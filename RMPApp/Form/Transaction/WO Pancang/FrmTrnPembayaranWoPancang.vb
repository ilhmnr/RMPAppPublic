Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports System.IO

Public Class FrmTrnPembayaranWoPancang
    Dim namaFileBayarDariDatabase As String
    Private Sub FrmTrnPembayaranWoPancang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpBayar.Value = Now
        dtpTambahBayar.Value = Now

        Call HeaderFgHistoryBayar()
        Call HeaderFgHistoryTambahBayar()

        Call clearData()
    End Sub
    Private Sub clearData()
        txtWoId.Clear()
        txtPancang.Clear()
        txtJudul.Clear()
        txtHargaProyek.Clear()
        txtSudahDiBayar.Clear()
        txtBelumBayar.Clear()

        txtBayar.Clear()
        txtBayar.Enabled = False
        chkPelunasan.Enabled = False
        btnUploadFileBayar.Enabled = False
        picBayar.BackgroundImage = My.Resources.no_image
        btnBayar.Enabled = False
        dtpBayar.Enabled = False

        txtTambahBayar.Clear()
        txtTambahBayar.Enabled = False
        txtKet.Clear()
        txtKet.Enabled = False
        btnUploadFileTambahBayar.Enabled = False
        picFileTambahBayar.BackgroundImage = My.Resources.no_image
        btnTambahBayar.Enabled = False
        dtpTambahBayar.Enabled = False

        fgHistoryBayar.Rows.Count = 1
        fgHistoryTambahBayar.Rows.Count = 1
    End Sub

    Private Sub HeaderFgHistoryBayar()
        Dim txt As CellRange

        With fgHistoryBayar
            .Rows.Fixed = 1
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Cols.Count = 16

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

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).TextAlign = TextAlignEnum.LeftCenter : .Cols(0).AllowEditing = False
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Bayar" : .Cols(1).TextAlign = TextAlignEnum.RightCenter : .Cols(1).AllowEditing = False : .Cols(1).Format = "#,###0"
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Akumulasi Bayar" : .Cols(2).TextAlign = TextAlignEnum.RightCenter : .Cols(2).AllowEditing = False : .Cols(2).Format = "#,###0"
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "%" : .Cols(3).TextAlign = TextAlignEnum.CenterCenter : .Cols(3).AllowEditing = False
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Akumulasi %" : .Cols(4).TextAlign = TextAlignEnum.CenterCenter : .Cols(4).AllowEditing = False
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Deskripsi" : .Cols(5).TextAlign = TextAlignEnum.LeftCenter : .Cols(5).AllowEditing = False
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Created By" : .Cols(6).TextAlign = TextAlignEnum.LeftCenter : .Cols(6).AllowEditing = False
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Created Date" : .Cols(7).TextAlign = TextAlignEnum.CenterCenter : .Cols(7).AllowEditing = False
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Tranfer Date" : .Cols(8).TextAlign = TextAlignEnum.CenterCenter : .Cols(8).AllowEditing = False
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Deleted By" : .Cols(9).TextAlign = TextAlignEnum.LeftCenter : .Cols(9).AllowEditing = False : .Cols(9).Visible = False
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "Deleted Date" : .Cols(10).TextAlign = TextAlignEnum.CenterCenter : .Cols(10).AllowEditing = False : .Cols(10).Visible = False
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "File Pembayaran" : .Cols(11).TextAlign = TextAlignEnum.LeftCenter : .Cols(11).AllowEditing = False
            txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "Nama File Pembayaran" : .Cols(12).Visible = False
            txt = .GetCellRange(0, 13, 0, 13) : txt.Data = "Hapus" : .Cols(13).TextAlign = TextAlignEnum.LeftCenter : .Cols(13).AllowEditing = False
            txt = .GetCellRange(0, 14, 0, 14) : txt.Data = "Id" : .Cols(14).Visible = False
            txt = .GetCellRange(0, 15, 0, 15) : txt.Data = "Deleted" : .Cols(15).Visible = False

            .AutoSizeCols()
        End With
    End Sub

    Private Sub HeaderFgHistoryTambahBayar()
        Dim txt As CellRange

        With fgHistoryTambahBayar
            .Rows.Fixed = 1
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Cols.Count = 16

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

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).TextAlign = TextAlignEnum.LeftCenter : .Cols(0).AllowEditing = False
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Bayar" : .Cols(1).TextAlign = TextAlignEnum.RightCenter : .Cols(1).AllowEditing = False : .Cols(1).Format = "#,###0"
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Akumulasi Bayar" : .Cols(2).TextAlign = TextAlignEnum.RightCenter : .Cols(2).AllowEditing = False : .Cols(2).Format = "#,###0"
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "%" : .Cols(3).TextAlign = TextAlignEnum.CenterCenter : .Cols(3).AllowEditing = False
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Akumulasi %" : .Cols(4).TextAlign = TextAlignEnum.CenterCenter : .Cols(4).AllowEditing = False
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Deskripsi" : .Cols(5).TextAlign = TextAlignEnum.LeftCenter : .Cols(5).AllowEditing = False
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Created By" : .Cols(6).TextAlign = TextAlignEnum.LeftCenter : .Cols(6).AllowEditing = False
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Created Date" : .Cols(7).TextAlign = TextAlignEnum.CenterCenter : .Cols(7).AllowEditing = False
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Tranfer Date" : .Cols(8).TextAlign = TextAlignEnum.CenterCenter : .Cols(8).AllowEditing = False
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Deleted By" : .Cols(9).TextAlign = TextAlignEnum.LeftCenter : .Cols(9).AllowEditing = False : .Cols(9).Visible = False
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "Deleted Date" : .Cols(10).TextAlign = TextAlignEnum.CenterCenter : .Cols(10).AllowEditing = False : .Cols(10).Visible = False
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "File Pembayaran" : .Cols(11).TextAlign = TextAlignEnum.LeftCenter : .Cols(11).AllowEditing = False
            txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "Nama File Pembayaran" : .Cols(12).Visible = False
            txt = .GetCellRange(0, 13, 0, 13) : txt.Data = "Hapus" : .Cols(13).TextAlign = TextAlignEnum.LeftCenter : .Cols(13).AllowEditing = False
            txt = .GetCellRange(0, 14, 0, 14) : txt.Data = "Id" : .Cols(14).Visible = False
            txt = .GetCellRange(0, 15, 0, 15) : txt.Data = "Deleted" : .Cols(15).Visible = False

            .AutoSizeCols()
        End With
    End Sub

    Public Sub loadHistoryBayar()
        Dim i As Integer = 1
        Dim dt As DataTable = New DataTable
        Dim dt2 As DataTable = New DataTable
        Dim query, query2 As String

        'Try
        query = " select * from tbl_wo_trn_bayar where wo_id=" & txtWoId.Text & " and deleted=0 and flag<>4 "
        query2 = " select * from tbl_wo_trn_bayar where wo_id=" & txtWoId.Text & " and deleted=0 and flag=4 "

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, query)
        dt2 = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, query2)

        fgHistoryBayar.Rows.Count = 1
        If dt.Rows.Count > 0 Then
            With fgHistoryBayar
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, 1) = row("bayar")
                    .Item(i, 5) = row("deskripsi")
                    .Item(i, 6) = row("created_by")
                    .Item(i, 7) = row("created_date")
                    .Item(i, 8) = row("transfer_date")
                    .Item(i, 9) = row("deleted_by")
                    .Item(i, 10) = row("deleted_date")

                    Dim style As C1.Win.C1FlexGrid.CellStyle = .Styles.Add("style")
                    style.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
                    .SetCellImage(i, 11, My.Resources.ButtonPdf)
                    .SetCellStyle(i, 11, style)

                    .Item(i, 12) = row("file_pembayaran")

                    Dim style2 As C1.Win.C1FlexGrid.CellStyle = .Styles.Add("style")
                    style2.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
                    .SetCellImage(i, 13, My.Resources.ButtonHapus)
                    .SetCellStyle(i, 13, style2)

                    .Item(i, 14) = row("id")
                    .Item(i, 15) = row("deleted")
                    i += 1
                Next
                .AutoSizeCols()
            End With
        End If

        Dim totalBayar As Int64 = 0
        For i = 1 To fgHistoryBayar.Rows.Count - 1
            If fgHistoryBayar.Item(i, 15) = False Then
                totalBayar += fgHistoryBayar.Item(i, 1)
            End If
        Next
        txtSudahDiBayar.Text = CStr(String.Format("{0:n0}", CInt(totalBayar)))
        txtBelumBayar.Text = txtHargaProyek.Text - txtSudahDiBayar.Text
        txtBelumBayar.Text = CStr(String.Format("{0:n0}", CInt(txtBelumBayar.Text)))

        i = 1
        fgHistoryTambahBayar.Rows.Count = 1
        If dt2.Rows.Count > 0 Then
            With fgHistoryTambahBayar
                For Each row As DataRow In dt2.Rows
                    .AddItem(i)
                    .Item(i, 1) = row("bayar")
                    .Item(i, 5) = row("deskripsi")
                    .Item(i, 6) = row("created_by")
                    .Item(i, 7) = row("created_date")
                    .Item(i, 8) = row("transfer_date")
                    .Item(i, 9) = row("deleted_by")
                    .Item(i, 10) = row("deleted_date")

                    Dim style As C1.Win.C1FlexGrid.CellStyle = .Styles.Add("style")
                    style.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
                    .SetCellImage(i, 11, My.Resources.ButtonPdf)
                    .SetCellStyle(i, 11, style)

                    .Item(i, 12) = row("file_pembayaran")

                    Dim style2 As C1.Win.C1FlexGrid.CellStyle = .Styles.Add("style")
                    style2.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
                    .SetCellImage(i, 13, My.Resources.ButtonHapus)
                    .SetCellStyle(i, 13, style2)

                    .Item(i, 14) = row("id")
                    .Item(i, 15) = row("deleted")
                    i += 1
                Next
                .AutoSizeCols()
            End With
        End If

        'hitung persen dan akum persen bayar
        Dim bayar As Integer
        Dim percentage As Decimal
        With fgHistoryBayar
            If .Rows.Count > 1 Then
                For i = 1 To .Rows.Count - 1
                    bayar = .Item(i, 1)
                    percentage = (bayar / txtHargaProyek.Text) * 100
                    .Item(i, 3) = CInt(percentage)
                    If i > 1 Then
                        .Item(i, 4) = CInt(percentage) + .Item(i - 1, 4)
                        .Item(i, 2) = bayar + .Item(i - 1, 2)
                    Else
                        .Item(i, 4) = CInt(percentage)
                        .Item(i, 2) = bayar
                    End If
                    DB.ExecuteScalarValue(Of String)(StrConnRMPApp," update tbl_wo_trn_bayar set persen=" & .Item(i, 3) & ",akum_persen=" & .Item(i, 4) & ",akum_bayar=" & .Item(i, 2) & " where id=" & .Item(i, 14) & "
                                     select '' as GetValueString ")
                Next
            End If
        End With

        'hitung persen dan akum persen tambah bayar
        Dim bayar2 As Integer
        Dim percentage2 As Decimal
        With fgHistoryTambahBayar
            If .Rows.Count > 1 Then
                For i = 1 To .Rows.Count - 1
                    bayar2 = .Item(i, 1)
                    percentage2 = (bayar2 / txtHargaProyek.Text) * 100
                    .Item(i, 3) = CInt(percentage2)
                    If i > 1 Then
                        .Item(i, 4) = CInt(percentage2) + .Item(i - 1, 4)
                        .Item(i, 2) = bayar2 + .Item(i - 1, 2)
                    Else
                        .Item(i, 4) = CInt(percentage2) + fgHistoryBayar.Item(fgHistoryBayar.Rows.Count - 1, 4)
                        .Item(i, 2) = bayar2 + fgHistoryBayar.Item(fgHistoryBayar.Rows.Count - 1, 2)
                    End If
                    DB.ExecuteScalarValue(Of String)(StrConnRMPApp," update tbl_wo_trn_bayar set persen=" & .Item(i, 3) & ",akum_persen=" & .Item(i, 4) & ",akum_bayar=" & .Item(i, 2) & " where id=" & .Item(i, 14) & "
                                     select '' as GetValueString ")
                Next
            End If
        End With

        'nonaktifkan bayar ketika sudah lunas dan aktifkan tambah bayar

        If txtBelumBayar.Text = 0 Then
            txtTambahBayar.Enabled = True
            btnTambahBayar.Enabled = True
            txtKet.Enabled = True
            btnUploadFileTambahBayar.Enabled = True
            dtpTambahBayar.Enabled = True

            txtBayar.Enabled = False
            chkPelunasan.Enabled = False
            btnUploadFileBayar.Enabled = False
            btnBayar.Enabled = False
            dtpBayar.Enabled = False

            fgHistoryBayar.Cols(13).Visible = False
        Else
            txtTambahBayar.Enabled = False
            btnTambahBayar.Enabled = False
            txtKet.Enabled = False
            btnUploadFileTambahBayar.Enabled = False
            dtpTambahBayar.Enabled = False

            txtBayar.Enabled = True
            chkPelunasan.Enabled = True
            btnUploadFileBayar.Enabled = True
            btnBayar.Enabled = True
            dtpBayar.Enabled = True

            fgHistoryBayar.Cols(13).Visible = True
        End If

        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub btnUploadFileTambahBayar_Click(sender As Object, e As EventArgs) Handles btnUploadFileTambahBayar.Click
        Dim Openpdf As OpenFileDialog = New OpenFileDialog()
        Openpdf.Filter = "PDF files|*.pdf|All files|*.*;"

        If Openpdf.ShowDialog() = DialogResult.OK Then
            Dim pdfLog As String = Openpdf.FileName.ToString()
            lblFileTambahBayar.Text = pdfLog
            AxAcroPDF1.src = Openpdf.FileName
            AxAcroPDF1.LoadFile(lblFileTambahBayar.Text)
            picFileTambahBayar.BackgroundImage = My.Resources.file
        Else
            lblFileTambahBayar.Text = "No File"
            picFileTambahBayar.BackgroundImage = My.Resources.no_image
        End If

        If AxAcroPDF1.src Is Nothing Then
            MessageBox.Show("Try new file")
        Else
            MessageBox.Show("PDF Uploaded")
        End If
    End Sub

    Private Function saveData(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal flagTambahBayar As Integer, ByVal bayar As Int64, ByVal tgl As DateTime) As Boolean
        saveData = False

        Dim MyCon As SqlConnection = Conn
        Dim MyConTrans As SqlTransaction = Trans
        Dim cmd As New SqlCommand

        With cmd
            .Connection = Conn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RMPApp..spSaveBayarWoPancang"
            .Transaction = MyConTrans

            .Parameters.Add("@woId", SqlDbType.Int).Value = CInt(txtWoId.Text)
            .Parameters.Add("@bayar", SqlDbType.Decimal, 18.2).Value = bayar
            .Parameters.Add("@ket", SqlDbType.VarChar, 400).Value = txtKet.Text
            .Parameters.Add("@flagPelunasan", SqlDbType.Int).Value = IIf(chkPelunasan.Checked = True, 1, 0)
            .Parameters.Add("@falgTambahBayar", SqlDbType.Int).Value = flagTambahBayar
            .Parameters.Add("@createdBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
            .Parameters.Add("@tgl", SqlDbType.DateTime).Value = tgl
            .Parameters.Add(New SqlParameter("@Flag", SqlDbType.SmallInt, 3, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .Parameters.Add(New SqlParameter("@namaFileBayar", SqlDbType.VarChar, 100, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))

            .ExecuteNonQuery()
        End With

        Try
            If CInt(cmd.Parameters("@Flag").Value) = 0 Then
                cmd.Dispose()
                Exit Function
            End If

            namaFileBayarDariDatabase = cmd.Parameters("@namaFileBayar").Value

            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        Call clearData()

        With FrmTrnApproval1DanInputBarangPengajuanWoPancangFind
            .TabControl.SelectedTab = .TabPage4
            .openFormBy = "Pembayaran"
            .rdAllBayar.Checked = True
            .loadData()
            .ShowDialog()
        End With
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnBayar_Click(sender As Object, e As EventArgs) Handles btnBayar.Click
        Me.Cursor = Cursors.WaitCursor

        If CInt(txtBayar.Text) > CInt(txtBelumBayar.Text) Then
            MsgBox("Nominal Pembayaran Melebihi Sisa Yang Harus Di Bayar ! !", vbInformation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If chkPelunasan.Checked = False And Replace(txtBayar.Text, ".", "") = Replace(txtBelumBayar.Text, ".", "") Then
            MsgBox("Ceklist Pelunasan Untuk Pembayaran Akhir ! !", vbInformation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If chkPelunasan.Checked Then
            If txtBayar.Text <> txtBelumBayar.Text Then
                MsgBox("Nominal Pembayaran Dan Sisa Yang Harus Di Bayar Tidak Sama ! !", vbInformation, AT)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        If lblFileBayar.Text = "No File" Then
            MsgBox("File Bayar Belum Di Upload !", vbInformation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        ElseIf txtBayar.Text = "" Then
            MsgBox("Pembayaran Belum Di Input !", vbInformation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        Dim koneksi As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnRMPApp)
        Dim transaksi As SqlTransaction
        transaksi = koneksi.BeginTransaction

        If saveData(koneksi, transaksi, 0, Replace(txtBayar.Text, ".", ""), dtpBayar.Value) = False Then
            transaksi.Rollback()
            MsgBox("Simpan Data Gagal !", vbExclamation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        transaksi.Commit()


        Dim lokasiSimpanFile1 As String = UrlNotaPancang & "DocumentWorkOrder\" & namaFileBayarDariDatabase
        File.Copy(lblFileBayar.Text, lokasiSimpanFile1, True)

        MsgBox("Save Data Berhasil !", vbInformation, AT)

        txtBayar.Clear()
        chkPelunasan.Checked = False
        lblFileBayar.Text = "No File"
        picBayar.BackgroundImage = My.Resources.no_image
        Call loadHistoryBayar()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnTambahBayar_Click(sender As Object, e As EventArgs) Handles btnTambahBayar.Click
        Me.Cursor = Cursors.WaitCursor

        If lblFileTambahBayar.Text = "No File" Then
            MsgBox("File Bayar Belum Di Upload !", vbInformation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        ElseIf txtTambahBayar.Text = "" Then
            MsgBox("Pembayaran Belum Di Input !", vbInformation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        ElseIf txtKet.Text = "" Then
            MsgBox("Keterangan Tambah Bayar Belum Di Input !", vbInformation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        Dim koneksi As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnRMPApp)
        Dim transaksi As SqlTransaction
        transaksi = koneksi.BeginTransaction

        If saveData(koneksi, transaksi, 1, Replace(txtTambahBayar.Text, ".", ""), dtpTambahBayar.Value) = False Then
            transaksi.Rollback()
            MsgBox("Simpan Data Gagal !", vbExclamation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        transaksi.Commit()


        Dim lokasiSimpanFile1 As String = UrlNotaPancang & "DocumentWorkOrder\" & namaFileBayarDariDatabase
        File.Copy(lblFileTambahBayar.Text, lokasiSimpanFile1, True)

        txtTambahBayar.Clear()
        txtKet.Clear()
        lblFileTambahBayar.Text = "No File"
        picFileTambahBayar.BackgroundImage = My.Resources.no_image
        MsgBox("Save Data Berhasil !", vbInformation, AT)

        Call loadHistoryBayar()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtWoId_TextChanged(sender As Object, e As EventArgs) Handles txtWoId.TextChanged
        If txtWoId.Text <> "" Then
            txtBayar.Enabled = True
            chkPelunasan.Enabled = True
            btnUploadFileBayar.Enabled = True
            txtTambahBayar.Enabled = True
            txtKet.Enabled = True
            btnUploadFileTambahBayar.Enabled = True
            btnBayar.Enabled = True
            btnTambahBayar.Enabled = True
        End If
    End Sub

    Private Sub btnUploadFileBayar_Click(sender As Object, e As EventArgs) Handles btnUploadFileBayar.Click
        Dim Openpdf As OpenFileDialog = New OpenFileDialog()
        Openpdf.Filter = "PDF files|*.pdf|All files|*.*;"

        If Openpdf.ShowDialog() = DialogResult.OK Then
            Dim pdfLog As String = Openpdf.FileName.ToString()
            lblFileBayar.Text = pdfLog
            AxAcroPDF1.src = Openpdf.FileName
            AxAcroPDF1.LoadFile(lblFileBayar.Text)
            picBayar.BackgroundImage = My.Resources.file
        Else
            lblFileBayar.Text = "No File"
            picBayar.BackgroundImage = My.Resources.no_image
        End If

        If AxAcroPDF1.src Is Nothing Then
            MessageBox.Show("Try new file")
        Else
            MessageBox.Show("PDF Uploaded")
        End If
    End Sub

    Private Sub chkPelunasan_CheckedChanged(sender As Object, e As EventArgs) Handles chkPelunasan.CheckedChanged
        If chkPelunasan.Checked Then
            'Dim flagSudahAdaBA As Integer
            'flagSudahAdaBA = CInt(DB.ExecuteScalarValue(Of String)(StrConnRMPApp," select iif(file_ba is null,'0','1') as GetValueString from tbl_wo_trn_hdr where id=" & txtWoId.Text & " "))
            'If flagSudahAdaBA = 0 Then
            '    MsgBox("Tidak Bisa Melakukan Pelunasan, Karena File BA Belum Di Input !", vbExclamation, AT)
            '    chkPelunasan.Checked = False
            '    Exit Sub
            'End If
        End If
    End Sub

    Private Sub fgHistoryBayar_DoubleClick(sender As Object, e As EventArgs) Handles fgHistoryBayar.DoubleClick
        With fgHistoryBayar
            If .Rows.Count > 1 Then
                If .Col = 11 Then
                    Try
                        Process.Start(UrlNotaPancang & "DocumentWorkOrder\" & .Item(.RowSel, 12))
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "File Tidak Ditemukan Pilih File terlebih dahulu", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End Try
                ElseIf .Col = 13 Then
                    If MsgBox("Yakin Akan Hapus Data Pembayaran Tanggal " & .Item(.RowSel, 8) & " Dengan Nominal " & .Item(.RowSel, 1) & " ?", vbYesNo, AT) = vbYes Then
                        Dim updateData As String = " update RMPApp..tbl_wo_trn_bayar set deleted=1,deleted_by='" & ClsSession.UserID & "',deleted_date=getdate() where id=" & .Item(.RowSel, 14) & " "
                        Dim updateData_ As New SqlCommand(updateData, DB.OpenConnection(StrConnRMPApp))
                        updateData_.ExecuteNonQuery()

                        loadHistoryBayar()
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub fgHistoryTambahBayar_DoubleClick(sender As Object, e As EventArgs) Handles fgHistoryTambahBayar.DoubleClick
        With fgHistoryTambahBayar
            If .Rows.Count > 1 Then
                If .Col = 11 Then
                    Try
                        Process.Start(UrlNotaPancang & "DocumentWorkOrder\" & .Item(.RowSel, 12))
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "File Tidak Ditemukan Pilih File terlebih dahulu", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End Try
                ElseIf .Col = 13 Then
                    If MsgBox("Yakin Akan Hapus Data Pembayaran Tanggal " & .Item(.RowSel, 8) & " Dengan Nominal " & .Item(.RowSel, 1) & " ?", vbYesNo, AT) = vbYes Then
                        Dim updateData As String = " update RMPApp..tbl_wo_trn_bayar set deleted=1,deleted_by='" & ClsSession.UserID & "',deleted_date=getdate() where id=" & .Item(.RowSel, 14) & " "
                        Dim updateData_ As New SqlCommand(updateData, DB.OpenConnection(StrConnRMPApp))
                        updateData_.ExecuteNonQuery()

                        loadHistoryBayar()
                    End If
                End If
            End If
        End With
    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Try
            Dim topColor As Color = Color.FromArgb(0, 172, 251) ' Warna atas yang tebal
            Dim bottomColor As Color = Color.FromArgb(0, 0, 255, 255) ' Warna bawah yang pudar

            Dim gradientRect As New Rectangle(0, 0, Panel1.Width, Panel1.Height)

            Using brush As New Drawing2D.LinearGradientBrush(gradientRect, topColor, bottomColor, Drawing2D.LinearGradientMode.Vertical)
                e.Graphics.FillRectangle(brush, gradientRect)
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtBayar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBayar.KeyPress
        If (Not Char.IsNumber(e.KeyChar)) AndAlso (e.KeyChar <> ControlChars.Back) AndAlso (e.KeyChar <> "."c) Then
            ' Cancel the event to prevent the character from being entered
            e.Handled = True
        End If
    End Sub

    Private Sub txtTambahBayar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTambahBayar.KeyPress
        If (Not Char.IsNumber(e.KeyChar)) AndAlso (e.KeyChar <> ControlChars.Back) AndAlso (e.KeyChar <> "."c) Then
            ' Cancel the event to prevent the character from being entered
            e.Handled = True
        End If
    End Sub

    Private Sub txtBayar_GotFocus(sender As Object, e As EventArgs) Handles txtBayar.GotFocus
        txtBayar.Text = Replace(txtBayar.Text, ".", "")
        txtBayar.SelectionStart = txtBayar.Text.Length
        txtBayar.SelectionLength = 0
    End Sub

    Private Sub txtBayar_LostFocus(sender As Object, e As EventArgs) Handles txtBayar.LostFocus
        Try
            txtBayar.Text = CStr(String.Format("{0:n0}", CInt(txtBayar.Text)))
        Catch ex As Exception
        End Try
        txtBayar.SelectionStart = txtBayar.Text.Length
        txtBayar.SelectionLength = 0
    End Sub

    Private Sub txtBayar_MouseEnter(sender As Object, e As EventArgs) Handles txtBayar.MouseEnter
        txtBayar.Text = Replace(txtBayar.Text, ".", "")
        txtBayar.SelectionStart = txtBayar.Text.Length
        txtBayar.SelectionLength = 0
    End Sub

    Private Sub txtBayar_MouseLeave(sender As Object, e As EventArgs) Handles txtBayar.MouseLeave
        Try
            txtBayar.Text = CStr(String.Format("{0:n0}", CInt(txtBayar.Text)))
        Catch ex As Exception
        End Try
        txtBayar.SelectionStart = txtBayar.Text.Length
        txtBayar.SelectionLength = 0
    End Sub

    Private Sub txtTambahBayar_GotFocus(sender As Object, e As EventArgs) Handles txtTambahBayar.GotFocus
        txtTambahBayar.Text = Replace(txtTambahBayar.Text, ".", "")
        txtTambahBayar.SelectionStart = txtTambahBayar.Text.Length
        txtTambahBayar.SelectionLength = 0
    End Sub

    Private Sub txtTambahBayar_LostFocus(sender As Object, e As EventArgs) Handles txtTambahBayar.LostFocus
        Try
            txtTambahBayar.Text = CStr(String.Format("{0:n0}", CInt(txtTambahBayar.Text)))
        Catch ex As Exception
        End Try
        txtTambahBayar.SelectionStart = txtTambahBayar.Text.Length
        txtTambahBayar.SelectionLength = 0
    End Sub

    Private Sub txtTambahBayar_MouseEnter(sender As Object, e As EventArgs) Handles txtTambahBayar.MouseEnter
        txtTambahBayar.Text = Replace(txtTambahBayar.Text, ".", "")
        txtTambahBayar.SelectionStart = txtTambahBayar.Text.Length
        txtTambahBayar.SelectionLength = 0
    End Sub

    Private Sub txtTambahBayar_MouseLeave(sender As Object, e As EventArgs) Handles txtTambahBayar.MouseLeave
        Try
            txtTambahBayar.Text = CStr(String.Format("{0:n0}", CInt(txtTambahBayar.Text)))
        Catch ex As Exception
        End Try
        txtTambahBayar.SelectionStart = txtTambahBayar.Text.Length
        txtTambahBayar.SelectionLength = 0
    End Sub
End Class