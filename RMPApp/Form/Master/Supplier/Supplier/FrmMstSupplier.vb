Imports System.Data.SqlClient
Imports System.Windows.Documents

Public Class FrmMstSupplier
    Dim FolderLokal As String = cls_Webdav.WebDavGENSupplierFolder
    Private perintah As String = ""
    Private daftarLampiran As New List(Of String) ' path file lampiran yang dipilih user (belum disimpan ke server)

    Private Sub FrmMstSupplier_v2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call LoadComboBoxData()
        Call KondisiAwal()
        Call SetTabIndex()

        ClsFlexGrid.ApplyStyle(ocxAttachment)
        ClsFlexGrid.SetEditableColumns(ocxAttachment, "ocxRemarkAttachment")
    End Sub

#Region "Setup Awal"

    Private Sub LoadComboBoxData()
        Combo.SetBahanBaku(CboBahanBaku)
        Combo.DivBlockKav(CboKodeDivKav)

        cmbKategori.Items.Clear()
        cmbKategori.Items.Add("Petani")
        cmbKategori.Items.Add("Pelangsir")
        cmbKategori.Items.Add("Pengepul/Pembeli")
        cmbKategori.Items.Add("Toke")
        cmbKategori.Items.Add("Petani dan Pelangsir")
        cmbKategori.Items.Add("Petani dan Pembeli/Pengepul")
        cmbKategori.Items.Add("Petani, Pelangsir dan Pembeli/Pengepul")
    End Sub

    Private Sub KondisiAwal()
        Call ControlEnabled(False)
        Call CmdEnabled(True)
        Call ClearData()

        perintah = ""
    End Sub

    Private Sub SetTabIndex()
        TxtNamaSup.TabIndex = 900
        TxtNoKTP.TabIndex = 901
        TxtNamaNpwp.TabIndex = 902
        TxtNoNpwp.TabIndex = 903
        TxtNoHp.TabIndex = 904
        TxtAlamatSup.TabIndex = 905

        CboKodeDivKav.TabIndex = 906
        CboBahanBaku.TabIndex = 907
        cmbJenisSupplier.TabIndex = 908
        cmbKategori.TabIndex = 909
        txtketerangan.TabIndex = 910
    End Sub

#End Region

#Region "Pengaturan Tombol & Enable Control"

    Private Sub ControlEnabled(flag As Boolean)
        TxtNamaSup.Enabled = flag
        TxtWilayah.Enabled = flag
        CboKodeDivKav.Enabled = flag
        TxtAlamatSup.Enabled = flag
        CboBahanBaku.Enabled = flag
        TxtNoNpwp.Enabled = flag
        TxtNamaNpwp.Enabled = flag
        TxtNoKTP.Enabled = flag
        TxtNoHp.Enabled = flag
        cmbJenisSupplier.Enabled = flag
        cmbKategori.Enabled = flag
        txtketerangan.Enabled = flag
        ChkTdkAktif.Enabled = flag
        ChkNpwp.Enabled = flag
        ChkToke.Enabled = flag
        chkRelasiPcgSub.Enabled = flag
        chkKomisiToke.Enabled = flag
        rdPTCV.Enabled = flag
        rdPribadi.Enabled = flag
        rdCash.Enabled = flag
        chkPPHUMKM.Enabled = flag
        btnFileChoose.Enabled = flag
    End Sub

    Private Sub CmdEnabled(flag As Boolean)
        btnAdd.Enabled = flag
        btnEdit.Enabled = flag
        btnDelete.Enabled = flag
        btnFind.Enabled = flag
        btnExit.Enabled = flag
        btnSave.Enabled = Not flag
        btnCancel.Enabled = Not flag
    End Sub

#End Region

