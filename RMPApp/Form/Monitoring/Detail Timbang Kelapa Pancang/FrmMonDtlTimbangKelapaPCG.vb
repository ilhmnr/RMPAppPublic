Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports System.Windows.Forms
Imports System.Drawing
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices


Public Class FrmMonDtlTimbangKelapaPCG
    Dim conn As SqlConnection

    ' Dictionary untuk menyimpan hasil split detail_timbang per baris
    Private detailTimbangDict As New Dictionary(Of Integer, List(Of String))

    Private Sub FrmMonDtlTimbangKelapaPCG_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Modul_RMP.Combo.SetPancang(cmbIDPancang)
        HeaderData()
        AddHandler fgDtl.OwnerDrawCell, AddressOf fgDtl_OwnerDrawCell
    End Sub

    Private Sub HeaderData()
        With fgDtl
            Dim txt As CellRange
            .AllowEditing = False
            .Font = New Font("Century Gothic", 9.0!, FontStyle.Bold)
            .Cols.Count = 34
            .Cols.Fixed = 2
            .Styles.Normal.WordWrap = True
            .AllowResizing = AllowResizingEnum.Both
            .DrawMode = DrawModeEnum.OwnerDraw

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No"
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "No Nota" : .Cols(1).Visible = True
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Pancang" : .Cols(2).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Kapal" : .Cols(3).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Trip" : .Cols(4).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Petani Pelangsir" : .Cols(5).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "ID Penerima Uang" : .Cols(6).AllowMerging = True : .Cols(6).TextAlign = TextAlignEnum.CenterCenter : .Cols(6).Visible = True
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Nama Relasi Penerima Uang" : .Cols(7).AllowMerging = True : .Cols(7).TextAlign = TextAlignEnum.LeftCenter : .Cols(7).Visible = True
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "ID Sub Petani" : .Cols(8).AllowMerging = True : .Cols(8).TextAlign = TextAlignEnum.LeftCenter : .Cols(8).Visible = True
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Sub Petani" : .Cols(9).AllowMerging = True : .Cols(9).TextAlign = TextAlignEnum.LeftCenter : .Cols(9).Visible = True
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "Kapal Pelangsir" : .Cols(10).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "Tanggal Check-in Pelangsir" : .Cols(11).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "Tanggal dan Jam Timbang Kelapa /Jaring" : .Cols(12).AllowMerging = True : .Cols(12).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 13, 0, 13) : txt.Data = "No Page Nota" : .Cols(13).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 14, 0, 14) : txt.Data = "Total Angkat Kelapa" : .Cols(14).AllowMerging = True : .Cols(14).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 15, 0, 15) : txt.Data = "Detail Timbang" : .Cols(15).AllowMerging = True : .Cols(15).TextAlign = TextAlignEnum.LeftCenter : .Cols(15).Visible = True : .Cols(15).Name = "detail_timbang"
            txt = .GetCellRange(0, 16, 0, 16) : txt.Data = "Timbang Kelapa (KG) /Jaring" : .Cols(16).AllowMerging = True : .Cols(16).TextAlign = TextAlignEnum.LeftCenter : .Cols(16).Name = "timbang_kelapa"
            txt = .GetCellRange(0, 17, 0, 17) : txt.Data = "Berat Jaring (KG) /Jaring" : .Cols(17).AllowMerging = True : .Cols(17).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 18, 0, 18) : txt.Data = "Brutto" : .Cols(18).AllowMerging = True : .Cols(18).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 19, 0, 19) : txt.Data = "Netto 2" : .Cols(19).AllowMerging = True : .Cols(19).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 20, 0, 20) : txt.Data = "Harga" : .Cols(20).AllowMerging = True : .Cols(20).TextAlign = TextAlignEnum.CenterCenter : .Cols(20).Format = "#,##0"
            txt = .GetCellRange(0, 21, 0, 21) : txt.Data = "Device Operator" : .Cols(21).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 22, 0, 22) : txt.Data = "Tanggal dan Jam Nota Simpan di Lokal (Internal Device)" : .Cols(22).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 23, 0, 23) : txt.Data = "User Purchaser" : .Cols(23).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 24, 0, 24) : txt.Data = "Tanggal Booking Pelangsir" : .Cols(24).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 25, 0, 25) : txt.Data = "Device Untuk Booking" : .Cols(25).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 26, 0, 26) : txt.Data = "Device Untuk Checkin" : .Cols(26).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 27, 0, 27) : txt.Data = "User Pengawas" : .Cols(27).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 28, 0, 28) : txt.Data = "User Operator" : .Cols(28).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 29, 0, 29) : txt.Data = "Tanggal Kirim Nota" : .Cols(29).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 30, 0, 30) : txt.Data = "Nama Bluetooth Timbang" : .Cols(30).TextAlign = TextAlignEnum.LeftCenter
            txt = .GetCellRange(0, 31, 0, 31) : txt.Data = "Trans Id" : .Cols(31).TextAlign = TextAlignEnum.CenterCenter : .Cols(31).Width = 100 : .Cols(31).Visible = False : .Cols(31).Name = "transid"
            txt = .GetCellRange(0, 32, 0, 32) : txt.Data = "Foto Kapal Pelangsir" : .Cols(32).TextAlign = TextAlignEnum.CenterCenter : .Cols(32).Width = 100 : .Cols(32).Visible = False : .Cols(32).Name = "fotokapal"
            txt = .GetCellRange(0, 33, 0, 33) : txt.Data = "Foto Kelapa Pelangsir" : .Cols(33).TextAlign = TextAlignEnum.CenterCenter : .Cols(33).Width = 100 : .Cols(33).Visible = False : .Cols(33).Name = "fotokelapa"

            .AutoSizeCols()
        End With
    End Sub

    Private Sub panggilData()
        Try


            If String.IsNullOrEmpty(txtTrip.Text) AndAlso cmbIDPancang.SelectedValue Is Nothing Then
                MessageBox.Show("Trip dan ID Pancang tidak boleh kosong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            conn = DB.OpenConnection(StrConnRMPApp)
            Dim cmd As New SqlCommand("SpMonAngkatJaring072025", conn)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Add("@IDPancang", SqlDbType.Int, 10).Value = cmbIDPancang.SelectedValue
            cmd.Parameters.Add("@TripAwal", SqlDbType.Int, 10).Value = txtTrip.Text
            cmd.Parameters.Add("@TripAkhir", SqlDbType.Int, 10).Value = txtTripAkhir.Text

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            fgDtl.Rows.Count = fgDtl.Rows.Fixed
            detailTimbangDict.Clear()

            If Not dr.HasRows Then
                MessageBox.Show("Data tidak ditemukan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            While dr.Read()
                Dim rowIndex As Integer = fgDtl.Rows.Add().Index
                fgDtl(rowIndex, 0) = fgDtl.Rows.Count - fgDtl.Rows.Fixed
                If Not dr.IsDBNull(dr.GetOrdinal("nonota")) Then fgDtl(rowIndex, 1) = dr("nonota").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("pancang")) Then fgDtl(rowIndex, 2) = dr("pancang").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("kapal")) Then fgDtl(rowIndex, 3) = dr("kapal").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("trip")) Then fgDtl(rowIndex, 4) = dr("trip").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("petani_pelangsir")) Then fgDtl(rowIndex, 5) = dr("petani_pelangsir").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("id_penerima_uang")) Then fgDtl(rowIndex, 6) = dr("id_penerima_uang").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("penerima_uang")) Then fgDtl(rowIndex, 7) = dr("penerima_uang").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("id_sub_petani")) Then fgDtl(rowIndex, 8) = dr("id_sub_petani").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("sub_petani")) Then fgDtl(rowIndex, 9) = dr("sub_petani").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("kapal_pelangsir")) Then fgDtl(rowIndex, 10) = dr("kapal_pelangsir").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("tanggal_checkin_pelangsir")) Then fgDtl(rowIndex, 11) = dr("tanggal_checkin_pelangsir").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("tanggal_timbang")) Then fgDtl(rowIndex, 12) = dr("tanggal_timbang").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("NoPageNota")) Then fgDtl(rowIndex, 13) = dr("NoPageNota").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("total_angkat_kelapa")) Then fgDtl(rowIndex, 14) = dr("total_angkat_kelapa").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("detail_timbang")) Then
                    Dim detail As String = dr("detail_timbang").ToString()
                    fgDtl(rowIndex, 15) = detail
                    detailTimbangDict(rowIndex) = detail.Split("@"c).Select(Function(p) p.Trim()).ToList()
                End If
                If Not dr.IsDBNull(dr.GetOrdinal("timbang_kelapa")) Then fgDtl(rowIndex, 16) = dr("timbang_kelapa").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("timbang_jaring")) Then fgDtl(rowIndex, 17) = dr("timbang_jaring").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("Brutto")) Then fgDtl(rowIndex, 18) = dr("Brutto").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("NettoAkhir")) Then fgDtl(rowIndex, 19) = dr("NettoAkhir").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("Harga")) Then fgDtl(rowIndex, 20) = dr("Harga")
                If Not dr.IsDBNull(dr.GetOrdinal("device_operator")) Then fgDtl(rowIndex, 21) = dr("device_operator").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("tanggal_simpan_lokal")) Then fgDtl(rowIndex, 22) = dr("tanggal_simpan_lokal").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("user_purchaser")) Then fgDtl(rowIndex, 23) = dr("user_purchaser").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("tanggal_booking_pelangsir")) Then fgDtl(rowIndex, 24) = dr("tanggal_booking_pelangsir").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("device_booking_pelangsir")) Then fgDtl(rowIndex, 25) = dr("device_booking_pelangsir").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("device_checkin_pelangsir")) Then fgDtl(rowIndex, 26) = dr("device_checkin_pelangsir").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("user_pengawas")) Then fgDtl(rowIndex, 27) = dr("user_pengawas").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("user_operator")) Then fgDtl(rowIndex, 28) = dr("user_operator").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("TanggalKirimNota")) Then fgDtl(rowIndex, 29) = dr("TanggalKirimNota").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("bluetoothName")) Then fgDtl(rowIndex, 30) = dr("bluetoothName").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("transid")) Then fgDtl(rowIndex, 31) = dr("transid").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("foto_kapal_pelangsir")) Then fgDtl(rowIndex, 32) = dr("foto_kapal_pelangsir").ToString()
                If Not dr.IsDBNull(dr.GetOrdinal("foto_kelapa_pelangsir")) Then fgDtl(rowIndex, 33) = dr("foto_kelapa_pelangsir").ToString()

            End While

            fgDtl.AutoSizeCols()
            fgDtl.Rows.DefaultSize = 40
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat mengambil data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        conn.Close()
    End Sub


    Private Sub fgDtl_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs)
        If e.Col = 15 AndAlso e.Row >= fgDtl.Rows.Fixed Then
            ' Gambar background dan border default
            e.DrawCell(DrawCellFlags.Background Or DrawCellFlags.Border)

            ' Ambil nilai detailTimbang, timbangKelapa, dan nonota
            Dim detailTimbang As String = fgDtl(e.Row, 15)?.ToString()
            Dim timbangKelapa As String = fgDtl(e.Row, 16)?.ToString()?.Trim()
            Dim noNota As String = fgDtl(e.Row, 1)?.ToString()?.Trim()

            If String.IsNullOrWhiteSpace(detailTimbang) Then Return

            ' Pecah jadi list berdasarkan '@'
            Dim parts = detailTimbang.Split("@"c).Select(Function(p) p.Trim()).Where(Function(p) Not String.IsNullOrWhiteSpace(p)).ToList()

            ' Membuat objek Graphics dan Rectangle untuk menggambar
            Dim g As Graphics = e.Graphics
            Dim r As Rectangle = e.Bounds
            Dim font As Font = fgDtl.Font

            ' Menyiapkan format untuk menggambar teks
            Dim sf As New StringFormat() With {
            .Alignment = StringAlignment.Near,
            .LineAlignment = StringAlignment.Near,
            .FormatFlags = StringFormatFlags.NoWrap
        }

            Dim x As Single = r.X + 2
            Dim y As Single = r.Y + 2
            Dim maxWidth As Single = r.Width

            ' Menyimpan jumlah kemunculan nilai dalam kelompok nonota yang sama
            Dim colorTracker As New Dictionary(Of String, Integer)()

            ' Gambar setiap bagian dalam baris terpisah
            For Each part In parts
                If String.IsNullOrWhiteSpace(part) Then Continue For

                Dim brush As Brush
                If part = timbangKelapa Then
                    ' Tentukan apakah nilai berada dalam kelompok nonota yang sama
                    If Not colorTracker.ContainsKey(noNota) Then
                        colorTracker(noNota) = 0
                    End If

                    ' Tentukan warna berdasarkan urutan kemunculan dalam kelompok nonota
                    If colorTracker(noNota) Mod 2 = 0 Then
                        brush = Brushes.Red ' Merah untuk kemunculan pertama, ketiga, dll.
                    Else
                        brush = Brushes.Black ' Hitam untuk kemunculan kedua, keempat, dll.
                    End If

                    ' Update kemunculan untuk nilai ini dalam kelompok nonota
                    colorTracker(noNota) += 1
                Else
                    brush = Brushes.Black
                End If

                ' Ukur ukuran teks
                Dim textToDraw = part & " @ "
                Dim size = g.MeasureString(textToDraw, font)

                ' Pindah baris jika melebihi batas kanan
                If x + size.Width > r.Right - 2 Then
                    x = r.X + 2
                    y += size.Height
                End If

                ' Gambar teks
                g.DrawString(textToDraw, font, brush, New PointF(x, y), sf)
                x += size.Width
            Next

            ' Tandai bahwa sudah digambar manual
            e.Handled = True
        ElseIf (e.Col = 1 OrElse e.Col = 10 OrElse e.Col = 5) AndAlso e.Row >= fgDtl.Rows.Fixed Then
            ' Gambar sel default
            e.DrawCell(DrawCellFlags.Background Or DrawCellFlags.Border)

            ' Ambil teks dari sel
            Dim text As String = fgDtl(e.Row, e.Col)?.ToString()

            If Not String.IsNullOrWhiteSpace(text) Then
                ' Tentukan warna berdasarkan kolom
                Dim brush As Brush = Brushes.Black
                Select Case e.Col
                    Case 1 : brush = Brushes.DarkBlue
                    Case 10 : brush = Brushes.Green
                    Case 5 : brush = Brushes.OrangeRed
                End Select

                ' Gambar teks dengan warna
                Dim g As Graphics = e.Graphics
                Dim r As Rectangle = e.Bounds
                Dim font As Font = fgDtl.Font
                Dim sf As New StringFormat() With {
            .Alignment = StringAlignment.Near,
            .LineAlignment = StringAlignment.Center,
            .FormatFlags = StringFormatFlags.NoWrap
        }

                g.DrawString(text, font, brush, r, sf)
                e.Handled = True
            End If
        End If
    End Sub


    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        panggilData()
    End Sub


    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If SaveFileDialog.ShowDialog() <> DialogResult.OK Then Return

        Dim filename As String = SaveFileDialog.FileName

        ' Inisialisasi Excel
        Dim xlApp As New Excel.Application
        Dim wb As Excel.Workbook = xlApp.Workbooks.Add()
        Dim ws As Excel.Worksheet = CType(wb.Sheets(1), Excel.Worksheet)

        ' Tulis Header
        For c As Integer = 0 To fgDtl.Cols.Count - 1
            ws.Cells(1, c + 1).Value = fgDtl(0, c)
        Next

        ' Mulai dari baris kedua Excel (karena baris pertama untuk header)
        Dim rowExcel As Integer = 2

        For rowFlex As Integer = fgDtl.Rows.Fixed To fgDtl.Rows.Count - 1
            For colFlex As Integer = 0 To fgDtl.Cols.Count - 1
                Dim value = fgDtl(rowFlex, colFlex)?.ToString()
                Dim cell As Excel.Range = ws.Cells(rowExcel, colFlex + 1)
                cell.Value = value

                ' Cek apakah ini kolom "Detail Timbang" dan perlu diwarnai
                If fgDtl.Cols(colFlex).Name = "detail_timbang" Then
                    Dim timbangKelapa As String = fgDtl(rowFlex, "timbang_kelapa")?.ToString()?.Trim()

                    If Not String.IsNullOrEmpty(timbangKelapa) AndAlso Not String.IsNullOrEmpty(value) Then
                        ' Temukan posisi timbangKelapa dalam detailTimbang
                        Dim searchParts = value.Split("@"c).ToList()
                        Dim charIndex As Integer = 1
                        For Each part In searchParts
                            If part = timbangKelapa Then
                                ' Warna bagian match dengan merah
                                cell.Characters(charIndex, timbangKelapa.Length).Font.Color = RGB(255, 0, 0)
                                Exit For ' Hanya pertama yang match
                            End If
                            charIndex += part.Length + 1 ' +1 untuk @
                        Next
                    End If
                End If
            Next
            rowExcel += 1
        Next

        ws.Columns.AutoFit()
        wb.SaveAs(filename & ".xlsx")
        wb.Close()
        xlApp.Quit()

        Marshal.ReleaseComObject(ws)
        Marshal.ReleaseComObject(wb)
        Marshal.ReleaseComObject(xlApp)

        MessageBox.Show("Export selesai ke Excel!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' Deklarasikan di tingkat form atau kelas
    Private imageCache As New Dictionary(Of String, Image)()

    Private Sub fgDtl_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles fgDtl.MouseDoubleClick
        Dim hit As C1.Win.C1FlexGrid.HitTestInfo = fgDtl.HitTest(e.X, e.Y)

        If hit.Row >= fgDtl.Rows.Fixed Then
            Dim imageKey As String = ""
            Dim url As String = ""
            Dim filename As String = ""

            Select Case hit.Column
                Case 1 ' Kolom 1: Nota (transid)
                    filename = TryCast(fgDtl(hit.Row, "transid"), String)
                    If String.IsNullOrEmpty(filename) Then
                        MessageBox.Show("TransID tidak ditemukan.")
                        Exit Sub
                    End If
                    url = $"https://apip2.myrsup.co.id:8083/api/file/uploadNew?subfolder=notapancangapi/ImagesNotaPancang&filename={filename}.jpg&flag=notapancang"
                    imageKey = $"nota_{filename}"

                Case 10 ' Kolom 5: Kapal Pelangsir
                    filename = TryCast(fgDtl(hit.Row, "fotokapal"), String)
                    If String.IsNullOrEmpty(filename) Then
                        MessageBox.Show("Foto kapal pelangsir tidak tersedia.")
                        Exit Sub
                    End If
                    url = $"https://apip2.myrsup.co.id:8083/api/file/uploadNew?subfolder=notapancangapi/ImagesKapalPelangsirCheckin&filename={filename}&flag=notapancang"
                    imageKey = $"kapal_{filename}"

                Case 5 ' Kolom 6: Supplier Pelangsir
                    filename = TryCast(fgDtl(hit.Row, "fotokelapa"), String)
                    If String.IsNullOrEmpty(filename) Then
                        MessageBox.Show("Foto supplier pelangsir tidak tersedia.")
                        Exit Sub
                    End If
                    url = $"https://apip2.myrsup.co.id:8083/api/file/uploadNew?subfolder=notapancangapi/ImagesSupplierPelangsir&filename={filename}&flag=notapancang"
                    imageKey = $"supplier_{filename}"

                Case Else
                    ' Jika kolom lain yang diklik, tidak melakukan apa-apa
                    Exit Sub
            End Select

            ' Ambil atau unduh gambar
            Dim image As Image = Nothing

            If imageCache.ContainsKey(imageKey) Then
                image = imageCache(imageKey)
            Else
                Try
                    Using client As New Net.WebClient()
                        client.Headers.Add("User-Agent", "VB App")
                        Using stream As IO.Stream = client.OpenRead(url)
                            image = Image.FromStream(stream)
                            imageCache(imageKey) = image
                        End Using
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Gagal memuat gambar. Error: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End Try
            End If

            If image IsNot Nothing Then

                Dim previewForm As New FrmFotoView

                previewForm.TampilkanImage(image)
                previewForm.ShowDialog()

                previewForm.Dispose()

            Else
                MessageBox.Show("Gambar tidak tersedia.")
            End If
        End If
    End Sub


End Class
