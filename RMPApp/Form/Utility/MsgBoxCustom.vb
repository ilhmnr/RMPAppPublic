Public Class MsgBoxCustom

    Public Enum ButtonType
        OK
        OKCancel
        YesNo
        YesNoCancel
        RetryCancel
    End Enum

    Public Enum IconType
        None
        Information
        Warning
        [Error]
        Question
        Success
    End Enum

    Private isDragging As Boolean = False
    Private mouseDownPos As Point

    Private Sub New(message As String, buttons As ButtonType, icon As IconType, title As String)
        InitializeComponent()

        ' lblMessage tidak lagi Dock=Fill, karena ukurannya akan dihitung manual
        ' sesuai panjang teks. Panel3 dibuat AutoScroll supaya pesan yang sangat
        ' panjang tetap bisa digulir alih-alih memotong teks atau membuat form raksasa.
        lblMessage.Dock = DockStyle.None
        Panel3.AutoScroll = True

        lblTitle.Text = If(String.IsNullOrEmpty(title), GetDefaultTitle(icon), title)
        lblMessage.Text = message
        SetIcon(icon)

        AdjustMessageSize()
        BuildButtons(buttons)

        ' Supaya form bisa digeser dengan drag di area judul (karena tidak ada title bar bawaan)
        AddHandler Panel5.MouseDown, AddressOf Header_MouseDown
        AddHandler Panel5.MouseMove, AddressOf Header_MouseMove
        AddHandler Panel5.MouseUp, AddressOf Header_MouseUp
        AddHandler lblTitle.MouseDown, AddressOf Header_MouseDown
        AddHandler lblTitle.MouseMove, AddressOf Header_MouseMove
        AddHandler lblTitle.MouseUp, AddressOf Header_MouseUp
    End Sub

    ''' <summary>
    ''' Panggil seperti MessageBox.Show bawaan. title bersifat opsional -- kalau tidak
    ''' diisi, judul otomatis mengikuti jenis icon (mis. IconType.Question -> "Konfirmasi").
    ''' Contoh:
    ''' CustomMessageBox.Show("Yakin ingin menghapus data ini?", CustomMessageBox.ButtonType.YesNo, CustomMessageBox.IconType.Question)
    ''' CustomMessageBox.Show("Stok tinggal 2 buah.", CustomMessageBox.ButtonType.OK, CustomMessageBox.IconType.Warning, "Stok Menipis")
    ''' </summary>
    Public Shared Function Show(message As String,
                                 Optional buttons As ButtonType = ButtonType.OK,
                                 Optional icon As IconType = IconType.Information,
                                 Optional title As String = Nothing) As DialogResult
        Using box As New MsgBoxCustom(message, buttons, icon, title)
            Return box.ShowDialog()
        End Using
    End Function

    ''' <summary>Judul bawaan kalau parameter title tidak diisi, mengikuti jenis ikon.</summary>
    Private Function GetDefaultTitle(icon As IconType) As String
        Select Case icon
            Case IconType.Information
                Return "Informasi"
            Case IconType.Warning
                Return "Peringatan"
            Case IconType.Error
                Return "Terjadi Kesalahan"
            Case IconType.Question
                Return "Konfirmasi"
            Case IconType.Success
                Return "Berhasil"
            Case Else
                Return "Pesan"
        End Select
    End Function

    ''' <summary>
    ''' Menyiapkan gambar ikon sesuai IconType. Coba ambil dulu dari file PNG yang
    ''' di-embed (folder Resource_v2) berdasarkan nama filenya. Kalau tidak ketemu
    ''' (misalnya Build Action belum diubah ke Embedded Resource), otomatis pakai
    ''' ikon bulat gambar GDI+ sebagai cadangan supaya tidak pernah kosong.
    ''' Kalau icon = None, picIcon disembunyikan dan lblTitle melebar mengisi ruang kosongnya.
    ''' </summary>
    Private Sub SetIcon(icon As IconType)
        If icon = IconType.None Then
            picIcon.Visible = False
            lblTitle.Location = New Point(picIcon.Location.X, lblTitle.Location.Y)
            lblTitle.Width += picIcon.Width
            Return
        End If

        Dim namaFile As String = GetNamaFileIkon(icon)
        Dim gambar As Image = If(namaFile <> "", MuatIkonDariResource(namaFile), Nothing)

        If gambar IsNot Nothing Then
            picIcon.Image = gambar
        Else
            picIcon.Image = BuatIkonBulat(GetWarnaIkon(icon), GetSimbolIkon(icon), picIcon.Width)
        End If
    End Sub

    ''' <summary>Nama file PNG di folder Resource_v2 untuk tiap IconType.</summary>
    Private Function GetNamaFileIkon(icon As IconType) As String
        Select Case icon
            Case IconType.Information : Return "msg_information.png"
            Case IconType.Warning : Return "msg_warning.png"
            Case IconType.Error : Return "msg_error.png"
            Case IconType.Question : Return "msg_question.png"
            Case IconType.Success : Return "msg_succes.png"
            Case Else : Return ""
        End Select
    End Function

    ''' <summary>
    ''' Mencari resource yang di-embed berdasarkan nama filenya saja (tidak perlu tahu
    ''' namespace project), lalu memuatnya sebagai Image. Mengembalikan Nothing kalau
    ''' tidak ditemukan (misalnya Build Action file itu belum diubah ke Embedded Resource).
    ''' </summary>
    Private Function MuatIkonDariResource(namaFile As String) As Image
        Dim asm As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim namaResource As String = Nothing

        For Each n As String In asm.GetManifestResourceNames()
            If n.EndsWith(namaFile, StringComparison.OrdinalIgnoreCase) Then
                namaResource = n
                Exit For
            End If
        Next

        If namaResource Is Nothing Then Return Nothing

        Using stream As System.IO.Stream = asm.GetManifestResourceStream(namaResource)
            Using imgSementara As Image = Image.FromStream(stream)
                Return New Bitmap(imgSementara) ' salin penuh ke memori, aman walau stream sudah ditutup
            End Using
        End Using
    End Function

    Private Function GetWarnaIkon(icon As IconType) As Color
        Select Case icon
            Case IconType.Information : Return Color.FromArgb(41, 128, 185)
            Case IconType.Warning : Return Color.FromArgb(230, 160, 20)
            Case IconType.Error : Return Color.FromArgb(192, 57, 43)
            Case IconType.Question : Return Color.FromArgb(142, 68, 173)
            Case IconType.Success : Return Color.FromArgb(39, 174, 96)
            Case Else : Return Color.Gray
        End Select
    End Function

    Private Function GetSimbolIkon(icon As IconType) As String
        Select Case icon
            Case IconType.Information : Return "i"
            Case IconType.Warning : Return "!"
            Case IconType.Error : Return "!"
            Case IconType.Question : Return "?"
            Case IconType.Success : Return Convert.ToChar(&H2713).ToString()
            Case Else : Return ""
        End Select
    End Function

    ''' <summary>Menggambar lingkaran berwarna dengan simbol di tengahnya sebagai Bitmap.</summary>
    Private Function BuatIkonBulat(warna As Color, simbol As String, ukuran As Integer) As Image
        Dim bmp As New Bitmap(ukuran, ukuran)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            g.Clear(Color.Transparent)
            Using brush As New SolidBrush(warna)
                g.FillEllipse(brush, 0, 0, ukuran - 1, ukuran - 1)
            End Using
            If simbol <> "" Then
                Using f As New Font("Segoe UI", ukuran * 0.45F, FontStyle.Bold)
                    Dim sf As New StringFormat With {
                        .Alignment = StringAlignment.Center,
                        .LineAlignment = StringAlignment.Center
                    }
                    g.DrawString(simbol, f, Brushes.White, New RectangleF(0, 0, ukuran, ukuran), sf)
                End Using
            End If
        End Using
        Return bmp
    End Function

    ' Button1 (tombol X) sudah punya DialogResult = Cancel di Designer,
    ' jadi form otomatis tertutup saat diklik tanpa perlu handler tambahan.

    ''' <summary>
    ''' Menghitung tinggi lblMessage berdasarkan panjang teks & lebar yang tersedia,
    ''' lalu menyesuaikan tinggi form. Dibatasi tinggi maksimum (80% tinggi layar);
    ''' jika teks lebih panjang dari itu, Panel3 akan menampilkan scrollbar (AutoScroll).
    ''' </summary>
    Private Sub AdjustMessageSize()
        ' Lebar area yang tersedia untuk teks = lebar Panel3 dikurangi padding kiri-kanannya
        Dim availableWidth As Integer = Panel3.ClientSize.Width - Panel3.Padding.Horizontal
        If availableWidth < 100 Then availableWidth = 350 ' pengaman kalau layout belum siap

        ' Ukur tinggi teks memakai TextRenderer (mesin render yang sama dipakai Label)
        Dim measured As Size = TextRenderer.MeasureText(
            lblMessage.Text,
            lblMessage.Font,
            New Size(availableWidth, Integer.MaxValue),
            TextFormatFlags.WordBreak Or TextFormatFlags.TextBoxControl)

        Dim textHeight As Integer = measured.Height + 4 ' sedikit buffer

        lblMessage.Location = New Point(Panel3.Padding.Left, Panel3.Padding.Top)
        lblMessage.Size = New Size(availableWidth, textHeight)

        ' Tinggi elemen yang selalu tetap (header + footer + padding Panel3 + border form)
        Dim chromeHeight As Integer = Panel1.Height + Panel2.Height + Panel3.Padding.Vertical + Me.Padding.Vertical
        Dim desiredHeight As Integer = chromeHeight + textHeight

        Const minFormHeight As Integer = 238
        Dim maxFormHeight As Integer = CInt(Screen.PrimaryScreen.WorkingArea.Height * 0.75)

        If desiredHeight < minFormHeight Then desiredHeight = minFormHeight
        If desiredHeight > maxFormHeight Then desiredHeight = maxFormHeight

        Me.ClientSize = New Size(Me.ClientSize.Width, desiredHeight)
    End Sub

    Private Sub BuildButtons(buttons As ButtonType)
        Dim daftar As New List(Of (Teks As String, Hasil As DialogResult))

        Select Case buttons
            Case ButtonType.OK
                daftar.Add(("OK", DialogResult.OK))
            Case ButtonType.OKCancel
                daftar.Add(("Batal", DialogResult.Cancel))
                daftar.Add(("OK", DialogResult.OK))
            Case ButtonType.YesNo
                daftar.Add(("Tidak", DialogResult.No))
                daftar.Add(("Ya", DialogResult.Yes))
            Case ButtonType.YesNoCancel
                daftar.Add(("Batal", DialogResult.Cancel))
                daftar.Add(("Tidak", DialogResult.No))
                daftar.Add(("Ya", DialogResult.Yes))
            Case ButtonType.RetryCancel
                daftar.Add(("Batal", DialogResult.Cancel))
                daftar.Add(("Coba Lagi", DialogResult.Retry))
        End Select

        Dim xPos As Integer = Panel2.Width - 10
        For Each item In daftar
            Dim btn As New Button With {
                .Text = item.Teks,
                .Size = New Size(90, 32),
                .FlatStyle = FlatStyle.Flat,
                .Font = New Font("Segoe UI", 9.5F),
                .Cursor = Cursors.Hand
            }
            btn.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200)

            If item.Hasil = DialogResult.OK OrElse item.Hasil = DialogResult.Yes Then
                btn.BackColor = Color.FromArgb(41, 128, 185)
                btn.ForeColor = Color.White
                btn.FlatAppearance.BorderSize = 0
            Else
                btn.BackColor = Color.White
                btn.ForeColor = Color.FromArgb(80, 80, 80)
                btn.FlatAppearance.BorderSize = 1
            End If

            xPos -= btn.Width + 8
            btn.Location = New Point(xPos, (Panel2.Height - btn.Height) \ 2 + 1)
            btn.Anchor = AnchorStyles.Top Or AnchorStyles.Right

            Dim hasilTombol = item.Hasil
            AddHandler btn.Click, Sub()
                                      Me.DialogResult = hasilTombol
                                      Me.Close()
                                  End Sub
            Panel2.Controls.Add(btn)
        Next
    End Sub

    Private Sub Header_MouseDown(sender As Object, e As MouseEventArgs)
        isDragging = True
        mouseDownPos = e.Location
    End Sub

    Private Sub Header_MouseMove(sender As Object, e As MouseEventArgs)
        If isDragging Then
            Me.Location = New Point(Me.Location.X + e.X - mouseDownPos.X, Me.Location.Y + e.Y - mouseDownPos.Y)
        End If
    End Sub

    Private Sub Header_MouseUp(sender As Object, e As MouseEventArgs)
        isDragging = False
    End Sub

End Class