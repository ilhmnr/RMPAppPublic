# Audit DLL RMPApp

Branch: `audit-unused-dll`  
Target framework: .NET Framework 4.8  
Project: `RMPApp/RMPApp.vbproj`

## Tujuan dan batasan

Audit ini memetakan referensi assembly dan pemakaian kode sebelum penghapusan. Tidak ada DLL atau referensi proyek yang dihapus pada tahap ini. Hasil pencarian kode GitHub untuk repository ini belum mengembalikan hasil, sehingga pemeriksaan dilakukan dengan membaca file proyek dan beberapa file sumber/Designer yang relevan. Hasil "belum ditemukan" bukan bukti final bahwa assembly tidak dipakai.

## Pemakaian yang sudah terkonfirmasi

| Komponen | Bukti dari source | Status |
|---|---|---|
| LiveChartsCore + SkiaSharp | `FrmDashboard.vb` mengimpor LiveChartsCore/SkiaSharp; Designer membuat PieChart dan CartesianChart | Pertahankan |
| QRCoder | `FrmTrnCetakLabelPetani.vb` membuat QRCodeGenerator dan QRCode | Pertahankan |
| ZXing.Net | File yang sama menggunakan BarcodeWriter dan BarcodeFormat.CODE_93 | Pertahankan |
| ReportViewer | `FrmRptQRbarcode.vb`, `FrmRptTest.vb` menggunakan Microsoft.Reporting.WinForms.ReportViewer | Pertahankan |
| DockPanelSuite | `FrmMain.vb` menggunakan DockContent/DockPanel; Designer membuat DockPanel | Pertahankan |
| Newtonsoft.Json | `FrmLogin.vb` mengimpor Newtonsoft.Json dan Newtonsoft.Json.Linq | Pertahankan |
| Adobe Acrobat ActiveX | `Reports/Form/FrmRptViewFilePdf_.vb` mengatur AxAcroPDF1.src; Designer membuat AxAcroPDF | Bukan bukti penggunaan PDFsharp/Spire/Syncfusion |

## Kandidat pemeriksaan lanjutan

Belum ada yang dihapus. Perlu pencarian menyeluruh di seluruh source, Designer, resource, dan konfigurasi runtime.

- ClosedXML dan DocumentFormat.OpenXml
- PDFsharp dan PdfSharp.Charting
- Spire.Pdf
- Syncfusion.Pdf.Base dan Syncfusion.Compression.Base
- OpenTK dan OpenTK.GLControl
- Microsoft.AspNetCore.SignalR.Client beserta dependensinya
- MessagingToolkit.QRCode dan ThoughtWorks.QRCode (sementara QR di form label memakai QRCoder)
- Spire.Barcode
- System.Text.Json beserta dependensi .NET 9
- Referensi ComponentOne lawas yang memakai versi assembly `.2`

## Anomali konfigurasi referensi

Beberapa `HintPath` di `RMPApp.vbproj` tampak tidak cocok dengan nama assembly pada `Reference Include`, contohnya:

- `C1.C1DataExtender.2` menunjuk ke file `C1.C1Excel.4.5.2.dll`
- `C1.C1Pdf.2` menunjuk ke file `C1.C1Zip.4.5.2.dll`
- `C1.Win.2` menunjuk ke file `C1.Win.4.5.2.dll`
- `C1.Win.C1Command.2` menunjuk ke file `C1.Win.C1DX.4.5.2.dll`
- `C1.Win.C1DynamicHelp.2` menunjuk ke file `C1.Win.C1FlexGrid.4.5.2.dll`
- `C1.Win.C1InputPanel.2` menunjuk ke file `ClosedXML.dll`

Ini perlu diverifikasi sebelum mengubah apa pun. Kemungkinan referensi lama/duplikat atau kesalahan konfigurasi; jangan langsung dihapus hanya berdasarkan nama.

Ada juga referensi resource ReportViewer versi 150.900.148, sedangkan paket utama yang tercatat adalah 140.1000.523. Perlu pemeriksaan konsistensi versi dan output build.

## Langkah validasi sebelum penghapusan

1. Telusuri seluruh file `.vb`, `.Designer.vb`, `.resx`, konfigurasi, dan pemanggilan reflection/dynamic loading.
2. Pisahkan referensi langsung, dependensi transitif, COM/ActiveX, dan assembly yang hanya diperlukan Designer.
3. Hapus kandidat satu kelompok kecil pada branch audit, restore NuGet, rebuild, lalu uji form/fitur terkait.
4. Bandingkan ukuran folder Publish sebelum/sesudah; jangan menghapus file DLL manual dari folder Publish sebagai pengganti perubahan project.
5. Jangan merge ke branch utama sebelum build dan pengujian fitur lolos.

