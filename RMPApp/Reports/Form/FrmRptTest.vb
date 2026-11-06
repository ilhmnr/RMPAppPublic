Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

Public Class FrmRptTest
	Public FileName As String
	Public FormName As String
	Dim LinkFile As String
	Dim clas As New ClsDatabaseConnection

	Private Sub FrmRptTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		If FormName = "FotoCheckin" Then
			LinkFile = UrlApiNotaPancangNew & "ImagesKapalPelangsirCheckin&filename=" & FileName & "&flag=notapancang"
		ElseIf FormName = "Nota" Then
			LinkFile = UrlApiNotaPancangNew & "ImagesNotaPancang&filename=" & FileName & ".jpg&flag=notapancang"
		End If

		PanggilReport()
	End Sub

	Sub PanggilReport()
		Dim param As New List(Of ReportParameter)
		param.Clear()
		param.Add(New ReportParameter("LinkFile", LinkFile))
		Try
			With Me.ReportViewer1
				.LocalReport.EnableExternalImages = True
				.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".rptFotoNota.rdlc"
				.LocalReport.SetParameters(param)
				'Dim newPageSetting As New System.Drawing.Printing.PageSettings
				'newPageSetting.Margins = New System.Drawing.Printing.Margins(3, 3, 3, 3)
				'newPageSetting.Landscape = True
				'ReportViewer1.SetPageSettings(newPageSetting)
				Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
				Me.ReportViewer1.RefreshReport()
				.RefreshReport()
			End With
		Catch ex As Exception
			MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try


	End Sub
End Class
