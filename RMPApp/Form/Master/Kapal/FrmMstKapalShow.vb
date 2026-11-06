Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports System.IO
Imports WeifenLuo.WinFormsUI.Docking

Public Class FrmMstKapalShow

    Private _isLoading As Boolean = True

    Private Sub FrmMstKapalShow_Load(
        sender As Object, e As EventArgs
    ) Handles MyBase.Load

        Try
            _isLoading = True

            ClsFlexGrid.ApplyStyle(fg)
            Combo.SetPancang(cmbPancang)

            SearchGrid()
            ShowData()

        Catch ex As Exception
            MsgBoxCustom.Show(
                "Error: " & ex.Message,
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Error)
        Finally
            _isLoading = False
        End Try

    End Sub

    Private Sub SearchGrid()
        schfg.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
        schfg.SearchDelay = 2
        schfg.Watermark = "Search : Pemilik/Kapal"
        schfg.SetC1FlexGridSearchPanel(fg, schfg)
    End Sub

    Private Sub ShowData()
        Dim dt As New DataTable
        Dim sql As String =
        "SELECT * FROM vwkapalnew WHERE 1=1 "

        Try
            If txtNamaKapal.Text.Trim() <> "" Then
                sql &= " AND (KapalName LIKE @KapalName OR KapalID LIKE @KapalID)"
            End If

            If cmbPancang.SelectedValue IsNot Nothing AndAlso cmbPancang.Text.Trim() <> "" Then
                sql &= " AND IDPancang = @IDPancang "
            End If

            If txtNamaKapal.Text = "" Or cmbPancang.Text = "" Then
                sql &= " AND CAST(CreatedDate AS date) BETWEEN @FromDate AND @ToDate "
            End If

            sql &= " ORDER BY NonActive, KapalName "

            Using cn As New SqlConnection(StrConnRMPApp)
                Using cmd As New SqlCommand(sql, cn)

                    If txtNamaKapal.Text.Trim() <> "" Then
                        cmd.Parameters.AddWithValue("@KapalName", "%" & txtNamaKapal.Text.Trim() & "%")
                        cmd.Parameters.AddWithValue("@KapalID", "%" & txtNamaKapal.Text.Trim() & "%")
                    Else
                        cmd.Parameters.AddWithValue("@FromDate", dtpFrom.Value.Date)
                        cmd.Parameters.AddWithValue("@ToDate", dtpTo.Value.Date)
                    End If

                    If cmbPancang.SelectedValue IsNot Nothing AndAlso
                   cmbPancang.Text.Trim() <> "" Then

                        cmd.Parameters.AddWithValue(
                        "@IDPancang", cmbPancang.SelectedValue)
                    End If

                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using

                End Using
            End Using

            With fg
                UI.HapusGrid(1, fg)

                If dt.Rows.Count = 0 Then Return

                Dim i As Integer = 1

                For Each row As DataRow In dt.Rows
                    .AddItem(i)

                    .Item(i, "KapalID") = row("KapalID")
                    .Item(i, "KapalName") = row("KapalName")
                    .Item(i, "Pemilik") = row("Pemilik")
                    .Item(i, "NamaKapten") = row("namakapten")
                    .Item(i, "NoHpKapten") = row("nohpkapten")
                    .Item(i, "Kap") = row("Kap")
                    .Item(i, "Pancang") = row("Pancang")
                    .Item(i, "NonActive") = If(
                    IsDBNull(row("NonActive")), False,
                    Convert.ToBoolean(row("NonActive")))
                    .Item(i, "Pembantu") = If(
                    IsDBNull(row("pembantu")), False,
                    Convert.ToBoolean(row("pembantu")))
                    .Item(i, "TahunKapal") = row("TahunKapal")
                    .Item(i, "BodyKapal") = row("BodyKapal")
                    .Item(i, "DayaMesin") = row("DayaMesin")
                    .Item(i, "CreatedBy") = row("CreatedBy")
                    .Item(i, "CreatedDate") = row("CreatedDate")
                    .Item(i, "UpdatedBy") = row("UpdatedBy")
                    .Item(i, "UpdatedDate") = row("UpdatedDate")
                    .Item(i, "IDPancang") = row("IDPancang")
                    .Item(i, "IDKapten") = row("KaptenID")
                    .Item(i, "Crane") = row("Crane")
                    .Item(i, "Pontianak") = row("Pontianak")

                    If Not IsDBNull(row("NonActive")) AndAlso
                   Convert.ToBoolean(row("NonActive")) Then

                        .GetCellRange(i, 1, i, .Cols.Count - 1).
                        StyleNew.ForeColor = Color.Red

                    ElseIf Not IsDBNull(row("pembantu")) AndAlso
                       Convert.ToBoolean(row("pembantu")) Then

                        .GetCellRange(i, 1, i, .Cols.Count - 1).
                        StyleNew.ForeColor = Color.Green
                    End If

                    i += 1
                Next

                .AutoSizeCols()
            End With

        Catch ex As Exception
            MsgBoxCustom.Show(
            "Error: " & ex.Message,
            MsgBoxCustom.ButtonType.OK,
            MsgBoxCustom.IconType.Error)
        End Try
    End Sub

    Private Sub btnrefreshh_Click(
        sender As Object, e As EventArgs
    ) Handles btnrefreshh.Click

        Me.Cursor = Cursors.WaitCursor

        Try
            ShowData()
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub btnExcel_Click(
        sender As Object, e As EventArgs
    ) Handles btnExcel.Click

        ConvertExcel()

    End Sub

    Private Sub ConvertExcel()
        Try
            If fg.Rows.Count <= 1 Then
                MsgBoxCustom.Show(
                    "Data kosong.",
                    MsgBoxCustom.ButtonType.OK,
                    MsgBoxCustom.IconType.Information)
                Return
            End If

            Using save As New SaveFileDialog
                save.Filter = "Excel 97-2003 (*.xls)|*.xls"
                save.FileName = "DataKapal_" &
                    Format(Now, "yyyyMMdd") & ".xls"

                If save.ShowDialog() <> DialogResult.OK Then Return

                fg.SaveExcel(
                    save.FileName,
                    "Sheet1",
                    FileFlags.IncludeFixedCells)

                If File.Exists(save.FileName) Then
                    MsgBoxCustom.Show(
                        "Export berhasil!",
                        MsgBoxCustom.ButtonType.OK,
                        MsgBoxCustom.IconType.Information)
                End If
            End Using

        Catch ex As Exception
            MsgBoxCustom.Show(
                "Error Export: " & ex.Message,
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Error)
        End Try
    End Sub

    Private Sub btncancel_Click(
        sender As Object, e As EventArgs
    ) Handles btncancel.Click

        Me.Close()

    End Sub

    Private Sub fg_DoubleClick(
        sender As Object, e As EventArgs
    ) Handles fg.DoubleClick

        BukaDataKapal()

    End Sub

    Private Sub BukaDataKapal()
        Try
            If fg.Row < fg.Rows.Fixed OrElse fg.Row >= fg.Rows.Count Then
                Return
            End If

            Dim kapalID As Integer

            If Not Integer.TryParse(
                Convert.ToString(fg.Item(fg.Row, 1)), kapalID) Then
                Return
            End If

            With FrmMstKapal
                .ShowData(kapalID)
                .Show()
                .BringToFront()
            End With

        Catch ex As Exception
            MsgBoxCustom.Show(
                "Gagal membuka data kapal: " & ex.Message,
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Error)
        End Try
    End Sub

End Class
