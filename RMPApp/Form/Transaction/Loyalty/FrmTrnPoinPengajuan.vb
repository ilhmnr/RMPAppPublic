Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Windows.Forms
Imports C1.Win.C1FlexGrid
Imports Microsoft.VisualBasic

Public Class FrmTrnPoinPengajuan
    Public AT As String = "RMPApplication ©" & Format(Year(Now))
    Dim Conn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim Kode As String
    Dim str As String
    
    Public perintah As String
    Dim NoTransUpahBongkar_ As String
    Dim NoInvoice_ As String

    Private Sub FrmTrnPoinPengajuan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtp1.Value = Format(Now, "dd/MM/yy")
        dtp2.Value = Format(Now, "dd/MM/yy")
        dtpInvoice.Value = Format(Now, "dd/MM/yy")
        dtpPembayaran.Value = Format(Now, "dd/MM/yy")

        btnexit.Enabled = True
        rdp1.Checked = True
        rdp2.Checked = False

        HeaderFG()
        perintah = perintah
        Modul_RMP.Combo.SettokoPancang(cmbToko)
    End Sub

    Public Sub cmdEnabled(flag As Boolean)
        btnsave.Enabled = Not flag
        btnexit.Enabled = flag
    End Sub


    Public Sub HeaderFG()
        Dim txt As CellRange
        With fg
            .AllowEditing = True
            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular)
            .Cols.Count = 22
            .Cols.Fixed = 1
            .Cols.Frozen = 5
            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(209, 229, 252)

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 1
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "N0" : .Cols(0).Name = "No" : .Cols(0).Width = 50
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "NO TRANSAKSI" : .Cols(1).Name = "NOTRANSAKSI" : .Cols(1).TextAlign = TextAlignEnum.CenterCenter : .Cols(1).AllowEditing = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "TGL TRANSAKSI" : .Cols(2).Name = "TGLTRANSAKSI" : .Cols(2).TextAlign = TextAlignEnum.CenterCenter : .Cols(2).AllowEditing = False
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "JAM TRANSAKSI" : .Cols(3).Name = "JAMTRANSAKSI" : .Cols(3).TextAlign = TextAlignEnum.CenterCenter : .Cols(3).AllowEditing = False : .Cols(3).Visible = False
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "NAMA TOKO" : .Cols(4).Name = "NAMATOKO" : .Cols(4).TextAlign = TextAlignEnum.LeftCenter : .Cols(4).AllowEditing = False
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "ALAMAT TOKO" : .Cols(5).Name = "ALAMATTOKO" : .Cols(5).TextAlign = TextAlignEnum.LeftCenter : .Cols(5).AllowEditing = False
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "PETANI ID" : .Cols(6).Name = "PETANIID" : .Cols(6).TextAlign = TextAlignEnum.LeftCenter : .Cols(6).AllowEditing = False
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "NAMA PETANI" : .Cols(7).Name = "NAMAPETANI" : .Cols(7).TextAlign = TextAlignEnum.LeftCenter : .Cols(7).AllowEditing = False
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "ALAMAT" : .Cols(8).Name = "ALAMAT" : .Cols(8).TextAlign = TextAlignEnum.LeftCenter : .Cols(8).AllowEditing = False
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "ITEM ID" : .Cols(9).Name = "ITEMID" : .Cols(9).TextAlign = TextAlignEnum.LeftCenter : .Cols(9).AllowEditing = False : .Cols(9).Visible = False
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "ITEM NAME" : .Cols(10).Name = "ITEMNAME" : .Cols(10).TextAlign = TextAlignEnum.LeftCenter : .Cols(10).AllowEditing = False
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "QTY" : .Cols(11).Name = "QTY" : .Cols(11).TextAlign = TextAlignEnum.RightCenter : .Cols(11).AllowEditing = False : .Cols(11).Format = "#,###0"
            txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "SATUAN" : .Cols(12).Name = "SATUAN" : .Cols(12).TextAlign = TextAlignEnum.CenterCenter : .Cols(12).AllowEditing = False
            txt = .GetCellRange(0, 13, 0, 13) : txt.Data = "POIN" : .Cols(13).Name = "POIN" : .Cols(13).TextAlign = TextAlignEnum.RightCenter : .Cols(13).AllowEditing = False : .Cols(13).Format = "#,###0"
            txt = .GetCellRange(0, 14, 0, 14) : txt.Data = "RUPIAH" : .Cols(14).Name = "RUPIAH" : .Cols(14).TextAlign = TextAlignEnum.RightCenter : .Cols(14).AllowEditing = False : .Cols(14).Format = "#,###0"
            txt = .GetCellRange(0, 15, 0, 15) : txt.Data = "ID" : .Cols(15).Name = "ID" : .Cols(15).TextAlign = TextAlignEnum.RightCenter : .Cols(15).AllowEditing = False : .Cols(15).Visible = False
            txt = .GetCellRange(0, 16, 0, 16) : txt.Data = "IDTOKO" : .Cols(16).Name = "ID_TOKO" : .Cols(16).TextAlign = TextAlignEnum.CenterCenter : .Cols(16).AllowEditing = False : .Cols(16).Visible = False

            txt = .GetCellRange(0, 17, 0, 17) : txt.Data = "NoRekToko" : .Cols(17).Name = "NoRekToko" : .Cols(17).TextAlign = TextAlignEnum.LeftCenter : .Cols(17).AllowEditing = False
            txt = .GetCellRange(0, 18, 0, 18) : txt.Data = "NamaRekToko" : .Cols(18).Name = "NamaRekToko" : .Cols(18).TextAlign = TextAlignEnum.LeftCenter : .Cols(18).AllowEditing = False
            txt = .GetCellRange(0, 19, 0, 19) : txt.Data = "Bank" : .Cols(19).Name = "Bank" : .Cols(19).TextAlign = TextAlignEnum.CenterCenter : .Cols(19).AllowEditing = False

            txt = .GetCellRange(0, 20, 0, 20) : txt.Data = "Ajukan" : .Cols(20).Name = "Ajukan" : .Cols(20).TextAlign = TextAlignEnum.CenterCenter : .Cols(20).AllowEditing = True
            txt = .GetCellRange(0, 21, 0, 21) : txt.Data = "Foto" : .Cols(21).Name = "Foto" : .Cols(21).TextAlign = TextAlignEnum.CenterCenter : .Cols(21).Visible = False

            .AutoSizeCols()
        End With
    End Sub

    Public Sub loaddata(noinvoice As String)
        Dim i As Integer = 1
        Dim sql As String = ""
        Dim dt As DataTable = New DataTable()

        Try
            Dim sql2 As String = ""
            If perintah = "Add" Then
                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "  SELECT * from RMPApp..vwPengajuanPoinDtlBefore where status_pengajuan =0   and  CAST(tanggal_pengajuan AS DATE)  between '" & Format(dtp1.Value, "yyyy-MM-dd") & "'  and '" & Format(dtp2.Value, "yyyy-MM-dd") & "' and ID_Toko ='" & cmbToko.SelectedValue & "' ")
            Else
                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "  SELECT * from RMPApp..vwPengajuanPoinDtl where status_pengajuan >=1   and notranspengajuan='" & noinvoice & "' ")
            End If

            If dt.Rows.Count > 0 Then
                With fg
                    Call ui.HapusGrid(1, fg)
                    For Each row As DataRow In dt.Rows
                        .AddItem(i)
                        .Item(i, "No") = i
                        .Item(i, "NOTRANSAKSI") = row.Item("kode_pengajuan")
                        .Item(i, "TGLTRANSAKSI") = row.Item("tanggal_pengajuan")
                        .Item(i, "JAMTRANSAKSI") = row.Item("tanggal_pengajuan")
                        .Item(i, "NAMATOKO") = row.Item("nama_toko")
                        .Item(i, "ALAMATTOKO") = row.Item("alamat_toko")
                        .Item(i, "PETANIID") = row.Item("KodeSup")
                        .Item(i, "NAMAPETANI") = row.Item("NamaSup")
                        .Item(i, "ALAMAT") = row.Item("Alamat")
                        .Item(i, "ITEMID") = row.Item("item_id")
                        .Item(i, "ITEMNAME") = row.Item("nama_item")
                        .Item(i, "QTY") = row.Item("qty")
                        .Item(i, "SATUAN") = row.Item("satuan")
                        .Item(i, "POIN") = row.Item("bayar_poin")
                        .Item(i, "RUPIAH") = row.Item("bayar_rupiah")
                        .Item(i, "ID_TOKO") = row.Item("ID_Toko")
                        .Item(i, "NoRekToko") = row.Item("NoRekToko")
                        .Item(i, "NamaRekToko") = row.Item("NamaRekToko")
                        .Item(i, "Bank") = row.Item("Bank")
                        .Item(i, "ID") = row.Item("id")
                        .Item(i, "Ajukan") = True
                        .Item(i, "Foto") = row.Item("Foto_Transaksi")

                        If perintah <> "Add" Then
                            cmbToko.SelectedValue = row.Item("ID_Toko")
                            txtinvoice.Text = row.Item("NoInvoice")
                            dtp1.Value = row.Item("tglpengajuan1")
                            dtp2.Value = row.Item("tglpengajuan2")
                            dtpInvoice.Value = row.Item("tglInvoice")
                        End If

                        If row.Item("pengajuan") = "PSG" Then
                            rdp1.Checked = True
                            rdp2.Checked = False
                        End If

                        If row.Item("pengajuan") = "RSUP" Then
                            rdp1.Checked = False
                            rdp2.Checked = True
                        End If

                        i = i + 1
                    Next
                    .AutoSizeCols()
                End With
                GrandTotal()
            Else
                MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
            End If
        Catch EX As Exception
            MsgBox(EX.Message)
        End Try
    End Sub

    Private Sub GrandTotal()
        With fg
            .Tree.Column = 0
            .Tree.Style = TreeStyleFlags.CompleteLeaf
            .Subtotal(AggregateEnum.Clear)
            .Subtotal(AggregateEnum.Sum, -1, -1, 11, "TOTAL")
            .Subtotal(AggregateEnum.Sum, 1, 1, 11, "Pengajuan-{0}")
            .Subtotal(AggregateEnum.Sum, -1, -1, 13)
            .Subtotal(AggregateEnum.Sum, 1, 1, 13)
            .Subtotal(AggregateEnum.Sum, -1, -1, 14)
            .Subtotal(AggregateEnum.Sum, 1, 1, 14)
            .AutoSizeCols()
        End With
        ColorSubTotal()
    End Sub

    Private Sub ColorSubTotal()
        Dim cs As C1.Win.C1FlexGrid.CellStyle
        With fg
            cs = .Styles(C1.Win.C1FlexGrid.CellStyleEnum.GrandTotal)
            'cs.BackColor = Color.DimGray
            cs.Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Bold)

            cs = .Styles(C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0)
            'cs.BackColor = Color.FromArgb(156, 206, 255)
            cs.Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Regular)
        End With
    End Sub

    Private Function spSavePengajuanPoin(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal Nonvoice As String, ByVal NoPengajuan As String, ByVal NoRekToko As String, ByVal NamaRekToko As String, ByVal Bank As String) As Boolean
        Dim pengajuan As String
        If rdp1.Checked = True Then
            pengajuan = "PSG"
        Else
            pengajuan = "RSUP"
        End If
        Dim MyCMD As New SqlCommand
        Try
            With MyCMD
                .Connection = Conn
                .CommandType = CommandType.StoredProcedure
                .CommandText = "RMPApp..spSavePengajuanPoin"
                .Transaction = Trans
                .Parameters.Add("@NoInvoice", SqlDbType.VarChar).Value = NoInvoice_
                .Parameters.Add("@NoPengajuan", SqlDbType.VarChar).Value = NoPengajuan
                .Parameters.Add("@NoRekToko", SqlDbType.VarChar).Value = NoRekToko
                .Parameters.Add("@NamaRekToko", SqlDbType.VarChar).Value = NamaRekToko
                .Parameters.Add("@Bank", SqlDbType.VarChar).Value = Bank
                .Parameters.Add("@createdbypengajuan", SqlDbType.VarChar).Value = ClsSession.UserID
                .Parameters.Add("@createddatepengajuan", SqlDbType.Date).Value = dtpInvoice.Value
                .Parameters.Add("@tglpengajuanpembayaran", SqlDbType.DateTime).Value = dtpPembayaran.Value
                .Parameters.Add("@pengajuan", SqlDbType.VarChar).Value = pengajuan
                .Parameters.Add(New SqlParameter("@Error", SqlDbType.VarChar, 200, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
                .ExecuteNonQuery()
                .Dispose()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message & " infosp : " & MyCMD.Parameters("@Error").Value)
            
            
            Return False
        End Try
        Return True
    End Function


    Private Function spSavePengajuanPoinHdr(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        Dim pengajuan As String
        If rdp1.Checked = True Then
            pengajuan = "PSG"
        Else
            pengajuan = "RSUP"
        End If
        Dim MyCMD As New SqlCommand
        Try
            With MyCMD
                spSavePengajuanPoinHdr = False
                Dim MyCon As SqlConnection = Conn
                Dim MyConTrans As SqlTransaction = Trans
                .Connection = MyCon
                .CommandType = CommandType.StoredProcedure
                .CommandText = "RMPApp..spSavePengajuanPoinHdr"
                .Transaction = MyConTrans
                .Parameters.Add("@RETURN_VALUE", SqlDbType.SmallInt).Direction = ParameterDirection.ReturnValue
                .Parameters.Add("@Perintah", SqlDbType.VarChar, 10).Value = perintah
                .Parameters.Add(New SqlParameter("@NoInvoice", SqlDbType.VarChar, 20, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
                .Parameters.Add("@NoInvoice2", SqlDbType.VarChar, 30).Value = txtinvoice.Text
                .Parameters.Add("@tglinvoice", SqlDbType.DateTime).Value = dtpInvoice.Value
                .Parameters.Add("@tglpengajuan1", SqlDbType.DateTime).Value = dtp1.Value
                .Parameters.Add("@tglpengajuan2", SqlDbType.DateTime).Value = dtp2.Value
                .Parameters.Add("@tglpengajuanpembayaran", SqlDbType.DateTime).Value = dtpPembayaran.Value
                .Parameters.Add("@IDToko", SqlDbType.Int).Value = cmbToko.SelectedValue
                .Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
                .Parameters.Add("@Pengajuan", SqlDbType.VarChar, 10).Value = pengajuan
                .Parameters.Add(New SqlParameter("@Error", SqlDbType.VarChar, 200, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
                .ExecuteNonQuery()

                If perintah = "Add" Then
                    NoInvoice_ = .Parameters("@NoInvoice").Value
                Else
                    NoInvoice_ = .Parameters("@NoInvoice2").Value
                End If
                .Dispose()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message & " infosp : " & MyCMD.Parameters("@Error").Value)
            Return False
        End Try
        Return True
    End Function

    Private Sub btnExcel_Click(sender As Object, e As EventArgs)
        Dim filename As String
        Me.SaveFileDialog.ShowDialog()
        filename = SaveFileDialog.FileName
        'Me.fg.SaveExcel(filename & ".xls", "Sheet1", FileFlags.IncludeFixedCells)
        Me.fg.SaveExcel(filename & ".xls", "Sheet1", FileFlags.IncludeFixedCells)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Dispose()
    End Sub

    Private Sub btnLoaddata_Click(sender As Object, e As EventArgs) Handles btnLoaddata.Click
        If perintah = "Add" Then
            loaddata("")
        End If
    End Sub

    Private Sub btnexit_Click(sender As Object, e As EventArgs) Handles btnexit.Click
        Me.Dispose()
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim Koneksi As SqlConnection = DB.OpenConnection(StrConnRMPApp)
        Dim Transaksi As SqlTransaction
        Transaksi = Koneksi.BeginTransaction
        Me.Cursor = Cursors.WaitCursor
        Try
            If cmbToko.Text = "" Then
                MessageBox.Show("Pilih Toko", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Cursor = Cursors.Default
                Exit Try
            End If

            If perintah = "Add" Then
                'If NOREFFPREMI(txtinvoice.Text) = "1" Then
                '    MessageBox.Show("No Invoice Sudah Ada !", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '    Exit Try
                'End If
            End If

            Dim i As Integer

            If spSavePengajuanPoinHdr(Koneksi, Transaksi) = False Then
                Transaksi.Rollback()
                Transaksi = Nothing
                Me.Cursor = Cursors.Default
                MessageBox.Show("Simpan Data Hdr Gagal !", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Try
            End If

            If perintah = "Add" Then
                With fg
                    For i = 1 To .Rows.Count - 1
                        If .Item(i, 20) = True And .Item(i, 1) <> "" Then
                            If spSavePengajuanPoin(Koneksi, Transaksi, NoInvoice_,
                                            IIf(IsDBNull(.Item(i, 1)), "", .Item(i, 1)), IIf(IsDBNull(.Item(i, 17)), "", .Item(i, 17)), IIf(IsDBNull(.Item(i, 18)), "", .Item(i, 18)), IIf(IsDBNull(.Item(i, 19)), "", .Item(i, 19))) = False Then
                                Transaksi.Rollback()
                                MsgBox("Simpan Data PancangDtl Gagal", vbExclamation, "Save Data - " & AT)
                                Exit Try
                            End If
                        End If
                    Next i
                End With
            End If

            Transaksi.Commit()
            Me.Cursor = Cursors.Default
            MessageBox.Show("Simpan Data Berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Call clear(True)
            perintah = ""
            'cmdEnabled(True)
            Me.Dispose()
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

    Private Sub cbxAllApproved_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAllApproved.CheckedChanged
        If cbxAllApproved.Checked = True Then
            For i = 3 To fg.Rows.Count - 1
                fg.SetCellCheck(i, 17, C1.Win.C1FlexGrid.CheckEnum.Checked)
            Next
        Else
            For i = 3 To fg.Rows.Count - 1
                fg.SetCellCheck(i, 17, C1.Win.C1FlexGrid.CheckEnum.Unchecked)
            Next
        End If
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click

        Dim namaFoto As String = TryCast(fg.Item(fg.Row, "FOTO"), String)

        If String.IsNullOrEmpty(namaFoto) Then Exit Sub

        Dim url As String = UrlApiNotaPancang &
        "ImagesPoinTransaksi&filename=" & namaFoto &
        ".jpg&flag=notapancang"

        Try
            Using client As New WebClient
                client.Headers.Add("User-Agent", "VB App")

                Using stream As IO.Stream = client.OpenRead(url)
                    Using img As Image = Image.FromStream(stream)
                        Using frm As New FrmFotoView
                            frm.TampilkanImage(img)
                            frm.ShowDialog()
                        End Using
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MsgBox("Gagal membuka foto: " & ex.Message, vbExclamation, AT)
        End Try

    End Sub

    Private Sub fg_DoubleClick(sender As Object, e As EventArgs) Handles fg.DoubleClick

        If fg.Col <> 10 Then Exit Sub

        Dim namaFoto As String = TryCast(fg.Item(fg.Row, "FOTO"), String)

        If String.IsNullOrEmpty(namaFoto) Then
            MsgBox("Foto tidak tersedia!", vbExclamation, AT)
            Exit Sub
        End If

        Dim url As String = UrlApiNotaPancang &
        "ImagesPoinTransaksi&filename=" & namaFoto &
        ".jpg&flag=notapancang"

        Using client As New WebClient
            client.Headers.Add("User-Agent", "VB App")

            Try
                Using stream As IO.Stream = client.OpenRead(url)
                    Using img As Image = Image.FromStream(stream)
                        Using frm As New FrmFotoView
                            frm.TampilkanImage(img)
                            frm.ShowDialog()
                        End Using
                    End Using
                End Using

            Catch ex As Exception
                MsgBox("Gagal membuka foto: " & ex.Message, vbExclamation, AT)
            End Try
        End Using

    End Sub
End Class