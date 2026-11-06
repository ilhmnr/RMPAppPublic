Imports System.Data.SqlClient

Public Class FrmMstTarifTambangKapalDialog
    Private Sub ListData()
        'Dim i As Integer
        Dim sql As String
        Dim cmd As New SqlCommand

        sql = "Select * from RMPApp..vwMstHargaTambangKapalHdr  Where  " &
             " (CONVERT(DATETIME, CONVERT(VARCHAR, Periode, 103), 103) Between " &
              " CONVERT(DATETIME, '" & CDate(dtTanggal1.Value) & "', 103) and CONVERT(DATETIME, '" & CDate(dtTanggal2.Value) & "', 103)) order by periode desc "

        cmd.Connection = DB.OpenConnection(StrConnAccounting)
        cmd.CommandText = sql
        dgvfind.Rows.Clear()
        Dim DR As SqlDataReader = cmd.ExecuteReader
        If DR.HasRows Then
            Do While DR.Read()
                dgvfind.Rows.Add(DR("KodeHargaString"), DR("Kapasitas"), DR("KapasitasStr"),
                                 DR("Periode"), DR("CreatedBy"), DR("CreatedDate"), DR("LastUpdatedBy"), DR("LastUpdatedDate"))
            Loop
        Else
            MsgBox("Data Tidak ditemukan ! ", MsgBoxStyle.Information)
            Exit Sub
        End If

        DR.Close()
        DR = Nothing
        cmd.Dispose()
    End Sub

    Private Sub FrmMasterHargaTambangKapalFind_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        BringToFront()

        dtTanggal1.Value = CDate("01/" & Format(Now, "MM/yyyy"))
        dtTanggal2.Value = CDate(DateAdd("d", -1, DateAdd("M", 1, dtTanggal1.Value)))

    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        Call ListData()
    End Sub

    Private Sub dgvfind_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvfind.CellDoubleClick
        With FrmMstTarifTambangKapal
            .cmdENabled(True)
            .txtnotrans.Text = dgvfind.Item("KodeHargaString", dgvfind.CurrentRow.Index).Value
            .dttgl.Value = dgvfind.Item("Periode", dgvfind.CurrentRow.Index).Value
            .cmbKapasitas.SelectedValue = If(IsDBNull(dgvfind.Item("IDKapasitas", dgvfind.CurrentRow.Index).Value) = True, 0, dgvfind.Item("IDKapasitas", dgvfind.CurrentRow.Index).Value)

            .ShowdataDTL(dgvfind.Item("KodeHargaString", dgvfind.CurrentRow.Index).Value)
        End With
        Me.Dispose()
    End Sub

    Private Sub dgvfind_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvfind.CellContentClick

    End Sub

    Private Sub dgvfind_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvfind.CellEndEdit

    End Sub
End Class