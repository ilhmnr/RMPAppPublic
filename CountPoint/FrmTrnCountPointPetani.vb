Imports System.Data.SqlClient
Imports System.Reflection.Emit

' =====================================================================================
' FORM: FrmTrnCountPointPetani
' TUJUAN:
'   Form ini menjalankan proses harian penghitungan poin loyalty petani via
'   stored procedure RMPApp..spPoinNew, dan proses awal bulan (reset flag +
'   inisiasi periode) via RMPApp..spPoinNewcreateawalbulan (CATATAN: SP ini
'   tidak dipakai/dijalankan di operasional saat ini).
'
' RINGKASAN ALUR PENGGUNAAN HARIAN (urutan klik tombol):
'   1. Button4   -> loaddatasupplier()  : tarik 5 supplier dgn FlagMonthPoint_new=0
'   2. Button2   -> tmrtgl.Enabled=True : proses 5 supplier itu (netto=0) via
'                                          SavetglPoin -> spPoinNew, lalu otomatis
'                                          ambil 5 berikutnya, berulang sampai habis
'   3. Button1   -> loaddata()          : tarik 1 nota asli (TRANSID terkecil
'                                          yang belum diproses)
'   4. btnsave   -> tmrpoin.Enabled=True: proses nota itu (netto asli) via
'                                          SavePoin2023 -> spPoinNew, lalu otomatis
'                                          ambil nota berikutnya, berulang sampai habis
'
' RINGKASAN ALUR AWAL BULAN (dijalankan sekali per bulan):
'   a. Set DateTimePicker1 ke bulan SEBELUMNYA, jalankan alur harian di atas
'      sampai tuntas (memproses semua nota bulan lalu).
'   b. Set DateTimePicker1 balik ke bulan SEKARANG.
'   c. Klik btnHitungAwalBulan -> reset FlagMonthPoint_new & FlagMonthPoint_newawal
'      ke 0 untuk SEMUA supplier, supaya alur harian di atas mulai memproses
'      bulan baru dari awal.
'
' CATATAN PENTING (hasil investigasi bug klasifikasi poin, Juni 2026):
'   - Variabel LOADDATA_ / LOADDATA1_ / LOADDATA2_ adalah field level class dan
'     TIDAK di-reset di awal setiap proses. Akibatnya, kalau spPoinNew gagal
'     (exception, misal divide-by-zero) di tengah loop, blok Catch akan
'     menampilkan MessageBox, TAPI karena variabel LOADDATA_ masih bernilai 1
'     dari sukses sebelumnya, kondisi "If LOADDATA_ = 1 Then loaddata()" tetap
'     terpenuhi -> nota yang sama (masih TRANSID terkecil yang belum tercatat)
'     akan ditarik ulang dan diproses ulang -> error berulang terus-menerus
'     selama timer masih aktif. Ini adalah alasan operasional di balik daftar
'     NOT IN (...) di loaddata() (nota-nota yang di-exclude manual karena
'     pernah menyebabkan error saat eksekusi spPoinNew).
'   - Root cause error tersebut sudah diperbaiki di sisi spPoinNew (lihat
'     spPoinNew_FIXED.sql). Setelah fix itu dipasang & diuji, daftar exclude
'     NOT IN (...) di loaddata() seharusnya bisa dikosongkan kembali.
'   - spPoinNewcreateawalbulan (dipanggil dari SavetglPoinawal/Timer1) saat ini
'     TIDAK dijalankan di operasional sehari-hari, jadi tidak menjadi prioritas
'     perbaikan.
'
' Catatan perapian kode ini: HANYA indentasi, pengelompokan komentar, dan
' penjelasan alur yang ditambahkan. Tidak ada logika yang diubah dari kode asli.
' =====================================================================================

Public Class FrmTrnCountPointPetani

#Region "Variabel Class"
    ' Flag penanda "masih ada data berhasil diproses, lanjutkan loop":
    '   LOADDATA_  -> dipakai oleh alur nota harian (SavePoin / SavePoin2023)
    '   LOADDATA1_ -> dipakai oleh alur 5-supplier awal bulan (SavetglPoin)
    '   LOADDATA2_ -> dipakai oleh alur awal bulan "createawalbulan" (SavetglPoinawal)
    ' CATATAN: ketiganya tidak pernah direset ke 0 di awal proses, lihat
    ' catatan penting di header file ini.
    Dim LOADDATA_ As Integer
    Dim LOADDATA1_ As Integer
    Dim LOADDATA2_ As Integer

    ' Flag penanda "boleh mulai proses simpan poin" (di-set oleh loaddatasupplier/
    ' loaddataawal ketika query tidak menemukan baris lagi -> grid supplier kosong)
    Dim bolehsimpanpoin_ As Integer

    Public RD As SqlDataReader
#End Region


