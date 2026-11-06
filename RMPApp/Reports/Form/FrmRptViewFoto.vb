Public Class FrmRptViewFoto
    Public formName As String
    Public FileName As String
    Private Sub FrmRptViewFoto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If formName = "FrmTrnRealisasiDokingKapal" Then
            Dim apiUrl As String = UrlApiNotaPancang & "ImagesPerbaikanKapal&filename=" & FileName & "&flag=notapancang"

            Modul_RMP.Func.getfoto(apiUrl, TokenApiNotaPancang, PictureBox1)
            Label1.Text = FileName
            btnDownload.Enabled = False
        ElseIf formName = "FrmMonPemeriksaanKapal" Then
            Dim apiUrl As String = UrlApiNotaPancang & "ImagesPemeriksaanKapal&filename=" & FileName & "&flag=notapancang"

            Modul_RMP.Func.getfoto(apiUrl, TokenApiNotaPancang, PictureBox1)
            Label1.Text = FileName
            btnDownload.Enabled = False
        ElseIf formName = "FrmMstKaptenKapal" Then
            Dim apiUrl As String = UrlApiNotaPancang & "ImagesKapalKTP&filename=" & FileName & "&flag=notapancang"

            Modul_RMP.Func.getfoto(apiUrl, TokenApiNotaPancang, PictureBox1)
            Label1.Text = FileName
            btnDownload.Enabled = False
        ElseIf formName = "FrmTrnApproval1DanInputBarangPengajuanWoPancang" Then
            Dim apiUrl As String = UrlApiNotaPancang & "ImagesWorkOrder&filename=" & FileName & "&flag=notapancang"

            Modul_RMP.Func.getfoto(apiUrl, TokenApiNotaPancang, PictureBox1)
            Label1.Text = FileName
            btnDownload.Enabled = True
        ElseIf formName = "FrmMonWoPancangDtl" Then
            Dim apiUrl As String = UrlApiNotaPancang & "ImagesBarangWorkOrder&filename=" & FileName & "&flag=notapancang"

            Modul_RMP.Func.getfoto(apiUrl, TokenApiNotaPancang, PictureBox1)
            Label1.Text = FileName
            btnDownload.Enabled = True
        ElseIf formName = "FrmMonWoPancangDtl_temuan" Then
            Dim apiUrl As String = UrlApiNotaPancang & "ImagesPemeriksaanWorkOrder&filename=" & FileName & "&flag=notapancang"

            Modul_RMP.Func.getfoto(apiUrl, TokenApiNotaPancang, PictureBox1)
            Label1.Text = FileName
            btnDownload.Enabled = True
        End If
    End Sub

    Private Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        Dim sourceFile As String = UrlNotaPancang & "ImagesPurchaserSupplier\" & FileName

        If formName = "FrmTrnRealisasiDokingKapal" Then
            sourceFile = UrlNotaPancang & "ImagesPerbaikanKapal\" & FileName
        ElseIf formName = "FrmMonPemeriksaanKapal" Then
            sourceFile = UrlNotaPancang & "ImagesPemeriksaanKapal\" & FileName
        ElseIf formName = "FrmMstKaptenKapal" Then
            sourceFile = UrlNotaPancang & "ImagesKapalKTP\" & FileName
        ElseIf formName = "FrmTrnApproval1DanInputBarangPengajuanWoPancang" Then
            sourceFile = UrlNotaPancang & "ImagesWorkOrder\" & FileName
        ElseIf formName = "FrmMonWoPancangDtl" Then
            sourceFile = UrlNotaPancang & "ImagesBarangWorkOrder\" & FileName
        ElseIf formName = "FrmMonWoPancangDtl_temuan" Then
            sourceFile = UrlNotaPancang & "ImagesPemeriksaanWorkOrder\" & FileName
        End If

        Dim downloadFolder As String = System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) & "\Downloads"
        Dim destinationFile As String = System.IO.Path.Combine(downloadFolder, System.IO.Path.GetFileName(sourceFile))

        Try
            System.IO.File.Copy(sourceFile, destinationFile, True)
            MsgBox("File berhasil dipindahkan ke direktori download.")
        Catch ex As Exception
            MsgBox("Terjadi kesalahan saat memindahkan file: " & ex.Message)
        End Try
    End Sub
End Class