Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports DocumentFormat.OpenXml.Math

Public Class FrmMonPemeriksaanKapal
    Private data(,) As String
    Dim cell As CellRange
    Private Sub FrmMonPemeriksaanKapal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtp1.Value = Now
        dtp2.Value = Now

        Modul_RMP.Combo.SetPancang(CmbPancang)
        Modul_RMP.Combo.SetKapal(CmbKapal)

        showdata()
    End Sub
    Private Sub showdata()
        Me.Cursor = Cursors.WaitCursor

        Dim dt As DataTable = New DataTable
        Dim connection As SqlConnection
        Dim adapter As SqlDataAdapter
        Dim sql As String = ""
        Dim rowfg, colfg As Integer
        Dim filter As String

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
            .Cols.Frozen = 10
            .AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free
            .Cols(3).AllowMerging = True
            .Cols(5).AllowMerging = True
            .AllowEditing = False
            .AllowMerging = True
        End With

        connection = New SqlConnection("server=192.168.12.5; database=RMPApp; user=uKoneksi; password=sm@rt2018;  MultipleActiveResultSets=True; connect timeout=0;Max Pool Size=500000  ;")

        filter = " (cast(a.created_date as date) between cast(''" & Format(dtp1.Value, "yyyy-MM-dd") & "'' as date) and cast(''" & Format(dtp2.Value, "yyyy-MM-dd") & "'' as date)) "
        filter = filter & IIf(CmbPancang.Text <> "", " and a.pancang_id=" & CmbPancang.SelectedValue & " ", "")
        filter = filter & IIf(CmbKapal.Text <> "", " and a.kapal_id=" & CmbKapal.SelectedValue & " ", "")

        If rd1.Checked = True Then
            filter = filter & " and a.id in (select PemeriksaanKapalID from RMPApp..tblMstKapal where PemeriksaanKapalID > 0 and NonActivePemeriksaan = 0 ) "
        ElseIf rd2.Checked = True Then
            filter = filter & " and a.id in (select PemeriksaanKapalID from RMPApp..tblMstKapal where PemeriksaanKapalID > 0 and NonActivePemeriksaan = 1 ) "
        End If

        sql = "DECLARE @cols AS NVARCHAR(MAX)
                DECLARE @query AS NVARCHAR(MAX)
                DECLARE @Name TABLE (
                    Name varchar(50)
                )

                ;WITH d(Name) AS (
                    SELECT nama FROM RMPApp..Android_tblPemeriksaanKapalMst where deleted_by is null
                )

                INSERT INTO @Name
                SELECT d.Name FROM d
                SET @cols = STUFF((SELECT  ',' + QUOTENAME(n.Name) 
                FROM @Name AS n
                GROUP BY n.Name
                ORDER BY n.Name ASC
                FOR XML PATH(''), TYPE
                ).value('.', 'NVARCHAR(MAX)'), 1, 1, '')

                SET @query = '
                ;WITH 
                dermaga as (			
	                select 
		                a.DermagaName as dermaga,c.DetailidAntrian as antrian
	                from 
		                [192.168.13.28].[RSUPAccounting].[dbo].[tblRMMstDermaga] as a inner join	
		                [192.168.13.28].[RSUPAccounting].[dbo].[TblTrnNotaTimbangan] as b on a.DermagaID=b.DermagaID inner join						
		                [192.168.13.28].[RSUPAccounting].[dbo].[TblTrnKapal] as c on b.RegKapal=c.No inner join
		                RMPApp..Android_tblBookingKapalMuat as d on c.DetailidAntrian=d.BookingID
	                group by 
		                a.DermagaName,c.DetailidAntrian
	                union
	                SELECT 
		                B.ReceivingStation  as dermaga,A.DetailID as antrian
	                FROM 
		                [192.168.2.3].[PSGRMP].[dbo].[tblAndroidBookingAntrian] A inner JOIN 
		                [192.168.2.3].[PSGRMP].[dbo].[tblTransNotaTimbang_forPancang] B on A.DetailID = B.DetailID
	                group by 
		                B.ReceivingStation,A.DetailID
                ),

                tabuangmakan (Trip, Kapal_Name, Pancang,  nama,dtl,created_by,created_date,close_by,close_date,catatan,Dermaga,Note) AS (
                    select 
	                    a.TripID AS Trip,
                        a.KapalName,
                        a.Pancang,
                        a.nama,
                        a.kelayakan + ''@'' + ISNULL(a.keterangan, '''') + ''@'' + ISNULL(a.nama_foto, '''') + ''@'' + CAST(a.booking_id AS VARCHAR(10)) AS dtl,
                        a.created_by,
                        CAST(a.created_date AS DATE) AS created_date,
                        ISNULL(a.close_by, '''') AS close_by,
                        CAST(a.close_date AS DATE) AS close_date,
                        a.catatan,
                        c.dermaga,
	                    '''' AS Note
                    from 
	                    RMPApp..vwMonPemeriksaanKapal as a inner join
	                    RMPApp..Android_tblBookingKapalMuat as b on a.booking_id=b.DetailID Left join 
	                    (select * from dermaga) as c on b.BookingID=c.antrian
                    WHERE 
                        " & filter & "
                ),

                datauangmakan AS (
                SELECT * from tabuangmakan
                )

                SELECT * FROM datauangmakan
                PIVOT (
                    MAX(dtl) FOR nama IN (' + @cols + ')
                ) AS pvtlemburr order by Kapal_Name,created_date desc'

                EXEC(@query)"

        Try

            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)
            connection.Open()
            adapter = New SqlDataAdapter(sql, connection)
            adapter.Fill(DS)
            connection.Close()
            fg.DataSource = DS.Tables(0)

            rowfg = fg.Rows.Count
            colfg = fg.Cols.Count

            data = New String(rowfg - 2, ((colfg - 11) * 4) - 1) {}

            Dim stringarray As String
            For i = 1 To fg.Rows.Count - 1
                stringarray = ""
                For j = 11 To fg.Cols.Count - 1
                    If j = colfg Then
                        stringarray = stringarray & IIf(IsDBNull(fg.Item(i, j)), "Null@@@0", fg.Item(i, j))
                    Else
                        stringarray = stringarray & IIf(IsDBNull(fg.Item(i, j)), "Null@@@0", fg.Item(i, j)) & "@"
                    End If
                Next
                Dim values() As String = stringarray.Split("@"c)
                For k = 0 To ((colfg - 11) * 4) - 1
                    data(i - 1, k) = values(k)
                Next
            Next

            Dim l As Integer = 0
            Dim m As Integer = 2
            For i = 1 To fg.Rows.Count - 1
                l = 0
                m = 2
                For J = 11 To fg.Cols.Count - 1
                    fg.Item(i, J) = data(i - 1, l)
                    If fg.Item(i, J) = "Layak" Then
                        Dim style As C1.Win.C1FlexGrid.CellStyle = fg.Styles.Add("style")
                        style.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
                        fg.SetCellImage(i, J, My.Resources.check2)
                        fg.SetCellStyle(i, J, style)
                    ElseIf fg.Item(i, J) = "Tidak Layak" Then
                        Dim style As C1.Win.C1FlexGrid.CellStyle = fg.Styles.Add("style")
                        style.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
                        fg.SetCellImage(i, J, My.Resources.Cancel)
                        fg.SetCellStyle(i, J, style)
                    End If
                    l += 4

                    If fg.Item(i, J) = "Layak" And data(i - 1, m) <> "" Then
                        Dim style As C1.Win.C1FlexGrid.CellStyle = fg.Styles.Add("style")
                        style.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
                        fg.SetCellImage(i, J, My.Resources.CheckAndCamera)
                        fg.SetCellStyle(i, J, style)
                    ElseIf fg.Item(i, J) = "Tidak Layak" And data(i - 1, m) <> "" Then
                        Dim style As C1.Win.C1FlexGrid.CellStyle = fg.Styles.Add("style")
                        style.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
                        fg.SetCellImage(i, J, My.Resources.CancelAndCamera)
                        fg.SetCellStyle(i, J, style)
                    End If
                    m += 4
                    If fg.Item(i, J) = "Null" Then
                        fg.Item(i, J) = "-"
                    Else
                        fg.Item(i, J) = ""
                    End If
                Next
            Next

            For I = 1 To fg.Rows.Count - 1
                fg.Item(0, 0) = "No"
                fg.Item(I, 0) = I

                Dim style As C1.Win.C1FlexGrid.CellStyle = fg.Styles.Add("style")
                style.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
                fg.SetCellImage(I, 10, My.Resources.Doc1)
                fg.SetCellStyle(I, 10, style)
            Next

            fg.Cols(8).Visible = False

            fg.Cols(1).AllowMerging = True
            fg.Cols(2).AllowMerging = True
            fg.Cols(3).AllowMerging = True

            fg.Cols(0).TextAlign = TextAlignEnum.CenterCenter
            fg.Cols(1).TextAlign = TextAlignEnum.CenterCenter
            fg.Cols(5).TextAlign = TextAlignEnum.CenterCenter
            fg.Rows(0).TextAlign = TextAlignEnum.CenterCenter

            For J = 11 To fg.Cols.Count - 1
                fg.Cols(J).TextAlign = TextAlignEnum.CenterCenter
            Next

            fg.AutoSizeCols()
        Catch ex As Exception

        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        showdata()
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click
        With fg
            Dim r As Integer = fg.Row
            Dim c As Integer = fg.Col

            Try
                If .Rows.Count > 1 Then
                    If c > 10 Then
                        If data(r - 1, (((c - 11) * 4) + 2)) <> "" Then
                            If Application.OpenForms.OfType(Of FrmRptViewFoto)().Any() Then
                                FrmRptViewFoto.Close()
                            End If
                            FrmRptViewFoto.FileName = data(r - 1, (((c - 11) * 4) + 2))
                            FrmRptViewFoto.formName = "FrmMonPemeriksaanKapal"
                            'FrmRptViewFoto.Note = data(r - 1, (((c - 11) * 4) + 1))
                            FrmRptViewFoto.Show()
                        Else
                            MsgBox("Foto Tidak Ada !", vbInformation, AT)
                        End If
                    ElseIf c = 10 Then
                        MsgBox(.Item(r, c - 2), vbInformation, AT)
                    End If
                End If
            Catch ex As Exception

            End Try
        End With
    End Sub

    Private Sub B_Click(sender As Object, e As EventArgs) Handles B.Click
        Try
            Dim filename As String
            Me.SaveFileDialog1.ShowDialog()
            filename = SaveFileDialog1.FileName
            Me.fg.SaveExcel(filename & ".xls", "Sheet1", FileFlags.IncludeFixedCells)
            MsgBox("Convert Success !", MsgBoxStyle.Information, AT)
        Catch ex As Exception
            MsgBox("Convert Gagal !", vbInformation, ex)
        End Try
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub rd2_CheckedChanged(sender As Object, e As EventArgs) Handles rd2.CheckedChanged
        showdata()
    End Sub

    Private Sub rd1_CheckedChanged(sender As Object, e As EventArgs) Handles rd1.CheckedChanged, RdAll.CheckedChanged
        showdata()
    End Sub
End Class