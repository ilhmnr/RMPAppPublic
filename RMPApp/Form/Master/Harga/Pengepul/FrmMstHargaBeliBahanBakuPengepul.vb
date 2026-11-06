Imports System.Reflection
Imports C1.Win.C1FlexGrid

Public Class FrmMstHargaBeliBahanBakuPengepul
    Dim Aksi As String = ""
    Private Sub FrmMstHargaPengepul_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Modul_RMP.Combo.SetPancang(cmbPancang)
        Modul_RMP.Combo.SetPancang(cmbPancnagCari)

        btnCancel.PerformClick()

        Call HeaderFg()
    End Sub

    Private Sub HeaderFg()
        Dim txt As CellRange

        With fg
            .Rows.Fixed = 1
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Cols.Count = 14

            .AutoGenerateColumns = True
            .Rows(0).AllowMerging = True
            .Styles.Normal.WordWrap = True

            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular)
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .AllowMerging = AllowMergingEnum.FixedOnly
            .AllowEditing = False

            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

            .Rows(0).TextAlign = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).TextAlign = TextAlignEnum.LeftCenter : .Cols(0).AllowEditing = False : .Cols(0).AllowMerging = True
            .Cols(12).Visible = False
            .Cols(13).Visible = False

            .AutoSizeCols()
        End With
    End Sub


    Private Sub EnabelInput(ByVal bool As Boolean)
        cmbPancang.Enabled = bool
        txtHarga.Enabled = bool
        dtpPeriode.Enabled = bool

        btnAdd.Enabled = bool
        btnEdit.Enabled = bool
        btnDelete.Enabled = bool
        btnSave.Enabled = bool
        btnCancel.Enabled = bool
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        EnabelInput(True)

        cmbPancang.Text = ""
        txtHarga.Text = ""
        dtpPeriode.Value = Now

        btnAdd.Enabled = False
        btnEdit.Enabled = False
        btnDelete.Enabled = False

        fg.Enabled = False

        Aksi = "Add"
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        EnabelInput(True)

        cmbPancang.Enabled = False
        dtpPeriode.Enabled = False

        btnAdd.Enabled = False
        btnEdit.Enabled = False
        btnDelete.Enabled = False

        fg.Enabled = False

        Aksi = "Edit"
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If CInt(DB.ExecuteScalarValue(Of String)(StrConnRMPApp," select isnull((select ID from RMPApp..TblMstHargaPengepul where ID=" & txtID.Text & " and ApprovedBy is not null),0) as GetValueString ")) > 0 Then
            MsgBox("Tidak bisa di delete karena sudah di approve !", vbExclamation, AT)
            Exit Sub
        End If

        db.ExecuteQuery(StrConnRMPApp,"  update RMPApp..TblMstHargaPengepul
                                                        set
                                                        DeletedBy='" & ClsSession.UserID & "',
                                                        DeletedDate=GETDATE(),
                                                        ComputerDeleted=HOST_NAME()
                                                        where ID=" & txtID.Text & " ")

        MsgBox("Delete data berhasil.", vbInformation, AT)

        btnCancel.Enabled = True
        btnCancel.PerformClick()
        btnCari.PerformClick()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If cmbPancang.Text = "" Then
            MsgBox("Pancang belum di input !", vbExclamation, AT)
            Exit Sub
        End If

        If txtHarga.Text = "" Then
            MsgBox("Harga belum di input !", vbExclamation, AT)
            Exit Sub
        End If

        If Aksi = "Add" Then
            If CInt(DB.ExecuteScalarValue(Of String)(StrConnRMPApp," select isnull((select ID from RMPApp..TblMstHargaPengepul where IDPancang=" & cmbPancang.SelectedValue & " and TglPeriode='" & Format(dtpPeriode.Value, "yyyy-MM-dd") & "' and DeletedBy is null),0) as GetValueString ")) > 0 Then
                MsgBox("Harga di periode ini sudah ada !", vbExclamation, AT)
                Exit Sub
            End If

            db.ExecuteQuery(StrConnRMPApp,"  insert into RMPApp..TblMstHargaPengepul 
                                                            (IDPancang,Harga,TglPeriode,CreatedBy,CreatedDate,ComputerCreated)
                                                            values 
                                                            (" & cmbPancang.SelectedValue & "," & Trim(txtHarga.Text) & ",'" & Format(dtpPeriode.Value, "yyyy-MM-dd") & "','" & ClsSession.UserID & "',GETDATE(),HOST_NAME()) ")
        Else
            db.ExecuteQuery(StrConnRMPApp,"  update RMPApp..TblMstHargaPengepul
                                                            set 
                                                            IDPancang=" & cmbPancang.SelectedValue & ",
                                                            Harga=" & Trim(txtHarga.Text) & ",
                                                            TglPeriode='" & Format(dtpPeriode.Value, "yyyy-MM-dd") & "',
                                                            UpdatedBy='" & ClsSession.UserID & "',
                                                            UpdatedDate=GETDATE(),
                                                            ComputerUpdated=HOST_NAME()
                                                            where ID=" & txtID.Text & " ")
        End If

        MsgBox("Save data berhasil.", vbInformation, AT)

        btnCancel.PerformClick()
        btnCari.PerformClick()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        EnabelInput(True)

        cmbPancang.Text = ""
        txtHarga.Text = ""
        dtpPeriode.Value = Now

        cmbPancang.Enabled = False
        txtHarga.Enabled = False
        dtpPeriode.Enabled = False

        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnSave.Enabled = False
        btnCancel.Enabled = False

        fg.Enabled = True

        Aksi = ""
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        Me.Cursor = Cursors.WaitCursor
        Call loadData()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub loadData()
        Dim dt As DataTable = New DataTable
        Dim i As Integer = 1
        Dim sql As String = ""

        sql = " select a.*,b.Pancang from RMPApp..TblMstHargaPengepul as a inner join 
                RMPApp..Android_tblMstPancang as b on a.IDPancang=b.IDPancang 
                where cast(a.CreatedDate as date) between cast('" & Format(dtpCari1.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(dtpCari2.Value, "yyyy-MM-dd") & "' as date) "

        If chkAllData.Checked = False Then
            sql &= " and DeletedBy is null "
        End If

        If cmbPancnagCari.Text <> "" Then
            sql &= " and a.IDPancang=" & cmbPancnagCari.SelectedValue & " "
        End If

        sql &= " order by a.CreatedDate desc "

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fg
            .Rows.Count = 1

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, 1) = row("Pancang")
                    .Item(i, 2) = row("TglPeriode")
                    .Item(i, 3) = row("Harga")
                    .Item(i, 4) = row("CreatedBy")
                    .Item(i, 5) = row("CreatedDate")
                    .Item(i, 6) = row("UpdatedBy")
                    .Item(i, 7) = row("UpdatedDate")
                    .Item(i, 8) = row("DeletedBy")
                    .Item(i, 9) = row("DeletedDate")
                    .Item(i, 10) = row("ApprovedBy")
                    .Item(i, 11) = row("ApprovedDate")
                    .Item(i, 12) = row("ID")
                    .Item(i, 13) = row("IDPancang")

                    If Not IsDBNull(row("DeletedBy")) OrElse row("DeletedBy").ToString() <> "" Then
                        .Rows(i).StyleNew.BackColor = Color.FromArgb(255, 192, 192)
                        .Rows(i).StyleNew.ForeColor = Color.Black
                    End If

                    i += 1
                Next

                .AutoSizeCols()
            End If
        End With
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click
        With fg
            If .Rows.Count > 1 Then
                If (IsDBNull(.Item(.RowSel, 8)) OrElse .Item(.RowSel, 8).ToString() = "") And (IsDBNull(.Item(.RowSel, 10)) OrElse .Item(.RowSel, 10).ToString() = "") Then
                    cmbPancang.SelectedValue = .Item(.RowSel, 13)
                    cmbPancang.Text = .Item(.RowSel, 1)
                    txtHarga.Text = .Item(.RowSel, 3)
                    dtpPeriode.Value = .Item(.RowSel, 2)
                    txtID.Text = .Item(.RowSel, 12)

                    If cmbPancang.Text <> "" Then
                        btnAdd.Enabled = True
                        btnEdit.Enabled = True
                        btnDelete.Enabled = True
                        btnSave.Enabled = False
                        btnCancel.Enabled = False
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub txtHarga_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHarga.KeyPress
        ' Hanya izinkan angka, tombol Backspace, dan titik desimal
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then
            e.Handled = True
        End If

        ' Cegah lebih dari satu titik desimal
        If e.KeyChar = "."c AndAlso CType(sender, TextBox).Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub FrmMstHargaPengepul_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim topColor As Color = Color.FromArgb(0, 172, 251) ' Warna atas yang tebal
        Dim bottomColor As Color = Color.FromArgb(0, 0, 255, 255) ' Warna bawah yang pudar

        Dim gradientRect As New Rectangle(0, 0, Me.Width, Me.Height)

        Try
            Using brush As New Drawing2D.LinearGradientBrush(gradientRect, topColor, bottomColor, Drawing2D.LinearGradientMode.Vertical)
                e.Graphics.FillRectangle(brush, gradientRect)
            End Using
        Catch ex As Exception

        End Try
    End Sub
End Class