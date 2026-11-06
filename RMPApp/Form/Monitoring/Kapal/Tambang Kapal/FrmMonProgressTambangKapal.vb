Imports C1.Win.C1FlexGrid
Imports Microsoft.Office.Interop

Public Class FrmMonProgressTambangKapal
    Private Sub FrmMonApprovalPenerimaan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' set dtpMuat1 dan dtpMuat2 ke tanggal awal dan akhir bulan ini
        dtpMuat1.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
        dtpMuat2.Value = dtpMuat1.Value.AddMonths(1).AddDays(-1)

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
        Dim sql As String = "select DetailID,MuatDate,Bongkar,Trip,IDPancang,(cast(IDPancang as varchar)+'. '+Pancang) as Pancang,IDKapal,(cast(IDKapal as varchar)+'. '+KapalName) as Kapal,NoTransPenjualan,StatusPenjualanHabis from RMPApp..fnGetProgressTambangKapal('" & Format(dtpMuat1.Value, "yyyy-MM-dd") & "','" & Format(dtpMuat2.Value, "yyyy-MM-dd") & "') where 1=1"

        If rdBelumInput.Checked = True Then
            sql &= " and SudahInputTambang=0"
        ElseIf rdSudahInput.Checked = True Then
            sql &= " and SudahInputTambang=1"
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
        ElseIf rdAllTujuan.Checked = True Then
            ' Tidak perlu menambahkan kondisi apapun untuk "All Tujuan"
        End If

        If rdJambul.Checked = True Then
            sql &= " and Jenis='Jambul'"
        ElseIf rdLicin.Checked = True Then
            sql &= " and Jenis='Licin'"
        ElseIf rdCungkil.Checked = True Then
            sql &= " and Jenis='Cungkil'"
        ElseIf rdAllJenis.Checked = True Then
            ' Tidak perlu menambahkan kondisi apapun untuk "All Jenis"
        End If

        sql &= " order by DetailID asc"

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fg
            .Rows.Count = 1 ' Reset grid sebelum mengisi data baru

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "DetailID") = row("DetailID")
                    .Item(i, "MuatDate") = row("MuatDate")
                    .Item(i, "Tujuan") = row("Bongkar")
                    .Item(i, "Trip") = row("Trip")
                    .Item(i, "Pancang") = row("Pancang")
                    .Item(i, "Kapal") = row("Kapal")
                    .Item(i, "SudahJualHabis") = row("StatusPenjualanHabis")

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