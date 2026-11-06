Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports Microsoft.Office.Interop

Public Class FrmTrnPotonganRelasiFind
    Private CanEdit, CanAdd, CanDelete, CanSave As Boolean
    Private Sub FrmTrnApprovalPenerimaanFind_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpTanggalApproval1.Value = Now
        dtpTanggalApproval2.Value = Now

        Call ClsFlexGrid.ApplyStyle(fg)

        Security.GetAccess(ClsSession.RoleID, Me.Tag, CanAdd, CanEdit, CanDelete, CanSave)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' tutup FrmTrnUpahBongkar jika sudah di buka
        For Each f As Form In Application.OpenForms
            If TypeOf f Is FrmTrnPotonganRelasi Then
                f.Close()
                Exit For
            End If
        Next

        FrmMain.BukaMenu(FrmTrnPotonganRelasi, FrmMain.mnuTrnPotonganRelasi)
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
        Dim sql As String = "select * from RMPApp..tblTrnPotonganRelasiHdr where Deleted=0 AND cast(CreatedDate as date) between '" & Format(dtpTanggalApproval1.Value, "yyyy-MM-dd") & "' and '" & Format(dtpTanggalApproval2.Value, "yyyy-MM-dd") & "' and NoTrans like '%" & txtNoTrans.Text & "%' order by CreatedDate asc"

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fg
            .Rows.Count = 1 ' Reset grid

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "HeaderID") = row("HeaderID")
                    .Item(i, "NoTrans") = row("NoTrans")
                    .Item(i, "Potongan") = row("Potongan")
                    .Item(i, "PotonganTransaksi") = row("PotonganTransaksi")
                    .Item(i, "ReffNo") = row("ReffNo")
                    .Item(i, "RemarkReffNo") = row("RemarkReffNo")
                    .Item(i, "CreatedBy") = row("CreatedBy")
                    .Item(i, "CreatedDate") = row("CreatedDate")

                    ' Masukkan gambar yang sudah di-resize
                    .SetCellImage(i, "View", Func.ResizeImage(My.Resources.Doc1, 16, 16))

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
                    Dim HeaderID As Integer = .Item(.Row, "HeaderID")

                    If MsgBox("Apakah Anda ingin menghapus pengajuan penerimaan No. Trans: " & fg.Item(fg.Row, "NoTrans") &
                          " ?", vbYesNo, AT) = vbNo Then Exit Sub

                    ' Cek apakah sudah diproses
                    If DB.ExecuteScalarValue(Of String)(StrConnRMPApp, "select SudahProsesAcc as GetValueString from RMPApp..TblTrnUpahBongkarHdr where HeaderID=" & HeaderID) = True Then
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
                        Using cmd As New SqlCommand("RMPApp..sp_TrnUpahBongkarDelete", Conn, Trans)
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
                    ' === Aksi jika klik kolom View ===
                    ' Cek apakah form masih terbuka
                    For Each f As Form In Application.OpenForms
                        If TypeOf f Is FrmTrnPotonganRelasi Then
                            f.Close()
                            Exit For
                        End If
                    Next

                    ' === Buat instance baru ===
                    Dim frm As New FrmTrnPotonganRelasi
                    With frm
                        .StatusOpenForm = "View"
                        FrmMain.BukaMenu(frm, FrmMain.mnuTrnPotonganRelasi)
                        .ShowDataView(fg.Item(fg.Row, "HeaderID"))
                    End With
            End Select
        End With
    End Sub

    Private Sub FrmTrnApprovalPenerimaanFind_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        lblJudulForm.Left = (Me.Width - lblJudulForm.Width) / 2
    End Sub

    Private Sub btnMonitoring_Click(sender As Object, e As EventArgs)
        FrmMonPengajuanPenerimaanNota.Show(FrmMain.DockPanel1)
    End Sub

    Private Sub btnAddVoucher_Click(sender As Object, e As EventArgs) Handles btnAddVoucher.Click
        FrmTrnPotonganRelasiVoucher.ShowDialog()
    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg.BeforeEdit
        e.Cancel = True
    End Sub
End Class