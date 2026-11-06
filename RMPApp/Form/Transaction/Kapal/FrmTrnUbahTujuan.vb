
Imports System.Data.SqlClient
Imports System.IO
Imports System.Data
Imports System.ComponentModel
Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Public Class FrmTrnUbahTujuan
    Private Sub btnrefreshh_Click(sender As Object, e As EventArgs) Handles btnrefreshh.Click
        loaddata()
    End Sub
    Private Sub loaddata()

        Try
            Dim SQL, SQL2, SQL3, SQL4, SQL5 As String, i As Integer


            If chkTransDate.Checked = True Then
                SQL2 = "AND  CONVERT(DATETIME,CONVERT(VARCHAR,A.CreatedDate,103),103) BETWEEN CONVERT (DATETIME,'" & DTPStart.Value & "',103) AND CONVERT(DATETIME,'" & DTPEnd.Value & "',103)"
            End If

            If chkKapal.Checked = True Then
                SQL3 = "AND D.IDKapal = '" & cmbKapal.SelectedValue.ToString & "'"
            End If

            If chkPancang.Checked = True Then
                SQL4 = "AND D.IDPancang = '" & cmbPancang.SelectedValue.ToString & "'"
            End If

            If chkTrip.Checked = True Then
                SQL5 = "AND TripAwal ='" & txttrip.Text & "'"
            End If

            SQL = " select A.* ,D.TUJUAN AS Tujuan 
                    FROM tblMstAwalTripPancang as a  INNER JOIN
                    Android_tblBookingKapalMuat AS D ON A.IDBooking=D.DetailID 
                    WHERe  D.PindahMuatDate IS NOT NULL "

            SQL = SQL + SQL2 + SQL3 + SQL4 + SQL5

            Using koneksi As New SqlCommand(SQL, DB.OpenConnection(StrConnRMPApp))
                Using DR = koneksi.ExecuteReader()
                    If DR.HasRows Then
                        dgvList.RowCount = 0
                        While DR.Read
                            With dgvList
                                .Rows.Add()
                                .Item("no", i).Value = i + 1
                                .Item("id", i).Value = DR!id
                                .Item("IDPancang", i).Value = DR!IDPancang
                                .Item("Pancang", i).Value = DR!Pancang
                                .Item("IDKapal", i).Value = DR!IDKapal
                                .Item("Kapal", i).Value = DR!Kapal
                                .Item("Trip", i).Value = DR!TripAwal
                                .Item("JenisMuat", i).Value = DR!JenisMuat
                                .Item("Tujuan", i).Value = DR!Tujuan

                                Dim dgvImageColumn As New DataGridViewImageColumn
                                dgvImageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch

                                With Me.dgvList
                                    .RowsDefaultCellStyle.BackColor = Color.White
                                    .AlternatingRowsDefaultCellStyle.BackColor = Color.Azure
                                    .Rows(i).Cells("No").Style.BackColor = Color.FromArgb(240, 240, 240)
                                End With

                            End With
                            i += 1
                        End While
                    Else
                        dgvList.Rows.Clear()
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


    Private Sub FrmUbahTujuan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DTPStart.Value = Format(Now, "dd/MM/yy")
        DTPEnd.Value = Format(Now, "dd/MM/yy")
        Modul_RMP.Combo.SetPancang(cmbPancang)
        Modul_RMP.Combo.SetKapal(cmbKapal)

    End Sub

    Private Sub dgvList_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvList.CellPainting
        If dgvList.Columns(e.ColumnIndex).Name = "UbahTujuan" AndAlso e.RowIndex >= 0 Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)
            e.Graphics.DrawImage(My.Resources.Resources.icons8_ship_wheel_10__1_, CInt((e.CellBounds.Width / 2) - (My.Resources.DELETED_20.Width / 2)) + e.CellBounds.X, CInt((e.CellBounds.Height / 2.5) - (My.Resources.DELETED_20.Height / 2.5)) + e.CellBounds.Y)
            e.Handled = True
        End If
    End Sub



    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        With FrmTrnPremiAsuransi
            Call .clear(True)
            .perintah = "Add"
            .dtpInvoice.Focus()
            .cmdEnabled(False)
            .enableds(True)
            .Show()
        End With
    End Sub
    Private Function PrintNota(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal PrintBy As String, ByVal NoInvoice As String) As Boolean
        Dim MyCMD As New SqlCommand
        Try
            With MyCMD
                .Connection = Conn
                .CommandType = CommandType.Text
                .Transaction = Trans
                .CommandText = "UPDATE RMPApp..tbl_RMTrnAngkutanBuahKapalHdr SET FlagPrint = '1', PrintBy = '" & PrintBy & "', PrintDate = GETDATE() " &
                                 "WHERE NoInvoice = '" & NoInvoice & "' "
                .ExecuteNonQuery()
                .Dispose()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
        Return True
    End Function
    Private Function FRestorekapal(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, trip As Integer, idkapal As Integer, idpancang As Integer, jenismuat As String, TujuanAwal As String) As Boolean
        Dim MyCMD As New SqlCommand
        Try
            With MyCMD
                .Connection = Conn
                .CommandType = CommandType.StoredProcedure
                .CommandText = "RMPApp..sprestorekapal"
                .Transaction = Trans
                .Parameters.Add("@TRIP", SqlDbType.VarChar).Value = trip
                .Parameters.Add("@IDKAPAL", SqlDbType.VarChar).Value = idkapal
                .Parameters.Add("@IDPANCANG", SqlDbType.VarChar).Value = idpancang
                .Parameters.Add("@jenismuat", SqlDbType.VarChar).Value = jenismuat
                .Parameters.Add("@TujuanAwal", SqlDbType.VarChar).Value = TujuanAwal
                .Parameters.Add("@RestoreBy", SqlDbType.VarChar).Value = ClsSession.UserID
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

    Private Sub dgvList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellClick
        With FrmTrnPremiAsuransi
            Select Case dgvList.CurrentCell.ColumnIndex
                Case 9
                    If MsgBox("Yakin Ubah Tujuan Kapal '" & dgvList.Item("Kapal", dgvList.CurrentRow.Index).Value + " - " + CStr(dgvList.Item("Trip", dgvList.CurrentRow.Index).Value) & "' ", vbYesNo) = vbNo Then
                        Exit Sub
                    End If

                    'Dim StatusKapal As Integer = 0

                    'StatusKapal = DB.ExecuteScalarValue(Of String)(StrConnRMPApp," declare @Flag as int = 0

                    '                                --Tidak bisa pindah kapal jika sudah di um
                    '                                if Not Exists(Select NoNota   from  RMPApp..TblTrnKelapaHdr  where IDKapal=" & dgvList.Item("IDKapal", dgvList.CurrentRow.Index).Value & " and IDPancang=" & dgvList.Item("IDPancang", dgvList.CurrentRow.Index).Value & " and trip=" & dgvList.Item("Trip", dgvList.CurrentRow.Index).Value & " and jeniskb='" & dgvList.Item("JenisMuat", dgvList.CurrentRow.Index).Value & "' and IndUM=1 )
                    '                                begin
                    '                                 set @Flag=1
                    '                                end

                    '                                --Boleh pindah tujuan ketika sudah um jika kapal mengalamai tenggelam / rusak
                    '                                if  Exists(Select NoNota   from  RMPApp..TblTrnKelapaHdr  where IDKapal=" & dgvList.Item("IDKapal", dgvList.CurrentRow.Index).Value & " and IDPancang=" & dgvList.Item("IDPancang", dgvList.CurrentRow.Index).Value & " and trip=" & dgvList.Item("Trip", dgvList.CurrentRow.Index).Value & " and jeniskb='" & dgvList.Item("JenisMuat", dgvList.CurrentRow.Index).Value & "' and IndUM=1 AND (KapalTenggelamFlag =1 or KapalRusak =1))
                    '                                begin 
                    '                                 set @Flag=1
                    '                                end 

                    '                                select @Flag as GetValueString ")

                    'If StatusKapal = 0 Then
                    '    MsgBox("Tidak bisa pindah tujuan kapal, karena kapal sudah di input uang muka !", vbExclamation, AT)
                    '    Exit Sub
                    'End If

                    Me.Cursor = Cursors.WaitCursor

                    Dim koneksi As SqlConnection = DB.OpenConnection(StrConnRMPApp)
                    Dim Transaksi As SqlTransaction
                    Transaksi = koneksi.BeginTransaction

                    Try
                        If FRestorekapal(koneksi, Transaksi, dgvList.Item("Trip", dgvList.CurrentRow.Index).Value, dgvList.Item("IDKapal", dgvList.CurrentRow.Index).Value, dgvList.Item("IDPancang", dgvList.CurrentRow.Index).Value, dgvList.Item("JenisMuat", dgvList.CurrentRow.Index).Value, dgvList.Item("Tujuan", dgvList.CurrentRow.Index).Value) = False Then
                            Transaksi.Rollback()
                            MsgBox("Restore Data Gagal", vbExclamation, "Save Data - " & AT)
                            Exit Try
                        End If

                        Transaksi.Commit()
                        Me.Cursor = Cursors.Default
                        MessageBox.Show("Ubah Tujuan berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Call loaddata()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "gagal trf data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Transaksi.Rollback()

                        Me.Cursor = Cursors.Default
                    Finally
                        Me.Cursor = Cursors.Default
                    End Try
            End Select
        End With
    End Sub
    Private Sub cmbPancang_Validated(sender As Object, e As EventArgs) Handles cmbPancang.Validated
        chkPancang.Checked = IIf(cmbPancang.Text = "", False, True)
        If cmbPancang.SelectedValue <> Nothing Then
            cmbKapal.Text = ""
            chkKapal.Checked = False
        End If
    End Sub
    Private Sub cmbKapal_Validated(sender As Object, e As EventArgs) Handles cmbKapal.Validated
        chkKapal.Checked = IIf(cmbKapal.Text = "", False, True)
    End Sub

    Private Sub cmbKapal_Validating(sender As Object, e As CancelEventArgs) Handles cmbKapal.Validating
        If cmbKapal.Text = "" Then
            Exit Sub
        End If

        If IsNothing(cmbKapal.SelectedValue) Then
            MsgBox("Pilihan tidak ada !", vbExclamation, AT)
            cmbKapal.Text = ""
            cmbKapal.Focus()
        End If
    End Sub

    Private Sub cmbPancang_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbPancang.KeyUp
        UI.AutoCompleteCombo_KeyUp(cmbPancang, e)
    End Sub

    Private Sub cmbKapal_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbKapal.KeyUp
        UI.AutoCompleteCombo_KeyUp(cmbKapal, e)
    End Sub

    Private Sub dgvList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellContentClick

    End Sub
End Class