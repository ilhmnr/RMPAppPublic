Imports Microsoft.Reporting.WinForms
Imports System.Data.SqlClient

Public Class FrmRptPembelianBarangCashPancangFromMon
    Public Pulsa As Boolean
    Public Purchaser As Boolean
    Public Pancang As Boolean
    Dim Pembelian As String = ""
    Public trip As Integer
    Dim user As String = ""
    Dim tanggal As String = ""
    Public IdPancang As String
    Dim Periode As String = ""
    Public detail_id As String
    Public detail_id_ As String
    Public ModelReport As Integer

    Private Sub FrmRptPembelianBarangCashPancangFromMon_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Pulsa = True Then
            Pembelian = "Listrik / Internet"
        ElseIf Pancang = True Then
            Pembelian = "PANCANG"
        ElseIf Purchaser = True Then
            Pembelian = "PURCHASER"
        End If

        With FrmMonPembelianBarangPancangCash
            If .chkTglNota.Checked = True Then
                If ModelReport = 1 Then
                    If Format(.Dtp1.Value, "MMMM yyyy") <> Format(.Dtp2.Value, "MMMM yyyy") Then
                        Periode = Format(.Dtp1.Value, "dd MMMM") & "-" & .Dtp2.Value.ToString("dd") & " " & Format(.Dtp2.Value, "MMMM yyyy")
                    Else
                        Periode = .Dtp1.Value.ToString("dd") & "-" & .Dtp2.Value.ToString("dd") & " " & Format(.Dtp1.Value, "MMMM yyyy")
                    End If
                Else
                    If trip = 1 Then
                        Periode = "01-15 " & Format(.Dtp1.Value, "MMMM yyyy")
                    Else
                        Periode = "16-" & Date.DaysInMonth(.Dtp1.Value.Year, .Dtp1.Value.Month).ToString() & " " & Format(.Dtp1.Value, "MMMM yyyy")
                    End If
                End If

                tanggal = " AND (CAST(tanggal_nota AS DATE) BETWEEN cast('" & Format(.Dtp1.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(.Dtp2.Value, "yyyy-MM-dd") & "' as date)) "
            ElseIf .chkTglTerima.Checked = True Then
                If ModelReport = 1 Then
                    If Format(.dtpTerima.Value, "MMMM yyyy") <> Format(.dtpTerima2.Value, "MMMM yyyy") Then
                        Periode = Format(.dtpTerima.Value, "dd MMMM") & "-" & .dtpTerima2.Value.ToString("dd") & " " & Format(.dtpTerima2.Value, "MMMM yyyy")
                    Else
                        Periode = .dtpTerima.Value.ToString("dd") & "-" & .dtpTerima2.Value.ToString("dd") & " " & Format(.dtpTerima.Value, "MMMM yyyy")
                    End If
                Else
                    If trip = 1 Then
                        Periode = "01-15 " & Format(.dtpTerima.Value, "MMMM yyyy")
                    Else
                        Periode = "16-" & Date.DaysInMonth(.dtpTerima.Value.Year, .dtpTerima.Value.Month).ToString() & " " & Format(.dtpTerima.Value, "MMMM yyyy")
                    End If
                End If

                tanggal = " AND (CAST(terima_nota_date AS DATE) BETWEEN cast('" & Format(.dtpTerima.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(.dtpTerima2.Value, "yyyy-MM-dd") & "' as date)) "
            ElseIf .rdTgl.Checked = True Then
                If ModelReport = 1 Then
                    If Format(.dtpCreate1.Value, "MMMM yyyy") <> Format(.dtpCreate2.Value, "MMMM yyyy") Then
                        Periode = Format(.dtpCreate1.Value, "dd MMMM") & "-" & .dtpCreate2.Value.ToString("dd") & " " & Format(.dtpCreate2.Value, "MMMM yyyy")
                    Else
                        Periode = .dtpCreate1.Value.ToString("dd") & "-" & .dtpCreate2.Value.ToString("dd") & " " & Format(.dtpCreate1.Value, "MMMM yyyy")
                    End If
                Else
                    If trip = 1 Then
                        Periode = "01-15 " & Format(.dtpCreate1.Value, "MMMM yyyy")
                    Else
                        Periode = "16-" & Date.DaysInMonth(.dtpCreate1.Value.Year, .dtpCreate1.Value.Month).ToString() & " " & Format(.dtpCreate1.Value, "MMMM yyyy")
                    End If
                End If

                tanggal = " AND (CAST(created_date AS DATE) BETWEEN cast('" & Format(.dtpCreate1.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(.dtpCreate2.Value, "yyyy-MM-dd") & "' as date)) "
            End If
        End With

        user = ClsSession.UserID

        Me.ReportViewer1.RefreshReport()

        If Pulsa = True Then
            If ModelReport = 1 Then
                Call ReportShowPulsaToken()
            Else

            End If
        Else
            If ModelReport = 1 Then
                Call ReportShow()
            Else
                Call ReportShowModelReport2()
            End If
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
            ParamList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Periode", Periode, True))
            ParamList.Add(New Microsoft.Reporting.WinForms.ReportParameter("UserPrint", user, True))


            ReportName = ".RptPembelianBarangPancangCash.rdlc"
            Ds = "ds"

            sql = " SELECT c.pancang,cast(FORMAT(a.tanggal_nota,'dd-MMM') as char(6)) as tanggal,a.nama_item as jenisItem,a.qty,a.harga_sub as harga,a.harga as totalHarga,a.remark as catatan,
                    (select sum(harga) from [192.168.2.3].[PSGRMP].[dbo].[vwPancangReq_TransaksiItem] where nama_kategori='Solar' and pancang_id=a.pancang_id and nama_penggunaan='" & Pembelian & "'
					" & tanggal & " and " & detail_id_ & ") as totalSolar,
                    (select sum(harga) from [192.168.2.3].[PSGRMP].[dbo].[vwPancangReq_TransaksiItem] where nama_kategori<>'Solar' and pancang_id=a.pancang_id and nama_penggunaan='" & Pembelian & "'
					" & tanggal & " and " & detail_id_ & ") as totalBukanSolar,
					(select sum(harga) from [192.168.2.3].[PSGRMP].[dbo].[vwPancangReq_TransaksiItem] where pancang_id=a.pancang_id and nama_penggunaan='" & Pembelian & "'
					" & tanggal & " and " & detail_id_ & ") as totalAll,
                    iif(a.nama_item like '%solar%','solar','bukanSolar') kategoriTabel
                    FROM [192.168.2.3].[PSGRMP].[dbo].[vwPancangReq_TransaksiItem] AS a
                    inner JOIN Android_tblMstPancang AS c ON a.pancang_id = c.IDPancang
                    " & tanggal & "
                    and a.nama_penggunaan='" & Pembelian & "'
                    and " & detail_id & "
                    " & IIf(IdPancang <> "", " and pancang_id=" & IdPancang & " ", "") & "
                    order by c.Pancang,a.tanggal_nota asc "

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
            ParamList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Periode", Periode, True))
            ParamList.Add(New Microsoft.Reporting.WinForms.ReportParameter("UserPrint", user, True))


            ReportName = ".RptPembelianBarangPancangCashPulsaToken.rdlc"
            Ds = "ds"

            sql = " SELECT c.pancang,cast(FORMAT(a.tanggal_nota,'dd-MMM') as char(6)) as tanggal,a.nama_item as jenisItem,a.qty,a.harga_sub as harga,a.harga as totalHarga,
                    A.remark as catatan,0 as totalSolar,
                    (select sum(harga) from [192.168.2.3].[PSGRMP].[dbo].[vwPancangReq_TransaksiItem] where pancang_id=a.pancang_id and nama_penggunaan='" & Pembelian & "'
					" & tanggal & " and " & detail_id_ & ") as totalBukanSolar,
					(select sum(harga) from [192.168.2.3].[PSGRMP].[dbo].[vwPancangReq_TransaksiItem] where pancang_id=a.pancang_id and nama_penggunaan='" & Pembelian & "'
					" & tanggal & " and " & detail_id_ & ") as totalAll,
                    iif(a.nama_item like '%solar%','solar','bukanSolar') kategoriTabel
                    FROM [192.168.2.3].[PSGRMP].[dbo].[vwPancangReq_TransaksiItem] AS a
                    inner JOIN Android_tblMstPancang AS c ON a.pancang_id = c.IDPancang
                    " & tanggal & "
                    and a.nama_penggunaan='" & Pembelian & "'
                    and " & detail_id & "
                    " & IIf(IdPancang <> "", " and pancang_id=" & IdPancang & " ", "") & "
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

    Private Sub ReportViewer1_Print(sender As Object, e As ReportPrintEventArgs) Handles ReportViewer1.Print
        With FrmMonPembelianBarangPancangCash.FG
            For i = 1 To .Rows.Count - 1
                If .Item(i, 1) = True Then
                    DB.ExecuteQuery(StrConnPSGRMP, " update PSGRMP..tblPancangReq_TransaksiItemDetail set flag_sudah_print=1 where detaild_id=" & .Item(i, 25))
                End If
            Next
        End With
    End Sub

    Private Sub ReportShowModelReport2()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim Conn As SqlConnection
            Dim ReportName, Ds, sql As String


            Dim ParamList As New Generic.List(Of ReportParameter)
            ParamList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Untuk", Pembelian, True))
            ParamList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Trip", trip, True))
            ParamList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Periode", Periode, True))
            ParamList.Add(New Microsoft.Reporting.WinForms.ReportParameter("UserPrint", user, True))


            ReportName = ".RptPembelianBarangPancangCash2.rdlc"
            Ds = "dtPembelinBarangCash2"

            sql = " SELECT c.pancang,cast(FORMAT(a.tanggal_nota,'dd-MMM') as char(6)) as tanggal,a.nama_item as jenisItem,a.qty,a.harga_sub as harga,a.harga as totalHarga,a.remark as catatan
                    FROM [192.168.2.3].[PSGRMP].[dbo].[vwPancangReq_TransaksiItem] AS a
                    inner JOIN Android_tblMstPancang AS c ON a.pancang_id = c.IDPancang
                    " & tanggal & "
                    and a.nama_penggunaan='" & Pembelian & "'
                    and " & detail_id & "
                    " & IIf(IdPancang <> "", " and pancang_id=" & IdPancang & " ", "") & "
                    order by a.tanggal_nota asc "

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