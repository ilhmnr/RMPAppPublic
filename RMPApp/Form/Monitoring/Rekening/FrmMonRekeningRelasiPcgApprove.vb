Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel

Public Class FrmMonRekeningRelasiPcgApprove
    Private Sub FrmMonRekeningRelasiPCG__Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvlist.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 140, 217)
        dgvlist.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvlist.EnableHeadersVisualStyles = False

        dgvlist.Columns("Approve1").HeaderCell.Style.BackColor = Color.FromArgb(36, 165, 169)
        dgvlist.Columns("Approve2").HeaderCell.Style.BackColor = Color.FromArgb(36, 165, 169)

        Combo.SetPancang(cboPancang)
        Combo.SetBank(cboBank)
    End Sub

    Private Sub txtCari_MouseClick(sender As Object, e As MouseEventArgs) Handles txtCari.MouseClick
        If txtCari.Text = "Search" Then txtCari.Text = String.Empty
    End Sub

    Private Sub txtCari_LostFocus(sender As Object, e As EventArgs) Handles txtCari.LostFocus
        If txtCari.Text = String.Empty Then txtCari.Text = "Search"
    End Sub
    Private Sub cboBank_MouseClick(sender As Object, e As MouseEventArgs) Handles cboBank.MouseClick
        If cboBank.Text = "Bank" Then cboBank.Text = String.Empty
    End Sub

    Private Sub cboBank_LostFocus(sender As Object, e As EventArgs) Handles cboBank.LostFocus
        If cboBank.Text = String.Empty Then cboBank.Text = "Bank"
    End Sub
    Private Sub cboPancang_MouseClick(sender As Object, e As MouseEventArgs) Handles cboPancang.MouseClick
        If cboPancang.Text = "Pancang" Then cboPancang.Text = String.Empty
    End Sub

    Private Sub cboPancang_LostFocus(sender As Object, e As EventArgs) Handles cboPancang.LostFocus
        If cboPancang.Text = String.Empty Then cboPancang.Text = "Pancang"
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadData()
    End Sub
    Sub LoadData()
        Dim i As Integer = 0
        Dim SQL, SQL1, SQL2, SQL3, SQL4, SQL5, SQL6, Approval As String

        If txtCari.Text = "Search" Then
            SQL1 = ""
        Else
            SQL1 = " and (IDPetani Like '%" & txtCari.Text & "%' or Petani like '%" & txtCari.Text & "%')"
        End If

        If dtp1.Checked = False Then
            SQL2 = ""
        Else
            SQL2 = "and ((convert(date,convert(varchar, CreatedDate,103),103) between convert (date,'" & Format(dtp1.Value, "yyyy-MM-dd") & "',23) and convert(date,'" & Format(dtp2.Value, "yyyy-MM-dd") & "',23))) "
        End If

        If dt3.Checked = False Then
            SQL3 = ""
        Else
            SQL3 = "and ((convert(date,convert(varchar, ApproveDate,103),103) between convert (date,'" & Format(dt3.Value, "yyyy-MM-dd") & "',23) and convert(date,'" & Format(dt4.Value, "yyyy-MM-dd") & "',23))) "
        End If


        If dt5.Checked = False Then
            SQL4 = ""
        Else
            SQL4 = "and ((convert(date,convert(varchar,ApproveDate2,103),103) between convert (date,'" & Format(dt5.Value, "yyyy-MM-dd") & "',23) and convert(date,'" & Format(dt6.Value, "yyyy-MM-dd") & "',23))) "
        End If


        'If cboPancang.Text = "Pancang" Then
        '    SQL3 = ""
        'Else
        '    SQL3 = " and (IDPancang = '" & cboPancang.SelectedValue & "')"
        'End If

        If cboBank.Text = "Bank" Then
            SQL5 = ""
        Else
            SQL5 = " and (JenisBank Like '%" & cboBank.Text & "%')"
        End If

        SQL = " Select * from RSUPAccounting..TblRMMstRekRM where Inactive = 0  "
        SQL = SQL + SQL1 + SQL2 + SQL3 + SQL4 + SQL5 + "  ORDER BY CREATEDDATE DESC "

        'SQL = "Select B.IDPancang,B.Pancang,A.IDPetani,A.Petani,B.AlamatPenerimaUang,A.NamaRekening,A.IDNoRek,A.NoRekening,A.JenisBank,A.InActive,A.InActiveBy,A.InActiveDate,A.CreatedBy,A.CreatedDate, A.UpdatedBy,A.UpdatedDate,
        '       A.ApproveBy, A.ApproveDate, A.ApproveBy2, A.ApproveDate2, A.Approval, A.Ditolak From RSUPAccounting..TblRMMstRekRM AS A INNER Join RMPApp..vwTMBGKelapaHdr AS B ON A.IDPetani = B.IDPenerimaUang Where b.Deleted = 0 "

        'SQL = SQL + SQL1 + SQL2 + SQL3 + SQL4 + " GROUP by B.IDPancang, b.Pancang, a.IDPetani, a.Petani, b.AlamatPenerimaUang, a.NamaRekening, a.IDNoRek, a.NoRekening, a.JenisBank, a.InActive, a.InActiveBy, a.InActiveDate, a.CreatedBy, a.CreatedDate,A.UpdatedBy,A.UpdatedDate,
        '                      A.ApproveBy, A.ApproveDate, A.ApproveBy2, A.ApproveDate2, A.Approval, A.Ditolak ORDER by CreatedDate desc"

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
                                .Item("CreatedBy", i).Value = DR!CreatedBy
                                .Item("CreatedDate", i).Value = DR!CreatedDate
                                .Item("Ditolak", i).Value = DR!Ditolak
                                .Item("Approve1", i).Value = DR!ApproveBy + "   -   " + DR!ApproveDate
                                .Item("Approve2", i).Value = DR!ApproveBy2 + "   -   " + DR!ApproveDate2
                                .Item("InActive", i).Value = DR!InActive
                                '.Item("IDPancang", i).Value = DR!IDPancang
                                '.Item("Pancang2", i).Value = DR!Pancang
                                '.Item("Alamat", i).Value = DR!AlamatPenerimaUang
                                If IsDBNull(DR!UpdatedDate) Then .Item("UpdatedDate", i).Value = "" Else .Item("UpdatedDate", i).Value = DR!UpdatedDate
                                If IsDBNull(DR!UpdatedBy) Then .Item("UpdatedBy", i).Value = "" Else .Item("UpdatedBy", i).Value = DR!UpdatedBy
                                If IsDBNull(DR!Approval) Then .Item("Approval", i).Value = "" Else .Item("Approval", i).Value = DR!Approval
                                If IsDBNull(DR!AlasanDitolak) Then .Item("AlasanDitolak", i).Value = "" Else .Item("AlasanDitolak", i).Value = DR!AlasanDitolak
                                If IsDBNull(DR!RemarksApproval1) Then .Item("Remarks1", i).Value = "" Else .Item("Remarks1", i).Value = DR!RemarksApproval1
                                If IsDBNull(DR!RemarksApproval2) Then .Item("Remarks2", i).Value = "" Else .Item("Remarks2", i).Value = DR!RemarksApproval2

                                With Me.dgvlist
                                    .RowsDefaultCellStyle.BackColor = Color.White
                                    .AlternatingRowsDefaultCellStyle.BackColor = Color.White
                                    .Rows(i).Cells("No").Style.BackColor = Color.FromArgb(240, 240, 240)
                                End With

                                For r As Integer = 0 To dgvlist.Rows.Count - 1
                                    If dgvlist.Rows(r).Cells("Approval").Value = "0" Then
                                        dgvlist.Rows(r).DefaultCellStyle.BackColor = Color.FromArgb(246, 245, 180)
                                    ElseIf dgvlist.Rows(r).Cells("Approval").Value = "1" Then
                                        dgvlist.Rows(r).DefaultCellStyle.BackColor = Color.FromArgb(173, 216, 230)
                                    ElseIf dgvlist.Rows(r).Cells("Ditolak").Value = True Then
                                        dgvlist.Rows(r).DefaultCellStyle.BackColor = Color.FromArgb(247, 145, 147)
                                    End If
                                Next

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

    Private Sub dtp1_ValueChanged(sender As Object, e As EventArgs) Handles dtp1.ValueChanged
        If dtp1.Checked = True Then
            dtp2.Enabled = True
        ElseIf dtp1.Checked = False Then
            dtp2.Enabled = False
            dtp1.Value = Now
            dtp2.Value = Now
        End If
    End Sub

    Private Sub dtp2_ValueChanged(sender As Object, e As EventArgs) Handles dtp2.ValueChanged
        dgvlist.Rows.Clear()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub dt6_ValueChanged(sender As Object, e As EventArgs) Handles dt5.ValueChanged
        If dt5.Checked = True Then
            dt6.Enabled = True

        ElseIf dt5.Checked = False Then
            dt6.Enabled = False
            dt5.Value = Now
            dt6.Value = Now
        End If
    End Sub

    Private Sub dt3_ValueChanged(sender As Object, e As EventArgs) Handles dt3.ValueChanged
        If dt3.Checked = True Then
            dt4.Enabled = True

        ElseIf dt3.Checked = False Then
            dt4.Enabled = False
            dt3.Value = Now
            dt4.Value = Now
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call ExportToExcel()
    End Sub

    Private Sub ExportToExcel()

        If dgvlist.Rows.Count = 0 Then
            MessageBox.Show("Tidak ada data untuk diexport.")
            Exit Sub
        End If

        Using sfd As New SaveFileDialog
            sfd.Filter = "Excel Files|*.xlsx"
            sfd.FileName = "Export.xlsx"

            If sfd.ShowDialog() <> DialogResult.OK Then Exit Sub

            Dim xlApp As New Excel.Application
            Dim xlWorkBook As Excel.Workbook = xlApp.Workbooks.Add()
            Dim xlSheet As Excel.Worksheet = xlWorkBook.Sheets(1)

            Dim excelCol As Integer = 1

            'Hanya kolom yang tampil
            For dgvCol As Integer = 0 To dgvlist.Columns.Count - 1

                If dgvlist.Columns(dgvCol).Visible Then

                    'Header
                    Dim headerCell As Excel.Range =
                    xlSheet.Cells(1, excelCol)

                    headerCell.Value = dgvlist.Columns(dgvCol).HeaderText

                    'Warna header
                    Dim headerColor = dgvlist.ColumnHeadersDefaultCellStyle.BackColor

                    If headerColor <> Color.Empty Then
                        headerCell.Interior.Color =
                        ColorTranslator.ToOle(headerColor)
                    End If

                    'Font header
                    headerCell.Font.Bold = True
                    headerCell.Font.Color =
                    ColorTranslator.ToOle(
                        dgvlist.ColumnHeadersDefaultCellStyle.ForeColor
                    )

                    'Data
                    Dim excelRow As Integer = 2

                    For dgvRow As Integer = 0 To dgvlist.Rows.Count - 1

                        If Not dgvlist.Rows(dgvRow).IsNewRow Then

                            Dim dgvCell =
                            dgvlist.Rows(dgvRow).Cells(dgvCol)

                            Dim excelCell As Excel.Range =
                            xlSheet.Cells(excelRow, excelCol)

                            'Value
                            If dgvCell.Value IsNot Nothing Then
                                excelCell.Value = dgvCell.Value
                            End If

                            'Warna cell
                            If dgvCell.InheritedStyle.BackColor <> Color.Empty Then
                                excelCell.Interior.Color =
                                ColorTranslator.ToOle(
                                    dgvCell.InheritedStyle.BackColor
                                )
                            End If

                            'Warna font
                            If dgvCell.InheritedStyle.ForeColor <> Color.Empty Then
                                excelCell.Font.Color =
                                ColorTranslator.ToOle(
                                    dgvCell.InheritedStyle.ForeColor
                                )
                            End If

                            'Bold
                            excelCell.Font.Bold =
                            dgvCell.InheritedStyle.Font.Bold

                            excelRow += 1

                        End If

                    Next

                    'Lebar kolom
                    xlSheet.Columns(excelCol).AutoFit()

                    excelCol += 1

                End If

            Next

            'Simpan
            xlWorkBook.SaveAs(sfd.FileName)
            xlWorkBook.Close()
            xlApp.Quit()

            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlSheet)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp)

            MessageBox.Show("Export berhasil.", "Informasi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)

        End Using

    End Sub
End Class