Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports System.Windows.Forms.Design
Imports C1.Win.C1FlexGrid
Imports Excel = Microsoft.Office.Interop.Excel

Public Class FrmTrnPoinPengajuanFind
    Public Sub HeaderFG()
        Dim txt As CellRange
        With fg
            .AllowEditing = True
            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular)
            .Cols.Count = 23
            .Cols.Fixed = 1
            .Cols.Frozen = 2
            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            '.Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            '.Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 1
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "N0" : .Cols(0).Name = "No" : .Cols(0).Width = 50
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "NO INVOICE" : .Cols(1).Name = "NOINVOICE" : .Cols(1).TextAlign = TextAlignEnum.CenterCenter : .Cols(1).AllowEditing = False : .Cols(1).AllowMerging = True
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "TGL INVOICE" : .Cols(2).Name = "TGLINVOICE" : .Cols(2).TextAlign = TextAlignEnum.CenterCenter : .Cols(2).AllowEditing = False : .Cols(2).AllowMerging = True
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "IDTOKO" : .Cols(3).Name = "IDTOKO" : .Cols(3).TextAlign = TextAlignEnum.CenterCenter : .Cols(3).AllowEditing = False : .Cols(3).Visible = False : .Cols(3).AllowMerging = True
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "NO TRANSAKSI" : .Cols(4).Name = "NOTRANSAKSI" : .Cols(4).TextAlign = TextAlignEnum.CenterCenter : .Cols(4).AllowEditing = False : .Cols(4).AllowMerging = True
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "TGL TRANSAKSI" : .Cols(5).Name = "TGLTRANSAKSI" : .Cols(5).TextAlign = TextAlignEnum.CenterCenter : .Cols(5).AllowEditing = False : .Cols(5).AllowMerging = True
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "JAM TRANSAKSI" : .Cols(6).Name = "JAMTRANSAKSI" : .Cols(6).TextAlign = TextAlignEnum.CenterCenter : .Cols(6).AllowEditing = False : .Cols(6).AllowMerging = True : .Cols(6).Visible = False
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "TGL PENGAJUAN PEMBAYARAN" : .Cols(7).Name = "TGLPENGAJUANPEMBAYARAN" : .Cols(7).TextAlign = TextAlignEnum.CenterCenter : .Cols(7).AllowEditing = False : .Cols(7).AllowMerging = True
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "NAMA TOKO" : .Cols(8).Name = "NAMATOKO" : .Cols(8).TextAlign = TextAlignEnum.LeftCenter : .Cols(8).AllowEditing = False : .Cols(8).AllowMerging = True
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "ALAMAT TOKO" : .Cols(9).Name = "ALAMATTOKO" : .Cols(9).TextAlign = TextAlignEnum.CenterCenter : .Cols(9).AllowEditing = False
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "PETANI ID" : .Cols(10).Name = "PETANIID" : .Cols(10).TextAlign = TextAlignEnum.CenterCenter : .Cols(10).AllowEditing = False
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "NAMA PETANI" : .Cols(11).Name = "NAMAPETANI" : .Cols(11).TextAlign = TextAlignEnum.CenterCenter : .Cols(11).AllowEditing = False
            txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "ALAMAT" : .Cols(12).Name = "ALAMAT" : .Cols(12).TextAlign = TextAlignEnum.CenterCenter : .Cols(12).AllowEditing = False
            txt = .GetCellRange(0, 13, 0, 13) : txt.Data = "ITEM ID" : .Cols(13).Name = "ITEMID" : .Cols(13).TextAlign = TextAlignEnum.CenterCenter : .Cols(13).AllowEditing = False
            txt = .GetCellRange(0, 14, 0, 14) : txt.Data = "ITEM NAME" : .Cols(14).Name = "ITEMNAME" : .Cols(14).TextAlign = TextAlignEnum.CenterCenter : .Cols(14).AllowEditing = False
            txt = .GetCellRange(0, 15, 0, 15) : txt.Data = "QTY" : .Cols(15).Name = "QTY" : .Cols(15).TextAlign = TextAlignEnum.CenterCenter : .Cols(15).AllowEditing = False : .Cols(15).Format = "#,###0"
            txt = .GetCellRange(0, 16, 0, 16) : txt.Data = "SATUAN" : .Cols(16).Name = "SATUAN" : .Cols(16).TextAlign = TextAlignEnum.CenterCenter : .Cols(16).AllowEditing = False
            txt = .GetCellRange(0, 17, 0, 17) : txt.Data = "POIN" : .Cols(17).Name = "POIN" : .Cols(17).TextAlign = TextAlignEnum.CenterCenter : .Cols(17).AllowEditing = False : .Cols(17).Format = "#,###0"
            txt = .GetCellRange(0, 18, 0, 18) : txt.Data = "RUPIAH" : .Cols(18).Name = "RUPIAH" : .Cols(18).TextAlign = TextAlignEnum.CenterCenter : .Cols(18).AllowEditing = False : .Cols(18).Format = "#,###0"
            txt = .GetCellRange(0, 19, 0, 19) : txt.Data = "ID" : .Cols(19).Name = "ID" : .Cols(19).TextAlign = TextAlignEnum.CenterCenter : .Cols(19).AllowEditing = False : .Cols(19).Visible = False
            txt = .GetCellRange(0, 20, 0, 20) : txt.Data = "CREATEDBY" : .Cols(20).Name = "CREATEDBY" : .Cols(20).TextAlign = TextAlignEnum.CenterCenter : .Cols(20).AllowEditing = False
            txt = .GetCellRange(0, 21, 0, 21) : txt.Data = "EDIT" : .Cols(21).Name = "EDIT" : .Cols(21).TextAlign = TextAlignEnum.CenterCenter : .Cols(21).AllowEditing = False
            txt = .GetCellRange(0, 22, 0, 22) : txt.Data = "PRINT" : .Cols(22).Name = "PRINT" : .Cols(22).TextAlign = TextAlignEnum.CenterCenter : .Cols(22).AllowEditing = False

            .AutoSizeCols()
        End With
    End Sub

    Public Sub HeaderFG2()
        Dim txt As CellRange
        With fg2
            .AllowEditing = True
            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular)
            .Cols.Count = 23
            .Cols.Fixed = 1
            .Cols.Frozen = 2
            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            '.Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            '.Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 1
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "N0" : .Cols(0).Name = "No" : .Cols(0).Width = 50
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "NO INVOICE" : .Cols(1).Name = "NOINVOICE" : .Cols(1).TextAlign = TextAlignEnum.CenterCenter : .Cols(1).AllowEditing = False : .Cols(1).AllowMerging = True
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "TGL INVOICE" : .Cols(2).Name = "TGLINVOICE" : .Cols(2).TextAlign = TextAlignEnum.CenterCenter : .Cols(2).AllowEditing = False : .Cols(2).AllowMerging = True
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "IDTOKO" : .Cols(3).Name = "IDTOKO" : .Cols(3).TextAlign = TextAlignEnum.CenterCenter : .Cols(3).AllowEditing = False : .Cols(3).Visible = False : .Cols(3).AllowMerging = True
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "NO TRANSAKSI" : .Cols(4).Name = "NOTRANSAKSI" : .Cols(4).TextAlign = TextAlignEnum.CenterCenter : .Cols(4).AllowEditing = False : .Cols(4).AllowMerging = True
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "TGL TRANSAKSI" : .Cols(5).Name = "TGLTRANSAKSI" : .Cols(5).TextAlign = TextAlignEnum.CenterCenter : .Cols(5).AllowEditing = False : .Cols(5).AllowMerging = True
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "JAM TRANSAKSI" : .Cols(6).Name = "JAMTRANSAKSI" : .Cols(6).TextAlign = TextAlignEnum.CenterCenter : .Cols(6).AllowEditing = False : .Cols(6).AllowMerging = True : .Cols(6).Visible = False
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "TGL PENGAJUAN PEMBAYARAN" : .Cols(7).Name = "TGLPENGAJUANPEMBAYARAN" : .Cols(7).TextAlign = TextAlignEnum.CenterCenter : .Cols(7).AllowEditing = False : .Cols(7).AllowMerging = True
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "NAMA TOKO" : .Cols(8).Name = "NAMATOKO" : .Cols(8).TextAlign = TextAlignEnum.LeftCenter : .Cols(8).AllowEditing = False : .Cols(8).AllowMerging = True
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "ALAMAT TOKO" : .Cols(9).Name = "ALAMATTOKO" : .Cols(9).TextAlign = TextAlignEnum.LeftCenter : .Cols(9).AllowEditing = False
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "PETANI ID" : .Cols(10).Name = "PETANIID" : .Cols(10).TextAlign = TextAlignEnum.LeftCenter : .Cols(10).AllowEditing = False
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "NAMA PETANI" : .Cols(11).Name = "NAMAPETANI" : .Cols(11).TextAlign = TextAlignEnum.LeftCenter : .Cols(11).AllowEditing = False
            txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "ALAMAT" : .Cols(12).Name = "ALAMAT" : .Cols(12).TextAlign = TextAlignEnum.LeftCenter : .Cols(12).AllowEditing = False
            txt = .GetCellRange(0, 13, 0, 13) : txt.Data = "ITEM ID" : .Cols(13).Name = "ITEMID" : .Cols(13).TextAlign = TextAlignEnum.LeftCenter : .Cols(13).AllowEditing = False
            txt = .GetCellRange(0, 14, 0, 14) : txt.Data = "ITEM NAME" : .Cols(14).Name = "ITEMNAME" : .Cols(14).TextAlign = TextAlignEnum.LeftCenter : .Cols(14).AllowEditing = False
            txt = .GetCellRange(0, 15, 0, 15) : txt.Data = "QTY" : .Cols(15).Name = "QTY" : .Cols(15).TextAlign = TextAlignEnum.RightCenter : .Cols(15).AllowEditing = False : .Cols(15).Format = "#,###0"
            txt = .GetCellRange(0, 16, 0, 16) : txt.Data = "SATUAN" : .Cols(16).Name = "SATUAN" : .Cols(16).TextAlign = TextAlignEnum.CenterCenter : .Cols(16).AllowEditing = False
            txt = .GetCellRange(0, 17, 0, 17) : txt.Data = "POIN" : .Cols(17).Name = "POIN" : .Cols(17).TextAlign = TextAlignEnum.RightCenter : .Cols(17).AllowEditing = False : .Cols(17).Format = "#,###0"
            txt = .GetCellRange(0, 18, 0, 18) : txt.Data = "RUPIAH" : .Cols(18).Name = "RUPIAH" : .Cols(18).TextAlign = TextAlignEnum.RightCenter : .Cols(18).AllowEditing = False : .Cols(18).Format = "#,###0"
            txt = .GetCellRange(0, 19, 0, 19) : txt.Data = "ID" : .Cols(19).Name = "ID" : .Cols(19).TextAlign = TextAlignEnum.CenterCenter : .Cols(19).AllowEditing = False : .Cols(19).Visible = False
            txt = .GetCellRange(0, 20, 0, 20) : txt.Data = "CREATEDBY" : .Cols(20).Name = "CREATEDBY" : .Cols(20).TextAlign = TextAlignEnum.CenterCenter : .Cols(20).AllowEditing = False
            txt = .GetCellRange(0, 21, 0, 21) : txt.Data = "EDIT" : .Cols(21).Name = "EDIT" : .Cols(21).TextAlign = TextAlignEnum.CenterCenter : .Cols(21).AllowEditing = False
            'txt = .GetCellRange(0, 22, 0, 22) : txt.Data = "PRINT" : .Cols(22).Name = "PRINT" : .Cols(22).TextAlign = TextAlignEnum.CenterCenter : .Cols(22).AllowEditing = False

            .AutoSizeCols()
        End With
    End Sub

    Private Sub GrandTotal()
        With fg
            .Tree.Column = 0
            .Tree.Style = TreeStyleFlags.CompleteLeaf
            .Subtotal(AggregateEnum.Clear)
            .Subtotal(AggregateEnum.Sum, -1, -1, 15, "TOTAL")
            .Subtotal(AggregateEnum.Sum, 1, 1, 15, "Pengajuan-{0}")
            .Subtotal(AggregateEnum.Sum, -1, -1, 17)
            .Subtotal(AggregateEnum.Sum, 1, 1, 17)
            .Subtotal(AggregateEnum.Sum, -1, -1, 18)
            .Subtotal(AggregateEnum.Sum, 1, 1, 18)
            .AutoSizeCols()
        End With

        ColorSubTotal()
    End Sub

    Private Sub ColorSubTotal()
        Dim cs As C1.Win.C1FlexGrid.CellStyle
        With fg
            cs = .Styles(C1.Win.C1FlexGrid.CellStyleEnum.GrandTotal)
            'cs.BackColor = Color.DimGray
            cs.Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Bold)

            cs = .Styles(C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0)
            'cs.BackColor = Color.FromArgb(156, 206, 255)
            cs.Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Regular)
        End With

        With fg2
            cs = .Styles(C1.Win.C1FlexGrid.CellStyleEnum.GrandTotal)
            'cs.BackColor = Color.DimGray
            cs.Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Bold)

            cs = .Styles(C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0)
            'cs.BackColor = Color.FromArgb(156, 206, 255)
            cs.Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Regular)
        End With
    End Sub

    Private Sub GrandTotal2()
        With fg2
            .Tree.Column = 0
            .Tree.Style = TreeStyleFlags.CompleteLeaf
            .Subtotal(AggregateEnum.Clear)
            .Subtotal(AggregateEnum.Sum, -1, -1, 15, "TOTAL")
            .Subtotal(AggregateEnum.Sum, 1, 1, 15, "Pengajuan-{0}")
            .Subtotal(AggregateEnum.Sum, -1, -1, 17)
            .Subtotal(AggregateEnum.Sum, 1, 1, 17)
            .Subtotal(AggregateEnum.Sum, -1, -1, 18)
            .Subtotal(AggregateEnum.Sum, 1, 1, 18)
            .AutoSizeCols()
        End With

        ColorSubTotal()
    End Sub

    Private Sub FrmTrnPoinPengajuanFind_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Modul_RMP.Combo.SetSupplier(cmbS_Petani)
        Modul_RMP.Combo.SettokoPancang(cmbToko)
        HeaderFG()
        HeaderFG2()
        dt1.Value = Format(Now, "yyyy-MM-dd")
        dt2.Value = Format(Now, "yyyy-MM-dd")
        dtp1.Value = Format(Now, "yyyy-MM-dd")
        dtp2.Value = Format(Now, "yyyy-MM-dd")
        DTPStart.Value = Format(Now, "yyyy-MM-dd")
        DTPEnd.Value = Format(Now, "yyyy-MM-dd")
        search()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        FrmTrnPoinPengajuan.Show()
        FrmTrnPoinPengajuan.perintah = "Add"
    End Sub

    Private Sub ShowData()
        Dim i As Integer = 1
        Dim sql As String = ""
        Dim dt As DataTable = New DataTable()

        Try
            If chknoinvoice.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "notranspengajuan ='" & txtinvoice.Text & "' ")
            End If

            If chkTransDate.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, " CAST(tanggal_pengajuan AS DATE ) BETWEEN  CONVERT (DATETIME,'" & DTPStart.Value & "',103) And  CONVERT (DATETIME,'" & DTPEnd.Value & "',103)")
            End If

            If chkDoDate.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "CONVERT(DATETIME, Convert(VARCHAR, tglInvoice, 103), 103) BETWEEN CONVERT (DATETIME,'" & dt1.Value & "',103) AND CONVERT(DATETIME,'" & dt2.Value & "',103)  ")
            End If

            If chkPengajuan.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "CONVERT(DATETIME, Convert(VARCHAR, tglpengajuanpembayaran, 103), 103) BETWEEN CONVERT (DATETIME,'" & dtp1.Value & "',103) AND CONVERT(DATETIME,'" & dtp2.Value & "',103)  ")
            End If

            If chkToko.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "ID_Toko ='" & cmbToko.SelectedValue & "'  ")
            End If

            If chkS_Petani.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "KodeSup ='" & cmbS_Petani.SelectedValue & "'  ")
            End If

            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT * from RMPApp..vwpengajuanpoindtl where noinvoice is not null and status_pengajuan=1  " & IIf(sql = "", "", " And " & sql) & " ")

            If dt.Rows.Count > 0 Then
                With fg
                    Call ui.HapusGrid(1, fg)
                    For Each row As DataRow In dt.Rows
                        .AddItem(i)
                        .Item(i, "No") = i
                        .Item(i, "NOINVOICE") = row.Item("NOINVOICE")
                        .Item(i, "TGlINVOICE") = row.Item("TGLINVOICE")
                        .Item(i, "IDTOKO") = row.Item("ID_Toko")
                        .Item(i, "NOTRANSAKSI") = row.Item("kode_pengajuan")
                        .Item(i, "TGLTRANSAKSI") = row.Item("tanggal_pengajuan")
                        .Item(i, "TGLPENGAJUANPEMBAYARAN") = IIf(IsDBNull(row.Item("tglpengajuanpembayaran")), "", row.Item("tglpengajuanpembayaran"))
                        .Item(i, "JAMTRANSAKSI") = row.Item("tanggal_pengajuan")
                        .Item(i, "NAMATOKO") = row.Item("nama_toko")
                        .Item(i, "ALAMATTOKO") = row.Item("alamat_toko")
                        .Item(i, "PETANIID") = row.Item("KodeSup")
                        .Item(i, "NAMAPETANI") = row.Item("NamaSup")
                        .Item(i, "ALAMAT") = row.Item("Alamat")
                        .Item(i, "ITEMID") = row.Item("item_id")
                        .Item(i, "ITEMNAME") = row.Item("nama_item")
                        .Item(i, "QTY") = row.Item("qty")
                        .Item(i, "SATUAN") = row.Item("satuan")
                        .Item(i, "POIN") = row.Item("bayar_poin")
                        .Item(i, "RUPIAH") = row.Item("bayar_rupiah")
                        '.Item(i, "ID_TOKO") = row.Item("ID_Toko")
                        .Item(i, "ID") = row.Item("id")
                        .Item(i, "CREATEDBY") = row.Item("createdbypengajuan")
                        Me.fg.SetCellImage(i, 21, My.Resources.icons8_edit_20)
                        Me.fg.SetCellImage(i, 22, My.Resources.PRINTF2)
                        i = i + 1
                    Next
                    .AutoSizeCols()
                End With
                GrandTotal()
            Else
                Call ui.HapusGrid(1, fg)
                MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
            End If
        Catch EX As Exception
            MsgBox(EX.Message)
        End Try
    End Sub

    Private Sub ShowData2()
        Dim i As Integer = 1
        Dim sql As String = ""
        Dim dt As DataTable = New DataTable()

        Try
            If chknoinvoice.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "notranspengajuan ='" & txtinvoice.Text & "' ")
            End If

            If chkTransDate.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "CONVERT(DATETIME, Convert(VARCHAR, tanggal_pengajuan, 103), 103)  BETWEEN  CONVERT (DATETIME,'" & DTPStart.Value & "',103) And CONVERT (DATETIME,'" & DTPEnd.Value & "',103)")
            End If

            If chkDoDate.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "CONVERT(DATETIME, Convert(VARCHAR, tglInvoice, 103), 103) BETWEEN CONVERT (DATETIME,'" & dt1.Value & "',103) AND CONVERT(DATETIME,'" & dt2.Value & "',103)  ")
            End If

            If chkPengajuan.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "CONVERT(DATETIME, Convert(VARCHAR, tglpengajuanpembayaran, 103), 103) BETWEEN CONVERT (DATETIME,'" & dtp1.Value & "',103) AND CONVERT(DATETIME,'" & dtp2.Value & "',103)  ")
            End If

            If chkToko.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "ID_Toko ='" & cmbToko.SelectedValue & "'  ")
            End If

            If chkS_Petani.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "KodeSup ='" & cmbS_Petani.SelectedValue & "'  ")
            End If

            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT * from RMPApp..vwpengajuanpoindtl where noinvoice is not null and status_pengajuan=1  " & IIf(sql = "", "", " And " & sql) & " ")

            If dt.Rows.Count > 0 Then
                With fg2
                    Call UI.HapusGrid(1, fg2)
                    For Each row As DataRow In dt.Rows
                        .AddItem(i)
                        .Item(i, "No") = i
                        .Item(i, "NOINVOICE") = row.Item("NOINVOICE")
                        .Item(i, "TGlINVOICE") = row.Item("TGLINVOICE")
                        .Item(i, "IDTOKO") = row.Item("ID_Toko")
                        .Item(i, "NOTRANSAKSI") = row.Item("kode_pengajuan")
                        .Item(i, "TGLTRANSAKSI") = row.Item("tanggal_pengajuan")
                        .Item(i, "TGLPENGAJUANPEMBAYARAN") = IIf(IsDBNull(row.Item("tglpengajuanpembayaran")), "", row.Item("tglpengajuanpembayaran"))
                        .Item(i, "JAMTRANSAKSI") = row.Item("tanggal_pengajuan")
                        .Item(i, "NAMATOKO") = row.Item("nama_toko")
                        .Item(i, "ALAMATTOKO") = row.Item("alamat_toko")
                        .Item(i, "PETANIID") = row.Item("KodeSup")
                        .Item(i, "NAMAPETANI") = row.Item("NamaSup")
                        .Item(i, "ALAMAT") = row.Item("Alamat")
                        .Item(i, "ITEMID") = row.Item("item_id")
                        .Item(i, "ITEMNAME") = row.Item("nama_item")
                        .Item(i, "QTY") = row.Item("qty")
                        .Item(i, "SATUAN") = row.Item("satuan")
                        .Item(i, "POIN") = row.Item("bayar_poin")
                        .Item(i, "RUPIAH") = row.Item("bayar_rupiah")
                        '.Item(i, "ID_TOKO") = row.Item("ID_Toko")
                        .Item(i, "ID") = row.Item("id")
                        .Item(i, "CREATEDBY") = row.Item("createdbypengajuan")
                        i = i + 1
                    Next
                    .AutoSizeCols()
                End With
                GrandTotal2()
            Else
                Call UI.HapusGrid(1, fg2)
                MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
            End If
        Catch EX As Exception
            MsgBox(EX.Message)
        End Try
    End Sub

    Private Sub btnrefreshh_Click(sender As Object, e As EventArgs) Handles btnrefreshh.Click
        ShowData()
        ShowData2()
    End Sub

    Private Sub search()
        With schfg
            .SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
            .SearchDelay = 2
            .Watermark = "Cari Disini"
            .SetC1FlexGridSearchPanel(fg, schfg)
        End With
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Dim filename As String
        Me.SaveFileDialog.ShowDialog()
        filename = SaveFileDialog.FileName
        'Me.fg.SaveExcel(filename & ".xls", "Sheet1", FileFlags.IncludeFixedCells)
        Me.fg2.SaveExcel(filename & ".xls", "Sheet1", FileFlags.IncludeFixedCells)
    End Sub

    Private Sub fg_DoubleClick(sender As Object, e As EventArgs) Handles fg.DoubleClick
        With FrmTrnPoinPengajuan
            Select Case fg.Col
                Case 21
                    .Show()
                    .loaddata(fg.Item(fg.Row, "NOINVOICE"))
                    .cmdEnabled(False)
                    .perintah = "Edit"
                    '.dtp1.Enabled = False
                    '.dtp2.Enabled = False
                    .btnsave.Visible = True
                    .btnexit.Enabled = True

                Case 22
                    With FrmRptRequestPenukaranPoint
                        .noinvoice = fg.Item(fg.Row, "NOINVOICE")
                        .Show()
                        .noinvoice = fg.Item(fg.Row, "NOINVOICE")
                    End With
            End Select
        End With
    End Sub

    Private Sub cmbToko_Validated(sender As Object, e As EventArgs) Handles cmbToko.Validated
        chkToko.Checked = IIf(cmbToko.Text = "", False, True)
    End Sub

    Private Sub cmbS_Petani_Validated(sender As Object, e As EventArgs) Handles cmbS_Petani.Validated
        chkS_Petani.Checked = IIf(cmbS_Petani.Text = "", False, True)
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

    Private Sub cmbS_Petani_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbS_Petani.KeyUp
        UI.AutoCompleteCombo_KeyUp(cmbS_Petani, e)
    End Sub

    Private Sub cmbToko_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbToko.KeyUp
        UI.AutoCompleteCombo_KeyUp(cmbToko, e)
    End Sub

    Private Sub cmbToko_Validating(sender As Object, e As CancelEventArgs) Handles cmbToko.Validating
        If cmbToko.Text = "" Then
            Exit Sub
        End If

        If IsNothing(cmbToko.SelectedValue) Then
            MsgBox("Pilihan tidak ada !", vbExclamation, AT)
            cmbToko.Text = ""
            cmbToko.Focus()
        End If
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub btnAjukanPembayaran_Click(sender As Object, e As EventArgs) Handles btnAjukanPembayaran.Click
        FrmRptPembayaranLoyalty.Show()
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click

    End Sub
End Class