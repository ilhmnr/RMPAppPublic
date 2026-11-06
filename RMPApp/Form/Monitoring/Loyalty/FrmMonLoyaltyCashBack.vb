Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports ClosedXML.Excel

Public Class FrmMonLoyaltyCashBack
    Dim adapter As SqlDataAdapter
    Dim connetionString As String
    Dim connection As SqlConnection
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub FrmMonLoyaltyCashBack_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtSum.Text = Now.AddMonths(-3)
        fg.Clear()
        fg.Row = 0
        fg.Col = 0
        fg.DataSource = Nothing

        dtcb1.Value = Format(Now, "dd/MM/yyyy")
        HeaderFG()
        schKg()
        Modul_RMP.Combo.SetSupplier(cmbS_Petani)

    End Sub

    Public Sub HeaderFG()

        Dim txt As CellRange
        With fg
            .Font = New System.Drawing.Font("Century Gothic", 9.0!)
            .Styles.Fixed.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
            .Cols.Count = 51
            .Cols.Fixed = 0

            .Styles.Fixed.BackColor = Color.FromArgb(83, 141, 213)

            .Rows(1).StyleFixedNew.BackColor = Color.FromArgb(250, 191, 143)

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 3
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Rows(1).AllowMerging = True
            fg.Cols.Frozen = 9
        End With
    End Sub

    Private Sub CELL2()
        Dim txt As CellRange
        With fg

            txt = .GetCellRange(0, 0, 2, 0) : txt.Data = "ID Petani" : .Cols(0).Width = 120 : .Cols(0).Name = "IDSubPetani" : .Cols(0).TextAlign = TextAlignEnum.LeftCenter : .Cols(0).AllowMerging = True : .Cols(0).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 1, 2, 1) : txt.Data = "NAMA PEMILIK KELAPA/ SUB PETANI" : .Cols(1).Width = 80 : .Cols(1).Name = "SubPetani" : .Cols(1).AllowMerging = True : .Cols(1).TextAlign = TextAlignEnum.LeftCenter : .Cols(1).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 2, 2, 2) : txt.Data = "ID PETANI" : .Cols(2).Name = "IDSubPetani2" : .Cols(2).Width = 70 : .Cols(2).TextAlign = TextAlignEnum.LeftCenter : .Cols(2).AllowMerging = True : .Cols(2).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(2).Visible = False
            txt = .GetCellRange(0, 3, 2, 3) : txt.Data = "NAMA PEMILIK KELAPA/ SUB PETANI" : .Cols(3).Width = 80 : .Cols(3).Name = "SubPetani2" : .Cols(3).TextAlign = TextAlignEnum.LeftCenter : .Cols(3).AllowMerging = True : .Cols(3).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(3).Visible = False
            txt = .GetCellRange(0, 4, 2, 4) : txt.Data = "IDPENERIMA UANG" : .Cols(4).Name = "IDPenerimaUang" : .Cols(4).Width = 70 : .Cols(4).TextAlign = TextAlignEnum.LeftCenter : .Cols(4).AllowMerging = True : .Cols(4).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(4).Visible = False
            txt = .GetCellRange(0, 5, 2, 5) : txt.Data = "PENERIMA UANG" : .Cols(5).Name = "PenerimaUang" : .Cols(5).Width = 80 : .Cols(5).TextAlign = TextAlignEnum.LeftCenter : .Cols(5).AllowMerging = True : .Cols(5).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(5).Visible = False

            txt = .GetCellRange(0, 6, 2, 6) : txt.Data = "PANCANG" : .Cols(6).Name = "Pancang" : .Cols(6).Width = 80 : .Cols(6).TextAlign = TextAlignEnum.LeftCenter : .Cols(6).AllowMerging = True : .Cols(6).TextAlignFixed = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 7, 2, 7) : txt.Data = "NONOTA" : .Cols(7).Name = "nonota" : .Cols(7).Visible = False
            txt = .GetCellRange(0, 8, 2, 8) : txt.Data = "KLASIFIKASI" : .Cols(8).Name = "Klasifikasi" : .Cols(8).TextAlign = TextAlignEnum.LeftCenter : .Cols(8).AllowMerging = True

            txt = .GetCellRange(0, 9, 0, 11) : txt.Data = "TRANS-PERIODE / - 3 BLN" : .Cols(9).Name = "TransDate3" : .Cols(9).Width = 80 : .Cols(9).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(9).AllowMerging = True
            txt = .GetCellRange(1, 9, 2, 9) : txt.Data = "START DATE(-3Month)" : .Cols(9).Name = "TransDate3" : .Cols(9).Width = 80 : .Cols(9).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(9).AllowMerging = True
            txt = .GetCellRange(1, 10, 2, 10) : txt.Data = "VOL.Kg (-3Month) " : .Cols(10).Name = "TotalVolKg3" : .Cols(10).Width = 80 : .Cols(10).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(10).AllowMerging = True : .Cols(10).Format = "#,###0"
            txt = .GetCellRange(1, 11, 2, 11) : txt.Data = "KLASIFIKASI(-3Month)" : .Cols(11).Name = "Klasifikasi3" : .Cols(11).Width = 80 : .Cols(11).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(11).AllowMerging = True : .Cols(11).Visible = False

            txt = .GetCellRange(0, 12, 2, 12) : txt.Data = "TRANS DATE" : .Cols(12).Name = "TransDate" : .Cols(12).Width = 80 : .Cols(12).TextAlign = TextAlignEnum.LeftCenter : .Cols(12).AllowMerging = True : .Cols(12).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 13, 2, 13) : txt.Data = "JENIS" : .Cols(13).Name = "Jenis" : .Cols(13).Width = 50 : .Cols(13).TextAlign = TextAlignEnum.LeftCenter : .Cols(13).AllowMerging = True : .Cols(13).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 14, 2, 14) : txt.Data = "TARRA(%)" : .Cols(14).Name = "TarraPersen" : .Cols(14).Width = 50 : .Cols(14).AllowMerging = True : .Cols(14).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 15, 2, 15) : txt.Data = "VOLUME N-2 (Kg)" : .Cols(15).Name = "VolumeKg" : .Cols(15).Width = 60 : .Cols(15).TextAlign = TextAlignEnum.RightCenter : .Cols(15).AllowMerging = True : .Cols(15).Format = "#,###0" : .Cols(15).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(0, 16, 2, 16) : txt.Data = "AKUM VOLUME KB(Kg)" : .Cols(16).Name = "TotalVolKg" : .Cols(16).Width = 80 : .Cols(16).TextAlign = TextAlignEnum.RightCenter : .Cols(16).AllowMerging = True : .Cols(16).Format = "#,###0" : .Cols(16).TextAlignFixed = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 17, 2, 17) : txt.Data = "POINT/KG" : .Cols(17).Name = "PointSupplier" : .Cols(17).AllowMerging = True : .Cols(17).Width = 50 : .Cols(17).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(17).Format = "#,###0"

            txt = .GetCellRange(0, 18, 2, 29) : txt.Data = "LOYALTY REWARD" : .Cols(18).Name = "JumlahPoint" : .Cols(18).Width = 80 : .Cols(18).TextAlign = TextAlignEnum.RightCenter : .Cols(18).AllowMerging = True : .Cols(18).Format = "#,###0" : .Cols(18).TextAlignFixed = TextAlignEnum.CenterCenter

            txt = .GetCellRange(1, 18, 2, 18) : txt.Data = "POINT" : .Cols(18).Name = "JumlahPoint" : .Cols(18).Width = 80 : .Cols(18).TextAlign = TextAlignEnum.RightCenter : .Cols(18).AllowMerging = True : .Cols(18).Format = "#,###0" : .Cols(18).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 19, 2, 19) : txt.Data = "JUMLAH POINT/AKUMULASI " : .Cols(19).Name = "jumlahpointakum" : .Cols(19).Width = 80 : .Cols(19).TextAlign = TextAlignEnum.RightCenter : .Cols(19).AllowMerging = True : .Cols(19).Format = "#,###0" : .Cols(19).AllowMerging = True : .Cols(19).Visible = False

            txt = .GetCellRange(1, 20, 2, 20) : txt.Data = "NoReffQL" : .Cols(20).Name = "NoReff" : .Cols(20).Visible = False : .Cols(20).TextAlign = TextAlignEnum.LeftCenter : .Cols(20).AllowMerging = True : .Cols(20).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 21, 2, 21) : txt.Data = "NoReff" : .Cols(21).Visible = False

            txt = .GetCellRange(1, 22, 2, 23) : txt.Data = "REK.SENDIRI" : .Cols(22).TextAlign = TextAlignEnum.CenterCenter : .Cols(22).AllowMerging = True
            txt = .GetCellRange(1, 22, 2, 22) : txt.Data = "%" : .Cols(22).Name = "persenrek" : .Cols(22).Width = 50 : .Cols(22).AllowMerging = True : .Cols(22).Format = "#,###0" : .Cols(22).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(22).Visible = False
            txt = .GetCellRange(1, 23, 2, 23) : txt.Data = "POINT" : .Cols(23).Name = "pointrek" : .Cols(23).Width = 50 : .Cols(23).TextAlign = TextAlignEnum.RightCenter : .Cols(23).AllowMerging = True : .Cols(23).Format = "#,###0" : .Cols(23).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(23).Visible = False
            txt = .GetCellRange(1, 24, 2, 25) : txt.Data = "KUALITAS KELAPA" : .Cols(24).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(24).AllowMerging = True
            txt = .GetCellRange(1, 24, 2, 24) : txt.Data = "%" : .Cols(24).Name = "persenkualitas" : .Cols(24).Width = 50 : .Cols(24).TextAlign = TextAlignEnum.CenterCenter : .Cols(24).AllowMerging = True : .Cols(24).Format = "#,###0" : .Cols(24).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(24).Visible = False
            txt = .GetCellRange(1, 25, 2, 25) : txt.Data = "POINT" : .Cols(25).Name = "PointKualitas" : .Cols(25).Width = 50 : .Cols(25).TextAlign = TextAlignEnum.RightCenter : .Cols(25).AllowMerging = True : .Cols(25).Format = "#,###0" : .Cols(25).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(25).Visible = False
            txt = .GetCellRange(1, 26, 2, 27) : txt.Data = "KB-LICIN" : .Cols(26).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(26).AllowMerging = True
            txt = .GetCellRange(1, 26, 2, 26) : txt.Data = "%" : .Cols(26).Name = "persenlicin" : .Cols(26).Width = 50 : .Cols(26).TextAlign = TextAlignEnum.CenterCenter : .Cols(26).AllowMerging = True : .Cols(26).Format = "#,###0" : .Cols(26).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(26).Visible = False

            txt = .GetCellRange(1, 27, 2, 27) : txt.Data = "TOTAL POINT" : .Cols(27).Name = "totalpoint" : .Cols(27).Visible = False : .Cols(27).Width = 80 : .Cols(27).TextAlignFixed = TextAlignEnum.RightCenter : .Cols(27).Format = "#,###0" : .Cols(27).Visible = False
            txt = .GetCellRange(1, 28, 2, 28) : txt.Data = "RP" : .Cols(28).Name = "RPTOTALPOINT" : .Cols(28).AllowMerging = True : .Cols(28).Width = 80 : .Cols(28).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(28).Format = "#,###0" : .Cols(28).TextAlign = TextAlignEnum.RightCenter
            txt = .GetCellRange(1, 29, 2, 29) : txt.Data = "RPTOTALPOINT/AKUMULASI" : .Cols(29).Name = "RPTOTALPOINTAKUM" : .Cols(29).AllowMerging = True : .Cols(29).Width = 80 : .Cols(29).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(29).Format = "#,###0" : .Cols(29).TextAlign = TextAlignEnum.RightCenter : .Cols(29).Visible = False

            txt = .GetCellRange(0, 30, 2, 30) : txt.Data = "EXPIRED" : .Cols(30).Name = "EXPIRED2" : .Cols(30).Width = 80 : .Cols(30).TextAlign = TextAlignEnum.RightCenter : .Cols(30).AllowMerging = True : .Cols(30).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(30).Visible = False

            txt = .GetCellRange(0, 31, 2, 42) : txt.Data = "PER PERIODE" : .Cols(31).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(31).Visible = False

            txt = .GetCellRange(1, 31, 1, 33) : txt.Data = "TUKAR" : .Cols(31).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(30).Visible = False
            txt = .GetCellRange(2, 31, 2, 31) : txt.Data = "QTY" : .Cols(31).Name = "QTYTUKAR" : .Cols(31).AllowMerging = True : .Cols(31).Width = 80 : .Cols(31).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(31).Format = "#,###0" : .Cols(31).TextAlign = TextAlignEnum.RightCenter : .Cols(31).Visible = False
            txt = .GetCellRange(2, 32, 2, 32) : txt.Data = "POINT" : .Cols(32).Name = "POINTTUKAR" : .Cols(32).AllowMerging = True : .Cols(32).Width = 80 : .Cols(32).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(32).Format = "#,###0" : .Cols(32).TextAlign = TextAlignEnum.RightCenter : .Cols(32).Visible = False
            txt = .GetCellRange(2, 33, 2, 33) : txt.Data = "POINT(RP)" : .Cols(33).Name = "RPPOINTTUKAR" : .Cols(33).AllowMerging = True : .Cols(33).Width = 80 : .Cols(33).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(33).Format = "#,###0" : .Cols(33).TextAlign = TextAlignEnum.RightCenter : .Cols(33).Visible = False

            txt = .GetCellRange(1, 34, 1, 36) : txt.Data = "PENGAJUAN (TOKO)" : .Cols(34).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(2, 34, 2, 34) : txt.Data = "QTY" : .Cols(34).Name = "QTYPENGAJUANTOKO" : .Cols(34).AllowMerging = True : .Cols(34).Width = 80 : .Cols(34).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(34).Format = "#,###0" : .Cols(34).TextAlign = TextAlignEnum.RightCenter : .Cols(34).Visible = False
            txt = .GetCellRange(2, 35, 2, 35) : txt.Data = "POINT" : .Cols(35).Name = "POINTPENGAJUANTOKO" : .Cols(35).AllowMerging = True : .Cols(35).Width = 80 : .Cols(35).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(35).Format = "#,###0" : .Cols(35).TextAlign = TextAlignEnum.RightCenter : .Cols(35).Visible = False
            txt = .GetCellRange(2, 36, 2, 36) : txt.Data = "POINT(RP)" : .Cols(36).Name = "RPPOINTPENGAJUANTOKO" : .Cols(36).AllowMerging = True : .Cols(36).Width = 80 : .Cols(36).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(36).Format = "#,###0" : .Cols(36).TextAlign = TextAlignEnum.RightCenter : .Cols(36).Visible = False

            txt = .GetCellRange(1, 37, 1, 39) : txt.Data = "PENGAJUAN  (APPROVED)" : .Cols(37).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(2, 37, 2, 37) : txt.Data = "QTY" : .Cols(37).Name = "QTYAPPROVE" : .Cols(37).AllowMerging = True : .Cols(37).Width = 80 : .Cols(37).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(37).Format = "#,###0" : .Cols(37).TextAlign = TextAlignEnum.RightCenter : .Cols(37).Visible = False
            txt = .GetCellRange(2, 38, 2, 38) : txt.Data = "POINT" : .Cols(38).Name = "POINTPENGAJUANSDHAPPROVE" : .Cols(38).AllowMerging = True : .Cols(38).Width = 80 : .Cols(38).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(38).Format = "#,###0" : .Cols(38).TextAlign = TextAlignEnum.RightCenter : .Cols(38).Visible = False
            txt = .GetCellRange(2, 39, 2, 39) : txt.Data = "POINT (RP)" : .Cols(39).Name = "RPPOINTPENGAJUANSDHAPPROVE" : .Cols(39).AllowMerging = True : .Cols(39).Width = 80 : .Cols(39).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(39).Format = "#,###0" : .Cols(39).TextAlign = TextAlignEnum.RightCenter : .Cols(39).Visible = False

            txt = .GetCellRange(1, 40, 1, 42) : txt.Data = "PENGAJUAN  (COMPLETE)" : .Cols(40).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(2, 40, 2, 40) : txt.Data = "QTY" : .Cols(40).Name = "QTYCOMPLETE" : .Cols(40).AllowMerging = True : .Cols(40).Width = 80 : .Cols(40).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(40).Format = "#,###0" : .Cols(40).TextAlign = TextAlignEnum.RightCenter : .Cols(40).Visible = False
            txt = .GetCellRange(2, 41, 2, 41) : txt.Data = "POINT" : .Cols(41).Name = "POINTPENGAJUANSDHCOMPLETE" : .Cols(41).AllowMerging = True : .Cols(41).Width = 80 : .Cols(41).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(41).Format = "#,###0" : .Cols(41).TextAlign = TextAlignEnum.RightCenter : .Cols(41).Visible = False
            txt = .GetCellRange(2, 42, 2, 42) : txt.Data = "POINT (RP)" : .Cols(42).Name = "RPPOINTPENGAJUANSDHCOMPLETE" : .Cols(42).AllowMerging = True : .Cols(42).Width = 80 : .Cols(42).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(42).Format = "#,###0" : .Cols(42).TextAlign = TextAlignEnum.RightCenter : .Cols(42).Visible = False

            txt = .GetCellRange(0, 43, 0, 48) : txt.Data = "PER PERIODE" : .Cols(43).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 43, 1, 45) : txt.Data = "PENUKARAN" : .Cols(43).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(2, 43, 2, 43) : txt.Data = "QTY" : .Cols(43).Name = "QTYTOTAL" : .Cols(43).AllowMerging = False : .Cols(43).Width = 80 : .Cols(43).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(43).Format = "#,###0" : .Cols(43).TextAlign = TextAlignEnum.RightCenter : .Cols(43).Visible = False
            txt = .GetCellRange(2, 44, 2, 44) : txt.Data = "POINT" : .Cols(44).Name = "POINTTOTAL" : .Cols(44).AllowMerging = False : .Cols(44).Width = 80 : .Cols(44).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(44).Format = "#,###0" : .Cols(44).TextAlign = TextAlignEnum.RightCenter
            txt = .GetCellRange(2, 45, 2, 45) : txt.Data = "RP" : .Cols(45).Name = "RPPOINTTOTAL" : .Cols(45).AllowMerging = False : .Cols(45).Width = 80 : .Cols(45).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(45).Format = "#,###0" : .Cols(45).TextAlign = TextAlignEnum.RightCenter

            txt = .GetCellRange(1, 46, 1, 47) : txt.Data = "BALANCE" : .Cols(46).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(2, 46, 2, 46) : txt.Data = "POINT" : .Cols(46).Name = "SISAPOINT" : .Cols(46).AllowMerging = True : .Cols(46).Width = 80 : .Cols(46).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(46).Format = "#,###0" : .Cols(46).TextAlign = TextAlignEnum.RightCenter
            txt = .GetCellRange(2, 47, 2, 47) : txt.Data = "RP" : .Cols(47).Name = "SISARPPOINT" : .Cols(47).AllowMerging = True : .Cols(47).Width = 80 : .Cols(47).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(47).Format = "#,###0" : .Cols(47).TextAlign = TextAlignEnum.RightCenter
            txt = .GetCellRange(2, 48, 2, 48) : txt.Data = "EXPIRED DATE" : .Cols(48).Name = "EXPIRED" : .Cols(48).AllowMerging = True : .Cols(48).Width = 80 : .Cols(48).TextAlignFixed = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 49, 2, 50) : txt.Data = "EXPIRED" : .Cols(49).TextAlignFixed = TextAlignEnum.CenterCenter
            txt = .GetCellRange(1, 49, 2, 49) : txt.Data = "POINT" : .Cols(49).Name = "SISAPOINTEXP" : .Cols(49).AllowMerging = True : .Cols(49).Width = 80 : .Cols(49).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(49).Format = "#,###0" : .Cols(49).TextAlign = TextAlignEnum.RightCenter
            txt = .GetCellRange(1, 50, 2, 50) : txt.Data = "RP" : .Cols(50).Name = "SISARPPOINTEXP" : .Cols(50).AllowMerging = True : .Cols(50).Width = 80 : .Cols(50).TextAlignFixed = TextAlignEnum.CenterCenter : .Cols(50).Format = "#,###0" : .Cols(50).TextAlign = TextAlignEnum.RightCenter

            txt = .GetCellRange(0, 51, 2, 51) : txt.Data = "AKUM  POIN/PERTAHUN" : .Cols(51).Name = "AKUMPOINPERTAHUN" : .Cols(51).AllowMerging = True : .Cols(51).Width = 120 : .Cols(51).Format = "#,###0" : .Cols(51).TextAlign = TextAlignEnum.RightCenter
            txt = .GetCellRange(0, 52, 2, 52) : txt.Data = "AKUM POINT (NO EXP)" : .Cols(52).Name = "jumlahpointakum2" : .Cols(52).AllowMerging = True : .Cols(52).Width = 100 : .Cols(52).Format = "#,###0" : .Cols(52).TextAlign = TextAlignEnum.RightCenter : .Cols(52).Visible = False
            txt = .GetCellRange(0, 53, 2, 53) : txt.Data = "Remark" : .Cols(53).Name = "Remark" : .Cols(53).AllowMerging = True : .Cols(53).Width = 100 : .Cols(53).TextAlign = TextAlignEnum.LeftCenter
        End With

    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Me.Cursor = Cursors.WaitCursor

        TXTHARGANOW.Text = rppoin()
        fg.Clear()
        fg.Row = 0
        fg.Col = 0
        fg.DataSource = Nothing
        Me.fg.Clear(C1.Win.C1FlexGrid.ClearFlags.Content)
        DS.Clear()
        DS.Tables.Clear()

        Call UI.HapusGrid(3, fg)

        If fg.Rows.Count < 4 Then
            If IsNothing(cmbS_Petani.SelectedValue) = False And chkS_Petani.Checked = True Then
                Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "EXEC dbo.spPoinUpdateJumlahPointAkum @IDRelasi = '" & cmbS_Petani.SelectedValue.ToString & "'")
                Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "EXEC dbo.spPoinUpdateJumlahPointAkumExpired @IDRelasi = '" & cmbS_Petani.SelectedValue.ToString & "'")
            End If
            SHOWDATA3()
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Public Sub SHOWDATA3()
        Me.fg.Clear(C1.Win.C1FlexGrid.ClearFlags.Content)
        DS.Clear()
        DS.Tables.Clear()

        HeaderFG()
        connetionString = "server=192.168.12.5; database=RSUPAccounting; user=UKoneksi; password=sm@rt2018;  MultipleActiveResultSets=True; connect timeout=0;Max Pool Size=500000  ;"

        connection = New SqlConnection(connetionString)
        Dim sql, sql2 As String

        If chkS_Petani.Checked = True Then
            sql2 = Modul_RMP.Func.SetCondition(sql, "IDSUBPETANI = '" & cmbS_Petani.SelectedValue.ToString & "'")
        End If

        sql = "SELECT IDSubPetani,SubPetani ,IDSubPetani AS IDSubPetani2 , SubPetani AS  SubPetani2,IDPenerimaUang , PenerimaUang ,Pancang, NONOTA AS nonota,  
                Klasifikasi, bTransDate As TransDate3 , bsum3month As TotalVolKg3 , '' AS Klasifikasi3, TransDate, Jenis, TarraPersen,netto2  VolumeKg, nettoakum  AS TotalVolKg, point AS PointSupplier , 
                jumlahpoint AS JumlahPoint, ISNULL(jumlahpointakum, 0) As jumlahpointakum ,'' AS NOREFF, totalcashback, 
                persenrek , pointrek, persenkualitas, PointKualitas, persenlicin, totalpoint,
                RPTOTALPOINT  As RPTOTALPOINT, RPTOTALPOINTAKUM As RPTOTALPOINTAKUM, ExpiredDatenew As EXPIRED2, 
                QTYTUKAR , POINTTUKAR, RPPOINTTUKAR , QTYPENGAJUANTOKO,  POINTPENGAJUANTOKO, RPPOINTPENGAJUANTOKO ,  QTYAPPROVE,  POINTPENGAJUANSDHAPPROVE,
                RPPOINTPENGAJUANSDHAPPROVE,  QTYCOMPLETE,  POINTPENGAJUANSDHCOMPLETE,
                RPPOINTPENGAJUANSDHCOMPLETE,  QTYTOTAL, ISNULL(POINTTOTAL,0) AS POINTTOTAL, RPPOINTTOTAL,  jumlahpointakum -POINTTOTAL AS  SISAPOINT, (jumlahpointakum -POINTTOTAL ) * '" & Val(TXTHARGANOW.Text) & " ' AS  SISARPPOINT, 
                EXPIREDDATEnew as EXPIRED ,   0 AS SISAPOINTEXP ,0  AS SISARPPOINTEXP , AKUMPOINPERTAHUN  as AKUMPOINPERTAHUN ,jumlahpointakum as jumlahpointakum2, Remark
                FROM RMPAPP..fndataloyaltypetani2023NEW('" & Format(dtcb1.Value, "yyyy-MM-dd") & "'  ,'" & Format(dtcb2.Value, "yyyy-MM-dd") & "') AS A  where 
                KLASIFIKASI IS NOT NULL  " & IIf(sql2 = "", "", " And " & sql2) & "   ORDER BY  IDSUBPETANI ASC ,TRANSID ASC ,cast(TRANSDATE as date) ASC,   URUTPOIN ASC"

        Try
            connection.Open()
            adapter = New SqlDataAdapter(sql, connection)
            adapter.Fill(DS)
            connection.Close()
            fg.DataSource = DS.Tables(0)

            fg.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free

            CELL2()

            ShowTotals()
            For i = 3 To fg.Rows.Count - 1
                If IsDBNull(fg.Item(i, "TransDate")) = False Then

                    If IsDBNull(fg.Item(i, "TransDate")) = False And IsDBNull(fg.Item(i, "EXPIRED")) = False Then
                        If (Now.Date >= fg.Item(i, "EXPIRED")) And IsDBNull(fg.Item(i, "TransDate")) = False And fg.Item(i, "NONOTA") <> "" Then

                            fg.Rows(i).StyleNew.ForeColor = Color.Red
                            fg.Item(i, "SISAPOINTEXP") = Convert.ToDouble(fg.Item(i, "totalpoint"))
                            fg.Item(i, "SISARPPOINTEXP") = Convert.ToDouble(fg.Item(i, "RPTOTALPOINT"))
                            fg.Item(i, "SISAPOINT") = 0
                            fg.Item(i, "SISARPPOINT") = 0

                        Else

                            fg.Rows(i).StyleNew.ForeColor = Color.Black
                            fg.Item(i, "SISAPOINTEXP") = 0
                            fg.Item(i, "SISARPPOINTEXP") = 0

                        End If
                    Else
                    End If

                End If

                ShowTotals2()

                Dim cs2 As CellStyle
                cs2 = fg.Styles.Add("LargeValue2")
                cs2.ForeColor = Color.Red

                If Year(CType(fg.Item(i, "TransDate"), DateTime)) <> Year(Now.Date) Then
                    fg.SetCellStyle(i, "AKUMPOINPERTAHUN", cs2)
                End If

                Dim cs As CellStyle

                cs = fg.Styles.Add("LargeValue")
                cs.ForeColor = Color.Black

                If Year(CType(fg.Item(i, "TransDate"), DateTime)) = Year(Now.Date) Then
                    fg.SetCellStyle(i, "AKUMPOINPERTAHUN", cs)
                End If
            Next i
            ShowTotals2()

            fg.AutoSizeCols()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Public Function GetQTYcashBack(ByVal IDRelasi As String) As Double
        Dim dt As DataTable = New DataTable()
        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "Select sum(qty) As GetQTYcashBack from RMPAPP..vwAndroid_tblPoinTransaksiItemDtl where kodesup = '" & IDRelasi & "'   AND (deleted=0)   ")
        If IsDBNull(dt.Rows(0).Item("GetQTYcashBack")) Then
            GetQTYcashBack = 0
        Else
            GetQTYcashBack = dt.Rows(0).Item("GetQTYcashBack")
        End If

        Return GetQTYcashBack
    End Function

    Public Function GetTotalcashBack(ByVal IDRelasi As String) As Double
        Dim dt As DataTable = New DataTable()
        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select sum(bayar_poin) AS GetTotalcashBack from RMPAPP..vwAndroid_tblPoinTransaksiItemDtl where kodesup = '" & IDRelasi & "'   AND ( deleted=0)   ")
        If IsDBNull(dt.Rows(0).Item("GetTotalcashBack")) Then
            GetTotalcashBack = 0
        Else
            GetTotalcashBack = dt.Rows(0).Item("GetTotalcashBack")
        End If

        Return GetTotalcashBack
    End Function

    Public Function GetrpTotalcashBack(ByVal IDRelasi As String) As Double

        Dim dt As DataTable = New DataTable()
        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " Select sum(bayar_rupiah) As GetrpTotalcashBack from RMPAPP..vwAndroid_tblPoinTransaksiItemDtl   where kodesup= '" & IDRelasi & "' AND (deleted is NULL or deleted=0)   ")
        If IsDBNull(dt.Rows(0).Item("GetrpTotalcashBack")) Then
            GetrpTotalcashBack = 0
        Else
            GetrpTotalcashBack = dt.Rows(0).Item("GetrpTotalcashBack")
        End If

        Return GetrpTotalcashBack

    End Function

    Public Function GetTotalcashBackblmapprove(ByVal IDRelasi As String) As Double

        Dim dt As DataTable = New DataTable()
        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select sum(bayar_poin) AS GetTotalcashBackblmapprove from RMPAPP..vwpengajuanpoindtl where (status_pengajuan =0 or status_pengajuan IS NULL ) AND  kodesup = '" & IDRelasi & "'   AND (deleted is NULL or deleted=0)   ")
        If IsDBNull(dt.Rows(0).Item("GetTotalcashBackblmapprove")) Then
            GetTotalcashBackblmapprove = 0
        Else
            GetTotalcashBackblmapprove = dt.Rows(0).Item("GetTotalcashBackblmapprove")
        End If

        Return GetTotalcashBackblmapprove

    End Function

    Public Function GetrpTotalcashBackblmapprove(ByVal IDRelasi As String) As Double

        Dim dt As DataTable = New DataTable()
        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " Select sum(bayar_rupiah) As GetrpTotalcashBackblmapprove from RMPAPP..vwpengajuanpoindtl  where (status_pengajuan =0 or status_pengajuan IS NULL ) AND kodesup= '" & IDRelasi & "' AND (deleted is NULL or deleted=0)   ")
        If IsDBNull(dt.Rows(0).Item("GetrpTotalcashBackblmapprove")) Then
            GetrpTotalcashBackblmapprove = 0
        Else
            GetrpTotalcashBackblmapprove = dt.Rows(0).Item("GetrpTotalcashBackblmapprove")
        End If
        Return GetrpTotalcashBackblmapprove

    End Function

    Public Function GetTotalcashBackSDHapprove(ByVal IDRelasi As String) As Double

        Dim dt As DataTable = New DataTable()
        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select sum(bayar_poin) AS GetTotalcashBackSDHapprove from RMPAPP..vwpengajuanpoindtl where (status_pengajuan =1) AND  kodesup = '" & IDRelasi & "'   AND (deleted is NULL or deleted=0)   ")
        If IsDBNull(dt.Rows(0).Item("GetTotalcashBackblmapprove")) Then
            GetTotalcashBackSDHapprove = 0
        Else
            GetTotalcashBackSDHapprove = dt.Rows(0).Item("GetTotalcashBackSDHapprove")
        End If

        Return GetTotalcashBackSDHapprove

    End Function

    Public Function GetrpTotalcashBackSDHapprove(ByVal IDRelasi As String) As Double

        Dim dt As DataTable = New DataTable()
        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "Select sum(bayar_rupiah) As GetrpTotalcashBackSDHapprove from RMPAPP..vwpengajuanpoindtl  where (status_pengajuan =1 ) AND kodesup= '" & IDRelasi & "' AND (deleted is NULL or deleted=0)   ")
        If IsDBNull(dt.Rows(0).Item("GetrpTotalcashBackblmapprove")) Then
            GetrpTotalcashBackSDHapprove = 0
        Else
            GetrpTotalcashBackSDHapprove = dt.Rows(0).Item("GetrpTotalcashBackSDHapprove")
        End If

        Return GetrpTotalcashBackSDHapprove

    End Function

    Public Function poinall(ByVal IDRelasi As String) As Double

        Dim dt As DataTable = New DataTable()
        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " select sum(totalpoint)  as poinall from RMPAPP..TblTrnKelapa_Poin_2023  where IDSUBPETANI ='" & IDRelasi & "' ")
        If IsDBNull(dt.Rows(0).Item("poinall")) Then
            poinall = 0
        Else
            poinall = dt.Rows(0).Item("poinall")
        End If

        Return poinall

    End Function

    Public Function poinhangus(ByVal IDRelasi As String) As Double

        Dim dt As DataTable = New DataTable()
        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " Select sum(totalpoint) As poinhangus from  RMPAPP..TblTrnKelapa_Poin_2023 where IDSUBPETANI = '" & IDRelasi & "'  AND HANGUS=1 AND EXPIREDDATEnew>GETDATE()   ")
        If IsDBNull(dt.Rows(0).Item("poinhangus")) Then
            poinhangus = 0
        Else
            poinhangus = dt.Rows(0).Item("poinhangus")
        End If

        Return poinhangus

    End Function

    Public Function poinexpired(ByVal IDRelasi As String) As Double

        Dim dt As DataTable = New DataTable()
        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select sum(totalpoint)  as poinexpired from RMPAPP..TblTrnKelapa_Poin_2023 where IDSUBPETANI ='" & IDRelasi & "'  AND CAST(EXPIREDDATEnew AS DATE)<=CAST(GETDATE() AS DATE)  AND (HANGUS=0 OR HANGUS IS NULL)")
        If IsDBNull(dt.Rows(0).Item("poinexpired")) Then
            poinexpired = 0
        Else
            poinexpired = dt.Rows(0).Item("poinexpired")
        End If

        Return poinexpired

    End Function

    Public Function rppoin() As Double

        Dim dt As DataTable = New DataTable()
        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select top(1) harga  as  rppoin from RMPAPP..tbl_Mst_HargaPoint  where  cast(Tanggal as date)<=cast(getdate() as date) order by Tanggal desc")
        If IsDBNull(dt.Rows(0).Item("rppoin")) Then
            rppoin = 0
        Else
            rppoin = dt.Rows(0).Item("rppoin")
        End If
        Return rppoin

    End Function

    Public Function GetTotalcashBack() As Double

        Dim dt As DataTable = New DataTable()
        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select sum(bayar_poin) AS GetTotalcashBack from RMPAPP..vwAndroid_tblPoinTransaksiItemDtl where (deleted is NULL or deleted=0)  ")
        If IsDBNull(dt.Rows(0).Item("GetTotalcashBack")) Then
            GetTotalcashBack = 0
        Else
            GetTotalcashBack = dt.Rows(0).Item("GetTotalcashBack")
        End If

        Return GetTotalcashBack

    End Function

    Public Function GetrpTotalcashBack() As Double

        Dim dt As DataTable = New DataTable()
        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, " Select sum(bayar_rupiah) As GetrpTotalcashBack from RMPAPP..vwAndroid_tblPoinTransaksiItemDtl   where (deleted is NULL or deleted=0)   ")
        If IsDBNull(dt.Rows(0).Item("GetrpTotalcashBack")) Then
            GetrpTotalcashBack = 0
        Else
            GetrpTotalcashBack = dt.Rows(0).Item("GetrpTotalcashBack")
        End If

        Return GetrpTotalcashBack

    End Function

    Public Sub ShowData()

        Cursor = Cursors.WaitCursor
        Application.DoEvents()

        Try
            Dim dt As DataTable = New DataTable()
            Dim i As Integer = 3
            Dim sql As String

            If chkS_Petani.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "IDSUBPETANI = '" & cmbS_Petani.SelectedValue.ToString & "'")

            End If

            sql = " SELECT * FROM fndataloyaltypetani_('" & Format(dtcb1.Value, "yyyy-MM-dd") & "') where TRANSID>0  " & IIf(sql = "", "", " AND " & sql) & "   ORDER BY IDSUBPETANI ,TRANSDATE "

            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

            If dt.Rows.Count > 0 Then
                With fg
                    Call UI.HapusGrid(3, fg)
                    For Each dr As DataRow In dt.Rows
                        .AddItem(i - 1)

                        .Item(i, 0) = dr!Klasifikasi
                        .Item(i, "KodeSupUM") = dr!KodeSupUM
                        .Item(i, "NamaSupUM") = dr!NamaSupUM
                        .Item(i, "IDSubPetani") = dr!IDSubPetani
                        .Item(i, "SubPetani") = dr!SubPetani
                        .Item(i, "IDPenerimaUang") = dr!IDPenerimaUang
                        .Item(i, "PenerimaUang") = dr!PenerimaUang
                        .Item(i, "Pancang") = dr!Pancang
                        .Item(i, "TransDate") = dr!TransDate
                        .Item(i, "Jenis") = dr!Jenis
                        .Item(i, "NoReff") = dr!NoReff
                        .Item(i, "TransDate") = dr!TransDate
                        .Item(i, "TarraPersen") = dr!TarraPersen
                        .Item(i, 12) = dr!netto2
                        .Item(i, "QCTarra") = dr!QCTarra
                        .Item(i, "totalcashback") = dr!totalcashback

                        If .Item(i, "totalnettoakhir") < 15000 Then
                            .Item(i, "PointSupplier") = 1

                            If .Item(i, "IDSubPetani") = .Item(i, "IDPenerimaUang") Then
                                .Item(i, "PersenRek") = 10
                            Else
                                .Item(i, "PersenRek") = 0
                            End If

                            If .Item(i, "TarraPersen") <= .Item(i, "QCTarra") Then
                                .Item(i, "PersenKualitas") = 10
                            Else
                                .Item(i, "PersenKualitas") = 0
                            End If
                            ''''''''''''''''''''''''''petani besar'''''''''''''''''''''''''''''''''''''''''''''''

                        ElseIf .Item(i, "totalnettoakhir") >= 15000 And .Item(i, "totalnettoakhir") <= 90000 Then
                            .Item(i, "PointSupplier") = 8
                            .Item(i, "PersenRek") = 5

                            If .Item(i, "IDSubPetani") = .Item(i, "IDPenerimaUang") Then
                                .Item(i, "PersenRek") = 5
                            Else
                                .Item(i, "PersenRek") = 0
                            End If

                            If .Item(i, "TarraPersen") <= .Item(i, "QCTarra") Then
                                .Item(i, "PersenKualitas") = 10
                            Else
                                .Item(i, "PersenKualitas") = 0
                            End If
                            ''''''''''''''''''''''''''''''toko''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        ElseIf .Item(i, "totalnettoakhir") > 90000 Then
                            .Item(i, "PointSupplier") = 70
                            .Item(i, "PersenRek") = 0

                            If .Item(i, "Jenis") = "Licin" Then
                                .Item(i, 26) = 10
                            Else

                                .Item(i, 26) = 0
                            End If

                            If .Item(i, "TarraPersen") <= .Item(i, "QCTarra") Then
                                .Item(i, "PersenKualitas") = 10
                            Else
                                .Item(i, "PersenKualitas") = 0
                            End If

                        End If
                        Dim netto, pointsupplier, persenrek, persenkualitas, persennlicin, jumlahpoint, pointrek, pointkualitas, pointlicin As Double
                        netto = .Item(i, 12)
                        pointsupplier = .Item(i, "PointSupplier")
                        persenrek = .Item(i, "PersenRek")
                        persenkualitas = .Item(i, "PersenKualitas")
                        persennlicin = .Item(i, 25)
                        .Item(i, "JumlahPoint") = Math.Round(netto / pointsupplier, 0)
                        jumlahpoint = .Item(i, "JumlahPoint")
                        .Item(i, "PointRek") = Math.Round((jumlahpoint * persenrek) / 100, 0)
                        pointrek = .Item(i, "PointRek")
                        .Item(i, "PointKualitas") = Math.Round((jumlahpoint * persenkualitas) / 100, 0)
                        pointkualitas = .Item(i, "PointKualitas")
                        .Item(i, "PointLicin") = Math.Round((jumlahpoint * persennlicin) / 100, 0)
                        pointlicin = .Item(i, "PointLicin")

                        .Item(i, "totalpoint") = jumlahpoint + pointrek + pointkualitas + pointlicin

                        .Item(i, 29) = .Item(i, "TotalPoint")

                        i = i + 1
                    Next
                End With

                Call ShowTotals()
                fg.AutoSizeCols()

                Call ShowTotals()
            Else
                Call UI.HapusGrid(3, fg)
                MsgBox("No Data", MsgBoxStyle.Exclamation, AT)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Public Sub ShowData2()
        Cursor = Cursors.WaitCursor
        Application.DoEvents()

        Try
            Dim dt As DataTable = New DataTable()
            Dim i As Integer = 3
            Dim sql As String

            If chkS_Petani.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "IDSUBPETANI = '" & cmbS_Petani.SelectedValue.ToString & "'")
            End If

            sql = " SELECT * FROM fndataloyaltypetani2022New('" & Format(dtcb1.Value, "yyyy-MM-dd") & "','" & Format(dtcb2.Value, "yyyy-MM-dd") & "') where TRANSID>0  " & IIf(sql = "", "", " AND " & sql) & "   ORDER BY  IDSUBPETANI,kodesupum ,TRANSDATE "

            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

            If dt.Rows.Count > 0 Then
                With fg
                    Call UI.HapusGrid(3, fg)
                    For Each dr As DataRow In dt.Rows
                        .AddItem(i - 1)

                        .Item(i, "Klasifikasi") = dr!Klasifikasi

                        .Item(i, "KodeSupUM") = dr!KodeSupUM
                        .Item(i, "NamaSupUM") = dr!NamaSupUM

                        .Item(i, "IDSubPetani") = dr!IDSubPetani
                        .Item(i, "SubPetani") = dr!SubPetani

                        .Item(i, "IDPenerimaUang") = dr!IDPenerimaUang
                        .Item(i, "PenerimaUang") = dr!PenerimaUang                       '
                        .Item(i, "Pancang") = dr!Pancang

                        .Item(i, "TransDate") = dr!TransDate
                        .Item(i, "Jenis") = dr!Jenis
                        .Item(i, "NoReff") = dr!NoReff
                        .Item(i, "TransDate") = dr!TransDate
                        .Item(i, "TarraPersen") = dr!TarraPersen
                        .Item(i, "VolumeKg") = dr!nettoakhir
                        .Item(i, "QCTarra") = dr!QCTarra
                        .Item(i, "RPTOTALPOINT") = dr!totalcashback

                        If dr!IDSubPetani = .Item(i - 1, "IDSubPetani") Then
                            .Item(i, "Klasifikasi3") = ""
                            .Item(i, "TotalVolKg3") = ""
                            .Item(i, "TransDate3") = ""
                        Else
                            .Item(i, "Klasifikasi3") = dr!bKlasifikasi
                            .Item(i, "TotalVolKg3") = IIf(IsDBNull(dr!bsum3month), 0, dr!bsum3month)
                            .Item(i, "TransDate3") = dr!bTransDate
                        End If

                        If dr!IDSubPetani = .Item(i - 1, "IDSubPetani") And dr!NoNota = .Item(i - 1, "NoNota") Then
                            .Item(i, "TotalVolKg") = 0
                        Else
                            .Item(i, "TotalVolKg") = IIf(IsDBNull(dr!netto2), 0, dr!netto2)
                        End If

                        .Item(i, "PointSupplier") = IIf(IsDBNull(dr!point), 0, dr!point)
                        .Item(i, "PersenRek") = IIf(IsDBNull(dr!persenrek), 0, dr!persenrek)
                        .Item(i, "PersenKualitas") = IIf(IsDBNull(dr!persenkualitas), 0, dr!persenkualitas)
                        .Item(i, 26) = IIf(IsDBNull(dr!persenlicin), 0, dr!persenlicin)
                        .Item(i, "JumlahPoint") = IIf(IsDBNull(dr!jumlahpoint), 0, dr!jumlahpoint)
                        .Item(i, "PointRek") = IIf(IsDBNull(dr!pointrek), 0, dr!pointrek)
                        .Item(i, "PointKualitas") = IIf(IsDBNull(dr!PointKualitas), 0, dr!PointKualitas)
                        .Item(i, "PointLicin") = IIf(IsDBNull(dr!PointLicin), 0, dr!PointLicin)

                        .Item(i, 29) = IIf(IsDBNull(dr!totalpoint), 0, dr!totalpoint)

                        i = i + 1
                    Next
                End With

                Call ShowTotals()

                fg.AutoSizeCols()

                Call ShowTotals()

                If fg.Rows.Count > 6 Then
                    For i = 4 To fg.Rows.Count - 1

                        If fg.Item(i, "PANCANG") = "" Then
                            fg.Item(i, "POINTCASHBACK") = GetTotalcashBack(fg.Item(i - 1, "IDSubPetani"))
                            fg.Item(i, "RPPOINTCASHBACK") = GetrpTotalcashBack(fg.Item(i - 1, "IDSubPetani"))

                        End If
                        fg.Item(fg.Rows.Count - 1, "POINTCASHBACK") = GetTotalcashBack(fg.Item(i - 2, "IDSubPetani"))
                        fg.Item(fg.Rows.Count - 1, "RPPOINTCASHBACK") = GetrpTotalcashBack(fg.Item(i - 2, "IDSubPetani"))

                    Next i
                End If

            Else
                Call UI.HapusGrid(3, fg)
                MsgBox("No Data", MsgBoxStyle.Exclamation, AT)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Public Sub ShowDatanotloyal()
        Cursor = Cursors.WaitCursor
        Application.DoEvents()

        Try
            Dim dt As DataTable = New DataTable()
            Dim i As Integer = 3
            Dim sql As String

            If chkS_Petani.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "IDSUBPETANI = '" & cmbS_Petani.SelectedValue.ToString & "'")
            End If

            sql = " SELECT * FROM fndatapetani2notloyal('" & Format(dtcb1.Value, "yyyy-MM-dd") & "','" & Format(dtcb2.Value, "yyyy-MM-dd") & "') where TRANSID>0  " & IIf(sql = "", "", " AND " & sql) & "   ORDER BY  IDSUBPETANI,kodesupum ,TRANSDATE "

            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, sql)

            If dt.Rows.Count > 0 Then
                With fg
                    Call UI.HapusGrid(3, fg)
                    For Each dr As DataRow In dt.Rows
                        .AddItem(i - 1)

                        .Item(i, "Klasifikasi") = dr!Klasifikasi

                        .Item(i, "KodeSupUM") = dr!KodeSupUM
                        .Item(i, "NamaSupUM") = dr!NamaSupUM

                        .Item(i, "IDSubPetani") = dr!IDSubPetani
                        .Item(i, "SubPetani") = dr!SubPetani

                        .Item(i, "IDPenerimaUang") = dr!IDPenerimaUang
                        .Item(i, "PenerimaUang") = dr!PenerimaUang                       '
                        .Item(i, "Pancang") = dr!Pancang
                        .Item(i, "NoNota") = dr!NoNota
                        .Item(i, "TransDate") = dr!TransDate
                        .Item(i, "Jenis") = dr!Jenis
                        .Item(i, "NoReff") = dr!NoReff
                        .Item(i, "TransDate") = dr!TransDate
                        .Item(i, "TarraPersen") = dr!TarraPersen
                        .Item(i, "VolumeKg") = dr!netto2
                        .Item(i, "QCTarra") = dr!QCTarra

                        i = i + 1
                    Next
                End With

                Call ShowTotals()
                fg.AutoSizeCols()

            Else
                Call UI.HapusGrid(3, fg)
                MsgBox("No Data", MsgBoxStyle.Exclamation, AT)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Public Sub ShowTotals()
        With fg
            .Tree.Column = 0
            .Tree.Style = TreeStyleFlags.CompleteLeaf
            .Subtotal(AggregateEnum.Clear)

            .Subtotal(AggregateEnum.Sum, -1, -1, 15, "Grand Total")
            .Subtotal(AggregateEnum.Sum, 2, 2, 15, "Total {0}")

            .Subtotal(AggregateEnum.Sum, -1, -1, 18, "Grand Total")
            .Subtotal(AggregateEnum.Sum, 2, 2, 18, "Total {0}")

            .Subtotal(AggregateEnum.Sum, -1, -1, 23, "Grand Total")
            .Subtotal(AggregateEnum.Sum, 2, 2, 23, "Total {0}")

            .Subtotal(AggregateEnum.Sum, -1, -1, 25, "Grand Total")
            .Subtotal(AggregateEnum.Sum, 2, 2, 25, "Total {0}")

            .Subtotal(AggregateEnum.Sum, -1, -1, 28, "Grand Total")
            .Subtotal(AggregateEnum.Sum, 2, 2, 28, "Total {0}")

            For I = 31 To 45
                .Subtotal(AggregateEnum.Sum, -1, -1, I, "Grand Total")
                .Subtotal(AggregateEnum.Sum, 2, 2, I, "Total {0}")
            Next I

        End With
        Call ColorSubTotal()

    End Sub

    Public Sub ShowTotals2()
        With fg
            .Tree.Column = 0
            .Tree.Style = TreeStyleFlags.CompleteLeaf

            .Subtotal(AggregateEnum.Sum, -1, -1, 49, "Grand Total")
            .Subtotal(AggregateEnum.Sum, 2, 2, 49, "Total {0}")

            .Subtotal(AggregateEnum.Sum, -1, -1, 50, "Grand Total")
            .Subtotal(AggregateEnum.Sum, 2, 2, 50, "Total {0}")

        End With
        Call ColorSubTotal()

    End Sub

    Private Sub ColorSubTotal()
        Dim cs As C1.Win.C1FlexGrid.CellStyle
        With fg
            cs = .Styles(C1.Win.C1FlexGrid.CellStyleEnum.GrandTotal)
            cs.BackColor = Color.SteelBlue
            cs = .Styles(C1.Win.C1FlexGrid.CellStyleEnum.Subtotal0)
            cs.BackColor = Color.AliceBlue

            cs.ForeColor = Color.White
            cs.Font = New Font(Font, FontStyle.Bold)
        End With
    End Sub

    Private Sub schKg()
        With schfg
            .SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
            .SearchDelay = 2
            .Watermark = "Cari Disini"
            .SetC1FlexGridSearchPanel(fg, schfg)
        End With
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Dim filename As String
        Me.SaveFileDialog.ShowDialog()
        filename = SaveFileDialog.FileName
        Me.fg.SaveExcel(filename & ".xls", "Sheet1", FileFlags.IncludeFixedCells)
        MsgBox("Convert Success !", vbInformation, AT)
    End Sub

    Private Sub cmbS_Petani_Validated(sender As Object, e As EventArgs) Handles cmbS_Petani.Validated
        chkS_Petani.Checked = IIf(cmbS_Petani.Text = "", False, True)
    End Sub

    Private Sub cmbS_Petani_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbS_Petani.Validating
        If cmbS_Petani.Text = "" Then
            Exit Sub
        End If

        If IsNothing(cmbS_Petani.SelectedValue) Then
            MsgBox("Pilihan tidak ada !", vbExclamation, AT)
            cmbS_Petani.Text = ""
            cmbS_Petani.Focus()
        End If
    End Sub

    Private Sub cmbS_Petani_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbS_Petani.KeyUp
        UI.AutoCompleteCombo_KeyUp(cmbS_Petani, e)
    End Sub

    Private Sub fg_AfterSelChange(sender As Object, e As RangeEventArgs) Handles fg.AfterSelChange
        On Error Resume Next
        Dim sum As Double
        Dim R, c As Integer
        With fg
            If .Row = 0 Then Exit Sub
            If .RowSel > .Row Then
                For R = .Row To .RowSel
                    If (R > 0) And (R <= (.Rows.Count - 1)) Then
                        For c = .Col To .ColSel
                            Select Case c
                                Case 15, 18, 23, 25, 27, 28, 29, 30, 31, 32, 49, 50
                                    If Trim(.Item(R, c) <> 0) Then
                                        sum = sum + CDbl(.Item(R, c))
                                    End If
                            End Select
                        Next
                    End If
                Next
            End If

        End With
        txtSum.Text = FormatNumber(sum, 0)
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim filename As String

        ' Show the Save File Dialog to get the desired file path
        If Me.SaveFileDialog.ShowDialog() = DialogResult.OK Then
            filename = Me.SaveFileDialog.FileName

            Using workbook As New XLWorkbook()
                Dim worksheet As IXLWorksheet = workbook.Worksheets.Add("SheetPoin")

                ' Loop through the rows and columns of the C1FlexGrid and transfer data to Excel
                For row As Integer = 0 To fg.Rows.Count - 1
                    For col As Integer = 0 To fg.Cols.Count - 1
                        worksheet.Cell(row + 1, col + 1).Value = fg.GetDataDisplay(row, col)
                    Next
                Next

                ' Generate the full file path including the .xlsx extension
                Dim filePath As String = filename & ".xlsx"

                ' Save the Excel workbook to the specified file path
                workbook.SaveAs(filePath)

                ' Open the saved Excel file using the default application
                System.Diagnostics.Process.Start(filePath)
            End Using
        End If
    End Sub
End Class