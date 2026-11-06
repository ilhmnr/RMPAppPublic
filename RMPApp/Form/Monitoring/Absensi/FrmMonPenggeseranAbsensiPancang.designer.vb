<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMonPenggeseranAbsensiPancang
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMonPenggeseranAbsensiPancang))
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlHead = New System.Windows.Forms.Panel()
        Me.lblHead = New System.Windows.Forms.Label()
        Me.chkAktif = New System.Windows.Forms.RadioButton()
        Me.chkAll = New System.Windows.Forms.RadioButton()
        Me.cbojabatan = New System.Windows.Forms.ComboBox()
        Me.chkJabatan = New System.Windows.Forms.CheckBox()
        Me.chkIDPersonil = New System.Windows.Forms.CheckBox()
        Me.txtIdPersonil = New System.Windows.Forms.TextBox()
        Me.chkNamaPersonil = New System.Windows.Forms.CheckBox()
        Me.chkPancang = New System.Windows.Forms.CheckBox()
        Me.cboPancang = New System.Windows.Forms.ComboBox()
        Me.txtNamapersonil = New System.Windows.Forms.TextBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.dgvlist = New System.Windows.Forms.DataGridView()
        Me.No = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tanggal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDPancang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pancang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pengawas1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pengawas2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MasaKerja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.fgpersonil = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.dgvlist1 = New System.Windows.Forms.DataGridView()
        Me.No1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDPersonil1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nama1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nik1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pancang2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Jabatan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.SaveFileDialog2 = New System.Windows.Forms.SaveFileDialog()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvlist, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.fgpersonil, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvlist1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.SystemColors.HighlightText
        Me.SplitContainer1.Panel1.Controls.Add(Me.PictureBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlHead)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblHead)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.SplitContainer1.Panel2.Controls.Add(Me.chkAktif)
        Me.SplitContainer1.Panel2.Controls.Add(Me.chkAll)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cbojabatan)
        Me.SplitContainer1.Panel2.Controls.Add(Me.chkJabatan)
        Me.SplitContainer1.Panel2.Controls.Add(Me.chkIDPersonil)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtIdPersonil)
        Me.SplitContainer1.Panel2.Controls.Add(Me.chkNamaPersonil)
        Me.SplitContainer1.Panel2.Controls.Add(Me.chkPancang)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cboPancang)
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtNamapersonil)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnRefresh)
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1065, 643)
        Me.SplitContainer1.SplitterDistance = 73
        Me.SplitContainer1.TabIndex = 9
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.RMPApp.My.Resources.Resources.information
        Me.PictureBox1.Location = New System.Drawing.Point(19, 7)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(85, 64)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 905611
        Me.PictureBox1.TabStop = False
        '
        'pnlHead
        '
        Me.pnlHead.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlHead.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.pnlHead.Location = New System.Drawing.Point(15, 73)
        Me.pnlHead.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlHead.Name = "pnlHead"
        Me.pnlHead.Size = New System.Drawing.Size(1029, 1)
        Me.pnlHead.TabIndex = 905610
        '
        'lblHead
        '
        Me.lblHead.AutoSize = True
        Me.lblHead.BackColor = System.Drawing.Color.Transparent
        Me.lblHead.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblHead.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHead.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.lblHead.Location = New System.Drawing.Point(109, 22)
        Me.lblHead.Name = "lblHead"
        Me.lblHead.Size = New System.Drawing.Size(393, 28)
        Me.lblHead.TabIndex = 905609
        Me.lblHead.Text = "Monitoring Penggeseran Absensi"
        '
        'chkAktif
        '
        Me.chkAktif.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkAktif.AutoSize = True
        Me.chkAktif.Checked = True
        Me.chkAktif.Location = New System.Drawing.Point(1001, 20)
        Me.chkAktif.Name = "chkAktif"
        Me.chkAktif.Size = New System.Drawing.Size(46, 17)
        Me.chkAktif.TabIndex = 342
        Me.chkAktif.TabStop = True
        Me.chkAktif.Text = "Aktif"
        Me.chkAktif.UseVisualStyleBackColor = True
        '
        'chkAll
        '
        Me.chkAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkAll.AutoSize = True
        Me.chkAll.Location = New System.Drawing.Point(959, 20)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(36, 17)
        Me.chkAll.TabIndex = 343
        Me.chkAll.Text = "All"
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'cbojabatan
        '
        Me.cbojabatan.BackColor = System.Drawing.Color.White
        Me.cbojabatan.Enabled = False
        Me.cbojabatan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbojabatan.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbojabatan.FormattingEnabled = True
        Me.cbojabatan.IntegralHeight = False
        Me.cbojabatan.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cbojabatan.Location = New System.Drawing.Point(173, 104)
        Me.cbojabatan.Name = "cbojabatan"
        Me.cbojabatan.Size = New System.Drawing.Size(224, 25)
        Me.cbojabatan.TabIndex = 339
        '
        'chkJabatan
        '
        Me.chkJabatan.AutoSize = True
        Me.chkJabatan.FlatAppearance.BorderSize = 0
        Me.chkJabatan.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkJabatan.Location = New System.Drawing.Point(19, 106)
        Me.chkJabatan.Name = "chkJabatan"
        Me.chkJabatan.Size = New System.Drawing.Size(82, 21)
        Me.chkJabatan.TabIndex = 338
        Me.chkJabatan.Text = "Jabatan"
        Me.chkJabatan.UseVisualStyleBackColor = True
        '
        'chkIDPersonil
        '
        Me.chkIDPersonil.AutoSize = True
        Me.chkIDPersonil.FlatAppearance.BorderSize = 0
        Me.chkIDPersonil.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIDPersonil.Location = New System.Drawing.Point(19, 78)
        Me.chkIDPersonil.Name = "chkIDPersonil"
        Me.chkIDPersonil.Size = New System.Drawing.Size(108, 21)
        Me.chkIDPersonil.TabIndex = 337
        Me.chkIDPersonil.Text = "ID Personil    "
        Me.chkIDPersonil.UseVisualStyleBackColor = True
        '
        'txtIdPersonil
        '
        Me.txtIdPersonil.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtIdPersonil.Enabled = False
        Me.txtIdPersonil.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdPersonil.Location = New System.Drawing.Point(173, 77)
        Me.txtIdPersonil.Multiline = True
        Me.txtIdPersonil.Name = "txtIdPersonil"
        Me.txtIdPersonil.Size = New System.Drawing.Size(224, 22)
        Me.txtIdPersonil.TabIndex = 335
        '
        'chkNamaPersonil
        '
        Me.chkNamaPersonil.AutoSize = True
        Me.chkNamaPersonil.FlatAppearance.BorderSize = 0
        Me.chkNamaPersonil.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNamaPersonil.Location = New System.Drawing.Point(19, 51)
        Me.chkNamaPersonil.Name = "chkNamaPersonil"
        Me.chkNamaPersonil.Size = New System.Drawing.Size(136, 21)
        Me.chkNamaPersonil.TabIndex = 334
        Me.chkNamaPersonil.Text = "Nama Personil    "
        Me.chkNamaPersonil.UseVisualStyleBackColor = True
        '
        'chkPancang
        '
        Me.chkPancang.AutoSize = True
        Me.chkPancang.FlatAppearance.BorderSize = 0
        Me.chkPancang.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPancang.Location = New System.Drawing.Point(20, 23)
        Me.chkPancang.Name = "chkPancang"
        Me.chkPancang.Size = New System.Drawing.Size(94, 21)
        Me.chkPancang.TabIndex = 333
        Me.chkPancang.Text = "Pancang  "
        Me.chkPancang.UseVisualStyleBackColor = True
        '
        'cboPancang
        '
        Me.cboPancang.BackColor = System.Drawing.Color.White
        Me.cboPancang.Enabled = False
        Me.cboPancang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPancang.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPancang.FormattingEnabled = True
        Me.cboPancang.IntegralHeight = False
        Me.cboPancang.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cboPancang.Location = New System.Drawing.Point(173, 20)
        Me.cboPancang.Name = "cboPancang"
        Me.cboPancang.Size = New System.Drawing.Size(224, 25)
        Me.cboPancang.TabIndex = 332
        '
        'txtNamapersonil
        '
        Me.txtNamapersonil.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNamapersonil.Enabled = False
        Me.txtNamapersonil.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNamapersonil.Location = New System.Drawing.Point(173, 50)
        Me.txtNamapersonil.Multiline = True
        Me.txtNamapersonil.Name = "txtNamapersonil"
        Me.txtNamapersonil.Size = New System.Drawing.Size(224, 22)
        Me.txtNamapersonil.TabIndex = 327
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnRefresh.BackgroundImage = CType(resources.GetObject("btnRefresh.BackgroundImage"), System.Drawing.Image)
        Me.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnRefresh.Location = New System.Drawing.Point(406, 20)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(29, 23)
        Me.btnRefresh.TabIndex = 331
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.fg)
        Me.GroupBox2.Controls.Add(Me.dgvlist)
        Me.GroupBox2.Location = New System.Drawing.Point(622, 137)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(431, 416)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button1.Image = Global.RMPApp.My.Resources.Resources.excel
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(356, 20)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(66, 30)
        Me.Button1.TabIndex = 340
        Me.Button1.Text = "Excel"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'fg
        '
        Me.fg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fg.ColumnInfo = resources.GetString("fg.ColumnInfo")
        Me.fg.Location = New System.Drawing.Point(6, 56)
        Me.fg.Name = "fg"
        Me.fg.Rows.Count = 10
        Me.fg.Size = New System.Drawing.Size(419, 338)
        Me.fg.StyleInfo = resources.GetString("fg.StyleInfo")
        Me.fg.TabIndex = 432
        '
        'dgvlist
        '
        Me.dgvlist.AllowUserToAddRows = False
        Me.dgvlist.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvlist.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvlist.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.No, Me.Tanggal, Me.IDPancang, Me.Pancang, Me.Pengawas1, Me.Pengawas2, Me.MasaKerja})
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvlist.DefaultCellStyle = DataGridViewCellStyle17
        Me.dgvlist.Location = New System.Drawing.Point(6, 192)
        Me.dgvlist.Name = "dgvlist"
        Me.dgvlist.RowHeadersVisible = False
        Me.dgvlist.Size = New System.Drawing.Size(338, 191)
        Me.dgvlist.TabIndex = 0
        '
        'No
        '
        Me.No.Frozen = True
        Me.No.HeaderText = "No"
        Me.No.Name = "No"
        Me.No.Width = 35
        '
        'Tanggal
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Tanggal.DefaultCellStyle = DataGridViewCellStyle13
        Me.Tanggal.HeaderText = "Tanggal"
        Me.Tanggal.Name = "Tanggal"
        Me.Tanggal.ReadOnly = True
        Me.Tanggal.Width = 200
        '
        'IDPancang
        '
        Me.IDPancang.HeaderText = "IDPancang"
        Me.IDPancang.Name = "IDPancang"
        Me.IDPancang.ReadOnly = True
        Me.IDPancang.Visible = False
        Me.IDPancang.Width = 30
        '
        'Pancang
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Pancang.DefaultCellStyle = DataGridViewCellStyle14
        Me.Pancang.HeaderText = "Pancang"
        Me.Pancang.Name = "Pancang"
        Me.Pancang.ReadOnly = True
        Me.Pancang.Width = 300
        '
        'Pengawas1
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Pengawas1.DefaultCellStyle = DataGridViewCellStyle15
        Me.Pengawas1.HeaderText = "Pengawas 1"
        Me.Pengawas1.Name = "Pengawas1"
        Me.Pengawas1.ReadOnly = True
        Me.Pengawas1.Width = 150
        '
        'Pengawas2
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Pengawas2.DefaultCellStyle = DataGridViewCellStyle16
        Me.Pengawas2.HeaderText = "Pengawas 2"
        Me.Pengawas2.Name = "Pengawas2"
        Me.Pengawas2.ReadOnly = True
        Me.Pengawas2.Width = 150
        '
        'MasaKerja
        '
        Me.MasaKerja.HeaderText = "Masa Kerja"
        Me.MasaKerja.Name = "MasaKerja"
        Me.MasaKerja.Width = 200
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.fgpersonil)
        Me.GroupBox1.Controls.Add(Me.dgvlist1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 137)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(610, 417)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(189, 13)
        Me.Label1.TabIndex = 436
        Me.Label1.Text = "Sudah 3 Bulan Tidak Pindah Pancang"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(6, 30)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(20, 20)
        Me.Panel1.TabIndex = 435
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button2.Image = Global.RMPApp.My.Resources.Resources.excel
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(535, 19)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(66, 30)
        Me.Button2.TabIndex = 341
        Me.Button2.Text = "Excel"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = False
        '
        'fgpersonil
        '
        Me.fgpersonil.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fgpersonil.ColumnInfo = resources.GetString("fgpersonil.ColumnInfo")
        Me.fgpersonil.Location = New System.Drawing.Point(6, 56)
        Me.fgpersonil.Name = "fgpersonil"
        Me.fgpersonil.Rows.Count = 10
        Me.fgpersonil.Size = New System.Drawing.Size(598, 355)
        Me.fgpersonil.StyleInfo = resources.GetString("fgpersonil.StyleInfo")
        Me.fgpersonil.TabIndex = 433
        '
        'dgvlist1
        '
        Me.dgvlist1.AllowUserToAddRows = False
        Me.dgvlist1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvlist1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvlist1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.No1, Me.IDPersonil1, Me.Nama1, Me.Nik1, Me.Pancang2, Me.Jabatan, Me.Status})
        Me.dgvlist1.Location = New System.Drawing.Point(6, 56)
        Me.dgvlist1.Name = "dgvlist1"
        Me.dgvlist1.RowHeadersVisible = False
        Me.dgvlist1.Size = New System.Drawing.Size(587, 355)
        Me.dgvlist1.TabIndex = 1
        '
        'No1
        '
        Me.No1.HeaderText = "No"
        Me.No1.Name = "No1"
        Me.No1.Width = 35
        '
        'IDPersonil1
        '
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IDPersonil1.DefaultCellStyle = DataGridViewCellStyle18
        Me.IDPersonil1.HeaderText = "IDPersonil"
        Me.IDPersonil1.Name = "IDPersonil1"
        Me.IDPersonil1.ReadOnly = True
        '
        'Nama1
        '
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nama1.DefaultCellStyle = DataGridViewCellStyle19
        Me.Nama1.HeaderText = "Nama"
        Me.Nama1.Name = "Nama1"
        Me.Nama1.ReadOnly = True
        Me.Nama1.Width = 160
        '
        'Nik1
        '
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nik1.DefaultCellStyle = DataGridViewCellStyle20
        Me.Nik1.HeaderText = "Nik"
        Me.Nik1.Name = "Nik1"
        Me.Nik1.ReadOnly = True
        '
        'Pancang2
        '
        Me.Pancang2.HeaderText = "Pancang"
        Me.Pancang2.Name = "Pancang2"
        Me.Pancang2.Width = 250
        '
        'Jabatan
        '
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Jabatan.DefaultCellStyle = DataGridViewCellStyle21
        Me.Jabatan.HeaderText = "Jabatan"
        Me.Jabatan.Name = "Jabatan"
        Me.Jabatan.ReadOnly = True
        '
        'Status
        '
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Status.DefaultCellStyle = DataGridViewCellStyle22
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        '
        'FrmMonPenggeseranAbsensiPancang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1065, 643)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmMonPenggeseranAbsensiPancang"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvlist, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.fgpersonil, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvlist1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dgvlist As DataGridView
    Friend WithEvents dgvlist1 As DataGridView
    Friend WithEvents txtNamapersonil As TextBox
    Friend WithEvents pnlHead As Panel
    Friend WithEvents lblHead As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnRefresh As Button
    Friend WithEvents chkNamaPersonil As CheckBox
    Friend WithEvents chkPancang As CheckBox
    Friend WithEvents cboPancang As ComboBox
    Friend WithEvents chkIDPersonil As CheckBox
    Friend WithEvents txtIdPersonil As TextBox
    Friend WithEvents chkJabatan As CheckBox
    Friend WithEvents cbojabatan As ComboBox
    Friend WithEvents No1 As DataGridViewTextBoxColumn
    Friend WithEvents IDPersonil1 As DataGridViewTextBoxColumn
    Friend WithEvents Nama1 As DataGridViewTextBoxColumn
    Friend WithEvents Nik1 As DataGridViewTextBoxColumn
    Friend WithEvents Pancang2 As DataGridViewTextBoxColumn
    Friend WithEvents Jabatan As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents No As DataGridViewTextBoxColumn
    Friend WithEvents Tanggal As DataGridViewTextBoxColumn
    Friend WithEvents IDPancang As DataGridViewTextBoxColumn
    Friend WithEvents Pancang As DataGridViewTextBoxColumn
    Friend WithEvents Pengawas1 As DataGridViewTextBoxColumn
    Friend WithEvents Pengawas2 As DataGridViewTextBoxColumn
    Friend WithEvents MasaKerja As DataGridViewTextBoxColumn
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents fgpersonil As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents SaveFileDialog2 As SaveFileDialog
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents chkAktif As RadioButton
    Friend WithEvents chkAll As RadioButton
End Class
