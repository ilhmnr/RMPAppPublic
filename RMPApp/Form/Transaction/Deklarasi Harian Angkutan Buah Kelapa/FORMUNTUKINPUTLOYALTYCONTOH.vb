
Imports System.Data.SqlClient
Imports System.IO
Imports System.Data
Imports System.ComponentModel
Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Globalization

Public Class FORMUNTUKINPUTLOYALTYCONTOH
    Public RD As SqlDataReader
    Private Sub btnLoaddata_Click(sender As Object, e As EventArgs) Handles btnLoaddata.Click
        loaddata()


    End Sub

    'Private Function SaveDataAngkutanMuatDtl(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal NONOTA As String, ByVal TRANSDATE As String, ByVal Jenis As String, ByVal IDPenerimaUang As String, ByVal IDSubPetani As String, ByVal Pancang As String, ByVal TarraPersen As Decimal, ByVal NettoAkhir As Decimal) As Boolean
    Private Function SaveDataAngkutanMuatDtl(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal I As Integer) As Boolean

        Dim MyCMD As New SqlCommand
        With MyCMD

            SaveDataAngkutanMuatDtl = False
            Dim MyCon As SqlConnection = Conn
            Dim MyConTrans As SqlTransaction = Trans
            .Connection = MyCon
            .Connection = MyCon
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RMPApp..spAndroidloyalty"
            .Transaction = MyConTrans
            .Parameters.Add("@RETURN_VALUE", SqlDbType.SmallInt).Direction = ParameterDirection.ReturnValue
            .Parameters.Add("@NONOTA", SqlDbType.VarChar, 30).Value = dgvList.Item("NONOTA", I).Value
            .Parameters.Add("@TRANSDATE", SqlDbType.DateTime).Value = dgvList.Item("TRANSDATE", I).Value
            .Parameters.Add("@JENISKELAPA ", SqlDbType.VarChar, 10).Value = dgvList.Item("JENISKELAPA", I).Value
            .Parameters.Add("@PENERIMAID", SqlDbType.VarChar, 30).Value = dgvList.Item("PENERIMAID", I).Value
            .Parameters.Add("@SUBPETANIID", SqlDbType.VarChar, 30).Value = (dgvList.Item("SUBPETANIID", I).Value)
            .Parameters.Add("@Pancang", SqlDbType.VarChar, 100).Value = dgvList.Item("Pancang", I).Value
            .Parameters.Add("@TarraPersen", SqlDbType.Decimal, 18, 4).Value = dgvList.Item("TarraPersen", I).Value
            .Parameters.Add("@BeratNettoAkhir", SqlDbType.Decimal, 18, 4).Value = (If(Val(dgvList.Item("BeratNettoAkhir", I).Value) = 0, 0, Convert.ToDouble(dgvList.Item("BeratNettoAkhir", I).Value)))
            .Parameters.Add("@DeviceName", SqlDbType.VarChar, 100).Value = dgvList.Item("Pancang", I).Value

            '.Parameters.Add("@NONOTA", SqlDbType.VarChar, 30).Value = NONOTA
            '.Parameters.Add("@TRANSDATE", SqlDbType.DateTime).Value = TRANSDATE
            '.Parameters.Add("@JENISKELAPA ", SqlDbType.VarChar, 10).Value = Jenis
            '.Parameters.Add("@PENERIMAID", SqlDbType.VarChar, 30).Value = IDPenerimaUang
            '.Parameters.Add("@SUBPETANIID", SqlDbType.VarChar, 30).Value = IDSubPetani
            '.Parameters.Add("@Pancang", SqlDbType.VarChar, 100).Value = Pancang
            '.Parameters.Add("@TarraPersen", SqlDbType.Decimal, 18, 4).Value = TarraPersen
            '.Parameters.Add("@BeratNettoAkhir", SqlDbType.Decimal, 18, 4).Value = NettoAkhir
            '.Parameters.Add("@DeviceName", SqlDbType.VarChar, 100).Value = Pancang

            .Parameters.Add(New SqlParameter("@Flag", SqlDbType.SmallInt, 5, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .ExecuteNonQuery()

            If CInt(.Parameters("@Flag").Value) = 0 Then
                .Dispose()
                Exit Function
            End If
            Return True
        End With
    End Function
    Private Sub loaddata()


        Dim SQL As String, i As Integer
        Dim COUNTKAPAL As Integer
        COUNTKAPAL = 0
        SQL = " SELECT top(100) * FROM  vwkelapahdrall WHERE YEAR(TRANSDATE)='2022' and month(transdate)='01' ORDER BY cast(TRANSDATE as date),nonota ASC "

        Using koneksi As New SqlCommand(SQL, OpenKoneksi)
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
                    MsgBox("Data Tidak ditemukan ! ", MsgBoxStyle.Information)
                    Exit Sub
                End If

                DR.Close()
            End Using


        End Using
        OpenKoneksi.Close()

    End Sub


    Private Sub save()
        Dim Koneksi As SqlConnection = Modul_RMP.OpenKoneksi
        Dim Koneksi2 As SqlConnection = MDLRMP.KoneksiP2()
        Dim Transaksi As SqlTransaction
        Transaksi = Koneksi.BeginTransaction
        Me.Cursor = Cursors.WaitCursor

        Try
            Dim connp2 As New SqlConnection(koneksirmp2)

            Dim sql As String
            connp2.Open()
            sql = "SELECT top(20) *,jenis as jenis2  FROM  RMPApp..vwkelapahdrall WHERE YEAR(TRANSDATE)='2022' and month(transdate)='01' ORDER BY cast(TRANSDATE as date) ASC "
            Dim cmdselect As New SqlCommand(sql, connp2)
            RD = cmdselect.ExecuteReader()

            If RD.HasRows Then
                Do While RD.Read
                    Dim JENIS As String
                    JENIS = RD("jenis")
                    JENIS = JENIS
                    'If SaveDataAngkutanMuatDtl(Koneksi, Transaksi, RD("NONOTA"), Format(CDate(RD("TRANSDATE")), "yyyy-MM-dd"), RD("jenis"), RD("IDPenerimaUang"), RD("IDSubPetani"), RD("Pancang"), RD("TarraPersen"), RD("NettoAkhir")) = False Then
                    'Format(CDate(RD("TRANSDATE")), "yyyy-MM-dd")
                    Transaksi.Rollback()
                        Transaksi = Nothing
                        Me.Cursor = Cursors.Default
                        MessageBox.Show("Simpan Data Dtl Gagal!", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Try
                    'End If

                    Transaksi.Commit()
                    'MessageBox.Show("trf data berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)


                Loop

            Else
                Exit Try

            End If


            connp2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "gagal trf data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Transaksi.Rollback()

            Me.Cursor = Cursors.Default
            'connp2.Close()
        Finally
            Koneksi.Close()
            Me.Cursor = Cursors.Default
            'connp2.Close()
        End Try
        connp2.Close()
    End Sub
    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click

        'Timer1.Enabled = True
        'save()

        Dim Koneksi As SqlConnection = Modul_RMP.OpenKoneksi
        Dim Transaksi As SqlTransaction
        Transaksi = Koneksi.BeginTransaction
        Me.Cursor = Cursors.WaitCursor
        Try



            For i = 0 To dgvList.RowCount - 1
                If Val(dgvList.Item("BeratNettoAkhir", i).Value) > 0 Then
                    If SaveDataAngkutanMuatDtl(Koneksi, Transaksi, i) = False Then
                        Transaksi.Rollback()
                        Transaksi = Nothing
                        Me.Cursor = Cursors.Default
                        MessageBox.Show("Simpan Data Dtl Gagal!", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If
                End If
            Next i

            Transaksi.Commit()

            Me.Cursor = Cursors.Default
            MessageBox.Show("Simpan Data Berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

            loaddata()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Transaksi.Rollback()
            Koneksi.Close()
            Me.Cursor = Cursors.Default
        Finally
            Koneksi.Close()


        End Try
    End Sub

    Private Sub dtp1_ValueChanged(sender As Object, e As EventArgs) Handles dtp1.ValueChanged

    End Sub

    Private Sub FORMUNTUKINPUTLOYALTYCONTOH_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtp1.Value = Format(Now, "dd/MM/yy")
        dtp2.Value = Format(Now, "dd/MM/yy")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        save()
    End Sub
End Class