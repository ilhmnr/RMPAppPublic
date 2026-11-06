Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmPremiInspektor
    Dim nm As String
    Dim ClsRelasiLoyal_ As New ClsRelasiLoyal
    Dim adapter As SqlDataAdapter
    Dim adapter2 As SqlDataAdapter
    Dim connetionString As String
    Dim connection As SqlConnection
    Private Sub headerfglavelbonus()

        Dim txt As CellRange
        With fglavelbonus
            .AutoGenerateColumns = True
            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
            .Cols.Count = 5
            ''.Cols.Fixed = 2
            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 2
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Rows(1).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            CELL()
            .AutoSizeCols()
        End With
    End Sub

    Private Sub headerfglavelbonusdesc()
        On Error Resume Next

        Dim txt As CellRange
        With fglavelbonusdesc
            .Rows.Count = 1
            .AutoGenerateColumns = True
            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
            .Cols.Count = 10

            ''.Cols.Fixed = 2
            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 1
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            '.Rows(1).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            'CELL()
            .AutoSizeCols()
        End With
    End Sub



    Private Sub headerfgPCG()

        Dim txt As CellRange
        With fgpcg
            .AutoGenerateColumns = True
            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
            .Cols.Count = 12
            ''.Cols.Fixed = 2
            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 2
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Rows(1).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 1, 0) : txt.Data = "Nomor" : .Cols(0).AllowMerging = True : .Cols(0).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 1, 1, 1) : txt.Data = "No Urut Pcg" : .Cols(1).AllowMerging = True : .Cols(1).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 2, 1, 2) : txt.Data = "Nama Pancang" : .Cols(2).AllowMerging = True : .Cols(2).Visible = True : .Cols(2).TextAlign = TextAlignEnum.LeftCenter

            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Netto-2 (Pancang)" : .Cols(3).AllowMerging = True : .Cols(3).Visible = True : .Cols(3).Width = 100 : .Cols(3).Format = "#,###0"
            txt = .GetCellRange(1, 3, 1, 3) : txt.Data = "Kb-A (Kg)" : .Cols(3).AllowMerging = True : .Cols(3).Visible = True : .Cols(3).Width = 100 : .Cols(3).Format = "#,###0"

            txt = .GetCellRange(0, 4, 0, 8) : txt.Data = "Netto-2 (Pabrik)"
            txt = .GetCellRange(1, 4, 1, 4) : txt.Data = "Kb-A (Kg)" : .Cols(4).AllowMerging = True : .Cols(4).Visible = True : .Cols(4).Width = 100 : .Cols(4).Format = "#,###0"
            txt = .GetCellRange(1, 5, 1, 5) : txt.Data = "%" : .Cols(5).AllowMerging = True : .Cols(5).Visible = True : .Cols(5).Width = 100 : .Cols(5).Format = "##.0 %"
            txt = .GetCellRange(1, 6, 1, 6) : txt.Data = "KB-B (Kg)" : .Cols(6).AllowMerging = True : .Cols(6).Visible = True : .Cols(6).Width = 100 : .Cols(6).Format = "#,###0"
            txt = .GetCellRange(1, 7, 1, 7) : txt.Data = "%" : .Cols(7).AllowMerging = True : .Cols(7).Visible = True : .Cols(7).Width = 100 : .Cols(7).Format = "##.0 %"
            txt = .GetCellRange(1, 8, 1, 8) : txt.Data = "Total KB" : .Cols(8).AllowMerging = True : .Cols(8).Visible = True : .Cols(8).Width = 100 : .Cols(8).Format = "#,###0"

            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Susut (Kg)" : .Cols(9).AllowMerging = True : .Cols(9).Visible = True : .Cols(9).Width = 100 : .Cols(9).Format = "#,###0"
            txt = .GetCellRange(1, 9, 1, 9) : txt.Data = "Qty (Kg)" : .Cols(9).AllowMerging = True : .Cols(9).Visible = True : .Cols(9).Width = 100 : .Cols(9).Format = "#,###0"
            txt = .GetCellRange(1, 10, 1, 10) : txt.Data = "%" : .Cols(10).AllowMerging = True : .Cols(10).Visible = True : .Cols(10).Width = 50 : .Cols(10).Format = "##.0 %"




            .AutoSizeCols()
        End With
    End Sub

    Private Sub CELL()

        Dim txt As CellRange
        With fglavelbonus

            txt = .GetCellRange(0, 0, 1, 0) : txt.Data = "IDLavel" : .Cols(0).AllowMerging = True : .Cols(0).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 1, 1, 1) : txt.Data = "Lavel" : .Cols(1).AllowMerging = True : .Cols(1).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 2, 1, 2) : txt.Data = "Range" : .Cols(2).AllowMerging = True : .Cols(2).Visible = True : .Cols(2).TextAlign = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 3, 1, 3) : txt.Data = "RangeMin" : .Cols(3).Name = "RangeMin" : .Cols(3).AllowMerging = True : .Cols(3).Visible = True : .Cols(3).Format = "#,###0"
            txt = .GetCellRange(0, 4, 1, 4) : txt.Data = "RangeMax" : .Cols(4).Name = "RangeMax" : .Cols(4).AllowMerging = True : .Cols(4).Visible = True : .Cols(4).Format = "#,###0"

            ''txt = .GetCellRange(0, 5, 0, 9) : txt.Data = "Rupiah"
            'txt = .GetCellRange(1, 5, 1, 5) : txt.Data = "<100" : .Cols(4).AllowMerging = True : .Cols(4).TextAlign = TextAlignEnum.RightCenter : .Cols(4).Visible = True : .Cols(4).Format = "#,###0"
            'txt = .GetCellRange(1, 6, 1, 6) : txt.Data = "125 MT" : .Cols(5).AllowMerging = True : .Cols(5).TextAlign = TextAlignEnum.RightCenter : .Cols(5).Visible = True : .Cols(5).Format = "#,###0"
            'txt = .GetCellRange(1, 7, 1, 7) : txt.Data = "150 MT" : .Cols(6).AllowMerging = True : .Cols(6).TextAlign = TextAlignEnum.RightCenter : .Cols(6).Visible = True : .Cols(6).Format = "#,###0"
            'txt = .GetCellRange(1, 8, 1, 8) : txt.Data = "175 MT" : .Cols(7).AllowMerging = True : .Cols(7).TextAlign = TextAlignEnum.RightCenter : .Cols(7).Visible = True : .Cols(7).Format = "#,###0"
            'txt = .GetCellRange(1, 9, 1, 9) : txt.Data = ">200" : .Cols(8).AllowMerging = True : .Cols(8).TextAlign = TextAlignEnum.RightCenter : .Cols(8).Visible = True : .Cols(8).Format = "#,###0"
            HEADERADD()
            .AutoSizeCols()
        End With

    End Sub
    Private Sub HEADERADD()
        With fglavelbonus
            Dim txt As CellRange
            Dim x As Integer

            Dim conny As New SqlConnection(StrConnAccounting)
            Dim col As New DataGridViewTextBoxColumn
            Dim sqlx As String

            conny.Open()
            sqlx = "Select * from RMPApp..tblMstLevelMatrixTon where No_Lavel in (select TOP(1)  no_lavel from RMPApp..tblMstLevelMatrixTon where cast(Tgl_Lavel as date)<='" & dttgl.Value.ToString("yyyy-MM-dd") & "' order by idlavel desc) order by idlavel asc  "
            Dim cmdselect As New SqlCommand(sqlx, conny)
            RD = cmdselect.ExecuteReader()
            x = 5

            If RD.HasRows Then
                Do While RD.Read
                    .Cols.Count = fglavelbonus.Cols.Count + 1
                    txt = .GetCellRange(0, 5, 0, x) : txt.Data = "Rupiah" : .Cols(x).Format = "#,###0"
                    txt = .GetCellRange(1, x, 1, x) : txt.Data = RD("Range") : .Cols(x).AllowMerging = True : .Cols(x).TextAlign = TextAlignEnum.RightCenter : .Cols(x).Visible = True : .Cols(x).Format = "#,###0"
                    x = x + 1
                Loop
            End If
            Exit Sub
            conny.Close()
        End With
    End Sub


    Private Sub Mstfgpcg()
        With fgpancang
            Dim txt As CellRange
            Dim x As Integer

            Dim conny As New SqlConnection(StrConnAccounting)
            Dim col As New DataGridViewTextBoxColumn
            Dim sqlx As String

            conny.Open()
            sqlx = "Select IDPancang,Pancang from RMPApp..vwMstPremiPengawasdanInspektorDtl where NoTrans in  (select top(1) notrans from RMPApp..tblMstPremiPengawasdanInspektorHdr where CONVERT(DATETIME, CONVERT(VARCHAR, periode, 103), 103) <=CONVERT(DATETIME, '" & CDate(dttgl.Value) & "', 103) order by periode desc) AND  IDRING='" & cmbring.SelectedValue.ToString & "' "
            Dim cmdselect As New SqlCommand(sqlx, conny)
            RD = cmdselect.ExecuteReader()
            x = 1

            If RD.HasRows Then
                Do While RD.Read
                    .Item(x, 0) = RD("IDPancang")
                    .Item(x, 1) = RD("Pancang")
                    x = x + 1
                Loop
            End If
            Exit Sub
            conny.Close()
        End With
    End Sub


    Private Sub Dtlfgpcg()
        With fgpcg
            Dim txt As CellRange
            Dim x As Integer

            Dim conny As New SqlConnection(StrConnAccounting)
            Dim col As New DataGridViewTextBoxColumn
            Dim sqlx As String

            conny.Open()
            sqlx = "declare @periodemonth varchar(2), @periodeyear varchar(4), @cols AS NVARCHAR(MAX),@cols2 AS NVARCHAR(MAX),@query  AS NVARCHAR(MAX)
		    set @periodeyear= ('" & Year(dttgl.Value) & "')
			set @periodemonth=('" & Month(dttgl.Value) & "')  
            ;with tblKBAPabrik as (SELECT kodesup1   ,namasup1 collate Latin1_General_CI_AS  as  pancang,
             case when right(Grade,1)='a' then  SUM(NETTO) end  as kbaPabrik ,case when right(Grade,1)='b' then  SUM(NETTO) end  as kbbPabrik 
             From vwRMTrnPenerimaanKBDtla 
             Where AsalKelapa like '%" & cmbGrade_KB.Text & "%' AND
             KodeSup1 In (SELECT  kodesup  FROM rmpapp..vwMstPremiPengawasdanInspektorDtl as a
             where  NoTrans In  (Select top(1) notrans from RMPApp..tblMstPremiPengawasdanInspektorHdr 
             where CONVERT(DATETIME, CONVERT(VARCHAR, periode, 103), 103) <=CONVERT(DATETIME, '" & dttgl.Value & "', 103) order by periode desc 
             ) and ring='" & cmbring.Text & "') AND
             month(tglterima)=@periodemonth and year(TglTerima)=@periodeyear 
             group by kodesup1,NAMASUP1,Grade
             union  select kodesup1  collate  Latin1_General_CI_AS,mainsuppliername  as pancang,case when right(jenis,1)='a' then  SUM(NETTO1) end  as kbaPabrik ,
             case when right(jenis,1)='b' then  SUM(NETTO1) end  as kbbPabrik  FROM  [192.168.2.3].[PSGRMP].[dbo].[vwRMTrnPenerimaanKBKgDtlaNew_PCG]  
             WHERE  AsalKelapa like '%" & cmbGrade_KB.Text & "%' AND  kodesup1 In (SELECT  kodesup COLLATE SQL_Latin1_General_CP1_CI_AS  FROM rmpapp..vwMstPremiPengawasdanInspektorDtl as a
             where  NoTrans In  (Select top(1) notrans from RMPApp..tblMstPremiPengawasdanInspektorHdr 
             where CONVERT(DATETIME, CONVERT(VARCHAR, periode, 103), 103) <=CONVERT(DATETIME, '" & dttgl.Value & "', 103) order by periode desc 
             ) and ring='RING 1')
             and month(tglterima)=@periodemonth and year(TglTerima)=@periodeyear
             group by KODEsup1,mainsuppliername,jenis )
             ,  
             tblkb as (	select IDPANCANG, KodeSup1,A.pancang ,sum(kbaPabrik) as kbaPabrik ,sum(kbbpabrik) as  kbbpabrik ,    (select sum(nettoakhir) from[RMPApp].[dbo].[vwtbltrnkelapahdrmainsup]   
             where  DELETED=0 AND JENIS ='" & cmbGrade_KB.Text & "' AND KodeSup=a.KodeSup1  and MONTH(TglTerima)=@periodemonth and year(TglTerima)=@periodeyear   ) as kbpcg
             from tblKBAPabrik as a   
             INNER JOIN  RMPApp..Android_tblMstPancang AS B ON A.KodeSup1=B.KodeSup
             group by kodesup1,a.pancang, IDPANCANG)
             select *, kbapabrik/(kbapabrik+kbbpabrik)as prsnkba,kbbpabrik/(kbapabrik+kbbpabrik) as prsnkbb from  tblkb "

            Dim cmdselect As New SqlCommand(sqlx, conny)
            RD = cmdselect.ExecuteReader()
            x = 2

            If RD.HasRows Then
                Call UI.HapusGrid(2, fgpcg)
                Do While RD.Read
                    .AddItem(x - 1)
                    .Item(x, 0) = x - 1
                    .Item(x, 1) = RD("IDPancang")
                    .Item(x, 2) = RD("Pancang")
                    .Item(x, 3) = RD("kbpcg")
                    .Item(x, 4) = RD("kbapabrik")
                    .Item(x, 5) = RD("prsnkba")
                    .Item(x, 6) = RD("kbbpabrik")
                    .Item(x, 7) = RD("prsnkbb")
                    .Item(x, 8) = RD("kbapabrik") + RD("kbbpabrik")
                    .Item(x, 9) = RD("kbpcg") - (RD("kbapabrik") + RD("kbbpabrik"))
                    .Item(x, 10) = (RD("kbpcg") - (RD("kbapabrik") + RD("kbbpabrik"))) / RD("kbpcg")
                    x = x + 1
                Loop
            Else
                Call UI.HapusGrid(2, fgpcg)
            End If
        End With

        GrandTotal()

        Exit Sub

        'conny.close()



    End Sub

    Private Sub GrandTotal()
        With fgpcg
            .Tree.Column = 0
            .Tree.Style = TreeStyleFlags.CompleteLeaf
            .Subtotal(AggregateEnum.Clear)
            .Subtotal(AggregateEnum.Sum, -1, -1, 3)
            .Subtotal(AggregateEnum.Sum, -1, -1, 4)
            .Subtotal(AggregateEnum.Average, -1, -1, 5)
            .Subtotal(AggregateEnum.Average, -1, -1, 7)


            .Subtotal(AggregateEnum.Sum, -1, -1, 6)
            .Subtotal(AggregateEnum.Sum, -1, -1, 8)
            .Subtotal(AggregateEnum.Sum, -1, -1, 9)
            .Subtotal(AggregateEnum.Average, -1, -1, 10)
            .AutoSizeCols()
        End With

    End Sub




    Private Sub ItemMst()

        'Dim txt As CellRange
        Dim x As Integer

        Dim conny As New SqlConnection(StrConnAccounting)
        Dim col As New DataGridViewTextBoxColumn
        Dim sqlx As String

        conny.Open()
        sqlx = "Select * from RMPApp..tblMstItemPremi "
        Dim cmdselect As New SqlCommand(sqlx, conny)
        RD = cmdselect.ExecuteReader()
        x = 1



        If RD.HasRows Then
            Call UI.HapusGrid(1, fghasilinspektur)
            Call UI.HapusGrid(1, fginspektur)
            Call UI.HapusGrid(1, fgpoint)

            Do While RD.Read
                fghasilinspektur.AddItem(x)
                fginspektur.AddItem(x)
                fgpoint.AddItem(x)
                fghasilinspektur.Item(x, 0) = x
                fghasilinspektur.Item(x, "Item") = RD("Item")
                fginspektur.Item(x, 0) = x
                fginspektur.Item(x, "Item") = RD("Item")
                fgpoint.Item(x, 0) = x
                fgpoint.Item(x, "Item") = RD("Item")
                x = x + 1
            Loop

        End If

        Exit Sub


        conny.Close()

    End Sub




    Private Sub HEADERAFTERDATA()
        With fglavelbonus

            Dim txt As CellRange
            Dim x As Integer
            txt = .GetCellRange(0, 0, 1, 0) : txt.Data = "IDLavel" : .Cols(0).AllowMerging = True : .Cols(0).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 1, 1, 1) : txt.Data = "Lavel" : .Cols(1).AllowMerging = True : .Cols(1).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 2, 1, 2) : txt.Data = "Range" : .Cols(2).AllowMerging = True : .Cols(2).Visible = True : .Cols(2).TextAlign = TextAlignEnum.CenterCenter


            txt = .GetCellRange(0, 3, 1, 3) : txt.Data = "RangeMin" : .Cols(3).AllowMerging = True : .Cols(3).Visible = True
            txt = .GetCellRange(0, 4, 1, 4) : txt.Data = "RangeMax" : .Cols(4).AllowMerging = True : .Cols(4).Visible = True
            Dim conny As New SqlConnection(StrConnAccounting)
            Dim col As New DataGridViewTextBoxColumn
            Dim sqlx As String

            conny.Open()
            sqlx = "Select * from RMPApp..tblMstLevelMatrixTon where No_Lavel in (select TOP(1)  no_lavel from RMPApp..tblMstLevelMatrixTon where cast(Tgl_Lavel as date)<='" & dttgl.Value.ToString("yyyy-MM-dd") & "' order by idlavel desc) order by idlavel asc  "
            Dim cmdselect As New SqlCommand(sqlx, conny)
            RD = cmdselect.ExecuteReader()
            x = 5

            '.Col = 5

            If RD.HasRows Then

                Do While RD.Read
                    txt = .GetCellRange(1, x, 1, x) : txt.Data = RD("Range") : .Cols(x).AllowMerging = True : .Cols(x).TextAlign = TextAlignEnum.RightCenter : .Cols(x).Visible = True : .Cols(x).Format = "#,###0"
                    x = x + 1
                Loop
                txt = .GetCellRange(0, 5, 0, x - 1) : txt.Data = "Rupiah"
            End If

            Exit Sub


            conny.Close()
        End With

    End Sub

    Private Sub cleargrid()
        'Call UI.HapusGrid(2, fglavelbonus)
        'Call UI.HapusGrid(1, fgpoint)
        'Call UI.HapusGrid(1, fgpcg)
        'Call UI.HapusGrid(1, fgrupiah)
        'Call UI.HapusGrid(1, fginspektur)
        'Call UI.HapusGrid(1, fghasilinspektur)
    End Sub
    Private Sub FrmPremiInspektor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call cleargrid()
        headerfglavelbonus()
        Combo.CboMstRing(cmbring)
        Combo.SetJenisByKDJenis(cmbGrade_KB)

        dttgl.Value = CDate(DateAdd("d", -1, DateAdd("M", 1, dttgl.Value)))

    End Sub

    Private Sub CALLDATAlevelbonus()

        connetionString = "server=192.168.12.5; database=RMPApp; user=UKoneksi; password=sm@rt2018;  MultipleActiveResultSets=True; connect timeout=0;Max Pool Size=500000  ;"

        connection = New SqlConnection(connetionString)
        Dim sql As String
        sql = "declare @cols AS NVARCHAR(MAX),@query  AS NVARCHAR(MAX),@periode as date
		       set @periode='" & dttgl.Value.ToString("yyyy-MM-dd") & "'  
									SET @cols = STUFF((SELECT  ',' +  QUOTENAME(range) 
					                FROM tblMstLevelMatrixTon
									where No_Lavel in ( select top(1 ) No_Lavel from tblMstLevelMatrixTon where cast(Tgl_Lavel as date)<=@periode order by Tgl_Lavel desc )
                             order by idlavel asc
					                    FOR XML PATH(''), TYPE
					                    ).value('.', 'NVARCHAR(MAX)') 
				                    ,1,1,'')
		  
		                    set  @query = ';WITH  tabkanalbtr(  IDLAVEL,Lavel, RANGE,Range_Min,Range_Max, rangematrix, Harga) AS
                            (
                                SELECT A.IDLAVEL, A.Lavel,  A.RANGE, B.Range_Min,B.Range_Max, A.rangematrix,  HARGA  FROM    TblMstLavelBonusInspektorDtl AS A
								INNER JOIN tblMstLevelRange AS B ON A.IDLaveL=B.IDlavel  WHERE NOTRANS 
								 IN (SELECT TOP(1) NOTRANS FROM  
								TblMstLavelBonusInspektorHdr 
								where cast(periode as date)<='''+cast(@periode as VARCHAR)+''' order by periode desc )
								 
                            ),
                            kanalbtr as (SELECT *
                            FROM    tabkanalbtr
                            PIVOT 
                            (
                                SUM (HARGA) 
                                FOR rangematrix IN ('+ @cols +')
                            ) AS pvtkanalbtr
                            )
                          
						    select * from    kanalbtr AS A  
							'						
					 EXECUTE(@query)"

        Try
            connection.Open()
            adapter = New SqlDataAdapter(sql, connection)
            adapter.Fill(DS)
            connection.Close()
            fglavelbonus.DataSource = DS.Tables(0)


            Dim intensitasrelasi, dblHighValue As Double
            Dim maxV As Integer
            Dim minV As Integer

            fglavelbonus.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub CALLDATAlevelbonus2()

        connetionString = "server=192.168.12.5; database=RMPApp; user=UKoneksi; password=sm@rt2018;  MultipleActiveResultSets=True; connect timeout=0;Max Pool Size=500000  ;"

        connection = New SqlConnection(connetionString)
        Dim sql2 As String
        sql2 = "declare @cols AS NVARCHAR(MAX),@query  AS NVARCHAR(MAX),@periode as date
		       set @periode='" & dttgl.Value.ToString("yyyy-MM-dd") & "'   
									SET @cols = STUFF((SELECT  ',' +  QUOTENAME(RangeMatrixKg) 
					                FROM tblMstLevelMatrixTon
									where No_Lavel in ( select top(1 ) No_Lavel from tblMstLevelMatrixTon where cast(Tgl_Lavel as date)<=@periode order by Tgl_Lavel desc )
                             order by idlavel asc
					                    FOR XML PATH(''), TYPE
					                    ).value('.', 'NVARCHAR(MAX)') 
				                    ,1,1,'')
		  
		                    set  @query = ';WITH  tabkanalbtr(  IDLAVEL,Lavel, RANGE,Range_Min,Range_Max, RangeMatrixKg, Harga) AS
                            (
                                SELECT A.IDLAVEL, A.Lavel,  A.RANGE, B.Range_Min,B.Range_Max, A.rangematrixkg,  HARGA  FROM    TblMstLavelBonusInspektorDtl AS A
								INNER JOIN tblMstLevelRange AS B ON A.IDLaveL=B.IDlavel  WHERE NOTRANS 
								 IN (SELECT TOP(1) NOTRANS FROM  
								TblMstLavelBonusInspektorHdr 
								where cast(periode as date)<='''+cast(@periode as VARCHAR)+''' order by periode desc )
								 
                            ),
                            kanalbtr as (SELECT *
                            FROM    tabkanalbtr
                            PIVOT 
                            (
                                SUM (HARGA) 
                                FOR RangeMatrixKg IN ('+ @cols +')
                            ) AS pvtkanalbtr
                            )
                          
						    select * from    kanalbtr AS A   order by range_min asc
							'						
					 EXECUTE(@query)"

        Try
            connection.Open()
            adapter2 = New SqlDataAdapter(sql2, connection)
            adapter2.Fill(DS2)
            connection.Close()
            fglavelbonusdesc.DataSource = DS2.Tables(0)


            Dim intensitasrelasi, dblHighValue As Double
            Dim maxV As Integer
            Dim minV As Integer

            fglavelbonusdesc.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub


    Private Sub dttgl_ValueChanged(sender As Object, e As EventArgs) Handles dttgl.ValueChanged
        Call UI.HapusGrid(2, fglavelbonus)
        Call UI.HapusGrid(0, fglavelbonusdesc)
        'fglavelbonusdesc.AddItem(0)
        fglavelbonusdesc.DataSource = 0

        'Call cleargrid()
        fglavelbonus.DataSource = 0
        headerfglavelbonusdesc()
        headerfglavelbonus()
        CALLDATAlevelbonus()
        CALLDATAlevelbonus2()
        HEADERAFTERDATA()
        ItemMst()
        'dttgl.Value = CDate(DateAdd("d", -1, DateAdd("M", 1, dttgl.Value)))
    End Sub

    Private Sub cmbring_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbring.SelectedIndexChanged
        Mstfgpcg()
        headerfgPCG()
        'Dtlfgpcg()
    End Sub

    Private Sub DATAKBPCG()
        With fgpancang
            Dim txt As CellRange
            Dim x As Integer

            Dim conny As New SqlConnection(StrConnAccounting)
            Dim col As New DataGridViewTextBoxColumn
            Dim sqlx As String

            conny.Open()
            sqlx = "Select IDPancang,Pancang from RMPApp..vwMstPremiPengawasdanInspektorDtl where NoTrans in  (select top(1) notrans from RMPApp..tblMstPremiPengawasdanInspektorHdr where CONVERT(DATETIME, CONVERT(VARCHAR, periode, 103), 103) <=CONVERT(DATETIME, '" & CDate(dttgl.Value) & "', 103) order by periode desc) AND  IDRING='" & cmbring.SelectedValue.ToString & "' "
            Dim cmdselect As New SqlCommand(sqlx, conny)
            RD = cmdselect.ExecuteReader()
            x = 1



            If RD.HasRows Then
                Do While RD.Read
                    '.Item(x, 0) = x
                    .Item(x, 0) = RD("IDPancang")
                    .Item(x, 1) = RD("Pancang")
                    x = x + 1
                Loop

            End If

            Exit Sub


            conny.Close()
        End With
    End Sub

    Private Sub cmbGrade_KB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGrade_KB.SelectedIndexChanged
        headerfgPCG()
    End Sub

    Private Sub TOTALPOINT()
        With fgpoint
            .Tree.Column = 0
            .Tree.Style = TreeStyleFlags.CompleteLeaf
            .Subtotal(AggregateEnum.Clear)
            .Subtotal(AggregateEnum.Sum, -1, -1, 3)
            .Subtotal(AggregateEnum.Sum, -1, -1, 4)

            .AutoSizeCols()
        End With

    End Sub


    Private Sub calculate()

        On Error Resume Next
        Call UI.HapusGrid(1, fgrupiah)
        ''fginspektur.Rows(1).COLS(12).Format = "####%"

        fginspektur.Item(1, 2) = GetKBBTarget(cmbGrade_KB)
        fginspektur.Item(2, 2) = GetSusutTarget(cmbGrade_KB)

        fginspektur.Item(1, 4) = GetKBBTarget_(cmbGrade_KB)
        fginspektur.Item(2, 4) = GetSusutTarget_(cmbGrade_KB)


        fginspektur.Cols(3).Format = "#,###0"
        fginspektur.Rows(3).Format = "#,###0"
        '"#,###0"
        fginspektur.Item(3, 2) = GetVolumeKB(cmbGrade_KB, cmbring.SelectedValue)
        fginspektur.Item(1, 3) = GetKBBTarget_(cmbGrade_KB) * GetVolumeKB(cmbGrade_KB, cmbring.SelectedValue)
        fginspektur.Item(2, 3) = GetSusutTarget_(cmbGrade_KB) * GetVolumeKB(cmbGrade_KB, cmbring.SelectedValue)


        fghasilinspektur.Item(1, 2) = Math.Round((fgpcg.Item(2, 7) * 100), 1).ToString + " %"
        fghasilinspektur.Item(2, 2) = Math.Round((fgpcg.Item(2, 10) * 100), 1).ToString + " %"


        fghasilinspektur.Item(1, 3) = fgpcg.Item(2, 6)
        fghasilinspektur.Item(2, 3) = fgpcg.Item(2, 9)

        fghasilinspektur.Item(1, 4) = fgpcg.Rows.Count - 3
        fghasilinspektur.Item(2, 4) = fgpcg.Rows.Count - 3

        fghasilinspektur.Item(1, 5) = fgpcg.Item(2, 7)
        'fghasilinspektur.Item(1, 5) = 900
        fghasilinspektur.Item(2, 5) = fgpcg.Item(2, 10)

        fghasilinspektur.Item(3, 2) = fgpcg.Item(2, 3)
        'fghasilinspektur.Item(3, 2) = 7


        fghasilinspektur.Cols(3).Format = "#,###0"
        fghasilinspektur.Cols(2).Format = "#,###0"

        Dim Bulan, Tahun As Integer
        Dim Hasil As Integer

        Bulan = Month(dttgl.Value)
        Tahun = Year(dttgl.Value)
        Hasil = Date.DaysInMonth(Tahun, Bulan)
        'Hasil = 31
        fghasilinspektur.Item(3, 4) = Hasil

        fghasilinspektur.Item(3, 3) = fgpcg.Item(2, 3) / Hasil


        ' fghasilinspektur.Item(3, 3) = 200000.12

        If fghasilinspektur.Item(1, 5) < GetKBBTarget_(cmbGrade_KB) Then
            fgpoint.Item(1, 2) = 1
        Else
            fgpoint.Item(1, 2) = GetKBBTarget_(cmbGrade_KB) / fghasilinspektur.Item(1, 5)
        End If

        If fghasilinspektur.Item(2, 5) < GetSusutTarget_(cmbGrade_KB) Then
            fgpoint.Item(2, 2) = 1
        Else
            fgpoint.Item(2, 2) = 100 - GetSusutTarget_(cmbGrade_KB) / fghasilinspektur.Item(2, 5)
        End If

        If fghasilinspektur.Item(3, 2) > GetVolumeKB(cmbGrade_KB, cmbring.SelectedValue) Then
            fgpoint.Item(3, 2) = 1
        Else
            fgpoint.Item(3, 2) = fghasilinspektur.Item(3, 2) / GetVolumeKB(cmbGrade_KB, cmbring.SelectedValue)
        End If


        fgpoint.Item(1, 3) = stdMaksimalKbB(cmbGrade_KB, cmbring.SelectedValue)
        fgpoint.Item(2, 3) = stdMaksimalSusut(cmbGrade_KB, cmbring.SelectedValue)
        fgpoint.Item(3, 3) = stdVolumeKB(cmbGrade_KB, cmbring.SelectedValue)




        fgpoint.Item(1, 4) = Math.Round(fgpoint.Item(1, 2) * stdMaksimalKbB(cmbGrade_KB, cmbring.SelectedValue), 1)
        fgpoint.Item(2, 4) = Math.Round(fgpoint.Item(2, 2) * stdMaksimalSusut(cmbGrade_KB, cmbring.SelectedValue), 1)
        fgpoint.Item(3, 4) = Math.Round(fgpoint.Item(3, 2) * stdVolumeKB(cmbGrade_KB, cmbring.SelectedValue), 1)

        fginspektur.Item(3, 3) = GetVolumeKB(cmbGrade_KB, cmbring.SelectedValue) / Hasil
        'Catch
        TOTALPOINT()
        fgrupiah.AddItem(1)
        ' fgpoint.Item(fgpoint.Rows.Count - 1, 4) = 99
        fgrupiah.Item(1, 1) = 0
        For I = 1 To fglavelbonusdesc.Rows.Count
            If fglavelbonusdesc.Item(I, "Range_Min") > fgpoint.Item(fgpoint.Rows.Count - 1, 4) Then
                Exit For
            Else
                If fglavelbonusdesc.Item(I, "Range_Min") <= fgpoint.Item(fgpoint.Rows.Count - 1, 4) And fglavelbonusdesc.Item(I, "Range_Max") >= fgpoint.Item(fgpoint.Rows.Count - 1, 4) Then

                    fgrupiah.Item(1, 1) = fgpoint.Item(fgpoint.Rows.Count - 1, 4)

                    For a = 5 To fglavelbonusdesc.Cols.Count - 1

                        Dim btslevel As Double
                        Dim hasilinspektur As Double
                        btslevel = Convert.ToDouble(fglavelbonusdesc.Item(0, a))
                        hasilinspektur = Convert.ToDouble(fghasilinspektur.Item(3, 3))
                        If a = 5 Then


                            If hasilinspektur < btslevel Then
                                fgrupiah.Item(1, 2) = fglavelbonusdesc.Item(I, a)
                            End If

                        Else
                            If a = 9 Then
                                If hasilinspektur > btslevel Then
                                    fgrupiah.Item(1, 2) = fglavelbonusdesc.Item(I, a)
                                End If
                            Else

                                If hasilinspektur < btslevel Then
                                    Exit For
                                End If

                                If btslevel <= hasilinspektur Then
                                    fgrupiah.Item(1, 2) = fglavelbonusdesc.Item(I, a)
                                End If
                            End If
                        End If


                    Next
                    If fgrupiah.Item(1, 1) > 0 Then

                        fgrupiah.Item(1, 3) = fgrupiah.Item(1, 2) * fgrupiah.Item(1, 1)
                    End If
                End If


            End If
        Next
    End Sub



    Public Function GetKBBTarget(ByVal gradekb As ComboBox) As String

        Dim dt As DataTable = New DataTable()
        If gradekb.SelectedValue.ToString = "LC" Then
            Dim NoTrans As String
            NoTrans = DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"Select Top 1 NoTrans As GetValuep2 From RMPApp..tblMstPremiPengawasdanInspektorHdr Where Grade_KB='LC' AND convert(smalldatetime,Periode,103) <= convert(smalldatetime,'" & dttgl.Value & "',103) Order BY Periode Desc")


            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "Select  Cast( Batas_KB_B as varchar(5)) + ' %' AS Batas_KB_B  from RMPApp..tblMstPremiPengawasdanInspektorHdr  Where Grade_KB='LC' AND NoTrans='" & NoTrans & "' ")

        Else
            If gradekb.SelectedValue.ToString = "JB" Then
                Dim NoTrans As String
                NoTrans = DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"Select Top 1 NoTrans As GetValuep2 From RMPApp..tblMstPremiPengawasdanInspektorHdr Where Grade_KB='JB' AND  convert(smalldatetime,Periode,103) <= convert(smalldatetime,'" & dttgl.Value & "',103) Order BY Periode Desc")


                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "Select  Cast( Batas_KB_B as varchar(5)) + ' %'  AS Batas_KB_B  from RMPApp..tblMstPremiPengawasdanInspektorHdr  Where Grade_KB='JB' AND NoTrans='" & NoTrans & "' ")

            Else
                MessageBox.Show("Tidak Ada Batas_KB_B ")
            End If
        End If
        GetKBBTarget = dt.Rows(0).Item("Batas_KB_B")
        Return GetKBBTarget


    End Function


    Public Function GetSusutTarget(ByVal gradekb As ComboBox) As String

        Dim dt As DataTable = New DataTable()
        If gradekb.SelectedValue.ToString = "LC" Then
            Dim NoTrans As String
            NoTrans = DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"Select Top 1 NoTrans As GetValuep2 From RMPApp..tblMstPremiPengawasdanInspektorHdr Where Grade_KB='LC' AND  convert(smalldatetime,Periode,103) <= convert(smalldatetime,'" & dttgl.Value & "',103) Order BY Periode Desc")


            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "Select  Cast( Batas_Susut_KB as varchar(5)) + ' %' AS Batas_Susut_KB from RMPApp..tblMstPremiPengawasdanInspektorHdr  Where Grade_KB='LC' AND NoTrans='" & NoTrans & "' ")

        Else
            If gradekb.SelectedValue.ToString = "JB" Then
                Dim NoTrans As String
                NoTrans = DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"Select Top 1 NoTrans As GetValuep2 From RMPApp..tblMstPremiPengawasdanInspektorHdr Where Grade_KB='JB' AND  convert(smalldatetime,Periode,103) <= convert(smalldatetime,'" & dttgl.Value & "',103) Order BY Periode Desc")


                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "Select Cast( Batas_Susut_KB as varchar(5)) + ' %' AS Batas_Susut_KB   from RMPApp..tblMstPremiPengawasdanInspektorHdr  Where Grade_KB='JB' AND NoTrans='" & NoTrans & "' ")

            Else
                MessageBox.Show("Tidak Ada Batas_Susut_KB")
            End If
        End If
        GetSusutTarget = dt.Rows(0).Item("Batas_Susut_KB")
        Return GetSusutTarget

    End Function


    Public Function GetKBBTarget_(ByVal gradekb As ComboBox) As Double

        Dim dt As DataTable = New DataTable()
        If gradekb.SelectedValue.ToString = "LC" Then
            Dim NoTrans As String
            NoTrans = DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"Select Top 1 NoTrans As GetValuep2 From RMPApp..tblMstPremiPengawasdanInspektorHdr Where Grade_KB='LC' AND convert(smalldatetime,Periode,103) <= convert(smalldatetime,'" & dttgl.Value & "',103) Order BY Periode Desc")


            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "Select  Batas_KB_B/100 AS Batas_KB_B  from RMPApp..tblMstPremiPengawasdanInspektorHdr  Where Grade_KB='LC' AND NoTrans='" & NoTrans & "' ")

        Else
            If gradekb.SelectedValue.ToString = "JB" Then
                Dim NoTrans As String
                NoTrans = DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"Select Top 1 NoTrans As GetValuep2 From RMPApp..tblMstPremiPengawasdanInspektorHdr Where Grade_KB='JB' AND  convert(smalldatetime,Periode,103) <= convert(smalldatetime,'" & dttgl.Value & "',103) Order BY Periode Desc")


                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "Select  Batas_KB_B/100  AS Batas_KB_B  from RMPApp..tblMstPremiPengawasdanInspektorHdr  Where Grade_KB='JB' AND NoTrans='" & NoTrans & "' ")

            Else
                MessageBox.Show("Tidak Ada Batas_KB_B ")
            End If
        End If
        GetKBBTarget_ = dt.Rows(0).Item("Batas_KB_B")
        Return GetKBBTarget_


    End Function


    Public Function GetSusutTarget_(ByVal gradekb As ComboBox) As Double

        Dim dt As DataTable = New DataTable()
        If gradekb.SelectedValue.ToString = "LC" Then
            Dim NoTrans As String
            NoTrans = DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"Select Top 1 NoTrans As GetValuep2 From RMPApp..tblMstPremiPengawasdanInspektorHdr Where Grade_KB='LC' AND  convert(smalldatetime,Periode,103) <= convert(smalldatetime,'" & dttgl.Value & "',103) Order BY Periode Desc")


            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "Select  Batas_Susut_KB/100  AS Batas_Susut_KB from RMPApp..tblMstPremiPengawasdanInspektorHdr  Where Grade_KB='LC' AND NoTrans='" & NoTrans & "' ")

        Else
            If gradekb.SelectedValue.ToString = "JB" Then
                Dim NoTrans As String
                NoTrans = DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"Select Top 1 NoTrans As GetValuep2 From RMPApp..tblMstPremiPengawasdanInspektorHdr Where Grade_KB='JB' AND  convert(smalldatetime,Periode,103) <= convert(smalldatetime,'" & dttgl.Value & "',103) Order BY Periode Desc")


                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "Select Batas_Susut_KB/100   AS Batas_Susut_KB   from RMPApp..tblMstPremiPengawasdanInspektorHdr  Where Grade_KB='JB' AND NoTrans='" & NoTrans & "' ")

            Else
                MessageBox.Show("Tidak Ada Batas_Susut_KB")
            End If
        End If
        GetSusutTarget_ = dt.Rows(0).Item("Batas_Susut_KB")
        Return GetSusutTarget_

    End Function


    Public Function GetVolumeKB(ByVal gradekb As ComboBox, ring As Integer) As Double

        Dim dt As DataTable = New DataTable()
        If gradekb.SelectedValue.ToString = "LC" Then
            Dim NoTrans As String
            NoTrans = DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"Select Top 1 NoTrans As GetValuep2 From RMPApp..tblMstPremiPengawasdanInspektorHdr Where Grade_KB='LC' AND  convert(smalldatetime,Periode,103) <= convert(smalldatetime,'" & dttgl.Value & "',103) Order BY Periode Desc")


            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "Select  SUM(Volume) AS Volume from RMPApp..vwMstPremiPengawasdanInspektorDtl  Where Grade_KB='LC' AND NoTrans='" & NoTrans & "'  and IDring='" & ring & "' ")

        Else
            If gradekb.SelectedValue.ToString = "JB" Then
                Dim NoTrans As String
                NoTrans = DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"Select Top 1 NoTrans As GetValuep2 From RMPApp..tblMstPremiPengawasdanInspektorHdr Where Grade_KB='JB' AND  convert(smalldatetime,Periode,103) <= convert(smalldatetime,'" & dttgl.Value & "',103) Order BY Periode Desc")



                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "Select  SUM(Volume) AS Volume from RMPApp..vwMstPremiPengawasdanInspektorDtl  Where Grade_KB='JB' AND NoTrans='" & NoTrans & "' and IDring='" & ring & "'  ")

            Else
                MessageBox.Show("Tidak Ada Volume")
            End If
        End If
        GetVolumeKB = dt.Rows(0).Item("Volume")
        Return GetVolumeKB

    End Function


    Public Function stdMaksimalKbB(ByVal gradekb As ComboBox, ring As Integer) As Double

        Dim dt As DataTable = New DataTable()
        If gradekb.SelectedValue.ToString = "LC" Then
            Dim NoTrans As String
            NoTrans = DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"Select Top 1 NoTrans As GetValuep2 From RMPApp..tblMstPremiPengawasdanInspektorHdr Where Grade_KB='LC' AND  convert(smalldatetime,Periode,103) <= convert(smalldatetime,'" & dttgl.Value & "',103) Order BY Periode Desc")


            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "Select  Maksimal_KBB_Inspektor from RMPApp..vwMstPremiPengawasdanInspektorDtl  Where Grade_KB='LC' AND NoTrans='" & NoTrans & "'  and IDring='" & ring & "' ")

        Else
            If gradekb.SelectedValue.ToString = "JB" Then
                Dim NoTrans As String
                NoTrans = DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"Select Top 1 NoTrans As GetValuep2 From RMPApp..tblMstPremiPengawasdanInspektorHdr Where Grade_KB='JB' AND  convert(smalldatetime,Periode,103) <= convert(smalldatetime,'" & dttgl.Value & "',103) Order BY Periode Desc")



                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "Select  Maksimal_KBB_Inspektor from RMPApp..vwMstPremiPengawasdanInspektorDtl  Where Grade_KB='JB' AND NoTrans='" & NoTrans & "' and IDring='" & ring & "'  ")

            Else
                MessageBox.Show("Tidak Ada Volume")
            End If
        End If
        stdMaksimalKbB = dt.Rows(0).Item("Maksimal_KBB_Inspektor")
        Return stdMaksimalKbB

    End Function


    Public Function stdMaksimalSusut(ByVal gradekb As ComboBox, ring As Integer) As Double

        Dim dt As DataTable = New DataTable()
        If gradekb.SelectedValue.ToString = "LC" Then
            Dim NoTrans As String
            NoTrans = DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"Select Top 1 NoTrans As GetValuep2 From RMPApp..tblMstPremiPengawasdanInspektorHdr Where Grade_KB='LC' AND  convert(smalldatetime,Periode,103) <= convert(smalldatetime,'" & dttgl.Value & "',103) Order BY Periode Desc")


            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "Select  Max_Susut_Kg_Inspektor from RMPApp..vwMstPremiPengawasdanInspektorDtl  Where Grade_KB='LC' AND NoTrans='" & NoTrans & "'  and IDring='" & ring & "' ")

        Else
            If gradekb.SelectedValue.ToString = "JB" Then
                Dim NoTrans As String
                NoTrans = DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"Select Top 1 NoTrans As GetValuep2 From RMPApp..tblMstPremiPengawasdanInspektorHdr Where Grade_KB='JB' AND  convert(smalldatetime,Periode,103) <= convert(smalldatetime,'" & dttgl.Value & "',103) Order BY Periode Desc")



                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "Select  Max_Susut_Kg_Inspektor from RMPApp..vwMstPremiPengawasdanInspektorDtl  Where Grade_KB='JB' AND NoTrans='" & NoTrans & "' and IDring='" & ring & "'  ")

            Else
                MessageBox.Show("Tidak Ada Volume")
            End If
        End If
        stdMaksimalSusut = dt.Rows(0).Item("Max_Susut_Kg_Inspektor")
        Return stdMaksimalSusut

    End Function

    Public Function stdVolumeKB(ByVal gradekb As ComboBox, ring As Integer) As Double

        Dim dt As DataTable = New DataTable()
        If gradekb.SelectedValue.ToString = "LC" Then
            Dim NoTrans As String
            NoTrans = DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"Select Top 1 NoTrans As GetValuep2 From RMPApp..tblMstPremiPengawasdanInspektorHdr Where Grade_KB='LC' AND  convert(smalldatetime,Periode,103) <= convert(smalldatetime,'" & dttgl.Value & "',103) Order BY Periode Desc")


            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "Select  Vol_KB_Pcg_Inspektor from RMPApp..vwMstPremiPengawasdanInspektorDtl  Where Grade_KB='LC' AND NoTrans='" & NoTrans & "'  and IDring='" & ring & "' ")

        Else
            If gradekb.SelectedValue.ToString = "JB" Then
                Dim NoTrans As String
                NoTrans = DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"Select Top 1 NoTrans As GetValuep2 From RMPApp..tblMstPremiPengawasdanInspektorHdr Where Grade_KB='JB' AND  convert(smalldatetime,Periode,103) <= convert(smalldatetime,'" & dttgl.Value & "',103) Order BY Periode Desc")



                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "Select  Vol_KB_Pcg_Inspektor from RMPApp..vwMstPremiPengawasdanInspektorDtl  Where Grade_KB='JB' AND NoTrans='" & NoTrans & "' and IDring='" & ring & "'  ")

            Else
                MessageBox.Show("Tidak Ada Volume")
            End If
        End If
        stdVolumeKB = dt.Rows(0).Item("Vol_KB_Pcg_Inspektor")
        Return stdVolumeKB

    End Function

    Private Sub btnrefresh_Click(sender As Object, e As EventArgs) Handles btnrefresh.Click
        Dtlfgpcg()
        calculate()


    End Sub


    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        Dim Tanggal As Date
        Dim TanggalAkhir As Date
        Tanggal = DateSerial(Year(DateTimePicker1.Value), Month(DateTimePicker1.Value), 1) 'membuat tanggal 6 June 2021
        'rumus mencari tanggal akhir dalam suatu bulan
        TanggalAkhir = DateSerial(Year(Tanggal), Month(Tanggal) + 1, 0)
        dttgl.Value = Format(TanggalAkhir, "dd MMMM yyyy")
    End Sub

    Private Sub fglavelbonusdesc_Click(sender As Object, e As EventArgs) Handles fglavelbonusdesc.Click

    End Sub

    Private Sub TableLayoutPanel7_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel7.Paint

    End Sub
End Class