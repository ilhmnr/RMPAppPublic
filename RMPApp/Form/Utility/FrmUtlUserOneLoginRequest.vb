Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions

Public Class FrmUtlUserOneLoginRequest

    ' ── Property yang dibaca FrmUtlUser setelah ShowDialog ───────────────
    Public SelectedUsername As String = ""
    Public SelectedName As String = ""

    ' ── Struktur data dari API ────────────────────────────────────────────
    Private Structure PendingUser
        Dim Username As String
        Dim Name As String
        Dim EmployeeId As String
        Dim Remark As String
    End Structure

    Private _users As New List(Of PendingUser)

    ' ── Form Load ─────────────────────────────────────────────────────────
    Private Sub FrmUtlUserOneLoginRequest_Load(sender As Object, e As EventArgs) _
        Handles MyBase.Load
        SetupGrid()
        LoadData()
    End Sub

    ' ── Setup FlexGrid ────────────────────────────────────────────────────
    Private Sub SetupGrid()
        With C1FlexGrid1
            .AllowEditing = False
            .SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
            .HighLight = C1.Win.C1FlexGrid.HighLightEnum.Always

            .Styles.Fixed.BackColor = Color.FromArgb(179, 229, 252)
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)

            .Cols(0).Width = 40   ' No
            .Cols(1).Width = 200  ' Nama
            .Cols(2).Width = 130  ' Username
            .Cols(3).Width = -1   ' Remark

            .Cols(0).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
            .Cols(1).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
            .Cols(2).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
            .Cols(3).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter

            .Rows.Count = 1
        End With
    End Sub

    ' ── Load data dari OneLogin ───────────────────────────────────────────
    Private Sub LoadData()
        cmdPilih.Enabled = False
        CheckBox1.Text = "Memuat data..."

        Try
            _users = GetPendingUsers()

            C1FlexGrid1.Rows.Count = _users.Count + 1

            For i = 0 To _users.Count - 1
                C1FlexGrid1(i + 1, 0) = i + 1
                C1FlexGrid1(i + 1, 1) = _users(i).Name
                C1FlexGrid1(i + 1, 2) = _users(i).Username
                C1FlexGrid1(i + 1, 3) = If(_users(i).Remark, "-")
            Next

            C1FlexGrid1.AutoSizeCols()

            CheckBox1.Text = If(_users.Count = 0,
                "Tidak ada user yang menunggu pembuatan akun.",
                $"{_users.Count} user menunggu — pilih baris lalu klik Pilih.")

        Catch ex As Exception
            CheckBox1.Text = "Gagal memuat: " & ex.Message
            MsgBoxCustom.Show(ex.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
        End Try
    End Sub

    ' ── Row change ────────────────────────────────────────────────────────
    Private Sub C1FlexGrid1_RowColChange(sender As Object, e As EventArgs) _
        Handles C1FlexGrid1.RowColChange
        cmdPilih.Enabled = C1FlexGrid1.Row > 0
    End Sub

    ' ── Double click → langsung pilih ────────────────────────────────────
    Private Sub C1FlexGrid1_DoubleClick(sender As Object, e As EventArgs) _
        Handles C1FlexGrid1.DoubleClick
        If C1FlexGrid1.Row > 0 Then cmdPilih.PerformClick()
    End Sub

    ' ── Tombol Refresh ───────────────────────────────────────────────────
    Private Sub cmdRefresh_Click(sender As Object, e As EventArgs) Handles cmdRefresh.Click
        LoadData()
    End Sub

    ' ── Tombol Pilih → return data ke FrmUtlUser ──────────────────────────
    Private Sub cmdPilih_Click(sender As Object, e As EventArgs) Handles cmdPilih.Click
        Dim rowIdx = C1FlexGrid1.Row
        If rowIdx < 1 OrElse rowIdx > _users.Count Then Return

        SelectedUsername = _users(rowIdx - 1).Username
        SelectedName = _users(rowIdx - 1).Name
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    ' ── Tombol Tutup ─────────────────────────────────────────────────────
    Private Sub cmdTutup_Click(sender As Object, e As EventArgs) Handles cmdTutup.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    ' ══════════════════════════════════════════════════════════════════════
    '  ONELOGIN API
    ' ══════════════════════════════════════════════════════════════════════
    Private Function GetPendingUsers() As List(Of PendingUser)
        Dim result As New List(Of PendingUser)

        Dim body = "{""application_id"":" & APPLICATION_ID &
                   ",""client_secret"":""" & JsonEscape(CLIENT_SECRET) & """}"

        Dim req As HttpWebRequest = CType(
            WebRequest.Create(ONELOGIN_BASE_URL & "/api/apps/pending-users"), HttpWebRequest)
        req.Method = "POST"
        req.ContentType = "application/json"
        req.Accept = "application/json"
        req.Timeout = 15000

        Dim bytes = Encoding.UTF8.GetBytes(body)
        req.ContentLength = bytes.Length
        Using s = req.GetRequestStream() : s.Write(bytes, 0, bytes.Length) : End Using

        Using res As HttpWebResponse = CType(req.GetResponse(), HttpWebResponse)
            Using reader As New StreamReader(res.GetResponseStream(), Encoding.UTF8)
                Dim json = reader.ReadToEnd()
                Dim items = Regex.Matches(json, "\{([^{}]*)\}")
                For Each m As Match In items
                    Dim item = m.Value
                    result.Add(New PendingUser With {
                        .Username = ExtractJson(item, "username"),
                        .Name = ExtractJson(item, "name"),
                        .EmployeeId = ExtractJson(item, "employee_id"),
                        .Remark = ExtractJson(item, "remark")
                    })
                Next
            End Using
        End Using

        Return result
    End Function

    Private Function ExtractJson(json As String, key As String) As String
        If String.IsNullOrEmpty(json) Then Return Nothing
        Dim m = Regex.Match(json, """" & Regex.Escape(key) & """\s*:\s*""((?:[^""\\]|\\.)*)""")
        If Not m.Success Then Return Nothing
        Return m.Groups(1).Value.Replace("\""", """").Replace("\\", "\")
    End Function

    Private Function JsonEscape(v As String) As String
        If v Is Nothing Then Return ""
        Return v.Replace("\", "\\").Replace("""", "\""")
    End Function

End Class