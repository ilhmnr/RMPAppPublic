Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmTrnPenjualanNonDataBongkarShow
    Public CallbackSub As Action(Of String)

    Private Sub FrmTrnPenjualanShow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Awal dan akhir bulan ini
        dtpDari.Value = dtpDari.Value.AddDays(-dtpDari.Value.Day + 1)
        dtpSampai.Value = dtpSampai.Value.AddDays(-dtpSampai.Value.Day + 1).AddMonths(1).AddDays(-1)

        Call ClsFlexGrid.ApplyStyle(fg)
        Call ClsFlexGrid.SetNumberFormat(fg, "N0", "TotalQnty", "TotalGrandTotal")
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ShowData()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Public Sub ShowData()
        Dim sql As String = "SELECT * FROM vw_MonPenjualanHdr
                             WHERE CAST(TglPenjualan AS DATE)
                                   BETWEEN '" & Format(dtpDari.Value, "yyyy-MM-dd") & "'
                                       AND '" & Format(dtpSampai.Value, "yyyy-MM-dd") & "'"

        If txtNoPenjualan.Text.Trim <> "" Then
            sql &= " AND NoPenjualan LIKE '%" & txtNoPenjualan.Text.Trim() & "%'"
        End If

        If txtCustomer.Text.Trim <> "" Then
            sql &= " AND Customer LIKE '%" & txtCustomer.Text.Trim() & "%'"
        End If

        sql &= " ORDER BY TglPenjualan ASC"

        Dim dt As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fg
            .Rows.Count = 1

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim i As Integer = 1
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "NoPenjualan") = row("NoPenjualan")
                    .Item(i, "TglPenjualan") = row("TglPenjualan")
                    .Item(i, "Customer") = row("Customer")
                    .Item(i, "NoSO") = row("NoSO")
                    .Item(i, "NoDO") = row("NoDO")
                    .Item(i, "NoInvoice") = row("NoInvoice")
                    .Item(i, "JumlahItem") = row("JumlahItem")
                    .Item(i, "TotalQnty") = row("TotalQnty")
                    .Item(i, "TotalGrandTotal") = row("TotalGrandTotal")
                    .Item(i, "RemarkHdr") = row("RemarkHdr")
                    .Item(i, "CreatedBy") = row("CreatedBy")
                    .Item(i, "CreatedDate") = row("CreatedDate")
                    i += 1
                Next
                .AutoSizeCols()
            Else
                MsgBoxCustom.Show("Tidak ada data.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
            End If
        End With
    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg.BeforeEdit
        e.Cancel = True
    End Sub

    Private Sub fg_DoubleClick(sender As Object, e As EventArgs) Handles fg.DoubleClick
        If fg.Row < 1 OrElse fg.Rows.Count <= 1 Then Exit Sub

        If CallbackSub IsNot Nothing Then
            CallbackSub(fg.Item(fg.Row, "NoPenjualan").ToString())
        End If

        Me.DialogResult = DialogResult.OK
    End Sub
End Class