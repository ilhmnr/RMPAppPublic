Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmTrnUangMakanPersonilPancang
    Dim Perintah, Bagian As String

    Private Sub FrmTrnHitungUangMakanPersonilPCG_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Modul_RMP.Combo.SetPancang(cboPancang)
        Modul_RMP.Combo.SetJabatan(cboJabatan)
        Modul_RMP.Combo.SetStatus(cboStatus)

        dtpTanggal.Value = Format(Now, "yyyy-MM-dd")
        dtpTanggal2.Value = Format(Now, "yyyy-MM-dd")
        dtpTransDate.Value = Format(Now, "yyyy-MM-dd")
        fg.Rows.Count = 1
        txtNoTrans.Enabled = False

        dtpTanggal.Enabled = False
        dtpTanggal2.Enabled = False
        dtpTransDate.Enabled = False
        cboPancang.Enabled = False
        cboJabatan.Enabled = False
        cboStatus.Enabled = False

        btnAdd.Enabled = True
        btnClose.Enabled = True
        btnSave.Enabled = False
        btnRefresh.Enabled = False
        btnCancel.Enabled = False
        btnFind.Enabled = True
        btnDelete.Enabled = False

        Call Search()
        Call HeaderFG()
    End Sub

    Private Sub Search()
        With scp
            .SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
            .SearchDelay = 2
            .Watermark = "Cari Disini"
            .SetC1FlexGridSearchPanel(fg, scp)
        End With
    End Sub

    Public Sub HeaderFG()
        Dim txt As CellRange
        With fg
            .AllowEditing = True
            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular)
            .Cols.Count = 13
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

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "N0" : .Cols(0).Width = 50
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "ID Personil" : .Cols(1).TextAlign = TextAlignEnum.CenterCenter : .Cols(1).AllowEditing = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Bagian" : .Cols(2).TextAlign = TextAlignEnum.CenterCenter : .Cols(2).AllowEditing = False
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Nama" : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).AllowEditing = False
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "NIK" : .Cols(4).TextAlign = TextAlignEnum.CenterCenter : .Cols(4).AllowEditing = False
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Jabatan" : .Cols(5).TextAlign = TextAlignEnum.CenterCenter : .Cols(5).AllowEditing = False
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Status" : .Cols(6).TextAlign = TextAlignEnum.CenterCenter : .Cols(6).AllowEditing = False
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Libur Mingguan" : .Cols(7).TextAlign = TextAlignEnum.CenterCenter : .Cols(7).AllowEditing = False
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "ID Pancang" : .Cols(8).TextAlign = TextAlignEnum.CenterCenter : .Cols(8).AllowEditing = False : .Cols(8).Visible = False
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Pancang" : .Cols(9).TextAlign = TextAlignEnum.LeftCenter : .Cols(9).AllowEditing = False
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "Jumlah HK" : .Cols(10).TextAlign = TextAlignEnum.CenterCenter : .Cols(10).AllowEditing = False
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "Uang Makan" : .Cols(11).TextAlign = TextAlignEnum.RightCenter : .Cols(11).AllowEditing = False : .Cols(11).Format = "#,###0"
            txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "Total" : .Cols(12).TextAlign = TextAlignEnum.RightCenter : .Cols(12).AllowEditing = False : .Cols(12).Format = "#,###0"

            .AutoSizeCols()
        End With
    End Sub

    Private Sub ShowData()
        Dim i As Integer = 1
        Dim sql As String = ""
        Dim dt As DataTable = New DataTable()

        Try
            If chkPancang.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "IDPancang = '" & cboPancang.SelectedValue & "'")
            End If

            If chkJabatan.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "Jabatan = '" & cboJabatan.Text & "'")
            End If

            If chkStatus.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "Status = '" & cboStatus.Text & "'")
            End If

            If rdP1.Checked = True Then
                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT IDPersonil, Bagian, Nama, Nik, Jabatan, Status, IM, IDPancang, Pancang, UangMakan, Count(Kehadiran) AS TotalHK FROM vwAndroidAbsensiPCG_ WHERE Bagian = 'P1' AND CONVERT(DATETIME,CONVERT(VARCHAR, JamMasuk,103),103) BETWEEN CONVERT (DATETIME,'" & dtpTanggal.Value & "',103) AND CONVERT(DATETIME,'" & dtpTanggal2.Value & "',103) AND Kehadiran IN ('H','TL') " & IIf(sql = "", "", " AND " & sql) & " GROUP BY IDPersonil, Bagian, Nama, Nik, Jabatan, Status, IM, IDPancang, Pancang, UangMakan ORDER BY Nama")
            ElseIf rdP2.Checked = True Then
                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT IDPersonil, Bagian, Nama, Nik, Jabatan, Status, IM, IDPancang, Pancang, UangMakan, Count(Kehadiran) AS TotalHK FROM vwAndroidAbsensiPCG_ WHERE Bagian = 'P2' AND CONVERT(DATETIME,CONVERT(VARCHAR, JamMasuk,103),103) BETWEEN CONVERT (DATETIME,'" & dtpTanggal.Value & "',103) AND CONVERT(DATETIME,'" & dtpTanggal2.Value & "',103) AND Kehadiran IN ('H','TL') " & IIf(sql = "", "", " AND " & sql) & " GROUP BY IDPersonil, Bagian, Nama, Nik, Jabatan, Status, IM, IDPancang, Pancang, UangMakan ORDER BY Nama")
            End If

            If dt.Rows.Count > 0 Then
                With fg
                    Call ui.HapusGrid(1, fg)
                    For Each row As DataRow In dt.Rows
                        .AddItem(i)

                        .Item(i, 1) = row.Item("IDPersonil")
                        .Item(i, 2) = row.Item("Bagian")
                        .Item(i, 3) = row.Item("Nama")
                        .Item(i, 4) = row.Item("Nik")
                        .Item(i, 5) = row.Item("Jabatan")
                        .Item(i, 6) = row.Item("Status")
                        .Item(i, 7) = row.Item("IM")
                        .Item(i, 8) = row.Item("IDPancang")
                        .Item(i, 9) = row.Item("Pancang")
                        .Item(i, 10) = row.Item("TotalHK")
                        .Item(i, 11) = row.Item("UangMakan")
                        .Item(i, 12) = row.Item("TotalHK") * row.Item("UangMakan")
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

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtMonth.Text = ""
        txtYear.Text = ""
        txtNoTrans.Text = ""
        dtpTanggal.Value = Format(Now, "yyyy-MM-dd")
        dtpTanggal2.Value = Format(Now, "yyyy-MM-dd")
        dtpTransDate.Value = Format(Now, "yyyy-MM-dd")
        fg.Rows.Count = 1
        btnAdd.Enabled = True
        btnClose.Enabled = True
        btnSave.Enabled = False
        btnRefresh.Enabled = False
        btnCancel.Enabled = False
        btnDelete.Enabled = False
        btnFind.Enabled = True
        dtpTanggal.Enabled = False
        dtpTanggal2.Enabled = False
        dtpTransDate.Enabled = False
    End Sub

    Private Sub txtMonth_KeyPress(sender As Object, e As KeyPressEventArgs)
        UI.validasi(e, 2)
    End Sub

    Private Sub txtYear_KeyPress(sender As Object, e As KeyPressEventArgs)
        UI.validasi(e, 2)
    End Sub

    Private Sub cboPancang_KeyUp(sender As Object, e As KeyEventArgs) Handles cboPancang.KeyUp
        UI.AutoCompleteCombo_KeyUp(cboPancang, e)
    End Sub

    Private Sub cboJabatan_KeyUp(sender As Object, e As KeyEventArgs) Handles cboJabatan.KeyUp
        UI.AutoCompleteCombo_KeyUp(cboJabatan, e)
    End Sub

    Private Sub cboStatus_KeyUp(sender As Object, e As KeyEventArgs) Handles cboStatus.KeyUp
        UI.AutoCompleteCombo_KeyUp(cboStatus, e)
    End Sub

    Private Sub chkPancang_CheckedChanged(sender As Object, e As EventArgs) Handles chkPancang.CheckedChanged
        If chkPancang.Checked = True Then
            cboPancang.Enabled = True
        Else
            cboPancang.Enabled = False
            cboPancang.Text = ""
        End If
    End Sub

    Private Sub chkJabatan_CheckedChanged(sender As Object, e As EventArgs) Handles chkJabatan.CheckedChanged
        If chkJabatan.Checked = True Then
            cboJabatan.Enabled = True
        Else
            cboJabatan.Enabled = False
            cboJabatan.Text = ""
        End If
    End Sub

    Private Sub chkStatus_CheckedChanged(sender As Object, e As EventArgs) Handles chkStatus.CheckedChanged
        If chkStatus.Checked = True Then
            cboStatus.Enabled = True
        Else
            cboStatus.Enabled = False
            cboStatus.Text = ""
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        'If txtMonth.Text = "" Then
        '    MsgBox("Month tidak boleh kosong !!", MsgBoxStyle.Exclamation, AT)
        '    Exit Sub
        'End If

        'If txtYear.Text = "" Then
        '    MsgBox("Year tidak boleh kosong !!", MsgBoxStyle.Exclamation, AT)
        '    Exit Sub
        'End If

        btnAdd.Enabled = False
        btnClose.Enabled = True
        btnSave.Enabled = True
        btnRefresh.Enabled = True
        btnCancel.Enabled = True
        btnDelete.Enabled = True
        btnFind.Enabled = True

        Call ShowData()
    End Sub

    Private Sub NoTrans()
        Try
            If Perintah = "Add" Then
                Dim Conn As New SqlConnection(StrConnRMPApp)
                Conn.Open()
                Dim NoTrans As String
                Dim Sql As String

                Sql = "SELECT TOP 1 NoTrans FROM RMPApp..tblTrnUangMakanHdr WHERE YEAR(TransDate) = " & Year(dtpTransDate.Value) & " AND MONTH(TransDate) = " & Month(dtpTransDate.Value) & " ORDER BY NoTrans DESC"

                Dim cmd As New SqlClient.SqlCommand(Sql, Conn)
                Dim reader As SqlClient.SqlDataReader
                reader = cmd.ExecuteReader

                If reader.HasRows Then
                    Do While reader.Read
                        NoTrans = Mid("00000", 1, 5 - (Val(Trim(reader.Item(0).ToString)) + 1).ToString.Length) + (Val(Trim(reader.Item(0).ToString)) + 1).ToString
                        txtNoTrans.Text = NoTrans & "/" & Format(dtpTransDate.Value, "MMyyyy")
                    Loop
                Else
                    txtNoTrans.Text = "00001" & "/" & Format(dtpTransDate.Value, "MMyyyy")
                End If

                Conn.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Default
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Perintah = ""
        Perintah = "Add"
        dtpTransDate.Focus()

        btnAdd.Enabled = False
        btnClose.Enabled = True
        btnSave.Enabled = False
        btnRefresh.Enabled = True
        btnCancel.Enabled = True
        btnFind.Enabled = True
        btnDelete.Enabled = False
        dtpTanggal.Enabled = True
        dtpTanggal2.Enabled = True
        dtpTransDate.Enabled = True

        Call NoTrans()
    End Sub

    Private Sub dtpTransDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpTransDate.ValueChanged
        Call NoTrans()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim Koneksi As SqlConnection = DB.OpenConnection(StrConnRMPApp)
        Dim Transaksi As SqlTransaction
        Transaksi = Koneksi.BeginTransaction
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim i As Integer

            If rdP1.Checked = True Then
                Bagian = "P1"
            ElseIf rdP2.Checked = True Then
                Bagian = "P2"
            End If

            If SaveHdr(Koneksi, Transaksi) = False Then
                Transaksi.Rollback()
                Transaksi = Nothing
                Me.Cursor = Cursors.Default
                MessageBox.Show("Simpan Data Hdr Gagal !", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            For i = 1 To fg.Rows.Count - 1
                If SaveDtl(Koneksi, Transaksi, i) = False Then
                    Transaksi.Rollback()
                    Transaksi = Nothing
                    Me.Cursor = Cursors.Default
                    MessageBox.Show("Simpan Data Dtl Gagal !", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Next i

            Transaksi.Commit()

            Me.Cursor = Cursors.Default
            MessageBox.Show("Simpan Data Berhasil !", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

            fg.Rows.Count = 1
            txtNoTrans.Text = ""
            Perintah = ""

            btnClose.Enabled = True
            btnCancel.Enabled = True
            btnDelete.Enabled = False
            btnSave.Enabled = False
            btnRefresh.Enabled = False
            btnAdd.Enabled = True
            btnFind.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Transaksi.Rollback()
            Koneksi.Close()
            Me.Cursor = Cursors.Default
        Finally
            Koneksi.Close()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function SaveHdr(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        Dim MyCMD As New SqlCommand

        Try
            With MyCMD
                Dim MyCon As SqlConnection = Conn
                Dim MyConTrans As SqlTransaction = Trans
                .Connection = MyCon
                .CommandType = CommandType.StoredProcedure
                .CommandText = "RMPApp..spTrnUangMakanHdr"
                .Transaction = MyConTrans

                .Parameters.Add("@RETURN_VALUE", SqlDbType.SmallInt).Direction = ParameterDirection.ReturnValue
                .Parameters.Add("@Perintah", SqlDbType.VarChar, 10).Value = Perintah
                .Parameters.Add("@NoTrans", SqlDbType.VarChar, 30).Value = txtNoTrans.Text
                .Parameters.Add("@TransDate", SqlDbType.DateTime).Value = dtpTransDate.Value
                .Parameters.Add("@Bagian", SqlDbType.VarChar, 30).Value = Bagian
                .Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
                .Parameters.Add(New SqlParameter("@Flag", SqlDbType.SmallInt, 5, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
                .ExecuteNonQuery()

                If CInt(.Parameters("@Flag").Value) = 0 Then
                    .Dispose()
                    Exit Function
                End If

                Return True
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message & "Simpan Data Gagal, - spRMTrnUpahBongkarMuatHdr")
            Return False
        End Try

        Return True
    End Function

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        FrmRptUangMakanPancang.Show()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtNote.TextChanged

    End Sub

    Private Function SaveDtl(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal i As Integer) As Boolean
        Dim MyCMD As New SqlCommand
        With MyCMD

            SaveDtl = False
            Dim MyCon As SqlConnection = Conn
            Dim MyConTrans As SqlTransaction = Trans

            .Connection = MyCon
            .Connection = MyCon
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RMPApp..spTrnUangMakanDtl"
            .Transaction = MyConTrans

            .Parameters.Add("@RETURN_VALUE", SqlDbType.SmallInt).Direction = ParameterDirection.ReturnValue
            .Parameters.Add("@NoTrans", SqlDbType.VarChar, 30).Value = txtNoTrans.Text
            .Parameters.Add("@TransDate", SqlDbType.DateTime).Value = dtpTransDate.Value
            .Parameters.Add("@PersonilID", SqlDbType.VarChar, 20).Value = fg.Item(i, 1)
            .Parameters.Add("@Nama ", SqlDbType.VarChar, 100).Value = fg.Item(i, 3)
            .Parameters.Add("@NIK", SqlDbType.Int).Value = fg.Item(i, 4)
            .Parameters.Add("@Jabatan", SqlDbType.VarChar).Value = fg.Item(i, 5)
            .Parameters.Add("@Status", SqlDbType.VarChar).Value = fg.Item(i, 6)
            .Parameters.Add("@IDPancang", SqlDbType.Int).Value = fg.Item(i, 8)
            .Parameters.Add("@UangMakan", SqlDbType.Decimal, 18, 0).Value = fg.Item(i, 12)
            .Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
            .Parameters.Add(New SqlParameter("@Flag", SqlDbType.SmallInt, 5, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .ExecuteNonQuery()

            If CInt(.Parameters("@Flag").Value) = 0 Then
                .Dispose()
                Exit Function
            End If

            Return True
        End With
    End Function

    Private Sub TextBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles txtNote.MouseClick
        If txtNote.Text = "Input Note Print Out" Then txtNote.Text = String.Empty
    End Sub

    Private Sub txtNote_LostFocus(sender As Object, e As EventArgs) Handles txtNote.LostFocus
        If txtNote.Text = String.Empty Then txtNote.Text = "Input Note Print Out"
    End Sub
End Class