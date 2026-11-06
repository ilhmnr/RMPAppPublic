Namespace My

    Partial Friend Class MyApplication

        ' Dipanggil saat aplikasi PERTAMA KALI dibuka (belum ada instance lain jalan)
        Private Sub MyApplication_Startup(sender As Object, e As ApplicationServices.StartupEventArgs) Handles Me.Startup
            If e.CommandLine.Count > 0 Then
                HandleLaunchArgument(e.CommandLine(0))
            End If
        End Sub

        ' Dipanggil saat aplikasi SUDAH JALAN, lalu user klik launch lagi dari OneLogin
        ' (Windows coba buka instance baru, tapi karena "Single Instance" aktif,
        '  argumennya malah dikirim ke instance yang sudah ada lewat event ini)
        Private Sub MyApplication_StartupNextInstance(sender As Object, e As ApplicationServices.StartupNextInstanceEventArgs) Handles Me.StartupNextInstance
            If e.CommandLine.Count > 0 Then
                HandleLaunchArgument(e.CommandLine(0))
            End If

            ' Bawa jendela utama ke depan
            If Me.MainForm IsNot Nothing Then
                Me.MainForm.WindowState = FormWindowState.Normal
                Me.MainForm.Activate()
            End If
        End Sub

        Private Sub HandleLaunchArgument(rawArgument As String)
            If Not rawArgument.StartsWith("onelogin-rmpapp://") Then Return

            ' Perintah LOGIN (seperti sebelumnya)
            Try
                Dim uri As New Uri(rawArgument)
                Dim query = System.Web.HttpUtility.ParseQueryString(uri.Query)
                Dim token As String = query("token")

                If String.IsNullOrEmpty(token) Then
                    MessageBox.Show("Token dari OneLogin tidak ditemukan.", "Login Gagal",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                OneLoginService.RedeemAndLoginAsync(token)

            Catch ex As Exception
                MessageBox.Show("Gagal memproses link dari OneLogin: " & ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

    End Class

End Namespace
