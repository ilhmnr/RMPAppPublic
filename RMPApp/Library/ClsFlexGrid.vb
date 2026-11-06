' ============================================================================
'  ClsFlexGrid.vb
'  ----------------------------------------------------------------------------
'  Helper class untuk C1FlexGrid. Berisi 2 fungsi utama:
'
'   1. ApplyStyle(fg)
'      → Terapkan tampilan standar yang seragam ke seluruh grid:
'        warna header, font, tinggi baris, alignment header, seleksi baris,
'        zebra row, dan opsi visual lainnya.
'
'   2. AttachLiveNumber(fg, decimals, colNames...)
'      → Format angka otomatis saat user mengetik di cell.
'        Contoh: ketik "100" lalu "0" → tampil "1.000" real-time.
'
'  PEMAKAIAN STANDAR DI FORM:
'      Call ClsFlexGrid.ApplyStyle(fg)
'      Call ClsFlexGrid.AttachLiveNumber(fg, 0, "fgDebet", "fgCredit")
'      Call ClsFlexGrid.AttachLiveNumber(fg, 2, "fgRate")
'
'  CATATAN:
'   - Default culture "id-ID" (titik=ribuan, koma=desimal).
'   - AttachLiveNumber idempoten: aman dipanggil berulang.
' ============================================================================

Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms
Imports C1.Win.C1FlexGrid
Imports ClosedXML.Excel

Public Class ClsFlexGrid

#Region "============== KONFIGURASI GLOBAL ==============="

    Public Shared Property CultureName As String = "id-ID"

    Public Shared Property HeaderBackColor As Color = Color.FromArgb(54, 96, 146)
    Public Shared Property HeaderForeColor As Color = Color.White
    Public Shared Property HeaderFont As Font = New Font("Tahoma", 8.25, FontStyle.Bold)

    Public Shared Property SelectionBackColor As Color = Color.FromArgb(255, 235, 156)
    Public Shared Property SelectionForeColor As Color = Color.Black

    Public Shared Property AlternateRowColor As Color = Color.FromArgb(245, 245, 245)

    Public Shared Property HeaderHeight As Integer = 25
    Public Shared Property DataRowHeight As Integer = 22

    Public Shared Property CellFont As Font = New Font("Tahoma", 8.25)

    Public Shared Property DefaultSelectionMode As SelectionModeEnum = SelectionModeEnum.Default

    Public Shared Property ExtendLastColumn As Boolean = False

    ''' <summary>Warna latar untuk kolom yang boleh di-edit. Default biru muda lembut.</summary>
    Public Shared Property EditableBackColor As Color = Color.FromArgb(204, 229, 255)
    ''' <summary>Warna teks untuk kolom yang boleh di-edit. Default hitam.</summary>
    Public Shared Property EditableForeColor As Color = Color.Black

#End Region

#Region "============== STATE INTERNAL ==============="
    Private Shared ReadOnly liveColMap As New Dictionary(Of C1FlexGrid, Dictionary(Of Integer, Integer))
    Private Shared ReadOnly attachedGrids As New HashSet(Of C1FlexGrid)
    Private Shared ReadOnly zebraGrids As New HashSet(Of C1FlexGrid)
    Private Shared isFormatting As Boolean = False
#End Region

