Imports System.Data.SqlClient
Imports System.Runtime.Remoting.Messaging
Imports System.Text
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid
Imports Spire.Pdf.HtmlConverter

Public Class FrmTrnBarangKeluar
    Dim txt As CellRange
    Dim teks As String
    Dim Bergerak As Integer
    'variabel sp 
    Dim Qty As Integer
    Dim Id As Integer
    Private Sub FrmTrnBarangKeluar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Combo.SetPancang(CmbPancang)

        Call HeaderFg()
        Call cleardata()
    End Sub

    Private Sub HeaderFg()
        With fg
            .Font = New System.Drawing.Font("Century Gothic", 7.0!, System.Drawing.FontStyle.Regular)
            .Cols.Count = 18
            .Cols.Fixed = 1
            .Rows.Count = 2
            '.Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            '.Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleFixedNew.BackColor = Color.PowderBlue
            .Rows(0).StyleNew.BackColor = Color.PowderBlue
            .Rows(1).StyleFixedNew.BackColor = Color.PowderBlue
            .Rows(1).StyleNew.BackColor = Color.PowderBlue

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 2
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 0, 1, 0) : txt.Data = "NO" : .Cols(0).AllowMerging = True : .Cols(0).TextAlign = TextAlignEnum.CenterCenter : .Cols(0).Visible = True : .Cols(0).AllowEditing = False
            txt = .GetCellRange(0, 1, 1, 1) : txt.Data = "Pancang" : .Cols(1).AllowMerging = True : .Cols(1).TextAlign = TextAlignEnum.CenterCenter : .Cols(1).Visible = False : .Cols(1).AllowEditing = False
            txt = .GetCellRange(0, 2, 1, 2) : txt.Data = "Kode Barang" : .Cols(2).AllowMerging = True : .Cols(2).TextAlign = TextAlignEnum.CenterCenter : .Cols(2).Visible = False : .Cols(2).AllowEditing = False
            txt = .GetCellRange(0, 3, 1, 3) : txt.Data = "NAMA BARANG" : .Cols(3).AllowMerging = True : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).Visible = True : .Cols(3).AllowEditing = False
            txt = .GetCellRange(0, 4, 1, 4) : txt.Data = "KATEGORI" : .Cols(4).AllowMerging = True : .Cols(4).TextAlign = TextAlignEnum.CenterCenter : .Cols(4).Visible = True : .Cols(4).AllowEditing = False
            txt = .GetCellRange(0, 5, 1, 5) : txt.Data = "QTY" : .Cols(5).AllowMerging = True : .Cols(5).TextAlign = TextAlignEnum.CenterCenter : .Cols(5).Visible = True : .Cols(5).AllowEditing = False
            txt = .GetCellRange(0, 6, 1, 6) : txt.Data = "SATUAN/UOM" : .Cols(6).AllowMerging = True : .Cols(6).TextAlign = TextAlignEnum.CenterCenter : .Cols(6).Visible = True : .Cols(6).AllowEditing = False
            txt = .GetCellRange(0, 7, 1, 7) : txt.Data = "HARGA/SATUAN" : .Cols(7).AllowMerging = True : .Cols(7).TextAlign = TextAlignEnum.RightCenter : .Cols(7).Format = "#,###0" : .Cols(7).Visible = True : .Cols(7).AllowEditing = False
            txt = .GetCellRange(0, 8, 1, 8) : txt.Data = "Tanggal Alokasi" : .Cols(8).AllowMerging = True : .Cols(8).TextAlign = TextAlignEnum.CenterCenter : .Cols(8).Visible = True : .Cols(8).AllowEditing = False
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "TOTAL" : .Cols(9).AllowMerging = False : .Cols(9).TextAlign = TextAlignEnum.RightCenter : .Cols(9).Format = "#,###0" : .Cols(9).Visible = True : .Cols(9).AllowEditing = False
            txt = .GetCellRange(1, 9, 1, 9) : txt.Data = "TOTAL SEMUA" : .Cols(9).Visible = True
            txt = .GetCellRange(0, 10, 1, 10) : txt.Data = "KONDISI" : .Cols(10).AllowMerging = True : .Cols(10).TextAlign = TextAlignEnum.CenterCenter : .Cols(10).Visible = False : .Cols(10).AllowEditing = False
            txt = .GetCellRange(0, 11, 1, 11) : txt.Data = "KETERANGAN/PENANGGUNG JAWAB" : .Cols(11).AllowMerging = True : .Cols(11).TextAlign = TextAlignEnum.CenterCenter : .Cols(11).Visible = True : .Cols(11).AllowEditing = False
            txt = .GetCellRange(0, 12, 1, 12) : txt.Data = "Inventaris Masuk" : .Cols(12).AllowMerging = True : .Cols(12).TextAlign = TextAlignEnum.CenterCenter : .Cols(12).Visible = True : .Cols(12).AllowEditing = False
            txt = .GetCellRange(0, 13, 0, 16) : txt.Data = "Kontrol Edit"
            txt = .GetCellRange(1, 13, 1, 13) : txt.Data = "Kurang" : .Cols(13).AllowMerging = True : .Cols(13).TextAlign = TextAlignEnum.CenterCenter : .Cols(13).Visible = False : .Cols(13).AllowEditing = False
            txt = .GetCellRange(1, 14, 1, 14) : txt.Data = "Total Keluar" : .Cols(14).AllowMerging = True : .Cols(14).TextAlign = TextAlignEnum.CenterCenter : .Cols(14).Visible = False : .Cols(14).AllowEditing = False
            txt = .GetCellRange(1, 15, 1, 15) : txt.Data = "Tambah" : .Cols(15).AllowMerging = True : .Cols(15).TextAlign = TextAlignEnum.CenterCenter : .Cols(15).Visible = False : .Cols(15).AllowEditing = False
            txt = .GetCellRange(1, 16, 1, 16) : txt.Data = "Hapus Semua" : .Cols(16).AllowMerging = True : .Cols(16).TextAlign = TextAlignEnum.CenterCenter : .Cols(16).Visible = False : .Cols(16).AllowEditing = True
            txt = .GetCellRange(1, 17, 1, 17) : txt.Data = "id" : .Cols(17).AllowMerging = True : .Cols(17).TextAlign = TextAlignEnum.CenterCenter : .Cols(17).Visible = False : .Cols(17).AllowEditing = False

            .AutoSizeCols()
        End With
    End Sub
    Private Sub cleardata()
        BtnCari.Enabled = True
        btnSave.Enabled = False
        BtnCancel.Enabled = False
        BtnEdit.Enabled = False

        CmbPancang.Enabled = True
        TxtNamaBarang.Enabled = True
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click
        With fg
            'jika fg ada isi nya
            If .Rows.Count > 1 Then
                'jika tombol TAMBAH pada fg di klik
                If .Col = 15 And .Item(.RowSel, 5) >= 1 Then
                    .Item(.RowSel, 5) -= 1
                    .Item(.RowSel, 14) += 1
                    If .Item(.RowSel, 5) = 0 Then
                        .Item(.RowSel, 16) = True
                    Else
                        .Item(.RowSel, 16) = False
                    End If
                    'jika tombol KURANG pada fg di klik
                ElseIf .Col = 13 And .Item(.RowSel, 14) >= 1 Then
                    .Item(.RowSel, 5) += 1
                    .Item(.RowSel, 14) -= 1
                    If .Item(.RowSel, 5) = 0 Then
                        .Item(.RowSel, 16) = True
                    Else
                        .Item(.RowSel, 16) = False
                    End If
                    'jika checkbox hapus semua di pilih
                ElseIf .Col = 16 Then
                    If .Item(.RowSel, 16) = True Then
                        .Item(.RowSel, 14) += .Item(.RowSel, 5)
                        .Item(.RowSel, 5) = 0
                    ElseIf .Item(.RowSel, 16) = False Then
                        .Item(.RowSel, 5) += .Item(.RowSel, 14)
                        .Item(.RowSel, 14) = 0
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub BtnCari_Click(sender As Object, e As EventArgs) Handles BtnCari.Click
        Call ShowData(0)
        If fg.Rows.Count > 1 Then
            BtnEdit.Enabled = True
        Else
            BtnEdit.Enabled = False
        End If
    End Sub
    Private Sub ShowData(ByVal flag As Integer)
        Dim dt As DataTable = New DataTable
        Dim i As Integer = 2
        Dim sql As String = ""
        Dim Total As Decimal = 0

        If CmbPancang.Text = "" Then
            MsgBox("Pilih Dulu PancangNya !", vbInformation, AT)
            CmbPancang.Focus()
            Exit Sub
        End If

        If TxtNamaBarang.Text <> "" Then
            sql = Func.SetCondition(sql, "NamaBarang like '%" & TxtNamaBarang.Text & "%'")
        End If

        Try
            fg.Rows.Count = 2
            dt = DB.ExecuteQuery(StrConnRMPApp, "select * from RMPApp..vwInv_MonBarangPancang where IdPancang = '" & CmbPancang.SelectedValue & "' " & IIf(sql = "", "", " AND " & sql) & " and  NotActived = 0 ORDER BY NamaBarang Asc")

            If dt.Rows.Count > 0 Then
                With fg
                    For Each row As DataRow In dt.Rows
                        .AddItem(i - 1)
                        .Item(i, 1) = row.Item("Pancang")
                        .Item(i, 2) = row.Item("KodeBarang")
                        .Item(i, 3) = row.Item("NamaBarang")
                        .Item(i, 4) = row.Item("Kategori")
                        .Item(i, 5) = IIf(IsDBNull(row.Item("Qty")), 0, row.Item("Qty"))
                        .Item(i, 6) = row.Item("Satuan")
                        .Item(i, 7) = row.Item("Harga")
                        .Item(i, 8) = row.Item("TglAlokasi")
                        .Item(i, 9) = row.Item("Harga") * row.Item("Qty")
                        .Item(i, 10) = row.Item("Kondisi")
                        .Item(i, 11) = row.Item("PenanggungJawab")
                        .Item(i, 12) = row.Item("InventarisMasuk")
                        .Item(i, 14) = 0
                        .Item(i, 17) = row.Item("Id")

                        ' Masukan Gambar Ke Dalam FlexGrid
                        Dim style As C1.Win.C1FlexGrid.CellStyle = Me.fg.Styles.Add("style")
                        style.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
                        Me.fg.SetCellImage(i, 13, My.Resources.TombolKurang)
                        Me.fg.SetCellStyle(i, 13, style)

                        ' Masukan Gambar Ke Dalam FlexGrid
                        Dim style1 As C1.Win.C1FlexGrid.CellStyle = Me.fg.Styles.Add("style")
                        style1.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
                        Me.fg.SetCellImage(i, 15, My.Resources.TombolTambah)
                        Me.fg.SetCellStyle(i, 15, style1)

                        i = i + 1
                    Next

                    For i = 2 To .Rows.Count - 1
                        Total += .Item(i, 9)
                    Next

                    Dim nilai As Decimal = Total
                    Dim nilaiFormatted As String = String.Format("{0:#,##0}", nilai)

                    txt = .GetCellRange(1, 9, 1, 9) : txt.Data = nilaiFormatted
                    .Rows(0).StyleNew.TextAlign = TextAlignEnum.CenterCenter

                    If .Rows.Count > 1 Then

                    End If
                    .AutoSizeCols()
                End With
            Else
                If flag = 0 Then
                    MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
                End If
            End If
        Catch EX As Exception
            MsgBox(EX.Message)
        End Try
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        BtnCari.Enabled = False
        btnSave.Enabled = True
        BtnCancel.Enabled = True
        BtnEdit.Enabled = False

        CmbPancang.Enabled = False
        TxtNamaBarang.Enabled = False

        With fg
            txt = .GetCellRange(1, 13, 1, 13) : txt.Data = "Kurang" : .Cols(13).Visible = True
            txt = .GetCellRange(1, 14, 1, 14) : txt.Data = "Total Keluar" : .Cols(14).Visible = True
            txt = .GetCellRange(1, 15, 1, 15) : txt.Data = "Tambah" : .Cols(15).Visible = True
            txt = .GetCellRange(1, 16, 1, 16) : txt.Data = "Hapus Semua" : .Cols(16).Visible = True
        End With
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Call cleardata()
        Call ShowData(0)

        If fg.Rows.Count > 1 Then
            BtnEdit.Enabled = True
        Else
            BtnEdit.Enabled = False
        End If

        If fg.Rows.Count > 1 Then

        End If

        With fg
            txt = .GetCellRange(1, 13, 1, 13) : txt.Data = "Kurang" : .Cols(13).Visible = False
            txt = .GetCellRange(1, 14, 1, 14) : txt.Data = "Total Keluar" : .Cols(14).Visible = False
            txt = .GetCellRange(1, 15, 1, 15) : txt.Data = "Tambah" : .Cols(15).Visible = False
            txt = .GetCellRange(1, 16, 1, 16) : txt.Data = "Hapus Semua" : .Cols(16).Visible = False
        End With
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Me.Cursor = Cursors.WaitCursor
        'Membuat Variabel
        Dim koneksi As SqlConnection = DB.OpenConnection(StrConnRMPApp)
        Dim Transaksi As SqlTransaction
        Transaksi = koneksi.BeginTransaction

        Try
            With fg
                For i = 2 To .Rows.Count - 1
                    Qty = .Item(i, 5)
                    Id = .Item(i, 17)
                    If Sp_SaveTrnBarangKeluarPancang(koneksi, Transaksi) = False Then
                        Transaksi.Rollback()
                        MsgBox("Simpan Data Gagal", vbCritical, "Sp_SaveTrnBarangKeluarPancang")
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                Next
            End With
            Transaksi.Commit()
            MsgBox("Data Telah Tersimpan", MsgBoxStyle.Information)
            Call cleardata()
            HeaderFg()
            ShowData(0)
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            koneksi.Close()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub TxtNamaBarang_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtNamaBarang.KeyUp
        ShowData(1)
        If fg.Rows.Count > 2 Then
            BtnEdit.Enabled = True
        Else
            BtnEdit.Enabled = False
        End If
    End Sub

    Private Function Sp_SaveTrnBarangKeluarPancang(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        Sp_SaveTrnBarangKeluarPancang = False
        Dim MyCon As SqlConnection = Conn
        Dim MyConTrans As SqlTransaction = Trans
        Dim cmd As New SqlCommand
        Try
            With cmd
                .Connection = Conn
                .CommandType = CommandType.StoredProcedure
                .CommandText = "RMPApp..SpInv_SaveTrnBarangKeluarPancang"
                .Transaction = MyConTrans
                .Parameters.Add("@Id", SqlDbType.Int).Value = Id
                .Parameters.Add("@Qty", SqlDbType.Int).Value = Qty
                .Parameters.Add("@UserLogin", SqlDbType.VarChar, 50).Value = ClsSession.UserID
                .Parameters.Add(New SqlParameter("@Flag", SqlDbType.TinyInt, 1, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
                .ExecuteNonQuery()
            End With
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
End Class