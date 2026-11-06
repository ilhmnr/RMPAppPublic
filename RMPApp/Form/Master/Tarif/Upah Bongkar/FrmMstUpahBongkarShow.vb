Imports System.ComponentModel
Imports C1.Win.C1FlexGrid

Public Class FrmMstUpahBongkarShow
    Private Sub FrmMstUpahBongkarShow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClsFlexGrid.ApplyStyle(fg)

        Combo.SetPancang(cmbPancang)
        Combo.SetBahanBaku(cboJenis)
    End Sub

    Private Sub ShowData()
        Dim i As Integer = 1
        Dim sql As String = ""
        Dim dt As DataTable = New DataTable()
        Dim Pancang As String = ""
        Dim No As Integer = 1

        If Replace(cboJenis.Text, " ", "") = "" Then
            MsgBoxCustom.Show("Jenis bahan baku belum dipilih.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Exit Sub
        End If

        Try
            sql = "select * from vwMstUpahBongkar where 1=1"

            If chkPeriode.Checked = True Then
                sql &= " AND UpahBongkarPeriode = '" & Format(dtpPeriode.Value, "yyyy-MM-dd") & "'"
            End If

            If cmbPancang.Text <> "" Then
                sql &= " AND IDPancang = " & cmbPancang.SelectedValue
            End If

            If cboJenis.Text <> "" Then
                sql &= " AND JenisBahanBaku = " & cboJenis.SelectedValue
            End If

            If rdLaut.Checked Then
                sql &= " AND Asal = 'Laut'"
            ElseIf rdDarat.Checked Then
                sql &= " AND Asal = 'Darat'"
            End If

            If rdKapal.Checked Then
                sql &= " AND Bongkar = 'Kapal'"
            ElseIf rdGudang.Checked Then
                sql &= " AND Bongkar = 'Gudang'"
            End If

            sql &= " order by Pancang asc, UpahBongkarPeriode desc, CreatedDate desc"

            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)
            If dt.Rows.Count > 0 Then
                With fg
                    Call UI.HapusGrid(1, fg)
                    For Each row As DataRow In dt.Rows

                        If Pancang <> row.Item("Pancang") Then
                            Pancang = row.Item("Pancang")
                            .AddItem("")
                            .Item(i, "Pancang") = row.Item("Pancang")
                            .Item(i, "NamaBahanBaku") = row.Item("NamaBahanBaku")
                            .Item(i, "ViaNota") = row.Item("Asal")
                            .Item(i, "Bongkar") = row.Item("Bongkar")
                            .Rows(i).StyleNew.BackColor = Color.LightGreen
                            i += 1
                        End If

                        .AddItem(No)
                        .Item(i, "IDUpahBongkar") = row.Item("IDUpahBongkar")
                        .Item(i, "Periode") = row.Item("UpahBongkarPeriode")
                        .Item(i, "IDPancang") = row.Item("IDPancang")
                        .Item(i, "Pancang") = row.Item("Pancang")
                        .Item(i, "JenisBahanBaku") = row.Item("JenisBahanBaku")
                        .Item(i, "NamaBahanBaku") = row.Item("NamaBahanBaku")
                        .Item(i, "ViaNota") = row.Item("Asal")
                        .Item(i, "Bongkar") = row.Item("Bongkar")
                        .Item(i, "UpahBongkar") = row.Item("UpahBongkar")
                        .Item(i, "IsActive") = row.Item("is_active")
                        .Item(i, "CreatedDate") = row.Item("CreatedDate")
                        .Item(i, "CreatedBy") = row.Item("CreatedBy")

                        i = i + 1
                        No += 1
                        Pancang = row.Item("Pancang")
                    Next
                    .AutoSizeCols()
                End With
            Else
                MsgBoxCustom.Show("Data tidak ditemukan", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            End If
        Catch EX As Exception
            MsgBoxCustom.Show(EX.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
        End Try
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        ShowData()
    End Sub

End Class
