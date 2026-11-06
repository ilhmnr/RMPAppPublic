Imports C1.Win
Imports C1.Win.C1FlexGrid

Public Class ClsFormControlHelper
    Public Sub EnabledTextBoxInBox(ByVal flag As Boolean, ByVal grb As System.Windows.Forms.GroupBox)
        For Each ctl As Control In grb.Controls
            If TypeOf ctl Is TextBox Then
                CType(ctl, TextBox).Enabled = flag
            End If
        Next
    End Sub

    Public Sub EnabledcomboboxInBox(ByVal flag As Boolean, ByVal grb As System.Windows.Forms.GroupBox)
        For Each ctl As Control In grb.Controls
            If TypeOf ctl Is ComboBox Then
                CType(ctl, ComboBox).Enabled = flag
            End If
        Next
    End Sub


    Public Sub EnabledTextBoxInBoxSPLIT(ByVal flag As Boolean, ByVal grb As System.Windows.Forms.SplitContainer)
        For Each ctl As Control In grb.Panel1.Controls
            If TypeOf ctl Is TextBox Then
                CType(ctl, TextBox).Enabled = flag
            End If
        Next
    End Sub

    Public Sub EnabledcomboboxInBoxSPLIT(ByVal flag As Boolean, ByVal grb As System.Windows.Forms.SplitContainer)
        For Each ctl As Control In grb.Panel1.Controls
            If TypeOf ctl Is ComboBox Then
                CType(ctl, ComboBox).Enabled = flag
            End If
        Next
    End Sub

    Public Sub ValidCombo(cbo As ComboBox)
        If cbo.FindString(cbo.Text) < 0 Then
            cbo.Text = cbo.Text.Remove(cbo.Text.Length - 1)
            cbo.SelectionStart = cbo.Text.Length
        End If
    End Sub

    Public Sub ClearText(ByVal root As Control)
        For Each ctrl As Control In root.Controls
            ClearText(ctrl)
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Text = String.Empty
            End If

            If TypeOf ctrl Is ComboBox Then
                CType(ctrl, ComboBox).Text = String.Empty
            End If

            If TypeOf ctrl Is CheckBox Then
                If CType(ctrl, CheckBox).Tag = 1 Then
                    CType(ctrl, CheckBox).Checked = True
                Else
                    CType(ctrl, CheckBox).Checked = False
                End If
            End If

            If TypeOf ctrl Is DateTimePicker Then
                CType(ctrl, DateTimePicker).Value = Now
            End If
        Next ctrl
    End Sub

    Public Sub EnabledFalse(ByVal root As Control)
        For Each ctrl As Control In root.Controls
            EnabledFalse(ctrl)
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Enabled = False
            End If

            If TypeOf ctrl Is ComboBox Then
                CType(ctrl, ComboBox).Enabled = False
            End If

            If TypeOf ctrl Is CheckBox Then
                CType(ctrl, CheckBox).Enabled = False
            End If

            If TypeOf ctrl Is RadioButton Then
                CType(ctrl, RadioButton).Enabled = False
            End If

            If TypeOf ctrl Is Button Then
                CType(ctrl, Button).Enabled = False
            End If
        Next ctrl
    End Sub

    Public Sub EnabledTrue(ByVal root As Control)
        For Each ctrl As Control In root.Controls
            EnabledTrue(ctrl)
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Enabled = True
                'If CType(ctrl, TextBox).Enabled = True Then

                'End If
            End If

            If TypeOf ctrl Is ComboBox Then
                CType(ctrl, ComboBox).Enabled = True
            End If

            If TypeOf ctrl Is CheckBox Then
                CType(ctrl, CheckBox).Enabled = True
            End If

            If TypeOf ctrl Is RadioButton Then
                CType(ctrl, RadioButton).Enabled = True
            End If

            If TypeOf ctrl Is Button Then
                CType(ctrl, Button).Enabled = True
            End If
        Next ctrl
    End Sub

    Public Sub BackClr(obj As Object, pilihan As Integer)
        Select Case pilihan
            Case 1
                obj.BackColor = Color.FromArgb(102, 164, 172)
            Case 2
                obj.BackColor = Color.FromArgb(241, 231, 254) 'FIND
            Case 3
                obj.BackColor = Color.FromArgb(150, 54, 148) 'EDIT
            Case 4
                obj.BackColor = Color.FromArgb(30, 130, 76) 'SAVE
            Case 5
                obj.BackColor = Color.FromArgb(217, 30, 24) 'DELETE
            Case 6
                obj.BackColor = Color.FromArgb(46, 49, 49) 'EXIT
            Case 7
                obj.BackColor = Color.FromArgb(240, 240, 240) 'FORM
            Case 8
                obj.BackColor = Color.IndianRed 'CANCEL
            Case 9
                obj.BackColor = Color.FromArgb(0, 172, 251)
            Case 10
                obj.BackColor = Color.FromArgb(139, 195, 74)
            Case 11
                obj.BackColor = Color.FromArgb(33, 115, 70)
        End Select
    End Sub

    Public Sub AfterSave(ByVal root As Control)
        For Each ctrl As Control In root.Controls
            AfterSave(ctrl)
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Enabled = True
                CType(ctrl, TextBox).ReadOnly = True
            End If

            If TypeOf ctrl Is RadioButton Then
                CType(ctrl, RadioButton).Enabled = False
            End If

            If TypeOf ctrl Is ComboBox Then
                CType(ctrl, ComboBox).Enabled = False
            End If

            If TypeOf ctrl Is DateTimePicker Then
                CType(ctrl, DateTimePicker).Enabled = False
            End If
        Next ctrl
    End Sub

    Public Sub ChkCondtxt(chk As CheckBox, obj As TextBox, Msg As String, Optional TypeInd As Byte = 0)
        If TypeInd = 0 Then
            If chk.Checked = False Then
                obj.Text = ""
            Else
                If obj.Text = "" Then
                    Call MsgBox(Msg & " is Empty !", vbExclamation, AT)
                    obj.Focus()
                    chk.Checked = False
                End If
            End If
        Else
            If chk.Checked = False Then
                obj.Text = ""
            Else
                If obj.Text = "" Then
                    Call MsgBox(Msg & " is Empty !", vbExclamation, AT)
                    obj.Focus()
                    chk.Checked = False
                End If
            End If
        End If
    End Sub

    Public Sub ChkCondCmb(chk As CheckBox, obj As ComboBox, Msg As String, Optional TypeInd As Byte = 0)
        If TypeInd = 0 Then
            If chk.Checked = False Then
                obj.Text = ""
            Else
                If obj.Text = "" Then
                    Call MsgBox(Msg & " is Empty !", vbExclamation, AT)
                    obj.Focus()
                    chk.Checked = False
                End If
            End If
        Else
            If chk.Checked = False Then
                obj.Text = ""
            Else
                If obj.Text = "" Then
                    Call MsgBox(Msg & " is Empty !", vbExclamation, AT)
                    obj.Focus()
                    chk.Checked = False
                End If
            End If
        End If
    End Sub

    Public Sub validasi(e As KeyPressEventArgs, pilihan As Integer)
        Select Case pilihan
            Case 1
                'Hanya huruf A-Z atau a-z dan tombol BackSpace, Delete, Space serta Enter
                Dim KeyAscii As Short = Asc(e.KeyChar)
                If (e.KeyChar Like "[A-Z, a-z]" _
                    OrElse KeyAscii = Keys.Back _
                    OrElse KeyAscii = Keys.Space _
                    OrElse KeyAscii = Keys.Return _
                    OrElse KeyAscii = Keys.Delete) Then
                    KeyAscii = 0
                End If
                e.Handled = CBool(KeyAscii)
            Case 2
                If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
        End Select
    End Sub

    Public Sub AutoCompleteCombo_KeyUp(ByVal cbo As ComboBox, ByVal e As KeyEventArgs)
        Dim sTypedText As String
        Dim iFoundIndex As Integer
        Dim oFoundItem As Object
        Dim sFoundText As String
        Dim sAppendText As String

        'Allow select keys without Autocompleting
        Select Case e.KeyCode
            Case Keys.Back, Keys.Left, Keys.Right, Keys.Up, Keys.Delete, Keys.Down
                Return
        End Select

        'Get the Typed Text and Find it in the list
        sTypedText = cbo.Text
        iFoundIndex = cbo.FindString(sTypedText)

        'If we found the Typed Text in the list then Autocomplete
        If iFoundIndex >= 0 Then

            'Get the Item from the list (Return Type depends if Datasource was bound 
            ' or List Created)
            oFoundItem = cbo.Items(iFoundIndex)

            'Use the ListControl.GetItemText to resolve the Name in case the Combo 
            ' was Data bound
            sFoundText = cbo.GetItemText(oFoundItem)

            'Append then found text to the typed text to preserve case
            sAppendText = sFoundText.Substring(sTypedText.Length)
            cbo.Text = sTypedText & sAppendText

            'Select the Appended Text
            cbo.SelectionStart = sTypedText.Length
            cbo.SelectionLength = sAppendText.Length

        End If

    End Sub

    Public Sub HapusGrid(ByVal RowHeader As Integer, ByVal NamaFlexGrid As C1FlexGrid)
        With NamaFlexGrid
            For i As Integer = RowHeader To .Rows.Count - 1
                .RemoveItem()
            Next i
        End With
    End Sub

    Public Sub setcolorandreadonly(txt As TextBox, key As Integer)
        Select Case key
            Case 1
                txt.ReadOnly = True
                txt.BackColor = Color.LightGoldenrodYellow
            Case 2
                txt.ReadOnly = False
                txt.BackColor = Color.White
        End Select
    End Sub

    Public Sub MdiChildTengah(ByVal parent As Windows.Forms.Form, ByVal child As Windows.Forms.Form)
        Dim frmA As Windows.Forms.Form = parent
        Dim frmB As Windows.Forms.Form = child
        Dim x As Integer = (parent.Width / 2) - (child.Width / 2)
        Dim y As Integer = (parent.Height / 2) - (child.Height / 2)
        child.Location = New Point(x, y)
    End Sub

    Public Sub CenterForm(ByVal frm As Windows.Forms.Form)
        frm.Width = 831
        frm.Height = 534
        frm.Left = (Screen.PrimaryScreen.WorkingArea.Width - frm.Width) / 2
        frm.Top = (Screen.PrimaryScreen.WorkingArea.Height - frm.Height) / 2
    End Sub

    Public Sub InitializeDataGridView(C1FLEXGRID1 As DataGridView)
        ' Initialize basic DataGridView properties.
        C1FLEXGRID1.Dock = DockStyle.Fill
        C1FLEXGRID1.BackgroundColor = Color.White
        C1FLEXGRID1.BorderStyle = BorderStyle.Fixed3D

        ' Set property values appropriate for read-only display and 
        ' limited interactivity. 
        C1FLEXGRID1.AllowUserToAddRows = False
        C1FLEXGRID1.AllowUserToDeleteRows = False
        C1FLEXGRID1.AllowUserToOrderColumns = True

        'C1FLEXGRID1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        C1FLEXGRID1.AllowUserToResizeColumns = False
        C1FLEXGRID1.ColumnHeadersHeightSizeMode =
            DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        C1FLEXGRID1.AllowUserToResizeRows = False
        C1FLEXGRID1.RowHeadersWidthSizeMode =
            DataGridViewRowHeadersWidthSizeMode.DisableResizing

        'Set the selection background color for all the cells.
        C1FLEXGRID1.DefaultCellStyle.SelectionBackColor = Color.Ivory
        C1FLEXGRID1.DefaultCellStyle.SelectionForeColor = Color.LightBlue
        C1FLEXGRID1.RowHeadersDefaultCellStyle.SelectionBackColor = Color.WhiteSmoke

        C1FLEXGRID1.RowsDefaultCellStyle.BackColor = Color.AliceBlue
        C1FLEXGRID1.AlternatingRowsDefaultCellStyle.BackColor = Color.White

        ' Set the row and column header styles.
        C1FLEXGRID1.ColumnHeadersDefaultCellStyle.ForeColor = Color.SteelBlue
        C1FLEXGRID1.ColumnHeadersDefaultCellStyle.BackColor = Color.CornflowerBlue
        C1FLEXGRID1.RowHeadersDefaultCellStyle.BackColor = Color.White

        Dim font As New Font(
            C1FLEXGRID1.DefaultCellStyle.Font.FontFamily, 15, FontStyle.Bold)
        Try

        Finally
            font.Dispose()
        End Try
    End Sub

    Public Sub SetThousandSeparator(txt As TextBox)
        If txt.Text.Length > 0 Then
            Try
                Dim s As String = txt.Text.Replace(",", "")

                Dim i As Decimal = Decimal.Parse(s)
                ''= String.Format("{0:###,###,###,###}", s)

                txt.Text = i.ToString("#,###")

                '#,### 
                txt.SelectionStart = txt.Text.Length

            Catch
            End Try
        End If

    End Sub
    Public Sub WarnaDGV(ByVal DGV As DataGridView)
        With DGV
            .RowsDefaultCellStyle.BackColor = Color.AliceBlue
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
        End With
    End Sub

    Function ValidDatePicker(CtlTgl As DateTimePicker) As Boolean
        ValidDatePicker = False
        With CtlTgl
            If Format(.Value, "MMyyyy") = Format(Periode, "MMyyyy") Then
                ValidDatePicker = True
            Else
                ValidDatePicker = False
                MsgBox("Tanggal Dan Periode Tidak Sesuai, Periksa Kembali Data Anda!", vbCritical, "Periode : " & Format(Periode, "MM/yyyy"))
                .Value = CDate(Format(.Value, "dd/") & Format(Periode, "MM/yyyy"))
            End If
        End With
    End Function

    Public Sub WarnaDGVPINK(ByVal DGV As DataGridView)
        With DGV

            .ColumnHeadersDefaultCellStyle.BackColor = Color.SlateBlue
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .RowsDefaultCellStyle.BackColor = Color.LavenderBlush
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
        End With
    End Sub


    Public Sub ClearComboBoxInBox(ByVal grb As System.Windows.Forms.GroupBox)
        For Each ctl As Control In grb.Controls
            If TypeOf ctl Is ComboBox Then
                CType(ctl, ComboBox).Text = String.Empty
            End If
        Next
    End Sub
    Public Sub WarnaDGVBLUE(ByVal DGV As DataGridView)
        With DGV

            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 57, 92)
            '.ColumnHeadersDefaultCellStyle.BackColor = Color.Red
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .RowsDefaultCellStyle.BackColor = Color.AliceBlue
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
            ' .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
        End With
    End Sub

    Public Sub EnabledTextBoxsplit(ByVal flag As Boolean, ByVal grb As SplitterPanel, Optional resurse As Boolean = True)
        For Each ctl As Control In grb.Controls
            If TypeOf ctl Is TextBox Then
                CType(ctl, TextBox).Enabled = flag
            End If
        Next

    End Sub

    Public Sub Enabledcomboboxsplit(ByVal flag As Boolean, ByVal grb As SplitterPanel, Optional resurse As Boolean = True)
        For Each ctl As Control In grb.Controls
            If TypeOf ctl Is ComboBox Then
                CType(ctl, ComboBox).Enabled = flag
            End If
        Next
    End Sub

End Class
