Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Controls.Primitives
Imports AxAcroPDFLib
Imports C1.Win.C1FlexGrid
Imports Syncfusion.Pdf

Public Class FrmTrnApproval1DanInputBarangPengajuanWoPancang
    Public openFormBy As String
    Dim aksi As String = ""
    Dim namaFilePenawaranHargaDariDatabase As String
    Dim namaFileSpkDariDatabase As String
    Dim namaFileProposalDariDatabase As String
    Private Sub FrmTrnApproval1DanInputBarangPengajuanWoPancang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If openFormBy = "EstimasiBiaya" Or openFormBy = "BarangRequest" Then
            lblJudulForm.Text = "Estimasi Biaya"
            Panel3.Height = 865
        ElseIf openFormBy = "Proyek" Then
            lblJudulForm.Text = "Proyek"
            Panel3.Height = 968
        ElseIf openFormBy = "Spk" Then
            lblJudulForm.Text = "Input SPK"
            Panel3.Height = 1225
        End If

        Call headerFgFoto()
        Call headerFglistBarang()
        Call headerFglistPilih()

        Call kondisiAwal()

        Call setCmbJenisWo()
        Call setCmbPrioritas()

        Modul_RMP.Combo.setKontraktor(cmbKontraktor)
        Modul_RMP.Combo.setSubKontraktor(cmbSubKontraktor)
    End Sub

    Private Sub setCmbJenisWo()
        Dim dt As DataTable = New DataTable()

        dt.Columns.Add("id")
        dt.Columns.Add("jenisWo")

        Dim newRow As DataRow = dt.NewRow()
        newRow("id") = 1
        newRow("jenisWo") = "Proyek"
        dt.Rows.Add(newRow)

        newRow = dt.NewRow()
        newRow("id") = 2
        newRow("jenisWo") = "Relokasi Baru"
        dt.Rows.Add(newRow)

        newRow = dt.NewRow()
        newRow("id") = 3
        newRow("jenisWo") = "Perbaikan"
        dt.Rows.Add(newRow)

        With cmbJenisWo
            .DataSource = dt
            .DisplayMember = "jenisWo"
            .ValueMember = "id"
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub setCmbPrioritas()
        Dim dt As DataTable = New DataTable()

        dt.Columns.Add("id")
        dt.Columns.Add("Prioritas")

        Dim newRow As DataRow = dt.NewRow()
        newRow("id") = 1
        newRow("Prioritas") = "Prioritas 1"
        dt.Rows.Add(newRow)

        newRow = dt.NewRow()
        newRow("id") = 2
        newRow("Prioritas") = "Prioritas 2"
        dt.Rows.Add(newRow)

        newRow = dt.NewRow()
        newRow("id") = 3
        newRow("Prioritas") = "Prioritas 3"
        dt.Rows.Add(newRow)

        With cmbPrioritas
            .DataSource = dt
            .DisplayMember = "Prioritas"
            .ValueMember = "id"
            .SelectedIndex = -1
        End With
    End Sub

    Public Sub kondisiAwal()
        aksi = ""

        txtId.Text = "0"
        txtIdPancang.Clear()
        txtPancang.Clear()
        txtJudul.Clear()
        txtDeskripsi.Clear()
        cmbJenisWo.SelectedValue = -1
        cmbPrioritas.SelectedValue = -1
        txtDiAjukan.Clear()
        dtpPengajuan.Value = Now
        txtKetReject.Clear()
        txtKetReject.Enabled = False

        cmbJenisWo.Enabled = False
        cmbPrioritas.Enabled = False

        fgFoto.Rows.Count = 1

        btnFind.Enabled = True
        BtnApproval.Enabled = False
        btnReject.Enabled = False
        BtnEdit.Enabled = False
        btnSave.Enabled = False
        btnCancel.Enabled = False

        txtCari.Enabled = False
        btnCari.Enabled = False

        Select Case openFormBy
            Case "EstimasiBiaya"
                fgListBarang.Rows.Count = 1

                fgListPilih.Enabled = False
                fgListPilih.Rows.Count = 1
            Case "Proyek"
                BtnApproval.Visible = False
                btnReject.Visible = False

                fgListBarang.Rows.Count = 1

                fgListPilih.Enabled = False
                fgListPilih.Rows.Count = 1

                btnUploadFileDesain.Enabled = False
                lblFileDesain.Text = "No File"
                picFileDesain.BackgroundImage = My.Resources.no_image
                btnSaveFileDesain.Enabled = False

                rdBukanMandiri.Enabled = False
                rdMandiri.Enabled = False
                cmbKontraktor.Enabled = False
                cmbKontraktor.SelectedValue = -1
                cmbSubKontraktor.Enabled = False
                cmbSubKontraktor.SelectedValue = -1
                btnPdfPenawaranHarga.Enabled = False
                lblPathFile.Text = "No File"
                picPdf.BackgroundImage = My.Resources.no_image
                btnSaveFilePenawaran.Enabled = False
            Case "Spk"
                BtnApproval.Visible = False
                btnReject.Visible = False

                fgListBarang.Rows.Count = 1

                fgListPilih.Enabled = False
                fgListPilih.Rows.Count = 1

                btnUploadFileDesain.Enabled = False
                lblFileDesain.Text = "No File"
                picFileDesain.BackgroundImage = My.Resources.no_image
                btnSaveFileDesain.Enabled = False

                rdBukanMandiri.Enabled = False
                rdMandiri.Enabled = False
                cmbKontraktor.Enabled = False
                cmbKontraktor.SelectedValue = -1
                cmbSubKontraktor.Enabled = False
                cmbSubKontraktor.SelectedValue = -1
                btnPdfPenawaranHarga.Enabled = False
                lblPathFile.Text = "No File"
                picPdf.BackgroundImage = My.Resources.no_image
                btnSaveFilePenawaran.Enabled = False

                lblFileSpk.Text = "No File"
                picSpk.BackgroundImage = My.Resources.no_image
                lblFileProposal.Text = "No File"
                picProposal.BackgroundImage = My.Resources.no_image
                btnPdfSpk.Enabled = False
                btnPdfProposal.Enabled = False
                txtHargaProyek.Clear()
                txtHargaProyek.Enabled = False

                btnSaveSpk.Enabled = False
        End Select
    End Sub

    Public Sub loadFgFoto()
        Dim dt As DataTable = New DataTable
        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " select foto_wo from RMPApp..tbl_wo_trn_foto_wo where wo_id=" & txtId.Text)

        Dim i As Integer = 1
        fgFoto.Rows.Count = 1
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                With fgFoto
                    .AddItem(i)
                    fgFoto.Rows(i).Height = 100
                    fgFoto.Cols(1).Width = 170
                    Try
                        If System.IO.File.Exists(UrlNotaPancang & "ImagesWorkOrder\" & row("foto_wo")) Then
                            fgFoto.SetCellImage(i, "Foto", Image.FromFile(UrlNotaPancang & "ImagesWorkOrder\" & row("foto_wo")))
                        Else
                            .Item(i, "Foto") = "Error !"
                        End If
                    Catch ex As Exception
                    End Try
                    .Item(i, 2) = row("foto_wo")
                    i += 1
                End With
            Next
            fgFoto.Styles.Normal.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.Stretch
            fgFoto.Styles.Normal.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
        End If
    End Sub

    Private Sub headerFgFoto()
        Dim txt As CellRange

        With fgFoto
            .Rows.Fixed = 1
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Cols.Count = 3

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
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Foto" : .Cols(1).Name = "Foto" : .Cols(1).TextAlign = TextAlignEnum.LeftCenter : .Cols(1).AllowEditing = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Nama" : .Cols(2).Visible = False

            .AutoSizeCols()
        End With
    End Sub
    Private Sub headerFglistBarang()
        Dim txt As CellRange

        With fgListBarang
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
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Pilih" : .Cols(1).TextAlign = TextAlignEnum.LeftCenter : .Cols(1).AllowEditing = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Item Id" : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).AllowEditing = False
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Nama Item" : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).AllowEditing = False
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Satuan" : .Cols(4).TextAlign = TextAlignEnum.LeftCenter : .Cols(4).AllowEditing = False
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Harga" : .Cols(5).TextAlign = TextAlignEnum.RightCenter : .Cols(5).AllowEditing = False : .Cols(5).Format = "#,###0"
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Asal Barang" : .Cols(6).TextAlign = TextAlignEnum.RightCenter : .Cols(6).AllowEditing = False

            .AutoSizeCols()
        End With
    End Sub
    Private Sub headerFglistPilih()
        Dim txt As CellRange

        With fgListPilih
            .Rows.Fixed = 1
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Cols.Count = 16

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
            .AllowSorting = False
            .AllowResizing = False

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).TextAlign = TextAlignEnum.LeftCenter : .Cols(0).AllowEditing = False
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Item Id" : .Cols(1).TextAlign = TextAlignEnum.LeftCenter : .Cols(1).AllowEditing = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Nama Item" : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).AllowEditing = False
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Satuan" : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).AllowEditing = False
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Asal Barang" : .Cols(4).TextAlign = TextAlignEnum.LeftCenter : .Cols(4).AllowEditing = False
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Harga" : .Cols(5).TextAlign = TextAlignEnum.RightCenter : .Cols(5).AllowEditing = True : .Cols(5).Format = "#,###0"
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Qty" : .Cols(6).TextAlign = TextAlignEnum.LeftCenter : .Cols(6).AllowEditing = False
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Qty" : .Cols(7).TextAlign = TextAlignEnum.CenterCenter : .Cols(7).AllowEditing = True
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Qty" : .Cols(8).TextAlign = TextAlignEnum.LeftCenter : .Cols(8).AllowEditing = False
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Total" : .Cols(9).TextAlign = TextAlignEnum.RightCenter : .Cols(9).AllowEditing = False : .Cols(9).Format = "#,###0"
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "Hitung %" : .Cols(10).TextAlign = TextAlignEnum.LeftCenter : .Cols(10).AllowEditing = True
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "Hapus" : .Cols(11).TextAlign = TextAlignEnum.LeftCenter : .Cols(11).AllowEditing = False
            txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "Request" : .Cols(12).TextAlign = TextAlignEnum.LeftCenter : .Cols(12).AllowEditing = False
            txt = .GetCellRange(0, 13, 0, 13) : txt.Data = "persen_request" : .Cols(13).Visible = False
            txt = .GetCellRange(0, 14, 0, 14) : txt.Data = "akum_persen_request" : .Cols(14).Visible = False
            txt = .GetCellRange(0, 15, 0, 15) : txt.Data = "Sudah Request" : .Cols(15).Visible = False

            .AutoSizeCols()
        End With
    End Sub

    Private Sub fgListPilih_Click(sender As Object, e As EventArgs) Handles fgListPilih.Click
        With fgListPilih
            If .Rows.Count > 1 And .RowSel <> .Rows.Count - 1 Then
                If .Col = 6 Then
                    If .Item(.RowSel, 7) - 1 <> 0 Then
                        .Item(.RowSel, 7) = .Item(.RowSel, 7) - 1
                        .Item(.RowSel, 9) = .Item(.RowSel, 5) * .Item(.RowSel, 7)
                        hitungTotalDanSetNomor()
                    End If
                ElseIf .Col = 8 Then
                    .Item(.RowSel, 7) = .Item(.RowSel, 7) + 1
                    .Item(.RowSel, 9) = .Item(.RowSel, 5) * .Item(.RowSel, 7)
                    hitungTotalDanSetNomor()
                ElseIf .Col = 11 Then
                    .Rows.Remove(.RowSel)
                    If .Rows.Count <= 2 Then
                        .Rows.Remove(.Rows.Count - 1)
                    Else
                        hitungTotalDanSetNomor()
                    End If
                ElseIf .Col = 12 Then
                    Dim flagBarangSudahDiKirim As String = ""
                    flagBarangSudahDiKirim = DB.ExecuteScalarValue(Of String)(StrConnRMPApp," SELECT 'ada' as GetValueString FROM tbl_wo_trn_approval_barang where notactive=0 and deleted=0 and flag=1 and trn_barang_id=(select id from tbl_wo_trn_barang where kode_barang=" & .Item(.RowSel, 1) & " and wo_id=" & txtId.Text & ") ")
                    If flagBarangSudahDiKirim = "ada" Then
                        MsgBox("Barang " & .Item(.RowSel, 2) & ",Sudah Di Kirim !", vbInformation, AT)
                        .Item(.RowSel, 12) = True
                    End If

                    Dim sum_qty As Integer = 0
                    For i = 1 To .Rows.Count - 2
                        sum_qty += .Item(i, 7)
                    Next

                    Dim qty As Integer
                    Dim percentage As Decimal
                    For j = 1 To .Rows.Count - 2
                        qty = IIf(.Item(j, 12) = True, .Item(j, 7), 0)
                        percentage = (qty / sum_qty) * 100
                        .Item(j, 13) = CInt(percentage)
                        If j > 1 Then
                            .Item(j, 14) = CInt(percentage) + .Item(j - 1, 14)
                        Else
                            .Item(j, 14) = CInt(percentage)
                        End If
                        If j = .Rows.Count - 2 And .Item(j, 13) <> 0 And .Item(j, 14) <> 100 Then 'baris terakhir,persen nya ada,akum persen bukan 100 
                            .Item(j, 14) = 100
                        End If
                    Next
                    For k = 1 To .Rows.Count - 2
                        If .Item(k, 13) = 0 Then
                            .Item(k, 14) = 0
                        End If
                    Next
                End If
                .AutoSizeCols()
                .Cols(7).Width = 50
            End If
        End With
    End Sub

    Private Sub fgFoto_Click(sender As Object, e As EventArgs) Handles fgFoto.Click
        If fgFoto.Rows.Count > 1 Then
            If Application.OpenForms.OfType(Of FrmRptViewFoto)().Any() Then
                Dim FrmViewFoto As FrmRptViewFoto = Application.OpenForms.OfType(Of FrmRptViewFoto)().FirstOrDefault()
                FrmViewFoto.Close()
            End If

            With FrmRptViewFoto
                .formName = "FrmTrnApproval1DanInputBarangPengajuanWoPancang"
                .FileName = fgFoto.Item(fgFoto.RowSel, 2)
                .Show()
            End With
        End If
    End Sub

    Private Sub loadItemBarang()
        Dim dt As DataTable = New DataTable
        dt = SqlSelect_VBDSERVER_RSUPDB(" with data_ as (
                                          SELECT a.ItemID as kode_barang,a.ItemName as nama_barang,a.UOMName as satuan_barang,convert(decimal(18,2),isnull(b.UnitPrice,0)) as harga_barang,'RSUP' as asal_barang
                                          FROM vwItem A left outer JOIN tblMstItemNew B ON A.ItemID=B.ItemID
                                          WHERE A.InActive=0 
                                          union
                                          SELECT a.ItemID as kode_barang,a.ItemName as nama_barang,a.UOMName as satuan_barang,convert(decimal(18,2),isnull(b.UnitPrice,0)) as harga_barang,'PSG' as asal_barang
                                          FROM [192.168.2.3].[MYPSG].[dbo].[vwItem] A left outer JOIN [192.168.2.3].[MYPSG].[dbo].[tblMstItemNew] B ON A.ItemID=B.ItemID
                                          WHERE A.InActive=0 )
                                          select * from data_ where nama_barang LIKE '%" & txtCari.Text & "%' order by nama_barang asc ")

        fgListBarang.Rows.Count = 1
        Dim i As Integer = 1
        If dt.Rows.Count > 0 Then
            With fgListBarang
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    Dim style As C1.Win.C1FlexGrid.CellStyle = .Styles.Add("style")
                    style.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
                    .SetCellImage(i, 1, My.Resources.ButtonTambah)
                    .SetCellStyle(i, 1, style)
                    .Item(i, 2) = row("kode_barang")
                    .Item(i, 3) = row("nama_barang")
                    .Item(i, 4) = row("satuan_barang")
                    .Item(i, 5) = row("harga_barang")
                    .Item(i, 6) = row("asal_barang")
                    i += 1
                Next
                .AutoSizeCols()
            End With
        Else
            MsgBox("Data Tidak Di Temukan !", vbInformation, AT)
        End If
    End Sub

    Private Function SqlSelect_VBDSERVER_RSUPDB(ByVal sqla As String, Optional params As SqlParameter() = Nothing) As DataTable
        Dim dt As DataTable = New DataTable()
        Using cn As SqlConnection = New SqlConnection("Data Source=192.168.12.5;Initial Catalog=RSUPDB;Persist Security Info=True;User ID=uKoneksi; pooling=false; password=sm@rt2018; Max Pool Size=100000;Connection Timeout=50; ")
            Using cmd As SqlCommand = New SqlCommand(sqla, cn)
                cmd.CommandTimeout = 600
                If Not params Is Nothing Then
                    cmd.Parameters.AddRange(params)
                End If
                Try
                    cn.Open()
                    dt.Load(cmd.ExecuteReader)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        Return dt
    End Function

    Private Sub fgListBarang_Click(sender As Object, e As EventArgs) Handles fgListBarang.Click
        With fgListBarang
            If .Rows.Count > 1 Then
                If .Col = 1 Then
                    'jika barang sudah di pilih tak perlu di tambangkan lagi
                    Dim sudahAda As Boolean = 0
                    For i = 1 To fgListPilih.Rows.Count - 1
                        If fgListPilih.Item(i, 1) = .Item(.RowSel, 2) Then
                            sudahAda = 1
                        End If
                    Next
                    If sudahAda = True Then
                        MsgBox("Item Ini Sudah Ada Di List !", vbInformation, AT)
                        Exit Sub
                    End If

                    'jika sudah ada barang yang di pilih hapus dulu total nya
                    If fgListPilih.Rows.Count >= 3 Then
                        fgListPilih.Rows.Remove(fgListPilih.Rows.Count - 1)
                    End If

                    Dim barisBaru As Integer = fgListPilih.Rows.Count + 1
                    fgListPilih.Rows.Count = barisBaru
                    barisBaru -= 1

                    fgListPilih.Item(barisBaru, 1) = fgListBarang.Item(.RowSel, 2)
                    fgListPilih.Item(barisBaru, 2) = fgListBarang.Item(.RowSel, 3)
                    fgListPilih.Item(barisBaru, 3) = fgListBarang.Item(.RowSel, 4)
                    fgListPilih.Item(barisBaru, 4) = fgListBarang.Item(.RowSel, 6)
                    fgListPilih.Item(barisBaru, 5) = fgListBarang.Item(.RowSel, 5)
                    Dim style As C1.Win.C1FlexGrid.CellStyle = .Styles.Add("style")
                    style.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
                    fgListPilih.SetCellImage(barisBaru, 6, My.Resources.TombolKurang)
                    fgListPilih.SetCellStyle(barisBaru, 6, style)
                    fgListPilih.Item(barisBaru, 7) = 1
                    Dim style1 As C1.Win.C1FlexGrid.CellStyle = .Styles.Add("style")
                    style1.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
                    fgListPilih.SetCellImage(barisBaru, 8, My.Resources.TombolTambah)
                    fgListPilih.SetCellStyle(barisBaru, 8, style1)
                    fgListPilih.Item(barisBaru, 9) = .Item(.RowSel, 5)
                    fgListPilih.Item(barisBaru, 10) = False
                    Dim style2 As C1.Win.C1FlexGrid.CellStyle = .Styles.Add("style")
                    style2.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
                    fgListPilih.SetCellImage(barisBaru, 11, My.Resources.ButtonHapus)
                    fgListPilih.SetCellStyle(barisBaru, 11, style2)

                    'buat total list barang
                    Dim barisBaru2 As Integer = fgListPilih.Rows.Count + 1
                    fgListPilih.Rows.Count = barisBaru2
                    barisBaru2 -= 1

                    hitungTotalDanSetNomor()
                End If
            End If
        End With
    End Sub

    Private Sub hitungTotalDanSetNomor()
        With fgListPilih
            Dim total As Int64 = 0
            For i = 1 To .Rows.Count - 2
                total += .Item(i, 9)
            Next
            .Item(.Rows.Count - 1, 9) = total
            .AutoSizeCols()

            For i = 1 To fgListPilih.Rows.Count - 2
                .Item(i, 0) = i
            Next
        End With
    End Sub

    Private Sub BtnApproval_Click(sender As Object, e As EventArgs) Handles BtnApproval.Click
        aksi = "Approval"

        txtJudul.Enabled = True
        cmbJenisWo.Enabled = True
        cmbPrioritas.Enabled = True

        btnFind.Enabled = False
        BtnApproval.Enabled = False
        btnReject.Enabled = False
        BtnEdit.Enabled = False
        btnSave.Enabled = True
        btnCancel.Enabled = True

        txtCari.Enabled = True
        btnCari.Enabled = True

        fgListPilih.Enabled = True
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        With FrmTrnApproval1DanInputBarangPengajuanWoPancangFind
            If openFormBy = "EstimasiBiaya" Then
                .TabControl.SelectedTab = .TabPage1
                .rdAllEB.Checked = True
            ElseIf openFormBy = "Proyek" Then
                .TabControl.SelectedTab = .TabPage2
                .rdAllP.Checked = True
            ElseIf openFormBy = "Spk" Then
                .TabControl.SelectedTab = .TabPage3
                .rdAllSpk.Checked = True
            ElseIf openFormBy = "BarangRequest" Then
                .TabControl.SelectedTab = .TabPage7
                .rdAllBarangRequest.Checked = True
            End If

            .openFormBy = openFormBy
            .loadData()
            .ShowDialog()
        End With
    End Sub

    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        aksi = "Reject"

        txtKetReject.Enabled = True

        btnFind.Enabled = False
        BtnApproval.Enabled = False
        btnReject.Enabled = False
        BtnEdit.Enabled = False
        btnSave.Enabled = True
        btnCancel.Enabled = True
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        aksi = "Edit"

        Select Case openFormBy
            Case "EstimasiBiaya"
                txtJudul.Enabled = True
                cmbJenisWo.Enabled = True
                cmbPrioritas.Enabled = True

                btnFind.Enabled = False
                BtnEdit.Enabled = False
                btnSave.Enabled = True
                btnCancel.Enabled = True

                txtCari.Enabled = True
                btnCari.Enabled = True

                fgListPilih.Cols(6).Visible = True
                fgListPilih.Cols(8).Visible = True
                fgListPilih.Cols(11).Visible = True
                fgListPilih.Cols(5).AllowEditing = True
                fgListPilih.Cols(7).AllowEditing = True
            Case "Proyek"
                btnFind.Enabled = False
                BtnEdit.Enabled = False
                btnSave.Enabled = True
                btnCancel.Enabled = True

                txtCari.Enabled = True
                btnCari.Enabled = True

                fgListPilih.Enabled = True

                rdMandiri.Enabled = True
                rdBukanMandiri.Enabled = True

                If rdMandiri.Checked = True Then
                    cmbKontraktor.Enabled = False
                    cmbSubKontraktor.Enabled = False
                    btnPdfPenawaranHarga.Enabled = False
                Else
                    cmbKontraktor.Enabled = True
                    cmbSubKontraktor.Enabled = True
                    btnPdfPenawaranHarga.Enabled = True
                End If
            Case "Spk"
                btnFind.Enabled = False
                BtnEdit.Enabled = False
                btnSave.Enabled = True
                btnCancel.Enabled = True

                txtCari.Enabled = True
                btnCari.Enabled = True

                fgListPilih.Enabled = True

                rdMandiri.Enabled = False
                rdBukanMandiri.Enabled = False

                cmbKontraktor.Enabled = False
                cmbSubKontraktor.Enabled = False
                btnPdfPenawaranHarga.Enabled = False

                btnPdfSpk.Enabled = True
                btnPdfProposal.Enabled = True
                txtHargaProyek.Enabled = True
        End Select

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Select Case openFormBy
            Case "EstimasiBiaya"
                Call saveEstimasiBiaya()
            Case "Proyek"
                Call saveProyek()
            Case "Spk"
                Call saveSpk()
            Case "BarangRequest"
                Call saveBarangRequest()
        End Select
    End Sub
    Private Sub saveBarangRequest()
        Me.Cursor = Cursors.WaitCursor

        Dim koneksi As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnRMPApp)
        Dim transaksi As SqlTransaction
        transaksi = koneksi.BeginTransaction

        For i = 1 To fgListPilih.Rows.Count - 2
            If SaveDataBarang(koneksi, transaksi, i) = False Then
                transaksi.Rollback()
                MsgBox("Simpan Data Gagal !", vbExclamation, AT)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
        Next

        transaksi.Commit()

        'notif buat telegram
        With fgListPilih
            Dim barangBelumRequest As String = ""
            Dim barang As String = ""
            For j = 1 To .Rows.Count - 2
                If .Item(j, 15) = False Then
                    barangBelumRequest = "ada"
                End If
                If .Item(j, 12) = True And .Item(j, 15) = False Then
                    If barang = "" Then
                        barang &= .Item(j, 2) & "(" & .Item(j, 7) & ")"
                    Else
                        barang &= "#" & .Item(j, 2) & "(" & .Item(j, 7) & ")"
                    End If
                End If
            Next
            If barangBelumRequest = "ada" And barang <> "" Then
                Dim insertData As String = " EXEC [dbo].[sp_wo_save_trn_notif] " & txtId.Text & ",'Permintaan Barang Oleh Enginner :#" & barang & ".',1," & ClsSession.UserID
                Dim updateData_ As New SqlCommand(insertData, DB.OpenConnection(StrConnRMPApp))
                updateData_.ExecuteNonQuery()
            End If
        End With

        MsgBox("Save Data Berhasil !", vbInformation, AT)

        Call loadListBarang()

        Me.Cursor = Cursors.Default

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub saveSpk()
        Me.Cursor = Cursors.WaitCursor

        If cmbJenisWo.Text = "Proyek" Then
            If Not File.Exists(lblFileProposal.Text) And Not File.Exists(UrlNotaPancang & "DocumentWorkOrder\" & lblFileProposal.Text) Then
                MsgBox("File Proposal Belum Di Upload !", vbInformation, AT)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        If Not File.Exists(lblFileSpk.Text) And Not File.Exists(UrlNotaPancang & "DocumentWorkOrder\" & lblFileSpk.Text) Then
            MsgBox("File Spk Belum Di Upload !", vbInformation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        ElseIf txtHargaProyek.Text = "" Then
            MsgBox("Harga Proyek Belum Di Input !", vbInformation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If File.Exists(lblFileSpk.Text) Then
            Dim query As String = ""
            query = " declare @namaFile varchar(100)
                    select @namaFile=(select 'Spk_'+cast(id as varchar(50))+'_'+cast(format(getdate(),'yyyy-MM-dd HH-mm-ss') as varchar(20))+'.pdf' from tbl_wo_trn_hdr where id=" & txtId.Text & ")
                  
                    update RMPApp..tbl_wo_trn_hdr set file_spk=@namaFile,harga_proyek=" & Replace(txtHargaProyek.Text, ".", "") & " where id=" & txtId.Text & "
                    
                    UPDATE RMPApp..tbl_wo_trn_file_wo set deleted=1,deleted_by='" & ClsSession.UserID & "',deleted_date=getdate() where wo_id=" & txtId.Text & " and deleted=0 and flag=3
                    
                    insert into RMPApp..tbl_wo_trn_file_wo (wo_id,file_name,flag,deskripsi,deleted,created_by,created_date)
                    values (" & txtId.Text & ",@namaFile,3,'Spk',0,'" & ClsSession.UserID & "',getdate())
                    
                    EXEC [dbo].[sp_wo_save_marker] " & txtId.Text & ", 'PROSES 2', '" & ClsSession.UserID.ToUpper & "','PROSES 3 / PROGRESS 1', 'PAYER / ENGINEER'

                    select @namaFile as GetValueString "

            Dim namaFile As String = DB.ExecuteScalarValue(Of String)(StrConnRMPApp,query)

            Try
                Dim lokasiSimpanFile As String = UrlNotaPancang & "DocumentWorkOrder\" & namaFile
                File.Copy(lblFileSpk.Text, lokasiSimpanFile, True)
            Catch ex As Exception
            End Try

            lblFileSpk.Text = namaFile
        Else
            Dim updateData As String = " update RMPApp..tbl_wo_trn_hdr set harga_proyek=" & Replace(txtHargaProyek.Text, ".", "") & " where id=" & txtId.Text & " "
            Dim updateData_ As New SqlCommand(updateData, DB.OpenConnection(StrConnRMPApp))
            updateData_.ExecuteNonQuery()
        End If

        If File.Exists(lblFileProposal.Text) Then
            Dim query As String = ""
            query = " declare @namaFile varchar(100)
                    select @namaFile=(select 'Proposal_'+cast(id as varchar(50))+'_'+cast(format(getdate(),'yyyy-MM-dd HH-mm-ss') as varchar(20))+'.pdf' from tbl_wo_trn_hdr where id=" & txtId.Text & ")
                    update RMPApp..tbl_wo_trn_hdr set file_proposal=@namaFile where id=" & txtId.Text & "
                    UPDATE RMPApp..tbl_wo_trn_file_wo set deleted=1,deleted_by='" & ClsSession.UserID & "',deleted_date=getdate() where wo_id=" & txtId.Text & " and deleted=0 and flag=2
                    insert into RMPApp..tbl_wo_trn_file_wo (wo_id,file_name,flag,deskripsi,deleted,created_by,created_date)
                    values (" & txtId.Text & ",@namaFile,2,'Proposal',0,'" & ClsSession.UserID & "',getdate())
                    select @namaFile as GetValueString "

            Dim namaFile As String = DB.ExecuteScalarValue(Of String)(StrConnRMPApp,query)

            Try
                Dim lokasiSimpanFile2 As String = UrlNotaPancang & "DocumentWorkOrder\" & namaFile
                File.Copy(lblFileProposal.Text, lokasiSimpanFile2, True)
            Catch ex As Exception
            End Try

            lblFileProposal.Text = namaFile
        End If

        MsgBox("Save Data Berhasil !", vbInformation, AT)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub saveEstimasiBiaya()
        Me.Cursor = Cursors.WaitCursor

        If aksi = "Reject" Then
            If txtKetReject.Text = "" Then
                MsgBox("Keterangan Reject Belum Di Input !", vbInformation, AT)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
        ElseIf aksi = "Approval" Or aksi = "Edit" Then
            If fgListPilih.Rows.Count = 1 Then
                MsgBox("Barang Belum Ada Yang Di Pilih !", vbInformation, AT)
                Me.Cursor = Cursors.Default
                Exit Sub
            ElseIf cmbJenisWo.SelectedValue = Nothing Then
                MsgBox("Jenis Wo Belum Di Pilih !", vbInformation, AT)
                Me.Cursor = Cursors.Default
                Exit Sub
            ElseIf cmbPrioritas.SelectedValue = Nothing Then
                MsgBox("Perioritas Belum Di Pilih !", vbInformation, AT)
                Me.Cursor = Cursors.Default
                Exit Sub
            ElseIf txtJudul.Text = "" Then
                MsgBox("Judul Tidak Boleh Kosong !", vbInformation, AT)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        Dim koneksi As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnRMPApp)
        Dim transaksi As SqlTransaction
        transaksi = koneksi.BeginTransaction

        If SaveDataEstimasiBiaya(koneksi, transaksi) = False Then
            transaksi.Rollback()
            MsgBox("Simpan Data Gagal !", vbExclamation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If aksi = "Approval" Or aksi = "Edit" Then
            For i = 1 To fgListPilih.Rows.Count - 2
                If SaveDataBarang(koneksi, transaksi, i) = False Then
                    transaksi.Rollback()
                    MsgBox("Simpan Data Gagal !", vbExclamation, AT)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            Next
        End If

        transaksi.Commit()

        MsgBox("Save Data Berhasil !", vbInformation, AT)
        Call kondisiAwal()
        Me.Cursor = Cursors.Default
    End Sub

    Private Function SaveDataEstimasiBiaya(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        SaveDataEstimasiBiaya = False

        Dim MyCon As SqlConnection = Conn
        Dim MyConTrans As SqlTransaction = Trans
        Dim cmd As New SqlCommand

        With cmd
            .Connection = Conn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RMPApp..spSaveEstimasiBiayaStatusApproval1WoPancang"
            .Transaction = MyConTrans

            .Parameters.Add("@aksi", SqlDbType.VarChar, 50).Value = aksi
            .Parameters.Add("@woId", SqlDbType.Int).Value = CInt(txtId.Text)
            .Parameters.Add("@jenisWo", SqlDbType.Int).Value = cmbJenisWo.SelectedValue
            .Parameters.Add("@prioritas", SqlDbType.Int).Value = IIf(cmbPrioritas.SelectedValue = Nothing, 0, cmbPrioritas.SelectedValue)
            .Parameters.Add("@ketReject", SqlDbType.VarChar, 300).Value = txtKetReject.Text
            .Parameters.Add("@createdBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
            .Parameters.Add("@judul", SqlDbType.VarChar, 300).Value = txtJudul.Text
            .Parameters.Add(New SqlParameter("@Flag", SqlDbType.SmallInt, 3, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))

            .ExecuteNonQuery()
        End With

        Try
            If CInt(cmd.Parameters("@Flag").Value) = 0 Then
                cmd.Dispose()
                Exit Function
            End If

            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function
    Private Function SaveDataBarang(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal row As Integer) As Boolean
        SaveDataBarang = False

        Dim MyCon As SqlConnection = Conn
        Dim MyConTrans As SqlTransaction = Trans
        Dim cmd As New SqlCommand

        With cmd
            .Connection = Conn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RMPApp..spSaveBarangWoPancang"
            .Transaction = MyConTrans

            .Parameters.Add("@openFormBy", SqlDbType.VarChar, 50).Value = openFormBy
            .Parameters.Add("@woId", SqlDbType.Int).Value = txtId.Text
            .Parameters.Add("@kodeBarang", SqlDbType.VarChar, 50).Value = fgListPilih.Item(row, 1)
            .Parameters.Add("@namaBarang", SqlDbType.VarChar, 300).Value = fgListPilih.Item(row, 2)
            .Parameters.Add("@qty", SqlDbType.Int).Value = fgListPilih.Item(row, 7)
            .Parameters.Add("@harga", SqlDbType.Decimal, 18.2).Value = fgListPilih.Item(row, 5)
            .Parameters.Add("@persen", SqlDbType.Int).Value = IIf(fgListPilih.Item(row, 10) = True, 1, 0)
            .Parameters.Add("@createdBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID.ToUpper
            .Parameters.Add("@total", SqlDbType.Decimal, 18.2).Value = fgListPilih.Item(row, 9)
            .Parameters.Add("@satuan", SqlDbType.VarChar, 50).Value = fgListPilih.Item(row, 3)
            .Parameters.Add("@idPancang", SqlDbType.Int).Value = txtIdPancang.Text
            .Parameters.Add("@asal_kelapa", SqlDbType.VarChar, 50).Value = fgListPilih.Item(row, 4)
            .Parameters.Add("@flag_barang_request", SqlDbType.Int).Value = IIf(fgListPilih.Item(row, 12) = True, 1, 0)
            .Parameters.Add("@persen_request", SqlDbType.Int).Value = fgListPilih.Item(row, 13)
            .Parameters.Add("@akum_persen_request", SqlDbType.Int).Value = fgListPilih.Item(row, 14)
            .Parameters.Add(New SqlParameter("@Flag", SqlDbType.SmallInt, 3, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))

            .ExecuteNonQuery()
        End With

        Try
            If CInt(cmd.Parameters("@Flag").Value) = 0 Then
                cmd.Dispose()
                Exit Function
            End If

            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function

    Private Sub saveProyek()
        Me.Cursor = Cursors.WaitCursor

        If fgListPilih.Rows.Count = 1 Then
            MsgBox("Barang Belum Ada Yang Di Pilih !", vbInformation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        Dim flagTidakAdaBarangYangJadiPersentasi As Integer = 1
        For i = 1 To fgListPilih.Rows.Count - 2
            If fgListPilih.Item(i, 10) = True Then
                flagTidakAdaBarangYangJadiPersentasi = 0
            End If
        Next
        If flagTidakAdaBarangYangJadiPersentasi = 1 Then
            MsgBox("Belum Ada Barang Yang Di Pilih Untuk Persentase Pengerjaan !", vbInformation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        Dim koneksi As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnRMPApp)
        Dim transaksi As SqlTransaction
        transaksi = koneksi.BeginTransaction

        For i = 1 To fgListPilih.Rows.Count - 2
            If SaveDataBarang(koneksi, transaksi, i) = False Then
                transaksi.Rollback()
                MsgBox("Simpan Data Gagal !", vbExclamation, AT)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
        Next

        transaksi.Commit()

        MsgBox("Save Data Berhasil !", vbInformation, AT)
        'Call kondisiAwal()
        Me.Cursor = Cursors.Default

        Me.Cursor = Cursors.Default
    End Sub
    Private Function SaveDataProyek(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        SaveDataProyek = False

        Dim MyCon As SqlConnection = Conn
        Dim MyConTrans As SqlTransaction = Trans
        Dim cmd As New SqlCommand

        With cmd
            .Connection = Conn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RMPApp..spSaveProyekWoPancang"
            .Transaction = MyConTrans

            .Parameters.Add("@woId", SqlDbType.Int).Value = CInt(txtId.Text)
            .Parameters.Add("@falgMandiri", SqlDbType.Int).Value = IIf(rdMandiri.Checked = True, 1, 0)
            .Parameters.Add("@kontraktorId", SqlDbType.Int).Value = IIf(cmbKontraktor.SelectedValue = Nothing, 0, cmbKontraktor.SelectedValue)
            .Parameters.Add("@subKontraktorId", SqlDbType.Int).Value = IIf(cmbSubKontraktor.SelectedValue = Nothing, 0, cmbSubKontraktor.SelectedValue)
            .Parameters.Add("@createdBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
            .Parameters.Add(New SqlParameter("@Flag", SqlDbType.SmallInt, 3, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .Parameters.Add(New SqlParameter("@namaFilePenawaranHarga", SqlDbType.VarChar, 100, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))

            .ExecuteNonQuery()
        End With

        Try
            If CInt(cmd.Parameters("@Flag").Value) = 0 Then
                cmd.Dispose()
                Exit Function
            End If

            namaFilePenawaranHargaDariDatabase = cmd.Parameters("@namaFilePenawaranHarga").Value

            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Call kondisiAwal()
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        If txtCari.Text = "" Then
            MsgBox("Input Terlebih Dahulu Nama Item / Kode Item !", vbInformation, AT)
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        Call loadItemBarang()
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub txtId_TextChanged(sender As Object, e As EventArgs) Handles txtId.TextChanged
        If txtId.Text <> "" Then
            Call loadFgFoto()
        End If
    End Sub



    Public Sub loadListBarang()
        Dim dt As DataTable = New DataTable

        Select Case openFormBy
            Case "EstimasiBiaya"
                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " select kode_barang,nama_barang,satuan,cast(harga_estimasi as bigint) as harga,qty_estimasi as qty,persen,company,barang_request,persen_request,persen_request_akum from tbl_wo_trn_barang where wo_id=" & txtId.Text & " and deleted=0 ")
            Case "Proyek"
                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " select kode_barang,nama_barang,satuan,cast(harga_estimasi as bigint) as harga,qty_estimasi as qty,persen,company,barang_request,persen_request,persen_request_akum from tbl_wo_trn_barang where wo_id=" & txtId.Text & " and deleted=0 ")
            Case "Spk"
                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " select kode_barang,nama_barang,satuan,cast(harga_real as bigint) as harga,qty_real as qty,persen,company,barang_request,persen_request,persen_request_akum from tbl_wo_trn_barang where wo_id=" & txtId.Text & " and deleted=0 ")
            Case "BarangRequest"
                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " select kode_barang,nama_barang,satuan,cast(harga_real as bigint) as harga,qty_real as qty,persen,company,barang_request,persen_request,persen_request_akum from tbl_wo_trn_barang where wo_id=" & txtId.Text & " and deleted=0 ")
        End Select

        fgListPilih.Rows.Count = 1
        Dim i As Integer = 1
        If dt.Rows.Count > 0 Then
            With fgListPilih
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    fgListPilih.Item(i, 1) = row("kode_barang")
                    fgListPilih.Item(i, 2) = row("nama_barang")
                    fgListPilih.Item(i, 3) = row("satuan")
                    fgListPilih.Item(i, 4) = row("company")
                    fgListPilih.Item(i, 5) = row("harga")
                    Dim style As C1.Win.C1FlexGrid.CellStyle = .Styles.Add("style")
                    style.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
                    fgListPilih.SetCellImage(i, 6, My.Resources.TombolKurang)
                    fgListPilih.SetCellStyle(i, 6, style)
                    fgListPilih.Item(i, 7) = row("qty")
                    Dim style1 As C1.Win.C1FlexGrid.CellStyle = .Styles.Add("style")
                    style1.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
                    fgListPilih.SetCellImage(i, 8, My.Resources.TombolTambah)
                    fgListPilih.SetCellStyle(i, 8, style1)
                    fgListPilih.Item(i, 9) = (row("harga") * row("qty"))
                    fgListPilih.Item(i, 10) = row("persen")
                    Dim style2 As C1.Win.C1FlexGrid.CellStyle = .Styles.Add("style")
                    style2.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
                    fgListPilih.SetCellImage(i, 11, My.Resources.ButtonHapus)
                    fgListPilih.SetCellStyle(i, 11, style2)
                    fgListPilih.Item(i, 12) = row("barang_request")
                    fgListPilih.Item(i, 13) = row("persen_request")
                    fgListPilih.Item(i, 14) = row("persen_request_akum")
                    fgListPilih.Item(i, 15) = row("barang_request")

                    i += 1
                Next
                'buat total list barang
                Dim barisBaru2 As Integer = fgListPilih.Rows.Count + 1
                fgListPilih.Rows.Count = barisBaru2
                barisBaru2 -= 1
                hitungTotalDanSetNomor()

                .AutoSizeCols()
                .Cols(6).Width = 50
            End With
        Else
            MsgBox("Data Tidak Di Temukan !", vbInformation, AT)
        End If
    End Sub

    Private Sub fgListPilih_AfterEdit(sender As Object, e As RowColEventArgs) Handles fgListPilih.AfterEdit
        With fgListPilih
            If .Rows.Count >= 3 Then
                .Item(.RowSel, 9) = .Item(.RowSel, 5) * .Item(.RowSel, 7)
                hitungTotalDanSetNomor()
            End If
        End With
    End Sub


    Private Sub btnPdfSpk_Click(sender As Object, e As EventArgs) Handles btnPdfSpk.Click
        Dim Openpdf As OpenFileDialog = New OpenFileDialog()
        Openpdf.Filter = "PDF files|*.pdf|All files|*.*;"

        If Openpdf.ShowDialog() = DialogResult.OK Then
            Dim pdfLog As String = Openpdf.FileName.ToString()
            lblFileSpk.Text = pdfLog
            AxAcroPDF1.src = Openpdf.FileName
            AxAcroPDF1.LoadFile(lblFileSpk.Text)
            picSpk.BackgroundImage = My.Resources.file
        Else
            lblFileSpk.Text = "No File"
            picSpk.BackgroundImage = My.Resources.no_image
        End If

        If AxAcroPDF1.src Is Nothing Then
            MessageBox.Show("Try new file")
        Else
            MessageBox.Show("PDF Uploaded")
        End If
    End Sub

    Private Sub btnPdfProposal_Click(sender As Object, e As EventArgs) Handles btnPdfProposal.Click
        Dim Openpdf As OpenFileDialog = New OpenFileDialog()
        Openpdf.Filter = "PDF files|*.pdf|All files|*.*;"

        If Openpdf.ShowDialog() = DialogResult.OK Then
            Dim pdfLog As String = Openpdf.FileName.ToString()
            lblFileProposal.Text = pdfLog
            AxAcroPDF1.src = Openpdf.FileName
            AxAcroPDF1.LoadFile(lblFileProposal.Text)
            picProposal.BackgroundImage = My.Resources.file
        Else
            lblFileProposal.Text = "No File"
            picProposal.BackgroundImage = My.Resources.no_image
        End If

        If AxAcroPDF1.src Is Nothing Then
            MessageBox.Show("Try new file")
        Else
            MessageBox.Show("PDF Uploaded")
        End If
    End Sub

    Private Sub btnSaveFileDesain_Click(sender As Object, e As EventArgs) Handles btnSaveFileDesain.Click
        If lblFileDesain.Text = "No File" Then
            MsgBox("File Desain Belum Di Upload !", vbExclamation, AT)
            Exit Sub
        End If

        Dim query As String = ""
        query = " declare @namaFile varchar(100)
                    select @namaFile=(select 'DesainProyek_'+cast(id as varchar(50))+'_'+cast(format(getdate(),'yyyy-MM-dd HH-mm-ss') as varchar(20))+'.pdf' from tbl_wo_trn_hdr where id=" & txtId.Text & ")

                    update RMPApp..tbl_wo_trn_hdr set file_design_proyek=@namaFile where id=" & txtId.Text & "

                    UPDATE RMPApp..tbl_wo_trn_file_wo set deleted=1,deleted_by='" & ClsSession.UserID & "',deleted_date=getdate() where wo_id=" & txtId.Text & " and deleted=0 and flag=6

                    insert into RMPApp..tbl_wo_trn_file_wo (wo_id,file_name,flag,deskripsi,deleted,created_by,created_date)
                    values (" & txtId.Text & ",@namaFile,6,'Desain Proyek',0,'" & ClsSession.UserID & "',getdate())

                    if exists (select a.* from vw_woPancang as a where (select top 1 persen from tbl_wo_trn_barang where wo_id=a.id and persen=1 and deleted=0) is not null and(file_penawaran_harga is not null or proyek_mandiri=1) and file_design_proyek is not null and a.id=" & txtId.Text & ")
			        begin
				        EXEC [dbo].[sp_wo_save_marker] " & txtId.Text & ", 'PROSES 1', '" & ClsSession.UserID.ToUpper & "','PROSES 2', 'ADMIN'
			        end
			        else
			        begin
				        EXEC [dbo].[sp_wo_save_marker] " & txtId.Text & ", 'PROSES 1', '" & ClsSession.UserID.ToUpper & "','PROSES 1', 'ENGINEER'
			        end

                    select @namaFile as GetValueString "

        Dim namaFile As String = DB.ExecuteScalarValue(Of String)(StrConnRMPApp,query)

        Dim lokasiSimpanFile As String = UrlNotaPancang & "DocumentWorkOrder\" & namaFile
        File.Copy(lblFileDesain.Text, lokasiSimpanFile, True)

        lblFileDesain.Text = namaFile

        MsgBox("File Berhasil Di Simpan", vbInformation, AT)
    End Sub

    Private Sub btnSaveFilePenawaran_Click(sender As Object, e As EventArgs) Handles btnSaveFilePenawaran.Click
        If rdBukanMandiri.Checked Then
            If Not File.Exists(lblPathFile.Text) Then
                MsgBox("File Penawaran Harga Belum Di Upload !", vbExclamation, AT)
                Exit Sub
            ElseIf cmbKontraktor.SelectedValue = Nothing Then
                MsgBox("Kontraktor Belum Di Pilih !", vbExclamation, AT)
                Exit Sub
            ElseIf cmbSubKontraktor.SelectedValue = Nothing Then
                MsgBox("Sub Kontraktor Belum Di Pilih !", vbExclamation, AT)
                Exit Sub
            End If

            Dim query As String = ""
            query = " declare @namaFile varchar(100)
                        select @namaFile=(select 'PenawaranHarga_'+cast(id as varchar(50))+'_'+cast(format(getdate(),'yyyy-MM-dd HH-mm-ss') as varchar(20))+'.pdf' from tbl_wo_trn_hdr where id=" & txtId.Text & ")
                        
                        update RMPApp..tbl_wo_trn_hdr set proyek_mandiri=0,file_penawaran_harga=@namaFile,kontraktor_id=" & cmbKontraktor.SelectedValue & ",kontraktor_sub_id=" & cmbSubKontraktor.SelectedValue & " where id=" & txtId.Text & "
                        
                        UPDATE RMPApp..tbl_wo_trn_file_wo set deleted=1,deleted_by='" & ClsSession.UserID & "',deleted_date=getdate() where flag=1 and deleted=0 and wo_id=" & txtId.Text & "
                        
                        insert into RMPApp..tbl_wo_trn_file_wo (wo_id,file_name,flag,deskripsi,deleted,created_by,created_date)
                        values (" & txtId.Text & ",@namaFile,1,'Penawaran Harga',0,'" & ClsSession.UserID & "',getdate())
                        
                        if exists (select a.* from vw_woPancang as a where (select top 1 persen from tbl_wo_trn_barang where wo_id=a.id and persen=1 and deleted=0) is not null and(file_penawaran_harga is not null or proyek_mandiri=1) and file_design_proyek is not null and a.id=" & txtId.Text & ")
			            begin
				            EXEC [dbo].[sp_wo_save_marker] " & txtId.Text & ", 'PROSES 1', '" & ClsSession.UserID.ToUpper & "','PROSES 2', 'ADMIN'
			            end
			            else
			            begin
				            EXEC [dbo].[sp_wo_save_marker] " & txtId.Text & ", 'PROSES 1', '" & ClsSession.UserID.ToUpper & "','PROSES 1', 'ENGINEER'
			            end

                        select @namaFile as GetValueString "

            Dim namaFile As String = DB.ExecuteScalarValue(Of String)(StrConnRMPApp,query)

            Dim lokasiSimpanFile As String = UrlNotaPancang & "DocumentWorkOrder\" & namaFile
            File.Copy(lblPathFile.Text, lokasiSimpanFile, True)

            lblPathFile.Text = namaFile
        Else
            Dim updateData As String = " update RMPApp..tbl_wo_trn_hdr set proyek_mandiri=1,file_penawaran_harga=null,kontraktor_id=0,kontraktor_sub_id=0 where id=" & txtId.Text & "
                                            UPDATE RMPApp..tbl_wo_trn_file_wo set deleted=1,deleted_by='" & ClsSession.UserID & "',deleted_date=getdate() where flag=1 and deleted=0 and wo_id=" & txtId.Text & "
                                            EXEC [dbo].[sp_wo_save_marker] " & txtId.Text & ", 'PROSES 1', '" & ClsSession.UserID.ToUpper & "','PROGRESS 1', 'SHIPPER' "
            Dim updateData_ As New SqlCommand(updateData, DB.OpenConnection(StrConnRMPApp))
            updateData_.ExecuteNonQuery()
        End If

        MsgBox("Save Data Berhasil", vbInformation, AT)
    End Sub

    Private Sub picFileDesain_Click(sender As Object, e As EventArgs) Handles picFileDesain.Click
        Try
            Process.Start(UrlNotaPancang & "DocumentWorkOrder\" & lblFileDesain.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "File Tidak Ditemukan Pilih File terlebih dahulu", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub btnUploadFileDesain_Click(sender As Object, e As EventArgs) Handles btnUploadFileDesain.Click
        Dim Openpdf As OpenFileDialog = New OpenFileDialog()
        Openpdf.Filter = "PDF files|*.pdf|All files|*.*;"

        If Openpdf.ShowDialog() = DialogResult.OK Then
            Dim pdfLog As String = Openpdf.FileName.ToString()
            lblFileDesain.Text = pdfLog
            AxAcroPDF1.src = Openpdf.FileName
            AxAcroPDF1.LoadFile(lblFileDesain.Text)
            picFileDesain.BackgroundImage = My.Resources.file
        Else
            lblFileDesain.Text = "No File"
            picFileDesain.BackgroundImage = My.Resources.no_image
        End If

        If AxAcroPDF1.src Is Nothing Then
            MessageBox.Show("Try new file")
        Else
            MessageBox.Show("PDF Uploaded")
        End If
    End Sub

    Private Sub rdBukanMandiri_CheckedChanged(sender As Object, e As EventArgs) Handles rdBukanMandiri.CheckedChanged
        If rdBukanMandiri.Checked = True Then
            cmbKontraktor.Enabled = True
            cmbSubKontraktor.Enabled = True
            btnPdfPenawaranHarga.Enabled = True
        Else
            cmbKontraktor.Enabled = False
            cmbKontraktor.SelectedValue = -1
            cmbSubKontraktor.Enabled = False
            cmbSubKontraktor.SelectedValue = -1
            btnPdfPenawaranHarga.Enabled = False
            lblPathFile.Text = "No File"
            picPdf.BackgroundImage = My.Resources.no_image
        End If
    End Sub

    Private Sub rdMandiri_CheckedChanged(sender As Object, e As EventArgs) Handles rdMandiri.CheckedChanged
        If rdBukanMandiri.Checked = True Then
            cmbKontraktor.Enabled = True
            cmbSubKontraktor.Enabled = True
            btnPdfPenawaranHarga.Enabled = True
        Else
            cmbKontraktor.Enabled = False
            cmbKontraktor.SelectedValue = -1
            cmbSubKontraktor.Enabled = False
            cmbSubKontraktor.SelectedValue = -1
            btnPdfPenawaranHarga.Enabled = False
            lblPathFile.Text = "No File"
            picPdf.BackgroundImage = My.Resources.no_image
        End If
    End Sub

    Private Sub btnPdfPenawaranHarga_Click_1(sender As Object, e As EventArgs) Handles btnPdfPenawaranHarga.Click
        Dim Openpdf As OpenFileDialog = New OpenFileDialog()
        Openpdf.Filter = "PDF files|*.pdf|All files|*.*;"

        If Openpdf.ShowDialog() = DialogResult.OK Then
            Dim pdfLog As String = Openpdf.FileName.ToString()
            lblPathFile.Text = pdfLog
            AxAcroPDF1.src = Openpdf.FileName
            AxAcroPDF1.LoadFile(lblPathFile.Text)
            picPdf.BackgroundImage = My.Resources.file
        Else
            lblPathFile.Text = "No File"
            picPdf.BackgroundImage = My.Resources.no_image
        End If

        If AxAcroPDF1.src Is Nothing Then
            MessageBox.Show("Try new file")
        Else
            MessageBox.Show("PDF Uploaded")
        End If
    End Sub

    Private Sub picPdf_Click(sender As Object, e As EventArgs) Handles picPdf.Click
        Try
            Process.Start(UrlNotaPancang & "DocumentWorkOrder\" & lblFileDesain.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "File Tidak Ditemukan Pilih File terlebih dahulu", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub picSpk_Click(sender As Object, e As EventArgs) Handles picSpk.Click
        Try
            Process.Start(UrlNotaPancang & "DocumentWorkOrder\" & lblFileSpk.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "File Tidak Ditemukan Pilih File terlebih dahulu", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub picProposal_Click(sender As Object, e As EventArgs) Handles picProposal.Click
        Try
            Process.Start(UrlNotaPancang & "DocumentWorkOrder\" & lblFileProposal.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "File Tidak Ditemukan Pilih File terlebih dahulu", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub btnSaveSpk_Click(sender As Object, e As EventArgs) Handles btnSaveSpk.Click
        Call saveSpk()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Try
            Dim topColor As Color = Color.FromArgb(0, 172, 251) ' Warna atas yang tebal
            Dim bottomColor As Color = Color.FromArgb(0, 0, 255, 255) ' Warna bawah yang pudar

            Dim gradientRect As New Rectangle(0, 0, Panel1.Width, Panel1.Height)

            Using brush As New Drawing2D.LinearGradientBrush(gradientRect, topColor, bottomColor, Drawing2D.LinearGradientMode.Vertical)
                e.Graphics.FillRectangle(brush, gradientRect)
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtHargaProyek_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHargaProyek.KeyPress
        If (Not Char.IsNumber(e.KeyChar)) AndAlso (e.KeyChar <> ControlChars.Back) AndAlso (e.KeyChar <> "."c) Then
            ' Cancel the event to prevent the character from being entered
            e.Handled = True
        End If
    End Sub

    Private Sub txtHargaProyek_GotFocus(sender As Object, e As EventArgs) Handles txtHargaProyek.GotFocus
        txtHargaProyek.Text = Replace(txtHargaProyek.Text, ".", "")
        txtHargaProyek.SelectionStart = txtHargaProyek.Text.Length
        txtHargaProyek.SelectionLength = 0
    End Sub

    Private Sub txtHargaProyek_LostFocus(sender As Object, e As EventArgs) Handles txtHargaProyek.LostFocus
        Try
            txtHargaProyek.Text = CStr(String.Format("{0:n0}", CInt(txtHargaProyek.Text)))
        Catch ex As Exception
        End Try
        txtHargaProyek.SelectionStart = txtHargaProyek.Text.Length
        txtHargaProyek.SelectionLength = 0
    End Sub

    Private Sub txtHargaProyek_MouseEnter(sender As Object, e As EventArgs) Handles txtHargaProyek.MouseEnter
        txtHargaProyek.Text = Replace(txtHargaProyek.Text, ".", "")
        txtHargaProyek.SelectionStart = txtHargaProyek.Text.Length
        txtHargaProyek.SelectionLength = 0
    End Sub

    Private Sub txtHargaProyek_MouseLeave(sender As Object, e As EventArgs) Handles txtHargaProyek.MouseLeave
        Try
            txtHargaProyek.Text = CStr(String.Format("{0:n0}", CInt(txtHargaProyek.Text)))
        Catch ex As Exception
        End Try
        txtHargaProyek.SelectionStart = txtHargaProyek.Text.Length
        txtHargaProyek.SelectionLength = 0
    End Sub
End Class