Imports System.Data.SqlClient

Public Class FrmTrnApprovalPengeluaranBarangDialog
    Public Id As Integer
    Public Foto As String

    Private Sub FrmTrnApprovalPengeluaranBarangShow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim apiUrl As String = "http://192.168.12.168:5006/api/file/upload?subfolder=notapancangapi\ImagesInventarisPancang&filename=" & Foto & ".JPG&flag=notapancang"
        Dim bearerToken As String = "uPzT8Q3wK1XvR5yS7zV0ZbN4oM7lT3mF6gP9rL4eR1sY2oW8uP1zT0Y3oJ6kP8"
        Func.getfoto(apiUrl, bearerToken, PictureBox1)
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim koneksi As SqlConnection = DB.OpenConnection(StrConnRMPApp)
        Dim Transaksi As SqlTransaction
        Transaksi = koneksi.BeginTransaction

        If SaveApproval(koneksi, Transaksi) = False Then
            Transaksi.Rollback()
            MsgBox("Simpan Data Gagal", vbCritical, "Save Harga Item")
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        Transaksi.Commit()

        MsgBox("Approval Berhasil", vbInformation, AT)

        Me.Close()
        FrmTrnApprovalPengeluaranBarang.ShowData()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        If TxtKetReject.Text = "" Then
            MsgBox("Isi Dulu Keterangan Reject Nya", vbInformation, AT)
            Exit Sub
        End If

        DB.ExecuteNonQuery(StrConnRMPApp, " update TblInv_InventarisPengeluaran set approval=2,approval_by='" & ClsSession.UserID & "',approval_date=getdate(),approval_desc='" & TxtKetReject.Text & "',updated_by='" & ClsSession.UserID & "',updated_date=getdate() where id='" & Id & "' ")

        MsgBox("Reject Berhasil", vbInformation, AT)

        Me.Close()
        FrmTrnApprovalPengeluaranBarang.ShowData()
    End Sub

    Private Function SaveApproval(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        SaveApproval = False
        Dim MyCon As SqlConnection = Conn
        Dim MyConTrans As SqlTransaction = Trans
        Dim cmd As New SqlCommand

        With cmd
            .Connection = Conn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RMPApp..spInv_ApprovalPengeluaranBarang"
            .Transaction = MyConTrans

            .Parameters.Add("@Id", SqlDbType.Int).Value = Id
            .Parameters.Add("@UserLogin", SqlDbType.VarChar, 50).Value = ClsSession.UserID
            .Parameters.Add(New SqlParameter("@Flag", SqlDbType.TinyInt, 1, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .ExecuteNonQuery()
        End With

        Try
            If CInt(cmd.Parameters("@Flag").Value) = "0" Then
                cmd.Dispose()
                Exit Function
            End If

            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return True
    End Function

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class