Imports C1.Win.C1FlexGrid
Imports System.IO

Public Class FrmMonPemakaianSolar
    Dim txt As CellRange

    Private Const KOL_AWAL As Integer = 4   ' kolom data tanggal pertama
    Private Const KOL_PER_HARI As Integer = 5 ' A6, KC, KB-A, TOTAL, BBM

#Region "Load & Header"
    Private Sub FrmMonPemakaianSolar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HeaderFG()
        dtp1.Value = Now
        dtp2.Value = Now
        If cboJenis.Items.Count > 0 AndAlso cboJenis.SelectedIndex < 0 Then cboJenis.SelectedIndex = 0
    End Sub

    Public Sub HeaderFG()
        With fg
            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
            .Cols.Count = 4
            .Rows.Count = 2
            .Rows.Fixed = 2
            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 213)
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 212)
            .Rows(1).StyleNew.BackColor = Color.FromArgb(242, 222, 222)
            .Rows(1).StyleFixedNew.BackColor = Color.FromArgb(223, 240, 216)
            .Rows(0).AllowMerging = True
            .Rows(1).AllowMerging = True

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 0, 1, 0) : txt.Data = "No"
            .Cols(0).AllowMerging = True : .Cols(0).TextAlign = TextAlignEnum.CenterCenter : .Cols(0).AllowEditing = False

            txt = .GetCellRange(0, 1, 1, 1) : txt.Data = "PANCANG"
            .Cols(1).AllowMerging = True : .Cols(1).TextAlign = TextAlignEnum.LeftCenter : .Cols(1).AllowEditing = False

            txt = .GetCellRange(0, 2, 1, 2) : txt.Data = "IDPANCANG"
            .Cols(2).AllowMerging = True : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).AllowEditing = False : .Cols(2).Visible = False

            txt = .GetCellRange(0, 3, 1, 3) : txt.Data = "T.JAM KERJA"
            .Cols(3).AllowMerging = True : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).AllowEditing = False : .Cols(3).Format = "#,##0.00"

            .AutoSizeCols()
        End With
    End Sub

    ' Mengisi satu blok 5 kolom (A6, KC, KB-A, TOTAL, BBM) mulai dari kolom startCol
    Private Sub SetBlokHeader(startCol As Integer, judul As String)
        With fg
            txt = .GetCellRange(0, startCol, 0, startCol + KOL_PER_HARI - 1)
            txt.Data = judul

            Dim sub1() As String = {"A6", "KC", "KB-A", "TOTAL", cboJenis.Text}
            For n As Integer = 0 To sub1.Length - 1
                Dim c As Integer = startCol + n
                .SetData(1, c, sub1(n))
                .Cols(c).AllowMerging = True
                .Cols(c).TextAlignFixed = TextAlignEnum.CenterCenter
                .Cols(c).TextAlign = TextAlignEnum.RightCenter
                .Cols(c).AllowEditing = False
                .Cols(c).Format = If(n = 4, "#,##0.00", "#,##0")
            Next
        End With
    End Sub

    Private Sub SetHeader()
        With fg
            Dim tanggalAwal As Date = dtp1.Value.Date
            Dim jumlahHari As Integer = (dtp2.Value.Date - tanggalAwal).Days + 1

            ' 4 kolom tetap + (hari x 5) + total akhir (5) + keterangan (1)
            .Cols.Count = KOL_AWAL + (jumlahHari * KOL_PER_HARI) + KOL_PER_HARI + 1

            Dim LastCol As Integer = KOL_AWAL
            For d As Integer = 0 To jumlahHari - 1
                SetBlokHeader(LastCol, tanggalAwal.AddDays(d).ToString("yyyy-MM-dd"))
                LastCol += KOL_PER_HARI
            Next

            SetBlokHeader(LastCol, "TOTAL AKHIR")
            LastCol += KOL_PER_HARI

            txt = .GetCellRange(0, LastCol, 1, LastCol) : txt.Data = "KETERANGAN"
            .Cols(LastCol).AllowMerging = True
            .Cols(LastCol).TextAlign = TextAlignEnum.LeftCenter
            .Cols(LastCol).AllowEditing = False
        End With
    End Sub
#End Region

