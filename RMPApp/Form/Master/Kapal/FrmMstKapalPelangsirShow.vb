Imports C1.Win.C1FlexGrid
Imports System.Data
Imports System.Windows.Forms

Public Class FrmMstKapalPelangsirShow

    Private Sub FrmMstKapalPelangsirShow_Load(
        sender As Object, e As EventArgs
    ) Handles MyBase.Load

        ClsFlexGrid.ApplyStyle(fg)
        Modul_RMP.Combo.SetPancang(cmbPancang)

        dtpFrom.Value = Date.Today
        dtpTo.Value = Date.Today

        loaddata()
    End Sub

    Private Sub btnrefreshh_Click(
        sender As Object, e As EventArgs
    ) Handles btnrefreshh.Click

        loaddata()
    End Sub

    Public Sub loaddata()
        Dim dt As New DataTable
        Dim sql As String

        Try
            sql = "SELECT * FROM vwMstPelangsir WHERE ID IS NOT NULL"

            If txtnamapompong.Text.Trim() = "" Then
                sql &= " AND CreatedDate >= '" &
                    dtpFrom.Value.ToString("yyyy-MM-dd") & "'"

                sql &= " AND CreatedDate < '" &
                    dtpTo.Value.Date.AddDays(1).ToString("yyyy-MM-dd") & "'"
            Else
                sql &= " AND NamaPompong LIKE '%" &
                    txtnamapompong.Text.Trim().Replace("'", "''") & "%'"
            End If

            If txtnamapemilik.Text.Trim() <> "" Then
                sql &= " AND NamaPemilik LIKE '%" &
                    txtnamapemilik.Text.Trim().Replace("'", "''") & "%'"
            End If

            If txtkapasitas.Text.Trim() <> "" Then
                sql &= " AND CAST(Kapasitas AS VARCHAR(50)) LIKE '%" &
                    txtkapasitas.Text.Trim().Replace("'", "''") & "%'"
            End If

            If txtnamakapten.Text.Trim() <> "" Then
                sql &= " AND NamaKapten LIKE '%" &
                    txtnamakapten.Text.Trim().Replace("'", "''") & "%'"
            End If

            If cmbPancang.SelectedIndex >= 0 AndAlso
               cmbPancang.SelectedValue IsNot Nothing Then

                sql &= " AND PancangID = '" &
                    cmbPancang.SelectedValue.ToString().Replace("'", "''") & "'"
            End If

            sql &= " ORDER BY CAST(ID AS INT) DESC"

            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

            fg.Rows.Count = 1

            Dim i As Integer = 1

            For Each row As DataRow In dt.Rows
                fg.AddItem("")

                With fg
                    .Item(i, "No") = i
                    .Item(i, "NamaPompong") = row("NamaPompong")
                    .Item(i, "Kapasitas") = row("Kapasitas")
                    .Item(i, "NamaPemilik") = row("NamaPemilik")
                    .Item(i, "NoHPPemilik") = row("NomorHPPemilik")
                    .Item(i, "NamaKapten") = row("NamaKapten")
                    .Item(i, "NoHPKapten") = row("NomorHPKapten")
                    .Item(i, "Pancang") = row("Pancang")
                    .Item(i, "AlamatPompong") = row("AlamatPompong")
                    .Item(i, "NotActive") = row("NotActive")
                    .Item(i, "CreatedBy") = row("CreatedBy")
                    .Item(i, "CreatedDate") = row("CreatedDate")
                    .Item(i, "UpdatedBy") = row("UpdatedBy")
                    .Item(i, "UpdatedDate") = row("UpdatedDate")

                    .Item(i, "ID") = row("ID")
                    .Item(i, "FotoPompong") = row("FotoPompong")
                    .Item(i, "PelangsirCode") = row("PelangsirCode")
                    .Item(i, "PancangID") = row("PancangID")
                End With

                If Not IsDBNull(row("NotActive")) AndAlso
                   Convert.ToBoolean(row("NotActive")) Then

                    fg.Rows(i).StyleNew.ForeColor = Color.Red
                End If

                i += 1
            Next

            fg.AutoSizeCols()

            If dt.Rows.Count = 0 Then
                MsgBoxCustom.Show(
                    "No Data",
                    MsgBoxCustom.ButtonType.OK,
                    MsgBoxCustom.IconType.Information)
            End If

        Catch ex As Exception
            MsgBoxCustom.Show(
                "Error: " & ex.Message,
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Error)
        End Try
    End Sub

    Private Sub fg_DoubleClick(
        sender As Object, e As EventArgs
    ) Handles fg.DoubleClick

        If fg.Row <= 0 OrElse fg.Row >= fg.Rows.Count Then Exit Sub

        If fg.Item(fg.Row, "ID") Is Nothing OrElse
           IsDBNull(fg.Item(fg.Row, "ID")) Then Exit Sub

        With FrmMstKapalPelangsir
            .ClearInput()
            .LoadDataFromFind(fg.Item(fg.Row, "ID"))
            FrmMain.BukaMenu(FrmMstKapalPelangsir, FrmMain.mnuMstKapalKapalPelangsir)
        End With
    End Sub

    Private Sub btncancel_Click(
        sender As Object, e As EventArgs
    ) Handles btncancel.Click

        Me.Close()
    End Sub

    Private Sub btnExcel_Click(
        sender As Object, e As EventArgs
    ) Handles btnExcel.Click

        Try
            If fg.Rows.Count <= 1 Then
                MsgBoxCustom.Show(
                    "Data kosong.",
                    MsgBoxCustom.ButtonType.OK,
                    MsgBoxCustom.IconType.Information)
                Exit Sub
            End If

            Using dlg As New SaveFileDialog()
                dlg.Filter = "Excel File (*.xlsx)|*.xlsx"
                dlg.FileName = "MasterKapalPelangsir_" &
                    Format(Now, "yyyyMMdd")

                If dlg.ShowDialog() <> DialogResult.OK Then Exit Sub

                fg.SaveExcel(
                    dlg.FileName,
                    "Sheet1",
                    FileFlags.IncludeFixedCells)

                If IO.File.Exists(dlg.FileName) Then
                    MsgBoxCustom.Show(
                        "Export berhasil!",
                        MsgBoxCustom.ButtonType.OK,
                        MsgBoxCustom.IconType.Information)
                Else
                    MsgBoxCustom.Show(
                        "Export gagal.",
                        MsgBoxCustom.ButtonType.OK,
                        MsgBoxCustom.IconType.Error)
                End If
            End Using

        Catch ex As Exception
            MsgBoxCustom.Show(
                "Error Export: " & ex.Message,
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Error)
        End Try
    End Sub

End Class