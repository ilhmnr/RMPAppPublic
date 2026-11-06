Imports System.Runtime.InteropServices
Imports WeifenLuo.WinFormsUI.Docking

Public Class FrmMain
    Dim revision As Integer = My.Application.Info.Version.Revision
    Dim formattedRevision As String = revision.ToString("D3")

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.IsMdiContainer = True

        If Not Object.ReferenceEquals(DockPanel1.Parent, Me) Then
            DockPanel1.Parent.Controls.Remove(DockPanel1)
            Me.Controls.Add(DockPanel1)
        End If

        DockPanel1.Dock = DockStyle.Fill
        DockPanel1.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingMdi

        If Modul_RMP.Func.Appversion(
            My.Application.Info.Version.Major.ToString() &
            My.Application.Info.Version.Minor.ToString() &
            My.Application.Info.Version.Build.ToString() &
            formattedRevision) = False Then
            Me.Close()
            Return
        End If

        Me.Visible = False

        BukaMenu(FrmDashboard)
    End Sub

    Private Sub FrmMain_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If Me.Visible = False Then
            Me.Visible = True
            FrmLogin.ShowDialog()
        End If
    End Sub

    Private Sub btnTutupSemuaMenu_Click(sender As Object, e As EventArgs) Handles btnTutupSemuaMenu.Click, lblTutupSemuaMenu.Click

        For Each frm As WeifenLuo.WinFormsUI.Docking.DockContent In DockPanel1.Contents.ToArray()
            If frm IsNot Nothing AndAlso Not frm.IsDisposed AndAlso Not TypeOf frm Is FrmDashboard Then
                frm.Close()
            End If
        Next

    End Sub

    Private Sub mnuDashboard_Click(sender As Object, e As EventArgs) Handles mnuDashboard.Click
        BukaMenu(FrmDashboard, mnuDashboard)
    End Sub
#Region "Menu Akses"
    Public Sub VisibleMenuAkses()
        Try
            Dim sql As String =
            "SELECT M.MenuTag, M.IsVisible, " &
            "ISNULL(RM.IsAllowed, 0) AS CanAccess " &
            "FROM dbo.tblUtlMenu M " &
            "LEFT JOIN dbo.tblUtlRoleMenu RM " &
            "ON M.MenuID = RM.MenuID " &
            "AND RM.RoleID = " & ClsSession.RoleID

            Dim dt As DataTable =
            Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

            Dim menuVisible As New Dictionary(Of String, Boolean)(
            StringComparer.OrdinalIgnoreCase)

            Dim menuAccess As New Dictionary(Of String, Boolean)(
            StringComparer.OrdinalIgnoreCase)

            For Each dr As DataRow In dt.Rows
                Dim tag As String = dr("MenuTag").ToString()

                If tag <> "" Then
                    menuVisible(tag) = Convert.ToBoolean(dr("IsVisible"))
                    menuAccess(tag) = Convert.ToBoolean(dr("CanAccess"))
                End If
            Next

            ApplyMenuAccess(MenuStrip1.Items, menuVisible, menuAccess)

        Catch ex As Exception
            MsgBoxCustom.Show(ex.Message,
                          MsgBoxCustom.ButtonType.OK,
                          MsgBoxCustom.IconType.Error)
        End Try
    End Sub

    Private Function ApplyMenuAccess(
    items As ToolStripItemCollection,
    menuVisible As Dictionary(Of String, Boolean),
    menuAccess As Dictionary(Of String, Boolean),
    Optional parentVisible As Boolean = True) As Boolean

        Dim anyVisible As Boolean = False

        For Each item As ToolStripItem In items
            Dim menu As ToolStripMenuItem =
            TryCast(item, ToolStripMenuItem)

            If menu Is Nothing Then Continue For

            Dim tag As String = If(menu.Tag IsNot Nothing,
                               menu.Tag.ToString(), "")

            If tag = "" Then tag = menu.Name

            Dim globalVisible As Boolean = False
            Dim roleAccess As Boolean = False

            If menuVisible.ContainsKey(tag) Then
                globalVisible = menuVisible(tag)
                roleAccess = menuAccess(tag)
            End If

            If Not parentVisible OrElse Not globalVisible Then
                menu.Visible = False
                ApplyMenuAccess(menu.DropDownItems,
                            menuVisible, menuAccess, False)
                Continue For
            End If

            Dim childVisible As Boolean =
            ApplyMenuAccess(menu.DropDownItems,
                            menuVisible, menuAccess)

            menu.Visible = roleAccess OrElse childVisible

            If menu.Visible Then anyVisible = True
        Next

        Return anyVisible
    End Function
#End Region

#Region "Buka Menu"
    Public Sub BukaMenu(Of T As {WeifenLuo.WinFormsUI.Docking.DockContent, New})(
    ByRef frm As T,
    Optional menu As ToolStripMenuItem = Nothing)

        Me.Cursor = Cursors.WaitCursor

        Try
            If frm Is Nothing OrElse frm.IsDisposed Then
                frm = New T()
            End If

            If menu IsNot Nothing Then
                frm.Tag = menu.Tag

                If menu.Image IsNot Nothing Then
                    Using bmp As New Bitmap(menu.Image)
                        Dim hIcon As IntPtr = bmp.GetHicon()

                        Try
                            Using ico As Icon = Icon.FromHandle(hIcon)
                                frm.Icon = CType(ico.Clone(), Icon)
                            End Using
                        Finally
                            DestroyIcon(hIcon)
                        End Try
                    End Using
                End If
            End If

            If Not frm.Visible Then
                frm.Show(DockPanel1, DockState.Document)
            Else
                frm.Activate()
            End If

        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function DestroyIcon(hIcon As IntPtr) As Boolean
    End Function

    Private Function CariImageMenu(parent As Control, namaForm As String) As Image
        For Each ctrl As Control In parent.Controls
            If TypeOf ctrl Is MenuStrip Then
                Dim hasil As Image = CariImageItem(
                DirectCast(ctrl, MenuStrip).Items,
                namaForm)

                If hasil IsNot Nothing Then Return hasil
            End If

            Dim hasilChild As Image = CariImageMenu(ctrl, namaForm)
            If hasilChild IsNot Nothing Then Return hasilChild
        Next

        Return Nothing
    End Function

    Private Function CariImageItem(
    items As ToolStripItemCollection,
    namaForm As String) As Image

        For Each item As ToolStripItem In items
            If TypeOf item Is ToolStripMenuItem Then
                If item.Name = namaForm Then Return item.Image

                Dim subItem = DirectCast(item, ToolStripMenuItem)
                Dim hasil As Image = CariImageItem(subItem.DropDownItems, namaForm)

                If hasil IsNot Nothing Then Return hasil
            End If
        Next

        Return Nothing
    End Function
#End Region

