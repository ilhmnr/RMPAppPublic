Imports System.ComponentModel
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmMstRelasiCekDoc
    Dim nm As String
    Dim ClsRelasiLoyal_ As New ClsRelasiLoyal
    Dim adapter As SqlDataAdapter
    Dim adapter2 As SqlDataAdapter
    Dim connetionString As String
    Dim connection As SqlConnection
    Dim sumbrutoperrelasi As Double

    Dim TotalAllMonth As Double

    Dim TotalPerKK As Double
    Dim TotalPerPancang As Double

    Dim lopkk As Integer
    Dim loppcg As Integer
    Dim intensitas As Integer
    Private Sub FFrmMasterRelasiCekDoc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        nm = "12"

        'UI.ClearText(grpFilterData)
        Modul_RMP.Combo.SetPancang(cmbPancang)
        Modul_RMP.Combo.SetSupplier(cmbS_Petani)
        HeaderFG(fg1)
        HeaderFG(fg2)

        schKg()
        'chkyear.Checked = True
    End Sub

    Private Sub ShowData()
        Cursor = Cursors.WaitCursor
        Application.DoEvents()
        Try
            Dim sqlKg As String = ""
            Dim sqlCrane As String = ""
            Dim sqlButir As String = ""
            Dim diff As Integer

            'ShowDataKg(sqlKg)


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

#Region "Data Kg"
    Private Sub schKg()
        With schfg
            .SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
            .SearchDelay = 2
            .Watermark = "Cari Disini"
            .SetC1FlexGridSearchPanel(fg1, schfg)
        End With
    End Sub
