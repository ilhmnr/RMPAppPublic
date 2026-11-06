Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class FrmMstUpahBongkarMuatKeSupplier
    Public IDPancang As String
    Private Sub FrmMastUpahBongkarMuat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClearData()
        Modul_RMP.Combo.SetPancang(cmbPancang)
        Modul_RMP.Combo.SetCustomer(cmbSupplierTujuan)
        Combo.SetPancang(cmbPancang2)
        Modul_RMP.Combo.SetBahanBaku(cbobahanbaku)

        dgvlist.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 140, 217)
        dgvlist.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvlist.EnableHeadersVisualStyles = False

        cbobahanbaku.TabIndex = 2003
        dtpPeriode.TabIndex = 2004
        txtUpah.TabIndex = 2005
        TxtUpahKapalCrane.TabIndex = 2006
        txtKet.TabIndex = 2007
    End Sub

    Private Sub ClearData()
        txtIDUpah.Clear()
        cmbPancang.Text = ""
        cmbSupplierTujuan.Text = ""
        cbobahanbaku.Text = ""
        dtpPeriode.Value = Now
        txtUpah.Clear()
        TxtUpahKapalCrane.Clear()
        txtKet.Clear()

        txtIDUpah.Enabled = False
        cmbPancang.Enabled = False
        cmbSupplierTujuan.Enabled = False
        cbobahanbaku.Enabled = False
        rdLaut.Enabled = False
        rdDarat.Enabled = False
        dtpPeriode.Enabled = False
        txtUpah.Enabled = False
        TxtUpahKapalCrane.Enabled = False
        txtKet.Enabled = False

        btnAdd.Enabled = True
        btnFind.Enabled = True
        btnSave.Enabled = False
        btnEdit.Enabled = False
        btnCancel.Enabled = True
    End Sub

    Private Sub dtpPeriode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpPeriode.KeyPress
        If (e.KeyChar = Chr(13)) Then
            txtUpah.Focus()
        End If
    End Sub

    Private Sub txtKet_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKet.KeyPress
        If (e.KeyChar = Chr(13)) Then
            btnSave.Focus()
        End If
    End Sub

    Private Sub cmbPancang_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbPancang.KeyUp
        UI.AutoCompleteCombo_KeyUp(cmbPancang, e)
    End Sub

    Private Sub txtUpah_GotFocus(sender As Object, e As EventArgs) Handles txtUpah.GotFocus
        If txtUpah.Text = "0" Then
            txtUpah.Text = ""
        End If
    End Sub

    Private Sub txtUpahKapalCrane_GotFocus(sender As Object, e As EventArgs) Handles TxtUpahKapalCrane.GotFocus
        If TxtUpahKapalCrane.Text = "0" Then
            TxtUpahKapalCrane.Text = ""
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        txtIDUpah.Text = 0
        cmbPancang.Text = ""
        cmbSupplierTujuan.Text = ""
        cbobahanbaku.Text = ""
        dtpPeriode.Value = Now
        txtUpah.Text = 0
        TxtUpahKapalCrane.Text = 0
        txtKet.Clear()

        txtIDUpah.Enabled = False
        cmbPancang.Enabled = True
        cmbSupplierTujuan.Enabled = True
        cbobahanbaku.Enabled = True
        rdLaut.Enabled = True
        rdDarat.Enabled = True
        dtpPeriode.Enabled = True
        txtUpah.Enabled = True
        TxtUpahKapalCrane.Enabled = True
        txtKet.Enabled = True

        btnAdd.Enabled = False
        btnFind.Enabled = False
        btnSave.Enabled = True
        btnEdit.Enabled = False
        btnCancel.Enabled = True

        cmbPancang.Focus()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Call ClearData()
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        txtIDUpah.Enabled = False
        cmbPancang.Enabled = False
        cmbSupplierTujuan.Enabled = False
        cbobahanbaku.Enabled = True
        rdLaut.Enabled = True
        rdDarat.Enabled = True
        dtpPeriode.Enabled = False
        txtUpah.Enabled = True
        TxtUpahKapalCrane.Enabled = True
        txtKet.Enabled = True

        btnAdd.Enabled = False
        btnSave.Enabled = True
        btnEdit.Enabled = False
        btnCancel.Enabled = True
    End Sub

    Private Sub SaveData()
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim koneksi As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnRMPApp)
            Dim Transaksi As SqlTransaction
            Transaksi = koneksi.BeginTransaction

            If SaveMstTambang(koneksi, Transaksi) = False Then
                Transaksi.Rollback()
                MsgBox("Simpan Data Gagal", vbExclamation, "Save Data - " & AT)
                Exit Try
            End If

            Transaksi.Commit()
            MessageBox.Show("Save Completed !", "Save Data - " & AT, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call ClearData()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Save Data - " & AT, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function SaveMstTambang(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        Dim MyCMD As New SqlCommand
        Try
            With MyCMD
                .Connection = Conn
                .CommandType = CommandType.StoredProcedure
                .CommandText = "RMPApp..spSaveTambangKapalKeSupplier"
                .Transaction = Trans

                .Parameters.Add("@IDTambang", SqlDbType.Int).Value = txtIDUpah.Text
                .Parameters.Add("@IDPancang", SqlDbType.Int).Value = cmbPancang.SelectedValue
                .Parameters.Add("@IDSupplierTujuan", SqlDbType.VarChar, 50).Value = cmbSupplierTujuan.SelectedValue
                .Parameters.Add("@Periode", SqlDbType.Date).Value = dtpPeriode.Value
                .Parameters.Add("@UpahTambang", SqlDbType.Int).Value = txtUpah.Text
                .Parameters.Add("@UpahTambangKapalCrane", SqlDbType.Int).Value = TxtUpahKapalCrane.Text
                .Parameters.Add("@Jenis", SqlDbType.Int).Value = IIf(rdLaut.Checked = True, 1, 2)
                .Parameters.Add("@JenisBahanBaku", SqlDbType.Int).Value = cbobahanbaku.SelectedValue
                .Parameters.Add("@Ket", SqlDbType.VarChar, 200).Value = txtKet.Text
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

    Private Sub BtnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        With FrmMstUpahBongkarMuatShow
            .FormName = "FrmMstUpahBongkarMuatPCGSub"
            .ShowDialog()
            .ClearData()
        End With
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If cmbPancang.Text = "" Then
            MsgBox("Pancang Is Empty !", MsgBoxStyle.Exclamation, AT)
        ElseIf cmbSupplierTujuan.Text = "" Then
            MsgBox("Pancang Tujuan Is Empty !", MsgBoxStyle.Exclamation, AT)
        ElseIf cbobahanbaku.Text = "" Then
            MsgBox("Upah Bongkar Is Empty !", MsgBoxStyle.Exclamation, AT)
        ElseIf txtUpah.Text = "" Then
            MsgBox("Upah Bongkar Is Empty !", MsgBoxStyle.Exclamation, AT)
        ElseIf TxtUpahKapalCrane.Text = "" Then
            MsgBox("Upah Bongkar Kapal Crane Is Empty !", MsgBoxStyle.Exclamation, AT)
        ElseIf txtKet.Text = "" Then
            MsgBox("Keterangan Is Empty !", MsgBoxStyle.Exclamation, AT)
        Else
            Call SaveData()
            Call LoadData()
        End If
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        LoadData()
    End Sub

    Sub LoadData()
        Dim i As Integer = 0
        Dim SQL, SQL1, SQL2, SQL3, SQL4, SQL5, SQL6, StatusVaksin As String

        If cmbPancang2.Text = "Nama Pancang" Then
            SQL1 = ""
        Else
            SQL1 = " And (IDPancang = '" & cmbPancang2.SelectedValue & "')"
        End If

        If dtp1.Checked = False Then
            SQL2 = ""
        Else
            SQL2 = "and ((convert(date,convert(varchar, Periode,103),103) between convert (date,'" & dtp1.Value & "',103) and convert(date,'" & dtp2.Value & "',103))) "
        End If

        SQL = " SELECT * FROM vwMstTambangKapalKeSupplier where IDTambang is not null "

        SQL = SQL + SQL1 + SQL2 + SQL3 + SQL4 + SQL5 + SQL6 + "  ORDER BY Periode desc "


        Try
            Me.Cursor = Cursors.WaitCursor
            Using koneksi As New SqlCommand(SQL, DB.OpenConnection(StrConnRMPApp))
                Using DR = koneksi.ExecuteReader
                    dgvlist.Rows.Clear()

                    If DR.HasRows Then
                        dgvlist.RowCount = 0
                        While DR.Read
                            With dgvlist
                                .Rows.Add()
                                .Item("No", i).Value = i + 1
                                .Item("IDTambang", i).Value = DR!IDTambang
                                .Item("IDPancang2", i).Value = DR!IDPancang
                                .Item("Pancang", i).Value = DR!Pancang
                                .Item("SupplierTujuan", i).Value = DR!SupplierTujuan
                                .Item("Periode", i).Value = DR!Periode
                                .Item("UpahTambang", i).Value = DR!UpahTambang
                                .Item("UpahTambangKapalCrane", i).Value = DR!UpahTambangKapalCrane
                                .Item("KodeBB", i).Value = DR!JenisBahanBaku
                                .Item("JenisBahanBaku", i).Value = DR!NamaBahanBaku
                                .Item("Keterangan", i).Value = DR!Ket
                                .Item("CreatedBy", i).Value = DR!CreatedBy
                                .Item("CreatedDate", i).Value = DR!CreatedDate
                                If IsDBNull(DR!UpdatedBy) Then .Item("UpdatedBy", i).Value = "" Else .Item("UpdatedBy", i).Value = DR!UpdatedBy
                                If IsDBNull(DR!UpdatedDate) Then .Item("UpdatedDate", i).Value = "" Else .Item("UpdatedDate", i).Value = DR!UpdatedDate

                                .RowsDefaultCellStyle.BackColor = Color.White
                                .AlternatingRowsDefaultCellStyle.BackColor = Color.Azure

                                With Me.dgvlist
                                    .RowsDefaultCellStyle.BackColor = Color.White
                                    .AlternatingRowsDefaultCellStyle.BackColor = Color.White
                                    .Rows(i).Cells("No").Style.BackColor = Color.FromArgb(240, 240, 240)
                                End With
                            End With
                            i += 1
                        End While
                    Else
                        dgvlist.Rows.Clear()
                        MsgBox("Data Tidak ditemukan ! ", MsgBoxStyle.Information)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    DR.Close()
                End Using
            End Using
            DB.CloseConnection()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub txtCari_MouseClick(sender As Object, e As MouseEventArgs) Handles txtCari.MouseClick
        If txtCari.Text = "Search" Then txtCari.Text = String.Empty
    End Sub
    Private Sub txtCari_LostFocus(sender As Object, e As EventArgs) Handles txtCari.LostFocus
        If txtCari.Text = String.Empty Then txtCari.Text = "Search"
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub txtUpah_LostFocus(sender As Object, e As EventArgs) Handles txtUpah.LostFocus
        If txtUpah.Text = "" Then
            txtUpah.Text = 0
        End If
    End Sub

    Private Sub TxtUpahKapalCrane_LostFocus(sender As Object, e As EventArgs) Handles TxtUpahKapalCrane.LostFocus
        If TxtUpahKapalCrane.Text = "" Then
            TxtUpahKapalCrane.Text = 0
        End If
    End Sub

    Private Sub txtUpah_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUpah.KeyPress
        ' Cek apakah karakter bukan angka dan bukan tombol kontrol (Backspace, Delete, dll.)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True ' Batalkan input karakter yang tidak valid
        End If
    End Sub

    Private Sub TxtUpahKapalCrane_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtUpahKapalCrane.KeyPress
        ' Cek apakah karakter bukan angka dan bukan tombol kontrol (Backspace, Delete, dll.)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True ' Batalkan input karakter yang tidak valid
        End If
    End Sub
End Class