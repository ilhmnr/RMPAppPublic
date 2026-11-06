Imports System.Runtime.InteropServices.ComTypes
Imports C1.Win.C1FlexGrid
Imports Excel = Microsoft.Office.Interop.Excel

Public Class FrmMonPenerimaanPabrikKelapaBPI
    Private Sub FrmMonPenerimaanPabrikKelapaBPI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call HeaderFGKB()
        Call HeaderFGKC()

        Call Modul_RMP.Combo.SetPancang(cboPancang)

        fgKBPSG.Height = (fgKBPSG.Height + fgKBRSUP.Height + 15) / 2
        fgKCPSG.Height = (fgKCPSG.Height + fgKCRSUP.Height + 15) / 2
    End Sub

    Private Sub HeaderFGKB()
        ' Pastikan objek fg sudah tersedia
        If fgKBTot Is Nothing Then Exit Sub
        If fgKBPSG Is Nothing Then Exit Sub
        If fgKBRSUP Is Nothing Then Exit Sub

        With fgKBTot
            ' === Pengaturan dasar grid ===
            .AllowEditing = True
            .Font = New Font("Century Gothic", 9.0!, FontStyle.Regular)
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True

            ' === Warna header dan baris selang-seling ===
            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)   ' Warna latar header utama
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224) ' Warna latar baris bergantian
            .Styles.Fixed.TextAlign = TextAlignEnum.LeftCenter          ' Rata kiri untuk header

            ' === Pastikan ada minimal 2 baris header ===
            .Rows.Count = 3

            ' === Warna khusus untuk baris header ke-0 dan ke-1 ===
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

            ' === Aktifkan fitur merging untuk header ===
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Rows(1).AllowMerging = True
            .Rows(2).AllowMerging = True

            ' Merge kolom No
            Dim rngNo = .GetCellRange(0, 0, 2, 0)
            rngNo.Data = "No"
            rngNo.Style = .Styles.Fixed

            For c As Integer = 0 To .Cols.Count - 1
                .Cols(c).AllowMerging = True
            Next

            ' === Set Manual Caption Kolom ===
            .Item(0, "No") = "No"
            .Item(1, "No") = "No"
            .Item(2, "No") = "No"

            ' Kolom KB PANCANG
            .Item(0, "KBP1Pcg") = "TERIMA KB PANCANG (KG)"
            .Item(1, "KBP1Pcg") = "P1"
            .Item(2, "KBP1Pcg") = "P1"

            .Item(0, "KBP2Pcg") = "TERIMA KB PANCANG (KG)"
            .Item(1, "KBP2Pcg") = "P2"
            .Item(2, "KBP2Pcg") = "P2"

            .Item(0, "TOTALKBPcg") = "TERIMA KB PANCANG (KG)"
            .Item(1, "TOTALKBPcg") = "TOTAL"
            .Item(2, "TOTALKBPcg") = "TOTAL"

            ' Kolom KB P1 PABRIK
            .Item(0, "KBAP1Pbk") = "TERIMA KB PABRIK (KG)"
            .Item(1, "KBAP1Pbk") = "P1"
            .Item(2, "KBAP1Pbk") = "KB-A"

            .Item(0, "KBBP1Pbk") = "TERIMA KB PABRIK (KG)"
            .Item(1, "KBBP1Pbk") = "P1"
            .Item(2, "KBBP1Pbk") = "KB-B"

            .Item(0, "%KBBP1Pbk") = "TERIMA KB PABRIK (KG)"
            .Item(1, "%KBBP1Pbk") = "P1"
            .Item(2, "%KBBP1Pbk") = "%"

            .Item(0, "TOTALKBP1Pbk") = "TERIMA KB PABRIK (KG)"
            .Item(1, "TOTALKBP1Pbk") = "P1"
            .Item(2, "TOTALKBP1Pbk") = "TOTAL"

            ' Kolom KB P2 PABRIK
            .Item(0, "KBAP2Pbk") = "TERIMA KB PABRIK (KG)"
            .Item(1, "KBAP2Pbk") = "P2"
            .Item(2, "KBAP2Pbk") = "KB-A"

            .Item(0, "KBBP2Pbk") = "TERIMA KB PABRIK (KG)"
            .Item(1, "KBBP2Pbk") = "P2"
            .Item(2, "KBBP2Pbk") = "KB-B"

            .Item(0, "%KBBP2Pbk") = "TERIMA KB PABRIK (KG)"
            .Item(1, "%KBBP2Pbk") = "P2"
            .Item(2, "%KBBP2Pbk") = "%"

            .Item(0, "TOTALKBP2Pbk") = "TERIMA KB PABRIK (KG)"
            .Item(1, "TOTALKBP2Pbk") = "P2"
            .Item(2, "TOTALKBP2Pbk") = "TOTAL"

            ' Kolom KB P1 + P2 PABRIK
            .Item(0, "KBAP1P2Pbk") = "TERIMA KB PABRIK (KG)"
            .Item(1, "KBAP1P2Pbk") = "TOTAL P1 + P2"
            .Item(2, "KBAP1P2Pbk") = "KB-A"

            .Item(0, "KBBP1P2Pbk") = "TERIMA KB PABRIK (KG)"
            .Item(1, "KBBP1P2Pbk") = "TOTAL P1 + P2"
            .Item(2, "KBBP1P2Pbk") = "KB-B"

            .Item(0, "%KBBP1P2Pbk") = "TERIMA KB PABRIK (KG)"
            .Item(1, "%KBBP1P2Pbk") = "TOTAL P1 + P2"
            .Item(2, "%KBBP1P2Pbk") = "%"

            .Item(0, "TOTALKBP1P2Pbk") = "TERIMA KB PABRIK (KG)"
            .Item(1, "TOTALKBP1P2Pbk") = "TOTAL P1 + P2"
            .Item(2, "TOTALKBP1P2Pbk") = "TOTAL"

            ' Kolom SUSUT
            .Item(0, "SstP1") = "TOTAL SUSUT"
            .Item(1, "SstP1") = "P1"
            .Item(2, "SstP1") = "P1"

            .Item(0, "%SstP1") = "TOTAL SUSUT"
            .Item(1, "%SstP1") = "%"
            .Item(2, "%SstP1") = "%"

            .Item(0, "SstP2") = "TOTAL SUSUT"
            .Item(1, "SstP2") = "P2"
            .Item(2, "SstP2") = "P2"

            .Item(0, "%SstP2") = "TOTAL SUSUT"
            .Item(1, "%SstP2") = "%"
            .Item(2, "%SstP2") = "%"

            .Item(0, "SstP1P2") = "TOTAL SUSUT"
            .Item(1, "SstP1P2") = "SUSUT P1 + P2"
            .Item(2, "SstP1P2") = "SUSUT P1 + P2"

            .Item(0, "%SstP1P2") = "TOTAL SUSUT"
            .Item(1, "%SstP1P2") = "%"
            .Item(2, "%SstP1P2") = "%"

            ' === Sesuaikan ukuran kolom secara otomatis ===
            .AutoSizeCols()
        End With

        With fgKBPSG
            ' === Pengaturan dasar grid ===
            .AllowEditing = True
            .Font = New Font("Century Gothic", 9.0!, FontStyle.Regular)
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True

            ' === Warna header dan baris selang-seling ===
            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)   ' Warna latar header utama
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224) ' Warna latar baris bergantian
            .Styles.Fixed.TextAlign = TextAlignEnum.LeftCenter          ' Rata kiri untuk header

            ' === Pastikan ada minimal 2 baris header ===
            .Rows.Count = 2

            ' === Warna khusus untuk baris header ke-0 dan ke-1 ===
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

            ' === Aktifkan fitur merging untuk header ===
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Rows(1).AllowMerging = True

            ' Merge kolom No
            Dim rngNo = .GetCellRange(0, 0, 1, 0)
            rngNo.Data = "No"
            rngNo.Style = .Styles.Fixed

            For c As Integer = 0 To .Cols.Count - 1
                .Cols(c).AllowMerging = True
            Next

            ' === Set Manual Caption Kolom ===
            .Item(0, "No") = "No"
            .Item(1, "No") = "No"

            ' Kolom Informasi Umum
            .Item(0, "Pancang") = "PSG"
            .Item(1, "Pancang") = "Pancang"

            .Item(0, "Kapal") = "PSG"
            .Item(1, "Kapal") = "Kapal"

            .Item(0, "Trip") = "PSG"
            .Item(1, "Trip") = "Trip"

            .Item(0, "Jenis") = "PSG"
            .Item(1, "Jenis") = "Jenis"

            .Item(0, "Grade") = "PSG"
            .Item(1, "Grade") = "Grade"

            .Item(0, "Tujuan") = "PSG"
            .Item(1, "Tujuan") = "Tujuan"

            .Item(0, "TanggalMulaiMuat") = "PSG"
            .Item(1, "TanggalMulaiMuat") = "Tanggal Mulai Muat"

            .Item(0, "TanggalSelesaiMuat") = "PSG"
            .Item(1, "TanggalSelesaiMuat") = "Tanggal Selesai Muat"

            .Item(0, "TanggalBerangkat") = "PSG"
            .Item(1, "TanggalBerangkat") = "Tanggal Berangkat"

            .Item(0, "TanggalCheckin") = "PSG"
            .Item(1, "TanggalCheckin") = "Tanggal Checkin"

            .Item(0, "TanggalBongkar") = "PSG"
            .Item(1, "TanggalBongkar") = "Tanggal Bongkar"

            .Item(0, "TanggalSelesaiBongkar") = "PSG"
            .Item(1, "TanggalSelesaiBongkar") = "Tanggal Selesai Bongkar"

            .Item(0, "TanggalTerima") = "PSG"
            .Item(1, "TanggalTerima") = "Tanggal Terima"

            .Item(0, "TotalHari") = "PSG"
            .Item(1, "TotalHari") = "TotalHari"

            .Item(0, "Dermaga") = "Dermaga"
            .Item(1, "Dermaga") = "Dermaga"

            ' Kolom Muatan Pancang
            .Item(0, "MuatanN1Pcg") = "HASIL MUAT DI PANCANG"
            .Item(1, "MuatanN1Pcg") = "Muatan N1"

            .Item(0, "MuatanN2Pcg") = "HASIL MUAT DI PANCANG"
            .Item(1, "MuatanN2Pcg") = "Muatan N2"

            .Item(0, "HargaPcg") = "HASIL MUAT DI PANCANG"
            .Item(1, "HargaPcg") = "Harga / Kg"

            .Item(0, "TOTALRpPcg") = "HASIL MUAT DI PANCANG"
            .Item(1, "TOTALRpPcg") = "Rupiah"

            ' Kolom Bongkar Pabrik
            .Item(0, "KBAPbk") = "HASIL BONGKAR PABRIK"
            .Item(1, "KBAPbk") = "KB-A"

            .Item(0, "%KBAPbk") = "HASIL BONGKAR PABRIK"
            .Item(1, "%KBAPbk") = "%"

            .Item(0, "KBBPbk") = "HASIL BONGKAR PABRIK"
            .Item(1, "KBBPbk") = "KB-B"

            .Item(0, "%KBBPbk") = "HASIL BONGKAR PABRIK"
            .Item(1, "%KBBPbk") = "%"

            .Item(0, "TOTALN1KBPbk") = "HASIL BONGKAR PABRIK"
            .Item(1, "TOTALN1KBPbk") = "TOTAL N1"

            .Item(0, "TOTALN1BKBPbk") = "HASIL BONGKAR PABRIK"
            .Item(1, "TOTALN1BKBPbk") = "TOTAL N1 B"

            .Item(0, "TOTALKBPbk") = "HASIL BONGKAR PABRIK"
            .Item(1, "TOTALKBPbk") = "TOTAL N2"

            .Item(0, "SUSUTPbk") = "HASIL BONGKAR PABRIK"
            .Item(1, "SUSUTPbk") = "SUSUT"

            .Item(0, "%SUSUTPbk") = "HASIL BONGKAR PABRIK"
            .Item(1, "%SUSUTPbk") = "%"

            .Item(0, "TOTALRpPbk") = "NOMINAL UANG DI PABRIK"
            .Item(1, "TOTALRpPbk") = "NOMINAL UANG DI PABRIK"

            .Item(0, "Selisih") = "SELISIH"
            .Item(1, "Selisih") = "SELISIH"

            .Item(0, "Keterangan") = "KETERANGAN"
            .Item(1, "Keterangan") = "KETERANGAN"

            ' === Sesuaikan ukuran kolom secara otomatis ===
            .AutoSizeCols()
        End With

        With fgKBRSUP
            ' === Pengaturan dasar grid ===
            .AllowEditing = True
            .Font = New Font("Century Gothic", 9.0!, FontStyle.Regular)
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True

            ' === Warna header dan baris selang-seling ===
            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)   ' Warna latar header utama
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224) ' Warna latar baris bergantian
            .Styles.Fixed.TextAlign = TextAlignEnum.LeftCenter          ' Rata kiri untuk header

            ' === Pastikan ada minimal 2 baris header ===
            .Rows.Count = 2

            ' === Warna khusus untuk baris header ke-0 dan ke-1 ===
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

            ' === Aktifkan fitur merging untuk header ===
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Rows(1).AllowMerging = True

            ' Merge kolom No
            Dim rngNo = .GetCellRange(0, 0, 1, 0)
            rngNo.Data = "No"
            rngNo.Style = .Styles.Fixed

            For c As Integer = 0 To .Cols.Count - 1
                .Cols(c).AllowMerging = True
            Next

            ' === Set Manual Caption Kolom ===
            .Item(0, "No") = "No"
            .Item(1, "No") = "No"

            ' Kolom Informasi Umum
            .Item(0, "Pancang") = "RSUP"
            .Item(1, "Pancang") = "Pancang"

            .Item(0, "Kapal") = "RSUP"
            .Item(1, "Kapal") = "Kapal"

            .Item(0, "Trip") = "RSUP"
            .Item(1, "Trip") = "Trip"

            .Item(0, "Jenis") = "RSUP"
            .Item(1, "Jenis") = "Jenis"

            .Item(0, "Grade") = "RSUP"
            .Item(1, "Grade") = "Grade"

            .Item(0, "Tujuan") = "RSUP"
            .Item(1, "Tujuan") = "Tujuan"

            .Item(0, "TanggalMulaiMuat") = "RSUP"
            .Item(1, "TanggalMulaiMuat") = "Tanggal Mulai Muat"

            .Item(0, "TanggalSelesaiMuat") = "RSUP"
            .Item(1, "TanggalSelesaiMuat") = "Tanggal Selesai Muat"

            .Item(0, "TanggalBerangkat") = "RSUP"
            .Item(1, "TanggalBerangkat") = "Tanggal Berangkat"

            .Item(0, "TanggalCheckin") = "RSUP"
            .Item(1, "TanggalCheckin") = "Tanggal Checkin"

            .Item(0, "TanggalBongkar") = "RSUP"
            .Item(1, "TanggalBongkar") = "Tanggal Bongkar"

            .Item(0, "TanggalSelesaiBongkar") = "RSUP"
            .Item(1, "TanggalSelesaiBongkar") = "Tanggal Selesai Bongkar"

            .Item(0, "TanggalTerima") = "RSUP"
            .Item(1, "TanggalTerima") = "Tanggal Terima"

            .Item(0, "TotalHari") = "RSUP"
            .Item(1, "TotalHari") = "TotalHari"

            .Item(0, "Dermaga") = "Dermaga"
            .Item(1, "Dermaga") = "Dermaga"

            ' Kolom Muatan Pancang
            .Item(0, "MuatanN1Pcg") = "HASIL MUAT DI PANCANG"
            .Item(1, "MuatanN1Pcg") = "Muatan N1"

            .Item(0, "MuatanN2Pcg") = "HASIL MUAT DI PANCANG"
            .Item(1, "MuatanN2Pcg") = "Muatan N2"

            .Item(0, "HargaPcg") = "HASIL MUAT DI PANCANG"
            .Item(1, "HargaPcg") = "Harga / Kg"

            .Item(0, "TOTALRpPcg") = "HASIL MUAT DI PANCANG"
            .Item(1, "TOTALRpPcg") = "Rupiah"

            ' Kolom Bongkar Pabrik
            .Item(0, "KBAPbk") = "HASIL BONGKAR PABRIK"
            .Item(1, "KBAPbk") = "KB-A"

            .Item(0, "%KBAPbk") = "HASIL BONGKAR PABRIK"
            .Item(1, "%KBAPbk") = "%"

            .Item(0, "KBBPbk") = "HASIL BONGKAR PABRIK"
            .Item(1, "KBBPbk") = "KB-B"

            .Item(0, "%KBBPbk") = "HASIL BONGKAR PABRIK"
            .Item(1, "%KBBPbk") = "%"

            .Item(0, "TOTALN1KBPbk") = "HASIL BONGKAR PABRIK"
            .Item(1, "TOTALN1KBPbk") = "TOTAL N1"

            .Item(0, "TOTALN1BKBPbk") = "HASIL BONGKAR PABRIK"
            .Item(1, "TOTALN1BKBPbk") = "TOTAL N1 B"

            .Item(0, "TOTALKBPbk") = "HASIL BONGKAR PABRIK"
            .Item(1, "TOTALKBPbk") = "TOTAL N2"

            .Item(0, "SUSUTPbk") = "HASIL BONGKAR PABRIK"
            .Item(1, "SUSUTPbk") = "SUSUT"

            .Item(0, "%SUSUTPbk") = "HASIL BONGKAR PABRIK"
            .Item(1, "%SUSUTPbk") = "%"

            .Item(0, "TOTALRpPbk") = "NOMINAL UANG DI PABRIK"
            .Item(1, "TOTALRpPbk") = "NOMINAL UANG DI PABRIK"

            .Item(0, "Selisih") = "SELISIH"
            .Item(1, "Selisih") = "SELISIH"

            .Item(0, "Keterangan") = "KETERANGAN"
            .Item(1, "Keterangan") = "KETERANGAN"

            ' === Sesuaikan ukuran kolom secara otomatis ===
            .AutoSizeCols()
        End With
    End Sub

    Private Sub HeaderFGKC()
        ' Pastikan objek fg sudah tersedia
        If fgKCTot Is Nothing Then Exit Sub
        If fgKCPSG Is Nothing Then Exit Sub
        If fgKCRSUP Is Nothing Then Exit Sub

        With fgKCTot
            ' === Pengaturan dasar grid ===
            .AllowEditing = True
            .Font = New Font("Century Gothic", 9.0!, FontStyle.Regular)
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True

            ' === Warna header dan baris selang-seling ===
            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)   ' Warna latar header utama
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224) ' Warna latar baris bergantian
            .Styles.Fixed.TextAlign = TextAlignEnum.LeftCenter          ' Rata kiri untuk header

            ' === Pastikan ada minimal 2 baris header ===
            .Rows.Count = 3

            ' === Warna khusus untuk baris header ke-0 dan ke-1 ===
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

            ' === Aktifkan fitur merging untuk header ===
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Rows(1).AllowMerging = True
            .Rows(2).AllowMerging = True

            ' Merge kolom No
            Dim rngNo = .GetCellRange(0, 0, 2, 0)
            rngNo.Data = "No"
            rngNo.Style = .Styles.Fixed

            For c As Integer = 0 To .Cols.Count - 1
                .Cols(c).AllowMerging = True
            Next

            ' === Set Manual Caption Kolom ===
            .Item(0, "No") = "No"
            .Item(1, "No") = "No"
            .Item(2, "No") = "No"

            ' Kolom KB PANCANG
            .Item(0, "KCP1Pcg") = "TERIMA KC PANCANG (KG)"
            .Item(1, "KCP1Pcg") = "P1"
            .Item(2, "KCP1Pcg") = "P1"

            .Item(0, "KCP2Pcg") = "TERIMA KC PANCANG (KG)"
            .Item(1, "KCP2Pcg") = "P2"
            .Item(2, "KCP2Pcg") = "P2"

            .Item(0, "TOTALKCPcg") = "TERIMA KC PANCANG (KG)"
            .Item(1, "TOTALKCPcg") = "TOTAL"
            .Item(2, "TOTALKCPcg") = "TOTAL"

            ' Kolom KB P1 PABRIK
            .Item(0, "KCP1Pbk") = "TERIMA KC PABRIK (KG)"
            .Item(1, "KCP1Pbk") = "P1"
            .Item(2, "KCP1Pbk") = "P1"

            .Item(0, "KCP2Pbk") = "TERIMA KC PABRIK (KG)"
            .Item(1, "KCP2Pbk") = "P2"
            .Item(2, "KCP2Pbk") = "P2"

            .Item(0, "TOTALKCPbk") = "TERIMA KC PABRIK (KG)"
            .Item(1, "TOTALKCPbk") = "TOTAL"
            .Item(2, "TOTALKCPbk") = "TOTAL"

            ' Kolom SUSUT
            .Item(0, "SstP1") = "SUSUT KC (KG)"
            .Item(1, "SstP1") = "SUSUT P1"
            .Item(2, "SstP1") = "SUSUT P1"

            .Item(0, "%SstP1") = "SUSUT KC (KG)"
            .Item(1, "%SstP1") = "%"
            .Item(2, "%SstP1") = "%"

            .Item(0, "SstP2") = "SUSUT KC (KG)"
            .Item(1, "SstP2") = "SUSUT P2"
            .Item(2, "SstP2") = "SUSUT P2"

            .Item(0, "%SstP2") = "SUSUT KC (KG)"
            .Item(1, "%SstP2") = "%"
            .Item(2, "%SstP2") = "%"

            .Item(0, "SstP1P2") = "SUSUT KC (KG)"
            .Item(1, "SstP1P2") = "TOTAL SUSUT"
            .Item(2, "SstP1P2") = "TOTAL SUSUT"

            .Item(0, "%SstP1P2") = "SUSUT KC (KG)"
            .Item(1, "%SstP1P2") = "%"
            .Item(2, "%SstP1P2") = "%"

            ' === Sesuaikan ukuran kolom secara otomatis ===
            .AutoSizeCols()
        End With

        With fgKCPSG
            ' === Pengaturan dasar grid ===
            .AllowEditing = True
            .Font = New Font("Century Gothic", 9.0!, FontStyle.Regular)
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True

            ' === Warna header dan baris selang-seling ===
            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)   ' Warna latar header utama
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224) ' Warna latar baris bergantian
            .Styles.Fixed.TextAlign = TextAlignEnum.LeftCenter          ' Rata kiri untuk header

            ' === Pastikan ada minimal 2 baris header ===
            .Rows.Count = 2

            ' === Warna khusus untuk baris header ke-0 dan ke-1 ===
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

            ' === Aktifkan fitur merging untuk header ===
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Rows(1).AllowMerging = True

            ' Merge kolom No
            Dim rngNo = .GetCellRange(0, 0, 1, 0)
            rngNo.Data = "No"
            rngNo.Style = .Styles.Fixed

            For c As Integer = 0 To .Cols.Count - 1
                .Cols(c).AllowMerging = True
            Next

            ' === Set Manual Caption Kolom ===
            .Item(0, "No") = "No"
            .Item(1, "No") = "No"

            ' Kolom Informasi Umum
            .Item(0, "Pancang") = "PSG"
            .Item(1, "Pancang") = "Pancang"

            .Item(0, "Kapal") = "PSG"
            .Item(1, "Kapal") = "Kapal"

            .Item(0, "Trip") = "PSG"
            .Item(1, "Trip") = "Trip"

            .Item(0, "Jenis") = "PSG"
            .Item(1, "Jenis") = "Jenis"

            .Item(0, "Grade") = "PSG"
            .Item(1, "Grade") = "Grade"

            .Item(0, "Tujuan") = "PSG"
            .Item(1, "Tujuan") = "Tujuan"

            .Item(0, "TanggalMulaiMuat") = "PSG"
            .Item(1, "TanggalMulaiMuat") = "Tanggal Mulai Muat"

            .Item(0, "TanggalSelesaiMuat") = "PSG"
            .Item(1, "TanggalSelesaiMuat") = "Tanggal Selesai Muat"

            .Item(0, "TanggalBerangkat") = "PSG"
            .Item(1, "TanggalBerangkat") = "Tanggal Berangkat"

            .Item(0, "TanggalCheckin") = "PSG"
            .Item(1, "TanggalCheckin") = "Tanggal Checkin"

            .Item(0, "TanggalBongkar") = "PSG"
            .Item(1, "TanggalBongkar") = "Tanggal Bongkar"

            .Item(0, "TanggalSelesaiBongkar") = "PSG"
            .Item(1, "TanggalSelesaiBongkar") = "Tanggal Selesai Bongkar"

            .Item(0, "TanggalTerima") = "PSG"
            .Item(1, "TanggalTerima") = "Tanggal Terima"

            .Item(0, "TotalHari") = "PSG"
            .Item(1, "TotalHari") = "TotalHari"

            .Item(0, "Dermaga") = "Dermaga"
            .Item(1, "Dermaga") = "Dermaga"

            ' Kolom Muatan Pancang
            .Item(0, "MuatanN1Pcg") = "HASIL MUAT DI PANCANG"
            .Item(1, "MuatanN1Pcg") = "Muatan N1"

            .Item(0, "MuatanN2Pcg") = "HASIL MUAT DI PANCANG"
            .Item(1, "MuatanN2Pcg") = "Muatan N2"

            .Item(0, "HargaPcg") = "HASIL MUAT DI PANCANG"
            .Item(1, "HargaPcg") = "Harga / Kg"

            .Item(0, "TOTALRpPcg") = "HASIL MUAT DI PANCANG"
            .Item(1, "TOTALRpPcg") = "Rupiah"

            ' Kolom Bongkar Pabrik
            .Item(0, "KCPbk") = "HASIL BONGKAR PABRIK"
            .Item(1, "KCPbk") = "CUNGKIL"

            .Item(0, "%KCPbk") = "HASIL BONGKAR PABRIK"
            .Item(1, "%KCPbk") = "%"

            .Item(0, "TOTALN1KCPbk") = "HASIL BONGKAR PABRIK"
            .Item(1, "TOTALN1KCPbk") = "TOTAL N1"

            .Item(0, "TOTALKCPbk") = "HASIL BONGKAR PABRIK"
            .Item(1, "TOTALKCPbk") = "TOTAL N2"

            .Item(0, "SUSUTPbk") = "HASIL BONGKAR PABRIK"
            .Item(1, "SUSUTPbk") = "SUSUT"

            .Item(0, "%SUSUTPbk") = "HASIL BONGKAR PABRIK"
            .Item(1, "%SUSUTPbk") = "%"

            .Item(0, "TOTALRpPbk") = "NOMINAL UANG DI PABRIK"
            .Item(1, "TOTALRpPbk") = "NOMINAL UANG DI PABRIK"

            .Item(0, "Selisih") = "SELISIH"
            .Item(1, "Selisih") = "SELISIH"

            .Item(0, "Keterangan") = "KETERANGAN"
            .Item(1, "Keterangan") = "KETERANGAN"

            ' === Sesuaikan ukuran kolom secara otomatis ===
            .AutoSizeCols()
        End With

        With fgKCRSUP
            ' === Pengaturan dasar grid ===
            .AllowEditing = True
            .Font = New Font("Century Gothic", 9.0!, FontStyle.Regular)
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True

            ' === Warna header dan baris selang-seling ===
            .Styles.Fixed.BackColor = Color.FromArgb(227, 242, 253)   ' Warna latar header utama
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224) ' Warna latar baris bergantian
            .Styles.Fixed.TextAlign = TextAlignEnum.LeftCenter          ' Rata kiri untuk header

            ' === Pastikan ada minimal 2 baris header ===
            .Rows.Count = 2

            ' === Warna khusus untuk baris header ke-0 dan ke-1 ===
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

            ' === Aktifkan fitur merging untuk header ===
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Rows(1).AllowMerging = True

            ' Merge kolom No
            Dim rngNo = .GetCellRange(0, 0, 1, 0)
            rngNo.Data = "No"
            rngNo.Style = .Styles.Fixed

            For c As Integer = 0 To .Cols.Count - 1
                .Cols(c).AllowMerging = True
            Next

            ' === Set Manual Caption Kolom ===
            .Item(0, "No") = "No"
            .Item(1, "No") = "No"

            ' Kolom Informasi Umum
            .Item(0, "Pancang") = "RSUP"
            .Item(1, "Pancang") = "Pancang"

            .Item(0, "Kapal") = "RSUP"
            .Item(1, "Kapal") = "Kapal"

            .Item(0, "Trip") = "RSUP"
            .Item(1, "Trip") = "Trip"

            .Item(0, "Jenis") = "RSUP"
            .Item(1, "Jenis") = "Jenis"

            .Item(0, "Grade") = "RSUP"
            .Item(1, "Grade") = "Grade"

            .Item(0, "Tujuan") = "RSUP"
            .Item(1, "Tujuan") = "Tujuan"

            .Item(0, "TanggalMulaiMuat") = "RSUP"
            .Item(1, "TanggalMulaiMuat") = "Tanggal Mulai Muat"

            .Item(0, "TanggalSelesaiMuat") = "RSUP"
            .Item(1, "TanggalSelesaiMuat") = "Tanggal Selesai Muat"

            .Item(0, "TanggalBerangkat") = "RSUP"
            .Item(1, "TanggalBerangkat") = "Tanggal Berangkat"

            .Item(0, "TanggalCheckin") = "RSUP"
            .Item(1, "TanggalCheckin") = "Tanggal Checkin"

            .Item(0, "TanggalBongkar") = "RSUP"
            .Item(1, "TanggalBongkar") = "Tanggal Bongkar"

            .Item(0, "TanggalSelesaiBongkar") = "RSUP"
            .Item(1, "TanggalSelesaiBongkar") = "Tanggal Selesai Bongkar"

            .Item(0, "TanggalTerima") = "RSUP"
            .Item(1, "TanggalTerima") = "Tanggal Terima"

            .Item(0, "TotalHari") = "RSUP"
            .Item(1, "TotalHari") = "TotalHari"

            .Item(0, "Dermaga") = "Dermaga"
            .Item(1, "Dermaga") = "Dermaga"

            ' Kolom Muatan Pancang
            .Item(0, "MuatanN1Pcg") = "HASIL MUAT DI PANCANG"
            .Item(1, "MuatanN1Pcg") = "Muatan N1"

            .Item(0, "MuatanN2Pcg") = "HASIL MUAT DI PANCANG"
            .Item(1, "MuatanN2Pcg") = "Muatan N2"

            .Item(0, "HargaPcg") = "HASIL MUAT DI PANCANG"
            .Item(1, "HargaPcg") = "Harga / Kg"

            .Item(0, "TOTALRpPcg") = "HASIL MUAT DI PANCANG"
            .Item(1, "TOTALRpPcg") = "Rupiah"

            ' Kolom Bongkar Pabrik
            .Item(0, "KCPbk") = "HASIL BONGKAR PABRIK"
            .Item(1, "KCPbk") = "CUNGKIL"

            .Item(0, "%KCPbk") = "HASIL BONGKAR PABRIK"
            .Item(1, "%KCPbk") = "%"

            .Item(0, "TOTALN1KCPbk") = "HASIL BONGKAR PABRIK"
            .Item(1, "TOTALN1KCPbk") = "TOTAL N1"

            .Item(0, "TOTALKCPbk") = "HASIL BONGKAR PABRIK"
            .Item(1, "TOTALKCPbk") = "TOTAL N2"

            .Item(0, "SUSUTPbk") = "HASIL BONGKAR PABRIK"
            .Item(1, "SUSUTPbk") = "SUSUT"

            .Item(0, "%SUSUTPbk") = "HASIL BONGKAR PABRIK"
            .Item(1, "%SUSUTPbk") = "%"

            .Item(0, "TOTALRpPbk") = "NOMINAL UANG DI PABRIK"
            .Item(1, "TOTALRpPbk") = "NOMINAL UANG DI PABRIK"

            .Item(0, "Selisih") = "SELISIH"
            .Item(1, "Selisih") = "SELISIH"

            .Item(0, "Keterangan") = "KETERANGAN"
            .Item(1, "Keterangan") = "KETERANGAN"

            ' === Sesuaikan ukuran kolom secara otomatis ===
            .AutoSizeCols()
        End With
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ' wajib pilih status
        If Replace(cboStatus.Text, " ", "") = "" Then
            MessageBox.Show("Silakan pilih status terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        Dim Status As String = cboStatus.Text
        Dim DateStart As String = Format(dtpStart.Value, "yyyy-MM-dd")
        Dim DateEnd As String = Format(dtpEnd.Value, "yyyy-MM-dd")
        Dim IDPancang As Integer = If(Replace(cboPancang.Text, " ", "") = "", 0, cboPancang.SelectedValue)

        Call LoadDataKBPSG(Status, DateStart, DateEnd, "PSG", "Kelapa Bulat", IDPancang)
        Call LoadDataKBRSUP(Status, DateStart, DateEnd, "RSUP", "Kelapa Bulat", IDPancang)
        Call LoadAkumulasiKB()

        Call LoadDataKCPSG(Status, DateStart, DateEnd, "PSG", "Cungkil", IDPancang)
        Call LoadDataKCRSUP(Status, DateStart, DateEnd, "RSUP", "Cungkil", IDPancang)
        Call LoadAkumulasiKC()

        Me.Cursor = Cursors.Default
    End Sub

#Region "KELAPA BULAT"
    Private Sub LoadDataKBPSG(ByVal Status As String, ByVal DateStart As String, ByVal DateEnd As String, ByVal Tujuan As String, ByVal Jenis As String, ByVal IDPancang As Integer)
        Dim dt As New DataTable
        Dim i As Integer = 2
        Dim No As Integer = 1
        Dim sql As String = ""

        If Status <> "Terima Pabrik" Then
            sql &= "select * from fnMonPenerimaanPabrikKelapaBPI('" & Status & "','" & DateStart & "','" & DateEnd & "','" & Tujuan & "','" & Jenis & "','" & IDPancang & "') "
        Else
            sql &= "select * from fnMonPenerimaanPabrikKelapaBPI_NonBooking('" & DateStart & "','" & DateEnd & "','" & Tujuan & "','" & Jenis & "','" & IDPancang & "') "
        End If

        sql &= " order by MuatDate asc"

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fgKBPSG
            .Rows.Count = 2 ' Reset grid sebelum mengisi data baru

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(No)
                    .Item(i, "Pancang") = row("Pancang")
                    .Item(i, "Kapal") = row("Kapal")
                    .Item(i, "Trip") = row("Trip")
                    .Item(i, "Jenis") = row("Jenis")
                    .Item(i, "Grade") = row("Grade")
                    .Item(i, "Tujuan") = row("Tujuan")
                    .Item(i, "TanggalMulaiMuat") = row("MuatDate")
                    .Item(i, "TanggalSelesaiMuat") = row("CloseDate")
                    .Item(i, "TanggalBerangkat") = row("BerangkatDate")
                    .Item(i, "TanggalCheckin") = row("ChekinPabrik")
                    .Item(i, "TanggalBongkar") = row("BongkarDate")
                    .Item(i, "TanggalSelesaiBongkar") = row("ReleaseDatePabrik")
                    .Item(i, "TanggalTerima") = row("TanggalPenjualan")
                    .Item(i, "TotalHari") = row("TotalHari")
                    .Item(i, "Dermaga") = row("NamaDermaga")
                    .Item(i, "MuatanN1Pcg") = row("Netto1Pcg")
                    .Item(i, "MuatanN2Pcg") = row("Netto2Pcg")
                    .Item(i, "HargaPcg") = row("RpPcg")
                    .Item(i, "TOTALRpPcg") = row("TotalRpPcg")
                    .Item(i, "KBAPbk") = row("NettoA2Pbk")
                    .Item(i, "%KBAPbk") = row("PercenA2Pbk")
                    .Item(i, "KBBPbk") = row("NettoB2Pbk")
                    .Item(i, "%KBBPbk") = row("PercenB2Pbk")
                    .Item(i, "TOTALN1KBPbk") = row("TotalN1Pbk")
                    .Item(i, "TOTALN1BKBPbk") = row("TotalN1BPbk")
                    .Item(i, "TOTALKBPbk") = row("TotalNetto2Pbk")
                    .Item(i, "SUSUTPbk") = row("Susut")
                    .Item(i, "%SUSUTPbk") = row("PercenSusut")
                    .Item(i, "TotalRpPbk") = row("TotalRpPbk")
                    .Item(i, "Selisih") = row("SelisihRp")
                    .Item(i, "Keterangan") = row("Keterangan")

                    i += 1
                    No += 1
                Next

                .AutoSizeCols()
            End If

            Call AddTotalRowKB(fgKBPSG)
        End With
    End Sub

    Private Sub LoadDataKBRSUP(ByVal Status As String, ByVal DateStart As String, ByVal DateEnd As String, ByVal Tujuan As String, ByVal Jenis As String, ByVal IDPancang As Integer)
        Dim dt As New DataTable
        Dim i As Integer = 2
        Dim No As Integer = 1
        Dim sql As String = ""

        If Status <> "Terima Pabrik" Then
            sql &= "select * from fnMonPenerimaanPabrikKelapaBPI('" & Status & "','" & DateStart & "','" & DateEnd & "','" & Tujuan & "','" & Jenis & "','" & IDPancang & "') "
        Else
            sql &= "select * from fnMonPenerimaanPabrikKelapaBPI_NonBooking('" & DateStart & "','" & DateEnd & "','" & Tujuan & "','" & Jenis & "','" & IDPancang & "') "
        End If

        sql &= " order by MuatDate asc"

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fgKBRSUP
            .Rows.Count = 2 ' Reset grid sebelum mengisi data baru

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(No)
                    .Item(i, "Pancang") = row("Pancang")
                    .Item(i, "Kapal") = row("Kapal")
                    .Item(i, "Trip") = row("Trip")
                    .Item(i, "Jenis") = row("Jenis")
                    .Item(i, "Grade") = row("Grade")
                    .Item(i, "Tujuan") = row("Tujuan")
                    .Item(i, "TanggalMulaiMuat") = row("MuatDate")
                    .Item(i, "TanggalSelesaiMuat") = row("CloseDate")
                    .Item(i, "TanggalBerangkat") = row("BerangkatDate")
                    .Item(i, "TanggalCheckin") = row("ChekinPabrik")
                    .Item(i, "TanggalBongkar") = row("BongkarDate")
                    .Item(i, "TanggalSelesaiBongkar") = row("ReleaseDatePabrik")
                    .Item(i, "TanggalTerima") = row("TanggalPenjualan")
                    .Item(i, "TotalHari") = row("TotalHari")
                    .Item(i, "Dermaga") = row("NamaDermaga")
                    .Item(i, "MuatanN1Pcg") = row("Netto1Pcg")
                    .Item(i, "MuatanN2Pcg") = row("Netto2Pcg")
                    .Item(i, "HargaPcg") = row("RpPcg")
                    .Item(i, "TOTALRpPcg") = row("TotalRpPcg")
                    .Item(i, "KBAPbk") = row("NettoA2Pbk")
                    .Item(i, "%KBAPbk") = row("PercenA2Pbk")
                    .Item(i, "KBBPbk") = row("NettoB2Pbk")
                    .Item(i, "%KBBPbk") = row("PercenB2Pbk")
                    .Item(i, "TOTALN1KBPbk") = row("TotalN1Pbk")
                    .Item(i, "TOTALN1BKBPbk") = row("TotalN1BPbk")
                    .Item(i, "TOTALKBPbk") = row("TotalNetto2Pbk")
                    .Item(i, "SUSUTPbk") = row("Susut")
                    .Item(i, "%SUSUTPbk") = row("PercenSusut")
                    .Item(i, "TotalRpPbk") = row("TotalRpPbk")
                    .Item(i, "Selisih") = row("SelisihRp")
                    .Item(i, "Keterangan") = row("Keterangan")

                    i += 1
                    No += 1
                Next

                .AutoSizeCols()
            End If

            Call AddTotalRowKB(fgKBRSUP)
        End With
    End Sub

    Private Sub LoadAkumulasiKB()
        Dim LstColPsg As Integer = fgKBPSG.Rows.Count - 1
        Dim LstColRsup As Integer = fgKBRSUP.Rows.Count - 1

        With fgKBTot
            .Rows.Count = 3

            .AddItem(1)
            .Item(3, "KBP1Pcg") = fgKBPSG.Item(LstColPsg, "MuatanN2Pcg")
            .Item(3, "KBP2Pcg") = fgKBRSUP.Item(LstColRsup, "MuatanN2Pcg")
            .Item(3, "TOTALKBPcg") = .Item(3, "KBP1Pcg") + .Item(3, "KBP2Pcg")

            .Item(3, "KBAP1Pbk") = fgKBPSG.Item(LstColPsg, "KBAPbk")
            .Item(3, "KBBP1Pbk") = fgKBPSG.Item(LstColPsg, "KBBPbk")
            .Item(3, "%KBBP1Pbk") = fgKBPSG.Item(LstColPsg, "%KBBPbk")
            .Item(3, "TOTALKBP1Pbk") = fgKBPSG.Item(LstColPsg, "TOTALKBPbk")

            .Item(3, "KBAP2Pbk") = fgKBRSUP.Item(LstColRsup, "KBAPbk")
            .Item(3, "KBBP2Pbk") = fgKBRSUP.Item(LstColRsup, "KBBPbk")
            .Item(3, "%KBBP2Pbk") = fgKBRSUP.Item(LstColRsup, "%KBBPbk")
            .Item(3, "TOTALKBP2Pbk") = fgKBRSUP.Item(LstColRsup, "TOTALKBPbk")

            .Item(3, "KBAP1P2Pbk") = .Item(3, "KBAP1Pbk") + .Item(3, "KBAP2Pbk")
            .Item(3, "KBBP1P2Pbk") = .Item(3, "KBBP1Pbk") + .Item(3, "KBBP2Pbk")
            .Item(3, "%KBBP1P2Pbk") = .Item(3, "%KBBP1Pbk") + .Item(3, "%KBBP2Pbk")
            .Item(3, "TOTALKBP1P2Pbk") = .Item(3, "TOTALKBP1Pbk") + .Item(3, "TOTALKBP2Pbk")

            .Item(3, "SstP1") = fgKBPSG.Item(LstColPsg, "SUSUTPbk")
            .Item(3, "%SstP1") = fgKBPSG.Item(LstColPsg, "%SUSUTPbk")

            .Item(3, "SstP2") = fgKBRSUP.Item(LstColRsup, "SUSUTPbk")
            .Item(3, "%SstP2") = fgKBRSUP.Item(LstColRsup, "%SUSUTPbk")

            .Item(3, "SstP1P2") = .Item(3, "SstP1") + .Item(3, "SstP2")
            .Item(3, "%SstP1P2") = .Item(3, "%SstP1") + .Item(3, "%SstP2")

            .AutoSizeCols()
        End With
    End Sub

    Private Sub AddTotalRowKB(ByRef fg As C1.Win.C1FlexGrid.C1FlexGrid)

        ' === HAPUS TOTAL LAMA JIKA ADA ===
        For r As Integer = fg.Rows.Fixed To fg.Rows.Count - 1
            If fg.Item(r, "Dermaga").ToString() = "TOTAL" Then
                fg.Rows.Remove(r)
                Exit For
            End If
        Next

        ' === VAR TOTAL ===
        Dim totMuatanN2Pcg As Decimal = 0
        Dim totTotalRpPcg As Decimal = 0
        Dim totKBAPbk As Decimal = 0
        Dim totKBBPbk As Decimal = 0
        Dim totTOTALKBPbk As Decimal = 0
        Dim totSusut As Decimal = 0
        Dim totTotalRpPbk As Decimal = 0
        Dim totSelisih As Decimal = 0

        ' === HITUNG DARI GRID (AMAN SAAT SORT) ===
        For r As Integer = fg.Rows.Fixed To fg.Rows.Count - 1
            If fg.Item(r, "Dermaga").ToString() <> "TOTAL" Then
                totMuatanN2Pcg += Val(fg.Item(r, "MuatanN2Pcg"))
                totTotalRpPcg += Val(fg.Item(r, "TOTALRpPcg"))
                totKBAPbk += Val(fg.Item(r, "KBAPbk"))
                totKBBPbk += Val(fg.Item(r, "KBBPbk"))
                totTOTALKBPbk += Val(fg.Item(r, "TOTALKBPbk"))
                totSusut += Val(fg.Item(r, "SUSUTPbk"))
                totTotalRpPbk += Val(fg.Item(r, "TotalRpPbk"))
                totSelisih += Val(fg.Item(r, "Selisih"))
            End If
        Next

        ' === TAMBAH BARIS TOTAL ===
        Dim rTot As Integer = fg.Rows.Count
        fg.AddItem("")

        fg.Item(rTot, "Dermaga") = "TOTAL"
        fg.Item(rTot, "MuatanN2Pcg") = totMuatanN2Pcg
        fg.Item(rTot, "TOTALRpPcg") = totTotalRpPcg
        fg.Item(rTot, "HargaPcg") = If(totMuatanN2Pcg = 0, 0, totTotalRpPcg / totMuatanN2Pcg)
        fg.Item(rTot, "KBAPbk") = totKBAPbk
        fg.Item(rTot, "%KBAPbk") = If(totMuatanN2Pcg = 0, 0, (totKBAPbk / totMuatanN2Pcg) * 100)
        fg.Item(rTot, "KBBPbk") = totKBBPbk
        fg.Item(rTot, "%KBBPbk") = If(totMuatanN2Pcg = 0, 0, (totKBBPbk / totMuatanN2Pcg) * 100)
        fg.Item(rTot, "TOTALKBPbk") = totTOTALKBPbk
        fg.Item(rTot, "SUSUTPbk") = totSusut
        fg.Item(rTot, "%SUSUTPbk") = If(totMuatanN2Pcg = 0, 0, (totSusut / totMuatanN2Pcg) * 100)
        fg.Item(rTot, "TotalRpPbk") = totTotalRpPbk
        fg.Item(rTot, "Selisih") = totSelisih

        ' === STYLE TOTAL ===
        fg.Rows(rTot).StyleNew.BackColor = Color.FromArgb(255, 243, 205)
        fg.Rows(rTot).StyleNew.Font = New Font("Century Gothic", 9, FontStyle.Bold)

    End Sub
#End Region

#Region "CUNGKIL"
    Private Sub LoadDataKCPSG(ByVal Status As String, ByVal DateStart As String, ByVal DateEnd As String, ByVal Tujuan As String, ByVal Jenis As String, ByVal IDPancang As Integer)
        Dim dt As New DataTable
        Dim i As Integer = 2
        Dim No As Integer = 1
        Dim sql As String = ""

        sql &= "select * from fnMonPenerimaanPabrikKelapaBPI('" & Status & "','" & DateStart & "','" & DateEnd & "','" & Tujuan & "','" & Jenis & "','" & IDPancang & "') "

        sql &= " order by MuatDate asc"

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fgKCPSG
            .Rows.Count = 2 ' Reset grid sebelum mengisi data baru

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(No)
                    .Item(i, "Pancang") = row("Pancang")
                    .Item(i, "Kapal") = row("Kapal")
                    .Item(i, "Trip") = row("Trip")
                    .Item(i, "Jenis") = row("Jenis")
                    .Item(i, "Grade") = row("Grade")
                    .Item(i, "Tujuan") = row("Tujuan")
                    .Item(i, "TanggalMulaiMuat") = row("MuatDate")
                    .Item(i, "TanggalSelesaiMuat") = row("CloseDate")
                    .Item(i, "TanggalBerangkat") = row("BerangkatDate")
                    .Item(i, "TanggalCheckin") = row("ChekinPabrik")
                    .Item(i, "TanggalBongkar") = row("BongkarDate")
                    .Item(i, "TanggalSelesaiBongkar") = row("ReleaseDatePabrik")
                    .Item(i, "TanggalTerima") = row("TanggalPenjualan")
                    .Item(i, "TotalHari") = row("TotalHari")
                    .Item(i, "Dermaga") = row("NamaDermaga")
                    .Item(i, "MuatanN1Pcg") = row("Netto1Pcg")
                    .Item(i, "MuatanN2Pcg") = row("Netto2Pcg")
                    .Item(i, "HargaPcg") = row("RpPcg")
                    .Item(i, "TOTALRpPcg") = row("TotalRpPcg")
                    .Item(i, "KCPbk") = row("NettoKC2Pbk")
                    .Item(i, "%KCPbk") = row("PercenKC2Pbk")
                    .Item(i, "TOTALN1KCPbk") = row("TotalN1Pbk")
                    .Item(i, "TOTALKCPbk") = row("TotalNetto2Pbk")
                    .Item(i, "SUSUTPbk") = row("Susut")
                    .Item(i, "%SUSUTPbk") = row("PercenSusut")
                    .Item(i, "TotalRpPbk") = row("TotalRpPbk")
                    .Item(i, "Selisih") = row("SelisihRp")
                    .Item(i, "Keterangan") = row("Keterangan")

                    i += 1
                    No += 1
                Next

                .AutoSizeCols()
            End If

            Call AddTotalRowKC(fgKCPSG)
        End With
    End Sub

    Private Sub LoadDataKCRSUP(ByVal Status As String, ByVal DateStart As String, ByVal DateEnd As String, ByVal Tujuan As String, ByVal Jenis As String, ByVal IDPancang As Integer)
        Dim dt As New DataTable
        Dim i As Integer = 2
        Dim No As Integer = 1
        Dim sql As String = ""

        sql &= "select * from fnMonPenerimaanPabrikKelapaBPI('" & Status & "','" & DateStart & "','" & DateEnd & "','" & Tujuan & "','" & Jenis & "','" & IDPancang & "') "

        sql &= " order by MuatDate asc"

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fgKCRSUP
            .Rows.Count = 2 ' Reset grid sebelum mengisi data baru

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(No)
                    .Item(i, "Pancang") = row("Pancang")
                    .Item(i, "Kapal") = row("Kapal")
                    .Item(i, "Trip") = row("Trip")
                    .Item(i, "Jenis") = row("Jenis")
                    .Item(i, "Grade") = row("Grade")
                    .Item(i, "Tujuan") = row("Tujuan")
                    .Item(i, "TanggalMulaiMuat") = row("MuatDate")
                    .Item(i, "TanggalSelesaiMuat") = row("CloseDate")
                    .Item(i, "TanggalBerangkat") = row("BerangkatDate")
                    .Item(i, "TanggalCheckin") = row("ChekinPabrik")
                    .Item(i, "TanggalBongkar") = row("BongkarDate")
                    .Item(i, "TanggalSelesaiBongkar") = row("ReleaseDatePabrik")
                    .Item(i, "TanggalTerima") = row("TanggalPenjualan")
                    .Item(i, "TotalHari") = row("TotalHari")
                    .Item(i, "Dermaga") = row("NamaDermaga")
                    .Item(i, "MuatanN1Pcg") = row("Netto1Pcg")
                    .Item(i, "MuatanN2Pcg") = row("Netto2Pcg")
                    .Item(i, "HargaPcg") = row("RpPcg")
                    .Item(i, "TOTALRpPcg") = row("TotalRpPcg")
                    .Item(i, "KCPbk") = row("NettoKC2Pbk")
                    .Item(i, "%KCPbk") = row("PercenKC2Pbk")
                    .Item(i, "TOTALN1KCPbk") = row("TotalN1Pbk")
                    .Item(i, "TOTALKCPbk") = row("TotalNetto2Pbk")
                    .Item(i, "SUSUTPbk") = row("Susut")
                    .Item(i, "%SUSUTPbk") = row("PercenSusut")
                    .Item(i, "TotalRpPbk") = row("TotalRpPbk")
                    .Item(i, "Selisih") = row("SelisihRp")
                    .Item(i, "Keterangan") = row("Keterangan")

                    i += 1
                    No += 1
                Next

                .AutoSizeCols()
            End If

            Call AddTotalRowKC(fgKCRSUP)
        End With
    End Sub

    Private Sub LoadAkumulasiKC()
        Dim LstColPsg As Integer = fgKCPSG.Rows.Count - 1
        Dim LstColRsup As Integer = fgKCRSUP.Rows.Count - 1

        With fgKCTot
            .Rows.Count = 3

            .AddItem(1)
            .Item(3, "KCP1Pcg") = fgKCPSG.Item(LstColPsg, "MuatanN2Pcg")
            .Item(3, "KCP2Pcg") = fgKCRSUP.Item(LstColRsup, "MuatanN2Pcg")
            .Item(3, "TOTALKCPcg") = .Item(3, "KCP1Pcg") + .Item(3, "KCP2Pcg")

            .Item(3, "KCP1Pbk") = fgKCPSG.Item(LstColPsg, "TOTALKCPbk")
            .Item(3, "KCP2Pbk") = fgKCRSUP.Item(LstColRsup, "TOTALKCPbk")
            .Item(3, "TOTALKCPbk") = .Item(3, "KCP1Pbk") + .Item(3, "KCP2Pbk")

            .Item(3, "SstP1") = fgKCPSG.Item(LstColPsg, "SUSUTPbk")
            .Item(3, "%SstP1") = fgKCPSG.Item(LstColPsg, "%SUSUTPbk")

            .Item(3, "SstP2") = fgKCRSUP.Item(LstColRsup, "SUSUTPbk")
            .Item(3, "%SstP2") = fgKCRSUP.Item(LstColRsup, "%SUSUTPbk")

            .Item(3, "SstP1P2") = .Item(3, "SstP1") + .Item(3, "SstP2")
            .Item(3, "%SstP1P2") = .Item(3, "%SstP1") + .Item(3, "%SstP2")

            .AutoSizeCols()
        End With
    End Sub

    Private Sub AddTotalRowKC(ByRef fg As C1.Win.C1FlexGrid.C1FlexGrid)

        ' === HAPUS TOTAL LAMA JIKA ADA ===
        For r As Integer = fg.Rows.Fixed To fg.Rows.Count - 1
            If fg.Item(r, "Dermaga").ToString() = "TOTAL" Then
                fg.Rows.Remove(r)
                Exit For
            End If
        Next

        ' === VAR TOTAL ===
        Dim totMuatanN2Pcg As Decimal = 0
        Dim totTotalRpPcg As Decimal = 0
        Dim totKCPbk As Decimal = 0
        Dim totTOTALN1KCPbk As Decimal = 0
        Dim totTOTALKCPbk As Decimal = 0
        Dim totSusut As Decimal = 0
        Dim totTotalRpPbk As Decimal = 0
        Dim totSelisih As Decimal = 0

        ' === HITUNG DARI GRID (AMAN SAAT SORT) ===
        For r As Integer = fg.Rows.Fixed To fg.Rows.Count - 1
            If fg.Item(r, "Dermaga").ToString() <> "TOTAL" Then
                totMuatanN2Pcg += Val(fg.Item(r, "MuatanN2Pcg"))
                totTotalRpPcg += Val(fg.Item(r, "TOTALRpPcg"))
                totKCPbk += Val(fg.Item(r, "KCPbk"))
                totTOTALN1KCPbk += Val(fg.Item(r, "TOTALN1KCPbk"))
                totTOTALKCPbk += Val(fg.Item(r, "TOTALKCPbk"))
                totSusut += Val(fg.Item(r, "SUSUTPbk"))
                totTotalRpPbk += Val(fg.Item(r, "TotalRpPbk"))
                totSelisih += Val(fg.Item(r, "Selisih"))
            End If
        Next

        ' === TAMBAH BARIS TOTAL ===
        Dim rTot As Integer = fg.Rows.Count
        fg.AddItem("")

        fg.Item(rTot, "Dermaga") = "TOTAL"
        fg.Item(rTot, "MuatanN2Pcg") = totMuatanN2Pcg
        fg.Item(rTot, "TOTALRpPcg") = totTotalRpPcg
        fg.Item(rTot, "HargaPcg") = If(totMuatanN2Pcg = 0, 0, totTotalRpPcg / totMuatanN2Pcg)
        fg.Item(rTot, "KCPbk") = totKCPbk
        fg.Item(rTot, "%KCPbk") = If(totMuatanN2Pcg = 0, 0, (totKCPbk / totMuatanN2Pcg) * 100)
        fg.Item(rTot, "TOTALN1KCPbk") = totTOTALN1KCPbk
        fg.Item(rTot, "TOTALKCPbk") = totTOTALKCPbk
        fg.Item(rTot, "SUSUTPbk") = totSusut
        fg.Item(rTot, "%SUSUTPbk") = If(totMuatanN2Pcg = 0, 0, (totSusut / totMuatanN2Pcg) * 100)
        fg.Item(rTot, "TotalRpPbk") = totTotalRpPbk
        fg.Item(rTot, "Selisih") = totSelisih


        ' === STYLE TOTAL ===
        fg.Rows(rTot).StyleNew.BackColor = Color.FromArgb(255, 243, 205)
        fg.Rows(rTot).StyleNew.Font = New Font("Century Gothic", 9, FontStyle.Bold)

    End Sub
#End Region

    Private Sub FlexGrid_AfterSort(sender As Object, e As SortColEventArgs) Handles fgKBPSG.AfterSort, fgKBRSUP.AfterSort, fgKCPSG.AfterSort, fgKCRSUP.AfterSort


        Dim fg As C1.Win.C1FlexGrid.C1FlexGrid =
        TryCast(sender, C1.Win.C1FlexGrid.C1FlexGrid)

        If fg Is Nothing Then Exit Sub

        Select Case fg.Name
            Case "fgKBPSG", "fgKBRSUP"
                AddTotalRowKB(fg)

            Case "fgKCPSG", "fgKCRSUP"
                AddTotalRowKC(fg)
        End Select

    End Sub

    Private Sub btnExcelKB_Click(sender As Object, e As EventArgs) Handles btnExcelKB.Click
        Me.Cursor = Cursors.WaitCursor

        Dim xlApp As New Excel.Application
        Dim xlWB As Excel.Workbook = xlApp.Workbooks.Add()
        Dim xlWS As Excel.Worksheet = xlWB.Sheets(1)

        xlWS.Name = "Export"

        Dim startRow As Integer = 1

        ' ===== FLEXGRID 1 =====
        startRow = CopyFlexGridToExcel_Interop(fgKBTot, xlWS, startRow)
        startRow += 2

        ' ===== FLEXGRID 2 =====
        startRow = CopyFlexGridToExcel_Interop(fgKBPSG, xlWS, startRow)
        startRow += 2

        ' ===== FLEXGRID 3 =====
        startRow = CopyFlexGridToExcel_Interop(fgKBRSUP, xlWS, startRow)

        ' ===== SAVE FILE =====
        Using sfd As New SaveFileDialog()
            sfd.Filter = "Excel (*.xlsx)|*.xlsx"
            sfd.FileName = "LAPORAN KELAPA BULAT PT.BPI DI TERIMA PABRIK PT.PSG DAN PT.RSUP_" & Format(Now, "ddMMyyyy") & ".xlsx"

            If sfd.ShowDialog() = DialogResult.OK Then
                xlWB.SaveAs(sfd.FileName)
                xlWB.Close()
                xlApp.Quit()

                MessageBox.Show("Export Excel berhasil", "Info")
            End If
        End Using

        ReleaseObject(xlWS)
        ReleaseObject(xlWB)
        ReleaseObject(xlApp)

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnExcelKc_Click(sender As Object, e As EventArgs) Handles btnExcelKc.Click
        Me.Cursor = Cursors.WaitCursor

        Dim xlApp As New Excel.Application
        Dim xlWB As Excel.Workbook = xlApp.Workbooks.Add()
        Dim xlWS As Excel.Worksheet = xlWB.Sheets(1)

        xlWS.Name = "Export"

        Dim startRow As Integer = 1

        ' ===== FLEXGRID 1 =====
        startRow = CopyFlexGridToExcel_Interop(fgKCTot, xlWS, startRow)
        startRow += 2

        ' ===== FLEXGRID 2 =====
        startRow = CopyFlexGridToExcel_Interop(fgKCPSG, xlWS, startRow)
        startRow += 2

        ' ===== FLEXGRID 3 =====
        startRow = CopyFlexGridToExcel_Interop(fgKCRSUP, xlWS, startRow)

        ' ===== SAVE FILE =====
        Using sfd As New SaveFileDialog()
            sfd.Filter = "Excel (*.xlsx)|*.xlsx"
            sfd.FileName = "LAPORAN CUNGKIL PT.BPI DI TERIMA PABRIK PT.PSG DAN PT.RSUP_" & Format(Now, "ddMMyyyy") & ".xlsx"

            If sfd.ShowDialog() = DialogResult.OK Then
                xlWB.SaveAs(sfd.FileName)
                xlWB.Close()
                xlApp.Quit()

                MessageBox.Show("Export Excel berhasil", "Info")
            End If
        End Using

        ReleaseObject(xlWS)
        ReleaseObject(xlWB)
        ReleaseObject(xlApp)

        Me.Cursor = Cursors.Default
    End Sub

    Private Function CopyFlexGridToExcel_Interop(
    fg As C1.Win.C1FlexGrid.C1FlexGrid,
    ws As Excel.Worksheet,
    startRow As Integer) As Integer

        Dim rExcel As Integer = startRow

        For r As Integer = 0 To fg.Rows.Count - 1
            For c As Integer = 0 To fg.Cols.Count - 1

                Dim cell As Excel.Range = ws.Cells(rExcel, c + 1)
                cell.Value = fg(r, c)

                ' ==== COPY BACKGROUND COLOR ====
                Dim cs = fg.GetCellStyle(r, c)
                If cs IsNot Nothing AndAlso cs.BackColor <> Color.Empty Then
                    cell.Interior.Color = ColorTranslator.ToOle(cs.BackColor)
                End If

                ' ==== HEADER BOLD (FIXED ROW) ====
                If r < fg.Rows.Fixed Then
                    cell.Font.Bold = True
                End If

            Next
            rExcel += 1
        Next

        Return rExcel

    End Function

    Private Sub ReleaseObject(obj As Object)
        Try
            Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub FrmMonPenerimaanPabrikKelapaBPI_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        fgKBPSG.Height = (fgKBPSG.Height + fgKBRSUP.Height + 15) / 2
        fgKCPSG.Height = (fgKCPSG.Height + fgKCRSUP.Height + 15) / 2
    End Sub

    Private Sub fgKBTot_SelChange(sender As Object, e As EventArgs) Handles fgKBTot.SelChange, fgKCTot.SelChange
        Dim grid As C1.Win.C1FlexGrid.C1FlexGrid = CType(sender, C1.Win.C1FlexGrid.C1FlexGrid)

        txtTotal.Text = ClsFunction.FormatNum(grid.Aggregate(AggregateEnum.Sum), 2)
    End Sub
End Class