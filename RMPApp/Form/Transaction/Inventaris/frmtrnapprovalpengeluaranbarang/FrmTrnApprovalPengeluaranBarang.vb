Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmTrnApprovalPengeluaranBarang
    Dim IdDetail As Integer


    Private Sub FrmTrnApprovalPengeluaranBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Combo.SetPancang(CmbPancang)

        Call HeaderFg()
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Me.Cursor = Cursors.WaitCursor
        ShowData()
        Me.Cursor = Cursors.Default
    End Sub
    Public Sub ShowData()
        Dim dt As DataTable = New DataTable
        Dim i As Integer = 1
        Dim sql As String = ""

        sql = " select * from vwInv_ApprovalPengeluaranBarang where 1=1 "

        If RdPengajuan.Checked = True Then
            sql &= " and approval = 0 "
        ElseIf RdApproval.Checked = True Then
            sql &= " and approval = 1 "
        ElseIf RdReject.Checked = True Then
            sql &= " and approval = 2 "
        End If

        sql &= " and (cast(created_date as date) between cast('" & Format(Dtp1.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(Dtp2.Value, "yyyy-MM-dd") & "' as date)) "

        If CmbPancang.Text <> "" Then
            sql &= " and idPancang='" & CmbPancang.SelectedValue & "' "
        End If

        dt = DB.ExecuteQuery(StrConnRMPApp, sql)

        With Fg
            .Rows.Count = 1

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)

                    Dim style As C1.Win.C1FlexGrid.CellStyle = Me.Fg.Styles.Add("style")
                    style.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
                    Me.Fg.SetCellImage(i, 1, My.Resources.ButtonCari_16px)
                    Me.Fg.SetCellStyle(i, 1, style)

                    .Item(i, 2) = row.Item("Pancang")
                    .Item(i, 3) = row.Item("NamaBarang")
                    .Item(i, 4) = row.Item("qty")
                    .Item(i, 5) = row.Item("remark")
                    .Item(i, 6) = row.Item("created_by")
                    .Item(i, 7) = row.Item("created_date")
                    .Item(i, 8) = row.Item("foto_item")
                    .Item(i, 9) = row.Item("id")

                    i += 1
                Next

                .AutoSizeCols()
            Else
                MsgBox("Tidak Ada Data Di Temukan !", vbInformation, AT)
            End If

            If RdPengajuan.Checked = True Then
                .Cols(1).Visible = True
            Else
                .Cols(1).Visible = False
            End If
        End With
    End Sub

    Private Sub HeaderFg()
        Dim txt As CellRange

        With Fg
            .Cols.Count = 10
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Rows.Fixed = 1

            .Font = New System.Drawing.Font("Century Gothic", 7.0!, System.Drawing.FontStyle.Regular)
            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).TextAlign = TextAlignEnum.LeftCenter : .Cols(0).AllowEditing = False
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Detail" : .Cols(1).TextAlign = TextAlignEnum.LeftCenter : .Cols(1).AllowEditing = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Pancang" : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).AllowEditing = False
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Item" : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).AllowEditing = False
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Qty Dikeluarkan" : .Cols(4).TextAlign = TextAlignEnum.LeftCenter : .Cols(4).AllowEditing = False
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Remark" : .Cols(5).TextAlign = TextAlignEnum.LeftCenter : .Cols(5).AllowEditing = False
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Created By" : .Cols(6).TextAlign = TextAlignEnum.LeftCenter : .Cols(6).AllowEditing = False
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Created" : .Cols(7).TextAlign = TextAlignEnum.LeftCenter : .Cols(7).AllowEditing = False
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Nama Foto" : .Cols(8).Visible = False
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Id Detail" : .Cols(9).Visible = False

            .AutoSizeCols()
        End With
    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        If Fg.Rows.Count > 1 Then
            With FrmTrnApprovalPengeluaranBarangDialog
                .Id = Fg.Item(Fg.RowSel, 9)
                .Foto = Fg.Item(Fg.RowSel, 8)
                .TxtPancang.Text = Fg.Item(Fg.RowSel, 2)
                .TxtNamaBarang.Text = Fg.Item(Fg.RowSel, 3)
                .TxtQty.Text = Fg.Item(Fg.RowSel, 4)
                .TxtKeterangan.Text = Fg.Item(Fg.RowSel, 5)
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub RdPengajuan_CheckedChanged(sender As Object, e As EventArgs) Handles RdPengajuan.CheckedChanged, RdApproval.CheckedChanged, RdReject.CheckedChanged
        ShowData()
    End Sub
End Class