Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports Spire.Pdf.HtmlConverter

Public Class FrmTrnRestoreBarangMasuk
    Private Sub FrmTrnRestoreBarangMasuk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DtpStart.Value = New Date(DateTime.Now.Year, DateTime.Now.Month, 1)
        DtpEnd.Value = New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month))

        fg.Rows.Count = 1
        Call SetHeaderFg()
    End Sub
    Public Sub SetHeaderFg()
        Dim txt As CellRange
        Dim i As Integer = 0

        With fg
            .AutoGenerateColumns = True
            .Font = New System.Drawing.Font("Century Gothic", 7.0!, System.Drawing.FontStyle.Regular)
            .Cols.Count = 11
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Styles.Fixed.BackColor = Color.PowderBlue
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleFixedNew.BackColor = Color.PowderBlue
            .Rows(0).StyleNew.BackColor = Color.PowderBlue

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 1
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

            For i = 0 To 8
                '0
                txt = .GetCellRange(0, i, 0, i) : txt.Data = "No" : .Cols(i).TextAlign = TextAlignEnum.LeftCenter : .Cols(i).AllowEditing = False
                i += 1
                txt = .GetCellRange(0, i, 0, i) : txt.Data = "Restore" : .Cols(i).TextAlign = TextAlignEnum.CenterCenter : .Cols(i).AllowEditing = True
                i += 1
                txt = .GetCellRange(0, i, 0, i) : txt.Data = "Kode Transaksi" : .Cols(i).TextAlign = TextAlignEnum.LeftCenter : .Cols(i).AllowEditing = False
                i += 1
                txt = .GetCellRange(0, i, 0, i) : txt.Data = "Kode Barang" : .Cols(i).TextAlign = TextAlignEnum.LeftCenter : .Cols(i).AllowEditing = False
                i += 1
                txt = .GetCellRange(0, i, 0, i) : txt.Data = "Nama Barang" : .Cols(i).TextAlign = TextAlignEnum.LeftCenter : .Cols(i).AllowEditing = False
                i += 1
                txt = .GetCellRange(0, i, 0, i) : txt.Data = "Harga Satuan" : .Cols(i).TextAlign = TextAlignEnum.RightCenter : .Cols(i).Format = "#,###0" : .Cols(i).AllowEditing = False
                i += 1
                txt = .GetCellRange(0, i, 0, i) : txt.Data = "Tanggal Transaksi" : .Cols(i).TextAlign = TextAlignEnum.CenterCenter : .Cols(i).AllowEditing = False
                i += 1
                txt = .GetCellRange(0, i, 0, i) : txt.Data = "Qty" : .Cols(i).TextAlign = TextAlignEnum.RightCenter : .Cols(i).Format = "#,###0" : .Cols(i).AllowEditing = False
                i += 1
                txt = .GetCellRange(0, i, 0, i) : txt.Data = "Remark" : .Cols(i).TextAlign = TextAlignEnum.LeftCenter : .Cols(i).AllowEditing = False
                i += 1
                txt = .GetCellRange(0, i, 0, i) : txt.Data = "Created By" : .Cols(i).TextAlign = TextAlignEnum.LeftCenter : .Cols(i).AllowEditing = False
                i += 1
                txt = .GetCellRange(0, i, 0, i) : txt.Data = "Created Date" : .Cols(i).TextAlign = TextAlignEnum.CenterCenter : .Cols(i).AllowEditing = False
            Next

            .AutoSizeCols()
        End With
    End Sub

    Private Sub BtnCari_Click(sender As Object, e As EventArgs) Handles BtnCari.Click
        Call ShowData()
    End Sub

    Public Sub ShowData()
        Me.Cursor = Cursors.WaitCursor

        Dim dt As DataTable = New DataTable

        dt = DB.ExecuteQuery(StrConnRMPApp, "select * from RMPApp..vwInv_RestoreBarangBPB where (cast(TransDate as date) between cast('" & Format(DtpStart.Value, "yyyy/MM/dd") & "' as date) and cast('" & Format(DtpEnd.Value, "yyyy/MM/dd") & "' as date)) order by TransDate Desc")

        fg.Rows.Count = 1

        If dt.Rows.Count > 0 Then
            Dim i As Integer = 1

            For Each Row As DataRow In dt.Rows
                With fg
                    .AddItem(i)
                    .Item(i, 2) = Row("KodeTransBPB")
                    .Item(i, 3) = Row("KodeBarangBPB")
                    .Item(i, 4) = Row("NamaBarang")
                    .Item(i, 5) = Row("UnitPrice")
                    .Item(i, 6) = Row("TransDate")
                    .Item(i, 7) = Row("Qty")
                    .Item(i, 8) = Row("Remark")
                    .Item(i, 9) = Row("CreatedBy")
                    .Item(i, 10) = Row("CreatedDate")
                End With

                i += 1
            Next

            fg.AutoSizeCols()
        Else
            MsgBox("Tidak Ada Data !", vbInformation, AT)
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Me.Cursor = Cursors.WaitCursor

        Dim FlagAdaDataYangDiPilih As Integer = 0

        If fg.Rows.Count > 1 Then
            For i = 1 To fg.Rows.Count - 1
                If fg.Item(i, 1) = True Then
                    FlagAdaDataYangDiPilih = 1
                End If
            Next

            If FlagAdaDataYangDiPilih = 0 Then
                MsgBox("Tidak Ada Data Yang Di Pilih.", vbInformation, AT)
                Me.Cursor = Cursors.Default
                Exit Sub
            Else
                For i = 1 To fg.Rows.Count - 1
                    If fg.Item(i, 1) = True Then
                        DB.ExecuteScalarValue(Of String)(StrConnRMPApp, "update RMPApp..TblInv_TrnBarangTerinputBPB set FlagSudahInput=0 where KodeTransBPB='" & fg.Item(i, 2) & "' and KodeBarangBPB='" & fg.Item(i, 3) & "' and UnitPrice='" & fg.Item(i, 5) & "0000'and TransDate=cast('" & Format(CDate(fg.Item(i, 6)), "yyyy-MM-dd") & "' as date) and qty='" & fg.Item(i, 7) & "0000'")
                    End If
                Next
            End If

            Call ShowData()
            MsgBox("Restore Berhasil.", vbInformation, AT)
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub FrmTrnRestoreBarangMasuk_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Func.ControlCentreForm(Me, PanelForm)
    End Sub
End Class