Imports System.CodeDom
Imports System.Data.SqlClient
Imports C1.Util.DX.Storage
Imports C1.Win.C1FlexGrid
Imports Dapper

Public Class FrmMstPersonilPancangNew
    Dim cls As New ClsDatabaseConnection
    Dim Status_ As Integer, StatusID_ As Integer
    Public Bagian_, StatusJbt, Perintah As String
    Public Ind As Boolean
    Dim nameBerkas, nameshow, destPath, PathPng As String
    Public pathFile As String = UrlMasterTTPancnag & "PersonilPancang\"
    Dim openfoto As Byte
    Dim IDBank As Integer

    Private Sub FrmMstPersonilPancangNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Perintah = Perintah

        DTP1.Value = Format(Now, "yyyy-MM-dd")
        DTP2.Value = Format(Now, "yyyy-MM-dd")
        dttgl.Value = Format(Now, "yyyy-MM-dd")
        GroupBox2.Enabled = True

        Modul_RMP.Combo.SetPancang(cboPancang)
        Modul_RMP.Combo.SetIM(cboIM)
        Modul_RMP.Combo.SetJabatan(cboJabatan)
    End Sub

    Public Sub clear()
        txtNama.Text = ""
        txtReg.Text = ""
        txtNIK.Text = ""
        cboPancang.Text = ""
        cboJabatan.Text = ""
        chkHarian.Checked = False
        chkKaryawan.Checked = False
        txtID.Text = ""
        txtNama.Text = ""
        txtNIK.Text = ""
        cboPancang.Text = ""
        cboIM.Text = ""
        cboJabatan.Text = ""
        txtMasuk.Text = ""
        txtPulang.Text = ""
        txtUangMakan.Text = ""
    End Sub

    Public Sub cmdEnabled(flag As Boolean)
        btnsave.Enabled = Not flag
        btnexit.Enabled = flag
    End Sub

    Private Sub txtNama_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNama.KeyDown
        If e.KeyCode = Keys.Tab Then
            txtNIK.Focus()
        End If
    End Sub
    Private Sub txtNIK_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNIK.KeyDown
        If e.KeyCode = Keys.Tab Then
            cboPancang.Focus()
        End If
    End Sub

    Private Sub cboJabatan_KeyDown(sender As Object, e As KeyEventArgs) Handles cboJabatan.KeyDown
        If e.KeyCode = Keys.Tab Then
            cboJabatan.Focus()
        End If
    End Sub

    Private Sub cboIM_KeyDown(sender As Object, e As KeyEventArgs) Handles cboIM.KeyDown
        If e.KeyCode = Keys.Tab Then
            txtMasuk.Focus()
        End If
    End Sub

    Private Sub txtPulang_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPulang.KeyDown
        If e.KeyCode = Keys.Tab Then
            txtUangMakan.Focus()
        End If
    End Sub

    Private Function CekIDPancang() As String
        Try
            CekIDPancang = ""
            Dim connb As New SqlConnection(StrConnRMPApp)
            connb.Open()

            Dim sql As String
            sql = "Select Top (1) * From  RMPApp..Android_tblMstPancang  where IDPancang = '" & cboPancang.SelectedValue & "' "
            Dim cmd2 As New SqlClient.SqlCommand(sql, connb)
            Dim reader As SqlClient.SqlDataReader
            reader = cmd2.ExecuteReader
            If reader.HasRows Then
                If reader.Read() Then
                    CekIDPancang = "0"
                Else
                    CekIDPancang = "1"
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Default
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

    Private Sub txtMasuk_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMasuk.KeyDown
        If e.KeyCode = Keys.Tab Then
            txtPulang.Focus()
        End If
    End Sub

    Public Class Data
        Public Property Bagian As String
        Public Property IDPersonil As String
        Public Property Nama As String
        Public Property RegFixNo As Integer
        Public Property NIK As String
        Public Property IDPancang As Integer
        Public Property Jabatan As String
        Public Property Status As String
        Public Property IM As String
        Public Property JamMasuk As String
        Public Property JamPulang As String
        Public Property CreatedBy As String
        Public Property NotActive As Boolean
        Public Property NotActiveID As Boolean
        Public Property UangMakan As Integer
        Public Property CV As String
        Public Property Pemborong As String
        Public Property Trainee As Int32
        Public Property TDate1 As DateTime
        Public Property TDate2 As DateTime
        Public Property NoRek As String
        Public Property NamaRek As String
        Public Property IDBank_ As Integer
        Public Property Tanggal As DateTime
        Public Property Flag As Integer
    End Class

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click

        If cboPancang.SelectedValue.ToString = "" Then
            MessageBox.Show("Pilih Pancang !", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If CekIDPancang() = "1" Then
            MessageBox.Show("Pilih Pancang !", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If txtID.Text = "" And Perintah = "Edit" Then
            MessageBox.Show("IDPersonil Kosong !", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If rdP2.Checked = True And txtReg.Text = "" Then
            MessageBox.Show("Untuk Personil P2 RegFixNo Tidak Boleh Kosong !", "Gagal!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If cboIM.Text = "" Then
            MessageBox.Show("Pilih LIBUR MINGGUAN !", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If


        'btnUpload_Click(sender, New System.EventArgs)

        If chkNotActive.Checked = True Then
            Status_ = 1
        Else
            Status_ = 0
        End If


        If chkNotActiveID.Checked = True Then
            StatusID_ = 1
        Else
            StatusID_ = 0
        End If



        If rdP1.Checked = True Then
            Bagian_ = "P1"
        ElseIf rdP2.Checked = True Then
            Bagian_ = "P2"
        ElseIf rdP3.Checked = True Then
            Bagian_ = "P3"
        ElseIf rdpsp.Checked = True Then
            Bagian_ = "PSP"
        End If

        If chkKaryawan.Checked = True Then
            StatusJbt = "Karyawan"
        ElseIf chkHarian.Checked = True Then
            StatusJbt = "Harian"
        End If

        If ChkMandiri.Checked = True Then
            IDBank = 2
        ElseIf ChkBni.Checked = True Then
            IDBank = 1
        End If

        'Dim date1, date2 As DateTime
        'If chktrainee.Checked Then
        '    date1 = DTP1.Value
        '    date2 = DTP2.Value
        'Else
        '    date1 = Nothing
        '    date2 =Nothing
        'End If

        Try
            Dim obj As New Data With {
                .Bagian = Bagian_,
                .IDPersonil = txtID.Text,
                .Nama = txtNama.Text,
                .RegFixNo = txtReg.Text,
                .NIK = txtNIK.Text,
                .IDPancang = cboPancang.SelectedValue,
                .Jabatan = cboJabatan.Text,
                .Status = StatusJbt,
                .IM = cboIM.Text,
                .JamMasuk = txtMasuk.Text,
                .JamPulang = txtPulang.Text,
                .CreatedBy = ClsSession.UserID,
                .NotActive = Status_,
                .NotActiveID = StatusID_,
                .UangMakan = txtUangMakan.Text,
                .CV = txtCV.Text,
                .Pemborong = txtPemborong.Text,
                .Trainee = chktrainee.Checked,
                .TDate1 = DTP1.Value,
                .TDate2 = DTP2.Value,
                .NoRek = txtRek.Text,
                .NamaRek = TxtNamaRek.Text,
                .IDBank_ = IDBank,
                .Tanggal = dttgl.Value,
                .Flag = 0}

            Dim result = (SaveData(obj))

            If Perintah = "Edit" Then
                MessageBox.Show("Save Completed !", "Save Data - " & AT, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If result > 0 Then
                    MessageBox.Show("Save Completed !", "Save Data - " & AT, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MsgBox("Simpan Data Gagal", vbExclamation, "Save Data - " & AT)
                End If
            End If

            Call clear()
        Catch ex As Exception
            MsgBox("Error !" + ex.Message, MsgBoxStyle.Exclamation)
            Exit Sub
        End Try

        FrmMstPersonilPancangNewList.ShowData()
        Me.Dispose()
        btnsave.Enabled = False
        GroupBox2.Enabled = False
    End Sub

    Public Function SaveData(ByVal Obj As Data) As Integer
        Dim result As Integer
        Using cn As SqlConnection = New SqlConnection(StrConnRMPApp)
            If cn.State = ConnectionState.Closed Then cn.Open()
            Dim dParamsObject = New DynamicParameters(Obj)
            dParamsObject.Add("@Flag", 0, direction:=ParameterDirection.InputOutput)
            Using Trx As SqlTransaction = cn.BeginTransaction
                Try
                    'cn.Execute("spSavePersonilPCG", dParamsObject, Trx, commandType:=CommandType.StoredProcedure)
                    cn.Execute("spSavePersonilPCGNew2023", dParamsObject, Trx, commandType:=CommandType.StoredProcedure)
                    result = dParamsObject.Get(Of Integer)("@Flag")
                    Trx.Commit()
                Catch ex As Exception
                    Trx.Rollback()
                    MessageBox.Show(ex.Message)
                End Try
            End Using
        End Using
        Return result
    End Function

    Private Sub txtUangMakan_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUangMakan.KeyDown
        If e.KeyCode = Keys.Tab Then
            DTP1.Focus()
        End If
    End Sub

    Private Sub btnexit_Click(sender As Object, e As EventArgs) Handles btnexit.Click
        Me.Dispose()
    End Sub

    Private Sub ChkMandiri_CheckedChanged(sender As Object, e As EventArgs) Handles ChkMandiri.CheckedChanged
        If ChkMandiri.Checked = True Then
            ChkMandiri.Checked = True
            ChkBni.Checked = False
        Else
            ChkMandiri.Checked = False
            ChkBni.Checked = True
        End If
    End Sub

    Private Sub ChkBni_CheckedChanged(sender As Object, e As EventArgs) Handles ChkBni.CheckedChanged
        If ChkBni.Checked = True Then
            ChkBni.Checked = True
            ChkMandiri.Checked = False
        Else
            ChkBni.Checked = False
            ChkMandiri.Checked = True
        End If
    End Sub

    Private Sub chkNotActive_CheckedChanged(sender As Object, e As EventArgs) Handles chkNotActive.CheckedChanged

    End Sub

    Private Sub DTP1_KeyDown(sender As Object, e As KeyEventArgs) Handles DTP1.KeyDown
        If e.KeyCode = Keys.Tab Then
            DTP2.Focus()
        End If
    End Sub

    Private Sub DTP2_KeyDown(sender As Object, e As KeyEventArgs) Handles DTP2.KeyDown
        If e.KeyCode = Keys.Tab Then
            txtPemborong.Focus()
        End If
    End Sub

    Private Sub txtPemborong_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPemborong.KeyDown
        If e.KeyCode = Keys.Tab Then
            txtCV.Focus()
        End If
    End Sub

    Private Sub txtCV_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCV.KeyDown
        If e.KeyCode = Keys.Tab Then
            txtRek.Focus()
        End If
    End Sub

    Public Sub loaddataFind(id As Long)
        Try
            Dim SQL As String
            Dim COUNTKAPAL As Integer
            COUNTKAPAL = 0
            SQL = "SELECT * From RMPAPP..vwPersonilPCG2024  WHERE id ='" & id & "'  "

            Using koneksi As New SqlCommand(SQL, DB.OpenConnection(StrConnRMPApp))
                Using DR = koneksi.ExecuteReader()
                    If DR.HasRows Then
                        While DR.Read

                            txtID.Text = DR!IDPersonil
                            txtNama.Text = DR!Nama
                            txtReg.Text = DR!RegFixNo
                            txtNIK.Text = DR!nik

                            cboJabatan.Text = DR!Jabatan.ToString

                            If DR!Bagian = "P1" Then
                                rdP1.Checked = True
                            Else
                                rdP1.Checked = False
                            End If

                            If DR!Bagian = "P2" Then
                                rdP2.Checked = True
                            Else
                                rdP2.Checked = False
                            End If


                            If DR!Bagian = "P3" Then
                                RDP3.Checked = True
                            Else
                                RDP3.Checked = False
                            End If


                            If DR!Bagian = "PSP" Then
                                rdpsp.Checked = True
                            Else
                                rdpsp.Checked = False
                            End If


                            cboPancang.Text = DR!IDPancang.ToString + ". " + DR!Pancang

                            If DR!Status = "Harian" Then
                                chkHarian.Checked = True
                            Else
                                chkHarian.Checked = False
                            End If

                            If DR!Status = "Karyawan" Then
                                chkKaryawan.Checked = True
                            Else
                                chkKaryawan.Checked = False
                            End If

                            cboIM.Text = DR!IM.ToString

                            If IsDBNull(DR!TDate1) = False Then
                                DTP1.Value = DR!TDate1
                                DTP2.Value = DR!TDate2
                            End If

                            txtMasuk.Text = DR!JamMasuk
                            txtPulang.Text = DR!JamPulang
                            chkNotActive.Checked = DR!NotActive
                            txtUangMakan.Text = DR!UangMakan
                            txtCV.Text = DR!cv

                            If IsDBNull(DR!Pemborong) = False Then
                                txtPemborong.Text = DR!Pemborong
                            End If

                            If IsDBNull(DR!NoRekening) = False Then
                                txtRek.Text = DR!NoRekening
                            End If

                            If IsDBNull(DR!TDate1) = False Then
                                dttgl.Value = DR!Tanggal
                            End If

                            If IsDBNull(DR!IDBank) = False Then
                                If DR!IDBank = 1 Then
                                    ChkBni.Checked = True
                                Else
                                    ChkMandiri.Checked = True
                                End If
                            Else
                                ChkMandiri.Checked = False
                                ChkBni.Checked = False
                            End If

                            If IsDBNull(DR!NamaRek) = False Then
                                TxtNamaRek.Text = DR!NamaRek
                            End If
                        End While
                    Else
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
End Class