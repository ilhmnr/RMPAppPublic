Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

Public Class FrmRptInvoicePembayaranKelapa
    Dim cls As New ClsDatabaseConnection
    Dim Conn As SqlConnection = New SqlConnection(StrConnRMPApp)
    Private Sub FrmRptInvoicePembayaranKelapa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ReportViewer.Reset()
        Me.ReportViewer.RefreshReport()
        Call ReportShow()
    End Sub
    Sub ReportShow()
        'Try
        ReportViewer.Clear()
            ReportViewer.LocalReport.DataSources.Clear()
            Dim a As Integer
            a = FrmTrnInvoicePembayaranKelapa.dgvlist.CurrentRow.Index
        Dim Tanggal As String = Format(FrmTrnInvoicePembayaranKelapa.dtInput.Value, "dd/MM/yyyy")
        Dim NoInvoice As String = FrmTrnInvoicePembayaranKelapa.txtNoInvoice.Text
        'Dim Kapal, Kapasitas, Trip, Pancang, Muatan, Harga, Jumlah As String

        Dim SQL, SQL2, SQL3, SQL4, SQL5 As String

        'For i As Integer = 0 To FrmTrnInvoicePembayaranKelapa.dgvlist.RowCount - 1
        '    If FrmTrnInvoicePembayaranKelapa.dgvlist.Rows(i).Cells("Check").Value = True Then
        '        Kapal = FrmTrnInvoicePembayaranKelapa.dgvlist.Item("NamaKapal", i).Value
        '        Kapasitas = FrmTrnInvoicePembayaranKelapa.dgvlist.Item("Kapasitas", i).Value
        '        Trip = FrmTrnInvoicePembayaranKelapa.dgvlist.Item("Trip", i).Value
        '        Pancang = FrmTrnInvoicePembayaranKelapa.dgvlist.Item("Pancang", i).Value
        '        Muatan = FrmTrnInvoicePembayaranKelapa.dgvlist.Item("Muatan", i).Value
        '        Harga = FrmTrnInvoicePembayaranKelapa.dgvlist.Item("Harga", i).Value
        '        Jumlah = FrmTrnInvoicePembayaranKelapa.dgvlist.Item("Jumlah", i).Value

        '        i += 1
        '    End If
        'Next


        Dim paramList As New Generic.List(Of ReportParameter)

        paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Tanggal", Tanggal, True))
        paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("NoInvoice", NoInvoice, True))
        '    paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Kapasitas", Kapasitas, True))
        '    paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Trip", Trip, True))
        '    paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Pancang", Pancang, True))
        '    paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Muatan", Muatan, True))
        '    paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Tanggal", Tanggal, True))
        '    paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Harga", Harga, True))
        '    paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Jumlah", Jumlah, True))




        'For i As Integer = 0 To FrmTrnInvoicePembayaranKelapa.dgvlist.RowCount - 1
        'If FrmTrnInvoicePembayaranKelapa.dgvlist.Rows(i).Cells("Check").Value = True Then

        If FrmTrnInvoicePembayaranKelapa.chkTgl.Checked = False Then
                    SQL2 = ""
                Else
                SQL2 = " And CONVERT(DATETIME,CONVERT(VARCHAR, TglMasukKapal,103),103) BETWEEN CONVERT (DATETIME,'" & FrmTrnInvoicePembayaranKelapa.dtp1.Value & "',103) AND CONVERT(DATETIME,'" & FrmTrnInvoicePembayaranKelapa.dtp2.Value & "',103)"
            End If

                If FrmTrnInvoicePembayaranKelapa.chkPancang.Checked = False Then
                    SQL3 = ""
                Else
                SQL3 = " And IDPancang = '" & FrmTrnInvoicePembayaranKelapa.cboPCG.SelectedValue & "'"
            End If

        If FrmTrnInvoicePembayaranKelapa.chkKapal.Checked = False Then
            SQL4 = ""
        Else
            SQL4 = " And IDKapal = '" & FrmTrnInvoicePembayaranKelapa.cboKPL.SelectedValue & "'"
        End If


        If FrmTrnInvoicePembayaranKelapa.chkTrip.Checked = False Then
                    SQL5 = ""
                Else
                SQL5 = " And Trip = '" & FrmTrnInvoicePembayaranKelapa.txtTrip.Text & "'"

            End If

        'SQL = "SELECT DISTINCT(A.Harga), Sum(A.NettoAkhir) As NettoAkhir, A.Kapal, A.Trip, A.Pancang, B.Kap, Sum(A.TotalHarga) as TotalHarga, A.Jenis,A.IDKapal FROM vwTMBGKelapaHdr_ AS A INNER JOIN " &
        '      "tblMstKapal AS B ON A.IDKapal = B.KapalID WHERE A.Deleted = 0 and IDKapal = '" & FrmTrnInvoicePembayaranKelapa.dgvlist.Item("IDKapal", i).Value & "'"

        'SQL = SQL + SQL2 + SQL3 + SQL4 + SQL5 & " GROUP BY A.Kapal,A.Trip,A.Pancang,B.Kap,A.Harga,A.Jenis,A.IDKapal order by Kapal desc"

        SQL = "SELECT TglMasukKapal,IDKapal,Kapal,Kap,Trip,IDPancang,Pancang,NettoAkhir,TotalHarga,TotalHarga/NettoAkhir AS Harga FROM vwInvoiceKelapa WHERE TglMasukKapal IS NOT NULL"

        SQL = SQL + SQL2 + SQL3 + SQL4 + SQL5 & "ORDER BY Kapal"

        Dim Da = New SqlDataAdapter(SQL, Conn)
                Dim Dt = New DataTable()
                Da.Fill(Dt)
                Dim Drs = New ReportDataSource("DSInvoicePembayaranKelapa_", Dt)
                Me.ReportViewer.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".rptInvoicePembayaranKelapa.rdlc"
                Me.ReportViewer.LocalReport.DataSources.Add(Drs)
                Me.ReportViewer.LocalReport.SetParameters(paramList)

        'End If
        'Next

        Dim newPageSetting As New System.Drawing.Printing.PageSettings
        newPageSetting.Margins = New Drawing.Printing.Margins(10, 10, 10, 10)
            newPageSetting.Landscape = True
            Me.ReportViewer.SetPageSettings(newPageSetting)
            Me.ReportViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            Me.ReportViewer.LocalReport.EnableExternalImages = True
            Me.ReportViewer.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".rptInvoicePembayaranKelapa.rdlc"
            Me.ReportViewer.RefreshReport()
            Me.ReportViewer.RefreshReport()
        'Catch ex As Exception
        '    MsgBox("Tidak ada Data yang akan diprint!", vbInformation, AT)
        'End Try
    End Sub

    Private Sub ReportViewer_Load(sender As Object, e As EventArgs) Handles ReportViewer.Load

    End Sub
End Class