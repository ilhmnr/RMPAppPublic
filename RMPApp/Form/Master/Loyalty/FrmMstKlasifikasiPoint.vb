Imports System.Data.SqlClient

Public Class FrmMstKlasifikasiPoint
    Dim Perintah As String
    Dim NoReff_ As String

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Dispose()
    End Sub

    Private Sub ShowPoin()
        Dim sql As String
        Dim i As Integer = 0

        sql = "SELECT * FROM RMPApp..tbl_Mst_KlasifikasiPoin_Hdr WHERE CAST(Tanggal as date) BETWEEN '" & Format(tglAwal.Value, "yyyy-MM-dd") & "' AND '" & Format(tglAkhir.Value, "yyyy-MM-dd") & "'"

        Using koneksi As New SqlCommand(sql,DB.OpenConnection(StrConnRMPApp))
            Using DR = koneksi.ExecuteReader
                DataGridView1.RowCount = 0
                If DR.HasRows Then
                    Do While DR.Read
                        With DataGridView1
                            .Rows.Add()
                            .Item("No", i).Value = i + 1
                            .Item("NoReff", i).Value = DR!NoReff
                            .Item("Tanggal", i).Value = Format(DR!Tanggal, "dd/MM/yyyy")
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

    Private Sub ShowPoinLoad()
        Dim sql As String
        Dim i As Integer = 0

        sql = "SELECT TOP 1 * FROM RMPApp..tbl_Mst_KlasifikasiPoin_Hdr ORDER BY Tanggal DESC"

        Using koneksi As New SqlCommand(sql,DB.OpenConnection(StrConnRMPApp))
            Using DR = koneksi.ExecuteReader
                DataGridView1.RowCount = 0
                If DR.HasRows Then
                    Do While DR.Read
                        With DataGridView1
                            .Rows.Add()
                            .Item("No", i).Value = i + 1
                            .Item("NoReff", i).Value = DR!NoReff
                            .Item("Tanggal", i).Value = Format(DR!Tanggal, "dd/MM/yyyy")
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

    Private Sub btnrefresh_Click(sender As Object, e As EventArgs) Handles btnrefresh.Click
        ShowPoin()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        btnEdit.Enabled = False
        btnsave.Enabled = True
        btnAdd.Enabled = False
        Perintah = "Add"
        txtnoreff.Text = ""

        With dgvlist
            .Rows.Clear()
            .RowCount = 3
            .Item("klasifikasi", 0).Value = "PETANI KECIL"
            .Item("klasifikasi", 1).Value = "PETANI SEDANG"
            .Item("klasifikasi", 2).Value = "PETANI BESAR"
            .RowsDefaultCellStyle.BackColor = Color.White
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Azure
        End With

        DataGridView1.Rows.Clear()
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim Koneksi As SqlConnection = DB.OpenConnection(StrConnAccounting)
        Dim Transaksi As SqlTransaction

        Transaksi = Koneksi.BeginTransaction
        Me.Cursor = Cursors.WaitCursor

        Try
            If dttgl.Text = "" Then
                MessageBox.Show("Cek Tanggal!", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Try
            End If

            If SimpanDataHdr(Koneksi, Transaksi) = False Then
                Transaksi.Rollback()
                Me.Cursor = Cursors.Default
                MessageBox.Show("Simpan data gagal!", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Try
            End If

            With dgvlist
                For i = 0 To .Rows.Count - 1
                    If .Item("klasifikasi", i).Value <> "" Then
                        If SimpanDataDtl(Koneksi, Transaksi, i) = False Then
                            Transaksi.Rollback()
                            MsgBox("Simpan Master Klasifikasi Gagal", vbExclamation, "Save Data - " & AT)
                            Exit Try
                        End If
                    End If
                Next
            End With

            Transaksi.Commit()
            Me.Cursor = Cursors.Default
            MessageBox.Show("Simpan data berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Call ClearTxt()
            Perintah = ""
            cmdENabled(True)
            controlenabled(False)
            ShowPoin()
        Catch ex As Exception
        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Transaksi.Rollback()
        Koneksi.Close()
        Me.Cursor = Cursors.Default
        Finally
        Koneksi.Close()
        Me.Cursor = Cursors.Default
        End Try
        Call ClearTxt()
        Call cmdENabled(True)
    End Sub

    Private Sub controlenabled(ByVal flag As Boolean)
        dttgl.Enabled = flag
        txtnoreff.Enabled = flag
        dgvlist.Enabled = flag
    End Sub

    Public Sub cmdENabled(ByVal flag As Boolean)
        btnAdd.Enabled = flag
        btnEdit.Enabled = flag
        btnsave.Enabled = flag
        btnclose.Enabled = flag
    End Sub

    Private Function SimpanDataHdr(ByVal Conn2 As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        SimpanDataHdr = False
        Dim cqd As New SqlCommand
        Dim MyCon As SqlConnection = Conn2
        Dim MyConTrans As SqlTransaction = Trans
        cqd.Connection = MyCon
        cqd.CommandType = CommandType.StoredProcedure
        cqd.CommandText = "RMPApp..Sp_Mst_KlasifikasiPoin_Hdr"
        cqd.Transaction = MyConTrans
        cqd.Parameters.Add("@RETURN_VALUE", SqlDbType.SmallInt).Direction = ParameterDirection.ReturnValue
        cqd.Parameters.Add("@Perintah", SqlDbType.VarChar, 20).Value = Perintah
        cqd.Parameters.Add(New SqlParameter("@NoReff", SqlDbType.VarChar, 20, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
        cqd.Parameters.Add("@NoReff2", SqlDbType.VarChar, 30).Value = txtnoreff.Text
        cqd.Parameters.Add("@Tanggal", SqlDbType.Date).Value = CDate(Format(dttgl.Value, "dd/MM/yyyy"))
        cqd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
        cqd.Parameters.Add("@UpdatedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID

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

    Private Function SimpanDataDtl(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal i As Integer) As Boolean
        SimpanDataDtl = False
        Dim cqd As New SqlCommand
        Dim MyCon As SqlConnection = Conn
        Dim MyConTrans As SqlTransaction = Trans
        cqd.Connection = MyCon
        cqd.CommandType = CommandType.StoredProcedure
        cqd.CommandText = "RMPApp..Sp_Mst_KlasifikasiPoin_Dtl"
        cqd.Transaction = MyConTrans
        cqd.Parameters.Add("@RETURN_VALUE", SqlDbType.SmallInt).Direction = ParameterDirection.ReturnValue
        cqd.Parameters.Add("@ID", SqlDbType.Int).Value = 0
        cqd.Parameters.Add("@NoReff", SqlDbType.VarChar, 20).Value = NoReff_
        cqd.Parameters.Add("@Klasifikasi", SqlDbType.VarChar, 20).Value = dgvlist.Item("klasifikasi", i).Value
        cqd.Parameters.Add("@Point", SqlDbType.Int).Value = dgvlist.Item("point", i).Value
        cqd.Parameters.Add("@PersenRek", SqlDbType.Int).Value = dgvlist.Item("persenRek", i).Value
        cqd.Parameters.Add("@PersenTarra", SqlDbType.Int).Value = dgvlist.Item("persenTarra", i).Value
        cqd.Parameters.Add("@PersenLicin", SqlDbType.Int).Value = dgvlist.Item("persenLicin", i).Value
        cqd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
        cqd.Parameters.Add("@UpdatedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
        cqd.Parameters.Add("@Range1", SqlDbType.Int).Value = dgvlist.Item("Range1", i).Value
        cqd.Parameters.Add("@Range2", SqlDbType.Int).Value = IIf(IsDBNull(dgvlist.Item("Range2", i).Value), DBNull.Value, dgvlist.Item("Range2", i).Value)
        cqd.Parameters.Add("@Range3Month1", SqlDbType.Int).Value = dgvlist.Item("Range3Month1", i).Value
        cqd.Parameters.Add("@Range3Month2", SqlDbType.Int).Value = IIf(IsDBNull(dgvlist.Item("Range3Month2", i).Value), DBNull.Value, dgvlist.Item("Range3Month2", i).Value)
        cqd.Parameters.Add("@RangeDesc", SqlDbType.VarChar, 30).Value = dgvlist.Item("RangeDesc", i).Value
        cqd.Parameters.Add(New SqlParameter("@Flag", SqlDbType.SmallInt, 5, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
        cqd.ExecuteNonQuery()

        If CInt(cqd.Parameters("@Flag").Value) = 0 Then
            cqd.Dispose()
            Exit Function
        End If

        Return True
    End Function

    Private Sub ClearTxt()
        btnAdd.Enabled = True
        btnsave.Enabled = False
        btnEdit.Enabled = False

        txtnoreff.Clear()
        dgvlist.Rows.Clear()
        DataGridView1.Rows.Clear()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        cmdENabled(True)
        txtnoreff.Text = If(IsDBNull(DataGridView1.Item("NoReff", DataGridView1.CurrentRow.Index).Value) = True, "", DataGridView1.Item("NoReff", DataGridView1.CurrentRow.Index).Value)
        dttgl.Value = DataGridView1.Item("tanggal", DataGridView1.CurrentRow.Index).Value
        Showdgvlist(If(IsDBNull(DataGridView1.Item("NoReff", DataGridView1.CurrentRow.Index).Value) = True, "", DataGridView1.Item("NoReff", DataGridView1.CurrentRow.Index).Value))
    End Sub

    Private Sub Showdgvlist(noreff As String)
        Dim sql As String
        Dim i As Integer = 0

        sql = "SELECT Klasifikasi, Point, PersenRek, PersenTarra, PersenLicin,Range1,Range2,Range3month1,Range3month2,rangedesc FROM RMPApp..tbl_Mst_KlasifikasiPoin_Dtl WHERE NoReff='" & noreff & "' "

        Using koneksi As New SqlCommand(sql,DB.OpenConnection(StrConnRMPApp))
            Using DR = koneksi.ExecuteReader
                dgvlist.Rows.Clear()
                If DR.HasRows Then
                    Do While DR.Read
                        With dgvlist
                            .Rows.Add()
                            .Item("klasifikasi", i).Value = DR!Klasifikasi
                            .Item("point", i).Value = DR!Point
                            .Item("persenRek", i).Value = DR!PersenRek
                            .Item("persenTarra", i).Value = DR!PersenTarra
                            .Item("persenLicin", i).Value = DR!PersenLicin
                            .Item("Range1", i).Value = DR!Range1
                            .Item("Range2", i).Value = DR!Range2
                            .Item("Range3month1", i).Value = DR!Range3month1
                            .Item("Range3month2", i).Value = DR!Range3month2
                            .Item("rangedesc", i).Value = DR!rangedesc
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

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ClearTxt()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Perintah = ""

        If txtnoreff.Text = "" Then
            MessageBox.Show("Tidak ada data yang di Edit, Klik data terlebih dahulu", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        cmdENabled(False)
        Perintah = "Edit"
        btnAdd.Enabled = False
        btnEdit.Enabled = True
        btnsave.Enabled = True
        txtnoreff.Enabled = False
        controlenabled(True)
        ShowPoin()
    End Sub

    Private Sub FrmMasterKlasifikasiPoint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dttgl.Value = Format(Now, "yyyy-MM-dd")
        tglAwal.Value = Format(Now, "yyyy-MM-dd")
        tglAkhir.Value = Format(Now, "yyyy-MM-dd")
        ShowPoinLoad()
    End Sub
End Class