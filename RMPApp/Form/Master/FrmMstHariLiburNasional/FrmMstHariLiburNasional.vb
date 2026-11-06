Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class FrmMstHariLiburNasional
    Dim dt As DataTable = New DataTable()
    Dim Perintah As String
    Private Sub FrmMstHariLiburNasional_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call HeaderFG()
        Call ClearData()
        Call search()
        DtpTglLibur.Value = Format(Now, "dd/MM/yy")
    End Sub
    Public Sub HeaderFG()
        Dim txt As CellRange
        With fg
            .AllowEditing = False
            .AutoGenerateColumns = True
            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular)
            .Cols.Count = 9
            .Cols.Fixed = 1
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

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "NO"
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Tanggal" : .Cols(1).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Keterangan" : .Cols(2).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Created By" : .Cols(3).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Created Date" : .Cols(4).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Updated By" : .Cols(5).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Updated Date" : .Cols(6).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Computer" : .Cols(7).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Computer Date" : .Cols(8).TextAlign = TextAlignEnum.CenterCenter

            .AutoSizeCols()
        End With
    End Sub

    Private Sub ClearData()
        TxtKeterangan.Clear()
        DtpTglLibur.Value = Format(Now, "dd/MM/yy")
        '----------------------------
        TxtKeterangan.Enabled = False
        DtpTglLibur.Enabled = False

        btnSave.Enabled = False
        btnEdit.Enabled = False
        btnAdd.Enabled = True
    End Sub

    Private Sub search()
        C1FlexGridSearchPanel1.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        C1FlexGridSearchPanel1.SearchDelay = 2
        C1FlexGridSearchPanel1.Watermark = "Search : Tanggal/Keterangan"
        C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(fg, C1FlexGridSearchPanel1)
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Call ShowData()
    End Sub
    Private Sub ShowData()
        Dim i As Integer = 1
        Dim sql As String = ""

        Try
            dt = Modul_RMP.Cls_Connection.SqlSelect_VBDSERVER("select * from tblMstHariLiburNasional order by tanggal desc")

            If dt.Rows.Count > 0 Then
                With fg
                    Call Modul_RMP.Cls_Model.HapusGrid(1, fg)
                    For Each row As DataRow In dt.Rows
                        .AddItem(i)
                        .Item(i, 1) = row.Item("Tanggal")
                        .Item(i, 2) = row.Item("Keterangan")
                        .Item(i, 3) = IIf(IsDBNull(row.Item("CreatedBy")), "-", row.Item("CreatedBy"))
                        .Item(i, 4) = IIf(IsDBNull(row.Item("CreatedDate")), "-", row.Item("CreatedDate"))
                        .Item(i, 5) = IIf(IsDBNull(row.Item("UpdateBy")), "-", row.Item("UpdateBy"))
                        .Item(i, 6) = IIf(IsDBNull(row.Item("UpdateDate")), "-", row.Item("UpdateDate"))
                        .Item(i, 7) = IIf(IsDBNull(row.Item("Computer")), "-", row.Item("Computer"))
                        .Item(i, 8) = IIf(IsDBNull(row.Item("ComputerDate")), "-", row.Item("ComputerDate"))

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

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click
        If fg.Rows.Count > 1 Then
            With fg
                TxtKeterangan.Text = .Item(.Row, 2)
                DtpTglLibur.Value = .Item(.Row, 1)
            End With

            btnEdit.Enabled = True
            btnAdd.Enabled = False
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If TxtKeterangan.Text = "" Then
            Call MsgBox("Keterangan is Empty !!", vbExclamation, AT)
        ElseIf DtpTglLibur.Text = "" Then
            Call MsgBox("Tanggal is Empty !!", vbExclamation, AT)
        Else
            Dim koneksi As SqlConnection = Modul_RMP.Cls_Connection.OpenConnection
            Dim Transaksi As SqlTransaction
            Transaksi = koneksi.BeginTransaction
            Try
                If SaveHariLiburNasional(koneksi, Transaksi) = False Then
                    Transaksi.Rollback()
                    MsgBox("Simpan Data Gagal", vbCritical, "Save Kapal")
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                Transaksi.Commit()
                MsgBox("Data Telah Tersimpan", MsgBoxStyle.Information)
                ClearData()
                ShowData()
                Perintah = ""
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                koneksi.Close()
                Me.Cursor = Cursors.Default
            End Try
        End If
    End Sub

    Private Function SaveHariLiburNasional(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        SaveHariLiburNasional = False
        Dim MyCon As SqlConnection = Conn
        Dim MyConTrans As SqlTransaction = Trans
        Dim cmd As New SqlCommand
        With cmd
            .Connection = Conn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RMPApp..spSaveHariLiburNasional"
            .Transaction = MyConTrans

            .Parameters.Add("@Keterangan", SqlDbType.VarChar, 150).Value = TxtKeterangan.Text.ToString
            .Parameters.Add("@Tanggal", SqlDbType.VarChar, 50).Value = DtpTglLibur.Text.ToString
            .Parameters.Add("@Perintah", SqlDbType.VarChar, 50).Value = Perintah
            .Parameters.Add("@User", SqlDbType.VarChar, 50).Value = FrmMenuNew.UserName
            .Parameters.Add(New SqlParameter("@Flag", SqlDbType.SmallInt, 3, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .ExecuteNonQuery()
        End With

        Try
            If CInt(cmd.Parameters("@Flag").Value) = 0 Then
                cmd.Dispose()
                Exit Function
            End If

            cmd.Dispose()
            SaveHariLiburNasional = 1
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        TxtKeterangan.Enabled = True
        DtpTglLibur.Enabled = True

        btnSave.Enabled = True
        btnAdd.Enabled = False

        Perintah = "Add"
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ClearData()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        btnSave.Enabled = True
        btnEdit.Enabled = False
    End Sub
End Class