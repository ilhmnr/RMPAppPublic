Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmTrnBuktiTrfPengajuanPoinFind
    Private Sub FrmTrnBuktiTrfPengajuanPoinFind_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DTPStart.Value = Format(Now, "dd/MM/yy")
        DTPEnd.Value = Format(Now, "dd/MM/yy")
        dt1.Value = Format(Now, "dd/MM/yy")
        dt2.Value = Format(Now, "dd/MM/yy")
        chknoinvoice.Checked = False
        Call HeaderFg()
    End Sub

    Private Sub HeaderFg()
        Dim txt As CellRange

        With fg
            .Rows.Fixed = 1
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Cols.Count = 12

            .AutoGenerateColumns = True
            '.Rows(0).AllowMerging = True
            .Styles.Normal.WordWrap = True

            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular)
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            '.AllowMerging = AllowMergingEnum.FixedOnly

            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

            .Rows(0).TextAlign = TextAlignEnum.CenterCenter

            .AllowMerging = True

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).TextAlign = TextAlignEnum.LeftCenter : .Cols(0).AllowEditing = False : .Cols(0).AllowMerging = True
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Transaction ID" : .Cols(1).TextAlign = TextAlignEnum.LeftCenter : .Cols(1).AllowEditing = False : .Cols(1).AllowMerging = True
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Tgl Transaksi" : .Cols(2).TextAlign = TextAlignEnum.CenterCenter : .Cols(2).AllowEditing = False
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Tgl Transfer" : .Cols(3).TextAlign = TextAlignEnum.CenterCenter : .Cols(3).AllowEditing = False
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Bank Kirim" : .Cols(4).TextAlign = TextAlignEnum.LeftCenter : .Cols(4).AllowEditing = False
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Bank Toko" : .Cols(5).TextAlign = TextAlignEnum.LeftCenter : .Cols(5).AllowEditing = False
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Nama Rekening Toko" : .Cols(6).TextAlign = TextAlignEnum.LeftCenter : .Cols(6).AllowEditing = False
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "No Rekening Toko" : .Cols(7).TextAlign = TextAlignEnum.LeftCenter : .Cols(7).AllowEditing = False
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Total" : .Cols(8).TextAlign = TextAlignEnum.RightCenter : .Cols(8).AllowEditing = False : .Cols(8).Format = "#,###0"
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Total Akhir" : .Cols(9).TextAlign = TextAlignEnum.RightCenter : .Cols(9).AllowEditing = False : .Cols(9).Format = "#,###0" : .Cols(9).AllowMerging = True
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "Created By" : .Cols(10).TextAlign = TextAlignEnum.LeftCenter : .Cols(10).AllowEditing = False
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "Print Bukti Bayar" : .Cols(11).TextAlign = TextAlignEnum.LeftCenter : .Cols(11).AllowEditing = False

            .AutoSizeCols()
        End With
    End Sub

    Private Sub dgvList_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvList.CellPainting
        If dgvList.Columns(e.ColumnIndex).Name = "delete" AndAlso e.RowIndex >= 0 Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)
            e.Graphics.DrawImage(My.Resources.DELETED_20, CInt((e.CellBounds.Width / 2) - (My.Resources.DELETED_20.Width / 2)) + e.CellBounds.X, CInt((e.CellBounds.Height / 2) - (My.Resources.DELETED_20.Height / 2)) + e.CellBounds.Y)
            e.Handled = True
        End If

        If dgvList.Columns(e.ColumnIndex).Name = "edit" AndAlso e.RowIndex >= 0 Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)
            e.Graphics.DrawImage(My.Resources.icons8_edit_20, CInt((e.CellBounds.Width / 2) - (My.Resources.icons8_edit_20.Width / 2)) + e.CellBounds.X, CInt((e.CellBounds.Height / 2) - (My.Resources.icons8_edit_20.Height / 2)) + e.CellBounds.Y)
            e.Handled = True
        End If

        If dgvList.Columns(e.ColumnIndex).Name = "PrintDeklarasi" AndAlso e.RowIndex >= 0 Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)
            e.Graphics.DrawImage(My.Resources.PRINTF1, CInt((e.CellBounds.Width / 2) - (My.Resources.PRINTF1.Width / 2)) + e.CellBounds.X, CInt((e.CellBounds.Height / 2) - (My.Resources.PRINTF1.Height / 2)) + e.CellBounds.Y)
            e.Handled = True
        End If

        If dgvList.Columns(e.ColumnIndex).Name = "PrintInvoice" AndAlso e.RowIndex >= 0 Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)
            e.Graphics.DrawImage(My.Resources.PRINTF2, CInt((e.CellBounds.Width / 2) - (My.Resources.PRINTF2.Width / 2)) + e.CellBounds.X, CInt((e.CellBounds.Height / 2) - (My.Resources.PRINTF2.Height / 2)) + e.CellBounds.Y)
            e.Handled = True
        End If

        If dgvList.Columns(e.ColumnIndex).Name = "Detail" AndAlso e.RowIndex >= 0 Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)
            e.Graphics.DrawImage(My.Resources.find20, CInt((e.CellBounds.Width / 2) - (My.Resources.find20.Width / 2)) + e.CellBounds.X, CInt((e.CellBounds.Height / 2) - (My.Resources.find20.Height / 2)) + e.CellBounds.Y)
            e.Handled = True
        End If

        If dgvList.Columns(e.ColumnIndex).Name = "Restore" AndAlso e.RowIndex >= 0 Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)
            e.Graphics.DrawImage(My.Resources.icons8_restart_20, CInt((e.CellBounds.Width / 2) - (My.Resources.icons8_restart_20.Width / 2)) + e.CellBounds.X, CInt((e.CellBounds.Height / 2) - (My.Resources.icons8_restart_20.Height / 2)) + e.CellBounds.Y)
            e.Handled = True
        End If
    End Sub

    Private Sub LoadData()
        Try
            Dim dt As DataTable = New DataTable
            Dim SQL As String
            Dim i As Integer = 1
            Dim sql2 As String = ""

            If chkTransDate.Checked = True Then
                sql2 = Modul_RMP.Func.SetCondition(sql2, " CONVERT(DATETIME,CONVERT(VARCHAR,TglTransaksi,103),103) BETWEEN CONVERT (DATETIME,'" & DTPStart.Value & "',103) AND CONVERT(DATETIME,'" & DTPEnd.Value & "',103)")
            End If

            If chkDoDate.Checked = True Then
                sql2 = Modul_RMP.Func.SetCondition(sql2, " CONVERT(DATETIME,CONVERT(VARCHAR,TglTransfer,103),103) BETWEEN CONVERT (DATETIME,'" & dt1.Value & "',103) AND CONVERT(DATETIME,'" & dt2.Value & "',103)")
            End If

            If chknoinvoice.Checked = True Then
                sql2 = Modul_RMP.Func.SetCondition(sql2, " TransID  like '%" & txtinvoice.Text & "%'")
            End If

            SQL = "SELECT B.TransID,TglTransaksi,TglTransfer,b.Bank as bank_kirim,A.JenisBank as bank_toko,a.NamaRekToko2,a.NoRekToko,sum(bayar_rupiah) as bayar_rupiah,(select sum(bayar_rupiah) from vwpengajuanpoindtl where TransactionID = B.TransID) as total_bayar_rupiah,B.CreatedBy 
                    FROM vwpengajuanpoindtl A INNER JOIN TblTrnBuktiTransferToko B ON A.TransactionID = B.TransID 
                    WHERE B.TransID IS NOT NULL AND status_pengajuan = 2 " & IIf(sql2 = "", "", " AND " & sql2) & " 
                    group by B.TransID,TglTransaksi,TglTransfer,A.JenisBank,B.CreatedBy,b.Bank,a.NamaRekToko2,a.NoRekToko ORDER BY TglTransaksi ASC"

            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, SQL)

            fg.Rows.Count = 1
            If dt.Rows.Count > 0 Then
                With fg
                    For Each row As DataRow In dt.Rows
                        .AddItem(i)
                        .Item(i, 1) = row("TransID")
                        .Item(i, 2) = row("TglTransaksi")
                        .Item(i, 3) = row("TglTransfer")
                        .Item(i, 4) = row("bank_kirim")
                        .Item(i, 5) = row("bank_toko")
                        .Item(i, 6) = row("NamaRekToko2")
                        .Item(i, 7) = row("NoRekToko")
                        .Item(i, 8) = row("bayar_rupiah")
                        .Item(i, 9) = row("total_bayar_rupiah")
                        .Item(i, 10) = row("CreatedBy")

                        Dim style As C1.Win.C1FlexGrid.CellStyle = Me.fg.Styles.Add("style")
                        style.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
                        Me.fg.SetCellImage(i, 11, My.Resources.PRINTF2)
                        Me.fg.SetCellStyle(i, 11, style)

                        i += 1
                    Next

                    .AutoSizeCols()

                    'atur no ulang
                    For j = 1 To .Rows.Count - 1
                        If j = 1 Then
                            .Item(j, 0) = j
                        Else
                            If .Item(j, 1) = .Item(j - 1, 1) Then
                                .Item(j, 0) = .Item(j - 1, 0)
                            Else
                                .Item(j, 0) = .Item(j - 1, 0) + 1
                            End If
                        End If
                    Next
                End With
            Else
                dgvList.Rows.Clear()
                MsgBox("Data Tidak ditemukan ! ", MsgBoxStyle.Information)
                Exit Sub
            End If
            DB.CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub LoadData2()
        Try
            Dim SQL As String, i As Integer
            Dim sql2 As String = ""

            If chkTransDate.Checked = True Then
                sql2 = Modul_RMP.Func.SetCondition(sql2, " CONVERT(DATETIME,CONVERT(VARCHAR,TglTransaksi,103),103) BETWEEN CONVERT (DATETIME,'" & DTPStart.Value & "',103) AND CONVERT(DATETIME,'" & DTPEnd.Value & "',103)")
            End If

            If chkDoDate.Checked = True Then
                sql2 = Modul_RMP.Func.SetCondition(sql2, " CONVERT(DATETIME,CONVERT(VARCHAR,TglTransfer,103),103) BETWEEN CONVERT (DATETIME,'" & dt1.Value & "',103) AND CONVERT(DATETIME,'" & dt2.Value & "',103)")
            End If

            If chknoinvoice.Checked = True Then
                sql2 = Modul_RMP.Func.SetCondition(sql2, " TransID  like '%" & txtinvoice.Text & "%'")
            End If

            SQL = "SELECT B.TransID,TglTransaksi,TglTransfer,b.Bank as bank_kirim,A.JenisBank as bank_toko,a.NamaRekToko2,a.NoRekToko,sum(bayar_rupiah) as bayar_rupiah,(select sum(bayar_rupiah) from vwpengajuanpoindtl where TransactionID = B.TransID) as total_bayar_rupiah,B.CreatedBy 
                    FROM vwpengajuanpoindtl A INNER JOIN TblTrnBuktiTransferToko B ON A.TransactionID = B.TransID 
                    WHERE B.TransID IS NOT NULL AND status_pengajuan = 2 " & IIf(sql2 = "", "", " AND " & sql2) & " 
                    group by B.TransID,TglTransaksi,TglTransfer,A.JenisBank,B.CreatedBy,b.Bank,a.NamaRekToko2,a.NoRekToko ORDER BY TglTransaksi ASC"

            Using koneksi As New SqlCommand(SQL, DB.OpenConnection(StrConnRMPApp))
                Using DR = koneksi.ExecuteReader()
                    If DR.HasRows Then
                        dgvList.RowCount = 0
                        While DR.Read
                            With dgvList
                                .Rows.Add()

                                .Item("no", i).Value = i + 1
                                .Item("TransactionID", i).Value = DR!TransID
                                .Item("TglTransaksi", i).Value = Format(DR!TglTransaksi, "dd/MM/yyyy")
                                .Item("TglTransfer", i).Value = Format(DR!TglTransfer, "dd/MM/yyyy")
                                .Item("CreatedBy", i).Value = DR!CreatedBy
                                .Item("Bank", i).Value = DR!bank_kirim
                                .Item("bank_toko", i).Value = DR!bank_toko
                                .Item("nama_rekening", i).Value = DR!NamaRekToko2
                                .Item("no_rekening", i).Value = DR!NoRekToko
                                .Item("Total", i).Value = DR!bayar_rupiah
                                .Item("total_akhir", i).Value = DR!total_bayar_rupiah

                                Dim dgvImageColumn As New DataGridViewImageColumn
                                dgvImageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch

                                With Me.dgvList
                                    .RowsDefaultCellStyle.BackColor = Color.White
                                    .AlternatingRowsDefaultCellStyle.BackColor = Color.Azure
                                    .Rows(i).Cells("No").Style.BackColor = Color.FromArgb(240, 240, 240)
                                End With
                            End With
                            i += 1
                        End While
                    Else
                        dgvList.Rows.Clear()
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

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadData()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        With FrmTrnBuktiTrfPengajuanPoin
            Call .clear(True)
            .perintah = "Add"
            .dtpInvoice.Focus()
            .cmdEnabled(False)
            .enableds(True)
            .Show()
        End With
    End Sub

    Private Sub dgvList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellClick
        'With FrmTrnBuktiTrfPengajuanPoin
        Select Case dgvList.CurrentCell.ColumnIndex

                'Case 12
                '    If Val(dgvList.Item("FlagPrint", dgvList.CurrentRow.Index).Value) = 1 Then
                '        MessageBox.Show("Tidak Dapat Edit Data Sudah Complete (Print Deklarasi) !", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '        Exit Sub
                '    Else
                '        .Show()
                '        .loaddataFind(dgvList.Item("TransactionID", dgvList.CurrentRow.Index).Value, dgvList.Item("Fac", dgvList.CurrentRow.Index).Value)
                '        .cmdEnabled(False)
                '        .perintah = "Edit"
                '        .enableds(True)
                '        .txtinvoice.Enabled = False
                '        .dtp1.Enabled = False
                '        .dtp2.Enabled = False
                '        '.dtptrf.Enabled = False
                '        .btnsave.Visible = True
                '        .btnexit.Enabled = True
                '    End If

                'Case 13
                '    .btnexit.Enabled = True
                '    Dim A As String
                '    A = dgvList.Item("TransactionID", dgvList.CurrentRow.Index).Value
                '    A = A

                '    Dim result As DialogResult = MessageBox.Show("Yakin Delete Invoice '" & A & "' ", "caption", MessageBoxButtons.YesNoCancel)

                '    If result = DialogResult.Cancel Then
                '        MessageBox.Show("Cancel pressed")
                '    ElseIf result = DialogResult.Yes Then
                '        Dim Koneksi As SqlConnection = DB.OpenConnection(StrConnRMPApp)
                '        Dim Transaksi As SqlTransaction
                '        Transaksi = Koneksi.BeginTransaction
                '        Me.Cursor = Cursors.WaitCursor

                '        Try
                '            If DelVerifikasiUM(Koneksi, Transaksi) = False Then
                '                Transaksi.Rollback()
                '                Transaksi = Nothing
                '                Me.Cursor = Cursors.Default
                '                MessageBox.Show("Delete Data Hdr Gagal !", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '                Exit Sub
                '            End If

                '            Transaksi.Commit()
                '            Me.Cursor = Cursors.Default
                '            MessageBox.Show("Delete Data Berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '            LoadData()
                '        Catch ex As Exception
                '            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '            Transaksi.Rollback()
                '            Koneksi.Close()
                '            Me.Cursor = Cursors.Default
                '        Finally
                '            Koneksi.Close()
                '            Me.Cursor = Cursors.Default
                '        End Try
                '    End If

            Case 9
                Try
                    Dim PDFUPLOADBOX As String
                    PDFUPLOADBOX = "\\192.168.12.11\buktitransferpointoko\" & dgvList.Item("Bank", dgvList.CurrentRow.Index).Value + "-" + Trim(dgvList.Item("TransactionID", dgvList.CurrentRow.Index).Value) & ".pdf"
                    Process.Start(PDFUPLOADBOX)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "File Tidak Ditemukan Pilih File terlebih dahulu", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Cursor = Cursors.Default
                Finally
                    Me.Cursor = Cursors.Default
                End Try

                'Case 16
                '    .Show()
                '    .loaddataFind(dgvList.Item("TransactionID", dgvList.CurrentRow.Index).Value, dgvList.Item("Fac", dgvList.CurrentRow.Index).Value)
                '    .cmdEnabled(False)
                '    .btnsave.Visible = False
                '    .enableds(False)
                '    .btnexit.Enabled = True
                '    .txtinvoice.Enabled = False
                '    .dtp1.Enabled = False
                '    .dtp2.Enabled = False
                '    .dtpInvoice.Enabled = False

        End Select
        'End With
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click
        With fg
            If .Rows.Count > 1 Then
                If .Col = 11 Then
                    Try
                        Dim PDFUPLOADBOX As String
                        PDFUPLOADBOX = "\\192.168.12.11\buktitransferpointoko\" & .Item(.RowSel, 4) & "-" & .Item(.RowSel, 1) & ".pdf"
                        Process.Start(PDFUPLOADBOX)
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "File Tidak Ditemukan Pilih File terlebih dahulu", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.Cursor = Cursors.Default
                    Finally
                        Me.Cursor = Cursors.Default
                    End Try
                End If
            End If
        End With
    End Sub
End Class