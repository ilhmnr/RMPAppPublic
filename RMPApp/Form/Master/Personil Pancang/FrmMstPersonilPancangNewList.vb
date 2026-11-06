Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports C1.Win.C1FlexGrid
Imports Spire.Pdf

Public Class FrmMstPersonilPancangNewList
    Public Sub HeaderFG()
        Dim txt As CellRange
        With fg
            .AllowEditing = True
            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular)
            .Cols.Count = 32
            .Cols.Fixed = 1
            .Cols.Frozen = 5
            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 1
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "N0" : .Cols(0).Width = 50
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "ID Personil" : .Cols(1).TextAlign = TextAlignEnum.CenterCenter : .Cols(1).AllowEditing = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Bagian" : .Cols(2).TextAlign = TextAlignEnum.CenterCenter : .Cols(2).AllowEditing = False
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Nama" : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).AllowEditing = False
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "NIK" : .Cols(4).TextAlign = TextAlignEnum.CenterCenter : .Cols(4).AllowEditing = False
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Tanggal" : .Cols(5).TextAlign = TextAlignEnum.LeftCenter : .Cols(5).AllowEditing = False
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Jabatan" : .Cols(6).TextAlign = TextAlignEnum.CenterCenter : .Cols(6).AllowEditing = False
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Pancang" : .Cols(7).TextAlign = TextAlignEnum.CenterCenter : .Cols(7).AllowEditing = False
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Libur Mingguan" : .Cols(8).TextAlign = TextAlignEnum.CenterCenter : .Cols(8).AllowEditing = False
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Jam Masuk" : .Cols(9).TextAlign = TextAlignEnum.CenterCenter : .Cols(9).AllowEditing = False
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "Jam Pulang" : .Cols(10).TextAlign = TextAlignEnum.CenterCenter : .Cols(10).AllowEditing = False
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "Uang Makan" : .Cols(11).TextAlign = TextAlignEnum.CenterCenter : .Cols(11).AllowEditing = False
            txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "Not Active" : .Cols(12).TextAlign = TextAlignEnum.CenterCenter : .Cols(12).AllowEditing = False : .Cols(12).Visible = True
            txt = .GetCellRange(0, 13, 0, 13) : txt.Data = "Not Active By" : .Cols(13).TextAlign = TextAlignEnum.CenterCenter : .Cols(13).AllowEditing = False : .Cols(13).Visible = False
            txt = .GetCellRange(0, 14, 0, 14) : txt.Data = "Not Active Date" : .Cols(14).TextAlign = TextAlignEnum.CenterCenter : .Cols(14).AllowEditing = False : .Cols(14).Visible = False
            txt = .GetCellRange(0, 15, 0, 15) : txt.Data = "Created By" : .Cols(15).TextAlign = TextAlignEnum.CenterCenter : .Cols(15).AllowEditing = False
            txt = .GetCellRange(0, 16, 0, 16) : txt.Data = "Created Date" : .Cols(16).TextAlign = TextAlignEnum.CenterCenter : .Cols(16).AllowEditing = False
            txt = .GetCellRange(0, 17, 0, 17) : txt.Data = "ID Pancang" : .Cols(17).TextAlign = TextAlignEnum.CenterCenter : .Cols(17).AllowEditing = False : .Cols(17).Visible = False
            txt = .GetCellRange(0, 18, 0, 18) : txt.Data = "CV" : .Cols(18).TextAlign = TextAlignEnum.CenterCenter : .Cols(18).AllowEditing = False
            txt = .GetCellRange(0, 19, 0, 19) : txt.Data = "Pemborong" : .Cols(19).TextAlign = TextAlignEnum.CenterCenter : .Cols(19).AllowEditing = False
            txt = .GetCellRange(0, 20, 0, 20) : txt.Data = "IDPersonilPengawas1" : .Cols(20).TextAlign = TextAlignEnum.CenterCenter : .Cols(20).AllowEditing = False
            txt = .GetCellRange(0, 21, 0, 21) : txt.Data = "Pengawas1" : .Cols(21).TextAlign = TextAlignEnum.CenterCenter : .Cols(21).AllowEditing = False
            txt = .GetCellRange(0, 22, 0, 22) : txt.Data = "Status" : .Cols(22).TextAlign = TextAlignEnum.CenterCenter : .Cols(22).AllowEditing = False
            txt = .GetCellRange(0, 23, 0, 23) : txt.Data = "Tanggal Training (1)" : .Cols(23).TextAlign = TextAlignEnum.CenterCenter : .Cols(23).AllowEditing = False
            txt = .GetCellRange(0, 24, 0, 24) : txt.Data = "Tanggal Training (2)" : .Cols(24).TextAlign = TextAlignEnum.CenterCenter : .Cols(24).AllowEditing = False
            txt = .GetCellRange(0, 25, 0, 25) : txt.Data = "NoRekening" : .Cols(22).TextAlign = TextAlignEnum.CenterCenter : .Cols(22).AllowEditing = False
            txt = .GetCellRange(0, 27, 0, 27) : txt.Data = "Edit/ Pindah Pancang" : .Cols(27).ImageAlign = ImageAlignEnum.CenterCenter : .Cols(27).AllowEditing = False
            txt = .GetCellRange(0, 26, 0, 26) : txt.Data = "Tanggal Akhir" : .Cols(26).TextAlign = TextAlignEnum.LeftCenter : .Cols(26).AllowEditing = False
            txt = .GetCellRange(0, 28, 0, 28) : txt.Data = "ID" : .Cols(28).ImageAlign = ImageAlignEnum.CenterCenter : .Cols(28).AllowEditing = False : .Cols(28).Visible = False
            txt = .GetCellRange(0, 29, 0, 29) : txt.Data = "REG/FIXNO" : .Cols(29).ImageAlign = ImageAlignEnum.CenterCenter : .Cols(29).AllowEditing = False
            txt = .GetCellRange(0, 30, 0, 30) : txt.Data = "Nama Bank" : .Cols(30).ImageAlign = ImageAlignEnum.CenterCenter : .Cols(30).AllowEditing = False
            txt = .GetCellRange(0, 31, 0, 31) : txt.Data = "Nama Rekening" : .Cols(31).ImageAlign = ImageAlignEnum.CenterCenter : .Cols(31).AllowEditing = False
            .AutoSizeCols()
        End With
    End Sub
    Private Sub FrmMstPersonilPancangNewList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HeaderFG()
        chkPancang.Checked = False
        DTP1.Value = Format(Now, "yyyy-MM-dd")
        DTP2.Value = Format(Now, "yyyy-MM-dd")
        search()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        FrmMstPersonilPancangNew.Show()
        FrmMstPersonilPancangNew.Perintah = "Add"
    End Sub

    Private Sub cmbPancang_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPancang.SelectedIndexChanged
        If cmbPancang.Text = "" Then
            Exit Sub
        End If

        If IsNothing(cmbPancang.SelectedValue) Then
            MsgBox("Pilihan tidak ada !", vbExclamation, AT)
            cmbPancang.Text = ""
            cmbPancang.Focus()
        End If
    End Sub

    Private Sub cmbPancang_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbPancang.KeyUp
        UI.AutoCompleteCombo_KeyUp(cmbPancang, e)
    End Sub
    Private Sub cmbPancang_Validated(sender As Object, e As EventArgs) Handles cmbPancang.Validated
        chkPancang.Checked = IIf(cmbPancang.Text = "", False, True)
    End Sub
    Public Sub ShowData()
        Dim i As Integer = 1
        Dim sql As String = ""
        Dim dt As DataTable = New DataTable()

        Try
            If chkPancang.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "pancangID ='" & cmbPancang.SelectedValue.ToString & "'")
            End If

            If chkIDPersonil.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, " idPersonil like '%" & txtidpersonil.Text & "%' or   Nama like '%" & txtidpersonil.Text & "%' ")
            End If

            If chkTransDate.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "CONVERT(DATETIME, CONVERT(VARCHAR, Tanggal, 103),103) between CONVERT (DATETIME,'" & Format(DTP1.Value, "dd/MM/yyyy") & "',103) and CONVERT (DATETIME,'" & Format(DTP2.Value, "dd/MM/yyyy") & "',103)")
            End If

            If chkp1.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, " BAGIAN='P1' ")
            End If

            If chkp2.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "BAGIAN='P2' ")
            End If


            If CHkp3.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "BAGIAN='P3' ")
            End If


            If chkpsp.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "BAGIAN='PSP' ")
            End If

            If chkAll.Checked = True Then
                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " SELECT * FROM RMPApp..vwPersonilPCG2024 WHERE  IDPersonil Is Not Null  " & IIf(sql = "", "", " AND " & sql) & "   ORDER BY Tanggal")
            Else
                If chkNotActive.Checked = False Then
                    dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " SELECT * FROM RMPApp..vwPersonilPCG2024 WHERE (NotActive IS NULL OR NOTACTIVE=0 ) AND IDPersonil Is Not Null  " & IIf(sql = "", "", " AND " & sql) & "   ORDER BY Tanggal")
                Else
                    dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " SELECT * FROM RMPApp..vwPersonilPCG2024 WHERE (NotActive=1 ) AND IDPersonil Is Not Null  " & IIf(sql = "", "", " AND " & sql) & "   ORDER BY Tanggal")
                End If
            End If

            If dt.Rows.Count > 0 Then
                With fg
                    Call ui.HapusGrid(1, fg)
                    For Each row As DataRow In dt.Rows
                        .AddItem(i)
                        .Item(i, 1) = row.Item("IDPersonil")
                        .Item(i, 2) = row.Item("Bagian")
                        .Item(i, 3) = row.Item("Nama")
                        .Item(i, 4) = row.Item("NIK")
                        .Item(i, 5) = row.Item("Tanggal")
                        .Item(i, 6) = row.Item("Jabatan")
                        .Item(i, 7) = row.Item("Pancang")
                        .Item(i, 8) = row.Item("IM")
                        .Item(i, 9) = row.Item("JamMasuk")
                        .Item(i, 10) = row.Item("JamPulang")
                        .Item(i, 11) = row.Item("UangMakan")
                        .Item(i, 12) = row.Item("NotActive")
                        .Item(i, 13) = row.Item("NotActiveBy")
                        .Item(i, 14) = row.Item("NotActiveDate")
                        .Item(i, 15) = row.Item("CreatedBy")
                        .Item(i, 16) = row.Item("CreatedDate")
                        .Item(i, 17) = row.Item("IDPancang")
                        .Item(i, 18) = row.Item("CV")
                        .Item(i, 19) = row.Item("Pemborong")
                        .Item(i, 20) = row.Item("IDPersonilPengawas1")
                        .Item(i, 21) = row.Item("Pengawas1")
                        .Item(i, 22) = row.Item("Status")
                        .Item(i, 23) = row.Item("TDate1")
                        .Item(i, 24) = row.Item("TDate2")
                        .Item(i, 25) = row.Item("NoRekening")
                        .Item(i, 28) = row.Item("ID")
                        .Item(i, 26) = row.Item("TanggalAkhir")
                        .Item(i, 29) = row.Item("RegFixNo")
                        .Item(i, 30) = row.Item("Bank")
                        .Item(i, 31) = row.Item("NamaRek")

                        Me.fg.SetCellImage(i, 27, My.Resources.icons8_edit_20)

                        If Val(row.Item("NotActive")) = True Then
                            .Rows(i).StyleNew.BackColor = Color.LavenderBlush
                        End If


                        i = i + 1
                    Next
                    .AutoSizeCols()
                End With
            Else
                MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
            End If
        Catch EX As Exception
            MsgBox(EX.Message)
        End Try
    End Sub

    Private Sub btnrefreshh_Click(sender As Object, e As EventArgs) Handles btnrefreshh.Click
        ShowData()
    End Sub

    Private Sub search()
        With schfg
            .SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
            .SearchDelay = 2
            .Watermark = "Cari Disini"
            .SetC1FlexGridSearchPanel(fg, schfg)
        End With
    End Sub

    Private Sub fg_DoubleClick(sender As Object, e As EventArgs) Handles fg.DoubleClick
        Select Case fg.Col
            Case 27
                With FrmMstPersonilPancangnEW
                    .Show()
                    .loaddataFind(fg.Item(fg.Row, 28))
                    .cmdEnabled(False)
                    .Perintah = "Edit"
                    '.dtp1.Enabled = False
                    '.dtp2.Enabled = False
                    .btnsave.Visible = True
                    .btnexit.Enabled = True
                    .cboPancang.Enabled = False
                End With
        End Select
    End Sub

    Private Sub chkp2_CheckedChanged(sender As Object, e As EventArgs) Handles chkp2.CheckedChanged
        If chkp2.Checked = True Then
            chkp1.Checked = False
        End If
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click

    End Sub
End Class