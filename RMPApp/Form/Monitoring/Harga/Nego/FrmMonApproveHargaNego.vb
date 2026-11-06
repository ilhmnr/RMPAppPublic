
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmMonApproveHargaNego
	Private Sub FrmMonApproveHargaNego_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Call HeaderFG()
		Call scfh()

		DTPStart.Value = Format(Now, "dd/MM/yy")
		DTPEnd.Value = Format(Now, "dd/MM/yy")

		Modul_RMP.Combo.SetPancang(cmbPancang)
		Modul_RMP.Combo.SetKapal(cmbKapal)

		Modul_RMP.Combo.SetSupplier(cmbS_Petani)


	End Sub


	Public Sub HeaderFG()
		Dim txt As CellRange
		With fg
			.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
			.Cols.Count = 40
			.Cols.Fixed = 2



			.Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
			.Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
			.Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
			.Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

			.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
			.Styles.Normal.WordWrap = True
			.Rows.Fixed = 2
			.AllowMerging = AllowMergingEnum.FixedOnly
			.Rows(0).AllowMerging = True
			.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter


			txt = .GetCellRange(0, 0, 1, 0) : txt.Data = "No" : .Cols(0).AllowMerging = True
			txt = .GetCellRange(0, 1, 1, 1) : txt.Data = "NoNota" : .Cols(1).AllowMerging = True
			txt = .GetCellRange(0, 2, 1, 2) : txt.Data = "Trip" : .Cols(2).AllowMerging = True : .Cols(2).TextAlign = TextAlignEnum.CenterCenter
			txt = .GetCellRange(0, 3, 1, 3) : txt.Data = "Tanggal" : .Cols(3).AllowMerging = True : .Cols(3).TextAlign = TextAlignEnum.CenterCenter
			txt = .GetCellRange(0, 4, 1, 4) : txt.Data = "Via" : .Cols(4).AllowMerging = True : .Cols(4).TextAlign = TextAlignEnum.CenterCenter : .Cols(4).Visible = False
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

			txt = .GetCellRange(0, 13, 0, 14) : txt.Data = "PETANI"
			txt = .GetCellRange(1, 13, 1, 14) : txt.Data = "ID" : .Cols(13).AllowMerging = True : .Cols(13).TextAlign = TextAlignEnum.CenterCenter
			txt = .GetCellRange(1, 14, 1, 14) : txt.Data = "Nama" : .Cols(14).AllowMerging = True : .Cols(14).TextAlign = TextAlignEnum.LeftCenter

			txt = .GetCellRange(0, 15, 1, 15) : txt.Data = "Bruto" : .Cols(15).AllowMerging = True : .Cols(15).Format = "#,###0"
			txt = .GetCellRange(0, 16, 1, 16) : txt.Data = "Tarra Jaring" : .Cols(16).AllowMerging = True : .Cols(16).Format = "#,###0"
			txt = .GetCellRange(0, 17, 1, 17) : txt.Data = "Netto" : .Cols(17).AllowMerging = True : .Cols(17).Format = "#,###0"
			txt = .GetCellRange(0, 18, 1, 18) : txt.Data = "Tarra Persen" : .Cols(18).AllowMerging = True : .Cols(18).Format = "#,###0"
			txt = .GetCellRange(0, 19, 1, 19) : txt.Data = "Netto Akhir" : .Cols(19).AllowMerging = True : .Cols(19).Format = "#,###0"
			txt = .GetCellRange(0, 20, 1, 20) : txt.Data = "Harga Nego" : .Cols(20).AllowMerging = True : .Cols(20).Format = "#,###0"

			txt = .GetCellRange(0, 21, 0, 27) : txt.Data = "HARGA SEBELUM NEGO"
			txt = .GetCellRange(1, 21, 1, 21) : txt.Data = "Harga" : .Cols(21).AllowMerging = True : .Cols(21).Format = "#,###0" : .Cols(21).Style.BackColor = Color.PaleGreen
			txt = .GetCellRange(1, 22, 1, 22) : txt.Data = "TotalHarga" : .Cols(22).AllowMerging = True : .Cols(22).Format = "#,###0" : .Cols(22).Style.BackColor = Color.PaleGreen
			txt = .GetCellRange(1, 23, 1, 23) : txt.Data = "Potongan" : .Cols(23).AllowMerging = True : .Cols(23).Format = "#,###0" : .Cols(23).Style.BackColor = Color.PaleGreen
			txt = .GetCellRange(1, 24, 1, 24) : txt.Data = "Pph" : .Cols(24).AllowMerging = True : .Cols(24).Format = "#,###0" : .Cols(24).Style.BackColor = Color.PaleGreen
			txt = .GetCellRange(1, 25, 1, 25) : txt.Data = "Potongan Pph" : .Cols(25).AllowMerging = True : .Cols(25).Format = "#,###0" : .Cols(25).Style.BackColor = Color.PaleGreen
			txt = .GetCellRange(1, 26, 1, 26) : txt.Data = "SubsidiKarung" : .Cols(26).AllowMerging = True : .Cols(26).Format = "#,###0" : .Cols(26).Style.BackColor = Color.PaleGreen
			txt = .GetCellRange(1, 27, 1, 27) : txt.Data = "Total Akhir" : .Cols(27).AllowMerging = True : .Cols(27).Format = "#,###0" : .Cols(27).Style.BackColor = Color.PaleGreen

			txt = .GetCellRange(0, 28, 0, 34) : txt.Data = "HARGA SETELAH NEGO"
			txt = .GetCellRange(1, 28, 1, 28) : txt.Data = "Harga" : .Cols(28).AllowMerging = True : .Cols(28).Format = "#,###0" : .Cols(28).Style.BackColor = Color.MistyRose
			txt = .GetCellRange(1, 29, 1, 29) : txt.Data = "Total Harga" : .Cols(29).AllowMerging = True : .Cols(29).Format = "#,###0" : .Cols(29).Style.BackColor = Color.MistyRose
			txt = .GetCellRange(1, 30, 1, 30) : txt.Data = "Potongan" : .Cols(30).AllowMerging = True : .Cols(30).Format = "#,###0" : .Cols(30).Style.BackColor = Color.MistyRose
			txt = .GetCellRange(1, 31, 1, 31) : txt.Data = "Pph" : .Cols(31).AllowMerging = True : .Cols(31).Format = "#,###0" : .Cols(31).Style.BackColor = Color.MistyRose
			txt = .GetCellRange(1, 32, 1, 32) : txt.Data = "Potongan Pph" : .Cols(32).AllowMerging = True : .Cols(32).Format = "#,###0" : .Cols(32).Style.BackColor = Color.MistyRose
			txt = .GetCellRange(1, 33, 1, 33) : txt.Data = "SubsidiKarung" : .Cols(33).AllowMerging = True : .Cols(33).Format = "#,###0" : .Cols(33).Style.BackColor = Color.MistyRose
			txt = .GetCellRange(1, 34, 1, 34) : txt.Data = "Total Akhir" : .Cols(34).AllowMerging = True : .Cols(34).Format = "#,###0" : .Cols(34).Style.BackColor = Color.MistyRose

			txt = .GetCellRange(0, 35, 0, 36) : txt.Data = "Approval Admin" : .Cols(35).AllowMerging = True : .Cols(35).TextAlign = TextAlignEnum.LeftCenter
			txt = .GetCellRange(1, 35, 1, 35) : txt.Data = "Approve By " : .Cols(35).AllowMerging = True : .Cols(35).TextAlign = TextAlignEnum.LeftCenter
			txt = .GetCellRange(1, 36, 1, 36) : txt.Data = "Approve Date" : .Cols(36).AllowMerging = True : .Cols(36).TextAlign = TextAlignEnum.LeftCenter

			txt = .GetCellRange(0, 37, 0, 38) : txt.Data = "Approval Pimpinan" : .Cols(37).AllowMerging = True : .Cols(37).TextAlign = TextAlignEnum.LeftCenter
			txt = .GetCellRange(1, 37, 1, 37) : txt.Data = "Approve By " : .Cols(37).AllowMerging = True : .Cols(37).TextAlign = TextAlignEnum.LeftCenter
			txt = .GetCellRange(1, 38, 1, 38) : txt.Data = "Approve Date" : .Cols(38).AllowMerging = True : .Cols(38).TextAlign = TextAlignEnum.LeftCenter

			'txt = .GetCellRange(0, 26, 1, 26) : txt.Data = "Total Rp" : .Cols(26).ShowButtons = ShowButtonsEnum.Always
			txt = .GetCellRange(0, 39, 1, 39) : txt.Data = "Remark" : .Cols(39).AllowMerging = True : .Cols(39).TextAlign = TextAlignEnum.LeftCenter


		End With
	End Sub

	Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
		ShowData()
	End Sub

	Private Sub ShowData()
		Cursor = Cursors.WaitCursor
		Application.DoEvents()
		Try
			Dim dt As DataTable = New DataTable()
			Dim i As Integer = 2
			Dim diff As Integer

			Dim sql As String = ""

			Dim sql2 As String = ""

			If chkTransDate.Checked = True Then
				sql2 = Modul_RMP.Func.SetCondition(sql2, " (cast(TransDate as date) BETWEEN cast('" & Format(DTPStart.Value, "yyyy-MM-dd") & "' as date) AND cast('" & Format(DTPEnd.Value, "yyyy-MM-dd") & "' as date)) ")

			End If

			If chkPancang.Checked = True Then

				sql2 = Modul_RMP.Func.SetCondition(sql2, " IDPancang = '" & cmbPancang.SelectedValue & "' ")


			End If

			If chkKapal.Checked = True Then
				sql2 = Modul_RMP.Func.SetCondition(sql2, " IDKapal = '" & cmbKapal.SelectedValue.ToString & "' ")

			End If

			If chkTrip.Checked = True Then
				sql2 = Modul_RMP.Func.SetCondition(sql2, " Trip = '" & cmbTrip.Text & "' ")

			End If


			If chkS_Petani.Checked = True Then
				sql2 = Modul_RMP.Func.SetCondition(sql2, " IDSubPetani = '" & cmbS_Petani.SelectedValue.ToString & "' ")

			End If

			If rdSudahInputHargaNego.Checked = True Then
				dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "  select * from vwApproveHargaNego where HargaNego > 0 And isnull(ApproveHargaNegoFlag,0)=0 and Deleted = 0 " & IIf(sql2 = "", "", " AND " & sql2) & " order by TransID desc")
			ElseIf rdSudahApproval1.Checked = True Then
				dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "  select * from vwApproveHargaNego where HargaNego > 0 And ApproveHargaNegoFlag=1 and Deleted = 0 " & IIf(sql2 = "", "", " AND " & sql2) & " order by TransID desc")
			ElseIf rdSudahApproval2.Checked = True Then
				dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "  select * from vwApproveHargaNego where HargaNego > 0 And ApproveHargaNegoFlag=2 and Deleted = 0 " & IIf(sql2 = "", "", " AND " & sql2) & " order by TransID desc")
			ElseIf rdSudahApproval3.Checked = True Then
				dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "  select * from vwApproveHargaNego where HargaNego > 0 And ApproveHargaNegoFlag=3 and Deleted = 0 " & IIf(sql2 = "", "", " AND " & sql2) & " order by TransID desc")
			End If

			If dt.Rows.Count > 0 Then
				With fg
					fg.Rows.Count=2
					For Each row As DataRow In dt.Rows
						.AddItem(i - 1)
						.Item(i, 1) = row.Item("NoNota")
						.Item(i, 2) = row.Item("Trip")
						.Item(i, 3) = Format(row.Item("TransDate"), "dd/MM/yyyy")
						'.Item(i, 4) = row.Item("Pembayaran")
						.Item(i, 5) = row.Item("IDPancang")
						.Item(i, 6) = row.Item("Pancang")
						.Item(i, 8) = row.Item("IDKapal")
						.Item(i, 9) = row.Item("Kapal")

						.Item(i, 10) = row.Item("IDRelasi")
						.Item(i, 11) = row.Item("NamaRelasi")
						.Item(i, 12) = row.Item("AlamatRelasi")

						.Item(i, 13) = row.Item("IDSubPetani")
						.Item(i, 14) = row.Item("SubPetani")



						.Item(i, 15) = row.Item("Brutto")
						.Item(i, 16) = row.Item("TarraJaring")
						.Item(i, 17) = row.Item("Netto")
						.Item(i, 18) = row.Item("TarraPersen")
						.Item(i, 19) = row.Item("NettoAkhir")
						.Item(i, 20) = row.Item("HargaNego")

						.Item(i, 21) = row.Item("Harga")
						.Item(i, 22) = row.Item("TotalHarga")
						.Item(i, 23) = row.Item("Potongan")
						.Item(i, 26) = row.Item("PPhProsen")
						.Item(i, 27) = row.Item("PphPotong")
						.Item(i, 26) = row.Item("SubsidiKarung")
						.Item(i, 27) = row.Item("TotalPascaPph")

						.Item(i, 28) = row.Item("HargaStlhNego")
						.Item(i, 29) = row.Item("TotalHargaStlhNego")
						.Item(i, 30) = row.Item("Potongan")
						.Item(i, 31) = row.Item("PphProsen")
						.Item(i, 32) = row.Item("PphPotongStlhNego")
						.Item(i, 33) = row.Item("SubsidiKarung")
						.Item(i, 34) = row.Item("TotalRupiahAkhirStlhNego")
						.Item(i, 35) = row.Item("ApproveHargaNegoBy")
						.Item(i, 36) = row.Item("ApproveHargaNegoDate")

						.Item(i, 37) = row.Item("ApproveHargaNegoBy2")
						.Item(i, 38) = row.Item("ApproveHargaNegoDate2")
						.Item(i, 39) = row.Item("Remark")
						If IsDBNull(row.Item("editharga")) = False Then
							If row.Item("editharga") = "1" Then
								.Rows(i).StyleNew.BackColor = Color.Pink
								.Rows(i).StyleNew.ForeColor = Color.Black
							End If
						End If
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

	Private Sub chkPancang_CheckedChanged(sender As Object, e As EventArgs) Handles chkPancang.CheckedChanged
		Call UI.ChkCondCmb(chkPancang, cmbPancang, "Pancang")
	End Sub

	Private Sub chkTrip_CheckedChanged(sender As Object, e As EventArgs) Handles chkTrip.CheckedChanged
		Call UI.ChkCondCmb(chkTrip, cmbTrip, "Trip")
	End Sub

	Private Sub chkKapal_CheckedChanged(sender As Object, e As EventArgs) Handles chkKapal.CheckedChanged
		Call UI.ChkCondCmb(chkKapal, cmbKapal, "Kapal")
	End Sub

	Private Sub cmbPancang_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPancang.SelectedIndexChanged

	End Sub

	Private Sub cmbPancang_Validated(sender As Object, e As EventArgs) Handles cmbPancang.Validated
		chkPancang.Checked = IIf(cmbPancang.Text = "", False, True)
	End Sub

	Private Sub cmbTrip_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTrip.SelectedIndexChanged

	End Sub

	Private Sub cmbTrip_Validated(sender As Object, e As EventArgs) Handles cmbTrip.Validated
		chkTrip.Checked = IIf(cmbTrip.Text = "", False, True)
	End Sub

	Private Sub scfh()
		With schfg()
			.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
			.SearchDelay = 2
			.Watermark = "Cari Disini"
			.SetC1FlexGridSearchPanel(fg, schfg)
		End With
	End Sub

	Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
		Me.Close()
	End Sub

	Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click

	End Sub

	Private Sub fg_DoubleClick(sender As Object, e As EventArgs) Handles fg.DoubleClick

	End Sub

	Private Sub cmbS_Petani_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbS_Petani.SelectedIndexChanged

	End Sub

	Private Sub cmbS_Petani_Validated(sender As Object, e As EventArgs) Handles cmbS_Petani.Validated
		chkS_Petani.Checked = IIf(cmbS_Petani.Text = "", False, True)
	End Sub

	Private Sub cmbS_Petani_Validating(sender As Object, e As CancelEventArgs) Handles cmbS_Petani.Validating
		If cmbS_Petani.Text = "" Then
			Exit Sub
		End If

		If IsNothing(cmbS_Petani.SelectedValue) Then
			MsgBox("Pilihan tidak ada !", vbExclamation, AT)
			cmbS_Petani.Text = ""
			cmbS_Petani.Focus()
		End If
	End Sub

	Private Sub cmbS_Petani_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbS_Petani.KeyUp
		UI.AutoCompleteCombo_KeyUp(cmbS_Petani, e)
	End Sub

	Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
		Dim filename As String
		Me.SaveFileDialog.ShowDialog()
		filename = SaveFileDialog.FileName
		Me.fg.SaveExcel(filename & ".xls", "Sheet1", FileFlags.IncludeFixedCells)
	End Sub

	'Private Sub fg_CellButtonClick(sender As Object, e As RowColEventArgs) Handles fg.CellButtonClick
	'	Dim p As String
	'	With fg

	'		p = MsgBox("Apakah Anda Yakin Ingin Mengeluarkan Saudara " & fg(fg.Row, "Nama").ToString() & vbTab & "Dari List ini ??", vbQuestion + vbOKCancel)

	'		If p = vbOK Then
	'			fg.RemoveItem(fg.Row)
	'		End If
	'	End With
	'End Sub

End Class