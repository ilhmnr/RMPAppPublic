Imports System.ComponentModel
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmTrnInputTrip
	Dim text_ As String
	Dim dt As DataTable = New DataTable()
	Public Indlebih, IDKapal, IndShow, Jalan, IndRelasiPcg, FlagTglMasukKapal As Integer
	Dim KapalTenggelam As String

	Private Sub FrmInputTripNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Modul_RMP.Combo.SetPancang(cmbPancang)
		Modul_RMP.Combo.SetKapal(cmbKapal)
		Call HeaderFG()
		Call Search()
		Call ClearData()
		text_ = Label6.Text
		cmbTrip.Enabled = True
		TimerInfo.Start()
	End Sub

	Private Sub ClearData()
		UI.ClearText(grpFilterData)
		UI.EnabledTrue(grpFilterData)
		DTPStart.Enabled = True
		DTPEnd.Enabled = True
		chkTransDate.Checked = True
		chkTransDate.Enabled = True
		fg.Rows.Count = 2
		btnSave.Enabled = False
		cmbTrip.Enabled = True
		cmbTrip.Text = ""
		fg.AutoSizeCols()
	End Sub

	Private Sub TimerInfo_Tick(sender As Object, e As EventArgs) Handles TimerInfo.Tick
		Label6.Text = Jalan
		text_ = Microsoft.VisualBasic.Right(text_, Len(text_) - 1) & Microsoft.VisualBasic.Left(text_, 1)
		Label6.Text = text_
	End Sub

	Private Sub chkPancang_CheckedChanged(sender As Object, e As EventArgs) Handles chkPancang.CheckedChanged
		Call UI.ChkCondCmb(chkPancang, cmbPancang, "Pancang")
	End Sub

	Private Sub chkKapal_CheckedChanged(sender As Object, e As EventArgs) Handles chkKapal.CheckedChanged
		Call UI.ChkCondCmb(chkKapal, cmbKapal, "Kapal")
	End Sub

#Region "CmbPancang"
	Private Sub cmbPancang_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbPancang.KeyUp
		UI.AutoCompleteCombo_KeyUp(cmbPancang, e)
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

		'Modul_RMP.Combo.SetKapalPerPCG(cmbKapal, cmbPancang.SelectedValue)
	End Sub

	Private Sub cmbPancang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbPancang.KeyPress
		If (e.KeyChar = Chr(13)) Then
			cmbKapal.Focus()
		End If
	End Sub
#End Region

#Region "CmbKapal"
	Private Sub cmbKapal_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbKapal.KeyUp
		UI.AutoCompleteCombo_KeyUp(cmbKapal, e)
	End Sub

	Private Sub cmbKapal_Validated(sender As Object, e As EventArgs) Handles cmbKapal.Validated
		chkKapal.Checked = IIf(cmbKapal.Text = "", False, True)
	End Sub

	Private Sub cmbKapal_Validating(sender As Object, e As CancelEventArgs) Handles cmbKapal.Validating
		If cmbKapal.Text = "" Then
			Exit Sub
		End If

		If IsNothing(cmbKapal.SelectedValue) Then
			MsgBox("Pilihan tidak ada !", vbExclamation, AT)
			cmbKapal.Text = ""
			cmbKapal.Focus()
		End If
	End Sub

	Private Sub cmbKapal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbKapal.KeyPress
		If (e.KeyChar = Chr(13)) Then
			btnRefresh.Focus()
		End If
	End Sub

	Private Sub cmbKapal_Click(sender As Object, e As EventArgs) Handles cmbKapal.Click
		If IsNothing(cmbPancang.SelectedValue) Then
			MsgBox("Pancang is Empty!", vbExclamation, AT)
			cmbPancang.Text = ""
			cmbPancang.Focus()
		End If
	End Sub

#End Region

