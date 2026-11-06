Imports C1.Win.C1FlexGrid
Imports Microsoft.Reporting.WinForms
Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing.Reader

Public Class FrmRptRekapDataPetaniPembayaranKB
	Public Conn As SqlConnection
	'test
	Private Sub FrmRptRekapDataPetaniPembayaranKB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Me.ReportViewer1.RefreshReport()
		ShowPancang()
		ShowVia()
		cboJenisBayar.Enabled = False
	End Sub

	Sub ShowPancang()
		cboPancang.Items.Clear()
		Dim cn As New SqlConnection(StrConnRMPApp)
		Dim sql As String
		If chkPcgLuarInhil.Checked = True Then
			sql = "SELECT [Pancang] FROM [RMPApp].[dbo].[Android_tblMstPancang] where PONTIANAK=1 order by Pancang"
		Else
			sql = "SELECT [Pancang] FROM [RMPApp].[dbo].[Android_tblMstPancang] where PONTIANAK IS NULL order by Pancang"
		End If
		Dim cmd As New SqlCommand(sql, cn)
		Dim rs As SqlDataReader
		Try
			cn.Open()
			rs = cmd.ExecuteReader
			While rs.Read
				cboPancang.Items.Add(rs!Pancang)
			End While
		Catch ex As Exception
			MsgBox(ex.Message, MsgBoxStyle.Critical)
		End Try
	End Sub

	Sub ShowVia()
		Dim cn As New SqlConnection(StrConnRMPApp)
		Dim sql As String
		sql = "SELECT [KapalName] FROM [RMPApp].[dbo].[tblMstKapal] WHERE NonActive = 0 order by KapalName"
		Dim cmd As New SqlCommand(sql, cn)
		Dim rs As SqlDataReader
		Try
			cn.Open()
			rs = cmd.ExecuteReader
			While rs.Read
				cboVia.Items.Add(rs!KapalName)
			End While
		Catch ex As Exception
			MsgBox(ex.Message, MsgBoxStyle.Critical)
		End Try
	End Sub

	Sub ReportShow()
		If rdKB.Checked = True Or rdKC.Checked = True Then
			If CHKPSP.Checked = True Then
				Call KBPSP()
				LoadDetailPSP()
			Else
				Call KB()
				LoadDetail()
			End If
		End If

		If rdUBM.Checked = True Or rdubmkc.Checked = True Then
			Call UBM()
			LoadDetailubm()
		End If

		If rdUB.Checked = True Then
			Call UB()
			LoadDetailub()
		End If

		If rdkomkb.Checked = True Or rdkomkc.Checked = True Then
			Call KOM()
			LoadDetailkom()
		End If

		If chkJenisBayar.Checked = True And cboJenisBayar.Text <> "" Then
			With dgvlist
				For i = 0 To .Rows.Count - 1
					.Item("LAYANANTRF", i).Value = cboJenisBayar.Text
				Next
			End With
		End If
	End Sub

	Sub ReportShowbelumapprove()
		If rdKB.Checked = True Or rdKC.Checked = True Then
			LoadDetail()
		End If

		If rdUBM.Checked = True Or rdubmkc.Checked = True Then
			LoadDetailubm()
		End If

		If rdUB.Checked = True Then
			LoadDetailub()
		End If
	End Sub

	Sub UB()
		Try
			Me.Cursor = Cursors.WaitCursor
			Dim ReportName As String
			Dim DsKontrak As String
			Dim sql, sqlp, sqla, sqlp2 As String

			Dim Pancang As String = cboPancang.Text
			Dim Tanggal As String = Format(dtpTanggal.Value, "dd/MM/yyyy")
			Dim Header As String = "REKAP DATA PETANI UNTUK PEMBAYARAN UPAH BURUH PANCANG SAMBU GROUP"

			Dim paramList As New Generic.List(Of ReportParameter)

			If cbxPancang.Checked = True Then
				paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Pancang", Pancang, True))
			Else cbxPancang.Checked = False
				paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Pancang", " ", True))
			End If
			paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Tanggal", Tanggal, True))
			paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Header", Header, True))

			ReportName = ".RptRekapDataPetaniPembayaranUBM.rdlc"
			DsKontrak = "dtRekap2"

			If cbxPancang.Checked = True Then
				sqlp = "and Pancang = '" & cboPancang.Text & "' "
			Else
				sqlp = ""
			End If

			If chkmandiri.Checked = True And chkBNI.Checked = True And chkBankLain.Checked = False Then
				sqlp2 = "and Bank  in ('MANDIRI','BNI') "
			End If

			If chkmandiri.Checked = True And chkBNI.Checked = False And chkBankLain.Checked = True Then

				sqlp2 = "and Bank  NOT in ('BNI') "
			End If

			If chkmandiri.Checked = False And chkBNI.Checked = True And chkBankLain.Checked = True Then

				sqlp2 = "and Bank NOT in ('MANDIRI') "
			End If


			If chkmandiri.Checked = True And chkBNI.Checked = False And chkBankLain.Checked = False Then

				sqlp2 = "and Bank  in ('MANDIRI') "
			End If

			If chkmandiri.Checked = False And chkBNI.Checked = True And chkBankLain.Checked = False Then

				sqlp2 = "and Bank in ('BNI') "
			End If


			If chkmandiri.Checked = False And chkBNI.Checked = False And chkBankLain.Checked = True Then

				sqlp2 = "and Bank  not in ('MANDIRI','BNI') "
			End If

			If chkP1.Checked = True Then
				sql = "SELECT * FROM [RMPApp].[dbo].[vwRMRekapUBP1_032025] " &
				  "where Amount>0 AND (cast(FDate as date) between cast('" & Format(dtpTanggal.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(dtpTanggal2.Value, "yyyy-MM-dd") & "' as date)) "
			ElseIf chkP2.Checked = True Then
				sql = "SELECT * FROM [RSUPAccounting].[dbo].[vwRMRekapUB_022025] " &
				  "where Amount>0 AND (cast(FDate as date) between cast('" & Format(dtpTanggal.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(dtpTanggal2.Value, "yyyy-MM-dd") & "' as date)) "
			End If

			sqla = sql + sqlp + sqlp2 & "ORDER BY KODEBANK ,Remark1"


			Dim Da = New SqlDataAdapter(sqla, Conn)
			Dim _Dt As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sqla)
			Dim DSource = New ReportDataSource(DsKontrak, _Dt)
			Me.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ReportName
			Me.ReportViewer1.LocalReport.DataSources.Add(DSource)
			Me.ReportViewer1.LocalReport.SetParameters(paramList)

			Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
			Me.ReportViewer1.RefreshReport()
		Catch ex As Exception
			Me.Cursor = Cursors.Arrow
			MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
		Me.Cursor = Cursors.Arrow
	End Sub

	Sub UBM()
		Try
			Me.Cursor = Cursors.WaitCursor
			Dim ReportName As String
			Dim DsKontrak As String
			Dim sql, sqlp, sqla, sqlp2, sqlp3 As String


			Dim Pancang As String = cboPancang.Text
			Dim Tanggal As String = Format(dtpTanggal.Value, "dd/MM/yyyy")
			Dim Header As String = "REKAP DATA PETANI UNTUK PEMBAYARAN UPAH BURUH MUAT PANCANG SAMBU GROUP"

			Dim paramList As New Generic.List(Of ReportParameter)

			If cbxPancang.Checked = True Then
				paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Pancang", Pancang, True))
			Else cbxPancang.Checked = False
				paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Pancang", " ", True))
			End If
			paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Header", Header, True))
			paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Tanggal", Tanggal, True))

			ReportName = ".RptRekapDataPetaniPembayaranUBM.rdlc"
			DsKontrak = "dtRekap2"

			If cbxPancang.Checked = True Then
				sqlp = "and Pancang = '" & cboPancang.Text & "' "
			Else
				sqlp = ""
			End If

			If chkPcgLuarInhil.Checked = True Then
				sqlp &= " and Pancang in (SELECT Pancang FROM [RMPApp].[dbo].[Android_tblMstPancang] where PONTIANAK IS NOT NULL) "
			Else
				sqlp &= " and Pancang in (SELECT Pancang FROM [RMPApp].[dbo].[Android_tblMstPancang] where PONTIANAK IS NULL) "
			End If

			If rdUBM.Checked = True And rdubmkc.Checked = True Then
				sqlp3 = "and kodebahanbaku  in ('1','3') "
			End If

			If rdUBM.Checked = True And rdubmkc.Checked = False Then
				sqlp3 = "and kodebahanbaku in ('1') "
			End If

			If rdUBM.Checked = False And rdubmkc.Checked = True Then
				sqlp3 = "and kodebahanbaku  in ('3') "
			End If

			If chkmandiri.Checked = True And chkBNI.Checked = True And chkBankLain.Checked = False Then
				sqlp2 = "and Bank  in ('MANDIRI','BNI') "
			End If

			If chkmandiri.Checked = True And chkBNI.Checked = False And chkBankLain.Checked = True Then

				sqlp2 = "and Bank  NOT in ('BNI') "
			End If

			If chkmandiri.Checked = False And chkBNI.Checked = True And chkBankLain.Checked = True Then
				sqlp2 = "and Bank NOT in ('MANDIRI') "
			End If


			If chkmandiri.Checked = True And chkBNI.Checked = False And chkBankLain.Checked = False Then
				sqlp2 = "and Bank  in ('MANDIRI') "
			End If

			If chkmandiri.Checked = False And chkBNI.Checked = True And chkBankLain.Checked = False Then
				sqlp2 = "and Bank in ('BNI') "
			End If


			If chkmandiri.Checked = False And chkBNI.Checked = False And chkBankLain.Checked = True Then
				sqlp2 = "and Bank  not in ('MANDIRI','BNI') "
			End If

			If chkP1.Checked = True Then
				sql = "SELECT * FROM [RMPApp].[dbo].[vwRMRekapUBMP1022025] " &
				  "where Amount>0 AND (cast(FDate as date) between cast('" & Format(dtpTanggal.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(dtpTanggal2.Value, "yyyy-MM-dd") & "' as date)) "
			ElseIf chkP2.Checked = True Then
				sql = "SELECT * FROM [RSUPAccounting].[dbo].[vwRMRekapUBM022025] " &
				  "where Amount>0 AND (cast(FDate as date) between cast('" & Format(dtpTanggal.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(dtpTanggal2.Value, "yyyy-MM-dd") & "' as date)) "
			End If

			sqla = sql + sqlp + sqlp2 + sqlp3 & "ORDER BY KODEBANK ,Remark1"

			Dim Da = New SqlDataAdapter(sqla, Conn)
			Dim _Dt As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sqla)
			Dim DSource = New ReportDataSource(DsKontrak, _Dt)
			Me.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ReportName
			Me.ReportViewer1.LocalReport.DataSources.Add(DSource)
			Me.ReportViewer1.LocalReport.SetParameters(paramList)
			Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
			Me.ReportViewer1.RefreshReport()
		Catch ex As Exception
			Me.Cursor = Cursors.Arrow
			MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
		Me.Cursor = Cursors.Arrow
	End Sub
	Sub KOM()
		Try
			Me.Cursor = Cursors.WaitCursor
			Dim ReportName As String
			Dim DsKontrak As String
			Dim sql, sqlp, sqla, sqlp2, sqlp3, sqlp4 As String


			Dim Pancang As String = cboPancang.Text
			Dim Tanggal As String = Format(Now, "MMyyyy")
			Dim Header As String = "REKAP DATA PETANI UNTUK PEMBAYARAN KOMISI"

			Dim paramList As New Generic.List(Of ReportParameter)

			If cbxPancang.Checked = True Then
				paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Pancang", Pancang, True))
			Else cbxPancang.Checked = False
				paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Pancang", " ", True))
			End If
			paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Header", Header, True))
			paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Tanggal", Tanggal, True))

			ReportName = ".RptRekapDataPetaniPembayaranKOM.rdlc"
			DsKontrak = "dtRekap2"

			If cbxPancang.Checked = True Then
				sqlp = "and Pancang = '" & cboPancang.Text & "' "
			Else
				sqlp = ""
			End If

			If rdUBM.Checked = True And rdubmkc.Checked = True Then
				sqlp3 = "and kodebahanbaku  in ('1','3') "
			End If

			If rdUBM.Checked = True And rdubmkc.Checked = False Then
				sqlp3 = "and kodebahanbaku in ('1') "
			End If

			If rdUBM.Checked = False And rdubmkc.Checked = True Then
				sqlp3 = "and kodebahanbaku  in ('3') "
			End If

			If chkmandiri.Checked = True And chkBNI.Checked = True And chkBankLain.Checked = False Then

				sqlp2 = "and Bank  in ('MANDIRI','BNI') "
			End If

			If chkmandiri.Checked = True And chkBNI.Checked = False And chkBankLain.Checked = True Then

				sqlp2 = "and Bank  NOT in ('BNI') "
			End If

			If chkmandiri.Checked = False And chkBNI.Checked = True And chkBankLain.Checked = True Then

				sqlp2 = "and Bank NOT in ('MANDIRI') "
			End If


			If chkmandiri.Checked = True And chkBNI.Checked = False And chkBankLain.Checked = False Then

				sqlp2 = "and Bank  in ('MANDIRI') "
			End If

			If chkmandiri.Checked = False And chkBNI.Checked = True And chkBankLain.Checked = False Then

				sqlp2 = "and Bank in ('BNI') "
			End If


			If chkmandiri.Checked = False And chkBNI.Checked = False And chkBankLain.Checked = True Then

				sqlp2 = "and Bank  not in ('MANDIRI','BNI') "
			End If

			sqlp4 = " and (cast(Transdate as date) between cast('" & Format(dtpTanggal.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(dtpTanggal2.Value, "yyyy-MM-dd") & "' as date)) "

			If chkP1.Checked = True Then
				sql = " SELECT
						NoInvoice,
						replace(NoRekening,'-','') AS Rek_Tujuan,
						NamaRekening AS Rekening_Penerima,
						'KOM ' + Pancang AS Remark1,
						'' AS Remark2,
						NoTelp AS Email,
						Bank AS Datacolumn8,
						(
							CAST(REPLACE(Total, '.0000', '') AS NUMERIC(18, 2)) -
							CAST(REPLACE(ISNULL(PajakNonNPWP, '0.00'), '.00', '') AS NUMERIC(18, 2)) -
							CAST(REPLACE(ISNULL(PajakNPWP, '0.00'), '.00', '') AS NUMERIC(18, 2))
						) AS Amount
						FROM
							RSUPAccounting..vwRMTrnBiayaSaranaMuat
						WHERE
						Factory = 'PSG' "
			ElseIf chkP2.Checked = True Then
				sql = " SELECT
						NoInvoice,
						replace(NoRekening,'-','') AS Rek_Tujuan,
						NamaRekening AS Rekening_Penerima,
						'KOM ' + Pancang AS Remark1,
						'' AS Remark2,
						NoTelp AS Email,
						Bank AS Datacolumn8,
						(
							CAST(REPLACE(Total, '.0000', '') AS NUMERIC(18, 2)) -
							CAST(REPLACE(ISNULL(PajakNonNPWP, '0.00'), '.00', '') AS NUMERIC(18, 2)) -
							CAST(REPLACE(ISNULL(PajakNPWP, '0.00'), '.00', '') AS NUMERIC(18, 2))
						) AS Amount
						FROM
							RSUPAccounting..vwRMTrnBiayaSaranaMuat
						WHERE
						Factory = 'RSUP' "
			End If

			sqla = sql + sqlp + sqlp2 + sqlp3 + sqlp4 & " order by Datacolumn8 asc "

			Dim Da = New SqlDataAdapter(sqla, Conn)
			Dim _Dt As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sqla)
			Dim DSource = New ReportDataSource(DsKontrak, _Dt)
			Me.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ReportName
			Me.ReportViewer1.LocalReport.DataSources.Add(DSource)
			Me.ReportViewer1.LocalReport.SetParameters(paramList)
			Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
			Me.ReportViewer1.RefreshReport()
		Catch ex As Exception
			Me.Cursor = Cursors.Arrow
			MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
		Me.Cursor = Cursors.Arrow
	End Sub

	Sub KB()
		Try

			Me.Cursor = Cursors.WaitCursor
			Dim ReportName, IndUMBy As String
			Dim DsKontrak As String
			Dim sql, sqlp, sqla, sqlp2, sqlp3 As String
			Dim Pancang As String = cboPancang.Text
			Dim Tanggal As String = Format(dtpTanggal.Value, "dd/MM/yyyy")
			Dim Via As String = cboVia.Text
			Dim JenisBank As String
			Dim paramList As New Generic.List(Of ReportParameter)

			paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Pancang", Pancang, True))
			paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Tanggal", Tanggal, True))
			paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Via", Via, True))


			ReportName = ".RptRekapDataPetaniPembayaranKB.rdlc"
			DsKontrak = "dtRekap"

			If cbxPancang.Checked = True Then
				sqlp = "and Pancang = '" & cboPancang.Text & "' "
			Else
				sqlp = ""
			End If

			If chkmandiri.Checked = True And chkBNI.Checked = True And chkBankLain.Checked = True Then
				JenisBank = "All"
			End If

			If chkmandiri.Checked = True And chkBNI.Checked = True And chkBankLain.Checked = False Then
				JenisBank = "BNI AND Mandiri"
				sqlp2 = "and LEFT(JenisBank,50)  in ('MANDIRI','BNI') "
			End If

			If chkmandiri.Checked = True And chkBNI.Checked = False And chkBankLain.Checked = True Then
				JenisBank = "Mandiri dan Bank Lain"
				sqlp2 = "and LEFT(JenisBank,50)  NOT in ('BNI') "
			End If

			If chkmandiri.Checked = False And chkBNI.Checked = True And chkBankLain.Checked = True Then
				JenisBank = "BNI DAN Bank Lain"
				sqlp2 = "and LEFT(JenisBank,50)  NOT in ('MANDIRI') "
			End If


			If chkmandiri.Checked = True And chkBNI.Checked = False And chkBankLain.Checked = False Then
				JenisBank = "Mandiri"
				sqlp2 = "and LEFT(JenisBank,50)  in ('MANDIRI') "
			End If

			If chkmandiri.Checked = False And chkBNI.Checked = True And chkBankLain.Checked = False Then
				JenisBank = "BNI"
				sqlp2 = "and LEFT(JenisBank,50)  in ('BNI') "
			End If


			If chkmandiri.Checked = False And chkBNI.Checked = False And chkBankLain.Checked = True Then
				JenisBank = "BankLain"
				sqlp2 = "and LEFT(JenisBank,50)  not in ('MANDIRI','BNI') "
			End If

			paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("JenisBank", JenisBank, True))


			If rdKB.Checked = True And rdKC.Checked = True Then
				sqlp3 = "and JENISKB  in ('KB-A','KB-B','KC') "
			End If

			If rdKB.Checked = True And rdKC.Checked = False Then
				sqlp3 = "and JENISKB  in ('KB-A','KB-B') "
			End If

			If rdKB.Checked = False And rdKC.Checked = True Then
				sqlp3 = "and JENISKB  in ('KC') "
			End If


			If chkP1.Checked = True Then
				IndUMBy = "PSG"
			ElseIf chkP2.Checked = True Then
				IndUMBy = "RSUP"
			End If


			If rdPagi.Checked = True Then
				sql = "SELECT * FROM [RSUPAccounting].[dbo].[fnDataPetaniPembayaranKBTgl_TrnRpt_14112025]( '" & Format(dtpTanggal.Value, "yyyy") & "', '" & Format(dtpTanggal.Value, "MM") & "', '" & Format(dtpTanggal.Value, "dd") & "','" & IndUMBy & "') where   Amount>0 AND jenisbank is not null and WaktuPengajuan = 'PAGI'   "

			ElseIf rdSore.Checked = True Then
				sql = "SELECT * FROM [RSUPAccounting].[dbo].[fnDataPetaniPembayaranKBTgl_TrnRpt_14112025]( '" & Format(dtpTanggal.Value, "yyyy") & "', '" & Format(dtpTanggal.Value, "MM") & "', '" & Format(dtpTanggal.Value, "dd") & "','" & IndUMBy & "') where   Amount>0 AND jenisbank is not null and WaktuPengajuan = 'SORE'  "

			ElseIf rdAll.Checked = True Then
				sql = "SELECT * FROM [RSUPAccounting].[dbo].[fnDataPetaniPembayaranKBTgl_TrnRpt_14112025]( '" & Format(dtpTanggal.Value, "yyyy") & "', '" & Format(dtpTanggal.Value, "MM") & "', '" & Format(dtpTanggal.Value, "dd") & "','" & IndUMBy & "') where    Amount>0 AND jenisbank is not null   "
			End If

			sqla = sql + sqlp + sqlp2 + sqlp3 & "ORDER BY KODEBANK ,Remark1,NoRekening,NamaRekening"


			Dim Da = New SqlDataAdapter(sqla, Conn)
			Dim _Dt As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sqla)
			Dim DSource = New ReportDataSource(DsKontrak, _Dt)
			Me.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ReportName
			Me.ReportViewer1.LocalReport.DataSources.Add(DSource)
			'ReportParameter p1 = New ReportParameter(" ReportParameter1", comboBox1.SelectedValue.ToString());
			Me.ReportViewer1.LocalReport.SetParameters(paramList)
			Dim newPageSetting As New System.Drawing.Printing.PageSettings
			newPageSetting.Margins = New System.Drawing.Printing.Margins(3, 3, 3, 3)
			newPageSetting.Landscape = True
			ReportViewer1.SetPageSettings(newPageSetting)
			Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
			Me.ReportViewer1.RefreshReport()
		Catch ex As Exception
			Me.Cursor = Cursors.Arrow
			MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
		Me.Cursor = Cursors.Arrow
	End Sub


	Sub KBPSP()
		Try
			Me.Cursor = Cursors.WaitCursor
			Dim ReportName, IndUMBy As String
			Dim DsKontrak As String
			Dim sql, sqlp, sqla, sqlp2, sqlp3 As String
			Dim Pancang As String = cboPancang.Text
			Dim Tanggal As String = Format(dtpTanggal.Value, "dd/MM/yyyy")
			Dim Via As String = cboVia.Text
			Dim JenisBank As String
			Dim paramList As New Generic.List(Of ReportParameter)

			paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Pancang", Pancang, True))
			paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Tanggal", Tanggal, True))
			paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Via", Via, True))

			ReportName = ".RptRekapDataPetaniPembayaranKB.rdlc"
			DsKontrak = "dtRekap"

			If cbxPancang.Checked = True Then
				sqlp = "and Pancang = '" & cboPancang.Text & "' "
			Else
				sqlp = ""
			End If

			If chkmandiri.Checked = True And chkBNI.Checked = True And chkBankLain.Checked = True Then
				JenisBank = "All"
			End If

			If chkmandiri.Checked = True And chkBNI.Checked = True And chkBankLain.Checked = False Then
				JenisBank = "BNI AND Mandiri"
				sqlp2 = "and LEFT(JenisBank,50)  in ('MANDIRI','BNI') "
			End If

			If chkmandiri.Checked = True And chkBNI.Checked = False And chkBankLain.Checked = True Then
				JenisBank = "Mandiri dan Bank Lain"
				sqlp2 = "and LEFT(JenisBank,50)  NOT in ('BNI') "
			End If

			If chkmandiri.Checked = False And chkBNI.Checked = True And chkBankLain.Checked = True Then
				JenisBank = "BNI DAN Bank Lain"
				sqlp2 = "and LEFT(JenisBank,50)  NOT in ('MANDIRI') "
			End If


			If chkmandiri.Checked = True And chkBNI.Checked = False And chkBankLain.Checked = False Then
				JenisBank = "Mandiri"
				sqlp2 = "and LEFT(JenisBank,50)  in ('MANDIRI') "
			End If

			If chkmandiri.Checked = False And chkBNI.Checked = True And chkBankLain.Checked = False Then
				JenisBank = "BNI"
				sqlp2 = "and LEFT(JenisBank,50)  in ('BNI') "
			End If


			If chkmandiri.Checked = False And chkBNI.Checked = False And chkBankLain.Checked = True Then
				JenisBank = "BankLain"
				sqlp2 = "and LEFT(JenisBank,50)  not in ('MANDIRI','BNI') "
			End If

			paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("JenisBank", JenisBank, True))


			If rdKB.Checked = True And rdKC.Checked = True Then
				sqlp3 = "and JENISKB  in ('KB-A','KB-B','KC') "
			End If

			If rdKB.Checked = True And rdKC.Checked = False Then
				sqlp3 = "and JENISKB  in ('KB-A','KB-B') "
			End If

			If rdKB.Checked = False And rdKC.Checked = True Then
				sqlp3 = "and JENISKB  in ('KC') "
			End If


			If chkP1.Checked = True Then
				IndUMBy = "PSG"
			ElseIf chkP2.Checked = True Then
				IndUMBy = "RSUP"
			End If

			If rdPagi.Checked = True Then
				sql = "SELECT * FROM [RSUPAccounting].[dbo].[fnDataPetaniPembayaranKBtgl_TrnRptPSP]( '" & Format(dtpTanggal.Value, "yyyy") & "', '" & Format(dtpTanggal.Value, "MM") & "', '" & Format(dtpTanggal.Value, "dd") & "','" & IndUMBy & "') where   Amount>0 AND jenisbank is not null and WaktuPengajuan = 'PAGI'   "
			ElseIf rdSore.Checked = True Then
				sql = "SELECT * FROM [RSUPAccounting].[dbo].[fnDataPetaniPembayaranKBtgl_TrnRptPSP]( '" & Format(dtpTanggal.Value, "yyyy") & "', '" & Format(dtpTanggal.Value, "MM") & "', '" & Format(dtpTanggal.Value, "dd") & "','" & IndUMBy & "') where   Amount>0 AND jenisbank is not null and WaktuPengajuan = 'SORE'  "

			ElseIf rdAll.Checked = True Then
				sql = "SELECT * FROM [RSUPAccounting].[dbo].[fnDataPetaniPembayaranKBtgl_TrnRptPSP]( '" & Format(dtpTanggal.Value, "yyyy") & "', '" & Format(dtpTanggal.Value, "MM") & "', '" & Format(dtpTanggal.Value, "dd") & "','" & IndUMBy & "') where    Amount>0 AND jenisbank is not null   "
			End If

			sqla = sql + sqlp + sqlp2 + sqlp3 & "ORDER BY KODEBANK ,Remark1,NoRekening,NamaRekening"

			Dim Da = New SqlDataAdapter(sqla, Conn)
			Dim _Dt As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sqla)
			Dim DSource = New ReportDataSource(DsKontrak, _Dt)
			Me.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ReportName
			Me.ReportViewer1.LocalReport.DataSources.Add(DSource)

			Me.ReportViewer1.LocalReport.SetParameters(paramList)
			Dim newPageSetting As New System.Drawing.Printing.PageSettings
			newPageSetting.Margins = New System.Drawing.Printing.Margins(3, 3, 3, 3)
			newPageSetting.Landscape = True
			ReportViewer1.SetPageSettings(newPageSetting)
			Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
			Me.ReportViewer1.RefreshReport()
		Catch ex As Exception
			Me.Cursor = Cursors.Arrow
			MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
		Me.Cursor = Cursors.Arrow
	End Sub
	Private Sub CboPancang_TextUpdate(sender As Object, e As EventArgs)
		Call ui.ValidCombo(cboPancang)
	End Sub
	Private Sub CboVia_TextUpdate(sender As Object, e As EventArgs)
		Call ui.ValidCombo(cboVia)
	End Sub
	Private Sub rdUB_CheckedChanged(sender As Object, e As EventArgs) Handles rdUB.CheckedChanged
		If rdUB.Checked = True Then
			chkP1.Enabled = True
			chkP2.Enabled = True
			rdUBM.Checked = False
			rdubmkc.Checked = False
			rdKB.Checked = False
			rdKC.Checked = False
			Label3.Visible = False
			Panel3.Visible = False
			gbFilter.Enabled = True

			'dtpTanggal2.Visible = False
			Label4.Visible = False
			'dtpTanggal.Size = New Size(226, 20)
		ElseIf rdUB.Checked = False And rdKB.Checked = False And rdKC.Checked = False And rdUBM.Checked = False And rdubmkc.Checked = False And rdkomkb.Checked = False And rdkomkc.Checked = False Then
			gbFilter.Enabled = False

			dtpTanggal2.Visible = True
			Label4.Visible = True
			dtpTanggal.Size = New Size(103, 20)
		End If
	End Sub
	Private Sub rdUBM_CheckedChanged(sender As Object, e As EventArgs) Handles rdUBM.CheckedChanged
		If rdUBM.Checked = True Then
			chkP1.Enabled = True
			chkP2.Enabled = True
			rdKB.Checked = False
			rdKC.Checked = False
			rdUB.Checked = False
			Label3.Visible = False
			Panel3.Visible = False
			gbFilter.Enabled = True

			'dtpTanggal2.Visible = False
			Label4.Visible = False
			'dtpTanggal.Size = New Size(226, 20)
		ElseIf rdUB.Checked = False And rdKB.Checked = False And rdKC.Checked = False And rdUBM.Checked = False And rdubmkc.Checked = False And rdkomkb.Checked = False And rdkomkc.Checked = False Then
			gbFilter.Enabled = False

			dtpTanggal2.Visible = True
			Label4.Visible = True
			dtpTanggal.Size = New Size(103, 20)
		End If
	End Sub

	Private Sub rdKB_CheckedChanged(sender As Object, e As EventArgs) Handles rdKB.CheckedChanged
		If rdKB.Checked = True Then
			chkP1.Enabled = True
			chkP2.Enabled = True
			rdUBM.Checked = False
			rdubmkc.Checked = False
			rdUB.Checked = False
			Label3.Visible = True
			Panel3.Visible = True
			gbFilter.Enabled = True

			dtpTanggal2.Visible = False
			Label4.Visible = False
			dtpTanggal.Size = New Size(226, 20)
		ElseIf rdUB.Checked = False And rdKB.Checked = False And rdKC.Checked = False And rdUBM.Checked = False And rdubmkc.Checked = False And rdkomkb.Checked = False And rdkomkc.Checked = False Then
			gbFilter.Enabled = False
			chkP1.Enabled = False
			chkP2.Enabled = False

			dtpTanggal2.Visible = True
			Label4.Visible = True
			dtpTanggal.Size = New Size(103, 20)
		End If
	End Sub

	Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
		If rdKC.Checked = False And rdKB.Checked = False And rdUBM.Checked = False And rdUB.Checked = False And rdUBM.Checked = False And rdubmkc.Checked = False And rdkomkb.Checked = False And rdkomkc.Checked = False Then
			MsgBox("Ceklis jenis pembayaran !", MsgBoxStyle.Information)
		End If

		Me.ReportViewer1.Reset()
		ReportShow()
		Me.Cursor = Cursors.Default
	End Sub

	Private Sub LoadDetailubm()
		Dim connb As New SqlConnection(StrConnRMPApp)
		connb.Open()

		Dim sql As String
		Dim I As Integer

		dgvlist.Rows.Clear()

		Me.Cursor = Cursors.WaitCursor
		Dim sqlp, sqla, sqlp2, sqlp3 As String

		Dim Pancang As String = cboPancang.Text
		Dim Tanggal As String = Format(dtpTanggal.Value, "dd/MM/yyyy")
		Dim Via As String = cboVia.Text

		If cbxPancang.Checked = True Then
			sqlp = "and Pancang = '" & cboPancang.Text & "' "
		Else
			sqlp = ""
		End If

		If rdUBM.Checked = True And rdubmkc.Checked = True Then
			sqlp3 = "and kodebahanbaku  in ('1','3') "
		End If

		If rdUBM.Checked = True And rdubmkc.Checked = False Then
			sqlp3 = "and kodebahanbaku in ('1') "
		End If

		If rdUBM.Checked = False And rdubmkc.Checked = True Then
			sqlp3 = "and kodebahanbaku  in ('3') "
		End If

		If chkmandiri.Checked = True And chkBNI.Checked = True And chkBankLain.Checked = False Then
			sqlp2 = "and Bank  in ('MANDIRI','BNI') "
		End If

		If chkmandiri.Checked = True And chkBNI.Checked = False And chkBankLain.Checked = True Then
			sqlp2 = "and Bank  NOT in ('BNI') "
		End If

		If chkmandiri.Checked = False And chkBNI.Checked = True And chkBankLain.Checked = True Then
			sqlp2 = "and Bank NOT in ('MANDIRI') "
		End If

		If chkmandiri.Checked = True And chkBNI.Checked = False And chkBankLain.Checked = False Then
			sqlp2 = "and Bank  in ('MANDIRI') "
		End If

		If chkmandiri.Checked = False And chkBNI.Checked = True And chkBankLain.Checked = False Then
			sqlp2 = "and Bank in ('BNI') "
		End If

		If chkmandiri.Checked = False And chkBNI.Checked = False And chkBankLain.Checked = True Then
			sqlp2 = "and Bank  not in ('MANDIRI','BNI') "
		End If

		If chkPcgLuarInhil.Checked = True Then
			sqlp &= " and Pancang in (SELECT Pancang FROM [RMPApp].[dbo].[Android_tblMstPancang] where PONTIANAK IS NOT NULL) "
		Else
			sqlp &= " and Pancang in (SELECT Pancang FROM [RMPApp].[dbo].[Android_tblMstPancang] where PONTIANAK IS NULL) "
		End If

		If chkP1.Checked = True Then
			sql = "SELECT Rek_Tujuan,Rekening_Penerima,CAST(Amount AS INTEGER) AS Amount, left(REPLACE(Remark2,'PANCANG',''),12) as Remark3 , Bank, LAYANANTRF ,KODEBANK   FROM [RMPApp].[dbo].[vwRMRekapUBMP1022025] where Amount>0 AND (cast(FDate as date) between cast('" & Format(dtpTanggal.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(dtpTanggal2.Value, "yyyy-MM-dd") & "' as date)) "
		ElseIf chkP2.Checked = True Then
			sql = "SELECT Rek_Tujuan,Rekening_Penerima,CAST(Amount AS INTEGER) AS Amount , left(REPLACE(Remark2,'PANCANG',''),12)  as Remark3 , Bank, LAYANANTRF ,KODEBANK  FROM [RSUPAccounting].[dbo].[vwRMRekapUBM022025] where Amount>0 AND (cast(FDate as date) between cast('" & Format(dtpTanggal.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(dtpTanggal2.Value, "yyyy-MM-dd") & "' as date)) "
		End If

		sqla = sql + sqlp + sqlp2 + sqlp3 & "ORDER BY KODEBANK ,Remark1"



		Dim cmd2 As New SqlClient.SqlCommand(sqla, connb)
		Dim reader As SqlClient.SqlDataReader
		reader = cmd2.ExecuteReader
		I = 0
		If reader.HasRows Then

			Do While reader.Read()

				I = I + 1

				If chkP1.Checked = True Then
					dgvlist.Rows.Add(reader("Rek_Tujuan").ToString, reader("Rekening_Penerima").ToString, "TEMBILAHAN", "", "", "IDR", reader("Amount").ToString, reader("Remark3").ToString, "", reader("LAYANANTRF").ToString, reader("KODEBANK").ToString, reader("Bank").ToString, "TEMBILAHAN,,,,Y,juniyanti@rsup.co.id,,,,Y,,,,,,,,,,,,,,,,,OUR,1,E,,,")
				Else
					dgvlist.Rows.Add(reader("Rek_Tujuan").ToString, reader("Rekening_Penerima").ToString, "TEMBILAHAN", "", "", "IDR", reader("Amount").ToString, reader("Remark3").ToString, "", reader("LAYANANTRF").ToString, reader("KODEBANK").ToString, reader("Bank").ToString, "TEMBILAHAN,,,,Y,juniyanti@rsup.co.id,,,,Y,,,,,,,,,,,,,,,,,OUR,1,E,,,")
				End If
			Loop

		Else
			MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
			Exit Sub
		End If
		dgvlist.Rows.Add()
		sumtotalamount()
		connb.Close()
	End Sub
	Private Sub LoadDetailkom()
		Dim connb As New SqlConnection(StrConnRMPApp)
		connb.Open()

		Dim sql, sql2 As String
		Dim I As Integer

		dgvlist.Rows.Clear()


		Me.Cursor = Cursors.WaitCursor
		Dim ReportName, IndUMBy As String
		Dim DsKontrak As String
		Dim sqlp, sqla, sqlp2, sqlp3, sqlp4 As String
		Dim LAYANANTRF As String


		Dim Pancang As String = cboPancang.Text
		Dim Tanggal As String = Format(dtpTanggal.Value, "dd/MM/yyyy")
		Dim Via As String = cboVia.Text
		Dim JenisBank As String

		If cbxPancang.Checked = True Then
			sqlp = "and Pancang = '" & cboPancang.Text & "' "
		Else
			sqlp = ""
		End If

		If rdUBM.Checked = True And rdubmkc.Checked = True Then
			sqlp3 = "and kodebahanbaku  in ('1','3') "
		End If

		If rdUBM.Checked = True And rdubmkc.Checked = False Then
			sqlp3 = "and kodebahanbaku in ('1') "
		End If

		If rdUBM.Checked = False And rdubmkc.Checked = True Then
			sqlp3 = "and kodebahanbaku  in ('3') "
		End If

		If chkmandiri.Checked = True And chkBNI.Checked = True And chkBankLain.Checked = False Then
			sqlp2 = "and Bank  in ('MANDIRI','BNI') "
		End If

		If chkmandiri.Checked = True And chkBNI.Checked = False And chkBankLain.Checked = True Then
			sqlp2 = "and Bank  NOT in ('BNI') "
		End If

		If chkmandiri.Checked = False And chkBNI.Checked = True And chkBankLain.Checked = True Then
			sqlp2 = "and Bank NOT in ('MANDIRI') "
		End If


		If chkmandiri.Checked = True And chkBNI.Checked = False And chkBankLain.Checked = False Then
			sqlp2 = "and Bank  in ('MANDIRI') "
		End If

		If chkmandiri.Checked = False And chkBNI.Checked = True And chkBankLain.Checked = False Then
			sqlp2 = "and Bank in ('BNI') "
		End If

		If chkmandiri.Checked = False And chkBNI.Checked = False And chkBankLain.Checked = True Then
			sqlp2 = "and Bank  not in ('MANDIRI','BNI') "
		End If

		sqlp4 = " and (cast(Transdate as date) between cast('" & Format(dtpTanggal.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(dtpTanggal2.Value, "yyyy-MM-dd") & "' as date)) "

		If chkP1.Checked = True Then
			sql = " SELECT
					REPLACE(a.NoRekening, '-', '') AS Rek_Tujuan,
					a.NamaRekening AS Rekening_Penerima,
					(
					cast((replace(Total,'.0000','')) as int)-
					cast((iif(PajakNonNPWP is null,'0',left(PajakNonNPWP,len(PajakNonNPWP)-3))) as int)-
					cast((iif(PajakNPWP is null,'0',left(PajakNPWP,len(PajakNPWP)-3))) as int)
					) AS Amount,
					REPLACE(REPLACE('KOM' + a.Pancang, ' ', ''), 'PANCANG', '') AS Remark3,
					a.Bank,
					CASE
						WHEN (DATENAME(dw, GETDATE()) IN ('Saturday', 'Sunday') OR CAST(GETDATE() AS DATE) IN (SELECT CAST(tanggal AS DATE) AS tanggal FROM rmpapp..tblmstobu))
							AND a.Factory = 'PSG' AND ((ISNULL(b.KodeBank, '') <> '0080017')) THEN 'OBU'
						WHEN (DATENAME(dw, GETDATE()) NOT IN ('Saturday', 'Sunday') OR CAST(GETDATE() AS DATE) NOT IN (SELECT CAST(tanggal AS DATE) AS tanggal FROM rmpapp..tblmstobu))
							AND a.Factory = 'PSG' AND ((ISNULL(b.KodeBank, '') <> '0080017')) THEN 'LBU'
						WHEN ((ISNULL(b.KodeBank, '')) = '0080017') THEN 'IBU'
					END AS LAYANANTRF,
					b.KodeBank
					FROM
						RSUPAccounting..vwRMTrnBiayaSaranaMuat AS a
						LEFT OUTER JOIN RSUPAccounting..TblRM_MstBank AS b ON a.Bank = b.JenisBank
					WHERE
					a.Factory = 'PSG' "
		ElseIf chkP2.Checked = True Then
			sql = " SELECT
					REPLACE(a.NoRekening, '-', '') AS Rek_Tujuan,
					a.NamaRekening AS Rekening_Penerima,
					(
					cast((replace(Total,'.0000','')) as int)-
					cast((iif(PajakNonNPWP is null,'0',left(PajakNonNPWP,len(PajakNonNPWP)-3))) as int)-
					cast((iif(PajakNPWP is null,'0',left(PajakNPWP,len(PajakNPWP)-3))) as int)
					) AS Amount,
					REPLACE(REPLACE('KOM' + a.Pancang, ' ', ''), 'PANCANG', '') AS Remark3,
					a.Bank,
					CASE
						WHEN (DATENAME(dw, GETDATE()) IN ('Saturday', 'Sunday') OR CAST(GETDATE() AS DATE) IN (SELECT CAST(tanggal AS DATE) AS tanggal FROM rmpapp..tblmstobu))
							AND a.Factory = 'RSUP' AND ((ISNULL(b.KodeBank, '') <> '0080017')) THEN 'OBU'
						WHEN (DATENAME(dw, GETDATE()) NOT IN ('Saturday', 'Sunday') OR CAST(GETDATE() AS DATE) NOT IN (SELECT CAST(tanggal AS DATE) AS tanggal FROM rmpapp..tblmstobu))
							AND a.Factory = 'RSUP' AND ((ISNULL(b.KodeBank, '') <> '0080017')) THEN 'LBU'
						WHEN ((ISNULL(b.KodeBank, '')) = '0080017') THEN 'IBU'
					END AS LAYANANTRF,
					b.KodeBank
					FROM
						RSUPAccounting..vwRMTrnBiayaSaranaMuat AS a
						LEFT OUTER JOIN RSUPAccounting..TblRM_MstBank AS b ON a.Bank = b.JenisBank
					WHERE
					a.Factory = 'RSUP' "
		End If

		sqla = sql + sqlp + sqlp2 + sqlp3 + sqlp4 & " ORDER BY a.Bank ASC "

		Dim cmd2 As New SqlClient.SqlCommand(sqla, connb)
		Dim reader As SqlClient.SqlDataReader
		reader = cmd2.ExecuteReader
		I = 0
		If reader.HasRows Then

			Do While reader.Read()

				I = I + 1

				If chkP1.Checked = True Then
					dgvlist.Rows.Add(reader("Rek_Tujuan").ToString, reader("Rekening_Penerima").ToString, "TEMBILAHAN", "", "", "IDR", reader("Amount").ToString, reader("Remark3").ToString, "", reader("LAYANANTRF").ToString, reader("KODEBANK").ToString, reader("Bank").ToString, "TEMBILAHAN,,,,Y,juniyanti@rsup.co.id,,,,Y,,,,,,,,,,,,,,,,,OUR,1,E,,,")
				Else
					dgvlist.Rows.Add(reader("Rek_Tujuan").ToString, reader("Rekening_Penerima").ToString, "TEMBILAHAN", "", "", "IDR", reader("Amount").ToString, reader("Remark3").ToString, "", reader("LAYANANTRF").ToString, reader("KODEBANK").ToString, reader("Bank").ToString, "TEMBILAHAN,,,,Y,juniyanti@rsup.co.id,,,,Y,,,,,,,,,,,,,,,,,OUR,1,E,,,")
				End If
			Loop

		Else
			MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
			Exit Sub
		End If
		dgvlist.Rows.Add()
		sumtotalamount()
		connb.Close()
	End Sub

	Private Sub LoadDetailub()
		Dim connb As New SqlConnection(StrConnRMPApp)
		connb.Open()

		Dim sql, sql2 As String
		Dim I As Integer

		dgvlist.Rows.Clear()

		Me.Cursor = Cursors.WaitCursor
		Dim ReportName, IndUMBy As String
		Dim DsKontrak As String
		Dim sqlp, sqla, sqlp2, sqlp3 As String
		Dim LAYANANTRF As String


		Dim Pancang As String = cboPancang.Text
		Dim Tanggal As String = Format(dtpTanggal.Value, "dd/MM/yyyy")
		Dim Via As String = cboVia.Text
		Dim JenisBank As String

		If cbxPancang.Checked = True Then
			sqlp = "and Pancang = '" & cboPancang.Text & "' "
		Else
			sqlp = ""
		End If

		If rdKB.Checked = True And rdKC.Checked = True Then
			sqlp3 = "and JENISKB  in ('KB-A','KB-B','KC') "
		End If

		If rdKB.Checked = True And rdKC.Checked = False Then
			sqlp3 = "and JENISKB  in ('KB-A','KB-B') "
		End If

		If rdKB.Checked = False And rdKC.Checked = True Then
			sqlp3 = "and JENISKB  in ('KC') "
		End If

		If chkmandiri.Checked = True And chkBNI.Checked = True And chkBankLain.Checked = False Then
			JenisBank = "BNI AND Mandiri"
			sqlp2 = "and Bank in ('MANDIRI','BNI') "
		End If

		If chkmandiri.Checked = True And chkBNI.Checked = False And chkBankLain.Checked = True Then
			JenisBank = "Mandiri dan Bank Lain"
			sqlp2 = "and Bank NOT in ('BNI') "
		End If

		If chkmandiri.Checked = False And chkBNI.Checked = True And chkBankLain.Checked = True Then
			JenisBank = "BNI DAN Bank Lain"
			sqlp2 = "and Bank NOT in ('MANDIRI') "
		End If


		If chkmandiri.Checked = True And chkBNI.Checked = False And chkBankLain.Checked = False Then
			JenisBank = "Mandiri"
			sqlp2 = "and Bank  in ('MANDIRI') "
		End If

		If chkmandiri.Checked = False And chkBNI.Checked = True And chkBankLain.Checked = False Then
			JenisBank = "BNI"
			sqlp2 = "and Bank  in ('BNI') "
		End If


		If chkmandiri.Checked = False And chkBNI.Checked = False And chkBankLain.Checked = True Then
			JenisBank = "BankLain"
			sqlp2 = "and Bank  not in ('MANDIRI','BNI') "
		End If

		If chkP1.Checked = True Then
			IndUMBy = "PSG"
		ElseIf chkP2.Checked = True Then
			IndUMBy = "RSUP"
		End If


		If chkP1.Checked = True Then
			sql = "SELECT Rek_Tujuan,Rekening_Penerima,CAST(Amount AS INTEGER) AS Amount,left(REPLACE(Remark1,'PANCANG',''),12) as Remark3  , Bank, LAYANANTRF ,KODEBANK ,FDate FROM [RMPApp].[dbo].[vwRMRekapUBP1_032025] WHERE Amount>0  AND (cast(FDate as date) between cast('" & Format(dtpTanggal.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(dtpTanggal2.Value, "yyyy-MM-dd") & "' as date)) "
		ElseIf chkP2.Checked = True Then
			sql = "SELECT Rek_Tujuan,Rekening_Penerima,CAST(Amount AS INTEGER) AS Amount,left(REPLACE(Remark1,'PANCANG',''),12) as Remark3  , Bank, LAYANANTRF ,KODEBANK ,FDate FROM [RSUPAccounting].[dbo].[vwRMRekapUB_022025] WHERE Amount>0  AND (cast(FDate as date) between cast('" & Format(dtpTanggal.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(dtpTanggal2.Value, "yyyy-MM-dd") & "' as date)) "
		End If

		sqla = sql + sqlp + sqlp2 + sqlp3 & " ORDER BY KODEBANK ,Remark1"


		Dim cmd2 As New SqlClient.SqlCommand(sqla, connb)
		Dim reader As SqlClient.SqlDataReader
		reader = cmd2.ExecuteReader
		I = 0
		If reader.HasRows Then
			Do While reader.Read()
				I = I + 1
				If chkP1.Checked = True Then
					dgvlist.Rows.Add(reader("Rek_Tujuan").ToString, reader("Rekening_Penerima").ToString, "TEMBILAHAN", "", "", "IDR", reader("Amount").ToString, reader("Remark3").ToString, "", reader("LAYANANTRF").ToString, reader("KODEBANK").ToString, reader("Bank").ToString, "TEMBILAHAN,,,,Y,juniyanti@rsup.co.id,,,,Y,,,,,,,,,,,,,,,,,OUR,1,E,,,")
				Else
					dgvlist.Rows.Add(reader("Rek_Tujuan").ToString, reader("Rekening_Penerima").ToString, "TEMBILAHAN", "", "", "IDR", reader("Amount").ToString, reader("Remark3").ToString, "", reader("LAYANANTRF").ToString, reader("KODEBANK").ToString, reader("Bank").ToString, "TEMBILAHAN,,,,Y,juniyanti@rsup.co.id,,,,Y,,,,,,,,,,,,,,,,,OUR,1,E,,,")
				End If
			Loop
		Else
			MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
			Exit Sub
		End If
		dgvlist.Rows.Add()
		sumtotalamount()
		connb.Close()
	End Sub
	Private Sub LoadDetail()
		Dim connb As New SqlConnection(StrConnRMPApp)
		connb.Open()

		Dim sql, sql2 As String
		Dim I As Integer

		dgvlist.Rows.Clear()


		Me.Cursor = Cursors.WaitCursor
		Dim ReportName, IndUMBy As String
		Dim DsKontrak As String
		Dim sqlp, sqla, sqlp2, sqlp3 As String
		Dim LAYANANTRF As String


		Dim Pancang As String = cboPancang.Text
		Dim Tanggal As String = Format(dtpTanggal.Value, "dd/MM/yyyy")
		Dim Via As String = cboVia.Text
		Dim JenisBank As String

		If cbxPancang.Checked = True Then
			sqlp = "And Pancang = '" & cboPancang.Text & "' "
		Else
			sqlp = ""
		End If

		If rdKB.Checked = True And rdKC.Checked = True Then
			sqlp3 = "and JENISKB  in ('KB-A','KB-B','KC') "
		End If

		If rdKB.Checked = True And rdKC.Checked = False Then
			sqlp3 = "and JENISKB  in ('KB-A','KB-B') "
		End If

		If rdKB.Checked = False And rdKC.Checked = True Then
			sqlp3 = "and JENISKB  in ('KC') "
		End If

		If chkmandiri.Checked = True And chkBNI.Checked = True And chkBankLain.Checked = False Then
			JenisBank = "BNI AND Mandiri"
			sqlp2 = "and LEFT(JenisBank,50)  in ('MANDIRI','BNI') "
		End If

		If chkmandiri.Checked = True And chkBNI.Checked = False And chkBankLain.Checked = True Then
			JenisBank = "Mandiri dan Bank Lain"
			sqlp2 = "and LEFT(JenisBank,50)  NOT in ('BNI') "
		End If

		If chkmandiri.Checked = False And chkBNI.Checked = True And chkBankLain.Checked = True Then
			JenisBank = "BNI DAN Bank Lain"
			sqlp2 = "and LEFT(JenisBank,50)  NOT in ('MANDIRI') "
		End If

		If chkmandiri.Checked = True And chkBNI.Checked = False And chkBankLain.Checked = False Then
			JenisBank = "Mandiri"
			sqlp2 = "and LEFT(JenisBank,50)  in ('MANDIRI') "
		End If

		If chkmandiri.Checked = False And chkBNI.Checked = True And chkBankLain.Checked = False Then
			JenisBank = "BNI"
			sqlp2 = "and LEFT(JenisBank,50)  in ('BNI') "
		End If


		If chkmandiri.Checked = False And chkBNI.Checked = False And chkBankLain.Checked = True Then
			JenisBank = "BankLain"
			sqlp2 = "and LEFT(JenisBank,50)  not in ('MANDIRI','BNI') "
		End If

		If chkP1.Checked = True Then
			IndUMBy = "PSG"
		ElseIf chkP2.Checked = True Then
			IndUMBy = "RSUP"
		End If


		If rdPagi.Checked = True Then
			sql = "SELECT NoRekening, left(NamaRekening,40) as NamaRekening, CAST(Amount AS INTEGER) AS Amount,Remark1 as Remark1,left(Remark3,12) as Remark3, NoHP ,KODEBANK ,JenisBank,LAYANANTRF  FROM [RSUPAccounting].[dbo].[fnDataPetaniPembayaranKBTgl_TrnRpt_14112025]( '" & Format(dtpTanggal.Value, "yyyy") & "', '" & Format(dtpTanggal.Value, "MM") & "', '" & Format(dtpTanggal.Value, "dd") & "','" & IndUMBy & "') where Amount>0 AND  jenisbank is not null and WaktuPengajuan = 'PAGI'   "
		ElseIf rdSore.Checked = True Then
			sql = "SELECT NoRekening, left(NamaRekening,40) as NamaRekening, CAST(Amount AS INTEGER) AS Amount,Remark1 as Remark1,left(Remark3,12) as Remark3, NoHP  ,KODEBANK,JenisBank,LAYANANTRF   FROM [RSUPAccounting].[dbo].[fnDataPetaniPembayaranKBTgl_TrnRpt_14112025]( '" & Format(dtpTanggal.Value, "yyyy") & "', '" & Format(dtpTanggal.Value, "MM") & "', '" & Format(dtpTanggal.Value, "dd") & "','" & IndUMBy & "') where Amount>0 AND jenisbank is not null  and WaktuPengajuan = 'SORE'  "
		ElseIf rdAll.Checked = True Then
			sql = "SELECT NoRekening, left(NamaRekening,40) as NamaRekening, CAST(Amount AS INTEGER) AS Amount,Remark1 as Remark1,left(Remark3,12) as Remark3, NoHP  ,KODEBANK,JenisBank,LAYANANTRF    FROM [RSUPAccounting].[dbo].[fnDataPetaniPembayaranKBTgl_TrnRpt_14112025]( '" & Format(dtpTanggal.Value, "yyyy") & "', '" & Format(dtpTanggal.Value, "MM") & "', '" & Format(dtpTanggal.Value, "dd") & "','" & IndUMBy & "') where Amount>0 AND jenisbank is not null   "
		End If


		sqla = sql + sqlp + sqlp2 + sqlp3 & "ORDER BY KODEBANK ,Remark1,NoRekening,NamaRekening"

		Dim cmd2 As New SqlClient.SqlCommand(sqla, connb)
		' Tambah waktu timeout, misal 300 detik (5 menit)
		cmd2.CommandTimeout = 300
		Dim reader As SqlClient.SqlDataReader
		reader = cmd2.ExecuteReader
		I = 0

		If reader.HasRows Then
			Do While reader.Read()
				I = I + 1
				If chkP1.Checked = True Then
					dgvlist.Rows.Add(reader("NoRekening").ToString, reader("NamaRekening").ToString, "TEMBILAHAN", "", "", "IDR", reader("Amount").ToString, reader("Remark3").ToString, "", reader("LAYANANTRF").ToString, reader("KODEBANK").ToString, reader("JenisBank").ToString, "TEMBILAHAN,,,,Y,juniyanti@rsup.co.id,,,,Y,,,,,,,,,,,,,,,,,OUR,1,E,,,")
				Else
					dgvlist.Rows.Add(reader("NoRekening").ToString, reader("NamaRekening").ToString, "TEMBILAHAN", "", "", "IDR", reader("Amount").ToString, reader("Remark3").ToString, "", reader("LAYANANTRF").ToString, reader("KODEBANK").ToString, reader("JenisBank").ToString, "TEMBILAHAN,,,,Y,juniyanti@rsup.co.id,,,,Y,,,,,,,,,,,,,,,,,OUR,1,E,,,")
				End If
			Loop
		Else
			MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
			Exit Sub
		End If
		dgvlist.Rows.Add()
		sumtotalamount()
		connb.Close()
	End Sub


	Private Sub LoadDetailPSP()
		Dim connb As New SqlConnection(StrConnRMPApp)
		connb.Open()

		Dim sql, sql2 As String
		Dim I As Integer
		dgvlist.Rows.Clear()

		Me.Cursor = Cursors.WaitCursor
		Dim ReportName, IndUMBy As String
		Dim DsKontrak As String
		Dim sqlp, sqla, sqlp2, sqlp3 As String
		Dim LAYANANTRF As String


		Dim Pancang As String = cboPancang.Text
		Dim Tanggal As String = Format(dtpTanggal.Value, "dd/MM/yyyy")
		Dim Via As String = cboVia.Text
		Dim JenisBank As String

		If cbxPancang.Checked = True Then
			sqlp = "And Pancang = '" & cboPancang.Text & "' "
		Else
			sqlp = ""
		End If

		If rdKB.Checked = True And rdKC.Checked = True Then
			sqlp3 = "and JENISKB  in ('KB-A','KB-B','KC') "
		End If

		If rdKB.Checked = True And rdKC.Checked = False Then
			sqlp3 = "and JENISKB  in ('KB-A','KB-B') "
		End If

		If rdKB.Checked = False And rdKC.Checked = True Then
			sqlp3 = "and JENISKB  in ('KC') "
		End If

		If chkmandiri.Checked = True And chkBNI.Checked = True And chkBankLain.Checked = False Then
			JenisBank = "BNI AND Mandiri"
			sqlp2 = "and LEFT(JenisBank,50)  in ('MANDIRI','BNI') "
		End If

		If chkmandiri.Checked = True And chkBNI.Checked = False And chkBankLain.Checked = True Then
			JenisBank = "Mandiri dan Bank Lain"
			sqlp2 = "and LEFT(JenisBank,50)  NOT in ('BNI') "
		End If

		If chkmandiri.Checked = False And chkBNI.Checked = True And chkBankLain.Checked = True Then
			JenisBank = "BNI DAN Bank Lain"
			sqlp2 = "and LEFT(JenisBank,50)  NOT in ('MANDIRI') "
		End If

		If chkmandiri.Checked = True And chkBNI.Checked = False And chkBankLain.Checked = False Then
			JenisBank = "Mandiri"
			sqlp2 = "and LEFT(JenisBank,50)  in ('MANDIRI') "
		End If

		If chkmandiri.Checked = False And chkBNI.Checked = True And chkBankLain.Checked = False Then
			JenisBank = "BNI"
			sqlp2 = "and LEFT(JenisBank,50)  in ('BNI') "
		End If


		If chkmandiri.Checked = False And chkBNI.Checked = False And chkBankLain.Checked = True Then
			JenisBank = "BankLain"
			sqlp2 = "and LEFT(JenisBank,50)  not in ('MANDIRI','BNI') "
		End If

		If chkP1.Checked = True Then
			IndUMBy = "PSG"
		ElseIf chkP2.Checked = True Then
			IndUMBy = "RSUP"
		End If

		If rdPagi.Checked = True Then
			sql = "SELECT NoRekening, left(NamaRekening,40) as NamaRekening, CAST(Amount AS INTEGER) AS Amount,Remark1 as Remark1,left(Remark3,12) as Remark3, NoHP ,KODEBANK ,JenisBank,LAYANANTRF  FROM [RSUPAccounting].[dbo].[fnDataPetaniPembayaranKBTgl_TrnRptPSP]( '" & Format(dtpTanggal.Value, "yyyy") & "', '" & Format(dtpTanggal.Value, "MM") & "', '" & Format(dtpTanggal.Value, "dd") & "','" & IndUMBy & "') where Amount>0 AND  jenisbank is not null and WaktuPengajuan = 'PAGI'   "
		ElseIf rdSore.Checked = True Then
			sql = "SELECT NoRekening, left(NamaRekening,40) as NamaRekening, CAST(Amount AS INTEGER) AS Amount,Remark1 as Remark1,left(Remark3,12) as Remark3, NoHP  ,KODEBANK,JenisBank,LAYANANTRF   FROM [RSUPAccounting].[dbo].[fnDataPetaniPembayaranKBTgl_TrnRptPSP]( '" & Format(dtpTanggal.Value, "yyyy") & "', '" & Format(dtpTanggal.Value, "MM") & "', '" & Format(dtpTanggal.Value, "dd") & "','" & IndUMBy & "') where Amount>0 AND jenisbank is not null  and WaktuPengajuan = 'SORE'  "
		ElseIf rdAll.Checked = True Then
			sql = "SELECT NoRekening, left(NamaRekening,40) as NamaRekening, CAST(Amount AS INTEGER) AS Amount,Remark1 as Remark1,left(Remark3,12) as Remark3, NoHP  ,KODEBANK,JenisBank,LAYANANTRF    FROM [RSUPAccounting].[dbo].[fnDataPetaniPembayaranKBTgl_TrnRptPSP]( '" & Format(dtpTanggal.Value, "yyyy") & "', '" & Format(dtpTanggal.Value, "MM") & "', '" & Format(dtpTanggal.Value, "dd") & "','" & IndUMBy & "') where Amount>0 AND jenisbank is not null   "
		End If


		sqla = sql + sqlp + sqlp2 + sqlp3 & "ORDER BY KODEBANK ,Remark1,NoRekening,NamaRekening"

		Dim cmd2 As New SqlClient.SqlCommand(sqla, connb)
		Dim reader As SqlClient.SqlDataReader
		reader = cmd2.ExecuteReader
		I = 0

		If reader.HasRows Then
			Do While reader.Read()
				I = I + 1
				If chkP1.Checked = True Then
					dgvlist.Rows.Add(reader("NoRekening").ToString, reader("NamaRekening").ToString, "TEMBILAHAN", "", "", "IDR", reader("Amount").ToString, reader("Remark3").ToString, "", reader("LAYANANTRF").ToString, reader("KODEBANK").ToString, reader("JenisBank").ToString, "TEMBILAHAN,,,,Y,juniyanti@rsup.co.id,,,,Y,,,,,,,,,,,,,,,,,OUR,1,E,,,")
				Else
					dgvlist.Rows.Add(reader("NoRekening").ToString, reader("NamaRekening").ToString, "TEMBILAHAN", "", "", "IDR", reader("Amount").ToString, reader("Remark3").ToString, "", reader("LAYANANTRF").ToString, reader("KODEBANK").ToString, reader("JenisBank").ToString, "TEMBILAHAN,,,,Y,juniyanti@rsup.co.id,,,,Y,,,,,,,,,,,,,,,,,OUR,1,E,,,")
				End If
			Loop
		Else
			MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
			Exit Sub
		End If
		dgvlist.Rows.Add()
		sumtotalamount()
		connb.Close()
	End Sub


	Private Sub cbxPancang_CheckedChanged(sender As Object, e As EventArgs) Handles cbxPancang.CheckedChanged
		If cbxPancang.Checked = True Then
			Panel1.Enabled = True
		Else
			cboPancang.SelectedIndex = -1
			Panel1.Enabled = False
		End If
	End Sub

	Private Sub chkP1_CheckedChanged(sender As Object, e As EventArgs) Handles chkP1.CheckedChanged
		If chkP1.Checked = True Then
			chkP2.Checked = False
		End If
	End Sub

	Private Sub chkP2_CheckedChanged(sender As Object, e As EventArgs) Handles chkP2.CheckedChanged
		If chkP2.Checked = True Then
			chkP1.Checked = False
		End If
	End Sub


	Private Sub SaveGridDataInFile(ByRef fName As String)
		Using fSave As New SaveFileDialog
			fSave.FileName = fName

			If fSave.ShowDialog = Windows.Forms.DialogResult.OK Then
				fName = fSave.FileName
			Else
				Exit Sub
			End If
		End Using
		Try
			'Create Empty String
			Dim thecsvfile As String = String.Empty
			'get column headers
			'trim the last comma
			thecsvfile = thecsvfile.TrimEnd(",")

			Dim strROW As String = dgvlist.Rows.Count - 1
			Dim STRAMOUNT As String = dgvlist.Rows(dgvlist.Rows.Count - 1).Cells("Amount").Value().ToString

			If chkP1.Checked = True Then
				thecsvfile = "P," + Format(dtpTanggal.Value, "yyyyMMdd").ToString + "," + "1080097979190," + strROW + "," + STRAMOUNT + ",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,"
			Else
				thecsvfile = "P," + Format(dtpTanggal.Value, "yyyyMMdd").ToString + "," + "1080066566770," + strROW + "," + STRAMOUNT + ",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,"
			End If


			thecsvfile = thecsvfile & vbCr & vbLf

			Dim lines As New List(Of String)
			Dim cells As New List(Of String)

			Dim TEX As Integer
			TEX = 0


			Dim TEX2, TEXTROW As Integer
			TEX2 = 0
			TEXTROW = 0
			For Each row As DataGridViewRow In dgvlist.Rows
				'get the cells
				TEX2 = 0
				TEXTROW = TEXTROW + 1
				If TEXTROW <> strROW + 1 Then
					For Each cell As DataGridViewCell In row.Cells
						If TEX2 = 12 Then
							thecsvfile = thecsvfile & cell.FormattedValue
						Else
							thecsvfile = thecsvfile & cell.FormattedValue & ","
						End If
						TEX2 = TEX2 + 1

					Next
				End If
				'Jika Mandiri Tidak Perlu Kode Bank
				thecsvfile = Replace(thecsvfile, "0080017", "") & vbCr & vbLf
			Next

			Dim csvString As String = String.Join(Environment.NewLine, thecsvfile.ToArray)
			IO.File.WriteAllText(fName, csvString)
		Catch e As Exception
			MessageBox.Show("Error occured while writing to the file." + e.ToString())
		Finally

		End Try
	End Sub

	Public Sub sumtotalamount()

		Dim a As Integer
		Dim b As Integer
		Dim c As Integer
		a = dgvlist.RowCount
		b = a - 1
		c = a - 2

		Dim sumnetto As Double = 0
		For i = 0 To dgvlist.RowCount - 1
			sumnetto += If(IsDBNull(dgvlist.Rows(i).Cells("Amount").Value()) = True, 0, Val(dgvlist.Rows(i).Cells("Amount").Value()))
		Next i

		dgvlist.Rows(b).Cells(0).Value = "Total"
		dgvlist.Rows(b).Cells(1).Value = ""
		dgvlist.Rows(b).Cells(3).Value = ""
		dgvlist.Rows(b).Cells(4).Value = ""
		dgvlist.Rows(b).Cells(5).Value = ""
		dgvlist.Rows(b).Cells("Amount").Value = Val(sumnetto.ToString)
		dgvlist.Rows(b).ReadOnly = True

		For red = 0 To dgvlist.ColumnCount - 1
			dgvlist.Rows(b - 1).Cells(red).Style.BackColor = Color.White
			dgvlist.Rows(b).Cells(red).ReadOnly = True
			dgvlist.Rows(b).Cells(red).Style.BackColor = Color.LightBlue
		Next red
		dgvlist.Columns(0).Width = 80

	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Dim pengajuan, pembayaran, jenisbank As String

		If rdPagi.Checked = True Then
			pengajuan = "Pagi"
		End If
		If rdSore.Checked = True Then
			pengajuan = "Sore"
		End If
		If rdAll.Checked = True Then
			pengajuan = "All"
		End If


		If rdUB.Checked = True Then
			pembayaran = "UB"
		End If
		If rdUBM.Checked = True Then
			pembayaran = "UBMKB"
		End If

		If rdubmkc.Checked = True Then
			pembayaran = "UBMKC"
		End If

		If rdUBM.Checked = True And rdubmkc.Checked = True Then
			pembayaran = "UBMKB-KC"
		End If


		If rdKB.Checked = True Then
			pembayaran = "KB"
		End If


		If rdKB.Checked = True And rdKC.Checked = True Then
			pembayaran = "KB-KC"
		End If


		If rdKC.Checked = True Then
			pembayaran = "KC"
		End If

		If rdKC.Checked = True And rdKB.Checked = True Then
			pembayaran = "KB-KC"
		End If

		If chkmandiri.Checked = True And chkBNI.Checked = True And chkBankLain.Checked = True Then
			jenisbank = "All Bank"
		End If

		If chkmandiri.Checked = True And chkBNI.Checked = True And chkBankLain.Checked = False Then
			jenisbank = "BNI AND Mandiri"
		End If

		If chkmandiri.Checked = True And chkBNI.Checked = True And chkBankLain.Checked = False Then
			jenisbank = "BNI AND Mandiri"
		End If
		If chkmandiri.Checked = True And chkBNI.Checked = False And chkBankLain.Checked = True Then
			jenisbank = "Mandiri dan Bank Lain"
		End If
		If chkmandiri.Checked = False And chkBNI.Checked = True And chkBankLain.Checked = True Then
			jenisbank = "BNI DAN Bank Lain"
		End If
		If chkmandiri.Checked = True And chkBNI.Checked = False And chkBankLain.Checked = False Then
			jenisbank = "Mandiri"
		End If
		If chkmandiri.Checked = False And chkBNI.Checked = True And chkBankLain.Checked = False Then
			jenisbank = "BNI"
		End If
		If chkmandiri.Checked = False And chkBNI.Checked = False And chkBankLain.Checked = True Then
			jenisbank = "BankLain"
		End If

		SaveGridDataInFile(pembayaran + " " + Replace(dtpTanggal.Text, "/", "") + pengajuan + " " + jenisbank + ".csv")

	End Sub


	Private Sub rdKC_CheckedChanged(sender As Object, e As EventArgs) Handles rdKC.CheckedChanged
		If rdKC.Checked = True Then
			chkP1.Enabled = True
			chkP2.Enabled = True
			rdUBM.Checked = False
			rdUB.Checked = False
			rdubmkc.Checked = False
			Label3.Visible = True
			Panel3.Visible = True
			gbFilter.Enabled = True

			dtpTanggal2.Visible = False
			Label4.Visible = False
			dtpTanggal.Size = New Size(226, 20)
		ElseIf rdUB.Checked = False And rdKB.Checked = False And rdKC.Checked = False And rdUBM.Checked = False And rdubmkc.Checked = False And rdkomkb.Checked = False And rdkomkc.Checked = False Then
			gbFilter.Enabled = False
			chkP1.Enabled = False
			chkP2.Enabled = False

			dtpTanggal2.Visible = True
			Label4.Visible = True
			dtpTanggal.Size = New Size(103, 20)
		End If
	End Sub

	Private Sub rdubmkc_CheckedChanged(sender As Object, e As EventArgs) Handles rdubmkc.CheckedChanged
		If rdubmkc.Checked = True Then
			chkP1.Enabled = True
			chkP2.Enabled = True
			rdKB.Checked = False
			rdKC.Checked = False
			rdUB.Checked = False
			Label3.Visible = False
			Panel3.Visible = False
			gbFilter.Enabled = True

			'dtpTanggal2.Visible = False
			Label4.Visible = False
			'dtpTanggal.Size = New Size(226, 20)
		ElseIf rdUB.Checked = False And rdKB.Checked = False And rdKC.Checked = False And rdUBM.Checked = False And rdubmkc.Checked = False And rdkomkb.Checked = False And rdkomkc.Checked = False Then
			gbFilter.Enabled = False

			dtpTanggal2.Visible = True
			Label4.Visible = True
			dtpTanggal.Size = New Size(103, 20)
		End If
	End Sub

	Private Sub Palembang_CheckedChanged(sender As Object, e As EventArgs) Handles CHKPSP.CheckedChanged, chkPcgLuarInhil.CheckedChanged
		Call ShowPancang()
	End Sub

	Private Sub rdkomkb_CheckedChanged(sender As Object, e As EventArgs) Handles rdkomkb.CheckedChanged
		If rdkomkb.Checked = True Then
			chkP1.Enabled = True
			chkP2.Enabled = True
			rdKB.Checked = False
			rdKC.Checked = False
			rdUB.Checked = False
			Label3.Visible = False
			Panel3.Visible = False
			gbFilter.Enabled = True

			dtpTanggal2.Visible = True
			Label4.Visible = True
			dtpTanggal.Size = New Size(103, 20)
		ElseIf rdUB.Checked = False And rdKB.Checked = False And rdKC.Checked = False And rdUBM.Checked = False And rdubmkc.Checked = False And rdkomkb.Checked = False And rdkomkc.Checked = False Then
			gbFilter.Enabled = False

			dtpTanggal2.Visible = False
			Label4.Visible = False
			dtpTanggal.Size = New Size(226, 20)
		End If
	End Sub

	Private Sub rdkomkc_CheckedChanged(sender As Object, e As EventArgs) Handles rdkomkc.CheckedChanged
		If rdkomkc.Checked = True Then
			chkP1.Enabled = True
			chkP2.Enabled = True
			rdKB.Checked = False
			rdKC.Checked = False
			rdUB.Checked = False
			Label3.Visible = False
			Panel3.Visible = False
			gbFilter.Enabled = True

			dtpTanggal2.Visible = True
			Label4.Visible = True
			dtpTanggal.Size = New Size(103, 20)
		ElseIf rdUB.Checked = False And rdKB.Checked = False And rdKC.Checked = False And rdUBM.Checked = False And rdubmkc.Checked = False And rdkomkb.Checked = False And rdkomkc.Checked = False Then
			gbFilter.Enabled = False

			dtpTanggal2.Visible = False
			Label4.Visible = False
			dtpTanggal.Size = New Size(226, 20)
		End If
	End Sub

	Private Sub chkJenisBayar_CheckedChanged(sender As Object, e As EventArgs) Handles chkJenisBayar.CheckedChanged
		If chkJenisBayar.Checked = True Then
			cboJenisBayar.Enabled = True
		Else
			cboJenisBayar.Enabled = False
		End If
	End Sub
End Class
