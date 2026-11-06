<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMonApprovalHarga
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMonApprovalHarga))
        Me.pnlHead = New System.Windows.Forms.Panel()
        Me.lblHead = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DTPEnd = New System.Windows.Forms.DateTimePicker()
        Me.DTPStart = New System.Windows.Forms.DateTimePicker()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.rdupahbongkar = New System.Windows.Forms.RadioButton()
        Me.rdjasatransport = New System.Windows.Forms.RadioButton()
        Me.rdbahanbaku = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkjeniskbs = New System.Windows.Forms.CheckBox()
        Me.cbojeniskb = New System.Windows.Forms.ComboBox()
        Me.chkPancang = New System.Windows.Forms.CheckBox()
        Me.cmbPancang = New System.Windows.Forms.ComboBox()
        Me.grpDataTimbangCrane = New XanderUI.XUICustomGroupbox()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.schfg = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.grpDataTimbangCrane.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHead
        '
        Me.pnlHead.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlHead.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.pnlHead.Location = New System.Drawing.Point(3, 36)
        Me.pnlHead.Name = "pnlHead"
        Me.pnlHead.Size = New System.Drawing.Size(934, 1)
        Me.pnlHead.TabIndex = 331
        '
        'lblHead
        '
        Me.lblHead.AutoSize = True
        Me.lblHead.BackColor = System.Drawing.Color.Transparent
        Me.lblHead.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblHead.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHead.ForeColor = System.Drawing.Color.DimGray
        Me.lblHead.Location = New System.Drawing.Point(13, 10)
        Me.lblHead.Name = "lblHead"
        Me.lblHead.Size = New System.Drawing.Size(170, 25)
        Me.lblHead.TabIndex = 330
        Me.lblHead.Text = "Approve Harga"
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
        Me.btnRefresh.Location = New System.Drawing.Point(331, 100)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(30, 22)
        Me.btnRefresh.TabIndex = 329
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label2.Location = New System.Drawing.Point(15, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 17)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(213, 106)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 13)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "-"
        '
        'DTPEnd
        '
        Me.DTPEnd.CustomFormat = "dd/mm/yyyy"
        Me.DTPEnd.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPEnd.Location = New System.Drawing.Point(232, 100)
        Me.DTPEnd.Name = "DTPEnd"
        Me.DTPEnd.Size = New System.Drawing.Size(93, 23)
        Me.DTPEnd.TabIndex = 32
        Me.DTPEnd.Value = New Date(2020, 2, 1, 0, 0, 0, 0)
        '
        'DTPStart
        '
        Me.DTPStart.CustomFormat = "dd/mm/yyyy"
        Me.DTPStart.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPStart.Location = New System.Drawing.Point(105, 100)
        Me.DTPStart.Name = "DTPStart"
        Me.DTPStart.Size = New System.Drawing.Size(98, 23)
        Me.DTPStart.TabIndex = 31
        Me.DTPStart.Value = New Date(2020, 2, 1, 0, 0, 0, 0)
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkAll)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.rdupahbongkar)
        Me.SplitContainer1.Panel1.Controls.Add(Me.rdjasatransport)
        Me.SplitContainer1.Panel1.Controls.Add(Me.rdbahanbaku)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkjeniskbs)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbojeniskb)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkPancang)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmbPancang)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlHead)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblHead)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnRefresh)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DTPEnd)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DTPStart)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.SplitContainer1.Panel2.Controls.Add(Me.grpDataTimbangCrane)
        Me.SplitContainer1.Size = New System.Drawing.Size(943, 465)
        Me.SplitContainer1.SplitterDistance = 134
        Me.SplitContainer1.TabIndex = 334
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.Location = New System.Drawing.Point(421, 72)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(37, 17)
        Me.chkAll.TabIndex = 343
        Me.chkAll.Text = "All"
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.BackgroundImage = Global.RMPApp.My.Resources.Resources.Designbolts_Free_Multimedia_Printer_512
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(880, 75)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(60, 56)
        Me.Button1.TabIndex = 342
        Me.Button1.UseVisualStyleBackColor = False
        '
        'rdupahbongkar
        '
        Me.rdupahbongkar.AutoSize = True
        Me.rdupahbongkar.Location = New System.Drawing.Point(487, 97)
        Me.rdupahbongkar.Name = "rdupahbongkar"
        Me.rdupahbongkar.Size = New System.Drawing.Size(126, 17)
        Me.rdupahbongkar.TabIndex = 341
        Me.rdupahbongkar.TabStop = True
        Me.rdupahbongkar.Text = "Harga Upah Bongkar"
        Me.rdupahbongkar.UseVisualStyleBackColor = True
        '
        'rdjasatransport
        '
        Me.rdjasatransport.AutoSize = True
        Me.rdjasatransport.Location = New System.Drawing.Point(487, 73)
        Me.rdjasatransport.Name = "rdjasatransport"
        Me.rdjasatransport.Size = New System.Drawing.Size(127, 17)
        Me.rdjasatransport.TabIndex = 340
        Me.rdjasatransport.TabStop = True
        Me.rdjasatransport.Text = "Harga Jasa Transport"
        Me.rdjasatransport.UseVisualStyleBackColor = True
        '
        'rdbahanbaku
        '
        Me.rdbahanbaku.AutoSize = True
        Me.rdbahanbaku.Location = New System.Drawing.Point(487, 48)
        Me.rdbahanbaku.Name = "rdbahanbaku"
        Me.rdbahanbaku.Size = New System.Drawing.Size(116, 17)
        Me.rdbahanbaku.TabIndex = 339
        Me.rdbahanbaku.TabStop = True
        Me.rdbahanbaku.Text = "Harga Bahan Baku"
        Me.rdbahanbaku.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(2, 10)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(936, 1)
        Me.Panel2.TabIndex = 338
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.Panel3.Location = New System.Drawing.Point(2, 8)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(934, 1)
        Me.Panel3.TabIndex = 337
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(3, 38)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(936, 1)
        Me.Panel1.TabIndex = 336
        '
        'chkjeniskbs
        '
        Me.chkjeniskbs.AutoSize = True
        Me.chkjeniskbs.FlatAppearance.BorderSize = 0
        Me.chkjeniskbs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkjeniskbs.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkjeniskbs.Location = New System.Drawing.Point(18, 72)
        Me.chkjeniskbs.Name = "chkjeniskbs"
        Me.chkjeniskbs.Size = New System.Drawing.Size(54, 21)
        Me.chkjeniskbs.TabIndex = 335
        Me.chkjeniskbs.Text = "Jenis"
        Me.chkjeniskbs.UseVisualStyleBackColor = True
        '
        'cbojeniskb
        '
        Me.cbojeniskb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cbojeniskb.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbojeniskb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbojeniskb.FormattingEnabled = True
        Me.cbojeniskb.IntegralHeight = False
        Me.cbojeniskb.Location = New System.Drawing.Point(107, 74)
        Me.cbojeniskb.Name = "cbojeniskb"
        Me.cbojeniskb.Size = New System.Drawing.Size(255, 24)
        Me.cbojeniskb.TabIndex = 334
        '
        'chkPancang
        '
        Me.chkPancang.AutoSize = True
        Me.chkPancang.FlatAppearance.BorderSize = 0
        Me.chkPancang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkPancang.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPancang.Location = New System.Drawing.Point(18, 48)
        Me.chkPancang.Name = "chkPancang"
        Me.chkPancang.Size = New System.Drawing.Size(83, 21)
        Me.chkPancang.TabIndex = 333
        Me.chkPancang.Text = "Pancang"
        Me.chkPancang.UseVisualStyleBackColor = True
        '
        'cmbPancang
        '
        Me.cmbPancang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cmbPancang.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbPancang.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPancang.FormattingEnabled = True
        Me.cmbPancang.IntegralHeight = False
        Me.cmbPancang.Location = New System.Drawing.Point(107, 50)
        Me.cmbPancang.Name = "cmbPancang"
        Me.cmbPancang.Size = New System.Drawing.Size(255, 24)
        Me.cmbPancang.TabIndex = 332
        '
        'grpDataTimbangCrane
        '
        Me.grpDataTimbangCrane.BackColor = System.Drawing.Color.White
        Me.grpDataTimbangCrane.BorderColor = System.Drawing.Color.DodgerBlue
        Me.grpDataTimbangCrane.BorderWidth = 1
        Me.grpDataTimbangCrane.Controls.Add(Me.fg)
        Me.grpDataTimbangCrane.Controls.Add(Me.schfg)
        Me.grpDataTimbangCrane.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDataTimbangCrane.Font = New System.Drawing.Font("Cascadia Code", 8.25!)
        Me.grpDataTimbangCrane.Location = New System.Drawing.Point(0, 0)
        Me.grpDataTimbangCrane.Name = "grpDataTimbangCrane"
        Me.grpDataTimbangCrane.ShowText = True
        Me.grpDataTimbangCrane.Size = New System.Drawing.Size(943, 327)
        Me.grpDataTimbangCrane.TabIndex = 439
        Me.grpDataTimbangCrane.TabStop = False
        Me.grpDataTimbangCrane.TextColor = System.Drawing.Color.Navy
        '
        'fg
        '
        Me.fg.AllowEditing = False
        Me.fg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fg.ColumnInfo = resources.GetString("fg.ColumnInfo")
        Me.fg.ForeColor = System.Drawing.Color.Black
        Me.fg.Location = New System.Drawing.Point(6, 25)
        Me.fg.Name = "fg"
        Me.fg.Rows.Count = 4
        Me.fg.Rows.DefaultSize = 22
        Me.fg.Size = New System.Drawing.Size(931, 302)
        Me.fg.StyleInfo = resources.GetString("fg.StyleInfo")
        Me.fg.TabIndex = 437
        '
        'schfg
        '
        Me.schfg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.schfg.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.schfg.Location = New System.Drawing.Point(762, -12)
        Me.schfg.Margin = New System.Windows.Forms.Padding(1)
        Me.schfg.Name = "schfg"
        Me.schfg.ShowClearButton = False
        Me.schfg.ShowSearchButton = False
        Me.schfg.Size = New System.Drawing.Size(208, 37)
        Me.schfg.TabIndex = 194
        '
        'FrmMonApprovalHarga
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(943, 465)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmMonApprovalHarga"
        Me.Text = "FrmMonApprovalHarga"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.grpDataTimbangCrane.ResumeLayout(False)
        Me.grpDataTimbangCrane.PerformLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHead As Panel
    Friend WithEvents lblHead As Label
    Friend WithEvents btnRefresh As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents DTPEnd As DateTimePicker
    Friend WithEvents DTPStart As DateTimePicker
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents cbojeniskb As ComboBox
    Friend WithEvents chkPancang As CheckBox
    Friend WithEvents cmbPancang As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents chkjeniskbs As CheckBox
    Friend WithEvents rdupahbongkar As RadioButton
    Friend WithEvents rdjasatransport As RadioButton
    Friend WithEvents rdbahanbaku As RadioButton
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Private WithEvents grpDataTimbangCrane As XanderUI.XUICustomGroupbox
    Friend WithEvents schfg As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents Button1 As Button
    Friend WithEvents chkAll As CheckBox
End Class
