Imports System.Data.SqlClient
Imports System.IO
Imports C1.Win.C1FlexGrid
Imports Microsoft.Win32

Public Class FrmTrnDokingKapalRealisasi
    Dim txt As CellRange
    Dim FNameSebelumDoking1, FNameSebelumDoking2, FNameSebelumDoking3, FNameSebelumDoking4 As String
    Dim FNameSebelumDoking1Old, FNameSebelumDoking2Old, FNameSebelumDoking3Old, FNameSebelumDoking4Old As String
    Dim FNameSetelahDoking1, FNameSetelahDoking2, FNameSetelahDoking3, FNameSetelahDoking4 As String
    Dim FNameSetelahDoking1Old, FNameSetelahDoking2Old, FNameSetelahDoking3Old, FNameSetelahDoking4Old As String
    Dim FotoName1, FotoName2, FotoName3, FotoName4, FotoName5, FotoName6, FotoName7, FotoName8 As String
    Dim File1, File2, File3, File4, File5, File6, File7, File8 As String
    Dim aksi As String = ""
    'simpan id pancang dan id kapal agar setelah save di tampilkan hasil save nya
    Dim IdKapal, IdPancang As Integer
    Public IdDtlFromApproval As Integer = 0
    Private Sub FrmTrnRealisasiDokingKapal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HeaderFg()
        ClearInput()
        EnabelInput(False)
        CmbPancang.Enabled = True
        CmbKapal.Enabled = True
        EnabelTombol(False)
        BtnRefresh.Enabled = True
        BtnAdd.Enabled = True
        SetCmbPancang()
        If IdDtlFromApproval <> 0 Then
            ShowData()
        End If
    End Sub
    Private Sub SetCmbPancang()
        If aksi = "Add" Then
            Try
                Dim dt As DataTable = New DataTable()
                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " select IDPancang,Pancang = convert(varchar,IDPancang) + '. ' + Pancang from Android_tblMstPancang WHERE IDPancang in ( select DISTINCT IdPancang from TblTrnDokingKapal where TglRealisasi is null ) ORDER BY IDPancang ASC ")
                With CmbPancang
                    .DataSource = dt
                    .DisplayMember = "Pancang"
                    .ValueMember = "IDPancang"
                    .SelectedIndex = -1
                End With
            Catch ex As Exception
            End Try
        Else
            Try
                Dim dt As DataTable = New DataTable()
                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " select IDPancang,Pancang = convert(varchar,IDPancang) + '. ' + Pancang from Android_tblMstPancang WHERE IDPancang in ( select DISTINCT IdPancang from TblTrnDokingKapal where TglRealisasi is not null and Approval=0 and NonActive=0 ) ORDER BY IDPancang ASC ")
                With CmbPancang
                    .DataSource = dt
                    .DisplayMember = "Pancang"
                    .ValueMember = "IDPancang"
                    .SelectedIndex = -1
                End With
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub BtnStlh3_Click(sender As Object, e As EventArgs) Handles BtnStlh3.Click
        Try
            OpenFileDialog1.Filter = "All Image Files|*.png;*.jpeg;*.jpg;*.JPG;*.JPEG|PDF Files|*.pdf"
            OpenFileDialog1.Title = "Select Image File"

            If OpenFileDialog1.ShowDialog = DialogResult.OK Then
                FNameSetelahDoking3 = OpenFileDialog1.FileName

                If FNameSetelahDoking3.Contains("pdf") Then
                    PicStlh3.Image = RMPApp.My.Resources.Resources.file
                Else
                    PicStlh3.Image = System.Drawing.Image.FromFile(FNameSetelahDoking3)
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
            Else
                File7 = ""
                FNameSetelahDoking3 = ""
                PicStlh3.Image = RMPApp.My.Resources.Resources.uploadtidakoke
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnStlh2_Click(sender As Object, e As EventArgs) Handles BtnStlh2.Click
        Try
            OpenFileDialog1.Filter = "All Image Files|*.png;*.jpeg;*.jpg;*.JPG;*.JPEG|PDF Files|*.pdf"
            OpenFileDialog1.Title = "Select Image File"

            If OpenFileDialog1.ShowDialog = DialogResult.OK Then
                FNameSetelahDoking2 = OpenFileDialog1.FileName

                If FNameSetelahDoking2.Contains("pdf") Then
                    PicStlh2.Image = RMPApp.My.Resources.Resources.file
                Else
                    PicStlh2.Image = System.Drawing.Image.FromFile(FNameSetelahDoking2)
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
            Else
                File6 = ""
                FNameSetelahDoking2 = ""
                PicStlh2.Image = RMPApp.My.Resources.Resources.uploadtidakoke
            End If
        Catch ex As Exception
        End Try
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

    Private Sub BtnStlh1_Click(sender As Object, e As EventArgs) Handles BtnStlh1.Click
        Try
            OpenFileDialog1.Filter = "All Image Files|*.png;*.jpeg;*.jpg;*.JPG;*.JPEG|PDF Files|*.pdf"
            OpenFileDialog1.Title = "Select Image File"

            If OpenFileDialog1.ShowDialog = DialogResult.OK Then
                FNameSetelahDoking1 = OpenFileDialog1.FileName

                If FNameSetelahDoking1.Contains("pdf") Then
                    PicStlh1.Image = RMPApp.My.Resources.Resources.file
                Else
                    PicStlh1.Image = System.Drawing.Image.FromFile(FNameSetelahDoking1)
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
            Else
                File5 = ""
                FNameSetelahDoking1 = ""
                PicStlh1.Image = RMPApp.My.Resources.Resources.uploadtidakoke
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnSblm3_Click(sender As Object, e As EventArgs) Handles BtnSblm3.Click
        Try
            OpenFileDialog1.Filter = "All Image Files|*.png;*.jpeg;*.jpg;*.JPG;*.JPEG|PDF Files|*.pdf"
            OpenFileDialog1.Title = "Select Image File"

            If OpenFileDialog1.ShowDialog = DialogResult.OK Then
                FNameSebelumDoking3 = OpenFileDialog1.FileName

                If FNameSebelumDoking3.Contains("pdf") Then
                    PicSblm3.Image = RMPApp.My.Resources.Resources.file
                Else
                    PicSblm3.Image = System.Drawing.Image.FromFile(FNameSebelumDoking3)
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
            Else
                File3 = ""
                FNameSebelumDoking3 = ""
                PicSblm3.Image = RMPApp.My.Resources.Resources.uploadtidakoke
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If MsgBox("Yakin akan hapus data ini ?", vbYesNo, AT) = vbNo Then
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        Dim koneksi As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnRMPApp)
        Dim transaksi As SqlTransaction
        transaksi = koneksi.BeginTransaction

        Try
            If SaveData(koneksi, transaksi, TxtIdDtl.Text) = False Then
                transaksi.Rollback()
                MsgBox("Delete Data Gagal !", vbCritical, AT)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            transaksi.Commit()

            IdPancang = CmbPancang.SelectedValue
            IdKapal = CmbKapal.SelectedValue

            aksi = ""
            SetCmbPancang()

            ClearInputAfterSave()
            EnabelTombol(False)
            BtnRefresh.Enabled = True
            BtnAdd.Enabled = True
            EnabelInput(False)
            CmbPancang.Enabled = True
            CmbKapal.Enabled = True

            CmbPancang.SelectedValue = IdPancang
            CmbKapal.SelectedValue = IdKapal
            ShowData()

            MsgBox("Delete Data Berhasil !", vbInformation, AT)
        Catch ex As Exception
            MsgBox("Delete Data Gagal !" & ex.Message, vbExclamation, AT)
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Function SaveData(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal IdDtl As Integer) As Boolean
        SaveData = False

        Dim MyCon As SqlConnection = Conn
        Dim MyConTrans As SqlTransaction = Trans
        Dim cmd As New SqlCommand

        With cmd
            .Connection = Conn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RMPApp..spSaveTrnDokingDeleteKapal"
            .Transaction = MyConTrans

            .Parameters.Add("@IdDtl", SqlDbType.Int).Value = IdDtl
            .Parameters.Add("@UserRMPAPP", SqlDbType.VarChar, 50).Value = ClsSession.UserID
            .Parameters.Add(New SqlParameter("@Flag", SqlDbType.TinyInt, 1, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))

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

    Private Sub BtnSblm2_Click(sender As Object, e As EventArgs) Handles BtnSblm2.Click
        Try
            OpenFileDialog1.Filter = "All Image Files|*.png;*.jpeg;*.jpg;*.JPG;*.JPEG|PDF Files|*.pdf"
            OpenFileDialog1.Title = "Select Image File"

            If OpenFileDialog1.ShowDialog = DialogResult.OK Then
                FNameSebelumDoking2 = OpenFileDialog1.FileName

                If FNameSebelumDoking2.Contains("pdf") Then
                    PicSblm2.Image = RMPApp.My.Resources.Resources.file
                Else
                    PicSblm2.Image = System.Drawing.Image.FromFile(FNameSebelumDoking2)
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
            Else
                File2 = ""
                FNameSebelumDoking2 = ""
                PicSblm2.Image = RMPApp.My.Resources.Resources.uploadtidakoke
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnSblm1_Click(sender As Object, e As EventArgs) Handles BtnSblm1.Click
        Try
            OpenFileDialog1.Filter = "All Image Files|*.png;*.jpeg;*.jpg;*.JPG;*.JPEG|PDF Files|*.pdf"
            OpenFileDialog1.Title = "Select Image File"

            If OpenFileDialog1.ShowDialog = DialogResult.OK Then
                FNameSebelumDoking1 = OpenFileDialog1.FileName

                If FNameSebelumDoking1.Contains("pdf") Then
                    PicSblm1.Image = RMPApp.My.Resources.Resources.file
                Else
                    PicSblm1.Image = System.Drawing.Image.FromFile(FNameSebelumDoking1)
                End If

                If FNameSebelumDoking1.Contains("jpg") Then
                    File1 = "jpg"
                ElseIf FNameSebelumDoking1.Contains("jpeg") Then
                    File1 = "jpeg"
                ElseIf FNameSebelumDoking1.Contains("pdf") Then
                    File1 = "pdf"
                ElseIf FNameSebelumDoking1.Contains("png") Then
                    File1 = "png"
                End If
            Else
                File1 = ""
                FNameSebelumDoking1 = ""
                PicSblm1.Image = RMPApp.My.Resources.Resources.uploadtidakoke
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub HeaderFg()
        With fg
            .Rows.Fixed = 1
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Cols.Count = 42

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
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Kapasitas" : .Cols(3).TextAlign = TextAlignEnum.CenterCenter : .Cols(3).AllowEditing = False : .Cols(3).AllowMerging = True
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Nama Kapten Kapten" : .Cols(4).TextAlign = TextAlignEnum.CenterCenter : .Cols(4).AllowEditing = False : .Cols(4).AllowMerging = True
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "No Hp Kapten" : .Cols(5).TextAlign = TextAlignEnum.CenterCenter : .Cols(5).AllowEditing = False : .Cols(5).AllowMerging = True
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Tgl Mulai Doking" : .Cols(6).TextAlign = TextAlignEnum.CenterCenter : .Cols(6).AllowEditing = False : .Cols(6).AllowMerging = True
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Tgl Selesai Doking" : .Cols(7).TextAlign = TextAlignEnum.CenterCenter : .Cols(7).AllowEditing = False : .Cols(7).AllowMerging = True
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Lokasi Doking" : .Cols(8).TextAlign = TextAlignEnum.CenterCenter : .Cols(8).AllowEditing = False : .Cols(8).AllowMerging = True
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Rekomendasi Perbaikan" : .Cols(9).TextAlign = TextAlignEnum.CenterCenter : .Cols(9).AllowEditing = False : .Cols(9).AllowMerging = True
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "Real Perbaikan" : .Cols(10).TextAlign = TextAlignEnum.CenterCenter : .Cols(10).AllowEditing = False : .Cols(10).AllowMerging = True
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "Cat" : .Cols(11).TextAlign = TextAlignEnum.CenterCenter : .Cols(11).AllowEditing = False : .Cols(11).AllowMerging = True
            txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "Tali Palka" : .Cols(12).TextAlign = TextAlignEnum.CenterCenter : .Cols(12).AllowEditing = False : .Cols(12).AllowMerging = True
            txt = .GetCellRange(0, 13, 0, 13) : txt.Data = "Roll / Kuas" : .Cols(13).TextAlign = TextAlignEnum.LeftCenter : .Cols(13).AllowEditing = False : .Cols(13).AllowMerging = True
            txt = .GetCellRange(0, 14, 0, 14) : txt.Data = "Semen" : .Cols(14).TextAlign = TextAlignEnum.CenterCenter : .Cols(14).AllowEditing = False : .Cols(14).AllowMerging = True
            txt = .GetCellRange(0, 15, 0, 15) : txt.Data = "Gading" : .Cols(15).TextAlign = TextAlignEnum.CenterCenter : .Cols(15).AllowEditing = False : .Cols(15).AllowMerging = True
            txt = .GetCellRange(0, 16, 0, 16) : txt.Data = "Biaya Upah / Tukang" : .Cols(16).TextAlign = TextAlignEnum.CenterCenter : .Cols(16).AllowEditing = False : .Cols(16).AllowMerging = True
            txt = .GetCellRange(0, 17, 0, 17) : txt.Data = "Biaya Sewa Galangan" : .Cols(17).TextAlign = TextAlignEnum.CenterCenter : .Cols(17).AllowEditing = False : .Cols(17).AllowMerging = True
            txt = .GetCellRange(0, 18, 0, 18) : txt.Data = "Paku" : .Cols(18).TextAlign = TextAlignEnum.LeftCenter : .Cols(18).AllowEditing = False : .Cols(18).AllowMerging = True
            txt = .GetCellRange(0, 19, 0, 19) : txt.Data = "Kayu/Papan" : .Cols(19).TextAlign = TextAlignEnum.CenterCenter : .Cols(19).AllowEditing = False : .Cols(19).AllowMerging = True
            txt = .GetCellRange(0, 20, 0, 20) : txt.Data = "Tabung Gas" : .Cols(20).TextAlign = TextAlignEnum.CenterCenter : .Cols(20).AllowEditing = False : .Cols(20).AllowMerging = True
            txt = .GetCellRange(0, 21, 0, 21) : txt.Data = "Daun Kelapa" : .Cols(21).TextAlign = TextAlignEnum.CenterCenter : .Cols(21).AllowEditing = False : .Cols(21).AllowMerging = True
            txt = .GetCellRange(0, 22, 0, 22) : txt.Data = "Tepung Damar" : .Cols(22).TextAlign = TextAlignEnum.CenterCenter : .Cols(22).AllowEditing = False : .Cols(22).AllowMerging = True
            txt = .GetCellRange(0, 23, 0, 23) : txt.Data = "Lain Nya" : .Cols(23).TextAlign = TextAlignEnum.CenterCenter : .Cols(23).AllowEditing = False : .Cols(23).AllowMerging = True
            txt = .GetCellRange(0, 24, 0, 24) : txt.Data = "Ket" : .Cols(24).TextAlign = TextAlignEnum.CenterCenter : .Cols(24).AllowEditing = False : .Cols(24).AllowMerging = True
            txt = .GetCellRange(0, 25, 0, 25) : txt.Data = "Total Biaya" : .Cols(25).TextAlign = TextAlignEnum.CenterCenter : .Cols(25).AllowEditing = False : .Cols(25).AllowMerging = True
            txt = .GetCellRange(0, 26, 0, 26) : txt.Data = "Created By" : .Cols(26).TextAlign = TextAlignEnum.CenterCenter : .Cols(26).AllowEditing = False : .Cols(26).AllowMerging = True
            txt = .GetCellRange(0, 27, 0, 27) : txt.Data = "Created Date" : .Cols(27).TextAlign = TextAlignEnum.CenterCenter : .Cols(27).AllowEditing = False : .Cols(27).AllowMerging = True
            txt = .GetCellRange(0, 28, 0, 28) : txt.Data = "Updated By" : .Cols(28).TextAlign = TextAlignEnum.CenterCenter : .Cols(28).AllowEditing = False : .Cols(28).AllowMerging = True
            txt = .GetCellRange(0, 29, 0, 29) : txt.Data = "Updated Date" : .Cols(29).TextAlign = TextAlignEnum.LeftCenter : .Cols(29).AllowEditing = False : .Cols(29).AllowMerging = True
            txt = .GetCellRange(0, 30, 0, 30) : txt.Data = "Foto Sebelum Perbaikan 1" : .Cols(30).Visible = False
            txt = .GetCellRange(0, 31, 0, 31) : txt.Data = "Foto Sebelum Perbaikan 2" : .Cols(31).Visible = False
            txt = .GetCellRange(0, 32, 0, 32) : txt.Data = "Foto Sebelum Perbaikan 3" : .Cols(32).Visible = False
            txt = .GetCellRange(0, 33, 0, 33) : txt.Data = "Foto Sebelum Perbaikan 4" : .Cols(33).Visible = False
            txt = .GetCellRange(0, 34, 0, 34) : txt.Data = "Foto Setelah Perbaikan 1" : .Cols(34).Visible = False
            txt = .GetCellRange(0, 35, 0, 35) : txt.Data = "Foto Setelah Perbaikan 2" : .Cols(35).Visible = False
            txt = .GetCellRange(0, 36, 0, 36) : txt.Data = "Foto Setelah Perbaikan 3" : .Cols(36).Visible = False
            txt = .GetCellRange(0, 37, 0, 37) : txt.Data = "Foto Setelah Perbaikan 4" : .Cols(37).Visible = False
            txt = .GetCellRange(0, 38, 0, 38) : txt.Data = "IdDtl" : .Cols(38).Visible = False
            txt = .GetCellRange(0, 39, 0, 39) : txt.Data = "IdPancang" : .Cols(39).Visible = False
            txt = .GetCellRange(0, 40, 0, 40) : txt.Data = "IdKapal" : .Cols(40).Visible = False
            txt = .GetCellRange(0, 41, 0, 41) : txt.Data = "IdKapal" : .Cols(41).Visible = False

            .AutoSizeCols()
        End With
    End Sub
    Private Sub ShowData()
        Me.Cursor = Cursors.WaitCursor

        Dim dt As DataTable = New DataTable
        Dim i As Integer = 1
        Dim sql As String = ""

        If CmbPancang.Text <> "" Then
            sql = Modul_RMP.Func.SetCondition(sql, " IdPancang = '" & CmbPancang.SelectedValue & "' ")
        End If

        If CmbKapal.Text <> "" Then
            sql = Modul_RMP.Func.SetCondition(sql, " IdKapal = '" & CmbKapal.SelectedValue & "' ")
        End If

        If IdDtlFromApproval = 0 Then
            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "  SELECT * FROM [RMPApp].[dbo].[vwTrnRealisasiDokingKapal] 
                                                             where 1=1 " & IIf(sql = "", "", " And " & sql) & " order by CreatedDate desc ")
        ElseIf IdDtlFromApproval <> 0 Then
            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "  SELECT * FROM [RMPApp].[dbo].[vwTrnRealisasiDokingKapal] 
                                                             where ID='" & IdDtlFromApproval & "' ")
        End If

        fg.Rows.Count = 1
        If dt.Rows.Count > 0 Then
            With fg
                .Rows.Count = 1
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, 1) = row("Pancang")
                    .Item(i, 2) = row("Kapal")
                    .Item(i, 3) = row("Kapasitas")
                    .Item(i, 4) = row("NamaKaptenKapal")
                    .Item(i, 5) = row("NoHpKaptenKapal")
                    .Item(i, 6) = row("TglMulaiDoking")
                    .Item(i, 7) = row("TglSelesaiDoking")
                    .Item(i, 8) = row("LokasiDoking")
                    .Item(i, 9) = row("RekomendasiPerbaikan")
                    .Item(i, 10) = row("RealPerbaikan")
                    .Item(i, 11) = row("Cat")
                    .Item(i, 12) = row("TaliPalka")
                    .Item(i, 13) = row("Roll")
                    .Item(i, 14) = row("Semen")
                    .Item(i, 15) = row("Gading")
                    .Item(i, 16) = row("BiayaUpah")
                    .Item(i, 17) = row("BiayaSewaGalangan")
                    .Item(i, 18) = row("Paku")
                    .Item(i, 19) = row("Kayu")
                    .Item(i, 20) = row("TabungGas")
                    .Item(i, 21) = row("DaunKelapa")
                    .Item(i, 22) = row("TepungDamar")
                    .Item(i, 23) = row("BiayaLainNya")
                    .Item(i, 24) = row("KetBiayaLain")
                    .Item(i, 25) = row("TotalBiaya")
                    .Item(i, 26) = row("CreatedBy")
                    .Item(i, 27) = row("CreatedDate")
                    .Item(i, 28) = row("UpdatedBy")
                    .Item(i, 29) = row("UpdatedDate")
                    .Item(i, 30) = row("FotoSebelumDoking1")
                    .Item(i, 31) = row("FotoSebelumDoking2")
                    .Item(i, 32) = row("FotoSebelumDoking3")
                    .Item(i, 33) = row("FotoSebelumDoking4")
                    .Item(i, 34) = row("FotoSetelahDoking1")
                    .Item(i, 35) = row("FotoSetelahDoking2")
                    .Item(i, 36) = row("FotoSetelahDoking3")
                    .Item(i, 37) = row("FotoSetelahDoking4")
                    .Item(i, 38) = row("Id")
                    .Item(i, 39) = row("IdPancang")
                    .Item(i, 40) = row("IdKapal")
                    .Item(i, 41) = row("IdKaptenKapal")

                    i += 1
                Next

                .AutoSizeCols()
            End With
        Else
            MsgBox("Tidak Ada Data !", vbInformation, AT)
        End If

        Me.Cursor = Cursors.Default
    End Sub
    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click
        If fg.Rows.Count > 1 Then
            ClearInput()
            aksi = ""
            SetCmbPancang()

            With fg
                TxtIdDtl.Text = .Item(.RowSel, 38)
                CmbPancang.SelectedValue = .Item(.RowSel, 39)
                CmbKapal.SelectedValue = .Item(.RowSel, 40)
                TxtIdKapten.Text = .Item(.RowSel, 41)
                TxtKapasitas.Text = .Item(.RowSel, 3)
                TxtKapten.Text = .Item(.RowSel, 4)
                TxtNoHpKapten.Text = .Item(.RowSel, 5)
                Dtp1.Value = .Item(.RowSel, 6)
                Dtp2.Value = .Item(.RowSel, 7)
                TxtLokasiDoking.Text = .Item(.RowSel, 8)
                TxtRekomPerbaikan.Text = .Item(.RowSel, 9)
                TxtRealPerbaikan.Text = .Item(.RowSel, 10)

                TxtCat.Text = .Item(.RowSel, 11)
                TxtTaliPalka.Text = .Item(.RowSel, 12)
                TxtRoll.Text = .Item(.RowSel, 13)
                TxtSemen.Text = .Item(.RowSel, 14)
                TxtGading.Text = .Item(.RowSel, 15)

                TxtBiayaUpah.Text = .Item(.RowSel, 16)
                TxtBiayaSewaGalang.Text = .Item(.RowSel, 17)
                TxtPaku.Text = .Item(.RowSel, 18)
                TxtKayu.Text = .Item(.RowSel, 19)
                TxtTabungGas.Text = .Item(.RowSel, 20)
                TxtDaunKelapa.Text = .Item(.RowSel, 21)
                TxtTepungDamar.Text = .Item(.RowSel, 22)
                TxtLainNya.Text = .Item(.RowSel, 23)
                TxtKet.Text = .Item(.RowSel, 24)
                TxtTotBiaya.Text = .Item(.RowSel, 25)

                FNameSebelumDoking1 = .Item(.RowSel, 30)
                FNameSebelumDoking1Old = .Item(.RowSel, 30)
                FNameSebelumDoking2 = .Item(.RowSel, 31)
                FNameSebelumDoking2Old = .Item(.RowSel, 31)
                FNameSebelumDoking3 = .Item(.RowSel, 32)
                FNameSebelumDoking3Old = .Item(.RowSel, 32)
                FNameSebelumDoking4 = .Item(.RowSel, 33)
                FNameSebelumDoking4Old = .Item(.RowSel, 33)
                FNameSetelahDoking1 = .Item(.RowSel, 34)
                FNameSetelahDoking1Old = .Item(.RowSel, 34)
                FNameSetelahDoking2 = .Item(.RowSel, 35)
                FNameSetelahDoking2Old = .Item(.RowSel, 35)
                FNameSetelahDoking3 = .Item(.RowSel, 36)
                FNameSetelahDoking3Old = .Item(.RowSel, 36)
                FNameSetelahDoking4 = .Item(.RowSel, 37)
                FNameSetelahDoking4Old = .Item(.RowSel, 37)

                CekJenisFile()

                If FNameSebelumDoking1.Contains("pdf") Then
                    PicSblm1.Image = RMPApp.My.Resources.Resources.file
                Else
                    Try
                        Dim apiUrl As String = UrlApiNotaPancang & "ImagesPerbaikanKapal&filename=" & .Item(.RowSel, 30) & "&flag=notapancang"

                        Modul_RMP.Func.getfoto(apiUrl, TokenApiNotaPancang, PicSblm1)
                    Catch ex As Exception
                    End Try
                End If
                If FNameSebelumDoking2.Contains("pdf") Then
                    PicSblm2.Image = RMPApp.My.Resources.Resources.file
                Else
                    Try
                        Dim apiUrl As String = UrlApiNotaPancang & "ImagesPerbaikanKapal&filename=" & .Item(.RowSel, 31) & "&flag=notapancang"

                        Modul_RMP.Func.getfoto(apiUrl, TokenApiNotaPancang, PicSblm2)
                    Catch ex As Exception
                    End Try
                End If
                If FNameSebelumDoking3.Contains("pdf") Then
                    PicSblm3.Image = RMPApp.My.Resources.Resources.file
                Else
                    Try
                        Dim apiUrl As String = UrlApiNotaPancang & "ImagesPerbaikanKapal&filename=" & .Item(.RowSel, 32) & "&flag=notapancang"

                        Modul_RMP.Func.getfoto(apiUrl, TokenApiNotaPancang, PicSblm3)
                    Catch ex As Exception
                    End Try
                End If
                If FNameSebelumDoking4.Contains("pdf") Then
                    PicSblm4.Image = RMPApp.My.Resources.Resources.file
                Else
                    Try
                        Dim apiUrl As String = UrlApiNotaPancang & "ImagesPerbaikanKapal&filename=" & .Item(.RowSel, 33) & "&flag=notapancang"

                        Modul_RMP.Func.getfoto(apiUrl, TokenApiNotaPancang, PicSblm4)
                    Catch ex As Exception
                    End Try
                End If
                If FNameSetelahDoking1.Contains("pdf") Then
                    PicStlh1.Image = RMPApp.My.Resources.Resources.file
                Else
                    Try
                        Dim apiUrl As String = UrlApiNotaPancang & "ImagesPerbaikanKapal&filename=" & .Item(.RowSel, 34) & "&flag=notapancang"

                        Modul_RMP.Func.getfoto(apiUrl, TokenApiNotaPancang, PicStlh1)
                    Catch ex As Exception
                    End Try
                End If
                If FNameSetelahDoking2.Contains("pdf") Then
                    PicStlh2.Image = RMPApp.My.Resources.Resources.file
                Else
                    Try
                        Dim apiUrl As String = UrlApiNotaPancang & "ImagesPerbaikanKapal&filename=" & .Item(.RowSel, 35) & "&flag=notapancang"

                        Modul_RMP.Func.getfoto(apiUrl, TokenApiNotaPancang, PicStlh2)
                    Catch ex As Exception
                    End Try
                End If
                If FNameSetelahDoking3.Contains("pdf") Then
                    PicStlh3.Image = RMPApp.My.Resources.Resources.file
                Else
                    Try
                        Dim apiUrl As String = UrlApiNotaPancang & "ImagesPerbaikanKapal&filename=" & .Item(.RowSel, 36) & "&flag=notapancang"

                        Modul_RMP.Func.getfoto(apiUrl, TokenApiNotaPancang, PicStlh3)
                    Catch ex As Exception
                    End Try
                End If
                If FNameSetelahDoking4.Contains("pdf") Then
                    PicStlh4.Image = RMPApp.My.Resources.Resources.file
                Else
                    Try
                        Dim apiUrl As String = UrlApiNotaPancang & "ImagesPerbaikanKapal&filename=" & .Item(.RowSel, 37) & "&flag=notapancang"

                        Modul_RMP.Func.getfoto(apiUrl, TokenApiNotaPancang, PicStlh4)
                    Catch ex As Exception
                    End Try
                End If
            End With
        End If
        If TxtIdDtl.Text <> "" Then
            BtnEdit.Enabled = True
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
    Private Sub ClearInput()
        TxtIdDtl.Text = ""
        CmbPancang.Text = ""
        CmbKapal.Text = ""
        TxtKapasitas.Clear()
        TxtKapten.Clear()
        TxtNoHpKapten.Clear()
        Dtp1.Value = Now
        Dtp2.Value = Now
        TxtLokasiDoking.Clear()
        TxtRekomPerbaikan.Clear()
        TxtRealPerbaikan.Clear()
        TxtCat.Clear()
        TxtTaliPalka.Clear()
        TxtRoll.Clear()
        TxtSemen.Clear()
        TxtGading.Clear()
        TxtBiayaUpah.Clear()
        TxtBiayaSewaGalang.Clear()
        TxtPaku.Clear()
        TxtKayu.Clear()
        TxtTabungGas.Clear()
        TxtDaunKelapa.Clear()
        TxtTepungDamar.Clear()
        TxtLainNya.Clear()
        TxtKet.Clear()
        TxtTotBiaya.Clear()

        PicSblm1.Image = Nothing
        PicSblm2.Image = Nothing
        PicSblm3.Image = Nothing
        PicSblm4.Image = Nothing
        PicStlh1.Image = Nothing
        PicStlh2.Image = Nothing
        PicStlh3.Image = Nothing
        PicStlh4.Image = Nothing

        FNameSebelumDoking1 = ""
        FNameSebelumDoking2 = ""
        FNameSebelumDoking3 = ""
        FNameSebelumDoking4 = ""
        FNameSebelumDoking1Old = ""
        FNameSebelumDoking2Old = ""
        FNameSebelumDoking3Old = ""
        FNameSebelumDoking4Old = ""
        FNameSetelahDoking1 = ""
        FNameSetelahDoking2 = ""
        FNameSetelahDoking3 = ""
        FNameSetelahDoking4 = ""
        FNameSetelahDoking1Old = ""
        FNameSetelahDoking2Old = ""
        FNameSetelahDoking3Old = ""
        FNameSetelahDoking4Old = ""
        File1 = ""
        File2 = ""
        File3 = ""
        File4 = ""
        File5 = ""
        File6 = ""
        File7 = ""
        File8 = ""
        FotoName1 = ""
        FotoName2 = ""
        FotoName3 = ""
        FotoName4 = ""
        FotoName5 = ""
        FotoName6 = ""
        FotoName7 = ""
        FotoName8 = ""

        fg.Enabled = True
    End Sub
    Private Sub ClearInputAfterSave()
        TxtKapasitas.Clear()
        TxtKapten.Clear()
        TxtNoHpKapten.Clear()
        Dtp1.Value = Now
        Dtp2.Value = Now
        TxtLokasiDoking.Clear()
        TxtRekomPerbaikan.Clear()
        TxtRealPerbaikan.Clear()
        TxtCat.Clear()
        TxtTaliPalka.Clear()
        TxtRoll.Clear()
        TxtSemen.Clear()
        TxtGading.Clear()
        TxtBiayaUpah.Clear()
        TxtBiayaSewaGalang.Clear()
        TxtPaku.Clear()
        TxtKayu.Clear()
        TxtTabungGas.Clear()
        TxtDaunKelapa.Clear()
        TxtTepungDamar.Clear()
        TxtLainNya.Clear()
        TxtKet.Clear()
        TxtTotBiaya.Clear()

        PicSblm1.Image = Nothing
        PicSblm2.Image = Nothing
        PicSblm3.Image = Nothing
        PicSblm4.Image = Nothing
        PicStlh1.Image = Nothing
        PicStlh2.Image = Nothing
        PicStlh3.Image = Nothing
        PicStlh4.Image = Nothing

        FNameSebelumDoking1 = ""
        FNameSebelumDoking2 = ""
        FNameSebelumDoking3 = ""
        FNameSebelumDoking4 = ""
        FNameSebelumDoking1Old = ""
        FNameSebelumDoking2Old = ""
        FNameSebelumDoking3Old = ""
        FNameSebelumDoking4Old = ""
        FNameSetelahDoking1 = ""
        FNameSetelahDoking2 = ""
        FNameSetelahDoking3 = ""
        FNameSetelahDoking4 = ""
        FNameSetelahDoking1Old = ""
        FNameSetelahDoking2Old = ""
        FNameSetelahDoking3Old = ""
        FNameSetelahDoking4Old = ""
        File1 = ""
        File2 = ""
        File3 = ""
        File4 = ""
        File5 = ""
        File6 = ""
        File7 = ""
        File8 = ""
        FotoName1 = ""
        FotoName2 = ""
        FotoName3 = ""
        FotoName4 = ""
        FotoName5 = ""
        FotoName6 = ""
        FotoName7 = ""
        FotoName8 = ""

        fg.Enabled = True
    End Sub
    Private Sub EnabelInput(flag As Boolean)
        Dtp1.Enabled = flag
        Dtp2.Enabled = flag
        TxtLokasiDoking.Enabled = flag
        TxtRekomPerbaikan.Enabled = flag
        TxtRealPerbaikan.Enabled = flag
        TxtCat.Enabled = flag
        TxtTaliPalka.Enabled = flag
        TxtRoll.Enabled = flag
        TxtSemen.Enabled = flag
        TxtGading.Enabled = flag
        TxtBiayaUpah.Enabled = flag
        TxtBiayaSewaGalang.Enabled = flag
        TxtPaku.Enabled = flag
        TxtKayu.Enabled = flag
        TxtTabungGas.Enabled = flag
        TxtDaunKelapa.Enabled = flag
        TxtTepungDamar.Enabled = flag
        TxtLainNya.Enabled = flag
        TxtKet.Enabled = flag

        aksi = ""
    End Sub
    Private Sub EnabelTombol(flag As Boolean)
        BtnRefresh.Enabled = flag
        BtnAdd.Enabled = flag
        BtnEdit.Enabled = flag
        BtnSave.Enabled = flag
        btnDelete.Enabled = flag
        BtnCancel.Enabled = flag
        BtnSblm1.Enabled = flag
        BtnSblm3.Enabled = flag
        BtnSblm2.Enabled = flag
        BtnSblm4.Enabled = flag
        BtnStlh1.Enabled = flag
        BtnStlh3.Enabled = flag
        BtnStlh2.Enabled = flag
        BtnStlh4.Enabled = flag
    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Dim topColor As Color = Color.FromArgb(0, 172, 251) ' Warna atas yang tebal
        Dim bottomColor As Color = Color.FromArgb(0, 0, 255, 255) ' Warna bawah yang pudar

        Dim gradientRect As New Rectangle(0, 0, Panel1.Width, Panel1.Height)

        Try
            Using brush As New Drawing2D.LinearGradientBrush(gradientRect, topColor, bottomColor, Drawing2D.LinearGradientMode.Vertical)
                e.Graphics.FillRectangle(brush, gradientRect)
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        ShowData()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        ClearInput()
        EnabelTombol(True)
        BtnAdd.Enabled = False
        BtnEdit.Enabled = False
        BtnRefresh.Enabled = False
        EnabelInput(True)
        TxtKet.Enabled = False

        TxtIdDtl.Text = 0
        aksi = "Add"

        SetCmbPancang()
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        EnabelInput(True)
        CmbPancang.Enabled = False
        CmbKapal.Enabled = False
        EnabelTombol(True)
        BtnRefresh.Enabled = False
        BtnAdd.Enabled = False
        BtnEdit.Enabled = False
        fg.Enabled = False
        aksi = "Edit"
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Me.Cursor = Cursors.WaitCursor

        Dim koneksi As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnRMPApp)
        Dim transaksi As SqlTransaction
        transaksi = koneksi.BeginTransaction

        If CmbPancang.Text = "" Then
            MsgBox("Pancang Belum Di Pilih !", vbInformation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        ElseIf CmbKapal.Text = "" Then
            MsgBox("Kapal Belum Di Pilih !", vbInformation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        ElseIf TxtKapasitas.Text = "" Then
            MsgBox("Kapasitas Kapal Belum Di Perbaharui Data Nya !", vbInformation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        ElseIf TxtKapten.Text = "" Then
            MsgBox("Nama Kapten Kapal Belum Di Perbaharui Data Nya !", vbInformation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        ElseIf TxtNoHpKapten.Text = "" Then
            MsgBox("No Hp Kapten Kapal Belum Di Perbaharui Data Nya !", vbInformation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        ElseIf TxtLokasiDoking.Text = "" Then
            MsgBox("Lokasi Doking Belum Di Isi !", vbInformation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        ElseIf TxtLainNya.Text <> "" And TxtKet.Text = "" Then
            MsgBox("Jika Ada Biaya Lain Nya,Wajib Isi Keterangan Nya !", vbInformation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        Else
            Try
                If SaveData(koneksi, transaksi) = False Then
                    transaksi.Rollback()
                    MsgBox("Simpan Data Gagal !", vbCritical, AT)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If

                transaksi.Commit()

                If FNameSebelumDoking1 <> FNameSebelumDoking1Old Then
                    Try
                        If File.Exists(UrlNotaPancang & "ImagesPerbaikanKapal\" & FNameSebelumDoking1Old) Then
                            File.Delete(UrlNotaPancang & "ImagesPerbaikanKapal\" & FNameSebelumDoking1Old)
                        End If
                        Modul_RMP.Func.UploadFoto(FNameSebelumDoking1, UrlNotaPancang & "ImagesPerbaikanKapal\" & FotoName1)
                    Catch ex As Exception
                    End Try
                End If
                If FNameSebelumDoking2 <> FNameSebelumDoking2Old Then
                    Try
                        If File.Exists(UrlNotaPancang & "ImagesPerbaikanKapal\" & FNameSebelumDoking2Old) Then
                            File.Delete(UrlNotaPancang & "ImagesPerbaikanKapal\" & FNameSebelumDoking2Old)
                        End If
                        Modul_RMP.Func.UploadFoto(FNameSebelumDoking2, UrlNotaPancang & "ImagesPerbaikanKapal\" & FotoName2)
                    Catch ex As Exception
                    End Try
                End If
                If FNameSebelumDoking3 <> FNameSebelumDoking3Old Then
                    Try
                        If File.Exists(UrlNotaPancang & "ImagesPerbaikanKapal\" & FNameSebelumDoking3Old) Then
                            File.Delete(UrlNotaPancang & "ImagesPerbaikanKapal\" & FNameSebelumDoking3Old)
                        End If
                        Modul_RMP.Func.UploadFoto(FNameSebelumDoking3, UrlNotaPancang & "ImagesPerbaikanKapal\" & FotoName3)
                    Catch ex As Exception
                    End Try
                End If
                If FNameSebelumDoking4 <> FNameSebelumDoking4Old Then
                    Try
                        If File.Exists(UrlNotaPancang & "ImagesPerbaikanKapal\" & FNameSebelumDoking4Old) Then
                            File.Delete(UrlNotaPancang & "ImagesPerbaikanKapal\" & FNameSebelumDoking4Old)
                        End If
                        Modul_RMP.Func.UploadFoto(FNameSebelumDoking4, UrlNotaPancang & "ImagesPerbaikanKapal\" & FotoName4)
                    Catch ex As Exception
                    End Try
                End If
                If FNameSetelahDoking1 <> FNameSetelahDoking1Old Then
                    Try
                        If File.Exists(UrlNotaPancang & "ImagesPerbaikanKapal\" & FNameSetelahDoking1Old) Then
                            File.Delete(UrlNotaPancang & "ImagesPerbaikanKapal\" & FNameSetelahDoking1Old)
                        End If
                        Modul_RMP.Func.UploadFoto(FNameSetelahDoking1, UrlNotaPancang & "ImagesPerbaikanKapal\" & FotoName5)
                    Catch ex As Exception
                    End Try
                End If
                If FNameSetelahDoking2 <> FNameSetelahDoking2Old Then
                    Try
                        If File.Exists(UrlNotaPancang & "ImagesPerbaikanKapal\" & FNameSetelahDoking2Old) Then
                            File.Delete(UrlNotaPancang & "ImagesPerbaikanKapal\" & FNameSetelahDoking2Old)
                        End If
                        Modul_RMP.Func.UploadFoto(FNameSetelahDoking2, UrlNotaPancang & "ImagesPerbaikanKapal\" & FotoName6)
                    Catch ex As Exception
                    End Try
                End If
                If FNameSetelahDoking3 <> FNameSetelahDoking3Old Then
                    Try
                        If File.Exists(UrlNotaPancang & "ImagesPerbaikanKapal\" & FNameSetelahDoking3Old) Then
                            File.Delete(UrlNotaPancang & "ImagesPerbaikanKapal\" & FNameSetelahDoking3Old)
                        End If
                        Modul_RMP.Func.UploadFoto(FNameSetelahDoking3, UrlNotaPancang & "ImagesPerbaikanKapal\" & FotoName7)
                    Catch ex As Exception
                    End Try
                End If
                If FNameSetelahDoking4 <> FNameSetelahDoking4Old Then
                    Try
                        If File.Exists(UrlNotaPancang & "ImagesPerbaikanKapal\" & FNameSetelahDoking4Old) Then
                            File.Delete(UrlNotaPancang & "ImagesPerbaikanKapal\" & FNameSetelahDoking4Old)
                        End If
                        Modul_RMP.Func.UploadFoto(FNameSetelahDoking4, UrlNotaPancang & "ImagesPerbaikanKapal\" & FotoName8)
                    Catch ex As Exception
                    End Try
                End If

            IdPancang = CmbPancang.SelectedValue
            IdKapal = CmbKapal.SelectedValue

            aksi = ""
            SetCmbPancang()

            ClearInputAfterSave()
            EnabelTombol(False)
            BtnRefresh.Enabled = True
            BtnAdd.Enabled = True
            EnabelInput(False)
            CmbPancang.Enabled = True
            CmbKapal.Enabled = True

            CmbPancang.SelectedValue = IdPancang
            CmbKapal.SelectedValue = IdKapal
            ShowData()

            MsgBox("Berhasil Simpan Data", vbInformation, AT)
            Catch ex As Exception
                MsgBox(ex)
            End Try
        End If

        Me.Cursor = Cursors.Default
    End Sub
    Private Function SaveData(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        SaveData = False

        Dim MyCon As SqlConnection = Conn
        Dim MyConTrans As SqlTransaction = Trans
        Dim cmd As New SqlCommand

        With cmd
            .Connection = Conn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RMPApp..spSaveTrnDokingRelasiasiKapal"
            .Transaction = MyConTrans

            .Parameters.Add("@IdDtl", SqlDbType.Int).Value = CInt(TxtIdDtl.Text)
            .Parameters.Add("@IdPancang", SqlDbType.Int).Value = CmbPancang.SelectedValue
            .Parameters.Add("@IdKapal", SqlDbType.Int).Value = CmbKapal.SelectedValue
            .Parameters.Add("@IdKapten", SqlDbType.Int).Value = TxtIdKapten.Text
            .Parameters.Add("@TglMulaiDoking", SqlDbType.Date).Value = Format(Dtp1.Value, "yyyy-MM-dd")
            .Parameters.Add("@TglSelesaiDoking", SqlDbType.Date).Value = Format(Dtp2.Value, "yyyy-MM-dd")
            .Parameters.Add("@LokasiDoking", SqlDbType.VarChar, 100).Value = TxtLokasiDoking.Text
            .Parameters.Add("@RekomendasiPerbaikan", SqlDbType.VarChar, 200).Value = TxtRealPerbaikan.Text
            .Parameters.Add("@Realperbaikan", SqlDbType.VarChar, 200).Value = TxtRealPerbaikan.Text
            .Parameters.Add("@Cat", SqlDbType.Int).Value = If(String.IsNullOrEmpty(TxtCat.Text), 0, CInt(TxtCat.Text))
            .Parameters.Add("@TaliPalka", SqlDbType.Int).Value = If(String.IsNullOrEmpty(TxtTaliPalka.Text), 0, CInt(TxtTaliPalka.Text))
            .Parameters.Add("@Roll", SqlDbType.Int).Value = If(String.IsNullOrEmpty(TxtRoll.Text), 0, CInt(TxtRoll.Text))
            .Parameters.Add("@Semen", SqlDbType.Int).Value = If(String.IsNullOrEmpty(TxtSemen.Text), 0, CInt(TxtSemen.Text))
            .Parameters.Add("@Gading", SqlDbType.Int).Value = If(String.IsNullOrEmpty(TxtGading.Text), 0, CInt(TxtGading.Text))
            .Parameters.Add("@BiayaUpah", SqlDbType.Int).Value = If(String.IsNullOrEmpty(TxtBiayaUpah.Text), 0, CInt(TxtBiayaUpah.Text))
            .Parameters.Add("@BiayaSewa", SqlDbType.Int).Value = If(String.IsNullOrEmpty(TxtBiayaSewaGalang.Text), 0, CInt(TxtBiayaSewaGalang.Text))
            .Parameters.Add("@Paku", SqlDbType.Int).Value = If(String.IsNullOrEmpty(TxtPaku.Text), 0, CInt(TxtPaku.Text))
            .Parameters.Add("@Kayu", SqlDbType.Int).Value = If(String.IsNullOrEmpty(TxtKayu.Text), 0, CInt(TxtKayu.Text))
            .Parameters.Add("@TabungGas", SqlDbType.Int).Value = If(String.IsNullOrEmpty(TxtTabungGas.Text), 0, CInt(TxtTabungGas.Text))
            .Parameters.Add("@DaunKelapa", SqlDbType.Int).Value = If(String.IsNullOrEmpty(TxtDaunKelapa.Text), 0, CInt(TxtDaunKelapa.Text))
            .Parameters.Add("@TepungDamar", SqlDbType.Int).Value = If(String.IsNullOrEmpty(TxtTepungDamar.Text), 0, CInt(TxtTepungDamar.Text))
            .Parameters.Add("@LainNya", SqlDbType.Int).Value = If(String.IsNullOrEmpty(TxtLainNya.Text), 0, CInt(TxtLainNya.Text))
            .Parameters.Add("@Ket", SqlDbType.VarChar).Value = TxtKet.Text
            .Parameters.Add("@TotalBiaya", SqlDbType.Int).Value = CInt(TxtTotBiaya.Text)
            .Parameters.Add("@File1", SqlDbType.VarChar, 10).Value = File1
            .Parameters.Add("@File2", SqlDbType.VarChar, 10).Value = File2
            .Parameters.Add("@File3", SqlDbType.VarChar, 10).Value = File3
            .Parameters.Add("@File4", SqlDbType.VarChar, 10).Value = File4
            .Parameters.Add("@File5", SqlDbType.VarChar, 10).Value = File5
            .Parameters.Add("@File6", SqlDbType.VarChar, 10).Value = File6
            .Parameters.Add("@File7", SqlDbType.VarChar, 10).Value = File7
            .Parameters.Add("@File8", SqlDbType.VarChar, 10).Value = File8
            If FNameSebelumDoking1 <> FNameSebelumDoking1Old Then
                .Parameters.Add("@FlagChangeFotoSebelumDoking1", SqlDbType.Int).Value = 1
            Else
                .Parameters.Add("@FlagChangeFotoSebelumDoking1", SqlDbType.Int).Value = 0
            End If
            If FNameSebelumDoking2 <> FNameSebelumDoking2Old Then
                .Parameters.Add("@FlagChangeFotoSebelumDoking2", SqlDbType.Int).Value = 1
            Else
                .Parameters.Add("@FlagChangeFotoSebelumDoking2", SqlDbType.Int).Value = 0
            End If
            If FNameSebelumDoking3 <> FNameSebelumDoking3Old Then
                .Parameters.Add("@FlagChangeFotoSebelumDoking3", SqlDbType.Int).Value = 1
            Else
                .Parameters.Add("@FlagChangeFotoSebelumDoking3", SqlDbType.Int).Value = 0
            End If
            If FNameSebelumDoking4 <> FNameSebelumDoking4Old Then
                .Parameters.Add("@FlagChangeFotoSebelumDoking4", SqlDbType.Int).Value = 1
            Else
                .Parameters.Add("@FlagChangeFotoSebelumDoking4", SqlDbType.Int).Value = 0
            End If
            If FNameSetelahDoking1 <> FNameSetelahDoking1Old Then
                .Parameters.Add("@FlagChangeFotoSetelahDoking1", SqlDbType.Int).Value = 1
            Else
                .Parameters.Add("@FlagChangeFotoSetelahDoking1", SqlDbType.Int).Value = 0
            End If
            If FNameSetelahDoking2 <> FNameSetelahDoking2Old Then
                .Parameters.Add("@FlagChangeFotoSetelahDoking2", SqlDbType.Int).Value = 1
            Else
                .Parameters.Add("@FlagChangeFotoSetelahDoking2", SqlDbType.Int).Value = 0
            End If
            If FNameSetelahDoking3 <> FNameSetelahDoking3Old Then
                .Parameters.Add("@FlagChangeFotoSetelahDoking3", SqlDbType.Int).Value = 1
            Else
                .Parameters.Add("@FlagChangeFotoSetelahDoking3", SqlDbType.Int).Value = 0
            End If
            If FNameSetelahDoking4 <> FNameSetelahDoking4Old Then
                .Parameters.Add("@FlagChangeFotoSetelahDoking4", SqlDbType.Int).Value = 1
            Else
                .Parameters.Add("@FlagChangeFotoSetelahDoking4", SqlDbType.Int).Value = 0
            End If
            .Parameters.Add("@UserRMPAPP", SqlDbType.VarChar, 50).Value = ClsSession.UserID
            .Parameters.Add(New SqlParameter("@Flag", SqlDbType.TinyInt, 1, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .Parameters.Add(New SqlParameter("@FotoName1", SqlDbType.VarChar, 50, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .Parameters.Add(New SqlParameter("@FotoName2", SqlDbType.VarChar, 50, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .Parameters.Add(New SqlParameter("@FotoName3", SqlDbType.VarChar, 50, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .Parameters.Add(New SqlParameter("@FotoName4", SqlDbType.VarChar, 50, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .Parameters.Add(New SqlParameter("@FotoName5", SqlDbType.VarChar, 50, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .Parameters.Add(New SqlParameter("@FotoName6", SqlDbType.VarChar, 50, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .Parameters.Add(New SqlParameter("@FotoName7", SqlDbType.VarChar, 50, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .Parameters.Add(New SqlParameter("@FotoName8", SqlDbType.VarChar, 50, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))

            .ExecuteNonQuery()
        End With

        Try
            FotoName1 = cmd.Parameters("@FotoName1").Value
            FotoName2 = cmd.Parameters("@FotoName2").Value
            FotoName3 = cmd.Parameters("@FotoName3").Value
            FotoName4 = cmd.Parameters("@FotoName4").Value
            FotoName5 = cmd.Parameters("@FotoName5").Value
            FotoName6 = cmd.Parameters("@FotoName6").Value
            FotoName7 = cmd.Parameters("@FotoName7").Value
            FotoName8 = cmd.Parameters("@FotoName8").Value

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

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        ClearInput()
        EnabelInput(False)
        CmbPancang.Enabled = True
        CmbKapal.Enabled = True
        EnabelTombol(False)
        BtnRefresh.Enabled = True
        BtnAdd.Enabled = True
        aksi = ""
        SetCmbPancang()
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles BtnSblm4.Click
        Try
            OpenFileDialog1.Filter = "All Image Files|*.png;*.jpeg;*.jpg;*.JPG;*.JPEG|PDF Files|*.pdf"
            OpenFileDialog1.Title = "Select Image File"

            If OpenFileDialog1.ShowDialog = DialogResult.OK Then
                FNameSebelumDoking4 = OpenFileDialog1.FileName

                If FNameSebelumDoking4.Contains("pdf") Then
                    PicSblm4.Image = RMPApp.My.Resources.Resources.file
                Else
                    PicSblm4.Image = System.Drawing.Image.FromFile(FNameSebelumDoking4)
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
            Else
                File4 = ""
                FNameSebelumDoking4 = ""
                PicSblm4.Image = RMPApp.My.Resources.Resources.uploadtidakoke
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles BtnStlh4.Click
        Try
            OpenFileDialog1.Filter = "All Image Files|*.png;*.jpeg;*.jpg;*.JPG;*.JPEG|PDF Files|*.pdf"
            OpenFileDialog1.Title = "Select Image File"

            If OpenFileDialog1.ShowDialog = DialogResult.OK Then
                FNameSetelahDoking4 = OpenFileDialog1.FileName

                If FNameSetelahDoking4.Contains("pdf") Then
                    PicStlh4.Image = RMPApp.My.Resources.Resources.file
                Else
                    PicStlh4.Image = System.Drawing.Image.FromFile(FNameSetelahDoking4)
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
            Else
                File8 = ""
                FNameSetelahDoking4 = ""
                PicStlh4.Image = RMPApp.My.Resources.Resources.uploadtidakoke
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CmbKapal_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbKapal.SelectedValueChanged
        Dim dt As DataTable = New DataTable
        Dim d2 As DataTable = New DataTable
        Try
            TxtKapasitas.Clear()
            TxtKapten.Clear()
            TxtNoHpKapten.Clear()
            If aksi = "Add" Then
                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " select Kap,KaptenID from tblMstKapal where KapalID='" & CmbKapal.SelectedValue & "' ")
                For Each row As DataRow In dt.Rows
                    TxtKapasitas.Text = row("Kap")
                    TxtIdKapten.Text = row("KaptenID")
                Next
                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " select namakapten,nohpkapten from tblMstKaptenKapal where id='" & TxtIdKapten.Text & "' ")
                For Each row As DataRow In dt.Rows
                    TxtKapten.Text = row("namakapten")
                    TxtNoHpKapten.Text = row("nohpkapten")
                Next
            ElseIf CmbKapal.Text = "" Then
                TxtKapasitas.Clear()
                TxtKapten.Clear()
                TxtNoHpKapten.Clear()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CmbPancang_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbPancang.SelectedValueChanged
        If aksi = "Add" Then
            Try
                Dim dt As DataTable = New DataTable()
                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select KapalID,KapalName = Convert(Varchar(5),KapalID) + '. ' + KapalName from tblMstKapal where IDPancang='" & CmbPancang.SelectedValue & "' and KapalID in (select distinct IdKapal from TblTrnDokingKapal where NonActive=0 and TglRealisasi is null)")
                With CmbKapal
                    .DataSource = dt
                    .DisplayMember = "KapalName"
                    .ValueMember = "KapalID"
                    .SelectedIndex = -1
                End With
            Catch ex As Exception
            End Try
        Else
            Try
                Dim dt As DataTable = New DataTable()
                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select KapalID,KapalName = Convert(Varchar(5),KapalID) + '. ' + KapalName from tblMstKapal where IDPancang='" & CmbPancang.SelectedValue & "' and KapalID in ( select distinct IdKapal from TblTrnRealisasiDokingKapal )")
                With CmbKapal
                    .DataSource = dt
                    .DisplayMember = "KapalName"
                    .ValueMember = "KapalID"
                    .SelectedIndex = -1
                End With
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub TxtRekomPerbaikan_TextChanged(sender As Object, e As EventArgs) Handles TxtCat.TextChanged, TxtTaliPalka.TextChanged, TxtRoll.TextChanged, TxtSemen.TextChanged, TxtGading.TextChanged, TxtBiayaUpah.TextChanged, TxtBiayaSewaGalang.TextChanged, TxtPaku.TextChanged, TxtKayu.TextChanged, TxtTabungGas.TextChanged, TxtDaunKelapa.TextChanged, TxtTepungDamar.TextChanged, TxtTaliPalka.TextChanged, TxtSemen.TextChanged, TxtRoll.TextChanged, TxtGading.TextChanged, TxtCat.TextChanged
        Dim total As Integer
        Try
            If aksi = "Add" Or aksi = "Edit" Then
                total += If(String.IsNullOrEmpty(TxtCat.Text), 0, CInt(TxtCat.Text))
                total += If(String.IsNullOrEmpty(TxtTaliPalka.Text), 0, CInt(TxtTaliPalka.Text))
                total += If(String.IsNullOrEmpty(TxtRoll.Text), 0, CInt(TxtRoll.Text))
                total += If(String.IsNullOrEmpty(TxtGading.Text), 0, CInt(TxtGading.Text))
                total += If(String.IsNullOrEmpty(TxtSemen.Text), 0, CInt(TxtSemen.Text))
                total += If(String.IsNullOrEmpty(TxtBiayaUpah.Text), 0, CInt(TxtBiayaUpah.Text))
                total += If(String.IsNullOrEmpty(TxtBiayaSewaGalang.Text), 0, CInt(TxtBiayaSewaGalang.Text))
                total += If(String.IsNullOrEmpty(TxtPaku.Text), 0, CInt(TxtPaku.Text))
                total += If(String.IsNullOrEmpty(TxtKayu.Text), 0, CInt(TxtKayu.Text))
                total += If(String.IsNullOrEmpty(TxtTabungGas.Text), 0, CInt(TxtTabungGas.Text))
                total += If(String.IsNullOrEmpty(TxtDaunKelapa.Text), 0, CInt(TxtDaunKelapa.Text))
                total += If(String.IsNullOrEmpty(TxtTepungDamar.Text), 0, CInt(TxtTepungDamar.Text))
                total += If(String.IsNullOrEmpty(TxtLainNya.Text), 0, CInt(TxtLainNya.Text))

                TxtTotBiaya.Text = total
            End If
        Catch ex As Exception
            'MsgBox(ex)
        End Try
    End Sub



    Private Sub TxtRekomPerbaikan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtBiayaUpah.KeyPress, TxtBiayaSewaGalang.KeyPress, TxtPaku.KeyPress, TxtKayu.KeyPress, TxtTabungGas.KeyPress, TxtDaunKelapa.KeyPress, TxtTepungDamar.KeyPress, TxtLainNya.KeyPress, TxtTaliPalka.KeyPress, TxtSemen.KeyPress, TxtRoll.KeyPress, TxtGading.KeyPress, TxtCat.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtLainNya_TextChanged(sender As Object, e As EventArgs) Handles TxtLainNya.TextChanged
        If TxtLainNya.Text <> "" And (aksi = "Add" Or aksi = "Edit") Then
            TxtKet.Enabled = True
        Else
            TxtKet.Enabled = False
            TxtKet.Clear()
        End If
    End Sub

    Private Sub CmbPancang_KeyUp(sender As Object, e As KeyEventArgs) Handles CmbPancang.KeyUp
        UI.AutoCompleteCombo_KeyUp(CmbPancang, e)
    End Sub

    Private Sub CmbKapal_KeyUp(sender As Object, e As KeyEventArgs) Handles CmbKapal.KeyUp
        UI.AutoCompleteCombo_KeyUp(CmbKapal, e)
    End Sub
End Class