<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMstHariLiburNasional
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMstHariLiburNasional))
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.TxtKeterangan = New System.Windows.Forms.TextBox()
        Me.pnlHdr = New System.Windows.Forms.Panel()
        Me.XuiCustomGroupbox4 = New XanderUI.XUICustomGroupbox()
        Me.C1FlexGridSearchPanel1 = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.XuiCustomGroupbox1 = New XanderUI.XUICustomGroupbox()
        Me.DtpTglLibur = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.XuiCustomGroupbox2 = New XanderUI.XUICustomGroupbox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.Panel14 = New System.Windows.Forms.Panel()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHdr.SuspendLayout()
        Me.XuiCustomGroupbox4.SuspendLayout()
        Me.XuiCustomGroupbox1.SuspendLayout()
        Me.XuiCustomGroupbox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'fg
        '
        Me.fg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D
        Me.fg.ColumnInfo = "10,1,0,0,0,95,Columns:1{Style:""TextAlign:GeneralCenter;ImageAlign:CenterCenter;"";" &
    "}" & Global.Microsoft.VisualBasic.ChrW(9) & "5{Style:""TextAlign:GeneralCenter;ImageAlign:CenterCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.fg.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.fg.Location = New System.Drawing.Point(26, 42)
        Me.fg.Name = "fg"
        Me.fg.Rows.Count = 1
        Me.fg.Rows.DefaultSize = 19
        Me.fg.Size = New System.Drawing.Size(1257, 485)
        Me.fg.StyleInfo = resources.GetString("fg.StyleInfo")
        Me.fg.TabIndex = 152
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnRefresh.Location = New System.Drawing.Point(13, 22)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(85, 30)
        Me.btnRefresh.TabIndex = 154
        Me.btnRefresh.Text = "REFRESH"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(287, 22)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(85, 30)
        Me.btnSave.TabIndex = 143
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEdit.FlatAppearance.BorderSize = 0
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.Color.White
        Me.btnEdit.Location = New System.Drawing.Point(104, 22)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(85, 30)
        Me.btnEdit.TabIndex = 145
        Me.btnEdit.Text = "EDIT"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAdd.FlatAppearance.BorderSize = 0
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnAdd.Location = New System.Drawing.Point(195, 22)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(85, 30)
        Me.btnAdd.TabIndex = 147
        Me.btnAdd.Text = "ADD"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.Red
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(378, 22)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(85, 30)
        Me.btnCancel.TabIndex = 146
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'TxtKeterangan
        '
        Me.TxtKeterangan.BackColor = System.Drawing.SystemColors.Window
        Me.TxtKeterangan.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKeterangan.Location = New System.Drawing.Point(137, 66)
        Me.TxtKeterangan.Name = "TxtKeterangan"
        Me.TxtKeterangan.Size = New System.Drawing.Size(374, 23)
        Me.TxtKeterangan.TabIndex = 0
        '
        'pnlHdr
        '
        Me.pnlHdr.BackColor = System.Drawing.Color.Transparent
        Me.pnlHdr.Controls.Add(Me.XuiCustomGroupbox4)
        Me.pnlHdr.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHdr.Location = New System.Drawing.Point(0, 0)
        Me.pnlHdr.Name = "pnlHdr"
        Me.pnlHdr.Size = New System.Drawing.Size(1309, 116)
        Me.pnlHdr.TabIndex = 151
        '
        'XuiCustomGroupbox4
        '
        Me.XuiCustomGroupbox4.BackColor = System.Drawing.Color.LawnGreen
        Me.XuiCustomGroupbox4.BorderColor = System.Drawing.Color.Black
        Me.XuiCustomGroupbox4.BorderWidth = 1
        Me.XuiCustomGroupbox4.Controls.Add(Me.Panel4)
        Me.XuiCustomGroupbox4.Controls.Add(Me.Panel3)
        Me.XuiCustomGroupbox4.Controls.Add(Me.Panel2)
        Me.XuiCustomGroupbox4.Controls.Add(Me.Panel5)
        Me.XuiCustomGroupbox4.Controls.Add(Me.Panel1)
        Me.XuiCustomGroupbox4.Controls.Add(Me.XuiCustomGroupbox1)
        Me.XuiCustomGroupbox4.Controls.Add(Me.DtpTglLibur)
        Me.XuiCustomGroupbox4.Controls.Add(Me.TxtKeterangan)
        Me.XuiCustomGroupbox4.Controls.Add(Me.Label4)
        Me.XuiCustomGroupbox4.Controls.Add(Me.Label3)
        Me.XuiCustomGroupbox4.Controls.Add(Me.Label2)
        Me.XuiCustomGroupbox4.Controls.Add(Me.Label1)
        Me.XuiCustomGroupbox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XuiCustomGroupbox4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XuiCustomGroupbox4.Location = New System.Drawing.Point(0, 0)
        Me.XuiCustomGroupbox4.Name = "XuiCustomGroupbox4"
        Me.XuiCustomGroupbox4.ShowText = True
        Me.XuiCustomGroupbox4.Size = New System.Drawing.Size(1309, 116)
        Me.XuiCustomGroupbox4.TabIndex = 264
        Me.XuiCustomGroupbox4.TabStop = False
        Me.XuiCustomGroupbox4.Text = "Input Data"
        Me.XuiCustomGroupbox4.TextColor = System.Drawing.Color.Black
        '
        'C1FlexGridSearchPanel1
        '
        Me.C1FlexGridSearchPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.C1FlexGridSearchPanel1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1FlexGridSearchPanel1.Location = New System.Drawing.Point(1000, -12)
        Me.C1FlexGridSearchPanel1.Margin = New System.Windows.Forms.Padding(0, 0, 0, 0)
        Me.C1FlexGridSearchPanel1.Name = "C1FlexGridSearchPanel1"
        Me.C1FlexGridSearchPanel1.ShowClearButton = False
        Me.C1FlexGridSearchPanel1.ShowSearchButton = False
        Me.C1FlexGridSearchPanel1.Size = New System.Drawing.Size(286, 40)
        Me.C1FlexGridSearchPanel1.TabIndex = 265
        '
        'XuiCustomGroupbox1
        '
        Me.XuiCustomGroupbox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XuiCustomGroupbox1.BackColor = System.Drawing.Color.LawnGreen
        Me.XuiCustomGroupbox1.BorderColor = System.Drawing.Color.Black
        Me.XuiCustomGroupbox1.BorderWidth = 1
        Me.XuiCustomGroupbox1.Controls.Add(Me.btnSave)
        Me.XuiCustomGroupbox1.Controls.Add(Me.btnRefresh)
        Me.XuiCustomGroupbox1.Controls.Add(Me.btnAdd)
        Me.XuiCustomGroupbox1.Controls.Add(Me.btnCancel)
        Me.XuiCustomGroupbox1.Controls.Add(Me.btnEdit)
        Me.XuiCustomGroupbox1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XuiCustomGroupbox1.Location = New System.Drawing.Point(827, 46)
        Me.XuiCustomGroupbox1.Name = "XuiCustomGroupbox1"
        Me.XuiCustomGroupbox1.ShowText = True
        Me.XuiCustomGroupbox1.Size = New System.Drawing.Size(476, 64)
        Me.XuiCustomGroupbox1.TabIndex = 264
        Me.XuiCustomGroupbox1.TabStop = False
        Me.XuiCustomGroupbox1.Text = "Button Aksi"
        Me.XuiCustomGroupbox1.TextColor = System.Drawing.Color.Black
        '
        'DtpTglLibur
        '
        Me.DtpTglLibur.Location = New System.Drawing.Point(137, 37)
        Me.DtpTglLibur.Name = "DtpTglLibur"
        Me.DtpTglLibur.Size = New System.Drawing.Size(112, 23)
        Me.DtpTglLibur.TabIndex = 52
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(121, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 21)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = ":"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(30, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 21)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "Tanggal"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(121, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 21)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = ":"
        '
        'XuiCustomGroupbox2
        '
        Me.XuiCustomGroupbox2.BackColor = System.Drawing.Color.LawnGreen
        Me.XuiCustomGroupbox2.BorderColor = System.Drawing.Color.Black
        Me.XuiCustomGroupbox2.BorderWidth = 1
        Me.XuiCustomGroupbox2.Controls.Add(Me.Panel11)
        Me.XuiCustomGroupbox2.Controls.Add(Me.C1FlexGridSearchPanel1)
        Me.XuiCustomGroupbox2.Controls.Add(Me.Panel12)
        Me.XuiCustomGroupbox2.Controls.Add(Me.Panel13)
        Me.XuiCustomGroupbox2.Controls.Add(Me.Panel10)
        Me.XuiCustomGroupbox2.Controls.Add(Me.Panel9)
        Me.XuiCustomGroupbox2.Controls.Add(Me.Panel8)
        Me.XuiCustomGroupbox2.Controls.Add(Me.Panel14)
        Me.XuiCustomGroupbox2.Controls.Add(Me.Panel15)
        Me.XuiCustomGroupbox2.Controls.Add(Me.Panel7)
        Me.XuiCustomGroupbox2.Controls.Add(Me.Panel6)
        Me.XuiCustomGroupbox2.Controls.Add(Me.fg)
        Me.XuiCustomGroupbox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XuiCustomGroupbox2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XuiCustomGroupbox2.Location = New System.Drawing.Point(0, 116)
        Me.XuiCustomGroupbox2.Name = "XuiCustomGroupbox2"
        Me.XuiCustomGroupbox2.ShowText = True
        Me.XuiCustomGroupbox2.Size = New System.Drawing.Size(1309, 553)
        Me.XuiCustomGroupbox2.TabIndex = 264
        Me.XuiCustomGroupbox2.TabStop = False
        Me.XuiCustomGroupbox2.Text = "Data Hari Libur Nasional"
        Me.XuiCustomGroupbox2.TextColor = System.Drawing.Color.Black
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(30, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 21)
        Me.Label3.TabIndex = 51
        Me.Label3.Text = "Keterangan"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(7, 97)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(501, 1)
        Me.Panel1.TabIndex = 267
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Location = New System.Drawing.Point(18, 21)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 90)
        Me.Panel2.TabIndex = 268
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Black
        Me.Panel3.Location = New System.Drawing.Point(25, 40)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1, 50)
        Me.Panel3.TabIndex = 268
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Black
        Me.Panel4.Location = New System.Drawing.Point(12, 53)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1, 50)
        Me.Panel4.TabIndex = 268
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Black
        Me.Panel5.Location = New System.Drawing.Point(26, 104)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(401, 1)
        Me.Panel5.TabIndex = 267
        '
        'Panel6
        '
        Me.Panel6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel6.BackColor = System.Drawing.Color.Black
        Me.Panel6.Location = New System.Drawing.Point(8, 533)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(415, 1)
        Me.Panel6.TabIndex = 154
        '
        'Panel7
        '
        Me.Panel7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel7.BackColor = System.Drawing.Color.Black
        Me.Panel7.Location = New System.Drawing.Point(882, 533)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(415, 1)
        Me.Panel7.TabIndex = 154
        '
        'Panel8
        '
        Me.Panel8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel8.BackColor = System.Drawing.Color.Black
        Me.Panel8.Location = New System.Drawing.Point(885, 30)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(415, 1)
        Me.Panel8.TabIndex = 154
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.Black
        Me.Panel9.Location = New System.Drawing.Point(8, 30)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(415, 1)
        Me.Panel9.TabIndex = 154
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.Black
        Me.Panel10.Location = New System.Drawing.Point(19, 20)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(1, 100)
        Me.Panel10.TabIndex = 155
        '
        'Panel12
        '
        Me.Panel12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel12.BackColor = System.Drawing.Color.Black
        Me.Panel12.Location = New System.Drawing.Point(1289, 247)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(1, 300)
        Me.Panel12.TabIndex = 155
        '
        'Panel13
        '
        Me.Panel13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel13.BackColor = System.Drawing.Color.Black
        Me.Panel13.Location = New System.Drawing.Point(1289, 20)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(1, 100)
        Me.Panel13.TabIndex = 155
        '
        'Panel11
        '
        Me.Panel11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel11.BackColor = System.Drawing.Color.Black
        Me.Panel11.Location = New System.Drawing.Point(19, 247)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(1, 300)
        Me.Panel11.TabIndex = 155
        '
        'Panel15
        '
        Me.Panel15.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel15.BackColor = System.Drawing.Color.Black
        Me.Panel15.Location = New System.Drawing.Point(498, 534)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(315, 1)
        Me.Panel15.TabIndex = 154
        '
        'Panel14
        '
        Me.Panel14.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel14.BackColor = System.Drawing.Color.Black
        Me.Panel14.Location = New System.Drawing.Point(556, 541)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(215, 1)
        Me.Panel14.TabIndex = 154
        '
        'FrmMstHariLiburNasional
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1309, 669)
        Me.Controls.Add(Me.XuiCustomGroupbox2)
        Me.Controls.Add(Me.pnlHdr)
        Me.Name = "FrmMstHariLiburNasional"
        Me.Text = "FrmMstHariLiburNasional"
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHdr.ResumeLayout(False)
        Me.XuiCustomGroupbox4.ResumeLayout(False)
        Me.XuiCustomGroupbox4.PerformLayout()
        Me.XuiCustomGroupbox1.ResumeLayout(False)
        Me.XuiCustomGroupbox1.PerformLayout()
        Me.XuiCustomGroupbox2.ResumeLayout(False)
        Me.XuiCustomGroupbox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents TxtKeterangan As TextBox
    Friend WithEvents pnlHdr As Panel
    Friend WithEvents DtpTglLibur As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents XuiCustomGroupbox4 As XanderUI.XUICustomGroupbox
    Friend WithEvents XuiCustomGroupbox1 As XanderUI.XUICustomGroupbox
    Friend WithEvents XuiCustomGroupbox2 As XanderUI.XUICustomGroupbox
    Friend WithEvents C1FlexGridSearchPanel1 As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents Panel13 As Panel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel14 As Panel
    Friend WithEvents Panel15 As Panel
End Class
