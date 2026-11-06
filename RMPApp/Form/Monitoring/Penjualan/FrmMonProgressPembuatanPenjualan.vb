Imports C1.Win.C1FlexGrid
Imports Microsoft.Office.Interop

Public Class FrmMonProgressPembuatanPenjualan
    Private Sub FrmMonApprovalPenerimaan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set ComboBox
        Modul_RMP.Combo.SetPancang(cboPancang)
        cboPancang.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboPancang.AutoCompleteSource = AutoCompleteSource.ListItems
        Modul_RMP.Combo.SetKapal(cboKapal)
        cboKapal.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboKapal.AutoCompleteSource = AutoCompleteSource.ListItems

        Call ClsFlexGrid.ApplyStyle(fg)
    End Sub

    Private Sub FrmMonApprovalPenerimaan_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        lblJudulForm.Left = (Me.Width \ 2) - (lblJudulForm.Width \ 2)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Me.Cursor = Cursors.WaitCursor

        Dim dt As New DataTable
        Dim i As Integer = 1
        Dim sql As String = "select * from vw_MonProgressPembuatanPenjualan where 1=1 "

        If rdBelumTerjual.Checked = True Then
            sql &= " and ((QtyAvailable = 0 and QtySell = 0) or (QtyAvailable > 0)) "
        ElseIf rdSudahTerjual.Checked = True Then
            sql &= " and QtyAvailable = 0 and QtySell > 0"
        End If

        If txtTrip.Text <> "" Then
            sql &= " and Trip='" & txtTrip.Text & "'"
        End If

        If cboPancang.Text <> "" Then
            sql &= " and IDPancang='" & cboPancang.SelectedValue & "'"
        End If

        If cboKapal.Text <> "" Then
            sql &= " and IDKapal='" & cboKapal.SelectedValue & "'"
        End If

        If rdRSUP.Checked = True Then
            sql &= " and Bongkar='RSUP'"
        ElseIf rdPSG.Checked = True Then
            sql &= " and Bongkar='PSG'"
        ElseIf rdCustomer.Checked = True Then
            sql &= " and Bongkar='SUPPLIER'"
        ElseIf rdAllTujuan.Checked = True Then
            ' Tidak perlu menambahkan kondisi apapun untuk "All Tujuan"
        End If

        If rdJambul.Checked = True Then
            sql &= " and Jenis='Jambul'"
        ElseIf rdLicin.Checked = True Then
            sql &= " and Jenis='Licin'"
        ElseIf rdCungkil.Checked = True Then
            sql &= " and Jenis='Cungkil'"
        ElseIf rdGelondong.Checked = True Then
            sql &= " and Jenis='Gelondong'"
        ElseIf rdAllJenis.Checked = True Then
            ' Tidak perlu menambahkan kondisi apapun untuk "All Jenis"
        End If

        If rdJambul.Checked = True Or rdLicin.Checked = True Then
            If chkA6.Checked = True Then
                sql &= " and GradeSub='A6'"
            ElseIf chkA6.Checked = False Then
                sql &= " and GradeSub='A'"
            End If
        End If

        If rdKBA.Checked = True Then
            sql &= " and JenisKB='KB-A'"
        ElseIf rdKBB.Checked = True Then
            sql &= " and JenisKB='KB-B'"
        ElseIf rdKC.Checked = True Then
            sql &= " and JenisKB='KC'"
        ElseIf rdGD.Checked = True Then
            sql &= " and JenisKB='GD'"
        ElseIf rdAllGrade.Checked = True Then
            ' Tidak perlu menambahkan kondisi apapun untuk "All KB"
        End If

        sql &= " order by IDPancang asc"

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fg
            .Rows.Count = 1 ' Reset grid sebelum mengisi data baru

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "Tujuan") = row("Bongkar")
                    .Item(i, "Pancang") = row("Pancang")
                    .Item(i, "Kapal") = row("KapalName")
                    .Item(i, "Trip") = row("Trip")
                    .Item(i, "Jenis") = row("Jenis")
                    .Item(i, "Grade") = row("JenisKB")
                    .Item(i, "GradeSub") = row("GradeSub")
                    .Item(i, "TanggalAwalNota") = row("TanggalAwalNota")
                    .Item(i, "TanggalAkhirNota") = row("TanggalAkhirNota")
                    .Item(i, "JumlahNota") = row("JumlahNota")
                    .Item(i, "JumlahNotaBelumTerimaBPI") = row("JumlahBelumTerimaBPI")
                    .Item(i, "JumlahNotaSudahTerimaBPI") = row("JumlahSudahTerimaBPI")
                    .Item(i, "Qty") = row("NettoPancang")
                    .Item(i, "QtyAvailable") = row("QtyAvailable")
                    .Item(i, "QtySell") = row("QtySell")

                    i += 1
                Next

                .AutoSizeCols()
            Else
                MsgBox("Tidak ada data.", vbInformation, AT)
            End If
        End With

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg.BeforeEdit
        e.Cancel = True
    End Sub
End Class