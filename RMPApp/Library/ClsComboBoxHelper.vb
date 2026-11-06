Public Class ClsComboBoxHelper
#Region "ComboBox Helper"
	Private Sub FilterDataTableAktif(ByVal dt As DataTable, ByVal Aktif As Integer)
		' Aktif: -1 = ambil semua (tidak difilter)
		'         1 = hanya yang aktif
		'         0 = hanya yang tidak aktif
		If Aktif = -1 Then Exit Sub

		Dim i As Integer
		For i = dt.Rows.Count - 1 To 0 Step -1
			If Convert.ToInt32(dt.Rows(i)("Aktif")) <> Aktif Then
				dt.Rows(i).Delete()
			End If
		Next
		dt.AcceptChanges()
	End Sub

	Private Sub SetAutoComplete(ByVal cbo As ComboBox)
		cbo.AutoCompleteMode = AutoCompleteMode.SuggestAppend
		cbo.AutoCompleteSource = AutoCompleteSource.ListItems
	End Sub
#End Region

	Public Sub SetPancang(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select IDPancang as ValueMember, DisplayMember = convert(varchar,IDPancang) + '. ' + Pancang from Android_tblMstPancang ORDER BY IDPancang ASC")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub PancangByGroup(ByVal cbo As ComboBox, ByVal UserID As String)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT p.IDPancang AS ValueMember, CONVERT(VARCHAR(10), p.IDPancang) + '. ' + p.Pancang AS DisplayMember
														FROM Android_tblMstPancang p
														WHERE EXISTS (
															SELECT 1 FROM tblUtlPancangGroup pg
															INNER JOIN tblUtlUserPancangGroup upg ON upg.GroupID = pg.GroupID
															WHERE pg.IDPancang = p.IDPancang AND upg.UserID = '" & UserID & "'
														) ORDER BY p.IDPancang ASC")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetSupplierCustomerAfiliasi(ByVal cbo As ComboBox, Optional ByVal MitraCode As Integer = 0)
		Dim dt As DataTable = New DataTable()
		Dim mitraFilter As String = ""
		Select Case MitraCode
			Case 1
				mitraFilter = " AND SupplierInd=1"
			Case 2
				mitraFilter = " AND CustomerInd=1"
			Case 3
				mitraFilter = " AND AfiliasiInd=1"
		End Select

		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select SupplierID as ValueMember, SupplierName + ' - ' + SupplierID as DisplayMember from DBPancang..tblGENMstSupplier where InActive=0 " & mitraFilter & " order by SupplierName asc")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetWarehouse(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select WHSID as ValueMember, WHSName as DisplayMember from DBPancang..tblINVMstWarehouse order by WHSName asc")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetPancang22(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select KodeSup as ValueMember, DisplayMember = convert(varchar,IDPancang) + '. ' + Pancang from Android_tblMstPancang ORDER BY IDPancang ASC")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SettokoPancang(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select id as ValueMember, upper(nama_toko) as DisplayMember from Android_tblPoinToko where ACTIVED=1")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetMstKehadiran(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select distinct Kehadiran AS ValueMember, Kehadiran AS DisplayMember from TblMstKehadiranPCG")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetKodebarangItem(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select distinct kode_item as ValueMember, kode_item as DisplayMember from Android_tblPoinItem")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetPotUBM(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select IDPotongan as ValueMember, NamaPotongan as DisplayMember from tbl_mst_pot where IDPotongan in (1,2,3)")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetBahanBaku(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnAccounting, "select Kode as ValueMember, NamaBahanBaku as DisplayMember from tblRMMstJenisBahanBaku order by NamaBahanBaku asc")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		'Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetPancangpsp(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select IDPancang as ValueMember, DisplayMember = convert(varchar,IDPancang) + '. ' + Pancang from Android_tblMstPancang where IDPancang ='40' ORDER BY IDPancang ASC")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetPancang_(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select Pancang as DisplayMember from Android_tblMstPancang where IDPancang <>40 ORDER BY Pancang ASC")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetPancang2(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select KodeSup as ValueMember, DisplayMember = convert(varchar,IDPancang) + ' - ' + Pancang + '('+ Kodesup +')' from Android_tblMstPancang where IDPancang <>40 ORDER BY IDPANCANG ASC")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetPancangponti(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select KodeSup as ValueMember, DisplayMember = convert(varchar,IDPancang) + ' - ' + Pancang + '('+ Kodesup +')' from Android_tblMstPancang where IDPancang <>40 and pontianak=1 ORDER BY IDPANCANG ASC")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetPancangpsp_(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select Pancang as DisplayMember from Android_tblMstPancang where IDPancang =40 ORDER BY Pancang ASC")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetPancang2psp(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select KodeSup as ValueMember, DisplayMember = convert(varchar,KodeSup) + ' - ' + Pancang from Android_tblMstPancang where IDPancang =40 ORDER BY KodeSup ASC")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetPancangdokapalsusut(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select IDPancang as ValueMember, DisplayMember = convert(varchar,IDPancang) + ' - ' + Pancang + ' - ' + convert(varchar,KodeSup) from Android_tblMstPancang ORDER BY KodeSup ASC")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetIM(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT ID as ValueMember, LiburMingguan as DisplayMember FROM TblMstIM ORDER BY ID")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetJabatan(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT ID as ValueMember, Jabatan as DisplayMember FROM TblMstJabatanPersonilPCG ORDER BY ID")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetStatus(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT ID as ValueMember, Status as DisplayMember FROM TblMstStatusPersonilPCG ORDER BY ID")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetBagian(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT ID as ValueMember, Bagian as DisplayMember FROM tblMstBagian ORDER BY ID")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub GetMasterRekening(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnAccounting, "SELECT NoRekening as ValueMember, (NoRekening + ' | ' + NamaRekening + ' | ' + JenisBank + ' | ' + IDPetani) AS DisplayMember FROM TblRMMstRekRM WHERE Approval = '2' AND InActive = 0 OR InActive IS NULL ORDER BY NamaRekening")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = 0
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetRek(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT DISTINCT IDNoRek as ValueMember, NoRekening as DisplayMember FROM RSUPAccounting..TblRMMstRekRM WHERE " &
														"(IDPetani IS NOT NULL) AND (LEN(ISNULL(IDPetani, '')) >= 3) AND (SUBSTRING(IDPetani, 1, 3) = 'PCG') AND (LEN(ISNULL(NamaRekening, '')) >= 3)") 'AND IDPetani = '" & FrmInputNotaManual.cmb_PUang.SelectedValue & "'")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = 0
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetJenisBank(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT DISTINCT JenisBank as ValueMember, JenisBank as DisplayMember FROM RSUPAccounting..TblRMMstRekRM WHERE " &
														"(IDPetani IS NOT NULL) AND (LEN(ISNULL(IDPetani, '')) >= 3) AND (SUBSTRING(IDPetani, 1, 3) = 'PCG') AND (LEN(ISNULL(NamaRekening, '')) >= 3) AND JenisBank IS NOT NULL ")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = 0
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetJenis(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT ID_Jenis as ValueMember, Jenis as DisplayMember FROM RSUPAccounting..TblRMMstJenisKg")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = 0
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetJenisByKDJenis(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT KD_Jenis as ValueMember, Jenis as DisplayMember FROM RSUPAccounting..TblRMMstJenisKg")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = 0
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetDERMAGA(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " SELECT DISTINCT iddermaga as ValueMember, iddermaga as DisplayMember
															FROM rmpapp..TblTrnCrane  
															 ORDER BY IDDermaga ")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = 0
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetJenisKB(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT ID_Jenis as ValueMember, Jenis as DisplayMember FROM RMPApp..tblMstJenisKelapa")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetSupplier(ByVal cbo As ComboBox, Optional Aktif As Integer = 0)
		Dim dt As DataTable = New DataTable
		dt = DB.ExecuteQuery(StrConnAccounting, "select KodeSup as ValueMember, Convert(Varchar,KodeSup) + ' - ' + NamaSup as DisplayMember, NotActive as Aktif from tblRMMstSupplier where KodeSup like '%PCG%' and NotActive=" & Aktif)

		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetMstQrBarcode(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select IDPetani as ValueMember, DisplayMember = Convert(Varchar(10),IDPetani) + ' - ' + NamaPetani from vwmstqrbarcodepetani")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetPelangsir(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select id as ValueMember, namapompong as DisplayMember from Android_tblMstPelangsir where notactivedby IS NULL")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetSupplierPerPCG(ByVal cbo As ComboBox, ByVal IDPancang As String)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select RMPSupplierID as ValueMember, DisplayMember = Convert(Varchar(10),RMPSupplierID) + ' - ' + RMPSupplierName from vwAndroid_MstPancang where IDPancang = '" & IDPancang & "' AND (NotActive = 0 OR NotActive IS NULL)")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub Setpenerimauang(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnAccounting, " Select IDNorek as ValueMember, NamaRekening + ' | ' + IDPetani + ' | ' + NoRekening + ' | ' + isnull(JenisBank,'') As DisplayMember from vwRMMstRekeningPancang where Approval = '2' AND ID_Jenis_RekUBM='1' and (InActive=0 OR InActive IS NULL) order by DisplayMember ")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetPenerimaUangUB(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnAccounting, " Select IDNorek as ValueMember, NamaRekening + ' | ' + IDPetani + ' | ' + NoRekening + ' | ' + isnull(JenisBank,'') As DisplayMember from vwRMMstRekeningPancang where Approval = '2' AND ID_Jenis_RekUB='1' and (InActive=0 OR InActive IS NULL) order by DisplayMember ")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetKapal(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select KapalID as ValueMember, DisplayMember = Convert(Varchar(5),KapalID) + '. ' + KapalName from tblMstKapal")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetKapalByName(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select KapalID as ValueMember, KapalName as DisplayMember from tblMstKapal where NonActive=0 order by KapalName asc")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetKapalPSP(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select * from tblMstKapalPSP")
		With cbo
			.DataSource = dt
			.DisplayMember = "Kapal"
			'.ValueMember = "KapalID"
			'.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub Setfac_(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select Fac as ValueMember, Fac as DisplayMember from TblRMMstFactory")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetSupplier_(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select KodeSup as ValueMember, KodeSup + '. ' + NamaSup as DisplayMember from RSUPAccounting..vwRMMstSupplier WHERE ( KODESUP LIKE '%PCG%' OR KODESUP LIKE '%PC03458%' ) and kodesup1<>'psp' ")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetSupplierpsp_(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select KodeSup as ValueMember, KodeSup + '. ' + NamaSup as DisplayMember from RSUPAccounting..vwRMMstSupplier WHERE KODESUP LIKE '%PC%' and kodesup1='psp' ")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetSupplierNonPancang(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select KodeSup as ValueMember, KodeSup + '. ' + NamaSup as DisplayMember from RSUPAccounting..vwRMMstSupplier WHERE ( KODESUP NOT LIKE '%PCG%' OR KODESUP LIKE '%PC03458%' ) and kodesup1<>'psp' ")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetCustomer(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select SupplierID as ValueMember, SupplierName as DisplayMember from DBPancang..tblGENMstSupplier where InActive=0 and CustomerInd=1")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetGroup(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT KodeGroupSup as ValueMember, DisplayMember = Convert(Varchar(5),KodeGroupSup) + '. ' + NamaGroup FROM RMPApp..tblMstGroupSupplier")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = 1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub Settujuanpembayaran(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT TujuanPembayaran as ValueMember, TujuanPembayaran as DisplayMember FROM RMPApp..tblMstTujuanPembayaran")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = 1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetJenisKelapa_(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT ID_Jenis as ValueMember, Jenis as DisplayMember FROM RMPApp..tblMstJenisKelapa_")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = 0
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetKapalPerPCG(ByVal cbo As ComboBox, ByVal IDPancang As String)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select KapalID as ValueMember, DisplayMember = Convert(Varchar(5),KapalID) + '. ' + KapalName from tblMstKapal where IDPancang = '" & IDPancang & "'")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetTripPerPCG(ByVal cbo As ComboBox, ByVal IDPancang As String)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select Distinct Trip as ValueMember, Trip as DisplayMember from tblTrnDoHdr where IDPancang = '" & IDPancang & "' order by Trip")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetTypePCG(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select Type_id as ValueMember, Type as DisplayMember from RSUPAccounting..tblRMMstTypePancang")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetTypeBayar(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select Type_Byr as ValueMember, Type as DisplayMember from RSUPAccounting..tblRMMstTypeBayar")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetAN_rek(ByVal cbo As ComboBox, ByVal IDPancang As Integer)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select distinct A.NamaRekening as ValueMember, A.NamaRekening as DisplayMember
                                                            from RSUPAccounting..TblRMMstRekRM A INNER JOIN
	                                                             RMPApp..Android_tblMstPancang B on A.KodeSup1 = B.KodeSup where A.InActive = 0 and B.IDPancang = '" & IDPancang & "'")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetNoRek(ByVal cbo As ComboBox, ByVal Nama As String, ByVal IDPancang As Integer)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select A.IDNoRek as ValueMember, A.NoRekening as DisplayMember
                                                            from RSUPAccounting..TblRMMstRekRM A INNER JOIN
                                                            RMPApp..Android_tblMstPancang B on A.KodeSup1 = B.KodeSup where A.InActive = 0 and B.IDPancang = '" & IDPancang & "' and NamaRekening = '" & Nama & "'")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetNoRekPSP(ByVal cbo As ComboBox, ByVal Nama As String)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select A.IDNoRek as ValueMember, A.NoRekening as DisplayMember
                                                            from RSUPAccounting..TblRMMstRekRM A INNER JOIN
                                                            RMPApp..Android_tblMstPancang B on A.KodeSup1 = B.KodeSup where A.InActive = 0 and NamaRekening = '" & Nama & "'")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetBank(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select Distinct JenisBank as ValueMember, JenisBank as DisplayMember from RSUPAccounting..TblRMMstRekRM")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetTripPenerimaan(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select distinct Trip as ValueMember, Trip as DisplayMember from RSUPAccounting..vwRMPAppPenerimaanPancang where Trip> 0")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetGroupUser(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "Select GroupID as ValueMember, GroupName as DisplayMember from MstGroupUser where InActive = 0")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetSupplierForTokoPancang(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = DB.ExecuteQuery(StrConnPSGRMP, "select distinct KodeSupplierRMP as ValueMember, DisplayMember = Convert(Varchar(10),KodeSupplierRMP) + ' - ' + FullName from vwDO")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub Bank(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select JenisBank as ValueMember, JenisBank as DisplayMember from RSUPAccounting..TblRM_MstBank")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub JenisRek(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " select ID_Jenis as ValueMember, Jenis as DisplayMember from RMPApp..tblMstJenisRekening ")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetPersonilPancang(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select DISTINCT IDPersonil as ValueMember, IDPersonil as DisplayMember from TblMstPersonilPancangNew")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetKehadiran(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select kehadiran as ValueMember, kehadiran as DisplayMember from TblMstKehadiranPCG")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub setKontraktor(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select id as ValueMember, nama_kontraktor as DisplayMember from tbl_wo_mst_kontraktor where notactive=0 and deleted=0 order by nama_kontraktor asc")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub setSubKontraktor(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select id as ValueMember, nama_kontraktor_sub as DisplayMember from tbl_wo_mst_kontraktor_sub where notactive=0 and deleted=0 order by nama_kontraktor_sub asc")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub setIdPancang(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " select IDPancang as ValueMember, DisplayMember = convert(varchar,IDPancang) + '. ' + Pancang from Android_tblMstPancang ORDER BY IDPancang ASC")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub MainSupplier(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "Select KodeMainSUP as ValueMember, isnull(NamaKTP,'') AS DisplayMember, KodeNota from [PSGRMP].[dbo].[tblRMMstMainSupplier] where notactive=0 order by MainSupplierName asc")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub LoadSupplier1(ByVal cbo As ComboBox, ByVal KodeMainSUP As String)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnPSGRMP, "select kodesup as ValueMember, KodeSup +' | ' + NamaSup as DisplayMember, KodeNota from tblRMMstSupplier where KodeMainSUP= '" & KodeMainSUP & "'")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub LoadGroupKK(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		'dt = Modul_RMP.DB.ExecuteQuery(StrConnAccounting, "SELECT DISTINCT KodeSupUM as ValueMember, KodeSupUM +' | ' + NamaSupUM as DisplayMember, NamaGroup, NoKK FROM RSUPAccounting..vwRMMstSupplierUM WHERE NamaSupUM LIKE '%" & LTrim(FrmDlgSupplier.cbokkfltr.Text) & "%' OR KODESupUM LIKE '%" & LTrim(FrmDlgSupplier.cbokkfltr.Text) & "%' ORDER BY KodeSupUM")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub LoadBahanBaku(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " Select KodeGroupBahanBaku as ValueMember, NamaGroupBahanBaku as DisplayMember from TblRMMstGroupBahanBaku where KodeJenisBahanBaku=1 and NotActive = 0")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub BahanBaku(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnPSGRMP, "Select KodeGroupBahanBaku as ValueMember, NamaGroupBahanBaku as DisplayMember from TblRMMstGroupBahanBaku where KodeJenisBahanBaku=1 and NotActive = 0")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub LoadWilayah(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnPSGRMP, "Select AreaMainID as ValueMember, AreaMainName as DisplayMember From tblRMPAreaMain Where DiscardedInd=0")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub LoadKapal(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnPSGRMP, "Select KapalID as ValueMember, KapalName as DisplayMember, Pemilik From [192.168.12.5].[RMPAPP].[dbo].[vwkapall]")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub LoadShift(ByVal cbo As ComboBox)
		cbo.Items.Add("A")
		cbo.Items.Add("B")
		cbo.Items.Add("C")
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub LoadConveyor(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnPSGRMP, "Select CvCode as ValueMember, CvCode as DisplayMember from tblMstConveyor ORDER BY ShortOrder Asc")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetKapalWithPCG(ByVal cbo As ComboBox, IDPancang As String)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select KapalID as ValueMember, DisplayMember = Convert(Varchar(5),KapalID) + '. ' + KapalName from tblMstKapal where IDPancang = '" & IDPancang & "'")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetKaptenKapal(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select id as ValueMember, namakapten as DisplayMember from tblMstKaptenKapal where nonactive=0")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetAbsensiNik(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select Distinct Nik as ValueMember, DisplayMember = convert(varchar,Nik) + ' - ' + Nama from Android_tblAbsensiPancang")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetParit(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select IDParit as ValueMember, DisplayMember = convert(varchar,IDParit) + '. ' + NamaLokasi from Android_tblMstParit where Status = 1")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetPeriode(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()

		dt.Columns.Add("ValueMember")
		dt.Columns.Add("DisplayMember")

		dt.Rows.Add("1", "1. Januari")
		dt.Rows.Add("2", "2. Februari")
		dt.Rows.Add("3", "3. Maret")
		dt.Rows.Add("4", "4. April")
		dt.Rows.Add("5", "5. Mei")
		dt.Rows.Add("6", "6. Juni")
		dt.Rows.Add("7", "7. Juli")
		dt.Rows.Add("8", "8. Agustus")
		dt.Rows.Add("9", "9. September")
		dt.Rows.Add("10", "10. Oktober")
		dt.Rows.Add("11", "11. November")
		dt.Rows.Add("12", "12. Desember")

		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetItem(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "Select Item as DisplayMember from [RMPApp].[dbo].[TblMstTargetPengawasPCGDtl]")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SetJenisItem(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "Select id_jenis as ValueMember, jenis_item as DisplayMember from [RMPApp].[dbo].[Android_tblJenisItem]")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub setSatuanItem(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select id as ValueMember, satuan as DisplayMember from rmpapp..Android_tblPoinSatuan")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub loadcbojenis(cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnPSGRMP, "Select KodeGroupBahanBaku as ValueMember, NamaGroupBahanBaku as DisplayMember from TblRMMstGroupBahanBaku where NotActive=0")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	''''cOMBO'''''
	Public Sub loadcboarea(cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnPSGRMP, "Select AreaSubID as ValueMember, AreaSubID + ' | ' + AreaSubName as DisplayMember from vwrmarea where (areasubid<>'' or areasubid is not null) order by areasubid asc")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub SUBGRADE(cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnAccounting, "Select KodeGrade as ValueMember, KodeGrade as DisplayMember FROM [RSUPAccounting].[dbo].[tblRMMstKodeGrade] where LEFT(KODEGRADE,1)='A'")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub CboMstRing(cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnAccounting, "select IDRing as ValueMember, RING as DisplayMember from RMPAPP..tblRMMstRing")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub CboMstKapasitasKapal(cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnAccounting, "Select IDKapasitas as ValueMember, Kapasitas as DisplayMember FROM [RMPApp].[dbo].[tblRMMstKapasitasKapal]")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub CboSuplierGL(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnAccounting, "SELECT SupplierID as ValueMember, SupplierName as DisplayMember, NoCOA, NoCOAPrepaid FROM RSUPGeneralLedger2018..TblRGLMstSupplier 
															Where NoCOA is Not Null and NotActive=0 and Type='PBL' ORDER BY SupplierName")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub JenisWilayah(ByVal cbo As ComboBox)
		With cbo
			.Items.Clear()
			.Items.Add("LOKAL")
			.Items.Add("NON LOKAL")
			.Items.Add("LUAR PULAU")

			.SelectedIndex = -1
		End With

		Call SetAutoComplete(cbo)
	End Sub

	Public Sub Role(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT RoleID as ValueMember, RoleName as DisplayMember FROM dbo.tblUtlRole ORDER BY RoleName")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub GroupSupplier(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnAccounting, "SELECT KodeGroupSup as ValueMember, NamaGroup as DisplayMember FROM tblRMMstGroupSupplier ORDER BY KodeGroupSup")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub DivBlockKav(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT DivkavP2 AS DisplayMember, DivkavP2 AS ValueMember FROM Android_tblMstPancang ORDER BY DivkavP2")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub FactoryID(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnAccounting, "SELECT IDFactory as DisplayMember, IDFactory as ValueMember FROM TblRMMstFactory ORDER BY IDFactory")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub InvCategory(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select id as ValueMember, kategori as DisplayMember from RMPApp..TblInv_MstKategoriBarang where notactived = 0")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub InvSatuan(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select id as ValueMember, satuan as DisplayMember from RMPApp..TblInv_MstSatuanBarang where notactived = 0")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub InvKodeBarang(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select KodeBarang as DisplayMember, KodeBarang as ValueMember from RMPApp..TblInv_MstBarang where NotActived = 0")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub InvKondisiBarang(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "  select IDMstKondisi as ValueMember, KondisiBarang as DisplayMember from RMPApp..TblInv_MstKondisiBarang where NotActived = 0")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub
	Public Sub InvPenanggungJawab(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select IdPenanggungJawab as ValueMember, PenanggungJawab as DisplayMember from RMPApp..TblInv_MstPenanggungJawab where NotActived = 0")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub
	Public Sub InvInventarisMasuk(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "  SELECT IdInventarisMasuk as ValueMember, InventarisMasuk as DisplayMember FROM TblInv_MstInventarisMasuk WHERE NotActived=0")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub RmWilayah(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnAccounting, "SELECT Kode_Wilayah as ValueMember, NAMA_WILAYAH as DisplayMember FROM TblRMMstWilayah ORDER BY Kode_Wilayah")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

	Public Sub RmAreaZone(ByVal cbo As ComboBox)
		Dim dt As DataTable = New DataTable()
		dt = Modul_RMP.DB.ExecuteQuery(StrConnAccounting, "SELECT AreaZoneID as ValueMember, AreaZoneName as DisplayMember FROM TblRMMstAreaZone ORDER BY AreaZoneName")
		With cbo
			.DataSource = dt
			.DisplayMember = "DisplayMember"
			.ValueMember = "ValueMember"
			.SelectedIndex = -1
		End With
		Call SetAutoComplete(cbo)
	End Sub

End Class