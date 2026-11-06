<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTrnDokingKapal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTrnDokingKapal))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rdAll = New System.Windows.Forms.RadioButton()
        Me.rdSudahDoking = New System.Windows.Forms.RadioButton()
        Me.rdBelumDoking = New System.Windows.Forms.RadioButton()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CmbPancang = New System.Windows.Forms.ComboBox()
        Me.BtnPerencanaan = New System.Windows.Forms.Button()
        Me.BtnRealisasi = New System.Windows.Forms.Button()
        Me.B = New System.Windows.Forms.Button()
        Me.BtnMon = New System.Windows.Forms.Button()
        Me.BtnRestore = New System.Windows.Forms.Button()
        Me.BtnApproval = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmbKapal = New System.Windows.Forms.ComboBox()
        Me.Dtp2 = New System.Windows.Forms.DateTimePicker()
        Me.Dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.BtnRefresh = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.ChkHistory = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.rdAll)
        Me.Panel1.Controls.Add(Me.rdSudahDoking)
        Me.Panel1.Controls.Add(Me.rdBelumDoking)
        Me.Panel1.Controls.Add(Me.BtnExit)
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Controls.Add(Me.Panel7)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.CmbPancang)
        Me.Panel1.Controls.Add(Me.BtnPerencanaan)
        Me.Panel1.Controls.Add(Me.BtnRealisasi)
        Me.Panel1.Controls.Add(Me.B)
        Me.Panel1.Controls.Add(Me.BtnMon)
        Me.Panel1.Controls.Add(Me.BtnRestore)
        Me.Panel1.Controls.Add(Me.BtnApproval)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1685, 111)
        Me.Panel1.TabIndex = 0
        '
        'rdAll
        '
        Me.rdAll.AutoSize = True
        Me.rdAll.BackColor = System.Drawing.Color.Transparent
        Me.rdAll.Checked = True
        Me.rdAll.Location = New System.Drawing.Point(297, 89)
        Me.rdAll.Name = "rdAll"
        Me.rdAll.Size = New System.Drawing.Size(36, 17)
        Me.rdAll.TabIndex = 38
        Me.rdAll.TabStop = True
        Me.rdAll.Text = "All"
        Me.rdAll.UseVisualStyleBackColor = False
        '
        'rdSudahDoking
        '
        Me.rdSudahDoking.AutoSize = True
        Me.rdSudahDoking.BackColor = System.Drawing.Color.Transparent
        Me.rdSudahDoking.Location = New System.Drawing.Point(492, 89)
        Me.rdSudahDoking.Name = "rdSudahDoking"
        Me.rdSudahDoking.Size = New System.Drawing.Size(149, 17)
        Me.rdSudahDoking.TabIndex = 38
        Me.rdSudahDoking.Text = "Sudah Melakukan Doking"
        Me.rdSudahDoking.UseVisualStyleBackColor = False
        '
        'rdBelumDoking
        '
        Me.rdBelumDoking.AutoSize = True
        Me.rdBelumDoking.BackColor = System.Drawing.Color.Transparent
        Me.rdBelumDoking.Location = New System.Drawing.Point(339, 89)
        Me.rdBelumDoking.Name = "rdBelumDoking"
        Me.rdBelumDoking.Size = New System.Drawing.Size(147, 17)
        Me.rdBelumDoking.TabIndex = 38
        Me.rdBelumDoking.Text = "Belum Melakukan Doking"
        Me.rdBelumDoking.UseVisualStyleBackColor = False
        '
        'BtnExit
        '
        Me.BtnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExit.BackColor = System.Drawing.Color.DodgerBlue
        Me.BtnExit.ForeColor = System.Drawing.Color.White
        Me.BtnExit.Image = Global.RMPApp.My.Resources.Resources.ExitPSN
        Me.BtnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnExit.Location = New System.Drawing.Point(1585, 76)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(93, 32)
        Me.BtnExit.TabIndex = 37
        Me.BtnExit.Text = "Exit"
        Me.BtnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnExit.UseVisualStyleBackColor = False
        '
        'Panel6
        '
        Me.Panel6.BackgroundImage = Global.RMPApp.My.Resources.Resources.iconKapalDoking
        Me.Panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel6.Location = New System.Drawing.Point(5, 3)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(81, 74)
        Me.Panel6.TabIndex = 36
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Black
        Me.Panel7.Location = New System.Drawing.Point(5, 80)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(400, 3)
        Me.Panel7.TabIndex = 35
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(92, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(290, 29)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Transaksi Doking Kapal"
        '
        'CmbPancang
        '
        Me.CmbPancang.FormattingEnabled = True
        Me.CmbPancang.Location = New System.Drawing.Point(54, 87)
        Me.CmbPancang.Name = "CmbPancang"
        Me.CmbPancang.Size = New System.Drawing.Size(232, 21)
        Me.CmbPancang.TabIndex = 30
        '
        'BtnPerencanaan
        '
        Me.BtnPerencanaan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPerencanaan.BackColor = System.Drawing.Color.DodgerBlue
        Me.BtnPerencanaan.ForeColor = System.Drawing.Color.White
        Me.BtnPerencanaan.Image = Global.RMPApp.My.Resources.Resources.Doc1
        Me.BtnPerencanaan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPerencanaan.Location = New System.Drawing.Point(1032, 77)
        Me.BtnPerencanaan.Name = "BtnPerencanaan"
        Me.BtnPerencanaan.Size = New System.Drawing.Size(93, 32)
        Me.BtnPerencanaan.TabIndex = 25
        Me.BtnPerencanaan.Text = "Perencanaan"
        Me.BtnPerencanaan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnPerencanaan.UseVisualStyleBackColor = False
        '
        'BtnRealisasi
        '
        Me.BtnRealisasi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRealisasi.BackColor = System.Drawing.Color.DodgerBlue
        Me.BtnRealisasi.ForeColor = System.Drawing.Color.White
        Me.BtnRealisasi.Image = CType(resources.GetObject("BtnRealisasi.Image"), System.Drawing.Image)
        Me.BtnRealisasi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnRealisasi.Location = New System.Drawing.Point(1125, 77)
        Me.BtnRealisasi.Name = "BtnRealisasi"
        Me.BtnRealisasi.Size = New System.Drawing.Size(93, 32)
        Me.BtnRealisasi.TabIndex = 26
        Me.BtnRealisasi.Text = "Realisasi"
        Me.BtnRealisasi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnRealisasi.UseVisualStyleBackColor = False
        '
        'B
        '
        Me.B.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.B.BackColor = System.Drawing.Color.DodgerBlue
        Me.B.ForeColor = System.Drawing.Color.White
        Me.B.Image = Global.RMPApp.My.Resources.Resources.excel
        Me.B.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.B.Location = New System.Drawing.Point(1494, 77)
        Me.B.Name = "B"
        Me.B.Size = New System.Drawing.Size(93, 32)
        Me.B.TabIndex = 27
        Me.B.Text = "Excel"
        Me.B.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.B.UseVisualStyleBackColor = False
        '
        'BtnMon
        '
        Me.BtnMon.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnMon.BackColor = System.Drawing.Color.DodgerBlue
        Me.BtnMon.ForeColor = System.Drawing.Color.White
        Me.BtnMon.Image = Global.RMPApp.My.Resources.Resources.Monitoring
        Me.BtnMon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnMon.Location = New System.Drawing.Point(1402, 77)
        Me.BtnMon.Name = "BtnMon"
        Me.BtnMon.Size = New System.Drawing.Size(93, 32)
        Me.BtnMon.TabIndex = 27
        Me.BtnMon.Text = "Mnitoring"
        Me.BtnMon.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnMon.UseVisualStyleBackColor = False
        '
        'BtnRestore
        '
        Me.BtnRestore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRestore.BackColor = System.Drawing.Color.DodgerBlue
        Me.BtnRestore.ForeColor = System.Drawing.Color.White
        Me.BtnRestore.Image = Global.RMPApp.My.Resources.Resources.icons8_restart_20
        Me.BtnRestore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnRestore.Location = New System.Drawing.Point(1310, 77)
        Me.BtnRestore.Name = "BtnRestore"
        Me.BtnRestore.Size = New System.Drawing.Size(93, 32)
        Me.BtnRestore.TabIndex = 27
        Me.BtnRestore.Text = "Restore"
        Me.BtnRestore.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnRestore.UseVisualStyleBackColor = False
        '
        'BtnApproval
        '
        Me.BtnApproval.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnApproval.BackColor = System.Drawing.Color.DodgerBlue
        Me.BtnApproval.ForeColor = System.Drawing.Color.White
        Me.BtnApproval.Image = Global.RMPApp.My.Resources.Resources.Mattahan
        Me.BtnApproval.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnApproval.Location = New System.Drawing.Point(1218, 77)
        Me.BtnApproval.Name = "BtnApproval"
        Me.BtnApproval.Size = New System.Drawing.Size(93, 32)
        Me.BtnApproval.TabIndex = 27
        Me.BtnApproval.Text = "Approval"
        Me.BtnApproval.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnApproval.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(2, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Pancang"
        '
        'CmbKapal
        '
        Me.CmbKapal.FormattingEnabled = True
        Me.CmbKapal.Location = New System.Drawing.Point(54, 4)
        Me.CmbKapal.Name = "CmbKapal"
        Me.CmbKapal.Size = New System.Drawing.Size(232, 21)
        Me.CmbKapal.TabIndex = 30
        '
        'Dtp2
        '
        Me.Dtp2.CustomFormat = "MM-yyyy"
        Me.Dtp2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtp2.Location = New System.Drawing.Point(444, 4)
        Me.Dtp2.Name = "Dtp2"
        Me.Dtp2.Size = New System.Drawing.Size(82, 20)
        Me.Dtp2.TabIndex = 29
        '
        'Dtp1
        '
        Me.Dtp1.CustomFormat = "MM-yyyy"
        Me.Dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtp1.Location = New System.Drawing.Point(346, 4)
        Me.Dtp1.Name = "Dtp1"
        Me.Dtp1.Size = New System.Drawing.Size(82, 20)
        Me.Dtp1.TabIndex = 29
        '
        'BtnRefresh
        '
        Me.BtnRefresh.BackColor = System.Drawing.Color.DodgerBlue
        Me.BtnRefresh.ForeColor = System.Drawing.Color.White
        Me.BtnRefresh.Image = Global.RMPApp.My.Resources.Resources.Refresh
        Me.BtnRefresh.Location = New System.Drawing.Point(596, -1)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(32, 32)
        Me.BtnRefresh.TabIndex = 28
        Me.BtnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnRefresh.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(431, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(10, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "-"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(294, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Tanggal"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(2, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 13)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Kapal"
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.C1FlexGridSearchPanel1.BackColor = System.Drawing.Color.Transparent
        Me.C1FlexGridSearchPanel1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(1422, -10)
        Me.C1FlexGridSearchPanel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.ShowClearButton = False
        Me.C1FlexGridSearchPanel1.ShowSearchButton = False
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(286, 38)
        Me.C1FlexGridSearchPanel1.TabIndex = 151
        '
        'Panel8
        '
        Me.Panel8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Panel8.Location = New System.Drawing.Point(1360, 8)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(10, 15)
        Me.Panel8.TabIndex = 38
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel5.Location = New System.Drawing.Point(1296, 8)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(10, 15)
        Me.Panel5.TabIndex = 38
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Panel4.Location = New System.Drawing.Point(1227, 8)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(10, 15)
        Me.Panel4.TabIndex = 38
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Panel3.Location = New System.Drawing.Point(1142, 8)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(10, 15)
        Me.Panel3.TabIndex = 38
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(1155, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 13)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Perencanaan"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(1372, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Approval"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(1308, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Realisasi"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(1240, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Toleransi"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.ChkHistory)
        Me.Panel2.Controls.Add(Me.Panel8)
        Me.Panel2.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Controls.Add(Me.fg)
        Me.Panel2.Controls.Add(Me.CmbKapal)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Dtp2)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Dtp1)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.BtnRefresh)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 111)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel2.Size = New System.Drawing.Size(1685, 512)
        Me.Panel2.TabIndex = 0
        '
        'fg
        '
        Me.fg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fg.ColumnInfo = resources.GetString("fg.ColumnInfo")
        Me.fg.Location = New System.Drawing.Point(5, 29)
        Me.fg.Name = "fg"
        Me.fg.Size = New System.Drawing.Size(1675, 478)
        Me.fg.StyleInfo = resources.GetString("fg.StyleInfo")
        Me.fg.TabIndex = 0
        '
        'ChkHistory
        '
        Me.ChkHistory.AutoSize = True
        Me.ChkHistory.Location = New System.Drawing.Point(532, 7)
        Me.ChkHistory.Name = "ChkHistory"
        Me.ChkHistory.Size = New System.Drawing.Size(58, 17)
        Me.ChkHistory.TabIndex = 39
        Me.ChkHistory.Text = "History"
        Me.ChkHistory.UseVisualStyleBackColor = True
        '
        'FrmTrnDokingKapal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1685, 623)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmTrnDokingKapal"
        Me.Text = "FrmTrnDokingKapal"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents CmbPancang As ComboBox
    Friend WithEvents Dtp1 As DateTimePicker
    Friend WithEvents BtnPerencanaan As Button
    Friend WithEvents BtnRealisasi As Button
    Friend WithEvents BtnApproval As Button
    Friend WithEvents BtnRefresh As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents B As Button
    Friend WithEvents BtnExit As Button
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents BtnMon As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents CmbKapal As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Dtp2 As DateTimePicker
    Friend WithEvents Label9 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents BtnRestore As Button
    Friend WithEvents rdBelumDoking As RadioButton
    Friend WithEvents rdAll As RadioButton
    Friend WithEvents rdSudahDoking As RadioButton
    Friend WithEvents ChkHistory As CheckBox
End Class
