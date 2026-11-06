Imports C1.Win.C1FlexGrid

Public Class FrmMonBarangInventarisPancang
    Dim dt As DataTable = New DataTable
    Dim txt As CellRange
    Dim bergerak As Integer
    Dim teks As String
    Dim TglAlokasi As Date
    Dim KodeBarang As String
    Dim Keterangan As String
    Dim Pancang As String

    Private Sub FrmMonBarangInventarisPancang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Combo.SetPancang(CmbPancang)
        Combo.InvInventarisMasuk(CmbInventarisMasuk)

        RbAsc.Checked = True
        Call HeaderFG()
    End Sub
    Public Sub HeaderFG()
        With fg
            .Font = New System.Drawing.Font("Century Gothic", 7.0!, System.Drawing.FontStyle.Regular)
            .Cols.Count = 14
            .Cols.Fixed = 1
            .Rows.Count = 2
            '.Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            '.Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleFixedNew.BackColor = Color.PowderBlue 'FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.PowderBlue 'FromArgb(179, 229, 252)
            .Rows(1).StyleFixedNew.BackColor = Color.PowderBlue 'FromArgb(179, 229, 252)
            .Rows(1).StyleNew.BackColor = Color.PowderBlue 'FromArgb(179, 229, 252)

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 2
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 0, 1, 0) : txt.Data = "NO" : .Cols(0).AllowMerging = True : .Cols(0).TextAlign = TextAlignEnum.CenterCenter : .Cols(0).Visible = True : .Cols(0).AllowEditing = False
            txt = .GetCellRange(0, 1, 1, 1) : txt.Data = "Pancang" : .Cols(1).AllowMerging = True : .Cols(1).TextAlign = TextAlignEnum.CenterCenter : .Cols(1).Visible = True : .Cols(1).AllowEditing = False
            txt = .GetCellRange(0, 2, 1, 2) : txt.Data = "Kode Barang" : .Cols(2).AllowMerging = True : .Cols(2).TextAlign = TextAlignEnum.CenterCenter : .Cols(2).Visible = True : .Cols(2).AllowEditing = False
            txt = .GetCellRange(0, 3, 1, 3) : txt.Data = "NAMA BARANG" : .Cols(3).AllowMerging = True : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).Visible = True : .Cols(3).AllowEditing = False
            txt = .GetCellRange(0, 4, 1, 4) : txt.Data = "KATEGORI" : .Cols(4).AllowMerging = True : .Cols(4).TextAlign = TextAlignEnum.CenterCenter : .Cols(4).Visible = True : .Cols(4).AllowEditing = False
            txt = .GetCellRange(0, 5, 1, 5) : txt.Data = "QTY" : .Cols(5).AllowMerging = True : .Cols(5).TextAlign = TextAlignEnum.CenterCenter : .Cols(5).Visible = True : .Cols(5).AllowEditing = False
            txt = .GetCellRange(0, 6, 1, 6) : txt.Data = "SATUAN/UOM" : .Cols(6).AllowMerging = True : .Cols(6).TextAlign = TextAlignEnum.CenterCenter : .Cols(6).Visible = True : .Cols(6).AllowEditing = False
            txt = .GetCellRange(0, 7, 1, 7) : txt.Data = "HARGA/SATUAN" : .Cols(7).AllowMerging = True : .Cols(7).TextAlign = TextAlignEnum.RightCenter : .Cols(7).Format = "#,###0" : .Cols(7).Visible = True : .Cols(7).AllowEditing = False
            txt = .GetCellRange(0, 8, 1, 8) : txt.Data = "Tanggal Alokasi" : .Cols(8).AllowMerging = True : .Cols(8).TextAlign = TextAlignEnum.CenterCenter : .Cols(8).Visible = True : .Cols(8).AllowEditing = False
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "TOTAL" : .Cols(9).AllowMerging = False : .Cols(9).TextAlign = TextAlignEnum.RightCenter : .Cols(9).Format = "#,###0" : .Cols(9).Visible = True : .Cols(9).AllowEditing = False
            txt = .GetCellRange(1, 9, 1, 9) : txt.Data = "TOTAL SEMUA" : .Cols(1).Visible = True : .Cols(10).AllowEditing = False
            txt = .GetCellRange(0, 10, 1, 10) : txt.Data = "KONDISI" : .Cols(10).AllowMerging = True : .Cols(10).TextAlign = TextAlignEnum.CenterCenter : .Cols(10).Visible = True : .Cols(11).AllowEditing = False
            txt = .GetCellRange(0, 11, 1, 11) : txt.Data = "KETERANGAN/PENANGGUNG JAWAB" : .Cols(11).AllowMerging = True : .Cols(11).TextAlign = TextAlignEnum.CenterTop : .Cols(11).Visible = True : .Cols(12).AllowEditing = False
            txt = .GetCellRange(0, 12, 1, 12) : txt.Data = "Inventaris Masuk" : .Cols(12).AllowMerging = True : .Cols(12).TextAlign = TextAlignEnum.CenterTop : .Cols(12).Visible = True : .Cols(12).AllowEditing = False
            txt = .GetCellRange(0, 13, 1, 13) : txt.Data = "Id" : .Cols(13).Visible = False : .Cols(13).AllowEditing = False

            .AutoSizeCols()
        End With
    End Sub
    Private Sub HeaderExcel()
        With fg
            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular)
            .Cols.Count = 12
            .Cols.Fixed = 1
            .Rows.Count = 2
            '.Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            '.Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(1).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(1).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 2
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 1, 1, 1) : txt.Data = "Pancang" : .Cols(1).AllowMerging = True : .Cols(1).TextAlign = TextAlignEnum.CenterCenter : .Cols(1).Visible = False
            txt = .GetCellRange(0, 2, 1, 2) : txt.Data = "Kode Barang" : .Cols(2).AllowMerging = True : .Cols(2).TextAlign = TextAlignEnum.CenterCenter : .Cols(2).Visible = False
            txt = .GetCellRange(0, 8, 1, 8) : txt.Data = "Tanggal Alokasi" : .Cols(8).AllowMerging = True : .Cols(8).TextAlign = TextAlignEnum.CenterCenter : .Cols(8).Visible = False

            .AutoSizeCols()
        End With
    End Sub
    Private Async Sub ShowData()

        Me.Cursor = Cursors.WaitCursor

        Try

            Dim i As Integer = 2
            Dim sql As String = ""
            Dim Total As Decimal = 0

            If CmbPancang.Text <> "" Then
                sql = Func.SetCondition(sql, "a.IdPancang = '" & CmbPancang.SelectedValue & "'")
            End If

            If TxtNamaBarang.Text <> "" Then
                sql = Func.SetCondition(sql, "a.NamaBarang like '%" & TxtNamaBarang.Text & "%'")
            End If

            FG.Rows.Count = 2

            ' 🔥 QUERY DI BACKGROUND THREAD
            dt = Await Task.Run(Function()

                                    If RbAsc.Checked Then

                                        Return DB.ExecuteQuery(StrConnRMPApp, "
                                    select a.*,b.UrutHarga
                                    from RMPApp..vwInv_MonBarangPancang as a
                                    inner join VwInv_UrutanSumPancang as b
                                    on a.Pancang=b.Pancang
                                    where a.NotActived = 0 " &
                                    If(sql = "", "", " AND " & sql) & "
                                    order by b.UrutHarga asc")

                                    Else

                                        Return DB.ExecuteQuery(StrConnRMPApp, "
                                    select a.*,b.UrutHarga
                                    from RMPApp..vwInv_MonBarangPancang as a
                                    inner join VwInv_UrutanSumPancang as b
                                    on a.Pancang=b.Pancang
                                    where a.NotActived = 0 " &
                                    If(sql = "", "", " AND " & sql) & "
                                    order by b.UrutHarga desc")

                                    End If

                                End Function)

            If dt.Rows.Count > 0 Then

                With FG

                    For Each row As DataRow In dt.Rows

                        .AddItem(i - 1)

                        .Item(i, 1) = row("Pancang")
                        .Item(i, 2) = row("KodeBarang")
                        .Item(i, 3) = row("NamaBarang")
                        .Item(i, 4) = row("Kategori")
                        .Item(i, 5) = row("Qty")
                        .Item(i, 6) = row("Satuan")
                        .Item(i, 7) = row("Harga")
                        .Item(i, 8) = row("TglAlokasi")
                        .Item(i, 9) = row("Harga") * row("Qty")
                        .Item(i, 10) = row("Kondisi")
                        .Item(i, 11) = row("PenanggungJawab")
                        .Item(i, 12) = row("InventarisMasuk")
                        .Item(i, 13) = row("Id")

                        Total += Val(.Item(i, 9))

                        i += 1

                    Next

                    ' 🔥 AUTOSIZE SEKALI SAJA
                    .AutoSizeCols()

                    Dim nilaiFormatted As String = String.Format("{0:#,##0}", Total)

                    txt = .GetCellRange(1, 9, 1, 9)
                    txt.Data = nilaiFormatted

                    .Rows(0).StyleNew.TextAlign = TextAlignEnum.CenterCenter

                    GrandTotal()

                    Dim k As Integer = 1

                    For j = 3 To FG.Rows.Count - 1

                        If IsNumeric(FG.Item(j, 0)) Then
                            FG.Item(j, 0) = k
                            k += 1
                        Else
                            k = 1
                        End If

                    Next

                End With

            Else

                If TxtNamaBarang.Text = "" Then
                    MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub TxtNamaBarang_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtNamaBarang.KeyUp
        ShowData()
    End Sub
    Private Sub GrandTotal()
        With FG
            .Tree.Column = 0
            .Tree.Style = TreeStyleFlags.CompleteLeaf
            .Subtotal(AggregateEnum.Clear)
            '.Subtotal(AggregateEnum.Sum, -1, -1, 9, "TOTAL SEMUA")
            .Subtotal(AggregateEnum.Sum, 1, 1, 9, "{0}")

            .AutoSizeCols()
        End With
    End Sub

    Private Sub BtnEdit_Click_1(sender As Object, e As EventArgs)
        txt = FG.GetCellRange(0, 12, 1, 12) : FG.Cols(12).AllowEditing = True
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs)
        With FG
            For i As Integer = 3 To .Rows.Count - 1
                DB.ExecuteScalarValue(Of String)(StrConnRMPApp, "UPDATE TblInv_InventarisBarangPancang SET InventarisMasuk='" & .Item(i, 12) & "' where id='" & .Item(i, 13) & "'")
            Next
        End With
        MsgBox("Update Berhasil")
        txt = FG.GetCellRange(0, 12, 1, 12) : FG.Cols(12).AllowEditing = False
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Call ShowData()
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub BtnExcel_Click(sender As Object, e As EventArgs) Handles BtnExcel.Click
        Dim filename As String
        HeaderExcel()
        ShowData()

        Me.SaveFileDialog.ShowDialog()
        filename = SaveFileDialog.FileName
        Me.FG.SaveExcel(filename & ".xls", "Sheet1", FileFlags.IncludeFixedCells)
        MsgBox("Convert Success !", MsgBoxStyle.Information, AT)

        HeaderFG()
        ShowData()
    End Sub
End Class