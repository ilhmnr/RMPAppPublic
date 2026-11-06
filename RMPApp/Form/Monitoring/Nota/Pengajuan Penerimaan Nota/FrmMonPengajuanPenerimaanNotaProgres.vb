Imports C1.Win.C1FlexGrid
Imports Microsoft.Office.Interop

Public Class FrmMonPengajuanPenerimaanNotaProgres
    Private Sub FrmMonApprovalPenerimaan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set ComboBox
        Modul_RMP.Combo.SetPancang(cboPancang)
        cboPancang.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboPancang.AutoCompleteSource = AutoCompleteSource.ListItems
        Modul_RMP.Combo.SetKapal(cboKapal)
        cboKapal.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboKapal.AutoCompleteSource = AutoCompleteSource.ListItems

        dtpTanggalNota1.Value = Date.Now.AddDays(-1)
        dtpTanggalNota2.Value = Date.Now.AddDays(-1)

        Call ClsFlexGrid.ApplyStyle(fg)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Me.Cursor = Cursors.WaitCursor

        Dim dt As New DataTable
        Dim i As Integer = 1
        Dim sql As String = "select NoNota,Trip,a.IDPancang,(cast(c.IDPancang as varchar(10))+'. '+c.Pancang) as Pancang,IDKapal,(cast(d.KapalID as varchar(10))+'. '+d.KapalName) as Kapal,Bongkar,Jenis,JenisKB,GradeSub,
                            IDPenerimaUang,PenerimaUang,b.NamaRekening,RekeningPenerima,b.JenisBank,Jenis+'-'+JenisKB as ItemName,Brutto,TarraJaring,Netto,
                            TarraPersen,NettoAkhir,HargaSil,HargaNego,Harga,TotalHarga,PPhProsen,PPhPotong,0 as Pinjaman,TotalRupiahAkhir,a.NoTransApprovalPengajuan,e.TanggalApproval ,a.TransDate
                            from RMPApp..TblTrnKelapaHdr as a
                            left join RSUPAccounting..TblRMMstRekRM as b on a.IDPenerimaUang=b.IDPetani and a.RekeningPenerima=b.NoRekening
                            inner join RMPApp..Android_tblMstPancang as c on a.IDPancang=c.IDPancang
                            inner join RMPApp..tblMstKapal as d on a.IDKapal=d.KapalID
                            left join RMPApp..TblTrnApprovalPenerimaanHdr as e on a.NoTransApprovalPengajuan=e.NoTrans
                            where a.Deleted=0 "

        If rdTanggalNota.Checked = True Then
            sql &= "and cast(TransDate as date) between '" & Format(dtpTanggalNota1.Value, "yyyy-MM-dd") & "' and '" & Format(dtpTanggalNota2.Value, "yyyy-MM-dd") & "' "
        ElseIf rdTanggalPengajuan.Checked = True Then
            sql &= "and cast(e.TanggalApproval as date) between '" & Format(dtpPengajuan1.Value, "yyyy-MM-dd") & "' and '" & Format(dtpPengajuan2.Value, "yyyy-MM-dd") & "' "
        End If

        If rdBelumTerima.Checked = True Then
            sql &= " and NoTransApprovalPengajuan is null"
        ElseIf rdSudahTerima.Checked = True Then
            sql &= " and NoTransApprovalPengajuan is not null"
        End If

        If txtTrip.Text <> "" Then
            sql &= " and Trip='" & txtTrip.Text & "'"
        End If

        If cboPancang.Text <> "" Then
            sql &= " and a.IDPancang='" & cboPancang.SelectedValue & "'"
        End If

        If cboKapal.Text <> "" Then
            sql &= " and IDKapal='" & cboKapal.SelectedValue & "'"
        End If

        If rdRSUP.Checked = True Then
            sql &= " and Tujuan='RSUP'"
        ElseIf rdPSG.Checked = True Then
            sql &= " and Tujuan='PSG'"
        ElseIf rdAllTujuan.Checked = True Then
            ' Tidak perlu menambahkan kondisi apapun untuk "All Tujuan"
        End If

        If rdJambul.Checked = True Then
            sql &= " and Jenis='Jambul'"

            If chkA6.Checked = True Then
                sql &= " and GradeSub='A6'"
            Else
                sql &= " and GradeSub='A'"
            End If
        ElseIf rdLicin.Checked = True Then
            sql &= " and Jenis='Licin'"

            If chkA6.Checked = True Then
                sql &= " and GradeSub='A6'"
            Else
                sql &= " and GradeSub='A'"
            End If
        ElseIf rdCungkil.Checked = True Then
            sql &= " and Jenis='Cungkil'"
        ElseIf rdAllJenis.Checked = True Then
            ' Tidak perlu menambahkan kondisi apapun untuk "All Jenis"
        End If

        If rdKBA.Checked = True Then
            sql &= " and JenisKB='KB-A'"
        ElseIf rdKBB.Checked = True Then
            sql &= " and JenisKB='KB-B'"
        ElseIf rdKC.Checked = True Then
            sql &= " and JenisKB='KC'"
        ElseIf rdAllGrade.Checked = True Then
            ' Tidak perlu menambahkan kondisi apapun untuk "All KB"
        End If

        sql &= " order by a.IDPancang,a.Trip"

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fg
            .Rows.Count = 1 ' Reset grid sebelum mengisi data baru

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "NoTrans") = row("NoTransApprovalPengajuan")
                    .Item(i, "TanggalPengajuan") = row("TanggalApproval")
                    .Item(i, "InvoiceNo") = row("NoNota")
                    .Item(i, "TanggalNota") = row("TransDate")
                    .Item(i, "IDPancang") = row("IDPancang")
                    .Item(i, "Pancang") = row("Pancang")
                    .Item(i, "IDKapal") = row("IDKapal")
                    .Item(i, "Kapal") = row("Kapal")
                    .Item(i, "Trip") = row("Trip")
                    .Item(i, "Tujuan") = row("Bongkar")
                    .Item(i, "Jenis") = row("Jenis")
                    .Item(i, "Grade") = row("JenisKB")
                    .Item(i, "GradeSub") = row("GradeSub")
                    .Item(i, "SupplierID") = row("IDPenerimaUang")
                    .Item(i, "SupplierName") = row("penerimaUang")
                    .Item(i, "RekeningName") = row("NamaRekening")
                    .Item(i, "RekeningNo") = row("RekeningPenerima")
                    .Item(i, "RekeningBank") = row("JenisBank")
                    .Item(i, "ItemName") = row("ItemName")
                    .Item(i, "Brutto") = row("Brutto")
                    .Item(i, "TarraJaring") = row("TarraJaring")
                    .Item(i, "Netto1") = row("Netto")
                    .Item(i, "Tarra%") = row("TarraPersen")
                    .Item(i, "Netto2") = row("NettoAkhir")
                    .Item(i, "HargaAwal") = row("HargaSil")
                    .Item(i, "HargaNego") = row("HargaNego")
                    .Item(i, "HargaBeli") = row("Harga")
                    .Item(i, "TotalRPBeforePPH") = row("TotalHarga")
                    .Item(i, "PPH%") = row("PPHProsen")
                    .Item(i, "PPHRP") = row("PPHPotong")
                    .Item(i, "Pinjaman") = row("Pinjaman")
                    .Item(i, "TotalRP") = row("TotalRupiahAkhir")

                    i += 1
                Next

                fg.Rows.Insert(1)

                ' === HITUNG TOTAL DAN TARUH DI ROW INDEX 1 ===
                Dim totalBrutto As Decimal = 0
                Dim totalTarraJaring As Decimal = 0
                Dim totalNetto1 As Decimal = 0
                Dim totalNetto2 As Decimal = 0
                Dim totalRPBeforePPH As Decimal = 0
                Dim totalPPHRP As Decimal = 0
                Dim totalRP As Decimal = 0
                Dim totalPinjaman As Decimal = 0

                For r As Integer = 1 To fg.Rows.Count - 1
                    totalBrutto += Val(fg.Item(r, "Brutto"))
                    totalTarraJaring += Val(fg.Item(r, "TarraJaring"))
                    totalNetto1 += Val(fg.Item(r, "Netto1"))
                    totalNetto2 += Val(fg.Item(r, "Netto2"))
                    totalRPBeforePPH += Val(fg.Item(r, "TotalRPBeforePPH"))
                    totalPPHRP += Val(fg.Item(r, "PPHRP"))
                    totalRP += Val(fg.Item(r, "TotalRP"))
                    totalPinjaman += Val(fg.Item(r, "Pinjaman"))
                Next

                ' === SET TOTAL DI ROW INDEX 1 ===
                fg.Item(1, "InvoiceNo") = "TOTAL"
                fg.Item(1, "Brutto") = totalBrutto
                fg.Item(1, "TarraJaring") = totalTarraJaring
                fg.Item(1, "Netto1") = totalNetto1
                fg.Item(1, "Netto2") = totalNetto2
                fg.Item(1, "TotalRPBeforePPH") = totalRPBeforePPH
                fg.Item(1, "PPHRP") = totalPPHRP
                fg.Item(1, "TotalRP") = totalRP
                fg.Item(1, "Pinjaman") = totalPinjaman

                ' KASIH WARNA AGAR JELAS BARIS TOTAL
                Dim s = fg.Styles.Add("TotalRow")
                s.BackColor = Color.LightYellow
                s.Font = New Font(fg.Font, FontStyle.Bold)
                fg.Rows(1).Style = s

                .AutoSizeCols()
            Else
                MsgBoxCustom.Show("Tidak ada data.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            End If
        End With

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnRekapExcel_Click(sender As Object, e As EventArgs) Handles btnRekapExcel.Click
        Try
            If fg.Rows.Count <= 1 Then
                MsgBoxCustom.Show("Data kosong.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            End If

            Using save As New SaveFileDialog
                save.Filter = "Excel File (*.xlsx)|*.xlsx"
                save.FileName = "MONITORING PROGRESS APPROVAL PEMBELIAN_" & Format(Now, "yyyyMMdd")

                If save.ShowDialog() = DialogResult.OK Then

                    ' === EXPORT LANGSUNG DARI GRID ===
                    ' otomatis hanya kolom Visible yang ikut
                    fg.SaveExcel(save.FileName, "Sheet1", FileFlags.IncludeFixedCells)

                    If IO.File.Exists(save.FileName) Then
                        MsgBoxCustom.Show("Export berhasil!", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                    Else
                        MsgBoxCustom.Show("Export gagal.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
                    End If
                End If
            End Using

        Catch ex As Exception
            MsgBoxCustom.Show("Error Export : " & ex.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
        End Try
    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg.BeforeEdit
        e.Cancel = True
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class