Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports C1.Win
Imports C1.Win.C1FlexGrid
Imports DocumentFormat.OpenXml.Drawing

Public Class FrmMonLemburPersonilPCG
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
    Dim dateStart As Date
    Dim dateEnd As Date

    Private Sub FrmMonLemburKaryawan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Testing
        dtp.Value = Format(Now, "yyyy-MM-dd")
        fg.Rows.Count = 1
        fg2.Rows.Count = 1

        'declare style
        Dim styleMerah As CellStyle = fg.Styles.Add("Merah")
        styleMerah.BackColor = Color.Red
        styleMerah.ForeColor = Color.White ' Opsional: agar teks tetap terlihat
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

        fg.Clear(C1.Win.C1FlexGrid.ClearFlags.Content)
        DS.Clear()
        DS.Tables.Clear()
        DS.Tables.Clear()

        Call UI.HapusGrid(1, fg2)
        fg2.Clear()
        fg2.Row = 0
        fg2.Col = 0
        fg2.DataSource = Nothing

        fg2.Clear(C1.Win.C1FlexGrid.ClearFlags.Content)
        DS2.Clear()
        DS2.Tables.Clear()
        DS2.Tables.Clear()

        Call CALLDATA()
        Call HitungLembur()

        'cek idRelasi terhubung ke program psn
        With fg
            For i = 2 To .Rows.Count - 1
                If .Item(i, 5) = "P1" Then

                Else
                    If DB.ExecuteScalarValue(Of String)(StrConnRMPApp," select isnull((SELECT Nama FROM [192.168.12.12].[RSUPBorongan2010].[dbo].[tblMstTenagaKerja] where NoFix=(select top 1 RegFixNo from RMPApp..TblMstPersonilPancangNew where IDPersonil='" & .Item(i, 1) & "' order by CreatedDate desc)),'') as GetValueString ") <> .Item(i, 2) Then
                        .Rows(i).StyleNew.ForeColor = Color.Red
                    End If
                End If
            Next
        End With

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

        Call GrandTotal()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub HitungLembur()
        Dim TglMerahTerakhir As Integer = 0
        Dim AkumulasiMingguan As Integer = 0

        'warnai merah pada tanggal merah
        For j = 7 To fg.Cols.Count - 2
            If DB.ExecuteScalarValue(Of Integer)(StrConnRMPApp, " select isnull((select top 1 1 from RMPApp..tblMstHariLiburNasional where cast(Tanggal as date)='" & Format(CDate(fg.Item(0, j)), "yyyy-MM-dd") & "'),0) as GetValueInteger ") = 1 Then
                fg.Cols(j).StyleNew.BackColor = Color.FromArgb(255, 192, 192)
                fg2.Cols(j).StyleNew.BackColor = Color.FromArgb(255, 192, 192)
                TglMerahTerakhir = j
            End If

            If CDate(fg.Item(0, j)).DayOfWeek = DayOfWeek.Sunday Then
                fg.Cols(j).StyleNew.BackColor = Color.FromArgb(255, 192, 192)
                fg2.Cols(j).StyleNew.BackColor = Color.FromArgb(255, 192, 192)
                TglMerahTerakhir = j
            End If
        Next

        ' hitung jam lembur
        For i = 1 To fg.Rows.Count - 1
            For j = 7 To fg.Cols.Count - 2
                If fg.GetCellStyleDisplay(i, j).BackColor = Color.FromArgb(255, 192, 192) Then ' jika tanggal merah
                    If fg.Item(i - 1, 2) <> fg.Item(i, 2) Then ' skip jika nama sama di atas
                        If fg.Item(i, j) = 0 Then ' jika nilai nya 0 cek ke bawah
                            For l = i + 1 To fg.Rows.Count - 1
                                'If l <> fg.Rows.Count - 1 Then ' jika bukan baris akhir
                                If fg.Item(i, 2) = fg.Item(l, 2) Then ' jika nama sama
                                    If fg.Item(l, j) <> 0 Then ' jika bukan 0
                                        AkumulasiMingguan += fg.Item(l, j) Mod 20000

                                        fg.Item(l, j) = Math.Floor(fg.Item(l, j) / 20000)
                                    End If
                                Else
                                    Exit For
                                    End If
                                'Else
                                '    Exit For
                                'End If
                            Next
                        Else
                            AkumulasiMingguan += fg.Item(i, j) Mod 20000

                            fg.Item(i, j) = Math.Floor(fg.Item(i, j) / 20000)
                        End If

                        If TglMerahTerakhir = j Then
                            fg.Item(i, j) += Math.Floor(AkumulasiMingguan / 20000)
                            AkumulasiMingguan = 0
                        End If
                    End If
                Else
                    If fg.Item(i, j) > 70000 Then
                        fg.Item(i, j) = Math.Floor((fg.Item(i, j) - 70000) / 15000)
                    Else
                        fg.Item(i, j) = 0
                    End If
                End If
            Next
        Next
    End Sub

