Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Runtime.CompilerServices
Imports System.Windows.Controls
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Interop
Imports System.Xml
Imports C1.Win.C1FlexGrid
Imports zxing.Common.Detector

Public Class FrmTrnBarangMasuk
    Dim dt As DataTable = New DataTable
    Dim dt3 As DataTable = New DataTable
    Dim dt4 As DataTable = New DataTable
    Dim BarisBaruFg2 As Integer
    Dim Qty As Integer
    Dim IdPancang As Integer
    Dim Harga As Decimal
    Dim TotalSemua As Decimal
    Dim KodeBarang As String
    Dim PenanggungJawab As String
    Dim InventarisMasuk As String
    Dim FlagCari As String = "PCG"
    Dim kodeTransBPB As String
    Dim AlokasiBarang As String
    Dim TglAlokasi As DateTime
    Dim txt As CellRange
    Private Sub FrmTrnBarangMasuk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RdPCG.Checked = True

        Call HeaderFG()
        Call HeaderFG2()

        Combo.SetPancang(CmbPancang)
        Combo.InvPenanggungJawab(CmbPenanggungJawab)
        Combo.InvKondisiBarang(CmbKondisiBarang)
        Combo.InvInventarisMasuk(CmbInventarisMasuk)

        TxtNamaBarang.Text = "Ketik Nama Barang/Kode Barang/Kode Transaksi BPB ..."
    End Sub
    Public Sub HeaderFG()
        Dim txt As CellRange
        With fg
            .AllowEditing = False
            .AutoGenerateColumns = True
            .Font = New System.Drawing.Font("Century Gothic", 7.0!, System.Drawing.FontStyle.Regular)
            .Cols.Count = 12
            .Cols.Fixed = 1
            .Rows.Count = 1
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

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "NO"
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "select" : .Cols(1).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Kode Barang" : .Cols(2).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Nama Barang" : .Cols(3).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Harga" : .Cols(4).TextAlign = TextAlignEnum.RightCenter : .Cols(4).Format = "#,###0"
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Qty" : .Cols(5).TextAlign = TextAlignEnum.CenterCenter : .Cols(5).Visible = False
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Tanggal Transaksi" : .Cols(6).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Kategori" : .Cols(7).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Satuan" : .Cols(8).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "HargaDecimal" : .Cols(9).TextAlign = TextAlignEnum.CenterCenter : .Cols(9).Visible = False
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "KodeTransBPB" : .Cols(10).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "Remark" : .Cols(11).TextAlign = TextAlignEnum.LeftCenter

            .Rows.Count = 1
            .AutoSizeCols()
        End With
    End Sub
    Public Sub HeaderFG2()
        Dim txt As CellRange
        With fg2
            .Font = New System.Drawing.Font("Century Gothic", 7.0!, System.Drawing.FontStyle.Regular)
            .Rows.Count = 1
            .Cols.Count = 16
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
            .AllowSorting = False
            .AllowResizing = False

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "NO"
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Kode Barang" : .Cols(1).TextAlign = TextAlignEnum.CenterCenter : .Cols(1).AllowEditing = False : .Cols(1).Visible = False 'HIDDEN
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Nama Barang" : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).AllowEditing = False
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Harga" : .Cols(3).TextAlign = TextAlignEnum.RightCenter : .Cols(3).AllowEditing = False : .Cols(3).Format = "#,###0"
            txt = .GetCellRange(0, 4, 0, 6) : txt.Data = "Qty" : .Cols(4).TextAlign = TextAlignEnum.LeftCenter : .Cols(4).AllowEditing = False : .Cols(5).AllowEditing = True : .Cols(6).AllowEditing = False
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Total" : .Cols(7).TextAlign = TextAlignEnum.RightCenter : .Cols(7).AllowEditing = False : .Cols(7).Format = "#,###0"
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Kondisi" : .Cols(8).TextAlign = TextAlignEnum.CenterCenter : .Cols(8).Visible = False 'HIDDEN AJA
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Keterangan / Penanggung Jawab" : .Cols(9).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "Tanggal Alokasi" : .Cols(10).Visible = True : .Cols(10).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "Inventaris Masuk" : .Cols(11).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "Inputan Barang" : .Cols(12).TextAlign = TextAlignEnum.CenterCenter : .Cols(12).Visible = True : .Cols(12).AllowEditing = False 'HIDDEN
            txt = .GetCellRange(0, 13, 0, 13) : txt.Data = "Hapus" : .Cols(13).TextAlign = TextAlignEnum.CenterCenter : .Cols(13).AllowEditing = False
            txt = .GetCellRange(0, 14, 0, 14) : txt.Data = "KodeTransBPB" : .Cols(14).Visible = False
            txt = .GetCellRange(0, 15, 0, 15) : txt.Data = "HargaDecimal" : .Cols(15).Visible = False

            .AutoSizeCols()
        End With
    End Sub
    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click
        Dim TotalHargaBarang As Decimal
        With fg
            If .Rows.Count > 1 Then
                If .Row = -1 Then
                    Exit Sub
                End If


                If .Col = 1 Then
                    'Cek Jika Barang Sudah Di TambahKan
                    If fg2.Rows.Count > 2 Then
                        For i = 1 To fg2.Rows.Count - 1
                            If FlagCari = "PCG" And fg.Item(.RowSel, 2).ToString = fg2.Item(i, 1).ToString Then
                                Dim userResponse As String
                                userResponse = MsgBox("Barang Dengan Kode '" & .Item(.Row, 2) & "' Sudah DiTambahkan,Apakah Anda ingin MenambahkanNya Lagi?", vbYesNo)
                                If userResponse = vbNo Then
                                    Exit Sub
                                End If
                            End If
                            'jika barang yang di input barang BPB cek kode,qty,tanggalTransaksi jika sudah ada di fg2
                            If FlagCari = "BPB" And fg.Item(.RowSel, 2).ToString = fg2.Item(i, 1).ToString And fg.Item(.RowSel, 5) = fg2.Item(i, 5) And fg.Item(.RowSel, 6) = fg2.Item(i, 10) Then
                                Dim userResponse As String
                                userResponse = MsgBox("Barang Dengan Kode '" & .Item(.Row, 2) & "' Sudah DiTambahkan,Apakah Anda ingin MenambahkanNya Lagi?", vbYesNo)
                                If userResponse = vbNo Then
                                    Exit Sub
                                End If
                            End If
                        Next
                    End If

                    'mengatur baris pada fg2
                    If fg2.Rows.Count > 2 Then
                        fg2.Rows.Count -= 1
                    End If
                    BarisBaruFg2 = fg2.Rows.Count
                    fg2.Rows.Count += 1

                    'masukan data dari fg1 ke fg2
                    If FlagCari = "PCG" Then
                        TotalHargaBarang = .Item(.Row, 4)
                    Else
                        TotalHargaBarang = .Item(.Row, 5) * .Item(.Row, 4)
                    End If
                    fg2.Item(BarisBaruFg2, 0) = BarisBaruFg2 'NO
                    fg2.Item(BarisBaruFg2, 1) = .Item(.Row, 2) 'KODE BARANG
                    fg2.Item(BarisBaruFg2, 2) = .Item(.Row, 3) 'NAMA BARANG
                    fg2.Item(BarisBaruFg2, 3) = .Item(.Row, 4) 'HARGA
                    If Not IsNumeric(.Item(.Row, 2)) Then
                        fg2.Item(BarisBaruFg2, 5) = "1" 'QTY
                        fg2.Item(BarisBaruFg2, 10) = Format(Now, "dd/MM/yyyy") 'TANGGAL SEKARANG
                        fg2.Item(BarisBaruFg2, 12) = "PCG"
                    ElseIf IsNumeric(.Item(.Row, 2)) Then
                        fg2.Item(BarisBaruFg2, 5) = .Item(.Row, 5) 'QTY
                        fg2.Item(BarisBaruFg2, 10) = .Item(.Row, 6) 'TGL TRANSAKSI
                        fg2.Item(BarisBaruFg2, 12) = "BPB"
                    End If
                    fg2.Item(BarisBaruFg2, 7) = TotalHargaBarang
                    fg2.Item(BarisBaruFg2, 8) = "BAGUS"
                    fg2.Item(BarisBaruFg2, 14) = .Item(.Row, 10) 'KODE TRANS BPB
                    fg2.Item(BarisBaruFg2, 15) = .Item(.Row, 9) 'HARGA DECIMAL

                    ' Masukan Gambar Ke Dalam FlexGrid
                    Dim style As C1.Win.C1FlexGrid.CellStyle = Me.fg2.Styles.Add("style")
                    style.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
                    Me.fg2.SetCellImage(BarisBaruFg2, 13, My.Resources.ButtonHapus)
                    Me.fg2.SetCellStyle(BarisBaruFg2, 13, style)
                    ' Masukan Gambar Ke Dalam FlexGrid
                    Dim style2 As C1.Win.C1FlexGrid.CellStyle = Me.fg2.Styles.Add("style")
                    style2.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
                    Me.fg2.SetCellImage(BarisBaruFg2, 4, My.Resources.TombolKurang)
                    Me.fg2.SetCellStyle(BarisBaruFg2, 4, style2)
                    ' Masukan Gambar Ke Dalam FlexGrid
                    Dim style3 As C1.Win.C1FlexGrid.CellStyle = Me.fg2.Styles.Add("style")
                    style3.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
                    Me.fg2.SetCellImage(BarisBaruFg2, 6, My.Resources.TombolTambah)
                    Me.fg2.SetCellStyle(BarisBaruFg2, 6, style3)
                    'menjumlahkan semua data yang di list
                    TotalSemua = 0
                    For i = 1 To fg2.Rows.Count - 1
                        TotalSemua += fg2.Item(i, 7)
                    Next
                    'menampilkan jumlah total semua yang di list
                    fg2.Rows.Count += 1
                    fg2.Item(BarisBaruFg2 + 1, 0) = "#"
                    fg2.Item(BarisBaruFg2 + 1, 1) = "Total Semua :"
                    fg2.Item(BarisBaruFg2 + 1, 7) = TotalSemua
                    'atur kolom pada fg2
                    fg2.AutoSizeCols()

                    fg2.Cols(5).Width = 50
                    fg2.Cols(5).TextAlign = TextAlignEnum.CenterCenter
                    fg2.Cols(7).Width = 100
                    fg2.Cols(8).Width = 150
                    fg2.Cols(9).Width = 300

                    'fg2 baris atas nya / header nya di cegah untuk di klik
                    fg2.Rows(fg2.Rows.Count - 1).AllowEditing = False
                End If
            End If
        End With
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs)
        Me.Cursor = Cursors.WaitCursor
        Dim YesNo As String
        Dim koneksi As SqlConnection = DB.OpenConnection(StrConnRMPApp)
        Dim Transaksi As SqlTransaction
        Transaksi = koneksi.BeginTransaction

        If fg2.Rows.Count = 1 Then
            MsgBox("Belum Ada Data Yang Di Tambahkan !", vbInformation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        If CmbPancang.Text = "" Then
            Call MsgBox("Pancang is Empty !!", vbExclamation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        ElseIf CmbPancang.SelectedValue = 0 Then
            Call MsgBox("Pancang is Empty !!", vbExclamation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        For i = 1 To fg2.Rows.Count - 2
            If fg2.Item(i, 8) = "" Or fg2.Item(i, 9) = "" Then
                Call MsgBox("Kolom Kondisi Dan Penanggung Jawab Wajib DiIsi !!", vbExclamation, AT)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
        Next
        YesNo = MsgBox("Klik 'Yes' Jika Data Sudah Siap DiSimpan !", vbYesNo, AT)
        If YesNo = vbNo Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        Try
            With fg2
                For i = 1 To .Rows.Count - 2
                    IdPancang = CmbPancang.SelectedValue
                    KodeBarang = .Item(i, 1)
                    Qty = .Item(i, 5)
                    PenanggungJawab = .Item(i, 9)
                    Harga = .Item(i, 15)
                    TglAlokasi = .Item(i, 10)
                    InventarisMasuk = .Item(i, 11)
                    AlokasiBarang = .Item(i, 12)
                    kodeTransBPB = .Item(i, 14)
                    If Sp_SaveTrnBarangMasukPancang(koneksi, Transaksi) = False Then
                        Transaksi.Rollback()
                        MsgBox("Simpan Data Gagal", vbCritical, "Save Harga Item")
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                Next
            End With
            Me.Cursor = Cursors.Default

            Transaksi.Commit()
            MsgBox("Data Telah Tersimpan", MsgBoxStyle.Information)
            CmbPancang.Text = ""
            HeaderFG()
            fg2.Rows.Count = 1
            If FlagCari = "PCG" Then
                ShowData()
            Else
                ShowDataBPB()
                txt = fg.GetCellRange(0, 5, 0, 5) : txt.Data = "Qty" : fg.Cols(5).Visible = True
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            koneksi.Close()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub BtnCari_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Me.Cursor = Cursors.WaitCursor
        If RdPCG.Checked = True Then
            Call ShowData()
            txt = fg.GetCellRange(0, 5, 0, 5) : txt.Data = "Qty" : fg.Cols(5).Visible = False
            txt = fg.GetCellRange(0, 11, 0, 11) : txt.Data = "Remark" : fg.Cols(11).Visible = False
        ElseIf RdBPB.Checked = True Then
            Call ShowDataBPB()
            txt = fg.GetCellRange(0, 5, 0, 5) : txt.Data = "Qty" : fg.Cols(5).Visible = True
            txt = fg.GetCellRange(0, 11, 0, 11) : txt.Data = "Remark" : fg.Cols(11).Visible = True
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ShowData()
        Me.Cursor = Cursors.WaitCursor
        Dim i As Integer = 1
        Dim sql As String = ""
        Dim query As String = ""

        If TxtNamaBarang.Text <> "Ketik Nama Barang/Kode Barang/Kode Transaksi BPB ..." Then
            sql = Func.SetCondition(sql, " (NamaBarang like '%" & TxtNamaBarang.Text & "%' or KodeBarang like '%" & TxtNamaBarang.Text & "%') ")
        End If
        If ChkKodeBarang.Checked = True Then
            sql = Func.SetCondition(sql, "KodeBarang = '" & CmbKodeBarang.Text.ToString & "'")
        End If
        If ChkKategoriBarang.Checked = True Then
            sql = Func.SetCondition(sql, "Kategori = '" & CmbKategori.Text.ToString & "'")
        End If
        If ChkSatuanBarang.Checked = True Then
            sql = Func.SetCondition(sql, "Satuan = '" & CmbSatuan.Text.ToString & "'")
        End If

        query = "select *,cast((cast(harga as varchar(20))+'0000')as decimal) as HargaVw from RMPApp..TblInv_MstBarang where 1=1" & IIf(sql = "", "", " AND " & sql) & " and NotActived=0 and KodeBarang like '%BRG%'  ORDER  BY NamaBarang asc"

        Try
            fg.Rows.Count = 1
            dt = DB.ExecuteQuery(StrConnRMPApp, query)
            If dt.Rows.Count > 0 Then
                With fg
                    For Each row1 As DataRow In dt.Rows
                        .AddItem(i)
                        .Item(i, 2) = row1.Item("KodeBarang")
                        .Item(i, 3) = row1.Item("NamaBarang")
                        .Item(i, 4) = row1.Item("Harga")
                        .Item(i, 6) = row1.Item("TglPeriode")
                        .Item(i, 7) = row1.Item("Kategori")
                        .Item(i, 8) = row1.Item("Satuan")
                        .Item(i, 9) = row1.Item("HargaVw")
                        .Item(i, 10) = row1.Item("KodeBarang")

                        Dim style As C1.Win.C1FlexGrid.CellStyle = Me.fg.Styles.Add("style")
                        style.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
                        Me.fg.SetCellImage(i, 1, My.Resources.ButtonTambah)
                        Me.fg.SetCellStyle(i, 1, style)

                        i = i + 1
                    Next
                    .AutoSizeCols()
                End With
            Else
                If TxtNamaBarang.Text = "" Then
                    MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
                End If
            End If
        Catch EX As Exception
            MsgBox(EX.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub ShowDataBPB()
        Me.Cursor = Cursors.WaitCursor

        Dim i As Integer = 1
        Dim sql As String = ""
        Dim FlagUpdateMasterBarangBPB As Integer = 0
        Dim flagDataSudahDiTabel As Integer = 0
        Dim query As String = ""

        'simpan data dari bpb ke master
        dt4 = DB.ExecuteQuery(StrConnRMPApp, "select BPBID,ItemID,replace(UnitPrice,'.','') as UnitPrice,TransDate,replace(Qnty,'.','') as Qnty,Remark,BPBID,CategoryName,UOMName,ItemID from RSUPDB..vwBPB where WHSID=36 and Status=2 and cast(TransDate as date) BETWEEN cast('" & Format(DtpStart.Value, "yyyy-MM-dd") & "' as date) AND cast('" & Format(DtpEnd.Value, "yyyy-MM-dd") & "' as date)")
        For Each row4 As DataRow In dt4.Rows
            DB.ExecuteQuery(StrConnRMPApp, "if not exists (select KodeTransBPB from TblInv_TrnBarangTerinputBPB where KodeTransBPB='" & row4("BPBID") & "' and KodeBarangBPB='" & row4("ItemID") & "')
                                                        begin
	                                                        insert into TblInv_TrnBarangTerinputBPB (KodeTransBPB,KodeBarangBPB,UnitPrice,TransDate,Qty,CreatedBy,CreatedDate,FlagSudahInput,Remark) 
                                                        values ('" & row4("BPBID") & "','" & row4("ItemID") & "','" & row4("UnitPrice") & "','" & Format(row4("TransDate"), "yyyy-MM-dd") & "','" & row4("Qnty") & "','" & ClsSession.UserID & "',getdate(),0,'" & row4("Remark") & "')
                                                        end
                                                        if not exists (select * from TblInv_MstBarang where KodeBarang='" & row4("ItemID") & "')
                                                        begin
	                                                        insert into TblInv_MstBarang (KodeBarang,NamaBarang,Kategori,Satuan,TglPeriode,CreatedBy,CreatedDate,Computer,ComputerDate,NotActived)
	                                                        select ItemID,ItemName,CategoryName,UOMName,getdate(),'" & ClsSession.UserID & "',getdate(),HOST_NAME(),getdate(),0 from RSUPDB..vwBPB where BPBID='" & row4("BPBID") & "'
                                                        end
                                                        if not exists (select * from TblInv_MstKategoriBarangBPB where Kategori='" & row4("CategoryName") & "')
                                                        begin
	                                                        insert into TblInv_MstKategoriBarangBPB (Kategori,CreatedBy,CreatedDate,Computer,computerDate,NotActived)
	                                                        values ('" & row4("CategoryName") & "','" & ClsSession.UserID & "',getdate(),host_name(),getdate(),0)
                                                        end
                                                        if not exists (select * from TblInv_MstSatuanBarangBPB where Satuan='" & row4("UOMName") & "')
                                                        begin
	                                                        insert into TblInv_MstSatuanBarangBPB (Satuan,CreatedBy,CreatedDate,Computer,computerDate,NotActived)
	                                                        values ('" & row4("UOMName") & "','" & ClsSession.UserID & "',getdate(),host_name(),getdate(),0)
                                                        end")
        Next

        'hapus jika ada master yang doubel
        Dim dt2 As DataTable = New DataTable
        Dim KodeItem As String = ""
        Dim CreatedDate As String = ""
        dt = DB.ExecuteQuery(StrConnRMPApp, " Select KodeBarang from RMPApp..TblInv_MstBarang group by KodeBarang having count(KodeBarang)>1 ")
        If dt.Rows.Count > 0 Then
            For Each Row_ As DataRow In dt2.Rows
                KodeItem = DB.ExecuteScalarValue(Of String)(StrConnRMPApp, " Select Case Top 1 KodeBarang as GetValueString from RMPApp..TblInv_MstBarang where KodeBarang='" & Row_("KodeBarang") & "' order by CreatedDate desc ")
                CreatedDate = DB.ExecuteScalarValue(Of String)(StrConnRMPApp, " Select Case Top 1 CONVERT(varchar,CreatedDate,120) as GetValueString from RMPApp..TblInv_MstBarang where KodeBarang='" & Row_("KodeBarang") & "' order by CreatedDate desc ")
                DB.ExecuteScalarValue(Of String)(StrConnRMPApp, " delete RMPApp..TblInv_MstBarang where KodeBarang='" & KodeItem & "' and CreatedDate='" & CreatedDate & "' ")
            Next
        End If

        If TxtNamaBarang.Text <> "Ketik Nama Barang/Kode Barang/Kode Transaksi BPB ..." Then
            sql = Func.SetCondition(sql, " (NamaBarang like '%" & TxtNamaBarang.Text & "%' or KodeTransBPB like '%" & TxtNamaBarang.Text & "%' or KodeBarang like '%" & TxtNamaBarang.Text & "%' )")
        End If
        If ChkKodeBarang.Checked = True Then
            sql = Func.SetCondition(sql, "KodeBarang = '" & CmbKodeBarang.Text.ToString & "'")
        End If
        If ChkKategoriBarang.Checked = True Then
            sql = Func.SetCondition(sql, "Kategori = '" & CmbKategori.Text.ToString & "'")
        End If
        If ChkSatuanBarang.Checked = True Then
            sql = Func.SetCondition(sql, "Satuan = '" & CmbSatuan.Text.ToString & "'")
        End If

        query = "select * from VwInv_MstBarangBPB where CAST(TransDate as date) BETWEEN cast('" & Format(DtpStart.Value, "yyyy-MM-dd") & "' as date) AND cast('" & Format(DtpEnd.Value, "yyyy-MM-dd") & "' as date) " & IIf(sql = "", "", " AND " & sql) & " ORDER BY TransDate asc "

        Try
            fg.Rows.Count = 1
            dt = DB.ExecuteQuery(StrConnRMPApp, query)
            If dt.Rows.Count > 0 Then
                With fg
                    For Each row1 As DataRow In dt.Rows
                        .AddItem(i)
                        .Item(i, 2) = row1.Item("KodeBarang")
                        .Item(i, 3) = row1.Item("NamaBarang")
                        .Item(i, 4) = row1.Item("UnitPriceNonDecimal")
                        .Item(i, 5) = row1.Item("QtyNonDecimal")
                        .Item(i, 6) = row1.Item("TransDate")
                        .Item(i, 7) = row1.Item("Kategori")
                        .Item(i, 8) = row1.Item("Satuan")
                        .Item(i, 9) = row1.Item("UnitPrice")
                        .Item(i, 10) = row1.Item("KodeTransBPB")
                        .Item(i, 11) = row1.Item("Remark")

                        Dim style As C1.Win.C1FlexGrid.CellStyle = Me.fg.Styles.Add("style")
                        style.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
                        Me.fg.SetCellImage(i, 1, My.Resources.ButtonTambah)
                        Me.fg.SetCellStyle(i, 1, style)

                        i = i + 1
                    Next
                    .AutoSizeCols()
                End With
            Else
                If TxtNamaBarang.Text = "Ketik Nama Barang/Kode Barang/Kode Transaksi BPB ..." Then
                    MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
                End If
            End If
        Catch EX As Exception
            MsgBox(EX.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub



    Private Sub fg2_Click(sender As Object, e As EventArgs) Handles fg2.Click
        With fg2
            If .Rows.Count > 1 Then
                'cegah user menekan header tabel 2
                If .Row = -1 Then
                    Exit Sub
                End If
                'jika tombol hapus di tekan
                If .Col = 13 Then
                    If .RowSel + 1 = .Rows.Count Then
                        Exit Sub
                    End If

                    Me.fg2.Rows.RemoveRange(.RowSel, 1)

                    TotalSemua = 0
                    For i = 1 To .Rows.Count - 2
                        TotalSemua += .Item(i, 7)
                    Next
                    If TotalSemua <> 0 Then
                        fg2.Item(.Rows.Count - 1, 7) = TotalSemua
                    End If

                    For i = 1 To .Rows.Count - 2
                        .Item(i, 0) = i
                    Next

                    If .Rows.Count = 2 Then
                        .Rows.Count = 1
                    End If
                End If
                'cegah user menekan baris akhir tabel 2
                If .Col = 4 And .RowSel = .Rows.Count - 1 Then
                    Exit Sub
                ElseIf .Col = 6 And .RowSel = .Rows.Count - 1 Then
                    Exit Sub
                End If

                '#++jika tombol kurang di tekan
                If .Col = 4 Then

                    'hentikan fungsi jika melampaui batas qty awal
                    'If .Item(.Row, 12) = "BPB" Then
                    '    Exit Sub
                    'End If

                    'kurangi jumlah qty nya
                    .Item(.Row, 5) -= 1
                    'hitung ulang qty di x harga barang
                    If .Item(.Row, 5) <> 0 Then
                        .Item(.Row, 7) = .Item(.Row, 3) * .Item(.Row, 5)
                    End If
                    'totalkan semua barang
                    TotalSemuaHarga()
                    'jika qty nya sudah kosong
                    If .Item(.Row, 5) = 0 Then
                        'cegah user klik kolom akhir
                        If .RowSel + 1 = .Rows.Count Then
                            Exit Sub
                        End If
                        'hilanhkan baris nya
                        Me.fg2.Rows.RemoveRange(.RowSel, 1)
                        'totalkan semua jumlah barang
                        If .Rows.Count > 2 Then
                            TotalSemuaHarga()
                        End If
                        'sun ulang no tabel
                        For i = 1 To .Rows.Count - 2
                            .Item(i, 0) = i
                        Next
                        'bersihkan jika data terakhir yang di hapus
                        If .Rows.Count = 2 Then
                            .Rows.Count = 1
                        End If
                    End If

                    '#++jika tombol tambah di tekan
                ElseIf .Col = 6 Then

                    'hentikan fungsi jika melampaui batas qty awal
                    'If .Item(.Row, 12) = "BPB" Then
                    '    Exit Sub
                    'End If

                    'tambahkan jumlah qty
                    .Item(.Row, 5) += 1
                    'ubah total barang di kali qty
                    .Item(.Row, 7) = .Item(.Row, 3) * .Item(.Row, 5)
                    'totalkan semua harga barang
                    TotalSemuaHarga()
                    'jika qty kosong
                    If .Item(.Row, 5) = 0 Then
                        'cegak user klik baris terakhir
                        If .RowSel + 1 = .Rows.Count Then
                            Exit Sub
                        End If
                        'hapus baris nya
                        Me.fg2.Rows.RemoveRange(.RowSel, 1)
                        'totalkan semua barang nya
                        TotalSemuaHarga()
                        'susun ulang no tabel
                        For i = 1 To .Rows.Count - 2
                            .Item(i, 0) = i
                        Next
                        'jika baris terakhir yang di hapus bersihkan data fg2
                        If .Rows.Count = 2 Then
                            .Rows.Count = 1
                        End If
                    End If

                End If
            End If
        End With
    End Sub
    Private Sub TotalSemuaHarga()
        TotalSemua = 0
        For i = 1 To fg2.Rows.Count - 2
            TotalSemua += fg2.Item(i, 7)
        Next
        fg2.Item(fg2.Rows.Count - 1, 7) = TotalSemua
    End Sub

    Private Function Sp_SaveTrnBarangMasukPancang(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        Sp_SaveTrnBarangMasukPancang = False
        Dim MyCon As SqlConnection = Conn
        Dim MyConTrans As SqlTransaction = Trans
        Dim cmd As New SqlCommand
        With cmd
            .Connection = Conn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RMPApp..SpInv_SaveTrnBarangMasukPancang"
            .Transaction = MyConTrans
            .Parameters.Add("@KodeBarang", SqlDbType.VarChar, 50).Value = KodeBarang
            .Parameters.Add("@Qty", SqlDbType.Int).Value = Qty
            .Parameters.Add("@Harga", SqlDbType.BigInt).Value = Harga
            .Parameters.Add("@PenanggungJawab", SqlDbType.VarChar, 100).Value = PenanggungJawab
            .Parameters.Add("@IdPancang", SqlDbType.Int).Value = IdPancang
            .Parameters.Add("@InventarisMasuk", SqlDbType.VarChar, 50).Value = InventarisMasuk
            .Parameters.Add("@TglAlokasi", SqlDbType.DateTime).Value = TglAlokasi
            .Parameters.Add("@AlokasiBarang", SqlDbType.VarChar, 20).Value = AlokasiBarang
            .Parameters.Add("@UserLogin", SqlDbType.VarChar, 50).Value = ClsSession.UserID
            .Parameters.Add("@KodeTransBPB", SqlDbType.VarChar, 50).Value = kodeTransBPB
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

    Private Sub CmbKodeBarang_KeyUp(sender As Object, e As KeyEventArgs) Handles CmbKodeBarang.KeyUp
        If CmbKodeBarang.Text <> "" Then
            ChkKodeBarang.Checked = True
        Else
            ChkKodeBarang.Checked = False
        End If
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub ChkKodeBarang_Click(sender As Object, e As EventArgs) Handles ChkKodeBarang.Click
        If ChkKodeBarang.Checked = False Then
            CmbKodeBarang.Text = ""
        End If
    End Sub

    Private Sub TxtNamaBarang_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtNamaBarang.KeyUp
        If RdPCG.Checked = True Then
            ShowData()
        ElseIf RdBPB.Checked = True Then
            ShowDataBPB()
        End If
    End Sub

    Private Sub TxtNamaBarang_GotFocus(sender As Object, e As EventArgs) Handles TxtNamaBarang.GotFocus
        If TxtNamaBarang.Text = "Ketik Nama Barang/Kode Barang/Kode Transaksi BPB ..." Then
            TxtNamaBarang.Text = ""
        End If
    End Sub

    Private Sub TxtNamaBarang_LostFocus(sender As Object, e As EventArgs) Handles TxtNamaBarang.LostFocus
        If TxtNamaBarang.Text = "" Then
            TxtNamaBarang.Text = "Ketik Nama Barang/Kode Barang/Kode Transaksi BPB ..."
        End If
    End Sub

End Class