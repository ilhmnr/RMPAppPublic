Imports System.IO
Imports System.Net
Imports System.Windows.Forms.Design

Public Class FrmMstSupplierPindahDokumen
    Private Sub btnDownloadNPWP_Click(sender As Object, e As EventArgs)
        Me.Cursor = Cursors.WaitCursor

        Dim dt As DataTable = New DataTable
        dt = DB.ExecuteQuery(StrConnAccounting, "select KodeSup, NoNPWP from DS_SupplierMoveNoNPWP")

        For Each row As DataRow In dt.Rows
            Dim fileName As String = row("NoNPWP").ToString() & ".JPEG"
            Dim apiUrl As String = UrlApiNotaPancang &
                                   "npwpsuplierpcg&filename=" &
                                   fileName &
                                   "&flag=notapancang"

            ' Folder tujuan di C:
            Dim folderTujuan As String = "C:\PROJEK APLICATION\NoNPWP"

            If Not Directory.Exists(folderTujuan) Then
                Directory.CreateDirectory(folderTujuan)
            End If

            Dim fileTujuan As String = Path.Combine(folderTujuan, fileName)

            Try
                Using wc As New WebClient()
                    wc.Headers.Add("Authorization", "Bearer " & TokenApiNotaPancang)
                    wc.DownloadFile(apiUrl, fileTujuan)
                End Using

                ' jika file sudah di temukan di tempat download
                If File.Exists(fileTujuan) Then
                    DB.ExecuteNonQuery(StrConnAccounting, "update DS_SupplierMoveNoNPWP set IndSudahDownload=1 where KodeSup='" & row("KodeSup").ToString() & "'")
                End If

            Catch ex As Exception

            End Try
        Next

        Me.Cursor = Cursors.Default

        MsgBox("Gambar berhasil disimpan")
    End Sub

    Private Sub btnUploadNPWP_Click(sender As Object, e As EventArgs) Handles btnUploadNPWP.Click
        Me.Cursor = Cursors.WaitCursor

        Dim dt As DataTable = New DataTable
        dt = DB.ExecuteQuery(StrConnAccounting, "select KodeSup, NoNPWP from DS_SupplierMoveNoNPWP")

        For Each row As DataRow In dt.Rows
            Dim fileName As String = row("NoNPWP").ToString() & ".JPEG"
            Dim fileNameSave As String = "NPWP-" & row("NoNPWP").ToString() & ".JPEG"

            ' Folder tujuan di C:
            Dim folderAsal As String = "C:\PROJEK APLICATION\FotoNPWP"

            Dim fileAsal As String = Path.Combine(folderAsal, fileName)

            Try
                Dim ok As Boolean = ClsWebDAV.UploadFileWebDav(Trim(fileAsal), cls_Webdav.WebDavGENSupplier, Trim(row("KodeSup").ToString()), Trim(fileNameSave))

                If ok Then
                    DB.ExecuteNonQuery(StrConnAccounting, "update DS_SupplierMoveNoNPWP set IndSudahUpload=1 where KodeSup='" & row("KodeSup").ToString() & "'")
                    DB.ExecuteNonQuery(StrConnDBPancang, "INSERT INTO tblGENMstSupplierAttachment (
		                                                    SupplierID, FileAttachment , AttachmentDescriptions,
		                                                    AppVersion, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, Computer ,ComputerDate )
		                                                    SELECT
		                                                    '" & row("KodeSup").ToString() & "', '" & fileNameSave & "' , 'NPWP',
		                                                    '', 'system', GETDATE(), NULL, NULL, LEFT(HOST_NAME(),25), GETDATE()")
                End If

            Catch ex As Exception

            End Try
        Next

        Me.Cursor = Cursors.Default

        MsgBox("Gambar berhasil disimpan")
    End Sub

    Private Sub btnUploadKTP_Click(sender As Object, e As EventArgs) Handles btnUploadKTP.Click
        Me.Cursor = Cursors.WaitCursor

        Dim i As Integer = 0
        Dim dt As DataTable = New DataTable
        dt = DB.ExecuteQuery(StrConnAccounting, "select * from DS_SupplierMoveNoKTP where IndSudahUpload=0")

        For Each row As DataRow In dt.Rows
            Dim fileName As String = row("NoKTP").ToString() & ".JPEG"
            Dim fileNameSave As String = "KTP-" & row("KodeSup").ToString() & ".JPEG"

            ' Folder tujuan di C:
            Dim folderAsal As String = "C:\PROJEK APLICATION\FotoKTP"

            Dim fileAsal As String = Path.Combine(folderAsal, fileName)

            Try
                Dim ok As Boolean = ClsWebDAV.UploadFileWebDav(Trim(fileAsal), cls_Webdav.WebDavGENSupplier, Trim(row("KodeSup").ToString()), Trim(fileNameSave))

                If ok Then
                    DB.ExecuteNonQuery(StrConnAccounting, "update DS_SupplierMoveNoKTP set IndSudahUpload=1 where KodeSup='" & row("KodeSup").ToString() & "'")
                    DB.ExecuteNonQuery(StrConnDBPancang, "INSERT INTO tblGENMstSupplierAttachment (
		                                                    SupplierID, FileAttachment , AttachmentDescriptions,
		                                                    AppVersion, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, Computer ,ComputerDate )
		                                                    SELECT
		                                                    '" & row("KodeSup").ToString() & "', '" & fileNameSave & "' , 'KTP',
		                                                    '', 'system', GETDATE(), NULL, NULL, LEFT(HOST_NAME(),25), GETDATE()")
                End If

            Catch ex As Exception

            End Try

            i += 1

            lblNo.Text = i.ToString() & " / " & dt.Rows.Count.ToString()
        Next

        Me.Cursor = Cursors.Default

        MsgBox("Gambar berhasil disimpan")
    End Sub

    Private Sub btnUploadPetani_Click(sender As Object, e As EventArgs) Handles btnUploadPetani.Click
        Me.Cursor = Cursors.WaitCursor

        Dim i As Integer = 0
        Dim dt As DataTable = New DataTable
        dt = DB.ExecuteQuery(StrConnAccounting, "select * from DS_SupplierMoveNoKTP where IndSudahUploadPetani=0")

        For Each row As DataRow In dt.Rows
            Dim fileName As String = row("NoKTP").ToString() & ".JPG"
            Dim fileNameSave As String = "PETANI-" & row("KodeSup").ToString() & ".JPG"

            ' Folder tujuan di C:
            Dim folderAsal As String = "C:\PROJEK APLICATION\FotoPetani"

            Dim fileAsal As String = Path.Combine(folderAsal, fileName)

            Try
                Dim ok As Boolean = ClsWebDAV.UploadFileWebDav(Trim(fileAsal), cls_Webdav.WebDavGENSupplier, Trim(row("KodeSup").ToString()), Trim(fileNameSave))

                If ok Then
                    DB.ExecuteNonQuery(StrConnAccounting, "update DS_SupplierMoveNoKTP set IndSudahUploadPetani=1 where KodeSup='" & row("KodeSup").ToString() & "'")
                    DB.ExecuteNonQuery(StrConnDBPancang, "INSERT INTO tblGENMstSupplierAttachment (
		                                                    SupplierID, FileAttachment , AttachmentDescriptions,
		                                                    AppVersion, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, Computer ,ComputerDate )
		                                                    SELECT
		                                                    '" & row("KodeSup").ToString() & "', '" & fileNameSave & "' , 'PETANI',
		                                                    '', 'system', GETDATE(), NULL, NULL, LEFT(HOST_NAME(),25), GETDATE()")
                End If

            Catch ex As Exception

            End Try

            i += 1

            lblNo.Text = i.ToString() & " / " & dt.Rows.Count.ToString()
        Next

        Me.Cursor = Cursors.Default

        MsgBox("Gambar berhasil disimpan")
    End Sub

    Private Sub btnUploadKK_Click(sender As Object, e As EventArgs) Handles btnUploadKK.Click
        Me.Cursor = Cursors.WaitCursor

        Dim i As Integer = 0
        Dim dt As DataTable = New DataTable
        dt = DB.ExecuteQuery(StrConnAccounting, "select * from DS_SupplierMoveNoKTP where IndSudahUploadKK=0")

        For Each row As DataRow In dt.Rows
            Dim fileName As String = row("NoKTP").ToString() & ".JPEG"
            Dim fileNameSave As String = "KK-" & row("KodeSup").ToString() & ".JPEG"

            ' Folder tujuan di C:
            Dim folderAsal As String = "C:\PROJEK APLICATION\FotoKK"

            Dim fileAsal As String = Path.Combine(folderAsal, fileName)

            Try
                Dim ok As Boolean = ClsWebDAV.UploadFileWebDav(Trim(fileAsal), cls_Webdav.WebDavGENSupplier, Trim(row("KodeSup").ToString()), Trim(fileNameSave))

                If ok Then
                    DB.ExecuteNonQuery(StrConnAccounting, "update DS_SupplierMoveNoKTP set IndSudahUploadKK=1 where KodeSup='" & row("KodeSup").ToString() & "'")
                    DB.ExecuteNonQuery(StrConnDBPancang, "INSERT INTO tblGENMstSupplierAttachment (
		                                                    SupplierID, FileAttachment , AttachmentDescriptions,
		                                                    AppVersion, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, Computer ,ComputerDate )
		                                                    SELECT
		                                                    '" & row("KodeSup").ToString() & "', '" & fileNameSave & "' , 'KK',
		                                                    '', 'system', GETDATE(), NULL, NULL, LEFT(HOST_NAME(),25), GETDATE()")
                End If

            Catch ex As Exception

            End Try

            i += 1

            lblNo.Text = i.ToString() & " / " & dt.Rows.Count.ToString()
        Next

        Me.Cursor = Cursors.Default

        MsgBox("Gambar berhasil disimpan")
    End Sub

    Private Sub btnUploadNIB_Click(sender As Object, e As EventArgs) Handles btnUploadNIB.Click
        Me.Cursor = Cursors.WaitCursor

        Dim i As Integer = 0
        Dim dt As DataTable = New DataTable
        dt = DB.ExecuteQuery(StrConnAccounting, "SELECT KodeSup
                                                    FROM tblRMMstSupplier
                                                    WHERE KodeSup IN (
                                                        'PCG24712',
                                                        'PCG27439',
                                                        'PCG27457',
                                                        'PCG27462',
                                                        'PCG27479',
                                                        'PCG27481',
                                                        'PCG27493',
                                                        'PCG27544',
                                                        'PCG27591',
                                                        'PCG27592',
                                                        'PCG27602',
                                                        'PCG27680',
                                                        'PCG27681',
                                                        'PCG27682',
                                                        'PCG27683',
                                                        'PCG27684',
                                                        'PCG27685',
                                                        'PCG27688',
                                                        'PCG27689',
                                                        'PCG27690',
                                                        'PCG27694',
                                                        'PCG27697',
                                                        'PCG27700',
                                                        'PCG27704',
                                                        'PCG27710',
                                                        'PCG27725',
                                                        'PCG27734',
                                                        'PCG27735',
                                                        'PCG27738',
                                                        'PCG27739',
                                                        'PCG27746',
                                                        'PCG27759',
                                                        'PCG27763',
                                                        'PCG27765',
                                                        'PCG27769',
                                                        'PCG27778',
                                                        'PCG27795',
                                                        'PCG27796',
                                                        'PCG27807',
                                                        'PCG27819',
                                                        'PCG27845',
                                                        'PCG27848',
                                                        'PCG27882',
                                                        'PCG27886',
                                                        'PCG27887',
                                                        'PCG27888',
                                                        'PCG27945',
                                                        'PCG28059',
                                                        'PCG28074',
                                                        'PCG28157',
                                                        'PCG28160',
                                                        'PCG28586',
                                                        'PCG28687',
                                                        'PCG28716',
                                                        'PCG28884',
                                                        'PCG28896',
                                                        'PCG28897',
                                                        'PCG28905',
                                                        'PCG29023',
                                                        'PCG29253',
                                                        'PCG29373',
                                                        'PCG29395',
                                                        'PCG29401',
                                                        'PCG29489',
                                                        'PCG29551',
                                                        'PCG29824',
                                                        'PCG29904',
                                                        'PCG30144',
                                                        'PCG30179'
                                                    );")

        For Each row As DataRow In dt.Rows
            Dim fileName As String = row("KodeSup").ToString() & ".PDF"

            ' Folder tujuan di C:
            Dim folderAsal As String = "C:\PROJEK APLICATION\NIB"

            Dim fileAsal As String = Path.Combine(folderAsal, fileName)

            Try
                Dim ok As Boolean = ClsWebDAV.UploadFileWebDav(Trim(fileAsal), cls_Webdav.WebDavGENSupplier, Trim(row("KodeSup").ToString()), Trim(fileName))

                If ok Then
                    'DB.ExecuteNonQuery(StrConnAccounting, "update DS_SupplierMoveNoKTP set IndSudahUploadKK=1 where KodeSup='" & row("KodeSup").ToString() & "'")
                    DB.ExecuteNonQuery(StrConnDBPancang, "INSERT INTO tblGENMstSupplierAttachment (
		                                                    SupplierID, FileAttachment , AttachmentDescriptions,
		                                                    AppVersion, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, Computer ,ComputerDate )
		                                                    SELECT
		                                                    '" & row("KodeSup").ToString() & "', '" & fileName & "' , 'NIB',
		                                                    '', 'system', GETDATE(), NULL, NULL, LEFT(HOST_NAME(),25), GETDATE()")
                End If

            Catch ex As Exception

            End Try

            i += 1

            lblNo.Text = i.ToString() & " / " & dt.Rows.Count.ToString()
        Next

        Me.Cursor = Cursors.Default

        MsgBox("Gambar berhasil disimpan")
    End Sub

    Private Sub btnDeleteKTP_Click(sender As Object, e As EventArgs) Handles btnDeleteKTP.Click
        Me.Cursor = Cursors.WaitCursor

        Dim i As Integer = 0
        Dim dt As DataTable = New DataTable
        dt = DB.ExecuteQuery(StrConnAccounting, "select * from DS_SupplierMoveNoKTP where IndSudahDelete=0")

        For Each row As DataRow In dt.Rows
            Dim fileName As String = row("NoKTP").ToString() & ".JPEG"
            Dim fileName2 As String = row("NoKTP").ToString() & ".JPG"

            Try
                Dim ok As Boolean = ClsWebDAV.DeleteFileWebDav(cls_Webdav.WebDavGENSupplier, Trim(row("KodeSup").ToString()), Trim(fileName))
                Dim ok2 As Boolean = ClsWebDAV.DeleteFileWebDav(cls_Webdav.WebDavGENSupplier, Trim(row("KodeSup").ToString()), Trim(fileName2))

                If ok Or ok2 Then
                    DB.ExecuteNonQuery(StrConnAccounting, "update DS_SupplierMoveNoKTP set IndSudahDelete=1 where KodeSup='" & row("KodeSup").ToString() & "'")
                End If

            Catch ex As Exception

            End Try

            i += 1

            lblNo.Text = i.ToString() & " / " & dt.Rows.Count.ToString()
        Next

        Me.Cursor = Cursors.Default

        MsgBox("Gambar berhasil disimpan")
    End Sub

    Private Sub btnDeleteNPWP_Click(sender As Object, e As EventArgs) Handles btnDeleteNPWP.Click
        Me.Cursor = Cursors.WaitCursor

        Dim i As Integer = 0
        Dim dt As DataTable = New DataTable
        dt = DB.ExecuteQuery(StrConnAccounting, "select * from DS_SupplierMoveNoNPWP where IndSudahDelete=0")

        For Each row As DataRow In dt.Rows
            Dim fileName As String = row("NoNPWP").ToString() & ".JPEG"

            Try
                Dim ok As Boolean = ClsWebDAV.DeleteFileWebDav(cls_Webdav.WebDavGENSupplier, Trim(row("KodeSup").ToString()), Trim(fileName))

                If ok Then
                    DB.ExecuteNonQuery(StrConnAccounting, "update DS_SupplierMoveNoNPWP set IndSudahDelete=1 where KodeSup='" & row("KodeSup").ToString() & "'")
                End If

            Catch ex As Exception

            End Try

            i += 1

            lblNo.Text = i.ToString() & " / " & dt.Rows.Count.ToString()
        Next

        Me.Cursor = Cursors.Default

        MsgBox("Gambar berhasil disimpan")
    End Sub

    Private Sub btnUploadRekening_Click(sender As Object, e As EventArgs) Handles btnUploadRekening.Click
        Me.Cursor = Cursors.WaitCursor

        Dim i As Integer = 0
        Dim dt As DataTable = New DataTable
        dt = DB.ExecuteQuery(StrConnAccounting, "select * from DS_RevisiFotoRekening where IndSudahUpload=0")

        For Each row As DataRow In dt.Rows
            Dim fileName As String = row("FotoRekening").ToString() & ".PNG"

            ' Folder tujuan di C:
            Dim folderAsal As String = "C:\PROJEK APLICATION\FotoRekening"

            Dim fileAsal As String = Path.Combine(folderAsal, fileName)

            Try
                Dim ok As Boolean = ClsWebDAV.UploadFileWebDav(Trim(fileAsal), cls_Webdav.WebDavGENSupplier, Trim(row("KodeSup").ToString()), Trim(fileName))

                If ok Then
                    DB.ExecuteNonQuery(StrConnAccounting, "update DS_RevisiFotoRekening set IndSudahUpload=1 where IDNoRek=" & row("IDNoRek"))
                End If

            Catch ex As Exception

            End Try

            i += 1

            lblNo.Text = i.ToString() & " / " & dt.Rows.Count.ToString()
        Next

        Me.Cursor = Cursors.Default

        MsgBox("Gambar berhasil disimpan")
    End Sub

    Private Sub btnUploadFotoKapalPelangsir_Click(sender As Object, e As EventArgs) Handles btnUploadFotoKapalPelangsir.Click
        Me.Cursor = Cursors.WaitCursor

        Dim i As Integer = 0
        Dim FolderLokal As String = "RMP-Ship-Pelangsir"

        Dim dt As DataTable = New DataTable
        dt = DB.ExecuteQuery(StrConnRMPApp, "select id, fotopompong, is_sudah_uplaod, pelangsir_code from DS_Android_tblMstPelangsir where is_sudah_uplaod=0")

        For Each row As DataRow In dt.Rows
            Dim fileName As String = row("fotopompong").ToString()

            ' Folder tujuan di C:
            Dim folderAsal As String = "C:\PROJEK APLICATION\FotoKapalPelangsir"

            Dim fileAsal As String = Path.Combine(folderAsal, fileName)

            Try
                Dim ok As Boolean = ClsWebDAV.UploadFileWebDav(Trim(fileAsal), FolderLokal, row("id"), Trim(fileName))

                If ok Then
                    DB.ExecuteNonQuery(StrConnRMPApp, "update DS_Android_tblMstPelangsir set is_sudah_uplaod=1 where id=" & row("id"))
                End If

            Catch ex As Exception

            End Try

            i += 1

            lblNo.Text = i.ToString() & " / " & dt.Rows.Count.ToString()
        Next

        Me.Cursor = Cursors.Default

        MsgBox("Gambar berhasil disimpan")
    End Sub

    Private Sub btnUplaodKapal_Click(sender As Object, e As EventArgs) Handles btnUplaodKapal.Click
        Me.Cursor = Cursors.WaitCursor

        Dim i As Integer = 0
        Dim FolderLokal As String = "RMP-Ship\"

        Dim dt As DataTable = New DataTable
        dt = DB.ExecuteQuery(StrConnRMPApp, "select KapalID, FotoKapal, FotoSurat, is_sudah_upload from DS_tblMstKapal where is_sudah_upload=0")

        For Each row As DataRow In dt.Rows
            Dim fileName As String = row("FotoKapal").ToString()

            ' Folder tujuan di C:
            Dim folderAsal As String = "C:\PROJEK APLICATION\FotoKapal"

            Dim fileAsal As String = Path.Combine(folderAsal, fileName)

            Try
                Dim ok As Boolean = ClsWebDAV.UploadFileWebDav(Trim(fileAsal), FolderLokal, Trim(row("KapalID").ToString()), Trim(fileName))

                If ok Then
                    DB.ExecuteNonQuery(StrConnRMPApp, "update DS_tblMstKapal set is_sudah_upload=1 where KapalID='" & row("KapalID").ToString() & "'")
                    DB.ExecuteNonQuery(StrConnRMPApp, "INSERT INTO tblMstKapalAttachment (
		                                                    KapalID, FileAttachment , AttachmentDescriptions,
		                                                    AppVersion, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, Computer ,ComputerDate )
		                                                    SELECT
		                                                    '" & row("KapalID").ToString() & "', '" & fileName & "' , 'KAPAL',
		                                                    '', 'system', GETDATE(), NULL, NULL, LEFT(HOST_NAME(),25), GETDATE()")
                End If

            Catch ex As Exception

            End Try

            i += 1

            lblNo.Text = i.ToString() & " / " & dt.Rows.Count.ToString()
        Next

        Me.Cursor = Cursors.Default

        MsgBox("Gambar berhasil disimpan")
    End Sub

    Private Sub btnUploadSuratKapal_Click(sender As Object, e As EventArgs) Handles btnUploadSuratKapal.Click
        Me.Cursor = Cursors.WaitCursor

        Dim i As Integer = 0
        Dim FolderLokal As String = "RMP-Ship\"

        Dim dt As DataTable = New DataTable
        dt = DB.ExecuteQuery(StrConnRMPApp, "select KapalID, FotoKapal, FotoSurat, is_sudah_upload from DS_tblMstKapal where is_sudah_upload=0")

        For Each row As DataRow In dt.Rows
            Dim fileName As String = row("FotoSurat").ToString()

            ' Folder tujuan di C:
            Dim folderAsal As String = "C:\PROJEK APLICATION\SuratKapal"

            Dim fileAsal As String = Path.Combine(folderAsal, fileName)

            Try
                Dim ok As Boolean = ClsWebDAV.UploadFileWebDav(Trim(fileAsal), FolderLokal, Trim(row("KapalID").ToString()), Trim(fileName))

                If ok Then
                    DB.ExecuteNonQuery(StrConnRMPApp, "update DS_tblMstKapal set is_sudah_upload=1 where KapalID='" & row("KapalID").ToString() & "'")
                    DB.ExecuteNonQuery(StrConnRMPApp, "INSERT INTO tblMstKapalAttachment (
		                                                    KapalID, FileAttachment , AttachmentDescriptions,
		                                                    AppVersion, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, Computer ,ComputerDate )
		                                                    SELECT
		                                                    '" & row("KapalID").ToString() & "', '" & fileName & "' , 'KAPAL',
		                                                    '', 'system', GETDATE(), NULL, NULL, LEFT(HOST_NAME(),25), GETDATE()")
                End If

            Catch ex As Exception

            End Try

            i += 1

            lblNo.Text = i.ToString() & " / " & dt.Rows.Count.ToString()
        Next

        Me.Cursor = Cursors.Default

        MsgBox("Gambar berhasil disimpan")
    End Sub

    Private Sub btnUploadInvPancang_Click(sender As Object, e As EventArgs) Handles btnUploadInvPancang.Click
        Me.Cursor = Cursors.WaitCursor

        Dim i As Integer = 0
        Dim FolderLokal As String = "RMP-INV-Item\"

        Dim dt As DataTable = New DataTable
        dt = DB.ExecuteQuery(StrConnRMPApp, "select top 1 Id, NamaFoto, is_sudah_upload from DS_TblInv_MstBarang where is_sudah_upload=0")

        For Each row As DataRow In dt.Rows
            Dim fileName As String = row("NamaFoto").ToString()

            ' Folder tujuan di C:
            Dim folderAsal As String = "C:\PROJEK APLICATION\FotoInvPancang"

            Dim fileAsal As String = Path.Combine(folderAsal, fileName)

            Try
                Dim ok As Boolean = ClsWebDAV.UploadFileWebDav(Trim(fileAsal), FolderLokal, Trim(row("Id").ToString()), Trim(fileName))

                If ok Then
                    DB.ExecuteNonQuery(StrConnRMPApp, "update DS_tblMstKapal set is_sudah_upload=1 where KapalID='" & row("Id").ToString() & "'")
                End If

            Catch ex As Exception

            End Try

            i += 1

            lblNo.Text = i.ToString() & " / " & dt.Rows.Count.ToString()
        Next

        Me.Cursor = Cursors.Default

        MsgBox("Gambar berhasil disimpan")
    End Sub
End Class