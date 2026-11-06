Imports System.Globalization
Imports clsVar = RMPApp.ClsVariable

Public Module Modul_RMP
    Public AT As String = "RMPApplication ©" & Format(Year(Now))
    Public Time As String = Format(Now, "dd-MM-yyyy")
    Public Day As String = DateTime.Now.DayOfWeek.ToString()

    Public DB As New ClsDatabaseConnection
    Public Func As New ClsFunction
    Public Draw As New ClsDrawingHelper
    Public Combo As New ClsComboBoxHelper
    Public ClsTerbilang As New ClsTerbilang
    Public Clsfg As New ClsFlexGrid
    Public HargaBB As ClsHargaBahanBakuService
    Public UI As New ClsFormControlHelper
    Public Security As New ClsSecurityHelper
    Public Gen As New ClsGeneral
    Public cls_computeraccess As clsVar.ComputerAccess
    Public cls_DBLogin As clsVar.AppDBLogin
    Public cls_UserLogin As New clsVar.UserLogin
    Public cls_VarProgram As New clsVar.Variable
    Public cls_VarToast As New clsVar.Toast
    Public cls_Webdav As New ClsWebDAV.WebDavVariable

#Region "Format Number"
    Public Enum NumberType
        IntegerNumber
        DecimalNumber
    End Enum

    Private ReadOnly _culture As CultureInfo =
        CultureInfo.GetCultureInfo("id-ID")

    Private Class NumberSettings
        Public Property Type As NumberType
        Public Property Precision As Integer
        Public Property AllowNegative As Boolean
    End Class

    Private ReadOnly _settings As New Dictionary(Of TextBox, NumberSettings)

    Private ReadOnly _formatting As New HashSet(Of TextBox)

    Public Sub SetNumberOnly(
        txt As TextBox,
        Optional Type As NumberType = NumberType.IntegerNumber,
        Optional Precision As Integer = 0,
        Optional AllowNegative As Boolean = False,
        Optional MaxLength As Integer = 0
    )

        If txt Is Nothing Then Exit Sub

        If MaxLength > 0 Then
            txt.MaxLength = MaxLength
        End If

        _settings(txt) = New NumberSettings With {
            .Type = Type,
            .Precision = Precision,
            .AllowNegative = AllowNegative
        }

        RemoveHandler txt.KeyPress, AddressOf NumberOnly_KeyPress
        RemoveHandler txt.TextChanged, AddressOf NumberOnly_TextChanged
        RemoveHandler txt.Leave, AddressOf NumberOnly_Leave

        AddHandler txt.KeyPress, AddressOf NumberOnly_KeyPress
        AddHandler txt.TextChanged, AddressOf NumberOnly_TextChanged
        AddHandler txt.Leave, AddressOf NumberOnly_Leave

    End Sub

    Private Sub NumberOnly_KeyPress(
        sender As Object,
        e As KeyPressEventArgs
    )

        Dim txt As TextBox = DirectCast(sender, TextBox)

        If Not _settings.ContainsKey(txt) Then Exit Sub

        Dim settings = _settings(txt)

        If Char.IsControl(e.KeyChar) Then Exit Sub

        If Char.IsDigit(e.KeyChar) Then Exit Sub

        If settings.Type = NumberType.DecimalNumber AndAlso
           e.KeyChar = ","c Then

            If Not txt.Text.Contains(",") Then Exit Sub

        End If

        If settings.AllowNegative AndAlso e.KeyChar = "-"c Then

            If txt.SelectionStart = 0 AndAlso
               Not txt.Text.Contains("-") Then

                Exit Sub
            End If

        End If

        e.Handled = True

    End Sub

    Private Sub NumberOnly_TextChanged(
        sender As Object,
        e As EventArgs
    )

        Dim txt As TextBox = DirectCast(sender, TextBox)

        If _formatting.Contains(txt) Then Exit Sub
        If Not _settings.ContainsKey(txt) Then Exit Sub

        If String.IsNullOrWhiteSpace(txt.Text) Then
            _formatting.Add(txt)

            Try
                If _settings(txt).Type = NumberType.DecimalNumber Then
                    txt.Text = "0," & New String("0"c, _settings(txt).Precision)
                Else
                    txt.Text = "0"
                End If

                txt.SelectionStart = txt.Text.Length
            Finally
                _formatting.Remove(txt)
            End Try

            Exit Sub
        End If

        Dim settings = _settings(txt)

        'Simpan posisi kursor
        Dim oldText As String = txt.Text
        Dim oldSelection As Integer = txt.SelectionStart

        'Hapus pemisah ribuan
        Dim raw As String = oldText.Replace(".", "")

        Dim value As Decimal

        If Not Decimal.TryParse(
            raw,
            NumberStyles.Number,
            _culture,
            value
        ) Then Exit Sub

        If Not settings.AllowNegative AndAlso value < 0 Then
            Exit Sub
        End If

        Dim formatted As String

        If settings.Type = NumberType.IntegerNumber Then

            formatted = value.ToString("N0", _culture)

        Else

            formatted = value.ToString(
                "N" & settings.Precision,
                _culture
            )

        End If

        If formatted = oldText Then Exit Sub

        _formatting.Add(txt)

        Try

            txt.Text = formatted

            'Pertahankan posisi kursor
            Dim newSelection As Integer =
                oldSelection + (formatted.Length - oldText.Length)

            txt.SelectionStart = Math.Max(
                0,
                Math.Min(newSelection, formatted.Length)
            )

        Finally

            _formatting.Remove(txt)

        End Try

    End Sub

    Private Sub NumberOnly_Leave(
        sender As Object,
        e As EventArgs
    )

        Dim txt As TextBox = DirectCast(sender, TextBox)

        If Not _settings.ContainsKey(txt) Then Exit Sub

        If String.IsNullOrWhiteSpace(txt.Text) Then
            txt.Text = "0"
            Exit Sub
        End If

        Dim settings = _settings(txt)

        Dim raw As String = txt.Text.Replace(".", "")

        Dim value As Decimal

        If Not Decimal.TryParse(
            raw,
            NumberStyles.Number,
            _culture,
            value
        ) Then

            txt.Text = ""
            Exit Sub

        End If

        If Not settings.AllowNegative AndAlso value < 0 Then
            txt.Text = ""
            Exit Sub
        End If

        If settings.Type = NumberType.IntegerNumber Then

            txt.Text = value.ToString("N0", _culture)

        Else

            txt.Text = value.ToString(
                "N" & settings.Precision,
                _culture
            )

        End If

    End Sub
#End Region

End Module
