
Imports System.ComponentModel
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient

Public Class FrmMonKapalSusust

#Region "Helper"

    Private Function SqlText(value As String) As String
        Return "'" & value.Replace("'", "''") & "'"
    End Function

    Private Function GetValue(row As DataRow, column As String) As Object
        If IsDBNull(row(column)) Then Return ""
        Return row(column)
    End Function

    Private Function GetNumber(row As DataRow, column As String) As Decimal
        If IsDBNull(row(column)) Then Return 0D
        Return Convert.ToDecimal(row(column))
    End Function

    Private Function GetPercent(nilai As Decimal, total As Decimal) As Decimal
        If total = 0D Then Return 0D
        Return Math.Round(nilai / total * 100D, 2)
    End Function

#End Region

#Region "Form Load"

    Private Sub FrmMonDONew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DoDate1.Value = Now
        DoDate2.Value = Now

        Modul_RMP.Combo.SetPancang(cmbPancang)
        Modul_RMP.Combo.SetKapal(cmbKapal)
        Modul_RMP.Combo.SetJenis(cbojenis)
        Modul_RMP.Combo.SetDERMAGA(cbodermaga)

        HeaderFGKg()
        schKg()

        rdAll.Checked = True
        chkDO.Checked = True

    End Sub

#End Region

#Region "Show Data"

    Private Sub ShowData()

        Cursor = Cursors.WaitCursor

        Try

            Dim sql As String = ""

            If chkPancang.Checked AndAlso cmbPancang.SelectedValue IsNot Nothing Then
                sql = Modul_RMP.Func.SetCondition(
                    sql,
                    "IDPancang = " & SqlText(cmbPancang.SelectedValue.ToString())
                )
            End If

            If chkJenisKB.Checked AndAlso cbojenis.Text <> "" Then
                sql = Modul_RMP.Func.SetCondition(
                    sql,
                    "JenisKelapa = " & SqlText(cbojenis.Text)
                )
            End If

            If chkKapal.Checked AndAlso cmbKapal.SelectedValue IsNot Nothing Then
                sql = Modul_RMP.Func.SetCondition(
                    sql,
                    "IDkapal = " & SqlText(cmbKapal.SelectedValue.ToString())
                )
            End If

            ShowDataKg(sql)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub ShowDataKg(ByVal sql As String)

        Try

            Dim dt As New DataTable

            Dim tgl1 As String = Format(DoDate1.Value, "yyyy-MM-dd")
            Dim tgl2 As String = Format(DoDate2.Value, "yyyy-MM-dd")

            Dim functionName As String =
                If(chkDermaga.Checked,
                   "fnmonkapalfilterdermaga",
                   "fnmonkapal")

            Dim sqlQuery As String

            If chkDermaga.Checked Then

                sqlQuery = "SELECT * FROM " & functionName &
                           " (" & SqlText(tgl1) & "," &
                           SqlText(tgl2) & "," &
                           SqlText(cbodermaga.Text) & ")"

            Else

                sqlQuery = "SELECT * FROM " & functionName &
                           " (" & SqlText(tgl1) & "," &
                           SqlText(tgl2) & ")"

            End If

            sqlQuery &= " WHERE 1 = 1 "

            If rdp1.Checked Then
                sqlQuery &= " AND Bongkar IN ('PSG','P1')"
            ElseIf rdp2.Checked Then
                sqlQuery &= " AND Bongkar IN ('RSUP','P2')"
            End If

            If sql <> "" Then
                sqlQuery &= " AND " & sql
            End If

            sqlQuery &= " ORDER BY Pancang, KapalName ASC"

            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sqlQuery)

            If dt.Rows.Count = 0 Then
                UI.HapusGrid(5, fgKg)
                MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
                Return
            End If

            IsiGridKg(dt)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub IsiGridKg(dt As DataTable)

        Dim i As Integer = 5

        With fgKg

            UI.HapusGrid(5, fgKg)

            For Each row As DataRow In dt.Rows

                .AddItem(i - 4)

                .Item(i, 1) = GetValue(row, "pancang")
                .Item(i, 2) = GetValue(row, "kapalname")
                .Item(i, 3) = GetValue(row, "trip")
                .Item(i, 4) = GetValue(row, "jeniskelapa")

                .Item(i, 5) = GetValue(row, "muatdate")
                .Item(i, 6) = GetValue(row, "closedate")
                .Item(i, 7) = GetValue(row, "berangkatdate")
                .Item(i, 8) = GetValue(row, "TanggalCheckInPabrik")
                .Item(i, 9) = GetValue(row, "bongkardate")
                .Item(i, 10) = GetValue(row, "tanggalkalkulasi")

                If Not IsDBNull(row("muatdate")) AndAlso
                   Not IsDBNull(row("bongkardate")) Then

                    .Item(i, 11) = DateDiff(
                        DateInterval.Day,
                        CDate(row("muatdate")),
                        CDate(row("bongkardate"))
                    )

                Else
                    .Item(i, 11) = 0
                End If

                Dim n1 As Decimal = GetNumber(row, "n1")
                Dim n2 As Decimal = GetNumber(row, "n2")

                Dim kbA As Decimal = GetNumber(row, "nettoSTLH_A")
                Dim kbB As Decimal = GetNumber(row, "nettoSTLH_B")
                Dim kc As Decimal = GetNumber(row, "nettoSTLH_KC")

                Dim totalAB As Decimal = kbA + kbB
                Dim totalKB As Decimal = kbA + kbB + kc
                Dim susut As Decimal = n2 - totalKB

                .Item(i, 12) = n1
                .Item(i, 13) = n2

                .Item(i, 14) = GetValue(row, "bongkar")
                .Item(i, 15) = GetValue(row, "dermaga")

                .Item(i, 16) = kbA
                .Item(i, 17) = GetPercent(kbA, totalAB)

                .Item(i, 18) = kbB
                .Item(i, 19) = GetPercent(kbB, totalAB)

                .Item(i, 20) = kc

                'Persentase KC mengikuti perhitungan sebelumnya
                .Item(i, 21) = GetPercent(kc, kc)

                .Item(i, 22) = totalKB

                .Item(i, 24) = susut
                .Item(i, 25) = GetPercent(susut, n2)

                .Item(i, 26) = GetValue(row, "KET_SUSUT")
                .Item(i, 27) = GetValue(row, "AwalTripID")

                i += 1

            Next

            .AutoSizeCols()

        End With

        GrandTotal()

    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        ShowData()
    End Sub

