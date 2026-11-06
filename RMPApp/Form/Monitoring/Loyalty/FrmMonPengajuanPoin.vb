Imports System.ComponentModel
Imports C1.Win.C1FlexGrid

Public Class FrmMonPengajuanPoin
    Dim dt As DataTable = New DataTable()
    Dim Teks As String
    Dim Bergerak As Integer

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub FrmMonPengajuanPoin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Clear()
        SearchFG()
        HeaderFG()
        Modul_RMP.Combo.SettokoPancang(cboToko)
        Teks = lblInfo.Text
        Timer.Start()
        'schKg()
        Modul_RMP.Combo.SetSupplier(cmbS_Petani)
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        lblInfo.Text = Bergerak
        Teks = Microsoft.VisualBasic.Right(Teks, Len(Teks) - 1) & Microsoft.VisualBasic.Left(Teks, 1)
        lblInfo.Text = Teks
    End Sub

    Private Sub SearchFG()
        With schfg
            .SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
            .SearchDelay = 2
            .Watermark = "Search Here ..."
            .SetC1FlexGridSearchPanel(fg, schfg)
        End With
    End Sub

    Private Sub Clear()
        dtp1.Value = Format(Now, "dd/MM/yyyy")
        dtp2.Value = Format(Now, "dd/MM/yyyy")
        Dt1.Value = Format(Now, "dd/MM/yyyy")
        Dt2.Value = Format(Now, "dd/MM/yyyy")

        dtp1.Enabled = False
        dtp2.Enabled = False
        cboToko.Enabled = False
        cboToko.Text = ""
        fg.Rows.Count = 2
        chkTgl.Checked = False
        chkToko.Checked = False
    End Sub

    Public Sub HeaderFG()
        Dim txt As CellRange
        With fg
            .Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Regular)
            .Cols.Count = 47
            .Cols.Fixed = 0
            .AllowMergingFixed = AllowMergingEnum.FixedOnly
            .Styles.Fixed.BackColor = Color.FromArgb(240, 248, 254)
            .Styles.Alternate.BackColor = Color.White
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)
            .Styles.Frozen.BackColor = Color.FromArgb(240, 248, 254)
            .Styles.FrozenAlternate.BackColor = Color.FromArgb(240, 248, 254)

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 2
            .AllowMerging = AllowMergingEnum.RestrictAll
            .Rows(0).AllowMerging = True
            .Rows(1).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Cols.Frozen = 6


            'CELL2()




            txt = .GetCellRange(0, 0, 1, 0) : txt.Data = "NO" : .Cols(0).Width = 50 : .Cols(0).AllowMerging = True : .Cols(0).Name = "NO"
            txt = .GetCellRange(0, 1, 1, 1) : txt.Data = "ID" : .Cols(1).TextAlign = TextAlignEnum.CenterCenter : .Cols(1).AllowMerging = True : .Cols(1).Name = "ID" : .Cols(1).Visible = False
            txt = .GetCellRange(0, 2, 1, 2) : txt.Data = "ID TOKO" : .Cols(2).TextAlign = TextAlignEnum.CenterCenter : .Cols(2).AllowMerging = True : .Cols(2).Name = "IDTOKO" : .Cols(2).Visible = False
            txt = .GetCellRange(0, 3, 1, 3) : txt.Data = "NAMA TOKO" : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).AllowMerging = True : .Cols(3).Name = "NAMATOKO"
            txt = .GetCellRange(0, 4, 1, 4) : txt.Data = "ALAMAT TOKO" : .Cols(4).TextAlign = TextAlignEnum.LeftCenter : .Cols(4).AllowMerging = True : .Cols(4).Name = "ALAMATTOKO"
            txt = .GetCellRange(0, 5, 1, 5) : txt.Data = "KODE SUPPLIER" : .Cols(5).TextAlign = TextAlignEnum.CenterCenter : .Cols(5).AllowMerging = True : .Cols(5).Name = "KODESUPPLIER"
            txt = .GetCellRange(0, 6, 1, 6) : txt.Data = "NAMA SUPPLIER" : .Cols(6).TextAlign = TextAlignEnum.LeftCenter : .Cols(6).AllowMerging = True : .Cols(6).Name = "NAMASUPPLIER"
            txt = .GetCellRange(0, 7, 1, 7) : txt.Data = "ALAMAT SUPPLIER" : .Cols(7).TextAlign = TextAlignEnum.LeftCenter : .Cols(7).AllowMerging = True : .Cols(7).Name = "ALAMATSUPPLIER"
            txt = .GetCellRange(0, 8, 1, 8) : txt.Data = "JENIS TRANSAKSI" : .Cols(8).TextAlign = TextAlignEnum.CenterCenter : .Cols(8).AllowMerging = True : .Cols(8).Name = "JENISTRANSAKSI"
            txt = .GetCellRange(0, 9, 1, 9) : txt.Data = "KODE PENGAJUAN" : .Cols(9).TextAlign = TextAlignEnum.CenterCenter : .Cols(9).AllowMerging = True : .Cols(9).Name = "KODEPENGAJUAN"
            txt = .GetCellRange(0, 10, 1, 10) : txt.Data = "TGL PENGAJUAN" : .Cols(10).TextAlign = TextAlignEnum.CenterCenter : .Cols(10).AllowMerging = True : .Cols(10).Name = "TGLPENGAJUAN"
            txt = .GetCellRange(0, 11, 1, 11) : txt.Data = "NOTRANS PENGAJUAN" : .Cols(11).TextAlign = TextAlignEnum.CenterCenter : .Cols(11).AllowMerging = True : .Cols(11).Name = "NOTRANSPENGAJUAN"
            txt = .GetCellRange(0, 12, 1, 12) : txt.Data = "PENGAJUAN BY" : .Cols(12).TextAlign = TextAlignEnum.CenterCenter : .Cols(12).AllowMerging = True : .Cols(12).Name = "PENGAJUANBY"
            txt = .GetCellRange(0, 13, 1, 13) : txt.Data = "PENGAJUAN CREATED DATE" : .Cols(13).TextAlign = TextAlignEnum.CenterCenter : .Cols(13).AllowMerging = True : .Cols(13).Name = "PENGAJUANCREATEDDATE"
            txt = .GetCellRange(0, 14, 1, 14) : txt.Data = "TGL TRANSAKSI KLAIM" : .Cols(14).TextAlign = TextAlignEnum.CenterCenter : .Cols(14).AllowMerging = True : .Cols(14).Name = "TGLTRANSAKSIKLAIM"
            txt = .GetCellRange(0, 15, 1, 15) : txt.Data = "ITEM ID" : .Cols(15).TextAlign = TextAlignEnum.CenterCenter : .Cols(15).AllowMerging = True : .Cols(15).Name = "ITEMID" : .Cols(15).Visible = False
            txt = .GetCellRange(0, 16, 1, 16) : txt.Data = "KODE ITEM" : .Cols(16).TextAlign = TextAlignEnum.CenterCenter : .Cols(16).AllowMerging = True : .Cols(16).Name = "KODEITEM"
            txt = .GetCellRange(0, 17, 1, 17) : txt.Data = "NAMA ITEM" : .Cols(17).TextAlign = TextAlignEnum.LeftCenter : .Cols(17).AllowMerging = True : .Cols(17).Name = "NAMAITEM"
            txt = .GetCellRange(0, 18, 1, 18) : txt.Data = "JENIS ITEM" : .Cols(18).TextAlign = TextAlignEnum.LeftCenter : .Cols(18).AllowMerging = True : .Cols(18).Name = "JENISITEM"
            txt = .GetCellRange(0, 19, 1, 19) : txt.Data = "FOTO" : .Cols(19).TextAlign = TextAlignEnum.CenterCenter : .Cols(19).AllowMerging = True : .Cols(19).Name = "FOTO"
            txt = .GetCellRange(0, 20, 1, 20) : txt.Data = "SATUAN" : .Cols(20).TextAlign = TextAlignEnum.CenterCenter : .Cols(20).AllowMerging = True : .Cols(20).Name = "SATUAN"
            txt = .GetCellRange(0, 21, 1, 21) : txt.Data = "QTY" : .Cols(21).TextAlign = TextAlignEnum.CenterCenter : .Cols(21).AllowMerging = True : .Cols(21).Name = "QTY"
            txt = .GetCellRange(0, 22, 1, 22) : txt.Data = "POIN" : .Cols(22).TextAlign = TextAlignEnum.RightCenter : .Cols(22).Format = "#,###0" : .Cols(22).AllowMerging = True : .Cols(22).Name = "POIN"
            txt = .GetCellRange(0, 23, 1, 23) : txt.Data = "RUPIAH" : .Cols(23).TextAlign = TextAlignEnum.RightCenter : .Cols(23).Format = "#,###0" : .Cols(23).AllowMerging = True : .Cols(23).Name = "RUPIAH"
            txt = .GetCellRange(0, 24, 1, 24) : txt.Data = "BAYAR POIN" : .Cols(24).TextAlign = TextAlignEnum.RightCenter : .Cols(24).Format = "#,###0" : .Cols(24).AllowMerging = True : .Cols(24).Name = "BAYARPOIN"
            txt = .GetCellRange(0, 25, 1, 25) : txt.Data = "BAYAR RUPIAH" : .Cols(25).TextAlign = TextAlignEnum.RightCenter : .Cols(25).Format = "#,###0" : .Cols(25).AllowMerging = True : .Cols(25).Name = "BAYARRUPIAH"


            txt = .GetCellRange(0, 26, 0, 28) : txt.Data = "BELUM DIAJUKAN" : .Cols(26).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 26, 1, 26) : txt.Data = "QTY TUKAR" : .Cols(26).TextAlign = TextAlignEnum.RightCenter : .Cols(26).AllowMerging = True : .Cols(26).Name = "QTYTUKAR" : .Cols(26).Format = "#,###0"
            txt = .GetCellRange(1, 27, 1, 27) : txt.Data = "POIN TUKAR" : .Cols(27).TextAlign = TextAlignEnum.RightCenter : .Cols(27).AllowMerging = True : .Cols(27).Name = "POINTUKAR" : .Cols(27).Format = "#,###0"
            txt = .GetCellRange(1, 28, 1, 28) : txt.Data = "RP POIN TUKAR" : .Cols(28).TextAlign = TextAlignEnum.RightCenter : .Cols(28).AllowMerging = True : .Cols(28).Name = "RPPOINTUKAR" : .Cols(28).Format = "#,###0"

            txt = .GetCellRange(0, 29, 0, 31) : txt.Data = "PENGAJUAN TOKO" : .Cols(29).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 29, 1, 29) : txt.Data = "QTY PENGAJUAN" : .Cols(29).TextAlign = TextAlignEnum.RightCenter : .Cols(29).AllowMerging = True : .Cols(29).Name = "QTYPENGAJUAN" : .Cols(29).Format = "#,###0"
            txt = .GetCellRange(1, 30, 1, 30) : txt.Data = "POIN PENGAJUAN" : .Cols(30).TextAlign = TextAlignEnum.RightCenter : .Cols(30).AllowMerging = True : .Cols(30).Name = "POINPENGAJUAN" : .Cols(30).Format = "#,###0"
            txt = .GetCellRange(1, 31, 1, 31) : txt.Data = "RP POIN PENGAJUAN" : .Cols(31).TextAlign = TextAlignEnum.RightCenter : .Cols(31).AllowMerging = True : .Cols(31).Name = "RPPOINPENGAJUAN" : .Cols(31).Format = "#,###0"


            txt = .GetCellRange(0, 32, 0, 35) : txt.Data = "PENGAJUAN ADMIN " : .Cols(29).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 32, 1, 32) : txt.Data = "QTY PENGAJUAN " : .Cols(32).TextAlign = TextAlignEnum.RightCenter : .Cols(32).AllowMerging = True : .Cols(32).Name = "QTYPENGAJUANAPPROVED" : .Cols(32).Format = "#,###0"
            txt = .GetCellRange(1, 33, 1, 33) : txt.Data = "POIN PENGAJUAN" : .Cols(33).TextAlign = TextAlignEnum.RightCenter : .Cols(33).AllowMerging = True : .Cols(33).Name = "POINPENGAJUANAPPROVED" : .Cols(33).Format = "#,###0"
            txt = .GetCellRange(1, 34, 1, 34) : txt.Data = "RP POIN PENGAJUAN" : .Cols(34).TextAlign = TextAlignEnum.RightCenter : .Cols(34).AllowMerging = True : .Cols(34).Name = "RPPOINPENGAJUANAPPROVED" : .Cols(34).Format = "#,###0"
            txt = .GetCellRange(1, 35, 1, 35) : txt.Data = "STATUS" : .Cols(35).TextAlign = TextAlignEnum.CenterCenter : .Cols(35).AllowMerging = True : .Cols(35).Name = "STATUS" : .Cols(35).Visible = False


            txt = .GetCellRange(0, 36, 0, 38) : txt.Data = "COMPLETE (SUDAH TRF)" : .Cols(36).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 36, 1, 36) : txt.Data = "SISA QTY  " : .Cols(36).TextAlign = TextAlignEnum.RightCenter : .Cols(36).AllowMerging = True : .Cols(36).Name = "QTYPENGAJUANCOMPLETE" : .Cols(36).Format = "#,###0"
            txt = .GetCellRange(1, 37, 1, 37) : txt.Data = "SISA POIN " : .Cols(37).TextAlign = TextAlignEnum.RightCenter : .Cols(37).AllowMerging = True : .Cols(37).Name = "POINPENGAJUANCOMPLETE" : .Cols(37).Format = "#,###0"
            txt = .GetCellRange(1, 38, 1, 38) : txt.Data = "SISA RP POIN" : .Cols(38).TextAlign = TextAlignEnum.RightCenter : .Cols(38).AllowMerging = True : .Cols(38).Name = "RPPOINPENGAJUANCOMPLETE" : .Cols(38).Format = "#,###0"


            'txt = .GetCellRange(0, 36, 0, 38) : txt.Data = "SISA POIN PENGAJUAN (BELUM APPROVE)" : .Cols(36).TextAlignFixed = TextAlignEnum.CenterCenter
            'txt = .GetCellRange(1, 36, 1, 36) : txt.Data = "SISA QTY  " : .Cols(36).TextAlign = TextAlignEnum.RightCenter : .Cols(36).AllowMerging = True : .Cols(36).Name = "SISAQTYPENGAJUANTOKO" : .Cols(36).Format = "#,###0" : .Cols(36).Visible = False
            'txt = .GetCellRange(1, 37, 1, 37) : txt.Data = "SISA POIN " : .Cols(37).TextAlign = TextAlignEnum.RightCenter : .Cols(37).AllowMerging = True : .Cols(37).Name = "SISAPOINPENGAJUANTOKO" : .Cols(37).Format = "#,###0" : .Cols(37).Visible = False
            'txt = .GetCellRange(1, 38, 1, 38) : txt.Data = "SISA RP POIN" : .Cols(38).TextAlign = TextAlignEnum.RightCenter : .Cols(38).AllowMerging = True : .Cols(38).Name = "SISARPPOINPENGAJUANTOKO" : .Cols(38).Format = "#,###0" : .Cols(38).Visible = False



            txt = .GetCellRange(0, 39, 0, 42) : txt.Data = "SISA POIN BELUM DIBAYARKAN" : .Cols(39).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 40, 1, 40) : txt.Data = "SISA QTY " : .Cols(40).TextAlign = TextAlignEnum.RightCenter : .Cols(40).AllowMerging = True : .Cols(40).Name = "SISAQTYTOKO" : .Cols(40).Format = "#,###0"
            txt = .GetCellRange(1, 41, 1, 41) : txt.Data = "SISA POIN " : .Cols(41).TextAlign = TextAlignEnum.RightCenter : .Cols(41).AllowMerging = True : .Cols(41).Name = "SISAPOINTOKO" : .Cols(41).Format = "#,###0"
            txt = .GetCellRange(1, 42, 1, 42) : txt.Data = "SISA RP POIN" : .Cols(42).TextAlign = TextAlignEnum.RightCenter : .Cols(42).AllowMerging = True : .Cols(42).Name = "SISARPPOINTOKO" : .Cols(42).Format = "#,###0"


            txt = .GetCellRange(0, 43, 1, 43) : txt.Data = "NoRekToko" : .Cols(43).TextAlign = TextAlignEnum.LeftCenter : .Cols(43).AllowMerging = True : .Cols(43).Name = "NoRekToko"
            txt = .GetCellRange(0, 44, 1, 44) : txt.Data = "NamaRekToko" : .Cols(44).TextAlign = TextAlignEnum.LeftCenter : .Cols(44).AllowMerging = True : .Cols(44).Name = "NamaRekToko"
            txt = .GetCellRange(0, 45, 1, 45) : txt.Data = "Bank" : .Cols(45).TextAlign = TextAlignEnum.LeftCenter : .Cols(45).AllowMerging = True : .Cols(45).Name = "Bank"
            txt = .GetCellRange(0, 46, 1, 46) : txt.Data = "Tgl. Transfer" : .Cols(46).TextAlign = TextAlignEnum.LeftCenter : .Cols(46).AllowMerging = True : .Cols(46).Name = "TglTransfer"


            .AutoSizeCols()
        End With
    End Sub

    Private Sub chkTgl_CheckedChanged(sender As Object, e As EventArgs) Handles chkTgl.CheckedChanged
        If chkTgl.Checked = True Then
            dtp1.Enabled = True
            dtp2.Enabled = True
        Else
            dtp1.Value = Format(Now, "dd/MM/yyyy")
            dtp2.Value = Format(Now, "dd/MM/yyyy")
            dtp1.Enabled = False
            dtp2.Enabled = False
        End If
    End Sub

    Private Sub chkToko_CheckedChanged(sender As Object, e As EventArgs) Handles chkToko.CheckedChanged
        If chkToko.Checked = True Then
            cboToko.Enabled = True
        Else
            cboToko.Enabled = False
            cboToko.Text = ""
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        ShowData()
        Dim A As Integer
        A = 0
        For I = 3 To fg.Rows.Count - 1


            If fg.Item(I, "NAMATOKO") <> "" Then

                fg.Item(I, "NO") = A + 1
                A = A + 1
            End If
        Next I

    End Sub

    Public Sub ShowTotal()
        With fg
            .Tree.Column = 0
            .Tree.Style = TreeStyleFlags.SimpleLeaf
            .Subtotal(AggregateEnum.Clear)
            For I = 24 To 42

                .Subtotal(AggregateEnum.Sum, -1, -1, I, "Grand Total")
                .Subtotal(AggregateEnum.Sum, 3, 3, I, "Total {0}")
            Next I

            '.Subtotal(AggregateEnum.Sum, -1, -1, 23, "Grand Total")
            '.Subtotal(AggregateEnum.Sum, 2, 2, 23, "Total")

            '.Subtotal(AggregateEnum.Sum, -1, -1, 24, "Grand Total")
            '.Subtotal(AggregateEnum.Sum, 2, 2, 24, "Total")

            '.Subtotal(AggregateEnum.Sum, -1, -1, 25, "Grand Total")
            '.Subtotal(AggregateEnum.Sum, 2, 2, 25, "Total")

            '.Subtotal(AggregateEnum.Sum, -1, -1, 32, "Grand Total")
            '.Subtotal(AggregateEnum.Sum, 2, 2, 32, "Total")

            '.Subtotal(AggregateEnum.Sum, -1, -1, 33, "Grand Total")
            '.Subtotal(AggregateEnum.Sum, 2, 2, 33, "Total")

            '.Subtotal(AggregateEnum.Sum, -1, -1, 34, "Grand Total")
            '.Subtotal(AggregateEnum.Sum, 2, 2, 34, "Total")

            '.Subtotal(AggregateEnum.Sum, -1, -1, 36, "Grand Total")
            '.Subtotal(AggregateEnum.Sum, 2, 2, 36, "Total")

            '.Subtotal(AggregateEnum.Sum, -1, -1, 37, "Grand Total")
            '.Subtotal(AggregateEnum.Sum, 2, 2, 37, "Total")

            '.Subtotal(AggregateEnum.Sum, -1, -1, 38, "Grand Total")
            '.Subtotal(AggregateEnum.Sum, 2, 2, 38, "Total")
        End With
        Call ColorSubTotal()
    End Sub

    Private Sub ColorSubTotal()
        Dim cs As C1.Win.C1FlexGrid.CellStyle
        With fg
            cs = .Styles(C1.Win.C1FlexGrid.CellStyleEnum.GrandTotal)
            cs.BackColor = Color.SteelBlue
        End With
    End Sub

    Public Sub ShowData()
        Dim i As Integer = 2
        Dim sql As String = ""

        If chkTgl.Checked = True Then
            sql = Modul_RMP.Func.SetCondition(sql, " CONVERT(DATETIME,CONVERT(VARCHAR, Tanggal_Pengajuan,103),103) BETWEEN CONVERT (DATETIME,'" & dtp1.Value & "',103) AND CONVERT(DATETIME,'" & dtp2.Value & "',103)")
        End If

        If chktukarpoin.Checked = True Then
            sql = Modul_RMP.Func.SetCondition(sql, " CONVERT(DATETIME,CONVERT(VARCHAR, TanggalTransaksiKlaim,103),103) BETWEEN CONVERT (DATETIME,'" & Dt1.Value & "',103) AND CONVERT(DATETIME,'" & Dt2.Value & "',103)")
        End If


        If chkS_Petani.Checked = True Then
            sql = Modul_RMP.Func.SetCondition(sql, " KODESUP ='" & cmbS_Petani.SelectedValue.ToString & "' ")
        End If


        If chkToko.Checked = True Then
            If cboToko.Text = "" Then
                MsgBox("Silahkan Pilih Toko !", MsgBoxStyle.Exclamation, AT)
                Exit Sub
            Else
                sql = Modul_RMP.Func.SetCondition(sql, " TOKO_ID = '" & cboToko.SelectedValue.ToString & "'")
            End If
        End If

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " SELECT * FROM vwtukarpoin2 " &
                                                          " WHERE 1=1   " & IIf(sql = "", "", " AND " & sql) & " ORDER BY TOKO_ID asc")

        If dt.Rows.Count > 0 Then
            With fg
                fg.Rows.Count=2
                For Each dr As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "ID") = ""
                    .Item(i, "NO") = ""
                    .Item(i, 2) = dr!TOKO_ID
                    .Item(i, "NAMATOKO") = dr!Nama_Toko
                    .Item(i, "ALAMATTOKO") = dr!Alamat_Toko
                    .Item(i, "KODESUPPLIER") = dr!KodeSup
                    .Item(i, "NAMASUPPLIER") = dr!NamaSup
                    .Item(i, "ALAMATSUPPLIER") = dr!Alamat
                    .Item(i, "JENISTRANSAKSI") = dr!Jenis_Transaksi
                    .Item(i, "KODEPENGAJUAN") = dr!Kode_Pengajuan
                    .Item(i, "TGLPENGAJUAN") = dr!Tanggal_Pengajuan
                    .Item(i, "NOTRANSPENGAJUAN") = dr!NoTransPengajuan
                    .Item(i, "PENGAJUANBY") = dr!CreatedByPengajuan
                    .Item(i, "PENGAJUANCREATEDDATE") = dr!CreatedDatePengajuan
                    .Item(i, "TGLTRANSAKSIKLAIM") = dr!TanggalTransaksiKlaim
                    .Item(i, "ITEMID") = dr!Item_ID
                    .Item(i, "KODEITEM") = dr!Kode_Item
                    .Item(i, "NAMAITEM") = dr!Nama_Item
                    .Item(i, "JENISITEM") = dr!Jenis_Item
                    .Item(i, "FOTO") = dr!Foto_Transaksi
                    .Item(i, "SATUAN") = dr!Satuan

                    .Item(i, "QTY") = dr!Qty
                    .Item(i, "POIN") = dr!Poin
                    .Item(i, "RUPIAH") = dr!Rupiah
                    .Item(i, "BAYARPOIN") = dr!Bayar_Poin
                    .Item(i, "BAYARRUPIAH") = dr!Bayar_Rupiah
                    .Item(i, "STATUS") = dr!status_pengajuan



                    If IsDBNull(dr!Kode_Pengajuan) = True Then
                        .Rows(i).StyleNew.BackColor = Color.LavenderBlush
                        .Rows(i).StyleNew.ForeColor = Color.Black

                        .Item(i, "QTYTUKAR") = dr!Qty
                        .Item(i, "POINTUKAR") = dr!Bayar_Poin
                        .Item(i, "RPPOINTUKAR") = dr!Bayar_Rupiah
                        .Item(i, "QTYPENGAJUAN") = 0
                        .Item(i, "POINPENGAJUAN") = 0
                        .Item(i, "RPPOINPENGAJUAN") = 0
                        .Item(i, "QTYPENGAJUANAPPROVED") = 0
                        .Item(i, "POINPENGAJUANAPPROVED") = 0
                        .Item(i, "RPPOINPENGAJUANAPPROVED") = 0
                        .Item(i, "QTYTUKAR") = 0
                    End If

                    If IIf(IsDBNull(.Item(i, "STATUS")), 0, dr!status_pengajuan) = 0 And IsDBNull(dr!Kode_Pengajuan) = False Then
                        .Rows(i).StyleNew.BackColor = Color.Ivory
                        .Rows(i).StyleNew.ForeColor = Color.Black
                        .Item(i, "QTYTUKAR") = 0
                        .Item(i, "POINTUKAR") = 0
                        .Item(i, "RPPOINTUKAR") = 0
                        .Item(i, "QTYPENGAJUANAPPROVED") = 0
                        .Item(i, "POINPENGAJUANAPPROVED") = 0
                        .Item(i, "RPPOINPENGAJUANAPPROVED") = 0
                        .Item(i, "QTYPENGAJUAN") = dr!Qty
                        .Item(i, "POINPENGAJUAN") = dr!Bayar_Poin
                        .Item(i, "RPPOINPENGAJUAN") = dr!Bayar_Rupiah
                    End If



                    If IIf(IsDBNull(.Item(i, "STATUS")), 0, dr!status_pengajuan) = 1 Then
                        .Rows(i).StyleNew.BackColor = Color.FromArgb(232, 249, 232)
                        .Rows(i).StyleNew.ForeColor = Color.Black
                        .Item(i, "QTYPENGAJUANAPPROVED") = dr!Qty
                        .Item(i, "POINPENGAJUANAPPROVED") = dr!Bayar_Poin
                        .Item(i, "RPPOINPENGAJUANAPPROVED") = dr!Bayar_Rupiah
                        .Item(i, "QTYTUKAR") = 0
                        .Item(i, "POINTUKAR") = 0
                        .Item(i, "RPPOINTUKAR") = 0
                        .Item(i, "QTYPENGAJUAN") = 0
                        .Item(i, "POINPENGAJUAN") = 0
                        .Item(i, "RPPOINPENGAJUAN") = 0
                    End If

                    If IIf(IsDBNull(.Item(i, "STATUS")), 0, dr!status_pengajuan) = 2 Then
                        .Rows(i).StyleNew.BackColor = Color.White
                        .Rows(i).StyleNew.ForeColor = Color.Black
                        .Item(i, "QTYPENGAJUANCOMPLETE") = dr!Qty
                        .Item(i, "POINPENGAJUANCOMPLETE") = dr!Bayar_Poin
                        .Item(i, "RPPOINPENGAJUANCOMPLETE") = dr!Bayar_Rupiah
                        .Item(i, "QTYTUKAR") = 0
                        .Item(i, "POINTUKAR") = 0
                        .Item(i, "RPPOINTUKAR") = 0
                        .Item(i, "QTYPENGAJUAN") = 0
                        .Item(i, "POINPENGAJUAN") = 0
                        .Item(i, "RPPOINPENGAJUAN") = 0
                        .Item(i, "QTYPENGAJUANAPPROVED") = 0
                        .Item(i, "POINPENGAJUANAPPROVED") = 0
                        .Item(i, "RPPOINPENGAJUANAPPROVED") = 0

                    End If
                    '.Item(i, "SISAQTYPENGAJUANTOKO") = .Item(i, "QTYPENGAJUAN") - .Item(i, "QTYPENGAJUANAPPROVED")
                    '.Item(i, "SISAPOINPENGAJUANTOKO") = .Item(i, "POINPENGAJUAN") - .Item(i, "POINPENGAJUANAPPROVED")
                    '.Item(i, "SISARPPOINPENGAJUANTOKO") = .Item(i, "RPPOINPENGAJUAN") - .Item(i, "RPPOINPENGAJUANAPPROVED")


                    .Item(i, "SISAQTYTOKO") = .Item(i, "QTY") - .Item(i, "QTYPENGAJUANCOMPLETE")
                    .Item(i, "SISAPOINTOKO") = .Item(i, "BAYARPOIN") - .Item(i, "POINPENGAJUANCOMPLETE")
                    .Item(i, "SISARPPOINTOKO") = .Item(i, "BAYARRUPIAH") - .Item(i, "RPPOINPENGAJUANCOMPLETE")


                    .Item(i, "NoRekToko") = dr!NoRekToko
                    .Item(i, "NamaRekToko") = dr!NamaRekToko
                    .Item(i, "Bank") = dr!Bank
                    .Item(i, "TglTransfer") = dr!TglTransfer

                    i = i + 1
                Next
                ShowTotal()
                .AutoSizeCols()
            End With
        Else
            fg.Rows.Count=2
            MsgBox("No Data !", MsgBoxStyle.Exclamation, AT)
        End If
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Dim filename As String
        Me.SaveFileDialog.ShowDialog()
        filename = SaveFileDialog.FileName
        Me.fg.SaveExcel(filename & ".xls", "Sheet1", FileFlags.IncludeFixedCells)
        MsgBox("File Excel Berhasil Disimpan !", MsgBoxStyle.Information, AT)
    End Sub

    Private Sub fg_AfterSelChange(sender As Object, e As RangeEventArgs) Handles fg.AfterSelChange
        Dim sum As Double
        Dim R, c As Integer
        With fg
            If .Row = 0 Then Exit Sub
            If .RowSel > .Row Then
                For R = .Row To .RowSel
                    If (R > 0) And (R <= (.Rows.Count - 1)) Then
                        For c = .Col To .ColSel
                            Select Case c
                                Case 22, 23, 24, 25, 32, 33, 34, 36, 37, 38
                                    If Trim(.Item(R, c) <> 0) Then
                                        sum = sum + CDbl(.Item(R, c))
                                    End If
                            End Select
                        Next
                    End If
                Next
            End If
        End With
        txtSum.Text = FormatNumber(sum, 0)
    End Sub

    Private Sub fg_DoubleClick(sender As Object, e As EventArgs) Handles fg.DoubleClick

        If fg.Col <> 19 Then Exit Sub

        Dim namaFoto As String = TryCast(fg.Item(fg.Row, "FOTO"), String)

        If String.IsNullOrEmpty(namaFoto) Then
            MsgBox("Foto tidak tersedia!", vbExclamation, AT)
            Exit Sub
        End If

        Dim url As String = UrlApiNotaPancang &
        "ImagesPoinTransaksi&filename=" & namaFoto &
        ".jpg&flag=notapancang"

        Try
            Using client As New Net.WebClient
                client.Headers.Add("User-Agent", "VB App")

                Using stream As IO.Stream = client.OpenRead(url)
                    Using img As Image = Image.FromStream(stream)
                        Using frm As New FrmFotoView
                            frm.TampilkanImage(img)
                            frm.ShowDialog()
                        End Using
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MsgBox("Gagal membuka foto: " & ex.Message, vbExclamation, AT)
        End Try

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub cmbS_Petani_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbS_Petani.SelectedIndexChanged

    End Sub

    Private Sub cmbS_Petani_Validating(sender As Object, e As CancelEventArgs) Handles cmbS_Petani.Validating
        If cmbS_Petani.Text = "" Then
            Exit Sub
        End If

        If IsNothing(cmbS_Petani.SelectedValue) Then
            MsgBox("Pilihan tidak ada !", vbExclamation, AT)
            cmbS_Petani.Text = ""
            cmbS_Petani.Focus()
        End If
    End Sub

    Private Sub cmbS_Petani_Validated(sender As Object, e As EventArgs) Handles cmbS_Petani.Validated
        chkS_Petani.Checked = IIf(cmbS_Petani.Text = "", False, True)
    End Sub

    Private Sub cmbS_Petani_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbS_Petani.KeyUp
        UI.AutoCompleteCombo_KeyUp(cmbS_Petani, e)
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click

    End Sub
End Class