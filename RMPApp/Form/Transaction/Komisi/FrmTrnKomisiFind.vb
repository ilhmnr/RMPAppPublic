Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports Microsoft.Office.Interop

Public Class FrmTrnKomisiFind
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
            If TypeOf f Is FrmTrnKomisi Then
                f.Close()
                Exit For
            End If
        Next

        FrmMain.BukaMenu(FrmTrnKomisi, FrmMain.mnuTrnKomisi)
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
        Dim sql As String = "select *,case when IDJenisBahanBaku=1 then 'Kelapa Bulat' else 'Cungkil' end as JenisBahanBaku from RMPApp..tblTrnKomisiHdr where Deleted=0 and TanggalPengajuan between '" & Format(dtpTanggalApproval1.Value, "yyyy-MM-dd") & "' and '" & Format(dtpTanggalApproval2.Value, "yyyy-MM-dd") & "' and NoTrans like '%" & txtNoTrans.Text & "%' order by TanggalPengajuan asc"

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fg
            .Rows.Count = 1 ' Reset grid

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "HeaderID") = row("HeaderID")
                    .Item(i, "NoTrans") = row("NoTrans")
                    .Item(i, "TanggalPengajuan") = row("TanggalPengajuan")
                    .Item(i, "TanggalPeriode1") = row("TanggalStart")
                    .Item(i, "TanggalPeriode2") = row("TanggalEnd")
                    .Item(i, "JenisKomisi") = row("JenisKomisi")
                    .Item(i, "JenisBahanBaku") = row("JenisBahanBaku")
                    .Item(i, "CreatedBy") = row("CreatedBy")
                    .Item(i, "CreatedDate") = row("CreatedDate")

                    ' Masukkan gambar yang sudah di-resize
                    .SetCellImage(i, "View", Func.ResizeImage(My.Resources.Doc1, 16, 16))
                    .SetCellImage(i, "Edit", Func.ResizeImage(My.Resources.edit, 16, 16))

                    i += 1
                Next

                .AutoSizeCols()
            Else
                MsgBoxCustom.Show("Data tidak ditemukan.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
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
                        MsgBoxCustom.Show("Anda tidak memiliki hak akses untuk menghapus data.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                        Exit Sub
                    End If

                    Dim HeaderID As Integer = .Item(.Row, "HeaderID")

                    If MsgBoxCustom.Show("Apakah Anda ingin menghapus pengajuan penerimaan No. Trans: " & fg.Item(fg.Row, "NoTrans") & " ?", MsgBoxCustom.ButtonType.YesNo, MsgBoxCustom.IconType.Question) = DialogResult.No Then Exit Sub

                    ' Cek apakah sudah diproses
                    If DB.ExecuteScalarValue(Of String)(StrConnRMPApp, "select SudahProsesAcc as GetValueString from RMPApp..TblTrnUpahBongkarHdr where HeaderID=" & HeaderID) = True Then
                        MsgBoxCustom.Show("Data No. Trans: " & fg.Item(fg.Row, "NoTrans") & " tidak dapat dihapus karena sudah diproses.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
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
                        MsgBoxCustom.Show("Delete Data Gagal.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
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
                                MsgBoxCustom.Show("Data Tambang Kapal No. Trans: " & fg.Item(fg.Row, "NoTrans") & " berhasil dihapus.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                            Else
                                Trans.Rollback()
                                MsgBoxCustom.Show("GAGAL menghapus data No. Trans: " & fg.Item(fg.Row, "NoTrans") & "Transaksi dibatalkan!", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
                                Exit Sub
                            End If
                        End Using

                    Catch ex As Exception
                        Trans.Rollback()
                        MsgBoxCustom.Show("Error saat proses delete: " & ex.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
                        Exit Sub

                    Finally
                        Conn.Close()
                    End Try

                    btnSearch.PerformClick()
                Case "View"
                    ' === Aksi jika klik kolom View ===
                    ' Cek apakah form masih terbuka
                    For Each f As Form In Application.OpenForms
                        If TypeOf f Is FrmTrnKomisi Then
                            f.Close()
                            Exit For
                        End If
                    Next

                    ' === Buat instance baru ===
                    Dim frm As New FrmTrnKomisi
                    With frm
                        .StatusOpenForm = "View"
                        FrmMain.BukaMenu(frm, FrmMain.mnuTrnKomisi)
                        .ShowDataView(fg.Item(fg.Row, "HeaderID"))
                    End With
                Case "Edit"
                    If CanEdit = False Then
                        MsgBoxCustom.Show("Anda tidak memiliki hak akses untuk mengubah data.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                        Exit Sub
                    End If

                    Dim NoTrans As String = fg.Item(fg.Row, "NoTrans")

                    ' === Aksi jika klik kolom View ===
                    ' Cek apakah form masih terbuka
                    For Each f As Form In Application.OpenForms
                        If TypeOf f Is FrmTrnKomisi Then
                            f.Close()
                            Exit For
                        End If
                    Next

                    ' === Buat instance baru ===
                    Dim frm As New FrmTrnKomisi
                    With frm
                        .StatusOpenForm = "Edit"
                        FrmMain.BukaMenu(frm, FrmMain.mnuTrnKomisi)
                        .HeaderID = fg.Item(fg.Row, "HeaderID")
                        .ShowDataView(fg.Item(fg.Row, "HeaderID"))
                    End With
            End Select
        End With
    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg.BeforeEdit
        e.Cancel = True
    End Sub
End Class