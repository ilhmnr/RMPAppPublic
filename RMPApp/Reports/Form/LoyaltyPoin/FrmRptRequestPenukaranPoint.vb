Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Public Class FrmRptRequestPenukaranPoint
    Public Conn As SqlConnection
    Dim _Dt As DataTable = New DataTable()
    Public noinvoice As String
    Private Sub FrmRptRequestPenukaranPoint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ReportViewer1.Reset()
        Me.ReportViewer1.RefreshReport()
        Call ReportShow(noinvoice)
    End Sub

    Private Sub ReportShow(noinvoice)
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim ReportName, Ds, sql As String

            ReportName = ".RptPengajuanPembayaranPoin.rdlc"
            Ds = "dtbayarpoin"
            sql = "select * from vwpengajuanpoindtl where noinvoice='" & noinvoice & "'"

            Dim Da = New SqlDataAdapter(sql, Conn)
            Dim _Dt As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)
            Dim DSource = New ReportDataSource(Ds, _Dt)

            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ReportName
            Me.ReportViewer1.LocalReport.DataSources.Add(DSource)
            Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            Me.Cursor = Cursors.Arrow
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

End Class