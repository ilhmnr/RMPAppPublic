Public Class FrmTrnPenjualanRestoreFakturPabrik
    Private Sub FrmTrnPembuatanPenjualanRestoreFakturPabrik_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpStartDate.Value = Now
        dtpEndDate.Value = Now

        ' Set FlexGrid
        Call ClsFlexGrid.ApplyStyle(fg)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim dt As New DataTable
        Dim i As Integer = 1
        Dim sql As String = ""

        Dim TglTerima As String = " AND TglTerima BETWEEN '" & dtpStartDate.Value.ToString("yyyy-MM-dd") & "' AND '" & dtpEndDate.Value.ToString("yyyy-MM-dd") & "' "

        Dim NoNota As String = " AND NoNota LIKE '%" & txtNoFaktur.Text & "%' "

        Me.Cursor = Cursors.WaitCursor

        If rdRSUP.Checked = True Then
            sql = "with cte as (
	                    Select TglTerima,NoNota,via as Kapal,DivKav as AsalKelapa,
                        case when Jenis in ('Jambul-A','Jambul-B') then 'Jambul' else 'Licin' end as Jenis,
	                    case when Jenis in ('Jambul-A','Licin-A') then Netto else 0 end as NettoA,
	                    case when Jenis in ('Jambul-B','Licin-B') then Netto else 0 end as NettoB,
	                    0 as NettoKC,
	                    case when Jenis in ('Jambul-A','Licin-A') then Harga else 0 end as HargaA,
	                    case when Jenis in ('Jambul-B','Licin-B') then Harga else 0 end as HargaB,
	                    0 as HargaKC,
                        ISNULL(UseBPI,0) as UseBPI
	                    from RSUPAccounting..vwRMTrnPenerimaanKBKg where KodeSup1='1000000007516449'

	                    union all 

	                    Select TglTerima,NoNota,BoatName as Kapal,KodeDivKav as AsalKelapa,Jenis,0 NettoA,0 NettoB,Netto2 as NettoKC,0 as HargaA,0 as HargaB,Harga as HargaKC, 
                        ISNULL(UseBPI,0) as UseBPI
	                    from RSUPAccounting..vwRMTrnPenerimaanKCDtl where kodesup1='1000000007516449' and Jenis='Cungkil'
                    ) 

                    select TglTerima,NoNota,Kapal,AsalKelapa,Jenis,0 as Netto1A,sum(NettoA) as NettoA,sum(NettoB) as NettoB,sum(NettoKC) as NettoKC,0 as NettoGelondong,
                    max(HargaA) as HargaA,max(HargaB) as HargaB,max(HargaKC) as HargaKC,0 HargaGelondong,
                    '202511.001' as CustomerID, 'RIAU SAKTI UNITED PLANTATIONS' as Customer, UseBPI
                    from cte WHERE 1=1 " & TglTerima & NoNota & "
                    group by TglTerima,NoNota,Kapal,AsalKelapa,Jenis, UseBPI
                    order by NoNota asc"

            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)
        ElseIf rdPSG.Checked = True Then
            sql = "  select tanggal as TglTerima,Nonota as NoNota,kapal as Kapal,AreaSubName as AsalKelapa,jenis as Jenis
                      ,'202511.002' as CustomerID, 'PT. PULAU SAMBU GUNTUNG' as Customer,
                      0 as Netto1A,NettoA,NettoB,NettoKC,NettoGelondong,HargaA,HargaB,HargaKC,HargaGelondong, 
                      ISNULL(UseBPI,0) as UseBPI
                      FROM vwLaporanBPIKalkulasi WHERE NamaSup='BALARAMA PRAJAKARSAKA INDONESIA' 
                        AND tanggal BETWEEN '" & dtpStartDate.Value.ToString("yyyy-MM-dd") & "' AND '" & dtpEndDate.Value.ToString("yyyy-MM-dd") & "' 
                        " & NoNota & ""

            dt = Modul_RMP.DB.ExecuteQuery(StrConnPSGRMP, sql)

        ElseIf rdCustomer.Checked = True Then
            sql = "select TglTerima,NoInvoice as NoNota,Kapal,AsalKelapa,Jenis,CustomerID,Customer,
                    Netto1A,NettoA,NettoB,0 as NettoKC,0 as NettoGelondong,HargaA,isnull(HargaB,0) as HargaB,0 as HargaKC,0 as HargaGelondong, 
                    ISNULL(UseBPI,0) as UseBPI
                    from RMPApp..vw_NotaCustomer WHERE 1=1 
                    " & TglTerima &
                    " AND NoInvoice LIKE '%" & txtNoFaktur.Text & "%' " & ""

            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)
        End If



        With fg
            .Rows.Count = 1 ' Reset grid sebelum mengisi data baru

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "Used") = row("UseBPI")
                    .Item(i, "NoNota") = row("NoNota")
                    .Item(i, "TanggalTerima") = row("TglTerima")
                    .Item(i, "Kapal") = row("Kapal")
                    .Item(i, "AsalKelapa") = row("AsalKelapa")
                    .Item(i, "Jenis") = row("Jenis")
                    .Item(i, "CustomerID") = row("CustomerID")
                    .Item(i, "Customer") = row("Customer")
                    .Item(i, "Netto1A") = row("Netto1A")
                    .Item(i, "NettoA") = row("NettoA")
                    .Item(i, "NettoB") = row("NettoB")
                    .Item(i, "NettoKC") = row("NettoKC")
                    .Item(i, "HargaA") = row("HargaA")
                    .Item(i, "HargaB") = row("HargaB")
                    .Item(i, "HargaKC") = row("HargaKC")
                    .Item(i, "NettoGD") = row("NettoGelondong")
                    .Item(i, "HargaGD") = row("HargaGelondong")

                    i += 1
                Next

                .AutoSizeCols()
            Else
                MsgBoxCustom.Show("Faktur Pabrik tidak ditemukan.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            End If
        End With

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub fgFakturPabrik_BeforeEdit(sender As Object, e As C1.Win.C1FlexGrid.RowColEventArgs) Handles fg.BeforeEdit
        ' Tidak boleh edit header dan kolom pertama
        If e.Row = 0 OrElse e.Col = 0 Then
            e.Cancel = True
            Exit Sub
        End If

        ' Hanya kolom "Used" yang boleh diedit
        e.Cancel = (fg.Cols(e.Col).Name <> "Used")
    End Sub

    Private Sub fg_AfterEdit(sender As Object, e As C1.Win.C1FlexGrid.RowColEventArgs) Handles fg.AfterEdit
        If fg.Cols(e.Col).Name = "Used" Then
            Select Case fg.Item(e.Row, "Used")
                Case True
                    If MsgBoxCustom.Show("No Faktur : " & fg.Item(e.Row, "NoNota") & vbCrLf &
                            "Tanggal : " & fg.Item(e.Row, "TanggalTerima") & vbCrLf &
                            "Kapal : " & fg.Item(e.Row, "Kapal") & vbCrLf &
                            "Asal Kelapa : " & fg.Item(e.Row, "AsalKelapa") & vbCrLf &
                            "Jenis : " & fg.Item(e.Row, "Jenis") & vbCrLf &
                            "Customer : " & fg.Item(e.Row, "Customer") & vbCrLf &
                            "Apakah Anda yakin ingin menandai faktur ini sebagai digunakan?", MsgBoxCustom.ButtonType.YesNo, MsgBoxCustom.IconType.Question) = vbNo Then
                        fg.Item(e.Row, "Used") = False
                    Else
                        Me.Cursor = Cursors.WaitCursor

                        ' Update status Used di database
                        If rdPSG.Checked = True Then
                            Modul_RMP.DB.ExecuteQuery(StrConnPSGRMP, "UPDATE tblRMTrnPenerimaanKBKGHdr
                                                            SET TFtoBPI = 1
                                                            WHERE Nonota = '" & fg.Item(e.Row, "NoNota") & "'

                                                            UPDATE tblRMTrnPenerimaanKCDtl
                                                            SET TFtoBPI = 1
                                                            WHERE NoNota = '" & fg.Item(e.Row, "NoNota") & "'")
                        ElseIf rdRSUP.Checked = True Then
                            Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "update RSUPAccounting..tblRMTrnPenerimaanKBHdr set UseBPI=1 where NoNota='" & fg.Item(e.Row, "NoNota") & "'
                                                                update RSUPAccounting..tblRMTrnPenerimaanKCHdr set UseBPI=1 where NoNota='" & fg.Item(e.Row, "NoNota") & "'")
                        ElseIf rdCustomer.Checked = True Then
                            Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "update A  
                                                                set a.pullBPI=1,a.PullBPIBy='',a.PullBPIDate=getdate()
                                                                from Supplier_TransaksiKelapa as A
                                                                inner join Supplier_HargaHeader as B on a.IDHeader=b.id
                                                                where b.NoInvoice='" & fg.Item(e.Row, "NoNota") & "'")
                        End If

                        Me.Cursor = Cursors.Default

                        MsgBoxCustom.Show("Faktur telah ditandai sebagai digunakan.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                    End If

                Case False
                    If MsgBoxCustom.Show("No Faktur : " & fg.Item(e.Row, "NoNota") & vbCrLf &
                           "Tanggal : " & fg.Item(e.Row, "TanggalTerima") & vbCrLf &
                           "Kapal : " & fg.Item(e.Row, "Kapal") & vbCrLf &
                           "Asal Kelapa : " & fg.Item(e.Row, "AsalKelapa") & vbCrLf &
                           "Jenis : " & fg.Item(e.Row, "Jenis") & vbCrLf &
                           "Customer : " & fg.Item(e.Row, "Customer") & vbCrLf &
                           "Apakah Anda yakin ingin menandai faktur ini Belum digunakan?", MsgBoxCustom.ButtonType.YesNo, MsgBoxCustom.IconType.Question) = vbNo Then
                        fg.Item(e.Row, "Used") = True
                    Else
                        Me.Cursor = Cursors.WaitCursor

                        ' Update status Used di database
                        If rdPSG.Checked = True Then
                            Modul_RMP.DB.ExecuteQuery(StrConnPSGRMP, "UPDATE tblRMTrnPenerimaanKBKGHdr
                                                            SET TFtoBPI = 0
                                                            WHERE Nonota = '" & fg.Item(e.Row, "NoNota") & "'

                                                            UPDATE tblRMTrnPenerimaanKCDtl
                                                            SET TFtoBPI = 0
                                                            WHERE NoNota = '" & fg.Item(e.Row, "NoNota") & "'")
                        ElseIf rdRSUP.Checked = True Then
                            Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "update RSUPAccounting..tblRMTrnPenerimaanKBHdr set UseBPI=0 where NoNota='" & fg.Item(e.Row, "NoNota") & "'
                                                                update RSUPAccounting..tblRMTrnPenerimaanKCHdr set UseBPI=0 where NoNota='" & fg.Item(e.Row, "NoNota") & "'")
                        ElseIf rdCustomer.Checked = True Then
                            Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "update A  
                                                                set a.pullBPI=0,a.PullBPIBy='',a.PullBPIDate=getdate()
                                                                from Supplier_TransaksiKelapa as A
                                                                inner join Supplier_HargaHeader as B on a.IDHeader=b.id
                                                                where b.NoInvoice='" & fg.Item(e.Row, "NoNota") & "'")
                        End If

                        Me.Cursor = Cursors.Default

                        MsgBoxCustom.Show("Faktur telah ditandai sebagai Belum digunakan.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                    End If

            End Select
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class