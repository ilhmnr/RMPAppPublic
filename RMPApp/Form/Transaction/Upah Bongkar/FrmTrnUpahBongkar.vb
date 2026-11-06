Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports Microsoft.Office.Interop

Public Class FrmTrnUpahBongkar
    Private CanEdit, CanAdd, CanDelete, CanSave As Boolean
    Private Sub FrmTrnApprovalPenerimaanFind_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpTanggalApproval1.Value = Now
        dtpTanggalApproval2.Value = Now

        Combo.SetPancang(cboPancang)

        Call ClsFlexGrid.ApplyStyle(fg)

        Security.GetAccess(ClsSession.RoleID, Me.Tag, CanAdd, CanEdit, CanDelete, CanSave)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' tutup FrmTrnUpahBongkar jika sudah di buka
        For Each f As Form In Application.OpenForms
            If TypeOf f Is FrmTrnUpahBongkarInput Then
                f.Close()
                Exit For
            End If
        Next

        FrmMain.BukaMenu(FrmTrnUpahBongkarInput, FrmMain.mnuTrnUpahBongkar)
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
        Dim sql As String = "select * from vw_TrnUpahBongkarBPIHdr where TanggalPengajuan between '" & Format(dtpTanggalApproval1.Value, "yyyy-MM-dd") & "' and '" & Format(dtpTanggalApproval2.Value, "yyyy-MM-dd") & "' and NoTrans like '%" & txtNoTrans.Text & "%'"

        If cboPancang.Text <> "" Then
            sql &= " and IDPancang=" & cboPancang.SelectedValue
        End If

        sql &= " order by TanggalPengajuan desc"

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fg
            .Rows.Count = 1 ' Reset grid

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "HeaderID") = row("HeaderID")
                    .Item(i, "NoTrans") = row("NoTrans")
                    .Item(i, "TanggalApproval") = row("TanggalPengajuan")
                    .Item(i, "IDRelasi") = row("IDPetani")
                    .Item(i, "NamaRelasi") = row("NamaRekening")
                    .Item(i, "Pancang") = row("Pancang")
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

                    ' Masukkan gambar yang sudah di-resize
                    .SetCellImage(i, "View", Func.ResizeImage(My.Resources.Doc1, 16, 16))
                    .SetCellImage(i, "Delete", Func.ResizeImage(My.Resources.DELETED_20, 16, 16))
                    .SetCellImage(i, "Edit", Func.ResizeImage(My.Resources.edit, 16, 16))
                    .SetCellImage(i, "Excel", Func.ResizeImage(My.Resources.excel, 16, 16))

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

                    If MsgBoxCustom.Show("Apakah Anda ingin menghapus pengajuan penerimaan No. Trans: " & fg.Item(fg.Row, "NoTrans") &
                          " ?", MsgBoxCustom.ButtonType.YesNo, MsgBoxCustom.IconType.Question) = DialogResult.No Then Exit Sub

                    ' Cek apakah sudah diproses
                    If DB.ExecuteScalarValue(Of String)(StrConnRMPApp, "select SudahProsesAcc as GetValueString from RMPApp..TblTrnUpahBongkarHdr where HeaderID=" & HeaderID) = True Then
                        MsgBoxCustom.Show("Data No. Trans: " & fg.Item(fg.Row, "NoTrans") & " tidak dapat dihapus karena sudah diproses.",
                           MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
                        Exit Sub
                    End If

                    '  INPUT KETERANGAN DELETE
                    Dim fr As New FrmKeteranganDelete
                    Dim KeteranganDelete As String

                    If fr.ShowDialog() = DialogResult.OK Then
                        KeteranganDelete = fr.ResultText
                    Else
                        KeteranganDelete = ""
                    End If

                    If KeteranganDelete = "" Then
                        MsgBoxCustom.Show("Delete Data Gagal.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
                        Exit Sub
                    End If

                    Me.Cursor = Cursors.WaitCursor

                    '  EKSEKUSI SP PAKAI TRANSAKSI
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
                                MsgBoxCustom.Show("Data Tambang Kapal No. Trans: " & fg.Item(fg.Row, "NoTrans") & " berhasil dihapus.",
                                   MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                            Else
                                Trans.Rollback()
                                MsgBoxCustom.Show("GAGAL menghapus data No. Trans: " & fg.Item(fg.Row, "NoTrans") & vbCrLf &
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
                        Me.Cursor = Cursors.Default
                    End Try

                    btnSearch.PerformClick()
                Case "View"
                    ' === Aksi jika klik kolom View ===
                    ' Cek apakah form masih terbuka
                    For Each f As Form In Application.OpenForms
                        If TypeOf f Is FrmTrnUpahBongkarInput Then
                            f.Close()
                            Exit For
                        End If
                    Next

                    ' === Buat instance baru ===
                    Dim frm As New FrmTrnUpahBongkarInput
                    With frm
                        .StatusOpenForm = "View"
                        FrmMain.BukaMenu(frm, FrmMain.mnuTrnUpahBongkar)
                        .ShowDataView(fg.Item(fg.Row, "HeaderID"))
                    End With
                Case "Edit"
                    If CanEdit = False Then
                        MsgBoxCustom.Show("Anda tidak memiliki hak akses untuk mengedit data.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                        Exit Sub
                    End If

                    Dim NoTrans As String = fg.Item(fg.Row, "NoTrans")

                        ' === Aksi jika klik kolom View ===
                        ' Cek apakah form masih terbuka
                        For Each f As Form In Application.OpenForms
                            If TypeOf f Is FrmTrnUpahBongkarInput Then
                                f.Close()
                                Exit For
                            End If
                        Next

                        ' === Buat instance baru ===
                        Dim frm As New FrmTrnUpahBongkarInput
                        With frm
                            .StatusOpenForm = "Edit"
                            FrmMain.BukaMenu(frm, FrmMain.mnuTrnUpahBongkar)
                            .ShowDataView(fg.Item(fg.Row, "HeaderID"))
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
        Dim sql As String = "select * from vwTrnUpahBongkar where HeaderID='" & fg.Item(fg.Row, "HeaderID") & "' order by DetailID asc"

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fgDtl
            .Rows.Count = 1 ' Reset grid sebelum mengisi data baru
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "DetailID") = row("DetailID")
                    .Item(i, "ByTanggal") = row("ByTanggal")
                    .Item(i, "Tanggal") = row("Tanggal")
                    .Item(i, "IDPancang") = row("IDPancang")
                    .Item(i, "Pancang") = row("Pancang")
                    .Item(i, "IDKapal") = row("IDKapal")
                    .Item(i, "Kapal") = row("Kapal")
                    .Item(i, "Trip") = row("Trip")
                    .Item(i, "NotaVia") = row("NotaVia")
                    .Item(i, "NamaRelasi") = row("NamaRelasi")
                    .Item(i, "IDRelasi") = row("IDRelasi")
                    .Item(i, "RekeningName") = row("NamaRelasi")
                    .Item(i, "RekeningNo") = row("RekeningNo")
                    .Item(i, "RekeningBank") = row("RekeningBank")
                    .Item(i, "BadanUsaha") = row("BadanUsaha")
                    .Item(i, "Netto2Pancang") = row("Netto2Pancang")
                    .Item(i, "Tarif") = row("Tarif")
                    .Item(i, "TotalRp") = row("TotalRp")
                    .Item(i, "DPP") = row("DPP")
                    .Item(i, "AkumulasiDPP") = row("AkumulasiDPP")
                    .Item(i, "TarifPajak") = row("TarifPajak")
                    .Item(i, "PotPPH21") = row("PotPPH21")
                    .Item(i, "PotPPH23") = row("PotPPH23")
                    .Item(i, "PotBPJS") = row("PotBPJS")
                    .Item(i, "PotonganDP") = row("PotonganDP")
                    .Item(i, "SisaDP") = row("SisaDP")
                    .Item(i, "GrandTotal") = row("GrandTotal")

                    i += 1
                Next

                .Rows.Insert(1)


                ' === HITUNG TOTAL ===
                Dim totalNetto2Pancang As Decimal = 0
                Dim totalRp As Decimal = 0
                Dim totalDPP As Decimal = 0
                Dim totalAkumulasiDPP As Decimal = 0
                Dim totalPotPPH21 As Decimal = 0
                Dim totalPotPPH23 As Decimal = 0
                Dim totalPotBPJS As Decimal = 0
                Dim totalPotonganDP As Decimal = 0
                Dim totalSisaDP As Decimal = 0
                Dim totalGrandTotal As Decimal = 0

                For r As Integer = 2 To .Rows.Count - 1
                    totalNetto2Pancang += Val(.Item(r, "Netto2Pancang"))
                    totalRp += Val(.Item(r, "TotalRp"))
                    totalDPP += Val(.Item(r, "DPP"))
                    totalAkumulasiDPP += Val(.Item(r, "AkumulasiDPP"))
                    totalPotPPH21 += Val(.Item(r, "PotPPH21"))
                    totalPotPPH23 += Val(.Item(r, "PotPPH23"))
                    totalPotBPJS += Val(.Item(r, "PotBPJS"))
                    totalPotonganDP += Val(.Item(r, "PotonganDP"))
                    totalSisaDP += Val(.Item(r, "SisaDP"))
                    totalGrandTotal += Val(.Item(r, "GrandTotal"))
                Next

                ' === SET TOTAL DI ROW INDEX 1 ===
                .Item(1, "NamaRelasi") = "TOTAL"
                .Item(1, "Netto2Pancang") = totalNetto2Pancang
                .Item(1, "TotalRp") = totalRp
                .Item(1, "DPP") = totalDPP
                .Item(1, "AkumulasiDPP") = totalAkumulasiDPP
                .Item(1, "PotPPH21") = totalPotPPH21
                .Item(1, "PotPPH23") = totalPotPPH23
                .Item(1, "PotBPJS") = totalPotBPJS
                .Item(1, "PotonganDP") = totalPotonganDP
                .Item(1, "SisaDP") = totalSisaDP
                .Item(1, "GrandTotal") = totalGrandTotal

                ' === WARNA BARIS TOTAL ===
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
            save.FileName = "Pancang = " & fg.Item(fg.Row, "Pancang") &
                    " - No.Trans = " & fg.Item(fg.Row, "NoTrans") &
                    " - Tgl Pengajuan = " & Format(CDate(fg.Item(fg.Row, "TanggalApproval")), "ddMMyy")

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

    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg.BeforeEdit
        e.Cancel = True
    End Sub
End Class