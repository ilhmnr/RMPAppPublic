<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMstRelasiCekDoc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMstRelasiCekDoc))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.grpDataTimbangCrane = New XanderUI.XUICustomGroupbox()
        Me.fg1 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.schfg = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.chktanggal = New System.Windows.Forms.CheckBox()
        Me.cmbPancang = New System.Windows.Forms.ComboBox()
        Me.chkPancang = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DTAP2 = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DTAP1 = New System.Windows.Forms.DateTimePicker()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.DOYear = New System.Windows.Forms.DateTimePicker()
        Me.chkyear = New System.Windows.Forms.CheckBox()
        Me.dtcb2 = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkS_Petani = New System.Windows.Forms.CheckBox()
        Me.dtcb1 = New System.Windows.Forms.DateTimePicker()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.rdbelumuploadfoto = New System.Windows.Forms.RadioButton()
        Me.rdbelumadaktp = New System.Windows.Forms.RadioButton()
        Me.chkAPV = New System.Windows.Forms.CheckBox()
        Me.cmbS_Petani = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.fg2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.grpDataTimbangCrane.SuspendLayout()
        CType(Me.fg1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.SplitContainer1.Size = New System.Drawing.Size(1158, 488)
        Me.SplitContainer1.SplitterDistance = 440
        Me.SplitContainer1.TabIndex = 878
        '
        'grpDataTimbangCrane
        '
        Me.grpDataTimbangCrane.BackColor = System.Drawing.Color.AliceBlue
        Me.grpDataTimbangCrane.BorderColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grpDataTimbangCrane.BorderWidth = 1
        Me.grpDataTimbangCrane.Controls.Add(Me.fg1)
        Me.grpDataTimbangCrane.Controls.Add(Me.fg2)
        Me.grpDataTimbangCrane.Controls.Add(Me.schfg)
        Me.grpDataTimbangCrane.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDataTimbangCrane.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDataTimbangCrane.Location = New System.Drawing.Point(0, 0)
        Me.grpDataTimbangCrane.Name = "grpDataTimbangCrane"
        Me.grpDataTimbangCrane.ShowText = True
        Me.grpDataTimbangCrane.Size = New System.Drawing.Size(1158, 440)
        Me.grpDataTimbangCrane.TabIndex = 877
        Me.grpDataTimbangCrane.TabStop = False
        Me.grpDataTimbangCrane.Text = "Relasi"
        Me.grpDataTimbangCrane.TextColor = System.Drawing.Color.Navy
        '
        'fg1
        '
        Me.fg1.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.fg1.AllowEditing = False
        Me.fg1.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.fg1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fg1.BackColor = System.Drawing.Color.White
        Me.fg1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fg1.ColumnInfo = resources.GetString("fg1.ColumnInfo")
        Me.fg1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fg1.ForeColor = System.Drawing.Color.Black
        Me.fg1.Location = New System.Drawing.Point(9, 22)
        Me.fg1.Name = "fg1"
        Me.fg1.Rows.Count = 10
        Me.fg1.Rows.DefaultSize = 22
        Me.fg1.Size = New System.Drawing.Size(1140, 412)
        Me.fg1.StyleInfo = resources.GetString("fg1.StyleInfo")
        Me.fg1.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.fg1.TabIndex = 427
        '
        'schfg
        '
        Me.schfg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.schfg.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.schfg.Location = New System.Drawing.Point(977, -12)
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
        Me.btnExcel.Location = New System.Drawing.Point(988, 3)
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
        Me.btnRefresh.Location = New System.Drawing.Point(1080, 3)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 34)
        Me.btnRefresh.TabIndex = 873
        Me.btnRefresh.Text = "&Refresh"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnRefresh.UseVisualStyleBackColor = False
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(97, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 15)
        Me.Label3.TabIndex = 879
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.RMPApp.My.Resources.Resources.download__7_
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(72, 52)
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
        Me.Label8.Size = New System.Drawing.Size(1074, 33)
        Me.Label8.TabIndex = 856
        Me.Label8.Text = "Master Relasi Document"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Panel2, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label8, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(81, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1080, 52)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 47)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1074, 2)
        Me.Panel2.TabIndex = 857
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
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1164, 58)
        Me.Panel1.TabIndex = 880
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
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1164, 58)
        Me.TableLayoutPanel1.TabIndex = 0
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
        'dtcb1
        '
        Me.dtcb1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtcb1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtcb1.Location = New System.Drawing.Point(113, 11)
        Me.dtcb1.Name = "dtcb1"
        Me.dtcb1.Size = New System.Drawing.Size(92, 20)
        Me.dtcb1.TabIndex = 240
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
        Me.SplitContainer2.Panel1.Controls.Add(Me.rdbelumuploadfoto)
        Me.SplitContainer2.Panel1.Controls.Add(Me.rdbelumadaktp)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkAPV)
        Me.SplitContainer2.Panel1.Controls.Add(Me.DTAP2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer2.Panel1.Controls.Add(Me.DTAP1)
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
        Me.SplitContainer2.Size = New System.Drawing.Size(1158, 587)
        Me.SplitContainer2.SplitterDistance = 95
        Me.SplitContainer2.TabIndex = 75
        '
        'rdbelumuploadfoto
        '
        Me.rdbelumuploadfoto.AutoSize = True
        Me.rdbelumuploadfoto.Location = New System.Drawing.Point(932, 44)
        Me.rdbelumuploadfoto.Name = "rdbelumuploadfoto"
        Me.rdbelumuploadfoto.Size = New System.Drawing.Size(181, 17)
        Me.rdbelumuploadfoto.TabIndex = 260
        Me.rdbelumuploadfoto.TabStop = True
        Me.rdbelumuploadfoto.Text = "Relasi Loyal (Belum Upload Foto)"
        Me.rdbelumuploadfoto.UseVisualStyleBackColor = True
        '
        'rdbelumadaktp
        '
        Me.rdbelumadaktp.AutoSize = True
        Me.rdbelumadaktp.Location = New System.Drawing.Point(932, 18)
        Me.rdbelumadaktp.Name = "rdbelumadaktp"
        Me.rdbelumadaktp.Size = New System.Drawing.Size(178, 17)
        Me.rdbelumadaktp.TabIndex = 259
        Me.rdbelumadaktp.TabStop = True
        Me.rdbelumadaktp.Text = "Relasi Loyal (BelumUpload KTP)"
        Me.rdbelumadaktp.UseVisualStyleBackColor = True
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
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.AliceBlue
        Me.GroupBox2.Controls.Add(Me.SplitContainer2)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 58)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1164, 606)
        Me.GroupBox2.TabIndex = 881
        Me.GroupBox2.TabStop = False
        '
        'fg2
        '
        Me.fg2.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.fg2.AllowEditing = False
        Me.fg2.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.fg2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fg2.BackColor = System.Drawing.Color.White
        Me.fg2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fg2.ColumnInfo = resources.GetString("fg2.ColumnInfo")
        Me.fg2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fg2.ForeColor = System.Drawing.Color.Black
        Me.fg2.Location = New System.Drawing.Point(12, 174)
        Me.fg2.Name = "fg2"
        Me.fg2.Rows.Count = 10
        Me.fg2.Rows.DefaultSize = 22
        Me.fg2.Size = New System.Drawing.Size(692, 263)
        Me.fg2.StyleInfo = resources.GetString("fg2.StyleInfo")
        Me.fg2.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.fg2.TabIndex = 429
        Me.fg2.Visible = False
        '
        'FrmMasterRelasiCekDoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1164, 664)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmMasterRelasiCekDoc"
        Me.Text = "FrmMasterRelasiCekDoc"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.grpDataTimbangCrane.ResumeLayout(False)
        Me.grpDataTimbangCrane.PerformLayout()
        CType(Me.fg1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.fg2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents grpDataTimbangCrane As XanderUI.XUICustomGroupbox
    Friend WithEvents fg1 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents schfg As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents btnExcel As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents chktanggal As CheckBox
    Friend WithEvents cmbPancang As ComboBox
    Friend WithEvents chkPancang As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents DTAP2 As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents DTAP1 As DateTimePicker
    Friend WithEvents SaveFileDialog As SaveFileDialog
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents DOYear As DateTimePicker
    Friend WithEvents chkyear As CheckBox
    Friend WithEvents dtcb2 As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents chkS_Petani As CheckBox
    Friend WithEvents dtcb1 As DateTimePicker
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents cmbS_Petani As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents chkAPV As CheckBox
    Friend WithEvents rdbelumuploadfoto As RadioButton
    Friend WithEvents rdbelumadaktp As RadioButton
    Friend WithEvents fg2 As C1.Win.C1FlexGrid.C1FlexGrid
End Class
