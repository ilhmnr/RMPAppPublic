Imports C1.Win.C1FlexGrid

Public Class FrmMonApprovalHarga
    Public sqlBahanBaku As String
    Public filterBahanBaku As String
    Private Sub FrmMonApprovalHarga_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DTPStart.Value = Format(Now, "dd/MM/yy")
        DTPEnd.Value = Format(Now, "dd/MM/yy")
        HeaderFG()
        Modul_RMP.Combo.SetJenisKB(cbojeniskb)
        Modul_RMP.Combo.SetPancang(cmbPancang)
        Call search()
    End Sub
    Private Sub search()
        With schfg
            .SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
            .SearchDelay = 2
            .Watermark = "Cari Disini"
            .SetC1FlexGridSearchPanel(fg, schfg)
        End With
    End Sub
    Public Sub HeaderFG()
        Dim txt As CellRange
        With fg
            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
            .Cols.Count = 16
            .Cols.Fixed = 1
            .Styles.Fixed.BackColor = Color.White

            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(156, 206, 255)
            .Rows(0).StyleNew.BackColor = Color.White

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 1
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter


            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).Width = 50 : .Cols(0).AllowMerging = True
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "KodeHarga" : .Cols(1).TextAlign = TextAlignEnum.CenterCenter : .Cols(1).AllowMerging = True
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "BahanBaku" : .Cols(2).TextAlign = TextAlignEnum.CenterCenter : .Cols(2).AllowMerging = True
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Pancang" : .Cols(3).TextAlign = TextAlignEnum.CenterCenter : .Cols(3).AllowMerging = True

            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Asal" : .Cols(4).TextAlign = TextAlignEnum.CenterCenter : .Cols(4).AllowMerging = True
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Sub Grade" : .Cols(5).TextAlign = TextAlignEnum.CenterCenter : .Cols(5).AllowMerging = True

            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Harga(P1)" : .Cols(6).TextAlign = TextAlignEnum.CenterCenter : .Cols(6).AllowMerging = True : .Cols(6).Format = "#,###0"
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Harga(P2)" : .Cols(7).TextAlign = TextAlignEnum.CenterCenter : .Cols(7).AllowMerging = True : .Cols(7).Format = "#,###0"
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Periode" : .Cols(8).TextAlign = TextAlignEnum.CenterCenter : .Cols(8).AllowMerging = True
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "CreatedBy" : .Cols(9).TextAlign = TextAlignEnum.CenterCenter : .Cols(9).AllowMerging = True

            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "CreatedDate" : .Cols(10).TextAlign = TextAlignEnum.CenterCenter : .Cols(10).AllowMerging = True

            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "Approval1By" : .Cols(11).TextAlign = TextAlignEnum.CenterCenter : .Cols(11).AllowMerging = True

            txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "Approval1Date" : .Cols(12).TextAlign = TextAlignEnum.CenterCenter : .Cols(12).AllowMerging = True
            txt = .GetCellRange(0, 13, 0, 13) : txt.Data = "Approval2By" : .Cols(13).TextAlign = TextAlignEnum.LeftCenter : .Cols(13).AllowMerging = True
            txt = .GetCellRange(0, 14, 0, 14) : txt.Data = "Approval2Date" : .Cols(14).TextAlign = TextAlignEnum.LeftCenter : .Cols(14).AllowMerging = True
            txt = .GetCellRange(0, 15, 0, 15) : txt.Data = "Print" : .Cols(15).ImageAlign = TextAlignEnum.CenterCenter : .Cols(15).AllowMerging = True : .Cols(15).Visible = False


            .AutoSizeCols()
        End With
    End Sub

    Public Sub loaddata()
        Me.Cursor = Cursors.WaitCursor

        Dim i As Integer = 1
        Dim sql, sql2 As String
        Dim grade As String
        Dim dt As DataTable = New DataTable()

        filterBahanBaku = IIf(chkjeniskbs.Checked = True, " and Grade='" & cbojeniskb.Text & "' ", "") & IIf(chkPancang.Checked = True, " and IDPancang='" & cmbPancang.SelectedValue & "' ", "")

        If chkAll.Checked = False Then
            sql = "with data as (
                    select *  from vwMstHargaBahanBakuPancangNEW where (cast(Periode as date) between cast('" & Format(DTPStart.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(DTPEnd.Value, "yyyy-MM-dd") & "' as date)) 
                    )"
            sqlBahanBaku = sql
            sql = sql & " select * from data where 1=1 " & filterBahanBaku & " order by Pancang,Grade,BahanBaku,Asal,Periode"
            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)
        Else
            sql = "with data as (
                    select * from vwMstHargaBahanBakuPancangNEW 
                    where 
                    DetailID in (select distinct ( select top 1 DetailID from vwMstHargaBahanBakuPancangNEW  where Pancang=A.Pancang and Grade=A.Grade and BahanBaku=A.BahanBaku and Asal=A.Asal order by Periode desc ) as DetailID from vwMstHargaBahanBakuPancangNEW as A)
                    and (Pancang+Grade+BahanBaku+Asal) not in (select (Pancang+Grade+BahanBaku+Asal) as Data from vwMstHargaBahanBakuPancangNEW where (cast(Periode as date) between cast('" & Format(DTPStart.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(DTPEnd.Value, "yyyy-MM-dd") & "' as date)))
                    UNION
                    select *  from vwMstHargaBahanBakuPancangNEW where (cast(Periode as date) between cast('" & Format(DTPStart.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(DTPEnd.Value, "yyyy-MM-dd") & "' as date)) 
                    )"
            sqlBahanBaku = sql
            sql = sql & " select * from data where 1=1 " & filterBahanBaku & " order by Pancang,Grade,BahanBaku,Asal,Periode"
            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)
        End If

        If dt.Rows.Count > 0 Then
            fg.Rows.Count = 1
            With fg
                For Each dr In dt.Rows
                    .Rows.Add()
                    .Item(i, 0) = i
                    .Item(i, 1) = dr!KodeHargaString
                    .Item(i, 2) = dr!BahanBaku
                    .Item(i, 3) = dr!Pancang
                    .Item(i, 4) = dr!Asal
                    .Item(i, 5) = dr!SubGrade
                    .Item(i, 6) = dr!Hargap1
                    .Item(i, 7) = dr!Hargap2
                    .Item(i, 8) = dr!Periode
                    .Item(i, 9) = dr!CreatedBy
                    .Item(i, 10) = dr!CreatedDate
                    .Item(i, 11) = dr!Approve1By
                    .Item(i, 12) = dr!Approve1Date
                    .Item(i, 13) = dr!Approve2By
                    .Item(i, 14) = dr!Approve2Date
                    i += 1
                Next
            End With
            i += 1
        Else
            fg.Rows.Count = 1
            MsgBox("Data Tidak ditemukan ! ", MsgBoxStyle.Information)
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Public Sub loaddataub()

        Dim i As Integer = 1
        Dim sql As String = ""
        Dim dt As DataTable = New DataTable()



        Dim sql2 As String = ""   '

        If chkPancang.Checked = True Then
            sql = Modul_RMP.Func.SetCondition(sql, "IDPancang ='" & cmbPancang.SelectedValue.ToString & "'")
        End If


        If chkjeniskbs.Checked = True Then
            sql = Modul_RMP.Func.SetCondition(sql, "NamaBahanBaku ='" & cbojeniskb.Text & "'")
        End If

        sql = Modul_RMP.Func.SetCondition(sql, " CONVERT(DATETIME,CONVERT(VARCHAR, UpahBongkarPeriode,103),103) BETWEEN CONVERT (DATETIME,'" & DTPStart.Value & "',103) AND CONVERT(DATETIME,'" & DTPEnd.Value & "',103)")

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "  SELECT IDUpahBongkar as detailid, IDUpahBongkar as KodeHargaString, NamaBahanBaku as BahanBaku, " &
                                                          " IDPancang, Pancang, asal,HargaP1, HargaP2,UpahBongkarPeriode  as Periode,'' as kodegrade,'' grade,   " &
                                                          " CreatedBy, createddate, UpdatedBy as lastupdatedby , Updateddate as lastupdateddate, ComputerName as computer , ComputerDate,Approve1By,Approve1Date,Approve2By,Approve2Date  from RMPApp..vwMstUpahBongkar  " &
                                                          " where  Approve1By IS NOT NULL AND upahbongkar>0  " & IIf(sql = "", "", " AND " & sql) & " Order by namabahanbaku,idpancang,UpahBongkarPeriode")

        If dt.Rows.Count > 0 Then
            fg.Rows.Count = 1
            With fg
                For Each dr In dt.Rows
                    .Rows.Add()
                    .Item(i, 0) = i
                    .Item(i, 1) = dr!KodeHargaString
                    .Item(i, 2) = dr!BahanBaku
                    .Item(i, 3) = dr!Pancang
                    .Item(i, 4) = dr!Asal
                    .Item(i, 6) = dr!Hargap1
                    .Item(i, 7) = dr!Hargap2
                    .Item(i, 8) = dr!Periode
                    .Item(i, 9) = dr!CreatedBy
                    .Item(i, 10) = dr!CreatedDate
                    .Item(i, 11) = dr!Approve1By
                    .Item(i, 12) = dr!Approve1Date
                    .Item(i, 13) = dr!Approve2By
                    .Item(i, 14) = dr!Approve2Date
                    i += 1
                Next
            End With
            i += 1

        Else
            fg.Rows.Count = 1
            MsgBox("Data Tidak ditemukan ! ", MsgBoxStyle.Information)
            Exit Sub
        End If


    End Sub


    Public Sub loaddatajasatransport()

        Dim i As Integer = 1
        Dim sql As String = ""
        Dim dt As DataTable = New DataTable()

        Dim sql2 As String = ""   '

        If chkPancang.Checked = True Then
            sql = Modul_RMP.Func.SetCondition(sql, "IDPancang ='" & cmbPancang.SelectedValue.ToString & "'")
        End If


        If chkjeniskbs.Checked = True Then
            sql = Modul_RMP.Func.SetCondition(sql, "BahanBaku ='" & cbojeniskb.Text & "'")
        End If

        sql = Modul_RMP.Func.SetCondition(sql, " CONVERT(DATETIME,CONVERT(VARCHAR, Periode,103),103) BETWEEN CONVERT (DATETIME,'" & DTPStart.Value & "',103) AND CONVERT(DATETIME,'" & DTPEnd.Value & "',103)")

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " SELECT detailid, KodeHargaString, BahanBaku, IDPancang, Pancang, Asal, hargap1 as hargap1 , hargap2 as hargap2, Periode, kodegrade, grade, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate, ComputerName, ComputerDate, Approve1By,  " &
                                                          " Approve1Date, Approve2By, Approve2Date, ttapv1, ttapv2 from vwmstjasatransportp1p2   " &
                                                          " where  Approve1By IS NOT NULL AND (hargap1>0 OR  hargap2>0 ) " & IIf(sql = "", "", " AND " & sql) &
                                                          " Order by BahanBaku,idpancang,Periode")

        If dt.Rows.Count > 0 Then
            fg.Rows.Count = 1
            With fg
                For Each dr In dt.Rows
                    .Rows.Add()
                    .Item(i, 0) = i
                    .Item(i, 1) = dr!KodeHargaString
                    .Item(i, 2) = dr!BahanBaku
                    .Item(i, 3) = dr!Pancang
                    .Item(i, 4) = dr!Asal
                    .Item(i, 6) = dr!Hargap1
                    .Item(i, 7) = dr!Hargap2
                    .Item(i, 8) = dr!Periode
                    .Item(i, 9) = dr!CreatedBy
                    .Item(i, 10) = dr!CreatedDate
                    .Item(i, 11) = dr!Approve1By
                    .Item(i, 12) = dr!Approve1Date
                    .Item(i, 13) = dr!Approve2By
                    .Item(i, 14) = dr!Approve2Date
                    i += 1
                Next
            End With
            i += 1

        Else
            fg.Rows.Count = 1
            MsgBox("Data Tidak ditemukan ! ", MsgBoxStyle.Information)
            Exit Sub
        End If

    End Sub


    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If rdbahanbaku.Checked Then
            loaddata()
        ElseIf rdupahbongkar.Checked Then
            loaddataub()
        ElseIf rdjasatransport.Checked Then
            loaddatajasatransport()
        Else
            MsgBox("Wait.. Print Harga belum tersedia ! ", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If MessageBox.Show("Apakah Anda ingin print memo Harga ?", "Print out", MessageBoxButtons.YesNo) = vbNo Then
            Exit Sub
        End If

        'If rdbahanbaku.Checked Then
        '    FrmRptMemoHarga.jenisdataprint = "BahanBaku"
        'End If

        'If rdupahbongkar.Checked Then
        '    FrmRptMemoHarga.jenisdataprint = "UB"
        'End If

        'If rdjasatransport.Checked Then
        '    FrmRptMemoHarga.jenisdataprint = "JasaTransport"
        'End If

        'Call FrmRptMemoHarga.Show()

    End Sub
End Class