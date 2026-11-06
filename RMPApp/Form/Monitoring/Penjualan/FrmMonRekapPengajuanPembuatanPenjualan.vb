Imports C1.Win.C1FlexGrid
Imports Microsoft.Office.Interop

Public Class FrmMonRekapPengajuanPembuatanPenjualan
    Private Sub FrmMonApprovalPenerimaan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' set dtpMuat1 dan dtpMuat2 ke tanggal awal dan akhir bulan ini
        dtpPengajuan1.Value = Now
        dtpPengajuan2.Value = Now

        Call ClsFlexGrid.ApplyStyle(fg)
    End Sub
    Private Sub FrmMonApprovalPenerimaan_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        lblJudulForm.Left = (Me.Width \ 2) - (lblJudulForm.Width \ 2)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Me.Cursor = Cursors.WaitCursor

        Dim dt As New DataTable
        Dim i As Integer = 1
        Dim sql As String = "select * from RMPApp..vw_MonRekapPengajuanPembuatanPenjualan where cast(TanggalPenjualan as date) between '" & Format(dtpPengajuan1.Value, "yyyy-MM-dd") & "' and '" & Format(dtpPengajuan2.Value, "yyyy-MM-dd") & "' "

        If rdBelumRekapExcel.Checked = True Then
            sql &= " and SudahRekapExcel=0"
        ElseIf rdSudahRekapExcel.Checked = True Then
            sql &= " and SudahRekapExcel=1"
        End If

        sql &= " order by TanggalPenjualan,NoTrans asc"

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fg
            .Rows.Count = 1 ' Reset grid sebelum mengisi data baru

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "NoTrans") = row("NoTrans")
                    .Item(i, "NoNotaRefrensi") = row("NoNota")
                    .Item(i, "NoInvoice") = row("InvoiceNo")
                    .Item(i, "TanggalPengajuan") = row("TanggalPenjualan")
                    .Item(i, "Kapal") = row("Kapal")
                    .Item(i, "Pancang") = row("Pancang")
                    .Item(i, "Trip") = row("Trip")
                    .Item(i, "Tujuan") = row("Tujuan")
                    .Item(i, "Jenis") = row("Jenis")
                    .Item(i, "Grade") = row("Grade")
                    .Item(i, "GradeSub") = row("GradeSub")
                    .Item(i, "ItemName") = row("ItemName")
                    .Item(i, "Qty") = row("Qty")
                    .Item(i, "Price") = row("Price")
                    .Item(i, "TotalRpBeforePPH") = row("TotalRpBeforePPH")
                    .Item(i, "PersenPPH") = row("PersenPPH")
                    .Item(i, "RpPPH") = row("RpPPH")
                    .Item(i, "Total") = row("Total")

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

    Private Sub rdBelumRekapExcel_CheckedChanged(sender As Object, e As EventArgs) Handles rdBelumRekapExcel.CheckedChanged, rdSudahRekapExcel.CheckedChanged
        If rdBelumRekapExcel.Checked = True Then
            btnRekapExcel.Enabled = True
            btnRestore.Enabled = False
        ElseIf rdSudahRekapExcel.Checked = True Then
            btnRekapExcel.Enabled = False
            btnRestore.Enabled = True
        End If

        fg.Rows.Count = 1
    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg.BeforeEdit
        If fg.Cols(e.Col).Name = "Select" Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub btnRekapExcel_Click(sender As Object, e As EventArgs) Handles btnRekapExcel.Click, btnRestore.Click
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
                        "UPDATE RMPApp..TblTrnPembuatanPenjualanHdr 
                         SET SudahRekapExcel = 0 
                         WHERE NoTrans = '" & fg.Item(j, "NoTrans") & "'
                         
                         UPDATE RMPApp..tblTrnPenjualanHdr 
                         SET SudahRekapExcel = 0 
                         WHERE NoPenjualan = '" & fg.Item(j, "NoTrans") & "'"
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

            Using save As New SaveFileDialog
                save.Filter = "Excel File (*.xlsx)|*.xlsx"
                save.FileName = "Pengajuan Tambang Kapal_" & Format(Now, "yyyyMMdd")

                If save.ShowDialog() = DialogResult.OK Then

                    ' === EXPORT LANGSUNG DARI FLEXGRID ===
                    ' otomatis tidak export kolom Hidden
                    ' pastikan kolom "Select" diset Visible = False di design / code
                    fg.SaveExcel(save.FileName, "Sheet1", FileFlags.IncludeFixedCells)

                    If IO.File.Exists(save.FileName) Then

                        ' === Update status database ===
                        For j As Integer = 1 To fg.Rows.Count - 1
                            Modul_RMP.DB.ExecuteQuery(StrConnRMPApp,
                            "UPDATE RMPApp..TblTrnPembuatanPenjualanHdr 
                             SET SudahRekapExcel = 1
                             WHERE NoTrans = '" & fg.Item(j, "NoTrans") & "'
                         
                             UPDATE RMPApp..tblTrnPenjualanHdr 
                             SET SudahRekapExcel = 1 
                             WHERE NoPenjualan = '" & fg.Item(j, "NoTrans") & "'")
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

    Private Sub SumTotalCheck()

        If fg.Rows.Count <= 2 Then Exit Sub

        Dim rowTotal As Integer = fg.Rows.Count - 1

        ' Reset total
        fg.Item(rowTotal, "Qty") = 0
        fg.Item(rowTotal, "RpPPH") = 0
        fg.Item(rowTotal, "TotalRpBeforePPH") = 0
        fg.Item(rowTotal, "Total") = 0

        ' Hitung hanya yang dicentang
        For r As Integer = 1 To fg.Rows.Count - 2
            If fg.Item(r, "Select") = True Then
                fg.Item(rowTotal, "Qty") += Val(fg.Item(r, "Qty"))
                fg.Item(rowTotal, "RpPPH") += If(IsDBNull(fg.Item(r, "RpPPH")), 0D, CDbl(fg.Item(r, "RpPPH")))
                fg.Item(rowTotal, "TotalRpBeforePPH") += If(IsDBNull(fg.Item(r, "TotalRpBeforePPH")), 0D, CDbl(fg.Item(r, "TotalRpBeforePPH")))
                fg.Item(rowTotal, "Total") += Val(fg.Item(r, "Total"))
            End If
        Next

        fg.AutoSizeCols()
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

    Private Sub fg_SelChange(sender As Object, e As EventArgs) Handles fg.SelChange
        Dim grid As C1.Win.C1FlexGrid.C1FlexGrid = CType(sender, C1.Win.C1FlexGrid.C1FlexGrid)

        txtTotal.Text = ClsFunction.FormatNum(grid.Aggregate(AggregateEnum.Sum), 2)
    End Sub

End Class