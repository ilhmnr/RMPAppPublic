
Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Public Class FrmRptAngkutanBuahKapal
    Public Conn As SqlConnection
    Dim _Dt As DataTable = New DataTable()
    Public noinvoice As String
    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load
        Me.ReportViewer1.Reset()
        Me.ReportViewer1.RefreshReport()
        Call ReportShow(noinvoice)
    End Sub

    Public Sub ReportShow(noinvoice)
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim ReportName, Ds, sql As String
            Dim Dibuat As String = ClsSession.UserID
            Dim ParamList As New Generic.List(Of ReportParameter)
            ParamList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Dibuat", Dibuat, True))
            Dim Tujuan As String = DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"select Tujuan as GetValueString from RMPApp..tbl_RMTrnAngkutanBuahKapalHdr where Noinvoice='" & FrmTrnPremiAsuransiFind.dgvList.CurrentRow.Cells(1).Value & "'")


            ReportName = ".RptAngkutanBuahKelapa.rdlc"

                Ds = "dtangkutanbuahkapal"

            sql = " Select * from vw_RM_TrnAngkutanBuahKapalDtl where NOINVOICE='" & noinvoice & "'  "

            Dim Da = New SqlDataAdapter(sql, Conn)
            Dim _Dt As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)
            Dim DSource = New ReportDataSource(Ds, _Dt)

            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ReportName
            Me.ReportViewer1.LocalReport.DataSources.Add(DSource)
            'Me.ReportViewer1.LocalReport.SetParameters(ParamList)
            Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)

            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            Me.Cursor = Cursors.Arrow
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub FrmRptAngkutanBuahKapal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class