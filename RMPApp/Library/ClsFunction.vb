Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Runtime.InteropServices
Imports System.Text
Imports C1.Win.C1FlexGrid
Imports DocumentFormat.OpenXml.Spreadsheet

Public Class ClsFunction

#Region "A - Version & Update Check"

    Public Function Appversion(ByVal OldVer As Double) As Boolean
        Dim NewVer As Double
        Dim dt As DataTable = New DataTable()

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "Select max(Version) as Version from RMPApp..AppVersion")
        NewVer = dt.Rows(0).Item("Version")

        If OldVer < NewVer Then
            MsgBox("New Version Available !" & vbNewLine & "Please Update Version Via One Login", MsgBoxStyle.Information, AT)
            Return False
        End If
        Return True
    End Function

#End Region

#Region "B - Text & Condition Helpers"

    Function SetCondition(OldCond As String, NewCond As String) As String
        SetCondition = IIf((OldCond <> ""), OldCond & " And " & NewCond, NewCond)
    End Function

    Public Function ChangeDay(ByVal tgl As String)
        Return Replace(Replace(Replace(Replace(Replace(Replace(Replace(tgl, "Sunday", "Minggu"), "Monday", "Senin"), "Tuesday", "Selasa"), "Wednesday", "Rabu"), "Thursday", "Kamis"), "Friday", "Jumat"), "Saturday", "Sabtu")
    End Function

#End Region

#Region "C - Map & Connectivity"

    Public Function OpenMap(ByVal Latitude As String, ByVal Longitude As String, Browser As WebBrowser)
        Dim QuerryAddress As New System.Text.StringBuilder
        QuerryAddress.Append("https://www.google.com/maps?q=" & Latitude & "," & Longitude)
        Browser.Navigate(QuerryAddress.ToString)
        Return True
    End Function

    Public Function CheckForInternetConnection() As Boolean
        Try
            Using client = New WebClient()
                Using stream = client.OpenRead("http://www.google.com")
                    Return True
                End Using
            End Using
        Catch
            Return False
        End Try
    End Function

#End Region

#Region "D - Encryption"

    Public Function EncryptText(strText As String, ByVal Kunci As String)
        Dim i As Integer, c As Integer
        Dim strBuff As String = ""

#If Not CASE_SENSITIVE_PASSWORD Then
        Kunci = UCase$(Kunci)

#End If

        If Len(Kunci) Then
            For i = 1 To Len(strText)
                c = Asc(Mid$(strText, i, 1))
                c = c + Asc(Mid$(Kunci, (i Mod Len(Kunci)) + 1, 1))
                strBuff = strBuff & Chr(c And &HFF)

            Next i
        Else
            strBuff = strText
        End If
        EncryptText = strBuff
    End Function

    Public Function DecryptText(strText As String, ByVal Kunci As String)
        Dim i As Integer, c As Integer, strBuff As String = ""

#If Not CASE_SENSITIVE_PASSWORD Then
        Kunci = UCase$(Kunci)
#End If

        If Len(Kunci) Then
            For i = 1 To Len(strText)
                c = Asc(Mid$(strText, i, 1))
                c = c - Asc(Mid$(Kunci, (i Mod Len(Kunci)) + 1, 1))
                strBuff = strBuff & Chr(c And &HFF)
            Next i
        Else
            strBuff = strText
        End If
        DecryptText = strBuff
    End Function

#End Region

#Region "E - Custom Dialogs & UI Helpers"

    Public Class PlaceholderHelper
        <DllImport("user32.dll", CharSet:=CharSet.Auto)>
        Private Shared Function SendMessage(hWnd As IntPtr, msg As Integer, wParam As Integer, lParam As String) As Integer
        End Function

        Private Const EM_SETCUEBANNER As Integer = &H1501

        Public Shared Sub SetPlaceholder(textbox As TextBox, placeholder As String)
            SendMessage(textbox.Handle, EM_SETCUEBANNER, 0, placeholder)
        End Sub
    End Class

#End Region