#Region "Load Data"
    Private Sub btnLoaddata_Click(sender As Object, e As EventArgs) Handles btnLoaddata.Click
        If dtp1.Value.Date > dtp2.Value.Date Then
            MessageBox.Show("Tanggal awal tidak boleh lebih besar dari tanggal akhir.")
            Exit Sub
        End If

        If cboJenis.Text = "" Then
            MessageBox.Show("Jenis tidak boleh kosong.")
            Exit Sub
        End If

        HeaderFG()   ' reset header & baris supaya sisa load sebelumnya hilang
        SetHeader()
        ShowData2()
    End Sub

    Private Function Dbl(o As Object) As Double
        If o Is Nothing OrElse IsDBNull(o) Then Return 0
        If IsNumeric(o) Then Return CDbl(o)
        Return 0
    End Function

    ' Nama kolom BBM diambil dari whitelist (aman dari SQL injection)
    Private Function KolomBBM() As String
        Select Case cboJenis.Text.Trim().ToUpper()
            Case "OLI 40" : Return "oli_40"
            Case "OLI 10" : Return "oli_10"
            Case Else : Return "solar"
        End Select
    End Function

    Private Sub ShowData2()
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim tglAwal As Date = dtp1.Value.Date
            Dim tglAkhir As Date = dtp2.Value.Date
            Dim jumlahHari As Integer = (tglAkhir - tglAwal).Days + 1
            Dim sAwal As String = tglAwal.ToString("yyyy-MM-dd")
            Dim sAkhir As String = tglAkhir.ToString("yyyy-MM-dd")
            Dim kolBBM As String = KolomBBM()

            ' 1. Daftar pancang yang punya pemakaian pada rentang tanggal
            Dim dtPcg As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp,
                "select IDPancang, Pancang from RMPApp..Android_tblMstPancang " &
                "where IDPancang in (select pancang_id from RMPApp..Android_tblPemakaianSolar " &
                "where deleted=0 and cast(tanggal_kerja as date) between '" & sAwal & "' and '" & sAkhir & "') " &
                "order by IDPancang asc")

            If dtPcg.Rows.Count = 0 Then
                MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
                HeaderFG()
                Exit Sub
            End If

            ' 2. Hasil bongkar per hari per pancang
            Dim dtKlp As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp,
                "select cast(TransDate as date) as Tgl, IDPancang, " &
                "SUM(CASE WHEN GradeSub = 'A6' THEN NETTOAKHIR ELSE 0 END) AS A6, " &
                "SUM(CASE WHEN JENIS = 'Cungkil' THEN NETTOAKHIR ELSE 0 END) AS KC, " &
                "SUM(CASE WHEN GradeSub <> 'A6' AND JENIS <> 'Cungkil' THEN NETTOAKHIR ELSE 0 END) AS KBA, " &
                "SUM(NettoAkhir) as Total " &
                "from RMPApp..TblTrnKelapaHdr " &
                "where Deleted=0 and cast(TransDate as date) between '" & sAwal & "' and '" & sAkhir & "' " &
                "group by cast(TransDate as date), IDPancang")

            ' 3. Pemakaian BBM & jam kerja per hari per pancang
            Dim dtSlr As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp,
                "select cast(tanggal_kerja as date) as Tgl, pancang_id as IDPancang, " &
                "sum(waktu_kerja) as waktu_kerja, sum(solar) as solar, sum(oli_10) as oli_10, sum(oli_40) as oli_40 " &
                "from RMPApp..Android_tblPemakaianSolar " &
                "where deleted=0 and cast(tanggal_kerja as date) between '" & sAwal & "' and '" & sAkhir & "' " &
                "group by cast(tanggal_kerja as date), pancang_id")

            With fg
                .Rows.Count = 2 + dtPcg.Rows.Count
                Dim kolTotal As Integer = KOL_AWAL + jumlahHari * KOL_PER_HARI
                Dim kolKet As Integer = .Cols.Count - 1
                Dim map As New Dictionary(Of String, Integer)

                ' Isi identitas baris & inisialisasi angka = 0
                For n As Integer = 0 To dtPcg.Rows.Count - 1
                    Dim r As Integer = n + 2
                    .Item(r, 0) = n + 1
                    .Item(r, 1) = dtPcg.Rows(n)("Pancang")
                    .Item(r, 2) = dtPcg.Rows(n)("IDPancang")
                    For c As Integer = 3 To kolKet - 1
                        .Item(r, c) = 0
                    Next
                    map(CStr(dtPcg.Rows(n)("IDPancang"))) = r
                Next

                ' Isi hasil bongkar
                For Each row As DataRow In dtKlp.Rows
                    Dim r As Integer
                    If Not map.TryGetValue(CStr(row("IDPancang")), r) Then Continue For
                    Dim idx As Integer = (CDate(row("Tgl")).Date - tglAwal).Days
                    If idx < 0 OrElse idx >= jumlahHari Then Continue For
                    Dim c As Integer = KOL_AWAL + idx * KOL_PER_HARI
                    .Item(r, c) = Dbl(row("A6"))
                    .Item(r, c + 1) = Dbl(row("KC"))
                    .Item(r, c + 2) = Dbl(row("KBA"))
                    .Item(r, c + 3) = Dbl(row("Total"))
                Next

                ' Isi BBM & jam kerja
                For Each row As DataRow In dtSlr.Rows
                    Dim r As Integer
                    If Not map.TryGetValue(CStr(row("IDPancang")), r) Then Continue For
                    Dim idx As Integer = (CDate(row("Tgl")).Date - tglAwal).Days
                    If idx < 0 OrElse idx >= jumlahHari Then Continue For
                    Dim c As Integer = KOL_AWAL + idx * KOL_PER_HARI
                    .Item(r, c + 4) = Dbl(row(kolBBM))
                    .Item(r, 3) = Dbl(.Item(r, 3)) + Dbl(row("waktu_kerja"))
                Next

                ' Total akhir + keterangan
                For r As Integer = 2 To .Rows.Count - 1
                    Dim t(KOL_PER_HARI - 1) As Double
                    Dim adaBongkar As Boolean = False

                    For d As Integer = 0 To jumlahHari - 1
                        Dim c As Integer = KOL_AWAL + d * KOL_PER_HARI
                        For n As Integer = 0 To KOL_PER_HARI - 1
                            t(n) += Dbl(.Item(r, c + n))
                        Next
                        If Dbl(.Item(r, c + 3)) > 0 Then adaBongkar = True ' kolom TOTAL hasil bongkar
                    Next

                    For n As Integer = 0 To KOL_PER_HARI - 1
                        .Item(r, kolTotal + n) = t(n)
                    Next

                    If adaBongkar Then
                        .Item(r, kolKet) = "ADA PEMBONGKARAN"
                    Else
                        .Item(r, kolKet) = "TIDAK ADA PEMBONGKARAN"
                        .Rows(r).StyleNew.BackColor = Color.Red
                        .Rows(r).StyleNew.ForeColor = Color.White
                    End If
                Next
            End With

            GrandTotal()
            fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub GrandTotal()
        With fg
            .Tree.Column = 0
            .Tree.Style = TreeStyleFlags.CompleteLeaf
            .Subtotal(AggregateEnum.Clear)
            For c As Integer = 3 To .Cols.Count - 2   ' mulai dari T.JAM KERJA, sampai sebelum KETERANGAN
                .Subtotal(AggregateEnum.Sum, -1, -1, c, "TOTAL")
            Next
        End With
    End Sub
#End Region

#Region "Export & Close"
    Private Sub BtnExcel_Click(sender As Object, e As EventArgs) Handles BtnExcel.Click
        ConvertExcel()
    End Sub

    Private Sub ConvertExcel()
        Try
            If fg.Rows.Count <= fg.Rows.Fixed Then
                MsgBoxCustom.Show("Data kosong.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                Return
            End If

            Using save As New SaveFileDialog
                save.Filter = "Excel 97-2003 (*.xls)|*.xls"
                save.FileName = "PemakaianSolar_" & Format(Now, "yyyyMMdd") & ".xls"

                If save.ShowDialog() <> DialogResult.OK Then Return

                fg.SaveExcel(save.FileName, "Sheet1", FileFlags.IncludeFixedCells)

                If File.Exists(save.FileName) Then
                    MsgBoxCustom.Show("Export berhasil!", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                End If
            End Using

        Catch ex As Exception
            MsgBoxCustom.Show("Error Export: " & ex.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
        End Try
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.Close()
    End Sub
#End Region
End Class