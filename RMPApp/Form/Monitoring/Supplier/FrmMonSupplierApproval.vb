Imports C1.Win.C1FlexGrid

Public Class FrmMonSupplierApproval
    Private Sub FrmMonApprovalRelasi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call HeaderFg()
    End Sub
    Private Sub HeaderFg()
        Dim txt As CellRange

        With fg
            .Rows.Fixed = 1
            .Cols.Fixed = 1
            .Rows.Count = 1

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

            .AutoSizeCols()
        End With
    End Sub
    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        Dim dt As DataTable = New DataTable
        Dim i As Integer = 1
        Dim sql As String = ""

        sql = " select * from vwMonApprovalRelasi where 1=1"

        If rdBelumApproval.Checked = True Then
            sql &= " and approved=0"
        ElseIf rdApproval1.Checked = True Then
            sql &= " and approved=1"
        ElseIf rdApproval1.Checked = True Then
            sql &= " and approved=2"
        End If

        If chkTgl.Checked = True Then
            sql &= " and (cast(created_at as date) between '" & Format(dtp1.Value, "yyyy-MM-dd") & "' and '" & Format(dtp2.Value, "yyyy-MM-dd") & "')"
        End If

        sql &= " order by created_at desc "

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fg
            .Rows.Count = 1

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "No") = i + 1
                    .Item(i, "IDRelasi") = row("KodeSup").ToString()
                    .Item(i, "NamaRelasi") = row("NamaSup").ToString()
                    .Item(i, "Pancang") = row("Pancang").ToString()
                    .Item(i, "Permintaan") = row("flag").ToString()
                    .Item(i, "AktifNonAktif") = row("Status").ToString()
                    .Item(i, "StatusApproval") = row("StatusApproval").ToString()
                    .Item(i, "CreatedBy") = row("created_by").ToString()
                    .Item(i, "CreatedDate") = row("created_at")
                    .Item(i, "Approval1By") = row("updated_by").ToString()
                    .Item(i, "Approval1Date") = row("updated_at")
                    .Item(i, "Approval2By") = row("updated_by_2").ToString()
                    .Item(i, "Approval2Date") = row("updated_at_2")
                    .Item(i, "Remark") = row("remark").ToString()

                    i += 1
                Next

                .AutoSizeCols()
            Else
                MsgBox("Data tidak ditemukan")
            End If
        End With
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Try
            ' === Cek data ===
            If fg.Rows.Count <= 1 Then
                MsgBox("Data kosong.", vbExclamation)
            End If

            Using save As New SaveFileDialog
                save.Filter = "Excel File (*.xlsx)|*.xlsx"
                save.FileName = "Rekap_Approval_Relasi_" & Format(Now, "yyyyMMdd")

                If save.ShowDialog() = DialogResult.OK Then

                    ' === EXPORT LANGSUNG DARI FLEXGRID ===
                    ' otomatis tidak export kolom Hidden
                    ' pastikan kolom "Select" diset Visible = False di design / code
                    fg.SaveExcel(save.FileName, "Sheet1", FileFlags.IncludeFixedCells)

                    If IO.File.Exists(save.FileName) Then
                        MsgBox("Export berhasil!", vbInformation, "Sukses")
                    Else
                        MsgBox("Export gagal.", vbCritical, "Gagal")
                    End If
                End If
            End Using

        Catch ex As Exception
            MsgBox("Error Export : " & ex.Message, vbCritical)
        End Try
    End Sub
End Class