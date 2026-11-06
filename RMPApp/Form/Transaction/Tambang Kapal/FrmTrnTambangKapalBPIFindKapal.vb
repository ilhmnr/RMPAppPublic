Imports C1.Win.C1FlexGrid
Imports Microsoft.Office.Interop

Public Class FrmTrnTambangKapalBPIFindKapal
    Private Sub FrmMonApprovalPenerimaan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' set tanggal kemaren
        dtpTanggalNota1.Value = Now
        dtpTanggalNota2.Value = Now

        ' Set ComboBox
        Modul_RMP.Combo.SetPancang(cboPancang)
        cboPancang.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboPancang.AutoCompleteSource = AutoCompleteSource.ListItems
        Modul_RMP.Combo.SetKapal(cboKapal)
        cboKapal.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboKapal.AutoCompleteSource = AutoCompleteSource.ListItems

        Call ClsFlexGrid.ApplyStyle(fg)

        Call ShowData()
    End Sub

    Private Sub FrmMonApprovalPenerimaan_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        lblJudulForm.Left = (Me.Width \ 2) - (lblJudulForm.Width \ 2)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Call ShowData()
    End Sub

    Private Sub ShowData()
        Me.Cursor = Cursors.WaitCursor

        Dim dt As New DataTable
        Dim i As Integer = 1
        Dim sql As String = "SELECT * FROM fnTrnTambangKapalFindKapal ('" & Format(dtpTanggalNota1.Value, "yyyy-MM-dd") & "','" & Format(dtpTanggalNota2.Value, "yyyy-MM-dd") & "') where 1=1 "

        If txtTrip.Text <> "" Then
            sql &= " and Trip='" & txtTrip.Text & "'"
        End If

        If cboPancang.Text <> "" Then
            sql &= " and IDPancang='" & cboPancang.SelectedValue & "'"
        End If

        If cboKapal.Text <> "" Then
            sql &= " and IDKapal='" & cboKapal.SelectedValue & "'"
        End If

        'If rdRSUP.Checked = True Then
        '    sql &= " and Bongkar='RSUP'"
        'ElseIf rdPSG.Checked = True Then
        '    sql &= " and Bongkar='PSG'"
        'ElseIf rdAllTujuan.Checked = True Then
        '    ' Tidak perlu menambahkan kondisi apapun untuk "All Tujuan"
        'End If

        'If rdJambul.Checked = True Then
        '    sql &= " and Jenis='Jambul'"

        '    If chkA6.Checked = True Then
        '        sql &= " and GradeSub='A6'"
        '    Else
        '        sql &= " and GradeSub='A'"
        '    End If
        'ElseIf rdLicin.Checked = True Then
        '    sql &= " and Jenis='Licin'"

        '    If chkA6.Checked = True Then
        '        sql &= " and GradeSub='A6'"
        '    Else
        '        sql &= " and GradeSub='A'"
        '    End If
        'ElseIf rdCungkil.Checked = True Then
        '    sql &= " and Jenis='Cungkil'"
        'ElseIf rdAllJenis.Checked = True Then
        '    ' Tidak perlu menambahkan kondisi apapun untuk "All Jenis"
        'End If

        'If rdKBA.Checked = True Then
        '    sql &= " and JenisKB='KB-A'"
        'ElseIf rdKBB.Checked = True Then
        '    sql &= " and JenisKB='KB-B'"
        'ElseIf rdKC.Checked = True Then
        '    sql &= " and JenisKB='KC'"
        'ElseIf rdAllGrade.Checked = True Then
        '    ' Tidak perlu menambahkan kondisi apapun untuk "All KB"
        'End If

        sql &= " order by IDPancang,Trip asc"

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fg
            .Rows.Count = 1 ' Reset grid sebelum mengisi data baru

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "TanggalKalkulasi") = row("TanggalPenjualan")
                    .Item(i, "NoTrans") = row("NoTransPenjualan")
                    .Item(i, "Tujuan") = row("Bongkar")
                    .Item(i, "IDPancang") = row("IDPancang")
                    .Item(i, "Pancang") = row("Pancang")
                    .Item(i, "IDKapal") = row("IDKapal")
                    .Item(i, "Kapal") = row("KapalName")
                    .Item(i, "Trip") = row("Trip")
                    .Item(i, "Netto1Pabrik") = row("Kg")

                    i += 1
                Next

                .AutoSizeCols()
            Else
                MsgBox("Tidak ada data.", vbInformation, AT)
            End If
        End With

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub fg_DoubleClick(sender As Object, e As EventArgs) Handles fg.DoubleClick
        With fg
            If .Rows.Count > 1 Then
                If .Row > 0 Then
                    FrmTrnTambangKapalBPI.LoadData(.Item(.Row, "Tujuan"), .Item(.Row, "IDPancang"), .Item(.Row, "IDKapal"), .Item(.Row, "Trip"))
                    Me.Close()
                End If
            End If
        End With
    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg.BeforeEdit
        e.Cancel = True
    End Sub
End Class