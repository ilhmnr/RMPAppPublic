<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMonPengajuanPoinNew
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMonPengajuanPoinNew))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlHead = New System.Windows.Forms.Panel()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkpancang = New System.Windows.Forms.CheckBox()
        Me.cbopancang = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.chk1 = New System.Windows.Forms.CheckBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.chk2 = New System.Windows.Forms.CheckBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.chk3 = New System.Windows.Forms.CheckBox()
        Me.chk4 = New System.Windows.Forms.CheckBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.txtSum = New System.Windows.Forms.TextBox()
        Me.schfg = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.chkS_Petani = New System.Windows.Forms.CheckBox()
        Me.cmbS_Petani = New System.Windows.Forms.ComboBox()
        Me.Dt2 = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Dt1 = New System.Windows.Forms.DateTimePicker()
        Me.chktukarpoin = New System.Windows.Forms.CheckBox()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.cboToko = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkToko = New System.Windows.Forms.CheckBox()
        Me.dtp2 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.chkTgl = New System.Windows.Forms.CheckBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.C1FlexGrid1 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.BackgroundImage = Global.RMPApp.My.Resources.Resources.Banner600pixel
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.pnlHead)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1206, 126)
        Me.GroupBox1.TabIndex = 905627
        Me.GroupBox1.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Palatino Linotype", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(138, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(144, 25)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Relasi Pancang"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Lucida Sans", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(138, 49)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(346, 27)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Monitoring Pengajuan Poin"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.RMPApp.My.Resources.Resources.prop
        Me.PictureBox1.Location = New System.Drawing.Point(6, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(126, 108)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'pnlHead
        '
        Me.pnlHead.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlHead.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.pnlHead.Location = New System.Drawing.Point(138, 112)
        Me.pnlHead.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlHead.Name = "pnlHead"
        Me.pnlHead.Size = New System.Drawing.Size(1062, 1)
        Me.pnlHead.TabIndex = 905608
        '
        'fg
        '
        Me.fg.AllowEditing = False
        Me.fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fg.ColumnInfo = "23,1,0,0,0,110,Columns:22{Style:""TextAlign:GeneralCenter;ImageAlign:CenterCenter;" &
    """;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fg.ForeColor = System.Drawing.Color.Black
        Me.fg.Location = New System.Drawing.Point(3, 17)
        Me.fg.Name = "fg"
        Me.fg.Rows.Count = 4
        Me.fg.Rows.DefaultSize = 22
        Me.fg.Size = New System.Drawing.Size(1200, 397)
        Me.fg.StyleInfo = resources.GetString("fg.StyleInfo")
        Me.fg.TabIndex = 905631
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.chkpancang)
        Me.GroupBox2.Controls.Add(Me.cbopancang)
        Me.GroupBox2.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox2.Controls.Add(Me.txtSum)
        Me.GroupBox2.Controls.Add(Me.schfg)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.chkS_Petani)
        Me.GroupBox2.Controls.Add(Me.cmbS_Petani)
        Me.GroupBox2.Controls.Add(Me.Dt2)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Dt1)
        Me.GroupBox2.Controls.Add(Me.chktukarpoin)
        Me.GroupBox2.Controls.Add(Me.lblInfo)
        Me.GroupBox2.Controls.Add(Me.btnExcel)
        Me.GroupBox2.Controls.Add(Me.btnRefresh)
        Me.GroupBox2.Controls.Add(Me.cboToko)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.chkToko)
        Me.GroupBox2.Controls.Add(Me.dtp2)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.dtp1)
        Me.GroupBox2.Controls.Add(Me.chkTgl)
        Me.GroupBox2.Controls.Add(Me.btnClose)
        Me.GroupBox2.Controls.Add(Me.Panel1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(0, 126)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1206, 162)
        Me.GroupBox2.TabIndex = 905628
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filter Data"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(135, 129)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(10, 16)
        Me.Label6.TabIndex = 905647
        Me.Label6.Text = ":"
        '
        'chkpancang
        '
        Me.chkpancang.AutoSize = True
        Me.chkpancang.FlatAppearance.BorderSize = 0
        Me.chkpancang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkpancang.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.chkpancang.Location = New System.Drawing.Point(12, 124)
        Me.chkpancang.Name = "chkpancang"
        Me.chkpancang.Size = New System.Drawing.Size(74, 20)
        Me.chkpancang.TabIndex = 905646
        Me.chkpancang.Text = "Pancang"
        Me.chkpancang.UseVisualStyleBackColor = True
        '
        'cbopancang
        '
        Me.cbopancang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cbopancang.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbopancang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbopancang.FormattingEnabled = True
        Me.cbopancang.IntegralHeight = False
        Me.cbopancang.Location = New System.Drawing.Point(152, 125)
        Me.cbopancang.Name = "cbopancang"
        Me.cbopancang.Size = New System.Drawing.Size(243, 24)
        Me.cbopancang.TabIndex = 905645
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.chk1, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox4, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.chk2, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox3, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.chk3, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.chk4, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox2, 0, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(950, 13)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(244, 89)
        Me.TableLayoutPanel1.TabIndex = 905644
        '
        'chk1
        '
        Me.chk1.AutoSize = True
        Me.chk1.Location = New System.Drawing.Point(33, 3)
        Me.chk1.Name = "chk1"
        Me.chk1.Size = New System.Drawing.Size(143, 16)
        Me.chk1.TabIndex = 905640
        Me.chk1.Text = "Belum diajukan (Toko)"
        Me.chk1.UseVisualStyleBackColor = True
        '
        'TextBox4
        '
        Me.TextBox4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.TextBox4.BackColor = System.Drawing.Color.White
        Me.TextBox4.Font = New System.Drawing.Font("Calibri", 5.25!)
        Me.TextBox4.Location = New System.Drawing.Point(3, 69)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(24, 16)
        Me.TextBox4.TabIndex = 905638
        '
        'chk2
        '
        Me.chk2.AutoSize = True
        Me.chk2.Location = New System.Drawing.Point(33, 25)
        Me.chk2.Name = "chk2"
        Me.chk2.Size = New System.Drawing.Size(147, 16)
        Me.chk2.TabIndex = 905641
        Me.chk2.Text = "Sudah Diajukan (Toko)"
        Me.chk2.UseVisualStyleBackColor = True
        '
        'TextBox3
        '
        Me.TextBox3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.TextBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox3.Font = New System.Drawing.Font("Calibri", 5.25!)
        Me.TextBox3.Location = New System.Drawing.Point(3, 25)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(24, 16)
        Me.TextBox3.TabIndex = 905636
        '
        'chk3
        '
        Me.chk3.AutoSize = True
        Me.chk3.Location = New System.Drawing.Point(33, 47)
        Me.chk3.Name = "chk3"
        Me.chk3.Size = New System.Drawing.Size(210, 16)
        Me.chk3.TabIndex = 905642
        Me.chk3.Text = "sudah diajukan (Belum Complete)"
        Me.chk3.UseVisualStyleBackColor = True
        '
        'chk4
        '
        Me.chk4.AutoSize = True
        Me.chk4.Location = New System.Drawing.Point(33, 69)
        Me.chk4.Name = "chk4"
        Me.chk4.Size = New System.Drawing.Size(80, 17)
        Me.chk4.TabIndex = 905643
        Me.chk4.Text = "Complete"
        Me.chk4.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.TextBox1.BackColor = System.Drawing.Color.Pink
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Font = New System.Drawing.Font("Calibri", 5.25!)
        Me.TextBox1.Location = New System.Drawing.Point(3, 3)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(24, 16)
        Me.TextBox1.TabIndex = 905629
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.TextBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Font = New System.Drawing.Font("Calibri", 5.25!)
        Me.TextBox2.Location = New System.Drawing.Point(3, 47)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(24, 16)
        Me.TextBox2.TabIndex = 905630
        '
        'txtSum
        '
        Me.txtSum.BackColor = System.Drawing.Color.White
        Me.txtSum.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSum.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSum.Location = New System.Drawing.Point(588, 129)
        Me.txtSum.Name = "txtSum"
        Me.txtSum.ReadOnly = True
        Me.txtSum.Size = New System.Drawing.Size(181, 15)
        Me.txtSum.TabIndex = 905621
        Me.txtSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'schfg
        '
        Me.schfg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.schfg.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.schfg.Location = New System.Drawing.Point(997, 127)
        Me.schfg.Margin = New System.Windows.Forms.Padding(1)
        Me.schfg.Name = "schfg"
        Me.schfg.ShowClearButton = False
        Me.schfg.ShowSearchButton = False
        Me.schfg.Size = New System.Drawing.Size(226, 37)
        Me.schfg.TabIndex = 905609
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(135, 103)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(10, 16)
        Me.Label10.TabIndex = 905635
        Me.Label10.Text = ":"
        '
        'chkS_Petani
        '
        Me.chkS_Petani.AutoSize = True
        Me.chkS_Petani.FlatAppearance.BorderSize = 0
        Me.chkS_Petani.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkS_Petani.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.chkS_Petani.Location = New System.Drawing.Point(12, 98)
        Me.chkS_Petani.Name = "chkS_Petani"
        Me.chkS_Petani.Size = New System.Drawing.Size(82, 20)
        Me.chkS_Petani.TabIndex = 905634
        Me.chkS_Petani.Text = "Sub Petani"
        Me.chkS_Petani.UseVisualStyleBackColor = True
        '
        'cmbS_Petani
        '
        Me.cmbS_Petani.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cmbS_Petani.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbS_Petani.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbS_Petani.FormattingEnabled = True
        Me.cmbS_Petani.IntegralHeight = False
        Me.cmbS_Petani.Location = New System.Drawing.Point(152, 99)
        Me.cmbS_Petani.Name = "cmbS_Petani"
        Me.cmbS_Petani.Size = New System.Drawing.Size(243, 24)
        Me.cmbS_Petani.TabIndex = 905633
        '
        'Dt2
        '
        Me.Dt2.CustomFormat = "dd MMM yyyy"
        Me.Dt2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dt2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dt2.Location = New System.Drawing.Point(285, 14)
        Me.Dt2.Name = "Dt2"
        Me.Dt2.Size = New System.Drawing.Size(110, 23)
        Me.Dt2.TabIndex = 905628
        Me.Dt2.Value = New Date(2019, 4, 8, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(267, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 16)
        Me.Label4.TabIndex = 905627
        Me.Label4.Text = "-"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(135, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 16)
        Me.Label5.TabIndex = 905626
        Me.Label5.Text = ":"
        '
        'Dt1
        '
        Me.Dt1.CustomFormat = "dd MMM yyyy"
        Me.Dt1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dt1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dt1.Location = New System.Drawing.Point(151, 14)
        Me.Dt1.Name = "Dt1"
        Me.Dt1.Size = New System.Drawing.Size(110, 23)
        Me.Dt1.TabIndex = 905625
        Me.Dt1.Value = New Date(2019, 4, 8, 0, 0, 0, 0)
        '
        'chktukarpoin
        '
        Me.chktukarpoin.AutoSize = True
        Me.chktukarpoin.Location = New System.Drawing.Point(12, 19)
        Me.chktukarpoin.Name = "chktukarpoin"
        Me.chktukarpoin.Size = New System.Drawing.Size(97, 20)
        Me.chktukarpoin.TabIndex = 905624
        Me.chktukarpoin.Text = "Tgl Tukar Poin"
        Me.chktukarpoin.UseVisualStyleBackColor = True
        '
        'lblInfo
        '
        Me.lblInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblInfo.BackColor = System.Drawing.Color.Transparent
        Me.lblInfo.Font = New System.Drawing.Font("Palatino Linotype", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.ForeColor = System.Drawing.Color.Red
        Me.lblInfo.Location = New System.Drawing.Point(418, 17)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(545, 24)
        Me.lblInfo.TabIndex = 905623
        Me.lblInfo.Text = "DoubleClick pada kolom ""FOTO"" untuk melihat foto petani !!                       " &
    "                                                                                " &
    "                            "
        '
        'btnExcel
        '
        Me.btnExcel.BackColor = System.Drawing.Color.MintCream
        Me.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnExcel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExcel.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.ForeColor = System.Drawing.Color.ForestGreen
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(466, 125)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(60, 24)
        Me.btnExcel.TabIndex = 905620
        Me.btnExcel.Text = "Excel"
        Me.btnExcel.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.AliceBlue
        Me.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRefresh.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRefresh.Location = New System.Drawing.Point(400, 125)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(60, 24)
        Me.btnRefresh.TabIndex = 905619
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'cboToko
        '
        Me.cboToko.FormattingEnabled = True
        Me.cboToko.Location = New System.Drawing.Point(151, 71)
        Me.cboToko.Name = "cboToko"
        Me.cboToko.Size = New System.Drawing.Size(244, 24)
        Me.cboToko.TabIndex = 905618
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(135, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(10, 16)
        Me.Label3.TabIndex = 905617
        Me.Label3.Text = ":"
        '
        'chkToko
        '
        Me.chkToko.AutoSize = True
        Me.chkToko.Location = New System.Drawing.Point(12, 73)
        Me.chkToko.Name = "chkToko"
        Me.chkToko.Size = New System.Drawing.Size(50, 20)
        Me.chkToko.TabIndex = 905616
        Me.chkToko.Text = "Toko"
        Me.chkToko.UseVisualStyleBackColor = True
        '
        'dtp2
        '
        Me.dtp2.CustomFormat = "dd MMM yyyy"
        Me.dtp2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp2.Location = New System.Drawing.Point(285, 42)
        Me.dtp2.Name = "dtp2"
        Me.dtp2.Size = New System.Drawing.Size(110, 23)
        Me.dtp2.TabIndex = 905615
        Me.dtp2.Value = New Date(2019, 4, 8, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(267, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 16)
        Me.Label2.TabIndex = 905614
        Me.Label2.Text = "-"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(135, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 16)
        Me.Label1.TabIndex = 905613
        Me.Label1.Text = ":"
        '
        'dtp1
        '
        Me.dtp1.CustomFormat = "dd MMM yyyy"
        Me.dtp1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp1.Location = New System.Drawing.Point(151, 42)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(110, 23)
        Me.dtp1.TabIndex = 905612
        Me.dtp1.Value = New Date(2019, 4, 8, 0, 0, 0, 0)
        '
        'chkTgl
        '
        Me.chkTgl.AutoSize = True
        Me.chkTgl.Location = New System.Drawing.Point(12, 47)
        Me.chkTgl.Name = "chkTgl"
        Me.chkTgl.Size = New System.Drawing.Size(103, 20)
        Me.chkTgl.TabIndex = 905611
        Me.chkTgl.Text = "Tgl Pengajuan"
        Me.chkTgl.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.LavenderBlush
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.IndianRed
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(532, 125)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(50, 24)
        Me.btnClose.TabIndex = 905610
        Me.btnClose.Text = "Exit"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(6, 156)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1194, 1)
        Me.Panel1.TabIndex = 905608
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox3.Controls.Add(Me.fg)
        Me.GroupBox3.Controls.Add(Me.C1FlexGrid1)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(0, 288)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1206, 417)
        Me.GroupBox3.TabIndex = 905629
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Data Pengajuan"
        '
        'C1FlexGrid1
        '
        Me.C1FlexGrid1.AllowEditing = False
        Me.C1FlexGrid1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.C1FlexGrid1.ColumnInfo = "23,1,0,0,0,110,Columns:22{Style:""TextAlign:GeneralCenter;ImageAlign:CenterCenter;" &
    """;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.C1FlexGrid1.ForeColor = System.Drawing.Color.Black
        Me.C1FlexGrid1.Location = New System.Drawing.Point(514, 144)
        Me.C1FlexGrid1.Name = "C1FlexGrid1"
        Me.C1FlexGrid1.Rows.Count = 4
        Me.C1FlexGrid1.Rows.DefaultSize = 22
        Me.C1FlexGrid1.Size = New System.Drawing.Size(179, 128)
        Me.C1FlexGrid1.StyleInfo = resources.GetString("C1FlexGrid1.StyleInfo")
        Me.C1FlexGrid1.TabIndex = 905632
        Me.C1FlexGrid1.Visible = False
        '
        'Timer
        '
        '
        'SaveFileDialog
        '
        '
        'FrmMonPengajuanPoinNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1206, 705)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmMonPengajuanPoinNew"
        Me.Text = "FrmMonPengajuanPoinNew"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents pnlHead As Panel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents txtSum As TextBox
    Friend WithEvents schfg As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents Label10 As Label
    Friend WithEvents chkS_Petani As CheckBox
    Friend WithEvents cmbS_Petani As ComboBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Dt2 As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Dt1 As DateTimePicker
    Friend WithEvents chktukarpoin As CheckBox
    Friend WithEvents lblInfo As Label
    Friend WithEvents btnExcel As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents cboToko As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents chkToko As CheckBox
    Friend WithEvents dtp2 As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtp1 As DateTimePicker
    Friend WithEvents chkTgl As CheckBox
    Friend WithEvents btnClose As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Timer As Timer
    Friend WithEvents SaveFileDialog As SaveFileDialog
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents chk4 As CheckBox
    Friend WithEvents chk3 As CheckBox
    Friend WithEvents chk2 As CheckBox
    Friend WithEvents chk1 As CheckBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label6 As Label
    Friend WithEvents chkpancang As CheckBox
    Friend WithEvents cbopancang As ComboBox
    Friend WithEvents C1FlexGrid1 As C1.Win.C1FlexGrid.C1FlexGrid
End Class
