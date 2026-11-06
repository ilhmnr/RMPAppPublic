Imports System.ComponentModel
Imports C1.Win.C1FlexGrid

Public Class FrmTrnInputTripShow
	Private Sub FrmInputTrip_Show_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Modul_RMP.Combo.SetPancang(cmbPancang)
		Call HeaderFG_()
		Call search()
		Call clearData()
	End Sub
	Public Sub clearData()
		UI.ClearText(grpFilterData)
		cmbTrip.Text = ""
		chkTrip.Checked = False
		cmbPancang.Text = ""
		chkPancang.Checked = False
		cmbKapal.Text = ""
		chkKapal.Checked = False
		fg.Rows.Count=2
	End Sub
	Private Sub chkPancang_CheckedChanged(sender As Object, e As EventArgs) Handles chkPancang.CheckedChanged
		Call UI.ChkCondCmb(chkPancang, cmbPancang, "Pancang")
	End Sub
	Private Sub chkKapal_CheckedChanged(sender As Object, e As EventArgs) Handles chkKapal.CheckedChanged
		Call UI.ChkCondCmb(chkKapal, cmbKapal, "Kapal")
	End Sub
	Private Sub chkTrip_CheckedChanged(sender As Object, e As EventArgs) Handles chkTrip.CheckedChanged
		Call UI.ChkCondCmb(chkTrip, cmbTrip, "Trip")
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

#Region "CmbTrip"
	Private Sub cmbTrip_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbTrip.KeyUp
		UI.AutoCompleteCombo_KeyUp(cmbTrip, e)
	End Sub

	Private Sub cmbTrip_Validated(sender As Object, e As EventArgs) Handles cmbTrip.Validated
		chkTrip.Checked = IIf(cmbTrip.Text = "", False, True)
	End Sub

	Private Sub cmbTrip_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbTrip.KeyPress
		If (e.KeyChar = Chr(13)) Then
			cmbPancang.Focus()
		End If
	End Sub

#End Region

