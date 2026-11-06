Imports C1.Win.C1FlexGrid

Public Class FrmMonLemburPersonilPCGFind
    Dim dateStart As Date

    Private Sub FrmMonLemburPersonilPCGFind_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtp.Value = Format(Now, "dd/MM/yyyy")
        Call HeaderFg()
    End Sub

    Private Sub HeaderFg()
        Dim txt As CellRange

        With fg
            .Rows.Fixed = 1
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Cols.Count = 9

            .AutoGenerateColumns = True
            .Rows(0).AllowMerging = True
            .Styles.Normal.WordWrap = True

            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular)
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .AllowMerging = AllowMergingEnum.FixedOnly

            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

            .Rows(0).TextAlign = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).TextAlign = TextAlignEnum.LeftCenter : .Cols(0).AllowEditing = False
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Periode" : .Cols(1).TextAlign = TextAlignEnum.CenterCenter : .Cols(1).AllowEditing = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "FixNo" : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).AllowEditing = False
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "ID Relasi" : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).AllowEditing = False
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Nama" : .Cols(4).TextAlign = TextAlignEnum.LeftCenter : .Cols(4).AllowEditing = False
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Nik" : .Cols(5).TextAlign = TextAlignEnum.LeftCenter : .Cols(5).AllowEditing = False
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Jam Lembur" : .Cols(6).TextAlign = TextAlignEnum.LeftCenter : .Cols(6).AllowEditing = False
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Created By" : .Cols(7).TextAlign = TextAlignEnum.LeftCenter : .Cols(7).AllowEditing = False
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Created Date" : .Cols(8).TextAlign = TextAlignEnum.CenterCenter : .Cols(8).AllowEditing = False

            .AutoSizeCols()
        End With
    End Sub

    Private Sub btnrefreshh_Click(sender As Object, e As EventArgs) Handles btnrefreshh.Click
        Dim dt As DataTable = New DataTable()
        Dim i As Integer = 1

        If rdPeriode1.Checked = True Then
            dateStart = New Date(dtp.Value.Year, dtp.Value.Month, 1)
        Else
            dateStart = New Date(dtp.Value.Year, dtp.Value.Month, 16)
        End If

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select a.*,(select top 1 IDPersonil from RMPApp..TblMstPersonilPancangNew where RegFixNo=a.FixNo) as IDPersonil from RMPApp..tblTransaksiKalkulasiLemburPancang as a where cast(a.Periode as date)='" & Format(dateStart, "yyyy-MM-dd") & "'")

        With fg
            .Rows.Count = 1

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, 1) = row("Periode")
                    .Item(i, 2) = row("FixNo")
                    .Item(i, 3) = row("IDPersonil")
                    .Item(i, 4) = row("Nama")
                    .Item(i, 5) = row("Nik")
                    .Item(i, 6) = row("TotalJam")
                    .Item(i, 7) = row("CreatedBy")
                    .Item(i, 8) = row("CreatedDate")

                    i += 1
                Next

                .AutoSizeCols()
            End If
        End With
    End Sub
End Class