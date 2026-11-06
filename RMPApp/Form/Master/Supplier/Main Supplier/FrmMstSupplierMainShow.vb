Imports C1.Win.C1FlexGrid

Public Class FrmMstSupplierMainShow

    Public Property KodeSupTerpilih As String = ""

    Private Sub FrmMstSupplierMainShow_Load(
        sender As Object, e As EventArgs
    ) Handles MyBase.Load

        ClsFlexGrid.ApplyStyle(fgSupplier)
        LoadSupplier()

    End Sub

    Private Sub LoadSupplier()
        Dim dt As New DataTable
        Dim sql As String =
            "SELECT * FROM vwRMMstSupplier1 WHERE 1=1 "

        If txtCariSupplier.Text.Trim <> "" Then
            Dim cari As String =
                txtCariSupplier.Text.Trim.Replace("'", "''")

            sql &= " AND (KodeSup LIKE '%" & cari & "%' " &
                   " OR NamaSup LIKE '%" & cari & "%') "
        End If

        sql &= " ORDER BY NotActive, KodeJenisBahanBaku, GroupSup, KodeSup"

        Try
            dt = DB.ExecuteQuery(StrConnAccounting, sql)

            With fgSupplier
                .Rows.Count = 1

                For Each row As DataRow In dt.Rows
                    .AddItem("")
                    Dim i As Integer = .Rows.Count - 1

                    .Item(i, "No") = i
                    .Item(i, "KodeSup") = row("KodeSup")
                    .Item(i, "NamaSup") = row("NamaSup")
                    .Item(i, "NamaGroup") = row("NamaGroup")
                    .Item(i, "NamaBahanBaku") = row("NamaBahanBaku")
                    .Item(i, "WilSP") = row("WilSP")
                    .Item(i, "DivBlokKav") = row("DivBlokKav")
                    .Item(i, "KodeNota") = row("KodeNota")
                    .Item(i, "NoNPWP") = row("NoNPWP")
                    .Item(i, "NamaNPWP") = row("NamaNPWP")
                    .Item(i, "Alamat") = row("Alamat")
                    .Item(i, "RMSupplierID") = row("RMSupplierID")
                    .Item(i, "Kanal") = row("Kanal")
                    .Item(i, "Laut") = row("Laut")
                    .Item(i, "NotActive") = row("NotActive")
                    .Item(i, "CreatedBy") = row("CreatedBy")
                    .Item(i, "CreatedDate") = row("CreatedDate")
                    .Item(i, "IDFactory") = row("IDFactory")
                    .Item(i, "singktn") = row("singktn")
                    .Item(i, "SingkatanNota") = row("SingkatanNota")
                    .Item(i, "PcgDarat") = row("PcgDarat")
                    .Item(i, "PcgLaut") = row("PcgLaut")
                    .Item(i, "jambul") = row("jambul")
                    .Item(i, "licin") = row("licin")
                    .Item(i, "Arang") = row("Arang")
                    .Item(i, "Cungkil") = row("Cungkil")
                    .Item(i, "Pancang") = row("Pancang")
                    .Item(i, "FlagPancangSub") = row("FlagPancangSub")
                    .Item(i, "FlagPancangSubMain") = row("FlagPancangSubMain")
                    .Item(i, "FlagKontainer") = row("FlagKontainer")
                    .Item(i, "FlagHargaPetaniKaki") = row("FlagHargaPetaniKaki")
                    .Item(i, "FlagHargaPetaniKakiView") = row("FlagHargaPetaniKakiView")
                    .Item(i, "FlagKomisiTokeh") = row("FlagKomisiTokeh")
                    .Item(i, "FlagKomisiOnlyTokeh") = row("FlagKomisiOnlyTokeh")
                Next

                .AutoSizeCols()
            End With

        Catch ex As Exception
            MsgBoxCustom.Show(
                "Error: " & ex.Message,
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Error
            )
        End Try
    End Sub

    Private Sub btnAdd_Click(
        sender As Object, e As EventArgs
    ) Handles btnAdd.Click

        LoadSupplier()

    End Sub

    Private Sub txtCariSupplier_KeyDown(
        sender As Object, e As KeyEventArgs
    ) Handles txtCariSupplier.KeyDown

        If e.KeyCode = Keys.Enter Then
            LoadSupplier()
            e.SuppressKeyPress = True
        End If

    End Sub

    Private Sub btnExit_Click(
        sender As Object, e As EventArgs
    ) Handles btnExit.Click

        Me.Close()

    End Sub

    Private Sub fgSupplier_DoubleClick(
    sender As Object, e As EventArgs
) Handles fgSupplier.DoubleClick

        If fgSupplier.Rows.Count > 1 Then
            With FrmMstSupplierMain
                .ShowData(fgSupplier.Item(fgSupplier.Row, "KodeSup"))
                .Show()
            End With
        Else
            MsgBoxCustom.Show("No Data",
            MsgBoxCustom.ButtonType.OK,
            MsgBoxCustom.IconType.Information)
        End If

    End Sub

End Class