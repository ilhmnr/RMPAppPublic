<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMstItem
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMstItem))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.fgDtl = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ChkGetAllData = New System.Windows.Forms.CheckBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.CmbFilterNamaToko = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.ChkTgl = New System.Windows.Forms.CheckBox()
        Me.DtpStart = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Dtpend = New System.Windows.Forms.DateTimePicker()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DtpCekTglAwal = New System.Windows.Forms.DateTimePicker()
        Me.TxtHargaAwal = New System.Windows.Forms.TextBox()
        Me.TxtIdHarga = New System.Windows.Forms.TextBox()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.BtnUpdate = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.pic1 = New System.Windows.Forms.PictureBox()
        Me.DtpTanggal = New System.Windows.Forms.DateTimePicker()
        Me.BtnChoose = New System.Windows.Forms.Button()
        Me.TxtNamaItem = New System.Windows.Forms.TextBox()
        Me.TxtHargaPoint = New System.Windows.Forms.TextBox()
        Me.TxtTotalPoint = New System.Windows.Forms.TextBox()
        Me.TxtHarga = New System.Windows.Forms.TextBox()
        Me.TxtIdItem = New System.Windows.Forms.TextBox()
        Me.TxtKodeItem = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkNotActive = New System.Windows.Forms.CheckBox()
        Me.CmbNamaToko = New System.Windows.Forms.ComboBox()
        Me.CmbSatuan = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Satuan = New System.Windows.Forms.Label()
        Me.CmbJenisItem = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel10.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.fgDtl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.pic1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Panel10
        '
        Me.Panel10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel10.Controls.Add(Me.Label9)
        Me.Panel10.Location = New System.Drawing.Point(0, 0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(1276, 36)
        Me.Panel10.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Rockwell Condensed", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(2, 4)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(154, 28)
        Me.Label9.TabIndex = 879
        Me.Label9.Text = "Master Item"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel2.Controls.Add(Me.GroupBox3)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Controls.Add(Me.GroupBox4)
        Me.Panel2.Location = New System.Drawing.Point(0, 36)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1276, 639)
        Me.Panel2.TabIndex = 9
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox3.Controls.Add(Me.fgDtl)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.GroupBox3.Location = New System.Drawing.Point(918, 316)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(358, 323)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "List Data"
        '
        'fgDtl
        '
        Me.fgDtl.ColumnInfo = "12,1,0,0,0,-1,Columns:10{Style:""DataType:System.Boolean;TextAlign:LeftCenter;Imag" &
    "eAlign:CenterCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "11{Style:""DataType:System.Boolean;TextAlign:LeftCenter;I" &
    "mageAlign:CenterCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.fgDtl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgDtl.Location = New System.Drawing.Point(3, 19)
        Me.fgDtl.Name = "fgDtl"
        Me.fgDtl.Size = New System.Drawing.Size(352, 301)
        Me.fgDtl.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.ChkGetAllData)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.CmbFilterNamaToko)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.ChkTgl)
        Me.GroupBox1.Controls.Add(Me.DtpStart)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Dtpend)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.btnRefresh)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, -2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1276, 72)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter Data"
        '
        'ChkGetAllData
        '
        Me.ChkGetAllData.AutoSize = True
        Me.ChkGetAllData.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ChkGetAllData.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkGetAllData.ForeColor = System.Drawing.Color.Red
        Me.ChkGetAllData.Location = New System.Drawing.Point(418, 45)
        Me.ChkGetAllData.Name = "ChkGetAllData"
        Me.ChkGetAllData.Size = New System.Drawing.Size(99, 21)
        Me.ChkGetAllData.TabIndex = 953
        Me.ChkGetAllData.Text = "Get All Data"
        Me.ChkGetAllData.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(12, 18)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(86, 21)
        Me.Label15.TabIndex = 916
        Me.Label15.Text = "Nama Toko"
        '
        'CmbFilterNamaToko
        '
        Me.CmbFilterNamaToko.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.CmbFilterNamaToko.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbFilterNamaToko.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbFilterNamaToko.FormattingEnabled = True
        Me.CmbFilterNamaToko.Location = New System.Drawing.Point(167, 16)
        Me.CmbFilterNamaToko.Name = "CmbFilterNamaToko"
        Me.CmbFilterNamaToko.Size = New System.Drawing.Size(245, 24)
        Me.CmbFilterNamaToko.TabIndex = 891
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(150, 20)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(11, 16)
        Me.Label26.TabIndex = 902
        Me.Label26.Text = ":"
        '
        'ChkTgl
        '
        Me.ChkTgl.AutoSize = True
        Me.ChkTgl.BackColor = System.Drawing.Color.Transparent
        Me.ChkTgl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ChkTgl.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkTgl.Location = New System.Drawing.Point(16, 45)
        Me.ChkTgl.Name = "ChkTgl"
        Me.ChkTgl.Size = New System.Drawing.Size(137, 20)
        Me.ChkTgl.TabIndex = 883
        Me.ChkTgl.Text = "Tanggal Periode "
        Me.ChkTgl.UseVisualStyleBackColor = False
        '
        'DtpStart
        '
        Me.DtpStart.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpStart.Location = New System.Drawing.Point(167, 44)
        Me.DtpStart.Name = "DtpStart"
        Me.DtpStart.Size = New System.Drawing.Size(110, 22)
        Me.DtpStart.TabIndex = 896
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(283, 47)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(12, 16)
        Me.Label12.TabIndex = 898
        Me.Label12.Text = "-"
        '
        'Dtpend
        '
        Me.Dtpend.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtpend.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dtpend.Location = New System.Drawing.Point(302, 44)
        Me.Dtpend.Name = "Dtpend"
        Me.Dtpend.Size = New System.Drawing.Size(110, 22)
        Me.Dtpend.TabIndex = 897
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(150, 47)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(11, 16)
        Me.Label14.TabIndex = 899
        Me.Label14.Text = ":"
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.White
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRefresh.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.Color.Black
        Me.btnRefresh.Image = Global.RMPApp.My.Resources.Resources.find20
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRefresh.Location = New System.Drawing.Point(523, 35)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(85, 30)
        Me.btnRefresh.TabIndex = 894
        Me.btnRefresh.Text = "CARI"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Panel3)
        Me.GroupBox2.Controls.Add(Me.Panel1)
        Me.GroupBox2.Controls.Add(Me.DtpCekTglAwal)
        Me.GroupBox2.Controls.Add(Me.TxtHargaAwal)
        Me.GroupBox2.Controls.Add(Me.TxtIdHarga)
        Me.GroupBox2.Controls.Add(Me.txtFileName)
        Me.GroupBox2.Controls.Add(Me.btnAdd)
        Me.GroupBox2.Controls.Add(Me.BtnExit)
        Me.GroupBox2.Controls.Add(Me.btnCancel)
        Me.GroupBox2.Controls.Add(Me.BtnUpdate)
        Me.GroupBox2.Controls.Add(Me.btnSave)
        Me.GroupBox2.Controls.Add(Me.pic1)
        Me.GroupBox2.Controls.Add(Me.DtpTanggal)
        Me.GroupBox2.Controls.Add(Me.BtnChoose)
        Me.GroupBox2.Controls.Add(Me.TxtNamaItem)
        Me.GroupBox2.Controls.Add(Me.TxtHargaPoint)
        Me.GroupBox2.Controls.Add(Me.TxtTotalPoint)
        Me.GroupBox2.Controls.Add(Me.TxtHarga)
        Me.GroupBox2.Controls.Add(Me.TxtIdItem)
        Me.GroupBox2.Controls.Add(Me.TxtKodeItem)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.chkNotActive)
        Me.GroupBox2.Controls.Add(Me.CmbNamaToko)
        Me.GroupBox2.Controls.Add(Me.CmbSatuan)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.Satuan)
        Me.GroupBox2.Controls.Add(Me.CmbJenisItem)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 68)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1276, 250)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Input Data"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(611, 162)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(170, 19)
        Me.Label17.TabIndex = 960
        Me.Label17.Text = "Item Sudah Tidak Aktif"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(611, 186)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(347, 19)
        Me.Label16.TabIndex = 960
        Me.Label16.Text = "Item Aktif Namun Harga Belum Ada Untuk Hari Ini"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Red
        Me.Panel3.Location = New System.Drawing.Point(588, 161)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(21, 20)
        Me.Panel3.TabIndex = 959
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Aqua
        Me.Panel1.Location = New System.Drawing.Point(588, 185)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(21, 20)
        Me.Panel1.TabIndex = 959
        '
        'DtpCekTglAwal
        '
        Me.DtpCekTglAwal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpCekTglAwal.Location = New System.Drawing.Point(113, 127)
        Me.DtpCekTglAwal.Name = "DtpCekTglAwal"
        Me.DtpCekTglAwal.Size = New System.Drawing.Size(23, 23)
        Me.DtpCekTglAwal.TabIndex = 958
        Me.DtpCekTglAwal.Visible = False
        '
        'TxtHargaAwal
        '
        Me.TxtHargaAwal.Location = New System.Drawing.Point(113, 68)
        Me.TxtHargaAwal.Name = "TxtHargaAwal"
        Me.TxtHargaAwal.Size = New System.Drawing.Size(23, 23)
        Me.TxtHargaAwal.TabIndex = 957
        Me.TxtHargaAwal.Visible = False
        '
        'TxtIdHarga
        '
        Me.TxtIdHarga.Location = New System.Drawing.Point(113, 68)
        Me.TxtIdHarga.Name = "TxtIdHarga"
        Me.TxtIdHarga.Size = New System.Drawing.Size(23, 23)
        Me.TxtIdHarga.TabIndex = 956
        Me.TxtIdHarga.Visible = False
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(585, 103)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(23, 23)
        Me.txtFileName.TabIndex = 955
        Me.txtFileName.Visible = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.White
        Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAdd.FlatAppearance.BorderSize = 0
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAdd.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.Black
        Me.btnAdd.Image = Global.RMPApp.My.Resources.Resources.AddPSN
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(588, 214)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(85, 30)
        Me.btnAdd.TabIndex = 895
        Me.btnAdd.Text = "ADD"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'BtnExit
        '
        Me.BtnExit.BackColor = System.Drawing.Color.White
        Me.BtnExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnExit.FlatAppearance.BorderSize = 0
        Me.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnExit.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExit.ForeColor = System.Drawing.Color.Black
        Me.BtnExit.Image = Global.RMPApp.My.Resources.Resources.ExitPSN
        Me.BtnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnExit.Location = New System.Drawing.Point(952, 214)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(85, 30)
        Me.BtnExit.TabIndex = 893
        Me.BtnExit.Text = "Exit"
        Me.BtnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnExit.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.White
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancel.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Image = Global.RMPApp.My.Resources.Resources.Cancel
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(861, 214)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(85, 30)
        Me.btnCancel.TabIndex = 894
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'BtnUpdate
        '
        Me.BtnUpdate.BackColor = System.Drawing.Color.White
        Me.BtnUpdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnUpdate.FlatAppearance.BorderSize = 0
        Me.BtnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnUpdate.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdate.ForeColor = System.Drawing.Color.Black
        Me.BtnUpdate.Image = Global.RMPApp.My.Resources.Resources.icons8_edit_20
        Me.BtnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnUpdate.Location = New System.Drawing.Point(679, 214)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(85, 30)
        Me.BtnUpdate.TabIndex = 892
        Me.BtnUpdate.Text = "EDIT"
        Me.BtnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnUpdate.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.White
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSave.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        Me.btnSave.Image = Global.RMPApp.My.Resources.Resources.SavePSN
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(770, 214)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(85, 30)
        Me.btnSave.TabIndex = 891
        Me.btnSave.Text = "SAVE"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'pic1
        '
        Me.pic1.BackColor = System.Drawing.Color.White
        Me.pic1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pic1.Location = New System.Drawing.Point(412, 16)
        Me.pic1.Name = "pic1"
        Me.pic1.Size = New System.Drawing.Size(170, 195)
        Me.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic1.TabIndex = 954
        Me.pic1.TabStop = False
        '
        'DtpTanggal
        '
        Me.DtpTanggal.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpTanggal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpTanggal.Location = New System.Drawing.Point(158, 128)
        Me.DtpTanggal.Name = "DtpTanggal"
        Me.DtpTanggal.Size = New System.Drawing.Size(245, 22)
        Me.DtpTanggal.TabIndex = 953
        '
        'BtnChoose
        '
        Me.BtnChoose.BackColor = System.Drawing.Color.White
        Me.BtnChoose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnChoose.FlatAppearance.BorderSize = 0
        Me.BtnChoose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnChoose.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnChoose.ForeColor = System.Drawing.Color.Black
        Me.BtnChoose.Location = New System.Drawing.Point(412, 217)
        Me.BtnChoose.Name = "BtnChoose"
        Me.BtnChoose.Size = New System.Drawing.Size(170, 27)
        Me.BtnChoose.TabIndex = 951
        Me.BtnChoose.Text = "Pilih Foto"
        Me.BtnChoose.UseVisualStyleBackColor = False
        '
        'TxtNamaItem
        '
        Me.TxtNamaItem.BackColor = System.Drawing.SystemColors.Window
        Me.TxtNamaItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNamaItem.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNamaItem.Location = New System.Drawing.Point(158, 44)
        Me.TxtNamaItem.Name = "TxtNamaItem"
        Me.TxtNamaItem.Size = New System.Drawing.Size(245, 22)
        Me.TxtNamaItem.TabIndex = 929
        '
        'TxtHargaPoint
        '
        Me.TxtHargaPoint.BackColor = System.Drawing.SystemColors.Window
        Me.TxtHargaPoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtHargaPoint.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHargaPoint.Location = New System.Drawing.Point(354, 100)
        Me.TxtHargaPoint.Name = "TxtHargaPoint"
        Me.TxtHargaPoint.ReadOnly = True
        Me.TxtHargaPoint.Size = New System.Drawing.Size(49, 22)
        Me.TxtHargaPoint.TabIndex = 927
        '
        'TxtTotalPoint
        '
        Me.TxtTotalPoint.BackColor = System.Drawing.SystemColors.Window
        Me.TxtTotalPoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTotalPoint.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalPoint.Location = New System.Drawing.Point(158, 100)
        Me.TxtTotalPoint.Name = "TxtTotalPoint"
        Me.TxtTotalPoint.ReadOnly = True
        Me.TxtTotalPoint.Size = New System.Drawing.Size(190, 22)
        Me.TxtTotalPoint.TabIndex = 926
        '
        'TxtHarga
        '
        Me.TxtHarga.BackColor = System.Drawing.SystemColors.Window
        Me.TxtHarga.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtHarga.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHarga.Location = New System.Drawing.Point(158, 72)
        Me.TxtHarga.Name = "TxtHarga"
        Me.TxtHarga.Size = New System.Drawing.Size(245, 22)
        Me.TxtHarga.TabIndex = 925
        '
        'TxtIdItem
        '
        Me.TxtIdItem.BackColor = System.Drawing.SystemColors.Window
        Me.TxtIdItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIdItem.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIdItem.Location = New System.Drawing.Point(113, 15)
        Me.TxtIdItem.Name = "TxtIdItem"
        Me.TxtIdItem.ReadOnly = True
        Me.TxtIdItem.Size = New System.Drawing.Size(23, 22)
        Me.TxtIdItem.TabIndex = 928
        Me.TxtIdItem.Visible = False
        '
        'TxtKodeItem
        '
        Me.TxtKodeItem.BackColor = System.Drawing.SystemColors.Window
        Me.TxtKodeItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtKodeItem.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKodeItem.Location = New System.Drawing.Point(158, 16)
        Me.TxtKodeItem.Name = "TxtKodeItem"
        Me.TxtKodeItem.ReadOnly = True
        Me.TxtKodeItem.Size = New System.Drawing.Size(245, 22)
        Me.TxtKodeItem.TabIndex = 928
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(142, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(10, 21)
        Me.Label8.TabIndex = 936
        Me.Label8.Text = ":"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(142, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(10, 21)
        Me.Label7.TabIndex = 937
        Me.Label7.Text = ":"
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(142, 103)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(10, 21)
        Me.Label23.TabIndex = 939
        Me.Label23.Text = ":"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(142, 129)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(10, 21)
        Me.Label11.TabIndex = 938
        Me.Label11.Text = ":"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(142, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 21)
        Me.Label5.TabIndex = 940
        Me.Label5.Text = ":"
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(142, 220)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(10, 21)
        Me.Label25.TabIndex = 934
        Me.Label25.Text = ":"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(142, 190)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(10, 21)
        Me.Label13.TabIndex = 935
        Me.Label13.Text = ":"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(142, 159)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 21)
        Me.Label4.TabIndex = 941
        Me.Label4.Text = ":"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(12, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 21)
        Me.Label3.TabIndex = 942
        Me.Label3.Text = "Kode Item"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(12, 103)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(91, 19)
        Me.Label22.TabIndex = 931
        Me.Label22.Text = "Harga Point"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(12, 129)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(132, 19)
        Me.Label10.TabIndex = 930
        Me.Label10.Text = "Tanggal Berlaku"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(12, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 19)
        Me.Label2.TabIndex = 932
        Me.Label2.Text = "Harga Item"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 19)
        Me.Label1.TabIndex = 933
        Me.Label1.Text = "Nama Item"
        '
        'chkNotActive
        '
        Me.chkNotActive.AutoSize = True
        Me.chkNotActive.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chkNotActive.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNotActive.ForeColor = System.Drawing.Color.Red
        Me.chkNotActive.Location = New System.Drawing.Point(588, 19)
        Me.chkNotActive.Name = "chkNotActive"
        Me.chkNotActive.Size = New System.Drawing.Size(91, 21)
        Me.chkNotActive.TabIndex = 952
        Me.chkNotActive.Text = "Not Active"
        Me.chkNotActive.UseVisualStyleBackColor = True
        '
        'CmbNamaToko
        '
        Me.CmbNamaToko.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.CmbNamaToko.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbNamaToko.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbNamaToko.FormattingEnabled = True
        Me.CmbNamaToko.Location = New System.Drawing.Point(158, 217)
        Me.CmbNamaToko.Name = "CmbNamaToko"
        Me.CmbNamaToko.Size = New System.Drawing.Size(245, 25)
        Me.CmbNamaToko.TabIndex = 943
        '
        'CmbSatuan
        '
        Me.CmbSatuan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.CmbSatuan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbSatuan.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbSatuan.FormattingEnabled = True
        Me.CmbSatuan.Location = New System.Drawing.Point(158, 187)
        Me.CmbSatuan.Name = "CmbSatuan"
        Me.CmbSatuan.Size = New System.Drawing.Size(245, 25)
        Me.CmbSatuan.TabIndex = 944
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(12, 220)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(107, 21)
        Me.Label21.TabIndex = 948
        Me.Label21.Text = "Nama Toko"
        '
        'Satuan
        '
        Me.Satuan.BackColor = System.Drawing.Color.Transparent
        Me.Satuan.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Satuan.ForeColor = System.Drawing.Color.Black
        Me.Satuan.Location = New System.Drawing.Point(12, 190)
        Me.Satuan.Name = "Satuan"
        Me.Satuan.Size = New System.Drawing.Size(107, 21)
        Me.Satuan.TabIndex = 949
        Me.Satuan.Text = "Satuan Item"
        '
        'CmbJenisItem
        '
        Me.CmbJenisItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.CmbJenisItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbJenisItem.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbJenisItem.FormattingEnabled = True
        Me.CmbJenisItem.Location = New System.Drawing.Point(158, 156)
        Me.CmbJenisItem.Name = "CmbJenisItem"
        Me.CmbJenisItem.Size = New System.Drawing.Size(245, 25)
        Me.CmbJenisItem.TabIndex = 947
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(12, 159)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 21)
        Me.Label6.TabIndex = 950
        Me.Label6.Text = "Jenis Item"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox4.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.GroupBox4.Controls.Add(Me.fg)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.GroupBox4.Location = New System.Drawing.Point(0, 316)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(915, 323)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Detail List"
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.C1FlexGridSearchPanel1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(622, -15)
        Me.C1FlexGridSearchPanel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.ShowClearButton = False
        Me.C1FlexGridSearchPanel1.ShowSearchButton = False
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(320, 33)
        Me.C1FlexGridSearchPanel1.TabIndex = 926
        '
        'fg
        '
        Me.fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fg.ColumnInfo = "18,1,0,0,0,110,Columns:14{Style:""DataType:System.Boolean;TextAlign:LeftCenter;Ima" &
    "geAlign:CenterCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fg.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fg.ForeColor = System.Drawing.Color.Black
        Me.fg.Location = New System.Drawing.Point(3, 19)
        Me.fg.Name = "fg"
        Me.fg.Rows.Count = 4
        Me.fg.Rows.DefaultSize = 22
        Me.fg.Size = New System.Drawing.Size(909, 301)
        Me.fg.StyleInfo = resources.GetString("fg.StyleInfo")
        Me.fg.TabIndex = 925
        '
        'FrmMstItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1276, 674)
        Me.Controls.Add(Me.Panel10)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "FrmMstItem"
        Me.Text = "FrmMstItem"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel10.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.fgDtl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.pic1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents BtnExit As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents BtnUpdate As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents pic1 As PictureBox
    Friend WithEvents DtpTanggal As DateTimePicker
    Friend WithEvents BtnChoose As Button
    Friend WithEvents TxtNamaItem As TextBox
    Friend WithEvents TxtHargaPoint As TextBox
    Friend WithEvents TxtTotalPoint As TextBox
    Friend WithEvents TxtHarga As TextBox
    Friend WithEvents TxtKodeItem As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents chkNotActive As CheckBox
    Friend WithEvents CmbNamaToko As ComboBox
    Friend WithEvents CmbSatuan As ComboBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Satuan As Label
    Friend WithEvents CmbJenisItem As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label15 As Label
    Friend WithEvents CmbFilterNamaToko As ComboBox
    Friend WithEvents Label26 As Label
    Friend WithEvents ChkTgl As CheckBox
    Friend WithEvents DtpStart As DateTimePicker
    Friend WithEvents Label12 As Label
    Friend WithEvents Dtpend As DateTimePicker
    Friend WithEvents Label14 As Label
    Friend WithEvents btnRefresh As Button
    Friend WithEvents fgDtl As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents TxtIdItem As TextBox
    Friend WithEvents txtFileName As TextBox
    Friend WithEvents TxtIdHarga As TextBox
    Friend WithEvents TxtHargaAwal As TextBox
    Friend WithEvents DtpCekTglAwal As DateTimePicker
    Friend WithEvents ChkGetAllData As CheckBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label17 As Label
    Friend WithEvents Panel3 As Panel
End Class