#End Region

#Region "Search"

    Private Sub schKg()

        With schfgKg
            .SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
            .SearchDelay = 2
            .Watermark = "Cari Disini"
            .SetC1FlexGridSearchPanel(fgKg, schfgKg)
        End With

    End Sub

#End Region

#Region "Header FlexGrid"

    Private Sub HeaderFGKg()

        Dim txt As CellRange

        With fgKg

            .AllowEditing = True
            .Font = New Font("Century Gothic", 9.0!, FontStyle.Bold)
            .Cols.Count = 28

            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)

            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

            For r As Integer = 1 To 4
                .Rows(r).StyleNew.BackColor = Color.FromArgb(242, 222, 222)
                .Rows(r).StyleFixedNew.BackColor = Color.FromArgb(223, 240, 226)
            Next

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True

            .Rows.Fixed = 5
            .Cols.Frozen = 3

            .AllowMerging = AllowMergingEnum.FixedOnly

            For r As Integer = 0 To 4
                .Rows(r).AllowMerging = True
            Next

            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

#Region "Header"

            txt = .GetCellRange(0, 0, 4, 0)
            txt.Data = "No"
            .Cols(0).AllowMerging = True
            .Cols(0).TextAlign = TextAlignEnum.LeftCenter
            .Cols(0).AllowEditing = False

            txt = .GetCellRange(0, 1, 4, 1)
            txt.Data = "PANCANG"
            .Cols(1).AllowMerging = True
            .Cols(1).TextAlign = TextAlignEnum.LeftCenter
            .Cols(1).AllowEditing = False

            txt = .GetCellRange(0, 2, 4, 2)
            txt.Data = "NAMA KAPAL"
            .Cols(2).AllowMerging = True
            .Cols(2).TextAlign = TextAlignEnum.LeftCenter
            .Cols(2).AllowEditing = False

            txt = .GetCellRange(0, 3, 4, 3)
            txt.Data = "TRIP"
            .Cols(3).AllowMerging = True
            .Cols(3).TextAlign = TextAlignEnum.LeftCenter
            .Cols(3).AllowEditing = False

            txt = .GetCellRange(0, 4, 4, 4)
            txt.Data = "JENIS KELAPA"
            .Cols(4).AllowMerging = True
            .Cols(4).TextAlign = TextAlignEnum.LeftCenter
            .Cols(4).AllowEditing = False

            txt = .GetCellRange(0, 5, 4, 5)
            txt.Data = "TGL MULAI MUAT"
            .Cols(5).AllowMerging = True
            .Cols(5).TextAlign = TextAlignEnum.LeftCenter
            .Cols(5).AllowEditing = False

            txt = .GetCellRange(0, 6, 4, 6)
            txt.Data = "TGL SELESAI MUAT"
            .Cols(6).AllowMerging = True
            .Cols(6).TextAlign = TextAlignEnum.LeftCenter
            .Cols(6).AllowEditing = False

            txt = .GetCellRange(0, 7, 4, 7)
            txt.Data = "TGL BERANGKAT"
            .Cols(7).AllowMerging = True
            .Cols(7).TextAlign = TextAlignEnum.LeftCenter
            .Cols(7).AllowEditing = False

            txt = .GetCellRange(0, 8, 4, 8)
            txt.Data = "TGL CHECK-IN"
            .Cols(8).AllowMerging = True
            .Cols(8).TextAlign = TextAlignEnum.LeftCenter
            .Cols(8).AllowEditing = False

            txt = .GetCellRange(0, 9, 4, 9)
            txt.Data = "TGL BONGKAR"
            .Cols(9).AllowMerging = True
            .Cols(9).TextAlign = TextAlignEnum.LeftCenter
            .Cols(9).AllowEditing = False

            txt = .GetCellRange(0, 10, 4, 10)
            txt.Data = "TGL KALKULASI"
            .Cols(10).AllowMerging = True
            .Cols(10).TextAlign = TextAlignEnum.LeftCenter
            .Cols(10).AllowEditing = False

            txt = .GetCellRange(0, 11, 4, 11)
            txt.Data = "LAMA KELAPA DI KAPAL"
            .Cols(11).AllowMerging = True
            .Cols(11).TextAlign = TextAlignEnum.RightCenter
            .Cols(11).AllowEditing = False

            txt = .GetCellRange(0, 12, 0, 13)
            txt.Data = "NETTO(KG PANCANG)"
            .Cols(12).AllowMerging = True
            .Cols(12).TextAlign = TextAlignEnum.LeftCenter
            .Cols(12).AllowEditing = False

            txt = .GetCellRange(1, 12, 4, 12)
            txt.Data = "TOTAL N1"
            .Cols(12).AllowMerging = True
            .Cols(12).TextAlign = TextAlignEnum.RightCenter
            .Cols(12).Format = "#,###0"
            .Cols(12).AllowEditing = False

            txt = .GetCellRange(1, 13, 4, 13)
            txt.Data = "TOTAL N2"
            .Cols(13).AllowMerging = True
            .Cols(13).TextAlign = TextAlignEnum.RightCenter
            .Cols(13).Format = "#,###0"
            .Cols(13).AllowEditing = False

            txt = .GetCellRange(0, 14, 4, 14)
            txt.Data = "BONGKAR DI PABRIK (PSG/RSUP)"
            .Cols(14).AllowMerging = True
            .Cols(14).TextAlign = TextAlignEnum.LeftCenter
            .Cols(14).AllowEditing = False

            txt = .GetCellRange(0, 15, 4, 15)
            txt.Data = "DERMAGA PEMBONGKARAN DI PABRIK"
            .Cols(15).AllowMerging = True
            .Cols(15).TextAlign = TextAlignEnum.LeftCenter
            .Cols(15).AllowEditing = False

            txt = .GetCellRange(0, 16, 0, 20)
            txt.Data = "HASIL TIMBANG PABRIK (NETTO-2) Kg"
            .Cols(16).AllowMerging = True
            .Cols(16).TextAlign = TextAlignEnum.LeftCenter

            txt = .GetCellRange(1, 16, 1, 20)
            txt.Data = "TOTAL KB TERIMA PABRIK"
            .Cols(16).AllowMerging = True
            .Cols(16).TextAlign = TextAlignEnum.CenterCenter
            .Cols(16).AllowEditing = False

            txt = .GetCellRange(2, 16, 4, 16)
            txt.Data = "KB-A"
            .Cols(16).AllowMerging = True
            .Cols(16).TextAlign = TextAlignEnum.RightCenter
            .Cols(16).Format = "#,###0"
            .Cols(16).AllowEditing = False

            txt = .GetCellRange(2, 17, 4, 17)
            txt.Data = "%"
            .Cols(17).AllowMerging = True
            .Cols(17).TextAlign = TextAlignEnum.RightCenter
            .Cols(17).AllowEditing = False

            txt = .GetCellRange(2, 18, 4, 18)
            txt.Data = "KB-B"
            .Cols(18).AllowMerging = True
            .Cols(18).TextAlign = TextAlignEnum.RightCenter
            .Cols(18).Format = "#,###0"
            .Cols(18).AllowEditing = False

            txt = .GetCellRange(2, 19, 4, 19)
            txt.Data = "%"
            .Cols(19).AllowMerging = True
            .Cols(19).TextAlign = TextAlignEnum.RightCenter
            .Cols(19).AllowEditing = False

            txt = .GetCellRange(2, 20, 4, 20)
            txt.Data = "KC"
            .Cols(20).AllowMerging = True
            .Cols(20).TextAlign = TextAlignEnum.RightCenter
            .Cols(20).Format = "#,###0"
            .Cols(20).AllowEditing = False

            txt = .GetCellRange(2, 21, 4, 21)
            txt.Data = "%"
            .Cols(21).AllowMerging = True
            .Cols(21).TextAlign = TextAlignEnum.RightCenter
            .Cols(21).AllowEditing = False

            txt = .GetCellRange(2, 22, 4, 22)
            txt.Data = "TOTAL"
            .Cols(22).AllowMerging = True
            .Cols(22).TextAlign = TextAlignEnum.RightCenter
            .Cols(22).Format = "#,###0"
            .Cols(22).AllowEditing = False

            txt = .GetCellRange(2, 23, 4, 23)
            txt.Data = ""
            .Cols(23).AllowMerging = True
            .Cols(23).TextAlign = TextAlignEnum.RightCenter
            .Cols(23).Format = "#,###0"
            .Cols(23).Visible = False

            txt = .GetCellRange(0, 24, 0, 25)
            txt.Data = "SUSUT TIMBANGAN(Kg)"
            .Cols(24).AllowMerging = True
            .Cols(24).Format = "#,###0"
            .Cols(24).AllowEditing = False

            txt = .GetCellRange(1, 24, 4, 24)
            txt.Data = "TOTAL SUSUT KB"
            .Cols(24).AllowMerging = True
            .Cols(24).Format = "#,###0"
            .Cols(24).AllowEditing = False

            txt = .GetCellRange(1, 25, 4, 25)
            txt.Data = "%"
            .Cols(25).AllowMerging = True

            txt = .GetCellRange(0, 26, 4, 26)
            txt.Data = "KETERANGAN"
            .Cols(26).Name = "KET"
            .Cols(26).AllowMerging = True
            .Cols(26).TextAlign = TextAlignEnum.LeftCenter
            .Cols(26).AllowEditing = True
            .Cols(26).ComboList = DB.GetCategories("tblMstket")
            .Cols(26).Visible = True
            .Cols(26).Width = 300

            txt = .GetCellRange(0, 27, 4, 27)
            txt.Data = "AWALTRIPID"
            .Cols(27).AllowMerging = True
            .Cols(27).Visible = False

