Imports System.Data.SqlClient
Imports System.Net
Imports System.Net.Http
Imports System.Net.NetworkInformation
Imports System.Net.Sockets
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Public Class FrmLogin
    Public LoginSukses As Boolean
    Private Const CS_DropSHadow As Integer = &H20000
    Const WM_NCHITTEST As Integer = &H84
    Const HTCLIENT As Integer = &H1
    Const HTCAPTION As Integer = &H2

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = CS_DropSHadow
            Return cp
        End Get
    End Property

    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = AT & " | Ver " & My.Application.Info.Version.Major.ToString() & "." & My.Application.Info.Version.Minor.ToString & "." _
                                                            & My.Application.Info.Version.Build.ToString & "." & My.Application.Info.Version.Revision.ToString

        Call ClsVariable.SaveVariableProgram()
        Call ClsWebDAV.SetVariableWebDAV()

        TryAutoLoginFromSession()
    End Sub

    Public Sub TryAutoLoginFromSession()
        ' PENTING: sebelumnya ada "AndAlso Not String.IsNullOrEmpty(...PendingPassword)"
        ' di sini -- itu DIHAPUS. Sekarang cukup username saja yang wajib ada,
        ' karena mode Token Redirect memang tidak pernah kirim password.
        If Not String.IsNullOrEmpty(OneLoginService.OneLoginPendingUsername) Then

            Dim u As String = OneLoginService.OneLoginPendingUsername
            Dim p As String = OneLoginService.OneLoginPendingPassword ' boleh "" sekarang

            ' Kosongkan DULU sebelum Login() -- supaya kalau method ini kepanggil
            ' dua kali (dari FrmLogin_Load DAN dari Invoke langsung), yang kedua
            ' tidak login ulang pakai kredensial yang sama.
            OneLoginService.OneLoginPendingUsername = ""
            OneLoginService.OneLoginPendingPassword = ""

            txtUserName.Text = u
            txtPassword.Text = p
            Login()

            ' ---- Paksa jendela utama ke depan ----
            Try
                If FrmMain IsNot Nothing AndAlso FrmMain.Visible Then
                    FrmMain.WindowState = FormWindowState.Maximized
                    FrmMain.TopMost = True
                    FrmMain.Activate()
                    FrmMain.TopMost = False
                End If
            Catch ex As Exception
                ' Abaikan -- ini cuma bonus UX (bawa ke depan), bukan hal fatal
                ' kalau gagal. Login-nya sendiri tetap sudah berhasil.
            End Try
        End If
    End Sub

    Public Sub GetMenues(ByVal Current As ToolStripItem, ByRef menues As List(Of ToolStripItem))
        menues.Add(Current)
        If TypeOf (Current) Is ToolStripMenuItem Then
            For Each menu As ToolStripItem In DirectCast(Current, ToolStripMenuItem).DropDownItems
                GetMenues(menu, menues)
            Next
        End If
    End Sub
    Private Sub txtUserName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUserName.KeyPress
        If e.KeyChar = Chr(13) Then
            txtPassword.Focus()
        End If
    End Sub
    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = Chr(13) Then
            btnlogin.PerformClick()
        End If
    End Sub
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        If txtPassword.UseSystemPasswordChar = True Then
            txtPassword.UseSystemPasswordChar = False
        Else
            txtPassword.UseSystemPasswordChar = True
        End If
    End Sub
    Private Sub txtUserName_TextChanged(sender As Object, e As EventArgs) Handles txtUserName.TextChanged
        If txtUserName.Text = "Username" Then
            txtUserName.ForeColor = Color.DarkGray
        Else
            txtUserName.ForeColor = Color.Black
        End If
    End Sub
    Private Sub txtUserName_GotFocus(sender As Object, e As EventArgs) Handles txtUserName.GotFocus
        If txtUserName.Text = "Username" Then
            txtUserName.Text = ""
        End If
    End Sub
    Private Sub txtUserName_LostFocus(sender As Object, e As EventArgs) Handles txtUserName.LostFocus
        If txtUserName.Text = "" Then
            txtUserName.Text = "Username"
        End If
    End Sub
    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        If txtPassword.Text = "Password" Then
            txtPassword.ForeColor = Color.DarkGray
            txtPassword.UseSystemPasswordChar = False
        Else
            txtPassword.ForeColor = Color.Black
            txtPassword.UseSystemPasswordChar = True
        End If
    End Sub
    Private Sub txtPassword_LostFocus(sender As Object, e As EventArgs) Handles txtPassword.LostFocus
        If txtPassword.Text = "" Then
            txtPassword.Text = "Password"
            txtPassword.UseSystemPasswordChar = True
        End If
    End Sub
    Private Sub txtPassword_GotFocus(sender As Object, e As EventArgs) Handles txtPassword.GotFocus
        If txtPassword.Text = "Password" Then
            txtPassword.Text = ""
        End If
    End Sub
    Private Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        Dim UserPass As String

        If DB.ExecuteScalarValue(Of String)(StrConnRMPApp, "SELECT UserID FROM dbo.MstUserLogin WHERE UserID = '" & txtUserName.Text & "' AND AllowWithoutOneLogin = 1") IsNot Nothing Then
            Login()
        Else
            UserPass = Clipboard.GetText()
            If Trim(Mid(UserPass, 1, 30)) = "OneLogin" Then
                Login()
            Else
                CheckFreeLogin()
            End If
        End If
    End Sub 'OneLogin                      zamri                         singleaja                

    Private Function DecryptText(strText As String, ByVal Kunci As String)
        Dim i As Integer, c As Integer, strBuff As String = ""

