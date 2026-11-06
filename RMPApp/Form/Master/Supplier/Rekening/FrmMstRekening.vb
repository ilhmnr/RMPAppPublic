Imports System.Data.SqlClient
Imports System.IO
Imports System.Linq.Expressions
Imports Dapper

Public Class FrmMstRekening
    Private FolderLokal As String = cls_Webdav.WebDavGENSupplierFolder
    Private Sub FrmMstSupRekening__Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Modul_RMP.Combo.Bank(cboBank)

        ClsFlexGrid.ApplyStyle(fg)
        ClsFlexGrid.ApplyStyle(fgRek)

        ClearInput()
        EnableInput(False)
        ReadOnlyInput(True)
        CmdEnabled(True)
    End Sub

    Private Sub ShowData()
        Dim SQL As String = ""
        Dim i As Integer = 1
        Dim dt As DataTable = New DataTable()

        If txtFind.Text.Replace(" ", "") = "" Then
            MsgBoxCustom.Show("Tentukan relasi yang ingin di cari !", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
            Exit Sub
        End If

        SQL = "select * from vwMstSupplierRekening where 1=1"

        If txtFind.Text <> "" Then
            SQL &= " and (KodeSup Like '%" & txtFind.Text & "%' or NamaSup like '%" & txtFind.Text & "%')"
        End If

        If rdTidakAdaRek.Checked Then
            SQL &= " and IndAdaRekening=0"
        ElseIf rdAdaRek.Checked Then
            SQL &= " and IndAdaRekening=1"
        End If

        SQL &= " order by NamaSup"

        Try
            Me.Cursor = Cursors.WaitCursor

            dt = DB.ExecuteQuery(StrConnAccounting, SQL)

            With fg
                .Rows.Count = 1

                If dt.Rows.Count > 0 Then
                    For Each row As DataRow In dt.Rows
                        .AddItem(i)
                        .Item(i, "IDSupplier") = row("KodeSup")
                        .Item(i, "NamaSupplier") = row("NamaSup")
                        .Item(i, "IDPancang") = If(IsDBNull(row("IDPancang")), "", row("IDPancang"))
                        .Item(i, "Pancang") = If(IsDBNull(row("Pancang")), "", row("Pancang"))
                        .Item(i, "Alamat") = If(IsDBNull(row("Alamat")), "", row("Alamat"))
                        .Item(i, "DivBlokKav") = If(IsDBNull(row("DivBlokKav")), "", row("DivBlokKav"))

                        i += 1
                    Next

                    .AutoSizeCols()
                Else
                    MsgBoxCustom.Show("Data Tidak ditemukan ! ", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                End If
            End With
        Catch ex As Exception
            MsgBoxCustom.Show(ex.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ShowDataRek()
        Dim SQL As String
        Dim i As Integer = 1
        Dim dt As DataTable = New DataTable()

        SQL = " SELECT * FROM vwRMMstRekeningPancang  WHERE IDPetani = '" & fg.Item(fg.Row, "IDSupplier") & "'"

        Try
            Me.Cursor = Cursors.WaitCursor

            dt = DB.ExecuteQuery(StrConnAccounting, SQL)

            With fgRek
                fgRek.Rows.Count = 1

                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "IDRekening") = row("IDNoRek")
                    .Item(i, "NoRekening") = If(IsDBNull(row("NoRekening")), "", row("NoRekening"))
                    .Item(i, "NamaRekening") = If(IsDBNull(row("NamaRekening")), "", row("NamaRekening"))
                    .Item(i, "Bank") = If(IsDBNull(row("JenisBank")), "", row("JenisBank"))
                    .Item(i, "RekeningKelapa") = If(IsDBNull(row("ID_Jenis_Rek")), False, row("ID_Jenis_Rek"))
                    .Item(i, "RekeningTambang") = If(IsDBNull(row("ID_Jenis_RekUBM")), False, row("ID_Jenis_RekUBM"))
                    .Item(i, "RekeningUpahBongkar") = If(IsDBNull(row("ID_Jenis_RekUB")), False, row("ID_Jenis_RekUB"))
                    .Item(i, "RekeningKomisi") = If(IsDBNull(row("ID_Jenis_RekKomisi")), False, row("ID_Jenis_RekKomisi"))
                    .Item(i, "InActive") = If(IsDBNull(row("InActive")), False, row("InActive"))
                    .Item(i, "Keterangan") = If(IsDBNull(row("Remark")), "", row("Remark"))
                    .Item(i, "Create") = If(IsDBNull(row("CreatedBy")), "", row("CreatedBy") & " / " & row("CreatedDate"))
                    .Item(i, "Update") = If(IsDBNull(row("UpdatedBy")), "", row("UpdatedBy") & " / " & row("UpdatedDate"))

                    i += 1
                Next

                .AutoSizeCols()
            End With
        Catch ex As Exception
            MsgBoxCustom.Show(ex.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub fg_DoubleClick(sender As Object, e As EventArgs) Handles fg.DoubleClick
        ClearInput()
        EnableInput(False)
        ReadOnlyInput(True)
        CmdEnabled(True)

        txtIDPancang.Text = fg.Item(fg.Row, "IDPancang")
        txtKodeSup.Text = fg.Item(fg.Row, "IDSupplier")

        ShowDataRek()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub fgRek_DoubleClick(sender As Object, e As EventArgs) Handles fgRek.DoubleClick
        ClearInput()
        LoadDataRekening(fgRek.Item(fgRek.Row, "IDRekening"))
    End Sub

    Private Sub LoadDataRekening(ByVal IDRek As Integer)
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim dt As DataTable = New DataTable()
            Dim sql As String = ""

            sql = " SELECT * FROM vwrmmstrekeningpancang  WHERE IDNoRek = '" & IDRek & "'"

            dt = DB.ExecuteQuery(StrConnAccounting, sql)

            txtIDRek.Text = dt.Rows(0)("IDNoRek").ToString()
            txtNamaSup.Text = dt.Rows(0)("NamaRekening").ToString()
            txtNoRekening.Text = dt.Rows(0)("NoRekening").ToString()
            cboBank.Text = dt.Rows(0)("JenisBank").ToString()
            chkkelapa.Checked = Convert.ToBoolean(dt.Rows(0)("ID_Jenis_Rek"))
            CHKUBM.Checked = Convert.ToBoolean(dt.Rows(0)("ID_Jenis_RekUBM"))
            chkub.Checked = Convert.ToBoolean(dt.Rows(0)("ID_Jenis_RekUB"))
            chkKomisi.Checked = Convert.ToBoolean(dt.Rows(0)("ID_Jenis_RekKomisi"))
            txtKeterangan.Text = dt.Rows(0)("Remark").ToString()
            chkInActive.Checked = Convert.ToBoolean(dt.Rows(0)("InActive"))
            If Not IsDBNull(dt.Rows(0)("FileAttachment")) Then txtFileAttachment.Text = dt.Rows(0)("FileAttachment").ToString()

            Call Func.IsCreateFolderExists(Application.StartupPath & "\" & FolderLokal)
            If txtFileAttachment.Text <> "" Then
                pictItem.Image = ClsWebDAV.DownloadFileWebDav(cls_Webdav.WebDavGENSupplier, FolderLokal, txtKodeSup.Text, txtFileAttachment.Text)
            End If
        Catch ex As Exception

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If txtIDRek.Text = "" Then
            MsgBoxCustom.Show("Tentukan rekening relasi yang ingin diubah !", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
            Exit Sub
        End If

        CmdEnabled(False)
        EnableInput(True)
        ReadOnlyInput(False)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtKodeSup.Text = "" And txtIDPancang.Text = "" Then
            MsgBox("Tentukan relasi yang ingin di input !", MsgBoxStyle.Exclamation, AT)
            Exit Sub
        End If

        CmdEnabled(False)
        ClearInput()
        EnableInput(True)
        ReadOnlyInput(False)

        txtIDRek.Text = "0"
    End Sub

    Sub ClearInput()
        ' bersihkan input
        txtIDRek.Clear()
        chkInActive.Checked = False
        txtNamaSup.Clear()
        txtNoRekening.Clear()
        cboBank.Text = ""
        txtKeterangan.Clear()
        chkkelapa.Checked = False
        CHKUBM.Checked = False
        chkub.Checked = False
        chkKomisi.Checked = False

        pictItem.Image = Nothing
        txtFileAttachment.Clear()
    End Sub

    Private Sub EnableInput(ByVal flag As Boolean)
        chkInActive.Enabled = flag
        cboBank.Enabled = flag
        chkkelapa.Enabled = flag
        CHKUBM.Enabled = flag
        chkub.Enabled = flag
        chkKomisi.Enabled = flag
        btnFileChooseImage.Enabled = flag
    End Sub

    Private Sub ReadOnlyInput(ByVal flag As Boolean)
        txtNamaSup.ReadOnly = flag
        txtNoRekening.ReadOnly = flag
        txtKeterangan.ReadOnly = flag
    End Sub

    Private Sub CmdEnabled(flag As Boolean)
        btnAdd.Enabled = flag
        btnEdit.Enabled = flag
        btnExit.Enabled = flag
        btnSave.Enabled = Not flag
        BtnCancel.Enabled = Not flag
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        ClearInput()
        EnableInput(False)
        ReadOnlyInput(True)
        CmdEnabled(True)
    End Sub

    Public Class Rekening
        Public Property JenisBank As String
        Public Property NoRekening As String
        Public Property NamaRekening As String
        Public Property IDPancang As Integer
        Public Property IDPetani As String
        Public Property InActive As Boolean
        Public Property InActiveMstRek As Boolean
        Public Property InActiveBy As String
        Public Property CreatedBy As String
        Public Property IDNoRek As Integer
        Public Property ID_Jenis_Rek As Boolean
        Public Property ID_Jenis_RekUBM As Boolean
        Public Property ID_Jenis_RekUB As Boolean
        Public Property ID_Jenis_RekKomisi As Boolean
        Public Property Flag As Integer

        Public Property RemarksApproval1 As String
    End Class

    Private Function Statusrek(rek As String) As String
        Try
            Dim IDPetani As String = ""

            IDPetani = DB.ExecuteScalarValue(Of String)(StrConnAccounting, " select isnull((Select TOP(1) IDPETANI From  vwrmmstrekeningpancang where norek ='" & rek & "' and (InActive IS NULL OR InActive=0) and IDPETANI <>'" & txtKodeSup.Text & "'),'') as GetValueString ")

            Return IDPetani
        Catch ex As Exception
            MsgBox("Gagagl Cek Status Rekening, Coba Save Kembali !", vbExclamation, AT)
            Return "Error"
        End Try
    End Function

    Private Sub btnFileChooseImage_Click(sender As Object, e As EventArgs) Handles btnFileChooseImage.Click
        Dim openfile As New OpenFileDialog
        Try
            With openfile
                '.InitialDirectory = "D:/"
                .Filter = ("Image Files|*.jpeg;*.jpg;*.gif;*.png;*.bmp")
                .FilterIndex = 1
                .Multiselect = False
            End With
            'Clear the file name
            openfile.FileName = ""
            If openfile.ShowDialog() = DialogResult.OK Then
                If Func.ValidateSpecialCharNextcloud(openfile.FileName) = False Then Exit Sub
                pictItem.Image = Image.FromFile(openfile.FileName)
                txtFileAttachment.Text = openfile.SafeFileName
                txtFileAttachment.Tag = openfile.FileName
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        ShowData()
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click

    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As C1.Win.C1FlexGrid.RowColEventArgs) Handles fg.BeforeEdit, fgRek.BeforeEdit
        e.Cancel = True
    End Sub



    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim IDRek As Integer = 0
        Dim FileName As String = ""

        If txtNamaSup.Text = "" Then
            MsgBoxCustom.Show("Nama Rekening Tidak Boleh Kosong !", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
            Exit Sub
        End If

        If Replace(Trim(txtNoRekening.Text), " ", "") = "" Then
            MsgBoxCustom.Show("Nomor Rekening Tidak Boleh Kosong !", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
            Exit Sub
        End If

        If cboBank.Text = "" Then
            MsgBoxCustom.Show("Jenis Bank Tidak Boleh Kosong !", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
            Exit Sub
        End If

        If txtKeterangan.Text = "" Then
            MsgBoxCustom.Show("Keterangan Tidak Boleh Kosong !", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
            Exit Sub
        End If

        If chkkelapa.Checked = False And CHKUBM.Checked = False And chkub.Checked = False And chkKomisi.Checked = False Then
            MsgBoxCustom.Show("Jenis Rekening Belum Dipilih !", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
            Exit Sub
        End If

        If txtIDPancang.Text = "" Then
            MsgBoxCustom.Show("Divisi Relasi Bukan Divisi Pancang,Update Dulu Divisi Nya Di Master Relasi Untuk Melanjutkan !", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
            Exit Sub
        End If

        If Trim(txtFileAttachment.Tag) = "" Then
            MsgBoxCustom.Show("Gambar Belum Di Upload,Save Data Gagal !", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
            Exit Sub
        End If

        If chkKomisi.Checked = True Then
            If CInt(DB.ExecuteScalarValue(Of Integer)(StrConnAccounting, "select isnull((select 1 from TblRMMstRekRM where IDPetani='" & txtKodeSup.Text & "' and isnull(InActive,0)=0 and ID_Jenis_RekKomisi=1 and IDNoRek<>" & txtIDRek.Text & "),'') as GetValueString")) = 1 Then
                MsgBoxCustom.Show("Sudah Ada Rekening Komisi yang Aktif, Tidak Boleh Lebih Dari 1 Rekening Komisi Aktif !", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
                Exit Sub
            End If
        End If

        Dim conn As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnAccounting)
        Dim tran As SqlTransaction
        tran = conn.BeginTransaction

        Try
            Me.Cursor = Cursors.WaitCursor

            If Trim(txtFileAttachment.Tag) <> "" Then
                If txtFileAttachment.Tag <> "" Then
                    Dim extension As String = Path.GetExtension(txtFileAttachment.Text)
                    FileName = "Rek_" & Replace(Replace(Trim(txtKodeSup.Text), "[", ""), "]", "") & "_" & Format(Func.GetDate(), "ddMMyyyyHHmmss") & extension
                Else
                    FileName = IIf(Trim(txtFileAttachment.Text) = "", DBNull.Value, txtFileAttachment.Text)
                End If
            End If

            If SaveData(conn, tran, IDRek, FileName) = False Then
                tran.Rollback()
                MsgBoxCustom.Show("Simpan Rekening Gagal !", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
                Exit Sub
            End If

            Call Func.IsCreateFolderExists(Application.StartupPath & "\" & FolderLokal & "\" & Replace(Trim(txtKodeSup.Text), "/", "-"))
            If Trim(txtFileAttachment.Tag) <> "" Then
                Dim ok As Boolean = ClsWebDAV.UploadFileWebDav(txtFileAttachment.Tag, FolderLokal, Trim(txtKodeSup.Text), FileName)
                If Not ok Then
                    tran.Rollback()
                    MsgBoxCustom.Show("Gagal menyimpan lampiran dokumen supplier.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
                    Exit Sub
                End If
            End If

            tran.Commit()

            MsgBoxCustom.Show("Simpan Rekening Berhasil !", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)

            ShowDataRek()
            CmdEnabled(True)
            ClearInput()
            EnableInput(False)
            ReadOnlyInput(True)
            LoadDataRekening(IDRek)
        Catch ex As Exception
            MsgBoxCustom.Show("Error !" + ex.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
            tran.Rollback()
            Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " delete RSUPAccounting..TblRMMstRekRM where IDNoRek='" & txtIDRek.Text & "' ")
        Finally
            conn.Close()
            conn.Dispose()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function SaveData(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByRef IDRek As Integer, ByVal FileName As String) As Boolean
        Try
            IDRek = 0

            Using cmd As New SqlCommand("spMstRekening", Conn, Trans)

                cmd.CommandType = CommandType.StoredProcedure

                Dim pID As SqlParameter = cmd.Parameters.Add("@IDNoRek", SqlDbType.BigInt)
                pID.Direction = ParameterDirection.InputOutput
                pID.Value = CLng(txtIDRek.Text)
                cmd.Parameters.Add("@JenisBank", SqlDbType.VarChar, 50).Value = cboBank.Text.Trim()
                cmd.Parameters.Add("@NoRekening", SqlDbType.VarChar, 30).Value = Replace(Trim(txtNoRekening.Text), " ", "")
                cmd.Parameters.Add("@NamaRekening", SqlDbType.VarChar, 100).Value = txtNamaSup.Text.Trim()
                cmd.Parameters.Add("@IDPancang", SqlDbType.Int).Value = CInt(txtIDPancang.Text)
                cmd.Parameters.Add("@IDPetani", SqlDbType.VarChar, 10).Value = txtKodeSup.Text.Trim()
                cmd.Parameters.Add("@InActive", SqlDbType.Int).Value = If(chkInActive.Checked, 1, 0)
                cmd.Parameters.Add("@Remark", SqlDbType.VarChar, 20).Value = txtKeterangan.Text.Trim()
                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 20).Value = ClsSession.UserID
                cmd.Parameters.Add("@ID_Jenis_Rek", SqlDbType.Int).Value = If(chkkelapa.Checked, 1, 0)
                cmd.Parameters.Add("@ID_Jenis_RekUBM", SqlDbType.Int).Value = If(CHKUBM.Checked, 1, 0)
                cmd.Parameters.Add("@ID_Jenis_RekUB", SqlDbType.Int).Value = If(chkub.Checked, 1, 0)
                cmd.Parameters.Add("@ID_Jenis_RekKomisi", SqlDbType.Int).Value = If(chkKomisi.Checked, 1, 0)
                cmd.Parameters.Add("@FileAttachment", SqlDbType.VarChar).Value = FileName
                Dim pFlag As SqlParameter = cmd.Parameters.Add("@Flag", SqlDbType.Int)
                pFlag.Direction = ParameterDirection.Output

                cmd.ExecuteNonQuery()

                If pFlag.Value Is Nothing OrElse pFlag.Value Is DBNull.Value Then
                    Return False
                End If

                If Convert.ToInt32(pFlag.Value) = 0 Then
                    Return False
                End If

                If pID.Value Is Nothing OrElse pID.Value Is DBNull.Value Then
                    Return False
                End If

                IDRek = Convert.ToInt32(pID.Value)

            End Using
        Catch ex As Exception
            MsgBoxCustom.Show("Error Simpan Rekening ! " + ex.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
        End Try

        Return IDRek > 0
    End Function

End Class