<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMonPembelianBarangPancangCash
    'Inherits System.Windows.Forms.Form
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMonPembelianBarangPancangCash))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnPrint2 = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.BtnExcel = New System.Windows.Forms.Button()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.btnKalkulasiData = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.FG = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.ChkAll = New System.Windows.Forms.CheckBox()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.rdTrip2 = New System.Windows.Forms.RadioButton()
        Me.rdTrip1 = New System.Windows.Forms.RadioButton()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.chkTglTerima = New System.Windows.Forms.RadioButton()
        Me.CmbKategori = New System.Windows.Forms.ComboBox()
        Me.rdTgl = New System.Windows.Forms.RadioButton()
        Me.chkTglNota = New System.Windows.Forms.RadioButton()
        Me.CmbPancang = New System.Windows.Forms.ComboBox()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.RdPancang = New System.Windows.Forms.RadioButton()
        Me.RdPurchaser = New System.Windows.Forms.RadioButton()
        Me.rdPulsa = New System.Windows.Forms.RadioButton()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.rdBelumPrint = New System.Windows.Forms.RadioButton()
        Me.rdSudahPrint = New System.Windows.Forms.RadioButton()
        Me.rdall = New System.Windows.Forms.RadioButton()
        Me.dtpTerima2 = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.dtpCreate2 = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Dtp2 = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpTerima = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpCreate1 = New System.Windows.Forms.DateTimePicker()
        Me.Dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtItem = New System.Windows.Forms.TextBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.FG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Panel8)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(885, 40)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(48, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(432, 28)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Monitoring Pembelian Barang Pancang Cash"
        '
        'Panel8
        '
        Me.Panel8.BackgroundImage = CType(resources.GetObject("Panel8.BackgroundImage"), System.Drawing.Image)
        Me.Panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel8.Location = New System.Drawing.Point(12, 2)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(35, 35)
        Me.Panel8.TabIndex = 9
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnPrint2)
        Me.Panel2.Controls.Add(Me.btnRefresh)
        Me.Panel2.Controls.Add(Me.BtnExit)
        Me.Panel2.Controls.Add(Me.BtnExcel)
        Me.Panel2.Controls.Add(Me.BtnPrint)
        Me.Panel2.Controls.Add(Me.btnKalkulasiData)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 361)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(885, 40)
        Me.Panel2.TabIndex = 0
        '
        'btnPrint2
        '
        Me.btnPrint2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint2.BackColor = System.Drawing.Color.White
        Me.btnPrint2.Image = CType(resources.GetObject("btnPrint2.Image"), System.Drawing.Image)
        Me.btnPrint2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrint2.Location = New System.Drawing.Point(725, 5)
        Me.btnPrint2.Name = "btnPrint2"
        Me.btnPrint2.Size = New System.Drawing.Size(75, 30)
        Me.btnPrint2.TabIndex = 1027
        Me.btnPrint2.Text = "Print 2"
        Me.btnPrint2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrint2.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.White
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRefresh.Location = New System.Drawing.Point(500, 5)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnRefresh.Size = New System.Drawing.Size(75, 30)
        Me.btnRefresh.TabIndex = 1026
        Me.btnRefresh.Text = "Cari"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'BtnExit
        '
        Me.BtnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExit.BackColor = System.Drawing.Color.White
        Me.BtnExit.Image = CType(resources.GetObject("BtnExit.Image"), System.Drawing.Image)
        Me.BtnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnExit.Location = New System.Drawing.Point(800, 5)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.BtnExit.Size = New System.Drawing.Size(75, 30)
        Me.BtnExit.TabIndex = 1025
        Me.BtnExit.Text = "Exit"
        Me.BtnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnExit.UseVisualStyleBackColor = False
        '
        'BtnExcel
        '
        Me.BtnExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExcel.BackColor = System.Drawing.Color.White
        Me.BtnExcel.Image = CType(resources.GetObject("BtnExcel.Image"), System.Drawing.Image)
        Me.BtnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnExcel.Location = New System.Drawing.Point(575, 5)
        Me.BtnExcel.Name = "BtnExcel"
        Me.BtnExcel.Padding = New System.Windows.Forms.Padding(5, 0, 3, 0)
        Me.BtnExcel.Size = New System.Drawing.Size(75, 30)
        Me.BtnExcel.TabIndex = 1024
        Me.BtnExcel.Text = "Excel"
        Me.BtnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnExcel.UseVisualStyleBackColor = False
        '
        'BtnPrint
        '
        Me.BtnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPrint.BackColor = System.Drawing.Color.White
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPrint.Location = New System.Drawing.Point(650, 5)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.BtnPrint.Size = New System.Drawing.Size(75, 30)
        Me.BtnPrint.TabIndex = 1023
        Me.BtnPrint.Text = "Print"
        Me.BtnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'btnKalkulasiData
        '
        Me.btnKalkulasiData.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnKalkulasiData.BackColor = System.Drawing.Color.White
        Me.btnKalkulasiData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKalkulasiData.Location = New System.Drawing.Point(378, 5)
        Me.btnKalkulasiData.Name = "btnKalkulasiData"
        Me.btnKalkulasiData.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnKalkulasiData.Size = New System.Drawing.Size(122, 30)
        Me.btnKalkulasiData.TabIndex = 1021
        Me.btnKalkulasiData.Text = "Kalkulasi Data"
        Me.btnKalkulasiData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKalkulasiData.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 40)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(885, 321)
        Me.Panel3.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Panel7)
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 110)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(885, 211)
        Me.Panel5.TabIndex = 0
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.White
        Me.Panel7.Controls.Add(Me.FG)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(0, 36)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Padding = New System.Windows.Forms.Padding(10, 0, 10, 10)
        Me.Panel7.Size = New System.Drawing.Size(885, 175)
        Me.Panel7.TabIndex = 1037
        '
        'FG
        '
        Me.FG.ColumnInfo = "10,1,0,0,0,-1,Columns:1{Style:""DataType:System.Boolean;TextAlign:LeftCenter;Image" &
    "Align:CenterCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.FG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FG.Location = New System.Drawing.Point(10, 0)
        Me.FG.Name = "FG"
        Me.FG.Size = New System.Drawing.Size(865, 165)
        Me.FG.TabIndex = 1041
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.White
        Me.Panel6.Controls.Add(Me.Panel9)
        Me.Panel6.Controls.Add(Me.ChkAll)
        Me.Panel6.Controls.Add(Me.Panel11)
        Me.Panel6.Controls.Add(Me.Label13)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(885, 36)
        Me.Panel6.TabIndex = 1037
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.Black
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(885, 1)
        Me.Panel9.TabIndex = 905707
        '
        'ChkAll
        '
        Me.ChkAll.AutoSize = True
        Me.ChkAll.Location = New System.Drawing.Point(178, 10)
        Me.ChkAll.Name = "ChkAll"
        Me.ChkAll.Size = New System.Drawing.Size(68, 17)
        Me.ChkAll.TabIndex = 1037
        Me.ChkAll.Text = "CheckAll"
        Me.ChkAll.UseVisualStyleBackColor = True
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.rdTrip2)
        Me.Panel11.Controls.Add(Me.rdTrip1)
        Me.Panel11.Location = New System.Drawing.Point(41, 6)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(119, 24)
        Me.Panel11.TabIndex = 1040
        '
        'rdTrip2
        '
        Me.rdTrip2.AutoSize = True
        Me.rdTrip2.Location = New System.Drawing.Point(62, 4)
        Me.rdTrip2.Name = "rdTrip2"
        Me.rdTrip2.Size = New System.Drawing.Size(52, 17)
        Me.rdTrip2.TabIndex = 0
        Me.rdTrip2.Text = "Trip 2"
        Me.rdTrip2.UseVisualStyleBackColor = True
        '
        'rdTrip1
        '
        Me.rdTrip1.AutoSize = True
        Me.rdTrip1.Checked = True
        Me.rdTrip1.Location = New System.Drawing.Point(4, 4)
        Me.rdTrip1.Name = "rdTrip1"
        Me.rdTrip1.Size = New System.Drawing.Size(52, 17)
        Me.rdTrip1.TabIndex = 0
        Me.rdTrip1.TabStop = True
        Me.rdTrip1.Text = "Trip 1"
        Me.rdTrip1.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.Label13.Location = New System.Drawing.Point(9, 12)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(26, 13)
        Me.Label13.TabIndex = 1039
        Me.Label13.Text = "Trip"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.chkTglTerima)
        Me.Panel4.Controls.Add(Me.CmbKategori)
        Me.Panel4.Controls.Add(Me.rdTgl)
        Me.Panel4.Controls.Add(Me.chkTglNota)
        Me.Panel4.Controls.Add(Me.CmbPancang)
        Me.Panel4.Controls.Add(Me.Panel13)
        Me.Panel4.Controls.Add(Me.Panel10)
        Me.Panel4.Controls.Add(Me.Label15)
        Me.Panel4.Controls.Add(Me.Panel12)
        Me.Panel4.Controls.Add(Me.dtpTerima2)
        Me.Panel4.Controls.Add(Me.Label16)
        Me.Panel4.Controls.Add(Me.dtpCreate2)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.Dtp2)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.dtpTerima)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.dtpCreate1)
        Me.Panel4.Controls.Add(Me.Dtp1)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.TxtItem)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(885, 110)
        Me.Panel4.TabIndex = 0
        '
        'chkTglTerima
        '
        Me.chkTglTerima.AutoSize = True
        Me.chkTglTerima.Location = New System.Drawing.Point(12, 80)
        Me.chkTglTerima.Name = "chkTglTerima"
        Me.chkTglTerima.Size = New System.Drawing.Size(99, 17)
        Me.chkTglTerima.TabIndex = 987
        Me.chkTglTerima.Text = "Tanggal Terima"
        Me.chkTglTerima.UseVisualStyleBackColor = True
        '
        'CmbKategori
        '
        Me.CmbKategori.FormattingEnabled = True
        Me.CmbKategori.Location = New System.Drawing.Point(476, 78)
        Me.CmbKategori.Name = "CmbKategori"
        Me.CmbKategori.Size = New System.Drawing.Size(246, 21)
        Me.CmbKategori.TabIndex = 905709
        '
        'rdTgl
        '
        Me.rdTgl.AutoSize = True
        Me.rdTgl.Checked = True
        Me.rdTgl.Location = New System.Drawing.Point(12, 35)
        Me.rdTgl.Name = "rdTgl"
        Me.rdTgl.Size = New System.Drawing.Size(67, 17)
        Me.rdTgl.TabIndex = 987
        Me.rdTgl.TabStop = True
        Me.rdTgl.Text = "Tanggal "
        Me.rdTgl.UseVisualStyleBackColor = True
        '
        'chkTglNota
        '
        Me.chkTglNota.AutoSize = True
        Me.chkTglNota.Location = New System.Drawing.Point(12, 58)
        Me.chkTglNota.Name = "chkTglNota"
        Me.chkTglNota.Size = New System.Drawing.Size(90, 17)
        Me.chkTglNota.TabIndex = 987
        Me.chkTglNota.Text = "Tanggal Nota"
        Me.chkTglNota.UseVisualStyleBackColor = True
        '
        'CmbPancang
        '
        Me.CmbPancang.FormattingEnabled = True
        Me.CmbPancang.Location = New System.Drawing.Point(476, 33)
        Me.CmbPancang.Name = "CmbPancang"
        Me.CmbPancang.Size = New System.Drawing.Size(246, 21)
        Me.CmbPancang.TabIndex = 905709
        '
        'Panel13
        '
        Me.Panel13.Controls.Add(Me.RdPancang)
        Me.Panel13.Controls.Add(Me.RdPurchaser)
        Me.Panel13.Controls.Add(Me.rdPulsa)
        Me.Panel13.Location = New System.Drawing.Point(476, 8)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(311, 24)
        Me.Panel13.TabIndex = 905708
        '
        'RdPancang
        '
        Me.RdPancang.AutoSize = True
        Me.RdPancang.Checked = True
        Me.RdPancang.Location = New System.Drawing.Point(3, 3)
        Me.RdPancang.Name = "RdPancang"
        Me.RdPancang.Size = New System.Drawing.Size(68, 17)
        Me.RdPancang.TabIndex = 1022
        Me.RdPancang.TabStop = True
        Me.RdPancang.Text = "Pancang"
        Me.RdPancang.UseVisualStyleBackColor = True
        '
        'RdPurchaser
        '
        Me.RdPurchaser.AutoSize = True
        Me.RdPurchaser.Location = New System.Drawing.Point(77, 3)
        Me.RdPurchaser.Name = "RdPurchaser"
        Me.RdPurchaser.Size = New System.Drawing.Size(73, 17)
        Me.RdPurchaser.TabIndex = 1023
        Me.RdPurchaser.Text = "Purchaser"
        Me.RdPurchaser.UseVisualStyleBackColor = True
        '
        'rdPulsa
        '
        Me.rdPulsa.AutoSize = True
        Me.rdPulsa.Location = New System.Drawing.Point(156, 3)
        Me.rdPulsa.Name = "rdPulsa"
        Me.rdPulsa.Size = New System.Drawing.Size(123, 17)
        Me.rdPulsa.TabIndex = 1021
        Me.rdPulsa.Text = "Pulsa / Token Listrik"
        Me.rdPulsa.UseVisualStyleBackColor = True
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.Black
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel10.Location = New System.Drawing.Point(0, 0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(885, 1)
        Me.Panel10.TabIndex = 905707
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.Label15.Location = New System.Drawing.Point(12, 14)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(61, 13)
        Me.Label15.TabIndex = 1011
        Me.Label15.Text = "Status Print"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.rdBelumPrint)
        Me.Panel12.Controls.Add(Me.rdSudahPrint)
        Me.Panel12.Controls.Add(Me.rdall)
        Me.Panel12.Location = New System.Drawing.Point(113, 8)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(280, 24)
        Me.Panel12.TabIndex = 1030
        '
        'rdBelumPrint
        '
        Me.rdBelumPrint.AutoSize = True
        Me.rdBelumPrint.Checked = True
        Me.rdBelumPrint.Location = New System.Drawing.Point(4, 4)
        Me.rdBelumPrint.Name = "rdBelumPrint"
        Me.rdBelumPrint.Size = New System.Drawing.Size(78, 17)
        Me.rdBelumPrint.TabIndex = 0
        Me.rdBelumPrint.TabStop = True
        Me.rdBelumPrint.Text = "Belum Print"
        Me.rdBelumPrint.UseVisualStyleBackColor = True
        '
        'rdSudahPrint
        '
        Me.rdSudahPrint.AutoSize = True
        Me.rdSudahPrint.Location = New System.Drawing.Point(88, 4)
        Me.rdSudahPrint.Name = "rdSudahPrint"
        Me.rdSudahPrint.Size = New System.Drawing.Size(80, 17)
        Me.rdSudahPrint.TabIndex = 0
        Me.rdSudahPrint.Text = "Sudah Print"
        Me.rdSudahPrint.UseVisualStyleBackColor = True
        '
        'rdall
        '
        Me.rdall.AutoSize = True
        Me.rdall.Location = New System.Drawing.Point(174, 4)
        Me.rdall.Name = "rdall"
        Me.rdall.Size = New System.Drawing.Size(36, 17)
        Me.rdall.TabIndex = 0
        Me.rdall.Text = "All"
        Me.rdall.UseVisualStyleBackColor = True
        '
        'dtpTerima2
        '
        Me.dtpTerima2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTerima2.Location = New System.Drawing.Point(258, 78)
        Me.dtpTerima2.Name = "dtpTerima2"
        Me.dtpTerima2.Size = New System.Drawing.Size(112, 20)
        Me.dtpTerima2.TabIndex = 1027
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.Label16.Location = New System.Drawing.Point(235, 82)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(19, 13)
        Me.Label16.TabIndex = 1003
        Me.Label16.Text = "To"
        '
        'dtpCreate2
        '
        Me.dtpCreate2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCreate2.Location = New System.Drawing.Point(258, 33)
        Me.dtpCreate2.Name = "dtpCreate2"
        Me.dtpCreate2.Size = New System.Drawing.Size(112, 20)
        Me.dtpCreate2.TabIndex = 1026
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.Label6.Location = New System.Drawing.Point(235, 37)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(19, 13)
        Me.Label6.TabIndex = 1006
        Me.Label6.Text = "To"
        '
        'Dtp2
        '
        Me.Dtp2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp2.Location = New System.Drawing.Point(258, 56)
        Me.Dtp2.Name = "Dtp2"
        Me.Dtp2.Size = New System.Drawing.Size(112, 20)
        Me.Dtp2.TabIndex = 1025
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.Label9.Location = New System.Drawing.Point(235, 60)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(19, 13)
        Me.Label9.TabIndex = 1008
        Me.Label9.Text = "To"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.Label5.Location = New System.Drawing.Point(399, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 1013
        Me.Label5.Text = "Pancang"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.Label3.Location = New System.Drawing.Point(399, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 1010
        Me.Label3.Text = "Nama Item"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpTerima
        '
        Me.dtpTerima.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTerima.Location = New System.Drawing.Point(117, 78)
        Me.dtpTerima.Name = "dtpTerima"
        Me.dtpTerima.Size = New System.Drawing.Size(112, 20)
        Me.dtpTerima.TabIndex = 1029
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.Label11.Location = New System.Drawing.Point(399, 82)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 13)
        Me.Label11.TabIndex = 1009
        Me.Label11.Text = "Kategori Item"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpCreate1
        '
        Me.dtpCreate1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCreate1.Location = New System.Drawing.Point(117, 33)
        Me.dtpCreate1.Name = "dtpCreate1"
        Me.dtpCreate1.Size = New System.Drawing.Size(112, 20)
        Me.dtpCreate1.TabIndex = 1024
        '
        'Dtp1
        '
        Me.Dtp1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtp1.Location = New System.Drawing.Point(117, 56)
        Me.Dtp1.Name = "Dtp1"
        Me.Dtp1.Size = New System.Drawing.Size(112, 20)
        Me.Dtp1.TabIndex = 1028
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.Label8.Location = New System.Drawing.Point(399, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 13)
        Me.Label8.TabIndex = 1012
        Me.Label8.Text = "Pembelian"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtItem
        '
        Me.TxtItem.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.TxtItem.Location = New System.Drawing.Point(476, 57)
        Me.TxtItem.Name = "TxtItem"
        Me.TxtItem.Size = New System.Drawing.Size(246, 18)
        Me.TxtItem.TabIndex = 1014
        '
        'FrmMonPembelianBarangPancangCash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(885, 401)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmMonPembelianBarangPancangCash"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Monitoring Pembelian Barang Pancang Cash"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.FG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel13.ResumeLayout(False)
        Me.Panel13.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        Me.Panel12.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents FG As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel6 As Panel
    Friend WithEvents ChkAll As CheckBox
    Friend WithEvents Panel11 As Panel
    Friend WithEvents rdTrip2 As RadioButton
    Friend WithEvents rdTrip1 As RadioButton
    Friend WithEvents Label13 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents rdPulsa As RadioButton
    Friend WithEvents Label15 As Label
    Friend WithEvents chkTglTerima As RadioButton
    Friend WithEvents rdTgl As RadioButton
    Friend WithEvents chkTglNota As RadioButton
    Friend WithEvents RdPurchaser As RadioButton
    Friend WithEvents RdPancang As RadioButton
    Friend WithEvents Panel12 As Panel
    Friend WithEvents rdBelumPrint As RadioButton
    Friend WithEvents rdSudahPrint As RadioButton
    Friend WithEvents rdall As RadioButton
    Friend WithEvents dtpTerima2 As DateTimePicker
    Friend WithEvents Label16 As Label
    Friend WithEvents dtpCreate2 As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Dtp2 As DateTimePicker
    Friend WithEvents Label9 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpTerima As DateTimePicker
    Friend WithEvents Label11 As Label
    Friend WithEvents dtpCreate1 As DateTimePicker
    Friend WithEvents Dtp1 As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents TxtItem As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents CmbKategori As ComboBox
    Friend WithEvents CmbPancang As ComboBox
    Friend WithEvents Panel13 As Panel
    Friend WithEvents BtnExit As Button
    Friend WithEvents BtnExcel As Button
    Friend WithEvents BtnPrint As Button
    Friend WithEvents btnKalkulasiData As Button
    Friend WithEvents btnPrint2 As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
End Class
