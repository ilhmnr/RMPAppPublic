Imports System.Data.SqlClient
Imports System.Windows.Forms.DataVisualization.Charting
Imports C1.Win.C1FlexGrid

Public Class FrmMonVerifikasiTimbangPCG
    Dim conn As SqlConnection

    Private Sub FrmMonVerifikasiTimbangPCG_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Modul_RMP.Combo.SetPancang(cmbIDPancang)
        dtp1.Value = Format(Now, "dd-MM-yyyy")
        cmbIDPancang.Enabled = False
    End Sub

    Private Sub chkTanggal_CheckedChanged(sender As Object, e As EventArgs) Handles chkPCG.CheckedChanged
        If chkPCG.Checked = True Then
            cmbIDPancang.Enabled = True
        Else
            cmbIDPancang.Enabled = False
        End If
    End Sub

    Private Sub HeaderData()
        With fgDtl
            Dim txt As CellRange
            .AllowEditing = False
            .Font = New Font("Century Gothic", 9.0!, FontStyle.Bold)
            .Cols.Count = 9
            .Cols.Fixed = 2
            .Styles.Normal.WordWrap = True
            .AllowResizing = AllowResizingEnum.Both
            .DrawMode = DrawModeEnum.OwnerDraw

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No"
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Nama Bluetooth" : .Cols(1).Visible = True
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Photo" : .Cols(2).TextAlign = TextAlignEnum.CenterCenter : .Cols(2).Name = "foto"
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Pancang ID" : .Cols(3).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Nama Pancang" : .Cols(4).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Tanggal Timbang" : .Cols(5).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Nilai Timbang" : .Cols(6).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Nama Device" : .Cols(7).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Kategori Timbangan" : .Cols(8).TextAlign = TextAlignEnum.CenterCenter

            .AutoSizeCols()
        End With
    End Sub

    Private Sub panggilData()
        Try
            conn = DB.OpenConnection(StrConnRMPApp)
            Dim cmd As New SqlCommand("sp_MonWeightVerification", conn)
            cmd.CommandType = CommandType.StoredProcedure
            If chkPCG.Checked = True Then
                cmd.Parameters.Add("@pancang_id", SqlDbType.Int, 10).Value = cmbIDPancang.SelectedValue
            Else
                cmd.Parameters.Add("@pancang_id", SqlDbType.Int, 10).Value = 0
            End If
            cmd.Parameters.Add("@date", SqlDbType.SmallDateTime).Value = dtp1.Value

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            fgDtl.Rows.Count = fgDtl.Rows.Fixed

            If Not dr.HasRows Then
                MessageBox.Show("Data tidak ditemukan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            While dr.Read()
                Dim rowIndex As Integer = fgDtl.Rows.Add().Index
                fgDtl(rowIndex, 0) = fgDtl.Rows.Count - fgDtl.Rows.Fixed
                If Not dr.IsDBNull(dr.GetOrdinal("bluetooth_name")) Then fgDtl(rowIndex, 1) = dr("bluetooth_name").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("photo")) Then fgDtl(rowIndex, 2) = dr("photo").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("pancang_id")) Then fgDtl(rowIndex, 3) = dr("pancang_id").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("pancang_name")) Then fgDtl(rowIndex, 4) = dr("pancang_name").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("recorded_at")) Then fgDtl(rowIndex, 5) = dr("recorded_at").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("weight_value")) Then fgDtl(rowIndex, 6) = dr("weight_value").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("device_name")) Then fgDtl(rowIndex, 7) = dr("device_name").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("scale_category")) Then fgDtl(rowIndex, 8) = dr("scale_category").ToString()
            End While

            fgDtl.AutoSizeCols()
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat mengambil data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        conn.Close()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        HeaderData()
        panggilData()
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Dim filename As String = ""

        Try
            Cursor.Current = Cursors.WaitCursor

            If SaveFileDialog.ShowDialog() = DialogResult.OK Then
                filename = SaveFileDialog.FileName

                ' Pastikan ada ekstensi .xls
                If Not filename.EndsWith(".xls") Then
                    filename &= ".xls"
                End If

                ' Ekspor FlexGrid ke Excel
                fgDtl.SaveExcel(filename, "Sheet1", FileFlags.IncludeFixedCells)

                MessageBox.Show("Export berhasil ke file: " & filename, "Export Excel", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat export: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub


    Private imageCache As New Dictionary(Of String, Image)()
    Private Sub fgDtl_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles fgDtl.MouseDoubleClick

        Dim hit As C1.Win.C1FlexGrid.HitTestInfo = fgDtl.HitTest(e.X, e.Y)

        If hit.Row < fgDtl.Rows.Fixed Then Exit Sub

        Dim filename As String = TryCast(fgDtl(hit.Row, "foto"), String)

        If String.IsNullOrEmpty(filename) Then
            MessageBox.Show("Foto tidak tersedia.")
            Exit Sub
        End If

        Dim url As String =
        $"https://apip2.myrsup.co.id:8083/api/file/uploadNew?subfolder=notapancangapi/ImagesWeightVerification&filename={filename}&flag=notapancang"

        Dim imageKey As String = $"nota_{filename}"
        Dim image As Image = Nothing

        If imageCache.ContainsKey(imageKey) Then
            image = imageCache(imageKey)
        Else
            Try
                Using client As New Net.WebClient()
                    client.Headers.Add("User-Agent", "VB App")

                    Using stream As IO.Stream = client.OpenRead(url)
                        Using img As Image = Image.FromStream(stream)
                            image = New Bitmap(img)
                        End Using
                    End Using
                End Using

                imageCache(imageKey) = image

            Catch ex As Exception
                MessageBox.Show("Gagal memuat gambar. Error: " & ex.Message,
                            "Kesalahan",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
                Exit Sub
            End Try
        End If

        If image IsNot Nothing Then
            Using previewForm As New FrmFotoView
                previewForm.TampilkanImage(image)
                previewForm.ShowDialog()
            End Using
        Else
            MessageBox.Show("Gambar tidak tersedia.")
        End If

    End Sub

End Class