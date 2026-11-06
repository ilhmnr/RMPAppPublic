Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient

Public Class FrmMstKontraktorSub
    Private Sub FrmMstKontraktor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call HeaderFg()
        Call kondisiAwal()
        Call loadData()
    End Sub

    Private Sub kondisiAwal()
        BtnRefresh.Enabled = True
        BtnAdd.Enabled = True
        BtnEdit.Enabled = False
        BtnSave.Enabled = False
        BtnCancel.Enabled = False

        txtId.Text = 0
        txtSubKontraktor.Clear()
        chkNonActive.Checked = False
        chkNonActive.Enabled = False

        fg.Enabled = True
    End Sub
    Private Sub HeaderFg()
        Dim txt As CellRange

        With fg
            .Rows.Fixed = 1
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Cols.Count = 10

            .AutoGenerateColumns = True
            .Rows(0).AllowMerging = True
            .Styles.Normal.WordWrap = True

            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular)
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .AllowMerging = AllowMergingEnum.FixedOnly

            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

            .Rows(0).TextAlign = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).TextAlign = TextAlignEnum.LeftCenter : .Cols(0).AllowEditing = False
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Nama Sub Kontraktor" : .Cols(1).TextAlign = TextAlignEnum.LeftCenter : .Cols(1).AllowEditing = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Created By" : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).AllowEditing = False
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Created Date" : .Cols(3).TextAlign = TextAlignEnum.CenterCenter : .Cols(3).AllowEditing = False
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Updated By" : .Cols(4).TextAlign = TextAlignEnum.LeftCenter : .Cols(4).AllowEditing = False
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Updated Date" : .Cols(5).TextAlign = TextAlignEnum.CenterCenter : .Cols(5).AllowEditing = False
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Non Active" : .Cols(6).TextAlign = TextAlignEnum.LeftCenter : .Cols(6).AllowEditing = False : .Cols(6).Visible = False
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Non Active By" : .Cols(7).TextAlign = TextAlignEnum.LeftCenter : .Cols(7).AllowEditing = False : .Cols(7).Visible = False
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Non Active Date" : .Cols(8).TextAlign = TextAlignEnum.CenterCenter : .Cols(8).AllowEditing = False : .Cols(8).Visible = False
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Id" : .Cols(9).Visible = False

            .AutoSizeCols()
        End With
    End Sub


    Private Sub loadData()
        Dim i As Integer = 1
        Dim dt As DataTable = New DataTable

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " select * from tbl_wo_mst_kontraktor_sub where nama_kontraktor_sub like '%" & txtSubKontraktor.Text & "%' and notactive=0 order by nama_kontraktor_sub asc ")

        fg.Rows.Count = 1
        If dt.Rows.Count > 0 Then
            With fg
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, 1) = row("nama_kontraktor_sub")
                    .Item(i, 2) = row("created_by")
                    .Item(i, 3) = row("created_date")
                    .Item(i, 4) = row("updated_by")
                    .Item(i, 5) = row("updated_date")
                    .Item(i, 6) = row("notactive")
                    .Item(i, 7) = row("notactive_by")
                    .Item(i, 8) = row("notactive_date")
                    .Item(i, 9) = row("id")
                    i += 1
                Next
                .AutoSizeCols()
            End With
        End If
    End Sub



    Private Function SaveData(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        SaveData = False

        Dim MyCon As SqlConnection = Conn
        Dim MyConTrans As SqlTransaction = Trans
        Dim cmd As New SqlCommand

        With cmd
            .Connection = Conn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RMPApp..spSaveMstSubKontraktor"
            .Transaction = MyConTrans

            .Parameters.Add("@id", SqlDbType.Int).Value = txtId.Text
            .Parameters.Add("@namaSubKontraktor", SqlDbType.VarChar, 200).Value = txtSubKontraktor.Text
            .Parameters.Add("@nonActive", SqlDbType.Int).Value = IIf(chkNonActive.Checked = True, 1, 0)
            .Parameters.Add("@createdBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
            .Parameters.Add(New SqlParameter("@Flag", SqlDbType.SmallInt, 3, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))

            .ExecuteNonQuery()
        End With

        Try
            If CInt(cmd.Parameters("@Flag").Value) = 0 Then
                cmd.Dispose()
                Exit Function
            End If

            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function


    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        BtnRefresh.Enabled = True
        BtnAdd.Enabled = True
        BtnEdit.Enabled = False
        BtnSave.Enabled = False
        BtnCancel.Enabled = False

        txtId.Text = 0
        chkNonActive.Checked = False

        Call loadData()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        BtnRefresh.Enabled = False
        BtnAdd.Enabled = False
        BtnEdit.Enabled = False
        BtnSave.Enabled = True
        BtnCancel.Enabled = True

        txtSubKontraktor.Clear()
        txtSubKontraktor.Focus()
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        BtnRefresh.Enabled = False
        BtnAdd.Enabled = False
        BtnEdit.Enabled = False
        BtnSave.Enabled = True
        BtnCancel.Enabled = True

        txtSubKontraktor.Focus()
        chkNonActive.Enabled = True

        fg.Enabled = False
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If txtSubKontraktor.Text = "" Then
            MsgBox("Nama Sub Kontraktor Belum Di Input !", vbExclamation, AT)
            Exit Sub
        End If

        Dim namaKontraktok As String
        namaKontraktok = DB.ExecuteScalarValue(Of String)(StrConnRMPApp," select nama_kontraktor_sub as GetValueString from tbl_wo_mst_kontraktor_sub where slug=LOWER(REPLACE('" & txtSubKontraktor.Text & "',' ','_')) ")
        If namaKontraktok <> "" And chkNonActive.Checked = False Then
            MsgBox("Nama Sub Kontraktor Sudah Ada !", vbExclamation, AT)
            Exit Sub
        End If

        Dim koneksi As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnRMPApp)
        Dim transaksi As SqlTransaction
        transaksi = koneksi.BeginTransaction

        If SaveData(koneksi, transaksi) = False Then
            transaksi.Rollback()
            MsgBox("Simpan Data Gagal !", vbExclamation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        transaksi.Commit()
        MsgBox("Data Berhasil Di Save", vbInformation, AT)
        Call kondisiAwal()
        Call loadData()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Call kondisiAwal()
        Call loadData()
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click
        If fg.Rows.Count > 1 Then
            txtId.Text = fg.Item(fg.RowSel, 9)
            txtSubKontraktor.Text = fg.Item(fg.RowSel, 1)
            If fg.Item(fg.RowSel, 6) = True Then
                chkNonActive.Checked = True
            Else
                chkNonActive.Checked = False
            End If
        End If
    End Sub

    Private Sub txtId_TextChanged(sender As Object, e As EventArgs) Handles txtId.TextChanged
        If txtId.Text <> 0 Then
            BtnEdit.Enabled = True
        Else
            BtnEdit.Enabled = False
        End If
    End Sub
End Class