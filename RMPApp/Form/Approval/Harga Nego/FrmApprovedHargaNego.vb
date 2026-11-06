Imports System.Data.SqlClient
Public Class FrmApprovedHargaNego
    Public KodeApproved As String
    Dim dt As DataTable = New DataTable()
    Dim flagApproved, flagNotApproved As Integer
    '
    Private Sub FrmApprovedHargaNego_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If KodeApproved = 1 Then
            lblHead.Text = "Approved 1 - Harga Nego"
        ElseIf KodeApproved = 2 Then
            lblHead.Text = "Approved 2 - Harga Nego"
        ElseIf KodeApproved = 3 Then
            lblHead.Text = "Approved 3 - Harga Nego"
        End If

        DTPStart.Value = Format(Now, "dd/MM/yy")
        DTPEnd.Value = Format(Now, "dd/MM/yy")

        Modul_RMP.Combo.SetSupplier(cmbS_Petani)
        Modul_RMP.Combo.SetPancang(cmbPancang)
        Modul_RMP.Combo.SetKapal(cmbKapal)
    End Sub

    Private Sub chkPancang_CheckedChanged(sender As Object, e As EventArgs) Handles chkPancang.CheckedChanged
        Call UI.ChkCondCmb(chkPancang, cmbPancang, "Pancang")
    End Sub

    Private Sub cmbPancang_Validated(sender As Object, e As EventArgs) Handles cmbPancang.Validated
        chkPancang.Checked = IIf(cmbPancang.Text = "", False, True)
    End Sub

    Private Sub chkKapal_CheckedChanged(sender As Object, e As EventArgs) Handles chkKapal.CheckedChanged
        Call UI.ChkCondCmb(chkKapal, cmbKapal, "Kapal")
    End Sub
    Private Sub cmbKapal_Validated(sender As Object, e As EventArgs) Handles cmbKapal.Validated
        chkKapal.Checked = IIf(cmbKapal.Text = "", False, True)
    End Sub

    Private Sub chkTrip_CheckedChanged(sender As Object, e As EventArgs) Handles chkTrip.CheckedChanged
        Call UI.ChkCondCmb(chkTrip, cmbTrip, "Trip")
    End Sub

    Private Sub cmbTrip_Validated(sender As Object, e As EventArgs) Handles cmbTrip.Validated
        chkTrip.Checked = IIf(cmbTrip.Text = "", False, True)
    End Sub

    Sub LoadData()
        Try
            Dim i As Integer
            Dim sql, SQL2, SQL3, SQL4, SQL5, SQL6 As String

            If chkTransDate.Checked = True Then
                SQL2 = " AND CONVERT(DATETIME,CONVERT(VARCHAR, TransDate,103),103) BETWEEN CONVERT (DATETIME,'" & DTPStart.Value & "',103) AND CONVERT(DATETIME,'" & DTPEnd.Value & "',103)"

            End If

            If chkPancang.Checked = True Then
                SQL3 = " AND IDPancang = '" & cmbPancang.SelectedValue & "'"
            End If

            If chkKapal.Checked = True Then
                SQL4 = " AND IDKapal = '" & cmbKapal.SelectedValue.ToString & "'"
            End If

            If chkS_Petani.Checked = True Then
                SQL5 = " AND IDSubPetani = '" & cmbS_Petani.SelectedValue.ToString & "'"
            End If

            If chkTrip.Checked = True Then
                SQL6 = " AND Trip = '" & cmbTrip.Text & "'"
            End If

            If KodeApproved = 1 Then
                sql = " SELECT * FROM vwApproveHargaNegoNew WHERE HargaNego > 0 AND ApproveHargaNegoFlag = 0 AND NotApproveHargaNegoFlag = 0 "
            ElseIf KodeApproved = 2 Then
                sql = " SELECT * FROM vwApproveHargaNegoNew WHERE HargaNego > 0 AND ApproveHargaNegoFlag = 1 AND NotApproveHargaNegoFlag = 0 "
            ElseIf KodeApproved = 3 Then
                sql = " SELECT * FROM vwApproveHargaNegoNew WHERE HargaNego > 0 AND ApproveHargaNegoFlag = 2 AND NotApproveHargaNegoFlag = 0 "
            End If

            sql = sql + SQL2 + SQL3 + SQL4 + SQL5 + SQL6 + " order by TransID desc "

            Using koneksi As New SqlCommand(sql,DB.OpenConnection(StrConnRMPApp))
                Using DR = koneksi.ExecuteReader()
                    If DR.HasRows Then
                        dgvlist.RowCount = 0
                        While DR.Read
                            With dgvlist
                                .Rows.Add()
                                .Item("No", i).Value = i + 1
                                .Item("TRANSID", i).Value = DR!TransID
                                .Item("NONOTA", i).Value = DR!NoNota
                                .Item("TRANSDATE", i).Value = DR!Transdate
                                .Item("TANGGALNOTA", i).Value = DR!TanggalNota
                                .Item("CHECKINDATE", i).Value = DR!checkindate
                                .Item("IDPANCANG", i).Value = DR!IDPancang
                                .Item("PANCANG", i).Value = DR!Pancang
                                .Item("IDKAPAL", i).Value = DR!IDKapal
                                .Item("KAPAL", i).Value = DR!KapaL
                                .Item("TRIP", i).Value = DR!Trip
                                .Item("IDRELASI", i).Value = DR!IDrelasi
                                .Item("NAMARELASI", i).Value = DR!NamaRelasi

                                .Item("IDPETANI", i).Value = DR!IDSubPetani
                                .Item("PETANI", i).Value = DR!SubPetani

                                .Item("BRUTTO", i).Value = DR!Brutto
                                .Item("TARRAJARING", i).Value = DR!TarraJaring
                                .Item("NETTO", i).Value = DR!Netto
                                .Item("TARRAPERSEN", i).Value = DR!TarraPersen

                                .Item("NETTOAKHIR", i).Value = DR!NettoAkhir
                                .Item("HARGA", i).Value = DR!Harga
                                .Item("HARGANEGO", i).Value = DR!HargaNego
                                .Item("TOTALHARGA", i).Value = DR!TotalHarga
                                .Item("POTONGAN", i).Value = DR!Potongan
                                .Item("PPH", i).Value = DR!PphProsen
                                .Item("PPHPOTONGAN", i).Value = DR!Pphpotong
                                .Item("TOTALAKHIR", i).Value = DR!TotalRupiahAkhir


                                .Item("HARGASTLHNEGO", i).Value = DR!HargaStlhNego
                                .Item("TOTALHARGASTLHNEGO", i).Value = DR!TotalHargastlhNego
                                .Item("POTONGANSTLHNEGO", i).Value = DR!Potongan
                                .Item("PPHSTLHNEGO", i).Value = DR!PphProsen
                                .Item("POTONGANPPHSTLHNEGO", i).Value = DR!PphpotongstlhNego
                                .Item("TOTALAKHIRSTLHNEGO", i).Value = DR!TotalRupiahAkhirStlhNego

                                .Item("Remark", i).Value = DR!Remark

                                With Me.dgvlist
                                    '.AlternatingRowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                                    .Rows(i).Cells("HARGA").Style.BackColor = Color.MistyRose
                                    .Rows(i).Cells("TOTALHARGA").Style.BackColor = Color.MistyRose
                                    .Rows(i).Cells("PPH").Style.BackColor = Color.MistyRose
                                    .Rows(i).Cells("PPHPOTONGAN").Style.BackColor = Color.MistyRose
                                    .Rows(i).Cells("POTONGAN").Style.BackColor = Color.MistyRose
                                    .Rows(i).Cells("TOTALAKHIR").Style.BackColor = Color.MistyRose


                                    .Rows(i).Cells("HARGASTLHNEGO").Style.BackColor = Color.PaleGreen
                                    .Rows(i).Cells("TOTALHARGASTLHNEGO").Style.BackColor = Color.PaleGreen
                                    .Rows(i).Cells("PPHSTLHNEGO").Style.BackColor = Color.PaleGreen
                                    .Rows(i).Cells("POTONGANPPHSTLHNEGO").Style.BackColor = Color.PaleGreen
                                    .Rows(i).Cells("POTONGANSTLHNEGO").Style.BackColor = Color.PaleGreen
                                    .Rows(i).Cells("TOTALAKHIRSTLHNEGO").Style.BackColor = Color.PaleGreen



                                    If IsDBNull(DR!editharga) = False Then
                                        If DR!editharga = "1" Then
                                            .Rows(i).DefaultCellStyle.BackColor = Color.Pink
                                            .Rows(i).DefaultCellStyle.ForeColor = Color.Black
                                        End If
                                    End If

                                End With

                                If DR!IndUM = 1 Then
                                    .Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 192)
                                End If

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
        End Try
    End Sub


    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadData()
    End Sub

    Private Sub cbxAll_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAllApproved.CheckedChanged
        If (cbxAllApproved.Checked) Then
            For Each row As DataGridViewRow In dgvlist.Rows
                row.Cells("APPROVED").Value = True
                row.Cells("NOTAPPROVED").Value = False
            Next
        Else
            For Each row As DataGridViewRow In dgvlist.Rows
                row.Cells("APPROVED").Value = False
            Next
        End If
        cbxAllNotApproved.Checked = False
    End Sub

    Private Sub cbxAllNotApproved_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAllNotApproved.CheckedChanged
        If (cbxAllNotApproved.Checked) Then
            For Each row As DataGridViewRow In dgvlist.Rows
                row.Cells("NOTAPPROVED").Value = True
                row.Cells("APPROVED").Value = False
            Next
        Else
            For Each row As DataGridViewRow In dgvlist.Rows
                row.Cells("NOTAPPROVED").Value = False
            Next
        End If
        cbxAllApproved.Checked = False
    End Sub

    Private Sub btnexit_Click(sender As Object, e As EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub


    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        If dgvlist.RowCount = 0 Then
            MsgBox("Tidak Ada Data Yang Di Simpan ", vbExclamation)
            Exit Sub
        End If

        Call Savedata()
        Call LoadData()
    End Sub


    Sub Savedata()
        Me.Cursor = Cursors.WaitCursor
        Dim koneksis As SqlConnection = DB.OpenConnection(StrConnRMPApp)
        Dim Transaksi As SqlTransaction
        Dim QtyNotaApproved As Integer = 0
        Transaksi = koneksis.BeginTransaction

        Try
            For i As Integer = 0 To dgvlist.RowCount - 1
                If dgvlist.Rows(i).Cells("APPROVED").Value = True OrElse dgvlist.Rows(i).Cells("NOTAPPROVED").Value = True Then
                    If dgvlist.Rows(i).Cells("APPROVED").Value = True Then
                        flagApproved = KodeApproved
                        flagNotApproved = 0
                    Else
                        flagApproved = 0
                        flagNotApproved = KodeApproved
                    End If

                    If SimpanData(koneksis, Transaksi, i) = False Then
                        Transaksi.Rollback()
                        Me.Cursor = Cursors.Default
                        MsgBox("Simpan Data Gagal", vbExclamation, "Save Data - " & "")
                        Exit Sub
                    End If

                    QtyNotaApproved += 1
                End If
            Next i

            Transaksi.Commit()

            Modul_RMP.DB.ExecuteQuery(StrConnRMPApp,
                " INSERT INTO [192.168.12.12].[SMSGateway].[dbo].[TelegramOutbox] (DataFrom,ToTelegramID,FirstName,Messages) 
                  VALUES ('RMP-App','513289681','RIDWAN','Terdapat " & QtyNotaApproved & " nota menunggu persetujuan 3 harga nego, Mohon untuk segera di-approve.') "
            )

            MessageBox.Show("Save Completed !", "Save Data - " & "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Save Data Gagal Hdr " & "", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Transaksi.Rollback()
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function SimpanData(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal i As Integer) As Boolean
        Dim MyCMD As New SqlCommand
        SimpanData = False

        Try
            With MyCMD
                .Connection = Conn
                .CommandType = CommandType.StoredProcedure
                .CommandText = "RMPApp..spApprovedHargaNego2025"
                .Transaction = Trans
                .Parameters.Add("@TransID", SqlDbType.Int).Value = dgvlist.Item("TRANSID", i).Value
                .Parameters.Add("@flagApproved", SqlDbType.Int).Value = flagApproved
                .Parameters.Add("@flagNotApproved", SqlDbType.Int).Value = flagNotApproved
                .Parameters.Add("@ApproveHargaNegoBy", SqlDbType.VarChar).Value = ClsSession.UserID
                .Parameters.Add(New SqlParameter("@Error", SqlDbType.VarChar, 200, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
                .ExecuteNonQuery()
                .Dispose()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message & " infosp : " & MyCMD.Parameters("@Error").Value)
            Return False
        End Try
        Return True
    End Function

    Private Sub cmbS_Petani_Validated(sender As Object, e As EventArgs) Handles cmbS_Petani.Validated
        chkS_Petani.Checked = IIf(cmbS_Petani.Text = "", False, True)
    End Sub

    Private Sub dgvlist_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        FrmFotoNota.Foto = "Nota"
        FrmFotoNota.images = dgvlist.Item("TRANSID", dgvlist.CurrentRow.Index).Value
        FrmFotoNota.ShowDialog()
    End Sub
End Class