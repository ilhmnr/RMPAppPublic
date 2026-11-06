Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmApprovalPenerimaanKelapa
    Public Approval As String = "" ' Approval1 / Approval2 / Approval3
    Private Sub FrmTrnApprovalPembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case Approval
            Case "Approval1"
                lblJudulForm.Text = "Approval Penerimaan - Level 1"
            Case "Approval2"
                lblJudulForm.Text = "Approval Penerimaan - Level 2"
            Case "Approval3"
                lblJudulForm.Text = "Approval Penerimaan - Level 3"
        End Select

        lblJudulForm.Left = (Me.Width - lblJudulForm.Width) / 2

        dtpStartTrans.Value = Now
        dtpEndTrans.Value = Now

        txtNoTransaksi.Text = ""
        txtKeterangan.Text = "Approved"

        ' Set ComboBox
        If ClsSession.RoleName = "MAIN ADMIN NOTA" Then
            Modul_RMP.Combo.PancangByGroup(cboPancang, ClsSession.UserID)
        Else
            Modul_RMP.Combo.SetPancang(cboPancang)
        End If
        Modul_RMP.Combo.SetKapal(cboKapal)

        Call HeaderFG()
    End Sub

    Public Sub HeaderFG()
        ' Pastikan objek fg sudah tersedia
        If fg Is Nothing Then Exit Sub

        With fg
            ' === Pengaturan dasar grid ===
            .AllowEditing = True
            .Font = New Font("Century Gothic", 9.0!, FontStyle.Regular)
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True

            ' === Warna header dan baris selang-seling ===
            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)   ' Warna latar header utama
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224) ' Warna latar baris bergantian
            .Styles.Fixed.TextAlign = TextAlignEnum.LeftCenter          ' Rata kiri untuk header

            ' === Pastikan ada minimal 2 baris header ===
            'If .Rows.Count < 2 Then .Rows.Count = 2

            ' === Warna khusus untuk baris header ke-0 dan ke-1 ===
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

            ' === Aktifkan fitur merging untuk header ===
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True

            ' === Sesuaikan ukuran kolom secara otomatis ===
            .AutoSizeCols()
        End With
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click
        With fg
            ' Pastikan ada baris data dan tidak klik header
            If .Rows.Count = 1 Then Exit Sub

            ' Ambil nama kolom yang diklik
            Dim colName As String = .Cols(.Col).Name

            Select Case colName
                Case "View"
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
                        .StatusOpenForm = "ViewApproval"
                        .txtNoTrans.Text = fg.Item(fg.Row, "NoTrans")
                        .dtpTanggalApproval.Text = fg.Item(fg.Row, "TanggalPengajuan")
                        .dtpTanggalNota1.Text = fg.Item(fg.Row, "TanggalNota1")
                        .dtpTanggalNota2.Text = fg.Item(fg.Row, "TanggalNota2")
                        .txtTrip.Text = fg.Item(fg.Row, "Trip")
                        FrmMain.BukaMenu(frm, FrmMain.mnuTrnPengajuanPenerimaanNota)
                        .cboPancang.SelectedValue = fg.Item(fg.Row, "PancangID")
                        .cboKapal.SelectedValue = fg.Item(fg.Row, "KapalID")
                    End With
            End Select
        End With
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Call ShowData()
    End Sub

    Public Sub ShowData()
        Me.Cursor = Cursors.WaitCursor

        Dim dt As New DataTable
        Dim i As Integer = 1
        Dim sql As String = "select * from RMPApp..vw_MonApprovalPenerimaanHdr as a 
                                where cast(a.TanggalApproval as date) between '" & Format(dtpStartTrans.Value, "yyyy-MM-dd") & "' and '" & Format(dtpEndTrans.Value, "yyyy-MM-dd") & "' and a.NoTrans like '%" & txtNoTransaksi.Text & "%' "

        Select Case Approval
            Case "Approval1"
                sql &= " and a.approval_status_1 = 0 and a.approval_status_2 = 0 and a.approval_status_3 = 0 "
            Case "Approval2"
                sql &= " and a.approval_status_1 = 1 and a.approval_status_2 = 0 and a.approval_status_3 = 0 "
            Case "Approval3"
                sql &= " and a.approval_status_1 = 1 and a.approval_status_2 = 1 and a.approval_status_3 = 0 "
        End Select

        ' jika ada filter trip
        If txtTrip.Text <> "" Then
            sql &= " and a.Trip = " & txtTrip.Text & " "
        End If

        ' jika ada filter kapal
        If Replace(cboKapal.Text, " ", "") <> "" Then
            sql &= " and a.KapalID = " & cboKapal.SelectedValue & " "
        End If

        ' jika ada filter pancang
        If Replace(cboPancang.Text, " ", "") <> "" Then
            sql &= " and a.PancangID = " & cboPancang.SelectedValue & " "
        End If

        If ClsSession.RoleName = "ADMIN NOTA" Then
            sql &= " and EXISTS (
					    SELECT 1 FROM tblUtlPancangGroup pg
						INNER JOIN tblUtlUserPancangGroup upg ON upg.GroupID = pg.GroupID
						WHERE pg.IDPancang = a.PancangID AND upg.UserID = '" & ClsSession.UserID & "'
					)"
        End If

        sql &= " order by a.TanggalApproval asc"

        ' Ambil gambar dari resource
        Dim imgDetailOriginal As Image = My.Resources.detail_button_01112025

        ' Resize gambar agar muat di cell
        Dim imgDetail As Image = Modul_RMP.Func.ResizeImage(imgDetailOriginal, 16, 16)

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fg
            .Rows.Count = 1 ' Reset grid

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "NoTrans") = row("NoTrans")
                    .Item(i, "TanggalPengajuan") = row("TanggalApproval")
                    .Item(i, "TanggalNota1") = row("TanggalNota1")
                    .Item(i, "TanggalNota2") = row("TanggalNota2")
                    .Item(i, "PancangID") = row("PancangID")
                    .Item(i, "Pancang") = row("Pancang")
                    .Item(i, "KapalID") = row("KapalID")
                    .Item(i, "Kapal") = row("KapalName")
                    .Item(i, "Trip") = row("Trip")
                    .Item(i, "Tujuan") = row("Tujuan")
                    .Item(i, "Netto") = row("Netto2")
                    .Item(i, "TotalRp") = row("TotalRp")
                    .Item(i, "PPH22") = row("PPHRp")
                    .Item(i, "Pinjaman") = row("Pinjaman")
                    .Item(i, "GrandTotalRp") = row("GrandTotalRp")
                    .Item(i, "CreatedBy") = row("CreatedBy")
                    .Item(i, "CreatedDate") = row("CreatedDate")

                    ' Masukkan gambar yang sudah di-resize
                    .SetCellImage(i, "View", imgDetail)

                    i += 1
                Next

                ' === Atur posisi gambar ke tengah ===
                .Cols("View").ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter

                AddTotalRow()

                .AutoSizeCols()
            Else
                MsgBox("Tidak ada data.", vbInformation, AT)
            End If
        End With

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub RemoveTotalRow()
        For r As Integer = fg.Rows.Fixed To fg.Rows.Count - 1
            If fg.Item(r, "Tujuan") IsNot Nothing AndAlso
           fg.Item(r, "Tujuan").ToString() = "TOTAL :" Then
                fg.Rows.Remove(r)
                Exit For
            End If
        Next
    End Sub

    Private Sub AddTotalRow()
        If fg.Rows.Count <= fg.Rows.Fixed Then Exit Sub

        Dim totalNetto As Decimal = 0
        Dim totalTotalRp As Decimal = 0
        Dim totalPPH22 As Decimal = 0
        Dim totalPinjaman As Decimal = 0
        Dim totalGrandTotal As Decimal = 0
        Dim hasChecked As Boolean = False

        ' === cek apakah ada yang dicentang ===
        For r As Integer = fg.Rows.Fixed To fg.Rows.Count - 1
            If fg.Item(r, "Select") = True Then
                hasChecked = True
                Exit For
            End If
        Next

        ' === hitung total ===
        For r As Integer = fg.Rows.Fixed To fg.Rows.Count - 1
            If hasChecked = False OrElse fg.Item(r, "Select") = True Then
                totalNetto += Val(fg.Item(r, "Netto"))
                totalTotalRp += Val(fg.Item(r, "TotalRp"))
                totalPPH22 += Val(fg.Item(r, "PPH22"))
                totalPinjaman += Val(fg.Item(r, "Pinjaman"))
                totalGrandTotal += Val(fg.Item(r, "GrandTotalRp"))
            End If
        Next

        ' === tambah baris TOTAL ===
        fg.AddItem("")
        Dim lastRow As Integer = fg.Rows.Count - 1

        fg.Item(lastRow, "Tujuan") = "TOTAL :"
        fg.Item(lastRow, "Netto") = totalNetto
        fg.Item(lastRow, "TotalRp") = totalTotalRp
        fg.Item(lastRow, "PPH22") = totalPPH22
        fg.Item(lastRow, "Pinjaman") = totalPinjaman
        fg.Item(lastRow, "GrandTotalRp") = totalGrandTotal

        ' === style TOTAL ===
        fg.Rows(lastRow).StyleNew.BackColor = Color.LightYellow
        fg.Rows(lastRow).StyleNew.Font = New Font(fg.Font, FontStyle.Bold)
        fg.Rows(lastRow).AllowEditing = False
    End Sub

    Private Sub fg_BeforeSort(sender As Object, e As C1.Win.C1FlexGrid.SortColEventArgs) _
