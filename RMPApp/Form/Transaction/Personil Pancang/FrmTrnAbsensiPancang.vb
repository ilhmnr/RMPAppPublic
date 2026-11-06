Imports C1.Win
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Public Class FrmTrnAbsensiPancang
    Dim Bergerak As Integer
    Dim Teks As String
    Dim IdAbsensi As String
    Dim TidakHitungUangMakan As Integer
    Dim HitungUangMakan As Integer
    Dim tidakHitungLembur As Integer
    Dim HitungLembur As Integer
    Dim rg As CellRange

    Private Sub FrmMonAbsensiPancang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Modul_RMP.Combo.SetPancang(cboPancang)
        Modul_RMP.Combo.SetJabatan(cboJabatan)
        Modul_RMP.Combo.SetStatus(cboStatus)
        Modul_RMP.Combo.SetBagian(cboBagian)
        Modul_RMP.Combo.SetKehadiran(CmbKehadiran)
        Modul_RMP.Combo.SetPersonilPancang(CmbIdPersonil)

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
        ChkHitungLembur.Enabled = False
        ChkTidakHitungUangMakan.Enabled = False
        ChkHitungUangMakan.Enabled = False

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

            .AutoSizeCols()
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
                sql = Modul_RMP.Func.SetCondition(sql, " CONVERT(DATETIME,CONVERT(VARCHAR, Tanggal,103),103) BETWEEN CONVERT (DATETIME,'" & dtpTanggal.Value & "',103) AND CONVERT(DATETIME,'" & dtpTanggal2.Value & "',103)")
            End If

            If chkPancang.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "IDPancang = '" & cboPancang.SelectedValue & "'")
            End If

            If chkJabatan.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "Jabatan = '" & cboJabatan.Text & "'")
            End If

            If chkStatus.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "Status = '" & cboStatus.Text & "'")
            End If

            If chkBagian.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "Bagian = '" & cboBagian.Text & "'")
            End If

            If ChkIdPersonil.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "IDPersonil= '" & CmbIdPersonil.Text & "'")
            End If

            If ChkAllData.Checked = False Then
                sql = Modul_RMP.Func.SetCondition(sql, "deleted = 0")
            End If

            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT * FROM RMPApp..vwAndroidAbsensiPCG__2024 WHERE IDPersonil IS NOT NULL " & IIf(sql = "", "", " AND " & sql) & " ORDER BY IDPersonil,JamMasuk DESC")

            If dt.Rows.Count > 0 Then
                With fg
                    Call ui.HapusGrid(1, fg)
                    For Each row As DataRow In dt.Rows
                        .AddItem(i)
                        .Item(i, "fgPersonil") = row.Item("IDPersonil") & " : " & row.Item("Nama")
                        .Item(i, "fgIDPersonil") = row.Item("IDPersonil")
                        .Item(i, "fgBagian") = row.Item("Bagian")
                        .Item(i, "fgNama") = row.Item("Nama")
                        .Item(i, "fgNIK") = row.Item("NIK")
                        .Item(i, "fgPancang") = row.Item("Pancang")
                        .Item(i, "fgJabatan") = row.Item("Jabatan")
                        .Item(i, "fgStatus") = row.Item("Status")
                        .Item(i, "fgLiburMingguan") = row.Item("IM")
                        .Item(i, "fgKehadiran") = row.Item("Kehadiran")
                        .Item(i, "fgKeterangan") = row.Item("KetAbsen")
                        .Item(i, "fgTanggal") = row.Item("Tanggal")
                        .Item(i, "fgTanggalUploadServer") = row.Item("ComputerDate")
                        .Item(i, "fgJamMasuk") = row.Item("JamMasuk")
                        .Item(i, "fgFotoNameMasuk") = row.Item("FotoMasuk")
                        .Item(i, "fgFotoMasuk") = "..."
                        .Item(i, "fgJamPulang") = row.Item("JamPulang")
                        .Item(i, "fgFotoNamePulang") = row.Item("FotoPulang")
                        .Item(i, "fgFotoPulang") = "..."
                        .Item(i, "fgID") = row.Item("ID")
                        .Item(i, "fgUpdateBy") = IIf(IsDBNull(row.Item("UpdatedBy")), "-", row.Item("UpdatedBy"))
                        .Item(i, "fgUpdateDate") = IIf(IsDBNull(row.Item("UpdatedDate")), "-", row.Item("UpdatedDate"))
                        .Item(i, "fgKeteranganUpdate") = IIf(IsDBNull(row.Item("Keterangan")), "", row.Item("Keterangan"))
                        .Item(i, "fgUpdateKetBy") = IIf(IsDBNull(row.Item("UpdateKetBy")), "-", row.Item("UpdateKetBy"))
                        .Item(i, "fgUpdateKetDate") = IIf(IsDBNull(row.Item("UpdateKetDate")), "-", row.Item("UpdateKetDate"))
                        .Item(i, "fgTidakHitungUangMakan") = row.Item("TidakHitungUangMakan")
                        .Item(i, "fgTidakHitungLembur") = row.Item("TidakHitungLembur")
                        .Item(i, "fgHitungUangMakan") = row.Item("HitungUangMakan")

                        If row.Item("JamMasuk") < "09:59" And row.Item("JamMasuk") > "14:01" Then
                            rg = fg.GetCellRange(i, 13, i, 13)
                            rg.StyleNew.BackColor = Color.FromArgb(22, 250, 250)
                        End If

                        If row.Item("deleted") = True Then
                            fg.Rows(i).StyleNew.ForeColor = Color.Red
                        End If

                        i = i + 1
                    Next
                    .AutoSizeCols()
                End With

                If chkGroupkanPersonil.Checked = True Then
                    Call ShowTotalsByPersonil()
                    fg.Cols("fgNoInGroup").Visible = True
                Else
                    fg.Cols("fgNoInGroup").Visible = False
                End If
            Else
                MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
            End If
        Catch EX As Exception
            MsgBox(EX.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ShowTotalsByPersonil()
        With fg
            'Group by IDPersonil
            .Tree.Column = 0
            .Tree.Style = TreeStyleFlags.CompleteLeaf
            .Subtotal(AggregateEnum.Clear)
            .Subtotal(AggregateEnum.Count, 0, 2, 3, "{0}")

            ' Tambahkan penomoran berdasarkan fgIDPersonil
            Dim idxNo As Integer = .Cols("fgNoInGroup").Index       ' pastikan kolom No ada
            Dim idxPersonil As Integer = .Cols("fgIDPersonil").Index

            Dim currentPersonil As String = ""
            Dim nomor As Integer = 0

            For i As Integer = .Rows.Fixed To .Rows.Count - 1
                ' Hanya baris data (bukan subtotal)
                If .Rows(i).IsNode = False Then
                    Dim idPersonil As String = CStr(.Item(i, idxPersonil))

                    ' Jika personil berubah, reset nomor
                    If idPersonil <> currentPersonil Then
                        currentPersonil = idPersonil
                        nomor = 1
                    Else
                        nomor += 1
                    End If

                    .Item(i, idxNo) = nomor
                End If
            Next

            .AutoSizeCols()
        End With

        'ColorSubTotal()
    End Sub



    Private Sub cboPancang_KeyUp(sender As Object, e As KeyEventArgs) Handles cboPancang.KeyUp
        UI.AutoCompleteCombo_KeyUp(cboPancang, e)
    End Sub

    Private Sub cboJabatan_KeyUp(sender As Object, e As KeyEventArgs) Handles cboJabatan.KeyUp
        UI.AutoCompleteCombo_KeyUp(cboJabatan, e)
    End Sub

    Private Sub cboStatus_KeyUp(sender As Object, e As KeyEventArgs) Handles cboStatus.KeyUp
        UI.AutoCompleteCombo_KeyUp(cboStatus, e)
    End Sub

    Private Sub cboBagian_KeyUp(sender As Object, e As KeyEventArgs) Handles cboBagian.KeyUp
        UI.AutoCompleteCombo_KeyUp(cboBagian, e)
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

    Private Sub chkStatus_CheckedChanged(sender As Object, e As EventArgs) Handles chkStatus.CheckedChanged, ChkAllData.CheckedChanged
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
                TxtNama.Text = If(IsDBNull(.Item(.Row, "fgNama")) OrElse .Item(.Row, "fgNama") Is Nothing, "", .Item(.Row, "fgNama").ToString())
                TxtNik.Text = If(IsDBNull(.Item(.Row, "fgNIK")) OrElse .Item(.Row, "fgNIK") Is Nothing, "", .Item(.Row, "fgNIK").ToString())
                TxtStatus.Text = If(IsDBNull(.Item(.Row, "fgStatus")) OrElse .Item(.Row, "fgStatus") Is Nothing, "", .Item(.Row, "fgStatus").ToString())
                CmbKehadiran.Text = If(IsDBNull(.Item(.Row, "fgKehadiran")) OrElse .Item(.Row, "fgKehadiran") Is Nothing, "", .Item(.Row, "fgKehadiran").ToString())
                TxtLiburMingguan.Text = If(IsDBNull(.Item(.Row, "fgLiburMingguan")) OrElse .Item(.Row, "fgLiburMingguan") Is Nothing, "", .Item(.Row, "fgLiburMingguan").ToString())
                TxtJabatan.Text = If(IsDBNull(.Item(.Row, "fgJabatan")) OrElse .Item(.Row, "fgJabatan") Is Nothing, "", .Item(.Row, "fgJabatan").ToString())
                TxtBagian.Text = If(IsDBNull(.Item(.Row, "fgBagian")) OrElse .Item(.Row, "fgBagian") Is Nothing, "", .Item(.Row, "fgBagian").ToString())
                TxtPancang.Text = If(IsDBNull(.Item(.Row, "fgPancang")) OrElse .Item(.Row, "fgPancang") Is Nothing, "", .Item(.Row, "fgPancang").ToString())
                TxtTanggalAbsen.Text = If(IsDBNull(.Item(.Row, "fgTanggalUploadServer")) OrElse .Item(.Row, "fgTanggalUploadServer") Is Nothing, "", .Item(.Row, "fgTanggalUploadServer").ToString())
                IdAbsensi = If(IsDBNull(.Item(.Row, "fgID")) OrElse .Item(.Row, "fgID") Is Nothing, "", .Item(.Row, "fgID").ToString())
                TxtKeterangan.Text = If(IsDBNull(.Item(.Row, "fgKeterangan")) OrElse .Item(.Row, "fgKeterangan") Is Nothing, "", .Item(.Row, "fgKeterangan").ToString())
                ChkTidakHitungUangMakan.Checked = .Item(.Row, "fgTidakHitungUangMakan")
                ChkTidakHitungLembur.Checked = .Item(.Row, "fgTidakHitungLembur")
                ChkHitungUangMakan.Checked = .Item(.Row, "fgHitungUangMakan")
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
            If ChkHitungUangMakan.Checked = True Then
                HitungUangMakan = 1
            ElseIf ChkHitungUangMakan.Checked = False Then
                HitungUangMakan = 0
            End If
            If ChkTidakHitungLembur.Checked = True Then
                tidakHitungLembur = 1
            ElseIf ChkTidakHitungLembur.Checked = False Then
                tidakHitungLembur = 0
            End If

            Dim koneksi As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnRMPApp)
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
            .Parameters.Add("@User", SqlDbType.VarChar, 50).Value = ClsSession.UserID
            .Parameters.Add("@Id", SqlDbType.VarChar, 10).Value = IdAbsensi
            .Parameters.Add("@Keterangan", SqlDbType.Text).Value = TxtKeterangan.Text.ToString
            .Parameters.Add("@TidakHitungUangMakan", SqlDbType.Bit, 1).Value = TidakHitungUangMakan
            .Parameters.Add("@HitungUangMakan", SqlDbType.Bit, 1).Value = HitungUangMakan
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

    Private Sub ChkIdPersonil_CheckedChanged(sender As Object, e As EventArgs) Handles ChkIdPersonil.CheckedChanged, ChkTidakHitungLembur.CheckedChanged, ChkTidakHitungUangMakan.CheckedChanged, ChkHitungUangMakan.CheckedChanged, ChkHitungLembur.CheckedChanged
        If ChkIdPersonil.Checked = True Then
            CmbIdPersonil.Enabled = True
        Else
            CmbIdPersonil.Enabled = False
            CmbIdPersonil.Text = ""
        End If
    End Sub

    Private Sub CmbIdPersonil_KeyUp(sender As Object, e As KeyEventArgs) Handles CmbIdPersonil.KeyUp
        UI.AutoCompleteCombo_KeyUp(CmbIdPersonil, e)
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        If (DB.ExecuteScalarValue(Of String)(StrConnRMPApp," select cast(isnull(deleted,0) as int) as GetValue_ from Android_tblAbsensiPancangNew where ID=" & IdAbsensi)) = 1 Then
            MsgBox("Absen ini tidak bisa di edit, karena sudah di delete !", vbExclamation, AT)
            Exit Sub
        End If

        BtnEdit.Enabled = False
        btnCancel.Enabled = True
        BtnSave.Enabled = True

        CmbKehadiran.Enabled = True
        TxtKeterangan.Enabled = True
        ChkTidakHitungLembur.Enabled = True
        ChkHitungLembur.Enabled = True
        ChkTidakHitungUangMakan.Enabled = True
        ChkHitungUangMakan.Enabled = True
    End Sub

    Private Sub fg_DoubleClick(sender As Object, e As EventArgs) Handles fg.DoubleClick

        If fg.Col <> 3 Then Exit Sub

        Dim image As Image = TryCast(fg.Item(fg.Row, "fgFotoNameMasuk"), Image)

        If image Is Nothing Then
            MsgBox("Foto tidak tersedia!", vbExclamation, AT)
            Exit Sub
        End If

        Using frm As New FrmFotoView
            frm.TampilkanImage(image)
            frm.ShowDialog()
        End Using

    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        lblInfo.Text = Bergerak
        Teks = Microsoft.VisualBasic.Right(Teks, Len(Teks) - 1) & Microsoft.VisualBasic.Left(Teks, 1)
        lblInfo.Text = Teks
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FrmMonLemburKaryawan.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FrmMonUangMakanPCG.Show()
    End Sub

    Private Sub btnexcel_Click(sender As Object, e As EventArgs) Handles btnexcel.Click
        Dim filename As String
        Me.SaveFileDialog.ShowDialog()
        filename = SaveFileDialog.FileName
        Me.fg.SaveExcel(filename & ".xls", "Sheet1", FileFlags.IncludeFixedCells)
        MsgBox("Convert Success !", MsgBoxStyle.Information, AT)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Cursor = Cursors.WaitCursor 'and some various me.Cursor / current.cursor 
        Application.DoEvents()
        'Call FrmMonFingerPancangNew.Show(DockPanel1)
        Call FrmMonLemburPersonilPCG.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Cursor = Cursors.WaitCursor 'and some various me.Cursor / current.cursor 
        Application.DoEvents()
        'Call FrmMonFingerPancangNew.Show(DockPanel1)
        Call frmmstuangmakan.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg.BeforeEdit
        e.Cancel = True
    End Sub
End Class
