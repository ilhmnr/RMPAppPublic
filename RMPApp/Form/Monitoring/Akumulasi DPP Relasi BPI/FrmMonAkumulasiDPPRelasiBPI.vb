Imports C1.Win.C1FlexGrid
Imports Microsoft.Office.Interop

Public Class FrmMonAkumulasiDPPRelasiBPI
    Private Sub FrmMonApprovalPenerimaan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call ClsFlexGrid.ApplyStyle(fg)
    End Sub

    Private Sub FrmMonApprovalPenerimaan_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        lblJudulForm.Left = (Me.Width \ 2) - (lblJudulForm.Width \ 2)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Me.Cursor = Cursors.WaitCursor

        Dim dt As DataTable
        Dim i As Integer = 1
        Dim sql As String = ""
        Dim RelasiIDParam As String = ""
        Dim No As Integer = 1

        If Replace(txtRelasiID.Text, " ", "") <> "" Then
            RelasiIDParam = "'" & txtRelasiID.Text & "'"
        Else
            RelasiIDParam = "NULL"
        End If

        sql = "select * from RMPApp..fnMonAkumulasiDPPRelasi('" &
      Format(dtpPeriode.Value, "yyyy-MM-dd") & "'," &
      RelasiIDParam & ") order by SupplierID,TanggalPengajuan asc"

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fg
            .Rows.Count = 1

            If dt.Rows.Count > 0 Then

                Dim lastRelasiID As Object = Nothing
                Dim rowHeaderIndex As Integer = 0
                Dim sumDPPRelasi As Decimal = 0

                For Each row As DataRow In dt.Rows

                    ' =========================
                    ' JIKA RELASI BERGANTI
                    ' =========================
                    If lastRelasiID Is Nothing OrElse
               row("SupplierID").ToString() <> lastRelasiID.ToString() Then

                        ' simpan total ke header sebelumnya
                        If lastRelasiID IsNot Nothing Then
                            .Item(rowHeaderIndex, "DPP") =
                        Format(sumDPPRelasi, "N0")
                        End If

                        ' reset total
                        sumDPPRelasi = 0

                        ' buat header baru
                        .AddItem("")
                        rowHeaderIndex = i
                        .Item(i, "NoTrans") =
                    "RELASI : " & row("SupplierID").ToString() & " - " & row("NamaSup").ToString()

                        .Rows(i).StyleNew.BackColor = Color.LightGreen
                        .Rows(i).StyleNew.Font =
                    New Font(.Font, FontStyle.Bold)
                        .Rows(i).AllowEditing = False

                        i += 1
                        lastRelasiID = row("SupplierID")
                    End If

                    ' =========================
                    ' DETAIL
                    ' =========================
                    Dim dpp As Decimal = CDec(row("DPP"))
                    sumDPPRelasi += dpp

                    .AddItem(No)
                    .Item(i, "NoTrans") = row("NoTrans")
                    .Item(i, "NameTrans") = row("NameTrans")
                    .Item(i, "TanggalPengajuan") = row("TanggalPengajuan")
                    .Item(i, "RelasiID") = row("SupplierID")
                    .Item(i, "RelasiName") = row("NamaSup")
                    .Item(i, "RekeningName") = row("RekeningName")
                    .Item(i, "RekeningNo") = row("RekeningNo")
                    .Item(i, "RekeningBank") = row("RekeningBank")
                    .Item(i, "DPP") = Format(dpp, "N0")

                    i += 1
                    No += 1
                Next

                ' =========================
                ' TOTAL HEADER TERAKHIR
                ' =========================
                If rowHeaderIndex > 0 Then
                    .Item(rowHeaderIndex, "DPP") =
                Format(sumDPPRelasi, "N0")
                End If

                .AutoSizeCols()
            Else
                MsgBox("Tidak ada data.", vbInformation, AT)
            End If
        End With

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg.BeforeEdit
        e.Cancel = True
    End Sub
End Class