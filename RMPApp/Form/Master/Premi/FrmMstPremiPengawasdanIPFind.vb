Imports System.Data.SqlClient

Public Class FrmMstPremiPengawasdanIPFind
    Private Sub ListData()
        'Dim i As Integer
        Dim sql As String
        Dim cmd As New SqlCommand

        sql = "Select * from RsupAccounting..vwtblMstPengawasdanInspektordanPengawas  Where  " &
             " (CONVERT(DATETIME, CONVERT(VARCHAR, Periode, 103), 103) Between " &
              " CONVERT(DATETIME, '" & CDate(dtTanggal1.Value) & "', 103) and CONVERT(DATETIME, '" & CDate(dtTanggal2.Value) & "', 103)) "

        cmd.Connection = DB.OpenConnection(StrConnAccounting)
        cmd.CommandText = sql
        dgvfind.Rows.Clear()
        Dim DR As SqlDataReader = cmd.ExecuteReader
        If DR.HasRows Then
            Do While DR.Read()
                dgvfind.Rows.Add(DR("HeaderID"), DR("NoTrans"),
                                       DR("Periode"), DR("Batas_KB_B"), DR("Batas_Susut_KB"), DR("Jenis"), DR("Grade_KB"), DR("Maksimal_KBB_Pengawas"),
                                       DR("Max_Susut_Kg_Pengawas"), DR("Vol_KB_Pcg_Pengawas"), DR("Maksimal_KBB_Inspektor"),
                                        DR("Max_Susut_Kg_Inspektor"), DR("Vol_KB_Pcg_Inspektor"),
                                       DR("CreatedBy"), DR("CreatedDate"), DR("LastUpdatedBy"), DR("LastUpdatedDate"))
            Loop
        Else
            MsgBox("Data Tidak ditemukan ! ", MsgBoxStyle.Information)
            Exit Sub
        End If

        DR.Close()
        DR = Nothing
        cmd.Dispose()
    End Sub

    Private Sub FrmMasterPremiPengawasdanIPFind_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        BringToFront()

        dtTanggal1.Value = CDate("01/" & Format(Now, "MM/yyyy"))
        dtTanggal2.Value = CDate(DateAdd("d", -1, DateAdd("M", 1, dtTanggal1.Value)))

    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        Call ListData()
    End Sub

    Private Sub DGV1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvfind.CellDoubleClick
        With FrmMstPremiPengawasandIP


            .cmdENabled(True)
            .txtnotrans.Text = If(IsDBNull(dgvfind.Item("NoTrans", dgvfind.CurrentRow.Index).Value) = True, "", dgvfind.Item("NoTrans", dgvfind.CurrentRow.Index).Value)
            .dttgl.Value = dgvfind.Item("Periode", dgvfind.CurrentRow.Index).Value
            .txtbatasskbb.Text = If(IsDBNull(dgvfind.Item("Batas_KB_B", dgvfind.CurrentRow.Index).Value) = True, 0, dgvfind.Item("Batas_KB_B", dgvfind.CurrentRow.Index).Value)
            .txtbatassusut.Text = If(IsDBNull(dgvfind.Item("Batas_Susut_KB", dgvfind.CurrentRow.Index).Value) = True, 0, dgvfind.Item("Batas_Susut_KB", dgvfind.CurrentRow.Index).Value)

            .cmbGrade_KB.SelectedValue = If(IsDBNull(dgvfind.Item("Grade_KB_ID", dgvfind.CurrentRow.Index).Value) = True, 0, dgvfind.Item("Grade_KB_ID", dgvfind.CurrentRow.Index).Value)

            .cmbGrade_KB.Text = If(IsDBNull(dgvfind.Item("Grade_KB", dgvfind.CurrentRow.Index).Value) = True, 0, dgvfind.Item("Grade_KB", dgvfind.CurrentRow.Index).Value)


            .txtMaksimal_KBB_Pengawas.Text = If(IsDBNull(dgvfind.Item("Maksimal_KBB_Pengawas", dgvfind.CurrentRow.Index).Value) = True, 0, dgvfind.Item("Maksimal_KBB_Pengawas", dgvfind.CurrentRow.Index).Value)
            .txtMax_Susut_Kg_Pengawas.Text = If(IsDBNull(dgvfind.Item("Max_Susut_Kg_Pengawas", dgvfind.CurrentRow.Index).Value) = True, 0, dgvfind.Item("Max_Susut_Kg_Pengawas", dgvfind.CurrentRow.Index).Value)
            .txtVol_KB_Pcg_Pengawas.Text = If(IsDBNull(dgvfind.Item("Vol_KB_Pcg_Pengawas", dgvfind.CurrentRow.Index).Value) = True, 0, dgvfind.Item("Vol_KB_Pcg_Pengawas", dgvfind.CurrentRow.Index).Value)

            .txtMaksimal_KBB_Inspektor.Text = If(IsDBNull(dgvfind.Item("Maksimal_KBB_Inspektor", dgvfind.CurrentRow.Index).Value) = True, 0, dgvfind.Item("Maksimal_KBB_Inspektor", dgvfind.CurrentRow.Index).Value)
            .txtMax_Susut_Kg_Inspektor.Text = If(IsDBNull(dgvfind.Item("Max_Susut_Kg_Inspektor", dgvfind.CurrentRow.Index).Value) = True, 0, dgvfind.Item("Max_Susut_Kg_Inspektor", dgvfind.CurrentRow.Index).Value)
            .txtVol_KB_Pcg_Inspektor.Text = If(IsDBNull(dgvfind.Item("Vol_KB_Pcg_Inspektor", dgvfind.CurrentRow.Index).Value) = True, 0, dgvfind.Item("Vol_KB_Pcg_Inspektor", dgvfind.CurrentRow.Index).Value)
            .ShowdataDTL(dgvfind.Item("NoTrans", dgvfind.CurrentRow.Index).Value)
        End With
        Me.Dispose()
    End Sub

    Private Sub dgvfind_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvfind.CellContentClick

    End Sub
End Class