#Region "Data"
	Private Sub search()
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
			.AllowEditing = True
			.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
			.Cols.Count = 8
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
			txt = .GetCellRange(0, 1, 1, 1) : txt.Data = "Trip" : .Cols(1).AllowMerging = True : .Cols(1).TextAlign = TextAlignEnum.CenterCenter
			txt = .GetCellRange(0, 2, 0, 3) : txt.Data = "PANCANG"
			txt = .GetCellRange(1, 2, 1, 2) : txt.Data = "ID" : .Cols(2).AllowMerging = True : .Cols(2).TextAlign = TextAlignEnum.RightCenter : .Cols(2).Visible = True
			txt = .GetCellRange(1, 3, 1, 3) : txt.Data = "Nama" : .Cols(3).AllowMerging = True : .Cols(3).TextAlign = TextAlignEnum.LeftCenter
			txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "KAPAL"
			txt = .GetCellRange(1, 4, 1, 4) : txt.Data = "ID" : .Cols(4).AllowMerging = True : .Cols(4).TextAlign = TextAlignEnum.RightCenter
			txt = .GetCellRange(1, 5, 1, 5) : txt.Data = "Nama" : .Cols(5).AllowMerging = True : .Cols(5).TextAlign = TextAlignEnum.LeftCenter
			txt = .GetCellRange(0, 6, 1, 6) : txt.Data = "Trip By" : .Cols(6).AllowMerging = True : .Cols(6).TextAlign = TextAlignEnum.CenterCenter
			txt = .GetCellRange(0, 7, 1, 7) : txt.Data = "Trip Date" : .Cols(7).AllowMerging = True : .Cols(7).TextAlign = TextAlignEnum.CenterCenter
			.AutoSizeCols()
		End With
	End Sub

	Public Sub HeaderFG_()
		Dim txt As CellRange
		With fg
			.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
			.Cols.Count = 32
			.Cols.Fixed = 3
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
			txt = .GetCellRange(0, 27, 0, 28) : txt.Data = "TRIP"
			txt = .GetCellRange(1, 27, 1, 27) : txt.Data = "User" : .Cols(27).Visible = True : .Cols(27).TextAlign = TextAlignEnum.CenterCenter
			txt = .GetCellRange(1, 28, 1, 28) : txt.Data = "Date" : .Cols(28).Visible = True : .Cols(28).TextAlign = TextAlignEnum.CenterCenter
			txt = .GetCellRange(0, 29, 0, 30) : txt.Data = "INDIKATOR"
			txt = .GetCellRange(1, 29, 1, 29) : txt.Data = "UM"
			txt = .GetCellRange(1, 30, 1, 30) : txt.Data = "Invoice"
			txt = .GetCellRange(0, 31, 1, 31) : txt.Data = "Grade Sub" : .Cols(31).AllowMerging = True : .Cols(31).TextAlign = TextAlignEnum.LeftCenter
			.AutoSizeCols()
		End With
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
				sql = Modul_RMP.Func.SetCondition(sql, " CONVERT(DATETIME,CONVERT(VARCHAR, TransDate,103),103) BETWEEN CONVERT (DATETIME,'" & Format(DTPStart.Value, "dd/MM/yyyy") & "',103) AND CONVERT(DATETIME,'" & Format(DTPEnd.Value, "dd/MM/yyyy") & "',103)")
			End If

			If chkPancang.Checked = True Then
				sql = Modul_RMP.Func.SetCondition(sql, "IDPancang = '" & cmbPancang.SelectedValue & "'")
			End If

			If chkKapal.Checked = True Then
				sql = Modul_RMP.Func.SetCondition(sql, "IDKapal = '" & cmbKapal.SelectedValue & "'")
				'sql = Modul_RMP.Func.SetCondition(sql, "Kapal LIKE '%" & cmbKapal.Text & "%'")
			End If

			If chkTrip.Checked = True Then
				sql = Modul_RMP.Func.SetCondition(sql, "Trip = '" & cmbTrip.Text & "'")
			End If

			'dt = DB.ExecuteQuery(StrConnRMPApp,"select Distinct Trip,IDPancang,Pancang,IDKapal,Kapal,UpdatedTripBy,UpdatedTripDate from vwTMBGKelapaHdr where TransDate >= '2019-10-01' and Deleted=0 and IndNota = 0 and IndUM = 0 and Trip is Not NULL " & IIf(sql = "", "", " And " & sql) & " order by Trip")
			dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select * from vwTMBGKelapaHdr where TransDate >= '2019-10-01' and Deleted=0 and Trip is Not NULL " & IIf(sql = "", "", " And " & sql) & " order by Trip")

			If dt.Rows.Count > 0 Then
				With fg
					fg.Rows.Count=2
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
						.Item(i, 27) = row.Item("UpdatedTripBy")
						.Item(i, 28) = row.Item("UpdatedTripDate")
						.Item(i, 29) = row.Item("IndUM")
						.Item(i, 30) = row.Item("IndNota")
						.Item(i, 31) = row.Item("GradeSub")
						i = i + 1
					Next
					.AutoSizeCols()
				End With
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
#End Region

	Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
		Call ShowData()
	End Sub

	Private Sub fg_DoubleClick(sender As Object, e As EventArgs) Handles fg.DoubleClick
		With FrmTrnInputTrip
			'If fg.GetCellCheck(fg.Row, 29) = CheckEnum.Checked = True Then
			'    MsgBox("Maaf, DO ini sudah Input UM" & vbNewLine & "Tidak bisa edit !", MsgBoxStyle.Information, AT)
			'    Exit Sub
			'End If
			.cmbTrip.Text = fg.Item(fg.Row, 2)
			.cmbPancang.SelectedValue = fg.Item(fg.Row, 5)
			.cmbPancang.Text = fg.Item(fg.Row, 5) & "." & fg.Item(fg.Row, 6)
			.chkPancang.Checked = True
			.IDKapal = fg.Item(fg.Row, 8)
			.cmbKapal.Text = fg.Item(fg.Row, 8) & "." & fg.Item(fg.Row, 9)
			.chkKapal.Checked = True
			.FilterData(2)
		End With
		Me.Close()
	End Sub
End Class
