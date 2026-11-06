Imports System.Data
Imports System.Data.SqlClient

Public Class FrmMstSupplierMain

#Region "Variabel"

    Private perintah As String = ""
    Private noRekeningLama As String = ""

#End Region

#Region "Setup Awal"

    Private Sub FrmMstSupplierMain_Load(
        sender As Object, e As EventArgs
    ) Handles MyBase.Load

        Call LoadComboBoxData()
        Call KondisiAwal()
    End Sub

    Private Sub LoadComboBoxData()
        Combo.GroupSupplier(cboGroupSup)
        Combo.SetBahanBaku(cboBahanBaku)
        Combo.DivBlockKav(cboKodeDivKav)
        Combo.FactoryID(cboMainFactory)
    End Sub

    Private Sub KondisiAwal()
        Call ClearData()
        Call ControlEnabled(False)
        Call CmdEnabled(True)

        perintah = ""
    End Sub

    Private Sub ControlEnabled(flag As Boolean)
        txtKodeSup.Enabled = flag
        txtNamaSup.Enabled = flag
        cboGroupSup.Enabled = flag
        cboBahanBaku.Enabled = flag
        txtWilayah.Enabled = flag
        cboKodeDivKav.Enabled = flag
        txtKodeNota.Enabled = flag
        txtNoNPWP.Enabled = flag
        txtNamaNPWP.Enabled = flag
        txtAlamatSup.Enabled = flag
        cboMainFactory.Enabled = flag
        txtSingkatan.Enabled = flag
        txtSingkatanNota.Enabled = flag

        chkNotActive.Enabled = flag
        CheckBox1.Enabled = flag
        CheckBox2.Enabled = flag
        chkPancang.Enabled = flag
        chkPcgSub.Enabled = flag
        chkPcgSubMain.Enabled = flag
        chkPcgKontainer.Enabled = flag
        chkDarat.Enabled = flag
        chkPcgLaut.Enabled = flag
        chkJambul.Enabled = flag
        chkLicin.Enabled = flag
        chkArang.Enabled = flag
        chkCungkil.Enabled = flag
        chkPetaniKaki.Enabled = flag
        chkPetaniKakiView.Enabled = flag
        chkKomisiToke.Enabled = flag
        chkKomisiHanyaToke.Enabled = flag

        txtRMSupID.Enabled = False
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

#Region "Clear Data"

    Private Sub ClearData()
        txtRMSupID.Clear()
        txtKodeSup.Clear()
        txtNamaSup.Clear()
        txtWilayah.Clear()
        txtKodeNota.Clear()
        txtNoNPWP.Clear()
        txtNamaNPWP.Clear()
        txtAlamatSup.Clear()
        txtSingkatan.Clear()
        txtSingkatanNota.Clear()

        cboGroupSup.SelectedIndex = -1
        cboBahanBaku.SelectedIndex = -1
        cboKodeDivKav.SelectedIndex = -1
        cboMainFactory.SelectedIndex = -1

        chkNotActive.Checked = False
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        chkPancang.Checked = False
        chkPcgSub.Checked = False
        chkPcgSubMain.Checked = False
        chkPcgKontainer.Checked = False
        chkDarat.Checked = False
        chkPcgLaut.Checked = False
        chkJambul.Checked = False
        chkLicin.Checked = False
        chkArang.Checked = False
        chkCungkil.Checked = False
        chkPetaniKaki.Checked = False
        chkPetaniKakiView.Checked = False
        chkKomisiToke.Checked = False
        chkKomisiHanyaToke.Checked = False

        noRekeningLama = ""
    End Sub

#End Region