#End Region

            .AutoSizeCols()

        End With

    End Sub

#End Region

#Region "Grand Total"

    Private Sub GrandTotal()

        With fgKg

            .Tree.Column = 0
            .Tree.Style = TreeStyleFlags.CompleteLeaf

            .Subtotal(AggregateEnum.Clear)

            .Subtotal(AggregateEnum.Sum, -1, -1, 11, "TOTAL")

            .Subtotal(AggregateEnum.Sum, -1, -1, 12)
            .Subtotal(AggregateEnum.Sum, -1, -1, 13)

            .Subtotal(AggregateEnum.Sum, -1, -1, 16)
            .Subtotal(AggregateEnum.Sum, -1, -1, 18)
            .Subtotal(AggregateEnum.Sum, -1, -1, 20)

            .Subtotal(AggregateEnum.Sum, -1, -1, 22)
            .Subtotal(AggregateEnum.Sum, -1, -1, 23)
            .Subtotal(AggregateEnum.Sum, -1, -1, 24)

            .AutoSizeCols()

        End With

        FGColor()

    End Sub

    Public Sub FGColor()

        Dim cs As CellStyle

        cs = fgKg.Styles(CellStyleEnum.GrandTotal)
        cs.BackColor = Color.FromArgb(73, 173, 8)
        cs.ForeColor = Color.White
        cs.Font = New Font(Font, FontStyle.Bold)

        cs = fgKg.Styles(CellStyleEnum.Subtotal0)
        cs.BackColor = Color.FromArgb(81, 161, 243)
        cs.ForeColor = Color.White
        cs.Font = New Font(Font, FontStyle.Bold)

        cs = fgKg.Styles(CellStyleEnum.Subtotal1)
        cs.BackColor = Color.DarkBlue
        cs.ForeColor = Color.White

        fgKg.AutoSizeCols()

    End Sub

