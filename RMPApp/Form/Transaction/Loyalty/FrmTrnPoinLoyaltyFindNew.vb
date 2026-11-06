Imports System.Data.SqlClient
Imports System.IO
Imports System.Data
Imports System.ComponentModel
Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Globalization
Public Class FrmTrnPoinLoyaltyFindNew

    Private Sub FrmTrnPoinLoyaltyFindNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DTPStart.Value = Format(Now, "dd/MM/yy")
        DTPEnd.Value = Format(Now, "dd/MM/yy")

        dt1.Value = Format(Now, "dd/MM/yy")
        dt2.Value = Format(Now, "dd/MM/yy")
        chknoinvoice.Checked = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        With FrmTrnTukarPoinNew
            'Call .clear(True)
            .perintah = "Add"
            .dtpInvoice.Focus()

            '.cmdEnabled(False)

            '.enableds(True)
            .Show()
        End With
    End Sub
End Class