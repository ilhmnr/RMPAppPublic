Imports C1.Win.C1FlexGrid

Public Class FrmMonPointKapalRanking
    Private Sub FrmMonRankingPointKapal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtp1.Value = Now
        dtp2.Value = Now

        Call HeaderFg()
    End Sub

    Private Sub HeaderFg()
        Dim txt As CellRange
        With fg
            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
            .Cols.Count = 17
            .Cols.Fixed = 1
            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 3
            .Rows.Count = 3
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Rows(1).AllowMerging = True
            .Rows(2).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 0, 2, 0) : txt.Data = "No" : .Cols(0).TextAlign = TextAlignEnum.LeftCenter : .Cols(0).AllowEditing = False : .Cols(0).AllowMerging = True
            txt = .GetCellRange(0, 1, 2, 1) : txt.Data = "PANCANG" : .Cols(1).TextAlign = TextAlignEnum.LeftCenter : .Cols(1).AllowEditing = False : .Cols(1).AllowMerging = True
            txt = .GetCellRange(0, 2, 2, 2) : txt.Data = "NAMA KAPAL" : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).AllowEditing = False : .Cols(2).AllowMerging = True
            txt = .GetCellRange(0, 3, 2, 3) : txt.Data = "TRIP" : .Cols(3).TextAlign = TextAlignEnum.CenterCenter : .Cols(3).AllowEditing = False : .Cols(3).AllowMerging = True
            txt = .GetCellRange(0, 4, 2, 4) : txt.Data = "N2 PANCANG" : .Cols(4).TextAlign = TextAlignEnum.RightCenter : .Cols(4).AllowEditing = False : .Cols(4).AllowMerging = True : .Cols(4).Format = "#,###0"
            txt = .GetCellRange(0, 5, 2, 5) : txt.Data = "POINT" : .Cols(5).TextAlign = TextAlignEnum.CenterCenter : .Cols(5).AllowEditing = False : .Cols(5).AllowMerging = True

            txt = .GetCellRange(0, 6, 0, 11) : txt.Data = "N2 PABRIK"
            txt = .GetCellRange(1, 6, 1, 11) : txt.Data = "TOTAL KB TERIMA PABRIK"
            txt = .GetCellRange(2, 6, 2, 6) : txt.Data = "KB-A" : .Cols(6).TextAlign = TextAlignEnum.RightCenter : .Cols(6).AllowEditing = False : .Cols(6).AllowMerging = True : .Cols(4).Format = "#,###0"
            txt = .GetCellRange(2, 7, 2, 7) : txt.Data = "%" : .Cols(7).TextAlign = TextAlignEnum.CenterCenter : .Cols(7).AllowEditing = False : .Cols(7).AllowMerging = True
            txt = .GetCellRange(2, 8, 2, 8) : txt.Data = "KB-B" : .Cols(8).TextAlign = TextAlignEnum.RightCenter : .Cols(8).AllowEditing = False : .Cols(8).AllowMerging = True : .Cols(4).Format = "#,###0"
            txt = .GetCellRange(2, 9, 2, 9) : txt.Data = "%" : .Cols(9).TextAlign = TextAlignEnum.CenterCenter : .Cols(9).AllowEditing = False : .Cols(9).AllowMerging = True
            txt = .GetCellRange(2, 10, 2, 10) : txt.Data = "POINT" : .Cols(10).TextAlign = TextAlignEnum.CenterCenter : .Cols(10).AllowEditing = False : .Cols(10).AllowMerging = True
            txt = .GetCellRange(2, 11, 2, 11) : txt.Data = "TOTAL" : .Cols(11).TextAlign = TextAlignEnum.RightCenter : .Cols(11).AllowEditing = False : .Cols(11).AllowMerging = True : .Cols(4).Format = "#,###0"

            txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "SUSUT"
            txt = .GetCellRange(1, 12, 2, 12) : txt.Data = "TOTAL SUSUT KB" : .Cols(12).TextAlign = TextAlignEnum.RightCenter : .Cols(12).AllowEditing = False : .Cols(12).AllowMerging = True : .Cols(4).Format = "#,###0"
            txt = .GetCellRange(1, 13, 2, 13) : txt.Data = "%" : .Cols(13).TextAlign = TextAlignEnum.CenterCenter : .Cols(13).AllowEditing = False : .Cols(13).AllowMerging = True
            txt = .GetCellRange(1, 14, 2, 14) : txt.Data = "POINT" : .Cols(14).TextAlign = TextAlignEnum.CenterCenter : .Cols(14).AllowEditing = False : .Cols(14).AllowMerging = True
            txt = .GetCellRange(0, 15, 2, 15) : txt.Data = "TOTAL POINT" : .Cols(15).TextAlign = TextAlignEnum.CenterCenter : .Cols(15).AllowEditing = False : .Cols(15).AllowMerging = True
            txt = .GetCellRange(0, 16, 2, 16) : txt.Data = "RANKING" : .Cols(16).TextAlign = TextAlignEnum.CenterCenter : .Cols(16).AllowEditing = False : .Cols(16).AllowMerging = True

            .AutoSizeCols()
        End With
    End Sub


    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        Me.Cursor = Cursors.WaitCursor

        With fg
            Dim dt As DataTable = New DataTable
            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " select *,ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS Ranking from RMPApp..fnDataRankingPointKapal ('" & Format(dtp1.Value, "yyyy-MM") & "','" & Format(dtp2.Value, "yyyy-MM") & "') order by TotalPoint desc ")

            fg.Rows.Count = 3

            Dim i As Integer = 3

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i - 2)
                    .Item(i, 1) = row("Pancang")
                    .Item(i, 2) = row("KapalName")
                    .Item(i, 3) = row("TotalTrip")
                    .Item(i, 4) = row("N2PANCANG")
                    .Item(i, 5) = row("PointPenilaian")
                    .Item(i, 6) = row("N2PabrikKBA")
                    .Item(i, 7) = row("ProsenN2PabrikKBA")
                    .Item(i, 8) = row("N2PabrikKBB")
                    .Item(i, 9) = row("ProsenN2PabrikKBB")
                    .Item(i, 10) = row("PointKBB")
                    .Item(i, 11) = row("TotalN2Pabrik")
                    .Item(i, 12) = row("Susut")
                    .Item(i, 13) = row("ProsenSusut")
                    .Item(i, 14) = row("PointSusut")
                    .Item(i, 15) = row("TotalPoint")
                    .Item(i, 16) = row("Ranking")

                    i += 1
                Next

                .AutoSizeCols()
            Else
                MsgBox("Tidak ada data yang di temukan", vbInformation, AT)
            End If
        End With

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnExcel_Click(sender As Object, e As EventArgs) Handles BtnExcel.Click
        If fg.Rows.Count > 1 Then
            Try
                Dim filename As String
                Me.SaveFileDialog1.ShowDialog()
                filename = SaveFileDialog1.FileName
                Me.fg.SaveExcel(filename & ".xls", "Sheet1", FileFlags.IncludeFixedCells)
                MsgBox("Berhasil Compert Ke Excel !", vbInformation, AT)
            Catch ex As Exception
                MsgBox("Gagal Compert Ke Excel !", vbInformation, AT)
            End Try
        Else
            MsgBox("Tidak Ada Data Yang Akan Di Compert Ke Excel !", vbInformation, AT)
        End If
    End Sub
End Class