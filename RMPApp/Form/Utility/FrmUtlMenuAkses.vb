Imports System.Data
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmUtlMenuAkses

    Private RoleID As Integer = 0
    Private IsLoading As Boolean = False
    Private IsUpdating As Boolean = False

    '==========================================================
    ' FORM LOAD
    '==========================================================
    Private Sub FrmUtlMenuAkses_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClsFlexGrid.ApplyStyle(fgRole)
        ClsFlexGrid.ApplyStyle(fgMenu)

        TampilkanRole()
    End Sub

    '==========================================================
    ' TAMPILKAN ROLE
    '==========================================================
    Private Sub TampilkanRole()
        Dim No As Integer = 1

        Try
            Dim sql As String =
                "SELECT RoleID, RoleCode, RoleName, IsActive " &
                "FROM dbo.tblUtlRole " &
                "ORDER BY RoleCode"

            Using cn As New SqlConnection(StrConnRMPApp)
                Using cmd As New SqlCommand(sql, cn)
                    cn.Open()

                    Using rd As SqlDataReader = cmd.ExecuteReader()
                        IsLoading = True
                        fgRole.Rows.Count = fgRole.Rows.Fixed

                        While rd.Read()
                            Dim r As Integer = fgRole.Rows.Count
                            fgRole.Rows.Count += 1

                            fgRole(r, "No") = No
                            fgRole(r, "RoleID") = CInt(rd("RoleID"))
                            fgRole(r, "RoleCode") = rd("RoleCode").ToString()
                            fgRole(r, "RoleName") = rd("RoleName").ToString()
                            fgRole(r, "IsActive") = CBool(rd("IsActive"))

                            No += 1
                        End While

                        fgRole.AutoSizeCols()
                    End Using
                End Using
            End Using

            IsLoading = False

            If fgRole.Rows.Count > fgRole.Rows.Fixed Then
                fgRole.Row = fgRole.Rows.Fixed
                MuatMenuAkses()
            Else
                RoleID = 0
                fgMenu.Rows.Count = fgMenu.Rows.Fixed
            End If

        Catch ex As Exception
            IsLoading = False

            MsgBoxCustom.Show(
                "Gagal menampilkan role: " & ex.Message,
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Error)
        End Try
    End Sub

    '==========================================================
    ' ROLE DIPILIH
    '==========================================================
    Private Sub fgRole_RowColChange(
        sender As Object,
        e As EventArgs
    ) Handles fgRole.RowColChange

        If IsLoading Then Exit Sub
        If fgRole.Row < fgRole.Rows.Fixed Then Exit Sub
        If fgRole.Rows.Count <= fgRole.Rows.Fixed Then Exit Sub

        MuatMenuAkses()
    End Sub

    '==========================================================
    ' MUAT MENU BERDASARKAN ROLE
    '==========================================================
    Private Sub MuatMenuAkses()
        If fgRole.Row < fgRole.Rows.Fixed Then Exit Sub
        If fgRole.Rows.Count <= fgRole.Rows.Fixed Then Exit Sub

        If fgRole(fgRole.Row, "RoleID") Is Nothing Then Exit Sub

        RoleID = CInt(fgRole(fgRole.Row, "RoleID"))

        Dim No As Integer = 1

        Try
            Dim sql As String =
                "SELECT M.MenuID, M.MenuText, M.MenuLevel, " &
                "ISNULL(RM.IsAllowed, 0) AS IsAllowed, " &
                "ISNULL(RM.CanAdd, 0) AS CanAdd, " &
                "ISNULL(RM.CanSave, 0) AS CanSave, " &
                "ISNULL(RM.CanEdit, 0) AS CanEdit, " &
                "ISNULL(RM.CanDelete, 0) AS CanDelete " &
                "FROM dbo.tblUtlMenu M " &
                "LEFT JOIN dbo.tblUtlRoleMenu RM " &
                "ON M.MenuID = RM.MenuID AND RM.RoleID = @RoleID " &
                "ORDER BY M.SortOrder, M.MenuLevel, M.MenuText"

            Using cn As New SqlConnection(StrConnRMPApp)
                Using cmd As New SqlCommand(sql, cn)
                    cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = RoleID
                    cn.Open()

                    Using rd As SqlDataReader = cmd.ExecuteReader()
                        IsLoading = True
                        fgMenu.Rows.Count = fgMenu.Rows.Fixed

                        While rd.Read()
                            Dim r As Integer = fgMenu.Rows.Count
                            fgMenu.Rows.Count += 1

                            Dim level As Integer = CInt(rd("MenuLevel"))

                            fgMenu(r, "No") = No
                            fgMenu(r, "MenuID") = CInt(rd("MenuID"))
                            fgMenu(r, "Level") = level
                            fgMenu(r, "MenuText") =
                                New String(" "c, Math.Max(0, level - 1) * 8) &
                                rd("MenuText").ToString().Trim()

                            fgMenu(r, "IsAllowed") = CBool(rd("IsAllowed"))
                            fgMenu(r, "CanAdd") = CBool(rd("CanAdd"))
                            fgMenu(r, "CanSave") = CBool(rd("CanSave"))
                            fgMenu(r, "CanEdit") = CBool(rd("CanEdit"))
                            fgMenu(r, "CanDelete") = CBool(rd("CanDelete"))

                            No += 1
                        End While

                        fgMenu.AutoSizeCols()
                    End Using
                End Using
            End Using

            IsLoading = False

        Catch ex As Exception
            IsLoading = False

            MsgBoxCustom.Show(
                "Gagal menampilkan akses menu: " & ex.Message,
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Error)
        End Try
    End Sub

    '==========================================================
    ' VALIDASI CHECKLIST
    '==========================================================

    Private Sub fgMenu_AfterEdit(
    sender As Object,
    e As RowColEventArgs
) Handles fgMenu.AfterEdit

        If IsLoading OrElse IsUpdating Then Exit Sub
        If e.Row < fgMenu.Rows.Fixed Then Exit Sub

        Dim namaKolom As String = fgMenu.Cols(e.Col).Name

        If namaKolom = "IsAllowed" Then
            If Not CBool(fgMenu(e.Row, "IsAllowed")) Then
                fgMenu(e.Row, "CanAdd") = False
                fgMenu(e.Row, "CanSave") = False
                fgMenu(e.Row, "CanEdit") = False
                fgMenu(e.Row, "CanDelete") = False
            End If

        ElseIf namaKolom = "CanAdd" OrElse
           namaKolom = "CanSave" OrElse
           namaKolom = "CanEdit" OrElse
           namaKolom = "CanDelete" Then

            If CBool(fgMenu(e.Row, e.Col)) Then
                fgMenu(e.Row, "IsAllowed") = True
            End If
        End If

        SimpanAksesCell(e.Row)
    End Sub


    Private Sub SimpanAksesCell(row As Integer)
        If RoleID <= 0 Then Exit Sub

        Try
            IsUpdating = True

            Dim sql As String =
            "IF EXISTS (" &
            "SELECT 1 FROM dbo.tblUtlRoleMenu " &
            "WHERE RoleID = @RoleID AND MenuID = @MenuID) " &
            "BEGIN " &
            "UPDATE dbo.tblUtlRoleMenu SET " &
            "IsAllowed = @IsAllowed, " &
            "CanAdd = @CanAdd, " &
            "CanSave = @CanSave, " &
            "CanEdit = @CanEdit, " &
            "CanDelete = @CanDelete " &
            "WHERE RoleID = @RoleID AND MenuID = @MenuID " &
            "END " &
            "ELSE " &
            "BEGIN " &
            "INSERT INTO dbo.tblUtlRoleMenu " &
            "(RoleID, MenuID, IsAllowed, CanAdd, CanSave, CanEdit, CanDelete) " &
            "VALUES " &
            "(@RoleID, @MenuID, @IsAllowed, @CanAdd, @CanSave, @CanEdit, @CanDelete) " &
            "END"

            Dim akses As Boolean = CBool(fgMenu(row, "IsAllowed"))

            Using cn As New SqlConnection(StrConnRMPApp)
                Using cmd As New SqlCommand(sql, cn)

                    cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = RoleID
                    cmd.Parameters.Add("@MenuID", SqlDbType.Int).Value =
                    CInt(fgMenu(row, "MenuID"))

                    cmd.Parameters.Add("@IsAllowed", SqlDbType.Bit).Value = akses
                    cmd.Parameters.Add("@CanAdd", SqlDbType.Bit).Value =
                    akses AndAlso CBool(fgMenu(row, "CanAdd"))
                    cmd.Parameters.Add("@CanSave", SqlDbType.Bit).Value =
                    akses AndAlso CBool(fgMenu(row, "CanSave"))
                    cmd.Parameters.Add("@CanEdit", SqlDbType.Bit).Value =
                    akses AndAlso CBool(fgMenu(row, "CanEdit"))
                    cmd.Parameters.Add("@CanDelete", SqlDbType.Bit).Value =
                    akses AndAlso CBool(fgMenu(row, "CanDelete"))

                    cn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception
            MsgBoxCustom.Show(
            "Gagal menyimpan akses menu: " & ex.Message,
            MsgBoxCustom.ButtonType.OK,
            MsgBoxCustom.IconType.Error)
        Finally
            IsUpdating = False
        End Try
    End Sub


    '==========================================================
    ' SIMPAN AKSES MENU
    '==========================================================
    Private Sub btnSave_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnSave.Click

        If RoleID <= 0 Then
            MsgBoxCustom.Show(
                "Pilih role terlebih dahulu.",
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Warning)
            Exit Sub
        End If

        Try
            fgMenu.FinishEditing()

            Using cn As New SqlConnection(StrConnRMPApp)
                cn.Open()

                Using tr As SqlTransaction = cn.BeginTransaction()
                    Try
                        Dim sqlDelete As String =
                            "DELETE FROM dbo.tblUtlRoleMenu WHERE RoleID = @RoleID"

                        Using cmd As New SqlCommand(sqlDelete, cn, tr)
                            cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = RoleID
                            cmd.ExecuteNonQuery()
                        End Using

                        Dim sqlInsert As String =
                            "INSERT INTO dbo.tblUtlRoleMenu " &
                            "(RoleID, MenuID, IsAllowed, CanAdd, CanSave, CanEdit, CanDelete) " &
                            "VALUES (@RoleID, @MenuID, @IsAllowed, @CanAdd, " &
                            "@CanSave, @CanEdit, @CanDelete)"

                        For r As Integer = fgMenu.Rows.Fixed To fgMenu.Rows.Count - 1
                            Using cmd As New SqlCommand(sqlInsert, cn, tr)
                                Dim menuID As Integer = CInt(fgMenu(r, "MenuID"))
                                Dim akses As Boolean = CBool(fgMenu(r, "IsAllowed"))

                                cmd.Parameters.Add("@RoleID", SqlDbType.Int).Value = RoleID
                                cmd.Parameters.Add("@MenuID", SqlDbType.Int).Value = menuID
                                cmd.Parameters.Add("@IsAllowed", SqlDbType.Bit).Value = akses
                                cmd.Parameters.Add("@CanAdd", SqlDbType.Bit).Value =
                                    akses AndAlso CBool(fgMenu(r, "CanAdd"))
                                cmd.Parameters.Add("@CanSave", SqlDbType.Bit).Value =
                                    akses AndAlso CBool(fgMenu(r, "CanSave"))
                                cmd.Parameters.Add("@CanEdit", SqlDbType.Bit).Value =
                                    akses AndAlso CBool(fgMenu(r, "CanEdit"))
                                cmd.Parameters.Add("@CanDelete", SqlDbType.Bit).Value =
                                    akses AndAlso CBool(fgMenu(r, "CanDelete"))

                                cmd.ExecuteNonQuery()
                            End Using
                        Next

                        tr.Commit()

                    Catch
                        tr.Rollback()
                        Throw
                    End Try
                End Using
            End Using

            MsgBoxCustom.Show(
                "Akses menu berhasil disimpan.",
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Information)

        Catch ex As Exception
            MsgBoxCustom.Show(
                "Gagal menyimpan akses menu: " & ex.Message,
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Error)
        End Try
    End Sub

    '==========================================================
    ' EXIT
    '==========================================================
    Private Sub btnExit_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnExit.Click

        Me.Close()
    End Sub


    Private Sub fgMenu_BeforeEdit(
    sender As Object,
    e As RowColEventArgs
) Handles fgMenu.BeforeEdit

        If e.Row < fgMenu.Rows.Fixed Then Exit Sub

        Dim namaKolom As String = fgMenu.Cols(e.Col).Name

        If namaKolom = "No" OrElse
       namaKolom = "MenuID" OrElse
       namaKolom = "Level" OrElse
       namaKolom = "MenuText" Then

            e.Cancel = True
            Exit Sub
        End If

        If namaKolom = "IsAllowed" Then Exit Sub

        If namaKolom = "CanAdd" OrElse
       namaKolom = "CanSave" OrElse
       namaKolom = "CanEdit" OrElse
       namaKolom = "CanDelete" Then

            If fgMenu(e.Row, "IsAllowed") Is Nothing OrElse
           Not CBool(fgMenu(e.Row, "IsAllowed")) Then

                e.Cancel = True
            End If
        End If

    End Sub


End Class