Imports C1.Win.C1FlexGrid

Public Class FrmTrnPengajuanPenerimaanNotaInputFindNota
    Private Sub FrmMonApprovalPenerimaan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' set tanggal kemaren
        dtpTanggalNota1.Value = Date.Now.AddDays(-1)
        dtpTanggalNota2.Value = Date.Now.AddDays(-1)

        ' Set ComboBox
        If ClsSession.RoleName = "ADMIN NOTA" Then
            Modul_RMP.Combo.PancangByGroup(cboPancang, ClsSession.UserID)
        Else
            Modul_RMP.Combo.SetPancang(cboPancang)
        End If
        Modul_RMP.Combo.SetKapal(cboKapal)

        Call ClsFlexGrid.ApplyStyle(fg)

        Call ShowData()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Call ShowData()
    End Sub

    Private Sub ShowData()
        Me.Cursor = Cursors.WaitCursor

        Dim dt As New DataTable
        Dim i As Integer = 1
        Dim sql As String = "SELECT * FROM fnTrnApprovalPenerimaanFindKapal ('" & Format(dtpTanggalNota1.Value, "yyyy-MM-dd") & "','" & Format(dtpTanggalNota2.Value, "yyyy-MM-dd") & "') as a 
                                where a.JumlahBelumTerimaBPI <> 0 "

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
            sql &= " and a.Bongkar='RSUP'"
        ElseIf rdPSG.Checked = True Then
            sql &= " and a.Bongkar='PSG'"
        End If

        If ClsSession.RoleName = "ADMIN NOTA" Then
            sql &= " and EXISTS (
					    SELECT 1 FROM tblUtlPancangGroup pg
						INNER JOIN tblUtlUserPancangGroup upg ON upg.GroupID = pg.GroupID
						WHERE pg.IDPancang = a.IDPancang AND upg.UserID = '" & ClsSession.UserID & "'
					)"
        End If

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

        sql &= " order by a.IDPancang,a.Trip asc"

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
                    .Item(i, "TanggalAwalNota") = row("TanggalAwalNota")
                    .Item(i, "TanggalAkhirNota") = row("TanggalAkhirNota")
                    .Item(i, "JumlahNota") = row("JumlahNota")
                    .Item(i, "JumlahNotaBelumTerimaBPI") = row("JumlahBelumTerimaBPI")
                    .Item(i, "JumlahNotaSudahTerimaBPI") = row("JumlahSudahTerimaBPI")

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
        With fg
            If .Rows.Count > 1 Then
                If .Row > 0 Then
                    FrmTrnPengajuanPenerimaanNotaInput.dtpTanggalNota1.Value = .Item(.Row, "TanggalAwalNota")
                    FrmTrnPengajuanPenerimaanNotaInput.dtpTanggalNota2.Value = .Item(.Row, "TanggalAkhirNota")
                    FrmTrnPengajuanPenerimaanNotaInput.cboKapal.SelectedValue = .Item(.Row, "IDKapal")
                    FrmTrnPengajuanPenerimaanNotaInput.txtTrip.Text = If(IsDBNull(.Item(.Row, "Trip")), "", .Item(.Row, "Trip").ToString())
                    FrmTrnPengajuanPenerimaanNotaInput.cboPancang.SelectedValue = .Item(.Row, "IDPancang")
                    Select Case .Item(.Row, "Tujuan")
                        Case "RSUP"
                            FrmTrnPengajuanPenerimaanNotaInput.rdRSUP.Checked = True
                        Case "PSG"
                            FrmTrnPengajuanPenerimaanNotaInput.rdPSG.Checked = True
                        Case ""
                            FrmTrnPengajuanPenerimaanNotaInput.rdAllTujuan.Checked = True
                    End Select
                    'Select Case .Item(.Row, "Jenis")
                    '    Case "Jambul"
                    '        FrmTrnApprovalPenerimaan.rdJambul.Checked = True
                    '    Case "Licin"
                    '        FrmTrnApprovalPenerimaan.rdLicin.Checked = True
                    '    Case "Cungkil"
                    '        FrmTrnApprovalPenerimaan.rdCungkil.Checked = True
                    'End Select
                    'Select Case .Item(.Row, "Grade")
                    '    Case "KB-A"
                    '        FrmTrnApprovalPenerimaan.rdKBA.Checked = True
                    '    Case "KB-B"
                    '        FrmTrnApprovalPenerimaan.rdKBB.Checked = True
                    '    Case "KC"
                    '        FrmTrnApprovalPenerimaan.rdKC.Checked = True
                    'End Select
                    'If .Item(.Row, "GradeSub") = "A6" Then
                    '    FrmTrnApprovalPenerimaan.chkA6.Checked = True
                    'Else
                    '    FrmTrnApprovalPenerimaan.chkA6.Checked = False
                    'End If
                    FrmTrnPengajuanPenerimaanNotaInput.LoadData()
                    Me.Close()
                End If
            End If
        End With


    End Sub

#Region "Fg"
    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs)
        e.Cancel = True
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
#End Region
End Class