Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmUtlAksesPancang

    Private dtGroup As New DataTable
    Private dtPancang As New DataTable
    Private dtUser As New DataTable
    Private daftarGroup As New DataTable

    Private modeEdit As Boolean = False
    Private modeTambah As Boolean = False
    Private loading As Boolean = False
    Private groupIDTerpilih As Integer = 0

    Private Sub FrmUtlAksesPancang_Load(
        sender As Object, e As EventArgs
    ) Handles MyBase.Load
        ClsFlexGrid.ApplyStyle(fgGroup)
        ClsFlexGrid.ApplyStyle(fgPancang)
        ClsFlexGrid.ApplyStyle(fgUser)

        AturGrid()
        AturMode(False)
        TampilSemua()
    End Sub

    Private Sub AturGrid()

        With fgGroup
            .AllowEditing = False
            .SelectionMode = SelectionModeEnum.Row
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
        End With

        With fgPancang
            .AllowEditing = True
            .SelectionMode = SelectionModeEnum.Cell
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
        End With

        With fgUser
            .AllowEditing = True
            .SelectionMode = SelectionModeEnum.Cell
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
        End With

    End Sub

    Private Function AmbilData(sql As String) As DataTable

        Dim dt As New DataTable

        Using da As New SqlDataAdapter(sql, StrConnRMPApp)
            da.Fill(dt)
        End Using

        Return dt

    End Function

    Private Function EscapeSql(nilai As String) As String
        Return nilai.Replace("'", "''")
    End Function

    Private Function UserLogin() As String
        Return EscapeSql(Convert.ToString(ClsSession.UserID))
    End Function

    Private Sub TampilGroup()

        Try
            loading = True

            Dim sql As String =
                "SELECT g.GroupID, g.GroupName, " &
                "(SELECT COUNT(*) FROM dbo.tblUtlPancangGroup p " &
                " WHERE p.GroupID = g.GroupID) AS JumlahPancang " &
                "FROM dbo.tblUtlMstPancangGroup g " &
                "WHERE g.IsActive = 1 " &
                "ORDER BY g.GroupName"

            dtGroup = AmbilData(sql)
            fgGroup.DataSource = dtGroup

            If fgGroup.Cols.Contains("GroupID") Then
                fgGroup.Cols("GroupID").Visible = False
            End If

            If fgGroup.Cols.Contains("GroupName") Then
                fgGroup.Cols("GroupName").Caption = "Nama Group"
                fgGroup.Cols("GroupName").Width = 180
            End If

            If fgGroup.Cols.Contains("JumlahPancang") Then
                fgGroup.Cols("JumlahPancang").Caption = "Jumlah Pancang"
                fgGroup.Cols("JumlahPancang").Width = 100
            End If

            If fgGroup.Rows.Count > 1 Then
                fgGroup.Row = 1
                PilihGroup()
            Else
                groupIDTerpilih = 0
                TampilPancang()
                TampilUser()
            End If

        Catch ex As Exception
            MessageBox.Show(
                "Gagal menampilkan group: " & ex.Message,
                "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            loading = False
        End Try

    End Sub

    Private Sub PilihGroup()

        If fgGroup.Row < fgGroup.Rows.Fixed OrElse
       fgGroup.Row >= fgGroup.Rows.Count Then Return

        If IsDBNull(fgGroup.Item(fgGroup.Row, "GroupID")) Then Return

        groupIDTerpilih = CInt(fgGroup.Item(fgGroup.Row, "GroupID"))

        TxtNamaGroup.Text = Convert.ToString(fgGroup.Item(fgGroup.Row, "GroupName"))

        AturMode(False)

        TampilPancang()
        TampilUser()

    End Sub

    Private Sub fgGroup_SelChange(
        sender As Object, e As EventArgs
    ) Handles fgGroup.SelChange

        If loading OrElse modeEdit Then Return
        PilihGroup()

    End Sub

    Private Sub TampilPancang()

        Try
            loading = True

            Dim cari As String = EscapeSql(TxtCariPancang.Text.Trim())

            Dim sql As String =
                "SELECT p.IDPancang, p.Pancang " &
                "FROM dbo.Android_tblMstPancang p " &
                "WHERE ISNULL(p.Pancang, '') LIKE '%" & cari & "%' " &
                "ORDER BY p.Pancang"

            Dim dtDasar As DataTable = AmbilData(sql)

            dtPancang = New DataTable
            dtPancang.Columns.Add("IDPancang", GetType(Integer))
            dtPancang.Columns.Add("Pancang", GetType(String))

            For Each rowGroup As DataRow In daftarGroup.Rows
                Dim kolom As String = NamaKolomGroup(CInt(rowGroup("GroupID")))
                If Not dtPancang.Columns.Contains(kolom) Then
                    dtPancang.Columns.Add(kolom, GetType(Boolean))
                End If
            Next

            Dim sqlAkses As String =
                "SELECT IDPancang, GroupID " &
                "FROM dbo.tblUtlPancangGroup"

            Dim dtAkses As DataTable = AmbilData(sqlAkses)

            For Each rowPancang As DataRow In dtDasar.Rows

                Dim rowBaru As DataRow = dtPancang.NewRow()
                rowBaru("IDPancang") = CInt(rowPancang("IDPancang"))
                rowBaru("Pancang") = Convert.ToString(rowPancang("Pancang"))

                For Each rowGroup As DataRow In daftarGroup.Rows
                    Dim idGroup As Integer = CInt(rowGroup("GroupID"))
                    Dim kolom As String = NamaKolomGroup(idGroup)

                    rowBaru(kolom) = dtAkses.AsEnumerable().Any(
                        Function(r) CInt(r("IDPancang")) = CInt(rowPancang("IDPancang")) AndAlso
                                    CInt(r("GroupID")) = idGroup)
                Next

                dtPancang.Rows.Add(rowBaru)

            Next

            fgPancang.DataSource = dtPancang

            If fgPancang.Cols.Contains("IDPancang") Then
                fgPancang.Cols("IDPancang").Visible = False
            End If

            If fgPancang.Cols.Contains("Pancang") Then
                fgPancang.Cols("Pancang").Caption = "Pancang"
                fgPancang.Cols("Pancang").Width = 180
            End If

            AturKolomGroup(fgPancang)

        Catch ex As Exception
            MessageBox.Show(
                "Gagal menampilkan pancang: " & ex.Message,
                "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            loading = False
        End Try

    End Sub

    Private Sub TampilUser()

        Try
            loading = True

            Dim cari As String = EscapeSql(TxtCariUser.Text.Trim())

            Dim sql As String =
                "SELECT u.UserID, u.UserName " &
                "FROM dbo.MstUserLogin u " &
                "INNER JOIN dbo.tblUtlRole r ON r.RoleID = u.RoleID " &
                "WHERE r.RoleName in ('Admin Nota','Main Admin Nota') " &
                "AND r.IsActive = 1 " &
                "AND (ISNULL(u.UserID, '') LIKE '%" & cari & "%' " &
                "OR ISNULL(u.UserName, '') LIKE '%" & cari & "%') " &
                "ORDER BY u.UserName"

            Dim dtDasar As DataTable = AmbilData(sql)

            dtUser = New DataTable
            dtUser.Columns.Add("UserID", GetType(String))
            dtUser.Columns.Add("UserName", GetType(String))

            For Each rowGroup As DataRow In daftarGroup.Rows
                Dim kolom As String = NamaKolomGroup(CInt(rowGroup("GroupID")))
                If Not dtUser.Columns.Contains(kolom) Then
                    dtUser.Columns.Add(kolom, GetType(Boolean))
                End If
            Next

            Dim dtAkses As DataTable =
                AmbilData("SELECT UserID, GroupID FROM dbo.tblUtlUserPancangGroup")

            For Each rowUser As DataRow In dtDasar.Rows

                Dim rowBaru As DataRow = dtUser.NewRow()
                rowBaru("UserID") = Convert.ToString(rowUser("UserID"))
                rowBaru("UserName") = Convert.ToString(rowUser("UserName"))

                For Each rowGroup As DataRow In daftarGroup.Rows
                    Dim idGroup As Integer = CInt(rowGroup("GroupID"))
                    Dim kolom As String = NamaKolomGroup(idGroup)
                    Dim userID As String = Convert.ToString(rowUser("UserID"))

                    rowBaru(kolom) = dtAkses.AsEnumerable().Any(
                        Function(r) Convert.ToString(r("UserID")) = userID AndAlso
                                    CInt(r("GroupID")) = idGroup)
                Next

                dtUser.Rows.Add(rowBaru)

            Next

            fgUser.DataSource = dtUser

            If fgUser.Cols.Contains("UserID") Then
                fgUser.Cols("UserID").Visible = False
            End If

            If fgUser.Cols.Contains("UserName") Then
                fgUser.Cols("UserName").Caption = "Nama User"
                fgUser.Cols("UserName").Width = 160
            End If

            AturKolomGroup(fgUser)

        Catch ex As Exception
            MessageBox.Show(
                "Gagal menampilkan user: " & ex.Message,
                "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            loading = False
        End Try

    End Sub

    Private Sub MuatDaftarGroup()

        daftarGroup = AmbilData(
            "SELECT GroupID, GroupName " &
            "FROM dbo.tblUtlMstPancangGroup " &
            "WHERE IsActive = 1 ORDER BY GroupName")

    End Sub

    Private Function NamaKolomGroup(idGroup As Integer) As String
        Return "G_" & idGroup.ToString()
    End Function

    Private Sub AturKolomGroup(grid As C1FlexGrid)

        For Each rowGroup As DataRow In daftarGroup.Rows

            Dim idGroup As Integer = CInt(rowGroup("GroupID"))
            Dim kolom As String = NamaKolomGroup(idGroup)

            If grid.Cols.Contains(kolom) Then
                With grid.Cols(kolom)
                    .Caption = Convert.ToString(rowGroup("GroupName"))
                    .DataType = GetType(Boolean)
                    .AllowEditing = True
                    .Width = 90
                    .TextAlign = TextAlignEnum.CenterCenter
                End With
            End If

        Next

    End Sub

    Private Sub TampilSemua()

        MuatDaftarGroup()
        TampilGroup()
        TampilPancang()
        TampilUser()

    End Sub

    Private Sub AturMode(isEdit As Boolean)

        modeEdit = isEdit

        TxtNamaGroup.ReadOnly = Not isEdit

        btnAddGroup.Enabled = Not isEdit
        btnEditGroup.Enabled = Not isEdit AndAlso groupIDTerpilih > 0
        btnDeleteGroup.Enabled = Not isEdit AndAlso groupIDTerpilih > 0
        btnSaveGroup.Enabled = isEdit
        btnCancelGroup.Enabled = isEdit

    End Sub

    Private Sub btnAddGroup_Click(
        sender As Object, e As EventArgs
    ) Handles btnAddGroup.Click

        modeTambah = True
        groupIDTerpilih = 0
        TxtNamaGroup.Clear()
        AturMode(True)
        TxtNamaGroup.Focus()

    End Sub

    Private Sub btnEditGroup_Click(
        sender As Object, e As EventArgs
    ) Handles btnEditGroup.Click

        If groupIDTerpilih = 0 Then Return

        modeTambah = False
        AturMode(True)
        TxtNamaGroup.Focus()

    End Sub

    Private Sub btnSaveGroup_Click(
        sender As Object, e As EventArgs
    ) Handles btnSaveGroup.Click

        Dim nama As String = TxtNamaGroup.Text.Trim()

        If nama = "" Then
            MessageBox.Show("Nama group harus diisi.")
            TxtNamaGroup.Focus()
            Return
        End If

        Try
            Dim sql As String

            If modeTambah Then

                sql =
                    "INSERT INTO dbo.tblUtlMstPancangGroup " &
                    "(GroupName, IsActive, CreatedBy, CreatedDate) VALUES (" &
                    "'" & EscapeSql(nama) & "', 1, '" & UserLogin() & "', GETDATE())"

            Else

                sql =
                    "UPDATE dbo.tblUtlMstPancangGroup SET " &
                    "GroupName = '" & EscapeSql(nama) & "', " &
                    "UpdatedBy = '" & UserLogin() & "', " &
                    "UpdatedDate = GETDATE() " &
                    "WHERE GroupID = " & groupIDTerpilih

            End If

            DB.ExecuteNonQuery(StrConnRMPApp, sql)

            modeTambah = False
            AturMode(False)
            TampilSemua()

            MessageBox.Show("Data group berhasil disimpan.")

        Catch ex As Exception
            MessageBox.Show(
                "Gagal menyimpan group: " & ex.Message,
                "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnCancelGroup_Click(
        sender As Object, e As EventArgs
    ) Handles btnCancelGroup.Click

        modeTambah = False
        AturMode(False)

        If groupIDTerpilih > 0 Then
            PilihGroup()
        Else
            TxtNamaGroup.Clear()
        End If

    End Sub

    Private Sub btnDeleteGroup_Click(
        sender As Object, e As EventArgs
    ) Handles btnDeleteGroup.Click

        If groupIDTerpilih = 0 Then Return

        If MessageBox.Show(
            "Hapus group ini beserta akses pancang dan user-nya?",
            "Konfirmasi", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question) <> DialogResult.Yes Then Return

        Try
            DB.ExecuteNonQuery(
                StrConnRMPApp,
                "DELETE FROM dbo.tblUtlPancangGroup WHERE GroupID = " &
                groupIDTerpilih)

            DB.ExecuteNonQuery(
                StrConnRMPApp,
                "DELETE FROM dbo.tblUtlUserPancangGroup WHERE GroupID = " &
                groupIDTerpilih)

            DB.ExecuteNonQuery(
                StrConnRMPApp,
                "DELETE FROM dbo.tblUtlMstPancangGroup WHERE GroupID = " &
                groupIDTerpilih)

            groupIDTerpilih = 0
            TxtNamaGroup.Clear()
            TampilSemua()

        Catch ex As Exception
            MessageBox.Show(
                "Gagal menghapus group: " & ex.Message,
                "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub fgPancang_AfterEdit(
        sender As Object, e As RowColEventArgs
    ) Handles fgPancang.AfterEdit

        If loading OrElse e.Row < fgPancang.Rows.Fixed Then Return

        Dim namaKolom As String = fgPancang.Cols(e.Col).Name

        If Not namaKolom.StartsWith("G_") Then Return

        Try
            Dim idPancang As Integer =
                CInt(fgPancang.Item(e.Row, "IDPancang"))

            Dim idGroup As Integer =
                Integer.Parse(namaKolom.Substring(2))

            Dim dicentang As Boolean =
                Convert.ToBoolean(fgPancang.Item(e.Row, e.Col))

            If dicentang Then

                DB.ExecuteNonQuery(
                    StrConnRMPApp,
                    "DELETE FROM dbo.tblUtlPancangGroup " &
                    "WHERE IDPancang = " & idPancang)

                DB.ExecuteNonQuery(
                    StrConnRMPApp,
                    "INSERT INTO dbo.tblUtlPancangGroup " &
                    "(IDPancang, GroupID) VALUES (" &
                    idPancang & ", " & idGroup & ")")

            Else

                DB.ExecuteNonQuery(
                    StrConnRMPApp,
                    "DELETE FROM dbo.tblUtlPancangGroup " &
                    "WHERE IDPancang = " & idPancang &
                    " AND GroupID = " & idGroup)

            End If

            TampilGroup()

        Catch ex As Exception
            MessageBox.Show(
                "Gagal menyimpan akses pancang: " & ex.Message,
                "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TampilPancang()
        End Try

    End Sub

    Private Sub fgUser_AfterEdit(
        sender As Object, e As RowColEventArgs
    ) Handles fgUser.AfterEdit

        If loading OrElse e.Row < fgUser.Rows.Fixed Then Return

        Dim namaKolom As String = fgUser.Cols(e.Col).Name

        If Not namaKolom.StartsWith("G_") Then Return

        Try
            Dim userID As String =
                EscapeSql(Convert.ToString(fgUser.Item(e.Row, "UserID")))

            Dim idGroup As Integer =
                Integer.Parse(namaKolom.Substring(2))

            Dim dicentang As Boolean =
                Convert.ToBoolean(fgUser.Item(e.Row, e.Col))

            If dicentang Then

                DB.ExecuteNonQuery(
                    StrConnRMPApp,
                    "IF NOT EXISTS (" &
                    "SELECT 1 FROM dbo.tblUtlUserPancangGroup " &
                    "WHERE UserID = '" & userID & "' " &
                    "AND GroupID = " & idGroup & ") " &
                    "INSERT INTO dbo.tblUtlUserPancangGroup " &
                    "(UserID, GroupID) VALUES ('" & userID & "', " &
                    idGroup & ")")

            Else

                DB.ExecuteNonQuery(
                    StrConnRMPApp,
                    "DELETE FROM dbo.tblUtlUserPancangGroup " &
                    "WHERE UserID = '" & userID & "' " &
                    "AND GroupID = " & idGroup)

            End If

        Catch ex As Exception
            MessageBox.Show(
                "Gagal menyimpan akses user: " & ex.Message,
                "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TampilUser()
        End Try

    End Sub

    Private Sub TxtCariPancang_TextChanged(
        sender As Object, e As EventArgs
    ) Handles TxtCariPancang.TextChanged

        If Not loading Then TampilPancang()

    End Sub

    Private Sub TxtCariUser_TextChanged(
        sender As Object, e As EventArgs
    ) Handles TxtCariUser.TextChanged

        If Not loading Then TampilUser()

    End Sub

    Private Sub btnExit_Click(
        sender As Object, e As EventArgs
    ) Handles btnExit.Click

        Me.Close()

    End Sub

    Private Sub FrmUtlAksesPancang_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        ' ukurangan setengah layar
        Panel3.Width = Me.Width / 2 - 10
    End Sub
End Class