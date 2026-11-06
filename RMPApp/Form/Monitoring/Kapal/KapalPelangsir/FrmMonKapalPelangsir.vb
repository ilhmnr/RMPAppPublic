Imports System.ComponentModel
Imports C1.Win.C1FlexGrid

Public Class FrmMonKapalPelangsir
	Dim nm As String
	Dim kodebahanbaku As String
	Private Sub FrmMonKapalPelangsir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		nm = "12"
		Modul_RMP.Combo.SetPelangsir(cmbPelangsir)
		Modul_RMP.Combo.SetPancang(cmbPancang)

		HeaderFGKg()



	End Sub


#Region "Data Kg"

#End Region

	Private Sub ShowData()
		Try
			Dim dt As DataTable = New DataTable()
			Dim Sql, sql2 As String
			Dim i As Integer = 2

			If chkPancang.Checked = True Then
				Sql = Modul_RMP.Func.SetCondition(Sql, "pancangID ='" & cmbPancang.SelectedValue.ToString & "'")

			End If

			If chkPelangsir.Checked = True Then
				Sql = Modul_RMP.Func.SetCondition(Sql, "pelangsirid ='" & cmbPelangsir.SelectedValue.ToString & "'")

			End If

			If chktanggal.Checked = True Then
				Sql = Modul_RMP.Func.SetCondition(Sql, "CONVERT(DATETIME, CONVERT(VARCHAR, checkindate, 103),103) between CONVERT (DATETIME,'" & Format(dtcb1.Value, "dd/MM/yyyy") & "',103) and CONVERT (DATETIME,'" & Format(dtcb2.Value, "dd/MM/yyyy") & "',103)")

			End If

			dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select * from RMPApp..vw_mon_pelangsir where pelangsirid is not null  " & IIf(Sql = "", "", " AND " & Sql) & " order by pelangsirid ,ID asc")


			If dt.Rows.Count > 0 Then
				'HeaderFGKg()
				With fg
					fg.Rows.Count=2
					For Each row As DataRow In dt.Rows
						.AddItem(i - 1)
						.Item(i, 1) = row.Item("pelangsirid")
						.Item(i, 2) = row.Item("namapemilik")
						.Item(i, 3) = row.Item("ID")
						.Item(i, 4) = row.Item("namapompong")
						.Item(i, 5) = row.Item("alamatkelapa")
						.Item(i, 6) = row.Item("checkindate")
						.Item(i, 7) = row.Item("muatdate")

						Dim A As String
						Dim B As String
						If i > 2 Then
							If row.Item("ID") <> .Item(i - 1, 3) Then
								.Item(i, 8) = row.Item("Estimasi")
							Else

							End If
						Else
							.Item(i, 8) = row.Item("Estimasi")
						End If

						.Item(i, 9) = row.Item("KapalMuat")
						.Item(i, 10) = row.Item("jumlahmuatan")
						.Item(i, 11) = row.Item("hargatambang")
						.Item(i, 12) = row.Item("hargatambang") * row.Item("jumlahmuatan")
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

	Private Sub HeaderFGKg()
#Region "Design"
		Dim txt As CellRange
		With fg
			.AllowEditing = False
			.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
			.Cols.Count = 13
			.Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
			'.Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
			.Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
			.Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)
			.Rows(1).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
			.Rows(1).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

			.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
			.Styles.Normal.WordWrap = True
			.Rows.Fixed = 2
			.AllowMerging = AllowMergingEnum.FixedOnly

			.Rows(0).AllowMerging = True
			.Rows(1).AllowMerging = True
			.Rows(2).AllowMerging = True
			.Rows(3).AllowMerging = True
			.Rows(4).AllowMerging = True
			.Rows(5).AllowMerging = True
			.Rows(6).AllowMerging = True
			.Rows(7).AllowMerging = True

			.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
#End Region

