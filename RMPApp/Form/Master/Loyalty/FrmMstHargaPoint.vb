Imports System.Data.SqlClient

Public Class FrmMstHargaPoint
    Dim Perintah As String
    Dim NoReff_ As String
    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Dispose()
    End Sub

    Private Sub ShowHargaPoint()
        Dim sql As String
        Dim i As Integer = 0

        sql = "Select NoReff,tanggal,harga,CreatedBy FROM RMPApp..tbl_Mst_HargaPoint"
        Using koneksi As New SqlCommand(sql,DB.OpenConnection(StrConnRMPApp))
            Using DR = koneksi.ExecuteReader
                dgvlist.RowCount = 0
                If DR.HasRows Then
                    Do While DR.Read
                        With dgvlist
                            .Rows.Add()
                            .Item("No", i).Value = i + 1
                            .Item("NoReff", i).Value = DR!NoReff
                            .Item("tanggal", i).Value = DR!Tanggal
                            .Item("harga", i).Value = DR!Harga
                            .Item("CreatedBy", i).Value = DR!CreatedBy

                            .RowsDefaultCellStyle.BackColor = Color.White
                            .AlternatingRowsDefaultCellStyle.BackColor = Color.Azure
                        End With
                        i += 1
                    Loop
                Else
                    MsgBox("Data tidak ditemukan!")
                End If
            End Using
        End Using

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        btnEdit.Enabled = False
        btnAdd.Enabled = False
        btnsave.Enabled = True
        Perintah = "Add"
        txtnoreff.Text = ""
    End Sub

    Private Sub Clear()
        btnAdd.Enabled = True
        btnsave.Enabled = False
        btnEdit.Enabled = False

        txtnoreff.Clear()
        txtharga.Clear()
    End Sub

    Private Sub controlenabled(ByVal flag As Boolean)
        dttgl.Enabled = flag
        txtnoreff.Enabled = flag
        dgvlist.Enabled = flag
        txtharga.Enabled = flag
    End Sub

    Public Sub cmdENabled(ByVal flag As Boolean)

        btnAdd.Enabled = flag
        btnEdit.Enabled = flag
        ' btndelete.Enabled = flag
        btnsave.Enabled = flag

        btnclose.Enabled = flag
    End Sub



    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        Perintah = ""

        If txtnoreff.Text = "" Then
            MessageBox.Show("Tidak ada data yang di Edit", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        cmdENabled(False)
        Perintah = "Edit"
        txtnoreff.Enabled = False
        controlenabled(True)
        btnsave.Enabled = True

    End Sub

    Private Sub btnrefresh_Click(sender As Object, e As EventArgs) Handles btnrefresh.Click
        ShowHargaPoint()
    End Sub

    Private Function SimpanData(ByVal Conn2 As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        SimpanData = False
        Dim cqd As New SqlCommand
        Dim MyCon As SqlConnection = Conn2
        Dim MyConTrans As SqlTransaction = Trans
        cqd.Connection = MyCon
        cqd.CommandType = CommandType.StoredProcedure
        cqd.CommandText = "RMPApp..Sp_MstHargaPoint"
        cqd.Transaction = MyConTrans
        cqd.Parameters.Add("@RETURN_VALUE", SqlDbType.SmallInt).Direction = ParameterDirection.ReturnValue
        cqd.Parameters.Add("@Perintah", SqlDbType.VarChar, 20).Value = Perintah
        cqd.Parameters.Add(New SqlParameter("@NoReff", SqlDbType.VarChar, 20, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
        cqd.Parameters.Add("@NoReff2", SqlDbType.VarChar, 20).Value = txtnoreff.Text
        cqd.Parameters.Add("@Tanggal", SqlDbType.Date).Value = CDate(Format(dttgl.Value, "dd/MM/yyyy"))
        cqd.Parameters.Add("@Harga", SqlDbType.Decimal, 18, 0).Value = CDbl(txtharga.Text)
        cqd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID

        Dim A As String
        A = ClsSession.UserID
        A = A
        cqd.Parameters.Add(New SqlParameter("@Flag", SqlDbType.SmallInt, 5, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
        cqd.ExecuteNonQuery()
        If Perintah = "Add" Then
            NoReff_ = cqd.Parameters("@NoReff").Value
        Else
            NoReff_ = cqd.Parameters("@NoReff2").Value
        End If
        If CInt(cqd.Parameters("@Flag").Value) = 0 Then
            cqd.Dispose()
            Exit Function
        End If
        Return True

    End Function



    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim Koneksi As SqlConnection = DB.OpenConnection(StrConnAccounting)
        Dim Transaksi As SqlTransaction

        Transaksi = Koneksi.BeginTransaction
        Me.Cursor = Cursors.WaitCursor
        Try

            If txtharga.Text = "" Then
                MessageBox.Show("Cek Harga!", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If SimpanData(Koneksi, Transaksi) = False Then
                Transaksi.Rollback()
                Me.Cursor = Cursors.Default
                MessageBox.Show("Simpan data gagal!", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            'With dgvlist
            '    For i = 0 To .Rows.Count - 1
            '        If SimpanDataDtl(Koneksi, Transaksi, i) = False Then
            '            Transaksi.Rollback()
            '            MsgBox("Simpan Master Premi dan Inspektor Gagal", vbExclamation, "Save Data - " & AT)
            '            Exit Try
            '        End If
            '    Next
            'End With

            Transaksi.Commit()
            Me.Cursor = Cursors.Default
            MessageBox.Show("Simpan data berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)


            Call Clear()
            Perintah = ""
            cmdENabled(True)
            controlenabled(False)
            ShowHargaPoint()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Transaksi.Rollback()
            Koneksi.Close()
            Me.Cursor = Cursors.Default
        Finally
            Koneksi.Close()
            Me.Cursor = Cursors.Default
        End Try
        Call Clear()
        Call cmdENabled(True)
    End Sub

    Private Sub FormMstHargaPoint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnrefresh.Enabled = True

        btnclose.Enabled = True
        btnAdd.Enabled = True
        btnEdit.Enabled = True
        dttgl.Value = Format(Now, "yyyy-MM-dd")


    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Call Clear()
        Clear()
        ShowHargaPoint()

        cmdENabled(True)
    End Sub

    Private Sub dgvlist_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvlist.CellContentClick
        cmdENabled(True)
        txtnoreff.Text = If(IsDBNull(dgvlist.Item("NoReff", dgvlist.CurrentRow.Index).Value) = True, "", dgvlist.Item("NoReff", dgvlist.CurrentRow.Index).Value)
        dttgl.Value = dgvlist.Item("tanggal", dgvlist.CurrentRow.Index).Value
        txtharga.Text = dgvlist.Item("harga", dgvlist.CurrentRow.Index).Value

    End Sub



    'Private Sub btnfind_Click(sender As Object, e As EventArgs) Handles btnfind.Click
    '    FormMstHargaPointFind.Show()
    'End Sub
End Class