Imports System.Data.SqlClient
Imports System.IO

Public Class FrmTrnBuktiTrfPengajuanPoin
    Public AT As String = "RMPApplication ©" & Format(Year(Now))
    Dim Conn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim Kode As String
    Dim str As String
    
    Public perintah As String
    Dim NoTransUpahBongkar_ As String
    Dim NoInvoice_ As String

    Private Sub FrmTrnBuktiTrfPengajuanPoin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtp1.Value = Format(Now, "dd/MM/yy")
        dtp2.Value = Format(Now, "dd/MM/yy")
        dtptrf.Value = Format(Now, "dd/MM/yy")
        dtpInvoice.Value = Format(Now, "dd/MM/yy")
        btnexit.Enabled = True

        Call SetBank22(cmbBank)

        Dim cmdNs4 As String
        On Error GoTo ErrHandler
        cmdNs4 = "net use \\192.168.12.11\buktitransferpointoko /user:npwp npwp@2022"
        Shell("cmd.exe /c " & cmdNs4)
ErrHandler:

    End Sub

    Public Sub SetBank22(ByVal cbo As ComboBox)
        cbo.Items.Clear()
        Dim dt As DataTable = New DataTable()
        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select Distinct JenisBank from RSUPAccounting..TblRMMstRekRM WHERE JenisBank IN ('BNI','MANDIRI','BRI')")

        With cbo
            .DataSource = dt
            .DisplayMember = "JenisBank"
            .ValueMember = "JenisBank"
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub loaddata()
        Try
            Dim SQL As String, i As Integer
            Dim bank As String = "Bank"

            If chkMandiri.Checked Then
                bank &= ",MANDIRI"
            End If
            If chkBni.Checked Then
                bank &= ",BNI"
            End If
            If chkBri.Checked Then
                bank &= ",BRI"
            End If

            bank = Replace(bank, ",", "','")

            SQL = "SELECT * FROM vwpengajuanpoindtl WHERE status_pengajuan = 1 and TransactionID is null AND JenisBank IN ('" & bank & "') AND CAST(tanggal_pengajuan AS DATE) BETWEEN '" & Format(dtp1.Value, "yyyy-MM-dd") & "' AND '" & Format(dtp2.Value, "yyyy-MM-dd") & "' " & IIf(TxtNoInvoice.Text <> "", " And NoInvoice='" & TxtNoInvoice.Text & "' ", "") & " ORDER BY tanggal_pengajuan"

            Using koneksi As New SqlCommand(SQL, DB.OpenConnection(StrConnRMPApp))
                Using DR = koneksi.ExecuteReader()
                    If DR.HasRows Then
                        dgvList.Rows.Clear()
                        While DR.Read
                            With dgvList
                                .Rows.Add()

                                .Item("no", i).Value = i + 1
                                .Item("DetailID", i).Value = DR!kode_pengajuan
                                .Item("TanggalPengajuan", i).Value = DR!tanggal_pengajuan
                                .Item("IDToko", i).Value = DR!ID_Toko
                                .Item("NamaToko", i).Value = DR!Nama_Toko
                                .Item("IDSupplier", i).Value = DR!KodeSup
                                .Item("Supplier", i).Value = DR!NamaSup
                                .Item("JenisBank", i).Value = DR!JenisBank
                                .Item("RekTujuan", i).Value = DR!NoRekToko
                                .Item("NamaRek", i).Value = DR!NamaRekToko
                                .Item("Amount", i).Value = DR!bayar_rupiah
                                .Item("NoInvoice", i).Value = DR!noinvoice
                                .Item("IndTF", i).Value = True

                                With Me.dgvList
                                    .RowsDefaultCellStyle.BackColor = Color.White
                                    .AlternatingRowsDefaultCellStyle.BackColor = Color.Azure
                                    .Rows(i).Cells("No").Style.BackColor = Color.FromArgb(240, 240, 240)
                                End With
                            End With
                            i += 1
                        End While

                        For Each row As DataGridViewRow In dgvList.Rows
                            row.Cells("HapusBaris").Value = My.Resources.DELETED_20 ' Replace with your image resource
                        Next

                        dgvList.Rows.Add()

                        Call sum()
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

    Public Sub sum()
        Try
            Dim Amount As Double
            Amount = 0

            For i = 0 To dgvList.RowCount - 2
                Amount += (If(Val(dgvList.Rows(i).Cells("Amount").Value()) = 0, 0, Convert.ToDouble(dgvList.Rows(i).Cells("Amount").Value())))
            Next

            dgvList.Rows(dgvList.RowCount - 1).Cells(0).Value = "Total"
            dgvList.Rows(dgvList.RowCount - 1).Cells("Amount").Value() = Amount

            Dim red As Integer

            For red = 0 To dgvList.ColumnCount - 1
                dgvList.Rows(dgvList.RowCount - 1).Cells(red).Style.BackColor = Color.FromArgb(110, 160, 244)
                If dgvList.Rows(dgvList.RowCount - 1).Cells(red).Style.BackColor = Color.FromArgb(110, 160, 244) Then
                    dgvList.Rows(dgvList.RowCount - 1).Cells(red).Style.ForeColor = Color.White
                End If
                dgvList.Rows(dgvList.RowCount - 1).Cells(red).ReadOnly = True
            Next red
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Total", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Default
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function spTrnBuktiTrTokoHdr(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        Dim MyCMD As New SqlCommand
        Try
            With MyCMD
                Dim MyCon As SqlConnection = Conn
                Dim MyConTrans As SqlTransaction = Trans
                .Connection = MyCon
                .CommandType = CommandType.StoredProcedure
                .CommandText = "RMPApp..sp_TrnBuktiTrTokoHdr"
                .Transaction = MyConTrans
                .Parameters.Add("@RETURN_VALUE", SqlDbType.SmallInt).Direction = ParameterDirection.ReturnValue
                .Parameters.Add("@Perintah", SqlDbType.VarChar, 10).Value = perintah
                .Parameters.Add("@TransID", SqlDbType.VarChar, 50).Value = Trim(txtinvoice.Text)
                .Parameters.Add("@Tanggal_Transaksi", SqlDbType.DateTime).Value = dtpInvoice.Value
                .Parameters.Add("@Tanggal_Transfer", SqlDbType.DateTime).Value = dtptrf.Value
                .Parameters.Add("@Bank", SqlDbType.VarChar, 10).Value = cmbBank.Text
                .Parameters.Add("@tgl1", SqlDbType.DateTime).Value = dtp1.Value
                .Parameters.Add("@tgl2", SqlDbType.DateTime).Value = dtp2.Value
                .Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
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

    Private Function spTrnBuktiTrTokoDtl(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal I As Integer) As Boolean
        Dim MyCMD As New SqlCommand

        With MyCMD
            spTrnBuktiTrTokoDtl = False
            Dim MyCon As SqlConnection = Conn
            Dim MyConTrans As SqlTransaction = Trans
            .Connection = MyCon
            .Connection = MyCon
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RMPApp..sp_TrnBuktiTrTokoDtl"
            .Transaction = MyConTrans
            .Parameters.Add("@RETURN_VALUE", SqlDbType.SmallInt).Direction = ParameterDirection.ReturnValue
            .Parameters.Add("@NoInvoice", SqlDbType.VarChar, 50).Value = dgvList.Item("DetailID", I).Value
            .Parameters.Add("@TransactionID", SqlDbType.VarChar, 50).Value = Trim(txtinvoice.Text)
            .Parameters.Add(New SqlParameter("@Flag", SqlDbType.SmallInt, 5, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .ExecuteNonQuery()

            If CInt(.Parameters("@Flag").Value) = 0 Then
                .Dispose()
                Exit Function
            End If
            Return True
        End With
    End Function

    Private Sub btnLoaddata_Click(sender As Object, e As EventArgs) Handles btnLoaddata.Click
        dgvList.Rows.Clear()

        If chkMandiri.Checked = False And chkBni.Checked = False And chkBri.Checked = False Then
            MessageBox.Show("Silahkan Pilih Jenis Bank!", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If perintah = "Add" Then
            loaddata()
        End If
    End Sub

    Public Sub clear(flag As Boolean)
        dgvList.Rows.Clear()
        txtinvoice.Text = ""
        perintah = ""
    End Sub

    Public Sub cmdEnabled(flag As Boolean)
        btnedit.Enabled = flag
        btnadd.Enabled = flag
        btnsave.Enabled = Not flag
        btncancel.Enabled = Not flag
        btnexit.Enabled = flag

    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim DATACEKLIST As Integer
        DATACEKLIST = 0

        For i = 0 To dgvList.RowCount - 2
            If (dgvList.Item("Gagal_Transfer", i).Value) = True Or (dgvList.Item("IndTF", i).Value) = True Then
                DATACEKLIST = DATACEKLIST + 1
            End If
        Next i

        If DATACEKLIST = 0 Then
            MessageBox.Show("Ceklist Data yg Berhasil Atau Gagal Transfer", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        Dim result As Integer = MessageBox.Show("Anda Yakin Simpan Data ' " & DATACEKLIST & " ' Item ?!", AT, MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then
            savedata()
        ElseIf result = DialogResult.No Then
            Exit Sub
        End If
    End Sub

    Private Function cekTransID(NoInv As String) As String
        Try
            cekTransID = ""
            Dim connb As New SqlConnection(StrConnRMPApp)
            connb.Open()

            Dim sql As String
            sql = "Select TOP(1)  TransID From  RMPApp..TblTrnBuktiTransferToko  where TransID='" & NoInv & "'"
            Dim cmd2 As New SqlClient.SqlCommand(sql, connb)
            Dim reader As SqlClient.SqlDataReader
            reader = cmd2.ExecuteReader

            If reader.HasRows Then
                If reader.Read() Then
                    cekTransID = "1"
                Else
                    cekTransID = "0"
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Default
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

    Private Sub savedata()
        Dim Koneksi As SqlConnection = DB.OpenConnection(StrConnRMPApp)
        Dim Transaksi As SqlTransaction
        Dim PATH As String
        Transaksi = Koneksi.BeginTransaction
        Me.Cursor = Cursors.WaitCursor

        Try
            If txtinvoice.Text = "" Then
                MessageBox.Show("Isi Invoice", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Cursor = Cursors.Default
                Exit Try
            End If

            If cmbBank.Text = "" Then
                MessageBox.Show("Pilih Bank Kirim", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Cursor = Cursors.Default
                Exit Try
            End If

            If perintah = "Add" Then
                If cekTransID(txtinvoice.Text) = "1" Then
                    MessageBox.Show("TransactionID Sudah Ada lihat data!", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Try
                End If
            End If

            PATH = "\\192.168.12.11\buktitransferpointoko\" & cmbBank.Text + "-" + Trim(txtinvoice.Text) & ".pdf"

            If PATH <> pdfuploadbox.Text Then
                File.Delete(PATH)
                System.IO.File.Copy(pdfuploadbox.Text, PATH, True)
            End If

            If spTrnBuktiTrTokoHdr(Koneksi, Transaksi) = False Then
                Transaksi.Rollback()
                Transaksi = Nothing
                Me.Cursor = Cursors.Default
                MessageBox.Show("Simpan Data Hdr Gagal !", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            For i = 0 To dgvList.RowCount - 2
                If (dgvList.Item("Gagal_Transfer", i).Value) = True Or (dgvList.Item("IndTF", i).Value) = True Then
                    If spTrnBuktiTrTokoDtl(Koneksi, Transaksi, i) = False Then
                        Transaksi.Rollback()
                        Transaksi = Nothing
                        Me.Cursor = Cursors.Default
                        MessageBox.Show("Simpan Data Dtl Gagal!", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                End If
            Next i

            Transaksi.Commit()
            Me.Cursor = Cursors.Default
            MessageBox.Show("Simpan Data Berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call clear(True)
            perintah = ""
            cmdEnabled(True)
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

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        perintah = ""
        perintah = "Add"
        dtpInvoice.Focus()
        cmdEnabled(False)
        Call clear(True)
        enableds(True)
    End Sub

    Public Sub enableds(flag As Boolean)
        txtinvoice.Enabled = flag
        dtpInvoice.Enabled = flag
        dtptrf.Enabled = flag
        dtp1.Enabled = flag
        dtp2.Enabled = flag
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Call clear(True)
        cmdEnabled(True)
    End Sub

    Private Sub btnedit_Click(sender As Object, e As EventArgs) Handles btnedit.Click
        If txtinvoice.Text = "" Then
            MessageBox.Show("Tidak ada data yang di Edit", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        cmdEnabled(False)
        perintah = "Edit"
        txtinvoice.Enabled = False
        enableds(True)
    End Sub

    Private Sub dtp1_ValueChanged(sender As Object, e As EventArgs) Handles dtp1.ValueChanged
        If dgvList.RowCount > 1 Then
            dgvList.Rows.Clear()
        End If
    End Sub

    Private Sub dtp2_ValueChanged(sender As Object, e As EventArgs) Handles dtp2.ValueChanged
        If dgvList.RowCount > 1 Then
            dgvList.Rows.Clear()
        End If
    End Sub

    Private Sub btnexit_Click(sender As Object, e As EventArgs) Handles btnexit.Click
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Openpdf As New OpenFileDialog With {
        .Filter = "PDF files (*.pdf)|*.pdf"
    }

        If Openpdf.ShowDialog() = DialogResult.OK Then
            pdfuploadbox.Text = Openpdf.FileName
        End If
    End Sub

    Private Sub btnpdf_Click(sender As Object, e As EventArgs) Handles btnpdf.Click
        If pdfuploadbox.Text = "" OrElse Not File.Exists(pdfuploadbox.Text) Then
            MessageBox.Show("Pilih file PDF terlebih dahulu.", AT,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Process.Start("msedge.exe", """" & pdfuploadbox.Text & """")
        Catch ex As Exception
            MessageBox.Show(ex.Message, AT,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub cmbBank_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBank.SelectedIndexChanged
        'If dgvList.RowCount > 1 Then
        '    dgvList.Rows.Clear()
        'End If
    End Sub

    Private Sub chkMandiri_Click(sender As Object, e As EventArgs) Handles chkMandiri.Click
        If dgvList.RowCount > 1 Then
            dgvList.Rows.Clear()
        End If
    End Sub

    Private Sub chkBni_Click(sender As Object, e As EventArgs) Handles chkBni.Click
        If dgvList.RowCount > 1 Then
            dgvList.Rows.Clear()
        End If
    End Sub

    Private Sub chkBri_Click(sender As Object, e As EventArgs) Handles chkBri.Click
        If dgvList.RowCount > 1 Then
            dgvList.Rows.Clear()
        End If
    End Sub

    ' Event handler for cell click event in DataGridView
    Private Sub dgvList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellClick
        ' Check if there are more than one row in the DataGridView
        If dgvList.RowCount > 1 Then
            ' Ensure the clicked row is not the last row
            If e.RowIndex < dgvList.RowCount - 1 Then
                ' Check if the clicked cell is in the "HapusBaris" column
                If e.ColumnIndex = dgvList.Columns("HapusBaris").Index Then
                    ' Remove the clicked row
                    dgvList.Rows.RemoveAt(e.RowIndex)
                    ' Reorder the row numbers
                    For i As Integer = 0 To dgvList.Rows.Count - 2
                        dgvList.Rows(i).Cells("No").Value = i + 1
                    Next

                    Call sum()
                End If
            End If
        End If
    End Sub
End Class