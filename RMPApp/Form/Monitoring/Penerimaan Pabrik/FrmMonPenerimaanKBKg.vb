Imports System.Data
Imports System.Data.SqlClient
Imports WeifenLuo.WinFormsUI.Docking
Imports C1.Win.C1FlexGrid

Public Class FrmMonPenerimaanKBKg
    Inherits DockContent

    Private Sub FrmMonPenerimaanKBKg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClsFlexGrid.ApplyStyle(fg)
        ClsFlexGrid.ApplyStyle(fgpricekg)
        ClsFlexGrid.ApplyStyle(fg1)
        ClsFlexGrid.ApplyStyle(fg2)

        DtpTanggalAwal.Value = New Date(Date.Today.Year, Date.Today.Month, 1)
        DtpTanggalAkhir.Value = DtpTanggalAwal.Value.AddMonths(1).AddDays(-1)
        OptAllData.Checked = True
        fg.AllowEditing = False
        fgpricekg.AllowEditing = False
        fg1.AllowEditing = False
        fg2.AllowEditing = False

        Try
            MuatSupplier()
            MuatAsalKB()
            MuatKapal()
            SiapkanRekap()
        Catch ex As Exception
            TampilkanError(ex, "Inisialisasi monitoring")
        End Try
    End Sub

    Private Function AmbilData(sql As String, ParamArray parameter() As SqlParameter) As DataTable
        Dim dt As New DataTable
        Using cn As New SqlConnection(StrConnAccounting)
            Using cmd As New SqlCommand(sql, cn)
                If parameter IsNot Nothing AndAlso parameter.Length > 0 Then
                    cmd.Parameters.AddRange(parameter)
                End If
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    Private Sub MuatSupplier()
        Dim dt = AmbilData("SELECT KodeSup, NamaSup FROM tblRMMstSupplier1 ORDER BY NamaSup")
        CmbSupplier.DataSource = dt
        CmbSupplier.DisplayMember = "NamaSup"
        CmbSupplier.ValueMember = "KodeSup"
        CmbSupplier.SelectedIndex = -1
    End Sub

    Private Sub MuatAsalKB()
        Dim dt = AmbilData("SELECT KodeGroupSup, NamaGroup FROM tblRMMstGroupSupplier ORDER BY KodeGroupSup")
        CmbAsalKB.DataSource = dt
        CmbAsalKB.DisplayMember = "NamaGroup"
        CmbAsalKB.ValueMember = "KodeGroupSup"
        CmbAsalKB.SelectedIndex = -1
    End Sub

    Private Sub MuatKapal()
        Dim dt = AmbilData("SELECT KapalID, KapalName + '-' + CAST(KapalID AS VARCHAR(20)) AS KapalName FROM RMPApp..tblMstKapal ORDER BY KapalName")
        CmbKapal.DataSource = dt
        CmbKapal.DisplayMember = "KapalName"
        CmbKapal.ValueMember = "KapalID"
        CmbKapal.SelectedIndex = -1
    End Sub

    Private Function BuatFilter(namaView As String, Optional hanyaBelumConvert As Boolean = False) As Tuple(Of String, List(Of SqlParameter))
        Dim sql As String = "SELECT * FROM " & namaView & " WHERE CONVERT(date, TglTerima, 103) >= @TglAwal AND CONVERT(date, TglTerima, 103) <= @TglAkhir"
        Dim p As New List(Of SqlParameter) From {
            New SqlParameter("@TglAwal", SqlDbType.Date) With {.Value = DtpTanggalAwal.Value.Date},
            New SqlParameter("@TglAkhir", SqlDbType.Date) With {.Value = DtpTanggalAkhir.Value.Date}
        }

        If hanyaBelumConvert Then sql &= " AND KodeConvertKg IS NULL"

        If CmbKapal.SelectedValue IsNot Nothing AndAlso TypeOf CmbKapal.SelectedValue IsNot DataRowView Then
            sql &= " AND IDKapal = @KapalID"
            p.Add(New SqlParameter("@KapalID", CmbKapal.SelectedValue))
        End If

        If CmbSupplier.SelectedValue IsNot Nothing AndAlso TypeOf CmbSupplier.SelectedValue IsNot DataRowView Then
            sql &= " AND KodeSup1 = @KodeSup1"
            p.Add(New SqlParameter("@KodeSup1", CmbSupplier.SelectedValue.ToString()))
        End If

        If Not String.IsNullOrWhiteSpace(TxtKodeSupplier.Text) Then
            sql &= " AND KodeSup LIKE @KodeSup"
            p.Add(New SqlParameter("@KodeSup", "%" & TxtKodeSupplier.Text.Trim() & "%"))
        End If

        If CmbAsalKB.SelectedValue IsNot Nothing AndAlso TypeOf CmbAsalKB.SelectedValue IsNot DataRowView Then
            sql &= " AND KodeAsalKelapa = @AsalKB"
            p.Add(New SqlParameter("@AsalKB", CmbAsalKB.SelectedValue))
        End If

        If Not String.IsNullOrWhiteSpace(TxtNota.Text) Then
            sql &= " AND NoNota LIKE @NoNota"
            p.Add(New SqlParameter("@NoNota", "%" & TxtNota.Text.Trim() & "%"))
        End If

        If OptOrganik.Checked Then
            sql &= " AND ISNULL(Organik, 0) = 1"
        ElseIf OptNonOrganik.Checked Then
            sql &= " AND ISNULL(Organik, 0) = 0"
        End If

        If ChkApprovalUangMuka.Checked Then
            sql &= " AND ISNULL(SaveToJurnal, 0) = 0"
        End If

        If ChkBelumComplete.Checked Then
            sql &= " AND ISNULL(SaveToJurnal, 0) = 0 AND KodeAsalKelapa IN ('10','11','13','14')"
        End If

        If ChkBelumDibuatAP.Checked Then
            sql &= " AND NoNota NOT IN (SELECT NoInvoice FROM RSUPGENERALLEDGER2018..TblRGLAPPaymentTrnDtl)"
        End If

        sql &= " ORDER BY TglTerima, NoNota, KodeSup"
        Return Tuple.Create(sql, p)
    End Function

    Private Sub TampilkanGrid(grid As C1FlexGrid, dt As DataTable)
        grid.BeginUpdate()
        Try
            grid.DataSource = Nothing
            grid.DataSource = dt
            grid.AllowEditing = False
            grid.AutoResize = True
        Finally
            grid.EndUpdate()
        End Try
    End Sub

    Private Sub RefreshMonitoring(Optional areaP1 As Boolean = False)
        Cursor = Cursors.WaitCursor
        Try
            Dim sumber As String = If(areaP1,
                "PSGRMP..vwRMTrnPenerimaanKBKgDtlaNew_PCGall",
                "vwRMTrnPenerimaanKBDtl")
            Dim f = BuatFilter(sumber, Not areaP1)
            Dim dt = AmbilData(f.Item1, f.Item2.ToArray())
            TampilkanGrid(fg, dt)

            Dim sumberKg As String = If(areaP1,
                "PSGRMP..vwRMTrnPenerimaanKBKgDtlaNew_PCGall",
                "vwRMTrnPenerimaanKBKg")
            Dim fKg = BuatFilter(sumberKg, False)
            Dim dtKg = AmbilData(fKg.Item1, fKg.Item2.ToArray())
            TampilkanGrid(fgpricekg, dtKg)
            HitungRekap(dt)

            IsiNomorUrut(fg)
            IsiNomorUrut(fgpricekg)
            IsiNomorUrut(fg1)
            IsiNomorUrut(fg2)

            fg.AutoSizeCols()
            fgpricekg.AutoSizeCols()
            fg1.AutoSizeCols()
            fg2.AutoSizeCols()
        Catch ex As Exception
            TampilkanError(ex, "Refresh monitoring")
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub IsiNomorUrut(grid As C1FlexGrid)
        For r As Integer = grid.Rows.Fixed To grid.Rows.Count - 1
            grid(r, 0) = r - grid.Rows.Fixed + 1
        Next
    End Sub

    Private Sub SiapkanRekap()
        Dim dt1 As New DataTable
        dt1.Columns.Add("Grade", GetType(String))
        For Each nama In {"Brutto", "Reject", "Netto", "Harga", "Total"}
            dt1.Columns.Add(nama, GetType(Decimal))
        Next
        For Each nama In {"KB-Khina", "KB-A", "KB-B", "KB-C", "#"}
            Dim row = dt1.NewRow()
            row("Grade") = nama
            dt1.Rows.Add(row)
        Next
        TampilkanGrid(fg1, dt1)

        Dim dt2 As New DataTable
        dt2.Columns.Add("Grade", GetType(String))
        For Each nama In {"Jambul-A", "Jambul-B", "Licin-A", "Licin-B", "Hibrida-A", "Hibrida-B", "Licin-A,A6", "Licin-B,A6", "#"}
            Dim row = dt2.NewRow()
            row("Grade") = nama
            dt2.Rows.Add(row)
        Next
        TampilkanGrid(fg2, dt2)
    End Sub

    Private Sub HitungRekap(dt As DataTable)
        ' Rekap dihitung dari data hasil query. Jika nama field tidak tersedia pada view, kolom tersebut dilewati.
        If Not dt.Columns.Contains("Grade") OrElse Not dt.Columns.Contains("Brutto") Then Return

        Dim ringkas As New Dictionary(Of String, Decimal)(StringComparer.OrdinalIgnoreCase) From {
            {"KB-Khina", 0D}, {"KB-A", 0D}, {"KB-B", 0D}, {"KB-C", 0D}, {"#", 0D}
        }
        For Each row As DataRow In dt.Rows
            Dim grade = Convert.ToString(row("Grade"))
            Dim tujuan As String = "#"
            If {"KB-Khina", "A1", "A2"}.Contains(grade) Then
                tujuan = "KB-Khina"
            ElseIf {"KB-A", "A2", "A3", "A4", "A5", "A6"}.Contains(grade) Then
                tujuan = "KB-A"
            ElseIf {"KB-B", "B1", "B2", "B3"}.Contains(grade) Then
                tujuan = "KB-B"
            ElseIf {"KB-C", "C1", "C2", "C3"}.Contains(grade) Then
                tujuan = "KB-C"
            End If
            ringkas(tujuan) += KeDecimal(row("Brutto"))
            ringkas("#") += KeDecimal(row("Brutto"))
        Next

        If fg1.Cols.Contains("Brutto") Then
            For r = 1 To fg1.Rows.Count - 1
                Dim grade = Convert.ToString(fg1(r, "Grade"))
                If ringkas.ContainsKey(grade) Then fg1(r, "Brutto") = ringkas(grade)
            Next
        End If
    End Sub

    Private Function KeDecimal(value As Object) As Decimal
        If value Is Nothing OrElse value Is DBNull.Value Then Return 0D
        Dim hasil As Decimal
        Decimal.TryParse(Convert.ToString(value), hasil)
        Return hasil
    End Function

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        RefreshMonitoring(False)
    End Sub

    Private Sub btnRefreshP1_Click(sender As Object, e As EventArgs) Handles btnRefreshP1.Click
        RefreshMonitoring(True)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub Filter_Changed(sender As Object, e As EventArgs) Handles DtpTanggalAwal.ValueChanged, DtpTanggalAkhir.ValueChanged, CmbSupplier.SelectedIndexChanged, CmbAsalKB.SelectedIndexChanged, CmbKapal.SelectedIndexChanged, OptAllData.CheckedChanged, OptOrganik.CheckedChanged, OptNonOrganik.CheckedChanged, ChkApprovalUangMuka.CheckedChanged, ChkBelumComplete.CheckedChanged, ChkBelumDibuatAP.CheckedChanged
        ' Filter dijalankan saat tombol Refresh ditekan agar query tidak dieksekusi berulang saat mengubah filter.
    End Sub

    Private Sub TxtNota_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtNota.KeyDown, TxtKodeSupplier.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            RefreshMonitoring(False)
        End If
    End Sub

    Private Sub btnConvertButir_Click(sender As Object, e As EventArgs) Handles btnConvertButir.Click
        EksporGrid(fg, "MonitoringPenerimaanKBButir")
    End Sub

    Private Sub btnConvertKg_Click(sender As Object, e As EventArgs) Handles btnConvertKg.Click
        EksporGrid(fgpricekg, "MonitoringPenerimaanKBKg")
    End Sub

    Private Sub EksporGrid(grid As C1FlexGrid, namaFile As String)
        Using sfd As New SaveFileDialog With {
            .Title = "Simpan hasil monitoring",
            .Filter = "CSV (*.csv)|*.csv",
            .FileName = namaFile & "_" & DateTime.Now.ToString("yyyyMMdd_HHmm") & ".csv"
        }
            If sfd.ShowDialog() <> DialogResult.OK Then Return

            Dim sb As New System.Text.StringBuilder()

            For r As Integer = grid.Rows.Fixed To grid.Rows.Count - 1
                Dim nilai As New List(Of String)

                For c As Integer = grid.Cols.Fixed To grid.Cols.Count - 1
                    Dim teks As String = Convert.ToString(grid(r, c))
                    teks = teks.Replace("""", """""")
                    nilai.Add("""" & teks & """")
                Next

                sb.AppendLine(String.Join(",", nilai))
            Next

            IO.File.WriteAllText(sfd.FileName, sb.ToString(), System.Text.Encoding.UTF8)
        End Using
    End Sub

    Private Sub TampilkanError(ex As Exception, proses As String)
        MessageBox.Show(proses & ": " & Environment.NewLine & ex.Message,
                        "Monitoring Penerimaan KB Kg", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub FrmMonPenerimaanKBKg_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        ' ukuran Panel13 setengah layar
        Panel13.Size = New Size(Me.ClientSize.Width / 2, Me.ClientSize.Height - Panel13.Top - 10)
    End Sub
End Class
