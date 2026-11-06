Imports System.Data.SqlClient
Imports System.Globalization

Public Class FrmTrnPembelianNonPancang

    ' ─── State ───────────────────────────────────────────────────────

    ' ─── Form Helpers ────────────────────────────────────────────────
    Private Sub ClearForm()
        txtNoPembelian.Clear()
        txtNoNPBB.Clear()
        txtNoBTB.Clear()
        txtRemark.Clear()
        cboSupplier.SelectedIndex = -1
        dtpTanggalPembelian.Value = Date.Today
        fg.Rows.Count = 1
    End Sub

    Private Sub SetFormState(isEditing As Boolean, hasSelection As Boolean)
        txtRemark.Enabled = isEditing
        dtpTanggalPembelian.Enabled = isEditing
        cboSupplier.Enabled = isEditing

        btnAdd.Enabled = Not isEditing
        btnDelete.Enabled = Not isEditing AndAlso hasSelection
        btnSave.Enabled = isEditing
        btnCancel.Enabled = isEditing
    End Sub

    ' ─── Load ────────────────────────────────────────────────────────
    Private Sub FrmTrnPembelianNonPancang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Modul_RMP.Combo.SetSupplierCustomerAfiliasi(cboSupplier, 1)
        cboSupplier.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboSupplier.AutoCompleteSource = AutoCompleteSource.ListItems

        Call ClsFlexGrid.ApplyStyle(fg)
        Call ClsFlexGrid.AttachLiveNumber(fg, 0, "Qnty", "UnitPrice", "QntySusut", "QntyBertambah")
        Call ClsFlexGrid.SetEditableColumns(fg, "Qnty", "UnitPrice", "QntySusut", "QntyBertambah", "btnTambah", "btnDelete", "btnChose", "Remark")

        SetFormState(isEditing:=False, hasSelection:=False)
    End Sub

    ' ─── btnAdd ──────────────────────────────────────────────────────
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ClearForm()

        fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" &
                   vbTab & 0 & vbTab & 0 & vbTab & 0 & vbTab & 0 & vbTab & 0 & vbTab & 0)

        For i = 1 To fg.Rows.Count - 1
            fg(i, "No") = i
        Next

        SetFormState(isEditing:=True, hasSelection:=False)
        cboSupplier.Focus()
    End Sub

    ' ─── btnDelete ───────────────────────────────────────────────────
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If txtNoPembelian.Text = "" Then
            MessageBox.Show("Pilih data terlebih dahulu.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If MessageBox.Show("Yakin hapus data " & txtNoPembelian.Text & "?", "Konfirmasi",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Return

        Dim fr As New FrmKeteranganDelete
        Dim keteranganDelete As String

        If fr.ShowDialog() = DialogResult.OK Then
            keteranganDelete = fr.ResultText
        Else
            Return  ' user cancel
        End If

        If keteranganDelete = "" Then
            MessageBox.Show("Delete Data Gagal.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        SpHdrDelete(keteranganDelete)
    End Sub

    ' ─── btnSave ─────────────────────────────────────────────────────
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Me.Cursor = Cursors.WaitCursor

        Try
            ' ── Validasi Header ─────────────────────────────────────────
            If cboSupplier.SelectedIndex < 0 Then
                MessageBox.Show("Supplier harus dipilih.", "Validasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboSupplier.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtRemark.Text) Then
                MessageBox.Show("Remark tidak boleh kosong.", "Validasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtRemark.Focus()
                Exit Sub
            End If

            ' ── Validasi Detail ─────────────────────────────────────────
            Dim totalBaris As Integer = 0

            For i As Integer = 1 To fg.Rows.Count - 1
                If fg(i, "ItemID")?.ToString.Trim <> "" Then totalBaris += 1
            Next

            If totalBaris = 0 Then
                MessageBox.Show("Detail pembelian tidak boleh kosong.", "Validasi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            For i As Integer = 1 To fg.Rows.Count - 1

                Dim itemID As String = fg(i, "ItemID")?.ToString.Trim

                If String.IsNullOrEmpty(itemID) Then Continue For

                If fg(i, "Qnty") <= 0 Then
                    MessageBox.Show($"Qnty harus lebih besar dari 0 untuk Item : {itemID}.", "Validasi",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                If fg(i, "UnitPrice") <= 0 Then
                    MessageBox.Show($"Unit Price harus lebih besar dari 0 untuk Item : {itemID}.", "Validasi",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                If String.IsNullOrWhiteSpace(fg(i, "Remark")?.ToString) Then
                    MessageBox.Show($"Remark tidak boleh kosong untuk Item : {itemID}.", "Validasi",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

            Next

            ' ── Simpan Data ─────────────────────────────────────────────
            Using conn As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnRMPApp)

                Using trans As SqlTransaction = conn.BeginTransaction()

                    Try

                        ' Header
                        If SpHdrSave(conn, trans) <> 1 Then
                            Throw New Exception("Gagal menyimpan Header.")
                        End If

                        ' Detail
                        For r As Integer = 1 To fg.Rows.Count - 1

                            Dim itemID As String = fg(r, "ItemID")?.ToString.Trim

                            If String.IsNullOrEmpty(itemID) Then Continue For

                            If SpDtlSave(conn, trans, r) <> 1 Then
                                Throw New Exception($"Gagal menyimpan detail baris {r}.")
                            End If

                        Next

                        ' Generate NPBB & BTB
                        Using cmd As New SqlCommand("DBPancang..INV_spAutoGenerateNpbbNonPcgDanBtb_PembelianNonPancang", conn, trans)

                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.Parameters.AddWithValue("@NoPembelian", txtNoPembelian.Text.Trim)

                            Dim pFlag As New SqlParameter("@Flag", SqlDbType.Int)
                            pFlag.Direction = ParameterDirection.Output
                            cmd.Parameters.Add(pFlag)

                            cmd.ExecuteNonQuery()

                            If CInt(pFlag.Value) <> 1 Then
                                Throw New Exception("Gagal generate NPBB & BTB.")
                            End If

                        End Using

                        trans.Commit()

                    Catch
                        trans.Rollback()
                        Throw
                    End Try

                End Using

            End Using

            ' ── Reload Data ─────────────────────────────────────────────
            LoadData(txtNoPembelian.Text)

            SetFormState(False, True)

            MessageBox.Show("Data berhasil disimpan." & vbCrLf &
                        "No Pembelian : " & txtNoPembelian.Text,
                        "Sukses",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)

        Catch ex As Exception

            MessageBox.Show(ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)

        Finally

            Me.Cursor = Cursors.Default

        End Try

    End Sub

    ' ─── btnCancel ───────────────────────────────────────────────────
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ClearForm()
        SetFormState(isEditing:=False, hasSelection:=False)
    End Sub

    ' ═══════════════════════════════════════════════════════════════════
    ' LOAD DATA
    ' ═══════════════════════════════════════════════════════════════════

    ''' <summary>
    ''' Memuat ulang data header + detail berdasarkan NoPembelian (dipanggil setelah Save,
    ''' juga bisa dipakai saat membuka data existing untuk mode Edit).
    ''' NOTE: Sesuaikan nama SP / nama kolom hasil reader di bawah ini dengan skema
    ''' database yang sebenarnya (spTrnPembelianNonPancangHdrLoad / DtlLoad adalah asumsi).
    ''' </summary>
    Private Sub LoadData(noPembelian As String)
        If String.IsNullOrWhiteSpace(noPembelian) Then Return

        Try
            Using conn As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnRMPApp)

                ' ── Load Header ─────────────────────────────────────
                Dim dt As DataTable = New DataTable()
                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT * FROM tblTrnPembelianNonPancangHdr WHERE NoPembelian = '" & noPembelian & "'")

                If dt.Rows.Count > 0 Then
                    Dim dr As DataRow = dt.Rows(0)

                    txtNoPembelian.Text = dr("NoPembelian").ToString()
                    txtNoNPBB.Text = If(IsDBNull(dr("NoNPBB")), "", dr("NoNPBB").ToString())
                    txtNoBTB.Text = If(IsDBNull(dr("NoBTB")), "", dr("NoBTB").ToString())
                    dtpTanggalPembelian.Value = CDate(dr("TglPembelian"))
                    cboSupplier.SelectedValue = dr("SupplierID")
                    txtRemark.Text = If(IsDBNull(dr("Remark")), "", dr("Remark").ToString())

                    btnDelete.Enabled = True
                End If

                ' ── Load Detail ─────────────────────────────────────
                fg.Rows.Count = 1 ' reset, sisakan baris header grid

                Dim i As Integer = 1
                Dim dtDtl As New DataTable()
                dtDtl = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT d.*,i.ItemName FROM tblTrnPembelianNonPancangDtl d 
                                                                        inner join DBPancang..tblINVMstItem i on d.ItemID=i.ItemID                                                                        
                                                                        WHERE d.NoPembelian = '" & noPembelian & "'")

                If dtDtl.Rows.Count > 0 Then
                    For Each drDtl As DataRow In dtDtl.Rows
                        fg.AddItem(i)
                        fg.Item(i, "ItemID") = drDtl("ItemID")
                        fg.Item(i, "ItemName") = drDtl("ItemName")
                        fg.Item(i, "Qnty") = Format(drDtl("Qnty"), "#,##0")
                        fg.Item(i, "UnitPrice") = Format(drDtl("UnitPrice"), "#,##0")
                        fg.Item(i, "QntySusut") = Format(drDtl("QntySusut"), "#,##0")
                        fg.Item(i, "QntyBertambah") = Format(drDtl("QntyBertambah"), "#,##0")
                        fg.Item(i, "QntyTotal") = Format(drDtl("QntyTotal"), "#,##0")
                        fg.Item(i, "GrandTotal") = Format(drDtl("GrandTotal"), "#,##0")
                        fg.Item(i, "Remark") = If(IsDBNull(drDtl("Remark")), "", drDtl("Remark").ToString())

                        i += 1
                    Next

                    ' ── Hitung total SEBELUM baris TOTAL ditambahkan ────────
                    Dim totalQnty As Decimal = ClsFlexGrid.AggregateColumn(fg, "Qnty")
                    Dim totalQntySusut As Decimal = ClsFlexGrid.AggregateColumn(fg, "QntySusut")
                    Dim totalQntyBertambah As Decimal = ClsFlexGrid.AggregateColumn(fg, "QntyBertambah")
                    Dim totalQntyTotal As Decimal = ClsFlexGrid.AggregateColumn(fg, "QntyTotal")
                    Dim totalGrandTotal As Decimal = ClsFlexGrid.AggregateColumn(fg, "GrandTotal")

                    ' ── Baru tambah baris TOTAL ──────────────────────────────
                    fg.AddItem("")
                    Dim totalRow As Integer = fg.Rows.Count - 1

                    fg(totalRow, "ItemName") = "TOTAL"
                    fg(totalRow, "Qnty") = totalQnty.ToString("#,##0")
                    fg(totalRow, "QntySusut") = totalQntySusut.ToString("#,##0")
                    fg(totalRow, "QntyBertambah") = totalQntyBertambah.ToString("#,##0")
                    fg(totalRow, "QntyTotal") = totalQntyTotal.ToString("#,##0")
                    fg(totalRow, "GrandTotal") = totalGrandTotal.ToString("#,##0")

                    ' ── Styling baris TOTAL ───────────────────────────────────
                    fg.Rows(totalRow).StyleNew.BackColor = Color.LightYellow
                    fg.Rows(totalRow).StyleNew.Font = New Font(fg.Font, FontStyle.Bold)
                End If

            End Using

        Catch ex As Exception
            MessageBox.Show("Error load data: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Me.Show()
    End Sub

    ' ═══════════════════════════════════════════════════════════════════
    ' SP FUNCTIONS
    ' ═══════════════════════════════════════════════════════════════════

    ''' <summary>Simpan header. Return 1 = sukses. noPembelian diisi via ByRef.</summary>
    Private Function SpHdrSave(conn As SqlConnection, trans As SqlTransaction) As Integer
        Try
            Dim cmd As New SqlCommand("spTrnPembelianNonPancangHdrSave", conn, trans)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Perintah", "Add")
            cmd.Parameters.AddWithValue("@HeaderID", 0)
            cmd.Parameters.AddWithValue("@TglPembelian", dtpTanggalPembelian.Value.Date)
            cmd.Parameters.AddWithValue("@SupplierID", cboSupplier.SelectedValue.ToString())
            cmd.Parameters.AddWithValue("@Remark", txtRemark.Text.Trim())
            cmd.Parameters.AddWithValue("@CreatedBy", ClsSession.UserID)

            Dim pNoPembelian As New SqlParameter("@NoPembelian", SqlDbType.VarChar, 30) With {
                .Direction = ParameterDirection.InputOutput,
                .Value = txtNoPembelian.Text
            }
            cmd.Parameters.Add(pNoPembelian)

            Dim pFlag As New SqlParameter("@Flag", SqlDbType.Int) With {
                .Direction = ParameterDirection.Output
            }
            cmd.Parameters.Add(pFlag)
            cmd.ExecuteNonQuery()

            Dim flag As Integer = CInt(pFlag.Value)
            If flag <> 1 Then
                MessageBox.Show("Gagal simpan header.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return flag
            End If

            txtNoPembelian.Text = pNoPembelian.Value.ToString()

            Return 1
        Catch ex As Exception
            MessageBox.Show("Error simpan header: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    ''' <summary>Simpan satu baris detail. Return 1 = sukses.</summary>
    Private Function SpDtlSave(conn As SqlConnection, trans As SqlTransaction, ByVal Row As Integer) As Integer
        Try
            Dim cmd As New SqlCommand("spTrnPembelianNonPancangDtlSave", conn, trans)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Perintah", "Add")
            cmd.Parameters.AddWithValue("@DetailID", 0)
            cmd.Parameters.AddWithValue("@NoPembelian", txtNoPembelian.Text)
            cmd.Parameters.AddWithValue("@ItemID", fg.Item(Row, "ItemID"))

            cmd.Parameters.Add("@Qnty", SqlDbType.Decimal).Value = fg.Item(Row, "Qnty")
            cmd.Parameters.Add("@QntySusut", SqlDbType.Decimal).Value = fg.Item(Row, "QntySusut")
            cmd.Parameters.Add("@QntyTotal", SqlDbType.Decimal).Value = fg.Item(Row, "QntyTotal")
            cmd.Parameters.Add("@QntyBertambah", SqlDbType.Decimal).Value = fg.Item(Row, "QntyBertambah")
            cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = fg.Item(Row, "UnitPrice")
            cmd.Parameters.Add("@GrandTotal", SqlDbType.Decimal).Value = fg.Item(Row, "GrandTotal")

            cmd.Parameters.AddWithValue("@Remark", If(String.IsNullOrEmpty(fg.Item(Row, "Remark")), DBNull.Value, fg.Item(Row, "Remark")))
            cmd.Parameters.AddWithValue("@CreatedBy", ClsSession.UserID)

            Dim pFlag As New SqlParameter("@Flag", SqlDbType.Int) With {
            .Direction = ParameterDirection.Output
        }
            cmd.Parameters.Add(pFlag)
            cmd.ExecuteNonQuery()

            Dim flag As Integer = CInt(pFlag.Value)
            If flag <> 1 Then
                MessageBox.Show($"Gagal simpan detail Item : " & fg.Item(Row, "ItemID") & ". " & fg.Item(Row, "ItemName") & ".", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return flag
        Catch ex As Exception
            MessageBox.Show($"Error simpan detail Item, " & fg.Item(Row, "ItemID") & ". " & fg.Item(Row, "ItemName") & ": " & ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    ''' <summary>Hapus semua detail milik NoPembelian (untuk mode Edit). Return 1 = sukses.</summary>
    Private Function SpDtlDeleteAll(conn As SqlConnection,
                                     trans As SqlTransaction,
                                     noPembelian As String) As Integer
        Try
            ' Ambil semua DetailID dalam transaction yang sama
            Dim ids As New List(Of Long)
            Dim cmdSel As New SqlCommand(
                "SELECT DetailID FROM RMPApp..tblTrnPembelianNonPancangDtl WHERE NoPembelian = @NoPembelian",
                conn, trans)
            cmdSel.Parameters.AddWithValue("@NoPembelian", noPembelian)

            Dim dr As SqlDataReader = cmdSel.ExecuteReader()
            While dr.Read()
                ids.Add(CLng(dr("DetailID")))
            End While
            dr.Close()

            ' Hapus satu per satu via SP
            For Each detailID As Long In ids
                Dim cmd As New SqlCommand("spTrnPembelianNonPancangDtlSave", conn, trans)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Perintah", "Delete")
                cmd.Parameters.AddWithValue("@DetailID", detailID)
                cmd.Parameters.AddWithValue("@CreatedBy", ClsSession.UserID)

                Dim pFlag As New SqlParameter("@Flag", SqlDbType.Int) With {
                    .Direction = ParameterDirection.Output
                }
                cmd.Parameters.Add(pFlag)
                cmd.ExecuteNonQuery()

                If CInt(pFlag.Value) <> 1 Then
                    MessageBox.Show($"Gagal hapus detail ID: {detailID}.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return -1
                End If
            Next

            Return 1
        Catch ex As Exception
            MessageBox.Show("Gagal hapus detail lama: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    ''' <summary>Hapus header (soft delete). Return 1 = sukses.</summary>
    Private Sub SpHdrDelete(keteranganDelete As String)
        ' ── Trans 1: DBPancang ───────────────────────────────────
        Using connPancang As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnDBPancang)
            Using transPancang As SqlTransaction = connPancang.BeginTransaction()
                Try
                    Dim cmd As New SqlCommand("DBPancang..INV_spTrnPembelianNonPancangHdrDelete", connPancang, transPancang)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandTimeout = 60
                    cmd.Parameters.AddWithValue("@NoPembelian", txtNoPembelian.Text.Trim())
                    cmd.Parameters.AddWithValue("@DeletedBy", ClsSession.UserID)
                    cmd.Parameters.AddWithValue("@DeletedRemark", keteranganDelete)
                    Dim pFlag As New SqlParameter("@Flag", SqlDbType.Int) With {.Direction = ParameterDirection.Output}
                    cmd.Parameters.Add(pFlag)
                    cmd.ExecuteNonQuery()

                    If CInt(pFlag.Value) <> 1 Then
                        transPancang.Rollback()
                        MessageBox.Show("Gagal hapus data DBPancang.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If

                    transPancang.Commit()
                Catch ex As Exception
                    transPancang.Rollback()
                    MessageBox.Show("Error DBPancang: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End Try
            End Using
        End Using

        ' ── Trans 2: RMPApp ──────────────────────────────────────
        Using connRMP As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnRMPApp)
            Using transRMP As SqlTransaction = connRMP.BeginTransaction()
                Try
                    Dim cmd As New SqlCommand("RMPApp..spTrnPembelianNonPancangHdrDelete", connRMP, transRMP)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandTimeout = 60
                    cmd.Parameters.AddWithValue("@NoPembelian", txtNoPembelian.Text.Trim())
                    cmd.Parameters.AddWithValue("@DeletedBy", ClsSession.UserID)
                    cmd.Parameters.AddWithValue("@DeletedRemark", keteranganDelete)
                    Dim pFlag As New SqlParameter("@Flag", SqlDbType.Int) With {.Direction = ParameterDirection.Output}
                    cmd.Parameters.Add(pFlag)
                    cmd.ExecuteNonQuery()

                    If CInt(pFlag.Value) <> 1 Then
                        transRMP.Rollback()
                        MessageBox.Show("Gagal hapus header RMPApp.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If

                    transRMP.Commit()

                    MessageBox.Show("Data berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ClearForm()
                    SetFormState(isEditing:=False, hasSelection:=False)

                Catch ex As Exception
                    transRMP.Rollback()
                    MessageBox.Show("Error RMPApp: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    ' ═══════════════════════════════════════════════════════════════════
    ' GRID EVENTS
    ' ═══════════════════════════════════════════════════════════════════

    Private Sub fg_BeforeEdit(sender As Object, e As C1.Win.C1FlexGrid.RowColEventArgs) Handles fg.BeforeEdit
        If Not btnSave.Enabled Then
            e.Cancel = True
        Else
            Select Case fg.Cols(e.Col).Name
                Case "Qnty", "UnitPrice", "QntySusut", "QntyBertambah", "Remark"
                    ' boleh edit
                Case "btnTambah", "btnChose"
                    If fg.Rows.Count - 1 <> e.Row Then e.Cancel = True
                Case "btnDelete"
                    If fg.Rows.Count - 1 = e.Row Then e.Cancel = True
                Case Else
                    e.Cancel = True
            End Select
        End If
    End Sub

    Private Sub fg_CellButtonClick(sender As Object, e As C1.Win.C1FlexGrid.RowColEventArgs) Handles fg.CellButtonClick
        Select Case fg.Cols(e.Col).Name
            Case "btnTambah"
                fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" &
                           vbTab & 0 & vbTab & 0 & vbTab & 0 & vbTab & 0 & vbTab & 0 & vbTab & 0)
            Case "btnDelete"
                fg.RemoveItem(e.Row)
            Case "btnChose"
                Dim dlg As New FrmTrnPembelianNonPancangDlgItem
                Clsfg.ShowLookup(dlg, Me, "LaodItem", fg,
                                 excludeColumn:="ItemID",
                                 autoClose:=False)
        End Select

        For i = 1 To fg.Rows.Count - 1
            fg(i, "No") = i
        Next
    End Sub

    Private Sub fg_AfterEdit(sender As Object, e As C1.Win.C1FlexGrid.RowColEventArgs) Handles fg.AfterEdit
        Select Case fg.Cols(e.Col).Name
            Case "Qnty", "UnitPrice", "QntySusut", "QntyBertambah"
                Dim qnty As Decimal = fg.Item(fg.Row, "Qnty")
                Dim qntySusut As Decimal = fg.Item(fg.Row, "QntySusut")
                Dim qntyBertambah As Decimal = fg.Item(fg.Row, "QntyBertambah")
                fg(e.Row, "QntyTotal") = Format((qnty + qntyBertambah) - qntySusut, "#,##0")
                fg(e.Row, "GrandTotal") = Format(fg.Item(fg.Row, "UnitPrice") * qnty, "#,##0")
        End Select
    End Sub

    Public Sub LaodItem(data As Dictionary(Of String, String))
        If data.ContainsKey("ItemID") Then fg(fg.Row, "ItemID") = data("ItemID")
        If data.ContainsKey("ItemName") Then fg(fg.Row, "ItemName") = data("ItemName")

        ClsFlexGrid.AddEmptyRow(fg)
        fg.Row = fg.Rows.Count - 1

        For i = 1 To fg.Rows.Count - 1
            fg(i, "No") = i
        Next
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        FrmTrnPembelianNonPancangShow.CallbackSub = AddressOf LoadData
        FrmTrnPembelianNonPancangShow.Show(FrmMain.DockPanel1)
    End Sub

    Private Sub FrmTrnPembuatanPenjualanFind_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        lblJudulForm.Left = (Me.Width \ 2) - (lblJudulForm.Width \ 2)
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class