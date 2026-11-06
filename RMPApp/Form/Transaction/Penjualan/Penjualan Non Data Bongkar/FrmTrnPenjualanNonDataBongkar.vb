Imports System.Data.SqlClient
Imports C1.Design

Public Class FrmTrnPenjualanNonDataBongkar
    Private IndPECU As Boolean = False

    Private Sub ClearForm()
        txtNoPenjualan.Clear()
        txtNoSO.Clear()
        txtNoDO.Clear()
        txtNoInvoice.Clear()
        txtRemark.Clear()
        cboCustomer.SelectedIndex = -1
        cboWarehouse.SelectedIndex = -1
        fg.Rows.Count = 1
        fg.Rows.Count = 2
        chkPotPPH22.Checked = True
        chkPPN.Checked = True
    End Sub

    Private Sub SetFormState(isEditing As Boolean, hasSelection As Boolean)
        txtRemark.Enabled = isEditing
        dtpTglPenjualan.Enabled = isEditing
        cboCustomer.Enabled = isEditing
        cboWarehouse.Enabled = isEditing

        btnAdd.Enabled = Not isEditing
        btnDelete.Enabled = Not isEditing AndAlso hasSelection
        btnSave.Enabled = isEditing
        btnCancel.Enabled = isEditing

        chkPotPPH22.Enabled = isEditing
        chkPPN.Enabled = isEditing

        btnFindPECU.Enabled = isEditing
    End Sub

    ' ─── Load ────────────────────────────────────────────────────────
    Private Sub FrmTrnPembelianNonPancang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Combo.SetSupplierCustomerAfiliasi(cboCustomer, 2)
        cboCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboCustomer.AutoCompleteSource = AutoCompleteSource.ListItems

        Combo.SetWarehouse(cboWarehouse)
        cboWarehouse.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboWarehouse.AutoCompleteSource = AutoCompleteSource.ListItems

        Call ClsFlexGrid.ApplyStyle(fg)
        Call ClsFlexGrid.AttachLiveNumber(fg, 0, "Qnty", "UnitPrice")
        Call ClsFlexGrid.SetEditableColumns(fg, "Qnty", "UnitPrice", "btnTambah", "btnDelete", "btnChose", "Remark")
        Call ClsFlexGrid.SetNumberFormat(fg, "N0", "QntyAvailable")

        SetFormState(isEditing:=False, hasSelection:=False)
    End Sub

    ' ─── btnAdd ──────────────────────────────────────────────────────
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ClearForm()

        For i = 1 To fg.Rows.Count - 1
            fg(i, "No") = i
        Next

        SetFormState(isEditing:=True, hasSelection:=False)
        cboCustomer.Focus()
    End Sub

    ' ─── btnDelete ───────────────────────────────────────────────────
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If txtNoPenjualan.Text = "" Then
            MsgBoxCustom.Show("Pilih data terlebih dahulu.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Return
        End If

        If MsgBoxCustom.Show("Yakin hapus data " & txtNoPenjualan.Text & "?", MsgBoxCustom.ButtonType.YesNo, MsgBoxCustom.IconType.Question) = DialogResult.No Then Return

        Dim fr As New FrmKeteranganDelete
        Dim keteranganDelete As String

        If fr.ShowDialog() = DialogResult.OK Then
            keteranganDelete = fr.ResultText
        Else
            Return  ' user cancel
        End If

        If keteranganDelete = "" Then
            MsgBoxCustom.Show("Delete Data Gagal.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Return
        End If

        SpHdrDelete(keteranganDelete)
    End Sub

    ' ─── btnSave ─────────────────────────────────────────────────────
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Me.Cursor = Cursors.WaitCursor

        Try
            ' ── Validasi Header ─────────────────────────────────────────
            If cboCustomer.SelectedIndex < 0 Then
                MsgBoxCustom.Show("Customer harus dipilih.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
                cboCustomer.Focus()
                Exit Sub
            End If

            If cboWarehouse.SelectedIndex < 0 Then
                MsgBoxCustom.Show("Warehouse harus dipilih.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
                cboWarehouse.Focus()
                Exit Sub
            End If

            If String.IsNullOrWhiteSpace(txtRemark.Text) Then
                MsgBoxCustom.Show("Remark tidak boleh kosong.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
                txtRemark.Focus()
                Exit Sub
            End If

            ' ── Validasi Detail ─────────────────────────────────────────
            Dim totalBaris As Integer = 0

            For i As Integer = 1 To fg.Rows.Count - 1
                If fg(i, "ItemID")?.ToString.Trim <> "" Then totalBaris += 1
            Next

            If totalBaris = 0 Then
                MsgBoxCustom.Show("Detail pembelian tidak boleh kosong.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
                Exit Sub
            End If

            For i As Integer = 1 To fg.Rows.Count - 1

                Dim itemID As String = fg(i, "ItemID")?.ToString.Trim

                If String.IsNullOrEmpty(itemID) Then Continue For

                If fg(i, "Qnty") <= 0 Then
                    MsgBoxCustom.Show($"Qnty harus lebih besar dari 0 untuk Item : {itemID}.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
                    Exit Sub
                End If

                If fg(i, "UnitPrice") <= 0 Then
                    MsgBoxCustom.Show($"Unit Price harus lebih besar dari 0 untuk Item : {itemID}.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
                    Exit Sub
                End If

                If String.IsNullOrWhiteSpace(fg(i, "Remark")?.ToString) Then
                    MsgBoxCustom.Show($"Remark tidak boleh kosong untuk Item : {itemID}.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
                    Exit Sub
                End If

            Next

            ' ── Simpan Data ─────────────────────────────────────────────
            Using conn As SqlConnection = DB.OpenConnection(StrConnRMPApp)

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

                        'Generate SO, DO, INVOICE
                        Using cmd As New SqlCommand("DBPancang..SLS_spAutoGenerateSalesNotForPancang", conn, trans)

                            cmd.CommandType = CommandType.StoredProcedure

                            cmd.Parameters.AddWithValue("@NoPenjualan", txtNoPenjualan.Text.Trim)
                            cmd.Parameters.AddWithValue("@CreatedBy", ClsSession.UserID.Trim)

                            Dim pFlag As New SqlParameter("@Flag", SqlDbType.BigInt)
                            pFlag.Direction = ParameterDirection.Output
                            cmd.Parameters.Add(pFlag)

                            Dim pMsg As New SqlParameter("@Msg", SqlDbType.BigInt)
                            pMsg.Direction = ParameterDirection.Output
                            cmd.Parameters.Add(pMsg)

                            cmd.ExecuteNonQuery()

                            Dim flag As Long = CLng(If(IsDBNull(pFlag.Value), 0, pFlag.Value))
                            Dim msg As Long = CLng(If(IsDBNull(pMsg.Value), 0, pMsg.Value))

                            If flag <> 1 Then
                                Throw New Exception("Gagal generate SO, DO, dan INVOICE. Kode: " & msg.ToString())
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
            IndPECU = False

            LoadData(txtNoPenjualan.Text)
            SetFormState(False, True)

            MsgBoxCustom.Show("Data berhasil disimpan." & vbCrLf & "No Pembelian : " & txtNoPenjualan.Text, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
        Catch ex As Exception
            MsgBoxCustom.Show("Terjadi kesalahan: " & ex.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    ' ─── btnCancel ───────────────────────────────────────────────────
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        IndPECU = False

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
    Private Sub LoadData(noPenjualan As String)
        If String.IsNullOrWhiteSpace(noPenjualan) Then Return

        Try
            Using conn As SqlConnection = DB.OpenConnection(StrConnRMPApp)

                ' ── Load Header ─────────────────────────────────────
                Dim dt As DataTable = New DataTable()
                Dim sql As String = "SELECT * FROM tblTrnPenjualanHdr WHERE NoPenjualan = '" & noPenjualan & "'"

                dt = DB.ExecuteQuery(StrConnRMPApp, sql)

                If dt.Rows.Count > 0 Then
                    Dim dr As DataRow = dt.Rows(0)

                    dtpTglPenjualan.Value = CDate(dr("TglPenjualan"))
                    txtNoPenjualan.Text = dr("NoPenjualan").ToString()
                    txtNoSO.Text = If(IsDBNull(dr("NoSO")), "", dr("NoSO").ToString())
                    txtNoDO.Text = If(IsDBNull(dr("NoDO")), "", dr("NoDO").ToString())
                    txtNoInvoice.Text = If(IsDBNull(dr("NoInvoice")), "", dr("NoInvoice").ToString())
                    cboCustomer.SelectedValue = dr("CustomerID")
                    txtRemark.Text = If(IsDBNull(dr("Remark")), "", dr("Remark").ToString())
                    chkPotPPH22.Checked = If(IsDBNull(dr("IndPPH22")), False, dr("IndPPH22"))
                    chkPPN.Checked = If(IsDBNull(dr("IndPPN")), False, dr("IndPPN"))

                    btnDelete.Enabled = True
                End If

                ' ── Load Detail ─────────────────────────────────────
                fg.Rows.Count = 1 ' reset, sisakan baris header grid

                Dim i As Integer = 1
                Dim dtDtl As New DataTable()
                dtDtl = DB.ExecuteQuery(StrConnRMPApp, "SELECT d.*,i.ItemName FROM tblTrnPenjualanDtl d 
                                                                        inner join DBPancang..tblINVMstItem i on d.ItemID=i.ItemID                                                                        
                                                                        WHERE d.NoPenjualan = '" & noPenjualan & "'")

                If dtDtl.Rows.Count > 0 Then
                    For Each drDtl As DataRow In dtDtl.Rows
                        fg.AddItem(i)
                        fg.Item(i, "Mobil") = drDtl("Mobil")
                        fg.Item(i, "ItemID") = drDtl("ItemID")
                        fg.Item(i, "ItemName") = drDtl("ItemName")
                        fg.Item(i, "Qnty") = Format(drDtl("Qnty"), "#,##0")
                        fg.Item(i, "UnitPrice") = Format(drDtl("UnitPrice"), "#,##0")
                        fg.Item(i, "TotalRp") = Format(drDtl("TotalRp"), "#,##0")
                        fg.Item(i, "PersenPPH") = Format(drDtl("PersenPPH"), "0.00")
                        fg.Item(i, "RpPPH") = Format(drDtl("RpPPH"), "#,##0")
                        fg.Item(i, "PersenPPN") = Format(drDtl("PersenPPN"), "0.00")
                        fg.Item(i, "RpPPN") = Format(drDtl("RpPPN"), "#,##0")
                        fg.Item(i, "GrandTotal") = Format(drDtl("GrandTotal"), "#,##0")
                        fg.Item(i, "Remark") = If(IsDBNull(drDtl("Remark")), "", drDtl("Remark").ToString())

                        i += 1
                    Next

                    ' ── Hitung total SEBELUM baris TOTAL ditambahkan ────────
                    Dim totalQnty As Decimal = ClsFlexGrid.AggregateColumn(fg, "Qnty")
                    Dim totalUnitPrice As Decimal = ClsFlexGrid.AggregateColumn(fg, "UnitPrice")
                    Dim totalGrandTotal As Decimal = ClsFlexGrid.AggregateColumn(fg, "GrandTotal")

                    ' ── Baru tambah baris TOTAL ──────────────────────────────
                    fg.AddItem("")
                    Dim totalRow As Integer = fg.Rows.Count - 1

                    fg(totalRow, "ItemName") = "TOTAL"
                    fg(totalRow, "Qnty") = totalQnty.ToString("#,##0")
                    fg(totalRow, "UnitPrice") = totalQnty.ToString("#,##0")
                    fg(totalRow, "GrandTotal") = totalGrandTotal.ToString("#,##0")

                    ' ── Styling baris TOTAL ───────────────────────────────────
                    fg.Rows(totalRow).StyleNew.BackColor = Color.LightYellow
                    fg.Rows(totalRow).StyleNew.Font = New Font(fg.Font, FontStyle.Bold)
                End If

            End Using

        Catch ex As Exception
            MsgBoxCustom.Show("Error load data: " & ex.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
        End Try

        Me.Show()
    End Sub

    ' ═══════════════════════════════════════════════════════════════════
    ' SP FUNCTIONS
    ' ═══════════════════════════════════════════════════════════════════

    ''' <summary>Simpan header. Return 1 = sukses. noPembelian diisi via ByRef.</summary>
    Private Function SpHdrSave(conn As SqlConnection, trans As SqlTransaction) As Integer
        Try
            Dim cmd As New SqlCommand("spTrnPenjualanNonDataBongkarHdrSave", conn, trans)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Perintah", "Add")
            cmd.Parameters.AddWithValue("@HeaderID", 0)
            cmd.Parameters.AddWithValue("@TglPenjualan", dtpTglPenjualan.Value.Date)
            cmd.Parameters.AddWithValue("@CustomerID", cboCustomer.SelectedValue.ToString())
            cmd.Parameters.AddWithValue("@WHSID", cboWarehouse.SelectedValue)
            cmd.Parameters.AddWithValue("@Remark", txtRemark.Text.Trim())
            cmd.Parameters.AddWithValue("@CreatedBy", ClsSession.UserID)
            cmd.Parameters.AddWithValue("@IndPPH22", IIf(chkPotPPH22.Checked, 1, 0))
            cmd.Parameters.AddWithValue("@IndPPN", IIf(chkPPN.Checked, 1, 0))

            Dim pNoPembelian As New SqlParameter("@NoPenjualan", SqlDbType.VarChar, 30) With {
                .Direction = ParameterDirection.InputOutput,
                .Value = txtNoPenjualan.Text
            }
            cmd.Parameters.Add(pNoPembelian)

            Dim pFlag As New SqlParameter("@Flag", SqlDbType.Int) With {
                .Direction = ParameterDirection.Output
            }
            cmd.Parameters.Add(pFlag)
            cmd.ExecuteNonQuery()

            Dim flag As Integer = CInt(pFlag.Value)
            If flag <> 1 Then
                MsgBoxCustom.Show("Gagal simpan header.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
                Return flag
            End If

            txtNoPenjualan.Text = pNoPembelian.Value.ToString()

            Return 1
        Catch ex As Exception
            MsgBoxCustom.Show("Error simpan header: " & ex.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
            Return -1
        End Try
    End Function

    ''' <summary>Simpan satu baris detail. Return 1 = sukses.</summary>
    Private Function SpDtlSave(conn As SqlConnection, trans As SqlTransaction, ByVal Row As Integer) As Integer
        Try
            Dim cmd As New SqlCommand("spTrnPenjualanNonDataBongkarDtlSave", conn, trans)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Perintah", "Add")
            cmd.Parameters.AddWithValue("@DetailID", 0)
            cmd.Parameters.AddWithValue("@NoPenjualan", txtNoPenjualan.Text)
            cmd.Parameters.AddWithValue("@Mobil", fg.Item(Row, "Mobil"))
            cmd.Parameters.AddWithValue("@ItemID", fg.Item(Row, "ItemID"))

            cmd.Parameters.Add("@Qnty", SqlDbType.Decimal).Value = fg.Item(Row, "Qnty")
            cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = fg.Item(Row, "UnitPrice")
            cmd.Parameters.Add("@TotalRp", SqlDbType.Decimal).Value = fg.Item(Row, "TotalRp")
            cmd.Parameters.Add("@PersenPPH", SqlDbType.Decimal).Value = fg.Item(Row, "PersenPPH")
            cmd.Parameters.Add("@RpPPH", SqlDbType.Decimal).Value = fg.Item(Row, "RpPPH")
            cmd.Parameters.Add("@PersenPPN", SqlDbType.Decimal).Value = fg.Item(Row, "PersenPPN")
            cmd.Parameters.Add("@RpPPN", SqlDbType.Decimal).Value = fg.Item(Row, "RpPPN")
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
                MsgBoxCustom.Show($"Gagal simpan detail Item : " & fg.Item(Row, "ItemID") & ". " & fg.Item(Row, "ItemName") & ".", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
            End If
            Return flag
        Catch ex As Exception
            MsgBoxCustom.Show($"Error simpan detail Item, " & fg.Item(Row, "ItemID") & ". " & fg.Item(Row, "ItemName") & ": " & ex.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
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
                    MsgBoxCustom.Show($"Gagal hapus detail ID: {detailID}.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
                    Return -1
                End If
            Next

            Return 1
        Catch ex As Exception
            MsgBoxCustom.Show("Gagal hapus detail lama: " & ex.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
            Return -1
        End Try
    End Function

    ''' <summary>Hapus header (soft delete). Return 1 = sukses.</summary>
    Private Sub SpHdrDelete(keteranganDelete As String)
        ' ── Trans 1: DBPancang ───────────────────────────────────
        Using conn As SqlConnection = DB.OpenConnection(StrConnRMPApp)
            Using trans As SqlTransaction = conn.BeginTransaction()
                Try
                    Dim cmd As New SqlCommand("DBPancang..INV_spTrnPenjualanHdrDelete", conn, trans)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandTimeout = 60
                    cmd.Parameters.AddWithValue("@NoPenjualan", txtNoPenjualan.Text.Trim())
                    cmd.Parameters.AddWithValue("@DeletedBy", ClsSession.UserID)
                    cmd.Parameters.AddWithValue("@DeletedRemark", keteranganDelete)
                    Dim pFlag As New SqlParameter("@Flag", SqlDbType.Int) With {.Direction = ParameterDirection.Output}
                    cmd.Parameters.Add(pFlag)
                    cmd.ExecuteNonQuery()

                    If CInt(pFlag.Value) <> 1 Then
                        trans.Rollback()
                        MsgBoxCustom.Show("Gagal hapus data DBPancang.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
                        Return
                    End If

                    Dim cmd2 As New SqlCommand("spTrnPenjualanNonDataBongkarHdrDelete", conn, trans)
                    cmd2.CommandType = CommandType.StoredProcedure
                    cmd2.CommandTimeout = 60
                    cmd2.Parameters.AddWithValue("@NoPenjualan", txtNoPenjualan.Text.Trim())
                    cmd2.Parameters.AddWithValue("@DeletedBy", ClsSession.UserID)
                    cmd2.Parameters.AddWithValue("@DeletedRemark", keteranganDelete)
                    Dim pFlag2 As New SqlParameter("@Flag", SqlDbType.Int) With {.Direction = ParameterDirection.Output}
                    cmd2.Parameters.Add(pFlag2)
                    cmd2.ExecuteNonQuery()

                    If CInt(pFlag2.Value) <> 1 Then
                        trans.Rollback()
                        MsgBoxCustom.Show("Gagal hapus header RMPApp.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
                        Return
                    End If

                    trans.Commit()

                    MsgBoxCustom.Show("Data berhasil dihapus.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)

                    ClearForm()
                    SetFormState(isEditing:=False, hasSelection:=False)
                Catch ex As Exception
                    trans.Rollback()
                    MsgBoxCustom.Show("Error DBPancang: " & ex.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
                    Return
                End Try
            End Using
        End Using
    End Sub

    ' ═══════════════════════════════════════════════════════════════════
    ' GRID EVENTS
    ' ═══════════════════════════════════════════════════════════════════

    Private Sub fg_BeforeEdit(sender As Object, e As C1.Win.C1FlexGrid.RowColEventArgs) Handles fg.BeforeEdit
        If Not btnSave.Enabled Or IndPECU = True Then
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
                           vbTab & 0 & vbTab & 0 & vbTab & 0 & vbTab & 0 & vbTab & 0 & vbTab & 0 & vbTab & 0 & vbTab & 0 & vbTab & 0)
            Case "btnDelete"
                fg.RemoveItem(e.Row)
            Case "btnChose"
                ' pilih warehouse dulu sebelum pilih item
                If cboWarehouse.SelectedIndex < 0 Then
                    MsgBoxCustom.Show("Pilih warehouse terlebih dahulu.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                    cboWarehouse.Focus()
                    Return
                End If

                Dim dlg As New FrmDlgItemAvailable

                dlg.WHSID = cboWarehouse.SelectedValue
                dlg.TglTransaksi = dtpTglPenjualan.Value

                Clsfg.ShowLookup(dlg, Me, "LaodItem", fg,
                                 excludeColumn:="ItemID",
                                 autoClose:=False)
        End Select

        For i = 1 To fg.Rows.Count - 1
            fg(i, "No") = i
        Next
    End Sub

    Private Sub fg_AfterEdit(sender As Object, e As C1.Win.C1FlexGrid.RowColEventArgs) Handles fg.AfterEdit
        Try
            Select Case fg.Cols(e.Col).Name
                Case "Qnty", "UnitPrice"
                    fg(e.Row, "TotalRp") = Format(fg.Item(fg.Row, "UnitPrice") * fg.Item(fg.Row, "Qnty"), "#,##0")
                    If chkPotPPH22.Checked Then
                        fg.Item(e.Row, "PersenPPH") = 0.25
                        fg.Item(e.Row, "RpPPH") = Format(Math.Ceiling((fg.Item(e.Row, "TotalRp") * 0.25) / 100), "#,##0")
                    Else
                        fg.Item(e.Row, "PersenPPH") = 0
                        fg.Item(e.Row, "RpPPH") = 0
                    End If
                    If chkPPN.Checked Then
                        fg.Item(e.Row, "PersenPPN") = 11
                        fg.Item(e.Row, "RpPPN") = Format(Math.Ceiling(fg.Item(e.Row, "TotalRp") * 0.11), "#,##0")
                    Else
                        fg.Item(e.Row, "PersenPPN") = 0
                        fg.Item(e.Row, "RpPPN") = 0
                    End If
                    fg.Item(e.Row, "PersenPPN") = 11
                    fg.Item(e.Row, "RpPPN") = Format(Math.Ceiling(fg.Item(e.Row, "TotalRp") * 0.11), "#,##0")
                    fg.Item(e.Row, "GrandTotal") = Format(CDec(fg.Item(e.Row, "TotalRp")) - CDec(fg.Item(e.Row, "RpPPH")) + CDec(fg.Item(e.Row, "RpPPN")), "#,##0")
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Public Sub LaodItem(data As Dictionary(Of String, String))
        If data.ContainsKey("ItemID") Then fg(fg.Row, "ItemID") = data("ItemID")
        If data.ContainsKey("ItemName") Then fg(fg.Row, "ItemName") = data("ItemName")
        If data.ContainsKey("QntyAvailable") Then fg(fg.Row, "QntyAvailable") = CInt(data("QntyAvailable"))
        fg(fg.Row, "Qnty") = 0
        fg(fg.Row, "UnitPrice") = 0
        fg(fg.Row, "GrandTotal") = 0

        ClsFlexGrid.AddEmptyRow(fg)
        fg.Row = fg.Rows.Count - 1

        For i = 1 To fg.Rows.Count - 1
            fg(i, "No") = i
        Next
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        FrmTrnPenjualanNonDataBongkarShow.CallbackSub = AddressOf LoadData
        FrmMain.BukaMenu(FrmTrnPenjualanNonDataBongkarShow, FrmMain.mnuTrnPenjualan)
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub dtpTglPenjualan_ValueChanged(sender As Object, e As EventArgs) Handles dtpTglPenjualan.ValueChanged
        ClearForm()
    End Sub

    Private Sub chkPotPPH22_CheckedChanged(sender As Object, e As EventArgs) Handles chkPotPPH22.CheckedChanged
        Kalkulasi()
    End Sub

    Private Sub chkPPN_CheckedChanged(sender As Object, e As EventArgs) Handles chkPPN.CheckedChanged
        Kalkulasi()
    End Sub

    Private Sub Kalkulasi()
        For i = 1 To fg.Rows.Count - 2
            fg(i, "TotalRp") = Format(fg.Item(i, "UnitPrice") * fg.Item(i, "Qnty"), "#,##0")
            If chkPotPPH22.Checked Then
                fg.Item(i, "PersenPPH") = 0.25
                fg.Item(i, "RpPPH") = Format(Math.Ceiling((fg.Item(i, "TotalRp") * 0.25) / 100), "#,##0")
            Else
                fg.Item(i, "PersenPPH") = 0
                fg.Item(i, "RpPPH") = 0
            End If
            If chkPPN.Checked Then
                fg.Item(i, "PersenPPN") = 11
                fg.Item(i, "RpPPN") = Format(Math.Ceiling(fg.Item(i, "TotalRp") * 0.11), "#,##0")
            Else
                fg.Item(i, "PersenPPN") = 0
                fg.Item(i, "RpPPN") = 0
            End If
            fg.Item(i, "GrandTotal") = Format(CDec(fg.Item(i, "TotalRp")) - CDec(fg.Item(i, "RpPPH")) + CDec(fg.Item(i, "RpPPN")), "#,##0")
        Next
    End Sub

    Private Sub btnFindPECU_Click(sender As Object, e As EventArgs) Handles btnFindPECU.Click
        FrmTrnPenjualanNonDataBongkarFindPECU.ShowDialog()
    End Sub

    Public Sub LoadDataPECU(ByVal AntrianID As Integer)
        Dim i As Integer = 1
        Dim NoNota As String = ""
        Dim dt As DataTable = New DataTable
        Dim dtQnty As DataTable = New DataTable
        Dim sql As String = "select * from vwTrnPenjualanNonDataTimbangFindPECU where PullBPI=0 and AntrianID=" & AntrianID

        dt = DB.ExecuteQuery(StrConnRMPApp, sql)

        If dt.Rows.Count > 0 Then
            fg.Rows.Count = 1

            ' tentukan tanggal penjualan
            dtpTglPenjualan.Value = dt.Rows(0)("TanggalTimbang")

            btnSave.Enabled = True

            For Each row As DataRow In dt.Rows
                Dim sql2 As String = "SELECT ItemID, ItemName, QntyAvailable FROM DBPancang..INV_fnStockAvailableOnDate('" & Format(dtpTglPenjualan.Value, "yyyy-MM-dd") & "') WHERE WHSID=" & row("WHSID") & " AND ItemName='" & row("Jenis") & "-" & row("JenisKB") & "' AND QntyAvailable > 0 and CategoryID=01"

                dtQnty = DB.ExecuteQuery(StrConnDBPancang, sql2)

                fg.AddItem(i)
                fg(i, "Mobil") = row("Mobil")
                fg(i, "Qnty") = CInt(row("NettoFinal"))
                fg(i, "UnitPrice") = row("HargaPerKg")
                fg(i, "Remark") = row("NoNota")

                NoNota &= "@" & row("NoNota")

                If dtQnty.Rows.Count > 0 Then
                    fg(i, "ItemID") = dtQnty.Rows(0)("ItemID")
                    fg(i, "ItemName") = dtQnty.Rows(0)("ItemName")
                    fg(i, "QntyAvailable") = CInt(dtQnty.Rows(0)("QntyAvailable"))

                    If CInt(fg.Item(i, "QntyAvailable")) < CInt(fg.Item(i, "Qnty")) Then
                        MsgBoxCustom.Show("Item " & row("Jenis") & "-" & row("JenisKB") & " tidak mencukupi stok di Warehouse " & row("Pancang") & "." & vbCrLf &
                                          "Qnty Available : " & fg(i, "QntyAvailable") & vbCrLf &
                                          "Qnty Penjualan : " & fg(i, "Qnty") & ".", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                        btnSave.Enabled = False
                    End If
                Else
                    fg(i, "QntyAvailable") = 0

                    MsgBoxCustom.Show("Item " & row("Jenis") & "-" & row("JenisKB") & " tidak ada stok tersedia di Warehouse " & row("Pancang") & ".", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                    btnSave.Enabled = False
                End If

                i += 1
            Next

            IndPECU = True

            fg.AddItem("")

            dtpTglPenjualan.Enabled = False
            cboCustomer.Enabled = False
            cboWarehouse.Enabled = False
            txtRemark.Enabled = False
            chkPPN.Enabled = False
            chkPotPPH22.Enabled = False

            cboCustomer.SelectedValue = dt.Rows(0)("IDSupplier")
            cboWarehouse.SelectedValue = dt.Rows(0)("WHSID")
            txtRemark.Text = NoNota

            chkPotPPH22.Checked = True
            chkPPN.Checked = False

            Kalkulasi()

            fg.Rows.Count = dt.Rows.Count + 1
        Else
            MsgBoxCustom.Show("Data tidak ditemukan.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
        End If
    End Sub
End Class