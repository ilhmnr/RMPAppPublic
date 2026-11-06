<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMonSupplier
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMonSupplier))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtpersen = New System.Windows.Forms.TextBox()
        Me.txtjumlahrelasi = New System.Windows.Forms.TextBox()
        Me.txtsudahupload = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkfoto1 = New System.Windows.Forms.CheckBox()
        Me.chkfoto = New System.Windows.Forms.CheckBox()
        Me.chkactive = New System.Windows.Forms.CheckBox()
        Me.chknotactive = New System.Windows.Forms.CheckBox()
        Me.chktanggal = New System.Windows.Forms.CheckBox()
        Me.cmbPancang = New System.Windows.Forms.ComboBox()
        Me.chkPancang = New System.Windows.Forms.CheckBox()
        Me.DOYear = New System.Windows.Forms.DateTimePicker()
        Me.chkyear = New System.Windows.Forms.CheckBox()
        Me.dtcb2 = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkS_Petani = New System.Windows.Forms.CheckBox()
        Me.cmbS_Petani = New System.Windows.Forms.ComboBox()
        Me.dtcb1 = New System.Windows.Forms.DateTimePicker()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.grpDataTimbangCrane = New XanderUI.XUICustomGroupbox()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.schfg = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkAPV = New System.Windows.Forms.CheckBox()
        Me.DTAP2 = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DTAP1 = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.grpDataTimbangCrane.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.AliceBlue
        Me.GroupBox2.Controls.Add(Me.SplitContainer2)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 58)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1191, 703)
        Me.GroupBox2.TabIndex = 878
        Me.GroupBox2.TabStop = False
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
        Me.SplitContainer2.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkAPV)
        Me.SplitContainer2.Panel1.Controls.Add(Me.DTAP2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer2.Panel1.Controls.Add(Me.DTAP1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkfoto1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkfoto)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkactive)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chknotactive)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chktanggal)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cmbPancang)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkPancang)
        Me.SplitContainer2.Panel1.Controls.Add(Me.DOYear)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkyear)
        Me.SplitContainer2.Panel1.Controls.Add(Me.dtcb2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkS_Petani)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cmbS_Petani)
        Me.SplitContainer2.Panel1.Controls.Add(Me.dtcb1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer1)
        Me.SplitContainer2.Size = New System.Drawing.Size(1185, 684)
        Me.SplitContainer2.SplitterDistance = 95
        Me.SplitContainer2.TabIndex = 75
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtpersen)
        Me.GroupBox1.Controls.Add(Me.txtjumlahrelasi)
        Me.GroupBox1.Controls.Add(Me.txtsudahupload)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.GroupBox1.Location = New System.Drawing.Point(712, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(262, 73)
        Me.GroupBox1.TabIndex = 254
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Persentase Foto Petani"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(235, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(15, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "%"
        '
        'txtpersen
        '
        Me.txtpersen.Location = New System.Drawing.Point(184, 30)
        Me.txtpersen.Name = "txtpersen"
        Me.txtpersen.Size = New System.Drawing.Size(47, 20)
        Me.txtpersen.TabIndex = 4
        '
        'txtjumlahrelasi
        '
        Me.txtjumlahrelasi.Location = New System.Drawing.Point(125, 42)
        Me.txtjumlahrelasi.Name = "txtjumlahrelasi"
        Me.txtjumlahrelasi.Size = New System.Drawing.Size(50, 20)
        Me.txtjumlahrelasi.TabIndex = 3
        '
        'txtsudahupload
        '
        Me.txtsudahupload.AcceptsReturn = True
        Me.txtsudahupload.Location = New System.Drawing.Point(125, 20)
        Me.txtsudahupload.Name = "txtsudahupload"
        Me.txtsudahupload.Size = New System.Drawing.Size(50, 20)
        Me.txtsudahupload.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(5, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Jumlah Petani"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(6, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Foto Sdh Upload"
        '
        'chkfoto1
        '
        Me.chkfoto1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkfoto1.AutoSize = True
        Me.chkfoto1.BackColor = System.Drawing.Color.Transparent
        Me.chkfoto1.FlatAppearance.BorderSize = 0
        Me.chkfoto1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkfoto1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkfoto1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.chkfoto1.Location = New System.Drawing.Point(1020, 37)
        Me.chkfoto1.Name = "chkfoto1"
        Me.chkfoto1.Size = New System.Drawing.Size(154, 21)
        Me.chkfoto1.TabIndex = 253
        Me.chkfoto1.Text = "Foto Petani Uploaded"
        Me.chkfoto1.UseVisualStyleBackColor = False
        '
        'chkfoto
        '
        Me.chkfoto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkfoto.AutoSize = True
        Me.chkfoto.BackColor = System.Drawing.Color.Transparent
        Me.chkfoto.FlatAppearance.BorderSize = 0
        Me.chkfoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkfoto.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkfoto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.chkfoto.Location = New System.Drawing.Point(1020, 14)
        Me.chkfoto.Name = "chkfoto"
        Me.chkfoto.Size = New System.Drawing.Size(156, 21)
        Me.chkfoto.TabIndex = 252
        Me.chkfoto.Text = "Foto Petani Approved"
        Me.chkfoto.UseVisualStyleBackColor = False
        '
        'chkactive
        '
        Me.chkactive.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkactive.AutoSize = True
        Me.chkactive.BackColor = System.Drawing.Color.Transparent
        Me.chkactive.FlatAppearance.BorderSize = 0
        Me.chkactive.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkactive.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkactive.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.chkactive.Location = New System.Drawing.Point(1020, 62)
        Me.chkactive.Name = "chkactive"
        Me.chkactive.Size = New System.Drawing.Size(65, 21)
        Me.chkactive.TabIndex = 251
        Me.chkactive.Text = "Active"
        Me.chkactive.UseVisualStyleBackColor = False
        '
        'chknotactive
        '
        Me.chknotactive.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chknotactive.AutoSize = True
        Me.chknotactive.FlatAppearance.BorderSize = 0
        Me.chknotactive.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chknotactive.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chknotactive.ForeColor = System.Drawing.Color.Red
        Me.chknotactive.Location = New System.Drawing.Point(1091, 62)
        Me.chknotactive.Name = "chknotactive"
        Me.chknotactive.Size = New System.Drawing.Size(78, 21)
        Me.chknotactive.TabIndex = 250
        Me.chknotactive.Text = "In Active"
        Me.chknotactive.UseVisualStyleBackColor = True
        '
        'chktanggal
        '
        Me.chktanggal.AutoSize = True
        Me.chktanggal.FlatAppearance.BorderSize = 0
        Me.chktanggal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chktanggal.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chktanggal.Location = New System.Drawing.Point(6, 10)
        Me.chktanggal.Name = "chktanggal"
        Me.chktanggal.Size = New System.Drawing.Size(71, 21)
        Me.chktanggal.TabIndex = 249
        Me.chktanggal.Text = "Tanggal"
        Me.chktanggal.UseVisualStyleBackColor = True
        '
        'cmbPancang
        '
        Me.cmbPancang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cmbPancang.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbPancang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPancang.FormattingEnabled = True
        Me.cmbPancang.IntegralHeight = False
        Me.cmbPancang.Location = New System.Drawing.Point(443, 9)
        Me.cmbPancang.Name = "cmbPancang"
        Me.cmbPancang.Size = New System.Drawing.Size(188, 24)
        Me.cmbPancang.TabIndex = 248
        '
        'chkPancang
        '
        Me.chkPancang.AutoSize = True
        Me.chkPancang.FlatAppearance.BorderSize = 0
        Me.chkPancang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkPancang.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.chkPancang.Location = New System.Drawing.Point(343, 9)
        Me.chkPancang.Name = "chkPancang"
        Me.chkPancang.Size = New System.Drawing.Size(77, 21)
        Me.chkPancang.TabIndex = 247
        Me.chkPancang.Text = "Pancang"
        Me.chkPancang.UseVisualStyleBackColor = True
        '
        'DOYear
        '
        Me.DOYear.CustomFormat = "yyyy"
        Me.DOYear.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DOYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DOYear.Location = New System.Drawing.Point(113, 60)
        Me.DOYear.Name = "DOYear"
        Me.DOYear.Size = New System.Drawing.Size(66, 23)
        Me.DOYear.TabIndex = 246
        Me.DOYear.Value = New Date(2022, 1, 1, 0, 0, 0, 0)
        '
        'chkyear
        '
        Me.chkyear.AutoSize = True
        Me.chkyear.FlatAppearance.BorderSize = 0
        Me.chkyear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkyear.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkyear.Location = New System.Drawing.Point(7, 60)
        Me.chkyear.Name = "chkyear"
        Me.chkyear.Size = New System.Drawing.Size(51, 21)
        Me.chkyear.TabIndex = 245
        Me.chkyear.Text = "Year"
        Me.chkyear.UseVisualStyleBackColor = True
        '
        'dtcb2
        '
        Me.dtcb2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtcb2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtcb2.Location = New System.Drawing.Point(230, 11)
        Me.dtcb2.Name = "dtcb2"
        Me.dtcb2.Size = New System.Drawing.Size(96, 20)
        Me.dtcb2.TabIndex = 244
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(208, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(21, 17)
        Me.Label5.TabIndex = 243
        Me.Label5.Text = "to"
        '
        'chkS_Petani
        '
        Me.chkS_Petani.AutoSize = True
        Me.chkS_Petani.FlatAppearance.BorderSize = 0
        Me.chkS_Petani.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkS_Petani.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkS_Petani.Location = New System.Drawing.Point(343, 38)
        Me.chkS_Petani.Name = "chkS_Petani"
        Me.chkS_Petani.Size = New System.Drawing.Size(58, 21)
        Me.chkS_Petani.TabIndex = 242
        Me.chkS_Petani.Text = "Relasi"
        Me.chkS_Petani.UseVisualStyleBackColor = True
        '
        'cmbS_Petani
        '
        Me.cmbS_Petani.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cmbS_Petani.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbS_Petani.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbS_Petani.FormattingEnabled = True
        Me.cmbS_Petani.IntegralHeight = False
        Me.cmbS_Petani.Location = New System.Drawing.Point(443, 37)
        Me.cmbS_Petani.Name = "cmbS_Petani"
        Me.cmbS_Petani.Size = New System.Drawing.Size(188, 24)
        Me.cmbS_Petani.TabIndex = 241
        '
        'dtcb1
        '
        Me.dtcb1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtcb1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtcb1.Location = New System.Drawing.Point(113, 11)
        Me.dtcb1.Name = "dtcb1"
        Me.dtcb1.Size = New System.Drawing.Size(92, 20)
        Me.dtcb1.TabIndex = 240
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpDataTimbangCrane)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnExcel)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnRefresh)
        Me.SplitContainer1.Size = New System.Drawing.Size(1185, 585)
        Me.SplitContainer1.SplitterDistance = 537
        Me.SplitContainer1.TabIndex = 878
        '
        'grpDataTimbangCrane
        '
        Me.grpDataTimbangCrane.BackColor = System.Drawing.Color.AliceBlue
        Me.grpDataTimbangCrane.BorderColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grpDataTimbangCrane.BorderWidth = 1
        Me.grpDataTimbangCrane.Controls.Add(Me.fg)
        Me.grpDataTimbangCrane.Controls.Add(Me.schfg)
        Me.grpDataTimbangCrane.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDataTimbangCrane.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDataTimbangCrane.Location = New System.Drawing.Point(0, 0)
        Me.grpDataTimbangCrane.Name = "grpDataTimbangCrane"
        Me.grpDataTimbangCrane.ShowText = True
        Me.grpDataTimbangCrane.Size = New System.Drawing.Size(1185, 537)
        Me.grpDataTimbangCrane.TabIndex = 877
        Me.grpDataTimbangCrane.TabStop = False
        Me.grpDataTimbangCrane.Text = "Relasi"
        Me.grpDataTimbangCrane.TextColor = System.Drawing.Color.Navy
        '
        'fg
        '
        Me.fg.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.fg.AllowEditing = False
        Me.fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.fg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fg.BackColor = System.Drawing.Color.White
        Me.fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fg.ColumnInfo = resources.GetString("fg.ColumnInfo")
        Me.fg.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fg.ForeColor = System.Drawing.Color.Black
        Me.fg.Location = New System.Drawing.Point(9, 22)
        Me.fg.Name = "fg"
        Me.fg.Rows.Count = 10
        Me.fg.Rows.DefaultSize = 22
        Me.fg.Size = New System.Drawing.Size(1167, 509)
        Me.fg.StyleInfo = resources.GetString("fg.StyleInfo")
        Me.fg.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.fg.TabIndex = 427
        '
        'schfg
        '
        Me.schfg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.schfg.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.schfg.Location = New System.Drawing.Point(1004, -12)
        Me.schfg.Margin = New System.Windows.Forms.Padding(1)
        Me.schfg.Name = "schfg"
        Me.schfg.ShowClearButton = False
        Me.schfg.ShowSearchButton = False
        Me.schfg.Size = New System.Drawing.Size(208, 37)
        Me.schfg.TabIndex = 194
        '
        'btnExcel
        '
        Me.btnExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExcel.BackColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExcel.FlatAppearance.BorderSize = 0
        Me.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcel.Font = New System.Drawing.Font("Gabriola", 11.25!, System.Drawing.FontStyle.Bold)
        Me.btnExcel.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnExcel.Location = New System.Drawing.Point(1015, 3)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(86, 34)
        Me.btnExcel.TabIndex = 877
        Me.btnExcel.Text = "Excel"
        Me.btnExcel.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Gabriola", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRefresh.Location = New System.Drawing.Point(1107, 3)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 34)
        Me.btnRefresh.TabIndex = 873
        Me.btnRefresh.Text = "&Refresh"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(97, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 15)
        Me.Label3.TabIndex = 876
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.RMPApp.My.Resources.Resources.download__7_
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(74, 52)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label8.Font = New System.Drawing.Font("Bahnschrift", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(3, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(1099, 33)
        Me.Label8.TabIndex = 856
        Me.Label8.Text = "Monitoring Relasi"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label8, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(83, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1105, 52)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 47)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1099, 2)
        Me.Panel2.TabIndex = 857
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.752137!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 93.24786!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PictureBox1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1191, 58)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1191, 58)
        Me.Panel1.TabIndex = 877
        '
        'chkAPV
        '
        Me.chkAPV.AutoSize = True
        Me.chkAPV.FlatAppearance.BorderSize = 0
        Me.chkAPV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkAPV.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAPV.Location = New System.Drawing.Point(7, 35)
        Me.chkAPV.Name = "chkAPV"
        Me.chkAPV.Size = New System.Drawing.Size(104, 21)
        Me.chkAPV.TabIndex = 258
        Me.chkAPV.Text = "Tgl.Approved"
        Me.chkAPV.UseVisualStyleBackColor = True
        '
        'DTAP2
        '
        Me.DTAP2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTAP2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTAP2.Location = New System.Drawing.Point(230, 36)
        Me.DTAP2.Name = "DTAP2"
        Me.DTAP2.Size = New System.Drawing.Size(96, 20)
        Me.DTAP2.TabIndex = 257
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(208, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(21, 17)
        Me.Label6.TabIndex = 256
        Me.Label6.Text = "to"
        '
        'DTAP1
        '
        Me.DTAP1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTAP1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTAP1.Location = New System.Drawing.Point(113, 36)
        Me.DTAP1.Name = "DTAP1"
        Me.DTAP1.Size = New System.Drawing.Size(92, 20)
        Me.DTAP1.TabIndex = 255
        '
        'FrmMonSupplier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1191, 761)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmMonSupplier"
        Me.Text = "FrmMonSupplier"
        Me.GroupBox2.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.grpDataTimbangCrane.ResumeLayout(False)
        Me.grpDataTimbangCrane.PerformLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents dtcb2 As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents chkS_Petani As CheckBox
    Friend WithEvents cmbS_Petani As ComboBox
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents grpDataTimbangCrane As XanderUI.XUICustomGroupbox
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents schfg As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents btnExcel As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents SaveFileDialog As SaveFileDialog
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents chkyear As CheckBox
    Friend WithEvents dtcb1 As DateTimePicker
    Friend WithEvents DOYear As DateTimePicker
    Friend WithEvents cmbPancang As ComboBox
    Friend WithEvents chkPancang As CheckBox
    Friend WithEvents chktanggal As CheckBox
    Friend WithEvents chknotactive As CheckBox
    Friend WithEvents chkactive As CheckBox
    Friend WithEvents chkfoto As CheckBox
    Friend WithEvents chkfoto1 As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtpersen As TextBox
    Friend WithEvents txtjumlahrelasi As TextBox
    Friend WithEvents txtsudahupload As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents chkAPV As CheckBox
    Friend WithEvents DTAP2 As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents DTAP1 As DateTimePicker
End Class