#Region "F - Number Formatting & Rounding"

    Function Bulatkan(nValue As Double, nDigits As Integer) As Double
        Bulatkan = Int(nValue * (10 ^ nDigits) + 0.5) / (10 ^ nDigits)
    End Function

    Function Bulatkankbb(nValue As Double, nDigits As Integer) As Double
        Bulatkankbb = Int(nValue * (10 ^ nDigits) + 0.5) / (10 ^ nDigits)
    End Function

    Function SetSeparator(ByVal value_ As Double) As String
        SetSeparator = FormatNumber(value_, 0)
        Return SetSeparator
    End Function

    Function ClearSeparator(ByVal value_ As String) As String
        ClearSeparator = Replace(value_, ".", "")
        Return ClearSeparator
    End Function

    Shared Function FormatNum(NumValue As String, Precision As Integer) As String
        Dim StrValue As String, PrecisionLimit As Integer
        FormatNum = ""
        If IsNothing(NumValue) Then
            FormatNum = ""
            Exit Function
        Else
            If Not IsNumeric(NumValue) Then
                Call MsgBox("Value Is Not valid !", vbExclamation, AT)
                FormatNum = 0
                Exit Function
            End If
        End If
        StrValue = CStr(NumValue)
        PrecisionLimit = Len(StrValue) - InStr(1, StrValue, ",")
        If PrecisionLimit = Len(StrValue) Then
            FormatNum = FormatNumber(NumValue, 0)
        Else
            If Precision > PrecisionLimit Then
                FormatNum = FormatNumber(NumValue, PrecisionLimit)
            Else
                FormatNum = FormatNumber(NumValue, Precision)
            End If
        End If
    End Function

#End Region

#Region "G - Date & Time Helpers"

    Function GetweekOfyear(ByVal filterdate As Date)
        Dim dateNow = DateTime.Now
        Dim dfi = DateTimeFormatInfo.CurrentInfo
        Dim calendar = dfi.Calendar

        ' using Thursday because I can.
        Dim weekOfyear = calendar.GetWeekOfYear(filterdate, dfi.CalendarWeekRule, DayOfWeek.Saturday)

        Return weekOfyear
    End Function

#End Region

#Region "H - Input Validation"

    Function NumericOnly(e As System.Windows.Forms.KeyPressEventArgs) As Boolean
        Dim strValid As String = "0123456789"

        If strValid.IndexOf(e.KeyChar) < 0 AndAlso Not (e.KeyChar = Convert.ToChar(Keys.Back)) Then
            ' not valid
            Return True
        Else
            ' valid
            Return False
        End If
    End Function

#End Region

#Region "I - File, Image & PDF Handling"

    Public Sub getfoto(apiUrl As String, bearerToken As String, picbox As PictureBox)
        Try
            Dim httpClient As New HttpClient()
            httpClient.DefaultRequestHeaders.Authorization = New System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken)

            Dim response As HttpResponseMessage = httpClient.GetAsync(apiUrl).Result

            If response.IsSuccessStatusCode Then
                Dim contentStream As Stream = response.Content.ReadAsStreamAsync().Result

                Using memoryStream As New MemoryStream()
                    contentStream.CopyTo(memoryStream)
                    memoryStream.Seek(0, SeekOrigin.Begin)

                    Dim image As New System.Drawing.Bitmap(memoryStream)
                    picbox.Image = image
                    picbox.SizeMode = PictureBoxSizeMode.StretchImage
                End Using
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub getPdf(apiUrl As String, bearerToken As String)
        Try
            Dim httpClient As New HttpClient()
            httpClient.DefaultRequestHeaders.Authorization =
            New System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken)

            Dim response As HttpResponseMessage = httpClient.GetAsync(apiUrl).Result

            If response.IsSuccessStatusCode Then
                Dim bytes As Byte() = response.Content.ReadAsByteArrayAsync().Result

                Dim tempPath As String = System.IO.Path.Combine(
                System.IO.Path.GetTempPath(), "preview_" & Guid.NewGuid().ToString() & ".pdf")

                System.IO.File.WriteAllBytes(tempPath, bytes)

                Process.Start(New ProcessStartInfo(tempPath) With {.UseShellExecute = True})
            End If
        Catch ex As Exception
            MessageBox.Show("Error load PDF: " & ex.Message)
        End Try
    End Sub

    Public Sub UploadFoto(pathfile As String, destinationfile As String)
        Try
            If File.Exists(destinationfile) Then
                File.Delete(destinationfile)
            End If
            File.Copy(pathfile, destinationfile)
        Catch ex As Exception
            MsgBox("gagal upload foto.")
        End Try
    End Sub

    Public Function GetFileExtension(ByVal fileName As String) As String
        ' Cari posisi titik terakhir dalam nama file
        Dim lastDotIndex As Integer = fileName.LastIndexOf(".")

        ' Jika tidak ada titik, kembalikan string kosong
        If lastDotIndex = -1 Then
            Return ""
        End If

        ' Dapatkan substring dari titik hingga akhir nama file
        Dim extension As String = fileName.Substring(lastDotIndex + 1)

        ' Kembalikan ekstensi file
        Return extension
    End Function

