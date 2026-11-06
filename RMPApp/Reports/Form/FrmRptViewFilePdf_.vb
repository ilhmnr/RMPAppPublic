Public Class FrmRptViewFilePdf_
    Public FilePdf As String
    Public Folback As String
    Private Sub FrmRptViewFilePdf__Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AxAcroPDF1.src = FilePdf
    End Sub
End Class