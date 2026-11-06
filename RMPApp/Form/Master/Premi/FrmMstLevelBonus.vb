Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class FrmMstLevelBonus
    Public Qcmd As New SqlCommand
    Dim temp As VariantType
    Dim max As Integer
    Dim cmds As SqlCommand
    Dim txtkdsupplier As Object
    Dim nota As String
    Dim copycolumnindex As Integer
    Public perintah As String





    Private dtPenerimaanMasterHargaBahanBaku As DataTable = New DataTable()


    Dim koneksi = DB.OpenConnection(StrConnPSGRMP)

    Public Sub cmdENabled(ByVal flag As Boolean)
        BTNFIND.Enabled = flag
        btnAdd.Enabled = flag
        btnEdit.Enabled = flag
        btnsave.Enabled = Not flag
        btnCancel.Enabled = Not flag
        btnclose.Enabled = flag
    End Sub
    Private Sub controlenabled(ByVal flag As Boolean)
        dttgl.Enabled = flag
        dgvlist.Enabled = flag

    End Sub


    Private Sub loadtanggal()
        'If CDbl(Format(Now, "dd")) > 1 Then
        '    DateTimePicker1.Value = CDate(DateAdd("d", 1, CDate(Format(FrmMenuUtama.Periode, "dd/MM/yyyy"))))
        'End If
    End Sub

    Public Sub cleartxt()
        dttgl.Value = Now
        txtnotrans.Text = ""

    End Sub




    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        perintah = "Add"
        cleartxt()
        dgvlist.Rows.Clear()
        controlenabled(True)
        cmdENabled(False)
        dttgl.Enabled = True
        dttgl.Focus()
        loadtanggal()

    End Sub

    Private Sub FrmMstLevelBonus_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Public Sub ListLavel()
        'On Error GoTo a
        Dim y As Integer
        'Call Koneksi()
        Dim Cmd As New SqlCommand

        Dim sql As String
        Dim Periode As String
        '        If perintah = "Add" Then GoTo TAMBAH


        Periode = CDate(dttgl.Value)
        '        'Ifdgvlist.Rows.Count > 1 Then

        '        'End If

        '        '
        'TAMBAH:
        '        If perintah = "Add" Then
        sql = "select *  FROM RMPApp..tblMstLevelRange where no_lavel=(select top(1) No_Lavel from RMPApp..tblMstLevelRange where CONVERT(DATETIME, CONVERT(VARCHAR, tgl_lavel, 103), 103) <=CONVERT(DATETIME, '" & CDate(dttgl.Value) & "', 103) order by IDlavel desc)  ORDER BY IDLAVEL ASC"
        Cmd.CommandText = sql
        Cmd.Connection = DB.OpenConnection(StrConnAccounting)
        Dim qrd2 As SqlDataReader = Cmd.ExecuteReader()

        dgvlist.Rows.Clear()
        y = 0
        If qrd2.HasRows Then

            Do While qrd2.Read()
                dgvlist.Rows.Add()
                'dgvlist.Item(0, y).Value = y + 1
                dgvlist.Item(0, y).Value = qrd2("IDlavel")
                dgvlist.Item(1, y).Value = qrd2("Lavel")
                dgvlist.Item(2, y).Value = qrd2("Range")
                dgvlist.Item(3, y).Value = qrd2("Range_Min")
                dgvlist.Item(4, y).Value = qrd2("Range_Max")

                y = y + 1

            Loop
        End If
        'End If
        'a:
    End Sub

    Private Sub HEADERADD()

        Dim x As Integer

        Dim conny As New SqlConnection(StrConnAccounting)
        Dim col As New DataGridViewTextBoxColumn
        Dim sqlx As String

        conny.Open()
        sqlx = "Select * from RMPApp..tblMstLevelMatrixTon where no_lavel=(select top(1) No_Lavel from  RMPApp..tblMstLevelMatrixTon where (CONVERT(DATETIME, CONVERT(VARCHAR, tgl_lavel, 103), 103) <=CONVERT(DATETIME, '" & CDate(dttgl.Value) & "', 103)) order by  IDlavel desc)  ORDER BY IDLAVEL ASC "
        Dim cmdselect As New SqlCommand(sqlx, conny)
        RD = cmdselect.ExecuteReader()
        x = 5
        dgvlist.ColumnCount = 5
        'col = "0"
        If RD.HasRows Then

            Do While RD.Read

                'col.DataPropertyName = RD("IDLavel")
                'col.HeaderText = RD("Range")
                'col.Name = RD("IDLavel")
                'dgvlist.Columns.Add(x)
                dgvlist.Columns.Add(RD("IDLavel"), RD("Range"))

                Me.dgvlist.Columns(x).DefaultCellStyle.Format = "#,##0"
                dgvlist.Columns(x).DefaultCellStyle.Format = "n0"
                dgvlist.Columns(x).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvlist.Columns(x).Width = 100
                dgvlist.Columns(x).ValueType = GetType(Double)

                x = x + 1
            Loop
        End If

        Exit Sub
        conny.Close()
    End Sub


    Private Sub mstlavel()


        Dim x As Integer

        Dim conny As New SqlConnection(StrConnAccounting)
        Dim col As New DataGridViewTextBoxColumn
        Dim sqlx As String

        conny.Open()
        sqlx = "Select * from RMPApp..tblMstLevelMatrixTon where no_lavel=(select top(1) No_Lavel from  RMPApp..tblMstLevelMatrixTon where (CONVERT(DATETIME, CONVERT(VARCHAR, tgl_lavel, 103), 103) <=CONVERT(DATETIME, '" & CDate(dttgl.Value) & "', 103)) order by  IDlavel desc)  ORDER BY IDLAVEL ASC"
        Dim cmdselect As New SqlCommand(sqlx, conny)
        RD = cmdselect.ExecuteReader()
        x = 0
        'dgvlist.ColumnCount = 5

        If RD.HasRows Then

            Do While RD.Read
                With dgvmst
                    dgvmst.Rows.Add()
                    .Item("Range1", x).Value = RD!Range
                    .Item("RangeMin1", x).Value = RD!Range_Min
                    .Item("RangeMax1", x).Value = RD!Range_Max
                    .Item("IDlavelMatrix", x).Value = RD!IDlavel
                End With
                x = x + 1
            Loop
        End If

        Exit Sub
        conny.Close()
    End Sub





    Private Sub changedataadd()
        If perintah = "Add" Then
            'Call KodeHarga()
            HEADERADD()
            'ListSupplier()
            'MasterHargaAdd()

        End If
    End Sub

    Private Sub txtEdit_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Console.WriteLine("KeyPress " & e.KeyChar.ToString())
        'Test for numeric value or backspace in first column
        If dgvlist.CurrentCell.ColumnIndex = dgvlist.ColumnCount - 1 Then

            If IsNumeric(e.KeyChar.ToString()) _
            Or e.KeyChar = ChrW(Keys.Back) _
            Or e.KeyChar = "." Then
                Console.WriteLine("KeyPress number")
                e.Handled = False 'if numeric display 
            Else
                Console.WriteLine("Enter Numbers Only")
                e.Handled = True  'if non numeric don't display
            End If
        End If

        If dgvlist.CurrentCell.ColumnIndex = dgvlist.ColumnCount - 2 Then
            If IsNumeric(e.KeyChar.ToString()) _
            Or e.KeyChar = ChrW(Keys.Back) _
            Or e.KeyChar = "." Then
                Console.WriteLine("KeyPress number")
                e.Handled = False 'if numeric display 
            Else
                Console.WriteLine("Enter Numbers Only")
                e.Handled = True  'if non numeric don't display
            End If
        End If


    End Sub



    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Public Sub PasteFromClipboard(ByVal DataGrid As DataGridView)
        'Paste copied tab delimited cells (Excel) from clipboard to DataGridView
        Dim s As String = Clipboard.GetText() 'Get clipboard data as a string
        Dim lines() As String = Split(s, Environment.NewLine)
        Dim iRow As Integer = DataGrid.CurrentCell.RowIndex
        Dim iCol As Integer = DataGrid.CurrentCell.ColumnIndex
        Dim sCells() As String
        Dim oCell As DataGridViewCell
        Dim nlines As Integer = lines.Length
        Dim i As Integer = 0
        Dim j As Integer = 0

        For i = 1 To nlines
            If (iRow < DataGrid.RowCount And lines(i - 1).Length > 0) Then
                sCells = Split(lines(i - 1), vbTab)

                For j = 1 To sCells.Length
                    If (iCol + j - 1 < DataGrid.ColumnCount) Then
                        oCell = DataGrid(iCol + j - 1, iRow)
                        oCell.Value = Val(Convert.ChangeType(sCells(j - 1), oCell.ValueType))
                    Else
                        Exit For
                    End If
                Next
                iRow += 1
            Else
                Exit For
            End If
        Next
    End Sub



    Private Function SimpanDataHdr(ByVal Conn2 As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        SimpanDataHdr = False
        Dim cqd As New SqlCommand
        Dim MyCon As SqlConnection = Conn2
        Dim MyConTrans As SqlTransaction = Trans
        cqd.Connection = MyCon
        cqd.CommandType = CommandType.StoredProcedure
        cqd.CommandText = "RMPApp..spRMMstHargaBahanBakuHdr"
        cqd.Transaction = MyConTrans
        cqd.Parameters.Add("@RETURN_VALUE", SqlDbType.SmallInt).Direction = ParameterDirection.ReturnValue
        cqd.Parameters.Add("@Perintah", SqlDbType.VarChar, 20).Value = perintah
        cqd.Parameters.Add("@KodeHargaString", SqlDbType.VarChar, 35).Value = (txtnotrans.Text)
        cqd.Parameters.Add("@KodejenisBahanBaku", SqlDbType.Int).Value = 1
        'cqd.Parameters.Add("@AsalKelapa", SqlDbType.Int).Value = cmbGroupSup.SelectedValue
        'cqd.Parameters.Add("@Periode", SqlDbType.Date).Value = CDate(Format(DateTimePicker1.Value, "dd/MM/yyyy"))
        'cqd.Parameters.Add("@PeriodeString", SqlDbType.VarChar, 20).Value = CDate(Format(DateTimePicker1.Value, "dd/MM/yyyy"))
        'cqd.Parameters.Add("@MonthPeriode", SqlDbType.VarChar, 10).Value = CDate(Format(DateTimePicker1.Value, "MM/yyyy"))
        'cqd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = MDIMENU.txtid_user.Text
        'cqd.Parameters.Add("@LastUpdatedBy", SqlDbType.VarChar, 50).Value = MDIMENU.txtid_user.Text
        cqd.Parameters.Add(New SqlParameter("@Flag", SqlDbType.SmallInt, 5, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
        cqd.ExecuteNonQuery()
        If CInt(cqd.Parameters("@Flag").Value) = 0 Then
            cqd.Dispose()
            Exit Function
        End If
        Return True

    End Function

    Private Function SimpanDataHdrGrid(ByVal Conn2 As SqlConnection, ByVal Trans As SqlTransaction, ByVal grade As Integer) As Boolean
        SimpanDataHdrGrid = False
        Dim cqd As New SqlCommand
        Dim MyCon As SqlConnection = Conn2
        Dim MyConTrans As SqlTransaction = Trans
        cqd.Connection = MyCon
        cqd.CommandType = CommandType.StoredProcedure
        cqd.CommandText = "PSGRMP..spRMMstHargaBahanBakuGridHdr"
        cqd.Transaction = MyConTrans
        cqd.Parameters.Add("@RETURN_VALUE", SqlDbType.SmallInt).Direction = ParameterDirection.ReturnValue
        cqd.Parameters.Add("@Perintah", SqlDbType.VarChar, 20).Value = perintah
        cqd.Parameters.Add("@KodeGradeID", SqlDbType.Int).Value = 0
        cqd.Parameters.Add("@KodeGrade", SqlDbType.VarChar, 10).Value = dgvlist.Columns(grade).Name
        cqd.Parameters.Add("@Nama_Grade", SqlDbType.VarChar, 100).Value = dgvlist.Columns(grade).HeaderText
        cqd.Parameters.Add("@ID_BahanBaku", SqlDbType.Int).Value = 0
        cqd.Parameters.Add("@KodeHarga", SqlDbType.VarChar, 15).Value = Trim(txtkdsupplier.Text)
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

    Private Function SimpanDataDtl(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal kodeharga As String, ByVal kodesup As String, ByVal kodegrade As String, ByVal harga As Double,
                                       createdby As String, ByVal LastUpdatedBy As String) As Boolean
        Dim MyCMD As New SqlCommand
        Try
            With MyCMD
                .Connection = Conn
                .CommandType = CommandType.StoredProcedure
                .CommandText = "PSGRMP..spRMMstHargaBahanBakuDtl"
                .Transaction = Trans
                .Parameters.Add("@KodeHargaString", SqlDbType.VarChar).Value = kodeharga
                .Parameters.Add("@KodeSup", SqlDbType.VarChar).Value = kodesup
                .Parameters.Add("@KodeGrade", SqlDbType.VarChar).Value = kodegrade
                .Parameters.Add("@Harga", SqlDbType.Decimal, 18, 2).Value = harga
                .Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = createdby
                .Parameters.Add("@LastUpdatedBy", SqlDbType.VarChar).Value = LastUpdatedBy
                .Parameters.Add(New SqlParameter("@Error", SqlDbType.VarChar, 200, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
                .ExecuteNonQuery()
                .Dispose()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message & " infosp :  " & MyCMD.Parameters("@Error").Value)
            Return False
        End Try
        Return True
    End Function

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim Koneksi As SqlConnection = DB.OpenConnection(StrConnAccounting)
        Dim Transaksi As SqlTransaction

        Transaksi = Koneksi.BeginTransaction
        Me.Cursor = Cursors.WaitCursor
        Try



            If SimpanDataHdr(Koneksi, Transaksi) = False Then
                Transaksi.Rollback()
                Me.Cursor = Cursors.Default
                MessageBox.Show("Simpan data gagal!", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            With dgvlist
                For grade = 4 To dgvlist.ColumnCount - 1
                    If SimpanDataHdrGrid(Koneksi, Transaksi, grade) = False Then
                        Transaksi.Rollback()
                        Me.Cursor = Cursors.Default
                        MessageBox.Show("Simpan data gagal!", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                Next grade



                For grade = 4 To .ColumnCount - 1
                    For i = 0 To .RowCount - 1
                        If SimpanDataDtl(Koneksi, Transaksi, txtkdsupplier.Text, .Item(1, i).Value,
                                           .Columns(grade).Name,
                                             If(IsDBNull((.Item(grade, i).Value)) = True, 0, Val(.Item(grade, i).Value)),
                                             ClsSession.UserID,
                                             ClsSession.UserID) = False Then
                            Transaksi.Rollback()
                            MsgBox("Simpan Master Harga Bahan Baku (Kg) Gagal", vbExclamation, "Save Data - " & AT)
                            Exit Try
                        End If
                    Next
                Next grade
            End With
            Transaksi.Commit()
            Me.Cursor = Cursors.Default
            MessageBox.Show("Simpan data berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)


            Call cleartxt()
            perintah = ""
            Call cmdENabled(True)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Transaksi.Rollback()
            Koneksi.Close()
            Me.Cursor = Cursors.Default
        Finally
            Koneksi.Close()
            Me.Cursor = Cursors.Default
        End Try
        Call cleartxt()
        Call cmdENabled(True)
    End Sub


    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Call cleartxt()
        cmdENabled(True)
    End Sub

    Private Sub btnfind_Click(sender As Object, e As EventArgs) Handles BTNFIND.Click
        perintah = "Find"

    End Sub

    Public Sub HEADERfind(KodeHarga As String)

        Dim x As Integer

        Dim conny As New SqlConnection(StrConnPSGRMP)
        Dim col As New DataGridViewTextBoxColumn
        Dim sqlx As String

        conny.Open()
        sqlx = "Select * from vwRMMstHargaBahanBakuGradeHdr where KodeHarga='" & KodeHarga & "' "
        Dim cmdselect As New SqlCommand(sqlx, conny)
        RD = cmdselect.ExecuteReader()
        x = 4
        dgvlist.ColumnCount = 4

        If RD.HasRows Then

            Do While RD.Read

                dgvlist.Columns.Add(RD("KodeGrade"), RD("Nama_Grade"))
                Me.dgvlist.Columns(x).DefaultCellStyle.Format = "#,##0"
                dgvlist.Columns(x).DefaultCellStyle.Format = "n0"
                dgvlist.Columns(x).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvlist.Columns(x).Width = 220
                dgvlist.Columns(x).ValueType = GetType(Double)
                x = x + 1
            Loop
        End If
        Exit Sub
        conny.Close()
    End Sub



    'Private Sub btnedit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
    '    perintah = ""
    '    If txtkodeharga.Text = "" Then
    '        MessageBox.Show("Tidak ada data yang di Edit, Klik Find untuk Edit data", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Exit Sub
    '    End If
    '    cmdENabled(False)
    '    perintah = "Edit"
    '    txtkodeharga.Enabled = False
    '    controlenabled(True)
    'End Sub


    'Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    '    changedataadd()
    'End Sub




    Private Sub dttgl_ValueChanged(sender As Object, e As EventArgs) Handles dttgl.ValueChanged
        mstlavel()
        HEADERADD()
        ListLavel()
        ListLavel()
    End Sub

    Private Sub dgvmst_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvmst.CellContentClick

    End Sub
End Class