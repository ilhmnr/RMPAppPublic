Imports System.ComponentModel
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmMonRelasiLoyal
    Dim nm As String
    Dim ClsRelasiLoyal_ As New ClsRelasiLoyal
    Dim adapter As SqlDataAdapter
    Dim connetionString As String
    Dim connection As SqlConnection
    Dim sumbrutoperrelasi As Double

    Dim TotalAllMonth As Double

    Dim TotalPerKK As Double
    Dim TotalPerPancang As Double

    Dim lopkk As Integer
    Dim loppcg As Integer
    Dim intensitas As Integer
    Private Sub FrmFrmMonRelasiLoyal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        nm = "12"

        UI.ClearText(grpFilterData)
        HeaderFG()
        schKg()
        chkYear.Checked = True
    End Sub

    Private Sub ShowData()
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Try
            Dim sqlKg As String = ""
            Dim sqlCrane As String = ""
            Dim sqlButir As String = ""
            Dim diff As Integer

            'ShowDataKg(sqlKg)


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

#Region "Data Kg"
    Private Sub schKg()
        With schfgKg
            .SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
            .SearchDelay = 2
            .Watermark = "Cari Disini"
            .SetC1FlexGridSearchPanel(fgKg, schfgKg)
        End With
    End Sub
#End Region


    Public Sub HeaderFG()

        Dim txt As CellRange
        With fgKg
            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
            .Cols.Count = 29
            .Cols.Fixed = 0
            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            '.Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            '.Styles.Alternate.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)
            '.Rows(0).StyleNew.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular)

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 2
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
        End With
        CELL()
    End Sub


    Private Sub CELL()
        Dim txt As CellRange
        With fgKg


            txt = .GetCellRange(0, 0, 1, 0) : txt.Data = "ID Petani" : .Cols(0).Name = "GroupKK" : .Cols(0).AllowMerging = True : .Cols(0).TextAlign = TextAlignEnum.LeftCenter : .Cols(0).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 1, 1, 1) : txt.Data = "Nama Pemilik Kelapa / SubPetani" : .Cols(1).AllowMerging = True : .Cols(1).Width = 50 : .Cols(1).Name = "NamaSupUM_" : .Cols(1).TextAlign = TextAlignEnum.CenterCenter : .Cols(1).TextAlignFixed = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 2, 1, 2) : txt.Data = "%PerPancang" : .Cols(2).Name = "persenpcg" : .Cols(2).AllowMerging = True : .Cols(2).Width = 160 : .Cols(2).TextAlign = TextAlignEnum.CenterCenter : .Cols(2).Format = "#.##%" : .Cols(2).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(2).Visible = False


            txt = .GetCellRange(0, 3, 1, 3) : txt.Data = "GroupKK" : .Cols(3).Name = "IDSubPetani2" : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).AllowMerging = True : .Cols(3).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(3).Visible = False
            txt = .GetCellRange(0, 4, 1, 4) : txt.Data = "Nama KK" : .Cols(4).Name = "NamaSup2" : .Cols(4).TextAlign = TextAlignEnum.LeftCenter : .Cols(4).AllowMerging = True : .Cols(4).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(4).Visible = False


            txt = .GetCellRange(0, 5, 1, 5) : txt.Data = "" : .Cols(5).Name = "IDSubPetani" : .Cols(5).TextAlign = TextAlignEnum.LeftCenter : .Cols(5).AllowMerging = True : .Cols(5).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(5).Visible = False
            txt = .GetCellRange(0, 6, 1, 6) : txt.Data = "" : .Cols(6).Name = "NamaSup" : .Cols(6).TextAlign = TextAlignEnum.LeftCenter : .Cols(6).AllowMerging = True : .Cols(6).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(6).Visible = False
            txt = .GetCellRange(0, 7, 1, 7) : txt.Data = "IDPenerimaUang" : .Cols(7).Name = "IDPenerimaUang" : .Cols(7).TextAlign = TextAlignEnum.LeftCenter : .Cols(7).AllowMerging = True : .Cols(7).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 8, 1, 8) : txt.Data = "Penerima Uang" : .Cols(8).Name = "PenerimaUang" : .Cols(8).TextAlign = TextAlignEnum.LeftCenter : .Cols(8).AllowMerging = True : .Cols(8).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 9, 1, 9) : txt.Data = "Alamat" : .Cols(9).Width = 50 : .Cols(9).TextAlign = TextAlignEnum.LeftCenter : .Cols(9).AllowMerging = True : .Cols(9).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 10, 1, 10) : txt.Data = "Pancang" : .Cols(10).TextAlign = TextAlignEnum.LeftCenter : .Cols(10).AllowMerging = True : .Cols(10).Width = 180 : .Cols(10).TextAlignFixed = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 11, 1, 11) : txt.Data = "%PerPancang" : .Cols(11).Name = "persenpcg" : .Cols(11).AllowMerging = True : .Cols(11).Width = 180 : .Cols(11).TextAlign = TextAlignEnum.CenterCenter : .Cols(11).Format = "####%" : .Cols(11).TextAlignFixed = TextAlignEnum.CenterCenter


            txt = .GetCellRange(0, 12, 0, 23) : txt.Data = "Bulan" : .Cols(12).TextAlign = TextAlignEnum.CenterCenter : .Cols(12).AllowMerging = True : .Cols(12).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 12, 1, 12) : txt.Data = "Januari" : .Cols(12).TextAlign = TextAlignEnum.RightCenter : .Cols(12).AllowMerging = True : .Cols(12).Format = "#,###0" : .Cols(12).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 13, 1, 13) : txt.Data = "Februari" : .Cols(13).TextAlign = TextAlignEnum.RightCenter : .Cols(13).AllowMerging = True : .Cols(13).Format = "#,###0" : .Cols(13).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 14, 1, 14) : txt.Data = "Maret" : .Cols(14).TextAlign = TextAlignEnum.RightCenter : .Cols(14).AllowMerging = True : .Cols(14).Format = "#,###0" : .Cols(14).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 15, 1, 15) : txt.Data = "April" : .Cols(15).TextAlign = TextAlignEnum.RightCenter : .Cols(15).AllowMerging = True : .Cols(15).Format = "#,###0" : .Cols(15).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 16, 1, 16) : txt.Data = "Mei" : .Cols(16).TextAlign = TextAlignEnum.RightCenter : .Cols(16).AllowMerging = True : .Cols(16).Format = "#,###0" : .Cols(16).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 17, 1, 17) : txt.Data = "Juni" : .Cols(17).TextAlign = TextAlignEnum.RightCenter : .Cols(17).AllowMerging = True : .Cols(17).Format = "#,###0" : .Cols(17).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 18, 1, 18) : txt.Data = "Juli" : .Cols(18).TextAlign = TextAlignEnum.RightCenter : .Cols(18).AllowMerging = True : .Cols(18).Format = "#,###0" : .Cols(18).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 19, 1, 19) : txt.Data = "Agustus" : .Cols(19).TextAlign = TextAlignEnum.RightCenter : .Cols(19).AllowMerging = True : .Cols(19).Format = "#,###0" : .Cols(19).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 20, 1, 20) : txt.Data = "September" : .Cols(20).TextAlign = TextAlignEnum.RightCenter : .Cols(20).AllowMerging = True : .Cols(20).Format = "#,###0" : .Cols(20).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 21, 1, 21) : txt.Data = "Oktober" : .Cols(21).TextAlign = TextAlignEnum.RightCenter : .Cols(21).AllowMerging = True : .Cols(21).Format = "#,###0" : .Cols(21).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 22, 1, 22) : txt.Data = "November" : .Cols(22).TextAlign = TextAlignEnum.RightCenter : .Cols(22).AllowMerging = True : .Cols(22).Format = "#,###0" : .Cols(22).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 23, 1, 23) : txt.Data = "Desember" : .Cols(23).TextAlign = TextAlignEnum.RightCenter : .Cols(23).AllowMerging = True : .Cols(23).Format = "#,###0" : .Cols(23).TextAlignFixed = TextAlignEnum.CenterCenter


            txt = .GetCellRange(0, 24, 1, 24) : txt.Data = "Total" : .Cols(24).Name = "Total" : .Cols(24).Width = 120 : .Cols(24).AllowMerging = True : .Cols(24).Format = "#,###0" : .Cols(24).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 25, 1, 25) : txt.Data = "Intensitas" : .Cols(25).Name = "Intensitas" : .Cols(25).Width = 120 : .Cols(25).AllowMerging = True : .Cols(25).Format = "#,###0" : .Cols(25).TextAlignFixed = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 26, 0, 28) : txt.Data = "Min/Max" : .Cols(27).AllowMerging = True
            txt = .GetCellRange(1, 26, 1, 26) : txt.Data = "Min" : .Cols(26).Width = 50 : .Cols(26).Name = "Min_" : .Cols(26).AllowMerging = True : .Cols(26).Format = "#,###0" : .Cols(26).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 27, 1, 27) : txt.Data = "Rata-Rata" : .Cols(27).Name = "Average" : .Cols(27).Width = 120 : .Cols(27).AllowMerging = True : .Cols(27).Format = "#,###0" : .Cols(27).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 28, 1, 28) : txt.Data = "Max" : .Cols(28).Width = 50 : .Cols(28).Name = "max_" : .Cols(28).AllowMerging = True : .Cols(28).Format = "#,###0" : .Cols(28).TextAlignFixed = TextAlignEnum.CenterCenter

            .AutoSizeCols()
        End With

    End Sub
    Private Sub HEADERFG2()
        CELL()
        fgKg.Cols.Frozen = 2
    End Sub
    Public Sub FGColor()
        Dim cs As C1.Win.C1FlexGrid.CellStyle
        cs = fgKg.Styles(C1.Win.C1FlexGrid.CellStyleEnum.GrandTotal)
        'cs.BackColor = Color.FromArgb(73, 173, 8)
        cs.BackColor = Color.FromArgb(58, 106, 148)
        cs.ForeColor = Color.White
        cs.Font = New Font(Font, FontStyle.Bold)

        cs = fgKg.Styles(C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0)
        'cs.BackColor = Color.FromArgb(81, 161, 243)
        'cs.ForeColor = Color.White
        'cs.Font = New Font(Font, FontStyle.Bold)
        cs.BackColor = Color.FromArgb(191, 220, 245)
        cs.ForeColor = Color.Black

        cs = fgKg.Styles(C1.Win.C1FlexGrid.CellStyleEnum.Subtotal1)
        cs.BackColor = Color.AliceBlue
        cs.ForeColor = Color.Black

        'fgKg.AutoSizeCols()
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Call UI.HapusGrid(2, fgKg)
        fgKg.Clear()
        fgKg.Row = 0
        fgKg.Col = 0
        fgKg.DataSource = Nothing
        '
        fgKg.Clear(C1.Win.C1FlexGrid.ClearFlags.Content)
        DS.Clear()
        DS.Tables.Clear()
        DS.Tables.Clear()
        CALLDATA()

    End Sub



    Private Sub BtnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Dim filename As String
        Me.SaveFileDialog.ShowDialog()
        filename = SaveFileDialog.FileName
        Me.fgKg.SaveExcel(filename & ".xls", "Sheet1", FileFlags.IncludeFixedCells)
        MsgBox("Convert Success !", vbInformation, AT)
    End Sub

    Private Sub CALLDATA()

        HeaderFG()
        connetionString = "server=192.168.12.5; database=RSUPAccounting; user=UKoneksi; password=sm@rt2018;  MultipleActiveResultSets=True; connect timeout=0;Max Pool Size=500000  ;"

        connection = New SqlConnection(connetionString)
        Dim sql As String
        'If Now.Year = DOYear.Text Then
        sql = "Declare @periodeyear varchar(4),@cols As NVARCHAR(MAX),@query  As NVARCHAR(MAX) Set @periodeyear='" & DOYear.Text & "'        
                           Declare @dateFrom datetime =@periodeyear+'-01-01', @dateTo datetime =@periodeyear+'-12-31'
							Declare @Workingmonth Table 
		                     (
		                       Wmonth datetime
		                     )
		                    ;with  CTE as (
		                       Select @dateFrom AS cte_start_date
								UNION ALL
                        Select  DATEADD(MONTH, 1, cte_start_date)

									FROM CTE
									WHERE ( DATEADD(MONTH, 1, cte_start_date) <=  EOMONTH( @dateTo)   ) 
		                      )
		                     insert into @Workingmonth						 
							  Select cte_start_date  from CTE
		                     Set @cols = STUFF((Select  ',' +  QUOTENAME(CAST(CONVERT(CHAR(7), Wmonth, 120) AS varchar(7))) 
					                FROM @Workingmonth
					                    For XML PATH(''), TYPE
					                    ).value('.', 'NVARCHAR(MAX)') 
				                    ,1,1,'')

			

		                Set  @query = ';WITH 
						rel as (
						SELECT *
                        FROM    RSUPAccounting..fndatarelasiloyal2023('''+@periodeyear+''')
						),

                         relloy as (SELECT *
                        FROM    rel 
                        PIVOT 
                        (
                            SUM (netto2) 
                            For monthnota IN ('+ @cols +') 
                        ) AS pvtfc
                        ),
						reltotalpancangpetani as (

						SELECT pancang,idpenerimauang,idsubpetani,sum(netto2) as Total
                        FROM    RSUPAccounting..fndatarelasiloyal2023('''+@periodeyear+''')
						group by pancang,idpenerimauang,idsubpetani

						),

						relkodesup as (

						SELECT idsubpetani ,sum(netto2) as nettokodesup
                        FROM    RSUPAccounting..fndatarelasiloyal2023('''+@periodeyear+''')
						group by idsubpetani

						),

						relkodesuppancang  as (

						SELECT pancang,idsubpetani,sum(netto2) as nettokodesuppancang
                        FROM    RSUPAccounting..fndatarelasiloyal2023('''+@periodeyear+''')
						group by pancang,idsubpetani

						)


					   Select b.idsubpetani AS GroupKK ,NamaSup AS NamaSupUM_, c.IDSubPetani AS idsubpetani2,A.NamaSup AS NamaSup2,  round(nettokodesuppancang/	nettokodesup	,2) AS persenpcg,
					  a.* , Total, 0 as Intensitas,0 as Min_, 0 as Average, 0 as max_ 						   
					 From relloy as a left outer join
					 reltotalpancangpetani as b on a.pancang=b.pancang and a.idpenerimauang= b.idpenerimauang and a.idsubpetani=b.idsubpetani left outer join
					 relkodesup as c on a.idsubpetani=c.idsubpetani  left outer join
					 relkodesuppancang as d on a.idsubpetani=d.idsubpetani and a.pancang=d.pancang
					 ORDER BY a.NamaSup,a.idsubpetani asc, 
					 	round(nettokodesuppancang/	nettokodesup	,2) DESC '

					  execute(@query)"

        'Else


        'sql = "Declare @periodeyear varchar(4),@cols As NVARCHAR(MAX),@query  As NVARCHAR(MAX) Set @periodeyear='" & DOYear.Text & "'     
        '                      Declare @dateFrom datetime =@periodeyear+'-01-01', @dateTo datetime =@periodeyear+'-12-31'
        '	Declare @Workingmonth Table 
        '                 (
        '                   Wmonth datetime
        '                 )
        '                ;with  CTE as (
        '                   Select @dateFrom AS cte_start_date
        '		UNION ALL
        '                  Select  DATEADD(MONTH, 1, cte_start_date)

        '			FROM CTE
        '			WHERE ( DATEADD(MONTH, 1, cte_start_date) <=  EOMONTH( @dateTo)   ) 
        '                  )
        '                 insert into @Workingmonth						 
        '	  Select cte_start_date  from CTE
        '                 Set @cols = STUFF((Select  ',' +  QUOTENAME(CAST(CONVERT(CHAR(7), Wmonth, 120) AS varchar(7))) 
        '               FROM @Workingmonth
        '                   For XML PATH(''), TYPE
        '                   ).value('.', 'NVARCHAR(MAX)') 
        '                  ,1,1,'')
        '            Set  @query = ';WITH 
        'rel as (
        'SELECT *
        '                  FROM    RSUPAccounting..fndatarelasiloyal2023('''+@periodeyear+''')
        '),

        '                   relloy as (SELECT *
        '                  FROM    rel
        '                  PIVOT 
        '                  (
        '                      SUM (netto2) 
        '                      For monthnota IN ('+ @cols +')
        '                  ) AS pvtfc
        '                  )
        '                Select KodeSupUM AS GroupKK ,NamaSupUM AS NamaSupUM_, ROUND((Select sum(netto2) From rel where kodesupum=relloy.kodesupum and pancang=relloy.pancang)/(Select sum(netto2) From rel where kodesupum=relloy.kodesupum),2) AS persenpcg,
        ' *, (Select sum(netto2) From rel where IDSubPetani=relloy.IDSubPetani AND IDSubPetani=relloy.IDSubPetani AND PANCANG=relloy.PANCANG AND IDPENERIMAUANG=relloy.IDPENERIMAUANG) as Total ,0 as Intensitas,0 as Min_, 0 as Average, 0 as max_ 					   
        'From relloy ORDER BY  NAMASUPUM,KODESUPUM ASC, 
        '				 ROUND((Select sum(netto2) From rel where kodesupum=relloy.kodesupum 
        '			   and pancang=relloy.pancang)/(Select sum(netto2) From rel where
        '			    kodesupum=relloy.kodesupum),2) DESC '
        ' execute(@query)"

        '  sql = "Declare @periodeyear varchar(4),@cols As NVARCHAR(MAX),@query  As NVARCHAR(MAX) Set @periodeyear='" & DOYear.Text & "'        
        '                      Declare @dateFrom datetime =@periodeyear+'-01-01', @dateTo datetime =@periodeyear+'-12-31'
        '	Declare @Workingmonth Table 
        '                 (
        '                   Wmonth datetime
        '                 )
        '                ;with  CTE as (
        '                   Select @dateFrom AS cte_start_date
        '		UNION ALL
        '                  Select  DATEADD(MONTH, 1, cte_start_date)

        '			FROM CTE
        '			WHERE ( DATEADD(MONTH, 1, cte_start_date) <=  EOMONTH( @dateTo)   ) 
        '                  )
        '                 insert into @Workingmonth						 
        '	  Select cte_start_date  from CTE
        '                 Set @cols = STUFF((Select  ',' +  QUOTENAME(CAST(CONVERT(CHAR(7), Wmonth, 120) AS varchar(7))) 
        '               FROM @Workingmonth
        '                   For XML PATH(''), TYPE
        '                   ).value('.', 'NVARCHAR(MAX)') 
        '                  ,1,1,'')



        '  End If
        Try
            connection.Open()
            adapter = New SqlDataAdapter(sql, connection)
            adapter.Fill(DS)
            connection.Close()
            fgKg.DataSource = DS.Tables(0)

            TotalAllMonth = 0
            TotalPerKK = 0
            TotalPerPancang = 0

            Dim intensitasrelasi, dblHighValue As Double
            Dim maxV As Integer
            Dim minV As Integer

            fgKg.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free
            GrandTotal()
            HEADERFG2()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub


    Private Sub GrandTotal()
        With fgKg
            .Tree.Column = 0
            .Tree.Style = TreeStyleFlags.CompleteLeaf
            .Subtotal(AggregateEnum.Clear)

            For I = 12 To 24
                .Subtotal(AggregateEnum.Sum, -1, -1, I, "TOTAL")
                .Subtotal(AggregateEnum.Sum, 0, 1, I, "{0}")
            Next I
            '.Subtotal(AggregateEnum.Sum, 0, 1, 24)

            .AutoSizeCols()
        End With
        Call FGColor()
    End Sub

    Private Sub fgKg_BeforeEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles fgKg.BeforeEdit
        Dim i As Integer
        For i = 1 To fgKg.Rows.Count - 1

            For a = 0 To fgKg.Col - 1
                If e.Col = a And e.Row = i Then
                    e.Cancel = True
                End If
            Next
        Next
    End Sub

    Private Sub btnkalkulasi_Click(sender As Object, e As EventArgs) Handles btnkalkulasi.Click

        Dim intensitasrelasi, dblHighValue As Double
        Dim maxV As Integer
        Dim minV As Integer


        'fgKg.DataSource.Rows.Count +1
        For i = 2 To fgKg.Rows.Count - 1
            intensitasrelasi = 0
            maxV = 0

            For a = 12 To 23
                If Not IsDBNull(fgKg.Item(i, a)) Then
                    If minV = 0 Then
                        minV = Convert.ToDouble(fgKg.Item(i, a))
                    End If

                    If Convert.ToDouble(fgKg.Item(i, a)) > 0 Then
                        intensitasrelasi = intensitasrelasi + 1
                    End If

                    If Convert.ToDouble(fgKg.Item(i, a)) > maxV And Convert.ToDouble(fgKg.Item(i, a)) > 0 Then
                        maxV = fgKg.Item(i, a)
                    End If

                    If Convert.ToDouble(fgKg.Item(i, a)) < minV And Convert.ToDouble(fgKg.Item(i, a)) > 0 Then
                        minV = fgKg.Item(i, a)
                    Else
                        minV = minV
                    End If
                Else
                    intensitasrelasi = intensitasrelasi
                    maxV = maxV
                    minV = minV
                End If
            Next a

            fgKg.Item(i, "Intensitas") = intensitasrelasi
            fgKg.Item(i, 26) = minV
            fgKg.Item(i, 28) = maxV

            minV = 0
        Next i

        With fgKg

            Dim intensitas
            intensitas = 0

            For a = 12 To 23

                If Not IsDBNull(.Item(2, a)) Then
                    If .Item(2, a) > 0 Then
                        intensitas = intensitas + 1
                    End If
                End If

            Next a

            .Item(2, "Intensitas") = intensitas


            For I = 2 To .Rows.Count - 1
                If Not IsDBNull(.Item(I, 24)) Then
                    If .Item(I, 24) > 0 Then
                        .Item(I, 27) = Math.Round(.Item(I, 24) / intensitas, 0)
                    End If
                End If
            Next

        End With
    End Sub

    Private Sub schfgKg_Load(sender As Object, e As EventArgs) Handles schfgKg.Load

    End Sub
End Class