#Region "Pemanggil Stored Procedure: spAndroidloyaltyNew2023 (jalur lama/legacy)"

    ' Dipanggil dari Sub save() (legacy, lihat catatan di Sub save()).
    Private Function SaveDataAngkutanMuatDtl(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction,
                                              ByVal NONOTA As String, ByVal TRANSDATE As String, ByVal Jenis As String,
                                              ByVal IDPenerimaUang As String, ByVal IDSubPetani As String,
                                              ByVal Pancang As String, ByVal TarraPersen As Decimal,
                                              ByVal NettoAkhir As Decimal) As Boolean

        Dim MyCMD As New SqlCommand
        With MyCMD
            SaveDataAngkutanMuatDtl = False
            Dim MyCon As SqlConnection = Conn
            Dim MyConTrans As SqlTransaction = Trans
            .Connection = MyCon
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RMPApp..spAndroidloyaltyNew2023"
            .Transaction = MyConTrans
            .Parameters.Add("@RETURN_VALUE", SqlDbType.SmallInt).Direction = ParameterDirection.ReturnValue
            .Parameters.Add("@NONOTA", SqlDbType.VarChar, 30).Value = NONOTA
            .Parameters.Add("@TRANSDATE", SqlDbType.DateTime).Value = TRANSDATE
            .Parameters.Add("@JENISKELAPA ", SqlDbType.VarChar, 10).Value = Jenis
            .Parameters.Add("@PENERIMAID", SqlDbType.VarChar, 30).Value = IDPenerimaUang
            .Parameters.Add("@SUBPETANIID", SqlDbType.VarChar, 30).Value = IDSubPetani
            .Parameters.Add("@Pancang", SqlDbType.VarChar, 100).Value = Pancang
            .Parameters.Add("@TarraPersen", SqlDbType.Decimal, 18, 4).Value = TarraPersen
            .Parameters.Add("@BeratNettoAkhir", SqlDbType.Decimal, 18, 4).Value = NettoAkhir
            .Parameters.Add("@DeviceName", SqlDbType.VarChar, 100).Value = Pancang
            .Parameters.Add(New SqlParameter("@Flag", SqlDbType.SmallInt, 5, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .ExecuteNonQuery()

            If CInt(.Parameters("@Flag").Value) = 0 Then
                .Dispose()
                Exit Function
            End If

            Return True
        End With
    End Function


    ' Dipanggil dari Sub processsave() (legacy, lihat catatan di Sub processsave()).
    Private Function SavePoin(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal I As Integer) As Boolean

        Dim MyCMD As New SqlCommand
        With MyCMD
            SavePoin = False
            Dim MyCon As SqlConnection = Conn
            Dim MyConTrans As SqlTransaction = Trans
            .Connection = MyCon
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RMPApp..spAndroidloyaltyNew2023"
            .Transaction = MyConTrans
            .Parameters.Add("@RETURN_VALUE", SqlDbType.SmallInt).Direction = ParameterDirection.ReturnValue
            .Parameters.Add("@NONOTA", SqlDbType.VarChar, 30).Value = dgvList.Item("NONOTA", I).Value
            .Parameters.Add("@TRANSDATE", SqlDbType.DateTime).Value = dgvList.Item("TRANSDATE", I).Value
            .Parameters.Add("@JENISKELAPA ", SqlDbType.VarChar, 10).Value = dgvList.Item("JENISKELAPA", I).Value
            .Parameters.Add("@PENERIMAID", SqlDbType.VarChar, 30).Value = dgvList.Item("PENERIMAID", I).Value
            .Parameters.Add("@SUBPETANIID", SqlDbType.VarChar, 30).Value = (dgvList.Item("SUBPETANIID", I).Value)
            .Parameters.Add("@Pancang", SqlDbType.VarChar, 100).Value = dgvList.Item("Pancang", I).Value
            .Parameters.Add("@TarraPersen", SqlDbType.Decimal, 18, 4).Value = dgvList.Item("TarraPersen", I).Value
            .Parameters.Add("@BeratNettoAkhir", SqlDbType.Decimal, 18, 4).Value =
                (If(Val(dgvList.Item("BeratNettoAkhir", I).Value) = 0, 0, Convert.ToDouble(dgvList.Item("BeratNettoAkhir", I).Value)))
            .Parameters.Add("@DeviceName", SqlDbType.VarChar, 100).Value = dgvList.Item("Pancang", I).Value
            .Parameters.Add(New SqlParameter("@Flag", SqlDbType.SmallInt, 5, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .ExecuteNonQuery()

            If CInt(.Parameters("@Flag").Value) = 0 Then
                .Dispose()
                Exit Function
            End If

            If CInt(.Parameters("@Flag").Value) = 1 Then
                LOADDATA_ = 1
            Else
                Exit Function
            End If

            Return True
        End With
    End Function

#End Region


#Region "Pemanggil Stored Procedure: spPoinNew (jalur aktif yang dipakai sehari-hari)"

    ' Dipanggil dari Sub processsave2023(), untuk SATU nota asli dari dgvList
    ' (hasil loaddata()), dengan @BeratNettoAkhir = netto sungguhan nota itu.
    ' Ini adalah jalur UTAMA penghitungan poin harian.
    Private Function SavePoin2023(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal I As Integer) As Boolean
        Dim MyCMD As New SqlCommand
        With MyCMD
            SavePoin2023 = False
            .Connection = Conn
            .Transaction = Trans
            .CommandType = CommandType.StoredProcedure
            .CommandText = "spPoinNew"
            .CommandTimeout = 120  ' ← tambah ini

            .Parameters.Add("@RETURN_VALUE", SqlDbType.SmallInt).Direction = ParameterDirection.ReturnValue
            .Parameters.Add("@NONOTA", SqlDbType.VarChar, 30).Value = dgvList.Item("NONOTA", I).Value
            .Parameters.Add("@TRANSDATE", SqlDbType.DateTime).Value = dgvList.Item("TRANSDATE", I).Value
            .Parameters.Add("@JENISKELAPA", SqlDbType.VarChar, 50).Value = dgvList.Item("JENISKELAPA", I).Value  ' fix spasi & size
            .Parameters.Add("@PENERIMAID", SqlDbType.VarChar, 50).Value = dgvList.Item("PENERIMAID", I).Value
            .Parameters.Add("@SUBPETANIID", SqlDbType.VarChar, 50).Value = dgvList.Item("SUBPETANIID", I).Value
            .Parameters.Add("@Pancang", SqlDbType.VarChar, 100).Value = dgvList.Item("Pancang", I).Value
            .Parameters.Add("@TarraPersen", SqlDbType.Decimal).Value = Convert.ToDecimal(dgvList.Item("TarraPersen", I).Value)
            .Parameters.Add("@BeratNettoAkhir", SqlDbType.Decimal).Value = Convert.ToDecimal(dgvList.Item("BeratNettoAkhir", I).Value)
            .Parameters.Add("@DeviceName", SqlDbType.VarChar, 100).Value = dgvList.Item("Pancang", I).Value
            .Parameters.Add(New SqlParameter("@Flag", SqlDbType.SmallInt, 5, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))

            .ExecuteNonQuery()

            If CInt(.Parameters("@Flag").Value) = 1 Then
                LOADDATA_ = 1
                Return True
            Else
                Return False
            End If
        End With
    End Function


    ' Dipanggil dari Sub processsave1(), untuk baris-baris SUPPLIER (bukan nota
    ' asli) dari dgvsupplier (hasil loaddatasupplier()), dengan @BeratNettoAkhir=0
    ' selalu. Ini jalur "kickoff" per-supplier (cek hangus / inisiasi periode
    ' pertama), dipakai di awal alur harian (Button4 + Button2).
    Private Function SavetglPoin(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal I As Integer) As Boolean

        Dim MyCMD As New SqlCommand
        With MyCMD
            SavetglPoin = False
            Dim MyCon As SqlConnection = Conn
            Dim MyConTrans As SqlTransaction = Trans
            .Connection = MyCon
            .CommandType = CommandType.StoredProcedure
            '.CommandText = "RMPApp..spAndroidloyaltyNewHdr"
            .CommandText = "RMPApp..spPoinNew"
            .Transaction = MyConTrans
            .Parameters.Add("@RETURN_VALUE", SqlDbType.SmallInt).Direction = ParameterDirection.ReturnValue
            .Parameters.Add("@NONOTA", SqlDbType.VarChar, 30).Value = dgvsupplier.Item("NONOTA2", I).Value
            .Parameters.Add("@TRANSDATE", SqlDbType.DateTime).Value = dgvsupplier.Item("TRANSDATE2", I).Value
            .Parameters.Add("@JENISKELAPA ", SqlDbType.VarChar, 10).Value = dgvsupplier.Item("JENISKELAPA2", I).Value
            .Parameters.Add("@PENERIMAID", SqlDbType.VarChar, 30).Value = dgvsupplier.Item("PENERIMAID2", I).Value
            .Parameters.Add("@SUBPETANIID", SqlDbType.VarChar, 30).Value = (dgvsupplier.Item("SUBPETANIID2", I).Value)
            .Parameters.Add("@Pancang", SqlDbType.VarChar, 100).Value = dgvsupplier.Item("Pancang2", I).Value
            .Parameters.Add("@TarraPersen", SqlDbType.Decimal, 18, 4).Value = dgvsupplier.Item("TarraPersen2", I).Value
            .Parameters.Add("@BeratNettoAkhir", SqlDbType.Decimal, 18, 4).Value = 0
            .Parameters.Add("@DeviceName", SqlDbType.VarChar, 100).Value = dgvsupplier.Item("Pancang2", I).Value
            .Parameters.Add(New SqlParameter("@Flag", SqlDbType.SmallInt, 5, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .ExecuteNonQuery()

            If CInt(.Parameters("@Flag").Value) = 0 Then
                .Dispose()
                Exit Function
            End If

            If CInt(.Parameters("@Flag").Value) = 1 Then
                LOADDATA1_ = 1
            Else
                Exit Function
            End If

            Return True
        End With
    End Function

#End Region


#Region "Pemanggil Stored Procedure: spPoinNewcreateawalbulan (TIDAK DIPAKAI saat ini)"

    ' Dipanggil dari Sub processsave1awal() / Timer1. CATATAN: jalur ini
    ' (Button7 / Timer1) tidak dijalankan dalam operasional sehari-hari.
    Private Function SavetglPoinawal(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal I As Integer) As Boolean

        Dim MyCMD As New SqlCommand
        With MyCMD
            SavetglPoinawal = False
            Dim MyCon As SqlConnection = Conn
            Dim MyConTrans As SqlTransaction = Trans
            .Connection = MyCon
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RMPApp..spPoinNewcreateawalbulan"
            .Transaction = MyConTrans
            .Parameters.Add("@RETURN_VALUE", SqlDbType.SmallInt).Direction = ParameterDirection.ReturnValue
            .Parameters.Add("@NONOTA", SqlDbType.VarChar, 30).Value = dgvsupplier.Item("NONOTA2", I).Value
            .Parameters.Add("@TRANSDATE", SqlDbType.DateTime).Value = dgvsupplier.Item("TRANSDATE2", I).Value
            .Parameters.Add("@JENISKELAPA ", SqlDbType.VarChar, 10).Value = dgvsupplier.Item("JENISKELAPA2", I).Value
            .Parameters.Add("@PENERIMAID", SqlDbType.VarChar, 30).Value = dgvsupplier.Item("PENERIMAID2", I).Value
            .Parameters.Add("@SUBPETANIID", SqlDbType.VarChar, 30).Value = (dgvsupplier.Item("SUBPETANIID2", I).Value)
            .Parameters.Add("@Pancang", SqlDbType.VarChar, 100).Value = dgvsupplier.Item("Pancang2", I).Value
            .Parameters.Add("@TarraPersen", SqlDbType.Decimal, 18, 4).Value = dgvsupplier.Item("TarraPersen2", I).Value
            .Parameters.Add("@BeratNettoAkhir", SqlDbType.Decimal, 18, 4).Value = 0
            .Parameters.Add("@DeviceName", SqlDbType.VarChar, 100).Value = dgvsupplier.Item("Pancang2", I).Value
            .Parameters.Add(New SqlParameter("@Flag", SqlDbType.SmallInt, 5, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .ExecuteNonQuery()

            If CInt(.Parameters("@Flag").Value) = 0 Then
                .Dispose()
                Exit Function
            End If

            If CInt(.Parameters("@Flag").Value) = 1 Then
                LOADDATA2_ = 1
            Else
                Exit Function
            End If

            Return True
        End With
    End Function

#End Region


#Region "Pemanggil Stored Procedure: spPoinHangus (dipanggil tapi tidak pernah diaktifkan dari pemanggilnya)"

    ' CATATAN: function ini ADA tapi pemanggilannya selalu dalam keadaan
    ' di-comment-out di processsave1() / processsave1awal() (lihat blok
    ' "If SaveHangus(...) = False Then" yang di-comment di bawah). Jadi
    ' function ini saat ini TIDAK PERNAH benar-benar dieksekusi.
    Private Function SaveHangus(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        Dim MyCMD As New SqlCommand
        With MyCMD
            SaveHangus = False
            Dim MyCon As SqlConnection = Conn
            Dim MyConTrans As SqlTransaction = Trans
            .Connection = MyCon
            .CommandType = CommandType.StoredProcedure
            .CommandText = "DBCounter..spPoinHangus"
            .Transaction = MyConTrans
            .Parameters.Add("@RETURN_VALUE", SqlDbType.SmallInt).Direction = ParameterDirection.ReturnValue
            .Parameters.Add("@TRANSDATE", SqlDbType.DateTime).Value = DateTimePicker1.Value
            .Parameters.Add(New SqlParameter("@Flag", SqlDbType.SmallInt, 5, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .ExecuteNonQuery()

            If CInt(.Parameters("@Flag").Value) = 0 Then
                .Dispose()
                Exit Function
            End If

            Return True
        End With
    End Function

#End Region


#Region "Load Data: Nota Asli Harian (dgvList)"

    ' Dipanggil dari Button1 (klik manual) dan otomatis ulang oleh processsave2023()
    ' setelah satu nota berhasil diproses (LOADDATA_=1), sampai tidak ada nota
    ' tersisa di bulan yang sedang aktif (DateTimePicker1).
    '
    ' Hanya berjalan kalau dgvsupplier sudah kosong (Rows.Count < 2) -- artinya
    ' alur 5-supplier (Button4+Button2) harus sudah selesai dulu sebelum alur
    ' nota asli ini mulai mengambil data.
    '
    ' Diurutkan ASCENDING berdasarkan TRANSID (urutan input ke sistem), BUKAN
    ' berdasarkan TransDate -- jadi nota yang tanggalnya lebih tua tapi
    ' diinput belakangan akan diproses setelah nota lain yang sudah lebih
    ' dulu masuk ke sistem.
    '
    ' Daftar NOT IN (...) di bawah adalah nota-nota yang di-exclude manual
    ' karena pernah menyebabkan error saat dieksekusi via spPoinNew (lihat
    ' catatan di header file ini soal root cause & rencana penghapusan
    ' daftar ini setelah fix bug klasifikasi dipasang & terverifikasi).
    Private Sub loaddata()
        Dim SQL As String, i As Integer
        Dim COUNTKAPAL As Integer
        COUNTKAPAL = 0
        If (dgvsupplier.Rows.Count) < 2 Then
            SQL = " SELECT top(1) * FROM vwKelapaHdrNULL2023 WITH(NOLOCK) WHERE    MONTH(TRANSDATE)=MONTH('" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "')  AND YEAR(TRANSDATE) = YEAR('" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' )  
                    and NONOTA not in('00046/032026/PH',
                                        '03327/042026/PH',
                                        '03527/042026/PH',
                                        '12410/042026/PL',
                                        '00062/052026/PH',
                                        '07010/052026/PL',
                                        '07061/052026/PL',
                                        '07409/052026/PL',
                                        '08211/052026/S1',
                                        '08219/052026/PL',
                                        '09237/052026/PL',
'08835/062026/PD') 
                     ORDER BY TRANSID ASC "

            Using koneksi As New SqlCommand(SQL, RMPApp.DB.OpenConnection(RMPApp.StrConnRMPApp))
                Using DR = koneksi.ExecuteReader()
                    If DR.HasRows Then
                        dgvList.Rows.Clear()
                        While DR.Read
                            With dgvList
                                .Rows.Add()
                                .Item("noNOTA", i).Value = DR!NONOTA
                                .Item("TRANSDATE", i).Value = DR!TRANSDATE
                                .Item("JENISKELAPA", i).Value = DR!JENIS
                                .Item("PENERIMAID", i).Value = DR!IDPenerimaUang
                                .Item("SUBPETANIID", i).Value = DR!IDSubPetani
                                .Item("Pancang", i).Value = DR!Pancang
                                .Item("TarraPersen", i).Value = DR!TarraPersen
                                .Item("BeratNettoAkhir", i).Value = DR!NettoAkhir
                                i += 1
                            End With
                        End While
                    Else
                        dgvList.Rows.Clear()
                        Exit Sub
                    End If
                    DR.Close()
                End Using
            End Using
            RMPApp.Modul_RMP.DB.CloseConnection()
        End If
    End Sub

#End Region


#Region "Load Data: Supplier 5-an (dgvsupplier) untuk Awal Bulan / Cek Hangus"

    ' Dipanggil dari Button4 (klik manual) dan DateTimePicker1_ValueChanged,
    ' dan otomatis ulang oleh processsave1() setelah 5 supplier berhasil
    ' diproses (LOADDATA1_=1), sampai tidak ada supplier dengan
    ' FlagMonthPoint_new=0/NULL tersisa.
    '
    ' Hasil query ini adalah BARIS SINTETIS (bukan nota timbang asli):
    ' NoNota dibuat dari KODESUP + tanggal, NettoAkhir selalu 0. Baris ini
    ' nantinya dipakai sebagai trigger @BeratNettoAkhir=0 ke spPoinNew lewat
    ' SavetglPoin (lihat STEP 1/3/7A di spPoinNew: cek hangus / inisiasi
    ' periode pertama).
    Private Sub loaddatasupplier()
        Dim SQL As String, i As Integer
        Dim COUNTKAPAL As Integer
        COUNTKAPAL = 0

        SQL = " With dataa As (  Select   TOP(5) 0 As  TransID,'' as IDPancang ,KODESUP +'/'+'" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' as NoNota  ,'" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "'  as TransDate ,'" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' as TanggalNota ,kodesup as IDSubPetani
               ,namasup as SubPetani,'' as IDPenerimaUang,'' as PenerimaUang,'' as Alamat ,'' as Pancang,0 as NettoAkhir,0 as Deleted
                ,'' as Jenis,0 as  TarraPersen FROM  RSUPAccounting..tblRMMstSupplier
                WHERE KODESUP Like '%PCG%' AND (NOTACTIVE=0 OR NOTACTIVE IS NULL)
                AND (FlagMonthPoint_new IS NULL OR FlagMonthPoint_new=0)  
                )
               Select * From dataA Order By IDSubPetani  ASC"

        Using koneksi As New SqlCommand(SQL, RMPApp.DB.OpenConnection(RMPApp.StrConnRMPApp))
            Using DR = koneksi.ExecuteReader()
                If DR.HasRows Then
                    dgvsupplier.Rows.Clear()
                    While DR.Read
                        With dgvsupplier
                            .Rows.Add()
                            .Item("noNOTA2", i).Value = DR!NONOTA
                            .Item("TRANSDATE2", i).Value = DR!TRANSDATE
                            .Item("JENISKELAPA2", i).Value = DR!JENIS
                            .Item("PENERIMAID2", i).Value = DR!IDPenerimaUang
                            .Item("SUBPETANIID2", i).Value = DR!IDSubPetani
                            .Item("Pancang2", i).Value = DR!Pancang
                            .Item("TarraPersen2", i).Value = DR!TarraPersen
                            .Item("NettoAkhir2", i).Value = DR!NettoAkhir
                            i += 1
                        End With
                    End While
                    LOADDATA_ = 0
                    bolehsimpanpoin_ = 0
                Else
                    bolehsimpanpoin_ = 1

                    dgvsupplier.Rows.Clear()
                    Exit Sub
                End If
                DR.Close()
            End Using
        End Using
        RMPApp.Modul_RMP.DB.CloseConnection()

    End Sub


    ' Versi paralel dari loaddatasupplier(), tapi memfilter berdasarkan
    ' FlagMonthPoint_newawal (bukan FlagMonthPoint_new). Dipakai oleh jalur
    ' "createawalbulan" (Button7/Timer1) yang TIDAK DIPAKAI saat ini.
    Private Sub loaddataawal()
        Dim SQL As String, i As Integer
        Dim COUNTKAPAL As Integer
        COUNTKAPAL = 0

        SQL = " With dataa As (  Select   TOP(5) 0 As  TransID,'' as IDPancang ,KODESUP +'/'+'" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' as NoNota  ,'" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "'  as TransDate ,'" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' as TanggalNota ,kodesup as IDSubPetani
               ,namasup as SubPetani,'' as IDPenerimaUang,'' as PenerimaUang,'' as Alamat ,'' as Pancang,0 as NettoAkhir,0 as Deleted
                ,'' as Jenis,0 as  TarraPersen FROM  RSUPAccounting..tblRMMstSupplier
                WHERE KODESUP Like '%PCG%' AND (NOTACTIVE=0 OR NOTACTIVE IS NULL)
                AND (FlagMonthPoint_newawal IS NULL OR FlagMonthPoint_newawal=0)  
                )
               Select * From dataA Order By IDSubPetani  ASC"

        Using koneksi As New SqlCommand(SQL, RMPApp.DB.OpenConnection(RMPApp.StrConnRMPApp))
            Using DR = koneksi.ExecuteReader()
                If DR.HasRows Then
                    dgvsupplier.Rows.Clear()
                    While DR.Read
                        With dgvsupplier
                            .Rows.Add()
                            .Item("noNOTA2", i).Value = DR!NONOTA
                            .Item("TRANSDATE2", i).Value = DR!TRANSDATE
                            .Item("JENISKELAPA2", i).Value = DR!JENIS
                            .Item("PENERIMAID2", i).Value = DR!IDPenerimaUang
                            .Item("SUBPETANIID2", i).Value = DR!IDSubPetani
                            .Item("Pancang2", i).Value = DR!Pancang
                            .Item("TarraPersen2", i).Value = DR!TarraPersen
                            .Item("NettoAkhir2", i).Value = DR!NettoAkhir
                            i += 1
                        End With
                    End While
                    LOADDATA_ = 0
                    bolehsimpanpoin_ = 0
                Else
                    bolehsimpanpoin_ = 1

                    dgvsupplier.Rows.Clear()
                    Exit Sub
                End If
                DR.Close()
            End Using
        End Using
        RMPApp.Modul_RMP.DB.CloseConnection()
    End Sub

#End Region


#Region "Proses Simpan: Legacy (tidak dipakai di alur aktif saat ini)"

    ' Dipanggil hanya dari kode yang di-comment-out di btnsave_Click.
    ' Mengambil 1 baris dari vwKelapaHdrNULL2023 untuk periode Jan 2022
    ' (hardcoded), lalu simpan via SaveDataAngkutanMuatDtl. Tidak terhubung
    ' ke alur aktif manapun saat ini.
    Private Sub save()

        Dim Koneksi2 As SqlConnection = RMPApp.DB.OpenConnection(RMPApp.StrConnAccounting)
        Dim Transaksi As SqlTransaction
        Transaksi = Koneksi2.BeginTransaction

        Try
            Dim connp2 As New SqlConnection(RMPApp.StrConnAccounting)

            Dim sql As String
            connp2.Open()
            sql = "Select top(1) * FROM  RMPAPP..vwKelapaHdrNULL2023 WHERE YEAR(TRANSDATE)='2022' and month(transdate)='01' ORDER BY cast(TRANSDATE as date),nonota ASC "
            Dim cmdselect As New SqlCommand(sql, connp2)
            RD = cmdselect.ExecuteReader()

            If RD.HasRows Then
                If RD.Read Then
                    Dim JENIS As String
                    JENIS = RD("jenis")
                    JENIS = JENIS
                    If SaveDataAngkutanMuatDtl(Koneksi2, Transaksi, RD("NONOTA"), Format(CDate(RD("TRANSDATE")), "yyyy-MM-dd"),
                                                RD("jenis"), RD("IDPenerimaUang"), RD("IDSubPetani"), RD("Pancang"),
                                                RD("TarraPersen"), RD("NettoAkhir")) = False Then
                        Format(CDate(RD("TRANSDATE")), "yyyy-MM-dd")
                        Transaksi.Rollback()
                        Transaksi = Nothing
                        Exit Try
                    End If
                    Transaksi.Commit()
                End If
            Else
                Exit Try
            End If

        Catch ex As Exception
            Transaksi.Rollback()
            RMPApp.DB.CloseConnection()
        Finally
            Koneksi2.Close()
            RMPApp.DB.CloseConnection()
        End Try
        RMPApp.DB.CloseConnection()
    End Sub


    ' Dipanggil hanya dari kode yang di-comment-out di btnsave_Click.
    ' Versi loop penuh (For i = 0 To dgvList.RowCount-1) memakai SavePoin
    ' (-> spAndroidloyaltyNew2023, bukan spPoinNew). Tidak terhubung ke
    ' alur aktif manapun saat ini.
    Private Sub processsave()
        Dim Koneksi As SqlConnection = RMPApp.DB.OpenConnection(RMPApp.StrConnRMPApp)
        Dim Transaksi As SqlTransaction
        Transaksi = Koneksi.BeginTransaction
        Me.Cursor = Cursors.WaitCursor
        Try

            For i = 0 To dgvList.RowCount - 1
                If (dgvsupplier.Rows.Count) < 2 Then
                    If (dgvList.Item("NONOTA", i).Value) <> "" Then
                        If SavePoin(Koneksi, Transaksi, i) = False Then
                            Transaksi.Rollback()
                            Transaksi = Nothing
                            Me.Cursor = Cursors.Default
                            Label2.Text = "Simpan Data Dtl Gagal!"
                            Exit Sub
                        End If
                    End If
                End If
            Next i

            Transaksi.Commit()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Transaksi.Rollback()
            Koneksi.Close()

        Finally
            Koneksi.Close()
        End Try
        Me.Cursor = Cursors.Default

        If LOADDATA_ = 1 Then
            loaddata()
        Else
            Transaksi = Nothing
            Transaksi.Rollback()
            Exit Sub
        End If
    End Sub

#End Region


#Region "Proses Simpan: Alur Nota Harian Aktif (dipakai oleh btnsave + tmrpoin)"

    ' INI ADALAH JALUR UTAMA penghitungan poin harian.
    ' Dipanggil pertama kali oleh tmrpoin_Tick (timer diaktifkan via btnsave_Click),
    ' lalu memanggil dirinya sendiri secara tidak langsung lewat loaddata() setiap
    ' kali satu nota berhasil diproses (LOADDATA_=1), sehingga timer tick
    ' berikutnya akan memproses nota baru yang sudah ter-load.
    '
    ' Kondisi loop "For i = 0 To dgvList.RowCount - 1" pada praktiknya hanya
    ' memproses i=0 secara efektif, karena dgvList selalu diisi ulang dengan
    ' TOP(1) baris oleh loaddata() di setiap pemanggilan.
    '
    ' CATATAN: kalau SavePoin2023 (spPoinNew) melempar exception SQL di tengah
    ' eksekusi (misal divide-by-zero akibat bug klasifikasi kosong), proses
    ' masuk ke blok Catch -> tampil MessageBox & Rollback. Karena LOADDATA_
    ' tidak direset, kondisi "If LOADDATA_ = 1" di akhir tetap terpenuhi dari
    ' nota sukses sebelumnya, sehingga loaddata() dipanggil lagi dan menarik
    ' ULANG nota yang sama (karena belum berhasil tercatat) -> error berulang
    ' selama timer tmrpoin masih aktif.
    Private Sub processsave2023()
        Dim Koneksi As SqlConnection = RMPApp.DB.OpenConnection(RMPApp.StrConnRMPApp)
        Dim Transaksi As SqlTransaction
        Transaksi = Koneksi.BeginTransaction
        Me.Cursor = Cursors.WaitCursor
        Try

            For i = 0 To dgvList.RowCount - 1
                If (dgvsupplier.Rows.Count) < 2 Then
                    If (dgvList.Item("NONOTA", i).Value) <> "" Then
                        If SavePoin2023(Koneksi, Transaksi, i) = False Then
                            Transaksi.Rollback()
                            Transaksi = Nothing
                            Me.Cursor = Cursors.Default
                            Label2.Text = "Simpan Data Dtl Gagal!"
                            Exit Sub
                        End If
                    End If
                End If
            Next i

            Transaksi.Commit()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Transaksi.Rollback()
            Koneksi.Close()

        Finally
            Koneksi.Close()
        End Try
        Me.Cursor = Cursors.Default

        If LOADDATA_ = 1 Then
            loaddata()
            Exit Sub
        End If
    End Sub

#End Region


#Region "Proses Simpan: Alur Supplier 5-an Aktif (dipakai oleh Button2 + tmrtgl)"

    ' INI ADALAH JALUR UTAMA "kickoff" per-supplier di awal alur harian.
    ' Dipanggil pertama kali oleh tmrtgl_Tick (timer diaktifkan via Button2_Click),
    ' lalu memproses semua baris dgvsupplier (5 baris hasil loaddatasupplier())
    ' lewat SavetglPoin (-> spPoinNew, @BeratNettoAkhir=0). Setelah satu batch
    ' berhasil (LOADDATA1_=1), loaddatasupplier() dipanggil lagi untuk mengambil
    ' 5 supplier berikutnya, berulang sampai grid kosong (bolehsimpanpoin_=1).
    '
    ' Blok pemanggilan SaveHangus di bawah ini SENGAJA di-comment-out (tidak
    ' pernah dieksekusi).
    Private Sub processsave1()
        Dim Koneksi As SqlConnection = RMPApp.DB.OpenConnection(RMPApp.StrConnRMPApp)
        Dim Transaksi As SqlTransaction
        Transaksi = Koneksi.BeginTransaction
        Me.Cursor = Cursors.WaitCursor
        Try

            For i = 0 To dgvsupplier.RowCount - 1
                If (dgvsupplier.Item("NONOTA2", i).Value) <> "" Then
                    If SavetglPoin(Koneksi, Transaksi, i) = False Then
                        Transaksi.Rollback()
                        Transaksi = Nothing
                        Me.Cursor = Cursors.Default
                        Label2.Text = "Simpan Data Dtl Gagal!"
                        Exit Sub
                    End If
                End If
            Next i

            ' --- SaveHangus TIDAK PERNAH dipanggil (sengaja di-comment-out) ---
            'If SaveHangus(Koneksi, Transaksi) = False Then
            '    Transaksi.Rollback()
            '    Transaksi = Nothing
            '    Me.Cursor = Cursors.Default
            '    Label2.Text = "Simpan Data Dtl Gagal!"
            '    Exit Sub
            'End If

            Transaksi.Commit()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Transaksi.Rollback()
            Koneksi.Close()
        Finally
            Koneksi.Close()
        End Try
        Me.Cursor = Cursors.Default

        If LOADDATA1_ = 1 Then
            loaddatasupplier()
        Else
            Exit Sub
        End If
    End Sub

#End Region


#Region "Proses Simpan: Alur Awal Bulan 'createawalbulan' (TIDAK DIPAKAI saat ini)"

    ' Dipanggil oleh Timer1_Tick_1 (timer diaktifkan via Button7_Click, yang
    ' sendiri tidak terhubung ke Handles manapun -- lihat Button7_Click di
    ' bawah). Jalur ini secara keseluruhan TIDAK DIJALANKAN di operasional.
    Private Sub processsave1awal()
        Dim Koneksi As SqlConnection = RMPApp.DB.OpenConnection(RMPApp.StrConnRMPApp)
        Dim Transaksi As SqlTransaction
        Transaksi = Koneksi.BeginTransaction
        Me.Cursor = Cursors.WaitCursor
        Try

            For i = 0 To dgvsupplier.RowCount - 1
                If (dgvsupplier.Item("NONOTA2", i).Value) <> "" Then
                    If SavetglPoinawal(Koneksi, Transaksi, i) = False Then
                        Transaksi.Rollback()
                        Transaksi = Nothing
                        Me.Cursor = Cursors.Default
                        Label2.Text = "Simpan Data Dtl Gagal!"
                        Exit Sub
                    End If
                End If
            Next i

            ' --- SaveHangus TIDAK PERNAH dipanggil (sengaja di-comment-out) ---
            'If SaveHangus(Koneksi, Transaksi) = False Then
            '    Transaksi.Rollback()
            '    Transaksi = Nothing
            '    Me.Cursor = Cursors.Default
            '    Label2.Text = "Simpan Data Dtl Gagal!"
            '    Exit Sub
            'End If

            Transaksi.Commit()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Transaksi.Rollback()
            Koneksi.Close()
        Finally
            Koneksi.Close()
        End Try
        Me.Cursor = Cursors.Default

        If LOADDATA2_ = 1 Then
            loaddataawal()
        Else
            Exit Sub
        End If
    End Sub

#End Region


#Region "Event Handler: Tombol & Timer"

    ' Tombol lama untuk memanggil loaddata() langsung (tanpa lewat timer).
    ' Tidak ada Handles -- kemungkinan tombol UI-nya sudah tidak terpasang/aktif.
    Private Sub btnLoaddata_Click(sender As Object, e As EventArgs)
        loaddata()
    End Sub


    ' Memulai alur nota harian (lihat Region "Proses Simpan: Alur Nota Harian Aktif").
    ' Kode di bawah yang di-comment-out adalah versi lama processsave2023()/processsave()
    ' yang sebelumnya ditulis langsung di sini, sebelum dipindah jadi Sub terpisah.
    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        tmrpoin.Enabled = True
        'processsave2023()
        'processsave()

        'Dim Koneksi As SqlConnection = DB.OpenConnection(StrConnRMPApp)
        'Dim Transaksi As SqlTransaction
        'Transaksi = Koneksi.BeginTransaction
        'Me.Cursor = Cursors.WaitCursor
        'Try

        '    For i = 0 To dgvList.RowCount - 1
        '        If (dgvsupplier.Rows.Count) < 2 Then
        '            If (dgvList.Item("NONOTA", i).Value) <> "" Then
        '                If SavePoin2023(Koneksi, Transaksi, i) = False Then
        '                    Transaksi.Rollback()
        '                    Transaksi = Nothing
        '                    Me.Cursor = Cursors.Default
        '                    Me.Cursor = Cursors.Default
        '                    Label2.Text = "Simpan Data Dtl Gagal!"
        '                    Exit Sub
        '                End If
        '            End If
        '        End If
        '    Next i

        '    Transaksi.Commit()

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Transaksi.Rollback()
        '    Koneksi.Close()

        'Finally
        '    Koneksi.Close()
        'End Try
        'Me.Cursor = Cursors.Default

        'If LOADDATA_ = 1 Then
        '    loaddata()
        '    'Else
        '    '    Transaksi = Nothing
        '    '    Transaksi.Rollback()
        '    Exit Sub
        'End If
    End Sub


    Private Sub FORMUNTUKINPUTLOYALTYCONTOH_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = Format(Now, "01/MM/yyyy")
        Timer2.Enabled = True
    End Sub


    ' Tick handler untuk tmrpoin (timer alur nota harian). Hanya jalan kalau
    ' bolehsimpanpoin_=1 (di-set oleh loaddatasupplier()/loaddataawal() saat
    ' grid supplier sudah kosong). Baris "On Error Resume Next" berarti error
    ' tak tertangani di luar Try/Catch processsave2023() akan diabaikan diam-diam.
    Private Sub tmrpoin_Tick(sender As Object, e As EventArgs) Handles tmrpoin.Tick
        'On Error Resume Next
        'If bolehsimpanpoin_ = 1 Then
        '    processsave()
        'End If

        On Error Resume Next
        If bolehsimpanpoin_ = 1 Then
            processsave2023()
        End If
    End Sub


    ' Memulai alur nota harian (Langkah 3: tarik 1 nota asli). Kode tanya-jawab
    ' konfirmasi "apakah hari ini tanggal 1" di bawah sengaja di-comment-out;
    ' reset flag awal bulan sekarang dilakukan lewat btnHitungAwalBulan_Click.
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        On Error Resume Next

        'Dim tanya As DialogResult
        'tanya = MessageBox.Show("Cek Apakah Hari Ini Tgl 1 (Awal Bulan) Jika Ya Klik OK Jika Todak Pilih No", "Konfirmasi", MessageBoxButtons.YesNo,
        '        MessageBoxIcon.Question)
        'If tanya = Windows.Forms.DialogResult.Yes Then
        '    'Dim UpdateData As String = String.Empty
        '    'UpdateData = "update RSUPAccounting..tblRMMstSupplier set FlagMonthPoint_new='0', FlagMonthPoint_newawal =0   "
        '    'Dim AksiData As New SqlCommand(UpdateData, RMPApp.DB.OpenConnection(StrConnAccounting))
        '    'AksiData.ExecuteNonQuery()
        '    'MessageBox.Show("Hitung Data Persupplier Terlebih Dahulu Jika Diawal Bulan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Else
        '    If bolehsimpanpoin_ = 1 Then

        loaddata()

        '    End If
        'End If
    End Sub


    ' Indikator visual status timer tmrpoin (aktif/tidak aktif), murni UI.
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If tmrpoin.Enabled = True Then
            Label1.Text = "Hitung Poin Aktif"
            Label1.ForeColor = Color.MediumSpringGreen
        Else
            Label1.Text = "Hitung Poin Tidak Aktif"
            Label1.ForeColor = Color.Red
        End If
    End Sub


    ' Tick handler untuk tmrtgl (timer alur supplier 5-an). "On Error Resume
    ' Next" berarti error tak tertangani di luar Try/Catch processsave1()
    ' akan diabaikan diam-diam.
    Private Sub tmrtgl_Tick(sender As Object, e As EventArgs) Handles tmrtgl.Tick
        On Error Resume Next
        processsave1()
    End Sub


    ' Memulai alur supplier 5-an (Langkah 2: aktifkan timer tmrtgl).
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        tmrtgl.Enabled = True
        'processsave1()
    End Sub


    ' Memulai alur supplier 5-an (Langkah 1: tarik 5 supplier flag=0).
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        loaddatasupplier()
    End Sub


    ' Setiap kali tanggal di DateTimePicker1 diganti manual, otomatis tarik
    ' ulang daftar supplier untuk tanggal baru tersebut.
    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        loaddatasupplier()
    End Sub


    ' Tombol kosong, tidak ada aksi yang diprogram.
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub


    ' Tombol cadangan/manual untuk memicu processsave2023() satu kali
    ' (tanpa lewat timer tmrpoin), hanya kalau bolehsimpanpoin_=1.
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'processsave()

        On Error Resume Next
        If bolehsimpanpoin_ = 1 Then
            processsave2023()
        End If
    End Sub


    ' Memicu loaddataawal() (jalur "createawalbulan", tidak dipakai saat ini).
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        loaddataawal()
    End Sub


    ' CATATAN: Button7_Click ini TIDAK memiliki klausa "Handles", artinya
    ' tidak terhubung ke event klik tombol Button7 manapun di desainer form
    ' saat ini -- kode ini ada tapi tidak akan pernah otomatis terpanggil
    ' dari UI kecuali di-wire ulang.
    Private Sub Button7_Click(sender As Object, e As EventArgs)
        'processsave1awal()
        Timer1.Enabled = True
    End Sub


    ' Tick handler untuk Timer1 (jalur "createawalbulan", tidak dipakai saat ini).
    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick
        processsave1awal()
    End Sub


    ' Dijalankan sekali di awal setiap bulan baru (lihat alur awal bulan di
    ' header file ini): reset FlagMonthPoint_new & FlagMonthPoint_newawal ke 0
    ' untuk SEMUA supplier (tanpa filter WHERE), supaya alur harian mulai
    ' memproses ulang dari awal untuk bulan yang baru.
    Private Sub btnHitungAwalBulan_Click(sender As Object, e As EventArgs) Handles btnHitungAwalBulan.Click
        Dim UpdateData As String = String.Empty
        UpdateData = "update RSUPAccounting..tblRMMstSupplier set FlagMonthPoint_new='0', FlagMonthPoint_newawal =0   "
        Dim AksiData As New SqlCommand(UpdateData, RMPApp.DB.OpenConnection(RMPApp.StrConnAccounting))
        AksiData.ExecuteNonQuery()
        MessageBox.Show("Hitung Data Persupplier Terlebih Dahulu Jika Diawal Bulan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

#End Region

End Class