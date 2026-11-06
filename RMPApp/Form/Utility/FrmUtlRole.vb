
Imports System.Data
Imports System.Data.SqlClient

Public Class FrmUtlRole

    Private currentMode As String = "VIEW"
    Private selectedRoleID As Integer = 0

    Private Sub FrmUtlRole_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClsFlexGrid.ApplyStyle(fgMenu)

        TampilkanRole()
        ModeView()
    End Sub

    Private Sub TampilkanRole()
        Try
            fgMenu.Redraw = False
            fgMenu.Rows.Count = 1

            Using cn As New SqlConnection(StrConnRMPApp)
                Using cmd As New SqlCommand("
                    SELECT RoleID, RoleCode, RoleName,
                           Description, IsActive
                    FROM dbo.tblUtlRole
                    ORDER BY RoleName", cn)

                    cn.Open()

                    Using rd As SqlDataReader = cmd.ExecuteReader()
                        Dim no As Integer = 0

                        While rd.Read()
                            no += 1

                            Dim r As Integer = fgMenu.Rows.Count
                            fgMenu.Rows.Add()

                            fgMenu.Item(r, 0) = no
                            fgMenu.Item(r, 1) = Convert.ToInt32(rd("RoleID"))
                            fgMenu.Item(r, 2) = Convert.ToString(rd("RoleCode"))
                            fgMenu.Item(r, 3) = Convert.ToString(rd("RoleName"))
                            fgMenu.Item(r, 4) = If(IsDBNull(rd("Description")),
                                                   "", Convert.ToString(rd("Description")))
                            fgMenu.Item(r, 5) = If(Convert.ToBoolean(rd("IsActive")),
                                                   "Ya", "Tidak")
                        End While
                    End Using
                End Using
            End Using

            fgMenu.AutoSizeCols()
            fgMenu.Cols(1).Width = 0

        Catch ex As Exception
            MsgBoxCustom.Show("Gagal membaca data role: " & ex.Message,
                              MsgBoxCustom.ButtonType.OK,
                              MsgBoxCustom.IconType.Error)
        Finally
            fgMenu.Redraw = True
        End Try
    End Sub

    Private Sub ModeView()
        currentMode = "VIEW"

        TextBox1.ReadOnly = True
        TextBox2.ReadOnly = True
        TextBox3.ReadOnly = True
        CheckBox1.Enabled = False

        btnAdd.Enabled = True
        btnEdit.Enabled = True
        btnSave.Enabled = False
        btnCancel.Enabled = False
    End Sub

    Private Sub ModeInput()
        TextBox1.ReadOnly = False
        TextBox2.ReadOnly = False
        TextBox3.ReadOnly = False
        CheckBox1.Enabled = True

        btnAdd.Enabled = False
        btnEdit.Enabled = False
        btnSave.Enabled = True
        btnCancel.Enabled = True
    End Sub

    Private Sub BersihkanForm()
        selectedRoleID = 0

        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        CheckBox1.Checked = True
    End Sub

    Private Sub IsiForm()
        If fgMenu.Row < 1 OrElse fgMenu.Row >= fgMenu.Rows.Count Then Return

        selectedRoleID = Convert.ToInt32(fgMenu.Item(fgMenu.Row, 1))
        TextBox1.Text = Convert.ToString(fgMenu.Item(fgMenu.Row, 2))
        TextBox2.Text = Convert.ToString(fgMenu.Item(fgMenu.Row, 3))
        TextBox3.Text = Convert.ToString(fgMenu.Item(fgMenu.Row, 4))
        CheckBox1.Checked = Convert.ToString(fgMenu.Item(fgMenu.Row, 5)) = "Ya"
    End Sub

    Private Sub fgMenu_RowColChange(sender As Object, e As EventArgs) Handles fgMenu.RowColChange
        If currentMode <> "VIEW" Then Return

        Try
            IsiForm()
        Catch
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        BersihkanForm()
        currentMode = "ADD"
        ModeInput()
        TextBox1.Focus()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If fgMenu.Rows.Count <= 1 OrElse fgMenu.Row < 1 Then
            MsgBoxCustom.Show("Pilih role yang akan diedit.",
                              MsgBoxCustom.ButtonType.OK,
                              MsgBoxCustom.IconType.Warning)
            Return
        End If

        IsiForm()
        currentMode = "EDIT"
        ModeInput()
        TextBox2.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim kode As String = TextBox1.Text.Trim()
        Dim nama As String = TextBox2.Text.Trim()
        Dim keterangan As String = TextBox3.Text.Trim()

        If kode = "" OrElse nama = "" Then
            MsgBoxCustom.Show("Kode role dan nama role wajib diisi.",
                              MsgBoxCustom.ButtonType.OK,
                              MsgBoxCustom.IconType.Warning)
            Return
        End If

        If currentMode <> "ADD" AndAlso currentMode <> "EDIT" Then Return

        Using cn As New SqlConnection(StrConnRMPApp)
            cn.Open()

            Using tr As SqlTransaction = cn.BeginTransaction()
                Try
                    If currentMode = "ADD" Then
                        Using cmd As New SqlCommand("
                            INSERT INTO dbo.tblUtlRole
                                (RoleCode, RoleName, Description, IsActive)
                            VALUES
                                (@Code, @Name, @Description, @Active)",
                            cn, tr)

                            TambahParameter(cmd, kode, nama, keterangan)
                            cmd.ExecuteNonQuery()
                        End Using

                    Else
                        Using cmd As New SqlCommand("
                            UPDATE dbo.tblUtlRole
                            SET RoleCode = @Code,
                                RoleName = @Name,
                                Description = @Description,
                                IsActive = @Active,
                                UpdatedDate = GETDATE()
                            WHERE RoleID = @RoleID",
                            cn, tr)

                            TambahParameter(cmd, kode, nama, keterangan)
                            cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = selectedRoleID

                            If cmd.ExecuteNonQuery() = 0 Then
                                Throw New Exception("Data role tidak ditemukan.")
                            End If
                        End Using
                    End If

                    tr.Commit()

                    MsgBoxCustom.Show("Data role berhasil disimpan.",
                                      MsgBoxCustom.ButtonType.OK,
                                      MsgBoxCustom.IconType.Information)

                    TampilkanRole()
                    BersihkanForm()
                    ModeView()

                Catch ex As SqlException When ex.Number = 2601 OrElse ex.Number = 2627
                    Try
                        tr.Rollback()
                    Catch
                    End Try

                    MsgBoxCustom.Show("Kode role sudah digunakan.",
                                      MsgBoxCustom.ButtonType.OK,
                                      MsgBoxCustom.IconType.Warning)

                Catch ex As Exception
                    Try
                        tr.Rollback()
                    Catch
                    End Try

                    MsgBoxCustom.Show("Gagal menyimpan data role: " & ex.Message,
                                      MsgBoxCustom.ButtonType.OK,
                                      MsgBoxCustom.IconType.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub TambahParameter(cmd As SqlCommand,
                                kode As String,
                                nama As String,
                                keterangan As String)

        cmd.Parameters.Add("@Code", SqlDbType.VarChar, 50).Value = kode
        cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = nama
        cmd.Parameters.Add("@Description", SqlDbType.VarChar, 255).Value =
            If(keterangan = "", CType(DBNull.Value, Object), keterangan)
        cmd.Parameters.Add("@Active", SqlDbType.Bit).Value = CheckBox1.Checked
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        BersihkanForm()
        ModeView()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub FrmUtlRole_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Func.ControlCentreForm(Me, PanelForm)
    End Sub
End Class
