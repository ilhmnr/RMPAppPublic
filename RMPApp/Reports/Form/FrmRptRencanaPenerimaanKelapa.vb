Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

Public Class FrmRptRencanaPenerimaanKelapa
    Public Conn As SqlConnection
    Private Sub FrmRptRencanaPenerimaanKelapa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ReportViewer1.RefreshReport()
        PanggilReportAll()
    End Sub

    Sub PanggilReportAll()
        Try
            Modul_RMP.DB.OpenConnection(StrConnRMPApp)
            With Me.ReportViewer1.LocalReport
                .ReportEmbeddedResource = My.Application.Info.AssemblyName & ".rptRencanaPenerimaanKelapa.rdlc"
                .DataSources.Clear()
            End With
            Dim Sql As String
            Sql = "SELECT TOP 1 * FROM RMPApp..tblTrnKelapaHdr ORDER BY TRANSID DESC"

            Dim Da = New SqlDataAdapter(Sql, Conn)
            Dim Dt = New DataTable()
            Da.Fill(Dt)
            Dim Drs = New ReportDataSource("dtPromosi", Dt)
            Me.ReportViewer1.LocalReport.DataSources.Add(Drs)
            Dim newPageSetting As New System.Drawing.Printing.PageSettings
            newPageSetting.Margins = New System.Drawing.Printing.Margins(7, 7, 7, 7)
            ReportViewer1.SetPageSettings(newPageSetting)
            Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class