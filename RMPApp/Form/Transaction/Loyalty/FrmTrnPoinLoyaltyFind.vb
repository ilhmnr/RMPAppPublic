
Imports System.Data.SqlClient
Imports System.IO
Imports System.Data
Imports System.ComponentModel
Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Globalization
Public Class FrmTrnPoinLoyaltyFind

    Private Sub FrmTrnPoinLoyaltyFind_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DTPStart.Value = Format(Now, "dd/MM/yy")
        DTPEnd.Value = Format(Now, "dd/MM/yy")

        dt1.Value = Format(Now, "dd/MM/yy")
        dt2.Value = Format(Now, "dd/MM/yy")
        chknoinvoice.Checked = False
    End Sub




    Private Function DelPenukaranPoin(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        Dim MyCMD As New SqlCommand
        With MyCMD
            DelPenukaranPoin = False
            Dim MyCon As SqlConnection = Conn
            Dim MyConTrans As SqlTransaction = Trans
            .Connection = MyCon
            .Connection = MyCon
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RMPApp..sp_RMTrnPenukaranPoinDtldelete"
            .Transaction = MyConTrans
            .Parameters.Add("@RETURN_VALUE", SqlDbType.SmallInt).Direction = ParameterDirection.ReturnValue
            .Parameters.Add("@NoInvoice", SqlDbType.VarChar, 30).Value = dgvList.Item("NoInvoice", dgvList.CurrentRow.Index).Value
            '.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
            .Parameters.Add(New SqlParameter("@Flag", SqlDbType.SmallInt, 5, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .ExecuteNonQuery()

            If CInt(.Parameters("@Flag").Value) = 0 Then
                .Dispose()
                Exit Function
            End If
            Return True
        End With
    End Function



    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        With FrmTrnPoinLoyalty
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

                .CommandText = "UPDATE RMPApp..tbl_RMTrnPenukaranPoinHdr SET FlagPrint = '1', PrintBy = '" & PrintBy & "', PrintDate = GETDATE() " &
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
    Private Function FRestorepremi(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, noinvoice As String) As Boolean
        Dim MyCMD As New SqlCommand
        Try
            With MyCMD
                .Connection = Conn
                .CommandType = CommandType.StoredProcedure
                .CommandText = "RMPApp..sprestorepremi"
                .Transaction = Trans
                .Parameters.Add("@NoInvoicePremi", SqlDbType.VarChar).Value = noinvoice
                '.Parameters.Add("@RestoreBy", SqlDbType.VarChar).Value = ClsSession.UserID.ToString
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


    Private Sub restorepremi(noinvoice As String)
        'Dim koneksi As SqlConnection = DB.OpenConnection(StrConnRMPApp)
        Dim koneksi As SqlConnection = DB.OpenConnection(StrConnRMPApp)
        Dim Transaksi As SqlTransaction
        Transaksi = koneksi.BeginTransaction
        Dim StrConnPSGRMP As SqlConnection = DB.OpenConnection(StrConnTimbangan)
        Dim Transaksitimb As SqlTransaction
        Transaksitimb = StrConnPSGRMP.BeginTransaction


        Me.Cursor = Cursors.WaitCursor
        Try
            Dim connpsg As New SqlConnection(StrConnAccounting)
            connpsg.Open()
            Dim sql As String

            sql = "select  * from RMPApp..tbl_RMTrnAngkutanBuahKapalDtl where noinvoice='" & noinvoice & "' and flagubm=1 "
            Dim cmdselect As New SqlCommand(sql, connpsg)
            RD = cmdselect.ExecuteReader()

            If RD.HasRows Then
                If RD.Read Then
                    MessageBox.Show("Sudah Ada Data yang di UBM  !", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Try
                End If
            Else

                If FRestorepremi(koneksi, Transaksi, noinvoice) = False Then
                    Transaksi.Rollback()
                    Transaksitimb.Rollback()
                    MsgBox("Restore Data Gagal", vbExclamation, "Save Data - " & AT)
                    Exit Try
                End If


            End If

            connpsg.Close()
            Transaksi.Commit()
            Transaksitimb.Commit()

            Me.Cursor = Cursors.Default
            MessageBox.Show("RESTORE data berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Call loaddata()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "gagal trf data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Transaksi.Rollback()
            Transaksitimb.Rollback()
            Me.Cursor = Cursors.Default
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub


    Private Sub restorepoin(noinvoice As String)
        'Dim koneksi As SqlConnection = DB.OpenConnection(StrConnRMPApp)
        Dim koneksi As SqlConnection = DB.OpenConnection(StrConnRMPApp)
        Dim Transaksi As SqlTransaction
        Transaksi = koneksi.BeginTransaction
        Dim StrConnPSGRMP As SqlConnection = DB.OpenConnection(StrConnTimbangan)
        Dim Transaksitimb As SqlTransaction
        Transaksitimb = StrConnPSGRMP.BeginTransaction


        Me.Cursor = Cursors.WaitCursor
        Try
            Dim connpsg As New SqlConnection(StrConnAccounting)
            connpsg.Open()
            Dim sql As String

            sql = "select  * from RMPApp..tbl_RMTrnPenukaranPoinDtl where noinvoice='" & noinvoice & "' and flag_IMemo=1 "
            Dim cmdselect As New SqlCommand(sql, connpsg)
            RD = cmdselect.ExecuteReader()

            If RD.HasRows Then
                If RD.Read Then
                    MessageBox.Show("Sudah Ada Data yang di Ajukan tdk bisa direstore, silahkan kembalikan Memo Terlebih Dahulu  !", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Try
                End If
            Else

                If FRestorepoin(koneksi, Transaksi, noinvoice) = False Then
                    Transaksi.Rollback()
                    Transaksitimb.Rollback()
                    MsgBox("Restore Data Gagal", vbExclamation, "Save Data - " & AT)
                    Exit Try
                End If


            End If

            connpsg.Close()
            Transaksi.Commit()
            Transaksitimb.Commit()

            Me.Cursor = Cursors.Default
            MessageBox.Show("RESTORE data berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call loaddata()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "gagal trf data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Transaksi.Rollback()
            Transaksitimb.Rollback()
            Me.Cursor = Cursors.Default
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Function FRestorepoin(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, noinvoice As String) As Boolean
        Dim MyCMD As New SqlCommand
        Try
            With MyCMD
                .Connection = Conn
                .CommandType = CommandType.StoredProcedure
                .CommandText = "RMPApp..sprestorepoin"
                .Transaction = Trans
                .Parameters.Add("@NoInvoicepoin", SqlDbType.VarChar).Value = noinvoice
                '.Parameters.Add("@RestoreBy", SqlDbType.VarChar).Value = ClsSession.UserID.ToString
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

        If Val(dgvList.Item("Manual", dgvList.CurrentRow.Index).Value) = 0 Then
            With FrmTrnPoinLoyalty
                Select Case dgvList.CurrentCell.ColumnIndex
                    Case 8
                        If Val(dgvList.Item("FlagPrint", dgvList.CurrentRow.Index).Value) = 1 Then
                            MessageBox.Show("Tidak Dapat Edit Data Sudah Complete (Print Loyalty) !", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        Else
                            .Show()
                            .loaddata(dgvList.Item("NoInvoice", dgvList.CurrentRow.Index).Value)
                            .cmdEnabled(False)
                            .perintah = "Edit"
                            .enableds(True)
                            .txtinvoice.Enabled = False
                            .dtp1.Enabled = False
                            .dtp2.Enabled = False
                            .btnsave.Visible = True
                            .btnexit.Enabled = True
                        End If

                    Case 9
                        If Val(dgvList.Item("FlagPrint", dgvList.CurrentRow.Index).Value) = 1 Then
                            MessageBox.Show("Tidak Dapat Edit Data Sudah Complete (Print Loyalty) !", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        Else
                            .btnexit.Enabled = True
                            Dim A As String
                            A = dgvList.Item("NoInvoice", dgvList.CurrentRow.Index).Value
                            A = A
                            Dim result As DialogResult = MessageBox.Show("Yakin Delete Invoice '" & A & "' ", "caption", MessageBoxButtons.YesNoCancel)
                            If result = DialogResult.Cancel Then
                                MessageBox.Show("Cancel pressed")
                            ElseIf result = DialogResult.Yes Then
                                Dim Koneksi As SqlConnection = DB.OpenConnection(StrConnRMPApp)
                                Dim Transaksi As SqlTransaction
                                Transaksi = Koneksi.BeginTransaction
                                Me.Cursor = Cursors.WaitCursor
                                Try
                                    If DelPenukaranPoin(Koneksi, Transaksi) = False Then
                                        Transaksi.Rollback()
                                        Transaksi = Nothing
                                        Me.Cursor = Cursors.Default
                                        MessageBox.Show("Delete Data Hdr Gagal !", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        Exit Sub
                                    End If

                                    Transaksi.Commit()
                                    Me.Cursor = Cursors.Default
                                    MessageBox.Show("Delete Data Berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    'loaddata()
                                Catch ex As Exception
                                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Transaksi.Rollback()
                                    Koneksi.Close()
                                    Me.Cursor = Cursors.Default
                                Finally
                                    Koneksi.Close()
                                    Me.Cursor = Cursors.Default
                                End Try
                            End If
                        End If
                    Case 10
                        'With FrmRptRequestPenukaranPoint
                        '    .noinvoice = dgvList.Item("NoInvoice", dgvList.CurrentRow.Index).Value
                        '    .Show()
                        '    .noinvoice = dgvList.Item("NoInvoice", dgvList.CurrentRow.Index).Value
                        'End With

                        Dim Koneksi As SqlConnection = DB.OpenConnection(StrConnRMPApp)
                        Dim Transaksi As SqlTransaction
                        PrintNota(Koneksi, Transaksi, ClsSession.UserID, dgvList.Item("NoInvoice", dgvList.CurrentRow.Index).Value)

                        With FrmRptRequestPenukaranPoint
                            .noinvoice = dgvList.Item("NoInvoice", dgvList.CurrentRow.Index).Value
                            .Show()
                            .noinvoice = dgvList.Item("NoInvoice", dgvList.CurrentRow.Index).Value
                        End With
                    'loaddata()

                    Case 11
                        Dim Koneksi As SqlConnection = DB.OpenConnection(StrConnRMPApp)
                        Dim Transaksi As SqlTransaction
                        PrintNota(Koneksi, Transaksi, ClsSession.UserID, dgvList.Item("NoInvoice", dgvList.CurrentRow.Index).Value)

                        With FrmRptRequestPenukaranPoint
                            .noinvoice = dgvList.Item("NoInvoice", dgvList.CurrentRow.Index).Value
                            .Show()
                            .noinvoice = dgvList.Item("NoInvoice", dgvList.CurrentRow.Index).Value
                        End With
                    'loaddata()

                    Case 12
                        .Show()
                        .loaddata(dgvList.Item("NoInvoice", dgvList.CurrentRow.Index).Value)
                        .cmdEnabled(False)
                        .btnsave.Visible = False
                        .enableds(False)
                        .btnexit.Enabled = True
                        .txtinvoice.Enabled = False
                        .dtp1.Enabled = False
                        .dtp2.Enabled = False
                        .dtpInvoice.Enabled = False


                        'Case 12
                        '    Dim noinv As String
                        '    noinv = dgvList.Item("NoInvoice", dgvList.CurrentRow.Index).Value

                        '    Dim result2 As DialogResult = MessageBox.Show("Yakin Restore Invoice '" & noinv & "' ", "caption", MessageBoxButtons.YesNoCancel)
                        '    If result2 = DialogResult.Cancel Then
                        '        MessageBox.Show("Cancel pressed")
                        '    ElseIf result2 = DialogResult.Yes Then

                        '        Try
                        '            restorepremi(dgvList.Item("NoInvoice", dgvList.CurrentRow.Index).Value)
                        '        Catch ex As Exception
                        '            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        '            Me.Cursor = Cursors.Default
                        '        Finally

                        '            Me.Cursor = Cursors.Default
                        '        End Try
                        '    End If
                End Select
            End With



        Else

            With FrmTrnTukarPoin
                Select Case dgvList.CurrentCell.ColumnIndex
                    Case 8
                        If Val(dgvList.Item("FlagPrint", dgvList.CurrentRow.Index).Value) = 1 Then
                            MessageBox.Show("Tidak Dapat Edit Data Sudah Complete (Print Loyalty) !", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        Else
                            .Show()
                            .loaddata(dgvList.Item("NoInvoice", dgvList.CurrentRow.Index).Value)
                            .cmdEnabled(False)
                            .perintah = "Edit"
                            .enableds(True)
                            .txtinvoice.Enabled = False
                            .btnsave.Visible = True
                            .btnexit.Enabled = True
                        End If

                    Case 9
                        If Val(dgvList.Item("FlagPrint", dgvList.CurrentRow.Index).Value) = 1 Then
                            MessageBox.Show("Tidak Dapat Edit Data Sudah Complete (Print Loyalty) !", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        Else
                            .btnexit.Enabled = True
                            Dim A As String
                            A = dgvList.Item("NoInvoice", dgvList.CurrentRow.Index).Value
                            A = A
                            Dim result As DialogResult = MessageBox.Show("Yakin Delete Invoice '" & A & "' ", "caption", MessageBoxButtons.YesNoCancel)
                            If result = DialogResult.Cancel Then
                                MessageBox.Show("Cancel pressed")
                            ElseIf result = DialogResult.Yes Then
                                Dim Koneksi As SqlConnection = DB.OpenConnection(StrConnRMPApp)
                                Dim Transaksi As SqlTransaction
                                Transaksi = Koneksi.BeginTransaction
                                Me.Cursor = Cursors.WaitCursor
                                Try
                                    If DelPenukaranPoin(Koneksi, Transaksi) = False Then
                                        Transaksi.Rollback()
                                        Transaksi = Nothing
                                        Me.Cursor = Cursors.Default
                                        MessageBox.Show("Simpan Data Hdr Gagal !", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        Exit Sub
                                    End If

                                    Transaksi.Commit()
                                    Me.Cursor = Cursors.Default
                                    MessageBox.Show("Simpan Data Berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    'loaddata()
                                Catch ex As Exception
                                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Transaksi.Rollback()
                                    Koneksi.Close()
                                    Me.Cursor = Cursors.Default
                                Finally
                                    Koneksi.Close()
                                    Me.Cursor = Cursors.Default
                                End Try
                            End If
                        End If
                    Case 10

                        Dim Koneksi As SqlConnection = DB.OpenConnection(StrConnRMPApp)
                        Dim Transaksi As SqlTransaction
                        PrintNota(Koneksi, Transaksi, ClsSession.UserID, dgvList.Item("NoInvoice", dgvList.CurrentRow.Index).Value)

                        With FrmRptRequestPenukaranPoint
                            .noinvoice = dgvList.Item("NoInvoice", dgvList.CurrentRow.Index).Value
                            .Show()
                            .noinvoice = dgvList.Item("NoInvoice", dgvList.CurrentRow.Index).Value
                        End With
                    'loaddata()

                    Case 11
                        Dim Koneksi As SqlConnection = DB.OpenConnection(StrConnRMPApp)
                        Dim Transaksi As SqlTransaction
                        PrintNota(Koneksi, Transaksi, ClsSession.UserID, dgvList.Item("NoInvoice", dgvList.CurrentRow.Index).Value)

                        With FrmRptRequestPenukaranPoint
                            .noinvoice = dgvList.Item("NoInvoice", dgvList.CurrentRow.Index).Value
                            .Show()
                            .noinvoice = dgvList.Item("NoInvoice", dgvList.CurrentRow.Index).Value
                        End With
                    'loaddata()

                    Case 12
                        .Show()
                        .loaddata(dgvList.Item("NoInvoice", dgvList.CurrentRow.Index).Value)
                        .cmdEnabled(False)
                        .btnsave.Visible = False
                        .enableds(False)
                        .btnexit.Enabled = True
                        .txtinvoice.Enabled = False
                        .dtpInvoice.Enabled = False


                    Case 14

                        Dim noinv As String
                        noinv = dgvList.Item("NoInvoice", dgvList.CurrentRow.Index).Value

                        Dim result2 As DialogResult = MessageBox.Show("Yakin Restore Invoice '" & noinv & "' ", "caption", MessageBoxButtons.YesNoCancel)
                        If result2 = DialogResult.Cancel Then
                            MessageBox.Show("Cancel pressed")
                        ElseIf result2 = DialogResult.Yes Then

                            Try
                                restorepoin(dgvList.Item("NoInvoice", dgvList.CurrentRow.Index).Value)
                            Catch ex As Exception
                                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Me.Cursor = Cursors.Default
                            Finally

                                Me.Cursor = Cursors.Default
                            End Try
                        End If


                End Select
            End With
        End If
    End Sub



    Private Sub loaddata()

        Try
            Dim SQL As String, i As Integer



            Dim sql2 As String = ""

            If chkTransDate.Checked = True Then
                sql2 = Modul_RMP.Func.SetCondition(sql2, " CONVERT(DATETIME,CONVERT(VARCHAR,tglcashback,103),103) BETWEEN CONVERT (DATETIME,'" & DTPStart.Value & "',103) AND CONVERT(DATETIME,'" & DTPEnd.Value & "',103)")

            End If

            If chkDoDate.Checked = True Then
                sql2 = Modul_RMP.Func.SetCondition(sql2, " CONVERT(DATETIME,CONVERT(VARCHAR,tglinvoice,103),103) BETWEEN CONVERT (DATETIME,'" & dt1.Value & "',103) AND CONVERT(DATETIME,'" & dt2.Value & "',103)")

            End If


            If chknoinvoice.Checked = True Then
                sql2 = Modul_RMP.Func.SetCondition(sql2, "NoInvoice like '%" & txtinvoice.Text & "%'")

            End If

            SQL = " SELECT HEADERID, noinvoice, tglInvoice, tglcashback1,tglcashback2 ,VerifikasiBy AS CREATEDBY,sum(TotalPoinCashBack) as TotalPoinCashBack " &
                    " ,sum(RPTotalPoinCashBack) as RPTotalPoinCashBack, Manual_,FlagPrint  From [RMPApp].[dbo].[vw_RM_trnpenukaranpointverifikasi] " &
                    " where noinvoice is not null " & IIf(sql2 = "", "", " AND " & sql2) & " Group By HEADERID,VerifikasiBy, NoInvoice, TglInvoice,FlagPrint, tglcashback1, tglcashback2 ,Manual_ "

            Using koneksi As New SqlCommand(SQL, DB.OpenConnection(StrConnRMPApp))
                Using DR = koneksi.ExecuteReader()
                    If DR.HasRows Then
                        dgvList.RowCount = 0
                        While DR.Read
                            With dgvList
                                .Rows.Add()
                                .Item("no", i).Value = i + 1
                                .Item("NoInvoice", i).Value = DR!NoInvoice
                                .Item("TglInvoice", i).Value = Format(DR!TglInvoice, "dd/MM/yyyy")
                                .Item("tglcashback1", i).Value = Format(DR!tglcashback1, "dd/MM/yyyy")
                                If DR!Manual_ = 0 Then
                                    .Item("tglcashback2", i).Value = Format(DR!tglcashback2, "dd/MM/yyyy")
                                End If
                                .Item("TotalPointCashBack", i).Value = DR!TotalPoinCashBack
                                .Item("RpPointCashBack", i).Value = DR!RPTotalPoinCashBack

                                .Item("CreatedBy", i).Value = DR!createdby
                                .Item("Manual", i).Value = DR!Manual_
                                .Item("FlagPrint", i).Value = DR!FlagPrint

                                If .Item("FlagPrint", i).Value = 1 Then
                                    For COL = 1 To dgvList.Columns.Count - 1
                                        .Rows(i).Cells(COL).Style.BackColor = Color.LavenderBlush
                                    Next COL
                                End If

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

    Private Sub btnrefreshh_Click(sender As Object, e As EventArgs) Handles btnrefreshh.Click
        loaddata()
    End Sub


    Private Sub dgvList_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgvList.CellPainting
        If dgvList.Columns(e.ColumnIndex).Name = "delete" AndAlso e.RowIndex >= 0 Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)
            e.Graphics.DrawImage(My.Resources.DELETED_20, CInt((e.CellBounds.Width / 2) - (My.Resources.DELETED_20.Width / 2)) + e.CellBounds.X, CInt((e.CellBounds.Height / 2) - (My.Resources.DELETED_20.Height / 2)) + e.CellBounds.Y)
            e.Handled = True
        End If

        If dgvList.Columns(e.ColumnIndex).Name = "edit" AndAlso e.RowIndex >= 0 Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)
            e.Graphics.DrawImage(My.Resources.icons8_edit_20, CInt((e.CellBounds.Width / 2) - (My.Resources.icons8_edit_20.Width / 2)) + e.CellBounds.X, CInt((e.CellBounds.Height / 2) - (My.Resources.icons8_edit_20.Height / 2)) + e.CellBounds.Y)
            e.Handled = True
        End If

        If dgvList.Columns(e.ColumnIndex).Name = "PrintDeklarasi" AndAlso e.RowIndex >= 0 Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)
            e.Graphics.DrawImage(My.Resources.PRINTF1, CInt((e.CellBounds.Width / 2) - (My.Resources.PRINTF1.Width / 2)) + e.CellBounds.X, CInt((e.CellBounds.Height / 2) - (My.Resources.PRINTF1.Height / 2)) + e.CellBounds.Y)
            e.Handled = True
        End If

        If dgvList.Columns(e.ColumnIndex).Name = "PrintInvoice" AndAlso e.RowIndex >= 0 Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)
            e.Graphics.DrawImage(My.Resources.PRINTF2, CInt((e.CellBounds.Width / 2) - (My.Resources.PRINTF2.Width / 2)) + e.CellBounds.X, CInt((e.CellBounds.Height / 2) - (My.Resources.PRINTF2.Height / 2)) + e.CellBounds.Y)
            e.Handled = True
        End If

        If dgvList.Columns(e.ColumnIndex).Name = "Detail" AndAlso e.RowIndex >= 0 Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)
            e.Graphics.DrawImage(My.Resources.find20, CInt((e.CellBounds.Width / 2) - (My.Resources.find20.Width / 2)) + e.CellBounds.X, CInt((e.CellBounds.Height / 2) - (My.Resources.find20.Height / 2)) + e.CellBounds.Y)
            e.Handled = True
        End If

        If dgvList.Columns(e.ColumnIndex).Name = "Restore" AndAlso e.RowIndex >= 0 Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)
            e.Graphics.DrawImage(My.Resources.icons8_restart_20, CInt((e.CellBounds.Width / 2) - (My.Resources.icons8_restart_20.Width / 2)) + e.CellBounds.X, CInt((e.CellBounds.Height / 2) - (My.Resources.icons8_restart_20.Height / 2)) + e.CellBounds.Y)
            e.Handled = True
        End If
    End Sub


    Private Sub btnAddManual_Click(sender As Object, e As EventArgs) Handles btnAddManual.Click
        With FrmTrnTukarPoin
            Call .clear(True)
            .perintah = "Add"
            .dtpInvoice.Focus()

            .cmdEnabled(False)

            .enableds(True)
            .Show()
        End With
    End Sub

    Private Sub dgvList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellContentClick

    End Sub
End Class