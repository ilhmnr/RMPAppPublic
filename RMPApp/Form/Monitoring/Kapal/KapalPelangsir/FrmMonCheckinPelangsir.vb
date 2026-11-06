Imports C1.Win.C1FlexGrid

Public Class FrmMonCheckinPelangsir
    Dim Teks As String
    Dim Bergerak As Integer
    Private Sub FrmMonCheckinPelangsir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Teks = labelInfo.Text
        Timer1.Start()
        Modul_RMP.Combo.SetPancang(cmbPancang)
        tgl1.Value = Now
        tgl2.Value = Now
        Call HeaderFg()
        Call ShowData()
    End Sub

    Private Sub HeaderFg()
        With fg
            Dim txt As CellRange = New CellRange

            .Rows.Fixed = 1
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Cols.Count = 25

            .AllowMerging = True
            .AutoGenerateColumns = True
            .Rows(0).AllowMerging = True
            .Styles.Normal.WordWrap = True

            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular)
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .AllowMerging = AllowMergingEnum.RestrictAll

            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

            .Rows(0).TextAlign = TextAlignEnum.CenterCenter

            .Cols(1).AllowMerging = True

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).TextAlign = TextAlignEnum.LeftCenter : .Cols(0).AllowEditing = False
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Pancang" : .Cols(1).TextAlign = TextAlignEnum.LeftCenter : .Cols(1).AllowEditing = True
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Nama Pompong" : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).AllowEditing = False
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Kapasitas" : .Cols(3).TextAlign = TextAlignEnum.RightCenter : .Cols(3).AllowEditing = False : .Cols(3).Format = "#,###0"
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Nama Pemilik" : .Cols(4).TextAlign = TextAlignEnum.LeftCenter : .Cols(4).AllowEditing = False
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "NoHp Pemilik" : .Cols(5).TextAlign = TextAlignEnum.LeftCenter : .Cols(5).AllowEditing = False
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Nama Kapten" : .Cols(6).TextAlign = TextAlignEnum.LeftCenter : .Cols(6).AllowEditing = False
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "NoHp Kapten" : .Cols(7).TextAlign = TextAlignEnum.LeftCenter : .Cols(7).AllowEditing = False
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Alamat Pompong" : .Cols(8).TextAlign = TextAlignEnum.LeftCenter : .Cols(8).AllowEditing = False
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Status Antri" : .Cols(9).TextAlign = TextAlignEnum.LeftCenter : .Cols(9).AllowEditing = False
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "Jumlah Petani" : .Cols(10).TextAlign = TextAlignEnum.RightCenter : .Cols(10).AllowEditing = False : .Cols(10).Format = "#,###0"
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "Jumlah Muatan" : .Cols(11).TextAlign = TextAlignEnum.RightCenter : .Cols(11).AllowEditing = False : .Cols(11).Format = "#,###0"
            txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "Harga Tambang" : .Cols(12).TextAlign = TextAlignEnum.RightCenter : .Cols(12).AllowEditing = False : .Cols(12).Format = "#,###0"
            txt = .GetCellRange(0, 13, 0, 13) : txt.Data = "Jenis Harga Tambang" : .Cols(13).TextAlign = TextAlignEnum.LeftCenter : .Cols(13).AllowEditing = False
            txt = .GetCellRange(0, 14, 0, 14) : txt.Data = "Alamat Kelapa" : .Cols(14).TextAlign = TextAlignEnum.LeftCenter : .Cols(14).AllowEditing = False
            txt = .GetCellRange(0, 15, 0, 15) : txt.Data = "Trip" : .Cols(15).TextAlign = TextAlignEnum.LeftCenter : .Cols(15).AllowEditing = False
            txt = .GetCellRange(0, 16, 0, 16) : txt.Data = "Booking By" : .Cols(16).TextAlign = TextAlignEnum.LeftCenter : .Cols(16).AllowEditing = False
            txt = .GetCellRange(0, 17, 0, 17) : txt.Data = "Booking Date" : .Cols(17).TextAlign = TextAlignEnum.LeftCenter : .Cols(17).AllowEditing = False
            txt = .GetCellRange(0, 18, 0, 18) : txt.Data = "Checkin By" : .Cols(18).TextAlign = TextAlignEnum.LeftCenter : .Cols(18).AllowEditing = False
            txt = .GetCellRange(0, 19, 0, 19) : txt.Data = "Checkin Date" : .Cols(19).TextAlign = TextAlignEnum.LeftCenter : .Cols(19).AllowEditing = False
            txt = .GetCellRange(0, 20, 0, 20) : txt.Data = "Muat By" : .Cols(20).TextAlign = TextAlignEnum.LeftCenter : .Cols(20).AllowEditing = False
            txt = .GetCellRange(0, 21, 0, 21) : txt.Data = "Muat Date" : .Cols(21).TextAlign = TextAlignEnum.LeftCenter : .Cols(21).AllowEditing = False
            txt = .GetCellRange(0, 22, 0, 22) : txt.Data = "Close By" : .Cols(22).TextAlign = TextAlignEnum.LeftCenter : .Cols(22).AllowEditing = False
            txt = .GetCellRange(0, 23, 0, 23) : txt.Data = "Close Date" : .Cols(23).TextAlign = TextAlignEnum.LeftCenter : .Cols(23).AllowEditing = False
            txt = .GetCellRange(0, 24, 0, 24) : txt.Data = "Foto Checkin" : .Cols(24).Visible = False

            .AutoSizeCols()
        End With
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Call ShowData()
    End Sub

    Private Sub ShowData()
        Me.Cursor = Cursors.WaitCursor

        Dim dt As DataTable = New DataTable
        Dim sql As String = ""
        Dim i As Integer = 1

        sql = " select * from vwMonCheckinPelangsir where 1=1 "

        If cmbPancang.SelectedIndex <> -1 Then
            sql &= " and IDPancang='" & cmbPancang.SelectedValue & "' "
        End If

        If rdBooking.Checked = True Then
            sql &= " and cast(createddate as date) between cast('" & Format(tgl1.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(tgl2.Value, "yyyy-MM-dd") & "' as date) and statusantri='Booking' "
        ElseIf rdCheckin.Checked = True Then
            sql &= " and cast(checkindate as date) between cast('" & Format(tgl1.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(tgl2.Value, "yyyy-MM-dd") & "' as date) and statusantri='Checkin' "
        ElseIf rdMuat.Checked = True Then
            sql &= " and cast(muatdate as date) between cast('" & Format(tgl1.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(tgl2.Value, "yyyy-MM-dd") & "' as date) and statusantri='Muat' "
        ElseIf rdClose.Checked = True Then
            sql &= " and cast(closedate as date) between cast('" & Format(tgl1.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(tgl2.Value, "yyyy-MM-dd") & "' as date) and statusantri='Close' "
        ElseIf rdAll.Checked = True Then
            sql &= " and (cast(createddate as date) between cast('" & Format(tgl1.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(tgl2.Value, "yyyy-MM-dd") & "' as date) 
                        or cast(checkindate as date) between cast('" & Format(tgl1.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(tgl2.Value, "yyyy-MM-dd") & "' as date)
                        or cast(muatdate as date) between cast('" & Format(tgl1.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(tgl2.Value, "yyyy-MM-dd") & "' as date)
                        or cast(closedate as date) between cast('" & Format(tgl1.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(tgl2.Value, "yyyy-MM-dd") & "' as date)) "
        End If

        sql &= " order by Pancang asc "

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        fg.Rows.Count = 1
        fg.Cols(16).Visible = True
        fg.Cols(17).Visible = True
        fg.Cols(18).Visible = True
        fg.Cols(19).Visible = True
        fg.Cols(20).Visible = True
        fg.Cols(21).Visible = True
        fg.Cols(22).Visible = True
        fg.Cols(23).Visible = True

        If dt.Rows.Count >= 1 Then
            For Each row As DataRow In dt.Rows
                With fg
                    .AddItem(i)
                    .Item(i, 1) = row("Pancang")
                    .Item(i, 2) = row("namapompong")
                    .Item(i, 3) = row("kapasitas")
                    .Item(i, 4) = row("namapemilik")
                    .Item(i, 5) = row("nomorhppemilik")
                    .Item(i, 6) = row("namakapten")
                    .Item(i, 7) = row("nomorhpkapten")
                    .Item(i, 8) = row("alamatpompong")
                    .Item(i, 9) = row("statusantri")
                    .Item(i, 10) = row("jumlahpetani")
                    .Item(i, 11) = row("jumlahmuatan")
                    .Item(i, 12) = row("hargatambang")
                    .Item(i, 13) = row("jenishargatambang")
                    .Item(i, 14) = row("alamatkelapa")
                    .Item(i, 15) = row("trip")
                    .Item(i, 16) = row("createdby")
                    .Item(i, 17) = row("createddate")
                    .Item(i, 18) = row("checkinby")
                    .Item(i, 19) = row("checkindate")
                    .Item(i, 20) = row("muatby")
                    .Item(i, 21) = row("muatdate")
                    .Item(i, 22) = row("closeby")
                    .Item(i, 23) = row("closedate")
                    .Item(i, 24) = row("fotocheckin")

                    i += 1
                End With
            Next
            fg.AutoSizeCols()

            If rdBooking.Checked = True Then
                fg.Cols(18).Visible = False
                fg.Cols(19).Visible = False
                fg.Cols(20).Visible = False
                fg.Cols(21).Visible = False
                fg.Cols(22).Visible = False
                fg.Cols(23).Visible = False
            ElseIf rdCheckin.Checked = True Then
                fg.Cols(16).Visible = False
                fg.Cols(17).Visible = False
                fg.Cols(20).Visible = False
                fg.Cols(21).Visible = False
                fg.Cols(22).Visible = False
                fg.Cols(23).Visible = False
            ElseIf rdMuat.Checked = True Then
                fg.Cols(16).Visible = False
                fg.Cols(17).Visible = False
                fg.Cols(18).Visible = False
                fg.Cols(19).Visible = False
                fg.Cols(22).Visible = False
                fg.Cols(23).Visible = False
            ElseIf rdClose.Checked = True Then
                fg.Cols(16).Visible = False
                fg.Cols(17).Visible = False
                fg.Cols(18).Visible = False
                fg.Cols(19).Visible = False
                fg.Cols(20).Visible = False
                fg.Cols(21).Visible = False
            End If
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub rdCheckin_Click(sender As Object, e As EventArgs) Handles rdCheckin.Click
        Call ShowData()
    End Sub

    Private Sub rdClose_Click(sender As Object, e As EventArgs) Handles rdClose.Click
        Call ShowData()
    End Sub

    Private Sub rdMuat_Click(sender As Object, e As EventArgs) Handles rdMuat.Click
        Call ShowData()
    End Sub

    Private Sub rdAll_Click(sender As Object, e As EventArgs) Handles rdAll.Click
        Call ShowData()
    End Sub

    Private Sub cmbPancang_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbPancang.KeyUp
        UI.AutoCompleteCombo_KeyUp(cmbPancang, e)
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub FrmMonCheckinPelangsir_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Panel5.Left = (Me.Width \ 2) - (Panel5.Width \ 2)
    End Sub

    Private Sub fg_DoubleClick(sender As Object, e As EventArgs) Handles fg.DoubleClick
        If fg.Rows.Count > 1 Then
            If IsDBNull(fg.Item(fg.Row, 24)) Then
                MsgBox("Tidak Ada Foto !", vbInformation, AT)
            Else
                FrmFotoNota.Foto = "FotoCheckin"
                FrmFotoNota.images = fg.Item(fg.Row, 24)
                FrmFotoNota.ShowDialog()
            End If
        End If
    End Sub

    Private Sub rdBooking_Click(sender As Object, e As EventArgs) Handles rdBooking.Click
        Call ShowData()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        labelInfo.Text = Bergerak
        Teks = Microsoft.VisualBasic.Right(Teks, Len(Teks) - 1) & Microsoft.VisualBasic.Left(Teks, 1)
        labelInfo.Text = Teks
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        ' cek jika tidak ada data di grid
        If fg.Rows.Count <= 1 Then
            MsgBox("Tidak ada data untuk Excelkan.", vbInformation, AT)
            Exit Sub
        End If

        Call RekapExcel()
    End Sub

    Private Function RekapExcel() As Boolean
        RekapExcel = False

        Try
            If fg.Rows.Count <= 1 Then
                MsgBox("Data kosong.", vbExclamation)
                Exit Function
            End If

            Using save As New SaveFileDialog
                save.Filter = "Excel File (*.xlsx)|*.xlsx"
                save.FileName = "Check in Pelangsir " & Format(Now, "ddMMyyyy")

                If save.ShowDialog() = DialogResult.OK Then

                    ' === EXPORT LANGSUNG DARI GRID ===
                    ' otomatis hanya kolom Visible yang ikut
                    fg.SaveExcel(save.FileName, "Sheet1", FileFlags.IncludeFixedCells)

                    If IO.File.Exists(save.FileName) Then

                        MsgBox("Export berhasil!", vbInformation, "Sukses")
                        RekapExcel = True
                    Else
                        MsgBox("Export gagal.", vbCritical)
                    End If
                End If
            End Using

        Catch ex As Exception
            MsgBox("Error Export : " & ex.Message, vbCritical)
        End Try

        Return RekapExcel
    End Function
End Class