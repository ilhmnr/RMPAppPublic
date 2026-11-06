Imports C1.Win.C1FlexGrid
Imports Microsoft.Office.Interop
Imports Microsoft.Reporting.WinForms

Public Class FrmMonRekapPengajuanUpahBongkar
    Dim ReportName As String
    Private Sub FrmMonApprovalPenerimaan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' set dtpMuat1 dan dtpMuat2 ke tanggal awal dan akhir bulan ini
        dtpPengajuan1.Value = Now
        dtpPengajuan2.Value = Now

        Call ClsFlexGrid.ApplyStyle(fg)
    End Sub
    Private Sub FrmMonApprovalPenerimaan_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        lblJudulForm.Left = (Me.Width \ 2) - (lblJudulForm.Width \ 2)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Me.Cursor = Cursors.WaitCursor

        Dim dt As New DataTable
        Dim i As Integer = 1
        Dim sql As String = "select * from RMPApp..vw_MonRekapPengajuanUpahBongkar where approval_status_1=1 and cast(TanggalPengajuan as date) between '" & Format(dtpPengajuan1.Value, "yyyy-MM-dd") & "' and '" & Format(dtpPengajuan2.Value, "yyyy-MM-dd") & "' "

        If rdBelumRekapExcel.Checked = True Then
            sql &= " and SudahRekapExcel=0"
        ElseIf rdSudahRekapExcel.Checked = True Then
            sql &= " and SudahRekapExcel=1"
        End If

        sql &= " order by TanggalPengajuan,NoTrans asc"

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fg
            .Rows.Count = 1 ' Reset grid sebelum mengisi data baru

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "NoTrans") = row("NoTrans")
                    .Item(i, "TanggalPengajuan") = row("TanggalPengajuan")
                    .Item(i, "Kapal") = row("Kapal")
                    .Item(i, "Pancang") = row("Pancang")
                    .Item(i, "Trip") = row("Trip")
                    .Item(i, "IDRelasi") = row("IDRelasi")
                    .Item(i, "NamaRelasi") = row("NamaRelasi")
                    .Item(i, "RekeningName") = row("RekeningName")
                    .Item(i, "RekeningNo") = row("RekeningNo")
                    .Item(i, "RekeningBank") = row("RekeningBank")
                    .Item(i, "NoNPWP") = row("NoNPWP")
                    .Item(i, "NoKTP") = row("KTP")
                    .Item(i, "BadanUsaha") = row("BadanUsaha")
                    .Item(i, "Netto2Pancang") = row("Netto2Pancang")
                    .Item(i, "TotalRp") = row("TotalRp")
                    .Item(i, "PotPPH21") = row("PotPPH21")
                    .Item(i, "PotPPH23") = row("PotPPH23")
                    .Item(i, "PotBPJS") = row("PotBPJS")
                    .Item(i, "PotonganDP") = row("PotonganDP")
                    .Item(i, "GrandTotal") = row("GrandTotal")

                    i += 1
                Next

                If rdBelumRekapExcel.Checked = True Then
                    ' === Tambah baris TOTAL ===
                    Dim rowTotal As Integer = fg.Rows.Count
                    fg.AddItem("")
                    fg.Item(rowTotal, "NoTrans") = "TOTAL"
                    fg.Rows(rowTotal).StyleNew.BackColor = Color.LightYellow
                    fg.Rows(rowTotal).AllowEditing = False
                End If

                .AutoSizeCols()

                Call LoadReport()
            Else
                MsgBox("Tidak ada data.", vbInformation, AT)
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

        Dim url_paraf As String = url_paraf

        sql = "select * 
                ,approved_1_by as created_by
                ,approved_1_at as created_at
                ,'" & url_paraf & "' + approved_1_by + '.png' as paraf_created
                ,approved_2_by
                ,approved_2_at
                ,'" & url_paraf & "' + approved_2_by + '.png' as paraf_approve2
                ,approved_3_by
                ,approved_3_at
                ,'" & url_paraf & "' + approved_3_by + '.png' as paraf_approve3
                from RMPApp..vw_MonRekapPengajuanUpahBongkar where approval_status_1=1 and cast(TanggalPengajuan as date) between '" & Format(dtpPengajuan1.Value, "yyyy-MM-dd") & "' and '" & Format(dtpPengajuan2.Value, "yyyy-MM-dd") & "' order by TanggalPengajuan,NoTrans asc"

        Me.Cursor = Cursors.WaitCursor
        Try
            Dim dtTable As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)
            If dtTable.Rows.Count > 0 Then
                Dim FileName As String = "REKAP DATA PETANI UNTUK PEMBAYARAN UPAH BURUH BULAT BPI TANGGAL" & "_" & Format(dtpPengajuan1.Value, "dd-MMM-yyyy")
                ReportName = ".RptRekapUpahBongkar.rdlc"
                Dim rpt As ReportViewer = Me.ReportViewer1
                rpt.Reset()
                rpt.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                Dim dtGLAPPayment = New ReportDataSource("dtRekapUpahBongkar", dtTable)
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
            MsgBox("Error Load Report : " & ex.Message, vbCritical)
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
            MsgBox("Tidak ada data untuk direkap/direstore.", vbInformation, AT)
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
            MsgBox("Tidak ada data yang dipilih untuk direkap/direstore.", vbInformation, AT)
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
            If MsgBox("Yakin mau restore data?", vbYesNo + vbQuestion, "Konfirmasi") = vbNo Then
                Exit Sub
            End If

            ' Update status SudahRekapExcel
            For j As Integer = 1 To fg.Rows.Count - 1
                If fg.Item(j, "Select") = True Then
                    Modul_RMP.DB.ExecuteQuery(StrConnRMPApp,
                        "UPDATE RMPApp..TblTrnUpahBongkarHdr " &
                        "SET SudahRekapExcel = 0 " &
                        "WHERE NoTrans = '" & fg.Item(j, "NoTrans") & "'"
                    )
                End If
            Next

            ' Refresh data
            btnSearch.PerformClick()

            MsgBox("Restore berhasil.", vbInformation, "Sukses")
        End If
    End Sub

    Private Function RekapExcel() As Boolean
        RekapExcel = False

        Try
            ' === Cek data ===
            If fg.Rows.Count <= 1 Then
                MsgBox("Data kosong.", vbExclamation)
                Exit Function
            End If

            ' === Sembunyikan kolom Select saat export ===
            Dim selectVisible As Boolean = False
            If fg.Cols.Contains("Select") Then
                selectVisible = fg.Cols("Select").Visible
                fg.Cols("Select").Visible = False
            End If

            Using save As New SaveFileDialog
                save.Filter = "Excel File (*.xlsx)|*.xlsx"
                save.FileName = "Pengajuan Upah Bongkar_" & Format(Now, "yyyyMMdd")

                If save.ShowDialog() = DialogResult.OK Then

                    ' === EXPORT LANGSUNG DARI FLEXGRID ===
                    fg.SaveExcel(save.FileName, "Sheet1", FileFlags.IncludeFixedCells)

                    ' === Kembalikan kolom Select ===
                    If fg.Cols.Contains("Select") Then
                        fg.Cols("Select").Visible = selectVisible
                    End If

                    If IO.File.Exists(save.FileName) Then

                        ' === Update status database ===
                        For j As Integer = 1 To fg.Rows.Count - 1
                            Modul_RMP.DB.ExecuteQuery(StrConnRMPApp,
                            "UPDATE RMPApp..TblTrnUpahBongkarHdr " &
                            "SET SudahRekapExcel=1 " &
                            "WHERE NoTrans='" & fg.Item(j, "NoTrans") & "'")
                        Next

                        MsgBox("Export berhasil!", vbInformation, "Sukses")
                        RekapExcel = True
                    Else
                        MsgBox("Export gagal.", vbCritical, "Gagal")
                    End If
                End If
            End Using

        Catch ex As Exception
            MsgBox("Error Export : " & ex.Message, vbCritical)
        End Try

        Return RekapExcel
    End Function

    Private Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs)
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

        If fg.Rows.Count <= 2 Then Exit Sub

        Dim rowTotal As Integer = fg.Rows.Count - 1

        ' Reset total
        fg.Item(rowTotal, "Netto2Pancang") = 0
        fg.Item(rowTotal, "TotalRp") = 0
        fg.Item(rowTotal, "PotPPH21") = 0
        fg.Item(rowTotal, "PotPPH23") = 0
        fg.Item(rowTotal, "PotBPJS") = 0
        fg.Item(rowTotal, "GrandTotal") = 0

        ' Hitung hanya yang dicentang
        For r As Integer = 1 To fg.Rows.Count - 2

            If fg.Item(r, "Select") = True Then
                fg.Item(rowTotal, "Netto2Pancang") += Val(fg.Item(r, "Netto2Pancang"))
                fg.Item(rowTotal, "TotalRp") += Val(fg.Item(r, "TotalRp"))
                fg.Item(rowTotal, "PotPPH21") += Val(fg.Item(r, "PotPPH21"))
                fg.Item(rowTotal, "PotPPH23") += Val(fg.Item(r, "PotPPH23"))
                fg.Item(rowTotal, "PotBPJS") += Val(fg.Item(r, "PotBPJS"))
                fg.Item(rowTotal, "GrandTotal") += Val(fg.Item(r, "GrandTotal"))
            End If

        Next

    End Sub

End Class