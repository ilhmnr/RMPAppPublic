Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmUtlUser

    Private status As Integer
    Private _isFromOneLogin As Boolean = False
    Private _oneLoginUsername As String = ""

    Private Sub FrmUtlUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClsFlexGrid.ApplyStyle(fg)

        Combo.Role(cmbRole)

        search()
        ClearData()
        ShowData()
    End Sub

    ' ==========================================================
    ' CLEAR FORM
    ' ==========================================================
    Private Sub ClearData()
        txtUserID.Clear()
        txtUserName.Clear()
        txtPassword.Clear()

        txtUserID.Enabled = False
        txtUserID.ReadOnly = False
        txtPassword.Enabled = False
        txtUserName.Enabled = False
        cmbRole.Enabled = False
        cmbRole.SelectedIndex = -1
        chkInActive.Enabled = False
        chkInActive.Checked = False
        chkBypassOneLogin.Enabled = False
        chkBypassOneLogin.Checked = False

        status = 0

        btnAdd.Enabled = True
        btnSave.Enabled = False
        btnEdit.Enabled = False
        btnCancel.Enabled = True

        _isFromOneLogin = False
        _oneLoginUsername = ""
    End Sub

    ' ==========================================================
    ' SEARCH
    ' ==========================================================
    Private Sub search()
        schfg.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        schfg.SearchDelay = 2
        schfg.Watermark = "Search : UserID/User Name"
        schfg.SetC1FlexGridSearchPanel(fg, schfg)
    End Sub

    ' ==========================================================
    ' SHOW DATA
    ' ==========================================================
    Private Sub ShowData()
        Try
            Dim dt As DataTable = Modul_RMP.DB.ExecuteQuery(
                StrConnRMPApp,
                "SELECT A.UserID, A.UserName, A.Password, " &
                "A.InActive, A.RoleID, B.RoleName, " &
                "ISNULL(A.AllowWithoutOneLogin,0) as AllowWithoutOneLogin " &
                "FROM dbo.MstUserLogin A " &
                "LEFT JOIN dbo.tblUtlRole B ON A.RoleID = B.RoleID " &
                "ORDER BY A.UserID"
            )

            With fg
                UI.HapusGrid(1, fg)

                Dim i As Integer = 1

                For Each row As DataRow In dt.Rows
                    .AddItem(i)

                    .Item(i, "UserID") = row("UserID")
                    .Item(i, "UserName") = row("UserName")
                    .Item(i, "Password") = row("Password")

                    .Item(i, "RoleName") = If(
                        IsDBNull(row("RoleName")),
                        "(Belum ada Role)",
                        row("RoleName").ToString()
                    )

                    .Item(i, "Status") = row("InActive")
                    .Item(i, "AllowWithoutOneLogin") = row("AllowWithoutOneLogin")

                    i += 1
                Next

                .AutoSizeCols()
            End With

        Catch ex As Exception
            MsgBoxCustom.Show(ex.Message,
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Error)
        End Try
    End Sub

    ' ==========================================================
    ' ADD
    ' ==========================================================
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ClearData()

        txtUserID.Enabled = True
        txtUserID.ReadOnly = False
        txtPassword.Enabled = True
        txtUserName.Enabled = True
        cmbRole.Enabled = True
        chkInActive.Enabled = True
        chkBypassOneLogin.Enabled = True

        btnAdd.Enabled = False
        btnSave.Enabled = True
        btnEdit.Enabled = False
        btnCancel.Enabled = True

        txtPassword.Text = RandomString(12)
        txtUserID.Focus()
    End Sub

    ' ==========================================================
    ' IMPORT ON ELOGIN
    ' ==========================================================
    Private Sub btnImportOL_Click(sender As Object, e As EventArgs) Handles btnImportOL.Click
        Using frm As New FrmUtlUserOneLoginRequest
            If frm.ShowDialog(Me) <> DialogResult.OK Then Return

            ClearData()

            txtUserID.Text = frm.SelectedUsername
            txtUserName.Text = frm.SelectedName

            txtUserID.Enabled = True
            txtUserID.ReadOnly = True
            txtPassword.Enabled = True
            txtUserName.Enabled = True
            cmbRole.Enabled = True
            chkInActive.Enabled = True
            chkBypassOneLogin.Enabled = True

            btnAdd.Enabled = False
            btnSave.Enabled = True
            btnEdit.Enabled = False
            btnCancel.Enabled = True

            _isFromOneLogin = True
            _oneLoginUsername = frm.SelectedUsername

            txtPassword.Text = RandomString(12)
            txtPassword.Focus()
        End Using
    End Sub

    ' ==========================================================
    ' DOUBLE CLICK GRID
    ' ==========================================================
    Private Sub fg_DoubleClick(sender As Object, e As EventArgs) Handles fg.DoubleClick
        If fg.Row < fg.Rows.Fixed OrElse fg.Row >= fg.Rows.Count Then Return
        If fg.Item(fg.Row, 2) Is Nothing Then Return

        Try
            txtUserID.Text = fg.Item(fg.Row, "UserID").ToString()
            txtUserName.Text = fg.Item(fg.Row, "UserName").ToString()

            txtPassword.Text = Modul_RMP.Func.DecryptText(
                fg.Item(fg.Row, "Password").ToString(),
                txtUserID.Text
            )

            cmbRole.Text = fg.Item(fg.Row, "RoleName").ToString()

            chkBypassOneLogin.Checked = fg.Item(fg.Row, "AllowWithoutOneLogin")
            chkInActive.Checked = fg.Item(fg.Row, "Status")

            LoadSelectedRole(txtUserID.Text)
            LoadSelectedOneLoginSetting(txtUserID.Text)

            txtUserID.Enabled = False
            txtUserID.ReadOnly = True
            txtPassword.Enabled = False
            txtUserName.Enabled = False
            cmbRole.Enabled = False
            chkInActive.Enabled = False
            chkBypassOneLogin.Enabled = False

            btnAdd.Enabled = True
            btnSave.Enabled = False
            btnEdit.Enabled = True
            btnCancel.Enabled = True

        Catch ex As Exception
            MsgBoxCustom.Show(ex.Message,
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Error)
        End Try
    End Sub

    Private Sub LoadSelectedRole(userID As String)
        Using conn As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnRMPApp)
            Using cmd As New SqlCommand(
                "SELECT RoleID FROM dbo.MstUserLogin WHERE UserID = @UserID",
                conn)

                cmd.Parameters.Add("@UserID", SqlDbType.VarChar).Value = userID

                Dim result As Object = cmd.ExecuteScalar()

                If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
                    cmbRole.SelectedValue = CInt(result)
                Else
                    cmbRole.SelectedIndex = -1
                End If
            End Using
        End Using
    End Sub

    Private Sub LoadSelectedOneLoginSetting(userID As String)
        Using conn As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnRMPApp)
            Using cmd As New SqlCommand(
                "SELECT AllowWithoutOneLogin FROM dbo.MstUserLogin WHERE UserID = @UserID",
                conn)

                cmd.Parameters.Add("@UserID", SqlDbType.VarChar).Value = userID
                Dim result As Object = cmd.ExecuteScalar()

                chkBypassOneLogin.Checked =
                    result IsNot Nothing AndAlso
                    result IsNot DBNull.Value AndAlso
                    Convert.ToBoolean(result)
            End Using
        End Using
    End Sub

    ' ==========================================================
    ' EDIT
    ' ==========================================================
    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If String.IsNullOrWhiteSpace(txtUserID.Text) Then Return

        txtUserID.Enabled = True
        txtUserID.ReadOnly = True
        txtPassword.Enabled = True
        txtUserName.Enabled = True
        cmbRole.Enabled = True
        chkInActive.Enabled = True
        chkBypassOneLogin.Enabled = True

        btnAdd.Enabled = False
        btnSave.Enabled = True
        btnEdit.Enabled = False
        btnCancel.Enabled = True
    End Sub

    ' ==========================================================
    ' CANCEL
    ' ==========================================================
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ClearData()
    End Sub

    ' ==========================================================
    ' SAVE BUTTON
    ' ==========================================================
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveData()
    End Sub

    ' ==========================================================
    ' SAVE DATA
    ' ==========================================================
    Private Sub SaveData()
        If String.IsNullOrWhiteSpace(txtUserID.Text) Then
            MsgBoxCustom.Show("User ID wajib diisi.",
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Warning)
            txtUserID.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtUserName.Text) Then
            MsgBoxCustom.Show("User Name wajib diisi.",
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Warning)
            txtUserName.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MsgBoxCustom.Show("Password wajib diisi.",
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Warning)
            txtPassword.Focus()
            Return
        End If

        If cmbRole.SelectedValue Is Nothing OrElse
           Not IsNumeric(cmbRole.SelectedValue) Then

            MsgBoxCustom.Show("Silakan pilih Role.",
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Warning)
            cmbRole.Focus()
            Return
        End If

        Me.Cursor = Cursors.WaitCursor

        Try
            status = If(chkInActive.Checked, 1, 0)

            Using koneksi As SqlConnection =
                Modul_RMP.DB.OpenConnection(StrConnRMPApp)

                Using trans As SqlTransaction = koneksi.BeginTransaction()
                    Try
                        SaveMstUser(
                            koneksi,
                            trans,
                            txtUserID.Text.Trim(),
                            txtUserName.Text.Trim(),
                            txtPassword.Text,
                            CInt(cmbRole.SelectedValue),
                            status,
                            chkBypassOneLogin.Checked,
                            ClsSession.UserName
                        )

                        trans.Commit()

                    Catch
                        trans.Rollback()
                        Throw
                    End Try
                End Using
            End Using

            If _isFromOneLogin AndAlso
               Not String.IsNullOrWhiteSpace(_oneLoginUsername) Then

                OneLoginService.ConfirmPassword(
                    _oneLoginUsername,
                    txtPassword.Text
                )
            End If

            MsgBoxCustom.Show("Save Completed !",
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Information)

            ClearData()
            ShowData()

        Catch ex As Exception
            MsgBoxCustom.Show(ex.Message,
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    ' ==========================================================
    ' SAVE USER - ROLE
    ' ==========================================================
    Private Sub SaveMstUser(Conn As SqlConnection,
                            Trans As SqlTransaction,
                            UserID As String,
                            UserName As String,
                            Password As String,
                            RoleID As Integer,
                            InActive As Integer,
                            AllowWithoutOneLogin As Boolean,
                            CreatedBy As String)

        Dim isNew As Boolean

        Using cmd As New SqlCommand(
            "SELECT COUNT(*) FROM dbo.MstUserLogin WHERE UserID = @UserID",
            Conn, Trans)

            cmd.Parameters.Add("@UserID", SqlDbType.VarChar).Value = UserID
            isNew = CInt(cmd.ExecuteScalar()) = 0
        End Using

        Dim sql As String

        If isNew Then
            sql =
                "INSERT INTO dbo.MstUserLogin " &
                "(UserID, UserName, Password, RoleID, InActive, AllowWithoutOneLogin, " &
                "CreatedBy, CreatedDate, Computer, ComputerDate) " &
                "VALUES " &
                "(@UserID, @UserName, @Password, @RoleID, @InActive, @AllowWithoutOneLogin, " &
                "@CreatedBy, GETDATE(), @Computer, GETDATE())"
        Else
            sql =
                "UPDATE dbo.MstUserLogin SET " &
                "UserName = @UserName, " &
                "Password = @Password, " &
                "RoleID = @RoleID, " &
                "InActive = @InActive, " &
                "AllowWithoutOneLogin = @AllowWithoutOneLogin, " &
                "UpdatedBy = @CreatedBy, " &
                "UpdatedDate = GETDATE(), " &
                "Computer = @Computer, " &
                "ComputerDate = GETDATE() " &
                "WHERE UserID = @UserID"
        End If

        Using cmd As New SqlCommand(sql, Conn, Trans)
            cmd.Parameters.Add("@UserID", SqlDbType.VarChar).Value = UserID
            cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = UserName

            cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value =
                Modul_RMP.Func.EncryptText(Password, UserID)

            cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = RoleID
            cmd.Parameters.Add("@InActive", SqlDbType.Bit).Value = InActive
            cmd.Parameters.Add("@AllowWithoutOneLogin", SqlDbType.Bit).Value = AllowWithoutOneLogin
            cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = CreatedBy
            cmd.Parameters.Add("@Computer", SqlDbType.VarChar).Value =
                Environment.MachineName

            cmd.ExecuteNonQuery()
        End Using
    End Sub

    ' ==========================================================
    ' STATUS
    ' ==========================================================
    Private Sub chkInActive_CheckedChanged(sender As Object, e As EventArgs) _
        Handles chkInActive.CheckedChanged

        status = If(chkInActive.Checked, 1, 0)
    End Sub

    ' ==========================================================
    ' SHOW / HIDE PASSWORD
    ' ==========================================================
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) _
        Handles PictureBox4.Click

        txtPassword.UseSystemPasswordChar =
            Not txtPassword.UseSystemPasswordChar
    End Sub

    ' ==========================================================
    ' ROLE AUTOCOMPLETE
    ' ==========================================================
    Private Sub cmbRole_KeyUp(sender As Object, e As KeyEventArgs) _
        Handles cmbRole.KeyUp

        UI.AutoCompleteCombo_KeyUp(cmbRole, e)
    End Sub

    Private Sub cmbRole_Validating(sender As Object, e As CancelEventArgs) _
        Handles cmbRole.Validating

        If Not cmbRole.Enabled OrElse cmbRole.Text.Trim() = "" Then Return

        If cmbRole.SelectedValue Is Nothing OrElse
           Not IsNumeric(cmbRole.SelectedValue) Then

            MsgBoxCustom.Show("Pilihan Role tidak ada.",
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Warning)

            cmbRole.SelectedIndex = -1
            cmbRole.Focus()
        End If
    End Sub

    ' ==========================================================
    ' USER NAME
    ' ==========================================================
    Private Sub txtUserName_Validating(sender As Object, e As CancelEventArgs) _
        Handles txtUserName.Validating

        txtUserName.Text = txtUserName.Text.Trim().ToUpperInvariant()
    End Sub

    ' ==========================================================
    ' RANDOM PASSWORD
    ' ==========================================================
    Public Function RandomString(length As Integer) As String
        Const chars As String =
            "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"

        Dim result As New System.Text.StringBuilder()
        Dim bytes(length - 1) As Byte

        Using rng As System.Security.Cryptography.RandomNumberGenerator =
            System.Security.Cryptography.RandomNumberGenerator.Create()

            rng.GetBytes(bytes)
        End Using

        For i As Integer = 0 To length - 1
            result.Append(chars(CInt(bytes(i)) Mod chars.Length))
        Next

        Return result.ToString()
    End Function

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Me.Cursor = Cursors.WaitCursor

        Try
            ClearData()
            ShowData()

        Catch ex As Exception
            MsgBoxCustom.Show(ex.Message,
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

End Class