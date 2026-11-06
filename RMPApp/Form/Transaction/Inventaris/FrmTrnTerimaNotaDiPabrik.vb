Imports System.Runtime.CompilerServices
Imports C1.Util.DX.Direct3D11
Imports C1.Win.C1FlexGrid
Imports Microsoft.Vbe.Interop

Public Class FrmTrnTerimaNotaDiPabrik
    Private Sub FrmTrnTerimaNotaDiPabrik_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call HeaderFg()
        Combo.SetPancang(CmbPancang)

        dtp1.Value = Format(dtp1.Value, "01/MM/yyyy")
        dtp2.Value = DateTime.DaysInMonth(dtp2.Value.Year, dtp2.Value.Month) & Format(dtp1.Value, "/MM/yyyy")
    End Sub

    Private Sub HeaderFg()
        Dim txt As CellRange

        With fg
            .Rows.Fixed = 1
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Cols.Count = 16

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
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Pilih"
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Tanggal Terima" : .Cols(2).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Tanggal Nota" : .Cols(3).TextAlign = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Pancang" : .Cols(4).TextAlign = TextAlignEnum.LeftCenter : .Cols(4).AllowEditing = False
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Kode Transaksi" : .Cols(5).TextAlign = TextAlignEnum.CenterCenter : .Cols(5).AllowEditing = False
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Item" : .Cols(6).TextAlign = TextAlignEnum.LeftCenter : .Cols(6).AllowEditing = False
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Harga" : .Cols(7).TextAlign = TextAlignEnum.CenterCenter : .Cols(7).AllowEditing = False : .Cols(7).Format = "#,###0"
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Quantity" : .Cols(8).TextAlign = TextAlignEnum.RightCenter : .Cols(8).AllowEditing = False
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "Total" : .Cols(9).TextAlign = TextAlignEnum.RightCenter : .Cols(9).AllowEditing = False : .Cols(9).Format = "#,###0"
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "Kategori" : .Cols(10).TextAlign = TextAlignEnum.LeftCenter : .Cols(10).AllowEditing = False
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "kategori Barang" : .Cols(11).TextAlign = TextAlignEnum.LeftCenter : .Cols(11).AllowEditing = False
            txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "DetailID" : .Cols(12).Visible = False
            txt = .GetCellRange(0, 13, 0, 13) : txt.Data = "Penggunaan" : .Cols(13).TextAlign = TextAlignEnum.LeftCenter : .Cols(13).AllowEditing = False
            txt = .GetCellRange(0, 14, 0, 14) : txt.Data = "Created By" : .Cols(14).TextAlign = TextAlignEnum.LeftCenter : .Cols(14).AllowEditing = False
            txt = .GetCellRange(0, 15, 0, 15) : txt.Data = "Created Date" : .Cols(15).TextAlign = TextAlignEnum.CenterCenter : .Cols(15).AllowEditing = False

            .AutoSizeCols()
        End With
    End Sub

    Private Sub BtnCari_Click(sender As Object, e As EventArgs) Handles BtnCari.Click
        Call ShowData()
    End Sub

    Private Sub ShowData()
        Dim dt As DataTable = New DataTable
        Dim i As Integer = 1
        Dim Status As String = ""
        Dim Penggunaan As String = ""

        If rdBlmTerima.Checked = True Then
            Status = " and a.terima_nota_date is null "
        ElseIf rdSdhTerima.Checked = True Then
            Status = " and a.terima_nota_date is not null "
        End If

        If rdAllPenggunaan.Checked = True Then
            Penggunaan = ""
        ElseIf rdPancang.Checked = True Then
            Penggunaan = " and e.nama_penggunaan='Pancang' "
        ElseIf rdPurchaser.Checked = True Then
            Penggunaan = " and e.nama_penggunaan='Purchaser' "
        ElseIf rdPulsaListrik.Checked = True Then
            Penggunaan = " and e.nama_penggunaan='Listrik / Internet' "
        End If

        Dim query As String = " SELECT 
	                                b.kode_trans,f.Pancang,a.nama_item,a.harga_sub, a.qty, a.harga,a.kategori_item,c.nama_kategori,
	                                ISNULL(a.keterangan,'') as catatanBarang,ISNULL(b.catatan,'') as catatanNota,g.NamaLengkap as created_by, a.created_date, b.updated_date, 
                                    b.updated_by, a.deleted_by, a.deleted_date,a.detaild_id, a.header_id,a.foto_item,b.foto_trans,e.nama_penggunaan,d.remark
                                    ,a.terima_nota_by,a.terima_nota_date,a.tanggal_nota
                                FROM
	                                PSGRMP..tblPancangReq_TransaksiItemDetail AS a LEFT OUTER JOIN
                                    PSGRMP..tblPancangReq_TransaksiItemHeader AS b ON a.header_id = b.header_id LEFT OUTER JOIN
	                                PSGRMP..tblPancangReq_MasterKategori AS c ON a.kategori_id = c.id LEFT OUTER JOIN
                                    PSGRMP..tblPancangReq_MasterCatatan AS d ON a.catatan_id = d.id LEFT OUTER JOIN
                                    PSGRMP..tblPancangReq_MasterPenggunaan AS e ON d.penggunaan_id = e.id inner join
	                                [192.168.12.5].[RMPApp].[dbo].[Android_tblMstPancang] as f on b.pancang_id=f.IDPancang inner join 
	                                [192.168.12.5].[RMPApp].[dbo].[PancangRequestUser] as g on a.created_by=g.DetailID
                                where 
	                                isnull(a.deleted,0)=0 and
	                                isnull(b.deleted,0)=0 and
                                    cast(a.created_date as date) between cast('" & Format(dtp1.Value, "yyyy-MM-dd") & "' as date) and cast('" & Format(dtp2.Value, "yyyy-MM-dd") & "' as date)
                                    " & Status & "
                                    " & Penggunaan & "
                                    " & IIf(CmbPancang.Text = "", "", " and b.pancang_id='" & CmbPancang.SelectedValue & "' ") & " 
                                ORDER BY f.Pancang,c.nama_kategori 
                                "

        dt = DB.ExecuteQuery(StrConnPSGRMP, query)

        fg.Rows.Count = 1
        If dt.Rows.Count > 0 Then
            With fg
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, 1) = False
                    If IsDBNull(row.Item("terima_nota_date")) = False Then
                        .Item(i, 2) = row.Item("terima_nota_date")
                    Else
                        If rdAll.Checked = False Then
                            .Item(i, 2) = Format(Now, "dd/MM/yyyy")
                        End If
                    End If
                    .Item(i, 3) = row.Item("tanggal_nota")
                    .Item(i, 4) = row.Item("Pancang")
                    .Item(i, 5) = row.Item("kode_trans")
                    .Item(i, 6) = row.Item("nama_item")
                    .Item(i, 7) = row.Item("harga_sub")
                    .Item(i, 8) = row.Item("qty")
                    .Item(i, 9) = row.Item("harga")
                    .Item(i, 10) = row.Item("kategori_item")
                    .Item(i, 11) = row.Item("nama_kategori")
                    .Item(i, 12) = row.Item("detaild_id")
                    .Item(i, 13) = row.Item("nama_penggunaan")
                    .Item(i, 14) = row.Item("created_by")
                    .Item(i, 15) = row.Item("created_date")

                    i += 1
                Next

                .AutoSizeCols()
            End With
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        With fg
            If rdBlmTerima.Checked = True Or rdSdhTerima.Checked = True Then
                Dim FlagAdaCheclist As Integer = 0
                For i = 1 To .Rows.Count - 1
                    If .Item(i, 1) = True Then
                        FlagAdaCheclist = 1
                        Exit For
                    End If
                Next

                If FlagAdaCheclist = 1 Then
                    For i = 1 To .Rows.Count - 1
                        If .Item(i, 1) = True Then
                            DB.ExecuteNonQuery(StrConnPSGRMP, " update PSGRMP..tblPancangReq_TransaksiItemDetail set terima_nota_by='" & ClsSession.UserID & "',terima_nota_date='" & Format(CDate(.Item(i, 2)), "yyyy-MM-dd") & "',tanggal_nota='" & Format(CDate(.Item(i, 3)), "yyyy-MM-dd") & "' where detaild_id='" & .Item(i, 12) & "' ")
                        End If
                    Next

                    MsgBox("Data berhasil di save !", vbInformation, AT)
                    BtnCari.PerformClick()
                Else
                    MsgBox("Tidak ada data yang di pilih !", vbExclamation, AT)
                End If
            End If

            If rdAll.Checked = True Then

            End If
        End With
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub rdAll_CheckedChanged(sender As Object, e As EventArgs) Handles rdAll.CheckedChanged, rdBlmTerima.CheckedChanged, rdSdhTerima.CheckedChanged
        If rdAll.Checked = True Then
            btnSave.Enabled = False
        Else
            btnSave.Enabled = True
        End If
    End Sub

End Class