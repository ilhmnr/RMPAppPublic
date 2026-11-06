Imports System.Runtime.InteropServices
Imports C1.Win.C1FlexGrid
Imports DocumentFormat.OpenXml.Office2010.PowerPoint
Imports Microsoft.Office.Interop
Imports Microsoft.Reporting.WinForms

Public Class FrmMonPengajuanPenerimaanNotaRekap
    Dim ReportName As String
    Private Sub FrmMonApprovalPenerimaan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' set dtpMuat1 dan dtpMuat2 ke tanggal awal dan akhir bulan ini
        dtpPengajuan1.Value = Now
        dtpPengajuan2.Value = Now

        Call ClsFlexGrid.ApplyStyle(fg)

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Me.Cursor = Cursors.WaitCursor

        Dim dt As New DataTable
        Dim i As Integer = 1
        Dim sql As String = "select * from vwMonRekapPengajuanPenerimaanNotaRekap where approval_status_1=1 and cast(TanggalApproval as date) between '" & Format(dtpPengajuan1.Value, "yyyy-MM-dd") & "' and '" & Format(dtpPengajuan2.Value, "yyyy-MM-dd") & "' "

        If rdBelumRekapExcel.Checked = True Then
            sql &= " and SudahRekapExcel=0"
        ElseIf rdSudahRekapExcel.Checked = True Then
            sql &= " and SudahRekapExcel=1"
        End If

        If rdKBA.Checked Then
            sql &= " and Grade='KB-A'"
        ElseIf rdKBB.Checked Then
            sql &= " and Grade='KB-B'"
        ElseIf rdKC.Checked Then
            sql &= " and Grade='KC'"
        End If

        If rdJambul.Checked Then
            sql &= " and Jenis='Jambul'"
        ElseIf rdLicin.Checked Then
            sql &= " and Jenis='Licin'"
        ElseIf rdCungkil.Checked Then
            sql &= " and Jenis='Cungkil'"
        End If

        sql &= " order by TanggalApproval,NoTrans asc"

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fg
            .Rows.Count = 1 ' Reset grid sebelum mengisi data baru

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "NoTrans") = row("NoTrans")
                    .Item(i, "TanggalPengajuan") = row("TanggalApproval")
                    .Item(i, "KapalMobil") = row("KapalMobil")
                    .Item(i, "Pancang") = row("Pancang")
                    .Item(i, "Tujuan") = row("Tujuan")
                    .Item(i, "Trip") = row("Trip")
                    .Item(i, "Brutto") = row("Brutto")
                    .Item(i, "TarraJaring") = row("TarraJaring")
                    .Item(i, "Netto1") = row("Netto1")
                    .Item(i, "Netto2") = row("Netto2")
                    .Item(i, "TotalRpBeforePPH") = row("TotalRpBeforePPH")
                    .Item(i, "PPHRp") = row("PPHRp")
                    .Item(i, "Pinjaman") = row("Pinjaman")
                    .Item(i, "TotalRp") = row("TotalRp")

                    i += 1
                Next

                If rdBelumRekapExcel.Checked = True Then
                    ' === Baris TOTAL ===
                    Dim rowTotal As Integer = i
                    fg.AddItem("")
                    fg.Item(rowTotal, "NoTrans") = "TOTAL"
                    fg.Rows(rowTotal).StyleNew.BackColor = Color.LightYellow
                    fg.Rows(rowTotal).StyleNew.Font = New Font(fg.Font, FontStyle.Bold)
                End If

                .AutoSizeCols()

                Call LoadReport()
            Else
                MsgBoxCustom.Show("Tidak ada data.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            End If
        End With

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadReport()
        Dim sql As String = ""
        Dim ParmsPengajuan As New ReportParameter
        Dim Pengajuan As String = ""

        Dim imgLogo As Image
        Dim paramsImgLogo As New ReportParameter

        sql = "select NoTrans, TanggalApproval as TanggalPengajuan, Tujuan, KapalMobil, Pancang, Trip, Brutto as Bruto, TarraJaring as TaraJaring, Netto1 as Neto1, Netto2 as Neto2,Pinjaman,TotalRp
                ,approved_1_by as created_by
                ,approved_1_at as created_at
                ,'" & Modul_Config.url_paraf & "' + approved_1_by + '.png' as paraf_created
                ,approved_2_by
                ,approved_2_at
                ,'" & Modul_Config.url_paraf & "' + approved_2_by + '.png' as paraf_approve2
                ,approved_3_by
                ,approved_3_at
                ,'" & Modul_Config.url_paraf & "' + approved_3_by + '.png' as paraf_approve3
               from vwMonRekapPengajuanPenerimaanNotaRekap where approval_status_1=1 and cast(TanggalApproval as date) between '" & Format(dtpPengajuan1.Value, "yyyy-MM-dd") & "' and '" & Format(dtpPengajuan2.Value, "yyyy-MM-dd") & "'"

        If rdKBA.Checked Then
            sql &= " and Grade='KB-A'"
        ElseIf rdKBB.Checked Then
            sql &= " and Grade='KB-B'"
        ElseIf rdKC.Checked Then
            sql &= " and Grade='KC'"
        End If

        If rdJambul.Checked Then
            sql &= " and Jenis='Jambul'"
        ElseIf rdLicin.Checked Then
            sql &= " and Jenis='Licin'"
        ElseIf rdCungkil.Checked Then
            sql &= " and Jenis='Cungkil'"
        End If

        sql &= " order by TanggalApproval,NoTrans asc"

        Me.Cursor = Cursors.WaitCursor
        Try
            Dim dtTable As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)
            If dtTable.Rows.Count > 0 Then
                Dim FileName As String = "REKAP DATA PETANI UNTUK PEMBAYARAN KELAPA BULAT BPI TANGGAL" & "_" & Format(dtpPengajuan1.Value, "dd-MMM-yyyy")
                ReportName = ".RptRekapApprovalPenerimaan.rdlc"
                Dim rpt As ReportViewer = Me.ReportViewer1
                rpt.Reset()
                rpt.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                Dim dtGLAPPayment = New ReportDataSource("dtRekapApprovalPenerimaan", dtTable)
                rpt.LocalReport.DisplayName = Replace(FileName, "/", "-")
                rpt.LocalReport.DataSources.Add(dtGLAPPayment)

                rpt.LocalReport.ReportEmbeddedResource = My.Application.Info.ProductName & ReportName
                rpt.LocalReport.EnableExternalImages = True

                Dim newPageSetting As New System.Drawing.Printing.PageSettings
                newPageSetting.Margins = New System.Drawing.Printing.Margins(0, 0, 0, 0)
                newPageSetting.Landscape = True
                'newPageSetting.PaperSize = New PaperSize("Customer", 850, 550)

                Me.ReportViewer1.ShowToolBar = True
                rpt.SetPageSettings(newPageSetting)
                rpt.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal)
                rpt.ZoomPercent = 100
                rpt.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent
                rpt.RefreshReport()
            End If
        Catch ex As Exception
            MsgBoxCustom.Show("Error Load Report : " & ex.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub rdBelumRekapExcel_CheckedChanged(sender As Object, e As EventArgs) Handles rdBelumRekapExcel.CheckedChanged, rdSudahRekapExcel.CheckedChanged
        If rdBelumRekapExcel.Checked = True Then
            btnRekapExcel.Enabled = True
            btnRestore.Enabled = False
        ElseIf rdSudahRekapExcel.Checked = True Then
            btnRekapExcel.Enabled = False
            btnRestore.Enabled = True
        End If

        fg.Rows.Count = 1
    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg.BeforeEdit
        If fg.Cols(e.Col).Name = "Select" Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub btnRekapExcel_Click(sender As Object, e As EventArgs) Handles btnRekapExcel.Click, btnRestore.Click
        ' cek jika tidak ada data di grid
        If fg.Rows.Count <= 1 Then
            MsgBoxCustom.Show("Tidak ada data untuk direkap/direstore.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Exit Sub
        End If

        ' cek jika tidak ada data yang dipilih
        Dim adaDipilih As Boolean = False
        For i As Integer = 1 To fg.Rows.Count - 1
            If fg.Item(i, "Select") = True Then
                adaDipilih = True
                Exit For
            End If
        Next
        If adaDipilih = False Then
            MsgBoxCustom.Show("Tidak ada data yang dipilih untuk direkap/direstore.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Exit Sub
        End If

        ' jika klik btnrekapexce
        If sender Is btnRekapExcel Then
            ' remove baris yang tidak di pilih
            For i As Integer = fg.Rows.Count - 2 To 1 Step -1
                If fg.Item(i, "Select") = False Then
                    fg.RemoveItem(i)
                End If
            Next

            ' set ulang no
            For i As Integer = 1 To fg.Rows.Count - 1
                fg.Item(i, 0) = i
            Next

            If RekapExcel() = True Then
                btnSearch.PerformClick()
            End If
        ElseIf sender Is btnRestore Then
            ' Konfirmasi restore
            If MsgBoxCustom.Show("Yakin mau restore data?", MsgBoxCustom.ButtonType.YesNo, MsgBoxCustom.IconType.Question) = vbNo Then
                Exit Sub
            End If

            ' Update status SudahRekapExcel
            For j As Integer = 1 To fg.Rows.Count - 1
                If fg.Item(j, "Select") = True Then
                    Modul_RMP.DB.ExecuteQuery(StrConnRMPApp,
                        "UPDATE RMPApp..TblTrnApprovalPenerimaanHdr " &
                        "SET SudahRekapExcel = 0 " &
                        "WHERE NoTrans = '" & fg.Item(j, "NoTrans") & "'"
                    )
                End If
            Next

            ' Refresh data
            btnSearch.PerformClick()

            MsgBoxCustom.Show("Restore berhasil.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
        End If
    End Sub

    Private Function RekapExcel() As Boolean
        RekapExcel = False

        Try
            If fg.Rows.Count <= 1 Then
                MsgBoxCustom.Show("Data kosong.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                Exit Function
            End If

            Using save As New SaveFileDialog
                save.Filter = "Excel File (*.xlsx)|*.xlsx"
                save.FileName = "Pengajuan Penerimaan Kelapa_" & Format(Now, "yyyyMMdd")

                If save.ShowDialog() = DialogResult.OK Then

                    ' === EXPORT LANGSUNG DARI GRID ===
                    ' otomatis hanya kolom Visible yang ikut
                    fg.SaveExcel(save.FileName, "Sheet1", FileFlags.IncludeFixedCells)

                    If IO.File.Exists(save.FileName) Then

                        ' === Update status database ===
                        For j As Integer = 1 To fg.Rows.Count - 1
                            Modul_RMP.DB.ExecuteQuery(StrConnRMPApp,
                            "UPDATE RMPApp..TblTrnApprovalPenerimaanHdr " &
                            "SET SudahRekapExcel = 1 " &
                            "WHERE NoTrans='" & fg.Item(j, "NoTrans") & "'")
                        Next

                        MsgBoxCustom.Show("Export berhasil!", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                        RekapExcel = True
                    Else
                        MsgBoxCustom.Show("Export gagal.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
                    End If
                End If
            End Using

        Catch ex As Exception
            MsgBoxCustom.Show("Error Export : " & ex.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
        End Try

        Return RekapExcel
    End Function

    Private Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelectAll.CheckedChanged
        ' Set semua checkbox di kolom "Select" sesuai dengan status chkSelectAll
        For i As Integer = 1 To fg.Rows.Count - 1
            fg.Item(i, "Select") = chkSelectAll.Checked

            If fg.Rows.Count > 1 And rdBelumRekapExcel.Checked = True Then
                Call SumTotalCheck()
            End If
        Next
    End Sub

    Private Sub fg_AfterEdit(sender As Object, e As RowColEventArgs) Handles fg.AfterEdit
        With fg
            If fg.Rows.Count <= 1 Then Exit Sub

            ' Jika kolom yang diedit adalah "Select"
            If .Cols(e.Col).Name = "Select" Then
                Call SumTotalCheck()
            End If
        End With
    End Sub

    Private Sub SumTotalCheck()

        If fg.Rows.Count <= 1 Then Exit Sub

        Dim rowTotal As Integer = fg.Rows.Count - 1

        ' Reset nilai total
        fg.Item(rowTotal, "Brutto") = 0
        fg.Item(rowTotal, "TarraJaring") = 0
        fg.Item(rowTotal, "Netto1") = 0
        fg.Item(rowTotal, "Netto2") = 0
        fg.Item(rowTotal, "TotalRpBeforePPH") = 0
        fg.Item(rowTotal, "PPHRp") = 0
        fg.Item(rowTotal, "Pinjaman") = 0
        fg.Item(rowTotal, "TotalRp") = 0

        ' Loop hanya baris data
        For r As Integer = 1 To fg.Rows.Count - 2

            If fg.Item(r, "Select") = True Then

                fg.Item(rowTotal, "Brutto") += Val(fg.Item(r, "Brutto"))
                fg.Item(rowTotal, "TarraJaring") += Val(fg.Item(r, "TarraJaring"))
                fg.Item(rowTotal, "Netto1") += Val(fg.Item(r, "Netto1"))
                fg.Item(rowTotal, "Netto2") += Val(fg.Item(r, "Netto2"))
                fg.Item(rowTotal, "TotalRpBeforePPH") += Val(fg.Item(r, "TotalRpBeforePPH"))
                fg.Item(rowTotal, "PPHRp") += Val(fg.Item(r, "PPHRp"))
                fg.Item(rowTotal, "Pinjaman") += Val(fg.Item(r, "Pinjaman"))
                fg.Item(rowTotal, "TotalRp") += Val(fg.Item(r, "TotalRp"))

            End If

        Next

    End Sub

    Private Sub fg_SelChange(sender As Object, e As EventArgs) Handles fg.SelChange
        Dim grid As C1.Win.C1FlexGrid.C1FlexGrid = CType(sender, C1.Win.C1FlexGrid.C1FlexGrid)

        txtTotal.Text = ClsFunction.FormatNum(grid.Aggregate(AggregateEnum.Sum), 2)
    End Sub
End Class