#Region "Data"
	Private Sub Search()
		With schfg
			.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
			.SearchDelay = 2
			.Watermark = "Cari Disini"
			.SetC1FlexGridSearchPanel(fg, schfg)
		End With
	End Sub

	Public Sub HeaderFG()
		Dim txt As CellRange
		With fg
			.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
			.Cols.Count = 28
			.Cols.Fixed = 2
			.Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
			.Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
			.Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
			.Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)
			.Rows(1).StyleNew.BackColor = Color.FromArgb(242, 222, 222)
			.Rows(1).StyleFixedNew.BackColor = Color.FromArgb(223, 240, 216)

			.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
			.Styles.Normal.WordWrap = True
			.Rows.Fixed = 2
			.AllowMerging = AllowMergingEnum.FixedOnly
			.Rows(0).AllowMerging = True
			.Rows(1).AllowMerging = True
			.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

			txt = .GetCellRange(0, 0, 1, 0) : txt.Data = "No" : .Cols(0).AllowMerging = True
			txt = .GetCellRange(0, 1, 1, 1) : txt.Data = "NoNota" : .Cols(1).AllowMerging = True
			txt = .GetCellRange(0, 2, 1, 2) : txt.Data = "Trip" : .Cols(2).AllowMerging = True : .Cols(2).TextAlign = TextAlignEnum.CenterCenter
			txt = .GetCellRange(0, 3, 1, 3) : txt.Data = "Tanggal" : .Cols(3).AllowMerging = True : .Cols(3).TextAlign = TextAlignEnum.CenterCenter
			txt = .GetCellRange(0, 4, 1, 4) : txt.Data = "Via" : .Cols(4).AllowMerging = True : .Cols(4).TextAlign = TextAlignEnum.CenterCenter
			txt = .GetCellRange(0, 5, 0, 7) : txt.Data = "PANCANG"
			txt = .GetCellRange(1, 5, 1, 5) : txt.Data = "ID" : .Cols(5).AllowMerging = True : .Cols(5).TextAlign = TextAlignEnum.RightCenter : .Cols(5).Visible = True
			txt = .GetCellRange(1, 6, 1, 6) : txt.Data = "Nama" : .Cols(6).AllowMerging = True : .Cols(6).TextAlign = TextAlignEnum.LeftCenter
			txt = .GetCellRange(1, 7, 1, 7) : txt.Data = "KodeSup1" : .Cols(7).AllowMerging = True : .Cols(7).TextAlign = TextAlignEnum.LeftCenter : .Cols(7).Visible = False
			txt = .GetCellRange(0, 8, 0, 9) : txt.Data = "KAPAL"
			txt = .GetCellRange(1, 8, 1, 8) : txt.Data = "ID" : .Cols(8).AllowMerging = True : .Cols(8).TextAlign = TextAlignEnum.RightCenter
			txt = .GetCellRange(1, 9, 1, 9) : txt.Data = "Nama" : .Cols(9).AllowMerging = True : .Cols(9).TextAlign = TextAlignEnum.LeftCenter
			txt = .GetCellRange(0, 10, 0, 12) : txt.Data = "RELASI"
			txt = .GetCellRange(1, 10, 1, 10) : txt.Data = "ID" : .Cols(10).AllowMerging = True : .Cols(10).TextAlign = TextAlignEnum.CenterCenter
			txt = .GetCellRange(1, 11, 1, 11) : txt.Data = "Nama" : .Cols(11).AllowMerging = True : .Cols(11).TextAlign = TextAlignEnum.LeftCenter
			txt = .GetCellRange(1, 12, 1, 12) : txt.Data = "Alamat" : .Cols(12).AllowMerging = True : .Cols(12).TextAlign = TextAlignEnum.LeftCenter
			txt = .GetCellRange(0, 13, 0, 15) : txt.Data = "PENERIMA UANG"
			txt = .GetCellRange(1, 13, 1, 13) : txt.Data = "ID" : .Cols(13).AllowMerging = True : .Cols(13).TextAlign = TextAlignEnum.CenterCenter
			txt = .GetCellRange(1, 14, 1, 14) : txt.Data = "Nama" : .Cols(14).AllowMerging = True : .Cols(14).TextAlign = TextAlignEnum.LeftCenter
			txt = .GetCellRange(1, 15, 1, 15) : txt.Data = "Alamat" : .Cols(15).AllowMerging = True : .Cols(15).TextAlign = TextAlignEnum.LeftCenter
			txt = .GetCellRange(0, 16, 0, 18) : txt.Data = "SUB PETANI"
			txt = .GetCellRange(1, 16, 1, 16) : txt.Data = "ID" : .Cols(16).AllowMerging = True : .Cols(16).TextAlign = TextAlignEnum.CenterCenter
			txt = .GetCellRange(1, 17, 1, 17) : txt.Data = "Nama" : .Cols(17).AllowMerging = True : .Cols(17).TextAlign = TextAlignEnum.LeftCenter
			txt = .GetCellRange(1, 18, 1, 18) : txt.Data = "Alamat" : .Cols(18).AllowMerging = True : .Cols(18).TextAlign = TextAlignEnum.LeftCenter
			txt = .GetCellRange(0, 19, 0, 26) : txt.Data = "TIMBANG PANCANG"
			txt = .GetCellRange(1, 19, 1, 19) : txt.Data = "Bruto" : .Cols(19).AllowMerging = True : .Cols(19).Format = "#,###0"
			txt = .GetCellRange(1, 20, 1, 20) : txt.Data = "Tarra Jaring" : .Cols(20).AllowMerging = True : .Cols(20).Format = "#,###0"
			txt = .GetCellRange(1, 21, 1, 21) : txt.Data = "Netto" : .Cols(21).AllowMerging = True : .Cols(21).Format = "#,###0"
			txt = .GetCellRange(1, 22, 1, 22) : txt.Data = "Tarra-[%]" : .Cols(22).AllowMerging = True : .Cols(22).Format = "#,###0"
			txt = .GetCellRange(1, 23, 1, 23) : txt.Data = "Tarra POT-[%]" : .Cols(23).AllowMerging = True : .Cols(23).Format = "#,###0"
			txt = .GetCellRange(1, 24, 1, 24) : txt.Data = "Netto Akhir" : .Cols(24).AllowMerging = True : .Cols(24).Format = "#,###0"
			txt = .GetCellRange(1, 25, 1, 25) : txt.Data = "Rp" : .Cols(25).AllowMerging = True : .Cols(25).Format = "#,###0"
			txt = .GetCellRange(0, 26, 1, 26) : txt.Data = "Total Rp" : .Cols(26).AllowMerging = True : .Cols(26).Format = "#,###0"
			txt = .GetCellRange(0, 27, 1, 27) : txt.Data = "Grade Sub" : .Cols(27).AllowMerging = True : .Cols(27).TextAlign = TextAlignEnum.LeftCenter
			.AutoSizeCols()
		End With
	End Sub

	Public Sub FilterData(ByVal Ind_ As Integer)
		If Ind_ = 0 Then
			'cmbTrip.Text = ""
			Call ShowData()
		ElseIf Ind_ = 1 Then
			'With FrmMonPemasukanKelapaPCG
			'	DTPStart.Value = .DTPStart.Value
			'	DTPEnd.Value = .DTPEnd.Value
			'	IDKapal = .cmbKapal.SelectedValue
			'	cmbKapal.Text = .cmbKapal.Text
			'	chkKapal.Checked = True
			'	cmbPancang.SelectedValue = .cmbPancang.SelectedValue
			'	cmbPancang.Text = .cmbPancang.Text
			'	chkPancang.Checked = True
			'End With
			'cmbTrip.Text = ""
			Call ShowData()
		ElseIf Ind_ = 2 Then
			UI.EnabledFalse(grpFilterData)
			DTPStart.Enabled = False
			DTPEnd.Enabled = False
			chkTransDate.Checked = False
			chkTransDate.Enabled = False
			Call ShowData()
		End If
	End Sub

	Private Sub ShowData()
		Cursor = Cursors.WaitCursor
		Application.DoEvents()
		Try
			Dim dt As DataTable = New DataTable()
			Dim i As Integer = 2
			Dim diff As Integer
			Dim sql As String = ""

			diff = DateDiff("d", Format(DTPStart.Value, "dd/MM/yyyy"), Format(DTPEnd.Value, "dd/MM/yyyy"))
			If diff < 0 Then
				MsgBox("Filter Date invalid", vbExclamation, AT)
				DTPStart.Value = Now
				DTPEnd.Value = Now
				DTPEnd.Focus()
				Exit Try
			End If

			If chkTransDate.Checked = True Then
				sql = Modul_RMP.Func.SetCondition(sql, "CONVERT(DATETIME, CONVERT(VARCHAR, TransDate, 103),103) between CONVERT (DATETIME,'" & Format(DTPStart.Value, "dd/MM/yyyy") & "',103) and CONVERT (DATETIME,'" & Format(DTPEnd.Value, "dd/MM/yyyy") & "',103)")
			End If

			If chkPancang.Checked = True Then
				sql = Modul_RMP.Func.SetCondition(sql, "IDPancang = '" & cmbPancang.SelectedValue & "'")
			Else
				MsgBox("Pancang Is Empty !", MsgBoxStyle.Exclamation, AT)
				cmbPancang.Focus()
				Exit Sub
			End If

			If chkKapal.Checked = True Then
				sql = Modul_RMP.Func.SetCondition(sql, "IDKapal = '" & IIf(cmbKapal.SelectedValue = Nothing, IDKapal, cmbKapal.SelectedValue) & "'")
				'sql = Modul_RMP.Func.SetCondition(sql, "Kapal LIKE '%" & cmbKapal.Text & "%'")
			Else
				MsgBox("Kapal Is Empty !", MsgBoxStyle.Exclamation, AT)
				cmbKapal.Focus()
				Exit Sub
			End If

			'dt = DB.ExecuteQuery(StrConnRMPApp,"select * from vwTMBGKelapaHdr where TransDate >= '2019-10-01' and Deleted=0 and IndNota = 0 and Trip IS NULL order by TransDate desc")

			'If cmbTrip.Text <> "" Then
			'	sql = Modul_RMP.Func.SetCondition(sql, "Trip = '" & cmbTrip.Text & "'")
			'	dt = DB.ExecuteQuery(StrConnRMPApp,"select * from vwTMBGKelapaHdr where TransDate >= '2019-10-01' and Deleted=0 and IndNota = 0 and IndUM = 0 " & IIf(sql = "", "", " And " & sql) & " order by IDRelasi")
			'Else
			'	dt = DB.ExecuteQuery(StrConnRMPApp,"select * from vwTMBGKelapaHdr where TransDate >= '2019-10-01' and Trip IS NULL and Deleted=0 and IndNota = 0 and IndUM = 0 " & IIf(sql = "", "", " And " & sql) & " order by IDRelasi")
			'End If

			'dt = DB.ExecuteQuery(StrConnRMPApp,"select * from vwTMBGKelapaHdr where TransDate >= '2019-10-01' and Trip = '" & cmbTrip.Text & "' and Deleted=0 and IndNota = 0 and IndUM = 0 " & IIf(sql = "", "", " And " & sql) & " order by IDRelasi")

			dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select * from vwTMBGKelapaHdr where TransDate >= '2019-10-01' and Trip = '" & cmbTrip.Text & "' and Deleted=0 and IndNota = 0 " & IIf(sql = "", "", " And " & sql) & " order by IDRelasi")

			If dt.Rows.Count > 0 Then
				With fg
					fg.Rows.Count = 2
					For Each row As DataRow In dt.Rows
						.AddItem(i - 1)
						.Item(i, 1) = row.Item("NoNota")
						.Item(i, 2) = row.Item("Trip")
						.Item(i, 3) = Format(row.Item("TransDate"), "dd/MM/yyyy")
						.Item(i, 4) = row.Item("Pembayaran")
						.Item(i, 5) = row.Item("IDPancang")
						.Item(i, 6) = row.Item("Pancang")
						.Item(i, 8) = row.Item("IDKapal")
						.Item(i, 9) = row.Item("Kapal")
						.Item(i, 10) = row.Item("IDRelasi")
						.Item(i, 11) = row.Item("NamaRelasi")
						.Item(i, 12) = row.Item("AlamatRelasi")
						.Item(i, 13) = row.Item("IDPenerimaUang")
						.Item(i, 14) = row.Item("PenerimaUang")
						.Item(i, 15) = row.Item("AlamatPenerimaUang")
						.Item(i, 16) = row.Item("IDSubPetani")
						.Item(i, 17) = row.Item("SubPetani")
						.Item(i, 18) = row.Item("AlamatSubPetani")
						.Item(i, 19) = row.Item("Brutto")
						.Item(i, 20) = row.Item("TarraJaring")
						.Item(i, 21) = row.Item("Netto")
						.Item(i, 22) = row.Item("TarraPersen")
						.Item(i, 23) = row.Item("TarraKg")
						.Item(i, 24) = row.Item("NettoAkhir")
						.Item(i, 25) = row.Item("Harga")
						.Item(i, 26) = row.Item("TotalHarga")
						.Item(i, 27) = row.Item("GradeSub")
						i = i + 1
					Next
					.AutoSizeCols()
				End With
				ShowTotals()
				'CekRelasiPcg()
				CekTotPenjRelasi()
				CekFlagTglMasukKapal()
				btnSave.Enabled = True
				cmbTrip.Enabled = True
			Else
				fg.Rows.Count = 2
				MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
				btnSave.Enabled = False
				cmbTrip.Enabled = False
			End If

		Catch ex As Exception
			MessageBox.Show(ex.Message)
		Finally
			Cursor = Cursors.Default
		End Try
	End Sub

	Private Sub CekRelasiPcg()
		Dim dt As DataTable = New DataTable()
		For k = 3 To fg.Rows.Count - 1
			dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select IDPancang From RMPApp..vwMstRelasi where KodeSup = '" & fg.Item(k, 10) & "'")
			If dt.Rows(0).Item("IDPancang") <> fg.Item(k, 5) Then
				fg.Rows(k).StyleNew.BackColor = Color.BlueViolet
				fg.Rows(k).StyleNew.ForeColor = Color.White
				IndRelasiPcg = IndRelasiPcg + fg.Item(k, 0)
			End If
		Next
	End Sub

	Private Sub ShowTotals()
		With fg
			.Tree.Column = 0
			.Tree.Style = TreeStyleFlags.Simple
			.Subtotal(AggregateEnum.Clear)

			.Subtotal(AggregateEnum.Sum, -1, -1, 19, "")
			.Subtotal(AggregateEnum.Sum, -1, -1, 20, "")
			.Subtotal(AggregateEnum.Sum, -1, -1, 21, "")
			.Subtotal(AggregateEnum.Sum, -1, -1, 23, "")
			.Subtotal(AggregateEnum.Sum, -1, -1, 24, "")
			.Subtotal(AggregateEnum.Sum, -1, -1, 26, "")
			.AutoSizeCols()
		End With
		Call ColorSubTotal()
	End Sub

	Private Sub ColorSubTotal()
		Dim cs As C1.Win.C1FlexGrid.CellStyle
		With fg
			cs = .Styles(C1.Win.C1FlexGrid.CellStyleEnum.GrandTotal)
			cs.BackColor = Color.FromArgb(73, 173, 8)
			cs.ForeColor = Color.White
			cs.Font = New Font(Font, FontStyle.Bold)
		End With
	End Sub

	Private Sub CekTotPenjRelasi()
		Dim dt As DataTable = New DataTable()
		Dim dt2 As DataTable = New DataTable()
		With fg
			For i = 3 To .Rows.Count - 1
				dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT SUM(Total) AS Total FROM RSUPAccounting..vwRMTrnPenerimaanKBDtla WHERE YEAR(TglTerima) = YEAR(GETDATE()) AND MONTH(TglTerima) = MONTH(GETDATE()) AND KodeSup = '" & .Item(i, 10) & "'")
				dt2 = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT idpancang  FROM RMPApp..Android_tblMstPancang  WHERE idpancang  = '" & cmbPancang.SelectedValue.ToString & "' and  TdkBoleh20 = 1 ")


				If (CDbl(IIf(IsDBNull(dt.Rows(0).Item("Total")), 0, dt.Rows(0).Item("Total"))) + .Item(i, 26)) > 4500000000 And dt2.Rows.Count > 0 Then
					.Rows(i).StyleNew.BackColor = Color.Red
					.Rows(i).StyleNew.ForeColor = Color.White
					Indlebih = 1
				End If
			Next
		End With
	End Sub

	Private Sub CekFlagTglMasukKapal()
		Dim dt As DataTable = New DataTable()

		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "IF EXISTS (SELECT TOP 1 TransID FROM RMPApp..TblTrnKelapaHdr 
														   WHERE IDPancang = '" & cmbPancang.SelectedValue & "' AND IDKapal = '" & fg.Item(3, 8) & "' AND 
														   Trip = '" & fg.Item(3, 2) & "' AND EndTimbangDate IS NOT NULL)
														   BEGIN
															 SELECT 1 AS Flag
														   END
														   ELSE
														   BEGIN
															 SELECT 0 AS Flag
														   END")

		If dt.Rows(0).Item("Flag") = 1 Then
			FlagTglMasukKapal = 1
		ElseIf dt.Rows(0).Item("Flag") = 0 Then
			FlagTglMasukKapal = 0
		End If
	End Sub

	Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
		Call FilterData(0)
	End Sub

	Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
		CekTotPenjRelasi()
		CekFlagTglMasukKapal()

		If cmbPancang.SelectedValue = Nothing Then
			MsgBox("Pancang is Empty !", MsgBoxStyle.Exclamation, AT)
			cmbPancang.Focus()
			Exit Sub
		End If

		If cmbKapal.SelectedValue = Nothing And IDKapal = 0 Then
			MsgBox("Kapal is Empty !", MsgBoxStyle.Exclamation, AT)
			cmbKapal.Focus()
			Exit Sub
		End If

		If cmbTrip.Text = "" Then
			MsgBox("Trip is Empty !", MsgBoxStyle.Exclamation, AT)
			cmbTrip.Focus()
			Exit Sub
		End If

		'If Indlebih > 0 Then
		'	MsgBox("Ada relasi yang lebih dari 20Jt !" & vbNewLine & "Silahkan edit nota !", MsgBoxStyle.Exclamation, AT)
		'	Exit Sub
		'End If

		If FlagTglMasukKapal = 0 Then
			MsgBox("Tgl Masuk Kapal tidak bisa diinput karena nota timbang belum penuh !", MsgBoxStyle.Exclamation, AT)
			Exit Sub
		End If

		Dim result As Integer = MessageBox.Show("Apakah data sudah benar ?" & vbNewLine & "Pastikan Tanggal Masuk Kapal Sudah Benar !", AT, MessageBoxButtons.YesNo)
		If result = DialogResult.Yes Then
			Call SaveData()
		ElseIf result = DialogResult.No Then
			Exit Sub
		End If
	End Sub

	Private Sub chkKapalTenggelam_CheckedChanged(sender As Object, e As EventArgs) Handles chkKapalTenggelam.CheckedChanged
		If chkKapalTenggelam.Checked = True Then
			KapalTenggelam = "Kapal Tenggelam"
		End If
	End Sub

	Private Sub cmbPancang_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPancang.SelectedIndexChanged

	End Sub

	Private Sub cmbKapal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbKapal.SelectedIndexChanged

	End Sub

	Private Sub chkTransDate_CheckedChanged(sender As Object, e As EventArgs) Handles chkTransDate.CheckedChanged

	End Sub

	Private Sub rdP1_CheckedChanged(sender As Object, e As EventArgs) Handles rdP1.CheckedChanged

	End Sub

	Private Sub cmbTrip_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTrip.SelectedIndexChanged

	End Sub

	Private Sub rdP2_CheckedChanged(sender As Object, e As EventArgs) Handles rdP2.CheckedChanged

	End Sub

	Private Function CekTrip(ByVal IDPancang_ As Integer, ByVal Trip_ As String) As Integer
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select * from TblTrnKelapaHdr " &
															 "where Deleted = 0 And IDPancang = '" & IDPancang_ & "' " &
															 "And Trip = '" & Trip_ & "' and " &
															 "MONTH(TransDate) = MONTH(GETDATE())")
		CekTrip = dt.Rows.Count
		Return CekTrip
	End Function

	Private Sub SaveData()
		Me.Cursor = Cursors.WaitCursor
		Try
			Dim koneksi As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnRMPApp)
			Dim Transaksi As SqlTransaction
			Transaksi = koneksi.BeginTransaction

			With fg
				For i = 3 To .Rows.Count - 1
					If Simpan(koneksi, Transaksi, Format(DTPTglMasuk.Value, "yyyy/MM/dd"), cmbTrip.Text, .Item(i, 1), ClsSession.UserID, IIf(cmbKapal.SelectedValue = Nothing, IDKapal, cmbKapal.SelectedValue), cmbPancang.SelectedValue, KapalTenggelam) = False Then
						Transaksi.Rollback()
						MsgBox("Simpan Data Gagal", vbExclamation, "Save Data - " & AT)
						Exit Try
					End If
				Next
			End With

			Transaksi.Commit()
			MessageBox.Show("Save Completed !", "Save Data - " & AT, MessageBoxButtons.OK, MessageBoxIcon.Information)
			Call ClearData()
		Catch ex As Exception
			MessageBox.Show(ex.Message, "Save Data - " & AT, MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			Me.Cursor = Cursors.Default
		End Try
	End Sub

	Private Function Simpan(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal TglMasuk As String, ByVal Trip_ As String, ByVal Nonota_ As String, ByVal UpdatedTripBy_ As String, ByVal IDKapal_ As Integer,
							ByVal IDPancang_ As Integer, ByVal KapalTenggelam As String) As Boolean
		Dim MyCMD, cmdTrip As New SqlCommand




		Try
			'If rdP1.Checked = True Then

			With MyCMD
				.Connection = Conn
				.CommandType = CommandType.Text
				.Transaction = Trans
				'.CommandText = "Update RMPApp..TblTrnKelapaHdr set TglMasukKapal = '" & TglMasuk & "' ,Trip = '" & Trip_ & "', UpdatedTripBy = '" & UpdatedTripBy_ & "', UpdatedTripDate = GETDATE(), Bongkar = 'P1' " &
				'			   "where IDKapal = '" & IDKapal_ & "' and IDPancang = '" & IDPancang_ & "' and NoNota = '" & Nonota_ & "'"


				If chkKapalTenggelam.Checked = True Then
					.CommandText = "UPDATE RMPApp..TblTrnKelapaHdr SET TglMasukKapal = NULL,KeteranganKapal = '" & KapalTenggelam & "', UpdatedTripBy = NULL, UpdatedTripDate = GETDATE() " &
							   "WHERE IDKapal = '" & IDKapal_ & "' AND IDPancang = '" & IDPancang_ & "' AND NoNota = '" & Nonota_ & "'"
				Else
					.CommandText = "UPDATE RMPApp..TblTrnKelapaHdr SET TglMasukKapal = '" & TglMasuk & "',KeteranganKapal= NULL, UpdatedTripBy = '" & UpdatedTripBy_ & " (UPDATE TGL MASUK)', UpdatedTripDate = GETDATE() " &
							   "WHERE IDKapal = '" & IDKapal_ & "' AND IDPancang = '" & IDPancang_ & "' AND NoNota = '" & Nonota_ & "'"
				End If

				'.CommandText = "UPDATE RMPApp..TblTrnKelapaHdr SET TglMasukKapal = NULL WHERE IDKapal = '" & IDKapal_ & "' AND IDPancang = '" & IDPancang_ & "' AND NoNota = '" & Nonota_ & "'"

				.ExecuteNonQuery()
				.Dispose()
			End With

			With cmdTrip '  at : 2020-07-30 16:30

				.Connection = Conn
				.CommandType = CommandType.Text
				.Transaction = Trans

				If chkKapalTenggelam.Checked = True Then

					Dim sql = "UPDATE [RMPApp].[dbo].[Android_tblBookingKapalMuat] SET ChekinPabrik = NULL,Keterangan ='Edit tanggal masuk kapal tenggelam manual : " & ClsSession.UserID & "' WHERE IDPancang = '" & IDPancang_ & "' AND IDKapal = '" & IDKapal_ & "' AND  TripID = '" & CInt(Trip_) & "'"
					.CommandText = sql
				Else
					Dim sql = "UPDATE [RMPApp].[dbo].[Android_tblBookingKapalMuat] SET ChekinPabrik = '" & TglMasuk & "',Keterangan ='Edit tanggal masuk kapal manual : " & ClsSession.UserID & "' WHERE IDPancang = '" & IDPancang_ & "' AND IDKapal = '" & IDKapal_ & "' AND  TripID = '" & CInt(Trip_) & "'"

					.CommandText = sql
				End If
				.ExecuteNonQuery()
				.Dispose()
			End With

			'ElseIf rdP2.Checked = True Then
			'	With MyCMD
			'		.Connection = Conn
			'		.CommandType = CommandType.Text
			'		.Transaction = Trans
			'		'.CommandText = "Update RMPApp..TblTrnKelapaHdr set TglMasukKapal = '" & TglMasuk & "' ,Trip = '" & Trip_ & "', UpdatedTripBy = '" & UpdatedTripBy_ & "', UpdatedTripDate = GETDATE(), Bongkar = 'P2' " &
			'		'			   "where IDKapal = '" & IDKapal_ & "' and IDPancang = '" & IDPancang_ & "' and NoNota = '" & Nonota_ & "'"

			'		.CommandText = "Update RMPApp..TblTrnKelapaHdr set TglMasukKapal = '" & TglMasuk & "' , Bongkar = 'P2' " &
			'					   "where IDKapal = '" & IDKapal_ & "' and IDPancang = '" & IDPancang_ & "' and NoNota = '" & Nonota_ & "'"
			'		.ExecuteNonQuery()
			'		.Dispose()
			'	End With
			'End If
		Catch ex As Exception
			MessageBox.Show(ex.Message)
			Return False
		End Try
		Return True
	End Function

	Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
		Call ClearData()
	End Sub

	Private Sub BtnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
		With FrmTrnInputTripShow
			.ShowDialog()
			.clearData()
		End With
	End Sub
#End Region
End Class
