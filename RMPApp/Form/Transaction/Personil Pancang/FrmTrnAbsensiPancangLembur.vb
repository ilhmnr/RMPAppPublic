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
Public Class FrmTrnAbsensiPancangLembur

    Public Sub HeaderFG()

        Dim txt As CellRange
        With fg
            .AllowEditing = True
            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular)
            .Cols.Count = 12
            .Cols.Fixed = 1
            '.Cols.Frozen = 5
            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 1
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "N0" : .Cols(0).Width = 50
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "NoTransaksi" : .Cols(1).TextAlign = TextAlignEnum.CenterCenter : .Cols(1).AllowEditing = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "tglTransaksi" : .Cols(2).TextAlign = TextAlignEnum.CenterCenter : .Cols(2).AllowEditing = False
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Periode Awal" : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).AllowEditing = False
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Periode Akhir" : .Cols(4).TextAlign = TextAlignEnum.CenterCenter : .Cols(4).AllowEditing = False
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "createdby" : .Cols(5).TextAlign = TextAlignEnum.LeftCenter : .Cols(5).AllowEditing = False
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "createddate" : .Cols(6).TextAlign = TextAlignEnum.CenterCenter : .Cols(6).AllowEditing = False
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "ApproveBy" : .Cols(7).TextAlign = TextAlignEnum.CenterCenter : .Cols(7).AllowEditing = False
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "ApproveDate" : .Cols(8).TextAlign = TextAlignEnum.CenterCenter : .Cols(8).AllowEditing = False
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "LihatData" : .Cols(9).ImageAlign = ImageAlignEnum.CenterCenter : .Cols(9).AllowEditing = False
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "StatusApprove" : .Cols(10).TextAlign = TextAlignEnum.CenterCenter : .Cols(10).AllowEditing = False : .Cols(10).Visible = False
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "Restore" : .Cols(11).ImageAlign = ImageAlignEnum.CenterCenter : .Cols(11).AllowEditing = False
            .AutoSizeCols()
        End With

    End Sub






    Public Sub ShowData()

        Dim i As Integer = 1
        Dim sql As String = ""
        Dim dt As DataTable = New DataTable()

        Try




            If chkTransDate.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "CONVERT(DATETIME, CONVERT(VARCHAR, tglTransaksi, 103),103) between CONVERT (DATETIME,'" & Format(DTP1.Value, "dd/MM/yyyy") & "',103) and CONVERT (DATETIME,'" & Format(DTP2.Value, "dd/MM/yyyy") & "',103)")
            End If


            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " SELECT * FROM RMPApp..tbl_Absensi_Pancang_PSN_Hdr  WHERE  1=1 " & IIf(sql = "", "", " AND " & sql) & "   ORDER BY tglTransaksi")




            If dt.Rows.Count > 0 Then
                With fg
                    Call UI.HapusGrid(1, fg)
                    For Each row As DataRow In dt.Rows
                        .AddItem(i)
                        .Item(i, 1) = row.Item("NoTransaksi")
                        .Item(i, 2) = row.Item("tglTransaksi")
                        .Item(i, 3) = row.Item("PeriodeStart")
                        .Item(i, 4) = row.Item("PeriodeEnd")
                        .Item(i, 5) = row.Item("createdby")
                        .Item(i, 6) = row.Item("createddate")
                        .Item(i, 7) = row.Item("ApproveBy")
                        .Item(i, 8) = row.Item("ApproveDate")
                        .Item(i, 10) = row.Item("FlagApprove")
                        Me.fg.SetCellImage(i, 9, My.Resources.find20)
                        Me.fg.SetCellImage(i, 11, My.Resources.icons8_restart_20)

                        If .Item(i, 10) = 1 Then
                            .Rows(i).StyleNew.BackColor = Color.LavenderBlush

                        End If
                        i = i + 1
                    Next
                    .AutoSizeCols()
                End With
            Else
                MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
            End If
        Catch EX As Exception
            MsgBox(EX.Message)
        End Try
    End Sub


    Private Sub search()
        With schfg
            .SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
            .SearchDelay = 2
            .Watermark = "Cari Disini"
            .SetC1FlexGridSearchPanel(fg, schfg)
        End With
    End Sub
    Private Function DelAbsensi(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, notrans As String) As Boolean
        Dim MyCMD As New SqlCommand
        Try
            With MyCMD

                DelAbsensi = False
                Dim MyCon As SqlConnection = Conn
                Dim MyConTrans As SqlTransaction = Trans
                .Connection = MyCon
                .Connection = MyCon
                .CommandType = CommandType.StoredProcedure
                .CommandText = "RMPApp..sp_DelAbsensi"
                .Transaction = MyConTrans
                .Parameters.Add("@RETURN_VALUE", SqlDbType.SmallInt).Direction = ParameterDirection.ReturnValue
                .Parameters.Add("@NoTransaksi", SqlDbType.VarChar, 30).Value = fg.Item(fg.Row, 1)
                .Parameters.Add("@RestoreBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
                .Parameters.Add(New SqlParameter("@Error", SqlDbType.VarChar, 200, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message & " infosp : " & MyCMD.Parameters("@Error").Value)
            Return False
        End Try
        Return True
    End Function


    Private Function SaveTrnAbsensiHdr(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        Dim MyCMD As New SqlCommand
        Try
            With MyCMD
                Dim MyCon As SqlConnection = Conn
                Dim MyConTrans As SqlTransaction = Trans
                .Connection = MyCon
                .CommandType = CommandType.StoredProcedure
                .CommandText = "RMPApp..spSaveTrnAbsensiHdrAQWE"
                .Transaction = MyConTrans
                .Parameters.Add("@RETURN_VALUE", SqlDbType.SmallInt).Direction = ParameterDirection.ReturnValue
                .Parameters.Add("@Perintah", SqlDbType.VarChar, 10).Value = "Add"
                .Parameters.Add("@NoInvoice", SqlDbType.VarChar, 30).Value = "001/ABSN/052023"
                .Parameters.Add("@periode1", SqlDbType.DateTime).Value = DTP1.Value
                .Parameters.Add("@periode2", SqlDbType.DateTime).Value = DTP2.Value
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

    Private Sub Button1_Click(sender As Object, e As EventArgs)
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

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        FrmTrnAbsensiPancang.Show()
        FrmTrnAbsensiPancangLemburApproval.C1DockingTab1.Visible = True
        FrmTrnAbsensiPancangLemburApproval.fgall.Visible = False
        FrmTrnAbsensiPancangLemburApproval.Perintah = "Add"
    End Sub

    Private Sub FrmTrnAbsensiPancangList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HeaderFG()

        DTP1.Value = Format(Now, "yyyy-MM-dd")
        DTP2.Value = Format(Now, "yyyy-MM-dd")
        search()
        fg.Rows.Count = 1
    End Sub


    Private Sub fg_DoubleClick(sender As Object, e As EventArgs) Handles fg.DoubleClick

        Select Case fg.Col
            Case 9

                With FrmTrnAbsensiPancangLemburApproval
                    .fgall.Rows.Count = 1
                    .Show()

                    .cmdEnabled(False)
                    .Perintah = "Edit"
                    .btnSave.Visible = False

                    With .fgall
                        .AutoSizeCols()
                        .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
                        .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
                        .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)
                        .AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free
                        .AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free
                    End With


                    Call UI.HapusGrid(1, .fgall)
                    .C1DockingTab1.Visible = False
                    .fgall.Visible = True
                    .fgall.Clear()
                    .fgall.Row = 0
                    .fgall.Col = 0
                    .fgall.DataSource = Nothing
                    .fgall.Clear(C1.Win.C1FlexGrid.ClearFlags.Content)
                    .CALLDATAall(fg.Item(fg.Row, 1))
                    .GrandTotalALL()
                    .txtinvoice.Text = fg.Item(fg.Row, 1)
                    .dtp1.Value = fg.Item(fg.Row, 3)
                    .dtp2.Value = fg.Item(fg.Row, 4)
                    .dtp1.Enabled = False
                    .dtp2.Enabled = False
                    .btnApprove.Visible = True

                End With
            Case 11
                If fg.Item(fg.Row, 10) = 0 Then

                    Dim result As DialogResult = MessageBox.Show("Yakin Restore Transaksi  Periode '" & fg.Item(fg.Row, 3) & "' s/d  '" & fg.Item(fg.Row, 4) & "' ", "caption", MessageBoxButtons.YesNoCancel)
                    If result = DialogResult.Cancel Then
                        MessageBox.Show("Cancel pressed")
                    ElseIf result = DialogResult.Yes Then
                        Dim Koneksi As SqlConnection = DB.OpenConnection(StrConnRMPApp)
                        Dim Transaksi As SqlTransaction
                        Transaksi = Koneksi.BeginTransaction
                        Me.Cursor = Cursors.WaitCursor

                        Try

                            If DelAbsensi(Koneksi, Transaksi, fg.Item(fg.Row, 1)) = False Then
                                Transaksi.Rollback()
                                Transaksi = Nothing
                                Me.Cursor = Cursors.Default
                                MessageBox.Show("Delete Data Hdr Gagal !", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            Transaksi.Commit()
                            Call UI.HapusGrid(1, fg)
                            Me.Cursor = Cursors.Default
                            MessageBox.Show("Delete Data Berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ShowData()
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Transaksi.Rollback()
                            Koneksi.Close()
                            Me.Cursor = Cursors.Default
                        Finally
                            Koneksi.Close()
                            Me.Cursor = Cursors.Default
                        End Try
                    End If

                Else
                    MessageBox.Show("Data Absensi Tidak Dapat direstore sudah di Approve (dikirim-PSN) !", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

        End Select
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ShowData()
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnrefreshh_Click(sender As Object, e As EventArgs) Handles btnrefreshh.Click
        ShowData()
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click

    End Sub

    Private Sub fg_DragDrop(sender As Object, e As DragEventArgs) Handles fg.DragDrop

    End Sub
End Class