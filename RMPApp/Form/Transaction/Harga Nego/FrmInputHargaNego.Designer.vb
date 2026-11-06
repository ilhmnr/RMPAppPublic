<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmInputHargaNego
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInputHargaNego))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlHead = New System.Windows.Forms.Panel()
        Me.lblHead = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.chkEditAll = New System.Windows.Forms.CheckBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.btnexit = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.chkDariPurchaser = New System.Windows.Forms.CheckBox()
        Me.C1DynamicHelp2 = New C1.Win.C1DynamicHelp.C1DynamicHelp()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.cmbS_Petani = New System.Windows.Forms.ComboBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.DTPEnd = New System.Windows.Forms.DateTimePicker()
        Me.DTPStart = New System.Windows.Forms.DateTimePicker()
        Me.cmbKapal = New System.Windows.Forms.ComboBox()
        Me.cmbPancang = New System.Windows.Forms.ComboBox()
        Me.C1DynamicHelp1 = New C1.Win.C1DynamicHelp.C1DynamicHelp()
        Me.txtNoNota = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTrip = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pnlHead)
        Me.Panel1.Controls.Add(Me.lblHead)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1DynamicHelp2.SetHelpTopic(Me.Panel1, Nothing)
        Me.C1DynamicHelp1.SetHelpTopic(Me.Panel1, Nothing)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.Panel1.Size = New System.Drawing.Size(1260, 46)
        Me.Panel1.TabIndex = 0
        '
        'pnlHead
        '
        Me.pnlHead.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.pnlHead.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.C1DynamicHelp2.SetHelpTopic(Me.pnlHead, Nothing)
        Me.C1DynamicHelp1.SetHelpTopic(Me.pnlHead, Nothing)
        Me.pnlHead.Location = New System.Drawing.Point(10, 43)
        Me.pnlHead.Name = "pnlHead"
        Me.pnlHead.Padding = New System.Windows.Forms.Padding(0, 0, 10, 0)
        Me.pnlHead.Size = New System.Drawing.Size(1240, 3)
        Me.pnlHead.TabIndex = 303
        '
        'lblHead
        '
        Me.lblHead.AutoSize = True
        Me.lblHead.BackColor = System.Drawing.Color.Transparent
        Me.lblHead.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblHead.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHead.ForeColor = System.Drawing.Color.DimGray
        Me.C1DynamicHelp1.SetHelpTopic(Me.lblHead, Nothing)
        Me.C1DynamicHelp2.SetHelpTopic(Me.lblHead, Nothing)
        Me.lblHead.Location = New System.Drawing.Point(12, 9)
        Me.lblHead.Name = "lblHead"
        Me.lblHead.Size = New System.Drawing.Size(220, 28)
        Me.lblHead.TabIndex = 302
        Me.lblHead.Text = "Input Harga Nego"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1DynamicHelp2.SetHelpTopic(Me.Panel2, Nothing)
        Me.C1DynamicHelp1.SetHelpTopic(Me.Panel2, Nothing)
        Me.Panel2.Location = New System.Drawing.Point(0, 46)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1260, 657)
        Me.Panel2.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1DynamicHelp2.SetHelpTopic(Me.Panel4, Nothing)
        Me.C1DynamicHelp1.SetHelpTopic(Me.Panel4, Nothing)
        Me.Panel4.Location = New System.Drawing.Point(0, 98)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1260, 559)
        Me.Panel4.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Panel7)
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1DynamicHelp2.SetHelpTopic(Me.Panel5, Nothing)
        Me.C1DynamicHelp1.SetHelpTopic(Me.Panel5, Nothing)
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1260, 559)
        Me.Panel5.TabIndex = 0
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.fg)
        Me.Panel7.Controls.Add(Me.chkEditAll)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1DynamicHelp2.SetHelpTopic(Me.Panel7, Nothing)
        Me.C1DynamicHelp1.SetHelpTopic(Me.Panel7, Nothing)
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Padding = New System.Windows.Forms.Padding(10, 30, 10, 0)
        Me.Panel7.Size = New System.Drawing.Size(1260, 497)
        Me.Panel7.TabIndex = 3
        '
        'fg
        '
        Me.fg.ColumnInfo = "10,1,0,0,0,-1,Columns:1{Style:""DataType:System.Boolean;TextAlign:LeftCenter;Image" &
    "Align:CenterCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1DynamicHelp2.SetHelpTopic(Me.fg, Nothing)
        Me.C1DynamicHelp1.SetHelpTopic(Me.fg, Nothing)
        Me.fg.Location = New System.Drawing.Point(10, 30)
        Me.fg.Name = "fg"
        Me.fg.Size = New System.Drawing.Size(1240, 467)
        Me.fg.TabIndex = 0
        '
        'chkEditAll
        '
        Me.chkEditAll.AutoSize = True
        Me.chkEditAll.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chkEditAll.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1DynamicHelp1.SetHelpTopic(Me.chkEditAll, Nothing)
        Me.C1DynamicHelp2.SetHelpTopic(Me.chkEditAll, Nothing)
        Me.chkEditAll.Location = New System.Drawing.Point(10, 6)
        Me.chkEditAll.Name = "chkEditAll"
        Me.chkEditAll.Size = New System.Drawing.Size(124, 21)
        Me.chkEditAll.TabIndex = 822
        Me.chkEditAll.Text = "Checklist Edit All"
        Me.chkEditAll.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Panel9)
        Me.Panel6.Controls.Add(Me.btnsave)
        Me.Panel6.Controls.Add(Me.btnexit)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.C1DynamicHelp2.SetHelpTopic(Me.Panel6, Nothing)
        Me.C1DynamicHelp1.SetHelpTopic(Me.Panel6, Nothing)
        Me.Panel6.Location = New System.Drawing.Point(0, 497)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.Panel6.Size = New System.Drawing.Size(1260, 62)
        Me.Panel6.TabIndex = 2
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1DynamicHelp2.SetHelpTopic(Me.Panel9, Nothing)
        Me.C1DynamicHelp1.SetHelpTopic(Me.Panel9, Nothing)
        Me.Panel9.Location = New System.Drawing.Point(10, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Padding = New System.Windows.Forms.Padding(0, 0, 10, 0)
        Me.Panel9.Size = New System.Drawing.Size(1240, 3)
        Me.Panel9.TabIndex = 823
        '
        'btnsave
        '
        Me.btnsave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnsave.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnsave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnsave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.btnsave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsave.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsave.ForeColor = System.Drawing.Color.White
        Me.C1DynamicHelp2.SetHelpTopic(Me.btnsave, Nothing)
        Me.C1DynamicHelp1.SetHelpTopic(Me.btnsave, Nothing)
        Me.btnsave.Image = Global.RMPApp.My.Resources.Resources.SavePSN
        Me.btnsave.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnsave.Location = New System.Drawing.Point(1076, 9)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(79, 46)
        Me.btnsave.TabIndex = 332
        Me.btnsave.Text = "SAVE"
        Me.btnsave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnsave.UseVisualStyleBackColor = False
        '
        'btnexit
        '
        Me.btnexit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnexit.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnexit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnexit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.btnexit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.btnexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnexit.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexit.ForeColor = System.Drawing.Color.White
        Me.C1DynamicHelp2.SetHelpTopic(Me.btnexit, Nothing)
        Me.C1DynamicHelp1.SetHelpTopic(Me.btnexit, Nothing)
        Me.btnexit.Image = CType(resources.GetObject("btnexit.Image"), System.Drawing.Image)
        Me.btnexit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnexit.Location = New System.Drawing.Point(1171, 9)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(79, 46)
        Me.btnexit.TabIndex = 331
        Me.btnexit.Text = "EXIT"
        Me.btnexit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnexit.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.txtTrip)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.txtNoNota)
        Me.Panel3.Controls.Add(Me.chkDariPurchaser)
        Me.Panel3.Controls.Add(Me.C1DynamicHelp2)
        Me.Panel3.Controls.Add(Me.C1DynamicHelp1)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Panel10)
        Me.Panel3.Controls.Add(Me.Panel8)
        Me.Panel3.Controls.Add(Me.cmbS_Petani)
        Me.Panel3.Controls.Add(Me.btnRefresh)
        Me.Panel3.Controls.Add(Me.DTPEnd)
        Me.Panel3.Controls.Add(Me.DTPStart)
        Me.Panel3.Controls.Add(Me.cmbKapal)
        Me.Panel3.Controls.Add(Me.cmbPancang)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1DynamicHelp2.SetHelpTopic(Me.Panel3, Nothing)
        Me.C1DynamicHelp1.SetHelpTopic(Me.Panel3, Nothing)
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.Panel3.Size = New System.Drawing.Size(1260, 98)
        Me.Panel3.TabIndex = 0
        '
        'chkDariPurchaser
        '
        Me.chkDariPurchaser.AutoSize = True
        Me.chkDariPurchaser.Checked = True
        Me.chkDariPurchaser.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDariPurchaser.FlatAppearance.BorderSize = 0
        Me.chkDariPurchaser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkDariPurchaser.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1DynamicHelp1.SetHelpTopic(Me.chkDariPurchaser, Nothing)
        Me.C1DynamicHelp2.SetHelpTopic(Me.chkDariPurchaser, Nothing)
        Me.chkDariPurchaser.Location = New System.Drawing.Point(781, 64)
        Me.chkDariPurchaser.Name = "chkDariPurchaser"
        Me.chkDariPurchaser.Size = New System.Drawing.Size(116, 21)
        Me.chkDariPurchaser.TabIndex = 827
        Me.chkDariPurchaser.Text = "Dari Purchaser"
        Me.chkDariPurchaser.UseVisualStyleBackColor = True
        '
        'C1DynamicHelp2
        '
        Me.C1DynamicHelp2.Location = New System.Drawing.Point(1234, 0)
        Me.C1DynamicHelp2.Name = "C1DynamicHelp2"
        Me.C1DynamicHelp2.Size = New System.Drawing.Size(8, 95)
        Me.C1DynamicHelp2.TabIndex = 826
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold)
        Me.C1DynamicHelp1.SetHelpTopic(Me.Label1, Nothing)
        Me.C1DynamicHelp2.SetHelpTopic(Me.Label1, Nothing)
        Me.Label1.Location = New System.Drawing.Point(807, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(164, 16)
        Me.Label1.TabIndex = 824
        Me.Label1.Text = "Sudah Input Uang Muka"
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.C1DynamicHelp2.SetHelpTopic(Me.Panel10, Nothing)
        Me.C1DynamicHelp1.SetHelpTopic(Me.Panel10, Nothing)
        Me.Panel10.Location = New System.Drawing.Point(781, 37)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(20, 20)
        Me.Panel10.TabIndex = 823
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.C1DynamicHelp2.SetHelpTopic(Me.Panel8, Nothing)
        Me.C1DynamicHelp1.SetHelpTopic(Me.Panel8, Nothing)
        Me.Panel8.Location = New System.Drawing.Point(10, 95)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Padding = New System.Windows.Forms.Padding(0, 0, 10, 0)
        Me.Panel8.Size = New System.Drawing.Size(1240, 3)
        Me.Panel8.TabIndex = 822
        '
        'cmbS_Petani
        '
        Me.cmbS_Petani.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cmbS_Petani.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbS_Petani.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbS_Petani.FormattingEnabled = True
        Me.C1DynamicHelp2.SetHelpTopic(Me.cmbS_Petani, Nothing)
        Me.C1DynamicHelp1.SetHelpTopic(Me.cmbS_Petani, Nothing)
        Me.cmbS_Petani.IntegralHeight = False
        Me.cmbS_Petani.Location = New System.Drawing.Point(499, 8)
        Me.cmbS_Petani.Name = "cmbS_Petani"
        Me.cmbS_Petani.Size = New System.Drawing.Size(251, 24)
        Me.cmbS_Petani.TabIndex = 820
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
        Me.C1DynamicHelp2.SetHelpTopic(Me.btnRefresh, Nothing)
        Me.C1DynamicHelp1.SetHelpTopic(Me.btnRefresh, Nothing)
        Me.btnRefresh.Location = New System.Drawing.Point(903, 62)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(36, 24)
        Me.btnRefresh.TabIndex = 819
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'DTPEnd
        '
        Me.DTPEnd.CustomFormat = "dd/mm/yyyy"
        Me.DTPEnd.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.C1DynamicHelp1.SetHelpTopic(Me.DTPEnd, Nothing)
        Me.C1DynamicHelp2.SetHelpTopic(Me.DTPEnd, Nothing)
        Me.DTPEnd.Location = New System.Drawing.Point(263, 34)
        Me.DTPEnd.Name = "DTPEnd"
        Me.DTPEnd.Size = New System.Drawing.Size(103, 23)
        Me.DTPEnd.TabIndex = 818
        Me.DTPEnd.Value = New Date(2020, 2, 1, 0, 0, 0, 0)
        '
        'DTPStart
        '
        Me.DTPStart.CustomFormat = "dd/mm/yyyy"
        Me.DTPStart.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.C1DynamicHelp1.SetHelpTopic(Me.DTPStart, Nothing)
        Me.C1DynamicHelp2.SetHelpTopic(Me.DTPStart, Nothing)
        Me.DTPStart.Location = New System.Drawing.Point(115, 34)
        Me.DTPStart.Name = "DTPStart"
        Me.DTPStart.Size = New System.Drawing.Size(108, 23)
        Me.DTPStart.TabIndex = 817
        Me.DTPStart.Value = New Date(2020, 2, 1, 0, 0, 0, 0)
        '
        'cmbKapal
        '
        Me.cmbKapal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cmbKapal.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.cmbKapal.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbKapal.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbKapal.FormattingEnabled = True
        Me.C1DynamicHelp2.SetHelpTopic(Me.cmbKapal, Nothing)
        Me.C1DynamicHelp1.SetHelpTopic(Me.cmbKapal, Nothing)
        Me.cmbKapal.IntegralHeight = False
        Me.cmbKapal.Location = New System.Drawing.Point(499, 62)
        Me.cmbKapal.Name = "cmbKapal"
        Me.cmbKapal.Size = New System.Drawing.Size(251, 25)
        Me.cmbKapal.TabIndex = 812
        '
        'cmbPancang
        '
        Me.cmbPancang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cmbPancang.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbPancang.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPancang.FormattingEnabled = True
        Me.C1DynamicHelp2.SetHelpTopic(Me.cmbPancang, Nothing)
        Me.C1DynamicHelp1.SetHelpTopic(Me.cmbPancang, Nothing)
        Me.cmbPancang.IntegralHeight = False
        Me.cmbPancang.Location = New System.Drawing.Point(115, 61)
        Me.cmbPancang.Name = "cmbPancang"
        Me.cmbPancang.Size = New System.Drawing.Size(251, 25)
        Me.cmbPancang.TabIndex = 811
        '
        'C1DynamicHelp1
        '
        Me.C1DynamicHelp1.Location = New System.Drawing.Point(1242, 0)
        Me.C1DynamicHelp1.Name = "C1DynamicHelp1"
        Me.C1DynamicHelp1.Size = New System.Drawing.Size(8, 95)
        Me.C1DynamicHelp1.TabIndex = 825
        '
        'txtNoNota
        '
        Me.C1DynamicHelp1.SetHelpTopic(Me.txtNoNota, Nothing)
        Me.C1DynamicHelp2.SetHelpTopic(Me.txtNoNota, Nothing)
        Me.txtNoNota.Location = New System.Drawing.Point(115, 9)
        Me.txtNoNota.Name = "txtNoNota"
        Me.txtNoNota.Size = New System.Drawing.Size(251, 22)
        Me.txtNoNota.TabIndex = 828
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.C1DynamicHelp1.SetHelpTopic(Me.Label2, Nothing)
        Me.C1DynamicHelp2.SetHelpTopic(Me.Label2, Nothing)
        Me.Label2.Location = New System.Drawing.Point(14, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 17)
        Me.Label2.TabIndex = 829
        Me.Label2.Text = "No Nota"
        '
        'txtTrip
        '
        Me.C1DynamicHelp1.SetHelpTopic(Me.txtTrip, Nothing)
        Me.C1DynamicHelp2.SetHelpTopic(Me.txtTrip, Nothing)
        Me.txtTrip.Location = New System.Drawing.Point(499, 36)
        Me.txtTrip.Name = "txtTrip"
        Me.txtTrip.Size = New System.Drawing.Size(125, 22)
        Me.txtTrip.TabIndex = 830
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.C1DynamicHelp1.SetHelpTopic(Me.Label3, Nothing)
        Me.C1DynamicHelp2.SetHelpTopic(Me.Label3, Nothing)
        Me.Label3.Location = New System.Drawing.Point(398, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 17)
        Me.Label3.TabIndex = 831
        Me.Label3.Text = "Sub Petani"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.C1DynamicHelp1.SetHelpTopic(Me.Label4, Nothing)
        Me.C1DynamicHelp2.SetHelpTopic(Me.Label4, Nothing)
        Me.Label4.Location = New System.Drawing.Point(14, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 17)
        Me.Label4.TabIndex = 832
        Me.Label4.Text = "Pancang"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.C1DynamicHelp1.SetHelpTopic(Me.Label5, Nothing)
        Me.C1DynamicHelp2.SetHelpTopic(Me.Label5, Nothing)
        Me.Label5.Location = New System.Drawing.Point(14, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 17)
        Me.Label5.TabIndex = 833
        Me.Label5.Text = "Tanggal Nota"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.C1DynamicHelp1.SetHelpTopic(Me.Label6, Nothing)
        Me.C1DynamicHelp2.SetHelpTopic(Me.Label6, Nothing)
        Me.Label6.Location = New System.Drawing.Point(398, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 17)
        Me.Label6.TabIndex = 834
        Me.Label6.Text = "Trip"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.C1DynamicHelp1.SetHelpTopic(Me.Label7, Nothing)
        Me.C1DynamicHelp2.SetHelpTopic(Me.Label7, Nothing)
        Me.Label7.Location = New System.Drawing.Point(398, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 17)
        Me.Label7.TabIndex = 835
        Me.Label7.Text = "Kapal"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.C1DynamicHelp1.SetHelpTopic(Me.Label9, Nothing)
        Me.C1DynamicHelp2.SetHelpTopic(Me.Label9, Nothing)
        Me.Label9.Location = New System.Drawing.Point(229, 37)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(28, 17)
        Me.Label9.TabIndex = 837
        Me.Label9.Text = "s/d"
        '
        'FrmInputHargaNego
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1260, 703)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1DynamicHelp2.SetHelpTopic(Me, Nothing)
        Me.C1DynamicHelp1.SetHelpTopic(Me, Nothing)
        Me.Name = "FrmInputHargaNego"
        Me.Text = "FrmInputHargaNego"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents pnlHead As Panel
    Friend WithEvents lblHead As Label
    Friend WithEvents cmbS_Petani As ComboBox
    Friend WithEvents btnRefresh As Button
    Friend WithEvents DTPEnd As DateTimePicker
    Friend WithEvents DTPStart As DateTimePicker
    Friend WithEvents cmbKapal As ComboBox
    Friend WithEvents cmbPancang As ComboBox
    Friend WithEvents Panel7 As Panel
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel6 As Panel
    Friend WithEvents btnsave As Button
    Friend WithEvents btnexit As Button
    Friend WithEvents chkEditAll As CheckBox
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel10 As Panel
    Friend WithEvents C1DynamicHelp1 As C1.Win.C1DynamicHelp.C1DynamicHelp
    Friend WithEvents C1DynamicHelp2 As C1.Win.C1DynamicHelp.C1DynamicHelp
    Friend WithEvents chkDariPurchaser As CheckBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtTrip As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtNoNota As TextBox
End Class
