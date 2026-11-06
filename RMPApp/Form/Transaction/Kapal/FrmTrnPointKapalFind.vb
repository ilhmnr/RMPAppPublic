Imports System.Web
Imports C1.Win.C1FlexGrid

Public Class FrmTrnPointKapalFind
    Dim txt As CellRange
    Private Sub FrmTrnPointKapalfind_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call HeaderFG()
        Call showdata()

        DTPStart.Value = Now
        DTPEnd.Value = Now
        dt1.Value = Now
    End Sub
    Public Sub HeaderFG()
        With fg
            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
            .Cols.Count = 9
            .Rows.Count = 1
            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).AllowMerging = True
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 1
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).AllowMerging = False : .Cols(0).TextAlign = TextAlignEnum.CenterCenter : .Cols(0).AllowEditing = False
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "No Invoice" : .Cols(1).AllowMerging = False : .Cols(1).TextAlign = TextAlignEnum.LeftCenter : .Cols(1).AllowEditing = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Tanggal Invoice" : .Cols(2).AllowMerging = False : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).AllowEditing = False
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Star DoDate" : .Cols(3).AllowMerging = False : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).AllowEditing = False
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "End DoDate" : .Cols(4).AllowMerging = False : .Cols(4).TextAlign = TextAlignEnum.LeftCenter : .Cols(4).AllowEditing = False
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "CreatedBy" : .Cols(5).AllowMerging = False : .Cols(5).TextAlign = TextAlignEnum.LeftCenter : .Cols(5).AllowEditing = False
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "CreatedDate" : .Cols(6).AllowMerging = False : .Cols(6).TextAlign = TextAlignEnum.LeftCenter : .Cols(6).AllowEditing = False
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Detail Data" : .Cols(7).AllowMerging = False : .Cols(7).TextAlign = TextAlignEnum.LeftCenter : .Cols(7).AllowEditing = False
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Restor" : .Cols(8).AllowMerging = False : .Cols(8).TextAlign = TextAlignEnum.LeftCenter : .Cols(8).AllowEditing = False

            .AutoSizeCols()
        End With
    End Sub
    Private Sub showdata()
        Me.Cursor = Cursors.WaitCursor

        Dim i As Integer = 1
        Dim sql As String = ""
        Dim dt As DataTable = New DataTable

        If chkDoDate.Checked = True Then
            sql = Modul_RMP.Func.SetCondition(sql, " cast(TanggalInvoice as date) = cast('" & Format(dt1.Value, "yyyy-MM-dd") & "' as date) ")
        End If

        If chkTransDate.Checked = True Then
            sql = Modul_RMP.Func.SetCondition(sql, " (cast(DoDateStar as date) >= cast('" & Format(DTPStart.Value, "yyyy-MM-dd") & "' as date) and cast(DoDateEnd as date) <= cast('" & Format(DTPEnd.Value, "yyyy-MM-dd") & "' as date)) ")
        End If

        If chknoinvoice.Checked = True Then
            sql = Modul_RMP.Func.SetCondition(sql, "NoTransPointKapal like '%" & txtinvoice.Text & "%'")
        End If

        Try
            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select * from TblTrnHitungPointKapalHdr where 1=1 and approval=0  " & IIf(sql = "", "", " AND " & sql) & " order by TanggalInvoice desc ")
            If dt.Rows.Count > 0 Then
                With fg
                    .Rows.Count = dt.Rows.Count + 1
                    For Each row As DataRow In dt.Rows
                        Dim sum As Double = 0

                        .Item(i, 0) = i
                        .Item(i, 1) = row.Item("NoTransPointKapal")
                        .Item(i, 2) = row.Item("TanggalInvoice")
                        .Item(i, 3) = row.Item("DoDateStar")
                        .Item(i, 4) = row.Item("DoDateEnd")
                        .Item(i, 5) = row.Item("CreatedBy")
                        .Item(i, 6) = row.Item("CreatedDate")

                        ' Mendefinisikan gaya sel
                        Dim style As C1.Win.C1FlexGrid.CellStyle = Me.fg.Styles.Add("style")
                        style.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
                        Me.fg.SetCellImage(i, 7, My.Resources.find20)
                        Me.fg.SetCellStyle(i, 7, style)
                        Dim style1 As C1.Win.C1FlexGrid.CellStyle = Me.fg.Styles.Add("style")
                        style1.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
                        Me.fg.SetCellImage(i, 8, My.Resources.icons8_restart_20)
                        Me.fg.SetCellStyle(i, 8, style1)

                        i += 1
                        .AutoSizeCols()
                    Next
                End With
                Me.Cursor = Cursors.Default
            Else
                MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
                Me.Cursor = Cursors.Default
            End If
        Catch EX As Exception
            MsgBox(EX.Message)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnrefreshh_Click(sender As Object, e As EventArgs) Handles btnrefreshh.Click
        Call HeaderFG()
        Call showdata()
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click
        With fg
            If .Rows.Count > 1 Then
                If .Col = 8 Then
                    Call RestorData()
                ElseIf .Col = 7 Then
                    FrmTrnPointKapal.NotransPointKapal = Trim(.Item(.Row, 1))
                    FrmTrnPointKapal.dtpstart = .Item(.Row, 3)
                    FrmTrnPointKapal.dtpend = .Item(.Row, 4)
                    FrmTrnPointKapal.ShowDialog()
                End If
            End If
        End With
    End Sub
    Private Sub RestorData()
        Dim dt As DataTable = New DataTable
        Dim YesNo As String
        YesNo = MsgBox("Yakin Data Dengan No Invoice '" & fg.Item(fg.Row, 1) & "' Akan Di Restor !!", vbYesNo, AT)
        If YesNo = vbNo Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "  update tblTrnDoHdr set FlagSavePoinKapal=null,NoTransPoinKapal=null where NoTransPoinKapal='" & fg.Item(fg.Row, 1) & "'
                                                                          delete TblTrnHitungPointKapalDtl where NoTransPointKapal='" & fg.Item(fg.Row, 1) & "'
                                                                          delete TblTrnHitungPointKapalHdr where NoTransPointKapal='" & fg.Item(fg.Row, 1) & "'")
        MsgBox("Restor Berhasil !", vbInformation, AT)
        HeaderFG()
        showdata()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        FrmTrnPointKapal.NotransPointKapal = ""
        FrmTrnPointKapal.Show()
    End Sub
End Class