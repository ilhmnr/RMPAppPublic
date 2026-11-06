

Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmTrnTambangKapalBPIFind
    Private CanEdit, CanAdd, CanDelete, CanSave As Boolean

    Private Sub FrmTrnApprovalPenerimaanFind_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Security.GetAccess(ClsSession.RoleID, Me.Tag, CanAdd, CanEdit, CanDelete, CanSave)

        dtpTanggalApproval1.Value = Now
        dtpTanggalApproval2.Value = Now

        Call ClsFlexGrid.ApplyStyle(fg)

        Call Modul_RMP.Combo.SetPancang(cboPancang)
        Call Modul_RMP.Combo.SetKapal(cboKapal)

        ' combobox auto complite
        cboPancang.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboPancang.AutoCompleteSource = AutoCompleteSource.ListItems
        cboKapal.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboKapal.AutoCompleteSource = AutoCompleteSource.ListItems
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        FrmMain.BukaMenu(FrmTrnTambangKapalBPI, FrmMain.mnuTrnTambangKapal)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Call ShowData()
    End Sub

    Public Sub ShowData()
        Dim dt As New DataTable
        Dim i As Integer = 1
        Dim sql As String = "select * from vwTrnTambangKapalBPIHdr where TanggalPengajuan between '" & Format(dtpTanggalApproval1.Value, "yyyy-MM-dd") & "' and '" & Format(dtpTanggalApproval2.Value, "yyyy-MM-dd") & "' and NoTrans like '%" & txtNoTrans.Text & "%' "

        If Replace(txtTrip.Text, " ", "") <> "" Then
            sql &= " and Trip =" & txtTrip.Text & " "
        End If

        If Replace(cboPancang.Text, " ", "") <> "" Then
            sql &= " and IDPancang =" & cboPancang.SelectedValue & " "
        End If

        If Replace(cboKapal.Text, " ", "") <> "" Then
            sql &= " and IDKapal =" & cboKapal.SelectedValue & " "
        End If

        If rdPSG.Checked = True Then
            sql &= " and Tujuan='PSG' "
        ElseIf rdRSUP.Checked = True Then
            sql &= " and Tujuan='RSUP' "
        End If

        sql &= " order by TanggalPengajuan asc"

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fg
            .Rows.Count = 1 ' Reset grid

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "HeaderID") = row("HeaderID")
                    .Item(i, "NoTrans") = row("NoTrans")
                    .Item(i, "TanggalApproval") = row("TanggalPengajuan")
                    .Item(i, "SupplierID") = row("SupplierID")
                    .Item(i, "SupplierName") = row("NamaSup")
                    .Item(i, "Pancang") = row("Pancang")
                    .Item(i, "Kapal") = row("Kapal")
                    .Item(i, "Trip") = row("Trip")
                    .Item(i, "Tujuan") = row("Tujuan")
                    .Item(i, "ApprovalLevel") = row("approval_level")
                    .Item(i, "Approval1By") = row("approve_1_by")
                    .Item(i, "ApprovalStatus1") = row("approval_status_1")
                    .Item(i, "Approval2By") = row("approve_2_by")
                    .Item(i, "ApprovalStatus2") = row("approval_status_2")
                    .Item(i, "Approval3By") = row("approve_3_by")
                    .Item(i, "ApprovalStatus3") = row("approval_status_3")
                    .Item(i, "CreatedBy") = row("CreatedBy")
                    .Item(i, "CreatedDate") = row("CreatedDate")

                    If row("SudahProsesAcc") = True Then
                        .Item(i, "Proses") = "Sudah Diproses"
                    Else
                        .Item(i, "Proses") = "Belum Diproses"
                    End If

                    .SetCellImage(i, "View", Func.ResizeImage(My.Resources.Doc1, 16, 16))
                    .SetCellImage(i, "Delete", Func.ResizeImage(My.Resources.DELETED_20, 16, 16))
                    .SetCellImage(i, "Edit", Func.ResizeImage(My.Resources.edit, 16, 16))

                    i += 1
                Next

                .AutoSizeCols()
            Else
                MsgBox("Tidak ada data.", vbInformation, AT)
            End If
        End With
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click
        With fg
            ' Pastikan ada baris data dan tidak klik header
            If .Rows.Count = 1 Then Exit Sub

            ' Ambil nama kolom yang diklik
            Dim colName As String = .Cols(.Col).Name

            Select Case colName
                Case "Delete"
                    If CanDelete = False Then
                        MsgBox("Anda tidak memiliki hak akses untuk menghapus data ini.", vbExclamation, AT)
                        Exit Sub
                    End If

                    Dim HeaderID As Integer = .Item(.Row, "HeaderID")

                    If MsgBox("Apakah Anda ingin menghapus pengajuan penerimaan No. Trans: " & fg.Item(fg.Row, "NoTrans") &
                          " ?", vbYesNo, AT) = vbNo Then Exit Sub

                    ' Cek apakah sudah diproses
                    If DB.ExecuteScalarValue(Of String)(StrConnRMPApp, "select SudahProsesAcc as GetValueString from RMPApp..TblTrnTambangKapalHdr where HeaderID=" & HeaderID) = True Then
                        MsgBox("Data No. Trans: " & fg.Item(fg.Row, "NoTrans") & " tidak dapat dihapus karena sudah diproses.",
                           vbExclamation, AT)
                        Exit Sub
                    End If

                    ' ==========================
                    '  INPUT KETERANGAN DELETE
                    ' ==========================
                    Dim fr As New FrmKeteranganDelete
                    Dim KeteranganDelete As String

                    If fr.ShowDialog() = DialogResult.OK Then
                        KeteranganDelete = fr.ResultText
                    Else
                        KeteranganDelete = ""
                    End If

                    If KeteranganDelete = "" Then
                        MsgBox("Delete Data Gagal.", vbExclamation)
                        Exit Sub
                    End If

                    ' ==========================
                    '  EKSEKUSI SP PAKAI TRANSAKSI
                    ' ==========================
                    Dim Conn As New SqlConnection(StrConnRMPApp)
                    Conn.Open()

                    Dim Trans As SqlTransaction = Conn.BeginTransaction()

                    Try
                        Using cmd As New SqlCommand("RMPApp..sp_TrnTambangKapalBPIDelete", Conn, Trans)
                            cmd.CommandType = CommandType.StoredProcedure

                            cmd.Parameters.Add("@HeaderID", SqlDbType.BigInt).Value = HeaderID
                            cmd.Parameters.Add("@KeteranganDeleted", SqlDbType.VarChar, 500).Value = KeteranganDelete
                            cmd.Parameters.Add("@DeletedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
                            cmd.Parameters.Add("@Flag", SqlDbType.Int).Direction = ParameterDirection.Output

                            cmd.ExecuteNonQuery()

                            Dim flagResult As Integer = CInt(cmd.Parameters("@Flag").Value)

                            If flagResult = 1 Then
                                Trans.Commit()
                                MsgBox("Data Tambang Kapal No. Trans: " & fg.Item(fg.Row, "NoTrans") & " berhasil dihapus.",
                                   vbInformation, AT)
                            Else
                                Trans.Rollback()
                                MsgBox("GAGAL menghapus data No. Trans: " & fg.Item(fg.Row, "NoTrans") & vbCrLf &
                                   "Transaksi dibatalkan!", vbCritical, AT)
                                Exit Sub
                            End If
                        End Using

                    Catch ex As Exception
                        Trans.Rollback()
                        MsgBox("Error saat proses delete: " & ex.Message, vbCritical, AT)
                        Exit Sub

                    Finally
                        Conn.Close()
                    End Try

                    btnSearch.PerformClick()
                Case "View"
                    Dim NoTrans As String = fg.Item(fg.Row, "NoTrans")

                    If NoTrans.Contains("TK-T") Then
                        ' === Aksi jika klik kolom View ===
                        ' Cek apakah form masih terbuka
                        For Each f As Form In Application.OpenForms
                            If TypeOf f Is FrmTrnTambangKapalTransitBPI Then
                                f.Close()
                                Exit For
                            End If
                        Next

                        ' === Buat instance baru ===
                        Dim frm As New FrmTrnTambangKapalTransitBPI
                        With frm
                            .StatusOpenForm = "View"
                            .Show(FrmMain.DockPanel1)
                            .ShowDataView(fg.Item(fg.Row, "HeaderID"))
                        End With
                    Else
                        ' === Aksi jika klik kolom View ===
                        ' Cek apakah form masih terbuka
                        For Each f As Form In Application.OpenForms
                            If TypeOf f Is FrmTrnTambangKapalBPI Then
                                f.Close()
                                Exit For
                            End If
                        Next

                        ' === Buat instance baru ===
                        Dim frm As New FrmTrnTambangKapalBPI
                        With frm
                            .StatusOpenForm = "View"
                            .Show(FrmMain.DockPanel1)
                            .ShowDataView(fg.Item(fg.Row, "HeaderID"))
                        End With
                    End If
                Case "Edit"
                    If CanEdit = False Then
                        MsgBox("Anda tidak memiliki hak akses untuk mengedit data ini.", vbExclamation, AT)
                        Exit Sub
                    End If

                    Dim NoTrans As String = fg.Item(fg.Row, "NoTrans")

                    If NoTrans.Contains("TK-T") Then
                        ' === Aksi jika klik kolom View ===
                        ' Cek apakah form masih terbuka
                        For Each f As Form In Application.OpenForms
                            If TypeOf f Is FrmTrnTambangKapalTransitBPI Then
                                f.Close()
                                Exit For
                            End If
                        Next

                        ' === Buat instance baru ===
                        Dim frm As New FrmTrnTambangKapalTransitBPI
                        With frm
                            .StatusOpenForm = "Edit"
                            FrmMain.BukaMenu(frm, FrmMain.mnuTrnTambangKapal)
                            .ShowDataView(fg.Item(fg.Row, "HeaderID"))
                        End With
                    Else
                        ' === Aksi jika klik kolom View ===
                        ' Cek apakah form masih terbuka
                        For Each f As Form In Application.OpenForms
                            If TypeOf f Is FrmTrnTambangKapalBPI Then
                                f.Close()
                                Exit For
                            End If
                        Next

                        ' === Buat instance baru ===
                        Dim frm As New FrmTrnTambangKapalBPI
                        With frm
                            .StatusOpenForm = "Edit"
                            FrmMain.BukaMenu(frm, FrmMain.mnuTrnTambangKapal)
                            .ShowDataView(fg.Item(fg.Row, "HeaderID"))
                        End With
                    End If
            End Select
        End With
    End Sub

    Private Sub FrmTrnApprovalPenerimaanFind_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        lblJudulForm.Left = (Me.Width - lblJudulForm.Width) / 2
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FrmMain.BukaMenu(FrmTrnTambangKapalTransitBPI, FrmMain.mnuTrnTambangKapal)
    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg.BeforeEdit
        e.Cancel = True
    End Sub
End Class