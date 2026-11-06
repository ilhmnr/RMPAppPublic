Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Linq
Imports System.Text.RegularExpressions

Public Module OneLoginService

    Public OneLoginPendingUsername As String = ""
    Public OneLoginPendingPassword As String = ""
    Public IsTrustedSsoLogin As Boolean = False

    Public Const ONELOGIN_BASE_URL As String = "http://192.168.12.35:8000"
    Private Const ONELOGIN_API_URL As String = ONELOGIN_BASE_URL & "/api/desktop/redeem"
    Public Const APPLICATION_ID As Integer = 5   ' ⚠️ ID RMPApp di OneLogin

    Public ReadOnly CLIENT_SECRET As String =
        ClsSecretObfuscation.Decode("4sHF8+DOuOHIzd3zw9D90b/t+Ojw29jz0eXi8869yM2+7O7m88zD/A==")

    ' ══════════════════════════════════════════════════════════════════════
    '  LOGIN SSO — tidak berubah
    ' ══════════════════════════════════════════════════════════════════════
    Public Async Sub RedeemAndLoginAsync(token As String)
        Try
            Dim result = Await Task.Run(Function() CallRedeemApi(token))

            If Not result.Success Then
                MessageBox.Show(If(result.Message, "Gagal login otomatis dari OneLogin."),
                                "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            IsTrustedSsoLogin = String.IsNullOrEmpty(result.Password)
            PerformInternalLogin(result.Username, result.Password)

        Catch ex As Exception
            MessageBox.Show("Tidak bisa terhubung ke server OneLogin: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function CallRedeemApi(token As String) _
        As (Success As Boolean, Username As String, Password As String, Message As String)

        Dim myVersion As String = My.Application.Info.Version.ToString()
        Dim requestJson As String =
            "{""token"":""" & JsonEscape(token) &
            """,""client_secret"":""" & JsonEscape(CLIENT_SECRET) &
            """,""app_version"":""" & JsonEscape(myVersion) & """}"

        Dim request As HttpWebRequest = CType(WebRequest.Create(ONELOGIN_API_URL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"
        request.Accept = "application/json"
        request.Timeout = 15000

        Dim bytes = Encoding.UTF8.GetBytes(requestJson)
        request.ContentLength = bytes.Length
        Using s As Stream = request.GetRequestStream()
            s.Write(bytes, 0, bytes.Length)
        End Using

        Dim responseText As String
        Dim statusCode As HttpStatusCode

        Try
            Using response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
                statusCode = response.StatusCode
                Using reader As New StreamReader(response.GetResponseStream(), Encoding.UTF8)
                    responseText = reader.ReadToEnd()
                End Using
            End Using
        Catch webEx As WebException When webEx.Response IsNot Nothing
            Using errResponse As HttpWebResponse = CType(webEx.Response, HttpWebResponse)
                statusCode = errResponse.StatusCode
                Using reader As New StreamReader(errResponse.GetResponseStream(), Encoding.UTF8)
                    responseText = reader.ReadToEnd()
                End Using
            End Using
        End Try

        If statusCode <> HttpStatusCode.OK Then
            Return (False, Nothing, Nothing, ExtractJsonValue(responseText, "message"))
        End If

        Dim username As String = ExtractJsonValue(responseText, "username")
        Dim password As String = ExtractJsonValue(responseText, "password")

        If String.IsNullOrEmpty(username) Then
            Return (False, Nothing, Nothing, "Response dari OneLogin tidak lengkap (username kosong).")
        End If

        Return (True, username, password, Nothing)
    End Function

    Private Sub PerformInternalLogin(username As String, password As String)
        OneLoginPendingUsername = username
        OneLoginPendingPassword = password

        Dim loginForm = My.Application.OpenForms.OfType(Of FrmLogin)().FirstOrDefault()
        If loginForm IsNot Nothing Then
            loginForm.Invoke(Sub() loginForm.TryAutoLoginFromSession())
        End If
    End Sub

    ' ══════════════════════════════════════════════════════════════════════
    '  CONFIRM PASSWORD — dipanggil FrmUtlUser setelah buat akun dari OneLogin
    ' ══════════════════════════════════════════════════════════════════════
    ''' <summary>
    ''' Konfirmasi ke OneLogin bahwa akun user sudah dibuat di RMPApp.
    ''' Kirim password plain text supaya OneLogin bisa auto-login nantinya.
    ''' Dipanggil dari FrmUtlUser.SaveData() kalau _isFromOneLogin = True.
    ''' </summary>
    Public Sub ConfirmPassword(username As String, password As String)
        Try
            Dim body As String =
                "{""application_id"":" & APPLICATION_ID &
                ",""client_secret"":""" & JsonEscape(CLIENT_SECRET) &
                """,""username"":""" & JsonEscape(username) &
                """,""password"":""" & JsonEscape(password) & """}"

            Dim req As HttpWebRequest = CType(
                WebRequest.Create(ONELOGIN_BASE_URL & "/api/apps/confirm-password"),
                HttpWebRequest)
            req.Method = "POST"
            req.ContentType = "application/json"
            req.Accept = "application/json"
            req.Timeout = 10000

            Dim bytes = Encoding.UTF8.GetBytes(body)
            req.ContentLength = bytes.Length
            Using s As Stream = req.GetRequestStream()
                s.Write(bytes, 0, bytes.Length)
            End Using

            Using res As HttpWebResponse = CType(req.GetResponse(), HttpWebResponse)
                ' Sukses — tidak perlu baca response body
            End Using

        Catch
            ' Tidak fatal — akun RMPApp sudah tersimpan di database.
            ' Konfirmasi ke OneLogin bisa dilakukan ulang lewat menu reset-password di admin.
        End Try
    End Sub

    ' ══════════════════════════════════════════════════════════════════════
    '  JSON HELPERS
    ' ══════════════════════════════════════════════════════════════════════
    Private Function ExtractJsonValue(json As String, key As String) As String
        If String.IsNullOrEmpty(json) Then Return Nothing
        Dim m = Regex.Match(json, """" & Regex.Escape(key) & """\s*:\s*""((?:[^""\\]|\\.)*)""")
        If Not m.Success Then Return Nothing
        Return m.Groups(1).Value.Replace("\""", """").Replace("\\", "\")
    End Function

    Private Function JsonEscape(value As String) As String
        If value Is Nothing Then Return ""
        Return value.Replace("\", "\\").Replace("""", "\""")
    End Function

End Module