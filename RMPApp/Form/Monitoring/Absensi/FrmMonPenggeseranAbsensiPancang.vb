
Imports System.ComponentModel
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Public Class FrmMonPenggeseranAbsensiPancang

	Dim NotAktif As Integer
	'test
	Private Sub FrmMonPenggeseranAbsensiPancang_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		Modul_RMP.Combo.SetPancang(cboPancang)
		Modul_RMP.Combo.SetJabatan(cbojabatan)

		Call HeaderDgvlist1()
		Call HeaderDgvlist()

		With fgpersonil
			.Rows.Fixed = 1
			.Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)

		End With

		With fg
			.Rows.Fixed = 1
			.Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)

		End With
	End Sub


	Sub LoadData()
		Try
			Dim i As Integer
			Dim sql As String = ""


			sql = "SELECT ID,IDPersonil,Bagian,Nama,Nik,Pancang = CONVERT(varchar,IDPancang) + '. ' + Pancang,Jabatan,Status,IM,JamMasuk, " &
						 "JamPulang,UangMakan,NotActive,NotActiveBy,NotActiveDate,CreatedBy,CreatedDate,IDPancang,CV,Pemborong ,tANGGAL FROM RMPApp..vwPersonilPancangUptDate ORDER BY ID"
			Using koneksi As New SqlCommand(sql,DB.OpenConnection(StrConnRMPApp))
				Using DR = koneksi.ExecuteReader()
					If DR.HasRows Then
						dgvlist1.RowCount = 0
						While DR.Read
							With dgvlist1
								.Rows.Add()
								.Item("No1", i).Value = i + 1
								'If IsDBNull(DR!IDPersonil) Then .Item("IDPersonil1", i).Value = "" Else .Item("IDPersonil1", i).Value = DR!IDPersonil
								''If IsDBNull(DR!Nik) Then .Item("Nik1", i).Value = "" Else .Item("Nik1", i).Value = DR!Nik
								'If IsDBNull(DR!Nama) Then .Item("Nama1", i).Value = "" Else .Item("Nama1", i).Value = DR!Nama
								'If IsDBNull(DR!Jabatan) Then .Item("Jabatan", i).Value = "" Else .Item("Jabatan", i).Value = DR!Jabatan
								'If IsDBNull(DR!Status) Then .Item("Status", i).Value = "" Else .Item("Status", i).Value = DR!Status



							End With
							i += 1
						End While

					Else
						dgvlist1.Rows.Clear()
						MsgBox("Data Tidak ditemukan ! ", MsgBoxStyle.Information)
						Exit Sub
					End If

					DR.Close()
				End Using
			End Using
			DB.CloseConnection()
		Catch ex As Exception
			MsgBox(ex.Message, MsgBoxStyle.Critical)
		End Try
	End Sub

	Sub HeaderDgvlist1()
		With dgvlist 'Ganti dengan nama datagridview kalian
			.AllowUserToAddRows = False
			.RowHeadersVisible = False
			.BorderStyle = BorderStyle.None
			.EnableHeadersVisualStyles = False
			.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
			.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
			.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
			.RowHeadersDefaultCellStyle.WrapMode = False
			.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
			.ColumnHeadersHeight = 39
			.SelectionMode = DataGridViewSelectionMode.FullRowSelect
			.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise
			With .ColumnHeadersDefaultCellStyle
				.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
				.BackColor = Color.DimGray
				.ForeColor = Color.White
			End With
			'testtt---
			'testtt---
			With .RowTemplate
				.Height = 31
			End With
		End With
	End Sub


	Sub HeaderDgvlist()
		With dgvlist1 'Ganti dengan nama datagridview kalian
			.AllowUserToAddRows = False
			.RowHeadersVisible = False
			.BorderStyle = BorderStyle.None
			.EnableHeadersVisualStyles = False
			.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
			.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
			.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
			.RowHeadersDefaultCellStyle.WrapMode = False
			.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
			.ColumnHeadersHeight = 39
			.SelectionMode = DataGridViewSelectionMode.FullRowSelect
			.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise
			With .ColumnHeadersDefaultCellStyle
				.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
				.BackColor = Color.DimGray
				.ForeColor = Color.White
			End With

			With .RowTemplate
				.Height = 31
			End With
		End With
	End Sub

	Private Sub dgvlist1_Click(sender As Object, e As EventArgs) Handles dgvlist1.Click
		Dim i As Integer
		With dgvlist1
			i = .CurrentRow.Index



			With dgvlist

				callDataDetail()

			End With
		End With

	End Sub

	Sub callDataDetail()
		Dim A, i As Integer
		A = fgpersonil.Row
		Dim dt As DataTable = New DataTable()
		Try
			Dim sql As String = ""
			i = 1
			dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select  *,IDPersonil+'.'+ Nama AS Personil,	 isnull(DATEADD(DAY, -1, (select top (1) tanggalawal  from vwMonPenggeseranAbsensi2024New where IDPersonil= a.IDPersonil and TanggalAwal>a.TanggalAwal order by TanggalAwal asc)),getdate()) AS TanggalAkhir2  from vwMonPenggeseranAbsensi2024New  as a WHERE NotActive=0 and IDPersonil = '" & fgpersonil.Item(A, "IDPersonil") & "'  ORDER BY A.TANGGALAWAL ASC")

			If dt.Rows.Count > 0 Then
				With fg
					Call ui.HapusGrid(1, fg)
					For Each row As DataRow In dt.Rows
						.AddItem(i)
						If IsDBNull(row.Item("TanggalAwal")) = True Then
							.Item(i, "Tanggal") = row.Item("TanggalAwal") & "" & "  s/d  " & "" & Format(Now, "dd/MM/yyyy")
						Else
							.Item(i, "Tanggal") = row.Item("TanggalAwal") & "" & "  s/d  " & "" & row.Item("TanggalAkhir")
						End If
						.Item(i, "Personil") = row.Item("Personil")
						.Item(i, "IDPancang") = row.Item("IDPancang")
						.Item(i, "Pancang") = row.Item("Pancang")
						.Item(i, "Pengawas1") = row.Item("Pengawas1")
						.Item(i, "Pengawas2") = row.Item("Pengawas2")
						.Item(i, "MasaKerja") = DB.ExecuteScalarValue(Of String)(StrConnRMPApp, "EXEC RMPAPP..spmasa '" & Format(row.Item("TanggalAwal"), "yyyy-MM-dd") & "','" & Format(row.Item("TanggalAkhir"), "yyyy-MM-dd") & "' ")
						.Item(i, "IM") = row.Item("IM")

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
		DB.CloseConnection()

	End Sub

	Sub Loaddatatext()
		Dim i As Integer
		Dim sql As String = ""
		Dim query As String = ""
		Dim dt As DataTable = New DataTable()
		Dim aktif As String

		If chkPancang.Checked = True Then
			sql = Modul_RMP.Func.SetCondition(sql, "IDPancang = '" & cboPancang.SelectedValue & "'")
		End If

		If chkNamaPersonil.Checked = True Then
			sql = Modul_RMP.Func.SetCondition(sql, "Nama like'%" & txtNamapersonil.Text & "%'")
		End If

		If chkIDPersonil.Checked = True Then
			sql = Modul_RMP.Func.SetCondition(sql, "IDPersonil like'%" & txtIdPersonil.Text & "%'")
		End If

		If chkJabatan.Checked = True Then
			sql = Modul_RMP.Func.SetCondition(sql, "Jabatan ='" & cbojabatan.Text & "'")
		End If

		If chkAktif.Checked = True Then
			aktif = " select distinct IDPersonil from vwPersonilPCG2024 where NotActive=0 "
		Else
			aktif = " select distinct IDPersonil from vwPersonilPCG2024 "
		End If

		Try

			query = " WITH personilPcg AS (
							" & aktif & "
							),
							idTerakhirPindah as (
							SELECT (SELECT TOP (1) ID FROM dbo.vwPersonilPCG2024 AS b WHERE NotActive=0 and IDPersonil = a.IDPersonil ORDER BY Tanggal DESC) as ID FROM personilPcg as a 
							)
							SELECT IDPersonil,Bagian,Nama,(cast(IDPancang as varchar(5))+'. '+Pancang) as Pancang,IDPancang,Jabatan,Status,Tanggal,
							(IIF(getdate() >= DATEADD(MONTH, 3, Tanggal), 1, 0)) as flagLewatTigaBulan
							FROM dbo.vwPersonilPCG2024 
							where ID in (select ID from idTerakhirPindah) " & IIf(sql = "", "", " AND " & sql) & "
							order by IDPersonil asc "

			dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, query)

			i = 1
			If dt.Rows.Count > 0 Then
				With fgpersonil
					Call UI.HapusGrid(1, fgpersonil)
					For Each row As DataRow In dt.Rows

						.AddItem(i)

						.Item(i, "IDPersonil") = row.Item("IDPersonil")
						.Item(i, "Nama") = row.Item("Nama")

						.Item(i, "Pancang") = row.Item("Pancang")
						.Item(i, "Jabatan") = row.Item("Jabatan")
						.Item(i, "Status") = row.Item("Status")
						.Item(i, "Tanggal") = row.Item("Tanggal")

						If row.Item("flagLewatTigaBulan") Then
							.Rows(i).StyleNew.BackColor = Color.FromArgb(255, 192, 192)
							.Rows(i).StyleNew.ForeColor = Color.Black
						End If

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

		DB.CloseConnection()

	End Sub


	Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
		Loaddatatext()
	End Sub

	Private Sub chkAktif_CheckedChanged(sender As Object, e As EventArgs)
		'If chkAktif.Checked = True Then
		'	chkNotAktif.Checked = False
		'Else
		'	chkNotAktif.Checked = True
		'End If
	End Sub

	Private Sub chkNotAktif_CheckedChanged(sender As Object, e As EventArgs)
		'If chkNotAktif.Checked = True Then
		'	chkAktif.Checked = False
		'Else
		'	chkNotAktif.Checked = False
		'End If
	End Sub

	Private Sub chkPancang_CheckedChanged(sender As Object, e As EventArgs) Handles chkPancang.CheckedChanged
		If chkPancang.Checked = True Then
			cboPancang.Enabled = True
		Else
			cboPancang.Enabled = False
			cboPancang.Text = ""
		End If
	End Sub

	Private Sub chkNamaPersonil_CheckedChanged(sender As Object, e As EventArgs) Handles chkNamaPersonil.CheckedChanged
		If chkNamaPersonil.Checked = True Then
			txtNamapersonil.Enabled = True
		Else
			txtNamapersonil.Enabled = False
			txtNamapersonil.Text = ""
		End If
	End Sub

	Private Sub chkIDPersonil_CheckedChanged(sender As Object, e As EventArgs) Handles chkIDPersonil.CheckedChanged
		If chkIDPersonil.Checked = True Then
			txtIdPersonil.Enabled = True
		Else
			txtIdPersonil.Enabled = False
			txtIdPersonil.Text = ""
		End If
	End Sub

	Private Sub SplitContainer1_Panel2_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel2.Paint

	End Sub

	Private Sub chkJabatan_CheckedChanged(sender As Object, e As EventArgs) Handles chkJabatan.CheckedChanged
		If chkJabatan.Checked = True Then
			cbojabatan.Enabled = True
		Else
			cbojabatan.Enabled = False
			cbojabatan.Text = ""
		End If
	End Sub

	Private Sub dgvlist1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvlist1.CellContentClick

	End Sub

	Private Sub fgpersonil_Click(sender As Object, e As EventArgs) Handles fgpersonil.Click
		Dim i As Integer
		With fgpersonil

			callDataDetail()

		End With
	End Sub

	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
		Dim filename As String
		Me.SaveFileDialog1.ShowDialog()
		filename = SaveFileDialog1.FileName
		Me.fgpersonil.SaveExcel(filename & ".xls", "Sheet1", FileFlags.IncludeFixedCells)
		MsgBox("Convert Success !", vbInformation, AT)
	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Dim filename As String
		Me.SaveFileDialog2.ShowDialog()
		filename = SaveFileDialog2.FileName
		Me.fg.SaveExcel(filename & ".xls", "Sheet1", FileFlags.IncludeFixedCells)
		MsgBox("Convert Success !", vbInformation, AT)
	End Sub


	Private Sub fgpersonil_DoubleClick(sender As Object, e As EventArgs) Handles fgpersonil.DoubleClick
		Select Case fgpersonil.Col
			Case 1, 2, 3, 4, 5
				With FrmTrnPergeseranPancang
					.id = fgpersonil.Item(fgpersonil.RowSel, "IDPersonil")
					.ShowDialog()
					'.dtp1.Enabled = False
					'.dtp2.Enabled = False
					.btnsave.Visible = True
					.btnexit.Enabled = True
					.chkAllPancang.Checked = False
				End With
		End Select
	End Sub

	'Private Sub Button3_Click(sender As Object, e As EventArgs)
	'	Me.Cursor = Cursors.WaitCursor
	'	Dim dt As DataTable = New DataTable
	'	For i = 1 To fgpersonil.Rows.Count - 1
	'		dt = DB.ExecuteQuery(StrConnRMPApp," select * from Android_tblMstPancang where RingWilayah is not null ")
	'		For Each row As DataRow In dt.Rows
	'			DB.ExecuteQuery(StrConnRMPApp," if not exists (select * from tblHistoryPerpindahanPersonilPcg where idPancang='" & row.Item("IDPancang") & "' and idPersonil='" & fgpersonil.Item(i, "IDPersonil") & "')
	'                                                          begin
	'                                                            insert into tblHistoryPerpindahanPersonilPcg (idPersonil,ringWilayah,idPancang,falgSudahPernah)
	'                                                            values ('" & fgpersonil.Item(i, "IDPersonil") & "','" & row.Item("RingWilayah") & "','" & row.Item("IDPancang") & "',0)
	'                                                          end ")
	'		Next

	'		i += 1
	'	Next
	'	Me.Cursor = Cursors.Default
	'	MsgBox("selesai")
	'End Sub
End Class
