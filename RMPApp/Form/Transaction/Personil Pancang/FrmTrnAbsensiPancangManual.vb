Imports System.Data.SqlClient
Imports System.IO
Imports C1.Win.C1FlexGrid
Imports Dapper

Public Class FrmTrnAbsensiPancangManual
    Public pathFoto As String = UrlMasterTTPancnag & "FotoAbsensiManual"
    Dim cls As New ClsDatabaseConnection
    Dim dt As DataTable = New DataTable()
    Dim NamaFile, destPath As String

    Private Sub FrmTrnAbsensiManualPCG_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Modul_RMP.Combo.SetMstKehadiran(cboKehadiran)
        HeaderFG()
        Clear()
        Search()
    End Sub

    Private Sub Search()
        With schfg
            .SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
            .SearchDelay = 2
            .Watermark = "Cari Disini"
            .SetC1FlexGridSearchPanel(fg, schfg)
        End With
    End Sub

    Sub Clear()
        fg.Rows.Count = 1
        dtpAbsen.Value = Format(Now, "dd/MM/yyyy")
        dt1.Value = Format(Now, "dd/MM/yyyy")
        dt2.Value = Format(Now, "dd/MM/yyyy")
        txtSearch.Text = "Cari IDPersonil Pancang disini !"
        txtKet.Text = "Ketik keterangan alasan input absensi manual disini !"
        pic.Image = Nothing
        IDMst.Text = ""
        txtNamaFile.Text = ""
        txtIDPersonil.Text = ""
        txtNama.Text = ""
        txtJabatan.Text = ""
        txtIDP.Text = ""
        txtPancang.Text = ""
        cboKehadiran.Text = ""
    End Sub

    Public Sub HeaderFG()
        Dim txt As CellRange
        With fg
            .AllowEditing = True
            .Font = New System.Drawing.Font("Century Gothic", 7.5!, System.Drawing.FontStyle.Regular)
            .Cols.Count = 15
            .AllowMergingFixed = AllowMergingEnum.FixedOnly
            .Styles.Fixed.BackColor = Color.FromArgb(240, 248, 254)
            .Styles.Alternate.BackColor = Color.White
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 1
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "NO" : .Cols(0).Width = 50 : .Cols(0).AllowMerging = True
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "ID" : .Cols(1).TextAlign = TextAlignEnum.CenterCenter : .Cols(1).AllowMerging = True : .Cols(1).AllowEditing = False : .Cols(1).Visible = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "TANGGAL" : .Cols(2).TextAlign = TextAlignEnum.CenterCenter : .Cols(2).AllowMerging = True : .Cols(2).AllowEditing = False
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "BAGIAN" : .Cols(3).TextAlign = TextAlignEnum.CenterCenter : .Cols(3).AllowMerging = True : .Cols(3).AllowEditing = False
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "ID PERSONIL" : .Cols(4).TextAlign = TextAlignEnum.CenterCenter : .Cols(4).AllowMerging = True : .Cols(4).AllowEditing = False
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "NAMA" : .Cols(5).TextAlign = TextAlignEnum.LeftCenter : .Cols(5).AllowMerging = True : .Cols(5).AllowEditing = False
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "JABATAN" : .Cols(6).TextAlign = TextAlignEnum.CenterCenter : .Cols(6).AllowMerging = True : .Cols(6).AllowEditing = False
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "ID PANCANG" : .Cols(7).TextAlign = TextAlignEnum.CenterCenter : .Cols(7).AllowMerging = True : .Cols(7).AllowEditing = False : .Cols(7).Visible = False
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "PANCANG" : .Cols(8).TextAlign = TextAlignEnum.LeftCenter : .Cols(8).AllowMerging = True : .Cols(8).AllowEditing = False
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "KEHADIRAN" : .Cols(9).TextAlign = TextAlignEnum.CenterCenter : .Cols(9).AllowMerging = True : .Cols(9).AllowEditing = False
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "FOTO" : .Cols(10).TextAlign = TextAlignEnum.CenterCenter : .Cols(10).AllowMerging = True : .Cols(10).AllowEditing = False
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "KETERANGAN" : .Cols(11).TextAlign = TextAlignEnum.LeftCenter : .Cols(11).AllowMerging = True : .Cols(11).AllowEditing = False
            txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "CREATED BY" : .Cols(12).TextAlign = TextAlignEnum.CenterCenter : .Cols(12).AllowMerging = True : .Cols(12).AllowEditing = False
            txt = .GetCellRange(0, 13, 0, 13) : txt.Data = "CREATED DATE" : .Cols(13).TextAlign = TextAlignEnum.CenterCenter : .Cols(13).AllowMerging = True : .Cols(13).AllowEditing = False
            txt = .GetCellRange(0, 14, 0, 14) : txt.Data = "CREATED COMP" : .Cols(14).TextAlign = TextAlignEnum.CenterCenter : .Cols(14).AllowMerging = True : .Cols(14).AllowEditing = False

            .AutoSizeCols()
        End With
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If txtSearch.Text = "Cari IDPersonil Pancang disini !" Then
            txtSearch.ForeColor = Color.DarkGray
        Else
            txtSearch.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtSearch_LostFocus(sender As Object, e As EventArgs) Handles txtSearch.LostFocus
        If txtSearch.Text = String.Empty Then txtSearch.Text = "Cari IDPersonil Pancang disini !"
    End Sub

    Private Sub txtSearch_MouseClick(sender As Object, e As MouseEventArgs) Handles txtSearch.MouseClick
        If txtSearch.Text = "Cari IDPersonil Pancang disini !" Then txtSearch.Text = String.Empty
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = 13 Then
            GetPersonil()
        End If
    End Sub

    Private Sub txtKet_TextChanged(sender As Object, e As EventArgs) Handles txtKet.TextChanged
        If txtKet.Text = "Ketik keterangan alasan input absensi manual disini !" Then
            txtKet.ForeColor = Color.DarkGray
        Else
            txtKet.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtKet_LostFocus(sender As Object, e As EventArgs) Handles txtKet.LostFocus
        If txtKet.Text = String.Empty Then txtKet.Text = "Ketik keterangan alasan input absensi manual disini !"
    End Sub

    Private Sub txtKet_MouseClick(sender As Object, e As MouseEventArgs) Handles txtKet.MouseClick
        If txtKet.Text = "Ketik keterangan alasan input absensi manual disini !" Then txtKet.Text = String.Empty
    End Sub

    Private Sub GetPersonil()
        Dim Site As String = ""

        If rdP1.Checked = False And rdP2.Checked = False And rdP3.Checked = False Then
            MsgBox("Silahkan Pilih Site Terlebih Dahulu P1/P2/P3 !", vbExclamation, "Get Personil - " & AT)
            Exit Sub
        End If

        If rdP1.Checked = True Then
            Site = "P1"
        ElseIf rdP2.Checked = True Then
            Site = "P2"
        ElseIf rdP3.Checked = True Then
            Site = "P3"
        End If

        Try
            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT TOP 1 ID,IDPersonil,UPPER(Nama) AS Nama,UPPER(Jabatan) AS Jabatan,IDPancang,Pancang FROM vwPersonilPCG2023 WHERE  Cast(Tanggal as date)<=cast('" & Format(dtpAbsen.Value, "yyyy-MM-dd") & "' as date)  and NotActive <> 1 AND Bagian = '" & Site & "' AND IDPersonil = '" & txtSearch.Text & "' ORDER BY Tanggal DESC")
            For Each row As DataRow In dt.Rows
                If dt.Rows.Count > 0 Then
                    IDMst.Text = row.Item("ID")
                    txtIDPersonil.Text = row.Item("IDPersonil")
                    txtNama.Text = row.Item("Nama")
                    txtJabatan.Text = row.Item("Jabatan")
                    txtIDP.Text = row.Item("IDPancang")
                    txtPancang.Text = row.Item("Pancang")
                Else
                    MsgBox("No Data !", MsgBoxStyle.Exclamation, AT)
                End If
            Next
        Catch EX As Exception
            MsgBox(EX.Message)
        End Try
    End Sub

    Private Sub ShowData()
        Cursor = Cursors.WaitCursor
        Dim i As Integer = 1
        Dim sql As String = ""
        Dim dt As DataTable = New DataTable()

        Try
            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT * FROM TblAbsensiManualPersonilPCG WHERE Deleted = 0 AND Tanggal BETWEEN '" & Format(dt1.Value, "yyyy-MM-dd") & "' AND '" & Format(dt2.Value, "yyyy-MM-dd") & "'")

            If dt.Rows.Count > 0 Then
                With fg
                    .Rows.Count = 1
                    For Each row As DataRow In dt.Rows
                        .AddItem(i)
                        .Item(i, 1) = row.Item("ID")
                        .Item(i, 2) = row.Item("Tanggal")
                        .Item(i, 3) = row.Item("Bagian")
                        .Item(i, 4) = row.Item("IDPersonil")
                        .Item(i, 5) = row.Item("Nama")
                        .Item(i, 6) = row.Item("Jabatan")
                        .Item(i, 7) = row.Item("IDPancang")
                        .Item(i, 8) = row.Item("Pancang")
                        .Item(i, 9) = row.Item("Kehadiran")
                        .Item(i, 10) = row.Item("Foto")
                        .Item(i, 11) = row.Item("Keterangan")
                        .Item(i, 12) = row.Item("CreatedBy")
                        .Item(i, 13) = row.Item("CreatedDate")
                        .Item(i, 14) = row.Item("CreatedComp")
                        i = i + 1
                    Next
                    .AutoSizeCols()
                End With
            Else
                MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
                fg.Rows.Count = 1
            End If
        Catch EX As Exception
            MsgBox(EX.Message)
        End Try

        Cursor = Cursors.Default
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Clear()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        GetPersonil()
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        ShowData()
    End Sub

    Public Class Absensi
        Public Property Tgl As DateTime
        Public Property Bagian As String
        Public Property IDPersonil As String
        Public Property Nama As String
        Public Property Jabatan As String
        Public Property IDP As Integer
        Public Property Pancang As String
        Public Property Kehadiran As String
        Public Property Foto As String
        Public Property Ket As String
        Public Property CreatedBy As String
        Public Property IDMst As Integer
        Public Property Flag As Integer
    End Class

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If rdAbsen1x.Checked = True Then
            Call SaveAbsen1x()
        Else
            Call SaveAbsen4x()
        End If
    End Sub

    Private Sub SaveAbsen1x()
        'cek jika sudah ada absen
        Dim sudahAbsen As String = ""
        sudahAbsen = DB.ExecuteScalarValue(Of String)(StrConnRMPApp, " select 'ada' as GetValueString from Android_tblAbsensiPancangNew where cast(CreatedDate as date)='" & Format(dtpAbsen.Value, "yyyy-MM-dd") & "' and IDPersonil='" & txtIDPersonil.Text & "' and AbsenManual=0 ")
        If sudahAbsen = "ada" Then
            MsgBox("Personil Ini Sudah Absen Di tanggal " & Format(dtpAbsen.Value, "dd-MM-yyyy") & " !", vbExclamation, "Save - " & AT)
            Exit Sub
        End If

        Dim Site As String = ""
        If rdP1.Checked = True Then
            Site = "P1"
        ElseIf rdP2.Checked = True Then
            Site = "P2"
        ElseIf rdP3.Checked = True Then
            Site = "P3"
        End If

        If txtIDPersonil.Text = "" Then
            MsgBox("Silahkan Cari Personil Terlebih Dahulu !", vbExclamation, "Save - " & AT)
            Exit Sub
        End If

        If txtNamaFile.Text = "" Then
            MsgBox("Silahkan Upload Foto Terlebih Dahulu !", vbExclamation, "Save - " & AT)
            Exit Sub
        End If

        If txtKet.Text = "Ketik keterangan alasan input absensi manual disini !" Then
            MsgBox("Silahkan Ketik Keterangan Alasan Terlebih Dahulu !", vbExclamation, "Save - " & AT)
            Exit Sub
        End If

        Try
            Dim obj As New Absensi With {
                .Tgl = dtpAbsen.Value,
                .Bagian = Site,
                .IDPersonil = txtIDPersonil.Text,
                .Nama = txtNama.Text,
                .Jabatan = txtJabatan.Text,
                .IDP = txtIDP.Text,
                .Pancang = txtPancang.Text,
                .Kehadiran = cboKehadiran.SelectedValue,
                .Foto = txtNamaFile.Text,
                .Ket = txtKet.Text,
                .CreatedBy = ClsSession.UserID,
                .IDMst = IDMst.Text,
                .Flag = 0}
            Dim result = (Save(obj))
        Catch ex As Exception
            MsgBox("Error !" + ex.Message, MsgBoxStyle.Exclamation)
            Exit Sub
        End Try
    End Sub

    Private Sub SaveAbsen4x()
        Dim Site As String = ""
        If rdP1.Checked = True Then
            Site = "P1"
        ElseIf rdP2.Checked = True Then
            Site = "P2"
        ElseIf rdP3.Checked = True Then
            Site = "P3"
        End If

        If txtIDPersonil.Text = "" Then
            MsgBox("Silahkan Cari Personil Terlebih Dahulu !", vbExclamation, "Save - " & AT)
            Exit Sub
        End If

        If txtNamaFile.Text = "" Then
            MsgBox("Silahkan Upload Foto Terlebih Dahulu !", vbExclamation, "Save - " & AT)
            Exit Sub
        End If

        If txtKet.Text = "Ketik keterangan alasan input absensi manual disini !" Then
            MsgBox("Silahkan Ketik Keterangan Alasan Terlebih Dahulu !", vbExclamation, "Save - " & AT)
            Exit Sub
        End If

        Try
            Dim obj As New Absensi With {
                .Tgl = dtpAbsen.Value,
                .Bagian = Site,
                .IDPersonil = txtIDPersonil.Text,
                .Nama = txtNama.Text,
                .Jabatan = txtJabatan.Text,
                .IDP = txtIDP.Text,
                .Pancang = txtPancang.Text,
                .Kehadiran = cboKehadiran.SelectedValue,
                .Foto = txtNamaFile.Text,
                .Ket = txtKet.Text,
                .CreatedBy = ClsSession.UserID,
                .IDMst = IDMst.Text,
                .Flag = 0}
            Dim result = (Save4x(obj))
        Catch ex As Exception
            MsgBox("Error !" + ex.Message, MsgBoxStyle.Exclamation)
            Exit Sub
        End Try
    End Sub

    Public Function Save(ByVal Obj As Absensi) As Integer
        Dim result As Integer
        Dim FotoName = txtNamaFile.Text

        Using cn As SqlConnection = New SqlConnection(StrConnRMPApp)
            If cn.State = ConnectionState.Closed Then cn.Open()
            Dim dParamsObject = New DynamicParameters(Obj)
            dParamsObject.Add("@Flag", 0, direction:=ParameterDirection.InputOutput)

            Using Trx As SqlTransaction = cn.BeginTransaction
                Try
                    If pic.Image IsNot Nothing Then
                        cn.Execute("spSaveAbsensiManualPCG", dParamsObject, Trx, commandType:=CommandType.StoredProcedure)
                        result = dParamsObject.Get(Of Integer)("@Flag")

                        If result > 0 Then
                            SaveImage(pathFoto & "\" & FotoName & ".jpeg", pic.Image)
                        End If

                        Trx.Commit()

                        If Not System.IO.File.Exists(pathFoto & FotoName) Then
                            If (SaveImage(pathFoto & "\" & FotoName & ".jpeg", pic.Image)) Then
                                Debug.WriteLine("OK")
                                MsgBox("Save Foto Success !", MsgBoxStyle.Information, AT)
                            End If
                        End If

                        Clear()

                        If System.IO.File.Exists(pathFoto & FotoName) Then
                            MsgBox("File exist !", MsgBoxStyle.Exclamation, AT)
                        End If

                        ShowData()
                    Else
                        result = dParamsObject.Get(Of Integer)("@Flag")
                        Trx.Commit()
                    End If
                Catch ex As Exception
                    Trx.Rollback()
                    MessageBox.Show(ex.Message)
                End Try
            End Using
        End Using
    End Function

    Public Function Save4x(ByVal Obj As Absensi) As Integer
        Dim result As Integer
        Dim FotoName = txtNamaFile.Text

        Using cn As SqlConnection = New SqlConnection(StrConnRMPApp)
            If cn.State = ConnectionState.Closed Then cn.Open()
            Dim dParamsObject = New DynamicParameters(Obj)
            dParamsObject.Add("@Flag", 0, direction:=ParameterDirection.InputOutput)

            Using Trx As SqlTransaction = cn.BeginTransaction
                Try
                    If pic.Image IsNot Nothing Then
                        cn.Execute("spSaveAbsensi4xManualPCG", dParamsObject, Trx, commandType:=CommandType.StoredProcedure)
                        result = dParamsObject.Get(Of Integer)("@Flag")

                        If result > 0 Then
                            SaveImage(pathFoto & "\" & FotoName & ".jpeg", pic.Image)
                        End If

                        Trx.Commit()

                        If Not System.IO.File.Exists(pathFoto & FotoName) Then
                            If (SaveImage(pathFoto & "\" & FotoName & ".jpeg", pic.Image)) Then
                                Debug.WriteLine("OK")
                                MsgBox("Save Foto Success !", MsgBoxStyle.Information, AT)
                            End If
                        End If

                        Clear()

                        If System.IO.File.Exists(pathFoto & FotoName) Then
                            MsgBox("File exist !", MsgBoxStyle.Exclamation, AT)
                        End If

                        ShowData()
                    Else
                        result = dParamsObject.Get(Of Integer)("@Flag")
                        Trx.Commit()
                    End If
                Catch ex As Exception
                    Trx.Rollback()
                    MessageBox.Show(ex.Message)
                End Try
            End Using
        End Using
    End Function

    Function SaveImage(filename As String, image As Image) As Boolean
        Dim mySource As New Bitmap(image.Width, image.Height)
        Dim grfx As Graphics = Graphics.FromImage(mySource)
        grfx.DrawImageUnscaled(image, Point.Empty)
        grfx.Dispose()
        mySource.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg)
        mySource.Dispose()
        Return True
    End Function

    Private Sub btnChoose_Click(sender As Object, e As EventArgs) Handles btnChoose.Click
        If txtIDPersonil.Text = "" Then
            MsgBox("Silahkan Cari Personil Terlebih Dahulu !", vbExclamation, "Choose File - " & AT)
            Exit Sub
        End If

        OpenFileDialog.Filter = "All Image Files|*.png;*.jpeg;*.jpg;*.JPG;*.JPEG"
        OpenFileDialog.Title = "Select Image File"

        If OpenFileDialog.ShowDialog = DialogResult.OK Then
            Dim pdfLog As String = txtIDPersonil.Text & "@" & Format(dtpAbsen.Value, "ddMMyyyy")
            txtNamaFile.Text = pdfLog
            NamaFile = OpenFileDialog.FileName
            On Error Resume Next
            pic.Image = System.Drawing.Image.FromFile(NamaFile)
        Else
            pic.Image = RMPApp.My.Resources.Resources.uploadtidakoke
        End If
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click

    End Sub

    Private Sub dtpAbsen_ValueChanged(sender As Object, e As EventArgs) Handles dtpAbsen.ValueChanged
        If txtIDPersonil.Text <> "" Then
            GetPersonil()
        End If

    End Sub

    Private Sub fg_DoubleClick(sender As Object, e As EventArgs) Handles fg.DoubleClick

        If fg.Col <> 10 Then Exit Sub

        Dim namaFoto As String = TryCast(fg.Item(fg.Row, 10), String)

        If String.IsNullOrEmpty(namaFoto) Then
            MsgBox("Foto tidak tersedia!", vbExclamation, AT)
            Exit Sub
        End If

        Dim path As String = IO.Path.Combine(pathFoto, namaFoto & ".jpeg")

        Using frm As New FrmFotoView
            If frm.TampilkanFotoAsync(path).GetAwaiter().GetResult() Then
                frm.ShowDialog()
            End If
        End Using

    End Sub
End Class