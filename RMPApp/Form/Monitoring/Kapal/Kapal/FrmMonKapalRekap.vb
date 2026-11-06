Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports C1.C1Preview
Imports C1.Win.C1FlexGrid

Public Class FrmMonKapalRekap
	Dim nm As String
	Dim kodebahanbaku As String
	Private Sub FrmMonKapalPancangNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		nm = "12"
		'Modul_RMP.Combo.SetPelangsir(CboStatus)
		Modul_RMP.Combo.SetPancang(cmbPancang)


		'Call MuatP1()
		'Call MuatP2()
		'Call AntriP1()
		'Call AntriP2()

		dtcb1.Value = Format(Now, "dd/MM/yyyy")
		dtcb2.Value = Format(Now, "dd/MM/yyyy")
	End Sub


#Region "Data Kg"

#End Region
	Sub AntriP1(ByVal sql As String)



		sql = "select count(*)as Total from Android_tblBookingKapalMuat as a join tblMstKapal as b on a.IDKapal = b.KapalID where StatusBooking  not in ('Close','Booking') and Tujuan = 'PSG' and StatusBooking ='Antri' " & IIf(sql = "", "", " AND " & sql) & " "

		Dim cmd As New SqlCommand(sql, DB.OpenConnection(StrConnRMPApp))
		Dim rs As SqlDataReader

		rs = cmd.ExecuteReader
		If rs.Read() Then
			txtP1.Text = (rs!Total)
		Else
			txtP1.Text = 0
		End If
	End Sub
	Sub AntriP2(ByVal sql As String)


		sql = "select count(*)as Total from Android_tblBookingKapalMuat as a join tblMstKapal as b on a.IDKapal = b.KapalID where StatusBooking  not in ('Close','Booking') and Tujuan = 'RSUP' and StatusBooking ='Antri'  " & IIf(sql = "", "", " AND " & sql) & " "


		Dim cmd As New SqlCommand(sql, DB.OpenConnection(StrConnRMPApp))
		Dim rs As SqlDataReader

		rs = cmd.ExecuteReader
		If rs.Read() Then
			txtP2.Text = (rs!Total)
		Else
			txtP2.Text = 0
		End If
	End Sub
	Sub MuatP1(ByVal sql As String)


		sql = "select count(*)as Total from Android_tblBookingKapalMuat as a join tblMstKapal as b on a.IDKapal = b.KapalID where StatusBooking  not in ('Close','Booking') and Tujuan = 'PSG' and StatusBooking ='Muat'  " & IIf(sql = "", "", " AND " & sql) & " "

		Dim cmd As New SqlCommand(sql, DB.OpenConnection(StrConnRMPApp))
		Dim rs As SqlDataReader

		rs = cmd.ExecuteReader
		If rs.Read() Then
			txtMuatP1.Text = (rs!Total)
		Else
			txtMuatP1.Text = 0
		End If
	End Sub
	Sub MuatP2(ByVal sql As String)


		sql = "select count(*)as Total from Android_tblBookingKapalMuat as a join tblMstKapal as b on a.IDKapal = b.KapalID where StatusBooking  not in ('Close','Booking') and Tujuan = 'RSUP' and StatusBooking ='Muat'   " & IIf(sql = "", "", " AND " & sql) & " "

		Dim cmd As New SqlCommand(sql, DB.OpenConnection(StrConnRMPApp))
		Dim rs As SqlDataReader

		rs = cmd.ExecuteReader
		If rs.Read() Then
			txtMuatP2.Text = (rs!Total)
		Else
			txtMuatP2.Text = 0
		End If
	End Sub
	Private Sub ShowData(ByVal sql As String)
		Dim query As String = ""

		Try
			Dim dt As DataTable = New DataTable()
			Dim i As Integer = 1

			'If chkStatusBooking.Checked = True Then
			'	Sql = Modul_RMP.Func.SetCondition(Sql, "StatusBooking='" & CboStatus.SelectedValue.ToString & "'")
			'End If

			If rdP1.Checked Then
				sql = Modul_RMP.Func.SetCondition(sql, " A.Tujuan='PSG' ")
			ElseIf rdP2.Checked Then
				sql = Modul_RMP.Func.SetCondition(sql, " A.Tujuan ='RSUP' ")
			ElseIf RdAll.Checked Then
				sql = Modul_RMP.Func.SetCondition(sql, " A.Tujuan  IN ('RSUP','PSG') ")
			End If

			If chkMuatAntri.Checked = True Then
				sql = Modul_RMP.Func.SetCondition(sql, " a.StatusBooking Not in ('Close','Booking') ")
			Else
				sql = Modul_RMP.Func.SetCondition(sql, " a.StatusBooking = 'Close' and a.BerangkatDate is null and (cast(a.ChekinDate as date) between cast('" & Format(dtcb1.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(dtcb2.Value, "yyyy-MM-dd") & "' as date)) ")
			End If

			'dt = DB.ExecuteQuery(StrConnRMPApp,"SELECT a.*,B.Kap, (select sum(netto) from TblTrnKelapaHdr as hdr where hdr.idpancang=a.idpancang and hdr.idkapal=a.IDKapal " &
			'											"	 and hdr.trip=a.TripID  and hdr.jeniskb=a.JenisMuat and (hdr.Deleted=0 or hdr.Deleted is null)) as realmuat FROM vwBookingMuatPCG as a " &
			'											"	join tblMstKapal as b  On a.IDKapal = b.KapalID  left outer join " &
			'											" [192.168.2.3].[PSGRMP].[dbo].[tblAndroidBookingAntrian] as c on a.bookingid=c.detailid " &
			'											"	WHERE a.StatusBooking Not in ('Close','Booking')   " & IIf(sql = "", "", " AND " & sql) & " order by JenisMuat, TUJUAN,CHEKINDATE Desc")

			query = "with cte as (
																	select b.ChekinDate,b.MuatDate,b.CloseDate,b.BerangkatDate,b.ChekinPabrik,B.Tujuan,B.DetailID,B.IDKapal,C.KapalName as NamaKapal,b.CreatedDate,b.flagInvoiceMuat,a.JenisMuat,b.JenisKelapa,C.Kap,B.Pancang,B.IDPancang,C.Pemilik as PemilikKapal,B.StatusBooking,isnull(b.BookingID,0) as BookingID,
																	(CONVERT(VARCHAR(10), B.CreatedDate, 3)+' '+CONVERT(VARCHAR(10), B.CreatedDate, 108)) as TanggalBooking,(CONVERT(VARCHAR(10), B.ChekinDate, 3)+' '+CONVERT(VARCHAR(10), B.ChekinDate, 108)) as  TanggalCheckIn,
																	(CONVERT(VARCHAR(10), B.MuatDate, 3)+' '+CONVERT(VARCHAR(10), B.MuatDate, 108)) as TanggalMuat,(CONVERT(VARCHAR(10), B.CloseDate, 3)+' '+CONVERT(VARCHAR(10), B.CloseDate, 108)) as TanggalSelesai,
																	case
																		when (StatusBooking='Muat') then DATEDIFF(day, B.MuatDate, getdate())
																		when (StatusBooking='Antri') then DATEDIFF(day, B.ChekinDate, getdate())
																		when (StatusBooking='Booking') then DATEDIFF(day, B.CreatedDate, getdate())
																		when (StatusBooking='Close') then DATEDIFF(day, B.CloseDate, getdate())
																		else 0
																	end
																	as totalHari,
																	isnull(B.TripID,0) as TripStr,CONVERT(varchar(10),
																	CASE 
																		WHEN StatusBooking = 'Booking' THEN b.CreatedDate
																		WHEN StatusBooking = 'Antri' THEN [ChekinDate]
																		WHEN StatusBooking = 'Muat' THEN [MuatDate] 
																		ELSE CloseDate 
																	END,103)  +' ' + LEFT(CAST(CONVERT(time,
																	CASE 
																		WHEN StatusBooking = 'Booking' THEN b.CreatedDate
																		WHEN StatusBooking = 'Antri' THEN [ChekinDate]
																		WHEN StatusBooking = 'Muat' THEN [MuatDate] 
																		ELSE CloseDate 
																	END) as varchar(20)),5) AS DateStatus,
																	A.tripawal,C.KaptenKapal as Kapten,C.NoHpKapten as NoKapten,a.id
																	from [tblMstAwalTripPancang] as A
																	right join [Android_tblBookingKapalMuat] as B on A.IDBooking=B.DetailID
																	left join [tblMstKapal] as C on B.IDKapal=C.KapalID
																	AND B.BerangkatDate IS NULL AND (B.BookingID IS NULL OR B.BookingID  = 0)
																	)

																	select a.IDPancang,a.Pancang,a.TripAwal AS TripID,a.StatusBooking,a.ChekinDate,a.MuatDate,a.CloseDate,a.BerangkatDate,a.ChekinPabrik,a.Tujuan,a.DetailID,a.IDKapal,a.NamaKapal,a.CreatedDate,a.flagInvoiceMuat,a.JenisMuat,a.JenisKelapa,a.BookingID,a.Kap,
																	(sum(case when b.Jenis='Licin' then b.NettoAkhir else 0 end) +
																	sum(case when b.Jenis='Jambul' then b.NettoAkhir else 0 end) +
																	sum(case when b.Jenis='Cungkil' then b.NettoAkhir else 0 end) +
																	sum(case when b.Jenis='Arang' then b.NettoAkhir else 0 end)) as realmuat
																	from cte as A
																	left join TblTrnKelapaHdr as B on a.id=B.AwalTripID and Deleted=0
																	where 
																	A.IDPancang NOT IN(10,8) AND A.IDKapal<>21044 " & IIf(sql = "", "", " AND " & sql) & "
																	group by a.IDPancang,a.Pancang,a.TripAwal,a.StatusBooking,a.ChekinDate,a.MuatDate,a.CloseDate,a.BerangkatDate,a.ChekinPabrik,a.Tujuan,a.DetailID,a.IDKapal,a.NamaKapal,a.CreatedDate,a.flagInvoiceMuat,a.JenisMuat,a.JenisKelapa,a.BookingID,a.Kap 
																	order by JenisMuat, TUJUAN,CHEKINDATE Desc"

			dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, query)

			fg.Rows.Count = 1
			If dt.Rows.Count > 0 Then
				'HeaderFGKg()
				With fg
					Call ui.HapusGrid(1, fg)
					For Each row As DataRow In dt.Rows
						.AddItem(i - 1)
						.Item(i, "No") = i
						.Item(i, "Jenis") = row.Item("JenisMuat")
						.Item(i, "Pancang") = row.Item("Pancang")
						.Item(i, "CheckIn") = row.Item("ChekInDate")
						.Item(i, "TanggalMuat") = row.Item("MuatDate")
						.Item(i, "TanggalPenuh") = row.Item("CloseDate")
						.Item(i, "Tujuan") = row.Item("Tujuan")
						.Item(i, "Kapal") = row.Item("NamaKapal")
						.Item(i, "Trip") = row.Item("TripID")
						.Item(i, "StatusBooking") = row.Item("StatusBooking")
						.Item(i, "Kapasitas") = row.Item("Kap")
						.Item(i, "RealMuat") = row.Item("realmuat")
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
			.Subtotal(AggregateEnum.Sum, -1, -1, 8, "TOTAL")
			.Subtotal(AggregateEnum.Sum, 1, 1, 8, "{0}")
			.Subtotal(AggregateEnum.Sum, 2, 2, 8, "{0}")

			.Subtotal(AggregateEnum.Sum, -1, -1, 9)
			.Subtotal(AggregateEnum.Sum, 1, 1, 9, "{0}")
			.Subtotal(AggregateEnum.Sum, 2, 2, 9, "{0}")

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

		fg.AutoSizeCols()
	End Sub

	Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
		Dim sql, SQL2 As String

		If chkPancang.Checked = True Then
			sql = Modul_RMP.Func.SetCondition(sql, "IDPancang='" & cmbPancang.SelectedValue.ToString & "'")
			SQL2 = Modul_RMP.Func.SetCondition(sql, "A.IDPancang='" & cmbPancang.SelectedValue.ToString & "'")
		End If

		Call ShowData(sql)
		Call MuatP1(SQL2)
		Call MuatP2(SQL2)
		Call AntriP1(SQL2)
		Call AntriP2(SQL2)
	End Sub

	Private Sub BtnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
		Dim filename As String
		Me.SaveFileDialog.ShowDialog()
		filename = SaveFileDialog.FileName
		Me.fg.SaveExcel(filename & ".xls", "Sheet1", FileFlags.IncludeFixedCells)
		MsgBox("Convert Success !", vbInformation, AT)
	End Sub

	Private Sub cmbPancang_Validated(sender As Object, e As EventArgs) Handles cmbPancang.Validated
		chkPancang.Checked = IIf(cmbPancang.Text = "", False, True)
	End Sub

	Private Sub cmbPancang_Validating(sender As Object, e As CancelEventArgs) Handles cmbPancang.Validating
		If cmbPancang.Text = "" Then
			Exit Sub
		End If

		If IsNothing(cmbPancang.SelectedValue) Then
			MsgBox("Pilihan tidak ada !", vbExclamation, AT)
			cmbPancang.Text = ""
			cmbPancang.Focus()
		End If
	End Sub

	Private Sub cmbPancang_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbPancang.KeyUp
		UI.AutoCompleteCombo_KeyUp(cmbPancang, e)
	End Sub

	Private Sub chkPancang_CheckedChanged(sender As Object, e As EventArgs) Handles chkPancang.CheckedChanged
		'If chkPancang.Checked = True Then
		'	cmbPancang.Enabled = True
		'Else
		'	cmbPancang.Enabled = False
		'	cmbPancang.Text = ""
		'End If
	End Sub

	Private Sub chkMuatAntri_CheckedChanged(sender As Object, e As EventArgs) Handles chkMuatAntri.CheckedChanged
		If chkMuatAntri.Checked Then
			chkSelesai.Checked = False
		End If
	End Sub

	Private Sub chkSelesai_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelesai.CheckedChanged
		If chkSelesai.Checked Then
			chkMuatAntri.Checked = False
		End If
	End Sub
End Class
