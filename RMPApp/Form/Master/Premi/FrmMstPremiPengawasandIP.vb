Imports System.ComponentModel
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmMstPremiPengawasandIP
    Dim Perintah As String
    Dim Notrans_ As String
    Dim myItems As New List(Of cmbItem)
    Public Sub cmdENabled(ByVal flag As Boolean)
        BTNFIND.Enabled = flag
        btnAdd.Enabled = flag
        btnEdit.Enabled = flag
        'btndelete.Enabled = flag
        btnsave.Enabled = Not flag
        btnCancel.Enabled = Not flag
        btnclose.Enabled = flag
    End Sub
    Private Sub controlenabled(ByVal flag As Boolean)
        dttgl.Enabled = flag
        txtnotrans.Enabled = flag
        dgvlist.Enabled = flag
        txtbatasskbb.Enabled = flag
        txtbatassusut.Enabled = flag
    End Sub


    Private Sub ClearTxt()
        btnAdd.Enabled = True
        btnsave1.Enabled = False
        btnEdit.Enabled = False
        btnCancel.Enabled = True
        txtbatasskbb.Clear()
        txtbatassusut.Clear()
        txtnotrans.Clear()
        txtMaksimal_KBB_Pengawas.Clear()
        txtMax_Susut_Kg_Pengawas.Clear()
        txtVol_KB_Pcg_Pengawas.Clear()
        txtMaksimal_KBB_Inspektor.Clear()
        txtMax_Susut_Kg_Inspektor.Clear()
        txtVol_KB_Pcg_Inspektor.Clear()


    End Sub


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        ClearTxt()
        ShowdataPancang()
        controlenabled(True)
        cmdENabled(False)
        Perintah = "Add"
        dttgl.Focus()

        'kodetrans()
    End Sub

    Private Sub ShowdataPancang()
        Dim sql As String
        Dim sql2 As String
        Dim i As Integer = 0

        sql = "Select * FROM RMPApp..Android_tblMstPancang WHERE IDPANCANG<>40 ORDER BY IDPANCANG ASC"
        Using koneksi As New SqlCommand(sql,DB.OpenConnection(StrConnRMPApp))
            Using DR = koneksi.ExecuteReader
                dgvlist.RowCount = 0
                If DR.HasRows Then
                    Do While DR.Read
                        With dgvlist
                            .Rows.Add()

                            .Item("IDPancang", i).Value = DR!IDPancang
                            .Item("Pancang", i).Value = DR!Pancang

                            .RowsDefaultCellStyle.BackColor = Color.White
                            .AlternatingRowsDefaultCellStyle.BackColor = Color.Azure
                        End With
                        i += 1
                    Loop
                Else
                    MsgBox("Data tidak ditemukan!")
                End If
            End Using
        End Using



    End Sub

    Public Sub ShowdataDTL(NOTRANS As String)
        'dgvlist.Columns.RemoveAt(3)
        'Dim ringSHOW As New DataGridViewTextBoxColumn

        'ringSHOW.HeaderText = "Ring"
        'ringSHOW.Name = "ringSHOW"
        'dgvlist.Columns.Add(ringSHOW)


        Dim sql As String
        Dim i As Integer = 0

        sql = "Select * FROM RMPApp..vwMstPremiPengawasdanInspektorDtl WHERE NOTRANS ='" & NOTRANS & "' "
        Using koneksi As New SqlCommand(sql,DB.OpenConnection(StrConnRMPApp))
            Using DR = koneksi.ExecuteReader
                dgvlist.RowCount = 0
                If DR.HasRows Then
                    Do While DR.Read
                        With dgvlist
                            .Rows.Add()

                            .Item("IDPancang", i).Value = DR!IDPancang
                            .Item("Pancang", i).Value = DR!Pancang
                            .Item("Volume", i).Value = If(IsDBNull(DR!Volume) = True, 0, DR!Volume)
                            '.Item("RING", i).Selected = 1
                            CType(Me.dgvlist("RING", i), DataGridViewComboBoxCell).Value = DR!IDRing


                            .RowsDefaultCellStyle.BackColor = Color.White
                            .AlternatingRowsDefaultCellStyle.BackColor = Color.Azure
                        End With
                        i += 1
                    Loop
                Else
                    MsgBox("Data tidak ditemukan!")
                End If
            End Using
        End Using



    End Sub
    Public Class cmbItem
        Property Text() As String
        Property DisplayText() As String
    End Class
    Private Sub kolomring()
        Dim x As Integer


        Dim ring As New DataGridViewComboBoxColumn
        ring.FlatStyle = FlatStyle.Flat
        ring.DisplayStyle = ComboBoxStyle.DropDown


        ring.HeaderText = "Ring"
        ring.Name = "Ring"
        dgvlist.Columns.Add(ring)

        'For x = 0 To dgvlist.RowCount - 1
        Dim dt As DataTable = New DataTable()
        dt = Modul_RMP.DB.ExecuteQuery(StrConnAccounting, "select * from RMPAPP..tblRMMstRing")
        With ring
            .DataSource = dt
            .DisplayMember = "RING"
            .ValueMember = "IDRing"
        End With

        'Next x
        'dgvlist.RowCount = dgvlist.RowCount - 1
        ring.Width = 90
    End Sub

    Private Sub dgvlist_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvlist.EditingControlShowing

        'If TypeOf e.Control Is DataGridViewComboBoxEditingControl Then
        '    DirectCast(e.Control, ComboBox).DropDownStyle = ComboBoxStyle.DropDown
        '    DirectCast(e.Control, ComboBox).AutoCompleteSource = AutoCompleteSource.ListItems
        '    DirectCast(e.Control, ComboBox).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        'End If

    End Sub

    Private Sub kodetrans()
        Try
            If Perintah = "Add" Then
                Dim connrm As New SqlConnection(StrConnPSGRMP)
                connrm.Open()
                Dim KodeHarga As String
                Dim sql As String
                sql = "Select Top 1 (left(KodeSampelString,4))AS KodeSampelString from TblRMMstSampelQualityHdr " &
                    " where Month(periode)= '" & Month(dttgl.Value) & "' " &
                    " and Year(Periode) ='" & Year(dttgl.Value) & "' order by Periode desc"
                Dim cqd As New SqlClient.SqlCommand(sql, connrm)
                Dim reader As SqlClient.SqlDataReader
                reader = cqd.ExecuteReader
                If reader.Read Then
                    KodeHarga = Mid("000", 1, 5 - (Val(Trim(reader.Item(0).ToString)) + 1).ToString.Length) + (Val(Trim(reader.Item(0).ToString)) + 1).ToString
                    txtnotrans.Text = KodeHarga & "-" & Format(dttgl.Value, "MMyyyy")
                Else
                    txtnotrans.Text = "0001" & "-" & Format(dttgl.Value, "MMyyyy")
                End If
                connrm.Close()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try
    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Call ClearTxt()
        ClearTxt()
        ShowdataPancang()

        cmdENabled(True)
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Perintah = ""

        If txtnotrans.Text = "" Then
            MessageBox.Show("Tidak ada data yang di Edit, Klik Find untuk Edit data", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        cmdENabled(False)
        Perintah = "Edit"
        txtnotrans.Enabled = False
        controlenabled(True)
    End Sub

    Private Function SimpanDataHdr(ByVal Conn2 As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        SimpanDataHdr = False
        Dim cqd As New SqlCommand
        Dim MyCon As SqlConnection = Conn2
        Dim MyConTrans As SqlTransaction = Trans
        cqd.Connection = MyCon
        cqd.CommandType = CommandType.StoredProcedure
        cqd.CommandText = "RMPApp..spMstPremiPengawasdanInspektorHdr"
        cqd.Transaction = MyConTrans
        cqd.Parameters.Add("@RETURN_VALUE", SqlDbType.SmallInt).Direction = ParameterDirection.ReturnValue
        cqd.Parameters.Add("@Perintah", SqlDbType.VarChar, 20).Value = Perintah
        cqd.Parameters.Add(New SqlParameter("@NoTrans", SqlDbType.VarChar, 20, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
        cqd.Parameters.Add("@NoTrans2", SqlDbType.VarChar, 30).Value = txtnotrans.Text
        cqd.Parameters.Add("@Periode", SqlDbType.Date).Value = CDate(Format(dttgl.Value, "dd/MM/yyyy"))
        cqd.Parameters.Add("@PeriodeString", SqlDbType.VarChar, 20).Value = CDate(Format(dttgl.Value, "dd/MM/yyyy"))
        cqd.Parameters.Add("@Batas_KB_B", SqlDbType.Decimal, 18, 2).Value = CDbl(txtbatasskbb.Text)
        cqd.Parameters.Add("@Batas_Susut_KB", SqlDbType.Decimal, 18, 2).Value = CDbl(txtbatassusut.Text)
        cqd.Parameters.Add("@Grade_KB", SqlDbType.VarChar, 10).Value = cmbGrade_KB.SelectedValue.ToString
        cqd.Parameters.Add("@Maksimal_KBB_Pengawas", SqlDbType.Decimal, 18, 2).Value = CDbl(txtMaksimal_KBB_Pengawas.Text)
        cqd.Parameters.Add("@Max_Susut_Kg_Pengawas", SqlDbType.Decimal, 18, 2).Value = CDbl(txtMax_Susut_Kg_Pengawas.Text)
        cqd.Parameters.Add("@Vol_KB_Pcg_Pengawas", SqlDbType.Decimal, 18, 2).Value = CDbl(txtVol_KB_Pcg_Pengawas.Text)
        cqd.Parameters.Add("@Maksimal_KBB_Inspektor", SqlDbType.Decimal, 18, 2).Value = CDbl(txtMaksimal_KBB_Inspektor.Text)
        cqd.Parameters.Add("@Max_Susut_Kg_Inspektor", SqlDbType.Decimal, 18, 2).Value = CDbl(txtMax_Susut_Kg_Inspektor.Text)
        cqd.Parameters.Add("@Vol_KB_Pcg_Inspektor", SqlDbType.Decimal, 18, 2).Value = CDbl(txtVol_KB_Pcg_Inspektor.Text)
        cqd.Parameters.Add("@MonthPeriode", SqlDbType.VarChar, 10).Value = CDate(Format(dttgl.Value, "MM/yyyy"))
        cqd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
        cqd.Parameters.Add("@LastUpdatedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
        cqd.Parameters.Add(New SqlParameter("@Flag", SqlDbType.SmallInt, 5, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
        cqd.ExecuteNonQuery()
        If Perintah = "Add" Then
            Notrans_ = cqd.Parameters("@NoTrans").Value
        Else
            ''Notrans_ = cqd.Parameters("@NoTrans2").Value
        End If
        If CInt(cqd.Parameters("@Flag").Value) = 0 Then
            cqd.Dispose()
            Exit Function
        End If
        Return True

    End Function




    Private Function SimpanDataDtl(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal i As Integer) As Boolean
        SimpanDataDtl = False
        Dim cqd As New SqlCommand
        Dim MyCon As SqlConnection = Conn
        Dim MyConTrans As SqlTransaction = Trans
        cqd.Connection = MyCon
        cqd.CommandType = CommandType.StoredProcedure
        cqd.CommandText = "RMPApp..spMstPremiPengawasdanInspektorDtl"
        cqd.Transaction = MyConTrans
        cqd.Parameters.Add("@RETURN_VALUE", SqlDbType.SmallInt).Direction = ParameterDirection.ReturnValue
        cqd.Parameters.Add("@DetailID", SqlDbType.Int).Value = 0
        cqd.Parameters.Add("@NoTrans", SqlDbType.VarChar, 20).Value = Notrans_
        cqd.Parameters.Add("@Volume", SqlDbType.Decimal, 18, 2).Value = If(Val(dgvlist.Item("Volume", i).Value) = 0, 0, CDbl(dgvlist.Item("Volume", i).Value))
        cqd.Parameters.Add("@IDPancang", SqlDbType.Int).Value = If(Val(dgvlist.Item("IDPancang", i).Value) = 0, 0, (dgvlist.Item("IDPANCANG", i).Value))
        cqd.Parameters.Add("@Ring", SqlDbType.VarChar, 20).Value = dgvlist.Item("Ring", i).Value
        cqd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
        cqd.Parameters.Add("@LastUpdatedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
        cqd.Parameters.Add(New SqlParameter("@Flag", SqlDbType.SmallInt, 5, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
        cqd.ExecuteNonQuery()
        If CInt(cqd.Parameters("@Flag").Value) = 0 Then
            cqd.Dispose()
            Exit Function
        End If
        Return True
    End Function

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim Koneksi As SqlConnection = DB.OpenConnection(StrConnAccounting)
        Dim Transaksi As SqlTransaction

        Transaksi = Koneksi.BeginTransaction
        Me.Cursor = Cursors.WaitCursor
        Try

            If txtbatassusut.Text = "" Or Val(txtbatassusut.Text) = 0 Then
                MessageBox.Show("Cek Batas Susut!", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If txtbatasskbb.Text = "" Or Val(txtbatasskbb.Text) = 0 Then
                MessageBox.Show("Cek Batas KB B!", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If cmbGrade_KB.Text = "" Then
                MessageBox.Show("Cek Grade!", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If


            If SimpanDataHdr(Koneksi, Transaksi) = False Then
                Transaksi.Rollback()
                Me.Cursor = Cursors.Default
                MessageBox.Show("Simpan data gagal!", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            With dgvlist
                For i = 0 To .Rows.Count - 1
                    If SimpanDataDtl(Koneksi, Transaksi, i) = False Then
                        Transaksi.Rollback()
                        MsgBox("Simpan Master Premi dan Inspektor Gagal", vbExclamation, "Save Data - " & AT)
                        Exit Try
                    End If
                Next
            End With

            Transaksi.Commit()
            Me.Cursor = Cursors.Default
            MessageBox.Show("Simpan data berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)


            Call ClearTxt()
            Perintah = ""
            cmdENabled(True)
            controlenabled(False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Transaksi.Rollback()
            Koneksi.Close()
            Me.Cursor = Cursors.Default
        Finally
            Koneksi.Close()
            Me.Cursor = Cursors.Default
        End Try
        Call ClearTxt()
        Call cmdENabled(True)
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub BTNFIND_Click(sender As Object, e As EventArgs) Handles BTNFIND.Click
        FrmMstPremiPengawasdanIPFind.Show()
    End Sub

    Private Sub FrmMasterPremiPengawasandIP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If dgvlist.Columns.Count < 4 Then
            kolomring()
        End If

        Combo.SetJenisByKDJenis(cmbGrade_KB)

        dgvlist.Columns("VOLUME").DefaultCellStyle.Format = "#,##0"
        dgvlist.Columns("VOLUME").DefaultCellStyle.Format = "n0"
        dgvlist.Columns("VOLUME").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvlist.Columns("VOLUME").ValueType = GetType(Double)
    End Sub

    Private Sub dttgl_ValueChanged(sender As Object, e As EventArgs) Handles dttgl.ValueChanged

    End Sub
End Class