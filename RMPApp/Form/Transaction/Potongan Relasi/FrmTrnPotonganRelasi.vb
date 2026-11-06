Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmTrnPotonganRelasi
    Public StatusOpenForm As String = ""
    Dim jalan, Indlebih, IndRelasi, indumharganego As Integer
    Dim tujuan, waktuPengajuan As String
    Dim imgAdd As Image
    Dim imgDelete As Image

    Private Sub FrmTrnApprovalPenerimaan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call ClsFlexGrid.ApplyStyle(fg)
        fg.Cols("PenerimaUang").Width = 400
        fg.Cols("NamaKapal").Width = 200

        CmbReffNo.Enabled = False
        rdTambangKapal.Enabled = False
        rdUpahBongkar.Enabled = False

        ' Resize gambar agar muat di cell
        imgAdd = Func.ResizeImage(My.Resources.ButtonTambah, 16, 16)
        imgDelete = Func.ResizeImage(My.Resources.ButtonHapus, 16, 16)

        'Modul_RMP.Combo.SetBahanBaku(cbobahanbaku)
        fg.Cols("DetailID").Visible = False
        fg.Cols("Select").Visible = False
        fg.Cols("SudahDigunakan").Visible = False

        btnSave.Enabled = True
        btnDelete.Enabled = False

        chkSelectAll.Enabled = False

        Modul_RMP.Combo.SetKapalByName(cboKapal)
        cboKapal.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboKapal.AutoCompleteSource = AutoCompleteSource.ListItems
    End Sub

    Public Sub ShowDataView(ByVal HeaderID As Integer)
        'set view
        chkSelectAll.Enabled = True

        fg.Cols("Select").Visible = True
        fg.Cols("SudahDigunakan").Visible = True
        fg.Cols("Add").Visible = False
        fg.Cols("Hapus").Visible = False

        btnSave.Enabled = False
        btnDelete.Enabled = True

        txtNoTrans.Enabled = False
        rdSusut.Enabled = False
        rdOlahGerak.Enabled = False
        rdBPJS.Enabled = False
        rdGPS.Enabled = False
        rdTambangKapal.Enabled = False
        rdUpahBongkar.Enabled = False
        CmbReffNo.Enabled = False
        cboPenerimaUang.Enabled = False
        TxtRemark.Enabled = False
        txtTotalVoucher.Enabled = False
        txtSudahTerpotong.Enabled = False
        TxtSisaVoucher.Enabled = False

        ' load header
        Dim dtHdr As New DataTable
        dtHdr = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select * from tblTrnPotonganRelasiHdr where Deleted=0 and HeaderID=" & HeaderID)

        txtNoTrans.Text = dtHdr.Rows(0).Item("NoTrans").ToString()
        If dtHdr.Rows(0).Item("Potongan") = "Susut" Then
            rdSusut.Checked = True
        ElseIf dtHdr.Rows(0).Item("Potongan") = "Olah Gerak" Then
            rdOlahGerak.Checked = True
        ElseIf dtHdr.Rows(0).Item("Potongan") = "BPJS" Then
            rdBPJS.Checked = True
        ElseIf dtHdr.Rows(0).Item("Potongan") = "GPS" Then
            rdGPS.Checked = True
        End If
        If dtHdr.Rows(0).Item("PotonganTransaksi") = "Tambang Kapal" Then
            rdTambangKapal.Checked = True
        ElseIf dtHdr.Rows(0).Item("PotonganTransaksi") = "Upah Bongkar" Then
            rdUpahBongkar.Checked = True
        End If
        If Not IsDBNull(dtHdr.Rows(0).Item("ReffNo")) Then
            CmbReffNo.SelectedValue = dtHdr.Rows(0).Item("ReffNo").ToString()
        End If
        TxtRemark.Text = dtHdr.Rows(0).Item("RemarkReffNo").ToString()

        ' load detail
        Dim dt As New DataTable
        Dim i As Integer = 1
        Dim sql As String = "SELECT * FROM tblTrnPotonganRelasiDtl where HeaderID=" & HeaderID & " and Deleted=0 order by DetailID asc"

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fg
            .Rows.Count = 1 ' Reset grid sebelum mengisi data baru

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "DetailID") = row("DetailID")
                    .Item(i, "IDNoRek") = row("IDNoRek")
                    .Item(i, "IDKapal") = row("IDKapal")
                    .Item(i, "NamaKapal") = row("NamaKapal")
                    .Item(i, "PenerimaUang") = row("PenerimaUang")
                    .Item(i, "RpPotongan") = row("RpPotongan")
                    .Item(i, "JumlahPotongan") = row("JumlahPotongan")
                    .Item(i, "RpPerPotongan") = row("RpPerpotongan")
                    .Item(i, "SudahDigunakan") = row("SudahDigunakan")

                    i += 1
                Next

                .AutoSizeCols()
            End If
        End With
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveData()
    End Sub

    Private Sub SaveData()
        If MsgBox("Apakah Anda yakin ingin menyimpan data ini?", vbQuestion + vbYesNo, AT) = vbNo Then
            Exit Sub
        End If

        ' cek kembali jika ada update
        If rdBPJS.Checked = True Or rdGPS.Checked = True Then
            Dim dtReffNo As New DataTable
            dtReffNo = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select *,RpPotongan-SudahDigunakan as SisaRpPotongan from RMPApp..tblTrnPotonganRelasiVoucher where ReffNo='" & CmbReffNo.SelectedValue & "'")

            TxtRemark.Text = dtReffNo.Rows(0).Item("Remark").ToString()
            txtTotalVoucher.Text = Format(CDec(dtReffNo.Rows(0).Item("RpPotongan")), "N0")
            txtSudahTerpotong.Text = Format(CDec(dtReffNo.Rows(0).Item("SudahDigunakan")), "N0")
            TxtSisaVoucher.Text = Format(CDec(dtReffNo.Rows(0).Item("SisaRpPotongan")), "N0")

            If CInt(txtTotalDetail.Text) > CInt(TxtSisaVoucher.Text) Then
                MsgBox("Total nilai potongan melebihi sisa voucher.", vbExclamation, AT)
                Exit Sub
            End If
        End If

        ' cek semua kolom data di isi
        For r As Integer = 1 To fg.Rows.Count - 1

            ' wajib semua
            If IsEmpty(fg.Item(r, "PenerimaUang")) _
        OrElse IsEmpty(fg.Item(r, "RpPotongan")) _
        OrElse ToDecimal(fg.Item(r, "RpPotongan")) <= 0 _
        OrElse IsEmpty(fg.Item(r, "JumlahPotongan")) _
        OrElse ToInteger(fg.Item(r, "JumlahPotongan")) <= 0 _
        OrElse IsEmpty(fg.Item(r, "RpPerPotongan")) _
        OrElse ToDecimal(fg.Item(r, "RpPerPotongan")) <= 0 _
        OrElse (rdTambangKapal.Checked AndAlso IsEmpty(fg.Item(r, "NamaKapal"))) Then

                MsgBox("Data pada baris ke-" & r & " belum lengkap atau ada yang bernilai nol.", vbExclamation, AT)
                Exit Sub
            End If

        Next


        ' === Deklarasi koneksi dan transaksi ===
        Dim Conn As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnRMPApp)
        Dim Trans As SqlTransaction = Conn.BeginTransaction()
        Dim HeaderID As Integer = 0

        Me.Cursor = Cursors.WaitCursor

        Try
            ' === 1. Simpan HEADER ===
            HeaderID = SaveHdr(Conn, Trans)
            If String.IsNullOrEmpty(HeaderID) Then
                Throw New Exception("Simpan Data Header Gagal!")
            End If

            ' === 2. Simpan DETAIL ===
            For r As Integer = 1 To fg.Rows.Count - 1
                If SaveDtl(Conn, Trans, HeaderID, r) = False Then
                    Throw New Exception("Simpan Data Detail Gagal pada baris ke-" & r)
                End If
            Next

            ' === 3. Commit jika semua sukses ===
            Trans.Commit()
            MsgBox("Data berhasil disimpan", vbInformation, "Sukses")

            Call ShowDataView(HeaderID)
        Catch ex As Exception
            ' === Rollback jika ada error ===
            Try
                Trans.Rollback()
            Catch
            End Try

            MsgBox(ex.Message, vbCritical, "Error")

        Finally
            ' === Tutup koneksi dan kembalikan cursor ===
            If Conn.State = ConnectionState.Open Then Conn.Close()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function IsEmpty(value As Object) As Boolean
        If value Is Nothing OrElse IsDBNull(value) Then Return True
        Return Trim(value.ToString()) = ""
    End Function

    Private Function ToDecimal(value As Object) As Decimal
        Dim d As Decimal = 0
        Decimal.TryParse(value.ToString(), d)
        Return d
    End Function

    Private Function ToInteger(value As Object) As Integer
        Dim i As Integer = 0
        Integer.TryParse(value.ToString(), i)
        Return i
    End Function


    Private Function SaveHdr(ByVal Conn As SqlConnection,
                         ByVal Trans As SqlTransaction) As Long

        SaveHdr = 0

        Dim Potongan As String = ""
        If rdSusut.Checked = True Then
            Potongan = "Susut"
        ElseIf rdOlahGerak.Checked = True Then
            Potongan = "Olah Gerak"
        ElseIf rdBPJS.Checked = True Then
            Potongan = "BPJS"
        ElseIf rdGPS.Checked = True Then
            Potongan = "GPS"
        End If

        Dim PotonganTransaksi As String = ""
        If rdTambangKapal.Checked = True Then
            PotonganTransaksi = "Tambang Kapal"
        ElseIf rdUpahBongkar.Checked = True Then
            PotonganTransaksi = "Upah Bongkar"
        End If

        Try
            Using cmd As New SqlCommand("dbo.sp_TrnPotonganRelasiHdr", Conn, Trans)
                cmd.CommandType = CommandType.StoredProcedure

                ' =========================
                ' INPUT PARAMETERS
                ' =========================
                cmd.Parameters.Add("@Potongan", SqlDbType.VarChar, 20).Value =
                Potongan

                cmd.Parameters.Add("@PotonganTransaksi", SqlDbType.VarChar, 30).Value =
                PotonganTransaksi

                If CmbReffNo.SelectedIndex = -1 OrElse
                   CmbReffNo.SelectedValue Is Nothing OrElse
                   TypeOf CmbReffNo.SelectedValue Is DataRowView Then

                    cmd.Parameters.Add("@ReffNo", SqlDbType.VarChar, 20).Value = DBNull.Value
                Else
                    cmd.Parameters.Add("@ReffNo", SqlDbType.VarChar, 20).Value =
                    CmbReffNo.SelectedValue.ToString()
                End If


                cmd.Parameters.Add("@RemarkReffNo", SqlDbType.VarChar, 500).Value =
                TxtRemark.Text

                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 100).Value =
                ClsSession.UserID

                ' =========================
                ' OUTPUT PARAMETERS
                ' =========================
                cmd.Parameters.Add("@HeaderID", SqlDbType.BigInt).Direction =
                ParameterDirection.Output

                cmd.Parameters.Add("@NoTrans", SqlDbType.VarChar, 30).Direction =
                ParameterDirection.Output

                cmd.Parameters.Add("@Flag", SqlDbType.Bit).Direction =
                ParameterDirection.Output

                ' =========================
                ' EXECUTE
                ' =========================
                cmd.ExecuteNonQuery()

                ' =========================
                ' RESULT
                ' =========================
                Dim resultFlag As Boolean =
                Convert.ToBoolean(cmd.Parameters("@Flag").Value)

                If resultFlag = True Then
                    SaveHdr = Convert.ToInt64(cmd.Parameters("@HeaderID").Value)
                    txtnotrans.Text = cmd.Parameters("@NoTrans").Value.ToString()
                Else
                    SaveHdr = 0
                End If

            End Using

        Catch ex As Exception
            MsgBox("Error saat simpan header potongan: " & ex.Message,
               vbCritical, "Error")
            SaveHdr = 0
        End Try

        Return SaveHdr
    End Function


    Private Function SaveDtl(ByVal Conn As SqlConnection,
                         ByVal Trans As SqlTransaction,
                         ByVal HeaderID As Long,
                         ByVal r As Integer) As Boolean

        Try
            Using cmd As New SqlCommand("dbo.sp_TrnPotonganRelasiDtl", Conn, Trans)
                cmd.CommandType = CommandType.StoredProcedure

                With cmd.Parameters
                    ' =========================
                    ' INPUT PARAMETERS
                    ' =========================

                    If CmbReffNo.SelectedIndex = -1 OrElse
                   CmbReffNo.SelectedValue Is Nothing OrElse
                   TypeOf CmbReffNo.SelectedValue Is DataRowView Then

                        cmd.Parameters.Add("@ReffNo", SqlDbType.VarChar, 20).Value = DBNull.Value
                    Else
                        cmd.Parameters.Add("@ReffNo", SqlDbType.VarChar, 20).Value =
                    CmbReffNo.SelectedValue.ToString()
                    End If

                    .Add("@HeaderID", SqlDbType.BigInt).Value =
                    HeaderID

                    .Add("@IDNoRek", SqlDbType.BigInt).Value =
                    CLng(fg.Item(r, "IDNoRek"))

                    .Add("@PenerimaUang", SqlDbType.VarChar, 150).Value =
                    fg.Item(r, "PenerimaUang").ToString()

                    If fg.Item(r, "IDKapal") Is Nothing OrElse IsDBNull(fg.Item(r, "IDKapal")) OrElse Replace(fg.Item(r, "IDKapal"), " ", "") = 0 Then
                        .Add("@IDKapal", SqlDbType.BigInt).Value = DBNull.Value
                    Else
                        .Add("@IDKapal", SqlDbType.BigInt).Value = CLng(fg.Item(r, "IDKapal"))
                    End If

                    If fg.Item(r, "NamaKapal") Is Nothing OrElse IsDBNull(fg.Item(r, "NamaKapal")) OrElse Replace(fg.Item(r, "NamaKapal"), " ", "") = "" Then
                        .Add("@NamaKapal", SqlDbType.VarChar, 150).Value = DBNull.Value
                    Else
                        .Add("@NamaKapal", SqlDbType.VarChar, 150).Value = fg.Item(r, "NamaKapal").ToString()
                    End If

                    .Add("@RpPotongan", SqlDbType.Decimal).Value =
                    CDec(fg.Item(r, "RpPotongan"))

                    .Add("@JumlahPotongan", SqlDbType.Int).Value =
                    CInt(fg.Item(r, "JumlahPotongan"))

                    .Add("@RpPerpotongan", SqlDbType.Decimal).Value =
                    CDec(fg.Item(r, "RpPerpotongan"))

                    .Add("@CreatedBy", SqlDbType.VarChar, 100).Value =
                    ClsSession.UserID

                    .Add("@CreatedComputer", SqlDbType.VarChar, 20).Value =
                    Environment.MachineName

                    ' =========================
                    ' OUTPUT
                    ' =========================
                    .Add("@Flag", SqlDbType.Bit).Direction =
                    ParameterDirection.Output
                End With

                cmd.ExecuteNonQuery()

                Return Convert.ToBoolean(cmd.Parameters("@Flag").Value)
            End Using

        Catch ex As Exception
            MessageBox.Show("Error simpan detail potongan : " & ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        FrmTrnPotonganRelasiFind.ShowData()
        FrmTrnPotonganRelasiFind.Show(FrmMain.DockPanel1)
        FrmTrnPotonganRelasiFind.Activate()
        Me.Close()
    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg.BeforeEdit
        ' Hanya kolom select yang boleh diedit
        If fg.Cols(e.Col).Name = "Select" Or
            fg.Cols(e.Col).Name = "PenerimaUang" Or
            fg.Cols(e.Col).Name = "NamaKapal" Or
            fg.Cols(e.Col).Name = "RpPotongan" Or
            fg.Cols(e.Col).Name = "JumlahPotongan" Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Dim adaDataDihapus As Boolean = False
        Dim Berhasil As Boolean = False

        For r As Integer = 1 To fg.Rows.Count - 1
            If Not IsDBNull(fg.Item(r, "Select")) AndAlso CBool(fg.Item(r, "Select")) Then
                adaDataDihapus = True
                Exit For
            End If
        Next
        If Not adaDataDihapus Then
            MsgBox("Tidak ada data yang dipilih untuk dihapus.", vbExclamation, AT)
            Exit Sub
        End If

        If MsgBox("Apakah Anda yakin ingin menghapus data ini?",
              vbQuestion + vbYesNo, AT) = vbNo Then Exit Sub

        ' Input keterangan delete
        Dim fr As New FrmKeteranganDelete
        Dim KeteranganDelete As String = ""

        If fr.ShowDialog() = DialogResult.OK Then
            KeteranganDelete = fr.ResultText.Trim()
        End If

        If KeteranganDelete = "" Then
            MsgBox("Delete Data Gagal.", vbExclamation, AT)
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        Using Conn As New SqlConnection(StrConnRMPApp)
            Conn.Open()
            Dim Trans As SqlTransaction = Conn.BeginTransaction()

            Try
                For r As Integer = fg.Rows.Count - 1 To 1 Step -1

                    If IsDBNull(fg.Item(r, "Select")) OrElse
                   CBool(fg.Item(r, "Select")) = False Then Continue For

                    Dim DetailID As Long = CLng(fg.Item(r, "DetailID"))

                    ' ✅ Cek SudahProsesAcc (AMAN)
                    Dim sudahProses As Integer = DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"select isnull((SELECT DetailID FROM tblTrnPotonganRelasiDtl where DetailID=" & DetailID & " and SudahDigunakan<>0),0) as GetValueString")
                    If sudahProses > 0 Then
                        Throw New Exception("Data No. " & r & " tidak dapat dihapus karena sudah digunakan.")
                    End If

                    Using cmd As New SqlCommand("RMPApp..sp_TrnPotonganRelasiDelete", Conn, Trans)
                        cmd.CommandType = CommandType.StoredProcedure

                        cmd.Parameters.Add("@DetailID", SqlDbType.BigInt).Value = DetailID
                        cmd.Parameters.Add("@KeteranganDeleted", SqlDbType.VarChar, 500).Value = KeteranganDelete
                        cmd.Parameters.Add("@DeletedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
                        cmd.Parameters.Add("@Flag", SqlDbType.Int).Direction = ParameterDirection.Output

                        cmd.ExecuteNonQuery()

                        If CInt(cmd.Parameters("@Flag").Value) <> 1 Then
                            Throw New Exception("GAGAL menghapus data.")
                        End If
                    End Using
                Next

                Trans.Commit()
                Berhasil = True
                MsgBox("Data berhasil dihapus.", vbInformation, AT)

            Catch ex As Exception
                Trans.Rollback()
                MsgBox("Error saat proses delete: " & vbNewLine & ex.Message, vbCritical, AT)
            Finally
                Me.Cursor = Cursors.Default
            End Try
        End Using

        ' remove baris sudah di delete
        If Berhasil = True Then
            For i As Integer = fg.Rows.Count - 1 To 1 Step -1
                If CBool(fg.Item(i, "Select")) = True Then fg.Rows.Remove(i)
            Next
        End If

        If fg.Rows.Count = 1 Then
            FrmTrnPotonganRelasiFind.ShowData()
            FrmTrnPotonganRelasiFind.Show(FrmMain.DockPanel1)
            FrmTrnPotonganRelasiFind.Activate()
            Me.Close()
        End If

        ' Reset nomor urut
        For r As Integer = 1 To fg.Rows.Count - 1
            fg.Item(r, 0) = r
        Next

    End Sub


    Private Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelectAll.CheckedChanged
        If chkSelectAll.Checked = True Then
            For r As Integer = 1 To fg.Rows.Count - 1
                fg.Item(r, "Select") = True
            Next
        Else
            For r As Integer = 1 To fg.Rows.Count - 1
                fg.Item(r, "Select") = False
            Next
        End If
    End Sub

    Private Sub rdSusut_CheckedChanged(sender As Object, e As EventArgs) Handles rdSusut.CheckedChanged, rdOlahGerak.CheckedChanged, rdBPJS.CheckedChanged, rdGPS.CheckedChanged
        fg.Rows.Count = 1
        fg.Rows.Count = 2

        ' Masukkan gambar yang sudah di-resize
        fg.SetCellImage(1, "Add", imgAdd)
        ' Atur posisi gambar ke tengah
        fg.Cols("Add").ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter

        If rdBPJS.Checked = True Then
            rdTambangKapal.Enabled = True
            rdUpahBongkar.Enabled = True

            rdTambangKapal.Checked = False
            rdUpahBongkar.Checked = False
        Else
            rdTambangKapal.Enabled = False
            rdUpahBongkar.Enabled = False

            rdTambangKapal.Checked = True
        End If

        If rdBPJS.Checked = True Or rdGPS.Checked = True Then
            CmbReffNo.Enabled = True
            Call GetReffNo(CmbReffNo)
        Else
            CmbReffNo.Enabled = False
        End If

        CmbReffNo.Text = ""
        TxtRemark.Text = ""
        txtTotalVoucher.Text = ""
        txtSudahTerpotong.Text = ""
        TxtSisaVoucher.Text = ""
    End Sub

    Public Sub GetReffNo(cbo As ComboBox)
        Dim dt As DataTable = New DataTable()

        If rdBPJS.Checked = True Then
            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select ReffNo as Value,ReffNo + ' | ' + FORMAT(RpPotongan,'N0') + ' | ' + Remark as Member  from RMPApp..tblTrnPotonganRelasiVoucher where Remark like '%BPJS%' and (RpPotongan-SudahDigunakan)<>0 order by CreatedDate desc")
        Else
            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select ReffNo as Value,ReffNo + ' | ' + FORMAT(RpPotongan,'N0') + ' | ' + Remark as Member  from RMPApp..tblTrnPotonganRelasiVoucher where Remark like '%GPS%' and (RpPotongan-SudahDigunakan)<>0 order by CreatedDate desc")
        End If

        With cbo
            .DataSource = dt
            .DisplayMember = "Member"
            .ValueMember = "Value"
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click
        ' jika bpjs / gps dan reff no belum dipilih
        If (rdBPJS.Checked = True Or rdGPS.Checked = True) And CmbReffNo.SelectedIndex = -1 Then
            MsgBox("Silahkan pilih Reff No Voucher terlebih dahulu.", vbExclamation, AT)
            Exit Sub
        End If

        ' jika belum pilih potongan transaksi
        If rdTambangKapal.Checked = False And rdUpahBongkar.Checked = False Then
            MsgBox("Silahkan pilih jenis potongan transaksi terlebih dahulu.", vbExclamation, AT)
            Exit Sub
        End If

        ' pastikan klik di baris data (bukan header)
        If fg.Row < fg.Rows.Fixed Then Exit Sub

        ' cek kolom berdasarkan Name
        If fg.Cols(fg.Col).Name = "Add" Then
            fg.Rows.Insert(fg.Row + 1)
            ' Masukkan gambar yang sudah di-resize
            fg.SetCellImage(fg.Row + 1, "Add", imgAdd)
            fg.SetCellImage(fg.Row + 1, "Hapus", imgDelete)
        ElseIf fg.Cols(fg.Col).Name = "Hapus" Then
            If fg.Row > 1 Then
                fg.Rows.Remove(fg.Row)
            End If
        End If

        ' set nomor urut
        For r As Integer = 1 To fg.Rows.Count - 1
            fg.Item(r, 0) = r
        Next
    End Sub

    Private Sub rdTambangKapal_CheckedChanged(sender As Object, e As EventArgs) Handles rdTambangKapal.CheckedChanged, rdUpahBongkar.CheckedChanged
        Call GetMasterRekening(cboPenerimaUang)
    End Sub

    Public Sub GetMasterRekening(cbo As ComboBox)
        Dim dt As DataTable = New DataTable()

        If rdTambangKapal.Checked = True Then
            dt = Modul_RMP.DB.ExecuteQuery(StrConnAccounting, "Select IDNorek, NamaRekening + ' | ' + IDPetani + ' | ' +  NoRekening + ' | ' + isnull(JenisBank,'') As NamaRek from vwRMMstRekeningPancang where Approval = '2' AND ID_Jenis_RekUBM='1' and (InActive=0 OR InActive IS NULL) order by NamaRek")
        Else
            dt = Modul_RMP.DB.ExecuteQuery(StrConnAccounting, "Select IDNorek, NamaRekening + ' | ' + IDPetani + ' | ' +  NoRekening + ' | ' + isnull(JenisBank,'') As NamaRek from vwRMMstRekeningPancang  where Approval = '2' AND ID_Jenis_RekUB='1' and (InActive=0 OR InActive IS NULL) order by NamaRek")
        End If

        With cbo
            .DataSource = dt
            .DisplayMember = "NamaRek"
            .ValueMember = "IDNorek"
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub CmbReffNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbReffNo.SelectedIndexChanged
        Try
            ' jika ada pilihan
            If CmbReffNo.SelectedIndex <> -1 Then
                Dim dtReffNo As New DataTable
                dtReffNo = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select *,RpPotongan-SudahDigunakan as SisaRpPotongan from RMPApp..tblTrnPotonganRelasiVoucher where ReffNo='" & CmbReffNo.SelectedValue & "'")

                TxtRemark.Text = dtReffNo.Rows(0).Item("Remark").ToString()
                txtTotalVoucher.Text = Format(CDec(dtReffNo.Rows(0).Item("RpPotongan")), "N0")
                txtSudahTerpotong.Text = Format(CDec(dtReffNo.Rows(0).Item("SudahDigunakan")), "N0")
                TxtSisaVoucher.Text = Format(CDec(dtReffNo.Rows(0).Item("SisaRpPotongan")), "N0")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fg_AfterEdit(sender As Object, e As RowColEventArgs) Handles fg.AfterEdit
        If fg.Cols(e.Col).Name = "PenerimaUang" Then
            If Replace(fg.Item(fg.Row, "PenerimaUang"), " ", "") <> "" Then
                fg.Item(fg.Row, "IDNoRek") = DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"select isnull((Select IDNorek from RSUPAccounting..vwrmmstrekeningpancang where IDNorek='" & cboPenerimaUang.SelectedValue & "'),'') as GetValueString")

                If fg.Item(fg.Row, "IDNoRek") = 0 Then
                    MsgBox("Pilihan Rekening Tidak Valid !", vbInformation, AT)
                    fg.Item(fg.Row, "PenerimaUang") = ""
                End If
            Else
                fg.Item(fg.Row, "IDNoRek") = 0
            End If

        ElseIf fg.Cols(e.Col).Name = "NamaKapal" Then
            If Replace(fg.Item(fg.Row, "NamaKapal"), " ", "") <> "" Then
                fg.Item(fg.Row, "IDKapal") = DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"select isnull((select KapalID from RMPApp..tblMstKapal where KapalID='" & cboKapal.SelectedValue & "'),'') as GetValueString")

                If fg.Item(fg.Row, "IDKapal") = 0 Then
                    MsgBox("Pilihan Kapal Tidak Valid !", vbInformation, AT)
                    fg.Item(fg.Row, "NamaKapal") = ""
                End If
            Else
                fg.Item(fg.Row, "IDKapal") = 0
            End If

        ElseIf fg.Cols(e.Col).Name = "RpPotongan" Then
            ' cek jika rekening dan kapal sudah di pilih
            If Replace(fg.Item(e.Row, "PenerimaUang"), " ", "") = "" Then
                MsgBox("Silahkan pilih penerima uang terlebih dahulu.", vbExclamation, AT)
                fg.Item(e.Row, "RpPotongan") = 0
                Exit Sub
            End If
            If Replace(fg.Item(e.Row, "NamaKapal"), " ", "") = "" And rdTambangKapal.Checked = True Then
                MsgBox("Silahkan pilih nama kapal terlebih dahulu.", vbExclamation, AT)
                fg.Item(e.Row, "RpPotongan") = 0
                Exit Sub
            End If

            ' cek jika bukan angka
            If Not IsNumeric(fg.Item(e.Row, "RpPotongan")) Then
                MsgBox("Nilai potongan harus berupa angka.", vbExclamation, AT)
                fg.Item(e.Row, "RpPotongan") = 0
                Exit Sub
            End If

            ' jika potongan gps / bpjs melebihi sisa voucher
            If (rdBPJS.Checked = True Or rdGPS.Checked = True) AndAlso CDec(fg.Item(e.Row, "RpPotongan")) > CDec(TxtSisaVoucher.Text) Then
                MsgBox("Nilai potongan melebihi sisa voucher.", vbExclamation, AT)
                fg.Item(e.Row, "RpPotongan") = 0
                Exit Sub
            End If

            Dim totalSudahTerpotong As Decimal = 0

            For r As Integer = 1 To fg.Rows.Count - 1
                totalSudahTerpotong = totalSudahTerpotong + CDec(fg.Item(r, "RpPotongan"))
            Next

            txtTotalDetail.Text = Format(totalSudahTerpotong, "N0")

            ' jika melebihi sisa voucher
            If rdBPJS.Checked = True Or rdGPS.Checked = True Then
                If CInt(txtTotalDetail.Text) > CInt(TxtSisaVoucher.Text) Then
                    MsgBox("Total nilai potongan melebihi sisa voucher.", vbExclamation, AT)
                    fg.Item(e.Row, "RpPotongan") = 0
                    Exit Sub
                End If
            End If

            fg.Item(e.Row, "RpPotongan") = Format(CInt(fg.Item(e.Row, "RpPotongan")), "N0")
            fg.Item(e.Row, "JumlahPotongan") = 1
            fg.Item(e.Row, "RpPerPotongan") = Format(CInt(fg.Item(e.Row, "RpPotongan")), "N0")

        ElseIf fg.Cols(e.Col).Name = "JumlahPotongan" Then
            ' cek jika bukan angka
            If Not IsNumeric(fg.Item(e.Row, "JumlahPotongan")) Then
                MsgBox("Jumlah potongan harus berupa angka.", vbExclamation, AT)
                fg.Item(e.Row, "JumlahPotongan") = 0
                Exit Sub
            End If

            fg.Item(e.Row, "RpPerPotongan") = Format(CInt(fg.Item(e.Row, "RpPotongan")) / CInt(fg.Item(e.Row, "JumlahPotongan")), "N0")
        End If
    End Sub

    Private Sub AkumulasiSudahTerpotong()
        If CmbReffNo.SelectedIndex <> -1 Then
            Dim dtReffNo As New DataTable
            dtReffNo = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select *,RpPotongan-SudahDigunakan as SisaRpPotongan from RMPApp..tblTrnPotonganRelasiVoucher where ReffNo='" & CmbReffNo.SelectedValue & "'")

            TxtRemark.Text = dtReffNo.Rows(0).Item("Remark").ToString()
            txtTotalVoucher.Text = Format(CDec(dtReffNo.Rows(0).Item("RpPotongan")), "N0")
            txtSudahTerpotong.Text = Format(CDec(dtReffNo.Rows(0).Item("SudahDigunakan")), "N0")
            TxtSisaVoucher.Text = Format(CDec(dtReffNo.Rows(0).Item("SisaRpPotongan")), "N0")
        End If


        Dim totalSudahTerpotong As Decimal = 0

        For r As Integer = 1 To fg.Rows.Count - 1
            totalSudahTerpotong = totalSudahTerpotong + CDec(fg.Item(r, "RpPotongan"))
        Next

        txtTotalDetail.Text = Format(totalSudahTerpotong, "N0")
    End Sub

    Private Sub FrmTrnApprovalPenerimaan_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        lblJudulForm.Left = (Me.Width - lblJudulForm.Width) / 2
    End Sub
End Class