#Region "============== APPLY STYLE ==============="

    Public Shared Sub ApplyStyle(ByVal fg As C1FlexGrid)
        If fg Is Nothing Then Exit Sub

        ' --- Visual umum ---
        fg.Font = CellFont
        fg.AllowResizing = AllowResizingEnum.Columns
        fg.SelectionMode = DefaultSelectionMode
        fg.FocusRect = FocusRectEnum.None
        fg.ExtendLastCol = ExtendLastColumn
        fg.BackColor = Color.White

        ' --- Tinggi baris ---
        fg.Rows.DefaultSize = DataRowHeight
        If fg.Rows.Count > 0 Then fg.Rows(0).Height = HeaderHeight

        ' --- Style header ---
        Dim hdrStyle As CellStyle = fg.Styles("Fixed")
        hdrStyle.BackColor = HeaderBackColor
        hdrStyle.ForeColor = HeaderForeColor
        hdrStyle.Font = HeaderFont
        hdrStyle.TextAlign = TextAlignEnum.CenterCenter

        ' --- Style baris terpilih ---
        Dim selStyle As CellStyle = fg.Styles("Highlight")
        selStyle.BackColor = SelectionBackColor
        selStyle.ForeColor = SelectionForeColor

        ' --- Zebra row ---
        If AlternateRowColor <> Color.Empty Then
            Dim altStyle As CellStyle
            If fg.Styles.Contains("Alternate") Then
                altStyle = fg.Styles("Alternate")
            Else
                altStyle = fg.Styles.Add("Alternate")
            End If
            altStyle.BackColor = AlternateRowColor

            If Not zebraGrids.Contains(fg) Then
                AddHandler fg.AfterDataRefresh, AddressOf Fg_AfterDataRefresh_Zebra
                AddHandler fg.Disposed, AddressOf Fg_Disposed
                zebraGrids.Add(fg)
            End If

            ApplyZebraRows(fg)
        End If
    End Sub

    Public Shared Sub ApplyStyle(ByVal fg As C1FlexGrid, ByVal selectionMode As SelectionModeEnum)
        ApplyStyle(fg)
        If fg IsNot Nothing Then fg.SelectionMode = selectionMode
    End Sub

    Public Shared Sub ApplyZebraRows(ByVal fg As C1FlexGrid)
        If fg Is Nothing Then Exit Sub
        If Not fg.Styles.Contains("Alternate") Then Exit Sub

        Dim altStyle As CellStyle = fg.Styles("Alternate")
        For r As Integer = fg.Rows.Fixed To fg.Rows.Count - 1
            Dim dataRowIndex As Integer = r - fg.Rows.Fixed
            If (dataRowIndex Mod 2) = 0 Then
                fg.Rows(r).Style = altStyle
            Else
                fg.Rows(r).Style = Nothing
            End If
        Next
    End Sub

    Public Shared Sub SetCaptions(ByVal fg As C1FlexGrid, ParamArray pairs As String())
        If fg Is Nothing Then Exit Sub
        For Each p In pairs
            If String.IsNullOrEmpty(p) OrElse Not p.Contains(":") Then Continue For
            Dim parts = p.Split(New Char() {":"c}, 2)
            Dim cIdx = GetColIndex(fg, parts(0).Trim())
            If cIdx >= 0 Then fg.Cols(cIdx).Caption = parts(1)
        Next
    End Sub

    Public Shared Sub SetWidths(ByVal fg As C1FlexGrid, ParamArray pairs As String())
        If fg Is Nothing Then Exit Sub
        For Each p In pairs
            If String.IsNullOrEmpty(p) OrElse Not p.Contains(":") Then Continue For
            Dim parts = p.Split(New Char() {":"c}, 2)
            Dim cIdx = GetColIndex(fg, parts(0).Trim())
            Dim w As Integer
            If cIdx >= 0 AndAlso Integer.TryParse(parts(1), w) Then fg.Cols(cIdx).Width = w
        Next
    End Sub

    Public Shared Sub HideColumns(ByVal fg As C1FlexGrid, ParamArray colNames As String())
        If fg Is Nothing Then Exit Sub
        For Each cn In colNames
            Dim cIdx = GetColIndex(fg, cn)
            If cIdx >= 0 Then fg.Cols(cIdx).Visible = False
        Next
    End Sub

    ''' <summary>
    ''' Tandai kolom-kolom sebagai BOLEH di-edit, dengan warna khusus.
    ''' Kolom selain yang disebut otomatis di-set read-only (AllowEditing=False).
    ''' 
    ''' Hanya mengubah BackColor & ForeColor; tidak mengganggu Format,
    ''' TextAlign, atau setting style lain yang sudah ada di kolom.
    ''' Contoh:
    '''   SetEditableColumns(fg, "fgDebet", "fgCredit", "fgRemark")
    ''' </summary>
    Public Shared Sub SetEditableColumns(ByVal fg As C1FlexGrid, ParamArray colNames As String())
        If fg Is Nothing Then Exit Sub

        '' Set semua kolom jadi read-only dulu
        'For c As Integer = 0 To fg.Cols.Count - 1
        '    fg.Cols(c).AllowEditing = False
        'Next

        '' Aktifkan editing + warnai hanya pada kolom yang disebut
        'For Each cn In colNames
        '    Dim cIdx = GetColIndex(fg, cn)
        '    If cIdx >= 0 Then
        '        fg.Cols(cIdx).AllowEditing = True

        '        ' Pastikan kolom punya Style sendiri (bukan referensi ke Normal),
        '        ' lalu ubah HANYA warna — Format & TextAlign tetap utuh.
        '        If fg.Cols(cIdx).Style Is Nothing Then
        '            fg.Cols(cIdx).Style = fg.Styles.Add("Editable_" & fg.Cols(cIdx).Name)
        '        End If
        '        fg.Cols(cIdx).Style.BackColor = EditableBackColor
        '        fg.Cols(cIdx).Style.ForeColor = EditableForeColor
        '    End If
        'Next

        ' Aktifkan editing + warnai hanya pada kolom yang disebut
        For Each cn In colNames
            Dim cIdx = GetColIndex(fg, cn)
            If cIdx >= 0 Then
                fg.Cols(cIdx).Style.BackColor = EditableBackColor
                fg.Cols(cIdx).Style.ForeColor = EditableForeColor
            End If
        Next

        ' Aktifkan editing di grid (kalau belum)
        fg.AllowEditing = True
    End Sub

    ''' <summary>
    ''' Sebaliknya: tandai kolom-kolom sebagai READ-ONLY (tidak boleh di-edit).
    ''' Kolom lain tetap mengikuti setting Designer.
    ''' </summary>
    Public Shared Sub SetReadOnlyColumns(ByVal fg As C1FlexGrid, ParamArray colNames As String())
        If fg Is Nothing Then Exit Sub
        For Each cn In colNames
            Dim cIdx = GetColIndex(fg, cn)
            If cIdx >= 0 Then fg.Cols(cIdx).AllowEditing = False
        Next
    End Sub

#End Region

#Region "============== ATTACH LIVE NUMBER FORMAT ==============="

    ''' <summary>
    ''' Pasang live number format pada kolom-kolom tertentu.
    ''' Setiap kali user mengetik, tampilan langsung ter-format ribuan.
    ''' 
    ''' Otomatis memvalidasi: jika cell kosong / berisi string non-angka saat
    ''' user keluar dari edit-mode, nilai akan di-set ke 0.
    ''' 
    ''' Contoh: AttachLiveNumber(fg, 0, "fgDebet", "fgCredit")
    '''         AttachLiveNumber(fg, 2, "fgRate")    ' 2 desimal
    ''' </summary>
    Public Shared Sub AttachLiveNumber(ByVal fg As C1FlexGrid,
                                       ByVal decimals As Integer,
                                       ParamArray colNames As String())
        If fg Is Nothing Then Exit Sub

        If Not liveColMap.ContainsKey(fg) Then
            liveColMap(fg) = New Dictionary(Of Integer, Integer)
        End If
        For Each cn In colNames
            Dim cIdx = GetColIndex(fg, cn)
            If cIdx >= 0 Then
                liveColMap(fg)(cIdx) = decimals
                fg.Cols(cIdx).Format = If(decimals > 0,
                                          "#,##0." & New String("0"c, decimals),
                                          "#,##0")
                fg.Cols(cIdx).TextAlign = TextAlignEnum.RightCenter
            End If
        Next

        If Not attachedGrids.Contains(fg) Then
            AddHandler fg.SetupEditor, AddressOf Fg_SetupEditor
            AddHandler fg.ValidateEdit, AddressOf Fg_ValidateEdit
            AddHandler fg.AfterEdit, AddressOf Fg_AfterEdit
            AddHandler fg.Disposed, AddressOf Fg_Disposed
            attachedGrids.Add(fg)
        End If
    End Sub

    Public Shared Sub DetachLiveNumber(ByVal fg As C1FlexGrid)
        If fg Is Nothing Then Exit Sub
        If attachedGrids.Contains(fg) Then
            RemoveHandler fg.SetupEditor, AddressOf Fg_SetupEditor
            RemoveHandler fg.ValidateEdit, AddressOf Fg_ValidateEdit
            RemoveHandler fg.AfterEdit, AddressOf Fg_AfterEdit
            RemoveHandler fg.Disposed, AddressOf Fg_Disposed
            attachedGrids.Remove(fg)
        End If
        liveColMap.Remove(fg)
    End Sub

#End Region

#Region "============== EVENT HANDLERS ==============="

    Private Shared Sub Fg_AfterDataRefresh_Zebra(sender As Object, e As EventArgs)
        Dim fg As C1FlexGrid = TryCast(sender, C1FlexGrid)
        If fg IsNot Nothing Then ApplyZebraRows(fg)
    End Sub

    Private Shared Sub Fg_SetupEditor(sender As Object, e As RowColEventArgs)
        Dim fg As C1FlexGrid = TryCast(sender, C1FlexGrid)
        If fg Is Nothing Then Exit Sub

        If Not liveColMap.ContainsKey(fg) Then Exit Sub
        If Not liveColMap(fg).ContainsKey(e.Col) Then Exit Sub

        Dim tb As TextBox = TryCast(fg.Editor, TextBox)
        If tb Is Nothing Then Exit Sub

        tb.Tag = liveColMap(fg)(e.Col)

        RemoveHandler tb.TextChanged, AddressOf Editor_TextChanged
        AddHandler tb.TextChanged, AddressOf Editor_TextChanged
    End Sub

    Private Shared Sub Editor_TextChanged(sender As Object, e As EventArgs)
        If isFormatting Then Exit Sub
        Dim tb As TextBox = TryCast(sender, TextBox)
        If tb Is Nothing Then Exit Sub
        If String.IsNullOrEmpty(tb.Text) Then Exit Sub

        Dim decimals As Integer = 0
        If tb.Tag IsNot Nothing AndAlso TypeOf tb.Tag Is Integer Then
            decimals = CInt(tb.Tag)
        End If

        Dim culture = GetCulture()
        Dim originalText As String = tb.Text
        Dim caretPos As Integer = tb.SelectionStart
        Dim digitsBefore As Integer = CountDigitsBefore(originalText, caretPos)

        Dim parsed As Double
        If Not TryParseLocalized(originalText, culture, parsed) Then Exit Sub

        Dim fmt As String = "#,##0"
        If decimals > 0 Then fmt = "#,##0." & New String("0"c, decimals)

        Dim newText As String = parsed.ToString(fmt, culture)

        Dim decSep As String = culture.NumberFormat.NumberDecimalSeparator
        If originalText.EndsWith(decSep) AndAlso Not newText.Contains(decSep) Then
            newText &= decSep
        End If

        If newText = originalText Then Exit Sub

        isFormatting = True
        Try
            tb.Text = newText
            tb.SelectionStart = FindCaretAfterDigits(newText, digitsBefore)
            tb.SelectionLength = 0
        Finally
            isFormatting = False
        End Try
    End Sub

    Private Shared Sub Fg_Disposed(sender As Object, e As EventArgs)
        Dim fg As C1FlexGrid = TryCast(sender, C1FlexGrid)
        If fg Is Nothing Then Exit Sub
        attachedGrids.Remove(fg)
        zebraGrids.Remove(fg)
        liveColMap.Remove(fg)
    End Sub

    ''' <summary>
    ''' Validasi saat user keluar dari edit-mode (Enter/Tab/klik cell lain).
    ''' Jika input kosong atau bukan angka valid, set ke "0" tanpa menolak edit.
    ''' </summary>
    Private Shared Sub Fg_ValidateEdit(sender As Object, e As ValidateEditEventArgs)
        Dim fg As C1FlexGrid = TryCast(sender, C1FlexGrid)
        If fg Is Nothing Then Exit Sub

        ' Cek apakah kolom ini terdaftar untuk live-format
        If Not liveColMap.ContainsKey(fg) Then Exit Sub
        If Not liveColMap(fg).ContainsKey(e.Col) Then Exit Sub

        Dim editorText As String = ""
        If fg.Editor IsNot Nothing Then editorText = fg.Editor.Text

        ' Kalau input kosong atau tidak bisa di-parse jadi angka → set ke "0"
        Dim parsed As Double
        If String.IsNullOrWhiteSpace(editorText) OrElse
           Not TryParseLocalized(editorText, GetCulture(), parsed) Then
            If fg.Editor IsNot Nothing Then fg.Editor.Text = "0"
        End If
    End Sub

    ''' <summary>
    ''' Setelah edit selesai, pastikan nilai cell sudah berupa angka valid.
    ''' Backup safety net kalau ValidateEdit terlewat (misal user paste data invalid).
    ''' </summary>
    Private Shared Sub Fg_AfterEdit(sender As Object, e As RowColEventArgs)
        Dim fg As C1FlexGrid = TryCast(sender, C1FlexGrid)
        If fg Is Nothing Then Exit Sub

        If Not liveColMap.ContainsKey(fg) Then Exit Sub
        If Not liveColMap(fg).ContainsKey(e.Col) Then Exit Sub

        Dim cellVal As Object = fg.Item(e.Row, e.Col)
        Dim s As String = If(cellVal Is Nothing OrElse IsDBNull(cellVal), "", cellVal.ToString())

        Dim parsed As Double
        If String.IsNullOrWhiteSpace(s) OrElse
           Not TryParseLocalized(s, GetCulture(), parsed) Then
            fg.Item(e.Row, e.Col) = 0
        Else
            ' Pastikan nilai tersimpan sebagai angka, bukan string
            fg.Item(e.Row, e.Col) = parsed
        End If
    End Sub

#End Region

#Region "============== HELPER PRIVATE ==============="

    Private Shared Function GetColIndex(ByVal fg As C1FlexGrid, ByVal colName As String) As Integer
        If fg Is Nothing OrElse String.IsNullOrEmpty(colName) Then Return -1
        Try
            Return fg.Cols(colName).Index
        Catch
            Return -1
        End Try
    End Function

    Private Shared Function GetCulture() As CultureInfo
        Try
            Return New CultureInfo(CultureName)
        Catch
            Return CultureInfo.CurrentCulture
        End Try
    End Function

    Private Shared Function CountDigitsBefore(ByVal text As String, ByVal caret As Integer) As Integer
        If caret > text.Length Then caret = text.Length
        Dim n As Integer = 0
        For i As Integer = 0 To caret - 1
            If Char.IsDigit(text(i)) Then n += 1
        Next
        Return n
    End Function

    Private Shared Function FindCaretAfterDigits(ByVal text As String, ByVal targetDigits As Integer) As Integer
        If targetDigits <= 0 Then Return 0
        Dim count As Integer = 0
        For i As Integer = 0 To text.Length - 1
            If Char.IsDigit(text(i)) Then
                count += 1
                If count >= targetDigits Then Return i + 1
            End If
        Next
        Return text.Length
    End Function

    Private Shared Function TryParseLocalized(ByVal s As String,
                                              ByVal culture As CultureInfo,
                                              ByRef result As Double) As Boolean
        result = 0
        If String.IsNullOrWhiteSpace(s) Then Return False

        Dim decSep As String = culture.NumberFormat.NumberDecimalSeparator
        Dim sb As New System.Text.StringBuilder(s.Length)
        Dim seenDecimal As Boolean = False

        For i As Integer = 0 To s.Length - 1
            Dim ch As Char = s(i)
            If Char.IsDigit(ch) Then
                sb.Append(ch)
            ElseIf ch = "-"c AndAlso sb.Length = 0 Then
                sb.Append(ch)
            ElseIf decSep.Length > 0 AndAlso ch = decSep(0) AndAlso Not seenDecimal Then
                sb.Append(ch)
                seenDecimal = True
            End If
        Next

        Dim cleaned As String = sb.ToString()
        If cleaned.Length = 0 OrElse cleaned = "-" Then Return False
        Return Double.TryParse(cleaned, NumberStyles.Number, culture, result)
    End Function

#End Region

#Region "============== DIALOG LOOKUP ==============="

    Public Shared Sub ShowLookup(frm As Form,
                             owner As Form,
                             methodName As String,
                             sourceFg As Object,
                             Optional excludeColumn As String = "",
                             Optional autoClose As Boolean = False)

        Dim dlg = TryCast(frm, ILookupDialog)
        If dlg Is Nothing Then
            Throw New ArgumentException("Form harus implement ILookupDialog")
        End If

        dlg.SourceFg = sourceFg
        dlg.ExcludeColumn = excludeColumn
        dlg.AutoClose = autoClose

        Dim handler As ILookupDialog.ItemSelectedEventHandler =
        Sub(data As Dictionary(Of String, String))
            Dim mi = owner.GetType().GetMethod(methodName)
            If mi IsNot Nothing Then
                mi.Invoke(owner, New Object() {data})
            End If
        End Sub

        AddHandler dlg.ItemSelected, handler

        owner.Cursor = Cursors.WaitCursor

        dlg.LoadItems()
        frm.ShowDialog(owner)

        owner.Cursor = Cursors.Default

        RemoveHandler dlg.ItemSelected, handler

    End Sub

    Public Shared Function CollectColumnValues(fg As Object,
                                               columnName As String) As List(Of String)
        Dim result As New List(Of String)

        Try
            Dim rowCount As Integer = fg.Rows.Count
            For i = 1 To rowCount - 1
                Dim cellVal = fg(i, columnName)
                Dim val As String = If(cellVal Is Nothing, "", cellVal.ToString().Trim())
                If val <> "" AndAlso Not result.Contains(val) Then
                    result.Add(val)
                End If
            Next
        Catch ex As Exception
        End Try

        Return result
    End Function

    Public Shared Sub AddEmptyRow(fg As C1.Win.C1FlexGrid.C1FlexGrid)
        Dim parts(fg.Cols.Count - 1) As String

        For i = 0 To fg.Cols.Count - 1
            Dim col = fg.Cols(i)
            If col.DataType = GetType(Integer) OrElse
               col.DataType = GetType(Double) OrElse
               col.DataType = GetType(Decimal) OrElse
               col.DataType = GetType(Single) Then
                parts(i) = "0"
            Else
                parts(i) = ""
            End If
        Next

        fg.AddItem(String.Join(vbTab, parts))
    End Sub

#End Region

    Public Shared Function AggregateColumn(fg As C1.Win.C1FlexGrid.C1FlexGrid,
                                       colName As String) As Decimal
        Dim total As Decimal = 0

        If fg.Cols.IndexOf(colName) < 0 Then Return 0

        For i = 1 To fg.Rows.Count - 1
            Dim cellVal = fg(i, colName)
            If cellVal IsNot Nothing AndAlso cellVal.ToString().Trim() <> "" Then
                Dim value As Decimal
                Decimal.TryParse(cellVal.ToString().Replace(",", ""), value)
                total += value
            End If
        Next

        Return total
    End Function

    Public Shared Sub SetNumberFormat(fg As C1FlexGrid,
                                  format As String,
                                  ParamArray colNames() As String)

        For Each colName As String In colNames

            If fg.Cols.Contains(colName) Then

                fg.Cols(colName).Format = format
                fg.Cols(colName).TextAlign = TextAlignEnum.RightCenter

            End If

        Next

        ' pasang event live format sekali saja
        RemoveHandler fg.StartEdit, AddressOf Flex_StartEdit
        AddHandler fg.StartEdit, AddressOf Flex_StartEdit

    End Sub

    Private Shared Sub Flex_StartEdit(sender As Object, e As RowColEventArgs)

        Dim fg As C1FlexGrid = DirectCast(sender, C1FlexGrid)

        If fg.Editor Is Nothing Then Exit Sub

        ' tentukan jumlah desimal dari format kolom
        Dim fmt As String = fg.Cols(e.Col).Format
        Dim decimals As Integer = 0

        If Not String.IsNullOrEmpty(fmt) AndAlso fmt.Contains(".") Then
            decimals = fmt.Length - fmt.IndexOf("."c) - 1
        End If

        fg.Editor.Tag = decimals

        RemoveHandler fg.Editor.TextChanged, AddressOf Editor_TextChanged
        AddHandler fg.Editor.TextChanged, AddressOf Editor_TextChanged

    End Sub

End Class