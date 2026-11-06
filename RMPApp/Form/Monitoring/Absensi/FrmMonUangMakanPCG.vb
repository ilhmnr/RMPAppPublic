Imports System.Data.SqlClient
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar
Imports System.Windows.Interop
Imports antlr.debug
Imports C1.Win
Imports C1.Win.C1FlexGrid

Public Class FrmMonUangMakanPCG
    Dim adapter As SqlDataAdapter
    Dim connetionString As String
    Dim connection As SqlConnection
    Dim txt As CellRange
    Dim sumAmoun As Integer = 0
    Dim data As New DataTable

    Private Sub FrmMonUangMakanPCG_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtp1.Value = Format(Now, "yyyy-MM-01")
        dtp2.Value = Format(Now, "yyyy-MM-15")

        fg.Rows.Count = 1

        HeaderDgv()
        sch()
    End Sub

    Private Sub HeaderDgv()
        data.Columns.Add("RekTujuan(16)")
        data.Columns.Add("NamaPenerima(20)")
        data.Columns.Add("Alamat1")
        data.Columns.Add("Alamat2")
        data.Columns.Add("SandiKota")
        data.Columns.Add("KURS")
        data.Columns.Add("Amount")
        data.Columns.Add("Remark(12)")
        data.Columns.Add("Koma1")
        data.Columns.Add("LAYANANTRF")
        data.Columns.Add("KODEBANK")
        data.Columns.Add("BANK")
        data.Columns.Add("ALAMATKOTABANK")
    End Sub
    Private Sub sch()
        With schfg()
            .SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
            .SearchDelay = 2
            .Watermark = "Cari Disini"
            .SetC1FlexGridSearchPanel(fg, schfg)
        End With
    End Sub

    Private Sub fg_DoubleClick(sender As Object, e As EventArgs)
        Dim N As String

        N = Format(CType(fg.Item(0, fg.Col), DateTime), "yyyy-MM-dd")
        Dim targetCell = fg.GetCellStyle(fg.Row, fg.Col) ' Use GetCell method to retrieve the cell object
        If targetCell IsNot Nothing AndAlso targetCell.BackColor = Color.FromArgb(255, 255, 192) Then
            FrmMonUangMakanPCGDataPancangManual.idpersonil = fg.Item(fg.Row, 1)
            FrmMonUangMakanPCGDataPancangManual.tanggal = N
            FrmMonUangMakanPCGDataPancangManual.Show()
        End If
    End Sub

    Private Sub btnrefreshh_Click(sender As Object, e As EventArgs) Handles btnrefreshh.Click
        Me.Cursor = Cursors.WaitCursor

        If ChkKaryawan.Checked = False And ChkHarian.Checked = False Then
            MsgBox("Pilih Dulu Status Tenaga KerjaNya.", vbInformation, AT)
            Exit Sub
        End If

        connection = New SqlConnection("server=192.168.12.5; database=RMPAPP; user=UKoneksi; password=sm@rt2018;  MultipleActiveResultSets=True; connect timeout=300;Max Pool Size=500000  ;")
        Dim sql, bagian, Status As String

        If rdp1.Checked = True Then
            bagian = "P1"
        ElseIf rdp2.Checked = True Then
            bagian = "P2"
        End If

        If ChkKaryawan.Checked = True And ChkHarian.Checked = False Then
            Status = "Karyawan"
        ElseIf ChkKaryawan.Checked = False And ChkHarian.Checked = True Then
            Status = "Harian"
        ElseIf ChkKaryawan.Checked = True And ChkHarian.Checked = True Then
            Status = "Harian'',''Karyawan"
        End If

        Call ui.HapusGrid(1, fg)
        fg.Clear()
        fg.Row = 0
        fg.Col = 0
        fg.DataSource = Nothing
        fg.Clear(C1.Win.C1FlexGrid.ClearFlags.Content)

        DS.Clear()
        DS.Tables.Clear()
        DS.Tables.Clear()

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

        'Call CALLDATA()
        'Call GrandTotal()
        'Call FlagTanggal()
        'Call FlagRekeningMaster()

        Try
            sql = "declare @StartDate DATE,@EndDate DATE,@cols AS NVARCHAR(MAX),@query  AS NVARCHAR(MAX),@Bagian AS VARCHAR(5),@Status AS VARCHAR(20)
		                    set @StartDate ='" & Format(dtp1.Value, "yyyy-MM-dd") & "'
		                    set @EndDate ='" & Format(dtp2.Value, "yyyy-MM-dd") & "'
                             set @Bagian ='" & bagian & "'
                             set @Status ='" & Status & "'

		                     declare @WorkingDays Table 
		                     (
		                       WDate DATE
		                     )
		                    ;with d(date) as (
		                      select cast(@StartDate as datetime)
		                      union all
		                      select date+1
		                      from d
		                      where date < @EndDate
		                      )
		                     insert into @WorkingDays select  d.date from d
		                     SET @cols = STUFF((SELECT  ',' + QUOTENAME(convert(varchar,wd.WDate, 103)) 
							 --+  QUOTENAME(convert(varchar,wd.WDate, 103)) 
					                FROM @WorkingDays wd
                                    group by wd.WDate
					                order by wd.WDate asc
					                    FOR XML PATH(''), TYPE
					                    ).value('.', 'NVARCHAR(MAX)') 
				                    ,1,1,'')
		                    set  @query = ';WITH 
						     tabuangmakan(IDPersonil,NamaPersonil,Pancang,Tanggal, Status,bagian,UangMakan ,HL,NamaRekeningBank1,Bank1,NoRekeningBank1,KodeBank1,LAYANANTRF1,OrderBank) AS
                            (
							SELECT  IDPersonil,nama as NamaPersonil ,Pancang,convert(varchar, Tanggal, 103) , Kehadiran, Bagian,UangMakan,HL,NamaRek,Bank,NoRekeningBank,KodeBank,LAYANANTRF,
							case 
								when Bank = ''BNI'' then ''A'' 
								when Bank = ''MANDIRI'' THEN ''B'' 
								ELSE ''C'' 
							END AS OrderBank
							FROM fnabsensimonuangmakanNEW_062025() 
							WHERE  Kehadiran=''H'' and ((convert(time,JamAbsen) between ''09:58'' and ''14:02'') or (HitungUangMakan=1)) and (TidakHitungUangMakan=0 OR TIDAKHITUNGUANGMAKAN IS NULL) 
							AND Status in ('''+ @Status +''') and cast(TANGGAL as date) BETWEEN '''+cast(@StartDate as VARCHAR)+''' AND '''+cast(@EndDate as VARCHAR)+'''  and  bagian='''+ @Bagian +'''
							
							UNION 
							
							SELECT  IDPersonil,nama as NamaPersonil ,Pancang,convert(varchar, Tanggal, 103) , Kehadiran, Bagian,UangMakan,HL,NamaRek,Bank,NoRekeningBank,KodeBank,LAYANANTRF,
							case 
								when Bank = ''BNI'' then ''A'' 
								when Bank = ''MANDIRI'' THEN ''B'' 
								ELSE ''C'' 
							END AS OrderBank
							FROM fnabsensimonuangmakanNEW_062025() 
							WHERE  Kehadiran=''TL'' and (TidakHitungUangMakan=0 OR TIDAKHITUNGUANGMAKAN IS NULL) 
							AND Status in ('''+ @Status +''') and cast(TANGGAL as date) BETWEEN '''+cast(@StartDate as VARCHAR)+''' AND '''+cast(@EndDate as VARCHAR)+'''   and bagian='''+ @Bagian +'''
							
							UNION 
							
							SELECT  IDPersonil,nama as NamaPersonil ,Pancang,convert(varchar, Tanggal, 103) , Kehadiran, Bagian,UangMakan,HL,NamaRek,Bank,NoRekeningBank,KodeBank,LAYANANTRF,
							case 
								when Bank = ''BNI'' then ''A'' 
								when Bank = ''MANDIRI'' THEN ''B'' 
								ELSE ''C'' 
							END AS OrderBank
							FROM fnabsensimonuangmakanNEW_062025() 
							WHERE  AbsenManual=1 and (TidakHitungUangMakan=0 OR TIDAKHITUNGUANGMAKAN IS NULL) 
							AND Status in ('''+ @Status +''') and cast(TANGGAL as date) BETWEEN '''+cast(@StartDate as VARCHAR)+''' AND '''+cast(@EndDate as VARCHAR)+'''  and bagian='''+ @Bagian +'''
                            ),
                            datauangmakan as (SELECT *
                            FROM    tabuangmakan
                            PIVOT 
                            (
                                SUM (UangMakan) 
                                FOR Tanggal IN ('+ @cols +')
                            ) AS pvtlembur


                            )
						    select *, 0  AS Total,NamaRekeningBank1 as NamaRekening,Bank1 as Bank,NoRekeningBank1 as NoRekening,KodeBank1 as KodeBank,LAYANANTRF1 as LAYANANTRF from datauangmakan ORDER BY OrderBank,NamaPersonil ASC'
				     execute(@query) "

            Dim dt_ As DataTable = New DataTable
            dt_ = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)
            DS.Tables.Add(dt_.Copy())

            'connection.Open()
            'adapter = New SqlDataAdapter(sql, connection)
            'adapter.Fill(DS)
            'connection.Close()
            'menghilangkan kolom yang sudah tak di gunakan karena hanya trik
            DS.Tables(0).Columns.Remove("NamaRekeningBank1")
            DS.Tables(0).Columns.Remove("Bank1")
            DS.Tables(0).Columns.Remove("NoRekeningBank1")
            DS.Tables(0).Columns.Remove("KodeBank1")
            DS.Tables(0).Columns.Remove("LAYANANTRF1")
            DS.Tables(0).Columns.Remove("OrderBank")
            fg_DS.DataSource = DS.Tables(0)

            'salin dari fg_ds ke fg
            fg.Rows.Count = fg_DS.Rows.Count
            fg.Cols.Count = fg_DS.Cols.Count

            ' Salin header
            For c As Integer = 0 To fg.Cols.Count - 1
                fg(0, c) = fg_DS(0, c)
            Next

            ' Salin data
            For r As Integer = 1 To fg.Rows.Count - 1
                For c As Integer = 0 To fg.Cols.Count - 1
                    fg(r, c) = fg_DS(r, c)
                Next
            Next

            Dim totalrel As Decimal = 0
            Dim COLU As Integer 'kolom pertama tanggal absen
            For i = 1 To fg.Rows.Count - 1
                totalrel = 0
                fg.Item(i, 0) = i
                For COLU = 7 To fg.Cols.Count - 6
                    fg.Cols(COLU).Format = "#,###0"
                    If Not IsDBNull(fg.Item(i, COLU)) Then
                        If Val(fg.Item(i, COLU)) > 0 Then
                            totalrel += fg.Item(i, COLU)
                        End If
                    End If
                Next
                fg.Item(i, fg.Cols.Count - 6) = totalrel
            Next

            txt = fg.GetCellRange(0, fg.Cols.Count - 1, 0, fg.Cols.Count - 1) : fg.Cols(fg.Cols.Count - 1).Visible = False
            txt = fg.GetCellRange(0, fg.Cols.Count - 2, 0, fg.Cols.Count - 2) : fg.Cols(fg.Cols.Count - 2).Visible = False
            fg.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        With fg
            .Tree.Column = 0
            .Tree.Style = TreeStyleFlags.CompleteLeaf
            .Subtotal(AggregateEnum.Clear)

            For I = 7 To fg.Cols.Count - 6
                .Subtotal(AggregateEnum.Sum, -1, -1, I, "TOTAL")
            Next I

            .AutoSizeCols()
        End With

        Dim dt As DataTable
        Dim dt2 As DataTable
        For a = 2 To fg.Rows.Count - 1
            Dim JUMLAHJAM, JUMLAHJAMSISA As Integer

            JUMLAHJAMSISA = 0
            JUMLAHJAM = 0

            For COLU = fg.Cols.Count - 7 To 7 Step -1
                Dim cs, CS2, cs3 As CellStyle

                cs = fg.Styles.Add("redValue")
                cs.BackColor = Color.LightPink

                CS2 = fg.Styles.Add("WHITEValue")
                CS2.BackColor = Color.White

                cs3 = fg.Styles.Add("YellowValue")
                cs3.BackColor = Color.FromArgb(255, 255, 192)

                Dim x As String
                Dim N As String

                x = (CType(fg.Item(0, COLU), DateTime)).DayOfWeek.ToString
                x = x
                N = Format(CType(fg.Item(0, COLU), DateTime), "yyyy-MM-dd")

                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " Select TANGGAL  FROM RMPApp..tblMstHariLiburNasional  WHERE tanggal ='" & N & "' ")

                If x = fg.Item(a, 6) Or dt.Rows.Count > 0 Then
                    fg.SetCellStyle(a, COLU, cs)
                End If

                dt2 = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " Select TANGGAL  FROM RMPApp..TblAbsensiManualPersonilPCG  WHERE tanggal ='" & N & "' and idpersonil='" & fg.Item(a, 1) & "' and Kehadiran='" & fg.Item(a, 4) & "'  ")

                If dt2.Rows.Count > 0 Then
                    fg.SetCellStyle(a, COLU, cs3)
                End If
            Next
        Next

        Try
            For i = 2 To fg.Rows.Count - 1
                Dim cell As String = fg.Item(i, fg.Cols.Count - 3)

                If cell = "FlagRekMst" Then
                    fg.Item(i, fg.Cols.Count - 3) = cell.Replace("FlagRekMst", "")
                End If

                If Len(cell) > 10 Then
                    If Mid(cell, (Len(cell) - 9), 10) = "FlagRekMst" Then
                        Dim style As New CellRange
                        style = fg.GetCellRange(i, fg.Cols.Count - 3, i, fg.Cols.Count - 3)
                        style.StyleNew.BackColor = Color.FromArgb(192, 255, 255)

                        fg.Item(i, fg.Cols.Count - 3) = cell.Replace("FlagRekMst", "")
                    End If
                End If
            Next
        Catch ex As Exception
            'MsgBox(ex)
        End Try

        Me.Cursor = Cursors.Default
    End Sub
    Private Sub FlagRekeningMaster()
        Try
            For i = 2 To fg.Rows.Count - 1
                Dim cell As String = fg.Item(i, fg.Cols.Count - 3)

                If cell = "FlagRekMst" Then
                    fg.Item(i, fg.Cols.Count - 3) = cell.Replace("FlagRekMst", "")
                End If

                If Len(cell) > 10 Then
                    If Mid(cell, (Len(cell) - 9), 10) = "FlagRekMst" Then
                        Dim style As New CellRange
                        style = fg.GetCellRange(i, fg.Cols.Count - 3, i, fg.Cols.Count - 3)
                        style.StyleNew.BackColor = Color.FromArgb(192, 255, 255)

                        fg.Item(i, fg.Cols.Count - 3) = cell.Replace("FlagRekMst", "")
                    End If
                End If
            Next
        Catch ex As Exception
            'MsgBox(ex)
        End Try
    End Sub

    Private Sub FlagTanggal()
        Dim dt As DataTable
        Dim dt2 As DataTable
        For a = 2 To fg.Rows.Count - 1
            Dim JUMLAHJAM, JUMLAHJAMSISA As Integer

            JUMLAHJAMSISA = 0
            JUMLAHJAM = 0

            For COLU = fg.Cols.Count - 7 To 7 Step -1
                Dim cs, CS2, cs3 As CellStyle

                cs = fg.Styles.Add("redValue")
                cs.BackColor = Color.LightPink

                CS2 = fg.Styles.Add("WHITEValue")
                CS2.BackColor = Color.White

                cs3 = fg.Styles.Add("YellowValue")
                cs3.BackColor = Color.FromArgb(255, 255, 192)

                Dim x As String
                Dim N As String

                x = (CType(fg.Item(0, COLU), DateTime)).DayOfWeek.ToString
                x = x
                N = Format(CType(fg.Item(0, COLU), DateTime), "yyyy-MM-dd")

                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " Select TANGGAL  FROM RMPApp..tblMstHariLiburNasional  WHERE tanggal ='" & N & "' ")

                If x = fg.Item(a, 6) Or dt.Rows.Count > 0 Then
                    fg.SetCellStyle(a, COLU, cs)
                End If

                dt2 = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " Select TANGGAL  FROM RMPApp..TblAbsensiManualPersonilPCG  WHERE tanggal ='" & N & "' and idpersonil='" & fg.Item(a, 1) & "' and Kehadiran='" & fg.Item(a, 4) & "'  ")

                If dt2.Rows.Count > 0 Then
                    fg.SetCellStyle(a, COLU, cs3)
                End If
            Next
        Next
    End Sub

    Private Sub GrandTotal()
        With fg
            .Tree.Column = 0
            .Tree.Style = TreeStyleFlags.CompleteLeaf
            .Subtotal(AggregateEnum.Clear)

            For I = 7 To fg.Cols.Count - 6
                .Subtotal(AggregateEnum.Sum, -1, -1, I, "TOTAL")
            Next I

            .AutoSizeCols()
        End With
    End Sub
    Private Sub CALLDATA()
        If ChkKaryawan.Checked = False And ChkHarian.Checked = False Then
            MsgBox("Pilih Dulu Status Tenaga KerjaNya.", vbInformation, AT)
            Exit Sub
        End If

        connection = New SqlConnection("server=192.168.12.5; database=RMPAPP; user=UKoneksi; password=sm@rt2018;  MultipleActiveResultSets=True; connect timeout=300;Max Pool Size=500000  ;")
        Dim sql As String

        Try
            sql = getSql()

            connection.Open()
            adapter = New SqlDataAdapter(sql, connection)
            adapter.Fill(DS)
            connection.Close()

            'menghilangkan kolom yang sudah tak di gunakan karena hanya trik
            DS.Tables(0).Columns.Remove("NamaRekeningBank1")
            DS.Tables(0).Columns.Remove("Bank1")
            DS.Tables(0).Columns.Remove("NoRekeningBank1")
            DS.Tables(0).Columns.Remove("KodeBank1")
            DS.Tables(0).Columns.Remove("LAYANANTRF1")
            DS.Tables(0).Columns.Remove("OrderBank")

            fg.DataSource = DS.Tables(0)

            Dim totalrel As Decimal = 0
            Dim COLU As Integer 'kolom pertama tanggal absen

            For i = 1 To fg.Rows.Count - 1
                totalrel = 0
                fg.Item(i, 0) = i

                For COLU = 7 To fg.Cols.Count - 6
                    fg.Cols(COLU).Format = "#,###0"

                    If Not IsDBNull(fg.Item(i, COLU)) Then
                        If Val(fg.Item(i, COLU)) > 0 Then
                            totalrel += fg.Item(i, COLU)
                        End If
                    End If
                Next

                fg.Item(i, fg.Cols.Count - 6) = totalrel
            Next

            txt = fg.GetCellRange(0, fg.Cols.Count - 1, 0, fg.Cols.Count - 1) : fg.Cols(fg.Cols.Count - 1).Visible = False
            txt = fg.GetCellRange(0, fg.Cols.Count - 2, 0, fg.Cols.Count - 2) : fg.Cols(fg.Cols.Count - 2).Visible = False

            fg.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        ''testtttt'''
    End Sub

    Private Function getSql()
        Dim sql, bagian, Status As String

        If rdp1.Checked = True Then
            bagian = "P1"
        ElseIf rdp2.Checked = True Then
            bagian = "P2"
        End If

        If ChkKaryawan.Checked = True And ChkHarian.Checked = False Then
            Status = "Karyawan"
        ElseIf ChkKaryawan.Checked = False And ChkHarian.Checked = True Then
            Status = "Harian"
        ElseIf ChkKaryawan.Checked = True And ChkHarian.Checked = True Then
            Status = "Harian'',''Karyawan"
        End If

        sql = "declare @StartDate DATE,@EndDate DATE,@cols AS NVARCHAR(MAX),@query  AS NVARCHAR(MAX),@Bagian AS VARCHAR(5),@Status AS VARCHAR(20)
		                    set @StartDate ='" & Format(dtp1.Value, "yyyy-MM-dd") & "'
		                    set @EndDate ='" & Format(dtp2.Value, "yyyy-MM-dd") & "'
                             set @Bagian ='" & bagian & "'
                             set @Status ='" & Status & "'

		                     declare @WorkingDays Table 
		                     (
		                       WDate DATE
		                     )
		                    ;with d(date) as (
		                      select cast(@StartDate as datetime)
		                      union all
		                      select date+1
		                      from d
		                      where date < @EndDate
		                      )
		                     insert into @WorkingDays select  d.date from d
		                     SET @cols = STUFF((SELECT  ',' + QUOTENAME(convert(varchar,wd.WDate, 103)) 
							 --+  QUOTENAME(convert(varchar,wd.WDate, 103)) 
					                FROM @WorkingDays wd
                                    group by wd.WDate
					                order by wd.WDate asc
					                    FOR XML PATH(''), TYPE
					                    ).value('.', 'NVARCHAR(MAX)') 
				                    ,1,1,'')
		                    set  @query = ';WITH 
						     tabuangmakan(IDPersonil,NamaPersonil,Pancang,Tanggal, Status,bagian,UangMakan ,HL,NamaRekeningBank1,Bank1,NoRekeningBank1,KodeBank1,LAYANANTRF1,OrderBank) AS
                            (
							SELECT  IDPersonil,nama as NamaPersonil ,Pancang,convert(varchar, Tanggal, 103) , Kehadiran, Bagian,UangMakan,HL,NamaRek,Bank,NoRekeningBank,KodeBank,LAYANANTRF,
							case 
								when Bank = ''BNI'' then ''A'' 
								when Bank = ''MANDIRI'' THEN ''B'' 
								ELSE ''C'' 
							END AS OrderBank
							FROM vwabsensimonuangmakanNEW_2024 
							WHERE  Kehadiran=''H'' and ((convert(time,JamAbsen) between ''09:58'' and ''14:02'') or (HitungUangMakan=1)) and (TidakHitungUangMakan=0 OR TIDAKHITUNGUANGMAKAN IS NULL) 
							AND Status in ('''+ @Status +''') and cast(TANGGAL as date) BETWEEN '''+cast(@StartDate as VARCHAR)+''' AND '''+cast(@EndDate as VARCHAR)+'''  and  bagian='''+ @Bagian +'''
							
							UNION 
							
							SELECT  IDPersonil,nama as NamaPersonil ,Pancang,convert(varchar, Tanggal, 103) , Kehadiran, Bagian,UangMakan,HL,NamaRek,Bank,NoRekeningBank,KodeBank,LAYANANTRF,
							case 
								when Bank = ''BNI'' then ''A'' 
								when Bank = ''MANDIRI'' THEN ''B'' 
								ELSE ''C'' 
							END AS OrderBank
							FROM vwabsensimonuangmakanNEW_2024 
							WHERE  Kehadiran=''TL'' and (TidakHitungUangMakan=0 OR TIDAKHITUNGUANGMAKAN IS NULL) 
							AND Status in ('''+ @Status +''') and cast(TANGGAL as date) BETWEEN '''+cast(@StartDate as VARCHAR)+''' AND '''+cast(@EndDate as VARCHAR)+'''   and bagian='''+ @Bagian +'''
							
							UNION 
							
							SELECT  IDPersonil,nama as NamaPersonil ,Pancang,convert(varchar, Tanggal, 103) , Kehadiran, Bagian,UangMakan,HL,NamaRek,Bank,NoRekeningBank,KodeBank,LAYANANTRF,
							case 
								when Bank = ''BNI'' then ''A'' 
								when Bank = ''MANDIRI'' THEN ''B'' 
								ELSE ''C'' 
							END AS OrderBank
							FROM vwabsensimonuangmakanNEW_2024 
							WHERE  AbsenManual=1 and (TidakHitungUangMakan=0 OR TIDAKHITUNGUANGMAKAN IS NULL) 
							AND Status in ('''+ @Status +''') and cast(TANGGAL as date) BETWEEN '''+cast(@StartDate as VARCHAR)+''' AND '''+cast(@EndDate as VARCHAR)+'''  and bagian='''+ @Bagian +'''
                            ),
                            datauangmakan as (SELECT *
                            FROM    tabuangmakan
                            PIVOT 
                            (
                                SUM (UangMakan) 
                                FOR Tanggal IN ('+ @cols +')
                            ) AS pvtlembur


                            )
						    select *, 0  AS Total,NamaRekeningBank1 as NamaRekening,Bank1 as Bank,NoRekeningBank1 as NoRekening,KodeBank1 as KodeBank,LAYANANTRF1 as LAYANANTRF from datauangmakan ORDER BY OrderBank,NamaPersonil ASC'
				     execute(@query) "
        Return sql
    End Function

    Private Sub BtnCSV_Click(sender As Object, e As EventArgs) Handles BtnCSV.Click
        Me.Cursor = Cursors.WaitCursor

        If ChkMandiri.Checked = False And ChkBni.Checked = False And ChkBanklainNya.Checked = False Then
            MsgBox("Pilih Dulu Bank Nya", vbInformation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If


        ' Menyalin jumlah baris dan kolom dari C1FlexGrid 1 ke C1FlexGrid 2
        Dim row1 As Integer, col As Integer
        Dim rowCount As Integer, colCount As Integer
        rowCount = fg.Rows.Count
        colCount = fg.Cols.Count

        fg2.Rows.Count = 1
        fg2.Cols.Count = 0
        fg2.Cols.Count = colCount + 1

        For row1 = 0 To rowCount - 1
            fg2.Rows.Add()

            For col = 0 To colCount - 1
                fg2(row1 + 1, col + 1) = fg(row1, col)
            Next col
        Next row1

        fg2.Rows.Remove(0)
        fg2.Cols.Remove(0)



        'gabungkan baris yang sama berdasarkan nama dan pancang dan jumlahkan total nya
        For i As Integer = fg2.Rows.Count - 1 To 2 Step -1
            If fg2.Item(i, 2) = fg2.Item(i - 1, 2) AndAlso fg2.Item(i, 3) = fg2.Item(i - 1, 3) Then
                fg2.Item(i - 1, fg2.Cols.Count - 6) = fg2.Item(i - 1, fg2.Cols.Count - 6) + fg2.Item(i, fg2.Cols.Count - 6)
                fg2.Rows.Remove(i)
            End If
        Next i

        Try
            dgvlist.DataSource = Nothing
            dgvlist.Rows.Clear()
            data.Clear()
            sumAmoun = 0

            If ChkMandiri.Checked = True And ChkBni.Checked = False And ChkBanklainNya.Checked = False Then 'MANDIRI
                'hitung total uang dari  data yang di pilih
                For i = 2 To fg2.Rows.Count - 1
                    If Not IsDBNull(fg2.Item(i, fg2.Cols.Count - 1)) Then
                        If fg2.Item(i, fg2.Cols.Count - 4) = "MANDIRI" Then
                            sumAmoun += fg2.Item(i, fg2.Cols.Count - 6)
                        End If
                    End If
                Next
                ' pilih data untuk di masukan ke data grid view
                For row As Integer = 2 To fg2.Rows.Count - 1
                    If Not IsDBNull(fg2.Item(row, fg2.Cols.Count - 1)) Then
                        If fg2.Item(row, fg2.Cols.Count - 4) = "MANDIRI" Then
                            tambahRowBaru(row)
                        End If
                    End If
                Next
            ElseIf ChkMandiri.Checked = False And ChkBni.Checked = True And ChkBanklainNya.Checked = False Then 'BNI
                'hitung total uang dari  data yang di pilih
                For i = 2 To fg2.Rows.Count - 1
                    If Not IsDBNull(fg2.Item(i, fg2.Cols.Count - 1)) Then
                        If fg2.Item(i, fg2.Cols.Count - 4) = "BNI" Then
                            sumAmoun += fg2.Item(i, fg2.Cols.Count - 6)
                        End If
                    End If
                Next
                ' pilih data untuk di masukan ke data grid view
                For row As Integer = 2 To fg2.Rows.Count - 1
                    If Not IsDBNull(fg2.Item(row, fg2.Cols.Count - 1)) Then
                        If fg2.Item(row, fg2.Cols.Count - 4) = "BNI" Then
                            tambahRowBaru(row)
                        End If
                    End If
                Next


            ElseIf ChkMandiri.Checked = False And ChkBni.Checked = False And ChkBanklainNya.Checked = True Then
                'hitung total uang dari  data yang di pilih
                For i = 2 To fg2.Rows.Count - 1
                    If Not IsDBNull(fg2.Item(i, fg2.Cols.Count - 1)) Then
                        If fg2.Item(i, fg2.Cols.Count - 4) <> "MANDIRI" And fg2.Item(i, fg2.Cols.Count - 4) <> "BNI" Then
                            sumAmoun += fg2.Item(i, fg2.Cols.Count - 6)
                        End If
                    End If
                Next
                ' pilih data untuk di masukan ke data grid view
                For row As Integer = 2 To fg2.Rows.Count - 1
                    If Not IsDBNull(fg2.Item(row, fg2.Cols.Count - 1)) Then
                        If fg2.Item(row, fg2.Cols.Count - 4) <> "MANDIRI" And fg2.Item(row, fg2.Cols.Count - 4) <> "BNI" Then
                            tambahRowBaru(row)
                        End If
                    End If
                Next


            ElseIf ChkMandiri.Checked = True And ChkBni.Checked = True And ChkBanklainNya.Checked = False Then 'MANDIRI DAN BNI
                'hitung total uang dari  data yang di pilih
                For i = 2 To fg2.Rows.Count - 1
                    If Not IsDBNull(fg2.Item(i, fg2.Cols.Count - 1)) Then
                        If (fg2.Item(i, fg2.Cols.Count - 4) = "MANDIRI" Or fg2.Item(i, fg2.Cols.Count - 4) = "BNI") Then
                            sumAmoun += fg2.Item(i, fg2.Cols.Count - 6)
                        End If
                    End If
                Next
                ' pilih data untuk di masukan ke data grid view
                For row As Integer = 2 To fg2.Rows.Count - 1
                    If Not IsDBNull(fg2.Item(row, fg2.Cols.Count - 1)) Then
                        If fg2.Item(row, fg2.Cols.Count - 4) = "MANDIRI" Or fg2.Item(row, fg2.Cols.Count - 4) = "BNI" Then
                            tambahRowBaru(row)
                        End If
                    End If
                Next


            ElseIf ChkMandiri.Checked = True And ChkBni.Checked = False And ChkBanklainNya.Checked = True Then 'MANDIRI DAN BANK LAIN NYA
                'hitung total uang dari  data yang di pilih
                For i = 2 To fg2.Rows.Count - 1
                    If Not IsDBNull(fg2.Item(i, fg2.Cols.Count - 1)) Then
                        If fg2.Item(i, fg2.Cols.Count - 4) <> "BNI" Then
                            sumAmoun += fg2.Item(i, fg2.Cols.Count - 6)
                        End If
                    End If
                Next
                ' pilih data untuk di masukan ke data grid view
                For row As Integer = 2 To fg2.Rows.Count - 1
                    If Not IsDBNull(fg2.Item(row, fg2.Cols.Count - 1)) Then
                        If fg2.Item(row, fg2.Cols.Count - 4) <> "BNI" Then
                            tambahRowBaru(row)
                        End If
                    End If
                Next


            ElseIf ChkMandiri.Checked = False And ChkBni.Checked = True And ChkBanklainNya.Checked = True Then 'BNI DAN BANK LAIN NYA
                'hitung total uang dari  data yang di pilih
                For i = 2 To fg2.Rows.Count - 1
                    If Not IsDBNull(fg2.Item(i, fg2.Cols.Count - 1)) Then
                        If fg2.Item(i, fg2.Cols.Count - 4) <> "MANDIRI" Then
                            sumAmoun += fg2.Item(i, fg2.Cols.Count - 6)
                        End If
                    End If
                Next
                ' pilih data untuk di masukan ke data grid view
                For row As Integer = 2 To fg2.Rows.Count - 1
                    If Not IsDBNull(fg2.Item(row, fg2.Cols.Count - 1)) Then
                        If fg2.Item(row, fg2.Cols.Count - 4) <> "MANDIRI" Then
                            tambahRowBaru(row)
                        End If
                    End If
                Next
            End If

            dgvlist.DataSource = data

            SaveGridDataInFile("UangMakanPeriode" + Format(dtp1.Value, "ddMMMyyyy").ToString + "sd" + Format(dtp2.Value, "ddMMMyyyy").ToString + ".csv")
            MsgBox("Export To Csv Complite", vbInformation, AT)
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox("Export To Csv Failed", vbInformation, AT)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub tambahRowBaru(row)
        Dim newrow As DataRow = data.NewRow

        newrow("RekTujuan(16)") = Trim(fg2(row, fg2.Cols.Count - 3).ToString)
        newrow("NamaPenerima(20)") = fg2(row, fg2.Cols.Count - 5).ToString
        newrow("Alamat1") = "TEMBILAHAN"
        newrow("Alamat2") = ""
        newrow("SandiKota") = ""
        newrow("KURS") = "IDR"
        newrow("Amount") = fg2(row, fg2.Cols.Count - 6).ToString
        newrow("Remark(12)") = "MakanPeriode" & Format(dtp1.Value, "MMMM").ToString & IIf(CInt(Format(dtp1.Value, "dd")) < 16, 1, 2).ToString & +Format(dtp1.Value, "yy").ToString
        newrow("Koma1") = ""
        newrow("LAYANANTRF") = fg2(row, fg2.Cols.Count - 1).ToString
        newrow("KODEBANK") = fg2(row, fg2.Cols.Count - 2).ToString
        newrow("BANK") = fg(row, fg2.Cols.Count - 4).ToString
        newrow("ALAMATKOTABANK") = "TEMBILAHAN,,,,Y,regiana@rsup.co.id,,,,Y,,,,,,,,,,,,,,,,,OUR,1,E,,,"

        data.Rows.Add(newrow)
    End Sub

    Private Sub ExportToCSV(FlexGrid As C1.Win.C1FlexGrid.C1FlexGrid)
        Dim SaveFileDialog As New SaveFileDialog()
        SaveFileDialog.Filter = "CSV Files (*.csv)|*.csv"
        SaveFileDialog.DefaultExt = ".csv"

        If SaveFileDialog.ShowDialog() = DialogResult.OK Then
            Try
                Using writer As New StreamWriter(SaveFileDialog.FileName)
                    For col As Integer = 0 To FlexGrid.Cols.Count - 1
                        If FlexGrid.Cols(col).Visible Then
                            writer.Write(FlexGrid.Cols(col).Caption)
                            If col < FlexGrid.Cols.Count - 1 Then
                                writer.Write(",")
                            End If
                        End If
                    Next
                    writer.WriteLine()

                    For row As Integer = 0 To FlexGrid.Rows.Count - 1
                        Dim Nodata As Boolean = True
                        For col As Integer = 0 To FlexGrid.Cols.Count - 1
                            If FlexGrid.Cols(col).Visible And FlexGrid.Rows(row).Visible Then
                                Nodata = False
                                writer.Write(FlexGrid.GetDataDisplay(row, col))
                                If col < FlexGrid.Cols.Count - 1 Then
                                    writer.Write(",")
                                End If
                            End If
                        Next
                        If Nodata = False Then
                            writer.WriteLine()
                        End If
                    Next
                End Using

                MsgBox("Berhasil Di Export Ke File CSV", vbInformation, AT)
            Catch ex As Exception
                MsgBox("Gagal Di Export Ke File CSV", vbInformation, AT)
                MsgBox(ex.ToString)
            End Try
        End If

    End Sub
    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnexcel.Click
        Me.Cursor = Cursors.WaitCursor
        ExportToExcel()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Cursor = Cursors.WaitCursor

        ' Menyalin jumlah baris dan kolom dari C1FlexGrid 1 ke C1FlexGrid 2
        Dim row1 As Integer, col As Integer
        Dim rowCount As Integer, colCount As Integer
        rowCount = fg.Rows.Count
        colCount = fg.Cols.Count

        fg2.Rows.Count = 1
        fg2.Cols.Count = 0
        fg2.Cols.Count = colCount + 1

        For row1 = 0 To rowCount - 1
            fg2.Rows.Add()

            For col = 0 To colCount - 1
                fg2(row1 + 1, col + 1) = fg(row1, col)
            Next col
        Next row1

        fg2.Rows.Remove(0)
        fg2.Cols.Remove(0)

        'gabungkan baris yang sama berdasarkan nama dan pancang dan jumlahkan total nya
        For i As Integer = fg2.Rows.Count - 1 To 2 Step -1
            If fg2.Item(i, 2) = fg2.Item(i - 1, 2) AndAlso fg2.Item(i, 3) = fg2.Item(i - 1, 3) Then
                fg2.Item(i - 1, fg2.Cols.Count - 6) = fg2.Item(i - 1, fg2.Cols.Count - 6) + fg2.Item(i, fg2.Cols.Count - 6)
                fg2.Rows.Remove(i)
            End If
        Next i

        For i As Integer = fg2.Cols.Count - 7 To 7 Step -1
            txt = fg2.GetCellRange(0, i, 0, i) : fg2.Cols(i).Visible = False
        Next
        txt = fg2.GetCellRange(0, 4, 0, 4) : fg2.Cols(4).Visible = False

        For I = 2 To fg2.Rows.Count - 1
            fg2.Item(I, 0) = I - 1
        Next

        Dim filename As String
        Me.SaveFileDialog.ShowDialog()
        filename = SaveFileDialog.FileName
        Me.fg2.SaveExcel(filename & ".xls", "Sheet1", FileFlags.IncludeFixedCells)
        MsgBox("Convert Success !", MsgBoxStyle.Information, AT)

        Me.Cursor = Cursors.Default
    End Sub
    Public ReadOnly Property selectedoption As Integer
        Get
            Return _selectedoption
        End Get
    End Property
    Private _selectedoption As Integer = 0
    Private Sub Btn1_Click(sender As Object, e As EventArgs)
        _selectedoption = 1
        Me.Close()
    End Sub

    Private Sub Btn2_Click(sender As Object, e As EventArgs)
        _selectedoption = 2
        Me.Close()
    End Sub
    Dim csutomdialog
    Private Sub ExportToExcel()
        Dim filename As String
        Me.SaveFileDialog.ShowDialog()
        filename = SaveFileDialog.FileName
        Me.fg.SaveExcel(filename & ".xls", "Sheet1", FileFlags.IncludeFixedCells)
        MsgBox("Convert Success !", MsgBoxStyle.Information, AT)
    End Sub
    Private Sub SaveGridDataInFile(ByRef fName As String)
        Using fSave As New SaveFileDialog
            fSave.Filter = "File CSV (*.csv)|*.csv"
            fSave.DefaultExt = "csv"
            fSave.FileName = fName

            If fSave.ShowDialog = Windows.Forms.DialogResult.OK Then
                fName = fSave.FileName
            Else
                Exit Sub
            End If
        End Using
        Try
            'Create Empty String
            Dim thecsvfile As String = String.Empty
            'get column headers
            'trim the last comma
            thecsvfile = thecsvfile.TrimEnd(",")
            'add the line to the output
            'thecsvfile = thecsvfile & vbCr & vbLf
            'get the rows
            'For Each column As DataGridViewColumn In dgvlist.Columns
            '	thecsvfile = thecsvfile & column.HeaderText & ","
            'Next

            'For Each row As DataGridViewRow In dgvlist.Rows
            '	'get the cells
            '	For Each cell As DataGridViewCell In row.Cells
            '		thecsvfile = thecsvfile & cell.FormattedValue & ","
            '	Next
            '	'trim the last comma
            '	thecsvfile = thecsvfile & vbCr & vbLf
            'Next

            Dim strROW As String = dgvlist.Rows.Count
            Dim STRAMOUNT As String = sumAmoun 'total uang

            If rdp1.Checked = True Then
                thecsvfile = "P," + Format(Now, "yyyyMMdd").ToString + "," + "1080097979190," + strROW + "," + STRAMOUNT + ",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,"
            Else
                thecsvfile = "P," + Format(Now, "yyyyMMdd").ToString + "," + "1080066566770," + strROW + "," + STRAMOUNT + ",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,"
            End If

            thecsvfile = thecsvfile & vbCr & vbLf

            Dim lines As New List(Of String)
            Dim cells As New List(Of String)

            'Dim TEX As Integer
            'TEX = 0
            'For Each column As DataGridViewColumn In dgvlist.Columns
            '	If TEX = 5 Then
            '		thecsvfile = thecsvfile & column.HeaderText & vbCr & vbLf
            '	Else
            '		thecsvfile = thecsvfile & column.HeaderText & ","
            '	End If
            '	TEX = TEX + 1
            'Next

            Dim TEX2, TEXTROW As Integer
            TEX2 = 0
            TEXTROW = 0

            For Each row As DataGridViewRow In dgvlist.Rows
                'get the cells
                TEX2 = 0
                TEXTROW = TEXTROW + 1
                If TEXTROW <> strROW + 1 Then
                    For Each cell As DataGridViewCell In row.Cells
                        If TEX2 = 12 Then
                            thecsvfile = thecsvfile & cell.FormattedValue
                        Else
                            thecsvfile = thecsvfile & cell.FormattedValue & ","
                        End If
                        TEX2 = TEX2 + 1

                    Next
                End If
                'Jika Mandiri Tidak Perlu Kode Bank
                thecsvfile = Replace(thecsvfile, "0080017", "") & vbCr & vbLf
            Next

            'lines.Add(thecsvfile)
            'For Each row As DataGridViewRow In dgvlist.Rows
            '	For cellNumber As Integer = 0 To (dgvlist.Columns.Count - 1)
            '		If Not TypeOf row.Cells.Item(cellNumber).Value Is DBNull Then
            '			cells.Add(row.Cells.Item(cellNumber).Value.ToString)
            '		Else
            '			cells.Add("")
            '		End If
            '	Next
            '	lines.Add(String.Join(","c, cells.ToArray))
            'thecsvfile = thecsvfile & vbCr & vbLf
            'Next

            Dim csvString As String = String.Join(Environment.NewLine, thecsvfile.ToArray)
            IO.File.WriteAllText(fName, csvString)
        Catch e As Exception
            MessageBox.Show("Error occured while writing to the file." + e.ToString())
        Finally

        End Try
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        If ChkKaryawan.Checked = False And ChkHarian.Checked = False Then
            MsgBox("pilih Dulu Status Tenaga Kerja Nya.", vbInformation, AT)
        Else
            FrmRptUangMakanPCG.Show()
        End If
    End Sub
End Class
