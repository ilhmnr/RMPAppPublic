Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports Microsoft.Office.Interop

Public Class FrmTrnPengajuanPenerimaanNota
    Private CanEdit, CanAdd, CanDelete, CanSave As Boolean
    Private Sub FrmTrnApprovalPenerimaanFind_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpTanggalApproval1.Value = Now
        dtpTanggalApproval2.Value = Now

        If ClsSession.RoleName = "ADMIN NOTA" Then
            Modul_RMP.Combo.PancangByGroup(cboPancang, ClsSession.UserID)
        Else
            Modul_RMP.Combo.SetPancang(cboPancang)
        End If
        Modul_RMP.Combo.SetKapal(cboKapal)

        Call ClsFlexGrid.ApplyStyle(fg)
        Call ClsFlexGrid.ApplyStyle(fgDtl)

        Security.GetAccess(ClsSession.RoleID, Me.Tag, CanAdd, CanEdit, CanDelete, CanSave)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Call ShowData()
    End Sub

    Public Sub ShowData()
        Dim dt As New DataTable
        Dim i As Integer = 1
        Dim sql As String = "select * from vwTrnPengajuanPenerimaanNotaHdr as a 
                             where cast(a.TanggalApproval as date) between '" & Format(dtpTanggalApproval1.Value, "yyyy-MM-dd") & "' and '" & Format(dtpTanggalApproval2.Value, "yyyy-MM-dd") & "'"

        If txtNoTrans.Text <> "" Then
            sql &= " and a.NoTrans like '%" & txtNoTrans.Text & "%'"
        End If

        If cboPancang.Text <> "" Then
            sql &= " and a.PancangID='" & cboPancang.SelectedValue & "'"
        End If

        If cboKapal.Text <> "" Then
            sql &= " and a.KapalID='" & cboKapal.SelectedValue & "'"
        End If

        If txtTrip.Text <> "" Then
            sql &= " and a.Trip like '%" & txtTrip.Text & "%'"
        End If

        If rdAllTujuan.Checked = False Then
            If rdPSG.Checked = True Then
                sql &= " and a.Tujuan='PSG'"
            ElseIf rdRSUP.Checked = True Then
                sql &= " and a.Tujuan='RSUP'"
            End If
        End If

        If ClsSession.RoleName = "ADMIN NOTA" Then
            sql &= " and EXISTS (
					    SELECT 1 FROM tblUtlPancangGroup pg
						INNER JOIN tblUtlUserPancangGroup upg ON upg.GroupID = pg.GroupID
						WHERE pg.IDPancang = a.PancangID AND upg.UserID = '" & ClsSession.UserID & "'
					)"
        End If

        sql &= " order by a.TanggalApproval asc"

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fg
            .Rows.Count = 1 ' Reset grid

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "NoTrans") = row("NoTrans")
                    .Item(i, "TanggalApproval") = row("TanggalApproval")
                    .Item(i, "TanggalNota1") = row("TanggalNota1")
                    .Item(i, "TanggalNota2") = row("TanggalNota2")
                    .Item(i, "PancangID") = row("PancangID")
                    .Item(i, "Pancang") = row("Pancang")
                    .Item(i, "KapalID") = row("KapalID")
                    .Item(i, "Kapal") = row("KapalName")
                    .Item(i, "Trip") = row("Trip")
                    .Item(i, "Tujuan") = row("Tujuan")
                    .Item(i, "CreatedBy") = row("CreatedBy")
                    .Item(i, "CreatedDate") = row("CreatedDate")
                    .Item(i, "ApprovalLevel") = row("approval_level")
                    .Item(i, "Approval1By") = row("approve_1_by")
                    .Item(i, "StatusApproval1") = row("approval_status_1")
                    .Item(i, "Approval2By") = row("approve_2_by")
                    .Item(i, "StatusApproval2") = row("approval_status_2")
                    .Item(i, "Approval3By") = row("approve_3_by")
                    .Item(i, "StatusApproval3") = row("approval_status_3")
                    .Item(i, "Approval4By") = row("approve_4_by")
                    .Item(i, "StatusApproval4") = row("approval_status_4")
                    .Item(i, "Approval5By") = row("approve_5_by")
                    .Item(i, "StatusApproval5") = row("approval_status_5")
                    .Item(i, "IndPECU") = row("IndPECU")

                    ' Masukkan gambar yang sudah di-resize
                    .SetCellImage(i, "View", Func.ResizeImage(My.Resources.Doc1, 16, 16))
                    .SetCellImage(i, "Delete", Func.ResizeImage(My.Resources.DELETED_20, 16, 16))
                    .SetCellImage(i, "Excel", Func.ResizeImage(My.Resources.excel, 16, 16))
                    .SetCellImage(i, "Edit", Func.ResizeImage(My.Resources.edit, 16, 16))

                    i += 1
                Next

                .AutoSizeCols()
            Else
                MsgBoxCustom.Show("Tidak ada data.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
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
                        MsgBoxCustom.Show("Anda tidak memiliki hak akses untuk menghapus data.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
                        Exit Sub
                    End If

                    Dim noTrans As String = .Item(.Row, "NoTrans")

                    If MsgBoxCustom.Show("Apakah Anda ingin menghapus pengajuan penerimaan No. Trans: " & noTrans &
                          " ?", MsgBoxCustom.ButtonType.YesNo, MsgBoxCustom.IconType.Question) = DialogResult.No Then Exit Sub

                    ' Cek apakah sudah diproses
                    'If DB.ExecuteScalarValue(Of String)(StrConnRMPApp,
                    '"SELECT ISNULL((SELECT TOP 1 '1' 
                    '                FROM RMPApp..TblTrnApprovalPenerimaanDtl 
                    '                WHERE StatusProses IS NOT NULL 
                    '                AND NoTrans='" & noTrans & "'),'0') AS GetValueString") = "1" Then

                    '    MsgBoxCustom.Show("Data No. Trans: " & noTrans & " tidak dapat dihapus karena sudah diproses.",
                    '       MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
                    '    Exit Sub
                    'End If

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
                        MsgBoxCustom.Show("Delete Data Gagal.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
                        Exit Sub
                    End If

                    ' ==========================
                    '  EKSEKUSI SP PAKAI TRANSAKSI
                    ' ==========================
                    Dim Conn As New SqlConnection(StrConnRMPApp)
                    Conn.Open()

                    Dim Trans As SqlTransaction = Conn.BeginTransaction()

                    Try
                        Using cmd As New SqlCommand("spTrnPengajuanPenerimaanNotaHdrDelete", Conn, Trans)
                            cmd.CommandType = CommandType.StoredProcedure

                            cmd.Parameters.Add("@NoTrans", SqlDbType.VarChar, 30).Value = noTrans
                            cmd.Parameters.Add("@KeteranganDeleted", SqlDbType.VarChar, 500).Value = KeteranganDelete
                            cmd.Parameters.Add("@DeletedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
                            cmd.Parameters.Add("@AppVersion", SqlDbType.VarChar, 50).Value = My.Application.Info.Version.ToString()
                            cmd.Parameters.Add("@Flag", SqlDbType.Int).Direction = ParameterDirection.Output

                            cmd.ExecuteNonQuery()

                            Dim flagResult As Integer = CInt(cmd.Parameters("@Flag").Value)

                            If flagResult = 1 Then
                                Trans.Commit()
                                MsgBoxCustom.Show("Data Approval Penerimaan No. Trans: " & noTrans & " berhasil dihapus.",
                                   MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                            Else
                                Trans.Rollback()
                                MsgBoxCustom.Show("GAGAL menghapus data No. Trans: " & noTrans & vbCrLf &
                                   "Transaksi dibatalkan!", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
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

                    btnRefresh.PerformClick()
                Case "View"
                    If fg.Item(fg.Row, "IndPECU") = True Then
                        ' === Aksi jika klik kolom View ===
                        ' Cek apakah form masih terbuka
                        For Each f As Form In Application.OpenForms
                            If TypeOf f Is FrmTrnPengajuanPenerimaanNotaInputPECU Then
                                f.Close()
                                Exit For
                            End If
                        Next

                        ' === Buat instance baru ===
                        Dim frm As New FrmTrnPengajuanPenerimaanNotaInputPECU

                        With frm
                            .StatusOpenForm = "View"
                            .txtNoTrans.Text = fg.Item(fg.Row, "NoTrans")
                            .dtpTanggalApproval.Text = fg.Item(fg.Row, "TanggalApproval")
                            .dtpTanggalNota1.Text = fg.Item(fg.Row, "TanggalNota1")
                            .dtpTanggalNota2.Text = fg.Item(fg.Row, "TanggalNota2")
                            .txtTrip.Text = fg.Item(fg.Row, "Trip")
                            .Show(FrmMain.DockPanel1)
                            .cboPancang.SelectedValue = fg.Item(fg.Row, "PancangID")
                            .cboKapal.SelectedValue = fg.Item(fg.Row, "KapalID")
                        End With
                    Else
                        ' === Aksi jika klik kolom View ===
                        ' Cek apakah form masih terbuka
                        For Each f As Form In Application.OpenForms
                            If TypeOf f Is FrmTrnPengajuanPenerimaanNotaInput Then
                                f.Close()
                                Exit For
                            End If
                        Next

                        ' === Buat instance baru ===
                        Dim frm As New FrmTrnPengajuanPenerimaanNotaInput

                        With frm
                            .StatusOpenForm = "View"
                            .txtNoTrans.Text = fg.Item(fg.Row, "NoTrans")
                            .dtpTanggalApproval.Text = fg.Item(fg.Row, "TanggalApproval")
                            .dtpTanggalNota1.Text = fg.Item(fg.Row, "TanggalNota1")
                            .dtpTanggalNota2.Text = fg.Item(fg.Row, "TanggalNota2")
                            .txtTrip.Text = fg.Item(fg.Row, "Trip")
                            .Show(FrmMain.DockPanel1)
                            .cboPancang.SelectedValue = fg.Item(fg.Row, "PancangID")
                            .cboKapal.SelectedValue = fg.Item(fg.Row, "KapalID")
                        End With
                    End If
                Case "Edit"
                    If CanEdit = False Then
                        MsgBoxCustom.Show("Anda tidak memiliki hak akses untuk mengedit data.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
                    End If

                    ' === Aksi jika klik kolom View ===
                    ' Cek apakah form masih terbuka
                    For Each f As Form In Application.OpenForms
                            If TypeOf f Is FrmTrnPengajuanPenerimaanNotaInput Then
                                f.Close()
                                Exit For
                            End If
                        Next

                        ' === Buat instance baru ===
                        Dim frm As New FrmTrnPengajuanPenerimaanNotaInput
                    With frm
                        .StatusOpenForm = "Edit"
                        .txtNoTrans.Text = fg.Item(fg.Row, "NoTrans")
                        .dtpTanggalApproval.Text = fg.Item(fg.Row, "TanggalApproval")
                        .dtpTanggalNota1.Text = fg.Item(fg.Row, "TanggalNota1")
                        .dtpTanggalNota2.Text = fg.Item(fg.Row, "TanggalNota2")
                        .txtTrip.Text = fg.Item(fg.Row, "Trip")
                        FrmMain.BukaMenu(frm, FrmMain.mnuTrnPengajuanPenerimaanNota)
                        .cboPancang.SelectedValue = fg.Item(fg.Row, "PancangID")
                        .cboKapal.SelectedValue = fg.Item(fg.Row, "KapalID")
                    End With

                Case "Excel"
                    Call CreateExcelFile()
            End Select
        End With
    End Sub

    Private Sub CreateExcelFile()
        Me.Cursor = Cursors.WaitCursor

        Dim dt As New DataTable
        Dim i As Integer = 1
        Dim sql As String = "select * from vwTrnPengajuanPenerimaanNotaDtl where NoTrans='" & fg.Item(fg.Row, "NoTrans") & "'"

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fgDtl
            .Rows.Count = 1 ' Reset grid sebelum mengisi data baru

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "InvoiceNo") = row("InvoiceNo")
                    .Item(i, "TanggalNota") = row("TanggalNota")
                    .Item(i, "Trip") = row("Trip")
                    .Item(i, "IDPancang") = row("IDPancang")
                    .Item(i, "Pancang") = row("Pancang")
                    .Item(i, "IDKapal") = row("IDKapal")
                    .Item(i, "Kapal") = row("Kapal")
                    .Item(i, "Mobil") = row("Mobil")
                    .Item(i, "Tujuan") = row("Tujuan")
                    .Item(i, "Jenis") = row("Jenis")
                    .Item(i, "Grade") = row("Grade")
                    .Item(i, "GradeSub") = row("GradeSub")
                    .Item(i, "SupplierID") = row("SupplierID")
                    .Item(i, "SupplierName") = row("SupplierName")
                    .Item(i, "RekeningName") = row("RekeningName")
                    .Item(i, "RekeningNo") = row("RekeningNo")
                    .Item(i, "RekeningBank") = row("RekeningBank")
                    .Item(i, "ItemName") = row("ItemName")
                    .Item(i, "Brutto") = row("Brutto")
                    .Item(i, "TarraJaring") = row("TarraJaring")
                    .Item(i, "Netto1") = row("Netto1")
                    .Item(i, "Tarra%") = row("TarraPersen")
                    .Item(i, "Netto2") = row("Netto2")
                    .Item(i, "HargaAwal") = row("HargaAwal")
                    .Item(i, "HargaNego") = row("HargaNego")
                    .Item(i, "HargaBeli") = row("HargaBeli")
                    .Item(i, "TotalRPBeforePPH") = row("TotalRpBeforePPH")
                    .Item(i, "PPH%") = row("PPHPersen")
                    .Item(i, "Pinjaman") = row("Pinjaman")
                    .Item(i, "PPHRP") = row("PPHRp")
                    .Item(i, "TotalRP") = row("TotalRp")

                    i += 1
                Next

                .Rows.Insert(1)

                ' === HITUNG TOTAL DAN TARUH DI ROW INDEX 1 ===
                Dim totalBrutto As Decimal = 0
                Dim totalTarraJaring As Decimal = 0
                Dim totalNetto1 As Decimal = 0
                Dim totalNetto2 As Decimal = 0
                Dim totalRPBeforePPH As Decimal = 0
                Dim totalPPHRP As Decimal = 0
                Dim totalRP As Decimal = 0
                Dim totalPinjaman As Decimal = 0

                For r As Integer = 1 To .Rows.Count - 1
                    totalBrutto += Val(.Item(r, "Brutto"))
                    totalTarraJaring += Val(.Item(r, "TarraJaring"))
                    totalNetto1 += Val(.Item(r, "Netto1"))
                    totalNetto2 += Val(.Item(r, "Netto2"))
                    totalRPBeforePPH += Val(.Item(r, "TotalRPBeforePPH"))
                    totalPPHRP += Val(.Item(r, "PPHRP"))
                    totalRP += Val(.Item(r, "TotalRP"))
                    totalPinjaman += Val(.Item(r, "Pinjaman"))
                Next

                ' === SET TOTAL DI ROW INDEX 1 ===
                .Item(1, "InvoiceNo") = "TOTAL"
                .Item(1, "Brutto") = totalBrutto
                .Item(1, "TarraJaring") = totalTarraJaring
                .Item(1, "Netto1") = totalNetto1
                .Item(1, "Netto2") = totalNetto2
                .Item(1, "TotalRPBeforePPH") = totalRPBeforePPH
                .Item(1, "PPHRP") = totalPPHRP
                .Item(1, "TotalRP") = totalRP
                .Item(1, "Pinjaman") = totalPinjaman

                ' KASIH WARNA AGAR JELAS BARIS TOTAL
                Dim s = .Styles.Add("TotalRow")
                s.BackColor = Color.LightYellow
                s.Font = New Font(.Font, FontStyle.Bold)
                .Rows(1).Style = s

                .AutoSizeCols()
            End If
        End With

        Try
            Me.Cursor = Cursors.WaitCursor

            If fgDtl.Rows.Count <= 1 Then
                MsgBoxCustom.Show("Data kosong.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                Exit Try
            End If

            Dim save As New SaveFileDialog
            save.Filter = "Excel File (*.xlsx)|*.xlsx"
            save.FileName = "Kapal = " & fg.Item(fg.Row, "Kapal") &
                    " - Trip = " & fg.Item(fg.Row, "Trip") &
                    " - Tgl Pengajuan = " &
                    Format(CDate(fg.Item(fg.Row, "TanggalApproval")), "ddMMyy")

            If save.ShowDialog() = DialogResult.OK Then

                ' === EXPORT LANGSUNG DARI GRID ===
                ' otomatis hanya kolom Visible yang diexport
                fgDtl.SaveExcel(save.FileName, "Sheet1", FileFlags.IncludeFixedCells)

                MsgBoxCustom.Show("Export berhasil!", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            End If

        Catch ex As Exception
            MsgBoxCustom.Show("Gagal export: " & ex.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)

        Finally
            Me.Cursor = Cursors.Default
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        FrmMain.BukaMenu(FrmTrnPengajuanPenerimaanNotaInput, FrmMain.mnuTrnPengajuanPenerimaanNota)
    End Sub

    Private Sub fg_SelChange(sender As Object, e As EventArgs) Handles fg.SelChange
        Dim grid As C1.Win.C1FlexGrid.C1FlexGrid = CType(sender, C1.Win.C1FlexGrid.C1FlexGrid)

        txtTotal.Text = ClsFunction.FormatNum(grid.Aggregate(AggregateEnum.Sum), 2)
    End Sub

#Region "Fg"
    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg.BeforeEdit
        e.Cancel = True
    End Sub

    Private Sub btnAddPECU_Click(sender As Object, e As EventArgs) Handles btnAddPECU.Click
        FrmMain.BukaMenu(FrmTrnPengajuanPenerimaanNotaInputPECU, FrmMain.mnuTrnPengajuanPenerimaanNota)
    End Sub
#End Region
End Class