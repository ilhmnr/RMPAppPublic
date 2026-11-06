<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTrnPergeseranPancang
    Inherits System.Windows.Forms.Form

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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.dttgl = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.ChkBni = New System.Windows.Forms.CheckBox()
        Me.ChkMandiri = New System.Windows.Forms.CheckBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtReg = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.btnexit = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TxtNamaRek = New System.Windows.Forms.TextBox()
        Me.txtRek = New System.Windows.Forms.TextBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.lblCV = New System.Windows.Forms.Label()
        Me.txtCV = New System.Windows.Forms.TextBox()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.chkAllPancang = New System.Windows.Forms.CheckBox()
        Me.txtlong2 = New System.Windows.Forms.TextBox()
        Me.txtlong1 = New System.Windows.Forms.TextBox()
        Me.txtlatd2 = New System.Windows.Forms.TextBox()
        Me.txtlatd1 = New System.Windows.Forms.TextBox()
        Me.txtidpancang = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtKet = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtjarak = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtnamapancang = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboPancang = New System.Windows.Forms.ComboBox()
        Me.txtNIK = New System.Windows.Forms.TextBox()
        Me.txtNama = New System.Windows.Forms.TextBox()
        Me.rdP2 = New System.Windows.Forms.RadioButton()
        Me.rdP1 = New System.Windows.Forms.RadioButton()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.btnAjukanAP = New System.Windows.Forms.Button()
        Me.rdp3 = New System.Windows.Forms.RadioButton()
        Me.rdPSP = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(530, 35)
        Me.Panel1.TabIndex = 882
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(356, 11)
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
        Me.dttgl.Location = New System.Drawing.Point(411, 9)
        Me.dttgl.Name = "dttgl"
        Me.dttgl.Size = New System.Drawing.Size(98, 20)
        Me.dttgl.TabIndex = 867
        Me.dttgl.Value = New Date(2020, 2, 1, 0, 0, 0, 0)
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(3, 6)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(164, 18)
        Me.Label8.TabIndex = 828
        Me.Label8.Text = "Pergeseran Pancang"
        '
        'btnsave
        '
        Me.btnsave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnsave.BackColor = System.Drawing.Color.AliceBlue
        Me.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsave.Font = New System.Drawing.Font("Gabriola", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsave.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.btnsave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnsave.Location = New System.Drawing.Point(447, 7)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(70, 36)
        Me.btnsave.TabIndex = 250
        Me.btnsave.Text = "&Save"
        Me.btnsave.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnsave.UseVisualStyleBackColor = False
        '
        'ChkBni
        '
        Me.ChkBni.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ChkBni.AutoSize = True
        Me.ChkBni.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ChkBni.Location = New System.Drawing.Point(267, 465)
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
        Me.ChkMandiri.Location = New System.Drawing.Point(189, 465)
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
        Me.Label17.Location = New System.Drawing.Point(54, 467)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(70, 13)
        Me.Label17.TabIndex = 875
        Me.Label17.Text = "NAMA BANK"
        '
        'txtReg
        '
        Me.txtReg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtReg.Location = New System.Drawing.Point(91, 95)
        Me.txtReg.Name = "txtReg"
        Me.txtReg.ReadOnly = True
        Me.txtReg.Size = New System.Drawing.Size(273, 20)
        Me.txtReg.TabIndex = 873
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(18, 98)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 13)
        Me.Label11.TabIndex = 872
        Me.Label11.Text = "REG/FIXNO"
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.FileName = "OpenFileDialog1"
        '
        'btnexit
        '
        Me.btnexit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnexit.BackColor = System.Drawing.Color.AliceBlue
        Me.btnexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnexit.Font = New System.Drawing.Font("Gabriola", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexit.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.btnexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnexit.Location = New System.Drawing.Point(376, 7)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(70, 36)
        Me.btnexit.TabIndex = 249
        Me.btnexit.Text = "Exit"
        Me.btnexit.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnexit.UseVisualStyleBackColor = False
        '
        'Label18
        '
        Me.Label18.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(54, 413)
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
        Me.Label15.Location = New System.Drawing.Point(54, 439)
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
        Me.TxtNamaRek.Location = New System.Drawing.Point(189, 412)
        Me.TxtNamaRek.Name = "TxtNamaRek"
        Me.TxtNamaRek.Size = New System.Drawing.Size(210, 20)
        Me.TxtNamaRek.TabIndex = 868
        '
        'txtRek
        '
        Me.txtRek.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtRek.BackColor = System.Drawing.SystemColors.Window
        Me.txtRek.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtRek.Location = New System.Drawing.Point(189, 438)
        Me.txtRek.Name = "txtRek"
        Me.txtRek.Size = New System.Drawing.Size(210, 20)
        Me.txtRek.TabIndex = 868
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Gabriola", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRefresh.Location = New System.Drawing.Point(-416, 493)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(484, 34)
        Me.btnRefresh.TabIndex = 888
        Me.btnRefresh.Text = "&Refresh"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'lblCV
        '
        Me.lblCV.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblCV.AutoSize = True
        Me.lblCV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCV.Location = New System.Drawing.Point(54, 390)
        Me.lblCV.Name = "lblCV"
        Me.lblCV.Size = New System.Drawing.Size(21, 13)
        Me.lblCV.TabIndex = 863
        Me.lblCV.Text = "CV"
        '
        'txtCV
        '
        Me.txtCV.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtCV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCV.Location = New System.Drawing.Point(189, 386)
        Me.txtCV.Name = "txtCV"
        Me.txtCV.Size = New System.Drawing.Size(210, 20)
        Me.txtCV.TabIndex = 861
        '
        'txtID
        '
        Me.txtID.BackColor = System.Drawing.SystemColors.Info
        Me.txtID.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtID.Location = New System.Drawing.Point(91, 40)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(144, 23)
        Me.txtID.TabIndex = 857
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.SplitContainer2)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 35)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(530, 403)
        Me.GroupBox2.TabIndex = 887
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Personil"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BackColor = System.Drawing.Color.White
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 16)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkAllPancang)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtlong2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtlong1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtlatd2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtlatd1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtidpancang)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtKet)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtjarak)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtnamapancang)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.ChkBni)
        Me.SplitContainer2.Panel1.Controls.Add(Me.ChkMandiri)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label17)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtReg)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label11)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label18)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label15)
        Me.SplitContainer2.Panel1.Controls.Add(Me.TxtNamaRek)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtRek)
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblCV)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtCV)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtID)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cboPancang)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtNIK)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtNama)
        Me.SplitContainer2.Panel1.Controls.Add(Me.rdPSP)
        Me.SplitContainer2.Panel1.Controls.Add(Me.rdp3)
        Me.SplitContainer2.Panel1.Controls.Add(Me.rdP2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.rdP1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label13)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label14)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label19)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.BackColor = System.Drawing.Color.White
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnsave)
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnexit)
        Me.SplitContainer2.Size = New System.Drawing.Size(524, 384)
        Me.SplitContainer2.SplitterDistance = 330
        Me.SplitContainer2.TabIndex = 75
        '
        'chkAllPancang
        '
        Me.chkAllPancang.AutoSize = True
        Me.chkAllPancang.Location = New System.Drawing.Point(89, 199)
        Me.chkAllPancang.Name = "chkAllPancang"
        Me.chkAllPancang.Size = New System.Drawing.Size(230, 17)
        Me.chkAllPancang.TabIndex = 887
        Me.chkAllPancang.Text = "Cheklist Untuk Nampilkan Semua Pancang"
        Me.chkAllPancang.UseVisualStyleBackColor = True
        '
        'txtlong2
        '
        Me.txtlong2.Location = New System.Drawing.Point(443, 175)
        Me.txtlong2.Name = "txtlong2"
        Me.txtlong2.ReadOnly = True
        Me.txtlong2.Size = New System.Drawing.Size(59, 20)
        Me.txtlong2.TabIndex = 886
        '
        'txtlong1
        '
        Me.txtlong1.Location = New System.Drawing.Point(443, 148)
        Me.txtlong1.Name = "txtlong1"
        Me.txtlong1.ReadOnly = True
        Me.txtlong1.Size = New System.Drawing.Size(59, 20)
        Me.txtlong1.TabIndex = 885
        '
        'txtlatd2
        '
        Me.txtlatd2.Location = New System.Drawing.Point(368, 175)
        Me.txtlatd2.Name = "txtlatd2"
        Me.txtlatd2.ReadOnly = True
        Me.txtlatd2.Size = New System.Drawing.Size(64, 20)
        Me.txtlatd2.TabIndex = 884
        '
        'txtlatd1
        '
        Me.txtlatd1.Location = New System.Drawing.Point(368, 148)
        Me.txtlatd1.Name = "txtlatd1"
        Me.txtlatd1.ReadOnly = True
        Me.txtlatd1.Size = New System.Drawing.Size(64, 20)
        Me.txtlatd1.TabIndex = 883
        '
        'txtidpancang
        '
        Me.txtidpancang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtidpancang.Location = New System.Drawing.Point(54, 146)
        Me.txtidpancang.Name = "txtidpancang"
        Me.txtidpancang.ReadOnly = True
        Me.txtidpancang.Size = New System.Drawing.Size(31, 20)
        Me.txtidpancang.TabIndex = 882
        Me.txtidpancang.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(208, 225)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 13)
        Me.Label3.TabIndex = 881
        Me.Label3.Text = "Km"
        '
        'txtKet
        '
        Me.txtKet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtKet.Location = New System.Drawing.Point(91, 248)
        Me.txtKet.Multiline = True
        Me.txtKet.Name = "txtKet"
        Me.txtKet.Size = New System.Drawing.Size(273, 72)
        Me.txtKet.TabIndex = 880
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 251)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 879
        Me.Label4.Text = "Keterangan"
        '
        'txtjarak
        '
        Me.txtjarak.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtjarak.Location = New System.Drawing.Point(91, 222)
        Me.txtjarak.Name = "txtjarak"
        Me.txtjarak.ReadOnly = True
        Me.txtjarak.Size = New System.Drawing.Size(113, 20)
        Me.txtjarak.TabIndex = 880
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 225)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 879
        Me.Label2.Text = "Jarak"
        '
        'txtnamapancang
        '
        Me.txtnamapancang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtnamapancang.Location = New System.Drawing.Point(91, 146)
        Me.txtnamapancang.Name = "txtnamapancang"
        Me.txtnamapancang.ReadOnly = True
        Me.txtnamapancang.Size = New System.Drawing.Size(273, 20)
        Me.txtnamapancang.TabIndex = 878
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 151)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 877
        Me.Label1.Text = "Pancang"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Maroon
        Me.Label9.Location = New System.Drawing.Point(19, 45)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(18, 13)
        Me.Label9.TabIndex = 856
        Me.Label9.Text = "ID"
        '
        'cboPancang
        '
        Me.cboPancang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboPancang.FormattingEnabled = True
        Me.cboPancang.Location = New System.Drawing.Point(91, 172)
        Me.cboPancang.Name = "cboPancang"
        Me.cboPancang.Size = New System.Drawing.Size(273, 21)
        Me.cboPancang.TabIndex = 849
        '
        'txtNIK
        '
        Me.txtNIK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtNIK.Location = New System.Drawing.Point(91, 121)
        Me.txtNIK.Name = "txtNIK"
        Me.txtNIK.ReadOnly = True
        Me.txtNIK.Size = New System.Drawing.Size(273, 20)
        Me.txtNIK.TabIndex = 848
        '
        'txtNama
        '
        Me.txtNama.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtNama.Location = New System.Drawing.Point(91, 69)
        Me.txtNama.Name = "txtNama"
        Me.txtNama.ReadOnly = True
        Me.txtNama.Size = New System.Drawing.Size(273, 20)
        Me.txtNama.TabIndex = 847
        '
        'rdP2
        '
        Me.rdP2.AutoSize = True
        Me.rdP2.Enabled = False
        Me.rdP2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdP2.Location = New System.Drawing.Point(68, 15)
        Me.rdP2.Name = "rdP2"
        Me.rdP2.Size = New System.Drawing.Size(39, 20)
        Me.rdP2.TabIndex = 846
        Me.rdP2.Text = "P2"
        Me.rdP2.UseVisualStyleBackColor = True
        '
        'rdP1
        '
        Me.rdP1.AutoSize = True
        Me.rdP1.Checked = True
        Me.rdP1.Enabled = False
        Me.rdP1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdP1.Location = New System.Drawing.Point(22, 15)
        Me.rdP1.Name = "rdP1"
        Me.rdP1.Size = New System.Drawing.Size(39, 20)
        Me.rdP1.TabIndex = 844
        Me.rdP1.Text = "P1"
        Me.rdP1.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(18, 175)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 13)
        Me.Label13.TabIndex = 838
        Me.Label13.Text = "Pancang"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(18, 124)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(25, 13)
        Me.Label14.TabIndex = 837
        Me.Label14.Text = "NIK"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(18, 72)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(38, 13)
        Me.Label19.TabIndex = 836
        Me.Label19.Text = "NAMA"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(244, -89)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(0, 15)
        Me.Label20.TabIndex = 885
        '
        'btnAjukanAP
        '
        Me.btnAjukanAP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAjukanAP.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnAjukanAP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAjukanAP.Font = New System.Drawing.Font("Gabriola", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAjukanAP.ForeColor = System.Drawing.Color.White
        Me.btnAjukanAP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAjukanAP.Location = New System.Drawing.Point(-334, 493)
        Me.btnAjukanAP.Name = "btnAjukanAP"
        Me.btnAjukanAP.Size = New System.Drawing.Size(498, 34)
        Me.btnAjukanAP.TabIndex = 889
        Me.btnAjukanAP.Text = "&AjukanAP"
        Me.btnAjukanAP.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnAjukanAP.UseVisualStyleBackColor = False
        '
        'rdp3
        '
        Me.rdp3.AutoSize = True
        Me.rdp3.Enabled = False
        Me.rdp3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdp3.Location = New System.Drawing.Point(113, 15)
        Me.rdp3.Name = "rdp3"
        Me.rdp3.Size = New System.Drawing.Size(39, 20)
        Me.rdp3.TabIndex = 844
        Me.rdp3.Text = "P3"
        Me.rdp3.UseVisualStyleBackColor = True
        '
        'rdPSP
        '
        Me.rdPSP.AutoSize = True
        Me.rdPSP.Enabled = False
        Me.rdPSP.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdPSP.Location = New System.Drawing.Point(159, 15)
        Me.rdPSP.Name = "rdPSP"
        Me.rdPSP.Size = New System.Drawing.Size(46, 20)
        Me.rdPSP.TabIndex = 846
        Me.rdPSP.Text = "PSP"
        Me.rdPSP.UseVisualStyleBackColor = True
        '
        'FrmTrnPergeseranPancang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 438)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.btnAjukanAP)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmTrnPergeseranPancang"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmTrnPergeseranPancang"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label16 As Label
    Friend WithEvents dttgl As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents btnsave As Button
    Friend WithEvents ChkBni As CheckBox
    Friend WithEvents ChkMandiri As CheckBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtReg As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents OpenFileDialog2 As OpenFileDialog
    Friend WithEvents btnexit As Button
    Friend WithEvents Label18 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents TxtNamaRek As TextBox
    Friend WithEvents txtRek As TextBox
    Friend WithEvents btnRefresh As Button
    Friend WithEvents lblCV As Label
    Friend WithEvents txtCV As TextBox
    Friend WithEvents txtID As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents Label9 As Label
    Friend WithEvents cboPancang As ComboBox
    Friend WithEvents txtNIK As TextBox
    Friend WithEvents txtNama As TextBox
    Friend WithEvents rdP2 As RadioButton
    Friend WithEvents rdP1 As RadioButton
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Label20 As Label
    Friend WithEvents SaveFileDialog As SaveFileDialog
    Friend WithEvents btnAjukanAP As Button
    Friend WithEvents txtnamapancang As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtjarak As TextBox
    Friend WithEvents txtidpancang As TextBox
    Friend WithEvents txtlong2 As TextBox
    Friend WithEvents txtlong1 As TextBox
    Friend WithEvents txtlatd2 As TextBox
    Friend WithEvents txtlatd1 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtKet As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents chkAllPancang As CheckBox
    Friend WithEvents rdPSP As RadioButton
    Friend WithEvents rdp3 As RadioButton
End Class
