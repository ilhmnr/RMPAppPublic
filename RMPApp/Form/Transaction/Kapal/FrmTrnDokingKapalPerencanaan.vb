Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports DocumentFormat.OpenXml.Drawing.Diagrams
Imports DocumentFormat.OpenXml.Math
Imports Microsoft.Win32
Imports ZXing.Common.Detector

Public Class FrmTrnDokingKapalPerencanaan
    Dim txt As CellRange
    Dim Aksi As String = ""
    Dim Pancang, Kapal As Integer
    Private Sub FrmTrnPerencanaanDokingKapal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HeaderFg()
        ClearInput()
        EnabeldInput(False)
        CmbPancang.Enabled = True
        CmbKapal.Enabled = True
        EnabeldTombol(False)
        BtnRefresh.Enabled = True
        BtnAdd.Enabled = True

        CmbFrekunsi.Items.Add("6 Bulan")
        CmbFrekunsi.Items.Add("12 Bulan")
    End Sub
    Private Sub EnabeldTombol(flag As Boolean)
        BtnRefresh.Enabled = flag
        BtnAdd.Enabled = flag
        BtnEdit.Enabled = flag
        BtnSave.Enabled = flag
        BtnCancel.Enabled = flag
    End Sub

    Private Sub EnabeldInput(flag As Boolean)
        CmbPancang.Enabled = flag
        CmbKapal.Enabled = flag
        CmbFrekunsi.Enabled = flag
        Dtp1.Enabled = flag
        Dtp2.Enabled = flag
        ChkNonActive.Enabled = flag
    End Sub

    Private Sub ClearInput()
        CmbPancang.SelectedValue = -1
        CmbKapal.SelectedValue = -1
        CmbFrekunsi.SelectedValue = -1
        Dtp1.Value = Now
        Dtp2.Value = Now
        ChkNonActive.Checked = False

        Aksi = ""

        Try
            Dim dt As DataTable = New DataTable()
            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " select IDPancang,Pancang = convert(varchar,IDPancang) + '. ' + Pancang from Android_tblMstPancang WHERE IDPancang in ( select DISTINCT IdPancang from TblTrnDokingKapal ) ORDER BY IDPancang ASC ")
            With CmbPancang
                .DataSource = dt
                .DisplayMember = "Pancang"
                .ValueMember = "IDPancang"
                .SelectedIndex = -1
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub HeaderFg()
        With fg
            .Rows.Fixed = 1
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Cols.Count = 17

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

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).TextAlign = TextAlignEnum.LeftCenter : .Cols(0).AllowEditing = False : .Cols(0).AllowMerging = True
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Pancang" : .Cols(1).TextAlign = TextAlignEnum.LeftCenter : .Cols(1).AllowEditing = False : .Cols(1).AllowMerging = True
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Kapal" : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).AllowEditing = False : .Cols(2).AllowMerging = True
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Frekuensi" : .Cols(3).TextAlign = TextAlignEnum.CenterCenter : .Cols(3).AllowEditing = False : .Cols(3).AllowMerging = True
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Tgl Perencanaan" : .Cols(4).TextAlign = TextAlignEnum.CenterCenter : .Cols(4).AllowEditing = False : .Cols(4).AllowMerging = True
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Tgl Toleransi" : .Cols(5).TextAlign = TextAlignEnum.CenterCenter : .Cols(5).AllowEditing = False : .Cols(5).AllowMerging = True
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Tgl Realisasi" : .Cols(6).TextAlign = TextAlignEnum.CenterCenter : .Cols(6).AllowEditing = False : .Cols(6).AllowMerging = True
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Tgl Approval" : .Cols(7).TextAlign = TextAlignEnum.CenterCenter : .Cols(7).AllowEditing = False : .Cols(7).AllowMerging = True
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Created By" : .Cols(8).TextAlign = TextAlignEnum.CenterCenter : .Cols(8).AllowEditing = False : .Cols(8).AllowMerging = True
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Created Date" : .Cols(9).TextAlign = TextAlignEnum.CenterCenter : .Cols(9).AllowEditing = False : .Cols(9).AllowMerging = True
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "Updated By" : .Cols(10).TextAlign = TextAlignEnum.CenterCenter : .Cols(10).AllowEditing = False : .Cols(10).AllowMerging = True
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "Updated Date" : .Cols(11).TextAlign = TextAlignEnum.CenterCenter : .Cols(11).AllowEditing = False : .Cols(11).AllowMerging = True
            txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "NonActive" : .Cols(12).TextAlign = TextAlignEnum.CenterCenter : .Cols(12).AllowEditing = False : .Cols(12).AllowMerging = True
            txt = .GetCellRange(0, 13, 0, 13) : txt.Data = "Approval" : .Cols(13).Visible = False
            txt = .GetCellRange(0, 14, 0, 14) : txt.Data = "Detail Id" : .Cols(14).Visible = False
            txt = .GetCellRange(0, 15, 0, 15) : txt.Data = "IdPancang" : .Cols(15).Visible = False
            txt = .GetCellRange(0, 16, 0, 16) : txt.Data = "IdKapal" : .Cols(16).Visible = False

            .AutoSizeCols()
        End With
    End Sub
    Private Sub ShowData()
        Me.Cursor = Cursors.WaitCursor

        Dim dt As DataTable = New DataTable
        Dim i As Integer = 1
        Dim sql As String = ""

        If CmbPancang.Text <> "" Then
            sql = Modul_RMP.Func.SetCondition(sql, " IdPancang = '" & CmbPancang.SelectedValue & "' ")
        End If

        If CmbKapal.Text <> "" Then
            sql = Modul_RMP.Func.SetCondition(sql, " IdKapal = '" & CmbKapal.SelectedValue & "' ")
        End If

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " SELECT * FROM [RMPApp].[dbo].[TblTrnDokingKapal] where NonActive=0 and idkapal in ( select KapalID from tblMstKapal where NonActive=0 ) " & IIf(sql = "", "", " And " & sql) & " order by TglToleransi asc ")

        If dt.Rows.Count > 0 Then
            With fg
                .Rows.Count = 1
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, 1) = row("Pancang")
                    .Item(i, 2) = row("NamaKapal")
                    .Item(i, 3) = row("Frekuensi")
                    .Item(i, 4) = row("TglPerencanaan")
                    .Item(i, 5) = row("TglToleransi")
                    .Item(i, 6) = row("TglRealisasi")
                    .Item(i, 7) = row("TglApproval")
                    .Item(i, 8) = row("CreatedBy")
                    .Item(i, 9) = row("CreatedDate")
                    .Item(i, 10) = row("UpdatedBy")
                    .Item(i, 11) = row("UpdatedDate")
                    .Item(i, 12) = row("NonActive")
                    .Item(i, 13) = row("Approval")
                    .Item(i, 14) = row("Id")
                    .Item(i, 15) = row("IdPancang")
                    .Item(i, 16) = row("IdKapal")

                    i += 1
                Next

                .AutoSizeCols()
            End With
        Else
            MsgBox("Tidak Ada Data !", vbInformation, AT)
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Dim topColor As Color = Color.FromArgb(0, 172, 251) ' Warna atas yang tebal
        Dim bottomColor As Color = Color.FromArgb(0, 0, 255, 255) ' Warna bawah yang pudar

        Dim gradientRect As New Rectangle(0, 0, Panel1.Width, Panel1.Height)

        Using brush As New Drawing2D.LinearGradientBrush(gradientRect, topColor, bottomColor, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(brush, gradientRect)
        End Using
    End Sub

    Private Sub CmbPancang_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbPancang.SelectedValueChanged
        If Aksi = "Add" Then
            Try
                Dim dt As DataTable = New DataTable()
                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select KapalID,KapalName = Convert(Varchar(5),KapalID) + '. ' + KapalName from tblMstKapal where IDPancang='" & CmbPancang.SelectedValue & "' and NonActive=0 and KapalID not in (select distinct IdKapal from TblTrnDokingKapal where NonActive=0)")
                With CmbKapal
                    .DataSource = dt
                    .DisplayMember = "KapalName"
                    .ValueMember = "KapalID"
                    .SelectedIndex = -1
                End With
            Catch ex As Exception
            End Try
        Else
            Try
                Dim dt As DataTable = New DataTable()
                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select KapalID,KapalName = Convert(Varchar(5),KapalID) + '. ' + KapalName from tblMstKapal where IDPancang='" & CmbPancang.SelectedValue & "' and NonActive=0 and KapalID in (select distinct IdKapal from TblTrnDokingKapal where NonActive=0)")
                With CmbKapal
                    .DataSource = dt
                    .DisplayMember = "KapalName"
                    .ValueMember = "KapalID"
                    .SelectedIndex = -1
                End With
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click
        Try
            If fg.Rows.Count > 1 Then
                ClearInput()
                With fg
                    CmbPancang.SelectedValue = .Item(.RowSel, 15)
                    Pancang = .Item(.RowSel, 15)
                    TxtIdDtl.Text = .Item(.RowSel, 14)
                    CmbKapal.SelectedValue = .Item(.RowSel, 16)
                    Kapal = .Item(.RowSel, 16)
                    If .Item(.RowSel, 3) = 6 Then
                        CmbFrekunsi.Text = "6 Bulan"
                    Else
                        CmbFrekunsi.Text = "12 Bulan"
                    End If
                    Dtp1.Value = .Item(.RowSel, 4)
                    Dtp2.Value = .Item(.RowSel, 5)
                    ChkNonActive.Checked = .Item(.RowSel, 12)
                End With
            End If
        Catch ex As Exception
        End Try

        If CmbPancang.Text <> "" Then
            BtnEdit.Enabled = True
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        ClearInput()
        EnabeldTombol(False)
        BtnRefresh.Enabled = True
        BtnAdd.Enabled = True
        EnabeldInput(False)
        CmbPancang.Enabled = True
        CmbKapal.Enabled = True
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Me.Cursor = Cursors.WaitCursor

        Dim koneksi As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnRMPApp)
        Dim transaksi As SqlTransaction
        transaksi = koneksi.BeginTransaction

        If CmbFrekunsi.Text = "" Then
            MsgBox("Anda Belum Memilih Frekuensi Kapal !", vbInformation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        ElseIf Dtp1.Value > Dtp2.Value Then
            MsgBox("Tanggal Toleransi Tidak Boleh Sebelum Tanggal Perencanaan !", vbInformation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        Try
            If SaveData(koneksi, transaksi) = False Then
                transaksi.Rollback()
                MsgBox("Simpan Data Gagal !", vbCritical, AT)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            transaksi.Commit()
            MsgBox("Simpan Data Berhasil !", vbInformation, AT)

            CmbFrekunsi.Text = ""
            CmbKapal.Text = ""
            Dtp1.Value = Now
            Dtp2.Value = Now
            ChkNonActive.Checked = False

            Aksi = ""

            Try
                Dim dt As DataTable = New DataTable()
                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " select IDPancang,Pancang = convert(varchar,IDPancang) + '. ' + Pancang from Android_tblMstPancang WHERE IDPancang in ( select DISTINCT IdPancang from TblTrnDokingKapal ) ORDER BY IDPancang ASC ")
                With CmbPancang
                    .DataSource = dt
                    .DisplayMember = "Pancang"
                    .ValueMember = "IDPancang"
                    .SelectedIndex = -1
                End With
            Catch ex As Exception
            End Try

            ShowData()

            EnabeldTombol(False)
            BtnRefresh.Enabled = True
            BtnAdd.Enabled = True

            EnabeldInput(False)
            CmbPancang.Enabled = True
            CmbKapal.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            koneksi.Close()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function SaveData(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        SaveData = False

        Dim MyCon As SqlConnection = Conn
        Dim MyConTrans As SqlTransaction = Trans
        Dim cmd As New SqlCommand

        With cmd
            .Connection = Conn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RMPApp..spSaveTrnDokingPerencanaanKapal"
            .Transaction = MyConTrans

            .Parameters.Add("@DetailId", SqlDbType.Int).Value = CInt(TxtIdDtl.Text)
            .Parameters.Add("@IdKapal", SqlDbType.Int).Value = CmbKapal.SelectedValue
            .Parameters.Add("@IdPancang", SqlDbType.Int).Value = CmbPancang.SelectedValue
            If CmbFrekunsi.Text = "6 Bulan" Then
                .Parameters.Add("@Frekuensi", SqlDbType.Int).Value = 6
            Else
                .Parameters.Add("@Frekuensi", SqlDbType.Int).Value = 12
            End If
            .Parameters.Add("@TglPerencanaan", SqlDbType.Date).Value = Format(Dtp1.Value, "yyyy-MM-dd")
            .Parameters.Add("@TglToleransi", SqlDbType.Date).Value = Format(Dtp2.Value, "yyyy-MM-dd")
            .Parameters.Add("@UserRMPApp", SqlDbType.VarChar, 50).Value = ClsSession.UserID
            If ChkNonActive.Checked = True Then
                .Parameters.Add("@NonActive", SqlDbType.Int).Value = 1
            Else
                .Parameters.Add("@NonActive", SqlDbType.Int).Value = 0
            End If
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

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        If fg.Item(fg.RowSel, 13) = 0 Then
            EnabeldInput(True)
            CmbPancang.Enabled = False
            CmbKapal.Enabled = False
            EnabeldTombol(False)
            BtnSave.Enabled = True
            BtnCancel.Enabled = True
        End If

        Aksi = ""

        Try
            Dim dt As DataTable = New DataTable()
            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " select IDPancang,Pancang = convert(varchar,IDPancang) + '. ' + Pancang from Android_tblMstPancang WHERE IDPancang in ( select DISTINCT IdPancang from TblTrnDokingKapal ) ORDER BY IDPancang ASC ")
            With CmbPancang
                .DataSource = dt
                .DisplayMember = "Pancang"
                .ValueMember = "IDPancang"
                .SelectedIndex = -1
            End With

            Dim dt2 As DataTable = New DataTable()
            dt2 = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select KapalID,KapalName = Convert(Varchar(5),KapalID) + '. ' + KapalName from tblMstKapal where IDPancang='" & CmbPancang.SelectedValue & "' and KapalID in (select distinct IdKapal from TblTrnDokingKapal where NonActive=0)")
            With CmbKapal
                .DataSource = dt
                .DisplayMember = "KapalName"
                .ValueMember = "KapalID"
                .SelectedIndex = -1
            End With
        Catch ex As Exception
        End Try

        CmbPancang.SelectedValue = Pancang
        CmbKapal.SelectedValue = Kapal
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        ClearInput()
        TxtIdDtl.Text = "0"
        EnabeldInput(True)
        ChkNonActive.Enabled = False
        EnabeldTombol(False)
        BtnSave.Enabled = True
        BtnCancel.Enabled = True

        Aksi = "Add"

        Try
            Dim dt As DataTable = New DataTable()
            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " select IDPancang,Pancang = convert(varchar,IDPancang) + '. ' + Pancang from Android_tblMstPancang WHERE IDPancang not in ( select * from vwKapalSudahDoking ) and IDPancang in (select distinct IDPancang from tblMstKapal where NonActive=0) ORDER BY IDPancang ASC ")
            With CmbPancang
                .DataSource = dt
                .DisplayMember = "Pancang"
                .ValueMember = "IDPancang"
                .SelectedIndex = -1
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim filename As String
            Me.SaveFileDialog1.ShowDialog()
            filename = SaveFileDialog1.FileName
            Me.fg.SaveExcel(filename & ".xlsx", "Sheet1", FileFlags.IncludeFixedCells)
            MsgBox("Convert Success !", MsgBoxStyle.Information, AT)
        Catch ex As Exception
            MsgBox("Convert Gagal !", vbInformation, ex)
        End Try
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        ShowData()
    End Sub

    Private Sub CmbPancang_KeyUp(sender As Object, e As KeyEventArgs) Handles CmbPancang.KeyUp
        UI.AutoCompleteCombo_KeyUp(CmbPancang, e)
    End Sub

    Private Sub CmbKapal_KeyUp(sender As Object, e As KeyEventArgs) Handles CmbKapal.KeyUp
        UI.AutoCompleteCombo_KeyUp(CmbKapal, e)
    End Sub
End Class