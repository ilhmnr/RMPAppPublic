Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports C1.Win.C1FlexGrid
Imports Spire.Pdf
Imports System.IO
Imports System.Data
Imports System.ComponentModel
Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Globalization

Public Class FrmTrnAbsensiPancangLemburApproval
    Dim cls As New ClsDatabaseConnection
    Dim Status_ As Integer
    Public Bagian_, StatusJbt, Perintah As String
    Public Ind As Boolean
    Dim nameBerkas, nameshow, destPath, PathPng As String

    Dim Teks As String
    Dim nm As String
    Dim ClsRelasiLoyal_ As New ClsRelasiLoyal
    Dim adapter, ADAPTER2, ADAPTER3 As SqlDataAdapter
    Dim connetionString, connetionString2 As String
    Dim connection, connection2 As SqlConnection
    Dim sumbrutoperrelasi As Double

    Dim TotalAllMonth As Double

    Dim TotalPerKK As Double
    Dim TotalPerPancang As Double

    Dim lopkk As Integer
    Dim loppcg As Integer
    Dim intensitas As Integer
    Dim NoInvoice_ As String

    Public pathFile As String = UrlMasterTTPancnag & "PersonilPancang\"



    Dim openfoto As Byte
    Private Sub FrmMstPersonilPancangNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Perintah = Perintah

        dtp1.Value = Format(Now, "yyyy-MM-dd")
        dtp2.Value = Format(Now, "yyyy-MM-dd")

        GroupBox2.Enabled = True

        dtp1.Value = Format(Now, "yyyy-MM-01")
        dtp2.Value = Format(Now, "yyyy-MM-15")
        fg.Rows.Count = 1
        fg2.Rows.Count = 1

        'sch()


    End Sub



    Public Sub clear()
        txtinvoice.Text = ""

    End Sub


    Public Sub cmdEnabled(flag As Boolean)
        btnSave.Enabled = Not flag

    End Sub





    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim dt2 As DataTable
        Dim TANGGALLIBUR As String
        TANGGALLIBUR = Format(dtp1.Value, "yyyy-MM-dd")
        dt2 = DB.ExecuteQuery(StrConnRMPApp, "  insert into tblMstHariLiburNasional (tanggal, keterangan)
            (select harilibur,keterangan  from  [192.168.12.12].[RSUPPAYROLL].[dbo].[tblMstHariLiburNasional] where year(harilibur)>=year('" & TANGGALLIBUR & "')  and month(harilibur)=month('" & TANGGALLIBUR & "')
            And harilibur Not in (select tanggal from  tblMstHariLiburNasional where year(tanggal)=year('" & TANGGALLIBUR & "') and month(tanggal)=month('" & TANGGALLIBUR & "'))) ")





        Call UI.HapusGrid(1, fg)
        fg.Clear()
        fg.Row = 0
        fg.Col = 0
        fg.DataSource = Nothing
        '
        fg.Clear(C1.Win.C1FlexGrid.ClearFlags.Content)
        DS.Clear()
        DS.Tables.Clear()
        DS.Tables.Clear()

        Call UI.HapusGrid(1, fg2)
        fg2.Clear()
        fg2.Row = 0
        fg2.Col = 0
        fg2.DataSource = Nothing
        '
        fg2.Clear(C1.Win.C1FlexGrid.ClearFlags.Content)
        DS2.Clear()
        DS2.Tables.Clear()
        DS2.Tables.Clear()


        CALLDATA()
        CALLDATAvolume()



        With fg
            .AutoSizeCols()
            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)
            .AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free
            .Cols.Frozen = 5
            .AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free
            .Cols(3).AllowMerging = True
            .Cols(5).AllowMerging = True
        End With

        With fg2
            .AutoSizeCols()
            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)
            .AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free
            .Cols.Frozen = 5
            .AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free
            .Cols(3).AllowMerging = True
            .Cols(5).AllowMerging = True
        End With

        GrandTotal()
        GrandTotal2()

        CEKHL()

    End Sub
    Private Sub GrandTotal()
        With fg
            .Tree.Column = 0
            .Tree.Style = TreeStyleFlags.CompleteLeaf
            .Subtotal(AggregateEnum.Clear)

            For I = 7 To fg.Cols.Count - 1
                .Subtotal(AggregateEnum.Sum, -1, -1, I, "TOTAL")
                '.Subtotal(AggregateEnum.Sum, 0, 1, I, "KK-{0}")
            Next I
            '.Subtotal(AggregateEnum.Sum, 0, 1, 24)

            .AutoSizeCols()
        End With

    End Sub




    'Private Function SaveTrnAbsensiHdr(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
    '    Dim MyCMD As New SqlCommand
    '    Try
    '        With MyCMD
    '            Dim MyCon As SqlConnection = Conn
    '            Dim MyConTrans As SqlTransaction = Trans
    '            .Connection = MyCon
    '            .CommandType = CommandType.StoredProcedure
    '            .CommandText = "RMPApp..spSaveTrnAbsensiHdrAQWE"
    '            .Transaction = MyConTrans
    '            '.Parameters.Add("@RETURN_VALUE", SqlDbType.SmallInt).Direction = ParameterDirection.ReturnValue
    '            .Parameters.Add("@Perintah", SqlDbType.VarChar, 10).Value = "Add"
    '            .Parameters.Add("@NoInvoice", SqlDbType.VarChar, 30).Value = "001/ABSN/052023"
    '            .Parameters.Add("@periode1", SqlDbType.DateTime).Value = dtp1.Value
    '            .Parameters.Add("@periode2", SqlDbType.DateTime).Value = dtp2.Value
    '            .Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
    '            .Parameters.Add(New SqlParameter("@Error", SqlDbType.VarChar, 200, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
    '            .ExecuteNonQuery()
    '            .Dispose()
    '        End With
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message & " infosp : " & MyCMD.Parameters("@Error").Value)
    '        Return False
    '    End Try
    '    Return True
    'End Function



    Private Function SaveTrnAbsensiDtl(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal i As Integer, ByVal tanggal As Date, ByVal lembur As Double, ByVal VOLUME As Double) As Boolean
        Dim MyCMD As New SqlCommand
        Try
            With MyCMD
                .Connection = Conn
                .CommandType = CommandType.StoredProcedure
                .CommandText = "RMPApp..sp_SaveTrnAbsensi"
                .Transaction = Trans
                .Parameters.Add("@RETURN_VALUE", SqlDbType.SmallInt).Direction = ParameterDirection.ReturnValue
                .Parameters.Add("@NoTransaksi", SqlDbType.VarChar, 20).Value = NoInvoice_
                .Parameters.Add("@IDPersonil", SqlDbType.VarChar, 100).Value = fg.Item(i, "IDPersonil")
                .Parameters.Add("@NamaPersonil", SqlDbType.VarChar).Value = fg.Item(i, "NamaPersonil")
                .Parameters.Add("@Status", SqlDbType.VarChar).Value = fg.Item(i, "Status")
                .Parameters.Add("@Bagian", SqlDbType.VarChar).Value = fg.Item(i, "Bagian")
                .Parameters.Add("@Pancang", SqlDbType.VarChar).Value = fg.Item(i, "Pancang")
                .Parameters.Add("@HL", SqlDbType.VarChar).Value = fg.Item(i, "HL")
                .Parameters.Add("@Tanggal", SqlDbType.Date).Value = tanggal
                .Parameters.Add("@Lembur", SqlDbType.Decimal).Value = lembur
                .Parameters.Add("@Volume", SqlDbType.Decimal).Value = VOLUME
                .Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
                .Parameters.Add(New SqlParameter("@Error", SqlDbType.VarChar, 200, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
                .ExecuteNonQuery()
                .Dispose()
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message & " infosp : " & MyCMD.Parameters("@Error").Value)


            Return False
        End Try
        Return True
    End Function

    Private Sub fg2_Click(sender As Object, e As EventArgs) Handles fg2.Click

    End Sub

    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        Dim result As DialogResult = MessageBox.Show("Yakin Approve Absensi '" & dtp1.Value & "' s/d  '" & dtp2.Value & "' ", "caption", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Cancel Then
            MessageBox.Show("Cancel pressed")
        ElseIf result = DialogResult.Yes Then
            Dim Koneksi As SqlConnection = DB.OpenConnection(StrConnRMPApp)
            Dim Transaksi As SqlTransaction
            Transaksi = Koneksi.BeginTransaction
            Me.Cursor = Cursors.WaitCursor

            Try

                Dim dt2 As DataTable

                dt2 = DB.ExecuteQuery(StrConnRMPApp, "UPDATE tbl_Absensi_Pancang_PSN_Hdr
                                        SET FlagApprove =1,ApproveBy='" & ClsSession.UserID & "',ApproveDate=GETDATE()
                                        WHERE NoTransaksi= '" & LTrim(txtinvoice.Text) & "' ")
            Catch ex As Exception
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Transaksi.Rollback()
                Koneksi.Close()
                Me.Cursor = Cursors.Default
            Finally
                Koneksi.Close()
                Me.Cursor = Cursors.Default
            End Try
            FrmTrnAbsensiPancangLembur.ShowData()
        End If




    End Sub

    Private Function SaveTrnAbsensiHdr(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        Dim MyCMD As New SqlCommand
        Try
            With MyCMD
                Dim MyCon As SqlConnection = Conn
                Dim MyConTrans As SqlTransaction = Trans
                .Connection = MyCon
                .CommandType = CommandType.StoredProcedure
                .CommandText = "RMPApp..spSaveTrnAbsensiHdr"
                .Transaction = MyConTrans
                .Parameters.Add("@RETURN_VALUE", SqlDbType.SmallInt).Direction = ParameterDirection.ReturnValue
                .Parameters.Add("@Perintah", SqlDbType.VarChar, 30).Value = "Add"
                .Parameters.Add(New SqlParameter("@NoInvoice", SqlDbType.VarChar, 20, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
                .Parameters.Add("@Noinvoice2", SqlDbType.VarChar, 30).Value = txtinvoice.Text
                .Parameters.Add("@periode1", SqlDbType.DateTime).Value = dtp1.Value
                .Parameters.Add("@periode2", SqlDbType.DateTime).Value = dtp2.Value
                .Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
                .Parameters.Add(New SqlParameter("@Error", SqlDbType.VarChar, 200, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
                .ExecuteNonQuery()

                If Perintah = "Add" Then
                    NoInvoice_ = .Parameters("@NoInvoice").Value
                Else
                    NoInvoice_ = .Parameters("@NoInvoice2").Value
                End If

                .Dispose()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message & " infosp : " & MyCMD.Parameters("@Error").Value)
            Return False
        End Try
        Return True
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        GrandTotalALL()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim Koneksi As SqlConnection = DB.OpenConnection(StrConnRMPApp)
        Dim Transaksi As SqlTransaction
        Transaksi = Koneksi.BeginTransaction
        Me.Cursor = Cursors.WaitCursor
        Try


            Dim i As Integer
            If SaveTrnAbsensiHdr(Koneksi, Transaksi) = False Then
                Transaksi.Rollback()
                Transaksi = Nothing
                Me.Cursor = Cursors.Default
                MessageBox.Show("Simpan Data Hdr Gagal !", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Try
            End If

            With fg
                Dim datacashback As Integer
                datacashback = 0
                For i = 1 To .Rows.Count - 1
                    If IsNothing(fg.Item(i, "IDPersonil")) = False Then


                        For a = 7 To fg.Cols.Count - 2 '
                            Dim lembur, VOLUME As Double
                            lembur = 0
                            VOLUME = 0
                            If IsDBNull(fg.Item(i, a)) = True Then
                                lembur = 0
                            Else
                                lembur = fg.Item(i, a)



                            End If

                            If IsDBNull(fg2.Item(i, a)) = True Then
                                VOLUME = 0
                            Else
                                VOLUME = fg2.Item(i, a)
                            End If

                            If SaveTrnAbsensiDtl(Koneksi, Transaksi, i, fg.Item(0, a), lembur, VOLUME) = False Then
                                Transaksi.Rollback()
                                Transaksi = Nothing
                                Me.Cursor = Cursors.Default
                                MessageBox.Show("Simpan data gagal!", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                                Exit Try
                            End If
                        Next a
                    End If
                Next i
            End With


            Transaksi.Commit()
            Me.Cursor = Cursors.Default
            MessageBox.Show("Simpan Data Berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Transaksi.Rollback()
            Koneksi.Close()
            Me.Cursor = Cursors.Default
        Finally
            Koneksi.Close()
            Me.Cursor = Cursors.Default
        End Try


    End Sub

    Private Sub btnexcel_Click(sender As Object, e As EventArgs) Handles btnexcel.Click
        Dim filename As String
        Me.SaveFileDialog.ShowDialog()
        filename = SaveFileDialog.FileName
        Me.fg.SaveExcel(filename & ".xls", "Sheet1", FileFlags.IncludeFixedCells)
        MsgBox("Convert Success !", MsgBoxStyle.Information, AT)
    End Sub
    Private Sub CEKHL()
        If Perintah = "Add" Then
            Dim dt As DataTable
            Dim dt2 As DataTable
            For a = 2 To fg.Rows.Count - 1
                Dim JUMLAHJAM, JUMLAHJAMSISA, JUMLAH As Integer
                JUMLAHJAMSISA = 0
                JUMLAHJAM = 0
                JUMLAHJAM = 0
                For COLU = fg.Cols.Count - 2 To 7 Step -1



                    Dim cs, CS2, cs3 As CellStyle

                    cs = fg.Styles.Add("redValue")
                    cs.BackColor = Color.LightPink

                    CS2 = fg.Styles.Add("WHITEValue")
                    CS2.BackColor = Color.White

                    cs3 = fg.Styles.Add("YellowValue")
                    cs3.BackColor = Color.FromArgb(255, 255, 192)




                    Dim x As String
                    Dim N As String
                    x = (CType(fg.Item(0, COLU), DateTime)).DayOfWeek.ToString
                    x = x
                    N = Format(CType(fg.Item(0, COLU), DateTime), "yyyy-MM-dd")
                    dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " Select TANGGAL  FROM RMPApp..tblMstHariLiburNasional  WHERE tanggal ='" & N & "' ")

                    If x = fg.Item(a, 6) Or dt.Rows.Count > 0 Then

                        If IsDBNull(fg.Item(a, COLU)) = True Then
                            JUMLAH = 0
                        Else
                            JUMLAH = fg.Item(a, COLU)
                        End If

                        JUMLAHJAM = JUMLAH + JUMLAHJAMSISA
                        If JUMLAHJAM > 6 Then
                            fg.Item(a, COLU) = 6
                            JUMLAHJAMSISA = JUMLAHJAM - 6
                        Else
                            fg.Item(a, COLU) = JUMLAHJAM
                            JUMLAHJAMSISA = 0
                        End If
                        JUMLAHJAMSISA = JUMLAHJAMSISA
                        fg.SetCellStyle(a, COLU, cs)

                    End If

                    dt2 = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " Select TANGGAL  FROM RMPApp..TblAbsensiManualPersonilPCG  WHERE tanggal ='" & N & "' and idpersonil='" & fg.Item(a, 1) & "' and Kehadiran='" & fg.Item(a, 4) & "'  ")


                    If dt2.Rows.Count > 0 Then


                        fg.SetCellStyle(a, COLU, cs3)

                    End If

                Next



            Next
        Else
            Dim dt As DataTable
            For a = 2 To fgall.Rows.Count - 1

                For COLU = fgall.Cols.Count - 3 To 7 Step -1


                    Dim cs, CS2 As CellStyle

                    cs = fgall.Styles.Add("redValue")
                    cs.BackColor = Color.LightPink

                    CS2 = fgall.Styles.Add("WHITEValue")
                    CS2.BackColor = Color.White

                    Dim x As String
                    Dim N As String
                    x = (CType(Replace(fgall.Item(0, COLU), " (Volume)", ""), DateTime)).DayOfWeek.ToString
                    x = x
                    N = Format((CType(Replace(fgall.Item(0, COLU), " (Volume)", ""), DateTime)), "yyyy-MM-dd")
                    dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " Select TANGGAL  FROM RMPApp..tblMstHariLiburNasional  WHERE tanggal ='" & N & "' ")

                    If x = fgall.Item(a, 6) Or dt.Rows.Count > 0 Then


                        fgall.SetCellStyle(a, COLU, cs)

                    End If



                Next



            Next
        End If
    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        CEKHL()

    End Sub

    Private Sub btnrefreshh_Click(sender As Object, e As EventArgs) Handles btnrefreshh.Click
        Me.Dispose()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Perintah = "Add" Then
            Dim dt As DataTable
            Dim dt2 As DataTable
            For a = 2 To fg.Rows.Count - 1
                Dim JUMLAHJAM, JUMLAHJAMSISA, JUMLAH As Integer
                JUMLAHJAMSISA = 0
                JUMLAHJAM = 0
                JUMLAHJAM = 0

                For COLU = fg.Cols.Count - 2 To 7 Step -1
                    Dim cs, CS2, cs3 As CellStyle

                    cs = fg.Styles.Add("redValue")
                    cs.BackColor = Color.LightPink

                    CS2 = fg.Styles.Add("WHITEValue")
                    CS2.BackColor = Color.White

                    cs3 = fg.Styles.Add("YellowValue")
                    cs3.BackColor = Color.FromArgb(255, 255, 192)

                    Dim x As String
                    Dim N As String
                    x = (CType(fg.Item(0, COLU), DateTime)).DayOfWeek.ToString
                    x = x
                    N = Format(CType(fg.Item(0, COLU), DateTime), "yyyy-MM-dd")

                    dt2 = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " Select TANGGAL  FROM RMPApp..TblAbsensiManualPersonilPCG  WHERE tanggal ='" & N & "' and idpersonil='" & fg.Item(a, 1) & "' and Kehadiran='" & fg.Item(a, 4) & "'  ")

                    If dt2.Rows.Count > 0 Then
                        fg.SetCellStyle(a, COLU, cs3)
                    End If

                Next
            Next

        Else
            Dim dt2 As DataTable
            For a = 2 To fgall.Rows.Count - 1

                For COLU = fgall.Cols.Count - 3 To 7 Step -1
                    Dim cs, CS3 As CellStyle

                    cs = fgall.Styles.Add("redValue")
                    cs.BackColor = Color.LightPink

                    CS3 = fg.Styles.Add("YellowValue")
                    CS3.BackColor = Color.FromArgb(255, 255, 192)

                    Dim x As String
                    Dim N As String
                    x = (CType(Replace(fgall.Item(0, COLU), " (Volume)", ""), DateTime)).DayOfWeek.ToString
                    x = x
                    N = Format((CType(Replace(fgall.Item(0, COLU), " (Volume)", ""), DateTime)), "yyyy-MM-dd")

                    dt2 = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " Select TANGGAL  FROM RMPApp..TblAbsensiManualPersonilPCG  WHERE tanggal ='" & N & "' and idpersonil='" & fg.Item(a, 1) & "' and Kehadiran='" & fg.Item(a, 4) & "'  ")

                    If dt2.Rows.Count > 0 Then
                        fgall.SetCellStyle(a, COLU, CS3)
                    End If

                Next

            Next
        End If
    End Sub

    Private Sub GrandTotal2()
        With fg2
            .Tree.Column = 0
            .Tree.Style = TreeStyleFlags.CompleteLeaf
            .Subtotal(AggregateEnum.Clear)

            For I = 7 To fg2.Cols.Count - 1
                .Subtotal(AggregateEnum.Sum, -1, -1, I, "TOTAL")
            Next I

            .AutoSizeCols()
        End With

    End Sub


    Private Sub CALLDATA()


        connetionString = "server=192.168.12.5; database=RMPAPP; user=UKoneksi; password=sm@rt2018;  MultipleActiveResultSets=True; connect timeout=0;Max Pool Size=500000  ;"

        connection = New SqlConnection(connetionString)
        Dim sql, sql2, bagian As String
        bagian = "P2"
        sql = "declare @StartDate DATE,@EndDate DATE,@cols AS NVARCHAR(MAX),@query  AS NVARCHAR(MAX),@Bagian AS VARCHAR(5)
		                    set @StartDate ='" & Format(dtp1.Value, "yyyy-MM-dd") & "'
		                    set @EndDate ='" & Format(dtp2.Value, "yyyy-MM-dd") & "'
                             set @Bagian ='" & bagian & "'
		               		                            
		                               DECLARE @WorkingDays TABLE (WDate DATE)

                                    ;WITH d (date) AS (
                                        SELECT @StartDate
                                        UNION ALL
                                        SELECT DATEADD(DAY, 1, date)
                                        FROM d
                                        WHERE date < @EndDate
                                    )
                                    INSERT INTO @WorkingDays
                                    SELECT d.date
                                    FROM d

                                    SET @cols = STUFF((
                                            SELECT ',' + QUOTENAME(CONVERT(VARCHAR, wd.WDate, 103)) 
                                            FROM @WorkingDays wd
                                            GROUP BY wd.WDate
                                            ORDER BY wd.WDate ASC
                                            FOR XML PATH(''), TYPE
                                        ).value('.', 'NVARCHAR(MAX)'), 1, 1, '')

                           SET @query = N';WITH tablembur(IDPersonil, NamaPersonil, Pancang, Tanggal, Status, Bagian, JamLembur, HL) AS (
                            SELECT IDPersonil, nama AS NamaPersonil, Pancang, CONVERT(VARCHAR, Tanggal, 103), Kehadiran, Bagian, 
                                CASE WHEN ISNULL(total, 0) > 70000 THEN CAST(ROUND((TOTAL - 70000) / 15000 - 0.499999999, 0) AS INTEGER) ELSE NULL END AS JamLembur, HL
                            FROM fnLemburPancangdaybeforesave(@StartDate, @EndDate) AS A 
                            WHERE total IS NOT NULL  AND bagian = @Bagian
                            UNION
                            SELECT IDPersonil, nama AS NamaPersonil, Pancang, CONVERT(VARCHAR, Tanggal, 103), Kehadiran, Bagian,
                              case when ISNULL(total, 0) >=20000 then   CAST(ROUND((ISNULL(total, 0) / 20000) - 0.49999999, 0) AS INTEGER) end AS JamLembur, HL
                            FROM fnLemburPancangLIBURbeforesave(@StartDate, @EndDate) AS A
                            WHERE tanggal IS NOT NULL AND total IS NOT NULL AND bagian = @Bagian
                        ),
   
                        datalembur AS (
                            SELECT *
                            FROM tablembur
                            PIVOT (
                                SUM(JamLembur)
                                FOR Tanggal IN (' + @cols + ')
                            ) AS pvtlembur
   
    
                        )
  
                    SELECT datalembur.*,0 as Total from datalembur ORDER BY Pancang asc '
                    EXECUTE sp_executesql @query, N'@StartDate DATE, @EndDate DATE, @Bagian VARCHAR(5)', @StartDate, @EndDate, @Bagian"




        Try
            connection.Open()
            adapter = New SqlDataAdapter(sql, connection)
            adapter.Fill(DS)
            connection.Close()
            fg.DataSource = DS.Tables(0)

            'TotalAllMonth = 0
            'TotalPerKK = 0
            'TotalPerPancang = 0

            'Dim intensitasrelasi, dblHighValue As Double
            'Dim maxV As Integer
            'Dim minV As Integer

            Dim totalrel As Integer
            Dim COLU As Integer
            For a = 1 To fg.Rows.Count - 1
                totalrel = 0
                fg.Item(a, 0) = a

                For COLU = 7 To fg.Cols.Count - 1
                    If Not IsDBNull(fg.Item(a, COLU)) Then
                        If Val(fg.Item(a, COLU)) > 0 Then
                            totalrel = fg.Item(a, COLU) + totalrel
                        End If
                    End If
                    fg.Cols(COLU).Format = "#,###0"


                Next
                fg.Item(a, fg.Cols.Count - 1) = totalrel


            Next



            fg.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub


    Private Sub CALLDATAvolume()


        connetionString2 = "server=192.168.12.5; database=RMPAPP; user=UKoneksi; password=sm@rt2018;  MultipleActiveResultSets=True; connect timeout=0;Max Pool Size=500000  ;"

        connection2 = New SqlConnection(connetionString2)
        Dim sql, sql2, bagian As String


        bagian = "P2"




        sql2 = "declare @StartDate DATE,@EndDate DATE,@cols AS NVARCHAR(MAX),@query  AS NVARCHAR(MAX),@Bagian AS VARCHAR(5)
		                                set @StartDate ='" & Format(dtp1.Value, "yyyy-MM-dd") & "'
		                                set @EndDate ='" & Format(dtp2.Value, "yyyy-MM-dd") & "'
                                         set @Bagian ='" & bagian & "'
                                        DECLARE @WorkingDays TABLE (WDate DATE)

                                        ;WITH d (date) AS (
                                            SELECT @StartDate
                                            UNION ALL
                                            SELECT DATEADD(DAY, 1, date)
                                            FROM d
                                            WHERE date < @EndDate
                                        )
                                        INSERT INTO @WorkingDays
                                        SELECT d.date
                                        FROM d

                                        SET @cols = STUFF((
                                                SELECT ',' + QUOTENAME(CONVERT(VARCHAR, wd.WDate, 103)) 
                                                FROM @WorkingDays wd
                                                GROUP BY wd.WDate
                                                ORDER BY wd.WDate ASC
                                                FOR XML PATH(''), TYPE
                                            ).value('.', 'NVARCHAR(MAX)'), 1, 1, '')
                                      SET @query = N'; with tabvolume(IDPersonil, NamaPersonil, Pancang, Tanggal, Status, Bagian, volume, HL) AS (
                                    SELECT IDPersonil, nama AS NamaPersonil, Pancang, CONVERT(VARCHAR, Tanggal, 103) , Kehadiran, Bagian, total AS volume, HL
                                    FROM fnLemburPancangdaybeforesave(@StartDate, @EndDate) AS A
                                    WHERE total IS NOT NULL AND bagian = @Bagian
                                    UNION
                                    SELECT IDPersonil, nama AS NamaPersonil, Pancang, CONVERT(VARCHAR, Tanggal, 103) , Kehadiran, Bagian, total AS volume, HL
                                    FROM fnLemburPancangLIBURbeforesaveVOLUME(@StartDate, @EndDate) AS A
                                    WHERE tanggal IS NOT NULL AND total IS NOT NULL AND bagian = @Bagian
                                ),
   
                                 datavolume AS (
                                    SELECT *
                                    FROM tabvolume
                                    PIVOT (
                                        SUM(volume)
                                        FOR Tanggal IN (' + @cols + ')
                                    ) AS pvtvolume
   
    
                                )
  
                            SELECT datavolume.* ,0 as Total  from datavolume  ORDER BY Pancang asc '
                            EXECUTE sp_executesql @query, N'@StartDate DATE, @EndDate DATE, @Bagian VARCHAR(5)', @StartDate, @EndDate, @Bagian"


        Try
            connection2.Open()
            ADAPTER2 = New SqlDataAdapter(sql2, connection)
            ADAPTER2.Fill(DS2)
            connection2.Close()
            fg2.DataSource = DS2.Tables(0)

            'TotalAllMonth = 0
            'TotalPerKK = 0
            'TotalPerPancang = 0

            'Dim intensitasrelasi, dblHighValue As Double
            'Dim maxV As Integer
            'Dim minV As Integer

            Dim totalrel As Integer
            Dim COLU As Integer
            For a = 1 To fg2.Rows.Count - 1
                totalrel = 0
                fg2.Item(a, 0) = a

                For COLU = 7 To fg2.Cols.Count - 1
                    If Not IsDBNull(fg2.Item(a, COLU)) Then
                        If Val(fg2.Item(a, COLU)) > 0 Then
                            totalrel = fg2.Item(a, COLU) + totalrel
                        End If
                    End If
                    fg2.Cols(COLU).Format = "#,###0"
                Next
                fg2.Item(a, fg2.Cols.Count - 1) = totalrel
            Next



            fg2.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub



    Public Sub CALLDATAall(notrans As String)
        '
        fgall.Clear(C1.Win.C1FlexGrid.ClearFlags.Content)
        DS3.Clear()

        connetionString = "server=192.168.12.5; database=RMPAPP; user=UKoneksi; password=sm@rt2018;  MultipleActiveResultSets=True; connect timeout=0;Max Pool Size=500000  ;"

        connection = New SqlConnection(connetionString)
        Dim sql, sql2, bagian As String


        bagian = "P2"
        sql = "DECLARE @NoTransaksi  AS NVARCHAR(MAX)  , @StartDate DATE, @EndDate DATE, @cols AS NVARCHAR(MAX), @colsVolume AS NVARCHAR(MAX),@colsall AS NVARCHAR(MAX), @query AS NVARCHAR(MAX), @Bagian AS VARCHAR(5)

                        SET @NoTransaksi ='" & notrans & "'
                       set @StartDate ='" & Format(dtp1.Value, "yyyy-MM-dd") & "'
		               set @EndDate ='" & Format(dtp2.Value, "yyyy-MM-dd") & "'

                        DECLARE @WorkingDays TABLE (WDate DATE)

                        ;WITH d(date) AS (
                            SELECT CAST(@StartDate AS DATETIME)
                            UNION ALL
                            SELECT DATEADD(DAY, 1, date)
                            FROM d
                            WHERE date < @EndDate
                        )
                        INSERT INTO @WorkingDays
                        SELECT d.date
                        FROM d

                        SET @cols = STUFF((
                                SELECT ',' + QUOTENAME(CONVERT(VARCHAR, wd.WDate, 103)) 
                                FROM @WorkingDays wd
                                GROUP BY wd.WDate
                                ORDER BY wd.WDate ASC
                                FOR XML PATH(''), TYPE
                            ).value('.', 'NVARCHAR(MAX)'), 1, 1, '')

                        SET @colsall = STUFF((
                                SELECT ',' + QUOTENAME(CONVERT(VARCHAR, wd.WDate, 103)) + ',' + QUOTENAME(CONVERT(VARCHAR, wd.WDate, 103) + ' (Volume)')
                                FROM @WorkingDays wd
                                GROUP BY wd.WDate
                                ORDER BY wd.WDate ASC
                                FOR XML PATH(''), TYPE
                            ).value('.', 'NVARCHAR(MAX)'), 1, 1, '')

	
                        SET @colsVolume  = STUFF((
                                SELECT  ',' + QUOTENAME(CONVERT(VARCHAR, wd.WDate, 103) + + ' (Volume)')
                                FROM @WorkingDays wd
                                GROUP BY wd.WDate
                                ORDER BY wd.WDate ASC
                                FOR XML PATH(''), TYPE
		                           ).value('.', 'NVARCHAR(MAX)'), 1, 1, '')


                        SET @query = ';WITH tablembur(IDPersonil, NamaPersonil, Pancang, Tanggal, Status, Bagian, JamLembur, HL) AS (
                                SELECT IDPersonil, NamaPersonil, Pancang, CONVERT(VARCHAR, Tanggal, 103), Status, Bagian, Lembur AS JamLembur, HL
                                FROM tbl_Absensi_Pancang_PSN_Dtl where notransaksi= '''+@NoTransaksi +'''
			                         ),

	                        tabvolume(IDPersonil, NamaPersonil, Pancang, Tanggal, Status, Bagian, volume, HL) AS (
                              SELECT IDPersonil, NamaPersonil, Pancang, CONVERT(VARCHAR, Tanggal, 103) +'' (Volume)'', Status, Bagian, Volume AS Volume, HL
                                FROM tbl_Absensi_Pancang_PSN_Dtl where notransaksi= '''+@NoTransaksi +'''
                            ),

                            datalembur AS (
                                SELECT *
                                FROM tablembur
                                PIVOT (
                                    SUM(JamLembur)
                                    FOR Tanggal IN (' + @cols + ')
                                ) AS pvtlembur
                            ),
                            datavolume AS (
                                SELECT *
                                FROM tabvolume
                                PIVOT (
                                    SUM(volume)
                                    FOR Tanggal IN ('+@colsVolume+')
                                ) AS pvtvolume
                            )
  

  
                              SELECT datalembur.IDPersonil, datalembur.NamaPersonil, datalembur.Pancang,  datalembur.Status, datalembur.Bagian,datalembur.HL, '+@colsall+',0 AS TotalJamLembur, 0 AS TotalVolume
                        FROM datalembur
                        INNER JOIN datavolume ON datalembur.IDPersonil = datavolume.IDPersonil AND 
						datalembur.Pancang=datavolume.PANCANG AND 
							datalembur.Status=datavolume.Status AND 
							datalembur.Bagian=datavolume.Bagian AND 
								datalembur.HL=datavolume.HL   ORDER BY datalembur.Pancang  asc
                         '
                        EXECUTE(@query)
                        --print @query"




        Try
            connection.Open()
            ADAPTER3 = New SqlDataAdapter(sql, connection)
            ADAPTER3.Fill(DS3)
            connection.Close()
            fgall.DataSource = DS3.Tables(0)

            'TotalAllMonth = 0
            'TotalPerKK = 0
            'TotalPerPancang = 0

            'Dim intensitasrelasi, dblHighValue As Double
            'Dim maxV As Integer
            'Dim minV As Integer

            Dim totalrel, totalvol As Integer
            Dim COLU As Integer
            For a = 1 To fgall.Rows.Count - 1
                totalrel = 0
                totalvol = 0
                fgall.Item(a, 0) = a

                For COLU = 7 To fgall.Cols.Count - 1
                    If Not IsDBNull(fgall.Item(a, COLU)) Then
                        If Val(fgall.Item(a, COLU)) > 0 And Strings.Right(fgall.Item(0, COLU), 8) <> "(Volume)" Then
                            Dim C As String
                            C = Strings.Right(fgall.Item(0, COLU), 8)
                            C = C
                            totalrel = fgall.Item(a, COLU) + totalrel
                        Else

                            'fgall.Item(a, COLU) = ""

                        End If
                    End If

                Next

                For COLU = 7 To fgall.Cols.Count - 1
                    If Not IsDBNull(fgall.Item(a, COLU)) Then
                        If Val(fgall.Item(a, COLU)) > 0 And Strings.Right(fgall.Item(0, COLU), 8) = "(Volume)" Then
                            totalvol = fgall.Item(a, COLU) + totalvol
                        Else

                        End If
                    End If
                    fgall.Cols(COLU).Format = "#,###0"
                Next

                fgall.Item(a, fgall.Cols.Count - 2) = totalrel
                fgall.Item(a, fgall.Cols.Count - 1) = totalvol
            Next



            fgall.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub


    Public Sub GrandTotalALL()
        With fgall
            .Tree.Column = 0
            .Tree.Style = TreeStyleFlags.CompleteLeaf
            .Subtotal(AggregateEnum.Clear)

            For I = 7 To fgall.Cols.Count - 1
                .Subtotal(AggregateEnum.Sum, -1, -1, I, "TOTAL")

            Next I


            .AutoSizeCols()
        End With

    End Sub

    Private Sub txtUangMakan_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Tab Then
            dtp1.Focus()
        End If
    End Sub

    Private Sub btnexit_Click(sender As Object, e As EventArgs)
        Me.Dispose()
    End Sub


    Private Sub DTP1_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Tab Then
            dtp2.Focus()
        End If
    End Sub

    Private Sub fgall_AfterSelChange(sender As Object, e As RangeEventArgs) Handles fgall.AfterSelChange
        On Error Resume Next
        Dim sum As Double
        Dim R, c As Integer
        With fgall
            If .Row = 0 Then Exit Sub
            If .RowSel > .Row Then
                For R = .Row To .RowSel
                    If (R > 0) And (R <= (.Rows.Count - 1)) Then
                        For c = .Col To .ColSel
                            Select Case c
                                Case 7, 8, 9, 10, 11, 12, 13, 14, 15, 18, 23, 25, 27, 28, 29, 30, 31, 32
                                    If Trim(.Item(R, c) <> 0) Then
                                        sum = sum + CDbl(.Item(R, c))
                                    End If
                            End Select
                        Next
                    End If
                Next
            End If

        End With
        TextBox1.Text = FormatNumber(sum, 0)
    End Sub
End Class