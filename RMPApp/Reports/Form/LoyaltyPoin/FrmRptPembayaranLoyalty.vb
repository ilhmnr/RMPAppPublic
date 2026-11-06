Imports C1.Win.C1FlexGrid
Imports Microsoft.Reporting.WinForms
Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing.Reader

Public Class FrmRptPembayaranLoyalty
	Public Conn As SqlConnection
	Private Sub FrmRptRekapDataPetaniPembayaranKB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		'cboPancang.Enabled = False
		'chkP1.Enabled = False
		'chkP2.Enabled = False
		'cboJenisBank.Enabled = False

		Me.ReportViewer1.RefreshReport()

		'Modul_RMP.Combo.SettokoPancang(cboToko)

		rdp1.Checked = True
		rdp2.Checked = False

		Call ShowVia()
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
				'cboVia.Items.Add(rs!KapalName)
			End While
		Catch ex As Exception
			MsgBox(ex.Message, MsgBoxStyle.Critical)
		End Try
	End Sub

	Sub ReportShow()
		Call KlaimPoin()
		Call LoadDetail()
	End Sub

	Sub ReportShowbelumapprove()
		Call LoadDetail()
	End Sub


	Sub KlaimPoin()
		'Try

		Me.Cursor = Cursors.WaitCursor
		Dim ReportName, IndUMBy As String
		Dim DsKontrak As String
		Dim sql, sqlp, sqla, sqlp2, sqlp3 As String
		'Dim Toko As String = cboToko.Text
		Dim Tanggal As String = Format(dtpTanggal.Value, "dd/MM/yyyy")
		'Dim Via As String = cboVia.Text
		Dim JenisBank As String
		Dim paramList As New Generic.List(Of ReportParameter)

		'paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Toko", Toko, True))
		paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Tanggal", Tanggal, True))
		'paramList.Add(New Microsoft.Reporting.WinForms.ReportParameter("Via", Via, True))


		ReportName = ".RptRekapDataPembayaranKlaimPoin.rdlc"
		DsKontrak = "dtRekap"

		'If cbxPancang.Checked = True Then
		'	sqlp = "and ID_Toko = '" & cboToko.SelectedValue.ToString & "' "
		'Else
		'	sqlp = ""
		'End If

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

		Dim pengajuan As String
		If rdp1.Checked Then
			pengajuan = "PSG"
		Else
			pengajuan = "RSUP"
		End If

		sql = "SELECT * FROM fnDataPetaniPembayaranLoyaltyRpt( '" & Format(dtpTanggal.Value, "yyyy") & "', '" & Format(dtpTanggal.Value, "MM") & "', '" & Format(dtpTanggal.Value, "dd") & "', '" & pengajuan & "') where   Amount>0 AND jenisbank is not null    "

		sqla = sql + sqlp + sqlp2 + sqlp3 & " ORDER BY JenisBank,Remark1"

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

		Me.Cursor = Cursors.Arrow
	End Sub

	Private Sub LoadDetail()
		Dim connb As New SqlConnection(StrConnRMPApp)
		connb.Open()
		'Dim NoReff As String
		Dim sql, sql2 As String
		Dim I As Integer

		dgvlist.Rows.Clear()


		Me.Cursor = Cursors.WaitCursor
		Dim ReportName, IndUMBy As String
		Dim DsKontrak As String
		Dim sqlp, sqla, sqlp2, sqlp3 As String
		Dim LAYANANTRF As String

		Dim Tanggal As String = Format(dtpTanggal.Value, "dd/MM/yyyy")
		Dim JenisBank As String

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
		Dim pengajuan As String
		If rdp1.Checked Then
			pengajuan = "PSG"
		Else
			pengajuan = "RSUP"
		End If

		'If rdPagi.Checked = True Then
		'	sql = "SELECT NoRekening, left(NamaRekening,40) as NamaRekening, CAST(Amount AS INTEGER) AS Amount,Remark1 as Remark1,left(Remark3,12) as Remark3, NoHP ,KODEBANK ,JenisBank,LAYANANTRF  FROM [RSUPAccounting].[dbo].[fnDataPetaniPembayaranLoyaltyRpt]( '" & Format(dtpTanggal.Value, "yyyy") & "', '" & Format(dtpTanggal.Value, "MM") & "', '" & Format(dtpTanggal.Value, "dd") & "','" & IndUMBy & "') where Amount>0 AND  jenisbank is not null and WaktuPengajuan = 'PAGI'   "

		'ElseIf rdSore.Checked = True Then
		'	sql = "SELECT NoRekening, left(NamaRekening,40) as NamaRekening, CAST(Amount AS INTEGER) AS Amount,Remark1 as Remark1,left(Remark3,12) as Remark3, NoHP  ,KODEBANK,JenisBank,LAYANANTRF   FROM [RSUPAccounting].[dbo].[fnDataPetaniPembayaranLoyaltyRpt]( '" & Format(dtpTanggal.Value, "yyyy") & "', '" & Format(dtpTanggal.Value, "MM") & "', '" & Format(dtpTanggal.Value, "dd") & "','" & IndUMBy & "') where Amount>0 AND jenisbank is not null  and WaktuPengajuan = 'SORE'  "

		'ElseIf rdAll.Checked = True Then
		sql = "SELECT NoRekening, left(NamaRekening,40) as NamaRekening, CAST(Amount AS INTEGER) AS Amount,LEFT(Remark1,20) as Remark1,left(Remark2,18) as Remark2, NoHP  ,KODEBANK,JenisBank,LAYANANTRF    FROM fnDataPetaniPembayaranLoyaltyRpt( '" & Format(dtpTanggal.Value, "yyyy") & "', '" & Format(dtpTanggal.Value, "MM") & "', '" & Format(dtpTanggal.Value, "dd") & "','" & pengajuan & "' ) where Amount>0 AND jenisbank is not null   "

		'End If

		sqla = sql + sqlp + sqlp2 + sqlp3 & "ORDER BY KODEBANK ,Remark1"

		Dim cmd2 As New SqlClient.SqlCommand(sqla, connb)
		Dim reader As SqlClient.SqlDataReader
		reader = cmd2.ExecuteReader
		I = 0
		If reader.HasRows Then
			Do While reader.Read()
				I = I + 1

				'dgvlist.Rows.Add(reader("NoRekening").ToString, reader("NamaRekening").ToString, "TEMBILAHAN", "TEMBILAHAN", "3505", "IDR", reader("Amount").ToString, reader("Remark3").ToString, "", reader("LAYANANTRF").ToString, reader("KODEBANK").ToString, reader("JenisBank").ToString, "TEMBILAHAN,,,,Y,regiana@rsup.co.id,,,,Y,Y,,,,,,,,,,,,,,,,OUR,1,E,,,")
				dgvlist.Rows.Add(reader("NoRekening").ToString, reader("NamaRekening").ToString, "TEMBILAHAN", "", "", "IDR", reader("Amount").ToString, reader("Remark2").ToString, "", IIf(chkJenisBayar.Checked = True, cboJenisBayar.Text, reader("LAYANANTRF").ToString), reader("KODEBANK").ToString, reader("JenisBank").ToString, "TEMBILAHAN,,,,Y,juniyanti@rsup.co.id,,,,Y,,,,,,,,,,,,,,,,,OUR,1,E,,,")
			Loop
		Else
			MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
			Exit Sub
		End If

		dgvlist.Rows.Add()

		Call sumtotalamount()

		connb.Close()
	End Sub


	Private Sub cbxPancang_CheckedChanged(sender As Object, e As EventArgs)
		'If cbxPancang.Checked = True Then
		'	Panel1.Enabled = True
		'Else
		'	cboToko.SelectedIndex = -1
		'	Panel1.Enabled = False
		'End If
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
			'add the line to the output
			'thecsvfile = thecsvfile & vbCr & vbLf
			'get the rows
			'For Each column As DataGridViewColumn In dgvlist.Columns
			'	thecsvfile = thecsvfile & column.HeaderText & ","
			'Next

			'For Each row As DataGridViewRow In dgvlist.Rows
			'	'get the cells
			'	For Each cell As DataGridViewCell In row.Cells
			'		thecsvfile = thecsvfile & cell.FormattedValue & ","
			'	Next
			'	'trim the last comma
			'	thecsvfile = thecsvfile & vbCr & vbLf
			'Next

			Dim strROW As String = dgvlist.Rows.Count - 1
			Dim STRAMOUNT As String = dgvlist.Rows(dgvlist.Rows.Count - 1).Cells("Amount").Value().ToString


			If rdp1.Checked = True Then
				thecsvfile = "P," + Format(dtpTanggal.Value, "yyyyMMdd").ToString + "," + "1080097979190," + strROW + "," + STRAMOUNT + ",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,"
			Else
				thecsvfile = "P," + Format(dtpTanggal.Value, "yyyyMMdd").ToString + "," + "1150097979696," + strROW + "," + STRAMOUNT + ",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,"
			End If
			thecsvfile = thecsvfile & vbCr & vbLf

			Dim lines As New List(Of String)
			Dim cells As New List(Of String)

			Dim TEX As Integer
			TEX = 0
			'For Each column As DataGridViewColumn In dgvlist.Columns
			'	If TEX = 5 Then
			'		thecsvfile = thecsvfile & column.HeaderText & vbCr & vbLf
			'	Else
			'		thecsvfile = thecsvfile & column.HeaderText & ","
			'	End If
			'	TEX = TEX + 1
			'Next
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




			'lines.Add(thecsvfile)
			'For Each row As DataGridViewRow In dgvlist.Rows
			'	For cellNumber As Integer = 0 To (dgvlist.Columns.Count - 1)
			'		If Not TypeOf row.Cells.Item(cellNumber).Value Is DBNull Then
			'			cells.Add(row.Cells.Item(cellNumber).Value.ToString)
			'		Else
			'			cells.Add("")
			'		End If
			'	Next
			'	lines.Add(String.Join(","c, cells.ToArray))
			'thecsvfile = thecsvfile & vbCr & vbLf
			'Next

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


	Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
		Me.ReportViewer1.Reset()

		ReportShow()

		Me.Cursor = Cursors.Default
	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Dim pengajuan, pembayaran, jenisbank As String

		'If rdPagi.Checked = True Then
		'	pengajuan = "Pagi"
		'End If
		'If rdSore.Checked = True Then
		'	pengajuan = "Sore"
		'End If
		'If rdAll.Checked = True Then
		'	pengajuan = "All"
		'End If



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


		'If chkBank.Checked = True Then
		SaveGridDataInFile(pembayaran + " " + Replace(dtpTanggal.Text, "/", "") + pengajuan + " " + jenisbank + ".csv")
		'Else
		'	SaveGridDataInFile(pembayaran + " " + Replace(dtpTanggal.Text, "/", "") + pengajuan + " AllBank" + ".csv")
		'End If
	End Sub
End Class