#End Region

#Region "Filter Pancang dan Kapal"

    Private Sub chkPancang_CheckedChanged(
        sender As Object,
        e As EventArgs
    ) Handles chkPancang.CheckedChanged

        UI.ChkCondCmb(chkPancang, cmbPancang, "Pancang")

    End Sub

    Private Sub ChkKapal_CheckedChanged(
        sender As Object,
        e As EventArgs
    ) Handles chkKapal.CheckedChanged

        UI.ChkCondCmb(chkKapal, cmbKapal, "Kapal")

    End Sub

    Private Sub cmbPancang_Validated(
        sender As Object,
        e As EventArgs
    ) Handles cmbPancang.Validated

        chkPancang.Checked = (cmbPancang.Text <> "")

    End Sub

    Private Sub cmbKapal_Validated(
        sender As Object,
        e As EventArgs
    ) Handles cmbKapal.Validated

        chkKapal.Checked = (cmbKapal.Text <> "")

    End Sub

    Private Sub cmbPancang_Validating(
        sender As Object,
        e As CancelEventArgs
    ) Handles cmbPancang.Validating

        If cmbPancang.Text = "" Then Return

        If cmbPancang.SelectedValue Is Nothing Then
            MsgBox("Pilihan tidak ada!", vbExclamation, AT)
            e.Cancel = True
        End If

    End Sub

    Private Sub cmbKapal_Validating(
        sender As Object,
        e As CancelEventArgs
    ) Handles cmbKapal.Validating

        If cmbKapal.Text = "" Then Return

        If cmbKapal.SelectedValue Is Nothing Then
            MsgBox("Pilihan tidak ada!", vbExclamation, AT)
            e.Cancel = True
        End If

    End Sub

    Private Sub cmbPancang_KeyUp(
        sender As Object,
        e As KeyEventArgs
    ) Handles cmbPancang.KeyUp

        UI.AutoCompleteCombo_KeyUp(cmbPancang, e)

    End Sub

    Private Sub cmbKapal_KeyUp(
        sender As Object,
        e As KeyEventArgs
    ) Handles cmbKapal.KeyUp

        UI.AutoCompleteCombo_KeyUp(cmbKapal, e)

    End Sub

    Private Sub cmbKapal_Click(
        sender As Object,
        e As EventArgs
    ) Handles cmbKapal.Click

        If cmbPancang.SelectedValue Is Nothing OrElse
           chkPancang.Checked = False Then

            MsgBox("Silahkan Pilih Pancang!", MsgBoxStyle.Exclamation, AT)
            cmbPancang.Focus()

        End If

    End Sub