#End Region


    Public Sub HeaderFG(fg As C1FlexGrid)

        Dim txt As CellRange
        With fg
            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
            .Cols.Count = 22
            .Cols.Fixed = 0
            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            '.Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            '.Styles.Alternate.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)
            '.Rows(0).StyleNew.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular)

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 1
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
        End With
        CELL(fg)
    End Sub






    Private Sub CELL(fg As C1FlexGrid)
        Dim txt As CellRange
        With fg

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).Width = 50 : .Cols(0).Name = "No" : .Cols(0).TextAlign = TextAlignEnum.LeftCenter : .Cols(0).AllowMerging = True : .Cols(0).TextAlignFixed = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "GroupKK" : .Cols(1).Width = 80 : .Cols(1).Name = "GroupKK" : .Cols(1).TextAlign = TextAlignEnum.LeftCenter : .Cols(1).AllowMerging = True : .Cols(1).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Nama KK" : .Cols(2).Width = 200 : .Cols(2).Name = "NamaSupUM_" : .Cols(2).AllowMerging = True : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).TextAlignFixed = TextAlignEnum.CenterCenter

            'txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "GroupKK-" : .Cols(2).Name = "KodeSupUM-" : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).AllowMerging = True : .Cols(2).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(2).Visible = False

            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "GroupKK" : .Cols(3).Name = "KodeSupUM" : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).AllowMerging = True : .Cols(3).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(3).Visible = False
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Nama KK" : .Cols(4).Name = "NamaSupUM" : .Cols(4).TextAlign = TextAlignEnum.LeftCenter : .Cols(4).AllowMerging = True : .Cols(4).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(4).Visible = False


            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "ID Relasi" : .Cols(5).Width = 80 : .Cols(5).Name = "KodeSup" : .Cols(5).TextAlign = TextAlignEnum.LeftCenter : .Cols(5).AllowMerging = True : .Cols(5).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Nama Relasi" : .Cols(6).Width = 200 : .Cols(6).Name = "NamaSup" : .Cols(6).TextAlign = TextAlignEnum.LeftCenter : .Cols(6).AllowMerging = True : .Cols(6).TextAlignFixed = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Divisi/Kavling" : .Cols(7).Width = 200 : .Cols(7).Name = "DivBlokKav" : .Cols(7).TextAlign = TextAlignEnum.LeftCenter : .Cols(7).AllowMerging = True : .Cols(7).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Alamat" : .Cols(8).Width = 300 : .Cols(8).Name = "Alamat" : .Cols(8).TextAlign = TextAlignEnum.LeftCenter : .Cols(8).AllowMerging = True : .Cols(8).TextAlignFixed = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "NO KTP" : .Cols(9).Name = "KTP" : .Cols(9).Width = 190 : .Cols(9).TextAlign = TextAlignEnum.LeftCenter : .Cols(9).AllowMerging = True : .Cols(9).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(4).Visible = False
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "KTP" : .Cols(10).Name = "FOTOKTP" : .Cols(10).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(10).TextAlign = TextAlignEnum.CenterCenter : .Cols(10).Visible = False

            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "NO NPWP" : .Cols(11).Name = "NPWP" : .Cols(11).Visible = False : .Cols(11).TextAlign = TextAlignEnum.LeftCenter : .Cols(11).AllowMerging = True : .Cols(11).Width = 180 : .Cols(11).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(4).Visible = False
            txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "NPWP" : .Cols(12).Name = "FOTONPWP" : .Cols(12).TextAlign = TextAlignEnum.CenterCenter : .Cols(12).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(12).Visible = False
            txt = .GetCellRange(0, 13, 0, 13) : txt.Data = "SURAT LAHAN" : .Cols(13).Name = "SURATLAHAN" : .Cols(13).TextAlign = TextAlignEnum.CenterCenter : .Cols(13).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(13).Visible = False
            txt = .GetCellRange(0, 14, 0, 14) : txt.Data = "CHECK" : .Cols(14).Name = "CHECKED" : .Cols(14).DataType = GetType(Boolean) : .Cols(14).Visible = False
            txt = .GetCellRange(0, 15, 0, 15) : txt.Data = "FSURAT" : .Cols(15).Name = "FSURAT" : .Cols(15).Visible = False


            txt = .GetCellRange(0, 16, 0, 16) : txt.Data = "NotActive" : .Cols(16).Name = "NotActive" : .Cols(16).TextAlign = TextAlignEnum.LeftCenter : .Cols(16).AllowMerging = True : .Cols(16).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(16).DataType = GetType(Boolean)
            txt = .GetCellRange(0, 17, 0, 17) : txt.Data = "RemarkInActive" : .Cols(17).Width = 100 : .Cols(17).Name = "RemarkInActive" : .Cols(17).TextAlign = TextAlignEnum.LeftCenter : .Cols(17).AllowMerging = True : .Cols(17).TextAlignFixed = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 18, 0, 18) : txt.Data = "Foto" : .Cols(18).Width = 50 : .Cols(18).Name = "Foto" : .Cols(18).ImageAlign = TextAlignEnum.CenterCenter : .Cols(18).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 19, 0, 19) : txt.Data = "Foto(Approved)" : .Cols(19).Width = 100 : .Cols(19).Name = "FlagLinkFoto" : .Cols(19).TextAlign = TextAlignEnum.LeftCenter : .Cols(19).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 20, 0, 20) : txt.Data = "LinkFoto" : .Cols(20).Width = 100 : .Cols(20).Name = "LinkFoto" : .Cols(20).TextAlign = TextAlignEnum.LeftCenter : .Cols(20).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(20).Visible = False

            '.AutoSizeCols()()
        End With

    End Sub
    Private Sub HEADERFG2()
        CELL(fg1)
        CELL(fg2)
        fg1.Cols.Frozen = 3
        fg2.Cols.Frozen = 3


    End Sub
    Public Sub FGColor()
        Dim cs As C1.Win.C1FlexGrid.CellStyle
        cs = fg1.Styles(C1.Win.C1FlexGrid.CellStyleEnum.GrandTotal)
        'cs.BackColor = Color.FromArgb(73, 173, 8)
        cs.BackColor = Color.FromArgb(58, 106, 148)
        cs.ForeColor = Color.White
        cs.Font = New Font(Font, FontStyle.Bold)

        cs = fg1.Styles(C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0)
        'cs.BackColor = Color.FromArgb(81, 161, 243)
        'cs.ForeColor = Color.White
        'cs.Font = New Font(Font, FontStyle.Bold)
        cs.BackColor = Color.FromArgb(191, 220, 245)
        cs.ForeColor = Color.Black

        cs = fg1.Styles(C1.Win.C1FlexGrid.CellStyleEnum.Subtotal1)
        cs.BackColor = Color.AliceBlue
        cs.ForeColor = Color.Black




        cs = fg2.Styles(C1.Win.C1FlexGrid.CellStyleEnum.GrandTotal)
        'cs.BackColor = Color.FromArgb(73, 173, 8)
        cs.BackColor = Color.FromArgb(58, 106, 148)
        cs.ForeColor = Color.White
        cs.Font = New Font(Font, FontStyle.Bold)

        cs = fg2.Styles(C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0)
        'cs.BackColor = Color.FromArgb(81, 161, 243)
        'cs.ForeColor = Color.White
        'cs.Font = New Font(Font, FontStyle.Bold)
        cs.BackColor = Color.FromArgb(191, 220, 245)
        cs.ForeColor = Color.Black

        cs = fg2.Styles(C1.Win.C1FlexGrid.CellStyleEnum.Subtotal1)
        cs.BackColor = Color.AliceBlue
        cs.ForeColor = Color.Black

        'fg.AutoSizeCols()
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        fg1.Clear()
        fg1.Row = 0
        fg1.Col = 0
        fg1.DataSource = Nothing

        fg2.Clear()
        fg2.Row = 0
        fg2.Col = 0
        fg2.DataSource = Nothing

        'Call ui.HapusGrid(1, fg)
        fg1.Clear(C1.Win.C1FlexGrid.ClearFlags.Content)
        fg2.Clear(C1.Win.C1FlexGrid.ClearFlags.Content)
        DS.Clear()
        DS.Tables.Clear()
        DS.Tables.Clear()

        DS2.Clear()
        DS2.Tables.Clear()
        DS2.Tables.Clear()

        Call UI.HapusGrid(1, fg1)
        Call UI.HapusGrid(2, fg1)
        CALLDATA()


        Dim sql2 As String = ""

        If chkS_Petani.Checked = True Then
            sql2 = Modul_RMP.Func.SetCondition(sql2, "KodeSup = '" & cmbS_Petani.SelectedValue.ToString & "'")
        End If



        If chkPancang.Checked = True Then
            sql2 = Modul_RMP.Func.SetCondition(sql2, "DivBlokKav in (select DivkavP2 FROM RMPApp..Android_tblMstPancang where IDPancang= '" & cmbPancang.SelectedValue.ToString & "') ")
        End If

        If chkyear.Checked = True Then
            sql2 = Modul_RMP.Func.SetCondition(sql2, " year(Tanggal)=  '" & DOYear.Text & "' ")
        End If

        If chktanggal.Checked = True Then
            sql2 = Modul_RMP.Func.SetCondition(sql2, "Convert(DateTime, Tanggal, 103) between convert(datetime,'" & Format(dtcb1.Value, "dd/MM/yyyy") & "',103) And convert(datetime,'" & Format(dtcb2.Value, "dd/MM/yyyy") & "',103) ")
        End If








        If rdbelumadaktp.Checked = True Then

            Dim DT As DataTable

            DT = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "Select count(kodesup) as countpetani from RSUPAccounting..vwRMMstSupplier where left(kodesup,3)='PCG'  " & IIf(sql2 = "", "", " And " & sql2) & "   ")


        End If

        If rdbelumuploadfoto.Checked = True Then
            Dim DT As DataTable

            DT = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "Select count(kodesup) as countpetani from RSUPAccounting..vwRMMstSupplier where left(kodesup,3)='PCG'  " & IIf(sql2 = "", "", " And " & sql2) & "   ")

        End If




        Dim DT2 As DataTable

        DT2 = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " Select count(kodesup) as countpetani from RSUPAccounting..vwRMMstSupplier where left(kodesup,3)='PCG'  " & IIf(sql2 = "", "", " And " & sql2) & " AND (FotoSupplier  IS NOT NULL )   ")



    End Sub



    Private Sub BtnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Dim filename As String
        Me.SaveFileDialog.ShowDialog()
        filename = SaveFileDialog.FileName
        Me.fg2.SaveExcel(filename & ".xls", "Sheet1", FileFlags.IncludeFixedCells)
        MsgBox("Convert Success !", vbInformation, AT)
    End Sub

    Private Sub CALLDATA()

        HeaderFG(fg1)
        HeaderFG(fg2)
        connetionString = "server=192.168.12.5; database=RSUPAccounting; user=UKoneksi; password=sm@rt2018;  MultipleActiveResultSets=True; connect timeout=0;Max Pool Size=500000  ;"

        connection = New SqlConnection(connetionString)



        Dim sql, sql2 As String

        If chkS_Petani.Checked = True Then
            sql2 = Modul_RMP.Func.SetCondition(sql2, "KodeSup = '" & cmbS_Petani.SelectedValue.ToString & "'")
        End If



        If chkPancang.Checked = True Then
            sql2 = Modul_RMP.Func.SetCondition(sql2, "DivBlokKav in (select DivkavP2 FROM RMPApp..Android_tblMstPancang where IDPancang= '" & cmbPancang.SelectedValue.ToString & "') ")
        End If

        If chkyear.Checked = True Then
            sql2 = Modul_RMP.Func.SetCondition(sql2, " year(Tanggal)=  '" & DOYear.Text & "' ")
        End If

        If chktanggal.Checked = True Then
            sql2 = Modul_RMP.Func.SetCondition(sql2, "Convert(DateTime, Tanggal, 103) between convert(datetime,'" & Format(dtcb1.Value, "dd/MM/yyyy") & "',103) And convert(datetime,'" & Format(dtcb2.Value, "dd/MM/yyyy") & "',103) ")
        End If



        If rdbelumadaktp.Checked = True Then


            sql = "Select  ROW_NUMBER() OVER (
	            ORDER BY kodesupum,rmsupplierid
               ) No, KodeSupUM AS GroupKK, NamaSupUM AS NamaSupUM_  , KodeSupUM, NamaSupUM, KodeSup, NamaSup, DivBlokKav,
                Alamat, KTP as KTP,'' as FOTOKTP, NoNPWP as NONPWP,'' AS FOTONPWP,'' AS SURATLAHAN,0 AS CHECKED,'' AS FSURAT,NotActive,RemarkInActive,'' as Foto,StatusVerifFoto AS FlagLinkFoto,FotoSupplier AS LinkFoto
                from RSUPAccounting..vwRMMstSupplier where  KTP IS NULL and FotoSupplier IS NOT NULL AND left(kodesup,3)='PCG' " & IIf(sql2 = "", "", " And " & sql2) & " ORDER BY kodesupum,rmsupplierid"

        Else

            sql = "WITH DATAA AS (SELECT IDSUBPETANI,SUM(JUMLAHPOINT) AS JUMLAHPOINT FROM RMPAPP..TblTrnKelapa_Poin_2023 GROUP BY IDSUBPETANI )
                 Select  ROW_NUMBER() OVER (
                 ORDER BY kodesupum,rmsupplierid ) No, A.KodeSupUM AS GroupKK, A.NamaSupUM AS NamaSupUM_  , A.KodeSupUM, A.NamaSupUM, A.KodeSup, A.NamaSup, A.DivBlokKav,
                 A.Alamat, A.KTP as KTP,'' as FOTOKTP, A.NoNPWP as NONPWP,'' AS FOTONPWP,'' AS SURATLAHAN,0 AS CHECKED,'' AS FSURAT,A.NotActive,A.RemarkInActive,'' as Foto,
                 A.StatusVerifFoto AS FlagLinkFoto,A.FotoSupplier AS LinkFoto
                 from RSUPAccounting..vwRMMstSupplier AS A  INNER JOIN
                 DATAA  AS B  ON A.KODESUP=B.IDSUBPETANI AND B.JUMLAHPOINT>0 AND
                left(kodesup,3)='PCG' AND A.FotoSupplier IS NULL " & IIf(sql2 = "", "", " And " & sql2) & " ORDER BY kodesupum,rmsupplierid"


        End If


        Try
            connection.Open()
            adapter = New SqlDataAdapter(sql, connection)
            adapter2 = New SqlDataAdapter(sql, connection)
            adapter.Fill(DS)
            adapter2.Fill(DS2)
            connection.Close()
            fg1.DataSource = DS.Tables(0)
            fg2.DataSource = DS2.Tables(0)

            fg1.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free
            fg2.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free
            HeaderFG(fg1)
            HeaderFG(fg2)
            HEADERFG2()

            For i = 1 To fg1.Rows.Count - 1
                If fg1.Item(i, "NotActive") = True Then
                    fg1.Rows(i).StyleNew.ForeColor = Color.Red
                Else
                    fg1.Rows(i).StyleNew.ForeColor = Color.Black
                End If
                Me.fg1.SetCellImage(i, 18, My.Resources.find20)

            Next


            For i = 1 To fg2.Rows.Count - 1
                If fg2.Item(i, "NotActive") = True Then
                    fg2.Rows(i).StyleNew.ForeColor = Color.Red
                Else
                    fg2.Rows(i).StyleNew.ForeColor = Color.Black
                End If
            Next


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub fg_BeforeEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles fg1.BeforeEdit
        Dim i As Integer
        For i = 1 To fg1.Rows.Count - 1

            For a = 0 To fg1.Col - 1
                If e.Col = a And e.Row = i Then
                    e.Cancel = True
                End If
            Next
        Next
    End Sub
    Private Sub cmbPancang_Validated(sender As Object, e As EventArgs) Handles cmbPancang.Validated
        chkPancang.Checked = IIf(chkPancang.Text = "", False, True)
    End Sub

    Private Sub cmbS_Petani_Validated(sender As Object, e As EventArgs) Handles cmbS_Petani.Validated
        chkS_Petani.Checked = IIf(chkS_Petani.Text = "", False, True)
    End Sub

    Private Sub cmbPancang_Validating(sender As Object, e As CancelEventArgs) Handles cmbPancang.Validating
        If cmbPancang.Text = "" Then
            Exit Sub
        End If
        If IsNothing(cmbPancang.SelectedValue) Then
            MsgBox("Pilihan tidak ada !", vbExclamation, AT)
            cmbPancang.Text = ""
            cmbPancang.Focus()
        End If
    End Sub

    Private Sub cmbS_Petani_Validating(sender As Object, e As CancelEventArgs) Handles cmbS_Petani.Validating
        If cmbS_Petani.Text = "" Then
            Exit Sub
        End If

        If IsNothing(cmbS_Petani.SelectedValue) Then
            MsgBox("Pilihan tidak ada !", vbExclamation, AT)
            cmbS_Petani.Text = ""
            cmbS_Petani.Focus()
        End If
    End Sub

    Private Sub cmbPancang_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbPancang.KeyUp
        UI.AutoCompleteCombo_KeyUp(cmbPancang, e)
    End Sub

    Private Sub cmbS_Petani_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbS_Petani.KeyUp
        UI.AutoCompleteCombo_KeyUp(cmbS_Petani, e)
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg1.Click

    End Sub

    Private Async Sub fg_DoubleClick(
    sender As Object, e As EventArgs
) Handles fg1.DoubleClick

        If fg1.Col <> 18 Then Exit Sub

        Dim linkFoto As String =
        Convert.ToString(fg1.Item(fg1.Row, "LinkFoto"))

        If String.IsNullOrWhiteSpace(linkFoto) Then
            MsgBox("Foto Belum diupload!", vbExclamation, AT)
            Exit Sub
        End If

        Dim imagePath As String =
        "\\192.168.12.11\notapancangapi\ImagesPurchaserSupplier\" &
        linkFoto & ".jpg"

        Dim frm As New FrmFotoView

        frm.Show(Me)

        Dim berhasil As Boolean =
        Await frm.TampilkanFotoAsync(imagePath)

        If Not berhasil Then
            frm.Close()
        End If

    End Sub

End Class
