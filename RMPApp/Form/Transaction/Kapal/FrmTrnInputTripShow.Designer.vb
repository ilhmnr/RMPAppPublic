<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTrnInputTripShow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTrnInputTripShow))
        Me.grpFilterData = New XanderUI.XUICustomGroupbox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PanelcmbTrip = New System.Windows.Forms.Panel()
        Me.PanelcmbTrip2 = New System.Windows.Forms.Panel()
        Me.PanelcmbTrip1 = New System.Windows.Forms.Panel()
        Me.cmbTrip = New System.Windows.Forms.ComboBox()
        Me.chkTrip = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PanelKapal = New System.Windows.Forms.Panel()
        Me.PanelKapal2 = New System.Windows.Forms.Panel()
        Me.PanelKapal1 = New System.Windows.Forms.Panel()
        Me.cmbKapal = New System.Windows.Forms.ComboBox()
        Me.chkKapal = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PanelPancang = New System.Windows.Forms.Panel()
        Me.PanelPancang2 = New System.Windows.Forms.Panel()
        Me.PanelPancang1 = New System.Windows.Forms.Panel()
        Me.cmbPancang = New System.Windows.Forms.ComboBox()
        Me.chkPancang = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DTPEnd = New System.Windows.Forms.DateTimePicker()
        Me.DTPStart = New System.Windows.Forms.DateTimePicker()
        Me.chkTransDate = New System.Windows.Forms.CheckBox()
        Me.XuiCustomGroupbox1 = New XanderUI.XUICustomGroupbox()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.schfg = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.grpFilterData.SuspendLayout()
        Me.PanelcmbTrip.SuspendLayout()
        Me.PanelKapal.SuspendLayout()
        Me.PanelPancang.SuspendLayout()
        Me.XuiCustomGroupbox1.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpFilterData
        '
        Me.grpFilterData.BorderColor = System.Drawing.Color.DodgerBlue
        Me.grpFilterData.BorderWidth = 1
        Me.grpFilterData.Controls.Add(Me.btnRefresh)
        Me.grpFilterData.Controls.Add(Me.Label6)
        Me.grpFilterData.Controls.Add(Me.PanelcmbTrip)
        Me.grpFilterData.Controls.Add(Me.chkTrip)
        Me.grpFilterData.Controls.Add(Me.Label4)
        Me.grpFilterData.Controls.Add(Me.PanelKapal)
        Me.grpFilterData.Controls.Add(Me.chkKapal)
        Me.grpFilterData.Controls.Add(Me.Label5)
        Me.grpFilterData.Controls.Add(Me.PanelPancang)
        Me.grpFilterData.Controls.Add(Me.chkPancang)
        Me.grpFilterData.Controls.Add(Me.Label2)
        Me.grpFilterData.Controls.Add(Me.Label1)
        Me.grpFilterData.Controls.Add(Me.DTPEnd)
        Me.grpFilterData.Controls.Add(Me.DTPStart)
        Me.grpFilterData.Controls.Add(Me.chkTransDate)
        Me.grpFilterData.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpFilterData.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpFilterData.Location = New System.Drawing.Point(0, 0)
        Me.grpFilterData.Name = "grpFilterData"
        Me.grpFilterData.ShowText = True
        Me.grpFilterData.Size = New System.Drawing.Size(1039, 82)
        Me.grpFilterData.TabIndex = 3
        Me.grpFilterData.TabStop = False
        Me.grpFilterData.Text = "Filter Data"
        Me.grpFilterData.TextColor = System.Drawing.Color.Navy
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnRefresh.Location = New System.Drawing.Point(943, 45)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(90, 30)
        Me.btnRefresh.TabIndex = 221
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(73, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(11, 17)
        Me.Label6.TabIndex = 215
        Me.Label6.Text = ":"
        '
        'PanelcmbTrip
        '
        Me.PanelcmbTrip.Controls.Add(Me.PanelcmbTrip2)
        Me.PanelcmbTrip.Controls.Add(Me.PanelcmbTrip1)
        Me.PanelcmbTrip.Controls.Add(Me.cmbTrip)
        Me.PanelcmbTrip.Location = New System.Drawing.Point(90, 48)
        Me.PanelcmbTrip.Name = "PanelcmbTrip"
        Me.PanelcmbTrip.Size = New System.Drawing.Size(68, 26)
        Me.PanelcmbTrip.TabIndex = 214
        '
        'PanelcmbTrip2
        '
        Me.PanelcmbTrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PanelcmbTrip2.Location = New System.Drawing.Point(4, 25)
        Me.PanelcmbTrip2.MaximumSize = New System.Drawing.Size(61, 1)
        Me.PanelcmbTrip2.MinimumSize = New System.Drawing.Size(2, 1)
        Me.PanelcmbTrip2.Name = "PanelcmbTrip2"
        Me.PanelcmbTrip2.Size = New System.Drawing.Size(5, 1)
        Me.PanelcmbTrip2.TabIndex = 66
        Me.PanelcmbTrip2.Visible = False
        '
        'PanelcmbTrip1
        '
        Me.PanelcmbTrip1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelcmbTrip1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PanelcmbTrip1.Location = New System.Drawing.Point(4, 25)
        Me.PanelcmbTrip1.Name = "PanelcmbTrip1"
        Me.PanelcmbTrip1.Size = New System.Drawing.Size(61, 1)
        Me.PanelcmbTrip1.TabIndex = 65
        '
        'cmbTrip
        '
        Me.cmbTrip.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTrip.BackColor = System.Drawing.Color.White
        Me.cmbTrip.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbTrip.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTrip.FormattingEnabled = True
        Me.cmbTrip.IntegralHeight = False
        Me.cmbTrip.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50"})
        Me.cmbTrip.Location = New System.Drawing.Point(3, 1)
        Me.cmbTrip.Name = "cmbTrip"
        Me.cmbTrip.Size = New System.Drawing.Size(64, 25)
        Me.cmbTrip.TabIndex = 64
        '
        'chkTrip
        '
        Me.chkTrip.AutoSize = True
        Me.chkTrip.FlatAppearance.BorderSize = 0
        Me.chkTrip.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTrip.Location = New System.Drawing.Point(10, 52)
        Me.chkTrip.Name = "chkTrip"
        Me.chkTrip.Size = New System.Drawing.Size(48, 21)
        Me.chkTrip.TabIndex = 213
        Me.chkTrip.Text = "Trip"
        Me.chkTrip.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(379, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 17)
        Me.Label4.TabIndex = 212
        Me.Label4.Text = ":"
        '
        'PanelKapal
        '
        Me.PanelKapal.Controls.Add(Me.PanelKapal2)
        Me.PanelKapal.Controls.Add(Me.PanelKapal1)
        Me.PanelKapal.Controls.Add(Me.cmbKapal)
        Me.PanelKapal.Location = New System.Drawing.Point(390, 48)
        Me.PanelKapal.Name = "PanelKapal"
        Me.PanelKapal.Size = New System.Drawing.Size(260, 26)
        Me.PanelKapal.TabIndex = 211
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
        Me.PanelKapal1.Size = New System.Drawing.Size(253, 1)
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
        Me.cmbKapal.Size = New System.Drawing.Size(256, 25)
        Me.cmbKapal.TabIndex = 64
        '
        'chkKapal
        '
        Me.chkKapal.AutoSize = True
        Me.chkKapal.FlatAppearance.BorderSize = 0
        Me.chkKapal.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkKapal.Location = New System.Drawing.Point(296, 50)
        Me.chkKapal.Name = "chkKapal"
        Me.chkKapal.Size = New System.Drawing.Size(65, 21)
        Me.chkKapal.TabIndex = 210
        Me.chkKapal.Text = "Kapal"
        Me.chkKapal.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(379, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 17)
        Me.Label5.TabIndex = 207
        Me.Label5.Text = ":"
        '
        'PanelPancang
        '
        Me.PanelPancang.Controls.Add(Me.PanelPancang2)
        Me.PanelPancang.Controls.Add(Me.PanelPancang1)
        Me.PanelPancang.Controls.Add(Me.cmbPancang)
        Me.PanelPancang.Location = New System.Drawing.Point(390, 17)
        Me.PanelPancang.Name = "PanelPancang"
        Me.PanelPancang.Size = New System.Drawing.Size(260, 26)
        Me.PanelPancang.TabIndex = 205
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
        Me.PanelPancang1.Size = New System.Drawing.Size(253, 1)
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
        Me.cmbPancang.Size = New System.Drawing.Size(256, 25)
        Me.cmbPancang.TabIndex = 64
        '
        'chkPancang
        '
        Me.chkPancang.AutoSize = True
        Me.chkPancang.FlatAppearance.BorderSize = 0
        Me.chkPancang.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPancang.Location = New System.Drawing.Point(296, 21)
        Me.chkPancang.Name = "chkPancang"
        Me.chkPancang.Size = New System.Drawing.Size(86, 21)
        Me.chkPancang.TabIndex = 203
        Me.chkPancang.Text = "Pancang"
        Me.chkPancang.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(73, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 17)
        Me.Label2.TabIndex = 195
        Me.Label2.Text = ":"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(182, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 13)
        Me.Label1.TabIndex = 197
        Me.Label1.Text = "-"
        '
        'DTPEnd
        '
        Me.DTPEnd.CustomFormat = "dd MMM yyyy"
        Me.DTPEnd.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPEnd.Location = New System.Drawing.Point(194, 19)
        Me.DTPEnd.Name = "DTPEnd"
        Me.DTPEnd.Size = New System.Drawing.Size(92, 23)
        Me.DTPEnd.TabIndex = 199
        Me.DTPEnd.Value = New Date(2019, 4, 9, 0, 0, 0, 0)
        '
        'DTPStart
        '
        Me.DTPStart.CustomFormat = "dd MMM yyyy"
        Me.DTPStart.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPStart.Location = New System.Drawing.Point(90, 19)
        Me.DTPStart.Name = "DTPStart"
        Me.DTPStart.Size = New System.Drawing.Size(92, 23)
        Me.DTPStart.TabIndex = 198
        Me.DTPStart.Value = New Date(2019, 4, 8, 0, 0, 0, 0)
        '
        'chkTransDate
        '
        Me.chkTransDate.AutoSize = True
        Me.chkTransDate.Checked = True
        Me.chkTransDate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTransDate.FlatAppearance.BorderSize = 0
        Me.chkTransDate.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTransDate.Location = New System.Drawing.Point(10, 20)
        Me.chkTransDate.Name = "chkTransDate"
        Me.chkTransDate.Size = New System.Drawing.Size(59, 21)
        Me.chkTransDate.TabIndex = 196
        Me.chkTransDate.Tag = "1"
        Me.chkTransDate.Text = "Date"
        Me.chkTransDate.UseVisualStyleBackColor = True
        '
        'XuiCustomGroupbox1
        '
        Me.XuiCustomGroupbox1.BorderColor = System.Drawing.Color.DodgerBlue
        Me.XuiCustomGroupbox1.BorderWidth = 1
        Me.XuiCustomGroupbox1.Controls.Add(Me.fg)
        Me.XuiCustomGroupbox1.Controls.Add(Me.schfg)
        Me.XuiCustomGroupbox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XuiCustomGroupbox1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XuiCustomGroupbox1.Location = New System.Drawing.Point(0, 82)
        Me.XuiCustomGroupbox1.Name = "XuiCustomGroupbox1"
        Me.XuiCustomGroupbox1.ShowText = True
        Me.XuiCustomGroupbox1.Size = New System.Drawing.Size(1039, 406)
        Me.XuiCustomGroupbox1.TabIndex = 4
        Me.XuiCustomGroupbox1.TabStop = False
        Me.XuiCustomGroupbox1.Text = "List Nota With Trip"
        Me.XuiCustomGroupbox1.TextColor = System.Drawing.Color.Navy
        '
        'fg
        '
        Me.fg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fg.ColumnInfo = resources.GetString("fg.ColumnInfo")
        Me.fg.ForeColor = System.Drawing.Color.Black
        Me.fg.Location = New System.Drawing.Point(6, 22)
        Me.fg.Name = "fg"
        Me.fg.Rows.Count = 2
        Me.fg.Rows.DefaultSize = 22
        Me.fg.Size = New System.Drawing.Size(1027, 381)
        Me.fg.StyleInfo = resources.GetString("fg.StyleInfo")
        Me.fg.TabIndex = 196
        '
        'schfg
        '
        Me.schfg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.schfg.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.schfg.Location = New System.Drawing.Point(565, -15)
        Me.schfg.Margin = New System.Windows.Forms.Padding(1)
        Me.schfg.Name = "schfg"
        Me.schfg.ShowClearButton = False
        Me.schfg.ShowSearchButton = False
        Me.schfg.Size = New System.Drawing.Size(503, 32)
        Me.schfg.TabIndex = 222
        '
        'FrmInputTrip_Show
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1039, 488)
        Me.Controls.Add(Me.XuiCustomGroupbox1)
        Me.Controls.Add(Me.grpFilterData)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmInputTrip_Show"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "List Trip"
        Me.grpFilterData.ResumeLayout(False)
        Me.grpFilterData.PerformLayout()
        Me.PanelcmbTrip.ResumeLayout(False)
        Me.PanelKapal.ResumeLayout(False)
        Me.PanelPancang.ResumeLayout(False)
        Me.XuiCustomGroupbox1.ResumeLayout(False)
        Me.XuiCustomGroupbox1.PerformLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grpFilterData As XanderUI.XUICustomGroupbox
    Friend WithEvents btnRefresh As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents PanelcmbTrip As Panel
    Friend WithEvents PanelcmbTrip2 As Panel
    Friend WithEvents PanelcmbTrip1 As Panel
    Friend WithEvents cmbTrip As ComboBox
    Friend WithEvents chkTrip As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents PanelKapal As Panel
    Friend WithEvents PanelKapal2 As Panel
    Friend WithEvents PanelKapal1 As Panel
    Friend WithEvents cmbKapal As ComboBox
    Friend WithEvents chkKapal As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents PanelPancang As Panel
    Friend WithEvents PanelPancang2 As Panel
    Friend WithEvents PanelPancang1 As Panel
    Friend WithEvents cmbPancang As ComboBox
    Friend WithEvents chkPancang As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents DTPEnd As DateTimePicker
    Friend WithEvents DTPStart As DateTimePicker
    Friend WithEvents chkTransDate As CheckBox
    Friend WithEvents XuiCustomGroupbox1 As XanderUI.XUICustomGroupbox
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents schfg As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
End Class
