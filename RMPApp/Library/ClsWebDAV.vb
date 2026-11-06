Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Runtime.InteropServices
Imports System.Web.Script.Serialization
Imports DocumentFormat.OpenXml.Spreadsheet
Imports vb = Microsoft.VisualBasic
Public Class ClsWebDAV
    'Shared Function UploadFile(ByVal FileDestination As String, ByVal WebDavFolder As String, ByVal HeadFolder As String, SubFolder As String, ByVal FileName As String) As Boolean
    '    UploadFile = False
    '    Dim extention As String = "", FolderAkhir As String

    '    extention = Path.GetExtension(FileDestination)
    '    Call ClsWebDAV.CreateFolderWebDav(WebDavFolder, "")
    '    If HeadFolder <> "" Then Call ClsWebDAV.CreateFolderWebDav(WebDavFolder, Replace(HeadFolder, "/", "-")) 'Folder BulanTahun
    '    If SubFolder <> "" Then Call ClsWebDAV.CreateFolderWebDav(WebDavFolder & Replace(HeadFolder, "/", "-") & "/", Replace(SubFolder, "/", "-")) 'Folder BulanTahun / Folder Nomor Faktur
    '    FolderAkhir = WebDavFolder
    '    If HeadFolder <> "" Then FolderAkhir = WebDavFolder & Replace(HeadFolder, "/", "-") & "/"
    '    If SubFolder <> "" Then FolderAkhir = FolderAkhir & Replace(SubFolder, "/", "-")
    '    Dim cmd As String = "curl -u " & cls_Webdav.WebDavUser & ":" & cls_Webdav.WebDavPassword & " -T """ & FileDestination & """ """ & Replace(FolderAkhir & "/" & FileName, " ", "%20") & """"

    '    Try
    '        Shell("cmd /c """ & cmd & """", AppWinStyle.Hide, True)
    '        UploadFile = True
    '    Catch ex As Exception
    '        Call MsgBoxDialogCustom(cls_VarToast.Error_Save_Data & vbCrLf &
    '                                ex.Message & "(UploadFile)", PrjCulinary, MsgType.MsgError, MsgDialogType.MsgDialog)
    '    Finally

    '    End Try
    'End Function
    Private Shared Sub CreateFolderWebDav(ByVal WebDavFolder As String, ByVal NewFolder As String)
        Dim cmd As String = "curl -u " & cls_Webdav.WebDavUser & ":" & cls_Webdav.WebDavPassword & " -X MKCOL """ & Replace(WebDavFolder & NewFolder, " ", "%20") & """ -k"

        Try
            Shell("cmd /c """ & cmd & """", AppWinStyle.Hide, True)
        Catch ex As Exception
            'Call MsgBoxCustom(ex.Message, AT, "Error")
        End Try
    End Sub
    Private Shared Function CreateBatchFile(ByVal StrCommand As String) As Boolean
        CreateBatchFile = False
        Dim appPath As String = Application.StartupPath
        Dim batPath As String = appPath & "\Create-Folder.bat"
        Dim statusPath As String = appPath & "\Create-Folder.status"
        Dim strData As String

        ' Bersihkan status file lama, supaya tidak salah baca hasil dari run sebelumnya
        Try
            If Func.FileFolderExists(statusPath) Then FileSystem.Kill(statusPath)
        Catch
        End Try

        strData = "@echo off" & vbNewLine
        strData = strData & "echo." & vbNewLine
        strData = strData & "echo ======= MEMPERSIAPKAN CREDENTIAL NETWORK =============" & vbNewLine
        strData = strData & "Net use " & "" & Replace(vb.Left(cls_Webdav.WebDavBaseUrl, vb.Len(cls_Webdav.WebDavBaseUrl) - 1), "/", "\") & " " & """" & cls_Webdav.WebDavPassword & """" & " " & """" & "/USER:" & cls_Webdav.WebDavUser & """" & vbNewLine
        strData = strData & "echo Done" & vbNewLine
        strData = strData & "echo ======= MENJALANKAN PERINTAH COMMAND PROMPT =============" & vbNewLine
        strData = strData & StrCommand & vbNewLine
        strData = strData & "if %ERRORLEVEL% EQU 0 (" & vbNewLine
        strData = strData & " echo Done" & vbNewLine
        strData = strData & " echo 0 > """ & statusPath & """" & vbNewLine
        strData = strData & ") else (" & vbNewLine
        strData = strData & " echo Failed" & vbNewLine
        strData = strData & " echo 1 > """ & statusPath & """" & vbNewLine
        strData = strData & ")" & vbNewLine
        strData = strData & "echo ======= MENGHAPUS FILE .BAT =============" & vbNewLine
        strData = strData & "DEL """ & batPath & """ /F" & vbNewLine

        Try
            Dim file As System.IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(batPath, False)
            file.WriteLine(strData)
            file.Close()

            Shell(batPath, AppWinStyle.Hide, True) ' tetap tunggu sampai .bat selesai jalan

            If Func.FileFolderExists(statusPath) Then
                Dim result As String = System.IO.File.ReadAllText(statusPath).Trim()
                CreateBatchFile = (result = "0")
                Try
                    FileSystem.Kill(statusPath)
                Catch
                End Try
            Else
                ' Tidak ada file status sama sekali -> batch-nya sendiri gagal jalan
                CreateBatchFile = False
            End If
        Catch ex As Exception
            CreateBatchFile = False
        End Try
    End Function
    'Baru dari Payroll
    Shared Function UploadFileWebDav(ByVal fileDestination As String, ByVal UrlWebDav As String, ByVal FolderPrimaryWebDav As String, ByVal FileName As String) As Boolean
        UploadFileWebDav = False

        Select Case UCase(cls_VarProgram.ServerFile)

            Case "OFFLINE"
                Dim FinalPath As String
                FinalPath = Replace(vb.Left(UrlWebDav, vb.Len(UrlWebDav) - 1), "/", "\")

                If Func.FileFolderExists(FinalPath) = False Then
                    Dim strFolder As String = "MkDir " & " " & """" & FinalPath & """"
                    If Not CreateBatchFile(strFolder) Then
                        Call MsgBoxCustom.Show(cls_VarToast.Error_Save_Data & vbCrLf & "Gagal membuat folder utama.(UploadFile-OFFLINE)", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
                        Return UploadFileWebDav
                    End If
                End If

                If FolderPrimaryWebDav <> "" Then
                    FinalPath = FinalPath & "\" & FolderPrimaryWebDav
                    If Func.FileFolderExists(FinalPath) = False Then
                        Dim subFolderOffline As String = "MkDir " & " " & """" & FinalPath & "\" & Replace(FolderPrimaryWebDav, "/", "-") & """"
                        If Not CreateBatchFile(subFolderOffline) Then
                            Call MsgBoxCustom.Show(cls_VarToast.Error_Save_Data & vbCrLf & "Gagal membuat subfolder.(UploadFile-OFFLINE)", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
                            Return UploadFileWebDav
                        End If
                    End If
                End If

                Dim FileOffline As String = Replace(FinalPath & "\" & FileName, "/", "\")
                If Func.FileFolderExists(FileOffline) = False Then
                    Dim strCopyFile As String = "COPY " & "" & fileDestination & "" & " " & """" & FileOffline & """"
                    If Not CreateBatchFile(strCopyFile) Then
                        Call MsgBoxCustom.Show(cls_VarToast.Error_Save_Data & vbCrLf & "Gagal menyalin file.(UploadFile-OFFLINE)", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
                        Return UploadFileWebDav
                    End If
                End If

                UploadFileWebDav = True

            Case "ONLINE"
                Dim FolderAkhir As String
                Call ClsWebDAV.CreateFolderWebDav(UrlWebDav, "")
                If FolderPrimaryWebDav <> "" Then Call ClsWebDAV.CreateFolderWebDav(UrlWebDav, Replace(FolderPrimaryWebDav, "/", "-"))

                FolderAkhir = UrlWebDav
                If FolderPrimaryWebDav <> "" Then FolderAkhir = UrlWebDav & Replace(FolderPrimaryWebDav, "/", "-") & "/"

                ' -f = curl DIANGGAP GAGAL (exit code bukan 0) kalau server balas HTTP error (401/403/500/dll).
                Dim curlArgs As String = "-f -u " & cls_Webdav.WebDavUser & ":" & cls_Webdav.WebDavPassword &
                                          " -T """ & fileDestination & """ """ &
                                          Replace(FolderAkhir & "/" & FileName, " ", "%20") & """"

                Try
                    Dim psi As New ProcessStartInfo("curl.exe", curlArgs)
                    psi.UseShellExecute = False
                    psi.CreateNoWindow = True
                    psi.RedirectStandardError = True

                    Dim proc As Process = Process.Start(psi)
                    proc.WaitForExit()

                    If proc.ExitCode = 0 Then
                        UploadFileWebDav = True
                    Else
                        Dim errOutput As String = proc.StandardError.ReadToEnd()
                        Call MsgBoxCustom.Show(cls_VarToast.Error_Save_Data & vbCrLf &
                                                "curl exit code " & proc.ExitCode & ": " & errOutput & " (UploadFile-ONLINE)",
                                                MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
                    End If
                Catch ex As Exception
                    Call MsgBoxCustom.Show(cls_VarToast.Error_Save_Data & vbCrLf & ex.Message & " (UploadFile-ONLINE)", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
                End Try

            Case "BPI.API"
                ' BaseUrl/User/Password WebDAV TIDAK dikirim dari sini -- sudah otomatis
                ' diambil API dari SQL Server. Client cukup kirim file + folder tujuan.
                Try
                    Using client As New HttpClient()
                        client.Timeout = TimeSpan.FromMinutes(5)
                        client.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", TokenBPIAPI)

                        Using content As New MultipartFormDataContent()
                            Dim folderTujuan As String = UrlWebDav & FolderPrimaryWebDav
                            content.Add(New StringContent(folderTujuan), "FolderPath")

                            Dim fileBytes = System.IO.File.ReadAllBytes(fileDestination)
                            Dim fileContent As New ByteArrayContent(fileBytes)
                            fileContent.Headers.ContentType = New MediaTypeHeaderValue("application/octet-stream")
                            content.Add(fileContent, "file", FileName)

                            Dim response = client.PostAsync(UrlBPIAPI & "webdav/upload", content).GetAwaiter().GetResult()

                            If response.IsSuccessStatusCode Then
                                UploadFileWebDav = True
                            Else
                                Dim errorBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult()
                                'Call MsgBoxCustom.Show(cls_VarToast.Error_Save_Data & vbCrLf & errorBody, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
                            End If
                        End Using
                    End Using
                Catch ex As Exception
                    'Call MsgBoxCustom.Show(cls_VarToast.Error_Save_Data & vbCrLf & ex.Message & "(UploadFileWebDav-BPI.API)", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
                End Try

            Case Else
                'Call MsgBoxCustom.Show(cls_VarToast.Error_Save_Data & vbCrLf & "cls_VarProgram.ServerFile tidak dikenali: '" & cls_VarProgram.ServerFile & "'.(UploadFileWebDav)", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)

        End Select

        Return UploadFileWebDav
    End Function

    Shared Function DeleteFileWebDav(ByVal UrlWebDav As String, ByVal FolderPrimaryWebDav As String, ByVal FileName As String) As Boolean
        DeleteFileWebDav = False

        Select Case UCase(cls_VarProgram.ServerFile)

            Case "OFFLINE"
                Dim FinalPath As String
                FinalPath = Replace(vb.Left(UrlWebDav, vb.Len(UrlWebDav) - 1), "/", "\")

                If FolderPrimaryWebDav <> "" Then
                    FinalPath = FinalPath & "\" & FolderPrimaryWebDav
                End If

                Dim FileOffline As String = Replace(FinalPath & "\" & FileName, "/", "\")

                If Func.FileFolderExists(FileOffline) = False Then
                    ' Anggap sukses kalau memang filenya sudah tidak ada
                    DeleteFileWebDav = True
                    Return DeleteFileWebDav
                End If

                Dim strDeleteFile As String = "DEL " & " " & """" & FileOffline & """"
                If Not CreateBatchFile(strDeleteFile) Then
                    Call MsgBoxCustom.Show(cls_VarToast.Error_Save_Data & vbCrLf & "Gagal menghapus file.(DeleteFile-OFFLINE)", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
                    Return DeleteFileWebDav
                End If

                DeleteFileWebDav = True

            Case "ONLINE"
                Dim FolderAkhir As String
                FolderAkhir = UrlWebDav
                If FolderPrimaryWebDav <> "" Then FolderAkhir = UrlWebDav & Replace(FolderPrimaryWebDav, "/", "-") & "/"

                ' -f = curl DIANGGAP GAGAL (exit code bukan 0) kalau server balas HTTP error (401/403/500/dll).
                Dim curlArgs As String = "-f -u " & cls_Webdav.WebDavUser & ":" & cls_Webdav.WebDavPassword &
                                      " -X DELETE """ &
                                      Replace(FolderAkhir & "/" & FileName, " ", "%20") & """"

                Try
                    Dim psi As New ProcessStartInfo("curl.exe", curlArgs)
                    psi.UseShellExecute = False
                    psi.CreateNoWindow = True
                    psi.RedirectStandardError = True

                    Dim proc As Process = Process.Start(psi)
                    proc.WaitForExit()

                    If proc.ExitCode = 0 Then
                        DeleteFileWebDav = True
                    Else
                        Dim errOutput As String = proc.StandardError.ReadToEnd()
                        Call MsgBoxCustom.Show(cls_VarToast.Error_Save_Data & vbCrLf &
                                            "curl exit code " & proc.ExitCode & ": " & errOutput & " (DeleteFile-ONLINE)",
                                            MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
                    End If
                Catch ex As Exception
                    Call MsgBoxCustom.Show(cls_VarToast.Error_Save_Data & vbCrLf & ex.Message & " (DeleteFile-ONLINE)", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
                End Try

            Case "BPI.API"
                ' BaseUrl/User/Password WebDAV TIDAK dikirim dari sini -- sudah otomatis
                ' diambil API dari SQL Server. Client cukup kirim folder + nama file yang mau dihapus.
                Try
                    Using client As New HttpClient()
                        client.Timeout = TimeSpan.FromMinutes(5)
                        client.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", TokenBPIAPI)

                        Dim folderTujuan As String = cls_Webdav.WebDavGENSupplierFolder & FolderPrimaryWebDav
                        Dim requestUrl As String = UrlBPIAPI & "webdav/delete?folderPath=" & Uri.EscapeDataString(folderTujuan) &
                                                "&fileName=" & Uri.EscapeDataString(FileName)

                        Dim response = client.DeleteAsync(requestUrl).GetAwaiter().GetResult()

                        If response.IsSuccessStatusCode Then
                            DeleteFileWebDav = True
                        Else
                            Dim errorBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult()
                            Call MsgBoxCustom.Show(cls_VarToast.Error_Save_Data & vbCrLf & errorBody, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
                        End If
                    End Using
                Catch ex As Exception
                    Call MsgBoxCustom.Show(cls_VarToast.Error_Save_Data & vbCrLf & ex.Message & "(DeleteFileWebDav-BPI.API)", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
                End Try

            Case Else
                Call MsgBoxCustom.Show(cls_VarToast.Error_Save_Data & vbCrLf & "cls_VarProgram.ServerFile tidak dikenali: '" & cls_VarProgram.ServerFile & "'.(DeleteFileWebDav)", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)

        End Select

        Return DeleteFileWebDav
    End Function

    Shared Function DownloadFileWebDav(ByVal UrlWebDav As String, FolderLocal As String, FolderPrimaryWebDav As String, FileName As String, Optional OpenFileAutomatically As Boolean = False, Optional progress As IProgress(Of Integer) = Nothing) As Image
        Dim fileStream As FileStream = Nothing, img As Image = My.Resources.imgTransparent
        Dim sDestPath As String = "", FolderAkhir As String = ""

        'Setting Folder Local
        sDestPath = Application.StartupPath
        If FolderLocal <> "" Then
            sDestPath = Application.StartupPath & "\" & Replace(FolderLocal, "/", "\") & FolderPrimaryWebDav
            Call Func.IsCreateFolderExists(sDestPath)
        End If
        sDestPath = sDestPath & "\" & FileName

        Try
            'Cek jika file sudah ada 
            If Func.FileFolderExists(sDestPath) = True Then
                fileStream = New IO.FileStream(sDestPath, FileMode.Open)
                'jika file size dibawah 500 bytes dihapus
                If (fileStream.Length) < 500 Then
                    fileStream.Dispose()
                    FileSystem.Kill(sDestPath)
                Else
                    fileStream.Dispose()
                End If
            End If

            'proses download ulang file
            If Func.FileFolderExists(sDestPath) = False Then
                If UCase(cls_VarProgram.ServerFile) = "BPI.API" Then
                    FolderPrimaryWebDav = FolderLocal & FolderPrimaryWebDav
                    Call DownloadFileWebDavAPI(sDestPath, FolderPrimaryWebDav, FileName, progress)
                ElseIf UCase(cls_VarProgram.ServerFile) = "ONLINE" Then
                    FolderAkhir = UrlWebDav
                    If FolderPrimaryWebDav <> "" Then FolderAkhir = UrlWebDav & Replace(FolderPrimaryWebDav, "/", "-") & "/"
                    ClsWebDAV.DownloadFile(sDestPath, FolderAkhir, FileName, progress)
                End If

                fileStream = New IO.FileStream(sDestPath, FileMode.Open)
                'jika file size dibawah 500 bytes dihapus
                If (fileStream.Length) < 500 Then
                    fileStream.Dispose()
                    FileSystem.Kill(sDestPath)
                Else
                    fileStream.Dispose()
                End If
            End If

            If OpenFileAutomatically = True Then
                System.Diagnostics.Process.Start(sDestPath)
            Else
                Dim extension As String = Path.GetExtension(FileName).ToLower()
                Select Case extension
                    Case ".jpg", ".jpeg", ".png", ".bmp"
                        Dim stream As New FileStream(sDestPath, FileMode.Open)
                        img = Image.FromStream(stream)
                        stream.Close()
                End Select
            End If

        Catch ex As Exception
            MsgBoxCustom.Show("PERHATIAN..!" & vbCrLf &
                                "Ada kesalahan proses download file " & FileName & "." & vbCrLf &
                                "(Download File)", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
        End Try
        Return img
    End Function

    Shared Sub DownloadFileWebDavAPI(ByVal destinationPath As String, ByVal FolderPrimaryWebDav As String, ByVal FileName As String, Optional progress As IProgress(Of Integer) = Nothing)
        Using client As New HttpClient()
            client.Timeout = TimeSpan.FromMinutes(5)
            client.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", TokenBPIAPI)

            Dim url = UrlBPIAPI & "webdav/download?folderPath=" & Uri.EscapeDataString(FolderPrimaryWebDav) & "&fileName=" & Uri.EscapeDataString(FileName)

            Dim response = client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead).GetAwaiter().GetResult()

            If Not response.IsSuccessStatusCode Then
                Dim errorBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult()
                Throw New Exception("Gagal download dari API: " & errorBody)
            End If

            Dim totalBytes = If(response.Content.Headers.ContentLength, 0L)
            Dim buffer(81919) As Byte
            Dim totalRead As Long = 0

            Using remoteStream = response.Content.ReadAsStreamAsync().GetAwaiter().GetResult()
                Using fileStream As New FileStream(destinationPath, FileMode.Create, FileAccess.Write)
                    Dim bytesRead As Integer
                    Do
                        bytesRead = remoteStream.Read(buffer, 0, buffer.Length)
                        If bytesRead > 0 Then
                            fileStream.Write(buffer, 0, bytesRead)
                            totalRead += bytesRead
                            If progress IsNot Nothing AndAlso totalBytes > 0 Then
                                progress.Report(CInt(totalRead * 100 / totalBytes))
                            End If
                        End If
                    Loop While bytesRead > 0
                End Using
            End Using
        End Using
    End Sub

    Shared Function DownloadFile(ByVal FileDestination As String, ByVal WebDavFolderPath As String, ByVal FileName As String, Optional progress As IProgress(Of Integer) = Nothing) As Boolean
        DownloadFile = False
        Dim urlNoParaf As String = cls_Webdav.WebDavParaf & "noParaf.png"
        Dim tClient As WebClient = New WebClient
        tClient.UseDefaultCredentials = True
        tClient.Credentials = New System.Net.NetworkCredential(cls_Webdav.WebDavUser, cls_Webdav.WebDavPassword)

        Dim sourceUrl As String = If(Trim(FileName) <> "", WebDavFolderPath & "/" & FileName, urlNoParaf)

        Try
            If progress IsNot Nothing Then
                Dim tcs As New TaskCompletionSource(Of Boolean)

                AddHandler tClient.DownloadProgressChanged,
                Sub(s As Object, e As DownloadProgressChangedEventArgs)
                    progress.Report(e.ProgressPercentage)
                End Sub

                AddHandler tClient.DownloadFileCompleted,
                Sub(s As Object, e As System.ComponentModel.AsyncCompletedEventArgs)
                    If e.Error IsNot Nothing Then
                        tcs.TrySetException(e.Error)
                    ElseIf e.Cancelled Then
                        tcs.TrySetCanceled()
                    Else
                        tcs.TrySetResult(True)
                    End If
                End Sub

                tClient.DownloadFileAsync(New Uri(sourceUrl), FileDestination)
                tcs.Task.Wait() ' aman, karena fungsi ini dipanggil dari background thread (Task.Run)
            Else
                tClient.DownloadFile(sourceUrl, FileDestination)
            End If

            DownloadFile = True
        Catch ex As Exception
            Call MsgBoxCustom.Show("PERHATIAN..!" & vbCrLf &
                                "Ada kesalahan proses download file " & FileName & "." & vbCrLf &
                                "(Download File)", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
        Finally
            tClient.Dispose()
        End Try
    End Function
    Shared Sub LoadImageParafWebDav(ByVal pict As PictureBox, ByVal WebDavFolder As String, FileAttachment As String)
        If FileAttachment = "" Then FileAttachment = "noParaf.png"
        Call Func.IsCreateFolderExists(Application.StartupPath & "\Variable")
        Dim sDestPath As String = Application.StartupPath & "\Variable\" & Replace(FileAttachment, "/", "\")
        Dim fileStream As FileStream = Nothing
        Try
            If Func.FileFolderExists(sDestPath) = True Then
                fileStream = New IO.FileStream(sDestPath, FileMode.Open)
                If (fileStream.Length) < 500 Then
                    fileStream.Dispose()
                    FileSystem.Kill(sDestPath)
                Else
                    fileStream.Dispose()
                End If
            End If

            If Func.FileFolderExists(sDestPath) = False Then
                ClsWebDAV.DownloadFile(sDestPath, WebDavFolder, FileAttachment)
            End If


            If Func.FileFolderExists(sDestPath) = True Then
                Dim stream As New FileStream(sDestPath, FileMode.Open)
                Dim image As Image = Image.FromStream(stream)
                stream.Close()
                pict.Image = image
                pict.SizeMode = PictureBoxSizeMode.StretchImage
            Else
                pict.Image = My.Resources.imgTransparent
            End If
        Catch ex As Exception
            fileStream.Dispose()
        Finally

        End Try
    End Sub
    Shared Function LoadParafRDLC(ByVal WebDavFolder As String, FileAttachment As String) As Image
        If FileAttachment = "" Then FileAttachment = "noParaf.png"
        Call Func.IsCreateFolderExists(Application.StartupPath & "\Variable")
        Dim sDestPath As String = Application.StartupPath & "\Variable\" & Replace(FileAttachment, "/", "\")
        Dim fileStream As FileStream = Nothing
        LoadParafRDLC = My.Resources.imgTransparent

        Try
            If Func.FileFolderExists(sDestPath) = True Then
                fileStream = New IO.FileStream(sDestPath, FileMode.Open)
                If (fileStream.Length) < 500 Then
                    fileStream.Dispose()
                    FileSystem.Kill(sDestPath)
                Else
                    fileStream.Dispose()
                End If
            End If

            If Func.FileFolderExists(sDestPath) = False Then
                ClsWebDAV.DownloadFile(sDestPath, WebDavFolder, FileAttachment)
            End If

            If Func.FileFolderExists(sDestPath) = True Then
                Dim stream As New FileStream(sDestPath, FileMode.Open)
                LoadParafRDLC = New Bitmap(Image.FromStream(stream))
                stream.Close()
            End If
            Return LoadParafRDLC
        Catch ex As Exception
            fileStream.Dispose()
        Finally

        End Try
    End Function
    Shared Function LoadImageToRDLC(ByVal WebDavFolder As String, ByVal FolderModul As String, FolderPrimary As String, FolderSecond As String,
                                   ByVal FileAttachment As String)


        Dim fileStream As FileStream = Nothing
        Dim sDestPath As String
        LoadImageToRDLC = My.Resources.imgTransparent

        If FolderModul <> "" Then
            sDestPath = Application.StartupPath & "\" & FolderModul
            Call Func.IsCreateFolderExists(sDestPath)
        End If
        If FolderPrimary <> "" Then
            sDestPath = sDestPath & "\" & Replace(FolderPrimary, "/", "-")
            Call Func.IsCreateFolderExists(sDestPath)
        End If
        If FolderSecond <> "" Then
            sDestPath = sDestPath & "\" & Replace(FolderSecond, "/", "-")
            Call Func.IsCreateFolderExists(sDestPath)
        End If
        If FileAttachment = "" Then
            sDestPath = sDestPath & "\" & "noParaf.png"
        Else
            sDestPath = sDestPath & "\" & Replace(FileAttachment, "/", "\")
        End If



        Try
            'Cek jika file sudah ada, apakah sedang dibuka atau tidak
            If Func.FileFolderExists(sDestPath) = True Then
                fileStream = New IO.FileStream(sDestPath, FileMode.Open)
                'jika file size dibawah 500 bytes dihapus
                If (fileStream.Length) < 500 Then
                    fileStream.Dispose()
                    FileSystem.Kill(sDestPath)
                Else
                    fileStream.Dispose()
                End If
            End If

            If Func.FileFolderExists(sDestPath) = False Then
                If FileAttachment = "" Then
                    ClsWebDAV.DownloadFile(sDestPath, cls_Webdav.WebDavParaf, "noParaf.png")
                Else
                    ClsWebDAV.DownloadFile(sDestPath, WebDavFolder, FileAttachment)
                End If
            End If

            'proses download ulang file
            If Func.FileFolderExists(sDestPath) = True Then
                Dim stream As New FileStream(sDestPath, FileMode.Open)
                LoadImageToRDLC = New Bitmap(Image.FromStream(stream))
                stream.Close()
            End If

            Return LoadImageToRDLC
        Catch ex As Exception
            Call MsgBox(ex.Message)
        End Try
    End Function
    Class WebDavVariable
        Public WebDavBaseUrl As String
        Public WebDavProfil, WebDavInfoUpdate, WebDavParaf, WebDavFormatExcel, WebDavManualBook As String
        Public WebDavUser, WebDavPassword As String
        Public WebDavINVitem, WebDavINVSupplierItemPrice As String
        Public WebDavGENSupplier, WebDavGENSupplierFolder As String
        Public WebDavINVNPBB, WebDavINVBTB, WebDavINVBPB, WebDavINVPPB, WebDavINVBPG, WebDavINVRejectItem, WebDavINVStockOpname, WebDavINVRepackItem As String
        Public WebDavSLSSalesOrder, WebDavSLSDeliveryOrder As String
        Public WebDavPRDBOM, WebDavPRDPricelist, WebDavPRDWorkOrder, WebDavPRDProduction As String
        Public WebDavCashbank, WebDavAPAR, WebDavKasbon As String
        Public WebDavGLPayable, WebDavGLPayableNote As String
        Public WebDavGLReceivable, WebDavGLReceivableNote As String
        Public WebDavGLCustomerNote As String
        Public WebDavGLGeneralJournal, WebDavGLProductionClosing As String
        Public WebDavHREmployee As String
        Public WebDavFAAsset As String
        Public WebDavRMPShip, WebDavRMPShipFolder, WebDavRMPShipPelangsir, WebDavRMPShipPelangsirFolder As String
        Public WebDavRMPInvItem, WebDavRMPInvItemFolder As String
    End Class

    Shared Sub SetVariableWebDAV()
        Dim sql As String
        sql = "SELECT * FROM tblAppMstVariableWebDAV ORDER BY CAST(VarID AS INTEGER) ASC"
        Try
            Dim dtTable As DataTable = DB.ExecuteQuery(StrConnDBPancang, sql)
            If dtTable.Rows.Count > 0 Then
                For Each dr As DataRow In dtTable.Rows
                    Select Case dr!VarID
                        Case 1 : cls_Webdav.WebDavUser = dr!VarValue
                        Case 2 : cls_Webdav.WebDavPassword = dr!VarValue
                        Case 3 : cls_Webdav.WebDavParaf = cls_VarProgram.BaseUrlWebDav & dr!VarValue
                        Case 6
                            cls_Webdav.WebDavGENSupplier = cls_VarProgram.BaseUrlWebDav & dr!VarValue
                            cls_Webdav.WebDavGENSupplierFolder = dr!VarValue
                        Case 7 : cls_Webdav.WebDavFormatExcel = cls_VarProgram.BaseUrlWebDav & dr!VarValue
                        Case 8 : cls_Webdav.WebDavInfoUpdate = cls_VarProgram.BaseUrlWebDav & dr!VarValue
                        Case 9 : cls_Webdav.WebDavProfil = cls_VarProgram.BaseUrlWebDav & dr!VarValue
                        Case 9 : cls_Webdav.WebDavManualBook = cls_VarProgram.BaseUrlWebDav & dr!VarValue

                        Case 10 : cls_Webdav.WebDavINVitem = cls_VarProgram.BaseUrlWebDav & dr!VarValue
                        Case 11 : cls_Webdav.WebDavINVNPBB = cls_VarProgram.BaseUrlWebDav & dr!VarValue
                        Case 12 : cls_Webdav.WebDavINVBTB = cls_VarProgram.BaseUrlWebDav & dr!VarValue
                        Case 13 : cls_Webdav.WebDavINVBPB = cls_VarProgram.BaseUrlWebDav & dr!VarValue
                        Case 14 : cls_Webdav.WebDavINVBPG = cls_VarProgram.BaseUrlWebDav & dr!VarValue
                        Case 15 : cls_Webdav.WebDavINVRejectItem = cls_VarProgram.BaseUrlWebDav & dr!VarValue
                        Case 16 : cls_Webdav.WebDavINVStockOpname = cls_VarProgram.BaseUrlWebDav & dr!VarValue
                        Case 17 : cls_Webdav.WebDavINVRepackItem = cls_VarProgram.BaseUrlWebDav & dr!VarValue
                        Case 18 : cls_Webdav.WebDavINVSupplierItemPrice = cls_VarProgram.BaseUrlWebDav & dr!VarValue



                        Case 21 : cls_Webdav.WebDavPRDBOM = cls_VarProgram.BaseUrlWebDav & dr!VarValue
                        Case 22 : cls_Webdav.WebDavPRDWorkOrder = cls_VarProgram.BaseUrlWebDav & dr!VarValue
                        Case 23 : cls_Webdav.WebDavPRDProduction = cls_VarProgram.BaseUrlWebDav & dr!VarValue
                        Case 24 : cls_Webdav.WebDavPRDPricelist = cls_VarProgram.BaseUrlWebDav & dr!VarValue

                        Case 31 : cls_Webdav.WebDavCashbank = cls_VarProgram.BaseUrlWebDav & dr!VarValue
                        Case 32 : cls_Webdav.WebDavKasbon = cls_VarProgram.BaseUrlWebDav & dr!VarValue
                        Case 33 : cls_Webdav.WebDavAPAR = cls_VarProgram.BaseUrlWebDav & dr!VarValue

                        Case 41 : cls_Webdav.WebDavGLPayable = cls_VarProgram.BaseUrlWebDav & dr!VarValue
                        'Case 42 : cls_Webdav.WebDavGLPayableRecognation = cls_VarProgram.BaseUrlWebDav & dr!VarValue
                        Case 43 : cls_Webdav.WebDavGLPayableNote = cls_VarProgram.BaseUrlWebDav & dr!VarValue
                        'Case 44 : cls_Webdav.WebDavGLPayableVoucher = cls_VarProgram.BaseUrlWebDav & dr!VarValue 

                        Case 50 : cls_Webdav.WebDavGLGeneralJournal = cls_VarProgram.BaseUrlWebDav & dr!VarValue
                        Case 51 : cls_Webdav.WebDavGLReceivable = cls_VarProgram.BaseUrlWebDav & dr!VarValue
                        Case 52 : cls_Webdav.WebDavGLCustomerNote = cls_VarProgram.BaseUrlWebDav & dr!VarValue
                        'Case 53 : cls_Webdav.WebDavGLReceivableVoucher = cls_VarProgram.BaseUrlWebDav & dr!VarValue


                        Case 60 : cls_Webdav.WebDavHREmployee = cls_VarProgram.BaseUrlWebDav & dr!VarValue


                        Case 70 : cls_Webdav.WebDavSLSSalesOrder = cls_VarProgram.BaseUrlWebDav & dr!VarValue
                        Case 71 : cls_Webdav.WebDavSLSDeliveryOrder = cls_VarProgram.BaseUrlWebDav & dr!VarValue

                        Case 81 : cls_Webdav.WebDavFAAsset = cls_VarProgram.BaseUrlWebDav & dr!VarValue

                        Case 100 : cls_Webdav.WebDavManualBook = cls_VarProgram.BaseUrlWebDav & dr!VarValue
                        Case 101
                            cls_Webdav.WebDavRMPShip = cls_VarProgram.BaseUrlWebDav & dr!VarValue
                            cls_Webdav.WebDavRMPShipFolder = dr!VarValue
                        Case 102
                            cls_Webdav.WebDavRMPShipPelangsir = cls_VarProgram.BaseUrlWebDav & dr!VarValue
                            cls_Webdav.WebDavRMPShipPelangsirFolder = dr!VarValue
                        Case 103
                            cls_Webdav.WebDavRMPInvItem = cls_VarProgram.BaseUrlWebDav & dr!VarValue
                            cls_Webdav.WebDavRMPInvItemFolder = dr!VarValue
                    End Select
                Next
            End If
            cls_Webdav.WebDavBaseUrl = cls_VarProgram.BaseUrlWebDav
        Catch ex As Exception
            Call MsgBoxCustom.Show(cls_VarToast.Error_Load_Data & vbCrLf &
                                    ex.Message & "(SetVariableWebDAV)", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
        End Try
    End Sub
End Class
