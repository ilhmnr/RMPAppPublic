Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Windows.Interop
Imports C1.Win.C1FlexGrid
Imports DocumentFormat.OpenXml.Drawing.Diagrams
Imports Syncfusion.Pdf.Interactive

Public Class FrmTrnUpahBongkarInput
    Public StatusOpenForm As String = ""
    Dim jalan, Indlebih, IndRelasi, indumharganego As Integer
    Dim tujuan, waktuPengajuan As String
    Private SudahKalkilasi As Boolean = False

    Private Sub FrmTrnApprovalPenerimaan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call ClsFlexGrid.ApplyStyle(fg)
        Call ClsFlexGrid.SetEditableColumns(fg, "PotonganDP")
        Call ClsFlexGrid.SetNumberFormat(fg, "N0", "PotonganDP")

        Modul_RMP.Combo.SetPenerimaUangUB(cboPenerimaUang)
        Modul_RMP.Combo.SetPancang(cboPancang)
        Combo.SetKapal(cboKapal)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Me.Cursor = Cursors.WaitCursor

        cboPenerimaUang.SelectedIndex = -1
        cboNoTransBPJS.DataSource = Nothing
        cboNoTransBPJS.Items.Clear()
        cboNoTransBPJS.SelectedIndex = -1

        Call LoadData()

        SudahKalkilasi = False

        Me.Cursor = Cursors.Default
    End Sub

    Public Sub LoadData()
        Dim dt As New DataTable
        Dim i As Integer = 1
        Dim ByTanggal As String = ""
        Dim sql As String

        ' wajib isi pancang
        If cboPancang.SelectedIndex = -1 Then
            MsgBoxCustom.Show("Pancang wajib dipilih.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
            cboPancang.Focus()
            Exit Sub
        End If

        If rdTglNota.Checked Then
            ByTanggal = "NOTA"

            sql = "EXEC RMPApp..sp_GetTrnUpahBongkar 'NOTA','" &
          Format(dtpNota1.Value, "yyyy-MM-dd") & "','" &
          Format(dtpNota2.Value, "yyyy-MM-dd") & "','" &
          Replace(txtTrip.Text, " ", "") & "','" &
          Replace(txtTrip2.Text, " ", "") & "'," &
          cboPancang.SelectedValue & "," &
          IIf(cboKapal.Text <> "", cboKapal.SelectedValue, "0")

        ElseIf rdTglBoking.Checked Then
            ByTanggal = "BOOKING"

            sql = "EXEC RMPApp..sp_GetTrnUpahBongkar 'BOOKING','" &
          Format(dtpboking1.Value, "yyyy-MM-dd") & "','" &
          Format(dtpboking2.Value, "yyyy-MM-dd") & "','" &
          Replace(txtTrip.Text, " ", "") & "','" &
          Replace(txtTrip2.Text, " ", "") & "'," &
          cboPancang.SelectedValue & "," &
          IIf(cboKapal.Text <> "", cboKapal.SelectedValue, "0")

        ElseIf rdTglCheckin.Checked Then
            ByTanggal = "CHECKIN"

            sql = "EXEC RMPApp..sp_GetTrnUpahBongkar 'CHECKIN','" &
          Format(dtpCheckin1.Value, "yyyy-MM-dd") & "','" &
          Format(dtpCheckin2.Value, "yyyy-MM-dd") & "','" &
          Replace(txtTrip.Text, " ", "") & "','" &
          Replace(txtTrip2.Text, " ", "") & "'," &
          cboPancang.SelectedValue & "," &
          IIf(cboKapal.Text <> "", cboKapal.SelectedValue, "0")
        End If


        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fg
            .Rows.Count = 1 ' Reset grid sebelum mengisi data baru

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "DetailID") = 0
                    .Item(i, "ByTanggal") = ByTanggal
                    If rdTglNota.Checked = True Then
                        .Item(i, "Tanggal") = row("NotaDate")
                    ElseIf rdTglBoking.Checked = True Then
                        .Item(i, "Tanggal") = row("BookingPabrikDate")
                    ElseIf rdTglCheckin.Checked = True Then
                        .Item(i, "Tanggal") = row("CheckinPabrikDate")
                    End If
                    .Item(i, "IDPancang") = row("IDPancang")
                    .Item(i, "Pancang") = row("Pancang")
                    .Item(i, "IDKapal") = row("KapalID")
                    .Item(i, "Kapal") = row("Kapal")
                    .Item(i, "Trip") = row("Trip")
                    .Item(i, "NotaVia") = row("NotaVia")
                    .Item(i, "Netto2Pancang") = row("NettoAkhir")
                    .Item(i, "Tarif") = row("Tarif")
                    .Item(i, "TotalRp") = row("NettoAkhir") * row("Tarif")
                    .Item(i, "TarifPajak") = 0
                    .Item(i, "DPP") = 0
                    .Item(i, "AkumulasiDPP") = 0
                    .Item(i, "PotPPH21") = 0
                    .Item(i, "PotPPH23") = 0
                    .Item(i, "PotBPJS") = 0
                    .Item(i, "GrandTotal") = 0
                    .Item(i, "PotonganDP") = 0
                    .Item(i, "SisaDP") = 0

                    i += 1
                Next

                ' BARIS TOTAL (TERAKHIR)
                .AddItem("")
                .Item(.Rows.Count - 1, "ByTanggal") = "Total"
                ' STYLE TOTAL
                .Rows(.Rows.Count - 1).StyleNew.BackColor = Color.LightYellow
                .Rows(.Rows.Count - 1).StyleNew.Font = New Font(.Font, FontStyle.Bold)

                Call GetDetailPenerimaUang()

                Call AkumulasiTotal()

                .AutoSizeCols()
            Else
                MsgBoxCustom.Show("Tidak ada data.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            End If
        End With
    End Sub

    Public Sub ShowDataView(ByVal HeaderID As Integer)
        ' set view
        txtNoTrans.Enabled = False
        dtpTanggalPengajuan.Enabled = False
        rdTglNota.Enabled = False
        rdTglBoking.Enabled = False
        rdTglCheckin.Enabled = False
        dtpNota1.Enabled = False
        dtpNota2.Enabled = False
        dtpboking1.Enabled = False
        dtpboking2.Enabled = False
        dtpCheckin1.Enabled = False
        dtpCheckin2.Enabled = False
        cboPancang.Enabled = False
        txtTrip.Enabled = False
        txtTrip2.Enabled = False
        btnSearch.Enabled = False
        cboPenerimaUang.Enabled = False
        cboNoTransBPJS.Enabled = False
        btnSave.Enabled = False

        fg.AllowEditing = True

        If StatusOpenForm = "Edit" Then
            btnSave.Enabled = True
        Else
            btnSave.Enabled = False
        End If

        ' load header
        Dim dtHdr As New DataTable
        dtHdr = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select * from RMPApp..tblTrnUpahBongkarHdr where HeaderID=" & HeaderID)

        txtHeaderID.Text = dtHdr.Rows(0).Item("HeaderID").ToString()
        txtNoTrans.Text = dtHdr.Rows(0).Item("NoTrans").ToString()
        dtpTanggalPengajuan.Value = CDate(dtHdr.Rows(0).Item("TanggalPengajuan"))
        If dtHdr.Rows(0).Item("ByTanggal").ToString() = "NOTA" Then
            rdTglNota.Checked = True
            dtpNota1.Value = CDate(dtHdr.Rows(0).Item("ByTanggalStart"))
            dtpNota2.Value = CDate(dtHdr.Rows(0).Item("ByTanggalEnd"))
        ElseIf dtHdr.Rows(0).Item("ByTanggal").ToString() = "BOOKING" Then
            rdTglBoking.Checked = True
            dtpboking1.Value = CDate(dtHdr.Rows(0).Item("ByTanggalStart"))
            dtpboking2.Value = CDate(dtHdr.Rows(0).Item("ByTanggalEnd"))
        ElseIf dtHdr.Rows(0).Item("ByTanggal").ToString() = "CHECKIN" Then
            rdTglCheckin.Checked = True
            dtpCheckin1.Value = CDate(dtHdr.Rows(0).Item("ByTanggalStart"))
            dtpCheckin2.Value = CDate(dtHdr.Rows(0).Item("ByTanggalEnd"))
        End If
        cboPancang.SelectedValue = dtHdr.Rows(0).Item("IDPancang")
        cboPenerimaUang.SelectedValue = dtHdr.Rows(0).Item("IDNoRek")
        Call GetDetailPenerimaUang()

        ' load detail
        Dim dt As New DataTable
        Dim i As Integer = 1
        Dim sql As String = "select * from vwTrnUpahBongkar where HeaderID=" & HeaderID & "order by DetailID asc"

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fg
            .Rows.Count = 1 ' Reset grid sebelum mengisi data baru

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "DetailID") = row("DetailID")
                    .Item(i, "ByTanggal") = row("ByTanggal")
                    .Item(i, "Tanggal") = row("Tanggal")
                    .Item(i, "IDPancang") = row("IDPancang")
                    .Item(i, "Pancang") = row("Pancang")
                    .Item(i, "IDKapal") = row("IDKapal")
                    .Item(i, "Kapal") = row("Kapal")
                    .Item(i, "Trip") = row("Trip")
                    .Item(i, "NotaVia") = row("NotaVia")
                    .Item(i, "NamaRelasi") = row("NamaRelasi")
                    .Item(i, "IDRelasi") = row("IDRelasi")
                    .Item(i, "RekeningName") = row("NamaRelasi")
                    .Item(i, "RekeningNo") = row("RekeningNo")
                    .Item(i, "RekeningBank") = row("RekeningBank")
                    .Item(i, "BadanUsaha") = row("BadanUsaha")
                    .Item(i, "Netto2Pancang") = row("Netto2Pancang")
                    .Item(i, "Tarif") = row("Tarif")
                    .Item(i, "TotalRp") = row("TotalRp")
                    .Item(i, "DPP") = row("DPP")
                    .Item(i, "AkumulasiDPP") = row("AkumulasiDPP")
                    .Item(i, "TarifPajak") = row("TarifPajak")
                    .Item(i, "PotPPH21") = row("PotPPH21")
                    .Item(i, "PotPPH23") = row("PotPPH23")
                    .Item(i, "PotBPJS") = row("PotBPJS")
                    .Item(i, "PotonganDP") = row("PotonganDP")
                    .Item(i, "SisaDP") = row("SisaDP")
                    .Item(i, "GrandTotal") = row("GrandTotal")

                    i += 1
                Next

                .AutoSizeCols()
            End If

            ' BARIS TOTAL (TERAKHIR)
            .AddItem("")
            .Item(.Rows.Count - 1, "ByTanggal") = "Total"
            ' STYLE TOTAL
            .Rows(.Rows.Count - 1).StyleNew.BackColor = Color.LightYellow
            .Rows(.Rows.Count - 1).StyleNew.Font = New Font(.Font, FontStyle.Bold)
        End With

        'btnKalkulasi.PerformClick()
        Call AkumulasiTotal()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        FrmTrnUpahBongkar.ShowData()
        FrmTrnUpahBongkar.Show(FrmMain.DockPanel1)
        FrmTrnUpahBongkar.Activate()
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveData()
    End Sub

    Private Sub SaveData()
        ' === Deklarasi koneksi dan transaksi ===
        Dim Conn As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnRMPApp)
        Dim Trans As SqlTransaction = Conn.BeginTransaction()
        Dim HeaderID As Integer = 0

        If SudahKalkilasi = False Then
            MsgBoxCustom.Show("Silakan lakukan kalkulasi sebelum menyimpan data.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
            Exit Sub
        End If

        ' wajib isi pancnag
        If cboPancang.SelectedIndex = -1 Then
            MsgBoxCustom.Show("Pancang wajib dipilih.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
            Exit Sub
        End If

        ' wajib pilih penerima uang
        If cboPenerimaUang.SelectedIndex = -1 Then
            MsgBoxCustom.Show("Penerima Uang wajib dipilih.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
            Exit Sub
        End If

        Dim isKapalBerbeda As Boolean = False
        Dim Kapal As String = ""
        For i = 1 To fg.Rows.Count - 2
            If Kapal = "" Then
                Kapal = fg.Item(i, "Kapal")
            ElseIf Kapal <> fg.Item(i, "Kapal") Then
                isKapalBerbeda = True
            End If
        Next
        If isKapalBerbeda Then
            MsgBoxCustom.Show("Tidak diperbolehkan menyimpan data dengan Kapal yang berbeda.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Exit Sub
        End If

        If MsgBoxCustom.Show("Apakah Anda yakin ingin menyimpan data ini?", MsgBoxCustom.ButtonType.YesNo, MsgBoxCustom.IconType.Question) = vbNo Then
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        Try
            If StatusOpenForm = "" Then
                ' === 1. Simpan HEADER ===
                HeaderID = SaveHdr(Conn, Trans)
                If HeaderID = 0 Then
                    Throw New Exception("Simpan Data Header Gagal!")
                End If

                ' === 2. Simpan DETAIL ===
                For r As Integer = 1 To fg.Rows.Count - 2
                    If SaveDtl(Conn, Trans, HeaderID, r) = False Then
                        Throw New Exception("Simpan Data Detail Gagal pada baris ke-" & r)
                    End If
                Next
            Else
                ' === 2. Simpan DETAIL ===
                For r As Integer = 1 To fg.Rows.Count - 2
                    If SaveDtl(Conn, Trans, HeaderID, r) = False Then
                        Throw New Exception("Simpan Data Detail Gagal pada baris ke-" & r)
                    End If
                Next
            End If


            ' === 3. Commit jika semua sukses ===
            Trans.Commit()
            MsgBoxCustom.Show("Data berhasil disimpan", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)

            Call ShowDataView(txtHeaderID.Text)
        Catch ex As Exception
            ' === Rollback jika ada error ===
            Try
                Trans.Rollback()
            Catch
            End Try

            MsgBoxCustom.Show(ex.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)

        Finally
            ' === Tutup koneksi dan kembalikan cursor ===
            If Conn.State = ConnectionState.Open Then Conn.Close()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function SaveHdr(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Long

        SaveHdr = 0

        Try
            Using cmd As New SqlCommand("RMPApp..sp_TrnUpahBongkarHdr", Conn, Trans)
                cmd.CommandType = CommandType.StoredProcedure

                ' INPUT PARAMETERS
                cmd.Parameters.Add("@TanggalPengajuan", SqlDbType.Date).Value =
                dtpTanggalPengajuan.Value

                cmd.Parameters.Add("@ByTanggal", SqlDbType.VarChar, 30).Value =
                fg.Item(1, "ByTanggal")

                If fg.Item(1, "ByTanggal") = "NOTA" Then
                    cmd.Parameters.Add("@ByTanggalStart", SqlDbType.Date).Value =
                    dtpNota1.Value
                    cmd.Parameters.Add("@ByTanggalEnd", SqlDbType.Date).Value =
                    dtpNota2.Value
                ElseIf fg.Item(1, "ByTanggal") = "BOOKING" Then
                    cmd.Parameters.Add("@ByTanggalStart", SqlDbType.Date).Value =
                    dtpboking1.Value
                    cmd.Parameters.Add("@ByTanggalEnd", SqlDbType.Date).Value =
                    dtpboking2.Value
                ElseIf fg.Item(1, "ByTanggal") = "CHECKIN" Then
                    cmd.Parameters.Add("@ByTanggalStart", SqlDbType.Date).Value =
                    dtpCheckin1.Value
                    cmd.Parameters.Add("@ByTanggalEnd", SqlDbType.Date).Value =
                    dtpCheckin2.Value
                End If

                cmd.Parameters.Add("@IDPancang", SqlDbType.Int).Value =
                CInt(cboPancang.SelectedValue)

                cmd.Parameters.Add("@IDNoRek", SqlDbType.BigInt).Value =
                CLng(cboPenerimaUang.SelectedValue)

                cmd.Parameters.Add("@IDPotBPJS", SqlDbType.BigInt).Value =
                If(cboNoTransBPJS.Text = "", 0,
                   cboNoTransBPJS.SelectedValue)

                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 100).Value =
                ClsSession.UserID

                cmd.Parameters.Add("@Trip", SqlDbType.VarChar, 30).Value =
                Replace(txtTrip.Text, " ", "")

                cmd.Parameters.Add("@Trip2", SqlDbType.VarChar, 30).Value =
                Replace(txtTrip2.Text, " ", "")

                ' OUTPUT PARAMETERS
                cmd.Parameters.Add("@NoTrans", SqlDbType.VarChar, 30).Direction =
                ParameterDirection.Output

                cmd.Parameters.Add("@HeaderID", SqlDbType.BigInt).Direction =
                ParameterDirection.Output

                cmd.Parameters.Add("@Flag", SqlDbType.Int).Direction =
                ParameterDirection.Output

                ' EXECUTE
                cmd.ExecuteNonQuery()

                ' RESULT
                Dim resultFlag As Integer = Convert.ToInt32(cmd.Parameters("@Flag").Value)

                If resultFlag = 1 Then
                    SaveHdr = Convert.ToInt64(cmd.Parameters("@HeaderID").Value)
                    txtHeaderID.Text = Convert.ToInt64(cmd.Parameters("@HeaderID").Value)
                    txtNoTrans.Text = cmd.Parameters("@NoTrans").Value.ToString()
                Else
                    SaveHdr = 0
                End If

            End Using

        Catch ex As Exception
            MsgBoxCustom.Show("Error saat simpan header: " & ex.Message,
               MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
            SaveHdr = 0
        End Try

        Return SaveHdr
    End Function

    Private Function SaveDtl(ByVal Conn As SqlConnection,
                          ByVal Trans As SqlTransaction,
                          ByVal HeaderID As Long,
                          ByVal r As Integer) As Boolean

        Try
            Using cmd As New SqlCommand("dbo.sp_TrnUpahBongkarDtl", Conn, Trans)
                cmd.CommandType = CommandType.StoredProcedure

                With cmd.Parameters
                    .Add("@HeaderID", SqlDbType.BigInt).Value = HeaderID
                    .Add("@DetailID", SqlDbType.BigInt).Value = fg.Item(r, "DetailID")
                    .Add("@ByTanggal", SqlDbType.VarChar, 30).Value = fg.Item(r, "ByTanggal")
                    .Add("@Tanggal", SqlDbType.Date).Value = CDate(fg.Item(r, "Tanggal"))
                    .Add("@Trip", SqlDbType.Int).Value = CInt(fg.Item(r, "Trip"))
                    .Add("@IDPancang", SqlDbType.Int).Value = CInt(fg.Item(r, "IDPancang"))
                    .Add("@IDKapal", SqlDbType.Int).Value = CInt(fg.Item(r, "IDKapal"))
                    .Add("@NotaVia", SqlDbType.VarChar, 20).Value = fg.Item(r, "NotaVia")
                    .Add("@IDRelasi", SqlDbType.VarChar, 30).Value = fg.Item(r, "IDRelasi")
                    .Add("@NamaRelasi", SqlDbType.VarChar, 150).Value = fg.Item(r, "NamaRelasi")
                    .Add("@RekeningName", SqlDbType.VarChar, 150).Value = fg.Item(r, "RekeningName")
                    .Add("@RekeningNo", SqlDbType.VarChar, 30).Value = fg.Item(r, "RekeningNo")
                    .Add("@RekeningBank", SqlDbType.VarChar, 50).Value = fg.Item(r, "RekeningBank")
                    .Add("@BadanUsaha", SqlDbType.VarChar, 20).Value = fg.Item(r, "BadanUsaha")

                    .Add("@Netto2Pancang", SqlDbType.BigInt).Value = CLng(fg.Item(r, "Netto2Pancang"))
                    .Add("@Tarif", SqlDbType.Int).Value = CInt(fg.Item(r, "Tarif"))
                    .Add("@TotalRp", SqlDbType.Decimal).Value = CDec(fg.Item(r, "TotalRp"))
                    .Add("@DPP", SqlDbType.Decimal).Value = CDec(fg.Item(r, "DPP"))
                    .Add("@AkumulasiDPP", SqlDbType.Decimal).Value = CDec(fg.Item(r, "AkumulasiDPP"))
                    .Add("@TarifPajak", SqlDbType.VarChar, 10).Value = fg.Item(r, "TarifPajak")

                    .Add("@PotPPH21", SqlDbType.Decimal).Value = CDec(fg.Item(r, "PotPPH21"))
                    .Add("@PotPPH23", SqlDbType.Decimal).Value = CDec(fg.Item(r, "PotPPH23"))
                    .Add("@PotBPJS", SqlDbType.Decimal).Value = CDec(fg.Item(r, "PotBPJS"))
                    .Add("@PotonganDP", SqlDbType.Decimal).Value = CDec(fg.Item(r, "PotonganDP"))
                    .Add("@GrandTotal", SqlDbType.Decimal).Value = CDec(fg.Item(r, "GrandTotal"))

                    .Add("@CreatedBy", SqlDbType.VarChar, 100).Value = ClsSession.UserID

                    .Add("@Flag", SqlDbType.Int).Direction = ParameterDirection.Output
                End With

                cmd.ExecuteNonQuery()
                Return CInt(cmd.Parameters("@Flag").Value) = 1
            End Using

        Catch ex As SqlException
            ' Pesan dari RAISERROR di SP (mis. "Transaksi sudah di-approve, tidak dapat dimodifikasi.")
            ' akan muncul langsung di ex.Message, jadi ditampilkan apa adanya tanpa prefix teknis.
            MessageBox.Show(ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False

        Catch ex As Exception
            MessageBox.Show("Error simpan detail : " & ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function


    Private Sub cboPenerimaUang_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPenerimaUang.SelectedIndexChanged
        Call GetDetailPenerimaUang()

        SudahKalkilasi = False
    End Sub

    Private Sub GetDetailPenerimaUang()
        If IsNumeric(cboPenerimaUang.SelectedValue) Then
            cboNoTransBPJS.DataSource = Nothing
            cboNoTransBPJS.Items.Clear()
            cboNoTransBPJS.SelectedIndex = -1

            Dim dt As DataTable = New DataTable

            dt = Modul_RMP.DB.ExecuteQuery(StrConnAccounting, "select b.KodeSup,b.NamaSup,a.NamaRekening,a.NoRekening,a.JenisBank,isnull(PTCV,0) as PTCV
                                                            from vwRMMstRekeningPancang as a 
                                                            inner join tblRMMstSupplier as b on a.IDPetani=b.KodeSup
                                                            where IDNoRek=" & cboPenerimaUang.SelectedValue)

            For r = 1 To fg.Rows.Count - 2
                fg.Item(r, "IDRelasi") = dt.Rows(0).Item("KodeSup").ToString
                fg.Item(r, "NamaRelasi") = dt.Rows(0).Item("NamaSup").ToString
                fg.Item(r, "RekeningName") = dt.Rows(0).Item("NamaRekening").ToString
                fg.Item(r, "RekeningNo") = dt.Rows(0).Item("NoRekening").ToString
                fg.Item(r, "RekeningBank") = dt.Rows(0).Item("JenisBank").ToString
                If dt.Rows(0).Item("PTCV") = True Then
                    fg.Item(r, "BadanUsaha") = "PT/CV"
                Else
                    fg.Item(r, "BadanUsaha") = "Pribadi"
                End If
            Next

            Call AutoGenerateMasterSupplierProgramAcc()

            Call AkumulasiTotal()

            Call GetPotongan()
        End If
    End Sub

    Public Sub GetPotongan()
        ' BPJS
        Dim dtBPJS As DataTable = New DataTable()
        dtBPJS = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select * from RMPApp..fnTrnPotonganRelasi('BPJS','Upah Bongkar'," & cboPenerimaUang.SelectedValue & ",NULL) order by Value asc")
        With cboNoTransBPJS
            .DataSource = dtBPJS
            .DisplayMember = "Member"
            .ValueMember = "Value"
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub cboNoTransBPJS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboNoTransBPJS.SelectedIndexChanged
        If cboNoTransBPJS.SelectedIndex = -1 Then Exit Sub
        If cboNoTransBPJS.SelectedValue Is Nothing Then Exit Sub
        If Not IsNumeric(cboNoTransBPJS.SelectedValue) Then Exit Sub
        If Not IsNumeric(cboNoTransBPJS.Text) Then Exit Sub

        SudahKalkilasi = False
    End Sub

    Private Sub dtpTanggalPengajuan_ValueChanged(sender As Object, e As EventArgs) Handles dtpTanggalPengajuan.ValueChanged
        fg.Rows.Count = 1

        SudahKalkilasi = False
    End Sub

    Private Sub rdTglNota_CheckedChanged(sender As Object, e As EventArgs) Handles rdTglNota.CheckedChanged
        fg.Rows.Count = 1

        SudahKalkilasi = False
    End Sub

    Private Sub cboPancang_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPancang.SelectedIndexChanged
        fg.Rows.Count = 1

        SudahKalkilasi = False
    End Sub

    Private Sub btnKalkulasi_Click(sender As Object, e As EventArgs) Handles btnKalkulasi.Click
        ' cek jika kolom relasi kosong
        For r As Integer = 1 To fg.Rows.Count - 2
            If fg.Item(r, "IDRelasi") = "" Then
                MsgBoxCustom.Show("Relasi pada baris ke-" & r & " masih kosong." & vbCrLf &
                   "Silakan pilih Penerima Uang yang sesuai.",
                   MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
                Exit Sub
            End If
        Next

        Dim totalBPJS As Decimal = If(String.IsNullOrWhiteSpace(cboNoTransBPJS.Text),
                               0D,
                               CDec(cboNoTransBPJS.Text))

        With fg
            ' VALIDASI TOTAL
            Dim totalSisa As Decimal = 0

            For r As Integer = 1 To .Rows.Count - 2
                totalSisa +=
                CDec(.Item(r, "TotalRp")) -
                (CDec(.Item(r, "PotPPH21")) + CDec(.Item(r, "PotPPH23")))
            Next

            If totalSisa < totalBPJS Then
                MsgBoxCustom.Show("Total upah setelah pajak lebih kecil dari potongan BPJS yang dipilih." &
                   vbCrLf & "Silakan pilih potongan BPJS yang sesuai.",
                   MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)

                cboNoTransBPJS.SelectedIndex = -1
                Exit Sub
            End If

            ' DISTRIBUSI BPJS
            Dim sisaBPJS As Decimal = totalBPJS

            For r As Integer = 1 To .Rows.Count - 2

                If sisaBPJS <= 0 Then
                    .Item(r, "PotBPJS") = 0
                    Continue For
                End If

                Dim maxBPJSBaris As Decimal =
                CDec(.Item(r, "TotalRp")) -
                (CDec(.Item(r, "PotPPH21")) + CDec(.Item(r, "PotPPH23")))

                If sisaBPJS >= maxBPJSBaris Then
                    .Item(r, "PotBPJS") = maxBPJSBaris
                    sisaBPJS -= maxBPJSBaris
                Else
                    .Item(r, "PotBPJS") = sisaBPJS
                    sisaBPJS = 0
                End If
            Next

            Call AkumulasiTotal()
        End With

        SudahKalkilasi = True

        MsgBoxCustom.Show("Kalkulasi selesai.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
    End Sub

    Private Sub txtTrip_TextChanged(sender As Object, e As EventArgs) Handles txtTrip.TextChanged
        txtTrip2.Text = txtTrip.Text

        fg.Rows.Count = 1

        SudahKalkilasi = False
    End Sub

    Private Sub txtTrip2_TextChanged(sender As Object, e As EventArgs) Handles txtTrip2.TextChanged
        If Replace(txtTrip2.Text, " ", "") = "" Then
            txtTrip.Text = ""
        End If

        fg.Rows.Count = 1

        SudahKalkilasi = False
    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg.BeforeEdit
        Select Case StatusOpenForm
            Case "Edit"
                If fg.Cols(e.Col).Name = "PotonganDP" Then
                    e.Cancel = False
                Else
                    e.Cancel = True
                End If
            Case Else
                e.Cancel = True
        End Select
    End Sub

    Private Sub AutoGenerateMasterSupplierProgramAcc()
        Dim SupplierID As String = DB.ExecuteScalarValue(Of String)(StrConnAccounting, "select IDPetani as GetValueString from vwRMMstRekeningPancang where IDNoRek=" & cboPenerimaUang.SelectedValue)

        ' Cek jika belum ada di program Acc
        If DB.ExecuteScalarValue(Of String)(StrConnDBPancang, "select isnull((select SupplierID from tblGENMstSupplier where SupplierID='" & SupplierID & "'),'') as GetValueString") = "" Then
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
                        from RSUPAccounting..tblRMMstSupplier where KodeSup='" & SupplierID & "'

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
    End Sub

    Private Sub fg_AfterEdit(sender As Object, e As RowColEventArgs) Handles fg.AfterEdit
        Select Case fg.Cols(e.Col).Name
            Case "PotonganDP"
                If CInt(fg.Item(fg.Row, "PotonganDP")) > CInt(fg.Item(fg.Row, "GrandTotal")) Then
                    MsgBoxCustom.Show("Potongan DP tidak boleh lebih besar dari Grand Total.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
                    fg.Item(fg.Row, "PotonganDP") = 0
                    Exit Sub
                ElseIf CInt(fg.Item(fg.Row, "PotonganDP")) > CInt(fg.Item(fg.Row, "SisaDP")) Then
                    MsgBoxCustom.Show("Potongan DP tidak boleh lebih besar dari Sisa DP.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
                    fg.Item(fg.Row, "PotonganDP") = 0
                    Exit Sub
                End If
        End Select

        If fg.Cols(e.Col).Name = "PotLainLain" Then
            If fg.Item(e.Row, "PotLainLain") = "" Then
                fg.Item(e.Row, "PotLainLain") = 0
            End If

            fg.Item(e.Row, "PotLainLain") = Format(CInt(fg.Item(e.Row, "PotLainLain")), "N0")

            Call AkumulasiTotal()
        End If
    End Sub

    Private Sub AkumulasiTotal()
        Dim totalPotonganExsternal As Decimal = 0 ' masuk ke accounting
        Dim grandTotal As Decimal = 0
        Dim Tnetto, Ttotal, Tpph21, Tpph23, Tbpjs, Tgrand As Integer

        For r As Integer = 1 To fg.Rows.Count - 2
            ' hitung pajak
            If fg.Item(r, "BadanUsaha") = "Pribadi" Then
                fg.Item(r, "DPP") = Format(fg.Item(r, "TotalRp") / 2, "N0")
                Dim AkumulasiDPP As Decimal = DB.ExecuteScalarValue(Of Integer)(StrConnRMPApp, "select isnull((select cast(sum(DPP) as decimal(18,0)) as DPP from RMPApp..fnMonAkumulasiDPPRelasi('" & Format(dtpTanggalPengajuan.Value, "yyyy-MM-dd") & "','" & fg.Item(r, "IDRelasi") & "')),0) as GetValueInteger")
                For i = 1 To fg.Rows.Count - 1
                    AkumulasiDPP = AkumulasiDPP + CDec(fg.Item(i, "DPP"))
                    fg.Item(r, "AkumulasiDPP") = AkumulasiDPP
                Next
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
            totalPotonganExsternal = CDec(fg.Item(r, "PotPPH21")) + CDec(fg.Item(r, "PotPPH23")) + CDec(fg.Item(r, "PotBPJS")) + CDec(fg.Item(r, "PotonganDP"))

            grandTotal = CDec(fg.Item(r, "TotalRp")) - totalPotonganExsternal

            fg.Item(r, "GrandTotal") = Format(grandTotal, "N0")

            ' tambahkan total
            Tnetto = Tnetto + CInt(fg.Item(r, "Netto2Pancang"))
            Ttotal = Ttotal + CInt(fg.Item(r, "TotalRp"))
            Tpph21 = Tpph21 + CInt(fg.Item(r, "PotPPH21"))
            Tpph23 = Tpph23 + CInt(fg.Item(r, "PotPPH23"))
            Tbpjs = Tbpjs + CInt(fg.Item(r, "PotBPJS"))
            Tgrand = Tgrand + CInt(fg.Item(r, "GrandTotal"))
        Next

        If fg.Rows.Count >= 3 Then
            ' tampilkan total di baris terakhir
            fg.Item(fg.Rows.Count - 1, "Netto2Pancang") = Format(Tnetto, "N0")
            fg.Item(fg.Rows.Count - 1, "TotalRp") = Format(Ttotal, "N0")
            fg.Item(fg.Rows.Count - 1, "PotPPH21") = Format(Tpph21, "N0")
            fg.Item(fg.Rows.Count - 1, "PotPPH23") = Format(Tpph23, "N0")
            fg.Item(fg.Rows.Count - 1, "PotBPJS") = Format(Tbpjs, "N0")
            fg.Item(fg.Rows.Count - 1, "GrandTotal") = Format(Tgrand, "N0")
        End If

        fg.AutoSizeCols()
    End Sub
End Class