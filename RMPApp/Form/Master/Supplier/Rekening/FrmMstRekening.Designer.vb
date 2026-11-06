<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMstRekening
    'Inherits System.Windows.Forms.Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMstRekening))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtNoRekening = New System.Windows.Forms.MaskedTextBox()
        Me.txtIDPancang = New System.Windows.Forms.TextBox()
        Me.btnFileChooseImage = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pictItem = New System.Windows.Forms.PictureBox()
        Me.txtFileAttachment = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtIDRek = New System.Windows.Forms.TextBox()
        Me.chkInActive = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboBank = New System.Windows.Forms.ComboBox()
        Me.txtKeterangan = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtNamaSup = New System.Windows.Forms.TextBox()
        Me.chkkelapa = New System.Windows.Forms.CheckBox()
        Me.txtKodeSup = New System.Windows.Forms.TextBox()
        Me.CHKUBM = New System.Windows.Forms.CheckBox()
        Me.chkKomisi = New System.Windows.Forms.CheckBox()
        Me.chkub = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.fgRek = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.rdTidakAdaRek = New System.Windows.Forms.RadioButton()
        Me.txtFind = New System.Windows.Forms.TextBox()
        Me.rdAdaRek = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rdAllRek = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel4.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pictItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.fgRek, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel10.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel12.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Panel6)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.Panel2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1226, 40)
        Me.Panel4.TabIndex = 415
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Black
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel6.Location = New System.Drawing.Point(0, 39)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1226, 1)
        Me.Panel6.TabIndex = 905704
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(46, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(172, 28)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Master Rekening"
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Location = New System.Drawing.Point(10, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(35, 35)
        Me.Panel2.TabIndex = 3
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel8.Controls.Add(Me.btnExcel)
        Me.Panel8.Controls.Add(Me.btnExit)
        Me.Panel8.Controls.Add(Me.BtnCancel)
        Me.Panel8.Controls.Add(Me.btnSave)
        Me.Panel8.Controls.Add(Me.btnEdit)
        Me.Panel8.Controls.Add(Me.btnAdd)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel8.Location = New System.Drawing.Point(0, 501)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(1226, 40)
        Me.Panel8.TabIndex = 415
        '
        'btnExcel
        '
        Me.btnExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExcel.BackColor = System.Drawing.Color.White
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(10, 5)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnExcel.Size = New System.Drawing.Size(121, 30)
        Me.btnExcel.TabIndex = 439
        Me.btnExcel.Text = "Convert Excel"
        Me.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcel.UseVisualStyleBackColor = False
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.BackColor = System.Drawing.Color.White
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExit.Location = New System.Drawing.Point(1141, 5)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnExit.Size = New System.Drawing.Size(75, 30)
        Me.btnExit.TabIndex = 438
        Me.btnExit.Text = "Exit"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.BackColor = System.Drawing.Color.White
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCancel.Location = New System.Drawing.Point(1065, 5)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Padding = New System.Windows.Forms.Padding(5, 0, 3, 0)
        Me.BtnCancel.Size = New System.Drawing.Size(75, 30)
        Me.BtnCancel.TabIndex = 437
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.White
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(989, 5)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnSave.Size = New System.Drawing.Size(75, 30)
        Me.btnSave.TabIndex = 436
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BackColor = System.Drawing.Color.White
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEdit.Location = New System.Drawing.Point(913, 5)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnEdit.Size = New System.Drawing.Size(75, 30)
        Me.btnEdit.TabIndex = 434
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.White
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(837, 5)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnAdd.Size = New System.Drawing.Size(75, 30)
        Me.btnAdd.TabIndex = 433
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.Panel11)
        Me.Panel9.Controls.Add(Me.Panel10)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(0, 40)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(1226, 461)
        Me.Panel9.TabIndex = 415
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.Panel1)
        Me.Panel11.Controls.Add(Me.GroupBox4)
        Me.Panel11.Controls.Add(Me.GroupBox3)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel11.Location = New System.Drawing.Point(411, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel11.Size = New System.Drawing.Size(815, 461)
        Me.Panel11.TabIndex = 424
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 461)
        Me.Panel1.TabIndex = 905705
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtNoRekening)
        Me.GroupBox4.Controls.Add(Me.txtIDPancang)
        Me.GroupBox4.Controls.Add(Me.btnFileChooseImage)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.GroupBox1)
        Me.GroupBox4.Controls.Add(Me.txtFileAttachment)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.txtIDRek)
        Me.GroupBox4.Controls.Add(Me.chkInActive)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.cboBank)
        Me.GroupBox4.Controls.Add(Me.txtKeterangan)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.txtNamaSup)
        Me.GroupBox4.Controls.Add(Me.chkkelapa)
        Me.GroupBox4.Controls.Add(Me.txtKodeSup)
        Me.GroupBox4.Controls.Add(Me.CHKUBM)
        Me.GroupBox4.Controls.Add(Me.chkKomisi)
        Me.GroupBox4.Controls.Add(Me.chkub)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox4.Location = New System.Drawing.Point(10, 172)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(795, 279)
        Me.GroupBox4.TabIndex = 869
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Input Rekening"
        '
        'txtNoRekening
        '
        Me.txtNoRekening.Location = New System.Drawing.Point(99, 70)
        Me.txtNoRekening.Mask = "0000 0000 0000 0000 0000"
        Me.txtNoRekening.Name = "txtNoRekening"
        Me.txtNoRekening.Size = New System.Drawing.Size(277, 22)
        Me.txtNoRekening.TabIndex = 873
        '
        'txtIDPancang
        '
        Me.txtIDPancang.Location = New System.Drawing.Point(99, 20)
        Me.txtIDPancang.Name = "txtIDPancang"
        Me.txtIDPancang.Size = New System.Drawing.Size(15, 22)
        Me.txtIDPancang.TabIndex = 872
        Me.txtIDPancang.Visible = False
        '
        'btnFileChooseImage
        '
        Me.btnFileChooseImage.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnFileChooseImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnFileChooseImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnFileChooseImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFileChooseImage.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnFileChooseImage.Location = New System.Drawing.Point(672, 207)
        Me.btnFileChooseImage.Name = "btnFileChooseImage"
        Me.btnFileChooseImage.Size = New System.Drawing.Size(72, 25)
        Me.btnFileChooseImage.TabIndex = 868
        Me.btnFileChooseImage.Text = "Pilih"
        Me.btnFileChooseImage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFileChooseImage.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(446, 212)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 14)
        Me.Label11.TabIndex = 870
        Me.Label11.Text = "Pilih Gambar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.pictItem)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(446, 20)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(298, 189)
        Me.GroupBox1.TabIndex = 869
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Foto Rekening"
        '
        'pictItem
        '
        Me.pictItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pictItem.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.pictItem.Location = New System.Drawing.Point(3, 18)
        Me.pictItem.Name = "pictItem"
        Me.pictItem.Size = New System.Drawing.Size(292, 168)
        Me.pictItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictItem.TabIndex = 227
        Me.pictItem.TabStop = False
        '
        'txtFileAttachment
        '
        Me.txtFileAttachment.AccessibleDescription = "ReadOnly"
        Me.txtFileAttachment.AccessibleName = ""
        Me.txtFileAttachment.BackColor = System.Drawing.Color.White
        Me.txtFileAttachment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFileAttachment.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtFileAttachment.ForeColor = System.Drawing.Color.Black
        Me.txtFileAttachment.Location = New System.Drawing.Point(446, 208)
        Me.txtFileAttachment.Name = "txtFileAttachment"
        Me.txtFileAttachment.Size = New System.Drawing.Size(298, 22)
        Me.txtFileAttachment.TabIndex = 871
        Me.txtFileAttachment.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 863
        Me.Label9.Text = "ID Rekening"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 839
        Me.Label2.Text = "Nama Rekening"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 840
        Me.Label3.Text = "No Rekening"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 841
        Me.Label4.Text = "Bank"
        '
        'txtIDRek
        '
        Me.txtIDRek.Location = New System.Drawing.Point(99, 20)
        Me.txtIDRek.Name = "txtIDRek"
        Me.txtIDRek.ReadOnly = True
        Me.txtIDRek.Size = New System.Drawing.Size(80, 22)
        Me.txtIDRek.TabIndex = 846
        '
        'chkInActive
        '
        Me.chkInActive.AutoSize = True
        Me.chkInActive.Enabled = False
        Me.chkInActive.Location = New System.Drawing.Point(99, 213)
        Me.chkInActive.Name = "chkInActive"
        Me.chkInActive.Size = New System.Drawing.Size(115, 17)
        Me.chkInActive.TabIndex = 847
        Me.chkInActive.Text = "InActiveRekening"
        Me.chkInActive.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 139)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 850
        Me.Label7.Text = "Keterangan"
        '
        'cboBank
        '
        Me.cboBank.FormattingEnabled = True
        Me.cboBank.Location = New System.Drawing.Point(99, 95)
        Me.cboBank.Name = "cboBank"
        Me.cboBank.Size = New System.Drawing.Size(189, 21)
        Me.cboBank.TabIndex = 861
        '
        'txtKeterangan
        '
        Me.txtKeterangan.Location = New System.Drawing.Point(99, 136)
        Me.txtKeterangan.Multiline = True
        Me.txtKeterangan.Name = "txtKeterangan"
        Me.txtKeterangan.Size = New System.Drawing.Size(277, 50)
        Me.txtKeterangan.TabIndex = 860
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(96, 119)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(192, 13)
        Me.Label8.TabIndex = 852
        Me.Label8.Text = "ketik nama bank jika belum tersedia"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 192)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 13)
        Me.Label10.TabIndex = 853
        Me.Label10.Text = "Jenis Rekening"
        '
        'txtNamaSup
        '
        Me.txtNamaSup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNamaSup.Location = New System.Drawing.Point(99, 45)
        Me.txtNamaSup.Name = "txtNamaSup"
        Me.txtNamaSup.Size = New System.Drawing.Size(277, 22)
        Me.txtNamaSup.TabIndex = 860
        '
        'chkkelapa
        '
        Me.chkkelapa.AutoSize = True
        Me.chkkelapa.Location = New System.Drawing.Point(99, 190)
        Me.chkkelapa.Name = "chkkelapa"
        Me.chkkelapa.Size = New System.Drawing.Size(60, 17)
        Me.chkkelapa.TabIndex = 856
        Me.chkkelapa.Text = "Kelapa"
        Me.chkkelapa.UseVisualStyleBackColor = True
        '
        'txtKodeSup
        '
        Me.txtKodeSup.Location = New System.Drawing.Point(185, 20)
        Me.txtKodeSup.Name = "txtKodeSup"
        Me.txtKodeSup.ReadOnly = True
        Me.txtKodeSup.Size = New System.Drawing.Size(80, 22)
        Me.txtKodeSup.TabIndex = 860
        '
        'CHKUBM
        '
        Me.CHKUBM.AutoSize = True
        Me.CHKUBM.Location = New System.Drawing.Point(165, 190)
        Me.CHKUBM.Name = "CHKUBM"
        Me.CHKUBM.Size = New System.Drawing.Size(100, 17)
        Me.CHKUBM.TabIndex = 857
        Me.CHKUBM.Text = "Bongkar Muat"
        Me.CHKUBM.UseVisualStyleBackColor = True
        '
        'chkKomisi
        '
        Me.chkKomisi.AutoSize = True
        Me.chkKomisi.Location = New System.Drawing.Point(378, 190)
        Me.chkKomisi.Name = "chkKomisi"
        Me.chkKomisi.Size = New System.Drawing.Size(59, 17)
        Me.chkKomisi.TabIndex = 859
        Me.chkKomisi.Text = "Komisi"
        Me.chkKomisi.UseVisualStyleBackColor = True
        '
        'chkub
        '
        Me.chkub.AutoSize = True
        Me.chkub.Location = New System.Drawing.Point(271, 190)
        Me.chkub.Name = "chkub"
        Me.chkub.Size = New System.Drawing.Size(101, 17)
        Me.chkub.TabIndex = 858
        Me.chkub.Text = "Upah Bongkar"
        Me.chkub.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.fgRek)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(10, 10)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(795, 162)
        Me.GroupBox3.TabIndex = 429
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "List Rekening"
        '
        'fgRek
        '
        Me.fgRek.ColumnInfo = resources.GetString("fgRek.ColumnInfo")
        Me.fgRek.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgRek.Location = New System.Drawing.Point(3, 18)
        Me.fgRek.Name = "fgRek"
        Me.fgRek.Size = New System.Drawing.Size(789, 141)
        Me.fgRek.TabIndex = 427
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.Panel13)
        Me.Panel10.Controls.Add(Me.Panel12)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel10.Location = New System.Drawing.Point(0, 0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(411, 461)
        Me.Panel10.TabIndex = 424
        '
        'Panel13
        '
        Me.Panel13.Controls.Add(Me.GroupBox2)
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel13.Location = New System.Drawing.Point(0, 57)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Padding = New System.Windows.Forms.Padding(10, 0, 10, 10)
        Me.Panel13.Size = New System.Drawing.Size(411, 404)
        Me.Panel13.TabIndex = 330
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.fg)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(10, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(391, 394)
        Me.GroupBox2.TabIndex = 330
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "List Supplier"
        '
        'fg
        '
        Me.fg.ColumnInfo = resources.GetString("fg.ColumnInfo")
        Me.fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fg.Location = New System.Drawing.Point(3, 18)
        Me.fg.Name = "fg"
        Me.fg.Size = New System.Drawing.Size(385, 373)
        Me.fg.TabIndex = 329
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.btnRefresh)
        Me.Panel12.Controls.Add(Me.rdTidakAdaRek)
        Me.Panel12.Controls.Add(Me.txtFind)
        Me.Panel12.Controls.Add(Me.rdAdaRek)
        Me.Panel12.Controls.Add(Me.Label1)
        Me.Panel12.Controls.Add(Me.rdAllRek)
        Me.Panel12.Controls.Add(Me.Label5)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel12.Location = New System.Drawing.Point(0, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(411, 57)
        Me.Panel12.TabIndex = 330
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.White
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRefresh.Location = New System.Drawing.Point(249, 5)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btnRefresh.Size = New System.Drawing.Size(75, 30)
        Me.btnRefresh.TabIndex = 440
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'rdTidakAdaRek
        '
        Me.rdTidakAdaRek.AutoSize = True
        Me.rdTidakAdaRek.Location = New System.Drawing.Point(217, 34)
        Me.rdTidakAdaRek.Name = "rdTidakAdaRek"
        Me.rdTidakAdaRek.Size = New System.Drawing.Size(127, 17)
        Me.rdTidakAdaRek.TabIndex = 332
        Me.rdTidakAdaRek.Text = "Tidak Ada Rekening"
        Me.rdTidakAdaRek.UseVisualStyleBackColor = True
        '
        'txtFind
        '
        Me.txtFind.Location = New System.Drawing.Point(70, 9)
        Me.txtFind.Name = "txtFind"
        Me.txtFind.Size = New System.Drawing.Size(173, 22)
        Me.txtFind.TabIndex = 325
        '
        'rdAdaRek
        '
        Me.rdAdaRek.AutoSize = True
        Me.rdAdaRek.Location = New System.Drawing.Point(114, 34)
        Me.rdAdaRek.Name = "rdAdaRek"
        Me.rdAdaRek.Size = New System.Drawing.Size(97, 17)
        Me.rdAdaRek.TabIndex = 332
        Me.rdAdaRek.Text = "Ada Rekening"
        Me.rdAdaRek.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 326
        Me.Label1.Text = "Cari Relasi"
        '
        'rdAllRek
        '
        Me.rdAllRek.AutoSize = True
        Me.rdAllRek.Checked = True
        Me.rdAllRek.Location = New System.Drawing.Point(70, 34)
        Me.rdAllRek.Name = "rdAllRek"
        Me.rdAllRek.Size = New System.Drawing.Size(38, 17)
        Me.rdAllRek.TabIndex = 332
        Me.rdAllRek.TabStop = True
        Me.rdAllRek.Text = "All"
        Me.rdAllRek.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 331
        Me.Label5.Text = "Rekening"
        '
        'FrmMstRekening
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1226, 541)
        Me.Controls.Add(Me.Panel9)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.Panel4)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmMstRekening"
        Me.Text = "Master Rekening"
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.pictItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.fgRek, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel10.ResumeLayout(False)
        Me.Panel13.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel12.ResumeLayout(False)
        Me.Panel12.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFind As TextBox
    Friend WithEvents Panel13 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents rdTidakAdaRek As RadioButton
    Friend WithEvents rdAdaRek As RadioButton
    Friend WithEvents rdAllRek As RadioButton
    Friend WithEvents Label5 As Label
    Friend WithEvents fgRek As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents btnFileChooseImage As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents pictItem As PictureBox
    Friend WithEvents txtFileAttachment As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtIDRek As TextBox
    Friend WithEvents chkInActive As CheckBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cboBank As ComboBox
    Friend WithEvents txtKeterangan As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtNamaSup As TextBox
    Friend WithEvents chkkelapa As CheckBox
    Friend WithEvents txtKodeSup As TextBox
    Friend WithEvents CHKUBM As CheckBox
    Friend WithEvents chkKomisi As CheckBox
    Friend WithEvents chkub As CheckBox
    Friend WithEvents btnExcel As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents BtnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtIDPancang As TextBox
    Friend WithEvents btnRefresh As Button
    Friend WithEvents txtNoRekening As MaskedTextBox
End Class
