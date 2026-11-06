
Imports System.Data
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmMstApprove

    Private Enum FormMode
        Normal
        Add
        Edit
    End Enum

    Private mode As FormMode = FormMode.Normal

    Private Sub FrmMstApproval_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClsFlexGrid.ApplyStyle(fg)

        Cancel()
        ShowData()
    End Sub

    Private Sub SetMode(ByVal newMode As FormMode)
        mode = newMode

        Dim isInput As Boolean = (mode <> FormMode.Normal)

        txtNamaTransaksi.Enabled = isInput
        cboLevelApproval.Enabled = isInput
        txtApproval1By.Enabled = isInput
        txtApproval2By.Enabled = isInput
        txtApproval3By.Enabled = isInput
        txtApproval4By.Enabled = isInput
        txtApproval5By.Enabled = isInput

        fg.Enabled = Not isInput

        btnAdd.Enabled = Not isInput
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnSave.Enabled = isInput
        btnCancel.Enabled = isInput

        If mode = FormMode.Normal Then
            Dim isSelected As Boolean = (txtID.Text <> "0" AndAlso txtKodeTransaksi.Text <> "")

            btnEdit.Enabled = isSelected
            btnDelete.Enabled = isSelected
        End If
    End Sub

    Private Sub ClearInput()
        txtID.Text = "0"
        txtKodeTransaksi.Text = ""
        txtNamaTransaksi.Text = ""
        cboLevelApproval.SelectedIndex = -1

        txtApproval1By.Text = ""
        txtApproval2By.Text = ""
        txtApproval3By.Text = ""
        txtApproval4By.Text = ""
        txtApproval5By.Text = ""
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ClearInput()
        SetMode(FormMode.Add)
        txtNamaTransaksi.Focus()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If txtID.Text = "0" OrElse txtKodeTransaksi.Text = "" Then Exit Sub

        SetMode(FormMode.Edit)
        txtNamaTransaksi.Focus()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Cancel()
    End Sub

    Private Sub Cancel()
        ClearInput()
        SetMode(FormMode.Normal)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If txtNamaTransaksi.Text.Trim() = "" Then
            MsgBox("Nama transaksi harus diisi.", vbExclamation, AT)
            txtNamaTransaksi.Focus()
            Exit Sub
        End If

        If cboLevelApproval.SelectedIndex < 0 Then
            MsgBox("Level approval harus dipilih.", vbExclamation, AT)
            cboLevelApproval.Focus()
            Exit Sub
        End If

        If mode = FormMode.Normal Then Exit Sub

        Using Conn As New SqlConnection(StrConnRMPApp)
            Conn.Open()

            Using Trans As SqlTransaction = Conn.BeginTransaction()
                Try
                    If SaveHdr(Conn, Trans) Then
                        Trans.Commit()

                        MsgBox("Data berhasil disimpan.", vbInformation, AT)

                        ShowData()
                        Cancel()
                    Else
                        Trans.Rollback()
                    End If

                Catch ex As Exception
                    Trans.Rollback()
                    MsgBox(ex.Message, vbCritical, "Error")
                End Try
            End Using
        End Using

    End Sub

    Private Function SaveHdr(ByVal Conn As SqlConnection,
                             ByVal Trans As SqlTransaction) As Boolean

        SaveHdr = False

        Try
            Using cmd As New SqlCommand("RMPApp..spMstApprovalSave", Conn, Trans)

                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = CLng(txtID.Text)
                cmd.Parameters("@ID").Direction = ParameterDirection.InputOutput

                cmd.Parameters.Add("@KodeTransaksi", SqlDbType.VarChar, 30).Direction = ParameterDirection.Output

                cmd.Parameters.Add("@JudulTransaksi", SqlDbType.VarChar, 50).Value = txtNamaTransaksi.Text.Trim()
                cmd.Parameters.Add("@ApprovalLevel", SqlDbType.Int).Value = CInt(cboLevelApproval.Text)

                cmd.Parameters.Add("@Approval1By", SqlDbType.VarChar, 200).Value = txtApproval1By.Text.Trim()
                cmd.Parameters.Add("@Approval2By", SqlDbType.VarChar, 200).Value = txtApproval2By.Text.Trim()
                cmd.Parameters.Add("@Approval3By", SqlDbType.VarChar, 200).Value = txtApproval3By.Text.Trim()
                cmd.Parameters.Add("@Approval4By", SqlDbType.VarChar, 200).Value = txtApproval4By.Text.Trim()
                cmd.Parameters.Add("@Approval5By", SqlDbType.VarChar, 200).Value = txtApproval5By.Text.Trim()

                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
                cmd.Parameters.Add("@Flag", SqlDbType.Int).Direction = ParameterDirection.Output

                cmd.ExecuteNonQuery()

                Dim Flag As Integer = CInt(cmd.Parameters("@Flag").Value)

                If Flag = 0 Then
                    MsgBox("Data gagal disimpan.", vbCritical, AT)
                    Exit Function
                End If

                txtID.Text = cmd.Parameters("@ID").Value.ToString()
                txtKodeTransaksi.Text = cmd.Parameters("@KodeTransaksi").Value.ToString()

                SaveHdr = True

            End Using

        Catch ex As Exception
            Throw
        End Try

    End Function

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        If txtID.Text = "0" Then Exit Sub

        If MsgBox("Apakah Anda yakin ingin menghapus data ini?",
              vbQuestion + vbYesNo, AT) <> vbYes Then Exit Sub

        Try
            Dim sql As String =
            "UPDATE tblMstApproval SET deleted = 1 WHERE id = @ID"

            Dim params As SqlParameter() = {
            New SqlParameter("@ID", SqlDbType.BigInt) With {
                .Value = CLng(txtID.Text)
            }
        }

            DB.ExecuteNonQuery(StrConnRMPApp, sql, params)

            MsgBox("Data berhasil dihapus.", vbInformation, AT)

            ShowData()
            Cancel()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error")
        End Try

    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        ShowData()
    End Sub


    Public Sub ShowData()

        Dim sql As String =
        "SELECT * FROM tblMstApproval " &
        "WHERE deleted = 0 " &
        "AND judul_transaksi LIKE @Nama " &
        "ORDER BY id ASC"

        Dim params As SqlParameter() = {
        New SqlParameter("@Nama", SqlDbType.VarChar, 50) With {
            .Value = "%" & txtSearch.Text.Trim() & "%"
        }
    }

        Dim dt As DataTable = DB.ExecuteQuery(StrConnRMPApp, sql, params)

        With fg
            .Rows.Count = 1

            For Each row As DataRow In dt.Rows
                Dim i As Integer = .Rows.Count

                .AddItem(i.ToString())

                .Item(i, "ID") = row("id")
                .Item(i, "KodeTransaksi") = row("kode_transaksi")
                .Item(i, "NamaTransaksi") = row("judul_transaksi")
                .Item(i, "ApprovalLevel") = row("approval_level")

                .Item(i, "Approval1By") = row("approve_1_by")
                .Item(i, "Approval2By") = row("approve_2_by")
                .Item(i, "Approval3By") = row("approve_3_by")
                .Item(i, "Approval4By") = row("approve_4_by")
                .Item(i, "Approval5By") = row("approve_5_by")

                .Item(i, "CreatedBy") = row("created_by")
                .Item(i, "CreatedDate") = row("created_at")
                .Item(i, "UpdatedBy") = row("updated_by")
                .Item(i, "UpdatedDate") = row("updated_at")
            Next

            .AutoSizeCols()
        End With

        If dt.Rows.Count = 0 Then
            ClearInput()
            SetMode(FormMode.Normal)
        End If

    End Sub


    Private Sub fg_DoubleClick(sender As Object, e As EventArgs) Handles fg.DoubleClick

        If fg.Row < fg.Rows.Fixed OrElse fg.Row >= fg.Rows.Count Then Exit Sub

        If mode <> FormMode.Normal Then Exit Sub

        txtID.Text = fg.Item(fg.Row, "ID").ToString()
        txtKodeTransaksi.Text = fg.Item(fg.Row, "KodeTransaksi").ToString()
        txtNamaTransaksi.Text = fg.Item(fg.Row, "NamaTransaksi").ToString()

        cboLevelApproval.Text = fg.Item(fg.Row, "ApprovalLevel").ToString()

        txtApproval1By.Text = fg.Item(fg.Row, "Approval1By").ToString()
        txtApproval2By.Text = fg.Item(fg.Row, "Approval2By").ToString()
        txtApproval3By.Text = fg.Item(fg.Row, "Approval3By").ToString()
        txtApproval4By.Text = fg.Item(fg.Row, "Approval4By").ToString()
        txtApproval5By.Text = fg.Item(fg.Row, "Approval5By").ToString()

        SetMode(FormMode.Normal)

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class
