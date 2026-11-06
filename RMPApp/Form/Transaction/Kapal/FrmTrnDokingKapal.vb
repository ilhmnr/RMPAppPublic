Imports System.Data.SqlClient
Imports System.Runtime.InteropServices.ComTypes
Imports C1.Win
Imports C1.Win.C1FlexGrid
Imports DocumentFormat.OpenXml.Math
Imports Microsoft.Win32

Public Class FrmTrnDokingKapal
    Dim txt As CellRange
    Dim cell As CellRange
    Private Sub FrmTrnDokingKapal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCmbPancang()
        fg.Clear()
        fg.Row = 0
        fg.Col = 0
        fg.DataSource = Nothing
        fg.Clear(C1.Win.C1FlexGrid.ClearFlags.Content)

        search()

        Dtp1.Value = Format(Dtp2.Value, "01-yyyy")
        Dtp2.Value = Format(Dtp2.Value, "12-yyyy")
    End Sub

    Private Sub search()
        C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        C1FlexGridSearchPanel1.SearchDelay = 2
        C1FlexGridSearchPanel1.Watermark = "Search : Pemilik/Kapal"
        C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(fg, C1FlexGridSearchPanel1)
    End Sub

    Private Sub LoadCmbPancang()
        Try
            Dim dt As DataTable = New DataTable()
            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " select IDPancang,Pancang = convert(varchar,IDPancang) + '. ' + Pancang from Android_tblMstPancang WHERE IDPancang in ( select DISTINCT IdPancang from TblTrnDokingKapal ) ORDER BY IDPancang ASC ")
            With CmbPancang
                .DataSource = dt
                .DisplayMember = "Pancang"
                .ValueMember = "IDPancang"
                .SelectedIndex = -1
            End With
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        Me.Cursor = Cursors.WaitCursor

        Dim dt As DataTable = New DataTable
        Dim connection As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sql As String = ""

        fg.Clear()
        fg.Row = 0
        fg.Col = 0
        fg.DataSource = Nothing
        fg.Clear(C1.Win.C1FlexGrid.ClearFlags.Content)

        DS.Clear()
        DS.Tables.Clear()
        DS.Tables.Clear()

        With fg
            .Styles.Normal.WordWrap = True

            .Rows.Fixed = 1
            .Cols.Fixed = 1
            .Cols.Frozen = 4

            .AutoGenerateColumns = True
            .Rows(0).AllowMerging = True
            .Rows(1).AllowMerging = True
            .Styles.Normal.WordWrap = True
            .AllowEditing = False

            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular)
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .AllowMerging = AllowMergingEnum.RestrictAll

            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

            .Rows(0).TextAlign = TextAlignEnum.CenterCenter
        End With

        connection = New SqlConnection("server=192.168.12.5; database=RMPAPP; user=UKoneksi; password=sm@rt2018;  MultipleActiveResultSets=True; connect timeout=0;Max Pool Size=500000  ;")

        Dim filter As String
        filter = filter & IIf(CmbPancang.Text <> "", " and idpancang=" & CmbPancang.SelectedValue & " ", "")
        filter = filter & IIf(CmbKapal.Text <> "", " and idkapal=" & CmbKapal.SelectedValue & " ", "")
        If rdAll.Checked = True Then
            filter = filter & " and (Approval=1 or NonActive=0) "
        ElseIf rdBelumDoking.Checked = True Then
            filter = filter & " and (NonActive=0) and TglPerencanaan <= cast(getdate() as date) "
        ElseIf rdSudahDoking.Checked = True Then
            filter = filter & " and (NonActive=0) and TglPerencanaan >= cast(getdate() as date) "
        End If

        If ChkHistory.Checked = True Then
            sql = "DECLARE @cols AS NVARCHAR(MAX)
                    DECLARE @query AS NVARCHAR(MAX)
                    DECLARE @Tgl1 AS DATE 
                    SET @Tgl1 = CAST('" & Format(Dtp1.Value, "yyyy-MM-dd") & "' AS DATE)
                    DECLARE @Tgl2 AS DATE
                    SET @Tgl2 = CAST('" & Format(Dtp2.Value, "yyyy-MM-dd") & "' AS DATE)
                    DECLARE @Name TABLE (
                        Name varchar(50)
                    )

                    ;WITH d(Nama) AS (
                        SELECT DATENAME(MONTH, DATEADD(MONTH, number, @Tgl1)) + ' ' + CAST(YEAR(DATEADD(MONTH, number, @Tgl1)) AS VARCHAR(4))
                        FROM master..spt_values
                        WHERE type = 'P' AND number BETWEEN 0 AND DATEDIFF(MONTH, @Tgl1, @Tgl2)
                    )

                    INSERT INTO @Name
                    SELECT d.Nama FROM d

                    SET @cols = STUFF((SELECT  ',' + QUOTENAME(n.Name) 
                    FROM @Name AS n
                    FOR XML PATH(''), TYPE
                    ).value('.', 'NVARCHAR(MAX)'), 1, 1, '')
                
                    SET @query = N'
                    ;WITH 
                    tabuangmakan (Pancang,NamaKapal,Frekuensi,CreatedDate,TglPerencanaan,tgl,Status,No,idpancang,idkapal) AS (
                        select Pancang,NamaKapal,cast(Frekuensi as varchar(2))+'' Bulan'' as Frekuensi,CreatedDate,TglPerencanaan,cast(Format(TglPerencanaan,''MMMM yyyy'') as varchar(20)) as tgl,''P'' as Status,''1'' as No,idpancang,idkapal
                        from TblTrnDokingKapal where (StatusRestore is null or StatusRestore=0)  and idkapal in ( select KapalID from tblMstKapal where NonActive=0 )  " & filter & "
	                    union
                        select Pancang,NamaKapal,cast(Frekuensi as varchar(2))+'' Bulan'' as Frekuensi,CreatedDate,TglToleransi,cast(Format(TglToleransi,''MMMM yyyy'') as varchar(20)) as tgl,''T'' as Status,''2'' as No,idpancang,idkapal
                        from TblTrnDokingKapal where (StatusRestore is null or StatusRestore=0) and idkapal in ( select KapalID from tblMstKapal where NonActive=0 )  " & filter & "
	                    union
                        select Pancang,NamaKapal,cast(Frekuensi as varchar(2))+'' Bulan'' as Frekuensi,CreatedDate,TglRealisasi,cast(Format(TglRealisasi,''MMMM yyyy'') as varchar(20)) as tgl,''R'' as Status,''3'' as No,idpancang,idkapal
                        from TblTrnDokingKapal where (StatusRestore is null or StatusRestore=0) and idkapal in ( select KapalID from tblMstKapal where NonActive=0 )  " & filter & "
	                    union
                        select Pancang,NamaKapal,cast(Frekuensi as varchar(2))+'' Bulan'' as Frekuensi,CreatedDate,TglApproval,cast(Format(TglApproval,''MMMM yyyy'') as varchar(20)) as tgl,''A'' as Status,''4'' as No,idpancang,idkapal
                        from TblTrnDokingKapal where (StatusRestore is null or StatusRestore=0) and idkapal in ( select KapalID from tblMstKapal where NonActive=0 )  " & filter & "
                    ),datauangmakan AS (
	                    SELECT * from tabuangmakan 
                    ),data as (
	                    SELECT * FROM datauangmakan PIVOT ( MAX(TglPerencanaan) FOR tgl IN (' + @cols + ') ) AS pvtlemburr 
                    )
                    select * from data order by NamaKapal,CreatedDate,no asc'

                    EXEC sp_executesql @query"
        Else
            sql = "DECLARE @cols AS NVARCHAR(MAX)
                DECLARE @query AS NVARCHAR(MAX)
                DECLARE @Tgl1 AS DATE 
                SET @Tgl1 = CAST('" & Format(Dtp1.Value, "yyyy-MM-dd") & "' AS DATE)
                DECLARE @Tgl2 AS DATE
                SET @Tgl2 = CAST('" & Format(Dtp2.Value, "yyyy-MM-dd") & "' AS DATE)
                DECLARE @Name TABLE (
                    Name varchar(50)
                )

                ;WITH d(Nama) AS (
                    SELECT DATENAME(MONTH, DATEADD(MONTH, number, @Tgl1)) + ' ' + CAST(YEAR(DATEADD(MONTH, number, @Tgl1)) AS VARCHAR(4))
                    FROM master..spt_values
                    WHERE type = 'P' AND number BETWEEN 0 AND DATEDIFF(MONTH, @Tgl1, @Tgl2)
                )

                INSERT INTO @Name
                SELECT d.Nama FROM d

                SET @cols = STUFF((SELECT  ',' + QUOTENAME(n.Name) 
                FROM @Name AS n
                FOR XML PATH(''), TYPE
                ).value('.', 'NVARCHAR(MAX)'), 1, 1, '')
                
                SET @query = N'
                ;WITH 
                tabuangmakan (Pancang,NamaKapal,Frekuensi,TglPerencanaan,tgl,Status,No,idpancang,idkapal) AS (
                    select Pancang,NamaKapal,cast(Frekuensi as varchar(2))+'' Bulan'' as Frekuensi,TglPerencanaan,cast(Format(TglPerencanaan,''MMMM yyyy'') as varchar(20)) as tgl,''P'' as Status,''1'' as No,idpancang,idkapal
                    from TblTrnDokingKapal where (StatusRestore is null or StatusRestore=0)  and idkapal in ( select KapalID from tblMstKapal where NonActive=0 ) " & filter & "
                ),
                tabuangmakan2 (Pancang,NamaKapal,Frekuensi,TglToleransi,tgl,Status,No,idpancang,idkapal) AS (
                    select Pancang,NamaKapal,cast(Frekuensi as varchar(2))+'' Bulan'' as Frekuensi,TglToleransi,cast(Format(TglToleransi,''MMMM yyyy'') as varchar(20)) as tgl,''T'' as Status,''2'' as No,idpancang,idkapal
                    from TblTrnDokingKapal where (StatusRestore is null or StatusRestore=0) and idkapal in ( select KapalID from tblMstKapal where NonActive=0 ) " & filter & "
                ),
                tabuangmakan3 (Pancang,NamaKapal,Frekuensi,TglRealisasi,tgl,Status,No,idpancang,idkapal) AS (
                    select Pancang,NamaKapal,cast(Frekuensi as varchar(2))+'' Bulan'' as Frekuensi,TglRealisasi,cast(Format(TglRealisasi,''MMMM yyyy'') as varchar(20)) as tgl,''R'' as Status,''3'' as No,idpancang,idkapal
                    from TblTrnDokingKapal where (StatusRestore is null or StatusRestore=0) and idkapal in ( select KapalID from tblMstKapal where NonActive=0 ) " & filter & "
                ),
                tabuangmakan4 (Pancang,NamaKapal,Frekuensi,TglApproval,tgl,Status,No,idpancang,idkapal) AS (
                    select Pancang,NamaKapal,cast(Frekuensi as varchar(2))+'' Bulan'' as Frekuensi,TglApproval,cast(Format(TglApproval,''MMMM yyyy'') as varchar(20)) as tgl,''A'' as Status,''4'' as No,idpancang,idkapal
                    from TblTrnDokingKapal where (StatusRestore is null or StatusRestore=0) and idkapal in ( select KapalID from tblMstKapal where NonActive=0 ) " & filter & "
                ),
                    
                    

                datauangmakan AS (
                SELECT * from tabuangmakan
                ),
                datauangmakan2 AS (
                SELECT * from tabuangmakan2
                ),
                datauangmakan3 AS (
                SELECT * from tabuangmakan3
                ),
                datauangmakan4 AS (
                SELECT * from tabuangmakan4
                ),

                data as (
                SELECT * FROM datauangmakan PIVOT ( MAX(TglPerencanaan) FOR tgl IN (' + @cols + ') ) AS pvtlemburr 
                union
                SELECT * FROM datauangmakan2 PIVOT ( MAX(TglToleransi) FOR tgl IN (' + @cols + ') ) AS pvtlemburr 
                union
                SELECT * FROM datauangmakan3 PIVOT ( MAX(TglRealisasi) FOR tgl IN (' + @cols + ') ) AS pvtlemburr 
                union
                SELECT * FROM datauangmakan4 PIVOT ( MAX(TglApproval) FOR tgl IN (' + @cols + ') ) AS pvtlemburr)
                select * from data order by NamaKapal,No asc'

                EXEC sp_executesql @query"
        End If

        Try

            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)
            connection.Open()
            adapter = New SqlDataAdapter(sql, connection)
            adapter.Fill(DS)
            connection.Close()

            If ChkHistory.Checked = True Then
                DS.Tables(0).Columns.Remove("CreatedDate")
            End If

            fg.DataSource = DS.Tables(0)

            With fg
                'yang(p, t, r, a) nya null,ga di tampilkan
                Dim FlagNull As Integer = 1
                Dim l As Integer = 1
                For i = 1 To .Rows.Count - 1
                    For k = 8 To .Cols.Count - 1
                        If Not IsDBNull(.Item(l, k)) Then
                            FlagNull = 0
                        End If
                    Next

                    If i Mod 4 = 0 Then
                        If FlagNull = 1 Then
                            .RemoveItem(l)
                            .RemoveItem(l - 1)
                            .RemoveItem(l - 2)
                            .RemoveItem(l - 3)

                            l -= 4
                        End If

                        FlagNull = 1
                    End If
                    l += 1
                Next

                'warnai baris
                Try
                    Dim Warna As Integer = 1
                    For i = 1 To fg.Rows.Count - 1
                        If Warna = 1 Then
                            fg.Rows(i).StyleNew.BackColor = Color.FromArgb(192, 192, 192)
                            fg.Rows(i).StyleNew.ForeColor = Color.Black
                        ElseIf Warna = 0 Then
                            fg.Rows(i).StyleNew.BackColor = Color.White
                            fg.Rows(i).StyleNew.ForeColor = Color.Black
                        End If
                        If i Mod 4 = 0 Then
                            If Warna = 1 Then
                                Warna = 0
                            ElseIf Warna = 0 Then
                                Warna = 1
                            End If
                        End If
                    Next
                Catch ex As Exception
                End Try

                'mengatur no baris
                .Item(0, 0) = "No"
                Dim j As Integer = 1
                For i = 1 To .Rows.Count - 1
                    .Item(i, 0) = j
                    If i Mod 4 = 0 Then
                        j += 1
                    End If
                Next

                'warnai cell
                For i = 1 To .Rows.Count - 1
                    For j = 8 To .Cols.Count - 1
                        If Not IsDBNull(.Item(i, j)) Then
                            If .Item(i, 4) = "P" Then
                                cell = .GetCellRange(i, j, i, j)
                                cell.StyleNew.BackColor = Color.FromArgb(255, 255, 128)
                            ElseIf .Item(i, 4) = "T" Then
                                cell = .GetCellRange(i, j, i, j)
                                cell.StyleNew.BackColor = Color.FromArgb(128, 255, 128)
                            ElseIf .Item(i, 4) = "R" Then
                                cell = .GetCellRange(i, j, i, j)
                                cell.StyleNew.BackColor = Color.FromArgb(128, 128, 255)
                            ElseIf .Item(i, 4) = "A" Then
                                cell = .GetCellRange(i, j, i, j)
                                cell.StyleNew.BackColor = Color.FromArgb(255, 128, 128)
                            End If
                        End If
                    Next
                Next

                'sembunyikan kolom ga perlu
                .Cols(5).Visible = False
                .Cols(6).Visible = False
                .Cols(7).Visible = False
                .Cols(0).AllowMerging = True
                .Cols(1).AllowMerging = True
                .Cols(2).AllowMerging = True
                .Cols(1).TextAlign = TextAlignEnum.LeftCenter
                .Cols(2).TextAlign = TextAlignEnum.LeftCenter
                .Cols(3).AllowMerging = True
                .Cols(4).TextAlign = TextAlignEnum.CenterCenter
            End With

            fg.AutoSizeCols()
        Catch ex As Exception

        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Dim topColor As Color = Color.FromArgb(0, 172, 251) ' Warna atas yang tebal
        Dim bottomColor As Color = Color.FromArgb(0, 0, 255, 255) ' Warna bawah yang pudar

        Dim gradientRect As New Rectangle(0, 0, Panel1.Width, Panel1.Height)

        Using brush As New Drawing2D.LinearGradientBrush(gradientRect, topColor, bottomColor, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(brush, gradientRect)
        End Using
    End Sub

    Private Sub BtnRealisasi_Click(sender As Object, e As EventArgs) Handles BtnRealisasi.Click
        FrmMain.BukaMenu(FrmTrnDokingKapalRealisasi, FrmMain.mnuMonKapalKapalDocking)
    End Sub

    Private Sub BtnPerencanaan_Click(sender As Object, e As EventArgs) Handles BtnPerencanaan.Click
        FrmTrnDokingKapalPerencanaan.Show()
    End Sub

    Private Sub BtnApproval_Click(sender As Object, e As EventArgs) Handles BtnApproval.Click
        FrmTrnDokingKapalApproval.Show()
    End Sub

    Private Sub BtnMon_Click(sender As Object, e As EventArgs) Handles BtnMon.Click
        FrmMain.BukaMenu(FrmMonDokingKapal, FrmMain.mnuMonKapalKapalDocking)
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub B_Click(sender As Object, e As EventArgs) Handles B.Click
        Try
            Dim filename As String
            Me.SaveFileDialog1.ShowDialog()
            filename = SaveFileDialog1.FileName
            Me.fg.SaveExcel(filename & ".xlsx", "Sheet1", FileFlags.IncludeFixedCells)
            MsgBox("Convert Success !", MsgBoxStyle.Information, AT)
        Catch ex As Exception
            MsgBox("Convert Gagal !", vbInformation, ex)
        End Try
    End Sub

    Private Sub CmbPancang_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbPancang.SelectedValueChanged
        Try
            Dim dt As DataTable = New DataTable()
            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select KapalID,KapalName = Convert(Varchar(5),KapalID) + '. ' + KapalName from tblMstKapal where IDPancang='" & CmbPancang.SelectedValue & "' and KapalID in (select distinct IdKapal from TblTrnDokingKapal where NonActive=0)")
            With CmbKapal
                .DataSource = dt
                .DisplayMember = "KapalName"
                .ValueMember = "KapalID"
                .SelectedIndex = -1
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CmbPancang_KeyUp(sender As Object, e As KeyEventArgs) Handles CmbPancang.KeyUp
        UI.AutoCompleteCombo_KeyUp(CmbPancang, e)
    End Sub

    Private Sub CmbKapal_KeyUp(sender As Object, e As KeyEventArgs) Handles CmbKapal.KeyUp
        UI.AutoCompleteCombo_KeyUp(CmbKapal, e)
    End Sub

    Private Sub BtnRestore_Click(sender As Object, e As EventArgs) Handles BtnRestore.Click
        FrmTrnRestorDokingKapal.Show()
    End Sub

    Private Sub fg_AfterSelChange(sender As Object, e As RangeEventArgs) Handles fg.AfterSelChange
        With fg
            For i = 1 To .Rows.Count - 1
                For j = 8 To .Cols.Count - 1
                    If Not IsDBNull(.Item(i, j)) Then
                        cell = .GetCellRange(i, j, i, j)
                        cell.StyleNew.BackColor = Color.White
                    End If
                Next
            Next

            'warnai cell
            For i = 1 To .Rows.Count - 1
                For j = 8 To .Cols.Count - 1
                    If Not IsDBNull(.Item(i, j)) Then
                        If .Item(i, 4) = "P" Then
                            cell = .GetCellRange(i, j, i, j)
                            cell.StyleNew.BackColor = Color.FromArgb(255, 255, 128)
                        ElseIf .Item(i, 4) = "T" Then
                            cell = .GetCellRange(i, j, i, j)
                            cell.StyleNew.BackColor = Color.FromArgb(128, 255, 128)
                        ElseIf .Item(i, 4) = "R" Then
                            cell = .GetCellRange(i, j, i, j)
                            cell.StyleNew.BackColor = Color.FromArgb(128, 128, 255)
                        ElseIf .Item(i, 4) = "A" Then
                            cell = .GetCellRange(i, j, i, j)
                            cell.StyleNew.BackColor = Color.FromArgb(255, 128, 128)
                        End If
                    End If
                Next
            Next
        End With
    End Sub

    Private Sub fg_AfterSort(sender As Object, e As SortColEventArgs) Handles fg.AfterSort
        With fg
            For i = 1 To .Rows.Count - 1
                For j = 8 To .Cols.Count - 1
                    cell = .GetCellRange(i, j, i, j)
                    cell.StyleNew.BackColor = Color.White
                Next
            Next

            'warnai cell
            For i = 1 To .Rows.Count - 1
                For j = 8 To .Cols.Count - 1
                    If Not IsDBNull(.Item(i, j)) Then
                        If .Item(i, 4) = "P" Then
                            cell = .GetCellRange(i, j, i, j)
                            cell.StyleNew.BackColor = Color.FromArgb(255, 255, 128)
                        ElseIf .Item(i, 4) = "T" Then
                            cell = .GetCellRange(i, j, i, j)
                            cell.StyleNew.BackColor = Color.FromArgb(128, 255, 128)
                        ElseIf .Item(i, 4) = "R" Then
                            cell = .GetCellRange(i, j, i, j)
                            cell.StyleNew.BackColor = Color.FromArgb(128, 128, 255)
                        ElseIf .Item(i, 4) = "A" Then
                            cell = .GetCellRange(i, j, i, j)
                            cell.StyleNew.BackColor = Color.FromArgb(255, 128, 128)
                        End If
                    End If
                Next
            Next
        End With
    End Sub
End Class