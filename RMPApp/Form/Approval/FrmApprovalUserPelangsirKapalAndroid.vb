Imports System.Xml
Imports C1.Win.C1FlexGrid

Public Class FrmApprovalUserPelangsirKapalAndroid
    Private Sub FrmApprovalUserPelangsirKapalAndroid_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        headerFg()
        loadData()
    End Sub

    Private Sub headerFg()
        Dim txt As CellRange
        With fg
            .AutoGenerateColumns = True
            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular)
            .Cols.Count = 9
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

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).TextAlign = TextAlignEnum.LeftCenter : .Cols(0).AllowEditing = False
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Pilih" : .Cols(1).TextAlign = TextAlignEnum.LeftCenter : .Cols(1).AllowEditing = True
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Nama User" : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).AllowEditing = False
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Nama Kapal" : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).AllowEditing = False
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Alamat Kapal" : .Cols(4).TextAlign = TextAlignEnum.LeftCenter : .Cols(4).AllowEditing = False
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Tujuan Kapal" : .Cols(5).TextAlign = TextAlignEnum.LeftCenter : .Cols(5).AllowEditing = False
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Approval By" : .Cols(6).TextAlign = TextAlignEnum.LeftCenter : .Cols(6).AllowEditing = False
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Approval Date" : .Cols(7).TextAlign = TextAlignEnum.LeftCenter : .Cols(7).AllowEditing = False
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Detail Id" : .Cols(8).Visible = False

            .AutoSizeCols()
        End With
    End Sub

    Private Sub loadData()
        Dim dt As DataTable = New DataTable
        Dim status As Integer = 0
        Dim i As Integer = 1

        fg.Cols(1).Visible = False
        fg.Cols(6).Visible = False
        fg.Cols(7).Visible = False

        btnApproval.Enabled = False
        btnReject.Enabled = False

        If rdNoStatus.Checked = True Then
            status = 0
            fg.Cols(1).Visible = True
            btnApproval.Enabled = True
            btnReject.Enabled = True
        ElseIf rdApproval.Checked = True Then
            status = 1
            fg.Cols(6).Visible = True
            fg.Cols(7).Visible = True
        ElseIf rdReject.Checked = True Then
            status = 2
        End If

        dt = Modul_RMP.Cls_Connection.SqlSelect_PCGP1(" select DetailID,UserName,NamaKapal,AlamatKapal,TujuanKapal,approve_by,approve_date from tblAndroidUser where GroupID=10 and approve_user=" & status & " and UserName is not null " & IIf(txtNama.Text = "", "", " and UserName like '%" & txtNama.Text & "%' ") & " order by UserName asc ")

        fg.Rows.Count = 1
        If dt.Rows.Count > 0 Then
            With fg
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, 2) = row("UserName")
                    .Item(i, 3) = row("NamaKapal")
                    .Item(i, 4) = row("AlamatKapal")
                    .Item(i, 5) = row("TujuanKapal")
                    .Item(i, 6) = row("approve_by")
                    .Item(i, 7) = row("approve_date")
                    .Item(i, 8) = row("DetailID")

                    i += 1
                Next

                .AutoSizeCols()
            End With
        End If
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        loadData()
    End Sub

    Private Sub btnApproval_Click(sender As Object, e As EventArgs) Handles btnApproval.Click
        Dim ada As Integer = 0

        If fg.Rows.Count > 1 Then
            For i = 1 To fg.Rows.Count - 1
                If fg.Item(i, 1) = True Then
                    ada = 1
                End If
            Next

            If ada = 1 Then
                For i = 1 To fg.Rows.Count - 1
                    If fg.Item(i, 1) = True Then
                        Modul_RMP.Cls_Connection.SqlSelect_PCGP1(" update PSGRMP..tblAndroidUser set approve_user=1,approve_by='" & FrmMenuNew.UserName & "',approve_date=getdate() where DetailID='" & fg.Item(i, 8) & "' ")
                    End If
                Next

                loadData()
                MsgBox("Approval Berhasil", vbExclamation, AT)
            Else
                MsgBox("Tidak Ada Data Yang Di Pilih", vbExclamation, AT)
            End If
        End If
    End Sub

    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        Dim ada As Integer = 0

        If fg.Rows.Count > 1 Then
            For i = 1 To fg.Rows.Count - 1
                If fg.Item(i, 1) = True Then
                    ada = 1
                End If
            Next

            If ada = 1 Then
                For i = 1 To fg.Rows.Count - 1
                    If fg.Item(i, 1) = True Then
                        Modul_RMP.Cls_Connection.SqlSelect_PCGP1(" update PSGRMP..tblAndroidUser set approve_user=2,approve_by='" & FrmMenuNew.UserName & "',approve_date=getdate() where DetailID='" & fg.Item(i, 8) & "' ")
                    End If
                Next

                loadData()
                MsgBox("Reject Berhasil", vbExclamation, AT)
            Else
                MsgBox("Tidak Ada Data Yang Di Pilih", vbExclamation, AT)
            End If
        End If
    End Sub

    Private Sub rdNoStatus_CheckedChanged(sender As Object, e As EventArgs) Handles rdNoStatus.CheckedChanged
        loadData()
    End Sub

    Private Sub rdApproval_CheckedChanged(sender As Object, e As EventArgs) Handles rdApproval.CheckedChanged
        loadData()
    End Sub

    Private Sub rdReject_CheckedChanged(sender As Object, e As EventArgs) Handles rdReject.CheckedChanged
        loadData()
    End Sub
End Class