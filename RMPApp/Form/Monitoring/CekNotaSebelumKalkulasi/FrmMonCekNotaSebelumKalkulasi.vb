Imports C1.Win.C1FlexGrid
Imports DocumentFormat.OpenXml.EMMA
Imports WeifenLuo.WinFormsUI.Docking

Public Class FrmMonCekNotaSebelumKalkulasi
    Dim txt As CellRange
    Private Sub FrmMonCekNotaSebelumKalkulasi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbPancang.DropDownStyle = ComboBoxStyle.DropDown
        cmbPancang.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cmbPancang.AutoCompleteSource = AutoCompleteSource.ListItems

        cmbKapal.DropDownStyle = ComboBoxStyle.DropDown
        cmbKapal.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cmbKapal.AutoCompleteSource = AutoCompleteSource.ListItems

        Call Modul_RMP.Combo.SetPancang(cmbPancang)
        Call Modul_RMP.Combo.SetKapal(cmbKapal)

        Call HeaderFg()
        Call HeaderFg2()
    End Sub

    Private Sub HeaderFg()
        With fg
            .Rows.Fixed = 1
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Cols.Count = 9

            .AutoGenerateColumns = True
            .Rows(0).AllowMerging = True
            .Styles.Normal.WordWrap = True

            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular)
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .AllowMerging = AllowMergingEnum.FixedOnly

            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

            .Rows(0).TextAlign = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).TextAlign = TextAlignEnum.LeftCenter : .Cols(0).AllowEditing = False
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "No Nota" : .Cols(1).TextAlign = TextAlignEnum.LeftCenter : .Cols(1).AllowEditing = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Pancang" : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).AllowEditing = False
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Trip" : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).AllowEditing = False
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Kapal" : .Cols(4).TextAlign = TextAlignEnum.LeftCenter : .Cols(4).AllowEditing = False
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Bongkar" : .Cols(5).TextAlign = TextAlignEnum.LeftCenter : .Cols(5).AllowEditing = False
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Jensi" : .Cols(6).TextAlign = TextAlignEnum.LeftCenter : .Cols(6).AllowEditing = False
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Jenis KB" : .Cols(7).TextAlign = TextAlignEnum.LeftCenter : .Cols(7).AllowEditing = False
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Grade Sub" : .Cols(8).TextAlign = TextAlignEnum.LeftCenter : .Cols(8).AllowEditing = False

            .AutoSizeCols()
        End With
    End Sub

    Private Sub HeaderFg2()
        With fg2
            .Rows.Fixed = 1
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Cols.Count = 15

            .AutoGenerateColumns = True
            .Rows(0).AllowMerging = True
            .Styles.Normal.WordWrap = True

            .Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular)
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .AllowMerging = AllowMergingEnum.FixedOnly

            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

            .Rows(0).TextAlign = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).TextAlign = TextAlignEnum.LeftCenter : .Cols(0).AllowEditing = False
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "No Nota" : .Cols(1).TextAlign = TextAlignEnum.LeftCenter : .Cols(1).AllowEditing = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Pancang" : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).AllowEditing = False
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Trip" : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).AllowEditing = False
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Kapal" : .Cols(4).TextAlign = TextAlignEnum.LeftCenter : .Cols(4).AllowEditing = False
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Bongkar" : .Cols(5).TextAlign = TextAlignEnum.LeftCenter : .Cols(5).AllowEditing = False
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Jenis" : .Cols(6).TextAlign = TextAlignEnum.LeftCenter : .Cols(6).AllowEditing = False
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Jenis KB" : .Cols(7).TextAlign = TextAlignEnum.LeftCenter : .Cols(7).AllowEditing = False
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Grade Sub" : .Cols(8).TextAlign = TextAlignEnum.LeftCenter : .Cols(8).AllowEditing = False
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Pengajuan UM" : .Cols(9).TextAlign = TextAlignEnum.LeftCenter : .Cols(9).AllowEditing = False
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "Status Kalkulasi" : .Cols(10).TextAlign = TextAlignEnum.LeftCenter : .Cols(10).AllowEditing = False
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "Status UM" : .Cols(11).TextAlign = TextAlignEnum.LeftCenter : .Cols(11).AllowEditing = False
            txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "Status Transfer" : .Cols(12).TextAlign = TextAlignEnum.LeftCenter : .Cols(12).AllowEditing = False
            txt = .GetCellRange(0, 13, 0, 13) : txt.Data = "Tanggal Masuk Kapal" : .Cols(13).TextAlign = TextAlignEnum.LeftCenter : .Cols(13).AllowEditing = False
            txt = .GetCellRange(0, 14, 0, 14) : txt.Data = "Type Pembayaran" : .Cols(14).TextAlign = TextAlignEnum.LeftCenter : .Cols(14).AllowEditing = False

            .AutoSizeCols()
        End With
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Me.Cursor = Cursors.WaitCursor
        Call LoadData()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LoadData()
        Dim dt As DataTable = New DataTable
        Dim i As Integer = 1

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp,
            "select NoNota,cast(a.IDPancang as varchar(3))+'. '+Pancang as Pancang,Trip,cast(IDKapal as varchar(50))+'. '+b.KapalName as Kapal,Bongkar,Jenis,JenisKB,GradeSub from TblTrnKelapaHdr as a inner join tblMstKapal as b on a.IDKapal=b.KapalID 
                where Deleted=0
                AND a.idpancang=" & cmbPancang.SelectedValue & "
                and trip=" & txtTrip.Text & " 
                and IDKapal=" & cmbKapal.SelectedValue & "
                and Bongkar='" & IIf(rdP1.Checked = True, "PSG", "RSUP") & "' 
                and GradeSub='" & IIf(ChkA6.Checked = True, "A6", "A") & "'
                and Jenis='" & IIf(rdLicin.Checked = True, "Licin", "Jambul") & "'
                AND JenisKB='" & IIf(rdKBA.Checked = True, "KB-A", "KB-B") & "'
                ORDER BY IDRelasi,TANGGALNOTA,NoTrans,IDUMPcg,NoNota asc")

        With fg
            .Rows.Count = 1

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, 1) = row("NoNota")
                    .Item(i, 2) = row("Pancang")
                    .Item(i, 3) = row("Trip")
                    .Item(i, 4) = row("Kapal")
                    .Item(i, 5) = row("Bongkar")
                    .Item(i, 6) = row("Jenis")
                    .Item(i, 7) = row("JenisKB")
                    .Item(i, 8) = row("GradeSub")

                    i += 1
                Next

                .AutoSizeCols()
            Else
                MsgBox("Tidak Ada Data Di Temukan.", vbInformation, AT)
            End If
        End With

        i = 1

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp,
            "SELECT NoNota,cast(IDPancang as varchar(3))+'. '+Pancang as Pancang,Trip,cast(IDKapal as varchar(50))+'. '+Kapal as Kapal,Bongkar,Jenis,JenisKB,GradeSub
                ,case when isnull(IDUMPcg,0)>0 then 'Sudah Di Ajukan' else 'Belum Di Ajukan' end as PengajuanUM,
                IndNota,IndUM,isnull(Trf,0) as Trf,TglMasukKapal,case when isnull(Type,0)=2 then 'KONTAN' when isnull(Type,0)=1 then 'TOKE' else '' end as Type FROM vwTMBGKelapaHdr102025
                where Deleted=0
                AND idpancang=" & cmbPancang.SelectedValue & "
                and trip=" & txtTrip.Text & " 
                and IDKapal=" & cmbKapal.SelectedValue & "
                and Bongkar='" & IIf(rdP1.Checked = True, "PSG", "RSUP") & "' 
                and GradeSub='" & IIf(ChkA6.Checked = True, "A6", "A") & "'
                and Jenis='" & IIf(rdLicin.Checked = True, "Licin", "Jambul") & "'
                AND JenisKB='" & IIf(rdKBA.Checked = True, "KB-A", "KB-B") & "'
                ORDER BY IDRelasi,TANGGALNOTA,NoTrans,IDUMPcg,NoNota asc")

        With fg2
            .Rows.Count = 1

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, 1) = row("NoNota")
                    .Item(i, 2) = row("Pancang")
                    .Item(i, 3) = row("Trip")
                    .Item(i, 4) = row("Kapal")
                    .Item(i, 5) = row("Bongkar")
                    .Item(i, 6) = row("Jenis")
                    .Item(i, 7) = row("JenisKB")
                    .Item(i, 8) = row("GradeSub")
                    .Item(i, 9) = row("PengajuanUM")
                    .Item(i, 10) = row("IndNota")
                    .Item(i, 11) = row("IndUM")
                    .Item(i, 12) = row("Trf")
                    .Item(i, 13) = row("TglMasukKapal")
                    .Item(i, 14) = row("Type")

                    If row("PengajuanUM") = "Belum Di Ajukan" Or row("IndNota") = True Or row("IndUM") = False Or row("Trf") = False Or IsDBNull(row("TglMasukKapal")) Or row("Type") = "" Then
                        .Rows(i).StyleNew.BackColor = Color.FromArgb(255, 192, 192) ' Warna merah muda
                    End If

                    i += 1
                Next

                .AutoSizeCols()
            Else
                MsgBox("Tidak Ada Data Di Temukan.", vbInformation, AT)
            End If
        End With
    End Sub

    Private Sub FrmMonCekNotaSebelumKalkulasi_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        ' ukuran lebar pnl1 setengah dari form
        Pnl1.Width = Me.Width / 2
    End Sub
End Class