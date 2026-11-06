Public Class FrmDlgItemAvailable
    Implements ILookupDialog

    Public Property SourceFg As Object Implements ILookupDialog.SourceFg
    Public Property ExcludeColumn As String = "" Implements ILookupDialog.ExcludeColumn
    Public Property AutoClose As Boolean = False Implements ILookupDialog.AutoClose
    Public Property ExcludeItemID As New List(Of String)

    Public TglTransaksi As DateTime
    Public WHSID As Integer

    Public Delegate Sub ItemSelectedEventHandler(data As Dictionary(Of String, String))
    Public Event ItemSelected As ILookupDialog.ItemSelectedEventHandler Implements ILookupDialog.ItemSelected

    Private Sub FrmDlgItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call ClsFlexGrid.ApplyStyle(fg)
        Call ClsFlexGrid.SetNumberFormat(fg, "N0", "QntyAvailable")
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadItems()
    End Sub

    Public Sub LoadItems() Implements ILookupDialog.LoadItems
        ExcludeItemID.Clear()
        If SourceFg IsNot Nothing AndAlso ExcludeColumn <> "" Then
            ExcludeItemID = Clsfg.CollectColumnValues(SourceFg, ExcludeColumn)
        End If

        Dim i = 1
        Dim sql As String = "SELECT * FROM DBPancang..INV_fnStockAvailableOnDate('" & Format(TglTransaksi, "yyyy-MM-dd") & "') WHERE WHSID='" & WHSID & "' AND QntyAvailable > 0 and CategoryID=01"

        If ExcludeItemID.Count > 0 Then
            sql &= " AND ItemID NOT IN ('" & String.Join("','", ExcludeItemID) & "')"
        End If

        If txtItem.Text.Trim <> "" Then
            sql &= " AND (ItemID LIKE '%" & txtItem.Text & "%'
                     OR ItemName LIKE '%" & txtItem.Text & "%')"
        End If

        sql &= " ORDER BY ItemName"

        Dim dt As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        fg.Rows.Count = 1

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                fg.AddItem("")

                Dim r As Integer = fg.Rows.Count - 1

                fg(r, "No") = i
                fg(r, "ItemID") = row("ItemID")
                fg(r, "ItemName") = row("ItemName")
                fg(r, "QntyAvailable") = CDec(row("QntyAvailable"))

                i += 1
            Next

            fg.AutoSizeCols()
        Else
            MsgBox("Tidak ada data item tersedia.", MsgBoxStyle.Information, "Informasi")
        End If
    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As C1.Win.C1FlexGrid.RowColEventArgs) Handles fg.BeforeEdit
        e.Cancel = True
    End Sub

    Private Sub fg_DoubleClick(sender As Object, e As EventArgs) Handles fg.DoubleClick
        If fg.Row < 1 OrElse fg.Rows.Count <= 1 Then Exit Sub

        Dim data As New Dictionary(Of String, String)
        Dim selectedRow = fg.Rows(fg.Row)
        For Each col As C1.Win.C1FlexGrid.Column In fg.Cols
            If col.Name <> "" Then
                Dim val = selectedRow(col.Name)
                data(col.Name) = If(val Is Nothing, "", val.ToString())
            End If
        Next

        fg.RemoveItem(fg.Row)

        For i = 1 To fg.Rows.Count - 1
            fg(i, "No") = i
        Next

        RaiseEvent ItemSelected(data)

        If AutoClose Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

End Class