#Region "Menu Utility"
    Private Sub mnuUtlMenuSetup_Click(sender As Object, e As EventArgs) Handles mnuUtlMenuSetup.Click
        BukaMenu(FrmUtlMenu, mnuUtlMenuSetup)
    End Sub

    Private Sub mnuUtlMenuVisibel_Click(sender As Object, e As EventArgs) Handles mnuUtlMenuVisibel.Click
        BukaMenu(FrmUtlMenuVisibel, mnuUtlMenuVisibel)
    End Sub

    Private Sub mnuUtlMenuAkses_Click(sender As Object, e As EventArgs) Handles mnuUtlMenuAkses.Click
        BukaMenu(FrmUtlMenuAkses, mnuUtlMenuAkses)
    End Sub

    Private Sub mnuUtlUser_Click(sender As Object, e As EventArgs) Handles mnuUtlUser.Click
        BukaMenu(FrmUtlUser, mnuUtlUser)
    End Sub

    Private Sub mnuUtlRole_Click(sender As Object, e As EventArgs) Handles mnuUtlRole.Click
        BukaMenu(FrmUtlRole, mnuUtlRole)
    End Sub

    Private Sub mnuUtlUpdateAplikasi_Click(sender As Object, e As EventArgs) Handles mnuUtlUpdateAplikasi.Click
        FrmUtlUpdateVersion.ShowDialog()
    End Sub

    Private Sub mnuUtlUpdateMenu_Click(sender As Object, e As EventArgs) Handles mnuUtlUpdateMenu.Click
        VisibleMenuAkses()

        MsgBoxCustom.Show("Update menu berhasil dilakukan.", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
    End Sub

    Private Sub mnuUtlAksesPancang_Click(sender As Object, e As EventArgs) Handles mnuUtlAksesPancang.Click
        BukaMenu(FrmUtlAksesPancang, mnuUtlAksesPancang)
    End Sub
#End Region

#Region "Menu Master"
    Private Sub mnuMstSupplierMainSupplier_Click(sender As Object, e As EventArgs) Handles mnuMstSupplierMainSupplier.Click
        BukaMenu(FrmMstSupplierMain, mnuMstSupplierMainSupplier)
    End Sub

    Private Sub mnuMstSupplierSupplier_Click(sender As Object, e As EventArgs) Handles mnuMstSupplierSupplier.Click
        BukaMenu(FrmMstSupplier, mnuMstSupplierSupplier)
    End Sub

    Private Sub mnuMstSupplierRekening_Click(sender As Object, e As EventArgs) Handles mnuMstSupplierRekening.Click
        BukaMenu(FrmMstRekening, mnuMstSupplierRekening)
    End Sub

    Private Sub mnuMstPersonilPancangPersonilPancang_Click(sender As Object, e As EventArgs) Handles mnuMstPersonilPancangPersonilPancang.Click
        BukaMenu(FrmMstPersonilPancangNewList, mnuMstPersonilPancangPersonilPancang)
    End Sub

    Private Sub mnuMstPersonilPancangUangMakan_Click(sender As Object, e As EventArgs) Handles mnuMstPersonilPancangUangMakan.Click
        BukaMenu(FrmMstUangMakan, mnuMstPersonilPancangUangMakan)
    End Sub

    Private Sub mnuMstKontraktorKontraktor_Click(sender As Object, e As EventArgs) Handles mnuMstKontraktorKontraktor.Click
        BukaMenu(FrmMstKontraktor, mnuMstKontraktorKontraktor)
    End Sub

    Private Sub mnuMstKontraktorSubKontraktor_Click(sender As Object, e As EventArgs) Handles mnuMstKontraktorSubKontraktor.Click
        BukaMenu(FrmMstKontraktorSub, mnuMstKontraktorSubKontraktor)
    End Sub

    Private Sub mnuMstKapalKapal_Click(sender As Object, e As EventArgs) Handles mnuMstKapalKapal.Click
        BukaMenu(FrmMstKapal, mnuMstKapalKapal)
    End Sub

    Private Sub mnuMstKapalKapalPelangsir_Click(sender As Object, e As EventArgs) Handles mnuMstKapalKapalPelangsir.Click
        BukaMenu(FrmMstKapalPelangsir, mnuMstKapalKapalPelangsir)
    End Sub

    Private Sub mnuMstKapalKapten_Click(sender As Object, e As EventArgs) Handles mnuMstKapalKapten.Click
        BukaMenu(FrmMstKaptenKapal, mnuMstKapalKapten)
    End Sub

    Private Sub mnuMstPersonilPancangHariLiburNasional_Click(sender As Object, e As EventArgs) Handles mnuMstPersonilPancangHariLiburNasional.Click
        BukaMenu(FrmMstHariLiburNasional, mnuMstPersonilPancangHariLiburNasional)
    End Sub

    Private Sub mnuMstTarifUpahBongkarUpahBongkar_Click(sender As Object, e As EventArgs) Handles mnuMstTarifUpahBongkarUpahBongkar.Click
        BukaMenu(FrmMstTarifUpahBongkar, mnuMstTarifUpahBongkar)
    End Sub

    Private Sub mnuMstTarifUpahBongkarUpahBongkarKontainer_Click(sender As Object, e As EventArgs) Handles mnuMstTarifUpahBongkarUpahBongkarKontainer.Click
        BukaMenu(FrmMstUpahBongkarKontainer, mnuMstTarifUpahBongkarUpahBongkarKontainer)
    End Sub

    Private Sub mnuMstTarifTambangKapalPSG_Click(sender As Object, e As EventArgs) Handles mnuMstTarifTambangKapalPSG.Click
        BukaMenu(FrmMstUpahBongkarMuatP1, mnuMstTarifTambangKapalPSG)
    End Sub

    Private Sub mnuMstTarifTambangKapalRSUP_Click(sender As Object, e As EventArgs) Handles mnuMstTarifTambangKapalRSUP.Click
        BukaMenu(FrmMstUpahBongkarMuat, mnuMstTarifTambangKapalRSUP)
    End Sub

    Private Sub mnuMstTarifTambangKapalPancangSub_Click(sender As Object, e As EventArgs) Handles mnuMstTarifTambangKapalPancangSub.Click
        BukaMenu(FrmMstUpahBongkarMuatPCGSub, mnuMstTarifTambangKapalPancangSub)
    End Sub

    Private Sub mnuMstTarifTambangKapalCustomer_Click(sender As Object, e As EventArgs) Handles mnuMstTarifTambangKapalCustomer.Click
        BukaMenu(FrmMstUpahBongkarMuatKeSupplier, mnuMstTarifTambangKapalCustomer)
    End Sub

    Private Sub mnuMstTarifKomisi_Click(sender As Object, e As EventArgs) Handles mnuMstTarifKomisi.Click
        BukaMenu(FrmMstFee, mnuMstTarifKomisi)
    End Sub

    Private Sub mnuMstHargaBeliBahanBakuBeliBahanBaku_Click(sender As Object, e As EventArgs) Handles mnuMstHargaBeliBahanBakuBeliBahanBaku.Click
        BukaMenu(FrmMstHargaBeliBahanBaku, mnuMstHargaBeliBahanBakuBeliBahanBaku)
    End Sub

    Private Sub mnuMstHargaBeliBahanBakuStatusAktif_Click(sender As Object, e As EventArgs) Handles mnuMstHargaBeliBahanBakuStatusAktif.Click
        BukaMenu(FrmMstHargaBeliBahanBakuStatusAktif, mnuMstHargaBeliBahanBakuStatusAktif)
    End Sub

    Private Sub mnuMstHargaPengepul_Click(sender As Object, e As EventArgs) Handles mnuMstHargaPengepul.Click
        BukaMenu(FrmMstHargaBeliBahanBakuPengepul, mnuMstHargaPengepul)
    End Sub

    Private Sub mnuMstHargaPremiAsuransi_Click(sender As Object, e As EventArgs) Handles mnuMstHargaPremiAsuransi.Click
        BukaMenu(FrmMstHargaPremiAsuransi, mnuMstHargaPremiAsuransi)
    End Sub

    Private Sub mnuMstApprove_Click(sender As Object, e As EventArgs) Handles mnuMstApprove.Click
        BukaMenu(FrmMstApprove, mnuMstApprove)
    End Sub

    Private Sub mnuMstPremiPremiDanPengawas_Click(sender As Object, e As EventArgs) Handles mnuMstPremiPremiDanPengawas.Click
        BukaMenu(FrmMstPremiPengawasandIP, mnuMstPremiPremiDanPengawas)
    End Sub

    Private Sub mnuMstPremiLevel_Click(sender As Object, e As EventArgs) Handles mnuMstPremiLevel.Click
        BukaMenu(FrmMstLevelBonus, mnuMstPremiLevel)
    End Sub

    Private Sub mnuMstPremiLevelBonusPengawas_Click(sender As Object, e As EventArgs) Handles mnuMstPremiLevelBonusPengawas.Click
        BukaMenu(FrmMstLevelBonusPengawas, mnuMstPremiLevelBonusPengawas)
    End Sub

    Private Sub mnuMstLoyaltyKlasifikasiPoint_Click(sender As Object, e As EventArgs) Handles mnuMstLoyaltyKlasifikasiPoint.Click
        BukaMenu(FrmMstKlasifikasiPoint, mnuMstLoyaltyKlasifikasiPoint)
    End Sub

    Private Sub mnuMstLoyaltyHargaPoint_Click(sender As Object, e As EventArgs) Handles mnuMstLoyaltyHargaPoint.Click
        BukaMenu(FrmMstHargaPoint, mnuMstLoyaltyHargaPoint)
    End Sub

    Private Sub mnuMstLoyaltyItemBarang_Click(sender As Object, e As EventArgs) Handles mnuMstLoyaltyItemBarang.Click
        BukaMenu(FrmMstItem, mnuMstLoyaltyItemBarang)
    End Sub

    Private Sub mnuMstLoyaltyToko_Click(sender As Object, e As EventArgs) Handles mnuMstLoyaltyToko.Click
        BukaMenu(FrmMstTokoNew, mnuMstLoyaltyToko)
    End Sub

    Private Sub mnuMstLoyaltyRelasiLoyal_Click(sender As Object, e As EventArgs) Handles mnuMstLoyaltyRelasiLoyal.Click
        BukaMenu(FrmMstRelasiCekDoc, mnuMstLoyaltyRelasiLoyal)
    End Sub

    Private Sub mnuMstInventarisBarang_Click(sender As Object, e As EventArgs) Handles mnuMstInventarisBarang.Click
        BukaMenu(FrmMstItemInventory, mnuMstInventarisBarang)
    End Sub

    Private Sub mnuMstInventarisSatuanBarang_Click(sender As Object, e As EventArgs) Handles mnuMstInventarisSatuanBarang.Click
        BukaMenu(FrmMstSatuanItem, mnuMstInventarisSatuanBarang)
    End Sub

    Private Sub mnuMstInventarisInventarisMasuk_Click(sender As Object, e As EventArgs) Handles mnuMstInventarisInventarisMasuk.Click
        BukaMenu(FrmMstInventarisMasuk, mnuMstInventarisInventarisMasuk)
    End Sub

    Private Sub mnuMstWilayahDivisi_Click(sender As Object, e As EventArgs) Handles mnuMstWilayahDivisi.Click
        BukaMenu(FrmMstWilayahDivisi, mnuMstWilayahDivisi)
    End Sub

    Private Sub mnuMstHargaBahanBakuKG_Click(sender As Object, e As EventArgs) Handles mnuMstHargaBahanBakuKG.Click
        BukaMenu(FrmMstHargaBahanBakuKg, mnuMstHargaBahanBakuKG)
    End Sub

#End Region

#Region "Menu Transaksi"
    Private Sub mnuTrnPersonilPancangUangMakan_Click(sender As Object, e As EventArgs) Handles mnuTrnPersonilPancangUangMakan.Click
        BukaMenu(FrmTrnUangMakanPersonilPancang, mnuTrnPersonilPancangUangMakan)
    End Sub

    Private Sub mnuTrnPersonilPancangLembur_Click(sender As Object, e As EventArgs) Handles mnuTrnPersonilPancangLembur.Click
        BukaMenu(FrmTrnAbsensiPancangLembur, mnuTrnPersonilPancangLembur)
    End Sub

    Private Sub mnuTrnPersonilPancangAbsensiManual_Click(sender As Object, e As EventArgs) Handles mnuTrnPersonilPancangAbsensiManual.Click
        BukaMenu(FrmTrnAbsensiPancangManual, mnuTrnPersonilPancangAbsensiManual)
    End Sub

    Private Sub mnuTrnInvoicePembayaranKelapa_Click(sender As Object, e As EventArgs) Handles mnuTrnInvoicePembayaranKelapa.Click
        BukaMenu(FrmTrnInvoicePembayaranKelapa, mnuTrnInvoicePembayaranKelapa)
    End Sub

    Private Sub mnuTrnDeklarasiHarianAngkutanBuahKelapa_Click(sender As Object, e As EventArgs) Handles mnuTrnDeklarasiHarianAngkutanBuahKelapa.Click
        BukaMenu(FrmTrnPremiAsuransiFind, mnuTrnDeklarasiHarianAngkutanBuahKelapa)
    End Sub

    Private Sub mnuTrnKapalPenilaianDanPerforma_Click(sender As Object, e As EventArgs) Handles mnuTrnKapalPenilaianDanPerforma.Click
        BukaMenu(FrmTrnPointKapalFind, mnuTrnKapalPenilaianDanPerforma)
    End Sub

    Private Sub mnuTrnKapalDocking_Click(sender As Object, e As EventArgs) Handles mnuTrnKapalDocking.Click
        BukaMenu(FrmTrnDokingKapal, mnuTrnKapalDocking)
    End Sub

    Private Sub mnuTrnKapalUpdateTrip_Click(sender As Object, e As EventArgs) Handles mnuTrnKapalUpdateTrip.Click
        BukaMenu(FrmTrnUpdateTripKapal, mnuTrnKapalUpdateTrip)
    End Sub

    Private Sub mnuTrnKapalUbahTujuan_Click(sender As Object, e As EventArgs) Handles mnuTrnKapalUbahTujuan.Click
        BukaMenu(FrmTrnUbahTujuan, mnuTrnKapalUbahTujuan)
    End Sub

    Private Sub mnuTrnKapalTanggalMasuk_Click(sender As Object, e As EventArgs) Handles mnuTrnKapalTanggalMasuk.Click
        BukaMenu(FrmTrnInputTrip, mnuTrnKapalTanggalMasuk)
    End Sub

    Private Sub mnuTrnWOPancangEstimasiBiaya_Click(sender As Object, e As EventArgs) Handles mnuTrnWOPancangEstimasiBiaya.Click
        If Application.OpenForms.OfType(Of FrmTrnApproval1DanInputBarangPengajuanWoPancang)().Any() Then
            Dim Frm As FrmTrnApproval1DanInputBarangPengajuanWoPancang = Application.OpenForms.OfType(Of FrmTrnApproval1DanInputBarangPengajuanWoPancang)().FirstOrDefault()
            Frm.Close()
        End If

        FrmTrnApproval1DanInputBarangPengajuanWoPancang.openFormBy = "EstimasiBiaya"
        BukaMenu(FrmTrnApproval1DanInputBarangPengajuanWoPancang, mnuTrnWOPancangEstimasiBiaya)
    End Sub

    Private Sub mnuTrnWOPancangProyek_Click(sender As Object, e As EventArgs) Handles mnuTrnWOPancangProyek.Click
        If Application.OpenForms.OfType(Of FrmTrnApproval1DanInputBarangPengajuanWoPancang)().Any() Then
            Dim Frm As FrmTrnApproval1DanInputBarangPengajuanWoPancang = Application.OpenForms.OfType(Of FrmTrnApproval1DanInputBarangPengajuanWoPancang)().FirstOrDefault()
            Frm.Close()
        End If

        FrmTrnApproval1DanInputBarangPengajuanWoPancang.openFormBy = "Proyek"
        BukaMenu(FrmTrnApproval1DanInputBarangPengajuanWoPancang, mnuTrnWOPancangProyek)
    End Sub

    Private Sub mnuTrnWOPancangSPK_Click(sender As Object, e As EventArgs) Handles mnuTrnWOPancangSPK.Click
        If Application.OpenForms.OfType(Of FrmTrnApproval1DanInputBarangPengajuanWoPancang)().Any() Then
            Dim Frm As FrmTrnApproval1DanInputBarangPengajuanWoPancang = Application.OpenForms.OfType(Of FrmTrnApproval1DanInputBarangPengajuanWoPancang)().FirstOrDefault()
            Frm.Close()
        End If

        FrmTrnApproval1DanInputBarangPengajuanWoPancang.openFormBy = "Spk"
        BukaMenu(FrmTrnApproval1DanInputBarangPengajuanWoPancang, mnuTrnWOPancangSPK)
    End Sub

    Private Sub mnuTrnWOPancangBarangRequest_Click(sender As Object, e As EventArgs) Handles mnuTrnWOPancangBarangRequest.Click
        If Application.OpenForms.OfType(Of FrmTrnApproval1DanInputBarangPengajuanWoPancang)().Any() Then
            Dim Frm As FrmTrnApproval1DanInputBarangPengajuanWoPancang = Application.OpenForms.OfType(Of FrmTrnApproval1DanInputBarangPengajuanWoPancang)().FirstOrDefault()
            Frm.Close()
        End If

        FrmTrnApproval1DanInputBarangPengajuanWoPancang.openFormBy = "BarangRequest"
        BukaMenu(FrmTrnApproval1DanInputBarangPengajuanWoPancang, mnuTrnWOPancangBarangRequest)
    End Sub

    Private Sub mnuTrnWOPancangPembayaranDanPelunasan_Click(sender As Object, e As EventArgs) Handles mnuTrnWOPancangPembayaranDanPelunasan.Click
        BukaMenu(FrmTrnPembayaranWoPancang, mnuTrnWOPancangPembayaranDanPelunasan)
    End Sub

    Private Sub mnuTrnWOPancangUploadInspection_Click(sender As Object, e As EventArgs) Handles mnuTrnWOPancangUploadInspection.Click
        FrmTrnUploadInspectionWoPancang.Show()
    End Sub

    Private Sub mnuTrnWOPancangUploadBA_Click(sender As Object, e As EventArgs) Handles mnuTrnWOPancangUploadBA.Click
        FrmTrnUploadBaWoPancang.Show()
    End Sub

    Private Sub mnuTrnPengajuanPenerimaanNota_Click(sender As Object, e As EventArgs) Handles mnuTrnPengajuanPenerimaanNota.Click
        BukaMenu(FrmTrnPengajuanPenerimaanNota, mnuTrnPengajuanPenerimaanNota)
    End Sub

    Private Sub mnuTrnPenjualanRSUPPSGDanRelasi_Click(sender As Object, e As EventArgs) Handles mnuTrnPenjualanRSUPPSGDanRelasi.Click
        BukaMenu(FrmTrnPenjualan, mnuTrnPenjualanRSUPPSGDanRelasi)
    End Sub

    Private Sub mnuTrnPenjualanRestore_Click(sender As Object, e As EventArgs) Handles mnuTrnPenjualanRestore.Click
        BukaMenu(FrmTrnPenjualanRestore, mnuTrnPenjualanRestore)
    End Sub

    Private Sub mnuTrnPenjualanRestoreFakturBongkar_Click(sender As Object, e As EventArgs) Handles mnuTrnPenjualanRestoreFakturBongkar.Click
        BukaMenu(FrmTrnPenjualanRestoreFakturPabrik, mnuTrnPenjualanRestoreFakturBongkar)
    End Sub

    Private Sub mnuTrnPenjualanNonDataBongkar_Click(sender As Object, e As EventArgs) Handles mnuTrnPenjualanNonDataBongkar.Click
        BukaMenu(FrmTrnPenjualanNonDataBongkar, mnuTrnPenjualanNonDataBongkar)
    End Sub

    Private Sub mnuTrnPotonganRelasi_Click(sender As Object, e As EventArgs) Handles mnuTrnPotonganRelasi.Click
        BukaMenu(FrmTrnPotonganRelasiFind, mnuTrnPotonganRelasi)
    End Sub

    Private Sub mnuTrnTambangKapal_Click(sender As Object, e As EventArgs) Handles mnuTrnTambangKapal.Click
        BukaMenu(FrmTrnTambangKapalBPIFind, mnuTrnTambangKapal)
    End Sub

    Private Sub mnuTrnUpahBongkar_Click(sender As Object, e As EventArgs) Handles mnuTrnUpahBongkar.Click
        BukaMenu(FrmTrnUpahBongkar, mnuTrnUpahBongkar)
    End Sub

    Private Sub mnuTrnKomisi_Click(sender As Object, e As EventArgs) Handles mnuTrnKomisi.Click
        BukaMenu(FrmTrnKomisiFind, mnuTrnKomisi)
    End Sub

    Private Sub mnuTrnPembelianNonPancang_Click(sender As Object, e As EventArgs) Handles mnuTrnPembelianNonPancang.Click
        BukaMenu(FrmTrnPembelianNonPancang, mnuTrnPembelianNonPancang)
    End Sub

    Private Sub mnuTrnHargaNego_Click(sender As Object, e As EventArgs) Handles mnuTrnHargaNego.Click
        BukaMenu(FrmInputHargaNego, mnuTrnHargaNego)
    End Sub

    Private Sub mnuTrnPremiPremiPengawas_Click(sender As Object, e As EventArgs) Handles mnuTrnPremiPremiPengawas.Click
        BukaMenu(FrmTrnPremiPengawas, mnuTrnPremiPremiPengawas)
    End Sub

    Private Sub mnuTrnPremiPremiInspektur_Click(sender As Object, e As EventArgs) Handles mnuTrnPremiPremiInspektur.Click
        BukaMenu(FrmPremiInspektor, mnuTrnPremiPremiInspektur)
    End Sub

    Private Sub mnuTrnLoyaltyVerifikasiPenukaranPoint_Click(sender As Object, e As EventArgs) Handles mnuTrnLoyaltyVerifikasiPenukaranPoint.Click
        BukaMenu(FrmTrnPoinPengajuanFind, mnuTrnLoyaltyVerifikasiPenukaranPoint)
    End Sub

    Private Sub mnuTrnLoyaltyBuktiBayar_Click(sender As Object, e As EventArgs) Handles mnuTrnLoyaltyBuktiBayar.Click
        BukaMenu(FrmTrnBuktiTrfPengajuanPoinFind, mnuTrnLoyaltyBuktiBayar)
    End Sub

    Private Sub mnuTrnInventarisBarangMasukPancang_Click(sender As Object, e As EventArgs) Handles mnuTrnInventarisBarangMasukPancang.Click
        BukaMenu(FrmTrnBarangMasuk, mnuTrnInventarisBarangMasukPancang)
    End Sub

    Private Sub mnuTrnInventarisApprovalPengeluaranBarang_Click(sender As Object, e As EventArgs) Handles mnuTrnInventarisApprovalPengeluaranBarang.Click
        BukaMenu(FrmTrnApprovalPengeluaranBarang, mnuTrnInventarisApprovalPengeluaranBarang)
    End Sub

    Private Sub mnuTrnInventarisRestoreBarangBPB_Click(sender As Object, e As EventArgs) Handles mnuTrnInventarisRestoreBarangBPB.Click
        BukaMenu(FrmTrnRestoreBarangMasuk, mnuTrnInventarisRestoreBarangBPB)
    End Sub

    Private Sub mnuTrnInventarisTerimaNotaPembelianCash_Click(sender As Object, e As EventArgs) Handles mnuTrnInventarisTerimaNotaPembelianCash.Click
        BukaMenu(FrmTrnTerimaNotaDiPabrik, mnuTrnInventarisTerimaNotaPembelianCash)
    End Sub

    Private Sub mnuTrnInventarisBarangKeluarPancang_Click(sender As Object, e As EventArgs) Handles mnuTrnInventarisBarangKeluarPancang.Click
        BukaMenu(FrmTrnBarangKeluar, mnuTrnInventarisBarangKeluarPancang)
    End Sub

    Private Sub mnuTrnCetakLabelPetani_Click(sender As Object, e As EventArgs) Handles mnuTrnCetakLabelPetani.Click
        BukaMenu(FrmTrnCetakLabelPetani, mnuTrnCetakLabelPetani)
    End Sub

    Private Sub mnuTrnPersonilPancangAbsensi_Click(sender As Object, e As EventArgs) Handles mnuTrnPersonilPancangAbsensi.Click
        BukaMenu(FrmTrnAbsensiPancang, mnuTrnPersonilPancangAbsensi)
    End Sub
#End Region

#Region "Menu Approval"
    Private Sub mnuAprRekeningSupplierLevel1_Click(sender As Object, e As EventArgs) Handles mnuAprRekeningSupplierLevel1.Click
        FrmApproveRekening.KodeApproval = 1
        BukaMenu(FrmApproveRekening, mnuAprRekeningSupplierLevel1)
    End Sub

    Private Sub mnuAprRekeningSupplierLevel2_Click(sender As Object, e As EventArgs) Handles mnuAprRekeningSupplierLevel2.Click
        FrmApproveRekening.KodeApproval = 2
        BukaMenu(FrmApproveRekening, mnuAprRekeningSupplierLevel2)
    End Sub

    Private Sub mnuAprHargaNegoLevel1_Click(sender As Object, e As EventArgs) Handles mnuAprHargaNegoLevel1.Click
        FrmApprovedHargaNego.KodeApproved = 1
        BukaMenu(FrmApprovedHargaNego, mnuAprHargaNegoLevel1)
    End Sub

    Private Sub mnuAprHargaNegoLevel2_Click(sender As Object, e As EventArgs) Handles mnuAprHargaNegoLevel2.Click
        FrmApprovedHargaNego.KodeApproved = 2
        BukaMenu(FrmApprovedHargaNego, mnuAprHargaNegoLevel2)
    End Sub

    Private Sub mnuAprHargaNegoLevel3_Click(sender As Object, e As EventArgs) Handles mnuAprHargaNegoLevel3.Click
        FrmApprovedHargaNego.KodeApproved = 3
        BukaMenu(FrmApprovedHargaNego, mnuAprHargaNegoLevel3)
    End Sub

    Private Sub mnuAprPenerimaanNotaLevel1_Click(sender As Object, e As EventArgs) Handles mnuAprPenerimaanNotaLevel1.Click
        If FrmApprovalPenerimaanKelapa IsNot Nothing Then
            If Not FrmApprovalPenerimaanKelapa.IsDisposed Then
                FrmApprovalPenerimaanKelapa.Close()
            End If
        End If
        FrmApprovalPenerimaanKelapa.Approval = "Approval1"
        BukaMenu(FrmApprovalPenerimaanKelapa, mnuAprPenerimaanNotaLevel1)
    End Sub

    Private Sub mnuAprPenerimaanNotaLevel2_Click(sender As Object, e As EventArgs) Handles mnuAprPenerimaanNotaLevel2.Click
        If FrmApprovalPenerimaanKelapa IsNot Nothing Then
            If Not FrmApprovalPenerimaanKelapa.IsDisposed Then
                FrmApprovalPenerimaanKelapa.Close()
            End If
        End If
        FrmApprovalPenerimaanKelapa.Approval = "Approval2"
        BukaMenu(FrmApprovalPenerimaanKelapa, mnuAprPenerimaanNotaLevel2)
    End Sub

    Private Sub mnuAprPenerimaanNotaLevel3_Click(sender As Object, e As EventArgs) Handles mnuAprPenerimaanNotaLevel3.Click
        If FrmApprovalPenerimaanKelapa IsNot Nothing Then
            If Not FrmApprovalPenerimaanKelapa.IsDisposed Then
                FrmApprovalPenerimaanKelapa.Close()
            End If
        End If
        FrmApprovalPenerimaanKelapa.Approval = "Approval3"
        BukaMenu(FrmApprovalPenerimaanKelapa, mnuAprPenerimaanNotaLevel3)
    End Sub

    Private Sub mnuAprPenjualanLevel1_Click(sender As Object, e As EventArgs) Handles mnuAprPenjualanLevel1.Click

    End Sub

    Private Sub mnuAprPenjualanLevel2_Click(sender As Object, e As EventArgs) Handles mnuAprPenjualanLevel2.Click

    End Sub

    Private Sub mnuAprPenjualanLevel3_Click(sender As Object, e As EventArgs) Handles mnuAprPenjualanLevel3.Click

    End Sub

    Private Sub mnuAprTambangKapalLevel1_Click(sender As Object, e As EventArgs) Handles mnuAprTambangKapalLevel1.Click
        If FrmApprovalTambangKapal IsNot Nothing Then
            If Not FrmApprovalTambangKapal.IsDisposed Then
                FrmApprovalTambangKapal.Close()
            End If
        End If
        FrmApprovalTambangKapal.Approval = "Approval1"
        BukaMenu(FrmApprovalTambangKapal, mnuAprTambangKapalLevel1)
    End Sub

    Private Sub mnuAprTambangKapalLevel2_Click(sender As Object, e As EventArgs) Handles mnuAprTambangKapalLevel2.Click
        If FrmApprovalTambangKapal IsNot Nothing Then
            If Not FrmApprovalTambangKapal.IsDisposed Then
                FrmApprovalTambangKapal.Close()
            End If
        End If
        FrmApprovalTambangKapal.Approval = "Approval2"
        BukaMenu(FrmApprovalTambangKapal, mnuAprTambangKapalLevel2)
    End Sub

    Private Sub mnuAprTambangKapalLevel3_Click(sender As Object, e As EventArgs) Handles mnuAprTambangKapalLevel3.Click
        If FrmApprovalTambangKapal IsNot Nothing Then
            If Not FrmApprovalTambangKapal.IsDisposed Then
                FrmApprovalTambangKapal.Close()
            End If
        End If
        FrmApprovalTambangKapal.Approval = "Approval3"
        BukaMenu(FrmApprovalTambangKapal, mnuAprTambangKapalLevel3)
    End Sub

    Private Sub mnuAprUpahBongkarLevel1_Click(sender As Object, e As EventArgs) Handles mnuAprUpahBongkarLevel1.Click
        If FrmApprovalUpahBongkar IsNot Nothing Then
            If Not FrmApprovalUpahBongkar.IsDisposed Then
                FrmApprovalUpahBongkar.Close()
            End If
        End If
        FrmApprovalUpahBongkar.Approval = "Approval1"
        BukaMenu(FrmApprovalUpahBongkar, mnuAprUpahBongkarLevel1)
    End Sub

    Private Sub mnuAprUpahBongkarLevel2_Click(sender As Object, e As EventArgs) Handles mnuAprUpahBongkarLevel2.Click
        If FrmApprovalUpahBongkar IsNot Nothing Then
            If Not FrmApprovalUpahBongkar.IsDisposed Then
                FrmApprovalUpahBongkar.Close()
            End If
        End If
        FrmApprovalUpahBongkar.Approval = "Approval2"
        BukaMenu(FrmApprovalUpahBongkar, mnuAprUpahBongkarLevel2)
    End Sub

    Private Sub mnuAprUpahBongkarLevel3_Click(sender As Object, e As EventArgs) Handles mnuAprUpahBongkarLevel3.Click
        If FrmApprovalUpahBongkar IsNot Nothing Then
            If Not FrmApprovalUpahBongkar.IsDisposed Then
                FrmApprovalUpahBongkar.Close()
            End If
        End If
        FrmApprovalUpahBongkar.Approval = "Approval3"
        BukaMenu(FrmApprovalUpahBongkar, mnuAprUpahBongkarLevel3)
    End Sub

    Private Sub mnuAprKomisiLevel1_Click(sender As Object, e As EventArgs) Handles mnuAprKomisiLevel1.Click
        If FrmApprovalKomisi IsNot Nothing Then
            If Not FrmApprovalKomisi.IsDisposed Then
                FrmApprovalKomisi.Close()
            End If
        End If
        FrmApprovalKomisi.Approval = "Approval1"
        BukaMenu(FrmApprovalKomisi, mnuAprKomisiLevel1)
    End Sub

    Private Sub mnuAprKomisiLevel2_Click(sender As Object, e As EventArgs) Handles mnuAprKomisiLevel2.Click
        If FrmApprovalKomisi IsNot Nothing Then
            If Not FrmApprovalKomisi.IsDisposed Then
                FrmApprovalKomisi.Close()
            End If
        End If
        FrmApprovalKomisi.Approval = "Approval2"
        BukaMenu(FrmApprovalKomisi, mnuAprKomisiLevel2)
    End Sub

    Private Sub mnuAprKomisiLevel3_Click(sender As Object, e As EventArgs) Handles mnuAprKomisiLevel3.Click
        If FrmApprovalKomisi IsNot Nothing Then
            If Not FrmApprovalKomisi.IsDisposed Then
                FrmApprovalKomisi.Close()
            End If
        End If
        FrmApprovalKomisi.Approval = "Approval3"
        BukaMenu(FrmApprovalKomisi, mnuAprKomisiLevel3)
    End Sub

    Private Sub mnuAprLoyaltyUser_Click(sender As Object, e As EventArgs) Handles mnuAprLoyaltyUser.Click
        BukaMenu(FrmApprovelUserToko, mnuAprLoyaltyUser)
    End Sub

    Private Sub mnuAprLoyaltyToko_Click(sender As Object, e As EventArgs) Handles mnuAprLoyaltyToko.Click
        BukaMenu(FrmApprovalTokoPancang, mnuAprLoyaltyToko)
    End Sub
#End Region

#Region "Menu Monitoring"
    Private Sub mnuMonNotaNota_Click(sender As Object, e As EventArgs) Handles mnuMonNotaNota.Click
        BukaMenu(FrmMonNotaTimbangPancang, mnuMonNotaNota)
    End Sub

    Private Sub mnuMonNotaPengajuanPenerimaanNotaProgress_Click(sender As Object, e As EventArgs) Handles mnuMonNotaPengajuanPenerimaanNotaProgress.Click
        BukaMenu(FrmMonPengajuanPenerimaanNotaProgres, mnuMonNotaPengajuanPenerimaanNotaProgress)
    End Sub

    Private Sub mnuMonNotaPengajuanPenerimaanNotaRekap_Click(sender As Object, e As EventArgs) Handles mnuMonNotaPengajuanPenerimaanNotaRekap.Click
        BukaMenu(FrmMonPengajuanPenerimaanNotaRekap, mnuMonNotaPengajuanPenerimaanNotaRekap)
    End Sub

    Private Sub mnuMonAbsensiPergeseran_Click(sender As Object, e As EventArgs) Handles mnuMonAbsensiPergeseran.Click
        BukaMenu(FrmMonPenggeseranAbsensiPancang, mnuMonAbsensiPergeseran)
    End Sub

    Private Sub mnuMonSupplierSupplier_Click(sender As Object, e As EventArgs) Handles mnuMonSupplierSupplier.Click
        BukaMenu(FrmMonSupplier, mnuMonSupplierSupplier)
    End Sub

    Private Sub mnuMonSupplierApproval_Click(sender As Object, e As EventArgs) Handles mnuMonSupplierApproval.Click
        BukaMenu(FrmMonSupplierApproval, mnuMonSupplierApproval)
    End Sub

    Private Sub mnuMonRekeningRekening_Click(sender As Object, e As EventArgs) Handles mnuMonRekeningRekening.Click
        BukaMenu(FrmMonRekeningRelasiPcg, mnuMonRekeningRekening)
    End Sub

    Private Sub mnuMonRekeningApprove_Click(sender As Object, e As EventArgs) Handles mnuMonRekeningApprove.Click
        BukaMenu(FrmMonRekeningRelasiPcgApprove, mnuMonRekeningApprove)
    End Sub

    Private Sub mnuMonRekeningCustomerCard_Click(sender As Object, e As EventArgs) Handles mnuMonRekeningCustomerCard.Click
        BukaMenu(FrmMonCustomerCard, mnuMonRekeningCustomerCard)
    End Sub

    Private Sub mnuMonRekeningPercentagePancang_Click(sender As Object, e As EventArgs) Handles mnuMonRekeningPercentagePancang.Click
        BukaMenu(FrmMonPercentagePancang, mnuMonRekeningPercentagePancang)
    End Sub

    Private Sub mnuMonKapalKapalRekap_Click(sender As Object, e As EventArgs) Handles mnuMonKapalKapalRekap.Click
        BukaMenu(FrmMonKapalRekap, mnuMonKapalKapalRekap)
    End Sub

    Private Sub mnuMonKapalKapalRekapPSGRSUP_Click(sender As Object, e As EventArgs) Handles mnuMonKapalKapalRekapPSGRSUP.Click
        BukaMenu(FrmMonKapalRekapPsgRsup, mnuMonKapalKapalRekapPSGRSUP)
    End Sub

    Private Sub mnuMonKapalKapalPoint_Click(sender As Object, e As EventArgs) Handles mnuMonKapalKapalPoint.Click
        BukaMenu(FrmMonPointKapalRanking, mnuMonKapalKapalPoint)
    End Sub

    Private Sub mnuMonKapalKapalSusut_Click(sender As Object, e As EventArgs) Handles mnuMonKapalKapalSusut.Click
        BukaMenu(FrmMonKapalSusust, mnuMonKapalKapalSusut)
    End Sub

    Private Sub mnuMonKapalKapalDocking_Click(sender As Object, e As EventArgs) Handles mnuMonKapalKapalDocking.Click
        BukaMenu(FrmMonDokingKapal, mnuMonKapalKapalDocking)
    End Sub

    Private Sub mnuMonKapalKapalPemeriksaan_Click(sender As Object, e As EventArgs) Handles mnuMonKapalKapalPemeriksaan.Click
        BukaMenu(FrmMonPemeriksaanKapal, mnuMonKapalKapalPemeriksaan)
    End Sub

    Private Sub mnuMonKapalKapalSelesaiBongkarPancang_Click(sender As Object, e As EventArgs) Handles mnuMonKapalKapalSelesaiBongkarPancang.Click
        BukaMenu(FrmMonKapalSelesaiPancang, mnuMonKapalKapalSelesaiBongkarPancang)
    End Sub

    Private Sub mnuMonKapalProgres_Click(sender As Object, e As EventArgs) Handles mnuMonKapalProgres.Click
        BukaMenu(FrmMonProgresNotaPancang, mnuMonKapalProgres)
    End Sub

    Private Sub mnuMonKapalPelangsirPelangsir_Click(sender As Object, e As EventArgs) Handles mnuMonKapalPelangsirPelangsir.Click
        BukaMenu(FrmMonKapalPelangsir, mnuMonKapalPelangsirPelangsir)
    End Sub

    Private Sub mnuMonKapalPelangsirCheckIn_Click(sender As Object, e As EventArgs) Handles mnuMonKapalPelangsirCheckIn.Click
        BukaMenu(FrmMonCheckinPelangsir, mnuMonKapalPelangsirCheckIn)
    End Sub

    Private Sub mnuMonKapalTambangProgress_Click(sender As Object, e As EventArgs) Handles mnuMonKapalTambangProgress.Click
        BukaMenu(FrmMonProgressTambangKapal, mnuMonKapalTambangProgress)
    End Sub

    Private Sub mnuMonKapalTambangRekap_Click(sender As Object, e As EventArgs) Handles mnuMonKapalTambangRekap.Click
        BukaMenu(FrmMonRekapPengajuanTambangKapal, mnuMonKapalTambangRekap)
    End Sub

    Private Sub mnuMonHargaNego_Click(sender As Object, e As EventArgs) Handles mnuMonHargaApprovalNego.Click
        BukaMenu(FrmMonApproveHargaNego, mnuMonHargaApprovalNego)
    End Sub

    Private Sub mnuMonHargaBeliBahanBakuBeliHargaBahanBaku_Click(sender As Object, e As EventArgs) Handles mnuMonHargaBeliBahanBakuBeliHargaBahanBaku.Click
        BukaMenu(FrmMonHargaPancang, mnuMonHargaBeliBahanBakuBeliHargaBahanBaku)
    End Sub

    Private Sub mnuMonHargaBeliBahanBakuApprove_Click(sender As Object, e As EventArgs) Handles mnuMonHargaBeliBahanBakuApprove.Click
        BukaMenu(FrmMonApprovalHarga, mnuMonHargaBeliBahanBakuApprove)
    End Sub

    Private Sub mnuMonWOPancang_Click(sender As Object, e As EventArgs) Handles mnuMonWOPancang.Click
        BukaMenu(FrmMonWoPancang, mnuMonWOPancang)
    End Sub

    Private Sub mnuMonPemakaianSolar_Click(sender As Object, e As EventArgs) Handles mnuMonPemakaianSolar.Click
        BukaMenu(FrmMonPemakaianSolar, mnuMonPemakaianSolar)
    End Sub

    Private Sub mnuMonDetailTimbangKelapaPancang_Click(sender As Object, e As EventArgs) Handles mnuMonDetailTimbangKelapaPancang.Click
        BukaMenu(FrmMonDtlTimbangKelapaPCG, mnuMonDetailTimbangKelapaPancang)
    End Sub

    Private Sub mnuMonVerifikasiTimbanganPancang_Click(sender As Object, e As EventArgs) Handles mnuMonVerifikasiTimbanganPancang.Click
        BukaMenu(FrmMonVerifikasiTimbangPCG, mnuMonVerifikasiTimbanganPancang)
    End Sub

    Private Sub mnuMonPembayaranSupplierKeToke_Click(sender As Object, e As EventArgs) Handles mnuMonPembayaranSupplierKeToke.Click
        BukaMenu(FrmMonPembayaranSupplierKeToke, mnuMonPembayaranSupplierKeToke)
    End Sub

    Private Sub mnuMonPenjualanProgress_Click(sender As Object, e As EventArgs) Handles mnuMonPenjualanProgress.Click
        BukaMenu(FrmMonProgressPembuatanPenjualan, mnuMonPenjualanProgress)
    End Sub

    Private Sub mnuMonPenjualanRekap_Click(sender As Object, e As EventArgs) Handles mnuMonPenjualanRekap.Click
        BukaMenu(FrmMonRekapPengajuanPembuatanPenjualan, mnuMonPenjualanRekap)
    End Sub

    Private Sub mnuMonRekapUpahBongkar_Click(sender As Object, e As EventArgs) Handles mnuMonRekapUpahBongkar.Click
        BukaMenu(FrmMonRekapPengajuanUpahBongkar, mnuMonRekapUpahBongkar)
    End Sub

    Private Sub mnuMonRekapKomisi_Click(sender As Object, e As EventArgs) Handles mnuMonRekapKomisi.Click
        BukaMenu(FrmMonRekapPengajuanKomisi, mnuMonRekapKomisi)
    End Sub

    Private Sub mnuMonAkumulasiDPPSupplier_Click(sender As Object, e As EventArgs) Handles mnuMonAkumulasiDPPSupplier.Click
        BukaMenu(FrmMonAkumulasiDPPRelasiBPI, mnuMonAkumulasiDPPSupplier)
    End Sub

    Private Sub mnuMonPremiRelasiLoyal_Click(sender As Object, e As EventArgs) Handles mnuMonPremiRelasiLoyal.Click
        BukaMenu(FrmMonRelasiLoyal, mnuMonPremiRelasiLoyal)
    End Sub

    Private Sub mnuMonPremiRelasiTidakLoyal_Click(sender As Object, e As EventArgs) Handles mnuMonPremiRelasiTidakLoyal.Click
        BukaMenu(FrmMonRelasiTdkLoyal, mnuMonPremiRelasiTidakLoyal)
    End Sub

    Private Sub mnuMonLoyaltyPoint_Click(sender As Object, e As EventArgs) Handles mnuMonLoyaltyPoint.Click
        BukaMenu(FrmMonLoyaltyCashBack, mnuMonLoyaltyPoint)
    End Sub

    Private Sub mnuMonLoyaltyPengajuanPembayaranPoint_Click(sender As Object, e As EventArgs) Handles mnuMonLoyaltyPengajuanPembayaranPoint.Click
        BukaMenu(FrmMonPengajuanPoinNew, mnuMonLoyaltyPengajuanPembayaranPoint)
    End Sub

    Private Sub mnuMonLoyaltyRelasi_Click(sender As Object, e As EventArgs) Handles mnuMonLoyaltyRelasi.Click
        BukaMenu(FrmMonLoyaltyCashBackRelasiNew, mnuMonLoyaltyRelasi)
    End Sub

    Private Sub mnuMonInventarisBarangInventarisPancang_Click(sender As Object, e As EventArgs) Handles mnuMonInventarisBarangInventarisPancang.Click
        BukaMenu(FrmMonBarangInventarisPancang, mnuMonInventarisBarangInventarisPancang)
    End Sub

    Private Sub mnuMonInventarisPembelianBarangCash_Click(sender As Object, e As EventArgs) Handles mnuMonInventarisPembelianBarangCash.Click
        BukaMenu(FrmMonPembelianBarangPancangCash, mnuMonInventarisPembelianBarangCash)
    End Sub

    Private Sub mnuMonInventarisReportPembelianBarangCash_Click(sender As Object, e As EventArgs) Handles mnuMonInventarisReportPembelianBarangCash.Click
        BukaMenu(FrmRptPembelianBarangCashPancang, mnuMonInventarisReportPembelianBarangCash)
    End Sub

    Private Sub mnuMonLaporanMuatKelapa_Click(sender As Object, e As EventArgs) Handles mnuMonLaporanMuatKelapa.Click
        BukaMenu(FrmLaporanMuatKelapa, mnuMonLaporanMuatKelapa)
    End Sub

    Private Sub mnuMonPenerimaanKelapaTimbang_Click(sender As Object, e As EventArgs) Handles mnuMonPenerimaanKelapaTimbang.Click
        BukaMenu(FrmMonPenerimaanKBKg, mnuMonPenerimaanKelapaTimbang)
    End Sub

    Private Sub mnuMonPenerimaanPabrikLaporanTerimaPabrik_Click(sender As Object, e As EventArgs) Handles mnuMonPenerimaanPabrikLaporanTerimaPabrik.Click
        BukaMenu(FrmMonPenerimaanPabrikKelapaBPI, mnuMonPenerimaanPabrikLaporanTerimaPabrik)
    End Sub

    Private Sub mnuMonPenerimaanPabrikInformasiPenerimaanBahanBaku_Click(sender As Object, e As EventArgs) Handles mnuMonPenerimaanPabrikInformasiPenerimaanBahanBaku.Click
        BukaMenu(FrmMonInformasiPenerimaanBahanBaku, mnuMonPenerimaanPabrikInformasiPenerimaanBahanBaku)
    End Sub

    Private Sub mnuMonPenerimaanBahanBaku_Click(sender As Object, e As EventArgs) Handles mnuMonPenerimaanBahanBaku.Click
        BukaMenu(FrmMonPenerimaanBahanBaku, mnuMonPenerimaanBahanBaku)
    End Sub
#End Region

    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        Application.Exit()
    End Sub


End Class