Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmApprovalTambangKapal
    Public Approval As String = "" ' Approval1 / Approval2 / Approval3
    Private Sub FrmTrnApprovalPembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case Approval
            Case "Approval1"
                lblJudulForm.Text = "Approval Tambang Kapal - Level 1"
            Case "Approval2"
                lblJudulForm.Text = "Approval Tambang Kapal - Level 2"
            Case "Approval3"
                lblJudulForm.Text = "Approval Tambang Kapal - Level 3"
        End Select

        lblJudulForm.Left = (Me.Width - lblJudulForm.Width) / 2

        dtpStartTrans.Value = Now
        dtpEndTrans.Value = Now

        txtNoTransaksi.Text = ""
        txtKeterangan.Text = "Approved"

        ' Set ComboBox
        Modul_RMP.Combo.SetPancang(cboPancang)
        cboPancang.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboPancang.AutoCompleteSource = AutoCompleteSource.ListItems
        Modul_RMP.Combo.SetKapal(cboKapal)
        cboKapal.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboKapal.AutoCompleteSource = AutoCompleteSource.ListItems

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
                        If TypeOf f Is FrmTrnTambangKapalBPI Then
                            f.Close()
                            Exit For
                        End If
                    Next

                    ' === Buat instance baru ===
                    Dim frm As New FrmTrnTambangKapalBPI
                    With frm
                        .StatusOpenForm = "View"
                        FrmMain.BukaMenu(frm, FrmMain.mnuTrnTambangKapal)
                        .ShowDataView(fg.Item(fg.Row, "HeaderID"))
                    End With
            End Select
        End With
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Call ShowData()
    End Sub

    Public Sub ShowData()
        Dim dt As New DataTable
        Dim i As Integer = 1

        Dim sql As String = "select * from RMPApp..vw_MonTambangKapal where cast(TanggalPengajuan as date) between '" & Format(dtpStartTrans.Value, "yyyy-MM-dd") & "' and '" & Format(dtpEndTrans.Value, "yyyy-MM-dd") & "' and NoTrans like '%" & txtNoTransaksi.Text & "%' "

        Select Case Approval
            Case "Approval1"
                sql &= " and approval_status_1 = 0 and approval_status_2 = 0 and approval_status_3 = 0 "
            Case "Approval2"
                sql &= " and approval_status_1 = 1 and approval_status_2 = 0 and approval_status_3 = 0 "
            Case "Approval3"
                sql &= " and approval_status_1 = 1 and approval_status_2 = 1 and approval_status_3 = 0 "
        End Select

        If txtTrip.Text <> "" Then
            sql &= " and Trip = " & txtTrip.Text & " "
        End If

        If Replace(cboKapal.Text, " ", "") <> "" Then
            sql &= " and IDKapal = " & cboKapal.SelectedValue & " "
        End If

        If Replace(cboPancang.Text, " ", "") <> "" Then
            sql &= " and IDPancang = " & cboPancang.SelectedValue & " "
        End If

        sql &= " order by TanggalPengajuan asc"

        Dim imgDetail As Image =
        Modul_RMP.Func.ResizeImage(My.Resources.detail_button_01112025, 16, 16)

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fg
            .Rows.Count = 1

            If dt.Rows.Count = 0 Then
                MsgBox("Tidak ada data.", vbInformation, AT)
                Exit Sub
            End If

            For Each row As DataRow In dt.Rows
                .AddItem(i)
                .Item(i, "HeaderID") = row("HeaderID")
                .Item(i, "NoTrans") = row("NoTrans")
                .Item(i, "TanggalPengajuan") = row("TanggalPengajuan")
                .Item(i, "Pancang") = row("Pancang")
                .Item(i, "Kapal") = row("Kapal")
                .Item(i, "Trip") = row("Trip")
                .Item(i, "Tujuan") = row("Tujuan")
                .Item(i, "Jenis") = row("Jenis")
                .Item(i, "RelasiID") = row("SupplierID")
                .Item(i, "RelasiName") = row("RekeningName")
                .Item(i, "BadanUsaha") = row("BadanUsaha")
                .Item(i, "Netto1Pabrik") = row("Netto1Pabrik")
                .Item(i, "GrandTotal") = row("GrandTotal")
                .Item(i, "CreatedBy") = row("CreatedBy")
                .Item(i, "CreatedDate") = row("CreatedDate")

                .SetCellImage(i, "View", imgDetail)
                i += 1
            Next

            .Cols("View").ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter

            AddTotalRow()
            .AutoSizeCols()
        End With
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
        Dim totalGrandTotal As Decimal = 0
        Dim hasChecked As Boolean = False

        ' cek apakah ada yang dicentang
        For r As Integer = fg.Rows.Fixed To fg.Rows.Count - 1
            If fg.Item(r, "Select") = True Then
                hasChecked = True
                Exit For
            End If
        Next

        ' hitung total
        For r As Integer = fg.Rows.Fixed To fg.Rows.Count - 1
            If hasChecked = False OrElse fg.Item(r, "Select") = True Then
                totalNetto += Val(fg.Item(r, "Netto1Pabrik"))
                totalGrandTotal += Val(fg.Item(r, "GrandTotal"))
            End If
        Next

        fg.AddItem("")
        Dim lastRow As Integer = fg.Rows.Count - 1

        fg.Item(lastRow, "Tujuan") = "TOTAL :"
        fg.Item(lastRow, "Netto1Pabrik") = totalNetto
        fg.Item(lastRow, "GrandTotal") = totalGrandTotal

        fg.Rows(lastRow).StyleNew.BackColor = Color.LightYellow
        fg.Rows(lastRow).StyleNew.Font = New Font(fg.Font, FontStyle.Bold)
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
        ' === Deklarasi koneksi dan transaksi ===
        Dim Conn As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnRMPApp)
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

        Me.Cursor = Cursors.WaitCursor

        Try
            ' === 1. Simpan HEADER ===
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
            If Conn.State = ConnectionState.Open Then Conn.Close()
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

        Try
            Using cmd As New SqlCommand("RMPApp..spAndroidSaveTrnApprove", Conn)
                cmd.CommandType = CommandType.StoredProcedure

                ' === Input parameters ===
                cmd.Parameters.Add("@no_trans", SqlDbType.VarChar, 30).Value = fg.Item(r, "NoTrans")
                cmd.Parameters.Add("@mst_kode_approval", SqlDbType.VarChar, 50).Value = "TRX-20251120-0004"
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
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Error")
        End Try
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