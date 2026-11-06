Imports System.Windows.Controls
Imports C1.Win.C1FlexGrid

Public Class FrmTrnApproval1DanInputBarangPengajuanWoPancangFind
    Public openFormBy As String
    Private Sub FrmTrnApproval1DanInputBarangPengajuanWoPancangFind_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim daysInMonth As Integer = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)

        dtpEB1.Value = Format(dtpEB1.Value, "yyyy-MM-01")
        dtpEB2.Value = Format(dtpEB2.Value, "yyyy-MM-" & daysInMonth)
        dtpP1.Value = Format(dtpP1.Value, "yyyy-MM-01")
        dtpP2.Value = Format(dtpP2.Value, "yyyy-MM-" & daysInMonth)
        dtpSpk1.Value = Format(dtpSpk1.Value, "yyyy-MM-01")
        dtpSpk2.Value = Format(dtpSpk2.Value, "yyyy-MM-" & daysInMonth)

        Modul_RMP.Combo.SetPancang(cmbPancangEB)
        Modul_RMP.Combo.SetPancang(cmbPancangP)
        Modul_RMP.Combo.SetPancang(cmbPancangSpk)
    End Sub

    Private Sub fg_DoubleClick(sender As Object, e As EventArgs) Handles fg.DoubleClick
        If fg.Rows.Count > 1 Then
            With FrmTrnApproval1DanInputBarangPengajuanWoPancang
                .kondisiAwal()

                If openFormBy <> "Pembayaran" Then
                    .txtId.Text = fg.Item(fg.RowSel, 16)
                    .txtIdPancang.Text = fg.Item(fg.RowSel, 17)
                    .txtPancang.Text = fg.Item(fg.RowSel, 2)
                    .txtJudul.Text = fg.Item(fg.RowSel, 3)
                    .txtDeskripsi.Text = fg.Item(fg.RowSel, 4)
                    .cmbJenisWo.Text = fg.Item(fg.RowSel, 5)
                    .cmbPrioritas.Text = fg.Item(fg.RowSel, 8)
                    .txtDiAjukan.Text = fg.Item(fg.RowSel, 6)
                    .dtpPengajuan.Value = fg.Item(fg.RowSel, 7)
                End If

                Select Case openFormBy
                    Case = "EstimasiBiaya"
                        Select Case fg.Item(fg.RowSel, 1)
                            Case "Belum Di Approval 1"
                                .txtJudul.Enabled = False

                                .BtnApproval.Enabled = True
                                .btnReject.Enabled = True

                                .fgListPilih.Cols(10).Visible = False
                                .fgListPilih.Cols(12).Visible = False
                            Case "Sudah Di Approval 1"
                                .txtJudul.Enabled = False

                                .BtnApproval.Enabled = False
                                .btnReject.Enabled = False
                                .BtnEdit.Enabled = True

                                .fgListPilih.Enabled = True
                                .fgListPilih.Cols(6).Visible = False
                                .fgListPilih.Cols(8).Visible = False
                                .fgListPilih.Cols(10).Visible = False
                                .fgListPilih.Cols(11).Visible = False
                                .fgListPilih.Cols(7).AllowEditing = False
                                .fgListPilih.Cols(5).AllowEditing = False

                                .loadListBarang()
                            Case "Di Reject"
                                .txtJudul.Enabled = False
                                .txtKetReject.Text = fg.Item(fg.RowSel, 20)
                            Case "Perlu Approval 1 Ulang (Reject 2)"
                                .txtJudul.Enabled = False

                                .BtnApproval.Enabled = False
                                .btnReject.Enabled = False
                                .BtnEdit.Enabled = True

                                .fgListPilih.Enabled = True
                                .fgListPilih.Cols(6).Visible = False
                                .fgListPilih.Cols(8).Visible = False
                                .fgListPilih.Cols(10).Visible = False
                                .fgListPilih.Cols(11).Visible = False
                                .fgListPilih.Cols(7).AllowEditing = False
                                .fgListPilih.Cols(5).AllowEditing = False

                                .loadListBarang()
                                .txtCatatanReject2.Text = fg.Item(fg.RowSel, 20)
                        End Select
                    Case "Proyek"
                        .btnFind.Enabled = True
                        .BtnEdit.Enabled = False
                        .btnSave.Enabled = True
                        .btnCancel.Enabled = True

                        .txtCari.Enabled = True
                        .btnCari.Enabled = True

                        .fgListPilih.Enabled = True
                        .fgListPilih.Cols(12).Visible = False
                        .loadListBarang()

                        .btnUploadFileDesain.Enabled = True
                        .btnSaveFileDesain.Enabled = True

                        .rdBukanMandiri.Checked = True

                        .rdBukanMandiri.Enabled = True
                        .rdMandiri.Enabled = True
                        .cmbKontraktor.Enabled = True
                        .cmbSubKontraktor.Enabled = True
                        .btnPdfPenawaranHarga.Enabled = True
                        .btnSaveFilePenawaran.Enabled = True

                        If Not IsDBNull(fg.Item(fg.RowSel, 19)) Then
                            .lblFileDesain.Text = fg.Item(fg.RowSel, 19)
                            .picFileDesain.BackgroundImage = My.Resources.file
                        Else
                            .lblFileDesain.Text = "No File"
                            .picFileDesain.BackgroundImage = My.Resources.no_image
                        End If

                        If fg.Item(fg.RowSel, 9) = True Then
                            .rdMandiri.Checked = True
                            .picPdf.BackgroundImage = My.Resources.no_image
                        Else
                            .rdBukanMandiri.Checked = True

                            .cmbKontraktor.Text = IIf(IsDBNull(fg.Item(fg.RowSel, 10)), "", fg.Item(fg.RowSel, 10))
                            .cmbSubKontraktor.Text = IIf(IsDBNull(fg.Item(fg.RowSel, 11)), "", fg.Item(fg.RowSel, 11))
                            .lblPathFile.Text = IIf(IsDBNull(fg.Item(fg.RowSel, 13)), "", fg.Item(fg.RowSel, 13))
                            .picPdf.BackgroundImage = My.Resources.file
                        End If
                    Case "Spk"
                        .btnFind.Enabled = True
                        .BtnEdit.Enabled = False
                        .btnSave.Enabled = False
                        .btnCancel.Enabled = False

                        .txtCari.Enabled = False
                        .btnCari.Enabled = False

                        .fgListPilih.Enabled = True
                        .fgListPilih.Cols(6).Visible = False
                        .fgListPilih.Cols(8).Visible = False
                        .fgListPilih.Cols(11).Visible = False
                        .fgListPilih.Cols(5).AllowEditing = False
                        .fgListPilih.Cols(7).AllowEditing = False
                        .fgListPilih.Cols(10).Visible = False
                        .fgListPilih.Cols(12).Visible = False
                        .loadListBarang()

                        If Not IsDBNull(fg.Item(fg.RowSel, 19)) Then
                            .lblFileDesain.Text = fg.Item(fg.RowSel, 19)
                            .picFileDesain.BackgroundImage = My.Resources.file
                        Else
                            .lblFileDesain.Text = "No File"
                            .picFileDesain.BackgroundImage = My.Resources.no_image
                        End If
                        .btnSaveFileDesain.Enabled = False

                        .rdMandiri.Enabled = False
                        .rdBukanMandiri.Enabled = False
                        .cmbKontraktor.Enabled = False
                        .cmbSubKontraktor.Enabled = False
                        .btnPdfPenawaranHarga.Enabled = False

                        If fg.Item(fg.RowSel, 9) = True Then
                            .rdMandiri.Checked = True
                            .picPdf.BackgroundImage = My.Resources.no_image
                        Else
                            .rdBukanMandiri.Checked = True

                            .cmbKontraktor.Text = IIf(IsDBNull(fg.Item(fg.RowSel, 10)), "", fg.Item(fg.RowSel, 10))
                            .cmbSubKontraktor.Text = IIf(IsDBNull(fg.Item(fg.RowSel, 11)), "", fg.Item(fg.RowSel, 11))
                            .lblPathFile.Text = IIf(IsDBNull(fg.Item(fg.RowSel, 13)), "", fg.Item(fg.RowSel, 13))
                            .picPdf.BackgroundImage = My.Resources.file
                        End If
                        .btnSaveFilePenawaran.Enabled = False

                        .btnPdfSpk.Enabled = True
                        .btnPdfProposal.Enabled = True
                        .txtHargaProyek.Enabled = True
                        .btnSaveSpk.Enabled = True

                        .lblFileSpk.Text = IIf(IsDBNull(fg.Item(fg.RowSel, 14)), "No File", fg.Item(fg.RowSel, 14))
                        .picSpk.BackgroundImage = IIf(IsDBNull(fg.Item(fg.RowSel, 14)), My.Resources.no_image, My.Resources.file)

                        .lblFileProposal.Text = IIf(IsDBNull(fg.Item(fg.RowSel, 15)), "No File", fg.Item(fg.RowSel, 15))
                        .picProposal.BackgroundImage = IIf(IsDBNull(fg.Item(fg.RowSel, 15)), My.Resources.no_image, My.Resources.file)

                        If IsDBNull(fg.Item(fg.RowSel, 12)) Then
                            .txtHargaProyek.Text = ""
                        Else
                            .txtHargaProyek.Text = CStr(String.Format("{0:n0}", CInt(fg.Item(fg.RowSel, 12))))
                        End If
                    Case "Pembayaran"
                        With FrmTrnPembayaranWoPancang
                            .txtWoId.Text = fg.Item(fg.RowSel, 16)
                            .txtPancang.Text = fg.Item(fg.RowSel, 2)
                            .txtJudul.Text = fg.Item(fg.RowSel, 3)
                            .txtHargaProyek.Text = CStr(String.Format("{0:n0}", CInt(fg.Item(fg.RowSel, 12))))
                            .txtSudahDiBayar.Text = CStr(String.Format("{0:n0}", CInt(fg.Item(fg.RowSel, 18))))
                            .txtBelumBayar.Text = CStr(String.Format("{0:n0}", CInt(fg.Item(fg.RowSel, 12) - fg.Item(fg.RowSel, 18))))

                            .loadHistoryBayar()
                        End With
                    Case "BA"
                        With FrmTrnUploadBaWoPancang
                            .txtWoId.Text = fg.Item(fg.RowSel, 16)
                            .txtPancang.Text = fg.Item(fg.RowSel, 2)
                            .txtJudul.Text = fg.Item(fg.RowSel, 3)

                            If fg.Item(fg.RowSel, 9) = True Then
                                .rdMandiri.Checked = True
                            Else
                                .rdKontraktor.Checked = True
                            End If

                            .lblFile.Text = IIf(IsDBNull(fg.Item(fg.RowSel, 22)), "No File", fg.Item(fg.RowSel, 22))
                            .picFile.BackgroundImage = IIf(IsDBNull(fg.Item(fg.RowSel, 22)), My.Resources.no_image, My.Resources.file)
                        End With
                    Case "Inspection"
                        With FrmTrnUploadInspectionWoPancang
                            .txtWoId.Text = fg.Item(fg.RowSel, 16)
                            .txtPancang.Text = fg.Item(fg.RowSel, 2)
                            .txtJudul.Text = fg.Item(fg.RowSel, 3)

                            .lblFile.Text = IIf(IsDBNull(fg.Item(fg.RowSel, 21)), "No File", fg.Item(fg.RowSel, 21))
                            .picFile.BackgroundImage = IIf(IsDBNull(fg.Item(fg.RowSel, 21)), My.Resources.no_image, My.Resources.file)
                        End With
                    Case = "BarangRequest"
                        .btnSave.Enabled = True
                        .btnCancel.Enabled = True

                        .fgListPilih.Cols(5).AllowEditing = False
                        .fgListPilih.Cols(6).Visible = False
                        .fgListPilih.Cols(7).AllowEditing = False
                        .fgListPilih.Cols(8).Visible = False
                        .fgListPilih.Cols(10).Visible = False
                        .fgListPilih.Cols(11).Visible = False
                        .fgListPilih.Cols(12).AllowEditing = True

                        .txtCari.Enabled = True
                        .btnCari.Enabled = True

                        .loadListBarang()
                End Select

                Me.Close()
            End With
        End If
    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Try
            Dim topColor As Color = Color.FromArgb(0, 172, 251) ' Warna atas yang tebal
            Dim bottomColor As Color = Color.FromArgb(0, 0, 255, 255) ' Warna bawah yang pudar

            Dim gradientRect As New Rectangle(0, 0, Panel1.Width, Panel1.Height)

            Using brush As New Drawing2D.LinearGradientBrush(gradientRect, topColor, bottomColor, Drawing2D.LinearGradientMode.Vertical)
                e.Graphics.FillRectangle(brush, gradientRect)
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnCariEB_Click(sender As Object, e As EventArgs) Handles btnCariEB.Click
        Call loadData()
    End Sub
    Private Sub HeaderFg()
        Dim txt As CellRange

        With fg
            .Rows.Fixed = 1
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Cols.Count = 23

            .AutoGenerateColumns = True
            .Rows(0).AllowMerging = True
            .Styles.Normal.WordWrap = True

            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular)
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .AllowMerging = AllowMergingEnum.FixedOnly

            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

            .Rows(0).TextAlign = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).TextAlign = TextAlignEnum.LeftCenter : .Cols(0).AllowEditing = False
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Status" : .Cols(1).TextAlign = TextAlignEnum.LeftCenter : .Cols(1).AllowEditing = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Pancang" : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).AllowEditing = False
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Judul" : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).AllowEditing = False
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Deskripsi" : .Cols(4).TextAlign = TextAlignEnum.LeftCenter : .Cols(4).AllowEditing = False
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Jenis WO" : .Cols(5).TextAlign = TextAlignEnum.LeftCenter : .Cols(5).AllowEditing = False
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Di Ajukan Oleh" : .Cols(6).TextAlign = TextAlignEnum.LeftCenter : .Cols(6).AllowEditing = False
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Tanggal Pengajuan" : .Cols(7).TextAlign = TextAlignEnum.LeftCenter : .Cols(7).AllowEditing = False
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Prioritas" : .Cols(8).TextAlign = TextAlignEnum.LeftCenter : .Cols(8).AllowEditing = False
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Proyek" : .Cols(9).TextAlign = TextAlignEnum.LeftCenter : .Cols(9).AllowEditing = False
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "Kontraktor" : .Cols(10).TextAlign = TextAlignEnum.LeftCenter : .Cols(10).AllowEditing = False
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "Sub Kontraktor" : .Cols(11).TextAlign = TextAlignEnum.LeftCenter : .Cols(11).AllowEditing = False
            txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "Harga Proyek" : .Cols(12).TextAlign = TextAlignEnum.LeftCenter : .Cols(12).AllowEditing = False
            txt = .GetCellRange(0, 13, 0, 13) : txt.Data = "File Penawaran Harga" : .Cols(13).Visible = False
            txt = .GetCellRange(0, 14, 0, 14) : txt.Data = "File SPK" : .Cols(14).Visible = False
            txt = .GetCellRange(0, 15, 0, 15) : txt.Data = "File Proposal" : .Cols(15).Visible = False
            txt = .GetCellRange(0, 16, 0, 16) : txt.Data = "Id" : .Cols(16).Visible = False
            txt = .GetCellRange(0, 17, 0, 17) : txt.Data = "Id Pancang" : .Cols(17).Visible = False
            txt = .GetCellRange(0, 18, 0, 18) : txt.Data = "Total Proyek Sudah Di Bayar" : .Cols(18).Visible = False
            txt = .GetCellRange(0, 19, 0, 19) : txt.Data = "File Desain Proyek" : .Cols(19).Visible = False
            txt = .GetCellRange(0, 20, 0, 20) : txt.Data = "ket" : .Cols(20).Visible = False
            txt = .GetCellRange(0, 21, 0, 21) : txt.Data = "File Pemeriksaan" : .Cols(21).Visible = False
            txt = .GetCellRange(0, 22, 0, 22) : txt.Data = "File BA" : .Cols(22).Visible = False

            .AutoSizeCols()
        End With
    End Sub
    Public Sub loadData()
        Dim i As Integer = 1
        Dim dt As DataTable = New DataTable
        Dim query As String = ""

        Call HeaderFg()

        Try
            Select Case openFormBy
                Case "EstimasiBiaya"
                    If rdAllEB.Checked = True Then
                        query = " select 'Perlu Approval 1 Ulang (Reject 2)' as proses,* from vw_woPancang where IDPancang like '%" & cmbPancangEB.SelectedValue & "%' and flag = 4
                                    union
                                    select 'Belum Di Approval 1' as proses,* from vw_woPancang where IDPancang like '%" & cmbPancangEB.SelectedValue & "%' and flag = 0
                                    union
                                    select 'Sudah Di Approval 1' as proses,* from vw_woPancang where IDPancang like '%" & cmbPancangEB.SelectedValue & "%' and flag=1
                                    union
                                    select 'Di Reject' as proses,* from vw_woPancang where IDPancang like '%" & cmbPancangEB.SelectedValue & "%' and flag=3 "
                    ElseIf rdBelumApproval.Checked = True Then
                        query = " select 'Belum Di Approval 1' as proses,* from vw_woPancang where IDPancang like '%" & cmbPancangEB.SelectedValue & "%' and flag=0 "
                    ElseIf rdSudahApproval.Checked = True Then
                        query = " select 'Sudah Di Approval 1' as proses,* from vw_woPancang where IDPancang like '%" & cmbPancangEB.SelectedValue & "%' and flag=1 "
                    ElseIf rdReject.Checked = True Then
                        query = " select 'Di Reject' as proses,* from vw_woPancang where IDPancang like '%" & cmbPancangEB.SelectedValue & "%' and flag=3 "
                    End If

                    If chkTglEB.Checked = True Then
                        query &= " and (cast(created_date_approval as date) between cast('" & Format(dtpEB1.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(dtpEB2.Value, "yyyy-MM-dd") & "' as date)) "
                    End If
                Case "Proyek"
                    If rdAllP.Checked Then
                        query = " select 'Belum Di Input Semua' as proses,* from vw_woPancang where IDPancang like '%" & cmbPancangP.SelectedValue & "%' and flag=2 and file_spk is null and id not in 
                                (select a.id from vw_woPancang as a 
                                where a.IDPancang like '%" & cmbPancangP.SelectedValue & "%' and a.flag=2 and a.file_spk is null and (select top 1 persen from tbl_wo_trn_barang where wo_id=a.id and persen=1 and deleted=0) is not null and
                                (file_penawaran_harga is not null or proyek_mandiri=1) and file_design_proyek is not null)
                                union
                                select 'Sudah Di Input Semua' as proses,a.* from vw_woPancang as a 
                                where a.IDPancang like '%" & cmbPancangP.SelectedValue & "%' and a.flag=2 and a.file_spk is null and (select top 1 persen from tbl_wo_trn_barang where wo_id=a.id and persen=1 and deleted=0) is not null and
                                (file_penawaran_harga is not null or proyek_mandiri=1) and file_design_proyek is not null "
                    ElseIf rdBelumInputPenawaranHarga.Checked Then
                        query = " select 'Belum Di Input Semua' as proses,* from vw_woPancang where IDPancang like '%" & cmbPancangP.SelectedValue & "%' and flag=2 and file_spk is null and id not in 
                                (select a.id from vw_woPancang as a 
                                where a.IDPancang like '%" & cmbPancangP.SelectedValue & "%' and a.flag=2 and a.file_spk is null and (select top 1 persen from tbl_wo_trn_barang where wo_id=a.id and persen=1 and deleted=0) is not null and
                                (file_penawaran_harga is not null or proyek_mandiri=1) and file_design_proyek is not null) "
                    ElseIf rdSudahInputPenawaranHarga.Checked Then
                        query = " select 'Sudah Di Input Semua' as proses,a.* from vw_woPancang as a 
                                where a.IDPancang like '%" & cmbPancangP.SelectedValue & "%' and a.flag=2 and a.file_spk is null and (select top 1 persen from tbl_wo_trn_barang where wo_id=a.id and persen=1 and deleted=0) is not null and
                                (file_penawaran_harga is not null or proyek_mandiri=1) and file_design_proyek is not null "
                    End If

                    If chkTglP.Checked = True Then
                        query &= " and (cast(created_date as date) between cast('" & Format(dtpP1.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(dtpP2.Value, "yyyy-MM-dd") & "' as date)) "
                    End If
                Case "Spk"
                    If rdAllSpk.Checked = True Then
                        query = " select 'Belum Input SPK' as proses,a.* from vw_woPancang as a where a.IDPancang like '%" & cmbPancangSpk.SelectedValue & "%' and a.file_spk is null and a.flag=2 and (select top 1 persen from tbl_wo_trn_barang where wo_id=a.id and persen=1 and deleted=0) is not null and
                                (a.file_penawaran_harga is not null or a.proyek_mandiri=1) and a.file_design_proyek is not null
                                    union
                                    select 'Sudah Input SPK' as proses,a.* from vw_woPancang as a where a.IDPancang like '%" & cmbPancangSpk.SelectedValue & "%'  and (a.proyek_mandiri=1 or a.file_penawaran_harga is not null) and a.file_spk is not null and id not in (select wo_id from tbl_wo_trn_barang where wo_id=a.id and deleted=0 and persen_request_akum=100) "
                    ElseIf rdBelumInputSpk.Checked = True Then
                        query = " select 'Belum Input SPK' as proses,a.* from vw_woPancang as a where a.IDPancang like '%" & cmbPancangSpk.SelectedValue & "%' and a.file_spk is null and a.flag=2 and (select top 1 persen from tbl_wo_trn_barang where wo_id=a.id and persen=1 and deleted=0) is not null and
                                (a.file_penawaran_harga is not null or a.proyek_mandiri=1) and a.file_design_proyek is not null"
                    ElseIf rdSudahinputSpk.Checked = True Then
                        query = " select 'Sudah Input SPK' as proses,a.* from vw_woPancang as a where a.IDPancang like '%" & cmbPancangSpk.SelectedValue & "%'  and (a.proyek_mandiri=1 or a.file_penawaran_harga is not null) and a.file_spk is not null and id not in (select wo_id from tbl_wo_trn_barang where wo_id=a.id and deleted=0 and persen_request_akum=100) "
                    End If

                    If chkTglEB.Checked = True Then
                        query &= " and (cast(created_date_approval as date) between cast('" & Format(dtpSpk1.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(dtpSpk2.Value, "yyyy-MM-dd") & "' as date)) "
                    End If
                Case "Pembayaran"
                    If rdAllBayar.Checked = True Then
                        query = " select 'Belum Lunas' as proses,a.* from vw_woPancang as a where a.IDPancang like '%" & cmbPancangInpection.SelectedValue & "%' and a.file_spk is not null and a.id not in (select top 1 wo_id from tbl_wo_trn_bayar where deleted=0 and flag=3 and wo_id=a.id)
                                    union
                                    select 'Sudah Lunas' as proses,a.* from vw_woPancang as a where a.IDPancang like '%" & cmbPancangInpection.SelectedValue & "%' and a.file_spk is not null and a.id in (select top 1 wo_id from tbl_wo_trn_bayar where deleted=0 and flag=3 and wo_id=a.id) and a.flag<>5 "
                    ElseIf rdBelumLunas.Checked = True Then
                        query = " select 'Belum Lunas' as proses,a.* from vw_woPancang as a where a.IDPancang like '%" & cmbPancangInpection.SelectedValue & "%' and a.file_spk is not null and a.id not in (select top 1 wo_id from tbl_wo_trn_bayar where deleted=0 and flag=3 and wo_id=a.id) "
                    ElseIf rdSudahLunas.Checked = True Then
                        query = " select 'Sudah Lunas' as proses,a.* from vw_woPancang as a where a.IDPancang like '%" & cmbPancangInpection.SelectedValue & "%' and a.file_spk is not null and a.id in (select top 1 wo_id from tbl_wo_trn_bayar where deleted=0 and flag=3 and wo_id=a.id) and a.flag<>5 "
                    End If

                    If chkTglBayar.Checked = True Then
                        query &= " and (cast(created_date as date) between cast('" & Format(dtp1Bayar.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(dtp2Bayar.Value, "yyyy-MM-dd") & "' as date)) "
                    End If
                Case = "BA"
                    If rdAllBA.Checked = True Then
                        query = " select 'Belum Upload BA' as proses,a.* from vw_woPancang as a where a.IDPancang like '%" & cmbPancangInpection.SelectedValue & "%' and (file_pemeriksaan is not null or (a.id in (select wo_id from tbl_wo_trn_pemeriksaan where wo_id=a.id and deleted=0))) and a.file_ba is null  
                                    union
                                    select 'Sudah Upload BA' as proses,* from vw_woPancang where IDPancang like '%" & cmbPancangSpk.SelectedValue & "%' and file_ba is not null and flag <> 5 "
                    ElseIf rdBelumUploadBA.Checked = True Then
                        query = " select 'Belum Upload BA' as proses,a.* from vw_woPancang as a where a.IDPancang like '%" & cmbPancangInpection.SelectedValue & "%' and (file_pemeriksaan is not null or (a.id in (select wo_id from tbl_wo_trn_pemeriksaan where wo_id=a.id and deleted=0))) and a.file_ba is null "
                    ElseIf rdSudahUploadBA.Checked = True Then
                        query = " select 'Sudah Upload BA' as proses,* from vw_woPancang where IDPancang like '%" & cmbPancangSpk.SelectedValue & "%' and file_ba is not null and flag <> 5 "
                    End If

                    If chkTglBA.Checked = True Then
                        query &= " and (cast(created_date as date) between cast('" & Format(dtpBA1.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(dtpBA2.Value, "yyyy-MM-dd") & "' as date)) "
                    End If
                Case = "Inspection"
                    If rdAllinspection.Checked = True Then
                        query = " select 'Belum Upload Inspection' as proses,a.* from vw_woPancang as a where a.IDPancang like '%" & cmbPancangInpection.SelectedValue & "%' and a.close_pengerjaan=1 and a.file_pemeriksaan is null and a.id not in (select wo_id from tbl_wo_trn_pemeriksaan where wo_id=a.id and deleted=0)
                                    union
                                    select 'Sudah Upload Inspection' as proses,a.* from vw_woPancang as a where a.IDPancang like '%" & cmbPancangInpection.SelectedValue & "%' and file_pemeriksaan is not null and a.file_ba is null "
                    ElseIf rdBelumUploadinspection.Checked = True Then
                        query = " select 'Belum Upload Inspection' as proses,a.* from vw_woPancang as a where a.IDPancang like '%" & cmbPancangInpection.SelectedValue & "%' and a.close_pengerjaan=1 and a.file_pemeriksaan is null and a.id not in (select wo_id from tbl_wo_trn_pemeriksaan where wo_id=a.id and deleted=0) "
                    ElseIf rdSudahUploadinspection.Checked = True Then
                        query = " select 'Sudah Upload Inspection' as proses,a.* from vw_woPancang as a where a.IDPancang like '%" & cmbPancangInpection.SelectedValue & "%' and file_pemeriksaan is not null  and a.file_ba is null "
                    End If

                    If chkTglinspection.Checked = True Then
                        query &= " and (cast(created_date as date) between cast('" & Format(dtpInspection1.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(dtpInspection2.Value, "yyyy-MM-dd") & "' as date)) "
                    End If
                Case = "BarangRequest"
                    If rdAllBarangRequest.Checked = True Then
                        query = "   select 'Sudah Selesai Request' as proses,a.* from vw_woPancang as a where a.IDPancang like '%" & cmbPancangBarangReq.SelectedValue & "%' and id not in (select wo_id from tbl_wo_trn_barang where wo_id=a.id and deleted=0 and persen_kirim_akum=100)
                                    union
                                    select 'Sudah Selesai Request' as proses,a.* from vw_woPancang as a where a.IDPancang like '%" & cmbPancangBarangReq.SelectedValue & "%' and id in (select wo_id from tbl_wo_trn_barang where wo_id=a.id and deleted=0 and persen_request_akum=100) and id not in (select wo_id from tbl_wo_trn_barang where wo_id=a.id and deleted=0 and persen_kirim_akum=100)"
                    ElseIf rdBelumSelesaiRequest.Checked = True Then
                        query = " select 'Sudah Selesai Request' as proses,a.* from vw_woPancang as a where a.IDPancang like '%" & cmbPancangBarangReq.SelectedValue & "%' and id not in (select wo_id from tbl_wo_trn_barang where wo_id=a.id and deleted=0 and persen_kirim_akum=100) "
                    ElseIf rdSudahSelesaiRequest.Checked = True Then
                        query = " select 'Sudah Selesai Request' as proses,a.* from vw_woPancang as a where a.IDPancang like '%" & cmbPancangBarangReq.SelectedValue & "%' and id in (select wo_id from tbl_wo_trn_barang where wo_id=a.id and deleted=0 and persen_request_akum=100) and id not in (select wo_id from tbl_wo_trn_barang where wo_id=a.id and deleted=0 and persen_kirim_akum=100) "
                    End If

                    If chkTglBarangRequest.Checked = True Then
                        query &= " and (cast(created_date as date) between cast('" & Format(dtpBarangReq1.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(dtpBarangReq2.Value, "yyyy-MM-dd") & "' as date)) "
                    End If
            End Select

            If query <> "" Then
                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, query)

                fg.Rows.Count = 1
                If dt.Rows.Count > 0 Then
                    With fg
                        For Each row As DataRow In dt.Rows
                            .AddItem(i)
                            .Item(i, 1) = row("proses")
                            .Item(i, 2) = row("Pancang")
                            .Item(i, 3) = row("judul")
                            .Item(i, 4) = row("deskripsi")
                            .Item(i, 5) = row("jenis_wo")
                            .Item(i, 6) = row("namalengkap")
                            .Item(i, 7) = row("created_date")
                            .Item(i, 8) = row("prioritas")
                            .Item(i, 9) = row("proyek_mandiri")
                            .Item(i, 10) = row("nama_kontraktor")
                            .Item(i, 11) = row("nama_kontraktor_sub")
                            .Item(i, 12) = row("harga_proyek")
                            .Item(i, 13) = row("file_penawaran_harga")
                            .Item(i, 14) = row("file_spk")
                            .Item(i, 15) = row("file_proposal")
                            .Item(i, 16) = row("id")
                            .Item(i, 17) = row("idpancang")
                            .Item(i, 18) = row("sudahDiBayar")
                            .Item(i, 19) = row("file_design_proyek")
                            .Item(i, 20) = row("ket")
                            .Item(i, 21) = row("file_pemeriksaan")
                            .Item(i, 22) = row("file_ba")
                            i += 1
                        Next
                        .AutoSizeCols()
                    End With
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCariP_Click(sender As Object, e As EventArgs) Handles btnCariP.Click
        Call loadData()
    End Sub

    Private Sub btnCariSpk_Click(sender As Object, e As EventArgs) Handles btnCariSpk.Click
        Call loadData()
    End Sub

    Private Sub TabControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl.SelectedIndexChanged
        If openFormBy = "EstimasiBiaya" Then
            TabControl.SelectedTab = TabPage1
        ElseIf openFormBy = "Proyek" Then
            TabControl.SelectedTab = TabPage2
        ElseIf openFormBy = "Spk" Then
            TabControl.SelectedTab = TabPage3
        ElseIf openFormBy = "Pembayaran" Then
            TabControl.SelectedTab = TabPage4
        ElseIf openFormBy = "BA" Then
            TabControl.SelectedTab = TabPage5
        ElseIf openFormBy = "Inspection" Then
            TabControl.SelectedTab = TabPage6
        ElseIf openFormBy = "BarangRequest" Then
            TabControl.SelectedTab = TabPage7
        End If
    End Sub

    Private Sub rdAllEB_CheckedChanged(sender As Object, e As EventArgs) Handles rdAllEB.CheckedChanged
        Call loadData()
    End Sub

    Private Sub rdBelumApproval_CheckedChanged(sender As Object, e As EventArgs) Handles rdBelumApproval.CheckedChanged
        Call loadData()
    End Sub

    Private Sub rdSudahApproval_CheckedChanged(sender As Object, e As EventArgs) Handles rdSudahApproval.CheckedChanged
        Call loadData()
    End Sub

    Private Sub rdReject_CheckedChanged(sender As Object, e As EventArgs) Handles rdReject.CheckedChanged, rdApprovUlang.CheckedChanged
        Call loadData()
    End Sub

    Private Sub rdAllP_CheckedChanged(sender As Object, e As EventArgs) Handles rdAllP.CheckedChanged
        Call loadData()
    End Sub

    Private Sub rdBelumInputPenawaranHarga_CheckedChanged(sender As Object, e As EventArgs) Handles rdBelumInputPenawaranHarga.CheckedChanged
        Call loadData()
    End Sub

    Private Sub rdSudahInputPenawaranHarga_CheckedChanged(sender As Object, e As EventArgs) Handles rdSudahInputPenawaranHarga.CheckedChanged
        Call loadData()
    End Sub

    Private Sub rdAllSpk_CheckedChanged(sender As Object, e As EventArgs) Handles rdAllSpk.CheckedChanged
        Call loadData()
    End Sub

    Private Sub rdBelumInputSpk_CheckedChanged(sender As Object, e As EventArgs) Handles rdBelumInputSpk.CheckedChanged
        Call loadData()
    End Sub

    Private Sub rdSudahinputSpk_CheckedChanged(sender As Object, e As EventArgs) Handles rdSudahinputSpk.CheckedChanged
        Call loadData()
    End Sub

    Private Sub rdAllBayar_CheckedChanged(sender As Object, e As EventArgs) Handles rdAllBayar.CheckedChanged
        Call loadData()
    End Sub

    Private Sub rdBelumLunas_CheckedChanged(sender As Object, e As EventArgs) Handles rdBelumLunas.CheckedChanged
        Call loadData()
    End Sub

    Private Sub rdSudahLunas_CheckedChanged(sender As Object, e As EventArgs) Handles rdSudahLunas.CheckedChanged
        Call loadData()
    End Sub

    Private Sub rdAllBA_CheckedChanged(sender As Object, e As EventArgs) Handles rdAllBA.CheckedChanged
        Call loadData()
    End Sub

    Private Sub rdBelumUploadBA_CheckedChanged(sender As Object, e As EventArgs) Handles rdBelumUploadBA.CheckedChanged
        Call loadData()
    End Sub

    Private Sub rdSudahUploadBA_CheckedChanged(sender As Object, e As EventArgs) Handles rdSudahUploadBA.CheckedChanged
        Call loadData()
    End Sub

    Private Sub rdAllinspection_CheckedChanged(sender As Object, e As EventArgs) Handles rdAllinspection.CheckedChanged
        Call loadData()
    End Sub

    Private Sub rdBelumUploadinspection_CheckedChanged(sender As Object, e As EventArgs) Handles rdBelumUploadinspection.CheckedChanged
        Call loadData()
    End Sub

    Private Sub rdSudahUploadinspection_CheckedChanged(sender As Object, e As EventArgs) Handles rdSudahUploadinspection.CheckedChanged
        Call loadData()
    End Sub

    Private Sub btnCariBayar_Click(sender As Object, e As EventArgs) Handles btnCariBayar.Click
        Call loadData()
    End Sub

    Private Sub btnCariBA_Click(sender As Object, e As EventArgs) Handles btnCariBA.Click
        Call loadData()
    End Sub

    Private Sub btnCariInspection_Click(sender As Object, e As EventArgs) Handles btnCariInspection.Click
        Call loadData()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call loadData()
    End Sub

    Private Sub rdAllBarangRequest_CheckedChanged(sender As Object, e As EventArgs) Handles rdAllBarangRequest.CheckedChanged
        Call loadData()
    End Sub

    Private Sub rdBelumSelesaiRequest_CheckedChanged(sender As Object, e As EventArgs) Handles rdBelumSelesaiRequest.CheckedChanged
        Call loadData()
    End Sub

    Private Sub rdSudahSelesaiRequest_CheckedChanged(sender As Object, e As EventArgs) Handles rdSudahSelesaiRequest.CheckedChanged
        Call loadData()
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click

    End Sub
End Class