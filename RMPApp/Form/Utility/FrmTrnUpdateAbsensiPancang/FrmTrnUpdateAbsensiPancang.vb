Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Public Class FrmTrnUpdateAbsensiPancang
    Dim Bergerak As Integer
    Dim Teks As String
    Dim IdAbsensi As String
    Dim TidakHitungUangMakan As Integer
    Dim tidakHitungLembur As Integer

    Private Sub FrmMonAbsensiPancang_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Modul_RMP.ClsComboBox.SetPancang(cboPancang)
        Modul_RMP.ClsComboBox.SetJabatan(cboJabatan)
        Modul_RMP.ClsComboBox.SetStatus(cboStatus)
        Modul_RMP.ClsComboBox.SetBagian(cboBagian)
        Modul_RMP.ClsComboBox.SetKehadiran(CmbKehadiran)
        Modul_RMP.ClsComboBox.SetPersonilPancang(CmbIdPersonil)

        dtpTanggal.Value = Format(Now, "yyyy-MM-dd")
        dtpTanggal2.Value = Format(Now, "yyyy-MM-dd")
        fg.Rows.Count = 1

        cboPancang.Enabled = False
        cboJabatan.Enabled = False
        cboStatus.Enabled = False
        CmbIdPersonil.Enabled = False
        cboBagian.Enabled = False
        dtpTanggal.Enabled = False
        dtpTanggal2.Enabled = False
        dtpPeriode.Enabled = False

        Teks = lblInfo.Text
        Timer.Start()

        Call Search()
        Call HeaderFG()
        Call ClearData()
    End Sub

    Sub ClearData()
        TxtNama.Clear()
        TxtNik.Clear()
        TxtStatus.Clear()
        TxtLiburMingguan.Clear()
        TxtJabatan.Clear()
        TxtBagian.Clear()
        TxtPancang.Clear()
        TxtTanggalAbsen.Clear()
        CmbKehadiran.Text = ""
        TxtKeterangan.Clear()
        ChkTidakHitungUangMakan.Checked = False
        ChkTidakHitungLembur.Checked = False
        '----------------------------
        TxtKeterangan.Enabled = False
        TxtNama.Enabled = False
        TxtNik.Enabled = False
        TxtStatus.Enabled = False
        TxtLiburMingguan.Enabled = False
        TxtJabatan.Enabled = False
        TxtBagian.Enabled = False
        TxtPancang.Enabled = False
        TxtTanggalAbsen.Enabled = False
        CmbKehadiran.Enabled = False
        chkTanggal.Checked = True
        ChkTidakHitungLembur.Enabled = False
        ChkTidakHitungUangMakan.Enabled = False


        BtnEdit.Enabled = False
        BtnSave.Enabled = False
        btnCancel.Enabled = False
    End Sub

    Private Sub Search()
        With scp
            .SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
            .SearchDelay = 2
            .Watermark = "Cari Disini"
            .SetC1FlexGridSearchPanel(fg, scp)
        End With
    End Sub

    Public Sub HeaderFG()
        Dim txt As CellRange
        With fg
            .AllowEditing = True
            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular)
            .Cols.Count = 26
            .Cols.Fixed = 1
            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 1
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "N0" : .Cols(0).Width = 50
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Tanggal" : .Cols(1).TextAlign = TextAlignEnum.CenterCenter : .Cols(1).AllowEditing = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "ID Personil" : .Cols(2).TextAlign = TextAlignEnum.CenterCenter : .Cols(2).AllowEditing = False
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Bagian" : .Cols(3).TextAlign = TextAlignEnum.CenterCenter : .Cols(3).AllowEditing = False
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Nama" : .Cols(4).TextAlign = TextAlignEnum.LeftCenter : .Cols(4).AllowEditing = False
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "NIK" : .Cols(5).TextAlign = TextAlignEnum.CenterCenter : .Cols(5).AllowEditing = False
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Pancang" : .Cols(6).TextAlign = TextAlignEnum.LeftCenter : .Cols(6).AllowEditing = False
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Jabatan" : .Cols(7).TextAlign = TextAlignEnum.CenterCenter : .Cols(7).AllowEditing = False
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Status" : .Cols(8).TextAlign = TextAlignEnum.CenterCenter : .Cols(8).AllowEditing = False
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Libur Mingguan" : .Cols(9).TextAlign = TextAlignEnum.CenterCenter : .Cols(9).AllowEditing = False
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "Kehadiran" : .Cols(10).TextAlign = TextAlignEnum.CenterCenter : .Cols(10).AllowEditing = False
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "Keterangan" : .Cols(11).TextAlign = TextAlignEnum.CenterCenter : .Cols(11).AllowEditing = False
            txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "Jam Masuk" : .Cols(12).TextAlign = TextAlignEnum.CenterCenter : .Cols(12).AllowEditing = False
            txt = .GetCellRange(0, 13, 0, 13) : txt.Data = "Foto Name Masuk" : .Cols(13).TextAlign = TextAlignEnum.CenterCenter : .Cols(13).AllowEditing = False : .Cols(13).Visible = False
            txt = .GetCellRange(0, 14, 0, 14) : txt.Data = "Foto Masuk" : .Cols(14).TextAlign = TextAlignEnum.CenterCenter : .Cols(14).AllowEditing = False : .Cols(14).Visible = False
            txt = .GetCellRange(0, 15, 0, 15) : txt.Data = "Jam Pulang" : .Cols(15).TextAlign = TextAlignEnum.CenterCenter : .Cols(15).AllowEditing = False
            txt = .GetCellRange(0, 16, 0, 16) : txt.Data = "Foto Name Pulang" : .Cols(16).TextAlign = TextAlignEnum.CenterCenter : .Cols(16).AllowEditing = False : .Cols(16).Visible = False
            txt = .GetCellRange(0, 17, 0, 17) : txt.Data = "Foto Pulang" : .Cols(17).TextAlign = TextAlignEnum.CenterCenter : .Cols(17).AllowEditing = False : .Cols(17).Visible = False
            txt = .GetCellRange(0, 18, 0, 18) : txt.Data = "ID" : .Cols(18).TextAlign = TextAlignEnum.CenterCenter : .Cols(18).AllowEditing = False : .Cols(18).Visible = False
            txt = .GetCellRange(0, 19, 0, 19) : txt.Data = "UpdatedBy" : .Cols(19).TextAlign = TextAlignEnum.CenterCenter : .Cols(19).AllowEditing = False
            txt = .GetCellRange(0, 20, 0, 20) : txt.Data = "UpdatedDate" : .Cols(20).TextAlign = TextAlignEnum.CenterCenter : .Cols(20).AllowEditing = False
            txt = .GetCellRange(0, 21, 0, 21) : txt.Data = "Keterangan Updated" : .Cols(21).TextAlign = TextAlignEnum.CenterCenter : .Cols(21).AllowEditing = False
            txt = .GetCellRange(0, 22, 0, 22) : txt.Data = "UpdatedKetBy" : .Cols(22).TextAlign = TextAlignEnum.CenterCenter : .Cols(22).AllowEditing = False
            txt = .GetCellRange(0, 23, 0, 23) : txt.Data = "UpdatedKetDate" : .Cols(23).TextAlign = TextAlignEnum.CenterCenter : .Cols(23).AllowEditing = False
            txt = .GetCellRange(0, 24, 0, 24) : txt.Data = "Tidak Hitung Uang Makan" : .Cols(24).TextAlign = TextAlignEnum.CenterCenter : .Cols(24).AllowEditing = False
            txt = .GetCellRange(0, 25, 0, 25) : txt.Data = "Tidak Hitung Lembur" : .Cols(25).TextAlign = TextAlignEnum.CenterCenter : .Cols(25).AllowEditing = False
        End With
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        ShowData()
    End Sub

    Private Sub ShowData()
        Me.Cursor = Cursors.WaitCursor
        Dim i As Integer = 1
        Dim sql As String = ""
        Dim dt As DataTable = New DataTable()

        Try
            If chkTanggal.Checked = True Then
                sql = Modul_RMP.Cls_Function.SetCondition(sql, " CONVERT(DATETIME,CONVERT(VARCHAR, Tanggal,103),103) BETWEEN CONVERT (DATETIME,'" & dtpTanggal.Value & "',103) AND CONVERT(DATETIME,'" & dtpTanggal2.Value & "',103)")
            End If

            If chkPancang.Checked = True Then
                sql = Modul_RMP.Cls_Function.SetCondition(sql, "IDPancang = '" & cboPancang.SelectedValue & "'")
            End If

            If chkJabatan.Checked = True Then
                sql = Modul_RMP.Cls_Function.SetCondition(sql, "Jabatan = '" & cboJabatan.Text & "'")
            End If

            If chkStatus.Checked = True Then
                sql = Modul_RMP.Cls_Function.SetCondition(sql, "Status = '" & cboStatus.Text & "'")
            End If

            If chkBagian.Checked = True Then
                sql = Modul_RMP.Cls_Function.SetCondition(sql, "Bagian = '" & cboBagian.Text & "'")
            End If

            If ChkIdPersonil.Checked = True Then
                sql = Modul_RMP.Cls_Function.SetCondition(sql, "IDPersonil= '" & CmbIdPersonil.Text & "'")
            End If

            dt = Modul_RMP.Cls_Connection.SqlSelect_VBDSERVER("SELECT * FROM RMPApp..vwAndroidAbsensiPCG__ WHERE IDPersonil IS NOT NULL " & IIf(sql = "", "", " AND " & sql) & " ORDER BY JamMasuk DESC")



            If dt.Rows.Count > 0 Then
                With fg
                    Call Modul_RMP.Cls_Model.HapusGrid(1, fg)
                    For Each row As DataRow In dt.Rows
                        .AddItem(i)
                        .Item(i, 1) = Format(row.Item("Tanggal"), "dd/MM/yyyy")
                        .Item(i, 2) = row.Item("IDPersonil")
                        .Item(i, 3) = row.Item("Bagian")
                        .Item(i, 4) = row.Item("Nama")
                        .Item(i, 5) = row.Item("NIK")
                        .Item(i, 6) = row.Item("Pancang")
                        .Item(i, 7) = row.Item("Jabatan")
                        .Item(i, 8) = row.Item("Status")
                        .Item(i, 9) = row.Item("IM")
                        .Item(i, 10) = row.Item("Kehadiran")
                        .Item(i, 11) = row.Item("KetAbsen")
                        .Item(i, 12) = Format(row.Item("JamMasuk"), "HH:mm")
                        .Item(i, 13) = row.Item("FotoMasuk")
                        .Item(i, 14) = "..."
                        .Item(i, 15) = row.Item("JamPulang")
                        .Item(i, 16) = row.Item("FotoPulang")
                        .Item(i, 17) = "..."
                        .Item(i, 18) = row.Item("ID")
                        .Item(i, 19) = IIf(IsDBNull(row.Item("UpdatedBy")), "-", row.Item("UpdatedBy"))
                        .Item(i, 20) = IIf(IsDBNull(row.Item("UpdatedDate")), "-", row.Item("UpdatedDate"))
                        .Item(i, 21) = IIf(IsDBNull(row.Item("Keterangan")), "", row.Item("Keterangan"))
                        .Item(i, 22) = IIf(IsDBNull(row.Item("UpdateKetBy")), "-", row.Item("UpdateKetBy"))
                        .Item(i, 23) = IIf(IsDBNull(row.Item("UpdateKetDate")), "-", row.Item("UpdateKetDate"))
                        .Item(i, 24) = row.Item("TidakHitungUangMakan")
                        .Item(i, 25) = row.Item("TidakHitungLembur")
                        i = i + 1
                    Next
                    .AutoSizeCols()
                End With
            Else
                MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
            End If
        Catch EX As Exception
            MsgBox(EX.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cboPancang_KeyUp(sender As Object, e As KeyEventArgs) Handles cboPancang.KeyUp
        Modul_RMP.Cls_Model.AutoCompleteCombo_KeyUp(cboPancang, e)
    End Sub

    Private Sub cboJabatan_KeyUp(sender As Object, e As KeyEventArgs) Handles cboJabatan.KeyUp
        Modul_RMP.Cls_Model.AutoCompleteCombo_KeyUp(cboJabatan, e)
    End Sub

    Private Sub cboStatus_KeyUp(sender As Object, e As KeyEventArgs) Handles cboStatus.KeyUp
        Modul_RMP.Cls_Model.AutoCompleteCombo_KeyUp(cboStatus, e)
    End Sub

    Private Sub cboBagian_KeyUp(sender As Object, e As KeyEventArgs) Handles cboBagian.KeyUp
        Modul_RMP.Cls_Model.AutoCompleteCombo_KeyUp(cboBagian, e)
    End Sub

    Private Sub chkPancang_CheckedChanged(sender As Object, e As EventArgs) Handles chkPancang.CheckedChanged
        If chkPancang.Checked = True Then
            cboPancang.Enabled = True
        Else
            cboPancang.Enabled = False
            cboPancang.Text = ""
        End If
    End Sub

    Private Sub chkJabatan_CheckedChanged(sender As Object, e As EventArgs) Handles chkJabatan.CheckedChanged
        If chkJabatan.Checked = True Then
            cboJabatan.Enabled = True
        Else
            cboJabatan.Enabled = False
            cboJabatan.Text = ""
        End If
    End Sub

    Private Sub chkStatus_CheckedChanged(sender As Object, e As EventArgs) Handles chkStatus.CheckedChanged
        If chkStatus.Checked = True Then
            cboStatus.Enabled = True
        Else
            cboStatus.Enabled = False
            cboStatus.Text = ""
        End If
    End Sub

    Private Sub chkBagian_CheckedChanged(sender As Object, e As EventArgs) Handles chkBagian.CheckedChanged
        If chkBagian.Checked = True Then
            cboBagian.Enabled = True
        Else
            cboBagian.Enabled = False
            cboBagian.Text = ""
        End If
    End Sub

    Private Sub chkPeriode_CheckedChanged(sender As Object, e As EventArgs) Handles chkPeriode.CheckedChanged
        If chkPeriode.Checked = True Then
            dtpPeriode.Enabled = True
        Else
            dtpPeriode.Enabled = False
            dtpPeriode.Value = Format(Now, "yyyy-MM-dd")
        End If
    End Sub

    Private Sub chkTanggal_CheckedChanged(sender As Object, e As EventArgs) Handles chkTanggal.CheckedChanged
        If chkTanggal.Checked = True Then
            dtpTanggal.Enabled = True
            dtpTanggal2.Enabled = True
        Else
            dtpTanggal.Enabled = False
            dtpTanggal2.Enabled = False
            dtpTanggal.Value = Format(Now, "yyyy-MM-dd")
            dtpTanggal2.Value = Format(Now, "yyyy-MM-dd")
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ClearData()
        dtpTanggal.Value = Format(Now, "yyyy-MM-dd")
        dtpTanggal2.Value = Format(Now, "yyyy-MM-dd")
        chkPancang.Checked = False
        chkJabatan.Checked = False
        chkStatus.Checked = False
        chkBagian.Checked = False
        fg.Rows.Count = 1
    End Sub
    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click
        If fg.Rows.Count > 1 Then
            With fg
                TxtNama.Text = .Item(.Row, 4)
                TxtNik.Text = .Item(.Row, 5)
                TxtStatus.Text = .Item(.Row, 8)
                CmbKehadiran.Text = .Item(.Row, 10)
                TxtLiburMingguan.Text = .Item(.Row, 9)
                TxtJabatan.Text = .Item(.Row, 7)
                TxtBagian.Text = .Item(.Row, 3)
                TxtPancang.Text = .Item(.Row, 6)
                TxtTanggalAbsen.Text = .Item(.Row, 1)
                IdAbsensi = .Item(.Row, 18)
                TxtKeterangan.Text = .Item(.Row, 21)
                ChkTidakHitungUangMakan.Checked = .Item(.Row, 24)
                ChkTidakHitungLembur.Checked = .Item(.Row, 25)
            End With

            BtnEdit.Enabled = True

        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If CmbKehadiran.Text = "" Then
            Call MsgBox("Kehadiran is Empty !!", vbExclamation, AT)
            Exit Sub
        ElseIf TxtKeterangan.Text = "" Then
            Call MsgBox("Keterangan is Empty !!", vbExclamation, AT)
            Exit Sub
        Else

            If ChkTidakHitungUangMakan.Checked = True Then
                TidakHitungUangMakan = 1
            ElseIf ChkTidakHitungUangMakan.Checked = False Then
                TidakHitungUangMakan = 0
            End If
            If ChkTidakHitungLembur.Checked = True Then
                tidakHitungLembur = 1
            ElseIf ChkTidakHitungLembur.Checked = False Then
                tidakHitungLembur = 0
            End If

            Dim koneksi As SqlConnection = Modul_RMP.Cls_Connection.OpenConnection
            Dim Transaksi As SqlTransaction
            Transaksi = koneksi.BeginTransaction
            Try
                If SaveAbsensiPancang(koneksi, Transaksi) = False Then
                    Transaksi.Rollback()
                    MsgBox("Update Data Gagal", vbCritical, "Save Absensi Pancang")
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                Transaksi.Commit()
                MsgBox("Data Telah Tersimpan", MsgBoxStyle.Information)
                IdAbsensi = ""
                ClearData()
                ShowData()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                koneksi.Close()
                Me.Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Function SaveAbsensiPancang(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        SaveAbsensiPancang = False
        Dim MyCon As SqlConnection = Conn
        Dim MyConTrans As SqlTransaction = Trans
        Dim cmd As New SqlCommand
        With cmd
            .Connection = Conn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RMPApp..spSaveAbsensiPancang"
            .Transaction = MyConTrans

            .Parameters.Add("@Kehadiran", SqlDbType.VarChar, 20).Value = CmbKehadiran.SelectedValue.ToString
            .Parameters.Add("@User", SqlDbType.VarChar, 50).Value = FrmMenuNew.UserName
            .Parameters.Add("@Id", SqlDbType.VarChar, 10).Value = IdAbsensi
            .Parameters.Add("@Keterangan", SqlDbType.Text).Value = TxtKeterangan.Text.ToString
            .Parameters.Add("@TidakHitungUangMakan", SqlDbType.Bit, 1).Value = TidakHitungUangMakan
            .Parameters.Add("@TidakHitungLembur", SqlDbType.Bit, 1).Value = tidakHitungLembur
            .Parameters.Add(New SqlParameter("@Flag", SqlDbType.SmallInt, 3, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .ExecuteNonQuery()
        End With

        Try
            If CInt(cmd.Parameters("@Flag").Value) = 0 Then
                cmd.Dispose()
                Exit Function
            End If

            cmd.Dispose()
            SaveAbsensiPancang = 1
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function

    Private Sub ChkIdPersonil_CheckedChanged(sender As Object, e As EventArgs) Handles ChkIdPersonil.CheckedChanged, ChkTidakHitungLembur.CheckedChanged, ChkTidakHitungUangMakan.CheckedChanged
        If ChkIdPersonil.Checked = True Then
            CmbIdPersonil.Enabled = True
        Else
            CmbIdPersonil.Enabled = False
            CmbIdPersonil.Text = ""
        End If
    End Sub

    Private Sub CmbIdPersonil_KeyUp(sender As Object, e As KeyEventArgs) Handles CmbIdPersonil.KeyUp
        Modul_RMP.Cls_Model.AutoCompleteCombo_KeyUp(CmbIdPersonil, e)
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        BtnEdit.Enabled = False
        btnCancel.Enabled = True
        BtnSave.Enabled = True

        CmbKehadiran.Enabled = True
        TxtKeterangan.Enabled = True
        ChkTidakHitungLembur.Enabled = True
        ChkTidakHitungUangMakan.Enabled = True
    End Sub

    Private Sub fg_DoubleClick(sender As Object, e As EventArgs) Handles fg.DoubleClick
        If fg.Col = 2 Then
            FrmFotoAbsen.PictureBox.BackgroundImage = Nothing
            FrmFotoAbsen.images = fg.Item(fg.Row, 13)
            FrmFotoAbsen.ShowDialog()
        End If
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        lblInfo.Text = Bergerak
        Teks = Microsoft.VisualBasic.Right(Teks, Len(Teks) - 1) & Microsoft.VisualBasic.Left(Teks, 1)
        lblInfo.Text = Teks
    End Sub
End Class
