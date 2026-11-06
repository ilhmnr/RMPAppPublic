Imports C1.Win.C1FlexGrid

Public Class FrmMonProgresNotaPancang
    Private Sub FrmMonProgresNotaPancang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call HeaderFg()

        Dim today As DateTime = DateTime.Now

        ' Set awal bulan
        dtpStart.Value = New DateTime(today.Year, today.Month, 1)

        ' Set akhir bulan
        dtpEnd.Value = New DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month))

        Modul_RMP.Combo.SetPancang(cmbPancang)
    End Sub

    Private Sub HeaderFg()
        Dim txt As CellRange

        With fg
            .Rows.Fixed = 1
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Cols.Count = 18

            .AutoGenerateColumns = True
            .Rows(0).AllowMerging = True
            .Styles.Normal.WordWrap = True

            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular)
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .AllowMerging = AllowMergingEnum.FixedOnly

            .Styles.Fixed.BackColor = Color.FromArgb(179, 229, 252)
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(137, 214, 250)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(137, 214, 250)

            .Rows(0).TextAlign = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).TextAlign = TextAlignEnum.LeftCenter : .Cols(0).AllowEditing = False
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Pancang" : .Cols(1).TextAlign = TextAlignEnum.LeftCenter : .Cols(1).AllowEditing = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Nama Kapal" : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).AllowEditing = False
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Trip" : .Cols(3).TextAlign = TextAlignEnum.CenterCenter : .Cols(3).AllowEditing = False
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Tujuan" : .Cols(4).TextAlign = TextAlignEnum.CenterCenter : .Cols(4).AllowEditing = False
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Grade" : .Cols(5).TextAlign = TextAlignEnum.CenterCenter : .Cols(5).AllowEditing = False
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Jenis Kelapa" : .Cols(6).TextAlign = TextAlignEnum.CenterCenter : .Cols(6).AllowEditing = False
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Status Antri" : .Cols(7).TextAlign = TextAlignEnum.LeftCenter : .Cols(7).AllowEditing = False
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Tanggal Booking" : .Cols(8).TextAlign = TextAlignEnum.CenterCenter : .Cols(8).AllowEditing = False
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Tanggal Awal Timbang" : .Cols(9).TextAlign = TextAlignEnum.CenterCenter : .Cols(9).AllowEditing = False
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "Tanggal Akhir Timbang" : .Cols(10).TextAlign = TextAlignEnum.CenterCenter : .Cols(10).AllowEditing = False
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "Tanggal OTW" : .Cols(11).TextAlign = TextAlignEnum.CenterCenter : .Cols(11).AllowEditing = False
            txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "Tanggal Checkin" : .Cols(12).TextAlign = TextAlignEnum.CenterCenter : .Cols(12).AllowEditing = False
            txt = .GetCellRange(0, 13, 0, 13) : txt.Data = "Tanggal UB" : .Cols(13).TextAlign = TextAlignEnum.CenterCenter : .Cols(13).AllowEditing = False
            txt = .GetCellRange(0, 14, 0, 14) : txt.Data = "Tanggal Bongkar Pabrik" : .Cols(14).TextAlign = TextAlignEnum.CenterCenter : .Cols(14).AllowEditing = False
            txt = .GetCellRange(0, 15, 0, 15) : txt.Data = "Tanggal Release Pabrik" : .Cols(15).TextAlign = TextAlignEnum.CenterCenter : .Cols(15).AllowEditing = False
            txt = .GetCellRange(0, 16, 0, 16) : txt.Data = "Tanggal DO" : .Cols(16).TextAlign = TextAlignEnum.CenterCenter : .Cols(16).AllowEditing = False
            txt = .GetCellRange(0, 17, 0, 17) : txt.Data = "Tanggal UBM" : .Cols(17).TextAlign = TextAlignEnum.CenterCenter : .Cols(17).AllowEditing = False

            .AutoSizeCols()
        End With
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        Dim query As String = ""
        Dim dt As DataTable = New DataTable
        Dim i As Integer = 1

        Cursor = Cursors.WaitCursor

        query = " select * from RMPApp..fnMonProgresNotaPancang('" & Format(dtpStart.Value, "yyyy-MM-dd") & "','" & Format(dtpEnd.Value, "yyyy-MM-dd") & "','" & cmbPancang.SelectedValue & "','" & txtTrip.Text & "') order by booking_pancang_date asc "

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, query)

        fg.Rows.Count = 1

        If dt.Rows.Count > 0 Then
            With fg
                For Each row As DataRow In dt.Rows

                    .AddItem(i)
                    .Item(i, 1) = row("Pancang")
                    .Item(i, 2) = row("NamaKapal")
                    .Item(i, 3) = row("TripID")
                    .Item(i, 4) = row("Tujuan")
                    .Item(i, 5) = row("JenisMuat")
                    .Item(i, 6) = row("Jenis")
                    .Item(i, 7) = row("status_antri")
                    .Item(i, 8) = row("booking_pancang_date")
                    .Item(i, 9) = row("AwalTimbangDate")
                    .Item(i, 10) = row("AkhirTimbangDate")
                    .Item(i, 11) = row("otw_pabrik_date")
                    .Item(i, 12) = row("checkin_pabrik_date")
                    .Item(i, 13) = row("TglUB")
                    .Item(i, 14) = row("bongkar_pabrik_date")
                    .Item(i, 15) = row("release_pabrik_date")
                    If row("indNota") = True Then
                        .Item(i, 16) = row("TglDO")
                    Else
                        .Item(i, 16) = row("TglDOHBS")
                    End If
                    .Item(i, 17) = row("TglUBM")

                    i += 1

                Next

                .AutoSizeCols()
            End With
        Else
            MsgBox("Data tidak ditemukan", MsgBoxStyle.Critical, "Error")
        End If

        Cursor = Cursors.Default
    End Sub
End Class