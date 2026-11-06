
Imports System.Data.SqlClient
Imports System.IO
Imports System.Data
Imports System.ComponentModel
Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Globalization

Public Class FrmTrnTukarPoin
    Public AT As String = "RMPApplication ©" & Format(Year(Now))
    Dim Conn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim Kode As String
    Dim str As String
    
    Public perintah As String
    Dim NoTransUpahBongkar_ As String
    Dim NoInvoice_ As String
    Private Sub FrmTrnTukarPoin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpInvoice.Value = Format(Now, "dd/MM/yy")
        btnexit.Enabled = True
        Modul_RMP.Combo.SetSupplier(cmbS_Petani)
    End Sub

    Public Sub loaddata(noinvoice As String)
        Try
            Dim SQL As String, i As Integer
            Dim COUNTKAPAL As Integer
            COUNTKAPAL = 0


            SQL = " select * from vw_RM_trnpenukaranpointverifikasi where  Manual_='1' and NoInvoice='" & noinvoice & "' "

            Using koneksi As New SqlCommand(SQL, DB.OpenConnection(StrConnRMPApp))
                Using DR = koneksi.ExecuteReader()
                    If DR.HasRows Then
                        dgvList.Rows.Clear()

                        While DR.Read
                            With dgvList
                                .Rows.Add()
                                COUNTKAPAL = COUNTKAPAL + 1
                                txtinvoice.Text = DR!noinvoice
                                dtpInvoice.Value = DR!tglinvoice

                                .Item("no", i).Value = i + 1
                                .Item("DetailID", i).Value = DR!DetailID
                                .Item("IDPetani", i).Value = DR!IDPetani
                                .Item("Petani", i).Value = DR!NamaPetani
                                .Item("AlamatID", i).Value = DR!AlamatLengkap
                                .Item("Keterangan", i).Value = DR!Keterangan
                                .Item("NoHp", i).Value = DR!NoHP

                                .Item("JumlahPoint", i).Value = DR!TotalPoinBeforeCashBack
                                .Item("RpPoint", i).Value = DR!RpTotalPoinBeforeCashBack
                                .Item("HargaPoint", i).Value = DR!Harga
                                .Item("NoReffHarga", i).Value = DR!NoReffHarga
                                .Item("JumlahPoinCashBack", i).Value = DR!TotalPoinCashBack
                                .Item("RpCashBack", i).Value = DR!RPTotalPoinCashBack

                                GetMasterPancang(DR!IDPetani)
                                GetMasterRek(DR!IDPetani)
                                .Item("Sering_antar_IDPancang", i).Value = DR!Sering_antar_IDPancang
                                .Item("IDNoRek", i).Value = DR!IDNoRek

                                With Me.dgvList
                                    .RowsDefaultCellStyle.BackColor = Color.White
                                    .AlternatingRowsDefaultCellStyle.BackColor = Color.Azure
                                    .Rows(i).Cells("No").Style.BackColor = Color.FromArgb(240, 240, 240)
                                End With
                            End With
                            i += 1
                        End While

                        dgvList.Rows.Add()
                        Call sumpoin()
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



    Public Sub sumpoin()

        Try
            Dim JumlahPoint As Double = 0
            Dim RpPoint As Double = 0

            Dim JumlahPointCB As Double = 0
            Dim RpPointCB As Double = 0


            For i = 0 To dgvList.RowCount - 2
                JumlahPoint += (If(Val(dgvList.Rows(i).Cells("JumlahPoint").Value()) = 0, 0, Convert.ToDouble(dgvList.Rows(i).Cells("JumlahPoint").Value())))
                RpPoint += (If(Val(dgvList.Rows(i).Cells("RpPoint").Value()) = 0, 0, Convert.ToDouble(dgvList.Rows(i).Cells("RpPoint").Value())))
                JumlahPointCB += (If(Val(dgvList.Rows(i).Cells("JumlahPoinCashBack").Value()) = 0, 0, Convert.ToDouble(dgvList.Rows(i).Cells("JumlahPoinCashBack").Value())))
                RpPointCB += (If(Val(dgvList.Rows(i).Cells("RpCashBack").Value()) = 0, 0, Convert.ToDouble(dgvList.Rows(i).Cells("RpCashBack").Value())))

            Next

            dgvList.Rows(dgvList.RowCount - 1).Cells(0).Value = "Total"
            dgvList.Rows(dgvList.RowCount - 1).Cells("JumlahPoint").Value() = JumlahPoint
            dgvList.Rows(dgvList.RowCount - 1).Cells("RpPoint").Value() = RpPoint
            dgvList.Rows(dgvList.RowCount - 1).Cells("JumlahPoinCashBack").Value() = JumlahPointCB
            dgvList.Rows(dgvList.RowCount - 1).Cells("RpCashBack").Value() = RpPointCB

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

    Sub GetMasterRek(ByVal idpetani As String)
        Dim dt As DataTable
        Dim cboKet As DataGridViewComboBoxColumn = dgvList.Columns.Item("IDNoRek")
        dt = DB.ExecuteQuery(StrConnRMPApp,"Select Norekening, IDNorek,   NamaRekening + ' | ' + isnull(IDPetani,'') + ' | ' + isnull(Petani,'') + ' | '  +  NoRekening + ' | ' +  Norekening + ' | ' + isnull(JenisBank,'')   As NamaRek  from RSUPAccounting..vwRMMstRekRM where idpetani='" & idpetani & "' and  InActive=0 order by NamaRekening ASC ")
        cboKet.DisplayMember = "NamaRek"
        cboKet.ValueMember = "IDNorek"
        cboKet.DataSource = dt
    End Sub

    Sub GetMasterPancang(idsubpetani As String)
        Dim dt2 As DataTable
        Dim cboPCG As DataGridViewComboBoxColumn = dgvList.Columns.Item("Sering_antar_IDPancang")
        dt2 = DB.ExecuteQuery(StrConnRMPApp,"with countdata as ( " &
        "select count(idpancang) As countdata  from RMPApp..TblTrnKelapaHdr where idsubpetani='" & idsubpetani & "' and deleted=0) " &
        "Select  CAST(idpancang AS int) AS Sering_antar_IDPancang, Pancang + ' | ' + LEFT(cast ( round(cast(count(idpancang) as decimal(18,2))/cast((select countdata  from countdata) as decimal(18,2)) *100,4) as varchar(50) ),5) + ' % ' as Pancang " &
        "from RMPApp..TblTrnKelapaHdr  " &
        "where idsubpetani='" & idsubpetani & "' " &
        "And deleted=0 " &
        "group by idpancang, Pancang ORDER BY count(idpancang) DESC ")
        cboPCG.DisplayMember = "Pancang"
        cboPCG.ValueMember = "Sering_antar_IDPancang"
        cboPCG.DataSource = dt2
    End Sub


    Sub GetMasterRekFIND(ByVal IDNOREK As Integer)
        Dim dt As DataTable
        Dim cboKet As DataGridViewComboBoxColumn = dgvList.Columns.Item("IDNoRek")
        dt = DB.ExecuteQuery(StrConnRMPApp,"Select Norekening, IDNorek,   NamaRekening + ' | ' + isnull(IDPetani,'') + ' | ' + isnull(Petani,'') + ' | '  +  NoRekening + ' | ' +  Norekening + ' | ' + isnull(JenisBank,'')   As NamaRek  from RSUPAccounting..vwRMMstRekRM where InActive=0 AND IDNOREK='" & IDNOREK & "'  order by NamaRekening ASC ")
        cboKet.DisplayMember = "NamaRek"
        cboKet.ValueMember = "IDNorek"
        cboKet.DataSource = dt
    End Sub

    Sub GetMasterPancangkFIND(ByVal IDPANCANG As String)
        Dim dt As DataTable
        Dim cboPCG As DataGridViewComboBoxColumn = dgvList.Columns.Item("Pancang")
        dt = DB.ExecuteQuery(StrConnRMPApp,"Select IDPancang, Pancang from RMPApp..Android_tblMstPancang  where IDPancang <>40 AND IDPANCANG='" & IDPANCANG & "' ")
        cboPCG.DisplayMember = "Pancang"
        cboPCG.ValueMember = "IDPancang"
        cboPCG.DataSource = dt
    End Sub

    Private Function SavePointLoyaltyHdr(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        Dim MyCMD As New SqlCommand
        Try
            With MyCMD
                SavePointLoyaltyHdr = False
                Dim MyCon As SqlConnection = Conn
                Dim MyConTrans As SqlTransaction = Trans
                .Connection = MyCon
                .CommandType = CommandType.StoredProcedure
                .CommandText = "RMPApp..sp_RMTrnPenukaranPoinHdrManual"
                .Transaction = MyConTrans
                .Parameters.Add("@RETURN_VALUE", SqlDbType.SmallInt).Direction = ParameterDirection.ReturnValue
                .Parameters.Add("@Perintah", SqlDbType.VarChar, 10).Value = perintah
                .Parameters.Add(New SqlParameter("@NoInvoice", SqlDbType.VarChar, 20, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
                .Parameters.Add("@NoInvoice2", SqlDbType.VarChar, 30).Value = txtinvoice.Text
                .Parameters.Add("@tglinvoice", SqlDbType.DateTime).Value = dtpInvoice.Value
                .Parameters.Add("@tglcashback1", SqlDbType.DateTime).Value = dtpInvoice.Value
                .Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
                .Parameters.Add(New SqlParameter("@Error", SqlDbType.VarChar, 200, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
                .ExecuteNonQuery()
                If perintah = "Add" Then
                    NoInvoice_ = .Parameters("@NoInvoice").Value
                Else
                    NoInvoice_ = .Parameters("@NoInvoice2").Value
                End If
                .Dispose()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message & " infosp : " & MyCMD.Parameters("@Error").Value)
            Return False
        End Try
        Return True
    End Function

    Private Function SavePointLoyaltyDtl(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal I As Integer) As Boolean
        Dim MyCMD As New SqlCommand
        With MyCMD

            SavePointLoyaltyDtl = False
            Dim MyCon As SqlConnection = Conn
            Dim MyConTrans As SqlTransaction = Trans
            .Connection = MyCon
            .Connection = MyCon
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RMPApp..sp_RMTrnPenukaranPoinDtlManual"
            .Transaction = MyConTrans
            .Parameters.Add("@RETURN_VALUE", SqlDbType.SmallInt).Direction = ParameterDirection.ReturnValue
            .Parameters.Add("@tglinvoice", SqlDbType.DateTime).Value = dtpInvoice.Value
            .Parameters.Add(New SqlParameter("@noreff", SqlDbType.VarChar, 20, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .Parameters.Add("@IDPetani", SqlDbType.VarChar, 30).Value = dgvList.Item("IDPetani", I).Value
            .Parameters.Add("@NamaPetani", SqlDbType.VarChar, 30).Value = dgvList.Item("Petani", I).Value
            .Parameters.Add("@NoInvoice", SqlDbType.VarChar, 30).Value = NoInvoice_
            .Parameters.Add("@AlamatLengkap", SqlDbType.VarChar, 30).Value = dgvList.Item("AlamatID", I).Value
            .Parameters.Add("@NoHp", SqlDbType.VarChar, 30).Value = dgvList.Item("NoHp", I).Value
            .Parameters.Add("@Sering_antar_IDPancang", SqlDbType.VarChar, 30).Value = dgvList.Item("Sering_antar_IDPancang", I).Value
            .Parameters.Add("@IDNoRek", SqlDbType.VarChar, 30).Value = dgvList.Item("IDNoRek", I).Value
            .Parameters.Add("@TotalPoinBeforeCashBack", SqlDbType.Decimal, 18, 2).Value = dgvList.Item("JumlahPoint", I).Value
            .Parameters.Add("@RpTotalPoinBeforeCashBack", SqlDbType.Decimal, 18, 2).Value = dgvList.Item("RpPoint", I).Value
            .Parameters.Add("@TotalPoinCashBack", SqlDbType.Decimal, 18, 2).Value = dgvList.Item("JumlahPoinCashBack", I).Value
            .Parameters.Add("@RPTotalPoinCashBack", SqlDbType.Decimal, 18, 2).Value = dgvList.Item("RpCashBack", I).Value
            .Parameters.Add("@Keterangan", SqlDbType.VarChar, 50).Value = dgvList.Item("Keterangan", I).Value
            .Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
            .Parameters.Add("NoReffHarga", SqlDbType.VarChar, 30).Value = dgvList.Item("NoReffHarga", I).Value
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

        Try
            Dim SQL As String, i As Integer, SQL2 As String
            Dim COUNTKAPAL As Integer
            COUNTKAPAL = 0

            If chkS_Petani.Checked = True Then
                SQL2 = Modul_RMP.Func.SetCondition(SQL2, " IDSubPetani = '" & cmbS_Petani.SelectedValue.ToString & "'")

            End If

            SQL = " declare @harganow decimal(18,2);declare @noharganow VARCHAR(30);
                   select top(1)  @harganow= harga from tbl_Mst_HargaPoint where  CONVERT(DATETIME,CONVERT(VARCHAR,tanggal,103),103)  <= CONVERT(DATETIME,'" & dtpInvoice.Value & "',103)   order by tanggal desc;
                   select  top(1) @noharganow= NoReff from tbl_Mst_HargaPoint where  CONVERT(DATETIME,CONVERT(VARCHAR,tanggal,103),103)  <= CONVERT(DATETIME,'" & dtpInvoice.Value & "',103)   order by tanggal desc;
                   with datapopinrelasi as ( SELECT     c.KodeSupUM, c.NamaSupUM,hdr.IDSubPetani, B.NamaSup AS  SubPetani, b.alamat, SUM(A.totalpoint) AS TOTALPOINT, SUM(A.TOTALCASHBACK) AS RPTOTALPOINT,
 			                                 0 AS TOTALPOINTCASHBACK, 0 AS RPTOTALPOINTCASHBACK,0 as harga
                                             FROM  TblTrnKelapa_Poin AS a  INNER JOIN
                                             TblTrnKelapaHdr AS hdr on a.nonota=hdr.nonota INNER JOIN  
                                             RSUPAccounting..tblRMMstSupplier AS b ON hdr.IDSubPetani = b.KodeSup INNER JOIN
                                             RSUPAccounting..tblRMMstSupplierUM AS c ON b.KodeSupUM = c.KodeSupUM
				                             WHERE (hdr.Deleted = 0) AND (hdr.IDPancang NOT IN (40, 10, 8))  AND (A.HANGUS=0 OR A.HANGUS IS NULL) 
                                             GROUP BY c.KodeSupUM, c.NamaSupUM,hdr.IDSubPetani, B.NamaSup,b.alamat
                                             UNION
                                             SELECT c.KodeSupUM, c.NamaSupUM,a.IDPetani as IDSubPetani, B.NamaSup AS  SubPetani,b.alamat, 0 AS TOTALPOINT, 0 AS RPTOTALPOINT,
                                             SUM(a.TotalPoinCashBack) AS TOTALPOINTCASHBACK, SUM(A.RPTotalPoinCashBack) AS RPTOTALPOINTCASHBACK,0 as harga
 			                                 FROM  tbl_RMTrnPenukaranPoinDtl AS a  INNER JOIN
                                             RSUPAccounting..tblRMMstSupplier AS b ON A.IDPetani =b.KodeSup INNER JOIN
                                             RSUPAccounting..tblRMMstSupplierUM AS c ON b.KodeSupUM = c.KodeSupUM
		                                     WHERE     Verifikasi=1 
                                             GROUP BY c.KodeSupUM, c.NamaSupUM,a.IDPetani, B.NamaSup,b.alamat)
                    select  KodeSupUM, NamaSupUM, IDSubPetani, SubPetani, alamat, sum(TOTALPOINT)-sum(TOTALPOINTCASHBACK)  as TOTALPOINT,  sum(RPTOTALPOINT)-sum(RPTOTALPOINTCASHBACK) as RPTOTALPOINTCASHBACK ,
                    @harganow as harga ,@noharganow as noreffharga  from datapopinrelasi  WHERE IDSUBPETANI IS NOT NULL " & IIf(SQL2 = "", "", " AND " & SQL2) & "
                    group by  KodeSupUM, NamaSupUM, IDSubPetani, SubPetani, alamat "


            Using koneksi As New SqlCommand(SQL, DB.OpenConnection(StrConnRMPApp))
                Using DR = koneksi.ExecuteReader()
                    If DR.HasRows Then
                        dgvList.Rows.Clear()

                        While DR.Read
                            With dgvList
                                .Rows.Add()
                                COUNTKAPAL = COUNTKAPAL + 1
                                .Item("no", i).Value = i + 1
                                '.Item("DetailID", i).Value = DR!IDSubPetani
                                '.Item("TglCashBack", i).Value = DR!tglcashback
                                .Item("IDPetani", i).Value = DR!IDSubPetani
                                .Item("Petani", i).Value = DR!SubPetani
                                .Item("AlamatID", i).Value = DR!alamat
                                .Item("JumlahPoint", i).Value = DR!TOTALPOINT
                                .Item("RpPoint", i).Value = DR!RPTOTALPOINTCASHBACK
                                .Item("HargaPoint", i).Value = DR!Harga
                                .Item("NoReffHarga", i).Value = DR!noreffharga
                                With Me.dgvList
                                    .RowsDefaultCellStyle.BackColor = Color.White
                                    .AlternatingRowsDefaultCellStyle.BackColor = Color.Azure
                                    .Rows(i).Cells("No").Style.BackColor = Color.FromArgb(240, 240, 240)
                                End With
                                GetMasterPancang(DR!IDSubPetani)
                                GetMasterRek(DR!IDSubPetani)
                            End With
                            i += 1
                        End While

                        dgvList.Rows.Add()
                        Call sumpoin()
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
        btnsave.Enabled = Not flag
        btnexit.Enabled = flag
    End Sub
    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim Koneksi As SqlConnection = DB.OpenConnection(StrConnRMPApp)
        Dim Transaksi As SqlTransaction
        Transaksi = Koneksi.BeginTransaction
        Me.Cursor = Cursors.WaitCursor

        Try
            Dim i As Integer
            If SavePointLoyaltyHdr(Koneksi, Transaksi) = False Then
                Transaksi.Rollback()
                Transaksi = Nothing
                Me.Cursor = Cursors.Default
                MessageBox.Show("Simpan Data Hdr Gagal !", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            For i = 0 To dgvList.RowCount - 1
                If Val(dgvList.Item("RpCashBack", i).Value) > 0 And Val(dgvList.Item("IDNoRek", i).Value) > 0 And Val(dgvList.Item("Sering_antar_IDPancang", i).Value) > 0 Then
                    If SavePointLoyaltyDtl(Koneksi, Transaksi, i) = False Then
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
    Public Sub enableds(flag As Boolean)
        txtinvoice.Enabled = flag
        dtpInvoice.Enabled = flag
    End Sub
    Private Sub btnexit_Click(sender As Object, e As EventArgs) Handles btnexit.Click
        Me.Dispose()
    End Sub

    Private Sub cmbS_Petani_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbS_Petani.KeyUp
        UI.AutoCompleteCombo_KeyUp(cmbS_Petani, e)
    End Sub

    Private Sub cmbS_Petani_Validated(sender As Object, e As EventArgs) Handles cmbS_Petani.Validated
        chkS_Petani.Checked = IIf(cmbS_Petani.Text = "", False, True)
    End Sub

    Private Sub cmbS_Petani_Validating(sender As Object, e As CancelEventArgs) Handles cmbS_Petani.Validating
        If cmbS_Petani.Text = "" Then
            Exit Sub
        End If

        If IsNothing(cmbS_Petani.SelectedValue) Then
            MsgBox("Pilihan tidak ada !", vbExclamation, AT)
            cmbS_Petani.Text = ""
            cmbS_Petani.Focus()
        End If
    End Sub
    Private Sub dgvList_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellEndEdit
        Select Case dgvList.CurrentCell.ColumnIndex
            Case 11
                If dgvList.Item("JumlahPoinCashBack", dgvList.CurrentRow.Index).Value < 5000 Then
                    MsgBox("Batas Penukaran Min. 100.000 ( 5000 POIN) !", vbExclamation, AT)
                    dgvList.Item("JumlahPoinCashBack", dgvList.CurrentRow.Index).Value = 0
                End If

                If dgvList.Item("JumlahPoinCashBack", dgvList.CurrentRow.Index).Value > dgvList.Item("JumlahPoint", dgvList.CurrentRow.Index).Value Then
                    MsgBox("Penukaran Tidak Boleh Lebih dari Poin Supplier  !", vbExclamation, AT)
                    dgvList.Item("JumlahPoinCashBack", dgvList.CurrentRow.Index).Value = 0
                End If

                If Val(dgvList.Item("HargaPoint", dgvList.CurrentRow.Index).Value) Then
                    dgvList.Item("RpCashBack", dgvList.CurrentRow.Index).Value = dgvList.Item("HargaPoint", dgvList.CurrentRow.Index).Value * dgvList.Item("JumlahPoinCashBack", dgvList.CurrentRow.Index).Value
                End If
        End Select
    End Sub
End Class