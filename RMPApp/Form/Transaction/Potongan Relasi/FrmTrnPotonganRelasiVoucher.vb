Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports Microsoft.Office.Interop

Public Class FrmTrnPotonganRelasiVoucher
    Private Sub FrmTrnApprovalPenerimaanFind_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call ClsFlexGrid.ApplyStyle(fg)
        Call ShowData()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' jika txtReffNo tidak di isi, maka tampilkan pesan peringatan
        If txtReffNo.Text = "" Then
            MsgBox("Silakan masukkan Reff No sebelum menambahkan voucher.", vbExclamation, AT)
            Exit Sub
        End If

        Dim reffNoExists As String

        ' cek jika reffno ada di database acc
        reffNoExists = CStr(DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"select isnull((select ReffNo from DBPancang..tblCBTrnCashBankJournalDtl where ReffNo='" & txtReffNo.Text & "' and Debit>0),'') as GetValueString"))
        If reffNoExists = "" Then
            MsgBox("Reff No Tidak Valid. Silakan masukkan Reff No yang lain.", vbExclamation, AT)
            Exit Sub
        End If

        ' cek jika reffno ada di database rmp
        reffNoExists = CStr(DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"select isnull((select ReffNo from RMPApp..tblTrnPotonganRelasiVoucher where ReffNo='" & txtReffNo.Text & "'),'') as GetValueString"))
        If reffNoExists <> "" Then
            MsgBox("Reff No sudah ada. Silakan masukkan Reff No yang lain.", vbExclamation, AT)
            Exit Sub
        End If

        ' save data
        DB.ExecuteQuery(StrConnRMPApp, "insert into RMPApp..tblTrnPotonganRelasiVoucher
                                                      (ReffNo, COA, RpPotongan, Remark, SudahDigunakan, CreatedBy, CreatedDate, CreatedComputer)
                                                      select 
                                                      ReffNo, COA, Debit, Remark, 0, '" & ClsSession.UserID & "', GETDATE(), HOST_NAME()
                                                      from DBPancang..tblCBTrnCashBankJournalDtl where ReffNo='" & txtReffNo.Text & "' and Debit>0")

        MsgBox("Data voucher dengan Reff No: " & txtReffNo.Text & " berhasil ditambahkan.", vbInformation, AT)

        Call ShowData()
    End Sub

    Public Sub ShowData()
        Dim dt As New DataTable
        Dim i As Integer = 1
        Dim sql As String = "select top 100 *,RpPotongan-SudahDigunakan as SisaRpPotongan from RMPApp..tblTrnPotonganRelasiVoucher order by CreatedDate desc"

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fg
            .Rows.Count = 1 ' Reset grid

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "ID") = row("ID")
                    .Item(i, "ReffNo") = row("ReffNo")
                    .Item(i, "COA") = row("COA")
                    .Item(i, "Remark") = row("Remark")
                    .Item(i, "RpPotongan") = row("RpPotongan")
                    .Item(i, "SudahDigunakan") = row("SudahDigunakan")
                    .Item(i, "SisaRpPotongan") = row("SisaRpPotongan")
                    .Item(i, "CreatedBy") = row("CreatedBy")
                    .Item(i, "CreatedDate") = row("CreatedDate")

                    ' Masukkan gambar yang sudah di-resize
                    .SetCellImage(i, "Delete", Func.ResizeImage(My.Resources.DELETED_20, 16, 16))

                    i += 1
                Next

                .AutoSizeCols()

                fg.Cols("Remark").Width = 300
            Else
                MsgBox("Tidak ada data.", vbInformation, AT)
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
                    If MsgBox("Apakah Anda ingin menghapus voucher dengan Reff No. " & fg.Item(fg.Row, "ReffNo") &
                          " ?", vbYesNo, AT) = vbNo Then Exit Sub

                    ' Cek apakah sudah digunakan
                    Dim reffNoUsed As String
                    reffNoUsed = CStr(DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"select isnull((select ReffNo from RMPApp..tblTrnPotonganRelasiVoucher where ReffNo='" & fg.Item(fg.Row, "ReffNo") & "' and SudahDigunakan<>0),'') as GetValueString"))
                    If reffNoUsed <> "" Then
                        MsgBox("Voucher dengan Reff No: " & fg.Item(fg.Row, "ReffNo") & " sudah digunakan, tidak dapat dihapus.", vbExclamation, AT)
                        Exit Sub
                    End If

                    ' exec delete data
                    Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "delete RMPApp..tblTrnPotonganRelasiVoucher where ID=" & fg.Item(fg.Row, "ID"))

                    MsgBox("Data voucher dengan Reff No: " & fg.Item(fg.Row, "ReffNo") & " berhasil dihapus.", vbInformation, AT)

                    Call ShowData()
            End Select
        End With
    End Sub

    Private Sub FrmTrnApprovalPenerimaanFind_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        lblJudulForm.Left = (Me.Width - lblJudulForm.Width) / 2
    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg.BeforeEdit
        e.Cancel = True
    End Sub
End Class