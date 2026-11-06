Public Class FrmFotoSlide
    Public JudulFoto As String
    Public listFoto As DataTable = New DataTable
    Public NoFoto As Integer
    Private Sub FrmFotoSlide_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblJudulFoto.Text = JudulFoto
        lblNoFoto.Text = 1
        NoFoto = 1
        lblTotalFoto.Text = listFoto.Rows.Count
        Call LoadFoto()
    End Sub

    Private Sub FrmFotoSlide_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        pnlControlSlide.Left = (Me.Width - pnlControlSlide.Width) / 2
    End Sub

    Private Sub LoadFoto()
        If JudulFoto = "Foto Kelapa B" Then
            Pic.BackgroundImage = Nothing

            Dim apiUrl As String = UrlApiNotaPancangNew & "ImagesKelapaReject&filename=" & listFoto.Rows(NoFoto - 1)(0) & "&flag=notapancang"

            Modul_RMP.Func.getfoto(apiUrl, TokenApiNotaPancang, Pic)

            lblKg.Text = listFoto.Rows(NoFoto - 1)(1).ToString() & "Kg"
        End If
    End Sub

    Private Sub pnlSlideKiri_Click(sender As Object, e As EventArgs) Handles pnlSlideKiri.Click
        If NoFoto = 1 Then
            Exit Sub
        End If

        NoFoto -= 1
        lblNoFoto.Text = NoFoto
        Call LoadFoto()
    End Sub

    Private Sub pnlSlideKanan_Click(sender As Object, e As EventArgs) Handles pnlSlideKanan.Click
        If NoFoto = lblTotalFoto.Text Then
            Exit Sub
        End If

        NoFoto += 1
        lblNoFoto.Text = NoFoto
        Call LoadFoto()
    End Sub
End Class