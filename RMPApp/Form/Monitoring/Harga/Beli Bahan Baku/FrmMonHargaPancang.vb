Imports System.ComponentModel
Imports C1.Win
Imports C1.Win.C1FlexGrid

Public Class FrmMonHargaPancang
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub HeaderFG()
        Dim txt As CellRange
        With fg
            .AllowEditing = True
            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular)
            .Cols.Count = 11
            .Cols.Fixed = 1
            .Styles.Fixed.BackColor = Color.FromArgb(167, 199, 252)
            .Styles.Alternate.BackColor = Color.AliceBlue
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(167, 199, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(167, 199, 252)

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 1
            '.AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True

            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).Name = "No" : .Cols(0).Width = 50
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "IDPancang" : .Cols(1).Name = "IDPancang" : .Cols(1).TextAlign = TextAlignEnum.LeftCenter : .Cols(1).AllowEditing = False : .Cols(1).AllowMerging = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Pancang" : .Cols(2).Name = "Pancang" : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).AllowEditing = False : .Cols(2).AllowMerging = False
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Periode" : .Cols(3).Name = "Periode" : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).AllowEditing = False : .Cols(3).AllowMerging = False
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Asal" : .Cols(4).Name = "Asal" : .Cols(4).TextAlign = TextAlignEnum.LeftCenter : .Cols(4).AllowEditing = False : .Cols(4).AllowMerging = False
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Grade" : .Cols(5).Name = "Grade" : .Cols(5).TextAlign = TextAlignEnum.LeftCenter : .Cols(5).AllowEditing = False : .Cols(5).AllowMerging = False
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "BahanBaku" : .Cols(6).Name = "BahanBaku" : .Cols(6).TextAlign = TextAlignEnum.LeftCenter : .Cols(6).AllowEditing = False : .Cols(6).AllowMerging = False
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Jenis Supplier" : .Cols(7).Name = "JenisSupplier" : .Cols(7).TextAlign = TextAlignEnum.LeftCenter : .Cols(7).AllowEditing = False : .Cols(7).AllowMerging = False
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Harga" : .Cols(8).Name = "Harga" : .Cols(8).Format = "#,###0" : .Cols(8).AllowMerging = True
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "CreatedBy" : .Cols(9).Name = "CreatedBy" : .Cols(9).TextAlign = TextAlignEnum.LeftCenter : .Cols(9).AllowEditing = False : .Cols(9).AllowMerging = False
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "CreatedDate" : .Cols(10).Name = "CreatedDate" : .Cols(10).TextAlign = TextAlignEnum.LeftCenter : .Cols(10).AllowEditing = False

            .AutoSizeCols()
        End With
    End Sub


    Private Sub ShowData()

        Dim i As Integer = 1
        Dim sql As String = ""
        Dim dt As DataTable = New DataTable()

        Try

            Dim sql2 As String = ""


            If chkPancang.Checked = True Then
                sql2 = Modul_RMP.Func.SetCondition(sql2, "IDPancang ='" & cmbPancang.SelectedValue.ToString & "'")
            End If


            If chkBahanBaku.Checked = True Then
                sql2 = Modul_RMP.Func.SetCondition(sql2, "KodeBahanBaku ='" & cmbGrade_KB.SelectedValue.ToString & "'")
            End If

            'If chkTanggal.Checked = True Then
            '    sql2 = Modul_RMP.Func.SetCondition(sql2, "KodeBahanBaku ='" & cmbGrade_KB.SelectedValue.ToString & "'")
            'End If

            If chkDarat.Checked Then
                sql2 = Modul_RMP.Func.SetCondition(sql2, "Asal in ('Darat') ")
            End If



            If chklaut.Checked Then
                sql2 = Modul_RMP.Func.SetCondition(sql2, "Asal in ('Laut') ")
            End If


            If chkall.Checked Then
                sql2 = Modul_RMP.Func.SetCondition(sql2, "Asal in ('Darat','Laut') ")
            End If


            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "  SELECT * from RMPApp..vwMstHargaBahanBakuPancang where harga>0   AND CONVERT(DATETIME,CONVERT(VARCHAR,Periode,103),103) BETWEEN CONVERT (DATETIME,'" & DT1.Value & "',103) AND CONVERT(DATETIME,'" & DT2.Value & "',103)  " & IIf(sql2 = "", "", " AND " & sql2) & " order by IDPAncang,asal,BahanBaku, grade,JenisSupplier ")

            If dt.Rows.Count > 0 Then
                With fg
                    Call ui.HapusGrid(1, fg)
                    For Each row As DataRow In dt.Rows
                        .AddItem(i)

                        '.Item(i, "No") = i
                        .Item(i, "IDPancang") = row.Item("IDPancang")
                        .Item(i, "Pancang") = row.Item("Pancang")
                        .Item(i, "Periode") = row.Item("Periode")
                        .Item(i, "Asal") = row.Item("Asal")
                        .Item(i, "Grade") = row.Item("Grade")
                        .Item(i, "BahanBaku") = row.Item("BahanBaku")
                        .Item(i, "JenisSupplier") = row.Item("JenisSupplier")
                        .Item(i, "Harga") = row.Item("Harga")
                        .Item(i, "CreatedBy") = row.Item("CreatedBy")
                        .Item(i, "CreatedDate") = row.Item("CreatedDate")

                        i = i + 1

                    Next
                    .AutoSizeCols()
                End With


                fg.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free
                ' Specify the column on which merging is allowed
                fg.Cols(1).AllowMerging = True
                fg.Cols(2).AllowMerging = True
                'GrandTotal()
            Else
                MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
            End If
        Catch EX As Exception
            MsgBox(EX.Message)
        End Try
    End Sub


    Private Sub FrmMonHargaPancang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HeaderFG()
        DT1.Value = Format(Now, "01/MM/yy")
        DT2.Value = Format(Now, "dd/MM/yy")
        Modul_RMP.Combo.SetPancang(cmbPancang)
        Combo.SetJenisByKDJenis(cmbGrade_KB)
        chkall.Checked = True
    End Sub


    Private Sub cmbGrade_KB_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbGrade_KB.KeyUp
        UI.AutoCompleteCombo_KeyUp(cmbGrade_KB, e)
    End Sub

    Private Sub cmbPancang_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbPancang.KeyUp
        UI.AutoCompleteCombo_KeyUp(cmbPancang, e)
    End Sub

    Private Sub cmbPancang_Validated(sender As Object, e As EventArgs) Handles cmbPancang.Validated
        chkPancang.Checked = IIf(cmbPancang.Text = "", False, True)
    End Sub

    Private Sub btnrefresh_Click(sender As Object, e As EventArgs) Handles btnrefresh.Click
        ShowData()
    End Sub

    Private Sub cmbGrade_KB_Validated(sender As Object, e As EventArgs) Handles cmbGrade_KB.Validated
        chkBahanBaku.Checked = IIf(cmbGrade_KB.Text = "", False, True)
    End Sub

    Private Sub cmbGrade_KB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGrade_KB.SelectedIndexChanged

    End Sub

    Private Sub SplitContainer1_Panel2_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel2.Paint

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub

    Private Sub BTNEXCEL_Click(sender As Object, e As EventArgs)

    End Sub
End Class