#Region "Tampilkan Data"

    Public Sub ShowData(KodeSup As String)
        Dim sql As String
        Dim dt As DataTable

        sql = "SELECT * FROM vwRMMstSupplier1 " &
              "WHERE KodeSup = '" & KodeSup.Replace("'", "''") & "'"

        Try
            dt = DB.ExecuteQuery(StrConnAccounting, sql)

            If dt.Rows.Count = 0 Then
                MsgBoxCustom.Show("Data supplier tidak ditemukan",
                    MsgBoxCustom.ButtonType.OK,
                    MsgBoxCustom.IconType.Information)
                Exit Sub
            End If

            Call ClearData()

            Dim row As DataRow = dt.Rows(0)

            txtRMSupID.Text = row("RMSupplierID").ToString()
            txtKodeSup.Text = row("KodeSup").ToString()
            txtNamaSup.Text = row("NamaSup").ToString()
            txtWilayah.Text = row("WilSP").ToString()
            txtKodeNota.Text = row("KodeNota").ToString()
            txtNoNPWP.Text = row("NoNPWP").ToString()
            txtNamaNPWP.Text = row("NamaNPWP").ToString()
            txtAlamatSup.Text = row("Alamat").ToString()
            txtSingkatan.Text = row("singktn").ToString()
            txtSingkatanNota.Text = row("SingkatanNota").ToString()

            noRekeningLama = row("NoRekening").ToString()

            cboGroupSup.SelectedValue = row("GroupSup")
            cboBahanBaku.SelectedValue = row("KodeJenisBahanBaku")
            cboKodeDivKav.SelectedValue = row("DivBlokKav").ToString()
            cboMainFactory.SelectedValue = row("IDFactory").ToString()

            CheckBox1.Checked = If(IsDBNull(row("Kanal")), False, CBool(row("Kanal")))
            CheckBox2.Checked = If(IsDBNull(row("Laut")), False, CBool(row("Laut")))
            chkNotActive.Checked = If(IsDBNull(row("NotActive")), False, CBool(row("NotActive")))
            chkPancang.Checked = If(IsDBNull(row("Pancang")), False, CBool(row("Pancang")))
            chkPcgSub.Checked = If(IsDBNull(row("FlagPancangSub")), False, CBool(row("FlagPancangSub")))
            chkPcgSubMain.Checked = If(IsDBNull(row("FlagPancangSubMain")), False, CBool(row("FlagPancangSubMain")))
            chkPcgKontainer.Checked = If(IsDBNull(row("FlagKontainer")), False, CBool(row("FlagKontainer")))
            chkDarat.Checked = If(IsDBNull(row("PcgDarat")), False, CBool(row("PcgDarat")))
            chkPcgLaut.Checked = If(IsDBNull(row("PcgLaut")), False, CBool(row("PcgLaut")))
            chkJambul.Checked = If(IsDBNull(row("jambul")), False, CBool(row("jambul")))
            chkLicin.Checked = If(IsDBNull(row("licin")), False, CBool(row("licin")))
            chkArang.Checked = If(IsDBNull(row("Arang")), False, CBool(row("Arang")))
            chkCungkil.Checked = If(IsDBNull(row("Cungkil")), False, CBool(row("Cungkil")))
            chkPetaniKaki.Checked = If(IsDBNull(row("FlagHargaPetaniKaki")), False, CBool(row("FlagHargaPetaniKaki")))
            chkPetaniKakiView.Checked = If(IsDBNull(row("FlagHargaPetaniKakiView")), False, CBool(row("FlagHargaPetaniKakiView")))
            chkKomisiToke.Checked = If(IsDBNull(row("FlagKomisiTokeh")), False, CBool(row("FlagKomisiTokeh")))
            chkKomisiHanyaToke.Checked = If(IsDBNull(row("FlagKomisiOnlyTokeh")), False, CBool(row("FlagKomisiOnlyTokeh")))

            Call ControlEnabled(False)
            Call CmdEnabled(True)

            perintah = ""

        Catch ex As Exception
            MsgBoxCustom.Show("Gagal menampilkan data supplier." & vbCrLf & ex.Message,
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Error)
        End Try
    End Sub

#End Region

