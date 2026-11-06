Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports DocumentFormat.OpenXml.Presentation

Public Class FrmMonPembayaranSupplierKeToke
    Private Sub FrmMonPembayaranSupplierKeToke_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call HeaderFg()

        cboPancang.DropDownStyle = ComboBoxStyle.DropDown ' Penting agar bisa ketik manual
        cboPancang.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboPancang.AutoCompleteSource = AutoCompleteSource.ListItems
        Modul_RMP.Combo.SetPancang(cboPancang)

        cboKapal.DropDownStyle = ComboBoxStyle.DropDown ' Penting agar bisa ketik manual
        cboKapal.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboKapal.AutoCompleteSource = AutoCompleteSource.ListItems
        Modul_RMP.Combo.SetKapal(cboKapal)
    End Sub

    Private Sub HeaderFg()
        Dim txt As CellRange

        With fg
            .Rows.Fixed = 2
            .Cols.Fixed = 1
            .Rows.Count = 2
            .Cols.Count = 20

            .AutoGenerateColumns = True
            .Rows(0).AllowMerging = True
            .Rows(1).AllowMerging = True
            .Styles.Normal.WordWrap = True

            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular)
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .AllowMerging = AllowMergingEnum.FixedOnly

            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(1).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(1).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

            .Rows(0).TextAlign = TextAlignEnum.CenterCenter
            .Rows(1).TextAlign = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 0, 1, 0) : txt.Data = "NO" : .Cols(0).TextAlign = TextAlignEnum.LeftCenter : .Cols(0).AllowEditing = True : .Cols(0).AllowMerging = True
            txt = .GetCellRange(0, 1, 1, 1) : txt.Data = "TANGGAL NOTA" : .Cols(1).TextAlign = TextAlignEnum.LeftCenter : .Cols(1).AllowEditing = True : .Cols(1).AllowMerging = True
            txt = .GetCellRange(0, 2, 1, 2) : txt.Data = "PANCANG" : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).AllowEditing = True : .Cols(2).AllowMerging = True
            txt = .GetCellRange(0, 3, 1, 3) : txt.Data = "NAMA KAPAL" : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).AllowEditing = True : .Cols(3).AllowMerging = True
            txt = .GetCellRange(0, 4, 1, 4) : txt.Data = "ID RELASI" : .Cols(4).TextAlign = TextAlignEnum.LeftCenter : .Cols(4).AllowEditing = True : .Cols(4).AllowMerging = True
            txt = .GetCellRange(0, 5, 1, 5) : txt.Data = "NAMA RELASI" : .Cols(5).TextAlign = TextAlignEnum.LeftCenter : .Cols(5).AllowEditing = True : .Cols(5).AllowMerging = True
            txt = .GetCellRange(0, 6, 1, 6) : txt.Data = "NOMOR REKENING" : .Cols(6).TextAlign = TextAlignEnum.LeftCenter : .Cols(6).AllowEditing = True : .Cols(6).AllowMerging = True
            txt = .GetCellRange(0, 7, 1, 7) : txt.Data = "NAMA REKENING" : .Cols(7).TextAlign = TextAlignEnum.LeftCenter : .Cols(7).AllowEditing = True : .Cols(7).AllowMerging = True
            txt = .GetCellRange(0, 8, 1, 8) : txt.Data = "BANK" : .Cols(8).TextAlign = TextAlignEnum.LeftCenter : .Cols(8).AllowEditing = True : .Cols(8).AllowMerging = True
            txt = .GetCellRange(0, 9, 1, 9) : txt.Data = "NETTO 1" : .Cols(9).TextAlign = TextAlignEnum.RightCenter : .Cols(9).AllowEditing = True : .Cols(9).AllowMerging = True : .Cols(9).Format = "#,##0"
            txt = .GetCellRange(0, 10, 1, 10) : txt.Data = "TARRA %" : .Cols(10).TextAlign = TextAlignEnum.RightCenter : .Cols(10).AllowEditing = True : .Cols(10).AllowMerging = True : .Cols(10).Format = "#,##0"
            txt = .GetCellRange(0, 11, 1, 11) : txt.Data = "TARRA POT" : .Cols(11).TextAlign = TextAlignEnum.RightCenter : .Cols(11).AllowEditing = True : .Cols(11).AllowMerging = True : .Cols(11).Format = "#,##0"
            txt = .GetCellRange(0, 12, 1, 12) : txt.Data = "NETTO 2" : .Cols(12).TextAlign = TextAlignEnum.RightCenter : .Cols(12).AllowEditing = True : .Cols(12).AllowMerging = True : .Cols(12).Format = "#,##0"
            txt = .GetCellRange(0, 13, 1, 13) : txt.Data = "HARGA" : .Cols(13).TextAlign = TextAlignEnum.RightCenter : .Cols(13).AllowEditing = True : .Cols(13).AllowMerging = True : .Cols(13).Format = "#,##0"
            txt = .GetCellRange(0, 14, 1, 14) : txt.Data = "TOTAL HARGA" : .Cols(14).TextAlign = TextAlignEnum.RightCenter : .Cols(14).AllowEditing = True : .Cols(14).AllowMerging = True : .Cols(14).Format = "#,##0"
            txt = .GetCellRange(0, 15, 0, 16) : txt.Data = "UPAH BURUH"
            txt = .GetCellRange(1, 15, 1, 15) : txt.Data = "Rp" : .Cols(15).TextAlign = TextAlignEnum.RightCenter : .Cols(15).AllowEditing = True : .Cols(15).Format = "#,##0"
            txt = .GetCellRange(1, 16, 1, 16) : txt.Data = "Rp/Kg" : .Cols(16).TextAlign = TextAlignEnum.RightCenter : .Cols(16).AllowEditing = True : .Cols(16).Format = "#,##0"
            txt = .GetCellRange(0, 17, 0, 18) : txt.Data = "UPAH TAMBANG"
            txt = .GetCellRange(1, 17, 1, 17) : txt.Data = "Rp" : .Cols(17).TextAlign = TextAlignEnum.RightCenter : .Cols(17).AllowEditing = True : .Cols(17).Format = "#,##0"
            txt = .GetCellRange(1, 18, 1, 18) : txt.Data = "Rp/Kg" : .Cols(18).TextAlign = TextAlignEnum.RightCenter : .Cols(18).AllowEditing = True : .Cols(18).Format = "#,##0"
            txt = .GetCellRange(0, 19, 0, 19) : txt.Data = "ASURANSI"
            txt = .GetCellRange(1, 19, 1, 19) : txt.Data = "Rp" : .Cols(19).TextAlign = TextAlignEnum.RightCenter : .Cols(19).AllowEditing = True : .Cols(19).Format = "#,##0"

            .AutoSizeCols()
        End With
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        If txtTrip.Text = "" Or cboPancang.Text = "" Or cboKapal.Text = "" Then
            MsgBox("Semua Data Harus Di Isi.", vbInformation, AT)
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        Dim dt As DataTable = New DataTable
        Dim i As Integer = 2

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select a.TransDate,a.Pancang,b.KapalName,a.IDRelasi,a.NamaRelasi,a.RekeningPenerima,a.PenerimaUang,c.JenisBank,a.Netto,a.TarraPersen,a.TarraKg,a.NettoAkhir,a.Harga,a.TotalHarga,
                                                            isnull((select top(1) upahbongkar from tblMstUpahBongkar where  upahbongkarperiode<=a.TransDate  And Jenis=a.NotaVia And idpancang=a.idpancang  order by UpahBongkarPeriode desc) ,0) as RpBongkar,
                                                            isnull((select top(1) iif(b.Crane=1,isnull(UpahTambangKapalCrane,0),isnull(UpahTambang,0))  as UpahTambang from tblMstTambangKapalKeSupplier where  JenisBahanBaku='1' and Periode<=CAST(a.TransDate AS DATE) and idpancang= a.idpancang order by Periode  desc) ,0) RpTambang
                                                            from RMPApp..TblTrnKelapaHdr as a inner join 
                                                            RMPApp..tblMstKapal as b on a.IDKapal=b.KapalID inner join
                                                            RSUPAccounting..vwRMMstRekeningPancang as c ON A.RekeningPenerima = c.NoRekening AND a.IDPenerimaUang = c.IDPetani AND c.ID_Jenis_Rek = '1'
                                                            where SupplierPabrikID is not null and a.Trip=" & txtTrip.Text & " and a.IDPancang=" & cboPancang.SelectedValue & " and a.IDKapal=" & cboKapal.SelectedValue & " ")


        With fg
            .Rows.Count = 2

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, 1) = row("TransDate")
                    .Item(i, 2) = row("Pancang")
                    .Item(i, 3) = row("KapalName")
                    .Item(i, 4) = row("IDRelasi")
                    .Item(i, 5) = row("NamaRelasi")
                    .Item(i, 6) = row("RekeningPenerima")
                    .Item(i, 7) = row("PenerimaUang")
                    .Item(i, 8) = row("JenisBank")
                    .Item(i, 9) = row("Netto")
                    .Item(i, 10) = row("TarraPersen")
                    .Item(i, 11) = row("TarraKg")
                    .Item(i, 12) = row("NettoAkhir")
                    .Item(i, 13) = row("Harga")
                    .Item(i, 14) = row("TotalHarga")
                    .Item(i, 15) = row("RpBongkar")
                    .Item(i, 16) = row("NettoAkhir") * row("RpBongkar")
                    .Item(i, 17) = row("RpTambang")
                    .Item(i, 18) = 0
                    .Item(i, 19) = 0

                    i += 1
                Next

                Call Total()

                .AutoSizeCols()
            End If
        End With


        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Total()
        Dim TotalNetto1 As Integer
        Dim TotalTarra As Integer
        Dim TotalNetto2 As Integer
        Dim TotalHarga As Integer
        Dim TotalBongkar As Integer
        Dim Asuransi As Integer

        Asuransi = DB.ExecuteScalarValue(Of Integer)(StrConnRMPApp," select isnull((select Asuransi from TblTrnAsuransiPembayaranSupplierKeToke where Trip=" & txtTrip.Text & " and IDPancang=" & cboPancang.SelectedValue & " and IDKapal=" & cboKapal.SelectedValue & "),0) as GetValueInteger ")

        With fg
            .AddItem("")

            For i = 2 To .Rows.Count - 2
                TotalNetto1 += .Item(i, 9)
                TotalTarra += .Item(i, 11)
                TotalNetto2 += .Item(i, 12)
                TotalHarga += .Item(i, 14)
                TotalBongkar += .Item(i, 16)
            Next

            .Item(.Rows.Count - 1, 8) = "Total"
            .Item(.Rows.Count - 1, 9) = TotalNetto1
            .Item(.Rows.Count - 1, 11) = TotalTarra
            .Item(.Rows.Count - 1, 12) = TotalNetto2
            .Item(.Rows.Count - 1, 14) = TotalHarga
            .Item(.Rows.Count - 1, 16) = TotalBongkar
            .Item(.Rows.Count - 1, 19) = Asuransi

            Dim lastRow As Integer = fg.Rows.Count - 1
            Dim rng = fg.GetCellRange(lastRow, 0, lastRow, fg.Cols.Count - 1)
            rng.StyleNew.BackColor = Color.Yellow
        End With
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Try
            Dim sql As String = "
            IF NOT EXISTS (
                SELECT 1 FROM TblTrnAsuransiPembayaranSupplierKeToke
                WHERE Trip=@Trip AND IDPancang=@IDPancang AND IDKapal=@IDKapal
            )
            BEGIN
                INSERT INTO TblTrnAsuransiPembayaranSupplierKeToke (IDPancang, IDKapal, Trip, Asuransi, LastUpdateBy, LastUpdateDate, Computer)
                VALUES (@IDPancang, @IDKapal, @Trip, @Asuransi, @User, GETDATE(), HOST_NAME())
            END
            ELSE
            BEGIN
                UPDATE TblTrnAsuransiPembayaranSupplierKeToke
                SET Asuransi=@Asuransi, LastUpdateBy=@User, LastUpdateDate=GETDATE(), Computer=HOST_NAME()
                WHERE Trip=@Trip AND IDPancang=@IDPancang AND IDKapal=@IDKapal
            END
            "

            Using conn As New SqlConnection(StrConnRMPApp)
                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@Trip", txtTrip.Text.Trim())
                    cmd.Parameters.AddWithValue("@IDPancang", cboPancang.SelectedValue)
                    cmd.Parameters.AddWithValue("@IDKapal", cboKapal.SelectedValue)
                    cmd.Parameters.AddWithValue("@User", ClsSession.UserID)

                    'Pastikan nilai Asuransi valid numerik
                    Dim asuransiVal As Decimal = 0
                    If fg.Item(fg.Rows.Count - 1, 19) IsNot Nothing AndAlso IsNumeric(fg.Item(fg.Rows.Count - 1, 19)) Then
                        asuransiVal = CDec(fg.Item(fg.Rows.Count - 1, 19))
                    End If
                    cmd.Parameters.AddWithValue("@Asuransi", asuransiVal)

                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
        End Try

        Dim filename As String
        Me.SaveFileDialog.ShowDialog()
        filename = SaveFileDialog.FileName
        Me.fg.SaveExcel(filename & ".xlsx", "Sheet1", FileFlags.IncludeFixedCells)
    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg.BeforeEdit
        ' hanya boleh edit baris terakhir & kolom ke-19
        e.Cancel = Not (e.Row = fg.Rows.Count - 1 AndAlso e.Col = 19)

        Try
            Dim val As Object = fg.Item(fg.Rows.Count - 1, 19)

            If val IsNot Nothing AndAlso IsNumeric(val) Then
                fg.Item(fg.Rows.Count - 1, 19) = Format(CDec(val), "#,##0")
            Else
                fg.Item(fg.Rows.Count - 1, 19) = ""
            End If

            fg.AutoSizeCols()
        Catch ex As Exception
        End Try
    End Sub
End Class