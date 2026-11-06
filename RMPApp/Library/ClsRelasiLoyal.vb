Imports System.Data.SqlClient
Imports Dapper
Imports C1.Win.C1FlexGrid

Public Class ClsRelasiLoyal
    Dim cn As SqlConnection = New SqlConnection(StrConnRMPApp)
    Dim perintah As String



    Public Const AT As String = "Raw Material Purchasing"

    Public Property KodeSupUM As String
    Public Property NamaSupUM As String
    Public Property IDRelasi As String
    Public Property NamaRelasi As String
    Public Property Alamat As String
    Public Property Pancang As String





    Private Sub monColorSubTotalCrane()
        Dim cs As C1.Win.C1FlexGrid.CellStyle
        With FrmMonRelasiLoyal.fgKg
            cs = .Styles(C1.Win.C1FlexGrid.CellStyleEnum.GrandTotal)
            'cs.BackColor = Color.FromArgb(30, 57, 91)
            cs.BackColor = Color.FromArgb(111, 188, 232)
            cs.ForeColor = Color.FromArgb(30, 57, 91)
            'cs.Font = New Font(Font, FontStyle.Bold)
        End With
    End Sub





    Public Sub MonRelasiLoyal()
        Try
            With FrmMonRelasiLoyal
                Dim sql As String
                Dim ListNota As List(Of ClsRelasiLoyal) = Nothing
                Dim i As Integer = 1

                sql = "declare @periodeyear varchar(4),@cols AS NVARCHAR(MAX),@query  AS NVARCHAR(MAX) set @periodeyear='" & Year(FrmMonRelasiLoyal.DOYear.Value) & "'      
							Declare @dateFrom datetime =@periodeyear+'-01-01', @dateTo datetime =@periodeyear+'-12-31'
							declare @Workingmonth Table 
		                     (
		                       Wmonth datetime
		                     )
		                    ;with  CTE as (
		                       SELECT @dateFrom AS cte_start_date
								UNION ALL
								SELECT DATEADD(MONTH, 1, cte_start_date)

									FROM CTE
									WHERE ( DATEADD(MONTH, 1, cte_start_date) <=  EOMONTH( @dateTo)   ) 
		                      )
		                     insert into @Workingmonth						 
							  select  cte_start_date  from CTE
		                     SET @cols = STUFF((SELECT  ',' +  QUOTENAME(CAST(CONVERT(CHAR(7), Wmonth, 120) AS varchar(7))) 
					                FROM @Workingmonth
					                    FOR XML PATH(''), TYPE
					                    ).value('.', 'NVARCHAR(MAX)') 
				                    ,1,1,'')
		                set  @query = ';WITH 
                        fc as (SELECT *
                        FROM    RSUPAccounting..vwtotalnetto2persupplier
                        PIVOT 
                        (
                            SUM (netto2) 
                            FOR monthnota IN ('+ @cols +')
                        ) AS pvtfc
                        )
                    select *  from fc '

					execute(@query)"


                ListNota = cn.Query(Of ClsRelasiLoyal)(sql)
                Call UI.HapusGrid(2, FrmMonRelasiLoyal.fgKg)
                If ListNota.Count > 0 Then
                    For Each j In ListNota
                        With .fgKg
                            .AddItem("")
                            .Item(.Rows.Count - 1, 0) = .Rows.Count - 2
                            .Item(.Rows.Count - 1, NameOf(Me.KodeSupUM)) = j.KodeSupUM

                            '.Item(.Rows.Count - 1, "TotalKg") = j.TotalKg1
                            '.Item(.Rows.Count - 1, NameOf(Me.HargaMaster)) = j.HargaMaster
                            '.Item(.Rows.Count - 1, NameOf(Me.TotalMaster)) = j.TotalMaster
                            '.Item(.Rows.Count - 1, NameOf(Me.kodeHarga)) = j.KodeHargaString
                            '.Item(.Rows.Count - 1, NameOf(Me.DetailID)) = j.DetailID
                            '.Item(.Rows.Count - 1, NameOf(Me.ContractorIDA)) = j.ContractorIDA
                            '.Item(.Rows.Count - 1, NameOf(Me.ContractorIDB)) = j.ContractorIDB
                            '.Item(.Rows.Count - 1, NameOf(Me.ContractorNameA)) = j.ContractorNameA
                            '.Item(.Rows.Count - 1, NameOf(Me.ContractorNameB)) = j.ContractorNameB
                            '.Item(.Rows.Count - 1, NameOf(Me.SupervisorID)) = j.SupervisorID
                            '.Item(.Rows.Count - 1, NameOf(Me.Supervisor)) = j.Supervisor
                            '.Item(.Rows.Count - 1, NameOf(Me.TallyID)) = j.TallyID
                            '.Item(.Rows.Count - 1, NameOf(Me.FarmerName)) = j.FarmerName
                            '.Item(.Rows.Count - 1, NameOf(Me.StartBongkarDateTime)) = j.StartBongkarDateTime
                            '.Item(.Rows.Count - 1, NameOf(Me.EndBongkarDateTime)) = j.EndBongkarDateTime
                            '.Item(.Rows.Count - 1, NameOf(Me.Sortir)) = j.Sortir
                            '.Item(.Rows.Count - 1, NameOf(Me.groupharga)) = j.groupharga
                        End With
                    Next
                End If
                'MonShowTotalsCrane()
            End With

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub



    '    Public Sub SubTotalMon()
    '        Dim I, J As Integer
    '        Dim TotA1, TotA2, TotA3, TotA4, TotB1, TotB2, TotB3, GrandTot As Double
    '        Dim A1 As Integer, A2 As Integer, A3 As Integer, A4 As Integer, A5 As Integer
    '        Dim B1 As Integer, B2 As Integer, B3 As Integer, C1 As Integer


    '        TotA1 = 0
    '        TotA2 = 0
    '        TotA3 = 0
    '        TotA4 = 0
    '        TotB1 = 0
    '        TotB2 = 0
    '        TotB3 = 0
    '        GrandTot = 0

    '        A1 = 0 : A2 = 0 : A3 = 0 : A4 = 0 : A5 = 0
    '        B1 = 0 : B2 = 0 : B3 = 0 : C1 = 0

    '        With FrmMonPenerimaanKBKgPCG



    '            For I = 6 To 10
    '                For J = 2 To .fg1.Rows.Count - 1
    '                    Select Case .fg1.Item(J, "grade")
    '                        Case "A1"
    '                            TotA1 = TotA1 + .fg1.Item(J, I)
    '                        Case "A2"
    '                            TotA2 = TotA2 + .fg1.Item(J, I)
    '                        Case "A3"
    '                            TotA3 = TotA3 + .fg1.Item(J, I)
    '                        Case "A4"
    '                            TotA4 = TotA4 + .fg1.Item(J, I)
    '                        Case "B1"
    '                            TotB1 = TotB1 + .fg1.Item(J, I)
    '                        Case "B2"
    '                            TotB2 = TotB2 + .fg1.Item(J, I)
    '                        Case "B3"
    '                            TotB3 = TotB3 + .fg1.Item(J, I)
    '                    End Select
    '                    GrandTot = GrandTot + .fg1.Item(J, I)

    '                    If I = 6 Then
    '                        Select Case .fg1.Item(J, "kode")
    '                            Case "A1"
    '                                .fg1.Item(J, 20) = A1
    '                                A1 = A1 + 1
    '                            Case "A2"
    '                                .fg1.Item(J, 20) = A2
    '                                A2 = A2 + 1
    '                            Case "A3"
    '                                .fg1.Item(J, 20) = A3
    '                                A3 = A3 + 1
    '                            Case "A4"
    '                                .fg1.Item(J, 20) = A4
    '                                A4 = A4 + 1
    '                            Case "A5"
    '                                .fg1.Item(J, 20) = A5
    '                                A5 = A5 + 1
    '                            Case "B1"
    '                                .fg1.Item(J, 20) = B1
    '                                B1 = B1 + 1
    '                            Case "B2"
    '                                .fg1.Item(J, 20) = B2
    '                                B2 = B2 + 1
    '                            Case "B3"
    '                                .fg1.Item(J, 20) = B3
    '                                B3 = B3 + 1
    '                            Case "C1"
    '                                .fg1.Item(J, 20) = C1
    '                                C1 = C1 + 1
    '                        End Select
    '                    End If

    '                Next J


    '                .fg12.Item(0, I) = (TotA1 + TotA2 + TotA3 + TotA4)
    '                ''MessageBox.Show(TotA1 + TotA2 + TotA3 + TotA4)
    '                .fg12.Item(1, I) = (TotB1 + TotB2 + TotB3)
    '                .fg12.Item(2, I) = GrandTot



    '                TotA1 = 0
    '                TotA2 = 0
    '                TotA3 = 0
    '                TotA4 = 0
    '                TotB1 = 0
    '                TotB2 = 0
    '                TotB3 = 0
    '                GrandTot = 0
    '            Next I



    '            Dim BJA, BJB, BLA, BLB, RJA, RJB, RLA, RLB, JA, JB, LA, lb, grandbrutokg, grandrejectkg, grandkg As Double
    '            Dim TJA, TJB, TLA, TLB, GrandTKg As Double
    '            BJA = 0
    '            BJB = 0
    '            BLA = 0
    '            BLB = 0
    '            RJA = 0
    '            RJB = 0
    '            RLA = 0
    '            RLB = 0
    '            LA = 0
    '            lb = 0
    '            JA = 0
    '            JB = 0
    '            grandbrutokg = 0
    '            grandrejectkg = 0
    '            grandkg = 0

    '            TJA = 0
    '            TJB = 0
    '            TLA = 0
    '            TLB = 0
    '            GrandTKg = 0


    '            Dim KG As Integer

    '            For KG = 1 To .fgpricekg.Rows.Count - 2
    '                'If .fgpricekg.Item(KG, 0) = True Then ''----ketika di centang
    '                If .fgpricekg.Item(KG, "Grade") <> "" Then
    '                    Select Case .fgpricekg.Item(KG, "Grade")
    ''       
    '                        Case "Jambul-A"
    '                            BJA = BJA + .fgpricekg.Item(KG, "Bruto")
    '                            RJA = RJA + .fgpricekg.Item(KG, "HasilTarraPersen")
    '                            JA = JA + .fgpricekg.Item(KG, "Netto1")
    '                            TJA = TJA + .fgpricekg.Item(KG, "Totalkg")
    '                        Case "Jambul-B"
    '                            BJB = BJB + .fgpricekg.Item(KG, "Bruto")
    '                            RJB = RJB + .fgpricekg.Item(KG, "HasilTarraPersen")
    '                            JB = JB + .fgpricekg.Item(KG, "Netto1")
    '                            TJB = TJB + .fgpricekg.Item(KG, "Totalkg")
    '                        Case "Licin-A"
    '                            BLA = BLA + .fgpricekg.Item(KG, "Bruto")
    '                            RLA = RLA + .fgpricekg.Item(KG, "HasilTarraPersen")
    '                            LA = LA + .fgpricekg.Item(KG, "Netto1")
    '                            TLA = TLA + .fgpricekg.Item(KG, "Totalkg")
    '                        Case "Licin-B"
    '                            BLB = BLB + .fgpricekg.Item(KG, "Bruto")
    '                            RLB = RLB + .fgpricekg.Item(KG, "HasilTarraPersen")
    '                            lb = lb + .fgpricekg.Item(KG, "Netto1")
    '                            TLB = TLB + .fgpricekg.Item(KG, "Totalkg")
    '                    End Select
    '                    grandbrutokg = grandbrutokg + .fgpricekg.Item(KG, "Bruto")
    '                    grandrejectkg = grandrejectkg + .fgpricekg.Item(KG, "HasilTarraPersen")
    '                    grandkg = grandkg + .fgpricekg.Item(KG, "Netto1")


    '                    GrandTKg = GrandTKg + .fgpricekg.Item(KG, "Totalkg")
    '                End If
    '                'End If

    '                ' GrandTKg = GrandTKg + .fgpricekg.Item(KG, "TotalMaster")
    '            Next KG

    '            '  If .fgpricekg.Rows.Selected.Count - 1 = True Then
    '            .fg12.Item(0, 15) = BJA
    '            .fg12.Item(1, 15) = BJB
    '            .fg12.Item(2, 15) = BLA
    '            .fg12.Item(3, 15) = BLB
    '            .fg12.Item(4, 15) = grandbrutokg


    '            .fg12.Item(0, 16) = RJA
    '            .fg12.Item(1, 16) = RJB
    '            .fg12.Item(2, 16) = RLA
    '            .fg12.Item(3, 16) = RLB
    '            .fg12.Item(4, 16) = grandrejectkg

    '            .fg12.Item(0, 17) = JA
    '            .fg12.Item(1, 17) = JB
    '            .fg12.Item(2, 17) = LA
    '            .fg12.Item(3, 17) = lb

    '            .fg12.Item(4, 17) = grandkg

    '            .fg12.Item(0, 19) = TJA
    '            .fg12.Item(1, 19) = TJB
    '            .fg12.Item(2, 19) = TLA
    '            .fg12.Item(3, 19) = TLB
    '            .fg12.Item(4, 19) = GrandTKg
    '            '   End If


    '            For I = 0 To .fg12.Rows.Count - 1
    '                If CDate(.dtTgl1.Value) > CDate("16/01/2015") Then
    '                    If .fg12.Item(I, 6) > 0 Then
    '                        .fg12.Item(I, 9) = .fg12.Item(I, 10) / .fg12.Item(I, 6)
    '                    End If

    '                    If .fg12.Item(I, 19) > 0 Then
    '                        .fg12.Item(I, 18) = .fg12.Item(I, 19) / .fg12.Item(I, 17)
    '                    End If

    '                Else
    '                    If .fg12.Item(I, 8) > 0 Then
    '                        .fg12.Item(I, 9) = .fg12.Item(I, 10) / .fg12.Item(I, 8)
    '                    End If
    '                    If .fg12.Item(I, 19) > 0 Then
    '                        .fg12.Item(I, 18) = .fg12.Item(I, 19) / .fg12.Item(I, 17)
    '                    End If
    '                End If

    '            Next I
    '        End With
    '    End Sub


    'Public Sub MonShowTotalsCrane()
    '    Dim i As Integer
    '    With FrmMonPenerimaanKBKgPCG.fgpricekg
    '        .Tree.Column = 0
    '        .Tree.Style = TreeStyleFlags.Simple
    '        .Subtotal(AggregateEnum.Clear)

    '        .Subtotal(AggregateEnum.Sum, -1, -1, 20)
    '        .Subtotal(AggregateEnum.Sum, 0, 0, 20)

    '        .Subtotal(AggregateEnum.Sum, -1, -1, 21)
    '        .Subtotal(AggregateEnum.Sum, 0, 0, 21)

    '        .Subtotal(AggregateEnum.Sum, -1, -1, 23)
    '        .Subtotal(AggregateEnum.Sum, 0, 0, 23)

    '        .Subtotal(AggregateEnum.Sum, -1, -1, 24)

    '        .Subtotal(AggregateEnum.Sum, 0, 0, 24)

    '        For i = 27 To 40
    '            .Subtotal(AggregateEnum.Sum, -1, -1, i)
    '            .Subtotal(AggregateEnum.Sum, 1, 1, i)

    '        Next i

    '        .AutoSizeCols()
    '    End With
    '    Call monColorSubTotalCrane()
    'End Sub



End Class
