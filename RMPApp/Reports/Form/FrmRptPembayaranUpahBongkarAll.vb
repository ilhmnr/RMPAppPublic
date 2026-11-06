Imports System.Data.SqlClient
Imports System.Globalization
Imports Microsoft.Reporting.WinForms

Public Class FrmRptPembayaranUpahBongkarAll
	Public Conn As SqlConnection
	Dim _Dt As DataTable = New DataTable()

	Private Sub FrmRptPembayaranUpahBongkarAll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Me.ReportViewer1.RefreshReport()
		ShowPancang()
		Modul_RMP.Combo.SetJenisBank(cboJenisBank)
		btnPrint.Enabled = False
		dtp1.Enabled = False
		dtp2.Enabled = False
		cboPancang.Enabled = False
		cboJenisBank.Enabled = False
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

	Sub ShowPancang()
		Dim cn As New SqlConnection(StrConnRMPApp)
		Dim sql As String
		sql = "SELECT [Pancang] FROM [RMPApp].[dbo].[Android_tblMstPancang] order by Pancang"
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

	Sub ReportShow()
		'Try
		Me.Cursor = Cursors.WaitCursor
			Dim ReportName As String
			Dim DsKontrak As String
			Dim sql, sql1, sql2, sql3, sql4 As String
			Dim i As Integer = 2

			Dim Tanggal1 As String = Format(dtp1.Value, "dd/MM/yyyy")
			Dim Tanggal2 As String = Format(dtp2.Value, "dd/MM/yyyy")
			Dim Minggu As String = txtMinggu.Text
			Dim getDate As String = Format(Now(), "dd/MM/yyyy")
			Dim NamaDibuat As String = ClsSession.UserID
			Dim Pancang As String = cboPancang.Text
			Dim paramList As New Generic.List(Of ReportParameter)
			Dim Tujuan As String = ""

			If chkPCG.Checked = True Then
				paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Minggu", Minggu, True))
				paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Pancang", Pancang, True))

				ReportName = ".rptPembayaranUBPerPancang.rdlc"
				DsKontrak = "dtUBPerPCG"

				If cboPancang.Text = "" Then
					MsgBox("Silahkan Pilih Pancang !", MsgBoxStyle.Exclamation, AT)
					Exit Sub
				End If

				If chkP1.Checked = True Then
					If rdBelumBayar.Checked = True Then
						sql1 = "SELECT a.Trip,a.TglMasukkapal,a.IDPancang,a.IDPancang2,a.Pancang,a.IDKapal,a.KapalName,a.Qty AS TOTALMUATAN,a.Harga,(a.Qty*a.Harga) - a.BebanRejectKB  AS TotalUpahBongkar,
								a.BayarVia,a.IDPetaniRek +'-'+ isnull(a.NamaRekening,b.NamaSup) as NamaRekening,a.NoRek,a.Bank,a.PajakNPWP as Pajak 
								FROM RMPApp..vwRMTrnUpahBongkarDtlP1_032025 as a left join
								RSUPAccounting.dbo.tblRMMstSupplier as b on a.IDPetaniRek=b.KodeSup
								where Pancang = '" & cboPancang.Text & "' AND FlagPrint = 0"
					ElseIf rdAll.Checked = True Then
						sql1 = "SELECT a.Trip,a.TglMasukkapal,a.IDPancang,a.IDPancang2,a.Pancang,a.IDKapal,a.KapalName,a.Qty AS TOTALMUATAN,a.Harga,(a.Qty*a.Harga) - a.BebanRejectKB  AS TotalUpahBongkar,
								a.BayarVia,a.IDPetaniRek +'-'+ isnull(a.NamaRekening,b.NamaSup) as NamaRekening,a.NoRek,a.Bank,a.PajakNPWP as Pajak
								FROM RMPApp..vwRMTrnUpahBongkarDtlP1_032025 as a left join
								RSUPAccounting.dbo.tblRMMstSupplier as b on a.IDPetaniRek=b.KodeSup
								where Pancang = '" & cboPancang.Text & "' AND FlagPrint IN ('0','1')"
					End If
				ElseIf chkP2.Checked = True Then
					If rdBelumBayar.Checked = True Then
					sql1 = "SELECT Trip,TglMasukkapal,IDPancang,IDPancang2,Pancang,IDKapal,KapalName,Qty AS TOTALMUATAN,Harga,(((Qty*Harga) - BebanRejectKB)-PotonganBpjs)  AS TotalUpahBongkar,BayarVia,IDPetaniRek +'-'+ NamaRekening as NamaRekening,NoRek,Bank,PajakNPWP as Pajak FROM RSUPAccounting..vwRMTrnUpahBongkarDtl_022025 " &
								"where Pancang = '" & cboPancang.Text & "' AND FlagPrint = 0 AND NomorAP IS NULL "
				ElseIf rdAll.Checked = True Then
					sql1 = "SELECT Trip,TglMasukkapal,IDPancang,IDPancang2,Pancang,IDKapal,KapalName,Qty AS TOTALMUATAN,Harga,(((Qty*Harga) - BebanRejectKB)-PotonganBpjs) AS TotalUpahBongkar,BayarVia,IDPetaniRek +'-'+ NamaRekening as NamaRekening,NoRek,Bank,PajakNPWP as Pajak FROM RSUPAccounting..vwRMTrnUpahBongkarDtl_022025 " &
								"where Pancang = '" & cboPancang.Text & "' AND FlagPrint IN ('0','1') AND NomorAP IS NOT NULL"
				End If
				End If

				If chkTrip.Checked = True And cmbTrip1.Text <> "" Then
					sql1 &= " and Trip>='" & cmbTrip1.Text & "' "
				End If

				If chkTrip.Checked = True And cmbTrip2.Text <> "" Then
					sql1 &= " and Trip<='" & cmbTrip2.Text & "' "
				End If

				If chkTgl.Checked = True Then
					sql2 = " and TglMasukkapal between ('" & Format(dtp1.Value, "yyyy-MM-dd") & "') and ('" & Format(dtp2.Value, "yyyy-MM-dd") & "') "
				Else
					sql2 = ""
				End If

				If chkBank.Checked = True Then
					sql4 = " and Bank = '" & cboJenisBank.Text & "' "
				Else
					sql4 = ""
				End If

				sql = sql1 + sql2 + sql4 & "ORDER BY TRIP"

				Dim Da = New SqlDataAdapter(sql, Conn)
				Dim _Dt As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

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
			ElseIf chkPCG.Checked = False Then
				If chkP1.Checked = True Then
					Tujuan = "PSG"
					ReportName = ".rptPembayaranUpahBongkarAllP1.rdlc"
				ElseIf chkP2.Checked = True Then
					Tujuan = "RSUP"
					ReportName = ".rptPembayaranUpahBongkarAll.rdlc"
				End If

				paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Tanggal1", Tanggal1, True))
				paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Tanggal2", Tanggal2, True))
				paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Minggu", Minggu, True))
				paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("getDate", getDate, True))
				paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("NamaDibuat", NamaDibuat, True))
				paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Pancang", Pancang, True))
				paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Tujuan", Tujuan, True))

				DsKontrak = "dtBayarBongkarAll"

				If chkP1.Checked = True Then
				sql1 = "SELECT (SELECT TOP(1) TRIP FROM RMPApp..tblRMTrnUpahBongkarDtlP1 WHERE NOINVOICE =A.NoInvoice ORDER BY TRIP ASC ) AS TRIP1, " &
							"(SELECT TOP(1) TRIP FROM RMPApp..tblRMTrnUpahBongkarDtlP1 WHERE NOINVOICE =A.NoInvoice ORDER BY TRIP DESC ) AS TRIP2, " &
							"(select count(trip) from RMPApp..tblRMTrnUpahBongkarDtlP1 WHERE NOINVOICE =A.NoInvoice) as JumlahTrip , " &
							"a.IDPancang,a.pancang, sum(a.qty) as TotalKelapa,a.Harga as Rp ,   SUM((a.qty * a.Harga) - a.BebanRejectKB) as TotalUpahBongkar , 
							a.BayarVia, a.IDPetaniRek +'-'+ ISNULL(a.NamaRekening,b.NamaSup) as NamaRekening,a.NoRek,a.bank,a.FlagPrint,a.noinvoice as NomorNK, " &
							"'' as NomorAP,cast(sum(a.PajakNPWP) as decimal(18,0)) as Pajak " &
							"from RMPApp..vwRMTrnUpahBongkarDtlP1_032025  as a left join
							 RSUPAccounting.dbo.tblRMMstSupplier as b on a.IDPetaniRek=b.KodeSup " &
							"where a.FlagPrint = 0   "
			ElseIf chkP2.Checked = True Then
				If rdBelumBayar.Checked = True Then
					sql1 = "SELECT (SELECT TOP(1) TRIP FROM RSUPAccounting..tblRMTrnUpahBongkarDtl WHERE NOINVOICE =A.NoInvoice ORDER BY TRIP ASC ) AS TRIP1, " &
								"(SELECT TOP(1) TRIP FROM RSUPAccounting..tblRMTrnUpahBongkarDtl WHERE NOINVOICE =A.NoInvoice ORDER BY TRIP DESC ) AS TRIP2, " &
								"(select count(trip) from RSUPAccounting..tblRMTrnUpahBongkarDtl WHERE NOINVOICE =A.NoInvoice) as JumlahTrip , " &
								"IDPancang,pancang, sum(qty) as TotalKelapa,Harga as Rp , SUM(((qty * Harga) - BebanRejectKB)-PotonganBpjs) as TotalUpahBongkar , BayarVia,IDPetaniRek +'-'+ NamaRekening as NamaRekening,NoRek,bank,FlagPrint,noinvoice as NomorNK, " &
								"(SELECT NomorAP FROM RSUPGeneralLedger2018..TblRGLAPPaymentTrnDtl WHERE NOINVOICE =A.NoInvoice) as NomorAP,cast(sum(a.PajakNPWP) as decimal(18,0)) as Pajak " &
								"from RSUPAccounting..vwRMTrnUpahBongkarDtl_022025  as a  " &
								"where FlagPrint = 0 AND NomorAP IS NULL  "
				ElseIf rdAll.Checked = True Then
					sql1 = "SELECT (SELECT TOP(1) TRIP FROM RSUPAccounting..tblRMTrnUpahBongkarDtl WHERE NOINVOICE =A.NoInvoice ORDER BY TRIP ASC ) AS TRIP1, " &
								"(SELECT TOP(1) TRIP FROM RSUPAccounting..tblRMTrnUpahBongkarDtl WHERE NOINVOICE =A.NoInvoice ORDER BY TRIP DESC ) AS TRIP2, " &
								"(select count(trip) from RSUPAccounting..tblRMTrnUpahBongkarDtl WHERE NOINVOICE =A.NoInvoice) as JumlahTrip , " &
								"IDPancang,pancang, sum(qty) as TotalKelapa,Harga as Rp , SUM(((qty * Harga) - BebanRejectKB)-PotonganBpjs) as TotalUpahBongkar , BayarVia, IDPetaniRek +'-'+ NamaRekening as NamaRekening ,NoRek,bank,FlagPrint,noinvoice as NomorNK, " &
								"(SELECT NomorAP FROM RSUPGeneralLedger2018..TblRGLAPPaymentTrnDtl WHERE NOINVOICE =A.NoInvoice) as NomorAP,cast(sum(a.PajakNPWP) as decimal(18,0)) as Pajak " &
								"from RSUPAccounting..vwRMTrnUpahBongkarDtl_022025  as a  " &
								"where FlagPrint IN ('0','1') AND NomorAP IS NOT NULL  "
				End If
			End If

				If chkTrip.Checked = True And cmbTrip1.Text <> "" Then
					sql1 &= " and Trip>='" & cmbTrip1.Text & "' "
				End If

				If chkTrip.Checked = True And cmbTrip2.Text <> "" Then
					sql1 &= " and Trip<='" & cmbTrip2.Text & "' "
				End If

				If chkTgl.Checked = True Then
					sql2 = " and a.TglMasukkapal between ('" & Format(dtp1.Value, "yyyy-MM-dd") & "') and ('" & Format(dtp2.Value, "yyyy-MM-dd") & "') "
				Else
					sql2 = ""
				End If

				If chkPancang.Checked = True Then
					sql3 = " and Pancang = '" & cboPancang.Text & "' "
				Else
					sql3 = ""
				End If

				If chkBank.Checked = True Then
					sql4 = " and Bank = '" & cboJenisBank.Text & "' "
				Else
					sql4 = ""
				End If

				If chkP1.Checked = True Then
					sql = sql1 + sql2 + sql3 + sql4 & " GROUP BY a.noinvoice,a.IDPancang,a.Pancang,a.Harga,a.BayarVia,a.IDPetaniRek +'-'+ ISNULL(a.NamaRekening,b.NamaSup),a.NoRek,a.Bank,a.FlagPrint having  SUM(a.qty * a.Harga)>0 "
				Else
					sql = sql1 + sql2 + sql3 + sql4 & " GROUP BY noinvoice,IDPancang,Pancang,Harga,BayarVia,IDPetaniRek +'-'+ NamaRekening,NoRek,Bank,FlagPrint having  SUM(((qty * Harga) - BebanRejectKB)-PotonganBpjs)>0 "
				End If

				Dim Da = New SqlDataAdapter(sql, Conn)
				Dim _Dt As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

				If _Dt.Rows.Count > 0 Then
					With fg
						fg.Rows.Count = 1
						For Each row As DataRow In _Dt.Rows
							.AddItem(i - 1)
							.Item(i - 1, 1) = row.Item("NomorNK")
							i = i + 1
						Next
						.AutoSizeCols()
					End With
				Else
					fg.Rows.Count = 1
					MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
				End If

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
			End If
			'Catch ex As Exception
			'	Me.Cursor = Cursors.Arrow
			'	MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
			'End Try
			Me.Cursor = Cursors.Arrow
	End Sub

	Private Sub Dtp1_ValueChanged(sender As Object, e As EventArgs) Handles dtp1.ValueChanged
		If Year(dtp1.Value) <> 2023 Then
			txtMinggu.Text = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(dtp1.Text, CalendarWeekRule.FirstDay, DayOfWeek.Monday)
			Dim A As String
			A = txtMinggu.Text
			A = A
		Else
			txtMinggu.Text = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(dtp1.Text, CalendarWeekRule.FirstDay, DayOfWeek.Monday) - 1
			Dim A As String
			A = txtMinggu.Text
			A = A
		End If


	End Sub

	Private Sub BtnLoaddata_Click(sender As Object, e As EventArgs) Handles btnLoaddata.Click
		If chkP1.Checked = False And chkP2.Checked = False Then
			MsgBox("Silahkan pilih transaksi P1 atau P2 ! ", MsgBoxStyle.Exclamation)
			Exit Sub
		End If

		Me.ReportViewer1.Reset()
		Call ReportShow()
	End Sub

	Private Sub chkPancang_CheckedChanged(sender As Object, e As EventArgs) Handles chkPancang.CheckedChanged
		If chkPancang.Checked = False Then
			cboPancang.Enabled = False
		Else
			cboPancang.Enabled = True
		End If
	End Sub

	Private Sub chkBank_CheckedChanged(sender As Object, e As EventArgs) Handles chkBank.CheckedChanged
		If chkBank.Checked = False Then
			cboJenisBank.Enabled = False
		Else
			cboJenisBank.Enabled = True
		End If
	End Sub

	Private Sub chkTgl_CheckedChanged(sender As Object, e As EventArgs) Handles chkTgl.CheckedChanged
		If chkTgl.Checked = False Then
			dtp1.Enabled = False
			dtp2.Enabled = False
		Else
			dtp1.Enabled = True
			dtp2.Enabled = True
		End If
	End Sub

	Private Sub rdBelumBayar_CheckedChanged(sender As Object, e As EventArgs) Handles rdBelumBayar.CheckedChanged
		If rdBelumBayar.Checked = True Then
			btnPrint.Enabled = True
		Else
			btnPrint.Enabled = False
		End If
	End Sub

	Private Sub rdAll_CheckedChanged(sender As Object, e As EventArgs) Handles rdAll.CheckedChanged
		If rdAll.Checked = True Then
			btnPrint.Enabled = False
		Else
			btnPrint.Enabled = True
		End If
	End Sub

	Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
		Call PrintData()
	End Sub

	Private Sub PrintData()
		Me.Cursor = Cursors.WaitCursor
		Try
			Dim koneksi As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnRMPApp)
			Dim Transaksi As SqlTransaction
			Transaksi = koneksi.BeginTransaction

			For i = 3 To fg.Rows.Count - 1
				If PrintNota(koneksi, Transaksi, ClsSession.UserID) = False Then
					Transaksi.Rollback()
					MsgBox("Print Data Gagal", vbExclamation, "Print Data - " & AT)
					Exit Try
				End If
			Next

			Transaksi.Commit()
			MessageBox.Show("Print Berhasil !", "Print Data - " & AT, MessageBoxButtons.OK, MessageBoxIcon.Information)
		Catch ex As Exception
			MessageBox.Show(ex.Message, "Print Data - " & AT, MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			Me.Cursor = Cursors.Default
		End Try
	End Sub

	Private Function PrintNota(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal PrintBy As String) As Boolean
		Dim MyCMD As New SqlCommand
		Dim i As Integer

		Try
			With MyCMD
				.Connection = Conn
				.CommandType = CommandType.Text
				.Transaction = Trans

				.CommandText = "UPDATE RSUPAccounting..tblRMTrnUpahBongkarDtl SET FlagPrint = '1', PrintBy = '" & PrintBy & "', PrintDate = GETDATE() " &
								"WHERE NoInvoice = '" & fg.Item(i, 1) & "'"

				.ExecuteNonQuery()
				.Dispose()
			End With
		Catch ex As Exception
			MessageBox.Show(ex.Message)
			Return False
		End Try

		Return True
	End Function

	Private Sub chkTrip_CheckedChanged(sender As Object, e As EventArgs) Handles chkTrip.CheckedChanged
		If chkTrip.Checked = True Then
			cmbTrip1.Enabled = True
			cmbTrip2.Enabled = True
		Else
			cmbTrip1.Enabled = False
			cmbTrip2.Enabled = False
		End If
		showTrip()
	End Sub

	Private Sub showTrip()
		Dim dt As DataTable = New DataTable
		Dim query As String = ""

		cmbTrip1.Items.Clear()
		cmbTrip2.Items.Clear()

		Try
			If chkP1.Checked = True Then
				query = "SELECT distinct Trip FROM RMPApp..vwRMTrnUpahBongkarDtlP1_032025
					where 1=1 " & IIf(rdBelumBayar.Checked = True, " AND FlagPrint = 0 ", " AND FlagPrint IN ('0','1') ")
			ElseIf chkP2.Checked = True Then
				query = "SELECT distinct Trip FROM RSUPAccounting..vwRMTrnUpahBongkarDtl 
					where 1=1 " & IIf(rdBelumBayar.Checked = True, " AND FlagPrint = 0 AND NomorAP IS NULL ", " AND FlagPrint IN ('0','1') AND NomorAP IS NOT NULL ")
			End If

			If chkPancang.Checked = True Then
				query &= " Pancang = '" & cboPancang.Text & "' "
			End If

			If chkTgl.Checked = True Then
				query &= " and TglMasukkapal between ('" & Format(dtp1.Value, "yyyy-MM-dd") & "') and ('" & Format(dtp2.Value, "yyyy-MM-dd") & "') "
			End If

			If chkBank.Checked = True Then
				query &= " and Bank = '" & cboJenisBank.Text & "' "
			End If

			query &= "ORDER BY TRIP"

			dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, query)

			If dt.Rows.Count > 0 Then
				For Each row As DataRow In dt.Rows
					cmbTrip1.Items.Add(row("Trip"))
					cmbTrip2.Items.Add(row("Trip"))
				Next
			End If
		Catch ex As Exception

		End Try
	End Sub
End Class
