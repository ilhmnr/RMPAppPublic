Imports System.ComponentModel
Imports System.Data.SqlClient
Imports C1.C1Preview.C1HyperlinkInfo
Imports System.Web.Services.Description
Imports C1.Win.C1FlexGrid
Imports Dapper
Imports PdfSharp.Pdf
Imports RMPApp.FrmTrnUpahBongkarMuatPontianak

Public Class FrmMstFee
    Dim cls As New ClsDatabaseConnection
    Dim Status_ As Integer
    Dim Perintah As String

    Private Sub FrmMstFee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Perintah = ""

        Call HeaderFG()
        Call Search()
        Call Enableinput(False)
        Call ClearData()

        btnFind.Enabled = True
        btnAdd.Enabled = True
        btnSave.Enabled = False
        btnEdit.Enabled = False
        btnCancel.Enabled = False

        ' set combo box
        Modul_RMP.Combo.SetBahanBaku(cbobahanbaku)
        'cbobahanbaku.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        'cbobahanbaku.AutoCompleteSource = AutoCompleteSource.ListItems

        SetSupplier()
        cboNamaPemilikLahan.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboNamaPemilikLahan.AutoCompleteSource = AutoCompleteSource.ListItems
        cboNamaToke.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboNamaToke.AutoCompleteSource = AutoCompleteSource.ListItems

        Modul_RMP.Combo.SetPancang(cboPancang)
        cboPancang.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboPancang.AutoCompleteSource = AutoCompleteSource.ListItems
    End Sub
    Public Sub SetSupplier()

        Dim dt As New DataTable

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select distinct a.KodeSup,a.KodeSup+'-'+a.NamaSup as NamaSup
                                                            from RSUPAccounting..tblRMMstSupplier as a right join
                                                            RSUPAccounting..TblRMMstRekRM as b on a.KodeSup=b.IDPetani 
                                                            where a.KodeSup like '%PCG%'")

        ' 🔥 Combo 1
        With cboNamaPemilikLahan
            .DataSource = dt.Copy()
            .DisplayMember = "NamaSup"
            .ValueMember = "KodeSup"
            .SelectedIndex = -1
        End With

        ' 🔥 Combo 2
        With cboNamaToke
            .DataSource = dt.Copy()
            .DisplayMember = "NamaSup"
            .ValueMember = "KodeSup"
            .SelectedIndex = -1
        End With

    End Sub

    Public Sub HeaderFG()
        ' Pastikan objek fg sudah tersedia
        If fg Is Nothing Then Exit Sub

        With fg
            ' === Pengaturan dasar grid ===
            .AllowEditing = False
            .Font = New Font("Century Gothic", 9.0!, FontStyle.Regular)
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True

            ' === Warna header dan baris selang-seling ===
            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)   ' Warna latar header utama
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224) ' Warna latar baris bergantian
            .Styles.Fixed.TextAlign = TextAlignEnum.LeftCenter          ' Rata kiri untuk header

            ' === Pastikan ada minimal 2 baris header ===
            .Rows.Count = 1

            ' === Warna khusus untuk baris header ke-0 dan ke-1 ===
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

            ' === Aktifkan fitur merging untuk header ===
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True

            ' === Sesuaikan ukuran kolom secara otomatis ===
            .AutoSizeCols()
        End With
    End Sub

    Private Sub cboPancang_KeyUp(sender As Object, e As KeyEventArgs) Handles cboPancang.KeyUp
        UI.AutoCompleteCombo_KeyUp(cboPancang, e)
    End Sub

    Private Sub Search()
        With scp
            .SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
            .SearchDelay = 2
            .Watermark = "Cari Disini"
            .SetC1FlexGridSearchPanel(fg, scp)
        End With
    End Sub

    Private Sub ShowData()
        Dim i As Integer = 1
        Dim sql As String = ""
        Dim dt As DataTable = New DataTable()

        Try
            If ChkGetAllData.Checked = True Then
                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT * from vwMstFee_040326 ORDER BY Pancang,NamaPemilikLahan,NotActive asc")
            Else
                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT * from vwMstFee_040326 where NotActive=0 ORDER BY Pancang,NamaPemilikLahan,NotActive asc")
            End If

            If dt.Rows.Count > 0 Then
                fg.Rows.Count = 1

                With fg
                    Call ui.HapusGrid(1, fg)
                    For Each row As DataRow In dt.Rows
                        .AddItem(i)
                        .Item(i, "ID") = row.Item("ID")
                        .Item(i, "IDPancang") = row.Item("IDPancang")
                        .Item(i, "Pancang") = row.Item("Pancang")
                        .Item(i, "Periode") = row.Item("Periode")
                        .Item(i, "IDJenisBahanBaku") = row.Item("KodeBahanBaku")
                        .Item(i, "JenisBahanBaku") = row.Item("NamaBahanBaku")
                        .Item(i, "IDPemilikLahan") = row.Item("IDPemilikLahan")
                        .Item(i, "NamaPemilikLahan") = row.Item("NamaPemilikLahan")
                        .Item(i, "NoTelponPemilikLahan") = row.Item("NoTelp")
                        .Item(i, "FeePemilikLahan") = row.Item("Fee")
                        .Item(i, "IDToke") = row.Item("IDToke")
                        .Item(i, "NamaToke") = row.Item("NamaToke")
                        .Item(i, "NoTelponToke") = row.Item("NoTelpToke")
                        .Item(i, "FeeToke") = row.Item("FeeToke")
                        .Item(i, "NotActive") = row.Item("NotActive")
                        .Item(i, "CreatedBy") = row.Item("CreatedBy")
                        .Item(i, "CreatedDate") = row.Item("CreatedDate")
                        .Item(i, "UpdatedBy") = row.Item("UpdatedBy")
                        .Item(i, "UpdatedDate") = row.Item("UpdatedDate")

                        Try
                            If row.Item("NotActive") = True Then
                                Dim style As New CellRange
                                style = fg.GetCellRange(i, 1, i, 14)
                                style.StyleNew.ForeColor = Color.Red
                            End If
                        Catch ex As Exception
                        End Try

                        i = i + 1
                    Next
                    .AutoSizeCols()
                End With
            Else
                MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
            End If
        Catch EX As Exception
            MsgBox(EX.Message)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim koneksi As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnRMPApp)
        Dim trans As SqlTransaction = koneksi.BeginTransaction()

        Try
            If Not saveMstFee(koneksi, trans) Then
                trans.Rollback()
                Return
            End If

            trans.Commit()

            MessageBox.Show("Save Completed!", "Edit Data - " & AT,
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearData()
            Enableinput(False)
            ShowData()

        Catch ex As Exception
            trans.Rollback()
            MessageBox.Show("Error: " & ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        btnFind.Enabled = True
        btnAdd.Enabled = True
        btnSave.Enabled = False
        btnEdit.Enabled = False
        btnCancel.Enabled = False

        If fg.Rows.Count > 1 Then
            btnEdit.Enabled = True
        End If
    End Sub

    Private Function saveMstFee(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        Try
            Dim cmd As New SqlCommand
            With cmd
                .Connection = Conn
                .Transaction = Trans
                .CommandType = CommandType.StoredProcedure
                .CommandText = "spSaveMstFeePCG_040326"

                .Parameters.Add("@ID", SqlDbType.Int).Value = CInt(TxtID.Text)
                .Parameters.Add("@Tanggal", SqlDbType.DateTime).Value = dttgl.Value
                .Parameters.Add("@IDPancang", SqlDbType.Int).Value = CInt(cboPancang.SelectedValue)
                .Parameters.Add("@KodeBahanBaku", SqlDbType.Int).Value = CInt(cbobahanbaku.SelectedValue)
                .Parameters.Add("@NotActive", SqlDbType.Int).Value = If(ChkNotActive.Checked, 1, 0)
                .Parameters.Add("@IDPemilikLahan", SqlDbType.VarChar, 30).Value = CStr(cboNamaPemilikLahan.SelectedValue)
                .Parameters.Add("@NamaPemilik", SqlDbType.VarChar, 50).Value = CStr(cboNamaPemilikLahan.Text)
                .Parameters.Add("@NoTelp", SqlDbType.VarChar, 20).Value = CStr(txtNoTlpPemilikLahan.Text)
                .Parameters.Add("@Fee", SqlDbType.Decimal).Value = CDec(txtFeePemilikLahan.Text)
                .Parameters.Add("@IDToke", SqlDbType.VarChar, 30).Value = If(cboNamaToke.Text = "", "", CStr(cboNamaToke.SelectedValue))
                .Parameters.Add("@NamaToke", SqlDbType.VarChar, 50).Value = CStr(cboNamaToke.Text)
                .Parameters.Add("@NoTelpToke", SqlDbType.VarChar, 20).Value = CStr(txtNoTlpToke.Text)
                .Parameters.Add("@FeeToke", SqlDbType.Decimal).Value = CDec(If(txtFeeToke.Text = "", "0", txtFeeToke.Text))
                .Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = CStr(ClsSession.UserID)

                Dim pFlag As New SqlParameter("@Flag", SqlDbType.Int) With {
                .Direction = ParameterDirection.Output
            }
                .Parameters.Add(pFlag)

                Dim pErrMsg As New SqlParameter("@ErrorMessage", SqlDbType.NVarChar, 500) With {
                .Direction = ParameterDirection.Output
            }
                .Parameters.Add(pErrMsg)

                .ExecuteNonQuery()

                If CInt(pFlag.Value) <> 1 Then
                    Dim errMsg As String = If(pErrMsg.Value Is DBNull.Value, "Gagal menyimpan data.", pErrMsg.Value.ToString())
                    MessageBox.Show(errMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If
            End With

            Return True

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Sub Enableinput(FLag As Boolean)
        dttgl.Enabled = FLag
        cboPancang.Enabled = FLag
        ChkNotActive.Enabled = FLag
        cbobahanbaku.Enabled = FLag

        cboNamaPemilikLahan.Enabled = FLag
        txtNoTlpPemilikLahan.Enabled = FLag
        txtFeePemilikLahan.Enabled = FLag

        cboNamaToke.Enabled = FLag
        txtNoTlpToke.Enabled = FLag
        txtFeeToke.Enabled = FLag
    End Sub

    Private Sub ClearData()
        fg.Enabled = True

        TxtID.Clear()
        dttgl.Value = Now
        cboPancang.SelectedValue = -1
        cbobahanbaku.SelectedValue = -1
        ChkNotActive.Checked = False

        cboNamaPemilikLahan.SelectedValue = -1
        txtNoTlpPemilikLahan.Clear()
        txtNoRekPemilikLahan.Clear()
        txtNamaRekPemilikLahan.Clear()
        txtBankPemilikLahan.Text = ""
        txtFeePemilikLahan.Clear()

        cboNamaToke.SelectedValue = -1
        txtNoTlpToke.Clear()
        txtNoRekToke.Clear()
        txtNamaRekToke.Clear()
        txtBankToke.Text = ""
        txtFeeToke.Clear()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        Enableinput(False)

        ClearData()

        btnFind.Enabled = True
        btnAdd.Enabled = True
        btnSave.Enabled = False
        btnEdit.Enabled = False
        btnCancel.Enabled = False

        If fg.Rows.Count > 1 Then
            btnEdit.Enabled = True
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If cboPancang.Text <> "" Then
            Perintah = "Edit"
            Enableinput(True)

            btnFind.Enabled = False
            btnAdd.Enabled = False
            btnSave.Enabled = True
            btnEdit.Enabled = False
            btnCancel.Enabled = True

            fg.Enabled = False
        Else
            MsgBox("Pilih Dulu Data Nya.", vbInformation, AT)
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ClearData()
        btnFind.Enabled = False
        btnAdd.Enabled = False
        btnSave.Enabled = True
        btnEdit.Enabled = False
        btnCancel.Enabled = True
        Enableinput(True)
        ChkNotActive.Enabled = False
        fg.Enabled = False

        TxtID.Text = "0"
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        Call ClearData()
        Call ShowData()

        btnFind.Enabled = False
        btnAdd.Enabled = False
        btnSave.Enabled = False
        btnEdit.Enabled = True
        btnCancel.Enabled = True
    End Sub

    Private Sub txtNoTelp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNoTlpPemilikLahan.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtNoRek_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNoRekPemilikLahan.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtFee_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFeePemilikLahan.KeyPress
        UI.validasi(e, 2)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub cmbP_Uang_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboNamaPemilikLahan.SelectedValueChanged
        Try
            Dim dt As DataTable = New DataTable
            dt = Modul_RMP.DB.ExecuteQuery(StrConnAccounting, "select NamaRekening,NoRekening,JenisBank FROM vwrmmstrekeningpancang  where idpetani='" & cboNamaPemilikLahan.SelectedValue & "' and ID_Jenis_RekKomisi=1")
            Dim row As DataRow = dt.Rows(0)
            txtNamaRekPemilikLahan.Text = row.Item("NamaRekening")
            txtNoRekPemilikLahan.Text = row.Item("NoRekening")
            txtBankPemilikLahan.Text = row.Item("JenisBank")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cboNamaToke_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboNamaToke.SelectedValueChanged
        Try
            Dim dt As DataTable = New DataTable
            dt = Modul_RMP.DB.ExecuteQuery(StrConnAccounting, "select NamaRekening,NoRekening,JenisBank FROM vwrmmstrekeningpancang  where idpetani='" & cboNamaPemilikLahan.SelectedValue & "' and ID_Jenis_RekKomisi=1")
            Dim row As DataRow = dt.Rows(0)
            txtNamaRekToke.Text = row.Item("NamaRekening")
            txtNoRekToke.Text = row.Item("NoRekening")
            txtBankToke.Text = row.Item("JenisBank")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click
        If fg.Rows.Count > 1 Then
            Try
                Call ClearData()

                Dim index As Integer = fg.RowSel
                TxtID.Text = fg.Item(index, "ID")
                dttgl.Value = CDate(fg.Item(index, "Periode"))
                cboPancang.SelectedValue = CInt(fg.Item(index, "IDPancang"))
                cbobahanbaku.SelectedValue = CInt(fg.Item(index, "IDJenisBahanBaku"))

                cboNamaPemilikLahan.SelectedValue = fg.Item(index, "IDPemilikLahan")
                txtNoTlpPemilikLahan.Text = fg.Item(index, "NoTelponPemilikLahan")
                txtFeePemilikLahan.Text = fg.Item(index, "FeePemilikLahan")

                cboNamaToke.SelectedValue = fg.Item(index, "IDToke")
                txtNoTlpToke.Text = fg.Item(index, "NoTelponToke")
                txtFeeToke.Text = fg.Item(index, "FeeToke")

                ChkNotActive.Checked = fg.Item(index, "NotActive")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub FrmMstFee_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        lblJudulForm.Left = (Me.Width - lblJudulForm.Width) / 2
    End Sub


End Class