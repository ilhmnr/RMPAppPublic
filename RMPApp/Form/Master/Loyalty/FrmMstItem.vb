Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports System.IO
Imports System.ComponentModel

Public Class FrmMstItem
    Dim HargaPoint As Integer
    Dim Flag As String
    Dim dt As DataTable = New DataTable
    Dim NamaFoto As String
    Dim txt As CellRange
    'test

    Private Sub FrmMstItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "  SELECT TOP 1 Harga  FROM tbl_Mst_HargaPoint WHERE Tanggal<=GETDATE() ORDER BY TANGGAL DESC")
        Dim Row As DataRow = dt.Rows(0)
        HargaPoint = Row("Harga")

        Call HeaderFG()
        Call HeaderFGDtl()

        clearInput()
        EnableInput(False)

        Call search()

        Combo.SetJenisItem(CmbJenisItem)
        Combo.setSatuanItem(CmbSatuan)
        Combo.SettokoPancang(CmbNamaToko)
        Combo.SettokoPancang(CmbFilterNamaToko)
    End Sub
    Private Sub clearInput()
        fg.Enabled = True
        fg.Rows.Count = 1
        fgDtl.Rows.Count = 1

        DtpStart.Value = Now
        Dtpend.Value = Now

        TxtIdItem.Clear()
        TxtKodeItem.Clear()
        TxtNamaItem.Clear()
        TxtHarga.Clear()
        TxtHargaAwal.Clear()
        TxtIdHarga.Clear()
        TxtHarga.Clear()
        TxtTotalPoint.Clear()
        TxtHargaPoint.Clear()
        DtpTanggal.Value = Now
        CmbJenisItem.SelectedValue = -1
        CmbSatuan.SelectedValue = -1
        CmbNamaToko.SelectedValue = -1

        pic1.Image = Nothing
        BtnChoose.Text = "Add Foto"
        chkNotActive.Checked = False

        txtFileName.Clear()

        Flag = ""
    End Sub

    Private Sub EnableInput(Flag As Boolean)
        DtpStart.Enabled = Flag
        Dtpend.Enabled = Flag

        TxtKodeItem.Enabled = False
        TxtNamaItem.Enabled = Flag
        TxtHarga.Enabled = Flag
        TxtHarga.Enabled = Flag
        TxtTotalPoint.Enabled = False
        TxtHargaPoint.Enabled = False
        DtpTanggal.Enabled = Flag
        CmbJenisItem.Enabled = Flag
        CmbSatuan.Enabled = Flag
        CmbNamaToko.Enabled = Flag

        BtnChoose.Enabled = Flag
        chkNotActive.Enabled = False
    End Sub

    Public Sub HeaderFG()
        With fg
            .AllowEditing = False
            .Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Regular)
            .Rows.Count = 1
            .Cols.Count = 18
            .Cols.Fixed = 1
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 1
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

            Dim i As Integer = 0

            txt = .GetCellRange(0, i, 0, i) : txt.Data = "N0" : .Cols(i).TextAlign = TextAlignEnum.LeftCenter '0
            i += 1
            txt = .GetCellRange(0, i, 0, i) : txt.Data = "Nama Toko" : .Cols(i).TextAlign = TextAlignEnum.LeftCenter : .Cols(i).AllowMerging = True
            i += 1
            txt = .GetCellRange(0, i, 0, i) : txt.Data = "Kode Item" : .Cols(i).TextAlign = TextAlignEnum.CenterCenter
            i += 1
            txt = .GetCellRange(0, i, 0, i) : txt.Data = "Nama Item" : .Cols(i).TextAlign = TextAlignEnum.LeftCenter
            i += 1
            txt = .GetCellRange(0, i, 0, i) : txt.Data = "Jenis Item" : .Cols(i).TextAlign = TextAlignEnum.LeftCenter
            i += 1
            txt = .GetCellRange(0, i, 0, i) : txt.Data = "Satuan" : .Cols(i).TextAlign = TextAlignEnum.LeftCenter '5
            i += 1
            txt = .GetCellRange(0, i, 0, i) : txt.Data = "Harga Item" : .Cols(i).TextAlign = TextAlignEnum.RightCenter : .Cols(i).Format = "#,###0"
            i += 1
            txt = .GetCellRange(0, i, 0, i) : txt.Data = "Tanggal Berlaku" : .Cols(i).TextAlign = TextAlignEnum.CenterCenter
            i += 1
            txt = .GetCellRange(0, i, 0, i) : txt.Data = "Create By" : .Cols(i).TextAlign = TextAlignEnum.LeftCenter
            i += 1
            txt = .GetCellRange(0, i, 0, i) : txt.Data = "Created Date" : .Cols(i).TextAlign = TextAlignEnum.CenterCenter
            i += 1
            txt = .GetCellRange(0, i, 0, i) : txt.Data = "Update By" : .Cols(i).TextAlign = TextAlignEnum.LeftCenter '10
            i += 1
            txt = .GetCellRange(0, i, 0, i) : txt.Data = "Update Date" : .Cols(i).TextAlign = TextAlignEnum.CenterCenter
            i += 1
            txt = .GetCellRange(0, i, 0, i) : txt.Data = "Non Active By" : .Cols(i).TextAlign = TextAlignEnum.LeftCenter : .Cols(i).Visible = False
            i += 1
            txt = .GetCellRange(0, i, 0, i) : txt.Data = "Non Active Date" : .Cols(i).TextAlign = TextAlignEnum.CenterCenter : .Cols(i).Visible = False
            i += 1
            txt = .GetCellRange(0, i, 0, i) : txt.Data = "NotActive" : .Cols(i).TextAlign = TextAlignEnum.LeftCenter : .Cols(i).Visible = False
            i += 1
            txt = .GetCellRange(0, i, 0, i) : txt.Data = "Id Item" : .Cols(i).TextAlign = TextAlignEnum.LeftCenter : .Cols(i).Visible = False '15
            i += 1
            txt = .GetCellRange(0, i, 0, i) : txt.Data = "Foto Item" : .Cols(i).TextAlign = TextAlignEnum.LeftCenter : .Cols(i).Visible = False
            i += 1
            txt = .GetCellRange(0, i, 0, i) : txt.Data = "IdHarga" : .Cols(i).TextAlign = TextAlignEnum.LeftCenter : .Cols(i).Visible = False

            .Cols.Frozen = 1
            .AutoSizeCols()
        End With
    End Sub
    Public Sub HeaderFGDtl()
        With fgDtl
            .Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Regular)
            .Rows.Count = 1
            .Cols.Count = 12
            .Cols.Fixed = 1
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 1
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

            Dim i As Integer = 0

            txt = .GetCellRange(0, i, 0, i) : txt.Data = "N0" : .Cols(i).TextAlign = TextAlignEnum.LeftCenter : .Cols(i).AllowEditing = False '0
            i += 1
            txt = .GetCellRange(0, i, 0, i) : txt.Data = "Nama Item" : .Cols(i).TextAlign = TextAlignEnum.LeftCenter : .Cols(i).AllowEditing = False
            i += 1
            txt = .GetCellRange(0, i, 0, i) : txt.Data = "Harga Item" : .Cols(i).TextAlign = TextAlignEnum.CenterCenter : .Cols(i).Format = "#,###0" : .Cols(i).AllowEditing = False
            i += 1
            txt = .GetCellRange(0, i, 0, i) : txt.Data = "Tanggal Berlaku" : .Cols(i).TextAlign = TextAlignEnum.LeftCenter : .Cols(i).AllowEditing = False
            i += 1
            txt = .GetCellRange(0, i, 0, i) : txt.Data = "Create By" : .Cols(i).TextAlign = TextAlignEnum.LeftCenter : .Cols(i).AllowEditing = False
            i += 1
            txt = .GetCellRange(0, i, 0, i) : txt.Data = "Created Date" : .Cols(i).TextAlign = TextAlignEnum.CenterCenter : .Cols(i).AllowEditing = False '5
            i += 1
            txt = .GetCellRange(0, i, 0, i) : txt.Data = "Update By" : .Cols(i).TextAlign = TextAlignEnum.LeftCenter : .Cols(i).AllowEditing = False
            i += 1
            txt = .GetCellRange(0, i, 0, i) : txt.Data = "Update Date" : .Cols(i).TextAlign = TextAlignEnum.CenterCenter : .Cols(i).AllowEditing = False
            i += 1
            txt = .GetCellRange(0, i, 0, i) : txt.Data = "Keterangan Update" : .Cols(i).TextAlign = TextAlignEnum.CenterCenter : .Cols(i).AllowEditing = False
            i += 1
            txt = .GetCellRange(0, i, 0, i) : txt.Data = "Id Harga" : .Cols(i).TextAlign = TextAlignEnum.LeftCenter : .Cols(i).Visible = False : .Cols(i).AllowEditing = False
            i += 1
            txt = .GetCellRange(0, i, 0, i) : txt.Data = "Delete" : .Cols(i).TextAlign = TextAlignEnum.LeftCenter : .Cols(i).Visible = False : .Cols(i).AllowEditing = True
            i += 1
            txt = .GetCellRange(0, i, 0, i) : txt.Data = "Active" : .Cols(i).TextAlign = TextAlignEnum.LeftCenter : .Cols(i).Visible = False : .Cols(i).AllowEditing = True

            .Cols.Frozen = 1
            .AutoSizeCols()
        End With
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click
        With fg
            Try
                If fg.Rows.Count > 1 Then
                    BtnChoose.Text = "Edit Foto"

                    TxtIdItem.Text = .Item(.Row, 15)
                    TxtKodeItem.Text = .Item(.Row, 2)
                    TxtNamaItem.Text = .Item(.Row, 3)
                    TxtIdHarga.Text = .Item(.Row, 17)
                    TxtHarga.Text = .Item(.Row, 6)
                    TxtHargaAwal.Text = .Item(.Row, 6)
                    TxtHargaPoint.Text = HargaPoint
                    TxtTotalPoint.Text = (TxtHarga.Text / TxtHargaPoint.Text)
                    DtpTanggal.Value = .Item(.Row, 7)
                    DtpCekTglAwal.Value = .Item(.Row, 7)
                    CmbJenisItem.Text = .Item(.Row, 4)
                    CmbSatuan.Text = .Item(.Row, 5)
                    CmbNamaToko.Text = .Item(.Row, 1)
                    chkNotActive.Checked = .Item(.Row, 14)

                    txtFileName.Text = UrlMasterTTPancnag & "ItemBarangPancang\" & .Item(.Row, 16) & ".jpg"

                    Dim apiUrl As String = UrlApiPancang & "ItemBarangPancang&filename=" & .Item(.Row, 16) & ".jpg&flag=mastertt2"

                    Modul_RMP.Func.getfoto(apiUrl, TokenApiNotaPancang, pic1)

                    LoadHistoryHarga(.Item(.Row, 15))
                End If
            Catch ex As Exception
                MsgBox("Error !", vbInformation, AT)
            End Try
        End With
    End Sub

    Private Sub LoadHistoryHarga(IdItem As String)
        Dim i As Integer = 1
        Dim sql As String = ""
        Dim dt As DataTable = New DataTable

        If ChkGetAllData.Checked = True Then
            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select * from vwmsthargapointitem where item_id='" & IdItem & "' order by tgl_periode desc ")
        Else
            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select * from vwmsthargapointitem where item_id='" & IdItem & "' and Active=1 order by tgl_periode desc ")
        End If

        Try
            Call UI.HapusGrid(1, fgDtl)

            With fgDtl

                For Each row1 As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, 1) = row1.Item("nama_item")
                    .Item(i, 2) = row1.Item("harga")
                    .Item(i, 3) = row1.Item("tgl_periode")
                    .Item(i, 4) = row1.Item("created_by")
                    .Item(i, 5) = row1.Item("created_date")
                    .Item(i, 6) = row1.Item("updated_by")
                    .Item(i, 7) = row1.Item("updated_date")
                    .Item(i, 8) = row1.Item("updated_ket")
                    .Item(i, 9) = row1.Item("id")
                    .Item(i, 11) = row1.Item("Active")

                    If row1.Item("Active") = False Then
                        Dim style As New CellRange
                        style = .GetCellRange(i, 1, i, 11)
                        style.StyleNew.ForeColor = Color.Red
                    End If

                    i = i + 1
                Next

                .AutoSizeCols()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        clearInput()
        EnableInput(False)

        If CmbFilterNamaToko.Text <> "" Then
            ShowData()
        End If

        txt = fgDtl.GetCellRange(0, 10, 0, 10) : fgDtl.Cols(10).Visible = False
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Me.Cursor = Cursors.WaitCursor

        If Flag = "" Then
            Call MsgBox("Anda Belum Memilih Aksi Add Atau Edit !", vbExclamation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If TxtNamaItem.Text = "" Then
            Call MsgBox("Nama Item Kosong,Cek Kembali Data Anda !", vbExclamation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        ElseIf TxtHarga.Text = "" Then
            Call MsgBox("Harga Item Kosong,Cek Kembali Data Anda !", vbExclamation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        ElseIf CmbJenisItem.Text = "" Then
            Call MsgBox("Jenis Item Kosong,Cek Kembali Data Anda !", vbExclamation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        ElseIf CmbSatuan.Text = "" Then
            Call MsgBox("Satuan Item Kosong,Cek Kembali Data Anda !", vbExclamation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        ElseIf CmbNamaToko.Text = "" Then
            Call MsgBox("Nama Toko Kosong,Cek Kembali Data Anda !", vbExclamation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        ElseIf pic1.Image Is Nothing Then
            Call MsgBox("Foto Item Kosong,Cek Kembali Data Anda !", vbExclamation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        ElseIf format(DtpTanggal.Value, "yyyy-MM-dd") <> format(DtpCekTglAwal.Value, "yyyy-MM-dd") And TxtHargaAwal.Text = TxtHarga.Text And Flag = "Edit" Then
            Call MsgBox("Anda Mengubah Tanggal Periode,Namun Tidak Mengubah Harga Nya !", vbExclamation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        ElseIf format(DtpTanggal.Value, "yyyy-MM-dd") = format(DtpCekTglAwal.Value, "yyyy-MM-dd") And TxtHargaAwal.Text <> TxtHarga.Text And Flag = "Edit" Then
            Call MsgBox("Anda Mengubah Harga Periode,Namun Tidak Mengubah Tanggal Nya !", vbExclamation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        Dim Nilai As String = TxtTotalPoint.Text
        Dim BilanganBulat As Integer
        If Integer.TryParse(Nilai, BilanganBulat) = False Then
            MsgBox("Harga Point Harus Bilangan Bulat", vbInformation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        Dim YesNo As String
        YesNo = MsgBox("Pastikan Kembali data Sudah Benar !!", vbYesNo, AT)
        If YesNo = vbNo Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        Dim koneksi As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnRMPApp)
        Dim Transaksi As SqlTransaction
        Transaksi = koneksi.BeginTransaction
        Try
            Dim FlagUserTidakNonAktifkanSemuaHarga As Integer = 0
            With fgDtl
                If Flag <> "Add" Then
                    For i = 1 To .Rows.Count - 1
                        If .Item(i, 10) = False And .Item(i, 11) = True Then '10=centang delete,11=status harga aktif
                            FlagUserTidakNonAktifkanSemuaHarga = 1
                        End If
                    Next
                    If FlagUserTidakNonAktifkanSemuaHarga = 1 And Flag = "Edit" Then
                        For i = 1 To .Rows.Count - 1
                            If .Item(i, 10) = True And .Item(i, 11) = True Then '10=centang delete,11=status harga aktif
                                DB.ExecuteScalarValue(Of String)(StrConnRMPApp," if not exists(select * from Android_tblPoinTransaksiItemDtl where harga_id='" & .Item(i, 9) & "')
                                            begin
	                                            update Android_tblPoinHargaDtl set Active=0 where id='" & .Item(i, 9) & "'
                                            end ")
                            End If
                        Next
                    Else
                        MsgBox("Anda Tidak Boleh Hapus Semua Harga", vbInformation, AT)
                        Exit Sub
                    End If
                End If
            End With

            If saveMstItem(koneksi, Transaksi) = False Then
                Transaksi.Rollback()
                MsgBox("Simpan Data Gagal", vbCritical, "Save Harga Item")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            Transaksi.Commit()

            SaveFoto()

            MsgBox("Data Telah Tersimpan", MsgBoxStyle.Information)

            clearInput()
            EnableInput(False)

            ShowData()
            LoadHistoryHarga(TxtIdItem.Text)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            koneksi.Close()
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Function saveMstItem(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        saveMstItem = False
        Dim MyCon As SqlConnection = Conn
        Dim MyConTrans As SqlTransaction = Trans
        Dim cmd As New SqlCommand
        With cmd

            .Connection = Conn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RMPApp..sp_SaveMstItem"
            .Transaction = MyConTrans

            .Parameters.Add("@IdItem", SqlDbType.Int).Value = IIf(Flag = "Add", 0, TxtIdItem.Text)
            .Parameters.Add("@KodeItem", SqlDbType.VarChar, 10).Value = IIf(TxtKodeItem.Text = "", "Null", TxtKodeItem.Text)
            .Parameters.Add("@NamaItem", SqlDbType.VarChar, 100).Value = TxtNamaItem.Text
            .Parameters.Add("@IdHarga", SqlDbType.Int).Value = IIf(TxtIdHarga.Text = "", 0, TxtIdHarga.Text)
            .Parameters.Add("@HargaItem", SqlDbType.Int).Value = TxtHarga.Text
            .Parameters.Add("@TanggalBerlaku", SqlDbType.Date).Value = Format(DtpTanggal.Value, "yyyy-MM-dd")
            .Parameters.Add("@JenisItem", SqlDbType.VarChar, 50).Value = CmbJenisItem.Text
            .Parameters.Add("@IdSatuanItem", SqlDbType.VarChar, 50).Value = CmbSatuan.SelectedValue
            .Parameters.Add("@IdToko", SqlDbType.Int).Value = CmbNamaToko.SelectedValue
            .Parameters.Add("@User", SqlDbType.VarChar, 50).Value = ClsSession.UserID
            .Parameters.Add("@NotActive", SqlDbType.Int, 1).Value = IIf(Flag = "Add", 0, chkNotActive.Checked)
            .Parameters.Add(New SqlParameter("@Flag_", SqlDbType.TinyInt, 1, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .Parameters.Add(New SqlParameter("@KodeItem_", SqlDbType.VarChar, 10, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .Parameters.Add(New SqlParameter("@NamaFoto_", SqlDbType.VarChar, 100, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .Parameters.Add(New SqlParameter("@ErrorValidasiHarga_", SqlDbType.VarChar, 100, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))

            .ExecuteNonQuery()
        End With

        Try
            If CInt(cmd.Parameters("@Flag_").Value) = "0" Then
                cmd.Dispose()
                Exit Function
            End If

            If cmd.Parameters("@ErrorValidasiHarga_").Value.ToString() <> "ok" And Flag = "Edit" Then
                MsgBox(cmd.Parameters("@ErrorValidasiHarga_").Value.ToString(), vbInformation, AT)
                cmd.Dispose()
                Exit Function
            End If

            If TxtKodeItem.Text = "" Then
                TxtKodeItem.Text = cmd.Parameters("@KodeItem_").Value.ToString()
            End If

            NamaFoto = cmd.Parameters("@NamaFoto_").Value.ToString()

            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function
    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        If Flag = "Add" Then
            MsgBox("Anda Sedang Melakukan Add Data,Klik Cencel Untuk Melakukan Edit Data !", vbInformation, AT)
        ElseIf Flag = "Edit" Then
            MsgBox("Anda Sedang Melakukan Edit Data !", vbInformation, AT)
        ElseIf chkNotActive.Checked = True Then
            MsgBox("Data Yang Sudah Non Aktif Tidak Bisa Di Edit !", vbInformation, AT)
        Else
            If TxtKodeItem.Text <> "" Then
                EnableInput(True)

                chkNotActive.Enabled = True

                fg.Rows.Count = 1
                fg.Enabled = False

                txt = fgDtl.GetCellRange(0, 10, 0, 10) : fgDtl.Cols(10).Visible = True

                Flag = "Edit"
            Else
                MsgBox("Tidak Ada Data Yang Di Pilih !", vbInformation, AT)
            End If
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Flag = "Add" Then
            MsgBox("Anda Sedang Melakukan Add Data !", vbInformation, AT)
        ElseIf Flag = "Edit" Then
            MsgBox("Anda Sedang Melakukan Edit Data,Klik Cencel Untuk Melakukan Add Data !", vbInformation, AT)
        Else
            clearInput()
            EnableInput(True)

            TxtHargaPoint.Text = HargaPoint

            fg.Rows.Count = 1
            fg.Enabled = False

            Flag = "Add"
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        'DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"DELETE Android_tblPoinItem WHERE id in(30,31,45,29,32,33)")
        'Exit Sub
        If Flag = "Add" Then
            MsgBox("Anda Sedang Melakukan Add Data,Klik Cencel Untuk Melakukan Cari Data !", vbInformation, AT)
        ElseIf Flag = "Edit" Then
            MsgBox("Anda Sedang Melakukan Edit Data,Klik Cencel Untuk Melakukan Cari Data !", vbInformation, AT)
        Else
            If CmbFilterNamaToko.Text = "" Then
                MsgBox("Pilih Dulu Nama Toko Nya.", vbInformation, AT)
            Else
                Call ShowData()
            End If
        End If
    End Sub


    Private Sub ClearPictureBox(pb As PictureBox)
        pb.Image = Nothing
        pb.BackColor = Color.White
        pb.Invalidate()
    End Sub

    Private Sub search()
        C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        C1FlexGridSearchPanel1.SearchDelay = 2
        C1FlexGridSearchPanel1.Watermark = "Search : "
        C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(fg, C1FlexGridSearchPanel1)
    End Sub
    Private Sub ShowData()
        Dim i As Integer = 1
        Dim sql As String = ""
        Dim dt As DataTable = New DataTable

        If ChkGetAllData.Checked = True Then
            sql = "  select * from vwMstItem where toko_id='3' and harga is not null
                     union 
                     select * from vwMstItem_GetNotNow where toko_id='3' and harga is not null
                     order by kode_item,notactived,tgl_periode desc  "
        Else
            sql = "select * from vwMstItem where toko_id='" & CmbFilterNamaToko.SelectedValue & "'  AND notactived = 0 and harga is not null  "
        End If

        If ChkTgl.Checked = True Then
            sql = sql + " and cast(tgl_periode as date) BETWEEN cast('" & Format(DtpStart.Value, "yyyy-MM-dd") & "' as date) AND cast('" & Format(Dtpend.Value, "yyyy-MM-dd") & "' as date)"
        End If

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        Try
            Call ui.HapusGrid(1, fg)

            If dt.Rows.Count > 0 Then
                With fg
                    For Each row1 As DataRow In dt.Rows
                        .AddItem(i)
                        .Item(i, 1) = row1.Item("nama_toko")
                        .Item(i, 2) = row1.Item("kode_item")
                        .Item(i, 3) = row1.Item("nama_item")
                        .Item(i, 4) = row1.Item("jenis_item")
                        .Item(i, 5) = row1.Item("satuan")
                        .Item(i, 6) = row1.Item("harga")
                        .Item(i, 7) = row1.Item("tgl_periode")
                        .Item(i, 8) = row1.Item("created_by")
                        .Item(i, 9) = row1.Item("created_date")
                        .Item(i, 10) = row1.Item("updated_by")
                        .Item(i, 11) = row1.Item("updated_date")
                        .Item(i, 12) = row1.Item("notactived_by")
                        .Item(i, 13) = row1.Item("notactived_date")
                        .Item(i, 14) = row1.Item("notactived")
                        .Item(i, 15) = row1.Item("id_item")
                        .Item(i, 16) = row1.Item("foto_item")
                        .Item(i, 17) = row1.Item("id_harga")

                        If row1.Item("notactived") = True Then
                            Dim style As New CellRange
                            style = .GetCellRange(i, 1, i, 17)
                            style.StyleNew.ForeColor = Color.Red
                        End If

                        If Format(row1.Item("tgl_periode"), "yyyy-MM-dd") > Format(Now, "yyyy-MM-dd") And row1.Item("notactived") = False Then
                            Dim style As New CellRange
                            style = .GetCellRange(i, 1, i, 17)
                            style.StyleNew.BackColor = Color.Aqua
                        End If

                        i = i + 1
                    Next
                    .AutoSizeCols()
                End With
            Else
                MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub SaveFoto()
        Dim FileFoto As String = txtFileName.Text
        Dim TujuanFile As String = UrlMasterTTPancnag & "ItemBarangPancang\" & NamaFoto & ".jpg"

        Try
            If FileFoto <> TujuanFile Then
                If File.Exists(TujuanFile) Then
                    File.Delete(TujuanFile)
                End If

                System.IO.File.Copy(FileFoto, TujuanFile, True)
            End If
        Catch ex As Exception
            MsgBox("File Gagal di Upload", MsgBoxStyle.Exclamation)
        End Try
    End Sub


    Private Sub ChkTgl_Click(sender As Object, e As EventArgs) Handles ChkTgl.Click
        If ChkTgl.Checked = True Then
            DtpStart.Enabled = True
            Dtpend.Enabled = True
        ElseIf ChkTgl.Checked = False Then
            DtpStart.Enabled = False
            Dtpend.Enabled = False
        End If
    End Sub


    Private Sub TxtHarga_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtHarga.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtHarga_TextChanged(sender As Object, e As EventArgs) Handles TxtHarga.TextChanged
        Try
            If TxtHarga.Text <> "" Then
                TxtTotalPoint.Text = TxtHarga.Text / TxtHargaPoint.Text
            Else
                TxtTotalPoint.Text = ""
            End If

            If Flag = "Edit" And TxtHarga.Text <> TxtHargaAwal.Text Then
                DtpTanggal.Value = Now
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnChoose_Click(sender As Object, e As EventArgs) Handles BtnChoose.Click
        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.Filter = "File Gambar|*.jpg;*.jpeg;*.png;*.gif"
        openFileDialog1.Title = "Pilih Gambar"

        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            txtFileName.Text = openFileDialog1.FileName

            pic1.Image = Image.FromFile(openFileDialog1.FileName)
        End If
    End Sub
End Class