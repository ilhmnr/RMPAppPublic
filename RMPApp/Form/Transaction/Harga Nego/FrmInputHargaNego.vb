Imports C1.Win
Imports System.Text
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class FrmInputHargaNego
    Private Sub FrmInputHargaNego_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call HeaderFg()
        DTPStart.Value = Format(Now, "dd/MM/yy")
        DTPEnd.Value = Format(Now, "dd/MM/yy")
        Modul_RMP.Combo.SetSupplier(cmbS_Petani)
        Modul_RMP.Combo.SetPancang(cmbPancang)
        Modul_RMP.Combo.SetKapal(cmbKapal)
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Call ShowData()
    End Sub

    Private Sub ShowData()
        Me.Cursor = Cursors.WaitCursor

        Dim sql As String = ""
        Dim dt As DataTable = New DataTable
        Dim query As String = ""
        Dim i As Integer = 1

        sql = Modul_RMP.Func.SetCondition(sql, " (cast(TransDate as date) between cast('" & Format(DTPStart.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(DTPEnd.Value, "yyyy-MM-dd") & "' as date)) ")

        If txtNoNota.Text <> "" Then
            sql = Modul_RMP.Func.SetCondition(sql, " NoNota like '%" & txtNoNota.Text & "%' ")
        End If

        If cmbPancang.Text <> "" Then
            sql = Modul_RMP.Func.SetCondition(sql, " IDPancang= " & cmbPancang.SelectedValue)
        End If

        If cmbS_Petani.Text <> "" Then
            sql = Modul_RMP.Func.SetCondition(sql, " IDSubPetani='" & cmbS_Petani.SelectedValue & "' ")
        End If

        If txttrip.Text <> "" Then
            sql = Modul_RMP.Func.SetCondition(sql, " Trip= " & txttrip.Text)
        End If

        If cmbKapal.Text <> "" Then
            sql = Modul_RMP.Func.SetCondition(sql, " IDKapal= " & cmbKapal.SelectedValue)
        End If

        If chkDariPurchaser.Checked = True Then
            sql = Modul_RMP.Func.SetCondition(sql, " flag_harga_nego = 1 ")
        Else
            sql = Modul_RMP.Func.SetCondition(sql, " isnull(flag_harga_nego,0) = 0 ")
        End If

        query = " select * from RMPApp..vwNotaInputHargaNego where HargaNego = 0 and ApproveHargaNegoBy is null and ApproveHargaNegoBy2 is null " & IIf(sql = "", "", " and " & sql) & " order by IDPancang asc "

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, query)

        fg.Rows.Count = 1
        If dt.Rows.Count > 0 Then
            With fg
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, 2) = row("TransID")
                    .Item(i, 3) = row("NoNota")
                    .Item(i, 4) = row("TransDate")
                    .Item(i, 5) = row("TanggalNota")
                    .Item(i, 6) = row("CheckinDate")
                    .Item(i, 7) = row("IDPancang")
                    .Item(i, 8) = row("Pancang")
                    .Item(i, 9) = row("IDKapal")
                    .Item(i, 10) = row("Kapal")
                    .Item(i, 11) = row("trip")
                    .Item(i, 12) = row("IDRelasi")
                    .Item(i, 13) = row("NamaRelasi")
                    .Item(i, 14) = row("IDSubPetani")
                    .Item(i, 15) = row("SubPetani")
                    .Item(i, 16) = row("Brutto")
                    .Item(i, 17) = row("TarraJaring")
                    .Item(i, 18) = row("Netto")
                    .Item(i, 19) = row("TarraPersen")
                    .Item(i, 20) = row("TarraKg")
                    .Item(i, 21) = row("NettoAkhir")
                    .Item(i, 22) = row("PPhProsen")
                    .Item(i, 23) = row("HargaNego")
                    .Item(i, 24) = row("catatan_harga_nego")
                    .Item(i, 25) = row("HargaBefore")
                    .Item(i, 26) = row("TotalRPBefore")
                    .Item(i, 27) = row("PPhPotongBefore")
                    .Item(i, 28) = row("TotalRpAkhirBefore")
                    .Item(i, 29) = row("Potongan")
                    .Item(i, 30) = row("HargaAfter")
                    .Item(i, 31) = row("TotalRpAfter")
                    .Item(i, 32) = row("PPhPotongAfter")
                    .Item(i, 33) = row("TotalRpAkhirAfter")
                    .Item(i, 34) = row("nama_tuan")
                    .Item(i, 35) = row("nama_pelangsir")
                    .Item(i, 36) = row("Remark")

                    If row("IndUM") = True Then
                        Dim style As New CellRange
                        style = fg.GetCellRange(i, 1, i, 36)
                        style.StyleNew.BackColor = Color.FromArgb(255, 192, 192)
                    End If

                    i += 1
                Next

                .AutoSizeCols()
            End With
        Else
            MsgBox("Tidak Ada Data Yang Di Temukan", vbInformation, AT)
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub HeaderFg()
        Dim txt As CellRange

        With fg
            .Rows.Fixed = 1
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Cols.Count = 37

            .Cols.Frozen = 11

            .AutoGenerateColumns = True
            .Rows(0).AllowMerging = True
            .Styles.Normal.WordWrap = True

            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular)
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .AllowMerging = AllowMergingEnum.FixedOnly

            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

            .Rows(0).TextAlign = TextAlignEnum.CenterCenter

            ' Mengatur warna kolom "Harga Nego" menjadi hijau
            Dim hargaNegoStyle As CellStyle = .Styles.Add("HargaNegoStyle")
            hargaNegoStyle.BackColor = Color.FromArgb(192, 255, 192)
            .Cols(23).Style = hargaNegoStyle

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No." : .Cols(0).TextAlign = TextAlignEnum.LeftCenter : .Cols(0).AllowEditing = False
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Ceklist Edit" : .Cols(1).AllowEditing = True
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Trans ID" : .Cols(2).Visible = False
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "No Nota" : .Cols(3).TextAlign = TextAlignEnum.CenterCenter : .Cols(3).AllowEditing = False
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Trans Date" : .Cols(4).TextAlign = TextAlignEnum.CenterCenter : .Cols(4).AllowEditing = False
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Tanggal Nota" : .Cols(5).TextAlign = TextAlignEnum.CenterCenter : .Cols(5).AllowEditing = False
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Checkin Date" : .Cols(6).TextAlign = TextAlignEnum.CenterCenter : .Cols(6).AllowEditing = False
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "ID Pancang" : .Cols(7).Visible = False
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Pancang" : .Cols(8).TextAlign = TextAlignEnum.LeftCenter : .Cols(8).AllowEditing = False
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "ID Kapal" : .Cols(9).Visible = False
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "Kapal" : .Cols(10).TextAlign = TextAlignEnum.LeftCenter : .Cols(10).AllowEditing = False
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "Trip" : .Cols(11).TextAlign = TextAlignEnum.CenterCenter : .Cols(11).AllowEditing = False
            txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "ID Relasi" : .Cols(12).TextAlign = TextAlignEnum.LeftCenter : .Cols(12).AllowEditing = False
            txt = .GetCellRange(0, 13, 0, 13) : txt.Data = "Nama Relasi" : .Cols(13).TextAlign = TextAlignEnum.LeftCenter : .Cols(13).AllowEditing = False
            txt = .GetCellRange(0, 14, 0, 14) : txt.Data = "ID Petani" : .Cols(14).TextAlign = TextAlignEnum.LeftCenter : .Cols(14).AllowEditing = False
            txt = .GetCellRange(0, 15, 0, 15) : txt.Data = "Petani" : .Cols(15).TextAlign = TextAlignEnum.LeftCenter : .Cols(15).AllowEditing = False
            txt = .GetCellRange(0, 16, 0, 16) : txt.Data = "Brutto" : .Cols(16).TextAlign = TextAlignEnum.RightCenter : .Cols(16).AllowEditing = False : .Cols(16).Format = "#,##0"
            txt = .GetCellRange(0, 17, 0, 17) : txt.Data = "Tarra Jaring" : .Cols(17).TextAlign = TextAlignEnum.RightCenter : .Cols(17).AllowEditing = False : .Cols(17).Format = "#,##0"
            txt = .GetCellRange(0, 18, 0, 18) : txt.Data = "Netto" : .Cols(18).TextAlign = TextAlignEnum.RightCenter : .Cols(18).AllowEditing = False : .Cols(18).Format = "#,##0"
            txt = .GetCellRange(0, 19, 0, 19) : txt.Data = "Tarra %" : .Cols(19).TextAlign = TextAlignEnum.RightCenter : .Cols(19).AllowEditing = False : .Cols(19).Format = "#,##0"
            txt = .GetCellRange(0, 20, 0, 20) : txt.Data = "Tarra Kg" : .Cols(20).TextAlign = TextAlignEnum.RightCenter : .Cols(20).AllowEditing = False : .Cols(20).Format = "#,##0"
            txt = .GetCellRange(0, 21, 0, 21) : txt.Data = "Netto Akhir" : .Cols(21).TextAlign = TextAlignEnum.RightCenter : .Cols(21).AllowEditing = False : .Cols(21).Format = "#,##0"
            txt = .GetCellRange(0, 22, 0, 22) : txt.Data = "PPH %" : .Cols(22).TextAlign = TextAlignEnum.RightCenter : .Cols(22).AllowEditing = False
            txt = .GetCellRange(0, 23, 0, 23) : txt.Data = "Harga Nego" : .Cols(23).TextAlign = TextAlignEnum.RightCenter : .Cols(23).AllowEditing = False : .Cols(23).Format = "#,##0" : .Cols(23).AllowEditing = True
            txt = .GetCellRange(0, 24, 0, 24) : txt.Data = "Catatan Harga Nego" : .Cols(24).TextAlign = TextAlignEnum.LeftCenter : .Cols(24).AllowEditing = False
            txt = .GetCellRange(0, 25, 0, 25) : txt.Data = "Harga" : .Cols(25).TextAlign = TextAlignEnum.RightCenter : .Cols(25).AllowEditing = False : .Cols(25).Format = "#,##0"
            txt = .GetCellRange(0, 26, 0, 26) : txt.Data = "Total Rp" : .Cols(26).TextAlign = TextAlignEnum.RightCenter : .Cols(26).AllowEditing = False : .Cols(26).Format = "#,##0"
            txt = .GetCellRange(0, 27, 0, 27) : txt.Data = "PPH Potongan" : .Cols(27).TextAlign = TextAlignEnum.RightCenter : .Cols(27).AllowEditing = False : .Cols(27).Format = "#,##0"
            txt = .GetCellRange(0, 28, 0, 28) : txt.Data = "Total Rp Akhir" : .Cols(28).TextAlign = TextAlignEnum.RightCenter : .Cols(28).AllowEditing = False : .Cols(28).Format = "#,##0"
            txt = .GetCellRange(0, 29, 0, 29) : txt.Data = "Potongan" : .Cols(29).TextAlign = TextAlignEnum.RightCenter : .Cols(29).AllowEditing = False : .Cols(29).Format = "#,##0"
            txt = .GetCellRange(0, 30, 0, 30) : txt.Data = "Harga Setelah Nego" : .Cols(30).TextAlign = TextAlignEnum.RightCenter : .Cols(30).AllowEditing = False : .Cols(30).Format = "#,##0"
            txt = .GetCellRange(0, 31, 0, 31) : txt.Data = "Total Rp Setelah Nego" : .Cols(31).TextAlign = TextAlignEnum.RightCenter : .Cols(31).AllowEditing = False : .Cols(32).Format = "#,##0"
            txt = .GetCellRange(0, 32, 0, 32) : txt.Data = "PPH Potongan Setelah Nego" : .Cols(32).TextAlign = TextAlignEnum.RightCenter : .Cols(32).AllowEditing = False : .Cols(33).Format = "#,##0"
            txt = .GetCellRange(0, 33, 0, 33) : txt.Data = "Total Rp Akhir Setelah Nego" : .Cols(33).TextAlign = TextAlignEnum.RightCenter : .Cols(33).AllowEditing = False : .Cols(33).Format = "#,##0"
            txt = .GetCellRange(0, 34, 0, 34) : txt.Data = "Nama Tuan" : .Cols(34).TextAlign = TextAlignEnum.LeftCenter : .Cols(34).AllowEditing = False
            txt = .GetCellRange(0, 35, 0, 35) : txt.Data = "Nama Pelangsir" : .Cols(35).TextAlign = TextAlignEnum.LeftCenter : .Cols(35).AllowEditing = False
            txt = .GetCellRange(0, 36, 0, 36) : txt.Data = "Remark" : .Cols(36).TextAlign = TextAlignEnum.LeftCenter : .Cols(36).AllowEditing = False

            .AutoSizeCols()
        End With
    End Sub

    Private Sub fg_KeyDown(sender As Object, e As KeyEventArgs) Handles fg.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.C Then
            Modul_RMP.Func.CopySelectedColumns(fg) ' Misal kita ingin menyalin 3 kolom
        End If

        If e.Control AndAlso e.KeyCode = Keys.V Then
            Modul_RMP.Func.PasteToColumns(fg)
        End If
    End Sub

    Private Sub chk_CheckedChanged(sender As Object, e As EventArgs) Handles chkEditAll.CheckedChanged
        If chkEditAll.Checked = True Then
            For i = 1 To fg.Rows.Count - 1
                fg.Item(i, 1) = True
            Next
        Else
            For i = 1 To fg.Rows.Count - 1
                fg.Item(i, 1) = False
            Next
        End If
    End Sub

    Private Sub btnexit_Click(sender As Object, e As EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        With fg
            Dim FlagAdaData As Integer = 0 'untuk memberi tanda jika ada data yang di ceklist
            Dim FlagTidakInputHarga As Integer = 0 'untuk memberi tanda jika ada data yang di ceklist namun tidak di input harga nya
            For i = 1 To .Rows.Count - 1
                If .Item(i, 1) = True Then
                    FlagAdaData += 1

                    If .Item(i, 23) = 0 Then
                        MsgBox("Anda Pilih Pada Baris No ( " & .Item(i, 0) & " ) Namun Harga Nego Tidak Di Input !", vbExclamation, AT)
                        Exit Sub
                    End If
                End If
            Next

            If FlagAdaData = 0 Then
                MsgBox("Tidak Ada Data Yang Di Pilih !", vbExclamation, AT)
                Exit Sub
            End If

            If MsgBox("Cek Kembali Harga Nego Yang Di Input, Jika Sudah Benar Klik Yes.", vbYesNo, AT) = vbNo Then
                Exit Sub
            End If

            Dim koneksi As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnRMPApp)
            Dim Transaksi As SqlTransaction
            Transaksi = koneksi.BeginTransaction

            Try
                For i = 1 To .Rows.Count - 1
                    If .Item(i, 1) = True Then
                        If DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"SELECT isnull(IndUM,0) AS GetValueString FROM TblTrnKelapaHdr WHERE TransID ='" & .Item(i, 2) & "'") = "1" Then
                            MsgBox("Nomor Nota (" & .Item(i, 3) & ") Sudah Di UM !", vbInformation, AT)
                        Else
                            If saveHargaNego(koneksi, Transaksi, .Item(i, 2), .Item(i, 23)) = False Then
                                Transaksi.Rollback()
                                MsgBox("Simpan Data Gagal", vbCritical, "Save Harga Item")
                                Me.Cursor = Cursors.Default
                                Exit Sub
                            End If
                        End If
                    End If
                Next

                Transaksi.Commit()
                MsgBox("Data Berhasil Di Simpan.", vbInformation, AT)
                Call ShowData()
                chkEditAll.Checked = False
            Catch ex As Exception
                Transaksi.Rollback()
                MsgBox("Simpan Data Gagal", vbCritical, "Save Harga Item")
                Me.Cursor = Cursors.Default
                Exit Sub
            End Try
        End With
    End Sub

    Private Sub cmbPancang_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbPancang.KeyUp
        UI.AutoCompleteCombo_KeyUp(cmbPancang, e)
    End Sub

    Private Sub cmbS_Petani_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbS_Petani.KeyUp
        UI.AutoCompleteCombo_KeyUp(cmbS_Petani, e)
    End Sub

    Private Sub chkKapal_KeyUp(sender As Object, e As KeyEventArgs)
        UI.AutoCompleteCombo_KeyUp(cmbKapal, e)
    End Sub

    Private Function saveHargaNego(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal TransID As Int64, ByVal HargaNego As Int64) As Boolean
        saveHargaNego = False

        Try
            Dim MyCon As SqlConnection = Conn
            Dim MyConTrans As SqlTransaction = Trans
            Dim cmd As New SqlCommand
            With cmd

                .Connection = Conn
                .CommandType = CommandType.StoredProcedure
                .CommandText = "RMPApp..sp_saveInputHargaNego"
                .Transaction = MyConTrans

                .Parameters.Add("@TransID", SqlDbType.Int).Value = TransID
                .Parameters.Add("@HargaNego", SqlDbType.Int).Value = HargaNego
                .Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
                .Parameters.Add(New SqlParameter("@Flag", SqlDbType.Int, 1, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))

                .ExecuteNonQuery()
            End With

            If CInt(cmd.Parameters("@Flag").Value) = 0 Then
                cmd.Dispose()
                Exit Function
            End If

            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return True
    End Function
End Class