Imports System.Data.SqlClient
Imports C1.Win
Imports C1.Win.C1FlexGrid

Public Class FrmMonLemburKaryawan
    Dim Bergerak As Integer
    Dim Teks As String
    Dim nm As String
    Dim ClsRelasiLoyal_ As New ClsRelasiLoyal
    Dim adapter, ADAPTER2 As SqlDataAdapter
    Dim connetionString As String
    Dim connection As SqlConnection
    Dim sumbrutoperrelasi As Double

    Dim TotalAllMonth As Double

    Dim TotalPerKK As Double
    Dim TotalPerPancang As Double

    Dim lopkk As Integer
    Dim loppcg As Integer
    Dim intensitas As Integer
    Private Sub FrmMonLemburKaryawan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Testing
        dtp1.Value = Format(Now, "yyyy-MM-01")
        dtp2.Value = Format(Now, "yyyy-MM-15")
        fg.Rows.Count = 1
        fg2.Rows.Count = 1
    End Sub

    Private Sub chkTanggal_CheckedChanged(sender As Object, e As EventArgs)
        dtp1.Value = Format(Now, "yyyy-MM-dd")
        dtp2.Value = Format(Now, "yyyy-MM-dd")
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnexcel.Click
        Dim filename As String
        Me.SaveFileDialog.ShowDialog()
        filename = SaveFileDialog.FileName
        Me.fg.SaveExcel(filename & ".xls", "Sheet1", FileFlags.IncludeFixedCells)
        MsgBox("Convert Success !", MsgBoxStyle.Information, AT)
    End Sub

    Private Sub btnrefreshh_Click(sender As Object, e As EventArgs) Handles btnrefreshh.Click
        Me.Cursor = Cursors.WaitCursor

        Call ui.HapusGrid(1, fg)
        fg.Clear()
        fg.Row = 0
        fg.Col = 0
        fg.DataSource = Nothing
        '
        fg.Clear(C1.Win.C1FlexGrid.ClearFlags.Content)
        DS.Clear()
        DS.Tables.Clear()
        DS.Tables.Clear()

        Call UI.HapusGrid(1, fg2)
        fg2.Clear()
        fg2.Row = 0
        fg2.Col = 0
        fg2.DataSource = Nothing
        '
        fg2.Clear(C1.Win.C1FlexGrid.ClearFlags.Content)
        DS2.Clear()
        DS2.Tables.Clear()
        DS2.Tables.Clear()

        CALLDATA()
        CALLDATAvolume()

        With fg
            .AutoSizeCols()
            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)
            .AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free
            .Cols.Frozen = 5
            .AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free
            .Cols(3).AllowMerging = True
            .Cols(5).AllowMerging = True
        End With

        With fg2
            .AutoSizeCols()
            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)
            .AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free
            .Cols.Frozen = 5
            .AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free
            .Cols(3).AllowMerging = True
            .Cols(5).AllowMerging = True
        End With

        GrandTotal()
        GrandTotal2()

        Me.Cursor = Cursors.Default
    End Sub

#Region "Data Kg"