#If Not CASE_SENSITIVE_PASSWORD Then
        Kunci = UCase$(Kunci)
#End If

        If Len(Kunci) Then
            For i = 1 To Len(strText)
                c = Asc(Mid$(strText, i, 1))
                c = c - Asc(Mid$(Kunci, (i Mod Len(Kunci)) + 1, 1))
                strBuff = strBuff & Chr(c And &HFF)
            Next i
        Else
            strBuff = strText
        End If
        DecryptText = strBuff
    End Function


    ' ---- CONTOH LENGKAP Sub Login() setelah diubah ----
    Private Async Sub Login()
        Dim DT As DataTable
        Dim User As String
        Dim Pass As String

        Dim wasTrustedSso As Boolean = OneLoginService.IsTrustedSsoLogin
        OneLoginService.IsTrustedSsoLogin = False

        Try
            Try
                Dim macAddress As String = NetworkInfo.GetMACAddress()
                Dim ipAddress As String = NetworkInfo.GetLocalIPAddress()
            Catch ex As Exception
                Dim macAddress As String = "00:00:00:00:00:00"
                Dim ipAddress As String = "192.168.00.00"
            End Try

            User = Trim(UCase(txtUserName.Text))

            If User = "" Then
                MsgBoxCustom.Show("Maaf .. UserID Belum Diisi.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
            End If

            DT = Modul_RMP.DB.ExecuteQuery(
            StrConnRMPApp,
            "SELECT * FROM vwUserGroup WHERE UserID='" & User.Replace("'", "''") & "' AND InActive = 0"
        )

            If DT.Rows.Count = 0 Then
                MsgBoxCustom.Show("Maaf .. UserID ( " & User & ") Belum Terdaftar.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
                SendKeys.Send("{Home}{End}")
                txtUserName.Focus()
                Exit Sub
            End If

            Pass = Modul_RMP.Func.DecryptText(
            DT.Rows(0).Item("Password").ToString(), User
        )

            If Not (wasTrustedSso OrElse
                UCase(Pass) = UCase(txtPassword.Text)) Then

                MsgBoxCustom.Show("Maaf .. Password Anda Salah !", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
                SendKeys.Send("{Home}{End}")
                txtPassword.Focus()
                txtPassword.Clear()
                Exit Sub
            End If

            ' Simpan data user login
            ClsSession.UserID = DT.Rows(0).Item("UserID").ToString()
            ClsSession.UserName = DT.Rows(0).Item("UserName").ToString()
            ClsSession.RoleID = If(
            IsDBNull(DT.Rows(0).Item("RoleID")),
            0,
            Convert.ToInt32(DT.Rows(0).Item("RoleID"))
            )
            ClsSession.RoleName = If(
                IsDBNull(DT.Rows(0).Item("RoleName")),
                "",
                DT.Rows(0).Item("RoleName").ToString()
            )
            ClsSession.ComputerName = Environment.MachineName

            With FrmMain
                .Show()
                .lblUserInfo.Text = "Nama: " & ClsSession.UserName &
                "  |  Role: " & ClsSession.RoleName &
                "  |  PC: " & Environment.MachineName &
                "  |  IP: " & NetworkInfo.GetLocalIPAddress() &
                "  |  Versi: " & My.Application.Info.Version.ToString()
                .VisibleMenuAkses()
            End With

            Me.Close()
            FrmMain.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Class NetworkInfo
        Public Shared Function GetLocalIPAddress() As String
            Dim host As String = Dns.GetHostName() ' Mendapatkan nama host (komputer)
            Dim ipAddresses As IPAddress() = Dns.GetHostAddresses(host) ' Mendapatkan semua alamat IP dari host

            For Each ip In ipAddresses
                ' Memeriksa apakah alamat IP menggunakan AddressFamily InterNetwork (IPv4)
                If ip.AddressFamily = AddressFamily.InterNetwork Then
                    Return ip.ToString() ' Mengembalikan IP address
                End If
            Next

            Throw New Exception("No network adapters with an IPv4 address in the system!")
        End Function

        Public Shared Function GetMACAddress() As String
            Dim macAddress As String = String.Empty

            ' Mengambil semua interface jaringan yang aktif
            Dim networkInterfaces As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()

            For Each netInterface As NetworkInterface In networkInterfaces
                ' Memastikan interface yang aktif dan menggunakan tipe Ethernet
                If netInterface.NetworkInterfaceType = NetworkInterfaceType.Ethernet AndAlso netInterface.OperationalStatus = OperationalStatus.Up Then
                    ' Mengambil alamat fisik (MAC address)
                    Dim physicalAddress As PhysicalAddress = netInterface.GetPhysicalAddress()
                    macAddress = String.Join(":", physicalAddress.GetAddressBytes().Select(Function(b) b.ToString("X2")))
                    Exit For
                End If
            Next

            If String.IsNullOrEmpty(macAddress) Then
                Throw New Exception("No active Ethernet network adapters found!")
            End If

            Return macAddress
        End Function
    End Class

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        End
    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint
        Modul_RMP.Draw.GradiantHorizontal(Me, e, Color.PaleGreen, Color.DeepSkyBlue)
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Modul_RMP.Draw.GradiantForwad(Me, e, Color.PaleGreen, Color.DeepSkyBlue)
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
        Modul_RMP.Draw.GradiantForwad(Me, e, Color.DeepSkyBlue, Color.PaleGreen)
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint
        Modul_RMP.Draw.GradiantForwad(Me, e, Color.DeepSkyBlue, Color.PaleGreen)
    End Sub

    Private Sub FrmLogin_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Dim UserPass As String

        UserPass = Clipboard.GetText()
        If Trim(Mid(UserPass, 1, 30)) = "OneLogin" Then
            txtUserName.Text = Trim(Mid(UserPass, 31, 30)) 'Sesuaikan dengan Program anda
            txtPassword.Text = Trim(Mid(UserPass, 61, 30)) 'Sesuaikan dengan Program anda
            btnlogin_Click(sender, New System.EventArgs()) 'Sesuaikan dengan Program anda
        End If
    End Sub

    Sub CheckFreeLogin()
        Try
            Dim SQL As String
            SQL = "SELECT FreeLogin FROM RSUPKomputer..tbl_OL_MstProgram " &
                  "WHERE NamaEXE = 'RMPApp' AND FreeLogin = 1 "

            Using koneksi As New SqlCommand(SQL, DB.OpenConnection(StrConnOneLogin))
                Using DR = koneksi.ExecuteReader()
                    If DR.HasRows Then
                        Login()
                    Else
                        MsgBoxCustom.Show("Program hanya bisa dibuka melalui OneLogin, silahkan login kembali melalui OneLogin!", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
                        End
                    End If
                    DR.Close()
                End Using
            End Using
            DB.CloseConnection()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
