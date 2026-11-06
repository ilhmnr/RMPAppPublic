Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmTrnPenjualan
    Private CanEdit, CanAdd, CanDelete, CanSave As Boolean
    Private Sub FrmTrnPembuatanPenjualanFind_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set ComboBox
        Modul_RMP.Combo.SetPancang(cboPancang)
        cboPancang.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboPancang.AutoCompleteSource = AutoCompleteSource.ListItems
        Modul_RMP.Combo.SetKapal(cboKapal)
        cboKapal.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboKapal.AutoCompleteSource = AutoCompleteSource.ListItems

        ' ambil awal dan akhir bulan dari tanggal sekarang
        dtpTanggalPenjualan1.Value = dtpTanggalPenjualan1.Value.AddDays(-dtpTanggalPenjualan1.Value.Day + 1)
        dtpTanggalPenjualan2.Value = dtpTanggalPenjualan2.Value.AddDays(-dtpTanggalPenjualan2.Value.Day + 1).AddMonths(1).AddDays(-1)

        Security.GetAccess(ClsSession.RoleID, Me.Tag, CanAdd, CanEdit, CanDelete, CanSave)
        If CanDelete = True Then
            fg.Cols("Delete").Visible = True
        End If

        Call ClsFlexGrid.ApplyStyle(fg)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        FrmMain.BukaMenu(FrmTrnPenjualanRSUPDanPSG, FrmMain.mnuTrnPenjualan)
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
        Dim sql As String = ""

        sql &= "select * from vwTrnPembuatanPenjualanHdr where cast(TanggalPenjualan as date) between '" & Format(dtpTanggalPenjualan1.Value, "yyyy-MM-dd") & "' and '" & Format(dtpTanggalPenjualan2.Value, "yyyy-MM-dd") & "' and NoTrans like '%" & txtNoTrans.Text & "%' "

        If rdRSUP.Checked = True Then
            sql &= " and Tujuan='RSUP' "
        ElseIf rdPSG.Checked = True Then
            sql &= " and Tujuan='PSG' "
        ElseIf rdCustomer.Checked = True Then
            sql &= " and Tujuan in ('Customer','Relasi') "
        End If

        If Replace(txtTrip.Text, " ", "") <> "" Then
            sql &= " and Trip = '" & txtTrip.Text & "' "
        End If

        If Replace(cboKapal.Text, " ", "") > "" Then
            sql &= " and IDKapal = '" & cboKapal.SelectedValue & "' "
        End If

        If Replace(cboPancang.Text, " ", "") > "" Then
            sql &= " and IDPancang = '" & cboPancang.SelectedValue & "' "
        End If

        sql &= " order by TanggalPenjualan asc"

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fg
            .Rows.Count = 1 ' Reset grid

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "NoTrans") = row("NoTrans")
                    .Item(i, "NoNotaRefrensi") = row("NoNota")
                    .Item(i, "NoDO") = row("DeliveryOrderNo")
                    .Item(i, "NoInvoice") = row("InvoiceNo")
                    .Item(i, "TanggalPenjualan") = row("TanggalPenjualan")
                    .Item(i, "TanggalNota1") = row("TanggalNota1")
                    .Item(i, "TanggalNota2") = row("TanggalNota2")
                    .Item(i, "PancangID") = row("IDPancang")
                    .Item(i, "Pancang") = row("Pancang")
                    .Item(i, "KapalID") = row("IDKapal")
                    .Item(i, "Kapal") = row("KapalName")
                    .Item(i, "Trip") = row("Trip")
                    .Item(i, "Tujuan") = row("Tujuan")
                    .Item(i, "Jenis") = row("Jenis")
                    .Item(i, "Grade") = row("Grade")
                    .Item(i, "GradeSub") = row("GradeSub")
                    .Item(i, "CreatedBy") = row("CreatedBy")
                    .Item(i, "CreatedDate") = row("CreatedDate")
                    .Item(i, "HabisBersambung") = IIf(row("Habis") = True, "Habis", "Bersambung")
                    .Item(i, "FlagParigi") = row("FlagParigi")

                    ' Masukkan gambar yang sudah di-resize
                    .SetCellImage(i, "View", Func.ResizeImage(My.Resources.Doc1, 16, 16))
                    .SetCellImage(i, "Delete", Func.ResizeImage(My.Resources.DELETED_20, 16, 16))

                    i += 1
                Next

                .AutoSizeCols()
            Else
                MsgBoxCustom.Show("Tidak ada data.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
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
                    Dim noTrans As String = .Item(.Row, "NoTrans")
                    Dim NoNotaRefrensi As String = .Item(.Row, "NoNotaRefrensi")

                    If MsgBoxCustom.Show("Apakah Anda ingin menghapus pengajuan penerimaan No. Trans: " & noTrans &
                          " ?", MsgBoxCustom.ButtonType.YesNo, MsgBoxCustom.IconType.Question) = DialogResult.No Then Exit Sub

                    ' Cek apakah sudah diproses
                    If DB.ExecuteScalarValue(Of String)(StrConnRMPApp, "SELECT ISNULL((SELECT '1' FROM tblTrnPembuatanPenjualanHdr where NoTrans='" & fg.Item(fg.Row, "NoTrans") & "' and StatusProses is not null),'0') AS GetValueString") = "1" Then
                        MsgBoxCustom.Show("Data No. Trans: " & noTrans & " tidak dapat dihapus karena sudah diproses.",
                           MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
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
                        MsgBoxCustom.Show("Delete Data Gagal.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
                        Exit Sub
                    End If

                    ' ==========================
                    '  EKSEKUSI SP PAKAI TRANSAKSI
                    ' ==========================
                    Dim Conn As New SqlConnection(StrConnRMPApp)
                    Conn.Open()

                    Dim Trans As SqlTransaction = Conn.BeginTransaction()

                    Try
                        Using cmd As New SqlCommand("RMPApp..sp_TrnPembuatanPenjualanDelete", Conn, Trans)
                            cmd.CommandType = CommandType.StoredProcedure

                            cmd.Parameters.Add("@NoTrans", SqlDbType.VarChar, 30).Value = noTrans
                            cmd.Parameters.Add("@DeletedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
                            cmd.Parameters.Add("@Keterangan", SqlDbType.VarChar, 50).Value = KeteranganDelete
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

                        If .Item(.Row, "Tujuan") = "PSG" Then
                            Modul_RMP.DB.ExecuteQuery(StrConnPSGRMP, "UPDATE tblRMTrnPenerimaanKBKGHdr
                                                            SET TFtoBPI = 0
                                                            WHERE Nonota = '" & NoNotaRefrensi & "'

                                                            UPDATE tblRMTrnPenerimaanKCDtl
                                                            SET TFtoBPI = 0
                                                            WHERE NoNota = '" & NoNotaRefrensi & "'")
                        ElseIf .Item(.Row, "Tujuan") = "RSUP" Then
                            Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "update RSUPAccounting..tblRMTrnPenerimaanKBHdr set UseBPI=0 where NoNota='" & NoNotaRefrensi & "'
                                                                update RSUPAccounting..tblRMTrnPenerimaanKCHdr set UseBPI=0 where NoNota='" & NoNotaRefrensi & "'")
                        End If

                    Catch ex As Exception
                        Trans.Rollback()
                        MsgBoxCustom.Show("Error saat proses delete: " & ex.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
                        Exit Sub

                    Finally
                        Conn.Close()
                    End Try

                    btnRefresh.PerformClick()
                Case "View"
                    If fg.Item(fg.Row, "FlagParigi") = True Then
                        ' === Aksi jika klik kolom View ===
                        ' Cek apakah form masih terbuka
                        For Each f As Form In Application.OpenForms
                            If TypeOf f Is FrmTrnPenjualanParigi Then
                                f.Close()
                                Exit For
                            End If
                        Next

                        ' === Buat instance baru ===
                        Dim frm As New FrmTrnPenjualanParigi
                        With frm
                            .Tujuan = fg.Item(fg.Row, "Tujuan")
                            .Jenis = fg.Item(fg.Row, "Jenis")
                            .Grade = fg.Item(fg.Row, "Grade")
                            .GradeSub = fg.Item(fg.Row, "GradeSub")
                            .Show(FrmMain.DockPanel1)
                            .LoadDataView(fg.Item(fg.Row, "NoTrans"))
                        End With
                    Else
                        ' === Aksi jika klik kolom View ===
                        ' Cek apakah form masih terbuka
                        For Each f As Form In Application.OpenForms
                            If TypeOf f Is FrmTrnPenjualanRSUPDanPSG Then
                                f.Close()
                                Exit For
                            End If
                        Next

                        ' === Buat instance baru ===
                        Dim frm As New FrmTrnPenjualanRSUPDanPSG
                        With frm
                            .Tujuan = fg.Item(fg.Row, "Tujuan")
                            .Jenis = fg.Item(fg.Row, "Jenis")
                            .Grade = fg.Item(fg.Row, "Grade")
                            .GradeSub = fg.Item(fg.Row, "GradeSub")
                            .Show(FrmMain.DockPanel1)
                            .LoadDataView(fg.Item(fg.Row, "NoTrans"))
                        End With
                    End If
            End Select
        End With
    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg.BeforeEdit
        e.Cancel = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAddParigi.Click
        FrmMain.BukaMenu(FrmTrnPenjualanParigi, FrmMain.mnuTrnPenjualan)
    End Sub
End Class