#End Region
    Private Sub GrandTotal()
        With fg
            .Tree.Column = 0
            .Tree.Style = TreeStyleFlags.CompleteLeaf
            .Subtotal(AggregateEnum.Clear)

            For I = 7 To fg.Cols.Count - 1
                .Subtotal(AggregateEnum.Sum, -1, -1, I, "TOTAL")
            Next I


            .AutoSizeCols()
        End With

    End Sub

    Private Sub GrandTotal2()
        With fg2
            .Tree.Column = 0
            .Tree.Style = TreeStyleFlags.CompleteLeaf
            .Subtotal(AggregateEnum.Clear)

            For I = 7 To fg2.Cols.Count - 1
                .Subtotal(AggregateEnum.Sum, -1, -1, I, "TOTAL")
            Next I

            .AutoSizeCols()
        End With

    End Sub


    Private Sub CALLDATA()

        connetionString = "server=192.168.12.5; database=RMPAPP; user=UKoneksi; password=sm@rt2018;  MultipleActiveResultSets=True; connect timeout=0;Max Pool Size=500000  ;"

        connection = New SqlConnection(connetionString)
        Dim sql, bagian As String

        If CHKP1.Checked = True Then
            bagian = "P1"
        End If
        If CHKP2.Checked = True Then
            bagian = "P2"
        End If
        If CHKP2.Checked = True And CHKP1.Checked = True Then
            bagian = "P1P2"

        End If

        If (CHKP1.Checked = True And CHKP2.Checked = False) Or (CHKP1.Checked = False And CHKP2.Checked = True) Then
            sql = "declare @StartDate DATE,@EndDate DATE,@cols AS NVARCHAR(MAX),@query  AS NVARCHAR(MAX),@Bagian AS VARCHAR(5)
		                    set @StartDate ='" & Format(dtp1.Value, "yyyy-MM-dd") & "'
		                    set @EndDate ='" & Format(dtp2.Value, "yyyy-MM-dd") & "'
                             set @Bagian ='" & bagian & "'
		               		                            
		                               DECLARE @WorkingDays TABLE (WDate DATE)

                                    ;WITH d (date) AS (
                                        SELECT @StartDate
                                        UNION ALL
                                        SELECT DATEADD(DAY, 1, date)
                                        FROM d
                                        WHERE date < @EndDate
                                    )
                                    INSERT INTO @WorkingDays
                                    SELECT d.date
                                    FROM d

                                    SET @cols = STUFF((
                                            SELECT ',' + QUOTENAME(CONVERT(VARCHAR, wd.WDate, 103)) 
                                            FROM @WorkingDays wd
                                            GROUP BY wd.WDate
                                            ORDER BY wd.WDate ASC
                                            FOR XML PATH(''), TYPE
                                        ).value('.', 'NVARCHAR(MAX)'), 1, 1, '')

                           SET @query = N';WITH tablembur(IDPersonil, NamaPersonil, Pancang, Tanggal, Status, Bagian, JamLembur, HL) AS (
                            SELECT IDPersonil, nama AS NamaPersonil, Pancang, CONVERT(VARCHAR, Tanggal, 103), Kehadiran, Bagian, 
                                CASE WHEN ISNULL(total, 0) > 70000 THEN CAST(ROUND((TOTAL - 70000) / 15000 - 0.499999999, 0) AS INTEGER) ELSE NULL END AS JamLembur, HL
                            FROM fnLemburPancangdayvolume(@StartDate, @EndDate) AS A 
                            WHERE total IS NOT NULL  AND bagian = @Bagian
                            UNION ALL
                            SELECT IDPersonil, nama AS NamaPersonil, Pancang, CONVERT(VARCHAR, Tanggal, 103), Kehadiran, Bagian,
                              case when ISNULL( total-total % 20000, 0) >=20000 then   CAST(ROUND((ISNULL( total-total % 20000, 0) / 20000) - 0.49999999, 0) AS INTEGER) end AS JamLembur, HL
                            FROM fnLemburPancangLIBURLEMBUR(@StartDate, @EndDate) AS A
                            WHERE tanggal IS NOT NULL AND total IS NOT NULL AND bagian = @Bagian
                            union ALL
							select IDPersonil, nama AS NamaPersonil, Pancang,cONVERT(VARCHAR, max(Tanggal), 103), Kehadiran, Bagian,	
							 case when ISNULL(sum(total % 20000 ), 0) >=20000 then   CAST(ROUND((ISNULL(sum(total % 20000 ), 0) / 20000) - 0.49999999, 0) AS INTEGER) end AS JamLembur, HL
							from fnLemburPancangLIBURLEMBUR (@StartDate, @EndDate) AS A WHERE  BAGIAN=@BAGIAN AND  total>0 
							group by  idpersonil,idpancang,pancang,bagian,nama,nik,jabatan,kehadiran,hl
                        ),
   
                        datalembur AS (
                            SELECT *
                            FROM tablembur
                            PIVOT (
                                SUM(JamLembur)
                                FOR Tanggal IN (' + @cols + ')
                            ) AS pvtlembur
   
    
                        )
  
                    SELECT datalembur.*,0 as Total from datalembur '
                    EXECUTE sp_executesql @query, N'@StartDate DATE, @EndDate DATE, @Bagian VARCHAR(5)', @StartDate, @EndDate, @Bagian"
        End If

        If CHKP1.Checked = True And CHKP2.Checked = True Then
            sql = "declare @StartDate DATE,@EndDate DATE,@cols AS NVARCHAR(MAX),@query  AS NVARCHAR(MAX),@Bagian AS VARCHAR(5)
		                    set @StartDate ='" & Format(dtp1.Value, "yyyy-MM-dd") & "'
		                    set @EndDate ='" & Format(dtp2.Value, "yyyy-MM-dd") & "'
                             set @Bagian ='" & bagian & "'

		                    
		                               DECLARE @WorkingDays TABLE (WDate DATE)

                                    ;WITH d (date) AS (
                                        SELECT @StartDate
                                        UNION ALL
                                        SELECT DATEADD(DAY, 1, date)
                                        FROM d
                                        WHERE date < @EndDate
                                    )
                                    INSERT INTO @WorkingDays
                                    SELECT d.date
                                    FROM d

                                    SET @cols = STUFF((
                                            SELECT ',' + QUOTENAME(CONVERT(VARCHAR, wd.WDate, 103)) 
                                            FROM @WorkingDays wd
                                            GROUP BY wd.WDate
                                            ORDER BY wd.WDate ASC
                                            FOR XML PATH(''), TYPE
                                        ).value('.', 'NVARCHAR(MAX)'), 1, 1, '')
                           
                    SET @query = N';WITH tablembur(IDPersonil, NamaPersonil, Pancang, Tanggal, Status, Bagian, JamLembur, HL) AS (
                            SELECT IDPersonil, nama AS NamaPersonil, Pancang, CONVERT(VARCHAR, Tanggal, 103), Kehadiran, Bagian, 
                                CASE WHEN ISNULL(total, 0) > 70000 THEN CAST(ROUND((TOTAL - 70000) / 15000 - 0.499999999, 0) AS INTEGER) ELSE NULL END AS JamLembur, HL
                            FROM fnLemburPancangdayvolume(@StartDate, @EndDate) AS A 
                            WHERE total IS NOT NULL  
                            UNION ALL
                            SELECT IDPersonil, nama AS NamaPersonil, Pancang, CONVERT(VARCHAR, Tanggal, 103), Kehadiran, Bagian,
                              case when ISNULL( total-total % 20000, 0) >=20000 then   CAST(ROUND((ISNULL( total-total % 20000, 0) / 20000) - 0.49999999, 0) AS INTEGER) end AS JamLembur, HL
                            FROM fnLemburPancangLIBURLEMBUR(@StartDate, @EndDate) AS A
                            WHERE tanggal IS NOT NULL AND total IS NOT NULL 
                            union ALL
							select IDPersonil, nama AS NamaPersonil, Pancang,cONVERT(VARCHAR, max(Tanggal), 103), Kehadiran, Bagian,	
							 case when ISNULL(sum(total % 20000 ), 0) >=20000 then   CAST(ROUND((ISNULL(sum(total % 20000 ), 0) / 20000) - 0.49999999, 0) AS INTEGER) end AS JamLembur, HL
							from fnLemburPancangLIBURLEMBUR (@StartDate, @EndDate) AS A WHERE  total>0 
							group by  idpersonil,idpancang,pancang,bagian,nama,nik,jabatan,kehadiran,hl

                        ),
   
                        datalembur AS (
                            SELECT * 
                            FROM tablembur
                            PIVOT (
                                SUM(JamLembur)
                                FOR Tanggal IN (' + @cols + ')
                            ) AS pvtlembur
   
    
                        )
  
                    SELECT datalembur.* ,0 as Total  from datalembur '
                    EXECUTE sp_executesql @query, N'@StartDate DATE, @EndDate DATE, @Bagian VARCHAR(5)', @StartDate, @EndDate, @Bagian"
        End If


        Try
            Dim dt As DataTable = New DataTable
            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)
            DS.Tables.Add(dt.Copy())
            fg.DataSource = DS.Tables(0)

            'connection.Open()
            'adapter = New SqlDataAdapter(sql, connection)
            'adapter.Fill(DS)
            'connection.Close()
            'fg.DataSource = DS.Tables(0)

            Dim totalrel As Integer
            Dim COLU As Integer
            For a = 1 To fg.Rows.Count - 1
                totalrel = 0
                fg.Item(a, 0) = a

                For COLU = 7 To fg.Cols.Count - 1
                    If Not IsDBNull(fg.Item(a, COLU)) Then
                        If Val(fg.Item(a, COLU)) > 0 Then
                            totalrel = fg.Item(a, COLU) + totalrel
                        End If
                    End If
                    fg.Cols(COLU).Format = "#,###0"
                Next
                fg.Item(a, fg.Cols.Count - 1) = totalrel
            Next

            fg.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub CALLDATAvolume()

        connetionString = "server=192.168.12.5; database=RMPAPP; user=UKoneksi; password=sm@rt2018;  MultipleActiveResultSets=True; connect timeout=0;Max Pool Size=500000  ;"

        connection = New SqlConnection(connetionString)
        Dim sql2, bagian As String

        If CHKP1.Checked = True Then
            bagian = "P1"
        End If
        If CHKP2.Checked = True Then
            bagian = "P2"
        End If
        If CHKP2.Checked = True And CHKP1.Checked = True Then
            bagian = "P1P2"

        End If

        If (CHKP1.Checked = True And CHKP2.Checked = False) Or (CHKP1.Checked = False And CHKP2.Checked = True) Then
            sql2 = "declare @StartDate DATE,@EndDate DATE,@cols AS NVARCHAR(MAX),@query  AS NVARCHAR(MAX),@Bagian AS VARCHAR(5)
		                                set @StartDate ='" & Format(dtp1.Value, "yyyy-MM-dd") & "'
		                                set @EndDate ='" & Format(dtp2.Value, "yyyy-MM-dd") & "'
                                         set @Bagian ='" & bagian & "'
                                        DECLARE @WorkingDays TABLE (WDate DATE)

                                        ;WITH d (date) AS (
                                            SELECT @StartDate
                                            UNION ALL
                                            SELECT DATEADD(DAY, 1, date)
                                            FROM d
                                            WHERE date < @EndDate
                                        )
                                        INSERT INTO @WorkingDays
                                        SELECT d.date
                                        FROM d

                                        SET @cols = STUFF((
                                                SELECT ',' + QUOTENAME(CONVERT(VARCHAR, wd.WDate, 103)) 
                                                FROM @WorkingDays wd
                                                GROUP BY wd.WDate
                                                ORDER BY wd.WDate ASC
                                                FOR XML PATH(''), TYPE
                                            ).value('.', 'NVARCHAR(MAX)'), 1, 1, '')
                                      SET @query = N'; with tabvolume(IDPersonil, NamaPersonil, Pancang, Tanggal, Status, Bagian, volume, HL) AS (
                                    SELECT IDPersonil, nama AS NamaPersonil, Pancang, CONVERT(VARCHAR, Tanggal, 103) , Kehadiran, Bagian, total AS volume, HL
                                    FROM fnLemburPancangdayvolume(@StartDate, @EndDate) AS A
                                    WHERE total IS NOT NULL AND bagian = @Bagian
                                    UNION  ALL
                                    SELECT IDPersonil, nama AS NamaPersonil, Pancang, CONVERT(VARCHAR, Tanggal, 103) , Kehadiran, Bagian, total AS volume, HL
                                    FROM fnLemburPancangLIBURVOLUME(@StartDate, @EndDate) AS A
                                    WHERE tanggal IS NOT NULL AND total IS NOT NULL AND bagian = @Bagian
                                ),
   
                                 datavolume AS (
                                    SELECT *
                                    FROM tabvolume
                                    PIVOT (
                                        SUM(volume)
                                        FOR Tanggal IN (' + @cols + ')
                                    ) AS pvtvolume
   
    
                                )
  
                            SELECT datavolume.* ,0 as Total  from datavolume '
                            EXECUTE sp_executesql @query, N'@StartDate DATE, @EndDate DATE, @Bagian VARCHAR(5)', @StartDate, @EndDate, @Bagian"
        End If

        If CHKP1.Checked = True And CHKP2.Checked = True Then
            sql2 = "declare @StartDate DATE,@EndDate DATE,@cols AS NVARCHAR(MAX),@query  AS NVARCHAR(MAX),@Bagian AS VARCHAR(5)
		                                set @StartDate ='" & Format(dtp1.Value, "yyyy-MM-dd") & "'
		                                set @EndDate ='" & Format(dtp2.Value, "yyyy-MM-dd") & "'
                                         set @Bagian ='" & bagian & "'

		                               DECLARE @WorkingDays TABLE (WDate DATE)

                                    ;WITH d (date) AS (
                                        SELECT @StartDate
                                        UNION ALL
                                        SELECT DATEADD(DAY, 1, date)
                                        FROM d
                                        WHERE date < @EndDate
                                    )
                                    INSERT INTO @WorkingDays
                                    SELECT d.date
                                    FROM d

                                    SET @cols = STUFF((
                                            SELECT ',' + QUOTENAME(CONVERT(VARCHAR, wd.WDate, 103)) 
                                            FROM @WorkingDays wd
                                            GROUP BY wd.WDate
                                            ORDER BY wd.WDate ASC
                                            FOR XML PATH(''), TYPE
                                        ).value('.', 'NVARCHAR(MAX)'), 1, 1, '')
                           
                               SET @query = N'; with tabvolume(IDPersonil, NamaPersonil, Pancang, Tanggal, Status, Bagian, volume, HL) AS (
                    SELECT IDPersonil, nama AS NamaPersonil, Pancang, CONVERT(VARCHAR, Tanggal, 103) , Kehadiran, Bagian, total AS volume, HL
                    FROM fnLemburPancangdayvolume(@StartDate, @EndDate) AS A
                    WHERE total IS NOT NULL
                    UNION  ALL
                    SELECT IDPersonil, nama AS NamaPersonil, Pancang, CONVERT(VARCHAR, Tanggal, 103) , Kehadiran, Bagian, total AS volume, HL
                    FROM fnLemburPancangLIBURVOLUME(@StartDate, @EndDate) AS A
                    WHERE tanggal IS NOT NULL AND total IS NOT NULL 
                ),
   
                 datavolume AS (
                    SELECT *
                    FROM tabvolume
                    PIVOT (
                        SUM(volume)
                        FOR Tanggal IN (' + @cols + ')
                    ) AS pvtvolume
               )
  
            SELECT datavolume.*,0 as Total from datavolume '
            EXECUTE sp_executesql @query, N'@StartDate DATE, @EndDate DATE, @Bagian VARCHAR(5)', @StartDate, @EndDate, @Bagian"
        End If

        Try
            Dim dt As DataTable = New DataTable
            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql2)
            DS2.Tables.Add(dt.Copy())
            fg2.DataSource = DS2.Tables(0)

            'connection.Open()
            'ADAPTER2 = New SqlDataAdapter(sql2, connection)
            'ADAPTER2.Fill(DS2)
            'connection.Close()
            'fg2.DataSource = DS2.Tables(0)

            Dim totalrel As Integer
            Dim COLU As Integer
            For a = 1 To fg2.Rows.Count - 1
                totalrel = 0
                fg2.Item(a, 0) = a

                For COLU = 7 To fg2.Cols.Count - 1
                    If Not IsDBNull(fg2.Item(a, COLU)) Then
                        If Val(fg2.Item(a, COLU)) > 0 Then
                            totalrel = fg2.Item(a, COLU) + totalrel
                        End If
                    End If
                    fg2.Cols(COLU).Format = "#,###0"
                Next
                fg2.Item(a, fg2.Cols.Count - 1) = totalrel
            Next



            fg2.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub CALLDATAall()

        connetionString = "server=192.168.12.5; database=RMPAPP; user=UKoneksi; password=sm@rt2018;  MultipleActiveResultSets=True; connect timeout=0;Max Pool Size=500000  ;"

        connection = New SqlConnection(connetionString)
        Dim sql, sql2, bagian As String

        If CHKP1.Checked = True Then
            bagian = "P1"
        End If
        If CHKP2.Checked = True Then
            bagian = "P2"
        End If
        If CHKP2.Checked = True And CHKP1.Checked = True Then
            bagian = "P1P2"

        End If

        If (CHKP1.Checked = True And CHKP2.Checked = False) Or (CHKP1.Checked = False And CHKP2.Checked = True) Then
            sql = "DECLARE @StartDate DATE, @EndDate DATE, @cols AS NVARCHAR(MAX), @colsVolume AS NVARCHAR(MAX), @colsall AS NVARCHAR(MAX), @query AS NVARCHAR(MAX), @Bagian AS VARCHAR(5)

		                                set @StartDate ='" & Format(dtp1.Value, "yyyy-MM-dd") & "'
		                                set @EndDate ='" & Format(dtp2.Value, "yyyy-MM-dd") & "'
                                         set @Bagian ='" & bagian & "'

		                              
		                               DECLARE @WorkingDays TABLE (WDate DATE)

                                    ;WITH d (date) AS (
                                        SELECT @StartDate
                                        UNION ALL
                                        SELECT DATEADD(DAY, 1, date)
                                        FROM d
                                        WHERE date < @EndDate
                                    )
                                    INSERT INTO @WorkingDays
                                    SELECT d.date
                                    FROM d

                                   SET @cols = STUFF((
                                    SELECT ',' + QUOTENAME(CONVERT(VARCHAR, wd.WDate, 103)) 
                                    FROM @WorkingDays wd
                                    GROUP BY wd.WDate
                                    ORDER BY wd.WDate ASC
                                    FOR XML PATH(''), TYPE
                                ).value('.', 'NVARCHAR(MAX)'), 1, 1, '')

                            SET @colsall = STUFF((
                                    SELECT ',' + QUOTENAME(CONVERT(VARCHAR, wd.WDate, 103)) + ',' + QUOTENAME(CONVERT(VARCHAR, wd.WDate, 103) + 'v')
                                    FROM @WorkingDays wd
                                    GROUP BY wd.WDate
                                    ORDER BY wd.WDate ASC
                                    FOR XML PATH(''), TYPE
                                ).value('.', 'NVARCHAR(MAX)'), 1, 1, '')

                            SET @colsVolume = STUFF((
                                    SELECT  ',' + QUOTENAME(CONVERT(VARCHAR, wd.WDate, 103) + 'v')
                                    FROM @WorkingDays wd
                                    GROUP BY wd.WDate
                                    ORDER BY wd.WDate ASC
                                    FOR XML PATH(''), TYPE
                                ).value('.', 'NVARCHAR(MAX)'), 1, 1, '')

                                     SET @query = N';;WITH tablembur(IDPersonil, NamaPersonil, Pancang, Tanggal, Status, Bagian, JamLembur, HL) AS (
                                    SELECT IDPersonil, nama AS NamaPersonil, Pancang, CONVERT(VARCHAR, Tanggal, 103), Kehadiran, Bagian, 
                                        CASE WHEN ISNULL(total, 0) > 70000 THEN CAST(ROUND((TOTAL - 70000) / 15000 - 0.499999999, 0) AS INTEGER) ELSE NULL END AS JamLembur, HL
                                    FROM fnLemburPancangdayvolume(@StartDate, @EndDate) AS A 
                                    WHERE total IS NOT NULL AND bagian = @Bagian
                                     union ALL
                                    SELECT IDPersonil, nama AS NamaPersonil, Pancang, CONVERT(VARCHAR, Tanggal, 103), Kehadiran, Bagian,
                                          case when ISNULL(total, 0) >=20000 then CAST(ROUND((ISNULL(total, 0) / 20000) - 0.49999999, 0) AS INTEGER) end AS JamLembur, HL
                                    FROM fnLemburPancangLIBURLEMBUR(@StartDate, @EndDate) AS A
                                    WHERE tanggal IS NOT NULL AND total IS NOT NULL AND bagian = @Bagian
                                ),
                                tabvolume(IDPersonil, NamaPersonil, Pancang, Tanggal, Status, Bagian, volume, HL) AS (
                                    SELECT IDPersonil, nama AS NamaPersonil, Pancang, CONVERT(VARCHAR, Tanggal, 103) + ''v'', Kehadiran, Bagian, total AS volume, HL
                                    FROM fnLemburPancangdayvolume(@StartDate, @EndDate) AS A 
                                    WHERE total IS NOT NULL AND bagian = @Bagian
                                      union ALL
                                    SELECT IDPersonil, nama AS NamaPersonil, Pancang, CONVERT(VARCHAR, Tanggal, 103) + ''v'', Kehadiran, Bagian, total AS volume, HL
                                    FROM fnLemburPancangLIBURVOLUME(@StartDate, @EndDate) AS A
                                    WHERE tanggal IS NOT NULL AND total IS NOT NULL AND bagian = @Bagian
                                ),
                                datalembur AS (
                                    SELECT *
                                    FROM tablembur
                                    PIVOT (
                                        SUM(JamLembur)
                                        FOR Tanggal IN ('+ @cols +')
                                    ) AS pvtlembur
                                ),
                                datavolume AS (
                                    SELECT *
                                    FROM tabvolume
                                    PIVOT (
                                        SUM(volume)
                                        FOR Tanggal IN ('+ @colsVolume +')
                                    ) AS pvtvolume
                                )
  
                            SELECT datalembur.IDPersonil, datalembur.NamaPersonil, datalembur.Pancang, 
                                datalembur.Status, datalembur.Bagian, datalembur.HL, '+ @colsall +' ,0 as Total
                            FROM datalembur
                            INNER JOIN datavolume ON datalembur.IDPersonil = datavolume.IDPersonil AND 
                                datalembur.NamaPersonil = datavolume.NamaPersonil AND 
                                datalembur.Pancang = datavolume.Pancang AND 
                                datalembur.HL = datavolume.HL'

                            EXECUTE sp_executesql @query, N'@StartDate DATE, @EndDate DATE, @Bagian VARCHAR(5)', @StartDate, @EndDate, @Bagian"
        End If

        If CHKP1.Checked = True And CHKP2.Checked = True Then
            sql = "DECLARE @StartDate DATE, @EndDate DATE, @cols AS NVARCHAR(MAX), @colsVolume AS NVARCHAR(MAX), @colsall AS NVARCHAR(MAX), @query AS NVARCHAR(MAX), @Bagian AS VARCHAR(5)

		                                set @StartDate ='" & Format(dtp1.Value, "yyyy-MM-dd") & "'
		                                set @EndDate ='" & Format(dtp2.Value, "yyyy-MM-dd") & "'
                                         set @Bagian ='" & bagian & "'

		                               
		                               DECLARE @WorkingDays TABLE (WDate DATE)

                                    ;WITH d (date) AS (
                                        SELECT @StartDate
                                        UNION ALL
                                        SELECT DATEADD(DAY, 1, date)
                                        FROM d
                                        WHERE date < @EndDate
                                    )
                                    INSERT INTO @WorkingDays
                                    SELECT d.date
                                    FROM d

                                  SET @cols = STUFF((
                                    SELECT ',' + QUOTENAME(CONVERT(VARCHAR, wd.WDate, 103)) 
                                    FROM @WorkingDays wd
                                    GROUP BY wd.WDate
                                    ORDER BY wd.WDate ASC
                                    FOR XML PATH(''), TYPE
                                ).value('.', 'NVARCHAR(MAX)'), 1, 1, '')

                            SET @colsall = STUFF((
                                    SELECT ',' + QUOTENAME(CONVERT(VARCHAR, wd.WDate, 103)) + ',' + QUOTENAME(CONVERT(VARCHAR, wd.WDate, 103) + 'v')
                                    FROM @WorkingDays wd
                                    GROUP BY wd.WDate
                                    ORDER BY wd.WDate ASC
                                    FOR XML PATH(''), TYPE
                                ).value('.', 'NVARCHAR(MAX)'), 1, 1, '')

                            SET @colsVolume = STUFF((
                                    SELECT  ',' + QUOTENAME(CONVERT(VARCHAR, wd.WDate, 103) + 'v')
                                    FROM @WorkingDays wd
                                    GROUP BY wd.WDate
                                    ORDER BY wd.WDate ASC
                                    FOR XML PATH(''), TYPE
                                ).value('.', 'NVARCHAR(MAX)'), 1, 1, '')
                           
                              SET @query = N';;WITH tablembur(IDPersonil, NamaPersonil, Pancang, Tanggal, Status, Bagian, JamLembur, HL) AS (
                                    SELECT IDPersonil, nama AS NamaPersonil, Pancang, CONVERT(VARCHAR, Tanggal, 103), Kehadiran, Bagian, 
                                        CASE WHEN ISNULL(total, 0) > 70000 THEN CAST(ROUND((TOTAL - 70000) / 15000 - 0.499999999, 0) AS INTEGER) ELSE NULL END AS JamLembur, HL
                                    FROM fnLemburPancangdayvolume(@StartDate, @EndDate) AS A 
                                    WHERE total IS NOT NULL 
                                     union ALL
                                    SELECT IDPersonil, nama AS NamaPersonil, Pancang, CONVERT(VARCHAR, Tanggal, 103), Kehadiran, Bagian,
                                          case when ISNULL(total, 0) >=20000 then CAST(ROUND((ISNULL(total, 0) / 20000) - 0.49999999, 0) AS INTEGER) end AS JamLembur, HL
                                    FROM fnLemburPancangLIBURLEMBUR(@StartDate, @EndDate) AS A
                                    WHERE tanggal IS NOT NULL AND total IS NOT NULL
                                ),
                                tabvolume(IDPersonil, NamaPersonil, Pancang, Tanggal, Status, Bagian, volume, HL) AS (
                                    SELECT IDPersonil, nama AS NamaPersonil, Pancang, CONVERT(VARCHAR, Tanggal, 103) + ''v'', Kehadiran, Bagian, total AS volume, HL
                                    FROM fnLemburPancangdayvolume(@StartDate, @EndDate) AS A 
                                    WHERE total IS NOT NULL
                                      union ALL
                                    SELECT IDPersonil, nama AS NamaPersonil, Pancang, CONVERT(VARCHAR, Tanggal, 103) + ''v'', Kehadiran, Bagian, total AS volume, HL
                                    FROM fnLemburPancangLIBURVOLUME(@StartDate, @EndDate) AS A
                                    WHERE tanggal IS NOT NULL AND total IS NOT NULL 
                                ),
                                datalembur AS (
                                    SELECT *
                                    FROM tablembur
                                    PIVOT (
                                        SUM(JamLembur)
                                        FOR Tanggal IN ('+ @cols +')
                                    ) AS pvtlembur
                                ),
                                datavolume AS (
                                    SELECT *
                                    FROM tabvolume
                                    PIVOT (
                                        SUM(volume)
                                        FOR Tanggal IN ('+ @colsVolume +')
                                    ) AS pvtvolume
                                )
  
                            SELECT datalembur.IDPersonil, datalembur.NamaPersonil, datalembur.Pancang, 
                                datalembur.Status, datalembur.Bagian, datalembur.HL, '+ @colsall +',0 as Total
                            FROM datalembur
                            INNER JOIN datavolume ON datalembur.IDPersonil = datavolume.IDPersonil AND 
                                datalembur.NamaPersonil = datavolume.NamaPersonil AND 
                                datalembur.Pancang = datavolume.Pancang AND 
                                datalembur.HL = datavolume.HL'

                            EXECUTE sp_executesql @query, N'@StartDate DATE, @EndDate DATE, @Bagian VARCHAR(5)', @StartDate, @EndDate, @Bagian
            EXECUTE sp_executesql @query, N'@StartDate DATE, @EndDate DATE, @Bagian VARCHAR(5)', @StartDate, @EndDate, @Bagian"
        End If




        Try
            connection.Open()
            adapter = New SqlDataAdapter(sql, connection)
            adapter.Fill(DS)
            connection.Close()
            fg.DataSource = DS.Tables(0)

            Dim totalrel As Integer
            Dim COLU As Integer
            For a = 1 To fg.Rows.Count - 1
                totalrel = 0
                fg.Item(a, 0) = a

                For COLU = 7 To fg.Cols.Count - 1
                    If Not IsDBNull(fg.Item(a, COLU)) Then
                        If Val(fg.Item(a, COLU)) > 0 Then
                            totalrel = fg.Item(a, COLU) + totalrel
                        End If
                    End If
                    fg.Cols(COLU).Format = "#,###0"
                Next
                fg.Item(a, fg.Cols.Count - 1) = totalrel
            Next

            fg.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

End Class
