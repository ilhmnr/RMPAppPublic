Imports System.Data.SqlClient
Imports System.Net.Http.Headers

Public Class FrmMstTarifUpahBongkar
    Private aksi As String = "none"

    Private Sub FrmMstHargaPremiAsuransi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClsFlexGrid.ApplyStyle(fg)
        ClsFlexGrid.SetNumberFormat(fg, "N0", "UpahBongkar", "UpahBongkarBefore")
        ClsFlexGrid.SetEditableColumns(fg, "UpahBongkar", "UpahBongkarBefore")

        Combo.SetPancang(cboPancang)
        Modul_RMP.Combo.SetBahanBaku(cboJenis)

        btnEdit.Enabled = True
        btnSave.Enabled = False
        btnCancel.Enabled = False
    End Sub

    Private Sub ShowData()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim dt As DataTable = New DataTable
            Dim i As Integer = 1
            Dim sql As String = ""

            Dim Periode As String = Format(dtpPeriode.Value, "yyyy-MM-dd")
            Dim Pancang As String = IIf(cboPancang.Text <> "", "'" & cboPancang.SelectedValue & "'", "0")
            Dim Jenis As String = IIf(cboJenis.Text <> "", "'" & cboJenis.SelectedValue & "'", "0")

            Dim NotaVia As Integer = 0
            If rdLaut.Checked Then
                NotaVia = 1
            ElseIf rdDarat.Checked Then
                NotaVia = 2
            End If

            Dim Bongkar As String = ""
            If rdKapal.Checked Then
                Bongkar = "Kapal"
            ElseIf rdGudang.Checked Then
                Bongkar = "Gudang"
            End If

            sql = "select * from fnMstTarifUpahBongkar('" & Periode & "'," & Pancang & "," & Jenis & "," & NotaVia & ",'" & Bongkar & "') order by Pancang"

            dt = DB.ExecuteQuery(StrConnRMPApp, sql)

            fg.Rows.Count = 1

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    fg.AddItem(i)
                    fg(i, "ID") = row("id")
                    fg(i, "IDPancang") = row("IDPancang")
                    fg(i, "Pancang") = row("Pancang")
                    fg(i, "UpahBongkar") = row("UpahBongkar")
                    fg(i, "UpahBongkarBefore") = row("UpahBongkar")
                    fg(i, "Periode") = row("UpahBongkarPeriode")
                    fg(i, "CreatedBy") = row("CreatedBy")
                    fg(i, "CreatedDate") = row("CreatedDate")

                    i += 1
                Next

                fg.AutoSizeCols()
            Else
                MsgBoxCustom.Show("Data tidak ditemukan.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            End If
        Catch ex As Exception

        Finally
            Me.Cursor = Cursors.Default
        End Try
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
        If Replace(cboJenis.Text, " ", "") = "" Then
            MsgBoxCustom.Show("Jenis bahan baku belum dipilih.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Exit Sub
        End If

        btnEdit.Enabled = False
        btnSave.Enabled = True
        btnCancel.Enabled = True

        aksi = "edit"
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Replace(cboJenis.Text, " ", "") = "" Then
            MsgBoxCustom.Show("Jenis bahan baku belum dipilih.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Exit Sub
        End If

        If MsgBoxCustom.Show("Apakah anda yakin ingin menyimpan data?", MsgBoxCustom.ButtonType.YesNo, MsgBoxCustom.IconType.Question) = vbNo Then
            Exit Sub
        End If

        Call SaveData()

        btnCancel.PerformClick()
    End Sub

    Private Sub SaveData()
        Dim AdaPerubahan As Boolean = False

        For i As Integer = 1 To fg.Rows.Count - 1
            Dim UpahBongkar As Integer = 0

            If Not String.IsNullOrWhiteSpace(fg.Item(i, "UpahBongkar").ToString()) Then
                If Not Integer.TryParse(fg.Item(i, "UpahBongkar").ToString(), UpahBongkar) Then
                    MsgBoxCustom.Show("Upah bongkar harus berupa angka.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                    Exit Sub
                End If
            End If

            If UpahBongkar <> CInt(Val(fg.Item(i, "UpahBongkarBefore").ToString())) Then
                AdaPerubahan = True
                Exit For
            End If
        Next

        If Not AdaPerubahan Then
            MsgBoxCustom.Show("Tidak ada perubahan data.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Exit Sub
        End If

        ' JENIS
        Dim Jenis As Integer = 0

        If cboJenis.Text <> "" AndAlso cboJenis.SelectedValue IsNot Nothing Then
            If Not Integer.TryParse(cboJenis.SelectedValue.ToString(), Jenis) Then
                MsgBoxCustom.Show("Jenis tidak valid.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                Exit Sub
            End If
        End If

        ' VIA NOTA
        Dim NotaVia As Integer = 0

        If rdLaut.Checked Then
            NotaVia = 1
        ElseIf rdDarat.Checked Then
            NotaVia = 2
        End If

        ' BONGKAR
        Dim Bongkar As String = ""

        If rdKapal.Checked Then
            Bongkar = "Kapal"
        ElseIf rdGudang.Checked Then
            Bongkar = "Gudang"
        End If

        Dim conn As SqlConnection = Nothing
        Dim tran As SqlTransaction = Nothing

        Try
            conn = DB.OpenConnection(StrConnRMPApp)
            tran = conn.BeginTransaction()

            For i As Integer = 1 To fg.Rows.Count - 1

                Dim UpahBongkar As Integer = 0
                Dim UpahBongkarBefore As Integer = 0
                Dim IDPancang As Integer = 0

                ' ID PANCANG
                If Not Integer.TryParse(fg.Item(i, "IDPancang").ToString(), IDPancang) Then
                    Throw New Exception("ID Pancang tidak valid pada baris " & i & ".")
                End If

                ' UPAH BONGKAR
                If Not String.IsNullOrWhiteSpace(fg.Item(i, "UpahBongkar").ToString()) Then
                    If Not Integer.TryParse(fg.Item(i, "UpahBongkar").ToString(), UpahBongkar) Then
                        Throw New Exception("Upah Bongkar tidak valid pada baris " & i & ".")
                    End If
                End If

                ' UPAH SEBELUMNYA
                If Not String.IsNullOrWhiteSpace(fg.Item(i, "UpahBongkarBefore").ToString()) Then
                    If Not Integer.TryParse(fg.Item(i, "UpahBongkarBefore").ToString(), UpahBongkarBefore) Then
                        UpahBongkarBefore = 0
                    End If
                End If

                If UpahBongkar <> UpahBongkarBefore Then

                    Using cmd As New SqlCommand("spMstTarifUpahBongkar", conn, tran)

                        cmd.CommandType = CommandType.StoredProcedure

                        cmd.Parameters.Add("@Periode", SqlDbType.Date).Value =
                        dtpPeriode.Value.Date

                        cmd.Parameters.Add("@IDPancang", SqlDbType.Int).Value =
                        IDPancang

                        cmd.Parameters.Add("@UpahBongkar", SqlDbType.Int).Value =
                        UpahBongkar

                        cmd.Parameters.Add("@Jenis", SqlDbType.Int).Value =
                        Jenis

                        cmd.Parameters.Add("@ViaNota", SqlDbType.Int).Value =
                        NotaVia

                        cmd.Parameters.Add("@Bongkar", SqlDbType.VarChar).Value =
                        Bongkar

                        cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value =
                        ClsSession.UserID

                        Dim paramFlag As SqlParameter =
                        cmd.Parameters.Add("@Flag", SqlDbType.Int)

                        paramFlag.Direction = ParameterDirection.Output

                        cmd.ExecuteNonQuery()

                        If paramFlag.Value Is Nothing OrElse
                       IsDBNull(paramFlag.Value) OrElse
                       CInt(paramFlag.Value) <> 1 Then

                            Throw New Exception("Stored procedure gagal menyimpan data.")
                        End If

                    End Using

                End If

            Next

            tran.Commit()

            MsgBoxCustom.Show(
            "Data berhasil disimpan.",
            MsgBoxCustom.ButtonType.OK,
            MsgBoxCustom.IconType.Information
        )

            Call ShowData()
            btnCancel.PerformClick()

        Catch ex As Exception

            If tran IsNot Nothing Then
                Try
                    tran.Rollback()
                Catch
                End Try
            End If

            MsgBoxCustom.Show(
            "Gagal menyimpan data." & vbCrLf & ex.Message,
            MsgBoxCustom.ButtonType.OK,
            MsgBoxCustom.IconType.Error
        )

        Finally

            If conn IsNot Nothing AndAlso conn.State <> ConnectionState.Closed Then
                conn.Close()
            End If

        End Try
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
        If fg.Cols(fg.Col).Name = "UpahBongkar" And aksi = "edit" Then
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub fg_AfterEdit(sender As Object, e As C1.Win.C1FlexGrid.RowColEventArgs) Handles fg.AfterEdit
        If fg.Item(e.Row, "UpahBongkar").ToString.Replace(" ", "") = "" Then
            fg.Item(e.Row, "UpahBongkar") = 0
        End If
    End Sub

    Private Sub cboJenis_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboJenis.SelectedIndexChanged
        ShowData()
    End Sub

    Private Sub rdLaut_CheckedChanged(sender As Object, e As EventArgs) Handles rdLaut.CheckedChanged, rdDarat.CheckedChanged, rdKapal.CheckedChanged, rdGudang.CheckedChanged, rdGudang.CheckedChanged
        ShowData()
    End Sub

    Private Sub cboFind_Click(sender As Object, e As EventArgs) Handles cboFind.Click
        FrmMstUpahBongkarShow.fg.Rows.Count = 1
        FrmMstUpahBongkarShow.ShowDialog()
    End Sub
End Class