#End Region

#Region "J - Grid (C1FlexGrid) Clipboard Operations"

    ' Fungsi untuk menyalin 3 kolom yang dipilih
    Public Sub CopySelectedColumns(ByVal fg As C1FlexGrid)
        Dim selectedText As New StringBuilder()

        ' Loop melalui baris yang dipilih
        For row As Integer = fg.Selection.TopRow To fg.Selection.BottomRow
            Dim rowData As New List(Of String)()

            ' Ambil data dari 3 kolom pertama yang dipilih
            For col As Integer = fg.Selection.LeftCol To fg.Selection.RightCol
                rowData.Add(fg.Item(row, col))
            Next

            ' Gabungkan data baris dengan tab sebagai pemisah antar kolom
            selectedText.AppendLine(String.Join(vbTab, rowData))
        Next

        ' Salin teks yang sudah diformat ke clipboard
        Clipboard.SetText(selectedText.ToString())
    End Sub

    ' Fungsi untuk menempelkan data dari clipboard ke kolom yang dipilih
    Public Sub PasteToColumns(ByVal fg As C1FlexGrid)
        ' Ambil teks dari clipboard
        Dim clipboardText As String = Clipboard.GetText()
        If String.IsNullOrEmpty(clipboardText) Then
            Return
        End If

        ' Pisahkan teks menjadi baris
        Dim rows As String() = clipboardText.Split(New String() {Environment.NewLine}, StringSplitOptions.None)

        ' Mulai menempelkan data dari baris yang dipilih
        Dim startRow As Integer = fg.Selection.TopRow
        Dim startCol As Integer = fg.Selection.LeftCol

        For i As Integer = 0 To rows.Length - 1
            ' Pisahkan baris menjadi kolom
            Dim cols As String() = rows(i).Split(New String() {vbTab}, StringSplitOptions.None)

            For j As Integer = 0 To cols.Length - 1
                ' Pastikan tidak melebihi batas grid
                If startRow + i < fg.Rows.Count AndAlso startCol + j < fg.Cols.Count Then
                    fg.Item(startRow + i, startCol + j) = cols(j)
                End If
            Next
        Next
    End Sub

#End Region

#Region "K - Array Helpers"

    Public Sub TambahKeArray(ByRef arr() As Integer, nilai As Integer)
        ' Cek apakah nilai sudah ada di array
        If Not arr.Contains(nilai) Then
            Array.Resize(arr, arr.Length + 1) ' Tambah ukuran array
            arr(arr.Length - 1) = nilai ' Tambahkan nilai
        End If
    End Sub

#End Region

#Region "L - Menu Access Control"

    Public Sub VisibleMenuAkses()
        Dim menues As New List(Of ToolStripItem)
        Dim dt As DataTable = New DataTable
        Try
            dt = DB.ExecuteQuery(StrConnRMPApp, "select * from Mstmenu where GroupID='" & ClsSession.RoleID & "' order by MenuID") 'xample
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    For Each t As ToolStripItem In FrmMain.MenuStrip1.Items
                        GetMenues(t, menues)
                    Next
                    For Each t As ToolStripItem In menues
                        If (Val(t.Tag) - Val(row.Item("MenuID"))) = 0 Then
                            t.Visible = True
                            Exit For
                        End If
                    Next
                Next
            End If
        Catch EX As Exception
            MsgBox(EX.Message)
        End Try
    End Sub

