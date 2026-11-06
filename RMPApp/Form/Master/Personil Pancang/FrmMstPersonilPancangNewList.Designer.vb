<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMstPersonilPancangNewList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMstPersonilPancangNewList))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DTP2 = New System.Windows.Forms.DateTimePicker()
        Me.DTP1 = New System.Windows.Forms.DateTimePicker()
        Me.chkTransDate = New System.Windows.Forms.CheckBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnAjukanAP = New System.Windows.Forms.Button()
        Me.grpDataTimbangCrane = New XanderUI.XUICustomGroupbox()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.schfg = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.btncancel = New System.Windows.Forms.Button()
        Me.btnrefreshh = New System.Windows.Forms.Button()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.chkpsp = New System.Windows.Forms.CheckBox()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        Me.chkNotActive = New System.Windows.Forms.CheckBox()
        Me.txtidpersonil = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkIDPersonil = New System.Windows.Forms.CheckBox()
        Me.chkp2 = New System.Windows.Forms.CheckBox()
        Me.chkp1 = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbPancang = New System.Windows.Forms.ComboBox()
        Me.chkPancang = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CHkp3 = New System.Windows.Forms.CheckBox()
        Me.grpDataTimbangCrane.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cascadia Code", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(107, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(13, 15)
        Me.Label2.TabIndex = 277
        Me.Label2.Text = ":"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cascadia Code", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(225, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(13, 15)
        Me.Label1.TabIndex = 270
        Me.Label1.Text = "-"
        '
        'DTP2
        '
        Me.DTP2.CustomFormat = "dd/mm/yyyy"
        Me.DTP2.Font = New System.Drawing.Font("Cascadia Code", 8.25!)
        Me.DTP2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP2.Location = New System.Drawing.Point(240, 13)
        Me.DTP2.Name = "DTP2"
        Me.DTP2.Size = New System.Drawing.Size(93, 20)
        Me.DTP2.TabIndex = 272
        Me.DTP2.Value = New Date(2020, 2, 1, 0, 0, 0, 0)
        '
        'DTP1
        '
        Me.DTP1.CustomFormat = "dd/mm/yyyy"
        Me.DTP1.Font = New System.Drawing.Font("Cascadia Code", 8.25!)
        Me.DTP1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP1.Location = New System.Drawing.Point(125, 13)
        Me.DTP1.Name = "DTP1"
        Me.DTP1.Size = New System.Drawing.Size(98, 20)
        Me.DTP1.TabIndex = 271
        Me.DTP1.Value = New Date(2020, 2, 1, 0, 0, 0, 0)
        '
        'chkTransDate
        '
        Me.chkTransDate.AutoSize = True
        Me.chkTransDate.Checked = True
        Me.chkTransDate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTransDate.FlatAppearance.BorderSize = 0
        Me.chkTransDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkTransDate.Font = New System.Drawing.Font("Cascadia Code", 8.25!)
        Me.chkTransDate.Location = New System.Drawing.Point(7, 14)
        Me.chkTransDate.Name = "chkTransDate"
        Me.chkTransDate.Size = New System.Drawing.Size(47, 19)
        Me.chkTransDate.TabIndex = 269
        Me.chkTransDate.Text = "Date"
        Me.chkTransDate.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.AliceBlue
        Me.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Gabriola", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(800, 9)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(97, 35)
        Me.btnAdd.TabIndex = 252
        Me.btnAdd.Text = "Add (New)"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnAjukanAP
        '
        Me.btnAjukanAP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAjukanAP.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnAjukanAP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAjukanAP.Font = New System.Drawing.Font("Gabriola", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAjukanAP.ForeColor = System.Drawing.Color.White
        Me.btnAjukanAP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAjukanAP.Location = New System.Drawing.Point(1103, 620)
        Me.btnAjukanAP.Name = "btnAjukanAP"
        Me.btnAjukanAP.Size = New System.Drawing.Size(89, 34)
        Me.btnAjukanAP.TabIndex = 884
        Me.btnAjukanAP.Text = "&AjukanAP"
        Me.btnAjukanAP.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnAjukanAP.UseVisualStyleBackColor = False
        '
        'grpDataTimbangCrane
        '
        Me.grpDataTimbangCrane.BorderColor = System.Drawing.Color.DodgerBlue
        Me.grpDataTimbangCrane.BorderWidth = 1
        Me.grpDataTimbangCrane.Controls.Add(Me.fg)
        Me.grpDataTimbangCrane.Controls.Add(Me.schfg)
        Me.grpDataTimbangCrane.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDataTimbangCrane.Font = New System.Drawing.Font("Cascadia Code", 8.25!)
        Me.grpDataTimbangCrane.Location = New System.Drawing.Point(0, 0)
        Me.grpDataTimbangCrane.Name = "grpDataTimbangCrane"
        Me.grpDataTimbangCrane.ShowText = True
        Me.grpDataTimbangCrane.Size = New System.Drawing.Size(1048, 443)
        Me.grpDataTimbangCrane.TabIndex = 215
        Me.grpDataTimbangCrane.TabStop = False
        Me.grpDataTimbangCrane.Text = "Master Personil Pancang"
        Me.grpDataTimbangCrane.TextColor = System.Drawing.Color.Navy
        '
        'fg
        '
        Me.fg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fg.ColumnInfo = resources.GetString("fg.ColumnInfo")
        Me.fg.Location = New System.Drawing.Point(12, 22)
        Me.fg.Name = "fg"
        Me.fg.Rows.Count = 10
        Me.fg.Size = New System.Drawing.Size(1027, 404)
        Me.fg.StyleInfo = resources.GetString("fg.StyleInfo")
        Me.fg.TabIndex = 431
        '
        'schfg
        '
        Me.schfg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.schfg.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.schfg.Location = New System.Drawing.Point(867, -12)
        Me.schfg.Margin = New System.Windows.Forms.Padding(1)
        Me.schfg.Name = "schfg"
        Me.schfg.ShowClearButton = False
        Me.schfg.ShowSearchButton = False
        Me.schfg.Size = New System.Drawing.Size(208, 37)
        Me.schfg.TabIndex = 194
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
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnAdd)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btncancel)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnrefreshh)
        Me.SplitContainer1.Size = New System.Drawing.Size(1048, 494)
        Me.SplitContainer1.SplitterDistance = 443
        Me.SplitContainer1.TabIndex = 0
        '
        'btncancel
        '
        Me.btncancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btncancel.BackColor = System.Drawing.Color.AliceBlue
        Me.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncancel.Font = New System.Drawing.Font("Gabriola", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncancel.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.btncancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btncancel.Location = New System.Drawing.Point(896, 9)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(75, 35)
        Me.btncancel.TabIndex = 251
        Me.btncancel.Text = "Close"
        Me.btncancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btncancel.UseVisualStyleBackColor = False
        '
        'btnrefreshh
        '
        Me.btnrefreshh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnrefreshh.BackColor = System.Drawing.Color.AliceBlue
        Me.btnrefreshh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnrefreshh.Font = New System.Drawing.Font("Gabriola", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnrefreshh.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.btnrefreshh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnrefreshh.Location = New System.Drawing.Point(970, 9)
        Me.btnrefreshh.Name = "btnrefreshh"
        Me.btnrefreshh.Size = New System.Drawing.Size(75, 35)
        Me.btnrefreshh.TabIndex = 249
        Me.btnrefreshh.Text = "Refresh"
        Me.btnrefreshh.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnrefreshh.UseVisualStyleBackColor = False
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
        Me.SplitContainer2.Panel1.Controls.Add(Me.CHkp3)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkpsp)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkAll)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkNotActive)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtidpersonil)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkIDPersonil)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkp2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkp1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cmbPancang)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkPancang)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.DTP2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.DTP1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkTransDate)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer1)
        Me.SplitContainer2.Size = New System.Drawing.Size(1048, 598)
        Me.SplitContainer2.SplitterDistance = 100
        Me.SplitContainer2.TabIndex = 75
        '
        'chkpsp
        '
        Me.chkpsp.AutoSize = True
        Me.chkpsp.FlatAppearance.BorderSize = 0
        Me.chkpsp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkpsp.Font = New System.Drawing.Font("Cascadia Code", 8.25!)
        Me.chkpsp.Location = New System.Drawing.Point(499, 12)
        Me.chkpsp.Name = "chkpsp"
        Me.chkpsp.Size = New System.Drawing.Size(41, 19)
        Me.chkpsp.TabIndex = 344
        Me.chkpsp.Text = "PSP"
        Me.chkpsp.UseVisualStyleBackColor = True
        '
        'chkAll
        '
        Me.chkAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkAll.AutoSize = True
        Me.chkAll.FlatAppearance.BorderSize = 0
        Me.chkAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkAll.Font = New System.Drawing.Font("Cascadia Code", 8.25!)
        Me.chkAll.Location = New System.Drawing.Point(911, 69)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(41, 19)
        Me.chkAll.TabIndex = 343
        Me.chkAll.Text = "All"
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'chkNotActive
        '
        Me.chkNotActive.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkNotActive.AutoSize = True
        Me.chkNotActive.FlatAppearance.BorderSize = 0
        Me.chkNotActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkNotActive.Font = New System.Drawing.Font("Cascadia Code", 8.25!)
        Me.chkNotActive.Location = New System.Drawing.Point(962, 69)
        Me.chkNotActive.Name = "chkNotActive"
        Me.chkNotActive.Size = New System.Drawing.Size(77, 19)
        Me.chkNotActive.TabIndex = 342
        Me.chkNotActive.Text = "NotActive"
        Me.chkNotActive.UseVisualStyleBackColor = True
        '
        'txtidpersonil
        '
        Me.txtidpersonil.Location = New System.Drawing.Point(125, 63)
        Me.txtidpersonil.Name = "txtidpersonil"
        Me.txtidpersonil.Size = New System.Drawing.Size(208, 20)
        Me.txtidpersonil.TabIndex = 341
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Cascadia Code", 8.25!)
        Me.Label5.Location = New System.Drawing.Point(106, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(13, 15)
        Me.Label5.TabIndex = 340
        Me.Label5.Text = ":"
        '
        'chkIDPersonil
        '
        Me.chkIDPersonil.AutoSize = True
        Me.chkIDPersonil.FlatAppearance.BorderSize = 0
        Me.chkIDPersonil.Font = New System.Drawing.Font("Cascadia Code", 8.25!)
        Me.chkIDPersonil.Location = New System.Drawing.Point(7, 62)
        Me.chkIDPersonil.Name = "chkIDPersonil"
        Me.chkIDPersonil.Size = New System.Drawing.Size(98, 19)
        Me.chkIDPersonil.TabIndex = 339
        Me.chkIDPersonil.Text = "Personil    "
        Me.chkIDPersonil.UseVisualStyleBackColor = True
        '
        'chkp2
        '
        Me.chkp2.AutoSize = True
        Me.chkp2.FlatAppearance.BorderSize = 0
        Me.chkp2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkp2.Font = New System.Drawing.Font("Cascadia Code", 8.25!)
        Me.chkp2.Location = New System.Drawing.Point(411, 13)
        Me.chkp2.Name = "chkp2"
        Me.chkp2.Size = New System.Drawing.Size(35, 19)
        Me.chkp2.TabIndex = 282
        Me.chkp2.Text = "P2"
        Me.chkp2.UseVisualStyleBackColor = True
        '
        'chkp1
        '
        Me.chkp1.AutoSize = True
        Me.chkp1.FlatAppearance.BorderSize = 0
        Me.chkp1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkp1.Font = New System.Drawing.Font("Cascadia Code", 8.25!)
        Me.chkp1.Location = New System.Drawing.Point(366, 13)
        Me.chkp1.Name = "chkp1"
        Me.chkp1.Size = New System.Drawing.Size(35, 19)
        Me.chkp1.TabIndex = 281
        Me.chkp1.Text = "P1"
        Me.chkp1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Cascadia Code", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(107, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(13, 15)
        Me.Label4.TabIndex = 280
        Me.Label4.Text = ":"
        '
        'cmbPancang
        '
        Me.cmbPancang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cmbPancang.Font = New System.Drawing.Font("Cascadia Code", 8.25!)
        Me.cmbPancang.FormattingEnabled = True
        Me.cmbPancang.IntegralHeight = False
        Me.cmbPancang.Location = New System.Drawing.Point(125, 37)
        Me.cmbPancang.Name = "cmbPancang"
        Me.cmbPancang.Size = New System.Drawing.Size(208, 23)
        Me.cmbPancang.TabIndex = 279
        '
        'chkPancang
        '
        Me.chkPancang.AutoSize = True
        Me.chkPancang.FlatAppearance.BorderSize = 0
        Me.chkPancang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkPancang.Font = New System.Drawing.Font("Cascadia Code", 8.25!)
        Me.chkPancang.Location = New System.Drawing.Point(7, 37)
        Me.chkPancang.Name = "chkPancang"
        Me.chkPancang.Size = New System.Drawing.Size(65, 19)
        Me.chkPancang.TabIndex = 278
        Me.chkPancang.Text = "Pancang"
        Me.chkPancang.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.SplitContainer2)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 43)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1054, 617)
        Me.GroupBox2.TabIndex = 882
        Me.GroupBox2.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(-138, -24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 15)
        Me.Label3.TabIndex = 880
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Cascadia Code", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(365, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(265, 25)
        Me.Label8.TabIndex = 857
        Me.Label8.Text = "Master Personil Pancang"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1054, 43)
        Me.Panel1.TabIndex = 881
        '
        'CHkp3
        '
        Me.CHkp3.AutoSize = True
        Me.CHkp3.FlatAppearance.BorderSize = 0
        Me.CHkp3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CHkp3.Font = New System.Drawing.Font("Cascadia Code", 8.25!)
        Me.CHkp3.Location = New System.Drawing.Point(452, 12)
        Me.CHkp3.Name = "CHkp3"
        Me.CHkp3.Size = New System.Drawing.Size(35, 19)
        Me.CHkp3.TabIndex = 345
        Me.CHkp3.Text = "P3"
        Me.CHkp3.UseVisualStyleBackColor = True
        '
        'FrmMstPersonilPancangNewList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1054, 660)
        Me.Controls.Add(Me.btnAjukanAP)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmMstPersonilPancangNewList"
        Me.Text = "FrmMstPersonilPancangNewList"
        Me.grpDataTimbangCrane.ResumeLayout(False)
        Me.grpDataTimbangCrane.PerformLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents DTP2 As DateTimePicker
    Friend WithEvents DTP1 As DateTimePicker
    Friend WithEvents chkTransDate As CheckBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnAjukanAP As Button
    Friend WithEvents schfg As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents btncancel As Button
    Friend WithEvents btnrefreshh As Button
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents SaveFileDialog As SaveFileDialog
    Friend WithEvents Label3 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel1 As Panel
    Private WithEvents grpDataTimbangCrane As XanderUI.XUICustomGroupbox
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbPancang As ComboBox
    Friend WithEvents chkPancang As CheckBox
    Friend WithEvents chkp2 As CheckBox
    Friend WithEvents chkp1 As CheckBox
    Friend WithEvents chkIDPersonil As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtidpersonil As TextBox
    Friend WithEvents chkNotActive As CheckBox
    Friend WithEvents chkAll As CheckBox
    Friend WithEvents chkpsp As CheckBox
    Friend WithEvents CHkp3 As CheckBox
End Class
