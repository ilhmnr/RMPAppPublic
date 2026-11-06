
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports C1.Win.C1FlexGrid

Public Class FrmMstItemInventory

    Private Enum FormMode
        Normal
        Add
        Update
    End Enum

    Private mode As FormMode = FormMode.Normal
    Private dt As New DataTable

    Private IDBarang As Integer
    Private KodeBarang As String = ""
    Private NamaBarang As String = ""
    Private KategoriBarang As String = ""
    Private SatuanBarang As String = ""
    Private Harga As Long
    Private TglBerlaku As DateTime = DateTime.Now

    Private LinkFillUpload As String = ""
    Private NamaGambar As String = ""
    Private NamaGambarLama As String = ""
    Private nama_foto As String = ""
    Private fotoBaruDipilih As Boolean

    Private ReadOnly FolderName As String =
        cls_Webdav.WebDavRMPInvItemFolder

    Private Sub FrmMstItem_Load(
        sender As Object, e As EventArgs
    ) Handles MyBase.Load

        ClsFlexGrid.ApplyStyle(fg)

        Combo.InvCategory(CmbKategori)
        Combo.InvCategory(CmbKategoriCari)
        Combo.InvCategory(CmbKategoriEdit)
        Combo.InvCategory(CmbUpdateKategori)

        Combo.InvSatuan(CmbSatuan)
        Combo.InvSatuan(CmbSatuanCari)
        Combo.InvSatuan(CmbSatuanEdit)
        Combo.InvSatuan(CmbUpdateSatuan)

        Combo.InvKodeBarang(CmbKodeBarangCari)

        ClearData()
        ShowData()
    End Sub

    Private Sub ClearData()
        mode = FormMode.Normal
        KodeBarang = ""

        TxtKodeItem.Clear()
        TxtNamaItem.Clear()
        TxtHarga.Clear()

        CmbKategori.SelectedIndex = -1
        CmbSatuan.SelectedIndex = -1
        DtpTanggal.Value = DateTime.Now

        LinkFillUpload = ""
        NamaGambar = ""
        NamaGambarLama = ""
        nama_foto = ""
        fotoBaruDipilih = False

        txtFileAttachment.Clear()
        SetPicturePlaceholder()

        TxtKodeItem.Enabled = False
        TxtNamaItem.Enabled = False
        TxtHarga.Enabled = False
        CmbKategori.Enabled = False
        CmbSatuan.Enabled = False
        DtpTanggal.Enabled = False

        RdPCG.Enabled = True
        RdBPB.Enabled = True
        TxtCariNamaBarang.Enabled = True

        ChkTgl.Enabled = True
        DtpStart.Enabled = ChkTgl.Checked
        Dtpend.Enabled = ChkTgl.Checked

        ChkKdItem.Enabled = True
        CmbKodeBarangCari.Enabled = ChkKdItem.Checked

        ChkKategori.Enabled = True
        CmbKategoriCari.Enabled = ChkKategori.Checked

        ChkSatuan.Enabled = True
        CmbSatuanCari.Enabled = ChkSatuan.Checked

        fg.Enabled = True

        btnAdd.Enabled = True
        BtnUpdate.Enabled = False
        btnSave.Enabled = False
        btnCancel.Enabled = False
        btnRefresh.Enabled = True
        btnFileChooseImage.Enabled = False
    End Sub

    Private Sub SetPicture(img As Image)
        Dim gambarBaru As Image = Nothing

        If img IsNot Nothing Then
            gambarBaru = New Bitmap(img)
        End If

        Dim gambarLama As Image = pictItem.Image
        pictItem.Image = gambarBaru

        If gambarLama IsNot Nothing Then
            gambarLama.Dispose()
        End If
    End Sub

    Private Sub SetPicturePlaceholder()
        SetPicture(My.Resources.no_image)
    End Sub

    Private Sub SetEditControls(editing As Boolean)
        TxtNamaItem.Enabled = editing
        TxtHarga.Enabled = editing
        CmbKategori.Enabled = editing
        CmbSatuan.Enabled = editing
        DtpTanggal.Enabled = editing
        btnFileChooseImage.Enabled = editing

        TxtKodeItem.Enabled = False

        RdPCG.Enabled = Not editing
        RdBPB.Enabled = Not editing
        TxtCariNamaBarang.Enabled = Not editing

        ChkTgl.Enabled = Not editing
        DtpStart.Enabled = Not editing AndAlso ChkTgl.Checked
        Dtpend.Enabled = Not editing AndAlso ChkTgl.Checked

        ChkKdItem.Enabled = Not editing
        CmbKodeBarangCari.Enabled =
            Not editing AndAlso ChkKdItem.Checked

        ChkKategori.Enabled = Not editing
        CmbKategoriCari.Enabled =
            Not editing AndAlso ChkKategori.Checked

        ChkSatuan.Enabled = Not editing
        CmbSatuanCari.Enabled =
            Not editing AndAlso ChkSatuan.Checked

        fg.Enabled = Not editing

        btnAdd.Enabled = Not editing
        BtnUpdate.Enabled = False
        btnSave.Enabled = editing
        btnCancel.Enabled = editing
        btnRefresh.Enabled = Not editing
    End Sub

    Private Sub ShowData()
        If mode <> FormMode.Normal Then Return

        Try
            Dim sql As String =
                "SELECT ID, KodeBarang, NamaBarang, Kategori, Satuan, " &
                "Harga, TglPeriode, CreatedBy, CreatedDate, " &
                "NotActived, NamaFoto " &
                "FROM dbo.TblInv_MstBarang WHERE NotActived = 0"

            Using conn As New SqlConnection(StrConnRMPApp)
                Using cmd As New SqlCommand()
                    cmd.Connection = conn

                    If ChkTgl.Checked Then
                        sql &= " AND TglPeriode >= @TglAwal " &
                               "AND TglPeriode < DATEADD(DAY, 1, @TglAkhir)"

                        cmd.Parameters.Add(
                            "@TglAwal", SqlDbType.DateTime).Value =
                            DtpStart.Value.Date

                        cmd.Parameters.Add(
                            "@TglAkhir", SqlDbType.DateTime).Value =
                            Dtpend.Value.Date
                    End If

                    If ChkKdItem.Checked AndAlso
                       CmbKodeBarangCari.Text.Trim() <> "" Then

                        sql &= " AND KodeBarang = @KodeBarang"

                        cmd.Parameters.Add(
                            "@KodeBarang", SqlDbType.VarChar, 50).Value =
                            CmbKodeBarangCari.Text.Trim()
                    End If

                    If ChkKategori.Checked AndAlso
                       CmbKategoriCari.Text.Trim() <> "" Then

                        sql &= " AND Kategori = @Kategori"

                        cmd.Parameters.Add(
                            "@Kategori", SqlDbType.VarChar, 100).Value =
                            CmbKategoriCari.Text.Trim()
                    End If

                    If ChkSatuan.Checked AndAlso
                       CmbSatuanCari.Text.Trim() <> "" Then

                        sql &= " AND Satuan = @Satuan"

                        cmd.Parameters.Add(
                            "@Satuan", SqlDbType.VarChar, 20).Value =
                            CmbSatuanCari.Text.Trim()
                    End If

                    If TxtCariNamaBarang.Text.Trim() <> "" Then
                        sql &= " AND NamaBarang LIKE @NamaBarang"

                        cmd.Parameters.Add(
                            "@NamaBarang", SqlDbType.VarChar, 100).Value =
                            "%" & TxtCariNamaBarang.Text.Trim() & "%"
                    End If

                    If RdPCG.Checked Then
                        sql &= " AND LEFT(KodeBarang, 3) = 'BRG'"
                    ElseIf RdBPB.Checked Then
                        sql &= " AND LEFT(KodeBarang, 3) <> 'BRG'"
                    End If

                    sql &= " ORDER BY NamaBarang ASC"
                    cmd.CommandText = sql

                    Using da As New SqlDataAdapter(cmd)
                        dt = New DataTable()
                        da.Fill(dt)
                    End Using
                End Using
            End Using

            fg.Rows.Count = 1

            For Each dr As DataRow In dt.Rows
                Dim rowIndex As Integer = fg.Rows.Count
                fg.Rows.Add()

                fg.Item(rowIndex, "KodeBarang") = dr("KodeBarang")
                fg.Item(rowIndex, "NamaBarang") = dr("NamaBarang")
                fg.Item(rowIndex, "Kategori") = dr("Kategori")
                fg.Item(rowIndex, "Satuan") = dr("Satuan")
                fg.Item(rowIndex, "Harga") = dr("Harga")
                fg.Item(rowIndex, "TanggalPeriode") = dr("TglPeriode")
                fg.Item(rowIndex, "CreatedBy") = dr("CreatedBy")
                fg.Item(rowIndex, "CreatedDate") = dr("CreatedDate")
                fg.Item(rowIndex, "NotActived") = dr("NotActived")
                fg.Item(rowIndex, "ID") = dr("ID")
            Next

            fg.AutoSizeCols()

        Catch ex As Exception
            'MessageBox.Show(
            '    "Gagal menampilkan data: " & ex.Message,
            '    "Master Barang",
            '    MessageBoxButtons.OK,
            '    MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidasiInput() As Boolean
        If TxtNamaItem.Text.Trim() = "" Then
            MessageBox.Show(
                "Nama barang wajib diisi.", AT,
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtNamaItem.Focus()
            Return False
        End If

        If TxtHarga.Text.Trim() = "" Then
            MessageBox.Show(
                "Harga barang wajib diisi.", AT,
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtHarga.Focus()
            Return False
        End If

        Dim hargaBersih As String =
            TxtHarga.Text.Trim().Replace(".", "").Replace(",", "")

        If Not Long.TryParse(hargaBersih, Harga) OrElse Harga < 0 Then
            MessageBox.Show(
                "Harga barang tidak valid.", AT,
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtHarga.Focus()
            Return False
        End If

        If CmbKategori.Text.Trim() = "" Then
            MessageBox.Show(
                "Kategori barang wajib dipilih.", AT,
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            CmbKategori.Focus()
            Return False
        End If

        If CmbSatuan.Text.Trim() = "" Then
            MessageBox.Show(
                "Satuan barang wajib dipilih.", AT,
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            CmbSatuan.Focus()
            Return False
        End If

        If mode = FormMode.Update AndAlso
           (TxtKodeItem.Text.Trim() = "" OrElse IDBarang <= 0) Then

            MessageBox.Show(
                "Pilih barang yang akan diedit terlebih dahulu.",
                AT, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    Private Function CekDuplikat(
        conn As SqlConnection,
        trans As SqlTransaction
    ) As Boolean

        If mode <> FormMode.Add Then Return False

        Const sql As String =
            "SELECT COUNT(1) FROM dbo.TblInv_MstBarang " &
            "WHERE NotActived = 0 AND NamaBarang = @NamaBarang " &
            "AND Kategori = @Kategori AND Satuan = @Satuan AND Harga = @Harga"

        Using cmd As New SqlCommand(sql, conn, trans)
            cmd.Parameters.Add(
                "@NamaBarang", SqlDbType.VarChar, 100).Value = NamaBarang

            cmd.Parameters.Add(
                "@Kategori", SqlDbType.VarChar, 100).Value = KategoriBarang

            cmd.Parameters.Add(
                "@Satuan", SqlDbType.VarChar, 20).Value = SatuanBarang

            cmd.Parameters.Add(
                "@Harga", SqlDbType.BigInt).Value = Harga

            Return Convert.ToInt32(cmd.ExecuteScalar()) > 0
        End Using
    End Function

    Private Function Sp_SaveMstBarang(
        conn As SqlConnection,
        trans As SqlTransaction
    ) As Boolean

        Using cmd As New SqlCommand(
            "dbo.spInv_saveMstBarang", conn, trans)

            cmd.CommandType = CommandType.StoredProcedure

            With cmd.Parameters
                .Add("@KodeBarang", SqlDbType.VarChar, 50).Value =
                    If(String.IsNullOrWhiteSpace(KodeBarang),
                       String.Empty, KodeBarang)

                .Add("@NamaBarang", SqlDbType.VarChar, 100).Value =
                    NamaBarang

                .Add("@HargaBarang", SqlDbType.BigInt).Value = Harga

                .Add("@TglPeriode", SqlDbType.DateTime).Value =
                    TglBerlaku

                .Add("@KategoriBarang", SqlDbType.VarChar, 100).Value =
                    KategoriBarang

                .Add("@SatuanBarang", SqlDbType.VarChar, 20).Value =
                    SatuanBarang

                .Add("@UserLogin", SqlDbType.VarChar, 50).Value =
                    ClsSession.UserID

                With .Add("@Flag", SqlDbType.TinyInt)
                    .Direction = ParameterDirection.InputOutput
                    .Value = CByte(0)
                End With

                With .Add("@GetNamaFotoBaru", SqlDbType.VarChar, 100)
                    .Direction = ParameterDirection.InputOutput
                    .Value = ""
                End With

                With .Add("@IDBarang", SqlDbType.Int)
                    .Direction = ParameterDirection.InputOutput
                    .Value = IDBarang
                End With
            End With

            cmd.ExecuteNonQuery()

            If Convert.ToInt32(cmd.Parameters("@Flag").Value) <> 1 Then
                Return False
            End If

            KodeBarang =
                Convert.ToString(cmd.Parameters("@KodeBarang").Value)

            nama_foto =
                If(cmd.Parameters("@GetNamaFotoBaru").Value Is Nothing OrElse
                   cmd.Parameters("@GetNamaFotoBaru").Value Is DBNull.Value,
                   "",
                   Convert.ToString(
                       cmd.Parameters("@GetNamaFotoBaru").Value).Trim())

            If cmd.Parameters("@IDBarang").Value Is Nothing OrElse
               cmd.Parameters("@IDBarang").Value Is DBNull.Value Then

                Throw New InvalidOperationException(
                    "Stored procedure tidak mengembalikan ID barang.")
            End If

            IDBarang = Convert.ToInt32(cmd.Parameters("@IDBarang").Value)

            If IDBarang <= 0 Then
                Throw New InvalidOperationException(
                    "ID barang tidak valid.")
            End If

            Return True
        End Using
    End Function

    'Mengecek apakah nama foto sudah digunakan di server.
    'DownloadFileWebDav harus mengembalikan Image jika file ditemukan.
    Private Function FotoAdaDiServer(namaFile As String) As Boolean
        Dim foto As Image = Nothing

        Try
            foto = ClsWebDAV.DownloadFileWebDav(
                cls_Webdav.WebDavRMPInvItem,
                FolderName,
                IDBarang.ToString(),
                namaFile)

            Return foto IsNot Nothing

        Catch
            Return False

        Finally
            If foto IsNot Nothing Then foto.Dispose()
        End Try
    End Function

    Private Function SimpanFoto(
        conn As SqlConnection,
        trans As SqlTransaction
    ) As Boolean

        If Not fotoBaruDipilih Then Return True

        If String.IsNullOrWhiteSpace(LinkFillUpload) OrElse
           Not File.Exists(LinkFillUpload) Then

            Throw New FileNotFoundException(
                "File foto yang dipilih tidak ditemukan.",
                LinkFillUpload)
        End If

        If IDBarang <= 0 Then
            Throw New InvalidOperationException(
                "ID barang tidak tersedia untuk menyimpan foto.")
        End If

        'Nama file berasal dari file yang dipilih pengguna.
        Dim namaAsli As String = Path.GetFileName(LinkFillUpload)
        Dim namaTujuan As String = namaAsli

        'Upload menggunakan nama unik agar file lama tidak tertimpa.
        Dim berhasil As Boolean =
            ClsWebDAV.UploadFileWebDav(
                LinkFillUpload,
                FolderName,
                IDBarang.ToString(),
                namaTujuan)

        If Not berhasil Then Return False

        'Simpan nama file aktual ke database.
        Using cmd As New SqlCommand(
            "UPDATE dbo.TblInv_MstBarang " &
            "SET NamaFoto = @NamaFoto WHERE ID = @IDBarang",
            conn, trans)

            cmd.Parameters.Add(
                "@NamaFoto", SqlDbType.VarChar, 100).Value = namaTujuan

            cmd.Parameters.Add(
                "@IDBarang", SqlDbType.Int).Value = IDBarang

            If cmd.ExecuteNonQuery() <> 1 Then
                Throw New InvalidOperationException(
                    "Nama foto gagal diperbarui pada database.")
            End If
        End Using

        NamaGambarLama = namaTujuan
        NamaGambar = namaAsli
        nama_foto = namaTujuan
        txtFileAttachment.Text = namaTujuan

        Return True
    End Function

    Private Sub TampilkanFotoLama()
        SetPicturePlaceholder()

        If IDBarang <= 0 OrElse
           String.IsNullOrWhiteSpace(NamaGambarLama) Then

            txtFileAttachment.Clear()
            Return
        End If

        Dim foto As Image = Nothing

        Try
            foto = ClsWebDAV.DownloadFileWebDav(
                cls_Webdav.WebDavRMPInvItem,
                FolderName,
                IDBarang.ToString(),
                NamaGambarLama)

            If foto IsNot Nothing Then
                SetPicture(foto)
            End If

            txtFileAttachment.Text = NamaGambarLama

        Catch ex As Exception
            SetPicturePlaceholder()
            txtFileAttachment.Text = NamaGambarLama

        Finally
            If foto IsNot Nothing Then foto.Dispose()
        End Try
    End Sub

    Private Sub btnAdd_Click(
        sender As Object, e As EventArgs
    ) Handles btnAdd.Click

        ClearData()

        IDBarang = 0
        KodeBarang = ""
        mode = FormMode.Add

        SetEditControls(True)

        LinkFillUpload = ""
        NamaGambar = ""
        NamaGambarLama = ""
        nama_foto = ""
        fotoBaruDipilih = False

        txtFileAttachment.Clear()
        SetPicturePlaceholder()
        TxtNamaItem.Focus()
    End Sub

    Private Sub BtnUpdate_Click(
        sender As Object, e As EventArgs
    ) Handles BtnUpdate.Click

        If fg.Row < 1 OrElse
           fg.Rows.Count <= 1 OrElse
           TxtKodeItem.Text.Trim() = "" OrElse
           IDBarang <= 0 Then

            MessageBox.Show(
                "Pilih barang yang akan diedit terlebih dahulu.",
                AT, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        mode = FormMode.Update
        LinkFillUpload = ""
        NamaGambar = ""
        fotoBaruDipilih = False

        SetEditControls(True)
        TxtNamaItem.Focus()
    End Sub

    Private Sub btnSave_Click(
        sender As Object, e As EventArgs
    ) Handles btnSave.Click

        If mode = FormMode.Normal Then Return
        If Not ValidasiInput() Then Return

        Me.Cursor = Cursors.WaitCursor

        Dim koneksi As SqlConnection = Nothing
        Dim transaksi As SqlTransaction = Nothing
        Dim transaksiAktif As Boolean = False

        Try
            KodeBarang = TxtKodeItem.Text.Trim()
            NamaBarang = TxtNamaItem.Text.Trim().ToUpperInvariant()
            KategoriBarang = CmbKategori.Text.Trim()
            SatuanBarang = CmbSatuan.Text.Trim()
            TglBerlaku = DtpTanggal.Value

            koneksi = New SqlConnection(StrConnRMPApp)
            koneksi.Open()

            transaksi = koneksi.BeginTransaction()
            transaksiAktif = True

            If CekDuplikat(koneksi, transaksi) Then
                Throw New InvalidOperationException(
                    "Barang dengan nama, kategori, satuan, dan harga tersebut sudah ada.")
            End If

            If Not Sp_SaveMstBarang(koneksi, transaksi) Then
                Throw New InvalidOperationException(
                    "Stored procedure tidak mengembalikan status berhasil.")
            End If

            If fotoBaruDipilih AndAlso
               Not SimpanFoto(koneksi, transaksi) Then

                Throw New InvalidOperationException(
                    "Gagal menyimpan foto barang ke WebDAV.")
            End If

            transaksi.Commit()
            transaksiAktif = False

            MessageBox.Show(
                "Data berhasil disimpan.",
                "Master Barang",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            Call ClearData()
            Call LoadDataBarang()
            Call ShowData()

        Catch ex As Exception
            If transaksiAktif AndAlso transaksi IsNot Nothing Then
                Try
                    transaksi.Rollback()
                Catch
                End Try
            End If

            MessageBox.Show(
                "Simpan data gagal: " & ex.Message,
                "Master Barang",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        Finally
            If transaksi IsNot Nothing Then transaksi.Dispose()
            If koneksi IsNot Nothing Then koneksi.Dispose()

            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnCancel_Click(
        sender As Object, e As EventArgs
    ) Handles btnCancel.Click

        ClearData()
        ShowData()
    End Sub

    Private Sub btnRefresh_Click(
        sender As Object, e As EventArgs
    ) Handles btnRefresh.Click

        ShowData()
    End Sub

    Private Sub BtnExit_Click(
        sender As Object, e As EventArgs
    ) Handles BtnExit.Click

        Me.Close()
    End Sub

    Private Sub btnFileChooseImage_Click(
        sender As Object, e As EventArgs
    ) Handles btnFileChooseImage.Click

        If mode = FormMode.Normal Then Return

        If mode = FormMode.Update AndAlso
           (String.IsNullOrWhiteSpace(TxtKodeItem.Text) OrElse
            IDBarang <= 0) Then

            MessageBox.Show(
                "Pilih barang yang akan diedit terlebih dahulu.",
                AT, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using dlg As New OpenFileDialog()
            dlg.Filter = "File Gambar|*.png;*.jpg;*.jpeg;*.bmp"
            dlg.Title = "Pilih Foto Barang"
            dlg.Multiselect = False

            If dlg.ShowDialog() <> DialogResult.OK Then Return

            Try
                If Not Func.ValidateSpecialCharNextcloud(dlg.FileName) Then
                    Return
                End If

                Using img As Image = Image.FromFile(dlg.FileName)
                    SetPicture(img)
                End Using

                LinkFillUpload = dlg.FileName
                NamaGambar = Path.GetFileName(dlg.FileName)
                fotoBaruDipilih = True

                'Preview memakai file yang dipilih.
                txtFileAttachment.Text = NamaGambar

            Catch ex As Exception
                MessageBox.Show(
                    "Gagal membuka gambar: " & ex.Message,
                    "Master Barang",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)
            End Try
        End Using
    End Sub

    Private Sub fg_Click(
    sender As Object, e As EventArgs
) Handles fg.Click

        IDBarang = Convert.ToInt32(fg.Item(fg.Row, "ID"))
        Call LoadDataBarang()
    End Sub

    Private Sub LoadDataBarang()
        If fg.Row < 1 OrElse fg.Rows.Count <= 1 Then Return

        Try
            Dim sql As String =
            "SELECT ID, KodeBarang, NamaBarang, Kategori, Satuan, " &
            "Harga, TglPeriode, NamaFoto " &
            "FROM dbo.TblInv_MstBarang " &
            "WHERE ID = @IDBarang"

            Using conn As New SqlConnection(StrConnRMPApp)
                Using cmd As New SqlCommand(sql, conn)

                    cmd.Parameters.Add("@IDBarang", SqlDbType.Int).Value =
                    IDBarang

                    conn.Open()

                    Using rd As SqlDataReader = cmd.ExecuteReader()

                        If Not rd.Read() Then
                            MessageBox.Show(
                            "Data barang tidak ditemukan.",
                            "Master Barang",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)

                            ClearData()
                            Return
                        End If

                        IDBarang = Convert.ToInt32(rd("ID"))
                        TxtKodeItem.Text = Convert.ToString(rd("KodeBarang"))
                        TxtNamaItem.Text = Convert.ToString(rd("NamaBarang"))
                        CmbKategori.Text = Convert.ToString(rd("Kategori"))
                        CmbSatuan.Text = Convert.ToString(rd("Satuan"))

                        If Not IsDBNull(rd("Harga")) Then
                            TxtHarga.Text =
                            Convert.ToInt64(rd("Harga")).ToString("#,##0")
                        Else
                            TxtHarga.Text = "0"
                        End If

                        If Not IsDBNull(rd("TglPeriode")) Then
                            DtpTanggal.Value =
                            Convert.ToDateTime(rd("TglPeriode"))
                        End If

                        NamaGambarLama =
                        If(IsDBNull(rd("NamaFoto")),
                           "",
                           Convert.ToString(rd("NamaFoto")).Trim())

                    End Using
                End Using
            End Using

            LinkFillUpload = ""
            NamaGambar = ""
            nama_foto = NamaGambarLama
            fotoBaruDipilih = False

            TampilkanFotoLama()

            BtnUpdate.Enabled =
            TxtKodeItem.Text.Trim() <> "" AndAlso RdPCG.Checked

        Catch ex As Exception
            MessageBox.Show(
            "Gagal mengambil data barang: " & ex.Message,
            "Master Barang",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ChkKdItem_CheckedChanged(
        sender As Object, e As EventArgs
    ) Handles ChkKdItem.CheckedChanged

        If mode <> FormMode.Normal Then Return

        CmbKodeBarangCari.Enabled = ChkKdItem.Checked

        If Not ChkKdItem.Checked Then
            CmbKodeBarangCari.SelectedIndex = -1
        End If
    End Sub

    Private Sub ChkTgl_CheckedChanged(
        sender As Object, e As EventArgs
    ) Handles ChkTgl.CheckedChanged

        If mode <> FormMode.Normal Then Return

        DtpStart.Enabled = ChkTgl.Checked
        Dtpend.Enabled = ChkTgl.Checked
    End Sub

    Private Sub ChkKategori_CheckedChanged(
        sender As Object, e As EventArgs
    ) Handles ChkKategori.CheckedChanged

        If mode <> FormMode.Normal Then Return

        CmbKategoriCari.Enabled = ChkKategori.Checked

        If Not ChkKategori.Checked Then
            CmbKategoriCari.SelectedIndex = -1
        End If
    End Sub

    Private Sub ChkSatuan_CheckedChanged(
        sender As Object, e As EventArgs
    ) Handles ChkSatuan.CheckedChanged

        If mode <> FormMode.Normal Then Return

        CmbSatuanCari.Enabled = ChkSatuan.Checked

        If Not ChkSatuan.Checked Then
            CmbSatuanCari.SelectedIndex = -1
        End If
    End Sub

    Private Sub TxtCariNamaBarang_KeyDown(
        sender As Object, e As KeyEventArgs
    ) Handles TxtCariNamaBarang.KeyDown

        If e.KeyCode = Keys.Enter AndAlso mode = FormMode.Normal Then
            e.SuppressKeyPress = True
            ShowData()
        End If
    End Sub

    Private Sub TxtHarga_KeyPress(
        sender As Object, e As KeyPressEventArgs
    ) Handles TxtHarga.KeyPress

        If Not Char.IsControl(e.KeyChar) AndAlso
           Not Char.IsDigit(e.KeyChar) Then

            e.Handled = True
        End If
    End Sub

    Private Sub TxtHarga_Enter(
        sender As Object, e As EventArgs
    ) Handles TxtHarga.Enter

        TxtHarga.Text =
            TxtHarga.Text.Replace(".", "").Replace(",", "")

        TxtHarga.SelectionStart = TxtHarga.Text.Length
    End Sub

    Private Sub TxtHarga_Leave(
        sender As Object, e As EventArgs
    ) Handles TxtHarga.Leave

        Dim nilai As Long

        If Long.TryParse(
            TxtHarga.Text.Replace(".", "").Replace(",", ""),
            nilai) Then

            TxtHarga.Text = nilai.ToString("#,##0")
        End If
    End Sub

    Private Sub RdPCG_CheckedChanged(
        sender As Object, e As EventArgs
    ) Handles RdPCG.CheckedChanged

        If mode <> FormMode.Normal Then Return

        BtnUpdate.Enabled = False
        fg.Rows.Count = 1
        ShowData()
    End Sub

    Private Sub RdBPB_CheckedChanged(
        sender As Object, e As EventArgs
    ) Handles RdBPB.CheckedChanged

        If mode <> FormMode.Normal Then Return

        BtnUpdate.Enabled = False
        fg.Rows.Count = 1
        ShowData()
    End Sub

    Private Sub Filter_Changed(
        sender As Object, e As EventArgs
    ) Handles CmbKodeBarangCari.SelectedIndexChanged,
              CmbKategoriCari.SelectedIndexChanged,
              CmbSatuanCari.SelectedIndexChanged,
              DtpStart.ValueChanged,
              Dtpend.ValueChanged

        If mode = FormMode.Normal AndAlso IsHandleCreated Then
            ShowData()
        End If
    End Sub

End Class
