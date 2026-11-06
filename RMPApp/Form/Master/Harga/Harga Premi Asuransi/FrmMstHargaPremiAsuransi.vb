Imports System.Data.SqlClient

Public Class FrmMstHargaPremiAsuransi
    Private aksi As String = "none"

    Private Sub FrmMstHargaPremiAsuransi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClsFlexGrid.ApplyStyle(fg)
        ClsFlexGrid.SetNumberFormat(fg, "N0", "HargaKBB", "HargaKBBBefore")
        ClsFlexGrid.SetEditableColumns(fg, "HargaKBB", "HargaKBBBefore")

        Combo.SetPancang(cboPancang)

        btnEdit.Enabled = True
        btnSave.Enabled = False
        btnCancel.Enabled = False
    End Sub

    Private Sub ShowData()
        Dim dt As DataTable = New DataTable
        Dim i As Integer = 1
        Dim sql As String = "select * from fnMstHargaPremiAsuransi('" & Format(dtpPeriode.Value, "yyyy-MM-dd") & "'," & IIf(cboPancang.Text <> "", "'" & cboPancang.SelectedValue & "'", "0") & ") order by Pancang"

        dt = DB.ExecuteQuery(StrConnRMPApp, sql)

        fg.Rows.Count = 1

        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                fg.AddItem(i)
                fg(i, "ID") = row("id")
                fg(i, "IDPancang") = row("IDPancang")
                fg(i, "Pancang") = row("Pancang")
                fg(i, "HargaKBB") = row("harga_kb_b")
                fg(i, "HargaKBBBefore") = row("harga_kb_b")
                fg(i, "Periode") = row("periode")
                fg(i, "CreatedBy") = row("created_by")
                fg(i, "CreatedDate") = row("created_date")

                i += 1
            Next

            fg.AutoSizeCols()
        Else
            MsgBoxCustom.Show("Data tidak ditemukan.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
        End If
    End Sub

    Private Sub dtpPeriode_ValueChanged(sender As Object, e As EventArgs) Handles dtpPeriode.ValueChanged
        Call ShowData()
    End Sub

    Private Sub cboPancang_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPancang.SelectedIndexChanged
        Try
            Call ShowData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        btnEdit.Enabled = False
        btnSave.Enabled = True
        btnCancel.Enabled = True

        aksi = "edit"
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If MsgBoxCustom.Show("Apakah anda yakin ingin menyimpan data?", MsgBoxCustom.ButtonType.YesNo, MsgBoxCustom.IconType.Question) = vbNo Then
            Exit Sub
        End If

        Call SaveData()

        btnCancel.PerformClick()
    End Sub

    Private Sub SaveData()
        Dim AdaPerubahan As Boolean = False
        For i As Integer = 1 To fg.Rows.Count - 1
            If IIf(fg.Item(i, "HargaKBB").ToString.Replace(" ", "") = "", 0, fg.Item(i, "HargaKBB")) <> fg.Item(i, "HargaKBBBefore") Then
                AdaPerubahan = True
                Exit For
            End If
        Next
        If AdaPerubahan = False Then
            MsgBoxCustom.Show("Tidak ada perubahan data.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Exit Sub
        End If

        Dim conn As SqlConnection = DB.OpenConnection(StrConnRMPApp)
        Dim tran As SqlTransaction = conn.BeginTransaction

        Dim dt As DataTable = New DataTable
        For i As Integer = 1 To fg.Rows.Count - 1
            If fg.Item(i, "HargaKBB") <> fg.Item(i, "HargaKBBBefore") Then
                Using cmd As SqlCommand = New SqlCommand("spMstHargaPremiAsuransi", conn, tran)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@IDPancang", fg.Item(i, "IDPancang"))
                    cmd.Parameters.AddWithValue("@HargaKBB", CInt(fg.Item(i, "HargaKBB")))
                    cmd.Parameters.AddWithValue("@Periode", Format(dtpPeriode.Value, "yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@CreatedBy", ClsSession.UserID)
                    Dim paramFlag As SqlParameter = New SqlParameter("@Flag", SqlDbType.Int)
                    paramFlag.Direction = ParameterDirection.Output
                    paramFlag.Value = 0
                    cmd.Parameters.Add(paramFlag)
                    cmd.ExecuteNonQuery()
                    If paramFlag.Value <> 1 Then
                        tran.Rollback()
                        MsgBoxCustom.Show("Gagal menyimpan data.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                        Exit Sub
                    End If
                End Using
            End If
        Next

        tran.Commit()

        MsgBoxCustom.Show("Data berhasil disimpan.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)

        Call ShowData()

        btnCancel.PerformClick()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        btnEdit.Enabled = True
        btnSave.Enabled = False
        btnCancel.Enabled = False

        aksi = "none"
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As C1.Win.C1FlexGrid.RowColEventArgs) Handles fg.BeforeEdit
        If fg.Cols(fg.Col).Name = "HargaKBB" And aksi = "edit" Then
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub fg_AfterEdit(sender As Object, e As C1.Win.C1FlexGrid.RowColEventArgs) Handles fg.AfterEdit
        If fg.Item(e.Row, "HargaKBB").ToString.Replace(" ", "") = "" Then
            fg.Item(e.Row, "HargaKBB") = 0
        End If
    End Sub
End Class