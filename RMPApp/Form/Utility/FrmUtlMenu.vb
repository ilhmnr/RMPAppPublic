Imports System.Data.SqlClient

Public Class FrmUtlMenu

    Private dtMenu As DataTable

    Private Sub FrmUtlMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClsFlexGrid.ApplyStyle(fgMenu)
        btnBacaMenu.PerformClick()
    End Sub

    Private Sub btnBacaMenu_Click(sender As Object, e As EventArgs) Handles btnBacaMenu.Click
        fgMenu.Redraw = False
        fgMenu.Rows.Count = 1

        Dim no As Integer = 0

        For Each item As ToolStripMenuItem In FrmMain.MenuStrip1.Items
            TampilkanMenu(item, 1, no)
        Next

        fgMenu.AutoSizeCols()
        fgMenu.Redraw = True
    End Sub

    Private Sub TampilkanMenu(item As ToolStripMenuItem, level As Integer, ByRef no As Integer)
        no += 1

        Dim r As Integer = fgMenu.Rows.Count
        fgMenu.Rows.Add()

        fgMenu.Item(r, "No") = no
        fgMenu.Item(r, "Level") = level
        fgMenu.Item(r, "NamaMenu") =
            New String(" "c, (level - 1) * 8) & item.Text.Replace("&", "")

        fgMenu.Item(r, "NameTag") =
            If(item.Tag IsNot Nothing AndAlso item.Tag.ToString() <> "",
               item.Tag.ToString(),
               item.Name)

        For Each child As ToolStripItem In item.DropDownItems
            If TypeOf child Is ToolStripMenuItem Then
                TampilkanMenu(DirectCast(child, ToolStripMenuItem), level + 1, no)
            End If
        Next
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs)
        Dim r As Integer = fgMenu.Rows.Count
        fgMenu.Rows.Add()

        fgMenu.Item(r, 0) = r
        fgMenu.Item(r, 1) = 1
        fgMenu.Item(r, 2) = ""
        fgMenu.Item(r, 3) = ""

        fgMenu.AllowEditing = True
        fgMenu.Select(r, 2)
        fgMenu.StartEditing()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If fgMenu.Rows.Count <= 1 Then
            MsgBoxCustom.Show(
                "Tidak ada menu untuk disimpan.",
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Warning)
            Return
        End If

        Dim listTag As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        Dim levelSebelumnya As Integer = 0

        ' Validasi menu sebelum mengubah database.
        For r As Integer = 1 To fgMenu.Rows.Count - 1

            Dim level As Integer = Val(Convert.ToString(fgMenu.Item(r, "Level")))
            Dim nama As String = Convert.ToString(fgMenu.Item(r, "NamaMenu")).Trim()
            Dim tag As String = Convert.ToString(fgMenu.Item(r, "NameTag")).Trim()

            If nama = "" OrElse tag = "" Then
                MsgBoxCustom.Show(
                    "Nama menu dan NameTag tidak boleh kosong. Baris: " & r,
                    MsgBoxCustom.ButtonType.OK,
                    MsgBoxCustom.IconType.Warning)
                Return
            End If

            If level < 1 OrElse (r = 1 AndAlso level <> 1) OrElse
               (r > 1 AndAlso level > levelSebelumnya + 1) Then

                MsgBoxCustom.Show(
                    "Struktur level menu tidak valid pada baris: " & r,
                    MsgBoxCustom.ButtonType.OK,
                    MsgBoxCustom.IconType.Warning)
                Return
            End If

            If Not listTag.Add(tag) Then
                MsgBoxCustom.Show(
                    "NameTag duplikat ditemukan: " & tag,
                    MsgBoxCustom.ButtonType.OK,
                    MsgBoxCustom.IconType.Warning)
                Return
            End If

            levelSebelumnya = level
        Next

        If listTag.Count = 0 Then
            MsgBoxCustom.Show(
                "Tidak ada menu valid untuk disimpan.",
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Warning)
            Return
        End If

        Using cn As New SqlConnection(StrConnRMPApp)
            cn.Open()

            Using tr As SqlTransaction = cn.BeginTransaction()
                Try
                    Dim parentTags As New Dictionary(Of Integer, String)
                    Dim total As Integer = 0
                    Dim totalDelete As Integer = 0

                    ' INSERT atau UPDATE menu.
                    For r As Integer = 1 To fgMenu.Rows.Count - 1

                        Dim level As Integer = Val(Convert.ToString(fgMenu.Item(r, "Level")))
                        Dim nama As String = Convert.ToString(fgMenu.Item(r, "NamaMenu")).Trim()
                        Dim tag As String = Convert.ToString(fgMenu.Item(r, "NameTag")).Trim()

                        Dim parentTag As Object = DBNull.Value

                        If level > 1 Then
                            If Not parentTags.ContainsKey(level - 1) Then
                                Throw New Exception(
                                    "Menu induk tidak ditemukan untuk: " & tag)
                            End If

                            parentTag = parentTags(level - 1)
                        End If

                        Using cmd As New SqlCommand("
                        IF EXISTS (
                            SELECT 1
                            FROM dbo.tblUtlMenu
                            WHERE MenuTag = @Tag
                        )
                        BEGIN
                            UPDATE dbo.tblUtlMenu
                            SET MenuText = @Text,
                                ParentTag = @ParentTag,
                                MenuLevel = @Level,
                                SortOrder = @Sort,
                                UpdatedDate = GETDATE()
                            WHERE MenuTag = @Tag
                        END
                        ELSE
                        BEGIN
                            INSERT INTO dbo.tblUtlMenu
                                (MenuTag, MenuText, ParentTag, MenuLevel, SortOrder)
                            VALUES
                                (@Tag, @Text, @ParentTag, @Level, @Sort)
                        END", cn, tr)

                            cmd.Parameters.Add("@Tag", SqlDbType.VarChar, 150).Value = tag
                            cmd.Parameters.Add("@Text", SqlDbType.VarChar, 150).Value = nama
                            cmd.Parameters.Add("@ParentTag", SqlDbType.VarChar, 150).Value = parentTag
                            cmd.Parameters.Add("@Level", SqlDbType.Int).Value = level
                            cmd.Parameters.Add("@Sort", SqlDbType.Int).Value = r

                            cmd.ExecuteNonQuery()
                        End Using

                        ' Hapus referensi level sebelumnya atau yang lebih dalam.
                        Dim levelHapus As New List(Of Integer)

                        For Each k As Integer In parentTags.Keys.ToList()
                            If k >= level Then
                                levelHapus.Add(k)
                            End If
                        Next

                        For Each k As Integer In levelHapus
                            parentTags.Remove(k)
                        Next

                        parentTags(level) = tag

                        total += 1
                    Next

                    ' Ambil menu database dari level terdalam.
                    Dim menuDatabase As New List(Of KeyValuePair(Of String, Integer))

                    Using cmd As New SqlCommand("
                    SELECT MenuTag, MenuLevel
                    FROM dbo.tblUtlMenu
                    ORDER BY MenuLevel DESC", cn, tr)

                        Using rd As SqlDataReader = cmd.ExecuteReader()
                            While rd.Read()
                                menuDatabase.Add(
                                    New KeyValuePair(Of String, Integer)(
                                        rd("MenuTag").ToString(),
                                        Convert.ToInt32(rd("MenuLevel"))))
                            End While
                        End Using
                    End Using

                    ' Hapus menu yang tidak ditemukan pada daftar NameTag.
                    For Each itemMenu As KeyValuePair(Of String, Integer) In menuDatabase

                        If Not listTag.Contains(itemMenu.Key) Then

                            Using cmd As New SqlCommand("
                            DELETE FROM dbo.tblUtlMenu
                            WHERE MenuTag = @Tag", cn, tr)

                                cmd.Parameters.Add(
                                    "@Tag", SqlDbType.VarChar, 150).Value = itemMenu.Key

                                totalDelete += cmd.ExecuteNonQuery()
                            End Using

                        End If
                    Next

                    tr.Commit()

                    MsgBoxCustom.Show(
                        "Simpan menu berhasil." & vbCrLf &
                        "Total menu tersimpan: " & total.ToString() & vbCrLf &
                        "Total menu dihapus: " & totalDelete.ToString(),
                        MsgBoxCustom.ButtonType.OK,
                        MsgBoxCustom.IconType.Information)

                Catch ex As Exception

                    Try
                        tr.Rollback()
                    Catch
                    End Try

                    MsgBoxCustom.Show(
                        "Terjadi kesalahan saat menyimpan menu: " & ex.Message,
                        MsgBoxCustom.ButtonType.OK,
                        MsgBoxCustom.IconType.Error)
                End Try
            End Using
        End Using

    End Sub


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

End Class