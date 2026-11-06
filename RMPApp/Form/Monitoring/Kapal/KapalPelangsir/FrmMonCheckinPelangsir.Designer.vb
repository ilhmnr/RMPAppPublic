<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMonCheckinPelangsir
    'Inherits System.Windows.Forms.Form
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
        Me.components = New System.ComponentModel.Container()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.XuiCustomGroupbox1 = New XanderUI.XUICustomGroupbox()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.grpFilterData = New XanderUI.XUICustomGroupbox()
        Me.labelInfo = New System.Windows.Forms.Label()
        Me.rdAll = New System.Windows.Forms.RadioButton()
        Me.rdClose = New System.Windows.Forms.RadioButton()
        Me.rdBooking = New System.Windows.Forms.RadioButton()
        Me.rdMuat = New System.Windows.Forms.RadioButton()
        Me.rdCheckin = New System.Windows.Forms.RadioButton()
        Me.cmbPancang = New System.Windows.Forms.ComboBox()
        Me.tgl2 = New System.Windows.Forms.DateTimePicker()
        Me.tgl1 = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.rdcungkil = New System.Windows.Forms.RadioButton()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.XuiCustomGroupbox1.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.grpFilterData.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1102, 64)
        Me.Panel1.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.White
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Location = New System.Drawing.Point(340, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(505, 64)
        Me.Panel5.TabIndex = 0
        '
        'Panel6
        '
        Me.Panel6.BackgroundImage = Global.RMPApp.My.Resources.Resources.icon_checkin_pelangsir
        Me.Panel6.Location = New System.Drawing.Point(1, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(64, 64)
        Me.Panel6.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Georgia", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(71, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(433, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Monitoring Checkin Pelangsir"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 64)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Panel2.Size = New System.Drawing.Size(1102, 474)
        Me.Panel2.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.XuiCustomGroupbox1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(5, 113)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.Panel4.Size = New System.Drawing.Size(1092, 361)
        Me.Panel4.TabIndex = 0
        '
        'XuiCustomGroupbox1
        '
        Me.XuiCustomGroupbox1.BorderColor = System.Drawing.Color.DodgerBlue
        Me.XuiCustomGroupbox1.BorderWidth = 1
        Me.XuiCustomGroupbox1.Controls.Add(Me.fg)
        Me.XuiCustomGroupbox1.Controls.Add(Me.RadioButton1)
        Me.XuiCustomGroupbox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XuiCustomGroupbox1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XuiCustomGroupbox1.Location = New System.Drawing.Point(0, 0)
        Me.XuiCustomGroupbox1.Name = "XuiCustomGroupbox1"
        Me.XuiCustomGroupbox1.ShowText = True
        Me.XuiCustomGroupbox1.Size = New System.Drawing.Size(1092, 356)
        Me.XuiCustomGroupbox1.TabIndex = 16
        Me.XuiCustomGroupbox1.TabStop = False
        Me.XuiCustomGroupbox1.Text = "View"
        Me.XuiCustomGroupbox1.TextColor = System.Drawing.Color.Navy
        '
        'fg
        '
        Me.fg.ColumnInfo = "10,1,0,0,0,-1,Columns:"
        Me.fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fg.Location = New System.Drawing.Point(3, 19)
        Me.fg.Name = "fg"
        Me.fg.Size = New System.Drawing.Size(1086, 334)
        Me.fg.TabIndex = 275
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(1408, 19)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(75, 21)
        Me.RadioButton1.TabIndex = 250
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Cungkil"
        Me.RadioButton1.UseVisualStyleBackColor = True
        Me.RadioButton1.Visible = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.grpFilterData)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(5, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1092, 113)
        Me.Panel3.TabIndex = 0
        '
        'grpFilterData
        '
        Me.grpFilterData.BorderColor = System.Drawing.Color.DodgerBlue
        Me.grpFilterData.BorderWidth = 1
        Me.grpFilterData.Controls.Add(Me.labelInfo)
        Me.grpFilterData.Controls.Add(Me.rdAll)
        Me.grpFilterData.Controls.Add(Me.rdClose)
        Me.grpFilterData.Controls.Add(Me.rdBooking)
        Me.grpFilterData.Controls.Add(Me.rdMuat)
        Me.grpFilterData.Controls.Add(Me.rdCheckin)
        Me.grpFilterData.Controls.Add(Me.cmbPancang)
        Me.grpFilterData.Controls.Add(Me.tgl2)
        Me.grpFilterData.Controls.Add(Me.tgl1)
        Me.grpFilterData.Controls.Add(Me.Label3)
        Me.grpFilterData.Controls.Add(Me.Label4)
        Me.grpFilterData.Controls.Add(Me.Label5)
        Me.grpFilterData.Controls.Add(Me.Label8)
        Me.grpFilterData.Controls.Add(Me.Label7)
        Me.grpFilterData.Controls.Add(Me.Label6)
        Me.grpFilterData.Controls.Add(Me.Label2)
        Me.grpFilterData.Controls.Add(Me.btnExit)
        Me.grpFilterData.Controls.Add(Me.rdcungkil)
        Me.grpFilterData.Controls.Add(Me.btnExcel)
        Me.grpFilterData.Controls.Add(Me.btnRefresh)
        Me.grpFilterData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpFilterData.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpFilterData.Location = New System.Drawing.Point(0, 0)
        Me.grpFilterData.Name = "grpFilterData"
        Me.grpFilterData.ShowText = True
        Me.grpFilterData.Size = New System.Drawing.Size(1092, 113)
        Me.grpFilterData.TabIndex = 15
        Me.grpFilterData.TabStop = False
        Me.grpFilterData.Text = "Filter Data"
        Me.grpFilterData.TextColor = System.Drawing.Color.Navy
        '
        'labelInfo
        '
        Me.labelInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.labelInfo.AutoSize = True
        Me.labelInfo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelInfo.Location = New System.Drawing.Point(467, 19)
        Me.labelInfo.Name = "labelInfo"
        Me.labelInfo.Size = New System.Drawing.Size(613, 16)
        Me.labelInfo.TabIndex = 280
        Me.labelInfo.Text = "Klik 2x Pada Baris Untuk Menampilkan Gambar                                      " &
    "                                    "
        '
        'rdAll
        '
        Me.rdAll.AutoSize = True
        Me.rdAll.Location = New System.Drawing.Point(429, 51)
        Me.rdAll.Name = "rdAll"
        Me.rdAll.Size = New System.Drawing.Size(41, 21)
        Me.rdAll.TabIndex = 278
        Me.rdAll.Text = "All"
        Me.rdAll.UseVisualStyleBackColor = True
        '
        'rdClose
        '
        Me.rdClose.AutoSize = True
        Me.rdClose.Location = New System.Drawing.Point(361, 51)
        Me.rdClose.Name = "rdClose"
        Me.rdClose.Size = New System.Drawing.Size(62, 21)
        Me.rdClose.TabIndex = 278
        Me.rdClose.Text = "Close"
        Me.rdClose.UseVisualStyleBackColor = True
        '
        'rdBooking
        '
        Me.rdBooking.AutoSize = True
        Me.rdBooking.Checked = True
        Me.rdBooking.Location = New System.Drawing.Point(127, 51)
        Me.rdBooking.Name = "rdBooking"
        Me.rdBooking.Size = New System.Drawing.Size(78, 21)
        Me.rdBooking.TabIndex = 278
        Me.rdBooking.TabStop = True
        Me.rdBooking.Text = "Booking"
        Me.rdBooking.UseVisualStyleBackColor = True
        '
        'rdMuat
        '
        Me.rdMuat.AutoSize = True
        Me.rdMuat.Location = New System.Drawing.Point(296, 51)
        Me.rdMuat.Name = "rdMuat"
        Me.rdMuat.Size = New System.Drawing.Size(59, 21)
        Me.rdMuat.TabIndex = 278
        Me.rdMuat.Text = "Muat"
        Me.rdMuat.UseVisualStyleBackColor = True
        '
        'rdCheckin
        '
        Me.rdCheckin.AutoSize = True
        Me.rdCheckin.Location = New System.Drawing.Point(211, 51)
        Me.rdCheckin.Name = "rdCheckin"
        Me.rdCheckin.Size = New System.Drawing.Size(79, 21)
        Me.rdCheckin.TabIndex = 278
        Me.rdCheckin.Text = "Checkin"
        Me.rdCheckin.UseVisualStyleBackColor = True
        '
        'cmbPancang
        '
        Me.cmbPancang.FormattingEnabled = True
        Me.cmbPancang.Location = New System.Drawing.Point(127, 77)
        Me.cmbPancang.Name = "cmbPancang"
        Me.cmbPancang.Size = New System.Drawing.Size(326, 25)
        Me.cmbPancang.TabIndex = 277
        '
        'tgl2
        '
        Me.tgl2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.tgl2.Location = New System.Drawing.Point(264, 22)
        Me.tgl2.Name = "tgl2"
        Me.tgl2.Size = New System.Drawing.Size(113, 23)
        Me.tgl2.TabIndex = 276
        '
        'tgl1
        '
        Me.tgl1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.tgl1.Location = New System.Drawing.Point(127, 22)
        Me.tgl1.Name = "tgl1"
        Me.tgl1.Size = New System.Drawing.Size(113, 23)
        Me.tgl1.TabIndex = 276
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 17)
        Me.Label3.TabIndex = 275
        Me.Label3.Text = "Checkin Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(246, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 17)
        Me.Label4.TabIndex = 275
        Me.Label4.Text = "-"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 17)
        Me.Label5.TabIndex = 275
        Me.Label5.Text = "Status Antri"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(109, 81)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(12, 17)
        Me.Label8.TabIndex = 275
        Me.Label8.Text = ":"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(109, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(12, 17)
        Me.Label7.TabIndex = 275
        Me.Label7.Text = ":"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(109, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(12, 17)
        Me.Label6.TabIndex = 275
        Me.Label6.Text = ":"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 17)
        Me.Label2.TabIndex = 275
        Me.Label2.Text = "Pancang"
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnExit.Location = New System.Drawing.Point(996, 76)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(84, 26)
        Me.btnExit.TabIndex = 273
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'rdcungkil
        '
        Me.rdcungkil.AutoSize = True
        Me.rdcungkil.Location = New System.Drawing.Point(1408, 19)
        Me.rdcungkil.Name = "rdcungkil"
        Me.rdcungkil.Size = New System.Drawing.Size(75, 21)
        Me.rdcungkil.TabIndex = 250
        Me.rdcungkil.Text = "Cungkil"
        Me.rdcungkil.UseVisualStyleBackColor = True
        Me.rdcungkil.Visible = False
        '
        'btnExcel
        '
        Me.btnExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExcel.BackColor = System.Drawing.Color.ForestGreen
        Me.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExcel.FlatAppearance.BorderSize = 0
        Me.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcel.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnExcel.Location = New System.Drawing.Point(911, 76)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(79, 26)
        Me.btnExcel.TabIndex = 222
        Me.btnExcel.Text = "Excel"
        Me.btnExcel.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnRefresh.Location = New System.Drawing.Point(459, 76)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(79, 26)
        Me.btnRefresh.TabIndex = 222
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        '
        'FrmMonCheckinPelangsir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1102, 538)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmMonCheckinPelangsir"
        Me.Text = "FrmMonCheckinPelangsir"
        Me.Panel1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.XuiCustomGroupbox1.ResumeLayout(False)
        Me.XuiCustomGroupbox1.PerformLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.grpFilterData.ResumeLayout(False)
        Me.grpFilterData.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents grpFilterData As XanderUI.XUICustomGroupbox
    Friend WithEvents btnExit As Button
    Friend WithEvents rdcungkil As RadioButton
    Friend WithEvents btnRefresh As Button
    Friend WithEvents XuiCustomGroupbox1 As XanderUI.XUICustomGroupbox
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents rdAll As RadioButton
    Friend WithEvents rdClose As RadioButton
    Friend WithEvents rdMuat As RadioButton
    Friend WithEvents rdCheckin As RadioButton
    Friend WithEvents cmbPancang As ComboBox
    Friend WithEvents tgl2 As DateTimePicker
    Friend WithEvents tgl1 As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents rdBooking As RadioButton
    Friend WithEvents Timer1 As Timer
    Friend WithEvents labelInfo As Label
    Friend WithEvents btnExcel As Button
End Class
