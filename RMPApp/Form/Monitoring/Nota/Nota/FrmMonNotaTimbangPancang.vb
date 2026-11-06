Imports System.Data.SqlClient
Imports System.Web.Compilation
Imports System.Windows.Media.Media3D
Imports C1.Win.C1FlexGrid
Imports RMPApp.ClsVariable
Imports WeifenLuo.WinFormsUI.Docking

Public Class FrmMonNotaTimbangPancang
    Private CanEdit, CanAdd, CanDelete, CanSave As Boolean
    Private Sub FrmMonNotaTimbangPancang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClsFlexGrid.ApplyStyle(fg)
        Call init()
        Call setcombo()

        fg.Cols("SelectGroupNota").Visible = False
        fg.Cols("DeleteGroupNota").Visible = False
        btnSaveGroup.Enabled = False
    End Sub

    Private Sub init()
        dtpTglNota1.Value = Now
        dtpTglNota2.Value = Now
        dtpTglJual1.Value = Now
        dtpTglJual2.Value = Now
    End Sub

    Private Sub setcombo()
        'If ClsSession.RoleName = "ADMIN NOTA" Then
        '    Combo.PancangByGroup(cmbPancang, ClsSession.UserID)
        'Else
        '    Combo.SetPancang(cmbPancang)
        'End If
        Combo.SetPancang(cmbPancang)
        Combo.SetKapal(cmbKapal)
        Combo.SetJenisKB(cmbJenisKB)
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Me.Cursor = Cursors.WaitCursor

        If chkTglNota.Checked = False And chkTglPenjualan.Checked = False Then
            MsgBoxCustom.Show("Silahkan pilih filter tanggal nota atau tanggal penjualan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Dim i As Integer
        Dim dt As DataTable = New DataTable
        Dim sql As String = "SELECT * FROM vwMonNotaTimbangPancang as a where 1=1"

        If txtNoNota.Text <> "" Then
            sql &= " and a.NoNota like '%" & txtNoNota.Text & "%'"
        End If

        If chkTglNota.Checked Then
            sql &= " and cast(a.TanggalNota as date) between '" & Format(dtpTglNota1.Value, "yyyy-MM-dd") & "' and '" & Format(dtpTglNota2.Value, "yyyy-MM-dd") & "'"
        End If

        If chkTglPenjualan.Checked Then
            sql &= " and cast(a.TglPengajuanPenjualan as date) between '" & Format(dtpTglJual1.Value, "yyyy-MM-dd") & "' and '" & Format(dtpTglJual2.Value, "yyyy-MM-dd") & "'"
        End If

        If chkTujuan.Checked Then
            If rdPSG.Checked Then
                sql &= " and a.Bongkar='PSG'"
            ElseIf rdRSUP.Checked Then
                sql &= " and a.Bongkar='RSUP'"
            ElseIf rdManual.Checked Then
                sql &= " and a.Bongkar=" & txtTujuanManual.Text
            End If
        End If

        If cmbPancang.Text <> "" Then
            sql &= " and a.IDPancang=" & cmbPancang.SelectedValue & ""
        End If

        If cmbKapal.Text <> "" Then
            sql &= " and a.KapalID=" & cmbKapal.SelectedValue & ""
        End If

        If txtTrip.Text <> "" Then
            sql &= " and a.Trip=" & txtTrip.Text & ""
        End If

        If cmbJenisKB.Text <> "" Then
            sql &= " and a.JenisKB='" & cmbJenisKB.Text & "'"
        End If

        sql &= " and (a.IDRelasi like '%" & txtKodeSupRelasi.Text & "%' or a.NamaRelasi like '%" & txtKodeSupRelasi.Text & "%')"

        sql &= " and (a.IDSubPetani like '%" & txtKodeSupPetani.Text & "%' or a.NamaSubPetani like '%" & txtKodeSupPetani.Text & "%')"

        '   If ClsSession.RoleName = "ADMIN NOTA" Then
        '       sql &= " and EXISTS (
        '    SELECT 1 FROM tblUtlPancangGroup pg
        '	INNER JOIN tblUtlUserPancangGroup upg ON upg.GroupID = pg.GroupID
        '	WHERE pg.IDPancang = a.IDPancang AND upg.UserID = '" & ClsSession.UserID & "'
        ')"
        '   End If

        sql &= " ORDER BY a.IDPancang,a.TanggalNota "

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        fg.Rows.Count = 1
        i = 1

        With fg
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)

                    .Item(i, "TransID") = row("TransID")
                    .Item(i, "NoNota") = row("NoNota")
                    .Item(i, "KodeGroupNota") = row("kode_group_nota")
                    .Item(i, "Trip") = row("Trip")
                    .Item(i, "TglTransaksi") = row("TransDate")
                    .Item(i, "TanggalNota") = row("TanggalNota")
                    .Item(i, "TglMasukKapal") = row("TglMasukKapal")
                    .Item(i, "Pembayaran") = row("Pembayaran")
                    .Item(i, "NotaVia") = row("NotaViaName")
                    .Item(i, "Tujuan") = row("Bongkar")
                    .Item(i, "Jenis") = row("Jenis")
                    .Item(i, "JenisKB") = row("JenisKB")
                    .Item(i, "GradeSub") = row("GradeSub")
                    .Item(i, "GradeSubA") = row("GradeSubA")
                    .Item(i, "Pancang") = row("Pancang")
                    .Item(i, "Mobil") = row("Mobil")
                    .Item(i, "Kapal") = row("Kapal")
                    .Item(i, "Supplier") = row("Supplier")
                    .Item(i, "SubPetani") = row("SubPetani")
                    .Item(i, "PenerimaUang") = row("PenerimaUang")
                    .Item(i, "NoHpPenerimaUang") = row("NoHpPenerimaUang")
                    .Item(i, "NamaRekening") = row("NamaRekening")
                    .Item(i, "NoRekening") = row("NoRekening")
                    .Item(i, "JenisBank") = row("JenisBank")
                    .Item(i, "Brutto") = row("Brutto")
                    .Item(i, "JaringKg") = row("JaringKg")
                    .Item(i, "TarraJaring") = row("TarraJaring")
                    .Item(i, "Netto") = row("Netto")
                    .Item(i, "TarraPersen") = row("TarraPersen")
                    .Item(i, "NettoAkhir") = row("NettoAkhir")
                    .Item(i, "TarraKg") = row("TarraKg")
                    .Item(i, "Harga") = row("Harga")
                    .Item(i, "TotalHarga") = row("TotalHarga")
                    .Item(i, "Potongan") = row("Potongan")
                    .Item(i, "JenisPotongan") = row("JenisPotongan")
                    .Item(i, "JumlahKarung") = row("JumlahKarung")
                    .Item(i, "HargaSubsidiKarung") = row("HargaSubsidiKarung")
                    .Item(i, "TotalKarung") = row("TotalKarung")
                    .Item(i, "TotalRpAkhir") = row("TotalRupiahAkhir")
                    .Item(i, "KeteranganKapal") = row("KeteranganKapal")
                    .Item(i, "NoTransPengajuanPenerimaanNota") = row("NoTransPengajuanPenerimaan")
                    .Item(i, "TglPengajuanPenerimaanNota") = row("TglPengajuanPenerimaan")
                    .Item(i, "NoNPBB") = row("NPBBNo")
                    .Item(i, "NoBTB") = row("BTBID")
                    .Item(i, "QtyStok") = row("QtyAwal")
                    .Item(i, "QtyStokAvailable") = row("Qnty")
                    .Item(i, "NoTransPengajuanUpahBongkar") = row("NoTransPengajuanUpahBongkar")
                    .Item(i, "TglPengajuanUpahBongkar") = row("TglPengajuanUpahBongkar")
                    .Item(i, "NoTransPengajuanPenjualan") = row("NoTransPengajuanPenjualan")
                    .Item(i, "TglPengajuanPenjualan") = row("TglPengajuanPenjualan")
                    .Item(i, "NoTransPengajuanTambangKapal") = row("NoTransPengajuanTambangKapal")
                    .Item(i, "TglPengajuanTambangKapal") = row("TglPengajuanTambangKapal")
                    .Item(i, "NoTransPengajuanKomisiToke") = row("NoTransPengajuanKomisiToke")
                    .Item(i, "TglPengajuanKomisiToke") = row("TglPengajuanKomisiToke")
                    .Item(i, "NoTransPengajuanKomisiLahan") = row("NoTransPengajuanKomisiLahan")
                    .Item(i, "TglPengajuanKomisiLahan") = row("TglPengajuanKomisiLahan")
                    .Item(i, "AlamatKelapa") = row("AlamatKelapa")
                    .Item(i, "namapompong") = row("namapompong")
                    .Item(i, "namapemilik") = row("namapemilik")
                    .Item(i, "UrlFotoCheckin") = row("UrlFotoCheckin")
                    .Item(i, "checkindate") = row("checkindate")
                    .Item(i, "AlasanNotaManual") = row("AlasanNotaManual")
                    .Item(i, "ApproveNotaManualBy") = row("ApproveNotaManualBy")
                    .Item(i, "ApproveNotaManualDate") = row("ApproveNotaManualDate")
                    .Item(i, "Remark") = row("Remark")
                    .Item(i, "CreatedBy") = row("CreatedBy")
                    .Item(i, "CreatedDate") = row("CreatedDate")
                    .Item(i, "UpdatedBy") = row("UpdatedBy")
                    .Item(i, "UpdateDate") = row("UpdateDate")
                    .Item(i, "UpdatedTripBy") = row("UpdatedTripBy")
                    .Item(i, "UpdatedTripDate") = row("UpdatedTripDate")

                    .SetCellImage(i, "FotoCheckin", Func.ResizeImage(My.Resources.image, 16, 16))
                    .SetCellImage(i, "FotoKelapaB", Func.ResizeImage(My.Resources.image, 16, 16))
                    .SetCellImage(i, "FotoNota", Func.ResizeImage(My.Resources.image, 16, 16))
                    .SetCellImage(i, "EditNota", Func.ResizeImage(My.Resources.edit, 16, 16))
                    .SetCellImage(i, "DeleteGroupNota", Func.ResizeImage(My.Resources.DELETED_20, 16, 16))

                    i += 1
                Next

                .AutoSizeCols()
                .Cols("Remark").Width = 200
            End If
        End With

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click
        Try
            If fg.Cols(fg.Col).Name = "FotoKelapaB" Then
                Dim dt As DataTable = New DataTable
                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select foto_kelapa_b,kelapa_b from Android_tblKelapaReject where hdr_id=" & fg.Item(fg.Row, "TransID"))
                If dt.Rows.Count > 0 Then
                    FrmFotoSlide.JudulFoto = "Foto Kelapa B"
                    FrmFotoSlide.listFoto.Clear()
                    FrmFotoSlide.listFoto = dt
                    FrmFotoSlide.ShowDialog()
                End If
            ElseIf fg.Cols(fg.Col).Name = "FotoCheckin" Then
                FrmFotoNota.Foto = "FotoCheckin"
                FrmFotoNota.images = fg.Item(fg.Row, "UrlFotoCheckin")
                FrmFotoNota.ShowDialog()
            ElseIf fg.Cols(fg.Col).Name = "FotoNota" Then
                FrmFotoNota.Foto = "Nota"
                FrmFotoNota.images = fg.Item(fg.Row, "TransID")
                FrmFotoNota.ShowDialog()
            ElseIf fg.Cols(fg.Col).Name = "EditNota" Then
                Security.GetAccess(ClsSession.RoleID, Me.Tag, CanAdd, CanEdit, CanDelete, CanSave)
                If CanEdit = False Then
                    MsgBoxCustom.Show("Anda tidak memiliki akses untuk mengedit nota !", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                    Exit Sub
                End If

                Me.Cursor = Cursors.WaitCursor

                Dim sql As String = "select NoNota from TblTrnKelapaHdr where TransID='" & fg.Item(fg.Row, "TransID") & "' and NoTransApprovalPengajuan is not null"

                If DB.ExecuteScalarValue(Of String)(StrConnRMPApp, sql) <> "" Then
                    MsgBoxCustom.Show("Nota sudah di Proses, tidak bisa di edit !", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If

                With FrmMonNotaTimbangPancangEdit
                    .txtTransID.Text = fg.Item(fg.Row, "TransID")
                    .ShowDialog()
                End With

                Me.Cursor = Cursors.Default
            ElseIf fg.Cols(fg.Col).Name = "DeleteGroupNota" Then
                If fg.Item(fg.Row, "KodeGroupNota").ToString() <> "" Then
                    If MsgBoxCustom.Show("Apakah anda yakin ingin menghapus group nota ini " & fg.Item(fg.Row, "KodeGroupNota").ToString() & " ?", MsgBoxCustom.ButtonType.YesNo, MsgBoxCustom.IconType.Question) = DialogResult.Yes Then
                        If DB.ExecuteScalarValue(Of Integer)(StrConnRMPApp, "select ISNULL((select top 1 1 from TblTrnKelapaHdrGroupNota where use_tambang_kapal_transit=1 and kode_group_nota='" & fg.Item(fg.Row, "KodeGroupNota") & "'),0)") = 1 Then
                            MsgBoxCustom.Show("Group nota ini sudah digunakan untuk pengajuan tambang kapal, tidak bisa dihapus !", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                            Exit Sub
                        End If


                        Dim sql As String = "exec spTrnGroupNotaTimbang '" & fg.Item(fg.Row, "KodeGroupNota") & "','','" & ClsSession.UserID & "','delete',0"
                        DB.ExecuteNonQuery(StrConnRMPApp, sql)
                        MsgBoxCustom.Show("Group nota berhasil dihapus.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)

                        fg.Cols("SelectGroupNota").Visible = False
                        fg.Cols("DeleteGroupNota").Visible = False
                        btnSaveGroup.Enabled = False
                        btnRefresh.PerformClick()
                    End If
                Else
                    MsgBoxCustom.Show("Data ini tidak memiliki group nota !", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                End If
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        RekapExcel()
    End Sub
    Private Function RekapExcel() As Boolean
        RekapExcel = False

        Try
            ' === Cek data ===
            If fg.Rows.Count <= 1 Then
                MsgBoxCustom.Show("Tidak ada data untuk diexport.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                Exit Function
            End If

            Using save As New SaveFileDialog
                save.Filter = "Excel File (*.xlsx)|*.xlsx"
                save.FileName = "Nota Timbang Pancang_" & Format(Now, "yyyyMMdd")

                If save.ShowDialog() = DialogResult.OK Then

                    ' === EXPORT LANGSUNG DARI FLEXGRID ===
                    fg.SaveExcel(save.FileName, "Sheet1", FileFlags.IncludeFixedCells)

                    If IO.File.Exists(save.FileName) Then
                        MsgBoxCustom.Show("Export berhasil.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                        RekapExcel = True
                    Else
                        MsgBoxCustom.Show("Export gagal.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
                    End If
                End If
            End Using

        Catch ex As Exception
            MsgBoxCustom.Show("Error Export : " & ex.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
        End Try

        Return RekapExcel
    End Function

    Private Sub btnInputTglMasukKapal_Click(sender As Object, e As EventArgs) Handles btnInputTglMasukKapal.Click
        With FrmTrnInputTrip
            If fg.Rows.Count <= 1 Then
                MsgBoxCustom.Show("Tidak ada data untuk diinput trip !", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                Exit Sub
            End If

            If cmbPancang.Text = "" Then
                MsgBoxCustom.Show("Pancang Is empty !", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
                cmbPancang.Focus()
                Exit Sub
            End If

            If cmbKapal.Text = "" Then
                MsgBoxCustom.Show("Kapal Is empty !", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
                cmbKapal.Focus()
                Exit Sub
            End If

            .Show(FrmMain.DockPanel1)
            .FilterData(1)
        End With
    End Sub

    Private Sub btnMonKapal_Click(sender As Object, e As EventArgs) Handles btnMonKapal.Click
        FrmMonKapalCheckIndanOTW.Show()
    End Sub

    Private Sub btnPrintAll_Click(sender As Object, e As EventArgs) Handles btnPrintAll.Click
        FrmMonPrintNotaALL.Show()
    End Sub

    Private Sub fg_AfterSelChange(sender As Object, e As EventArgs) Handles fg.AfterSelChange
        Try
            Dim total As Decimal = 0

            Dim rng As C1.Win.C1FlexGrid.CellRange = fg.Selection

            For r As Integer = rng.r1 To rng.r2
                For c As Integer = rng.c1 To rng.c2

                    If IsNumeric(fg.Item(r, c)) Then
                        total += Convert.ToDecimal(fg.Item(r, c))
                    End If

                Next
            Next

            txtTotalDiblok.Text = total.ToString("#,##0.##")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fg_KeyDown(sender As Object, e As KeyEventArgs) Handles fg.KeyDown

        If e.Control AndAlso e.KeyCode = Keys.C Then
            fg.Copy()
            e.Handled = True
        End If

    End Sub

    Private Sub btnFindRelasi_Click(sender As Object, e As EventArgs) Handles btnFindRelasi.Click
        Using frm As New FrmDlgSupplier()

            If frm.ShowDialog(Me) = DialogResult.OK Then
                txtKodeSupRelasi.Text = frm.KodeSup
                txtNamaSupRelasi.Text = frm.NamaSup
            End If

        End Using
    End Sub

    Private Sub btnFindPetani_Click(sender As Object, e As EventArgs) Handles btnFindPetani.Click
        Using frm As New FrmDlgSupplier()

            If frm.ShowDialog(Me) = DialogResult.OK Then
                txtKodeSupPetani.Text = frm.KodeSup
                txtNamaSupPetani.Text = frm.NamaSup
            End If

        End Using
    End Sub

    Private Sub btnAddGroup_Click(sender As Object, e As EventArgs) Handles btnEditGroup.Click
        fg.Cols("SelectGroupNota").Visible = True
        fg.Cols("DeleteGroupNota").Visible = True
        btnSaveGroup.Enabled = True
    End Sub

    Private Sub btnSaveGroup_Click(sender As Object, e As EventArgs) Handles btnSaveGroup.Click
        Dim AdaPilih As Boolean = False

        For i As Integer = 1 To fg.Rows.Count - 1
            If fg.Item(i, "SelectGroupNota") = True And fg.Item(i, "KodeGroupNota").ToString() = "" Then
                AdaPilih = True
                Exit For
            End If
        Next

        If Not AdaPilih Then
            MsgBoxCustom.Show("Tidak ada data yang dipilih untuk diinputkan group !",
                          MsgBoxCustom.ButtonType.OK,
                          MsgBoxCustom.IconType.Information)
            Exit Sub
        End If

        Dim KodeGroup As String = ""

        Using conn As SqlConnection = DB.OpenConnection(StrConnRMPApp)
            Using tran As SqlTransaction = conn.BeginTransaction()
                Try
                    For i As Integer = 1 To fg.Rows.Count - 1
                        If fg.Item(i, "SelectGroupNota") = True And fg.Item(i, "KodeGroupNota").ToString() = "" Then
                            Using cmd As New SqlCommand("spTrnGroupNotaTimbang", conn, tran)
                                cmd.CommandType = CommandType.StoredProcedure
                                cmd.Parameters.AddWithValue("@NoNota", fg.Item(i, "NoNota"))
                                cmd.Parameters.AddWithValue("@CreatedBy", ClsSession.UserID)
                                cmd.Parameters.AddWithValue("@Aksi", "add")

                                Dim pKodeGroup As SqlParameter = cmd.Parameters.Add("@KodeGroupNota", SqlDbType.VarChar, 30)
                                pKodeGroup.Direction = ParameterDirection.InputOutput
                                pKodeGroup.Value = KodeGroup

                                Dim pFlag As SqlParameter = cmd.Parameters.Add("@Flag", SqlDbType.Int)
                                pFlag.Direction = ParameterDirection.InputOutput
                                pFlag.Value = 0

                                cmd.ExecuteNonQuery()

                                If Convert.ToInt32(pFlag.Value) <> 1 Then
                                    Throw New Exception("Gagal membuat group.")
                                End If

                                KodeGroup = pKodeGroup.Value.ToString()
                            End Using
                        End If
                    Next

                    tran.Commit()

                    MsgBoxCustom.Show("Group berhasil disimpan.",
                                  MsgBoxCustom.ButtonType.OK,
                                  MsgBoxCustom.IconType.Information)

                    fg.Cols("SelectGroupNota").Visible = False
                    fg.Cols("DeleteGroupNota").Visible = False
                    btnSaveGroup.Enabled = False
                    btnRefresh.PerformClick()

                Catch ex As Exception
                    tran.Rollback()

                    MsgBoxCustom.Show("Error : " & ex.Message,
                                  MsgBoxCustom.ButtonType.OK,
                                  MsgBoxCustom.IconType.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg.BeforeEdit
        If fg.Row = 0 OrElse fg.Col = 0 Then
            e.Cancel = True
            Exit Sub
        End If

        If fg.Cols(e.Col).Name = "SelectGroupNota" AndAlso
       fg.Item(fg.Row, "KodeGroupNota").ToString() <> "" Then
            e.Cancel = True
        End If
    End Sub
End Class