Imports System.IO
Imports System.IO.Compression
Imports System.Security.AccessControl

Public Class FrmUtlUpdateVersion
    Dim version As Double
    Private Sub FrmUltUpdateVersion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = "Version " & My.Application.Info.Version.Major.ToString() & "." & My.Application.Info.Version.Minor.ToString & "." _
              & My.Application.Info.Version.Build.ToString & "." & My.Application.Info.Version.Revision.ToString
        version = My.Application.Info.Version.Major.ToString() & My.Application.Info.Version.Minor.ToString &
                       My.Application.Info.Version.Build.ToString & My.Application.Info.Version.Revision.ToString
    End Sub
    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtremark.Text = String.Empty Then
            MsgBox("Remarks Empty !", MsgBoxStyle.Exclamation, AT)
            txtremark.Focus()
            Exit Sub
        Else
            Cursor = Cursors.WaitCursor 'and some various me.Cursor / current.cursor 
            Application.DoEvents()
            Try
                Dim cekver As DataTable = New DataTable()
                cekver = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "Select max(Version) as Version from RMPApp..AppVersion")
                For Each row As DataRow In cekver.Rows
                    If version = IIf(IsDBNull(row.Item("Version")), 0, row.Item("Version")) Then
                        'MsgBox("Available Version" & vbNewLine & "Please change the version", MsgBoxStyle.Exclamation, AT)
                        'Exit Sub
                    Else
                        Dim savever As DataTable = New DataTable()
                        savever = DB.ExecuteQuery(StrConnRMPApp, "Insert RMPApp..AppVersion (Version, Remark, Author) values ('" & version & "', '" & txtremark.Text & "', '" & ClsSession.UserID & "')")
                    End If

                    'CopyFolderAndExstrakFolder()

                    MsgBox("Update Completed", MsgBoxStyle.Information, AT)
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                Cursor = Cursors.Default
            End Try
        End If
        Me.Close()
    End Sub

    Private Sub CopyFolderAndExstrakFolder()
        Dim sourcePath As String = Application.StartupPath
        Dim destinationPath As String = Application.StartupPath
        destinationPath = destinationPath.Substring(0, destinationPath.Length - 5) & "RMPApp\RMPApp"
        Dim A As String = destinationPath.Substring(0, destinationPath.Length - 7)

        If File.Exists(destinationPath.Substring(0, destinationPath.Length - 7)) Then
            File.Delete(destinationPath.Substring(0, destinationPath.Length - 7))
        End If
        If File.Exists(destinationPath.Substring(0, destinationPath.Length - 7) & ".zip") Then
            File.Delete(destinationPath.Substring(0, destinationPath.Length - 7) & ".zip")
        End If
        If File.Exists("M:\ITD\UpdateProgram\RMPApp.zip") Then
            File.Delete("M:\ITD\UpdateProgram\RMPApp.zip")
        End If

        If Directory.Exists(sourcePath) Then
            Directory.CreateDirectory(destinationPath)

            ' Menyalin file-file dalam folder sumber ke folder tujuan
            For Each filePath As String In Directory.GetFiles(sourcePath)
                Dim fileName As String = Path.GetFileName(filePath)
                Dim destinationFilePath As String = Path.Combine(destinationPath, fileName)
                File.Copy(filePath, destinationFilePath, True)
            Next

            ' Menyalin subfolder dalam folder sumber ke folder tujuan
            For Each subDirectoryPath As String In Directory.GetDirectories(sourcePath)
                Dim subDirectoryName As String = Path.GetFileName(subDirectoryPath)
                Dim destinationSubDirectoryPath As String = Path.Combine(destinationPath, subDirectoryName)
                DirectoryCopy(subDirectoryPath, destinationSubDirectoryPath)
            Next

            ExtractFolderToZip(destinationPath.Substring(0, destinationPath.Length - 7), "M:\ITD\UpdateProgram\RMPApp.zip")

            MessageBox.Show("Folder berhasil disalin.")
        Else
            MessageBox.Show("Folder sumber tidak ditemukan.")
        End If
    End Sub

    Private Sub ExtractFolderToZip(sourceFolderPath As String, zipFilePath As String)
        ZipFile.CreateFromDirectory(sourceFolderPath, zipFilePath)
    End Sub

    Private Sub DirectoryCopy(sourcePath As String, destinationPath As String)
        Dim directoryInfo As New DirectoryInfo(sourcePath)
        Dim directorySecurity As DirectorySecurity = directoryInfo.GetAccessControl()

        ' Membuat folder tujuan dengan izin yang sama dengan folder sumber
        Directory.CreateDirectory(destinationPath, directorySecurity)

        ' Menyalin file-file dalam folder sumber ke folder tujuan
        For Each filePath As String In Directory.GetFiles(sourcePath)
            Dim fileName As String = Path.GetFileName(filePath)
            Dim destinationFilePath As String = Path.Combine(destinationPath, fileName)
            File.Copy(filePath, destinationFilePath, True)
        Next

        ' Menyalin subfolder dalam folder sumber ke folder tujuan
        For Each subDirectoryPath As String In Directory.GetDirectories(sourcePath)
            Dim subDirectoryName As String = Path.GetFileName(subDirectoryPath)
            Dim destinationSubDirectoryPath As String = Path.Combine(destinationPath, subDirectoryName)
            DirectoryCopy(subDirectoryPath, destinationSubDirectoryPath)
        Next
    End Sub
End Class