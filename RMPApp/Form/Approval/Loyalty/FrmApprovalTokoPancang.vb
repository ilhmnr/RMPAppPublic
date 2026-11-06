Imports System.Data.SqlClient

Public Class FrmApprovalTokoPancang
    Private Sub FrmApprovalTokoPancang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Sub LoadData()
        Try
            Dim i As Integer
            Dim sql As String = ""

            sql = "SELECT id,UPPER(nama_toko) AS nama_toko,UPPER(alamat_toko) AS alamat_toko,UPPER(nama_pemilik_toko) AS nama_pemilik_toko, 
                   nomor_hp_toko,jam_buka,jam_tutup,koordinat_toko,NoRekToko,UPPER(NamaRekToko) AS NamaRekToko,Bank, 
                   Approved,ApprovedBy,ApprovedDate,ApprovedComp FROM [RMPApp].[dbo].[Android_tblPoinToko] WHERE actived = 1 AND Approved = 0"

            Using koneksi As New SqlCommand(sql,DB.OpenConnection(StrConnRMPApp))
                Using DR = koneksi.ExecuteReader()
                    If DR.HasRows Then
                        dgvlist.RowCount = 0
                        While DR.Read
                            With dgvlist
                                .Rows.Add()
                                .Item("No", i).Value = i + 1
                                .Item("ID", i).Value = DR!id
                                .Item("NamaToko", i).Value = DR!nama_toko
                                .Item("Alamat", i).Value = DR!alamat_toko
                                .Item("NamaPemilikToko", i).Value = DR!nama_pemilik_toko
                                .Item("NoHP", i).Value = DR!nomor_hp_toko
                                .Item("JamBuka", i).Value = DR!jam_buka
                                .Item("JamTutup", i).Value = DR!jam_tutup
                                .Item("KoordinatToko", i).Value = DR!koordinat_toko
                                .Item("NoRek", i).Value = DR!NoRekToko
                                .Item("NamaRek", i).Value = DR!NamaRekToko
                                .Item("Bank", i).Value = DR!Bank
                            End With
                            i += 1
                        End While
                    Else
                        dgvlist.Rows.Clear()
                        MsgBox("Data Tidak ditemukan !", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    DR.Close()
                End Using
            End Using
            DB.CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnexit_Click(sender As Object, e As EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub cbxAllApproved_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAllApproved.CheckedChanged
        If (cbxAllApproved.Checked) Then
            For Each row As DataGridViewRow In dgvlist.Rows
                row.Cells("Check").Value = True
            Next
        Else
            For Each row As DataGridViewRow In dgvlist.Rows
                row.Cells("Check").Value = False
            Next
        End If
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        If dgvlist.RowCount = 0 Then
            MsgBox("Tidak Ada Data Yang Disimpan!", vbExclamation)
            Exit Sub
        End If

        savedata()
        Call LoadData()
    End Sub

    Sub savedata()
        Me.Cursor = Cursors.WaitCursor
        Dim koneksis As SqlConnection = DB.OpenConnection(StrConnRMPApp)
        Dim Transaksi As SqlTransaction
        Transaksi = koneksis.BeginTransaction

        Try
            For i As Integer = 0 To dgvlist.RowCount - 1
                If dgvlist.Rows(i).Cells("Check").Value = True Then
                    If Simpan(koneksis, Transaksi, i) = False Then
                        Transaksi.Rollback()
                        Me.Cursor = Cursors.Default
                        MsgBox("Simpan Data Gagal!", vbExclamation, "Save Data - " & "")
                        Exit Sub
                    End If
                End If
            Next i

            Transaksi.Commit()
            MessageBox.Show("Save Completed!", "Save Data - " & "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Save Data Gagal!" & "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Transaksi.Rollback()
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function Simpan(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal i As Integer) As Boolean
        Dim MyCMD As New SqlCommand
        Simpan = False
        Try
            With MyCMD
                .Connection = Conn
                .CommandType = CommandType.StoredProcedure
                .CommandText = "RMPApp..spApprovalTokoPancang"
                .Transaction = Trans
                .Parameters.Add("@ID", SqlDbType.BigInt).Value = dgvlist.Item("ID", i).Value
                .Parameters.Add("@ApprovedBy", SqlDbType.VarChar).Value = ClsSession.UserID
                .Parameters.Add(New SqlParameter("@Error", SqlDbType.VarChar, 200, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
                .ExecuteNonQuery()
                .Dispose()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message & " infosp : " & MyCMD.Parameters("@Error").Value)
            Return False
        End Try
        Return True
    End Function
End Class