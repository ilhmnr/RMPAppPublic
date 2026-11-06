Imports System.Data.SqlClient

Public Class FrmTrnEditDataPembelianBarangPancangCash
    Public Kategori As String = ""
    Public Catatan As String = ""
    Public rdpan, rdpur, rdpul As Boolean
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim koneksi As SqlConnection = DB.OpenConnection(StrConnRMPApp)
        Dim Transaksi As SqlTransaction
        Transaksi = koneksi.BeginTransaction

        If ChkNonActive.Checked = True Then
            If MsgBox("Yakin Ingin Hapus Data ini ?", vbYesNo, AT) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        If TxtNamaItem.Text = "" Then
            MsgBox("Nama Item Masih Kosong !", vbExclamation, AT)
            Exit Sub
        ElseIf TxtQty.Text = "" Then
            MsgBox("Quantity Masih Kosong !", vbExclamation, AT)
            Exit Sub
        ElseIf TxtHarga.Text = "" Then
            MsgBox("Harga Masih Kosong !", vbExclamation, AT)
            Exit Sub
        ElseIf CmbCatatan.Text = "" Then
            MsgBox("Catatan Masih Kosong !", vbExclamation, AT)
            Exit Sub
        ElseIf CmbKategori.Text = "" Then
            MsgBox("kategori Masih Kosong !", vbExclamation, AT)
            Exit Sub
        End If

        If SaveData(koneksi, Transaksi) = False Then
            Transaksi.Rollback()
            MsgBox("Simpan Data Gagal", vbCritical, "info")
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        Transaksi.Commit()

        MsgBox("Data Berhasil Di Edit", vbInformation, AT)
        Me.Close()
    End Sub

    Private Function SaveData(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        SaveData = False
        Dim MyCon As SqlConnection = Conn
        Dim MyConTrans As SqlTransaction = Trans
        Dim cmd As New SqlCommand

        With cmd
            .Connection = Conn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "PSGRMP..SpInv_SaveEditDataPembelianBarangCashPancang"
            .Transaction = MyConTrans
            .Parameters.Add("@DetailId", SqlDbType.Int).Value = TxtDetailId.Text
            .Parameters.Add("@NamaItem", SqlDbType.VarChar, 200).Value = TxtNamaItem.Text
            .Parameters.Add("@CatatanId", SqlDbType.Int).Value = CmbCatatan.SelectedValue
            .Parameters.Add("@KategoriId", SqlDbType.Int).Value = CmbKategori.SelectedValue
            .Parameters.Add("@Qty", SqlDbType.Decimal, 18, 2).Value = CDec(TxtQty.Text)
            .Parameters.Add("@Harga", SqlDbType.Decimal, 18, 2).Value = CDec(TxtHarga.Text)
            .Parameters.Add("@Total", SqlDbType.Decimal, 18, 2).Value = CDec(TxtTotal.Text)
            .Parameters.Add("@Kategori", SqlDbType.VarChar, 15).Value = IIf(RdInv.Checked = True, "Inventaris", "Operasional")
            .Parameters.Add("@NonActive", SqlDbType.Int).Value = IIf(ChkNonActive.Checked = True, 1, 0)
            .Parameters.Add("@UserEdit", SqlDbType.VarChar, 50).Value = ClsSession.UserID
            .Parameters.Add("@Tanggal", SqlDbType.Date).Value = Format(tgl.Value, "yyyy-MM-dd")
            .Parameters.Add(New SqlParameter("@Flag", SqlDbType.TinyInt, 1, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .ExecuteNonQuery()
        End With

        Try
            If CInt(cmd.Parameters("@Flag").Value) = "0" Then
                cmd.Dispose()
                Exit Function
            End If

            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function

    Private Sub TxtQty_TextChanged(sender As Object, e As EventArgs) Handles TxtQty.TextChanged
        Try
            TxtTotal.Text = IIf(TxtQty.Text = "", 0, TxtQty.Text) * IIf(TxtHarga.Text = "", 0, TxtHarga.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub rdPancang_CheckedChanged(sender As Object, e As EventArgs) Handles rdPancang.CheckedChanged
        SetCmbCatatan()
    End Sub

    Private Sub rdPurchaser_CheckedChanged(sender As Object, e As EventArgs) Handles rdPurchaser.CheckedChanged
        SetCmbCatatan()
    End Sub

    Private Sub rdPulsa_CheckedChanged(sender As Object, e As EventArgs) Handles rdPulsa.CheckedChanged
        SetCmbCatatan()
    End Sub

    Private Sub FrmTrnEditDataPembelianBarangPancangCash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Combo.InvCategory(CmbKategori)

        rdPancang.Checked = rdpan
        rdPurchaser.Checked = rdpur
        rdPulsa.Checked = rdpul
        SetCmbCatatan()

        CmbKategori.Text = Kategori
        CmbCatatan.Text = Catatan
    End Sub

    Public Sub SetCmbCatatan()
        Dim dt As DataTable = New DataTable()
        Dim Pembelian As Integer = 0

        If rdPancang.Checked = True Then
            Pembelian = 1
        End If
        If rdPurchaser.Checked = True Then
            Pembelian = 3
        End If
        If rdPulsa.Checked = True Then
            Pembelian = 2
        End If

        dt = DB.ExecuteQuery(StrConnPSGRMP, "select remark,id from PSGRMP..tblPancangReq_MasterCatatan where penggunaan_id='" & Pembelian & "' and notactive=0 and deleted=0")
        With CmbCatatan
            .DataSource = dt
            .DisplayMember = "remark"
            .ValueMember = "id"
            .SelectedIndex = -1
        End With
    End Sub

End Class