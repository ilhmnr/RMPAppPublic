
Imports System.Data.SqlClient
Imports System.IO
Imports System.Data
Imports System.ComponentModel
Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Globalization

Public Class FrmTrnPoinLoyalty
    Public AT As String = "RMPApplication ©" & Format(Year(Now))
    Dim Conn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim Kode As String
    Dim str As String
    
    Public perintah As String
    Dim NoTransUpahBongkar_ As String
    Dim NoInvoice_ As String
    Private Sub FrmTrnPoinLoyalty_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtp1.Value = Format(Now, "dd/MM/yy")
        dtp2.Value = Format(Now, "dd/MM/yy")
        dtpInvoice.Value = Format(Now, "dd/MM/yy")
        'enableds(False)
        btnexit.Enabled = True
    End Sub



    Private Sub loaddata()

        Try
            Dim SQL As String, i As Integer
            Dim COUNTKAPAL As Integer
            COUNTKAPAL = 0


            SQL = " select * from tbl_RMTrnPenukaranPoinDtl where Verifikasi=0   and  CAST(tglcashback AS DATE) between  '" & Format(dtp1.Value, "yyyy-MM-dd") & "' and '" & Format(dtp2.Value, "yyyy-MM-dd") & "'  order by  CAST(tglcashback AS DATE),IDPetani asc"

            Using koneksi As New SqlCommand(SQL, DB.OpenConnection(StrConnRMPApp))
                Using DR = koneksi.ExecuteReader()
                    If DR.HasRows Then
                        dgvList.Rows.Clear()

                        While DR.Read
                            With dgvList
                                .Rows.Add()
                                COUNTKAPAL = COUNTKAPAL + 1
                                .Item("no", i).Value = i + 1
                                .Item("DetailID", i).Value = DR!DetailID
                                .Item("TglCashBack", i).Value = DR!tglcashback
                                .Item("IDPetani", i).Value = DR!IDPetani
                                .Item("Petani", i).Value = DR!NamaPetani
                                .Item("Pancang", i).Value = DR!Pancang
                                .Item("IDPenerimaUang", i).Value = DR!IDPenerimaUang
                                .Item("AlamatID", i).Value = DR!AlamatLengkap
                                .Item("NamaPenerimaUang", i).Value = DR!NamaRekening
                                .Item("NoRekening", i).Value = DR!NoRekening
                                .Item("Jenis_Bank", i).Value = DR!Jenis_Bank
                                .Item("Keterangan", i).Value = DR!Keterangan
                                .Item("JumlahPoinYangDiKlaim", i).Value = DR!TotalPoinCashBack
                                .Item("CashBackYangDiterima", i).Value = DR!RPTotalPoinCashBack
                                .Item("Verifikasi", i).Value = DR!Verifikasi

                                With Me.dgvList
                                    .RowsDefaultCellStyle.BackColor = Color.White
                                    .AlternatingRowsDefaultCellStyle.BackColor = Color.Azure
                                    .Rows(i).Cells("No").Style.BackColor = Color.FromArgb(240, 240, 240)
                                End With
                            End With
                            i += 1
                        End While



                        dgvList.Rows.Add()
                        Call sumpoin()
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



    Public Sub loaddata(noinvoice As String)

        Try
            Dim SQL As String, i As Integer
            Dim COUNTKAPAL As Integer
            COUNTKAPAL = 0


            SQL = " select * from vw_RM_trnpenukaranpointverifikasi where Verifikasi=1  and Manual_=0 and NoInvoice='" & noinvoice & "' "

            Using koneksi As New SqlCommand(SQL, DB.OpenConnection(StrConnRMPApp))
                Using DR = koneksi.ExecuteReader()
                    If DR.HasRows Then
                        dgvList.Rows.Clear()

                        While DR.Read
                            With dgvList
                                .Rows.Add()
                                COUNTKAPAL = COUNTKAPAL + 1
                                .Item("no", i).Value = i + 1
                                .Item("DetailID", i).Value = DR!DetailID
                                .Item("TglCashBack", i).Value = DR!tglcashback
                                .Item("IDPetani", i).Value = DR!IDPetani
                                .Item("Petani", i).Value = DR!NamaPetani
                                .Item("Pancang", i).Value = DR!Pancang
                                .Item("IDPenerimaUang", i).Value = DR!IDPenerimaUang
                                .Item("AlamatID", i).Value = DR!AlamatLengkap
                                .Item("NamaPenerimaUang", i).Value = DR!NamaRekening
                                .Item("NoRekening", i).Value = DR!NoRekening
                                .Item("Jenis_Bank", i).Value = DR!Jenis_Bank
                                .Item("Keterangan", i).Value = DR!Keterangan
                                .Item("JumlahPoinYangDiKlaim", i).Value = DR!TotalPoinCashBack
                                .Item("CashBackYangDiterima", i).Value = DR!RPTotalPoinCashBack
                                .Item("Verifikasi", i).Value = DR!Verifikasi

                                With Me.dgvList
                                    .RowsDefaultCellStyle.BackColor = Color.White
                                    .AlternatingRowsDefaultCellStyle.BackColor = Color.Azure
                                    .Rows(i).Cells("No").Style.BackColor = Color.FromArgb(240, 240, 240)
                                End With
                            End With
                            i += 1
                        End While



                        dgvList.Rows.Add()
                        Call sumpoin()
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



    Public Sub sumpoin()
        'Select Case fx.CurrentCell.ColumnIndex
        '    Case 22, 10
        Try
            Dim JumlahPoinYangDiKlaim As Double = 0
            Dim CashBackYangDiterima As Double = 0
            Dim max As Double = 0
            Dim TotalpremiKapal As Double = 0

            For i = 0 To dgvList.RowCount - 2
                JumlahPoinYangDiKlaim += (If(Val(dgvList.Rows(i).Cells("JumlahPoinYangDiKlaim").Value()) = 0, 0, Convert.ToDouble(dgvList.Rows(i).Cells("JumlahPoinYangDiKlaim").Value())))
                CashBackYangDiterima += (If(Val(dgvList.Rows(i).Cells("CashBackYangDiterima").Value()) = 0, 0, Convert.ToDouble(dgvList.Rows(i).Cells("CashBackYangDiterima").Value())))

            Next

            dgvList.Rows(dgvList.RowCount - 1).Cells(0).Value = "Total"
            dgvList.Rows(dgvList.RowCount - 1).Cells("JumlahPoinYangDiKlaim").Value() = JumlahPoinYangDiKlaim

            dgvList.Rows(dgvList.RowCount - 1).Cells("CashBackYangDiterima").Value() = CashBackYangDiterima

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



    'Public Sub loaddataFind(noinvoice As String)

    '    Try

    '        Dim SQL As String, i As Integer
    '        Dim sql2 As String = ""
    '        SQL = " select * from vw_RM_TrnAngkutanBuahKapalDtl WHERE NOINVOICE = '" & noinvoice & "' "

    '        Using koneksi As New SqlCommand(SQL, DB.OpenConnection(StrConnRMPApp))
    '            Using DR = koneksi.ExecuteReader()
    '                If DR.HasRows Then
    '                    dgvList.Rows.Clear()
    '                    'dgvList.RowCount = 0
    '                    While DR.Read

    '                        With dgvList
    '                            .Rows.Add()
    '                            txtinvoice.Text = DR!noinvoice
    '                            dtp1.Value = DR!periodetgl
    '                            dtp2.Value = DR!periodetgl2
    '                            dtpInvoice.Value = DR!tglinvoice
    '                            .Item("no", i).Value = i + 1
    '                            .Item("IDKapal", i).Value = DR!IDKapal
    '                            .Item("Rate", i).Value = DR!Rate
    '                            .Item("Trip", i).Value = DR!Trip
    '                            .Item("IDPancang", i).Value = DR!IDPancang
    '                            .Item("NamaKapal", i).Value = DR!NamaKapal
    '                            .Item("Muatan", i).Value = DR!muatan
    '                            .Item("totalharga", i).Value = DR!totalharga
    '                            .Item("Rp", i).Value = DR!Rp
    '                            .Item("jamberangkat", i).Value = DR!jamberangkat
    '                            .Item("TglBerangkat", i).Value = DR!TglBerangkat
    '                            .Item("Pancang", i).Value = DR!Pancang
    '                            .Item("Tujuan", i).Value = DR!Tujuan
    '                            .Item("LuasJaminan", i).Value = DR!LuasJaminan
    '                            .Item("RATEPLUS", i).Value = DR!RATEPLUS
    '                            .Item("RATEMIN", i).Value = DR!RATEMIN
    '                            .Item("Premi", i).Value = DR!Premi
    '                            .Item("PremiKapal", i).Value = DR!PremiKapal

    '                        End With
    '                        i += 1
    '                    End While
    '                    dgvList.Rows.Add()
    '                    Call sumpremi()
    '                Else
    '                    'dgvList.Rows.Clear()
    '                    MsgBox("Data Tidak ditemukan ! ", MsgBoxStyle.Information)
    '                    Exit Sub
    '                End If

    '                DR.Close()
    '            End Using

    '        End Using
    '        DB.CloseConnection()

    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical)
    '    End Try
    'End Sub

    Private Function SavePointLoyaltyHdr(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        Dim MyCMD As New SqlCommand
        Try
            With MyCMD
                SavePointLoyaltyHdr = False
                Dim MyCon As SqlConnection = Conn
                Dim MyConTrans As SqlTransaction = Trans
                .Connection = MyCon
                .CommandType = CommandType.StoredProcedure
                .CommandText = "RMPApp..sp_RMTrnPenukaranPoinHdr"
                .Transaction = MyConTrans
                .Parameters.Add("@RETURN_VALUE", SqlDbType.SmallInt).Direction = ParameterDirection.ReturnValue
                .Parameters.Add("@Perintah", SqlDbType.VarChar, 10).Value = perintah
                .Parameters.Add(New SqlParameter("@NoInvoice", SqlDbType.VarChar, 20, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
                .Parameters.Add("@NoInvoice2", SqlDbType.VarChar, 30).Value = txtinvoice.Text
                .Parameters.Add("@tglinvoice", SqlDbType.DateTime).Value = dtpInvoice.Value
                .Parameters.Add("@tglcashback1", SqlDbType.DateTime).Value = dtp1.Value
                .Parameters.Add("@tglcashback2", SqlDbType.DateTime).Value = dtp2.Value
                .Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
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




    Private Function SavePointLoyaltyDtl(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal I As Integer) As Boolean
        Dim MyCMD As New SqlCommand
        With MyCMD

            SavePointLoyaltyDtl = False
            Dim MyCon As SqlConnection = Conn
            Dim MyConTrans As SqlTransaction = Trans
            .Connection = MyCon
            .Connection = MyCon
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RMPApp..sp_RMTrnPenukaranPoinDtl"
            .Transaction = MyConTrans
            .Parameters.Add("@RETURN_VALUE", SqlDbType.SmallInt).Direction = ParameterDirection.ReturnValue
            .Parameters.Add("@DetailID", SqlDbType.VarChar, 30).Value = dgvList.Item("DetailID", I).Value
            .Parameters.Add("@Tglcashback", SqlDbType.DateTime).Value = Format(CDate(dgvList.Item("Tglcashback", I).Value), "yyyy-MM-dd")
            .Parameters.Add("@IDPetani", SqlDbType.VarChar, 30).Value = dgvList.Item("IDPetani", I).Value
            .Parameters.Add("@NoInvoice", SqlDbType.VarChar, 30).Value = NoInvoice_
            .Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
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
        btnsave.Enabled = Not flag
        btnexit.Enabled = flag
    End Sub
    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim Koneksi As SqlConnection = DB.OpenConnection(StrConnRMPApp)
        Dim Transaksi As SqlTransaction
        Transaksi = Koneksi.BeginTransaction
        Me.Cursor = Cursors.WaitCursor
        Try

            'If txtinvoice.Text = "" Then
            '    MessageBox.Show("Isi Invoice", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Me.Cursor = Cursors.Default
            '    Exit Sub
            'End If


            Dim i As Integer
            If SavePointLoyaltyHdr(Koneksi, Transaksi) = False Then
                Transaksi.Rollback()
                Transaksi = Nothing
                Me.Cursor = Cursors.Default
                MessageBox.Show("Simpan Data Hdr Gagal !", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Try
            End If

            For i = 0 To dgvList.RowCount - 2
                If dgvList.Item("Verifikasi", i).Value = True And dgvList.Item("CashBackYangDiterima", i).Value > 0 And dgvList.Item("IDPetani", i).Value <> "" Then
                    If SavePointLoyaltyDtl(Koneksi, Transaksi, i) = False Then
                        Transaksi.Rollback()
                        Transaksi = Nothing
                        Me.Cursor = Cursors.Default
                        MessageBox.Show("Simpan Data Dtl Gagal!", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Try
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


    Public Sub enableds(flag As Boolean)
        txtinvoice.Enabled = flag
        dtpInvoice.Enabled = flag
        dtp1.Enabled = flag
        dtp2.Enabled = flag
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
End Class