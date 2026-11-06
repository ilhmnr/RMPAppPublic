
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports ClosedXML.Excel
Public Class FrmMonPercentagePancang
    Dim dt As DataTable = New DataTable()
    Dim Bergerak As Integer
    Dim Teks As String
    Public images As String
    Dim cmds As SqlCommand

    Private Sub FrmMonPemasukanKelapaPCG_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dtp1.Value = Format(Now, "dd/MM/yy")
        dtp2.Value = Format(Now, "dd/MM/yy")
        dtpUm1.Value = Format(Now, "dd/MM/yy")
        dtpUm2.Value = Format(Now, "dd/MM/yy")


        Modul_RMP.Combo.SetPancang(cmbPancang)

        fg.Rows.Count=2
        Call HeaderFG()
        Call search()

    End Sub
    Private Sub search()
        With scp1
            .SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
            .SearchDelay = 2
            .Watermark = "Cari Disini"
            .SetC1FlexGridSearchPanel(fg, scp1)
        End With
    End Sub
    Public Sub HeaderFG()
        Dim txt As CellRange
        With fg
            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
            .Cols.Count = 17
            '.Cols.Fixed = 3
            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 2
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 0, 1, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 90 : .Cols(0).AllowMerging = True
            txt = .GetCellRange(0, 1, 1, 1) : txt.Data = "ID Pancang" : .Cols(1).Name = "IDPancang" : .Cols(1).Visible = False : .Cols(1).TextAlign = TextAlignEnum.CenterCenter : .Cols(1).AllowMerging = True
            txt = .GetCellRange(0, 2, 1, 2) : txt.Data = "Pancang" : .Cols(2).Name = "Pancang" : .Cols(2).TextAlign = TextAlignEnum.CenterCenter : .Cols(2).AllowMerging = True

            txt = .GetCellRange(0, 3, 1, 3) : txt.Data = "ID Relasi" : .Cols(3).Name = "IDRelasi" : .Cols(3).TextAlign = TextAlignEnum.CenterCenter : .Cols(3).AllowMerging = True
            txt = .GetCellRange(0, 4, 1, 4) : txt.Data = "Nama" : .Cols(4).Name = "NamaRelasi" :: .Cols(4).TextAlign = TextAlignEnum.LeftCenter : .Cols(4).AllowMerging = True

            txt = .GetCellRange(0, 5, 1, 5) : txt.Data = "ID Petani" : .Cols(5).Name = "IDSubPetani" : .Cols(5).TextAlign = TextAlignEnum.CenterCenter : .Cols(5).AllowMerging = True
            txt = .GetCellRange(0, 6, 1, 6) : txt.Data = "Nama" : .Cols(6).Name = "SubPetani" : .Cols(6).TextAlign = TextAlignEnum.LeftCenter : .Cols(6).AllowMerging = True

            txt = .GetCellRange(0, 7, 1, 7) : txt.Data = "Toke/Kontan" : .Cols(7).Name = "TokeKontan" : .Cols(7).TextAlign = TextAlignEnum.CenterCenter : .Cols(7).AllowMerging = True
            txt = .GetCellRange(0, 8, 1, 8) : txt.Data = "Keterangan" : .Cols(8).Name = "Keterangan" : .Cols(8).TextAlign = TextAlignEnum.LeftCenter : .Cols(8).AllowMerging = True

            txt = .GetCellRange(0, 9, 1, 9) : txt.Data = "Rekening" : .Cols(9).Name = "Rekening" : .Cols(9).TextAlign = TextAlignEnum.LeftCenter : .Cols(9).AllowMerging = True

            txt = .GetCellRange(0, 10, 1, 10) : txt.Data = "Jumlah Nota" : .Cols(10).Name = "JumlahNota" : .Cols(10).Format = "#,###0" : .Cols(10).TextAlign = TextAlignEnum.RightCenter : .Cols(10).AllowMerging = True
            txt = .GetCellRange(0, 11, 1, 11) : txt.Data = "Total Harga" : .Cols(11).Name = "TotalHarga" : .Cols(11).Format = "#,###0" : .Cols(11).TextAlign = TextAlignEnum.RightCenter : .Cols(11).AllowMerging = True
            txt = .GetCellRange(0, 12, 1, 12) : txt.Data = "No Rekening" : .Cols(12).Name = "NoRekening" : .Cols(12).Visible = False : .Cols(12).Format = "#,###0" : .Cols(12).TextAlign = TextAlignEnum.RightCenter : .Cols(12).AllowMerging = True
            txt = .GetCellRange(0, 13, 1, 13) : txt.Data = "Total Nota Pancang" : .Cols(13).Name = "TotalNotaPancang" : .Cols(13).Visible = False : .Cols(13).Format = "#,###0" : .Cols(13).TextAlign = TextAlignEnum.RightCenter : .Cols(13).AllowMerging = True
            txt = .GetCellRange(0, 14, 1, 14) : txt.Data = "TotalHargaPancang" : .Cols(14).Name = "TotalHargaPancang" : .Cols(14).Visible = False : .Cols(14).Format = "#,###0" : .Cols(14).TextAlign = TextAlignEnum.RightCenter : .Cols(14).AllowMerging = True
            txt = .GetCellRange(0, 15, 1, 15) : txt.Data = "(%) Nota" : .Cols(15).Name = "PersenNota" : .Cols(15).Format = "0.0%" : .Cols(15).TextAlign = TextAlignEnum.RightCenter : .Cols(15).AllowMerging = True
            txt = .GetCellRange(0, 16, 1, 16) : txt.Data = "(%) Total" : .Cols(16).Name = "PersenTotal" : .Cols(16).Format = "#,###.0%" : .Cols(16).TextAlign = TextAlignEnum.RightCenter : .Cols(16).AllowMerging = True

            .AutoSizeCols()
        End With
    End Sub

    Private Sub ShowData()
        fg.Cols.Fixed = 1
        Dim i As Integer = 2
        Dim sql As String = ""
        Dim query As String = ""

        Dim sql2 As String = ""


        If chkPancang.Checked = True Then
            sql = Modul_RMP.Func.SetCondition(sql, "IDPancang ='" & cmbPancang.SelectedValue.ToString & "'")
        End If

        If chkUmDate.Checked = True Then
            query = "select *,jumlahnota,totalnotapancang from fnmonpersentaserekeningByUM('" & Format(dtpUm1.Value, "yyyy-MM-dd") & "',' " & Format(dtpUm2.Value, "yyyy-MM-dd") & "' ) "
        Else
            query = "select *,jumlahnota,totalnotapancang from fnmonpersentaserekeningByTransDate('" & Format(dtp1.Value, "yyyy-MM-dd") & "',' " & Format(dtp2.Value, "yyyy-MM-dd") & "' ) "

        End If

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, query)

        If dt.Rows.Count > 0 Then
            With fg
                fg.Rows.Count=2
                For Each row As DataRow In dt.Rows
                    .AddItem(i - 1)
                    .Item(i, "IDPancang") = row.Item("IDPancang")
                    .Item(i, "Pancang") = row.Item("Pancang") 'IIf(IsDBNull(row.Item("Trip")), "", row.Item("Trip"))

                    .Item(i, "IDRelasi") = row.Item("IDRelasi")
                    .Item(i, "NamaRelasi") = row.Item("NamaRelasi")
                    .Item(i, "IDSubPetani") = row.Item("IDSubPetani")
                    .Item(i, "SubPetani") = row.Item("SubPetani")

                    .Item(i, "TokeKontan") = row.Item("Pembayaran")
                    .Item(i, "Keterangan") = row.Item("Keterangan")

                    .Item(i, "Rekening") = row.Item("RekeningPenerima")
                    .Item(i, "JumlahNota") = row.Item("JumlahNota")
                    .Item(i, "TotalHarga") = row.Item("TotalHarga")
                    .Item(i, "TotalNotaPancang") = row.Item("TotalNotaPancang")
                    .Item(i, "TotalHargaPancang") = row.Item("TotalHargaPancang")
                    .Item(i, "PersenNota") = row.Item("JumlahNota") / row.Item("TotalNotaPancang")
                    .Item(i, "PersenTotal") = row.Item("TotalHarga") / row.Item("TotalHargaPancang")

                    i = i + 1
                Next
                .AutoSizeCols()
            End With
            GrandTotal()
            fg.Cols.Fixed = 3
        Else
            fg.Rows.Count=2
            MsgBox("No Data", MsgBoxStyle.Exclamation, AT)

        End If
    End Sub

    Private Sub GrandTotal()
        With fg
            .Tree.Column = 0
            .Tree.Style = TreeStyleFlags.CompleteLeaf

            .Subtotal(AggregateEnum.Clear)

            .Subtotal(AggregateEnum.Sum, -1, -1, 10, "Grand Total")
            .Subtotal(AggregateEnum.Sum, 1, 1, 10, "Total")
            .Subtotal(AggregateEnum.Sum, -1, -1, 11)
            .Subtotal(AggregateEnum.Sum, 1, 1, 11)

            .AutoSizeCols()
        End With

    End Sub

    Private Sub fg_AfterSelChange(sender As Object, e As RangeEventArgs) Handles fg.AfterSelChange
        Dim sum As Double
        Dim R, c As Integer
        With fg
            If .Row = 0 Then Exit Sub
            If .RowSel > .Row Then
                For R = .Row To .RowSel
                    If (R > 0) And (R <= (.Rows.Count - 1)) Then
                        For c = .Col To .ColSel
                            Select Case c
                                Case 10, 11
                                    If Trim(.Item(R, c) <> 0) Then
                                        sum = sum + CDbl(.Item(R, c))
                                    End If
                            End Select
                        Next
                    End If
                Next
            End If
        End With
        txtSum.Text = FormatNumber(sum, 0)
    End Sub

    Private Sub chkPancang_CheckedChanged(sender As Object, e As EventArgs) Handles chkPancang.CheckedChanged
        Call UI.ChkCondCmb(chkPancang, cmbPancang, "Pancang")
    End Sub

    Private Sub cmbPancang_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbPancang.KeyUp
        UI.AutoCompleteCombo_KeyUp(cmbPancang, e)
    End Sub

    Private Sub cmbPancang_Validating(sender As Object, e As CancelEventArgs) Handles cmbPancang.Validating
        If cmbPancang.Text = "" Then
            Exit Sub
        End If

        If IsNothing(cmbPancang.SelectedValue) Then
            MsgBox("Pilihan tidak ada !", vbExclamation, AT)
            cmbPancang.Text = ""
            cmbPancang.Focus()
        End If
    End Sub

    Private Function GetTotalcashBack(ByVal IDRelasi As String, ByVal Fac As String) As Double
        Dim dt As DataTable = New DataTable()
        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select sum(CashBack) AS GetTotalcashBack from vwmoncashback where IDRelasi = '" & IDRelasi & "' and perusahaan_id ='" & Fac & "' and (sudahdiajukanum=0 or sudahdiajukanum is null)")
        If IsDBNull(dt.Rows(0).Item("GetTotalcashBack")) Then
            GetTotalcashBack = 0
        Else
            GetTotalcashBack = dt.Rows(0).Item("GetTotalcashBack")
        End If


        Return GetTotalcashBack
    End Function

    Private Sub btnrefreshh_Click(sender As Object, e As EventArgs) Handles btnrefreshh.Click
        ShowData()
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click

    End Sub

    Private Sub fg_BeforeAutosizeRow(sender As Object, e As RowColEventArgs) Handles fg.BeforeAutosizeRow

    End Sub
End Class


