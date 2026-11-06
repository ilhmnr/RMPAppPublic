<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMstTokoNew
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMstTokoNew))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.schfg = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnlHead = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtFileRek = New System.Windows.Forms.TextBox()
        Me.txtFileKTP = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtKTP = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.picRek = New System.Windows.Forms.PictureBox()
        Me.btnChooseRek = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.picKTP = New System.Windows.Forms.PictureBox()
        Me.btnChooseKTP = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtBank = New System.Windows.Forms.TextBox()
        Me.txtNamaRek = New System.Windows.Forms.TextBox()
        Me.txtNoRek = New System.Windows.Forms.TextBox()
        Me.chkNotActive = New System.Windows.Forms.CheckBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtNoHPPemilikToko = New System.Windows.Forms.TextBox()
        Me.txtNamaPemilikToko = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.JamTutup = New System.Windows.Forms.DateTimePicker()
        Me.JamBuka = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtKoordinat = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAlamatToko = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNamaToko = New System.Windows.Forms.TextBox()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ChkGetAllData = New System.Windows.Forms.CheckBox()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.picRek, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.picKTP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.BackgroundImage = Global.RMPApp.My.Resources.Resources.Banner600pixel
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.schfg)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.pnlHead)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1380, 125)
        Me.GroupBox1.TabIndex = 905628
        Me.GroupBox1.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.RMPApp.My.Resources.Resources.IconToko22
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(8, 15)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(99, 94)
        Me.PictureBox1.TabIndex = 905611
        Me.PictureBox1.TabStop = False
        '
        'schfg
        '
        Me.schfg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.schfg.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.schfg.Location = New System.Drawing.Point(1133, 83)
        Me.schfg.Margin = New System.Windows.Forms.Padding(1)
        Me.schfg.Name = "schfg"
        Me.schfg.ShowClearButton = False
        Me.schfg.ShowSearchButton = False
        Me.schfg.Size = New System.Drawing.Size(273, 37)
        Me.schfg.TabIndex = 905610
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Palatino Linotype", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(119, 75)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(126, 25)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Loyalty Poin"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Rounded MT Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(119, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(262, 28)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Master Toko Pancang"
        '
        'pnlHead
        '
        Me.pnlHead.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlHead.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.pnlHead.Location = New System.Drawing.Point(102, 108)
        Me.pnlHead.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlHead.Name = "pnlHead"
        Me.pnlHead.Size = New System.Drawing.Size(1221, 1)
        Me.pnlHead.TabIndex = 905608
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox2.Controls.Add(Me.txtFileRek)
        Me.GroupBox2.Controls.Add(Me.txtFileKTP)
        Me.GroupBox2.Controls.Add(Me.Label28)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.txtKTP)
        Me.GroupBox2.Controls.Add(Me.Panel3)
        Me.GroupBox2.Controls.Add(Me.Panel1)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.txtBank)
        Me.GroupBox2.Controls.Add(Me.txtNamaRek)
        Me.GroupBox2.Controls.Add(Me.txtNoRek)
        Me.GroupBox2.Controls.Add(Me.chkNotActive)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.txtNoHPPemilikToko)
        Me.GroupBox2.Controls.Add(Me.txtNamaPemilikToko)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.JamTutup)
        Me.GroupBox2.Controls.Add(Me.JamBuka)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtKoordinat)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtAlamatToko)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtNamaToko)
        Me.GroupBox2.Controls.Add(Me.txtID)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(0, 125)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(637, 691)
        Me.GroupBox2.TabIndex = 905629
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Data Toko"
        '
        'txtFileRek
        '
        Me.txtFileRek.BackColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtFileRek.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFileRek.Enabled = False
        Me.txtFileRek.ForeColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.txtFileRek.Location = New System.Drawing.Point(321, 641)
        Me.txtFileRek.Name = "txtFileRek"
        Me.txtFileRek.Size = New System.Drawing.Size(300, 14)
        Me.txtFileRek.TabIndex = 42
        Me.txtFileRek.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFileKTP
        '
        Me.txtFileKTP.BackColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtFileKTP.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFileKTP.Enabled = False
        Me.txtFileKTP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.txtFileKTP.Location = New System.Drawing.Point(15, 641)
        Me.txtFileKTP.Name = "txtFileKTP"
        Me.txtFileKTP.Size = New System.Drawing.Size(300, 14)
        Me.txtFileKTP.TabIndex = 41
        Me.txtFileKTP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(318, 417)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(84, 15)
        Me.Label28.TabIndex = 40
        Me.Label28.Text = "Foto Rekening"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(12, 417)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(52, 15)
        Me.Label27.TabIndex = 39
        Me.Label27.Text = "Foto KTP"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(12, 257)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(189, 15)
        Me.Label17.TabIndex = 22
        Me.Label17.Text = "Nama Pemilik Toko (Sesuai di KTP)"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(12, 284)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(114, 15)
        Me.Label25.TabIndex = 38
        Me.Label25.Text = "No KTP Pemilik Toko"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(207, 284)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(10, 15)
        Me.Label26.TabIndex = 37
        Me.Label26.Text = ":"
        '
        'txtKTP
        '
        Me.txtKTP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKTP.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKTP.Location = New System.Drawing.Point(223, 282)
        Me.txtKTP.Name = "txtKTP"
        Me.txtKTP.Size = New System.Drawing.Size(398, 21)
        Me.txtKTP.TabIndex = 36
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.picRek)
        Me.Panel3.Controls.Add(Me.btnChooseRek)
        Me.Panel3.Location = New System.Drawing.Point(321, 435)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(300, 200)
        Me.Panel3.TabIndex = 35
        '
        'picRek
        '
        Me.picRek.BackColor = System.Drawing.Color.White
        Me.picRek.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picRek.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picRek.Location = New System.Drawing.Point(0, 0)
        Me.picRek.Name = "picRek"
        Me.picRek.Size = New System.Drawing.Size(300, 177)
        Me.picRek.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picRek.TabIndex = 35
        Me.picRek.TabStop = False
        '
        'btnChooseRek
        '
        Me.btnChooseRek.BackColor = System.Drawing.Color.AliceBlue
        Me.btnChooseRek.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnChooseRek.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnChooseRek.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChooseRek.ForeColor = System.Drawing.Color.SteelBlue
        Me.btnChooseRek.Location = New System.Drawing.Point(0, 177)
        Me.btnChooseRek.Name = "btnChooseRek"
        Me.btnChooseRek.Size = New System.Drawing.Size(300, 23)
        Me.btnChooseRek.TabIndex = 33
        Me.btnChooseRek.Text = "Choose File"
        Me.btnChooseRek.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.picKTP)
        Me.Panel1.Controls.Add(Me.btnChooseKTP)
        Me.Panel1.Location = New System.Drawing.Point(15, 435)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(300, 200)
        Me.Panel1.TabIndex = 34
        '
        'picKTP
        '
        Me.picKTP.BackColor = System.Drawing.Color.White
        Me.picKTP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picKTP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picKTP.Location = New System.Drawing.Point(0, 0)
        Me.picKTP.Name = "picKTP"
        Me.picKTP.Size = New System.Drawing.Size(300, 177)
        Me.picKTP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picKTP.TabIndex = 35
        Me.picKTP.TabStop = False
        '
        'btnChooseKTP
        '
        Me.btnChooseKTP.BackColor = System.Drawing.Color.AliceBlue
        Me.btnChooseKTP.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnChooseKTP.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnChooseKTP.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChooseKTP.ForeColor = System.Drawing.Color.SteelBlue
        Me.btnChooseKTP.Location = New System.Drawing.Point(0, 177)
        Me.btnChooseKTP.Name = "btnChooseKTP"
        Me.btnChooseKTP.Size = New System.Drawing.Size(300, 23)
        Me.btnChooseKTP.TabIndex = 33
        Me.btnChooseKTP.Text = "Choose File"
        Me.btnChooseKTP.UseVisualStyleBackColor = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(207, 365)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(10, 15)
        Me.Label20.TabIndex = 29
        Me.Label20.Text = ":"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(12, 392)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(64, 15)
        Me.Label24.TabIndex = 33
        Me.Label24.Text = "Jenis Bank"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(12, 365)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(131, 15)
        Me.Label23.TabIndex = 32
        Me.Label23.Text = "Nama Rek Pemilik Toko"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(12, 338)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(115, 15)
        Me.Label22.TabIndex = 31
        Me.Label22.Text = "No Rek Pemilik Toko"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(207, 392)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(10, 15)
        Me.Label21.TabIndex = 30
        Me.Label21.Text = ":"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(207, 338)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(10, 15)
        Me.Label19.TabIndex = 28
        Me.Label19.Text = ":"
        '
        'txtBank
        '
        Me.txtBank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBank.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBank.Location = New System.Drawing.Point(223, 390)
        Me.txtBank.Name = "txtBank"
        Me.txtBank.Size = New System.Drawing.Size(398, 21)
        Me.txtBank.TabIndex = 27
        '
        'txtNamaRek
        '
        Me.txtNamaRek.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNamaRek.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNamaRek.Location = New System.Drawing.Point(223, 363)
        Me.txtNamaRek.Name = "txtNamaRek"
        Me.txtNamaRek.Size = New System.Drawing.Size(398, 21)
        Me.txtNamaRek.TabIndex = 26
        '
        'txtNoRek
        '
        Me.txtNoRek.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNoRek.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoRek.Location = New System.Drawing.Point(223, 336)
        Me.txtNoRek.Name = "txtNoRek"
        Me.txtNoRek.Size = New System.Drawing.Size(398, 21)
        Me.txtNoRek.TabIndex = 25
        '
        'chkNotActive
        '
        Me.chkNotActive.AutoSize = True
        Me.chkNotActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkNotActive.Location = New System.Drawing.Point(299, 22)
        Me.chkNotActive.Name = "chkNotActive"
        Me.chkNotActive.Size = New System.Drawing.Size(79, 19)
        Me.chkNotActive.TabIndex = 24
        Me.chkNotActive.Text = "Not Active"
        Me.chkNotActive.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(12, 311)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(110, 15)
        Me.Label18.TabIndex = 23
        Me.Label18.Text = "No HP Pemilik Toko"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(207, 311)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(10, 15)
        Me.Label16.TabIndex = 21
        Me.Label16.Text = ":"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(207, 257)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(10, 15)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = ":"
        '
        'txtNoHPPemilikToko
        '
        Me.txtNoHPPemilikToko.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNoHPPemilikToko.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoHPPemilikToko.Location = New System.Drawing.Point(223, 309)
        Me.txtNoHPPemilikToko.Name = "txtNoHPPemilikToko"
        Me.txtNoHPPemilikToko.Size = New System.Drawing.Size(398, 21)
        Me.txtNoHPPemilikToko.TabIndex = 19
        '
        'txtNamaPemilikToko
        '
        Me.txtNamaPemilikToko.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNamaPemilikToko.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNamaPemilikToko.Location = New System.Drawing.Point(223, 255)
        Me.txtNamaPemilikToko.Name = "txtNamaPemilikToko"
        Me.txtNamaPemilikToko.Size = New System.Drawing.Size(398, 21)
        Me.txtNamaPemilikToko.TabIndex = 18
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 232)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 15)
        Me.Label14.TabIndex = 17
        Me.Label14.Text = "Jam Tutup"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 205)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 15)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = "Jam Buka"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(207, 232)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(10, 15)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = ":"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(207, 205)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(10, 15)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = ":"
        '
        'JamTutup
        '
        Me.JamTutup.CustomFormat = "HH:mm"
        Me.JamTutup.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JamTutup.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.JamTutup.Location = New System.Drawing.Point(223, 228)
        Me.JamTutup.Name = "JamTutup"
        Me.JamTutup.ShowUpDown = True
        Me.JamTutup.Size = New System.Drawing.Size(70, 21)
        Me.JamTutup.TabIndex = 13
        Me.JamTutup.Value = New Date(2023, 3, 29, 0, 0, 0, 0)
        '
        'JamBuka
        '
        Me.JamBuka.CustomFormat = "HH:mm"
        Me.JamBuka.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JamBuka.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.JamBuka.Location = New System.Drawing.Point(223, 201)
        Me.JamBuka.Name = "JamBuka"
        Me.JamBuka.ShowUpDown = True
        Me.JamBuka.Size = New System.Drawing.Size(70, 21)
        Me.JamBuka.TabIndex = 12
        Me.JamBuka.Value = New Date(2023, 3, 29, 0, 0, 0, 0)
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 176)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(87, 15)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Koordinat Toko"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(207, 176)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(10, 15)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = ":"
        '
        'txtKoordinat
        '
        Me.txtKoordinat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKoordinat.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKoordinat.Location = New System.Drawing.Point(223, 174)
        Me.txtKoordinat.Name = "txtKoordinat"
        Me.txtKoordinat.Size = New System.Drawing.Size(398, 21)
        Me.txtKoordinat.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 78)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 15)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Alamat Toko"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(207, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 15)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = ":"
        '
        'txtAlamatToko
        '
        Me.txtAlamatToko.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAlamatToko.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlamatToko.Location = New System.Drawing.Point(223, 76)
        Me.txtAlamatToko.Multiline = True
        Me.txtAlamatToko.Name = "txtAlamatToko"
        Me.txtAlamatToko.Size = New System.Drawing.Size(398, 92)
        Me.txtAlamatToko.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 15)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Nama Toko"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(207, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(10, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = ":"
        '
        'txtNamaToko
        '
        Me.txtNamaToko.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNamaToko.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNamaToko.Location = New System.Drawing.Point(223, 49)
        Me.txtNamaToko.Name = "txtNamaToko"
        Me.txtNamaToko.Size = New System.Drawing.Size(398, 21)
        Me.txtNamaToko.TabIndex = 3
        '
        'txtID
        '
        Me.txtID.BackColor = System.Drawing.SystemColors.Info
        Me.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtID.Enabled = False
        Me.txtID.Location = New System.Drawing.Point(223, 22)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(70, 21)
        Me.txtID.TabIndex = 2
        Me.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(207, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = ":"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID Toko"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox3.Controls.Add(Me.ChkGetAllData)
        Me.GroupBox3.Controls.Add(Me.fg)
        Me.GroupBox3.Controls.Add(Me.Panel2)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(637, 125)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(743, 691)
        Me.GroupBox3.TabIndex = 905630
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "List Toko"
        '
        'ChkGetAllData
        '
        Me.ChkGetAllData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkGetAllData.AutoSize = True
        Me.ChkGetAllData.Location = New System.Drawing.Point(656, -2)
        Me.ChkGetAllData.Name = "ChkGetAllData"
        Me.ChkGetAllData.Size = New System.Drawing.Size(90, 19)
        Me.ChkGetAllData.TabIndex = 432
        Me.ChkGetAllData.Text = "Get All Data"
        Me.ChkGetAllData.UseVisualStyleBackColor = True
        '
        'fg
        '
        Me.fg.AllowEditing = False
        Me.fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fg.ColumnInfo = "23,1,0,0,0,110,Columns:6{Style:""TextAlign:GeneralCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "7{Style:""TextAlign:Ge" &
    "neralCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "22{Style:""TextAlign:GeneralCenter;ImageAlign:CenterCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fg.ForeColor = System.Drawing.Color.Black
        Me.fg.Location = New System.Drawing.Point(3, 17)
        Me.fg.Name = "fg"
        Me.fg.Rows.Count = 4
        Me.fg.Rows.DefaultSize = 22
        Me.fg.Size = New System.Drawing.Size(737, 631)
        Me.fg.StyleInfo = resources.GetString("fg.StyleInfo")
        Me.fg.TabIndex = 431
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnExit)
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Controls.Add(Me.btnEdit)
        Me.Panel2.Controls.Add(Me.btnSave)
        Me.Panel2.Controls.Add(Me.btnRefresh)
        Me.Panel2.Controls.Add(Me.btnAdd)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(3, 648)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(737, 40)
        Me.Panel2.TabIndex = 0
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.BackColor = System.Drawing.Color.White
        Me.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.Color.SteelBlue
        Me.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExit.Location = New System.Drawing.Point(662, 5)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(70, 30)
        Me.btnExit.TabIndex = 905625
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.White
        Me.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.SteelBlue
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(586, 5)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(70, 30)
        Me.btnCancel.TabIndex = 905624
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BackColor = System.Drawing.Color.White
        Me.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.Color.SteelBlue
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEdit.Location = New System.Drawing.Point(510, 5)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(70, 30)
        Me.btnEdit.TabIndex = 905623
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.White
        Me.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.SteelBlue
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(434, 5)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(70, 30)
        Me.btnSave.TabIndex = 905622
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.White
        Me.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.Color.SteelBlue
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRefresh.Location = New System.Drawing.Point(358, 5)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(70, 30)
        Me.btnRefresh.TabIndex = 905621
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.White
        Me.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.SteelBlue
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(282, 5)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(70, 30)
        Me.btnAdd.TabIndex = 905620
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog"
        '
        'FrmMstTokoNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1380, 816)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmMstTokoNew"
        Me.Text = "Master Toko Pancang"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.picRek, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.picKTP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents schfg As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents pnlHead As Panel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents chkNotActive As CheckBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txtNoHPPemilikToko As TextBox
    Friend WithEvents txtNamaPemilikToko As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents JamTutup As DateTimePicker
    Friend WithEvents JamBuka As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtKoordinat As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtAlamatToko As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNamaToko As TextBox
    Friend WithEvents txtID As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnExit As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents txtBank As TextBox
    Friend WithEvents txtNamaRek As TextBox
    Friend WithEvents txtNoRek As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents picRek As PictureBox
    Friend WithEvents btnChooseRek As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents picKTP As PictureBox
    Friend WithEvents btnChooseKTP As Button
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents txtKTP As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents txtFileRek As TextBox
    Friend WithEvents txtFileKTP As TextBox
    Friend WithEvents OpenFileDialog As OpenFileDialog
    Friend WithEvents ChkGetAllData As CheckBox
End Class
