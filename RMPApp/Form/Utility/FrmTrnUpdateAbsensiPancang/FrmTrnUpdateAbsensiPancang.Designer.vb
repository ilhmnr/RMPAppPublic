<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTrnUpdateAbsensiPancang
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTrnUpdateAbsensiPancang))
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cboBagian = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkBagian = New System.Windows.Forms.CheckBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.PanelKapal2 = New System.Windows.Forms.Panel()
        Me.PanelKapal1 = New System.Windows.Forms.Panel()
        Me.cboJabatan = New System.Windows.Forms.ComboBox()
        Me.dtpTanggal2 = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.grpDataTimbangPancang = New XanderUI.XUICustomGroupbox()
        Me.scp = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.PanelPancang1 = New System.Windows.Forms.Panel()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.dtpTanggal = New System.Windows.Forms.DateTimePicker()
        Me.chkTanggal = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.cboPancang = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkStatus = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PanelPancang = New System.Windows.Forms.Panel()
        Me.PanelPancang2 = New System.Windows.Forms.Panel()
        Me.chkPancang = New System.Windows.Forms.CheckBox()
        Me.dtpPeriode = New System.Windows.Forms.DateTimePicker()
        Me.chkPeriode = New System.Windows.Forms.CheckBox()
        Me.PanelKapal = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkJabatan = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grpFilterData = New XanderUI.XUICustomGroupbox()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.XuiCustomGroupbox3 = New XanderUI.XUICustomGroupbox()
        Me.BtnEdit = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.XuiCustomGroupbox2 = New XanderUI.XUICustomGroupbox()
        Me.XuiCustomGroupbox4 = New XanderUI.XUICustomGroupbox()
        Me.CmbKehadiran = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtKeterangan = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ChkTidakHitungLembur = New System.Windows.Forms.CheckBox()
        Me.ChkTidakHitungUangMakan = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtJabatan = New System.Windows.Forms.TextBox()
        Me.TxtTanggalAbsen = New System.Windows.Forms.TextBox()
        Me.TxtLiburMingguan = New System.Windows.Forms.TextBox()
        Me.TxtStatus = New System.Windows.Forms.TextBox()
        Me.TxtNik = New System.Windows.Forms.TextBox()
        Me.TxtPancang = New System.Windows.Forms.TextBox()
        Me.TxtNama = New System.Windows.Forms.TextBox()
        Me.TxtBagian = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.XuiCustomGroupbox1 = New XanderUI.XUICustomGroupbox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ChkIdPersonil = New System.Windows.Forms.CheckBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.CmbIdPersonil = New System.Windows.Forms.ComboBox()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDataTimbangPancang.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PanelPancang.SuspendLayout()
        Me.PanelKapal.SuspendLayout()
        Me.grpFilterData.SuspendLayout()
        Me.XuiCustomGroupbox3.SuspendLayout()
        Me.XuiCustomGroupbox2.SuspendLayout()
        Me.XuiCustomGroupbox4.SuspendLayout()
        Me.XuiCustomGroupbox1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
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
        Me.fg.Rows.Count = 4
        Me.fg.Rows.DefaultSize = 22
        Me.fg.Size = New System.Drawing.Size(1536, 387)
        Me.fg.StyleInfo = resources.GetString("fg.StyleInfo")
        Me.fg.TabIndex = 9
        '
        'cboBagian
        '
        Me.cboBagian.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cboBagian.BackColor = System.Drawing.Color.White
        Me.cboBagian.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBagian.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBagian.FormattingEnabled = True
        Me.cboBagian.IntegralHeight = False
        Me.cboBagian.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cboBagian.Location = New System.Drawing.Point(519, 52)
        Me.cboBagian.Name = "cboBagian"
        Me.cboBagian.Size = New System.Drawing.Size(259, 25)
        Me.cboBagian.TabIndex = 253
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(502, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(11, 17)
        Me.Label7.TabIndex = 255
        Me.Label7.Text = ":"
        '
        'chkBagian
        '
        Me.chkBagian.AutoSize = True
        Me.chkBagian.FlatAppearance.BorderSize = 0
        Me.chkBagian.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBagian.Location = New System.Drawing.Point(421, 54)
        Me.chkBagian.Name = "chkBagian"
        Me.chkBagian.Size = New System.Drawing.Size(72, 21)
        Me.chkBagian.TabIndex = 254
        Me.chkBagian.Text = "Bagian"
        Me.chkBagian.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.Teal
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnCancel.Location = New System.Drawing.Point(594, 14)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(95, 30)
        Me.btnCancel.TabIndex = 249
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
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
        Me.PanelKapal1.Size = New System.Drawing.Size(252, 1)
        Me.PanelKapal1.TabIndex = 65
        '
        'cboJabatan
        '
        Me.cboJabatan.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboJabatan.BackColor = System.Drawing.Color.White
        Me.cboJabatan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboJabatan.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboJabatan.FormattingEnabled = True
        Me.cboJabatan.IntegralHeight = False
        Me.cboJabatan.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cboJabatan.Location = New System.Drawing.Point(3, 1)
        Me.cboJabatan.Name = "cboJabatan"
        Me.cboJabatan.Size = New System.Drawing.Size(255, 25)
        Me.cboJabatan.TabIndex = 64
        '
        'dtpTanggal2
        '
        Me.dtpTanggal2.CustomFormat = "dd MMM yyyy"
        Me.dtpTanggal2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTanggal2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTanggal2.Location = New System.Drawing.Point(635, 24)
        Me.dtpTanggal2.Name = "dtpTanggal2"
        Me.dtpTanggal2.Size = New System.Drawing.Size(91, 23)
        Me.dtpTanggal2.TabIndex = 247
        Me.dtpTanggal2.Value = New Date(2019, 4, 8, 0, 0, 0, 0)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(616, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(13, 16)
        Me.Label6.TabIndex = 246
        Me.Label6.Text = "-"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.LightCoral
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnClose.Location = New System.Drawing.Point(695, 14)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(95, 30)
        Me.btnClose.TabIndex = 244
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'grpDataTimbangPancang
        '
        Me.grpDataTimbangPancang.BackColor = System.Drawing.Color.LightCyan
        Me.grpDataTimbangPancang.BorderColor = System.Drawing.Color.Black
        Me.grpDataTimbangPancang.BorderWidth = 1
        Me.grpDataTimbangPancang.Controls.Add(Me.fg)
        Me.grpDataTimbangPancang.Controls.Add(Me.scp)
        Me.grpDataTimbangPancang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDataTimbangPancang.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDataTimbangPancang.Location = New System.Drawing.Point(0, 271)
        Me.grpDataTimbangPancang.Name = "grpDataTimbangPancang"
        Me.grpDataTimbangPancang.ShowText = True
        Me.grpDataTimbangPancang.Size = New System.Drawing.Size(1548, 414)
        Me.grpDataTimbangPancang.TabIndex = 100
        Me.grpDataTimbangPancang.TabStop = False
        Me.grpDataTimbangPancang.Text = "Data Absensi Pancang"
        Me.grpDataTimbangPancang.TextColor = System.Drawing.Color.Black
        '
        'scp
        '
        Me.scp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.scp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.scp.Location = New System.Drawing.Point(1206, -14)
        Me.scp.Name = "scp"
        Me.scp.ShowClearButton = False
        Me.scp.ShowSearchButton = False
        Me.scp.Size = New System.Drawing.Size(370, 35)
        Me.scp.TabIndex = 170
        '
        'PanelPancang1
        '
        Me.PanelPancang1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelPancang1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PanelPancang1.Location = New System.Drawing.Point(4, 25)
        Me.PanelPancang1.Name = "PanelPancang1"
        Me.PanelPancang1.Size = New System.Drawing.Size(252, 1)
        Me.PanelPancang1.TabIndex = 65
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.Teal
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnRefresh.Location = New System.Drawing.Point(291, 14)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(95, 30)
        Me.btnRefresh.TabIndex = 241
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'dtpTanggal
        '
        Me.dtpTanggal.CustomFormat = "dd MMM yyyy"
        Me.dtpTanggal.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTanggal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTanggal.Location = New System.Drawing.Point(519, 24)
        Me.dtpTanggal.Name = "dtpTanggal"
        Me.dtpTanggal.Size = New System.Drawing.Size(91, 23)
        Me.dtpTanggal.TabIndex = 240
        Me.dtpTanggal.Value = New Date(2019, 4, 8, 0, 0, 0, 0)
        '
        'chkTanggal
        '
        Me.chkTanggal.AutoSize = True
        Me.chkTanggal.FlatAppearance.BorderSize = 0
        Me.chkTanggal.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTanggal.Location = New System.Drawing.Point(421, 25)
        Me.chkTanggal.Name = "chkTanggal"
        Me.chkTanggal.Size = New System.Drawing.Size(79, 21)
        Me.chkTanggal.TabIndex = 239
        Me.chkTanggal.Tag = "1"
        Me.chkTanggal.Text = "Tanggal"
        Me.chkTanggal.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(502, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 17)
        Me.Label3.TabIndex = 238
        Me.Label3.Text = ":"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.cboStatus)
        Me.Panel1.Location = New System.Drawing.Point(126, 109)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(259, 26)
        Me.Panel1.TabIndex = 236
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(4, 25)
        Me.Panel2.MaximumSize = New System.Drawing.Size(412, 1)
        Me.Panel2.MinimumSize = New System.Drawing.Size(2, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(5, 1)
        Me.Panel2.TabIndex = 66
        Me.Panel2.Visible = False
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel3.Location = New System.Drawing.Point(4, 25)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(252, 1)
        Me.Panel3.TabIndex = 65
        '
        'cboStatus
        '
        Me.cboStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboStatus.BackColor = System.Drawing.Color.White
        Me.cboStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboStatus.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.IntegralHeight = False
        Me.cboStatus.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cboStatus.Location = New System.Drawing.Point(3, 1)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(255, 25)
        Me.cboStatus.TabIndex = 64
        '
        'cboPancang
        '
        Me.cboPancang.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPancang.BackColor = System.Drawing.Color.White
        Me.cboPancang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPancang.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPancang.FormattingEnabled = True
        Me.cboPancang.IntegralHeight = False
        Me.cboPancang.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cboPancang.Location = New System.Drawing.Point(3, 1)
        Me.cboPancang.Name = "cboPancang"
        Me.cboPancang.Size = New System.Drawing.Size(255, 25)
        Me.cboPancang.TabIndex = 64
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(108, 114)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 17)
        Me.Label1.TabIndex = 237
        Me.Label1.Text = ":"
        '
        'chkStatus
        '
        Me.chkStatus.AutoSize = True
        Me.chkStatus.FlatAppearance.BorderSize = 0
        Me.chkStatus.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkStatus.Location = New System.Drawing.Point(16, 112)
        Me.chkStatus.Name = "chkStatus"
        Me.chkStatus.Size = New System.Drawing.Size(65, 21)
        Me.chkStatus.TabIndex = 235
        Me.chkStatus.Text = "Status"
        Me.chkStatus.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(108, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 17)
        Me.Label5.TabIndex = 207
        Me.Label5.Text = ":"
        '
        'PanelPancang
        '
        Me.PanelPancang.Controls.Add(Me.PanelPancang2)
        Me.PanelPancang.Controls.Add(Me.PanelPancang1)
        Me.PanelPancang.Controls.Add(Me.cboPancang)
        Me.PanelPancang.Location = New System.Drawing.Point(126, 51)
        Me.PanelPancang.Name = "PanelPancang"
        Me.PanelPancang.Size = New System.Drawing.Size(259, 26)
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
        'chkPancang
        '
        Me.chkPancang.AutoSize = True
        Me.chkPancang.FlatAppearance.BorderSize = 0
        Me.chkPancang.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPancang.Location = New System.Drawing.Point(16, 54)
        Me.chkPancang.Name = "chkPancang"
        Me.chkPancang.Size = New System.Drawing.Size(86, 21)
        Me.chkPancang.TabIndex = 203
        Me.chkPancang.Text = "Pancang"
        Me.chkPancang.UseVisualStyleBackColor = True
        '
        'dtpPeriode
        '
        Me.dtpPeriode.CustomFormat = " MMM yyyy"
        Me.dtpPeriode.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpPeriode.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPeriode.Location = New System.Drawing.Point(519, 82)
        Me.dtpPeriode.Name = "dtpPeriode"
        Me.dtpPeriode.Size = New System.Drawing.Size(91, 23)
        Me.dtpPeriode.TabIndex = 206
        Me.dtpPeriode.Value = New Date(2019, 4, 8, 0, 0, 0, 0)
        Me.dtpPeriode.Visible = False
        '
        'chkPeriode
        '
        Me.chkPeriode.AutoSize = True
        Me.chkPeriode.FlatAppearance.BorderSize = 0
        Me.chkPeriode.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPeriode.Location = New System.Drawing.Point(421, 83)
        Me.chkPeriode.Name = "chkPeriode"
        Me.chkPeriode.Size = New System.Drawing.Size(76, 21)
        Me.chkPeriode.TabIndex = 204
        Me.chkPeriode.Tag = "1"
        Me.chkPeriode.Text = "Periode"
        Me.chkPeriode.UseVisualStyleBackColor = True
        Me.chkPeriode.Visible = False
        '
        'PanelKapal
        '
        Me.PanelKapal.Controls.Add(Me.PanelKapal2)
        Me.PanelKapal.Controls.Add(Me.PanelKapal1)
        Me.PanelKapal.Controls.Add(Me.cboJabatan)
        Me.PanelKapal.Location = New System.Drawing.Point(126, 80)
        Me.PanelKapal.Name = "PanelKapal"
        Me.PanelKapal.Size = New System.Drawing.Size(259, 26)
        Me.PanelKapal.TabIndex = 217
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(108, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 17)
        Me.Label4.TabIndex = 218
        Me.Label4.Text = ":"
        '
        'chkJabatan
        '
        Me.chkJabatan.AutoSize = True
        Me.chkJabatan.FlatAppearance.BorderSize = 0
        Me.chkJabatan.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkJabatan.Location = New System.Drawing.Point(16, 83)
        Me.chkJabatan.Name = "chkJabatan"
        Me.chkJabatan.Size = New System.Drawing.Size(82, 21)
        Me.chkJabatan.TabIndex = 216
        Me.chkJabatan.Text = "Jabatan"
        Me.chkJabatan.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(502, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 17)
        Me.Label2.TabIndex = 203
        Me.Label2.Text = ":"
        Me.Label2.Visible = False
        '
        'grpFilterData
        '
        Me.grpFilterData.BackColor = System.Drawing.Color.LightCyan
        Me.grpFilterData.BorderColor = System.Drawing.Color.Black
        Me.grpFilterData.BorderWidth = 1
        Me.grpFilterData.Controls.Add(Me.lblInfo)
        Me.grpFilterData.Controls.Add(Me.XuiCustomGroupbox3)
        Me.grpFilterData.Controls.Add(Me.XuiCustomGroupbox2)
        Me.grpFilterData.Controls.Add(Me.XuiCustomGroupbox1)
        Me.grpFilterData.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpFilterData.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpFilterData.Location = New System.Drawing.Point(0, 0)
        Me.grpFilterData.Name = "grpFilterData"
        Me.grpFilterData.ShowText = True
        Me.grpFilterData.Size = New System.Drawing.Size(1548, 271)
        Me.grpFilterData.TabIndex = 99
        Me.grpFilterData.TabStop = False
        Me.grpFilterData.TextColor = System.Drawing.Color.Black
        '
        'lblInfo
        '
        Me.lblInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblInfo.BackColor = System.Drawing.Color.Black
        Me.lblInfo.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.ForeColor = System.Drawing.Color.Lime
        Me.lblInfo.Location = New System.Drawing.Point(746, 240)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(796, 24)
        Me.lblInfo.TabIndex = 263
        Me.lblInfo.Text = "Double Click Id Personil Untuk Menampilkan Foto                                  " &
    "                                                                                " &
    "                                      "
        '
        'XuiCustomGroupbox3
        '
        Me.XuiCustomGroupbox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XuiCustomGroupbox3.BackColor = System.Drawing.Color.LightCyan
        Me.XuiCustomGroupbox3.BorderColor = System.Drawing.Color.Black
        Me.XuiCustomGroupbox3.BorderWidth = 1
        Me.XuiCustomGroupbox3.Controls.Add(Me.btnCancel)
        Me.XuiCustomGroupbox3.Controls.Add(Me.BtnEdit)
        Me.XuiCustomGroupbox3.Controls.Add(Me.BtnSave)
        Me.XuiCustomGroupbox3.Controls.Add(Me.btnRefresh)
        Me.XuiCustomGroupbox3.Controls.Add(Me.btnClose)
        Me.XuiCustomGroupbox3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XuiCustomGroupbox3.Location = New System.Drawing.Point(746, 183)
        Me.XuiCustomGroupbox3.Name = "XuiCustomGroupbox3"
        Me.XuiCustomGroupbox3.ShowText = True
        Me.XuiCustomGroupbox3.Size = New System.Drawing.Size(796, 54)
        Me.XuiCustomGroupbox3.TabIndex = 261
        Me.XuiCustomGroupbox3.TabStop = False
        Me.XuiCustomGroupbox3.Text = "Button Aksi"
        Me.XuiCustomGroupbox3.TextColor = System.Drawing.Color.Black
        '
        'BtnEdit
        '
        Me.BtnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEdit.BackColor = System.Drawing.Color.Teal
        Me.BtnEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnEdit.FlatAppearance.BorderSize = 0
        Me.BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEdit.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEdit.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BtnEdit.Location = New System.Drawing.Point(392, 14)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(95, 30)
        Me.BtnEdit.TabIndex = 241
        Me.BtnEdit.Text = "Edit"
        Me.BtnEdit.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.BackColor = System.Drawing.Color.Teal
        Me.BtnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSave.FlatAppearance.BorderSize = 0
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BtnSave.Location = New System.Drawing.Point(493, 14)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(95, 30)
        Me.BtnSave.TabIndex = 241
        Me.BtnSave.Text = "Save"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'XuiCustomGroupbox2
        '
        Me.XuiCustomGroupbox2.BackColor = System.Drawing.Color.LightCyan
        Me.XuiCustomGroupbox2.BorderColor = System.Drawing.Color.Black
        Me.XuiCustomGroupbox2.BorderWidth = 1
        Me.XuiCustomGroupbox2.Controls.Add(Me.XuiCustomGroupbox4)
        Me.XuiCustomGroupbox2.Controls.Add(Me.TxtJabatan)
        Me.XuiCustomGroupbox2.Controls.Add(Me.TxtTanggalAbsen)
        Me.XuiCustomGroupbox2.Controls.Add(Me.TxtLiburMingguan)
        Me.XuiCustomGroupbox2.Controls.Add(Me.TxtStatus)
        Me.XuiCustomGroupbox2.Controls.Add(Me.TxtNik)
        Me.XuiCustomGroupbox2.Controls.Add(Me.TxtPancang)
        Me.XuiCustomGroupbox2.Controls.Add(Me.TxtNama)
        Me.XuiCustomGroupbox2.Controls.Add(Me.TxtBagian)
        Me.XuiCustomGroupbox2.Controls.Add(Me.Label11)
        Me.XuiCustomGroupbox2.Controls.Add(Me.Label29)
        Me.XuiCustomGroupbox2.Controls.Add(Me.Label28)
        Me.XuiCustomGroupbox2.Controls.Add(Me.Label23)
        Me.XuiCustomGroupbox2.Controls.Add(Me.Label27)
        Me.XuiCustomGroupbox2.Controls.Add(Me.Label25)
        Me.XuiCustomGroupbox2.Controls.Add(Me.Label24)
        Me.XuiCustomGroupbox2.Controls.Add(Me.Label22)
        Me.XuiCustomGroupbox2.Controls.Add(Me.Label10)
        Me.XuiCustomGroupbox2.Controls.Add(Me.Label14)
        Me.XuiCustomGroupbox2.Controls.Add(Me.Label21)
        Me.XuiCustomGroupbox2.Controls.Add(Me.Label19)
        Me.XuiCustomGroupbox2.Controls.Add(Me.Label18)
        Me.XuiCustomGroupbox2.Controls.Add(Me.Label16)
        Me.XuiCustomGroupbox2.Controls.Add(Me.Label15)
        Me.XuiCustomGroupbox2.Controls.Add(Me.Label13)
        Me.XuiCustomGroupbox2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XuiCustomGroupbox2.Location = New System.Drawing.Point(6, 12)
        Me.XuiCustomGroupbox2.Name = "XuiCustomGroupbox2"
        Me.XuiCustomGroupbox2.ShowText = True
        Me.XuiCustomGroupbox2.Size = New System.Drawing.Size(734, 253)
        Me.XuiCustomGroupbox2.TabIndex = 260
        Me.XuiCustomGroupbox2.TabStop = False
        Me.XuiCustomGroupbox2.Text = "Detail Personil"
        Me.XuiCustomGroupbox2.TextColor = System.Drawing.Color.Black
        '
        'XuiCustomGroupbox4
        '
        Me.XuiCustomGroupbox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XuiCustomGroupbox4.BackColor = System.Drawing.Color.LightCyan
        Me.XuiCustomGroupbox4.BorderColor = System.Drawing.Color.Black
        Me.XuiCustomGroupbox4.BorderWidth = 1
        Me.XuiCustomGroupbox4.Controls.Add(Me.CmbKehadiran)
        Me.XuiCustomGroupbox4.Controls.Add(Me.Label20)
        Me.XuiCustomGroupbox4.Controls.Add(Me.Label8)
        Me.XuiCustomGroupbox4.Controls.Add(Me.TxtKeterangan)
        Me.XuiCustomGroupbox4.Controls.Add(Me.Label17)
        Me.XuiCustomGroupbox4.Controls.Add(Me.ChkTidakHitungLembur)
        Me.XuiCustomGroupbox4.Controls.Add(Me.ChkTidakHitungUangMakan)
        Me.XuiCustomGroupbox4.Controls.Add(Me.Label9)
        Me.XuiCustomGroupbox4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XuiCustomGroupbox4.Location = New System.Drawing.Point(6, 155)
        Me.XuiCustomGroupbox4.Name = "XuiCustomGroupbox4"
        Me.XuiCustomGroupbox4.ShowText = True
        Me.XuiCustomGroupbox4.Size = New System.Drawing.Size(722, 92)
        Me.XuiCustomGroupbox4.TabIndex = 263
        Me.XuiCustomGroupbox4.TabStop = False
        Me.XuiCustomGroupbox4.Text = "Update Kehadiran"
        Me.XuiCustomGroupbox4.TextColor = System.Drawing.Color.Black
        '
        'CmbKehadiran
        '
        Me.CmbKehadiran.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbKehadiran.BackColor = System.Drawing.Color.White
        Me.CmbKehadiran.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbKehadiran.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbKehadiran.FormattingEnabled = True
        Me.CmbKehadiran.IntegralHeight = False
        Me.CmbKehadiran.Items.AddRange(New Object() {"1", "2", "3"})
        Me.CmbKehadiran.Location = New System.Drawing.Point(107, 22)
        Me.CmbKehadiran.Name = "CmbKehadiran"
        Me.CmbKehadiran.Size = New System.Drawing.Size(56, 25)
        Me.CmbKehadiran.TabIndex = 253
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(200, 26)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(84, 17)
        Me.Label20.TabIndex = 255
        Me.Label20.Text = "Keterangan"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 26)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 17)
        Me.Label8.TabIndex = 255
        Me.Label8.Text = "Kehadiran"
        '
        'TxtKeterangan
        '
        Me.TxtKeterangan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtKeterangan.Location = New System.Drawing.Point(308, 23)
        Me.TxtKeterangan.Name = "TxtKeterangan"
        Me.TxtKeterangan.Size = New System.Drawing.Size(395, 23)
        Me.TxtKeterangan.TabIndex = 257
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(290, 26)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(12, 17)
        Me.Label17.TabIndex = 255
        Me.Label17.Text = ":"
        '
        'ChkTidakHitungLembur
        '
        Me.ChkTidakHitungLembur.AutoSize = True
        Me.ChkTidakHitungLembur.FlatAppearance.BorderSize = 0
        Me.ChkTidakHitungLembur.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkTidakHitungLembur.Location = New System.Drawing.Point(213, 57)
        Me.ChkTidakHitungLembur.Name = "ChkTidakHitungLembur"
        Me.ChkTidakHitungLembur.Size = New System.Drawing.Size(158, 21)
        Me.ChkTidakHitungLembur.TabIndex = 203
        Me.ChkTidakHitungLembur.Text = "Tidak Hitung Lembur"
        Me.ChkTidakHitungLembur.UseVisualStyleBackColor = True
        '
        'ChkTidakHitungUangMakan
        '
        Me.ChkTidakHitungUangMakan.AutoSize = True
        Me.ChkTidakHitungUangMakan.FlatAppearance.BorderSize = 0
        Me.ChkTidakHitungUangMakan.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkTidakHitungUangMakan.Location = New System.Drawing.Point(12, 57)
        Me.ChkTidakHitungUangMakan.Name = "ChkTidakHitungUangMakan"
        Me.ChkTidakHitungUangMakan.Size = New System.Drawing.Size(192, 21)
        Me.ChkTidakHitungUangMakan.TabIndex = 203
        Me.ChkTidakHitungUangMakan.Text = "Tidak Hitung Uang Makan"
        Me.ChkTidakHitungUangMakan.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(89, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(12, 17)
        Me.Label9.TabIndex = 255
        Me.Label9.Text = ":"
        '
        'TxtJabatan
        '
        Me.TxtJabatan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtJabatan.Location = New System.Drawing.Point(486, 23)
        Me.TxtJabatan.Name = "TxtJabatan"
        Me.TxtJabatan.Size = New System.Drawing.Size(197, 23)
        Me.TxtJabatan.TabIndex = 257
        '
        'TxtTanggalAbsen
        '
        Me.TxtTanggalAbsen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTanggalAbsen.Location = New System.Drawing.Point(486, 107)
        Me.TxtTanggalAbsen.Name = "TxtTanggalAbsen"
        Me.TxtTanggalAbsen.Size = New System.Drawing.Size(112, 23)
        Me.TxtTanggalAbsen.TabIndex = 257
        '
        'TxtLiburMingguan
        '
        Me.TxtLiburMingguan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtLiburMingguan.Location = New System.Drawing.Point(143, 107)
        Me.TxtLiburMingguan.Name = "TxtLiburMingguan"
        Me.TxtLiburMingguan.Size = New System.Drawing.Size(112, 23)
        Me.TxtLiburMingguan.TabIndex = 257
        '
        'TxtStatus
        '
        Me.TxtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtStatus.Location = New System.Drawing.Point(143, 79)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.Size = New System.Drawing.Size(183, 23)
        Me.TxtStatus.TabIndex = 257
        '
        'TxtNik
        '
        Me.TxtNik.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNik.Location = New System.Drawing.Point(143, 51)
        Me.TxtNik.Name = "TxtNik"
        Me.TxtNik.Size = New System.Drawing.Size(112, 23)
        Me.TxtNik.TabIndex = 257
        '
        'TxtPancang
        '
        Me.TxtPancang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPancang.Location = New System.Drawing.Point(486, 79)
        Me.TxtPancang.Name = "TxtPancang"
        Me.TxtPancang.Size = New System.Drawing.Size(223, 23)
        Me.TxtPancang.TabIndex = 257
        '
        'TxtNama
        '
        Me.TxtNama.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNama.Location = New System.Drawing.Point(143, 23)
        Me.TxtNama.Name = "TxtNama"
        Me.TxtNama.Size = New System.Drawing.Size(232, 23)
        Me.TxtNama.TabIndex = 257
        '
        'TxtBagian
        '
        Me.TxtBagian.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtBagian.Location = New System.Drawing.Point(486, 51)
        Me.TxtBagian.Name = "TxtBagian"
        Me.TxtBagian.Size = New System.Drawing.Size(41, 23)
        Me.TxtBagian.TabIndex = 257
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(125, 110)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(12, 17)
        Me.Label11.TabIndex = 255
        Me.Label11.Text = ":"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(468, 110)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(12, 17)
        Me.Label29.TabIndex = 255
        Me.Label29.Text = ":"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(468, 82)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(12, 17)
        Me.Label28.TabIndex = 255
        Me.Label28.Text = ":"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(468, 26)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(12, 17)
        Me.Label23.TabIndex = 255
        Me.Label23.Text = ":"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(468, 54)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(12, 17)
        Me.Label27.TabIndex = 255
        Me.Label27.Text = ":"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(125, 54)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(12, 17)
        Me.Label25.TabIndex = 255
        Me.Label25.Text = ":"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(125, 26)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(12, 17)
        Me.Label24.TabIndex = 255
        Me.Label24.Text = ":"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(125, 82)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(12, 17)
        Me.Label22.TabIndex = 255
        Me.Label22.Text = ":"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(14, 110)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(107, 17)
        Me.Label10.TabIndex = 255
        Me.Label10.Text = "Libur Mingguan"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(397, 54)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(53, 17)
        Me.Label14.TabIndex = 255
        Me.Label14.Text = "Bagian"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(397, 110)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(60, 17)
        Me.Label21.TabIndex = 255
        Me.Label21.Text = "Tanggal"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(397, 26)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(63, 17)
        Me.Label19.TabIndex = 255
        Me.Label19.Text = "Jabatan"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(397, 82)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(67, 17)
        Me.Label18.TabIndex = 255
        Me.Label18.Text = "Pancang"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(14, 82)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(46, 17)
        Me.Label16.TabIndex = 255
        Me.Label16.Text = "Status"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(14, 54)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(28, 17)
        Me.Label15.TabIndex = 255
        Me.Label15.Text = "Nik"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(14, 26)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 17)
        Me.Label13.TabIndex = 255
        Me.Label13.Text = "Nama"
        '
        'XuiCustomGroupbox1
        '
        Me.XuiCustomGroupbox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XuiCustomGroupbox1.BackColor = System.Drawing.Color.LightCyan
        Me.XuiCustomGroupbox1.BorderColor = System.Drawing.Color.Black
        Me.XuiCustomGroupbox1.BorderWidth = 1
        Me.XuiCustomGroupbox1.Controls.Add(Me.chkTanggal)
        Me.XuiCustomGroupbox1.Controls.Add(Me.Label2)
        Me.XuiCustomGroupbox1.Controls.Add(Me.cboBagian)
        Me.XuiCustomGroupbox1.Controls.Add(Me.chkJabatan)
        Me.XuiCustomGroupbox1.Controls.Add(Me.Label12)
        Me.XuiCustomGroupbox1.Controls.Add(Me.ChkIdPersonil)
        Me.XuiCustomGroupbox1.Controls.Add(Me.Label7)
        Me.XuiCustomGroupbox1.Controls.Add(Me.Label4)
        Me.XuiCustomGroupbox1.Controls.Add(Me.chkBagian)
        Me.XuiCustomGroupbox1.Controls.Add(Me.PanelKapal)
        Me.XuiCustomGroupbox1.Controls.Add(Me.chkPeriode)
        Me.XuiCustomGroupbox1.Controls.Add(Me.dtpPeriode)
        Me.XuiCustomGroupbox1.Controls.Add(Me.dtpTanggal2)
        Me.XuiCustomGroupbox1.Controls.Add(Me.chkPancang)
        Me.XuiCustomGroupbox1.Controls.Add(Me.Label6)
        Me.XuiCustomGroupbox1.Controls.Add(Me.Panel4)
        Me.XuiCustomGroupbox1.Controls.Add(Me.PanelPancang)
        Me.XuiCustomGroupbox1.Controls.Add(Me.Label5)
        Me.XuiCustomGroupbox1.Controls.Add(Me.chkStatus)
        Me.XuiCustomGroupbox1.Controls.Add(Me.Label1)
        Me.XuiCustomGroupbox1.Controls.Add(Me.dtpTanggal)
        Me.XuiCustomGroupbox1.Controls.Add(Me.Panel1)
        Me.XuiCustomGroupbox1.Controls.Add(Me.Label3)
        Me.XuiCustomGroupbox1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XuiCustomGroupbox1.Location = New System.Drawing.Point(746, 12)
        Me.XuiCustomGroupbox1.Name = "XuiCustomGroupbox1"
        Me.XuiCustomGroupbox1.ShowText = True
        Me.XuiCustomGroupbox1.Size = New System.Drawing.Size(796, 165)
        Me.XuiCustomGroupbox1.TabIndex = 101
        Me.XuiCustomGroupbox1.TabStop = False
        Me.XuiCustomGroupbox1.Text = "Filter Data"
        Me.XuiCustomGroupbox1.TextColor = System.Drawing.Color.Black
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(108, 27)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(11, 17)
        Me.Label12.TabIndex = 207
        Me.Label12.Text = ":"
        '
        'ChkIdPersonil
        '
        Me.ChkIdPersonil.AutoSize = True
        Me.ChkIdPersonil.FlatAppearance.BorderSize = 0
        Me.ChkIdPersonil.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkIdPersonil.Location = New System.Drawing.Point(16, 25)
        Me.ChkIdPersonil.Name = "ChkIdPersonil"
        Me.ChkIdPersonil.Size = New System.Drawing.Size(91, 21)
        Me.ChkIdPersonil.TabIndex = 203
        Me.ChkIdPersonil.Text = "Id Personil"
        Me.ChkIdPersonil.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Controls.Add(Me.Panel6)
        Me.Panel4.Controls.Add(Me.CmbIdPersonil)
        Me.Panel4.Location = New System.Drawing.Point(126, 22)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(259, 26)
        Me.Panel4.TabIndex = 205
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel5.Location = New System.Drawing.Point(4, 25)
        Me.Panel5.MaximumSize = New System.Drawing.Size(412, 1)
        Me.Panel5.MinimumSize = New System.Drawing.Size(2, 1)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(5, 1)
        Me.Panel5.TabIndex = 66
        Me.Panel5.Visible = False
        '
        'Panel6
        '
        Me.Panel6.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel6.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel6.Location = New System.Drawing.Point(4, 25)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(252, 1)
        Me.Panel6.TabIndex = 65
        '
        'CmbIdPersonil
        '
        Me.CmbIdPersonil.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbIdPersonil.BackColor = System.Drawing.Color.White
        Me.CmbIdPersonil.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbIdPersonil.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbIdPersonil.FormattingEnabled = True
        Me.CmbIdPersonil.IntegralHeight = False
        Me.CmbIdPersonil.Items.AddRange(New Object() {"1", "2", "3"})
        Me.CmbIdPersonil.Location = New System.Drawing.Point(3, 1)
        Me.CmbIdPersonil.Name = "CmbIdPersonil"
        Me.CmbIdPersonil.Size = New System.Drawing.Size(255, 25)
        Me.CmbIdPersonil.TabIndex = 64
        '
        'Timer
        '
        Me.Timer.Interval = 150
        '
        'FrmTrnUpdateAbsensiPancang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1548, 685)
        Me.Controls.Add(Me.grpDataTimbangPancang)
        Me.Controls.Add(Me.grpFilterData)
        Me.Name = "FrmTrnUpdateAbsensiPancang"
        Me.Text = "FrmTrnUpdateAbsensiPancang"
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDataTimbangPancang.ResumeLayout(False)
        Me.grpDataTimbangPancang.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.PanelPancang.ResumeLayout(False)
        Me.PanelKapal.ResumeLayout(False)
        Me.grpFilterData.ResumeLayout(False)
        Me.grpFilterData.PerformLayout()
        Me.XuiCustomGroupbox3.ResumeLayout(False)
        Me.XuiCustomGroupbox3.PerformLayout()
        Me.XuiCustomGroupbox2.ResumeLayout(False)
        Me.XuiCustomGroupbox2.PerformLayout()
        Me.XuiCustomGroupbox4.ResumeLayout(False)
        Me.XuiCustomGroupbox4.PerformLayout()
        Me.XuiCustomGroupbox1.ResumeLayout(False)
        Me.XuiCustomGroupbox1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents cboBagian As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents chkBagian As CheckBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents PanelKapal2 As Panel
    Friend WithEvents PanelKapal1 As Panel
    Friend WithEvents cboJabatan As ComboBox
    Friend WithEvents dtpTanggal2 As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents grpDataTimbangPancang As XanderUI.XUICustomGroupbox
    Friend WithEvents scp As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents PanelPancang1 As Panel
    Friend WithEvents btnRefresh As Button
    Friend WithEvents dtpTanggal As DateTimePicker
    Friend WithEvents chkTanggal As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents cboPancang As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents chkStatus As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents PanelPancang As Panel
    Friend WithEvents PanelPancang2 As Panel
    Friend WithEvents chkPancang As CheckBox
    Friend WithEvents dtpPeriode As DateTimePicker
    Friend WithEvents chkPeriode As CheckBox
    Friend WithEvents PanelKapal As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents chkJabatan As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents grpFilterData As XanderUI.XUICustomGroupbox
    Friend WithEvents XuiCustomGroupbox2 As XanderUI.XUICustomGroupbox
    Friend WithEvents XuiCustomGroupbox1 As XanderUI.XUICustomGroupbox
    Friend WithEvents XuiCustomGroupbox3 As XanderUI.XUICustomGroupbox
    Friend WithEvents CmbKehadiran As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents TxtJabatan As TextBox
    Friend WithEvents TxtStatus As TextBox
    Friend WithEvents TxtNik As TextBox
    Friend WithEvents TxtPancang As TextBox
    Friend WithEvents TxtNama As TextBox
    Friend WithEvents TxtBagian As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents BtnEdit As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents ChkIdPersonil As CheckBox
    Friend WithEvents Label12 As Label
    Friend WithEvents XuiCustomGroupbox4 As XanderUI.XUICustomGroupbox
    Friend WithEvents TxtLiburMingguan As TextBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents CmbIdPersonil As ComboBox
    Friend WithEvents TxtTanggalAbsen As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents TxtKeterangan As TextBox
    Friend WithEvents ChkTidakHitungLembur As CheckBox
    Friend WithEvents ChkTidakHitungUangMakan As CheckBox
    Friend WithEvents lblInfo As Label
    Friend WithEvents Timer As Timer
End Class
