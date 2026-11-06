Imports System.IO
Imports System.IO.Compression
Imports System.Diagnostics
Imports System.Text

' ============================================================
' ClsAutoUpdater.vb
'
' Modul buat cek & pasang update aplikasi dari file .zip di folder
' jaringan bersama (network share). Cara pakainya, panggil dari tombol
' "Cek Update" di aplikasi Anda:
'
'   ClsAutoUpdater.CheckForUpdate(
'       sharedZipPath:="\\server\folder\RMPApp\RMPApp_Latest.zip",
'       installDir:="C:\Users\Public\OneLogin\RMPApp",
'       exeFileName:="RMPApp.exe"
'   )
'
' ⚠️ PENTING -- di project Anda, tambahkan referensi assembly ini dulu
' (klik kanan project -> Add Reference -> Assemblies):
'   - System.IO.Compression
'   - System.IO.Compression.FileSystem
' (dibutuhkan buat ZipFile.ExtractToDirectory)
' ============================================================

Public Module ClsAutoUpdater

    ''' <summary>
    ''' Cek update dari zip di folder bersama. Kalau ada versi lebih baru,
    ''' konfirmasi ke user, lalu tutup aplikasi & pasang otomatis.
    ''' </summary>
    ''' <param name="sharedZipPath">Path lengkap file zip di network share, misal \\server\folder\RMPApp\RMPApp_Latest.zip</param>
    ''' <param name="installDir">Folder tempat aplikasi ter-install sekarang, misal C:\Users\Public\OneLogin\RMPApp</param>
    ''' <param name="exeFileName">Nama file .exe utama, misal RMPApp.exe (harus PERSIS sama nama di dalam zip)</param>
    Public Sub CheckForUpdate(sharedZipPath As String, installDir As String, exeFileName As String)
        Try
            If Not File.Exists(sharedZipPath) Then
                MessageBox.Show("File update tidak ditemukan di folder bersama:" & vbCrLf & sharedZipPath & vbCrLf & vbCrLf &
                                "Pastikan Anda terhubung ke jaringan kantor.",
                                "Cek Update", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Extract ke folder temp dulu -- BUKAN langsung ke installDir,
            ' supaya bisa baca versinya dulu sebelum mutusin perlu update atau tidak.
            Dim tempExtractDir As String = Path.Combine(Path.GetTempPath(), "OneLoginUpdate_" & Guid.NewGuid().ToString("N"))
            Directory.CreateDirectory(tempExtractDir)

            Try
                ZipFile.ExtractToDirectory(sharedZipPath, tempExtractDir)
            Catch ex As Exception
                MessageBox.Show("Gagal buka file zip update: " & ex.Message, "Cek Update", MessageBoxButtons.OK, MessageBoxIcon.Error)
                SafeDeleteDir(tempExtractDir)
                Return
            End Try

            ' Cek exe di root zip dulu
            Dim effectiveSourceDir As String = tempExtractDir
            Dim newExePath As String = Path.Combine(effectiveSourceDir, exeFileName)

            ' Kalau tidak ada di root, coba satu level subfolder
            ' (misal zip berisi folder RMPApp/RMPApp.exe, bukan langsung RMPApp.exe)
            If Not File.Exists(newExePath) Then
                Dim subFolders() As String = Directory.GetDirectories(tempExtractDir)
                If subFolders.Length = 1 Then
                    Dim subExePath As String = Path.Combine(subFolders(0), exeFileName)
                    If File.Exists(subExePath) Then
                        effectiveSourceDir = subFolders(0)  ' xcopy dari subfolder ini
                        newExePath = subExePath
                    End If
                End If
            End If

            If Not File.Exists(newExePath) Then
                MessageBox.Show("File """ & exeFileName & """ tidak ditemukan di dalam zip update." & vbCrLf &
                    "Pastikan nama file .exe di zip persis sama.",
                    "Cek Update", MessageBoxButtons.OK, MessageBoxIcon.Error)
                SafeDeleteDir(tempExtractDir)
                Return
            End If

            Dim newVersionStr As String = FileVersionInfo.GetVersionInfo(newExePath).FileVersion
            Dim newVersion As Version

            If Not Version.TryParse(newVersionStr, newVersion) Then
                MessageBox.Show("Tidak bisa membaca nomor versi dari file update.", "Cek Update", MessageBoxButtons.OK, MessageBoxIcon.Error)
                SafeDeleteDir(tempExtractDir)
                Return
            End If

            ' Baca versi user LANGSUNG dari file .exe yang sedang terpasang di
            ' disknya (bukan cuma dari memori/My.Application.Info.Version) --
            ' supaya cara bacanya sama persis kayak baca versi baru di atas.
            Dim currentExePath As String = Path.Combine(installDir, exeFileName)
            Dim currentVersion As Version

            If File.Exists(currentExePath) Then
                Dim currentVersionStr As String = FileVersionInfo.GetVersionInfo(currentExePath).FileVersion
                If Not Version.TryParse(currentVersionStr, currentVersion) Then
                    currentVersion = My.Application.Info.Version ' fallback kalau file-nya aneh
                End If
            Else
                currentVersion = My.Application.Info.Version ' fallback kalau file tidak ketemu di path itu
            End If

            If newVersion <= currentVersion Then
                MessageBox.Show("Aplikasi Anda sudah versi terbaru (" & currentVersion.ToString() & ").",
                    "Cek Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                SafeDeleteDir(tempExtractDir)
                Application.Exit()  ' ← tambahkan ini
                Return
            End If

            Dim confirm = MessageBox.Show(
                "Versi baru tersedia: " & newVersion.ToString() & vbCrLf &
                "Versi Anda sekarang: " & currentVersion.ToString() & vbCrLf & vbCrLf &
                "Aplikasi akan DITUTUP sebentar untuk proses update, lalu terbuka lagi otomatis. Lanjutkan?",
                "Update Tersedia", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If confirm <> DialogResult.Yes Then
                SafeDeleteDir(tempExtractDir)
                Return
            End If

            RunUpdateAndRestart(effectiveSourceDir, installDir, exeFileName)

        Catch ex As Exception
            MessageBox.Show("Gagal cek update: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Bikin file .bat sementara yang: nunggu aplikasi ini beneran tertutup,
    ''' copy file baru ke folder install, buka lagi aplikasinya, lalu hapus
    ''' dirinya sendiri. Perlu lewat .bat karena aplikasi TIDAK BISA menimpa
    ''' file .exe dirinya sendiri selagi masih berjalan.
    ''' </summary>
    Private Sub RunUpdateAndRestart(sourceDir As String, installDir As String, exeFileName As String)
        Dim batPath As String = Path.Combine(Path.GetTempPath(), "onelogin_update_" & Guid.NewGuid().ToString("N") & ".bat")
        Dim currentPid As Integer = Process.GetCurrentProcess().Id
        Dim targetExe As String = Path.Combine(installDir, exeFileName)
        Dim q As String = Chr(34) ' tanda kutip ("), dipisah biar gampang dibaca di tengah string

        Dim sb As New StringBuilder()
        sb.AppendLine("@echo off")
        sb.AppendLine(":waitloop")
        sb.AppendLine("tasklist /FI " & q & "PID eq " & currentPid & q & " 2>nul | find /I " & q & CStr(currentPid) & q & " >nul")
        sb.AppendLine("if not errorlevel 1 (")
        sb.AppendLine("    timeout /t 1 /nobreak > nul")
        sb.AppendLine("    goto waitloop")
        sb.AppendLine(")")
        sb.AppendLine("timeout /t 1 /nobreak > nul")
        sb.AppendLine("xcopy " & q & sourceDir & "\*" & q & " " & q & installDir & q & " /E /Y /I >nul")
        sb.AppendLine("start " & q & q & " " & q & targetExe & q)
        sb.AppendLine("rmdir /S /Q " & q & sourceDir & q)
        sb.AppendLine("(goto) 2>nul & del " & q & "%~f0" & q)

        File.WriteAllText(batPath, sb.ToString())

        Dim psi As New ProcessStartInfo() With {
            .FileName = batPath,
            .WindowStyle = ProcessWindowStyle.Hidden,
            .UseShellExecute = True
        }
        Process.Start(psi)

        Application.Exit()
    End Sub

    Private Sub SafeDeleteDir(path As String)
        Try
            If Directory.Exists(path) Then Directory.Delete(path, True)
        Catch
            ' Abaikan -- folder temp, tidak fatal kalau gagal dihapus
        End Try
    End Sub

End Module
