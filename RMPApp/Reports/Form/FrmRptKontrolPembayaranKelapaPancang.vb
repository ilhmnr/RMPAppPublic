Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports DocumentFormat.OpenXml.Math
Imports Microsoft.Reporting.WinForms

Public Class FrmRptKontrolPembayaranKelapaPancang
    Private Sub FrmRptKontrolPembayaranKelapaPancang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call headerFg

        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer2.RefreshReport()
    End Sub

    Private Sub headerFg()
        Dim txt As CellRange
        With fg
            .AllowEditing = True
            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular)
            .Rows.Count = 2
            .Cols.Count = 14
            .Cols.Fixed = 0
            .Rows.Fixed = 2
            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(209, 229, 252)
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).AllowMerging = True

            txt = .GetCellRange(0, 0, 1, 0) : txt.Data = "Minggu" : .Cols(0).TextAlign = TextAlignEnum.CenterCenter : .Cols(0).AllowEditing = False : .Cols(0).AllowMerging = True
            txt = .GetCellRange(0, 1, 1, 1) : txt.Data = "Periode Tanggal" : .Cols(1).TextAlign = TextAlignEnum.CenterCenter : .Cols(1).AllowEditing = False : .Cols(1).AllowMerging = True

            txt = .GetCellRange(0, 2, 0, 3) : txt.Data = "KB Licin" : .Cols(2).TextAlign = TextAlignEnum.RightCenter : .Cols(2).AllowEditing = False
            txt = .GetCellRange(1, 2, 1, 2) : txt.Data = "P1" : .Cols(2).TextAlign = TextAlignEnum.RightCenter : .Cols(2).AllowEditing = False : .Cols(2).AllowMerging = True : .Cols(2).Format = "#,##0"
            txt = .GetCellRange(1, 3, 1, 3) : txt.Data = "P2" : .Cols(3).TextAlign = TextAlignEnum.RightCenter : .Cols(3).AllowEditing = False : .Cols(3).AllowMerging = True : .Cols(3).Format = "#,##0"

            txt = .GetCellRange(0, 4, 0, 5) : txt.Data = "KB Jambul" : .Cols(4).TextAlign = TextAlignEnum.RightCenter : .Cols(4).AllowEditing = False
            txt = .GetCellRange(1, 4, 1, 4) : txt.Data = "P1" : .Cols(4).TextAlign = TextAlignEnum.RightCenter : .Cols(4).AllowEditing = False : .Cols(4).AllowMerging = True : .Cols(4).Format = "#,##0"
            txt = .GetCellRange(1, 5, 1, 5) : txt.Data = "P2" : .Cols(5).TextAlign = TextAlignEnum.RightCenter : .Cols(5).AllowEditing = False : .Cols(5).AllowMerging = True : .Cols(5).Format = "#,##0"

            txt = .GetCellRange(0, 6, 0, 7) : txt.Data = "KC" : .Cols(6).TextAlign = TextAlignEnum.RightCenter : .Cols(6).AllowEditing = False
            txt = .GetCellRange(1, 6, 1, 6) : txt.Data = "P1" : .Cols(6).TextAlign = TextAlignEnum.RightCenter : .Cols(6).AllowEditing = False : .Cols(6).AllowMerging = True : .Cols(6).Format = "#,##0"
            txt = .GetCellRange(1, 7, 1, 7) : txt.Data = "P2" : .Cols(7).TextAlign = TextAlignEnum.RightCenter : .Cols(7).AllowEditing = False : .Cols(7).AllowMerging = True : .Cols(7).Format = "#,##0"

            txt = .GetCellRange(0, 8, 0, 9) : txt.Data = "UBM" : .Cols(8).TextAlign = TextAlignEnum.RightCenter : .Cols(8).AllowEditing = False
            txt = .GetCellRange(1, 8, 1, 8) : txt.Data = "P1" : .Cols(8).TextAlign = TextAlignEnum.RightCenter : .Cols(8).AllowEditing = False : .Cols(8).AllowMerging = True : .Cols(8).Format = "#,##0"
            txt = .GetCellRange(1, 9, 1, 9) : txt.Data = "P2" : .Cols(9).TextAlign = TextAlignEnum.RightCenter : .Cols(9).AllowEditing = False : .Cols(9).AllowMerging = True : .Cols(9).Format = "#,##0"

            txt = .GetCellRange(0, 10, 0, 11) : txt.Data = "UB" : .Cols(10).TextAlign = TextAlignEnum.RightCenter : .Cols(10).AllowEditing = False
            txt = .GetCellRange(1, 10, 1, 10) : txt.Data = "P1" : .Cols(10).TextAlign = TextAlignEnum.RightCenter : .Cols(10).AllowEditing = False : .Cols(10).AllowMerging = True : .Cols(10).Format = "#,##0"
            txt = .GetCellRange(1, 11, 1, 11) : txt.Data = "P2" : .Cols(11).TextAlign = TextAlignEnum.RightCenter : .Cols(11).AllowEditing = False : .Cols(11).AllowMerging = True : .Cols(11).Format = "#,##0"

            txt = .GetCellRange(0, 12, 1, 12) : txt.Data = "Total" : .Cols(12).TextAlign = TextAlignEnum.RightCenter : .Cols(12).AllowEditing = False : .Cols(12).AllowMerging = True : .Cols(12).Format = "#,##0"
            txt = .GetCellRange(0, 13, 1, 13) : txt.Data = "Bulan" : .Cols(13).TextAlign = TextAlignEnum.LeftCenter : .Cols(13).Visible = False

            .AutoSizeCols()
        End With
    End Sub

    Private Function ExecuteQuery(ByVal sqla As String, Optional params As SqlParameter() = Nothing) As DataTable
        Dim dt As DataTable = New DataTable()
        Using cn As SqlConnection = New SqlConnection("Data Source=192.168.12.5;Initial Catalog=RSUPAccounting;Persist Security Info=True;User ID=uKoneksi; pooling=false; password=sm@rt2018; Max Pool Size=100000;Connection Timeout=50; ")
            Using cmd As SqlCommand = New SqlCommand(sqla, cn)
                cmd.CommandTimeout = 600
                If Not params Is Nothing Then
                    cmd.Parameters.AddRange(params)
                End If
                Try
                    cn.Open()
                    dt.Load(cmd.ExecuteReader)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
        End Using
        Return dt
    End Function

    Private Sub createReport()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim Conn As SqlConnection
            Dim ReportName, Ds, sql As String

            fg.Visible = False

            Dim via As String = ""
            Dim via_ As String = ""
            If chkP1.Checked = True And chkP2.Checked = True Then
                ReportName = ".RptKontrolPembayaranKelapaPancang.rdlc"
                via = "PSG Dan RSUP"
                via_ = " Pabrik in ('P1','P2') "
                ReportViewer1.Visible = True
                ReportViewer2.Visible = False
            ElseIf chkP1.Checked = True Then
                ReportName = ".RptKontrolPembayaranKelapaPancangPisahP1danP2.rdlc"
                via = "PSG"
                via_ = " Pabrik = 'P1' "
                ReportViewer1.Visible = False
                ReportViewer2.Visible = True
            ElseIf chkP2.Checked = True Then
                ReportName = ".RptKontrolPembayaranKelapaPancangPisahP1danP2.rdlc"
                via = "RSUP"
                via_ = " Pabrik = 'P2' "
                ReportViewer1.Visible = False
                ReportViewer2.Visible = True
            End If

            Dim periode As String = ""
            Dim startDate As Date = dtp1.Value
            Dim endDate As Date = dtp2.Value
            periode = startDate.ToString("MMMM") & " - " & endDate.ToString("MMMM/yyyy")

            Dim ParamList As New Generic.List(Of ReportParameter)
            ParamList.Add(New Microsoft.Reporting.WinForms.ReportParameter("via", via, True))
            ParamList.Add(New Microsoft.Reporting.WinForms.ReportParameter("periode", periode, True))

            Ds = "dtkontrolpembayarankelapapacang"

            Dim i As Integer = 1
            Dim _Dt As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " SELECT 
                                                                                    CASE MONTH(TanggalStart)
                                                                                    WHEN 1 THEN 'Jan'
                                                                                    WHEN 2 THEN 'Feb'
                                                                                    WHEN 3 THEN 'Mar'
                                                                                    WHEN 4 THEN 'Apr'
                                                                                    WHEN 5 THEN 'Mei'
                                                                                    WHEN 6 THEN 'Jun'
                                                                                    WHEN 7 THEN 'Jul'
                                                                                    WHEN 8 THEN 'Agust'
                                                                                    WHEN 9 THEN 'Sep'
                                                                                    WHEN 10 THEN 'Okt'
                                                                                    WHEN 11 THEN 'Nov'
                                                                                    ELSE 'Des' 
                                                                                    END AS bulan_,Minggu AS minggu,TanggalRange AS periode,cast(0 as bigint) as kblicinp1,cast(0 as bigint) as kblicinp2,cast(0 as bigint) as kbjambulp1,cast(0 as bigint) as kbjambulp2,cast(0 as bigint) as kcp1,cast(0 as bigint) as kcp2,cast(0 as bigint) as total
                                                                                    from TblMstMingguKalender where (format(TanggalStart,'yyyy-MM') between '" & Format(dtp1.Value, "yyyy-MM") & "' and '" & Format(dtp2.Value, "yyyy-MM") & "') 
                                                                                    order by TanggalStart asc ")

            _Dt.Columns("kblicinp1").ReadOnly = False
            _Dt.Columns("kblicinp2").ReadOnly = False
            _Dt.Columns("kbjambulp1").ReadOnly = False
            _Dt.Columns("kbjambulp2").ReadOnly = False
            _Dt.Columns("kcp1").ReadOnly = False
            _Dt.Columns("kcp2").ReadOnly = False
            _Dt.Columns("total").ReadOnly = False

            If chkP1.Checked = True Then
                Dim dtKbLicinP1 As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " WITH countkelapa as ( Select ISNULL(count(TransID), 0) As Countt,TextMessage FROM [RMPApp].[dbo].[TblTrnKelapaHdr] as a left outer join RSUPAccounting..tblRMTrnPenerimaanPancangDtl as b on a.NoNota=b.NoNota 
                                                                                        WHERE Deleted = 0 And 1=1  AND  (format(b.CreatedDate,'yyyy-MM') between '" & Format(dtp1.Value, "yyyy-MM") & "' and '" & Format(dtp2.Value, "yyyy-MM") & "') And (Deleted Is NULL Or Deleted = 0)   AND JenisKB ='KB-A' GROUP BY  TextMessage 
                                                                                        having count(TextMessage) > 1),

                                                                                        cektimbang As (Select DISTINCT headerID  FROM [RMPApp].[dbo].[TblTrnKelapaDtlWireless]),

                                                                                        amount as (Select (((isnull(TotalHarga,0)-isnull(Potongan,0))-isnull(PPhPotong,0))+(isnull(jumlahkarung,0)*isnull(hargasubsidikarung,0)))+isnull(cashbackpph,0) as amount,cast(TglTerima as date) as fdate
                                                                                        from vwTMBGKelapaHdr2021  AS A LEFT outer JOIN countkelapa As B On A.TextMessage =B.TextMessage   LEFT outer JOIN cektimbang  AS C ON A.TransID = 
                                                                                        C.headerID    where 1=1  AND (format(TglTerima,'yyyy-MM') between '" & Format(dtp1.Value, "yyyy-MM") & "' and '" & Format(dtp2.Value, "yyyy-MM") & "') and  A.Bongkar = 'PSG' AND (Deleted is NULL or Deleted = 0) AND JenisKB ='KB-A' and Jenis='Licin' )

                                                                                        select sum(isnull(a.Amount,0)) as Amount,b.TanggalRange from amount as a right join
                                                                                        TblMstMingguKalender as b on a.fdate between b.TanggalStart and b.TanggalEnd 
                                                                                        where (format(TanggalStart,'yyyy-MM') between '" & Format(dtp1.Value, "yyyy-MM") & "' and '" & Format(dtp2.Value, "yyyy-MM") & "')
                                                                                        group by b.TanggalRange order by RIGHT(LEFT(TanggalRange,8),2),LEFT(TanggalRange,2) asc ")

                i = 0
                If dtKbLicinP1 IsNot Nothing Then
                    For Each row As DataRow In dtKbLicinP1.Rows
                        _Dt.Rows(i)("kblicinp1") = row("Amount")
                        i += 1
                    Next
                End If

                Dim dtKbJambulP1 As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " WITH countkelapa as ( Select ISNULL(count(TransID), 0) As Countt,TextMessage FROM [RMPApp].[dbo].[TblTrnKelapaHdr] as a left outer join RSUPAccounting..tblRMTrnPenerimaanPancangDtl as b on a.NoNota=b.NoNota 
                                                                                            WHERE Deleted = 0 And 1=1  AND  (format(b.CreatedDate,'yyyy-MM') between '" & Format(dtp1.Value, "yyyy-MM") & "' and '" & Format(dtp2.Value, "yyyy-MM") & "') And (Deleted Is NULL Or Deleted = 0)   AND JenisKB ='KB-A' GROUP BY  TextMessage 
                                                                                            having count(TextMessage) > 1),

                                                                                            cektimbang As (Select DISTINCT headerID  FROM [RMPApp].[dbo].[TblTrnKelapaDtlWireless]),

                                                                                            amount as (Select (((isnull(TotalHarga,0)-isnull(Potongan,0))-isnull(PPhPotong,0))+(isnull(jumlahkarung,0)*isnull(hargasubsidikarung,0)))+isnull(cashbackpph,0) as amount,cast(TglTerima as date) as fdate
                                                                                            from vwTMBGKelapaHdr2021  AS A LEFT outer JOIN countkelapa As B On A.TextMessage =B.TextMessage   LEFT outer JOIN cektimbang  AS C ON A.TransID = 
                                                                                            C.headerID    where 1=1  AND (format(TglTerima,'yyyy-MM') between '" & Format(dtp1.Value, "yyyy-MM") & "' and '" & Format(dtp2.Value, "yyyy-MM") & "') and  A.Bongkar = 'PSG' AND (Deleted is NULL or Deleted = 0) AND JenisKB ='KB-A' and Jenis='Jambul' )

                                                                                            select sum(isnull(a.Amount,0)) as Amount,b.TanggalRange from amount as a right join
                                                                                            TblMstMingguKalender as b on a.fdate between b.TanggalStart and b.TanggalEnd 
                                                                                            where (format(TanggalStart,'yyyy-MM') between '" & Format(dtp1.Value, "yyyy-MM") & "' and '" & Format(dtp2.Value, "yyyy-MM") & "')
                                                                                            group by b.TanggalRange order by RIGHT(LEFT(TanggalRange,8),2),LEFT(TanggalRange,2) asc ")

                i = 0
                If dtKbJambulP1 IsNot Nothing Then
                    For Each row As DataRow In dtKbJambulP1.Rows
                        _Dt.Rows(i)("kbjambulp1") = row("Amount")
                        i += 1
                    Next
                End If

                Dim dtKcP1 As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " WITH countkelapa as ( Select ISNULL(count(TransID), 0) As Countt,TextMessage FROM [RMPApp].[dbo].[TblTrnKelapaHdr] as a left outer join RSUPAccounting..tblRMTrnPenerimaanPancangDtl as b on a.NoNota=b.NoNota 
                                                                                            WHERE Deleted = 0 And 1=1  AND  (format(b.CreatedDate,'yyyy-MM') between '" & Format(dtp1.Value, "yyyy-MM") & "' and '" & Format(dtp2.Value, "yyyy-MM") & "') And (Deleted Is NULL Or Deleted = 0)   AND JenisKB ='KC' GROUP BY  TextMessage 
                                                                                            having count(TextMessage) > 1),

                                                                                            cektimbang As (Select DISTINCT headerID  FROM [RMPApp].[dbo].[TblTrnKelapaDtlWireless]),

                                                                                            amount as (Select (((isnull(TotalHarga,0)-isnull(Potongan,0))-isnull(PPhPotong,0))+(isnull(jumlahkarung,0)*isnull(hargasubsidikarung,0)))+isnull(cashbackpph,0) as amount,cast(TglTerima as date) as fdate
                                                                                            from vwTMBGKelapaHdr2021  AS A LEFT outer JOIN countkelapa As B On A.TextMessage =B.TextMessage   LEFT outer JOIN cektimbang  AS C ON A.TransID = 
                                                                                            C.headerID    where 1=1  AND (format(TglTerima,'yyyy-MM') between '" & Format(dtp1.Value, "yyyy-MM") & "' and '" & Format(dtp2.Value, "yyyy-MM") & "') and  A.Bongkar = 'PSG' AND (Deleted is NULL or Deleted = 0) AND JenisKB ='KC' )

                                                                                            select sum(isnull(a.Amount,0)) as Amount,b.TanggalRange from amount as a right join
                                                                                            TblMstMingguKalender as b on a.fdate between b.TanggalStart and b.TanggalEnd 
                                                                                            where (format(TanggalStart,'yyyy-MM') between '" & Format(dtp1.Value, "yyyy-MM") & "' and '" & Format(dtp2.Value, "yyyy-MM") & "')
                                                                                            group by b.TanggalRange order by RIGHT(LEFT(TanggalRange,8),2),LEFT(TanggalRange,2) asc ")

                i = 0
                If dtKcP1 IsNot Nothing Then
                    For Each row As DataRow In dtKcP1.Rows
                        _Dt.Rows(i)("kcp1") = row("Amount")
                        i += 1
                    Next
                End If
            End If

            If chkP2.Checked = True Then
                Dim dtKbLicinP2 As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " WITH countkelapa as ( Select ISNULL(count(TransID), 0) As Countt,TextMessage FROM [RMPApp].[dbo].[TblTrnKelapaHdr] as a left outer join RSUPAccounting..tblRMTrnPenerimaanPancangDtl as b on a.NoNota=b.NoNota 
                                                                                        WHERE Deleted = 0 And 1=1  AND  (format(b.CreatedDate,'yyyy-MM') between '" & Format(dtp1.Value, "yyyy-MM") & "' and '" & Format(dtp2.Value, "yyyy-MM") & "') And (Deleted Is NULL Or Deleted = 0)   AND JenisKB ='KB-A' GROUP BY  TextMessage 
                                                                                        having count(TextMessage) > 1),

                                                                                        cektimbang As (Select DISTINCT headerID  FROM [RMPApp].[dbo].[TblTrnKelapaDtlWireless]),

                                                                                        amount as (Select (((isnull(TotalHarga,0)-isnull(Potongan,0))-isnull(PPhPotong,0))+(isnull(jumlahkarung,0)*isnull(hargasubsidikarung,0)))+isnull(cashbackpph,0) as amount,cast(TglTerima as date) as fdate
                                                                                        from vwTMBGKelapaHdr2021  AS A LEFT outer JOIN countkelapa As B On A.TextMessage =B.TextMessage   LEFT outer JOIN cektimbang  AS C ON A.TransID = 
                                                                                        C.headerID    where 1=1  AND (format(TglTerima,'yyyy-MM') between '" & Format(dtp1.Value, "yyyy-MM") & "' and '" & Format(dtp2.Value, "yyyy-MM") & "') and  A.Bongkar = 'RSUP' AND (Deleted is NULL or Deleted = 0) AND JenisKB ='KB-A' and Jenis='Licin' )

                                                                                        select sum(isnull(a.Amount,0)) as Amount,b.TanggalRange from amount as a right join
                                                                                        TblMstMingguKalender as b on a.fdate between b.TanggalStart and b.TanggalEnd 
                                                                                        where (format(TanggalStart,'yyyy-MM') between '" & Format(dtp1.Value, "yyyy-MM") & "' and '" & Format(dtp2.Value, "yyyy-MM") & "')
                                                                                        group by b.TanggalRange order by RIGHT(LEFT(TanggalRange,8),2),LEFT(TanggalRange,2) asc ")

                i = 0
                If dtKbLicinP2 IsNot Nothing Then
                    For Each row As DataRow In dtKbLicinP2.Rows
                        _Dt.Rows(i)("kblicinp2") = row("Amount")
                        i += 1
                    Next
                End If

                Dim dtKbjambulP2 As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " WITH countkelapa as ( Select ISNULL(count(TransID), 0) As Countt,TextMessage FROM [RMPApp].[dbo].[TblTrnKelapaHdr] as a left outer join RSUPAccounting..tblRMTrnPenerimaanPancangDtl as b on a.NoNota=b.NoNota 
                                                                                            WHERE Deleted = 0 And 1=1  AND  (format(b.CreatedDate,'yyyy-MM') between '" & Format(dtp1.Value, "yyyy-MM") & "' and '" & Format(dtp2.Value, "yyyy-MM") & "') And (Deleted Is NULL Or Deleted = 0)   AND JenisKB ='KB-A' GROUP BY  TextMessage 
                                                                                            having count(TextMessage) > 1),

                                                                                            cektimbang As (Select DISTINCT headerID  FROM [RMPApp].[dbo].[TblTrnKelapaDtlWireless]),

                                                                                            amount as (Select (((isnull(TotalHarga,0)-isnull(Potongan,0))-isnull(PPhPotong,0))+(isnull(jumlahkarung,0)*isnull(hargasubsidikarung,0)))+isnull(cashbackpph,0) as amount,cast(TglTerima as date) as fdate
                                                                                            from vwTMBGKelapaHdr2021  AS A LEFT outer JOIN countkelapa As B On A.TextMessage =B.TextMessage   LEFT outer JOIN cektimbang  AS C ON A.TransID = 
                                                                                            C.headerID    where 1=1  AND (format(TglTerima,'yyyy-MM') between '" & Format(dtp1.Value, "yyyy-MM") & "' and '" & Format(dtp2.Value, "yyyy-MM") & "') and  A.Bongkar = 'RSUP' AND (Deleted is NULL or Deleted = 0) AND JenisKB ='KB-A' and Jenis='Jambul' )

                                                                                            select sum(isnull(a.Amount,0)) as Amount,b.TanggalRange from amount as a right join
                                                                                            TblMstMingguKalender as b on a.fdate between b.TanggalStart and b.TanggalEnd 
                                                                                            where (format(TanggalStart,'yyyy-MM') between '" & Format(dtp1.Value, "yyyy-MM") & "' and '" & Format(dtp2.Value, "yyyy-MM") & "')
                                                                                            group by b.TanggalRange order by RIGHT(LEFT(TanggalRange,8),2),LEFT(TanggalRange,2) asc ")

                i = 0
                If dtKbjambulP2 IsNot Nothing Then
                    For Each row As DataRow In dtKbjambulP2.Rows
                        _Dt.Rows(i)("kbjambulp2") = row("Amount")
                        i += 1
                    Next
                End If

                Dim dtKcP2 As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " WITH countkelapa as ( Select ISNULL(count(TransID), 0) As Countt,TextMessage FROM [RMPApp].[dbo].[TblTrnKelapaHdr] as a left outer join RSUPAccounting..tblRMTrnPenerimaanPancangDtl as b on a.NoNota=b.NoNota 
                                                                                            WHERE Deleted = 0 And 1=1  AND  (format(b.CreatedDate,'yyyy-MM') between '" & Format(dtp1.Value, "yyyy-MM") & "' and '" & Format(dtp2.Value, "yyyy-MM") & "') And (Deleted Is NULL Or Deleted = 0)   AND JenisKB ='KC' GROUP BY  TextMessage 
                                                                                            having count(TextMessage) > 1),

                                                                                            cektimbang As (Select DISTINCT headerID  FROM [RMPApp].[dbo].[TblTrnKelapaDtlWireless]),

                                                                                            amount as (Select (((isnull(TotalHarga,0)-isnull(Potongan,0))-isnull(PPhPotong,0))+(isnull(jumlahkarung,0)*isnull(hargasubsidikarung,0)))+isnull(cashbackpph,0) as amount,cast(TglTerima as date) as fdate
                                                                                            from vwTMBGKelapaHdr2021  AS A LEFT outer JOIN countkelapa As B On A.TextMessage =B.TextMessage   LEFT outer JOIN cektimbang  AS C ON A.TransID = 
                                                                                            C.headerID    where 1=1  AND (format(TglTerima,'yyyy-MM') between '" & Format(dtp1.Value, "yyyy-MM") & "' and '" & Format(dtp2.Value, "yyyy-MM") & "') and  A.Bongkar = 'RSUP' AND (Deleted is NULL or Deleted = 0) AND JenisKB ='KC' )

                                                                                            select sum(isnull(a.Amount,0)) as Amount,b.TanggalRange from amount as a right join
                                                                                            TblMstMingguKalender as b on a.fdate between b.TanggalStart and b.TanggalEnd 
                                                                                            where (format(TanggalStart,'yyyy-MM') between '" & Format(dtp1.Value, "yyyy-MM") & "' and '" & Format(dtp2.Value, "yyyy-MM") & "')
                                                                                            group by b.TanggalRange order by RIGHT(LEFT(TanggalRange,8),2),LEFT(TanggalRange,2) asc ")

                i = 0
                If dtKcP2 IsNot Nothing Then
                    For Each row As DataRow In dtKcP2.Rows
                        _Dt.Rows(i)("kcp2") = row("Amount")
                        i += 1
                    Next
                End If
            End If

            'totalkan
            i = 0
            For Each row As DataRow In _Dt.Rows
                If chkP1.Checked = True And chkP2.Checked = True Then
                    _Dt.Rows(i)("total") = _Dt.Rows(i)("kblicinp1") + _Dt.Rows(i)("kblicinp2") + _Dt.Rows(i)("kbjambulp1") + _Dt.Rows(i)("kbjambulp2") + _Dt.Rows(i)("kcp1") + _Dt.Rows(i)("kcp2")
                ElseIf chkP1.Checked = True Then
                    _Dt.Rows(i)("total") = _Dt.Rows(i)("kblicinp1") + _Dt.Rows(i)("kbjambulp1") + _Dt.Rows(i)("kcp1")
                Else
                    _Dt.Rows(i)("total") = _Dt.Rows(i)("kblicinp2") + _Dt.Rows(i)("kbjambulp2") + _Dt.Rows(i)("kcp2")
                End If

                i += 1
            Next

            If _Dt.Rows.Count = 0 Then
                MsgBox("Tidak Ada Data", vbInformation, AT)
            End If
            Dim DSource = New ReportDataSource(Ds, _Dt)

            If chkP1.Checked = True And chkP2.Checked = True Then
                Me.ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ReportName
                Me.ReportViewer1.LocalReport.DataSources.Add(DSource)
                Me.ReportViewer1.LocalReport.SetParameters(ParamList)
                Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
                Me.ReportViewer1.RefreshReport()
            Else
                Me.ReportViewer2.LocalReport.DataSources.Clear()
                Me.ReportViewer2.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ReportName
                Me.ReportViewer2.LocalReport.DataSources.Add(DSource)
                Me.ReportViewer2.LocalReport.SetParameters(ParamList)
                Me.ReportViewer2.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
                Me.ReportViewer2.RefreshReport()
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Arrow
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        If chkP1.Checked = False And chkP2.Checked = False Then
            MsgBox("Pabrik Belum Di Pilih !", vbExclamation, AT)
            Exit Sub
        End If
        ReportViewer1.Refresh()
        ReportViewer2.Refresh()
        Call createReport()
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Dim filename As String
        Me.SaveFileDialog.ShowDialog()
        filename = SaveFileDialog.FileName
        Me.fg.SaveExcel(filename & ".xlsx", "Sheet1", FileFlags.IncludeFixedCells)
    End Sub

    Private Sub btnMonitoring_Click(sender As Object, e As EventArgs) Handles btnMonitoring.Click
        With fg
            Me.Cursor = Cursors.WaitCursor

            Dim i As Integer = 2
            .Rows.Count = 2

            ReportViewer1.Visible = False
            ReportViewer2.Visible = False
            fg.Visible = True

            ' membuat susunan minggu nya dari master kalender
            Dim dt As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " SELECT *,
                                                                                case when MONTH(TanggalStart)='01' then 'Jan'
                                                                                when MONTH(TanggalStart)='02' then 'Feb'
                                                                                when MONTH(TanggalStart)='03' then 'Mar'
                                                                                when MONTH(TanggalStart)='04' then 'Apr'
                                                                                when MONTH(TanggalStart)='05' then 'Mei'
                                                                                when MONTH(TanggalStart)='06' then 'Jun'
                                                                                when MONTH(TanggalStart)='07' then 'Jul'
                                                                                when MONTH(TanggalStart)='08' then 'Agust'
                                                                                when MONTH(TanggalStart)='09' then 'Sep'
                                                                                when MONTH(TanggalStart)='10' then 'Okt'
                                                                                when MONTH(TanggalStart)='11' then 'Nov'
                                                                                else 'Des' end as Bulan
                                                                                FROM RMPApp..TblMstMingguKalender where year(TanggalStart)='2024' order by TanggalStart ")

            If dt IsNot Nothing Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, 0) = row("Minggu")
                    .Item(i, 1) = row("TanggalRange")
                    .Item(i, 13) = row("Bulan")

                    i += 1
                Next

                .AutoSizeCols()
            End If

            'masukan data kb licin p1
            i = 2
            Dim dtKbLicinP1 As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " WITH countkelapa as ( Select ISNULL(count(TransID), 0) As Countt,TextMessage FROM [RMPApp].[dbo].[TblTrnKelapaHdr] as a left outer join RSUPAccounting..tblRMTrnPenerimaanPancangDtl as b on a.NoNota=b.NoNota 
                                                                                        WHERE Deleted = 0 And 1=1  AND  year(b.CreatedDate)='" & Format(dtpMonitor.Value, "yyyy") & "' And (Deleted Is NULL Or Deleted = 0)   AND JenisKB ='KB-A' GROUP BY  TextMessage 
                                                                                        having count(TextMessage) > 1),

                                                                                        cektimbang As (Select DISTINCT headerID  FROM [RMPApp].[dbo].[TblTrnKelapaDtlWireless]),

                                                                                        amount as (Select (((isnull(TotalHarga,0)-isnull(Potongan,0))-isnull(PPhPotong,0))+(isnull(jumlahkarung,0)*isnull(hargasubsidikarung,0)))+isnull(cashbackpph,0) as amount,cast(TglTerima as date) as fdate
                                                                                        from vwTMBGKelapaHdr2021  AS A LEFT outer JOIN countkelapa As B On A.TextMessage =B.TextMessage   LEFT outer JOIN cektimbang  AS C ON A.TransID = 
                                                                                        C.headerID    where 1=1  AND year(TglTerima)='" & Format(dtpMonitor.Value, "yyyy") & "' and  A.Bongkar = 'PSG' AND (Deleted is NULL or Deleted = 0) AND JenisKB ='KB-A' and Jenis='Licin' )

                                                                                        select sum(isnull(a.Amount,0)) as Amount,b.TanggalRange from amount as a right join
                                                                                        TblMstMingguKalender as b on a.fdate between b.TanggalStart and b.TanggalEnd 
                                                                                        group by b.TanggalRange order by RIGHT(LEFT(TanggalRange,8),2),LEFT(TanggalRange,2) asc ")

            If dtKbLicinP1 IsNot Nothing Then
                For Each row As DataRow In dtKbLicinP1.Rows
                    If .Item(i, 1) = row("TanggalRange") Then
                        .Item(i, 2) = row("Amount")
                    End If

                    i += 1
                Next

                .AutoSizeCols()
            End If

            'masukan data kb licin p2 
            i = 2
            Dim dtKbLicinP2 As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " WITH countkelapa as ( Select ISNULL(count(TransID), 0) As Countt,TextMessage FROM [RMPApp].[dbo].[TblTrnKelapaHdr] as a left outer join RSUPAccounting..tblRMTrnPenerimaanPancangDtl as b on a.NoNota=b.NoNota 
                                                                                        WHERE Deleted = 0 And 1=1  AND  year(b.CreatedDate)='" & Format(dtpMonitor.Value, "yyyy") & "' And (Deleted Is NULL Or Deleted = 0)   AND JenisKB ='KB-A' GROUP BY  TextMessage 
                                                                                        having count(TextMessage) > 1),

                                                                                        cektimbang As (Select DISTINCT headerID  FROM [RMPApp].[dbo].[TblTrnKelapaDtlWireless]),

                                                                                        amount as (Select (((isnull(TotalHarga,0)-isnull(Potongan,0))-isnull(PPhPotong,0))+(isnull(jumlahkarung,0)*isnull(hargasubsidikarung,0)))+isnull(cashbackpph,0) as amount,cast(TglTerima as date) as fdate
                                                                                        from vwTMBGKelapaHdr2021  AS A LEFT outer JOIN countkelapa As B On A.TextMessage =B.TextMessage   LEFT outer JOIN cektimbang  AS C ON A.TransID = 
                                                                                        C.headerID    where 1=1  AND year(TglTerima)='" & Format(dtpMonitor.Value, "yyyy") & "' and  A.Bongkar = 'RSUP' AND (Deleted is NULL or Deleted = 0) AND JenisKB ='KB-A' and Jenis='Licin' )

                                                                                        select sum(isnull(a.Amount,0)) as Amount,b.TanggalRange from amount as a right join
                                                                                        TblMstMingguKalender as b on a.fdate between b.TanggalStart and b.TanggalEnd 
                                                                                        group by b.TanggalRange order by RIGHT(LEFT(TanggalRange,8),2),LEFT(TanggalRange,2) asc ")

            If dtKbLicinP2 IsNot Nothing Then
                For Each row As DataRow In dtKbLicinP2.Rows
                    If .Item(i, 1) = row("TanggalRange") Then
                        .Item(i, 3) = row("Amount")
                    End If

                    i += 1
                Next

                .AutoSizeCols()
            End If

            'masukan data kb Jambul p1
            i = 2
            Dim dtKbJambulP1 As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " WITH countkelapa as ( Select ISNULL(count(TransID), 0) As Countt,TextMessage FROM [RMPApp].[dbo].[TblTrnKelapaHdr] as a left outer join RSUPAccounting..tblRMTrnPenerimaanPancangDtl as b on a.NoNota=b.NoNota 
                                                                                            WHERE Deleted = 0 And 1=1  AND  year(b.CreatedDate)='" & Format(dtpMonitor.Value, "yyyy") & "' And (Deleted Is NULL Or Deleted = 0)   AND JenisKB ='KB-A' GROUP BY  TextMessage 
                                                                                            having count(TextMessage) > 1),

                                                                                            cektimbang As (Select DISTINCT headerID  FROM [RMPApp].[dbo].[TblTrnKelapaDtlWireless]),

                                                                                            amount as (Select (((isnull(TotalHarga,0)-isnull(Potongan,0))-isnull(PPhPotong,0))+(isnull(jumlahkarung,0)*isnull(hargasubsidikarung,0)))+isnull(cashbackpph,0) as amount,cast(TglTerima as date) as fdate
                                                                                            from vwTMBGKelapaHdr2021  AS A LEFT outer JOIN countkelapa As B On A.TextMessage =B.TextMessage   LEFT outer JOIN cektimbang  AS C ON A.TransID = 
                                                                                            C.headerID    where 1=1  AND year(TglTerima)='" & Format(dtpMonitor.Value, "yyyy") & "' and  A.Bongkar = 'PSG' AND (Deleted is NULL or Deleted = 0) AND JenisKB ='KB-A' and Jenis='Jambul' )

                                                                                            select sum(isnull(a.Amount,0)) as Amount,b.TanggalRange from amount as a right join
                                                                                            TblMstMingguKalender as b on a.fdate between b.TanggalStart and b.TanggalEnd 
                                                                                            group by b.TanggalRange order by RIGHT(LEFT(TanggalRange,8),2),LEFT(TanggalRange,2) asc ")

            If dtKbJambulP1 IsNot Nothing Then
                For Each row As DataRow In dtKbJambulP1.Rows
                    If .Item(i, 1) = row("TanggalRange") Then
                        .Item(i, 4) = row("Amount")
                    End If

                    i += 1
                Next

                .AutoSizeCols()
            End If

            'masukan data kb Jambul p2 
            i = 2
            Dim dtKbjambulP2 As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " WITH countkelapa as ( Select ISNULL(count(TransID), 0) As Countt,TextMessage FROM [RMPApp].[dbo].[TblTrnKelapaHdr] as a left outer join RSUPAccounting..tblRMTrnPenerimaanPancangDtl as b on a.NoNota=b.NoNota 
                                                                                            WHERE Deleted = 0 And 1=1  AND  year(b.CreatedDate)='" & Format(dtpMonitor.Value, "yyyy") & "' And (Deleted Is NULL Or Deleted = 0)   AND JenisKB ='KB-A' GROUP BY  TextMessage 
                                                                                            having count(TextMessage) > 1),

                                                                                            cektimbang As (Select DISTINCT headerID  FROM [RMPApp].[dbo].[TblTrnKelapaDtlWireless]),

                                                                                            amount as (Select (((isnull(TotalHarga,0)-isnull(Potongan,0))-isnull(PPhPotong,0))+(isnull(jumlahkarung,0)*isnull(hargasubsidikarung,0)))+isnull(cashbackpph,0) as amount,cast(TglTerima as date) as fdate
                                                                                            from vwTMBGKelapaHdr2021  AS A LEFT outer JOIN countkelapa As B On A.TextMessage =B.TextMessage   LEFT outer JOIN cektimbang  AS C ON A.TransID = 
                                                                                            C.headerID    where 1=1  AND year(TglTerima)='" & Format(dtpMonitor.Value, "yyyy") & "' and  A.Bongkar = 'RSUP' AND (Deleted is NULL or Deleted = 0) AND JenisKB ='KB-A' and Jenis='Jambul' )

                                                                                            select sum(isnull(a.Amount,0)) as Amount,b.TanggalRange from amount as a right join
                                                                                            TblMstMingguKalender as b on a.fdate between b.TanggalStart and b.TanggalEnd 
                                                                                            group by b.TanggalRange order by RIGHT(LEFT(TanggalRange,8),2),LEFT(TanggalRange,2) asc ")

            If dtKbjambulP2 IsNot Nothing Then
                For Each row As DataRow In dtKbjambulP2.Rows
                    If .Item(i, 1) = row("TanggalRange") Then
                        .Item(i, 5) = row("Amount")
                    End If

                    i += 1
                Next

                .AutoSizeCols()
            End If

            'masukan data kc p1
            i = 2
            Dim dtKcP1 As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " WITH countkelapa as ( Select ISNULL(count(TransID), 0) As Countt,TextMessage FROM [RMPApp].[dbo].[TblTrnKelapaHdr] as a left outer join RSUPAccounting..tblRMTrnPenerimaanPancangDtl as b on a.NoNota=b.NoNota 
                                                                                            WHERE Deleted = 0 And 1=1  AND  year(b.CreatedDate)='" & Format(dtpMonitor.Value, "yyyy") & "' And (Deleted Is NULL Or Deleted = 0)   AND JenisKB ='KC' GROUP BY  TextMessage 
                                                                                            having count(TextMessage) > 1),

                                                                                            cektimbang As (Select DISTINCT headerID  FROM [RMPApp].[dbo].[TblTrnKelapaDtlWireless]),

                                                                                            amount as (Select (((isnull(TotalHarga,0)-isnull(Potongan,0))-isnull(PPhPotong,0))+(isnull(jumlahkarung,0)*isnull(hargasubsidikarung,0)))+isnull(cashbackpph,0) as amount,cast(TglTerima as date) as fdate
                                                                                            from vwTMBGKelapaHdr2021  AS A LEFT outer JOIN countkelapa As B On A.TextMessage =B.TextMessage   LEFT outer JOIN cektimbang  AS C ON A.TransID = 
                                                                                            C.headerID    where 1=1  AND year(TglTerima)='" & Format(dtpMonitor.Value, "yyyy") & "' and  A.Bongkar = 'PSG' AND (Deleted is NULL or Deleted = 0) AND JenisKB ='KC' )

                                                                                            select sum(isnull(a.Amount,0)) as Amount,b.TanggalRange from amount as a right join
                                                                                            TblMstMingguKalender as b on a.fdate between b.TanggalStart and b.TanggalEnd 
                                                                                            group by b.TanggalRange order by RIGHT(LEFT(TanggalRange,8),2),LEFT(TanggalRange,2) asc ")

            If dtKcP1 IsNot Nothing Then
                For Each row As DataRow In dtKcP1.Rows
                    If .Item(i, 1) = row("TanggalRange") Then
                        .Item(i, 6) = row("Amount")
                    End If

                    i += 1
                Next

                .AutoSizeCols()
            End If

            'masukan data kc p2 
            i = 2
            Dim dtKcP2 As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " WITH countkelapa as ( Select ISNULL(count(TransID), 0) As Countt,TextMessage FROM [RMPApp].[dbo].[TblTrnKelapaHdr] as a left outer join RSUPAccounting..tblRMTrnPenerimaanPancangDtl as b on a.NoNota=b.NoNota 
                                                                                            WHERE Deleted = 0 And 1=1  AND  year(b.CreatedDate)='" & Format(dtpMonitor.Value, "yyyy") & "' And (Deleted Is NULL Or Deleted = 0)   AND JenisKB ='KC' GROUP BY  TextMessage 
                                                                                            having count(TextMessage) > 1),

                                                                                            cektimbang As (Select DISTINCT headerID  FROM [RMPApp].[dbo].[TblTrnKelapaDtlWireless]),

                                                                                            amount as (Select (((isnull(TotalHarga,0)-isnull(Potongan,0))-isnull(PPhPotong,0))+(isnull(jumlahkarung,0)*isnull(hargasubsidikarung,0)))+isnull(cashbackpph,0) as amount,cast(TglTerima as date) as fdate
                                                                                            from vwTMBGKelapaHdr2021  AS A LEFT outer JOIN countkelapa As B On A.TextMessage =B.TextMessage   LEFT outer JOIN cektimbang  AS C ON A.TransID = 
                                                                                            C.headerID    where 1=1  AND year(TglTerima)='" & Format(dtpMonitor.Value, "yyyy") & "' and  A.Bongkar = 'RSUP' AND (Deleted is NULL or Deleted = 0) AND JenisKB ='KC' )

                                                                                            select sum(isnull(a.Amount,0)) as Amount,b.TanggalRange from amount as a right join
                                                                                            TblMstMingguKalender as b on a.fdate between b.TanggalStart and b.TanggalEnd 
                                                                                            group by b.TanggalRange order by RIGHT(LEFT(TanggalRange,8),2),LEFT(TanggalRange,2) asc ")

            If dtKcP2 IsNot Nothing Then
                For Each row As DataRow In dtKcP2.Rows
                    If .Item(i, 1) = row("TanggalRange") Then
                        .Item(i, 7) = row("Amount")
                    End If

                    i += 1
                Next

                .AutoSizeCols()
            End If

            'masukan data ubm p1
            i = 2
            Dim dtUbmP1 As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " with amount as ( select sum(cast(Amount as decimal(18,0))) as Amount,fdate from [RMPApp].[dbo].[vwRMRekapUBMP1] where format(cast(fdate as date),'yyyy')='" & Format(dtpMonitor.Value, "yyyy") & "' group by fdate )
                                                                                        select sum(isnull(a.Amount,0)) as Amount,b.TanggalRange from amount as a right join
                                                                                        TblMstMingguKalender as b on a.fdate between b.TanggalStart and b.TanggalEnd 
                                                                                        group by b.TanggalRange order by RIGHT(LEFT(TanggalRange,8),2),LEFT(TanggalRange,2) asc ")

            If dtUbmP1 IsNot Nothing Then
                For Each row As DataRow In dtUbmP1.Rows
                    If .Item(i, 1) = row("TanggalRange") Then
                        .Item(i, 8) = row("Amount")
                    End If

                    i += 1
                Next

                .AutoSizeCols()
            End If

            'masukan data ubm p2
            i = 2
            Dim dtUbmP2 As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " with amount as ( select sum(cast(Amount as decimal(18,0))) as Amount,fdate from [RSUPAccounting].[dbo].[vwRMRekapUBM] where format(cast(fdate as date),'yyyy')='" & Format(dtpMonitor.Value, "yyyy") & "' group by fdate)
                                                                                        select sum(isnull(a.Amount,0)) as Amount,b.TanggalRange from amount as a right join
                                                                                        TblMstMingguKalender as b on a.fdate between b.TanggalStart and b.TanggalEnd 
                                                                                        group by b.TanggalRange order by RIGHT(LEFT(TanggalRange,8),2),LEFT(TanggalRange,2) asc ")

            If dtUbmP2 IsNot Nothing Then
                For Each row As DataRow In dtUbmP2.Rows
                    If .Item(i, 1) = row("TanggalRange") Then
                        .Item(i, 9) = row("Amount")
                    End If

                    i += 1
                Next

                .AutoSizeCols()
            End If

            'masukan data ub p1
            i = 2
            Dim dtUbP1 As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " with amount as ( select sum(cast(Amount as decimal(18,0))) as Amount,fdate from [RMPApp].[dbo].[vwRMRekapUBP1] where format(cast(fdate as date),'yyyy')='" & Format(dtpMonitor.Value, "yyyy") & "' group by fdate )
                                                                                        select sum(isnull(a.Amount,0)) as Amount,b.TanggalRange from amount as a right join
                                                                                        TblMstMingguKalender as b on a.fdate between b.TanggalStart and b.TanggalEnd 
                                                                                        group by b.TanggalRange order by RIGHT(LEFT(TanggalRange,8),2),LEFT(TanggalRange,2) asc ")

            If dtUbP1 IsNot Nothing Then
                For Each row As DataRow In dtUbP1.Rows
                    If .Item(i, 1) = row("TanggalRange") Then
                        .Item(i, 10) = row("Amount")
                    End If

                    i += 1
                Next

                .AutoSizeCols()
            End If

            'masukan data ub p2
            i = 2
            Dim dtUbP2 As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " with amount as ( select sum(cast(Amount as decimal(18,0))) as Amount,fdate from [RSUPAccounting].[dbo].[vwRMRekapUB] where format(cast(fdate as date),'yyyy')='" & Format(dtpMonitor.Value, "yyyy") & "' group by fdate)
                                                                                        select sum(isnull(a.Amount,0)) as Amount,b.TanggalRange from amount as a right join
                                                                                        TblMstMingguKalender as b on a.fdate between b.TanggalStart and b.TanggalEnd 
                                                                                        group by b.TanggalRange order by RIGHT(LEFT(TanggalRange,8),2),LEFT(TanggalRange,2) asc  ")

            If dtUbP2 IsNot Nothing Then
                For Each row As DataRow In dtUbP2.Rows
                    If .Item(i, 1) = row("TanggalRange") Then
                        .Item(i, 11) = row("Amount")
                    End If

                    i += 1
                Next

                .AutoSizeCols()
            End If

            'totalkan ke bawah
            Dim totKbLicinP1, totKbLicinP2, totKbJambulP1, totKbJambulP2, totKcP1, totKcP2, totUbmP1, totUbmP2, totUbP1, totUbP2, totAkhir As Decimal
            For j = 2 To .Rows.Count - 1
                totKbLicinP1 += .Item(j, 2)
                totKbLicinP2 += .Item(j, 3)
                totKbJambulP1 += .Item(j, 4)
                totKbJambulP2 += .Item(j, 5)
                totKcP1 += .Item(j, 6)
                totKcP2 += .Item(j, 7)
                totUbmP1 += .Item(j, 8)
                totUbmP2 += .Item(j, 9)
                totUbP1 += .Item(j, 10)
                totUbP2 += .Item(j, 11)
            Next

            .AddItem(1)
            Dim rowAkhir As Integer = fg.Rows.Count - 1
            .Item(rowAkhir, 0) = "Total"
            .Item(rowAkhir, 2) = totKbLicinP1
            .Item(rowAkhir, 3) = totKbLicinP2
            .Item(rowAkhir, 4) = totKbJambulP1
            .Item(rowAkhir, 5) = totKbJambulP2
            .Item(rowAkhir, 6) = totKcP1
            .Item(rowAkhir, 7) = totKcP2
            .Item(rowAkhir, 8) = totUbmP1
            .Item(rowAkhir, 9) = totUbmP2
            .Item(rowAkhir, 10) = totUbP1
            .Item(rowAkhir, 11) = totUbP2

            'totalkan ke samping
            For k = 2 To .Rows.Count - 1
                .Item(k, 12) = .Item(k, 2) + .Item(k, 3) + .Item(k, 4) + .Item(k, 5) + .Item(k, 6) + .Item(k, 7) + .Item(k, 8) + .Item(k, 9) + .Item(k, 10) + .Item(k, 11)
            Next

            'sum perbulan
            For j = .Rows.Count - 1 To 3 Step -1
                If j = .Rows.Count - 1 Then
                    .Rows.Insert(.Rows.Count - 1)
                    .Item(j, 0) = .Item(j - 1, 13)
                Else
                    If .Item(j, 13) <> .Item(j - 1, 13) Then
                        .Rows.Insert(j)
                        .Item(j, 0) = .Item(j - 1, 13)
                    End If
                End If
            Next

            totKbLicinP1 = 0
            totKbLicinP2 = 0
            totKbJambulP1 = 0
            totKbJambulP2 = 0
            totKcP1 = 0
            totKcP2 = 0
            totUbmP1 = 0
            totUbmP2 = 0
            totUbP1 = 0
            totUbP2 = 0
            totAkhir = 0
            For j = 2 To .Rows.Count - 2
                If .Item(j, 1) = "" Then
                    .Item(j, 2) = totKbLicinP1
                    .Item(j, 3) = totKbLicinP2
                    .Item(j, 4) = totKbJambulP1
                    .Item(j, 5) = totKbJambulP2
                    .Item(j, 6) = totKcP1
                    .Item(j, 7) = totKcP2
                    .Item(j, 8) = totUbmP1
                    .Item(j, 9) = totUbmP2
                    .Item(j, 10) = totUbP1
                    .Item(j, 11) = totUbP2
                    .Item(j, 12) = totAkhir

                    totKbLicinP1 = 0
                    totKbLicinP2 = 0
                    totKbJambulP1 = 0
                    totKbJambulP2 = 0
                    totKcP1 = 0
                    totKcP2 = 0
                    totUbmP1 = 0
                    totUbmP2 = 0
                    totUbP1 = 0
                    totUbP2 = 0
                    totAkhir = 0

                    .Rows(j).StyleNew.BackColor = Color.FromArgb(192, 255, 192)
                    .Rows(j).StyleNew.ForeColor = Color.Black
                Else
                    totKbLicinP1 += .Item(j, 2)
                    totKbLicinP2 += .Item(j, 3)
                    totKbJambulP1 += .Item(j, 4)
                    totKbJambulP2 += .Item(j, 5)
                    totKcP1 += .Item(j, 6)
                    totKcP2 += .Item(j, 7)
                    totUbmP1 += .Item(j, 8)
                    totUbmP2 += .Item(j, 9)
                    totUbP1 += .Item(j, 10)
                    totUbP2 += .Item(j, 11)
                    totAkhir += .Item(j, 12)
                End If
            Next

            .Rows(.Rows.Count - 1).StyleNew.BackColor = Color.FromArgb(209, 229, 252)
            .Rows(.Rows.Count - 1).StyleNew.ForeColor = Color.Black

            .AutoSizeCols()
        End With
        Me.Cursor = Cursors.Default
    End Sub
End Class