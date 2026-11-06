Imports System.Data.SqlClient

Public Class FrmMonRekeningRelasiPcg
    Public Print As Integer
    Private Sub FrmMonRekeningRelasiPCG___Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'dtp1.Value = Format(Now, "yyyy-MM-dd")
        'dtp2.Value = Format(Now, "yyyy-MM-dd")
        dgvlist.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 140, 217)
        dgvlist.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvlist.EnableHeadersVisualStyles = False

        dgvlist2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(36, 165, 169)
        dgvlist2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvlist2.EnableHeadersVisualStyles = False

        Combo.SetPancang(cboPancang)
        Combo.SetPancang(cboPancang2)
        Combo.SetBank(cboBank)
        cboBank.SelectedIndex = -1
        cboBank.Text = "Bank"
        cboPancang2.SelectedIndex = -1
        cboPancang2.Text = "Pancang"

    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        txtSQL.Clear()
        Call LoadData()
    End Sub

    Private Sub txtCari_MouseClick(sender As Object, e As MouseEventArgs) Handles txtCari.MouseClick
        If txtCari.Text = "Search" Then txtCari.Text = String.Empty
    End Sub
    Private Sub txtCari_LostFocus(sender As Object, e As EventArgs) Handles txtCari.LostFocus
        If txtCari.Text = String.Empty Then txtCari.Text = "Search"
    End Sub
    Private Sub txtCari2_MouseClick(sender As Object, e As MouseEventArgs) Handles txtCari2.MouseClick
        If txtCari2.Text = "Search" Then txtCari2.Text = String.Empty
    End Sub
    Private Sub txtCari2_LostFocus(sender As Object, e As EventArgs) Handles txtCari2.LostFocus
        If txtCari2.Text = String.Empty Then txtCari2.Text = "Search"
    End Sub
    Private Sub cboPancang_LostFocus(sender As Object, e As EventArgs) Handles cboPancang.LostFocus
        If cboPancang.Text = String.Empty Then cboPancang.Text = "Pancang"
    End Sub

    Private Sub cboPancang_MouseClick(sender As Object, e As MouseEventArgs) Handles cboPancang.MouseClick
        If cboPancang.Text = "Pancang" Then cboPancang.Text = String.Empty
    End Sub
    Private Sub cboPancang2_LostFocus(sender As Object, e As EventArgs) Handles cboPancang2.LostFocus
        If cboPancang2.Text = String.Empty Then cboPancang2.Text = "Pancang"
    End Sub

    Private Sub cboPancang2_MouseClick(sender As Object, e As MouseEventArgs) Handles cboPancang2.MouseClick
        If cboPancang2.Text = "Pancang" Then cboPancang2.Text = String.Empty
    End Sub
    Private Sub cboBank_LostFocus(sender As Object, e As EventArgs) Handles cboBank.LostFocus
        If cboBank.Text = String.Empty Then cboBank.Text = "Bank"
    End Sub

    Private Sub cboBank_MouseClick(sender As Object, e As MouseEventArgs) Handles cboBank.MouseClick
        If cboBank.Text = "Bank" Then cboBank.Text = String.Empty
    End Sub

    Sub LoadData()
        Dim i As Integer = 0
        Dim SQL, SQL1, SQL2, SQL3, SQL4, SQL5, SQL6, SQL7 As String

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

        If cboPancang.Text = "Pancang" Then
            SQL3 = ""
        Else
            SQL3 = " and (IDPancang = '" & cboPancang.SelectedValue & "')"
        End If


        If chkkelapa.Checked = True Then
            SQL5 = " and (ID_Jenis_Rek = '1') "

        End If


        
        If CHKUBM.Checked = True Then
            SQL6 = " and (ID_Jenis_RekUBM = '1') "

        End If


        
        If chkub.Checked = True Then
            SQL7= " and (ID_Jenis_RekUB= '1') "

        End If



        If chkNotActive.Checked = False Then
            SQL4 = ""
        Else
            SQL4 = " and (InActive = 1) "
        End If

        SQL = "SELECT * from RMPApp..vwmonrekapproval where IDPancang is not null "
        SQL = SQL + SQL1 + SQL2 + SQL3 + SQL4 +
            " GROUP BY ID_Jenis_Rek , ID_Jenis_RekUBM, ID_Jenis_RekUB , IDPancang,Pancang,IDPetani,Petani,AlamatPenerimaUang,NamaRekening,IDNoRek,NoRekening,JenisBank,DivBlokKav,InActive,InActiveBy,InActiveDate,CreatedBy,CreatedDate,ApproveDate,ApproveDate2 ORDER BY CreatedDate"

        txtSQL.Text = SQL
        Try
            Me.Cursor = Cursors.WaitCursor
            Using koneksi As New SqlCommand(SQL, DB.OpenConnection(StrConnRMPApp))
                Using DR = koneksi.ExecuteReader
                    dgvlist.Rows.Clear()

                    If DR.HasRows Then
                        dgvlist.RowCount = 0
                        While DR.Read
                            With dgvlist

                                .Rows.Add()
                                .Item("No", i).Value = i + 1
                                .Item("IDPancang", i).Value = DR!IDPancang
                                .Item("Pancang", i).Value = DR!Pancang
                                .Item("IDPetani", i).Value = DR!IDPetani
                                .Item("Petani", i).Value = DR!Petani
                                .Item("AlamatPenerimaUang", i).Value = DR!AlamatPenerimaUang
                                .Item("NamaRekening", i).Value = DR!NamaRekening
                                .Item("IDNoRek", i).Value = DR!IDNoRek
                                .Item("NoRekening", i).Value = DR!NoRekening
                                .Item("JenisBank", i).Value = DR!JenisBank
                                .Item("DivBlokKav", i).Value = DR!DivBlokKav
                                .Item("InActive", i).Value = DR!InActive
                                If IsDBNull(DR!CreatedBy) Then .Item("Create", i).Value = "" Else .Item("Create", i).Value = DR!CreatedBy + "   -   " + DR!CreatedDate

                                With Me.dgvlist
                                    .RowsDefaultCellStyle.BackColor = Color.White
                                    .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(195, 229, 247)
                                    .Rows(i).Cells("No").Style.BackColor = Color.FromArgb(240, 240, 240)
                                End With

                                For r As Integer = 0 To dgvlist.Rows.Count - 1
                                    If dgvlist.Rows(r).Cells("InActive").Value = True Then
                                        dgvlist.Rows(r).DefaultCellStyle.ForeColor = Color.Red
                                    End If
                                Next

                            End With
                            i += 1
                        End While
                    Else
                        dgvlist.Rows.Clear()
                        MsgBox("Data Tidak ditemukan ! ", MsgBoxStyle.Information)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    DR.Close()
                End Using
            End Using
            Me.Cursor = Cursors.Default
            DB.CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            
            
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub ShowDataRekening()
        Dim SQL As String
        Dim SQL1, SQL2, SQL3, SQL4 As String
        Dim i As Integer = 0

        If txtCari2.Text = "Search" Then
            SQL1 = ""
        Else
            SQL1 = " and (a.IDPetani = '" & txtCari2.Text & "' or a.Petani like '%" & txtCari2.Text & "%')"
        End If

        If dtp1a.Checked = False Then
            SQL2 = ""
        Else
            SQL2 = "and ((convert(date,convert(varchar, A.CreatedDate,103),103) between convert (date,'" & Format(dtp1a.Value, "yyyy-MM-dd") & "',23) and convert(date,'" & Format(dtp2a.Value, "yyyy-MM-dd") & "',23))) "
        End If

        If cboPancang2.Text = "Pancang" Then
            SQL3 = ""
        Else
            SQL3 = " and (IDPancang = '" & cboPancang2.SelectedValue & "')"
        End If

        If chkNotActive2.Checked = False Then
            SQL4 = ""
        Else
            SQL4 = " and (InActive = 1) "
        End If

        If cboBank.Text = "Bank" Then
            SQL3 = ""
        Else
            SQL3 = " and (a.JenisBank Like '%" & cboBank.Text & "%')"
        End If

        SQL = " Select b.DivBlokKav,b.Pancang,b.IDPancang,b.Approve1Date,b.Approve2Date , * from RSUPAccounting..TblRMMstRekRM as A INNER JOIN 
                RMPApp..vwAndroid_MstPancang__ as B on A.IDPetani = B.RMPSupplierID  where RMPSupplierID is not null "

        SQL = SQL + SQL1 + SQL2 + SQL3 + SQL4
        txtSQL2.Text = SQL

        Try
            Me.Cursor = Cursors.WaitCursor
            Using koneksi As New SqlCommand(SQL, DB.OpenConnection(StrConnRMPApp))
                Using DR = koneksi.ExecuteReader
                    dgvlist2.RowCount = 0
                    If DR.HasRows Then
                        Do While DR.Read
                            With dgvlist2
                                .Rows.Add()
                                .Item("No2", i).Value = i + 1
                                .Item("IDPetani2", i).Value = DR!IDPetani
                                .Item("Petani2", i).Value = DR!Petani
                                .Item("IDNoRek2", i).Value = DR!IDNoRek
                                .Item("NamaRekening2", i).Value = DR!NamaRekening
                                If IsDBNull(DR!IDPancang) Then .Item("IDPancang2", i).Value = "" Else .Item("IDPancang2", i).Value = DR!IDPancang
                                If IsDBNull(DR!Pancang) Then .Item("Pancang2", i).Value = "" Else .Item("Pancang2", i).Value = DR!Pancang
                                If IsDBNull(DR!DivBlokKav) Then .Item("DivBlokKav2", i).Value = "" Else .Item("DivBlokKav2", i).Value = DR!DivBlokKav
                                If IsDBNull(DR!NoRekening) Then .Item("NoRekening2", i).Value = "" Else .Item("NoRekening2", i).Value = DR!NoRekening
                                If IsDBNull(DR!JenisBank) Then .Item("JenisBank2", i).Value = "" Else .Item("JenisBank2", i).Value = DR!JenisBank
                                If IsDBNull(DR!InActive) Then .Item("InActive2", i).Value = "" Else .Item("InActive2", i).Value = DR!InActive
                                If IsDBNull(DR!CreatedBy) Then .Item("Created", i).Value = "" Else .Item("Created", i).Value = DR!CreatedBy + "  -  " + DR!CreatedDate
                                If IsDBNull(DR!UpdatedBy) Then .Item("Update", i).Value = "" Else .Item("Update", i).Value = DR!UpdatedBy + "  -  " + DR!UpdatedDate
                                If IsDBNull(DR!RemarksApproval1) Then .Item("RemarksApproval1", i).Value = "" Else .Item("RemarksApproval1", i).Value = DR!RemarksApproval1

                                With Me.dgvlist2
                                    .RowsDefaultCellStyle.BackColor = Color.White
                                    .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(190, 225, 202)
                                    .Rows(i).Cells("no2").Style.BackColor = Color.FromArgb(240, 240, 240)
                                End With
                            End With
                            i += 1
                        Loop
                    Else
                        MsgBox("Data tidak ditemukan !", MsgBoxStyle.Exclamation, AT)
                        Me.Cursor = Cursors.Default
                    End If
                End Using
            End Using
            Me.Cursor = Cursors.Default
            DB.CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            
            
            Me.Cursor = Cursors.Default
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtSQL2.Clear()
        ShowDataRekening()
    End Sub

    Private Sub dgvlist2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvlist2.CellClick
        Dim A As Integer
        A = dgvlist2.CurrentRow.Index

        If dgvlist2.Columns(e.ColumnIndex).Name = "PictRekening" Then
            FrmFotoRekening.Path = "Rekening"
            FrmFotoRekening.images = dgvlist2.Item("NoRekening2", A).Value + "-" + dgvlist2.Item("IDPetani2", A).Value
            FrmFotoRekening.ShowDialog()
        End If

    End Sub


    Private Sub dgvlist2_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvlist2.CellPainting
        If dgvlist2.Columns(e.ColumnIndex).Name = "PictRekening" AndAlso e.RowIndex >= 0 Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)
            e.Graphics.DrawImage(My.Resources.RekButton, CInt((e.CellBounds.Width / 2) - (My.Resources.RekButton.Width / 2)) + e.CellBounds.X, CInt((e.CellBounds.Height / 2) - (My.Resources.RekButton.Height / 2)) + e.CellBounds.Y)
            e.Handled = True
        End If
    End Sub


    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If txtSQL.Text = "" Then
            MsgBox("Tidak ada data yang akan di print !", MsgBoxStyle.Exclamation, AT)
            Exit Sub
        End If

        If MessageBox.Show("Anda yakin mau print data ini ?", "Print out", MessageBoxButtons.YesNo) = vbNo Then
            Exit Sub
        End If
        Print = 0
        FrmRptMonRekeningRelasiPancang.ShowDialog()
    End Sub

    Private Sub btnPrint2_Click(sender As Object, e As EventArgs) Handles btnPrint2.Click
        If txtSQL2.Text = "" Then
            MsgBox("Tidak ada data yang akan di print !", MsgBoxStyle.Exclamation, AT)
            Exit Sub
        End If

        If MessageBox.Show("Anda yakin mau print data ini ?", "Print out", MessageBoxButtons.YesNo) = vbNo Then
            Exit Sub
        End If
        Print = 1
        FrmRptMonRekeningRelasi.ShowDialog()
    End Sub

    Private Sub dtp1a_ValueChanged(sender As Object, e As EventArgs) Handles dtp1a.ValueChanged
        If dtp1a.Checked = True Then
            dtp2a.Enabled = True

        ElseIf dtp1a.Checked = False Then
            dtp2a.Enabled = False
            dtp1a.Value = Now
            dtp2a.Value = Now

        End If
    End Sub

End Class