#End Region

#Region "FlexGrid Event"

    Private Sub fgKg_AfterEdit(
        sender As Object,
        e As RowColEventArgs
    ) Handles fgKg.AfterEdit

        fgKg.AutoSizeCols()

    End Sub

#End Region

#Region "Simpan Keterangan"

    Private Function SaveTrnKET(
        ByVal Conn As SqlConnection,
        ByVal Trans As SqlTransaction,
        ByVal i As Integer
    ) As Boolean

        Try

            Using cmd As New SqlCommand(
                "RMPApp..spRM_TrnKET",
                Conn,
                Trans
            )

                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.Add(
                    "@AWALTRIPID",
                    SqlDbType.BigInt
                ).Value = Convert.ToInt64(fgKg.Item(i, 27))

                cmd.Parameters.Add(
                    "@KET",
                    SqlDbType.VarChar,
                    150
                ).Value = Convert.ToString(fgKg.Item(i, 26))

                Dim pError As SqlParameter =
                    cmd.Parameters.Add("@Error", SqlDbType.VarChar, 200)

                pError.Direction = ParameterDirection.InputOutput
                pError.Value = ""

                cmd.ExecuteNonQuery()

                If Not IsDBNull(pError.Value) AndAlso
                   Convert.ToString(pError.Value) <> "" Then

                    Throw New Exception(Convert.ToString(pError.Value))

                End If

            End Using

            Return True

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error Simpan Keterangan")
            Return False

        End Try

    End Function

    Private Sub BTNSAVE_Click(
        sender As Object,
        e As EventArgs
    ) Handles BTNSAVE.Click

        Dim Koneksi As SqlConnection = Nothing
        Dim Transaksi As SqlTransaction = Nothing

        Me.Cursor = Cursors.WaitCursor

        Try

            Koneksi = DB.OpenConnection(StrConnRMPApp)
            Transaksi = Koneksi.BeginTransaction

            With fgKg

                For i As Integer = 5 To .Rows.Count - 1

                    Dim awalTripID As Long

                    If Not Long.TryParse(
                        Convert.ToString(.Item(i, 27)),
                        awalTripID
                    ) Then
                        Continue For
                    End If

                    Dim ket As String =
                        Convert.ToString(.Item(i, 26)).Trim()

                    If ket.Length > 2 Then

                        If Not SaveTrnKET(Koneksi, Transaksi, i) Then
                            Throw New Exception("Update data gagal!")
                        End If

                    End If

                Next

            End With

            Transaksi.Commit()

            MessageBox.Show(
                "Simpan data berhasil",
                "Sukses",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            ShowData()

        Catch ex As Exception

            If Transaksi IsNot Nothing Then
                Try
                    Transaksi.Rollback()
                Catch
                End Try
            End If

            MessageBox.Show(
                ex.Message,
                "Gagal",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

        Finally

            If Koneksi IsNot Nothing Then
                Koneksi.Close()
                Koneksi.Dispose()
            End If

            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region "Export Excel"

    Private Sub btnExcel_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnExcel.Click

        Using sfd As New SaveFileDialog

            sfd.Filter = "Excel File|*.xlsx"
            sfd.Title = "Save an Excel File"
            sfd.FileName =
                "Report_KG_" & Format(Now, "yyyyMMdd_HHmmss") & ".xlsx"

            If sfd.ShowDialog() = DialogResult.OK Then

                fgKg.SaveExcel(
                    sfd.FileName,
                    C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells Or
                    C1.Win.C1FlexGrid.FileFlags.AsDisplayed
                )

                MessageBox.Show(
                    "Export to Excel berhasil",
                    "Sukses",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                )

            End If

        End Using

    End Sub

#End Region

End Class
