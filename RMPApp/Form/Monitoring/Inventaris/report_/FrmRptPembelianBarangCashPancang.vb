Imports Microsoft.Reporting.WinForms
Imports System.Data.SqlClient

Public Class FrmRptPembelianBarangCashPancang
    Dim Pembelian As String = ""
    Dim idPancang As String = ""
    Dim trip As Integer = 0
    Dim periode As String = ""
    Dim user As String = ""
    Dim tanggal As String = ""

    Private Sub FrmRptPembelianBarangCashPancang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Combo.SetPancang(CmbPancang)
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If rdPulsa.Checked = True Then
            Pembelian = "Listrik / Internet"
        ElseIf RdPancang.Checked = True Then
            Pembelian = "PANCANG"
        ElseIf RdPurchaser.Checked = True Then
            Pembelian = "PURCHASER"
        End If

        idPancang = CmbPancang.SelectedValue

        trip = IIf(dtp1.Value.Day < 15 = True, 1, 2)

        If Format(dtp1, "MMMM yyyy") <> Format(dtp2, "MMMM yyyy") Then
            periode = "PERIODE " & Format(dtp1, "dd MMMM") & "-" & dtp2.ToString("dd") & " " & Format(dtp2, "MMMM yyyy")
        Else
            periode = "PERIODE " & dtp1.ToString("dd") & "-" & dtp2.ToString("dd") & " " & Format(dtp1, "MMMM yyyy")
        End If

        user = ClsSession.UserID

        tanggal = " cast('" & Format(dtp1.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(dtp2.Value, "yyyy-MM-dd") & "' as date) "

        Me.ReportViewer1.RefreshReport()

        If rdPulsa.Checked = True Then
            Call ReportShowPulsaToken()
        Else
            Call ReportShow()
        End If
    End Sub

    Private Sub ReportShow()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim Conn As SqlConnection
            Dim ReportName, Ds, sql As String


            Dim ParamList As New Generic.List(Of ReportParameter)
            ParamList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Untuk", Pembelian, True))
            ParamList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Trip", Trip, True))
            ParamList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Periode", periode, True))
            ParamList.Add(New Microsoft.Reporting.WinForms.ReportParameter("UserPrint", user, True))


            ReportName = ".RptPembelianBarangPancangCash.rdlc"
            Ds = "ds"

            sql = " SELECT c.pancang,cast(FORMAT(a.created_date,'dd-MMM') as char(6)) as tanggal,a.nama_item as jenisItem,a.qty,a.harga_sub as harga,a.harga as totalHarga,a.remark as catatan,
                    (select sum(harga) from [192.168.2.3].[PSGRMP].[dbo].[vwPancangReq_TransaksiItem] where nama_kategori='Solar' and pancang_id=a.pancang_id and nama_penggunaan='" & Pembelian & "'
					AND (CAST(created_date AS DATE) BETWEEN " & tanggal & ")) as totalSolar,
                    (select sum(harga) from [192.168.2.3].[PSGRMP].[dbo].[vwPancangReq_TransaksiItem] where nama_kategori<>'Solar' and pancang_id=a.pancang_id and nama_penggunaan='" & Pembelian & "'
					AND (CAST(created_date AS DATE) BETWEEN " & tanggal & ")) as totalBukanSolar,
					(select sum(harga) from [192.168.2.3].[PSGRMP].[dbo].[vwPancangReq_TransaksiItem] where pancang_id=a.pancang_id and nama_penggunaan='" & Pembelian & "'
					AND (CAST(created_date AS DATE) BETWEEN " & tanggal & ")) as totalAll,
                    iif(a.nama_item like '%solar%','solar','bukanSolar') kategoriTabel
                    FROM [192.168.2.3].[PSGRMP].[dbo].[vwPancangReq_TransaksiItem] AS a
                    inner JOIN Android_tblMstPancang AS c ON a.pancang_id = c.IDPancang
                    AND (CAST(a.created_date AS DATE) BETWEEN " & tanggal & ") 
                    and a.nama_penggunaan='" & Pembelian & "'
                    " & IIf(CmbPancang.Text <> "", " and pancang_id=" & CmbPancang.SelectedValue & " ", "") & "
                    order by c.Pancang,a.header_id "

            Dim Da = New SqlDataAdapter(sql, Conn)
            Dim _Dt As DataTable = New DataTable
            _Dt = DB.ExecuteQuery(StrConnRMPApp, sql)
            If _Dt.Rows.Count = 0 Then
                MsgBox("Tidak Ada Data", vbInformation, AT)
            End If
            Dim DSource = New ReportDataSource(Ds, _Dt)

            Me.ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ReportName
            Me.ReportViewer1.LocalReport.DataSources.Add(DSource)
            Me.ReportViewer1.LocalReport.SetParameters(ParamList)
            Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            Me.Cursor = Cursors.Arrow
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ReportShowPulsaToken()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim Conn As SqlConnection
            Dim ReportName, Ds, sql As String


            Dim ParamList As New Generic.List(Of ReportParameter)
            ParamList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Untuk", Pembelian, True))
            ParamList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Trip", trip, True))
            ParamList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Periode", periode, True))
            ParamList.Add(New Microsoft.Reporting.WinForms.ReportParameter("UserPrint", user, True))


            ReportName = ".RptPembelianBarangPancangCashPulsaToken.rdlc"
            Ds = "ds"

            sql = " SELECT c.pancang,cast(FORMAT(a.created_date,'dd-MMM') as char(6)) as tanggal,a.nama_item as jenisItem,a.qty,a.harga_sub as harga,a.harga as totalHarga,
                    A.remark as catatan,0 as totalSolar,
                    (select sum(harga) from [192.168.2.3].[PSGRMP].[dbo].[vwPancangReq_TransaksiItem] where pancang_id=a.pancang_id and nama_penggunaan='" & Pembelian & "'
					AND (CAST(created_date AS DATE) BETWEEN " & tanggal & ")) as totalBukanSolar,
					(select sum(harga) from [192.168.2.3].[PSGRMP].[dbo].[vwPancangReq_TransaksiItem] where pancang_id=a.pancang_id and nama_penggunaan='" & Pembelian & "'
					AND (CAST(created_date AS DATE) BETWEEN " & tanggal & ")) as totalAll,
                    iif(a.nama_item like '%solar%','solar','bukanSolar') kategoriTabel
                    FROM [192.168.2.3].[PSGRMP].[dbo].[vwPancangReq_TransaksiItem] AS a
                    inner JOIN Android_tblMstPancang AS c ON a.pancang_id = c.IDPancang
                    AND (CAST(a.created_date AS DATE) BETWEEN " & tanggal & ") 
                    and a.nama_penggunaan='" & Pembelian & "'
                    " & IIf(CmbPancang.Text <> "", " and pancang_id=" & CmbPancang.SelectedValue & " ", "") & "
                    order by c.Pancang,a.header_id "

            Dim Da = New SqlDataAdapter(sql, Conn)
            Dim _Dt As DataTable = New DataTable
            _Dt = DB.ExecuteQuery(StrConnRMPApp, sql)
            If _Dt.Rows.Count = 0 Then
                MsgBox("Tidak Ada Data", vbInformation, AT)
            End If
            Dim DSource = New ReportDataSource(Ds, _Dt)

            Me.ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ReportName
            Me.ReportViewer1.LocalReport.DataSources.Add(DSource)
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