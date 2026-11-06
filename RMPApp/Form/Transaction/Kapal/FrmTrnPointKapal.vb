Imports C1.C1Preview.C1HyperlinkInfo
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports Spire.Pdf.HtmlConverter
Imports System.Data.SqlTypes

Public Class FrmTrnPointKapal
    Dim txt As CellRange
    Public NotransPointKapal As String
    Public dtpstart, dtpend As Date
    'value sp
    Dim NoTransPointKapal_sp, DoNumber, SusutPersent As String
    Dim DoDate As DateTime
    Dim IdKapal, IdPancang, Trip, N2Pancang, N2Pabrik, SusutKg, PointSusut, PointMembantuKondisiEmergency, PointAlokasiMuatKePancang, PointKondisiKapalLayak, PointKondisiKapalLengkap, PointKapalRusakDiJalan, PointMenolakPengirimanBarang, PointKapalTenggelam, TotalPoint As Integer

    Private Sub FrmTrnPointKapal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call HeaderFG()
        Call vw_add()

        If NotransPointKapal <> "" Then
            Call HeaderFG2()
            Call showdatadtl()
            Call vw_dtl()
        End If
    End Sub
    Private Sub vw_add()
        dtp1.Value = Now
        dtp2.Value = Now
        dtp1.Enabled = True
        dtp2.Enabled = True
        btnsave.Visible = True
        btnexit.Visible = True
        btnLoaddata.Visible = True
        fg.AllowEditing = True
        fg.Cols(8).Visible = True
        fg.Visible = True
        fg2.Visible = False
    End Sub
    Private Sub vw_dtl()
        dtp1.Value = dtpstart
        dtp2.Value = dtpend
        dtp1.Enabled = False
        dtp2.Enabled = False
        btnsave.Visible = False
        btnexit.Visible = True
        btnLoaddata.Visible = False
        fg.AllowEditing = False
        fg.Cols(8).Visible = False
        fg.Visible = False
        fg2.Visible = True
    End Sub
    Public Sub HeaderFG2()
        With fg2
            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
            .Cols.Count = 27
            .Cols.Frozen = 1
            .Rows.Count = 5
            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(1).StyleNew.BackColor = Color.FromArgb(242, 222, 222)
            .Rows(1).StyleFixedNew.BackColor = Color.FromArgb(223, 240, 216)
            .Rows(2).StyleNew.BackColor = Color.FromArgb(242, 222, 222)
            .Rows(2).StyleFixedNew.BackColor = Color.FromArgb(223, 240, 216)
            .Rows(3).StyleNew.BackColor = Color.FromArgb(242, 222, 222)
            .Rows(3).StyleFixedNew.BackColor = Color.FromArgb(223, 240, 216)
            .Rows(4).StyleNew.BackColor = Color.FromArgb(242, 222, 222)
            .Rows(4).StyleFixedNew.BackColor = Color.FromArgb(223, 240, 216)
            .Rows(0).AllowMerging = True
            .Rows(1).AllowMerging = True
            .Rows(2).AllowMerging = True
            .Rows(3).AllowMerging = True
            .Rows(4).AllowMerging = True
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 5
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 0, 4, 0) : txt.Data = "NO" : .Cols(0).AllowMerging = True : .Cols(0).TextAlign = TextAlignEnum.CenterCenter : .Cols(0).AllowEditing = False
            txt = .GetCellRange(0, 1, 4, 1) : txt.Data = "NAMA KAPAL" : .Cols(1).AllowMerging = True : .Cols(1).TextAlign = TextAlignEnum.LeftCenter : .Cols(1).AllowEditing = False
            txt = .GetCellRange(0, 2, 4, 2) : txt.Data = "PANCANG" : .Cols(2).AllowMerging = True : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).AllowEditing = False
            txt = .GetCellRange(0, 3, 4, 3) : txt.Data = "TRIP" : .Cols(3).AllowMerging = True : .Cols(3).TextAlign = TextAlignEnum.CenterCenter : .Cols(3).AllowEditing = False
            txt = .GetCellRange(0, 4, 4, 4) : txt.Data = "N2 PANCANG" : .Cols(4).AllowMerging = True : .Cols(4).TextAlign = TextAlignEnum.RightCenter : .Cols(4).AllowEditing = False : .Cols(4).Format = "#,###0"
            txt = .GetCellRange(0, 5, 4, 5) : txt.Data = "N2 PABRIK" : .Cols(5).AllowMerging = True : .Cols(5).TextAlign = TextAlignEnum.RightCenter : .Cols(5).AllowEditing = False : .Cols(5).Format = "#,###0"
            'SUSUT
            txt = .GetCellRange(0, 6, 0, 8) : txt.Data = "SUSUT" : .Cols(6).AllowMerging = True
            txt = .GetCellRange(1, 6, 4, 6) : txt.Data = "Kg" : .Cols(6).AllowMerging = True : .Cols(6).TextAlign = TextAlignEnum.RightCenter : .Cols(6).Format = "#,###0"
            txt = .GetCellRange(1, 7, 4, 7) : txt.Data = "%" : .Cols(7).AllowMerging = True : .Cols(7).TextAlign = TextAlignEnum.RightCenter
            txt = .GetCellRange(1, 8, 4, 8) : txt.Data = "(TIDAK DIHITUNG)" : .Cols(8).AllowMerging = True : .Cols(8).Visible = False
            'KATEGORI PENILAIAN
            txt = .GetCellRange(0, 9, 0, 21) : txt.Data = "KATEGORI PENILAIAN (POINT)"
            '(+)
            txt = .GetCellRange(1, 9, 1, 13) : txt.Data = "(+)"
            txt = .GetCellRange(2, 9, 3, 9) : txt.Data = "Susut Normal (<1,0%)" : .Cols(9).AllowMerging = True : .Cols(9).TextAlign = TextAlignEnum.CenterCenter : .Cols(9).AllowEditing = False
            txt = .GetCellRange(4, 9, 4, 9) : txt.Data = "+3"
            txt = .GetCellRange(2, 10, 3, 10) : txt.Data = "Membantu Kondisi Emergency" : .Cols(10).AllowMerging = True : .Cols(10).TextAlign = TextAlignEnum.CenterCenter : .Cols(10).AllowEditing = True
            txt = .GetCellRange(4, 10, 4, 10) : txt.Data = "+2"
            txt = .GetCellRange(2, 11, 3, 11) : txt.Data = "Alokasi Muat Ke Pancang" : .Cols(11).AllowMerging = True : .Cols(11).TextAlign = TextAlignEnum.CenterCenter : .Cols(11).AllowEditing = True
            txt = .GetCellRange(4, 11, 4, 11) : txt.Data = "+1"
            'kondisi Kapal
            txt = .GetCellRange(2, 12, 2, 13) : txt.Data = "Kondisi Kapal"
            txt = .GetCellRange(3, 12, 3, 12) : txt.Data = "Layak" : .Cols(12).AllowMerging = True : .Cols(12).TextAlign = TextAlignEnum.CenterCenter : .Cols(12).AllowEditing = True
            txt = .GetCellRange(4, 12, 4, 12) : txt.Data = "+1"
            txt = .GetCellRange(3, 13, 3, 13) : txt.Data = "Lengkap" : .Cols(13).AllowMerging = True : .Cols(13).TextAlign = TextAlignEnum.CenterCenter : .Cols(13).AllowEditing = True
            txt = .GetCellRange(4, 13, 4, 13) : txt.Data = "+1"
            '(-)
            txt = .GetCellRange(1, 14, 1, 21) : txt.Data = "(-)"
            'Susut Kg
            txt = .GetCellRange(2, 14, 2, 18) : txt.Data = "Susut"
            txt = .GetCellRange(3, 14, 3, 14) : txt.Data = "1,1-1,5%" : .Cols(14).AllowMerging = True : .Cols(14).TextAlign = TextAlignEnum.CenterCenter : .Cols(14).AllowEditing = False
            txt = .GetCellRange(4, 14, 4, 14) : txt.Data = "-1"
            txt = .GetCellRange(3, 15, 3, 15) : txt.Data = "1,6-2,0%" : .Cols(15).AllowMerging = True : .Cols(15).TextAlign = TextAlignEnum.CenterCenter : .Cols(15).AllowEditing = False
            txt = .GetCellRange(4, 15, 4, 15) : txt.Data = "-2"
            txt = .GetCellRange(3, 16, 3, 16) : txt.Data = "2,1-2,5%" : .Cols(16).AllowMerging = True : .Cols(16).TextAlign = TextAlignEnum.CenterCenter : .Cols(16).AllowEditing = False
            txt = .GetCellRange(4, 16, 4, 16) : txt.Data = "-3"
            txt = .GetCellRange(3, 17, 3, 17) : txt.Data = "2,6-3,0%" : .Cols(17).AllowMerging = True : .Cols(17).TextAlign = TextAlignEnum.CenterCenter : .Cols(17).AllowEditing = False
            txt = .GetCellRange(4, 17, 4, 17) : txt.Data = "-4"
            txt = .GetCellRange(3, 18, 3, 18) : txt.Data = ">3,0%" : .Cols(18).AllowMerging = True : .Cols(18).TextAlign = TextAlignEnum.CenterCenter : .Cols(18).AllowEditing = False
            txt = .GetCellRange(4, 18, 4, 18) : txt.Data = "-5"

            txt = .GetCellRange(2, 19, 3, 19) : txt.Data = "Kapal Rusak Di Jalan" : .Cols(19).AllowMerging = True : .Cols(19).TextAlign = TextAlignEnum.CenterCenter : .Cols(19).AllowEditing = True
            txt = .GetCellRange(4, 19, 4, 19) : txt.Data = "-1"
            txt = .GetCellRange(2, 20, 3, 20) : txt.Data = "Menolak Pengiriman Barang" : .Cols(20).AllowMerging = True : .Cols(20).TextAlign = TextAlignEnum.CenterCenter : .Cols(20).AllowEditing = True
            txt = .GetCellRange(4, 20, 4, 20) : txt.Data = "-1"
            txt = .GetCellRange(2, 21, 3, 21) : txt.Data = "Kapal Tenggelam" : .Cols(21).AllowMerging = True : .Cols(21).TextAlign = TextAlignEnum.CenterCenter : .Cols(21).AllowEditing = False
            txt = .GetCellRange(4, 21, 4, 21) : txt.Data = "-10"

            txt = .GetCellRange(0, 22, 4, 22) : txt.Data = "TOTAL POINT" : .Cols(22).AllowMerging = True : .Cols(22).TextAlign = TextAlignEnum.CenterCenter : .Cols(22).AllowEditing = False
            txt = .GetCellRange(0, 23, 4, 23) : txt.Data = "DoDate" : .Cols(23).AllowMerging = True : .Cols(23).TextAlign = TextAlignEnum.CenterCenter : .Cols(23).AllowEditing = False : .Cols(23).Visible = False
            txt = .GetCellRange(0, 24, 4, 24) : txt.Data = "DoNumber" : .Cols(24).AllowMerging = True : .Cols(24).TextAlign = TextAlignEnum.CenterCenter : .Cols(24).AllowEditing = False : .Cols(24).Visible = False
            txt = .GetCellRange(0, 25, 4, 25) : txt.Data = "IdPancang" : .Cols(25).Visible = False
            txt = .GetCellRange(0, 26, 4, 26) : txt.Data = "IdKapal" : .Cols(26).Visible = False

            .AutoSizeCols()
        End With
    End Sub
    Public Sub HeaderFG()
        With fg
            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
            .Cols.Count = 27
            .Cols.Frozen = 1
            .Rows.Count = 5
            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(1).StyleNew.BackColor = Color.FromArgb(242, 222, 222)
            .Rows(1).StyleFixedNew.BackColor = Color.FromArgb(223, 240, 216)
            .Rows(2).StyleNew.BackColor = Color.FromArgb(242, 222, 222)
            .Rows(2).StyleFixedNew.BackColor = Color.FromArgb(223, 240, 216)
            .Rows(3).StyleNew.BackColor = Color.FromArgb(242, 222, 222)
            .Rows(3).StyleFixedNew.BackColor = Color.FromArgb(223, 240, 216)
            .Rows(4).StyleNew.BackColor = Color.FromArgb(242, 222, 222)
            .Rows(4).StyleFixedNew.BackColor = Color.FromArgb(223, 240, 216)
            .Rows(0).AllowMerging = True
            .Rows(1).AllowMerging = True
            .Rows(2).AllowMerging = True
            .Rows(3).AllowMerging = True
            .Rows(4).AllowMerging = True
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 5
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 0, 4, 0) : txt.Data = "NO" : .Cols(0).AllowMerging = True : .Cols(0).TextAlign = TextAlignEnum.CenterCenter : .Cols(0).AllowEditing = False
            txt = .GetCellRange(0, 1, 4, 1) : txt.Data = "NAMA KAPAL" : .Cols(1).AllowMerging = True : .Cols(1).TextAlign = TextAlignEnum.LeftCenter : .Cols(1).AllowEditing = False
            txt = .GetCellRange(0, 2, 4, 2) : txt.Data = "PANCANG" : .Cols(2).AllowMerging = True : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).AllowEditing = False
            txt = .GetCellRange(0, 3, 4, 3) : txt.Data = "TRIP" : .Cols(3).AllowMerging = True : .Cols(3).TextAlign = TextAlignEnum.CenterCenter : .Cols(3).AllowEditing = False
            txt = .GetCellRange(0, 4, 4, 4) : txt.Data = "N2 PANCANG" : .Cols(4).AllowMerging = True : .Cols(4).TextAlign = TextAlignEnum.RightCenter : .Cols(4).AllowEditing = False : .Cols(4).Format = "#,###0"
            txt = .GetCellRange(0, 5, 4, 5) : txt.Data = "N2 PABRIK" : .Cols(5).AllowMerging = True : .Cols(5).TextAlign = TextAlignEnum.RightCenter : .Cols(5).AllowEditing = False : .Cols(5).Format = "#,###0"
            'SUSUT
            txt = .GetCellRange(0, 6, 0, 8) : txt.Data = "SUSUT" : .Cols(6).AllowMerging = True
            txt = .GetCellRange(1, 6, 4, 6) : txt.Data = "Kg" : .Cols(6).AllowMerging = True : .Cols(6).TextAlign = TextAlignEnum.RightCenter : .Cols(6).Format = "#,###0"
            txt = .GetCellRange(1, 7, 4, 7) : txt.Data = "%" : .Cols(7).AllowMerging = True : .Cols(7).TextAlign = TextAlignEnum.RightCenter
            txt = .GetCellRange(1, 8, 4, 8) : txt.Data = "(TIDAK DIHITUNG)" : .Cols(8).AllowMerging = True : .Cols(8).TextAlign = TextAlignEnum.LeftCenter
            'KATEGORI PENILAIAN
            txt = .GetCellRange(0, 9, 0, 21) : txt.Data = "KATEGORI PENILAIAN (POINT)"
            '(+)
            txt = .GetCellRange(1, 9, 1, 13) : txt.Data = "(+)"
            txt = .GetCellRange(2, 9, 3, 9) : txt.Data = "Susut Normal (<1,0%)" : .Cols(9).AllowMerging = True : .Cols(9).TextAlign = TextAlignEnum.CenterCenter : .Cols(9).AllowEditing = False
            txt = .GetCellRange(4, 9, 4, 9) : txt.Data = "+3"
            txt = .GetCellRange(2, 10, 3, 10) : txt.Data = "Membantu Kondisi Emergency" : .Cols(10).AllowMerging = True : .Cols(10).TextAlign = TextAlignEnum.CenterCenter : .Cols(10).AllowEditing = True
            txt = .GetCellRange(4, 10, 4, 10) : txt.Data = "+2"
            txt = .GetCellRange(2, 11, 3, 11) : txt.Data = "Alokasi Muat Ke Pancang" : .Cols(11).AllowMerging = True : .Cols(11).TextAlign = TextAlignEnum.CenterCenter : .Cols(11).AllowEditing = True
            txt = .GetCellRange(4, 11, 4, 11) : txt.Data = "+1"
            'kondisi Kapal
            txt = .GetCellRange(2, 12, 2, 13) : txt.Data = "Kondisi Kapal"
            txt = .GetCellRange(3, 12, 3, 12) : txt.Data = "Layak" : .Cols(12).AllowMerging = True : .Cols(12).TextAlign = TextAlignEnum.CenterCenter : .Cols(12).AllowEditing = True
            txt = .GetCellRange(4, 12, 4, 12) : txt.Data = "+1"
            txt = .GetCellRange(3, 13, 3, 13) : txt.Data = "Lengkap" : .Cols(13).AllowMerging = True : .Cols(13).TextAlign = TextAlignEnum.CenterCenter : .Cols(13).AllowEditing = True
            txt = .GetCellRange(4, 13, 4, 13) : txt.Data = "+1"
            '(-)
            txt = .GetCellRange(1, 14, 1, 21) : txt.Data = "(-)"
            'Susut Kg
            txt = .GetCellRange(2, 14, 2, 18) : txt.Data = "Susut"
            txt = .GetCellRange(3, 14, 3, 14) : txt.Data = "1,1-1,5%" : .Cols(14).AllowMerging = True : .Cols(14).TextAlign = TextAlignEnum.CenterCenter : .Cols(14).AllowEditing = False
            txt = .GetCellRange(4, 14, 4, 14) : txt.Data = "-1"
            txt = .GetCellRange(3, 15, 3, 15) : txt.Data = "1,6-2,0%" : .Cols(15).AllowMerging = True : .Cols(15).TextAlign = TextAlignEnum.CenterCenter : .Cols(15).AllowEditing = False
            txt = .GetCellRange(4, 15, 4, 15) : txt.Data = "-2"
            txt = .GetCellRange(3, 16, 3, 16) : txt.Data = "2,1-2,5%" : .Cols(16).AllowMerging = True : .Cols(16).TextAlign = TextAlignEnum.CenterCenter : .Cols(16).AllowEditing = False
            txt = .GetCellRange(4, 16, 4, 16) : txt.Data = "-3"
            txt = .GetCellRange(3, 17, 3, 17) : txt.Data = "2,6-3,0%" : .Cols(17).AllowMerging = True : .Cols(17).TextAlign = TextAlignEnum.CenterCenter : .Cols(17).AllowEditing = False
            txt = .GetCellRange(4, 17, 4, 17) : txt.Data = "-4"
            txt = .GetCellRange(3, 18, 3, 18) : txt.Data = ">3,0%" : .Cols(18).AllowMerging = True : .Cols(18).TextAlign = TextAlignEnum.CenterCenter : .Cols(18).AllowEditing = False
            txt = .GetCellRange(4, 18, 4, 18) : txt.Data = "-5"

            txt = .GetCellRange(2, 19, 3, 19) : txt.Data = "Kapal Rusak Di Jalan" : .Cols(19).AllowMerging = True : .Cols(19).TextAlign = TextAlignEnum.CenterCenter : .Cols(19).AllowEditing = True
            txt = .GetCellRange(4, 19, 4, 19) : txt.Data = "-1"
            txt = .GetCellRange(2, 20, 3, 20) : txt.Data = "Menolak Pengiriman Barang" : .Cols(20).AllowMerging = True : .Cols(20).TextAlign = TextAlignEnum.CenterCenter : .Cols(20).AllowEditing = True
            txt = .GetCellRange(4, 20, 4, 20) : txt.Data = "-1"
            txt = .GetCellRange(2, 21, 3, 21) : txt.Data = "Kapal Tenggelam" : .Cols(21).AllowMerging = True : .Cols(21).TextAlign = TextAlignEnum.CenterCenter : .Cols(21).AllowEditing = False
            txt = .GetCellRange(4, 21, 4, 21) : txt.Data = "-10"

            txt = .GetCellRange(0, 22, 4, 22) : txt.Data = "TOTAL POINT" : .Cols(22).AllowMerging = True : .Cols(22).TextAlign = TextAlignEnum.CenterCenter : .Cols(22).AllowEditing = False
            txt = .GetCellRange(0, 23, 4, 23) : txt.Data = "DoDate" : .Cols(23).AllowMerging = True : .Cols(23).TextAlign = TextAlignEnum.CenterCenter : .Cols(23).AllowEditing = False : .Cols(23).Visible = False
            txt = .GetCellRange(0, 24, 4, 24) : txt.Data = "DoNumber" : .Cols(24).AllowMerging = True : .Cols(24).TextAlign = TextAlignEnum.CenterCenter : .Cols(24).AllowEditing = False : .Cols(24).Visible = False
            txt = .GetCellRange(0, 25, 4, 25) : txt.Data = "IdPancang" : .Cols(25).Visible = False
            txt = .GetCellRange(0, 26, 4, 26) : txt.Data = "IdKapal" : .Cols(26).Visible = False

            .AutoSizeCols()
        End With
    End Sub
    Private Sub showdata()
        Me.Cursor = Cursors.WaitCursor

        Dim i As Integer = 5
        Dim j As Integer = 1
        Dim dt As DataTable = New DataTable

        Try
            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT * FROM [RMPApp].[dbo].[vw_TrnPoinKapal] where (IDPancang+IDKapal+Trip) in ( select (IDPancang+IDKapal+Trip) from tblTrnDoHdr where (cast(DoDate as date) between cast('" & Format(dtp1.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(dtp2.Value, "yyyy-MM-dd") & "' as date)) )")
            If dt.Rows.Count > 0 Then
                With fg
                    .Rows.Count = 5
                    .Rows.Count = dt.Rows.Count + 5
                    For Each row As DataRow In dt.Rows
                        Dim sum As Double = 0

                        .Item(i, 0) = j
                        .Item(i, 1) = row.Item("KapalName")
                        .Item(i, 2) = row.Item("Pancang")
                        .Item(i, 3) = row.Item("Trip")
                        .Item(i, 4) = row.Item("N2PANCANG")
                        .Item(i, 5) = row.Item("N2PABRIK")
                        .Item(i, 6) = row.Item("Susut")
                        .Item(i, 7) = row.Item("SusutPersent")
                        '.Item(i, 23) = row.Item("DoDate")
                        '.Item(i, 24) = row.Item("DoNumber")
                        .Item(i, 25) = row.Item("IdPancang")
                        .Item(i, 26) = row.Item("IdKapal")

                        If row.Item("SusutPersent") <= 1.0 Then
                            .Item(i, 9) = 3
                            sum += 3
                        ElseIf row.Item("SusutPersent") >= 1.1 And row.Item("SusutPersent") <= 1.5 Then
                            .Item(i, 14) = -1
                            sum += -1
                        ElseIf row.Item("SusutPersent") >= 1.6 And row.Item("SusutPersent") <= 2.0 Then
                            .Item(i, 15) = -2
                            sum += -2
                        ElseIf row.Item("SusutPersent") >= 2.1 And row.Item("SusutPersent") <= 2.5 Then
                            .Item(i, 16) = -3
                            sum += -3
                        ElseIf row.Item("SusutPersent") >= 2.6 And row.Item("SusutPersent") <= 3.0 Then
                            .Item(i, 17) = -4
                            sum += -4
                        ElseIf row.Item("SusutPersent") >= 3.1 Then
                            .Item(i, 18) = -5
                            sum += -5
                        End If

                        If row.Item("KapalTenggelam") = "-10" Then
                            .Item(i, 21) = "-10"
                            sum += -10
                        End If

                        .Item(i, 22) = sum

                        i += 1
                        j += 1
                        .AutoSizeCols()
                    Next
                End With
                Me.Cursor = Cursors.Default
            Else
                MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
                Me.Cursor = Cursors.Default
            End If
        Catch EX As Exception
            MsgBox(EX.Message)
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub showdatadtl()
        Me.Cursor = Cursors.WaitCursor
        Dim i As Integer = 5
        Dim dt As DataTable = New DataTable

        Try
            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "  select a.*,b.Pancang,c.KapalName from TblTrnHitungPointKapalDtl as a inner join Android_tblMstPancang as b on a.IdPancang = b.IDPancang inner join tblMstKapal as c on a.IdKapal = c.KapalID  where 1=1 and NoTransPointKapal='" & NotransPointKapal & "'")
            If dt.Rows.Count > 0 Then
                With fg2
                    .Rows.Count = dt.Rows.Count + 5
                    For Each row As DataRow In dt.Rows
                        Dim sum As Double = 0

                        .Item(i, 0) = i
                        .Item(i, 1) = row.Item("KapalName")
                        .Item(i, 2) = row.Item("Pancang")
                        .Item(i, 3) = row.Item("Trip")
                        .Item(i, 4) = row.Item("N2PANCANG")
                        .Item(i, 5) = row.Item("N2PABRIK")
                        .Item(i, 6) = row.Item("SusutKg")
                        .Item(i, 7) = row.Item("SusutPersent")
                        If row.Item("SusutPersent") <= 1.0 Then
                            .Item(i, 9) = 3
                        ElseIf row.Item("SusutPersent") >= 1.1 And row.Item("SusutPersent") <= 1.5 Then
                            .Item(i, 14) = -1
                        ElseIf row.Item("SusutPersent") >= 1.6 And row.Item("SusutPersent") <= 2.0 Then
                            .Item(i, 15) = -2
                        ElseIf row.Item("SusutPersent") >= 2.1 And row.Item("SusutPersent") <= 2.5 Then
                            .Item(i, 16) = -3
                        ElseIf row.Item("SusutPersent") >= 2.6 And row.Item("SusutPersent") <= 3.0 Then
                            .Item(i, 17) = -4
                        ElseIf row.Item("SusutPersent") >= 3.1 Then
                            .Item(i, 18) = -5
                        End If
                        .Item(i, 10) = row.Item("PointMembantuKondisiEmergency")
                        .Item(i, 11) = row.Item("PointAlokasiMuatKePancang")
                        .Item(i, 12) = row.Item("PointKondisiKapalLayak")
                        .Item(i, 13) = row.Item("PointkondisiKapalLengkap")
                        .Item(i, 19) = row.Item("PointKapalRusakDiJalan")
                        .Item(i, 20) = row.Item("PointMenolakPengirimanBarang")
                        .Item(i, 21) = row.Item("PointKapalTenggelam")
                        .Item(i, 22) = row.Item("TotalPoint")

                        For j = 9 To 21
                            If .Item(i, j) = 0 Then
                                .Item(i, j) = ""
                            End If
                        Next

                        i += 1
                        .AutoSizeCols()
                    Next
                End With
                Me.Cursor = Cursors.Default
            Else
                MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
                Me.Cursor = Cursors.Default
            End If
        Catch EX As Exception
            MsgBox(EX.Message)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnLoaddata_Click_1(sender As Object, e As EventArgs) Handles btnLoaddata.Click
        Call HeaderFG()
        Call showdata()
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click
        Dim rg As CellRange
        With fg
            If .Rows.Count > 5 Then
                'Tidak Hitung Susut point -()
                If .Col = 8 Then
                    If .Item(.Row, 7) >= 1.1 Then
                        If .Item(.Row, 8) = True Then
                            .Item(.Row, 9) = 3
                            .Item(.Row, 14) = ""
                            .Item(.Row, 15) = ""
                            .Item(.Row, 16) = ""
                            .Item(.Row, 17) = ""
                            .Item(.Row, 18) = ""
                            Call SumPoint()
                        Else
                            .Item(.Row, 9) = ""
                            Call HitungPointPersent()
                            Call SumPoint()
                        End If
                    Else
                        .Item(.Row, 8) = False
                    End If
                End If

                For i = 10 To 13
                    If .Col = i Then
                        SumPoint()
                    End If
                Next
                For i = 19 To 20
                    If .Col = i Then
                        SumPoint()
                    End If
                Next
            End If
        End With
    End Sub

    Private Sub HitungPointPersent()
        With fg
            If .Item(.Row, 7) >= 1.1 And .Item(.Row, 7) <= 1.5 Then
                .Item(.Row, 14) = -1
            ElseIf .Item(.Row, 7) >= 1.6 And .Item(.Row, 7) <= 2.0 Then
                .Item(.Row, 15) = -2
            ElseIf .Item(.Row, 7) >= 2.1 And .Item(.Row, 7) <= 2.5 Then
                .Item(.Row, 16) = -3
            ElseIf .Item(.Row, 7) >= 2.6 And .Item(.Row, 7) <= 3.0 Then
                .Item(.Row, 17) = -4
            ElseIf .Item(.Row, 7) >= 3.1 Then
                .Item(.Row, 18) = -5
            End If
        End With
    End Sub
    Private Sub SumPoint()
        Dim sum As Integer = 0
        With fg
            If .Item(.Row, 10) = True Then
                sum += 2
            End If
            If .Item(.Row, 11) = True Then
                sum += 1
            End If
            If .Item(.Row, 12) = True Then
                sum += 1
            End If
            If .Item(.Row, 13) = True Then
                sum += 1
            End If

            If .Item(.Row, 9) = "3" Then
                sum += 3
            ElseIf .Item(.Row, 14) = "-1" Then
                sum += -1
            ElseIf .Item(.Row, 15) = "-2" Then
                sum += -2
            ElseIf .Item(.Row, 16) = "-3" Then
                sum += -3
            ElseIf .Item(.Row, 17) = "-4" Then
                sum += -4
            ElseIf .Item(.Row, 18) = "-5" Then
                sum += -5
            End If

            If .Item(.Row, 19) = True Then
                sum += -1
            End If
            If .Item(.Row, 20) = True Then
                sum += -1
            End If
            If .Item(.Row, 21) = "-10" Then
                sum += -10
            End If
            .Item(.Row, 22) = sum
        End With
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Call savedata()
    End Sub

    Private Sub savedata()
        Me.Cursor = Cursors.WaitCursor
        'Membuat Variabel
        Dim dt As DataTable = New DataTable
        Dim koneksi As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnRMPApp)
        Dim Transaksi As SqlTransaction
        Transaksi = koneksi.BeginTransaction
        '-----------------------------------------------
        'Jalamkan Fungsi save
        Try
            NoTransPointKapal_sp = DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"declare @NoTransPointKapal varchar(50) = (SELECT    (left('0000' + CAST((ISNULL(MAX(CAST(left(NoTransPointKapal, 5) AS BIGINT)), 0) + 1) AS VARCHAR), 5)+'/PK/'+RIGHT('0' + CONVERT(VARCHAR, DAY(GETDATE())), 2) + RIGHT('0' + CONVERT(VARCHAR, MONTH(GETDATE())), 2) + CONVERT(VARCHAR, YEAR(GETDATE()), 2)) FROM TblTrnHitungPointKapalHdr)

                                                                insert into TblTrnHitungPointKapalHdr (NoTransPointKapal,TanggalInvoice,DoDateStar,DoDateEnd,CreatedBy,CreatedDate,Computer,ComputerDate,Approval)
                                                                values (@NoTransPointKapal,getdate(),'" & Format(dtp1.Value, "yyyy-MM-dd") & "','" & Format(dtp2.Value, "yyyy-MM-dd") & "','" & ClsSession.UserID & "',getdate(),HOST_NAME(),getdate(),0)
                                                                
                                                                select @NoTransPointKapal as GetValueString
                                                                ")

            With fg
                For i = 5 To .Rows.Count - 1
                    PointMembantuKondisiEmergency = 0
                    PointAlokasiMuatKePancang = 0
                    PointKondisiKapalLayak = 0
                    PointKondisiKapalLengkap = 0
                    PointKapalRusakDiJalan = 0
                    PointMenolakPengirimanBarang = 0

                    IdKapal = .Item(i, 26)
                    IdPancang = .Item(i, 25)
                    Trip = .Item(i, 3)
                    N2Pancang = .Item(i, 4)
                    N2Pabrik = .Item(i, 5)
                    SusutKg = .Item(i, 6)
                    SusutPersent = .Item(i, 7).ToString
                    If .Item(i, 9) = "3" Then
                        PointSusut = 3
                    ElseIf .Item(i, 14) = "-1" Then
                        PointSusut = -1
                    ElseIf .Item(i, 15) = "-2" Then
                        PointSusut = -2
                    ElseIf .Item(i, 16) = "-3" Then
                        PointSusut = -3
                    ElseIf .Item(i, 17) = "-4" Then
                        PointSusut = -4
                    ElseIf .Item(i, 18) = "-5" Then
                        PointSusut = -5
                    End If
                    If .Item(i, 10) = True Then
                        PointMembantuKondisiEmergency = 2
                    End If
                    If .Item(i, 11) = True Then
                        PointAlokasiMuatKePancang = 1
                    End If
                    If .Item(i, 12) = True Then
                        PointKondisiKapalLayak = 1
                    End If
                    If .Item(i, 13) = True Then
                        PointKondisiKapalLengkap = 1
                    End If
                    If .Item(i, 19) = True Then
                        PointKapalRusakDiJalan = -1
                    End If
                    If .Item(i, 20) = True Then
                        PointMenolakPengirimanBarang = -1
                    End If
                    TotalPoint = .Item(i, 22)

                    If sp_SaveTrnHitungPointKapal(koneksi, Transaksi) = False Then
                        Transaksi.Rollback()
                        MsgBox("Simpan Data Gagal", vbCritical, "sp_SaveTrnHitungPointKapal")
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                Next
            End With

            Transaksi.Commit()
            MsgBox("Data Telah Tersimpan", MsgBoxStyle.Information)
            HeaderFG()
            showdata()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Cursor = Cursors.Default
        Finally
            koneksi.Close()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function sp_SaveTrnHitungPointKapal(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        sp_SaveTrnHitungPointKapal = False
        Dim MyCon As SqlConnection = Conn
        Dim MyConTrans As SqlTransaction = Trans
        Dim cmd As New SqlCommand
        Try
            With cmd
                '--------------------------------------------
                .Connection = Conn
                .CommandType = CommandType.StoredProcedure
                .CommandText = "RMPApp..sp_SaveTrnHitungPointKapal"
                .Transaction = MyConTrans

                .Parameters.Add("@IdKapal", SqlDbType.Int).Value = IdKapal
                .Parameters.Add("@IdPancang", SqlDbType.Int).Value = IdPancang
                .Parameters.Add("@Trip", SqlDbType.Int).Value = Trip
                .Parameters.Add("@N2Pancang", SqlDbType.Int).Value = N2Pancang
                .Parameters.Add("@N2Pabrik", SqlDbType.Int).Value = N2Pabrik
                .Parameters.Add("@SusutKg", SqlDbType.Int).Value = SusutKg
                .Parameters.Add("@SusutPersen", SqlDbType.VarChar, 10).Value = SusutPersent
                .Parameters.Add("@PointSusut", SqlDbType.Int).Value = PointSusut
                .Parameters.Add("@PointMembantuKondisiEmergency", SqlDbType.Int).Value = PointMembantuKondisiEmergency
                .Parameters.Add("@PointAlokasiMuatKePancang", SqlDbType.Int).Value = PointAlokasiMuatKePancang
                .Parameters.Add("@PointKondisiKapalLayak", SqlDbType.Int).Value = PointKondisiKapalLayak
                .Parameters.Add("@PointKondisiKapalLengkap", SqlDbType.Int).Value = PointKondisiKapalLengkap
                .Parameters.Add("@PointKapalRusakDiJalan", SqlDbType.Int).Value = PointKapalRusakDiJalan
                .Parameters.Add("@PointMenolakPengirimanBarang", SqlDbType.Int).Value = PointMenolakPengirimanBarang
                .Parameters.Add("@PointKapalTenggelam", SqlDbType.Int).Value = PointKapalTenggelam
                .Parameters.Add("@TotalPoint", SqlDbType.Int).Value = TotalPoint
                .Parameters.Add("@UserLogin", SqlDbType.VarChar, 50).Value = ClsSession.UserID
                .Parameters.Add("@NoTransPointKapal", SqlDbType.VarChar, 50).Value = NoTransPointKapal_sp
                .Parameters.Add(New SqlParameter("@Flag", SqlDbType.TinyInt, 1, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
                .ExecuteNonQuery()
            End With


            If CInt(cmd.Parameters("@Flag").Value) = "0" Then
                cmd.Dispose()
                Exit Function
            End If

            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function
End Class