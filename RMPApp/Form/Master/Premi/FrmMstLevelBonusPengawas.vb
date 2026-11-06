Imports System.Data.SqlClient
Imports System.IO
Imports System.Data
Imports System.ComponentModel
Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Globalization

Public Class FrmMstLevelBonusPengawas
    Dim dt As DataTable = New DataTable()
    Dim Bergerak As Integer
    Dim Teks As String
    Dim Perintah As String
    Private Sub FrmMstLavelBonus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnSave.Enabled = False
        btnEdit.Enabled = False
        DtPeriode.Value = Format(Now, "yyyy-MM-dd") 'fg.Rows.Add()
        'Teks = lblInfo.Text
        'Timer.Start()
        Perintah = ""
        DtPeriode.Enabled = True
        DtPeriode.Focus()
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        'Dim i As Integer, c As DataGridView = fg
        'For x As Integer = 0 To c.RowCount - 1
        '    c.Item("Hub", x).Value = "-"
        'Next

    End Sub

    Private Sub fg_KeyPress(sender As Object, e As KeyPressEventArgs)
        'Dim a As Integer
        'If e.KeyChar = Convert.ToChar(13) Then
        '    a = fg.CurrentRow.Index
        '    If fg.Item("Range1", a).Value <> "" And fg.Item("Range2", a).Value <> "" And fg.Item("BonusRupiahSatu", a).Value <> "" And fg.Item("BonusRupiahDua", a).Value <> "" And fg.Item("BonusRupiahTiga", a).Value <> "" And fg.Item("BonusRupiahEmpat", a).Value <> "" And fg.Item("BonusRupiahLima", a).Value <> "" And fg.Item("BonusRupiahEnam", a).Value <> "" Then
        '        'fg.Item("No", a).Value = a + 1
        '        fg.Rows.Add()

        '    End If
        'End If
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Perintah = "Add"
        NoNota()
        ListLavel()
        HEADERADD()
        Dim a As Integer
        'a = fg.CurrentRow.Index
        ' fg.Rows.Add()
        DtPeriode.Enabled = True
        btnAdd.Enabled = False
        btnSave.Enabled = True
        btnEdit.Enabled = False
        btnCancel.Enabled = True
        btnFind.Enabled = False
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Call SimpanData()

    End Sub
    Private Sub SimpanData()

        Dim Koneksis As SqlConnection = DB.OpenConnection(StrConnRMPApp)
        Dim Transaksi As SqlTransaction

        Transaksi = Koneksis.BeginTransaction
        Me.Cursor = Cursors.WaitCursor
        Try
            If Perintah = "Add" Then
                If SimpanDataHDR(Koneksis, Transaksi) = False Then
                    Transaksi.Rollback()
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If

                pointurut1()
                pointurut2()
                pointurut3()
                pointurut4()
                pointurut5()
                pointurut6()


            Else
                '//Untuk menyimpan data detailnya per column
                For i = 0 To dgvlist.RowCount - 1
                    If SimpanDataUpdate1(Koneksis, Transaksi, i) = False Then
                        Transaksi.Rollback()
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                Next

                For i = 0 To dgvlist.RowCount - 1
                    If SimpanDataUpdate2(Koneksis, Transaksi, i) = False Then
                        Transaksi.Rollback()
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                Next
                For i = 0 To dgvlist.RowCount - 1
                    If SimpanDataUpdate3(Koneksis, Transaksi, i) = False Then
                        Transaksi.Rollback()
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                Next

                For i = 0 To dgvlist.RowCount - 1
                    If SimpanDataUpdate4(Koneksis, Transaksi, i) = False Then
                        Transaksi.Rollback()
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                Next

                For i = 0 To dgvlist.RowCount - 1
                    If SimpanDataUpdate5(Koneksis, Transaksi, i) = False Then
                        Transaksi.Rollback()
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                Next

                For i = 0 To dgvlist.RowCount - 1
                    If SimpanDataUpdate6(Koneksis, Transaksi, i) = False Then
                        Transaksi.Rollback()
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                Next
            End If


            Transaksi.Commit()
            Me.Cursor = Cursors.Default
            MessageBox.Show("Simpan data berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Transaksi.Rollback()
            Koneksis.Close()
            Me.Cursor = Cursors.Default
        Finally
            Koneksis.Close()
            Me.Cursor = Cursors.Default

        End Try
        ' Call ClearData()
    End Sub
    Private Function SimpanDataHDR(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        Dim MyCMD As New SqlCommand
        SimpanDataHDR = False
        ' Try
        With MyCMD
            .Connection = Conn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RMPApp..spSaveMstLavelBonusHdr"
            .Transaction = Trans
            .Parameters.Add("@KodeMaster", SqlDbType.VarChar).Value = txtID.Text
            .Parameters.Add("@Periode", SqlDbType.Date).Value = Format(DtPeriode.Value, "yyyy/MM/dd")
            .Parameters.Add("@PeriodeString", SqlDbType.VarChar).Value = Format(DtPeriode.Value, "dd/MM/yyyy")
            .Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = ClsSession.UserID
            .Parameters.Add(New SqlParameter("@Error", SqlDbType.VarChar, 200, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .ExecuteNonQuery()
            .Dispose()
        End With
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message & " infosp : " & MyCMD.Parameters("@Error saveHdr").Value)
        '    Return False
        'End Try
        Return True
    End Function

    Sub pointurut1()
        Dim c As DataGridView = dgvlist

        Try
            For x As Integer = 0 To c.RowCount - 1
                Dim cmd = New SqlCommand
                cmd.CommandText = "insert into RMPApp.. TblHubMstLavelBonus(RangeID,RupiahID,KodeMaster,Point,CreatedDate,CreatedBy) " &
                                     "values(@RangeID,@RupiahID,@KodeMaster,@Point,Getdate(),@CreatedBy)"

                cmd.Parameters.Add("@KodeMaster", SqlDbType.VarChar).Value = txtID.Text
                cmd.Parameters.Add("@RangeID", SqlDbType.Int).Value = dgvlist.Item("RangeID", x).Value
                cmd.Parameters.Add("@Point", SqlDbType.Decimal).Value = dgvlist.Item(11, x).Value
                cmd.Parameters.Add("@RupiahID", SqlDbType.Decimal).Value = 1
                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = ClsSession.UserID
                cmd.Connection = DB.OpenConnection(StrConnRMPApp)
                cmd.ExecuteNonQuery()
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
    Sub pointurut2()
        Dim c As DataGridView = dgvlist

        Try
            For x As Integer = 0 To c.RowCount - 1
                Dim cmd = New SqlCommand
                cmd.CommandText = "insert into RMPApp.. TblHubMstLavelBonus(RangeID,RupiahID,KodeMaster,Point,CreatedDate,CreatedBy) " &
                                     "values(@RangeID,@RupiahID,@KodeMaster,@Point,Getdate(),@CreatedBy)"


                cmd.Parameters.Add("@KodeMaster", SqlDbType.VarChar).Value = txtID.Text
                cmd.Parameters.Add("@RangeID", SqlDbType.Int).Value = dgvlist.Item("RangeID", x).Value
                cmd.Parameters.Add("@Point", SqlDbType.Decimal).Value = dgvlist.Item(12, x).Value
                cmd.Parameters.Add("@RupiahID", SqlDbType.Decimal).Value = 2
                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = ClsSession.UserID
                cmd.Connection = DB.OpenConnection(StrConnRMPApp)
                cmd.ExecuteNonQuery()
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
    Sub pointurut3()
        Dim c As DataGridView = dgvlist

        Try
            For x As Integer = 0 To c.RowCount - 1
                Dim cmd = New SqlCommand
                cmd.CommandText = "insert into RMPApp.. TblHubMstLavelBonus(RangeID,RupiahID,KodeMaster,Point,CreatedDate,CreatedBy) " &
                                     "values(@RangeID,@RupiahID,@KodeMaster,@Point,Getdate(),@CreatedBy)"


                cmd.Parameters.Add("@KodeMaster", SqlDbType.VarChar).Value = txtID.Text
                cmd.Parameters.Add("@RangeID", SqlDbType.Int).Value = dgvlist.Item("RangeID", x).Value
                cmd.Parameters.Add("@Point", SqlDbType.Decimal).Value = dgvlist.Item(13, x).Value
                cmd.Parameters.Add("@RupiahID", SqlDbType.Decimal).Value = 3
                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = ClsSession.UserID
                cmd.Connection = DB.OpenConnection(StrConnRMPApp)
                cmd.ExecuteNonQuery()
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
    Sub pointurut4()
        Dim c As DataGridView = dgvlist

        Try
            For x As Integer = 0 To c.RowCount - 1
                Dim cmd = New SqlCommand
                cmd.CommandText = "insert into RMPApp.. TblHubMstLavelBonus(RangeID,RupiahID,KodeMaster,Point,CreatedDate,CreatedBy) " &
                                     "values(@RangeID,@RupiahID,@KodeMaster,@Point,Getdate(),@CreatedBy)"


                cmd.Parameters.Add("@KodeMaster", SqlDbType.VarChar).Value = txtID.Text
                cmd.Parameters.Add("@RangeID", SqlDbType.Int).Value = dgvlist.Item("RangeID", x).Value
                cmd.Parameters.Add("@Point", SqlDbType.Decimal).Value = dgvlist.Item(14, x).Value
                cmd.Parameters.Add("@RupiahID", SqlDbType.Decimal).Value = 4
                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = ClsSession.UserID
                cmd.Connection = DB.OpenConnection(StrConnRMPApp)
                cmd.ExecuteNonQuery()
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
    Sub pointurut5()
        Dim c As DataGridView = dgvlist

        Try
            For x As Integer = 0 To c.RowCount - 1
                Dim cmd = New SqlCommand
                cmd.CommandText = "insert into RMPApp.. TblHubMstLavelBonus(RangeID,RupiahID,KodeMaster,Point,CreatedDate,CreatedBy) " &
                                     "values(@RangeID,@RupiahID,@KodeMaster,@Point,Getdate(),@CreatedBy)"


                cmd.Parameters.Add("@KodeMaster", SqlDbType.VarChar).Value = txtID.Text
                cmd.Parameters.Add("@RangeID", SqlDbType.Int).Value = dgvlist.Item("RangeID", x).Value
                cmd.Parameters.Add("@Point", SqlDbType.Decimal).Value = dgvlist.Item(15, x).Value
                cmd.Parameters.Add("@RupiahID", SqlDbType.Decimal).Value = 5
                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = ClsSession.UserID
                cmd.Connection = DB.OpenConnection(StrConnRMPApp)
                cmd.ExecuteNonQuery()
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub
    Sub pointurut6()
        Dim c As DataGridView = dgvlist

        Try
            For x As Integer = 0 To c.RowCount - 1
                Dim cmd = New SqlCommand
                cmd.CommandText = "insert into RMPApp.. TblHubMstLavelBonus(RangeID,RupiahID,KodeMaster,Point,CreatedDate,CreatedBy) " &
                                     "values(@RangeID,@RupiahID,@KodeMaster,@Point,Getdate(),@CreatedBy)"



                cmd.Parameters.Add("@KodeMaster", SqlDbType.VarChar).Value = txtID.Text
                cmd.Parameters.Add("@RangeID", SqlDbType.Int).Value = dgvlist.Item("RangeID", x).Value
                cmd.Parameters.Add("@Point", SqlDbType.Decimal).Value = dgvlist.Item(16, x).Value
                cmd.Parameters.Add("@RupiahID", SqlDbType.Decimal).Value = 6
                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = ClsSession.UserID
                cmd.Connection = DB.OpenConnection(StrConnRMPApp)
                cmd.ExecuteNonQuery()
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        'lblInfo.Text = Bergerak
        'Teks = Microsoft.VisualBasic.Right(Teks, Len(Teks) - 1) & Microsoft.VisualBasic.Left(Teks, 1)
        'lblInfo.Text = Teks
    End Sub

    Private Sub NoNota()
        Try
            ' If perintah = "Add" Then
            Dim connb As New SqlConnection(StrConnRMPApp)
            connb.Open()
            Dim NoReff As String
            Dim sql As String
            'Dim tabel As String

            sql = "Select Top 1 HeaderID From  RMPApp..TblMstLavelBonusHdr  order by HeaderID Desc "
            'sql = sql & " And Year(TglInvoice)=" & Year(dtinvoice.Value) & " And Month(TglInvoice)=" & Month(dtinvoice.Value) & " "
            ' sql = sql & " Order By NoTrans Desc "
            Dim cmd2 As New SqlClient.SqlCommand(sql, connb)
            Dim reader As SqlClient.SqlDataReader
            reader = cmd2.ExecuteReader
            If reader.HasRows Then
                Do While reader.Read
                    NoReff = Mid("000", 1, 3 - (Val(Trim(reader.Item(0).ToString)) + 1).ToString.Length) + (Val(Trim(reader.Item(0).ToString)) + 1).ToString
                    txtID.Text = NoReff & "/" & Format(DtPeriode.Value, "MM") & "/" & Format(DtPeriode.Value, "yyyy")
                Loop
            Else
                txtID.Text = "001" & "/" & Format(DtPeriode.Value, "MM") & "/" & Format(DtPeriode.Value, "yyyy")
            End If
            connb.Close()
            ' End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Default
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Call ClearData()
        Perintah = ""

    End Sub

    Sub ClearData()

        btnAdd.Enabled = True
        btnSave.Enabled = False
        btnEdit.Enabled = False
        btnFind.Enabled = True
        btnCancel.Enabled = True
        'fg.Rows.Clear()
        txtID.Text = ""
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Perintah = "Edit"

        btnAdd.Enabled = False
        btnSave.Enabled = True
        btnEdit.Enabled = False
        btnCancel.Enabled = True
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnFind_Click_1(sender As Object, e As EventArgs) Handles btnFind.Click
        'FrmMstLavelBonusFind.Show()
    End Sub


    Public Sub ListLavel()
        Dim y As Integer
        Dim Cmd As New SqlCommand

        Dim sql As String
        Dim Periode As String



        Periode = CDate(DtPeriode.Value)

        sql = "select *  FROM RMPApp..TblMstRange where KodeMaster=(select top(1) KodeMaster from RMPApp..TblMstRange where CONVERT(DATETIME, CONVERT(VARCHAR, CreatedDate, 103), 103) <=CONVERT(DATETIME, '" & CDate(DtPeriode.Value) & "', 103) order by RangeID desc)  ORDER BY RangeID ASC"
        Cmd.CommandText = sql
        Cmd.Connection = DB.OpenConnection(StrConnAccounting)
        Dim qrd2 As SqlDataReader = Cmd.ExecuteReader()

        dgvlist.Rows.Clear()
        y = 0
        If qrd2.HasRows Then

            Do While qrd2.Read()
                dgvlist.Rows.Add()
                dgvlist.Item(0, y).Value = qrd2("RangeID")
                dgvlist.Item(1, y).Value = qrd2("Lavel")
                dgvlist.Item(2, y).Value = qrd2("RangeString")
                dgvlist.Item(3, y).Value = qrd2("RangeMin")
                dgvlist.Item(4, y).Value = qrd2("RangeMax")

                y = y + 1

            Loop
        End If

    End Sub
    Public Sub HEADERADD()

        Dim x As Integer

        Dim conny As New SqlConnection(StrConnAccounting)
        Dim col As New DataGridViewTextBoxColumn
        Dim sqlx As String

        conny.Open()
        sqlx = "Select * from RMPApp..TblMstLavelBonusRupiah where KodeMaster=(select top(1) KodeMaster from  RMPApp..TblMstLavelBonusRupiah where (CONVERT(DATETIME, CONVERT(VARCHAR, CreatedDate, 103), 103) <=CONVERT(DATETIME, '" & CDate(DtPeriode.Value) & "', 103)) order by RupiahID desc)  ORDER BY RupiahID ASC "
        Dim cmdselect As New SqlCommand(sqlx, conny)
        RD = cmdselect.ExecuteReader()
        x = 11
        dgvlist.ColumnCount = 11
        If RD.HasRows Then

            Do While RD.Read
                dgvlist.Columns.Add(RD("RupiahID"), RD("LevelRupiah1"))
                Me.dgvlist.Columns(x).DefaultCellStyle.Format = "#,##0"
                dgvlist.Columns(x).DefaultCellStyle.Format = "n0"
                dgvlist.Columns(x).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvlist.Columns(x).Width = 100


                x = x + 1
            Loop
        End If

        Exit Sub
        conny.Close()
    End Sub
    Private Function SimpanDataUpdate1(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal i As Integer) As Boolean
        Dim MyCMD As New SqlCommand
        SimpanDataUpdate1 = False
        With MyCMD
            .Connection = Conn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RMPApp..spUpdateMstLavelBonusPengawas"
            .Transaction = Trans
            .Parameters.Add("@Point", SqlDbType.Decimal).Value = dgvlist.Item(11, i).Value
            .Parameters.Add("@DetailId", SqlDbType.Int).Value = dgvlist.Item("detailid1", i).Value
            .Parameters.Add("@UpdateBy", SqlDbType.VarChar).Value = ClsSession.UserID
            .Parameters.Add(New SqlParameter("@Error", SqlDbType.VarChar, 200, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .ExecuteNonQuery()
            .Dispose()
        End With
        Return True
    End Function
    Private Function SimpanDataUpdate2(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal i As Integer) As Boolean
        Dim MyCMD As New SqlCommand
        SimpanDataUpdate2 = False
        With MyCMD
            .Connection = Conn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RMPApp..spUpdateMstLavelBonusPengawas"
            .Transaction = Trans
            .Parameters.Add("@Point", SqlDbType.Decimal).Value = dgvlist.Item(12, i).Value
            .Parameters.Add("@DetailId", SqlDbType.Int).Value = dgvlist.Item("detailid2", i).Value
            .Parameters.Add("@UpdateBy", SqlDbType.VarChar).Value = ClsSession.UserID
            .Parameters.Add(New SqlParameter("@Error", SqlDbType.VarChar, 200, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .ExecuteNonQuery()
            .Dispose()
        End With
        Return True
    End Function
    Private Function SimpanDataUpdate3(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal i As Integer) As Boolean
        Dim MyCMD As New SqlCommand
        SimpanDataUpdate3 = False
        With MyCMD
            .Connection = Conn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RMPApp..spUpdateMstLavelBonusPengawas"
            .Transaction = Trans
            .Parameters.Add("@Point", SqlDbType.Decimal).Value = dgvlist.Item(13, i).Value
            .Parameters.Add("@DetailId", SqlDbType.Int).Value = dgvlist.Item("detailid3", i).Value
            .Parameters.Add("@UpdateBy", SqlDbType.VarChar).Value = ClsSession.UserID
            .Parameters.Add(New SqlParameter("@Error", SqlDbType.VarChar, 200, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .ExecuteNonQuery()
            .Dispose()
        End With
        Return True
    End Function
    Private Function SimpanDataUpdate4(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal i As Integer) As Boolean
        Dim MyCMD As New SqlCommand
        SimpanDataUpdate4 = False
        With MyCMD
            .Connection = Conn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RMPApp..spUpdateMstLavelBonusPengawas"
            .Transaction = Trans
            .Parameters.Add("@Point", SqlDbType.Decimal).Value = dgvlist.Item(14, i).Value
            .Parameters.Add("@DetailId", SqlDbType.Int).Value = dgvlist.Item("detailid4", i).Value
            .Parameters.Add("@UpdateBy", SqlDbType.VarChar).Value = ClsSession.UserID
            .Parameters.Add(New SqlParameter("@Error", SqlDbType.VarChar, 200, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .ExecuteNonQuery()
            .Dispose()
        End With
        Return True
    End Function
    Private Function SimpanDataUpdate5(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal i As Integer) As Boolean
        Dim MyCMD As New SqlCommand
        SimpanDataUpdate5 = False
        With MyCMD
            .Connection = Conn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RMPApp..spUpdateMstLavelBonusPengawas"
            .Transaction = Trans
            .Parameters.Add("@Point", SqlDbType.Decimal).Value = dgvlist.Item(15, i).Value
            .Parameters.Add("@DetailId", SqlDbType.Int).Value = dgvlist.Item("detailid5", i).Value
            .Parameters.Add("@UpdateBy", SqlDbType.VarChar).Value = ClsSession.UserID
            .Parameters.Add(New SqlParameter("@Error", SqlDbType.VarChar, 200, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .ExecuteNonQuery()
            .Dispose()
        End With
        Return True
    End Function
    Private Function SimpanDataUpdate6(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal i As Integer) As Boolean
        Dim MyCMD As New SqlCommand
        SimpanDataUpdate6 = False
        With MyCMD
            .Connection = Conn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RMPApp..spUpdateMstLavelBonusPengawas"
            .Transaction = Trans
            .Parameters.Add("@Point", SqlDbType.Decimal).Value = dgvlist.Item(16, i).Value
            .Parameters.Add("@DetailId", SqlDbType.Int).Value = dgvlist.Item("detailid6", i).Value
            .Parameters.Add("@UpdateBy", SqlDbType.VarChar).Value = ClsSession.UserID
            .Parameters.Add(New SqlParameter("@Error", SqlDbType.VarChar, 200, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .ExecuteNonQuery()
            .Dispose()
        End With
        Return True
    End Function
    Private Sub DtPeriode_ValueChanged(sender As Object, e As EventArgs) Handles DtPeriode.ValueChanged
        'Call ListLavel()
    End Sub

    '$$Private Sub DtPeriode_Validated(sender As Object, e As EventArgs) Handles DtPeriode.Validated
    'Call ListLavel()
    '    HEADERADD()
    'End Sub
    Sub ShowDataRupiah1()
        Dim SQL As String, i As Integer

        SQL = "select Point,DetailId from VwMstLavelBonusPengawas where RupiahID =1 and CreatedDate=(Select Max(CreatedDate) from VwMstLavelBonusPengawas where RupiahID=1)"

        Using koneksi As New SqlCommand(SQL, DB.OpenConnection(StrConnRMPApp))
            Using DR = koneksi.ExecuteReader()
                If DR.HasRows Then
                    While DR.Read
                        With dgvlist
                            .Item(11, i).Value = DR!Point
                            .Item("detailid1", i).Value = DR!DetailId
                        End With
                        i += 1
                    End While
                End If
                DR.Close()
            End Using
        End Using
        DB.CloseConnection()
    End Sub
    Sub ShowDataRupiah2()
        Dim SQL As String, i As Integer

        SQL = "select Point,DetailId from VwMstLavelBonusPengawas where RupiahID =2 and CreatedDate=(Select Max(CreatedDate) from VwMstLavelBonusPengawas where RupiahID=2)"

        Using koneksi As New SqlCommand(SQL, DB.OpenConnection(StrConnRMPApp))
            Using DR = koneksi.ExecuteReader()
                If DR.HasRows Then
                    While DR.Read
                        With dgvlist
                            .Item(12, i).Value = DR!Point
                            .Item("detailid2", i).Value = DR!DetailId
                        End With
                        i += 1
                    End While
                End If
                DR.Close()
            End Using
        End Using
        DB.CloseConnection()
    End Sub

    Sub ShowDataRupiah3()
        Dim SQL As String, i As Integer

        SQL = "select Point,DetailId from VwMstLavelBonusPengawas where RupiahID =3 and CreatedDate=(Select Max(CreatedDate) from VwMstLavelBonusPengawas where RupiahID=3)"

        Using koneksi As New SqlCommand(SQL, DB.OpenConnection(StrConnRMPApp))
            Using DR = koneksi.ExecuteReader()
                If DR.HasRows Then
                    While DR.Read
                        With dgvlist
                            .Item(13, i).Value = DR!Point
                            .Item("detailid3", i).Value = DR!DetailId
                        End With
                        i += 1
                    End While
                End If
                DR.Close()
            End Using
        End Using
        DB.CloseConnection()
    End Sub
    Sub ShowDataRupiah4()
        Dim SQL As String, i As Integer

        SQL = "select Point,DetailId from VwMstLavelBonusPengawas where RupiahID =4 and CreatedDate=(Select Max(CreatedDate) from VwMstLavelBonusPengawas where RupiahID=4)"

        Using koneksi As New SqlCommand(SQL, DB.OpenConnection(StrConnRMPApp))
            Using DR = koneksi.ExecuteReader()
                If DR.HasRows Then
                    While DR.Read
                        With dgvlist
                            .Item(14, i).Value = DR!Point
                            .Item("detailid4", i).Value = DR!DetailId
                        End With
                        i += 1
                    End While
                End If
                DR.Close()
            End Using
        End Using
        DB.CloseConnection()
    End Sub

    Sub ShowDataRupiah5()
        Dim SQL As String, i As Integer

        SQL = "select Point,DetailId from VwMstLavelBonusPengawas where RupiahID =5 and CreatedDate=(Select Max(CreatedDate) from VwMstLavelBonusPengawas where RupiahID=5)"

        Using koneksi As New SqlCommand(SQL, DB.OpenConnection(StrConnRMPApp))
            Using DR = koneksi.ExecuteReader()
                If DR.HasRows Then
                    While DR.Read
                        With dgvlist
                            .Item(15, i).Value = DR!Point
                            .Item("detailid5", i).Value = DR!DetailId
                        End With
                        i += 1
                    End While
                End If
                DR.Close()
            End Using
        End Using
        DB.CloseConnection()
    End Sub
    Sub ShowDataRupiah6()
        Dim SQL As String, i As Integer

        SQL = "select Point,DetailId from VwMstLavelBonusPengawas where RupiahID =6 and CreatedDate=(Select Max(CreatedDate) from VwMstLavelBonusPengawas where RupiahID=6)"

        Using koneksi As New SqlCommand(SQL, DB.OpenConnection(StrConnRMPApp))
            Using DR = koneksi.ExecuteReader()
                If DR.HasRows Then
                    While DR.Read
                        With dgvlist
                            .Item(16, i).Value = DR!Point
                            .Item("detailid6", i).Value = DR!DetailId
                        End With
                        i += 1
                    End While
                End If
                DR.Close()
            End Using
        End Using
        DB.CloseConnection()
    End Sub
End Class