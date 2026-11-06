Imports System.Data.SqlClient
Imports System.IO
Imports System.Data
Imports System.ComponentModel
Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Globalization

Public Class FrmTrnTukarPoinNew
    Public AT As String = "RMPApplication ©" & Format(Year(Now))
    Dim Conn As SqlConnection
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim Kode As String
    Dim str As String
    
    Public perintah As String
    Dim NoTransUpahBongkar_ As String
    Dim NoInvoice_ As String
    Private Sub FrmTrnTukarPoinNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpInvoice.Value = Format(Now, "dd/MM/yy")
        btnexit.Enabled = True
        Modul_RMP.Combo.SetSupplier(cmbS_Petani)
    End Sub

    Private Sub btnLoaddata_Click(sender As Object, e As EventArgs) Handles btnLoaddata.Click
        dgvList.Rows.Clear()
        If perintah = "Add" Then
            loaddata()
        End If
    End Sub
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

    Private Sub cmbS_Petani_Validated(sender As Object, e As EventArgs) Handles cmbS_Petani.Validated
        chkS_Petani.Checked = IIf(cmbS_Petani.Text = "", False, True)
    End Sub

    Private Sub cmbS_Petani_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbS_Petani.KeyUp
        UI.AutoCompleteCombo_KeyUp(cmbS_Petani, e)
    End Sub

    Private Sub SplitContainer1_Panel2_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel2.Paint

    End Sub
End Class
