Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient

Public Class FrmTrnRestorDokingKapal
    Dim txt As CellRange
    Private Sub FrmTrnApprovalDokingKapal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HeaderFg()
        ShowData()
    End Sub
    Private Sub ShowData()
        Me.Cursor = Cursors.WaitCursor

        Dim dt As DataTable = New DataTable
        Dim i As Integer = 1

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "  SELECT * FROM [RMPApp].[dbo].[TblTrnDokingKapal] where NonActive=1 and TglRealisasi is not null and Approval=1 order by TglApproval desc ")

        fg.Rows.Count = 1
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

                    Dim style As C1.Win.C1FlexGrid.CellStyle = Me.fg.Styles.Add("style")
                    style.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
                    .SetCellImage(i, 8, My.Resources.Doc1)
                    .SetCellStyle(i, 8, style)

                    .Item(i, 10) = row("Id")
                    .Item(i, 11) = row("IdPancang")
                    .Item(i, 12) = row("IdKapal")
                    .Item(i, 13) = row("IdDtlRealisasi")

                    i += 1
                Next

                .AutoSizeCols()
            End With
        Else
            MsgBox("Tidak Ada Data !", vbInformation, AT)
        End If

        Me.Cursor = Cursors.Default
    End Sub
    Private Sub HeaderFg()
        With fg
            .Rows.Fixed = 1
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Cols.Count = 14

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
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Detail Perbaikan"
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Select"
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "DetailId" : .Cols(10).Visible = False
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "IdPancang" : .Cols(11).Visible = False
            txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "IdKapal" : .Cols(12).Visible = False
            txt = .GetCellRange(0, 13, 0, 13) : txt.Data = "IdRealisasi" : .Cols(13).Visible = False

            .AutoSizeCols()
        End With
    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Dim topColor As Color = Color.FromArgb(0, 172, 251) ' Warna atas yang tebal
        Dim bottomColor As Color = Color.FromArgb(0, 0, 255, 255) ' Warna bawah yang pudar

        Dim gradientRect As New Rectangle(0, 0, Panel1.Width, Panel1.Height)

        Using brush As New Drawing2D.LinearGradientBrush(gradientRect, topColor, bottomColor, Drawing2D.LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(brush, gradientRect)
        End Using
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click
        If fg.Rows.Count > 1 Then
            With fg
                If .Col = 8 Then
                    If Application.OpenForms.OfType(Of FrmTrnDokingKapalRealisasi)().Any() Then
                        FrmMonDokingKapal.Close()
                    End If
                    FrmMonDokingKapal.IdRealisasi = .Item(.RowSel, 13)
                    FrmMonDokingKapal.Show()
                End If
            End With
        End If
    End Sub


    Private Function SaveData(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal IdDtl As Integer, ByVal IdKapal As Integer) As Boolean
        SaveData = False

        Dim MyCon As SqlConnection = Conn
        Dim MyConTrans As SqlTransaction = Trans
        Dim cmd As New SqlCommand

        With cmd
            .Connection = Conn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RMPApp..spSaveTrnRestoreKapal"
            .Transaction = MyConTrans

            .Parameters.Add("@IdKapal", SqlDbType.Int).Value = IdKapal
            .Parameters.Add("@IdDtl", SqlDbType.Int).Value = IdDtl
            .Parameters.Add("@UserRMPAPP", SqlDbType.VarChar, 50).Value = ClsSession.UserID
            .Parameters.Add(New SqlParameter("@Flag", SqlDbType.TinyInt, 1, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))

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

    Private Sub BtnRestore_Click(sender As Object, e As EventArgs) Handles BtnRestore.Click
        Me.Cursor = Cursors.WaitCursor

        Dim FlagAdaDataDiPilih As Integer = 0
        Dim koneksi As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnRMPApp)
        Dim transaksi As SqlTransaction
        transaksi = koneksi.BeginTransaction

        If fg.Rows.Count > 1 Then
            For i = 1 To fg.Rows.Count - 1
                If fg.Item(i, 9) = True Then
                    FlagAdaDataDiPilih = 1
                End If
            Next

            If FlagAdaDataDiPilih = 0 Then
                MsgBox("Tidak Ada Data Yang Di Pilih !", vbInformation, AT)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            For i = 1 To fg.Rows.Count - 1
                If fg.Item(i, 9) = True Then
                    If SaveData(koneksi, transaksi, fg.Item(i, 13), fg.Item(i, 12)) = False Then
                        transaksi.Rollback()
                        MsgBox("Simpan Data Gagal !", vbCritical, AT)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                End If
            Next

            transaksi.Commit()

            MsgBox("Approval Data Berhasil !", vbInformation, AT)
            ShowData()
        Else
            MsgBox("Tidak Ada Data Yang Akan Di Approval !", vbInformation, AT)
        End If

        Me.Cursor = Cursors.Default
    End Sub
End Class