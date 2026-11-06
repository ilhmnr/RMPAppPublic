Imports System.ComponentModel
Imports C1.Win.C1FlexGrid
Imports Syncfusion.Pdf.Graphics

Public Class FrmMonPengajuanPoinNew
    Dim dt As DataTable = New DataTable()
    Dim Teks As String
    Dim Bergerak As Integer

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub FrmMonPengajuanPoinnEW_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Clear()
        SearchFG()
        HeaderFG2()
        HeaderFG()
        Modul_RMP.Combo.SettokoPancang(cboToko)
        Teks = lblInfo.Text
        Timer.Start()
        'schKg()
        Modul_RMP.Combo.SetSupplier(cmbS_Petani)
        Modul_RMP.Combo.SetPancang(cbopancang)
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
        C1FlexGrid1.Rows.Count = 2
        chkTgl.Checked = False
        chkToko.Checked = False
    End Sub

    Public Sub HeaderFG()
        Dim txt As CellRange
        With fg
            .Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Regular)
            .Cols.Count = 49
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
            .Cols.Frozen = 10


            'CELL2()

            txt = .GetCellRange(0, 0, 1, 0) : txt.Data = "NO" : .Cols(0).Width = 50 : .Cols(0).AllowMerging = True : .Cols(0).Name = "NO"
            txt = .GetCellRange(0, 1, 1, 1) : txt.Data = "ID" : .Cols(1).TextAlign = TextAlignEnum.CenterCenter : .Cols(1).AllowMerging = True : .Cols(1).Name = "ID" : .Cols(1).Visible = False
            txt = .GetCellRange(0, 2, 1, 2) : txt.Data = "ID TOKO" : .Cols(2).TextAlign = TextAlignEnum.CenterCenter : .Cols(2).AllowMerging = True : .Cols(2).Name = "IDTOKO" : .Cols(2).Visible = False
            txt = .GetCellRange(0, 3, 1, 3) : txt.Data = "NAMA TOKO" : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).AllowMerging = True : .Cols(3).Name = "NAMATOKO" : .Cols(3).Visible = False

            txt = .GetCellRange(0, 4, 1, 4) : txt.Data = "TANGGAL PENGAMBILAN" : .Cols(4).TextAlign = TextAlignEnum.CenterCenter : .Cols(4).AllowMerging = True : .Cols(4).Name = "TANGGALPENGAMBILAN"
            txt = .GetCellRange(0, 5, 1, 5) : txt.Data = "NOTRANS PENGAJUAN" : .Cols(5).TextAlign = TextAlignEnum.CenterCenter : .Cols(5).AllowMerging = True : .Cols(5).Name = "NOTRANSPENGAJUAN"
            txt = .GetCellRange(0, 6, 1, 6) : txt.Data = "TRANS DATE" : .Cols(6).TextAlign = TextAlignEnum.CenterCenter : .Cols(6).AllowMerging = True : .Cols(6).Name = "TGLPENGAJUAN"
            txt = .GetCellRange(0, 7, 1, 7) : txt.Data = "NAMA TOKO" : .Cols(7).TextAlign = TextAlignEnum.LeftCenter : .Cols(7).AllowMerging = True : .Cols(7).Name = "NAMATOKO2"

            txt = .GetCellRange(0, 8, 1, 8) : txt.Data = "ALAMAT TOKO" : .Cols(8).TextAlign = TextAlignEnum.LeftCenter : .Cols(8).AllowMerging = True : .Cols(8).Name = "ALAMATTOKO"
            txt = .GetCellRange(0, 9, 1, 9) : txt.Data = "ID PETANI" : .Cols(9).TextAlign = TextAlignEnum.CenterCenter : .Cols(9).AllowMerging = True : .Cols(9).Name = "KODESUPPLIER"
            txt = .GetCellRange(0, 10, 1, 10) : txt.Data = "NAMAPETANI" : .Cols(10).TextAlign = TextAlignEnum.LeftCenter : .Cols(10).AllowMerging = True : .Cols(10).Name = "NAMASUPPLIER"

            txt = .GetCellRange(0, 11, 1, 11) : txt.Data = "ALAMAT PETANI" : .Cols(11).TextAlign = TextAlignEnum.LeftCenter : .Cols(11).AllowMerging = True : .Cols(11).Name = "ALAMATSUPPLIER"

            txt = .GetCellRange(0, 12, 1, 12) : txt.Data = "PANCANG" : .Cols(12).TextAlign = TextAlignEnum.LeftCenter : .Cols(12).AllowMerging = True : .Cols(12).Name = "PANCANG"


            txt = .GetCellRange(0, 13, 1, 13) : txt.Data = "JENIS TRANSAKSI" : .Cols(13).TextAlign = TextAlignEnum.CenterCenter : .Cols(13).AllowMerging = True : .Cols(13).Name = "JENISTRANSAKSI" : .Cols(13).Visible = False
            txt = .GetCellRange(0, 14, 1, 14) : txt.Data = "KODE PENGAJUAN" : .Cols(14).TextAlign = TextAlignEnum.CenterCenter : .Cols(14).AllowMerging = True : .Cols(14).Name = "KODEPENGAJUAN" : .Cols(14).Visible = False



            txt = .GetCellRange(0, 15, 1, 15) : txt.Data = "JENIS ITEM" : .Cols(15).TextAlign = TextAlignEnum.LeftCenter : .Cols(15).AllowMerging = True : .Cols(15).Name = "JENISITEM"
            txt = .GetCellRange(0, 16, 1, 16) : txt.Data = "KODE ITEM" : .Cols(16).TextAlign = TextAlignEnum.CenterCenter : .Cols(16).AllowMerging = True : .Cols(16).Name = "KODEITEM" : .Cols(16).Visible = False
            txt = .GetCellRange(0, 17, 1, 17) : txt.Data = "NAMA ITEM" : .Cols(17).TextAlign = TextAlignEnum.LeftCenter : .Cols(17).AllowMerging = True : .Cols(17).Name = "NAMAITEM"

            txt = .GetCellRange(0, 18, 1, 18) : txt.Data = "FOTO" : .Cols(18).Name = "btnFoto" : .Cols(18).TextAlign = TextAlignEnum.CenterCenter : .Cols(18).AllowMerging = True : .Cols(18).ImageAlign = ImageAlignEnum.CenterCenter
            txt = .GetCellRange(0, 19, 1, 19) : txt.Data = "SATUAN/ITEM" : .Cols(19).TextAlign = TextAlignEnum.CenterCenter : .Cols(19).AllowMerging = True : .Cols(19).Name = "SATUAN"
            txt = .GetCellRange(0, 20, 1, 20) : txt.Data = "QTY/ITEM" : .Cols(20).TextAlign = TextAlignEnum.CenterCenter : .Cols(20).AllowMerging = True : .Cols(20).Name = "QTY"
            txt = .GetCellRange(0, 21, 1, 21) : txt.Data = "POIN /ITEM" : .Cols(21).TextAlign = TextAlignEnum.RightCenter : .Cols(21).Format = "#,###0" : .Cols(21).AllowMerging = True : .Cols(21).Name = "POIN"
            txt = .GetCellRange(0, 22, 1, 22) : txt.Data = "TOTAL POIN" : .Cols(22).TextAlign = TextAlignEnum.RightCenter : .Cols(22).Format = "#,###0" : .Cols(22).AllowMerging = True : .Cols(22).Name = "BAYARPOIN"

            txt = .GetCellRange(0, 23, 1, 23) : txt.Data = "RP/POIN" : .Cols(23).TextAlign = TextAlignEnum.RightCenter : .Cols(23).Format = "#,###0" : .Cols(23).AllowMerging = True : .Cols(23).Name = "Harga"
            txt = .GetCellRange(0, 24, 1, 24) : txt.Data = "TOTAL RUPIAH" : .Cols(24).TextAlign = TextAlignEnum.RightCenter : .Cols(24).Format = "#,###0" : .Cols(24).AllowMerging = True : .Cols(24).Name = "BAYARRUPIAH"


            txt = .GetCellRange(0, 25, 0, 27) : txt.Data = "PENUKARAN PETANI" : .Cols(25).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 25, 1, 25) : txt.Data = "QTY" : .Cols(25).TextAlign = TextAlignEnum.RightCenter : .Cols(25).AllowMerging = True : .Cols(25).Name = "QTYTUKAR" : .Cols(25).Format = "#,###0"
            txt = .GetCellRange(1, 26, 1, 26) : txt.Data = "JUMLAH POIN" : .Cols(26).TextAlign = TextAlignEnum.RightCenter : .Cols(26).AllowMerging = True : .Cols(26).Name = "POINTUKAR" : .Cols(26).Format = "#,###0"
            txt = .GetCellRange(1, 27, 1, 27) : txt.Data = "RP" : .Cols(27).TextAlign = TextAlignEnum.RightCenter : .Cols(27).AllowMerging = True : .Cols(27).Name = "RPPOINTUKAR" : .Cols(27).Format = "#,###0"

            txt = .GetCellRange(0, 28, 0, 30) : txt.Data = "PENGAJUAN TOKO" : .Cols(28).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 28, 1, 28) : txt.Data = "QTY" : .Cols(28).TextAlign = TextAlignEnum.RightCenter : .Cols(28).AllowMerging = True : .Cols(28).Name = "QTYPENGAJUAN" : .Cols(28).Format = "#,###0"
            txt = .GetCellRange(1, 29, 1, 29) : txt.Data = "JUMLAH POIN" : .Cols(29).TextAlign = TextAlignEnum.RightCenter : .Cols(29).AllowMerging = True : .Cols(29).Name = "POINPENGAJUAN" : .Cols(29).Format = "#,###0"
            txt = .GetCellRange(1, 30, 1, 30) : txt.Data = "RP" : .Cols(30).TextAlign = TextAlignEnum.RightCenter : .Cols(30).AllowMerging = True : .Cols(30).Name = "RPPOINPENGAJUAN" : .Cols(30).Format = "#,###0"


            txt = .GetCellRange(0, 31, 0, 34) : txt.Data = "PENGAJUAN ADMIN " : .Cols(31).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 31, 1, 31) : txt.Data = "QTY" : .Cols(31).TextAlign = TextAlignEnum.RightCenter : .Cols(31).AllowMerging = True : .Cols(31).Name = "QTYPENGAJUANAPPROVED" : .Cols(31).Format = "#,###0"
            txt = .GetCellRange(1, 32, 1, 32) : txt.Data = "JUMLAH POIN" : .Cols(32).TextAlign = TextAlignEnum.RightCenter : .Cols(32).AllowMerging = True : .Cols(32).Name = "POINPENGAJUANAPPROVED" : .Cols(32).Format = "#,###0"
            txt = .GetCellRange(1, 33, 1, 33) : txt.Data = "RP" : .Cols(33).TextAlign = TextAlignEnum.RightCenter : .Cols(33).AllowMerging = True : .Cols(33).Name = "RPPOINPENGAJUANAPPROVED" : .Cols(33).Format = "#,###0"
            txt = .GetCellRange(1, 34, 1, 34) : txt.Data = "STATUS" : .Cols(34).TextAlign = TextAlignEnum.CenterCenter : .Cols(34).AllowMerging = True : .Cols(34).Name = "STATUS" : .Cols(34).Visible = False


            txt = .GetCellRange(0, 35, 0, 37) : txt.Data = "COMPLETE (SUDAH TRF)" : .Cols(35).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 35, 1, 35) : txt.Data = "QTY" : .Cols(35).TextAlign = TextAlignEnum.RightCenter : .Cols(35).AllowMerging = True : .Cols(35).Name = "QTYPENGAJUANCOMPLETE" : .Cols(35).Format = "#,###0"
            txt = .GetCellRange(1, 36, 1, 36) : txt.Data = "JUMLAH POIN" : .Cols(36).TextAlign = TextAlignEnum.RightCenter : .Cols(36).AllowMerging = True : .Cols(36).Name = "POINPENGAJUANCOMPLETE" : .Cols(36).Format = "#,###0"
            txt = .GetCellRange(1, 37, 1, 37) : txt.Data = "RP" : .Cols(37).TextAlign = TextAlignEnum.RightCenter : .Cols(37).AllowMerging = True : .Cols(37).Name = "RPPOINPENGAJUANCOMPLETE" : .Cols(37).Format = "#,###0"



            txt = .GetCellRange(0, 38, 0, 40) : txt.Data = "SISA POIN" : .Cols(38).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 38, 1, 38) : txt.Data = "QTY " : .Cols(38).TextAlign = TextAlignEnum.RightCenter : .Cols(38).AllowMerging = True : .Cols(38).Name = "SISAQTYTOKO" : .Cols(38).Format = "#,###0"
            txt = .GetCellRange(1, 39, 1, 39) : txt.Data = "JUMLAH POIN" : .Cols(39).TextAlign = TextAlignEnum.RightCenter : .Cols(39).AllowMerging = True : .Cols(39).Name = "SISAPOINTOKO" : .Cols(39).Format = "#,###0"
            txt = .GetCellRange(1, 40, 1, 40) : txt.Data = "RP" : .Cols(40).TextAlign = TextAlignEnum.RightCenter : .Cols(40).AllowMerging = True : .Cols(40).Name = "SISARPPOINTOKO" : .Cols(40).Format = "#,###0"


            txt = .GetCellRange(0, 41, 1, 41) : txt.Data = "NO. REK TOKO " : .Cols(41).TextAlign = TextAlignEnum.LeftCenter : .Cols(41).AllowMerging = True : .Cols(41).Name = "NoRekToko"
            txt = .GetCellRange(0, 42, 1, 42) : txt.Data = "NAMA REK TOKO " : .Cols(42).TextAlign = TextAlignEnum.LeftCenter : .Cols(42).AllowMerging = True : .Cols(42).Name = "NamaRekToko"
            txt = .GetCellRange(0, 43, 1, 43) : txt.Data = "BANK" : .Cols(43).TextAlign = TextAlignEnum.LeftCenter : .Cols(43).AllowMerging = True : .Cols(43).Name = "Bank"
            txt = .GetCellRange(0, 44, 1, 44) : txt.Data = "TANGGAL PENGAJUAN " : .Cols(44).TextAlign = TextAlignEnum.LeftCenter : .Cols(44).AllowMerging = True : .Cols(44).Name = "TglTransfer"
            txt = .GetCellRange(0, 45, 1, 45) : txt.Data = "PENGAJUAN BY " : .Cols(45).TextAlign = TextAlignEnum.LeftCenter : .Cols(45).AllowMerging = True : .Cols(45).Name = "PengajuanBy"
            txt = .GetCellRange(0, 46, 1, 46) : txt.Data = "FOTO" : .Cols(46).TextAlign = TextAlignEnum.CenterCenter : .Cols(46).AllowMerging = True : .Cols(46).Name = "FOTO" : .Cols(46).Visible = False

            txt = .GetCellRange(0, 47, 1, 47) : txt.Data = "BUKTITRF" : .Cols(47).TextAlign = TextAlignEnum.CenterCenter : .Cols(47).AllowMerging = True : .Cols(47).Name = "BUKTITRF" : .Cols(47).Visible = False

            txt = .GetCellRange(0, 48, 1, 48) : txt.Data = "BUKTITRF" : .Cols(48).TextAlign = TextAlignEnum.CenterCenter : .Cols(48).AllowMerging = True : .Cols(48).Name = "BUKTITRF2" : .Cols(48).ImageAlign = ImageAlignEnum.CenterCenter


            .AutoSizeCols()
        End With
    End Sub


    Public Sub HeaderFG2()
        Dim txt As CellRange
        With C1FlexGrid1
            .Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Regular)
            .Cols.Count = 49
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
            .Cols.Frozen = 10


            'CELL2()

            txt = .GetCellRange(0, 0, 1, 0) : txt.Data = "NO" : .Cols(0).Width = 50 : .Cols(0).AllowMerging = True : .Cols(0).Name = "NO"
            txt = .GetCellRange(0, 1, 1, 1) : txt.Data = "ID" : .Cols(1).TextAlign = TextAlignEnum.CenterCenter : .Cols(1).AllowMerging = True : .Cols(1).Name = "ID" : .Cols(1).Visible = False
            txt = .GetCellRange(0, 2, 1, 2) : txt.Data = "ID TOKO" : .Cols(2).TextAlign = TextAlignEnum.CenterCenter : .Cols(2).AllowMerging = True : .Cols(2).Name = "IDTOKO" : .Cols(2).Visible = False
            txt = .GetCellRange(0, 3, 1, 3) : txt.Data = "NAMA TOKO" : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).AllowMerging = True : .Cols(3).Name = "NAMATOKO" : .Cols(3).Visible = False

            txt = .GetCellRange(0, 4, 1, 4) : txt.Data = "TANGGAL PENGAMBILAN" : .Cols(4).TextAlign = TextAlignEnum.CenterCenter : .Cols(4).AllowMerging = True : .Cols(4).Name = "TANGGALPENGAMBILAN"
            txt = .GetCellRange(0, 5, 1, 5) : txt.Data = "NOTRANS PENGAJUAN" : .Cols(5).TextAlign = TextAlignEnum.CenterCenter : .Cols(5).AllowMerging = True : .Cols(5).Name = "NOTRANSPENGAJUAN"
            txt = .GetCellRange(0, 6, 1, 6) : txt.Data = "TRANS DATE" : .Cols(6).TextAlign = TextAlignEnum.CenterCenter : .Cols(6).AllowMerging = True : .Cols(6).Name = "TGLPENGAJUAN"
            txt = .GetCellRange(0, 7, 1, 7) : txt.Data = "NAMA TOKO" : .Cols(7).TextAlign = TextAlignEnum.LeftCenter : .Cols(7).AllowMerging = True : .Cols(7).Name = "NAMATOKO2"

            txt = .GetCellRange(0, 8, 1, 8) : txt.Data = "ALAMAT TOKO" : .Cols(8).TextAlign = TextAlignEnum.LeftCenter : .Cols(8).AllowMerging = True : .Cols(8).Name = "ALAMATTOKO"
            txt = .GetCellRange(0, 9, 1, 9) : txt.Data = "ID PETANI" : .Cols(9).TextAlign = TextAlignEnum.CenterCenter : .Cols(9).AllowMerging = True : .Cols(9).Name = "KODESUPPLIER"
            txt = .GetCellRange(0, 10, 1, 10) : txt.Data = "NAMAPETANI" : .Cols(10).TextAlign = TextAlignEnum.LeftCenter : .Cols(10).AllowMerging = True : .Cols(10).Name = "NAMASUPPLIER"

            txt = .GetCellRange(0, 11, 1, 11) : txt.Data = "ALAMAT PETANI" : .Cols(11).TextAlign = TextAlignEnum.LeftCenter : .Cols(11).AllowMerging = True : .Cols(11).Name = "ALAMATSUPPLIER"

            txt = .GetCellRange(0, 12, 1, 12) : txt.Data = "PANCANG" : .Cols(12).TextAlign = TextAlignEnum.LeftCenter : .Cols(12).AllowMerging = True : .Cols(12).Name = "pancang"


            txt = .GetCellRange(0, 13, 1, 13) : txt.Data = "JENIS TRANSAKSI" : .Cols(13).TextAlign = TextAlignEnum.CenterCenter : .Cols(13).AllowMerging = True : .Cols(13).Name = "JENISTRANSAKSI" : .Cols(13).Visible = False
            txt = .GetCellRange(0, 14, 1, 14) : txt.Data = "KODE PENGAJUAN" : .Cols(14).TextAlign = TextAlignEnum.CenterCenter : .Cols(14).AllowMerging = True : .Cols(14).Name = "KODEPENGAJUAN" : .Cols(14).Visible = False



            txt = .GetCellRange(0, 15, 1, 15) : txt.Data = "JENIS ITEM" : .Cols(15).TextAlign = TextAlignEnum.LeftCenter : .Cols(15).AllowMerging = True : .Cols(15).Name = "JENISITEM"
            txt = .GetCellRange(0, 16, 1, 16) : txt.Data = "KODE ITEM" : .Cols(16).TextAlign = TextAlignEnum.CenterCenter : .Cols(16).AllowMerging = True : .Cols(16).Name = "KODEITEM" : .Cols(15).Visible = False
            txt = .GetCellRange(0, 17, 1, 17) : txt.Data = "NAMA ITEM" : .Cols(17).TextAlign = TextAlignEnum.LeftCenter : .Cols(17).AllowMerging = True : .Cols(17).Name = "NAMAITEM"

            txt = .GetCellRange(0, 18, 1, 18) : txt.Data = "FOTO" : .Cols(18).TextAlign = TextAlignEnum.CenterCenter : .Cols(18).AllowMerging = True : .Cols(18).Name = "FOTO2" : .Cols(18).ImageAlign = ImageAlignEnum.CenterCenter
            txt = .GetCellRange(0, 19, 1, 19) : txt.Data = "SATUAN/ITEM" : .Cols(19).TextAlign = TextAlignEnum.CenterCenter : .Cols(19).AllowMerging = True : .Cols(19).Name = "SATUAN"
            txt = .GetCellRange(0, 20, 1, 20) : txt.Data = "QTY/ITEM" : .Cols(20).TextAlign = TextAlignEnum.CenterCenter : .Cols(20).AllowMerging = True : .Cols(20).Name = "QTY"
            txt = .GetCellRange(0, 21, 1, 21) : txt.Data = "POIN /ITEM" : .Cols(21).TextAlign = TextAlignEnum.RightCenter : .Cols(21).Format = "#,###0" : .Cols(21).AllowMerging = True : .Cols(21).Name = "POIN"
            txt = .GetCellRange(0, 22, 1, 22) : txt.Data = "TOTAL POIN" : .Cols(22).TextAlign = TextAlignEnum.RightCenter : .Cols(22).Format = "#,###0" : .Cols(22).AllowMerging = True : .Cols(22).Name = "BAYARPOIN"

            txt = .GetCellRange(0, 23, 1, 23) : txt.Data = "RP/POIN" : .Cols(23).TextAlign = TextAlignEnum.RightCenter : .Cols(23).Format = "#,###0" : .Cols(23).AllowMerging = True : .Cols(23).Name = "Harga"
            txt = .GetCellRange(0, 24, 1, 24) : txt.Data = "TOTAL RUPIAH" : .Cols(24).TextAlign = TextAlignEnum.RightCenter : .Cols(24).Format = "#,###0" : .Cols(24).AllowMerging = True : .Cols(24).Name = "BAYARRUPIAH"


            txt = .GetCellRange(0, 25, 0, 27) : txt.Data = "PENUKARAN PETANI" : .Cols(25).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 25, 1, 25) : txt.Data = "QTY" : .Cols(25).TextAlign = TextAlignEnum.RightCenter : .Cols(25).AllowMerging = True : .Cols(25).Name = "QTYTUKAR" : .Cols(25).Format = "#,###0"
            txt = .GetCellRange(1, 26, 1, 26) : txt.Data = "JUMLAH POIN" : .Cols(26).TextAlign = TextAlignEnum.RightCenter : .Cols(26).AllowMerging = True : .Cols(26).Name = "POINTUKAR" : .Cols(26).Format = "#,###0"
            txt = .GetCellRange(1, 27, 1, 27) : txt.Data = "RP" : .Cols(27).TextAlign = TextAlignEnum.RightCenter : .Cols(27).AllowMerging = True : .Cols(27).Name = "RPPOINTUKAR" : .Cols(27).Format = "#,###0"

            txt = .GetCellRange(0, 28, 0, 30) : txt.Data = "PENGAJUAN TOKO" : .Cols(28).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 28, 1, 28) : txt.Data = "QTY" : .Cols(28).TextAlign = TextAlignEnum.RightCenter : .Cols(28).AllowMerging = True : .Cols(28).Name = "QTYPENGAJUAN" : .Cols(28).Format = "#,###0"
            txt = .GetCellRange(1, 29, 1, 29) : txt.Data = "JUMLAH POIN" : .Cols(29).TextAlign = TextAlignEnum.RightCenter : .Cols(29).AllowMerging = True : .Cols(29).Name = "POINPENGAJUAN" : .Cols(29).Format = "#,###0"
            txt = .GetCellRange(1, 30, 1, 30) : txt.Data = "RP" : .Cols(30).TextAlign = TextAlignEnum.RightCenter : .Cols(30).AllowMerging = True : .Cols(30).Name = "RPPOINPENGAJUAN" : .Cols(30).Format = "#,###0"


            txt = .GetCellRange(0, 31, 0, 34) : txt.Data = "PENGAJUAN ADMIN " : .Cols(31).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 31, 1, 31) : txt.Data = "QTY" : .Cols(31).TextAlign = TextAlignEnum.RightCenter : .Cols(31).AllowMerging = True : .Cols(31).Name = "QTYPENGAJUANAPPROVED" : .Cols(31).Format = "#,###0"
            txt = .GetCellRange(1, 32, 1, 32) : txt.Data = "JUMLAH POIN" : .Cols(32).TextAlign = TextAlignEnum.RightCenter : .Cols(32).AllowMerging = True : .Cols(32).Name = "POINPENGAJUANAPPROVED" : .Cols(32).Format = "#,###0"
            txt = .GetCellRange(1, 33, 1, 33) : txt.Data = "RP" : .Cols(33).TextAlign = TextAlignEnum.RightCenter : .Cols(33).AllowMerging = True : .Cols(33).Name = "RPPOINPENGAJUANAPPROVED" : .Cols(33).Format = "#,###0"
            txt = .GetCellRange(1, 34, 1, 34) : txt.Data = "STATUS" : .Cols(34).TextAlign = TextAlignEnum.CenterCenter : .Cols(34).AllowMerging = True : .Cols(34).Name = "STATUS" : .Cols(34).Visible = False


            txt = .GetCellRange(0, 35, 0, 37) : txt.Data = "COMPLETE (SUDAH TRF)" : .Cols(35).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 35, 1, 35) : txt.Data = "QTY" : .Cols(35).TextAlign = TextAlignEnum.RightCenter : .Cols(35).AllowMerging = True : .Cols(35).Name = "QTYPENGAJUANCOMPLETE" : .Cols(35).Format = "#,###0"
            txt = .GetCellRange(1, 36, 1, 36) : txt.Data = "JUMLAH POIN" : .Cols(36).TextAlign = TextAlignEnum.RightCenter : .Cols(36).AllowMerging = True : .Cols(36).Name = "POINPENGAJUANCOMPLETE" : .Cols(36).Format = "#,###0"
            txt = .GetCellRange(1, 37, 1, 37) : txt.Data = "RP" : .Cols(37).TextAlign = TextAlignEnum.RightCenter : .Cols(37).AllowMerging = True : .Cols(37).Name = "RPPOINPENGAJUANCOMPLETE" : .Cols(37).Format = "#,###0"



            txt = .GetCellRange(0, 38, 0, 40) : txt.Data = "SISA POIN" : .Cols(38).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 38, 1, 38) : txt.Data = "QTY " : .Cols(38).TextAlign = TextAlignEnum.RightCenter : .Cols(38).AllowMerging = True : .Cols(38).Name = "SISAQTYTOKO" : .Cols(38).Format = "#,###0"
            txt = .GetCellRange(1, 39, 1, 39) : txt.Data = "JUMLAH POIN" : .Cols(39).TextAlign = TextAlignEnum.RightCenter : .Cols(39).AllowMerging = True : .Cols(39).Name = "SISAPOINTOKO" : .Cols(39).Format = "#,###0"
            txt = .GetCellRange(1, 40, 1, 40) : txt.Data = "RP" : .Cols(40).TextAlign = TextAlignEnum.RightCenter : .Cols(40).AllowMerging = True : .Cols(40).Name = "SISARPPOINTOKO" : .Cols(40).Format = "#,###0"


            txt = .GetCellRange(0, 41, 1, 41) : txt.Data = "NO. REK TOKO " : .Cols(41).TextAlign = TextAlignEnum.LeftCenter : .Cols(41).AllowMerging = True : .Cols(41).Name = "NoRekToko"
            txt = .GetCellRange(0, 42, 1, 42) : txt.Data = "NAMA REK TOKO " : .Cols(42).TextAlign = TextAlignEnum.LeftCenter : .Cols(42).AllowMerging = True : .Cols(42).Name = "NamaRekToko"
            txt = .GetCellRange(0, 43, 1, 43) : txt.Data = "BANK" : .Cols(43).TextAlign = TextAlignEnum.LeftCenter : .Cols(43).AllowMerging = True : .Cols(43).Name = "Bank"
            txt = .GetCellRange(0, 44, 1, 44) : txt.Data = "TANGGAL PENGAJUAN " : .Cols(44).TextAlign = TextAlignEnum.LeftCenter : .Cols(44).AllowMerging = True : .Cols(44).Name = "TglTransfer"
            txt = .GetCellRange(0, 45, 1, 45) : txt.Data = "PENGAJUAN BY " : .Cols(45).TextAlign = TextAlignEnum.LeftCenter : .Cols(45).AllowMerging = True : .Cols(45).Name = "PengajuanBy"
            txt = .GetCellRange(0, 46, 1, 46) : txt.Data = "FOTO" : .Cols(46).TextAlign = TextAlignEnum.CenterCenter : .Cols(46).AllowMerging = True : .Cols(46).Name = "FOTO" : .Cols(46).Visible = False

            txt = .GetCellRange(0, 47, 1, 47) : txt.Data = "BUKTITRF" : .Cols(47).TextAlign = TextAlignEnum.CenterCenter : .Cols(47).AllowMerging = True : .Cols(47).Name = "BUKTITRF" : .Cols(47).Visible = False

            txt = .GetCellRange(0, 48, 1, 48) : txt.Data = "BUKTITRF" : .Cols(48).TextAlign = TextAlignEnum.CenterCenter : .Cols(48).AllowMerging = True : .Cols(48).Name = "BUKTITRF2" : .Cols(48).ImageAlign = ImageAlignEnum.CenterCenter


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
        Me.Cursor = Cursors.WaitCursor
        ShowData()
        ShowData2()
        Dim A As Integer
        A = 0
        For I = 3 To fg.Rows.Count - 1


            If fg.Item(I, "NAMATOKO") <> "" Then

                fg.Item(I, "NO") = A + 1
                A = A + 1
            Else
                A = 0
            End If
        Next I
        A = 0
        For I = 3 To C1FlexGrid1.Rows.Count - 1


            If C1FlexGrid1.Item(I, "NAMATOKO") <> "" Then

                C1FlexGrid1.Item(I, "NO") = A + 1
                A = A + 1
            Else
                A = 0
            End If
        Next I
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub ShowTotal()
        With fg
            .Tree.Column = 0
            .Tree.Style = TreeStyleFlags.SimpleLeaf
            .Subtotal(AggregateEnum.Clear)
            For I = 23 To 39

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

            '.Subtotal(AggregateEnum.Sum, -1, -1, 312, "Grand Total")
            '.Subtotal(AggregateEnum.Sum, 2, 2, 312, "Total")

            '.Subtotal(AggregateEnum.Sum, -1, -1, 34, "Grand Total")
            '.Subtotal(AggregateEnum.Sum, 2, 2, 34, "Total")

            '.Subtotal(AggregateEnum.Sum, -1, -1, 38, "Grand Total")
            '.Subtotal(AggregateEnum.Sum, 2, 2, 38, "Total")
        End With
        Call ColorSubTotal()

    End Sub

    Private Sub showtotal2()

        With C1FlexGrid1
            .Tree.Column = 0
            .Tree.Style = TreeStyleFlags.SimpleLeaf
            .Subtotal(AggregateEnum.Clear)
            For I = 23 To 39

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

            '.Subtotal(AggregateEnum.Sum, -1, -1, 312, "Grand Total")
            '.Subtotal(AggregateEnum.Sum, 2, 2, 312, "Total")

            '.Subtotal(AggregateEnum.Sum, -1, -1, 34, "Grand Total")
            '.Subtotal(AggregateEnum.Sum, 2, 2, 34, "Total")

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

        With C1FlexGrid1
            cs = .Styles(C1.Win.C1FlexGrid.CellStyleEnum.GrandTotal)
            cs.BackColor = Color.SteelBlue
        End With
    End Sub

    Public Sub ShowData()
        Dim sqlConditions As New List(Of String)


        Dim i As Integer = 2
        Dim sql As String = ""

        If chkTgl.Checked = True Then
            sql = Modul_RMP.Func.SetCondition(sql, "CAST( Tanggal_Pengajuan AS DATE) BETWEEN  '" & Format(dtp1.Value, "yyyy-MM-dd") & "' AND '" & Format(dtp2.Value, "yyyy-MM-dd") & "' ")
        End If

        If chktukarpoin.Checked = True Then
            sql = Modul_RMP.Func.SetCondition(sql, " CAST( TanggalTransaksiKlaim  As Date)  BETWEEN '" & Format(Dt1.Value, "yyyy-MM-dd") & "'  AND '" & Format(Dt2.Value, "yyyy-MM-dd") & "' ")
        End If


        If chkS_Petani.Checked = True Then
            sql = Modul_RMP.Func.SetCondition(sql, " KODESUP ='" & cmbS_Petani.SelectedValue.ToString & "' ")
        End If

        If chk1.Checked = True Then
            Dim condition1 As String = " (Kode_Pengajuan IS NULL AND status_pengajuan IS NULL) "
            sqlConditions.Add(condition1)
        End If

        If chk2.Checked = True Then
            Dim condition2 As String = " (Kode_Pengajuan IS NOT NULL AND status_pengajuan = 0)"
            sqlConditions.Add(condition2)
        End If

        If chk3.Checked = True Then
            Dim condition3 As String = " (Kode_Pengajuan IS NOT NULL AND status_pengajuan = 1)"
            sqlConditions.Add(condition3)
        End If

        If chk4.Checked = True Then
            Dim condition4 As String = " (Kode_Pengajuan IS NOT NULL AND status_pengajuan = 2) "
            sqlConditions.Add(condition4)
        End If


        If chkpancang.Checked = True Then
            sql = Modul_RMP.Func.SetCondition(sql, " IDPancang= '" & cbopancang.SelectedValue.ToString & "' ")
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
                                                          " WHERE 1=1   " & IIf(sql = "", "", " AND " & sql) & IIf(sqlConditions.Count > 0, " AND (" & String.Join(" OR ", sqlConditions) & ")", "") & "   ORDER BY TOKO_ID asc")

        If dt.Rows.Count > 0 Then
            With fg
                fg.Rows.Count=2
                For Each dr As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "ID") = ""
                    .Item(i, "NO") = ""
                    .Item(i, 2) = dr!TOKO_ID
                    .Item(i, "NAMATOKO") = dr!Nama_Toko
                    .Item(i, "NAMATOKO2") = dr!Nama_Toko
                    .Item(i, "ALAMATTOKO") = dr!Alamat_Toko
                    .Item(i, "KODESUPPLIER") = dr!KodeSup
                    .Item(i, "NAMASUPPLIER") = dr!NamaSup
                    .Item(i, "ALAMATSUPPLIER") = dr!Alamat
                    .Item(i, "PANCANG") = dr!PANCANG
                    .Item(i, "JENISTRANSAKSI") = dr!Jenis_Transaksi
                    .Item(i, "KODEPENGAJUAN") = dr!Kode_Pengajuan
                    .Item(i, "TGLPENGAJUAN") = dr!Tanggal_Pengajuan
                    .Item(i, "TANGGALPENGAMBILAN") = dr!TglPengambilanBarang
                    .Item(i, "NOTRANSPENGAJUAN") = dr!NoTransPengajuan
                    .Item(i, "PENGAJUANBY") = dr!pENGAJUANbY

                    .Item(i, "KODEITEM") = dr!Kode_Item
                    .Item(i, "NAMAITEM") = dr!Nama_Item
                    .Item(i, "JENISITEM") = dr!Jenis_Item
                    .Item(i, "FOTO") = dr!Foto_Transaksi
                    .Item(i, "SATUAN") = dr!Satuan

                    .Item(i, "QTY") = dr!Qty
                    .Item(i, "POIN") = dr!Poin
                    .Item(i, "Harga") = dr!Harga
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
                    .Item(i, "TglTransfer") = dr!tglpengajuanpembayaran
                    .Item(i, "BUKTITRF") = dr!BUKTITRF


                    Me.fg.SetCellImage(i, 17, My.Resources.find20)
                    Me.fg.SetCellImage(i, "btnFoto", My.Resources.icon_foto_16px)

                    If IIf(IsDBNull(.Item(i, "BUKTITRF")), 0, dr!BUKTITRF) = 0 Then
                        .Item(i, "BUKTITRF2") = ""

                    Else

                        Me.fg.SetCellImage(i, 47, My.Resources.PRINTF2)
                    End If

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


    Public Sub ShowData2()
        Dim i As Integer = 2
        Dim sql As String = ""

        If chkTgl.Checked = True Then
            sql = Modul_RMP.Func.SetCondition(sql, "CAST( Tanggal_Pengajuan As Date) BETWEEN  '" & Format(dtp1.Value, "yyyy-MM-dd") & "' AND '" & Format(dtp2.Value, "yyyy-MM-dd") & "' ")
        End If

        If chktukarpoin.Checked = True Then
            sql = Modul_RMP.Func.SetCondition(sql, " CAST( TanggalTransaksiKlaim  As Date)  BETWEEN '" & Format(Dt1.Value, "yyyy-MM-dd") & "'  AND '" & Format(Dt2.Value, "yyyy-MM-dd") & "' ")
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
            With C1FlexGrid1
                Call UI.HapusGrid(2, C1FlexGrid1)
                For Each dr As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "ID") = ""
                    .Item(i, "NO") = ""
                    .Item(i, 2) = dr!TOKO_ID
                    .Item(i, "NAMATOKO") = dr!Nama_Toko
                    .Item(i, "NAMATOKO2") = dr!Nama_Toko
                    .Item(i, "ALAMATTOKO") = dr!Alamat_Toko
                    .Item(i, "KODESUPPLIER") = dr!KodeSup
                    .Item(i, "NAMASUPPLIER") = dr!NamaSup
                    .Item(i, "ALAMATSUPPLIER") = dr!Alamat
                    .Item(i, "PANCANG") = dr!PANCANG
                    .Item(i, "JENISTRANSAKSI") = dr!Jenis_Transaksi
                    .Item(i, "KODEPENGAJUAN") = dr!Kode_Pengajuan
                    .Item(i, "TGLPENGAJUAN") = dr!Tanggal_Pengajuan
                    .Item(i, "TANGGALPENGAMBILAN") = dr!TglPengambilanBarang
                    .Item(i, "NOTRANSPENGAJUAN") = dr!NoTransPengajuan
                    .Item(i, "PENGAJUANBY") = dr!pENGAJUANbY

                    .Item(i, "KODEITEM") = dr!Kode_Item
                    .Item(i, "NAMAITEM") = dr!Nama_Item
                    .Item(i, "JENISITEM") = dr!Jenis_Item
                    .Item(i, "FOTO") = dr!Foto_Transaksi
                    .Item(i, "SATUAN") = dr!Satuan

                    .Item(i, "QTY") = dr!Qty
                    .Item(i, "POIN") = dr!Poin
                    .Item(i, "Harga") = dr!Harga
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
                    .Item(i, "TglTransfer") = dr!tglpengajuanpembayaran
                    .Item(i, "BUKTITRF") = dr!BUKTITRF


                    'Me.C1FlexGrid1.SetCellImage(i, 16, My.Resources.find20)
                    If IIf(IsDBNull(.Item(i, "BUKTITRF")), 0, dr!BUKTITRF) = 0 Then
                        .Item(i, "BUKTITRF2") = ""

                    Else

                        'Me.C1FlexGrid1.SetCellImage(i, 46, My.Resources.PRINTF2)
                    End If

                    i = i + 1
                Next
                showtotal2()
                .AutoSizeCols()
            End With
        Else
            Call UI.HapusGrid(2, C1FlexGrid1)
            MsgBox("No Data !", MsgBoxStyle.Exclamation, AT)
        End If
    End Sub


    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Dim filename As String
        Me.SaveFileDialog.ShowDialog()
        filename = SaveFileDialog.FileName
        Me.C1FlexGrid1.SaveExcel(filename & ".xls", "Sheet1", FileFlags.IncludeFixedCells)
        MsgBox("File Excel Berhasil Disimpan !", MsgBoxStyle.Information, AT)
    End Sub

    'Private Sub fg_AfterSelChange(sender As Object, e As RangeEventArgs)
    '    Dim sum As Double
    '    Dim R, c As Integer
    '    With fg
    '        If .Row = 0 Then Exit Sub
    '        If .RowSel > .Row Then
    '            For R = .Row To .RowSel
    '                If (R > 0) And (R <= (.Rows.Count - 1)) Then
    '                    For c = .Col To .ColSel
    '                        Select Case c
    '                            Case 18, 19, 20, 22, 23, 24, 25, 26, 27, 28, 29, 30, 32, 31, 33, 34, 35, 36, 37, 38
    '                                If Trim(.Item(R, c) <> 0) Then
    '                                    sum = sum + CDbl(.Item(R, c))
    '                                End If
    '                        End Select
    '                    Next
    '                End If
    '            Next
    '        End If
    '    End With
    '    txtSum.Text = FormatNumber(sum, 0)
    'End Sub

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

    Private Sub fg_DoubleClick(sender As Object, e As EventArgs) Handles fg.DoubleClick

        Select Case fg.Cols(fg.Col).Name

            Case "btnFoto"

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

            Case 48

                ' Logic PDF tetap seperti sebelumnya

        End Select

    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click

    End Sub

    Private Sub fg_AfterSelChange(sender As Object, e As RangeEventArgs) Handles fg.AfterSelChange
        Dim sum As Double
        Dim R, c As Integer
        Try
            With fg
                If .Row = 0 Then Exit Sub
                If .RowSel > .Row Then
                    For R = .Row To .RowSel
                        If (R > 0) And (R <= (.Rows.Count - 1)) Then
                            For c = .Col To .ColSel
                                Select Case c
                                    Case 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 38, 39
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
        Catch ex As Exception

        End Try
    End Sub



    Private Sub cbopancang_KeyUp(sender As Object, e As KeyEventArgs) Handles cbopancang.KeyUp
        UI.AutoCompleteCombo_KeyUp(cbopancang, e)
    End Sub

    Private Sub cbopancang_Validated(sender As Object, e As EventArgs) Handles cbopancang.Validated
        chkpancang.Checked = IIf(cbopancang.Text = "", False, True)
    End Sub

    Private Sub cbopancang_Validating(sender As Object, e As CancelEventArgs) Handles cbopancang.Validating
        If cbopancang.Text = "" Then
            Exit Sub
        End If

        If IsNothing(cbopancang.SelectedValue) Then
            MsgBox("Pilihan tidak ada !", vbExclamation, AT)
            cbopancang.Text = ""
            cbopancang.Focus()
        End If
    End Sub

    Private Sub SaveFileDialog_FileOk(sender As Object, e As CancelEventArgs) Handles SaveFileDialog.FileOk

    End Sub
End Class