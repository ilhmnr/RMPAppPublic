Imports System.Data.SqlClient
Imports System.Text
Imports System.IO

Public Class FrmMonPenerimaanBahanBaku

    Private dt As New DataTable
    Private namaKolomJumlah As String = "Karung"
    Private namaJenis As String = "Kelapa Cungkil"

    Private Sub FrmMonPenerimaanBahanBaku_Load(
        sender As Object, e As EventArgs
    ) Handles MyBase.Load

        ClsFlexGrid.ApplyStyle(fg)

        DtpTanggalAwal.Value = New Date(Today.Year, Today.Month, 1)
        DtpTanggalAkhir.Value = DtpTanggalAwal.Value.AddMonths(1).AddDays(-1)

        TxtNota.Clear()

        fg.AllowEditing = False
        fg.AutoResize = True
        fg.ExtendLastCol = True

        rdKelapaCungkil.Checked = True

        ListSupplier()
    End Sub

    Private Function AmbilData(
        sql As String,
        ParamArray parameter() As SqlParameter
    ) As DataTable

        Dim hasil As New DataTable

        Using cn As New SqlConnection(StrConnAccounting)
            Using cmd As New SqlCommand(sql, cn)

                If parameter IsNot Nothing AndAlso parameter.Length > 0 Then
                    cmd.Parameters.AddRange(parameter)
                End If

                Using da As New SqlDataAdapter(cmd)
                    da.Fill(hasil)
                End Using

            End Using
        End Using

        Return hasil
    End Function

    Private Sub ListSupplier()
        Try
            Dim sql As String =
                "SELECT KodeSup, NamaSup, GroupSup " &
                "FROM tblRMMstSupplier " &
                "WHERE KodeSup NOT LIKE '%pcg%' " &
                "AND KodeSup NOT LIKE '%pc%' " &
                "AND NotActive = 0 " &
                "ORDER BY NamaSup"

            Dim data As DataTable = AmbilData(sql)

            CmbSupplier.DataSource = Nothing
            CmbSupplier.DisplayMember = "NamaSup"
            CmbSupplier.ValueMember = "KodeSup"
            CmbSupplier.DataSource = data
            CmbSupplier.SelectedIndex = -1

        Catch ex As Exception
            MessageBox.Show(
                "Gagal memuat supplier: " & ex.Message,
                "Monitoring Penerimaan Bahan Baku",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function SiapkanJenisMonitoring() As String

        If rdKelapaCungkil.Checked Then
            namaJenis = "Kelapa Cungkil"
            namaKolomJumlah = "Karung"
            Return "vwRMTrnPenerimaanKCDtl"

        ElseIf rdNata.Checked Then
            namaJenis = "Nata"
            namaKolomJumlah = "Drum"
            Return "vwRMTrnPenerimaanNataDtl"

        End If

        Return ""
    End Function

    Private Sub RefreshData()

        If DtpTanggalAwal.Value.Date > DtpTanggalAkhir.Value.Date Then
            MessageBox.Show(
                "Masukkan tanggal dengan benar!",
                "Peringatan",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            DtpTanggalAwal.Focus()
            Return
        End If

        Dim namaView As String = SiapkanJenisMonitoring()

        If namaView = "" Then
            MessageBox.Show(
                "Pilih jenis monitoring terlebih dahulu.",
                "Peringatan",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim sql As String =
                "SELECT * FROM " & namaView & " " &
                "WHERE CONVERT(datetime, TglTerima, 103) >= @TanggalAwal " &
                "AND CONVERT(datetime, TglTerima, 103) < @TanggalAkhir "

            Dim parameter As New List(Of SqlParameter) From {
                New SqlParameter("@TanggalAwal", SqlDbType.DateTime) With {
                    .Value = DtpTanggalAwal.Value.Date
                },
                New SqlParameter("@TanggalAkhir", SqlDbType.DateTime) With {
                    .Value = DtpTanggalAkhir.Value.Date.AddDays(1)
                }
            }

            If CmbSupplier.SelectedIndex >= 0 AndAlso
               CmbSupplier.SelectedValue IsNot Nothing AndAlso
               Not TypeOf CmbSupplier.SelectedValue Is DataRowView Then

                sql &= "AND KodeSup = @KodeSup "

                parameter.Add(
                    New SqlParameter("@KodeSup", SqlDbType.VarChar, 50) With {
                        .Value = CmbSupplier.SelectedValue.ToString()
                    })
            End If

            If TxtNota.Text.Trim() <> "" Then
                sql &= "AND NoNota LIKE @NoNota "

                parameter.Add(
                    New SqlParameter("@NoNota", SqlDbType.VarChar, 100) With {
                        .Value = "%" & TxtNota.Text.Trim() & "%"
                    })
            End If

            sql &= "ORDER BY TglTerima, NoNota, KodeSup, Operator"

            Dim data As DataTable = AmbilData(
                sql,
                parameter.ToArray())

            BuatStrukturData()

            For Each sumber As DataRow In data.Rows
                dt.Rows.Add(
                    NilaiTeks(sumber, "NoNota"),
                    NilaiTeks(sumber, "KodeSup"),
                    NilaiTeks(sumber, "NamaSup"),
                    NilaiTeks(sumber, "TglTerima"),
                    NilaiTeks(sumber, "NoReff"),
                    NilaiTeks(sumber, "KodeDivKav"),
                    NilaiTeks(sumber, "Wilayah"),
                    NilaiTeks(sumber, "NoIB"),
                    NilaiTeks(sumber, "Operator"),
                    NilaiTeks(sumber, namaKolomJumlah),
                    NilaiAngka(sumber, "Brutto"),
                    NilaiAngka(sumber, "BeratGoni"),
                    NilaiAngka(sumber, "Netto1"),
                    NilaiAngka(sumber, "Reject"),
                    NilaiAngka(sumber, "Netto2"),
                    NilaiAngka(sumber, "Harga"),
                    NilaiAngka(sumber, "Total"),
                    NilaiTeks(sumber, "Dermaga"),
                    NilaiTeks(sumber, "Jam"),
                    NilaiTeks(sumber, "Shift"),
                    NilaiTeks(sumber, "DetailID"),
                    NilaiTeks(sumber, "NoReff"))
            Next

            If dt.Rows.Count = 0 Then
                fg.DataSource = Nothing

                MessageBox.Show(
                    "Data " & namaJenis & " periode " &
                    DtpTanggalAwal.Value.ToString("dd/MM/yyyy") &
                    " s/d " &
                    DtpTanggalAkhir.Value.ToString("dd/MM/yyyy") &
                    " tidak ditemukan.",
                    "Informasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)

                Return
            End If

            TampilkanDataDenganSubtotal()

        Catch ex As Exception
            MessageBox.Show(
                "Gagal memuat data " & namaJenis & ": " & ex.Message,
                "Monitoring Penerimaan Bahan Baku",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BuatStrukturData()

        dt = New DataTable

        dt.Columns.Add("NoNota", GetType(String))
        dt.Columns.Add("KodeSup", GetType(String))
        dt.Columns.Add("NamaSup", GetType(String))
        dt.Columns.Add("TglTerima", GetType(String))
        dt.Columns.Add("NoReff", GetType(String))
        dt.Columns.Add("KodeDivKav", GetType(String))
        dt.Columns.Add("Wilayah", GetType(String))
        dt.Columns.Add("NoIB", GetType(String))
        dt.Columns.Add("Operator", GetType(String))
        dt.Columns.Add(namaKolomJumlah, GetType(String))
        dt.Columns.Add("Brutto", GetType(Decimal))
        dt.Columns.Add("BeratGoni", GetType(Decimal))
        dt.Columns.Add("Netto1", GetType(Decimal))
        dt.Columns.Add("Reject", GetType(Decimal))
        dt.Columns.Add("Netto2", GetType(Decimal))
        dt.Columns.Add("Harga", GetType(Decimal))
        dt.Columns.Add("Total", GetType(Decimal))
        dt.Columns.Add("Dermaga", GetType(String))
        dt.Columns.Add("Jam", GetType(String))
        dt.Columns.Add("Shift", GetType(String))
        dt.Columns.Add("DetailID", GetType(String))
        dt.Columns.Add("NoReff2", GetType(String))

    End Sub

    Private Function NilaiTeks(
        row As DataRow,
        kolom As String
    ) As String

        If Not row.Table.Columns.Contains(kolom) OrElse row.IsNull(kolom) Then
            Return ""
        End If

        Return Convert.ToString(row(kolom))
    End Function

    Private Function NilaiAngka(
        row As DataRow,
        kolom As String
    ) As Decimal

        If Not row.Table.Columns.Contains(kolom) OrElse row.IsNull(kolom) Then
            Return 0D
        End If

        Return Convert.ToDecimal(row(kolom))
    End Function

    Private Sub TampilkanDataDenganSubtotal()

        Dim hasil As DataTable = dt.Clone()
        Dim grup As String = Nothing

        Dim totalBrutto As Decimal = 0D
        Dim totalGoni As Decimal = 0D
        Dim totalNetto1 As Decimal = 0D
        Dim totalReject As Decimal = 0D
        Dim totalNetto2 As Decimal = 0D
        Dim totalNilai As Decimal = 0D

        For Each sumber As DataRow In dt.Rows

            Dim grupBaru As String = Convert.ToString(sumber("NoNota"))

            If grup IsNot Nothing AndAlso grup <> grupBaru Then

                TambahSubtotal(
                    hasil, "Sub Total " & grup,
                    totalBrutto, totalGoni, totalNetto1,
                    totalReject, totalNetto2, 0D, totalNilai)

                totalBrutto = 0D
                totalGoni = 0D
                totalNetto1 = 0D
                totalReject = 0D
                totalNetto2 = 0D
                totalNilai = 0D

            End If

            grup = grupBaru

            Dim baru As DataRow = hasil.NewRow()
            baru.ItemArray = CType(sumber.ItemArray.Clone(), Object())
            hasil.Rows.Add(baru)

            totalBrutto += CDec(sumber("Brutto"))
            totalGoni += CDec(sumber("BeratGoni"))
            totalNetto1 += CDec(sumber("Netto1"))
            totalReject += CDec(sumber("Reject"))
            totalNetto2 += CDec(sumber("Netto2"))
            totalNilai += CDec(sumber("Total"))

        Next

        If grup IsNot Nothing Then
            TambahSubtotal(
                hasil, "Sub Total " & grup,
                totalBrutto, totalGoni, totalNetto1,
                totalReject, totalNetto2, 0D, totalNilai)
        End If

        TambahSubtotal(
            hasil, "Grand Total",
            Jumlah(dt, "Brutto"),
            Jumlah(dt, "BeratGoni"),
            Jumlah(dt, "Netto1"),
            Jumlah(dt, "Reject"),
            Jumlah(dt, "Netto2"),
            0D,
            Jumlah(dt, "Total"))

        fg.DataSource = hasil

        IsiNomorUrut()

    End Sub

    Private Sub TambahSubtotal(
        hasil As DataTable,
        namaGrup As String,
        brutto As Decimal,
        goni As Decimal,
        netto1 As Decimal,
        reject As Decimal,
        netto2 As Decimal,
        harga As Decimal,
        nilai As Decimal)

        Dim row As DataRow = hasil.NewRow()

        row("NoNota") = namaGrup
        row("Brutto") = brutto
        row("BeratGoni") = goni
        row("Netto1") = netto1
        row("Reject") = reject
        row("Netto2") = netto2
        row("Harga") = harga
        row("Total") = nilai

        hasil.Rows.Add(row)

    End Sub

    Private Function Jumlah(
        data As DataTable,
        kolom As String
    ) As Decimal

        Dim total As Decimal = 0D

        For Each row As DataRow In data.Rows
            If Not row.IsNull(kolom) Then
                total += Convert.ToDecimal(row(kolom))
            End If
        Next

        Return total
    End Function

    Private Sub IsiNomorUrut()

        Dim nomor As Integer = 0

        For r As Integer = fg.Rows.Fixed To fg.Rows.Count - 1

            Dim nama As String = Convert.ToString(fg(r, 1))

            If nama.StartsWith("Sub Total ") OrElse
               nama = "Grand Total" Then

                fg(r, 0) = ""
            Else
                nomor += 1
                fg(r, 0) = nomor
            End If

        Next

    End Sub

    Private Sub btnRefresh_Click(
        sender As Object, e As EventArgs
    ) Handles btnRefresh.Click

        RefreshData()

    End Sub

    Private Sub TxtNota_KeyDown(
        sender As Object, e As KeyEventArgs
    ) Handles TxtNota.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            RefreshData()
        End If

    End Sub

    Private Sub btnClose_Click(
        sender As Object, e As EventArgs
    ) Handles btnClose.Click

        Close()

    End Sub

    Private Sub btnConvertKg_Click(
        sender As Object, e As EventArgs
    ) Handles btnConvert.Click

        EksporGrid("MonitorPenerimaan_" & namaJenis.Replace(" ", ""))

    End Sub

    Private Sub EksporGrid(namaFile As String)

        Using sfd As New SaveFileDialog With {
            .Title = "Simpan hasil monitoring",
            .Filter = "CSV (*.csv)|*.csv",
            .FileName = namaFile & "_" &
                        DateTime.Now.ToString("yyyyMMdd_HHmm") & ".csv"
        }

            If sfd.ShowDialog() <> DialogResult.OK Then Return

            Dim sb As New StringBuilder()

            For c As Integer = fg.Cols.Fixed To fg.Cols.Count - 1
                If c > fg.Cols.Fixed Then sb.Append(",")

                sb.Append(EscapeCsv(fg.GetData(0, c)))
            Next

            sb.AppendLine()

            For r As Integer = fg.Rows.Fixed To fg.Rows.Count - 1

                For c As Integer = fg.Cols.Fixed To fg.Cols.Count - 1
                    If c > fg.Cols.Fixed Then sb.Append(",")

                    sb.Append(EscapeCsv(fg.GetData(r, c)))
                Next

                sb.AppendLine()

            Next

            File.WriteAllText(
                sfd.FileName,
                sb.ToString(),
                Encoding.UTF8)

        End Using

    End Sub

    Private Function EscapeCsv(nilai As Object) As String

        Dim teks As String = Convert.ToString(nilai)
        Return """" & teks.Replace("""", """""") & """"

    End Function

End Class