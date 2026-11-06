
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.IO
Imports C1.Win.C1FlexGrid

Public Class FrmMstKapal

    Private ReadOnly FolderLokal As String =
        cls_Webdav.WebDavRMPShipFolder

    Private daftarHapusLampiran As New List(Of Long)
    Private modeEdit As Boolean = False
    Private sedangMemuat As Boolean = False

    Private Sub FrmMstKapal_Load(
        sender As Object, e As EventArgs
    ) Handles MyBase.Load

        Try
            ClsFlexGrid.ApplyStyle(ocxAttachment)
            ClsFlexGrid.SetEditableColumns(
                ocxAttachment, "ocxRemarkAttachment")

            With OpenFileDialog1
                .Multiselect = True
                .CheckFileExists = True
                .Filter = "Semua file (*.*)|*.*"
            End With

            Combo.SetPancang(CmbPancang)
            Combo.SetKaptenKapal(CmbKaptenKapala)

            CmbBodyKapal.Items.Clear()
            CmbBodyKapal.Items.Add("Kayu")
            CmbBodyKapal.Items.Add("Fiber")

            ClearData()

        Catch ex As Exception
            MsgBox("Gagal membuka form: " & ex.Message,
                   MsgBoxStyle.Critical)
        Finally
            SetModeEdit(False)
        End Try
    End Sub

    Private Sub SetModeEdit(aktif As Boolean)
        modeEdit = aktif

        ' TextBox
        AturTextBox(TxtNamaKapal, aktif)
        AturTextBox(TxtPemilikKapal, aktif)
        AturTextBox(TxtKapasitasKapal, aktif)
        AturTextBox(TxtDayaMesinKapal, aktif)
        AturTextBox(TxtTahunKapal, aktif)
        AturTextBox(TxtRemarkInActive, aktif)

        AturTextBox(TxtIDKapal, False)
        AturTextBox(TxtNoHpKapten, False)

        ' ComboBox dan CheckBox
        CmbPancang.Enabled = aktif
        CmbKaptenKapala.Enabled = aktif
        CmbBodyKapal.Enabled = aktif

        chkNonActive.Enabled = aktif
        chkCrane.Enabled = aktif
        chkPontianak.Enabled = aktif
        chkNonActive.Enabled = aktif

        ' Lampiran
        btnFileChoose.Enabled = aktif

        ' Tombol
        btnAdd.Enabled = Not aktif
        btnEdit.Enabled = Not aktif AndAlso
                      Val(TxtIDKapal.Text) > 0
        btnSave.Enabled = aktif
        btnCancel.Enabled = aktif
        btnFind.Enabled = Not aktif
        btnExit.Enabled = True
    End Sub

    Private Sub AturTextBox(txt As TextBox, aktif As Boolean)
        txt.ReadOnly = Not aktif
        txt.BackColor = If(
        aktif,
        SystemColors.Window,
        SystemColors.Control)
    End Sub

    '========================================================
    ' HELPER
    '========================================================
    Private Function NilaiCombo(cmb As ComboBox) As Integer
        If cmb.SelectedValue Is Nothing Then Return 0

        Dim hasil As Integer

        If Integer.TryParse(
            cmb.SelectedValue.ToString(), hasil) Then
            Return hasil
        End If

        Return 0
    End Function

    Private Function NilaiKolom(
        row As DataRow, namaKolom As String
    ) As String

        If row Is Nothing OrElse
           Not row.Table.Columns.Contains(namaKolom) OrElse
           IsDBNull(row(namaKolom)) Then

            Return ""
        End If

        Return row(namaKolom).ToString()
    End Function

    Private Function NilaiBoolean(
        row As DataRow, namaKolom As String
    ) As Boolean

        Return NilaiKolom(row, namaKolom) <> "" AndAlso
               Val(NilaiKolom(row, namaKolom)) <> 0
    End Function

    Private Sub ClearData()
        sedangMemuat = True

        Try
            TxtIDKapal.Clear()
            TxtNamaKapal.Clear()
            TxtPemilikKapal.Clear()
            TxtKapasitasKapal.Clear()
            TxtDayaMesinKapal.Clear()
            TxtTahunKapal.Clear()
            TxtNoHpKapten.Clear()
            TxtRemarkInActive.Clear()

            CmbPancang.SelectedIndex = -1
            CmbKaptenKapala.SelectedIndex = -1
            CmbBodyKapal.SelectedIndex = -1

            chkNonActive.Checked = False
            chkCrane.Checked = False
            chkPontianak.Checked = False

            daftarHapusLampiran.Clear()
            ocxAttachment.Rows.Count = 1

        Finally
            sedangMemuat = False
        End Try
    End Sub

    '========================================================
    ' TAMPILKAN DATA KAPAL
    '========================================================
    Public Sub ShowData(kode As String)
        Dim dt As New DataTable

        Try
            Using conn As New SqlConnection(StrConnRMPApp)
                Using cmd As New SqlCommand(
                    "SELECT * FROM vwkapalnew WHERE KapalID = @KapalID",
                    conn)

                    cmd.Parameters.Add(
                        "@KapalID", SqlDbType.Int).Value = Val(kode)

                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using

            If dt.Rows.Count = 0 Then
                MsgBox("Data kapal tidak ditemukan.",
                       MsgBoxStyle.Exclamation)
                Return
            End If

            Dim dr As DataRow = dt.Rows(0)

            sedangMemuat = True

            Try
                TxtIDKapal.Text = NilaiKolom(dr, "KapalID")
                TxtNamaKapal.Text = NilaiKolom(dr, "KapalName")
                TxtPemilikKapal.Text = NilaiKolom(dr, "Pemilik")
                TxtKapasitasKapal.Text = NilaiKolom(dr, "Kap")
                TxtDayaMesinKapal.Text = NilaiKolom(dr, "DayaMesin")
                TxtTahunKapal.Text = NilaiKolom(dr, "TahunKapal")
                TxtNoHpKapten.Text = NilaiKolom(dr, "nohpkapten")

                TxtRemarkInActive.Text =
                    NilaiKolom(dr, "RemarkNotActive")

                CmbBodyKapal.SelectedIndex =
                    CmbBodyKapal.FindStringExact(
                        NilaiKolom(dr, "BodyKapal"))

                If NilaiKolom(dr, "IDPancang") <> "" Then
                    CmbPancang.SelectedValue =
                        Convert.ToInt32(dr("IDPancang"))
                Else
                    CmbPancang.SelectedIndex = -1
                End If

                If NilaiKolom(dr, "KaptenID") <> "" Then
                    CmbKaptenKapala.SelectedValue =
                        Convert.ToInt32(dr("KaptenID"))
                Else
                    CmbKaptenKapala.SelectedIndex = -1
                End If

                chkNonActive.Checked =
                    NilaiBoolean(dr, "NonActive")

                chkCrane.Checked =
                    NilaiBoolean(dr, "Crane")

                chkPontianak.Checked =
                    NilaiBoolean(dr, "Pontianak")

            Finally
                sedangMemuat = False
            End Try

            daftarHapusLampiran.Clear()
            ShowDataAttachment()
            SetModeEdit(False)

        Catch ex As Exception
            sedangMemuat = False
            SetModeEdit(False)

            MsgBox("Gagal memuat data kapal: " & ex.Message,
                   MsgBoxStyle.Critical)
        End Try
    End Sub

    '========================================================
    ' TAMPILKAN LAMPIRAN
    '========================================================
    Private Sub ShowDataAttachment()
        ocxAttachment.Rows.Count = 1

        If Val(TxtIDKapal.Text) <= 0 Then Return

        Dim sql As String =
            "SELECT FileID, FileAttachment, AttachmentDescriptions " &
            "FROM dbo.tblMstKapalAttachment " &
            "WHERE KapalID = @KapalID ORDER BY FileID"

        Using conn As New SqlConnection(StrConnRMPApp)
            Using cmd As New SqlCommand(sql, conn)

                cmd.Parameters.Add(
                    "@KapalID", SqlDbType.Int).Value =
                    Val(TxtIDKapal.Text)

                conn.Open()

                Using rd As SqlDataReader = cmd.ExecuteReader()
                    While rd.Read()
                        Dim r As Integer = ocxAttachment.Rows.Count
                        ocxAttachment.Rows.Add()

                        ocxAttachment(r, "ocxNo") = r
                        ocxAttachment(r, "ocxFileID") = rd("FileID")
                        ocxAttachment(r, "ocxTagAttachment") = ""
                        ocxAttachment(r, "ocxFileAttachment") =
                            rd("FileAttachment").ToString()
                        ocxAttachment(r, "ocxRemarkAttachment") =
                            rd("AttachmentDescriptions").ToString()
                    End While
                End Using
            End Using
        End Using
    End Sub

    '========================================================
    ' SIMPAN HEADER KAPAL
    '========================================================
    Private Function SaveDataHeader(
    conn As SqlConnection,
    trans As SqlTransaction
) As Integer

        Using cmd As New SqlCommand("dbo.spSaveKapal", conn, trans)
            cmd.CommandType = CommandType.StoredProcedure

            Dim pID = cmd.Parameters.Add("@IDKapal", SqlDbType.Int)
            pID.Direction = ParameterDirection.InputOutput
            pID.Value = Val(TxtIDKapal.Text)

            cmd.Parameters.Add("@IDPancang", SqlDbType.Int).Value =
            NilaiCombo(CmbPancang)

            cmd.Parameters.Add("@NamaKapal", SqlDbType.VarChar, 50).Value =
            TxtNamaKapal.Text.Trim()

            cmd.Parameters.Add("@PemilikKapal", SqlDbType.VarChar, 50).Value =
            TxtPemilikKapal.Text.Trim()

            cmd.Parameters.Add("@KapasitasKapal", SqlDbType.Int).Value =
            Val(TxtKapasitasKapal.Text)

            cmd.Parameters.Add("@DayaMesinKapal", SqlDbType.Int).Value =
            Val(TxtDayaMesinKapal.Text)

            cmd.Parameters.Add("@BodyKapal", SqlDbType.VarChar, 10).Value =
            CmbBodyKapal.Text.Trim()

            cmd.Parameters.Add("@TahunKapal", SqlDbType.Int).Value =
            Val(TxtTahunKapal.Text)

            cmd.Parameters.Add("@IDKaptenKapal", SqlDbType.Int).Value =
            NilaiCombo(CmbKaptenKapala)

            cmd.Parameters.Add("@RemarkNonActive", SqlDbType.VarChar, 200).Value = TxtRemarkInActive.Text.Trim()

            cmd.Parameters.Add("@NonActive", SqlDbType.Int).Value = If(chkNonActive.Checked, 1, 0)
            cmd.Parameters.Add("@isNonAsuransi", SqlDbType.Int).Value = If(isNonAsuransi.Checked, 1, 0)

            cmd.Parameters.Add("@chkCrane", SqlDbType.Int).Value =
            If(chkCrane.Checked, 1, 0)

            cmd.Parameters.Add("@Pontianak", SqlDbType.Int).Value =
            If(chkPontianak.Checked, 1, 0)

            cmd.Parameters.Add("@UserRMPApp", SqlDbType.VarChar, 50).Value =
            ClsSession.UserID

            Dim pFlag = cmd.Parameters.Add("@Flag", SqlDbType.TinyInt)
            pFlag.Direction = ParameterDirection.Output

            cmd.ExecuteNonQuery()

            If pID.Value Is Nothing OrElse IsDBNull(pID.Value) Then
                Return 0
            End If

            If pFlag.Value Is Nothing OrElse IsDBNull(pFlag.Value) Then
                Return 0
            End If

            TxtIDKapal.Text = pID.Value.ToString()

            Return Convert.ToInt32(pFlag.Value)
        End Using
    End Function

    '========================================================
    ' SIMPAN LAMPIRAN
    '========================================================
    Private Function SaveDataAttachment(
        conn As SqlConnection,
        trans As SqlTransaction,
        row As Integer
    ) As Boolean

        Dim fileID As Long =
            Val(Convert.ToString(
                ocxAttachment(row, "ocxFileID")))

        Dim namaFile As String =
            Convert.ToString(
                ocxAttachment(row, "ocxFileAttachment"))

        Dim remark As String =
            Convert.ToString(
                ocxAttachment(row, "ocxRemarkAttachment"))

        Dim pathLokal As String =
            Convert.ToString(
                ocxAttachment(row, "ocxTagAttachment"))

        If namaFile.Trim() = "" Then Return False

        Using cmd As New SqlCommand(
            "dbo.RMP_spMstKapalAttachmentSave", conn, trans)

            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Add(
                "@FileID", SqlDbType.BigInt).Value = fileID

            cmd.Parameters.Add(
                "@KapalID", SqlDbType.Int).Value =
                Val(TxtIDKapal.Text)

            cmd.Parameters.Add(
                "@FileAttachment", SqlDbType.VarChar, 150).Value =
                namaFile

            cmd.Parameters.Add(
                "@AttachmentRemark", SqlDbType.VarChar, 250).Value =
                remark

            cmd.Parameters.Add(
                "@AppVersion", SqlDbType.VarChar, 10).Value =
                "RMPApp"

            cmd.Parameters.Add(
                "@CreatedBy", SqlDbType.VarChar, 20).Value =
                ClsSession.UserID

            Dim pFlag =
                cmd.Parameters.Add("@Flag", SqlDbType.BigInt)
            pFlag.Direction = ParameterDirection.Output

            cmd.ExecuteNonQuery()

            If pFlag.Value Is Nothing OrElse
               IsDBNull(pFlag.Value) OrElse
               Val(pFlag.Value.ToString()) <= 0 Then

                Return False
            End If
        End Using

        If pathLokal <> "" Then
            If Not File.Exists(pathLokal) Then
                Throw New Exception(
                    "File lampiran tidak ditemukan: " & pathLokal)
            End If

            ClsWebDAV.UploadFileWebDav(
                pathLokal,
                FolderLokal,
                TxtIDKapal.Text,
                namaFile)
        End If

        Return True
    End Function

    '========================================================
    ' HAPUS METADATA LAMPIRAN
    '========================================================
    Private Sub HapusMetadataLampiran(
        conn As SqlConnection,
        trans As SqlTransaction
    )

        For Each fileID As Long In daftarHapusLampiran
            Using cmd As New SqlCommand(
                "DELETE FROM dbo.tblMstKapalAttachment " &
                "WHERE FileID = @FileID AND KapalID = @KapalID",
                conn, trans)

                cmd.Parameters.Add(
                    "@FileID", SqlDbType.BigInt).Value = fileID

                cmd.Parameters.Add(
                    "@KapalID", SqlDbType.Int).Value =
                    Val(TxtIDKapal.Text)

                cmd.ExecuteNonQuery()
            End Using
        Next
    End Sub

    '========================================================
    ' VALIDASI DATA
    '========================================================
    Private Function ValidasiData() As Boolean
        If TxtNamaKapal.Text.Trim() = "" Then
            MsgBox("Nama kapal wajib diisi.", MsgBoxStyle.Exclamation)
            TxtNamaKapal.Focus()
            Return False
        End If

        If TxtPemilikKapal.Text.Trim() = "" Then
            MsgBox("Pemilik kapal wajib diisi.", MsgBoxStyle.Exclamation)
            TxtPemilikKapal.Focus()
            Return False
        End If

        If NilaiCombo(CmbPancang) <= 0 Then
            MsgBox("Pancang wajib dipilih.", MsgBoxStyle.Exclamation)
            CmbPancang.Focus()
            Return False
        End If

        If NilaiCombo(CmbKaptenKapala) <= 0 Then
            MsgBox("Kapten kapal wajib dipilih.", MsgBoxStyle.Exclamation)
            CmbKaptenKapala.Focus()
            Return False
        End If

        If CmbBodyKapal.Text.Trim() = "" Then
            MsgBox("Body kapal wajib dipilih.", MsgBoxStyle.Exclamation)
            CmbBodyKapal.Focus()
            Return False
        End If

        If chkNonActive.Checked AndAlso
           TxtRemarkInActive.Text.Trim() = "" Then

            MsgBox("Remark nonaktif wajib diisi.",
                   MsgBoxStyle.Exclamation)
            TxtRemarkInActive.Focus()
            Return False
        End If

        Dim kapasitas As Integer
        Dim dayaMesin As Integer
        Dim tahun As Integer

        If Not Integer.TryParse(
            TxtKapasitasKapal.Text, kapasitas) OrElse kapasitas < 0 Then

            MsgBox("Kapasitas kapal harus berupa angka yang valid.",
                   MsgBoxStyle.Exclamation)
            TxtKapasitasKapal.Focus()
            Return False
        End If

        If Not Integer.TryParse(
            TxtDayaMesinKapal.Text, dayaMesin) OrElse dayaMesin < 0 Then

            MsgBox("Daya mesin harus berupa angka yang valid.",
                   MsgBoxStyle.Exclamation)
            TxtDayaMesinKapal.Focus()
            Return False
        End If

        If Not Integer.TryParse(
            TxtTahunKapal.Text, tahun) OrElse
            tahun < 0 OrElse tahun > 9999 Then

            MsgBox("Tahun kapal harus berupa tahun yang valid.",
                   MsgBoxStyle.Exclamation)
            TxtTahunKapal.Focus()
            Return False
        End If

        Return True
    End Function

    '========================================================
    ' SIMPAN DATA
    '========================================================
    Private Sub btnSave_Click(
        sender As Object, e As EventArgs
    ) Handles btnSave.Click

        If Not modeEdit Then Return
        If Not ValidasiData() Then Return

        Me.Cursor = Cursors.WaitCursor

        Try
            Using conn As New SqlConnection(StrConnRMPApp)
                conn.Open()

                Using trans As SqlTransaction = conn.BeginTransaction()
                    Try
                        Dim hasil As Integer =
                            SaveDataHeader(conn, trans)

                        If hasil <> 1 OrElse
                           Val(TxtIDKapal.Text) <= 0 Then

                            Throw New Exception(
                                "Gagal menyimpan header kapal. " &
                                "Periksa output SP spSaveKapal.")
                        End If

                        For i As Integer = 1 To ocxAttachment.Rows.Count - 1
                            If Not SaveDataAttachment(conn, trans, i) Then
                                Throw New Exception(
                                    "Gagal menyimpan lampiran pada baris " & i)
                            End If
                        Next

                        HapusMetadataLampiran(conn, trans)
                        trans.Commit()

                    Catch
                        Try
                            trans.Rollback()
                        Catch
                        End Try

                        Throw
                    End Try
                End Using
            End Using

            daftarHapusLampiran.Clear()
            ShowData(TxtIDKapal.Text)

            MsgBox("Data kapal berhasil disimpan.",
                   MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox("Gagal menyimpan data kapal: " & ex.Message,
                   MsgBoxStyle.Critical)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnAdd_Click(
    sender As Object, e As EventArgs
) Handles btnAdd.Click

        ClearData()
        SetModeEdit(True)
        TxtNamaKapal.Focus()

    End Sub

    Private Sub btnEdit_Click(
    sender As Object, e As EventArgs
) Handles btnEdit.Click

        If Val(TxtIDKapal.Text) <= 0 Then Return

        SetModeEdit(True)
        TxtNamaKapal.Focus()
    End Sub

    '========================================================
    ' TOMBOL CANCEL
    '========================================================
    Private Sub btnCancel_Click(
        sender As Object, e As EventArgs
    ) Handles btnCancel.Click

        If Val(TxtIDKapal.Text) > 0 Then
            ShowData(TxtIDKapal.Text)
        Else
            ClearData()
        End If

        SetModeEdit(False)
    End Sub

    Private Sub btnExit_Click(
        sender As Object, e As EventArgs
    ) Handles btnExit.Click

        Me.Close()
    End Sub

    Private Sub btnFileChoose_Click(
    sender As Object, e As EventArgs
) Handles btnFileChoose.Click

        If Not modeEdit Then Return

        If OpenFileDialog1.ShowDialog() <> DialogResult.OK Then Return

        For Each path As String In OpenFileDialog1.FileNames
            Dim namaAsli As String = IO.Path.GetFileName(path)

            If Func.ValidateSpecialCharNextcloud(namaAsli) Then
                Continue For
            End If

            Dim namaFile As String = namaAsli
            Dim nomor As Integer = 1
            Dim namaDasar As String =
            IO.Path.GetFileNameWithoutExtension(namaAsli)
            Dim ekstensi As String = IO.Path.GetExtension(namaAsli)

            While NamaFileSudahAda(namaFile)
                namaFile = namaDasar & " (" & nomor & ")" & ekstensi
                nomor += 1
            End While

            Dim r As Integer = ocxAttachment.Rows.Count
            ocxAttachment.Rows.Add()

            ocxAttachment(r, "ocxNo") = r
            ocxAttachment(r, "ocxFileID") = 0
            ocxAttachment(r, "ocxTagAttachment") = path
            ocxAttachment(r, "ocxFileAttachment") = namaFile
            ocxAttachment(r, "ocxRemarkAttachment") = ""
        Next
    End Sub

    Private Function NamaFileSudahAda(namaFile As String) As Boolean
        For i As Integer = 1 To ocxAttachment.Rows.Count - 1
            If String.Equals(
            Convert.ToString(
                ocxAttachment(i, "ocxFileAttachment")),
            namaFile,
            StringComparison.OrdinalIgnoreCase) Then

                Return True
            End If
        Next

        Return False
    End Function

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

    '========================================================
    ' BUKA DAN HAPUS LAMPIRAN
    '========================================================
    Private Sub ocxAttachment_CellButtonClick(
        sender As Object, e As RowColEventArgs
    ) Handles ocxAttachment.CellButtonClick

        If e.Row < 1 Then Return

        Dim namaKolom As String =
            ocxAttachment.Cols(e.Col).Name

        Dim namaFile As String =
            Convert.ToString(
                ocxAttachment(e.Row, "ocxFileAttachment"))

        Dim pathLokal As String =
            Convert.ToString(
                ocxAttachment(e.Row, "ocxTagAttachment"))

        Dim fileID As Long =
            Val(Convert.ToString(
                ocxAttachment(e.Row, "ocxFileID")))

        Select Case namaKolom
            Case "ocxbtnOpen"
                Try
                    If pathLokal <> "" AndAlso File.Exists(pathLokal) Then
                        Process.Start(
                            New ProcessStartInfo(pathLokal) With {
                                .UseShellExecute = True
                            })
                    Else
                        ClsWebDAV.DownloadFileWebDav(
                            cls_Webdav.WebDavRMPShipPelangsir,
                            FolderLokal,
                            TxtIDKapal.Text,
                            namaFile,
                            True)
                    End If

                Catch ex As Exception
                    MsgBox("Gagal membuka attachment: " & ex.Message,
                           MsgBoxStyle.Exclamation)
                End Try

            Case "ocxbtnDelete"
                If Not modeEdit Then Return

                If MsgBox(
                    "Hapus attachment " & namaFile & "?",
                    MsgBoxStyle.YesNo Or MsgBoxStyle.Question) <>
                    MsgBoxResult.Yes Then Return

                If fileID > 0 AndAlso
                   Not daftarHapusLampiran.Contains(fileID) Then

                    daftarHapusLampiran.Add(fileID)
                End If

                ocxAttachment.Rows.Remove(e.Row)

                For i As Integer = 1 To ocxAttachment.Rows.Count - 1
                    ocxAttachment(i, "ocxNo") = i
                Next
        End Select
    End Sub

    '========================================================
    ' NOMOR HP KAPTEN
    '========================================================
    Private Sub CmbKaptenKapala_SelectedIndexChanged(
        sender As Object, e As EventArgs
    ) Handles CmbKaptenKapala.SelectedIndexChanged

        If sedangMemuat OrElse Not modeEdit Then Return

        Dim idKapten As Integer = NilaiCombo(CmbKaptenKapala)

        If idKapten <= 0 Then
            TxtNoHpKapten.Clear()
            Return
        End If

        Try
            Dim sql As String =
                "SELECT nohpkapten FROM tblMstKaptenKapal WHERE id = @ID"

            Using conn As New SqlConnection(StrConnRMPApp)
                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.Add(
                        "@ID", SqlDbType.Int).Value = idKapten

                    conn.Open()

                    Dim hasil As Object = cmd.ExecuteScalar()

                    TxtNoHpKapten.Text =
                        If(hasil Is Nothing OrElse IsDBNull(hasil),
                           "", hasil.ToString())
                End Using
            End Using

        Catch ex As Exception
            MsgBox("Gagal membaca nomor HP kapten: " & ex.Message,
                   MsgBoxStyle.Exclamation)
        End Try
    End Sub

    '========================================================
    ' CARI DATA KAPAL
    '========================================================
    Private Sub btnFind_Click(
        sender As Object, e As EventArgs
    ) Handles btnFind.Click

        If modeEdit Then Return

        FrmMain.BukaMenu(
            FrmMstKapalShow,
            FrmMain.mnuMstKapal)
    End Sub

    '========================================================
    ' RESIZE FORM
    '========================================================
    Private Sub FrmMstKapal_Resize(
        sender As Object, e As EventArgs
    ) Handles MyBase.Resize

        Func.ControlCentreForm(Me, PanelForm)
    End Sub

    '========================================================
    ' VALIDASI ANGKA
    '========================================================
    Private Sub TxtKapasitasKapal_KeyPress(
        sender As Object, e As KeyPressEventArgs
    ) Handles TxtKapasitasKapal.KeyPress

        If Not modeEdit Then
            e.Handled = True
            Return
        End If

        e.Handled = Modul_RMP.Func.NumericOnly(e)

        If e.KeyChar = ChrW(13) Then
            CmbPancang.Focus()
        End If
    End Sub

    Private Sub TxtDayaMesinKapal_KeyPress(
        sender As Object, e As KeyPressEventArgs
    ) Handles TxtDayaMesinKapal.KeyPress

        If Not modeEdit Then
            e.Handled = True
            Return
        End If

        e.Handled = Modul_RMP.Func.NumericOnly(e)

        If e.KeyChar = ChrW(13) Then
            CmbPancang.Focus()
        End If
    End Sub

End Class
