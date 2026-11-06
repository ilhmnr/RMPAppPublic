Imports C1.Win.C1FlexGrid
Imports Syncfusion.Pdf

Public Class FrmMonWoPancang


    Private Sub HeaderFg()
        Dim TXT As CellRange
        With fg
            .Rows.Fixed = 2
            .Cols.Fixed = 1
            .Rows.Count = 2
            .Cols.Count = 16

            .AutoGenerateColumns = True
            .Rows(0).AllowMerging = True
            .Rows(1).AllowMerging = True
            .Styles.Normal.WordWrap = True

            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular)
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .AllowMerging = AllowMergingEnum.FixedOnly

            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

            .Rows(0).TextAlign = TextAlignEnum.CenterCenter

            TXT = .GetCellRange(0, 0, 1, 0) : TXT.Data = "NO" : .Cols(0).TextAlign = TextAlignEnum.LeftCenter : .Cols(0).AllowEditing = False : .Cols(0).AllowMerging = True
            TXT = .GetCellRange(0, 1, 1, 1) : TXT.Data = "NAMA PROYEK / WO" : .Cols(1).TextAlign = TextAlignEnum.LeftCenter : .Cols(1).AllowEditing = False : .Cols(1).AllowMerging = True
            TXT = .GetCellRange(0, 2, 1, 2) : TXT.Data = "PANCANG" : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).AllowEditing = False : .Cols(2).AllowMerging = True
            TXT = .GetCellRange(0, 3, 1, 3) : TXT.Data = "PLAKSANA (MANDIRI / KONTRAKTOR)" : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).AllowEditing = False : .Cols(3).AllowMerging = True
            TXT = .GetCellRange(0, 4, 1, 4) : TXT.Data = "JENIS WO" : .Cols(4).TextAlign = TextAlignEnum.LeftCenter : .Cols(4).AllowEditing = False : .Cols(4).AllowMerging = True
            TXT = .GetCellRange(0, 5, 1, 5) : TXT.Data = "STATUS WO" : .Cols(5).TextAlign = TextAlignEnum.LeftCenter : .Cols(5).AllowEditing = False : .Cols(5).AllowMerging = True
            TXT = .GetCellRange(0, 6, 0, 9) : TXT.Data = "STATUS UPDATE" : .Cols(6).TextAlign = TextAlignEnum.LeftCenter : .Cols(6).AllowEditing = False
            TXT = .GetCellRange(1, 6, 1, 6) : TXT.Data = "LAST UPDATE" : .Cols(6).TextAlign = TextAlignEnum.LeftCenter : .Cols(6).AllowEditing = False : .Cols(6).AllowMerging = True
            TXT = .GetCellRange(1, 7, 1, 7) : TXT.Data = "PIC" : .Cols(7).TextAlign = TextAlignEnum.LeftCenter : .Cols(7).AllowEditing = False : .Cols(7).AllowMerging = True
            TXT = .GetCellRange(1, 8, 1, 8) : TXT.Data = "ON GOING PROCESS" : .Cols(8).TextAlign = TextAlignEnum.LeftCenter : .Cols(8).AllowEditing = False : .Cols(8).AllowMerging = True
            TXT = .GetCellRange(1, 9, 1, 9) : TXT.Data = "PIC" : .Cols(9).TextAlign = TextAlignEnum.LeftCenter : .Cols(9).AllowEditing = False : .Cols(9).AllowMerging = True
            TXT = .GetCellRange(0, 10, 1, 10) : TXT.Data = "PERSENTASE PROYEK" : .Cols(10).TextAlign = TextAlignEnum.CenterCenter : .Cols(10).AllowEditing = False : .Cols(10).AllowMerging = True
            TXT = .GetCellRange(0, 11, 0, 13) : TXT.Data = "TIMELINE WAKTU" : .Cols(11).TextAlign = TextAlignEnum.LeftCenter : .Cols(11).AllowEditing = False
            TXT = .GetCellRange(1, 11, 1, 11) : TXT.Data = "INPUT WO" : .Cols(11).TextAlign = TextAlignEnum.LeftCenter : .Cols(11).AllowEditing = False : .Cols(11).AllowMerging = True
            TXT = .GetCellRange(1, 12, 1, 12) : TXT.Data = "LAST UPDATE" : .Cols(12).TextAlign = TextAlignEnum.LeftCenter : .Cols(12).AllowEditing = False : .Cols(12).AllowMerging = True
            TXT = .GetCellRange(1, 13, 1, 13) : TXT.Data = "VERSI WEEK" : .Cols(13).TextAlign = TextAlignEnum.LeftCenter : .Cols(13).AllowEditing = False : .Cols(13).AllowMerging = True
            TXT = .GetCellRange(0, 14, 1, 14) : TXT.Data = "DETAIL PROJECT" : .Cols(14).TextAlign = TextAlignEnum.LeftCenter : .Cols(14).AllowEditing = False : .Cols(14).AllowMerging = True
            TXT = .GetCellRange(0, 15, 0, 15) : TXT.Data = "ID" : .Cols(15).Visible = False

            .AutoSizeCols()
        End With
    End Sub

    Private Sub FrmMonWoPancang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtp1.Value = Now
        dtp2.Value = Now

        Modul_RMP.Combo.SetPancang(cmbPancang)

        Call HeaderFg()
        Call showData()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Call showData()
    End Sub

    Private Sub showData()
        Dim i As Integer = 2
        Dim dt As DataTable = New DataTable
        Dim query As String

        Try
            query = "   select b.judul as nama_proyek,c.Pancang as pancang,iif(b.proyek_mandiri=1,'Mandiri','Kontraktor') as pelaksana,
                        case when b.jenis_wo =1 then 'Proyek' when b.jenis_wo =2 then 'Relokasi Baru' when b.jenis_wo =3 then 'Perbaikan' end as jenis_wo,
                        case when b.prioritas =1 then 'Prioritas 1' when b.prioritas=2 then 'Prioritas 2' when b.prioritas=3 then 'Prioritas 3' else '' end as Prioritas,
                        a.inprogress,isnull(d.NamaLengkap,a.inprogress_by) as inprogress_by,a.upcoming,isnull(e.NamaLengkap,a.upcoming_by) as upcoming_by,replace(CAST(a.percent_work as varchar(3))+'%',' ','') as percent_work,b.created_date,a.updated_date,CAST(count_week as varchar(3))+' minggu' as count_week,b.id
                        from tbl_wo_trn_marker as a left outer join
                        tbl_wo_trn_hdr as b on a.wo_id=b.id	left outer join 
                        Android_tblMstPancang as c on b.pancang_id=c.IDPancang left outer join 
                        PancangRequestUser as d on a.inprogress_by=d.Username left outer join 
                        PancangRequestUser as e on a.upcoming_by=e.Username
                        where b.deleted=0 "

            If txtNamaProyek.Text <> "" Then
                query &= " and b.judul like '%" & txtNamaProyek.Text & "%' "
            End If

            If cmbPancang.SelectedValue <> Nothing Then
                query &= " and b.pancang_id=" & cmbPancang.SelectedValue & " "
            End If

            If chkTanggal.Checked Then
                query &= " and (cast(b.created_date as date) between cast('" & Format(dtp1.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(dtp2.Value, "yyyy-MM-dd") & "' as date)) "
            End If

            query &= " order by b.created_date asc "

            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, query)

            fg.Rows.Count = 2
            If dt.Rows.Count > 0 Then
                With fg
                    For Each row As DataRow In dt.Rows
                        .AddItem(i - 1)
                        .Item(i, 1) = row("nama_proyek")
                        .Item(i, 2) = row("pancang")
                        .Item(i, 3) = row("pelaksana")
                        .Item(i, 4) = row("jenis_wo")
                        .Item(i, 5) = row("prioritas")
                        .Item(i, 6) = row("inprogress")
                        .Item(i, 7) = row("inprogress_by")
                        .Item(i, 8) = row("upcoming")
                        .Item(i, 9) = row("upcoming_by")
                        .Item(i, 10) = row("percent_work")
                        .Item(i, 11) = row("created_date")
                        .Item(i, 12) = row("updated_date")
                        .Item(i, 13) = row("count_week")

                        Dim style As C1.Win.C1FlexGrid.CellStyle = .Styles.Add("style")
                        style.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
                        .SetCellImage(i, 14, My.Resources.Doc1)
                        .SetCellStyle(i, 14, style)

                        .Item(i, 15) = row("id")

                        If row("upcoming") = "DONE" Then
                            .Rows(i).StyleNew.ForeColor = Color.Blue
                        End If

                        i += 1
                    Next
                    .AutoSizeCols()
                End With
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fg_DoubleClick(sender As Object, e As EventArgs) Handles fg.DoubleClick
        If fg.Rows.Count > 2 And fg.Col = 14 Then
            If Application.OpenForms.OfType(Of FrmMonWoPancangDtl)().Any() Then
                Dim Frm As FrmMonWoPancangDtl = Application.OpenForms.OfType(Of FrmMonWoPancangDtl)().FirstOrDefault()
                Frm.Close()
            End If

            With FrmMonWoPancangDtl
                .txtWoId.Text = fg.Item(fg.RowSel, 15)
                .lblNamaWo.Text = fg.Item(fg.RowSel, 1)

                Select Case fg.Item(fg.RowSel, 4)
                    Case "Proyek"
                        .lblRelokasiBaru.ForeColor = Color.Gray
                        .lblPerbaikan.ForeColor = Color.Gray
                    Case "Relokasi Baru"
                        .lblPerbaikan.ForeColor = Color.Gray
                        .lblProyek.ForeColor = Color.Gray
                    Case "Perbaikan"
                        .lblRelokasiBaru.ForeColor = Color.Gray
                        .lblProyek.ForeColor = Color.Gray
                End Select

                Select Case fg.Item(fg.RowSel, 5)
                    Case "Prioritas 1"
                        .lblPrioritas2.ForeColor = Color.Gray
                        .lblPrioritas3.ForeColor = Color.Gray
                    Case "Prioritas 2"
                        .lblPrioritas1.ForeColor = Color.Gray
                        .lblPrioritas3.ForeColor = Color.Gray
                    Case "Prioritas 3"
                        .lblPrioritas1.ForeColor = Color.Gray
                        .lblPrioritas2.ForeColor = Color.Gray
                    Case ""
                        .lblPrioritas1.ForeColor = Color.Gray
                        .lblPrioritas2.ForeColor = Color.Gray
                        .lblPrioritas3.ForeColor = Color.Gray
                End Select

                .lblStatusUpdate.Text = fg.Item(fg.RowSel, 6)
                .dtp1.Value = fg.Item(fg.RowSel, 11)
                .dtp2.Value = fg.Item(fg.RowSel, 12)
                .lblVersiWeek.Text = fg.Item(fg.RowSel, 13)
                .lblPersentaseProyek.Text = fg.Item(fg.RowSel, 10)
                .showData()
                .Show()
            End With
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Try
            Dim topColor As Color = Color.FromArgb(0, 172, 251) ' Warna atas yang tebal
            Dim bottomColor As Color = Color.FromArgb(0, 0, 255, 255) ' Warna bawah yang pudar

            Dim gradientRect As New Rectangle(0, 0, Panel1.Width, Panel1.Height)

            Using brush As New Drawing2D.LinearGradientBrush(gradientRect, topColor, bottomColor, Drawing2D.LinearGradientMode.Vertical)
                e.Graphics.FillRectangle(brush, gradientRect)
            End Using
        Catch ex As Exception

        End Try
    End Sub

End Class