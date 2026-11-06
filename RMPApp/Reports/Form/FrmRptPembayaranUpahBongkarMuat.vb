Imports System.Data.SqlClient
Imports System.Globalization
Imports Microsoft.Reporting.WinForms
Public Class FrmRptPembayaranUpahBongkarMuat
    Public Conn As SqlConnection

	Private Sub FrmRptPembayaranUpahBongkarMuat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		ShowPancang()
		cboPancang.Visible = True
		Modul_RMP.Combo.SetJenisBank(cboJenisBank)
		Me.ReportViewer1.RefreshReport()
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
		Try
			Me.Cursor = Cursors.WaitCursor
			Dim Flag As Integer
			Dim ReportName As String
			Dim DsKontrak As String
			Dim sql, sql1, sql2, sql3, sql4, sql5 As String
			Dim Tanggal1 As String = Format(dtp1.Value, "dd/MM/yyyy")
			Dim Tanggal2 As String = Format(dtp2.Value, "dd/MM/yyyy")
			Dim Minggu As String = txtMinggu.Text
			Dim getDate As String = Format(Now(), "dd/MM/yyyy")
			Dim NamaDibuat As String = ClsSession.UserID
			Dim Tujuan As String = ""

			If chkPancang.Checked = True Then
				Flag = 1
			Else
				Flag = 1
			End If

			If chkP1.Checked = True Then
				Tujuan = "PSG"
				ReportName = ".rptPembayaranUpahBongkarMuatp1.rdlc"
			ElseIf chkP2.Checked = True Then
				Tujuan = "RSUP"
				ReportName = ".rptPembayaranUpahBongkarMuat.rdlc"
			End If

			Dim FlagTTD As Integer = Flag

			Dim paramList As New Generic.List(Of ReportParameter)

			paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Tanggal1", Tanggal1, True))
			paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Tanggal2", Tanggal2, True))
			paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Minggu", Minggu, True))
			paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("getDate", getDate, True))
			paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("NamaDibuat", NamaDibuat, True))
			paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("FlagTTD", FlagTTD, True))
			paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Tujuan", Tujuan, True))

			DsKontrak = "dtBayarBongkarMuat"

			If chkTgl.Checked = True Then
				sql2 = " and TglInvoice between ('" & Format(dtp1.Value, "yyyy-MM-dd") & "') and ('" & Format(dtp2.Value, "yyyy-MM-dd") & "') "
			End If

			If chkPancang.Checked = True Then
				sql3 = " and Pancang = '" & cboPancang.Text & "' "
			End If

			If chkBank.Checked = True Then
				sql4 = " and Bank = '" & cboJenisBank.Text & "' "
			End If

			If ChkTrip.Checked = True Then
				sql5 = " and (TRIP between " & txtTrip1.Text & " and " & txtTrip2.Text & ") "
			End If

			If rdBelumBayar.Checked = True Then
				sql1 = "SELECT * FROM [RMPApp].[dbo].[vwRMRptUpahBongkarMuatP1] WHERE 1=1 "
			ElseIf rdAll.Checked = True Then
				sql1 = "Select * FROM [RMPApp].[dbo].[vwRMRptUpahBongkarMuatP1] WHERE 1=1 "
			End If
			If chkP2.Checked = True Then
				If rdBelumBayar.Checked = True Then
					sql1 = "Select TGLMASUKKAPAL,TRIP,KAPALNAME,QTY As TOTALMUATAN ,PANCANG,Case When  TglMasukKapal<'2021-11-06' THEN  Round(( isnull(Qty,0) - isnull(Qty,0)*0.02) * isnull(Harga,0),0) - isnull(TotalSusut,0) - isnull(PotongSusut,0)- isnull(PotongLainLain,0)- isnull(PotonganGps,0)  ELSE  " &
						 "  Round(isnull(SisaMuatan,0) * isnull(Harga,0),0) + isnull(TotalTambangBefore,0)  +  Round(isnull(Qty2,0) * isnull(Harga,0),0) + ISNULL(PPN,0) + ISNULL(KarantinaTumbuhan,0) - isnull(TotalSusut,0) - isnull(PotongSusut,0) - isnull(PotongLainLain,0)- isnull(PotonganGps,0)   " &
						 " -  isnull(PotonganBPJS,0)  -  isnull(PotonganLainLain,0) -  isnull(PotonganOlahGerak,0) -  isnull(PotonganAsuransi,0) -  isnull(PPH23,0)-  isnull(RpPajak,0) - isnull(NonNPWP,0) -  isnull(SIUPER,0) -  isnull(PPH15,0) -  isnull(DownPayment,0)  End   As  TotalUpahBongkar,BayarVia,  IDPETANIREK+ '-' + NamaRekening AS NamaRekening,NoRek,bank,noinvoice As nonk ,NomorAP " &
						 " FROM [RSUPAccounting].[dbo].[vwRMTrnUpahBongkarMuatDtl] where NomorAP Is NULL "
				ElseIf rdAll.Checked = True Then
					sql1 = "Select TGLMASUKKAPAL,TRIP,KAPALNAME,QTY As TOTALMUATAN ,PANCANG,Case When  TglMasukKapal<'2021-11-06' THEN  Round(( isnull(Qty,0) - isnull(Qty,0)*0.02) * isnull(Harga,0),0) - isnull(TotalSusut,0) - isnull(PotongSusut,0) - isnull(PotongLainLain,0)- isnull(PotonganGps,0)  ELSE " &
						   "  Round(isnull(SisaMuatan,0) * isnull(Harga,0),0) + isnull(TotalTambangBefore,0)  + Round(isnull(Qty2,0) * isnull(Harga,0),0) + ISNULL(PPN,0) + ISNULL(KarantinaTumbuhan,0) - isnull(TotalSusut,0) - isnull(PotongSusut,0) - isnull(PotongLainLain,0)- isnull(PotonganGps,0)  " &
						   " -  isnull(PotonganBPJS,0)  -  isnull(PotonganLainLain,0) -  isnull(PotonganOlahGerak,0) -  isnull(PotonganAsuransi,0)  -  isnull(PPH23,0)-  isnull(RpPajak,0) - isnull(NonNPWP,0) -  isnull(SIUPER,0)   -  isnull(PPH15,0) -  isnull(DownPayment,0)  END   AS   TotalUpahBongkar,BayarVia,  IDPETANIREK+ '-' + NamaRekening AS NamaRekening,NoRek,bank,noinvoice as nonk ,NomorAP " &
						   " FROM [RSUPAccounting].[dbo].[vwRMTrnUpahBongkarMuatDtl] where NomorAP IS NOT NULL "
				End If

			End If

			sql = sql1 + sql2 + sql3 + sql4 + sql5

			Dim Da = New SqlDataAdapter(sql, Conn)
			Dim _Dt As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)
			Dim DSource = New ReportDataSource(DsKontrak, _Dt)
			Me.ReportViewer1.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ReportName
			Me.ReportViewer1.LocalReport.DataSources.Add(DSource)
			Me.ReportViewer1.LocalReport.SetParameters(paramList)
			'Dim newPageSetting As New System.Drawing.Printing.PageSettings
			'newPageSetting.Margins = New System.Drawing.Printing.Margins(3, 3, 3, 3)
			'newPageSetting.Landscape = True
			'ReportViewer1.SetPageSettings(newPageSetting)
			Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
			Me.ReportViewer1.RefreshReport()
		Catch ex As Exception
			Me.Cursor = Cursors.Arrow
			MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
			
			
		End Try
		Me.Cursor = Cursors.Arrow
	End Sub


	Sub ReportShowum()
		Try
			Me.Cursor = Cursors.WaitCursor
			Dim Flag As Integer
			Dim ReportName As String
			Dim DsKontrak As String
			Dim sql, sql1, sql2, sql3, sql4, sql5 As String
			Dim Tanggal1 As String = Format(dtp1.Value, "dd/MM/yyyy")
			Dim Tanggal2 As String = Format(dtp2.Value, "dd/MM/yyyy")
			Dim Minggu As String = txtMinggu.Text
			Dim getDate As String = Format(Now(), "dd/MM/yyyy")
			Dim NamaDibuat As String = ClsSession.UserID

			If chkPancang.Checked = True Then
				Flag = 1
			Else
				Flag = 0
			End If
			Dim FlagTTD As Integer = Flag

			Dim paramList As New Generic.List(Of ReportParameter)

			paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Tanggal1", Tanggal1, True))
			paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Tanggal2", Tanggal2, True))
			paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Minggu", Minggu, True))
			paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("getDate", getDate, True))
			paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("NamaDibuat", NamaDibuat, True))
			paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("FlagTTD", FlagTTD, True))

			ReportName = ".rptPembayaranUpahBongkarMuatUM.rdlc"
			DsKontrak = "dtBayarBongkarMuat"



			If chkTgl.Checked = True Then
				sql2 = " and TglInvoice between ('" & Format(dtp1.Value, "yyyy-MM-dd") & "') and ('" & Format(dtp2.Value, "yyyy-MM-dd") & "') "
			End If

			If chkPancang.Checked = True Then
				sql3 = " and Pancang = '" & cboPancang.Text & "' "
			End If

			If chkBank.Checked = True Then
				sql4 = " and Bank = '" & cboJenisBank.Text & "' "
			End If

			If ChkTrip.Checked = True Then
				sql5 = " and (TRIP between " & txtTrip1.Text & " and " & txtTrip2.Text & ") "
			End If

			If rdBelumBayar.Checked = True Then
				sql1 = "SELECT TglInvoice AS TGLMASUKKAPAL,TRIP,KAPALNAME,QTY AS TOTALMUATAN ,PANCANG, CASE WHEN TglMasukKapal<'2021-11-06' THEN  Round(( isnull(Qty,0) - isnull(Qty,0)*0.02) * isnull(Harga,0),0) - isnull(TotalSusut,0) - isnull(PotongSusut,0) - isnull(PotongLainLain,0) - isnull(PotonganGps,0) ELSE  " &
						 " (Round(isnull(Qty2,0) * isnull(Harga,0),0) - isnull(TotalSusut,0) - isnull(PotongSusut,0) - isnull(PotongLainLain,0)- isnull(PotonganGps,0)    " &
						 " -  isnull(PotonganBPJS,0)  -  isnull(PotonganLainLain,0) -  isnull(PotonganOlahGerak,0) -  isnull(PotonganAsuransi,0)-  isnull(PPH23,0)  - isnull(NonNPWP,0) -  isnull(SIUPER,0) ) + isnull(DownPayment ,0)  End   As  TotalUpahBongkar,BayarVia,  IDPetani+ '-' + NamaRekening AS NamaRekening,NoRek,bank,noinvoice As nonk ,NoBK AS NomorAP " &
						 " FROM [RMPApp].[dbo].[vwRMTrnUpahBongkarMuatPontianakDtl] WHERE PANCANG Is Not NULL and Fac='PSG' "
			ElseIf rdAll.Checked = True Then
				sql1 = "Select TglInvoice AS TGLMASUKKAPAL,TRIP,KAPALNAME,QTY As TOTALMUATAN ,PANCANG, " &
						" (Round(isnull(Qty2,0) * isnull(Harga,0),0) - isnull(TotalSusut,0) - isnull(PotongSusut,0) - isnull(PotongLainLain,0)- isnull(PotonganGps,0)   " &
						"  -  isnull(PotonganBPJS,0)  -  isnull(PotonganLainLain,0) -  isnull(PotonganOlahGerak,0) -  isnull(PotonganAsuransi,0) -  isnull(PPH23,0) - isnull(NonNPWP,0) -  isnull(SIUPER,0)) + isnull(DownPayment ,0)  As TotalUpahBongkar,BayarVia,  IDPetani+ '-' + NamaRekening AS NamaRekening,NoRek,bank,noinvoice As nonk ,NoBK AS NomorAP " &
						" FROM [RMPApp].[dbo].[vwRMTrnUpahBongkarMuatPontianakDtl] WHERE PANCANG Is Not NULL  and Fac='PSG' "
			End If
			If chkP2.Checked = True Then
				If rdBelumBayar.Checked = True Then
					sql1 = "Select TglInvoice AS TGLMASUKKAPAL,TRIP,KAPALNAME,QTY As TOTALMUATAN ,PANCANG,Case When  TglMasukKapal<'2021-11-06' THEN  Round(( isnull(Qty,0) - isnull(Qty,0)*0.02) * isnull(Harga,0),0) - isnull(TotalSusut,0) - isnull(PotongSusut,0)- isnull(PotongLainLain,0)- isnull(PotonganGps,0)  ELSE  " &
						 " ( Round(isnull(Qty2,0) * isnull(Harga,0),0) - isnull(TotalSusut,0) - isnull(PotongSusut,0) - isnull(PotongLainLain,0)- isnull(PotonganGps,0)   " &
						 " -  isnull(PotonganBPJS,0)  -  isnull(PotonganLainLain,0) -  isnull(PotonganOlahGerak,0) -  isnull(PotonganAsuransi,0) -  isnull(PPH23,0) - isnull(NonNPWP,0) -  isnull(SIUPER,0))  + isnull(DownPayment ,0)   End   As  TotalUpahBongkar,BayarVia,  IDPetani+ '-' + NamaRekening AS NamaRekening,NoRek,bank,noinvoice As nonk,NoBK AS NomorAP " &
						 " FROM [RMPApp].[dbo].[vwRMTrnUpahBongkarMuatPontianakDtl] where  PANCANG Is Not NULL and Fac='RSUP' "
				ElseIf rdAll.Checked = True Then
					sql1 = "Select TglInvoice AS TGLMASUKKAPAL,TRIP,KAPALNAME,QTY As TOTALMUATAN ,PANCANG,Case When  TglMasukKapal<'2021-11-06' THEN  Round(( isnull(Qty,0) - isnull(Qty,0)*0.02) * isnull(Harga,0),0) - isnull(TotalSusut,0) - isnull(PotongSusut,0) - isnull(PotongLainLain,0)- isnull(PotonganGps,0)  ELSE " &
						   " (Round(isnull(Qty2,0) * isnull(Harga,0),0) - isnull(TotalSusut,0) - isnull(PotongSusut,0) - isnull(PotongLainLain,0)- isnull(PotonganGps,0)  " &
						   " -  isnull(PotonganBPJS,0)  -  isnull(PotonganLainLain,0) -  isnull(PotonganOlahGerak,0) -  isnull(PotonganAsuransi,0)  -  isnull(PPH23,0) - isnull(NonNPWP,0) -  isnull(SIUPER,0))  + isnull(DownPayment ,0)   END   AS   TotalUpahBongkar,BayarVia,  IDPetani+ '-' + NamaRekening AS NamaRekening,NoRek,bank,noinvoice as nonk ,NoBK AS NomorAP " &
						   " FROM [RMPApp].[dbo].[vwRMTrnUpahBongkarMuatPontianakDtl] where  PANCANG Is Not NULL  and Fac='RSUP' "
				End If

			End If

			sql = sql1 + sql2 + sql3 + sql4 + sql5

			Dim Da = New SqlDataAdapter(sql, Conn)
			Dim _Dt As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)
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


	Private Sub Dtp1_ValueChanged(sender As Object, e As EventArgs) Handles dtp1.ValueChanged
		If Year(dtp1.Value) < 2023 Then
			txtMinggu.Text = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(dtp1.Text, CalendarWeekRule.FirstDay, DayOfWeek.Monday)
		Else
			txtMinggu.Text = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(dtp1.Text, CalendarWeekRule.FirstDay, DayOfWeek.Monday) - 1

		End If
	End Sub

	Private Sub BtnLoaddata_Click(sender As Object, e As EventArgs) Handles btnLoaddata.Click
		If chkP1.Checked = False And chkP2.Checked = False Then
			MsgBox("Silahkan pilih transaksi P1 atau P2 ! ", MsgBoxStyle.Exclamation)
			Exit Sub
		End If

		Me.ReportViewer1.Reset()
		If chkpontianak.Checked Then
			Call ReportShowum()
		Else

			Call ReportShow()
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

End Class
