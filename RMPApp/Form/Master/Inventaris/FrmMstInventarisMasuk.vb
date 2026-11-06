Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmMstInventarisMasuk
    Dim AdaData As Integer
    Dim InventarisMasuk As String
    Dim Perintah As String
    Dim txt As CellRange
    Dim Id As Integer
    Private Sub FrmMstSatuanBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HeaderFG()
        ShowData()
        ClearData()
    End Sub
    Public Sub HeaderFG()
        With FG
            .Font = New System.Drawing.Font("Century Gothic", 7.0!, System.Drawing.FontStyle.Regular)
            .Rows.Count = 1
            .Cols.Count = 6
            .Cols.Fixed = 1
            .Styles.Fixed.BackColor = Color.PowderBlue
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleFixedNew.BackColor = Color.PowderBlue
            .Rows(0).StyleNew.BackColor = Color.PowderBlue
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 1
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "N0" : .Cols(0).Width = 50
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Satuan Barang" : .Cols(1).TextAlign = TextAlignEnum.LeftCenter : .Cols(1).AllowEditing = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Created By" : .Cols(2).TextAlign = TextAlignEnum.CenterCenter : .Cols(2).AllowEditing = False
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Created Date" : .Cols(3).TextAlign = TextAlignEnum.CenterCenter : .Cols(3).AllowEditing = False
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Not Actived" : .Cols(4).TextAlign = TextAlignEnum.CenterCenter : .Cols(4).AllowEditing = True : .Cols(4).Visible = False
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Id" : .Cols(5).Visible = False

            .AutoSizeCols()
        End With
    End Sub
    Private Sub ShowData()
        'variable
        Dim i As Integer = 1
        Dim dt As DataTable = New DataTable
        'jalankan tampil data
        Try
            dt = DB.ExecuteQuery(StrConnRMPApp, "select * from TblInv_MstInventarisMasuk where NotActived = 0 order by InventarisMasuk asc")
            If dt.Rows.Count > 0 Then
                With FG
                    For Each row As DataRow In dt.Rows
                        .AddItem(i)
                        .Item(i, 1) = row.Item("InventarisMasuk")
                        .Item(i, 2) = row.Item("CreatedBy")
                        .Item(i, 3) = row.Item("CreatedDate")
                        .Item(i, 5) = row.Item("IdInventarisMasuk")

                        i = i + 1
                    Next
                    .AutoSizeCols()
                End With
            Else
                Call MsgBox("Data Tidak Di Temulkan !", vbExclamation, AT)
            End If
        Catch EX As Exception
            MsgBox(EX.Message)
        End Try
    End Sub
    Private Sub ClearData()
        btnAdd.Enabled = True
        btnSave.Enabled = False
        BtnUpdate.Enabled = True
        btnCancel.Enabled = False

        Perintah = ""
        TxtSatuan.Clear()
        TxtSatuan.Enabled = False
        FG.Enabled = False

        txt = FG.GetCellRange(0, 4, 0, 4) : txt.Data = "Not Actived" : FG.Cols(4).Visible = False
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        btnAdd.Enabled = False
        btnSave.Enabled = True
        BtnUpdate.Enabled = False
        btnCancel.Enabled = True

        TxtSatuan.Focus()
        Perintah = "Add"
        TxtSatuan.Enabled = True
        FG.Enabled = False
    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        btnAdd.Enabled = False
        btnSave.Enabled = True
        BtnUpdate.Enabled = False
        btnCancel.Enabled = True

        Perintah = "Edit"
        FG.Enabled = True

        txt = FG.GetCellRange(0, 4, 0, 4) : txt.Data = "Not Actived" : FG.Cols(4).Visible = True
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'variabel
        Me.Cursor = Cursors.WaitCursor
        Dim koneksi As SqlConnection = DB.OpenConnection(StrConnRMPApp)
        Dim Transaksi As SqlTransaction
        Transaksi = koneksi.BeginTransaction
        'Jalamkan Fungsi save
        Try
            With FG
                If Perintah = "Add" Then
                    InventarisMasuk = TxtSatuan.Text
                    Id = 1 'agar parameter tidak kosong
                    If SpInv_SaveMstInventarisMasuk(koneksi, Transaksi) = False Then
                        Transaksi.Rollback()
                        MsgBox("Simpan Data Gagal", vbCritical, "Save Harga Item")
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                Else
                    For h = 1 To .Rows.Count - 1
                        If .Item(h, 4) = True Then
                            'beri tanda jika ada yang di edit
                            AdaData = "1"
                            'setting parameter sp
                            InventarisMasuk = .Item(h, 1)
                            Id = .Item(h, 5)
                            'jalankan sp nya
                            If SpInv_SaveMstInventarisMasuk(koneksi, Transaksi) = False Then
                                Transaksi.Rollback()
                                MsgBox("Simpan Data Gagal", vbCritical, "Save Harga Item")
                                Me.Cursor = Cursors.Default
                                Exit Sub
                            End If
                        End If
                    Next
                    'jika tidak ada data yang di edit
                    If AdaData <> "1" Then
                        MsgBox("Tidak Ada Data Yang Di Pilih,Centang Pada Kolom NotActived Untuk Memilih Data Yang Akan Di Edit!", vbExclamation, AT)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                End If
            End With
            Me.Cursor = Cursors.Default
            'jika flag save data nya add

            ' settign jika data berhasil di save
            Transaksi.Commit()
            MsgBox("Data Telah Tersimpan", MsgBoxStyle.Information)
            HeaderFG()
            ShowData()
            ClearData()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Cursor = Cursors.Default
        Finally
            koneksi.Close()
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Function SpInv_SaveMstInventarisMasuk(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        SpInv_SaveMstInventarisMasuk = False
        Dim MyCon As SqlConnection = Conn
        Dim MyConTrans As SqlTransaction = Trans
        Dim cmd As New SqlCommand
        With cmd
            'buat parameter sp
            .Connection = Conn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "spInv_saveInventarisMasuk"
            .Transaction = MyConTrans
            .Parameters.Add("@InventarisMasuk", SqlDbType.VarChar, 50).Value = InventarisMasuk
            .Parameters.Add("@UserLogin", SqlDbType.VarChar, 50).Value = ClsSession.UserID
            .Parameters.Add("@Perintah", SqlDbType.VarChar, 20).Value = Perintah
            .Parameters.Add("@Id", SqlDbType.Int).Value = Id
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

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ClearData()
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub
End Class