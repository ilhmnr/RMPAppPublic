
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports C1.Win
Imports C1.Win.C1FlexGrid
Imports Excel = Microsoft.Office.Interop.Excel

Public Class FrmMonLoyaltyCashBackRelasiNew

    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub FrmMonLoyaltyCashBackRelasi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HeaderFG()
        schKg()
        Modul_RMP.Combo.SetSupplier(cmbS_Petani)
        txtharga.Text = rppoin()
    End Sub
    Public Function rppoin() As Double

        Dim dt As DataTable = New DataTable()
        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select top(1) harga  as  rppoin from RMPAPP..tbl_Mst_HargaPoint  where  cast(Tanggal as date)<=cast(getdate() as date) order by Tanggal desc")
        If IsDBNull(dt.Rows(0).Item("rppoin")) Then
            rppoin = 0
        Else
            rppoin = dt.Rows(0).Item("rppoin")
        End If
        Return rppoin

    End Function

    Public Sub HeaderFG()
        Dim txt As CellRange
        With fg
            .Font = New System.Drawing.Font("Century Gothic", 9.0!)
            .Styles.Fixed.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
            .Cols.Count = 21
            .Cols.Fixed = 0

            .Styles.Fixed.BackColor = Color.FromArgb(93, 141, 213)
            .Styles.Fixed.ForeColor = Color.White
            '.Styles.Alternate.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
            .Rows(1).StyleFixedNew.BackColor = Color.FromArgb(250, 191, 143)

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 2
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Rows(1).AllowMerging = True
            fg.Cols.Frozen = 5
        End With

        With fg1
            .Font = New System.Drawing.Font("Century Gothic", 9.0!)
            .Styles.Fixed.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
            .Cols.Count = 19
            .Cols.Fixed = 0

            .Styles.Fixed.BackColor = Color.FromArgb(93, 141, 213)
            .Styles.Fixed.ForeColor = Color.White
            .Styles.Alternate.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
            .Rows(1).StyleFixedNew.BackColor = Color.FromArgb(250, 191, 143)
            .Rows(1).StyleFixedNew.BackColor = Color.SteelBlue

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 2
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Rows(1).AllowMerging = True
            fg.Cols.Frozen = 5
        End With

        CELL2()
        CELL21()
    End Sub

    Private Sub CELL2()
        Dim txt As CellRange
        With fg
            txt = .GetCellRange(0, 0, 1, 0) : txt.Data = "NO" : .Cols(0).Name = "NO" : .Cols(0).TextAlign = TextAlignEnum.LeftCenter : .Cols(0).AllowMerging = True : .Cols(0).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 1, 1, 1) : txt.Data = "GROUPKK" : .Cols(1).Name = "KodeSupUM" : .Cols(1).TextAlign = TextAlignEnum.LeftCenter : .Cols(1).AllowMerging = True : .Cols(1).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(1).Visible = False
            txt = .GetCellRange(0, 2, 1, 2) : txt.Data = "NAMA KK" : .Cols(2).Width = 50 : .Cols(2).Name = "NamaSupUM" : .Cols(2).AllowMerging = True : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(2).Visible = False
            txt = .GetCellRange(0, 3, 1, 3) : txt.Data = "ID PETANI" : .Cols(3).Name = "IDSubPetani" : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).AllowMerging = True : .Cols(3).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 4, 1, 4) : txt.Data = "NAMA PEMILIK KELAPA / SUBPETANI" : .Cols(4).Name = "SubPetani" : .Cols(4).AllowMerging = True : .Cols(4).TextAlign = TextAlignEnum.LeftCenter

            txt = .GetCellRange(0, 5, 1, 5) : txt.Data = "KLASIFIKASI" : .Cols(5).Name = "KLASIFIKASI" : .Cols(5).AllowMerging = True : .Cols(5).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 6, 1, 6) : txt.Data = "NETTO (Kg)" : .Cols(6).Name = "Netto" : .Cols(6).TextAlign = TextAlignEnum.RightCenter : .Cols(6).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(6).AllowMerging = True : .Cols(6).Format = "#,###0" : .Cols(6).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 7, 1, 7) : txt.Data = "POIN" : .Cols(7).Name = "POINT" : .Cols(7).TextAlign = TextAlignEnum.RightCenter : .Cols(7).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(7).AllowMerging = True : .Cols(7).Format = "#,###0" : .Cols(7).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 8, 0, 10) : txt.Data = "TAMBAHAN POIN" : .Cols(8).AllowMerging = True
            txt = .GetCellRange(1, 8, 1, 8) : txt.Data = "POINREK" : .Cols(8).Name = "POINTREK" : .Cols(8).AllowMerging = True : .Cols(8).Format = "#,###0" : .Cols(8).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(8).TextAlign = TextAlignEnum.RightCenter : .Cols(8).Visible = False
            txt = .GetCellRange(1, 9, 1, 9) : txt.Data = "POINKUALITAS" : .Cols(9).Name = "POINTKUALITAS" : .Cols(9).TextAlign = TextAlignEnum.RightCenter : .Cols(9).AllowMerging = True : .Cols(9).Format = "#,###0" : .Cols(9).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(9).Visible = False
            txt = .GetCellRange(1, 10, 1, 10) : txt.Data = "POINLICIN" : .Cols(10).Name = "POINTLICIN" : .Cols(10).TextAlign = TextAlignEnum.RightCenter : .Cols(10).AllowMerging = True : .Cols(10).Format = "#,###0" : .Cols(10).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(10).Visible = False
            txt = .GetCellRange(0, 11, 0, 12) : txt.Data = "TOTAL POIN" : .Cols(11).AllowMerging = True

            txt = .GetCellRange(1, 11, 1, 11) : txt.Data = "POIN" : .Cols(11).Name = "TOTALPOINT" : .Cols(11).AllowMerging = True : .Cols(11).Format = "#,###0" : .Cols(11).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(11).TextAlign = TextAlignEnum.RightCenter
            txt = .GetCellRange(1, 12, 1, 12) : txt.Data = "RUPIAH" : .Cols(12).Name = "RPTOTALPOINT" : .Cols(12).TextAlign = TextAlignEnum.RightCenter : .Cols(12).AllowMerging = True : .Cols(12).Format = "#,###0" : .Cols(12).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 13, 0, 14) : txt.Data = "TOTAL POIN KLAIM" : .Cols(13).TextAlign = TextAlignEnum.CenterCenter : .Cols(13).AllowMerging = True : .Cols(13).Format = "#,###0"
            txt = .GetCellRange(1, 13, 1, 13) : txt.Data = "POIN" : .Cols(13).Name = "TOTALPOINTKLAIM" : .Cols(13).TextAlign = TextAlignEnum.RightCenter : .Cols(13).AllowMerging = True : .Cols(13).Format = "#,###0" : .Cols(13).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 14, 1, 14) : txt.Data = "RUPIAH" : .Cols(14).Name = "RPTOTALPOINTKLAIM" : .Cols(14).TextAlign = TextAlignEnum.RightCenter : .Cols(14).AllowMerging = True : .Cols(14).Format = "#,###0" : .Cols(14).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 15, 0, 16) : txt.Data = "SISA POIN" : .Cols(15).TextAlign = TextAlignEnum.CenterCenter : .Cols(15).AllowMerging = True
            txt = .GetCellRange(1, 15, 1, 15) : txt.Data = "POIN" : .Cols(15).Name = "SISAPOINT" : .Cols(15).TextAlign = TextAlignEnum.RightCenter : .Cols(15).AllowMerging = True : .Cols(15).Format = "#,###0" : .Cols(15).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 16, 1, 16) : txt.Data = "RUPIAH" : .Cols(16).Name = "RPSISAPOINT" : .Cols(16).TextAlign = TextAlignEnum.RightCenter : .Cols(16).AllowMerging = True : .Cols(16).Format = "#,###0" : .Cols(16).TextAlignFixed = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 17, 0, 18) : txt.Data = "POIN (EXPIRED)" : .Cols(17).TextAlign = TextAlignEnum.CenterCenter : .Cols(17).AllowMerging = True
            txt = .GetCellRange(1, 17, 1, 17) : txt.Data = "POIN" : .Cols(17).Name = "pointexp" : .Cols(17).TextAlign = TextAlignEnum.RightCenter : .Cols(17).AllowMerging = True : .Cols(17).Format = "#,###0" : .Cols(17).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 18, 1, 18) : txt.Data = "RUPIAH" : .Cols(18).Name = "RPpointexp" : .Cols(18).TextAlign = TextAlignEnum.RightCenter : .Cols(18).AllowMerging = True : .Cols(18).Format = "#,###0" : .Cols(18).TextAlignFixed = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 19, 1, 19) : txt.Data = "DETAIL POINT" : .Cols(19).Name = "DETAILPOINT" : .Cols(19).AllowMerging = True : .Cols(19).Width = 30 : .Cols(19).ImageAlign = TextAlignEnum.CenterCenter : .Cols(19).ImageAndText = TextAlignEnum.CenterCenter : .Cols(19).DataType = System.Type.[GetType]("System.Drawing.Bitmap")
            txt = .GetCellRange(0, 20, 1, 20) : txt.Data = "DETAIL KLAIM" : .Cols(20).Name = "DETAILKLAIM" : .Cols(20).AllowMerging = True : .Cols(18).Width = 30 : .Cols(20).ImageAlign = TextAlignEnum.CenterCenter : .Cols(20).ImageAndText = TextAlignEnum.CenterCenter : .Cols(20).DataType = System.Type.[GetType]("System.Drawing.Bitmap")
            .AutoSizeCols()
        End With

    End Sub


    Private Sub CELL21()
        Dim txt As CellRange
        With fg1

            txt = .GetCellRange(0, 0, 1, 0) : txt.Data = "NO" : .Cols(0).Name = "NO" : .Cols(0).TextAlign = TextAlignEnum.LeftCenter : .Cols(0).AllowMerging = True : .Cols(0).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 1, 1, 1) : txt.Data = "GROUPKK" : .Cols(1).Name = "KodeSupUM" : .Cols(1).TextAlign = TextAlignEnum.LeftCenter : .Cols(1).AllowMerging = True : .Cols(1).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 2, 1, 2) : txt.Data = "NAMA KK" : .Cols(2).Width = 50 : .Cols(2).Name = "NamaSupUM" : .Cols(2).AllowMerging = True : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 3, 1, 3) : txt.Data = "ID PETANI" : .Cols(3).Name = "IDSubPetani" : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).AllowMerging = True : .Cols(3).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 4, 1, 4) : txt.Data = "NAMA PEMILIK KELAPA / SUBPETANI" : .Cols(4).Name = "SubPetani" : .Cols(4).AllowMerging = True : .Cols(4).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 5, 1, 5) : txt.Data = "KLASIFIKASI" : .Cols(5).Name = "KLASIFIKASI" : .Cols(5).AllowMerging = True : .Cols(5).TextAlign = TextAlignEnum.LeftCenter

            txt = .GetCellRange(0, 6, 1, 6) : txt.Data = "NETTO (Kg)" : .Cols(6).Name = "Netto" : .Cols(6).TextAlign = TextAlignEnum.RightCenter : .Cols(6).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(6).AllowMerging = True : .Cols(6).Format = "#,###0" : .Cols(6).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 7, 1, 7) : txt.Data = "POIN" : .Cols(7).Name = "POINT" : .Cols(7).TextAlign = TextAlignEnum.RightCenter : .Cols(7).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(7).AllowMerging = True : .Cols(7).Format = "#,###0" : .Cols(7).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 8, 0, 10) : txt.Data = "TAMBAHAN POIN" : .Cols(8).AllowMerging = True
            txt = .GetCellRange(1, 8, 1, 8) : txt.Data = "POINREK" : .Cols(8).Name = "POINTREK" : .Cols(8).AllowMerging = True : .Cols(8).Format = "#,###0" : .Cols(8).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(8).TextAlign = TextAlignEnum.RightCenter : .Cols(8).Visible = False
            txt = .GetCellRange(1, 9, 1, 9) : txt.Data = "POINKUALITAS" : .Cols(9).Name = "POINTKUALITAS" : .Cols(9).TextAlign = TextAlignEnum.RightCenter : .Cols(9).AllowMerging = True : .Cols(9).Format = "#,###0" : .Cols(9).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(9).Visible = False
            txt = .GetCellRange(1, 10, 1, 10) : txt.Data = "POINLICIN" : .Cols(10).Name = "POINTLICIN" : .Cols(10).TextAlign = TextAlignEnum.RightCenter : .Cols(10).AllowMerging = True : .Cols(10).Format = "#,###0" : .Cols(10).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(10).Visible = False
            txt = .GetCellRange(0, 11, 0, 12) : txt.Data = "TOTAL POIN" : .Cols(11).AllowMerging = True
            txt = .GetCellRange(1, 11, 1, 11) : txt.Data = "POIN" : .Cols(11).Name = "TOTALPOINT" : .Cols(11).AllowMerging = True : .Cols(11).Format = "#,###0" : .Cols(11).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(11).TextAlign = TextAlignEnum.RightCenter
            txt = .GetCellRange(1, 12, 1, 12) : txt.Data = "RUPIAH" : .Cols(12).Name = "RPTOTALPOINT" : .Cols(12).TextAlign = TextAlignEnum.RightCenter : .Cols(12).AllowMerging = True : .Cols(12).Format = "#,###0" : .Cols(12).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 13, 0, 14) : txt.Data = "TOTAL POIN KLAIM" : .Cols(13).TextAlign = TextAlignEnum.CenterCenter : .Cols(13).AllowMerging = True
            txt = .GetCellRange(1, 13, 1, 13) : txt.Data = "POIN" : .Cols(13).Name = "TOTALPOINTKLAIM" : .Cols(13).TextAlign = TextAlignEnum.RightCenter : .Cols(13).AllowMerging = True : .Cols(13).Format = "#,###0" : .Cols(13).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 14, 1, 14) : txt.Data = "RUPIAH" : .Cols(14).Name = "RPTOTALPOINTKLAIM" : .Cols(14).TextAlign = TextAlignEnum.RightCenter : .Cols(14).AllowMerging = True : .Cols(14).Format = "#,###0" : .Cols(14).TextAlignFixed = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 15, 0, 16) : txt.Data = "SISA POIN" : .Cols(17).TextAlign = TextAlignEnum.CenterCenter : .Cols(17).AllowMerging = True
            txt = .GetCellRange(1, 15, 1, 15) : txt.Data = "POIN" : .Cols(15).Name = "SISAPOINT" : .Cols(15).TextAlign = TextAlignEnum.RightCenter : .Cols(15).AllowMerging = True : .Cols(15).Format = "#,###0" : .Cols(15).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 16, 1, 16) : txt.Data = "RUPIAH" : .Cols(16).Name = "RPSISAPOINT" : .Cols(16).TextAlign = TextAlignEnum.RightCenter : .Cols(16).AllowMerging = True : .Cols(16).Format = "#,###0" : .Cols(16).TextAlignFixed = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 17, 0, 18) : txt.Data = "POIN (EXPIRED)"
            txt = .GetCellRange(1, 17, 1, 17) : txt.Data = "POIN" : .Cols(17).Name = "pointexp" : .Cols(17).TextAlign = TextAlignEnum.RightCenter : .Cols(17).AllowMerging = True : .Cols(17).Format = "#,###0" : .Cols(17).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 18, 1, 18) : txt.Data = "RUPIAH" : .Cols(18).Name = "RPpointexp" : .Cols(18).TextAlign = TextAlignEnum.RightCenter : .Cols(18).AllowMerging = True : .Cols(18).Format = "#,###0" : .Cols(18).TextAlignFixed = TextAlignEnum.CenterCenter


            .AutoSizeCols()
        End With
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Call UI.HapusGrid(3, fg)
        Call UI.HapusGrid(3, fg1)
        If chknewrelasi.Checked = True Then
            ShowDatanotloyal()
        Else
            ShowData21()
        End If
    End Sub

    Public Sub ShowData2()
        Cursor = Cursors.WaitCursor
        Application.DoEvents()

        Try
            Dim dt As DataTable = New DataTable()
            Dim i As Integer = 2
            Dim sqlsup As String = ""
            Dim sql, SQL1, SQL2 As String

            If chkS_Petani.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "IDSUBPETANI = '" & cmbS_Petani.SelectedValue.ToString & "'")
            End If

            sql = "	declare @harganow decimal(19,2);
                    select top(1) @harganow= harga from tbl_Mst_HargaPoint where tanggal<=getdate() order by tanggal desc;                 			  
				    with datapopinrelasi as (SELECT   hdr.IDSubPetani, B.NamaSup AS  SubPetani, B.recent_classification_new as recent_classification
					,SUM(A.netto) AS Netto,SUM(A.jumlahpoint) AS Point ,SUM(A.pointrek) as PointRek , sum(A.pointkualitas) as PointKualitas ,sum(A.pointlicin) as PointLicin,
					SUM(A.totalpoint) AS TOTALPOINT, sum(A.totalpoint) * '" & txtharga.Text & "' AS RPTOTALPOINT,
                    0 AS TOTALPOINTKLAIM, 0 AS RPTOTALPOINTKLAIM,0 as harga, 0 AS TotalPointExpired, 0 AS RpTotalPointExpired

                    FROM  TblTrnKelapa_Poin_2023 AS a  INNER JOIN
                    TblTrnKelapaHdr AS hdr on a.nonota=hdr.nonota INNER JOIN  
                    RSUPAccounting..tblRMMstSupplier AS b ON hdr.IDSubPetani = b.KodeSup 
                    WHERE (hdr.Deleted = 0) AND (hdr.IDPancang NOT IN (40, 10, 8))  AND (A.HANGUS=0 OR A.HANGUS IS NULL) AND ( A.HANGUS=0 OR A.HANGUS IS NULL)  
                    GROUP BY hdr.IDSubPetani, B.NamaSup,B.recent_classification_new
                  
				    UNION
                   
				    SELECT A.KODESUP as IDSubPetani, B.NamaSup AS  SubPetani, B.recent_classification_new as recent_classification , 
					0 AS Netto, 0 AS TOTALPOINT, 0 AS RPTOTALPOINT,0 AS Point ,0 as PointRek , 0 as PointKualitas ,0 as PointLicin,
                    SUM(a.bayar_poin) AS TOTALPOINTKLAIM, SUM(a.bayar_rupiah) AS RPTOTALPOINTKLAIM,0 as harga, 0 AS TotalPointExpired, 0 AS RpTotalPointExpired

                    FROM vwtukarpoin2 AS a  INNER JOIN
                    RSUPAccounting..tblRMMstSupplier AS b ON A.KODESUP =b.KodeSup 
                    GROUP BY A.KODESUP, B.NamaSup,B.recent_classification_new

					 UNION
                   
					SELECT   	hdr.IDSubPetani, B.NamaSup AS  SubPetani, B.recent_classification_new as recent_classification
					,0 AS Netto,0 AS Point ,0 as PointRek , 0 as PointKualitas ,0 as PointLicin,
					0 AS TOTALPOINT, 0 AS RPTOTALPOINT,
                    0 AS TOTALPOINTKLAIM, 0 AS RPTOTALPOINTKLAIM,0 as harga, SUM(A.totalpoint)   AS TotalPointExpired, sum(A.totalpoint) * '" & txtharga.Text & "' AS RpTotalPointExpired

                    FROM  TblTrnKelapa_Poin_2023 AS a  INNER JOIN
                    TblTrnKelapaHdr AS hdr on a.nonota=hdr.nonota INNER JOIN  
                    RSUPAccounting..tblRMMstSupplier AS b ON hdr.IDSubPetani = b.KodeSup 
                    WHERE (hdr.Deleted = 0) AND (hdr.IDPancang NOT IN (40, 10, 8))  AND (A.HANGUS=0 OR A.HANGUS IS NULL) AND ( A.HANGUS=0 OR A.HANGUS IS NULL)   and a.expireddate<=getdate()
                    GROUP BY hdr.IDSubPetani, B.NamaSup,B.recent_classification_new
                  )	,dataa as (
                    select  IDSubPetani, SubPetani,recent_classification AS KLASIFIKASI,sum(Netto) as Netto, 
					sum(Point) AS POINT ,SUM(pointrek) as POINTREK , sum(PointKualitas) as POINTKUALITAS ,sum(pointlicin)  as POINTLICIN,				
					sum(TOTALPOINT) as TOTALPOINT,  sum(RPTOTALPOINT) as RPTOTALPOINT,                
					sum(TOTALPOINTKLAIM) as TOTALPOINTKLAIM,  sum(RPTOTALPOINTKLAIM) as RPTOTALPOINTKLAIM ,sum(TotalPointExpired) as TotalPointExpired ,sum( RpTotalPointExpired)  as  RpTotalPointExpired,
			         (select top(1) jumlahpointakum  from TblTrnKelapa_Poin_2023 where IDSUBPETANI= datapopinrelasi.IDSUBPETANI  AND  (HANGUS=0 OR HANGUS IS NULL) AND  (deletedpoin=0 OR deletedpoin IS NULL)    order by transid desc) as sisapoint, (select top(1) TransID from TblTrnKelapa_Poin_2023 where IDSUBPETANI= datapopinrelasi.IDSUBPETANI   AND  (HANGUS=0 OR HANGUS IS NULL) AND  (deletedpoin=0 OR deletedpoin IS NULL)   order by transid desc) transid,'1' as a
                    from datapopinrelasi  WHERE IDSUBPETANI IS NOT NULL     " & IIf(sql = "", "", " AND " & sql) & "
                    group by   IDSubPetani, SubPetani,recent_classification
					UNION
					
					select  IDSubPetani, SubPetani,recent_classification AS KLASIFIKASI,sum(Netto) as Netto, 
					sum(Point) AS POINT ,SUM(pointrek) as POINTREK , sum(PointKualitas) as POINTKUALITAS ,sum(pointlicin)  as POINTLICIN,				
					sum(TOTALPOINT) as TOTALPOINT,  sum(RPTOTALPOINT) as RPTOTALPOINT,                
					sum(TOTALPOINTKLAIM) as TOTALPOINTKLAIM,  sum(RPTOTALPOINTKLAIM) as RPTOTALPOINTKLAIM ,sum(TotalPointExpired) as TotalPointExpired ,sum( RpTotalPointExpired)  as  RpTotalPointExpired,
			      ISNULL(   (select top(1) PoinBeforeClaim-poin  from Android_tblPoinTransaksiItemHdr where KODESUP= datapopinrelasi.IDSUBPETANI  AND (DELETED=0 OR DELETED IS NULL) order by transid desc),0) as sisapoint, ISNULL((select top(1) TransID from Android_tblPoinTransaksiItemHdr where KODESUP= datapopinrelasi.IDSUBPETANI AND (DELETED=0 OR DELETED IS NULL)  order by transid desc),0) transid,'2' as a
                    from datapopinrelasi  WHERE IDSUBPETANI IS NOT NULL      " & IIf(sql = "", "", " AND " & sql) & "
            group by   IDSubPetani, SubPetani,recent_classification  )

                select  DISTINCT IDSubPetani, SubPetani,KLASIFIKASI, Netto, 
					 POINT , POINTREK ,POINTKUALITAS ,POINTLICIN,				
					 TOTALPOINT,  RPTOTALPOINT,                
					 TOTALPOINTKLAIM,  RPTOTALPOINTKLAIM , TotalPointExpired ,  RpTotalPointExpired,
						ISNULL(  (SELECT TOP(1) sisapoint FROM DATAA WHERE IDSUBPETANI=A.IDSUBPETANI  ORDER BY TRANSID DESC ,A DESC),0) AS  sisapoint

                    from dataa AS A ORDER BY IDSubPetani "

            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)
            If dt.Rows.Count > 0 Then
                With fg
                    fg.Rows.Count=2
                    For Each dr As DataRow In dt.Rows
                        .AddItem(i - 1)

                        '.Item(i, "KodeSupUM") = dr!KodeSupUM
                        '.Item(i, "NamaSupUM") = dr!NamaSupUM
                        .Item(i, "IDSubPetani") = dr!IDSubPetani
                        .Item(i, "SubPetani") = dr!SubPetani
                        .Item(i, "Netto") = dr!Netto
                        .Item(i, "KLASIFIKASI") = dr!KLASIFIKASI

                        .Item(i, "POINT") = dr!POINT
                        .Item(i, "POINTREK") = dr!POINTREK
                        .Item(i, "POINTKUALITAS") = dr!POINTKUALITAS
                        .Item(i, "POINTLICIN") = dr!POINTLICIN

                        .Item(i, "TOTALPOINT") = dr!TOTALPOINT
                        .Item(i, "RPTOTALPOINT") = dr!RPTOTALPOINT
                        .Item(i, "TOTALPOINTKLAIM") = dr!TOTALPOINTKLAIM
                        .Item(i, "RPTOTALPOINTKLAIM") = dr!RPTOTALPOINTKLAIM

                        .Item(i, "SISAPOINT") = dr!sisapoint

                        .Item(i, "RPSISAPOINT") = dr!sisapoint * txtharga.Text

                        .Item(i, "pointexp") = dr!TotalPointExpired
                        .Item(i, "RPpointexp") = dr!RPTotalPointExpired


                        Me.fg.Styles.Normal.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                        Me.fg.SetCellImage(i, "DETAILPOINT", My.Resources.find20)
                        Me.fg.SetCellImage(i, "DETAILKLAIM", My.Resources.find20)
                        Me.fg.Styles.Normal.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                        i = i + 1
                    Next
                End With
                Call ShowTotals()
                fg.AutoSizeCols()
            Else
                fg.Rows.Count=2
                MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub ShowData21()
        Cursor = Cursors.WaitCursor
        Application.DoEvents()

        Try
            Dim dt As DataTable = New DataTable()
            Dim i As Integer = 2
            Dim sqlsup As String = ""
            Dim sql, SQL1, SQL2 As String

            If chkS_Petani.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "IDSUBPETANI = '" & cmbS_Petani.SelectedValue.ToString & "'")
            End If

            sql = "	declare @harganow decimal(19,2);
                    select top(1) @harganow= harga from tbl_Mst_HargaPoint where tanggal<=getdate() order by tanggal desc;                 			  
				    with datapopinrelasi as (SELECT   hdr.IDSubPetani, B.NamaSup AS  SubPetani, B.recent_classification_new as recent_classification
					,SUM(A.netto) AS Netto,SUM(A.jumlahpoint) AS Point ,SUM(A.pointrek) as PointRek , sum(A.pointkualitas) as PointKualitas ,sum(A.pointlicin) as PointLicin,
					SUM(A.totalpoint) AS TOTALPOINT, sum(A.totalpoint) * '" & txtharga.Text & "' AS RPTOTALPOINT,
                    0 AS TOTALPOINTKLAIM, 0 AS RPTOTALPOINTKLAIM,0 as harga, 0 AS TotalPointExpired, 0 AS RpTotalPointExpired

                    FROM  TblTrnKelapa_Poin_2023 AS a  INNER JOIN
                    TblTrnKelapaHdr AS hdr on a.nonota=hdr.nonota INNER JOIN  
                    RSUPAccounting..tblRMMstSupplier AS b ON hdr.IDSubPetani = b.KodeSup 
                    WHERE (hdr.Deleted = 0) AND (hdr.IDPancang NOT IN (40, 10, 8))  AND (A.HANGUS=0 OR A.HANGUS IS NULL) AND ( A.HANGUS=0 OR A.HANGUS IS NULL)    AND  (A.deletedpoin=0 OR A.deletedpoin IS NULL) 
                    GROUP BY hdr.IDSubPetani, B.NamaSup,B.recent_classification_new
                  
				    UNION
                   
				    SELECT A.KODESUP as IDSubPetani, B.NamaSup AS  SubPetani, B.recent_classification_new as recent_classification , 
					0 AS Netto, 0 AS TOTALPOINT, 0 AS RPTOTALPOINT,0 AS Point ,0 as PointRek , 0 as PointKualitas ,0 as PointLicin,
                    SUM(a.bayar_poin) AS TOTALPOINTKLAIM, SUM(a.bayar_rupiah) AS RPTOTALPOINTKLAIM,0 as harga, 0 AS TotalPointExpired, 0 AS RpTotalPointExpired

                    FROM vwtukarpoin2 AS a  INNER JOIN
                    RSUPAccounting..tblRMMstSupplier AS b ON A.KODESUP =b.KodeSup 
                    GROUP BY A.KODESUP, B.NamaSup,B.recent_classification_new

					 UNION
                   
					SELECT   	hdr.IDSubPetani, B.NamaSup AS  SubPetani, B.recent_classification_new as recent_classification
					,0 AS Netto,0 AS Point ,0 as PointRek , 0 as PointKualitas ,0 as PointLicin,
					0 AS TOTALPOINT, 0 AS RPTOTALPOINT,
                    0 AS TOTALPOINTKLAIM, 0 AS RPTOTALPOINTKLAIM,0 as harga, SUM(A.totalpoint)   AS TotalPointExpired, sum(A.totalpoint) * '" & txtharga.Text & "' AS RpTotalPointExpired

                    FROM  TblTrnKelapa_Poin_2023 AS a  INNER JOIN
                    TblTrnKelapaHdr AS hdr on a.nonota=hdr.nonota INNER JOIN  
                    RSUPAccounting..tblRMMstSupplier AS b ON hdr.IDSubPetani = b.KodeSup 
                    WHERE (hdr.Deleted = 0) AND (hdr.IDPancang NOT IN (40, 10, 8))  AND ( A.HANGUS=0 OR A.HANGUS IS NULL)    AND  (A.deletedpoin=0 OR A.deletedpoin IS NULL)   and a.expireddate<=getdate()
                    GROUP BY hdr.IDSubPetani, B.NamaSup,B.recent_classification_new
                  )	,dataa as (
                    select  IDSubPetani, SubPetani,recent_classification AS KLASIFIKASI,sum(Netto) as Netto, 
					sum(Point) AS POINT ,SUM(pointrek) as POINTREK , sum(PointKualitas) as POINTKUALITAS ,sum(pointlicin)  as POINTLICIN,				
					sum(TOTALPOINT) as TOTALPOINT,  sum(RPTOTALPOINT) as RPTOTALPOINT,                
					sum(TOTALPOINTKLAIM) as TOTALPOINTKLAIM,  sum(RPTOTALPOINTKLAIM) as RPTOTALPOINTKLAIM ,sum(TotalPointExpired) as TotalPointExpired ,sum( RpTotalPointExpired)  as  RpTotalPointExpired,
			         (select top(1) jumlahpointakum  from TblTrnKelapa_Poin_2023 where IDSUBPETANI= datapopinrelasi.IDSUBPETANI  AND  (HANGUS=0 OR HANGUS IS NULL) AND  (deletedpoin=0 OR deletedpoin IS NULL)    order by transid desc) as sisapoint, (select top(1) TransID from TblTrnKelapa_Poin_2023 where IDSUBPETANI= datapopinrelasi.IDSUBPETANI AND  (HANGUS=0 OR HANGUS IS NULL) AND  (deletedpoin=0 OR deletedpoin IS NULL)  order by transid desc) transid,'1' as a
                    from datapopinrelasi  WHERE IDSUBPETANI IS NOT NULL     " & IIf(sql = "", "", " AND " & sql) & "
                    group by   IDSubPetani, SubPetani,recent_classification
					UNION
					
				select  IDSubPetani, SubPetani,recent_classification AS KLASIFIKASI,sum(Netto) as Netto, 
					sum(Point) AS POINT ,SUM(pointrek) as POINTREK , sum(PointKualitas) as POINTKUALITAS ,sum(pointlicin)  as POINTLICIN,				
					sum(TOTALPOINT) as TOTALPOINT,  sum(RPTOTALPOINT) as RPTOTALPOINT,                
					sum(TOTALPOINTKLAIM) as TOTALPOINTKLAIM,  sum(RPTOTALPOINTKLAIM) as RPTOTALPOINTKLAIM ,sum(TotalPointExpired) as TotalPointExpired ,sum( RpTotalPointExpired)  as  RpTotalPointExpired,
			      ISNULL(   (select top(1) PoinBeforeClaim-poin  from Android_tblPoinTransaksiItemHdr where KODESUP= datapopinrelasi.IDSUBPETANI  AND (DELETED=0 OR DELETED IS NULL) order by transid desc),0) as sisapoint, ISNULL((select top(1) TransID from Android_tblPoinTransaksiItemHdr where KODESUP= datapopinrelasi.IDSUBPETANI   AND (DELETED=0 OR DELETED IS NULL) order by transid desc),0) transid,'2' as a
                    from datapopinrelasi  WHERE IDSUBPETANI IS NOT NULL      " & IIf(sql = "", "", " AND " & sql) & "
            group by   IDSubPetani, SubPetani,recent_classification )

                select  DISTINCT IDSubPetani, SubPetani,KLASIFIKASI, Netto, 
					 POINT , POINTREK ,POINTKUALITAS ,POINTLICIN,				
					 TOTALPOINT,  RPTOTALPOINT,                
					 TOTALPOINTKLAIM,  RPTOTALPOINTKLAIM , TotalPointExpired ,  RpTotalPointExpired,
						ISNULL(  (SELECT TOP(1) sisapoint FROM DATAA WHERE IDSUBPETANI=A.IDSUBPETANI  ORDER BY TRANSID DESC ,A DESC),0) AS  sisapoint

                    from dataa AS A ORDER BY IDSubPetani "


            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)
            If dt.Rows.Count > 0 Then
                With fg1
                    Call UI.HapusGrid(2, fg1)
                    For Each dr As DataRow In dt.Rows
                        .AddItem(i - 1)

                        '.Item(i, "KodeSupUM") = dr!KodeSupUM
                        '.Item(i, "NamaSupUM") = dr!NamaSupUM
                        .Item(i, "IDSubPetani") = dr!IDSubPetani
                        .Item(i, "SubPetani") = dr!SubPetani
                        .Item(i, "Netto") = dr!Netto

                        .Item(i, "POINT") = dr!POINT
                        .Item(i, "POINTREK") = dr!POINTREK
                        .Item(i, "POINTKUALITAS") = dr!POINTKUALITAS
                        .Item(i, "POINTLICIN") = dr!POINTLICIN

                        .Item(i, "KLASIFIKASI") = dr!KLASIFIKASI
                        .Item(i, "TOTALPOINT") = dr!TOTALPOINT
                        .Item(i, "RPTOTALPOINT") = dr!RPTOTALPOINT
                        .Item(i, "TOTALPOINTKLAIM") = dr!TOTALPOINTKLAIM
                        .Item(i, "RPTOTALPOINTKLAIM") = dr!RPTOTALPOINTKLAIM
                        '.Item(i, "SISAPOINT") = dr!TOTALPOINT - dr!TOTALPOINTKLAIM
                        '.Item(i, "RPSISAPOINT") = dr!RPTOTALPOINT - dr!RPTOTALPOINTKLAIM


                        .Item(i, "SISAPOINT") = dr!sisapoint
                        .Item(i, "RPSISAPOINT") = dr!sisapoint * txtharga.Text

                        .Item(i, "pointexp") = dr!TotalPointExpired
                        .Item(i, "RPpointexp") = dr!RPTotalPointExpired


                        i = i + 1
                    Next
                End With
                Call ShowTotals1()
                fg1.AutoSizeCols()
            Else
                fg.Rows.Count=2
                MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub


    Public Sub ShowDatanotloyal()
        Cursor = Cursors.WaitCursor
        Application.DoEvents()

        Try
            Dim dt As DataTable = New DataTable()
            Dim i As Integer = 2
            Dim sqlsup As String = ""
            Dim sql, SQL1, SQL2 As String

            If chkS_Petani.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "IDSUBPETANI = '" & cmbS_Petani.SelectedValue.ToString & "'")
            End If

            sql = " WITH RELASICLASSIFIED  as
                    (
                    SELECT DISTINCT  Hdr.IDSubPetani   FROM    TblTrnKelapa_Poin_New AS a  INNER JOIN
                    TblTrnKelapaHdr AS hdr on a.nonota=hdr.nonota INNER JOIN  
                    RSUPAccounting..tblRMMstSupplier AS b ON hdr.IDSubPetani = b.KodeSup INNER JOIN
                    RSUPAccounting..tblRMMstSupplierUM AS c ON b.KodeSupUM = c.KodeSupUM
				    WHERE (hdr.Deleted = 0) AND (hdr.IDPancang NOT IN (40, 10, 9))  AND (a.HANGUS=0 OR a.HANGUS IS NULL)
                    GROUP BY c.KodeSupUM, c.NamaSupUM,hdr.IDSubPetani, B.NamaSup
                    )
                    SELECT    c.KodeSupUM, c.NamaSupUM,B.KODESUP AS IDSubPetani, B.NamaSup AS  SubPetani
                    FROM     
                    RSUPAccounting..tblRMMstSupplier AS b INNER JOIN
                    RSUPAccounting..tblRMMstSupplierUM AS c ON b.KodeSupUM = c.KodeSupUM				
                    WHERE      B.KODESUP NOT IN (SELECT IDSubPetani FROM RELASICLASSIFIED) and B.notactive=0 and B.KODESUP like '%PCG%' " & IIf(sql = "", "", " AND " & sql) & "
                    GROUP BY c.KodeSupUM, c.NamaSupUM,B.KODESUP, B.NamaSup "

            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

            If dt.Rows.Count > 0 Then
                'SUP = ""
                With fg
                    fg.Rows.Count=2
                    For Each dr As DataRow In dt.Rows
                        .AddItem(i - 1)
                        .Item(i, "KodeSupUM") = dr!KodeSupUM
                        .Item(i, "NamaSupUM") = dr!NamaSupUM

                        .Item(i, "IDSubPetani") = dr!IDSubPetani
                        .Item(i, "SubPetani") = dr!SubPetani
                        i = i + 1
                    Next
                End With

                Call ShowTotals()
                fg.AutoSizeCols()

                Call ShowTotals()
            Else
                Call UI.HapusGrid(3, fg)
                MsgBox("No Data", MsgBoxStyle.Exclamation, AT)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ShowTotals()
        With fg
            .Tree.Column = 0
            .Tree.Style = TreeStyleFlags.CompleteLeaf
            .Subtotal(AggregateEnum.Clear)
            .Subtotal(AggregateEnum.Sum, -1, -1, 6, "Grand Total")
            .Subtotal(AggregateEnum.Sum, -1, -1, 7, "Grand Total")
            .Subtotal(AggregateEnum.Sum, -1, -1, 8, "Grand Total")
            .Subtotal(AggregateEnum.Sum, -1, -1, 9, "Grand Total")
            .Subtotal(AggregateEnum.Sum, -1, -1, 10, "Grand Total")
            .Subtotal(AggregateEnum.Sum, -1, -1, 11, "Grand Total")
            .Subtotal(AggregateEnum.Sum, -1, -1, 13, "Grand Total")
            .Subtotal(AggregateEnum.Sum, -1, -1, 14, "Grand Total")
            .Subtotal(AggregateEnum.Sum, -1, -1, 15, "Grand Total")
            .Subtotal(AggregateEnum.Sum, -1, -1, 16, "Grand Total")
            .Subtotal(AggregateEnum.Sum, -1, -1, 17, "Grand Total")
            .Subtotal(AggregateEnum.Sum, -1, -1, 18, "Grand Total")
        End With
        Call ColorSubTotal()
    End Sub

    Private Sub ShowTotals1()
        With fg1
            .Tree.Column = 0
            .Tree.Style = TreeStyleFlags.CompleteLeaf
            .Subtotal(AggregateEnum.Clear)
            .Subtotal(AggregateEnum.Sum, -1, -1, 6, "Grand Total")
            .Subtotal(AggregateEnum.Sum, -1, -1, 7, "Grand Total")
            .Subtotal(AggregateEnum.Sum, -1, -1, 8, "Grand Total")
            .Subtotal(AggregateEnum.Sum, -1, -1, 9, "Grand Total")
            .Subtotal(AggregateEnum.Sum, -1, -1, 10, "Grand Total")
            .Subtotal(AggregateEnum.Sum, -1, -1, 11, "Grand Total")
            .Subtotal(AggregateEnum.Sum, -1, -1, 13, "Grand Total")
            .Subtotal(AggregateEnum.Sum, -1, -1, 14, "Grand Total")
            .Subtotal(AggregateEnum.Sum, -1, -1, 15, "Grand Total")
            .Subtotal(AggregateEnum.Sum, -1, -1, 16, "Grand Total")
            .Subtotal(AggregateEnum.Sum, -1, -1, 17, "Grand Total")
            .Subtotal(AggregateEnum.Sum, -1, -1, 18, "Grand Total")
        End With
        Call ColorSubTotal()
    End Sub

    Private Sub ColorSubTotal()
        Dim cs As C1.Win.C1FlexGrid.CellStyle
        With fg
            cs = .Styles(C1.Win.C1FlexGrid.CellStyleEnum.GrandTotal)
            cs.BackColor = Color.SteelBlue
            cs = .Styles(C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0)
            cs.BackColor = Color.AliceBlue
            cs.ForeColor = Color.White
            cs.Font = New Font(Font, FontStyle.Bold)
        End With
    End Sub
    Private Sub schKg()
        With schfg
            .SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
            .SearchDelay = 2
            .Watermark = "Cari Disini"
            .SetC1FlexGridSearchPanel(fg, schfg)
        End With
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call UI.HapusGrid(3, fg)
        If chknewrelasi.Checked = True Then
            ShowDatanotloyal()
        Else
            ShowData2()
            ShowData21()
        End If
    End Sub

    Private Sub cmbS_Petani_Validated(sender As Object, e As EventArgs) Handles cmbS_Petani.Validated
        chkS_Petani.Checked = IIf(cmbS_Petani.Text = "", False, True)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim filename As String
        Me.SaveFileDialog.ShowDialog()
        filename = SaveFileDialog.FileName
        Me.fg1.SaveExcel(filename & ".xls", "Sheet1", FileFlags.IncludeFixedCells)
    End Sub

    Private Sub cmbS_Petani_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbS_Petani.Validating
        If cmbS_Petani.Text = "" Then
            Exit Sub
        End If

        If IsNothing(cmbS_Petani.SelectedValue) Then
            MsgBox("Pilihan tidak ada !", vbExclamation, AT)
            cmbS_Petani.Text = ""
            cmbS_Petani.Focus()
        End If
    End Sub

    Private Sub cmbS_Petani_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbS_Petani.KeyUp
        UI.AutoCompleteCombo_KeyUp(cmbS_Petani, e)
    End Sub

    Private Sub fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles fg.OwnerDrawCell
        If fg.Cols(e.Col).DataType = System.Type.[GetType]("System.Drawing.Bitmap") Then
            e.Image = fg.GetCellImage(e.Row, e.Col)
        End If
    End Sub
    Private Sub fg_DoubleClick(sender As Object, e As EventArgs) Handles fg.DoubleClick
        Select Case fg.Col

            Case 19
                With FrmMonLoyaltyCashBack
                    .Show(FrmMain.DockPanel1)
                    .chkS_Petani.Checked = True
                    .cmbS_Petani.SelectedValue = fg.Item(fg.Row, "IDSubPetani")
                    .dtcb1.Value = Format(Now, "01/MM/yyyy")
                    .dtcb2.Value = Format(Now, "dd/MM/yyyy")
                    .SHOWDATA3()
                End With

            Case 20
                With FrmMonPengajuanPoin
                    .Show(FrmMain.DockPanel1)
                    .chkS_Petani.Checked = True
                    .cmbS_Petani.SelectedValue = fg.Item(fg.Row, "IDSubPetani")
                    '.dtcb1.Value = Format(Now, "01/MM/yyyy")
                    '.dtcb2.Value = Format(Now, "dd/MM/yyyy")
                    .ShowData()
                End With

        End Select
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtharga.TextChanged

    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click

    End Sub
End Class