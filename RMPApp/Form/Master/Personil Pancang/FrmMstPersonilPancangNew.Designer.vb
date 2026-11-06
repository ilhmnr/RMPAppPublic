<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMstPersonilPancangNew
    Inherits System.Windows.Forms.Form

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
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.chkNotActiveID = New System.Windows.Forms.CheckBox()
        Me.ChkBni = New System.Windows.Forms.CheckBox()
        Me.ChkMandiri = New System.Windows.Forms.CheckBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.rdpsp = New System.Windows.Forms.RadioButton()
        Me.txtReg = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.chktrainee = New System.Windows.Forms.CheckBox()
        Me.chkNotActive = New System.Windows.Forms.CheckBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TxtNamaRek = New System.Windows.Forms.TextBox()
        Me.txtRek = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.DTP2 = New System.Windows.Forms.DateTimePicker()
        Me.DTP1 = New System.Windows.Forms.DateTimePicker()
        Me.lblCV = New System.Windows.Forms.Label()
        Me.lblPemborong = New System.Windows.Forms.Label()
        Me.txtCV = New System.Windows.Forms.TextBox()
        Me.txtPemborong = New System.Windows.Forms.TextBox()
        Me.txtUangMakan = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkHarian = New System.Windows.Forms.CheckBox()
        Me.chkKaryawan = New System.Windows.Forms.CheckBox()
        Me.txtPulang = New System.Windows.Forms.TextBox()
        Me.txtMasuk = New System.Windows.Forms.TextBox()
        Me.cboIM = New System.Windows.Forms.ComboBox()
        Me.cboJabatan = New System.Windows.Forms.ComboBox()
        Me.cboPancang = New System.Windows.Forms.ComboBox()
        Me.txtNIK = New System.Windows.Forms.TextBox()
        Me.txtNama = New System.Windows.Forms.TextBox()
        Me.rdP2 = New System.Windows.Forms.RadioButton()
        Me.rdP1 = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.btnexit = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.dttgl = New System.Windows.Forms.DateTimePicker()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnAjukanAP = New System.Windows.Forms.Button()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.RDP3 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(3, 6)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(140, 18)
        Me.Label8.TabIndex = 828
        Me.Label8.Text = "Personil Pancang"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(97, -1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 15)
        Me.Label3.TabIndex = 880
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.SplitContainer2)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 35)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(668, 557)
        Me.GroupBox2.TabIndex = 882
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Master"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BackColor = System.Drawing.Color.White
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 16)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitContainer2.Panel1.Controls.Add(Me.RDP3)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkNotActiveID)
        Me.SplitContainer2.Panel1.Controls.Add(Me.ChkBni)
        Me.SplitContainer2.Panel1.Controls.Add(Me.ChkMandiri)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label17)
        Me.SplitContainer2.Panel1.Controls.Add(Me.rdpsp)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtReg)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label11)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chktrainee)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkNotActive)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label18)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label15)
        Me.SplitContainer2.Panel1.Controls.Add(Me.TxtNamaRek)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtRek)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label12)
        Me.SplitContainer2.Panel1.Controls.Add(Me.DTP2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.DTP1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblCV)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblPemborong)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtCV)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtPemborong)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtUangMakan)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label10)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtID)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkHarian)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkKaryawan)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtPulang)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtMasuk)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cboIM)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cboJabatan)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cboPancang)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtNIK)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtNama)
        Me.SplitContainer2.Panel1.Controls.Add(Me.rdP2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.rdP1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label13)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label14)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.BackColor = System.Drawing.Color.White
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnsave)
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnexit)
        Me.SplitContainer2.Size = New System.Drawing.Size(662, 538)
        Me.SplitContainer2.SplitterDistance = 493
        Me.SplitContainer2.TabIndex = 75
        '
        'chkNotActiveID
        '
        Me.chkNotActiveID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkNotActiveID.AutoSize = True
        Me.chkNotActiveID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.chkNotActiveID.Location = New System.Drawing.Point(563, 38)
        Me.chkNotActiveID.Name = "chkNotActiveID"
        Me.chkNotActiveID.Size = New System.Drawing.Size(90, 17)
        Me.chkNotActiveID.TabIndex = 877
        Me.chkNotActiveID.Text = "Not Active ID"
        Me.chkNotActiveID.UseVisualStyleBackColor = True
        '
        'ChkBni
        '
        Me.ChkBni.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ChkBni.AutoSize = True
        Me.ChkBni.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ChkBni.Location = New System.Drawing.Point(334, 465)
        Me.ChkBni.Name = "ChkBni"
        Me.ChkBni.Size = New System.Drawing.Size(44, 17)
        Me.ChkBni.TabIndex = 876
        Me.ChkBni.Text = "BNI"
        Me.ChkBni.UseVisualStyleBackColor = True
        '
        'ChkMandiri
        '
        Me.ChkMandiri.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ChkMandiri.AutoSize = True
        Me.ChkMandiri.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ChkMandiri.Location = New System.Drawing.Point(256, 465)
        Me.ChkMandiri.Name = "ChkMandiri"
        Me.ChkMandiri.Size = New System.Drawing.Size(72, 17)
        Me.ChkMandiri.TabIndex = 876
        Me.ChkMandiri.Text = "MANDIRI"
        Me.ChkMandiri.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(121, 467)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(70, 13)
        Me.Label17.TabIndex = 875
        Me.Label17.Text = "NAMA BANK"
        '
        'rdpsp
        '
        Me.rdpsp.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.rdpsp.AutoSize = True
        Me.rdpsp.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdpsp.Location = New System.Drawing.Point(104, 14)
        Me.rdpsp.Name = "rdpsp"
        Me.rdpsp.Size = New System.Drawing.Size(46, 20)
        Me.rdpsp.TabIndex = 874
        Me.rdpsp.Text = "PSP"
        Me.rdpsp.UseVisualStyleBackColor = True
        '
        'txtReg
        '
        Me.txtReg.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtReg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtReg.Location = New System.Drawing.Point(256, 76)
        Me.txtReg.Name = "txtReg"
        Me.txtReg.Size = New System.Drawing.Size(210, 20)
        Me.txtReg.TabIndex = 873
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(121, 77)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 13)
        Me.Label11.TabIndex = 872
        Me.Label11.Text = "REG/FIXNO"
        '
        'chktrainee
        '
        Me.chktrainee.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chktrainee.AutoSize = True
        Me.chktrainee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.chktrainee.Location = New System.Drawing.Point(222, 328)
        Me.chktrainee.Name = "chktrainee"
        Me.chktrainee.Size = New System.Drawing.Size(73, 17)
        Me.chktrainee.TabIndex = 871
        Me.chktrainee.Text = "TRAINEE"
        Me.chktrainee.UseVisualStyleBackColor = True
        '
        'chkNotActive
        '
        Me.chkNotActive.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkNotActive.AutoSize = True
        Me.chkNotActive.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.chkNotActive.Location = New System.Drawing.Point(563, 16)
        Me.chkNotActive.Name = "chkNotActive"
        Me.chkNotActive.Size = New System.Drawing.Size(76, 17)
        Me.chkNotActive.TabIndex = 870
        Me.chkNotActive.Text = "Not Active"
        Me.chkNotActive.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(121, 413)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(97, 13)
        Me.Label18.TabIndex = 869
        Me.Label18.Text = "NAMA REKENING"
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(121, 439)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(82, 13)
        Me.Label15.TabIndex = 869
        Me.Label15.Text = "NO REKENING"
        '
        'TxtNamaRek
        '
        Me.TxtNamaRek.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TxtNamaRek.BackColor = System.Drawing.SystemColors.Window
        Me.TxtNamaRek.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtNamaRek.Location = New System.Drawing.Point(256, 412)
        Me.TxtNamaRek.Name = "TxtNamaRek"
        Me.TxtNamaRek.Size = New System.Drawing.Size(210, 20)
        Me.TxtNamaRek.TabIndex = 868
        '
        'txtRek
        '
        Me.txtRek.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtRek.BackColor = System.Drawing.SystemColors.Window
        Me.txtRek.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtRek.Location = New System.Drawing.Point(256, 438)
        Me.txtRek.Name = "txtRek"
        Me.txtRek.Size = New System.Drawing.Size(210, 20)
        Me.txtRek.TabIndex = 868
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label12.Location = New System.Drawing.Point(357, 332)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(10, 13)
        Me.Label12.TabIndex = 865
        Me.Label12.Text = "-"
        '
        'DTP2
        '
        Me.DTP2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.DTP2.CustomFormat = "dd/mm/yyyy"
        Me.DTP2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.DTP2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP2.Location = New System.Drawing.Point(371, 328)
        Me.DTP2.Name = "DTP2"
        Me.DTP2.Size = New System.Drawing.Size(93, 20)
        Me.DTP2.TabIndex = 867
        Me.DTP2.Value = New Date(2020, 2, 1, 0, 0, 0, 0)
        '
        'DTP1
        '
        Me.DTP1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.DTP1.CustomFormat = "dd/mm/yyyy"
        Me.DTP1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.DTP1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP1.Location = New System.Drawing.Point(256, 328)
        Me.DTP1.Name = "DTP1"
        Me.DTP1.Size = New System.Drawing.Size(98, 20)
        Me.DTP1.TabIndex = 866
        Me.DTP1.Value = New Date(2020, 2, 1, 0, 0, 0, 0)
        '
        'lblCV
        '
        Me.lblCV.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblCV.AutoSize = True
        Me.lblCV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCV.Location = New System.Drawing.Point(121, 390)
        Me.lblCV.Name = "lblCV"
        Me.lblCV.Size = New System.Drawing.Size(21, 13)
        Me.lblCV.TabIndex = 863
        Me.lblCV.Text = "CV"
        '
        'lblPemborong
        '
        Me.lblPemborong.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblPemborong.AutoSize = True
        Me.lblPemborong.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPemborong.Location = New System.Drawing.Point(121, 361)
        Me.lblPemborong.Name = "lblPemborong"
        Me.lblPemborong.Size = New System.Drawing.Size(77, 13)
        Me.lblPemborong.TabIndex = 862
        Me.lblPemborong.Text = "PEMBORONG"
        '
        'txtCV
        '
        Me.txtCV.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtCV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCV.Location = New System.Drawing.Point(256, 386)
        Me.txtCV.Name = "txtCV"
        Me.txtCV.Size = New System.Drawing.Size(210, 20)
        Me.txtCV.TabIndex = 861
        '
        'txtPemborong
        '
        Me.txtPemborong.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtPemborong.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtPemborong.Location = New System.Drawing.Point(256, 357)
        Me.txtPemborong.Name = "txtPemborong"
        Me.txtPemborong.Size = New System.Drawing.Size(208, 20)
        Me.txtPemborong.TabIndex = 860
        '
        'txtUangMakan
        '
        Me.txtUangMakan.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtUangMakan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtUangMakan.Location = New System.Drawing.Point(256, 299)
        Me.txtUangMakan.Name = "txtUangMakan"
        Me.txtUangMakan.Size = New System.Drawing.Size(208, 20)
        Me.txtUangMakan.TabIndex = 859
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(120, 303)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 13)
        Me.Label10.TabIndex = 858
        Me.Label10.Text = "UANG MAKAN"
        '
        'txtID
        '
        Me.txtID.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtID.BackColor = System.Drawing.SystemColors.Info
        Me.txtID.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtID.Location = New System.Drawing.Point(256, 12)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(144, 23)
        Me.txtID.TabIndex = 857
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Maroon
        Me.Label9.Location = New System.Drawing.Point(232, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(18, 13)
        Me.Label9.TabIndex = 856
        Me.Label9.Text = "ID"
        '
        'chkHarian
        '
        Me.chkHarian.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chkHarian.AutoSize = True
        Me.chkHarian.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.chkHarian.Location = New System.Drawing.Point(355, 190)
        Me.chkHarian.Name = "chkHarian"
        Me.chkHarian.Size = New System.Drawing.Size(67, 17)
        Me.chkHarian.TabIndex = 855
        Me.chkHarian.Text = "HARIAN"
        Me.chkHarian.UseVisualStyleBackColor = True
        '
        'chkKaryawan
        '
        Me.chkKaryawan.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chkKaryawan.AutoSize = True
        Me.chkKaryawan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.chkKaryawan.Location = New System.Drawing.Point(256, 190)
        Me.chkKaryawan.Name = "chkKaryawan"
        Me.chkKaryawan.Size = New System.Drawing.Size(88, 17)
        Me.chkKaryawan.TabIndex = 854
        Me.chkKaryawan.Text = "KARYAWAN"
        Me.chkKaryawan.UseVisualStyleBackColor = True
        '
        'txtPulang
        '
        Me.txtPulang.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtPulang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtPulang.Location = New System.Drawing.Point(256, 270)
        Me.txtPulang.Name = "txtPulang"
        Me.txtPulang.Size = New System.Drawing.Size(208, 20)
        Me.txtPulang.TabIndex = 853
        '
        'txtMasuk
        '
        Me.txtMasuk.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtMasuk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtMasuk.Location = New System.Drawing.Point(256, 242)
        Me.txtMasuk.Name = "txtMasuk"
        Me.txtMasuk.Size = New System.Drawing.Size(208, 20)
        Me.txtMasuk.TabIndex = 852
        '
        'cboIM
        '
        Me.cboIM.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboIM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboIM.FormattingEnabled = True
        Me.cboIM.Location = New System.Drawing.Point(256, 211)
        Me.cboIM.Name = "cboIM"
        Me.cboIM.Size = New System.Drawing.Size(208, 21)
        Me.cboIM.TabIndex = 851
        '
        'cboJabatan
        '
        Me.cboJabatan.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboJabatan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboJabatan.FormattingEnabled = True
        Me.cboJabatan.Location = New System.Drawing.Point(256, 159)
        Me.cboJabatan.Name = "cboJabatan"
        Me.cboJabatan.Size = New System.Drawing.Size(210, 21)
        Me.cboJabatan.TabIndex = 850
        '
        'cboPancang
        '
        Me.cboPancang.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cboPancang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboPancang.FormattingEnabled = True
        Me.cboPancang.Location = New System.Drawing.Point(256, 128)
        Me.cboPancang.Name = "cboPancang"
        Me.cboPancang.Size = New System.Drawing.Size(210, 21)
        Me.cboPancang.TabIndex = 849
        '
        'txtNIK
        '
        Me.txtNIK.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtNIK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtNIK.Location = New System.Drawing.Point(256, 102)
        Me.txtNIK.Name = "txtNIK"
        Me.txtNIK.Size = New System.Drawing.Size(210, 20)
        Me.txtNIK.TabIndex = 848
        '
        'txtNama
        '
        Me.txtNama.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtNama.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtNama.Location = New System.Drawing.Point(256, 50)
        Me.txtNama.Name = "txtNama"
        Me.txtNama.Size = New System.Drawing.Size(210, 20)
        Me.txtNama.TabIndex = 847
        '
        'rdP2
        '
        Me.rdP2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.rdP2.AutoSize = True
        Me.rdP2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdP2.Location = New System.Drawing.Point(58, 13)
        Me.rdP2.Name = "rdP2"
        Me.rdP2.Size = New System.Drawing.Size(39, 20)
        Me.rdP2.TabIndex = 846
        Me.rdP2.Text = "P2"
        Me.rdP2.UseVisualStyleBackColor = True
        '
        'rdP1
        '
        Me.rdP1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.rdP1.AutoSize = True
        Me.rdP1.Checked = True
        Me.rdP1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdP1.Location = New System.Drawing.Point(12, 13)
        Me.rdP1.Name = "rdP1"
        Me.rdP1.Size = New System.Drawing.Size(39, 20)
        Me.rdP1.TabIndex = 844
        Me.rdP1.TabStop = True
        Me.rdP1.Text = "P1"
        Me.rdP1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(120, 246)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 843
        Me.Label1.Text = "JAM MASUK"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(120, 274)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 13)
        Me.Label7.TabIndex = 842
        Me.Label7.Text = "JAM PULANG"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(120, 215)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 13)
        Me.Label6.TabIndex = 841
        Me.Label6.Text = "LIBUR MINGGUAN"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(120, 192)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 13)
        Me.Label5.TabIndex = 840
        Me.Label5.Text = "STATUS"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(120, 163)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 839
        Me.Label4.Text = "JABATAN"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(120, 132)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 838
        Me.Label2.Text = "PANCANG"
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(121, 103)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(25, 13)
        Me.Label13.TabIndex = 837
        Me.Label13.Text = "NIK"
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(120, 53)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(38, 13)
        Me.Label14.TabIndex = 836
        Me.Label14.Text = "NAMA"
        '
        'btnsave
        '
        Me.btnsave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnsave.BackColor = System.Drawing.Color.AliceBlue
        Me.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsave.Font = New System.Drawing.Font("Gabriola", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsave.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.btnsave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnsave.Location = New System.Drawing.Point(589, 2)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(70, 36)
        Me.btnsave.TabIndex = 250
        Me.btnsave.Text = "&Save"
        Me.btnsave.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnsave.UseVisualStyleBackColor = False
        '
        'btnexit
        '
        Me.btnexit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnexit.BackColor = System.Drawing.Color.AliceBlue
        Me.btnexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnexit.Font = New System.Drawing.Font("Gabriola", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexit.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.btnexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnexit.Location = New System.Drawing.Point(518, 2)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(70, 36)
        Me.btnexit.TabIndex = 249
        Me.btnexit.Text = "Exit"
        Me.btnexit.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnexit.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.dttgl)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(668, 35)
        Me.Panel1.TabIndex = 881
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(410, 11)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(46, 13)
        Me.Label16.TabIndex = 868
        Me.Label16.Text = "Tanggal"
        '
        'dttgl
        '
        Me.dttgl.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.dttgl.CustomFormat = "dd/mm/yyyy"
        Me.dttgl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dttgl.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dttgl.Location = New System.Drawing.Point(465, 9)
        Me.dttgl.Name = "dttgl"
        Me.dttgl.Size = New System.Drawing.Size(98, 20)
        Me.dttgl.TabIndex = 867
        Me.dttgl.Value = New Date(2020, 2, 1, 0, 0, 0, 0)
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Gabriola", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRefresh.Location = New System.Drawing.Point(-154, 593)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(484, 34)
        Me.btnRefresh.TabIndex = 883
        Me.btnRefresh.Text = "&Refresh"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'btnAjukanAP
        '
        Me.btnAjukanAP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAjukanAP.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnAjukanAP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAjukanAP.Font = New System.Drawing.Font("Gabriola", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAjukanAP.ForeColor = System.Drawing.Color.White
        Me.btnAjukanAP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAjukanAP.Location = New System.Drawing.Point(-72, 593)
        Me.btnAjukanAP.Name = "btnAjukanAP"
        Me.btnAjukanAP.Size = New System.Drawing.Size(498, 34)
        Me.btnAjukanAP.TabIndex = 884
        Me.btnAjukanAP.Text = "&AjukanAP"
        Me.btnAjukanAP.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnAjukanAP.UseVisualStyleBackColor = False
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.FileName = "OpenFileDialog1"
        '
        'RDP3
        '
        Me.RDP3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.RDP3.AutoSize = True
        Me.RDP3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RDP3.Location = New System.Drawing.Point(156, 14)
        Me.RDP3.Name = "RDP3"
        Me.RDP3.Size = New System.Drawing.Size(39, 20)
        Me.RDP3.TabIndex = 878
        Me.RDP3.Text = "P3"
        Me.RDP3.UseVisualStyleBackColor = True
        '
        'FrmMstPersonilPancangNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(668, 592)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.btnAjukanAP)
        Me.Name = "FrmMstPersonilPancangNew"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmMstPersonilPancangNew"
        Me.GroupBox2.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Label8 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents SaveFileDialog As SaveFileDialog
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents btnsave As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnAjukanAP As Button
    Friend WithEvents OpenFileDialog2 As OpenFileDialog
    Friend WithEvents btnexit As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents DTP2 As DateTimePicker
    Friend WithEvents lblCV As Label
    Friend WithEvents lblPemborong As Label
    Friend WithEvents txtCV As TextBox
    Friend WithEvents txtPemborong As TextBox
    Friend WithEvents txtUangMakan As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtID As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents chkHarian As CheckBox
    Friend WithEvents chkKaryawan As CheckBox
    Friend WithEvents txtPulang As TextBox
    Friend WithEvents txtMasuk As TextBox
    Friend WithEvents cboIM As ComboBox
    Friend WithEvents cboJabatan As ComboBox
    Friend WithEvents cboPancang As ComboBox
    Friend WithEvents txtNIK As TextBox
    Friend WithEvents txtNama As TextBox
    Friend WithEvents rdP2 As RadioButton
    Friend WithEvents rdP1 As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txtRek As TextBox
    Friend WithEvents DTP1 As DateTimePicker
    Friend WithEvents Label16 As Label
    Friend WithEvents dttgl As DateTimePicker
    Friend WithEvents chkNotActive As CheckBox
    Friend WithEvents chktrainee As CheckBox
    Friend WithEvents txtReg As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents rdpsp As RadioButton
    Friend WithEvents ChkBni As CheckBox
    Friend WithEvents ChkMandiri As CheckBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents TxtNamaRek As TextBox
    Friend WithEvents chkNotActiveID As CheckBox
    Friend WithEvents RDP3 As RadioButton
End Class
