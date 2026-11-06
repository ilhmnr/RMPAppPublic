Imports C1.Win.C1FlexGrid

Public Class FrmTrnPenjualanRSUPDanPSGFindKapal
    Private Sub FrmMonApprovalPenerimaan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set ComboBox
        Modul_RMP.Combo.SetPancang(cboPancang)
        cboPancang.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboPancang.AutoCompleteSource = AutoCompleteSource.ListItems
        Modul_RMP.Combo.SetKapal(cboKapal)
        cboKapal.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboKapal.AutoCompleteSource = AutoCompleteSource.ListItems

        Call ClsFlexGrid.ApplyStyle(fg)

        'Call ShowData()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Call ShowData()
    End Sub

    Private Sub ShowData()
        Me.Cursor = Cursors.WaitCursor

        Dim dt As New DataTable
        Dim i As Integer = 1
        Dim sql As String = "select * from vw_MonProgressPembuatanPenjualan where JumlahBelumTerimaBPI=0 and QtyAvailable>0 "

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
            sql &= " and Bongkar='RELASI'"
        ElseIf rdAllTujuan.Checked = True Then
            ' Tidak perlu menambahkan kondisi apapun untuk "All Tujuan"
        End If

        If rdJambul.Checked = True Then
            sql &= " and Jenis='Jambul'"

            If chkA6.Checked = True Then
                sql &= " and GradeSub='A6'"
            Else
                sql &= " and GradeSub='A'"
            End If
        ElseIf rdLicin.Checked = True Then
            sql &= " and Jenis='Licin'"

            If chkA6.Checked = True Then
                sql &= " and GradeSub='A6'"
            Else
                sql &= " and GradeSub='A'"
            End If
        ElseIf rdCungkil.Checked = True Then
            sql &= " and Jenis='Cungkil'"
        ElseIf rdGelondong.Checked = True Then
            sql &= " and Jenis='Gelondong'"
        ElseIf rdAllJenis.Checked = True Then
            ' Tidak perlu menambahkan kondisi apapun untuk "All Jenis"
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
                    .Item(i, "IDPancang") = row("IDPancang")
                    .Item(i, "Pancang") = row("Pancang")
                    .Item(i, "IDKapal") = row("IDKapal")
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
                MsgBoxCustom.Show("Tidak ada data.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            End If
        End With

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub fg_DoubleClick(sender As Object, e As EventArgs) Handles fg.DoubleClick
        With FrmTrnPenjualanRSUPDanPSG
            If fg.Rows.Count > 1 Then
                If fg.Row > 0 Then
                    .dtpTanggalNota1.Value = fg.Item(fg.Row, "TanggalAwalNota")
                    .cboKapal.SelectedValue = fg.Item(fg.Row, "IDKapal")
                    .txtTrip.Text = fg.Item(fg.Row, "Trip")
                    .cboPancang.SelectedValue = fg.Item(fg.Row, "IDPancang")

                    Select Case fg.Item(fg.Row, "Tujuan")
                        Case "RSUP"
                            .rdRSUP.Checked = True
                        Case "PSG"
                            .rdPSG.Checked = True
                        Case "RELASI"
                            .rdCustomer.Checked = True
                    End Select
                    .Tujuan = fg.Item(fg.Row, "Tujuan")

                    Select Case fg.Item(fg.Row, "Jenis")
                        Case "Jambul"
                            .rdJambul.Checked = True
                        Case "Licin"
                            .rdLicin.Checked = True
                        Case "Cungkil"
                            .rdCungkil.Checked = True
                        Case "Gelondong"
                            .rdGelondong.Checked = True
                    End Select
                    .Jenis = fg.Item(fg.Row, "Jenis")

                    Select Case fg.Item(fg.Row, "Grade")
                        Case "KB-A"
                            .rdKBA.Checked = True
                        Case "KB-B"
                            .rdKBB.Checked = True
                        Case "KC"
                            .rdKC.Checked = True
                        Case "GD"
                            .rdGD.Checked = True
                    End Select
                    .Grade = fg.Item(fg.Row, "Grade")

                    If fg.Item(fg.Row, "GradeSub") = "A6" Then
                        .chkA6.Checked = True
                    Else
                        .chkA6.Checked = False
                    End If
                    .GradeSub = fg.Item(fg.Row, "GradeSub")

                    .LoadData()
                End If
            End If
        End With
    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg.BeforeEdit
        e.Cancel = True
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class