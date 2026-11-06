Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Imports C1.Win.C1FlexGrid
Imports C1.Win
Imports System.Web.UI.Design.WebControls
Imports System.CodeDom
Imports Microsoft.Win32

Public Class FrmMonPembelianBarangPancangCash
    Private Sub FrmMonPembelianBarangPancangCash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Combo.SetPancang(CmbPancang)
        Combo.InvCategory(CmbKategori)

        HeaderFg()
    End Sub


    Private Sub HeaderFg()
        Dim txt As CellRange

        With FG
            .Rows.Fixed = 1
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Cols.Count = 30

            .AutoGenerateColumns = True
            .Rows(0).AllowMerging = True
            .Styles.Normal.WordWrap = True

            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular)
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .AllowMerging = AllowMergingEnum.FixedOnly

            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

            .Rows(0).TextAlign = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).TextAlign = TextAlignEnum.LeftCenter : .Cols(0).AllowEditing = False
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Pilih"
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Pancang" : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).AllowEditing = False
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Kode Transaksi" : .Cols(3).TextAlign = TextAlignEnum.CenterCenter : .Cols(3).AllowEditing = False
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Item" : .Cols(4).TextAlign = TextAlignEnum.LeftCenter : .Cols(4).AllowEditing = False
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Harga" : .Cols(5).TextAlign = TextAlignEnum.CenterCenter : .Cols(5).AllowEditing = False : .Cols(5).Format = "#,###0"
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Quantity" : .Cols(6).TextAlign = TextAlignEnum.RightCenter : .Cols(6).AllowEditing = False
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Total" : .Cols(7).TextAlign = TextAlignEnum.RightCenter : .Cols(7).AllowEditing = False : .Cols(7).Format = "#,###0"
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Kategori" : .Cols(8).TextAlign = TextAlignEnum.LeftCenter : .Cols(8).AllowEditing = False
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "kategori Barang" : .Cols(9).TextAlign = TextAlignEnum.LeftCenter : .Cols(9).AllowEditing = False
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "Catatan Barang" : .Cols(10).TextAlign = TextAlignEnum.LeftCenter : .Cols(10).AllowEditing = False
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "Catatan Nota" : .Cols(11).TextAlign = TextAlignEnum.LeftCenter : .Cols(11).AllowEditing = False
            txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "Foto Barang" : .Cols(12).TextAlign = TextAlignEnum.LeftCenter : .Cols(12).AllowEditing = False
            txt = .GetCellRange(0, 13, 0, 13) : txt.Data = "Foto Nota" : .Cols(13).TextAlign = TextAlignEnum.LeftCenter : .Cols(13).AllowEditing = False
            txt = .GetCellRange(0, 14, 0, 14) : txt.Data = "Edit" : .Cols(14).TextAlign = TextAlignEnum.LeftCenter : .Cols(14).AllowEditing = False
            txt = .GetCellRange(0, 15, 0, 15) : txt.Data = "Created By" : .Cols(15).TextAlign = TextAlignEnum.LeftCenter : .Cols(15).AllowEditing = False
            txt = .GetCellRange(0, 16, 0, 16) : txt.Data = "Created Date" : .Cols(16).TextAlign = TextAlignEnum.CenterCenter : .Cols(16).AllowEditing = False
            txt = .GetCellRange(0, 17, 0, 17) : txt.Data = "Updated By" : .Cols(17).TextAlign = TextAlignEnum.LeftCenter : .Cols(17).AllowEditing = False
            txt = .GetCellRange(0, 18, 0, 18) : txt.Data = "Updated Date" : .Cols(18).TextAlign = TextAlignEnum.LeftCenter : .Cols(18).AllowEditing = False
            txt = .GetCellRange(0, 19, 0, 19) : txt.Data = "Deleted By" : .Cols(19).Visible = False
            txt = .GetCellRange(0, 20, 0, 20) : txt.Data = "Deleted Date" : .Cols(20).Visible = False
            txt = .GetCellRange(0, 21, 0, 21) : txt.Data = "Link Foto Barang" : .Cols(21).Visible = False
            txt = .GetCellRange(0, 22, 0, 22) : txt.Data = "Link Foto Nota" : .Cols(22).Visible = False
            txt = .GetCellRange(0, 23, 0, 23) : txt.Data = "txtCatatanBarang" : .Cols(23).Visible = False
            txt = .GetCellRange(0, 24, 0, 24) : txt.Data = "txtCatatanNota" : .Cols(24).Visible = False
            txt = .GetCellRange(0, 25, 0, 25) : txt.Data = "Detail Id" : .Cols(25).Visible = False
            txt = .GetCellRange(0, 26, 0, 26) : txt.Data = "remark" : .Cols(26).Visible = False
            txt = .GetCellRange(0, 27, 0, 27) : txt.Data = "Terima Nota By" : .Cols(27).TextAlign = TextAlignEnum.LeftCenter : .Cols(27).AllowEditing = False
            txt = .GetCellRange(0, 28, 0, 28) : txt.Data = "Terima Nota Date" : .Cols(28).TextAlign = TextAlignEnum.CenterCenter : .Cols(28).AllowEditing = False
            txt = .GetCellRange(0, 29, 0, 29) : txt.Data = "Tanggal Nota" : .Cols(29).TextAlign = TextAlignEnum.CenterCenter : .Cols(29).AllowEditing = False

            .AutoSizeCols()
        End With
    End Sub
    Private Sub HeaderFgKalkulasi()
        Dim txt As CellRange

        With FG
            .Rows.Fixed = 1
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Cols.Count = 7

            .AutoGenerateColumns = True
            .Rows(0).AllowMerging = True
            .Styles.Normal.WordWrap = True

            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular)
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .AllowMerging = AllowMergingEnum.FixedOnly

            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

            .Rows(0).TextAlign = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).TextAlign = TextAlignEnum.LeftCenter : .Cols(0).AllowEditing = False
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Pilih" : .Cols(1).Visible = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Pancang" : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).AllowEditing = False
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Kategori Item" : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).AllowEditing = False
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Harga" : .Cols(4).TextAlign = TextAlignEnum.RightCenter : .Cols(4).AllowEditing = False : .Cols(4).Format = "#,##0.00"
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Qty" : .Cols(5).TextAlign = TextAlignEnum.RightCenter : .Cols(5).AllowEditing = False : .Cols(5).Format = "#,###0"
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Total Harga" : .Cols(6).TextAlign = TextAlignEnum.RightCenter : .Cols(6).AllowEditing = False : .Cols(6).Format = "#,###0"

            .AutoSizeCols()
        End With
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        ShowData()
    End Sub

    Private Sub ShowData()
        Dim dt As DataTable = New DataTable
        Dim i As Integer = 1
        Dim pembelian As String = ""
        Dim statusPrint As String = ""

        If chkTglNota.Checked = False And chkTglTerima.Checked = False And rdTgl.Checked = False Then
            MsgBox("Wajib pilih tanggal nota / tanggal terima !", vbExclamation, AT)
            Exit Sub
        End If

        If RdPancang.Checked = True Then
            pembelian = "Pancang"
        ElseIf RdPurchaser.Checked = True Then
            pembelian = "Purchaser"
        ElseIf rdPulsa.Checked = True Then
            pembelian = "Listrik / Internet"
        End If

        Dim query As String = " SELECT 
	                                b.kode_trans,f.Pancang,a.nama_item,a.harga_sub, a.qty, a.harga,a.kategori_item,c.nama_kategori,
	                                ISNULL(a.keterangan,'') as catatanBarang,ISNULL(b.catatan,'') as catatanNota,g.NamaLengkap as created_by, a.created_date, b.updated_date, 
                                    b.updated_by, a.deleted_by, a.deleted_date,a.detaild_id, a.header_id,a.foto_item,b.foto_trans,e.nama_penggunaan,d.remark
                                    ,a.terima_nota_by,a.terima_nota_date,a.tanggal_nota
                                FROM
	                                PSGRMP..tblPancangReq_TransaksiItemDetail AS a LEFT OUTER JOIN
                                    PSGRMP..tblPancangReq_TransaksiItemHeader AS b ON a.header_id = b.header_id LEFT OUTER JOIN
	                                PSGRMP..tblPancangReq_MasterKategori AS c ON a.kategori_id = c.id LEFT OUTER JOIN
                                    PSGRMP..tblPancangReq_MasterCatatan AS d ON a.catatan_id = d.id LEFT OUTER JOIN
                                    PSGRMP..tblPancangReq_MasterPenggunaan AS e ON d.penggunaan_id = e.id inner join
	                                [192.168.12.5].[RMPApp].[dbo].[Android_tblMstPancang] as f on b.pancang_id=f.IDPancang inner join 
	                                [192.168.12.5].[RMPApp].[dbo].[PancangRequestUser] as g on a.created_by=g.DetailID
                                where 
	                                isnull(a.deleted,0)=0 
                                    and isnull(b.deleted,0)=0 
                                    " & IIf(rdTgl.Checked = True, " and cast(a.created_date as date) between cast('" & Format(dtpCreate1.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(dtpCreate2.Value, "yyyy-MM-dd") & "' as date) ", "") & "
                                    " & IIf(chkTglNota.Checked = True, " and cast(a.tanggal_nota as date) between cast('" & Format(Dtp1.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(Dtp2.Value, "yyyy-MM-dd") & "' as date) ", "") & "
                                    " & IIf(chkTglTerima.Checked = True, " and cast(a.terima_nota_date as date) between cast('" & Format(dtpTerima.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(dtpTerima2.Value, "yyyy-MM-dd") & "' as date) ", "") & "
                                    and e.nama_penggunaan = '" & pembelian & "' 
                                    " & IIf(rdBelumPrint.Checked = True, " and (a.flag_sudah_print=0 or a.flag_sudah_print is null) ", "") & "
                                    " & IIf(rdSudahPrint.Checked = True, " and a.flag_sudah_print=1 ", "") & "
                                    " & IIf(CmbPancang.Text = "", "", " and b.pancang_id='" & CmbPancang.SelectedValue & "' ") & " 
                                    " & IIf(TxtItem.Text = "", "", " and a.nama_item like '%" & TxtItem.Text & "%' ") & "
                                    " & IIf(CmbKategori.Text = "", "", " and c.id='" & CmbKategori.SelectedValue & "' ") & " 
                                "

        dt = DB.ExecuteQuery(StrConnPSGRMP, query)

        FG.Rows.Count = 1
        If dt.Rows.Count > 0 Then
            Call HeaderFg()
            ChkAll.Checked = True

            With FG
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, 1) = True
                    .Item(i, 2) = row.Item("Pancang")
                    .Item(i, 3) = row.Item("kode_trans")
                    .Item(i, 4) = row.Item("nama_item")
                    .Item(i, 5) = row.Item("harga_sub")
                    .Item(i, 6) = row.Item("qty")
                    .Item(i, 7) = row.Item("harga")
                    .Item(i, 8) = row.Item("kategori_item")
                    .Item(i, 9) = row.Item("nama_kategori")

                    Dim style As C1.Win.C1FlexGrid.CellStyle = Me.FG.Styles.Add("style")
                    style.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
                    Me.FG.SetCellImage(i, 12, My.Resources.photo)
                    Me.FG.SetCellStyle(i, 12, style)
                    Me.FG.SetCellImage(i, 13, My.Resources.photo)
                    Me.FG.SetCellStyle(i, 13, style)

                    Dim style3 As C1.Win.C1FlexGrid.CellStyle = Me.FG.Styles.Add("style")
                    style3.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
                    Me.FG.SetCellImage(i, 14, My.Resources.ButtonEdit_16px)
                    Me.FG.SetCellStyle(i, 14, style3)

                    .Item(i, 15) = row.Item("created_by")
                    .Item(i, 16) = row.Item("created_date")
                    .Item(i, 17) = row.Item("updated_by")
                    .Item(i, 18) = row.Item("updated_date")
                    .Item(i, 19) = row.Item("deleted_by")
                    .Item(i, 20) = row.Item("deleted_date")
                    .Item(i, 21) = row.Item("foto_item")
                    .Item(i, 22) = row.Item("foto_trans")
                    .Item(i, 23) = row.Item("catatanBarang")
                    .Item(i, 24) = row.Item("catatanNota")
                    .Item(i, 25) = row.Item("detaild_id")
                    .Item(i, 26) = row.Item("remark")
                    .Item(i, 27) = row.Item("terima_nota_by")
                    .Item(i, 28) = row.Item("terima_nota_date")
                    .Item(i, 29) = row.Item("tanggal_nota")

                    Dim style2 As C1.Win.C1FlexGrid.CellStyle = Me.FG.Styles.Add("style")
                    style2.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
                    If .Item(i, 23) <> "" Then
                        Me.FG.SetCellImage(i, 10, My.Resources.list20px)
                        Me.FG.SetCellStyle(i, 10, style2)
                    End If
                    If .Item(i, 24) <> "" Then
                        Me.FG.SetCellImage(i, 11, My.Resources.list20px)
                        Me.FG.SetCellStyle(i, 11, style2)
                    End If

                    i += 1
                Next

                'buat total akhir
                Dim total As Int64
                For j = 1 To .Rows.Count - 1
                    total += .Item(j, 7)
                Next
                .AddItem(i)
                .Item(i, 0) = ""
                .Item(i, 7) = total

                .AutoSizeCols()
            End With
        Else
            If TxtItem.Text = "" Then
                MsgBox("Data Tidak Ada !", vbInformation, AT)
            End If
        End If
    End Sub

    Private Sub BtnExcel_Click(sender As Object, e As EventArgs) Handles BtnExcel.Click
        Try
            Dim filename As String
            Me.SaveFileDialog1.ShowDialog()
            filename = SaveFileDialog1.FileName
            Me.FG.SaveExcel(filename & ".xls", "Sheet1", FileFlags.IncludeFixedCells)
            MsgBox("Convert Success !", MsgBoxStyle.Information, AT)
        Catch ex As Exception
            MsgBox("Convert Gagal !", vbInformation, ex)
        End Try
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub FG_Click(sender As Object, e As EventArgs) Handles FG.Click
        If FG.Rows.Count > 1 Then
            With FG
                Dim form1 As Form = Application.OpenForms.OfType(Of FrmRptFoto)().FirstOrDefault()

                If form1 IsNot Nothing Then
                    form1.Close()
                End If

                If .Col = 10 Then
                    If FG.Item(.RowSel, 23) <> "" Then
                        MsgBox(FG.Item(.RowSel, 23), vbInformation, "Catatan Barang")
                    End If
                ElseIf .Col = 11 Then
                    If FG.Item(.RowSel, 24) <> "" Then
                        MsgBox(FG.Item(.RowSel, 24), vbInformation, "Catatan Nota")
                    End If
                ElseIf .Col = 12 Then
                    FrmRptFoto.Foto = .Item(.RowSel, 21)
                    FrmRptFoto.Show()
                ElseIf .Col = 13 Then
                    FrmRptFoto.Foto = .Item(.RowSel, 22)
                    FrmRptFoto.Show()
                ElseIf .Col = 14 Then

                    With FrmTrnEditDataPembelianBarangPancangCash
                        .rdpan = False
                        .rdpur = False
                        .rdpul = False
                        If RdPancang.Checked = True Then
                            .rdpan = True
                        ElseIf RdPurchaser.Checked = True Then
                            .rdpur = True
                        ElseIf rdPulsa.Checked = True Then
                            .rdpul = True
                        End If
                        .Catatan = FG.Item(FG.RowSel, 26)
                        .Kategori = FG.Item(FG.RowSel, 9)
                        .TxtNamaItem.Text = FG.Item(FG.RowSel, 4)
                        .TxtQty.Text = FG.Item(FG.RowSel, 6)
                        .TxtHarga.Text = CInt(FG.Item(FG.RowSel, 5))
                        .TxtTotal.Text = CInt(FG.Item(FG.RowSel, 7))
                        If FG.Item(FG.RowSel, 8) = "Operasional" Then
                            .RdOper.Checked = True
                        Else
                            .RdInv.Checked = True
                        End If
                        .ChkNonActive.Checked = False
                        .TxtDetailId.Text = FG.Item(FG.RowSel, 25)
                        .tgl.Value = FG.Item(FG.RowSel, 29)
                        .ShowDialog()
                    End With
                ElseIf .Col = 1 Then
                    Dim FlagTrueAll As Integer = 1
                    For i = 1 To FG.Rows.Count - 1
                        If .Item(i, 1) = False Then
                            FlagTrueAll = 0
                        End If
                    Next
                    If FlagTrueAll = 1 Then
                        ChkAll.Checked = True
                    Else
                        ChkAll.Checked = False
                    End If
                End If
            End With
        End If
    End Sub

    Private Sub ChkAll_Click(sender As Object, e As EventArgs) Handles ChkAll.Click
        If FG.Rows.Count > 1 Then
            If ChkAll.Checked = True Then
                For i = 1 To FG.Rows.Count - 1
                    FG.Item(i, 1) = True
                Next
            Else
                For i = 1 To FG.Rows.Count - 1
                    FG.Item(i, 1) = False
                Next
            End If
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        If FG.Rows.Count > 1 Then
            Dim GetId As String = "a.detaild_id in ("
            Dim GetId_ As String = "detaild_id in ("
            For i = 1 To FG.Rows.Count - 1
                If FG.Item(i, 1) = True Then
                    GetId &= "" & FG.Item(i, 25) & ","
                    GetId_ &= "" & FG.Item(i, 25) & ","
                End If
            Next
            GetId = GetId.Substring(0, Len(GetId) - 1) & ")"
            GetId_ = GetId_.Substring(0, Len(GetId_) - 1) & ")"

            With FrmRptPembelianBarangCashPancangFromMon
                .Pulsa = rdPulsa.Checked
                .Purchaser = RdPurchaser.Checked
                .Pancang = RdPancang.Checked
                If rdTrip1.Checked = True Then
                    .trip = 1
                Else
                    .trip = 2
                End If
                .IdPancang = IIf(CmbPancang.SelectedValue = -1, CmbPancang.SelectedValue, "")
                .detail_id = GetId
                .detail_id_ = GetId_
                .ModelReport = 1
                .Show()
            End With
        End If
    End Sub

    Private Sub btnKalkulasiData_Click(sender As Object, e As EventArgs) Handles btnKalkulasiData.Click
        Call ShowDataKalkulasi()
    End Sub

    Private Sub ShowDataKalkulasi()
        Dim dt As DataTable = New DataTable
        Dim i As Integer = 1
        Dim pembelian As String = ""
        Dim statusPrint As String = ""

        If RdPancang.Checked = True Then
            pembelian = "Pancang"
        ElseIf RdPurchaser.Checked = True Then
            pembelian = "Purchaser"
        ElseIf rdPulsa.Checked = True Then
            pembelian = "Listrik / Internet"
        End If

        dt = DB.ExecuteQuery(StrConnPSGRMP, " SELECT 
	                                                                f.Pancang,c.nama_kategori,cast((sum(a.harga)/sum(a.qty)) as decimal(18,2)) as harga,sum(a.qty) as qty,cast(sum(a.harga) as decimal(18,0)) as total_harga
                                                                FROM
	                                                                PSGRMP..tblPancangReq_TransaksiItemDetail AS a LEFT OUTER JOIN
                                                                    PSGRMP..tblPancangReq_TransaksiItemHeader AS b ON a.header_id = b.header_id LEFT OUTER JOIN
	                                                                PSGRMP..tblPancangReq_MasterKategori AS c ON a.kategori_id = c.id LEFT OUTER JOIN
                                                                    PSGRMP..tblPancangReq_MasterCatatan AS d ON a.catatan_id = d.id LEFT OUTER JOIN
                                                                    PSGRMP..tblPancangReq_MasterPenggunaan AS e ON d.penggunaan_id = e.id inner join
	                                                                [192.168.12.5].[RMPApp].[dbo].[Android_tblMstPancang] as f on b.pancang_id=f.IDPancang inner join 
	                                                                [192.168.12.5].[RMPApp].[dbo].[PancangRequestUser] as g on a.created_by=g.DetailID
                                                                where 
	                                                            a.deleted=0 and
	                                                            a.deleted is not null and
	                                                            b.deleted=0 and
	                                                            b.deleted is not null and
                                                                e.nama_penggunaan = '" & pembelian & "'   
                                                                " & IIf(rdTgl.Checked = True, " and cast(a.created_date as date) between cast('" & Format(dtpCreate1.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(dtpCreate2.Value, "yyyy-MM-dd") & "' as date) ", "") & "
                                                                " & IIf(chkTglNota.Checked = True, " and cast(a.tanggal_nota as date) between cast('" & Format(Dtp1.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(Dtp2.Value, "yyyy-MM-dd") & "' as date) ", "") & "
                                                                " & IIf(chkTglTerima.Checked = True, " and cast(a.terima_nota_date as date) between cast('" & Format(dtpTerima.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(dtpTerima2.Value, "yyyy-MM-dd") & "' as date) ", "") & "
                                                                " & IIf(rdBelumPrint.Checked = True, " and (a.flag_sudah_print=0 or a.flag_sudah_print is null) ", "") & "
                                                                " & IIf(rdSudahPrint.Checked = True, " and a.flag_sudah_print=1 ", "") & "
                                                                " & IIf(CmbPancang.Text = "", "", " and b.pancang_id='" & CmbPancang.SelectedValue & "' ") & " 
                                                                " & IIf(TxtItem.Text = "", "", " and a.nama_item like '%" & TxtItem.Text & "%' ") & "
                                                                " & IIf(CmbKategori.Text = "", "", " and c.id='" & CmbKategori.SelectedValue & "' ") & " 
                                                                group by f.Pancang,c.nama_kategori
	                                                            order by f.pancang asc ")

        FG.Rows.Count = 1
        If dt.Rows.Count > 0 Then
            Call HeaderFgKalkulasi()
            ChkAll.Checked = True

            With FG
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, 1) = True
                    .Item(i, 2) = row.Item("Pancang")
                    .Item(i, 3) = row.Item("nama_kategori")
                    .Item(i, 4) = row.Item("harga")
                    .Item(i, 5) = row.Item("qty")
                    .Item(i, 6) = row.Item("total_harga")

                    i += 1
                Next

                .AutoSizeCols()
            End With
        Else
            If TxtItem.Text = "" Then
                MsgBox("Data Tidak Ada !", vbInformation, AT)
            End If
        End If
    End Sub

    Private Sub btnPrint2_Click(sender As Object, e As EventArgs) Handles btnPrint2.Click
        If FG.Rows.Count > 1 Then
            Dim GetId As String = "a.detaild_id in ("
            Dim GetId_ As String = "detaild_id in ("
            For i = 1 To FG.Rows.Count - 1
                If FG.Item(i, 1) = True Then
                    GetId &= "" & FG.Item(i, 25) & ","
                    GetId_ &= "" & FG.Item(i, 25) & ","
                End If
            Next
            GetId = GetId.Substring(0, Len(GetId) - 1) & ")"
            GetId_ = GetId_.Substring(0, Len(GetId_) - 1) & ")"

            With FrmRptPembelianBarangCashPancangFromMon
                .Pulsa = rdPulsa.Checked
                .Purchaser = RdPurchaser.Checked
                .Pancang = RdPancang.Checked
                If rdTrip1.Checked = True Then
                    .trip = 1
                Else
                    .trip = 2
                End If
                .IdPancang = IIf(CmbPancang.SelectedValue = -1, CmbPancang.SelectedValue, "")
                .detail_id = GetId
                .detail_id_ = GetId_
                .ModelReport = 2
                .Show()
            End With
        End If
    End Sub
End Class
