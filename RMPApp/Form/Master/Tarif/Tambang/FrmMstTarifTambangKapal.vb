Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Windows.Controls
Imports C1.C1Preview.C1HyperlinkInfo
Imports C1.Win.C1FlexGrid

Public Class FrmMstTarifTambangKapal
    Public Qcmd As New SqlCommand
    Dim temp As VariantType
    Dim max As Integer
    Dim cmds As SqlCommand
    Dim txtkdsupplier As Object
    Dim kodehargastring As String
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
    End Sub
    Private Sub controlenabled(ByVal flag As Boolean)
        dttgl.Enabled = flag
        dgvlist.Enabled = flag
        txtnotrans.Enabled = flag
    End Sub
    Public Sub cleartxt()
        dttgl.Value = Now
        txtnotrans.Text = ""
        perintah = ""
        dgvlist.Rows.Clear()
    End Sub
    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        cleartxt()
        perintah = "Add"

        dgvlist.Rows.Clear()
        controlenabled(True)
        cmdENabled(False)
        dttgl.Enabled = True
        dttgl.Focus()
        'HEADERADD()
    End Sub
    Public Sub ListLavel(idkapsitas As Integer)
        Dim y As Integer
        Dim Cmd As New SqlCommand
        Dim sql As String
        Dim Periode As String
        Periode = CDate(dttgl.Value)

        sql = "select *  FROM [RMPApp].[dbo].[tblMstKapal]  where kap >= (SELECT Range1 FROM [RMPApp].[dbo].[tblRMMstKapasitasKapal] " &
              " WHERE IDKapasitas='" & idkapsitas & "' )  and   kap <= (SELECT Range2 FROM [RMPApp].[dbo].[tblRMMstKapasitasKapal] " &
              " WHERE IDKapasitas='" & idkapsitas & "' ) And PONTIANAK='True'  "
        'And PONTIANAK='True'
        Cmd.CommandText = sql
        Cmd.Connection = DB.OpenConnection(StrConnAccounting)
        Dim qrd2 As SqlDataReader = Cmd.ExecuteReader()

        dgvlist.Rows.Clear()
        y = 0
        If qrd2.HasRows Then

            Do While qrd2.Read()
                dgvlist.Rows.Add()
                dgvlist.Item(0, y).Value = qrd2("KapalID")
                dgvlist.Item(1, y).Value = qrd2("KapalName")
                dgvlist.Item(2, y).Value = qrd2("Kap")

                y = y + 1
            Loop
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
        Dim asal As String
        SimpanDataHdr = False
        Dim cqd As New SqlCommand
        Dim MyCon As SqlConnection = Conn2
        Dim MyConTrans As SqlTransaction = Trans
        cqd.Connection = MyCon
        cqd.CommandType = CommandType.StoredProcedure
        cqd.CommandText = "RMPApp..spRMMstHargaTambangHdr"
        cqd.Transaction = MyConTrans
        cqd.Parameters.Add("@RETURN_VALUE", SqlDbType.SmallInt).Direction = ParameterDirection.ReturnValue
        cqd.Parameters.Add("@Perintah", SqlDbType.VarChar, 20).Value = perintah
        cqd.Parameters.Add(New SqlParameter("@KodeHargaString", SqlDbType.VarChar, 20, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
        cqd.Parameters.Add("@KodeHargaString2", SqlDbType.VarChar, 35).Value = (txtnotrans.Text)
        cqd.Parameters.Add("@Kapasitas", SqlDbType.VarChar).Value = cmbKapasitas.SelectedValue.ToString
        cqd.Parameters.Add("@Periode", SqlDbType.Date).Value = CDate(Format(dttgl.Value, "dd/MM/yyyy"))
        cqd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
        cqd.Parameters.Add("@LastUpdatedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
        cqd.Parameters.Add(New SqlParameter("@Flag", SqlDbType.SmallInt, 5, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
        cqd.ExecuteNonQuery()
        If perintah = "Add" Then
            kodehargastring = cqd.Parameters("@KodeHargaString").Value
        Else
            kodehargastring = cqd.Parameters("@KodeHargaString2").Value
        End If
        If CInt(cqd.Parameters("@Flag").Value) = 0 Then
            cqd.Dispose()
            Exit Function
        End If
        Return True
    End Function

    Private Function SimpanDataDtl(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal kodeharga As String, ByVal idkapal As String, ByVal kapal As String, ByVal kapasitas As String, ByVal harga As Double,
                                       createdby As String, ByVal LastUpdatedBy As String) As Boolean
        Dim MyCMD As New SqlCommand
        Try

            With MyCMD
                .Connection = Conn
                .CommandType = CommandType.StoredProcedure
                .CommandText = "RMPApp..spRMMstHargaTambangDtl"
                .Transaction = Trans
                .Parameters.Add("@KodeHargaString", SqlDbType.VarChar).Value = kodeharga
                .Parameters.Add("@IDKapal", SqlDbType.Int).Value = idkapal
                .Parameters.Add("@Kapal", SqlDbType.VarChar).Value = kapal
                .Parameters.Add("@Kapasitas", SqlDbType.VarChar).Value = kapasitas
                .Parameters.Add("@Harga", SqlDbType.Decimal, 18, 2).Value = harga
                .Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = createdby
                .Parameters.Add("@LastUpdatedBy", SqlDbType.VarChar).Value = LastUpdatedBy
                .Parameters.Add(New SqlParameter("@Flag", SqlDbType.SmallInt, 5, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
                .ExecuteNonQuery()
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message & " infosp :  " & MyCMD.Parameters("@Error").Value)
            Return False
        End Try
        Return True
    End Function

    Public Sub ShowdataDTL(NOTRANS As String)
        Dim sql As String
        Dim i As Integer = 0
        Dim x As Integer = 0

        sql = "Select * FROM RMPApp..tblRMMstHargaTambangKapalDtl WHERE KodeHargaString='" & NOTRANS & "'  "
        Using koneksi As New SqlCommand(sql,DB.OpenConnection(StrConnRMPApp))
            Using DR = koneksi.ExecuteReader
                dgvlist.RowCount = 0
                If DR.HasRows Then
                    Do While DR.Read
                        With dgvlist
                            .Rows.Add()

                            .Item("IDKapal", i).Value = DR!IDKapal
                            .Item("Kapal", i).Value = DR!Kapal
                            .Item("Kapasitas", i).Value = DR!Kapasitas
                            .Item("Harga", i).Value = DR!Harga

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
                Exit Try
            End If

            With dgvlist
                For i = 0 To .RowCount - 1
                    If SimpanDataDtl(Koneksi, Transaksi, kodehargastring,
                                     .Item("IDKapal", i).Value, .Item("Kapal", i).Value, .Item("Kapasitas", i).Value,
                                     .Item("Harga", i).Value, ClsSession.UserID,
                                      ClsSession.UserID) = False Then


                        Transaksi.Rollback()
                        MsgBox("Simpan Master Harga Bahan Baku (Kg) Gagal", vbExclamation, "Save Data - " & AT)
                        Exit Try
                    End If
                Next

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
    End Sub
    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Call cleartxt()
        cmdENabled(True)
    End Sub
    Private Sub btnfind_Click(sender As Object, e As EventArgs) Handles BTNFIND.Click
        perintah = "Find"
        FrmMstTarifTambangKapalDialog.Show()
    End Sub

    Private Sub FrmMstLevelBonus_Load(sender As Object, e As EventArgs) Handles Me.Load
        Combo.CboMstKapasitasKapal(cmbKapasitas)
        controlenabled(False)
    End Sub
    Private Sub FrmMasterHargaTambangKapal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Combo.CboMstKapasitasKapal(cmbKapasitas)
    End Sub
    Private Sub CopyCells()
        Clipboard.SetDataObject(dgvlist.GetClipboardContent)
    End Sub
    Private Sub PasteCells()
        Dim s = Clipboard.GetText
        Dim ci = dgvlist.CurrentCell.ColumnIndex
        Dim ri = dgvlist.CurrentCell.RowIndex
        Dim colCount = dgvlist.Columns.Count
        Dim rowCount = dgvlist.Rows.Count

        For Each r In s.Split({ControlChars.CrLf}, StringSplitOptions.None)
            Dim Cell = ci
            For Each c In r.Split({ControlChars.Tab}, StringSplitOptions.None)
                If Cell >= colCount Then Exit For
                dgvlist(Cell, ri).Value = c
                Cell += 1
            Next
            ri += 1
            If ri >= rowCount Then Exit For
        Next
    End Sub
    Private Sub dgvlist_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvlist.KeyDown
        Select Case e.KeyCode
            Case Keys.C
                CopyCells()
                e.Handled = True
            Case Keys.V
                PasteCells()
                e.Handled = True
        End Select

    End Sub
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        perintah = ""

        If txtnotrans.Text = "" Then
            MessageBox.Show("Tidak ada data yang di Edit, Klik data terlebih dahulu", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        cmdENabled(False)
        perintah = "Edit"
        btnAdd.Enabled = False
        btnEdit.Enabled = True
        btnsave.Enabled = True
        txtnotrans.Enabled = False
        controlenabled(True)
    End Sub

    Private Sub cmbKapasitas_Validating(sender As Object, e As CancelEventArgs) Handles cmbKapasitas.Validating
        If IsNothing(cmbKapasitas.SelectedValue) = False Then
            ListLavel(cmbKapasitas.SelectedValue.ToString)
        End If
    End Sub

    Private Sub cmbKapasitas_Validated(sender As Object, e As EventArgs) Handles cmbKapasitas.Validated
        If IsNothing(cmbKapasitas.SelectedValue) = False Then
            ListLavel(cmbKapasitas.SelectedValue.ToString)
        End If
    End Sub

    Private Sub cmbKapasitas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbKapasitas.SelectedIndexChanged

    End Sub
End Class