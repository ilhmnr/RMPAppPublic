Imports System.Globalization
Imports C1.Win.C1FlexGrid

Public Class FrmMonKapalCheckIndanOTW
    Private Sub FrmMonKapalCheckIndanOTW_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtp1.Value = Format(Now, "dd/MM/yyyy 06:00")
        dtp2.Value = Format(Now, "dd/MM/yyyy 06:00")
        Modul_RMP.Combo.SetPancang(cmbPancang)
        Modul_RMP.Combo.SetKapal(cmbKapal)
        Modul_RMP.Combo.SetJenis(cmbJenis)
        fg.Rows.Count = 1
        cmbPancang.Enabled = False
        cmbKapal.Enabled = False
        cmbJenis.Enabled = False
        cmbJenis.Text = ""
        Call HeaderFG()
    End Sub

    Public Sub HeaderFG()
        Dim txt As CellRange
        With fg
            .Rows.Count = 3
            .Rows.Fixed = 3
            .Cols.Fixed = 1
            .Rows.Count = 3
            .Cols.Count = 16

            .AutoGenerateColumns = True
            .Rows(0).AllowMerging = True
            .Rows(1).AllowMerging = True
            .Rows(2).AllowMerging = True
            .Styles.Normal.WordWrap = True

            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular)
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .AllowMerging = AllowMergingEnum.FixedOnly

            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

            .Rows(0).TextAlign = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 0, 2, 0) : txt.Data = "NO" : .Cols(0).Width = 50
            txt = .GetCellRange(0, 1, 1, 1) : txt.Data = "Tanggal" : .Cols(1).TextAlign = TextAlignEnum.CenterCenter : .Cols(1).AllowEditing = False : .Cols(0).AllowMerging = True
            txt = .GetCellRange(0, 2, 1, 2) : txt.Data = "Pancang" : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).AllowEditing = False : .Cols(1).AllowMerging = True
            txt = .GetCellRange(0, 3, 1, 3) : txt.Data = "Kapal" : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).AllowEditing = False : .Cols(2).AllowMerging = True
            txt = .GetCellRange(0, 4, 1, 4) : txt.Data = "Trip" : .Cols(4).TextAlign = TextAlignEnum.CenterCenter : .Cols(4).AllowEditing = False : .Cols(3).AllowMerging = True
            txt = .GetCellRange(0, 5, 1, 5) : txt.Data = "Tujuan" : .Cols(5).TextAlign = TextAlignEnum.CenterCenter : .Cols(5).AllowEditing = False : .Cols(4).AllowMerging = True

            txt = .GetCellRange(2, 1, 2, 5) : txt.Data = "TOTAL" : .Rows(2).TextAlign = TextAlignEnum.CenterCenter : .Cols(5).AllowEditing = False : .Cols(5).AllowMerging = True

            txt = .GetCellRange(0, 6, 0, 9) : txt.Data = "Kelapa Bulat / Kelapa Cungkil" : .Cols(6).TextAlign = TextAlignEnum.RightCenter : .Cols(6).AllowEditing = False
            txt = .GetCellRange(1, 6, 1, 6) : txt.Data = "Muatan N1" : .Cols(6).TextAlign = TextAlignEnum.RightCenter : .Cols(6).AllowEditing = False : .Cols(6).Format = "#,###0" : .Cols(6).AllowMerging = True
            txt = .GetCellRange(1, 7, 1, 7) : txt.Data = "Muatan N2" : .Cols(7).TextAlign = TextAlignEnum.RightCenter : .Cols(7).AllowEditing = False : .Cols(7).Format = "#,###0" : .Cols(7).AllowMerging = True
            txt = .GetCellRange(1, 8, 1, 8) : txt.Data = "Harga / Kg" : .Cols(8).TextAlign = TextAlignEnum.RightCenter : .Cols(8).AllowEditing = False : .Cols(8).Format = "#,###0" : .Cols(8).AllowMerging = True
            txt = .GetCellRange(1, 9, 1, 9) : txt.Data = "Rupiah" : .Cols(9).TextAlign = TextAlignEnum.RightCenter : .Cols(9).AllowEditing = False : .Cols(9).Format = "#,###0" : .Cols(9).Visible = True : .Cols(9).AllowMerging = True

            txt = .GetCellRange(0, 10, 0, 11) : txt.Data = "Tambang" : .Cols(10).TextAlign = TextAlignEnum.LeftCenter : .Cols(10).AllowEditing = False
            txt = .GetCellRange(1, 10, 1, 10) : txt.Data = "Harga / Kg" : .Cols(10).TextAlign = TextAlignEnum.RightCenter : .Cols(10).AllowEditing = False : .Cols(10).AllowMerging = True : .Cols(10).Format = "#,###0"
            txt = .GetCellRange(1, 11, 1, 11) : txt.Data = "Rupiah" : .Cols(11).TextAlign = TextAlignEnum.RightCenter : .Cols(11).AllowEditing = False : .Cols(11).AllowMerging = True : .Cols(11).Format = "#,###0"

            txt = .GetCellRange(0, 12, 1, 12) : txt.Data = "Total Harga / Kg" : .Cols(12).TextAlign = TextAlignEnum.RightCenter : .Cols(12).AllowEditing = False : .Cols(12).AllowMerging = True : .Cols(12).Format = "#,###0"
            txt = .GetCellRange(0, 13, 1, 13) : txt.Data = "Date Status" : .Cols(13).TextAlign = TextAlignEnum.LeftCenter : .Cols(13).AllowEditing = False : .Cols(13).AllowMerging = True
            txt = .GetCellRange(0, 14, 1, 14) : txt.Data = "Jenis" : .Cols(14).TextAlign = TextAlignEnum.LeftCenter : .Cols(14).AllowEditing = False : .Cols(14).AllowMerging = True
            txt = .GetCellRange(0, 15, 1, 15) : txt.Data = "Jenis Licin/Jambul" : .Cols(15).TextAlign = TextAlignEnum.LeftCenter : .Cols(15).AllowEditing = False : .Cols(15).AllowMerging = True

            .Rows(0).TextAlign = TextAlignEnum.CenterCenter
            .Rows(1).TextAlign = TextAlignEnum.CenterCenter

            .AutoSizeCols()
        End With
    End Sub

    Private Sub ShowData()
        Dim Tujuan As String
        Dim i As Integer = 3
        Dim sql As String = ""
        Dim dt As DataTable = New DataTable()
        Dim query As String = ""

        Try
            If chkP1.Checked = True Then
                Tujuan = "PSG"
            ElseIf chkP2.Checked = True Then
                Tujuan = "RSUP"
            End If

            If chkPancang.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, " A.IDPancang ='" & cmbPancang.SelectedValue.ToString & "' ")
            End If

            If chkKapal.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, " A.IDKapal = '" & cmbKapal.SelectedValue.ToString & "' ")
            End If

            If chkJenis.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, " a.Jenis = '" & cmbJenis.Text.ToString & "' ")
            End If

            If chkTransDate.Checked = True Then
                If rdCheckIn.Checked = True Then
                    sql = Modul_RMP.Func.SetCondition(sql, " (a.ChekinPabrik BETWEEN '" & Format(dtp1.Value, "yyyy-MM-dd HH:mm:00") & "' AND '" & Format(dtp2.Value, "yyyy-MM-dd HH:mm:00") & "') ")
                Else
                    sql = Modul_RMP.Func.SetCondition(sql, " (a.BerangkatDate BETWEEN '" & Format(dtp1.Value, "yyyy-MM-dd HH:mm:00") & "' AND '" & Format(dtp2.Value, "yyyy-MM-dd HH:mm:00") & "') ")
                End If
            End If

            If rdOTW.Checked = True Then
                query = " with tripBokingMuatPancang as (
                                select a.IDPancang,a.Pancang,a.TripID,a.BerangkatDate,a.Tujuan,a.IDKapal,a.NamaKapal,a.JenisMuat,sum(c.Netto) AS MuatanN1,sum(c.NettoAkhir) AS MuatanN2,sum(c.TotalHarga) AS Rupiah,d.ID_Jenis,
                                isnull(e.Crane,0) as FlagKapalCrane,c.Jenis
                                from RMPApp..vwTripBookingMuatPancang as a left outer join 
                                RMPApp..TblTrnKelapaHdr as c on A.TripID = C.Trip AND  A.TUJUAN = C.Bongkar AND A.IDKapal =C.IDKapal AND  A.JENISMUAT=C.JenisKB AND C.IDPancang = A.IDPancang and (deleted=0 or deleted is null) left outer join 
                                RMPApp..tblMstJenisKelapa as d on a.JenisMuat=d.Jenis left outer join 
                                RMPApp..tblMstKapal as e on a.IDKapal=e.KapalID
                                group by a.IDPancang,a.Pancang,a.TripID,a.BerangkatDate,a.Tujuan,a.IDKapal,a.NamaKapal,a.JenisMuat,d.ID_Jenis,e.Crane,c.Jenis
                                ) 

                                select cast(a.BerangkatDate as date) as TanggalOtw,a.Pancang,a.NamaKapal as Kapal,a.TripID as Trip,a.Tujuan,ISNULL(a.MuatanN1,0) as MuatanN1,isnull(a.MuatanN2,0) as MuatanN2,isnull(a.Rupiah/MuatanN2,0) as HargaPerKgKelapa,isnull(a.Rupiah,0) as RupiahKelapa,
                                case 
                                when a.Tujuan='RSUP' and a.FlagKapalCrane=1 then 
                                (select top 1 isnull(UpahTambangKapalCrane,0) from tblMstTambangKapal where IDPancang=a.IDPancang and JenisBahanBaku=a.ID_Jenis and isnull(UpahTambangKapalCrane,0) > 0 and cast(Periode as date)<=cast(a.BerangkatDate as date) order by Periode desc)
								when a.Tujuan='RSUP' and a.FlagKapalCrane=0 then 
                                (select top 1 isnull(UpahTambang,0) from tblMstTambangKapal where IDPancang=a.IDPancang and JenisBahanBaku=a.ID_Jenis and isnull(UpahTambang,0) > 0 and cast(Periode as date)<=cast(a.BerangkatDate as date) order by Periode desc)
								when a.Tujuan='PSG' and a.FlagKapalCrane=1 then 
                                (select top 1 isnull(UpahTambangKapalCrane,0) from tblMstTambangKapalP1 where IDPancang=a.IDPancang and JenisBahanBaku=a.ID_Jenis and isnull(UpahTambangKapalCrane,0) > 0 and cast(Periode as date)<=cast(a.BerangkatDate as date) order by Periode desc)
								when a.Tujuan='PSG' and a.FlagKapalCrane=0 then 
                                (select top 1 isnull(UpahTambang,0) from tblMstTambangKapalP1 where IDPancang=a.IDPancang and JenisBahanBaku=a.ID_Jenis and isnull(UpahTambang,0) > 0 and cast(Periode as date)<=cast(a.BerangkatDate as date) order by Periode desc)
                                end HargaPerKgTambang,
                                FORMAT(a.BerangkatDate,'yyyy-MM-dd HH:mm') as DateStatusOtw,a.JenisMuat,isnull(a.Jenis,'') as Jenis
                                from tripBokingMuatPancang as a
                                where 1=1 " & IIf(sql = "", "", " AND " & sql) & " " & IIf(chkAll.Checked = False, " and a.Tujuan='" & Tujuan & "' ", "") & "
                                order by a.BerangkatDate "
            Else
                query = " with tripBokingMuatPancang as (
                                select a.IDPancang,a.Pancang,a.TripID,a.ChekinPabrik,a.Tujuan,a.IDKapal,a.NamaKapal,a.JenisMuat,sum(c.Netto) AS MuatanN1,sum(c.NettoAkhir) AS MuatanN2,sum(c.TotalHarga) AS Rupiah,d.ID_Jenis,
                                isnull(e.Crane,0) as FlagKapalCrane,c.Jenis
                                from RMPApp..vwTripBookingMuatPancang as a left outer join 
                                RMPApp..TblTrnKelapaHdr as c on A.TripID = C.Trip AND  A.TUJUAN = C.Bongkar AND A.IDKapal =C.IDKapal AND  A.JENISMUAT=C.JenisKB AND C.IDPancang = A.IDPancang and (deleted=0 or deleted is null) left outer join 
                                RMPApp..tblMstJenisKelapa as d on a.JenisMuat=d.Jenis left outer join 
                                RMPApp..tblMstKapal as e on a.IDKapal=e.KapalID
                                group by a.IDPancang,a.Pancang,a.TripID,a.ChekinPabrik,a.Tujuan,a.IDKapal,a.NamaKapal,a.JenisMuat,d.ID_Jenis,e.Crane,c.Jenis
                                ) 

                                select cast(a.ChekinPabrik as date) as TanggalCheckIn,a.Pancang,a.NamaKapal as Kapal,a.TripID as Trip,a.Tujuan,ISNULL(a.MuatanN1,0) as MuatanN1,isnull(a.MuatanN2,0) as MuatanN2,isnull(a.Rupiah/MuatanN2,0) as HargaPerKgKelapa,isnull(a.Rupiah,0) as RupiahKelapa,
                                case 
                                when a.Tujuan='RSUP' and a.FlagKapalCrane=1 then 
                                (select top 1 isnull(UpahTambangKapalCrane,0) from tblMstTambangKapal where IDPancang=a.IDPancang and JenisBahanBaku=a.ID_Jenis and isnull(UpahTambangKapalCrane,0) > 0 and cast(Periode as date)<=cast(a.ChekinPabrik as date) order by Periode desc)
								when a.Tujuan='RSUP' and a.FlagKapalCrane=0 then 
                                (select top 1 isnull(UpahTambang,0) from tblMstTambangKapal where IDPancang=a.IDPancang and JenisBahanBaku=a.ID_Jenis and isnull(UpahTambang,0) > 0 and cast(Periode as date)<=cast(a.ChekinPabrik as date) order by Periode desc)
								when a.Tujuan='PSG' and a.FlagKapalCrane=1 then 
                                (select top 1 isnull(UpahTambangKapalCrane,0) from tblMstTambangKapalP1 where IDPancang=a.IDPancang and JenisBahanBaku=a.ID_Jenis and isnull(UpahTambangKapalCrane,0) > 0 and cast(Periode as date)<=cast(a.ChekinPabrik as date) order by Periode desc)
								when a.Tujuan='PSG' and a.FlagKapalCrane=0 then 
                                (select top 1 isnull(UpahTambang,0) from tblMstTambangKapalP1 where IDPancang=a.IDPancang and JenisBahanBaku=a.ID_Jenis and isnull(UpahTambang,0) > 0 and cast(Periode as date)<=cast(a.ChekinPabrik as date) order by Periode desc)
                                end HargaPerKgTambang,
                                FORMAT(a.ChekinPabrik,'yyyy-MM-dd HH:mm') as DateStatusCheckin,a.JenisMuat,isnull(a.Jenis,'') as Jenis
                                from tripBokingMuatPancang as a
                                where 1=1 " & IIf(sql = "", "", " AND " & sql) & " " & IIf(chkAll.Checked = False, " and a.Tujuan='" & Tujuan & "' ", "") & "
                                order by a.ChekinPabrik "
            End If


            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, query)

            If dt.Rows.Count > 0 Then
                With fg
                    fg.Rows.Count = 3
                    For Each row As DataRow In dt.Rows
                        .AddItem(i - 2)
                        If rdOTW.Checked = True Then
                            .Item(i, 1) = row.Item("TanggalOtw")
                        Else
                            .Item(i, 1) = row.Item("TanggalCheckIn")
                        End If
                        .Item(i, 2) = row.Item("Pancang")
                        .Item(i, 3) = row.Item("Kapal")
                        .Item(i, 4) = row.Item("Trip")
                        .Item(i, 5) = row.Item("Tujuan")
                        .Item(i, 6) = row.Item("MuatanN1")
                        .Item(i, 7) = row.Item("MuatanN2")
                        .Item(i, 8) = row.Item("HargaPerKgKelapa")
                        .Item(i, 9) = row.Item("RupiahKelapa")
                        If IsDBNull(row.Item("HargaPerKgTambang")) Then
                            .Rows(i).StyleNew.BackColor = Color.FromArgb(255, 192, 192)
                            .Rows(i).StyleNew.ForeColor = Color.Black
                            .Item(i, 10) = 0
                            .Item(i, 11) = row.Item("MuatanN1") * 0
                            .Item(i, 12) = Convert.ToInt64(row.Item("HargaPerKgKelapa") + 0)
                        Else
                            .Item(i, 10) = row.Item("HargaPerKgTambang")
                            .Item(i, 11) = row.Item("MuatanN1") * row.Item("HargaPerKgTambang")
                            .Item(i, 12) = Convert.ToInt64(row.Item("HargaPerKgKelapa") + row.Item("HargaPerKgTambang"))
                        End If
                        If rdOTW.Checked = True Then
                            .Item(i, 1) = row.Item("DateStatusOtw")
                        Else
                            .Item(i, 1) = row.Item("DateStatusCheckin")
                        End If
                        .Item(i, 14) = row.Item("JenisMuat")
                        .Item(i, 15) = row.Item("Jenis")
                        i = i + 1
                    Next

                    Call sumHasil()

                    .AutoSizeCols()
                End With
            Else
                MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
            End If
        Catch EX As Exception
            MsgBox(EX.Message)
        End Try
    End Sub

    Private Sub sumHasil()
        Dim totMuatanN1, totMuatanN2, totRupiahKelapa, totRupiahTambang, totHargaPerKg As Int64

        With fg
            For i = 3 To .Rows.Count - 1
                totMuatanN1 += .Item(i, 6)
                totMuatanN2 += .Item(i, 7)
                totRupiahKelapa += .Item(i, 9)
                totRupiahTambang += .Item(i, 11)
            Next

            .Item(2, 6) = totMuatanN1.ToString("N0", New CultureInfo("id-ID"))
            .Item(2, 7) = totMuatanN2.ToString("N0", New CultureInfo("id-ID"))
            .Item(2, 9) = totRupiahKelapa.ToString("N0", New CultureInfo("id-ID"))
            .Item(2, 11) = totRupiahTambang.ToString("N0", New CultureInfo("id-ID"))

            .Item(2, 8) = Convert.ToInt64(totRupiahKelapa / totMuatanN2).ToString("N0", New CultureInfo("id-ID"))
            .Item(2, 10) = Convert.ToInt64(totRupiahTambang / totMuatanN1).ToString("N0", New CultureInfo("id-ID"))
            totHargaPerKg = (CInt(.Item(2, 8)) + CInt(.Item(2, 10)))
            .Item(2, 12) = totHargaPerKg.ToString("N0", New CultureInfo("id-ID"))
        End With
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If chkP1.Checked = False And chkP2.Checked = False And chkAll.Checked = False Then
            MsgBox("Silahkan Ceklis Pilihan P1, P2 atau All !", MsgBoxStyle.Exclamation, AT)
            Exit Sub
        End If

        Call ShowData()
    End Sub

    Private Sub chkP1_CheckedChanged(sender As Object, e As EventArgs) Handles chkP1.CheckedChanged
        If chkP1.Checked = True Then
            chkP2.Checked = False
            chkAll.Checked = False
            Call clearTotal()
        End If
    End Sub

    Private Sub chkP2_CheckedChanged(sender As Object, e As EventArgs) Handles chkP2.CheckedChanged
        If chkP2.Checked = True Then
            chkP1.Checked = False
            chkAll.Checked = False
            Call clearTotal()
        End If
    End Sub

    Private Sub chkAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkAll.CheckedChanged
        If chkAll.Checked = True Then
            chkP1.Checked = False
            chkP2.Checked = False
            Call clearTotal()
        End If
    End Sub

    Private Sub chkPancang_CheckedChanged(sender As Object, e As EventArgs) Handles chkPancang.CheckedChanged

        If chkPancang.Checked = True Then
            cmbPancang.Enabled = True
        Else
            cmbPancang.Enabled = False
            cmbPancang.Text = ""
        End If

    End Sub

    Private Sub chkKapal_CheckedChanged(sender As Object, e As EventArgs) Handles chkKapal.CheckedChanged

        If chkKapal.Checked = True Then
            cmbKapal.Enabled = True
        Else
            cmbKapal.Enabled = False
            cmbKapal.Text = ""
        End If

    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click

        Dim filename As String
        Me.SaveFileDialog.ShowDialog()
        filename = SaveFileDialog.FileName
        Me.fg.SaveExcel(filename & ".xls", "Sheet1", FileFlags.IncludeFixedCells)

    End Sub

    Private Sub rdCheckIn_CheckedChanged(sender As Object, e As EventArgs) Handles rdCheckIn.CheckedChanged
        Call clearTotal()

    End Sub

    Private Sub rdOTW_CheckedChanged(sender As Object, e As EventArgs) Handles rdOTW.CheckedChanged
        Call clearTotal()
    End Sub

    Private Sub clearTotal()
        fg.Rows.Count = 3
        fg.Item(2, 6) = ""
        fg.Item(2, 7) = ""
        fg.Item(2, 8) = ""
        fg.Item(2, 9) = ""
        fg.Item(2, 10) = ""
        fg.Item(2, 11) = ""
        fg.Item(2, 12) = ""
    End Sub

    Private Sub fg_AfterSelChange(sender As Object, e As RangeEventArgs) Handles fg.AfterSelChange

        Dim sum As Double
        Dim R, c As Integer
        With fg
            If .Row = 0 Then Exit Sub
            If .RowSel > .Row Then
                For R = .Row To .RowSel
                    If (R > 0) And (R <= (.Rows.Count - 1)) Then
                        For c = .Col To .ColSel
                            Select Case c
                                Case 6, 7, 8, 9, 10, 11
                                    If Trim(.Item(R, c) <> 0) Then
                                        sum = sum + CDbl(.Item(R, c))
                                    End If
                            End Select
                        Next
                    End If
                Next
            End If
        End With
        txtTotal.Text = FormatNumber(sum, 0)

    End Sub

    Private Sub cmbPancang_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbPancang.KeyUp

        UI.AutoCompleteCombo_KeyUp(cmbPancang, e)

    End Sub

    Private Sub cmbKapal_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbKapal.KeyUp

        UI.AutoCompleteCombo_KeyUp(cmbKapal, e)

    End Sub

    Private Sub chkJenis_CheckedChanged(sender As Object, e As EventArgs) Handles chkJenis.CheckedChanged
        If chkJenis.Checked = True Then
            cmbJenis.Enabled = True
        Else
            cmbJenis.Enabled = False
            cmbJenis.Text = ""
        End If
    End Sub

End Class