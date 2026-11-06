Imports C1.Win.C1FlexGrid
Imports Microsoft.Win32

Public Class FrmMonDokingKapal
    Dim txt As CellRange
    Dim FNameSebelumDoking1, FNameSebelumDoking2, FNameSebelumDoking3, FNameSebelumDoking4 As String
    Dim FNameSetelahDoking1, FNameSetelahDoking2, FNameSetelahDoking3, FNameSetelahDoking4 As String
    Dim File1, File2, File3, File4, File5, File6, File7, File8 As String
    Dim aksi As String = ""
    Public IdRealisasi As Integer = 0
    Private Sub FrmMonDokingKapal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tanggalAwal As New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
        Dim tanggalAkhir As DateTime = tanggalAwal.AddMonths(1).AddDays(-1)
        Dtp1.Value = tanggalAwal
        Dtp2.Value = tanggalAkhir

        HeaderFg()
        ShowData()
        SetCmbPancang()
    End Sub
    Private Sub SetCmbPancang()
        Try
            Dim dt As DataTable = New DataTable()
            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " select IDPancang,Pancang = convert(varchar,IDPancang) + '. ' + Pancang from Android_tblMstPancang WHERE IDPancang in ( select DISTINCT IdPancang from TblTrnDokingKapal where Approval=1 ) ORDER BY IDPancang ASC ")
            With CmbPancang
                .DataSource = dt
                .DisplayMember = "Pancang"
                .ValueMember = "IDPancang"
                .SelectedIndex = -1
            End With
        Catch ex As Exception
        End Try
    End Sub
    Private Sub HeaderFg()
        With fg
            .Rows.Fixed = 1
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Cols.Count = 41

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

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).TextAlign = TextAlignEnum.LeftCenter : .Cols(0).AllowEditing = False : .Cols(0).AllowMerging = True
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Pancang" : .Cols(1).TextAlign = TextAlignEnum.LeftCenter : .Cols(1).AllowEditing = False : .Cols(1).AllowMerging = True
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Kapal" : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).AllowEditing = False : .Cols(2).AllowMerging = True
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Frekuensi" : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).AllowEditing = False : .Cols(3).AllowMerging = True
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Kapasitas" : .Cols(4).TextAlign = TextAlignEnum.CenterCenter : .Cols(4).AllowEditing = False : .Cols(4).AllowMerging = True
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Nama Kapten Kapten" : .Cols(5).TextAlign = TextAlignEnum.CenterCenter : .Cols(5).AllowEditing = False : .Cols(5).AllowMerging = True
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "No Hp Kapten" : .Cols(6).TextAlign = TextAlignEnum.CenterCenter : .Cols(6).AllowEditing = False : .Cols(6).AllowMerging = True
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Tgl Perencanaan" : .Cols(7).TextAlign = TextAlignEnum.CenterCenter : .Cols(7).AllowEditing = False : .Cols(7).AllowMerging = True
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Tgl Toleransi" : .Cols(8).TextAlign = TextAlignEnum.CenterCenter : .Cols(8).AllowEditing = False : .Cols(8).AllowMerging = True
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Tgl Mulai Doking" : .Cols(9).TextAlign = TextAlignEnum.CenterCenter : .Cols(9).AllowEditing = False : .Cols(9).AllowMerging = True
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "Tgl Selesai Doking" : .Cols(10).TextAlign = TextAlignEnum.CenterCenter : .Cols(10).AllowEditing = False : .Cols(10).AllowMerging = True
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "Tgl Approval" : .Cols(11).TextAlign = TextAlignEnum.CenterCenter : .Cols(11).AllowEditing = False : .Cols(11).AllowMerging = True
            txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "Lokasi Doking" : .Cols(12).TextAlign = TextAlignEnum.CenterCenter : .Cols(12).AllowEditing = False : .Cols(12).AllowMerging = True
            txt = .GetCellRange(0, 13, 0, 13) : txt.Data = "Rekomendasi Perbaikan" : .Cols(13).TextAlign = TextAlignEnum.CenterCenter : .Cols(13).AllowEditing = False : .Cols(13).AllowMerging = True
            txt = .GetCellRange(0, 14, 0, 14) : txt.Data = "Real Perbaikan" : .Cols(14).TextAlign = TextAlignEnum.CenterCenter : .Cols(14).AllowEditing = False : .Cols(14).AllowMerging = True

            txt = .GetCellRange(0, 15, 0, 15) : txt.Data = "Cat" : .Cols(15).TextAlign = TextAlignEnum.CenterCenter : .Cols(15).AllowEditing = False : .Cols(15).AllowMerging = True
            txt = .GetCellRange(0, 16, 0, 16) : txt.Data = "Tali Palka" : .Cols(16).TextAlign = TextAlignEnum.CenterCenter : .Cols(16).AllowEditing = False : .Cols(16).AllowMerging = True
            txt = .GetCellRange(0, 17, 0, 17) : txt.Data = "Roll / Kuas" : .Cols(17).TextAlign = TextAlignEnum.LeftCenter : .Cols(17).AllowEditing = False : .Cols(17).AllowMerging = True
            txt = .GetCellRange(0, 18, 0, 18) : txt.Data = "Semen" : .Cols(18).TextAlign = TextAlignEnum.CenterCenter : .Cols(18).AllowEditing = False : .Cols(18).AllowMerging = True
            txt = .GetCellRange(0, 19, 0, 19) : txt.Data = "Gading" : .Cols(19).TextAlign = TextAlignEnum.CenterCenter : .Cols(19).AllowEditing = False : .Cols(19).AllowMerging = True
            txt = .GetCellRange(0, 20, 0, 20) : txt.Data = "Biaya Upah / Tukang" : .Cols(20).TextAlign = TextAlignEnum.CenterCenter : .Cols(20).AllowEditing = False : .Cols(20).AllowMerging = True
            txt = .GetCellRange(0, 21, 0, 21) : txt.Data = "Biaya Sewa Galangan" : .Cols(21).TextAlign = TextAlignEnum.CenterCenter : .Cols(21).AllowEditing = False : .Cols(21).AllowMerging = True
            txt = .GetCellRange(0, 22, 0, 22) : txt.Data = "Paku" : .Cols(22).TextAlign = TextAlignEnum.LeftCenter : .Cols(22).AllowEditing = False : .Cols(22).AllowMerging = True
            txt = .GetCellRange(0, 23, 0, 23) : txt.Data = "Kayu/Papan" : .Cols(23).TextAlign = TextAlignEnum.CenterCenter : .Cols(23).AllowEditing = False : .Cols(23).AllowMerging = True
            txt = .GetCellRange(0, 24, 0, 24) : txt.Data = "Tabung Gas" : .Cols(24).TextAlign = TextAlignEnum.CenterCenter : .Cols(24).AllowEditing = False : .Cols(24).AllowMerging = True
            txt = .GetCellRange(0, 25, 0, 25) : txt.Data = "Daun Kelapa" : .Cols(25).TextAlign = TextAlignEnum.CenterCenter : .Cols(25).AllowEditing = False : .Cols(25).AllowMerging = True
            txt = .GetCellRange(0, 26, 0, 26) : txt.Data = "Tepung Damar" : .Cols(26).TextAlign = TextAlignEnum.CenterCenter : .Cols(26).AllowEditing = False : .Cols(26).AllowMerging = True
            txt = .GetCellRange(0, 27, 0, 27) : txt.Data = "Lain Nya" : .Cols(27).TextAlign = TextAlignEnum.CenterCenter : .Cols(27).AllowEditing = False : .Cols(27).AllowMerging = True
            txt = .GetCellRange(0, 28, 0, 28) : txt.Data = "Ket" : .Cols(28).TextAlign = TextAlignEnum.CenterCenter : .Cols(28).AllowEditing = False : .Cols(28).AllowMerging = True
            txt = .GetCellRange(0, 29, 0, 29) : txt.Data = "Total Biaya" : .Cols(29).TextAlign = TextAlignEnum.CenterCenter : .Cols(29).AllowEditing = False : .Cols(29).AllowMerging = True

            txt = .GetCellRange(0, 30, 0, 30) : txt.Data = "Created Perencanaan By" : .Cols(30).TextAlign = TextAlignEnum.CenterCenter : .Cols(30).AllowEditing = False : .Cols(30).AllowMerging = True
            txt = .GetCellRange(0, 31, 0, 31) : txt.Data = "Created Realisasi By" : .Cols(31).TextAlign = TextAlignEnum.CenterCenter : .Cols(31).AllowEditing = False : .Cols(31).AllowMerging = True
            txt = .GetCellRange(0, 32, 0, 32) : txt.Data = "Created Approval By" : .Cols(32).TextAlign = TextAlignEnum.CenterCenter : .Cols(32).AllowEditing = False : .Cols(32).AllowMerging = True

            txt = .GetCellRange(0, 33, 0, 33) : txt.Data = "Foto Sebelum Perbaikan 1" : .Cols(33).Visible = False
            txt = .GetCellRange(0, 34, 0, 34) : txt.Data = "Foto Sebelum Perbaikan 2" : .Cols(34).Visible = False
            txt = .GetCellRange(0, 35, 0, 35) : txt.Data = "Foto Sebelum Perbaikan 3" : .Cols(35).Visible = False
            txt = .GetCellRange(0, 36, 0, 36) : txt.Data = "Foto Sebelum Perbaikan 4" : .Cols(36).Visible = False
            txt = .GetCellRange(0, 37, 0, 37) : txt.Data = "Foto Setelah Perbaikan 1" : .Cols(37).Visible = False
            txt = .GetCellRange(0, 38, 0, 38) : txt.Data = "Foto Setelah Perbaikan 2" : .Cols(38).Visible = False
            txt = .GetCellRange(0, 39, 0, 39) : txt.Data = "Foto Setelah Perbaikan 3" : .Cols(39).Visible = False
            txt = .GetCellRange(0, 40, 0, 40) : txt.Data = "Foto Setelah Perbaikan 4" : .Cols(40).Visible = False

            .AutoSizeCols()
        End With
    End Sub
    Private Sub ShowData()
        Me.Cursor = Cursors.WaitCursor

        Dim dt As DataTable = New DataTable
        Dim i As Integer = 1
        Dim sql As String = ""

        sql = Modul_RMP.Func.SetCondition(sql, " (a.TglSelesaiDoking between '" & Format(Dtp1.Value, "yyyy-MM-dd") & "' and '" & Format(Dtp2.Value, "yyyy-MM-dd") & "') ")

        If CmbPancang.Text <> "" Then
            sql = Modul_RMP.Func.SetCondition(sql, " b.IdPancang = '" & CmbPancang.SelectedValue & "' ")
        End If

        If CmbKapal.Text <> "" Then
            sql = Modul_RMP.Func.SetCondition(sql, " b.IdKapal = '" & CmbKapal.SelectedValue & "' ")
        End If

        If IdRealisasi > 0 Then
            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT a.Pancang,a.Kapal,b.Frekuensi,a.Kapasitas,  a.NamaKaptenKapal, a.NoHpKaptenKapal,b.TglPerencanaan,b.TglToleransi,   a.TglMulaiDoking, a.TglSelesaiDoking,b.TglApproval, a.LokasiDoking, ISNULL(a.FotoSebelumDoking1, '') 
                                                             AS FotoSebelumDoking1, ISNULL(a.FotoSebelumDoking2, '') AS FotoSebelumDoking2, ISNULL(a.FotoSebelumDoking3, '') AS FotoSebelumDoking3, ISNULL(a.FotoSebelumDoking4, '') AS FotoSebelumDoking4, 
                                                             ISNULL(a.FotoSetelahDoking1, '') AS FotoSetelahDoking1, ISNULL(a.FotoSetelahDoking2, '') AS FotoSetelahDoking2, ISNULL(a.FotoSetelahDoking3, '') AS FotoSetelahDoking3, ISNULL(a.FotoSetelahDoking4, '') 
                                                             AS FotoSetelahDoking4, a.RekomendasiPerbaikan, a.RealPerbaikan,a.Cat,a.TaliPalka,a.Roll,a.Semen,a.Gading, a.BiayaUpah, a.BiayaSewaGalangan, a.Paku, a.Kayu, a.TabungGas, a.DaunKelapa, a.TepungDamar, a.BiayaLainNya, a.KetBiayaLain, a.TotalBiaya,
                                                             a.CreatedBy as CreatedRealisasiBy,b.CreatedBy as CreatedPerencanaanBy,b.ApprovalBy as CreatedApprovalBy
                                                             FROM dbo.TblTrnRealisasiDokingKapal AS a INNER JOIN
                                                             dbo.TblTrnDokingKapal AS b ON a.Id = b.IdDtlRealisasi
						                                     where a.Id='" & IdRealisasi & "' and b.Approval=1 " & IIf(sql = "", "", " And " & sql) & " order by TglApproval,TglSelesaiDoking desc")
        Else
            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT a.Pancang,a.Kapal,b.Frekuensi,a.Kapasitas,  a.NamaKaptenKapal, a.NoHpKaptenKapal,b.TglPerencanaan,b.TglToleransi,   a.TglMulaiDoking, a.TglSelesaiDoking,b.TglApproval, a.LokasiDoking, ISNULL(a.FotoSebelumDoking1, '') 
                                                             AS FotoSebelumDoking1, ISNULL(a.FotoSebelumDoking2, '') AS FotoSebelumDoking2, ISNULL(a.FotoSebelumDoking3, '') AS FotoSebelumDoking3, ISNULL(a.FotoSebelumDoking4, '') AS FotoSebelumDoking4, 
                                                             ISNULL(a.FotoSetelahDoking1, '') AS FotoSetelahDoking1, ISNULL(a.FotoSetelahDoking2, '') AS FotoSetelahDoking2, ISNULL(a.FotoSetelahDoking3, '') AS FotoSetelahDoking3, ISNULL(a.FotoSetelahDoking4, '') 
                                                             AS FotoSetelahDoking4, a.RekomendasiPerbaikan, a.RealPerbaikan,a.Cat,a.TaliPalka,a.Roll,a.Semen,a.Gading, a.BiayaUpah, a.BiayaSewaGalangan, a.Paku, a.Kayu, a.TabungGas, a.DaunKelapa, a.TepungDamar, a.BiayaLainNya, a.KetBiayaLain, a.TotalBiaya,
                                                             a.CreatedBy as CreatedRealisasiBy,b.CreatedBy as CreatedPerencanaanBy,b.ApprovalBy as CreatedApprovalBy
                                                             FROM dbo.TblTrnRealisasiDokingKapal AS a INNER JOIN
                                                             dbo.TblTrnDokingKapal AS b ON a.Id = b.IdDtlRealisasi
						                                     where b.Approval=1 " & IIf(sql = "", "", " And " & sql) & " order by TglApproval,TglSelesaiDoking desc")
        End If

        fg.Rows.Count = 1
        If dt.Rows.Count > 0 Then
            With fg
                .Rows.Count = 1
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, 1) = row("Pancang")
                    .Item(i, 2) = row("Kapal")
                    .Item(i, 3) = row("Frekuensi")
                    .Item(i, 4) = row("Kapasitas")
                    .Item(i, 5) = row("NamaKaptenKapal")
                    .Item(i, 6) = row("NoHpKaptenKapal")
                    .Item(i, 7) = row("TglPerencanaan")
                    .Item(i, 8) = row("TglToleransi")
                    .Item(i, 9) = row("TglMulaiDoking")
                    .Item(i, 10) = row("TglSelesaiDoking")
                    .Item(i, 11) = row("TglApproval")
                    .Item(i, 12) = row("LokasiDoking")
                    .Item(i, 13) = row("RekomendasiPerbaikan")
                    .Item(i, 14) = row("RealPerbaikan")

                    .Item(i, 15) = row("Cat")
                    .Item(i, 16) = row("TaliPalka")
                    .Item(i, 17) = row("Roll")
                    .Item(i, 18) = row("Semen")
                    .Item(i, 19) = row("Gading")

                    .Item(i, 20) = row("BiayaUpah")
                    .Item(i, 21) = row("BiayaSewaGalangan")
                    .Item(i, 22) = row("Paku")
                    .Item(i, 23) = row("Kayu")
                    .Item(i, 24) = row("TabungGas")
                    .Item(i, 25) = row("DaunKelapa")
                    .Item(i, 26) = row("TepungDamar")
                    .Item(i, 27) = row("BiayaLainNya")
                    .Item(i, 28) = row("KetBiayaLain")
                    .Item(i, 29) = row("TotalBiaya")

                    .Item(i, 30) = row("CreatedPerencanaanBy")
                    .Item(i, 31) = row("CreatedRealisasiBy")
                    .Item(i, 32) = row("CreatedApprovalBy")

                    .Item(i, 33) = row("FotoSebelumDoking1")
                    .Item(i, 34) = row("FotoSebelumDoking2")
                    .Item(i, 35) = row("FotoSebelumDoking3")
                    .Item(i, 36) = row("FotoSebelumDoking4")
                    .Item(i, 37) = row("FotoSetelahDoking1")
                    .Item(i, 38) = row("FotoSetelahDoking2")
                    .Item(i, 39) = row("FotoSetelahDoking3")
                    .Item(i, 40) = row("FotoSetelahDoking4")

                    i += 1
                Next

                .AutoSizeCols()
            End With
        Else
            MsgBox("Tidak Ada Data !", vbInformation, AT)
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint
        Dim topColor As Color = Color.FromArgb(0, 172, 251) ' Warna atas yang tebal
        Dim bottomColor As Color = Color.FromArgb(0, 0, 255, 255) ' Warna bawah yang pudar

        Dim gradientRect As New Rectangle(0, 0, Panel3.Width, Panel3.Height)

        Try
            Using brush As New Drawing2D.LinearGradientBrush(gradientRect, topColor, bottomColor, Drawing2D.LinearGradientMode.Vertical)
                e.Graphics.FillRectangle(brush, gradientRect)
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim filename As String
            Me.SaveFileDialog1.ShowDialog()
            filename = SaveFileDialog1.FileName
            Me.fg.SaveExcel(filename & ".xlsx", "Sheet1", FileFlags.IncludeFixedCells)
            MsgBox("Convert Success !", MsgBoxStyle.Information, AT)
        Catch ex As Exception
            MsgBox("Convert Gagal !", vbInformation, ex)
        End Try
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        ShowData()
    End Sub

    Private Sub BtnExit_Click_1(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub fg_Click_1(sender As Object, e As EventArgs) Handles fg.Click
        If fg.Rows.Count > 1 Then
            With fg
                CmbPancang.Text = .Item(.RowSel, 1)
                CmbKapal.Text = .Item(.RowSel, 2)
                TxtFrekuensi.Text = .Item(.RowSel, 3)
                TxtKapasitas.Text = .Item(.RowSel, 4)
                TxtKapten.Text = .Item(.RowSel, 5)
                TxtNoHpKapten.Text = .Item(.RowSel, 6)
                TglPerencanaan.Value = .Item(.RowSel, 7)
                TglToleransi.Value = .Item(.RowSel, 8)
                TglMulaiDoking.Value = .Item(.RowSel, 9)
                TglSelesaiDoking.Value = .Item(.RowSel, 10)
                TglApproval.Value = .Item(.RowSel, 11)
                TxtPerencanaanBy.Text = .Item(.RowSel, 25)
                TxtRealisasiBy.Text = .Item(.RowSel, 26)
                TxtApprovalBy.Text = .Item(.RowSel, 27)
                TxtLokasiDoking.Text = .Item(.RowSel, 12)
                TxtRekomPerbaikan.Text = .Item(.RowSel, 13)
                TxtRealPerbaikan.Text = .Item(.RowSel, 14)

                TxtCat.Text = .Item(.RowSel, 15)
                TxtTaliPalka.Text = .Item(.RowSel, 16)
                TxtRoll.Text = .Item(.RowSel, 17)
                TxtSemen.Text = .Item(.RowSel, 18)
                TxtGading.Text = .Item(.RowSel, 19)
                TxtBiayaUpah.Text = .Item(.RowSel, 20)
                TxtBiayaSewaGalang.Text = .Item(.RowSel, 21)
                TxtPaku.Text = .Item(.RowSel, 22)
                TxtKayu.Text = .Item(.RowSel, 23)
                TxtTabungGas.Text = .Item(.RowSel, 24)
                TxtDaunKelapa.Text = .Item(.RowSel, 25)
                TxtTepungDamar.Text = .Item(.RowSel, 26)
                TxtLainNya.Text = .Item(.RowSel, 27)
                TxtKet.Text = .Item(.RowSel, 28)
                TxtTotBiaya.Text = .Item(.RowSel, 29)

                FNameSebelumDoking1 = .Item(.RowSel, 33)
                FNameSebelumDoking2 = .Item(.RowSel, 34)
                FNameSebelumDoking3 = .Item(.RowSel, 35)
                FNameSebelumDoking4 = .Item(.RowSel, 36)
                FNameSetelahDoking1 = .Item(.RowSel, 37)
                FNameSetelahDoking2 = .Item(.RowSel, 38)
                FNameSetelahDoking3 = .Item(.RowSel, 39)
                FNameSetelahDoking4 = .Item(.RowSel, 40)

                CekJenisFile()

                If FNameSebelumDoking1.Contains("pdf") Then
                    PicSblm1.Image = RMPApp.My.Resources.Resources.file
                Else
                    Try
                        Dim apiUrl As String = UrlApiNotaPancang & "ImagesPerbaikanKapal&filename=" & .Item(.RowSel, 33) & "&flag=notapancang"

                        Modul_RMP.Func.getfoto(apiUrl, TokenApiNotaPancang, PicSblm1)
                    Catch ex As Exception
                    End Try
                End If
                If FNameSebelumDoking2.Contains("pdf") Then
                    PicSblm2.Image = RMPApp.My.Resources.Resources.file
                Else
                    Try
                        Dim apiUrl As String = UrlApiNotaPancang & "ImagesPerbaikanKapal&filename=" & .Item(.RowSel, 34) & "&flag=notapancang"

                        Modul_RMP.Func.getfoto(apiUrl, TokenApiNotaPancang, PicSblm2)
                    Catch ex As Exception
                    End Try
                End If
                If FNameSebelumDoking3.Contains("pdf") Then
                    PicSblm3.Image = RMPApp.My.Resources.Resources.file
                Else
                    Try
                        Dim apiUrl As String = UrlApiNotaPancang & "ImagesPerbaikanKapal&filename=" & .Item(.RowSel, 35) & "&flag=notapancang"

                        Modul_RMP.Func.getfoto(apiUrl, TokenApiNotaPancang, PicSblm3)
                    Catch ex As Exception
                    End Try
                End If
                If FNameSebelumDoking4.Contains("pdf") Then
                    PicSblm4.Image = RMPApp.My.Resources.Resources.file
                Else
                    Try
                        Dim apiUrl As String = UrlApiNotaPancang & "ImagesPerbaikanKapal&filename=" & .Item(.RowSel, 36) & "&flag=notapancang"

                        Modul_RMP.Func.getfoto(apiUrl, TokenApiNotaPancang, PicSblm4)
                    Catch ex As Exception
                    End Try
                End If
                If FNameSetelahDoking1.Contains("pdf") Then
                    PicStlh1.Image = RMPApp.My.Resources.Resources.file
                Else
                    Try
                        Dim apiUrl As String = UrlApiNotaPancang & "ImagesPerbaikanKapal&filename=" & .Item(.RowSel, 37) & "&flag=notapancang"

                        Modul_RMP.Func.getfoto(apiUrl, TokenApiNotaPancang, PicStlh1)
                    Catch ex As Exception
                    End Try
                End If
                If FNameSetelahDoking2.Contains("pdf") Then
                    PicStlh2.Image = RMPApp.My.Resources.Resources.file
                Else
                    Try
                        Dim apiUrl As String = UrlApiNotaPancang & "ImagesPerbaikanKapal&filename=" & .Item(.RowSel, 38) & "&flag=notapancang"

                        Modul_RMP.Func.getfoto(apiUrl, TokenApiNotaPancang, PicStlh2)
                    Catch ex As Exception
                    End Try
                End If
                If FNameSetelahDoking3.Contains("pdf") Then
                    PicStlh3.Image = RMPApp.My.Resources.Resources.file
                Else
                    Try
                        Dim apiUrl As String = UrlApiNotaPancang & "ImagesPerbaikanKapal&filename=" & .Item(.RowSel, 39) & "&flag=notapancang"

                        Modul_RMP.Func.getfoto(apiUrl, TokenApiNotaPancang, PicStlh3)
                    Catch ex As Exception
                    End Try
                End If
                If FNameSetelahDoking4.Contains("pdf") Then
                    PicStlh4.Image = RMPApp.My.Resources.Resources.file
                Else
                    Try
                        Dim apiUrl As String = UrlApiNotaPancang & "ImagesPerbaikanKapal&filename=" & .Item(.RowSel, 40) & "&flag=notapancang"

                        Modul_RMP.Func.getfoto(apiUrl, TokenApiNotaPancang, PicStlh4)
                    Catch ex As Exception
                    End Try
                End If
            End With
        End If
    End Sub

    Private Sub CekJenisFile()
        If FNameSebelumDoking1.Contains("jpg") Then
            File1 = "jpg"
        ElseIf FNameSebelumDoking1.Contains("jpeg") Then
            File1 = "jpeg"
        ElseIf FNameSebelumDoking1.Contains("pdf") Then
            File1 = "pdf"
        ElseIf FNameSebelumDoking1.Contains("png") Then
            File1 = "png"
        End If
        If FNameSebelumDoking2.Contains("jpg") Then
            File2 = "jpg"
        ElseIf FNameSebelumDoking2.Contains("jpeg") Then
            File2 = "jpeg"
        ElseIf FNameSebelumDoking2.Contains("pdf") Then
            File2 = "pdf"
        ElseIf FNameSebelumDoking2.Contains("png") Then
            File2 = "png"
        End If
        If FNameSebelumDoking3.Contains("jpg") Then
            File3 = "jpg"
        ElseIf FNameSebelumDoking3.Contains("jpeg") Then
            File3 = "jpeg"
        ElseIf FNameSebelumDoking3.Contains("pdf") Then
            File3 = "pdf"
        ElseIf FNameSebelumDoking3.Contains("png") Then
            File3 = "png"
        End If
        If FNameSebelumDoking4.Contains("jpg") Then
            File4 = "jpg"
        ElseIf FNameSebelumDoking4.Contains("jpeg") Then
            File4 = "jpeg"
        ElseIf FNameSebelumDoking4.Contains("pdf") Then
            File4 = "pdf"
        ElseIf FNameSebelumDoking4.Contains("png") Then
            File4 = "png"
        End If
        If FNameSetelahDoking1.Contains("jpg") Then
            File5 = "jpg"
        ElseIf FNameSetelahDoking1.Contains("jpeg") Then
            File5 = "jpeg"
        ElseIf FNameSetelahDoking1.Contains("pdf") Then
            File5 = "pdf"
        ElseIf FNameSetelahDoking1.Contains("png") Then
            File5 = "png"
        End If
        If FNameSetelahDoking2.Contains("jpg") Then
            File6 = "jpg"
        ElseIf FNameSetelahDoking2.Contains("jpeg") Then
            File6 = "jpeg"
        ElseIf FNameSetelahDoking2.Contains("pdf") Then
            File6 = "pdf"
        ElseIf FNameSetelahDoking2.Contains("png") Then
            File6 = "png"
        End If
        If FNameSetelahDoking3.Contains("jpg") Then
            File7 = "jpg"
        ElseIf FNameSetelahDoking3.Contains("jpeg") Then
            File7 = "jpeg"
        ElseIf FNameSetelahDoking3.Contains("pdf") Then
            File7 = "pdf"
        ElseIf FNameSetelahDoking3.Contains("png") Then
            File7 = "png"
        End If
        If FNameSetelahDoking4.Contains("jpg") Then
            File8 = "jpg"
        ElseIf FNameSetelahDoking4.Contains("jpeg") Then
            File8 = "jpeg"
        ElseIf FNameSetelahDoking4.Contains("pdf") Then
            File8 = "pdf"
        ElseIf FNameSetelahDoking4.Contains("png") Then
            File8 = "png"
        End If
    End Sub

    Private Sub PicSblm1_Click(sender As Object, e As EventArgs) Handles PicSblm1.Click
        If aksi = "" Then
            If File1 = "pdf" Then
                Process.Start(UrlNotaPancang & "ImagesPerbaikanKapal\" & FNameSebelumDoking1)
            Else
                If Application.OpenForms.OfType(Of FrmRptViewFoto)().Any() Then
                    FrmRptViewFoto.Close()
                End If
                FrmRptViewFoto.FileName = FNameSebelumDoking1
                FrmRptViewFoto.formName = "FrmTrnRealisasiDokingKapal"
                FrmRptViewFoto.Show()
            End If
        End If
    End Sub

    Private Sub PicSblm2_Click(sender As Object, e As EventArgs) Handles PicSblm2.Click
        If aksi = "" Then
            If File2 = "pdf" Then
                Process.Start(UrlNotaPancang & "ImagesPerbaikanKapal\" & FNameSebelumDoking2)
            Else
                If Application.OpenForms.OfType(Of FrmRptViewFoto)().Any() Then
                    FrmRptViewFoto.Close()
                End If
                FrmRptViewFoto.FileName = FNameSebelumDoking2
                FrmRptViewFoto.formName = "FrmTrnRealisasiDokingKapal"
                FrmRptViewFoto.Show()
            End If
        End If
    End Sub

    Private Sub PicSblm3_Click(sender As Object, e As EventArgs) Handles PicSblm3.Click
        If aksi = "" Then
            If File3 = "pdf" Then
                Process.Start(UrlNotaPancang & "ImagesPerbaikanKapal\" & FNameSebelumDoking3)
            Else
                If Application.OpenForms.OfType(Of FrmRptViewFoto)().Any() Then
                    FrmRptViewFoto.Close()
                End If
                FrmRptViewFoto.FileName = FNameSebelumDoking3
                FrmRptViewFoto.formName = "FrmTrnRealisasiDokingKapal"
                FrmRptViewFoto.Show()
            End If
        End If
    End Sub

    Private Sub PicSblm4_Click(sender As Object, e As EventArgs) Handles PicSblm4.Click
        If aksi = "" Then
            If File4 = "pdf" Then
                Process.Start(UrlNotaPancang & "ImagesPerbaikanKapal\" & FNameSebelumDoking4)
            Else
                If Application.OpenForms.OfType(Of FrmRptViewFoto)().Any() Then
                    FrmRptViewFoto.Close()
                End If
                FrmRptViewFoto.FileName = FNameSebelumDoking4
                FrmRptViewFoto.formName = "FrmTrnRealisasiDokingKapal"
                FrmRptViewFoto.Show()
            End If
        End If
    End Sub

    Private Sub PicStlh1_Click(sender As Object, e As EventArgs) Handles PicStlh1.Click
        If aksi = "" Then
            If File5 = "pdf" Then
                Process.Start(UrlNotaPancang & "ImagesPerbaikanKapal\" & FNameSetelahDoking1)
            Else
                If Application.OpenForms.OfType(Of FrmRptViewFoto)().Any() Then
                    FrmRptViewFoto.Close()
                End If
                FrmRptViewFoto.FileName = FNameSetelahDoking1
                FrmRptViewFoto.formName = "FrmTrnRealisasiDokingKapal"
                FrmRptViewFoto.Show()
            End If
        End If
    End Sub

    Private Sub PicStlh2_Click(sender As Object, e As EventArgs) Handles PicStlh2.Click
        If aksi = "" Then
            If File6 = "pdf" Then
                Process.Start(UrlNotaPancang & "ImagesPerbaikanKapal\" & FNameSetelahDoking2)
            Else
                If Application.OpenForms.OfType(Of FrmRptViewFoto)().Any() Then
                    FrmRptViewFoto.Close()
                End If
                FrmRptViewFoto.FileName = FNameSetelahDoking2
                FrmRptViewFoto.formName = "FrmTrnRealisasiDokingKapal"
                FrmRptViewFoto.Show()
            End If
        End If
    End Sub

    Private Sub PicStlh3_Click(sender As Object, e As EventArgs) Handles PicStlh3.Click
        If aksi = "" Then
            If File7 = "pdf" Then
                Process.Start(UrlNotaPancang & "ImagesPerbaikanKapal\" & FNameSetelahDoking3)
            Else
                If Application.OpenForms.OfType(Of FrmRptViewFoto)().Any() Then
                    FrmRptViewFoto.Close()
                End If
                FrmRptViewFoto.FileName = FNameSetelahDoking3
                FrmRptViewFoto.formName = "FrmTrnRealisasiDokingKapal"
                FrmRptViewFoto.Show()
            End If
        End If
    End Sub

    Private Sub PicStlh4_Click(sender As Object, e As EventArgs) Handles PicStlh4.Click
        If aksi = "" Then
            If File8 = "pdf" Then
                Process.Start(UrlNotaPancang & "ImagesPerbaikanKapal\" & FNameSetelahDoking4)
            Else
                If Application.OpenForms.OfType(Of FrmRptViewFoto)().Any() Then
                    FrmRptViewFoto.Close()
                End If
                FrmRptViewFoto.FileName = FNameSetelahDoking4
                FrmRptViewFoto.formName = "FrmTrnRealisasiDokingKapal"
                FrmRptViewFoto.Show()
            End If
        End If
    End Sub

    Private Sub CmbPancang_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbPancang.SelectedValueChanged
        Try
            Dim dt As DataTable = New DataTable()
            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select KapalID,KapalName = Convert(Varchar(5),KapalID) + '. ' + KapalName from tblMstKapal where IDPancang='" & CmbPancang.SelectedValue & "' and KapalID in ( select distinct IdKapal from TblTrnDokingKapal WHERE Approval=1 )")
            With CmbKapal
                .DataSource = dt
                .DisplayMember = "KapalName"
                .ValueMember = "KapalID"
                .SelectedIndex = -1
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CmbPancang_KeyUp(sender As Object, e As KeyEventArgs) Handles CmbPancang.KeyUp
        UI.AutoCompleteCombo_KeyUp(CmbPancang, e)
    End Sub

    Private Sub CmbKapal_KeyUp(sender As Object, e As KeyEventArgs) Handles CmbKapal.KeyUp
        UI.AutoCompleteCombo_KeyUp(CmbKapal, e)
    End Sub
End Class