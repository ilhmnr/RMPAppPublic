Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmApprovalKomisi
    Public Approval As String = "" ' Approval1 / Approval2 / Approval3
    Private Sub FrmTrnApprovalPembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClsFlexGrid.ApplyStyle(fg)

        Select Case Approval
            Case "Approval1"
                lblJudulForm.Text = "Approval Komisi - Level 1"
            Case "Approval2"
                lblJudulForm.Text = "Approval Komisi - Level 2"
            Case "Approval3"
                lblJudulForm.Text = "Approval Komisi - Level 3"
        End Select

        dtpStartTrans.Value = Now
        dtpEndTrans.Value = Now

        txtNoTransaksi.Text = ""
        txtKeterangan.Text = "Approved"

        ' Set ComboBox
        Modul_RMP.Combo.SetPancang(cboPancang)
        cboPancang.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboPancang.AutoCompleteSource = AutoCompleteSource.ListItems
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
                        FrmMain.BukaMenu(frm, FrmMain.mnuTrnKomisi)
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
        Dim dt As New DataTable
        Dim i As Integer = 1
        Dim sql As String = "select * from RMPApp..vw_MonKomisiBPIHdr where cast(TanggalPengajuan as date) between '" & Format(dtpStartTrans.Value, "yyyy-MM-dd") & "' and '" & Format(dtpEndTrans.Value, "yyyy-MM-dd") & "' and NoTrans like '%" & txtNoTransaksi.Text & "%' "

        Select Case Approval
            Case "Approval1"
                sql &= " and approval_status_1 = 0 and approval_status_2 = 0 and approval_status_3 = 0 "
            Case "Approval2"
                sql &= " and approval_status_1 = 1 and approval_status_2 = 0 and approval_status_3 = 0 "
            Case "Approval3"
                sql &= " and approval_status_1 = 1 and approval_status_2 = 1 and approval_status_3 = 0 "
        End Select

        ' jika ada filter pancang
        If Replace(cboPancang.Text, " ", "") <> "" Then
            sql &= " and IDPancang = " & cboPancang.SelectedValue & " "
        End If

        sql &= " order by TanggalPengajuan asc"

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fg
            .Rows.Count = 1 ' Reset grid

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "NoTrans") = row("NoTrans")
                    .Item(i, "TanggalPengajuan") = row("TanggalPengajuan")
                    .Item(i, "JenisKomisi") = row("JenisKomisi")
                    .Item(i, "JenisBahanBaku") = row("JenisBahanBaku")
                    .Item(i, "PancangID") = row("IDPancang")
                    .Item(i, "Pancang") = row("Pancang")
                    .Item(i, "RelasiID") = row("RelasiID")
                    .Item(i, "RelasiName") = row("RelasiName")
                    .Item(i, "BadanUsaha") = row("BadanUsaha")
                    .Item(i, "TotalPemasukan") = row("TotalPemasukan")
                    .Item(i, "Tarif") = row("Tarif")
                    .Item(i, "TotalRp") = row("TotalRp")
                    .Item(i, "TarifPajak") = row("TarifPajak")
                    .Item(i, "DPP") = row("DPP")
                    .Item(i, "PotPPH21") = row("PotPPH21")
                    .Item(i, "PotPPH23") = row("PotPPH23")
                    .Item(i, "PotDP") = row("PotDP")
                    .Item(i, "GrandTotal") = row("GrandTotal")
                    .Item(i, "CreatedBy") = row("CreatedBy")
                    .Item(i, "CreatedDate") = row("CreatedDate")

                    i += 1
                Next

                Dim totalPemasukan As Decimal = 0
                Dim totalTotalRp As Decimal = 0
                Dim totalPPH21 As Decimal = 0
                Dim totalPPH23 As Decimal = 0
                Dim totalGrandTotal As Decimal = 0

                For r As Integer = 1 To fg.Rows.Count - 1
                    totalPemasukan += Val(fg.Item(r, "TotalPemasukan"))
                    totalTotalRp += Val(fg.Item(r, "TotalRp"))
                    totalPPH21 += Val(fg.Item(r, "PotPPH21"))
                    totalPPH23 += Val(fg.Item(r, "PotPPH23"))
                    totalGrandTotal += Val(fg.Item(r, "GrandTotal"))
                Next

                AddTotalRow()

                .AutoSizeCols()
            Else
                MsgBox("Tidak ada data.", vbInformation, AT)
            End If
        End With
    End Sub

    Private Sub RemoveTotalRow()
        For r As Integer = fg.Rows.Fixed To fg.Rows.Count - 1
            If fg.Item(r, "RelasiName") IsNot Nothing AndAlso
           fg.Item(r, "RelasiName").ToString() = "TOTAL :" Then
                fg.Rows.Remove(r)
                Exit For
            End If
        Next
    End Sub

    Private Sub AddTotalRow()
        If fg.Rows.Count <= fg.Rows.Fixed Then Exit Sub

        Dim totalPemasukan As Decimal = 0
        Dim totalTotalRp As Decimal = 0
        Dim totalPPH21 As Decimal = 0
        Dim totalPPH23 As Decimal = 0
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
                totalPemasukan += Val(fg.Item(r, "TotalPemasukan"))
                totalTotalRp += Val(fg.Item(r, "TotalRp"))
                totalPPH21 += Val(fg.Item(r, "PotPPH21"))
                totalPPH23 += Val(fg.Item(r, "PotPPH23"))
                totalGrandTotal += Val(fg.Item(r, "GrandTotal"))
            End If
        Next

        ' === tambah row TOTAL ===
        fg.AddItem("")
        Dim lastRow As Integer = fg.Rows.Count - 1

        fg.Item(lastRow, "RelasiName") = "TOTAL :"
        fg.Item(lastRow, "TotalPemasukan") = totalPemasukan
        fg.Item(lastRow, "TotalRp") = totalTotalRp
        fg.Item(lastRow, "PotPPH21") = totalPPH21
        fg.Item(lastRow, "PotPPH23") = totalPPH23
        fg.Item(lastRow, "GrandTotal") = totalGrandTotal

        ' === style TOTAL ===
        fg.Rows(lastRow).StyleNew.BackColor = Color.LightYellow
        fg.Rows(lastRow).StyleNew.Font = New Font(fg.Font, FontStyle.Bold)
    End Sub

    Private Sub fg_BeforeSort(sender As Object, e As C1.Win.C1FlexGrid.SortColEventArgs) Handles fg.BeforeSort

        RemoveTotalRow()
    End Sub

    Private Sub fg_AfterSort(sender As Object, e As C1.Win.C1FlexGrid.SortColEventArgs) Handles fg.AfterSort

        AddTotalRow()
    End Sub

    Private Sub fg_AfterEdit(sender As Object, e As C1.Win.C1FlexGrid.RowColEventArgs) Handles fg.AfterEdit


        If fg.Cols(e.Col).Name = "Select" Then
            RemoveTotalRow()
            AddTotalRow()
        End If
    End Sub

    Private Sub chkSelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelectAll.CheckedChanged

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
                cmd.Parameters.Add("@mst_kode_approval", SqlDbType.VarChar, 50).Value = "TRX-20251120-0006"
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