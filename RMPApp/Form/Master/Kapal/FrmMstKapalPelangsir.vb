Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms

Public Class FrmMstKapalPelangsir

    Private ReadOnly FolderName As String = cls_Webdav.WebDavRMPShipPelangsirFolder
    Private LinkFillUpload As String = ""
    Private NamaFoto As String = ""
    Private NamaFotoLama As String = ""

    Private Sub FrmMstKapalPelangsirInput_Load(
        sender As Object, e As EventArgs
    ) Handles MyBase.Load

        Modul_RMP.Combo.SetPancang(cmbPancang)

        If Val(txtidkapal.Text) = 0 Then
            SetPicture(My.Resources.uploadtidakoke)
        End If

        txtFileAttachment.ReadOnly = True

        SetFormMode(False, False)
    End Sub

    Public Sub ClearInput()
        txtidkapal.Clear()
        txtidpompong2.Clear()
        txtnamapompong.Clear()
        txtkapasitas.Clear()
        txtnamapemilik.Clear()
        txtnohppemilik.Clear()
        txtnamakapten.Clear()
        txtnohpkapten.Clear()
        txtalamat.Clear()

        If cmbPancang.Items.Count > 0 Then
            cmbPancang.SelectedIndex = -1
        End If

        chkNotActive.Checked = False
        SetPicture(My.Resources.uploadtidakoke)

        txtFileAttachment.Clear()
        LinkFillUpload = ""
        NamaFoto = ""
        NamaFotoLama = ""
    End Sub

    Private Sub SetPicture(img As Image)
        If pictItem.Image IsNot Nothing Then
            pictItem.Image.Dispose()
            pictItem.Image = Nothing
        End If

        If img IsNot Nothing Then
            pictItem.Image = New Bitmap(img)
        End If
    End Sub

    Public Sub LoadDataFromFind(Id As Integer)
        Try
            Modul_RMP.Combo.SetPancang(cmbPancang)

            Dim sql As String =
                "SELECT * FROM vwMstPelangsir WHERE id = @id"

            Dim dt As DataTable

            Using conn As SqlConnection = DB.OpenConnection(StrConnRMPApp)
                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = Id

                    Using da As New SqlDataAdapter(cmd)
                        dt = New DataTable()
                        da.Fill(dt)
                    End Using
                End Using
            End Using

            If dt.Rows.Count = 0 Then Exit Sub

            Dim row As DataRow = dt.Rows(0)

            txtidkapal.Text = row("id").ToString()
            txtidpompong2.Text = row("pelangsircode").ToString()
            txtnamapompong.Text = row("namapompong").ToString()
            txtkapasitas.Text = row("kapasitas").ToString()
            txtnamapemilik.Text = row("namapemilik").ToString()
            txtnohppemilik.Text = row("nomorhppemilik").ToString()
            txtnamakapten.Text = row("namakapten").ToString()
            txtnohpkapten.Text = row("nomorhpkapten").ToString()
            cmbPancang.SelectedValue = row("pancangid")
            txtalamat.Text = row("alamatpompong").ToString()
            chkNotActive.Checked = If(IsDBNull(row("notactive")), False,
                                      Convert.ToBoolean(row("notactive")))

            NamaFotoLama = If(IsDBNull(row("fotopompong")),
                              "", row("fotopompong").ToString())

            NamaFoto = NamaFotoLama
            txtFileAttachment.Text = NamaFotoLama
            LinkFillUpload = ""

            SetPicture(My.Resources.uploadtidakoke)
            Func.IsCreateFolderExists(Application.StartupPath & "\" & FolderName)

            If NamaFotoLama <> "" Then
                Try
                    Dim foto As Image = ClsWebDAV.DownloadFileWebDav(
                        cls_Webdav.WebDavRMPShipPelangsir,
                        FolderName,
                        row("id").ToString(),
                        NamaFotoLama)

                    If foto IsNot Nothing Then SetPicture(foto)
                    If foto IsNot Nothing Then foto.Dispose()
                Catch ex As Exception
                    SetPicture(My.Resources.uploadtidakoke)
                End Try
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Gagal Memuat Data",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Function SaveMstKapalPelangsir(
        conn As SqlConnection,
        tran As SqlTransaction,
        ByRef id As String
    ) As Boolean

        Try
            Using cmd As New SqlCommand("RMPApp..sp_RMMstPelangsir", conn, tran)
                cmd.CommandType = CommandType.StoredProcedure

                Dim pid As New SqlParameter("@id", SqlDbType.Int)
                pid.Direction = ParameterDirection.InputOutput
                pid.Value = Val(txtidkapal.Text)
                cmd.Parameters.Add(pid)

                cmd.Parameters.Add("@namapompong", SqlDbType.VarChar, 50).Value =
                    txtnamapompong.Text.Trim()

                cmd.Parameters.Add("@kapasitas", SqlDbType.Int).Value =
                    Convert.ToInt32(txtkapasitas.Text)

                cmd.Parameters.Add("@namapemilik", SqlDbType.VarChar, 50).Value =
                    txtnamapemilik.Text.Trim()

                cmd.Parameters.Add("@nomorhppemilik", SqlDbType.VarChar, 50).Value =
                    Replace(txtnohppemilik.Text, " ", "").Trim()

                cmd.Parameters.Add("@namakapten", SqlDbType.VarChar, 50).Value =
                    txtnamakapten.Text.Trim()

                cmd.Parameters.Add("@nomorhpkapten", SqlDbType.VarChar, 30).Value =
                    Replace(txtnohpkapten.Text, " ", "").Trim()

                cmd.Parameters.Add("@pancangid", SqlDbType.Int).Value =
                    Convert.ToInt32(cmbPancang.SelectedValue)

                cmd.Parameters.Add("@alamatpompong", SqlDbType.VarChar, 1000).Value =
                    txtalamat.Text.Trim()

                cmd.Parameters.Add("@notactive", SqlDbType.Bit).Value =
                    chkNotActive.Checked

                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value =
                    ClsSession.UserID

                cmd.Parameters.Add("@FlagTidakUploadFoto", SqlDbType.Int).Value =
                    If(String.IsNullOrWhiteSpace(LinkFillUpload), 1, 0)

                Dim pError As New SqlParameter("@Error", SqlDbType.VarChar, 200)
                pError.Direction = ParameterDirection.InputOutput
                pError.Value = ""

                Dim pNamaFoto As New SqlParameter("@NamaFoto", SqlDbType.VarChar, 50)
                pNamaFoto.Direction = ParameterDirection.InputOutput
                pNamaFoto.Value = If(NamaFotoLama, "")

                cmd.Parameters.Add(pError)
                cmd.Parameters.Add(pNamaFoto)
                cmd.ExecuteNonQuery()

                If pError.Value IsNot Nothing AndAlso
                   pError.Value IsNot DBNull.Value AndAlso
                   pError.Value.ToString().Trim() <> "" Then

                    MessageBox.Show(pError.Value.ToString(), "Gagal Menyimpan",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If

                id = pid.Value.ToString

                If Not String.IsNullOrWhiteSpace(LinkFillUpload) Then
                    NamaFoto = If(pNamaFoto.Value Is DBNull.Value,
                                  "", Convert.ToString(pNamaFoto.Value))
                Else
                    NamaFoto = NamaFotoLama
                End If
            End Using

            Return True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Gagal Menyimpan Data",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End Try
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtnamapompong.Text.Trim() = "" Then
            TampilkanPeringatan("Nama Pompong Belum Diisi!")
            txtnamapompong.Focus()
            Exit Sub
        End If

        If txtkapasitas.Text.Trim() = "" OrElse
           Not IsNumeric(txtkapasitas.Text) Then
            TampilkanPeringatan("Kapasitas Belum Diisi atau Tidak Valid!")
            txtkapasitas.Focus()
            Exit Sub
        End If

        If txtnamapemilik.Text.Trim() = "" Then
            TampilkanPeringatan("Nama Pemilik Belum Diisi!")
            txtnamapemilik.Focus()
            Exit Sub
        End If

        If txtnohppemilik.Text.Trim() = "" Then
            TampilkanPeringatan("No HP Pemilik Belum Diisi!")
            txtnohppemilik.Focus()
            Exit Sub
        End If

        If txtnamakapten.Text.Trim() = "" Then
            TampilkanPeringatan("Nama Kapten Belum Diisi!")
            txtnamakapten.Focus()
            Exit Sub
        End If

        If txtnohpkapten.Text.Trim() = "" Then
            TampilkanPeringatan("No HP Kapten Belum Diisi!")
            txtnohpkapten.Focus()
            Exit Sub
        End If

        If cmbPancang.SelectedValue Is Nothing OrElse
           Not IsNumeric(cmbPancang.SelectedValue) OrElse
           Convert.ToInt32(cmbPancang.SelectedValue) <= 0 Then
            TampilkanPeringatan("Pancang Belum Dipilih!")
            cmbPancang.Focus()
            Exit Sub
        End If

        If txtalamat.Text.Trim() = "" Then
            TampilkanPeringatan("Alamat Belum Diisi!")
            txtalamat.Focus()
            Exit Sub
        End If

        Dim id As String = ""
        Dim conn As SqlConnection = Nothing
        Dim tran As SqlTransaction = Nothing

        Me.Cursor = Cursors.WaitCursor

        Try
            conn = DB.OpenConnection(StrConnRMPApp)
            tran = conn.BeginTransaction()

            If Not SaveMstKapalPelangsir(conn, tran, id) Then
                tran.Rollback()
                tran = Nothing
                Exit Sub
            End If

            If Not String.IsNullOrWhiteSpace(LinkFillUpload) Then
                If Not UploadFotoKapal(id) Then
                    tran.Rollback()
                    tran = Nothing
                    MessageBox.Show("Gagal menyimpan foto kapal ke WebDAV.",
                                    "Gagal Menyimpan",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            End If

            tran.Commit()
            tran = Nothing

            MessageBox.Show("Simpan Data Berhasil", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.Close()

        Catch ex As Exception
            If tran IsNot Nothing Then
                Try
                    tran.Rollback()
                Catch
                End Try
            End If

            MessageBox.Show(ex.Message, "Gagal Menyimpan",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            If tran IsNot Nothing Then tran.Dispose()

            If conn IsNot Nothing Then
                conn.Close()
                conn.Dispose()
            End If

            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function UploadFotoKapal(ByVal id As String) As Boolean
        If String.IsNullOrWhiteSpace(LinkFillUpload) OrElse
           String.IsNullOrWhiteSpace(NamaFoto) Then Return True

        Try
            Dim kodeKapal As String = txtidpompong2.Text.Trim().Replace("/", "-")
            Func.IsCreateFolderExists(
                Application.StartupPath & "\" & FolderName & "\" & kodeKapal)

            Return ClsWebDAV.UploadFileWebDav(
                LinkFillUpload,
                FolderName,
                id,
                NamaFoto)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Gagal Upload Foto",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End Try
    End Function

    Private Sub TampilkanPeringatan(pesan As String)
        MessageBox.Show(pesan, "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnFileChooseImage_Click(
        sender As Object, e As EventArgs
    ) Handles btnFileChooseImage.Click

        Using dlg As New OpenFileDialog
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            dlg.Title = "Pilih Foto Kapal"
            dlg.Multiselect = False

            If dlg.ShowDialog() <> DialogResult.OK Then Exit Sub

            Try
                If Func.ValidateSpecialCharNextcloud(dlg.FileName) = False Then
                    Exit Sub
                End If

                Using img As Image = Image.FromFile(dlg.FileName)
                    SetPicture(img)
                End Using

                LinkFillUpload = dlg.FileName
                txtFileAttachment.Text = Path.GetFileName(dlg.FileName)

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Gagal Membuka Gambar",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End Using
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ClearInput()
        Modul_RMP.Combo.SetPancang(cmbPancang)

        txtidkapal.Text = "0"
        chkNotActive.Checked = False
        SetFormMode(True, True)
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If String.IsNullOrWhiteSpace(txtidkapal.Text) OrElse
           Val(txtidkapal.Text) = 0 Then
            TampilkanPeringatan("Pilih data kapal yang ingin diubah terlebih dahulu.")
            Exit Sub
        End If

        SetFormMode(True, False)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ClearInput()
        SetFormMode(False, False)
    End Sub

    Private Sub SetFormMode(editing As Boolean, adding As Boolean)
        txtnamapompong.ReadOnly = Not editing
        txtkapasitas.ReadOnly = Not editing
        txtnamapemilik.ReadOnly = Not editing
        txtnohppemilik.ReadOnly = Not editing
        txtnamakapten.ReadOnly = Not editing
        txtnohpkapten.ReadOnly = Not editing
        txtalamat.ReadOnly = Not editing

        txtidkapal.ReadOnly = True
        txtidpompong2.ReadOnly = True
        txtFileAttachment.ReadOnly = True
        cmbPancang.Enabled = editing
        btnFileChooseImage.Enabled = editing
        chkNotActive.Enabled = editing AndAlso Not adding

        btnAdd.Enabled = Not editing
        btnEdit.Enabled = Not editing
        btnSave.Enabled = editing
        btnCancel.Enabled = editing
        btnExit.Enabled = True
    End Sub

    Private Sub txtkapasitas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtkapasitas.KeyPress
        e.Handled = Modul_RMP.Func.NumericOnly(e)
    End Sub

    Private Sub txtnamapompong_KeyPress(
        sender As Object, e As KeyPressEventArgs
    ) Handles txtnamapompong.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtkapasitas.Focus()
        End If
    End Sub

    Private Sub txtnamapemilik_KeyPress(
        sender As Object, e As KeyPressEventArgs
    ) Handles txtnamapemilik.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtnohppemilik.Focus()
        End If
    End Sub

    Private Sub txtnohppemilik_KeyPress(
        sender As Object, e As KeyPressEventArgs
    ) Handles txtnohppemilik.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtnamakapten.Focus()
        End If
    End Sub

    Private Sub txtnamakapten_KeyPress(
        sender As Object, e As KeyPressEventArgs
    ) Handles txtnamakapten.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtnohpkapten.Focus()
        End If
    End Sub

    Private Sub txtnohpkapten_KeyPress(
        sender As Object, e As KeyPressEventArgs
    ) Handles txtnohpkapten.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            txtalamat.Focus()
        End If
    End Sub

    Private Sub FrmMstKapalPelangsir_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Func.ControlCentreForm(Me, PanelForm)
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        FrmMain.BukaMenu(FrmMstKapalPelangsirShow, FrmMain.mnuMstKapalKapalPelangsir)
    End Sub

    Private Sub txtnohppemilik_Click(sender As Object, e As EventArgs) Handles txtnohppemilik.Click
        Func.MaskTextBox_SetCursorAkhir(txtnohppemilik)
    End Sub

    Private Sub txtnohppemilik_Enter(sender As Object, e As EventArgs) Handles txtnohppemilik.Enter
        Func.MaskTextBox_SetCursorAkhir(txtnohppemilik)
    End Sub

    Private Sub txtnohpkapten_Click(sender As Object, e As EventArgs) Handles txtnohpkapten.Click
        Func.MaskTextBox_SetCursorAkhir(txtnohpkapten)
    End Sub

    Private Sub txtnohpkapten_Enter(sender As Object, e As EventArgs) Handles txtnohpkapten.Enter
        Func.MaskTextBox_SetCursorAkhir(txtnohpkapten)
    End Sub
End Class