#Region "Clear / Tampilkan / Ambil Data"

    Private Sub ClearData()
        Call ClearControls(Panel3)

        rdPribadi.Checked = True

        daftarLampiran.Clear()

        ocxAttachment.Rows.Count = 1
            ocxAttachment.Rows.Count = 2
    End Sub

    Private Sub ClearControls(container As Control)
        For Each ctrl As Control In container.Controls
            Select Case True
                Case TypeOf ctrl Is TextBoxBase ' TextBox & MaskedTextBox
                    CType(ctrl, TextBoxBase).Clear()
                Case TypeOf ctrl Is ComboBox
                    Dim cbo As ComboBox = CType(ctrl, ComboBox)
                    cbo.SelectedIndex = -1
                    cbo.Text = ""
                Case TypeOf ctrl Is CheckBox
                    CType(ctrl, CheckBox).Checked = False
                Case TypeOf ctrl Is RadioButton
                    CType(ctrl, RadioButton).Checked = False
                Case TypeOf ctrl Is DateTimePicker
                    CType(ctrl, DateTimePicker).Value = Now
            End Select

            If ctrl.HasChildren Then
                Call ClearControls(ctrl)
            End If
        Next
    End Sub

    Public Sub ShowData(KodeSup As String)
        Dim dt As New DataTable
        Dim sql As String

        sql = "Select * from vwMstSupplier where KodeSup='" & KodeSup & "'"

        dt = DB.ExecuteQuery(StrConnAccounting, sql)

        If dt.Rows.Count > 0 Then
            Call ClearData()

            For Each row As DataRow In dt.Rows
                TxtRmSupId.Text = row("RMSupplierID").ToString()
                txtkodesup.Text = row("KodeSup").ToString()
                TxtNamaSup.Text = row("NamaSup").ToString()
                TxtNoKTP.Text = row("KTP").ToString()
                TxtNoNpwp.Text = row("NoNPWP").ToString()
                TxtNamaNpwp.Text = row("NamaNPWP").ToString()
                TxtNoHp.Text = row("NoHp").ToString()
                TxtWilayah.Text = row("WilSP").ToString()
                CboKodeDivKav.Text = row("DivBlokKav").ToString()
                TxtAlamatSup.Text = row("Alamat").ToString()
                CboBahanBaku.SelectedValue = If(IsDBNull(row("KodeJenisBahanBaku")), Nothing, CInt(row("KodeJenisBahanBaku")))
                cmbKategori.Text = row("KategoriSupplier").ToString()
                cmbJenisSupplier.Text = row("JenisSupplier").ToString()
                txtketerangan.Text = row("Keterangan").ToString()
                ChkTdkAktif.Checked = row("NotActive")
                ChkNpwp.Checked = row("ChkNpwp")
                ChkToke.Checked = row("ChkToke")
                chkRelasiPcgSub.Checked = row("FlagRelasiSub")
                chkKomisiToke.Checked = row("FlagKomisiToke")
                rdPTCV.Checked = row("PTCV")
                rdPribadi.Checked = row("Pribadi")
                rdCash.Checked = row("Cash")
                chkPPHUMKM.Checked = row("IndPPHUMKM")

                perintah = ""
            Next

            Call ShowDataAttachment()
        Else
            MsgBoxCustom.Show("Data tidak ditemukan", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
        End If
    End Sub

    Private Sub ShowDataAttachment()
        Dim sql As String
        sql = "SELECT * FROM tblGENMstSupplierAttachment WHERE SupplierID='" & txtkodesup.Text & "'"
        Me.Cursor = Cursors.WaitCursor
        ocxAttachment.Rows.Count = 2
        Try
            Dim dtTable As DataTable = DB.ExecuteQuery(StrConnDBPancang, sql)
            If dtTable.Rows.Count > 0 Then
                Dim row As Integer = 1
                ocxAttachment.Rows.Count = 1
                ocxAttachment.Rows(0).Height = 25

                For i As Integer = 0 To dtTable.Rows.Count - 1
                    Dim dr As DataRow = dtTable.Rows(i)

                    With ocxAttachment
                        .AddItem("")

                        .Item(row, "ocxNo") = i + 1
                        .Item(row, "ocxFileID") = dr!FileID
                        .Item(row, "ocxTagAttachment") = ""
                        .Item(row, "ocxFileAttachment") = dr!FileAttachment
                        .Item(row, "ocxRemarkAttachment") = dr!AttachmentDescriptions
                        row += 1
                    End With
                Next

                ocxAttachment.AddItem("")
            End If
        Catch ex As Exception
            Call MsgBoxCustom.Show("Supplier Attachment Error" & vbCrLf &
                                    ex.Message & "(ShowDataAttachment)", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

#End Region

#Region "Validasi"

    Private Function ValidasiInput() As Boolean
        If TxtNamaSup.Text = "" Then
            MsgBoxCustom.Show("Nama Supplier harus diisi", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Return False
        End If

        If TxtWilayah.Text = "" Then
            MsgBoxCustom.Show("Wilayah Supplier harus diisi", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Return False
        End If

        If CboKodeDivKav.SelectedIndex = -1 Then
            MsgBoxCustom.Show("Kode Divisi/Blok/Kavling harus dipilih", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Return False
        End If

        If cmbJenisSupplier.Text = "" Then
            MsgBoxCustom.Show("Jenis Supplier harus dipilih", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Return False
        End If

        If cmbKategori.Text = "" Then
            MsgBoxCustom.Show("Kategori Supplier harus diisi", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Return False
        End If

        Return True
    End Function

#End Region

#Region "Simpan ke Database"
    Private Function SaveDataHdr(conn As SqlConnection,
                          trans As SqlTransaction,
                          ByRef pesanError As String,
                              ByRef KodeSup As String) As Boolean

        Dim cmd As New SqlCommand

        Try
            With cmd
                .Connection = conn
                .Transaction = trans
                .CommandType = System.Data.CommandType.StoredProcedure
                .CommandText = "spMstSupplier"

                .Parameters.Add("@Perintah", SqlDbType.VarChar, 15).Value = perintah

                Dim pKodeSup As New SqlParameter("@KodeSup", SqlDbType.VarChar, 20)
                pKodeSup.Direction = ParameterDirection.InputOutput
                pKodeSup.Value = txtkodesup.Text
                .Parameters.Add(pKodeSup)

                .Parameters.Add("@NamaSup", SqlDbType.VarChar, 50).Value = TxtNamaSup.Text.Trim().ToUpper().Replace("'", "`")
                .Parameters.Add("@GroupSup", SqlDbType.Int).Value = 13

                .Parameters.Add("@KodeJenisBahanBaku", SqlDbType.Int).Value =
             If(CboBahanBaku.SelectedValue IsNot Nothing,
                CInt(CboBahanBaku.SelectedValue), 0)

                .Parameters.Add("@KodeNota", SqlDbType.VarChar, 15).Value = "KB"
                .Parameters.Add("@WilSP", SqlDbType.VarChar, 200).Value = TxtWilayah.Text.Trim()
                .Parameters.Add("@DivBlokKav", SqlDbType.VarChar, 200).Value = CboKodeDivKav.Text

                .Parameters.Add("@KTP", SqlDbType.VarChar, 20).Value = TxtNoKTP.Text.Replace(" ", "")
                .Parameters.Add("@NoNPWP", SqlDbType.VarChar, 50).Value = TxtNoNpwp.Text.Replace(" ", "")

                ' Ukuran disesuaikan dengan definisi SP: VARCHAR(100)
                .Parameters.Add("@NamaNPWP", SqlDbType.VarChar, 100).Value = TxtNamaNpwp.Text
                .Parameters.Add("@chkNPWP", SqlDbType.Bit).Value = ChkNpwp.Checked

                ' Tipe disesuaikan dengan definisi SP: BIT
                .Parameters.Add("@Kanal", SqlDbType.Bit).Value = False
                .Parameters.Add("@Laut", SqlDbType.Bit).Value = False

                .Parameters.Add("@NoHP", SqlDbType.VarChar, 20).Value = TxtNoHp.Text.Replace(" ", "")
                .Parameters.Add("@NotActive", SqlDbType.Bit).Value = ChkTdkAktif.Checked
                .Parameters.Add("@KategoriSupplier", SqlDbType.VarChar, 100).Value = cmbKategori.Text

                .Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
                .Parameters.Add("@LastUpdatedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID

                .Parameters.Add("@Alamat", SqlDbType.VarChar, 500).Value = TxtAlamatSup.Text.Trim().Replace("'", "`")

                .Parameters.Add("@chkToke", SqlDbType.Bit).Value = ChkToke.Checked
                .Parameters.Add("@RemarkInActive", SqlDbType.VarChar, 100).Value = txtketerangan.Text

                ' Ukuran disesuaikan dengan definisi SP: VARCHAR(500)
                .Parameters.Add("@Keterangan", SqlDbType.VarChar, 500).Value = txtketerangan.Text

                .Parameters.Add("@PTCV", SqlDbType.Int).Value = If(rdPTCV.Checked, 1, 0)
                .Parameters.Add("@Pribadi", SqlDbType.Int).Value = If(rdPribadi.Checked, 1, 0)
                .Parameters.Add("@Cash", SqlDbType.Int).Value = If(rdCash.Checked, 1, 0)

                .Parameters.Add("@FlagRelasiPcgSub", SqlDbType.Int).Value = If(chkRelasiPcgSub.Checked, 1, 0)

                ' Ukuran ditambahkan sesuai definisi SP: VARCHAR(20)
                .Parameters.Add("@JenisSupplier", SqlDbType.VarChar, 20).Value = cmbJenisSupplier.Text
                .Parameters.Add("@KomisiToke", SqlDbType.Bit).Value = chkKomisiToke.Checked
                .Parameters.Add("@IndPPHUMKM", SqlDbType.Bit).Value = chkPPHUMKM.Checked

                .ExecuteNonQuery()

                KodeSup = .Parameters("@KodeSup").Value.ToString()
                txtkodesup.Text = KodeSup
            End With

            Return True

        Catch ex As Exception
            ' RAISERROR di SP (validasi KTP/HP/permission, atau error SQL yang di-re-throw
            ' dari blok CATCH) sudah otomatis menjadi ex.Message di sini, jadi tidak perlu
            ' lagi baca cmd.Parameters("@Error") secara terpisah.
            pesanError = ex.Message
            Return False

        Finally
            cmd.Dispose()
        End Try

    End Function

#End Region

#Region "Tombol Aksi"

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Call ClearData()
        Call ControlEnabled(True)
        Call CmdEnabled(False)
        perintah = "Add"
        TxtNamaSup.Focus()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If Trim(txtkodesup.Text) = "" Then
            MsgBoxCustom.Show("Silahkan cari data (tombol Find) terlebih dahulu, baru klik Edit", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Exit Sub
        End If

        Call ControlEnabled(True)
        Call CmdEnabled(False)
        perintah = "Edit"
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Call KondisiAwal()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Trim(txtkodesup.Text) = "" Then
            MsgBoxCustom.Show("Silahkan cari data (tombol Find) yang akan dihapus terlebih dahulu", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Exit Sub
        End If

        ' Konfirmasi penghapusan data
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        FrmMain.BukaMenu(FrmMstSupplierShow, FrmMain.mnuMstSupplierSupplier)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidasiInput() Then Exit Sub
        If Not ValidasiID() Then Exit Sub

        Me.Cursor = Cursors.WaitCursor

        Dim koneksi As SqlConnection = DB.OpenConnection(StrConnAccounting)
        Dim koneksiBPI As SqlConnection = DB.OpenConnection(StrConnDBPancang)
        Dim transaksi As SqlTransaction = Nothing
        Dim transaksiBPI As SqlTransaction = Nothing
        Dim pesanError As String = ""
        Dim KodeSup As String = ""

        Try
            transaksi = koneksi.BeginTransaction()
            transaksiBPI = koneksiBPI.BeginTransaction()

            If Not SaveDataHdr(koneksi, transaksi, pesanError, KodeSup) Then
                transaksi.Rollback()
                transaksiBPI.Rollback()
                MsgBoxCustom.Show("Simpan data gagal." & vbCrLf & pesanError, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
                Exit Sub
            End If

            For i As Integer = 1 To ocxAttachment.Rows.Count - 1
                If Trim(ocxAttachment.Item(i, "ocxFileAttachment")) <> "" Then
                    If SaveDataAttachment(koneksiBPI, transaksiBPI, i) = 0 Then
                        transaksi.Rollback()
                        transaksiBPI.Rollback()
                        Call MsgBoxCustom.Show("Simpan data attachment gagal." & vbCrLf &
                                                    "(GEN_spMstSupplierAttachmentSave)", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
                        Exit Sub
                    End If
                End If
            Next

            Call Func.IsCreateFolderExists(Application.StartupPath & "\" & FolderLokal & "\" & Replace(Trim(txtkodesup.Text), "/", "-"))

            'Proses Upload File Setelah Commit
            For i As Integer = 1 To ocxAttachment.Rows.Count - 1
                If Trim(ocxAttachment.Item(i, "ocxTagAttachment")) <> "" Then
                    Dim ok As Boolean = ClsWebDAV.UploadFileWebDav(Trim(ocxAttachment.Item(i, "ocxTagAttachment")), FolderLokal, Trim(txtkodesup.Text), Trim(ocxAttachment.Item(i, "ocxFileAttachment")))
                    If Not ok Then
                        transaksi.Rollback()
                        transaksiBPI.Rollback()
                        MsgBoxCustom.Show("Gagal menyimpan lampiran dokumen supplier." & vbCrLf &
                                              "Proses upload attachment tidak berhasil. Silakan periksa koneksi atau file yang diunggah, kemudian coba kembali.",
                                              MsgBoxCustom.ButtonType.OK,
                                              MsgBoxCustom.IconType.Error)
                        Exit Sub
                    End If
                End If
            Next

            transaksi.Commit()
            transaksiBPI.Commit()

            MsgBoxCustom.Show("Data berhasil disimpan", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)

            Call KondisiAwal()
            Call ShowData(KodeSup)
        Catch ex As Exception
            Try
                If transaksi IsNot Nothing Then transaksi.Rollback()
            Catch
            End Try
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If koneksi.State <> ConnectionState.Closed Then koneksi.Close()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function ValidasiID() As Boolean
        If rdPTCV.Checked = True Then
            ' Validasi untuk Supplier PT/CV
            ' no npwp
            If TxtNoHp.Text.Replace(" ", "") = "" Then
                MsgBoxCustom.Show("No. HP harus diisi untuk Supplier PT/CV",
                              MsgBoxCustom.ButtonType.OK,
                              MsgBoxCustom.IconType.Information)
                Return False
            End If

            ' dokumen NIB
            Dim adaNIB As Boolean = False

            For i = 1 To ocxAttachment.Rows.Count - 1

                Dim remark As String = LCase(Trim(CStr(ocxAttachment.Item(i, "ocxRemarkAttachment"))))

                If remark.Contains("nib") Then
                    adaNIB = True
                    Exit For
                End If

            Next

            If Not adaNIB Then
                MsgBoxCustom.Show("Lampiran dokumen NIB harus diupload untuk Supplier PT/CV",
                              MsgBoxCustom.ButtonType.OK,
                              MsgBoxCustom.IconType.Information)
                Return False
            End If

        ElseIf rdPribadi.Checked = True OrElse rdCash.Checked = True Then
            ' Validasi untuk Supplier Pribadi/Cash
            ' no ktp
            If TxtNoKTP.Text.Replace(" ", "") = "" Then
                MsgBoxCustom.Show("No. KTP harus diisi untuk Supplier Pribadi/Cash",
                              MsgBoxCustom.ButtonType.OK,
                              MsgBoxCustom.IconType.Information)
                Return False
            End If

            ' no hp
            If TxtNoHp.Text.Replace(" ", "") = "" Then
                MsgBoxCustom.Show("No. HP harus diisi untuk Supplier Pribadi/Cash",
                              MsgBoxCustom.ButtonType.OK,
                              MsgBoxCustom.IconType.Information)
                Return False
            End If

            ' foto petani dan foto ktp
            Dim adaFotoPetani As Boolean = False
            Dim adaFotoKTP As Boolean = False

            For i = 1 To ocxAttachment.Rows.Count - 1

                Dim remark As String = LCase(Trim(CStr(ocxAttachment.Item(i, "ocxRemarkAttachment"))))

                If remark.Contains("petani") Then
                    adaFotoPetani = True
                End If

                If remark.Contains("ktp") Then
                    adaFotoKTP = True
                End If

                If adaFotoPetani AndAlso adaFotoKTP Then Exit For

            Next

            If Not adaFotoPetani Then
                MsgBoxCustom.Show("Lampiran dokumen Foto Petani harus diupload untuk Supplier Pribadi/Cash",
                              MsgBoxCustom.ButtonType.OK,
                              MsgBoxCustom.IconType.Information)
                Return False
            End If

            If Not adaFotoKTP Then
                MsgBoxCustom.Show("Lampiran dokumen Foto KTP harus diupload untuk Supplier Pribadi/Cash",
                              MsgBoxCustom.ButtonType.OK,
                              MsgBoxCustom.IconType.Information)
                Return False
            End If

        Else

            MsgBoxCustom.Show("Jenis supplier tidak valid",
                          MsgBoxCustom.ButtonType.OK,
                          MsgBoxCustom.IconType.Information)

            Return False

        End If

        If chkPPHUMKM.Checked = True Then
            ' dokumen UMKM
            Dim adaUMKM As Boolean = False

            For i = 1 To ocxAttachment.Rows.Count - 1

                Dim remark As String = LCase(Trim(CStr(ocxAttachment.Item(i, "ocxRemarkAttachment"))))

                If remark.Contains("umkm") Then
                    adaUMKM = True
                    Exit For
                End If

            Next

            If Not adaUMKM Then
                MsgBoxCustom.Show("Lampiran dokumen UMKM harus diupload untuk Supplier UMKM",
                              MsgBoxCustom.ButtonType.OK,
                              MsgBoxCustom.IconType.Information)
                Return False
            End If
        End If

        Return True
    End Function

    Private Function SaveDataAttachment(ByVal cm As SqlConnection, ByVal trans As SqlTransaction, ByVal i As Integer) As Integer
        SaveDataAttachment = 0
        Dim Command As New SqlCommand()
        Dim MyConTrans As SqlTransaction = trans
        With Command
            .Connection = cm
            .CommandType = CommandType.StoredProcedure
            .CommandText = "GEN_spMstSupplierAttachmentSave"
            .Transaction = MyConTrans
        End With
        With Command.Parameters
            .Add("@RetValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue
            .Add("@FileID", SqlDbType.BigInt).Value = Val(ocxAttachment.Item(i, "ocxFileID"))
            .Add("@SupplierID", SqlDbType.VarChar, 100).Value = UCase(txtkodesup.Text)
            .Add("@FileAttachment", SqlDbType.VarChar, 150).Value = ocxAttachment.Item(i, "ocxFileAttachment")
            .Add("@AttachmentRemark", SqlDbType.VarChar, 250).Value = Trim(ocxAttachment.Item(i, "ocxRemarkAttachment"))
            .Add("@AppVersion", SqlDbType.VarChar, 10).Value = "RMPApp"
            .Add("@CreatedBy", SqlDbType.VarChar, 20).Value = ClsSession.UserID
            .Add("@Flag", SqlDbType.BigInt).Value = 0

        End With
        Command.Parameters("@flag").Direction = ParameterDirection.Output
        Command.ExecuteNonQuery()

        If CInt(Command.Parameters("@flag").Value) <> 0 Then SaveDataAttachment = Command.Parameters("@Flag").Value
        Exit Function

        If CInt(Command.Parameters("@Flag").Value) = 0 Then
            Command.Dispose()
            Exit Function
        End If
    End Function

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

#End Region

#Region "Event Lainnya"

    Private Sub CboKodeDivKav_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboKodeDivKav.SelectedIndexChanged
        TxtWilayah.Text = CboKodeDivKav.Text
    End Sub

    Private Sub btnFileChoose_Click(sender As Object, e As EventArgs) Handles btnFileChoose.Click

        Dim row As Integer
        Dim openfile As New OpenFileDialog

        Try

            With openfile
                .FilterIndex = 4
                .Multiselect = True
                .FileName = ""
            End With

            If openfile.ShowDialog() = DialogResult.OK Then

                row = ocxAttachment.Rows.Count - 1

                For i As Integer = 0 To openfile.FileNames.Length - 1

                    Dim namaFile As String = openfile.SafeFileNames(i)

                    If Func.ValidateSpecialCharNextcloud(namaFile) = False Then Exit Sub

                    ' cek apakah nama file sudah ada di grid
                    Dim sudahAda As Boolean = False

                    For r As Integer = 1 To ocxAttachment.Rows.Count - 1

                        If LCase(Trim(CStr(ocxAttachment.Item(r, "ocxFileAttachment")))) =
                       LCase(Trim(namaFile)) Then

                            sudahAda = True
                            Exit For

                        End If

                    Next

                    If sudahAda Then

                        MsgBoxCustom.Show("Nama file '" & namaFile & "' sudah ada.",
                                      MsgBoxCustom.ButtonType.OK,
                                      MsgBoxCustom.IconType.Warning)

                        Continue For

                    End If

                    With ocxAttachment

                        .AddItem("")

                        .Item(row, "ocxNo") = row
                        .Item(row, "ocxFileAttachment") = namaFile
                        .Item(row, "ocxTagAttachment") = openfile.FileNames(i)
                        .Item(row, "ocxbtnDelete") = ""

                        row += 1

                    End With

                Next

            End If

        Catch ex As Exception

            MsgBoxCustom.Show(ex.Message,
                          MsgBoxCustom.ButtonType.OK,
                          MsgBoxCustom.IconType.Error)

        End Try

    End Sub

    Private Sub ocxAttachment_BeforeEdit(sender As Object, e As C1.Win.C1FlexGrid.RowColEventArgs) Handles ocxAttachment.BeforeEdit
        Try
            With ocxAttachment
                If Trim(ocxAttachment.Item(e.Row, "ocxFileAttachment")) = "" Then
                    e.Cancel = True
                Else
                    Select Case ocxAttachment.Cols(e.Col).Name
                        Case "ocxFileID", "ocxFileAttachment", "ocxTagAttachment"
                            e.Cancel = True
                        Case Else
                    End Select
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ocxAttachment_CellButtonClick(sender As Object, e As C1.Win.C1FlexGrid.RowColEventArgs) Handles ocxAttachment.CellButtonClick
        Select Case ocxAttachment.Cols(e.Col).Name
            Case "ocxbtnOpen"
                Me.Cursor = Cursors.WaitCursor
                Dim FileName As String = ocxAttachment.Item(e.Row, "ocxFileAttachment")

                If Trim(ocxAttachment.Item(e.Row, "ocxTagAttachment")) <> "" Then
                    System.Diagnostics.Process.Start(ocxAttachment.Item(e.Row, "ocxTagAttachment"))
                Else
                    If FileName <> "" Then
                        Call ClsWebDAV.DownloadFileWebDav(cls_Webdav.WebDavGENSupplier, FolderLokal, txtkodesup.Text, FileName, True)
                    End If
                End If
                Me.Cursor = Cursors.Default
            Case "ocxbtnDelete"
                If btnSave.Enabled = False Then Exit Sub
                If MsgBoxCustom.Show("Apakah anda ingin menghapus.." & vbCrLf &
                          "Lampiran :" & ocxAttachment.Item(e.Row, "ocxFileAttachment") & vbCrLf & " Keterangan : " & ocxAttachment.Item(e.Row, "ocxRemarkAttachment") & " ?", MsgBoxCustom.ButtonType.YesNo, MsgBoxCustom.IconType.Question) = vbNo Then Exit Sub
                DB.ExecuteNonQuery(StrConnDBPancang, "DELETE FROM tblGENMstSupplierAttachment WHERE FileID='" & Val(ocxAttachment.Item(e.Row, "ocxFileID")) & "' ")
                ocxAttachment.RemoveItem(e.Row)
                'ocx.RemoveItem(e.Row)
            Case Else
        End Select
    End Sub

    Private Sub FrmMstSupplierV2_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Func.ControlCentreForm(Me, PanelForm)
    End Sub

#End Region

End Class