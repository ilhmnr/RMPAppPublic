
Imports System.Data.SqlClient

Public Class FrmUtlMenuVisibel

    Private dtMenu As DataTable

    Private Sub FrmUtlMenuVisibel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClsFlexGrid.ApplyStyle(fgMenu)

        With fgMenu
            .AllowEditing = True
            .Cols("Visibel").AllowEditing = True
        End With

        TampilkanMenu()
    End Sub

    Private Sub TampilkanMenu()
        Try
            fgMenu.Redraw = False
            fgMenu.Rows.Count = 1

            Using cn As New SqlConnection(StrConnRMPApp)
                Using cmd As New SqlCommand("
                    SELECT MenuID, MenuTag, MenuText, ParentTag,
                           MenuLevel, SortOrder, IsVisible
                    FROM dbo.tblUtlMenu
                    ORDER BY SortOrder, MenuID", cn)

                    Using da As New SqlDataAdapter(cmd)
                        dtMenu = New DataTable
                        da.Fill(dtMenu)
                    End Using
                End Using
            End Using

            Dim no As Integer = 0

            For Each dr As DataRow In dtMenu.Rows
                no += 1

                Dim r As Integer = fgMenu.Rows.Count
                fgMenu.Rows.Add()

                Dim level As Integer = Convert.ToInt32(dr("MenuLevel"))
                Dim nama As String = Convert.ToString(dr("MenuText"))

                fgMenu.Item(r, "No") = no
                fgMenu.Item(r, "Level") = level
                fgMenu.Item(r, "NamaMenu") =
                    New String(" "c, Math.Max(0, level - 1) * 4) & nama
                fgMenu.Item(r, "NameTag") = Convert.ToString(dr("MenuTag"))
                fgMenu.Item(r, "Visibel") = Convert.ToBoolean(dr("IsVisible"))
            Next

            fgMenu.AutoSizeCols()

        Catch ex As Exception
            MsgBoxCustom.Show("Gagal membaca data menu: " & ex.Message,
                              MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
        Finally
            fgMenu.Redraw = True
        End Try
    End Sub

    Private Sub btnPilihSemua_Click(sender As Object, e As EventArgs) Handles btnPilihSemua.Click
        For r As Integer = 1 To fgMenu.Rows.Count - 1
            fgMenu.Item(r, "Visibel") = True
        Next
    End Sub

    Private Sub btnHapusSemua_Click(sender As Object, e As EventArgs) Handles btnHapusSemua.Click
        For r As Integer = 1 To fgMenu.Rows.Count - 1
            fgMenu.Item(r, "Visibel") = False
        Next
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        TampilkanMenu()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If fgMenu.Rows.Count <= 1 Then
            MsgBoxCustom.Show("Tidak ada menu untuk disimpan.",
                              MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
            Return
        End If

        If MsgBoxCustom.Show("Simpan pengaturan visibilitas semua menu?", MsgBoxCustom.ButtonType.YesNo, MsgBoxCustom.IconType.Question) <> DialogResult.Yes Then
            Return
        End If

        Using cn As New SqlConnection(StrConnRMPApp)
            cn.Open()

            Using tr As SqlTransaction = cn.BeginTransaction()
                Try
                    Dim total As Integer = 0

                    For r As Integer = 1 To fgMenu.Rows.Count - 1
                        Dim tag As String =
                            Convert.ToString(fgMenu.Item(r, "NameTag")).Trim()

                        If tag = "" Then Continue For

                        Dim visible As Boolean =
                            Convert.ToBoolean(fgMenu.Item(r, "Visibel"))

                        Using cmd As New SqlCommand("
                            UPDATE dbo.tblUtlMenu
                            SET IsVisible = @IsVisible,
                                UpdatedDate = GETDATE()
                            WHERE MenuTag = @Tag", cn, tr)

                            cmd.Parameters.Add("@IsVisible", SqlDbType.Bit).Value = visible
                            cmd.Parameters.Add("@Tag", SqlDbType.VarChar, 150).Value = tag

                            total += cmd.ExecuteNonQuery()
                        End Using
                    Next

                    tr.Commit()

                    MsgBoxCustom.Show("Berhasil menyimpan visibilitas menu. Total menu yang diperbarui: " & total.ToString(),
                                      MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)

                Catch ex As Exception
                    Try
                        tr.Rollback()
                    Catch
                    End Try

                    MsgBoxCustom.Show("Gagal menyimpan visibilitas menu: " & ex.Message,
                                      MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

End Class
