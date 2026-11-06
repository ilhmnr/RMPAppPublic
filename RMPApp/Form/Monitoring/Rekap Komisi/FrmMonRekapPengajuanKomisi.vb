Imports C1.Win.C1FlexGrid
Imports Microsoft.Office.Interop

Public Class FrmMonRekapPengajuanKomisi
    Private Sub FrmMonApprovalPenerimaan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' set dtpMuat1 dan dtpMuat2 ke tanggal awal dan akhir bulan ini
        dtpPengajuan1.Value = Now
        dtpPengajuan2.Value = Now

        Call HeaderFG()
    End Sub

    Public Sub HeaderFG()
        ' Pastikan objek fg sudah tersedia
        If fg Is Nothing Then Exit Sub

        With fg
            ' === Pengaturan dasar grid ===
            .AllowEditing = True
            .Font = New Font("Century Gothic", 9.0!, FontStyle.Regular)
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True

            ' === Warna header dan baris selang-seling ===
            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)   ' Warna latar header utama
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224) ' Warna latar baris bergantian
            .Styles.Fixed.TextAlign = TextAlignEnum.LeftCenter          ' Rata kiri untuk header

            ' === Pastikan ada minimal 2 baris header ===
            .Rows.Count = 1

            ' === Warna khusus untuk baris header ke-0 dan ke-1 ===
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

            ' === Aktifkan fitur merging untuk header ===
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True

            ' === Sesuaikan ukuran kolom secara otomatis ===
            .AutoSizeCols()
        End With
    End Sub

    Private Sub FrmMonApprovalPenerimaan_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        lblJudulForm.Left = (Me.Width \ 2) - (lblJudulForm.Width \ 2)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Me.Cursor = Cursors.WaitCursor

        Dim dt As New DataTable
        Dim i As Integer = 1
        Dim sql As String = "select * from RMPApp..vw_MonRekapPengajuanKomisi where ApprovalStatus=1 and cast(TanggalPengajuan as date) between '" & Format(dtpPengajuan1.Value, "yyyy-MM-dd") & "' and '" & Format(dtpPengajuan2.Value, "yyyy-MM-dd") & "' "

        If rdBelumRekapExcel.Checked = True Then
            sql &= " and SudahRekapExcel=0"
        ElseIf rdSudahRekapExcel.Checked = True Then
            sql &= " and SudahRekapExcel=1"
        End If

        If rdPemilikLahan.Checked = True Then
            sql &= " and JenisKomisi='Pemilik Lahan'"
        ElseIf rdToke.Checked = True Then
            sql &= " and JenisKomisi='Toke'"
        End If

        sql &= " order by TanggalPengajuan,NoTrans asc"

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fg
            .Rows.Count = 1 ' Reset grid sebelum mengisi data baru

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "NoTrans") = row("NoTrans")
                    .Item(i, "TanggalPengajuan") = row("TanggalPengajuan")
                    .Item(i, "Pancang") = row("Pancang")
                    .Item(i, "RelasiID") = row("RelasiID")
                    .Item(i, "RelasiName") = row("RelasiName")
                    .Item(i, "RekeningName") = row("RekeningName")
                    .Item(i, "KtpNpwp") = row("KtpNpwp")
                    .Item(i, "RekeningNo") = row("RekeningNo")
                    .Item(i, "RekeningBank") = row("RekeningBank")
                    .Item(i, "BadanUsaha") = row("BadanUsaha")
                    .Item(i, "TotalPemasukan") = row("TotalPemasukan")
                    .Item(i, "Tarif") = row("Tarif")
                    .Item(i, "TotalRp") = row("TotalRp")
                    .Item(i, "TarifPajak") = row("TarifPajak")
                    .Item(i, "PotPPH21") = row("PotPPH21")
                    .Item(i, "PotPPH23") = row("PotPPH23")
                    .Item(i, "GrandTotal") = row("GrandTotal")

                    i += 1
                Next

                If rdBelumRekapExcel.Checked = True Then
                    ' === Tambah baris TOTAL ===
                    Dim rowTotal As Integer = fg.Rows.Count
                    fg.AddItem("")
                    fg.Item(rowTotal, "NoTrans") = "TOTAL"
                    fg.Rows(rowTotal).StyleNew.BackColor = Color.LightYellow
                    fg.Rows(rowTotal).AllowEditing = False
                End If

                .AutoSizeCols()
            Else
                MsgBox("Tidak ada data.", vbInformation, AT)
            End If
        End With

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub rdBelumRekapExcel_CheckedChanged(sender As Object, e As EventArgs) Handles rdSudahRekapExcel.CheckedChanged, rdBelumRekapExcel.CheckedChanged, rdPemilikLahan.CheckedChanged, rdToke.CheckedChanged
        If rdBelumRekapExcel.Checked = True Then
            btnRekapExcel.Enabled = True
            btnRestore.Enabled = False
        ElseIf rdSudahRekapExcel.Checked = True Then
            btnRekapExcel.Enabled = False
            btnRestore.Enabled = True
        End If

        fg.Rows.Count = 1
    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs)

    End Sub

    Private Sub btnRekapExcel_Click(sender As Object, e As EventArgs) Handles btnRestore.Click, btnRekapExcel.Click
        ' cek jika tidak ada data di grid
        If fg.Rows.Count <= 1 Then
            MsgBox("Tidak ada data untuk direkap/direstore.", vbInformation, AT)
            Exit Sub
        End If

        ' cek jika tidak ada data yang dipilih
        Dim adaDipilih As Boolean = False
        For i As Integer = 1 To fg.Rows.Count - 1
            If fg.Item(i, "Select") = True Then
                adaDipilih = True
                Exit For
            End If
        Next
        If adaDipilih = False Then
            MsgBox("Tidak ada data yang dipilih untuk direkap/direstore.", vbInformation, AT)
            Exit Sub
        End If

        ' jika klik btnrekapexce
        If sender Is btnRekapExcel Then
            ' remove baris yang tidak di pilih
            For i As Integer = fg.Rows.Count - 2 To 1 Step -1
                If fg.Item(i, "Select") = False Then
                    fg.RemoveItem(i)
                End If
            Next

            ' set ulang no
            For i As Integer = 1 To fg.Rows.Count - 1
                fg.Item(i, 0) = i
            Next

            If RekapExcel() = True Then
                btnSearch.PerformClick()
            End If
        ElseIf sender Is btnRestore Then
            ' Konfirmasi restore
            If MsgBox("Yakin mau restore data?", vbYesNo + vbQuestion, "Konfirmasi") = vbNo Then
                Exit Sub
            End If

            ' Update status SudahRekapExcel
            For j As Integer = 1 To fg.Rows.Count - 1
                If fg.Item(j, "Select") = True Then
                    Modul_RMP.DB.ExecuteQuery(StrConnRMPApp,
                        "UPDATE RMPApp..TblTrnKomisiDtl " &
                        "SET SudahRekapExcel = 0 " &
                        "WHERE NoTrans = '" & fg.Item(j, "NoTrans") & "'"
                    )
                End If
            Next

            ' Refresh data
            btnSearch.PerformClick()

            MsgBox("Restore berhasil.", vbInformation, "Sukses")
        End If
    End Sub

    Private Function RekapExcel() As Boolean
        RekapExcel = False

        Try
            ' === Cek data ===
            If fg.Rows.Count <= 1 Then
                MsgBox("Data kosong.", vbExclamation)
                Exit Function
            End If

            ' === Sembunyikan kolom Select saat export ===
            Dim selectVisible As Boolean = False
            If fg.Cols.Contains("Select") Then
                selectVisible = fg.Cols("Select").Visible
                fg.Cols("Select").Visible = False
            End If

            Using save As New SaveFileDialog
                save.Filter = "Excel File (*.xlsx)|*.xlsx"

                ' === Nama file sesuai radio button ===
                If rdPemilikLahan.Checked Then
                    save.FileName = "Pengajuan Komisi Pemilik Lahan_" & Format(Now, "yyyyMMdd")
                ElseIf rdToke.Checked Then
                    save.FileName = "Pengajuan Komisi Toke_" & Format(Now, "yyyyMMdd")
                Else
                    save.FileName = "Pengajuan Komisi_" & Format(Now, "yyyyMMdd")
                End If

                If save.ShowDialog() = DialogResult.OK Then

                    ' === Export langsung dari FlexGrid ===
                    fg.SaveExcel(save.FileName, "Sheet1", FileFlags.IncludeFixedCells)

                    ' === Kembalikan kolom Select ===
                    If fg.Cols.Contains("Select") Then
                        fg.Cols("Select").Visible = selectVisible
                    End If

                    If IO.File.Exists(save.FileName) Then

                        ' === Update status database ===
                        For j As Integer = 1 To fg.Rows.Count - 1
                            Modul_RMP.DB.ExecuteQuery(StrConnRMPApp,
                            "UPDATE RMPApp..TblTrnKomisiDtl " &
                            "SET SudahRekapExcel=1 " &
                            "WHERE NoTrans='" & fg.Item(j, "NoTrans") & "'")
                        Next

                        MsgBox("Export berhasil!", vbInformation, "Sukses")
                        RekapExcel = True
                    Else
                        MsgBox("Export gagal.", vbCritical, "Gagal")
                    End If
                End If
            End Using

        Catch ex As Exception
            MsgBox("Error Export : " & ex.Message, vbCritical)
        End Try

        Return RekapExcel
    End Function


    Private Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelectAll.CheckedChanged
        ' Set semua checkbox di kolom "Select" sesuai dengan status chkSelectAll
        For i As Integer = 1 To fg.Rows.Count - 1
            fg.Item(i, "Select") = chkSelectAll.Checked

            If fg.Rows.Count > 1 And rdBelumRekapExcel.Checked = True Then
                Call SumTotalCheck()
            End If
        Next
    End Sub

    Private Sub fg_AfterEdit(sender As Object, e As RowColEventArgs) Handles fg.AfterEdit
        With fg
            If fg.Rows.Count <= 1 Then Exit Sub

            ' Jika kolom yang diedit adalah "Select"
            If .Cols(e.Col).Name = "Select" Then
                Call SumTotalCheck()
            End If
        End With
    End Sub

    Private Sub SumTotalCheck()

        If fg.Rows.Count <= 2 Then Exit Sub

        Dim rowTotal As Integer = fg.Rows.Count - 1

        ' Reset total
        fg.Item(rowTotal, "TotalPemasukan") = 0
        fg.Item(rowTotal, "TotalRp") = 0
        fg.Item(rowTotal, "PotPPH21") = 0
        fg.Item(rowTotal, "PotPPH23") = 0
        fg.Item(rowTotal, "GrandTotal") = 0

        ' Hitung hanya baris yang dicentang
        For r As Integer = 1 To fg.Rows.Count - 2

            If fg.Item(r, "Select") = True Then
                fg.Item(rowTotal, "TotalPemasukan") += Val(fg.Item(r, "TotalPemasukan"))
                fg.Item(rowTotal, "TotalRp") += Val(fg.Item(r, "TotalRp"))
                fg.Item(rowTotal, "PotPPH21") += Val(fg.Item(r, "PotPPH21"))
                fg.Item(rowTotal, "PotPPH23") += Val(fg.Item(r, "PotPPH23"))
                fg.Item(rowTotal, "GrandTotal") += Val(fg.Item(r, "GrandTotal"))
            End If

        Next

    End Sub

End Class