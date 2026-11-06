Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmTrnPenjualanRestore
    Private Sub FrmTrnPembuatanPenjualanFind_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set ComboBox
        Modul_RMP.Combo.SetPancang(cboPancang)
        cboPancang.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboPancang.AutoCompleteSource = AutoCompleteSource.ListItems
        Modul_RMP.Combo.SetKapal(cboKapal)
        cboKapal.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboKapal.AutoCompleteSource = AutoCompleteSource.ListItems

        Call ClsFlexGrid.ApplyStyle(fg)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Call ShowData()
    End Sub

    Public Sub ShowData()
        Dim dt As New DataTable
        Dim i As Integer = 1
        Dim sql As String = ""

        ' cek jika belum memilih pancang
        If Replace(cboPancang.Text, " ", "") = "" Then
            MsgBoxCustom.Show("Silakan pilih pancang terlebih dahulu.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Exit Sub
        End If

        ' cek jika belum memilih kapal
        If Replace(cboKapal.Text, " ", "") = "" Then
            MsgBoxCustom.Show("Silakan pilih kapal terlebih dahulu.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Exit Sub
        End If

        ' cek jika belum isi trip
        If Replace(txtTrip.Text, " ", "") = "" Then
            MsgBoxCustom.Show("Silakan isi trip terlebih dahulu.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Exit Sub
        End If

        sql &= "select IDPancang,Pancang,IDKapal,KapalName,Trip,Tujuan,Jenis,Grade,GradeSub from vwTrnPembuatanPenjualanHdr where "

        If Replace(txtTrip.Text, " ", "") <> "" Then
            sql &= " Trip = '" & txtTrip.Text & "' "
        End If

        If Replace(cboKapal.Text, " ", "") > "" Then
            sql &= " and IDKapal = '" & cboKapal.SelectedValue & "' "
        End If

        If Replace(cboPancang.Text, " ", "") > "" Then
            sql &= " and IDPancang = '" & cboPancang.SelectedValue & "' "
        End If

        If rdRSUP.Checked = True Then
            sql &= " and Tujuan='RSUP' "
        ElseIf rdPSG.Checked = True Then
            sql &= " and Tujuan='PSG' "
        ElseIf rdCustomer.Checked = True Then
            sql &= " and Tujuan in ('Customer','Relasi') "
        End If

        If rdJambul.Checked = True Then
            sql &= " and Jenis='Jambul' "
        ElseIf rdLicin.Checked = True Then
            sql &= " and Jenis='Licin' "
        ElseIf rdCungkil.Checked = True Then
            sql &= " and Jenis='Cungkil' "
        ElseIf rdGelondong.Checked = True Then
            sql &= " and Jenis='Gelondong' "
        End If

        If rdKBA.Checked = True Then
            sql &= " and Grade='KB-A' "
        ElseIf rdKBB.Checked = True Then
            sql &= " and Grade='KB-B' "
        ElseIf rdKC.Checked = True Then
            sql &= " and Grade='KC' "
        ElseIf rdGD.Checked = True Then
            sql &= " and Grade='GD' "
        End If

        If rdJambul.Checked = True Or rdLicin.Checked = True Then
            If chkA6.Checked = True Then
                sql &= " and GradeSub='A6' "
            ElseIf chkA6.Checked = False Then
                sql &= " and GradeSub='A' "
            End If
        End If

        sql &= " group by IDPancang,Pancang,IDKapal,KapalName,Trip,Tujuan,Jenis,Grade,GradeSub"

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fg
            .Rows.Count = 1 ' Reset grid

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "PancangID") = row("IDPancang")
                    .Item(i, "Pancang") = row("Pancang")
                    .Item(i, "KapalID") = row("IDKapal")
                    .Item(i, "Kapal") = row("KapalName")
                    .Item(i, "Trip") = row("Trip")
                    .Item(i, "Tujuan") = row("Tujuan")
                    .Item(i, "Jenis") = row("Jenis")
                    .Item(i, "Grade") = row("Grade")
                    .Item(i, "GradeSub") = row("GradeSub")

                    ' Masukkan gambar yang sudah di-resize
                    .SetCellImage(i, "Delete", Func.ResizeImage(My.Resources.DELETED_20, 16, 16))

                    i += 1
                Next

                .AutoSizeCols()
            Else
                MsgBoxCustom.Show("Tidak ada data.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            End If
        End With
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click
        With fg
            If .Rows.Count = 1 Then Exit Sub

            Dim colName As String = .Cols(.Col).Name

            Select Case colName
                Case "Delete"
                    ' ==========================
                    ' KONFIRMASI DELETE
                    ' ==========================
                    If MsgBoxCustom.Show("Apakah Anda ingin menghapus pengajuan penjualan?" & vbCrLf & vbCrLf &
                          "Pancang    : " & .Item(.Row, "Pancang") & vbCrLf &
                          "Kapal         : " & .Item(.Row, "Kapal") & vbCrLf &
                          "Trip             : " & .Item(.Row, "Trip") & vbCrLf &
                          "Tujuan       : " & .Item(.Row, "Tujuan") & vbCrLf &
                          "Grade         : " & .Item(.Row, "Grade") & vbCrLf &
                          "Grade Sub : " & .Item(.Row, "GradeSub"),
                          MsgBoxCustom.ButtonType.YesNo, MsgBoxCustom.IconType.Question) = vbNo Then Exit Sub

                    ' ==========================
                    ' INPUT KETERANGAN
                    ' ==========================
                    Dim fr As New FrmKeteranganDelete
                    Dim KeteranganDelete As String = ""

                    If fr.ShowDialog() = DialogResult.OK Then
                        KeteranganDelete = fr.ResultText
                    End If

                    If KeteranganDelete.Trim() = "" Then
                        MsgBoxCustom.Show("Delete Data dibatalkan.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                        Exit Sub
                    End If

                    ' ==========================
                    ' EKSEKUSI SP DENGAN TRANSAKSI
                    ' ==========================
                    Me.Cursor = Cursors.WaitCursor

                    Dim Conn As New SqlConnection(StrConnRMPApp)
                    Conn.Open()

                    Dim Trans As SqlTransaction = Conn.BeginTransaction()

                    Try
                        Using cmd As New SqlCommand("RMPApp..sp_TrnPembuatanPenjualanDelete", Conn, Trans)
                            cmd.CommandType = CommandType.StoredProcedure

                            cmd.Parameters.Add("@IDPancang", SqlDbType.Int).Value = .Item(.Row, "PancangID")
                            cmd.Parameters.Add("@IDKapal", SqlDbType.Int).Value = .Item(.Row, "KapalID")
                            cmd.Parameters.Add("@Trip", SqlDbType.Int).Value = .Item(.Row, "Trip")
                            cmd.Parameters.Add("@Tujuan", SqlDbType.VarChar, 50).Value = .Item(.Row, "Tujuan")
                            cmd.Parameters.Add("@Jenis", SqlDbType.VarChar, 50).Value = .Item(.Row, "Jenis")
                            cmd.Parameters.Add("@Grade", SqlDbType.VarChar, 50).Value = .Item(.Row, "Grade")
                            cmd.Parameters.Add("@GradeSub", SqlDbType.VarChar, 50).Value = .Item(.Row, "GradeSub")
                            cmd.Parameters.Add("@DeletedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
                            cmd.Parameters.Add("@Keterangan", SqlDbType.VarChar, 500).Value = KeteranganDelete
                            cmd.Parameters.Add("@AppVersion", SqlDbType.VarChar, 50).Value =
                            My.Application.Info.Version.ToString()

                            cmd.Parameters.Add("@Flag", SqlDbType.Int).Direction = ParameterDirection.Output

                            cmd.ExecuteNonQuery()

                            Dim flagResult As Integer = CInt(cmd.Parameters("@Flag").Value)

                            If flagResult = 1 Then
                                Trans.Commit()
                                MsgBoxCustom.Show("Data berhasil dihapus.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                                Me.Cursor = Cursors.Default
                            Else
                                Me.Cursor = Cursors.Default
                                Trans.Rollback()
                                MsgBoxCustom.Show("Gagal menghapus data.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
                                Exit Sub
                            End If
                        End Using
                    Catch ex As SqlException
                        Trans.Rollback()

                        ' === PESAN ERROR DARI SP (RAISERROR)
                        If ex.Number >= 50000 Then
                            MsgBoxCustom.Show(ex.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
                        Else
                            MsgBoxCustom.Show("System Error:" & vbCrLf & ex.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
                        End If
                        Exit Sub

                    Finally
                        Conn.Close()
                        Me.Cursor = Cursors.Default
                    End Try

                    ' ==========================
                    ' UPDATE LANJUTAN (NON-CRITICAL)
                    ' ==========================
                    Dim NoNotaRefrensi As String

                    NoNotaRefrensi = DB.ExecuteScalarValue(Of String)(StrConnRMPApp, "SELECT STUFF((
                                                            SELECT ',' + QUOTENAME(a2.NoNota, '''')
                                                            FROM RMPApp..tblTrnPembuatanPenjualanFakturPabrik AS a2
                                                            INNER JOIN RMPApp..tblTrnPembuatanPenjualanHdr AS b2 
                                                                ON a2.NoTrans = b2.NoTrans
                                                            WHERE b2.IDPancang = " & fg.Item(fg.Row, "PancangID") & "
                                                              AND b2.IDKapal   = " & fg.Item(fg.Row, "KapalID") & "
                                                              AND b2.Trip      = " & fg.Item(fg.Row, "Trip") & "
                                                              AND b2.Tujuan    = '" & fg.Item(fg.Row, "Tujuan") & "'
                                                              AND b2.Jenis     = '" & fg.Item(fg.Row, "Jenis") & "'
                                                              AND b2.Grade     = '" & fg.Item(fg.Row, "Grade") & "'
                                                              AND b2.GradeSub  = '" & fg.Item(fg.Row, "GradeSub") & "'
                                                            FOR XML PATH(''), TYPE
                                                        ).value('.', 'varchar(max)'), 1, 1, '') AS GetValueString")

                    Try
                        If NoNotaRefrensi <> "" Then
                            If .Item(.Row, "Tujuan") = "PSG" Then
                                Modul_RMP.DB.ExecuteQuery(StrConnPSGRMP, "
                                UPDATE tblRMTrnPenerimaanKBKGHdr
                                SET TFtoBPI = 0
                                WHERE NoNota in (" & NoNotaRefrensi & ")

                                UPDATE tblRMTrnPenerimaanKCDtl
                                SET TFtoBPI = 0
                                WHERE NoNota in (" & NoNotaRefrensi & ")")
                            ElseIf .Item(.Row, "Tujuan") = "RSUP" Then
                                Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "
                                UPDATE RSUPAccounting..tblRMTrnPenerimaanKBHdr
                                SET UseBPI = 0
                                WHERE NoNota in (" & NoNotaRefrensi & ")

                                UPDATE RSUPAccounting..tblRMTrnPenerimaanKCHdr
                                SET UseBPI = 0
                                WHERE NoNota in (" & NoNotaRefrensi & ")")
                            ElseIf .Item(.Row, "Tujuan") = "Customer" Then
                                Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "
                                update A  
                                set a.pullBPI=0
                                from Supplier_TransaksiKelapa as A
                                inner join Supplier_HargaHeader as B on a.IDHeader=b.id
                                where b.NoInvoice='" & NoNotaRefrensi & "'")
                            End If
                        End If
                    Catch ex As Exception
                        MsgBoxCustom.Show("Data utama terhapus, namun update lanjutan gagal:" &
                               vbCrLf & ex.Message,
                               MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
                    End Try

                    btnSearch.PerformClick()
            End Select
        End With
    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg.BeforeEdit
        e.Cancel = True
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class