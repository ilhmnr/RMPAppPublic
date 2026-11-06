
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmTrnUpdateTripKapal

	Dim text_ As String
	Dim dt As DataTable = New DataTable()
	Public Indlebih, IDKapal, IndShow, Jalan, IndRelasiPcg, FlagTglMasukKapal As Integer
	Dim KapalTenggelam As String
	Private Sub FrmUpadateTripKapal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Modul_RMP.Combo.SetPancang(cmbPancang)

		Call HeaderFG()
		Call Search()
		Call ClearData()


		TimerInfo.Start()
		Width = 728
		Height = 489
	End Sub

	Public Sub HeaderFG()
		Dim txt As CellRange
		With fg
			.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
			.Cols.Count = 8
			.Cols.Fixed = 1
			.Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
			.Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
			.Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
			.Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)
			.Rows(1).StyleNew.BackColor = Color.FromArgb(243, 222, 222)
			.Rows(1).StyleFixedNew.BackColor = Color.FromArgb(223, 240, 216)

			.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
			.Styles.Normal.WordWrap = True
			.Rows.Fixed = 2
			.AllowMerging = AllowMergingEnum.FixedOnly
			.Rows(0).AllowMerging = True
			.Rows(1).AllowMerging = True
			.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

			txt = .GetCellRange(0, 0, 1, 0) : txt.Data = "No" : .Cols(0).AllowMerging = True
			txt = .GetCellRange(0, 1, 1, 1) : txt.Data = "TripAwal" : .Cols(1).AllowMerging = True : .Cols(2).TextAlign = TextAlignEnum.CenterCenter
			txt = .GetCellRange(0, 2, 1, 2) : txt.Data = "IDPancang" : .Cols(2).AllowMerging = True : .Cols(2).TextAlign = TextAlignEnum.CenterCenter : .Cols(2).Visible = False
			txt = .GetCellRange(0, 3, 1, 3) : txt.Data = "Pancang" : .Cols(3).AllowMerging = True : .Cols(3).TextAlign = TextAlignEnum.CenterCenter
			txt = .GetCellRange(0, 4, 1, 4) : txt.Data = "IdKapal" : .Cols(4).AllowMerging = True : .Cols(4).TextAlign = TextAlignEnum.CenterCenter : .Cols(4).Visible = False
			txt = .GetCellRange(0, 5, 1, 5) : txt.Data = "Kapal" : .Cols(5).AllowMerging = True : .Cols(5).TextAlign = TextAlignEnum.RightCenter
			txt = .GetCellRange(0, 6, 1, 6) : txt.Data = "CreatedDate" : .Cols(6).AllowMerging = True : .Cols(6).TextAlign = TextAlignEnum.LeftCenter
			txt = .GetCellRange(0, 7, 1, 7) : txt.Data = "TripBeforeEdit" : .Cols(7).AllowMerging = True : .Cols(7).TextAlign = TextAlignEnum.CenterCenter : .Cols(7).Visible = False

			.AutoSizeCols()
		End With
	End Sub

	Private Sub Search()
		With schfg
			.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
			.SearchDelay = 2
			.Watermark = "Cari Disini"
			.SetC1FlexGridSearchPanel(fg, schfg)
		End With
	End Sub

	Private Sub ClearData()
		UI.ClearText(grpFilterData)
		UI.EnabledTrue(grpFilterData)
		DTPStart.Enabled = True
		DTPEnd.Enabled = True
		chkTransDate.Checked = True
		chkTransDate.Enabled = True
		fg.Rows.Count=2
		btnSave.Enabled = False

		fg.AutoSizeCols()
	End Sub

	Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
		Call FilterData(0)
	End Sub

	Public Sub FilterData(ByVal Ind_ As Integer)


		Call ShowData()

	End Sub

	Private Sub cmbPancang_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPancang.SelectedIndexChanged

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
				sql = Modul_RMP.Func.SetCondition(sql, "CONVERT(DATETIME, CONVERT(VARCHAR, createdDate, 103),103) between CONVERT (DATETIME,'" & Format(DTPStart.Value, "dd/MM/yyyy") & "',103) and CONVERT (DATETIME,'" & Format(DTPEnd.Value, "dd/MM/yyyy") & "',103)")
			End If

			If chkPancang.Checked = True Then
				sql = Modul_RMP.Func.SetCondition(sql, "IDPancang = '" & cmbPancang.SelectedValue & "'")
			Else
				MsgBox("Pancang Is Empty !", MsgBoxStyle.Exclamation, AT)
				cmbPancang.Focus()
				Exit Sub
			End If


			dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select * from tblMstAwalTripPancang where 1=1 " & IIf(sql = "", "", " And " & sql) & " order by id desc")

			If dt.Rows.Count > 0 Then
				With fg
					fg.Rows.Count=2
					For Each row As DataRow In dt.Rows
						.AddItem(i - 1)
						.Item(i, 1) = row.Item("TripAwal")
						.Item(i, 2) = row.Item("IDPancang")
						.Item(i, 3) = row.Item("Pancang")
						.Item(i, 4) = row.Item("IdKapal")
						.Item(i, 5) = row.Item("Kapal")
						.Item(i, 6) = Format(row.Item("CreatedDate"), "dd/MM/yyyy")
						.Item(i, 7) = row.Item("TripAwal")
						i = i + 1
					Next
					.AutoSizeCols()
				End With
				'ShowTotals()
				'CekRelasiPcg()

				btnSave.Enabled = True

			Else
				fg.Rows.Count=2
				MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
				btnSave.Enabled = False

			End If

		Catch ex As Exception
			MessageBox.Show(ex.Message)
		Finally
			Cursor = Cursors.Default
		End Try
	End Sub

	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

	End Sub

	Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
		'Call SaveData()
		UpdateTripAwal()
		UpdateTripMuat()
		UpdateTriptblTrnKelapaHDR()
		ShowData()
	End Sub

	Private Sub cmbPancang_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbPancang.KeyUp
		UI.AutoCompleteCombo_KeyUp(cmbPancang, e)
	End Sub

	Private Sub chkPancang_CheckedChanged(sender As Object, e As EventArgs) Handles chkPancang.CheckedChanged

		Call UI.ChkCondCmb(chkPancang, cmbPancang, "Pancang")
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


	Sub UpdateTripAwal()

		Try
			With fg
				For i = 2 To .Rows.Count - 1
					Dim cmd = New SqlCommand
					cmd.CommandText = "UPDATE RMPApp..tblMstAwalTripPancang  set TripAwal=@TripAwal where TripAwal='" & .Item(i, 7) & "'and IDKapal='" & .Item(i, 4) & "' and IDpancang ='" & .Item(i, 2) & "' "
					cmd.Parameters.Add("@TripAwal", SqlDbType.Int).Value = fg.Item(i, 1)
					cmd.Connection = DB.OpenConnection(StrConnRMPApp)
					cmd.ExecuteNonQuery()
				Next
			End With
		Catch ex As Exception
			MsgBox("Data Gagal Diubah!!AndroidTripAwal", vbExclamation)
			Exit Sub
		End Try


	End Sub


	Sub UpdateTripMuat()
		Try
			With fg
				For i = 2 To .Rows.Count - 1
					Dim cmd = New SqlCommand
					cmd.CommandText = "UPDATE RMPApp..Android_tblBookingKapalMuat set TripID=@TripID where TripID='" & .Item(i, 7) & "'and IDKapal='" & .Item(i, 4) & "' and IDpancang ='" & .Item(i, 2) & "'"
					cmd.Parameters.Add("@TripID", SqlDbType.Int).Value = fg.Item(i, 1)
					cmd.Connection = DB.OpenConnection(StrConnRMPApp)
					cmd.ExecuteNonQuery()
				Next
			End With
		Catch ex As Exception
			MsgBox("Data Gagal Diubah!!AndroidtblMuat", vbExclamation)
			Exit Sub
		End Try
	End Sub


	Sub UpdateTriptblTrnKelapaHDR()
		Try
			With fg
				For i = 2 To .Rows.Count - 1
					Dim cmd = New SqlCommand
					cmd.CommandText = "UPDATE RMPApp..TblTrnkelapaHdr set Trip=@Trip where Trip='" & .Item(i, 7) & "'and IDKapal='" & .Item(i, 4) & "' and IDpancang ='" & .Item(i, 2) & "'"
					cmd.Parameters.Add("@Trip", SqlDbType.Int).Value = fg.Item(i, 1)
					cmd.Connection = DB.OpenConnection(StrConnRMPApp)
					cmd.ExecuteNonQuery()
				Next
			End With
		Catch ex As Exception
			MsgBox("Data Gagal Diubah!!TblTrnKelapaHdr", vbExclamation)
			Exit Sub
		End Try
		Call MsgBox("Data Berhasil Diubah!!", vbInformation)
	End Sub
End Class