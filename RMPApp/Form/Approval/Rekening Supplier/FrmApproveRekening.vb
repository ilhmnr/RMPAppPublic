Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Public Class FrmApproveRekening
    Public KodeApproval As String
    Private Sub FrmMstSupRekApproval_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dgvlist.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 140, 217)
        dgvlist.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvlist.EnableHeadersVisualStyles = False
        btnEXCEL.Visible = True
        LoadSkin()
        LoadData() '...
    End Sub

    Sub LoadData()
        Dim i As Integer = 0
        Dim SQL, SQL1, Approval As String

        If KodeApproval = 1 Then
            Approval = 0

        ElseIf KodeApproval = 2 Then
            Approval = 1

        ElseIf KodeApproval = 3 Then
            Approval = 2
        End If


        If txtCari.Text = "IDPetani/ Petani" Then
            SQL1 = ""
        Else
            SQL1 = " and (IDPetani Like '%" & txtCari.Text & "%' or Petani like '%" & txtCari.Text & "%')"
        End If

        SQL = "SELECT * FROM RSUPAccounting..TblRMMstRekRM where Ditolak = 0 and InActive = 0 and Approval = " & Approval & " "


        SQL = SQL + SQL1 + " ORDER BY CreatedDate desc"

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
                                .Item("IDNoRek", i).Value = DR!IDNoRek
                                .Item("JenisBank", i).Value = DR!JenisBank
                                .Item("NoRekening", i).Value = DR!NoRekening
                                .Item("IDPetani", i).Value = DR!IDPetani
                                .Item("Petani", i).Value = DR!Petani
                                .Item("NamaRekening", i).Value = DR!NamaRekening

                                If KodeApproval = 2 Then
                                    If IsDBNull(DR!RemarksApproval1) Then .Item("Remarks", i).Value = "" Else .Item("Remarks", i).Value = DR!RemarksApproval1

                                ElseIf KodeApproval = 1 Then
                                    If IsDBNull(DR!RemarksApproval1) Then .Item("Remarks", i).Value = "" Else .Item("Remarks", i).Value = DR!RemarksApproval1

                                ElseIf KodeApproval = 0 Then
                                    If IsDBNull(DR!RemarksApproval1) Then .Item("Remarks", i).Value = "" Else .Item("Remarks", i).Value = DR!RemarksApproval1

                                End If

                                .Item("CreatedBy", i).Value = DR!CreatedBy
                                .Item("CreatedDate", i).Value = DR!CreatedDate
                                .Item("Computer", i).Value = DR!Computer
                                If IsDBNull(DR!UpdatedDate) Then .Item("UpdatedDate", i).Value = "" Else .Item("UpdatedDate", i).Value = DR!UpdatedDate
                                If IsDBNull(DR!UpdatedBy) Then .Item("UpdatedBy", i).Value = "" Else .Item("UpdatedBy", i).Value = DR!UpdatedBy

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
    Sub LoadSkin()
        If KodeApproval = 1 Then
            lblHead.Text = "Approved 1 - Rekening Relasi"
            Me.Text = "Approved 1 - Rekening Relasi"

        ElseIf KodeApproval = 2 Then
            lblHead.Text = "Approved 2 - Rekening Relasi"
            Me.Text = "Approved 2 - Rekening Relasi"
            dgvlist.Columns("Remarks").ReadOnly = True
        End If
    End Sub
    Private Sub cbxAll_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAll.CheckedChanged
        If (cbxAll.Checked) Then
            For Each row As DataGridViewRow In dgvlist.Rows
                row.Cells("Check").Value = True
            Next
        Else
            For Each row As DataGridViewRow In dgvlist.Rows
                row.Cells("Check").Value = False
            Next
        End If
    End Sub

    Private Sub rdDitolak_CheckedChanged(sender As Object, e As EventArgs) Handles rdDitolak.CheckedChanged
        If rdDitolak.Checked = True Then
            txtAlasan.Visible = True
            lblAlasanDitolak.Visible = True
            lblAlasanDitolak.Visible = True
            pnlAlasanDitolak.Visible = True
            btnsave.Visible = True
            btnEXCEL.Visible = True
        End If
    End Sub

    Private Sub rdDisetujui_CheckedChanged(sender As Object, e As EventArgs) Handles rdDisetujui.CheckedChanged
        If rdDisetujui.Checked = True Then
            txtAlasan.Visible = False
            lblAlasanDitolak.Visible = False
            lblAlasanDitolak.Visible = False
            pnlAlasanDitolak.Visible = False
            btnsave.Visible = True
            btnEXCEL.Visible = True
        End If
    End Sub
    Sub reset()
        cbxAll.Checked = False
        rdDisetujui.Checked = False
        rdDitolak.Checked = False
        btnsave.Visible = False
        btnEXCEL.Visible = True
        txtAlasan.Text = "Alasan"
        lblAlasanDitolak.Visible = False
        txtAlasan.Visible = False
        pnlAlasanDitolak.Visible = False
    End Sub
    Private Sub txtCari_MouseClick(sender As Object, e As MouseEventArgs) Handles txtCari.MouseClick
        If txtCari.Text = "IDPetani/ Petani" Then txtCari.Text = String.Empty
    End Sub

    Private Sub txtAlasan_MouseClick(sender As Object, e As MouseEventArgs) Handles txtAlasan.MouseClick
        If txtAlasan.Text = "Alasan" Then txtAlasan.Text = String.Empty
    End Sub

    Private Sub txtCari_LostFocus(sender As Object, e As EventArgs) Handles txtCari.LostFocus
        If txtCari.Text = String.Empty Then txtCari.Text = "IDPetani/ Petani"
    End Sub

    Private Sub txtAlasan_LostFocus(sender As Object, e As EventArgs) Handles txtAlasan.LostFocus
        If txtAlasan.Text = String.Empty Then txtAlasan.Text = "Alasan"
    End Sub

    Private Sub btnexit_Click(sender As Object, e As EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            If MsgBox("Yakin ingin update data ini ? ", vbQuestion + vbYesNo) = vbYes Then

                If KodeApproval = 1 Then
                    Select Case ClsSession.RoleName
                        Case "KADEP/WAKADEP RMD"
                            If rdDisetujui.Checked = False And rdDitolak.Checked = False Then
                                MsgBox("ceklis Di tolak / Di setujui !", MsgBoxStyle.Information)
                                Exit Sub
                            End If

                            If rdDitolak.Checked = True And txtAlasan.Text = "Alasan" Then
                                MsgBox("Masukkan Alasan Penolakan Terlebih Dahulu !", MsgBoxStyle.Exclamation)
                                txtAlasan.Focus()
                                Exit Sub
                            Else
                                SimpanApprove()
                                SimpanApproveRMP()
                            End If

                        Case Else
                            MsgBox("Approval 1 hanya boleh di approve oleh Bapak Suhaimi !", MsgBoxStyle.Information)
                            Exit Sub
                    End Select
                ElseIf KodeApproval = 2 Then
                    Select Case ClsSession.RoleName
                        Case "MANAGER"
                            If rdDisetujui.Checked = False And rdDitolak.Checked = False Then
                                MsgBox("ceklis Di tolak / Di setujui !", MsgBoxStyle.Information)
                                Exit Sub
                            End If
                            If rdDitolak.Checked = True And txtAlasan.Text = "Alasan" Then
                                MsgBox("Masukkan Alasan Penolakan Terlebih Dahulu !", MsgBoxStyle.Exclamation)
                                txtAlasan.Focus()
                                Exit Sub
                            Else
                                SimpanApprove()
                                SimpanApproveRMP()
                            End If
                        Case Else
                            MsgBox("Approval 2 hanya boleh di approve oleh Mr. CHEN HUAN CHUN, ", MsgBoxStyle.Information)
                            Exit Sub
                    End Select
                Else
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            
        End Try
        MsgBox("Data berhasil di approve", MsgBoxStyle.Information)
        btnsave.Visible = False
        btnEXCEL.Visible = True
        Call reset()
        Call LoadData()
    End Sub

    Sub SimpanApprove()
        Dim X As Integer = 0
        Dim Dg As DataGridView = dgvlist
        Dim ditolak As Boolean
        Dim TrackApv, NameApv, DateApv, Remarks As String

        If KodeApproval = 1 Then
            TrackApv = "1"
            NameApv = "ApproveBy"
            DateApv = "ApproveDate"
            Remarks = "RemarksApproval1"
        ElseIf KodeApproval = 2 Then
            TrackApv = "2"
            NameApv = "ApproveBy2"
            DateApv = "ApproveDate2"
            Remarks = "RemarksApproval2"
        End If

        If rdDisetujui.Checked = True Then
            ditolak = 0
        ElseIf rdDitolak.Checked = True Then
            ditolak = 1
        End If

        For i As Integer = 0 To Dg.RowCount - 1
            If Dg.Rows(i).Cells("Check").Value = True Then X = X + 1
        Next i


        If X = 0 Then
            MsgBox("Tidak ada data yg diCheck !", MsgBoxStyle.Exclamation)
            Exit Sub
        Else

            For i As Integer = 0 To Dg.RowCount - 1
                If Dg.Rows(i).Cells("Check").Value = True Then
                    'Try
                    Dim cmd = New SqlCommand

                    If KodeApproval = 1 Then
                        cmd.CommandText = "Update RSUPAccounting..TblRMMstRekRM SET Approval = @Approval, " & NameApv & " = @NameApv, " & DateApv & " = @DateApv , " &
                                          " Ditolak = @Ditolak, AlasanDitolak = @AlasanDitolak, " & Remarks & "= @RemarksApproval                                     
                                          where IDNoRek = '" & dgvlist.Item("IDNoRek", i).Value & "'"
                    ElseIf KodeApproval = 2 Then
                        cmd.CommandText = "Update RSUPAccounting..TblRMMstRekRM SET Approval = @Approval, " & NameApv & " = @NameApv, " & DateApv & " = @DateApv , " &
                                          " Ditolak = @Ditolak, AlasanDitolak = @AlasanDitolak                                   
                                           where IDNoRek = '" & dgvlist.Item("IDNoRek", i).Value & "'"
                    End If

                    cmd.Parameters.Add("@Approval", SqlDbType.VarChar).Value = TrackApv
                    cmd.Parameters.Add("@NameApv", SqlDbType.VarChar).Value = ClsSession.UserID
                    cmd.Parameters.Add("@DateApv", SqlDbType.DateTime).Value = DB.GetDate()
                    cmd.Parameters.Add("@Ditolak", SqlDbType.Bit).Value = ditolak

                    If (dgvlist.Item("Remarks", i).Value Is Nothing) Then
                        cmd.Parameters.Add("@RemarksApproval", SqlDbType.VarChar).Value = DBNull.Value
                    Else
                        cmd.Parameters.Add("@RemarksApproval", SqlDbType.VarChar).Value = UCase(dgvlist.Item("Remarks", i).Value).ToString
                    End If


                    If txtAlasan.Text = "Alasan" Then
                        cmd.Parameters.Add("@AlasanDitolak", SqlDbType.Text).Value = ""
                    Else
                        cmd.Parameters.Add("@AlasanDitolak", SqlDbType.Text).Value = txtAlasan.Text
                    End If

                    cmd.Connection = DB.OpenConnection(StrConnAccounting)
                    cmd.ExecuteNonQuery()

                    'Catch ex As Exception
                    '    MsgBox(ex.Message, MsgBoxStyle.Critical)
                    '    'GetErrorLog("353756059", Me, ex.ToString)
                    '    Exit Sub
                    'End Try
                End If
            Next
        End If
    End Sub
    Sub SimpanApproveRMP()
        Dim X As Integer = 0
        Dim Dg As DataGridView = dgvlist
        Dim ditolak As Boolean
        Dim TrackApv, NameApv, DateApv, Remarks As String

        If KodeApproval = 1 Then
            TrackApv = "1"
            NameApv = "ApproveBy"
            DateApv = "ApproveDate"
            Remarks = "RemarksApproval1"
        ElseIf KodeApproval = 2 Then
            TrackApv = "2"
            NameApv = "ApproveBy2"
            DateApv = "ApproveDate2"
            Remarks = "RemarksApproval1"
        End If

        If rdDisetujui.Checked = True Then
            ditolak = 0
        ElseIf rdDitolak.Checked = True Then
            ditolak = 1
        End If

        For i As Integer = 0 To Dg.RowCount - 1
            If Dg.Rows(i).Cells("Check").Value = True Then X = X + 1
        Next i

        If X = 0 Then
            MsgBox("Tidak ada data yg diCheck !", MsgBoxStyle.Exclamation)
            Exit Sub
        Else

            For i As Integer = 0 To Dg.RowCount - 1
                If Dg.Rows(i).Cells("Check").Value = True Then
                    Try
                        Dim cmd = New SqlCommand

                        If KodeApproval = 1 Then
                            cmd.CommandText = "Update RMPApp..tblMstNoRekBank SET Approval = @Approval, " & NameApv & " = @NameApv, " & DateApv & " = @DateApv , " &
                                              " Ditolak = @Ditolak, AlasanDitolak = @AlasanDitolak, " & Remarks & "= @RemarksApproval                             
                                               where NoRek = '" & dgvlist.Item("NoRekening", i).Value & "'"
                        ElseIf KodeApproval = 2 Then
                            cmd.CommandText = "Update RMPApp..tblMstNoRekBank SET Approval = @Approval, " & NameApv & " = @NameApv, " & DateApv & " = @DateApv , " &
                                           " Ditolak = @Ditolak, AlasanDitolak = @AlasanDitolak                           
                                               where NoRek = '" & dgvlist.Item("NoRekening", i).Value & "'"
                        End If

                        cmd.Parameters.Add("@Approval", SqlDbType.VarChar).Value = TrackApv
                        cmd.Parameters.Add("@NameApv", SqlDbType.VarChar).Value = ClsSession.UserID
                        cmd.Parameters.Add("@DateApv", SqlDbType.DateTime).Value = DB.GetDate()
                        cmd.Parameters.Add("@Ditolak", SqlDbType.Bit).Value = ditolak

                        If (dgvlist.Item("Remarks", i).Value Is Nothing) Then
                            cmd.Parameters.Add("@RemarksApproval", SqlDbType.VarChar).Value = DBNull.Value
                        Else
                            cmd.Parameters.Add("@RemarksApproval", SqlDbType.VarChar).Value = UCase(dgvlist.Item("Remarks", i).Value).ToString
                        End If



                        If txtAlasan.Text = "Alasan" Then
                            cmd.Parameters.Add("@AlasanDitolak", SqlDbType.Text).Value = ""
                        Else
                            cmd.Parameters.Add("@AlasanDitolak", SqlDbType.Text).Value = txtAlasan.Text
                        End If

                        cmd.Connection = DB.OpenConnection(StrConnAccounting)
                        cmd.ExecuteNonQuery()

                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                        'GetErrorLog("353756059", Me, ex.ToString)
                        Exit Sub
                        End Try
                    End If
                Next
        End If
    End Sub

    Private Sub txtCari_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCari.KeyPress
        If (e.KeyChar = Chr(13)) Then
            LoadData()
        End If
    End Sub



    Sub ExportExcel(ByVal obj As Object)
        Dim xlapp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim i As Integer
        Dim j As Integer

        xlapp = New Excel.Application
        xlWorkBook = xlapp.Workbooks.Add(misValue)
        xlWorkSheet = CType(xlWorkBook.Sheets("Sheet1"), Excel.Worksheet)

        For k = 0 To dgvlist.ColumnCount - 1
            xlWorkSheet.Cells(1, k + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            xlWorkSheet.Cells(1, k + 1) = dgvlist.Columns(k).Name
        Next
        For i = 0 To dgvlist.RowCount - 1
            For j = 2 To 10
                xlWorkSheet.Cells(i + 2, j + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                xlWorkSheet.Cells(i + 2, j + 1) = IIf(IsNothing((dgvlist(j, i).Value.ToString())) = True, "", (dgvlist(j, i).Value.ToString()))

            Next
        Next

        Dim SaveFileDialog1 As New SaveFileDialog()
        SaveFileDialog1.Filter = "Execl files (*.xlsx)|*.xlsx"
        SaveFileDialog1.FilterIndex = 2
        SaveFileDialog1.RestoreDirectory = True
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            xlWorkSheet.SaveAs(SaveFileDialog1.FileName)
            MsgBox("Save file success")
        Else
            Return
        End If
        xlWorkBook.Close()
        xlapp.Quit()
    End Sub

    Private Sub btnEXCEL_Click(sender As Object, e As EventArgs) Handles btnEXCEL.Click
        ExportExcel(dgvlist)
    End Sub
End Class