Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Windows.Interop
Imports C1.Win.C1FlexGrid
Imports DocumentFormat.OpenXml.Drawing.Diagrams

Public Class FrmTrnTambangKapalBPI
    Public StatusOpenForm As String = ""
    Dim jalan, Indlebih, IndRelasi, indumharganego As Integer
    Dim tujuan, waktuPengajuan As String

    Private Sub FrmTrnApprovalPenerimaan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call ClsFlexGrid.ApplyStyle(fg)
        Call ClsFlexGrid.AttachLiveNumber(fg, 0, "PotLainLain", "PotonganDP")
        Call ClsFlexGrid.SetEditableColumns(fg, "PotLainLain", "KetPotLainLain", "PotonganDP")

        Modul_RMP.Combo.Setpenerimauang(cboPenerimaUang)

        If StatusOpenForm = "Edit" Then
            fg.Cols("SisaDP").Visible = True
        Else
            fg.Cols("SisaDP").Visible = False
        End If
    End Sub

    Public Sub LoadData(ByVal Bongkar As String, ByVal IDPancang As Integer, ByVal IDKapal As Integer, ByVal Trip As Integer)
        Dim dt As New DataTable
        Dim i As Integer = 1
        Dim sql As String = "select * from vw_TrnTambangKapalBPI
                                where Bongkar='" & Bongkar & "'
                                and IDPancang=" & IDPancang & "
                                and IDKapal=" & IDKapal & "
                                and Trip=" & Trip & "
                                order by Kg desc"

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fg
            .Rows.Count = 1 ' Reset grid sebelum mengisi data baru

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "Tujuan") = row("Bongkar")
                    .Item(i, "IDPancang") = row("IDPancang")
                    .Item(i, "Pancang") = row("Pancang")
                    .Item(i, "IDKapal") = row("IDKapal")
                    .Item(i, "Kapal") = row("Kapal")
                    .Item(i, "Trip") = row("Trip")
                    .Item(i, "Jenis") = row("Jenis")
                    .Item(i, "Netto1Pabrik") = row("Kg")
                    .Item(i, "Tarif") = row("Tarif")
                    .Item(i, "TotalRp") = row("Kg") * row("Tarif")
                    .Item(i, "PotSusut") = 0
                    .Item(i, "PotLainLain") = 0
                    .Item(i, "KetPotLainLain") = ""
                    .Item(i, "TotalAkhir") = 0
                    .Item(i, "DPP") = 0
                    .Item(i, "AkumulasiDPP") = 0
                    .Item(i, "TarifPajak") = "5%"
                    .Item(i, "PotPPH21") = 0
                    .Item(i, "PotPPH23") = 0
                    .Item(i, "PotGPS") = 0
                    .Item(i, "PotBPJS") = 0
                    .Item(i, "PotOlahGerak") = 0

                    txtIDAsuransi.Text = row("IDPremiKapal")
                    If i = 1 Then
                        .Item(i, "PotAsuransi") = row("PremiKapal")
                    Else
                        .Item(i, "PotAsuransi") = 0
                    End If

                    .Item(i, "PotonganDP") = 0
                    .Item(i, "GrandTotal") = 0

                    i += 1
                Next

                ' BARIS TOTAL (TERAKHIR)
                .AddItem("")
                .Item(.Rows.Count - 1, "Tujuan") = "Total"
                ' STYLE TOTAL
                .Rows(.Rows.Count - 1).StyleNew.BackColor = Color.LightYellow
                .Rows(.Rows.Count - 1).StyleNew.Font = New Font(.Font, FontStyle.Bold)

                Call GetDetailPenerimaUang()

                Call AkumulasiTotal()

                .AutoSizeCols()
            Else
                MsgBox("Tidak ada data.", vbInformation, AT)
            End If
        End With
    End Sub

    Public Sub ShowDataView(ByVal HeaderID As Integer)
        ' set view
        txtNoTrans.Enabled = False
        dtpTanggalPengajuan.Enabled = False
        cboPenerimaUang.Enabled = False
        btnFindKapal.Enabled = False
        cboNoTransSusut.Enabled = False
        cboNoTransGPS.Enabled = False
        cboNoTransBPJS.Enabled = False
        cboNoTransOlahGerak.Enabled = False

        If StatusOpenForm = "Edit" Then
            btnSave.Enabled = True
        Else
            btnSave.Enabled = False
        End If

        ' load header
        Dim dtHdr As New DataTable
        dtHdr = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select * from TblTrnTambangKapalHdr where HeaderID=" & HeaderID)

        txtHeaderID.Text = dtHdr.Rows(0).Item("HeaderID").ToString()
        txtNoTrans.Text = dtHdr.Rows(0).Item("NoTrans").ToString()
        dtpTanggalPengajuan.Value = CDate(dtHdr.Rows(0).Item("TanggalPengajuan"))
        cboPenerimaUang.SelectedValue = dtHdr.Rows(0).Item("IDNoRek")
        Call GetDetailPenerimaUang()
        txtIDAsuransi.Text = dtHdr.Rows(0).Item("IDAsuransi")

        ' load detail
        Dim dt As New DataTable
        Dim i As Integer = 1
        Dim sql As String = "select * from vwTrnTambangKapal WHERE HeaderID=" & HeaderID & " order by DetailID desc"

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fg
            .Rows.Count = 1 ' Reset grid sebelum mengisi data baru

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "DetailID") = row("DetailID")
                    .Item(i, "Tujuan") = row("Tujuan")
                    .Item(i, "Trip") = row("Trip")
                    .Item(i, "IDPancang") = row("IDPancang")
                    .Item(i, "Pancang") = row("Pancang")
                    .Item(i, "IDKapal") = row("IDKapal")
                    .Item(i, "Kapal") = row("Kapal")
                    .Item(i, "Jenis") = row("Jenis")
                    .Item(i, "SupplierID") = row("SupplierID")
                    .Item(i, "SupplierName") = row("NamaSup")
                    .Item(i, "RekeningName") = row("RekeningName")
                    .Item(i, "RekeningNo") = row("RekeningNo")
                    .Item(i, "RekeningBank") = row("RekeningBank")
                    .Item(i, "BadanUsaha") = row("BadanUsaha")
                    .Item(i, "Netto1Pabrik") = row("Netto1Pabrik")
                    .Item(i, "Tarif") = row("Tarif")
                    .Item(i, "TotalRp") = row("TotalRp")
                    .Item(i, "PotSusut") = row("PotSusut")
                    .Item(i, "PotLainLain") = row("PotLainLain")
                    .Item(i, "KetPotLainLain") = row("KetPotLainLain")
                    .Item(i, "TotalAkhir") = row("TotalAkhir")
                    .Item(i, "DPP") = row("DPP")
                    .Item(i, "AkumulasiDPP") = row("AkumulasiDPP")
                    .Item(i, "TarifPajak") = row("TarifPajak")
                    .Item(i, "PotPPHUMKM") = row("PotPPHUMKM")
                    .Item(i, "PotPPH21") = row("PotPPH21")
                    .Item(i, "PotPPH23") = row("PotPPH23")
                    .Item(i, "PotGPS") = row("PotGPS")
                    .Item(i, "PotBPJS") = row("PotBPJS")
                    .Item(i, "PotOlahGerak") = row("PotOlahGerak")
                    .Item(i, "PotAsuransi") = row("PotAsuransi")
                    .Item(i, "PotonganDP") = row("PotonganDP")
                    .Item(i, "SisaDP") = row("SisaDP")
                    .Item(i, "GrandTotal") = row("GrandTotal")

                    i += 1
                Next

                ' BARIS TOTAL (TERAKHIR)
                .AddItem("")
                .Item(.Rows.Count - 1, "Tujuan") = "Total"
                ' STYLE TOTAL
                .Rows(.Rows.Count - 1).StyleNew.BackColor = Color.LightYellow
                .Rows(.Rows.Count - 1).StyleNew.Font = New Font(.Font, FontStyle.Bold)

                .AutoSizeCols()
            End If
        End With

        Call AkumulasiTotal()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        FrmTrnTambangKapalBPIFind.ShowData()
        FrmTrnTambangKapalBPIFind.Show(FrmMain.DockPanel1)
        FrmTrnTambangKapalBPIFind.Activate()
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Call AkumulasiTotal()

        Call SaveData()
    End Sub

    Private Sub SaveData()
        ' === Deklarasi koneksi dan transaksi ===
        Dim Conn As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnRMPApp)
        Dim Trans As SqlTransaction = Conn.BeginTransaction()
        Dim HeaderID As Integer = 0
        Dim ErrMsg As String = ""

        If MsgBox("Apakah Anda yakin ingin menyimpan data ini?", vbQuestion + vbYesNo, AT) = vbNo Then
            Exit Sub
        End If

        ' jika PotLainLain > 0 wajib isi keterangan
        For r As Integer = 1 To fg.Rows.Count - 2
            Dim potLain As Decimal = If(fg.Item(r, "PotLainLain") Is Nothing, 0D, CDec(fg.Item(r, "PotLainLain")))
            Dim ket As String = If(fg.Item(r, "KetPotLainLain") Is Nothing, "", fg.Item(r, "KetPotLainLain").ToString().Trim())

            If potLain > 0 And ket = "" Then
                MsgBox("Keterangan Potongan Lain-Lain wajib diisi pada baris ke-" & r,
               vbExclamation, AT)
                Exit Sub
            End If
        Next


        ' wajib pilih penerima uang
        If cboPenerimaUang.SelectedIndex = -1 Then
            MsgBox("Penerima Uang wajib dipilih.", vbExclamation, AT)
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
                    If SaveDtl(Conn, Trans, HeaderID, r, ErrMsg) = False Then
                        Throw New Exception(ErrMsg)
                    End If
                Next
            ElseIf StatusOpenForm = "Edit" Then
                ' === 2. Simpan DETAIL ===
                For r As Integer = 1 To fg.Rows.Count - 2
                    If CInt(fg.Item(fg.Row, "PotonganDP")) > 0 Then
                        If SaveDtl(Conn, Trans, HeaderID, r, ErrMsg) = False Then
                            Throw New Exception(ErrMsg)
                        End If
                    End If
                Next
            End If

            ' === 3. Commit jika semua sukses ===
            Trans.Commit()
            MsgBox("Data berhasil disimpan", vbInformation, "Sukses")

            Call ShowDataView(txtHeaderID.Text)
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

    Private Function SaveHdr(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Integer

        SaveHdr = 0

        Try
            Using cmd As New SqlCommand("sp_TrnTambangKapalBPIHdr", Conn, Trans)
                cmd.CommandType = CommandType.StoredProcedure

                ' =====================
                ' INPUT PARAMETERS
                ' =====================
                cmd.Parameters.Add("@TanggalPengajuan", SqlDbType.Date).Value = dtpTanggalPengajuan.Value
                cmd.Parameters.Add("@IDNoRek", SqlDbType.BigInt).Value = cboPenerimaUang.SelectedValue

                cmd.Parameters.Add("@IDPotSusut", SqlDbType.BigInt).Value =
                If(cboNoTransSusut.Text = "", 0, cboNoTransSusut.SelectedValue)

                cmd.Parameters.Add("@IDPotGPS", SqlDbType.BigInt).Value =
                If(cboNoTransGPS.Text = "", 0, cboNoTransGPS.SelectedValue)

                cmd.Parameters.Add("@IDPotBPJS", SqlDbType.BigInt).Value =
                If(cboNoTransBPJS.Text = "", 0, cboNoTransBPJS.SelectedValue)

                cmd.Parameters.Add("@IDPotOlahGerak", SqlDbType.BigInt).Value =
                If(cboNoTransOlahGerak.Text = "", 0, cboNoTransOlahGerak.SelectedValue)

                cmd.Parameters.Add("@IDAsuransi", SqlDbType.BigInt).Value = txtIDAsuransi.Text

                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 100).Value = ClsSession.UserID

                ' =====================
                ' OUTPUT PARAMETERS
                ' =====================
                cmd.Parameters.Add("@HeaderID", SqlDbType.BigInt).Direction = ParameterDirection.Output
                cmd.Parameters.Add("@NoTrans", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                cmd.Parameters.Add("@Flag", SqlDbType.Int).Direction = ParameterDirection.Output

                ' EXECUTE
                cmd.ExecuteNonQuery()

                ' RESULT
                Dim resultFlag As Integer = CInt(cmd.Parameters("@Flag").Value)
                Dim HeaderID As Integer = cmd.Parameters("@HeaderID").Value

                If resultFlag = 1 Then
                    SaveHdr = HeaderID
                    txtHeaderID.Text = HeaderID
                    txtNoTrans.Text = cmd.Parameters("@NoTrans").Value
                Else
                    SaveHdr = 0
                End If
            End Using

        Catch ex As Exception
            MsgBox("Error saat simpan header: " & ex.Message,
               vbCritical, "Error")
            SaveHdr = 0
        End Try

        Return SaveHdr
    End Function


    Private Function SaveDtl(ByVal Conn As SqlConnection,
                            ByVal Trans As SqlTransaction,
                            ByVal HeaderID As Long,
                            ByVal r As Integer,
                            ByRef OutMessage As String) As Boolean

        SaveDtl = False

        Try
            Using cmd As New SqlCommand("sp_TrnTambangKapalBPIDtl", Conn, Trans)
                cmd.CommandType = CommandType.StoredProcedure

                ' ================================
                ' PRIMARY KEY / RELATION
                ' ================================
                cmd.Parameters.Add("@Perintah", SqlDbType.VarChar).Value = IIf(StatusOpenForm = "", "Add", "Edit")
                cmd.Parameters.Add("@DetailID", SqlDbType.BigInt).Value = CInt(fg.Item(r, "DetailID"))
                cmd.Parameters.Add("@HeaderID", SqlDbType.BigInt).Value = HeaderID
                cmd.Parameters.Add("@NoTrans", SqlDbType.VarChar, 50).Value = txtNoTrans.Text

                ' ================================
                ' DATA DARI GRID
                ' ================================
                cmd.Parameters.Add("@Tujuan", SqlDbType.VarChar, 20).Value = fg.Item(r, "Tujuan").ToString()

                cmd.Parameters.Add("@Trip", SqlDbType.Int).Value = CInt(fg.Item(r, "Trip"))

                cmd.Parameters.Add("@IDPancang", SqlDbType.Int).Value = CInt(fg.Item(r, "IDPancang"))

                cmd.Parameters.Add("@IDKapal", SqlDbType.Int).Value = CInt(fg.Item(r, "IDKapal"))

                cmd.Parameters.Add("@Jenis", SqlDbType.VarChar, 20).Value = fg.Item(r, "Jenis").ToString()

                cmd.Parameters.Add("@SupplierID", SqlDbType.VarChar, 30).Value = fg.Item(r, "SupplierID").ToString()

                cmd.Parameters.Add("@RekeningName", SqlDbType.VarChar, 150).Value = fg.Item(r, "RekeningName").ToString()

                cmd.Parameters.Add("@RekeningNo", SqlDbType.VarChar, 30).Value = fg.Item(r, "RekeningNo").ToString()

                cmd.Parameters.Add("@RekeningBank", SqlDbType.VarChar, 50).Value = fg.Item(r, "RekeningBank").ToString()

                cmd.Parameters.Add("@BadanUsaha", SqlDbType.VarChar, 20).Value = fg.Item(r, "BadanUsaha").ToString()

                cmd.Parameters.Add("@Netto1Pabrik", SqlDbType.Int).Value = CInt(fg.Item(r, "Netto1Pabrik"))
                cmd.Parameters.Add("@Tarif", SqlDbType.Int).Value = CInt(fg.Item(r, "Tarif"))

                cmd.Parameters.Add("@TotalRp", SqlDbType.Decimal).Value = CDec(fg.Item(r, "TotalRp"))
                cmd.Parameters.Add("@PotSusut", SqlDbType.Decimal).Value = CDec(fg.Item(r, "PotSusut"))
                cmd.Parameters.Add("@PotLainLain", SqlDbType.Decimal).Value = CDec(fg.Item(r, "PotLainLain"))

                cmd.Parameters.Add("@KetPotLainLain", SqlDbType.VarChar, 500).Value = If(fg.Item(r, "KetPotLainLain") Is Nothing, "", fg.Item(r, "KetPotLainLain").ToString())

                cmd.Parameters.Add("@TotalAkhir", SqlDbType.Decimal).Value = CDec(fg.Item(r, "TotalAkhir"))
                cmd.Parameters.Add("@DPP", SqlDbType.Decimal).Value = CDec(fg.Item(r, "DPP"))
                cmd.Parameters.Add("@AkumulasiDPP", SqlDbType.Decimal).Value = CDec(fg.Item(r, "AkumulasiDPP"))

                cmd.Parameters.Add("@TarifPajak", SqlDbType.VarChar, 10).Value = fg.Item(r, "TarifPajak").ToString()

                cmd.Parameters.Add("@PotPPH21", SqlDbType.Decimal).Value = CDec(fg.Item(r, "PotPPH21"))
                cmd.Parameters.Add("@PotPPH23", SqlDbType.Decimal).Value = CDec(fg.Item(r, "PotPPH23"))
                cmd.Parameters.Add("@PotPPHUMKM", SqlDbType.Decimal).Value = CDec(fg.Item(r, "PotPPHUMKM"))
                cmd.Parameters.Add("@PotGPS", SqlDbType.Decimal).Value = CDec(fg.Item(r, "PotGPS"))
                cmd.Parameters.Add("@PotBPJS", SqlDbType.Decimal).Value = CDec(fg.Item(r, "PotBPJS"))
                cmd.Parameters.Add("@PotOlahGerak", SqlDbType.Decimal).Value = CDec(fg.Item(r, "PotOlahGerak"))

                cmd.Parameters.Add("@PotAsuransi", SqlDbType.Decimal).Value = CDec(fg.Item(r, "PotAsuransi"))

                cmd.Parameters.Add("@PotonganDP", SqlDbType.Decimal).Value = CDec(fg.Item(r, "PotonganDP"))
                cmd.Parameters.Add("@GrandTotal", SqlDbType.Decimal).Value = CDec(fg.Item(r, "GrandTotal"))


                ' ================================
                ' AUDIT
                ' ================================
                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 100).Value = ClsSession.UserID

                ' ================================
                ' OUTPUT
                ' ================================
                cmd.Parameters.Add("@Flag", SqlDbType.Int).Direction = ParameterDirection.Output
                cmd.Parameters.Add("@Message", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output

                cmd.ExecuteNonQuery()

                SaveDtl = (CInt(cmd.Parameters("@Flag").Value) = 1)
                OutMessage = cmd.Parameters("@Message").Value.ToString()
            End Using

        Catch ex As Exception
            MessageBox.Show("Error saat simpan detail: " & ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return SaveDtl
    End Function

    Private Sub cboPenerimaUang_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPenerimaUang.SelectedIndexChanged
        Call GetDetailPenerimaUang()
    End Sub

    Private Sub GetDetailPenerimaUang()
        If IsNumeric(cboPenerimaUang.SelectedValue) Then
            cboNoTransSusut.DataSource = Nothing
            cboNoTransSusut.Items.Clear()
            cboNoTransSusut.Text = ""
            cboNoTransGPS.DataSource = Nothing
            cboNoTransGPS.Items.Clear()
            cboNoTransGPS.Text = ""
            cboNoTransBPJS.DataSource = Nothing
            cboNoTransBPJS.Items.Clear()
            cboNoTransBPJS.Text = ""
            cboNoTransOlahGerak.DataSource = Nothing
            cboNoTransOlahGerak.Items.Clear()
            cboNoTransOlahGerak.Text = ""

            Dim dt As DataTable = New DataTable

            dt = Modul_RMP.DB.ExecuteQuery(StrConnAccounting, "select b.KodeSup, b.NamaSup, a.NamaRekening, a.NoRekening, a.JenisBank, isnull(b.PTCV,0) as PTCV, isnull(b.IndPPHUMKM,0) as IndPPHUMKM
                                                                from vwrmmstrekeningpancang as a 
                                                                inner join tblRMMstSupplier as b on a.IDPetani=b.KodeSup
                                                                where IDNoRek=" & cboPenerimaUang.SelectedValue)

            For r = 1 To fg.Rows.Count - 2
                fg.Item(r, "SupplierID") = dt.Rows(0).Item("KodeSup").ToString
                fg.Item(r, "SupplierName") = dt.Rows(0).Item("NamaSup").ToString
                fg.Item(r, "RekeningName") = dt.Rows(0).Item("NamaRekening").ToString
                fg.Item(r, "RekeningNo") = dt.Rows(0).Item("NoRekening").ToString
                fg.Item(r, "RekeningBank") = dt.Rows(0).Item("JenisBank").ToString
                If dt.Rows(0).Item("IndPPHUMKM") = True Then
                    fg.Item(r, "BadanUsaha") = "UMKM"
                Else
                    If dt.Rows(0).Item("PTCV") = True Then
                        fg.Item(r, "BadanUsaha") = "PT/CV"
                    Else
                        fg.Item(r, "BadanUsaha") = "Pribadi"
                    End If
                End If
            Next

            Call AutoGenerateMasterSupplierProgramAcc()

            Call AkumulasiTotal()

            Call GetPotongan()
        End If
    End Sub

    Public Sub GetPotongan()
        If fg.Rows.Count > 1 Then
            ' Susut
            Dim dtSusut As DataTable = New DataTable()
            dtSusut = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select * from RMPApp..fnTrnPotonganRelasi('Susut','Tambang Kapal'," & cboPenerimaUang.SelectedValue & "," & fg.Item(1, "IDKapal") & ") order by Value asc")
            With cboNoTransSusut
                .DataSource = dtSusut
                .DisplayMember = "Member"
                .ValueMember = "Value"
                .SelectedIndex = -1
            End With

            ' Olah Gerak
            Dim dtOlahGerak As DataTable = New DataTable()
            dtOlahGerak = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select * from RMPApp..fnTrnPotonganRelasi('Olah Gerak','Tambang Kapal'," & cboPenerimaUang.SelectedValue & "," & fg.Item(1, "IDKapal") & ") order by Value asc")
            With cboNoTransOlahGerak
                .DataSource = dtOlahGerak
                .DisplayMember = "Member"
                .ValueMember = "Value"
                .SelectedIndex = -1
            End With

            ' BPJS
            Dim dtBPJS As DataTable = New DataTable()
            dtBPJS = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select * from RMPApp..fnTrnPotonganRelasi('BPJS','Tambang Kapal'," & cboPenerimaUang.SelectedValue & "," & fg.Item(1, "IDKapal") & ") order by Value asc")
            With cboNoTransBPJS
                .DataSource = dtBPJS
                .DisplayMember = "Member"
                .ValueMember = "Value"
                .SelectedIndex = -1
            End With

            ' GPS
            Dim dtGPS As DataTable = New DataTable()
            dtGPS = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select * from RMPApp..fnTrnPotonganRelasi('GPS','Tambang Kapal'," & cboPenerimaUang.SelectedValue & "," & fg.Item(1, "IDKapal") & ") order by Value asc")
            With cboNoTransGPS
                .DataSource = dtGPS
                .DisplayMember = "Member"
                .ValueMember = "Value"
                .SelectedIndex = -1
            End With
        End If
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
                    MsgBox("Potongan DP tidak boleh lebih besar dari Grand Total.", vbExclamation, AT)
                    fg.Item(fg.Row, "PotonganDP") = 0
                    Exit Sub
                ElseIf CInt(fg.Item(fg.Row, "PotonganDP")) > CInt(fg.Item(fg.Row, "SisaDP")) Then
                    MsgBox("Potongan DP tidak boleh lebih besar dari Sisa DP.", vbExclamation, AT)
                    fg.Item(fg.Row, "PotonganDP") = 0
                    Exit Sub
                End If
        End Select

        Call AkumulasiTotal()
    End Sub

    Private Sub cboNoTransSusut_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboNoTransSusut.SelectedIndexChanged, cboNoTransOlahGerak.SelectedIndexChanged, cboNoTransBPJS.SelectedIndexChanged, cboNoTransGPS.SelectedIndexChanged
        With fg
            ' masukan nilai potongan susut ke fg
            Try
                .Item(1, "PotSusut") = 0
                If IsNumeric(cboNoTransSusut.SelectedValue) Then
                    .Item(1, "PotSusut") = Format(CInt(cboNoTransSusut.Text), "N0")
                End If
            Catch ex As Exception
            End Try

            ' masukan nilai potongan olah gerak ke fg
            Try
                .Item(1, "PotOlahGerak") = 0
                If IsNumeric(cboNoTransOlahGerak.SelectedValue) Then
                    .Item(1, "PotOlahGerak") = Format(CInt(cboNoTransOlahGerak.Text), "N0")
                End If
            Catch ex As Exception
            End Try

            ' masukan nilai potongan BPJS ke fg
            Try
                .Item(1, "PotBPJS") = 0
                If IsNumeric(cboNoTransBPJS.SelectedValue) Then
                    .Item(1, "PotBPJS") = Format(CInt(cboNoTransBPJS.Text), "N0")
                End If
            Catch ex As Exception
            End Try

            ' masukan nilai potongan GPS ke fg
            Try
                .Item(1, "PotGPS") = 0
                If IsNumeric(cboNoTransGPS.SelectedValue) Then
                    .Item(1, "PotGPS") = Format(CInt(cboNoTransGPS.Text), "N0")
                End If
            Catch ex As Exception
            End Try

            Call AkumulasiTotal()
        End With
    End Sub

    Private Sub btnFindKapal_Click(sender As Object, e As EventArgs) Handles btnFindKapal.Click
        cboPenerimaUang.SelectedIndex = -1
        cboNoTransSusut.DataSource = Nothing
        cboNoTransSusut.Items.Clear()
        cboNoTransSusut.Text = ""
        cboNoTransGPS.DataSource = Nothing
        cboNoTransGPS.Items.Clear()
        cboNoTransGPS.Text = ""
        cboNoTransBPJS.DataSource = Nothing
        cboNoTransBPJS.Items.Clear()
        cboNoTransBPJS.Text = ""
        cboNoTransOlahGerak.DataSource = Nothing
        cboNoTransOlahGerak.Items.Clear()
        cboNoTransOlahGerak.Text = ""

        fg.Rows.Count = 1

        FrmTrnTambangKapalBPIFindKapal.ShowDialog() ' Ke LoadData
    End Sub

    Private Sub AkumulasiTotal()
        Dim totalPotonganInternal As Decimal = 0 ' tidak masuk ke accounting
        Dim totalPotonganExsternal As Decimal = 0 ' masuk ke accounting
        Dim grandTotal As Decimal = 0
        Dim Tnetto, Ttotal, Tsusut, TLain, TAkhir, TPPHUMKM, TPPH21, TPPH23, TGPS, TBPJS, TOlahGerak, TAsuransi, TGrand As Decimal

        For i = 1 To fg.Rows.Count - 2
            If CInt(fg.Item(i, "Tarif")) = 0 Then
                MsgBox("Tarif tidak boleh 0 (nol), Mohon input dahulu tarif di master tambang kapal." & i, vbExclamation, AT)
                Exit Sub
            End If
        Next

        For r As Integer = 1 To fg.Rows.Count - 2
            ' hitung total akhir
            totalPotonganInternal = CDec(fg.Item(r, "PotSusut")) + CDec(fg.Item(r, "PotLainLain"))

            fg.Item(r, "TotalAkhir") = Format(CDec(fg.Item(r, "TotalRp")) - totalPotonganInternal, "N0")

            ' hitung pajak
            If StatusOpenForm = "" Then
                If fg.Item(r, "BadanUsaha") = "Pribadi" Then
                    fg.Item(r, "DPP") = Format(Math.Ceiling(CDec(fg.Item(r, "TotalAkhir")) / 2), "N0")
                    Dim AkumulasiDPP As Decimal = DB.ExecuteScalarValue(Of Integer)(StrConnRMPApp, "select isnull((select cast(sum(DPP) as decimal(18,0)) as DPP from RMPApp..fnMonAkumulasiDPPRelasi('" & Format(dtpTanggalPengajuan.Value, "yyyy-MM-dd") & "','" & fg.Item(r, "SupplierID") & "')),0) as GetValueInteger")
                    For i = 1 To fg.Rows.Count - 2
                        AkumulasiDPP = AkumulasiDPP + CDec(fg.Item(i, "DPP"))
                        fg.Item(r, "AkumulasiDPP") = AkumulasiDPP
                    Next
                    If CDec(fg.Item(r, "AkumulasiDPP")) <= 60000000 Then
                        fg.Item(r, "TarifPajak") = "5%"
                        fg.Item(r, "PotPPH21") = Format(Math.Ceiling(CDec(fg.Item(r, "DPP")) * 0.05), "N0")
                    Else
                        fg.Item(r, "TarifPajak") = "15%"
                        fg.Item(r, "PotPPH21") = Format(Math.Ceiling(CDec(fg.Item(r, "DPP")) * 0.15), "N0")
                    End If
                ElseIf fg.Item(r, "BadanUsaha") = "PT/CV" Then
                    fg.Item(r, "DPP") = 0
                    fg.Item(r, "AkumulasiDPP") = 0
                    fg.Item(r, "TarifPajak") = "2%"
                    fg.Item(r, "PotPPH23") = Format(Math.Ceiling(CDec(fg.Item(r, "TotalAkhir")) * 0.02), "N0")
                ElseIf fg.Item(r, "BadanUsaha") = "UMKM" Then
                    fg.Item(r, "DPP") = 0
                    fg.Item(r, "AkumulasiDPP") = 0
                    fg.Item(r, "TarifPajak") = "0,5%"
                    fg.Item(r, "PotPPHUMKM") = Format(Math.Ceiling(CDec(fg.Item(r, "TotalAkhir")) * 0.005), "N0")
                Else
                    fg.Item(r, "DPP") = 0
                    fg.Item(r, "AkumulasiDPP") = 0
                    fg.Item(r, "TarifPajak") = "0%"
                    fg.Item(r, "PotPPH21") = 0
                    fg.Item(r, "PotPPH23") = 0
                    fg.Item(r, "PotPPHUMKM") = 0
                End If
            End If

            ' hitung grand total
            totalPotonganExsternal = CDec(fg.Item(r, "PotPPH21")) + CDec(fg.Item(r, "PotPPH23")) + CDec(fg.Item(r, "PotPPHUMKM")) + CDec(fg.Item(r, "PotGPS")) + CDec(fg.Item(r, "PotBPJS")) + CDec(fg.Item(r, "PotOlahGerak")) + CDec(fg.Item(r, "PotAsuransi")) + CDec(fg.Item(r, "PotonganDP"))

            grandTotal = CDec(fg.Item(r, "TotalAkhir")) - totalPotonganExsternal

            fg.Item(r, "GrandTotal") = Format(grandTotal, "N0")

            Tnetto = Tnetto + CDec(fg.Item(r, "Netto1Pabrik"))
            Ttotal = Ttotal + CDec(fg.Item(r, "TotalRp"))
            Tsusut = Tsusut + CDec(fg.Item(r, "PotSusut"))
            TLain = TLain + CDec(fg.Item(r, "PotLainLain"))
            TAkhir = TAkhir + CDec(fg.Item(r, "TotalAkhir"))
            TPPH21 = TPPH21 + CDec(fg.Item(r, "PotPPH21"))
            TPPH23 = TPPH23 + CDec(fg.Item(r, "PotPPH23"))
            TPPHUMKM = TPPHUMKM + CDec(fg.Item(r, "PotPPHUMKM"))
            TGPS = TGPS + CDec(fg.Item(r, "PotGPS"))
            TBPJS = TBPJS + CDec(fg.Item(r, "PotBPJS"))
            TOlahGerak = TOlahGerak + CDec(fg.Item(r, "PotOlahGerak"))
            TAsuransi = TAsuransi + CDec(fg.Item(r, "PotAsuransi"))
            TGrand = TGrand + CDec(fg.Item(r, "GrandTotal"))
        Next

        If fg.Rows.Count >= 3 Then
            fg.Item(fg.Rows.Count - 1, "Netto1Pabrik") = Format(Tnetto, "N0")
            fg.Item(fg.Rows.Count - 1, "TotalRp") = Format(Ttotal, "N0")
            fg.Item(fg.Rows.Count - 1, "PotSusut") = Format(Tsusut, "N0")
            fg.Item(fg.Rows.Count - 1, "PotLainLain") = Format(TLain, "N0")
            fg.Item(fg.Rows.Count - 1, "TotalAkhir") = Format(TAkhir, "N0")
            fg.Item(fg.Rows.Count - 1, "PotPPH21") = Format(TPPH21, "N0")
            fg.Item(fg.Rows.Count - 1, "PotPPH23") = Format(TPPH23, "N0")
            fg.Item(fg.Rows.Count - 1, "PotPPHUMKM") = Format(TPPHUMKM, "N0")
            fg.Item(fg.Rows.Count - 1, "PotGPS") = Format(TGPS, "N0")
            fg.Item(fg.Rows.Count - 1, "PotBPJS") = Format(TBPJS, "N0")
            fg.Item(fg.Rows.Count - 1, "PotOlahGerak") = Format(TOlahGerak, "N0")
            fg.Item(fg.Rows.Count - 1, "PotAsuransi") = Format(TAsuransi, "N0")
            fg.Item(fg.Rows.Count - 1, "GrandTotal") = Format(TGrand, "N0")
        End If

        fg.AutoSizeCols()
    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg.BeforeEdit
        Select Case StatusOpenForm
            Case ""
                If fg.Cols(e.Col).Name = "PotLainLain" Or fg.Cols(e.Col).Name = "KetPotLainLain" Then
                    e.Cancel = False
                Else
                    e.Cancel = True
                End If
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

    Private Sub FrmTrnApprovalPenerimaan_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        lblJudulForm.Left = (Me.Width - lblJudulForm.Width) / 2
    End Sub
End Class