#Region "Validasi"

    Private Function ValidasiInput() As Boolean
        If Trim(txtKodeSup.Text) = "" Then
            MsgBoxCustom.Show("Kode Supplier harus diisi",
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Information)
            txtKodeSup.Focus()
            Return False
        End If

        If Trim(txtNamaSup.Text) = "" Then
            MsgBoxCustom.Show("Nama Supplier harus diisi",
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Information)
            txtNamaSup.Focus()
            Return False
        End If

        If cboGroupSup.SelectedIndex = -1 Then
            MsgBoxCustom.Show("Group Supplier harus dipilih",
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Information)
            cboGroupSup.Focus()
            Return False
        End If

        If cboBahanBaku.SelectedIndex = -1 Then
            MsgBoxCustom.Show("Jenis Bahan Baku harus dipilih",
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Information)
            cboBahanBaku.Focus()
            Return False
        End If

        If Trim(txtWilayah.Text) = "" Then
            MsgBoxCustom.Show("Wilayah harus diisi",
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Information)
            txtWilayah.Focus()
            Return False
        End If

        If cboKodeDivKav.SelectedIndex = -1 Then
            MsgBoxCustom.Show("Divisi/Blok/Kav harus dipilih",
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Information)
            cboKodeDivKav.Focus()
            Return False
        End If

        If Trim(txtKodeNota.Text) = "" Then
            MsgBoxCustom.Show("Kode Nota harus diisi",
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Information)
            txtKodeNota.Focus()
            Return False
        End If

        If Trim(txtNoNPWP.Text).Replace("-", "").Replace(".", "") <> "" AndAlso
           Trim(txtNamaNPWP.Text) = "" Then

            MsgBoxCustom.Show("Nama NPWP harus diisi",
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Information)
            txtNamaNPWP.Focus()
            Return False
        End If

        Return True
    End Function

#End Region

