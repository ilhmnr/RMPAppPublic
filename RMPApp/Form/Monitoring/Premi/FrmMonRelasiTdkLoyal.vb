Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmMonRelasiTdkLoyal
    Dim nm As String
    Dim ClsRelasiLoyal_ As New ClsRelasiLoyal
    Dim adapter As SqlDataAdapter
    Dim connetionString As String
    Dim connection As SqlConnection
    Dim sumbrutoperrelasi As Double

    Dim TotalAllMonth As Double

    Dim TotalPerKK As Double
    Dim TotalPerPancang As Double

    Dim lopkk As Integer
    Dim loppcg As Integer
    Dim intensitas As Integer
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub FrmMonRelasiTdkLoyal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        fg.Clear()
        fg.Row = 0
        fg.Col = 0
        fg.DataSource = Nothing
        ''dtinvoice.Value = Format(Now, "dd/MM/yyyy")
        dtcb1.Value = Format(Now, "dd/MM/yyyy")
        dtcb1.Value = Format(Now, "dd/MM/yyyy")
        HeaderFG()
        schKg()
        Modul_RMP.Combo.SetSupplier(cmbS_Petani)
    End Sub


    Public Sub HeaderFG()

        Dim txt As CellRange
        With fg
            .Font = New System.Drawing.Font("Century Gothic", 9.0!)
            .Styles.Fixed.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
            .Cols.Count = 16
            .Cols.Fixed = 0

            .Styles.Fixed.BackColor = Color.FromArgb(83, 141, 213)
            '.Styles.Alternate.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
            .Rows(1).StyleFixedNew.BackColor = Color.FromArgb(250, 191, 143)

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 3
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Rows(1).AllowMerging = True
            fg.Cols.Frozen = 9
        End With
        'CELL2()
    End Sub


    Private Sub CELL()
        Dim txt As CellRange
        With fg

            txt = .GetCellRange(0, 0, 2, 0) : txt.Data = "Klasifikasi" : .Cols(2).Name = "Klasifikasi" : .Cols(0).TextAlign = TextAlignEnum.LeftCenter : .Cols(0).AllowMerging = True

            'txt = .GetCellRange(0, 1, 2, 1) : txt.Data = "GroupKK" : .Cols(1).Name = "KodeSupUM" : .Cols(1).TextAlign = TextAlignEnum.LeftCenter : .Cols(1).AllowMerging = True : .Cols(1).TextAlignFixed = TextAlignEnum.CenterCenter
            'txt = .GetCellRange(0, 2, 2, 2) : txt.Data = "Nama KK" : .Cols(2).Width = 50 : .Cols(2).Name = "NamaSupUM" : .Cols(2).AllowMerging = True : .Cols(2).TextAlign = TextAlignEnum.CenterCenter : .Cols(2).TextAlignFixed = TextAlignEnum.CenterCenter
            'txt = .GetCellRange(0, 3, 2, 3) : txt.Data = "ID Petani" : .Cols(3).Name = "IDSubPetani" : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).AllowMerging = True : .Cols(3).TextAlignFixed = TextAlignEnum.CenterCenter
            'txt = .GetCellRange(0, 4, 2, 4) : txt.Data = "Nama Pemilik Kelapa / SubPetani" : .Cols(4).Name = "SubPetani" : .Cols(4).TextAlign = TextAlignEnum.LeftCenter : .Cols(4).AllowMerging = True : .Cols(4).TextAlignFixed = TextAlignEnum.CenterCenter
            'txt = .GetCellRange(0, 5, 2, 5) : txt.Data = "IDPenerimaUang" : .Cols(5).Name = "IDPenerimaUang" : .Cols(5).TextAlign = TextAlignEnum.LeftCenter : .Cols(5).AllowMerging = True : .Cols(5).TextAlignFixed = TextAlignEnum.CenterCenter
            'txt = .GetCellRange(0, 6, 2, 6) : txt.Data = "Penerima Uang" : .Cols(6).Name = "PenerimaUang" : .Cols(6).TextAlign = TextAlignEnum.LeftCenter : .Cols(6).AllowMerging = True : .Cols(6).TextAlignFixed = TextAlignEnum.CenterCenter
            'txt = .GetCellRange(0, 7, 2, 7) : txt.Data = "Pancang" : .Cols(7).Name = "Pancang" : .Cols(7).TextAlign = TextAlignEnum.LeftCenter : .Cols(7).AllowMerging = True : .Cols(7).Width = 180 : .Cols(7).TextAlignFixed = TextAlignEnum.CenterCenter
            'txt = .GetCellRange(0, 8, 2, 8) : txt.Data = "NoNota" : .Cols(8).Name = "NoNota" : .Cols(8).TextAlign = TextAlignEnum.LeftCenter : .Cols(8).AllowMerging = True : .Cols(8).Width = 180 : .Cols(8).TextAlignFixed = TextAlignEnum.CenterCenter
            'txt = .GetCellRange(0, 9, 2, 9) : txt.Data = "TransDate" : .Cols(9).Name = "TransDate" : .Cols(9).TextAlign = TextAlignEnum.LeftCenter : .Cols(9).AllowMerging = True : .Cols(9).Width = 180 : .Cols(9).TextAlignFixed = TextAlignEnum.CenterCenter
            'txt = .GetCellRange(0, 10, 2, 10) : txt.Data = "Jenis" : .Cols(10).Name = "Jenis" : .Cols(10).TextAlign = TextAlignEnum.LeftCenter : .Cols(10).AllowMerging = True : .Cols(10).Width = 180 : .Cols(10).TextAlignFixed = TextAlignEnum.CenterCenter
            'txt = .GetCellRange(0, 11, 2, 11) : txt.Data = "Tarra(%)" : .Cols(11).Name = "TarraPersen" : .Cols(11).AllowMerging = True : .Cols(11).Width = 180 : .Cols(11).TextAlignFixed = TextAlignEnum.CenterCenter
            'txt = .GetCellRange(0, 12, 2, 12) : txt.Data = "Volume(Kg)" : .Cols(12).Name = "VolumeKg" : .Cols(12).TextAlign = TextAlignEnum.RightCenter : .Cols(12).AllowMerging = True : .Cols(12).Width = 180 : .Cols(12).Format = "#,###0"
            'txt = .GetCellRange(0, 13, 2, 13) : txt.Data = "QCTarra" : .Cols(13).Name = "QCTarra" : .Cols(13).TextAlign = TextAlignEnum.CenterCenter : .Cols(13).AllowMerging = True : .Cols(13).Width = 180 : .Cols(13).TextAlignFixed = TextAlignEnum.CenterCenter
            'txt = .GetCellRange(0, 14, 2, 14) : txt.Data = "NoReffQL" : .Cols(14).Name = "NoReff" : .Cols(14).TextAlign = TextAlignEnum.LeftCenter : .Cols(14).AllowMerging = True : .Cols(14).Width = 180 : .Cols(14).TextAlignFixed = TextAlignEnum.CenterCenter
            'txt = .GetCellRange(0, 15, 2, 15) : txt.Data = "TotalPerRelasi" : .Cols(15).Visible = False : .Cols(15).Name = "totalnettoakhir" : .Cols(15).TextAlign = TextAlignEnum.LeftCenter : .Cols(15).AllowMerging = True : .Cols(15).Width = 180 : .Cols(15).TextAlignFixed = TextAlignEnum.CenterCenter
            'txt = .GetCellRange(0, 16, 2, 16) : txt.Data = "Klasifikasi" : .Cols(16).Visible = False : .Cols(16).Name = "Klasifikasi2" : .Cols(16).TextAlign = TextAlignEnum.LeftCenter : .Cols(16).AllowMerging = True : .Cols(16).Width = 180 : .Cols(16).TextAlignFixed = TextAlignEnum.CenterCenter
            'txt = .GetCellRange(0, 17, 2, 17) : txt.Data = "hid" : .Cols(17).Visible = False : .Cols(17).TextAlign = TextAlignEnum.LeftCenter : .Cols(17).AllowMerging = True : .Cols(17).Width = 180 : .Cols(17).TextAlignFixed = TextAlignEnum.CenterCenter

            'txt = .GetCellRange(0, 18, 2, 18) : txt.Data = "PointSupplier" : .Cols(18).Name = "PointSupplier" : .Cols(18).AllowMerging = True : .Cols(18).Width = 180 : .Cols(18).TextAlignFixed = TextAlignEnum.RightCenter : .Cols(18).Format = "#,###0"
            'txt = .GetCellRange(0, 19, 2, 19) : txt.Data = "JumlahPoint" : .Cols(19).Name = "JumlahPoint" : .Cols(19).TextAlign = TextAlignEnum.RightCenter : .Cols(19).AllowMerging = True : .Cols(19).Width = 190 : .Cols(19).Format = "#,###0"
            'txt = .GetCellRange(0, 20, 2, 20) : txt.Data = "JumlahPoint" : .Cols(20).Visible = False : .Cols(20).AllowMerging = True : .Cols(20).Width = 190 : .Cols(20).TextAlignFixed = TextAlignEnum.RightCenter : .Cols(20).Format = "#,###0"

            'txt = .GetCellRange(0, 21, 0, 26) : txt.Data = "TambahanPoint" : .Cols(21).TextAlign = TextAlignEnum.CenterCenter : .Cols(21).AllowMerging = True : .Cols(21).TextAlignFixed = TextAlignEnum.CenterCenter

            'txt = .GetCellRange(1, 21, 1, 22) : txt.Data = "Rek.Sendiri" : .Cols(21).TextAlign = TextAlignEnum.CenterCenter : .Cols(21).AllowMerging = True
            'txt = .GetCellRange(2, 21, 2, 21) : txt.Data = "%" : .Cols(21).Name = "PersenRek" : .Cols(21).AllowMerging = True : .Cols(21).Format = "#,###0" : .Cols(21).TextAlignFixed = TextAlignEnum.CenterCenter
            'txt = .GetCellRange(2, 22, 2, 22) : txt.Data = "Point" : .Cols(22).Name = "PointRek" : .Cols(22).TextAlign = TextAlignEnum.RightCenter : .Cols(22).AllowMerging = True : .Cols(22).Format = "#,###0" : .Cols(22).TextAlignFixed = TextAlignEnum.RightCenter

            'txt = .GetCellRange(1, 23, 1, 24) : txt.Data = "Kualitas Kelapa" : .Cols(23).TextAlign = TextAlignEnum.CenterCenter : .Cols(23).AllowMerging = True
            'txt = .GetCellRange(2, 23, 2, 23) : txt.Data = "%" : .Cols(23).Name = "PersenKualitas" : .Cols(23).TextAlign = TextAlignEnum.CenterCenter : .Cols(23).AllowMerging = True : .Cols(23).Format = "#,###0" : .Cols(23).TextAlignFixed = TextAlignEnum.CenterCenter
            'txt = .GetCellRange(2, 24, 2, 24) : txt.Data = "Point" : .Cols(24).Name = "PointKualitas" : .Cols(24).TextAlign = TextAlignEnum.RightCenter : .Cols(24).AllowMerging = True : .Cols(24).Format = "#,###0" : .Cols(24).TextAlignFixed = TextAlignEnum.RightCenter

            'txt = .GetCellRange(1, 25, 1, 26) : txt.Data = "KB-Licin" : .Cols(25).TextAlign = TextAlignEnum.CenterCenter : .Cols(25).AllowMerging = True
            'txt = .GetCellRange(2, 25, 2, 25) : txt.Data = "%" : .Cols(25).Name = "PersenLicin" : .Cols(25).TextAlign = TextAlignEnum.CenterCenter : .Cols(25).AllowMerging = True : .Cols(25).Format = "#,###0" : .Cols(25).TextAlignFixed = TextAlignEnum.CenterCenter
            'txt = .GetCellRange(2, 26, 2, 26) : txt.Data = "Point" : .Cols(26).Name = "PointLicin" : .Cols(26).TextAlign = TextAlignEnum.RightCenter : .Cols(26).AllowMerging = True : .Cols(26).Format = "#,###0" : .Cols(26).TextAlignFixed = TextAlignEnum.RightCenter

            txt = .GetCellRange(0, 27, 2, 27) : txt.Data = "Total Point" : .Cols(27).AllowMerging = True : .Cols(27).Width = 180 : .Cols(27).TextAlignFixed = TextAlignEnum.RightCenter : .Cols(27).Format = "#,###0"
            .AutoSizeCols()
        End With

    End Sub


    Private Sub CELL2()
        Dim txt As CellRange
        With fg

            txt = .GetCellRange(0, 0, 2, 0) : txt.Data = "GROUP KK" : .Cols(0).Width = 40 : .Cols(0).Name = "KodeSupUM" : .Cols(0).TextAlign = TextAlignEnum.LeftCenter : .Cols(0).AllowMerging = True : .Cols(0).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 1, 2, 1) : txt.Data = "NAMA KK" : .Cols(1).Width = 60 : .Cols(1).Name = "NamaSupUM" : .Cols(1).AllowMerging = True : .Cols(1).TextAlign = TextAlignEnum.LeftCenter : .Cols(1).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 2, 2, 2) : txt.Data = "ID PETANI" : .Cols(2).Name = "IDSubPetani" : .Cols(2).Width = 68 : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).AllowMerging = True : .Cols(2).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 3, 2, 3) : txt.Data = "NAMA PEMILIK KELAPA/ SUB PETANI" : .Cols(3).Width = 80 : .Cols(3).Name = "SubPetani" : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).AllowMerging = True : .Cols(3).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 4, 2, 4) : txt.Data = "IDPENERIMA UANG" : .Cols(4).Name = "IDPenerimaUang" : .Cols(4).Width = 68 : .Cols(4).TextAlign = TextAlignEnum.LeftCenter : .Cols(4).AllowMerging = True : .Cols(4).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 5, 2, 5) : txt.Data = "PENERIMA UANG" : .Cols(5).Name = "PenerimaUang" : .Cols(5).Width = 80 : .Cols(5).TextAlign = TextAlignEnum.LeftCenter : .Cols(5).AllowMerging = True : .Cols(5).TextAlignFixed = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 6, 2, 6) : txt.Data = "PANCANG" : .Cols(6).Name = "Pancang" : .Cols(6).Width = 80 : .Cols(6).TextAlign = TextAlignEnum.LeftCenter : .Cols(6).AllowMerging = True : .Cols(6).TextAlignFixed = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 7, 2, 7) : txt.Data = "NONOTA" : .Cols(7).Name = "nonota" : .Cols(7).Visible = False
            txt = .GetCellRange(0, 8, 2, 8) : txt.Data = "KLASIFIKASI" : .Cols(8).Name = "Klasifikasi" : .Cols(8).TextAlign = TextAlignEnum.LeftCenter : .Cols(8).AllowMerging = True

            txt = .GetCellRange(0, 9, 2, 9) : txt.Data = "TRANS DATE(-3Month)" : .Cols(9).Name = "TransDate3" : .Cols(9).Width = 80 : .Cols(9).TextAlign = TextAlignEnum.LeftCenter : .Cols(9).AllowMerging = True
            txt = .GetCellRange(0, 10, 2, 10) : txt.Data = "VOL.Kg (-3Month) " : .Cols(10).Name = "TotalVolKg3" : .Cols(10).Width = 80 : .Cols(10).TextAlign = TextAlignEnum.RightCenter : .Cols(10).AllowMerging = True : .Cols(10).Format = "#,###0"
            txt = .GetCellRange(0, 11, 2, 11) : txt.Data = "KLASIFIKASI(-3Month)" : .Cols(11).Name = "Klasifikasi3" : .Cols(11).Width = 80 : .Cols(11).TextAlign = TextAlignEnum.LeftCenter : .Cols(11).AllowMerging = True

            txt = .GetCellRange(0, 12, 2, 12) : txt.Data = "TRANS DATE" : .Cols(12).Name = "TransDate" : .Cols(12).Width = 80 : .Cols(12).TextAlign = TextAlignEnum.LeftCenter : .Cols(12).AllowMerging = True : .Cols(12).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 13, 2, 13) : txt.Data = "JENIS" : .Cols(13).Name = "Jenis" : .Cols(13).Width = 50 : .Cols(13).TextAlign = TextAlignEnum.LeftCenter : .Cols(13).AllowMerging = True : .Cols(13).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 14, 2, 14) : txt.Data = "TARRA(%)" : .Cols(14).Name = "TarraPersen" : .Cols(14).Width = 80 : .Cols(14).AllowMerging = True : .Cols(14).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 15, 2, 15) : txt.Data = "VOLUME(Kg) NETTO2" : .Cols(15).Name = "VolumeKg" : .Cols(15).Width = 80 : .Cols(15).TextAlign = TextAlignEnum.RightCenter : .Cols(15).AllowMerging = True : .Cols(15).Format = "#,###0" : .Cols(15).TextAlignFixed = TextAlignEnum.CenterCenter


            '.AutoSizeCols()
        End With

    End Sub


    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click

        fg.Clear()
        fg.Row = 0
        fg.Col = 0
        fg.DataSource = Nothing
        '
        Me.fg.Clear(C1.Win.C1FlexGrid.ClearFlags.Content)
        DS.Clear()
        DS.Tables.Clear()

        Call UI.HapusGrid(3, fg)

        'HeaderFG()
        'CELL2()
        If fg.Rows.Count < 4 Then

            SHOWDATA3notloyal()

        End If


    End Sub


    Private Sub SHOWDATA3notloyal()
        fg.Clear()
        Me.fg.Clear(C1.Win.C1FlexGrid.ClearFlags.Content)
        DS.Clear()
        DS.Tables.Clear()


        fg.DataSource = Nothing
        Call UI.HapusGrid(3, fg)
        HeaderFG()
        connetionString = "server=192.168.12.5; database=RSUPAccounting; user=UKoneksi; password=sm@rt2018;  MultipleActiveResultSets=True; connect timeout=0;Max Pool Size=500000  ;"

        connection = New SqlConnection(connetionString)
        Dim sql, sql2 As String

        If chkS_Petani.Checked = True Then
            sql2 = Modul_RMP.Func.SetCondition(sql, "IDSUBPETANI = '" & cmbS_Petani.SelectedValue.ToString & "'")
        End If





        sql = "SELECT  KodeSupUM , NamaSupUM ,IDSubPetani , SubPetani,IDPenerimaUang , PenerimaUang ,Pancang, NONOTA AS nonota,  " &
                " Klasifikasi, '' AS TransDate3 , 0 AS TotalVolKg3 ,'' AS Klasifikasi3, TransDate, Jenis, TarraPersen,nettoakhir  VolumeKg, netto2  AS TotalVolKg " &
                 " FROM RMPAPP.. fndatapetani2notloyal('" & Format(dtcb1.Value, "yyyy-MM-dd") & "'  ,'" & Format(dtcb2.Value, "yyyy-MM-dd") & "') AS A  where " &
                "  new=0 " & IIf(sql2 = "", "", " And " & sql2) & "   ORDER BY  IDSUBPETANI,kodesupum ,TRANSDATE"


        Try
            connection.Open()
            adapter = New SqlDataAdapter(sql, connection)
            adapter.Fill(DS)
            connection.Close()
            fg.DataSource = DS.Tables(0)

            TotalAllMonth = 0
            TotalPerKK = 0
            TotalPerPancang = 0


            fg.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free




            CELL2()





            'fg.AutoSizeCols()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub




    Public Sub ShowTotals()
        With fg
            .Tree.Column = 0
            .Tree.Style = TreeStyleFlags.CompleteLeaf
            .Subtotal(AggregateEnum.Clear)

            .Subtotal(AggregateEnum.Sum, -1, -1, 15, "Grand Total")
            .Subtotal(AggregateEnum.Sum, 2, 2, 15, "Total {0}")

            '.Subtotal(AggregateEnum.Sum, -1, -1, 16, "Grand Total")
            '.Subtotal(AggregateEnum.Sum, 2, 2, 16, "Total {0}")

            '.Subtotal(AggregateEnum.Sum, -1, -1, 18, "Grand Total")
            '.Subtotal(AggregateEnum.Sum, 2, 2, 18, "Total {0}")

            '.Subtotal(AggregateEnum.Sum, -1, -1, 23, "Grand Total")
            '.Subtotal(AggregateEnum.Sum, 2, 2, 23, "Total {0}")

            '.Subtotal(AggregateEnum.Sum, -1, -1, 25, "Grand Total")
            '.Subtotal(AggregateEnum.Sum, 2, 2, 25, "Total {0}")

            '.Subtotal(AggregateEnum.Sum, -1, -1, 27, "Grand Total")
            '.Subtotal(AggregateEnum.Sum, 2, 2, 27, "Total {0}")

            '.Subtotal(AggregateEnum.Sum, -1, -1, 28, "Grand Total")
            '.Subtotal(AggregateEnum.Sum, 2, 2, 28, "Total {0}")

            '.Subtotal(AggregateEnum.Sum, -1, -1, 29, "Grand Total")
            '.Subtotal(AggregateEnum.Sum, 2, 2, 29, "Total {0}")

            '.Subtotal(AggregateEnum.Sum, -1, -1, 30, "Grand Total")
            '.Subtotal(AggregateEnum.Sum, 2, 2, 30, "Total {0}")

            '.Subtotal(AggregateEnum.Average, -1, -1, 31, "Grand Total")
            '.Subtotal(AggregateEnum.Average, 2, 2, 31, "Total {0}")

            '.Subtotal(AggregateEnum.Average, -1, -1, 32, "Grand Total")
            '.Subtotal(AggregateEnum.Average, 2, 2, 32, "Total {0}")


            '.Subtotal(AggregateEnum.Average, -1, -1, 33, "Grand Total")
            '.Subtotal(AggregateEnum.Average, 2, 2, 33, "Total {0}")

            '.Subtotal(AggregateEnum.Average, -1, -1, 34, "Grand Total")
            '.Subtotal(AggregateEnum.Average, 2, 2, 34, "Total {0}")


        End With
        Call ColorSubTotal()

    End Sub

    Private Sub ColorSubTotal()
        Dim cs As C1.Win.C1FlexGrid.CellStyle
        With fg
            cs = .Styles(C1.Win.C1FlexGrid.CellStyleEnum.GrandTotal)
            cs.BackColor = Color.SteelBlue
            'Color.FromArgb(64, 140, 217)
            cs = .Styles(C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0)
            cs.BackColor = Color.AliceBlue

            cs.ForeColor = Color.White
            cs.Font = New Font(Font, FontStyle.Bold)
        End With
    End Sub

    Private Sub schKg()
        With schfg
            .SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
            .SearchDelay = 2
            .Watermark = "Cari Disini"
            .SetC1FlexGridSearchPanel(fg, schfg)
        End With
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Dim filename As String
        Me.SaveFileDialog.ShowDialog()
        filename = SaveFileDialog.FileName
        Me.fg.SaveExcel(filename & ".xls", "Sheet1", FileFlags.IncludeFixedCells)
        MsgBox("Convert Success !", vbInformation, AT)
    End Sub


    Private Sub cmbS_Petani_Validated(sender As Object, e As EventArgs) Handles cmbS_Petani.Validated
        chkS_Petani.Checked = IIf(cmbS_Petani.Text = "", False, True)
    End Sub

    Private Sub cmbS_Petani_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbS_Petani.SelectedIndexChanged

    End Sub

    Private Sub cmbS_Petani_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbS_Petani.Validating
        If cmbS_Petani.Text = "" Then
            Exit Sub
        End If

        If IsNothing(cmbS_Petani.SelectedValue) Then
            MsgBox("Pilihan tidak ada !", vbExclamation, AT)
            cmbS_Petani.Text = ""
            cmbS_Petani.Focus()
        End If
    End Sub

    Private Sub cmbS_Petani_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbS_Petani.KeyUp
        UI.AutoCompleteCombo_KeyUp(cmbS_Petani, e)
    End Sub

    Private Sub chknewrelasi_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub schfg_Load(sender As Object, e As EventArgs) Handles schfg.Load

    End Sub

    'Private Sub fg_AfterSelChange(sender As Object, e As RangeEventArgs) Handles fg.AfterSelChange
    '    Dim sum As Double
    '    Dim R, c As Integer
    '    With fg
    '        If .Row = 0 Then Exit Sub
    '        If .RowSel > .Row Then
    '            For R = .Row To .RowSel
    '                If (R > 0) And (R <= (.Rows.Count - 1)) Then
    '                    For c = .Col To .ColSel
    '                        Select Case c
    '                            Case 16, 18, 23, 25, 27, 28, 29, 30, 31, 32
    '                                If Trim(.Item(R, c) <> 0) Then
    '                                    sum = sum + CDbl(.Item(R, c))
    '                                End If
    '                        End Select
    '                    Next
    '                End If
    '            Next
    '        End If

    '    End With
    '    txtSum.Text = FormatNumber(sum, 0)
    'End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs)

    '    'fg.Rows.CLE



    '    fg.Clear()
    '    fg.Row = 0
    '    fg.Col = 0
    '    fg.DataSource = Nothing
    '    '
    '    Me.fg.Clear(C1.Win.C1FlexGrid.ClearFlags.Content)
    '    Call UI.HapusGrid(3, fg)
    'End Sub
End Class