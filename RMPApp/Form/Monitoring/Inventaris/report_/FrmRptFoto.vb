Imports Microsoft.Reporting.WinForms
Imports System.Data.SqlClient

Public Class FrmRptFoto
    Public Foto As String
    Private Sub FrmRptFoto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ReportViewer1.RefreshReport()
        Call ReportShow()
    End Sub

    Private Sub ReportShow()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim ReportName As String
            Dim LinkFoto As String = "http://192.168.12.168:5006/api/file/uploadNew?subfolder=notapancangapi/ImagesStockTransaksi&filename=" & Foto & ".jpg&flag=notapancang"
            Dim ParamList As New Generic.List(Of ReportParameter)
            ParamList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Foto", LinkFoto, True))

            ReportName = ".FrmRptFotoNotaPembelianBarangCash.rdlc"

            Me.ReportViewer1.LocalReport.EnableExternalImages = True
            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ReportName
            Me.ReportViewer1.LocalReport.SetParameters(ParamList)
            Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            Me.ReportViewer1.RefreshReport()

        Catch ex As Exception
            Me.Cursor = Cursors.Arrow
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub
End Class