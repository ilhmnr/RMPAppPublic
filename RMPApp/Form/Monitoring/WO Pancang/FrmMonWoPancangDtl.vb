Imports System.IO
Imports System.Windows.Documents
Imports C1.Win.C1FlexGrid
Imports DocumentFormat.OpenXml.EMMA

Public Class FrmMonWoPancangDtl
    Public Sub showData()
        Call HeaderFg()

        Dim i As Integer = 1
        Dim dt As DataTable = New DataTable
        Dim dt2 As DataTable = New DataTable
        Dim dt3 As DataTable = New DataTable
        Dim dt4 As DataTable = New DataTable
        Dim dt5 As DataTable = New DataTable
        Dim dt6 As DataTable = New DataTable
        Dim dt7 As DataTable = New DataTable
        Dim dt8 As DataTable = New DataTable
        Dim dt9 As DataTable = New DataTable
        Dim dt10 As DataTable = New DataTable
        Dim dt11 As DataTable = New DataTable
        Dim dt12 As DataTable = New DataTable
        Dim query, query2, query3, query4, query5, query6, query7, query8, query9, query10, query11, query12 As String

        query = "   declare @id as int =" & txtWoId.Text & "
                        --1
                        SELECT 
                        1 as urut,1 as no,
                        'Input WO'as kolom1,'' as kolom2,'' as kolom3,'' as icon,'' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'' as kolom8,'' as kolom9,'' as kolom10,'' as kolom11,'' as kolom12
                        union
                        SELECT 
                        2 as urut,1 as no,
                        'Tanggal: '+cast(format(a.created_date,'dd/MM/yyyy') as varchar(10))+' Jam: '+cast(format(a.created_date,'HH:mm') as varchar(10)) as kolom1,
                        'Input by: '+b.NamaLengkap as kolom2 , 
                        '' as kolom3,'' as icon,'' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'' as kolom8,'' as kolom9,'' as kolom10,'' as kolom11,'' as kolom12
                        FROM tbl_wo_trn_hdr as a left outer join PancangRequestUser as b on a.created_by=b.Username WHERE a.id=@id

                        union --2

                        SELECT 
                        3 as urut,2 as no,
                        'Approval 1' as kolom1,'' as kolom2,'' as kolom3,'' as icon,'' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'' as kolom8,'' as kolom9,'' as kolom10,'' as kolom11,'' as kolom12
                        union
                        SELECT 
                        4 as urut,2 as no,
                        'Tanggal: '+ISNULL(cast((select top 1 FORMAT(created_date,'dd/MM/yyyy') from tbl_wo_trn_approval_wo where flag=1 and wo_id=@id) as varchar(10)),'dd/mm/yyyy')+' Jam: '+ISNULL(cast((select top 1 FORMAT(created_date,'hh:mm') from tbl_wo_trn_approval_wo where flag=1 and wo_id=@id) as varchar(10)),'hh/mm') as kolom1,
                        'Approved by: '+ISNULL((select top 1 isnull(b.namalengkap,a.created_by) from tbl_wo_trn_approval_wo as a left outer join PancangRequestUser as b on a.created_by=b.Username where a.flag=1 and a.wo_id=@id),'') as kolom2, 
                        '' as kolom3,'' as icon,'' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'' as kolom8,'' as kolom9,'' as kolom10,'' as kolom11,'' as kolom12

                        union --3

                        SELECT 
                        5 as urut,3 as no,
                        'Approval 2' as kolom1,'' as kolom2,'' as kolom3,'' as icon,'' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'' as kolom8,'' as kolom9,'' as kolom10,'' as kolom11,'' as kolom12
                        union
                        SELECT 
                        6 as urut,3 as no,
                        'Tanggal: '+ISNULL(cast((select top 1 FORMAT(created_date,'dd/MM/yyyy') from tbl_wo_trn_approval_wo where flag=2 and wo_id=@id) as varchar(10)),'dd/mm/yyyy')+' Jam: '+ISNULL(cast((select top 1 FORMAT(created_date,'hh:mm') from tbl_wo_trn_approval_wo where flag=2 and wo_id=@id) as varchar(10)),'hh/mm') as kolom1,
                        'Approved by: '+ISNULL((select top 1 isnull(b.namalengkap,a.created_by) from tbl_wo_trn_approval_wo as a left outer join PancangRequestUser as b on a.created_by=b.Username where a.flag=2 and a.wo_id=@id),'') as kolom2, 
                        '' as kolom3,'' as icon,'' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'' as kolom8,'' as kolom9,'' as kolom10,'' as kolom11,'' as kolom12

                        union--4

                        SELECT 
                        7 as urut,4 as no,
                        'Proses 1' as kolom1,'' as kolom2,'' as kolom3,'' as icon,'' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'' as kolom8,'' as kolom9,'' as kolom10,'' as kolom11,'' as kolom12
                        union
                        SELECT 
                        8 as urut,4 as no,
                        'Tanggal: '+ISNULL(cast((select top 1 FORMAT(b.created_date,'dd/MM/yyyy') from tbl_wo_trn_hdr as a left outer join tbl_wo_trn_file_wo as b on a.id=b.wo_id where a.file_design_proyek is not null and b.flag=6 and a.id=@id ) as varchar(10)),'dd/mm/yyyy')+' Jam: '+ISNULL(cast((select top 1 FORMAT(b.created_date,'hh:mm') from tbl_wo_trn_hdr as a left outer join tbl_wo_trn_file_wo as b on a.id=b.wo_id where a.file_design_proyek is not null and b.flag=6 and a.id=@id) as varchar(10)),'hh/mm') as kolom1,
                        'Processed by: '+ISNULL((select top 1 b.created_by from tbl_wo_trn_hdr as a left outer join tbl_wo_trn_file_wo as b on a.id=b.wo_id where a.file_design_proyek is not null and b.flag=6 and a.id=@id),'') as kolom2, 
                        'Proses Desain Proyek/Perbaikan' as kolom3,'' as icon, 
                        '' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'' as kolom8,'' as kolom9,'' as kolom10,'' as kolom11,
                        ISNULL((select top 1 a.file_design_proyek from tbl_wo_trn_hdr as a left outer join tbl_wo_trn_file_wo as b on a.id=b.wo_id where a.file_design_proyek is not null and b.flag=6 and a.id=@id),'') as kolom12
                        union
                        SELECT 
                        9 as urut,4 as no,
                        'Tanggal: '+ISNULL(cast((select top 1 FORMAT(b.created_date,'dd/MM/yyyy') from tbl_wo_trn_hdr as a left outer join tbl_wo_trn_file_wo as b on a.id=b.wo_id where ((a.file_penawaran_harga is not null and b.flag=1) or a.proyek_mandiri=1) and a.id=@id ) as varchar(10)),'dd/mm/yyyy')+' Jam: '+ISNULL(cast((select top 1 FORMAT(b.created_date,'hh:mm') from tbl_wo_trn_hdr as a left outer join tbl_wo_trn_file_wo as b on a.id=b.wo_id where ((a.file_penawaran_harga is not null and b.flag=1) or a.proyek_mandiri=1) and a.id=@id) as varchar(10)),'hh/mm') as kolom1,
                        'Processed by: '+ISNULL((select top 1 b.created_by from tbl_wo_trn_hdr as a left outer join tbl_wo_trn_file_wo as b on a.id=b.wo_id where ((a.file_penawaran_harga is not null and b.flag=1) or a.proyek_mandiri=1) and a.id=@id ),'') as kolom2, 
                        'Proses Penawaran Harga & Penentuan Kontraktor Pelaksana' as kolom3,'' as icon, 
                        '' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'' as kolom8,'' as kolom9,'' as kolom10,'' as kolom11,
                        ISNULL((select top 1 a.file_penawaran_harga from tbl_wo_trn_hdr as a left outer join tbl_wo_trn_file_wo as b on a.id=b.wo_id where ((a.file_penawaran_harga is not null and b.flag=1) or a.proyek_mandiri=1) and a.id=@id ),'') as kolom12
                        union
                        SELECT 
                        10 as urut,4 as no,
                        'Tanggal: '+ISNULL(cast((select top 1 FORMAT(updated_date,'dd/MM/yyyy') from tbl_wo_trn_barang where persen=1 and updated_date is not null and wo_id=@id) as varchar(10)),'dd/mm/yyyy')+' Jam: '+ISNULL(cast((select top 1 FORMAT(updated_date,'hh:mm') from tbl_wo_trn_barang where persen=1 and updated_date is not null and wo_id=@id) as varchar(10)),'hh/mm') as kolom1,
                        'Processed by: '+ISNULL((select top 1 created_by from tbl_wo_trn_barang where persen=1 and updated_date is not null and wo_id=@id),'') as kolom2, 
                        'Proses Master Proyek' as kolom3,'' as icon, 
                        '' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'' as kolom8,'' as kolom9,'' as kolom10,'' as kolom11,'' as kolom12

                        union--5

                        SELECT 
                        11 as urut,5 as no,
                        'Proses 2' as kolom1,'' as kolom2,'' as kolom3,'' as icon,'' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'' as kolom8,'' as kolom9,'' as kolom10,'' as kolom11,'' as kolom12
                        union
                        SELECT 
                        12 as urut,5 as no,
                        'Tanggal: '+ISNULL(cast((select top 1 FORMAT(created_date,'dd/MM/yyyy') from tbl_wo_trn_file_wo where flag=2 and deleted=0 and wo_id=@id) as varchar(10)),'dd/mm/yyyy')+' Jam: '+ISNULL(cast((select top 1 FORMAT(created_date,'hh:mm') from tbl_wo_trn_file_wo where flag=2 and deleted=0 and wo_id=@id) as varchar(10)),'hh/mm') as kolom1,
                        'Processed by: '+ISNULL((select top 1 created_by from tbl_wo_trn_file_wo where flag=2 and deleted=0 and wo_id=@id),'') as kolom2, 
                        'Proses Proposal' as kolom3,'' as icon, 
                        '' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'' as kolom8,'' as kolom9,'' as kolom10,'' as kolom11,
                        ISNULL((select top 1 file_name from tbl_wo_trn_file_wo where flag=2 and deleted=0 and wo_id=@id),'') as kolom12
                        union
                        SELECT 
                        13 as urut,5 as no,
                        'Tanggal: '+ISNULL(cast((select top 1 FORMAT(created_date,'dd/MM/yyyy') from tbl_wo_trn_file_wo where flag=3 and deleted=0 and wo_id=@id ) as varchar(10)),'dd/mm/yyyy')+' Jam: '+ISNULL(cast((select top 1 FORMAT(created_date,'hh:mm') from tbl_wo_trn_file_wo where flag=3 and deleted=0 and wo_id=@id) as varchar(10)),'hh/mm') as kolom1,
                        'Processed by: '+ISNULL((select top 1 created_by from tbl_wo_trn_file_wo where flag=3 and deleted=0 and wo_id=@id),'') as kolom2, 
                        'Proses SPK' as kolom3,'' as icon,
                        '' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'' as kolom8,'' as kolom9,'' as kolom10,'' as kolom11,
                        ISNULL((select top 1 file_name from tbl_wo_trn_file_wo where flag=3 and deleted=0 and wo_id=@id),'') as kolom12 
                        
                        union--6

                        SELECT 
                        14 as urut,6 as no,
                        'Proses 3' as kolom1,'' as kolom2, '' as kolom3,'' as icon, '' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'' as kolom8,'' as kolom9,'' as kolom10,'' as kolom11,'' as kolom12"

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, query)

        fg.Rows.Count = 1
        If dt.Rows.Count > 0 Then
            With fg
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, 0) = row("no")
                    .Item(i, 1) = row("kolom1")
                    .Item(i, 2) = row("kolom2")
                    .Item(i, 3) = row("kolom3")
                    .Item(i, 4) = row("icon")
                    .Item(i, 5) = row("kolom4")
                    .Item(i, 6) = row("kolom5")
                    .Item(i, 7) = row("kolom6")
                    .Item(i, 8) = row("kolom7")
                    .Item(i, 9) = row("kolom8")
                    .Item(i, 10) = row("kolom9")
                    .Item(i, 11) = row("kolom10")
                    .Item(i, 12) = row("kolom11")
                    .Item(i, 13) = row("kolom12")
                    i += 1
                Next
                .AutoSizeCols()
            End With
        End If

        'pembayaran dp

        If DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"select 'ada' as GetValueString from tbl_wo_trn_bayar where wo_id=" & txtWoId.Text & " and deleted=0 and flag in (1,2) ") = "ada" Then
            query2 = "  select
                            akum_persen as urut,6 as No, 
                            'Tanggal: '+cast(format(transfer_date,'dd/MM/yyyy') as varchar(10))+' Jam: '+cast(format(transfer_date,'hh:mm') as varchar(10)) as kolom1,
                            'Processed by: '+created_by as kolom2,
                            iif(deskripsi='UM','DP',deskripsi) as kolom3,'' as icon,'Rp' as kolom4,cast(bayar as decimal(18,0))  as kolom5,'Akumulasi Rp :' as kolom6,cast(akum_bayar as decimal(18,0)) as kolom7,'Persentase :' as kolom8,CAST(persen AS VARCHAR(3))+'%' as kolom9,'Akum Persentase :' as kolom10,CAST(akum_persen AS VARCHAR(3))+'%' as kolom11,file_pembayaran as kolom12
                            from tbl_wo_trn_bayar where wo_id=" & txtWoId.Text & " and flag in (1,2) and deleted=0 "
        Else
            query2 = "  select 
                            1 as urut,6 as No, 
                            'Tanggal: dd/mm/yyyy'+' Jam: hh/mm' as kolom1,
                            'Processed by: ' as kolom2,
                            'DP' as kolom3,'' as icon,'Rp' as kolom4,'' as kolom5,'Akumulasi Rp :' as kolom6,'' as kolom7,'Persentase :' as kolom8,'' as kolom9,'Akum Persentase :' as kolom10,'' as kolom11,'' as kolom12 "
        End If

        dt2 = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, query2)

        If dt2.Rows.Count > 0 Then
            With fg
                For Each row As DataRow In dt2.Rows
                    .AddItem(i)
                    .Item(i, 0) = row("no")
                    .Item(i, 1) = row("kolom1")
                    .Item(i, 2) = row("kolom2")
                    .Item(i, 3) = row("kolom3")
                    .Item(i, 4) = row("icon")
                    .Item(i, 5) = row("kolom4")
                    .Item(i, 6) = row("kolom5")
                    .Item(i, 7) = row("kolom6")
                    .Item(i, 8) = row("kolom7")
                    .Item(i, 9) = row("kolom8")
                    .Item(i, 10) = row("kolom9")
                    .Item(i, 11) = row("kolom10")
                    .Item(i, 12) = row("kolom11")
                    .Item(i, 13) = row("kolom12")
                    i += 1
                Next
                .AutoSizeCols()
            End With
        End If

        'pembayaran pelunasan

        If DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"select 'ada' as GetValueString from tbl_wo_trn_bayar where wo_id=" & txtWoId.Text & " and deleted=0 and flag=3") = "ada" Then
            query3 = "  select
                            akum_persen as urut,6 as No, 
                            'Tanggal: '+cast(format(transfer_date,'dd/MM/yyyy') as varchar(10))+' Jam: '+cast(format(transfer_date,'hh:mm') as varchar(10)) as kolom1,
                            'Processed by: '+created_by as kolom2,
                            'Pelunasan' as kolom3,'' as icon,'Rp' as kolom4,cast(bayar as decimal(18,0))  as kolom5,'Akumulasi Rp :' as kolom6,cast(akum_bayar as decimal(18,0)) as kolom7,'Persentase :' as kolom8,CAST(persen AS VARCHAR(3))+'%' as kolom9,'Akum Persentase :' as kolom10,CAST(akum_persen AS VARCHAR(3))+'%' as kolom11,file_pembayaran as kolom12
                            from tbl_wo_trn_bayar where wo_id=" & txtWoId.Text & " and flag=3 and deleted=0 "
        Else
            query3 = "  select 
                            1 as urut,6 as No, 
                            'Tanggal: dd/mm/yyyy'+' Jam: hh/mm' as kolom1,
                            'Processed by: ' as kolom2,
                            'Pelunasan' as kolom3,'' as icon,'Rp' as kolom4,'' as kolom5,'Akumulasi Rp :' as kolom6,'' as kolom7,'Persentase :' as kolom8,'' as kolom9,'Akum Persentase :' as kolom10,'' as kolom11,'' as kolom12 "
        End If

        dt3 = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, query3)

        If dt3.Rows.Count > 0 Then
            With fg
                For Each row As DataRow In dt3.Rows
                    .AddItem(i)
                    .Item(i, 0) = row("no")
                    .Item(i, 1) = row("kolom1")
                    .Item(i, 2) = row("kolom2")
                    .Item(i, 3) = row("kolom3")
                    .Item(i, 4) = row("icon")
                    .Item(i, 5) = row("kolom4")
                    .Item(i, 6) = row("kolom5")
                    .Item(i, 7) = row("kolom6")
                    .Item(i, 8) = row("kolom7")
                    .Item(i, 9) = row("kolom8")
                    .Item(i, 10) = row("kolom9")
                    .Item(i, 11) = row("kolom10")
                    .Item(i, 12) = row("kolom11")
                    .Item(i, 13) = row("kolom12")
                    i += 1
                Next
                .AutoSizeCols()
            End With
        End If

        'pembayaran tambahan

        If DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"select top 1 'ada' as GetValueString from tbl_wo_trn_bayar where wo_id=" & txtWoId.Text & " and deleted=0 and flag=4") = "ada" Then
            query4 = "  select
                            akum_persen as urut,6 as No, 
                            'Tanggal: '+cast(format(transfer_date,'dd/MM/yyyy') as varchar(10))+' Jam: '+cast(format(transfer_date,'hh:mm') as varchar(10)) as kolom1,
                            'Processed by: '+created_by as kolom2,
                            deskripsi as kolom3,'' as icon,'Rp' as kolom4,cast(bayar as decimal(18,0))  as kolom5,'Akumulasi Rp :' as kolom6,cast(akum_bayar as decimal(18,0)) as kolom7,'Persentase :' as kolom8,CAST(persen AS VARCHAR(3))+'%' as kolom9,'Akum Persentase :' as kolom10,CAST(akum_persen AS VARCHAR(3))+'%' as kolom11,file_pembayaran as kolom12
                            from tbl_wo_trn_bayar where wo_id=" & txtWoId.Text & " and flag=4 and deleted=0 "
        Else
            query4 = "  select 
                            1 as urut,6 as No, 
                            'Tanggal: dd/mm/yyyy'+' Jam: hh/mm' as kolom1,
                            'Processed by: ' as kolom2,
                            'Tambahan' as kolom3,'' as icon,'Rp' as kolom4,'' as kolom5,'Akumulasi Rp :' as kolom6,'' as kolom7,'Persentase :' as kolom8,'' as kolom9,'Akum Persentase :' as kolom10,'' as kolom11,'' as kolom12 "
        End If

        dt4 = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, query4)

        If dt4.Rows.Count > 0 Then
            With fg
                For Each row As DataRow In dt4.Rows
                    .AddItem(i)
                    .Item(i, 0) = row("no")
                    .Item(i, 1) = row("kolom1")
                    .Item(i, 2) = row("kolom2")
                    .Item(i, 3) = row("kolom3")
                    .Item(i, 4) = row("icon")
                    .Item(i, 5) = row("kolom4")
                    .Item(i, 6) = row("kolom5")
                    .Item(i, 7) = row("kolom6")
                    .Item(i, 8) = row("kolom7")
                    .Item(i, 9) = row("kolom8")
                    .Item(i, 10) = row("kolom9")
                    .Item(i, 11) = row("kolom10")
                    .Item(i, 12) = row("kolom11")
                    .Item(i, 13) = row("kolom12")
                    i += 1
                Next
                .AutoSizeCols()
            End With
        End If

        'barang request

        If DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"select top 1 'ada' as GetValueString from tbl_wo_trn_barang as a left join tbl_wo_trn_approval_barang as b on a.id=b.trn_barang_id where a.wo_id=" & txtWoId.Text & " and b.deleted=0 and b.flag=4") = "ada" Then
            query12 = "  SELECT 
                            1 as urut,7 as no,
                            'Progress 1' as kolom1,'' as kolom2, '' as kolom3,'' as icon, '' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'' as kolom8,'' as kolom9,'' as kolom10,'' as kolom11,'' as kolom12
                            union
                            select 
                            a.persen_request_akum as urut,7 as No, 
                            'Tanggal: '+cast(format(b.created_date,'dd/MM/yyyy') as varchar(10))+' Jam: '+cast(format(b.created_date,'hh/mm') as varchar(10)) as kolom1,
                            'Request by: '+isnull(c.NamaLengkap,b.created_by) as kolom2,
                            'Permintaan Barang ('+a.nama_barang+')' as kolom3,'' as icon,'' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'Persentase :' as kolom8,cast(a.persen_request as varchar(3))+'%' as kolom9,'Akum Persentase :' as kolom10,cast(a.persen_request_akum as varchar(3))+'%' as kolom11,'' as kolom12
                            from tbl_wo_trn_barang as a left OUTER join tbl_wo_trn_approval_barang as b on a.id=b.trn_barang_id left outer join PancangRequestUser as c on b.created_by=c.Username
                            where a.wo_id=" & txtWoId.Text & " and A.deleted=0 AND b.deleted=0 and b.flag=4 "
        Else
            query12 = "  SELECT 
                            1 as urut,7 as no,
                            'Progress 1' as kolom1,'' as kolom2, '' as kolom3,'' as icon, '' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'' as kolom8,'' as kolom9,'' as kolom10,'' as kolom11,'' as kolom12
                            union
                            select 
                            2 as urut,7 as No, 
                            'Tanggal: dd/mm/yyyy'+' Jam: hh/mm' as kolom1,
                            'Request by: ' as kolom2,
                            'Proses Request Barang Kebutuhan Proyek' as kolom3,'' as icon,'' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'Persentase :' as kolom8,'' as kolom9,'Akum Persentase :' as kolom10,'' as kolom11,'' as kolom12 "
        End If

        dt12 = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, query12)

        If dt12.Rows.Count > 0 Then
            With fg
                For Each row As DataRow In dt12.Rows
                    .AddItem(i)
                    .Item(i, 0) = row("no")
                    .Item(i, 1) = row("kolom1")
                    .Item(i, 2) = row("kolom2")
                    .Item(i, 3) = row("kolom3")
                    .Item(i, 4) = row("icon")
                    .Item(i, 5) = row("kolom4")
                    .Item(i, 6) = row("kolom5")
                    .Item(i, 7) = row("kolom6")
                    .Item(i, 8) = row("kolom7")
                    .Item(i, 9) = row("kolom8")
                    .Item(i, 10) = row("kolom9")
                    .Item(i, 11) = row("kolom10")
                    .Item(i, 12) = row("kolom11")
                    .Item(i, 13) = row("kolom12")
                    i += 1
                Next
                .AutoSizeCols()
            End With
        End If

        'spasi / baris kosong
        fg.AddItem(i)
        fg.Item(i, 0) = 7
        i += 1


        'kirim barang

        If DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"select top 1 'ada' as GetValueString from tbl_wo_trn_barang as a left join tbl_wo_trn_approval_barang as b on a.id=b.trn_barang_id where a.wo_id=" & txtWoId.Text & " and b.deleted=0 and b.flag=1") = "ada" Then
            query5 = "  select 
                            a.persen_kirim_akum as urut,7 as No, 
                            'Tanggal: '+cast(format(b.created_date,'dd/MM/yyyy') as varchar(10))+' Jam: '+cast(format(b.created_date,'hh/mm') as varchar(10)) as kolom1,
                            'Sent by: '+c.NamaLengkap as kolom2,
                            b.catatan as kolom3,'' as icon,'' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'Persentase :' as kolom8,cast(a.persen_kirim as varchar(3))+'%' as kolom9,'Akum Persentase :' as kolom10,cast(a.persen_kirim_akum as varchar(3))+'%' as kolom11,b.foto_barang as kolom12
                            from tbl_wo_trn_barang as a left join tbl_wo_trn_approval_barang as b on a.id=b.trn_barang_id left outer join PancangRequestUser as c on b.created_by=c.Username
                            where a.wo_id=" & txtWoId.Text & " and b.deleted=0 and b.flag=1 "
        Else
            query5 = "  select 
                            2 as urut,7 as No, 
                            'Tanggal: dd/mm/yyyy'+' Jam: hh/mm' as kolom1,
                            'Sent by: ' as kolom2,
                            'Proses Kirim Barang Kebutuhan Proyek' as kolom3,'' as icon,'' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'Persentase :' as kolom8,'' as kolom9,'Akum Persentase :' as kolom10,'' as kolom11,'' as kolom12 "
        End If

        dt5 = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, query5)

        If dt5.Rows.Count > 0 Then
            With fg
                For Each row As DataRow In dt5.Rows
                    .AddItem(i)
                    .Item(i, 0) = row("no")
                    .Item(i, 1) = row("kolom1")
                    .Item(i, 2) = row("kolom2")
                    .Item(i, 3) = row("kolom3")
                    .Item(i, 4) = row("icon")
                    .Item(i, 5) = row("kolom4")
                    .Item(i, 6) = row("kolom5")
                    .Item(i, 7) = row("kolom6")
                    .Item(i, 8) = row("kolom7")
                    .Item(i, 9) = row("kolom8")
                    .Item(i, 10) = row("kolom9")
                    .Item(i, 11) = row("kolom10")
                    .Item(i, 12) = row("kolom11")
                    .Item(i, 13) = row("kolom12")
                    i += 1
                Next
                .AutoSizeCols()
            End With
        End If

        'spasi / baris kosong
        fg.AddItem(i)
        fg.Item(i, 0) = 7
        i += 1

        'terima barang

        If DB.ExecuteScalarValue(Of String)(StrConnRMPApp,"select top 1 'ada' as GetValueString from tbl_wo_trn_barang as a left join tbl_wo_trn_approval_barang as b on a.id=b.trn_barang_id where a.wo_id=" & txtWoId.Text & " and b.deleted=0 and b.flag=2") = "ada" Then
            query6 = "  select 
                            a.persen_terima_akum as urut,7 as No, 
                            'Tanggal: '+cast(format(b.created_date,'dd/MM/yyyy') as varchar(10))+' Jam: '+cast(format(b.created_date,'hh/mm') as varchar(10)) as kolom1,
                            'Received by: '+c.NamaLengkap as kolom2,
                            b.catatan as kolom3,'' as icon,'' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'Persentase :' as kolom8,cast(a.persen_terima as varchar(3))+'%' as kolom9,'Akum Persentase :' as kolom10,cast(a.persen_terima_akum as varchar(3))+'%' as kolom11,b.foto_barang as kolom12
                            from tbl_wo_trn_barang as a left join tbl_wo_trn_approval_barang as b on a.id=b.trn_barang_id left outer join PancangRequestUser as c on b.created_by=c.Username
                            where a.wo_id=" & txtWoId.Text & " and b.deleted=0 and b.flag=2 "
        Else
            query6 = "  select 
                            1 as urut,7 as No, 
                            'Tanggal: dd/mm/yyyy'+' Jam: hh/mm' as kolom1,
                            'Received by: ' as kolom2,
                            'Proses terima barang di pancang' as kolom3,'' as icon,'' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'Persentase :' as kolom8,'' as kolom9,'Akum Persentase :' as kolom10,'' as kolom11,'' as kolom12 "
        End If

        dt6 = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, query6)

        If dt6.Rows.Count > 0 Then
            With fg
                For Each row As DataRow In dt6.Rows
                    .AddItem(i)
                    .Item(i, 0) = row("no")
                    .Item(i, 1) = row("kolom1")
                    .Item(i, 2) = row("kolom2")
                    .Item(i, 3) = row("kolom3")
                    .Item(i, 4) = row("icon")
                    .Item(i, 5) = row("kolom4")
                    .Item(i, 6) = row("kolom5")
                    .Item(i, 7) = row("kolom6")
                    .Item(i, 8) = row("kolom7")
                    .Item(i, 9) = row("kolom8")
                    .Item(i, 10) = row("kolom9")
                    .Item(i, 11) = row("kolom10")
                    .Item(i, 12) = row("kolom11")
                    .Item(i, 13) = row("kolom12")
                    i += 1
                Next
                .AutoSizeCols()
            End With
        End If

        'pengerjaan

        If DB.ExecuteScalarValue(Of String)(StrConnRMPApp," select top 1 'ada' as GetValueString from tbl_wo_trn_pengerjaan where wo_id=" & txtWoId.Text & " and deleted=0 ") = "ada" Then
            query7 = "  SELECT 
                            1 as urut,8 as no,
                            'Progress 2' as kolom1,'' as kolom2, '' as kolom3,'' as icon, '' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'' as kolom8,'' as kolom9,'' as kolom10,'' as kolom11,'' as kolom12
                            union
                            select 
                            akum_persen as urut,8 as No, 
                            'Tanggal: '+cast(format(a.created_date,'dd/MM/yyyy') as varchar(10))+' Jam: '+cast(format(a.created_date,'hh/mm') as varchar(10)) as kolom1,
                            'Reported by: '+b.NamaLengkap as kolom2,
                            catatan as kolom3,'' as icon,'' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'Persentase :' as kolom8,cast(a.persen as varchar(10))+'%' as kolom9,'Akum Persentase :' as kolom10,cast(a.akum_persen as varchar(10))+'%' as kolom11,'' as kolom12
                            from tbl_wo_trn_pengerjaan as a left outer join PancangRequestUser as b on a.created_by=b.Username
                            where a.wo_id=" & txtWoId.Text & " and deleted=0 "
        Else
            query7 = " SELECT 
                            1 as urut,8 as no,
                            'Progress 2' as kolom1,'' as kolom2, '' as kolom3,'' as icon, '' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'' as kolom8,'' as kolom9,'' as kolom10,'' as kolom11,'' as kolom12
                            union
                            select 
                            2 as urut,8 as No, 
                            'Tanggal: dd/mm/yyyy'+' Jam: hh/mm' as kolom1,
                            'Reported by: ' as kolom2,
                            'Proses Pengerjaan Proyek' as kolom3,'' as icon,'' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'Persentase :' as kolom8,'' as kolom9,'Akum Persentase :' as kolom10,'' as kolom11,'' as kolom12"
        End If

        dt7 = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, query7)

        If dt7.Rows.Count > 0 Then
            With fg
                For Each row As DataRow In dt7.Rows
                    .AddItem(i)
                    .Item(i, 0) = row("no")
                    .Item(i, 1) = row("kolom1")
                    .Item(i, 2) = row("kolom2")
                    .Item(i, 3) = row("kolom3")
                    .Item(i, 4) = row("icon")
                    .Item(i, 5) = row("kolom4")
                    .Item(i, 6) = row("kolom5")
                    .Item(i, 7) = row("kolom6")
                    .Item(i, 8) = row("kolom7")
                    .Item(i, 9) = row("kolom8")
                    .Item(i, 10) = row("kolom9")
                    .Item(i, 11) = row("kolom10")
                    .Item(i, 12) = row("kolom11")
                    .Item(i, 13) = row("kolom12")
                    i += 1
                Next
                .AutoSizeCols()
            End With
        End If

        'inspection 

        query8 = "  declare @id as int =" & txtWoId.Text & "
                        SELECT 
                        1 as urut,9 as no,
                        'Progress 3' as kolom1,'' as kolom2, '' as kolom3,'' as icon, '' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'' as kolom8,'' as kolom9,'' as kolom10,'' as kolom11,'' as kolom12
                        union
                        SELECT 
                        2 as urut,9 as No,
                        'Tanggal: '+ISNULL(cast((select top 1 FORMAT(b.created_date,'dd/MM/yyyy') from tbl_wo_trn_hdr as a left outer join tbl_wo_trn_file_wo as b on a.id=b.wo_id where a.file_pemeriksaan is not null and b.flag=4 and a.id=@id ) as varchar(10)),'dd/mm/yyyy')+' Jam: '+ISNULL(cast((select top 1 FORMAT(b.created_date,'hh:mm') from tbl_wo_trn_hdr as a left outer join tbl_wo_trn_file_wo as b on a.id=b.wo_id where a.file_pemeriksaan is not null and b.flag=4 and a.id=@id) as varchar(10)),'hh/mm') as kolom1,
                        'Reported by: '+ISNULL((select top 1 b.created_by from tbl_wo_trn_hdr as a left outer join tbl_wo_trn_file_wo as b on a.id=b.wo_id where a.file_pemeriksaan is not null and b.flag=4 and a.id=@id),'') as kolom2,
                        'Inspection Report (Close inspection dengan upload hasil inspeksi jika tidak ada temuan)' as kolom3,'' as icon, 
                        '' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'' as kolom8,'' as kolom9,'' as kolom10,'' as kolom11,
                        ISNULL((select top 1 b.file_name from tbl_wo_trn_hdr as a left outer join tbl_wo_trn_file_wo as b on a.id=b.wo_id where a.file_pemeriksaan is not null and b.flag=4 and a.id=@id),'') as kolom12"

        dt8 = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, query8)

        If dt8.Rows.Count > 0 Then
            With fg
                For Each row As DataRow In dt8.Rows
                    .AddItem(i)
                    .Item(i, 0) = row("no")
                    .Item(i, 1) = row("kolom1")
                    .Item(i, 2) = row("kolom2")
                    .Item(i, 3) = row("kolom3")
                    .Item(i, 4) = row("icon")
                    .Item(i, 5) = row("kolom4")
                    .Item(i, 6) = row("kolom5")
                    .Item(i, 7) = row("kolom6")
                    .Item(i, 8) = row("kolom7")
                    .Item(i, 9) = row("kolom8")
                    .Item(i, 10) = row("kolom9")
                    .Item(i, 11) = row("kolom10")
                    .Item(i, 12) = row("kolom11")
                    .Item(i, 13) = row("kolom12")
                    i += 1
                Next
                .AutoSizeCols()
            End With
        End If


        'temuan

        If DB.ExecuteScalarValue(Of String)(StrConnRMPApp," select top 1 'ada' as GetValueString from tbl_wo_trn_pemeriksaan  where deleted=0 and wo_id=" & txtWoId.Text & " ") = "ada" Then
            query9 = "  SELECT 
                        a.id as urut,9 as No,
                        'Tanggal: '+cast(FORMAT(a.created_date,'dd/MM/yyyy') as varchar(10))+' Jam: '+cast(FORMAT(a.created_date,'hh:mm') as varchar(10))  as kolom1,
                        'Inspected by: '+b.NamaLengkap as kolom2, 
                        a.temuan_desc as kolom3,'' as icon, 
                        '' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'' as kolom8,'' as kolom9,'' as kolom10,'' as kolom11,
                        a.foto_temuan as kolom12
                        from tbl_wo_trn_pemeriksaan as a left outer join 
                        PancangRequestUser as b on a.created_by=b.Username 
                        where deleted=0 and wo_id=" & txtWoId.Text & " "
        Else
            query9 = "  SELECT 
                        1 as urut,9 as No,
                        'Tanggal: dd/mm/yyyy'+' Jam: hh:mm' as kolom1,
                        'Inspected by: ' as kolom2, 
                        'temuan ketidaksesuaian perbaikan / intruksi perbaikan (jika ada)' as kolom3,'' as icon,
                        '' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'' as kolom8,'' as kolom9,'' as kolom10,'' as kolom11,'' as kolom12 "
        End If

        dt9 = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, query9)

        If dt9.Rows.Count > 0 Then
            With fg
                For Each row As DataRow In dt9.Rows
                    .AddItem(i)
                    .Item(i, 0) = row("no")
                    .Item(i, 1) = row("kolom1")
                    .Item(i, 2) = row("kolom2")
                    .Item(i, 3) = row("kolom3")
                    .Item(i, 4) = row("icon")
                    .Item(i, 5) = row("kolom4")
                    .Item(i, 6) = row("kolom5")
                    .Item(i, 7) = row("kolom6")
                    .Item(i, 8) = row("kolom7")
                    .Item(i, 9) = row("kolom8")
                    .Item(i, 10) = row("kolom9")
                    .Item(i, 11) = row("kolom10")
                    .Item(i, 12) = row("kolom11")
                    .Item(i, 13) = row("kolom12")
                    i += 1
                Next
                .AutoSizeCols()
            End With
        End If


        'perbaikan

        If DB.ExecuteScalarValue(Of String)(StrConnRMPApp," select top 1 'ada' as GetValueString from tbl_wo_trn_pemeriksaan  where deleted=0 and foto_perbaikan is not null and wo_id=" & txtWoId.Text & " ") = "ada" Then
            query10 = "  SELECT 
                        a.id as urut,9 as No,
                        'Tanggal: '+cast(FORMAT(a.created_date,'dd/MM/yyyy') as varchar(10))+' Jam: '+cast(FORMAT(a.created_date,'hh:mm') as varchar(10))  as kolom1,
                        'Repaired by: '+b.NamaLengkap as kolom2, 
                        a.perbaikan_desc as kolom3,'' as icon, 
                        '' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'' as kolom8,'' as kolom9,'' as kolom10,'' as kolom11,
                        a.foto_perbaikan as kolom12
                        from tbl_wo_trn_pemeriksaan as a left outer join 
                        PancangRequestUser as b on a.created_by=b.Username 
                        where deleted=0 and a.foto_perbaikan is not null and wo_id=" & txtWoId.Text & " "
        Else
            query10 = "  SELECT 
                        1 as urut,9 as No,
                        'Tanggal: dd/mm/yyyy'+' Jam: hh:mm' as kolom1,
                        'Repaired by: ' as kolom2, 
                        'perbaikan dari temuan inspeksi' as kolom3,'' as icon,
                        '' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'' as kolom8,'' as kolom9,'' as kolom10,'' as kolom11,'' as kolom12 "
        End If

        dt10 = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, query10)

        If dt10.Rows.Count > 0 Then
            With fg
                For Each row As DataRow In dt10.Rows
                    .AddItem(i)
                    .Item(i, 0) = row("no")
                    .Item(i, 1) = row("kolom1")
                    .Item(i, 2) = row("kolom2")
                    .Item(i, 3) = row("kolom3")
                    .Item(i, 4) = row("icon")
                    .Item(i, 5) = row("kolom4")
                    .Item(i, 6) = row("kolom5")
                    .Item(i, 7) = row("kolom6")
                    .Item(i, 8) = row("kolom7")
                    .Item(i, 9) = row("kolom8")
                    .Item(i, 10) = row("kolom9")
                    .Item(i, 11) = row("kolom10")
                    .Item(i, 12) = row("kolom11")
                    .Item(i, 13) = row("kolom12")
                    i += 1
                Next
                .AutoSizeCols()
            End With
        End If

        'close  wo

        query11 = "  declare @id as int =" & txtWoId.Text & "
                        --10
                        SELECT 
                        1 as urut,10 as No,
                        'Close WO' as kolom1,'' as kolom2, '' as kolom3,'' as icon, '' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'' as kolom8,'' as kolom9,'' as kolom10,'' as kolom11,'' as kolom12
                        union
                        SELECT 
                        2 as urut,10 as No,
                        'Tanggal: '+ISNULL(cast((select top 1 FORMAT(b.created_date,'dd/MM/yyyy') from tbl_wo_trn_hdr as a left outer join tbl_wo_trn_file_wo as b on a.id=b.wo_id where a.file_ba is not null and b.flag=5 and a.id=@id ) as varchar(10)),'dd/mm/yyyy')+' Jam: '+ISNULL(cast((select top 1 FORMAT(b.created_date,'hh:mm') from tbl_wo_trn_hdr as a left outer join tbl_wo_trn_file_wo as b on a.id=b.wo_id where a.file_ba is not null and b.flag=5 and a.id=@id) as varchar(10)),'hh/mm') as kolom1,
                        'Processed by: '+ISNULL((select top 1 b.created_by from tbl_wo_trn_hdr as a left outer join tbl_wo_trn_file_wo as b on a.id=b.wo_id where a.file_ba is not null and b.flag=5 and a.id=@id),'') as kolom2,
                        'Berita Acara Serah Terima' as kolom3,'' as icon, 
                        '' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'' as kolom8,'' as kolom9,'' as kolom10,'' as kolom11,
                        ISNULL((select top 1 b.file_name from tbl_wo_trn_hdr as a left outer join tbl_wo_trn_file_wo as b on a.id=b.wo_id where a.file_ba is not null and b.flag=5 and a.id=@id),'') as kolom12
                        union
                        SELECT 
                        3 as urut,10 as No,
                        'Tanggal: '+ISNULL(cast((select top 1 FORMAT(created_date,'dd/MM/yyyy') from tbl_wo_trn_bayar where flag=3 and deleted=0 and wo_id=@id) as varchar(10)),'dd/mm/yyyy')+' Jam: '+ISNULL(cast((select top 1 FORMAT(created_date,'hh/mm') from tbl_wo_trn_bayar where flag=3 and deleted=0 and wo_id=@id) as varchar(10)),'hh/mm') as kolom1,
                        'Processed by: '+ISNULL((select top 1 created_by from tbl_wo_trn_bayar where flag=3 and deleted=0 and wo_id=@id),'') as kolom2, 
                        'Pelunasan balik ke proses 3' as kolom3,'' as icon, 
                        '' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'' as kolom8,'' as kolom9,'' as kolom10,'' as kolom11,'' as kolom12 
                        union
                        SELECT 
                        4 as urut,10 as no,
                        'Tanggal: '+ISNULL(cast((select top 1 FORMAT(created_date,'dd/MM/yyyy') from tbl_wo_trn_approval_wo where flag=5 and wo_id=@id) as varchar(10)),'dd/mm/yyyy')+' Jam: '+ISNULL(cast((select top 1 FORMAT(created_date,'hh:mm') from tbl_wo_trn_approval_wo where flag=5 and wo_id=@id) as varchar(10)),'hh/mm') as kolom1,
                        'Processed by: '+ISNULL((select top 1 isnull(b.namalengkap,a.created_by) from tbl_wo_trn_approval_wo as a left outer join PancangRequestUser as b on a.created_by=b.Username where a.flag=5 and a.wo_id=@id),'') as kolom2, 
                        (select top 1 catatan from tbl_wo_trn_approval_wo where flag=5 and wo_id=@id) as kolom3,'' as icon,
                        '' as kolom4,'' as kolom5,'' as kolom6,'' as kolom7,'' as kolom8,'' as kolom9,'' as kolom10,'' as kolom11,'' as kolom12"

        dt11 = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, query11)

        If dt11.Rows.Count > 0 Then
            With fg
                For Each row As DataRow In dt11.Rows
                    .AddItem(i)
                    .Item(i, 0) = row("no")
                    .Item(i, 1) = row("kolom1")
                    .Item(i, 2) = row("kolom2")
                    .Item(i, 3) = row("kolom3")
                    .Item(i, 4) = row("icon")
                    .Item(i, 5) = row("kolom4")
                    .Item(i, 6) = row("kolom5")
                    .Item(i, 7) = row("kolom6")
                    .Item(i, 8) = row("kolom7")
                    .Item(i, 9) = row("kolom8")
                    .Item(i, 10) = row("kolom9")
                    .Item(i, 11) = row("kolom10")
                    .Item(i, 12) = row("kolom11")
                    .Item(i, 13) = row("kolom12")
                    i += 1
                Next
                .AutoSizeCols()
            End With
        End If

        'kasih icon buat baris yang ada gambar atau file
        With fg
            For i = 1 To .Rows.Count - 1
                If .Item(i, 13) <> Nothing Then
                    If Modul_RMP.Func.GetFileExtension(.Item(i, 13)).ToUpper = "PDF" Then
                        Dim style As C1.Win.C1FlexGrid.CellStyle = .Styles.Add("style")
                        style.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
                        .SetCellImage(i, 4, My.Resources.ButtonPdf)
                        .SetCellStyle(i, 4, style)
                    ElseIf Modul_RMP.Func.GetFileExtension(.Item(i, 13)).ToUpper = "JPG" Then
                        Dim style As C1.Win.C1FlexGrid.CellStyle = .Styles.Add("style")
                        style.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
                        .SetCellImage(i, 4, My.Resources.icon_foto_16px)
                        .SetCellStyle(i, 4, style)
                    End If
                End If
            Next
        End With

        'mewarnai abu - abu jika belum ada inputan
        For i = 1 To fg.Rows.Count - 1
            If fg.Item(i, 2) <> "" And (fg.Item(i, 2) = "Input By: " Or fg.Item(i, 2) = "Approved by: " Or fg.Item(i, 2) = "Processed by: " Or fg.Item(i, 2) = "Sent by: " Or fg.Item(i, 2) = "Received by: " Or fg.Item(i, 2) = "Inspected by: " Or fg.Item(i, 2) = "Repaired by: " Or fg.Item(i, 2) = "Reported by: " Or fg.Item(i, 2) = "Request by: ") Then
                fg.Rows(i).StyleNew.ForeColor = Color.Gray
            End If
            If fg.Item(i, 2) = "" Then
                fg.Rows(i).StyleNew.Font = New Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
            End If
        Next

    End Sub



    Private Sub HeaderFg()
        Dim TXT As CellRange
        With fg
            .Rows.Fixed = 1
            .Cols.Fixed = 1
            .Rows.Count = 1
            .Cols.Count = 14

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

            TXT = .GetCellRange(0, 0, 0, 0) : TXT.Data = "No" : .Cols(0).TextAlign = TextAlignEnum.LeftCenter : .Cols(0).AllowEditing = False : .Cols(0).AllowMerging = True
            TXT = .GetCellRange(0, 1, 0, 1) : TXT.Data = "Tanggal / Jam" : .Cols(1).TextAlign = TextAlignEnum.LeftCenter : .Cols(1).AllowEditing = False
            TXT = .GetCellRange(0, 2, 0, 2) : TXT.Data = "PIC" : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).AllowEditing = False
            TXT = .GetCellRange(0, 3, 0, 3) : TXT.Data = "KETERANGAN" : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).AllowEditing = False
            TXT = .GetCellRange(0, 4, 0, 4) : TXT.Data = "KETERANGAN" : .Cols(4).TextAlign = TextAlignEnum.LeftCenter : .Cols(4).AllowEditing = False
            TXT = .GetCellRange(0, 5, 0, 5) : TXT.Data = "KETERANGAN" : .Cols(5).TextAlign = TextAlignEnum.RightCenter : .Cols(5).AllowEditing = False : .Cols(5).Format = "#,###0"
            TXT = .GetCellRange(0, 6, 0, 6) : TXT.Data = "KETERANGAN" : .Cols(6).TextAlign = TextAlignEnum.LeftCenter : .Cols(6).AllowEditing = False
            TXT = .GetCellRange(0, 7, 0, 7) : TXT.Data = "KETERANGAN" : .Cols(7).TextAlign = TextAlignEnum.RightCenter : .Cols(7).AllowEditing = False : .Cols(7).Format = "#,###0"
            TXT = .GetCellRange(0, 8, 0, 8) : TXT.Data = "KETERANGAN" : .Cols(8).TextAlign = TextAlignEnum.LeftCenter : .Cols(8).AllowEditing = False
            TXT = .GetCellRange(0, 9, 0, 9) : TXT.Data = "KETERANGAN" : .Cols(9).TextAlign = TextAlignEnum.LeftCenter : .Cols(9).AllowEditing = False
            TXT = .GetCellRange(0, 10, 0, 10) : TXT.Data = "KETERANGAN" : .Cols(10).TextAlign = TextAlignEnum.LeftCenter : .Cols(10).AllowEditing = False
            TXT = .GetCellRange(0, 11, 0, 11) : TXT.Data = "KETERANGAN" : .Cols(11).TextAlign = TextAlignEnum.LeftCenter : .Cols(11).AllowEditing = False
            TXT = .GetCellRange(0, 12, 0, 12) : TXT.Data = "KETERANGAN" : .Cols(12).TextAlign = TextAlignEnum.LeftCenter : .Cols(12).AllowEditing = False
            TXT = .GetCellRange(0, 13, 0, 13) : TXT.Data = "KETERANGAN" : .Cols(13).Visible = False

            .AutoSizeCols()
        End With
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint
        Try
            Dim topColor As Color = Color.FromArgb(0, 172, 251) ' Warna atas yang tebal
            Dim bottomColor As Color = Color.FromArgb(0, 0, 255, 255) ' Warna bawah yang pudar

            Dim gradientRect As New Rectangle(0, 0, Panel3.Width, Panel3.Height)

            Using brush As New Drawing2D.LinearGradientBrush(gradientRect, topColor, bottomColor, Drawing2D.LinearGradientMode.Vertical)
                e.Graphics.FillRectangle(brush, gradientRect)
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fg_DoubleClick(sender As Object, e As EventArgs) Handles fg.DoubleClick
        With fg
            If .Item(.RowSel, 13) <> Nothing Then
                If .Col = 4 Then
                    If Modul_RMP.Func.GetFileExtension(.Item(.RowSel, 13)).ToUpper = "PDF" Then
                        If File.Exists(UrlNotaPancang & "DocumentWorkOrder\" & .Item(.RowSel, 13)) Then
                            Try
                                Process.Start(UrlNotaPancang & "DocumentWorkOrder\" & .Item(.RowSel, 13))
                            Catch ex As Exception
                                'MessageBox.Show(ex.Message, "File Tidak Ditemukan Pilih File terlebih dahulu", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End Try
                        End If
                    ElseIf Modul_RMP.Func.GetFileExtension(.Item(.RowSel, 13)).ToUpper = "JPG" Then
                        If Application.OpenForms.OfType(Of FrmRptViewFoto)().Any() Then
                            Dim FrmViewFoto As FrmRptViewFoto = Application.OpenForms.OfType(Of FrmRptViewFoto)().FirstOrDefault()
                            FrmViewFoto.Close()
                        End If

                        If File.Exists(UrlNotaPancang & "ImagesBarangWorkOrder\" & .Item(.RowSel, 13)) Then
                            With FrmRptViewFoto
                                .formName = "FrmMonWoPancangDtl"
                                .FileName = fg.Item(fg.RowSel, 13)
                                .Show()
                            End With
                        ElseIf File.Exists(UrlNotaPancang & "ImagesPemeriksaanWorkOrder\" & .Item(.RowSel, 13)) Then
                            With FrmRptViewFoto
                                .formName = "FrmMonWoPancangDtl_temuan"
                                .FileName = fg.Item(fg.RowSel, 13)
                                .Show()
                            End With
                        End If
                    End If
                End If
            End If
        End With
    End Sub


End Class