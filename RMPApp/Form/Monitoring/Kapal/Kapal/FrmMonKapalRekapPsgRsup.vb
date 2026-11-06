Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports C1.Win.C1FlexGrid

Public Class FrmMonKapalRekapPsgRsup
	Dim nm As String
	Dim kodebahanbaku As String
	Private Sub MonitoringKapal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		nm = "12"
		SetStatuskpal(CboStatus)

		dtcb1.Value = Format(Now, "dd/MM/yyyy")
		dtcb2.Value = Format(Now, "dd/MM/yyyy")
	End Sub


	Public Sub SetStatuskpal(ByVal cbo As ComboBox)
		With cbo
			.Items.Add("Antri")
			.Items.Add("Bongkar")
			.Items.Add("OTW")
			.Items.Add("Realesed")
			.Items.Add("Reject")
		End With
	End Sub


	'#Region "Data Kg"

	'#End Region
	'	Sub AntriP1(ByVal sql As String)
	'		Dim dt As DataTable = New DataTable()

	'		Dim i As Integer = 1


	'		dt = DB.ExecuteQuery(StrConnPSGRMP,"select count(DETAILid) as Total from PSGRMP..vwAndroidBookingAntrian2023  where statusbongkar='Antri'  and Tujuan = 'PSG'  ")


	'		If dt.Rows.Count > 0 Then
	'			txtantriP1.Text = 0
	'			For Each row As DataRow In dt.Rows
	'				txtantriP1.Text = row.Item("Total")
	'			Next
	'		Else
	'			txtantriP1.Text = 0
	'		End If
	'	End Sub
	'	Sub AntriP2(ByVal sql As String)
	'		Dim dt As DataTable = New DataTable()

	'		Dim i As Integer = 1


	'		dt = DB.ExecuteQuery(StrConnPSGRMP,"select count(DETAILid) as Total from PSGRMP..vwAndroidBookingAntrian2023  where statusbongkar='Antri'  and Tujuan = 'RSUP'   ")

	'		If dt.Rows.Count > 0 Then
	'			txtantriP2.Text = 0
	'			For Each row As DataRow In dt.Rows
	'				txtantriP2.Text = row.Item("Total")
	'			Next
	'		Else
	'			txtantriP2.Text = 0
	'		End If
	'	End Sub


	'	Sub BookingP1(ByVal sql As String)
	'		Dim dt As DataTable = New DataTable()

	'		Dim i As Integer = 1


	'		dt = DB.ExecuteQuery(StrConnPSGRMP,"select count(DETAILid) as Total  from PSGRMP..vwAndroidBookingAntrian2023  where statusbongkar='OTW'  and Tujuan = 'PSG'   ")


	'		If dt.Rows.Count > 0 Then
	'			txtotwp1.Text = 0
	'			For Each row As DataRow In dt.Rows
	'				txtotwp1.Text = row.Item("Total")
	'			Next
	'		Else
	'			txtotwp1.Text = 0
	'		End If
	'	End Sub
	'	Sub BookingP2(ByVal sql As String)
	'		Dim dt As DataTable = New DataTable()

	'		Dim i As Integer = 1


	'		dt = DB.ExecuteQuery(StrConnPSGRMP,"select count(DETAILid) as Total  from PSGRMP..vwAndroidBookingAntrian2023 where statusbongkar='OTW'  and Tujuan = 'RSUP'   ")


	'		If dt.Rows.Count > 0 Then
	'			txtotwp2.Text = 0
	'			For Each row As DataRow In dt.Rows
	'				txtotwp2.Text = row.Item("Total")
	'			Next
	'		Else
	'			txtotwp2.Text = 0
	'		End If

	'	End Sub


	'	Sub BongkarP1(ByVal sql As String)
	'		Dim dt As DataTable = New DataTable()

	'		Dim i As Integer = 1


	'		dt = DB.ExecuteQuery(StrConnPSGRMP,"select count(DETAILid) as Total from PSGRMP..vwAndroidBookingAntrian2023  where statusbongkar='Bongkar'  and Tujuan = 'PSG'  ")

	'		If dt.Rows.Count > 0 Then
	'			txtBgkrP1.Text = 0
	'			For Each row As DataRow In dt.Rows
	'				txtBgkrP1.Text = row.Item("Total")
	'			Next
	'		Else
	'			txtBgkrP1.Text = 0
	'		End If
	'	End Sub
	'	Sub BongkarP2(ByVal sql As String)
	'		Dim dt As DataTable = New DataTable()

	'		Dim i As Integer = 1


	'		dt = DB.ExecuteQuery(StrConnPSGRMP,"select count(DETAILid) as Total from PSGRMP..vwAndroidBookingAntrian2023 where statusbongkar='Bongkar'  and Tujuan = 'RSUP'  ")



	'		If dt.Rows.Count > 0 Then
	'			txtBgkrP2.Text = 0
	'			For Each row As DataRow In dt.Rows
	'				txtBgkrP2.Text = row.Item("Total")
	'			Next
	'		Else
	'			txtBgkrP2.Text = 0
	'		End If


	'	End Sub



	'	Sub RealesedP1(ByVal sql As String)
	'		Dim dt As DataTable = New DataTable()

	'		Dim i As Integer = 1


	'		dt = DB.ExecuteQuery(StrConnPSGRMP,"select count(DETAILid) AS Total from PSGRMP..vwAndroidBookingAntrian2023 where cast(ReleaseDate as date) between  '" & Format(dtcb1.Value, "yyyy-MM-dd") & "'  and '" & Format(dtcb2.Value, "yyyy-MM-dd") & "'  and statusbongkar='Realesed'  and Tujuan = 'PSG'  " & IIf(sql = "", "", " AND " & sql) & " ")


	'		If dt.Rows.Count > 0 Then
	'			txtRealesedP1.Text = 0
	'			For Each row As DataRow In dt.Rows
	'				txtRealesedP1.Text = row.Item("Total")
	'			Next
	'		Else
	'			txtRealesedP1.Text = 0
	'		End If
	'	End Sub
	'	Sub RealesedP2(ByVal sql As String)
	'		Dim dt As DataTable = New DataTable()

	'		Dim i As Integer = 1


	'		dt = DB.ExecuteQuery(StrConnPSGRMP,"select count(DETAILid) as Total from PSGRMP..vwAndroidBookingAntrian2023  where cast(ReleaseDate as date) between  '" & Format(dtcb1.Value, "yyyy-MM-dd") & "'  and '" & Format(dtcb2.Value, "yyyy-MM-dd") & "'   and Tujuan = 'RSUP'  " & IIf(sql = "", "", " AND " & sql) & " ")

	'		If dt.Rows.Count > 0 Then
	'			txtRealesedP2.Text = 0
	'			For Each row As DataRow In dt.Rows
	'				txtRealesedP2.Text = row.Item("Total")
	'			Next
	'		Else
	'			txtRealesedP2.Text = 0
	'		End If
	'	End Sub





	Private Sub ShowData(ByVal sql As String)
		Try
			Dim query As String = ""
			Dim dt As DataTable = New DataTable()
			Dim i As Integer = 1

			query = "SELECT  * from  fndatakapal ( '" & Format(dtcb1.Value, "yyyy-MM-dd") & "'  ,'" & Format(dtcb2.Value, "yyyy-MM-dd") & "' ) where 1 = 1 " & IIf(sql = "", "", " AND " & sql) & " order by  TUJUAN,Jeniskelapa,CHEcKINDATE Desc"

			dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, query)

			If dt.Rows.Count > 0 Then
				'HeaderFGKg()
				With fg
					Call ui.HapusGrid(1, fg)
					For Each row As DataRow In dt.Rows
						.AddItem(i - 1)
						.Item(i, "No") = i
						.Item(i, "Tujuan") = row.Item("Tujuan")
						.Item(i, "Status") = row.Item("StatusBongkar")
						.Item(i, "Jenis") = row.Item("Jeniskelapa")
						.Item(i, "Kapal") = row.Item("NamaKapal")
						.Item(i, "Trip") = row.Item("TripID")
						.Item(i, "TanggalBooking") = row.Item("TanggalPembuatan")

						.Item(i, "TanggalBongkar") = row.Item("StatusBongkarDate")
						.Item(i, "RealesedDate") = row.Item("ReleaseDate")

						.Item(i, "AlamatKapal") = row.Item("AlamatKapal")
						.Item(i, "Quantity") = row.Item("Quantity")
						.Item(i, "RealQuantity") = row.Item("RealQuantityPabrik")
						.Item(i, "CheckInDate") = row.Item("CheckInDate")
						.Item(i, "TanggalMuat") = row.Item("MuatDate")
						.Item(i, "Pancang") = row.Item("Pancang")
						'.Item(i, 7) = row.Item("muatdate")


						i = i + 1
					Next
					.AutoSizeCols()
					.AllowMerging = AllowMergingEnum.Free
				End With
				GrandTotal()

			Else
				fg.Rows.Count=2
				MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
			End If

		Catch ex As Exception
			MessageBox.Show(ex.Message)
		Finally
			Cursor = Cursors.Default
		End Try
	End Sub


	Private Sub GrandTotal()
		With fg
			.Tree.Column = 0
			.Tree.Style = TreeStyleFlags.CompleteLeaf
			.Subtotal(AggregateEnum.Clear)
			.Subtotal(AggregateEnum.Sum, -1, -1, 12, "TOTAL")
			.Subtotal(AggregateEnum.Sum, 1, 1, 12, "{0}")
			.Subtotal(AggregateEnum.Sum, 2, 2, 13, "{0}")
			'.Subtotal(AggregateEnum.Sum, 3, 3, 10, "ID-{0}")

			.Subtotal(AggregateEnum.Sum, -1, -1, 13)
			.Subtotal(AggregateEnum.Sum, 1, 1, 13, "{0}")
			.Subtotal(AggregateEnum.Sum, 2, 2, 13, "{0}")
			'.Subtotal(AggregateEnum.Sum, 1, 2, 8)
			'.Subtotal(AggregateEnum.Sum, 3, 3, 8)

			'.Subtotal(AggregateEnum.Sum, -1, -1, 12)
			'.Subtotal(AggregateEnum.Sum, 1, 2, 12)
			'.Subtotal(AggregateEnum.Sum, 3, 3, 12)


			.AutoSizeCols()
		End With
		Call FGColor()
	End Sub

	Public Sub FGColor()
		Dim cs As C1.Win.C1FlexGrid.CellStyle
		cs = fg.Styles(C1.Win.C1FlexGrid.CellStyleEnum.GrandTotal)
		cs.BackColor = Color.FromArgb(73, 173, 8)
		cs.ForeColor = Color.White
		cs.Font = New Font(Font, FontStyle.Bold)


		'cs = fg.Styles(C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0)
		'cs.BackColor = Color.LavenderBlush
		'cs.ForeColor = Color.Black

		'cs = fg.Styles(C1.Win.C1FlexGrid.CellStyleEnum.Subtotal1)
		'cs.BackColor = Color.FromArgb(81, 161, 243)
		'cs.ForeColor = Color.White
		'cs.Font = New Font(Font, FontStyle.Bold)

		fg.AutoSizeCols()
	End Sub


	Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
		'Me.Cursor = Cursors.WaitCursor

		'Dim sql As String
		'If chkStatusBooking.Checked = True Then
		'	sql = Modul_RMP.Func.SetCondition(sql, "statusbongkar='" & cboStatus.Text.ToString & "'")
		'End If

		'Call ShowData(sql)

		''Call AntriP1(sql)
		''Call AntriP2(sql)
		''Call BookingP1(sql)
		''Call BookingP2(sql)
		''Call BongkarP1(sql)
		''Call BongkarP2(sql)
		''Call RealesedP1(sql)
		''Call RealesedP2(sql)

		'Try
		'	Dim apiHelper As New ClsApiHelper()
		'	Dim apiHelper2 As New ClsApiHelper()
		'	Dim endpoint As String = "/RekapKapalP1P2/DataRekapKapalP1P2"
		'	Dim url As String = baseUrl & endpoint

		'	Dim data As New With
		'	{
		'		.rekapKapalP1P2DTO = New With {
		'			.tanggal1 = Format(dtcb1.Value, "yyyy-MM-dd"),
		'			.tanggal2 = Format(dtcb2.Value, "yyyy-MM-dd"),
		'			.statusBongkar = If(chkStatusBooking.Checked, cboStatus.Text?.ToString(), "")
		'		},
		'		.tokenP1 = FrmMain.tokenp1
		'	}
		'	Dim dt As DataTable = apiHelper.GetDataFromApi(url, data)

		'	If dt IsNot Nothing Then
		'		txtantriP1.Text = dt.Rows(0).Item(0).ToString()
		'		txtantriP2.Text = dt.Rows(0).Item(1).ToString()
		'		txtotwp1.Text = dt.Rows(0).Item(2).ToString()
		'		txtotwp2.Text = dt.Rows(0).Item(3).ToString()
		'		txtBgkrP1.Text = dt.Rows(0).Item(4).ToString()
		'		txtBgkrP2.Text = dt.Rows(0).Item(5).ToString()
		'		txtRealesedP1.Text = dt.Rows(0).Item(6).ToString()
		'		txtRealesedP2.Text = dt.Rows(0).Item(7).ToString()
		'	End If
		'Catch ex As Exception

		'End Try

		'Me.Cursor = Cursors.Default
	End Sub

	Private Sub BtnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
		Dim filename As String
		Me.SaveFileDialog.ShowDialog()
		filename = SaveFileDialog.FileName
		Me.fg.SaveExcel(filename & ".xls", "Sheet1", FileFlags.IncludeFixedCells)
		MsgBox("Convert Success !", vbInformation, AT)
	End Sub

	Private Sub cboStatus_Validated(sender As Object, e As EventArgs) Handles cboStatus.Validated
		chkStatusBooking.Checked = IIf(cboStatus.Text = "", False, True)
	End Sub

	Private Sub cboStatus_KeyUp(sender As Object, e As KeyEventArgs) Handles cboStatus.KeyUp
		UI.AutoCompleteCombo_KeyUp(cboStatus, e)
	End Sub
End Class
