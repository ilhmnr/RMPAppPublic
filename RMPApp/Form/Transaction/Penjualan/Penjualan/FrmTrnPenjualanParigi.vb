Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports Syncfusion.Windows.Forms.Tools

Public Class FrmTrnPenjualanParigi
    Private SalesOrderNo As String
    Private DeliveryOrderNo As String
    Private InvoiceNo As String
    Public Tujuan, Jenis, Grade, GradeSub, ItemID, ItemID2 As String

    Private Sub FrmTrnPembuatanPenjualan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set ComboBox
        Combo.SetPancang(cboPancang)
        cboPancang.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboPancang.AutoCompleteSource = AutoCompleteSource.ListItems
        Combo.SetKapal(cboKapal)
        cboKapal.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboKapal.AutoCompleteSource = AutoCompleteSource.ListItems

        ' Set DateTimePicker
        dtpTanggalPenjualan.Value = Now
        dtpTanggalNota1.Value = Now
        dtpTanggalNota2.Value = Now

        ' Set FlexGrid
        Call ClsFlexGrid.ApplyStyle(fgFakturPabrik)
        Call ClsFlexGrid.ApplyStyle(fgPabrik)
        Call ClsFlexGrid.ApplyStyle(fgAllPabrik)
        Call ClsFlexGrid.ApplyStyle(fgPancang)
        Call ClsFlexGrid.ApplyStyle(fgStok)
        Call ClsFlexGrid.ApplyStyle(fgPenjualan)

        ' set hasil susut/bertambah
        txtSusut.Text = "0"
        txtBertambah.Text = "0"

        btnCancel.Enabled = False
    End Sub

    Public Sub LoadData()
        If txtTrip.Text = "" Then
            MsgBoxCustom.Show("Silakan isi No Trip terlebih dahulu.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Exit Sub
        End If

        If cboPancang.Text = "" Then
            MsgBoxCustom.Show("Silakan pilih Pancang terlebih dahulu.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Exit Sub
        End If

        If cboKapal.Text = "" Then
            MsgBoxCustom.Show("Silakan pilih Kapal terlebih dahulu.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Exit Sub
        End If

        Call ShowDataFakturPabrik()
        If fgFakturPabrik.Rows.Count <= 1 Then
            fgFakturPabrik.Rows.Count = 1
            fgPabrik.Rows.Count = 1
            fgAllPabrik.Rows.Count = 1
            fgPancang.Rows.Count = 1
            Exit Sub
        End If

        'fgPabrik.AllowEditing = True

        'Call ShowDataPabrik()
        'If fgPabrik.Rows.Count <= 1 Then
        '    Exit Sub
        'End If

        If rdCustomer.Checked = False Then
            Call ShowDataAllPabrik()
        End If

        Call ShowDataPancang()
        If fgPancang.Rows.Count <= 1 Then
            fgFakturPabrik.Rows.Count = 1
            fgPabrik.Rows.Count = 1
            fgAllPabrik.Rows.Count = 1
            fgPancang.Rows.Count = 1
            Exit Sub
        End If

        If rdJambul.Checked = True Then
            Jenis = "Jambul"
        ElseIf rdLicin.Checked = True Then
            Jenis = "licin"
        ElseIf rdCungkil.Checked = True Then
            Jenis = "Cungkil"
        ElseIf rdGelondong.Checked = True Then
            Jenis = "Gelondong"
        End If

        If rdKBA.Checked = True Then
            Grade = "KB-A"
        ElseIf rdKBB.Checked = True Then
            Grade = "KB-B"
        ElseIf rdKC.Checked = True Then
            Grade = "KC"
        ElseIf rdGD.Checked = True Then
            Grade = "GD"
        End If

        If rdPSG.Checked = True Then
            Tujuan = "PSG"
        ElseIf rdRSUP.Checked = True Then
            Tujuan = "RSUP"
        ElseIf rdCustomer.Checked = True Then
            Tujuan = "Customer"
        End If

        GradeSub = IIf(chkA6.Checked = True, "A6", "A")

        Call ShowDataStok()
        If fgStok.Rows.Count <= 1 Then
            fgFakturPabrik.Rows.Count = 1
            fgPabrik.Rows.Count = 1
            fgAllPabrik.Rows.Count = 1
            fgPancang.Rows.Count = 1
            Exit Sub
        End If

        FrmTrnPenjualanRSUPDanPSGFindKapal.Close()
    End Sub

    Private Sub ShowDataFakturPabrik()
        Dim dt As New DataTable
        Dim i As Integer = 1
        Dim sql As String = ""

        If rdRSUP.Checked = True Then
            sql = "with cte as (
	                    Select TglTerima,NoNota,via as Kapal,DivKav as AsalKelapa,
                        case when Jenis in ('Jambul-A','Jambul-B') then 'Jambul' else 'Licin' end as Jenis,
	                    case when Jenis in ('Jambul-A','Licin-A') then Netto else 0 end as NettoA,
	                    case when Jenis in ('Jambul-B','Licin-B') then Netto else 0 end as NettoB,
	                    0 as NettoKC,
	                    case when Jenis in ('Jambul-A','Licin-A') then Harga else 0 end as HargaA,
	                    case when Jenis in ('Jambul-B','Licin-B') then Harga else 0 end as HargaB,
	                    0 as HargaKC
	                    from RSUPAccounting..vwRMTrnPenerimaanKBKg where KodeSup1='1000000007516449' and isnull(UseBPI,0)=0

	                    union all 

	                    Select TglTerima,NoNota,BoatName as Kapal,KodeDivKav as AsalKelapa,Jenis,0 NettoA,0 NettoB,Netto2 as NettoKC,0 as HargaA,0 as HargaB,Harga as HargaKC
	                    from RSUPAccounting..vwRMTrnPenerimaanKCDtl where kodesup1='1000000007516449' and Jenis='Cungkil' and isnull(UseBPI,0)=0 
                    ) 

                    select TglTerima,NoNota,Kapal,AsalKelapa,Jenis,0 as Netto1A,sum(NettoA) as NettoA,sum(NettoB) as NettoB,sum(NettoKC) as NettoKC,0 as NettoGelondong,
                    max(HargaA) as HargaA,max(HargaB) as HargaB,max(HargaKC) as HargaKC,0 HargaGelondong,
                    '202511.001' as CustomerID, 'RIAU SAKTI UNITED PLANTATIONS' as Customer
                    from cte 
                    group by TglTerima,NoNota,Kapal,AsalKelapa,Jenis
                    order by NoNota asc"

            dt = DB.ExecuteQuery(StrConnRMPApp,sql)
        ElseIf rdPSG.Checked = True Then
            sql = "  select tanggal as TglTerima,Nonota as NoNota,kapal as Kapal,AreaSubName as AsalKelapa,jenis as Jenis
                      ,'202511.002' as CustomerID, 'PT. PULAU SAMBU GUNTUNG' as Customer,
                      0 as Netto1A,NettoA,NettoB,NettoKC,NettoGelondong,HargaA,HargaB,HargaKC,HargaGelondong 
                      FROM vwLaporanBPIKalkulasi 
                      where NamaSup='BALARAMA PRAJAKARSAKA INDONESIA'"

            dt = DB.ExecuteQuery(StrConnPSGRMP,sql)

        ElseIf rdCustomer.Checked = True Then
            sql = "select TglTerima,NoInvoice as NoNota,Kapal,AsalKelapa,Jenis,CustomerID,Customer,
                    Netto1A,NettoA,NettoB,0 as NettoKC,0 as NettoGelondong,HargaA,isnull(HargaB,0) as HargaB,0 as HargaKC,0 as HargaGelondong from vw_NotaCustomer"

            dt = DB.ExecuteQuery(StrConnRMPApp,sql)
        End If



        With fgFakturPabrik
            .Rows.Count = 1 ' Reset grid sebelum mengisi data baru

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
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
    End Sub

    Private Sub ShowDataPabrik()
        Dim dt As New DataTable
        Dim i As Integer = 1
        Dim sql As String = ""
        Dim KodeSup As String = ""
        Dim Via_Kapal As String = ""
        Dim NotaSudahSave As String = ""
        Dim NotaBongkarPabrik As String = ""

        Dim Tujuan As String = ""
        If rdRSUP.Checked = True Then
            Tujuan = "RSUP"
        ElseIf rdPSG.Checked = True Then
            Tujuan = "PSG"
        End If

        Dim Jenis As String = ""
        If rdJambul.Checked = True Then
            Jenis = "Jambul"
        ElseIf rdLicin.Checked = True Then
            Jenis = "Licin"
        ElseIf rdCungkil.Checked = True Then
            Jenis = "Cungkil"
        ElseIf rdGelondong.Checked = True Then
            Jenis = "Gelondong"
        End If

        Dim Grade As String = ""
        If rdKBA.Checked = True Then
            Grade = "KB-A"
        ElseIf rdKBB.Checked = True Then
            Grade = "KB-B"
        ElseIf rdKC.Checked = True Then
            Grade = "KC"
        ElseIf rdGD.Checked = True Then
            Grade = "GD"
        End If

        Dim GradeSub As String = ""
        If rdKBA.Checked = True Or rdKBB.Checked = True Then
            If chkA6.Checked = True Then
                GradeSub = "A6"
            Else
                GradeSub = "A"
            End If
        Else
            GradeSub = ""
        End If

        KodeSup = DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"select KodeSup as GetValueString from Android_tblMstPancang where IDPancang=" & cboPancang.SelectedValue)
        Via_Kapal = DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"select RIGHT(RTRIM(KapalName),5) as GetValueString from tblMstKapal where KapalID=" & cboKapal.SelectedValue)
        'NotaSudahSave = DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"SELECT
        '                                        ISNULL(
        '                                            STUFF((
        '                                                SELECT ',' + QUOTENAME(P.NoNota, '''')
        '                                                FROM tblTrnPembuatanPenjualanNotaPabrik P
        '                                                WHERE P.NoTrans IN (
        '                                                    SELECT H.NoTrans
        '                                                    FROM tblTrnPembuatanPenjualanHdr H
        '                                                    WHERE H.IDPancang = " & cboPancang.SelectedValue & "
        '                                                      AND H.IDKapal = " & cboKapal.SelectedValue & "
        '                                                      AND H.Trip = " & txtTrip.Text & "
        '                                                      AND H.Tujuan = '" & Tujuan & "'
        '                                                      AND H.Jenis = '" & Jenis & "'
        '                                                      AND H.Grade = '" & Grade & "'
        '                                                      AND ISNULL(H.GradeSub,'') = '" & GradeSub & "'
        '                                                ) and P.Deleted=0
        '                                                FOR XML PATH(''), TYPE
        '                                            ).value('.', 'varchar(max)'), 1, 1, ''),
        '                                        '''''') AS GetValueString")

        If rdRSUP.Checked = True Then
            If fgFakturPabrik.Item(1, "Jenis") <> "Cungkil" Then
                NotaBongkarPabrik = DB.ExecuteScalarValue(Of String)(StrConnAccounting, "SELECT
                                                    STUFF((
                                                        SELECT ',' + QUOTENAME(NoReff, '''')
                                                        FROM (
                                                            SELECT DISTINCT NoReff, MIN(detailid) AS detailid
                                                            FROM vwRMTrnPenerimaanKBKg
                                                            WHERE NoNota = '" & fgFakturPabrik.Item(1, "NoNota") & "'
                                                            GROUP BY NoReff
                                                        ) x
                                                        ORDER BY detailid ASC
                                                        FOR XML PATH(''), TYPE
                                                    ).value('.', 'varchar(max)'), 1, 1, '') AS GetValueString
                                                ")

                sql = "select  
                                No_Reff,Tanggal,KodeSup,NamaSup,Via_Kapal,DermagaID,DermagaName,Shift,Jenis,
                                isnull(BrutoJambul_A,0)+isnull(BrutoLicin_A,0)+ISNULL(BrutoCungkil,0) as TotalN1,
                                isnull(BrutoJambul_B,0)+isnull(BrutoLicin_B,0) as TotalN1B,
                                isnull(TotalNettoJambul_A,0)+isnull(TotalNettoLicin_A,0) as KBA,
                                isnull(TotalNettoJambul_B,0)+isnull(TotalNettoLicin_B,0) as KBB,
                                ISNULL(TotalNettoCungkil,0) as KC,
                                isnull(TotalNettoJambul_A,0)+isnull(TotalNettoLicin_A,0)+
                                isnull(TotalNettoJambul_B,0)+isnull(TotalNettoLicin_B,0)+
                                ISNULL(TotalNettoCungkil,0) as Total,'RSUP' as Bongkar
                                from vwForRMPApp_05012026
                                where No_Reff in (" & NotaBongkarPabrik & ")"
            Else
                NotaBongkarPabrik = DB.ExecuteScalarValue(Of String)(StrConnAccounting, "SELECT
                                                    STUFF((
                                                        SELECT ',' + QUOTENAME(NoReff, '''')
                                                        FROM (
                                                            SELECT DISTINCT NoReff, MIN(detailid) AS detailid
                                                            FROM vwRMTrnPenerimaanKCDtl
                                                            WHERE NoNota = '" & fgFakturPabrik.Item(1, "NoNota") & "'
                                                            GROUP BY NoReff
                                                        ) x
                                                        ORDER BY detailid ASC
                                                        FOR XML PATH(''), TYPE
                                                    ).value('.', 'varchar(max)'), 1, 1, '') AS GetValueString
                                                ")

                sql = "select No_Reff,Tanggal,KodeSup,NamaSup,Via_Kapal,DermagaID,DermagaName,Shift,Jenis,TotalNetto1 as TotalN1,0 as TotalN1B,0 as KBA,0 as KBB,TotalNetto2 as KC,TotalNetto2 as Total,'RSUP' as Bongkar
                                from vwRMTrnKelapaTimbangKC
                                where No_Reff in (" & NotaBongkarPabrik & ")"
            End If

            dt = DB.ExecuteQuery(StrConnTimbangan, sql)
        ElseIf rdPSG.Checked = True Then
            sql = "select NotaBongkar as No_Reff,tanggal as Tanggal,KodeSup,NamaSup,kapal as Via_Kapal,ConveyorID as DermagaID,ConveyorID as DermagaName,'' as Shift,jenis as Jenis ,
                    case when jenis='Kelapa Cungkil' then NettoKC else netto1 end as TotalN1,netto1KBB as TotalN1B,NettoA as KBA,NettoB as KBB,NettoKC as KC,NettoGelondong as GD,TotalNetto as Total,'PSG' as Bongkar
                    from vwLaporanBPI where Nonota like '%" & fgFakturPabrik.Item(1, "NoNota") & "%'"

            dt = DB.ExecuteQuery(StrConnPSGRMP,sql)
        End If

        With fgPabrik
            .Rows.Count = 1 ' Reset grid sebelum mengisi data baru

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "Bongkar") = row("Bongkar")
                    .Item(i, "NoNota") = row("No_Reff")
                    .Item(i, "Tanggal") = row("Tanggal")
                    .Item(i, "KodeSup") = row("KodeSup")
                    .Item(i, "NamaSup") = row("NamaSup")
                    .Item(i, "NamaKapal") = row("Via_Kapal")
                    .Item(i, "KodeDermaga") = row("DermagaID")
                    .Item(i, "NamaDermaga") = row("DermagaName")
                    .Item(i, "Shift") = row("Shift")
                    .Item(i, "Jenis") = row("Jenis")
                    .Item(i, "TotalN1") = row("TotalN1")
                    .Item(i, "TotalN1B") = row("TotalN1B")
                    .Item(i, "KBA") = row("KBA")
                    .Item(i, "KBB") = row("KBB")
                    .Item(i, "KC") = row("KC")
                    If rdPSG.Checked = True Then
                        .Item(i, "GD") = row("GD")
                    ElseIf rdRSUP.Checked = True Then
                        .Item(i, "GD") = 0
                    End If
                    .Item(i, "Total") = row("Total")

                    i += 1
                Next

                .AutoSizeCols()
            Else
                MsgBoxCustom.Show("Nota pabrik tidak ditemukan.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            End If
        End With
    End Sub

    Private Sub ShowDataAllPabrik()
        Dim dt As New DataTable
        Dim i As Integer = 1

        ' ============================
        ' Jenis
        ' ============================
        Dim Tujuan As String
        If rdRSUP.Checked = True Then
            Tujuan = "RSUP"
        ElseIf rdPSG.Checked = True Then
            Tujuan = "PSG"
        End If

        ' ============================
        ' Jenis
        ' ============================
        Dim Jenis As String
        If rdJambul.Checked = True Then
            Jenis = "Jambul"
        ElseIf rdLicin.Checked = True Then
            Jenis = "Licin"
        Else
            Jenis = "Cungkil"
        End If

        ' ============================
        ' Grade
        ' ============================
        Dim Grade As String
        If rdKBA.Checked = True Then
            Grade = "KB-A"
        ElseIf rdKBB.Checked = True Then
            Grade = "KB-B"
        Else
            Grade = "KC"
        End If

        ' ============================
        ' GradeSub
        ' ============================
        Dim gradeSub As String
        If rdKBA.Checked = True Or rdKBB.Checked = True Then
            If chkA6.Checked = True Then
                gradeSub = "A6"
            Else
                gradeSub = "A"
            End If
        Else
            gradeSub = ""
        End If

        Dim sql As String = "select a.* 
                            from tblTrnPembuatanPenjualanNotaPabrik as a inner join 
                            tblTrnPembuatanPenjualanHdr as b on a.NoTrans=b.NoTrans
                            where a.Deleted=0 and b.Deleted=0 and b.Trip=" & txtTrip.Text & " and b.IDPancang=" & cboPancang.SelectedValue & " and b.IDKapal=" & cboKapal.SelectedValue & " 
                            and b.Tujuan='" & Tujuan & "' and b.Jenis='" & Jenis & "' and b.Grade='" & Grade & "' and isnull(b.GradeSub,'')='" & gradeSub & "'"

        dt = DB.ExecuteQuery(StrConnRMPApp,sql)

        With fgAllPabrik
            .Rows.Count = 1 ' Reset grid sebelum mengisi data baru

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "Bongkar") = row("Bongkar")
                    .Item(i, "NoNota") = row("NoNota")
                    .Item(i, "Tanggal") = row("Tanggal")
                    .Item(i, "KodeSup") = row("KodeSup")
                    .Item(i, "NamaSup") = row("NamaSup")
                    .Item(i, "NamaKapal") = row("NamaKapal")
                    .Item(i, "KodeDermaga") = row("KodeDermaga")
                    .Item(i, "NamaDermaga") = row("NamaDermaga")
                    .Item(i, "Shift") = row("Shift")
                    .Item(i, "Jenis") = row("Jenis")
                    .Item(i, "KBA") = row("KBA")
                    .Item(i, "KBB") = row("KBB")
                    .Item(i, "KC") = row("KC")
                    .Item(i, "Total") = row("Total")

                    i += 1
                Next

                ' === Tambahkan baris TOTAL pada index 1 ===
                .Rows.Insert(1)
                .Item(1, "NoNota") = "TOTAL"

                ' --- Variabel total ---
                Dim tKBA As Decimal = 0D
                Dim tKBB As Decimal = 0D
                Dim tKC As Decimal = 0D
                Dim tTotal As Decimal = 0D

                ' --- Hitung total dari data mulai baris 2 ---
                For r As Integer = 2 To .Rows.Count - 1

                    ' gunakan fungsi helper untuk aman (NULL / empty)
                    tKBA += .Item(r, "KBA")
                    tKBB += .Item(r, "KBB")
                    tKC += .Item(r, "KC")
                    tTotal += .Item(r, "Total")

                Next

                ' --- Isi total ke baris 1 ---
                .Item(1, "KBA") = tKBA
                .Item(1, "KBB") = tKBB
                .Item(1, "KC") = tKC
                .Item(1, "Total") = tTotal

                ' --- Styling row total ---
                '.Rows(1).StyleNew.BackColor = Color.LightYellow
                '.Rows(1).StyleNew.Font = New Font(.Font, FontStyle.Bold)

                .AutoSizeCols()
            End If
        End With
    End Sub
    Private Sub ShowDataPancang()
        Dim dt As New DataTable
        Dim Tujuan As String = ""
        Dim Jenis As String = ""
        Dim Grade As String = ""
        Dim GradeSub As String = ""
        Dim JumlahNota As Integer = 0

        If rdRSUP.Checked = True Then
            Tujuan = "RSUP"
        ElseIf rdPSG.Checked = True Then
            Tujuan = "PSG"
        ElseIf rdCustomer.Checked = True Then
            Tujuan = "SUPPLIER"
        End If

        If rdKBA.Checked = True Then
            Grade = "KB-A"
        ElseIf rdKBB.Checked = True Then
            Grade = "KB-B"
        ElseIf rdKC.Checked = True Then
            Grade = "KC"
        ElseIf rdGD.Checked = True Then
            Grade = "GD"
        End If

        If rdKBA.Checked = True Or rdKBB.Checked = True Then
            If chkA6.Checked = True = True Then
                GradeSub = "A6"
            Else
                GradeSub = "A"
            End If
        Else
            GradeSub = ""
        End If

        If rdJambul.Checked = True Then
            Jenis = "Jambul"
        ElseIf rdLicin.Checked = True Then
            Jenis = "Licin"
        ElseIf rdCungkil.Checked = True Then
            Jenis = "Cungkil"
        ElseIf rdGelondong.Checked = True Then
            Jenis = "Gelondong"
        End If

        Dim sql As String = "select NoNota,IDPenerimaUang,PenerimaUang,Jenis+'-'+JenisKB as ItemName,Brutto,TarraJaring,Netto,
                                TarraPersen,NettoAkhir,HargaSil,HargaNego,Harga,TotalHarga,PPhProsen,PPhPotong,TotalRupiahAkhir,JumlahKarung 
                                from TblTrnKelapaHdr 
                                where Deleted=0 
                                and Trip='" & txtTrip.Text & "'
                                and IDPancang='" & cboPancang.SelectedValue & "'
                                and IDKapal='" & cboKapal.SelectedValue & "'
                                and Bongkar='" & Tujuan & "'
                                and Jenis='" & Jenis & "'
                                and JenisKB='" & Grade & "'
                                and isnull(GradeSub,'')='" & GradeSub & "'"

        JumlahNota = DB.ExecuteScalarValue(Of Integer)(StrConnRMPApp, "select count(TransID) as GetValueInteger
                                        from TblTrnKelapaHdr 
                                        where Deleted=0 
                                        and Trip='" & txtTrip.Text & "'
                                        and IDPancang='" & cboPancang.SelectedValue & "'
                                        and IDKapal='" & cboKapal.SelectedValue & "'
                                        and Bongkar='" & Tujuan & "'
                                        and Jenis='" & Jenis & "'
                                        and JenisKB='" & Grade & "'
                                        and isnull(GradeSub,'')='" & GradeSub & "'")

        dt = DB.ExecuteQuery(StrConnRMPApp,sql)

        With fgPancang
            ' Reset Grid
            .Rows.Count = 1
            Dim i As Integer = 1 ' baris data mulai dari 1

            If dt.Rows.Count > 0 Then

                ' === Validasi jumlah nota ===
                If JumlahNota <> dt.Rows.Count Then
                    MsgBoxCustom.Show("Jumlah nota belum lengkap. Tersedia hanya " &
                           dt.Rows.Count.ToString() & " nota dari total " &
                           JumlahNota.ToString() & ".", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                    Exit Sub
                End If

                ' === Variabel total ===
                Dim tBrutto As Decimal = 0
                Dim tTarra As Decimal = 0
                Dim tJumlahKarung As Decimal = 0
                Dim tNetto1 As Decimal = 0
                Dim tNetto2 As Decimal = 0
                Dim tHargaAwal As Decimal = 0
                Dim tHargaNego As Decimal = 0
                Dim tHargaBeli As Decimal = 0
                Dim tTotalBeforePPH As Decimal = 0
                Dim tPPHRP As Decimal = 0
                Dim tTotalRP As Decimal = 0

                ' === Loop isi data ===
                For Each row As DataRow In dt.Rows
                    .AddItem(i)

                    .Item(i, "InvoiceNo") = row("NoNota")
                    .Item(i, "SupplierID") = row("IDPenerimaUang")
                    .Item(i, "SupplierName") = row("penerimaUang")
                    .Item(i, "ItemName") = row("ItemName")
                    .Item(i, "Brutto") = row("Brutto")
                    .Item(i, "TarraJaring") = row("TarraJaring")
                    .Item(i, "JumlahKarung") = row("JumlahKarung")
                    .Item(i, "Netto1") = row("Netto")
                    .Item(i, "Tarra%") = row("TarraPersen")
                    .Item(i, "Netto2") = row("NettoAkhir")
                    .Item(i, "HargaAwal") = row("HargaSil")
                    .Item(i, "HargaNego") = row("HargaNego")
                    .Item(i, "HargaBeli") = row("Harga")
                    .Item(i, "TotalRPBeforePPH") = row("TotalHarga")
                    .Item(i, "PPH%") = row("PPHProsen")
                    .Item(i, "PPHRP") = row("PPHPotong")
                    .Item(i, "TotalRP") = row("TotalRupiahAkhir")

                    ' === Hitung total ===
                    tBrutto += CDec(row("Brutto"))
                    tTarra += CDec(row("TarraJaring"))
                    tJumlahKarung += CDec(row("JumlahKarung"))
                    tNetto1 += CDec(row("Netto"))
                    tNetto2 += CDec(row("NettoAkhir"))
                    tHargaAwal += CDec(row("HargaSil"))
                    tHargaNego += CDec(row("HargaNego"))
                    tHargaBeli += CDec(row("Harga"))
                    tTotalBeforePPH += CDec(row("TotalHarga"))
                    tPPHRP += CDec(row("PPHPotong"))
                    tTotalRP += CDec(row("TotalRupiahAkhir"))

                    i += 1
                Next

                ' === Tambahkan baris TOTAL di posisi 1 (paling atas) ===
                .Rows.Insert(1)

                .Item(1, "InvoiceNo") = "TOTAL"
                .Item(1, "Brutto") = tBrutto
                .Item(1, "TarraJaring") = tTarra
                .Item(1, "JumlahKarung") = tJumlahKarung
                .Item(1, "Netto1") = tNetto1
                .Item(1, "Netto2") = tNetto2
                .Item(1, "HargaAwal") = tHargaAwal
                .Item(1, "HargaNego") = tHargaNego
                .Item(1, "HargaBeli") = tHargaBeli
                .Item(1, "TotalRPBeforePPH") = tTotalBeforePPH
                .Item(1, "PPHRP") = tPPHRP
                .Item(1, "TotalRP") = tTotalRP

                ' Styling row total
                .Rows(1).StyleNew.BackColor = Color.LightYellow
                .Rows(1).StyleNew.Font = New Font(.Font, FontStyle.Bold)

                .AutoSizeCols()

            Else
                MsgBoxCustom.Show("Nota Pancang tidak ditemukan.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            End If
        End With

    End Sub

    Private Sub ShowDataStok()
        Dim dt As New DataTable
        Dim i As Integer = 1
        Dim Jenis As String
        Dim JenisKB As String
        Dim Tujuan As String = ""

        If rdJambul.Checked = True Then
            Jenis = "Jambul"
        ElseIf rdLicin.Checked = True Then
            Jenis = "Licin"
        ElseIf rdCungkil.Checked = True Then
            Jenis = "Cungkil"
        ElseIf rdGelondong.Checked = True Then
            Jenis = "Gelondong"
        End If

        If rdKapalTenggelam.Checked = False Then
            If rdKBA.Checked = True Then
                JenisKB = "KB-A"
            ElseIf rdKBB.Checked = True Then
                JenisKB = "KB-B"
            ElseIf rdKC.Checked = True Then
                JenisKB = "KC"
            ElseIf rdGD.Checked = True Then
                JenisKB = "GD"
            End If
        End If

        If rdRSUP.Checked = True Then
            Tujuan = "RSUP"
        ElseIf rdPSG.Checked = True Then
            Tujuan = "PSG"
        ElseIf rdCustomer.Checked = True Then
            Tujuan = "SUPPLIER"
        End If

        Dim GradeSub As String
        If rdJambul.Checked = True Or rdLicin.Checked = True Then
            GradeSub = IIf(chkA6.Checked = True, "A6", "A")
        ElseIf rdCungkil.Checked = True Then
            GradeSub = ""
        End If

        Dim sql As String = "SELECT * FROM INV_fnItemStockForTransPenjualanParigi(" & cboPancang.SelectedValue & ")"

        dt = DB.ExecuteQuery(StrConnDBPancang, sql)

        With fgStok
            .Rows.Count = 1 ' Reset grid sebelum mengisi data baru

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "ItemID") = row("ItemID")
                    .Item(i, "ItemName") = row("ItemName")
                    .Item(i, "Qty") = row("Qnty")
                    .Item(i, "Price") = row("UnitPrice")
                    .Item(i, "TotalRp") = row("Total")

                    i += 1
                Next

                .AutoSizeCols()
            Else
                MsgBoxCustom.Show("Stok tidak ditemukan.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            End If
        End With
    End Sub

    Private Sub btnProposional_Click(sender As Object, e As EventArgs) Handles btnProposional.Click
        Me.Cursor = Cursors.WaitCursor

        ' jika belum pilih bersambung \ habis
        If rdBersambung.Checked = False And rdHabis.Checked = False Then
            MsgBoxCustom.Show("Silakan pilih status Bersambung / Habis terlebih dahulu.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        ' stop jika tidak ada data di fgPabrik
        If fgFakturPabrik.Rows.Count <= 1 Then
            MsgBoxCustom.Show("Tidak ada data nota pabrik untuk diproses.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        ' --- Cek apakah ada yang dipilih ---
        If rdCustomer.Checked = False Then
            Dim adaDipilih As Boolean = False
            For r As Integer = 1 To fgFakturPabrik.Rows.Count - 1
                If CBool(fgFakturPabrik.Item(r, "Select")) = True Then
                    adaDipilih = True
                    Exit For
                End If
            Next
            If Not adaDipilih Then
                MsgBoxCustom.Show("Tidak ada nota pabrik yang dipilih.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        ' tidak boleh pilih lebih dari 1 faktur pabrik
        Dim countFaktur As Integer = 0
        For r As Integer = 1 To fgFakturPabrik.Rows.Count - 1
            If CBool(fgFakturPabrik.Item(r, "Select")) = True Then
                countFaktur += 1
            End If
        Next
        If countFaktur > 1 Then
            MsgBoxCustom.Show("Hanya boleh memilih 1 (satu) faktur pabrik untuk metode proposional.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        ' --- Hapus baris faktur pabrik yang tidak dipilih ---
        For r As Integer = fgFakturPabrik.Rows.Count - 1 To 1 Step -1
            If Not CBool(fgFakturPabrik.Item(r, "Select")) Then
                fgFakturPabrik.Rows.Remove(r)
            End If
        Next

        dtpTanggalPenjualan.Value = fgFakturPabrik.Item(1, "TanggalTerima")

        Call ShowDataStok()

        If rdRSUP.Checked = True Or rdPSG.Checked = True Then
            Call ShowDataPabrik()

            ' stop jika tidak ada data di fgPabrik
            If fgPabrik.Rows.Count <= 1 Then
                MsgBoxCustom.Show("Tidak ada data nota pabrik untuk diproses.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            For r As Integer = 1 To fgPabrik.Rows.Count - 1
                fgPabrik.Item(r, "Select") = True
            Next

            ' --- Cek apakah ada yang dipilih ---
            Dim adaDipilih2 As Boolean = False
            For r As Integer = 1 To fgPabrik.Rows.Count - 1
                If CBool(fgPabrik.Item(r, "Select")) = True Then
                    adaDipilih2 = True
                    Exit For
                End If
            Next
            If Not adaDipilih2 Then
                MsgBoxCustom.Show("Tidak ada nota pabrik yang dipilih.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            Call LockNotaPabrik()
            Call MoveNotaPabrikToAllNotaPabrik()
        End If

        Call EnabelInput(False)

        btnSearch.Enabled = False
        btnProposional.Enabled = False
        btnCancel.Enabled = True
        rdKapalTenggelam.Enabled = False

        Call GeneratePersen()
        Call GenerateProposionalPenjualan()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LockNotaPabrik()
        With fgPabrik
            ' --- Hapus baris yang tidak dipilih ---
            For r As Integer = .Rows.Count - 1 To 1 Step -1
                If Not CBool(.Item(r, "Select")) Then
                    .Rows.Remove(r)
                End If
            Next

            ' === Tambahkan baris TOTAL pada index 1 ===
            .Rows.Insert(1)
            .Item(1, "NoNota") = "TOTAL"

            ' --- Variabel total ---
            Dim tKBA As Decimal = 0D
            Dim tKBB As Decimal = 0D
            Dim tKC As Decimal = 0D
            Dim tTotal As Decimal = 0D

            ' --- Hitung total dari data mulai baris 2 ---
            For r As Integer = 2 To .Rows.Count - 1

                ' gunakan fungsi helper untuk aman (NULL / empty)
                tKBA += .Item(r, "KBA")
                tKBB += .Item(r, "KBB")
                tKC += .Item(r, "KC")
                tTotal += .Item(r, "Total")

            Next

            ' --- Isi total ke baris 1 ---
            .Item(1, "KBA") = tKBA
            .Item(1, "KBB") = tKBB
            .Item(1, "KC") = tKC
            .Item(1, "Total") = tTotal

            ' --- Styling row total ---
            .Rows(1).StyleNew.BackColor = Color.LightYellow
            .Rows(1).StyleNew.Font = New Font(.Font, FontStyle.Bold)

            .AllowEditing = False
        End With
    End Sub

    Private Sub MoveNotaPabrikToAllNotaPabrik()
        If fgAllPabrik.Rows.Count > 1 Then fgAllPabrik.Rows.Remove(1)

        With fgPabrik
            For r = 2 To .Rows.Count - 1
                fgAllPabrik.Rows.Insert(1)
                fgAllPabrik.Item(1, "Bongkar") = .Item(r, "Bongkar")
                fgAllPabrik.Item(1, "NoNota") = .Item(r, "NoNota")
                fgAllPabrik.Item(1, "Tanggal") = .Item(r, "Tanggal")
                fgAllPabrik.Item(1, "KodeSup") = .Item(r, "KodeSup")
                fgAllPabrik.Item(1, "NamaSup") = .Item(r, "NamaSup")
                fgAllPabrik.Item(1, "NamaKapal") = .Item(r, "NamaKapal")
                fgAllPabrik.Item(1, "KodeDermaga") = .Item(r, "KodeDermaga")
                fgAllPabrik.Item(1, "NamaDermaga") = .Item(r, "NamaDermaga")
                fgAllPabrik.Item(1, "Shift") = .Item(r, "Shift")
                fgAllPabrik.Item(1, "Jenis") = .Item(r, "Jenis")
                fgAllPabrik.Item(1, "KBA") = .Item(r, "KBA")
                fgAllPabrik.Item(1, "KBB") = .Item(r, "KBB")
                fgAllPabrik.Item(1, "KC") = .Item(r, "KC")
                fgAllPabrik.Item(1, "Total") = .Item(r, "Total")
            Next
        End With

        ' set no
        For i = 1 To fgAllPabrik.Rows.Count - 1
            fgAllPabrik.Item(i, 0) = i
        Next

        With fgAllPabrik
            .Rows.Insert(1)
            .Item(1, "NoNota") = "TOTAL"

            ' --- Variabel total ---
            Dim tKBA As Decimal = 0D
            Dim tKBB As Decimal = 0D
            Dim tKC As Decimal = 0D
            Dim tTotal As Decimal = 0D

            ' --- Hitung total dari data mulai baris 2 ---
            For r As Integer = 2 To .Rows.Count - 1

                ' gunakan fungsi helper untuk aman (NULL / empty)
                tKBA += .Item(r, "KBA")
                tKBB += .Item(r, "KBB")
                tKC += .Item(r, "KC")
                tTotal += .Item(r, "Total")

            Next

            ' --- Isi total ke baris 1 ---
            .Item(1, "KBA") = tKBA
            .Item(1, "KBB") = tKBB
            .Item(1, "KC") = tKC
            .Item(1, "Total") = tTotal

            ' --- Styling row total ---
            .Rows(1).StyleNew.BackColor = Color.LightYellow
            .Rows(1).StyleNew.Font = New Font(.Font, FontStyle.Bold)

            .AutoSizeCols()
        End With
    End Sub

    Private Sub EnabelInput(ByVal Enable As Boolean)
        dtpTanggalNota1.Enabled = Enable
        dtpTanggalNota2.Enabled = Enable
        txtTrip.Enabled = Enable
        cboPancang.Enabled = Enable
        cboKapal.Enabled = Enable
        rdRSUP.Enabled = Enable
        rdPSG.Enabled = Enable
        rdJambul.Enabled = Enable
        rdLicin.Enabled = Enable
        rdCungkil.Enabled = Enable
        rdKBA.Enabled = Enable
        rdKBB.Enabled = Enable
        rdKC.Enabled = Enable
        chkA6.Enabled = Enable
        rdHabis.Enabled = Enable
        rdBersambung.Enabled = Enable
    End Sub

    Private Sub GeneratePersen()
        ' ==========================
        ' AMBIL DATA PCG / PBK DARI GRID
        ' ==========================
        If rdCustomer.Checked = False Then
            If rdKBA.Checked = True Then
                If rdKapalTenggelam.Checked = False Then
                    txtKBAPcg.Text = FormatNumber(CDec(fgPancang.Item(1, "Netto2")), 0)

                    txtKBAPbk.Text = FormatNumber(CDec(fgFakturPabrik.Item(1, "NettoA")), 0)
                    txtKBBPbk.Text = FormatNumber(CDec(fgFakturPabrik.Item(1, "NettoB")), 0)

                    txtKBAAllPbk.Text = FormatNumber(CDec(fgAllPabrik.Item(1, "KBA")), 0)
                    txtKBBAllPbk.Text = FormatNumber(CDec(fgAllPabrik.Item(1, "KBB")), 0)

                    If rdHabis.Checked = True Then
                        ' Persentase
                        txtKBAPersen.Text = FormatNumber(
                            (CDec(fgAllPabrik.Item(1, "KBA")) / CDec(fgPancang.Item(1, "Netto2"))) * 100, 2)

                        txtKBBPersen.Text = FormatNumber(
                            (CDec(fgAllPabrik.Item(1, "KBB")) / CDec(fgPancang.Item(1, "Netto2"))) * 100, 2)
                    End If
                Else
                    txtKBBPcg.Text = FormatNumber(CDec(fgPancang.Item(1, "Netto2")), 0)

                    txtKBBPbk.Text = FormatNumber(CDec(fgFakturPabrik.Item(1, "NettoB")), 0)

                    txtKBBAllPbk.Text = FormatNumber(CDec(fgAllPabrik.Item(1, "KBB")), 0)

                    If rdHabis.Checked = True Then
                        ' Persentase
                        txtKBBPersen.Text = FormatNumber(
                            (CDec(fgAllPabrik.Item(1, "KBB")) / CDec(fgPancang.Item(1, "Netto2"))) * 100, 2)
                    End If
                End If

            ElseIf rdKBB.Checked = True Then
                txtKBBPcg.Text = FormatNumber(CDec(fgPancang.Item(1, "Netto2")), 0)

                txtKBBPbk.Text = FormatNumber(CDec(fgFakturPabrik.Item(1, "NettoB")), 0)

                txtKBBAllPbk.Text = FormatNumber(CDec(fgAllPabrik.Item(1, "KBB")), 0)

                If rdHabis.Checked = True Then
                    ' Persentase
                    txtKBBPersen.Text = FormatNumber(
                        (CDec(fgAllPabrik.Item(1, "KBB")) / CDec(fgPancang.Item(1, "Netto2"))) * 100, 2)
                End If
            ElseIf rdKC.Checked = True Then

                txtKCPcg.Text = FormatNumber(CDec(fgPancang.Item(1, "Netto2")), 0)

                txtKCPbk.Text = FormatNumber(CDec(fgFakturPabrik.Item(1, "NettoKC")), 0)

                txtKCAllPbk.Text = FormatNumber(CDec(fgAllPabrik.Item(1, "KC")), 0)

                If rdHabis.Checked = True Then
                    ' Persentase
                    txtKCPersen.Text = FormatNumber(
                        (CDec(fgAllPabrik.Item(1, "KC")) / CDec(fgPancang.Item(1, "Netto2"))) * 100, 2)
                End If
            ElseIf rdGD.Checked = True Then

                txtGDPcg.Text = FormatNumber(CDec(fgPancang.Item(1, "Netto2")), 0)

                txtGDPbk.Text = FormatNumber(CDec(fgFakturPabrik.Item(1, "NettoGD")), 0)

                txtGDAllPbk.Text = FormatNumber(CDec(fgAllPabrik.Item(1, "GD")), 0)

                If rdHabis.Checked = True Then
                    ' Persentase
                    txtKCPersen.Text = FormatNumber(
                        (CDec(fgAllPabrik.Item(1, "")) / CDec(fgPancang.Item(1, "Netto2"))) * 100, 2)
                End If
            End If

            ' TOTAL PCG / PBK
            txtTotPcg.Text = FormatNumber(CDec(fgPancang.Item(1, "Netto2")), 0)
            txtTotPbk.Text = FormatNumber(CDec(fgFakturPabrik.Item(1, "NettoA")) + CDec(fgFakturPabrik.Item(1, "NettoB")) + CDec(fgFakturPabrik.Item(1, "NettoKC")) + CDec(fgFakturPabrik.Item(1, "NettoGD")), 0)
            txtTotAllPbk.Text = FormatNumber(CDec(fgAllPabrik.Item(1, "Total")), 0)

            ' PERHITUNGAN SUSUT / BERTAMBAH
            If rdHabis.Checked = True Then
                If rdKapalTenggelam.Checked = False Then
                    Dim totPcg As Decimal = CDec(fgPancang.Item(1, "Netto2"))
                    Dim totAllPbk As Decimal = CDec(fgAllPabrik.Item(1, "Total"))

                    If totPcg > totAllPbk Then
                        txtSusut.Text = FormatNumber(totPcg - totAllPbk, 0)
                        txtBertambah.Text = "0"
                    ElseIf totAllPbk > totPcg Then
                        txtSusut.Text = "0"
                        txtBertambah.Text = FormatNumber(totAllPbk - totPcg, 0)
                    Else
                        txtSusut.Text = "0"
                        txtBertambah.Text = "0"
                    End If
                Else
                    txtSusut.Text = "0"
                    txtBertambah.Text = "0"
                End If

            ElseIf rdBersambung.Checked = True Then
                txtSusut.Text = "0"
                txtBertambah.Text = "0"
            End If
        Else
            If rdKBA.Checked = True Then
                If rdKapalTenggelam.Checked = False Then
                    txtKBAPcg.Text = FormatNumber(CDec(fgPancang.Item(1, "Netto2")), 0)

                    txtKBAPbk.Text = FormatNumber(CDec(fgFakturPabrik.Item(1, "NettoA")), 0)
                    txtKBBPbk.Text = FormatNumber(CDec(fgFakturPabrik.Item(1, "NettoB")), 0)

                    txtKBAAllPbk.Text = FormatNumber(CDec(fgFakturPabrik.Item(1, "NettoA")), 0)
                    txtKBBAllPbk.Text = FormatNumber(CDec(fgFakturPabrik.Item(1, "NettoB")), 0)

                    If rdHabis.Checked = True Then
                        ' Persentase
                        txtKBAPersen.Text = FormatNumber((CDec(fgFakturPabrik.Item(1, "NettoA")) / CDec(fgPancang.Item(1, "Netto2"))) * 100, 2)

                        txtKBBPersen.Text = FormatNumber((CDec(fgFakturPabrik.Item(1, "NettoB")) / CDec(fgPancang.Item(1, "Netto2"))) * 100, 2)
                    End If
                Else
                    txtKBBPcg.Text = FormatNumber(CDec(fgPancang.Item(1, "Netto2")), 0)

                    txtKBBPbk.Text = FormatNumber(CDec(fgFakturPabrik.Item(1, "NettoB")), 0)

                    txtKBBAllPbk.Text = FormatNumber(CDec(fgFakturPabrik.Item(1, "NettoB")), 0)

                    If rdHabis.Checked = True Then
                        ' Persentase
                        txtKBBPersen.Text = FormatNumber((CDec(fgFakturPabrik.Item(1, "NettoB")) / CDec(fgPancang.Item(1, "Netto2"))) * 100, 2)
                    End If
                End If

            ElseIf rdKBB.Checked = True Then
                txtKBBPcg.Text = FormatNumber(CDec(fgPancang.Item(1, "Netto2")), 0)

                txtKBBPbk.Text = FormatNumber(CDec(fgFakturPabrik.Item(1, "NettoB")), 0)

                txtKBBAllPbk.Text = FormatNumber(CDec(fgFakturPabrik.Item(1, "NettoB")), 0)

                If rdHabis.Checked = True Then
                    ' Persentase
                    txtKBBPersen.Text = FormatNumber((CDec(fgFakturPabrik.Item(1, "NettoB")) / CDec(fgPancang.Item(1, "Netto2"))) * 100, 2)
                End If
            End If

            ' TOTAL PCG / PBK
            txtTotPcg.Text = FormatNumber(CDec(fgPancang.Item(1, "Netto2")), 0)
            txtTotPbk.Text = FormatNumber(CDec(fgFakturPabrik.Item(1, "NettoA")) + CDec(fgFakturPabrik.Item(1, "NettoB")) + CDec(fgFakturPabrik.Item(1, "NettoKC")) + CDec(fgFakturPabrik.Item(1, "NettoGD")), 0)
            txtTotAllPbk.Text = FormatNumber(CDec(fgFakturPabrik.Item(1, "NettoA")), 0)

            ' PERHITUNGAN SUSUT / BERTAMBAH
            If rdHabis.Checked = True Then
                If rdKapalTenggelam.Checked = False Then
                    Dim totPcg As Decimal = CDec(fgPancang.Item(1, "Netto2"))
                    Dim totAllPbk As Decimal = CDec(fgFakturPabrik.Item(1, "NettoA"))

                    If totPcg > totAllPbk Then
                        txtSusut.Text = FormatNumber(totPcg - totAllPbk, 0)
                        txtBertambah.Text = "0"
                    ElseIf totAllPbk > totPcg Then
                        txtSusut.Text = "0"
                        txtBertambah.Text = FormatNumber(totAllPbk - totPcg, 0)
                    Else
                        txtSusut.Text = "0"
                        txtBertambah.Text = "0"
                    End If
                Else
                    txtSusut.Text = "0"
                    txtBertambah.Text = "0"
                End If

            ElseIf rdBersambung.Checked = True Then
                txtSusut.Text = "0"
                txtBertambah.Text = "0"
            End If
        End If
    End Sub

    Private Sub GeneratePersenBeforeProposional()
        Dim KBAPbk, KBBPbk, KCPbk, TotalPbk As Decimal

        ' lopping fgpabrik ambil total kba,kbb,kc yang di pilih
        For r = 1 To fgPabrik.Rows.Count - 1
            If fgPabrik.Item(r, "Select") = True Then
                KBAPbk += CDec(fgPabrik.Item(r, "KBA"))
                KBBPbk += CDec(fgPabrik.Item(r, "KBB"))
                KCPbk += CDec(fgPabrik.Item(r, "KC"))
            End If
        Next

        TotalPbk = KBAPbk + KBBPbk + KCPbk

        ' ==========================
        ' AMBIL DATA PCG / PBK DARI GRID
        ' ==========================
        If rdKBA.Checked = True Then

            txtKBAPcg.Text = FormatNumber(CDec(fgPancang.Item(1, "Netto2")), 0)
            txtKBAPbk.Text = FormatNumber(CDec(KBAPbk), 0)
            txtKBBPbk.Text = FormatNumber(CDec(KBBPbk), 0)

            txtKBAPcg.Text = FormatNumber(CDec(fgPancang.Item(1, "Netto2")), 0)
            'txtKBAAllPbk.Text = FormatNumber(CDec(fgAllPabrik.Item(1, "KBA")), 0)
            'txtKBBAllPbk.Text = FormatNumber(CDec(fgAllPabrik.Item(1, "KBB")), 0)

            'If rdHabis.Checked = True Then
            '    ' Persentase
            '    txtKBAPersen.Text = FormatNumber(
            '        (CDec(fgAllPabrik.Item(1, "KBA")) / CDec(fgPancang.Item(1, "Netto2"))) * 100, 2)

            '    txtKBBPersen.Text = FormatNumber(
            '        (CDec(fgAllPabrik.Item(1, "KBB")) / CDec(fgPancang.Item(1, "Netto2"))) * 100, 2)
            'End If
        ElseIf rdKBB.Checked = True Then

            txtKBBPcg.Text = FormatNumber(CDec(fgPancang.Item(1, "Netto2")), 0)
            txtKBBPbk.Text = FormatNumber(CDec(KBBPbk), 0)

            'txtKBBAllPbk.Text = FormatNumber(CDec(fgAllPabrik.Item(1, "KBB")), 0)

            'If rdHabis.Checked = True Then
            '    ' Persentase
            '    txtKBBPersen.Text = FormatNumber(
            '        (CDec(fgAllPabrik.Item(1, "KBB")) / CDec(fgPancang.Item(1, "Netto2"))) * 100, 2)
            'End If
        Else

            txtKCPcg.Text = FormatNumber(CDec(fgPancang.Item(1, "Netto2")), 0)
            txtKCPbk.Text = FormatNumber(CDec(KCPbk), 0)

            'txtKCAllPbk.Text = FormatNumber(CDec(fgAllPabrik.Item(1, "KC")), 0)

            'If rdHabis.Checked = True Then
            '    ' Persentase
            '    txtKCPersen.Text = FormatNumber(
            '        (CDec(fgAllPabrik.Item(1, "KC")) / CDec(fgPancang.Item(1, "Netto2"))) * 100, 2)
            'End If
        End If



        ' ==========================
        ' TOTAL PCG / PBK
        ' ==========================

        txtTotPcg.Text = FormatNumber(CDec(fgPancang.Item(1, "Netto2")), 0)
        txtTotPbk.Text = FormatNumber(CDec(TotalPbk), 0)
        'txtTotAllPbk.Text = FormatNumber(CDec(fgAllPabrik.Item(1, "Total")), 0)



        ' ==========================
        ' PERHITUNGAN SUSUT / BERTAMBAH
        ' ==========================

        If rdHabis.Checked = True Then
            'Dim totPcg As Decimal = CDec(fgPancang.Item(1, "Netto2"))
            'Dim totAllPbk As Decimal = CDec(fgAllPabrik.Item(1, "Total"))

            'If totPcg > totAllPbk Then
            '    txtSusut.Text = FormatNumber(totPcg - totAllPbk, 0)
            '    txtBertambah.Text = "0"
            'ElseIf totAllPbk > totPcg Then
            '    txtSusut.Text = "0"
            '    txtBertambah.Text = FormatNumber(totAllPbk - totPcg, 0)
            'Else
            '    txtSusut.Text = "0"
            '    txtBertambah.Text = "0"
            'End If
        Else
            txtSusut.Text = "0"
            txtBertambah.Text = "0"
        End If
    End Sub

    Private Sub GenerateProposionalPenjualan()
        Dim Jenis As String
        If rdJambul.Checked = True Then
            Jenis = "Jambul"
        ElseIf rdLicin.Checked = True Then
            Jenis = "Licin"
        Else
            Jenis = "Cungkil"
        End If

        Dim Customer As String = ""
        If rdRSUP.Checked = True Then
            Customer = "RSUP"
        ElseIf rdPSG.Checked = True Then
            Customer = "PSG"
        End If

        'Dim PriceKBA As Decimal = GetValueInteger("select isnull((select top 1 harga from tblRMMstHargaJualDtl as a inner join tblRMMstHargaJualHdr as b on a.header_id=b.id 
        '                                            where a.deleted=0 and b.deleted=0 and b.ApprovalStatus=1 and cast(b.periode as date)<=GETDATE() 
        '                                            and jenis_kelapa='" & Jenis & "' and a.grade='KB-A' and pancang_id='" & cboPancang.SelectedValue & "' and b.Customer='" & Customer & "'
        '                                            ORDER BY b.periode DESC),0) as GetValueInteger")

        'Dim PriceKBB As Decimal = GetValueInteger("select isnull((select top 1 harga from tblRMMstHargaJualDtl as a inner join tblRMMstHargaJualHdr as b on a.header_id=b.id 
        '                                            where a.deleted=0 and b.deleted=0 and b.ApprovalStatus=1 and cast(b.periode as date)<=GETDATE() 
        '                                            and jenis_kelapa='" & Jenis & "' and a.grade='KB-B' and pancang_id='" & cboPancang.SelectedValue & "' and b.Customer='" & Customer & "'
        '                                            ORDER BY b.periode DESC),0) as GetValueInteger")

        'Dim PriceKC As Decimal = GetValueInteger("select isnull((select top 1 harga from tblRMMstHargaJualDtl as a inner join tblRMMstHargaJualHdr as b on a.header_id=b.id 
        '                                            where a.deleted=0 and b.deleted=0 and b.ApprovalStatus=1 and cast(b.periode as date)<=GETDATE() 
        '                                            and jenis_kelapa='" & Jenis & "' and a.grade='KB-C' and pancang_id='" & cboPancang.SelectedValue & "' and b.Customer='" & Customer & "'
        '                                            ORDER BY b.periode DESC),0) as GetValueInteger")

        Dim ItemName As String = ""
        Dim ItemName2 As String = ""
        If rdJambul.Checked = True Then
            ItemName = "JAMBUL-"
            ItemName2 = "JAMBUL-"
        ElseIf rdLicin.Checked = True Then
            ItemName = "LICIN-"
            ItemName2 = "LICIN-"
        ElseIf rdCungkil.Checked = True Then
            ItemName = "CUNGKIL-"
        ElseIf rdGelondong.Checked = True Then
            ItemName = "GELONDONG-"
        End If

        If rdKBA.Checked = True Then
            ItemName &= "KB-A"
            ItemName2 &= "KB-B"
        ElseIf rdKBB.Checked = True Then
            ItemName &= "KB-B"
            ItemName2 &= "KB-B"
        ElseIf rdKC.Checked = True Then
            ItemName &= "KC"
        ElseIf rdGD.Checked = True Then
            ItemName &= "GD"
        End If

        With fgPenjualan
            .Rows.Count = 1

            If rdKBA.Checked = True Then
                If rdKapalTenggelam.Checked = False Then
                    .AddItem(1)
                    .Item(.Rows.Count - 1, "ItemName") = ItemName
                    .Item(.Rows.Count - 1, "Qty") = txtKBAPbk.Text
                    .Item(.Rows.Count - 1, "Price") = fgFakturPabrik.Item(1, "HargaA")
                    .Item(.Rows.Count - 1, "TotalRpBeforePPH") = .Item(.Rows.Count - 1, "Qty") * .Item(.Rows.Count - 1, "Price")
                    If chkPPH22.Checked = True Then
                        .Item(.Rows.Count - 1, "PersenPPH") = 0.25
                        .Item(.Rows.Count - 1, "RpPPH") = Format(Math.Ceiling((CDec(.Item(.Rows.Count - 1, "TotalRpBeforePPH")) * 0.25) / 100), "#,##0")
                    Else
                        .Item(.Rows.Count - 1, "PersenPPH") = 0
                        .Item(.Rows.Count - 1, "RpPPH") = 0
                    End If
                    .Item(.Rows.Count - 1, "TotalRp") = .Item(.Rows.Count - 1, "TotalRpBeforePPH") - .Item(.Rows.Count - 1, "RpPPH")

                    .AddItem(2)
                    .Item(.Rows.Count - 1, "ItemName") = ItemName2
                    .Item(.Rows.Count - 1, "Qty") = txtKBBPbk.Text
                    .Item(.Rows.Count - 1, "Price") = fgFakturPabrik.Item(1, "HargaB")
                    .Item(.Rows.Count - 1, "TotalRpBeforePPH") = .Item(.Rows.Count - 1, "Qty") * .Item(.Rows.Count - 1, "Price")
                    If chkPPH22.Checked = True Then
                        .Item(.Rows.Count - 1, "PersenPPH") = 0.25
                        .Item(.Rows.Count - 1, "RpPPH") = Format(Math.Ceiling((CDec(.Item(.Rows.Count - 1, "TotalRpBeforePPH")) * 0.25) / 100), "#,##0")
                    Else
                        .Item(.Rows.Count - 1, "PersenPPH") = 0
                        .Item(.Rows.Count - 1, "RpPPH") = 0
                    End If
                    .Item(.Rows.Count - 1, "TotalRp") = .Item(.Rows.Count - 1, "TotalRpBeforePPH") - .Item(.Rows.Count - 1, "RpPPH")
                Else
                    .AddItem(1)
                    .Item(.Rows.Count - 1, "ItemName") = ItemName2
                    .Item(.Rows.Count - 1, "Qty") = txtKBBPbk.Text
                    .Item(.Rows.Count - 1, "Price") = fgFakturPabrik.Item(1, "HargaB")
                    .Item(.Rows.Count - 1, "TotalRpBeforePPH") = .Item(.Rows.Count - 1, "Qty") * .Item(.Rows.Count - 1, "Price")
                    If chkPPH22.Checked = True Then
                        .Item(.Rows.Count - 1, "PersenPPH") = 0.25
                        .Item(.Rows.Count - 1, "RpPPH") = Format(Math.Ceiling((CDec(.Item(.Rows.Count - 1, "TotalRpBeforePPH")) * 0.25) / 100), "#,##0")
                    Else
                        .Item(.Rows.Count - 1, "PersenPPH") = 0
                        .Item(.Rows.Count - 1, "RpPPH") = 0
                    End If
                    .Item(.Rows.Count - 1, "TotalRp") = .Item(.Rows.Count - 1, "TotalRpBeforePPH") - .Item(.Rows.Count - 1, "RpPPH")
                End If
            ElseIf rdKBB.Checked = True Then
                .AddItem(1)
                .Item(.Rows.Count - 1, "ItemName") = ItemName2
                .Item(.Rows.Count - 1, "Qty") = txtKBBPbk.Text
                .Item(.Rows.Count - 1, "Price") = fgFakturPabrik.Item(1, "HargaB")
                .Item(.Rows.Count - 1, "TotalRpBeforePPH") = .Item(.Rows.Count - 1, "Qty") * .Item(.Rows.Count - 1, "Price")
                If chkPPH22.Checked = True Then
                    .Item(.Rows.Count - 1, "PersenPPH") = 0.25
                    .Item(.Rows.Count - 1, "RpPPH") = Format(Math.Ceiling((CDec(.Item(.Rows.Count - 1, "TotalRpBeforePPH")) * 0.25) / 100), "#,##0")
                Else
                    .Item(.Rows.Count - 1, "PersenPPH") = 0
                    .Item(.Rows.Count - 1, "RpPPH") = 0
                End If
                .Item(.Rows.Count - 1, "TotalRp") = .Item(.Rows.Count - 1, "TotalRpBeforePPH") - .Item(.Rows.Count - 1, "RpPPH")
            ElseIf rdKC.Checked = True Then
                .AddItem(1)
                .Item(.Rows.Count - 1, "ItemName") = ItemName
                .Item(.Rows.Count - 1, "Qty") = txtKCPbk.Text
                .Item(.Rows.Count - 1, "Price") = fgFakturPabrik.Item(1, "HargaKC")
                .Item(.Rows.Count - 1, "TotalRpBeforePPH") = .Item(.Rows.Count - 1, "Qty") * .Item(.Rows.Count - 1, "Price")
                If chkPPH22.Checked = True Then
                    .Item(.Rows.Count - 1, "PersenPPH") = 0.25
                    .Item(.Rows.Count - 1, "RpPPH") = Format(Math.Ceiling((CDec(.Item(.Rows.Count - 1, "TotalRpBeforePPH")) * 0.25) / 100), "#,##0")
                Else
                    .Item(.Rows.Count - 1, "PersenPPH") = 0
                    .Item(.Rows.Count - 1, "RpPPH") = 0
                End If
                .Item(.Rows.Count - 1, "TotalRp") = .Item(.Rows.Count - 1, "TotalRpBeforePPH") - .Item(.Rows.Count - 1, "RpPPH")
            ElseIf rdGD.Checked = True Then
                .AddItem(1)
                .Item(.Rows.Count - 1, "ItemName") = ItemName
                .Item(.Rows.Count - 1, "Qty") = txtGDPbk.Text
                .Item(.Rows.Count - 1, "Price") = fgFakturPabrik.Item(1, "HargaGD")
                .Item(.Rows.Count - 1, "TotalRpBeforePPH") = .Item(.Rows.Count - 1, "Qty") * .Item(.Rows.Count - 1, "Price")
                If chkPPH22.Checked = True Then
                    .Item(.Rows.Count - 1, "PersenPPH") = 0.25
                    .Item(.Rows.Count - 1, "RpPPH") = Format(Math.Ceiling((CDec(.Item(.Rows.Count - 1, "TotalRpBeforePPH")) * 0.25) / 100), "#,##0")
                Else
                    .Item(.Rows.Count - 1, "PersenPPH") = 0
                    .Item(.Rows.Count - 1, "RpPPH") = 0
                End If
                .Item(.Rows.Count - 1, "TotalRp") = .Item(.Rows.Count - 1, "TotalRpBeforePPH") - .Item(.Rows.Count - 1, "RpPPH")
            End If

            .Rows.Insert(1)

            Call SumPenjualan()

            .AutoSizeCols()
        End With

        If rdHabis.Checked = True Then
            If rdKapalTenggelam.Checked = False Then
                Dim totalPabrik As Decimal = fgAllPabrik.Item(1, "Total")
                Dim totalPancang As Decimal = CDec(fgPancang.Item(1, "Netto2"))

                ' hitung susut bertambah
                Dim SusutBertambah As Decimal = 0D
                If totalPancang > totalPabrik Then
                    txtSusut.Text = FormatNumber(totalPancang - totalPabrik, 0)
                    txtBertambah.Text = "0"
                ElseIf totalPancang > totalPabrik Then
                    txtBertambah.Text = FormatNumber(totalPancang - totalPabrik, 0)
                    txtSusut.Text = "0"
                Else
                    txtSusut.Text = "0"
                    txtBertambah.Text = "0"
                End If
            Else
                txtSusut.Text = "0"
                txtBertambah.Text = "0"
            End If
        End If

        'Call CekKecocokanPenjualanDanBongkar()
    End Sub

    Private Sub SumPenjualan()
        Try
            With fgPenjualan
                Dim totalQty As Decimal = 0
                Dim totalBeforePPH As Decimal = 0
                Dim totalRpPPH As Decimal = 0
                Dim totalTotalRp As Decimal = 0

                For i = 2 To .Rows.Count - 1
                    totalQty += CDec(.Item(i, "Qty"))
                    totalBeforePPH += CDec(.Item(i, "TotalRpBeforePPH"))
                    totalRpPPH += CDec(.Item(i, "RpPPH"))
                    totalTotalRp += CDec(.Item(i, "TotalRp"))
                Next

                .Item(1, "Qty") = totalQty
                .Item(1, "TotalRpBeforePPH") = totalBeforePPH
                .Item(1, "RpPPH") = totalRpPPH
                .Item(1, "TotalRp") = totalTotalRp

                ' styling total
                .Rows(1).StyleNew.BackColor = Color.LightYellow
                .Rows(1).StyleNew.Font = New Font(.Font, FontStyle.Bold)
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CekKecocokanPenjualanDanBongkar()
        'Dim c As Integer = fgPenjualan.Cols("Qty").Index

        '' buat style sekali saja
        'Dim s As C1.Win.C1FlexGrid.CellStyle
        'If fgPenjualan.Styles.Contains("QtyColor") Then
        '    s = fgPenjualan.Styles("QtyColor")
        'Else
        '    s = fgPenjualan.Styles.Add("QtyColor")
        'End If

        '' tentukan warnanya
        'If fgPenjualan.Item(1, "Qty") <> fgPabrik.Item(1, "Total") Then
        '    s.BackColor = Color.Salmon
        'Else
        '    s.BackColor = Color.LightGreen
        'End If

        '' apply ke cell
        'fgPenjualan.SetCellStyle(1, c, s)
    End Sub

    Private Sub FrmTrnPembuatanPenjualan_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Panel12.Width = Me.Width \ 2

        grpFakturPembelian.Width = Me.Width \ 3
        PanelPabrik.Width = Me.Width \ 3
    End Sub

    Private Sub fgPabrik_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fgPabrik.BeforeEdit
        If fgPabrik.Cols(e.Col).Name <> "Select" Then
            e.Cancel = True
        End If
    End Sub

    Private Sub fgPenjualan_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fgPenjualan.BeforeEdit
        If fgPenjualan.Cols(e.Col).Name <> "Qty" Then
            e.Cancel = True
        End If
    End Sub

    Private Sub fgPenjualan_AfterEdit(sender As Object, e As RowColEventArgs) Handles fgPenjualan.AfterEdit
        Call SumPenjualan()
        Call CekKecocokanPenjualanDanBongkar()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' === Deklarasi koneksi dan transaksi ===
        Dim Conn As SqlConnection = DB.OpenConnection(StrConnRMPApp)
        Dim Trans As SqlTransaction = Conn.BeginTransaction()
        Dim NoTrans As String = ""
        Dim Pesan As String = ""

        If MsgBoxCustom.Show("Apakah Anda yakin ingin menyimpan data ini?", MsgBoxCustom.ButtonType.YesNo, MsgBoxCustom.IconType.Question) = vbNo Then
            Exit Sub
        End If

        ' === Validasi awal ===
        If txtTrip.Text = "" Then
            MsgBoxCustom.Show("Silakan isi No Trip terlebih dahulu.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Exit Sub
        End If

        If cboPancang.Text = "" Then
            MsgBoxCustom.Show("Silakan pilih Pancang terlebih dahulu.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Exit Sub
        End If

        If cboKapal.Text = "" Then
            MsgBoxCustom.Show("Silakan pilih Kapal terlebih dahulu.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Exit Sub
        End If

        For r As Integer = 2 To fgPenjualan.Rows.Count - 1
            If CDec(fgPenjualan.Item(r, "Price")) <= 0 Then
                MsgBoxCustom.Show("Harga jual tidak boleh 0 (nol). Silakan periksa kembali data penjualan.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                Exit Sub
            End If
        Next

        ' jika bersambung qty jual harus > stok
        If rdBersambung.Checked = True Then
            Dim totalStok As Decimal = 0D
            For i As Integer = 1 To fgStok.Rows.Count - 1
                totalStok += CDec(fgStok.Item(i, "Qty"))
            Next

            If CInt(fgPenjualan.Item(1, "Qty")) > CInt(totalStok) Then
                MsgBoxCustom.Show("Mode Bersambung mengharuskan total penjualan lebih Kecil atau sama dengan total stok, Silakan periksa kembali.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                Exit Sub
            End If
        End If

        ' cek item grade BPI
        Dim CekItemGrade As String = DB.ExecuteScalarValue(Of String)(StrConnRMPApp, "select top 1 isnull(g.Grade, '') as GetValueString
                                                from DBPancang..tblINVMstItem i
                                                left join DBPancang..tblINVMstItemGrade g on g.ItemID = i.ItemID
                                                where i.ItemName = '" & Jenis & "-" & Grade & "'")
        If CekItemGrade = "" Then
            MsgBoxCustom.Show("Item Grade belum di setting, setting terlebih dahulu!", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Exit Sub
        End If

        For i = 1 To fgPenjualan.Rows.Count - 1
            If i = 2 Then
                ItemID = DB.ExecuteScalarValue(Of String)(StrConnRMPApp, "select top 1 ISNULL(ItemID,'') AS GetValueString from DBPancang..tblINVMstItem where ItemName='" & fgPenjualan.Item(i, "ItemName") & "'")
            ElseIf i = 3 Then
                ItemID2 = DB.ExecuteScalarValue(Of String)(StrConnRMPApp, "select top 1 ISNULL(ItemID,'') AS GetValueString from DBPancang..tblINVMstItem where ItemName='" & fgPenjualan.Item(i, "ItemName") & "'")
            End If
        Next

        Me.Cursor = Cursors.WaitCursor

        Try
            ' ===  Simpan HEADER ===
            NoTrans = SaveHdr(Conn, Trans)
            If String.IsNullOrEmpty(NoTrans) Then
                Throw New Exception("Simpan Data Header Gagal!")
            End If

            ' ===  Simpan NOTA PABRIK ===
            If rdCustomer.Checked = False Then
                For rnp As Integer = 2 To fgPabrik.Rows.Count - 1
                    If SaveDtlNotaPabrik(Conn, Trans, NoTrans, rnp, Pesan) = False Then
                        If Pesan <> "" Then
                            MsgBoxCustom.Show(Pesan, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                        End If
                        Throw New Exception("Simpan Data Detail Nota Pabrik Gagal pada baris ke-" & rnp)
                    End If
                Next
            End If

            ' ===  Simpan STOK ===
            For rs As Integer = 1 To fgStok.Rows.Count - 1
                If SaveDtlStok(Conn, Trans, NoTrans, rs) = False Then
                    Throw New Exception("Simpan Data Detail Stok Gagal pada baris ke-" & rs)
                End If
            Next

            ' ===  Simpan Faktur Pabrik ===
            If SaveFakturPabrik(Conn, Trans, NoTrans, 1) = False Then
                Throw New Exception("Simpan Data Faktur Pabrik Gagal")
            End If

            ' ===  Update Faktur Pabrik Sudah Di Gunakan = 1 ===
            If rdPSG.Checked = True Then
                DB.ExecuteQuery(StrConnPSGRMP, "UPDATE tblRMTrnPenerimaanKBKGHdr
                                                            SET TFtoBPI = 1
                                                            WHERE Nonota = '" & fgFakturPabrik.Item(1, "NoNota") & "'

                                                            UPDATE tblRMTrnPenerimaanKCDtl
                                                            SET TFtoBPI = 1
                                                            WHERE NoNota = '" & fgFakturPabrik.Item(1, "NoNota") & "'")
            ElseIf rdRSUP.Checked = True Then
                DB.ExecuteQuery(StrConnAccounting, "update tblRMTrnPenerimaanKBHdr set UseBPI=1 where NoNota='" & fgFakturPabrik.Item(1, "NoNota") & "'
                                                                update RSUPAccounting..tblRMTrnPenerimaanKCHdr set UseBPI=1 where NoNota='" & fgFakturPabrik.Item(1, "NoNota") & "'")
            ElseIf rdCustomer.Checked = True Then
                DB.ExecuteQuery(StrConnRMPApp, "update A  
                                                                set a.pullBPI=1,a.PullBPIBy='',a.PullBPIDate=getdate()
                                                                from Supplier_TransaksiKelapa as A
                                                                inner join Supplier_HargaHeader as B on a.IDHeader=b.id
                                                                where b.NoInvoice='" & fgFakturPabrik.Item(1, "NoNota") & "'")
            End If

            ' === OPNAME ===
            'If CInt(txtBertambah.Text) > 0 Then

            'End If

            ' === DOWN GRADE STOK ===
            If SaveDownGradeKelapa(Conn, Trans, NoTrans) = False Then
                Throw New Exception("Down Grade gagal.")
            End If

            ' ===  Simpan DETAIL ===
            For r As Integer = 2 To fgPenjualan.Rows.Count - 1
                If SaveDtlPenjualan(Conn, Trans, NoTrans, r) = False Then
                    Throw New Exception("Simpan Data Detail Penjualan Gagal pada baris ke-" & r)
                End If
            Next

            ' === DELIVERY ORDER ===
            If SaveDtlAutoGenerateSales(Conn, Trans, NoTrans) = False Then
                Throw New Exception("Generate Delivery Order Gagal, Coba save kembali.")
            End If

            ' === 3. Commit jika semua sukses ===
            Trans.Commit()

            ' Untuk debug
            'Trans.Rollback()
            'MsgBoxCustom.Show("Data berhasil disimpan.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            'Exit Sub

            MsgBoxCustom.Show("Data berhasil disimpan.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)

            Call LoadDataView(NoTrans)
        Catch ex As Exception
            ' === Rollback jika ada error ===
            Try
                ' ===  Update Faktur Pabrik Sudah Di Gunakan = 0 ===
                If rdPSG.Checked = True Then
                    DB.ExecuteQuery(StrConnPSGRMP, "UPDATE tblRMTrnPenerimaanKBKGHdr
                                                            SET TFtoBPI = 0
                                                            WHERE Nonota = '" & fgFakturPabrik.Item(1, "NoNota") & "'

                                                            UPDATE tblRMTrnPenerimaanKCDtl
                                                            SET TFtoBPI = 0
                                                            WHERE NoNota = '" & fgFakturPabrik.Item(1, "NoNota") & "'")
                ElseIf rdRSUP.Checked = True Then
                    DB.ExecuteQuery(StrConnAccounting, "update tblRMTrnPenerimaanKBHdr set UseBPI=1 where NoNota='" & fgFakturPabrik.Item(1, "NoNota") & "'
                                                                update RSUPAccounting..tblRMTrnPenerimaanKCHdr set UseBPI=1 where NoNota='" & fgFakturPabrik.Item(1, "NoNota") & "'")
                ElseIf rdCustomer.Checked = True Then
                    DB.ExecuteQuery(StrConnRMPApp, "update A  
                                                                set a.pullBPI=0,a.PullBPIBy='',a.PullBPIDate=getdate()
                                                                from Supplier_TransaksiKelapa as A
                                                                inner join Supplier_HargaHeader as B on a.IDHeader=b.id
                                                                where b.NoInvoice='" & fgFakturPabrik.Item(1, "NoNota") & "'")
                End If

                Trans.Rollback()
            Catch
            End Try

            MsgBoxCustom.Show(ex.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)

        Finally
            ' === Tutup koneksi dan kembalikan cursor ===
            If Conn.State = ConnectionState.Open Then Conn.Close()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function SaveHdr(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As String
        SaveHdr = ""

        Try
            Using cmd As New SqlCommand("spTrnPembuatanPenjualanHdr", Conn, Trans)
                cmd.CommandType = CommandType.StoredProcedure

                ' =============================
                ' INPUT PARAMETERS
                ' =============================
                cmd.Parameters.Add("@NoTrans", SqlDbType.VarChar, 30).Value = ""   ' kosong → SP akan generate otomatis

                cmd.Parameters.Add("@TanggalPenjualan", SqlDbType.DateTime).Value = dtpTanggalPenjualan.Value
                cmd.Parameters.Add("@TanggalNota1", SqlDbType.DateTime).Value = dtpTanggalNota1.Value
                cmd.Parameters.Add("@TanggalNota2", SqlDbType.DateTime).Value = dtpTanggalNota2.Value

                cmd.Parameters.Add("@Trip", SqlDbType.Int).Value = CInt(txtTrip.Text)

                cmd.Parameters.Add("@IDPancang", SqlDbType.Int).Value = CInt(cboPancang.SelectedValue)
                cmd.Parameters.Add("@IDKapal", SqlDbType.Int).Value = CInt(cboKapal.SelectedValue)

                cmd.Parameters.Add("@Tujuan", SqlDbType.VarChar, 20).Value = Tujuan
                cmd.Parameters.Add("@Jenis", SqlDbType.VarChar, 20).Value = Jenis
                cmd.Parameters.Add("@Grade", SqlDbType.VarChar, 10).Value = Grade
                cmd.Parameters.Add("@GradeSub", SqlDbType.VarChar, 10).Value = GradeSub
                cmd.Parameters.Add("@Habis", SqlDbType.Int).Value = IIf(rdHabis.Checked = True, 1, 0)
                cmd.Parameters.Add("@PPH22Ind", SqlDbType.Int).Value = IIf(chkPPH22.Checked = True, 1, 0)

                cmd.Parameters.Add("@KBAPcg", SqlDbType.Int).Value = CInt(txtKBAPcg.Text)
                cmd.Parameters.Add("@KBAPbk", SqlDbType.Int).Value = CInt(txtKBAPbk.Text)
                cmd.Parameters.Add("@KBAPersen", SqlDbType.Decimal).Value = CDec(txtKBAPersen.Text)

                cmd.Parameters.Add("@KBBPcg", SqlDbType.Int).Value = CInt(txtKBBPcg.Text)
                cmd.Parameters.Add("@KBBPbk", SqlDbType.Int).Value = CInt(txtKBBPbk.Text)
                cmd.Parameters.Add("@KBBPersen", SqlDbType.Decimal).Value = CDec(txtKBBPersen.Text)

                cmd.Parameters.Add("@KCPcg", SqlDbType.Int).Value = CInt(txtKCPcg.Text)
                cmd.Parameters.Add("@KCPbk", SqlDbType.Int).Value = CInt(txtKCPbk.Text)
                cmd.Parameters.Add("@KCPersen", SqlDbType.Decimal).Value = CDec(txtKCPersen.Text)

                cmd.Parameters.Add("@GDPcg", SqlDbType.Int).Value = CInt(txtGDPcg.Text)
                cmd.Parameters.Add("@GDPbk", SqlDbType.Int).Value = CInt(txtGDPbk.Text)
                cmd.Parameters.Add("@GDPersen", SqlDbType.Decimal).Value = CDec(txtGDPersen.Text)

                cmd.Parameters.Add("@TotalPcg", SqlDbType.Int).Value = CInt(txtTotPcg.Text)
                cmd.Parameters.Add("@TotalPbk", SqlDbType.Int).Value = CInt(txtTotPbk.Text)

                cmd.Parameters.Add("@Susut", SqlDbType.Int).Value = CInt(txtSusut.Text)
                cmd.Parameters.Add("@Bertambah", SqlDbType.Int).Value = CInt(txtBertambah.Text)
                cmd.Parameters.Add("@FlagParigi", SqlDbType.Int).Value = 1

                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 100).Value = ClsSession.UserID
                cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = Now

                ' =============================
                ' OUTPUT PARAMETERS
                ' =============================
                cmd.Parameters("@NoTrans").Direction = ParameterDirection.Output

                Dim pFlag = cmd.Parameters.Add("@Flag", SqlDbType.Int)
                pFlag.Direction = ParameterDirection.Output

                ' =============================
                ' EXECUTE
                ' =============================
                cmd.ExecuteNonQuery()

                ' =============================
                ' OUTPUT VALUE
                ' =============================
                Dim resultFlag As Integer = CInt(pFlag.Value)
                Dim noTransResult As String = cmd.Parameters("@NoTrans").Value.ToString()

                If resultFlag = 1 Then
                    SaveHdr = noTransResult
                Else
                    SaveHdr = ""
                End If
            End Using

        Catch ex As Exception
            MsgBoxCustom.Show("Error saat simpan header: " & ex.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
            SaveHdr = ""
        End Try

        Return SaveHdr
    End Function


    Private Function SaveDtlNotaPabrik(ByVal Conn As SqlConnection,
                                   ByVal Trans As SqlTransaction,
                                   ByVal NoTrans As String,
                                   ByVal row As Integer,
                                   ByRef Pesan As String) As Boolean

        SaveDtlNotaPabrik = False

        Try
            Using cmd As New SqlCommand("spTrnPembuatanPenjualanNotaPabrik", Conn, Trans)
                cmd.CommandType = CommandType.StoredProcedure

                ' ========================
                ' PARAMETER INPUT
                ' ========================
                cmd.Parameters.Add("@NoTrans", SqlDbType.VarChar, 30).Value = NoTrans
                cmd.Parameters.Add("@Bongkar", SqlDbType.VarChar, 30).Value = fgPabrik.Item(row, "Bongkar").ToString()
                cmd.Parameters.Add("@NoNota", SqlDbType.VarChar, 30).Value = fgPabrik.Item(row, "NoNota").ToString()
                cmd.Parameters.Add("@Tanggal", SqlDbType.DateTime).Value = CDate(fgPabrik.Item(row, "Tanggal"))

                cmd.Parameters.Add("@KodeSup", SqlDbType.VarChar, 30).Value = fgPabrik.Item(row, "KodeSup").ToString()
                cmd.Parameters.Add("@NamaSup", SqlDbType.VarChar, 150).Value = fgPabrik.Item(row, "NamaSup").ToString()
                cmd.Parameters.Add("@NamaKapal", SqlDbType.VarChar, 150).Value = fgPabrik.Item(row, "NamaKapal").ToString()

                cmd.Parameters.Add("@KodeDermaga", SqlDbType.VarChar, 30).Value = fgPabrik.Item(row, "KodeDermaga").ToString()
                cmd.Parameters.Add("@NamaDermaga", SqlDbType.VarChar, 100).Value = fgPabrik.Item(row, "NamaDermaga").ToString()

                cmd.Parameters.Add("@Shift", SqlDbType.VarChar, 10).Value = fgPabrik.Item(row, "Shift").ToString()
                cmd.Parameters.Add("@Jenis", SqlDbType.VarChar, 20).Value = fgPabrik.Item(row, "Jenis").ToString()

                cmd.Parameters.Add("@TotalN1", SqlDbType.Int).Value = CInt(fgPabrik.Item(row, "TotalN1"))
                cmd.Parameters.Add("@TotalN1B", SqlDbType.Int).Value = CInt(fgPabrik.Item(row, "TotalN1B"))
                cmd.Parameters.Add("@KBA", SqlDbType.Int).Value = CInt(fgPabrik.Item(row, "KBA"))
                cmd.Parameters.Add("@KBB", SqlDbType.Int).Value = CInt(fgPabrik.Item(row, "KBB"))
                cmd.Parameters.Add("@KC", SqlDbType.Int).Value = CInt(fgPabrik.Item(row, "KC"))
                cmd.Parameters.Add("@GD", SqlDbType.Int).Value = CInt(fgPabrik.Item(row, "GD"))
                cmd.Parameters.Add("@Total", SqlDbType.Int).Value = CInt(fgPabrik.Item(row, "Total"))

                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 100).Value = Environment.UserName

                ' ========================
                ' OUTPUT PARAMETER
                ' ========================
                cmd.Parameters.Add("@Flag", SqlDbType.Int).Direction = ParameterDirection.Output
                cmd.Parameters.Add("@Pesan", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output

                ' Execute SP
                cmd.ExecuteNonQuery()

                Pesan = CStr(cmd.Parameters("@Pesan").Value)

                Dim resultFlag As Integer = CInt(cmd.Parameters("@Flag").Value)
                If resultFlag = 1 Then SaveDtlNotaPabrik = True
            End Using

        Catch ex As Exception
            MessageBox.Show("Error saat simpan nota pabrik: " & ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return SaveDtlNotaPabrik
    End Function

    Private Function SaveDtlStok(ByVal Conn As SqlConnection,
                             ByVal Trans As SqlTransaction,
                             ByVal NoTrans As String,
                             ByVal row As Integer) As Boolean

        SaveDtlStok = False

        Try
            Using cmd As New SqlCommand("spTrnPembuatanPenjualanStok", Conn, Trans)
                cmd.CommandType = CommandType.StoredProcedure

                ' ========================
                ' PARAMETER INPUT
                ' ========================
                cmd.Parameters.Add("@NoTrans", SqlDbType.VarChar, 30).Value = NoTrans
                cmd.Parameters.Add("@ItemID", SqlDbType.VarChar, 20).Value = fgStok.Item(row, "ItemID").ToString()
                cmd.Parameters.Add("@ItemName", SqlDbType.VarChar, 50).Value = fgStok.Item(row, "ItemName").ToString()
                cmd.Parameters.Add("@Qty", SqlDbType.BigInt).Value = CLng(fgStok.Item(row, "Qty"))
                cmd.Parameters.Add("@Price", SqlDbType.Int).Value = CInt(fgStok.Item(row, "Price"))
                cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = CDec(fgStok.Item(row, "TotalRp"))
                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 100).Value = ClsSession.UserID

                ' ========================
                ' PARAMETER OUTPUT
                ' ========================
                cmd.Parameters.Add("@Flag", SqlDbType.Int).Direction =
                ParameterDirection.Output

                ' ========================
                ' EKSEKUSI SP
                ' ========================
                cmd.ExecuteNonQuery()

                Dim resultFlag As Integer = CInt(cmd.Parameters("@Flag").Value)

                If resultFlag = 1 Then
                    SaveDtlStok = True
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Error saat simpan stok: " & ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
        End Try

        Return SaveDtlStok
    End Function

    Private Function SaveFakturPabrik(ByVal Conn As SqlConnection,
                                     ByVal Trans As SqlTransaction,
                                     ByVal NoTrans As String,
                                     ByVal row As Integer) As Boolean

        SaveFakturPabrik = False

        Try
            Using cmd As New SqlCommand("spTrnPembuatanPenjualanFakturPabrik", Conn, Trans)
                cmd.CommandType = CommandType.StoredProcedure

                ' ========================
                ' PARAMETER INPUT
                ' ========================
                cmd.Parameters.Add("@NoTrans", SqlDbType.VarChar, 30).Value = NoTrans

                cmd.Parameters.Add("@NoNota", SqlDbType.VarChar, 30).Value =
                fgFakturPabrik.Item(row, "NoNota").ToString()

                cmd.Parameters.Add("@TglTerima", SqlDbType.Date).Value =
                fgFakturPabrik.Item(row, "TanggalTerima").ToString()

                cmd.Parameters.Add("@Kapal", SqlDbType.VarChar, 100).Value =
                fgFakturPabrik.Item(row, "Kapal").ToString()

                cmd.Parameters.Add("@AsalKelapa", SqlDbType.VarChar, 100).Value =
                fgFakturPabrik.Item(row, "AsalKelapa").ToString()

                cmd.Parameters.Add("@Jenis", SqlDbType.VarChar, 30).Value = fgFakturPabrik.Item(row, "Jenis").ToString()

                cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar, 30).Value = fgFakturPabrik.Item(row, "CustomerID").ToString()

                cmd.Parameters.Add("@Netto1A", SqlDbType.Decimal).Value = CDec(If(IsDBNull(fgFakturPabrik.Item(row, "Netto1A")), 0, fgFakturPabrik.Item(row, "Netto1A")))

                cmd.Parameters.Add("@NettoA", SqlDbType.Decimal).Value = CDec(If(IsDBNull(fgFakturPabrik.Item(row, "NettoA")), 0, fgFakturPabrik.Item(row, "NettoA")))

                cmd.Parameters.Add("@NettoB", SqlDbType.Decimal).Value =
                CDec(If(IsDBNull(fgFakturPabrik.Item(row, "NettoB")), 0, fgFakturPabrik.Item(row, "NettoB")))

                cmd.Parameters.Add("@NettoKC", SqlDbType.Decimal).Value =
                CDec(If(IsDBNull(fgFakturPabrik.Item(row, "NettoKC")), 0, fgFakturPabrik.Item(row, "NettoKC")))

                cmd.Parameters.Add("@NettoGD", SqlDbType.Decimal).Value =
                CDec(If(IsDBNull(fgFakturPabrik.Item(row, "NettoGD")), 0, fgFakturPabrik.Item(row, "NettoGD")))

                cmd.Parameters.Add("@HargaA", SqlDbType.Decimal).Value =
                CDec(If(IsDBNull(fgFakturPabrik.Item(row, "HargaA")), 0, fgFakturPabrik.Item(row, "HargaA")))

                cmd.Parameters.Add("@HargaB", SqlDbType.Decimal).Value =
                CDec(If(IsDBNull(fgFakturPabrik.Item(row, "HargaB")), 0, fgFakturPabrik.Item(row, "HargaB")))

                cmd.Parameters.Add("@HargaKC", SqlDbType.Decimal).Value =
                CDec(If(IsDBNull(fgFakturPabrik.Item(row, "HargaKC")), 0, fgFakturPabrik.Item(row, "HargaKC")))

                cmd.Parameters.Add("@HargaGD", SqlDbType.Decimal).Value =
                CDec(If(IsDBNull(fgFakturPabrik.Item(row, "HargaGD")), 0, fgFakturPabrik.Item(row, "HargaGD")))

                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 100).Value =
                ClsSession.UserID

                ' ========================
                ' PARAMETER OUTPUT
                ' ========================
                cmd.Parameters.Add("@Flag", SqlDbType.Int).Direction =
                ParameterDirection.Output

                ' ========================
                ' EKSEKUSI SP
                ' ========================
                cmd.ExecuteNonQuery()

                Dim resultFlag As Integer = CInt(cmd.Parameters("@Flag").Value)

                If resultFlag = 1 Then
                    SaveFakturPabrik = True
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Error saat simpan faktur pabrik: " & ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
        End Try

        Return SaveFakturPabrik
    End Function


    Private Function SaveDtlPenjualan(ByVal Conn As SqlConnection,
                         ByVal Trans As SqlTransaction,
                         ByVal NoTrans As String,
                         ByVal r As Integer) As Boolean

        SaveDtlPenjualan = False

        Try
            Using cmd As New SqlCommand("spTrnPembuatanPenjualanDtl", Conn, Trans)
                cmd.CommandType = CommandType.StoredProcedure

                ' ================================
                ' Parameter Input
                ' ================================
                cmd.Parameters.Add("@NoTrans", SqlDbType.VarChar, 30).Value = NoTrans
                cmd.Parameters.Add("@ItemName", SqlDbType.VarChar, 50).Value = fgPenjualan.Item(r, "ItemName").ToString()
                cmd.Parameters.Add("@Qty", SqlDbType.BigInt).Value = CLng(fgPenjualan.Item(r, "Qty"))
                cmd.Parameters.Add("@Price", SqlDbType.Int).Value = CInt(fgPenjualan.Item(r, "Price"))
                cmd.Parameters.Add("@TotalRpBeforePPH", SqlDbType.Decimal).Value = CDec(fgPenjualan.Item(r, "TotalRpBeforePPH"))
                cmd.Parameters.Add("@PersenPPH", SqlDbType.Decimal).Value = CDec(fgPenjualan.Item(r, "PersenPPH"))
                cmd.Parameters.Add("@RpPPH", SqlDbType.Decimal).Value = CDec(fgPenjualan.Item(r, "RpPPH"))
                cmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = CDec(fgPenjualan.Item(r, "TotalRp"))
                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 100).Value = ClsSession.UserID
                cmd.Parameters.Add("@CreatedComputer", SqlDbType.VarChar, 30).Value = My.Computer.Name

                ' ================================
                ' Output parameter
                ' ================================
                cmd.Parameters.Add("@Flag", SqlDbType.Int).Direction = ParameterDirection.Output

                ' ================================
                ' Execute
                ' ================================
                cmd.ExecuteNonQuery()

                Dim resultFlag As Integer = CInt(cmd.Parameters("@Flag").Value)
                If resultFlag = 1 Then SaveDtlPenjualan = True
            End Using

        Catch ex As Exception
            MessageBox.Show("Error saat simpan detail penjualan : " & ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return SaveDtlPenjualan
    End Function

    Private Function SaveDownGradeKelapa(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal NoTrans As String) As Boolean

        SaveDownGradeKelapa = False

        Try
            Using cmd As New SqlCommand("DBPancang..INV_spDownGradeKelapaParigi", Conn, Trans)
                cmd.CommandType = CommandType.StoredProcedure

                ' ================================
                '  Parameter input dari datagrid
                ' ================================
                cmd.Parameters.Add("@NoTrans", SqlDbType.VarChar, 30).Value = NoTrans
                cmd.Parameters.Add("@TransDate", SqlDbType.DateTime).Value = dtpTanggalPenjualan.Value
                cmd.Parameters.Add("@ItemID", SqlDbType.VarChar, 20).Value = ItemID
                cmd.Parameters.Add("@QntyDownGrade", SqlDbType.Int).Value = CInt(txtKBBPbk.Text)
                cmd.Parameters.Add("@QntyLoss", SqlDbType.Int).Value = CInt(txtSusut.Text)
                cmd.Parameters.Add("@QntyBertambah", SqlDbType.Int).Value = CInt(txtBertambah.Text)
                If rdKBA.Checked = True And rdKapalTenggelam.Checked = False Then
                    cmd.Parameters.Add("@UnitPriceDownGrade", SqlDbType.Int).Value = CInt(fgPenjualan.Item(3, "Price"))
                    cmd.Parameters.Add("@UnitPriceBertambah", SqlDbType.Int).Value = CInt(fgPenjualan.Item(2, "Price"))
                Else
                    cmd.Parameters.Add("@UnitPriceDownGrade", SqlDbType.Int).Value = CInt(fgPenjualan.Item(2, "Price"))
                    cmd.Parameters.Add("@UnitPriceBertambah", SqlDbType.Int).Value = CInt(fgPenjualan.Item(2, "Price"))
                End If
                cmd.Parameters.Add("@IDPancang", SqlDbType.Int).Value = CInt(cboPancang.SelectedValue)
                cmd.Parameters.Add("@AppVersion", SqlDbType.VarChar, 10).Value = My.Application.Info.Version.ToString()
                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID

                ' ================================
                '  Output parameter
                ' ================================
                cmd.Parameters.Add("@Flag", SqlDbType.BigInt).Direction = ParameterDirection.Output
                'cmd.Parameters.Add("@Msg", SqlDbType.BigInt).Direction = ParameterDirection.Output

                ' ================================
                '  Execute
                ' ================================
                cmd.ExecuteNonQuery()

                'pesan untuk debug hasil sp
                'MsgBoxCustom.Show(CLng(cmd.Parameters("@Msg").Value).ToString(), MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)

                Dim resultFlag As Long = CLng(cmd.Parameters("@Flag").Value)
                If resultFlag = 1 Then
                    SaveDownGradeKelapa = True
                End If

            End Using

        Catch ex As Exception
            MessageBox.Show("Error saat simpan downgrade: " & ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return SaveDownGradeKelapa
    End Function

    Private Function SaveDtlAutoGenerateSales(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal NoTrans As String) As Boolean

        SaveDtlAutoGenerateSales = False

        Dim GradeSub As String = ""
        If rdKBA.Checked = True Or rdKBB.Checked = True Then
            GradeSub = IIf(chkA6.Checked = True, "A6", "A")
        End If

        Try
            Using cmd As New SqlCommand("DBPancang..SLS_spAutoGenerateSalesParigi", Conn, Trans)
                cmd.CommandType = CommandType.StoredProcedure

                ' ================================
                '  Parameter input dari datagrid
                ' ================================
                cmd.Parameters.Add("@NoTransPengajuan", SqlDbType.VarChar, 30).Value = NoTrans
                cmd.Parameters.Add("@TanggalPenjualan", SqlDbType.DateTime).Value = dtpTanggalPenjualan.Value
                cmd.Parameters.Add("@IDPancang", SqlDbType.Int).Value = CInt(cboPancang.SelectedValue)

                If (rdJambul.Checked = True Or rdLicin.Checked = True) And rdKBA.Checked = True Then
                    If rdKapalTenggelam.Checked = False Then
                        cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = CInt(fgPenjualan.Item(2, "Qty"))
                        cmd.Parameters.Add("@Qty2", SqlDbType.Int).Value = CInt(fgPenjualan.Item(3, "Qty"))
                        cmd.Parameters.Add("@Price", SqlDbType.Int).Value = CInt(fgPenjualan.Item(2, "Price"))
                        cmd.Parameters.Add("@Price2", SqlDbType.Int).Value = CInt(fgPenjualan.Item(3, "Price"))
                        cmd.Parameters.Add("@ItemID", SqlDbType.VarChar, 30).Value = ItemID
                        cmd.Parameters.Add("@ItemID2", SqlDbType.VarChar, 30).Value = ItemID2
                    Else
                        cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = CInt(fgPenjualan.Item(2, "Qty"))
                        cmd.Parameters.Add("@Qty2", SqlDbType.Int).Value = 0
                        cmd.Parameters.Add("@Price", SqlDbType.Int).Value = CInt(fgPenjualan.Item(2, "Price"))
                        cmd.Parameters.Add("@Price2", SqlDbType.Int).Value = CInt(fgPenjualan.Item(2, "Price"))
                        cmd.Parameters.Add("@ItemID", SqlDbType.VarChar, 30).Value = ItemID
                        cmd.Parameters.Add("@ItemID2", SqlDbType.VarChar, 30).Value = ""
                    End If

                Else
                    cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = CInt(fgPenjualan.Item(2, "Qty"))
                    cmd.Parameters.Add("@Qty2", SqlDbType.Int).Value = 0
                    cmd.Parameters.Add("@Price", SqlDbType.Int).Value = CInt(fgPenjualan.Item(2, "Price"))
                    cmd.Parameters.Add("@Price2", SqlDbType.Int).Value = CInt(fgPenjualan.Item(2, "Price"))
                    cmd.Parameters.Add("@ItemID", SqlDbType.VarChar, 30).Value = ItemID
                    cmd.Parameters.Add("@ItemID2", SqlDbType.VarChar, 30).Value = ""
                End If

                cmd.Parameters.Add("@RefrensiNota", SqlDbType.VarChar, 30).Value = fgFakturPabrik.Item(1, "NoNota").ToString()
                cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar, 30).Value = fgFakturPabrik.Item(1, "CustomerID")
                cmd.Parameters.Add("@PPH22Ind", SqlDbType.Int).Value = If(chkPPH22.Checked = True, 1, 0)
                cmd.Parameters.Add("@AppVersion", SqlDbType.VarChar, 10).Value = My.Application.Info.Version.ToString()
                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 15).Value = ClsSession.UserID

                ' ================================
                '  Output parameter
                ' ================================
                cmd.Parameters.Add("@Flag", SqlDbType.BigInt).Direction = ParameterDirection.Output
                cmd.Parameters.Add("@Msg", SqlDbType.VarChar, 300).Direction = ParameterDirection.Output

                ' ================================
                '  Execute
                ' ================================
                cmd.ExecuteNonQuery()

                Dim resultFlag As Long = CLng(cmd.Parameters("@Flag").Value)
                Dim resultMsg As String = cmd.Parameters("@Msg").Value.ToString()

                If resultFlag = 1 Then
                    SaveDtlAutoGenerateSales = True
                Else
                    ' Tampilkan pesan step mana yang gagal (dikirim dari SP)
                    MessageBox.Show("Auto Generate Sales gagal." & vbCrLf &
                                     "Detail : " & resultMsg,
                                     "Auto Generate Sales", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            End Using



        Catch ex As SqlClient.SqlException

            Dim s As String = ""

            For Each er As SqlClient.SqlError In ex.Errors
                s &= "Number    : " & er.Number & vbCrLf
                s &= "Procedure : " & er.Procedure & vbCrLf
                s &= "Line      : " & er.LineNumber & vbCrLf
                s &= "Message   : " & er.Message & vbCrLf
                s &= "------------------------" & vbCrLf
            Next

            MessageBox.Show(s)

        Catch ex As Exception

            MessageBox.Show(ex.ToString())

        End Try

        Return SaveDtlAutoGenerateSales
    End Function


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        rdBersambung.Checked = False
        rdHabis.Checked = False
        rdBersambung.Enabled = True
        rdHabis.Enabled = True

        btnSearch.Enabled = True
        btnProposional.Enabled = True
        btnCancel.Enabled = False
        rdKapalTenggelam.Enabled = True

        fgPabrik.AllowEditing = True

        fgFakturPabrik.Rows.Count = 1
        fgPabrik.Rows.Count = 1
        fgAllPabrik.Rows.Count = 1
        fgPancang.Rows.Count = 1
        fgStok.Rows.Count = 1
        fgPenjualan.Rows.Count = 1

        txtSusut.Text = "0"
        txtBertambah.Text = "0"

        txtKBAPcg.Text = "0"
        txtKBAPbk.Text = "0"
        txtKBAPersen.Text = "0.00"
        txtKBBPcg.Text = "0"
        txtKBBPbk.Text = "0"
        txtKBBPersen.Text = "0.00"
        txtKCPcg.Text = "0"
        txtKCPbk.Text = "0"
        txtKCPersen.Text = "0.00"
        txtTotPcg.Text = "0"
        txtTotPbk.Text = "0"
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        FrmTrnPenjualan.ShowData()
        FrmTrnPenjualan.Show(FrmMain.DockPanel1)
        FrmTrnPenjualan.Activate()
        Me.Close()
    End Sub

    Public Sub LoadDataView(ByVal NoTrans As String)
        Call ShowDataHdr(NoTrans)
        Call ShowDataFakturPabrikView(NoTrans)
        Call ShowDataDtl(NoTrans)
        Call ShowDataPancang()
        Call ShowDataStokView(NoTrans)

        If rdRSUP.Checked = True Or rdPSG.Checked = True Then
            Call ShowDataPabrikView(NoTrans)
        End If

        Call EnabelInput(False)
        dtpTanggalPenjualan.Enabled = False
        fgPabrik.AllowEditing = False

        btnSearch.Enabled = False
        btnProposional.Enabled = False
        btnCancel.Enabled = False
        btnSave.Enabled = False
    End Sub

    Private Sub ShowDataHdr(ByVal NoTrans As String)
        Dim dt As DataTable = New DataTable
        dt = DB.ExecuteQuery(StrConnRMPApp, "select * from tblTrnPembuatanPenjualanHdr where NoTrans='" & NoTrans & "'")
        Dim row As DataRow = dt.Rows(0)

        txtNoTrans.Text = NoTrans
        dtpTanggalPenjualan.Value = row("TanggalPenjualan")
        dtpTanggalNota1.Value = row("TanggalNota1")
        dtpTanggalNota2.Value = row("TanggalNota2")
        txtTrip.Text = row("Trip")
        cboPancang.SelectedValue = row("IDPancang")
        cboKapal.SelectedValue = row("IDKapal")

        Select Case row("Tujuan")
            Case "RSUP"
                rdRSUP.Checked = True
            Case "PSG"
                rdPSG.Checked = True
            Case "Customer"
                rdCustomer.Checked = True
        End Select

        Select Case row("Jenis")
            Case "Jambul"
                rdJambul.Checked = True
            Case "Licin"
                rdLicin.Checked = True
            Case "Cungkil"
                rdCungkil.Checked = True
            Case "Gelondong"
                rdGelondong.Checked = True
        End Select

        Select Case row("Grade")
            Case "KB-A"
                rdKBA.Checked = True
            Case "KB-B"
                rdKBB.Checked = True
            Case "KC"
                rdKC.Checked = True
            Case "GD"
                rdGD.Checked = True
        End Select

        If Not IsDBNull(row("GradeSub")) And row("GradeSub") = "A6" Then
            chkA6.Checked = True
        Else
            chkA6.Checked = False
        End If

        If row("Habis") = True Then
            rdHabis.Checked = True
        Else
            rdBersambung.Checked = True
        End If

        chkPPH22.Checked = If(IsDBNull(row("PPH22Ind")), False, CBool(row("PPH22Ind")))

        txtKBAPcg.Text = FormatNumber(row("KBAPcg"), 0)
        txtKBAPbk.Text = FormatNumber(row("KBAPbk"), 0)
        txtKBAPersen.Text = FormatNumber(row("KBAPersen"), 2)
        txtKBBPcg.Text = FormatNumber(row("KBBPcg"), 0)
        txtKBBPbk.Text = FormatNumber(row("KBBPbk"), 0)
        txtKBBPersen.Text = FormatNumber(row("KBBPersen"), 2)
        txtKCPcg.Text = FormatNumber(row("KCPcg"), 0)
        txtKCPbk.Text = FormatNumber(row("KCPbk"), 0)
        txtKCPersen.Text = FormatNumber(row("KCPersen"), 2)
        txtGDPcg.Text = FormatNumber(IIf(IsDBNull(row("GDPcg")), 0, row("GDPcg")), 0)
        txtGDPbk.Text = FormatNumber(IIf(IsDBNull(row("GDPbk")), 0, row("GDPbk")), 0)
        txtGDPersen.Text = FormatNumber(IIf(IsDBNull(row("GDPersen")), 0, row("GDPersen")), 0)
        txtTotPcg.Text = FormatNumber(row("TotalPcg"), 0)
        txtTotPbk.Text = FormatNumber(row("TotalPbk"), 0)
        txtSusut.Text = FormatNumber(row("Susut"), 0)
        txtBertambah.Text = FormatNumber(row("Bertambah"), 0)
    End Sub

    Private Sub ShowDataDtl(ByVal NoTrans As String)
        Dim dt As New DataTable
        Dim i As Integer = 1

        Dim sql As String = "select * from tblTrnPembuatanPenjualanDtl where NoTrans='" & NoTrans & "'"

        dt = DB.ExecuteQuery(StrConnRMPApp, sql)

        With fgPenjualan
            .Rows.Count = 1 ' Reset grid sebelum mengisi data baru

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "ItemName") = row("ItemName")
                    .Item(i, "Qty") = row("Qty")
                    .Item(i, "Price") = row("Price")
                    .Item(i, "TotalRpBeforePPH") = row("TotalRpBeforePPH")
                    .Item(i, "PersenPPH") = row("PersenPPH")
                    .Item(i, "RpPPH") = row("RpPPH")
                    .Item(i, "TotalRp") = row("Total")

                    i += 1
                Next

                .AutoSizeCols()
            Else
                MsgBoxCustom.Show("Tidak ada data.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            End If

            .Rows.Insert(1)

            Call SumPenjualan()
        End With
    End Sub

    Private Sub ShowDataFakturPabrikView(ByVal NoTrans As String)
        Dim dt As New DataTable
        Dim i As Integer = 1

        Dim sql As String = "select * from vwPembuatanPenjualanFakturPabrik where NoTrans='" & NoTrans & "'"

        dt = DB.ExecuteQuery(StrConnRMPApp, sql)

        With fgFakturPabrik
            .Rows.Count = 1 ' Reset grid sebelum mengisi data baru

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
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
                    .Item(i, "NettoGD") = row("NettoGD")
                    .Item(i, "HargaA") = row("HargaA")
                    .Item(i, "HargaB") = row("HargaB")
                    .Item(i, "HargaKC") = row("HargaKC")
                    .Item(i, "HargaGD") = row("HargaGD")

                    i += 1
                Next

                .AutoSizeCols()
            Else
                MsgBoxCustom.Show("Tidak ada data.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            End If
        End With
    End Sub

    Private Sub ShowDataPabrikView(ByVal NoTrans As String)
        Dim dt As New DataTable
        Dim i As Integer = 1
        Dim sql As String = "select * from tblTrnPembuatanPenjualanNotaPabrik where NoTrans='" & NoTrans & "'"

        dt = DB.ExecuteQuery(StrConnRMPApp, sql)

        With fgPabrik
            .Rows.Count = 1 ' Reset grid sebelum mengisi data baru

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "Bongkar") = row("Bongkar")
                    .Item(i, "NoNota") = row("NoNota")
                    .Item(i, "Tanggal") = row("Tanggal")
                    .Item(i, "KodeSup") = row("KodeSup")
                    .Item(i, "NamaSup") = row("NamaSup")
                    .Item(i, "NamaKapal") = row("NamaKapal")
                    .Item(i, "KodeDermaga") = row("KodeDermaga")
                    .Item(i, "NamaDermaga") = row("NamaDermaga")
                    .Item(i, "Shift") = row("Shift")
                    .Item(i, "Jenis") = row("Jenis")
                    .Item(i, "TotalN1") = row("TotalN1")
                    .Item(i, "KBA") = row("KBA")
                    .Item(i, "KBB") = row("KBB")
                    .Item(i, "KC") = row("KC")
                    .Item(i, "GD") = IIf(IsDBNull(row("GD")), 0, row("GD"))
                    .Item(i, "Total") = row("Total")

                    i += 1
                Next

                .AutoSizeCols()
            Else
                MsgBoxCustom.Show("Tidak ada data.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            End If

            ' === Tambahkan baris TOTAL pada index 1 ===
            .Rows.Insert(1)
            .Item(1, "NoNota") = "TOTAL"

            ' --- Variabel total ---
            Dim tKBA As Decimal = 0D
            Dim tKBB As Decimal = 0D
            Dim tKC As Decimal = 0D
            Dim tGD As Decimal = 0D
            Dim tTotal As Decimal = 0D

            ' --- Hitung total dari data mulai baris 2 ---
            For r As Integer = 2 To .Rows.Count - 1

                ' gunakan fungsi helper untuk aman (NULL / empty)
                tKBA += .Item(r, "KBA")
                tKBB += .Item(r, "KBB")
                tKC += .Item(r, "KC")
                tGD += .Item(r, "GD")
                tTotal += .Item(r, "Total")

            Next

            ' --- Isi total ke baris 1 ---
            .Item(1, "KBA") = tKBA
            .Item(1, "KBB") = tKBB
            .Item(1, "KC") = tKC
            .Item(1, "GD") = tGD
            .Item(1, "Total") = tTotal

            ' --- Styling row total ---
            .Rows(1).StyleNew.BackColor = Color.LightYellow
            .Rows(1).StyleNew.Font = New Font(.Font, FontStyle.Bold)
        End With
    End Sub

    Private Sub fgAllPabrik_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fgAllPabrik.BeforeEdit
        e.Cancel = True
    End Sub

    Private Sub fgPancang_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fgPancang.BeforeEdit
        e.Cancel = True
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Call LoadData()
    End Sub

    Private Sub chkPPH22_CheckedChanged(sender As Object, e As EventArgs) Handles chkPPH22.CheckedChanged
        Try
            With fgPenjualan
                For i = 2 To .Rows.Count - 1
                    If chkPPH22.Checked = True Then
                        .Item(i, "PersenPPH") = 0.25
                        .Item(i, "RpPPH") = Format(Math.Ceiling(fgPenjualan.Item(i, "TotalRpBeforePPH") * 0.25 / 100), "#,##0")
                    Else
                        .Item(i, "PersenPPH") = 0
                        .Item(i, "RpPPH") = 0
                    End If

                    .Item(i, "TotalRp") = .Item(i, "TotalRpBeforePPH") - .Item(i, "RpPPH")
                Next

                Call SumPenjualan()
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ShowDataStokView(ByVal NoTrans As String)
        Dim dt As New DataTable
        Dim i As Integer = 1

        Dim sql As String = "select * from tblTrnPembuatanPenjualanStok where NoTrans='" & NoTrans & "'"

        dt = DB.ExecuteQuery(StrConnRMPApp, sql)

        With fgStok
            .Rows.Count = 1 ' Reset grid sebelum mengisi data baru

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "ItemID") = row("ItemID")
                    .Item(i, "ItemName") = row("ItemName")
                    .Item(i, "Qty") = row("Qty")
                    .Item(i, "Price") = row("Price")
                    .Item(i, "TotalRp") = row("Total")

                    i += 1
                Next

                .AutoSizeCols()
            Else
                MsgBoxCustom.Show("Tidak ada data.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            End If
        End With
    End Sub

    Private Sub fgPabrik_SelChange(sender As Object, e As EventArgs) Handles fgPabrik.SelChange
        Dim grid As C1.Win.C1FlexGrid.C1FlexGrid = CType(sender, C1.Win.C1FlexGrid.C1FlexGrid)

        txtTotal.Text = Func.FormatNum(grid.Aggregate(AggregateEnum.Sum), 2)
    End Sub

    Private Sub fgPabrik_AfterEdit(sender As Object, e As RowColEventArgs) Handles fgPabrik.AfterEdit
        ' jika yang di edit adalah kolom Select
        If e.Col = fgPabrik.Cols("Select").Index Then
            Call GeneratePersenBeforeProposional()
        End If
    End Sub

    Private Sub fgFakturPabrik_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fgFakturPabrik.BeforeEdit
        If fgFakturPabrik.Cols(e.Col).Name <> "Select" Then
            e.Cancel = True
        End If
    End Sub
End Class