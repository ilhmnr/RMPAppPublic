<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTrnUangMakanPersonilPancang
    'Inherits System.Windows.Forms.Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTrnUangMakanPersonilPancang))
        Me.PanelKapal2 = New System.Windows.Forms.Panel()
        Me.cboJabatan = New System.Windows.Forms.ComboBox()
        Me.grpDataTimbangPancang = New XanderUI.XUICustomGroupbox()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.scp = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.PanelKapal1 = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkStatus = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PanelPancang = New System.Windows.Forms.Panel()
        Me.PanelPancang2 = New System.Windows.Forms.Panel()
        Me.PanelPancang1 = New System.Windows.Forms.Panel()
        Me.cboPancang = New System.Windows.Forms.ComboBox()
        Me.chkPancang = New System.Windows.Forms.CheckBox()
        Me.PanelKapal = New System.Windows.Forms.Panel()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkJabatan = New System.Windows.Forms.CheckBox()
        Me.grpFilterData = New XanderUI.XUICustomGroupbox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.dtpTransDate = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.rdP2 = New System.Windows.Forms.RadioButton()
        Me.rdP1 = New System.Windows.Forms.RadioButton()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtNoTrans = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.dtpTanggal2 = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpTanggal = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtYear = New System.Windows.Forms.TextBox()
        Me.txtMonth = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grpDataTimbangPancang.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.PanelPancang.SuspendLayout()
        Me.PanelKapal.SuspendLayout()
        Me.grpFilterData.SuspendLayout()
        Me.SuspendLayout()
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
        'grpDataTimbangPancang
        '
        Me.grpDataTimbangPancang.BackColor = System.Drawing.Color.LightSkyBlue
        Me.grpDataTimbangPancang.BorderColor = System.Drawing.Color.Black
        Me.grpDataTimbangPancang.BorderWidth = 1
        Me.grpDataTimbangPancang.Controls.Add(Me.fg)
        Me.grpDataTimbangPancang.Controls.Add(Me.scp)
        Me.grpDataTimbangPancang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDataTimbangPancang.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDataTimbangPancang.Location = New System.Drawing.Point(0, 146)
        Me.grpDataTimbangPancang.Name = "grpDataTimbangPancang"
        Me.grpDataTimbangPancang.ShowText = True
        Me.grpDataTimbangPancang.Size = New System.Drawing.Size(1217, 562)
        Me.grpDataTimbangPancang.TabIndex = 100
        Me.grpDataTimbangPancang.TabStop = False
        Me.grpDataTimbangPancang.Text = "Data Nota Pancang"
        Me.grpDataTimbangPancang.TextColor = System.Drawing.Color.Black
        '
        'fg
        '
        Me.fg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fg.ColumnInfo = "23,1,0,0,0,110,Columns:22{Style:""ComboList:""""..."""";TextAlign:GeneralCenter;ImageA" &
    "lign:CenterCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.fg.ForeColor = System.Drawing.Color.Black
        Me.fg.Location = New System.Drawing.Point(6, 22)
        Me.fg.Name = "fg"
        Me.fg.Rows.Count = 4
        Me.fg.Rows.DefaultSize = 22
        Me.fg.Size = New System.Drawing.Size(1205, 535)
        Me.fg.StyleInfo = resources.GetString("fg.StyleInfo")
        Me.fg.TabIndex = 9
        '
        'scp
        '
        Me.scp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.scp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.scp.Location = New System.Drawing.Point(875, -14)
        Me.scp.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.scp.Name = "scp"
        Me.scp.ShowClearButton = False
        Me.scp.ShowSearchButton = False
        Me.scp.Size = New System.Drawing.Size(370, 35)
        Me.scp.TabIndex = 170
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
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.Teal
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnCancel.Location = New System.Drawing.Point(1013, 102)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(95, 30)
        Me.btnCancel.TabIndex = 249
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
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
        Me.btnClose.Location = New System.Drawing.Point(1114, 102)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(95, 30)
        Me.btnClose.TabIndex = 244
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
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
        Me.btnRefresh.Location = New System.Drawing.Point(811, 102)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(95, 30)
        Me.btnRefresh.TabIndex = 241
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.cboStatus)
        Me.Panel1.Location = New System.Drawing.Point(107, 71)
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(94, 76)
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
        Me.chkStatus.Location = New System.Drawing.Point(11, 75)
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
        Me.Label5.Location = New System.Drawing.Point(94, 20)
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
        Me.PanelPancang.Location = New System.Drawing.Point(107, 15)
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
        'PanelPancang1
        '
        Me.PanelPancang1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelPancang1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PanelPancang1.Location = New System.Drawing.Point(4, 25)
        Me.PanelPancang1.Name = "PanelPancang1"
        Me.PanelPancang1.Size = New System.Drawing.Size(252, 1)
        Me.PanelPancang1.TabIndex = 65
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
        'chkPancang
        '
        Me.chkPancang.AutoSize = True
        Me.chkPancang.FlatAppearance.BorderSize = 0
        Me.chkPancang.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPancang.Location = New System.Drawing.Point(11, 19)
        Me.chkPancang.Name = "chkPancang"
        Me.chkPancang.Size = New System.Drawing.Size(86, 21)
        Me.chkPancang.TabIndex = 203
        Me.chkPancang.Text = "Pancang"
        Me.chkPancang.UseVisualStyleBackColor = True
        '
        'PanelKapal
        '
        Me.PanelKapal.Controls.Add(Me.PanelKapal2)
        Me.PanelKapal.Controls.Add(Me.PanelKapal1)
        Me.PanelKapal.Controls.Add(Me.cboJabatan)
        Me.PanelKapal.Location = New System.Drawing.Point(107, 43)
        Me.PanelKapal.Name = "PanelKapal"
        Me.PanelKapal.Size = New System.Drawing.Size(259, 26)
        Me.PanelKapal.TabIndex = 217
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(94, 48)
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
        Me.chkJabatan.Location = New System.Drawing.Point(11, 47)
        Me.chkJabatan.Name = "chkJabatan"
        Me.chkJabatan.Size = New System.Drawing.Size(82, 21)
        Me.chkJabatan.TabIndex = 216
        Me.chkJabatan.Text = "Jabatan"
        Me.chkJabatan.UseVisualStyleBackColor = True
        '
        'grpFilterData
        '
        Me.grpFilterData.BackColor = System.Drawing.Color.LightSkyBlue
        Me.grpFilterData.BorderColor = System.Drawing.Color.Black
        Me.grpFilterData.BorderWidth = 1
        Me.grpFilterData.Controls.Add(Me.Label13)
        Me.grpFilterData.Controls.Add(Me.txtNote)
        Me.grpFilterData.Controls.Add(Me.btnPrint)
        Me.grpFilterData.Controls.Add(Me.btnFind)
        Me.grpFilterData.Controls.Add(Me.btnDelete)
        Me.grpFilterData.Controls.Add(Me.dtpTransDate)
        Me.grpFilterData.Controls.Add(Me.Label11)
        Me.grpFilterData.Controls.Add(Me.Label12)
        Me.grpFilterData.Controls.Add(Me.rdP2)
        Me.grpFilterData.Controls.Add(Me.rdP1)
        Me.grpFilterData.Controls.Add(Me.btnAdd)
        Me.grpFilterData.Controls.Add(Me.txtNoTrans)
        Me.grpFilterData.Controls.Add(Me.Label10)
        Me.grpFilterData.Controls.Add(Me.btnSave)
        Me.grpFilterData.Controls.Add(Me.dtpTanggal2)
        Me.grpFilterData.Controls.Add(Me.Label8)
        Me.grpFilterData.Controls.Add(Me.dtpTanggal)
        Me.grpFilterData.Controls.Add(Me.Label7)
        Me.grpFilterData.Controls.Add(Me.Label6)
        Me.grpFilterData.Controls.Add(Me.txtYear)
        Me.grpFilterData.Controls.Add(Me.txtMonth)
        Me.grpFilterData.Controls.Add(Me.Label3)
        Me.grpFilterData.Controls.Add(Me.Label2)
        Me.grpFilterData.Controls.Add(Me.btnCancel)
        Me.grpFilterData.Controls.Add(Me.btnClose)
        Me.grpFilterData.Controls.Add(Me.btnRefresh)
        Me.grpFilterData.Controls.Add(Me.Panel1)
        Me.grpFilterData.Controls.Add(Me.Label1)
        Me.grpFilterData.Controls.Add(Me.chkStatus)
        Me.grpFilterData.Controls.Add(Me.Label5)
        Me.grpFilterData.Controls.Add(Me.PanelPancang)
        Me.grpFilterData.Controls.Add(Me.chkPancang)
        Me.grpFilterData.Controls.Add(Me.PanelKapal)
        Me.grpFilterData.Controls.Add(Me.Label4)
        Me.grpFilterData.Controls.Add(Me.chkJabatan)
        Me.grpFilterData.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpFilterData.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpFilterData.Location = New System.Drawing.Point(0, 0)
        Me.grpFilterData.Name = "grpFilterData"
        Me.grpFilterData.ShowText = True
        Me.grpFilterData.Size = New System.Drawing.Size(1217, 146)
        Me.grpFilterData.TabIndex = 99
        Me.grpFilterData.TabStop = False
        Me.grpFilterData.Text = "Filter Data"
        Me.grpFilterData.TextColor = System.Drawing.Color.Black
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(372, 53)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(57, 16)
        Me.Label13.TabIndex = 295
        Me.Label13.Text = "No Trans"
        '
        'txtNote
        '
        Me.txtNote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNote.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNote.Location = New System.Drawing.Point(859, 16)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(346, 41)
        Me.txtNote.TabIndex = 294
        Me.txtNote.Text = "Input Note Print Out"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.BackColor = System.Drawing.Color.OliveDrab
        Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrint.FlatAppearance.BorderSize = 0
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPrint.Location = New System.Drawing.Point(710, 102)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(95, 30)
        Me.btnPrint.TabIndex = 293
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'btnFind
        '
        Me.btnFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFind.BackColor = System.Drawing.Color.Teal
        Me.btnFind.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFind.FlatAppearance.BorderSize = 0
        Me.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFind.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFind.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnFind.Location = New System.Drawing.Point(508, 102)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(95, 30)
        Me.btnFind.TabIndex = 281
        Me.btnFind.Text = "Find"
        Me.btnFind.UseVisualStyleBackColor = False
        Me.btnFind.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.Teal
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnDelete.Location = New System.Drawing.Point(410, 102)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(95, 30)
        Me.btnDelete.TabIndex = 280
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        Me.btnDelete.Visible = False
        '
        'dtpTransDate
        '
        Me.dtpTransDate.CustomFormat = "dd MMM yyyy"
        Me.dtpTransDate.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTransDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTransDate.Location = New System.Drawing.Point(753, 18)
        Me.dtpTransDate.Name = "dtpTransDate"
        Me.dtpTransDate.Size = New System.Drawing.Size(91, 23)
        Me.dtpTransDate.TabIndex = 279
        Me.dtpTransDate.Value = New Date(2019, 4, 8, 0, 0, 0, 0)
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(736, 21)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(10, 16)
        Me.Label11.TabIndex = 278
        Me.Label11.Text = ":"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(662, 23)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 16)
        Me.Label12.TabIndex = 277
        Me.Label12.Text = "Trans Date"
        '
        'rdP2
        '
        Me.rdP2.AutoSize = True
        Me.rdP2.Checked = True
        Me.rdP2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdP2.Location = New System.Drawing.Point(495, 78)
        Me.rdP2.Name = "rdP2"
        Me.rdP2.Size = New System.Drawing.Size(39, 20)
        Me.rdP2.TabIndex = 275
        Me.rdP2.TabStop = True
        Me.rdP2.Text = "P2"
        Me.rdP2.UseVisualStyleBackColor = True
        '
        'rdP1
        '
        Me.rdP1.AutoSize = True
        Me.rdP1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdP1.Location = New System.Drawing.Point(449, 78)
        Me.rdP1.Name = "rdP1"
        Me.rdP1.Size = New System.Drawing.Size(39, 20)
        Me.rdP1.TabIndex = 274
        Me.rdP1.Text = "P1"
        Me.rdP1.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.Teal
        Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAdd.FlatAppearance.BorderSize = 0
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnAdd.Location = New System.Drawing.Point(609, 102)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(95, 30)
        Me.btnAdd.TabIndex = 272
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'txtNoTrans
        '
        Me.txtNoTrans.Location = New System.Drawing.Point(449, 49)
        Me.txtNoTrans.Name = "txtNoTrans"
        Me.txtNoTrans.Size = New System.Drawing.Size(207, 23)
        Me.txtNoTrans.TabIndex = 271
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(432, 52)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(10, 16)
        Me.Label10.TabIndex = 270
        Me.Label10.Text = ":"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.Teal
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSave.Location = New System.Drawing.Point(912, 102)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(95, 30)
        Me.btnSave.TabIndex = 268
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'dtpTanggal2
        '
        Me.dtpTanggal2.CustomFormat = "dd MMM yyyy"
        Me.dtpTanggal2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTanggal2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTanggal2.Location = New System.Drawing.Point(565, 18)
        Me.dtpTanggal2.Name = "dtpTanggal2"
        Me.dtpTanggal2.Size = New System.Drawing.Size(91, 23)
        Me.dtpTanggal2.TabIndex = 267
        Me.dtpTanggal2.Value = New Date(2019, 4, 8, 0, 0, 0, 0)
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(546, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(12, 16)
        Me.Label8.TabIndex = 266
        Me.Label8.Text = "-"
        '
        'dtpTanggal
        '
        Me.dtpTanggal.CustomFormat = "dd MMM yyyy"
        Me.dtpTanggal.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTanggal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTanggal.Location = New System.Drawing.Point(449, 18)
        Me.dtpTanggal.Name = "dtpTanggal"
        Me.dtpTanggal.Size = New System.Drawing.Size(91, 23)
        Me.dtpTanggal.TabIndex = 265
        Me.dtpTanggal.Value = New Date(2019, 4, 8, 0, 0, 0, 0)
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(432, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(10, 16)
        Me.Label7.TabIndex = 264
        Me.Label7.Text = ":"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(372, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 16)
        Me.Label6.TabIndex = 263
        Me.Label6.Text = "Periode"
        '
        'txtYear
        '
        Me.txtYear.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtYear.Location = New System.Drawing.Point(1336, 40)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(95, 22)
        Me.txtYear.TabIndex = 262
        Me.txtYear.Visible = False
        '
        'txtMonth
        '
        Me.txtMonth.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonth.Location = New System.Drawing.Point(1336, 12)
        Me.txtMonth.Name = "txtMonth"
        Me.txtMonth.Size = New System.Drawing.Size(95, 22)
        Me.txtMonth.TabIndex = 261
        Me.txtMonth.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(1286, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 16)
        Me.Label3.TabIndex = 260
        Me.Label3.Text = "Year"
        Me.Label3.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1286, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 16)
        Me.Label2.TabIndex = 259
        Me.Label2.Text = "Month"
        Me.Label2.Visible = False
        '
        'FrmTrnUangMakanPersonilPancang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1217, 708)
        Me.Controls.Add(Me.grpDataTimbangPancang)
        Me.Controls.Add(Me.grpFilterData)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmTrnUangMakanPersonilPancang"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Uang Makan Personil Pancang"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grpDataTimbangPancang.ResumeLayout(False)
        Me.grpDataTimbangPancang.PerformLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.PanelPancang.ResumeLayout(False)
        Me.PanelKapal.ResumeLayout(False)
        Me.grpFilterData.ResumeLayout(False)
        Me.grpFilterData.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelKapal2 As Panel
    Friend WithEvents cboJabatan As ComboBox
    Friend WithEvents grpDataTimbangPancang As XanderUI.XUICustomGroupbox
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents scp As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents PanelKapal1 As Panel
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents chkStatus As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents PanelPancang As Panel
    Friend WithEvents PanelPancang2 As Panel
    Friend WithEvents PanelPancang1 As Panel
    Friend WithEvents cboPancang As ComboBox
    Friend WithEvents chkPancang As CheckBox
    Friend WithEvents PanelKapal As Panel
    Friend WithEvents SaveFileDialog As SaveFileDialog
    Friend WithEvents Label4 As Label
    Friend WithEvents chkJabatan As CheckBox
    Friend WithEvents grpFilterData As XanderUI.XUICustomGroupbox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtYear As TextBox
    Friend WithEvents txtMonth As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpTanggal2 As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents dtpTanggal As DateTimePicker
    Friend WithEvents btnAdd As Button
    Friend WithEvents txtNoTrans As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents rdP2 As RadioButton
    Friend WithEvents rdP1 As RadioButton
    Friend WithEvents dtpTransDate As DateTimePicker
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnFind As Button
    Friend WithEvents btnPrint As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents txtNote As TextBox
End Class
