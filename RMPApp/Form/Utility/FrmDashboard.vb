Imports LiveChartsCore
Imports LiveChartsCore.Measure
Imports LiveChartsCore.SkiaSharpView
Imports LiveChartsCore.SkiaSharpView.Painting
Imports SkiaSharp

Public Class FrmDashboard
    Private Sub FrmDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpTglNota.Value = Now

        AturLebarPanel()
    End Sub

    Private Sub SetPanelRound()
        Func.SetRoundedPanel(PnlNotaPembelianIco, 8)

        Func.SetRoundedPanel(PnlTotalNota, 8)
        Func.SetRoundedPanel(PnlTotalNotaIco, 8)
        Func.SetRoundedPanel(PnlTotalPengajuan, 8)
        Func.SetRoundedPanel(PnlTotalPengajuanIco, 8)
        Func.SetRoundedPanel(PnlMenungguAcc, 8)
        Func.SetRoundedPanel(PnlMenungguAccIco, 8)
        Func.SetRoundedPanel(PnlApproved, 8)
        Func.SetRoundedPanel(PnlApprovedIco, 8)

        Func.SetRoundedPanel(PnlProsesNotaPergroup, 8)
        Func.SetRoundedPanel(PnlProsesPengajuanPergroup, 8)
        Func.SetRoundedPanel(PnlMenungguAccDtl, 8)

        Func.SetRoundedPanel(PnlRankingPancang, 8)
    End Sub

    Private Sub AturLebarPanel()
        For Each pnl As Control In flpDashboard.Controls
            pnl.Width = flpDashboard.ClientSize.Width - pnl.Margin.Horizontal
        Next
    End Sub

    Private Sub FrmDashboard_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        AturLebarPanel()
    End Sub

    Private Sub FrmDashboard_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        SetPanelRound()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Me.Cursor = Cursors.WaitCursor

        LoadNotaPembelian()
        LoadProsesPergroup()
        LoadMenungguAccDtl()
        LoadRankingNotaPerpancang()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadNotaPembelian()
        'Total Nota
        Dim totalNota As Integer = 0
        totalNota = DB.ExecuteScalarValue(Of Integer)(StrConnRMPApp, "SELECT
                                                                            COUNT(a.InvoiceNo)
                                                                        FROM TblTrnApprovalPenerimaanDtl AS a
                                                                        INNER JOIN TblTrnApprovalPenerimaanHdr AS b ON a.NoTrans = b.NoTrans
                                                                        INNER JOIN tblUtlUserPancangGroup AS c ON b.CreatedBy = c.UserID
                                                                        INNER JOIN tblUtlMstPancangGroup AS d ON c.GroupID = d.GroupID
                                                                        WHERE a.Deleted = 0
                                                                            AND b.Deleted = 0
                                                                            and CAST(b.TanggalApproval AS DATE) = '" & Format(dtpTglNota.Value, "yyyy-MM-dd") & "' ")
        txtTotalNota.Text = totalNota.ToString("N0")

        'Total Pengajuan
        Dim totalPengajuan As Integer = 0
        totalPengajuan = DB.ExecuteScalarValue(Of Integer)(StrConnRMPApp, "select COUNT(a.NoTrans)
                                                                            from TblTrnApprovalPenerimaanHdr as a 
                                                                            outer apply (
	                                                                            select top 1 b.IDPancang from TblTrnApprovalPenerimaanDtl as b where a.NoTrans=b.NoTrans
                                                                            ) as c
                                                                            WHERE a.Deleted=0 and CAST(a.TanggalApproval AS DATE) = '" & Format(dtpTglNota.Value, "yyyy-MM-dd") & "' ")
        txtTotalPengajuan.Text = totalPengajuan.ToString("N0")

        'Total Menunggu ACC
        Dim totalMenungguAcc As Integer = 0
        totalMenungguAcc = DB.ExecuteScalarValue(Of Integer)(StrConnRMPApp, "select COUNT(a.NoTrans)
                                                                            from TblTrnApprovalPenerimaanHdr as a 
                                                                            outer apply (
	                                                                            select top 1 b.IDPancang from TblTrnApprovalPenerimaanDtl as b where a.NoTrans=b.NoTrans
                                                                            ) as c
                                                                            WHERE ApprovalStatus=0 and a.Deleted=0 and CAST(a.TanggalApproval AS DATE) = '" & Format(dtpTglNota.Value, "yyyy-MM-dd") & "' ")
        txtMenungguAcc.Text = totalMenungguAcc.ToString("N0")

        'Total Approved
        Dim totalApproved As Integer = 0
        totalApproved = DB.ExecuteScalarValue(Of Integer)(StrConnRMPApp, "select COUNT(a.NoTrans)
                                                                            from TblTrnApprovalPenerimaanHdr as a 
                                                                            outer apply (
                                                                                select top 1 b.IDPancang from TblTrnApprovalPenerimaanDtl as b where a.NoTrans=b.NoTrans
                                                                            ) as c
                                                                            WHERE ApprovalStatus=1 and a.Deleted=0 and CAST(a.TanggalApproval AS DATE) = '" & Format(dtpTglNota.Value, "yyyy-MM-dd") & "' ")
        txtApproved.Text = totalApproved.ToString("N0")
    End Sub

    Private Sub LoadProsesPergroup()
        'Nota
        Dim dt As DataTable = New DataTable
        dt = DB.ExecuteQuery(StrConnRMPApp, "WITH DataGroup AS (
                                                SELECT
                                                    COUNT(a.InvoiceNo) AS SumInvoice,
                                                    d.GroupName
                                                FROM TblTrnApprovalPenerimaanDtl AS a
                                                INNER JOIN TblTrnApprovalPenerimaanHdr AS b ON a.NoTrans = b.NoTrans
                                                INNER JOIN tblUtlUserPancangGroup AS c ON b.CreatedBy = c.UserID
                                                INNER JOIN tblUtlMstPancangGroup AS d ON c.GroupID = d.GroupID
                                                WHERE a.Deleted = 0
                                                    AND b.Deleted = 0
                                                    and CAST(b.TanggalApproval AS DATE) = '" & Format(dtpTglNota.Value, "yyyy-MM-dd") & "' 
                                                GROUP BY d.GroupName
                                            )
                                            SELECT
                                                GroupName,
                                                CAST(SumInvoice * 100.0 / SUM(SumInvoice) OVER() AS DECIMAL(10,2)) AS Persentase
                                            FROM DataGroup
                                            ORDER BY GroupName")

        Dim series As New List(Of ISeries)

        For Each row As DataRow In dt.Rows

            Dim namaGroup As String = row("GroupName").ToString()
            Dim persentase As Double = CDbl(row("Persentase"))

            series.Add(
            New PieSeries(Of Double) With {
                .Name = namaGroup,
                .Values = New Double() {persentase},
                .DataLabelsPosition = PolarLabelsPosition.Middle,
                .DataLabelsSize = 14,
                .DataLabelsPaint = New SolidColorPaint(SKColors.White),
                .DataLabelsFormatter =
                    Function(point) namaGroup & vbCrLf & $"{persentase:N2}%"
            }
        )

        Next

        pcNota.Series = series

        'Pengjauan
        dt = DB.ExecuteQuery(StrConnRMPApp, "WITH DataGroup AS (
                                                SELECT
                                                    COUNT(b.NoTrans) AS SumInvoice,
                                                    d.GroupName
                                                FROM TblTrnApprovalPenerimaanHdr AS b
                                                INNER JOIN tblUtlUserPancangGroup AS c ON b.CreatedBy = c.UserID
                                                INNER JOIN tblUtlMstPancangGroup AS d ON c.GroupID = d.GroupID
                                                WHERE b.Deleted = 0
                                                     and CAST(b.TanggalApproval AS DATE) = '" & Format(dtpTglNota.Value, "yyyy-MM-dd") & "' 
                                                GROUP BY d.GroupName
                                            )
                                            SELECT
                                                GroupName,
                                                CAST(SumInvoice * 100.0 / SUM(SumInvoice) OVER() AS DECIMAL(10,2)) AS Persentase
                                            FROM DataGroup
                                            ORDER BY GroupName")

        Dim seriesPengajuan As New List(Of ISeries)

        For Each row As DataRow In dt.Rows

            Dim namaGroup As String = row("GroupName").ToString()
            Dim persentase As Double = CDbl(row("Persentase"))

            seriesPengajuan.Add(
        New PieSeries(Of Double) With {
                .Name = namaGroup,
                .Values = New Double() {persentase},
                .DataLabelsPosition = PolarLabelsPosition.Middle,
                .DataLabelsSize = 14,
                .DataLabelsPaint = New SolidColorPaint(SKColors.White),
                .DataLabelsFormatter = Function(point) namaGroup & vbCrLf & $"{persentase:N2}%"
            }
        )

        Next

        pcPengajuan.Series = seriesPengajuan

    End Sub

    Private Sub LoadMenungguAccDtl()
        Dim totalMenungguAcc As Integer = 0

        'Menunggu ACC Level1
        totalMenungguAcc = DB.ExecuteScalarValue(Of Integer)(StrConnRMPApp, "select COUNT(a.NoTrans)
                                                                            from TblTrnApprovalPenerimaanHdr as a 
                                                                            outer apply (
	                                                                            select top 1 b.IDPancang from TblTrnApprovalPenerimaanDtl as b where a.NoTrans=b.NoTrans
                                                                            ) as c
                                                                            WHERE ApprovalStatus=0 and a.ApprovalLevel=0 and a.Deleted=0 and CAST(a.TanggalApproval AS DATE) = '" & Format(dtpTglNota.Value, "yyyy-MM-dd") & "' ")
        txtMenungguAccLv1.Text = totalMenungguAcc.ToString("N0")

        'Menunggu ACC Level2
        totalMenungguAcc = DB.ExecuteScalarValue(Of Integer)(StrConnRMPApp, "select COUNT(a.NoTrans)
                                                                            from TblTrnApprovalPenerimaanHdr as a 
                                                                            outer apply (
	                                                                            select top 1 b.IDPancang from TblTrnApprovalPenerimaanDtl as b where a.NoTrans=b.NoTrans
                                                                            ) as c
                                                                            WHERE ApprovalStatus=0 and a.ApprovalLevel=1 and a.Deleted=0 and CAST(a.TanggalApproval AS DATE) = '" & Format(dtpTglNota.Value, "yyyy-MM-dd") & "' ")
        txtMenungguAccLv2.Text = totalMenungguAcc.ToString("N0")

        'Menunggu ACC Level3
        totalMenungguAcc = DB.ExecuteScalarValue(Of Integer)(StrConnRMPApp, "select COUNT(a.NoTrans)
                                                                            from TblTrnApprovalPenerimaanHdr as a 
                                                                            outer apply (
	                                                                            select top 1 b.IDPancang from TblTrnApprovalPenerimaanDtl as b where a.NoTrans=b.NoTrans
                                                                            ) as c
                                                                            WHERE ApprovalStatus=0 and a.ApprovalLevel=2 and a.Deleted=0 and CAST(a.TanggalApproval AS DATE) = '" & Format(dtpTglNota.Value, "yyyy-MM-dd") & "' ")
        txtMenungguAccLv3.Text = totalMenungguAcc.ToString("N0")
    End Sub

    Private Sub LoadRankingNotaPerpancang()
        Dim HariTerakhir As Integer = 0

        If rd1HariNP.Checked Then
            HariTerakhir = 0
        ElseIf rd7HariNP.Checked Then
            HariTerakhir = -7
        ElseIf rd30HariNP.Checked Then
            HariTerakhir = -30
        End If

        Dim dt As DataTable = DB.ExecuteQuery(StrConnRMPApp,
        "SELECT c.Pancang, COUNT(a.InvoiceNo) AS TotalNota " &
        "FROM TblTrnApprovalPenerimaanDtl AS a " &
        "INNER JOIN TblTrnApprovalPenerimaanHdr AS b ON a.NoTrans = b.NoTrans " &
        "INNER JOIN Android_tblMstPancang AS c ON a.IDPancang = c.IDPancang " &
        "WHERE a.Deleted = 0 AND b.Deleted = 0 " &
        "AND CAST(b.TanggalApproval AS DATE) BETWEEN '" &
        Format(dtpTglNota.Value.AddDays(HariTerakhir), "yyyy-MM-dd") &
        "' AND '" & Format(dtpTglNota.Value, "yyyy-MM-dd") & "' " &
        "GROUP BY c.Pancang " &
        "ORDER BY COUNT(a.InvoiceNo) asc")

        Dim namaGroup As String() = dt.AsEnumerable().
        Select(Function(r) r("Pancang").ToString()).ToArray()

        Dim jumlahNota As Double() = dt.AsEnumerable().
        Select(Function(r) CDbl(r("TotalNota"))).ToArray()

        CartesianChart1.Height = Math.Max(200, (namaGroup.Length * 35) + 80)

        CartesianChart1.Series = New ISeries() {
        New RowSeries(Of Double) With {
            .Name = "Jumlah Nota",
            .Values = jumlahNota,
            .DataLabelsPosition = DataLabelsPosition.End,
            .DataLabelsSize = 14,
            .DataLabelsPaint = New SolidColorPaint(SKColors.Black)
        }
    }

        CartesianChart1.XAxes = {
        New Axis With {
            .Name = "Jumlah Nota",
            .MinLimit = 0
        }
    }

        CartesianChart1.YAxes = {
        New Axis With {
            .Labels = namaGroup,
            .TextSize = 14,
            .MinStep = 1,
            .ForceStepToMin = True
        }
    }
    End Sub
End Class