#Region "Simpan Data"

    Private Function SaveDataHdr(
        conn As SqlConnection,
        trans As SqlTransaction,
        ByRef pesanError As String
    ) As Boolean

        Using cmd As New SqlCommand()
            Try
                With cmd
                    .Connection = conn
                    .Transaction = trans
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "spRMMstSupplier1New082025"

                    .Parameters.Add("@RetVal", SqlDbType.Int).Direction =
                        ParameterDirection.ReturnValue

                    .Parameters.Add("@Perintah", SqlDbType.VarChar, 5).Value =
                        perintah

                    .Parameters.Add("@RMSupplierID", SqlDbType.BigInt).Direction =
                        ParameterDirection.InputOutput

                    .Parameters("@RMSupplierID").Value =
                        If(Trim(txtRMSupID.Text) = "", 0L, CLng(txtRMSupID.Text))

                    .Parameters.Add("@KodeSup", SqlDbType.VarChar, 20).Value =
                        Trim(UCase(txtKodeSup.Text))

                    .Parameters.Add("@MyRSUPSupplierID", SqlDbType.VarChar, 20).Value =
                        Trim(UCase(txtKodeSup.Text))

                    .Parameters.Add("@NamaSup", SqlDbType.VarChar, 50).Value =
                        Trim(UCase(txtNamaSup.Text))

                    .Parameters.Add("@GroupSup", SqlDbType.Int).Value =
                        CInt(cboGroupSup.SelectedValue)

                    .Parameters.Add("@KodeJenisBahanBaku", SqlDbType.Int).Value =
                        CInt(cboBahanBaku.SelectedValue)

                    .Parameters.Add("@KodeNota", SqlDbType.VarChar, 15).Value =
                        Trim(txtKodeNota.Text)

                    .Parameters.Add("@WilSP", SqlDbType.VarChar, 200).Value =
                        Trim(txtWilayah.Text)

                    .Parameters.Add("@DivBlokKav", SqlDbType.VarChar, 200).Value =
                        cboKodeDivKav.SelectedValue.ToString()

                    .Parameters.Add("@NoRekening", SqlDbType.VarChar, 50).Value =
                        noRekeningLama

                    .Parameters.Add("@NoNPWP", SqlDbType.VarChar, 50).Value =
                        txtNoNPWP.Text.Trim()

                    .Parameters.Add("@NamaNPWP", SqlDbType.VarChar, 50).Value =
                        txtNamaNPWP.Text.Trim()

                    .Parameters.Add("@Kanal", SqlDbType.Int).Value =
                        If(CheckBox1.Checked, 1, 0)

                    .Parameters.Add("@Laut", SqlDbType.Int).Value =
                        If(CheckBox2.Checked, 1, 0)

                    .Parameters.Add("@NotActive", SqlDbType.Int).Value =
                        If(chkNotActive.Checked, 1, 0)

                    .Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value =
                        ClsSession.UserID

                    .Parameters.Add("@LastUpdatedBy", SqlDbType.VarChar, 50).Value =
                        ClsSession.UserID

                    .Parameters.Add("@Alamat", SqlDbType.VarChar, 500).Value =
                        txtAlamatSup.Text.Trim()

                    .Parameters.Add("@IDFactory", SqlDbType.VarChar, 20).Value =
                        cboMainFactory.SelectedValue.ToString()

                    .Parameters.Add("@singktn", SqlDbType.VarChar, 10).Value =
                        txtSingkatan.Text.Trim()

                    .Parameters.Add("@SingkatanNota", SqlDbType.VarChar, 10).Value =
                        txtSingkatanNota.Text.Trim()

                    .Parameters.Add("@chkPancang", SqlDbType.Int).Value =
                        If(chkPancang.Checked, 1, 0)

                    .Parameters.Add("@PcgDarat", SqlDbType.Int).Value =
                        If(chkDarat.Checked, 1, 0)

                    .Parameters.Add("@PcgLaut", SqlDbType.Int).Value =
                        If(chkPcgLaut.Checked, 1, 0)

                    .Parameters.Add("@Jambul", SqlDbType.Int).Value =
                        If(chkJambul.Checked, 1, 0)

                    .Parameters.Add("@Licin", SqlDbType.Int).Value =
                        If(chkLicin.Checked, 1, 0)

                    .Parameters.Add("@Arang", SqlDbType.Int).Value =
                        If(chkArang.Checked, 1, 0)

                    .Parameters.Add("@Cungkil", SqlDbType.Int).Value =
                        If(chkCungkil.Checked, 1, 0)

                    .Parameters.Add("@FlagPancangSub", SqlDbType.Int).Value =
                        If(chkPcgSub.Checked, 1, 0)

                    .Parameters.Add("@FlagPancangSubMain", SqlDbType.Int).Value =
                        If(chkPcgSubMain.Checked, 1, 0)

                    .Parameters.Add("@FlagPancangKontainer", SqlDbType.Int).Value =
                        If(chkPcgKontainer.Checked, 1, 0)

                    .Parameters.Add("@FlagHargaPetaniKaki", SqlDbType.Int).Value =
                        If(chkPetaniKaki.Checked, 1, 0)

                    .Parameters.Add("@FlagHargaPetaniKakiView", SqlDbType.Int).Value =
                        If(chkPetaniKakiView.Checked, 1, 0)

                    .Parameters.Add("@FlagKomisiTokeh", SqlDbType.Int).Value =
                        If(chkKomisiToke.Checked, 1, 0)

                    .Parameters.Add("@FlagKomisiHanyaTokeh", SqlDbType.Int).Value =
                        If(chkKomisiHanyaToke.Checked, 1, 0)

                    .Parameters.Add("@Flag", SqlDbType.Int).Direction =
                        ParameterDirection.Output

                    .ExecuteNonQuery()

                    If Convert.ToInt32(.Parameters("@RetVal").Value) = 100 Then
                        pesanError = "Kode Supplier " & txtKodeSup.Text & " sudah ada."
                        Return False
                    End If

                    If IsDBNull(.Parameters("@Flag").Value) OrElse
                       Convert.ToInt32(.Parameters("@Flag").Value) = 0 Then

                        pesanError = "Stored procedure gagal menyimpan data supplier."
                        Return False
                    End If

                    txtRMSupID.Text = .Parameters("@RMSupplierID").Value.ToString()
                End With

                Return True

            Catch ex As Exception
                pesanError = ex.Message
                Return False
            End Try
        End Using
    End Function

    Private Sub btnSave_Click(
        sender As Object, e As EventArgs
    ) Handles btnSave.Click

        If Not ValidasiInput() Then Exit Sub

        Me.Cursor = Cursors.WaitCursor

        Dim koneksi As SqlConnection = Nothing
        Dim transaksi As SqlTransaction = Nothing
        Dim pesanError As String = ""

        Try
            koneksi = DB.OpenConnection(StrConnAccounting)
            transaksi = koneksi.BeginTransaction()

            If Not SaveDataHdr(koneksi, transaksi, pesanError) Then
                transaksi.Rollback()

                MsgBoxCustom.Show("Simpan data gagal." & vbCrLf & pesanError,
                    MsgBoxCustom.ButtonType.OK,
                    MsgBoxCustom.IconType.Error)
                Exit Sub
            End If

            transaksi.Commit()

            MsgBoxCustom.Show("Data berhasil disimpan",
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Information)

            Dim kode As String = txtKodeSup.Text.Trim()

            Call KondisiAwal()
            Call ShowData(kode)

        Catch ex As Exception
            Try
                If transaksi IsNot Nothing Then transaksi.Rollback()
            Catch
            End Try

            MsgBoxCustom.Show("Gagal menyimpan data supplier." & vbCrLf & ex.Message,
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Error)

        Finally
            If koneksi IsNot Nothing AndAlso
               koneksi.State <> ConnectionState.Closed Then
                koneksi.Close()
            End If

            Me.Cursor = Cursors.Default
        End Try
    End Sub

