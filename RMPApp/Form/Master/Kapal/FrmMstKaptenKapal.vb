
Imports C1.Win.C1FlexGrid
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.Win32

Public Class FrmMstKaptenKapal
    Dim txt As CellRange
    Dim Bergerak As Integer
    Dim Teks As String
    Dim NewFileName, FileName, FileNameOld As String
    Private Sub FrmMstKaptenKapal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HeaderFg()

        ClearData()
        EnabelInput(False)
        EnabeldTombol(False)
        BtnAdd.Enabled = True

        Teks = lblInfo.Text
        Timer.Start()
    End Sub

    Private Sub ClearData()
        TxtID.Clear()
        TxtNama.Clear()
        TxtNik.Clear()
        TxtNoHp.Clear()
        ChkNonActive.Checked = False
        ChkBlackList.Checked = False
        fg.Enabled = True

        FileName = ""
        FileNameOld = ""
        NewFileName = ""

        PicBox.Image = RMPApp.My.Resources.Resources.uploadtidakoke
    End Sub
    Private Sub EnabelInput(flag As Boolean)
        TxtNama.Enabled = flag
        TxtNik.Enabled = flag
        TxtNoHp.Enabled = flag
        ChkNonActive.Enabled = flag
        ChkBlackList.Enabled = flag
    End Sub
    Private Sub EnabeldTombol(flag As Boolean)
        BtnAdd.Enabled = flag
        BtnEdit.Enabled = flag
        BtnSave.Enabled = flag
        BtnCancel.Enabled = flag
        BtnFoto.Enabled = flag
    End Sub
    Private Sub HeaderFg()
        With fg
            .Rows.Fixed = 1
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Cols.Count = 12

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
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Nama Kapten" : .Cols(1).TextAlign = TextAlignEnum.LeftCenter : .Cols(1).AllowEditing = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Nik" : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).AllowEditing = False
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "No Hp" : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).AllowEditing = False
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Non Active" : .Cols(4).TextAlign = TextAlignEnum.LeftCenter : .Cols(4).AllowEditing = False
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Black List" : .Cols(5).TextAlign = TextAlignEnum.LeftCenter : .Cols(5).AllowEditing = False
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "CreatedBy" : .Cols(6).TextAlign = TextAlignEnum.LeftCenter : .Cols(6).AllowEditing = False
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "CreatedDate" : .Cols(7).TextAlign = TextAlignEnum.CenterCenter : .Cols(7).AllowEditing = False
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "UpdatedBy" : .Cols(8).TextAlign = TextAlignEnum.LeftCenter : .Cols(8).AllowEditing = False
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "UpdatedDate" : .Cols(9).TextAlign = TextAlignEnum.CenterCenter : .Cols(9).AllowEditing = False
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "ID" : .Cols(10).Visible = False
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "Foto" : .Cols(11).Visible = False

            .AutoSizeCols()
        End With
    End Sub

    Private Sub ShowData()
        Dim dt As DataTable = New DataTable
        Dim i As Integer = 1

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "Select * from tblMstKaptenKapal where deleteddate is null and (namakapten like '%" & txtsearch.Text & "%' or nik  like '%" & txtsearch.Text & "%') order by namakapten asc")

        If dt.Rows.Count > 0 Then
            fg.Rows.Count = 1
            With fg
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, 1) = row("namakapten")
                    .Item(i, 2) = row("nik")
                    .Item(i, 3) = row("nohpkapten")
                    .Item(i, 4) = row("nonactive")
                    .Item(i, 5) = row("blacklist")
                    .Item(i, 6) = row("createdby")
                    .Item(i, 7) = row("createddate")
                    .Item(i, 8) = row("updatedby")
                    .Item(i, 9) = row("updateddate")
                    .Item(i, 10) = row("id")
                    .Item(i, 11) = row("FotoKTP")

                    i += 1
                Next

                .AutoSizeCols()
            End With
        Else
            MsgBox("No Data !", MsgBoxStyle.Exclamation, AT)
        End If
    End Sub

    Private Sub txtsearch_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(13) Then
            Call ShowData()
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
            .CommandText = "RMPApp..spSaveMaterKaptenKapal"
            .Transaction = MyConTrans

            .Parameters.Add("@ID", SqlDbType.Int).Value = TxtID.Text
            .Parameters.Add("@NamaKapten", SqlDbType.VarChar, 50).Value = TxtNama.Text
            .Parameters.Add("@Nik", SqlDbType.VarChar, 50).Value = TxtNik.Text
            .Parameters.Add("@NoHp", SqlDbType.VarChar, 50).Value = TxtNoHp.Text
            If ChkNonActive.Checked = True Then
                .Parameters.Add("@NonActive", SqlDbType.Int).Value = 1
            Else
                .Parameters.Add("@NonActive", SqlDbType.Int).Value = 0
            End If
            If ChkBlackList.Checked = True Then
                .Parameters.Add("@BlackList", SqlDbType.Int).Value = 1
            Else
                .Parameters.Add("@BlackList", SqlDbType.Int).Value = 0
            End If
            If FileName <> FileNameOld Then
                .Parameters.Add("@FlagUpdateFoto", SqlDbType.Int).Value = 1
            Else
                .Parameters.Add("@FlagUpdateFoto", SqlDbType.Int).Value = 0
            End If
            .Parameters.Add("@User", SqlDbType.VarChar, 50).Value = ClsSession.UserID
            .Parameters.Add(New SqlParameter("@Foto", SqlDbType.VarChar, 50, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .Parameters.Add(New SqlParameter("@Flag", SqlDbType.SmallInt, 3, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))

            .ExecuteNonQuery()
        End With

        Try
            NewFileName = cmd.Parameters("@Foto").Value

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


    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        lblInfo.Text = Bergerak
        Teks = Microsoft.VisualBasic.Right(Teks, Len(Teks) - 1) & Microsoft.VisualBasic.Left(Teks, 1)
        lblInfo.Text = Teks
    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Try
            Dim topColor As Color = Color.FromArgb(0, 172, 251) ' Warna atas yang tebal
            Dim bottomColor As Color = Color.FromArgb(0, 0, 255, 255) ' Warna bawah yang pudar

            Dim gradientRect As New Rectangle(0, 0, Panel1.Width, Panel1.Height)

            Using brush As New Drawing2D.LinearGradientBrush(gradientRect, topColor, bottomColor, Drawing2D.LinearGradientMode.Vertical)
                e.Graphics.FillRectangle(brush, gradientRect)
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        ShowData()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        ClearData()
        EnabelInput(True)
        ChkNonActive.Enabled = False
        ChkBlackList.Enabled = False
        EnabeldTombol(True)
        BtnAdd.Enabled = False
        BtnEdit.Enabled = False
        fg.Enabled = False
        TxtID.Text = "0"
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        EnabelInput(True)
        EnabeldTombol(True)
        BtnAdd.Enabled = False
        BtnEdit.Enabled = False
        fg.Enabled = False
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Me.Cursor = Cursors.WaitCursor
        Dim koneksis As SqlConnection = DB.OpenConnection(StrConnRMPApp)
        Dim Transaksi As SqlTransaction
        Transaksi = koneksis.BeginTransaction

        Dim dt As DataTable = New DataTable
        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select * from RMPApp..tblMstKaptenKapal where nik='" & TxtNik.Text & "' and id <> " & "'" & TxtID.Text & "'")
        If dt.Rows.Count > 0 Then
            MsgBox("Nik Sudah Digunakan !", vbExclamation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If TxtNama.Text = "" Then
            MsgBox("Nama Kapten Tidak Boleh Kosong !", vbExclamation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        ElseIf TxtNik.Text = "" Then
            MsgBox("Nik Tidak Boleh Kosong !", vbExclamation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        ElseIf TxtNoHp.Text = "" Then
            MsgBox("No Hp Tidak Boleh Kosong !", vbExclamation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        ElseIf FileName = "" Then
            MsgBox("Foto Tidak Boleh Kosong !", vbExclamation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        Try
            If SaveData(koneksis, Transaksi) = False Then
                Transaksi.Rollback()
                Me.Cursor = Cursors.Default
                MsgBox("Simpan Data Gagal", vbExclamation, "Save Data - " & "")
                Exit Sub
            End If
            Transaksi.Commit()
            MsgBox("Save Completed !", vbInformation, AT)

            If FileName <> FileNameOld Then
                Try
                    If File.Exists(UrlNotaPancang & "ImagesKapalKTP\" & FileNameOld) Then
                        File.Delete(UrlNotaPancang & "ImagesKapalKTP\" & FileNameOld)
                    End If
                    Modul_RMP.Func.UploadFoto(FileName, UrlNotaPancang & "ImagesKapalKTP\" & NewFileName)
                Catch ex As Exception
                End Try
            End If

            ClearData()
            EnabelInput(False)
            EnabeldTombol(False)
            BtnAdd.Enabled = True

            ShowData()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Save Data Gagal " & "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Transaksi.Rollback()
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click
        If fg.Rows.Count > 0 Then
            With fg
                TxtID.Text = .Item(.RowSel, 10)
                TxtNama.Text = .Item(.RowSel, 1)
                TxtNik.Text = .Item(.RowSel, 2)
                TxtNoHp.Text = .Item(.RowSel, 3)
                ChkNonActive.Checked = .Item(.RowSel, 4)
                ChkBlackList.Checked = .Item(.RowSel, 5)

                FileName = .Item(.RowSel, 11)
                FileNameOld = .Item(.RowSel, 11)

                Try
                    Dim apiUrl As String = UrlApiNotaPancang & "ImagesKapalKTP&filename=" & .Item(.RowSel, 11) & "&flag=notapancang"

                    Modul_RMP.Func.getfoto(apiUrl, TokenApiNotaPancang, PicBox)
                Catch ex As Exception
                End Try
            End With
        End If

        If TxtNama.Text <> "" Then
            BtnEdit.Enabled = True
        End If
    End Sub

    Private Sub BtnFoto_Click(sender As Object, e As EventArgs) Handles BtnFoto.Click
        Try
            OpenFileDialog1.Filter = "All Image Files|*.png;*.jpeg;*.jpg;*.JPG;*.JPEG|PDF Files|*.pdf"
            OpenFileDialog1.Title = "Select Image File"

            If OpenFileDialog1.ShowDialog = DialogResult.OK Then
                FileName = OpenFileDialog1.FileName
                PicBox.Image = System.Drawing.Image.FromFile(FileName)
            Else
                FileName = ""
                PicBox.Image = RMPApp.My.Resources.Resources.uploadtidakoke
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        ClearData()
        EnabelInput(False)
        EnabeldTombol(False)
        BtnAdd.Enabled = True
    End Sub

    Private Sub PicBox_Click(sender As Object, e As EventArgs) Handles PicBox.Click
        If Application.OpenForms.OfType(Of FrmRptViewFoto)().Any() Then
            FrmRptViewFoto.Close()
        End If
        FrmRptViewFoto.FileName = FileName
        FrmRptViewFoto.formName = "FrmMstKaptenKapal"
        FrmRptViewFoto.Show()
    End Sub

    Private Sub TxtNik_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNik.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtNoHp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNoHp.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class