#Region "Data Kg"

#End Region
    Private Sub GrandTotal()
        Dim totalrel As Integer
        Dim COLU As Integer

        'format fg
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

        'format fg2
        totalrel = 0
        COLU = 0

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

        With fg
            .Tree.Column = 0
            .Tree.Style = TreeStyleFlags.CompleteLeaf
            .Subtotal(AggregateEnum.Clear)

            For I = 7 To fg.Cols.Count - 1
                .Subtotal(AggregateEnum.Sum, -1, -1, I, "TOTAL")
            Next I


            .AutoSizeCols()
        End With

        With fg2
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
        Dim sql, bagian As String

        connetionString = "server=192.168.12.5; database=RMPAPP; user=UKoneksi; password=sm@rt2018;  MultipleActiveResultSets=True; connect timeout=0;Max Pool Size=500000  ;"
        connection = New SqlConnection(connetionString)

        If rdPeriode1.Checked = True Then
            dateStart = New Date(dtp.Value.Year, dtp.Value.Month, 1)
            dateEnd = New Date(dtp.Value.Year, dtp.Value.Month, 15)
        Else
            dateStart = New Date(dtp.Value.Year, dtp.Value.Month, 16)
            Dim lastDay As Integer = Date.DaysInMonth(dtp.Value.Year, dtp.Value.Month)
            dateEnd = New Date(dtp.Value.Year, dtp.Value.Month, lastDay)
        End If

        If rdP1.Checked = True Then
            bagian = "''P1''"
        End If
        If rdP2.Checked = True Then
            bagian = "''P2''"
        End If
        If rdAll.Checked = True Then
            bagian = "''P1'',''P2''"
        End If

        sql = "declare @StartDate DATE,
		                @EndDate DATE,
		                @cols AS NVARCHAR(MAX),
		                @query  AS NVARCHAR(MAX)

                set @StartDate ='" & Format(dateStart, "yyyy-MM-dd") & "'
		        set @EndDate ='" & Format(dateEnd, "yyyy-MM-dd") & "'
		               		                            
                DECLARE @WorkingDays TABLE (WDate DATE)

                ;WITH d (date) AS (
	                SELECT @StartDate
	                UNION ALL
	                SELECT DATEADD(DAY, 1, date)
	                FROM d
	                WHERE date <@EndDate
                )

                INSERT INTO @WorkingDays SELECT d.date FROM d

                SET @cols = STUFF((
                SELECT ',' + QUOTENAME(CONVERT(VARCHAR, wd.WDate, 103)) 
                FROM @WorkingDays wd
                GROUP BY wd.WDate
                ORDER BY wd.WDate ASC
                FOR XML PATH(''), TYPE
                ).value('.', 'NVARCHAR(MAX)'), 1, 1, '')

                SET @query = N';
	                WITH tablembur(IDPersonil, NamaPersonil, Pancang, Tanggal, Status, Bagian, total, HL) AS (
		                SELECT IDPersonil, nama AS NamaPersonil, Pancang, CONVERT(VARCHAR, Tanggal, 103), Kehadiran, Bagian,total, HL
		                FROM fnLemburPancangAll30062025(@StartDate, @EndDate) AS A 
		                WHERE total IS NOT NULL  AND bagian in (" & bagian & ") 
	                )
	                ,datalembur AS (
		                SELECT *
		                FROM tablembur
		                PIVOT (
		                SUM(total)
		                FOR Tanggal IN (' + @cols + ')) AS pvtlembur
	                )
  
	                SELECT datalembur.*,0 as Total from datalembur order by namapersonil
                '

                EXECUTE sp_executesql @query, N'@StartDate DATE, @EndDate DATE', @StartDate, @EndDate"

        Try
            Dim dt As DataTable = New DataTable

            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)
            DS.Tables.Add(dt.Copy())
            fg_.DataSource = DS.Tables(0)

            'copy ke fg 
            ' Atur jumlah baris dan kolom
            fg.Rows.Count = fg_.Rows.Count
            fg.Cols.Count = fg_.Cols.Count
            ' Salin nilai sel satu per satu
            For r As Integer = 0 To fg_.Rows.Count - 1
                For c As Integer = 0 To fg_.Cols.Count - 1
                    fg(r, c) = fg_(r, c)
                Next
            Next
            ' Salin header (opsional)
            For c As Integer = 0 To fg_.Cols.Count - 1
                fg.Cols(c).Caption = fg_.Cols(c).Caption
            Next

            'beri nilai 0 pada kolom null fg
            For i = 1 To fg.Rows.Count - 1
                For j = 7 To fg.Cols.Count - 2
                    If IsDBNull(fg.Item(i, j)) Then
                        fg.Item(i, j) = 0
                    End If
                Next
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'copy ke fg2
            ' Atur jumlah baris dan kolom
            fg2.Rows.Count = fg.Rows.Count
            fg2.Cols.Count = fg.Cols.Count
            ' Salin nilai sel satu per satu
            For r As Integer = 0 To fg.Rows.Count - 1
                For c As Integer = 0 To fg.Cols.Count - 1
                    fg2(r, c) = fg(r, c)
                Next
            Next
            ' Salin header (opsional)
            For c As Integer = 0 To fg.Cols.Count - 1
                fg2.Cols(c).Caption = fg.Cols(c).Caption
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnKirimData_Click(sender As Object, e As EventArgs) Handles btnKirimData.Click
        Me.Cursor = Cursors.WaitCursor

        Dim TotalJam As Integer = 0

        If rdPeriode1.Checked = True Then
            dateStart = New Date(dtp.Value.Year, dtp.Value.Month, 1)
        Else
            dateStart = New Date(dtp.Value.Year, dtp.Value.Month, 16)
        End If

        With fg
            ' jika total jam > 0 dan fixNo belum sesuai
            For k = 2 To .Rows.Count - 1
                If .Item(k, .Cols.Count - 1) > 0 And .GetCellStyleDisplay(k, .Cols.Count - 1).ForeColor = Color.Red Then
                    MsgBox("Personil Pancang " + .Item(k, 1) + ". " + .Item(k, 2) + " FixNo Belum Sesuai Dengan Program PSN.", vbExclamation, AT)
                    Exit Sub
                End If
            Next

            Dim koneksi As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnRMPApp)
            Dim transaksi As SqlTransaction
            transaksi = koneksi.BeginTransaction

            For i = 2 To .Rows.Count - 1
                If .Item(i, .Cols.Count - 1) > 0 Then
                    'hitung total jam 
                    For j = i To .Rows.Count - 1
                        If .Item(i, 1) = .Item(j, 1) Then
                            TotalJam += .Item(j, .Cols.Count - 1)
                        End If
                    Next

                    If SaveData(koneksi, transaksi, i, TotalJam) = False Then
                        transaksi.Rollback()
                        MsgBox("Simpan Data Gagal !", vbCritical, AT)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If

                    TotalJam = 0
                End If
            Next

            transaksi.Commit()

            Me.Cursor = Cursors.Default

            MsgBox("Data Berhasil Di Kirim.", vbInformation, AT)
        End With
    End Sub

    Private Function SaveData(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal row As Integer, ByVal TotalJam As Integer) As Boolean
        SaveData = False

        Dim MyCon As SqlConnection = Conn
        Dim MyConTrans As SqlTransaction = Trans
        Dim cmd As New SqlCommand

        With cmd
            .Connection = Conn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RMPApp..spSaveKalkulasiLemburPancangP2"
            .Transaction = MyConTrans

            .Parameters.Add("@Periode", SqlDbType.Date).Value = Format(dateStart, "yyyy-MM-dd")
            .Parameters.Add("@KodeSup", SqlDbType.VarChar, 50).Value = fg.Item(row, 1)
            .Parameters.Add("@TotalJam", SqlDbType.Int).Value = TotalJam
            .Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
            .Parameters.Add(New SqlParameter("@Flag", SqlDbType.Int, 1, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))

            .ExecuteNonQuery()
        End With

        Try
            If CInt(cmd.Parameters("@Flag").Value) = 0 Then
                cmd.Dispose()
                Exit Function
            End If

            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        FrmMonLemburPersonilPCGFind.Show()
    End Sub

    'Private Sub CALLDATAvolume()

    '    connetionString = "server=192.168.12.5; database=RMPAPP; user=UKoneksi; password=sm@rt2018;  MultipleActiveResultSets=True; connect timeout=0;Max Pool Size=500000  ;"

    '    connection = New SqlConnection(connetionString)
    '    Dim sql2, bagian As String

    '    If CHKP1.Checked = True Then
    '        bagian = "P1"
    '    End If
    '    If CHKP2.Checked = True Then
    '        bagian = "P2"
    '    End If
    '    If CHKP2.Checked = True And CHKP1.Checked = True Then
    '        bagian = "P1P2"

    '    End If

    '    If (CHKP1.Checked = True And CHKP2.Checked = False) Or (CHKP1.Checked = False And CHKP2.Checked = True) Then
    '        sql2 = "declare @StartDate DATE,@EndDate DATE,@cols AS NVARCHAR(MAX),@query  AS NVARCHAR(MAX),@Bagian AS VARCHAR(5)
    '                              set @StartDate ='" & Format(dtp1.Value, "yyyy-MM-dd") & "'
    '                              set @EndDate ='" & Format(dtp2.Value, "yyyy-MM-dd") & "'
    '                                     set @Bagian ='" & bagian & "'
    '                                    DECLARE @WorkingDays TABLE (WDate DATE)

    '                                    ;WITH d (date) AS (
    '                                        SELECT @StartDate
    '                                        UNION ALL
    '                                        SELECT DATEADD(DAY, 1, date)
    '                                        FROM d
    '                                        WHERE date < @EndDate
    '                                    )
    '                                    INSERT INTO @WorkingDays
    '                                    SELECT d.date
    '                                    FROM d

    '                                    SET @cols = STUFF((
    '                                            SELECT ',' + QUOTENAME(CONVERT(VARCHAR, wd.WDate, 103)) 
    '                                            FROM @WorkingDays wd
    '                                            GROUP BY wd.WDate
    '                                            ORDER BY wd.WDate ASC
    '                                            FOR XML PATH(''), TYPE
    '                                        ).value('.', 'NVARCHAR(MAX)'), 1, 1, '')
    '                                  SET @query = N'; with tabvolume(IDPersonil, NamaPersonil, Pancang, Tanggal, Status, Bagian, volume, HL) AS (
    '                                SELECT IDPersonil, nama AS NamaPersonil, Pancang, CONVERT(VARCHAR, Tanggal, 103) , Kehadiran, Bagian, total AS volume, HL
    '                                FROM fnLemburPancangdayvolume(@StartDate, @EndDate) AS A
    '                                WHERE total IS NOT NULL AND bagian = @Bagian
    '                                UNION  ALL
    '                                SELECT IDPersonil, nama AS NamaPersonil, Pancang, CONVERT(VARCHAR, Tanggal, 103) , Kehadiran, Bagian, total AS volume, HL
    '                                FROM fnLemburPancangLIBURVOLUME(@StartDate, @EndDate) AS A
    '                                WHERE tanggal IS NOT NULL AND total IS NOT NULL AND bagian = @Bagian
    '                            ),

    '                             datavolume AS (
    '                                SELECT *
    '                                FROM tabvolume
    '                                PIVOT (
    '                                    SUM(volume)
    '                                    FOR Tanggal IN (' + @cols + ')
    '                                ) AS pvtvolume


    '                            )

    '                        SELECT datavolume.* ,0 as Total  from datavolume '
    '                        EXECUTE sp_executesql @query, N'@StartDate DATE, @EndDate DATE, @Bagian VARCHAR(5)', @StartDate, @EndDate, @Bagian"
    '    End If

    '    If CHKP1.Checked = True And CHKP2.Checked = True Then
    '        sql2 = "declare @StartDate DATE,@EndDate DATE,@cols AS NVARCHAR(MAX),@query  AS NVARCHAR(MAX),@Bagian AS VARCHAR(5)
    '                              set @StartDate ='" & Format(dtp1.Value, "yyyy-MM-dd") & "'
    '                              set @EndDate ='" & Format(dtp2.Value, "yyyy-MM-dd") & "'
    '                                     set @Bagian ='" & bagian & "'

    '                             DECLARE @WorkingDays TABLE (WDate DATE)

    '                                ;WITH d (date) AS (
    '                                    SELECT @StartDate
    '                                    UNION ALL
    '                                    SELECT DATEADD(DAY, 1, date)
    '                                    FROM d
    '                                    WHERE date < @EndDate
    '                                )
    '                                INSERT INTO @WorkingDays
    '                                SELECT d.date
    '                                FROM d

    '                                SET @cols = STUFF((
    '                                        SELECT ',' + QUOTENAME(CONVERT(VARCHAR, wd.WDate, 103)) 
    '                                        FROM @WorkingDays wd
    '                                        GROUP BY wd.WDate
    '                                        ORDER BY wd.WDate ASC
    '                                        FOR XML PATH(''), TYPE
    '                                    ).value('.', 'NVARCHAR(MAX)'), 1, 1, '')

    '                           SET @query = N'; with tabvolume(IDPersonil, NamaPersonil, Pancang, Tanggal, Status, Bagian, volume, HL) AS (
    '                SELECT IDPersonil, nama AS NamaPersonil, Pancang, CONVERT(VARCHAR, Tanggal, 103) , Kehadiran, Bagian, total AS volume, HL
    '                FROM fnLemburPancangdayvolume(@StartDate, @EndDate) AS A
    '                WHERE total IS NOT NULL
    '                UNION  ALL
    '                SELECT IDPersonil, nama AS NamaPersonil, Pancang, CONVERT(VARCHAR, Tanggal, 103) , Kehadiran, Bagian, total AS volume, HL
    '                FROM fnLemburPancangLIBURVOLUME(@StartDate, @EndDate) AS A
    '                WHERE tanggal IS NOT NULL AND total IS NOT NULL 
    '            ),

    '             datavolume AS (
    '                SELECT *
    '                FROM tabvolume
    '                PIVOT (
    '                    SUM(volume)
    '                    FOR Tanggal IN (' + @cols + ')
    '                ) AS pvtvolume
    '           )

    '        SELECT datavolume.*,0 as Total from datavolume '
    '        EXECUTE sp_executesql @query, N'@StartDate DATE, @EndDate DATE, @Bagian VARCHAR(5)', @StartDate, @EndDate, @Bagian"
    '    End If

    '    Try
    '        Dim dt As DataTable = New DataTable
    '        dt = DB.ExecuteQuery(StrConnRMPApp,sql2)
    '        DS2.Tables.Add(dt.Copy())
    '        fg2.DataSource = DS2.Tables(0)

    '        'connection.Open()
    '        'ADAPTER2 = New SqlDataAdapter(sql2, connection)
    '        'ADAPTER2.Fill(DS2)
    '        'connection.Close()
    '        'fg2.DataSource = DS2.Tables(0)

    '        Dim totalrel As Integer
    '        Dim COLU As Integer
    '        For a = 1 To fg2.Rows.Count - 1
    '            totalrel = 0
    '            fg2.Item(a, 0) = a

    '            For COLU = 7 To fg2.Cols.Count - 1
    '                If Not IsDBNull(fg2.Item(a, COLU)) Then
    '                    If Val(fg2.Item(a, COLU)) > 0 Then
    '                        totalrel = fg2.Item(a, COLU) + totalrel
    '                    End If
    '                End If
    '                fg2.Cols(COLU).Format = "#,###0"
    '            Next
    '            fg2.Item(a, fg2.Cols.Count - 1) = totalrel
    '        Next



    '        fg2.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free

    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try

    'End Sub

    'Private Sub CALLDATAall()

    '    connetionString = "server=192.168.12.5; database=RMPAPP; user=UKoneksi; password=sm@rt2018;  MultipleActiveResultSets=True; connect timeout=0;Max Pool Size=500000  ;"

    '    connection = New SqlConnection(connetionString)
    '    Dim sql, sql2, bagian As String

    '    If CHKP1.Checked = True Then
    '        bagian = "P1"
    '    End If
    '    If CHKP2.Checked = True Then
    '        bagian = "P2"
    '    End If
    '    If CHKP2.Checked = True And CHKP1.Checked = True Then
    '        bagian = "P1P2"

    '    End If

    '    If (CHKP1.Checked = True And CHKP2.Checked = False) Or (CHKP1.Checked = False And CHKP2.Checked = True) Then
    '        sql = "DECLARE @StartDate DATE, @EndDate DATE, @cols AS NVARCHAR(MAX), @colsVolume AS NVARCHAR(MAX), @colsall AS NVARCHAR(MAX), @query AS NVARCHAR(MAX), @Bagian AS VARCHAR(5)

    '                              set @StartDate ='" & Format(dtp1.Value, "yyyy-MM-dd") & "'
    '                              set @EndDate ='" & Format(dtp2.Value, "yyyy-MM-dd") & "'
    '                                     set @Bagian ='" & bagian & "'


    '                             DECLARE @WorkingDays TABLE (WDate DATE)

    '                                ;WITH d (date) AS (
    '                                    SELECT @StartDate
    '                                    UNION ALL
    '                                    SELECT DATEADD(DAY, 1, date)
    '                                    FROM d
    '                                    WHERE date < @EndDate
    '                                )
    '                                INSERT INTO @WorkingDays
    '                                SELECT d.date
    '                                FROM d

    '                               SET @cols = STUFF((
    '                                SELECT ',' + QUOTENAME(CONVERT(VARCHAR, wd.WDate, 103)) 
    '                                FROM @WorkingDays wd
    '                                GROUP BY wd.WDate
    '                                ORDER BY wd.WDate ASC
    '                                FOR XML PATH(''), TYPE
    '                            ).value('.', 'NVARCHAR(MAX)'), 1, 1, '')

    '                        SET @colsall = STUFF((
    '                                SELECT ',' + QUOTENAME(CONVERT(VARCHAR, wd.WDate, 103)) + ',' + QUOTENAME(CONVERT(VARCHAR, wd.WDate, 103) + 'v')
    '                                FROM @WorkingDays wd
    '                                GROUP BY wd.WDate
    '                                ORDER BY wd.WDate ASC
    '                                FOR XML PATH(''), TYPE
    '                            ).value('.', 'NVARCHAR(MAX)'), 1, 1, '')

    '                        SET @colsVolume = STUFF((
    '                                SELECT  ',' + QUOTENAME(CONVERT(VARCHAR, wd.WDate, 103) + 'v')
    '                                FROM @WorkingDays wd
    '                                GROUP BY wd.WDate
    '                                ORDER BY wd.WDate ASC
    '                                FOR XML PATH(''), TYPE
    '                            ).value('.', 'NVARCHAR(MAX)'), 1, 1, '')

    '                                 SET @query = N';;WITH tablembur(IDPersonil, NamaPersonil, Pancang, Tanggal, Status, Bagian, JamLembur, HL) AS (
    '                                SELECT IDPersonil, nama AS NamaPersonil, Pancang, CONVERT(VARCHAR, Tanggal, 103), Kehadiran, Bagian, 
    '                                    CASE WHEN ISNULL(total, 0) > 70000 THEN CAST(ROUND((TOTAL - 70000) / 15000 - 0.499999999, 0) AS INTEGER) ELSE NULL END AS JamLembur, HL
    '                                FROM fnLemburPancangdayvolume(@StartDate, @EndDate) AS A 
    '                                WHERE total IS NOT NULL AND bagian = @Bagian
    '                                 union ALL
    '                                SELECT IDPersonil, nama AS NamaPersonil, Pancang, CONVERT(VARCHAR, Tanggal, 103), Kehadiran, Bagian,
    '                                      case when ISNULL(total, 0) >=20000 then CAST(ROUND((ISNULL(total, 0) / 20000) - 0.49999999, 0) AS INTEGER) end AS JamLembur, HL
    '                                FROM fnLemburPancangLIBURLEMBUR(@StartDate, @EndDate) AS A
    '                                WHERE tanggal IS NOT NULL AND total IS NOT NULL AND bagian = @Bagian
    '                            ),
    '                            tabvolume(IDPersonil, NamaPersonil, Pancang, Tanggal, Status, Bagian, volume, HL) AS (
    '                                SELECT IDPersonil, nama AS NamaPersonil, Pancang, CONVERT(VARCHAR, Tanggal, 103) + ''v'', Kehadiran, Bagian, total AS volume, HL
    '                                FROM fnLemburPancangdayvolume(@StartDate, @EndDate) AS A 
    '                                WHERE total IS NOT NULL AND bagian = @Bagian
    '                                  union ALL
    '                                SELECT IDPersonil, nama AS NamaPersonil, Pancang, CONVERT(VARCHAR, Tanggal, 103) + ''v'', Kehadiran, Bagian, total AS volume, HL
    '                                FROM fnLemburPancangLIBURVOLUME(@StartDate, @EndDate) AS A
    '                                WHERE tanggal IS NOT NULL AND total IS NOT NULL AND bagian = @Bagian
    '                            ),
    '                            datalembur AS (
    '                                SELECT *
    '                                FROM tablembur
    '                                PIVOT (
    '                                    SUM(JamLembur)
    '                                    FOR Tanggal IN ('+ @cols +')
    '                                ) AS pvtlembur
    '                            ),
    '                            datavolume AS (
    '                                SELECT *
    '                                FROM tabvolume
    '                                PIVOT (
    '                                    SUM(volume)
    '                                    FOR Tanggal IN ('+ @colsVolume +')
    '                                ) AS pvtvolume
    '                            )

    '                        SELECT datalembur.IDPersonil, datalembur.NamaPersonil, datalembur.Pancang, 
    '                            datalembur.Status, datalembur.Bagian, datalembur.HL, '+ @colsall +' ,0 as Total
    '                        FROM datalembur
    '                        INNER JOIN datavolume ON datalembur.IDPersonil = datavolume.IDPersonil AND 
    '                            datalembur.NamaPersonil = datavolume.NamaPersonil AND 
    '                            datalembur.Pancang = datavolume.Pancang AND 
    '                            datalembur.HL = datavolume.HL'

    '                        EXECUTE sp_executesql @query, N'@StartDate DATE, @EndDate DATE, @Bagian VARCHAR(5)', @StartDate, @EndDate, @Bagian"
    '    End If

    '    If CHKP1.Checked = True And CHKP2.Checked = True Then
    '        sql = "DECLARE @StartDate DATE, @EndDate DATE, @cols AS NVARCHAR(MAX), @colsVolume AS NVARCHAR(MAX), @colsall AS NVARCHAR(MAX), @query AS NVARCHAR(MAX), @Bagian AS VARCHAR(5)

    '                              set @StartDate ='" & Format(dtp1.Value, "yyyy-MM-dd") & "'
    '                              set @EndDate ='" & Format(dtp2.Value, "yyyy-MM-dd") & "'
    '                                     set @Bagian ='" & bagian & "'


    '                             DECLARE @WorkingDays TABLE (WDate DATE)

    '                                ;WITH d (date) AS (
    '                                    SELECT @StartDate
    '                                    UNION ALL
    '                                    SELECT DATEADD(DAY, 1, date)
    '                                    FROM d
    '                                    WHERE date < @EndDate
    '                                )
    '                                INSERT INTO @WorkingDays
    '                                SELECT d.date
    '                                FROM d

    '                              SET @cols = STUFF((
    '                                SELECT ',' + QUOTENAME(CONVERT(VARCHAR, wd.WDate, 103)) 
    '                                FROM @WorkingDays wd
    '                                GROUP BY wd.WDate
    '                                ORDER BY wd.WDate ASC
    '                                FOR XML PATH(''), TYPE
    '                            ).value('.', 'NVARCHAR(MAX)'), 1, 1, '')

    '                        SET @colsall = STUFF((
    '                                SELECT ',' + QUOTENAME(CONVERT(VARCHAR, wd.WDate, 103)) + ',' + QUOTENAME(CONVERT(VARCHAR, wd.WDate, 103) + 'v')
    '                                FROM @WorkingDays wd
    '                                GROUP BY wd.WDate
    '                                ORDER BY wd.WDate ASC
    '                                FOR XML PATH(''), TYPE
    '                            ).value('.', 'NVARCHAR(MAX)'), 1, 1, '')

    '                        SET @colsVolume = STUFF((
    '                                SELECT  ',' + QUOTENAME(CONVERT(VARCHAR, wd.WDate, 103) + 'v')
    '                                FROM @WorkingDays wd
    '                                GROUP BY wd.WDate
    '                                ORDER BY wd.WDate ASC
    '                                FOR XML PATH(''), TYPE
    '                            ).value('.', 'NVARCHAR(MAX)'), 1, 1, '')

    '                          SET @query = N';;WITH tablembur(IDPersonil, NamaPersonil, Pancang, Tanggal, Status, Bagian, JamLembur, HL) AS (
    '                                SELECT IDPersonil, nama AS NamaPersonil, Pancang, CONVERT(VARCHAR, Tanggal, 103), Kehadiran, Bagian, 
    '                                    CASE WHEN ISNULL(total, 0) > 70000 THEN CAST(ROUND((TOTAL - 70000) / 15000 - 0.499999999, 0) AS INTEGER) ELSE NULL END AS JamLembur, HL
    '                                FROM fnLemburPancangdayvolume(@StartDate, @EndDate) AS A 
    '                                WHERE total IS NOT NULL 
    '                                 union ALL
    '                                SELECT IDPersonil, nama AS NamaPersonil, Pancang, CONVERT(VARCHAR, Tanggal, 103), Kehadiran, Bagian,
    '                                      case when ISNULL(total, 0) >=20000 then CAST(ROUND((ISNULL(total, 0) / 20000) - 0.49999999, 0) AS INTEGER) end AS JamLembur, HL
    '                                FROM fnLemburPancangLIBURLEMBUR(@StartDate, @EndDate) AS A
    '                                WHERE tanggal IS NOT NULL AND total IS NOT NULL
    '                            ),
    '                            tabvolume(IDPersonil, NamaPersonil, Pancang, Tanggal, Status, Bagian, volume, HL) AS (
    '                                SELECT IDPersonil, nama AS NamaPersonil, Pancang, CONVERT(VARCHAR, Tanggal, 103) + ''v'', Kehadiran, Bagian, total AS volume, HL
    '                                FROM fnLemburPancangdayvolume(@StartDate, @EndDate) AS A 
    '                                WHERE total IS NOT NULL
    '                                  union ALL
    '                                SELECT IDPersonil, nama AS NamaPersonil, Pancang, CONVERT(VARCHAR, Tanggal, 103) + ''v'', Kehadiran, Bagian, total AS volume, HL
    '                                FROM fnLemburPancangLIBURVOLUME(@StartDate, @EndDate) AS A
    '                                WHERE tanggal IS NOT NULL AND total IS NOT NULL 
    '                            ),
    '                            datalembur AS (
    '                                SELECT *
    '                                FROM tablembur
    '                                PIVOT (
    '                                    SUM(JamLembur)
    '                                    FOR Tanggal IN ('+ @cols +')
    '                                ) AS pvtlembur
    '                            ),
    '                            datavolume AS (
    '                                SELECT *
    '                                FROM tabvolume
    '                                PIVOT (
    '                                    SUM(volume)
    '                                    FOR Tanggal IN ('+ @colsVolume +')
    '                                ) AS pvtvolume
    '                            )

    '                        SELECT datalembur.IDPersonil, datalembur.NamaPersonil, datalembur.Pancang, 
    '                            datalembur.Status, datalembur.Bagian, datalembur.HL, '+ @colsall +',0 as Total
    '                        FROM datalembur
    '                        INNER JOIN datavolume ON datalembur.IDPersonil = datavolume.IDPersonil AND 
    '                            datalembur.NamaPersonil = datavolume.NamaPersonil AND 
    '                            datalembur.Pancang = datavolume.Pancang AND 
    '                            datalembur.HL = datavolume.HL'

    '                        EXECUTE sp_executesql @query, N'@StartDate DATE, @EndDate DATE, @Bagian VARCHAR(5)', @StartDate, @EndDate, @Bagian
    '        EXECUTE sp_executesql @query, N'@StartDate DATE, @EndDate DATE, @Bagian VARCHAR(5)', @StartDate, @EndDate, @Bagian"
    '    End If




    '    Try
    '        connection.Open()
    '        adapter = New SqlDataAdapter(sql, connection)
    '        adapter.Fill(DS)
    '        connection.Close()
    '        fg.DataSource = DS.Tables(0)

    '        Dim totalrel As Integer
    '        Dim COLU As Integer
    '        For a = 1 To fg.Rows.Count - 1
    '            totalrel = 0
    '            fg.Item(a, 0) = a

    '            For COLU = 7 To fg.Cols.Count - 1
    '                If Not IsDBNull(fg.Item(a, COLU)) Then
    '                    If Val(fg.Item(a, COLU)) > 0 Then
    '                        totalrel = fg.Item(a, COLU) + totalrel
    '                    End If
    '                End If
    '                fg.Cols(COLU).Format = "#,###0"
    '            Next
    '            fg.Item(a, fg.Cols.Count - 1) = totalrel
    '        Next

    '        fg.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free

    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try

    'End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs)
        Dim a As Integer = fg.RowSel
        Dim b As Integer = fg.ColSel
    End Sub
End Class
