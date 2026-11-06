Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

Public Class FrmRptMonRekeningRelasi
    Public Conn As SqlConnection
    Dim _Dt As DataTable = New DataTable()
    Dim Print As Integer
    Private Sub FrmRptMonRekening_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ReportViewer1.Reset()
        Me.ReportViewer1.RefreshReport()
        Call ReportShow()
    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load
        Call ReportShow()
    End Sub
    Private Sub ReportShow()
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim ReportName, Ds, sql As String

            ReportName = ".rptRekeningRelasi.rdlc"
            Ds = "dtRekeningRelasi"
            sql = FrmMonRekeningRelasiPcg.txtSQL2.Text

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