#Region "DATA==============================================================================================================================================="
			txt = .GetCellRange(0, 1, 0, 8) : txt.Data = "PELANGSIR"
			txt = .GetCellRange(1, 1, 1, 1) : txt.Data = "PelangsirID" : .Cols(1).AllowMerging = True : .Cols(1).TextAlign = TextAlignEnum.LeftCenter : .Cols(1).TextAlignFixed = TextAlignEnum.CenterCenter
			txt = .GetCellRange(1, 2, 1, 2) : txt.Data = "Nama Pelangsir" : .Cols(2).AllowMerging = True : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).TextAlignFixed = TextAlignEnum.CenterCenter
			txt = .GetCellRange(1, 3, 1, 3) : txt.Data = "ID" : .Cols(3).AllowMerging = True : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).TextAlignFixed = TextAlignEnum.CenterCenter
			txt = .GetCellRange(1, 4, 1, 4) : txt.Data = "Nama Kapal" : .Cols(4).AllowMerging = True : .Cols(4).TextAlign = TextAlignEnum.LeftCenter : .Cols(4).TextAlignFixed = TextAlignEnum.CenterCenter
			txt = .GetCellRange(0, 5, 1, 5) : txt.Data = "Alamat" : .Cols(5).AllowMerging = True : .Cols(5).TextAlign = TextAlignEnum.LeftCenter : .Cols(5).TextAlignFixed = TextAlignEnum.CenterCenter
			txt = .GetCellRange(0, 6, 1, 6) : txt.Data = "Tanggal CheckIn" : .Cols(6).AllowMerging = True : .Cols(6).TextAlign = TextAlignEnum.LeftCenter : .Cols(6).TextAlignFixed = TextAlignEnum.CenterCenter
			txt = .GetCellRange(0, 7, 1, 7) : txt.Data = "Tanggal Bongkar" : .Cols(7).AllowMerging = True : .Cols(7).TextAlign = TextAlignEnum.LeftCenter : .Cols(7).TextAlignFixed = TextAlignEnum.CenterCenter
			txt = .GetCellRange(0, 8, 1, 8) : txt.Data = "Estimasi" : .Cols(8).TextAlign = TextAlignEnum.RightCenter : .Cols(8).AllowEditing = False : .Cols(8).Format = "#,###0" : .Cols(8).AllowMerging = True

			txt = .GetCellRange(0, 9, 1, 9) : txt.Data = "KapalMuat" : .Cols(9).TextAlign = TextAlignEnum.LeftCenter : .Cols(9).AllowEditing = False : .Cols(9).AllowMerging = True : .Cols(9).AllowMerging = True
			txt = .GetCellRange(0, 10, 1, 10) : txt.Data = "Jumlah Muatan" : .Cols(10).TextAlign = TextAlignEnum.RightCenter : .Cols(10).AllowEditing = False : .Cols(10).Format = "#,###0" : .Cols(10).AllowMerging = True

			txt = .GetCellRange(0, 11, 1, 11) : txt.Data = "Harga Tambang" : .Cols(11).TextAlign = TextAlignEnum.RightCenter : .Cols(11).AllowEditing = False : .Cols(11).Format = "#,###0" : .Cols(11).AllowMerging = True
			txt = .GetCellRange(0, 12, 1, 12) : txt.Data = "Total Tambang" : .Cols(12).TextAlign = TextAlignEnum.RightCenter : .Cols(12).AllowEditing = False : .Cols(12).Format = "#,###0" : .Cols(12).AllowMerging = True


			.AutoSizeCols()
		End With

	End Sub

	Private Sub GrandTotal()
		With fg
			.Tree.Column = 0
			.Tree.Style = TreeStyleFlags.CompleteLeaf
			.Subtotal(AggregateEnum.Clear)
			.Subtotal(AggregateEnum.Sum, -1, -1, 10, "TOTAL")
			.Subtotal(AggregateEnum.Sum, 1, 2, 10, "Pelangsir-{0}")
			.Subtotal(AggregateEnum.Sum, 3, 3, 10, "ID-{0}")

			.Subtotal(AggregateEnum.Sum, -1, -1, 8)
			.Subtotal(AggregateEnum.Sum, 1, 2, 8)
			.Subtotal(AggregateEnum.Sum, 3, 3, 8)

			.Subtotal(AggregateEnum.Sum, -1, -1, 12)
			.Subtotal(AggregateEnum.Sum, 1, 2, 12)
			.Subtotal(AggregateEnum.Sum, 3, 3, 12)




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
#End Region


	Private Sub chkPancang_CheckedChanged(sender As Object, e As EventArgs) Handles chkPancang.CheckedChanged
		Call UI.ChkCondCmb(chkPancang, cmbPancang, "Pancang")
	End Sub


	Private Sub Chkpelangsir_CheckedChanged(sender As Object, e As EventArgs) Handles chkPelangsir.CheckedChanged
		Call UI.ChkCondCmb(chkPelangsir, cmbPelangsir, "Kapal")
	End Sub




	Private Sub cmbPancang_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbPancang.KeyUp
		UI.AutoCompleteCombo_KeyUp(cmbPancang, e)
	End Sub

	Private Sub Chkpelangsir__KeyUp(sender As Object, e As KeyEventArgs) Handles cmbPelangsir.KeyUp
		UI.AutoCompleteCombo_KeyUp(cmbPelangsir, e)
	End Sub



	Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
		Call ShowData()
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

	Private Sub cmbPelangsir_Validated(sender As Object, e As EventArgs) Handles cmbPelangsir.Validated
		chkPelangsir.Checked = IIf(cmbPelangsir.Text = "", False, True)
	End Sub

	Private Sub cmbPelangsir_Validating(sender As Object, e As CancelEventArgs) Handles cmbPelangsir.Validating
		chkPelangsir.Checked = IIf(cmbPelangsir.Text = "", False, True)
	End Sub

	Private Sub SplitContainer2_Panel1_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer2.Panel1.Paint

	End Sub

	Private Sub cmbPancang_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPancang.SelectedIndexChanged

	End Sub
End Class
