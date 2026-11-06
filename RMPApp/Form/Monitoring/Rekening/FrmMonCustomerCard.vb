
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Windows.Controls
Imports C1.Win.C1FlexGrid
Imports Excel = Microsoft.Office.Interop.Excel
Public Class FrmMonCustomerCard
    Dim dt As DataTable = New DataTable()
    Dim Bergerak As Integer
    Dim Teks As String
    Public images As String
    Dim cmds As SqlCommand
    Dim adapterCUSTOMER As SqlDataAdapter
    Dim connetionStringCUSTOMER As String
    Dim connectionCUSTOMER As SqlConnection
    Private Sub FrmMonCustomerCard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FrmFotoNota.Foto = "Nota"
        DTPStart.Value = Format(Now, "dd/MM/yy")
        DTPEnd.Value = Format(Now, "dd/MM/yy")
        Modul_RMP.Combo.SetSupplier(cmbRelasi)

        Call HeaderFG()
        Call search()


    End Sub

    Private Sub search()
        With scp1
            .SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
            .SearchDelay = 2
            .Watermark = "Cari Disini"
            .SetC1FlexGridSearchPanel(fg, scp1)
        End With
    End Sub



    Public Sub HeaderFG()
        Dim txt As CellRange
        With fg
            .Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Bold)
            .Cols.Count = 10
            '.Cols.Fixed = 0
            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 254)
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            '.Styles.Alternate.Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Bold)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(178, 228, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(178, 228, 252)


            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 1
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter


            'txt = .GetCellRange(1, 1, 1, 1) : txt.Data = "No" : .Cols(1).Width = 61 : .Cols(1).Name = "No" : .Cols(1).AllowMerging = True
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "SupplierName" : .Cols(1).Width = 250 : .Cols(1).Name = "SupplierName" : .Cols(1).TextAlign = TextAlignEnum.LeftCenter : .Cols(1).AllowMerging = True
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "NoCOA" : .Cols(2).Width = 100 : .Cols(2).Name = "NoCOA" : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).AllowMerging = True
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Date" : .Cols(3).Width = 100 : .Cols(3).Name = "Date" : .Cols(3).TextAlign = TextAlignEnum.CenterCenter : .Cols(3).AllowMerging = True

            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "NoInvoice" : .Cols(4).Width = 100 : .Cols(4).Name = "NoInvoice" : .Cols(4).TextAlign = TextAlignEnum.LeftCenter : .Cols(4).AllowMerging = True
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Description" : .Cols(5).Width = 300 : .Cols(5).Name = "Description" : .Cols(5).TextAlign = TextAlignEnum.LeftCenter : .Cols(5).AllowMerging = True

            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Debit" : .Cols(6).Width = 160 : .Cols(6).Name = "Debit" : .Cols(6).Format = "#,###0" : .Cols(6).AllowMerging = True
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Credit" : .Cols(7).Width = 160 : .Cols(7).Name = "Credit" : .Cols(7).Format = "#,###0" : .Cols(7).AllowMerging = True
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Total" : .Cols(8).Width = 160 : .Cols(8).Name = "Total" : .Cols(8).Format = "#,###0" : .Cols(8).AllowMerging = True
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Balance" : .Cols(9).Width = 160 : .Cols(9).Name = "BeginningBalance" : .Cols(9).Format = "#,###0" : .Cols(9).AllowMerging = True

            '.AutoSizeCols()
        End With
    End Sub
    Private Sub CALLDATA()

        HeaderFG()

        connetionStringCUSTOMER = "server=192.168.12.5; database=RSUPAccounting; user=UKoneksi; password=sm@rt2018;  MultipleActiveResultSets=True; connect timeout=0;Max Pool Size=500000  ;"

        connectionCUSTOMER = New SqlConnection(connetionStringCUSTOMER)
        Dim sql, sql2 As String
        If chkRelasi.Checked = True Then
            sql2 = Modul_RMP.Func.SetCondition(sql, "left(SupplierName,8)='" & cmbRelasi.SelectedValue.ToString & "'")

        End If

        sql = " declare @tanggalawal as date
                                                            declare @tanggalakhir as date
                                                            declare @tanggalsebelum as date
                                                            declare @tanggalsaldoawal as date

                                                            set @tanggalawal=CONVERT (DATETIME,'" & DTPStart.Value & "',104)
                                                            set @tanggalakhir=CONVERT (DATETIME,'" & DTPEnd.Value & "',104)
                                                            set @tanggalsaldoawal=DATEADD(DAY, 1 - DATEPART(DAY, @tanggalawal),  @tanggalawal)

                                                            if  DATEPART(DAY, @tanggalawal) = 1
                                                            begin
                                                            set @tanggalsebelum=@tanggalawal
                                                            end 
                                                            else
                                                            begin 
                                                            set @tanggalsebelum= DATEADD(DAY, -1, @tanggalawal)
                                                            end 

                                                            ;with datasaldoawal as (
                                                                select * from RSUPGeneralLedger2018..fndatasaldoawal (@tanggalsaldoawal,@tanggalsebelum)
                                                            ),

                                                            customercard as(
                                                                select 1 as urut , SupplierName,NoCOA,@tanggalsebelum as Date,Noinvoice ,Description,sum(debit) as Debit, sum(credit) as Credit,sum(total) as Total from datasaldoawal
                                                                group by suppliername,nocoa,date,noinvoice ,Description
                                                                
                                                                union 
                                                            
                                                                select * from RSUPGeneralLedger2018..fncustomercard (@tanggalawal,@tanggalakhir)
                                                            )

                                                            select SupplierName,NoCOA, Date, NoInvoice ,Description  , Debit, Credit,Total,SUM(CASE
                                                                    WHEN debit > 0 THEN total
                                                                    WHEN credit > 0 THEN -total
                                                                    ELSE 0
                                                                  END) OVER (PARTITION BY suppliername ORDER BY date,noinvoice) AS BeginningBalance from customercard  where 1=1 " & IIf(sql2 = "", "", " AND " & sql2) & "order by SupplierName,urut,date"



        '  End If
        Try

            connectionCUSTOMER.Open()
            adapterCUSTOMER = New SqlDataAdapter(sql, connectionCUSTOMER)
            adapterCUSTOMER.Fill(DS)
            connectionCUSTOMER.Close()
            fg.DataSource = DS.Tables(0)


            Dim BeginningBalanced As Decimal

            ShowTotals()
            HeaderFG()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub



    Private Sub ShowData()
        Dim i As Integer = 1
        Dim sql As String = ""
        Dim BeginningBalanced As Decimal

        Dim sql2 As String = ""

        'If chktanggal.Checked = True Then
        '    sql = Modul_RMP.Func.SetCondition(sql, " CONVERT(DateTime, Convert(VARCHAR, Date, 104), 104) BETWEEN CONVERT (DATETIME,'" & DTPStart.Value & "',104) AND CONVERT(DATETIME,'" & DTPEnd.Value & "',104)")

        'End If


        If chkRelasi.Checked = True Then
            sql = Modul_RMP.Func.SetCondition(sql, "left(SupplierName,8)='" & cmbRelasi.SelectedValue.ToString & "'")

        End If

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " declare @tanggalawal as date
                                                            declare @tanggalakhir as date
                                                            declare @tanggalsebelum as date
                                                            declare @tanggalsaldoawal as date

                                                            set @tanggalawal=CONVERT (DATETIME,'" & DTPStart.Value & "',104)
                                                            set @tanggalakhir=CONVERT (DATETIME,'" & DTPEnd.Value & "',104)
                                                            set @tanggalsaldoawal=DATEADD(DAY, 1 - DATEPART(DAY, @tanggalawal),  @tanggalawal)

                                                            if  DATEPART(DAY, @tanggalawal) = 1
                                                            begin
                                                            set @tanggalsebelum=@tanggalawal
                                                            end 
                                                            else
                                                            begin 
                                                            set @tanggalsebelum= DATEADD(DAY, -1, @tanggalawal)
                                                            end 

                                                            ;with datasaldoawal as (
                                                                select * from RSUPGeneralLedger2018..fndatasaldoawal (@tanggalsaldoawal,@tanggalsebelum)
                                                            ),

                                                            customercard as(
                                                                select 1 as urut , SupplierName,NoCOA,@tanggalsebelum as Date,Noinvoice ,Description,sum(debit) as Debit, sum(credit) as Credit,sum(total) as Total from datasaldoawal
                                                                group by suppliername,nocoa,date,noinvoice ,Description
                                                           
                                                                union 
                                                            
                                                                select * from RSUPGeneralLedger2018..fncustomercard (@tanggalawal,@tanggalakhir)
                                                            )

                                                            select *,SUM(CASE
                                                                    WHEN debit > 0 THEN total
                                                                    WHEN credit > 0 THEN -total
                                                                    ELSE 0
                                                                  END) OVER (PARTITION BY suppliername ORDER BY date,noinvoice) AS BeginningBalance
	                                                              from customercard 
                                                            where 1=1 " & IIf(sql = "", "", " AND " & sql) & "order by SupplierName,urut,date")

        BeginningBalanced = 0
        If dt.Rows.Count > 0 Then
            With fg
                Call ui.HapusGrid(1, fg)
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, 1) = row.Item("SupplierName")
                    .Item(i, 2) = row.Item("NoCOA") 'IIf(IsDBNull(row.Item("Trip")), "", row.Item("Trip"))
                    .Item(i, 4) = Format(row.Item("Date"), "dd/MM/yyyy")
                    .Item(i, 4) = row.Item("NoInvoice")
                    .Item(i, 5) = row.Item("Description")
                    .Item(i, 6) = row.Item("Debit")
                    .Item(i, 7) = row.Item("Credit")

                    .Item(i, 8) = row.Item("Total")


                    If i = 1 Then
                        BeginningBalanced = row.Item("Total")
                        .Item(i, 8) = BeginningBalanced
                    End If
                    If i > 1 Then
                        Dim A As String
                        A = .Item(i - 1, 1)
                        A = A
                        If row.Item("Debit") > 0 And .Item(i, 1) = A Then
                            BeginningBalanced = BeginningBalanced + row.Item("Total")
                        End If



                        If row.Item("Credit") > 0 And .Item(i, 1) = .Item(i - 1, 1) Then
                            BeginningBalanced = BeginningBalanced - row.Item("Total")
                        End If


                        If .Item(i, 1) <> .Item(i - 1, 1) Then
                            BeginningBalanced = row.Item("Total")
                        End If


                        .Item(i, 8) = BeginningBalanced
                    End If
                    i = i + 1
                Next
                fg.AutoSizeCols() '.AutoSizeCols()
                ShowTotals()

                For X = 1 To .Rows.Count - 1
                    If .Item(X, 4) = "" Then
                        .Item(X, 8) = .Item(X, 6) - .Item(X, 7)
                    End If
                Next
                .Rows(1).AllowMerging = True
            End With
        Else
            Call ui.HapusGrid(1, fg)
            MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
        End If
    End Sub


    Private Sub SubTotal()
        With fg
            .Tree.Column = 0
            .Tree.Style = TreeStyleFlags.CompleteLeaf
            .Subtotal(AggregateEnum.Clear)

            .Subtotal(AggregateEnum.Sum, 0, 1, 6, "{0}")

            .AutoSizeCols()
        End With
    End Sub
    Private Sub ColorSubTotal()
        Dim cs As C1.Win.C1FlexGrid.CellStyle
        With fg
            cs = .Styles(C1.Win.C1FlexGrid.CellStyleEnum.GrandTotal)
            cs.BackColor = Color.SteelBlue

            cs = .Styles(C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0)
            cs.BackColor = Color.FromArgb(156, 206, 255)

        End With
    End Sub
    Private Sub ShowTotals()
        With fg
            .Tree.Column = 0
            .Tree.Style = TreeStyleFlags.CompleteLeaf

            .Subtotal(AggregateEnum.Clear)

            .Subtotal(AggregateEnum.Sum, 0, 1, 6, "Sub Total")
            '.Subtotal(AggregateEnum.Sum, 1, 1, 6)
            .Subtotal(AggregateEnum.Sum, 0, 1, 7)
            '.Subtotal(AggregateEnum.Sum, 1, 1, 7)
            '.Subtotal(AggregateEnum.Sum, 0, 1, 8)
            '.Subtotal(AggregateEnum.Sum, 1, 1, 8)


            '.AutoSizeCols()
        End With
        'Call ColorSubTotal()

    End Sub


    Private Sub fg_AfterSelChange(sender As Object, e As RangeEventArgs)
        Dim sum As Double
        Dim R, c As Integer
        With fg
            If .Row = 0 Then Exit Sub
            If .RowSel > .Row Then
                For R = .Row To .RowSel
                    If (R > 0) And (R <= (.Rows.Count - 1)) Then
                        For c = .Col To .ColSel
                            Select Case c
                                Case 24, 24, 25, 26, 27, 28, 41, 45, 46, 47, 48, 48, 40, 41
                                    If Trim(.Item(R, c) <> 0) Then
                                        sum = sum + CDbl(.Item(R, c))
                                    End If
                            End Select
                        Next
                    End If
                Next
            End If
        End With
        txtSum.Text = FormatNumber(sum, 0)
    End Sub

    Private Sub chkrelasi_CheckedChanged(sender As Object, e As EventArgs) Handles chkRelasi.CheckedChanged
        Call UI.ChkCondCmb(chkRelasi, cmbRelasi, "Relasi")
    End Sub


    Private Sub cmbrelasi_Validated(sender As Object, e As EventArgs) Handles cmbRelasi.Validated
        chkRelasi.Checked = IIf(cmbRelasi.Text = "", False, True)
    End Sub



    Private Sub cmbrelasi_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbRelasi.KeyUp
        UI.AutoCompleteCombo_KeyUp(cmbRelasi, e)
    End Sub




    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Dim filename As String
        Me.SaveFileDialog.ShowDialog()
        filename = SaveFileDialog.FileName
        Me.fg.SaveExcel(filename & ".xls", "Sheet1", FileFlags.IncludeFixedCells)
    End Sub



    Private Function DeleteNota(ByVal NoNota As String)
        Dim Remark, pesan As String
        Dim X As DataTable = New DataTable()

        Remark = InputBox("Isi Remark Hapus:  ", "")
        X = db.ExecuteQuery(StrConnRMPApp,
            "Update TblTrnKelapaHdr set Deleted = 1, " &
            "DeletedRemark = '" & Remark & "', " &
            "DeletedBy = '" & ClsSession.UserID & "', " &
            "DeletedDate = GETDATE() where NoNota = '" & NoNota & "'")
        pesan = MsgBox("Completed", vbInformation, AT)
        Return pesan
    End Function


    Private Sub cmbrelasi_Validating(sender As Object, e As CancelEventArgs) Handles cmbRelasi.Validating
        If cmbRelasi.Text = "" Then
            Exit Sub
        End If

        If IsNothing(cmbRelasi.SelectedValue) Then
            MsgBox("Pilihan tidak ada !", vbExclamation, AT)
            cmbRelasi.Text = ""
            cmbRelasi.Focus()
        End If
    End Sub



    Private Sub PrintNota()
        Dim i As Integer = 2
        For Each row As DataRow In dt.Rows
            FrmFotoNota.Foto = "Nota"
            FrmFotoNota.images = fg.Item(i, 56)
            FrmFotoNota.ShowDialog()
        Next
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Call ui.HapusGrid(1, fg)
        fg.Clear()
        fg.Row = 0
        fg.Col = 0
        fg.DataSource = Nothing
        '
        fg.Clear(C1.Win.C1FlexGrid.ClearFlags.Content)
        DS.Clear()
        DS.Tables.Clear()
        DS.Tables.Clear()

        CALLDATA()
    End Sub

End Class


