Imports Microsoft.Reporting.WinForms

Public Class FrmMonInformasiPenerimaanBahanBaku
    Dim ReportName As String
    Private Sub FrmMonInformasiPenerimaanBahanBaku_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Modul_RMP.Combo.SetPancang_(cboPancang)
        cboPancang.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboPancang.AutoCompleteSource = AutoCompleteSource.ListItems

        cboPancang.Text = ""

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub FrmMonApprovalPenerimaan_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        lblJudulForm.Left = (Me.Width \ 2) - (lblJudulForm.Width \ 2)
    End Sub

    Private Sub LoadReport()
        Dim sql As String = ""
        Dim ParmsPengajuan As New ReportParameter
        Dim Pengajuan As String = ""

        Dim imgLogo As Image
        Dim paramsImgLogo As New ReportParameter
        Dim DateStart, DateEnd As New ReportParameter

        Dim Bongkar As String = ""
        If rdPSG.Checked = True Then
            Bongkar = "PSG"
        ElseIf rdRSUP.Checked = True Then
            Bongkar = "RSUP"
        End If


        Dim dtTable As DataTable

        If rdPSG.Checked = True Then
            sql = "DECLARE @DateStart		date='" & Format(dtpPengajuan1.Value, "yyyy-MM-dd") & "',
		                    @DateEnd		date='" & Format(dtpPengajuan2.Value, "yyyy-MM-dd") & "',
		                    @Pancang		varchar(100)='',
		                    @RentangHari	int

                    set @RentangHari = DATEDIFF(DAY,@DateStart,@DateEnd)+1;

                    select
                        mainsuppliername as Pancang,
	                    jenis as Jenis,
                        sum(nettoA) as NettoA,
	                    (sum(NettoA)/sum(TotNetAB))*100 as PersenNettoA,
                        sum(NettoB) as NettoB,
	                    (sum(NettoB)/sum(TotNetAB))*100 as PersenNettoB,
	                    sum(TotNetAB) as TotalNetto,
	                    sum(TotNetAB)/@RentangHari as RataPerhari
                    from vwMonTrnPenerimaanKbkg_pcg
                    where cast(TglTerima as date) between @DateStart and @DateEnd
                    group by MainSupplierName,jenis
                    order by mainsuppliername,jenis desc"

            dtTable = Modul_RMP.DB.ExecuteQuery(StrConnPSGRMP, sql)
        ElseIf rdRSUP.Checked = True Then
            Dim Pancang As String = ""
            Pancang = cboPancang.Text

            sql = "exec spMonInformasiPenerimaanBahanBaku '" & Format(dtpPengajuan1.Value, "yyyy-MM-dd") & "','" & Format(dtpPengajuan2.Value, "yyyy-MM-dd") & "','" & Pancang & "'"

            dtTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)
        End If

        Me.Cursor = Cursors.WaitCursor
        Try
            If dtTable.Rows.Count > 0 Then
                Dim FileName As String = "INFORMASI PEMEBLIAN BAHAN BAKU PT " & Bongkar & " TANGGAL" & "_" & Format(Now, "dd-MMM-yyyy")
                ReportName = ".RptInformasiPenerimaanBahanBaku.rdlc"
                Dim rpt As ReportViewer = Me.ReportViewer1
                rpt.Reset()
                rpt.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                Dim dtGLAPPayment = New ReportDataSource("dtInformasiPenerimaanBahanBaku", dtTable)
                rpt.LocalReport.DisplayName = Replace(FileName, "/", "-")
                rpt.LocalReport.DataSources.Add(dtGLAPPayment)

                rpt.LocalReport.ReportEmbeddedResource = My.Application.Info.ProductName & ReportName
                rpt.LocalReport.EnableExternalImages = True

                DateStart = New ReportParameter("DateStart", Format(dtpPengajuan1.Value, "yyyy-MM-dd").ToString)
                rpt.LocalReport.SetParameters(DateStart)

                DateEnd = New ReportParameter("DateEnd", Format(dtpPengajuan1.Value, "yyyy-MM-dd").ToString)
                rpt.LocalReport.SetParameters(DateEnd)

                Dim newPageSetting As New System.Drawing.Printing.PageSettings
                newPageSetting.Margins = New System.Drawing.Printing.Margins(0, 0, 0, 0)
                newPageSetting.Landscape = False
                'newPageSetting.PaperSize = New PaperSize("Customer", 850, 550)

                Me.ReportViewer1.ShowToolBar = True
                rpt.SetPageSettings(newPageSetting)
                rpt.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
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

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Me.ReportViewer1.RefreshReport()

        Call LoadReport()
    End Sub
End Class