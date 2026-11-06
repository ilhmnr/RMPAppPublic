Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Windows.Interop
Imports C1.Win.C1FlexGrid

Public Class FrmTrnPengajuanPenerimaanNotaInput
    Public StatusOpenForm As String = "Add"
    Dim jalan, Indlebih, IndRelasi, indumharganego As Integer
    Dim tujuan, waktuPengajuan As String
    Private CanEdit, CanAdd, CanDelete, CanSave As Boolean

    Private Sub FrmTrnApprovalPenerimaan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set ComboBox
        Modul_RMP.Combo.SetPancang(cboPancang)
        Modul_RMP.Combo.SetKapal(cboKapal)

        ' Set FlexGrid
        Call ClsFlexGrid.ApplyStyle(fg)
        Call ClsFlexGrid.AttachLiveNumber(fg, 0, "Pinjaman")
        Call ClsFlexGrid.SetEditableColumns(fg, "Pinjaman", "Ajukan", "Select")

        If StatusOpenForm = "View" Then
            dtpTanggalApproval.Enabled = False
            btnFindNota.Enabled = False

            btnSave.Enabled = False
            btnDelete.Enabled = True

            fg.Cols("Select").Visible = True
            fg.Cols("StatusProses").Visible = True
            fg.Cols("Ajukan").Visible = False
            fg.Cols("SisaPinjaman").Visible = False

            pnlFg.Padding = New Padding(0, 0, 0, 0)

            Call ShowDataView()
        ElseIf StatusOpenForm = "Edit" Then
            dtpTanggalApproval.Enabled = False
            btnFindNota.Enabled = False

            btnSave.Enabled = True
            btnDelete.Enabled = False

            fg.Cols("Select").Visible = True
            fg.Cols("StatusProses").Visible = True
            fg.Cols("Ajukan").Visible = False
            fg.Cols("SisaPinjaman").Visible = True

            pnlFg.Padding = New Padding(0, 0, 0, 0)

            Call ShowDataView()
        ElseIf StatusOpenForm = "ViewApproval" Then
            dtpTanggalApproval.Enabled = False

            btnSave.Enabled = False
            btnDelete.Enabled = False

            fg.Cols("Select").Visible = False
            fg.Cols("StatusProses").Visible = False
            fg.Cols("Ajukan").Visible = False
            fg.Cols("SisaPinjaman").Visible = False

            pnlFg.Padding = New Padding(0, 0, 0, 0)

            Call ShowDataView()
        Else
            dtpTanggalApproval.Enabled = True

            btnSave.Enabled = True
            btnDelete.Enabled = False

            fg.Cols("Select").Visible = False
            fg.Cols("StatusProses").Visible = False
            fg.Cols("Ajukan").Visible = True
            fg.Cols("SisaPinjaman").Visible = False

            pnlFg.Padding = New Padding(0, 30, 0, 0)

            ' Set DateTimePicker
            dtpTanggalApproval.Value = Now
            dtpTanggalNota1.Value = Now
            dtpTanggalNota2.Value = Now
        End If

        Security.GetAccess(ClsSession.RoleID, Me.Tag, CanAdd, CanEdit, CanDelete, CanSave)
    End Sub

    Public Sub LoadData()
        Dim dt As New DataTable
        Dim i As Integer = 1
        Dim sql As String = "select * from vwTrnPengajuanPenerimaanNotaInput where cast(TransDate as date) between '" & Format(dtpTanggalNota1.Value, "yyyy-MM-dd") & "' and '" & Format(dtpTanggalNota2.Value, "yyyy-MM-dd") & "'"

        If cboPancang.Text <> "" Then
            sql &= " and IDPancang='" & cboPancang.SelectedValue & "'"
        Else
            MsgBoxCustom.Show("Silakan pilih Pancang terlebih dahulu.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Exit Sub
        End If

        If txtTrip.Text <> "" Then
            sql &= " and Trip='" & txtTrip.Text & "'"
        End If

        If cboKapal.Text <> "" Then
            sql &= " and IDKapal='" & cboKapal.SelectedValue & "'"
        End If

        If rdRSUP.Checked = True Then
            sql &= " and Bongkar='RSUP'"
        ElseIf rdPSG.Checked = True Then
            sql &= " and Bongkar='PSG'"
        ElseIf rdAllTujuan.Checked = True Then
            ' Tidak perlu menambahkan kondisi apapun untuk "All Tujuan"
        End If

        If rdJambul.Checked = True Then
            sql &= " and Jenis='Jambul'"

            If chkA6.Checked = True Then
                sql &= " and GradeSub='A6'"
            Else
                sql &= " and GradeSub='A'"
            End If
        ElseIf rdLicin.Checked = True Then
            sql &= " and Jenis='Licin'"

            If chkA6.Checked = True Then
                sql &= " and GradeSub='A6'"
            Else
                sql &= " and GradeSub='A'"
            End If
        ElseIf rdCungkil.Checked = True Then
            sql &= " and Jenis='Cungkil'"
        ElseIf rdAllJenis.Checked = True Then
            ' Tidak perlu menambahkan kondisi apapun untuk "All Jenis"
        End If

        If rdKBA.Checked = True Then
            sql &= " and JenisKB='KB-A'"
        ElseIf rdKBB.Checked = True Then
            sql &= " and JenisKB='KB-B'"
        ElseIf rdKC.Checked = True Then
            sql &= " and JenisKB='KC'"
        ElseIf rdAllGrade.Checked = True Then
            ' Tidak perlu menambahkan kondisi apapun untuk "All KB"
        End If

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fg
            .Rows.Count = 1 ' Reset grid sebelum mengisi data baru

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "InvoiceNo") = row("NoNota")
                    .Item(i, "TanggalNota") = row("TransDate")
                    .Item(i, "IDPancang") = row("IDPancang")
                    .Item(i, "Pancang") = row("Pancang")
                    .Item(i, "IDKapal") = row("IDKapal")
                    .Item(i, "Kapal") = row("Kapal")
                    .Item(i, "Trip") = row("Trip")
                    .Item(i, "Tujuan") = row("Bongkar")
                    .Item(i, "Jenis") = row("Jenis")
                    .Item(i, "Grade") = row("JenisKB")
                    .Item(i, "GradeSub") = row("GradeSub")
                    .Item(i, "SupplierID") = row("IDPenerimaUang")
                    .Item(i, "SupplierName") = row("penerimaUang")
                    .Item(i, "RekeningName") = row("NamaRekening")
                    .Item(i, "RekeningNo") = row("RekeningPenerima")
                    .Item(i, "RekeningBank") = row("JenisBank")
                    .Item(i, "ItemName") = row("ItemName")
                    .Item(i, "Brutto") = row("Brutto")
                    .Item(i, "TarraJaring") = row("TarraJaring")
                    .Item(i, "Netto1") = row("Netto")
                    .Item(i, "Tarra%") = row("TarraPersen")
                    .Item(i, "Netto2") = row("NettoAkhir")
                    .Item(i, "HargaAwal") = row("HargaSil")
                    .Item(i, "HargaNego") = row("HargaNego")
                    .Item(i, "HargaBeli") = row("Harga")
                    .Item(i, "TotalRPBeforePPH") = 0
                    .Item(i, "PPH%") = 0
                    .Item(i, "PPHRP") = 0
                    .Item(i, "Pinjaman") = row("Pinjaman")
                    .Item(i, "TotalRP") = row("TotalHarga")

                    i += 1
                Next

                fg.Rows.Insert(1)

                Call CountTotal()

                .AutoSizeCols()

                Call AutoGenerateMasterSupplierProgramAcc()
            Else
                MsgBoxCustom.Show("Tidak ada data.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            End If
        End With
    End Sub

    Private Sub AutoGenerateMasterSupplierProgramAcc()
        Dim sql As String

        For i = 2 To fg.Rows.Count - 1
            ' Cek jika belum ada di program Acc
            If DB.ExecuteScalarValue(Of String)(StrConnRMPApp, "select isnull((select SupplierID from DBPancang..tblGENMstSupplier where SupplierID='" & fg.Item(i, "SupplierID") & "'),'') as GetValueString") = "" Then
                sql = "DECLARE @RC int
                        DECLARE @SupplierID varchar(30)
                        DECLARE @SupplierIDPancang varchar(30)
                        DECLARE @SupplierName varchar(250)
                        DECLARE @MitraGroupID varchar(10)=''
                        DECLARE @ContactID bigint=0
                        DECLARE @ContactAddressID bigint=0
                        DECLARE @Address varchar(250)
                        DECLARE @Telephone varchar(100)
                        DECLARE @AppVersion varchar(10)=''
                        DECLARE @CreatedBy varchar(15)=''
                        DECLARE @CreatedDate date=getdate()
                        DECLARE @Flag bigint

                        select 
                        @SupplierID=KodeSup,
                        @SupplierIDPancang=KodeSup,
                        @SupplierName=NamaSup,
                        @Address=Alamat,
                        @Telephone=NoHP
                        from RSUPAccounting..tblRMMstSupplier where KodeSup='" & fg.Item(i, "SupplierID") & "'

                        EXECUTE @RC = DBPancang..GEN_spMstSupplierPancangSave_102025
                           @SupplierID OUTPUT
                          ,@SupplierIDPancang
                          ,@SupplierName
                          ,@MitraGroupID
                          ,@ContactID
                          ,@ContactAddressID
                          ,@Address
                          ,@Telephone
                          ,@AppVersion
                          ,@CreatedBy
                          ,@CreatedDate
                          ,@Flag OUTPUT
                        "

                Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)
            End If
        Next
    End Sub

    Private Sub ShowDataView()
        Dim dt As New DataTable
        Dim i As Integer = 1
        Dim sql As String = "select * from vwTrnPengajuanPenerimaanNotaDtl where NoTrans='" & txtNoTrans.Text & "'"

        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

        With fg
            .Rows.Count = 1 ' Reset grid sebelum mengisi data baru

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, "StatusProses") = row("StatusProses")
                    .Item(i, "InvoiceNo") = row("InvoiceNo")
                    .Item(i, "TanggalNota") = row("TanggalNota")
                    .Item(i, "Trip") = row("Trip")
                    .Item(i, "IDPancang") = row("IDPancang")
                    .Item(i, "Pancang") = row("Pancang")
                    .Item(i, "IDKapal") = row("IDKapal")
                    .Item(i, "Kapal") = row("Kapal")
                    .Item(i, "Tujuan") = row("Tujuan")
                    .Item(i, "Jenis") = row("Jenis")
                    .Item(i, "Grade") = row("Grade")
                    .Item(i, "GradeSub") = row("GradeSub")
                    .Item(i, "SupplierID") = row("SupplierID")
                    .Item(i, "SupplierName") = row("SupplierName")
                    .Item(i, "RekeningName") = row("RekeningName")
                    .Item(i, "RekeningNo") = row("RekeningNo")
                    .Item(i, "RekeningBank") = row("RekeningBank")
                    .Item(i, "ItemName") = row("ItemName")
                    .Item(i, "Brutto") = row("Brutto")
                    .Item(i, "TarraJaring") = row("TarraJaring")
                    .Item(i, "Netto1") = row("Netto1")
                    .Item(i, "Tarra%") = row("TarraPersen")
                    .Item(i, "Netto2") = row("Netto2")
                    .Item(i, "HargaAwal") = row("HargaAwal")
                    .Item(i, "HargaNego") = row("HargaNego")
                    .Item(i, "HargaBeli") = row("HargaBeli")
                    .Item(i, "TotalRPBeforePPH") = row("TotalRpBeforePPH")
                    .Item(i, "PPH%") = row("PPHPersen")
                    .Item(i, "Pinjaman") = row("Pinjaman")
                    .Item(i, "SisaPinjaman") = row("SisaPinjaman")
                    .Item(i, "PPHRP") = row("PPHRp")
                    .Item(i, "TotalRP") = row("TotalRp")

                    i += 1
                Next

                fg.Rows.Insert(1)

                Call CountTotal()

                .AutoSizeCols()
            Else
                FrmTrnPengajuanPenerimaanNota.ShowData()
                FrmTrnPengajuanPenerimaanNota.Show(FrmMain.DockPanel1)
                FrmTrnPengajuanPenerimaanNota.Activate()

                Me.Close()
            End If
        End With
    End Sub

    Private Sub CountTotal()
        ' === HITUNG TOTAL DAN TARUH DI ROW INDEX 1 ===
        Dim totalBrutto As Decimal = 0
        Dim totalTarraJaring As Integer = 0
        Dim totalNetto1 As Integer = 0
        Dim totalNetto2 As Integer = 0
        Dim totalRPBeforePPH As Integer = 0
        Dim totalPPHRP As Integer = 0
        Dim totalRP As Integer = 0
        Dim totalPinjaman As Integer = 0

        For r As Integer = 2 To fg.Rows.Count - 1
            totalBrutto += Val(fg.Item(r, "Brutto"))
            totalTarraJaring += Val(fg.Item(r, "TarraJaring"))
            totalNetto1 += Val(fg.Item(r, "Netto1"))
            totalNetto2 += Val(fg.Item(r, "Netto2"))
            totalRPBeforePPH += Val(fg.Item(r, "TotalRPBeforePPH"))
            totalPPHRP += Val(fg.Item(r, "PPHRP"))
            totalRP += Val(fg.Item(r, "TotalRP"))
            totalPinjaman += Val(fg.Item(r, "Pinjaman"))
        Next

        ' === SET TOTAL DI ROW INDEX 1 ===
        fg.Item(1, "InvoiceNo") = "TOTAL"
        fg.Item(1, "Brutto") = totalBrutto
        fg.Item(1, "TarraJaring") = totalTarraJaring
        fg.Item(1, "Netto1") = totalNetto1
        fg.Item(1, "Netto2") = totalNetto2
        fg.Item(1, "TotalRPBeforePPH") = totalRPBeforePPH
        fg.Item(1, "PPHRP") = totalPPHRP
        fg.Item(1, "TotalRP") = totalRP
        fg.Item(1, "Pinjaman") = totalPinjaman

        ' KASIH WARNA AGAR JELAS BARIS TOTAL
        Dim s = fg.Styles.Add("TotalRow")
        s.BackColor = Color.LightYellow
        s.Font = New Font(fg.Font, FontStyle.Bold)
        fg.Rows(1).Style = s
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        FrmTrnPengajuanPenerimaanNota.ShowData()
        FrmTrnPengajuanPenerimaanNota.Show(FrmMain.DockPanel1)
        FrmTrnPengajuanPenerimaanNota.Activate()
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        CekTotlebih45()
        CekRelasi()

        If CekStatusApproveNotaSimpanLokalDanTanggalTimbangBerbeda() = 1 Then Exit Sub
        If CekStatusNotaTimbangOffline() = 1 Then Exit Sub
        If CekBelumInputHargaNegoPadaNotaFlagHargaNego() = 1 Then Exit Sub
        If CekAdaHargaNegoYangBelumDiApprove() = 1 Then Exit Sub
        If CekAdaIDYangBaruDiEdit() = 1 Then Exit Sub
        If CekRekeningKosong() = 1 Then Exit Sub

        If IndRelasi = 1 Then
            MsgBoxCustom.Show("Ada Relasi yang sudah di NonAktifkan, Mohon periksa kembali data Anda !",
               MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Exit Sub
        End If

        ' Contoh pemisahan logika Indlebih
        If Indlebih > 45 Then
            MsgBoxCustom.Show("Ada relasi '" & tujuan & "' yang lebih dari 45 M!" & vbNewLine &
               "Silahkan edit nota !", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Exit Sub
        ElseIf Indlebih > 4.5 Then
            MsgBoxCustom.Show("Ada relasi '" & tujuan & "' yang lebih dari 4.5 M!" & vbNewLine &
               "Silahkan edit nota !", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Exit Sub
        End If

        Dim result As DialogResult =
        MessageBox.Show("Apakah data sudah benar ?", AT, MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then
            SaveData()
        End If

    End Sub

    Private Function CekRekeningKosong() As Integer

        With fg
            For i = 3 To .Rows.Count - 1

                Dim rekNoObj = .Item(i, "RekeningNo")
                Dim rekNameObj = .Item(i, "RekeningName")

                Dim rekNo As String = If(rekNoObj Is Nothing OrElse IsDBNull(rekNoObj),
                                     "",
                                     rekNoObj.ToString().Trim())

                Dim rekName As String = If(rekNameObj Is Nothing OrElse IsDBNull(rekNameObj),
                                       "",
                                       rekNameObj.ToString().Trim())

                If rekNo = "" OrElse rekName = "" Then
                    MsgBoxCustom.Show("Ada rekening yang kosong, silakan periksa kembali data Anda!",
                       MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                    Return 1
                End If

            Next

            Return 0
        End With
    End Function


    Private Sub CekTotlebih45()
        Dim sql As String
        Dim dt As DataTable = New DataTable()
        Dim dt2 As DataTable = New DataTable()
        Dim dt3 As DataTable = New DataTable()

        Indlebih = 0

        With fg
            For i = 3 To .Rows.Count - 1
                Dim a As String
                a = Strings.Right(.Item(i, 3), 4)
                sql = "WITH CTE AS ( 
						  SELECT SUM(TotalHarga) AS Total 
						  FROM RMPApp..tbltrnkelapahdr where IDRelasi = '" & .Item(i, 9) & "' AND (deleted=0 or deleted is null ) and INDNOTA=0 AND IndUM IN ('0','1') AND Deleted = 0 AND bongkar='" & .Item(i, "Tujuan") & "'
						  And CONVERT(VARCHAR(4),TransDate,126) = '" & Strings.Right(.Item(i, 3), 4) & "'
						  UNION ALL
						  SELECT SUM(TotalHarga) AS Total 
						  FROM RMPApp..TblTrnKelapaHdr where IDRelasi = '" & .Item(i, 9) & "' AND (deleted=0 or deleted is null ) and  INDNOTA=1 AND IndUM IN ('0','1') AND Deleted = 0 AND bongkar='" & .Item(i, "Tujuan") & "'
						  And CONVERT(VARCHAR(4),TglTerima,126) ='" & Strings.Right(.Item(i, 3), 4) & "'
						   )
						  SELECT ISNULL(SUM(Total),0) AS Total FROM CTE"


                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)
                dt2 = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT idpancang  FROM RMPApp..Android_tblMstPancang  WHERE idpancang  = '" & cboPancang.SelectedValue.ToString & "' and  TdkBoleh20 = 1 ")
                dt3 = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT nonpwp  FROM RSUPAccounting..tblrmmstsupplier  WHERE kodesup  = '" & .Item(i, 9) & "' and (chkNPWP='false' or chknpwp='0') and   nonpwp<>'' and nonpwp is not null and nonpwp <>'  .   .   . -   .   ' ")

                If (dt.Rows(0).Item("Total")) >= 4500000000 And dt2.Rows.Count > 0 And dt3.Rows.Count = 0 And .Item(i, 39) = False Then
                    Indlebih = 1
                    tujuan = .Item(i, "Tujuan")
                    .Rows(i).StyleNew.BackColor = Color.Red
                    .Rows(i).StyleNew.ForeColor = Color.White
                End If


            Next
        End With
    End Sub

    Private Sub CekRelasi()
        Dim sql As String
        Dim dt As DataTable = New DataTable()

        IndRelasi = 0

        With fg
            For i = 3 To .Rows.Count - 1

                sql = "select RMPSupplierID,RMPSupplierName from vwAndroid_MstPancang WHERE (NotActive = 1) AND RMPSupplierID = '" & .Item(i, 9) & "' "

                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

                If dt.Rows.Count > 0 And (.Item(i, 27) = True Or .Item(i, 27) = 1) Then
                    IndRelasi = 1
                    .Rows(i).StyleNew.BackColor = Color.Red
                    .Rows(i).StyleNew.ForeColor = Color.White
                End If
            Next
        End With
    End Sub

    Private Function CekStatusApproveNotaSimpanLokalDanTanggalTimbangBerbeda() As Integer
        If fg.Rows.Count > 1 Then
            For i = 2 To fg.Rows.Count - 1
                If DB.ExecuteScalarValue(Of String)(StrConnRMPApp, " select isnull((select TransID from TblTrnKelapaHdr where TransID='" & fg.Item(i, 40) & "' and ((isnull(flagnotasimpanlocal,0)=1 and isnull(approve_simpan_local,0)=0) or (isnull(flagtanggaltimbang,0)=1 and isnull(approve_tanggal_timbang,0)=0))),0) as GetValueString ") <> "0" Then
                    MsgBoxCustom.Show("No Nota " & fg.Item(i, 1) & ", Belum Approve Simpan Nota Lokal/Tanggal Timbang Berbeda.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                    Return 1
                    Exit Function
                End If
            Next
        End If

        Return 0
    End Function

    Private Function CekStatusNotaTimbangOffline() As Integer
        If fg.Rows.Count > 1 Then
            For i = 2 To fg.Rows.Count - 1
                If DB.ExecuteScalarValue(Of String)(StrConnRMPApp, " select isnull((select TransID from TblTrnKelapaHdr where TransID='" & fg.Item(i, 40) & "' and (isnull(flagnointernet,0)=1 and isnull(approve_no_internet,0)=0)),0) as GetValueString ") <> "0" Then
                    MsgBoxCustom.Show("No Nota " & fg.Item(i, 1) & ", Belum Approve Timbang Offline.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                    Return 1
                    Exit Function
                End If
            Next
        End If

        Return 0
    End Function

    Private Function CekBelumInputHargaNegoPadaNotaFlagHargaNego() As Integer
        Dim result As Integer = 0

        If fg.Rows.Count > 1 Then
            For i = 2 To fg.Rows.Count - 1
                If fg.Item(i, 28) = True Then
                    If DB.ExecuteScalarValue(Of String)(StrConnRMPApp, " select isnull((select a.TransID from RMPApp..TblTrnKelapaHdr as a INNER JOIN RMPApp..Android_tblSupplierPelangsir AS B ON A.supplier_pelangsir_id = B.id where a.TransID='" & fg.Item(i, 40) & "' and b.flag_harga_nego=1 and isnull(a.HargaNego,0)=0),0) as GetValueString ") <> "0" Then
                        If MsgBoxCustom.Show("No Nota " & fg.Item(i, 1) & " Belum Di Input Harga Nego, Klik ( Yes ) Jika Ingin Melanjutkan.", MsgBoxCustom.ButtonType.YesNo, MsgBoxCustom.IconType.Information) = vbNo Then
                            result = 1
                            Exit For
                        Else
                            result = 0
                        End If
                    End If
                End If
            Next
        End If

        Return result
    End Function
    Private Function CekAdaHargaNegoYangBelumDiApprove() As Integer
        Dim result As Integer = 0

        If fg.Rows.Count > 1 Then
            For i = 2 To fg.Rows.Count - 1
                If fg.Item(i, 28) = True Then
                    If DB.ExecuteScalarValue(Of String)(StrConnRMPApp, " select isnull((select TransID from RMPApp..TblTrnKelapaHdr where TransID='" & fg.Item(i, 40) & "' and isnull(HargaNego,0)<>0 and isnull(ApproveHargaNegoFlag,0)<2 and isnull(NotApproveHargaNegoFlag,0)=0),0) as GetValueString ") <> "0" Then
                        MsgBoxCustom.Show("No Nota " & fg.Item(i, 1) & " Harga Nego Nya Belum Di Approve.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                        result = 1
                        Exit For
                    End If
                End If
            Next
        End If

        Return result
    End Function

    Private Function CekAdaIDYangBaruDiEdit() As Integer
        Dim result As Integer = 0

        If fg.Rows.Count > 1 Then
            For i = 2 To fg.Rows.Count - 1
                If fg.Item(i, 28) = True Then 'chk um = true
                    If DB.ExecuteScalarValue(Of Integer)(StrConnRMPApp, "select isnull((select TransID from RMPApp..TblTrnKelapaHdr where TransID=" & fg.Item(i, 40) & " and IDRelasi='" & fg.Item(i, 9) & "' and IDPenerimaUang='" & fg.Item(i, 12) & "' and IDSubPetani='" & fg.Item(i, 15) & "'),0) as GetValueInteger") = 0 Then
                        MsgBoxCustom.Show("No Nota " & fg.Item(i, 1) & " Baru Di Edit, Silahkan Tarik Data Ulang.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                        result = 1
                        Exit For
                    End If
                End If
            Next
        End If

        Return result
    End Function

    Private Sub SaveData()
        ' === Deklarasi koneksi dan transaksi ===
        Dim Conn As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnRMPApp)
        Dim Trans As SqlTransaction = Conn.BeginTransaction()
        Dim NoTrans As String = ""
        Dim errMsg As String = ""

        If MsgBoxCustom.Show("Apakah Anda yakin ingin menyimpan data ini?", MsgBoxCustom.ButtonType.YesNo, MsgBoxCustom.IconType.Question) = vbNo Then
            Exit Sub
        End If

        ' === Validasi awal ===
        'If txtTrip.Text = "" Then
        '    MsgBoxCustom.Show("Silakan isi No Trip terlebih dahulu.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
        '    Exit Sub
        'End If

        If cboPancang.Text = "" Then

            MsgBoxCustom.Show("Silakan pilih Pancang terlebih dahulu.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Exit Sub
        End If

        'If cboKapal.Text = "" Then
        '    MsgBoxCustom.Show("Silakan pilih Kapal terlebih dahulu.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
        '    Exit Sub
        'End If

        ' cek jika tidak ada data ajukan = true
        Dim isAnyAjukan As Boolean = False
        For r As Integer = 2 To fg.Rows.Count - 1
            If fg.Item(r, "Ajukan") = True Then
                isAnyAjukan = True
                Exit For
            End If
        Next
        If Not isAnyAjukan And StatusOpenForm = "Add" Then
            MsgBoxCustom.Show("Tidak ada data yang diajukan untuk disimpan.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        Try
            If StatusOpenForm = "Add" Then
                ' === 1. Simpan HEADER ===
                NoTrans = SaveHdr(Conn, Trans)
                If String.IsNullOrEmpty(NoTrans) Then
                    Throw New Exception("Simpan Data Header Gagal!")
                End If

                ' === 2. Simpan DETAIL ===
                For r As Integer = 2 To fg.Rows.Count - 1
                    If fg.Item(r, "Ajukan") = True Then

                        If SaveDtl(Conn, Trans, NoTrans, r, errMsg) = False Then
                            Throw New Exception(errMsg)
                        End If

                        'If SaveAutoGenerateNpbbDanBtb(Conn, Trans, r) = False Then
                        '    Throw New Exception("Gagal Auto Generate BPBB dan BTB pada baris ke-" & r)
                        'End If

                    End If
                Next
            ElseIf StatusOpenForm = "Edit" Then
                ' === 2. Simpan DETAIL ===
                For r As Integer = 2 To fg.Rows.Count - 1
                    If CInt(fg.Item(r, "Pinjaman")) > 0 Then

                        If SaveDtl(Conn, Trans, NoTrans, r, errMsg) = False Then
                            Throw New Exception(errMsg)
                        End If

                        'If SaveAutoGenerateNpbbDanBtb(Conn, Trans, r) = False Then
                        '    Throw New Exception("Gagal Auto Generate BPBB dan BTB pada baris ke-" & r)
                        'End If

                    End If
                Next
            End If

            ' === 3. Commit jika semua sukses ===
            Trans.Commit()
            MsgBoxCustom.Show("Data berhasil disimpan dengan No. Trans: " & NoTrans, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)

            FrmTrnPengajuanPenerimaanNota.ShowData()
            FrmMain.BukaMenu(FrmTrnPengajuanPenerimaanNota, FrmMain.mnuTrnPengajuanPenerimaanNota)
            FrmTrnPengajuanPenerimaanNota.Activate()

            Me.Close()
        Catch ex As Exception
            ' === Rollback jika ada error ===
            Try
                Trans.Rollback()
            Catch
            End Try

            MsgBoxCustom.Show("Error: " & ex.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)

        Finally
            ' === Tutup koneksi dan kembalikan cursor ===
            If Conn.State = ConnectionState.Open Then Conn.Close()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function SaveHdr(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As String

        SaveHdr = ""

        Dim Jenis As String = ""
        If rdJambul.Checked = True Then
            Jenis = "Jambul"
        ElseIf rdLicin.Checked = True Then
            Jenis = "Licin"
        ElseIf rdCungkil.Checked = True Then
            Jenis = "Cungkil"
        End If

        Try
            Using cmd As New SqlCommand("spTrnPengajuanPenerimaanNotaHdr", Conn, Trans)
                cmd.CommandType = CommandType.StoredProcedure

                ' INPUT PARAMETERS (langsung Add)
                cmd.Parameters.Add("@TanggalApproval", SqlDbType.Date).Value = dtpTanggalApproval.Value
                cmd.Parameters.Add("@TanggalNota1", SqlDbType.Date).Value = dtpTanggalNota1.Value
                cmd.Parameters.Add("@TanggalNota2", SqlDbType.Date).Value = dtpTanggalNota2.Value
                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 100).Value = ClsSession.UserID
                cmd.Parameters.Add("@IndPECU", SqlDbType.VarChar, 100).Value = 0

                ' OUTPUT PARAMETERS
                cmd.Parameters.Add("@NoTrans", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                cmd.Parameters.Add("@Flag", SqlDbType.Int).Direction = ParameterDirection.Output

                ' EXECUTE SP
                cmd.ExecuteNonQuery()

                ' GET OUTPUT RESULTS
                Dim resultFlag As Integer = CInt(cmd.Parameters("@Flag").Value)
                Dim newNoTrans As String = cmd.Parameters("@NoTrans").Value.ToString()

                If resultFlag = 1 Then
                    SaveHdr = newNoTrans
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

    Private Function SaveDtl(ByVal Conn As SqlConnection,
                          ByVal Trans As SqlTransaction,
                          ByVal NoTrans As String,
                          ByVal r As Integer,
                          ByRef OutMessage As String) As Boolean

        SaveDtl = False
        OutMessage = ""

        Try
            Using cmd As New SqlCommand("spTrnPengajuanPenerimaanNotaDtl", Conn, Trans)
                cmd.CommandType = CommandType.StoredProcedure

                ' ================================
                '  Parameter input dari datagrid
                ' ================================
                cmd.Parameters.Add("@NoTrans", SqlDbType.VarChar, 50).Value = NoTrans
                cmd.Parameters.Add("@Perintah", SqlDbType.VarChar, 50).Value = StatusOpenForm
                cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar, 50).Value = fg.Item(r, "InvoiceNo")
                cmd.Parameters.Add("@TanggalNota", SqlDbType.Date).Value = fg.Item(r, "TanggalNota")
                cmd.Parameters.Add("@SupplierID", SqlDbType.VarChar, 50).Value = fg.Item(r, "SupplierID")
                cmd.Parameters.Add("@SupplierName", SqlDbType.VarChar, 200).Value = fg.Item(r, "SupplierName")
                cmd.Parameters.Add("@ItemName", SqlDbType.VarChar, 30).Value = fg.Item(r, "ItemName")

                cmd.Parameters.Add("@Brutto", SqlDbType.Decimal).Value = CDec(fg.Item(r, "Brutto"))
                cmd.Parameters.Add("@TarraJaring", SqlDbType.Decimal).Value = CDec(fg.Item(r, "TarraJaring"))
                cmd.Parameters.Add("@Netto1", SqlDbType.Decimal).Value = CDec(fg.Item(r, "Netto1"))
                cmd.Parameters.Add("@TarraPersen", SqlDbType.Decimal).Value = CDec(fg.Item(r, "Tarra%"))
                cmd.Parameters.Add("@Netto2", SqlDbType.Decimal).Value = CDec(fg.Item(r, "Netto2"))

                cmd.Parameters.Add("@HargaAwal", SqlDbType.Decimal).Value = CDec(fg.Item(r, "HargaAwal"))
                cmd.Parameters.Add("@HargaNego", SqlDbType.Decimal).Value = CDec(fg.Item(r, "HargaNego"))
                cmd.Parameters.Add("@HargaBeli", SqlDbType.Decimal).Value = CDec(fg.Item(r, "HargaBeli"))

                cmd.Parameters.Add("@TotalRpBeforePPH", SqlDbType.Decimal).Value = CDec(fg.Item(r, "TotalRpBeforePPH"))
                cmd.Parameters.Add("@PPHPersen", SqlDbType.Decimal).Value = CDec(fg.Item(r, "PPH%"))
                cmd.Parameters.Add("@PPHRp", SqlDbType.Decimal).Value = CDec(fg.Item(r, "PPHRp"))
                cmd.Parameters.Add("@TotalRp", SqlDbType.Decimal).Value = CDec(fg.Item(r, "TotalRp"))

                cmd.Parameters.Add("@IDPancang", SqlDbType.Int).Value = CInt(fg.Item(r, "IDPancang"))
                cmd.Parameters.Add("@IDKapal", SqlDbType.Int).Value = CInt(IIf(IsDBNull(fg.Item(r, "IDKapal")), 0, fg.Item(r, "IDKapal")))
                cmd.Parameters.Add("@Trip", SqlDbType.Int).Value = CInt(IIf(IsDBNull(fg.Item(r, "Trip")), 0, fg.Item(r, "Trip")))

                cmd.Parameters.Add("@Tujuan", SqlDbType.VarChar, 50).Value = fg.Item(r, "Tujuan")
                cmd.Parameters.Add("@Jenis", SqlDbType.VarChar, 50).Value = fg.Item(r, "Jenis")
                cmd.Parameters.Add("@Grade", SqlDbType.VarChar, 10).Value = fg.Item(r, "Grade")
                cmd.Parameters.Add("@GradeSub", SqlDbType.VarChar, 10).Value = fg.Item(r, "GradeSub")

                cmd.Parameters.Add("@RekeningName", SqlDbType.VarChar, 150).Value = fg.Item(r, "RekeningName")
                cmd.Parameters.Add("@RekeningNo", SqlDbType.VarChar, 50).Value = fg.Item(r, "RekeningNo")
                cmd.Parameters.Add("@RekeningBank", SqlDbType.VarChar, 50).Value = fg.Item(r, "RekeningBank")

                cmd.Parameters.Add("@Pinjaman", SqlDbType.Decimal).Value = CDec(fg.Item(r, "Pinjaman"))

                ' ================================
                '  CreatedBy
                ' ================================
                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID

                ' ================================
                '  Output parameter
                ' ================================
                cmd.Parameters.Add("@Flag", SqlDbType.Int).Direction = ParameterDirection.Output
                cmd.Parameters.Add("@Message", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output

                ' ================================
                '  Execute
                ' ================================
                cmd.ExecuteNonQuery()

                Dim resultFlag As Integer = CInt(cmd.Parameters("@Flag").Value)
                OutMessage = cmd.Parameters("@Message").Value.ToString()

                If resultFlag = 1 Then
                    SaveDtl = True
                Else
                    SaveDtl = False
                End If
            End Using

        Catch ex As Exception
            OutMessage = "Error saat simpan detail: " & ex.Message
            SaveDtl = False
        End Try

        Return SaveDtl
    End Function

    Private Function SaveAutoGenerateNpbbDanBtb(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal r As Integer) As Boolean

        SaveAutoGenerateNpbbDanBtb = False

        Try
            Using cmd As New SqlCommand("RMPApp..sp_AutoGenerateNpbbDanBtb", Conn, Trans)
                cmd.CommandType = CommandType.StoredProcedure

                ' ==========================
                '   PARAMETER INPUT
                ' ==========================

                cmd.Parameters.Add("@InvoiceDate", SqlDbType.Date).Value = dtpTanggalApproval.Value
                cmd.Parameters.Add("@SupplierID", SqlDbType.VarChar, 20).Value = fg.Item(r, "SupplierID").ToString
                cmd.Parameters.Add("@IDPancang", SqlDbType.Int).Value = cboPancang.SelectedValue
                cmd.Parameters.Add("@AppVersion", SqlDbType.VarChar, 10).Value = My.Application.Info.Version.ToString() ' <-- sesuaikan variable anda
                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 15).Value = ClsSession.UserID
                cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar, 50).Value = fg.Item(r, "InvoiceNo").ToString
                cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = CDec(fg.Item(r, "TotalRp"))
                cmd.Parameters.Add("@PPH22", SqlDbType.Decimal).Value = CDec(fg.Item(r, "PPHRP"))
                cmd.Parameters.Add("@ItemName", SqlDbType.VarChar, 20).Value = fg.Item(r, "ItemName").ToString
                cmd.Parameters.Add("@QntyBuy", SqlDbType.Decimal).Value = CDec(fg.Item(r, "Netto2"))
                cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = CDec(fg.Item(r, "HargaBeli"))

                ' ==========================
                '   PARAMETER OUTPUT
                ' ==========================
                cmd.Parameters.Add("@Flag", SqlDbType.Int).Direction = ParameterDirection.Output

                ' ==========================
                '   EXECUTE
                ' ==========================
                cmd.ExecuteNonQuery()

                Dim resultFlag As Integer = CInt(cmd.Parameters("@Flag").Value)
                If resultFlag = 1 Then
                    SaveAutoGenerateNpbbDanBtb = True
                End If

            End Using

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return SaveAutoGenerateNpbbDanBtb
    End Function

    Private Sub btnFindNota_Click(sender As Object, e As EventArgs) Handles btnFindNota.Click
        FrmTrnPengajuanPenerimaanNotaInputFindNota.ShowDialog() ' LoadData()
    End Sub

    Private Sub fg_SelChange(sender As Object, e As EventArgs) Handles fg.SelChange
        Dim grid As C1.Win.C1FlexGrid.C1FlexGrid = CType(sender, C1.Win.C1FlexGrid.C1FlexGrid)

        txtTotal.Text = ClsFunction.FormatNum(grid.Aggregate(AggregateEnum.Sum), 2)
    End Sub

    Private Sub fg_AfterEdit(sender As Object, e As RowColEventArgs) Handles fg.AfterEdit
        With fg
            If .Cols(e.Col).Name = "Pinjaman" Then
                If IsNumeric(.Item(e.Row, "Pinjaman")) Then
                    If CInt(.Item(e.Row, "Pinjaman")) <= CInt(.Item(e.Row, "TotalRp")) Then
                        .Item(e.Row, "Pinjaman") = CInt(.Item(e.Row, "Pinjaman"))
                        .Item(e.Row, "TotalRp") = CInt(.Item(e.Row, "Netto2")) * CInt(.Item(e.Row, "HargaBeli")) - CInt(.Item(e.Row, "Pinjaman"))
                    Else
                        MsgBoxCustom.Show("Input Pinjaman tidak boleh lebih besar dari Total Rp!", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                        .Item(e.Row, "Pinjaman") = 0
                    End If
                Else
                    MsgBoxCustom.Show("Input Pinjaman harus berupa angka!", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                    .Item(e.Row, "Pinjaman") = 0
                End If

                Call CountTotal()
            End If
        End With
    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg.BeforeEdit
        Dim colName As String = fg.Cols(e.Col).Name

        Select Case StatusOpenForm
            Case "Add"
                e.Cancel = (colName <> "Ajukan")
            Case "View"
                e.Cancel = (colName <> "Select")
            Case "Edit"
                e.Cancel = (colName <> "Pinjaman")
            Case Else
                e.Cancel = True
        End Select
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If CanDelete = False Then
            MsgBoxCustom.Show("Anda tidak memiliki hak untuk menghapus data ini.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Exit Sub
        End If

        With fg

            ' --- Cek jika tidak ada yang dipilih ---
            Dim isAnySelected As Boolean = False
            For r = 2 To .Rows.Count - 1
                If .Item(r, "Select") = True Then
                    isAnySelected = True
                    Exit For
                End If
            Next

            If Not isAnySelected Then
                MsgBoxCustom.Show("Tidak ada data yang dipilih untuk dihapus.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                Exit Sub
            End If

            If MsgBoxCustom.Show("Apakah anda yakin ingin menghapus data yang dipilih?", MsgBoxCustom.ButtonType.YesNo, MsgBoxCustom.IconType.Question) = DialogResult.No Then
                Exit Sub
            End If

            ' ==========================
            '  INPUT KETERANGAN DELETE
            ' ==========================
            Dim fr As New FrmKeteranganDelete
            Dim KeteranganDelete As String = ""

            If fr.ShowDialog() = DialogResult.OK Then
                KeteranganDelete = fr.ResultText
            End If

            If KeteranganDelete.Trim = "" Then
                MsgBoxCustom.Show("Delete Data Gagal.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                Exit Sub
            End If

            ' ================================================
            ' ========== MULAI TRANSAKSI DATABASE ============
            ' ================================================
            Using Conn As New SqlConnection(StrConnRMPApp)
                Conn.Open()
                Dim Trans As SqlTransaction = Conn.BeginTransaction()

                Dim isRolledBack As Boolean = False

                Try
                    For r = 2 To .Rows.Count - 1

                        If .Item(r, "Select") = True Then

                            Dim invoice As String = .Item(r, "InvoiceNo")

                            Dim sql As String =
                            "IF exists (select 1 from DBPancang..tblGLTrnFaktur where NoFaktur=@InvoiceNo) 
                            BEGIN
                                SELECT 1
                            END
                            ELSE
                            BEGIN
                                EXEC RMPApp..sp_TrnApprovalPenerimaanDelete 
                                    @InvoiceNo, @KeteranganDelete, @UserID, @Version, 0
                                SELECT 2
                            END"

                            Using cmd As New SqlCommand(sql, Conn, Trans)
                                cmd.Parameters.AddWithValue("@InvoiceNo", invoice)
                                cmd.Parameters.AddWithValue("@KeteranganDelete", KeteranganDelete)
                                cmd.Parameters.AddWithValue("@UserID", ClsSession.UserID)
                                cmd.Parameters.AddWithValue("@Version", My.Application.Info.Version.ToString)

                                Dim result As Integer = CInt(cmd.ExecuteScalar())

                                If result = 1 Then
                                    ' ==== INI ROLLBACK, STOP LOOP! ====
                                    Trans.Rollback()
                                    isRolledBack = True

                                    MsgBoxCustom.Show("Data dengan No. Invoice: " & invoice &
                                           " sudah diproses, tidak dapat dihapus.",
                                           MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)

                                    Exit For   ' ← WAJIB, AGAR TIDAK ERROR!
                                End If

                            End Using
                        End If
                    Next

                    ' =====================
                    ' COMMIT TRANSAKSI
                    ' =====================
                    If Not isRolledBack Then
                        Trans.Commit()

                        MsgBoxCustom.Show("Proses hapus selesai.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
                        Call ShowDataView()
                    End If

                Catch ex As Exception

                    If Not isRolledBack Then
                        Trans.Rollback()
                    End If

                    MsgBoxCustom.Show("Terjadi kesalahan: " & ex.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
                End Try
            End Using

        End With
    End Sub

    Private Sub rdAllAjukan_CheckedChanged(sender As Object, e As EventArgs) Handles rdAllAjukan.CheckedChanged
        If fg.Rows.Count > 1 Then
            For r = 2 To fg.Rows.Count - 1
                fg.Item(r, "Ajukan") = rdAllAjukan.Checked
            Next
        End If
    End Sub
End Class