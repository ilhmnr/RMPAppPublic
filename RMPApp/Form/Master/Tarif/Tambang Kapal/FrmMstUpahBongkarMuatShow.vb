Imports System.ComponentModel
Imports C1.Win.C1FlexGrid

Public Class FrmMstUpahBongkarMuatShow
	Public FormName As String
	Private Sub FrmMstUpahBongkarMuatShow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		HeaderFG()
		search()
		ClearData()
		Modul_RMP.Combo.SetPancang(cmbPancang)
	End Sub

	Public Sub ClearData()
		UI.ClearText(XuiCustomGroupbox1)
		ui.HapusGrid(1, fg)
	End Sub

	Private Sub search()
		schfg.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
		schfg.SearchDelay = 2
		schfg.Watermark = "Cari disini.."
		schfg.SetC1FlexGridSearchPanel(fg, schfg)
	End Sub

	Public Sub HeaderFG()
		Dim txt As CellRange
		With fg
			.AllowEditing = False
			.AutoGenerateColumns = True
			.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
			.Cols.Count = 19
			.Cols.Fixed = 1
			.Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
			.Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
			.Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
			.Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

			.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
			.Styles.Normal.WordWrap = True
			.Rows.Fixed = 1
			.AllowMerging = AllowMergingEnum.FixedOnly
			.Rows(0).AllowMerging = True
			.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

			txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No"
			txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "ID" : .Cols(1).TextAlign = TextAlignEnum.CenterCenter
			txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "IDPancang" : .Cols(2).TextAlign = TextAlignEnum.CenterCenter : .Cols(2).Visible = False
			txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Pancang" : .Cols(3).TextAlign = TextAlignEnum.LeftCenter
			txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Tujuan" : .Cols(4).TextAlign = TextAlignEnum.LeftCenter
			txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Periode" : .Cols(5).TextAlign = TextAlignEnum.CenterCenter
			txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Tambang" : .Cols(6).Format = "#,###0"
			txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Tambang (Kapal Crane)" : .Cols(7).Format = "#,###0"
			txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Jenis" : .Cols(8).TextAlign = TextAlignEnum.LeftCenter
			txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Jenis Bahan Baku" : .Cols(9).TextAlign = TextAlignEnum.LeftCenter
			txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "Keterangan" : .Cols(10).TextAlign = TextAlignEnum.LeftCenter
			txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "Created By" : .Cols(11).TextAlign = TextAlignEnum.CenterCenter
			txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "Created Date" : .Cols(12).TextAlign = TextAlignEnum.CenterCenter
			txt = .GetCellRange(0, 13, 0, 13) : txt.Data = "Updated By" : .Cols(13).TextAlign = TextAlignEnum.CenterCenter
			txt = .GetCellRange(0, 14, 0, 14) : txt.Data = "Updated Date" : .Cols(14).TextAlign = TextAlignEnum.CenterCenter
			txt = .GetCellRange(0, 15, 0, 15) : txt.Data = "Computer" : .Cols(15).TextAlign = TextAlignEnum.CenterCenter
			txt = .GetCellRange(0, 16, 0, 16) : txt.Data = "Computer Date" : .Cols(16).TextAlign = TextAlignEnum.CenterCenter
			txt = .GetCellRange(0, 17, 0, 17) : txt.Data = "IDJenisBahanBaku" : .Cols(17).Visible = False
			txt = .GetCellRange(0, 18, 0, 18) : txt.Data = "IDPancangTujuan" : .Cols(18).Visible = False

			.AutoSizeCols()
		End With
	End Sub

	Private Sub cmbPancang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbPancang.KeyPress
		If (e.KeyChar = Chr(13)) Then
			btnRefresh.Focus()
		End If
	End Sub
	Private Sub dtpPeriode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpPeriode.KeyPress
		If (e.KeyChar = Chr(13)) Then
			cmbPancang.Focus()
		End If
	End Sub
	Private Sub cmbPancang_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbPancang.KeyUp
		UI.AutoCompleteCombo_KeyUp(cmbPancang, e)
	End Sub
	Private Sub cmbPancang_Validated(sender As Object, e As EventArgs) Handles cmbPancang.Validated
		chkPancang.Checked = IIf(cmbPancang.Text = "", False, True)
	End Sub
	Private Sub dtpPeriode_Validated(sender As Object, e As EventArgs) Handles dtpPeriode.Validated
		chkPeriode.Checked = True
	End Sub
	Private Sub chkPancang_CheckedChanged(sender As Object, e As EventArgs) Handles chkPancang.CheckedChanged
		Call UI.ChkCondCmb(chkPancang, cmbPancang, "Pancang")
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

	Private Sub ShowData()
		Dim i As Integer = 1
		Dim sql As String = ""
		Dim dt As DataTable = New DataTable()
		Try

			If chkPeriode.Checked = True Then
				sql = Modul_RMP.Func.SetCondition(sql, "MONTH(A.Periode) = '" & Month(dtpPeriode.Value) & "' and YEAR(A.Periode) = '" & Year(dtpPeriode.Value) & "'")
			End If

			If chkPancang.Checked = True Then
				sql = Modul_RMP.Func.SetCondition(sql, "A.IDPancang = '" & cmbPancang.SelectedValue & "'")
			End If

			If FormName = "FrmMstUpahBongkarMuat" Then
				dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select A.IDTambang,A.IDPancang,B.Pancang,A.Periode,A.UpahTambang,A.Ket, " &
															  " A.CreatedBy,A.CreatedDate,A.UpdatedBy,A.UpdatedDate,A.ComputerName,A.ComputerDate ,a.UpahTambangKapalCrane,iif(a.Jenis=1,'Laut','Darat') as Jenis,c.NamaBahanBaku as JenisBahanBaku,a.JenisBahanBaku as  IDJenisBahanBaku " &
															  " from tblMstTambangKapal A INNER JOIN " &
															  " Android_tblMstPancang B ON A.IDPancang= B.IDPancang left outer join " &
															  " RSUPAccounting..tblRMMstJenisBahanBaku as c on a.JenisBahanBaku=c.Kode " &
															  " where 1=1 " & IIf(sql = "", "", " AND " & sql) & "Order by A.Periode")
			Else
				dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select A.IDTambang,A.IDPancang,B.Pancang,A.Periode,A.UpahTambang,A.Ket, 
																   A.CreatedBy,A.CreatedDate,A.UpdatedBy,A.UpdatedDate,A.ComputerName,A.ComputerDate ,a.UpahTambangKapalCrane,iif(a.Jenis=1,'Laut','Darat') as Jenis,
																   c.NamaBahanBaku as JenisBahanBaku,a.JenisBahanBaku as  IDJenisBahanBaku ,a.IDPancangTujuan,d.Pancang as PancangTujuan
																   from tblMstTambangKapalPCGSub A INNER JOIN 
																   Android_tblMstPancang B ON A.IDPancang= B.IDPancang left outer join 
																   RSUPAccounting..tblRMMstJenisBahanBaku as c on a.JenisBahanBaku=c.Kode INNER JOIN 
																   Android_tblMstPancang d ON A.IDPancangTujuan= d.IDPancang 
																   where 1=1 " & IIf(sql = "", "", " AND " & sql) & "Order by A.Periode")
			End If

			If dt.Rows.Count > 0 Then
				With fg
					Call ui.HapusGrid(1, fg)
					For Each row As DataRow In dt.Rows
						.AddItem(i)
						.Item(i, 1) = row.Item("IDTambang")
						.Item(i, 2) = row.Item("IDPancang")
						.Item(i, 3) = row.Item("Pancang")

						If FormName = "FrmMstUpahBongkarMuat" Then
							.Item(i, 4) = "RSUP"
							.Item(i, 18) = 0
						Else
							.Item(i, 4) = row.Item("PancangTujuan")
							.Item(i, 18) = row.Item("IDPancangTujuan")
						End If

						.Item(i, 5) = Format(row.Item("Periode"), "dd-MM-yyyy")
						.Item(i, 6) = row.Item("UpahTambang")
						.Item(i, 7) = row.Item("UpahTambangKapalCrane")
						.Item(i, 8) = row.Item("Jenis")
						.Item(i, 9) = row.Item("JenisBahanBaku")
						.Item(i, 10) = row.Item("Ket")
						.Item(i, 11) = row.Item("CreatedBy")
						.Item(i, 12) = row.Item("CreatedDate")
						.Item(i, 13) = row.Item("UpdatedBy")
						.Item(i, 14) = row.Item("UpdatedDate")
						.Item(i, 15) = row.Item("ComputerName")
						.Item(i, 16) = row.Item("ComputerDate")
						.Item(i, 17) = row.Item("IDJenisBahanBaku")


						i = i + 1
					Next
					.AutoSizeCols()
				End With
			Else
				MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
			End If
		Catch EX As Exception
			MsgBox(EX.Message)
		End Try
	End Sub

	Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
		ShowData()
	End Sub

	Private Sub fg_DoubleClick(sender As Object, e As EventArgs) Handles fg.DoubleClick
		If FormName = "FrmMstUpahBongkarMuat" Then
			With FrmMstUpahBongkarMuat
				.txtIDUpah.Text = fg.Item(fg.Row, 1)
				.IDPancang = fg.Item(fg.Row, 2)
				.cmbPancang.SelectedValue = fg.Item(fg.Row, 2)
				.cmbPancang.Text = fg.Item(fg.Row, 3)
				.dtpPeriode.Text = fg.Item(fg.Row, 5)
				.txtUpah.Text = Modul_RMP.Func.SetSeparator(fg.Item(fg.Row, 6))
				.TxtUpahKapalCrane.Text = Modul_RMP.Func.SetSeparator(IIf(IsDBNull(fg.Item(fg.Row, 7)), 0, fg.Item(fg.Row, 7)))
				If fg.Item(fg.Row, 8) = "Laut" Then
					.rdLaut.Checked = True
				Else
					.rdDarat.Checked = True
				End If
				.txtKet.Text = IIf(IsDBNull(fg.Item(fg.Row, 10)), "", fg.Item(fg.Row, 10))
				.cbobahanbaku.SelectedValue = fg.Item(fg.Row, 17)
				.cbobahanbaku.Text = fg.Item(fg.Row, 9)

				UI.EnabledFalse(.XuiCustomGroupbox1)
				'.dtpPeriode.Enabled = False
				.cmbPancang.Enabled = False

				.btnEdit.Enabled = True
				.btnSave.Enabled = False
				.btnCancel.Enabled = True
			End With
		Else
			With FrmMstUpahBongkarMuatPCGSub
				.txtIDUpah.Text = fg.Item(fg.RowSel, 1)
				.cmbPancang.Text = fg.Item(fg.RowSel, 3)
				.cmbPancangTujuan.Text = fg.Item(fg.RowSel, 4)
				.cbobahanbaku.Text = fg.Item(fg.RowSel, 9)
				If fg.Item(fg.RowSel, 8) = "Laut" Then
					.rdLaut.Checked = True
				Else
					.rdDarat.Checked = True
				End If
				.dtpPeriode.Text = fg.Item(fg.RowSel, 5)
				.txtUpah.Text = fg.Item(fg.RowSel, 6)
				.TxtUpahKapalCrane.Text = fg.Item(fg.RowSel, 7)
				.txtKet.Text = fg.Item(fg.RowSel, 10)

				.btnEdit.Enabled = True
				.btnSave.Enabled = False
				.btnCancel.Enabled = True
			End With
		End If

		Me.Close()
	End Sub

End Class
