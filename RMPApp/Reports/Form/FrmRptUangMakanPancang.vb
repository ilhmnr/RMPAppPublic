Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

Public Class FrmRptUangMakanPancang
    Public Conn As SqlConnection
    Dim _Dt As DataTable = New DataTable()
    Private Sub FrmRptUangMakanPancang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ReportViewer1.Reset()
        Me.ReportViewer1.RefreshReport()
        Call ReportShow()
    End Sub
    Private Sub ReportShow()
        Try

            Me.Cursor = Cursors.WaitCursor
            Dim ReportName, Ds, SQL, SQL1, SQL2, SQL3, SQL4 As String

            Dim Tgl1 As String = FrmTrnUangMakanPersonilPancang.dtpTanggal.Text
            Dim Tgl2 As String = FrmTrnUangMakanPersonilPancang.dtpTanggal2.Text
            Dim Note As String = FrmTrnUangMakanPersonilPancang.txtNote.Text
            Dim Logo As String
            If FrmTrnUangMakanPersonilPancang.rdP1.Checked = True Then
                Logo = "1"
            ElseIf FrmTrnUangMakanPersonilPancang.rdP2.Checked = True Then
                Logo = "2"
            End If

            Dim Dibuat As String = ClsSession.UserID

            Dim TransDate As String = Format(CDate(FrmTrnUangMakanPersonilPancang.dtpTransDate.Text), "dd/MMM/yyyy")



            Dim ParamList As New Generic.List(Of ReportParameter)
            Me.ReportViewer1.LocalReport.EnableExternalImages = True
            ParamList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Logo", Logo, True))
            If Note = "Input Note Print Out" Or Note = "" Then
                ParamList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Note", "-", True))
            Else
                ParamList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Note", Note, True))
            End If
            ParamList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Dibuat", Dibuat, True))
            ParamList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Tgl1", Tgl1, True))
            ParamList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Tgl2", Tgl2, True))
            ParamList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Note", Note, True))
            ParamList.Add(New Microsoft.Reporting.WinForms.ReportParameter("TransDate", TransDate, True))

            ReportName = ".rptUangMakanPancang.rdlc"
            Ds = "dtUangMakanPancang"

            If FrmTrnUangMakanPersonilPancang.chkPancang.Checked = True = True Then
                SQL1 = "And IDPancang = '" & FrmTrnUangMakanPersonilPancang.cboPancang.SelectedValue & "'"
            Else
                SQL1 = ""
            End If

            If FrmTrnUangMakanPersonilPancang.chkJabatan.Checked = True Then
                SQL2 = "And Jabatan = '" & FrmTrnUangMakanPersonilPancang.cboJabatan.Text & "'"
            Else
                SQL2 = ""
            End If

            If FrmTrnUangMakanPersonilPancang.chkStatus.Checked = True Then
                SQL3 = "And Status = '" & FrmTrnUangMakanPersonilPancang.cboStatus.Text & "'"
            Else
                SQL3 = ""
            End If

            If FrmTrnUangMakanPersonilPancang.rdP1.Checked = True Then
                SQL = "SELECT IDPersonil, Bagian, Nama, Nik, Jabatan, Status, IM, IDPancang, Pancang, UangMakan, Count(Kehadiran) AS TotalHK FROM vwAndroidAbsensiPCG_ WHERE Bagian = 'P1' AND CONVERT(DATETIME,CONVERT(VARCHAR, JamMasuk,103),103) BETWEEN CONVERT (DATETIME,'" & FrmTrnUangMakanPersonilPancang.dtpTanggal.Value & "',103) AND CONVERT(DATETIME,'" & FrmTrnUangMakanPersonilPancang.dtpTanggal2.Value & "',103) AND Kehadiran IN ('H','TL') " & IIf(SQL = "", "", " AND " & SQL) & " "
            ElseIf FrmTrnUangMakanPersonilPancang.rdP2.Checked = True Then
                SQL = "SELECT IDPersonil, Bagian, Nama, Nik, Jabatan, Status, IM, IDPancang, Pancang, UangMakan, Count(Kehadiran) AS TotalHK FROM vwAndroidAbsensiPCG_ WHERE Bagian = 'P2' AND CONVERT(DATETIME,CONVERT(VARCHAR, JamMasuk,103),103) BETWEEN CONVERT (DATETIME,'" & FrmTrnUangMakanPersonilPancang.dtpTanggal.Value & "',103) AND CONVERT(DATETIME,'" & FrmTrnUangMakanPersonilPancang.dtpTanggal2.Value & "',103) AND Kehadiran IN ('H','TL') " & IIf(SQL = "", "", " AND " & SQL) & " "
            End If

            SQL = SQL + SQL1 + SQL2 + SQL3 + "GROUP BY IDPersonil, Bagian, Nama, Nik, Jabatan, Status, IM, IDPancang, Pancang, UangMakan ORDER BY Pancang"

            Dim Da = New SqlDataAdapter(SQL, Conn)
            Dim _Dt As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, SQL)
            Dim DSource = New ReportDataSource(Ds, _Dt)

            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ReportName
            Me.ReportViewer1.LocalReport.SetParameters(ParamList)
            Me.ReportViewer1.LocalReport.DataSources.Add(DSource)
            Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)

            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            Me.Cursor = Cursors.Arrow
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load

    End Sub
End Class