Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Math
Imports DocumentFormat.OpenXml.EMMA
Imports DocumentFormat.OpenXml.Office2010.Excel
Imports Spire.Pdf.HtmlConverter

Public Class FrmTrnPergeseranPancang
    Public id As String
    Dim flagDiLuarAlur As Integer = 0
    Public Sub loaddataFind()
        Try
            Dim SQL As String
            Dim COUNTKAPAL As Integer
            COUNTKAPAL = 0
            SQL = "SELECT top 1 * From RMPAPP..vwPersonilPCG2024  WHERE idpersonil ='" & id & "' order by ID desc "

            Using koneksi As New SqlCommand(SQL, DB.OpenConnection(StrConnRMPApp))
                Using DR = koneksi.ExecuteReader()
                    If DR.HasRows Then
                        While DR.Read

                            If DR!Bagian = "P1" Then
                                rdP1.Checked = True
                            ElseIf DR!Bagian = "P2" Then
                                rdP2.Checked = True
                            ElseIf DR!Bagian = "P3" Then
                                rdp3.Checked = True
                            Else
                                rdPSP.Checked = True
                            End If

                            txtID.Text = DR!IDPersonil
                            txtNama.Text = DR!Nama
                            txtReg.Text = DR!RegFixNo
                            txtNIK.Text = DR!nik
                            txtidpancang.Text = DR!IDPancang
                            txtnamapancang.Text = DR!Pancang
                            txtlatd1.Text = DR!Latitude
                            txtlong1.Text = DR!Longitude

                        End While
                    Else
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

    Function Haversine(lat1 As Double, lon1 As Double, lat2 As Double, lon2 As Double) As Double
        ' Konversi derajat ke radian
        Dim R As Double = 6371 ' Radius bumi dalam kilometer
        Dim dLat As Double = (lat2 - lat1) * (PI / 180)
        Dim dLon As Double = (lon2 - lon1) * (PI / 180)
        Dim a As Double = Sin(dLat / 2) * Sin(dLat / 2) +
                          Cos(lat1 * (PI / 180)) * Cos(lat2 * (PI / 180)) *
                          Sin(dLon / 2) * Sin(dLon / 2)
        Dim c As Double = 2 * Atan2(Sqrt(a), Sqrt(1 - a))
        Dim distance As Double = R * c ' Jarak dalam kilometer

        Return distance
    End Function

    Function DegreesToRadians(degrees As Double) As Double
        Return degrees * (Math.PI / 180.0)
    End Function

    Private Sub FrmTrnPergeseranPancang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dttgl.Value = Format(Now, "yyyy-MM-dd")
        txtlatd1.Clear()
        txtlatd2.Clear()
        txtlong1.Clear()
        txtlong2.Clear()
        txtKet.Clear()
        txtjarak.Clear()

        'jika ada pancang baru masukan data pancang nya ke RMPApp..tblHistoryPerpindahanPersonilPcg
        Dim dt As DataTable = New DataTable
        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " select * from Android_tblMstPancang where RingWilayah is not null ")
        For Each row As DataRow In dt.Rows
            Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " if not exists (select * from tblHistoryPerpindahanPersonilPcg where idPancang='" & row.Item("IDPancang") & "' and idPersonil='" & id & "')
                                                           begin
	                                                            insert into tblHistoryPerpindahanPersonilPcg (idPersonil,ringWilayah,idPancang,flagSudahPernah)
	                                                            values ('" & id & "','" & row.Item("RingWilayah") & "','" & row.Item("IDPancang") & "',0)
                                                           end ")
        Next
        Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " --ketika belum pernah di edit di program baru ini, beri flag pada pancang sebelum nya yang sudah di pindahkan
                                                        if isnull((select top 1 flagSudahPernah from tblHistoryPerpindahanPersonilPcg where flagSudahPernah=1 and idPersonil='" & id & "'),0)=0
                                                        begin
	                                                        update tblHistoryPerpindahanPersonilPcg set flagSudahPernah=1 where idPersonil='" & id & "' and idPancang in (select distinct IDPancang from TblMstPersonilPancangNew where IDPersonil='" & id & "' and NotActive=0)
                                                        end
                                                         ")

        SetPancang(cboPancang)

        loaddataFind()
    End Sub

    Public Sub SetPancang(ByVal cbo As ComboBox)
        Dim dt As DataTable = New DataTable()

        If chkAllPancang.Checked = True Then
            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select IDPancang,Pancang = isnull(cast(RingWilayah as varchar(8)),'No Range') + ' | ' + Pancang +'('+ convert(varchar,IDPancang) +')' from Android_tblMstPancang  ORDER BY RingWilayah ASC")
        Else
            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " declare @rangeSaatIni int 
                                                            declare @idPersonil varchar(50) = '" & id & "'

                                                            set @rangeSaatIni = isnull((select top 1 ringWilayah from tblHistoryPerpindahanPersonilPcg 
                                                            where idPancang=(select top 1 IDPancang from TblMstPersonilPancangNew where IDPersonil=@idPersonil and NotActive=0 order by Tanggal desc)),0)

                                                            if (select isnull((select top 1 idPancang from tblHistoryPerpindahanPersonilPcg where flagSudahPernah=0 and ringWilayah = @rangeSaatIni and idPersonil=@idPersonil),0))=0
                                                            begin
	                                                            select IDPancang,Pancang = isnull(cast(RingWilayah as varchar(8)),'No Range') + ' | ' + Pancang +'('+ convert(varchar,IDPancang) +')'
	                                                            from Android_tblMstPancang  
	                                                            where (RingWilayah is null or IDPancang in 
	                                                            (
	                                                            select idPancang from tblHistoryPerpindahanPersonilPcg where idPersonil=@idPersonil and flagSudahPernah=0
	                                                            ))
	                                                            ORDER BY RingWilayah ASC
                                                            end
                                                            else
                                                            begin
	                                                            select IDPancang,Pancang = isnull(cast(RingWilayah as varchar(8)),'No Range') + ' | ' + Pancang +'('+ convert(varchar,IDPancang) +')'
	                                                            from Android_tblMstPancang  
	                                                            where IDPancang in 
	                                                            (
	                                                            select idPancang from tblHistoryPerpindahanPersonilPcg where flagSudahPernah=0 and ringWilayah = @rangeSaatIni and idPersonil=@idPersonil
	                                                            )
	                                                            ORDER BY RingWilayah ASC
                                                            end ")
        End If

        With cbo
            .DataSource = dt
            .DisplayMember = "Pancang"
            .ValueMember = "IDPancang"
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub cboPancang_Validating(sender As Object, e As CancelEventArgs) Handles cboPancang.Validating
        If txtidpancang.Text > 0 AndAlso cboPancang.SelectedValue IsNot Nothing Then
            Dim latd2 As String
            Dim long2 As String
            Dim A, B, C, D As Double

            Try
                Dim SQL As String
                Dim COUNTKAPAL As Integer
                COUNTKAPAL = 0
                SQL = "SELECT * From [RMPApp].[dbo].[Android_tblMstPancang]  WHERE  IDPancang='" & cboPancang.SelectedValue.ToString & "' "

                Using koneksi As New SqlCommand(SQL, DB.OpenConnection(StrConnRMPApp))
                    Using DR = koneksi.ExecuteReader()
                        If DR.HasRows Then
                            While DR.Read

                                txtlatd2.Text = DR!Latitude
                                txtlong2.Text = DR!Longitude

                                'aa

                            End While
                        Else
                            MsgBox("Data Tidak ditemukan ! ", MsgBoxStyle.Information)
                            Exit Sub
                        End If
                        DR.Close()
                    End Using
                End Using
                DB.CloseConnection()

                A = txtlatd1.Text
                B = txtlong1.Text
                C = txtlatd2.Text
                D = txtlong2.Text

                Dim distance As Double = Haversine(A, B, C, D)

                ' Tampilkan hasil
                txtjarak.Text = distance.ToString("F2")

                cekPancangYangDiPilih(txtidpancang.Text, cboPancang.SelectedValue)
            Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    Private Sub cekPancangYangDiPilih(ByVal pancangOld As Integer, ByVal pancangNow As Integer)
        Dim cekPancang As String = ""
        cekPancang = DB.ExecuteScalarValue(Of String)(StrConnRMPApp," declare @idPancangOld int = " & pancangOld & "
                                        declare @idPancangNew int = " & pancangNow & "
                                        declare @idPersonil varchar(50) = '" & id & "'
                                        declare @ringSaatIni int
                                        declare @ringDiPilih int
                                        declare @flagDiDalamRingTapiPancangYangSudahPernah int
                                        declare @ket varchar(150) = ''

                                        set @ringSaatIni = (select ISNULL(RingWilayah,0) from Android_tblMstPancang where IDPancang=@idPancangOld)
                                        set @ringDiPilih = (select ISNULL(RingWilayah,0) from Android_tblMstPancang where IDPancang=@idPancangNew)

										--jika pindah ring sebelum habiskan pancnag yang belum di pindahkan
										if (@ringSaatIni <> @ringDiPilih) and ((select COUNT(idPancang) from tblHistoryPerpindahanPersonilPcg where ringWilayah=@ringSaatIni and flagSudahPernah=0 and idPersonil=@idPersonil)<>0)
										begin
		                                    set @ket = 'Anda memilih pancang di luar alur pergeseran pancang, maka wajib beri keterangan pada pergeseran ini !' 
	                                    end

										--jika pindah ke pancang yang sudah pernah yang ada ring nya
										if isnull((select top 1 flagSudahPernah from tblHistoryPerpindahanPersonilPcg where idPancang=@idPancangNew and idPersonil=@idPersonil),0)=1
	                                    begin
		                                    set @ket = 'Anda memilih pancang di luar alur pergeseran pancang, maka wajib beri keterangan pada pergeseran ini !' 
	                                    end

										select @ket as GetValueString")
        If cekPancang <> "" Then
            MsgBox(cekPancang, vbExclamation, AT)
            flagDiLuarAlur = 1
        Else
            flagDiLuarAlur = 0
        End If
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Me.Cursor = Cursors.WaitCursor

        Dim koneksi As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnRMPApp)
        Dim transaksi As SqlTransaction
        transaksi = koneksi.BeginTransaction

        If flagDiLuarAlur = 1 And txtKet.Text = "" Then
            MsgBox("Keterangan wajib di isi karena pergeseran di luar alur !", vbInformation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        ElseIf cboPancang.SelectedValue Is Nothing Then
            MsgBox("Pancang tujuan belum di pilih !", vbInformation, AT)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        Try
            If SaveData(koneksi, transaksi) = False Then
                transaksi.Rollback()
                MsgBox("Simpan Data Gagal !", vbCritical, AT)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            transaksi.Commit()
            MsgBox("Simpan Data Berhasil !", vbInformation, AT)

            FrmMonPenggeseranAbsensiPancang.callDataDetail()
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Cursor = Cursors.Default
        Finally
            koneksi.Close()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function SaveData(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        SaveData = False

        Dim MyCon As SqlConnection = Conn
        Dim MyConTrans As SqlTransaction = Trans
        Dim cmd As New SqlCommand

        With cmd
            .Connection = Conn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RMPApp..spSavePindahPancang"
            .Transaction = MyConTrans

            .Parameters.Add("@idPancang", SqlDbType.Int).Value = cboPancang.SelectedValue
            .Parameters.Add("@idPersonil", SqlDbType.VarChar, 50).Value = txtID.Text
            .Parameters.Add("@ket", SqlDbType.VarChar, 500).Value = txtKet.Text
            .Parameters.Add("@tanggal", SqlDbType.Date).Value = Format(dttgl.Value, "yyyy-MM-dd")
            .Parameters.Add("@createdBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
            .Parameters.Add(New SqlParameter("@Flag", SqlDbType.SmallInt, 3, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))

            .ExecuteNonQuery()
        End With

        Try
            If CInt(cmd.Parameters("@Flag").Value) = 0 Then
                cmd.Dispose()
                Exit Function
            End If

            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function

    Private Sub btnexit_Click(sender As Object, e As EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub chkAllPancang_CheckedChanged(sender As Object, e As EventArgs) Handles chkAllPancang.CheckedChanged
        SetPancang(cboPancang)
    End Sub
End Class