#End Region

    Public Class CalendarColumn
        Inherits DataGridViewColumn
        Public Sub New()
            MyBase.New(New CalendarCell())
        End Sub
    End Class

    Public Class CalendarCell
        Inherits DataGridViewTextBoxCell
        Public Sub New()
            Me.Style.Format = "d"
        End Sub
    End Class


    Public Sub GetMenues(ByVal Current As ToolStripItem, ByRef menues As List(Of ToolStripItem))
        menues.Add(Current)
        If TypeOf (Current) Is ToolStripMenuItem Then
            For Each menu As ToolStripItem In DirectCast(Current, ToolStripMenuItem).DropDownItems
                GetMenues(menu, menues)
            Next
        End If
    End Sub
    Public Sub OpenForm(ByVal Frm As Form, ByVal Penuh As Boolean)
        Dim i As Integer

        For i = 0 To Application.OpenForms.Count - 1
            If Application.OpenForms.Item(i).Name.ToString = Frm.Name.ToString Then
                Frm.Focus()
            Else
                Frm.MdiParent = FrmMain
                If Penuh = True Then
                    Frm.WindowState = FormWindowState.Maximized
                End If
                Frm.Show()
            End If
        Next i
    End Sub

    Public Shared Function ValidateSpecialCharNextcloud(
    namaFile As String
) As Boolean

        If namaFile.Contains("[") OrElse namaFile.Contains("]") Then
            MessageBox.Show("Nama file tidak boleh mengandung karakter [ atau ].")
            Return False
        End If

        Return True
    End Function

    Public Function FileFolderExists(strFullPath As String) As Boolean
        'Author       : Ken Puls (www.excelguru.ca)
        'Macro Purpose: Check if a file or folder exists
        On Error GoTo EarlyExit
        If Not IsNothing(strFullPath) Then
            If Not Dir(strFullPath, vbDirectory) = vbNullString Then FileFolderExists = True
        End If
EarlyExit:
        On Error GoTo 0
    End Function

    Public Sub IsCreateFolderExists(ByVal Folder As String)
        Try
            If FileFolderExists(Folder) Then 'Jika folder ada
                '......................
            Else 'Jika folder tidak ada
                'Create folder
                MkDir(Folder)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Function ResizeImage(ByVal img As Image, ByVal width As Integer, ByVal height As Integer) As Image
        Dim bmp As New Bitmap(width, height)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.DrawImage(img, 0, 0, width, height)
        End Using
        Return bmp
    End Function

    Shared Function GetDate() As DateTime
        Dim dt As New DataTable
        dt = DB.ExecuteQuery(StrConnRMPApp, "Select GETDATE()")
        GetDate = dt.Rows(0).Item(0)
    End Function

    Public Sub ControlCentreForm(frm As Form, ctrl As System.Windows.Forms.Control)
        Dim sizes As Integer = ((frm.Width - ctrl.Width) / 2)
        Dim old As Padding = ctrl.Margin
        ctrl.Margin = New Padding(sizes, old.Top, old.Right, old.Bottom)
        ctrl.Focus()
        'ctrl.Top = ((frm.Height - ctrl.Height) / 2) - 100
    End Sub

    Public Sub MaskTextBox_SetCursorAkhir(txt As MaskedTextBox)
        Dim pos As Integer =
            txt.MaskedTextProvider.FindAssignedEditPositionFrom(
                txt.MaskedTextProvider.Length - 1, False)

        txt.SelectionStart = If(pos >= 0, pos + 1, 0)
        txt.SelectionLength = 0
    End Sub

    Public Sub SetRoundedPanel(pnl As Panel, radius As Integer)
        If pnl Is Nothing OrElse pnl.Width <= 0 OrElse pnl.Height <= 0 Then Exit Sub

        Dim r As Integer = Math.Max(1, Math.Min(radius, Math.Min(pnl.Width, pnl.Height) \ 2))
        Dim d As Integer = r * 2

        Using path As New GraphicsPath()
            path.AddArc(0, 0, d, d, 180, 90)
            path.AddArc(pnl.Width - d - 1, 0, d, d, 270, 90)
            path.AddArc(pnl.Width - d - 1, pnl.Height - d - 1, d, d, 0, 90)
            path.AddArc(0, pnl.Height - d - 1, d, d, 90, 90)
            path.CloseFigure()

            pnl.Region = New Region(path)
        End Using
    End Sub

End Class