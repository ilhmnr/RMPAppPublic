Imports DocumentFormat.OpenXml.Spreadsheet

Public Class FrmKeteranganDelete
    Public Property ResultText As String = ""

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If Replace(txtKeterangan.Text, " ", "") = "" Then
            MessageBox.Show("Keterangan delete harus diisi.")
            Exit Sub
        End If

        ResultText = txtKeterangan.Text
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmKeteranganDelete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtKeterangan.Text = ""
    End Sub
End Class