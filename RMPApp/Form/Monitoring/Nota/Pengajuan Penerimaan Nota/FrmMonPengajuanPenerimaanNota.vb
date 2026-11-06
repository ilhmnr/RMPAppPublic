Imports C1.Win.C1FlexGrid
Imports Microsoft.Office.Interop

Public Class FrmMonPengajuanPenerimaanNota
    Private Sub FrmMonApprovalPenerimaan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set ComboBox
        Modul_RMP.Combo.SetPancang(cboPancang)
        cboPancang.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboPancang.AutoCompleteSource = AutoCompleteSource.ListItems
        Modul_RMP.Combo.SetKapal(cboKapal)
        cboKapal.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboKapal.AutoCompleteSource = AutoCompleteSource.ListItems

        dtpTanggalApproval.Value = Now
        dtpTanggalApproval2.Value = Now
        dtpTanggalNota1.Value = Now
        dtpTanggalNota2.Value = Now

        Call ClsFlexGrid.ApplyStyle(fg)
    End Sub

    Private Sub FrmMonApprovalPenerimaan_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        lblJudulForm.Left = (Me.Width \ 2) - (lblJudulForm.Width \ 2)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Me.Cursor = Cursors.WaitCursor

        Dim dt As New DataTable
        Dim i As Integer = 1
        Dim sql As String = "select 
                                b.TanggalApproval,(cast(d.IDPancang as varchar(10))+'. '+d.Pancang) as Pancang,(cast(e.KapalID as varchar(20))+'. '+e.KapalName) as Kapal,a.Trip,
                                c.TransDate,c.Bongkar,c.Jenis,c.JenisKB,c.GradeSub,a.* 
                                from TblTrnApprovalPenerimaanDtl as a
                                inner join TblTrnApprovalPenerimaanHdr as b on a.NoTrans=b.NoTrans
                                inner join TblTrnKelapaHdr as c on a.InvoiceNo=c.NoNota
                                inner join Android_tblMstPancang as d on a.IDPancang=d.IDPancang
                                inner join tblMstKapal as e on a.IDKapal=e.KapalID
                                where a.Deleted=0 and b.Deleted=0 "

        If rdTglApproval.Checked = True Then
            sql &= " and cast(b.TanggalApproval as date) between '" & Format(dtpTanggalApproval.Value, "yyyy-MM-dd") & "' and '" & Format(dtpTanggalApproval2.Value, "yyyy-MM-dd") & "' "
        ElseIf rdTglNota.Checked = True Then
            sql &= " and cast(C.TransDate as date) between '" & Format(dtpTanggalNota1.Value, "yyyy-MM-dd") & "' and '" & Format(dtpTanggalNota2.Value, "yyyy-MM-dd") & "' "
        End If

        If txtTrip.Text <> "" Then
            sql &= " and a.Trip='" & txtTrip.Text & "'"
        End If

        If cboPancang.Text <> "" Then
            sql &= " and a.IDPancang='" & cboPancang.SelectedValue & "'"
        End If

        If cboKapal.Text <> "" Then
            sql &= " and a.IDKapal='" & cboKapal.SelectedValue & "'"
        End If

        If rdRSUP.Checked = True Then
            sql &= " and a.Tujuan='RSUP'"
        ElseIf rdPSG.Checked = True Then
            sql &= " and a.Tujuan='PSG'"
        ElseIf rdAllTujuan.Checked = True Then
            ' Tidak perlu menambahkan kondisi apapun untuk "All Tujuan"
        End If

        If rdJambul.Checked = True Then
            sql &= " and a.Jenis='Jambul'"

            If chkA6.Checked = True Then
                sql &= " and a.GradeSub='A6'"
            Else
                sql &= " and a.GradeSub='A'"
            End If
        ElseIf rdLicin.Checked = True Then
            sql &= " and a.Jenis='Licin'"

            If chkA6.Checked = True Then
                sql &= " and a.GradeSub='A6'"
            Else
                sql &= " and a.GradeSub='A'"
            End If
        ElseIf rdCungkil.Checked = True Then
            sql &= " and a.Jenis='Cungkil'"
        ElseIf rdAllJenis.Checked = True Then
            ' Tidak perlu menambahkan kondisi apapun untuk "All Jenis"
        End If

        If rdKBA.Checked = True Then
            sql &= " and a.Grade='KB-A'"
        ElseIf rdKBB.Checked = True Then
            sql &= " and a.Grade='KB-B'"
        ElseIf rdKC.Checked = True Then
            sql &= " and a.Grade='KC'"
        ElseIf rdAllGrade.Checked = True Then
            ' Tidak perlu menambahkan kondisi apapun untuk "All KB"
        End If

        sql &= " order by NoTrans"

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fg
            .Rows.Count = 1 ' Reset grid sebelum mengisi data baru

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "NoTrans") = row("NoTrans")
                    .Item(i, "TanggalPengajuan") = row("TanggalApproval")
                    .Item(i, "InvoiceNo") = row("InvoiceNo")
                    .Item(i, "TanggalNota") = row("TanggalNota")
                    .Item(i, "Pancang") = row("Pancang")
                    .Item(i, "Tujuan") = row("Bongkar")
                    .Item(i, "Trip") = row("Trip")
                    .Item(i, "Kapal") = row("Kapal")
                    .Item(i, "Jenis") = row("Jenis")
                    .Item(i, "Grade") = row("JenisKB")
                    .Item(i, "GradeSub") = row("GradeSub")
                    .Item(i, "SupplierID") = row("SupplierID")
                    .Item(i, "SupplierName") = row("SupplierName")
                    .Item(i, "RekeningName") = row("RekeningName")
                    .Item(i, "RekeningNo") = row("RekeningNo")
                    .Item(i, "RekeningBank") = row("RekeningBank")
                    .Item(i, "ItemName") = row("ItemName")
                    .Item(i, "Brutto") = row("Brutto")
                    .Item(i, "TarraJaring") = row("TarraJaring")
                    .Item(i, "Netto1") = row("Netto1")
                    .Item(i, "Tarra%") = row("TarraPersen")
                    .Item(i, "Netto2") = row("Netto2")
                    .Item(i, "HargaAwal") = row("HargaAwal")
                    .Item(i, "HargaNego") = row("HargaNego")
                    .Item(i, "HargaBeli") = row("HargaBeli")
                    .Item(i, "TotalRPBeforePPH") = row("TotalRPBeforePPH")
                    .Item(i, "PPH%") = row("PPHPersen")
                    .Item(i, "Pinjaman") = row("Pinjaman")
                    .Item(i, "PPHRP") = row("PPHRP")
                    .Item(i, "TotalRP") = row("TotalRP")

                    i += 1
                Next

                fg.Rows.Insert(1)

                ' === HITUNG TOTAL DAN TARUH DI ROW INDEX 1 ===
                Dim totalBrutto As Decimal = 0
                Dim totalTarraJaring As Decimal = 0
                Dim totalNetto1 As Decimal = 0
                Dim totalNetto2 As Decimal = 0
                Dim totalRPBeforePPH As Decimal = 0
                Dim totalPPHRP As Decimal = 0
                Dim totalRP As Decimal = 0
                Dim totalPinjaman As Decimal = 0

                For r As Integer = 1 To fg.Rows.Count - 1
                    totalBrutto += Val(fg.Item(r, "Brutto"))
                    totalTarraJaring += Val(fg.Item(r, "TarraJaring"))
                    totalNetto1 += Val(fg.Item(r, "Netto1"))
                    totalNetto2 += Val(fg.Item(r, "Netto2"))
                    totalRPBeforePPH += Val(fg.Item(r, "TotalRPBeforePPH"))
                    totalPPHRP += Val(fg.Item(r, "PPHRP"))
                    totalRP += Val(fg.Item(r, "TotalRP"))
                    totalPinjaman += Val(fg.Item(r, "Pinjaman"))
                Next

                ' === SET TOTAL DI ROW INDEX 1 ===
                fg.Item(1, "InvoiceNo") = "TOTAL"
                fg.Item(1, "Brutto") = totalBrutto
                fg.Item(1, "TarraJaring") = totalTarraJaring
                fg.Item(1, "Netto1") = totalNetto1
                fg.Item(1, "Netto2") = totalNetto2
                fg.Item(1, "TotalRPBeforePPH") = totalRPBeforePPH
                fg.Item(1, "PPHRP") = totalPPHRP
                fg.Item(1, "TotalRP") = totalRP
                fg.Item(1, "Pinjaman") = totalPinjaman

                ' KASIH WARNA AGAR JELAS BARIS TOTAL
                Dim s = fg.Styles.Add("TotalRow")
                s.BackColor = Color.LightYellow
                s.Font = New Font(fg.Font, FontStyle.Bold)
                fg.Rows(1).Style = s

                .AutoSizeCols()
            Else
                MsgBox("Tidak ada data.", vbInformation, AT)
            End If
        End With

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Try
            Dim xlApp As New Excel.Application
            Dim xlWorkBook As Excel.Workbook = xlApp.Workbooks.Add()
            Dim xlSheet As Excel.Worksheet = xlWorkBook.Sheets(1)

            xlApp.Visible = False

            ' === Header ===
            For c As Integer = 0 To fg.Cols.Count - 1
                xlSheet.Cells(1, c + 1) = fg.Cols(c).Caption
            Next

            ' === Data ===
            For r As Integer = 1 To fg.Rows.Count - 1
                For c As Integer = 0 To fg.Cols.Count - 1
                    xlSheet.Cells(r + 1, c + 1) = fg(r, c)
                Next
            Next

            ' === Format Otomatis ===
            xlSheet.Columns.AutoFit()

            ' === Save ===
            Dim save As New SaveFileDialog
            save.Filter = "Excel File|*.xlsx"
            save.FileName = "Rekap_Approval_Penerimaan_" & Format(Now, "yyyyMMdd")

            If save.ShowDialog() = DialogResult.OK Then
                xlWorkBook.SaveAs(save.FileName)
            End If

            xlWorkBook.Close()
            xlApp.Quit()

            MsgBox("Export berhasil!", vbInformation, "Sukses")
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error Export")
        End Try
    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg.BeforeEdit
        e.Cancel = True
    End Sub
End Class