
Imports System.Data.SqlClient
Imports C1.C1Rdl
Imports C1.Util.DX
Imports C1.Win.C1FlexGrid
Imports Microsoft.Reporting.Map.WebForms.BingMaps
Imports Syncfusion.Pdf.Graphics

Public Class FrmApprovelUserToko
    Dim nm As String
    Dim ClsRelasiLoyal_ As New ClsRelasiLoyal
    Dim adapter As SqlDataAdapter
    Dim connetionString As String
    Dim connection As SqlConnection
    Dim sumbrutoperrelasi As Double
    Dim TotalAllMonth As Double
    Dim TotalPerKK As Double
    Dim TotalPerPancang As Double
    Dim lopkk As Integer
    Dim loppcg As Integer
    Dim intensitas As Integer
    Dim StatusUser As Integer
    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub ApprovelUserToko_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HeaderFG()
        CELL()
        schKg()
        SHOWDATA3()
        'Cheklis Approval dan Toko sebagai pilihan defaultnya
        For i = 2 To fg.Rows.Count - 1
            fg.Item(i, 7) = True
            fg.Item(i, 8) = False
            fg.Item(i, 9) = True
        Next
    End Sub


    Private Sub schKg()
        With schfg
            .SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
            .SearchDelay = 2
            .Watermark = "Cari Disini"
            .SetC1FlexGridSearchPanel(fg, schfg)
        End With
    End Sub
    Public Sub HeaderFG()
        With fg
            .AutoGenerateColumns = True
            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular)
            .Rows.Count = 2
            .Cols.Count = 10
            .Cols.Fixed = 1
            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(1).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(1).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 2
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Rows(1).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
        End With
    End Sub



    Private Sub CELL()
        Dim txt As CellRange
        With fg

            txt = .GetCellRange(0, 0, 1, 0) : txt.Data = "NO" : .Cols(0).Name = "NO" : .Cols(0).Width = 60 : .Cols(0).AllowMerging = True : .Cols(0).TextAlign = TextAlignEnum.CenterCenter : .Cols(0).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 1, 1, 1) : txt.Data = "NAMA LENGKAP" : .Cols(1).Name = "NAMALENGKAP" : .Cols(1).AllowMerging = True : .Cols(1).TextAlign = TextAlignEnum.CenterCenter : .Cols(1).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(1).AllowEditing = False
            txt = .GetCellRange(0, 2, 1, 2) : txt.Data = "NIK" : .Cols(2).Width = 120 : .Cols(2).Name = "NIK" : .Cols(2).AllowMerging = True : .Cols(2).TextAlign = TextAlignEnum.CenterCenter : .Cols(2).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(2).AllowEditing = False
            txt = .GetCellRange(0, 3, 1, 3) : txt.Data = "ALAMAT" : .Cols(3).Name = "ALAMAT" : .Cols(3).AllowMerging = True : .Cols(3).TextAlign = TextAlignEnum.CenterCenter : .Cols(3).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(3).AllowEditing = False
            txt = .GetCellRange(0, 4, 1, 4) : txt.Data = "TOKO" : .Cols(4).Name = "TOKO" : .Cols(4).AllowMerging = True : .Cols(4).TextAlign = TextAlignEnum.CenterCenter : .Cols(4).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(4).AllowEditing = False
            txt = .GetCellRange(0, 5, 1, 5) : txt.Data = "Ktp" : .Cols(5).Name = "KTP" : .Cols(5).Width = 140 : .Cols(5).TextAlign = TextAlignEnum.LeftCenter : .Cols(5).AllowMerging = True : .Cols(5).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(5).AllowEditing = False
            txt = .GetCellRange(0, 6, 1, 6) : txt.Data = "User" : .Cols(6).Name = "USER_" : .Cols(6).Width = 140 : .Cols(6).TextAlign = TextAlignEnum.LeftCenter : .Cols(6).AllowMerging = True : .Cols(6).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(6).AllowEditing = False
            txt = .GetCellRange(0, 7, 0, 8) : txt.Data = "Status User" : .Cols(7).TextAlign = TextAlignEnum.CenterCenter : .Cols(8).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 7, 1, 7) : txt.Data = "Toko" : .Cols(7).Name = "Toko" : .Cols(7).Width = 140 : .Cols(7).TextAlign = TextAlignEnum.LeftCenter : .Cols(7).AllowMerging = True : .Cols(7).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(7).AllowEditing = True
            txt = .GetCellRange(1, 8, 1, 8) : txt.Data = "Purchaser" : .Cols(8).Name = "Purchaser" : .Cols(8).Width = 140 : .Cols(8).TextAlign = TextAlignEnum.LeftCenter : .Cols(8).AllowMerging = True : .Cols(8).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(8).AllowEditing = True
            txt = .GetCellRange(0, 9, 1, 9) : txt.Data = "APPROVAL" : .Cols(9).Name = "APPROVAL" : .Cols(9).Width = 140 : .Cols(9).AllowMerging = True : .Cols(9).AllowEditing = True

        End With

    End Sub




    Public Sub SHOWDATA3()
        Dim i As Integer = 2
        Try
            Dim dt As DataTable = New DataTable
            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT  NAMALENGKAP,NIK,ALAMAT,nama_toko, FOTOKTP,FOTOuser,CAST(1 AS BIT)  AS Toko,CAST(1 AS BIT)  AS Purchaser,CAST(1 AS BIT)  AS APPROVAL from RMPApp..vwpointokopcg where statusApprove=2 AND TolakStatus=0")
            fg.Rows.Count = dt.Rows.Count + 2
            For Each row As DataRow In dt.Rows
                fg.Item(i, 0) = i - 1
                fg.Item(i, 1) = row.Item("NAMALENGKAP")
                fg.Item(i, 2) = row.Item("NIK")
                fg.Item(i, 3) = row.Item("ALAMAT")
                fg.Item(i, 4) = row.Item("nama_toko")

                'memasukan gambar ke kolom 7 dan 8
                Me.fg.Rows(i).Height = 170
                Me.fg.Cols(5).Width = 300
                Me.fg.Cols(6).Width = 250

                Dim wc As New System.Net.WebClient()
                Dim url As String = "http://222.124.139.166:5006/ImageNota/ImagesPoinKTP/" + row.Item("FOTOKTP") + ".jpg"
                Dim imageBytes As Byte() = wc.DownloadData(url)
                Dim ms As New System.IO.MemoryStream(imageBytes)
                Dim originalImage As Image = Image.FromStream(ms)
                ' mengatur ukuran gambar
                Dim newWidth As Integer = 300 ' lebar baru gambar
                Dim newHeight As Integer = 170 ' tinggi baru gambar
                Dim thumbnailImage As Image = originalImage.GetThumbnailImage(newWidth, newHeight, Nothing, IntPtr.Zero)

                Dim wc2 As New System.Net.WebClient()
                Dim url2 As String = "http://222.124.139.166:5006/ImageNota/ImagesPoinUser/" + row.Item("FOTOuser") + ".jpg"
                Dim imageBytes2 As Byte() = wc2.DownloadData(url2)
                Dim ms2 As New System.IO.MemoryStream(imageBytes2)
                Dim originalImage2 As Image = Image.FromStream(ms2)
                ' mengatur ukuran gambar
                Dim newWidth2 As Integer = 250 ' lebar baru gambar
                Dim newHeight2 As Integer = 170 ' tinggi baru gambar
                Dim thumbnailImage2 As Image = originalImage2.GetThumbnailImage(newWidth2, newHeight2, Nothing, IntPtr.Zero)

                Me.fg.SetCellImage(i, 5, thumbnailImage)
                Me.fg.SetCellImage(i, 6, thumbnailImage2)

                i += 1
            Next
            'fg.AutoSizeCols()
            fg.Rows.Count = dt.Rows.Count + 2
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs)
        Select Case e.Col
            Case 6, 7
                e.Cancel = False
            Case Else

        End Select
    End Sub

    Private Sub cbxAll_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAll.CheckedChanged
        If (cbxAll.Checked) Then
            For i = 2 To fg.Rows.Count
                fg(i, "APPROVAL") = True
            Next i
        Else
            For i = 2 To fg.Rows.Count
                fg(i, "APPROVAL") = False
            Next i
        End If
    End Sub

    Private Sub txtCari_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcari.KeyPress
        If (e.KeyChar = Chr(13)) Then
            SHOWDATA3()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SHOWDATA3()
    End Sub
    Private Function SaveApRej(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ApproveReject As Integer, ByVal NIK As String, ByVal StatusUser As Integer) As Boolean
        Dim MyCMD As New SqlCommand
        Try
            With MyCMD
                .Connection = Conn
                .CommandType = CommandType.StoredProcedure
                .CommandText = "RMPAPP..spApprove"
                .Transaction = Trans
                .Parameters.Add("@ApproveReject", SqlDbType.Int).Value = ApproveReject
                .Parameters.Add("@nik", SqlDbType.VarChar).Value = NIK
                .Parameters.Add("@ApproveBy", SqlDbType.VarChar).Value = ClsSession.UserID.ToString
                .Parameters.Add("@remark", SqlDbType.VarChar).Value = txtAlasan.Text
                .Parameters.Add("@StatusUser", SqlDbType.Int).Value = StatusUser
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

    Private Sub save(ByVal approvereject As Integer)
        Dim koneksi As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnRMPApp)
        Dim Transaksi As SqlTransaction
        Transaksi = koneksi.BeginTransaction


        Dim sql As String
        Me.Cursor = Cursors.WaitCursor
        Try
            For i = 2 To fg.Rows.Count - 1
                If fg.Item(i, "APPROVAL") = True Then
                    'cek statusUser nya jika 0=purchaser dan 1=toko
                    If fg.Item(i, 7) = True Then
                        StatusUser = 1
                    Else
                        StatusUser = 0
                    End If
                    If SaveApRej(koneksi, Transaksi, approvereject, fg.Item(i, "NIK"), StatusUser) = False Then
                        Transaksi.Rollback()
                        MsgBox("Restore Data Gagal", vbExclamation, "Save Data - " & AT)
                        Exit Try
                    End If
                End If
            Next i

            Transaksi.Commit()
            Me.Cursor = Cursors.Default
            If approvereject = 1 Then
                MessageBox.Show("Approve data berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Reject data berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            SHOWDATA3()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Transaksi.Rollback()
            Me.Cursor = Cursors.Default
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub
    Private Sub btnApproved_Click(sender As Object, e As EventArgs) Handles btnApproved.Click
        save(1)
    End Sub

    Private Sub btnRejected_Click(sender As Object, e As EventArgs) Handles btnRejected.Click
        save(2)
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click
        With fg
            If .Rows.Count > 2 Then
                'jika check toko di klik
                If .Col = 7 Then
                    If .Item(.RowSel, 7) = True Then
                        .Item(.RowSel, 7) = True
                        .Item(.RowSel, 8) = False
                    Else
                        .Item(.RowSel, 7) = False
                        .Item(.RowSel, 8) = True
                    End If
                    'jika check purcheser di klik
                ElseIf .Col = 8 Then
                    If .Item(.RowSel, 8) = True Then
                        .Item(.RowSel, 7) = False
                        .Item(.RowSel, 8) = True
                    Else
                        .Item(.RowSel, 7) = True
                        .Item(.RowSel, 8) = False
                    End If
                End If
            End If
        End With
    End Sub
End Class