Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports C1.Win.C1FlexGrid
Public Class FrmTrnInvoicePembayaranKelapa
    Dim cls As New ClsDatabaseConnection
    Dim Conn As SqlConnection = New SqlConnection(StrConnRMPApp)
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'ReportViewer.Clear()
        'ReportViewer.LocalReport.DataSources.Clear()
        chkTgl.Checked = False
        chkPancang.Checked = False
        chkKapal.Checked = False
        chkTrip.Checked = False
        dtp1.Value = Format(Now, "yyyy-MM-dd")
        dtp2.Value = Format(Now, "yyyy-MM-dd")
        dtInput.Value = Format(Now, "yyyy-MM-dd")
    End Sub

    Private Sub FrmTrnInvoicePembayaranKelapa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'STYLE DGV--------------------------------------------------------------------------
        dgvlist.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 140, 217)
        dgvlist.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvlist.EnableHeadersVisualStyles = False
        '-----------------------------------------------------------------------------------


        dtp1.Value = Format(Now, "yyyy-MM-dd")
        dtp2.Value = Format(Now, "yyyy-MM-dd")
        dtInput.Value = Format(Now, "yyyy-MM-dd")
        Modul_RMP.Combo.SetPancang(cboPCG)
        Modul_RMP.Combo.SetKapal(cboKPL)

        dtp1.Enabled = False
        dtp2.Enabled = False
        cboPCG.Enabled = False
        cboKPL.Enabled = False
        txtTrip.Enabled = False

    End Sub

    Private Sub cboPCG_KeyUp(sender As Object, e As KeyEventArgs) Handles cboPCG.KeyUp
        UI.AutoCompleteCombo_KeyUp(cboPCG, e)
    End Sub

    Private Sub cboKPL_KeyUp(sender As Object, e As KeyEventArgs) Handles cboKPL.KeyUp
        UI.AutoCompleteCombo_KeyUp(cboKPL, e)
    End Sub

    Private Sub txtTrip_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTrip.KeyPress
        UI.validasi(e, 2)
    End Sub

    Private Sub chkTgl_CheckedChanged(sender As Object, e As EventArgs) Handles chkTgl.CheckedChanged
        If chkTgl.Checked = True Then
            dtp1.Enabled = True
            dtp2.Enabled = True
        Else
            dtp1.Enabled = False
            dtp2.Enabled = False
            dtp1.Value = Format(Now, "yyyy-MM-dd")
            dtp2.Value = Format(Now, "yyyy-MM-dd")
        End If
    End Sub

    Private Sub chkPancang_CheckedChanged(sender As Object, e As EventArgs) Handles chkPancang.CheckedChanged
        If chkPancang.Checked = True Then
            cboPCG.Enabled = True
        Else
            cboPCG.Enabled = False
            cboPCG.Text = ""
        End If
    End Sub

    Private Sub chkKapal_CheckedChanged(sender As Object, e As EventArgs) Handles chkKapal.CheckedChanged
        If chkKapal.Checked = True Then
            cboKPL.Enabled = True
        Else
            cboKPL.Enabled = False
            cboKPL.Text = ""
        End If
    End Sub

    Private Sub chkTrip_CheckedChanged(sender As Object, e As EventArgs) Handles chkTrip.CheckedChanged
        If chkTrip.Checked = True Then
            txtTrip.Enabled = True
        Else
            txtTrip.Enabled = False
            txtTrip.Text = ""
        End If
    End Sub

    Private Sub ShowData()


        Dim SQL, SQL1, SQL2, SQL3, SQL4, SQL5 As String
        Dim i As Integer = 0

        If chkTgl.Checked = False Then
            SQL2 = ""
        Else
            SQL2 = " And CONVERT(DATETIME,CONVERT(VARCHAR,TglMasukKapal,103),103) BETWEEN CONVERT (DATETIME,'" & dtp1.Value & "',103) AND CONVERT(DATETIME,'" & dtp2.Value & "',103)"
        End If

        If chkPancang.Checked = False Then
            SQL3 = ""
        Else
            SQL3 = " And IDPancang = '" & cboPCG.SelectedValue & "'"
        End If

        If chkKapal.Checked = False Then
            SQL4 = ""
        Else
            SQL4 = " And IDKapal = '" & cboKPL.SelectedValue & "'"
        End If

        If chkTrip.Checked = False Then
            SQL5 = ""
        Else
            SQL5 = " And Trip = '" & txtTrip.Text & "'"

        End If

        'SQL = "SELECT  DISTINCT(A.Harga), Sum(A.NettoAkhir) As NettoAkhir, A.Kapal, A.Trip, A.Pancang, B.Kap, Sum(A.TotalHarga) as TotalHarga, A.Jenis,A.IDKapal FROM vwTMBGKelapaHdr_ AS A INNER JOIN " &
        '          "tblMstKapal AS B ON A.IDKapal = B.KapalID WHERE A.Deleted = 0 "

        'SQL = SQL + SQL2 + SQL3 + SQL4 + SQL5 & "GROUP BY A.Kapal,A.Trip,A.Pancang,B.Kap,A.Harga,A.Jenis,A.IDKapal order by Kapal desc"

        SQL = "SELECT TglMasukKapal,IDKapal,Kapal,Kap,Trip,IDPancang,Pancang,NettoAkhir,TotalHarga,TotalHarga/NettoAkhir AS Harga FROM vwInvoiceKelapa WHERE TglMasukKapal IS NOT NULL"

        SQL = SQL + SQL2 + SQL3 + SQL4 + SQL5 & "ORDER BY Kapal"

        Try
            Using koneksi As New SqlCommand(SQL, DB.OpenConnection(StrConnRMPApp))
                Using DR = koneksi.ExecuteReader
                    dgvlist.Rows.Clear()

                    If DR.HasRows Then
                        dgvlist.RowCount = 0
                        While DR.Read
                            With dgvlist

                                .Rows.Add()
                                .Item("No", i).Value = i + 1
                                .Item("NamaKapal", i).Value = DR!Kapal
                                .Item("Kapasitas", i).Value = DR!Kap
                                .Item("Trip", i).Value = DR!Trip
                                .Item("Pancang", i).Value = DR!Pancang
                                .Item("Muatan", i).Value = DR!NettoAkhir
                                .Item("Harga", i).Value = DR!Harga
                                .Item("Jumlah", i).Value = DR!TotalHarga
                                '.Item("Jenis", i).Value = DR!Jenis
                                .Item("IDKapal", i).Value = DR!IDKapal
                                '.Item("NoNota", i).Value = DR!NoNota
                                '.Item("Alasan", i).Value = DR!Alasan
                                '.Item("Status", i).Value = DR!Status

                                With Me.dgvlist
                                    .RowsDefaultCellStyle.BackColor = Color.White
                                    .AlternatingRowsDefaultCellStyle.BackColor = Color.White
                                    .Rows(i).Cells("No").Style.BackColor = Color.FromArgb(240, 240, 240)
                                End With

                            End With
                            i += 1
                        End While
                    Else
                        dgvlist.Rows.Clear()
                        MsgBox("Data Tidak ditemukan ! ", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    DR.Close()
                End Using
            End Using
            DB.CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            'GetErrorLog("353756059", Me, ex.ToString)
        End Try
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        ShowData()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If txtNoInvoice.Text = "" Then
            MsgBox("NoInvoice Belum di Isi ! ", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        'If Trim(txtID.Text) = "" Then
        '    MessageBox.Show("Silahkan klik data yang akan di print, lalu klik tombol PRINT")
        '    Exit Sub
        'End If
        'If MessageBox.Show("Anda yakin mau print data ini ?", "Print out", MessageBoxButtons.YesNo) = vbNo Then
        '    Exit Sub
        'End If
        FrmRptInvoicePembayaranKelapa.Show()
    End Sub

    Private Sub txtNoInvoice_TextChanged(sender As Object, e As EventArgs) Handles txtNoInvoice.TextChanged

    End Sub
End Class