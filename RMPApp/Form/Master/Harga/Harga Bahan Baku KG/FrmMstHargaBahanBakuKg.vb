Imports System.Data.SqlClient

Public Class FrmMstHargaBahanBakuKg

    Private Enum FormMode
        Normal
        Add
        Edit
    End Enum

    Private mode As FormMode = FormMode.Normal
    Private loading As Boolean = False

    Private ReadOnly ConnString As String = StrConnAccounting

    Private ReadOnly Property UserIDAktif As String
        Get
            Return ClsSession.UserID.Trim()
        End Get
    End Property

    Private ReadOnly Property KodeGroupTerpilih As String
        Get
            If ComboBox1.SelectedValue Is Nothing OrElse
               TypeOf ComboBox1.SelectedValue Is DataRowView Then
                Return ""
            End If

            Return Convert.ToString(ComboBox1.SelectedValue).Trim()
        End Get
    End Property

    '========================================================
    ' KOLOM GRID BERDASARKAN NAME DESIGNER
    '========================================================
    Private Function KolomGrid(namaKolom As String) As Integer

        For i As Integer = 0 To fg.Cols.Count - 1
            If String.Equals(
                fg.Cols(i).Name,
                namaKolom,
                StringComparison.OrdinalIgnoreCase
            ) Then
                Return i
            End If
        Next

        Throw New Exception(
            "Kolom '" & namaKolom &
            "' tidak ditemukan. Periksa Name kolom pada Designer."
        )

    End Function

    '========================================================
    ' LOAD
    '========================================================
    Private Sub FrmMstHargaBahanBakuKg_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        Try
            ClsFlexGrid.ApplyStyle(fg)

            loading = True

            DateTimePicker1.Value = TanggalPeriodeAwal()

            IsiJenis()
            KondisiAwal()
            BuatKodeHarga()

            loading = False

            TampilkanData(txtKodeHarga.Text.Trim())

        Catch ex As Exception
            loading = False

            MsgBox(
                "Gagal membuka form: " & ex.Message,
                MsgBoxStyle.Exclamation,
                "Informasi"
            )
        End Try

    End Sub

    Private Function TanggalPeriodeAwal() As Date

        Dim periode As Date = Now
        Dim hari As Integer = Math.Min(
            Date.Today.Day,
            Date.DaysInMonth(periode.Year, periode.Month)
        )

        Return New Date(periode.Year, periode.Month, hari)

    End Function

    '========================================================
    ' GROUP SUPPLIER
    '========================================================
    Private Sub IsiJenis()

        Dim dt As New DataTable

        Using cn As New SqlConnection(ConnString)
            Using cmd As New SqlCommand(
                "SELECT KodeGroupSup, NamaGroup " &
                "FROM tblRMMstGroupSupplier " &
                "WHERE NotActive = 0 " &
                "ORDER BY KodeGroupSup",
                cn
            )

                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using

            End Using
        End Using

        ComboBox1.DataSource = Nothing
        ComboBox1.DisplayMember = "NamaGroup"
        ComboBox1.ValueMember = "KodeGroupSup"
        ComboBox1.DataSource = dt
        ComboBox1.SelectedIndex = -1

    End Sub

    '========================================================
    ' HEADER HARGA
    '========================================================
    Private Sub AturHeaderHarga()

        Select Case ComboBox1.Text.Trim()

            Case "Jambul"
                fg.Item(0, KolomGrid("HargaA")) = "Jambul-A"
                fg.Item(0, KolomGrid("HargaB")) = "Jambul-B"

            Case "Licin"
                fg.Item(0, KolomGrid("HargaA")) = "Licin-A"
                fg.Item(0, KolomGrid("HargaB")) = "Licin-B"

            Case Else
                fg.Item(0, KolomGrid("HargaA")) = "Harga A"
                fg.Item(0, KolomGrid("HargaB")) = "Harga B"

        End Select

    End Sub

    '========================================================
    ' KONDISI AWAL
    '========================================================
    Private Sub KondisiAwal()

        mode = FormMode.Normal

        btnTambah.Enabled = True
        btnEdit.Enabled = True
        btnHapus.Enabled = True
        btnSimpan.Enabled = False
        btnBatal.Enabled = False
        btnTutup.Enabled = True

        DateTimePicker1.Enabled = True
        ComboBox1.Enabled = True

        fg.AllowEditing = False
        fg.Rows.Count = 1

        AturHeaderHarga()

    End Sub

    '========================================================
    ' MODE TAMBAH / EDIT
    '========================================================
    Private Sub ModeEntryEdit()

        btnTambah.Enabled = False
        btnEdit.Enabled = False
        btnHapus.Enabled = False
        btnSimpan.Enabled = True
        btnBatal.Enabled = True
        btnTutup.Enabled = False

        fg.AllowEditing = True

        For i As Integer = 0 To fg.Cols.Count - 1
            fg.Cols(i).AllowEditing = False
        Next

        fg.Cols(KolomGrid("HargaA")).AllowEditing = True
        fg.Cols(KolomGrid("HargaB")).AllowEditing = True

    End Sub

    Private Sub BersihkanData()

        txtKodeHarga.Clear()
        ComboBox1.SelectedIndex = -1
        fg.Rows.Count = 1

        AturHeaderHarga()

    End Sub

    '========================================================
    ' BUAT KODE HARGA
    '========================================================
    Private Sub BuatKodeHarga()

        Dim nomorTerakhir As Integer = 0
        Dim periode As Date = DateTimePicker1.Value

        Const sql As String =
            "SELECT TOP 1 LEFT(KodeHargaString, 3) AS Nomor " &
            "FROM tblRMMstHargaBahanBakuHdr " &
            "WHERE MONTH(Periode) = @Bulan " &
            "AND YEAR(Periode) = @Tahun " &
            "ORDER BY KodeHargaString DESC"

        Using cn As New SqlConnection(ConnString)
            Using cmd As New SqlCommand(sql, cn)

                cmd.Parameters.Add("@Bulan", SqlDbType.Int).Value =
                    periode.Month

                cmd.Parameters.Add("@Tahun", SqlDbType.Int).Value =
                    periode.Year

                cn.Open()

                Dim hasil As Object = cmd.ExecuteScalar()

                If hasil IsNot Nothing AndAlso hasil IsNot DBNull.Value Then
                    Integer.TryParse(hasil.ToString(), nomorTerakhir)
                End If

            End Using
        End Using

        txtKodeHarga.Text =
            (nomorTerakhir + 1).ToString("000") & "/" &
            periode.Month.ToString() & "/" &
            periode.Year.ToString()

    End Sub

    Private Function KodeHargaTerakhirGroup() As String

        Const sql As String =
            "SELECT TOP 1 KodeHargaString " &
            "FROM tblRMMstHargaBahanBakuHdr " &
            "WHERE AsalKelapa = @AsalKelapa " &
            "ORDER BY Periode DESC, KodeHargaString DESC"

        Using cn As New SqlConnection(ConnString)
            Using cmd As New SqlCommand(sql, cn)

                cmd.Parameters.Add(
                    "@AsalKelapa",
                    SqlDbType.VarChar,
                    10
                ).Value = KodeGroupTerpilih

                cn.Open()

                Dim hasil As Object = cmd.ExecuteScalar()

                If hasil Is Nothing OrElse hasil Is DBNull.Value Then
                    Return ""
                End If

                Return hasil.ToString()

            End Using
        End Using

    End Function

    '========================================================
    ' TAMPILKAN DATA
    '========================================================
    Private Sub TampilkanData(
        Optional kodeHarga As String = "",
        Optional modeTambah As Boolean = False
    )

        If loading Then Return

        If String.IsNullOrWhiteSpace(KodeGroupTerpilih) Then
            fg.Rows.Count = 1
            AturHeaderHarga()
            Return
        End If

        AturHeaderHarga()

        Dim kodeReferensi As String = kodeHarga

        If modeTambah Then
            kodeReferensi = KodeHargaTerakhirGroup()
        End If

        Const sql As String =
            "SELECT " &
            "a.KodeSup, a.NamaSup, a.Alamat, " &
            "ISNULL(h.HargaA, 0) AS HargaA, " &
            "ISNULL(h.HargaB, 0) AS HargaB " &
            "FROM tblRMMstSupplier1 a " &
            "LEFT JOIN (" &
            "   SELECT KodeSup, " &
            "   SUM(CASE WHEN KodeGrade = @GradeA THEN Harga ELSE 0 END) AS HargaA, " &
            "   SUM(CASE WHEN KodeGrade = @GradeB THEN Harga ELSE 0 END) AS HargaB " &
            "   FROM tblRMMstHargaBahanBakuDtl " &
            "   WHERE KodeHargaString = @KodeHarga " &
            "   GROUP BY KodeSup " &
            ") h ON h.KodeSup = a.KodeSup " &
            "WHERE (a.NotActive <> 1 OR a.NotActive IS NULL) " &
            "ORDER BY a.NamaSup, a.KodeSup"

        Using cn As New SqlConnection(ConnString)
            Using cmd As New SqlCommand(sql, cn)

                cmd.Parameters.Add(
                    "@GradeA",
                    SqlDbType.VarChar,
                    10
                ).Value = Convert.ToString(
                    fg.Item(0, KolomGrid("HargaA"))
                )

                cmd.Parameters.Add(
                    "@GradeB",
                    SqlDbType.VarChar,
                    10
                ).Value = Convert.ToString(
                    fg.Item(0, KolomGrid("HargaB"))
                )

                cmd.Parameters.Add(
                    "@KodeHarga",
                    SqlDbType.VarChar,
                    25
                ).Value = kodeReferensi

                Using da As New SqlDataAdapter(cmd)

                    Dim dt As New DataTable
                    da.Fill(dt)

                    fg.Rows.Count = 1

                    For i As Integer = 0 To dt.Rows.Count - 1

                        Dim row As Integer = fg.Rows.Count
                        fg.Rows.Count += 1

                        fg.Item(row, KolomGrid("No")) = i + 1

                        fg.Item(row, KolomGrid("KodeSup")) =
                            Convert.ToString(dt.Rows(i)("KodeSup"))

                        fg.Item(row, KolomGrid("KodeSupSimpan")) =
                            Convert.ToString(dt.Rows(i)("KodeSup"))

                        fg.Item(row, KolomGrid("NamaSup")) =
                            Convert.ToString(dt.Rows(i)("NamaSup"))

                        fg.Item(row, KolomGrid("Alamat")) =
                            Convert.ToString(dt.Rows(i)("Alamat"))

                        fg.Item(row, KolomGrid("HargaA")) =
                            Convert.ToDecimal(dt.Rows(i)("HargaA"))

                        fg.Item(row, KolomGrid("HargaB")) =
                            Convert.ToDecimal(dt.Rows(i)("HargaB"))

                    Next

                End Using
            End Using
        End Using

        fg.AllowEditing = (mode = FormMode.Add OrElse mode = FormMode.Edit)

    End Sub

    '========================================================
    ' PILIH GROUP SUPPLIER
    '========================================================
    Private Sub ComboBox1_SelectedIndexChanged(
        sender As Object,
        e As EventArgs
    ) Handles ComboBox1.SelectedIndexChanged

        If loading Then Return
        If ComboBox1.SelectedIndex < 0 Then Return

        Try
            AturHeaderHarga()

            If mode = FormMode.Add Then
                BuatKodeHarga()
                TampilkanData(txtKodeHarga.Text.Trim(), True)
            Else
                TampilkanData(txtKodeHarga.Text.Trim())
            End If

        Catch ex As Exception
            MsgBox(
                "Gagal menampilkan data supplier: " & ex.Message,
                MsgBoxStyle.Exclamation,
                "Informasi"
            )
        End Try

    End Sub

    '========================================================
    ' TAMBAH
    '========================================================
    Private Sub btnTambah_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnTambah.Click

        Try
            mode = FormMode.Add

            BersihkanData()
            DateTimePicker1.Value = TanggalPeriodeAwal()

            ModeEntryEdit()

            DateTimePicker1.Enabled = True
            ComboBox1.Enabled = True

            BuatKodeHarga()

            If ComboBox1.SelectedIndex >= 0 Then
                TampilkanData(txtKodeHarga.Text.Trim(), True)
            End If

        Catch ex As Exception
            MsgBox(
                "Gagal memulai entry: " & ex.Message,
                MsgBoxStyle.Exclamation,
                "Informasi"
            )
        End Try

    End Sub

    '========================================================
    ' EDIT
    '========================================================
    Private Sub btnEdit_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnEdit.Click

        If String.IsNullOrWhiteSpace(KodeGroupTerpilih) Then
            MsgBox(
                "Tentukan Group Supplier terlebih dahulu.",
                MsgBoxStyle.Exclamation,
                "Informasi"
            )
            ComboBox1.Focus()
            Return
        End If

        If fg.Rows.Count <= 1 Then
            MsgBox(
                "Tidak ada daftar bahan baku yang diubah.",
                MsgBoxStyle.Exclamation,
                "Informasi"
            )
            Return
        End If

        mode = FormMode.Edit
        ModeEntryEdit()

        DateTimePicker1.Enabled = False
        ComboBox1.Enabled = False

    End Sub

    '========================================================
    ' BATAL
    '========================================================
    Private Sub btnBatal_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnBatal.Click

        Try
            loading = True

            DateTimePicker1.Value = TanggalPeriodeAwal()
            BersihkanData()

            loading = False

            KondisiAwal()
            BuatKodeHarga()

        Catch ex As Exception
            loading = False

            MsgBox(
                "Gagal membatalkan proses: " & ex.Message,
                MsgBoxStyle.Exclamation,
                "Informasi"
            )
        End Try

    End Sub

    Private Sub btnTutup_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnTutup.Click

        Me.Close()

    End Sub

    '========================================================
    ' SIMPAN HEADER
    '========================================================
    Private Function SimpanHeader(
        cn As SqlConnection,
        trans As SqlTransaction
    ) As Boolean

        Using cmd As New SqlCommand(
            "spRMMstHargaBahanBakuHdr",
            cn,
            trans
        )

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 600

            Dim returnValue As SqlParameter =
                cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int)

            returnValue.Direction = ParameterDirection.ReturnValue

            cmd.Parameters.Add(
                "@Perintah",
                SqlDbType.VarChar,
                5
            ).Value = If(mode = FormMode.Add, "ADD", "EDIT")

            cmd.Parameters.Add(
                "@KodeHargaString",
                SqlDbType.VarChar,
                25
            ).Value = txtKodeHarga.Text.Trim()

            cmd.Parameters.Add(
                "@KodeJenisBahanBaku",
                SqlDbType.Int
            ).Value = 1

            cmd.Parameters.Add(
                "@AsalKelapa",
                SqlDbType.VarChar,
                10
            ).Value = KodeGroupTerpilih

            cmd.Parameters.Add(
                "@Periode",
                SqlDbType.DateTime
            ).Value = DateTimePicker1.Value.Date

            cmd.Parameters.Add(
                "@PeriodeString",
                SqlDbType.VarChar,
                20
            ).Value = DateTimePicker1.Value.ToString("dd/MM/yyyy")

            cmd.Parameters.Add(
                "@MonthPeriode",
                SqlDbType.VarChar,
                20
            ).Value = DateTimePicker1.Value.ToString("dd/MM/yyyy")

            cmd.Parameters.Add(
                "@CreatedBy",
                SqlDbType.VarChar,
                50
            ).Value = UserIDAktif

            cmd.Parameters.Add(
                "@LastUpdatedBy",
                SqlDbType.VarChar,
                50
            ).Value = UserIDAktif

            Dim flag As SqlParameter =
                cmd.Parameters.Add("@Flag", SqlDbType.TinyInt)

            flag.Direction = ParameterDirection.InputOutput
            flag.Value = CByte(0)

            cmd.ExecuteNonQuery()

            If Convert.ToInt32(returnValue.Value) = 100 Then
                Throw New Exception(
                    "Data sudah ada. Silakan periksa kembali data Anda."
                )
            End If

            If flag.Value Is DBNull.Value OrElse
               Convert.ToInt32(flag.Value) = 0 Then
                Return False
            End If

            Return True

        End Using

    End Function

    '========================================================
    ' SIMPAN DETAIL
    '========================================================
    Private Function SimpanDetail(
        cn As SqlConnection,
        trans As SqlTransaction,
        baris As Integer,
        namaKolomHarga As String
    ) As Boolean

        Using cmd As New SqlCommand(
            "spRMMstHargaBahanBakuDtl",
            cn,
            trans
        )

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 600

            cmd.Parameters.Add("@DetailID", SqlDbType.Int).Value = 1

            cmd.Parameters.Add(
                "@KodeHargaString",
                SqlDbType.VarChar,
                25
            ).Value = txtKodeHarga.Text.Trim()

            cmd.Parameters.Add(
                "@KodeSup",
                SqlDbType.VarChar,
                30
            ).Value = Convert.ToString(
                fg.Item(baris, KolomGrid("KodeSupSimpan"))
            ).Trim()

            cmd.Parameters.Add(
                "@KodeGroupSup",
                SqlDbType.VarChar,
                20
            ).Value = ComboBox1.Text.Trim()

            cmd.Parameters.Add(
                "@KodeGrade",
                SqlDbType.VarChar,
                10
            ).Value = Convert.ToString(
                fg.Item(0, KolomGrid(namaKolomHarga))
            ).Trim()

            Dim harga As Decimal = 0D
            Dim nilai As Object =
                fg.Item(baris, KolomGrid(namaKolomHarga))

            If nilai IsNot Nothing AndAlso nilai IsNot DBNull.Value Then
                Decimal.TryParse(
                    Convert.ToString(nilai),
                    Globalization.NumberStyles.Any,
                    Globalization.CultureInfo.CurrentCulture,
                    harga
                )
            End If

            cmd.Parameters.Add("@Harga", SqlDbType.Float).Value =
                Convert.ToDouble(harga)

            cmd.Parameters.Add(
                "@CreatedBy",
                SqlDbType.VarChar,
                50
            ).Value = UserIDAktif

            cmd.Parameters.Add(
                "@LastUpdatedBy",
                SqlDbType.VarChar,
                50
            ).Value = UserIDAktif

            Dim flag As SqlParameter =
                cmd.Parameters.Add("@Flag", SqlDbType.TinyInt)

            flag.Direction = ParameterDirection.InputOutput
            flag.Value = CByte(0)

            cmd.ExecuteNonQuery()

            Return flag.Value IsNot DBNull.Value AndAlso
                   Convert.ToInt32(flag.Value) <> 0

        End Using

    End Function

    '========================================================
    ' SIMPAN
    '========================================================
    Private Sub btnSimpan_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnSimpan.Click

        If mode <> FormMode.Add AndAlso
           mode <> FormMode.Edit Then Return

        If String.IsNullOrWhiteSpace(KodeGroupTerpilih) Then
            MsgBox(
                "Tentukan Group Supplier terlebih dahulu.",
                MsgBoxStyle.Exclamation,
                "Informasi"
            )
            ComboBox1.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtKodeHarga.Text) Then
            MsgBox(
                "Kode harga belum tersedia.",
                MsgBoxStyle.Exclamation,
                "Informasi"
            )
            Return
        End If

        If fg.Rows.Count <= 1 Then
            MsgBox(
                "Tidak ada data supplier yang disimpan.",
                MsgBoxStyle.Exclamation,
                "Informasi"
            )
            Return
        End If

        Try
            fg.FinishEditing()
            Me.Cursor = Cursors.WaitCursor

            Using cn As New SqlConnection(ConnString)

                cn.Open()

                Using trans As SqlTransaction = cn.BeginTransaction()

                    Try
                        If Not SimpanHeader(cn, trans) Then
                            Throw New Exception(
                                "Proses penyimpanan header gagal."
                            )
                        End If

                        For baris As Integer = 1 To fg.Rows.Count - 1

                            Dim kodeSup As String =
                                Convert.ToString(
                                    fg.Item(
                                        baris,
                                        KolomGrid("KodeSupSimpan")
                                    )
                                ).Trim()

                            If kodeSup = "" Then Continue For

                            For Each namaKolomHarga As String In
                                New String() {"HargaA", "HargaB"}

                                If Not SimpanDetail(
                                    cn,
                                    trans,
                                    baris,
                                    namaKolomHarga
                                ) Then

                                    Throw New Exception(
                                        "Proses penyimpanan detail gagal pada " &
                                        "supplier " & kodeSup &
                                        ", kolom " & namaKolomHarga & "."
                                    )

                                End If

                            Next

                        Next

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

            MsgBox(
                "Data sudah tersimpan.",
                MsgBoxStyle.Information,
                "Informasi"
            )

            loading = True

            BersihkanData()
            DateTimePicker1.Value = TanggalPeriodeAwal()

            loading = False

            KondisiAwal()
            BuatKodeHarga()

        Catch ex As Exception
            MsgBox(
                "Gagal menyimpan data: " & ex.Message,
                MsgBoxStyle.Exclamation,
                "Informasi"
            )
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    '========================================================
    ' HAPUS
    '========================================================
    Private Sub btnHapus_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnHapus.Click

        If String.IsNullOrWhiteSpace(KodeGroupTerpilih) Then
            MsgBox(
                "Tentukan Group Supplier terlebih dahulu.",
                MsgBoxStyle.Exclamation,
                "Informasi"
            )
            ComboBox1.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtKodeHarga.Text) Then
            MsgBox(
                "Pilih data harga yang akan dihapus terlebih dahulu.",
                MsgBoxStyle.Exclamation,
                "Informasi"
            )
            Return
        End If

        If fg.Rows.Count <= 1 Then
            MsgBox(
                "Tidak ada daftar bahan baku yang dihapus.",
                MsgBoxStyle.Exclamation,
                "Informasi"
            )
            Return
        End If

        Dim konfirmasi As DialogResult = MessageBox.Show(
            "Hapus data harga bahan baku supplier " &
            ComboBox1.Text &
            " periode " & DateTimePicker1.Value.ToString("dd/MM/yyyy") &
            " dengan kode " & txtKodeHarga.Text & "?",
            "Konfirmasi",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        )

        If konfirmasi <> DialogResult.Yes Then Return

        Try
            Me.Cursor = Cursors.WaitCursor

            Using cn As New SqlConnection(ConnString)

                cn.Open()

                Using trans As SqlTransaction = cn.BeginTransaction()

                    Try
                        Using cmd As New SqlCommand(
                            "DELETE FROM tblRMMstHargaBahanBakuDtl " &
                            "WHERE KodeHargaString = @KodeHarga; " &
                            "DELETE FROM tblRMMstHargaBahanBakuHdr " &
                            "WHERE KodeHargaString = @KodeHarga;",
                            cn,
                            trans
                        )

                            cmd.CommandTimeout = 600

                            cmd.Parameters.Add(
                                "@KodeHarga",
                                SqlDbType.VarChar,
                                25
                            ).Value = txtKodeHarga.Text.Trim()

                            cmd.ExecuteNonQuery()

                        End Using

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

            MsgBox(
                "Data berhasil dihapus.",
                MsgBoxStyle.Information,
                "Informasi"
            )

            btnBatal.PerformClick()

        Catch ex As Exception
            MsgBox(
                "Gagal menghapus data: " & ex.Message,
                MsgBoxStyle.Exclamation,
                "Informasi"
            )
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    '========================================================
    ' PERUBAHAN PERIODE
    '========================================================
    Private Sub DateTimePicker1_ValueChanged(
        sender As Object,
        e As EventArgs
    ) Handles DateTimePicker1.ValueChanged

        If loading Then Return

        If mode = FormMode.Add Then
            BuatKodeHarga()
        End If

    End Sub
End Class