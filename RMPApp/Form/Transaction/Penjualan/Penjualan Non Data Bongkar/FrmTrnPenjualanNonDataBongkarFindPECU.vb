Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmTrnPenjualanNonDataBongkarFindPECU
    Public CallbackSub As Action(Of String)

    Private Sub FrmTrnPenjualanShow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Awal dan akhir bulan ini
        dtpTglTimbang1.Value = dtpTglTimbang1.Value.AddDays(-dtpTglTimbang1.Value.Day + 1)
        dtpTglTimbang2.Value = dtpTglTimbang2.Value.AddDays(-dtpTglTimbang2.Value.Day + 1).AddMonths(1).AddDays(-1)

        Call ClsFlexGrid.ApplyStyle(fg)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ShowData()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Public Sub ShowData()
        Dim sql As String = "select * from vwTrnPenjualanNonDataTimbangFindPECU where PullBPI=0 and cast(TanggalTimbang as date) between '" & Format(dtpTglTimbang1.Value, "yyyy-MM-dd") & "' and '" & Format(dtpTglTimbang2.Value, "yyyy-MM-dd") & "'"

        If txtNoNota.Text.Trim <> "" Then
            sql &= " AND NoNota LIKE '%" & txtNoNota.Text.Trim() & "%'"
        End If

        If cmbPancang.Text.Trim <> "" Then
            sql &= " AND IDPancang LIKE '%" & cmbPancang.SelectedValue.ToString().Trim() & "%'"
        End If

        sql &= " ORDER BY AntrianID ASC"

        Dim dt As DataTable = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fg
            .Rows.Count = 1

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim i As Integer = 1
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "ID") = row("id")
                    .Item(i, "AntrianID") = row("AntrianID")
                    .Item(i, "NoNota") = row("NoNota")
                    .Item(i, "NotaViaName") = row("NotaViaName")
                    .Item(i, "Jenis") = row("Jenis")
                    .Item(i, "JenisKB") = row("JenisKB")
                    .Item(i, "IDCustomer") = row("IDSupplier")
                    .Item(i, "Customer") = row("Supplier")
                    .Item(i, "IDPancang") = row("IDPancang")
                    .Item(i, "Pancang") = row("Pancang")
                    .Item(i, "KapalID") = row("KapalID")
                    .Item(i, "Kapal") = row("Kapal")
                    .Item(i, "Mobil") = row("Mobil")
                    .Item(i, "DetailTimbang") = row("DetailTimbang")
                    .Item(i, "JaringKg") = row("JaringKg")
                    .Item(i, "Brutto") = row("Brutto")
                    .Item(i, "TarraJaring") = row("TarraJaring")
                    .Item(i, "Netto") = row("Netto")
                    .Item(i, "AlamatKelapa") = row("AlamatKelapa")
                    .Item(i, "TglTimbang") = row("TanggalTimbang")
                    .Item(i, "Harga") = row("HargaPerKg")
                    .Item(i, "TotalHarga") = row("TotalHarga")
                    .Item(i, "TglInputHarga") = row("TanggalInputHarga")
                    .Item(i, "InputHargaBy") = row("InputHargaBy")
                    .Item(i, "TarraPersen") = row("TarraPersen")
                    .Item(i, "TarraPotong") = row("TarraPotong")
                    .Item(i, "NettoFinal") = row("NettoFinal")
                    .Item(i, "CreatedBy") = row("CreatedBy")
                    .Item(i, "CreatedDate") = row("CreatedDate")

                    i += 1
                Next
                .AutoSizeCols()
            Else
                MsgBoxCustom.Show("Tidak ada data.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
            End If
        End With
    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg.BeforeEdit
        e.Cancel = True
    End Sub

    Private Sub fg_DoubleClick(sender As Object, e As EventArgs) Handles fg.DoubleClick
        ' cek jika proses tidak sesuai no antrian


        FrmTrnPenjualanNonDataBongkar.LoadDataPECU(fg.Item(fg.Row, "AntrianID"))
        Me.Close()
    End Sub
End Class