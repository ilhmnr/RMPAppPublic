<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMonKapalSusust
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMonKapalSusust))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.rdp2 = New System.Windows.Forms.RadioButton()
        Me.rdp1 = New System.Windows.Forms.RadioButton()
        Me.rdAll = New System.Windows.Forms.RadioButton()
        Me.schfgKg = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.cbojenis = New System.Windows.Forms.ComboBox()
        Me.fgKg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.chkJenisKB = New System.Windows.Forms.CheckBox()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.cbodermaga = New System.Windows.Forms.ComboBox()
        Me.chkPancang = New System.Windows.Forms.CheckBox()
        Me.chkDermaga = New System.Windows.Forms.CheckBox()
        Me.chkKapal = New System.Windows.Forms.CheckBox()
        Me.DoDate1 = New System.Windows.Forms.DateTimePicker()
        Me.PanelKapal = New System.Windows.Forms.Panel()
        Me.PanelKapal2 = New System.Windows.Forms.Panel()
        Me.PanelKapal1 = New System.Windows.Forms.Panel()
        Me.cmbKapal = New System.Windows.Forms.ComboBox()
        Me.chkDO = New System.Windows.Forms.CheckBox()
        Me.PanelPancang = New System.Windows.Forms.Panel()
        Me.PanelPancang2 = New System.Windows.Forms.Panel()
        Me.PanelPancang1 = New System.Windows.Forms.Panel()
        Me.cmbPancang = New System.Windows.Forms.ComboBox()
        Me.DoDate2 = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.BTNSAVE = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.fgKg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel11.SuspendLayout()
        Me.PanelKapal.SuspendLayout()
        Me.PanelPancang.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Panel16)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(918, 40)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnRefresh)
        Me.Panel2.Controls.Add(Me.btnExit)
        Me.Panel2.Controls.Add(Me.btnExcel)
        Me.Panel2.Controls.Add(Me.BTNSAVE)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 449)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(918, 40)
        Me.Panel2.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 40)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(918, 409)
        Me.Panel3.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Panel15)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.rdp2)
        Me.Panel4.Controls.Add(Me.PanelPancang)
        Me.Panel4.Controls.Add(Me.rdp1)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.DoDate2)
        Me.Panel4.Controls.Add(Me.rdAll)
        Me.Panel4.Controls.Add(Me.Panel8)
        Me.Panel4.Controls.Add(Me.chkDO)
        Me.Panel4.Controls.Add(Me.PanelKapal)
        Me.Panel4.Controls.Add(Me.DoDate1)
        Me.Panel4.Controls.Add(Me.chkJenisKB)
        Me.Panel4.Controls.Add(Me.chkKapal)
        Me.Panel4.Controls.Add(Me.chkDermaga)
        Me.Panel4.Controls.Add(Me.Panel11)
        Me.Panel4.Controls.Add(Me.chkPancang)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(918, 100)
        Me.Panel4.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Panel7)
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 100)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(918, 309)
        Me.Panel5.TabIndex = 0
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Panel14)
        Me.Panel6.Controls.Add(Me.schfgKg)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(918, 30)
        Me.Panel6.TabIndex = 0
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.fgKg)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(0, 30)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Padding = New System.Windows.Forms.Padding(10, 0, 10, 10)
        Me.Panel7.Size = New System.Drawing.Size(918, 279)
        Me.Panel7.TabIndex = 0
        '
        'rdp2
        '
        Me.rdp2.AutoSize = True
        Me.rdp2.Location = New System.Drawing.Point(636, 73)
        Me.rdp2.Name = "rdp2"
        Me.rdp2.Size = New System.Drawing.Size(38, 17)
        Me.rdp2.TabIndex = 297
        Me.rdp2.Text = "P2"
        Me.rdp2.UseVisualStyleBackColor = True
        '
        'rdp1
        '
        Me.rdp1.AutoSize = True
        Me.rdp1.Location = New System.Drawing.Point(592, 73)
        Me.rdp1.Name = "rdp1"
        Me.rdp1.Size = New System.Drawing.Size(38, 17)
        Me.rdp1.TabIndex = 296
        Me.rdp1.Text = "P1"
        Me.rdp1.UseVisualStyleBackColor = True
        '
        'rdAll
        '
        Me.rdAll.AutoSize = True
        Me.rdAll.Checked = True
        Me.rdAll.Location = New System.Drawing.Point(550, 73)
        Me.rdAll.Name = "rdAll"
        Me.rdAll.Size = New System.Drawing.Size(36, 17)
        Me.rdAll.TabIndex = 295
        Me.rdAll.TabStop = True
        Me.rdAll.Text = "All"
        Me.rdAll.UseVisualStyleBackColor = True
        '
        'schfgKg
        '
        Me.schfgKg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.schfgKg.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.schfgKg.Location = New System.Drawing.Point(611, -7)
        Me.schfgKg.Margin = New System.Windows.Forms.Padding(1)
        Me.schfgKg.Name = "schfgKg"
        Me.schfgKg.ShowClearButton = False
        Me.schfgKg.ShowSearchButton = False
        Me.schfgKg.Size = New System.Drawing.Size(326, 32)
        Me.schfgKg.TabIndex = 283
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.Panel9)
        Me.Panel8.Controls.Add(Me.Panel10)
        Me.Panel8.Controls.Add(Me.cbojenis)
        Me.Panel8.Location = New System.Drawing.Point(549, 39)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(205, 26)
        Me.Panel8.TabIndex = 293
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel9.Location = New System.Drawing.Point(4, 25)
        Me.Panel9.MaximumSize = New System.Drawing.Size(412, 1)
        Me.Panel9.MinimumSize = New System.Drawing.Size(2, 1)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(5, 1)
        Me.Panel9.TabIndex = 66
        Me.Panel9.Visible = False
        '
        'Panel10
        '
        Me.Panel10.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel10.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel10.Location = New System.Drawing.Point(4, 25)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(198, 1)
        Me.Panel10.TabIndex = 65
        '
        'cbojenis
        '
        Me.cbojenis.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbojenis.BackColor = System.Drawing.Color.White
        Me.cbojenis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbojenis.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbojenis.FormattingEnabled = True
        Me.cbojenis.IntegralHeight = False
        Me.cbojenis.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cbojenis.Location = New System.Drawing.Point(3, 1)
        Me.cbojenis.Name = "cbojenis"
        Me.cbojenis.Size = New System.Drawing.Size(201, 25)
        Me.cbojenis.TabIndex = 64
        '
        'fgKg
        '
        Me.fgKg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fgKg.ColumnInfo = resources.GetString("fgKg.ColumnInfo")
        Me.fgKg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgKg.ForeColor = System.Drawing.Color.Black
        Me.fgKg.Location = New System.Drawing.Point(10, 0)
        Me.fgKg.Name = "fgKg"
        Me.fgKg.Rows.Count = 5
        Me.fgKg.Rows.DefaultSize = 22
        Me.fgKg.Size = New System.Drawing.Size(898, 269)
        Me.fgKg.StyleInfo = resources.GetString("fgKg.StyleInfo")
        Me.fgKg.TabIndex = 274
        '
        'chkJenisKB
        '
        Me.chkJenisKB.AutoSize = True
        Me.chkJenisKB.FlatAppearance.BorderSize = 0
        Me.chkJenisKB.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkJenisKB.Location = New System.Drawing.Point(457, 42)
        Me.chkJenisKB.Name = "chkJenisKB"
        Me.chkJenisKB.Size = New System.Drawing.Size(57, 21)
        Me.chkJenisKB.TabIndex = 292
        Me.chkJenisKB.Text = "Jenis"
        Me.chkJenisKB.UseVisualStyleBackColor = True
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.Panel12)
        Me.Panel11.Controls.Add(Me.Panel13)
        Me.Panel11.Controls.Add(Me.cbodermaga)
        Me.Panel11.Location = New System.Drawing.Point(550, 10)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(205, 26)
        Me.Panel11.TabIndex = 290
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel12.Location = New System.Drawing.Point(4, 25)
        Me.Panel12.MaximumSize = New System.Drawing.Size(412, 1)
        Me.Panel12.MinimumSize = New System.Drawing.Size(2, 1)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(5, 1)
        Me.Panel12.TabIndex = 66
        Me.Panel12.Visible = False
        '
        'Panel13
        '
        Me.Panel13.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel13.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel13.Location = New System.Drawing.Point(4, 25)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(198, 1)
        Me.Panel13.TabIndex = 65
        '
        'cbodermaga
        '
        Me.cbodermaga.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbodermaga.BackColor = System.Drawing.Color.White
        Me.cbodermaga.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbodermaga.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbodermaga.FormattingEnabled = True
        Me.cbodermaga.IntegralHeight = False
        Me.cbodermaga.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cbodermaga.Location = New System.Drawing.Point(3, 1)
        Me.cbodermaga.Name = "cbodermaga"
        Me.cbodermaga.Size = New System.Drawing.Size(201, 25)
        Me.cbodermaga.TabIndex = 64
        '
        'chkPancang
        '
        Me.chkPancang.AutoSize = True
        Me.chkPancang.FlatAppearance.BorderSize = 0
        Me.chkPancang.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPancang.Location = New System.Drawing.Point(10, 13)
        Me.chkPancang.Name = "chkPancang"
        Me.chkPancang.Size = New System.Drawing.Size(86, 21)
        Me.chkPancang.TabIndex = 275
        Me.chkPancang.Text = "Pancang"
        Me.chkPancang.UseVisualStyleBackColor = True
        '
        'chkDermaga
        '
        Me.chkDermaga.AutoSize = True
        Me.chkDermaga.FlatAppearance.BorderSize = 0
        Me.chkDermaga.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDermaga.Location = New System.Drawing.Point(457, 13)
        Me.chkDermaga.Name = "chkDermaga"
        Me.chkDermaga.Size = New System.Drawing.Size(89, 21)
        Me.chkDermaga.TabIndex = 289
        Me.chkDermaga.Text = "Dermaga"
        Me.chkDermaga.UseVisualStyleBackColor = True
        '
        'chkKapal
        '
        Me.chkKapal.AutoSize = True
        Me.chkKapal.FlatAppearance.BorderSize = 0
        Me.chkKapal.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkKapal.Location = New System.Drawing.Point(10, 42)
        Me.chkKapal.Name = "chkKapal"
        Me.chkKapal.Size = New System.Drawing.Size(65, 21)
        Me.chkKapal.TabIndex = 278
        Me.chkKapal.Text = "Kapal"
        Me.chkKapal.UseVisualStyleBackColor = True
        '
        'DoDate1
        '
        Me.DoDate1.CustomFormat = "dd MMM yyyy"
        Me.DoDate1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DoDate1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DoDate1.Location = New System.Drawing.Point(100, 69)
        Me.DoDate1.Name = "DoDate1"
        Me.DoDate1.Size = New System.Drawing.Size(92, 23)
        Me.DoDate1.TabIndex = 287
        Me.DoDate1.Value = New Date(2019, 4, 8, 0, 0, 0, 0)
        '
        'PanelKapal
        '
        Me.PanelKapal.Controls.Add(Me.PanelKapal2)
        Me.PanelKapal.Controls.Add(Me.PanelKapal1)
        Me.PanelKapal.Controls.Add(Me.cmbKapal)
        Me.PanelKapal.Location = New System.Drawing.Point(100, 39)
        Me.PanelKapal.Name = "PanelKapal"
        Me.PanelKapal.Size = New System.Drawing.Size(329, 26)
        Me.PanelKapal.TabIndex = 279
        '
        'PanelKapal2
        '
        Me.PanelKapal2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PanelKapal2.Location = New System.Drawing.Point(4, 25)
        Me.PanelKapal2.MaximumSize = New System.Drawing.Size(412, 1)
        Me.PanelKapal2.MinimumSize = New System.Drawing.Size(2, 1)
        Me.PanelKapal2.Name = "PanelKapal2"
        Me.PanelKapal2.Size = New System.Drawing.Size(5, 1)
        Me.PanelKapal2.TabIndex = 66
        Me.PanelKapal2.Visible = False
        '
        'PanelKapal1
        '
        Me.PanelKapal1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelKapal1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PanelKapal1.Location = New System.Drawing.Point(4, 25)
        Me.PanelKapal1.Name = "PanelKapal1"
        Me.PanelKapal1.Size = New System.Drawing.Size(322, 1)
        Me.PanelKapal1.TabIndex = 65
        '
        'cmbKapal
        '
        Me.cmbKapal.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbKapal.BackColor = System.Drawing.Color.White
        Me.cmbKapal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbKapal.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbKapal.FormattingEnabled = True
        Me.cmbKapal.IntegralHeight = False
        Me.cmbKapal.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cmbKapal.Location = New System.Drawing.Point(3, 1)
        Me.cmbKapal.Name = "cmbKapal"
        Me.cmbKapal.Size = New System.Drawing.Size(325, 25)
        Me.cmbKapal.TabIndex = 64
        '
        'chkDO
        '
        Me.chkDO.AutoSize = True
        Me.chkDO.FlatAppearance.BorderSize = 0
        Me.chkDO.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDO.Location = New System.Drawing.Point(10, 70)
        Me.chkDO.Name = "chkDO"
        Me.chkDO.Size = New System.Drawing.Size(79, 21)
        Me.chkDO.TabIndex = 285
        Me.chkDO.Tag = "1"
        Me.chkDO.Text = "Tanggal"
        Me.chkDO.UseVisualStyleBackColor = True
        '
        'PanelPancang
        '
        Me.PanelPancang.Controls.Add(Me.PanelPancang2)
        Me.PanelPancang.Controls.Add(Me.PanelPancang1)
        Me.PanelPancang.Controls.Add(Me.cmbPancang)
        Me.PanelPancang.Location = New System.Drawing.Point(100, 10)
        Me.PanelPancang.Name = "PanelPancang"
        Me.PanelPancang.Size = New System.Drawing.Size(329, 26)
        Me.PanelPancang.TabIndex = 276
        '
        'PanelPancang2
        '
        Me.PanelPancang2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PanelPancang2.Location = New System.Drawing.Point(4, 25)
        Me.PanelPancang2.MaximumSize = New System.Drawing.Size(412, 1)
        Me.PanelPancang2.MinimumSize = New System.Drawing.Size(2, 1)
        Me.PanelPancang2.Name = "PanelPancang2"
        Me.PanelPancang2.Size = New System.Drawing.Size(5, 1)
        Me.PanelPancang2.TabIndex = 66
        Me.PanelPancang2.Visible = False
        '
        'PanelPancang1
        '
        Me.PanelPancang1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelPancang1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PanelPancang1.Location = New System.Drawing.Point(4, 25)
        Me.PanelPancang1.Name = "PanelPancang1"
        Me.PanelPancang1.Size = New System.Drawing.Size(322, 1)
        Me.PanelPancang1.TabIndex = 65
        '
        'cmbPancang
        '
        Me.cmbPancang.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbPancang.BackColor = System.Drawing.Color.White
        Me.cmbPancang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbPancang.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPancang.FormattingEnabled = True
        Me.cmbPancang.IntegralHeight = False
        Me.cmbPancang.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cmbPancang.Location = New System.Drawing.Point(3, 1)
        Me.cmbPancang.Name = "cmbPancang"
        Me.cmbPancang.Size = New System.Drawing.Size(325, 25)
        Me.cmbPancang.TabIndex = 64
        '
        'DoDate2
        '
        Me.DoDate2.CustomFormat = "dd MMM yyyy"
        Me.DoDate2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DoDate2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DoDate2.Location = New System.Drawing.Point(204, 69)
        Me.DoDate2.Name = "DoDate2"
        Me.DoDate2.Size = New System.Drawing.Size(92, 23)
        Me.DoDate2.TabIndex = 288
        Me.DoDate2.Value = New Date(2019, 4, 9, 0, 0, 0, 0)
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(192, 74)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(11, 13)
        Me.Label10.TabIndex = 286
        Me.Label10.Text = "-"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(454, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 298
        Me.Label1.Text = "Tujuan"
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.BackColor = System.Drawing.Color.White
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExit.Location = New System.Drawing.Point(833, 5)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnExit.Size = New System.Drawing.Size(75, 30)
        Me.btnExit.TabIndex = 301
        Me.btnExit.Text = "Exit"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnExcel
        '
        Me.btnExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExcel.BackColor = System.Drawing.Color.White
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(757, 5)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Padding = New System.Windows.Forms.Padding(5, 0, 3, 0)
        Me.btnExcel.Size = New System.Drawing.Size(75, 30)
        Me.btnExcel.TabIndex = 300
        Me.btnExcel.Text = "Excel"
        Me.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcel.UseVisualStyleBackColor = False
        '
        'BTNSAVE
        '
        Me.BTNSAVE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTNSAVE.BackColor = System.Drawing.Color.White
        Me.BTNSAVE.Image = CType(resources.GetObject("BTNSAVE.Image"), System.Drawing.Image)
        Me.BTNSAVE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNSAVE.Location = New System.Drawing.Point(681, 5)
        Me.BTNSAVE.Name = "BTNSAVE"
        Me.BTNSAVE.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.BTNSAVE.Size = New System.Drawing.Size(75, 30)
        Me.BTNSAVE.TabIndex = 299
        Me.BTNSAVE.Text = "Save"
        Me.BTNSAVE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTNSAVE.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.White
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRefresh.Location = New System.Drawing.Point(605, 5)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnRefresh.Size = New System.Drawing.Size(75, 30)
        Me.btnRefresh.TabIndex = 302
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'Panel14
        '
        Me.Panel14.BackColor = System.Drawing.Color.Black
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel14.Location = New System.Drawing.Point(0, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(918, 1)
        Me.Panel14.TabIndex = 905704
        '
        'Panel15
        '
        Me.Panel15.BackColor = System.Drawing.Color.Black
        Me.Panel15.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel15.Location = New System.Drawing.Point(0, 0)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(918, 1)
        Me.Panel15.TabIndex = 905704
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(46, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(236, 28)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Monitoring Kapal Susut"
        '
        'Panel16
        '
        Me.Panel16.BackgroundImage = CType(resources.GetObject("Panel16.BackgroundImage"), System.Drawing.Image)
        Me.Panel16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel16.Location = New System.Drawing.Point(10, 3)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(35, 35)
        Me.Panel16.TabIndex = 3
        '
        'FrmMonKapalSusust
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(918, 489)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmMonKapalSusust"
        Me.Text = "Monitoring Kapal Susut"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        CType(Me.fgKg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel11.ResumeLayout(False)
        Me.PanelKapal.ResumeLayout(False)
        Me.PanelPancang.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents fgKg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel6 As Panel
    Friend WithEvents schfgKg As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents rdp2 As RadioButton
    Friend WithEvents PanelPancang As Panel
    Friend WithEvents PanelPancang2 As Panel
    Friend WithEvents PanelPancang1 As Panel
    Friend WithEvents cmbPancang As ComboBox
    Friend WithEvents rdp1 As RadioButton
    Friend WithEvents Label10 As Label
    Friend WithEvents DoDate2 As DateTimePicker
    Friend WithEvents rdAll As RadioButton
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents cbojenis As ComboBox
    Friend WithEvents chkDO As CheckBox
    Friend WithEvents PanelKapal As Panel
    Friend WithEvents PanelKapal2 As Panel
    Friend WithEvents PanelKapal1 As Panel
    Friend WithEvents cmbKapal As ComboBox
    Friend WithEvents DoDate1 As DateTimePicker
    Friend WithEvents chkJenisKB As CheckBox
    Friend WithEvents chkKapal As CheckBox
    Friend WithEvents chkDermaga As CheckBox
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents Panel13 As Panel
    Friend WithEvents cbodermaga As ComboBox
    Friend WithEvents chkPancang As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnExit As Button
    Friend WithEvents btnExcel As Button
    Friend WithEvents BTNSAVE As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents Panel14 As Panel
    Friend WithEvents Panel15 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel16 As Panel
End Class