Handles fg.BeforeSort
        RemoveTotalRow()
    End Sub

    Private Sub fg_AfterSort(sender As Object, e As C1.Win.C1FlexGrid.SortColEventArgs) _
Handles fg.AfterSort
        AddTotalRow()
    End Sub

    Private Sub fg_AfterEdit(sender As Object, e As C1.Win.C1FlexGrid.RowColEventArgs) _
    Handles fg.AfterEdit

        If fg.Cols(e.Col).Name = "Select" Then
            RemoveTotalRow()
            AddTotalRow()
        End If
    End Sub

    Private Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs) _
    Handles chkSelectAll.CheckedChanged

        If fg.Rows.Count <= 1 Then Exit Sub

        For r As Integer = fg.Rows.Fixed To fg.Rows.Count - 1
            fg.Item(r, "Select") = chkSelectAll.Checked
        Next

        RemoveTotalRow()
        AddTotalRow()
    End Sub

    Private Sub cmdApproved_Click(sender As Object, e As EventArgs) Handles cmdApproved.Click
        Call ApprovedOrReject(1)
    End Sub

    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        Call ApprovedOrReject(2)
    End Sub

    Private Sub ApprovedOrReject(ByVal Status As Integer)
        ' === Deklarasi koneksi (tanpa transaction, karena SP sudah punya transaction sendiri) ===
        Dim Conn As SqlConnection = Nothing
        Dim NoTrans As String = ""

        ' === Validasi awal ===
        Dim isAnySelected As Boolean = False
        For r = 1 To fg.Rows.Count - 2
            If fg.Item(r, "Select") = True Then
                isAnySelected = True
            End If
        Next
        If isAnySelected = False Then
            MsgBox("Tidak ada data yang dipilih untuk di-approve.", vbExclamation, "Peringatan")
            Exit Sub
        End If

        If Replace(txtKeterangan.Text, " ", "") = "" Then
            MsgBox("Keterangan approval/reject harus diisi.", vbExclamation, "Peringatan")
            Exit Sub
        End If

        For r = 1 To fg.Rows.Count - 2
            If fg.Item(r, "Select") = True Then
                If CInt(DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"select isnull((select WHSID from DBPancang..tblINVMstWarehouse where RefferenceID=" & fg.Item(r, "PancangID") & "),0) as GetValueString")) = 0 Then
                    MsgBox("Tidak bisa approve!" & vbCrLf &
                           "Baris No : " & r & vbCrLf &
                           "Pancang : " & fg.Item(r, "Pancang") & vbCrLf &
                           "Belum dibuatkan master gudang di program BPI.",
                           vbExclamation, "Peringatan")
                    Exit Sub
                End If
            End If
        Next

        Me.Cursor = Cursors.WaitCursor

        Try
            ' === Buka koneksi (tiap baris dipanggil ke SP, SP yang handle transaction-nya) ===
            Conn = Modul_RMP.DB.OpenConnection(StrConnRMPApp)

            ' === Simpan HEADER per baris yang dipilih ===
            For r = 1 To fg.Rows.Count - 2
                If fg.Item(r, "Select") = True Then
                    If SaveHdr(Conn, r, Status) = False Then
                        Throw New Exception("Simpan Data Gagal!")
                    End If
                End If
            Next

            MsgBox("Data berhasil di approved/reject !", vbInformation, "Sukses")

            Call btnSearch.PerformClick()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error")
        Finally
            ' === Tutup koneksi dan kembalikan cursor ===
            If Conn IsNot Nothing AndAlso Conn.State = ConnectionState.Open Then Conn.Close()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function SaveHdr(ByVal Conn As SqlConnection, ByVal r As Integer, ByVal Status As Integer) As Boolean
        SaveHdr = False

        Dim ApprovalLevel As Integer = 0
        Select Case Approval
            Case "Approval1"
                ApprovalLevel = 1
            Case "Approval2"
                ApprovalLevel = 2
            Case "Approval3"
                ApprovalLevel = 3
        End Select

        'Try
        Using cmd As New SqlCommand("RMPApp..spAndroidSaveTrnApprove", Conn)
            cmd.CommandType = CommandType.StoredProcedure

            ' === Input parameters ===
            cmd.Parameters.Add("@no_trans", SqlDbType.VarChar, 30).Value = fg.Item(r, "NoTrans")
            cmd.Parameters.Add("@mst_kode_approval", SqlDbType.VarChar, 50).Value = "TRX-20251120-0001"
            cmd.Parameters.Add("@approval_level", SqlDbType.Int).Value = ApprovalLevel
            cmd.Parameters.Add("@approval_status", SqlDbType.Int).Value = Status
            cmd.Parameters.Add("@remarks", SqlDbType.VarChar).Value = txtKeterangan.Text
            cmd.Parameters.Add("@saved_by", SqlDbType.VarChar, 50).Value = ClsSession.UserID

            ' === Output parameters ===
            cmd.Parameters.Add("@Flag", SqlDbType.Int).Direction = ParameterDirection.Output
            cmd.Parameters.Add("@MsgOutput", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output

            ' === Execute ===
            cmd.ExecuteNonQuery()

            ' === Ambil hasil output ===
            Dim resultFlag As Integer = If(cmd.Parameters("@Flag").Value Is DBNull.Value, 0, Convert.ToInt32(cmd.Parameters("@Flag").Value))
            Dim resultMsgOutput As String = If(cmd.Parameters("@MsgOutput").Value Is DBNull.Value, "", cmd.Parameters("@MsgOutput").Value)

            ' === Cek hasil ===
            If resultFlag = 1 Then
                SaveHdr = True
            Else
                MsgBox("Gagal menyimpan data. Pesan: " & vbCrLf & resultMsgOutput, vbExclamation, AT)
            End If
        End Using
        'Catch ex As Exception
        'MsgBox(ex.Message, vbCritical, "Error")
        'End Try
    End Function

    Private Sub FrmTrnApprovalPembelian_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        lblJudulForm.Left = (Me.Width - lblJudulForm.Width) / 2
    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg.BeforeEdit
        If fg.Cols(e.Col).Name <> "Select" Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub fg_SelChange(sender As Object, e As EventArgs) Handles fg.SelChange
        txtTotal.Text = ClsFunction.FormatNum(fg.Aggregate(AggregateEnum.Sum), 2)
    End Sub

End Class