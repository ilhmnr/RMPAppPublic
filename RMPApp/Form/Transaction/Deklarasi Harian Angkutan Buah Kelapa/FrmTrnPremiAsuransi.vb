Imports System.Data.SqlClient
Imports System.IO
Imports System.Data
Imports System.ComponentModel
Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Globalization

Public Class FrmTrnPremiAsuransi
    Public AT As String = "RMPApplication ©" & Format(Year(Now))
    Dim Conn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim Kode As String
    Dim str As String
    
    Public perintah As String
    Dim NoTransUpahBongkar_ As String
    Dim NoInvoice_ As String

    ' Warna kuning cerah untuk kolom yang boleh diedit (ganti ke Color.Yellow kalau mau lebih terang)
    Private ReadOnly WarnaKuningEdit As Color = Color.FromArgb(255, 255, 153)

    Private Sub FrmTrnPremiAsuransi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each col As DataGridViewColumn In dgvList.Columns
            If col.ReadOnly = False Then
                col.DefaultCellStyle.BackColor = Color.LightYellow
            End If
        Next

        dtp1.Value = Format(Now, "dd/MM/yy")
        dtp2.Value = Format(Now, "dd/MM/yy")
        dtpInvoice.Value = Format(Now, "dd/MM/yy")
        'enableds(False)
        btnexit.Enabled = True
    End Sub

    ''' <summary>
    ''' Mewarnai cell yang boleh diedit dengan warna kuning cerah.
    ''' Diwarnai di level CELL (prioritas tertinggi) agar tidak tertimpa
    ''' RowsDefaultCellStyle / AlternatingRowsDefaultCellStyle.
    ''' Baris Total otomatis dilewati karena cell-nya sudah ReadOnly = True.
    ''' </summary>
    Private Sub WarnaiKolomEdit()
        For i As Integer = 0 To dgvList.RowCount - 1
            For Each col As DataGridViewColumn In dgvList.Columns
                Dim cell = dgvList.Rows(i).Cells(col.Index)
                If Not cell.ReadOnly Then
                    cell.Style.BackColor = WarnaKuningEdit
                End If
            Next
        Next
    End Sub

    Private Sub loaddata()
        Try
            Dim SQL As String, i As Integer
            Dim COUNTKAPAL As Integer
            COUNTKAPAL = 0

            'If rdkrg500.Checked = True Then
            '    If dtp1.Value < "2022-01-01" Then
            '        SQL = " with  tblklp as ( " &
            '          " select sum(nettoakhir) as  muatan,sum(totalharga) as totalharga, trip, idpancang, idkapal from [192.168.12.5].[RMPApp].[dbo].TblTrnKelapaHdr " &
            '          " where (deleted=0 or deleted is null) and KODEBAHANBAKU=1  and IDPancang <>'8' and flaginvoicemuat =0  " &
            '          " group by trip,idpancang, idkapal )  SELECT IDBooking,NamaKapal,a.IDPancang,a.IDKapal,A.TripID,A.Tujuan,A.Pancang, klp.totalharga/klp.muatan  AS Rupiah,  CAST(A.BerangkatDate AS DATE) AS Tgl, " &
            '          " klp.muatan AS muatan,  CAST(BerangkatDate AS DATE) as tanggalberangkat,klp.totalharga as totalharga, " &
            '          " (select top(1) RATEMIN30 from RMPAPP..tbl_Mst_Rate_Premi where cast(TANGGAL as date) <= CAST(A.BerangkatDate AS DATE) order by tanggal desc) RATEMIN,    " &
            '          " (select top(1) RATEPLUS30 from RMPAPP..tbl_Mst_Rate_Premi where cast(TANGGAL as date) <= CAST(A.BerangkatDate AS DATE) order by tanggal desc) RATEPLUS,  " &
            '          " convert(varchar(10),A.BerangkatDate,103) +' ' + LEFT(cast(convert(time,A.BerangkatDate) as varchar(20)),5) AS jamberangkat " &
            '          " FROM  [192.168.12.5].[RMPApp].[dbo].[vwTripBookingMuatPancang] AS A LEFT JOIN   [192.168.12.5].[RMPApp].[dbo].[tblMstKapal] " &
            '          " AS B ON A.IDKapal = B.KapalID   inner join " &
            '          " tblklp as klp on a.IDKapal=klp.IDKapal and a.IDPancang=klp.IDPancang and a.TripID=klp.Trip  " &
            '          " WHERE ISNULL(B.TahunKapal,0)>0  AND  AND klp.totalharga<500000000   DATEDIFF(year, CAST(CAST(B.TahunKapal AS VARCHAR(4))+'-01-01'  AS DATE),GETDATE())  <= 15  AND  a.JenisMuat in ('KB-A','KB-B') and  a.flaginvoicemuat =0  and  CAST(BerangkatDate AS DATE) between  '" & Format(dtp1.Value, "yyyy-MM-dd") & "' and '" & Format(dtp2.Value, "yyyy-MM-dd") & "'  order by  CAST(BerangkatDate AS DATE),namakapal asc"
            '    Else
            SQL = "exec spTrnPremiAsuransi '" & Format(dtp1.Value, "yyyy-MM-dd") & "','" & Format(dtp2.Value, "yyyy-MM-dd") & "'"

            '    End If
            'End If

            'If rdlbh500.Checked = True Then
            '    If dtp1.Value < "2022-01-01" Then
            '        SQL = " with  tblklp as ( " &
            '          " select sum(nettoakhir) as  muatan,sum(totalharga) as totalharga, trip, idpancang, idkapal from [192.168.12.5].[RMPApp].[dbo].TblTrnKelapaHdr " &
            '          " where (deleted=0 or deleted is null) and KODEBAHANBAKU=1  and IDPancang <>'8' and flaginvoicemuat =0  " &
            '          " group by trip,idpancang, idkapal )  SELECT IDBooking,NamaKapal,a.IDPancang,a.IDKapal,A.TripID,A.Tujuan,A.Pancang, klp.totalharga/klp.muatan  AS Rupiah,  CAST(A.BerangkatDate AS DATE) AS Tgl, " &
            '          " klp.muatan AS muatan,  CAST(BerangkatDate AS DATE) as tanggalberangkat,klp.totalharga as totalharga, " &
            '          " (select top(1) RATEMIN30LBH500 from RMPAPP..tbl_Mst_Rate_Premi where cast(TANGGAL as date) <= CAST(A.BerangkatDate AS DATE) order by tanggal desc) RATEMIN,    " &
            '          " (select top(1) RATEPLUS30LBH500 from RMPAPP..tbl_Mst_Rate_Premi where cast(TANGGAL as date) <= CAST(A.BerangkatDate AS DATE) order by tanggal desc) RATEPLUS,  " &
            '          " convert(varchar(10),A.BerangkatDate,103) +' ' + LEFT(cast(convert(time,A.BerangkatDate) as varchar(20)),5) AS jamberangkat " &
            '          " FROM  [192.168.12.5].[RMPApp].[dbo].[vwTripBookingMuatPancang] AS A LEFT JOIN   [192.168.12.5].[RMPApp].[dbo].[tblMstKapal] " &
            '          " AS B ON A.IDKapal = B.KapalID   inner join " &
            '          " tblklp as klp on a.IDKapal=klp.IDKapal and a.IDPancang=klp.IDPancang and a.TripID=klp.Trip  " &
            '          " WHERE ISNULL(B.TahunKapal,0)>0  AND  AND klp.totalharga>=500000000   DATEDIFF(year, CAST(CAST(B.TahunKapal AS VARCHAR(4))+'-01-01'  AS DATE),GETDATE())  <= 15  AND  a.JenisMuat in ('KB-A','KB-B') and  a.flaginvoicemuat =0  and  CAST(BerangkatDate AS DATE) between  '" & Format(dtp1.Value, "yyyy-MM-dd") & "' and '" & Format(dtp2.Value, "yyyy-MM-dd") & "'  order by  CAST(BerangkatDate AS DATE),namakapal asc"
            '    Else
            '        SQL = " with  tblklp as ( " &
            '          " select sum(nettoakhir) as  muatan,sum(totalharga) as totalharga, trip, idpancang, idkapal from [192.168.12.5].[RMPApp].[dbo].TblTrnKelapaHdr " &
            '          " where (deleted=0 or deleted is null) and KODEBAHANBAKU=1 and IDPancang <>'8' and flaginvoicemuat =0 " &
            '          " group by trip,idpancang, idkapal )  SELECT IDBooking,NamaKapal,a.IDPancang,a.IDKapal,A.TripID,A.Tujuan,A.Pancang, klp.totalharga/klp.muatan  AS Rupiah,  CAST(A.BerangkatDate AS DATE) AS Tgl, " &
            '          " klp.muatan AS muatan,  CAST(BerangkatDate AS DATE) as tanggalberangkat,500000000 as totalharga, " &
            '          " (select top(1) RATEMIN30LBH500 from RMPAPP..tbl_Mst_Rate_Premi where cast(TANGGAL as date) <= CAST(A.BerangkatDate AS DATE) order by tanggal desc) RATEMIN,    " &
            '          " (select top(1) RATEPLUS30LBH500 from RMPAPP..tbl_Mst_Rate_Premi where cast(TANGGAL as date) <= CAST(A.BerangkatDate AS DATE) order by tanggal desc) RATEPLUS,  " &
            '          " convert(varchar(10),A.BerangkatDate,103) +' ' + LEFT(cast(convert(time,A.BerangkatDate) as varchar(20)),5) AS jamberangkat " &
            '          " FROM  [192.168.12.5].[RMPApp].[dbo].[vwTripBookingMuatPancang] AS A LEFT JOIN   [192.168.12.5].[RMPApp].[dbo].[tblMstKapal] " &
            '          " AS B ON A.IDKapal = B.KapalID     inner join " &
            '          " tblklp as klp on a.IDKapal=klp.IDKapal and a.IDPancang=klp.IDPancang and a.TripID=klp.Trip  " &
            '          " WHERE  ISNULL(B.TahunKapal,0)>0 AND klp.totalharga>=500000000  AND    DATEDIFF(year, CAST(CAST(B.TahunKapal AS VARCHAR(4))+'-01-01'  AS DATE),GETDATE()) <= 15  AND    a.JenisMuat in ('KB-A','KB-B') and a.flaginvoicemuat =0  and  CAST(BerangkatDate AS DATE) between  '" & Format(dtp1.Value, "yyyy-MM-dd") & "' and '" & Format(dtp2.Value, "yyyy-MM-dd") & "'  order by  CAST(BerangkatDate AS DATE),namakapal asc"

            '    End If
            'End If


            Using koneksi As New SqlCommand(SQL, DB.OpenConnection(StrConnRMPApp))
                Using DR = koneksi.ExecuteReader()
                    If DR.HasRows Then
                        dgvList.Rows.Clear()

                        While DR.Read
                            With dgvList
                                .Rows.Add()
                                COUNTKAPAL = COUNTKAPAL + 1
                                .Item("no", i).Value = i + 1
                                .Item("IDKapal", i).Value = DR!IDKapal
                                .Item("Trip", i).Value = DR!Tripid
                                .Item("IDPancang", i).Value = DR!IDPancang
                                .Item("NamaKapal", i).Value = DR!NamaKapal
                                .Item("Muatan", i).Value = DR!muatan
                                .Item("totalharga", i).Value = DR!totalharga
                                .Item("Rp", i).Value = DR!Rupiah
                                .Item("RpKBB", i).Value = DR!harga_kb_b
                                .Item("jamberangkat", i).Value = DR!jamberangkat
                                .Item("TglBerangkat", i).Value = DR!Tgl
                                .Item("Pancang", i).Value = Replace(DR!Pancang, "PANCANG SIMBAR - ABU", "PANCANG SIMBAR")
                                .Item("Tujuan", i).Value = DR!Tujuan
                                .Item("LuasJaminan", i).Value = "ICC C"
                                .Item("RATEPLUS", i).Value = DR!RATEPLUS
                                .Item("RATEMIN", i).Value = DR!RATEMIN
                                .Item("IDBooking", i).Value = DR!IDBooking
                                With Me.dgvList
                                    .RowsDefaultCellStyle.BackColor = Color.White
                                    .AlternatingRowsDefaultCellStyle.BackColor = Color.Azure
                                    .Rows(i).Cells("No").Style.BackColor = Color.FromArgb(240, 240, 240)
                                End With
                            End With
                            i += 1
                        End While


                        With dgvList
                            For i = 0 To .RowCount - 1
                                If COUNTKAPAL <= 30 Then
                                    .Item("RATE", i).Value = .Item("RATEMIN", i).Value
                                Else
                                    If COUNTKAPAL > 30 Then
                                        .Item("RATE", i).Value = .Item("RATEPLUS", i).Value
                                    End If
                                End If
                                .Item("Premi", i).Value = .Item("totalharga", i).Value * .Item("RATE", i).Value / 100
                            Next
                        End With


                        dgvList.Rows.Add()
                        Call sumpremi()
                        Call WarnaiKolomEdit()
                    Else
                        dgvList.Rows.Clear()
                        MsgBox("Data Tidak ditemukan ! ", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    DR.Close()
                End Using


            End Using
            DB.CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Sub sumpremi()

        Try
            Dim Totalmuatan As Double = 0
            Dim maxpremi As Double = 0
            Dim max As Double = 0
            Dim TotalpremiKapal As Double = 0

            For i = 0 To dgvList.RowCount - 2
                Totalmuatan += (If(Val(dgvList.Rows(i).Cells("muatan").Value()) = 0, 0, Convert.ToDouble(dgvList.Rows(i).Cells("muatan").Value())))
                If maxpremi < dgvList.Item("Premi", i).Value Then
                    maxpremi = dgvList.Item("Premi", i).Value
                End If
            Next

            dgvList.Rows(dgvList.RowCount - 1).Cells(0).Value = "Total"


            For i = 0 To dgvList.RowCount - 2
                If dtpInvoice.Value < "2023-10-01" Then
                    dgvList.Item("PremiKapal", i).Value = Math.Round(dgvList.Item("muatan", i).Value / Totalmuatan * maxpremi, 0)
                Else
                    dgvList.Item("PremiKapal", i).Value = dgvList.Item("Premi", i).Value
                End If
            Next


            For i = 0 To dgvList.RowCount - 2
                TotalpremiKapal += (If(Val(dgvList.Rows(i).Cells("PremiKapal").Value()) = 0, 0, Math.Round((dgvList.Rows(i).Cells("PremiKapal").Value()), 0)))
            Next

            dgvList.Rows(dgvList.RowCount - 1).Cells("muatan").Value() = Totalmuatan
            dgvList.Rows(dgvList.RowCount - 1).Cells("Premi").Value() = TotalpremiKapal
            dgvList.Rows(dgvList.RowCount - 1).Cells("PremiKapal").Value = TotalpremiKapal

            Dim red As Integer
            For red = 0 To dgvList.ColumnCount - 1
                dgvList.Rows(dgvList.RowCount - 1).Cells(red).Style.BackColor = Color.FromArgb(110, 160, 244)
                If dgvList.Rows(dgvList.RowCount - 1).Cells(red).Style.BackColor = Color.FromArgb(110, 160, 244) Then
                    dgvList.Rows(dgvList.RowCount - 1).Cells(red).Style.ForeColor = Color.White
                End If
                dgvList.Rows(dgvList.RowCount - 1).Cells(red).ReadOnly = True
            Next red
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Total", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Default
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub loaddataFind(noinvoice As String)
        Try
            Dim SQL As String, i As Integer
            Dim sql2 As String = ""
            SQL = " select * from vw_RM_TrnAngkutanBuahKapalDtl WHERE NOINVOICE = '" & noinvoice & "' "

            Using koneksi As New SqlCommand(SQL, DB.OpenConnection(StrConnRMPApp))
                Using DR = koneksi.ExecuteReader()
                    If DR.HasRows Then
                        dgvList.Rows.Clear()
                        'dgvList.RowCount = 0
                        While DR.Read

                            With dgvList
                                .Rows.Add()
                                txtinvoice.Text = DR!noinvoice
                                dtp1.Value = DR!periodetgl
                                dtp2.Value = DR!periodetgl2
                                dtpInvoice.Value = DR!tglinvoice
                                .Item("no", i).Value = i + 1
                                .Item("IDKapal", i).Value = DR!IDKapal
                                .Item("Rate", i).Value = DR!Rate
                                .Item("Trip", i).Value = DR!Trip
                                .Item("IDPancang", i).Value = DR!IDPancang
                                .Item("NamaKapal", i).Value = DR!NamaKapal
                                .Item("Muatan", i).Value = DR!muatan
                                .Item("totalharga", i).Value = DR!totalharga
                                .Item("Rp", i).Value = DR!Rp
                                .Item("RpKBB", i).Value = DR!RpKBB
                                .Item("jamberangkat", i).Value = DR!jamberangkat
                                .Item("TglBerangkat", i).Value = DR!TglBerangkat
                                .Item("Pancang", i).Value = Replace(DR!Pancang, "PANCANG SIMBAR - ABU", "PANCANG SIMBAR")
                                .Item("Tujuan", i).Value = DR!Tujuan
                                .Item("LuasJaminan", i).Value = DR!LuasJaminan
                                .Item("RATEPLUS", i).Value = DR!RATEPLUS
                                .Item("RATEMIN", i).Value = DR!RATEMIN
                                .Item("Premi", i).Value = DR!Premi
                                .Item("PremiKapal", i).Value = DR!PremiKapal
                                .Item("IDBooking", i).Value = DR!IDBooking
                            End With
                            i += 1
                        End While
                        dgvList.Rows.Add()
                        Call sumpremi()
                        Call WarnaiKolomEdit()
                    Else
                        'dgvList.Rows.Clear()
                        MsgBox("Data Tidak ditemukan ! ", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    DR.Close()
                End Using

            End Using
            DB.CloseConnection()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Function SaveDataAngkutanMuatHdr(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        Dim MyCMD As New SqlCommand
        Try
            With MyCMD
                Dim MyCon As SqlConnection = Conn
                Dim MyConTrans As SqlTransaction = Trans
                .Connection = MyCon
                .CommandType = CommandType.StoredProcedure
                .CommandText = "RMPApp..sp_RMTrnAngkutanBuahKapalHdr"
                .Transaction = MyConTrans
                .Parameters.Add("@RETURN_VALUE", SqlDbType.SmallInt).Direction = ParameterDirection.ReturnValue
                .Parameters.Add("@Perintah", SqlDbType.VarChar, 10).Value = perintah
                .Parameters.Add("@NoInvoice", SqlDbType.VarChar, 30).Value = txtinvoice.Text
                .Parameters.Add("@tglinvoice", SqlDbType.DateTime).Value = dtpInvoice.Value
                .Parameters.Add("@periodetgl", SqlDbType.DateTime).Value = dtp1.Value
                .Parameters.Add("@periodetgl2", SqlDbType.DateTime).Value = dtp2.Value
                .Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
                '.Parameters.Add("@Tujuan", SqlDbType.VarChar, 5).Value = IIf(rdRSUP.Checked = True, "RSUP", "PSG")
                .Parameters.Add(New SqlParameter("@Error", SqlDbType.VarChar, 200, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
                .ExecuteNonQuery()
                .Dispose()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message & " infosp : " & MyCMD.Parameters("@Error").Value)
            Return False
        End Try
        Return True
    End Function

    Private Function SaveDataAngkutanMuatDtl(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal I As Integer) As Boolean
        Dim MyCMD As New SqlCommand
        With MyCMD

            SaveDataAngkutanMuatDtl = False
            Dim MyCon As SqlConnection = Conn
            Dim MyConTrans As SqlTransaction = Trans
            .Connection = MyCon
            .Connection = MyCon
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RMPApp..sp_RMTrnAngkutanBuahKapalDtl"
            .Transaction = MyConTrans
            .Parameters.Add("@RETURN_VALUE", SqlDbType.SmallInt).Direction = ParameterDirection.ReturnValue
            .Parameters.Add("@NoInvoice", SqlDbType.VarChar, 30).Value = txtinvoice.Text
            .Parameters.Add("@IDKapal", SqlDbType.Int).Value = dgvList.Item("IDKapal", I).Value
            .Parameters.Add("@NamaKapal", SqlDbType.VarChar, 50).Value = dgvList.Item("NamaKapal", I).Value
            .Parameters.Add("@IDPancang", SqlDbType.Int).Value = dgvList.Item("IDPancang", I).Value
            .Parameters.Add("@Pancang", SqlDbType.VarChar, 50).Value = Replace(dgvList.Item("Pancang", I).Value, "PANCANG SIMBAR - ABU", "PANCANG SIMBAR")
            .Parameters.Add("@TglBerangkat", SqlDbType.DateTime).Value = Format(CDate(dgvList.Item("TglBerangkat", I).Value), "dd/MM/yyyy")
            .Parameters.Add("@Tujuan", SqlDbType.VarChar, 10).Value = dgvList.Item("Tujuan", I).Value
            .Parameters.Add("@Trip", SqlDbType.Int).Value = dgvList.Item("Trip", I).Value
            .Parameters.Add("@luasjaminan", SqlDbType.VarChar, 30).Value = (dgvList.Item("luasjaminan", I).Value)
            .Parameters.Add("@Muatan", SqlDbType.Decimal, 18, 4).Value = (If(Val(dgvList.Item("Muatan", I).Value) = 0, 0, Convert.ToDouble(dgvList.Item("Muatan", I).Value)))
            .Parameters.Add("@JamBerangkat", SqlDbType.DateTime).Value = dgvList.Item("JamBerangkat", I).Value
            .Parameters.Add("@Rp", SqlDbType.Decimal, 18, 4).Value = (If(Val(dgvList.Item("Rp", I).Value) = 0, 0, Convert.ToDouble(dgvList.Item("Rp", I).Value)))
            .Parameters.Add("@RpKBB", SqlDbType.Decimal, 18, 4).Value = (If(Val(dgvList.Item("RpKBB", I).Value) = 0, 0, Convert.ToDouble(dgvList.Item("RpKBB", I).Value)))
            .Parameters.Add("@TotalHarga", SqlDbType.Decimal, 18, 4).Value = dgvList.Item("TotalHarga", I).Value
            .Parameters.Add("@Rate", SqlDbType.Decimal, 18, 4).Value = (If(Val(dgvList.Item("Rate", I).Value) = 0, 0, Convert.ToDouble(dgvList.Item("Rate", I).Value)))
            .Parameters.Add("@Premi", SqlDbType.Decimal, 18, 4).Value = (If(Val(dgvList.Item("Premi", I).Value) = 0, 0, Convert.ToDouble(dgvList.Item("Premi", I).Value)))
            .Parameters.Add("@PremiKapal", SqlDbType.Decimal, 18, 4).Value = (If(Val(dgvList.Item("PremiKapal", I).Value) = 0, 0, Convert.ToDouble(dgvList.Item("PremiKapal", I).Value)))
            .Parameters.Add("@RATEPLUS", SqlDbType.Decimal, 18, 4).Value = (If(Val(dgvList.Item("RATEPLUS", I).Value) = 0, 0, Convert.ToDouble(dgvList.Item("RATEPLUS", I).Value)))
            .Parameters.Add("@RATEMIN", SqlDbType.Decimal, 18, 4).Value = (If(Val(dgvList.Item("RATEMIN", I).Value) = 0, 0, Convert.ToDouble(dgvList.Item("RATEMIN", I).Value)))
            .Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
            .Parameters.Add("@IDBOOKING", SqlDbType.Int).Value = (If(Val(dgvList.Item("IDBOOKING", I).Value) = 0, 0, dgvList.Item("IDBOOKING", I).Value))
            .Parameters.Add(New SqlParameter("@Flag", SqlDbType.SmallInt, 5, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .ExecuteNonQuery()
            If CInt(.Parameters("@Flag").Value) = 0 Then
                .Dispose()
                Exit Function
            End If
            Return True
        End With
    End Function

    Private Sub btnLoaddata_Click(sender As Object, e As EventArgs) Handles btnLoaddata.Click
        dgvList.Rows.Clear()
        If perintah = "Add" Then
            loaddata()
        End If
    End Sub
    Public Sub clear(flag As Boolean)
        dgvList.Rows.Clear()
        txtinvoice.Text = ""
        perintah = ""
    End Sub

    Public Sub cmdEnabled(flag As Boolean)
        btnedit.Enabled = flag
        btnadd.Enabled = flag
        btnsave.Enabled = Not flag
        btncancel.Enabled = Not flag
        btnDelete.Enabled = flag
        btnexit.Enabled = flag
        btnfind.Enabled = flag
    End Sub

    Private Function NOREFFPREMI(NoInv As String) As String
        Try
            NOREFFPREMI = ""
            Dim connb As New SqlConnection(StrConnRMPApp)
            connb.Open()
            Dim sql As String
            sql = "Select TOP(1)  NoInvoice From  RMPApp..tbl_RMTrnAngkutanBuahKapalHdr  where  NoInvoice='" & NoInv & "'"
            Dim cmd2 As New SqlClient.SqlCommand(sql, connb)
            Dim reader As SqlClient.SqlDataReader
            reader = cmd2.ExecuteReader
            If reader.HasRows Then
                If reader.Read() Then
                    NOREFFPREMI = "1"
                Else
                    NOREFFPREMI = "0"
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Default
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim Koneksi As SqlConnection = DB.OpenConnection(StrConnRMPApp)
        Dim Transaksi As SqlTransaction
        Transaksi = Koneksi.BeginTransaction
        Me.Cursor = Cursors.WaitCursor
        Try

            If txtinvoice.Text = "" Then
                MessageBox.Show("Isi Invoice", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Cursor = Cursors.Default
                Exit Try
            End If

            ' cek jika harga kbb belum di input
            Dim nilai As String = Trim(If(dgvList.Item("RpKBB", 0).Value, "").ToString)

            If nilai <> "" AndAlso Not IsNumeric(nilai) Then
                MessageBox.Show("Harga KB-B Belum Diinput!")
                Exit Sub
            End If

            If perintah = "Add" Then
                If NOREFFPREMI(txtinvoice.Text) = "1" Then
                    MessageBox.Show("No Invoice Sudah Ada !", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Try
                End If
            End If

            Dim i As Integer
            If SaveDataAngkutanMuatHdr(Koneksi, Transaksi) = False Then
                Transaksi.Rollback()
                Transaksi = Nothing
                Me.Cursor = Cursors.Default
                MessageBox.Show("Simpan Data Hdr Gagal !", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Try
            End If

            For i = 0 To dgvList.RowCount - 2
                If Val(dgvList.Item("PremiKapal", i).Value) > 0 Then
                    If SaveDataAngkutanMuatDtl(Koneksi, Transaksi, i) = False Then
                        Transaksi.Rollback()
                        Transaksi = Nothing
                        Me.Cursor = Cursors.Default
                        MessageBox.Show("Simpan Data Dtl Gagal!", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Try
                    End If
                End If
            Next i

            Transaksi.Commit()
            Me.Cursor = Cursors.Default
            MessageBox.Show("Simpan Data Berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call clear(True)
            perintah = ""
            cmdEnabled(True)
            Me.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Transaksi.Rollback()
            Koneksi.Close()
            Me.Cursor = Cursors.Default
        Finally
            Koneksi.Close()
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        perintah = ""
        perintah = "Add"
        dtpInvoice.Focus()

        cmdEnabled(False)
        Call clear(True)
        enableds(True)
        'Call NoNota()
    End Sub

    Public Sub enableds(flag As Boolean)
        txtinvoice.Enabled = flag
        dtpInvoice.Enabled = flag
        dtp1.Enabled = flag
        dtp2.Enabled = flag
    End Sub
    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Call clear(True)
        cmdEnabled(True)
    End Sub

    Private Sub btnedit_Click(sender As Object, e As EventArgs) Handles btnedit.Click
        If txtinvoice.Text = "" Then
            MessageBox.Show("Tidak ada data yang di Edit, Klik Find untuk Edit data", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        cmdEnabled(False)
        perintah = "Edit"
        txtinvoice.Enabled = False
        enableds(True)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim Koneksi As SqlConnection = DB.OpenConnection(StrConnRMPApp)
        Dim Transaksi As SqlTransaction
        Transaksi = Koneksi.BeginTransaction
        Me.Cursor = Cursors.WaitCursor
        Try

            If txtinvoice.Text = "" Then
                MessageBox.Show("Isi Invoice", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            'If SaveDelPremiMuat(Koneksi, Transaksi) = False Then
            '    Transaksi.Rollback()
            '    Transaksi = Nothing
            '    Me.Cursor = Cursors.Default
            '    MessageBox.Show("Simpan Data Hdr Gagal !", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Exit Sub
            'End If

            Transaksi.Commit()
            Me.Cursor = Cursors.Default
            MessageBox.Show("Simpan Data Berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call clear(True)
            perintah = ""
            cmdEnabled(True)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Transaksi.Rollback()
            Koneksi.Close()
            Me.Cursor = Cursors.Default
        Finally
            Koneksi.Close()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub dtp1_ValueChanged(sender As Object, e As EventArgs) Handles dtp1.ValueChanged
        If dgvList.RowCount > 1 Then
            dgvList.Rows.Clear()
        End If
    End Sub

    Private Sub dtp2_ValueChanged(sender As Object, e As EventArgs) Handles dtp2.ValueChanged
        If dgvList.RowCount > 1 Then
            dgvList.Rows.Clear()
        End If
    End Sub

    Private Sub btnexit_Click(sender As Object, e As EventArgs) Handles btnexit.Click
        Me.Dispose()
    End Sub

    Private Sub dgvList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellContentClick

    End Sub

    Private Sub SplitContainer1_Panel2_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel2.Paint

    End Sub


    Private Function SaveTrnAbsensiHdr(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        Dim MyCMD As New SqlCommand
        Try
            With MyCMD
                Dim MyCon As SqlConnection = Conn
                Dim MyConTrans As SqlTransaction = Trans
                .Connection = MyCon
                .CommandType = CommandType.StoredProcedure
                .CommandText = "RMPApp..spSaveTrnAbsensiHdrAQWE"
                .Transaction = MyConTrans
                .Parameters.Add("@RETURN_VALUE", SqlDbType.SmallInt).Direction = ParameterDirection.ReturnValue
                .Parameters.Add("@Perintah", SqlDbType.VarChar, 10).Value = "Add"
                .Parameters.Add("@NoInvoice", SqlDbType.VarChar, 30).Value = "001/ABSN/052023"
                .Parameters.Add("@periode1", SqlDbType.DateTime).Value = dtp1.Value
                .Parameters.Add("@periode2", SqlDbType.DateTime).Value = dtp2.Value
                .Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
                .Parameters.Add(New SqlParameter("@Error", SqlDbType.VarChar, 200, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
                .ExecuteNonQuery()
                .Dispose()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message & " infosp : " & MyCMD.Parameters("@Error").Value)
            Return False
        End Try
        Return True
    End Function


    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim Koneksi As SqlConnection = DB.OpenConnection(StrConnRMPApp)
        Dim Transaksi As SqlTransaction
        Transaksi = Koneksi.BeginTransaction
        Me.Cursor = Cursors.WaitCursor

        Try
            If SaveTrnAbsensiHdr(Koneksi, Transaksi) = False Then
                Transaksi.Rollback()
                Transaksi = Nothing
                Me.Cursor = Cursors.Default
                MessageBox.Show("Simpan Data Hdr Gagal !", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Try
            End If

            Transaksi.Commit()
            Me.Cursor = Cursors.Default
            MessageBox.Show("Simpan Data Berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call clear(True)
            perintah = ""
            cmdEnabled(True)
            Me.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Transaksi.Rollback()
            Koneksi.Close()
            Me.Cursor = Cursors.Default
        Finally
            Koneksi.Close()
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

    End Sub

    Private Sub dgvList_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) _
    Handles dgvList.CellEndEdit

        If e.ColumnIndex = dgvList.Columns("RpKBB").Index Then

            Dim nilai As Decimal = Val(dgvList.Rows(e.RowIndex).Cells("RpKBB").Value)

            If nilai > 0 Then
                For i As Integer = e.RowIndex + 1 To dgvList.RowCount - 2
                    dgvList.Rows(i).Cells("RpKBB").Value = nilai
                Next
            End If

        End If

    End Sub
End Class