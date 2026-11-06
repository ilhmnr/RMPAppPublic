Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Windows.Controls
Imports System.Windows.Interop
Imports C1.Win.C1FlexGrid
Imports DocumentFormat.OpenXml.Drawing.Diagrams
Imports Syncfusion.Pdf.Interactive

Public Class FrmTrnKomisi
    Public HeaderID As Integer = 0
    Dim Perintah As String = "Add"
    Public StatusOpenForm As String = ""
    Dim jalan, Indlebih, IndRelasi, indumharganego As Integer
    Dim tujuan, waktuPengajuan As String

    Private Sub FrmTrnApprovalPenerimaan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' set tanggal pengajuan ke tanggal hari ini
        dtpPengajuan.Value = Date.Now
        dtpPeriode1.Value = New Date(Date.Now.Year, Date.Now.Month, 1)
        dtpPeriode2.Value = New Date(Date.Now.Year, Date.Now.Month, Date.DaysInMonth(Date.Now.Year, Date.Now.Month))

        Call ClsFlexGrid.ApplyStyle(fg)
        Call ClsFlexGrid.AttachLiveNumber(fg, 0, "PotDP")
        Call ClsFlexGrid.SetEditableColumns(fg, "PotDP")

        Modul_RMP.Combo.SetBahanBaku(cbobahanbaku)

        fg.Cols("NoTrans").Visible = False
        fg.Cols("StatusProses").Visible = False

        btnsave.Enabled = True
        btnDelete.Enabled = False

        chkSelectAll.Enabled = True

        If StatusOpenForm = "Edit" Then
            fg.Cols("SisaDP").Visible = True
            Perintah = "Edit"
        Else
            fg.Cols("SisaDP").Visible = False
        End If
    End Sub

    Public Sub LoadData()
        Me.Cursor = Cursors.WaitCursor

        Dim dt As New DataTable
        Dim i As Integer = 1
        Dim ByTanggal As String = ""
        Dim sql As String
        Dim JenisKomisi As String = ""

        ' wajib pilih jenis bahan baku
        If cbobahanbaku.SelectedIndex = -1 Then
            MsgBoxCustom.Show("Jenis Bahan Baku wajib dipilih.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
            Exit Sub
        End If

        If rdBiayaSaranaMuat.Checked = True Then
            JenisKomisi = "LAHAN"
        ElseIf rdToke.Checked = True Then
            JenisKomisi = "TOKE"
        End If

        sql = " select * FROM fnGetKomisi('" & Format(dtpPeriode1.Value, "yyyy-MM-dd") & "' ,'" & Format(dtpPeriode2.Value, "yyyy-MM-dd") & "'," & cbobahanbaku.SelectedValue & ",'" & JenisKomisi & "') order by idpancang"

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fg
            .Rows.Count = 1 ' Reset grid sebelum mengisi data baru

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "NoTrans") = ""
                    .Item(i, "IDPancang") = row("IDPancang")
                    .Item(i, "Pancang") = row("Pancang")
                    .Item(i, "RelasiID") = IIf(IsDBNull(row("idpemiliklahan")), "", row("idpemiliklahan"))
                    .Item(i, "RelasiName") = row("NamaPemilikLahan")
                    .Item(i, "RekeningName") = row("NamaRek")
                    .Item(i, "RekeningNo") = row("NoRek")
                    .Item(i, "RekeningBank") = row("Bank")
                    .Item(i, "BadanUsaha") = row("PTCV")
                    .Item(i, "TotalPemasukan") = row("Total")
                    .Item(i, "Tarif") = row("Fee")
                    .Item(i, "TotalRp") = row("Total") * row("Fee")
                    .Item(i, "TarifPajak") = 0
                    .Item(i, "DPP") = 0
                    .Item(i, "AkumulasiDPP") = 0
                    .Item(i, "PotPPH21") = 0
                    .Item(i, "PotPPH23") = 0
                    .Item(i, "PotDP") = 0
                    .Item(i, "GrandTotal") = 0

                    i += 1
                Next

                Call AutoGenerateMasterSupplierProgramAcc()

                .AutoSizeCols()
            Else
                MsgBoxCustom.Show("Tidak ada data.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            End If
        End With

        Me.Cursor = Cursors.Default
    End Sub

    Public Sub ShowDataView(ByVal HeaderID As Integer)
        fg.Cols("NoTrans").Visible = True
        fg.Cols("StatusProses").Visible = True

        If StatusOpenForm = "Edit" Then
            chkSelectAll.Enabled = True

            btnsave.Enabled = True
            btnDelete.Enabled = True
        ElseIf StatusOpenForm = "View" Then
            chkSelectAll.Enabled = False

            btnsave.Enabled = False
            btnDelete.Enabled = False
        End If

        txtnotrans.Enabled = False
        dtpPengajuan.Enabled = False
        dtpPeriode1.Enabled = False
        dtpPeriode2.Enabled = False
        rdBiayaSaranaMuat.Enabled = False
        rdToke.Enabled = False
        cbobahanbaku.Enabled = False

        btnSearch.Enabled = False
        btnAkumulasiPPH.Enabled = False

        ' load detail
        Dim dt As New DataTable
        Dim i As Integer = 1
        Dim sql As String = "select * from vwTrnKomisi where Deleted=0 and HeaderID=" & HeaderID & " order by DetailID asc"

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fg
            .Rows.Count = 1 ' Reset grid sebelum mengisi data baru

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "DetailID") = row("DetailID")
                    .Item(i, "NoTrans") = row("NoTrans")
                    If row("SudahProsesAcc") = True Then
                        .Item(i, "StatusProses") = "Sudah Proses"
                    Else
                        .Item(i, "StatusProses") = "Belum Proses"
                    End If
                    .Item(i, "IDPancang") = row("IDPancang")
                    .Item(i, "Pancang") = row("Pancang")
                    .Item(i, "RelasiID") = row("RelasiID")
                    .Item(i, "RelasiName") = row("RelasiName")
                    .Item(i, "RekeningName") = row("RekeningName")
                    .Item(i, "RekeningNo") = row("RekeningNo")
                    .Item(i, "RekeningBank") = row("RekeningBank")
                    .Item(i, "BadanUsaha") = row("BadanUsaha")
                    .Item(i, "TotalPemasukan") = row("TotalPemasukan")
                    .Item(i, "Tarif") = row("Tarif")
                    .Item(i, "TotalRp") = row("TotalRp")
                    .Item(i, "TarifPajak") = row("TarifPajak")
                    .Item(i, "DPP") = row("DPP")
                    .Item(i, "AkumulasiDPP") = row("AkumulasiDPP")
                    .Item(i, "PotPPH21") = row("PotPPH21")
                    .Item(i, "PotPPH23") = row("PotPPH23")
                    .Item(i, "PotDP") = row("PotDP")
                    .Item(i, "SisaDP") = row("SisaDP")
                    .Item(i, "GrandTotal") = row("GrandTotal")

                    i += 1
                Next

                .AutoSizeCols()
            End If
        End With

        ' load header
        Dim dtHdr As New DataTable
        dtHdr = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select * from tblTrnKomisiHdr where HeaderID=" & HeaderID)

        txtnotrans.Text = dtHdr.Rows(0).Item("NoTrans").ToString()
        dtpPengajuan.Value = Convert.ToDateTime(dtHdr.Rows(0).Item("TanggalPengajuan"))
        dtpPeriode1.Value = Convert.ToDateTime(dtHdr.Rows(0).Item("TanggalStart"))
        dtpPeriode2.Value = Convert.ToDateTime(dtHdr.Rows(0).Item("TanggalEnd"))
        If dtHdr.Rows(0).Item("JenisKomisi").ToString() = "Pemilik Lahan" Then
            rdBiayaSaranaMuat.Checked = True
        ElseIf dtHdr.Rows(0).Item("JenisKomisi").ToString() = "Toke" Then
            rdToke.Checked = True
        End If
        cbobahanbaku.SelectedValue = dtHdr.Rows(0).Item("IDJenisBahanBaku").ToString()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        SaveData()
    End Sub

    Private Sub SaveData()
        If MsgBoxCustom.Show("Apakah Anda yakin ingin menyimpan data ini?", MsgBoxCustom.ButtonType.YesNo, MsgBoxCustom.IconType.Question) = DialogResult.No Then
            Exit Sub
        End If

        ' jenis bahan baku tidak boleh kosong
        If cbobahanbaku.SelectedIndex = -1 Then
            MsgBoxCustom.Show("Jenis Bahan Baku wajib dipilih.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
            Exit Sub
        End If

        ' cek jika ada baris yang tidak di ceklist 
        Dim AdaPilih As Boolean = False
        For r As Integer = fg.Rows.Count - 1 To 1 Step -1
            If fg.Item(r, "Select") = True Then
                AdaPilih = True
                Exit For
            End If
        Next
        If AdaPilih = False Then
            MsgBoxCustom.Show("Tidak Ada Data Yang Dipilih.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
            Exit Sub
        End If

        ' cek jika ada grand total = 0 maka beri pesan
        'For r As Integer = 1 To fg.Rows.Count - 1
        '    If fg.Item(r, "GrandTotal") = 0 Then
        '        MsgBoxCustom.Show("Terdapat baris No. " & r & " dengan Grand Total 0. Silakan periksa kembali.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
        '        Exit Sub
        '    End If
        'Next

        Call AkumulasiTotal()

        ' === Deklarasi koneksi dan transaksi ===
        Dim Conn As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnRMPApp)
        Dim Trans As SqlTransaction = Conn.BeginTransaction()

        Me.Cursor = Cursors.WaitCursor

        Try
            If Perintah = "Add" Then
                ' === 1. Simpan HEADER ===
                HeaderID = 0
                HeaderID = SaveHdr(Conn, Trans)
                If String.IsNullOrEmpty(HeaderID) Then
                    Throw New Exception("Simpan Data Header Gagal!")
                End If
            End If
            ' === 2. Simpan DETAIL ===
            For r As Integer = 1 To fg.Rows.Count - 1
                If fg.Item(r, "Select") = True Then
                    If SaveDtl(Conn, Trans, HeaderID, r) = False Then
                        Throw New Exception("Simpan Data Detail Gagal pada baris ke-" & r)
                    End If
                End If
            Next

            ' === 3. Commit jika semua sukses ===
            Trans.Commit()
            MsgBoxCustom.Show("Data berhasil disimpan", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)

            Call ShowDataView(HeaderID)
        Catch ex As Exception
            ' === Rollback jika ada error ===
            Try
                Trans.Rollback()
            Catch
            End Try

            MsgBoxCustom.Show("Error: " & ex.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)

        Finally
            ' === Tutup koneksi dan kembalikan cursor ===
            If Conn.State = ConnectionState.Open Then Conn.Close()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function SaveHdr(ByVal Conn As SqlConnection,
                         ByVal Trans As SqlTransaction) As Long

        SaveHdr = 0

        Dim JenisKomisi As String = ""
        If rdBiayaSaranaMuat.Checked = True Then
            JenisKomisi = "Pemilik Lahan"
        ElseIf rdToke.Checked = True Then
            JenisKomisi = "Toke"
        End If

        Try
            Using cmd As New SqlCommand("dbo.spTrnKomisiHdr", Conn, Trans)
                cmd.CommandType = CommandType.StoredProcedure

                ' =========================
                ' =========================
                cmd.Parameters.Add("@TanggalPengajuan", SqlDbType.Date).Value =
                dtpPengajuan.Value.Date

                cmd.Parameters.Add("@TanggalStart", SqlDbType.Date).Value =
                dtpPeriode1.Value.Date

                cmd.Parameters.Add("@TanggalEnd", SqlDbType.Date).Value =
                dtpPeriode2.Value.Date

                cmd.Parameters.Add("@JenisKomisi", SqlDbType.VarChar, 20).Value =
                JenisKomisi

                cmd.Parameters.Add("@IDJenisBahanBaku", SqlDbType.Int).Value =
                Convert.ToInt32(cbobahanbaku.SelectedValue)

                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 100).Value =
                ClsSession.UserID

                cmd.Parameters.Add("@CreatedComputer", SqlDbType.VarChar, 20).Value =
                Environment.MachineName

                ' OUTPUT PARAMETERS
                cmd.Parameters.Add("@HeaderID", SqlDbType.BigInt).Direction =
                ParameterDirection.Output

                cmd.Parameters.Add("@NoTrans", SqlDbType.VarChar, 30).Direction =
                ParameterDirection.Output

                cmd.Parameters.Add("@Flag", SqlDbType.Int).Direction =
                ParameterDirection.Output

                ' EXECUTE
                cmd.ExecuteNonQuery()

                ' RESULT
                Dim resultFlag As Integer =
                Convert.ToInt32(cmd.Parameters("@Flag").Value)

                If resultFlag = 1 Then
                    SaveHdr = Convert.ToInt64(cmd.Parameters("@HeaderID").Value)
                    txtnotrans.Text = cmd.Parameters("@NoTrans").Value.ToString()
                Else
                    SaveHdr = 0
                End If

            End Using

        Catch ex As Exception
            MsgBoxCustom.Show("Error saat simpan header komisi: " & ex.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
            SaveHdr = 0
        End Try

        Return SaveHdr
    End Function

    Private Function SaveDtl(ByVal Conn As SqlConnection,
                         ByVal Trans As SqlTransaction,
                         ByVal HeaderID As Long,
                         ByVal r As Integer) As Boolean

        Dim JenisKomisi As String = ""
        If rdBiayaSaranaMuat.Checked = True Then
            JenisKomisi = "Pemilik Lahan"
        ElseIf rdToke.Checked = True Then
            JenisKomisi = "Toke"
        End If

        Try
            Using cmd As New SqlCommand("dbo.spTrnKomisiDtl", Conn, Trans)
                cmd.CommandType = CommandType.StoredProcedure

                With cmd.Parameters
                    .Add("@Perintah", SqlDbType.VarChar, 20).Value = Perintah
                    .Add("@HeaderID", SqlDbType.BigInt).Value = HeaderID
                    .Add("@NoTrans", SqlDbType.VarChar, 30).Value = fg.Item(r, "NoTrans")
                    .Add("@TglPeriode1", SqlDbType.Date).Value = dtpPeriode1.Value
                    .Add("@TglPeriode2", SqlDbType.Date).Value = dtpPeriode2.Value
                    .Add("@JenisKomisi", SqlDbType.VarChar, 20).Value = JenisKomisi
                    .Add("@IDPancang", SqlDbType.Int).Value = CInt(fg.Item(r, "IDPancang"))
                    .Add("@RelasiID", SqlDbType.VarChar, 30).Value = fg.Item(r, "RelasiID")
                    .Add("@RelasiName", SqlDbType.VarChar, 150).Value = fg.Item(r, "RelasiName")
                    .Add("@RekeningName", SqlDbType.VarChar, 150).Value = fg.Item(r, "RekeningName")
                    .Add("@RekeningNo", SqlDbType.VarChar, 30).Value = fg.Item(r, "RekeningNo")
                    .Add("@RekeningBank", SqlDbType.VarChar, 50).Value = fg.Item(r, "RekeningBank")
                    .Add("@BadanUsaha", SqlDbType.VarChar, 20).Value = fg.Item(r, "BadanUsaha")
                    .Add("@TotalPemasukan", SqlDbType.BigInt).Value = CLng(fg.Item(r, "TotalPemasukan"))
                    .Add("@Tarif", SqlDbType.Int).Value = CInt(fg.Item(r, "Tarif"))
                    .Add("@TotalRp", SqlDbType.Decimal).Value = CDec(fg.Item(r, "TotalRp"))
                    .Add("@TarifPajak", SqlDbType.VarChar, 10).Value = fg.Item(r, "TarifPajak")
                    .Add("@DPP", SqlDbType.Decimal).Value = CDec(fg.Item(r, "DPP"))
                    .Add("@AkumulasiDPP", SqlDbType.Decimal).Value = CDec(fg.Item(r, "AkumulasiDPP"))
                    .Add("@PotPPH21", SqlDbType.Decimal).Value = CDec(fg.Item(r, "PotPPH21"))
                    .Add("@PotPPH23", SqlDbType.Decimal).Value = CDec(fg.Item(r, "PotPPH23"))
                    .Add("@PotDP", SqlDbType.Decimal).Value = CDec(fg.Item(r, "PotDP"))
                    .Add("@GrandTotal", SqlDbType.Decimal).Value = CDec(fg.Item(r, "GrandTotal"))
                    .Add("@CreatedBy", SqlDbType.VarChar, 100).Value = ClsSession.UserID
                    .Add("@KodeBahanBaku", SqlDbType.Int).Value = cbobahanbaku.SelectedValue
                    .Add("@Flag", SqlDbType.Int).Direction = ParameterDirection.Output
                End With

                cmd.ExecuteNonQuery()

                Return CInt(cmd.Parameters("@Flag").Value) = 1
            End Using

        Catch ex As Exception
            MsgBoxCustom.Show("Error simpan detail komisi : " & ex.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
            Return False
        End Try
    End Function


    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Call LoadData()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        FrmTrnKomisiFind.ShowData()
        FrmTrnKomisiFind.Show(FrmMain.DockPanel1)
        FrmTrnKomisiFind.Activate()
        Me.Close()
    End Sub

    Private Sub btnAkumulasiPPH_Click(sender As Object, e As EventArgs) Handles btnAkumulasiPPH.Click
        ' cek jika ada baris yang di ceklist dan tarif = 0 maka beri pesan
        For r As Integer = 1 To fg.Rows.Count - 1
            If fg.Item(r, "Select") = True AndAlso fg.Item(r, "Tarif") = 0 Then
                MsgBoxCustom.Show("Terdapat baris No. " & r & " yang dipilih dengan tarif 0. Silakan periksa kembali.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
                Exit Sub
            End If
        Next

        ' hapus baris yang tidak di ceklist dulu
        For r As Integer = fg.Rows.Count - 1 To 1 Step -1
            If fg.Item(r, "Select") = False Then
                fg.Rows.Remove(r)
            End If
        Next

        Call AkumulasiTotal()
    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg.BeforeEdit
        'Kolom yang diperbolehkan untuk diedit
        Select Case fg.Cols(e.Col).Name

            Case "Select"
                'Boleh diedit
            Case "PotDP"
                'Hanya boleh edit saat form dalam status Edit
                If StatusOpenForm <> "Edit" Then
                    e.Cancel = True
                End If
            Case Else
                e.Cancel = True

        End Select

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
            MsgBoxCustom.Show("Tidak ada data yang dipilih untuk dihapus.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
            Exit Sub
        End If

        If MsgBoxCustom.Show("Apakah Anda yakin ingin menghapus data ini?", MsgBoxCustom.ButtonType.YesNo, MsgBoxCustom.IconType.Question) = DialogResult.No Then Exit Sub

        ' Input keterangan delete
        Dim fr As New FrmKeteranganDelete
        Dim KeteranganDelete As String = ""

        If fr.ShowDialog() = DialogResult.OK Then
            KeteranganDelete = fr.ResultText.Trim()
        End If

        If KeteranganDelete = "" Then
            MsgBoxCustom.Show("Delete Data Gagal.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
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
                    Dim sudahProses As Boolean =
                    CBool(DB.ExecuteScalarValue(Of String)(StrConnRMPApp,
                        "SELECT ISNULL(SudahProsesAcc,0) as GetValueString FROM tblTrnKomisiDtl WHERE DetailID=" & DetailID))

                    If sudahProses Then
                        Throw New Exception("Data No. Trans: " & fg.Item(r, "NoTrans") &
                                        " tidak dapat dihapus karena sudah diproses.")
                    End If

                    Using cmd As New SqlCommand("RMPApp..sp_TrnKomisiDelete", Conn, Trans)
                        cmd.CommandType = CommandType.StoredProcedure

                        cmd.Parameters.Add("@DetailID", SqlDbType.BigInt).Value = DetailID
                        cmd.Parameters.Add("@KeteranganDeleted", SqlDbType.VarChar, 500).Value = KeteranganDelete
                        cmd.Parameters.Add("@DeletedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
                        cmd.Parameters.Add("@Flag", SqlDbType.Int).Direction = ParameterDirection.Output

                        cmd.ExecuteNonQuery()

                        If CInt(cmd.Parameters("@Flag").Value) <> 1 Then
                            Throw New Exception("GAGAL menghapus data No. Trans: " & fg.Item(r, "NoTrans"))
                        End If
                    End Using
                Next

                Trans.Commit()
                Berhasil = True
                MsgBoxCustom.Show("Data berhasil dihapus.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)

            Catch ex As Exception
                Trans.Rollback()
                MsgBoxCustom.Show("Error saat proses delete: " & ex.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
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
            FrmTrnKomisiFind.ShowData()
            FrmTrnKomisiFind.Show(FrmMain.DockPanel1)
            FrmTrnKomisiFind.Activate()
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

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Try
            Dim JenisKomisi As String = ""
            If rdBiayaSaranaMuat.Checked = True Then
                JenisKomisi = "Pemilik Lahan"
            ElseIf rdToke.Checked = True Then
                JenisKomisi = "Toke"
            End If

            If fg.Rows.Count <= 1 Then
                MsgBoxCustom.Show("Data kosong.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
            End If

            Using save As New SaveFileDialog
                save.Filter = "Excel File (*.xlsx)|*.xlsx"
                save.FileName = "Rekap Komisi " & JenisKomisi & " " & cbobahanbaku.Text & " Dengan No Transaksi " & txtnotrans.Text & " Pengajuan Tanggal " & Format(dtpPengajuan.Value, "ddMMyyyy")

                If save.ShowDialog() = DialogResult.OK Then

                    ' === EXPORT LANGSUNG DARI GRID ===
                    ' otomatis hanya kolom Visible yang ikut
                    fg.SaveExcel(save.FileName, "Sheet1", FileFlags.IncludeFixedCells)

                    If IO.File.Exists(save.FileName) Then
                        MsgBoxCustom.Show("Export berhasil!", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                    Else
                        MsgBoxCustom.Show("Export gagal.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
                    End If
                End If
            End Using

        Catch ex As Exception
            MsgBoxCustom.Show("Error Export : " & ex.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
        End Try
    End Sub



    Private Sub AutoGenerateMasterSupplierProgramAcc()
        ' Cek jika belum ada di program Acc
        For r = 1 To fg.Rows.Count - 1
            If fg.Item(r, "RelasiID") <> "" Then
                If DB.ExecuteScalarValue(Of String)(StrConnRMPApp, "select isnull((select SupplierID from DBPancang..tblGENMstSupplier where SupplierID='" & fg.Item(r, "RelasiID") & "'),'') as GetValueString") = "" Then
                    Dim sql As String
                    sql = "DECLARE @RC int
                        DECLARE @SupplierID varchar(30)
                        DECLARE @SupplierIDPancang varchar(30)
                        DECLARE @SupplierName varchar(250)
                        DECLARE @MitraGroupID varchar(10)=''
                        DECLARE @ContactID bigint=0
                        DECLARE @ContactAddressID bigint=0
                        DECLARE @Address varchar(250)
                        DECLARE @Telephone varchar(100)
                        DECLARE @AppVersion varchar(10)=''
                        DECLARE @CreatedBy varchar(15)=''
                        DECLARE @CreatedDate date=getdate()
                        DECLARE @Flag bigint

                        select 
                        @SupplierID=KodeSup,
                        @SupplierIDPancang=KodeSup,
                        @SupplierName=NamaSup,
                        @Address=Alamat,
                        @Telephone=NoHP
                        from RSUPAccounting..tblRMMstSupplier where KodeSup='" & fg.Item(r, "RelasiID") & "'

                        EXECUTE @RC = DBPancang..GEN_spMstSupplierPancangSave_102025
                           @SupplierID OUTPUT
                          ,@SupplierIDPancang
                          ,@SupplierName
                          ,@MitraGroupID
                          ,@ContactID
                          ,@ContactAddressID
                          ,@Address
                          ,@Telephone
                          ,@AppVersion
                          ,@CreatedBy
                          ,@CreatedDate
                          ,@Flag OUTPUT
                        "

                    Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)
                End If
            End If
        Next
    End Sub

    Private Sub fg_AfterEdit(sender As Object, e As RowColEventArgs) Handles fg.AfterEdit
        Select Case fg.Cols(e.Col).Name
            Case "PotDP"
                If CInt(fg.Item(fg.Row, "PotDP")) > CInt(fg.Item(fg.Row, "GrandTotal")) Then
                    MsgBox("Potongan DP tidak boleh lebih besar dari Grand Total.", vbExclamation, AT)
                    fg.Item(fg.Row, "PotDP") = 0
                    Exit Sub
                ElseIf CInt(fg.Item(fg.Row, "PotDP")) > CInt(fg.Item(fg.Row, "SisaDP")) Then
                    MsgBox("Potongan DP tidak boleh lebih besar dari Sisa DP.", vbExclamation, AT)
                    fg.Item(fg.Row, "PotDP") = 0
                    Exit Sub
                End If
        End Select

        Call AkumulasiTotal()
    End Sub

    Private Sub AkumulasiTotal()
        Dim totalPotonganExsternal As Decimal = 0 ' masuk ke accounting
        Dim grandTotal As Decimal = 0

        For r As Integer = 1 To fg.Rows.Count - 1
            ' hitung pajak
            If fg.Item(r, "BadanUsaha") = "Pribadi" Then
                fg.Item(r, "DPP") = Format(fg.Item(r, "TotalRp") / 2, "N0")

                Dim AkumulasiDPP As Decimal = DB.ExecuteScalarValue(Of Integer)(StrConnRMPApp, "select isnull((select cast(sum(DPP) as decimal(18,0)) as DPP from RMPApp..fnMonAkumulasiDPPRelasi('" & Format(dtpPengajuan.Value, "yyyy-MM-dd") & "','" & fg.Item(r, "RelasiID") & "')),0) as GetValueInteger")
                AkumulasiDPP = AkumulasiDPP + CDec(fg.Item(r, "DPP"))
                fg.Item(r, "AkumulasiDPP") = AkumulasiDPP

                If CDec(fg.Item(r, "AkumulasiDPP")) <= 60000000 Then
                    fg.Item(r, "TarifPajak") = "5%"
                    fg.Item(r, "PotPPH21") = Format(CDec(fg.Item(r, "DPP")) * 0.05, "N0")
                Else
                    fg.Item(r, "TarifPajak") = "15%"
                    fg.Item(r, "PotPPH21") = Format(CDec(fg.Item(r, "DPP")) * 0.15, "N0")
                End If
            ElseIf fg.Item(r, "BadanUsaha") = "PT/CV" Then
                fg.Item(r, "DPP") = 0
                fg.Item(r, "AkumulasiDPP") = 0
                fg.Item(r, "TarifPajak") = "2%"
                fg.Item(r, "PotPPH23") = Format(CDec(fg.Item(r, "TotalRp")) * 0.02, "N0")
            Else
                fg.Item(r, "DPP") = 0
                fg.Item(r, "AkumulasiDPP") = 0
                fg.Item(r, "TarifPajak") = "0%"
                fg.Item(r, "PotPPH21") = 0
                fg.Item(r, "PotPPH23") = 0
            End If

            ' hitung grand total
            totalPotonganExsternal = CDec(fg.Item(r, "PotPPH21")) + CDec(fg.Item(r, "PotPPH23")) + CDec(fg.Item(r, "PotDP"))

            grandTotal = CDec(fg.Item(r, "TotalRp")) - totalPotonganExsternal

            fg.Item(r, "GrandTotal") = Format(grandTotal, "N0")
        Next

        fg.AutoSizeCols()
    End Sub
End Class