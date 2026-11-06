Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class FrmMstUpahBongkarMuat
	Public IDPancang As String
	Private Sub FrmMastUpahBongkarMuat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		ClearData()
		Modul_RMP.Combo.SetPancang(cmbPancang)
		Combo.SetPancang(cmbPancang2)
		Modul_RMP.Combo.SetBahanBaku(cbobahanbaku)

		dgvlist.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 140, 217)
		dgvlist.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
		dgvlist.EnableHeadersVisualStyles = False
	End Sub

	Private Sub ClearData()
		UI.ClearText(grpFilterData)
		UI.EnabledFalse(grpFilterData)
		'dtpPeriode.Enabled = False
		IDPancang = ""
		btnAdd.Enabled = True
		btnFind.Enabled = True
		btnSave.Enabled = False
		btnEdit.Enabled = False
		btnCancel.Enabled = True
	End Sub

	Private Sub cmbPancang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbPancang.KeyPress
		If (e.KeyChar = Chr(13)) Then
			dtpPeriode.Focus()
		End If
	End Sub

	Private Sub dtpPeriode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpPeriode.KeyPress
		If (e.KeyChar = Chr(13)) Then
			txtUpah.Focus()
		End If
	End Sub

	Private Sub txtUpah_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUpah.KeyPress, TxtUpahKapalCrane.KeyPress
		If (e.KeyChar = Chr(13)) Then
			txtKet.Focus()
		End If
	End Sub

	Private Sub txtKet_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKet.KeyPress
		If (e.KeyChar = Chr(13)) Then
			btnSave.Focus()
		End If
	End Sub

	Private Sub cmbPancang_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbPancang.KeyUp
		UI.AutoCompleteCombo_KeyUp(cmbPancang, e)
	End Sub

	Private Sub txtUpah_Validated(sender As Object, e As EventArgs) Handles txtUpah.Validated, TxtUpahKapalCrane.Validated
		If txtUpah.Text = "" Then
			txtUpah.Text = "0"
		End If
		txtUpah.Text = Modul_RMP.Func.SetSeparator(txtUpah.Text)
	End Sub

	Private Sub txtUpah_GotFocus(sender As Object, e As EventArgs) Handles txtUpah.GotFocus, TxtUpahKapalCrane.GotFocus
		If txtUpah.Text = "0" Then
			txtUpah.Text = ""
		End If
		txtUpah.Text = Modul_RMP.Func.ClearSeparator(txtUpah.Text)
	End Sub

	Private Sub txtUpah_LostFocus(sender As Object, e As EventArgs) Handles txtUpah.LostFocus, TxtUpahKapalCrane.LostFocus
		If txtUpah.Text = "" Then
			txtUpah.Text = "0"
		End If
		txtUpah.Text = Modul_RMP.Func.SetSeparator(txtUpah.Text)
	End Sub

	Private Sub cmbPancang_Validating(sender As Object, e As CancelEventArgs) Handles cmbPancang.Validating
		If cmbPancang.Text = "" Then
			Exit Sub
		End If

		If IsNothing(cmbPancang.SelectedValue) Then
			MsgBox("Pilihan tidak ada !", vbExclamation, AT)
			cmbPancang.Text = ""
			cmbPancang.Focus()
			Exit Sub
		End If
	End Sub

	Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
		UI.ClearText(grpFilterData)
		UI.EnabledTrue(grpFilterData)
		'dtpPeriode.Enabled = True
		btnAdd.Enabled = False
		btnSave.Enabled = True
		btnEdit.Enabled = False
		btnCancel.Enabled = True

		txtUpah.Enabled = False
		TxtUpahKapalCrane.Enabled = False
	End Sub

	Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
		Call ClearData()
	End Sub

	Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
		UI.EnabledTrue(grpFilterData)
		'dtpPeriode.Enabled = False
		cmbPancang.Enabled = False
		btnAdd.Enabled = False
		btnSave.Enabled = True
		btnEdit.Enabled = False
		btnCancel.Enabled = True
	End Sub

	Private Sub SaveData()
		Me.Cursor = Cursors.WaitCursor
		Try
			Dim koneksi As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnRMPApp)
			Dim Transaksi As SqlTransaction
			Transaksi = koneksi.BeginTransaction

			If rdLaut.Checked = True Then
				If SaveMstTambang(koneksi, Transaksi, txtIDUpah.Text, IIf(IsNothing(cmbPancang.SelectedValue), IDPancang, cmbPancang.SelectedValue),
								 Format(dtpPeriode.Value, "yyyy-MM-dd"), Modul_RMP.Func.ClearSeparator(CDbl(txtUpah.Text)), "1", txtKet.Text, ClsSession.UserID, TxtUpahKapalCrane.Text) = False Then
					Transaksi.Rollback()
					MsgBox("Simpan Data Gagal", vbExclamation, "Save Data - " & AT)
					Exit Try
				End If
			ElseIf rdDarat.Checked = True Then
				If SaveMstTambang(koneksi, Transaksi, txtIDUpah.Text, IIf(IsNothing(cmbPancang.SelectedValue), IDPancang, cmbPancang.SelectedValue),
								 Format(dtpPeriode.Value, "yyyy-MM-dd"), Modul_RMP.Func.ClearSeparator(CDbl(txtUpah.Text)), "2", txtKet.Text, ClsSession.UserID, TxtUpahKapalCrane.Text) = False Then
					Transaksi.Rollback()
					MsgBox("Simpan Data Gagal", vbExclamation, "Save Data - " & AT)
					Exit Try
				End If
			End If

			Transaksi.Commit()
			MessageBox.Show("Save Completed !", "Save Data - " & AT, MessageBoxButtons.OK, MessageBoxIcon.Information)
			Call ClearData()
		Catch ex As Exception
			MessageBox.Show(ex.Message, "Save Data - " & AT, MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			Me.Cursor = Cursors.Default
		End Try
	End Sub

	Private Function SaveMstTambang(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, IDTambang As String, IDPancang As String, Periode As String, UpahTambang As Double, ByVal Jenis As Integer, Ket As String, CreatedBy As String, UpahTambangKapalCrane As Double) As Boolean
		Dim MyCMD As New SqlCommand
		Try
			With MyCMD
				.Connection = Conn
				.CommandType = CommandType.StoredProcedure
				.CommandText = "RMPApp..spSaveTambangKapal"
				.Transaction = Trans

				If IDTambang = String.Empty Then
					.Parameters.Add(New SqlParameter("@IDTambang", SqlDbType.VarChar, 20, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
				Else
					.Parameters.Add("@IDTambang", SqlDbType.Int).Value = IDTambang
				End If

				.Parameters.Add("@IDPancang", SqlDbType.VarChar).Value = IDPancang
				.Parameters.Add("@Periode", SqlDbType.VarChar).Value = Periode
				.Parameters.Add("@UpahTambang", SqlDbType.Decimal).Value = UpahTambang
				.Parameters.Add("@UpahTambangKapalCrane", SqlDbType.Decimal).Value = UpahTambangKapalCrane
				.Parameters.Add("@Jenis", SqlDbType.Int).Value = Jenis
				.Parameters.Add("@JenisBahanBaku", SqlDbType.Int).Value = cbobahanbaku.SelectedValue
				.Parameters.Add("@Ket", SqlDbType.VarChar).Value = Ket
				.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = CreatedBy
				.Parameters.Add(New SqlParameter("@Error", SqlDbType.VarChar, 200, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
				.ExecuteNonQuery()
				.Dispose()
			End With
		Catch ex As Exception
			MessageBox.Show(ex.Message & " infosp : " & MyCMD.Parameters("@Error").Value)
			Return False
		End Try
		Return True
	End Function

	Private Sub BtnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
		With FrmMstUpahBongkarMuatShow
			.FormName = "FrmMstUpahBongkarMuat"
			.ShowDialog()
			.ClearData()
		End With
	End Sub

	Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
		If IsNothing(cmbPancang.SelectedValue) And IDPancang = "" Then
			MsgBox("Pancang Is Empty !", MsgBoxStyle.Exclamation, AT)
		ElseIf txtUpah.Text = "0" And TxtUpahKapalCrane.Text = "0" Then
			MsgBox("Upah Bongkar Is Empty !", MsgBoxStyle.Exclamation, AT)
		ElseIf txtKet.Text = "" Then
			MsgBox("Keterangan Is Empty !", MsgBoxStyle.Exclamation, AT)
		Else
			Call SaveData()
			Call LoadData()
		End If
	End Sub

	Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
		LoadData()
	End Sub

	Sub LoadData()
		Dim i As Integer = 0
		Dim SQL, SQL1, SQL2, SQL3, SQL4, SQL5, SQL6, StatusVaksin As String

		If cmbPancang2.Text = "Nama Pancang" Then
			SQL1 = ""
		Else
			SQL1 = " And (IDPancang = '" & cmbPancang2.SelectedValue & "')"
		End If

		If dtp1.Checked = False Then
			SQL2 = ""
		Else
			SQL2 = "and ((convert(date,convert(varchar, Periode,103),103) between convert (date,'" & dtp1.Value & "',103) and convert(date,'" & dtp2.Value & "',103))) "
		End If

		SQL = " SELECT * FROM vwMstTambangKapal where IDTambang is not null "

		SQL = SQL + SQL1 + SQL2 + SQL3 + SQL4 + SQL5 + SQL6 + "  ORDER BY Periode desc "


		Try
			Me.Cursor = Cursors.WaitCursor
			Using koneksi As New SqlCommand(SQL, DB.OpenConnection(StrConnRMPApp))
				Using DR = koneksi.ExecuteReader
					dgvlist.Rows.Clear()

					If DR.HasRows Then
						dgvlist.RowCount = 0
						While DR.Read
							With dgvlist
								.Rows.Add()
								.Item("No", i).Value = i + 1
								.Item("IDTambang", i).Value = DR!IDTambang
								.Item("IDPancang2", i).Value = DR!IDPancang
								.Item("Pancang", i).Value = DR!Pancang
								.Item("Periode", i).Value = DR!Periode
								.Item("UpahTambang", i).Value = DR!UpahTambang
								.Item("UpahTambangKapalCrane", i).Value = DR!UpahTambangKapalCrane
								.Item("KodeBB", i).Value = DR!JenisBahanBaku
								.Item("JenisBahanBaku", i).Value = DR!NamaBahanBaku
								.Item("Keterangan", i).Value = DR!Ket
								.Item("CreatedBy", i).Value = DR!CreatedBy
								.Item("CreatedDate", i).Value = DR!CreatedDate
								If IsDBNull(DR!UpdatedBy) Then .Item("UpdatedBy", i).Value = "" Else .Item("UpdatedBy", i).Value = DR!UpdatedBy
								If IsDBNull(DR!UpdatedDate) Then .Item("UpdatedDate", i).Value = "" Else .Item("UpdatedDate", i).Value = DR!UpdatedDate

								.RowsDefaultCellStyle.BackColor = Color.White
								.AlternatingRowsDefaultCellStyle.BackColor = Color.Azure

								With Me.dgvlist
									.RowsDefaultCellStyle.BackColor = Color.White
									.AlternatingRowsDefaultCellStyle.BackColor = Color.White
									.Rows(i).Cells("No").Style.BackColor = Color.FromArgb(240, 240, 240)
								End With
							End With
							i += 1
						End While
					Else
						dgvlist.Rows.Clear()
						MsgBox("Data Tidak ditemukan ! ", MsgBoxStyle.Information)
						Me.Cursor = Cursors.Default
						Exit Sub
					End If
					DR.Close()
				End Using
			End Using
			DB.CloseConnection()
			Me.Cursor = Cursors.Default
		Catch ex As Exception
			Me.Cursor = Cursors.Default
			MsgBox(ex.Message, MsgBoxStyle.Critical)
		End Try
	End Sub
	Private Sub cmbPancang2_MouseClick(sender As Object, e As MouseEventArgs) Handles cmbPancang2.MouseClick
		If cmbPancang2.Text = "Nama Pancang" Then cmbPancang2.Text = String.Empty
	End Sub

	Private Sub cmbPancang2_LostFocus(sender As Object, e As EventArgs) Handles cmbPancang2.LostFocus
		If cmbPancang2.Text = String.Empty Then cmbPancang2.Text = "Nama Pancang"
	End Sub
	Private Sub txtCari_MouseClick(sender As Object, e As MouseEventArgs) Handles txtCari.MouseClick
		If txtCari.Text = "Search" Then txtCari.Text = String.Empty
	End Sub
	Private Sub txtCari_LostFocus(sender As Object, e As EventArgs) Handles txtCari.LostFocus
		If txtCari.Text = String.Empty Then txtCari.Text = "Search"
	End Sub

	Private Sub dtp1_ValueChanged(sender As Object, e As EventArgs) Handles dtp1.ValueChanged
		If dtp1.Checked = True Then
			dtp2.Enabled = True
		ElseIf dtp1.Checked = False Then
			dtp2.Enabled = False
			dtp1.Value = Now
			dtp2.Value = Now
		End If
	End Sub

	Private Sub cmbPancang_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbPancang.SelectedValueChanged, cbobahanbaku.SelectedValueChanged
		GetUpahTambangLama()

		If cmbPancang.Text <> "" And cbobahanbaku.Text <> "" Then
			txtUpah.Enabled = True
			TxtUpahKapalCrane.Enabled = True
		End If
	End Sub

	Private Sub GetUpahTambangLama()
		Try
			txtUpah.Text = DB.ExecuteScalarValue(Of String)(StrConnRMPApp, " select top 1 isnull(UpahTambang,0) as GetValue_ from tblMstTambangKapal where IDPancang='" & cmbPancang.SelectedValue & "' and Jenis='" & IIf(rdLaut.Checked = True, 1, 2) & "' and JenisBahanBaku='" & cbobahanbaku.SelectedValue & "' order by Periode desc ")
			TxtUpahKapalCrane.Text = DB.ExecuteScalarValue(Of String)(StrConnRMPApp, " select top 1 isnull(UpahTambangKapalCrane,0) as GetValue_ from tblMstTambangKapal where IDPancang='" & cmbPancang.SelectedValue & "' and Jenis='" & IIf(rdLaut.Checked = True, 1, 2) & "' and JenisBahanBaku='" & cbobahanbaku.SelectedValue & "' order by Periode desc ")
		Catch ex As Exception
		End Try
	End Sub

	Private Sub rdLaut_Click(sender As Object, e As EventArgs) Handles rdLaut.Click, rdDarat.Click
		GetUpahTambangLama()
	End Sub
End Class
