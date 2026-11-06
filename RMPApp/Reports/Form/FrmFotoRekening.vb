Imports System.IO
Imports System.Net
Public Class FrmFotoRekening
    Public images As String
    Public Foto As String
    Public Path As String
    Public pathFile As String = "\\Nas2Rsup\MasterTT\Pancang\Rekening\"
    Private Sub FrmFotoBerkasCovid_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PictureBox.BackgroundImage = Nothing
        Dim folder As String = pathFile
        Dim filename As String = System.IO.Path.Combine(folder, images & ".png")
        PictureBox.LoadAsync(pathFile & images & ".png")

    End Sub

    Private Sub PictureBox_Click(sender As Object, e As EventArgs) Handles PictureBox.Click

    End Sub
End Class