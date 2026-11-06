Imports C1.Win.C1FlexGrid

Public Class FrmMstHargaBeliBahanBakuStatusAktif
    Dim aksi As String = ""

    Private Sub FrmMstStatusAktifHargaBahanBaku_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboPancang.DropDownStyle = ComboBoxStyle.DropDown ' Penting agar bisa ketik manual
        cboPancang.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboPancang.AutoCompleteSource = AutoCompleteSource.ListItems
        Modul_RMP.Combo.SetPancang(cboPancang)

        cboJenisBahanBaku.DropDownStyle = ComboBoxStyle.DropDown ' Penting agar bisa ketik manual
        cboJenisBahanBaku.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboJenisBahanBaku.AutoCompleteSource = AutoCompleteSource.ListItems
        Combo.SetJenis(cboJenisBahanBaku)

        Call HeaderFg()

        Call LoadData()

        btnRefresh.Enabled = True
        btnEdit.Enabled = True
        btnsave.Enabled = False
        btnCancel.Enabled = False
    End Sub

    Private Sub HeaderFg()
        Dim txt As CellRange

        With fg
            .Rows.Fixed = 1
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Cols.Count = 11

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

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "No" : .Cols(0).TextAlign = TextAlignEnum.LeftCenter : .Cols(0).AllowEditing = True
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Pilih" : .Cols(1).Visible = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "ID Pancang" : .Cols(2).Visible = False
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Pancang" : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).AllowEditing = True
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Kode Jenis Bahan BAku" : .Cols(4).Visible = False
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Jenis Bahan Baku" : .Cols(5).TextAlign = TextAlignEnum.LeftCenter : .Cols(5).AllowEditing = True
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Bongkar Via" : .Cols(6).TextAlign = TextAlignEnum.LeftCenter : .Cols(6).AllowEditing = True
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Status Aktif" : .Cols(7).TextAlign = TextAlignEnum.LeftCenter : .Cols(7).AllowEditing = True
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Created By" : .Cols(8).TextAlign = TextAlignEnum.LeftCenter : .Cols(8).AllowEditing = True
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Created Date" : .Cols(9).TextAlign = TextAlignEnum.LeftCenter : .Cols(9).AllowEditing = True
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "DetailID" : .Cols(10).Visible = False

            .AutoSizeCols()
        End With
    End Sub

    Private Sub LoadData()
        Dim dt As DataTable = New DataTable
        Dim i As Integer = 1

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "with cte as (
                                                            SELECT IDPancang,Pancang,1 as KodeJenisBahanBaku,'Jambul' as JenisBahanBaku,'Laut' as BongkarVia from Android_tblMstPancang 
                                                            union
                                                            SELECT IDPancang,Pancang,1 as KodeJenisBahanBaku,'Jambul' as JenisBahanBaku,'Darat' as BongkarVia from Android_tblMstPancang 
                                                            union
                                                            SELECT IDPancang,Pancang,2 as KodeJenisBahanBaku,'Licin' as JenisBahanBaku,'Laut' as BongkarVia from Android_tblMstPancang 
                                                            union
                                                            SELECT IDPancang,Pancang,2 as KodeJenisBahanBaku,'Licin' as JenisBahanBaku,'Darat' as BongkarVia from Android_tblMstPancang 
                                                            union
                                                            SELECT IDPancang,Pancang,4 as KodeJenisBahanBaku,'Cungkil' as JenisBahanBaku,'Laut' as BongkarVia from Android_tblMstPancang 
                                                            union
                                                            SELECT IDPancang,Pancang,4 as KodeJenisBahanBaku,'Cungkil' as JenisBahanBaku,'Darat' as BongkarVia from Android_tblMstPancang 
                                                            )

                                                            select 
                                                            a.IDPancang,a.Pancang,a.KodeJenisBahanBaku,a.JenisBahanBaku,a.BongkarVia,b.StatusAktif,b.CreatedBy,b.CreatedDate,b.Computer,isnull(b.DetailID,0) as DetailID
                                                            from cte as a left join 
                                                            TblMstStatusAktifHargaBahanBakuPcg as b on a.IDPancang=b.IDPancang and a.KodeJenisBahanBaku=b.KodeJenisBahanBaku and a.BongkarVia=b.BongkarVia and b.Deleted=0
                                                            where 1=1
                                                            " & IIf(cboPancang.Text <> "", " and a.IDPancang = " & cboPancang.SelectedValue & " ", "") & "
                                                            " & IIf(cboJenisBahanBaku.Text <> "", " and a.KodeJenisBahanBaku = " & cboJenisBahanBaku.SelectedValue & " ", "") & "
                                                            " & IIf(cboBongkarVia.Text <> "", " and a.BongkarVia = '" & cboBongkarVia.Text & "' ", "") & "
                                                            order by a.IDPancang,a.KodeJenisBahanBaku,a.BongkarVia")

        If dt.Rows.Count > 0 Then
            With fg
                .Rows.Count = 1

                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, 1) = False
                    .Item(i, 2) = row("IDPancang")
                    .Item(i, 3) = row("Pancang")
                    .Item(i, 4) = row("KodeJenisBahanBaku")
                    .Item(i, 5) = row("JenisBahanBaku")
                    .Item(i, 6) = row("BongkarVia")
                    .Item(i, 7) = row("StatusAktif")
                    .Item(i, 8) = row("CreatedBy")
                    .Item(i, 9) = row("CreatedDate")
                    .Item(i, 10) = row("DetailID")

                    i += 1
                Next

                .AutoSizeCols()
            End With
        Else
            MsgBoxCustom.Show("Data tidak ditemukan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Call LoadData()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        aksi = "EDIT"

        cboPancang.Enabled = False
        cboJenisBahanBaku.Enabled = False
        cboBongkarVia.Enabled = False

        btnRefresh.Enabled = False
        btnEdit.Enabled = False
        btnsave.Enabled = True
        btnCancel.Enabled = True

        fg.Cols(1).Visible = True
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        With fg
            If .Rows.Count > 1 Then
                For row = 1 To .Rows.Count - 1
                    If CBool(.Item(row, 1)) = True Then
                        DB.ExecuteQuery(StrConnRMPApp, "update TblMstStatusAktifHargaBahanBakuPcg set Deleted = 1 where DetailID = " & .Item(row, 10) & "

                                                                        insert into TblMstStatusAktifHargaBahanBakuPcg (IDPancang,Pancang,KodeJenisBahanBaku,JenisBahanBaku,BongkarVia,StatusAktif,CreatedBy,CreatedDate,Computer,Deleted)
                                                                        values (" & .Item(row, 2) & ",'" & .Item(row, 3) & "'," & .Item(row, 4) & ",'" & .Item(row, 5) & "','" & .Item(row, 6) & "'," & IIf(CBool(.Item(row, 7)) = True, 1, 0) & ",'" & ClsSession.UserID & "',getdate(),host_name(),0)")
                    End If
                Next
            End If
        End With

        MsgBoxCustom.Show("Data berhasil disimpan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)

        aksi = ""

        cboPancang.Enabled = True
        cboJenisBahanBaku.Enabled = True
        cboBongkarVia.Enabled = True

        btnRefresh.Enabled = True
        btnEdit.Enabled = True
        btnsave.Enabled = False
        btnCancel.Enabled = False

        fg.Cols(1).Visible = False

        Call LoadData()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        aksi = ""

        cboPancang.Enabled = True
        cboJenisBahanBaku.Enabled = True
        cboBongkarVia.Enabled = True

        btnRefresh.Enabled = True
        btnEdit.Enabled = True
        btnsave.Enabled = False
        btnCancel.Enabled = False

        fg.Cols(1).Visible = False

        Call LoadData()
    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg.BeforeEdit
        ' Hanya kolom 1 dan 7 yang bisa di-edit
        If e.Col = 1 And aksi = "EDIT" Then
            e.Cancel = False ' Kolom 1 bebas edit
        ElseIf e.Col = 7 And aksi = "EDIT" Then
            ' Kolom 7 hanya bisa edit jika kolom 1 di baris ini = True
            If CBool(fg.Item(fg.RowSel, 1)) = True Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = True ' Kolom lain tidak bisa edit
        End If
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Me.Close()
    End Sub
End Class