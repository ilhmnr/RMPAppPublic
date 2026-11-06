Imports System.ComponentModel
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmTrnPremiPengawas
    Dim dt As DataTable = New DataTable()
    Dim RupiahID As Integer
    Dim RangeID
    Dim JenisKb, TransID As String
    Dim Grade As String
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call HeaderFG()
        Modul_RMP.Combo.SetPancang(cmbPancang)
        DtPeriode.Value = Format(Now, "MM/yyyy")
    End Sub

    Public Sub HeaderFG()
        Dim txt As CellRange
        With fg
            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
            .Cols.Count = 11
            '.Cols.Fixed = 2
            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(1).StyleNew.BackColor = Color.FromArgb(242, 222, 222)
            .Rows(1).StyleFixedNew.BackColor = Color.FromArgb(223, 240, 216)

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 2
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Rows(1).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 0, 1, 0) : txt.Data = "No" : .Cols(0).AllowMerging = True
            txt = .GetCellRange(0, 1, 1, 1) : txt.Data = "TripKapal" : .Cols(1).AllowMerging = True
            txt = .GetCellRange(0, 2, 1, 2) : txt.Data = "NamaKapal" : .Cols(2).AllowMerging = True : .Cols(2).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Netto-2(PCG)" : .Cols(3).TextAlign = TextAlignEnum.RightCenter
            txt = .GetCellRange(1, 3, 1, 3) : txt.Data = "Kb-A (Kg)" : .Cols(4).AllowMerging = True : .Cols(4).TextAlign = TextAlignEnum.RightCenter
            txt = .GetCellRange(0, 4, 0, 8) : txt.Data = "Netto-2 (Pabrik)" : .Cols(6).TextAlign = TextAlignEnum.RightCenter
            txt = .GetCellRange(1, 4, 1, 4) : txt.Data = "Kb- A (Kg)" : .Cols(4).AllowMerging = True : .Cols(4).TextAlign = TextAlignEnum.RightCenter : .Cols(4).Visible = True
            txt = .GetCellRange(1, 5, 1, 5) : txt.Data = "%" : .Cols(5).AllowMerging = True : .Cols(5).Format = "#,###0.0#" : .Cols(5).Visible = True
            txt = .GetCellRange(1, 6, 1, 6) : txt.Data = "Kb-B (Kg)" : .Cols(6).AllowMerging = True : .Cols(6).TextAlign = TextAlignEnum.RightCenter : .Cols(6).Visible = True
            txt = .GetCellRange(1, 7, 1, 7) : txt.Data = "%" : .Cols(7).AllowMerging = True : .Cols(7).Format = "#,###0.0#" : .Cols(7).Visible = True : .Cols(7).TextAlign = TextAlignEnum.RightCenter
            txt = .GetCellRange(1, 8, 1, 8) : txt.Data = "TotalKB" : .Cols(8).AllowMerging = True : .Cols(8).TextAlign = TextAlignEnum.RightCenter : .Cols(8).Visible = True
            txt = .GetCellRange(0, 9, 0, 10) : txt.Data = "Susut KG"
            txt = .GetCellRange(1, 9, 1, 9) : txt.Data = "Qty(KG)" : .Cols(9).AllowMerging = True : .Cols(9).TextAlign = TextAlignEnum.RightCenter
            txt = .GetCellRange(1, 10, 1, 10) : txt.Data = "%" : .Cols(7).AllowMerging = True : .Cols(10).Format = "#,###0.0#" : .Cols(10).Visible = True

        End With
    End Sub

    Private Sub ShowDataLicin()
        Dim i As Integer = 2
        Dim sql As String = ""

        sql = Modul_RMP.Func.SetCondition(sql, "a.IDPancang ='" & cmbPancang.SelectedValue.ToString & "'")

        Try
            dt = Modul_RMP.DB.ExecuteQuery(StrConnAccounting, "with tblKBAPabrik as (SELECT Trip,IDPancang,IDKapal, SUM(NETTO) as kbaPabrik 
				FROM vwRMTrnPenerimaanKBDtla 
				WHERE IDPANCANG='" & cmbPancang.SelectedValue & "' and month(tglterima)='" & Format(DtPeriode.Value, "MM") & "' and year(TglTerima)='" & Format(DtPeriode.Value, "yyyy") & "' and grade='Licin-A'
				group by trip,IDPancang,IDkapal,TRIP
				
				union

					   select Trip collate Latin1_General_CI_AS,IDPancang,IDKapal,sum(netto1) as kbaPabrik
				FROM  [192.168.2.3].[PSGRMP].[dbo].[vwRMTrnPenerimaanKBKgDtlaNew_PCG]
				WHERE IDPANCANG='" & cmbPancang.SelectedValue & "' and month(tglterima)='" & Format(DtPeriode.Value, "MM") & "' and year(TglTerima)='" & Format(DtPeriode.Value, "yyyy") & "' and jenis='Licin-A' 
				group by trip,IDPancang,IDkapal,TRIP
				),

	tblKBBPabrik as (SELECT Trip,IDPancang,IDKapal, SUM(NETTO) as kbbPabrik 
				FROM RSUPAccounting..vwRMTrnPenerimaanKBDtla 
				WHERE IDPANCANG='" & cmbPancang.SelectedValue & "' and month(tglterima)='" & Format(DtPeriode.Value, "MM") & "' and year(TglTerima)='" & Format(DtPeriode.Value, "yyyy") & "' and grade='Licin-B'
				group by trip,IDPancang,IDkapal,TRIP
				
				union

					   select Trip collate Latin1_General_CI_AS,IDPancang,IDKapal,sum(netto1) as kbbPabrik
				FROM  [192.168.2.3].[PSGRMP].[dbo].[vwRMTrnPenerimaanKBKgDtlaNew_PCG]
				WHERE IDPANCANG='" & cmbPancang.SelectedValue & "' and month(tglterima)='" & Format(DtPeriode.Value, "MM") & "' and year(TglTerima)='" & Format(DtPeriode.Value, "yyyy") & "' and jenis='Licin-B' 
				group by trip,IDPancang,IDkapal,TRIP
				),

 tblKBAPancang as (select trip,IDPancang,IDKapal,Kapal as NamaKapal,sum(NettoAkhir) as kbaPancang 
				from[RMPApp].[dbo].[TblTrnKelapaHdr]
				where IDPancang='" & cmbPancang.SelectedValue & "' and MONTH(TglTerima)='" & Format(DtPeriode.Value, "MM") & "' and year(TglTerima)='" & Format(DtPeriode.Value, "yyyy") & "'
				group by trip,IDPancang,IDKapal,Kapal)



				select distinct tblKBAPancang.trip,tblKBAPancang.IDKapal,tblKBAPancang.NamaKapal,
				tblKBAPancang.kbaPancang,
				tblKBAPabrik.kbaPabrik,
				tblKBBPabrik.kbbPabrik,
				(tblKBAPabrik.kbaPabrik+tblKBBPabrik.kbbPabrik) as totalkb, 
				(tblKBAPancang.kbaPancang-(tblKBAPabrik.kbaPabrik+tblKBBPabrik.kbbPabrik)) as qtySusut,
				round((((tblKBAPancang.kbaPancang-(tblKBAPabrik.kbaPabrik+tblKBBPabrik.kbbPabrik))/tblKBAPancang.kbaPancang)*100),1) as persenSusust,
				round(((tblKBAPabrik.kbaPabrik/(tblKBAPabrik.kbaPabrik+tblKBBPabrik.kbbPabrik))*100),0) as persenkbaPabrik,
				round(((tblKBBPabrik.kbbPabrik/(tblKBAPabrik.kbaPabrik+tblKBBPabrik.kbbPabrik))*100),1) as persenkbbPabrik
				from tblKBAPancang 
				left join tblKBAPabrik 
				on tblKBAPancang.IDKapal=tblKBAPabrik.IDKapal and tblKBAPancang.Trip=tblKBAPabrik.trip
				left join tblKBBPabrik
				on tblKBAPancang.IDKapal=tblKBBPabrik.IDKapal and tblKBAPancang.Trip=tblKBBPabrik.trip
				group by tblKBAPancang.trip,tblKBAPancang.IDKapal,tblKBAPancang.NamaKapal,tblKBAPancang.kbaPancang,tblKBAPabrik.kbaPabrik ,tblKBBPabrik.kbbPabrik")



            If dt.Rows.Count > 0 Then
                With fg
                    fg.Rows.Count=2
                    For Each row As DataRow In dt.Rows
                        .AddItem(i - 2)
                        .Item(i, 0) = i - 2

                        .Item(i, 1) = row.Item("trip")
                        .Item(i, 2) = row.Item("NamaKapal")
                        .Item(i, 3) = IIf(IsDBNull(row.Item("kbaPancang")), 0, row.Item("kbaPancang"))
                        .Item(i, 4) = IIf(IsDBNull(row.Item("kbaPabrik")), 0, row.Item("kbaPabrik"))
                        .Item(i, 5) = IIf(IsDBNull(row.Item("persenkbaPabrik")), 0, row.Item("persenkbaPabrik"))
                        .Item(i, 6) = IIf(IsDBNull(row.Item("kbbPabrik")), 0, row.Item("kbbPabrik"))
                        .Item(i, 7) = IIf(IsDBNull(row.Item("persenkbbPabrik")), 0, row.Item("kbbPabrik"))
                        .Item(i, 8) = IIf(IsDBNull(row.Item("totalkb")), 0, row.Item("totalkb"))
                        .Item(i, 9) = IIf(IsDBNull(row.Item("qtySusut")), 0, row.Item("qtySusut"))
                        .Item(i, 10) = IIf(IsDBNull(row.Item("persenSusust")), 0, row.Item("persenSusust"))


                        i = i + 1
                    Next
                    .AutoSizeCols()
                End With


            Else
                MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
                fg.Rows.Count=2

            End If

            Call ShowTotalsPcg1()

        Catch EX As Exception
            '  MsgBox(EX.Message)
            fg.Rows.Count=2
            fgHasil.Rows.Clear()
            fgPerhitungan.Rows.Clear()
            fgg.Rows.Clear()
        End Try
    End Sub
    Private Sub ShowDataJambul()
        Dim i As Integer = 2
        Dim sql As String = ""

        sql = Modul_RMP.Func.SetCondition(sql, "a.IDPancang ='" & cmbPancang.SelectedValue.ToString & "'")

        Try
            dt = Modul_RMP.DB.ExecuteQuery(StrConnAccounting, "with tblKBAPabrik as (SELECT Trip,IDPancang,IDKapal, SUM(NETTO) as kbaPabrik 
				FROM vwRMTrnPenerimaanKBDtla 
				WHERE IDPANCANG='" & cmbPancang.SelectedValue & "' and month(tglterima)='" & Format(DtPeriode.Value, "MM") & "' and year(TglTerima)='" & Format(DtPeriode.Value, "yyyy") & "' and grade='Jambul-A'
				group by trip,IDPancang,IDkapal,TRIP
				
				union

					   select Trip collate Latin1_General_CI_AS,IDPancang,IDKapal,sum(netto1) as kbaPabrik
				FROM  [192.168.2.3].[PSGRMP].[dbo].[vwRMTrnPenerimaanKBKgDtlaNew_PCG]
				WHERE IDPANCANG='" & cmbPancang.SelectedValue & "' and month(tglterima)='" & Format(DtPeriode.Value, "MM") & "' and year(TglTerima)='" & Format(DtPeriode.Value, "yyyy") & "' and jenis='Jambul-A'
				group by trip,IDPancang,IDkapal,TRIP
				),

	tblKBBPabrik as (SELECT Trip,IDPancang,IDKapal, SUM(NETTO) as kbbPabrik 
				FROM RSUPAccounting..vwRMTrnPenerimaanKBDtla 
				WHERE IDPANCANG='" & cmbPancang.SelectedValue & "' and month(tglterima)='" & Format(DtPeriode.Value, "MM") & "' and year(TglTerima)='" & Format(DtPeriode.Value, "yyyy") & "' and grade='Jambul-B'
				group by trip,IDPancang,IDkapal,TRIP
				
				union

					   select Trip collate Latin1_General_CI_AS,IDPancang,IDKapal,sum(netto1) as kbbPabrik
				FROM  [192.168.2.3].[PSGRMP].[dbo].[vwRMTrnPenerimaanKBKgDtlaNew_PCG]
				WHERE IDPANCANG='" & cmbPancang.SelectedValue & "' and month(tglterima)='" & Format(DtPeriode.Value, "MM") & "' and year(TglTerima)='" & Format(DtPeriode.Value, "yyyy") & "' and jenis='Jambul-A' 
				group by trip,IDPancang,IDkapal,TRIP
				),

 tblKBAPancang as (select trip,IDPancang,IDKapal,Kapal as NamaKapal,sum(NettoAkhir) as kbaPancang 
				from[RMPApp].[dbo].[TblTrnKelapaHdr]
				where IDPancang='" & cmbPancang.SelectedValue & "' and MONTH(TglTerima)='" & Format(DtPeriode.Value, "MM") & "' and year(TglTerima)='" & Format(DtPeriode.Value, "yyyy") & "'
				group by trip,IDPancang,IDKapal,Kapal)



				select distinct tblKBAPancang.trip,tblKBAPancang.IDKapal,tblKBAPancang.NamaKapal,
				tblKBAPancang.kbaPancang,
				tblKBAPabrik.kbaPabrik,
				tblKBBPabrik.kbbPabrik,
				(tblKBAPabrik.kbaPabrik+tblKBBPabrik.kbbPabrik) as totalkb, 
				(tblKBAPancang.kbaPancang-(tblKBAPabrik.kbaPabrik+tblKBBPabrik.kbbPabrik)) as qtySusut,
				round((((tblKBAPancang.kbaPancang-(tblKBAPabrik.kbaPabrik+tblKBBPabrik.kbbPabrik))/tblKBAPancang.kbaPancang)*100),1) as persenSusust,
				round(((tblKBAPabrik.kbaPabrik/(tblKBAPabrik.kbaPabrik+tblKBBPabrik.kbbPabrik))*100),0) as persenkbaPabrik,
				round(((tblKBBPabrik.kbbPabrik/(tblKBAPabrik.kbaPabrik+tblKBBPabrik.kbbPabrik))*100),1) as persenkbbPabrik
				from tblKBAPancang 
				left join tblKBAPabrik 
				on tblKBAPancang.IDKapal=tblKBAPabrik.IDKapal and tblKBAPancang.Trip=tblKBAPabrik.trip
				left join tblKBBPabrik
				on tblKBAPancang.IDKapal=tblKBBPabrik.IDKapal and tblKBAPancang.Trip=tblKBBPabrik.trip
				group by tblKBAPancang.trip,tblKBAPancang.IDKapal,tblKBAPancang.NamaKapal,tblKBAPancang.kbaPancang,tblKBAPabrik.kbaPabrik ,tblKBBPabrik.kbbPabrik")



            If dt.Rows.Count > 0 Then
                With fg
                    fg.Rows.Count=2
                    For Each row As DataRow In dt.Rows
                        .AddItem(i - 2)
                        '.Item(i, "No") = row.Item("No")
                        .Item(i, 0) = i - 2
                        .Item(i, 1) = row.Item("trip")
                        .Item(i, 2) = row.Item("NamaKapal")
                        .Item(i, 3) = IIf(IsDBNull(row.Item("kbaPancang")), 0, row.Item("kbaPancang"))
                        .Item(i, 4) = IIf(IsDBNull(row.Item("kbaPabrik")), 0, row.Item("kbaPabrik"))
                        .Item(i, 5) = IIf(IsDBNull(row.Item("persenkbaPabrik")), 0, row.Item("persenkbaPabrik"))
                        .Item(i, 6) = IIf(IsDBNull(row.Item("kbbPabrik")), 0, row.Item("kbbPabrik"))
                        .Item(i, 7) = IIf(IsDBNull(row.Item("persenkbbPabrik")), 0, row.Item("kbbPabrik"))
                        .Item(i, 8) = IIf(IsDBNull(row.Item("totalkb")), 0, row.Item("totalkb"))
                        .Item(i, 9) = IIf(IsDBNull(row.Item("qtySusut")), 0, row.Item("qtySusut"))
                        .Item(i, 10) = IIf(IsDBNull(row.Item("persenSusust")), 0, row.Item("persenSusust"))


                        i = i + 1
                    Next
                    .AutoSizeCols()
                End With




            Else
                MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
                fg.Rows.Count=2
            End If

            Call ShowTotalsPcg1()

        Catch EX As Exception
            ' MsgBox(EX.Message)
            fg.Rows.Count=2
            fgHasil.Rows.Clear()
            fgPerhitungan.Rows.Clear()
            fgg.Rows.Clear()

        End Try
    End Sub

    Private Sub ShowTotalsPcg1()
        With fg
            .Tree.Column = 0
            .Tree.Style = TreeStyleFlags.Simple
            .Subtotal(AggregateEnum.Clear)
            .Subtotal(AggregateEnum.Sum, -1, -1, 3, "")
            .Subtotal(AggregateEnum.Sum, -1, -1, 4, "")
            .Subtotal(AggregateEnum.Sum, -1, -1, 6, "")
            .Subtotal(AggregateEnum.Sum, -1, -1, 8, "")
            .Subtotal(AggregateEnum.Sum, -1, -1, 9, "")
            .Item(2, 5) = FormatNumber((.Item(2, 4) / .Item(2, 8) * 100), 1)
            'FormatNumber(textboxt.Text, 1)
            '.Item(2, 7) = Math.Round(((.Item(2, 6) / .Item(2, 8)) * 100), 0)
            .Item(2, 7) = FormatNumber((.Item(2, 6) / .Item(2, 8) * 100), 1)
            .Item(2, 10) = FormatNumber((.Item(2, 9) / .Item(2, 3) * 100), 1)
            'Math.Round((Val(jumlahpersen) / Val(jumlahsampel)), 0)
            .AutoSizeCols()
        End With
        Call ColorSubTotalPcg1()
    End Sub

    Private Sub ColorSubTotalPcg1()
        Dim cs As C1.Win.C1FlexGrid.CellStyle
        With fg
            cs = .Styles(C1.Win.C1FlexGrid.CellStyleEnum.GrandTotal)
            cs.BackColor = Color.FromArgb(73, 173, 8)
            cs.ForeColor = Color.White
            cs.Font = New Font(Font, FontStyle.Bold)
        End With
    End Sub
    Private Sub cmbPancang_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbPancang.KeyUp
        UI.AutoCompleteCombo_KeyUp(cmbPancang, e)
    End Sub
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs)
        If cmbPancang.Text = "" Then
            MsgBox("Pilih Pancang", vbExclamation)
            Exit Sub
        End If

        If rdLicin.Checked = True Then
            Call ShowDataLicin()
        Else
            Call ShowDataJambul()
        End If

        If fg.Rows.Count - 2 = 0 Then
            fgHasil.Rows.Clear()
        Else
            Call LoadItemfgHasil()
            Call HasilPengawas()
            fgHasil.Item("QuantityKg", 2).Value = fgHasil.Item("ItemTarget", 2).Value / fgHasil.Item("JumlahTrip", 2).Value
        End If
        'If fg.Item(2, 7) <> 0 Then
        'Call HasilPengawas()
        'fgHasil.Item("QuantityKg", 2).Value = fgHasil.Item("ItemTarget", 2).Value / fgHasil.Item("JumlahTrip", 2).Value
        'End If
        ''
        Call NoTransId()


    End Sub

    Sub LoadItemfgHasil()
        Dim SQL, SQL2, SQL3, SQL4 As String, i As Integer

        SQL = "SELECT *FROM [RMPApp].[dbo].[TblItemPremi] "

        Using koneksi As New SqlCommand(SQL, DB.OpenConnection(StrConnRMPApp))
            Using DR = koneksi.ExecuteReader()
                If DR.HasRows Then
                    fgHasil.RowCount = 0
                    While DR.Read
                        With fgHasil
                            .Rows.Add()
                            .Item("No", i).Value = i + 1
                            .Item("Item", i).Value = DR!Item
                        End With
                        i += 1
                    End While
                Else
                    fgHasil.Rows.Clear()
                    Exit Sub
                End If
                DR.Close()
            End Using
        End Using
        DB.CloseConnection()
        Call LoadTrip()
        GetTanggalAkhirBulan()
    End Sub

    Sub LoadItemfgPerhitungan()
        Dim SQL As String, i As Integer

        SQL = "SELECT *FROM [RMPApp].[dbo].[TblItemPremi] "

        Using koneksi As New SqlCommand(SQL, DB.OpenConnection(StrConnRMPApp))
            Using DR = koneksi.ExecuteReader()
                If DR.HasRows Then
                    fgPerhitungan.RowCount = 0
                    While DR.Read
                        With fgPerhitungan
                            .Rows.Add()
                            .Item("Noo", i).Value = i + 1
                            .Item("Iitem", i).Value = DR!Item
                        End With
                        i += 1
                    End While
                Else
                    fgPerhitungan.Rows.Clear()
                    Exit Sub
                End If
                DR.Close()
            End Using
        End Using
        DB.CloseConnection()

    End Sub
    Sub LoadTrip()
        Dim SQL As String, i As Integer

        SQL = "with tblCountTrip as (select Tglterima,trip,IDPancang,IDKapal,Kapal as NamaKapal,sum(NettoAkhir) as kbaPancang " &
                "From [RMPApp].[dbo].[TblTrnKelapaHdr]" &
                "group by trip,IDPancang,IDKapal,Kapal,TglTerima)" &
                "select count(*) as Trip from tblCountTrip where IDPancang='" & cmbPancang.SelectedValue & "' and MONTH(TglTerima)='" & Format(DtPeriode.Value, "MM") & "' and year(TglTerima)='" & Format(DtPeriode.Value, "yyyy") & "';"

        Using koneksi As New SqlCommand(SQL, DB.OpenConnection(StrConnRMPApp))
            Using DR = koneksi.ExecuteReader()
                If DR.HasRows Then
                    While DR.Read
                        With fgHasil
                            .Item("JumlahTrip", 0).Value = DR!Trip
                            .Item("JumlahTrip", 1).Value = DR!Trip
                        End With
                    End While

                End If
                DR.Close()
            End Using
        End Using
        DB.CloseConnection()
    End Sub
    Sub HasilPengawas()
        fgHasil.Item("QuantityKg", 0).Value = CDbl(fg.Item(2, 6))
        fgHasil.Item("QuantityKg", 1).Value = fg.Item(2, 9)



        fgHasil.Item("ItemTarget", 0).Value = fg.Item(2, 7)
        fgHasil.Item("ItemTarget", 1).Value = fg.Item(2, 10)
        fgHasil.Item("ItemTarget", 2).Value = fg.Item(2, 3)
    End Sub

    Private Sub btnKalkulasi_Click(sender As Object, e As EventArgs) Handles btnKalkulasi.Click
        Call LoadItemfgPerhitungan()
        Call LoadItemForKalkulasi()
        Call Kalkulasi()

    End Sub
    Sub Kalkulasi()
        'fgPerhitungan.Rows.Clear()

        fgPerhitungan.Item("Hasil", 0).Value = fgHasil.Item("ItemTarget", 0).Value
        fgPerhitungan.Item("Hasil", 1).Value = fgHasil.Item("ItemTarget", 1).Value
        fgPerhitungan.Item("Hasil", 2).Value = fgHasil.Item("ItemTarget", 2).Value

        ' -------------------Mencari Persen

        If fgPerhitungan.Item("Hasil", 0).Value < fgPerhitungan.Item("IitemTarget", 0).Value Then
            fgPerhitungan.Item("Persen", 0).Value = 100
        Else
            fgPerhitungan.Item("Persen", 0).Value = FormatNumber((fgPerhitungan.Item("IitemTarget", 0).Value / fgPerhitungan.Item("Hasil", 0).Value * 100), 1)
        End If

        If fgPerhitungan.Item("Hasil", 1).Value < fgPerhitungan.Item("IitemTarget", 1).Value Then
            fgPerhitungan.Item("Persen", 1).Value = 100
        Else
            fgPerhitungan.Item("Persen", 1).Value = FormatNumber((fgPerhitungan.Item("IitemTarget", 1).Value / fgPerhitungan.Item("Hasil", 1).Value * 100), 1)
        End If

        If fgPerhitungan.Item("Hasil", 2).Value > fgPerhitungan.Item("IitemTarget", 2).Value Then
            fgPerhitungan.Item("Persen", 2).Value = 100
        Else
            fgPerhitungan.Item("Persen", 2).Value = FormatNumber((fgPerhitungan.Item("Hasil", 2).Value / fgPerhitungan.Item("IitemTarget", 2).Value * 100), 1)
        End If

        '----------------Mecari Hasil Point
        ' fgPerhitungan.Item("HasilPoint", 0).Value = Val(FormatNumber((fgPerhitungan.Item("Persen", 0).Value * fgPerhitungan.Item("StdPoint", 0).Value / 100), 1))
        fgPerhitungan.Item("HasilPoint", 0).Value = Math.Ceiling(fgPerhitungan.Item("Persen", 0).Value * fgPerhitungan.Item("StdPoint", 0).Value / 100)
        fgPerhitungan.Item("HasilPoint", 1).Value = FormatNumber((fgPerhitungan.Item("Persen", 1).Value * fgPerhitungan.Item("StdPoint", 1).Value / 100), 1)
        fgPerhitungan.Item("HasilPoint", 2).Value = FormatNumber((fgPerhitungan.Item("Persen", 2).Value * fgPerhitungan.Item("StdPoint", 2).Value / 100), 1)


        '--------------------Mecari Hasil Akhir
        fgg.Rows.Clear()
        fgg.Rows.Add()
        With fgg
            .Item("MaksimalKBB", 0).Value = fgPerhitungan("HasilPoint", 0).Value
            .Item("MaksimalSusutKG", 0).Value = fgPerhitungan("HasilPoint", 1).Value
            .Item("VolumeKBPancang", 0).Value = fgPerhitungan("HasilPoint", 2).Value
        End With

        '------------------Mencari Total dari HasilPoint & Standart Point
        txtTotalHasilPoint.Text = CDbl(fgPerhitungan.Item("HasilPoint", 0).Value) + CDbl(fgPerhitungan.Item("HasilPoint", 1).Value) + CDbl(fgPerhitungan.Item("HasilPoint", 2).Value)
        txttotalStdPoint.Text = CDbl(fgPerhitungan.Item("StdPoint", 0).Value) + CDbl(fgPerhitungan.Item("StdPoint", 1).Value) + CDbl(fgPerhitungan.Item("StdPoint", 2).Value)


        '-----------------Mencari Rp/point 

        'Dim SQL, SQL2, satu, dua As String, i As Integer

        'If fgHasil.Item("QuantityKG", 2).Value <= 35000 Then
        '    SQL2 = Modul_RMP.Func.SetCondition(SQL2, "IDPancang = '" & cmbPancang.SelectedValue & "'")
        'End If


        'SQL = "Select * from [RMPApp].[dbo].[TblMstLavelBonusRupiah] where 1 = 1 "

        '    Using koneksi As New SqlCommand(SQL, DB.OpenConnection(StrConnRMPApp))
        '    Using DR = koneksi.ExecuteReader()
        '        If DR.HasRows Then
        '            While DR.Read
        '                With fgHasil
        '                    satu = DR!LevelRupiah1
        '                    '.Item("JumlahTrip", 0).Value = DR!Trip
        '                    '.Item("JumlahTrip", 1).Value = DR!Trip

        '                    'If fgHasil.Item("QuantityKG", 2).Value <= 35000 Then
        '                    '    RupiahID = 1
        '                    'ElseIf fgHasil.Item("QuantityKG", 2).Value >= 35000 And fgHasil.Item("QuantityKG", 2).Value <= 40000 Then
        '                    '    RupiahID = 1
        '                    'ElseIf fgHasil.Item("QuantityKG", 2).Value >= 40000 And fgHasil.Item("QuantityKG", 2).Value <= 45000 Then
        '                    '    RupiahID = 2
        '                    'ElseIf fgHasil.Item("QuantityKG", 2).Value >= 45000 And fgHasil.Item("QuantityKG", 2).Value <= 50000 Then
        '                    '    RupiahID = 3
        '                    'ElseIf fgHasil.Item("QuantityKG", 2).Value >= 50000 And fgHasil.Item("QuantityKG", 2).Value <= 55000 Then
        '                    '    RupiahID = 4
        '                    'ElseIf fgHasil.Item("QuantityKG", 2).Value >= 55000 And fgHasil.Item("QuantityKG", 2).Value <= 60000 Then
        '                    '    RupiahID = 5
        '                    'ElseIf fgHasil.Item("QuantityKG", 2).Value >= 60000 Then
        '                    '    RupiahID = 6
        '                    ' End If
        '                End With
        '            End While

        '        End If
        '        DR.Close()
        '    End Using
        'End Using
        'DB.CloseConnection()



        If fgHasil.Item("QuantityKG", 2).Value <= 35000 Then
            RupiahID = 1
        ElseIf fgHasil.Item("QuantityKG", 2).Value >= 35000 And fgHasil.Item("QuantityKG", 2).Value <= 40000 Then
            RupiahID = 1
        ElseIf fgHasil.Item("QuantityKG", 2).Value >= 40000 And fgHasil.Item("QuantityKG", 2).Value <= 45000 Then
            RupiahID = 2
        ElseIf fgHasil.Item("QuantityKG", 2).Value >= 45000 And fgHasil.Item("QuantityKG", 2).Value <= 50000 Then
            RupiahID = 3
        ElseIf fgHasil.Item("QuantityKG", 2).Value >= 50000 And fgHasil.Item("QuantityKG", 2).Value <= 55000 Then
            RupiahID = 4
        ElseIf fgHasil.Item("QuantityKG", 2).Value >= 55000 And fgHasil.Item("QuantityKG", 2).Value <= 60000 Then
            RupiahID = 5
        ElseIf fgHasil.Item("QuantityKG", 2).Value >= 60000 Then
            RupiahID = 6
        End If

        'Call MsgBox(RupiahID)


        If txtTotalHasilPoint.Text < 80 Then
            RangeID = ""
        End If
        If txtTotalHasilPoint.Text >= 80 And txtTotalHasilPoint.Text <= 86 Then
            RangeID = 4
        ElseIf txtTotalHasilPoint.Text >= 86 And txtTotalHasilPoint.Text < 91 Then
            RangeID = 3
        ElseIf txtTotalHasilPoint.Text >= 91 And txtTotalHasilPoint.Text < 96 Then
            RangeID = 2
        ElseIf txtTotalHasilPoint.Text >= 96 And txtTotalHasilPoint.Text <= 100 Then
            RangeID = 1
        End If

        Call HasilRpPoint()

        '    ---------------Mencari Jumlah Rupiah
        Dim a, b As Double
        a = (CDbl(fgg.Item("MaksimalKBB", 0).Value) + CDbl(fgg.Item("MaksimalSusutKG", 0).Value) + CDbl(fgg.Item("VolumeKBPancang", 0).Value))
        b = Val(fgg.Item("RpPoint", 0).Value)
        fgg.Item("JumlahRp", 0).Value = a * b

        If fgg.Item("RpPoint", 0).Value = "" Then
            fgg.Item("RpPoint", 0).Value = 0
        End If
    End Sub


    Sub HasilRpPoint()
        Dim SQL, SQL2, SQL3, SQL4 As String, i As Integer

        SQL = "select * from TblHubMstLavelBonus where RupiahId='" & RupiahID & "' and RangeID='" & RangeID & "' and CreatedDate=(Select Max(CreatedDate) from RMPApp..TblHubMstLavelBonus where RupiahId='" & RupiahID & "' and RangeID='" & RangeID & "')"

        Using koneksi As New SqlCommand(SQL, DB.OpenConnection(StrConnRMPApp))
            Using DR = koneksi.ExecuteReader()
                If DR.HasRows Then
                    While DR.Read
                        With fgg
                            .Item("RpPoint", 0).Value = DR!Point
                            'If IsDBNull(DR!Point) Then .Item("RpPoint", i).Value = 0 Else .Item("RpPoint", i).Value = DR!Point
                        End With
                    End While
                    Exit Sub
                End If
                DR.Close()
            End Using
        End Using
        DB.CloseConnection()
    End Sub
    Sub LoadItemForKalkulasi()
        Dim SQL, SQL2, SQL3, SQL4 As String, i As Integer

        If rdJambul.Checked = True Then
            Grade = "JB"
        Else
            Grade = "LC"
        End If
        ' SQL = "select * from  vwMstPremiPengawasdanInspektorDtl where IDpancang='" & cmbPancang.SelectedValue & "'"
        SQL = "select * from  vwMstPremiPengawasdanInspektorDtl where IDpancang='" & cmbPancang.SelectedValue & "' and CreatedDate=(Select Max(CreatedDate) from vwMstPremiPengawasdanInspektorDtl where IDPancang='" & cmbPancang.SelectedValue & "'and Grade_KB = '" & Grade & "') "

        Using koneksi As New SqlCommand(SQL, DB.OpenConnection(StrConnRMPApp))
            Using DR = koneksi.ExecuteReader()
                If DR.HasRows Then
                    While DR.Read
                        With fgPerhitungan

                            .Item("IitemTarget", 0).Value = DR!Batas_KB_B
                            .Item("IitemTarget", 1).Value = DR!Batas_Susut_KB
                            .Item("IitemTarget", 2).Value = DR!Volume

                            .Item("StdPoint", 0).Value = FormatNumber((DR!Maksimal_KBB_Pengawas), 1)
                            .Item("StdPoint", 1).Value = FormatNumber((DR!Max_Susut_Kg_Pengawas), 1)
                            .Item("StdPoint", 2).Value = FormatNumber((DR!Vol_KB_Pcg_Pengawas), 1)

                        End With
                        i += 1
                    End While
                Else
                    fgPerhitungan.Rows.Clear()
                    Exit Sub
                End If
                DR.Close()
            End Using
        End Using
        DB.CloseConnection()
    End Sub

    Sub GetTanggalAkhirBulan()
        Dim Tanggal As Date
        Dim TanggalAkhir As Date
        Tanggal = DateSerial(Format(DtPeriode.Value, "yyyy"), Format(DtPeriode.Value, "MM"), 10) 'membuat tanggal 6 June 2022
        'rumus mencari tanggal akhir dalam suatu bulan
        TanggalAkhir = DateSerial(Year(Tanggal), Month(Tanggal) + 1, 0)
        ' TanggalAkhir = DateSerial(Month(Tanggal) + 1, 0)
        Debug.Print(Format(TanggalAkhir, "dd MMMM yyyy"))
        'hasil = 30 June 2021

        fgHasil.Item("JumlahTrip", 2).Value = Format(TanggalAkhir, "dd")
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        fgHasil.Rows.Clear()
        fgPerhitungan.Rows.Clear()
        fgg.Rows.Clear()

        TransID = ""

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If rdJambul.Checked = True Then
            JenisKb = "Jambul"
        Else
            JenisKb = "Licin"
        End If

        Call SimpanData()
    End Sub
    Private Sub NoTransId()
        Try
            Dim connb As New SqlConnection(StrConnRMPApp)
            connb.Open()
            Dim NoReff As String
            Dim sql As String


            sql = "Select Top 1 HeaderID From  RMPApp..TblTrnPremiPengawasHdr order by HeaderID Desc "

            Dim cmd2 As New SqlClient.SqlCommand(sql, connb)
            Dim reader As SqlClient.SqlDataReader
            reader = cmd2.ExecuteReader
            If reader.HasRows Then
                Do While reader.Read
                    NoReff = Mid("000", 1, 3 - (Val(Trim(reader.Item(0).ToString)) + 1).ToString.Length) + (Val(Trim(reader.Item(0).ToString)) + 1).ToString
                    TransID = NoReff & "/" & Format(DtPeriode.Value, "MM") & Format(DtPeriode.Value, "yyyy")
                Loop
            Else
                TransID = "001" & "/" & Format(DtPeriode.Value, "MM") & Format(DtPeriode.Value, "yyyy")
            End If
            connb.Close()
            ' End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Default
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub SimpanData()

        Dim Koneksis As SqlConnection = DB.OpenConnection(StrConnRMPApp)
        Dim Transaksi As SqlTransaction

        Transaksi = Koneksis.BeginTransaction
        Me.Cursor = Cursors.WaitCursor
        Try
            If Periode(TransID) = "1" Then
                MessageBox.Show("Data" & "" & cmbPancang.Text & "" & "Dengan Periode" & "" & Format(DtPeriode.Value, "MM/yyyy") & "" & "" & "Sudah Ada", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            If SimpanDataHDR(Koneksis, Transaksi) = False Then
                Transaksi.Rollback()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            If SimpanDataDtl(Koneksis, Transaksi) = False Then
                Transaksi.Rollback()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            Transaksi.Commit()
            Me.Cursor = Cursors.Default
            MessageBox.Show("Simpan data berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Transaksi.Rollback()
            Koneksis.Close()
            Me.Cursor = Cursors.Default
        Finally
            Koneksis.Close()
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function SimpanDataHDR(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        Dim MyCMD As New SqlCommand
        SimpanDataHDR = False
        Try
            With MyCMD
                .Connection = Conn
                .CommandType = CommandType.StoredProcedure
                .CommandText = "RMPApp..spSaveTrnPengawasPremiHdr"
                .Transaction = Trans
                .Parameters.Add("@TransID", SqlDbType.VarChar).Value = TransID
                .Parameters.Add("IDPancang", SqlDbType.Int).Value = cmbPancang.SelectedValue
                .Parameters.Add("@Periode", SqlDbType.VarChar).Value = Format(DtPeriode.Value, "MM/yyyy")
                .Parameters.Add("@JenisKb", SqlDbType.VarChar).Value = JenisKb
                .Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = ClsSession.UserID
                .Parameters.Add(New SqlParameter("@Error", SqlDbType.VarChar, 200, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
                '.Parameters.Add(New SqlParameter("@Pesan", SqlDbType.VarChar, 200, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
                .ExecuteNonQuery()
                .Dispose()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message & " infosp :  " & MyCMD.Parameters("@Error saveHdr").Value)
            'MessageBox.Show(ex.Message & " infosp : " & MyCMD.Parameters("@Pesan ").Value)
            Return False
        End Try
        Return True
    End Function

    Private Function SimpanDataDtl(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        Dim MyCMD As New SqlCommand
        SimpanDataDtl = False
        Try
            With MyCMD
                .Connection = Conn
                .CommandType = CommandType.StoredProcedure
                .CommandText = "RMPApp..spSaveTrnPengawasPremiDtl"
                .Transaction = Trans
                .Parameters.Add("@TransID", SqlDbType.VarChar).Value = TransID
                .Parameters.Add("@HasilMaksimalKBB", SqlDbType.Decimal).Value = fgPerhitungan.Item("Hasil", 0).Value
                .Parameters.Add("@HasilMaksimalSusutKg", SqlDbType.Decimal).Value = fgPerhitungan.Item("Hasil", 1).Value
                .Parameters.Add("@HasilVolumeKBPancang", SqlDbType.Decimal).Value = fgPerhitungan.Item("Hasil", 2).Value

                .Parameters.Add("@PersenMaksimalKBB", SqlDbType.Decimal).Value = fgPerhitungan.Item("Persen", 0).Value
                .Parameters.Add("@PersenMaksimalSusutKg", SqlDbType.Decimal).Value = fgPerhitungan.Item("Persen", 1).Value
                .Parameters.Add("@PersenVolumeKbPancang", SqlDbType.Decimal).Value = fgPerhitungan.Item("Persen", 2).Value

                .Parameters.Add("@HasilPointMaksimalKBB", SqlDbType.Decimal).Value = fgPerhitungan.Item("HasilPoint", 0).Value
                .Parameters.Add("@HasilPointMaksimalSusutKg", SqlDbType.Decimal).Value = fgPerhitungan.Item("HasilPoint", 1).Value
                .Parameters.Add("@HasilPointVolumeKbPancang", SqlDbType.Decimal).Value = fgPerhitungan.Item("HasilPoint", 2).Value


                '.Parameters.Add("@PointRupiah", SqlDbType.Decimal).Value = 20
                .Parameters.Add("@PointRupiah", SqlDbType.Decimal).Value = fgg.Item("RpPoint", 0).Value
                .Parameters.Add("@JumlahRupiah", SqlDbType.Decimal).Value = fgg.Item("JumlahRp", 0).Value

                .Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = ClsSession.UserID
                .Parameters.Add(New SqlParameter("@Error", SqlDbType.VarChar, 200, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))

                .ExecuteNonQuery()
                .Dispose()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message & " infosp : " & MyCMD.Parameters("@Error saveDtl").Value)
            Return False
        End Try
        Return True
    End Function

    Private Sub btnRefresh_Click_1(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If cmbPancang.Text = "" Then
            MsgBox("Pilih Pancang", vbExclamation)
            Exit Sub
        End If

        If rdLicin.Checked = True Then
            Call ShowDataLicin()
        Else
            Call ShowDataJambul()
        End If

        If fg.Rows.Count - 2 = 0 Then
            fgHasil.Rows.Clear()
        Else
            Call LoadItemfgHasil()
            Call HasilPengawas()
            fgHasil.Item("QuantityKg", 2).Value = fgHasil.Item("ItemTarget", 2).Value / fgHasil.Item("JumlahTrip", 2).Value
        End If
        'If fg.Item(2, 7) <> 0 Then
        'Call HasilPengawas()
        'fgHasil.Item("QuantityKg", 2).Value = fgHasil.Item("ItemTarget", 2).Value / fgHasil.Item("JumlahTrip", 2).Value
        'End If
        ''
        Call NoTransId()

    End Sub

    Private Function Periode(IDTrans As String) As String
        Try
            Periode = ""
            Dim connb As New SqlConnection(StrConnRMPApp)
            connb.Open()

            Dim sql As String
            sql = "select * from TblTrnPremiPengawasHdr where TransID='" & TransID & "' and IDPancang='" & cmbPancang.SelectedValue & "' and Periode ='" & Format(DtPeriode.Value, "MM/yyyy") & "'"
            Dim cmd2 As New SqlClient.SqlCommand(sql, connb)
            Dim reader As SqlClient.SqlDataReader
            reader = cmd2.ExecuteReader
            If reader.HasRows Then
                If reader.Read() Then
                    Periode = "1"
                Else
                    Periode = "0"
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Default
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

End Class