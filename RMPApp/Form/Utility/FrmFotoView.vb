
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms

Public Class FrmFotoView

    Private pnlView As New Panel
    Private picFoto As New PictureBox
    Private toolBar As New ToolStrip
    Private statusBar As New StatusStrip

    Private lblNama As New ToolStripStatusLabel
    Private lblResolusi As New ToolStripStatusLabel
    Private lblUkuran As New ToolStripStatusLabel
    Private lblZoom As New ToolStripStatusLabel

    Private FotoAsli As Image
    Private PathFoto As String = ""

    Private ZoomLevel As Double = 1
    Private IsFit As Boolean = True

    Private Dragging As Boolean
    Private DragStart As Point
    Private ScrollStart As Point

    Private Sub FotoView_Load(
        sender As Object, e As EventArgs
    ) Handles MyBase.Load

        BuatUI()

        Me.KeyPreview = True
        Me.WindowState = FormWindowState.Maximized
        Me.MinimumSize = New Size(600, 400)

    End Sub

    ' =====================================
    ' MEMBUAT UI
    ' =====================================

    Private Sub BuatUI()

        Me.Text = "Foto Viewer"
        Me.BackColor = Color.FromArgb(40, 40, 40)
        Me.StartPosition = FormStartPosition.CenterScreen

        ' TOOLBAR
        With toolBar
            .Dock = DockStyle.Top
            .GripStyle = ToolStripGripStyle.Hidden
            .BackColor = Color.FromArgb(245, 245, 245)
            .Padding = New Padding(5, 4, 5, 4)
            .ImageScalingSize = New Size(20, 20)
        End With

        TambahTombol("Buka", AddressOf BukaFoto)
        TambahPemisah()

        TambahTombol("Zoom +", AddressOf ZoomIn)
        TambahTombol("Zoom -", AddressOf ZoomOut)
        TambahPemisah()

        TambahTombol("Fit", AddressOf FitFoto)
        TambahTombol("100%", AddressOf ActualSize)
        TambahPemisah()

        TambahTombol("Putar Kiri", AddressOf PutarKiri)
        TambahTombol("Putar Kanan", AddressOf PutarKanan)

        ' AREA FOTO
        With pnlView
            .Dock = DockStyle.Fill
            .AutoScroll = True
            .BackColor = Color.FromArgb(40, 40, 40)
            .TabStop = True
        End With

        With picFoto
            .SizeMode = PictureBoxSizeMode.StretchImage
            .BackColor = Color.Transparent
            .Cursor = Cursors.Default
            .TabStop = True
        End With

        pnlView.Controls.Add(picFoto)

        ' STATUS BAR
        With statusBar
            .Dock = DockStyle.Bottom
            .BackColor = Color.FromArgb(245, 245, 245)
            .SizingGrip = False
        End With

        lblNama.Text = "Tidak ada foto"
        lblNama.Spring = True
        lblNama.TextAlign = ContentAlignment.MiddleLeft

        lblResolusi.Text = ""
        lblUkuran.Text = ""
        lblZoom.Text = "100%"

        statusBar.Items.AddRange(New ToolStripItem() {
            lblNama,
            New ToolStripStatusLabel("|"),
            lblResolusi,
            New ToolStripStatusLabel("|"),
            lblUkuran,
            New ToolStripStatusLabel("|"),
            lblZoom
        })

        Me.Controls.Add(pnlView)
        Me.Controls.Add(statusBar)
        Me.Controls.Add(toolBar)

        ' EVENT
        AddHandler picFoto.MouseDown, AddressOf Foto_MouseDown
        AddHandler picFoto.MouseMove, AddressOf Foto_MouseMove
        AddHandler picFoto.MouseUp, AddressOf Foto_MouseUp

        AddHandler picFoto.MouseWheel, AddressOf Foto_MouseWheel
        AddHandler pnlView.MouseWheel, AddressOf Foto_MouseWheel

        AddHandler pnlView.Resize, AddressOf Panel_Resize

        AddHandler picFoto.MouseEnter,
            Sub()
                picFoto.Focus()
            End Sub

    End Sub

    Private Sub TambahTombol(
        teks As String,
        aksi As EventHandler
    )

        Dim btn As New ToolStripButton With {
            .Text = teks,
            .ToolTipText = teks,
            .DisplayStyle = ToolStripItemDisplayStyle.Text
        }

        AddHandler btn.Click, aksi

        toolBar.Items.Add(btn)

    End Sub

    Private Sub TambahPemisah()

        toolBar.Items.Add(New ToolStripSeparator())

    End Sub

    ' =====================================
    ' BUKA FOTO
    ' =====================================

    Private Sub BukaFoto(sender As Object, e As EventArgs)

        Using dlg As New OpenFileDialog

            dlg.Title = "Pilih Foto"

            dlg.Filter =
                "File Foto|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tif;*.tiff|" &
                "Semua File|*.*"

            If dlg.ShowDialog() = DialogResult.OK Then
                TampilkanFoto(dlg.FileName)
            End If

        End Using

    End Sub

    Public Sub TampilkanFoto(path As String)

        If Not File.Exists(path) Then

            MessageBox.Show(
                "File foto tidak ditemukan.",
                "Informasi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            Return

        End If

        Try

            Dim imgBaru As Image

            Using img As Image = Image.FromFile(path)
                imgBaru = New Bitmap(img)
            End Using

            If FotoAsli IsNot Nothing Then
                FotoAsli.Dispose()
            End If

            FotoAsli = imgBaru
            PathFoto = path

            picFoto.Image = FotoAsli

            IsFit = True
            ZoomLevel = 1

            Me.Text = "Foto Viewer - " & IO.Path.GetFileName(path)

            lblNama.Text = IO.Path.GetFileName(path)

            lblResolusi.Text =
                FotoAsli.Width & " x " & FotoAsli.Height

            Dim info As New FileInfo(path)
            lblUkuran.Text = FormatUkuran(info.Length)

            FitFoto()

        Catch ex As Exception

            MessageBox.Show(
                "Gagal membuka foto: " & ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        End Try

    End Sub

    Private Function FormatUkuran(bytes As Long) As String

        If bytes >= 1024 * 1024 Then
            Return (bytes / 1024 / 1024).ToString("0.00") & " MB"
        End If

        If bytes >= 1024 Then
            Return (bytes / 1024).ToString("0.00") & " KB"
        End If

        Return bytes.ToString() & " Byte"

    End Function

    ' =====================================
    ' ZOOM
    ' =====================================

    Private Sub ZoomIn(sender As Object, e As EventArgs)

        ZoomFoto(1.2)

    End Sub

    Private Sub ZoomOut(sender As Object, e As EventArgs)

        ZoomFoto(1 / 1.2)

    End Sub

    Private Sub ZoomFoto(nilai As Double)

        If FotoAsli Is Nothing Then Return

        IsFit = False

        ZoomLevel *= nilai
        ZoomLevel = Math.Max(0.05, Math.Min(8, ZoomLevel))

        TampilkanUkuranFoto()

    End Sub

    Private Sub FitFoto(sender As Object, e As EventArgs)

        FitFoto()

    End Sub

    Private Sub FitFoto()

        If FotoAsli Is Nothing Then Return

        IsFit = True

        TampilkanUkuranFoto()

    End Sub

    Private Sub ActualSize(sender As Object, e As EventArgs)

        If FotoAsli Is Nothing Then Return

        IsFit = False
        ZoomLevel = 1

        TampilkanUkuranFoto()

    End Sub

    Private Sub TampilkanUkuranFoto()

        If FotoAsli Is Nothing Then Return

        If IsFit Then

            Dim skalaX As Double =
                pnlView.ClientSize.Width / FotoAsli.Width

            Dim skalaY As Double =
                pnlView.ClientSize.Height / FotoAsli.Height

            ZoomLevel = Math.Min(skalaX, skalaY)

        End If

        Dim lebar As Integer =
            Math.Max(1, CInt(FotoAsli.Width * ZoomLevel))

        Dim tinggi As Integer =
            Math.Max(1, CInt(FotoAsli.Height * ZoomLevel))

        picFoto.Size = New Size(lebar, tinggi)

        Dim x As Integer = 0
        Dim y As Integer = 0

        If lebar < pnlView.ClientSize.Width Then
            x = (pnlView.ClientSize.Width - lebar) \ 2
        End If

        If tinggi < pnlView.ClientSize.Height Then
            y = (pnlView.ClientSize.Height - tinggi) \ 2
        End If

        picFoto.Location = New Point(x, y)

        pnlView.AutoScrollMinSize =
            New Size(x + lebar, y + tinggi)

        pnlView.AutoScrollPosition = New Point(0, 0)

        lblZoom.Text =
            CInt(ZoomLevel * 100).ToString() & "%"

    End Sub

    Private Sub Panel_Resize(sender As Object, e As EventArgs)

        If IsFit AndAlso FotoAsli IsNot Nothing Then
            TampilkanUkuranFoto()
        End If

    End Sub

    ' =====================================
    ' ROTASI
    ' =====================================

    Private Sub PutarKiri(sender As Object, e As EventArgs)

        PutarFoto(RotateFlipType.Rotate270FlipNone)

    End Sub

    Private Sub PutarKanan(sender As Object, e As EventArgs)

        PutarFoto(RotateFlipType.Rotate90FlipNone)

    End Sub

    Private Sub PutarFoto(arah As RotateFlipType)

        If FotoAsli Is Nothing Then Return

        FotoAsli.RotateFlip(arah)

        TampilkanUkuranFoto()

        lblResolusi.Text =
            FotoAsli.Width & " x " & FotoAsli.Height

    End Sub

    ' =====================================
    ' GESER FOTO
    ' =====================================

    Private Sub Foto_MouseDown(
        sender As Object, e As MouseEventArgs
    )

        If e.Button <> MouseButtons.Left Then Return

        If ZoomLevel <= 1 AndAlso IsFit Then Return

        Dragging = True
        DragStart = e.Location

        ScrollStart = New Point(
            -pnlView.AutoScrollPosition.X,
            -pnlView.AutoScrollPosition.Y
        )

        picFoto.Cursor = Cursors.Hand

    End Sub

    Private Sub Foto_MouseMove(
        sender As Object, e As MouseEventArgs
    )

        If Not Dragging Then Return

        Dim x As Integer =
            ScrollStart.X - (e.X - DragStart.X)

        Dim y As Integer =
            ScrollStart.Y - (e.Y - DragStart.Y)

        pnlView.AutoScrollPosition = New Point(x, y)

    End Sub

    Private Sub Foto_MouseUp(
        sender As Object, e As MouseEventArgs
    )

        Dragging = False
        picFoto.Cursor = Cursors.Default

    End Sub

    ' =====================================
    ' SCROLL MOUSE
    ' =====================================

    Private Sub Foto_MouseWheel(
        sender As Object, e As MouseEventArgs
    )

        If FotoAsli Is Nothing Then Return

        If e.Delta > 0 Then
            ZoomFoto(1.15)
        Else
            ZoomFoto(1 / 1.15)
        End If

    End Sub

    ' =====================================
    ' KEYBOARD
    ' =====================================

    Private Sub FotoView_KeyDown(
        sender As Object, e As KeyEventArgs
    ) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Add, Keys.Oemplus
                ZoomIn(Nothing, Nothing)

            Case Keys.Subtract, Keys.OemMinus
                ZoomOut(Nothing, Nothing)

            Case Keys.D0, Keys.NumPad0
                ActualSize(Nothing, Nothing)

            Case Keys.F
                FitFoto()

            Case Keys.R
                PutarKanan(Nothing, Nothing)

            Case Keys.L
                PutarKiri(Nothing, Nothing)

            Case Keys.O
                BukaFoto(Nothing, Nothing)

            Case Keys.Escape
                Me.Close()

        End Select

    End Sub

    ' =====================================
    ' TUTUP FORM
    ' =====================================

    Private Sub FotoView_FormClosed(
        sender As Object, e As FormClosedEventArgs
    ) Handles MyBase.FormClosed

        picFoto.Image = Nothing

        If FotoAsli IsNot Nothing Then
            FotoAsli.Dispose()
            FotoAsli = Nothing
        End If

    End Sub

    Public Async Function TampilkanFotoAsync(
    path As String
) As Task(Of Boolean)

        Try

            Dim imgBaru As Image =
                Await Task.Run(Function()

                                   Dim bytes As Byte() =
                                       IO.File.ReadAllBytes(path)

                                   Using ms As New MemoryStream(bytes)
                                       Using img As Image = Image.FromStream(ms)
                                           Return New Bitmap(img)
                                       End Using
                                   End Using

                               End Function)

            If FotoAsli IsNot Nothing Then
                FotoAsli.Dispose()
            End If

            FotoAsli = imgBaru
            PathFoto = path

            picFoto.Image = FotoAsli

            IsFit = True
            ZoomLevel = 1

            Me.Text = "Foto Viewer - " & IO.Path.GetFileName(path)

            lblNama.Text = IO.Path.GetFileName(path)

            lblResolusi.Text =
                FotoAsli.Width & " x " & FotoAsli.Height

            Dim info As New FileInfo(path)
            lblUkuran.Text = FormatUkuran(info.Length)

            FitFoto()

            Return True

        Catch ex As Exception

            MessageBox.Show(
                "Gagal membuka foto." & vbCrLf & ex.Message,
                "Informasi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation
            )

            Return False

        End Try

    End Function

    Public Sub TampilkanImage(img As Image)

        If img Is Nothing Then Return

        If FotoAsli IsNot Nothing Then
            FotoAsli.Dispose()
        End If

        FotoAsli = New Bitmap(img)
        picFoto.Image = FotoAsli

        IsFit = True
        ZoomLevel = 1

        Me.Text = "Foto Viewer"
        lblNama.Text = "Preview Foto"
        lblResolusi.Text = FotoAsli.Width & " x " & FotoAsli.Height
        lblUkuran.Text = ""

        FitFoto()

    End Sub

End Class
