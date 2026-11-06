Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmTrnPembelianNonPancangShow
    Public CallbackSub As Action(Of String)
    Private Sub FrmTrnPembuatanPenjualanFind_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ambil awal dan akhir bulan dari bulan ini
        dtpDari.Value = dtpDari.Value.AddDays(-dtpDari.Value.Day + 1)
        dtpSampai.Value = dtpSampai.Value.AddDays(-dtpSampai.Value.Day + 1).AddMonths(1).AddDays(-1)

        Call ClsFlexGrid.ApplyStyle(fg)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs)
        FrmTrnPenjualanRSUPDanPSG.Show(FrmMain.DockPanel1)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Call ShowData()
    End Sub

    Public Sub ShowData()
        Dim dt As New DataTable
        Dim i As Integer = 1
        Dim sql As String = ""

        sql &= "select * from vw_MonPembelianNonPancangHdr where cast(TglPembelian as date) between '" & Format(dtpDari.Value, "yyyy-MM-dd") & "' and '" & Format(dtpSampai.Value, "yyyy-MM-dd") & "' and NoPembelian like '%" & txtNoPembelian.Text & "%' "

        If Replace(txtNoPembelian.Text, " ", "") <> "" Then
            sql &= " and NoPembelian like '%" & txtNoPembelian.Text & "%' "
        End If

        If Replace(txtSupplier.Text, " ", "") <> "" Then
            sql &= " and Supplier like '%" & txtSupplier.Text & "%' "
        End If

        sql &= " order by TglPembelian asc"

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fg
            .Rows.Count = 1 ' Reset grid

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "NoPembelian") = row("NoPembelian")
                    .Item(i, "TglPembelian") = row("TglPembelian")
                    .Item(i, "Supplier") = row("Supplier")
                    .Item(i, "NoNPBB") = row("NoNPBB")
                    .Item(i, "NoBTB") = row("NoBTB")
                    .Item(i, "JumlahItem") = row("JumlahItem")
                    .Item(i, "TotalQnty") = row("TotalQnty")
                    .Item(i, "TotalQntyTotal") = row("TotalQntyTotal")
                    .Item(i, "TotalGrandTotal") = row("TotalGrandTotal")
                    .Item(i, "RemarkHdr") = row("RemarkHdr")
                    .Item(i, "CreatedBy") = row("CreatedBy")
                    .Item(i, "CreatedDate") = row("CreatedDate")

                    i += 1
                Next

                .AutoSizeCols()
            Else
                MsgBox("Tidak ada data.", vbInformation, AT)
            End If
        End With
    End Sub

    Private Sub FrmTrnPembuatanPenjualanFind_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        lblJudulForm.Left = (Me.Width \ 2) - (lblJudulForm.Width \ 2)
    End Sub

    Private Sub btnMonitoringProgress_Click(sender As Object, e As EventArgs)
        FrmMonProgressPembuatanPenjualan.Show(FrmMain.DockPanel1)
    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg.BeforeEdit
        e.Cancel = True
    End Sub

    Private Sub fg_DoubleClick(sender As Object, e As EventArgs) Handles fg.DoubleClick
        If fg.Row < 1 OrElse fg.Rows.Count <= 1 Then Exit Sub

        If CallbackSub IsNot Nothing Then
            CallbackSub(fg.Item(fg.Row, "NoPembelian").ToString())
        End If

        Me.DialogResult = DialogResult.OK
    End Sub
End Class