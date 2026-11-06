<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMonPercentagePancang
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMonPercentagePancang))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.cmbPancang = New System.Windows.Forms.ComboBox()
        Me.chkPancang = New System.Windows.Forms.CheckBox()
        Me.dtp2 = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.scp1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.C1DockingTab1 = New C1.Win.C1Command.C1DockingTab()
        Me.C1DockingTabPage1 = New C1.Win.C1Command.C1DockingTabPage()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtSum = New System.Windows.Forms.TextBox()
        Me.btnexcel = New System.Windows.Forms.Button()
        Me.btnrefreshh = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpUm2 = New System.Windows.Forms.DateTimePicker()
        Me.dtpUm1 = New System.Windows.Forms.DateTimePicker()
        Me.chkUmDate = New System.Windows.Forms.CheckBox()
        Me.chkTransDate = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.C1DockingTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1DockingTab1.SuspendLayout()
        Me.C1DockingTabPage1.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1144, 31)
        Me.Panel1.TabIndex = 879
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(29, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(158, 17)
        Me.Label8.TabIndex = 828
        Me.Label8.Text = "Monitoring Rekening"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.RMPApp.My.Resources.Resources.Invoice
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(29, 31)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.SplitContainer2)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 31)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1144, 502)
        Me.GroupBox2.TabIndex = 880
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
        Me.SplitContainer2.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer2.Panel1.Controls.Add(Me.dtpUm2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.dtpUm1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkUmDate)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkTransDate)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cmbPancang)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkPancang)
        Me.SplitContainer2.Panel1.Controls.Add(Me.dtp2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer2.Panel1.Controls.Add(Me.dtp1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer1)
        Me.SplitContainer2.Size = New System.Drawing.Size(1138, 483)
        Me.SplitContainer2.SplitterDistance = 90
        Me.SplitContainer2.TabIndex = 75
        '
        'cmbPancang
        '
        Me.cmbPancang.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbPancang.BackColor = System.Drawing.Color.White
        Me.cmbPancang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbPancang.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPancang.FormattingEnabled = True
        Me.cmbPancang.IntegralHeight = False
        Me.cmbPancang.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cmbPancang.Location = New System.Drawing.Point(110, 43)
        Me.cmbPancang.Name = "cmbPancang"
        Me.cmbPancang.Size = New System.Drawing.Size(263, 25)
        Me.cmbPancang.TabIndex = 258
        '
        'chkPancang
        '
        Me.chkPancang.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chkPancang.AutoSize = True
        Me.chkPancang.FlatAppearance.BorderSize = 0
        Me.chkPancang.Font = New System.Drawing.Font("Century Schoolbook", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPancang.Location = New System.Drawing.Point(11, 45)
        Me.chkPancang.Name = "chkPancang"
        Me.chkPancang.Size = New System.Drawing.Size(73, 20)
        Me.chkPancang.TabIndex = 259
        Me.chkPancang.Text = "Pancang"
        Me.chkPancang.UseVisualStyleBackColor = True
        '
        'dtp2
        '
        Me.dtp2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp2.CustomFormat = "dd MMM yyyy"
        Me.dtp2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp2.Location = New System.Drawing.Point(256, 13)
        Me.dtp2.Name = "dtp2"
        Me.dtp2.Size = New System.Drawing.Size(117, 23)
        Me.dtp2.TabIndex = 247
        Me.dtp2.Value = New Date(2019, 4, 8, 0, 0, 0, 0)
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(238, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(12, 17)
        Me.Label6.TabIndex = 246
        Me.Label6.Text = "-"
        '
        'dtp1
        '
        Me.dtp1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtp1.CustomFormat = "dd MMM yyyy"
        Me.dtp1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp1.Location = New System.Drawing.Point(110, 14)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(122, 23)
        Me.dtp1.TabIndex = 240
        Me.dtp1.Value = New Date(2019, 4, 8, 0, 0, 0, 0)
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.scp1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.C1DockingTab1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtSum)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnexcel)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnrefreshh)
        Me.SplitContainer1.Size = New System.Drawing.Size(1138, 389)
        Me.SplitContainer1.SplitterDistance = 333
        Me.SplitContainer1.TabIndex = 0
        '
        'scp1
        '
        Me.scp1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.scp1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.scp1.Location = New System.Drawing.Point(837, -15)
        Me.scp1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.scp1.Name = "scp1"
        Me.scp1.ShowClearButton = False
        Me.scp1.ShowSearchButton = False
        Me.scp1.Size = New System.Drawing.Size(323, 38)
        Me.scp1.TabIndex = 880
        '
        'C1DockingTab1
        '
        Me.C1DockingTab1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.C1DockingTab1.Controls.Add(Me.C1DockingTabPage1)
        Me.C1DockingTab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1DockingTab1.Location = New System.Drawing.Point(0, 0)
        Me.C1DockingTab1.Name = "C1DockingTab1"
        Me.C1DockingTab1.SelectedIndex = 1
        Me.C1DockingTab1.Size = New System.Drawing.Size(1138, 333)
        Me.C1DockingTab1.TabIndex = 446
        Me.C1DockingTab1.TabLook = C1.Win.C1Command.ButtonLookFlags.Text
        Me.C1DockingTab1.TabsSpacing = 5
        Me.C1DockingTab1.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007
        Me.C1DockingTab1.VisualStyle = C1.Win.C1Command.VisualStyle.Office2007Blue
        Me.C1DockingTab1.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2007Blue
        '
        'C1DockingTabPage1
        '
        Me.C1DockingTabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.C1DockingTabPage1.Controls.Add(Me.fg)
        Me.C1DockingTabPage1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.C1DockingTabPage1.Location = New System.Drawing.Point(0, 24)
        Me.C1DockingTabPage1.Name = "C1DockingTabPage1"
        Me.C1DockingTabPage1.Size = New System.Drawing.Size(1138, 309)
        Me.C1DockingTabPage1.TabBackColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.C1DockingTabPage1.TabBackColorSelected = System.Drawing.Color.AliceBlue
        Me.C1DockingTabPage1.TabForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.C1DockingTabPage1.TabForeColorSelected = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.C1DockingTabPage1.TabIndex = 0
        Me.C1DockingTabPage1.Text = "Nota"
        '
        'fg
        '
        Me.fg.AllowEditing = False
        Me.fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fg.ColumnInfo = resources.GetString("fg.ColumnInfo")
        Me.fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fg.ForeColor = System.Drawing.Color.Black
        Me.fg.Location = New System.Drawing.Point(0, 0)
        Me.fg.Name = "fg"
        Me.fg.Rows.Count = 5
        Me.fg.Rows.DefaultSize = 21
        Me.fg.Size = New System.Drawing.Size(1138, 309)
        Me.fg.StyleInfo = resources.GetString("fg.StyleInfo")
        Me.fg.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.fg.TabIndex = 441
        Me.fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
        '
        'txtSum
        '
        Me.txtSum.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSum.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSum.Location = New System.Drawing.Point(719, 18)
        Me.txtSum.Name = "txtSum"
        Me.txtSum.ReadOnly = True
        Me.txtSum.Size = New System.Drawing.Size(253, 23)
        Me.txtSum.TabIndex = 253
        Me.txtSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnexcel
        '
        Me.btnexcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnexcel.BackColor = System.Drawing.Color.AliceBlue
        Me.btnexcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnexcel.Font = New System.Drawing.Font("Gabriola", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexcel.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.btnexcel.Image = Global.RMPApp.My.Resources.Resources.excel2
        Me.btnexcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnexcel.Location = New System.Drawing.Point(1052, 12)
        Me.btnexcel.Name = "btnexcel"
        Me.btnexcel.Size = New System.Drawing.Size(84, 37)
        Me.btnexcel.TabIndex = 252
        Me.btnexcel.Text = "Excel"
        Me.btnexcel.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnexcel.UseVisualStyleBackColor = False
        '
        'btnrefreshh
        '
        Me.btnrefreshh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnrefreshh.BackColor = System.Drawing.Color.AliceBlue
        Me.btnrefreshh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnrefreshh.Font = New System.Drawing.Font("Gabriola", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnrefreshh.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.btnrefreshh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnrefreshh.Location = New System.Drawing.Point(978, 12)
        Me.btnrefreshh.Name = "btnrefreshh"
        Me.btnrefreshh.Size = New System.Drawing.Size(75, 37)
        Me.btnrefreshh.TabIndex = 250
        Me.btnrefreshh.Text = "Refresh"
        Me.btnrefreshh.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnrefreshh.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(609, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 13)
        Me.Label4.TabIndex = 262
        Me.Label4.Text = "-"
        '
        'dtpUm2
        '
        Me.dtpUm2.CustomFormat = "dd/mm/yyyy"
        Me.dtpUm2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpUm2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpUm2.Location = New System.Drawing.Point(623, 13)
        Me.dtpUm2.Name = "dtpUm2"
        Me.dtpUm2.Size = New System.Drawing.Size(93, 23)
        Me.dtpUm2.TabIndex = 266
        Me.dtpUm2.Value = New Date(2020, 2, 1, 0, 0, 0, 0)
        '
        'dtpUm1
        '
        Me.dtpUm1.CustomFormat = "dd/mm/yyyy"
        Me.dtpUm1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpUm1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpUm1.Location = New System.Drawing.Point(508, 13)
        Me.dtpUm1.Name = "dtpUm1"
        Me.dtpUm1.Size = New System.Drawing.Size(98, 23)
        Me.dtpUm1.TabIndex = 264
        Me.dtpUm1.Value = New Date(2020, 2, 1, 0, 0, 0, 0)
        '
        'chkUmDate
        '
        Me.chkUmDate.AutoSize = True
        Me.chkUmDate.FlatAppearance.BorderSize = 0
        Me.chkUmDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkUmDate.Font = New System.Drawing.Font("Century Schoolbook", 9.0!)
        Me.chkUmDate.Location = New System.Drawing.Point(427, 13)
        Me.chkUmDate.Name = "chkUmDate"
        Me.chkUmDate.Size = New System.Drawing.Size(75, 20)
        Me.chkUmDate.TabIndex = 260
        Me.chkUmDate.Text = "UM Date"
        Me.chkUmDate.UseVisualStyleBackColor = True
        '
        'chkTransDate
        '
        Me.chkTransDate.AutoSize = True
        Me.chkTransDate.Checked = True
        Me.chkTransDate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTransDate.FlatAppearance.BorderSize = 0
        Me.chkTransDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkTransDate.Font = New System.Drawing.Font("Century Schoolbook", 9.0!)
        Me.chkTransDate.Location = New System.Drawing.Point(11, 13)
        Me.chkTransDate.Name = "chkTransDate"
        Me.chkTransDate.Size = New System.Drawing.Size(81, 20)
        Me.chkTransDate.TabIndex = 261
        Me.chkTransDate.Text = "Nota Date"
        Me.chkTransDate.UseVisualStyleBackColor = True
        '
        'FrmMonPercentagePancang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1144, 533)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmMonPercentagePancang"
        Me.Text = "FrmMonPercentagePancang"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.C1DockingTab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1DockingTab1.ResumeLayout(False)
        Me.C1DockingTabPage1.ResumeLayout(False)
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents cmbPancang As ComboBox
    Friend WithEvents chkPancang As CheckBox
    Friend WithEvents dtp2 As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents dtp1 As DateTimePicker
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents scp1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents C1DockingTab1 As C1.Win.C1Command.C1DockingTab
    Friend WithEvents C1DockingTabPage1 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtSum As TextBox
    Friend WithEvents btnexcel As Button
    Friend WithEvents btnrefreshh As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpUm2 As DateTimePicker
    Friend WithEvents dtpUm1 As DateTimePicker
    Friend WithEvents chkUmDate As CheckBox
    Friend WithEvents chkTransDate As CheckBox
End Class
