Imports C1.Win.C1FlexGrid

Public Class FrmDlgSupplier
    Public Property KodeSup As String
    Public Property NamaSup As String

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Call ShowData()
    End Sub

    Private Sub ShowData()
        Dim dt As New DataTable
        Dim i As Integer = 1
        Dim sql As String = ""

        If Replace(Trim(TxtSupplier.Text), "'", "''") = "" Then
            MsgBoxCustom.Show("Please input Supplier Name or Code", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Exit Sub
        End If

        'SET QUERY -------------------------------------------------------------------------------------------
        sql = " Select * from vwMstSupplier where ( left(kodesup,3)='PCG') "

        sql = sql & " and (NamaSup like '%" & Trim(TxtSupplier.Text) & "%' or KodeSup like '%" & Trim(TxtSupplier.Text) & "%') "

        If cmbPancang.Text <> "" Then
            sql = sql & " and NamaDivKav='" & cmbPancang.Text & "' "
        End If

        sql = sql & " order by NotActive,KodeJenisBahanBaku,GroupSup,KodeSup "

        'TAMPILKAN HASIL QUERY -------------------------------------------------------------------------------------------
        Try
            dt = DB.ExecuteQuery(StrConnAccounting, sql)

            ocx.Rows.Count = 1
            If dt.Rows.Count > 0 Then
                With ocx
                    ocx.Rows.Count = 1
                    For Each row As DataRow In dt.Rows
                        .AddItem(i)
                        .Item(i, "ocxKodeSupplier") = row.Item("KodeSup")
                        .Item(i, "ocxNama") = row.Item("NamaSup")
                        .Item(i, "ocxNoKTP") = row.Item("KTP")
                        .Item(i, "ocxNoKK") = row.Item("NoKK")
                        .Item(i, "ocxNoHP") = row.Item("NoHP")
                        .Item(i, "ocxNoNpwp") = row.Item("NoNpwp")
                        .Item(i, "ocxNamaNpwp") = row.Item("NamaNpwp")
                        .Item(i, "ocxAlamat") = row.Item("Alamat")
                        .Item(i, "ocxBahanBaku") = row.Item("NamaBahanBaku")
                        .Item(i, "ocxWilayahSP") = row.Item("WilSP")
                        .Item(i, "ocxDivBlokKav") = row.Item("DivBlokKav")
                        .Item(i, "ocxKodeNota") = row.Item("KodeNota")
                        .Item(i, "ocxGroupUM") = row.Item("KODESUPUM") & "-" & row.Item("NamaSupUM")
                        If row.Item("PTCV") = True Then
                            .Item(i, "ocxBayarVia") = "PT/CV"
                        ElseIf row.Item("Pribadi") = True Then
                            .Item(i, "ocxBayarVia") = "Pribadi"
                        ElseIf row.Item("Cash") = True Then
                            .Item(i, "ocxBayarVia") = "Cash"
                        End If
                        .Item(i, "ocxKeterangan") = row.Item("Keterangan")
                        .Item(i, "ocxkk") = IIf(IsDBNull(row.Item("chkkk")), 0, row.Item("chkkk"))
                        .Item(i, "ocxNonNPWP") = IIf(IsDBNull(row.Item("chkNPWP")), 0, row.Item("chkNPWP"))
                        .Item(i, "ocxToke") = IIf(IsDBNull(row.Item("chkToke")), 0, row.Item("chkToke"))
                        .Item(i, "ocxKanal") = IIf(IsDBNull(row.Item("Kanal")), 0, row.Item("Kanal"))
                        .Item(i, "ocxLaut") = IIf(IsDBNull(row.Item("Laut")), 0, row.Item("Laut"))
                        .Item(i, "ocxRelasiSub") = IIf(IsDBNull(row.Item("FlagRelasiSub")), 0, row.Item("FlagRelasiSub"))
                        .Item(i, "ocxNotActive") = IIf(IsDBNull(row.Item("NotActive")), 0, row.Item("NotActive"))
                        .Item(i, "ocxKeteranganNotActive") = row.Item("RemarkInActive")
                        .Item(i, "ocxCreatedBy") = row.Item("CreatedBy")
                        .Item(i, "ocxCreatedDate") = row.Item("CreatedDate")
                        .Item(i, "ocxUpdatedBy") = row.Item("lastUpdatedBy")
                        .Item(i, "ocxUpdatedDate") = row.Item("LastUpdatedDate")
                        .Item(i, "ocxRMSupplierID") = row.Item("RMSupplierID")
                        .Item(i, "ocxKodeSupplierUM") = row.Item("KODESUPUM")
                        .Item(i, "ocxKodeGroupSupplier") = row.Item("KodeSup1")
                        .Item(i, "ocxNamaGroupSupplier") = row.Item("NamaSup1")
                        .Item(i, "ocxKategori") = row.Item("KategoriSupplier")
                        .Item(i, "ocxJenisSupplier") = row.Item("JenisSupplier")
                        .Item(i, "ocxKomisiToke") = row.Item("FlagKomisiToke")
                        .Item(i, "ocxPPHUMKM") = row.Item("IndPPHUMKM")

                        If row.Item("NotActive") = True Then
                            Dim style As New CellRange
                            style = ocx.GetCellRange(i, 1, i, ocx.Cols.Count - 1)
                            style.StyleNew.ForeColor = Color.Red
                            'ElseIf row.Item("FlagSudahUploadNpwp") = False And row.Item("FlagSudahUploadKtp") = False Then
                            '    .Rows(i).StyleNew.BackColor = Color.FromArgb(255, 255, 192)
                            '    .Rows(i).StyleNew.ForeColor = Color.Black
                            'ElseIf row.Item("FlagSudahUploadNpwp") = True And row.Item("FlagSudahUploadKtp") = False Then
                            '    .Rows(i).StyleNew.BackColor = Color.FromArgb(255, 192, 192)
                            '    .Rows(i).StyleNew.ForeColor = Color.Black
                            'ElseIf row.Item("FlagSudahUploadNpwp") = False And row.Item("FlagSudahUploadKtp") = True Then
                            '    .Rows(i).StyleNew.BackColor = Color.FromArgb(220, 220, 255)
                            '    .Rows(i).StyleNew.ForeColor = Color.Black
                        End If

                        i = i + 1
                    Next
                    .AutoSizeCols()
                    'txt = .GetCellRange(0, 29, 0, 29) : txt.Data = "Photo" : .Cols(29).Width = 100
                End With
                Me.Cursor = Cursors.Default
            Else
                MsgBoxCustom.Show("No Data", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            End If
        Catch EX As Exception
            MsgBoxCustom.Show("Error: " & EX.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ocx_DoubleClick(sender As Object, e As EventArgs) Handles ocx.DoubleClick
        KodeSup = ocx.Item(ocx.RowSel, "ocxKodeSupplier")
        NamaSup = ocx.Item(ocx.RowSel, "ocxNama")

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub FrmDlgSupplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtSupplier.Clear()
        cmbPancang.SelectedIndex = -1
        ocx.Rows.Count = 1
    End Sub

End Class