#End Region

#Region "Tombol Aksi"

    Private Sub btnAdd_Click(
        sender As Object, e As EventArgs
    ) Handles btnAdd.Click

        Call ClearData()
        Call ControlEnabled(True)
        Call CmdEnabled(False)

        perintah = "ADD"
        txtKodeSup.Enabled = True
        txtKodeSup.Focus()
    End Sub

    Private Sub btnEdit_Click(
        sender As Object, e As EventArgs
    ) Handles btnEdit.Click

        If Trim(txtKodeSup.Text) = "" Then
            MsgBoxCustom.Show("Silakan cari supplier terlebih dahulu.",
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Information)
            Exit Sub
        End If

        Call ControlEnabled(True)
        Call CmdEnabled(False)

        txtKodeSup.Enabled = False
        perintah = "Edit"
    End Sub

    Private Sub btnFind_Click(
        sender As Object, e As EventArgs
    ) Handles btnFind.Click

        FrmMain.BukaMenu(FrmMstSupplierMainShow, FrmMain.mnuMstSupplierMainSupplier)
    End Sub

    Private Sub btnCancel_Click(
        sender As Object, e As EventArgs
    ) Handles btnCancel.Click

        Call KondisiAwal()
    End Sub

    Private Sub btnDelete_Click(
        sender As Object, e As EventArgs
    ) Handles btnDelete.Click

        If Trim(txtKodeSup.Text) = "" Then
            MsgBoxCustom.Show("Silakan cari supplier yang akan dinonaktifkan.",
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Information)
            Exit Sub
        End If

        MsgBoxCustom.Show("Penonaktifan belum dijalankan. Gunakan stored procedure supplier untuk memastikan perubahan juga tersinkron ke database terkait.",
            MsgBoxCustom.ButtonType.OK,
            MsgBoxCustom.IconType.Information)
    End Sub

    Private Sub btnExit_Click(
        sender As Object, e As EventArgs
    ) Handles btnExit.Click

        Me.Close()
    End Sub

    Private Sub FrmMstSupplierMain_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Func.ControlCentreForm(Me, PanelForm)
    End Sub

#End Region

End Class