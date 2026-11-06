Imports System.Data.SqlClient
Imports System.IO
Imports C1.Win.C1FlexGrid
Imports Dapper
Imports Microsoft.Win32

Public Class FrmMstTokoNew
    Public pathFotoKTP As String = UrlMasterTTPancnag & "FotoToko\KTP"
    Public pathFotoRek As String = UrlMasterTTPancnag & "FotoToko\REK"
    Dim dt As DataTable = New DataTable()
    Dim cls As New ClsDatabaseConnection
    Dim Perintah, NamaKTP, NamaRek As String

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub FrmMstTokoNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Clear()
        Enable(False)
        SearchFG()
        HeaderFG()
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
        Perintah = ""
        picKTP.Image = Nothing
        picRek.Image = Nothing

        JamBuka.Format = DateTimePickerFormat.Custom
        JamBuka.CustomFormat = "HH:mm"
        JamTutup.Format = DateTimePickerFormat.Custom
        JamTutup.CustomFormat = "HH:mm"

        Dim dtval As String = "00:00"
        Dim dtval2 As String = "00:00"
        JamBuka.Value = Convert.ToDateTime(dtval)
        JamTutup.Value = Convert.ToDateTime(dtval2)

        fg.Rows.Count = 1
        chkNotActive.Checked = False
        txtID.Text = 0
        txtNamaToko.Text = ""
        txtAlamatToko.Text = ""
        txtKoordinat.Text = ""
        txtNamaPemilikToko.Text = ""
        txtNoHPPemilikToko.Text = ""
        txtNoRek.Text = ""
        txtNamaRek.Text = ""
        txtBank.Text = ""
        txtKTP.Text = ""

        btnAdd.Enabled = True
        btnRefresh.Enabled = True
        btnSave.Enabled = False
        btnEdit.Enabled = False
        btnCancel.Enabled = False
        btnExit.Enabled = True
    End Sub

    Private Sub Enable(Flag As Boolean)
        chkNotActive.Enabled = Flag
        txtNamaToko.Enabled = Flag
        txtAlamatToko.Enabled = Flag
        txtKoordinat.Enabled = Flag
        JamBuka.Enabled = Flag
        JamTutup.Enabled = Flag
        txtNamaPemilikToko.Enabled = Flag
        txtNoHPPemilikToko.Enabled = Flag
        txtNoRek.Enabled = Flag
        txtNamaRek.Enabled = Flag
        txtBank.Enabled = Flag
        txtKTP.Enabled = Flag
        btnChooseKTP.Enabled = Flag
        btnChooseRek.Enabled = Flag
    End Sub

    Public Sub HeaderFG()
        Dim txt As CellRange
        With fg
            .Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Regular)
            .Cols.Count = 22
            .Cols.Fixed = 1
            .AllowMergingFixed = AllowMergingEnum.FixedOnly
            .Styles.Fixed.BackColor = Color.FromArgb(240, 248, 254)
            .Styles.Alternate.BackColor = Color.White
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)
            .Styles.Frozen.BackColor = Color.FromArgb(240, 248, 254)
            .Styles.FrozenAlternate.BackColor = Color.FromArgb(240, 248, 254)

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 1
            .AllowMerging = AllowMergingEnum.RestrictAll
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Cols.Frozen = 2

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "NO" : .Cols(0).Width = 50 : .Cols(0).AllowMerging = False : .Cols(0).Name = "NO"
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "ID TOKO" : .Cols(1).TextAlign = TextAlignEnum.CenterCenter : .Cols(1).AllowMerging = False : .Cols(1).Name = "IDTOKO" : .Cols(1).Visible = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "NAMA TOKO" : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).AllowMerging = False : .Cols(2).Name = "NAMATOKO"
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "ALAMAT TOKO" : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).AllowMerging = False : .Cols(3).Name = "ALAMATTOKO"
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "NAMA PEMILIK TOKO" : .Cols(4).TextAlign = TextAlignEnum.LeftCenter : .Cols(4).AllowMerging = False : .Cols(4).Name = "NAMAPEMILIKTOKO"
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "NO HP PEMILIK TOKO" : .Cols(5).TextAlign = TextAlignEnum.CenterCenter : .Cols(5).AllowMerging = False : .Cols(5).Name = "NOHPPEMILIKTOKO"
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "JAM BUKA" : .Cols(6).TextAlign = TextAlignEnum.CenterCenter : .Cols(6).AllowMerging = False : .Cols(6).Name = "JAMBUKA"
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "JAM TUTUP" : .Cols(7).TextAlign = TextAlignEnum.CenterCenter : .Cols(7).AllowMerging = False : .Cols(7).Name = "JAMTUTUP"
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "KOORDINAT TOKO" : .Cols(8).TextAlign = TextAlignEnum.CenterCenter : .Cols(8).AllowMerging = False : .Cols(8).Name = "KOORDINATTOKO"
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "NO REK PEMILIK TOKO" : .Cols(9).TextAlign = TextAlignEnum.CenterCenter : .Cols(9).AllowMerging = False : .Cols(9).Name = "NOREKPEMILIKTOKO"
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "NAMA REK PEMILIK TOKO" : .Cols(10).TextAlign = TextAlignEnum.LeftCenter : .Cols(10).AllowMerging = False : .Cols(10).Name = "NAMAREKPEMILIKTOKO"
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "JENIS BANK" : .Cols(11).TextAlign = TextAlignEnum.CenterCenter : .Cols(11).AllowMerging = False : .Cols(11).Name = "JENISBANK"
            txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "ACTIVED" : .Cols(12).TextAlign = TextAlignEnum.CenterCenter : .Cols(12).AllowMerging = False : .Cols(12).Name = "ACTIVED" : .Cols(12).Visible = False
            txt = .GetCellRange(0, 13, 0, 13) : txt.Data = "CREATED BY" : .Cols(13).TextAlign = TextAlignEnum.CenterCenter : .Cols(13).AllowMerging = False : .Cols(13).Name = "CREATEDBY"
            txt = .GetCellRange(0, 14, 0, 14) : txt.Data = "CREATED DATE" : .Cols(14).TextAlign = TextAlignEnum.CenterCenter : .Cols(14).AllowMerging = False : .Cols(14).Name = "CREATEDDATE"
            txt = .GetCellRange(0, 15, 0, 15) : txt.Data = "CREATED COMP" : .Cols(15).TextAlign = TextAlignEnum.CenterCenter : .Cols(15).AllowMerging = False : .Cols(15).Name = "CREATEDCOMP"
            txt = .GetCellRange(0, 16, 0, 16) : txt.Data = "UPDATED BY" : .Cols(16).TextAlign = TextAlignEnum.CenterCenter : .Cols(16).AllowMerging = False : .Cols(16).Name = "UPDATEDBY"
            txt = .GetCellRange(0, 17, 0, 17) : txt.Data = "UPDATED DATE" : .Cols(17).TextAlign = TextAlignEnum.CenterCenter : .Cols(17).AllowMerging = False : .Cols(17).Name = "UPDATEDDATE"
            txt = .GetCellRange(0, 18, 0, 18) : txt.Data = "UPDATED COMP" : .Cols(18).TextAlign = TextAlignEnum.CenterCenter : .Cols(18).AllowMerging = False : .Cols(18).Name = "UPDATEDCOMP"
            txt = .GetCellRange(0, 19, 0, 19) : txt.Data = "KTP" : .Cols(19).TextAlign = TextAlignEnum.CenterCenter : .Cols(19).AllowMerging = False : .Cols(19).Name = "KTP" : .Cols(19).Visible = False
            txt = .GetCellRange(0, 20, 0, 20) : txt.Data = "FILE KTP" : .Cols(20).TextAlign = TextAlignEnum.CenterCenter : .Cols(20).AllowMerging = False : .Cols(20).Name = "FILEKTP" : .Cols(20).Visible = False
            txt = .GetCellRange(0, 21, 0, 21) : txt.Data = "FILE REK" : .Cols(21).TextAlign = TextAlignEnum.CenterCenter : .Cols(21).AllowMerging = False : .Cols(21).Name = "FILEREK" : .Cols(21).Visible = False

            .AutoSizeCols()
        End With
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Clear()
        Enable(False)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Enable(True)

        btnAdd.Enabled = False
        btnRefresh.Enabled = False
        btnSave.Enabled = True
        btnEdit.Enabled = False
        btnCancel.Enabled = True
        btnExit.Enabled = True
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Enable(False)

        btnAdd.Enabled = True
        btnRefresh.Enabled = True
        btnSave.Enabled = False
        btnEdit.Enabled = False
        btnCancel.Enabled = True
        btnExit.Enabled = True

        ShowData()
    End Sub

    Private Sub ShowData()
        Dim i As Integer = 1
        Dim sql As String = ""

        If ChkGetAllData.Checked = True Then
            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select * from vwMstTokoPoint order by nama_toko,actived DESC")
        Else
            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select * from vwMstTokoPoint where actived=1 order by nama_toko asc")
        End If

        If dt.Rows.Count > 0 Then
            With fg
                Call ui.HapusGrid(1, fg)
                For Each dr As DataRow In dt.Rows
                    .AddItem(i)

                    .Item(i, "IDTOKO") = dr!id
                    .Item(i, "NAMATOKO") = dr!nama_toko
                    .Item(i, "ALAMATTOKO") = dr!alamat_toko
                    .Item(i, "NAMAPEMILIKTOKO") = dr!nama_pemilik_toko
                    .Item(i, "NOHPPEMILIKTOKO") = dr!nomor_hp_toko
                    .Item(i, "JAMBUKA") = dr!jam_buka
                    .Item(i, "JAMTUTUP") = dr!jam_tutup
                    .Item(i, "KOORDINATTOKO") = dr!koordinat_toko
                    .Item(i, "ACTIVED") = dr!actived
                    .Item(i, "NOREKPEMILIKTOKO") = IIf(IsDBNull(dr!NoRekToko), "", dr!NoRekToko)
                    .Item(i, "NAMAREKPEMILIKTOKO") = IIf(IsDBNull(dr!NamaRekToko), "", dr!NamaRekToko)
                    .Item(i, "JENISBANK") = IIf(IsDBNull(dr!Bank), "", dr!Bank)
                    .Item(i, "CREATEDBY") = dr!created_by
                    .Item(i, "CREATEDDATE") = dr!created_date
                    .Item(i, "CREATEDCOMP") = dr!created_comp
                    .Item(i, "UPDATEDBY") = dr!updated_by
                    .Item(i, "UPDATEDDATE") = dr!updated_date
                    .Item(i, "UPDATEDCOMP") = dr!updated_comp
                    .Item(i, "KTP") = dr!NoKTP_Toko
                    .Item(i, "FILEKTP") = dr!FileKTP
                    .Item(i, "FILEREK") = dr!FileRek

                    If .Item(i, "ACTIVED") = 0 Then
                        .Rows(i).StyleNew.ForeColor = Color.Red
                    End If

                    i = i + 1
                Next
                .AutoSizeCols()
            End With
        Else
            Call ui.HapusGrid(1, fg)
            MsgBox("No Data !", MsgBoxStyle.Exclamation, AT)
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim Actived As Integer

            If chkNotActive.Checked = True Then
                Actived = 0
            Else
                Actived = 1
            End If

            Dim obj As New Data With {.ID = Val(txtID.Text),
                .NamaToko = txtNamaToko.Text,
                .AlamatToko = txtAlamatToko.Text,
                .NamaPemilikToko = txtNamaPemilikToko.Text,
                .NoHPPemilikToko = txtNoHPPemilikToko.Text,
                .JamBuka = JamBuka.Value,
                .JamTutup = JamTutup.Value,
                .Koordinat = txtKoordinat.Text,
                .Actived = Actived,
                .CreatedBy = ClsSession.UserID,
                .NoRekToko = txtNoRek.Text,
                .NamaRekToko = txtNamaRek.Text,
                .Bank = txtBank.Text,
                .NoKTP = txtKTP.Text,
                .FileKTP = txtFileKTP.Text,
                .FileRek = txtFileRek.Text}

            Dim result = (SaveData(obj))

            If Perintah = "Edit" Then
                MessageBox.Show("Save Completed !", "Edit Data - " & AT, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If result > 0 Then
                    MessageBox.Show("Save Completed !", "Save Data - " & AT, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MsgBox("Simpan Data Gagal !!", vbExclamation, "Save Data - " & AT)
                End If
            End If

            Call Clear()
            Enable(False)
            ShowData()
        Catch ex As Exception
            MsgBox("Error !" + ex.Message, MsgBoxStyle.Exclamation)
            Exit Sub
        End Try
    End Sub

    Public Class Data
        Public Property ID As Integer
        Public Property NamaToko As String
        Public Property AlamatToko As String
        Public Property NamaPemilikToko As String
        Public Property NoHPPemilikToko As String
        Public Property JamBuka As DateTime
        Public Property JamTutup As DateTime
        Public Property Koordinat As String
        Public Property Actived As Boolean
        Public Property CreatedBy As String
        Public Property NoRekToko As String
        Public Property NamaRekToko As String
        Public Property Bank As String
        Public Property NoKTP As String
        Public Property FileKTP As String
        Public Property FileRek As String
    End Class

    Public Function SaveData(ByVal Obj As Data) As Integer
        Dim result As Integer
        Dim KTP = txtFileKTP.Text
        Dim REK = txtFileRek.Text

        Using cn As SqlConnection = New SqlConnection(StrConnRMPApp)
            If cn.State = ConnectionState.Closed Then cn.Open()
            Dim dParamsObject = New DynamicParameters(Obj)
            dParamsObject.Add("@Flag", 0, direction:=ParameterDirection.InputOutput)

            Using Trx As SqlTransaction = cn.BeginTransaction
                Try
                    If picKTP.Image IsNot Nothing And picRek.Image IsNot Nothing Then
                        cn.Execute("spSaveMstToko", dParamsObject, Trx, commandType:=CommandType.StoredProcedure)
                        result = dParamsObject.Get(Of Integer)("@Flag")

                        If result > 0 Then
                            SaveImageKTP(pathFotoKTP & "\" & KTP & ".jpeg", picKTP.Image)
                            SaveImageREK(pathFotoRek & "\" & REK & ".jpeg", picRek.Image)
                        End If

                        Trx.Commit()

                        If Not System.IO.File.Exists(pathFotoKTP & KTP) Then
                            If (SaveImageKTP(pathFotoKTP & "\" & KTP & ".jpeg", picKTP.Image)) Then
                                Debug.WriteLine("OK")
                                MsgBox("Save Foto KTP Success !", MsgBoxStyle.Information, AT)
                            End If
                        End If

                        If Not System.IO.File.Exists(pathFotoRek & REK) Then
                            If (SaveImageREK(pathFotoRek & "\" & REK & ".jpeg", picRek.Image)) Then
                                Debug.WriteLine("OK")
                                MsgBox("Save Foto Rek Success !", MsgBoxStyle.Information, AT)
                            End If
                        End If

                        Clear()

                        If System.IO.File.Exists(pathFotoKTP & KTP) Then
                            MsgBox("File KTP exist !", MsgBoxStyle.Exclamation, AT)
                        End If

                        If System.IO.File.Exists(pathFotoRek & REK) Then
                            MsgBox("File REK exist !", MsgBoxStyle.Exclamation, AT)
                        End If

                        ShowData()
                    Else
                        result = dParamsObject.Get(Of Integer)("@Flag")
                        Trx.Commit()
                    End If
                Catch ex As Exception
                    'Trx.Rollback()
                    'MessageBox.Show(ex.Message)
                End Try
            End Using
        End Using
        Return result
    End Function

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If txtID.Text = "" Then
            MsgBox("Tidak ada data yang bisa diedit !" & vbNewLine & "Silahkan double klik data pada tabel untuk mengedit data !", MsgBoxStyle.Exclamation, AT)
            Exit Sub
        End If

        Enable(True)
        Perintah = "Edit"
        btnAdd.Enabled = False
        btnRefresh.Enabled = False
        btnSave.Enabled = True
        btnEdit.Enabled = False
        btnCancel.Enabled = True
        btnExit.Enabled = True
    End Sub

    Private Sub fg_DoubleClick(sender As Object, e As EventArgs) Handles fg.DoubleClick
        With fg
            If .Item(.Row, "ACTIVED") = 0 Then
                chkNotActive.Checked = True
            Else
                chkNotActive.Checked = False
            End If

            txtID.Text = .Item(.Row, "IDTOKO")
            txtNamaToko.Text = .Item(.Row, "NAMATOKO")
            txtAlamatToko.Text = .Item(.Row, "ALAMATTOKO")
            txtKoordinat.Text = .Item(.Row, "KOORDINATTOKO")
            txtNamaPemilikToko.Text = .Item(.Row, "NAMAPEMILIKTOKO")
            txtNoHPPemilikToko.Text = .Item(.Row, "NOHPPEMILIKTOKO")
            txtNoRek.Text = .Item(.Row, "NOREKPEMILIKTOKO")
            txtNamaRek.Text = .Item(.Row, "NAMAREKPEMILIKTOKO")
            txtBank.Text = .Item(.Row, "JENISBANK")
            txtKTP.Text = .Item(.Row, "KTP")
            txtFileRek.Text = .Item(.Row, "FILEKTP")
            txtFileRek.Text = .Item(.Row, "FILEREK")
            NamaKTP = pathFotoKTP & "\" & .Item(.Row, "FILEKTP") & ".Jpeg"
            NamaRek = pathFotoRek & "\" & .Item(.Row, "FILEREK") & ".Jpeg"

            If File.Exists(NamaKTP) = True Then
                picKTP.Image = System.Drawing.Image.FromFile(NamaKTP)
            End If

            If File.Exists(NamaRek) = True Then
                picRek.Image = System.Drawing.Image.FromFile(NamaRek)
            End If

            Dim dtval As String = .Item(.Row, "JAMBUKA")
            Dim dtval2 As String = .Item(.Row, "JAMTUTUP")
            JamBuka.Value = Convert.ToDateTime(dtval)
            JamTutup.Value = Convert.ToDateTime(dtval2)
        End With

        btnEdit.Enabled = True
    End Sub

    Private Sub btnChooseKTP_Click(sender As Object, e As EventArgs) Handles btnChooseKTP.Click
        OpenFileDialog.Filter = "All Image Files|*.png;*.jpeg;*.jpg;*.JPG;*.JPEG;*.JFIF;.*.jfif"
        OpenFileDialog.Title = "Select Image File"

        If OpenFileDialog.ShowDialog = DialogResult.OK Then
            Dim pdfLog As String = txtNamaPemilikToko.Text & "@" & txtKTP.Text
            txtFileKTP.Text = pdfLog
            NamaKTP = OpenFileDialog.FileName
            On Error Resume Next
            picKTP.Image = System.Drawing.Image.FromFile(NamaKTP)
        Else
            picKTP.Image = RMPApp.My.Resources.Resources.uploadtidakoke
        End If
    End Sub

    Private Sub btnChooseRek_Click(sender As Object, e As EventArgs) Handles btnChooseRek.Click
        OpenFileDialog.Filter = "All Image Files|*.png;*.jpeg;*.jpg;*.JPG;*.JPEG;*.JFIF;.*.jfif"
        OpenFileDialog.Title = "Select Image File"

        If OpenFileDialog.ShowDialog = DialogResult.OK Then
            Dim pdfLog As String = txtNamaRek.Text & "@" & txtNoRek.Text
            txtFileRek.Text = pdfLog
            NamaRek = OpenFileDialog.FileName
            On Error Resume Next
            picRek.Image = System.Drawing.Image.FromFile(NamaRek)
        Else
            picRek.Image = RMPApp.My.Resources.Resources.uploadtidakoke
        End If
    End Sub


    Function SaveImageKTP(filename As String, image As Image) As Boolean
        Dim mySource As New Bitmap(image.Width, image.Height)
        Dim grfx As Graphics = Graphics.FromImage(mySource)
        grfx.DrawImageUnscaled(image, Point.Empty)
        grfx.Dispose()
        mySource.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg)
        mySource.Dispose()
        Return True
    End Function

    Function SaveImageREK(filename As String, image As Image) As Boolean
        Dim mySource As New Bitmap(image.Width, image.Height)
        Dim grfx As Graphics = Graphics.FromImage(mySource)
        grfx.DrawImageUnscaled(image, Point.Empty)
        grfx.Dispose()
        mySource.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg)
        mySource.Dispose()
        Return True
    End Function
End Class