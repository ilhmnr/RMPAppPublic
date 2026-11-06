<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMonUangMakanPCG
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMonUangMakanPCG))
        Me.btnrefreshh = New System.Windows.Forms.Button()
        Me.schfg = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.grpDataTimbangCrane = New XanderUI.XUICustomGroupbox()
        Me.fg2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.dgvlist = New System.Windows.Forms.DataGridView()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ChkBanklainNya = New System.Windows.Forms.CheckBox()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ChkBni = New System.Windows.Forms.CheckBox()
        Me.BtnCSV = New System.Windows.Forms.Button()
        Me.btnexcel = New System.Windows.Forms.Button()
        Me.ChkMandiri = New System.Windows.Forms.CheckBox()
        Me.rdp2 = New System.Windows.Forms.RadioButton()
        Me.rdp1 = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.ChkHarian = New System.Windows.Forms.CheckBox()
        Me.ChkKaryawan = New System.Windows.Forms.CheckBox()
        Me.dtp2 = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.fg_DS = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.grpDataTimbangCrane.SuspendLayout()
        CType(Me.fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvlist, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.fg_DS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnrefreshh
        '
        Me.btnrefreshh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnrefreshh.BackColor = System.Drawing.Color.AliceBlue
        Me.btnrefreshh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnrefreshh.Font = New System.Drawing.Font("Gabriola", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnrefreshh.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.btnrefreshh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnrefreshh.Location = New System.Drawing.Point(812, 3)
        Me.btnrefreshh.Name = "btnrefreshh"
        Me.btnrefreshh.Size = New System.Drawing.Size(75, 37)
        Me.btnrefreshh.TabIndex = 250
        Me.btnrefreshh.Text = "Refresh"
        Me.btnrefreshh.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnrefreshh.UseVisualStyleBackColor = False
        '
        'schfg
        '
        Me.schfg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.schfg.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.schfg.Location = New System.Drawing.Point(1116, -12)
        Me.schfg.Margin = New System.Windows.Forms.Padding(1)
        Me.schfg.Name = "schfg"
        Me.schfg.ShowClearButton = False
        Me.schfg.ShowSearchButton = False
        Me.schfg.Size = New System.Drawing.Size(208, 37)
        Me.schfg.TabIndex = 194
        '
        'grpDataTimbangCrane
        '
        Me.grpDataTimbangCrane.BorderColor = System.Drawing.Color.DodgerBlue
        Me.grpDataTimbangCrane.BorderWidth = 1
        Me.grpDataTimbangCrane.Controls.Add(Me.fg)
        Me.grpDataTimbangCrane.Controls.Add(Me.fg_DS)
        Me.grpDataTimbangCrane.Controls.Add(Me.fg2)
        Me.grpDataTimbangCrane.Controls.Add(Me.dgvlist)
        Me.grpDataTimbangCrane.Controls.Add(Me.schfg)
        Me.grpDataTimbangCrane.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDataTimbangCrane.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDataTimbangCrane.Location = New System.Drawing.Point(0, 0)
        Me.grpDataTimbangCrane.Name = "grpDataTimbangCrane"
        Me.grpDataTimbangCrane.ShowText = True
        Me.grpDataTimbangCrane.Size = New System.Drawing.Size(1297, 483)
        Me.grpDataTimbangCrane.TabIndex = 215
        Me.grpDataTimbangCrane.TabStop = False
        Me.grpDataTimbangCrane.Text = "Monitoring Lembur Tenaga Kerja"
        Me.grpDataTimbangCrane.TextColor = System.Drawing.Color.Navy
        '
        'fg2
        '
        Me.fg2.ColumnInfo = "10,1,0,0,0,-1,Columns:"
        Me.fg2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fg2.Location = New System.Drawing.Point(3, 19)
        Me.fg2.Name = "fg2"
        Me.fg2.Size = New System.Drawing.Size(1291, 461)
        Me.fg2.TabIndex = 443
        Me.fg2.Visible = False
        '
        'dgvlist
        '
        Me.dgvlist.AllowUserToAddRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvlist.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvlist.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvlist.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvlist.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvlist.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvlist.EnableHeadersVisualStyles = False
        Me.dgvlist.Location = New System.Drawing.Point(3, 19)
        Me.dgvlist.Name = "dgvlist"
        Me.dgvlist.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvlist.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvlist.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvlist.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvlist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvlist.Size = New System.Drawing.Size(1291, 461)
        Me.dgvlist.TabIndex = 438
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnrefreshh)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ChkBanklainNya)
        Me.SplitContainer1.Panel2.Controls.Add(Me.BtnPrint)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Button3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ChkBni)
        Me.SplitContainer1.Panel2.Controls.Add(Me.BtnCSV)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnexcel)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ChkMandiri)
        Me.SplitContainer1.Size = New System.Drawing.Size(1297, 529)
        Me.SplitContainer1.SplitterDistance = 483
        Me.SplitContainer1.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(542, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 256
        Me.Label5.Text = "Bank :"
        '
        'ChkBanklainNya
        '
        Me.ChkBanklainNya.AutoSize = True
        Me.ChkBanklainNya.Location = New System.Drawing.Point(714, 18)
        Me.ChkBanklainNya.Name = "ChkBanklainNya"
        Me.ChkBanklainNya.Size = New System.Drawing.Size(92, 17)
        Me.ChkBanklainNya.TabIndex = 255
        Me.ChkBanklainNya.Text = "Bank lain Nya"
        Me.ChkBanklainNya.UseVisualStyleBackColor = True
        '
        'BtnPrint
        '
        Me.BtnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPrint.BackColor = System.Drawing.Color.AliceBlue
        Me.BtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPrint.Font = New System.Drawing.Font("Gabriola", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.BtnPrint.Image = Global.RMPApp.My.Resources.Resources.PRINTF1
        Me.BtnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPrint.Location = New System.Drawing.Point(1183, 3)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(111, 37)
        Me.BtnPrint.TabIndex = 252
        Me.BtnPrint.Text = "&Print Memo"
        Me.BtnPrint.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.BackColor = System.Drawing.Color.AliceBlue
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Gabriola", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(1073, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(111, 37)
        Me.Button3.TabIndex = 252
        Me.Button3.Text = "Excel Rekap"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.Button3.UseVisualStyleBackColor = False
        '
        'ChkBni
        '
        Me.ChkBni.AutoSize = True
        Me.ChkBni.Location = New System.Drawing.Point(664, 18)
        Me.ChkBni.Name = "ChkBni"
        Me.ChkBni.Size = New System.Drawing.Size(44, 17)
        Me.ChkBni.TabIndex = 254
        Me.ChkBni.Text = "BNI"
        Me.ChkBni.UseVisualStyleBackColor = True
        '
        'BtnCSV
        '
        Me.BtnCSV.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCSV.BackColor = System.Drawing.Color.AliceBlue
        Me.BtnCSV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BtnCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCSV.Font = New System.Drawing.Font("Gabriola", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCSV.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.BtnCSV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCSV.Location = New System.Drawing.Point(887, 3)
        Me.BtnCSV.Name = "BtnCSV"
        Me.BtnCSV.Size = New System.Drawing.Size(75, 37)
        Me.BtnCSV.TabIndex = 250
        Me.BtnCSV.Text = "CSV"
        Me.BtnCSV.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.BtnCSV.UseVisualStyleBackColor = False
        '
        'btnexcel
        '
        Me.btnexcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnexcel.BackColor = System.Drawing.Color.AliceBlue
        Me.btnexcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnexcel.Font = New System.Drawing.Font("Gabriola", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexcel.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.btnexcel.Image = CType(resources.GetObject("btnexcel.Image"), System.Drawing.Image)
        Me.btnexcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnexcel.Location = New System.Drawing.Point(962, 3)
        Me.btnexcel.Name = "btnexcel"
        Me.btnexcel.Size = New System.Drawing.Size(111, 37)
        Me.btnexcel.TabIndex = 252
        Me.btnexcel.Text = "Excel Detail"
        Me.btnexcel.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnexcel.UseVisualStyleBackColor = False
        '
        'ChkMandiri
        '
        Me.ChkMandiri.AutoSize = True
        Me.ChkMandiri.Location = New System.Drawing.Point(586, 18)
        Me.ChkMandiri.Name = "ChkMandiri"
        Me.ChkMandiri.Size = New System.Drawing.Size(72, 17)
        Me.ChkMandiri.TabIndex = 253
        Me.ChkMandiri.Text = "MANDIRI"
        Me.ChkMandiri.UseVisualStyleBackColor = True
        '
        'rdp2
        '
        Me.rdp2.AutoSize = True
        Me.rdp2.Location = New System.Drawing.Point(374, 13)
        Me.rdp2.Name = "rdp2"
        Me.rdp2.Size = New System.Drawing.Size(38, 17)
        Me.rdp2.TabIndex = 259
        Me.rdp2.Text = "P2"
        Me.rdp2.UseVisualStyleBackColor = True
        '
        'rdp1
        '
        Me.rdp1.AutoSize = True
        Me.rdp1.Checked = True
        Me.rdp1.Location = New System.Drawing.Point(330, 13)
        Me.rdp1.Name = "rdp1"
        Me.rdp1.Size = New System.Drawing.Size(38, 17)
        Me.rdp1.TabIndex = 258
        Me.rdp1.TabStop = True
        Me.rdp1.Text = "P1"
        Me.rdp1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 17)
        Me.Label1.TabIndex = 257
        Me.Label1.Text = "Periode"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.SplitContainer2)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 31)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1303, 595)
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
        Me.SplitContainer2.Panel1.Controls.Add(Me.ChkHarian)
        Me.SplitContainer2.Panel1.Controls.Add(Me.ChkKaryawan)
        Me.SplitContainer2.Panel1.Controls.Add(Me.rdp2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.rdp1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.dtp2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer2.Panel1.Controls.Add(Me.dtp1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Button2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Button4)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Button1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer2.Panel1.Controls.Add(Me.TextBox1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer1)
        Me.SplitContainer2.Size = New System.Drawing.Size(1297, 576)
        Me.SplitContainer2.SplitterDistance = 43
        Me.SplitContainer2.TabIndex = 75
        '
        'ChkHarian
        '
        Me.ChkHarian.AutoSize = True
        Me.ChkHarian.Location = New System.Drawing.Point(519, 13)
        Me.ChkHarian.Name = "ChkHarian"
        Me.ChkHarian.Size = New System.Drawing.Size(57, 17)
        Me.ChkHarian.TabIndex = 905640
        Me.ChkHarian.Text = "Harian"
        Me.ChkHarian.UseVisualStyleBackColor = True
        '
        'ChkKaryawan
        '
        Me.ChkKaryawan.AutoSize = True
        Me.ChkKaryawan.Location = New System.Drawing.Point(440, 13)
        Me.ChkKaryawan.Name = "ChkKaryawan"
        Me.ChkKaryawan.Size = New System.Drawing.Size(73, 17)
        Me.ChkKaryawan.TabIndex = 905639
        Me.ChkKaryawan.Text = "Karyawan"
        Me.ChkKaryawan.UseVisualStyleBackColor = True
        '
        'dtp2
        '
        Me.dtp2.CustomFormat = "dd MMM yyyy"
        Me.dtp2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp2.Location = New System.Drawing.Point(196, 10)
        Me.dtp2.Name = "dtp2"
        Me.dtp2.Size = New System.Drawing.Size(91, 23)
        Me.dtp2.TabIndex = 247
        Me.dtp2.Value = New Date(2019, 4, 8, 0, 0, 0, 0)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(177, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(12, 17)
        Me.Label6.TabIndex = 246
        Me.Label6.Text = "-"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(63, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 17)
        Me.Label3.TabIndex = 238
        Me.Label3.Text = ":"
        '
        'dtp1
        '
        Me.dtp1.CustomFormat = "dd MMM yyyy"
        Me.dtp1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp1.Location = New System.Drawing.Point(80, 10)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(91, 23)
        Me.dtp1.TabIndex = 240
        Me.dtp1.Value = New Date(2019, 4, 8, 0, 0, 0, 0)
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button2.Location = New System.Drawing.Point(1140, 11)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(46, 20)
        Me.Button2.TabIndex = 905638
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1187, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 13)
        Me.Label2.TabIndex = 905637
        Me.Label2.Text = "Input Absen Manual"
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(792, 11)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(46, 20)
        Me.Button4.TabIndex = 905636
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.Pink
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(974, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(46, 20)
        Me.Button1.TabIndex = 905636
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(839, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(129, 13)
        Me.Label7.TabIndex = 905635
        Me.Label7.Text = "No Rekening Dari Pancang"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(1021, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 13)
        Me.Label4.TabIndex = 905635
        Me.Label4.Text = "HL atau Tanggal Merah"
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Location = New System.Drawing.Point(1083, 57)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(79, 20)
        Me.TextBox1.TabIndex = 290
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(29, 31)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(29, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(179, 17)
        Me.Label8.TabIndex = 828
        Me.Label8.Text = "Monitoring Uang Makan"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1303, 31)
        Me.Panel1.TabIndex = 879
        '
        'fg_DS
        '
        Me.fg_DS.AllowEditing = False
        Me.fg_DS.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.fg_DS.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fg_DS.ColumnInfo = resources.GetString("fg_DS.ColumnInfo")
        Me.fg_DS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fg_DS.ForeColor = System.Drawing.Color.Black
        Me.fg_DS.Location = New System.Drawing.Point(3, 19)
        Me.fg_DS.Name = "fg_DS"
        Me.fg_DS.Rows.Count = 5
        Me.fg_DS.Rows.DefaultSize = 22
        Me.fg_DS.Size = New System.Drawing.Size(1291, 461)
        Me.fg_DS.StyleInfo = resources.GetString("fg_DS.StyleInfo")
        Me.fg_DS.TabIndex = 447
        '
        'fg
        '
        Me.fg.AllowEditing = False
        Me.fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fg.ColumnInfo = resources.GetString("fg.ColumnInfo")
        Me.fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fg.ForeColor = System.Drawing.Color.Black
        Me.fg.Location = New System.Drawing.Point(3, 19)
        Me.fg.Name = "fg"
        Me.fg.Rows.Count = 5
        Me.fg.Rows.DefaultSize = 22
        Me.fg.Size = New System.Drawing.Size(1291, 461)
        Me.fg.StyleInfo = resources.GetString("fg.StyleInfo")
        Me.fg.TabIndex = 448
        '
        'FrmMonUangMakanPCG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1303, 626)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmMonUangMakanPCG"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmMonUangMakanPCG"
        Me.grpDataTimbangCrane.ResumeLayout(False)
        Me.grpDataTimbangCrane.PerformLayout()
        CType(Me.fg2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvlist, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.fg_DS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnrefreshh As Button
    Friend WithEvents schfg As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents grpDataTimbangCrane As XanderUI.XUICustomGroupbox
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents btnexcel As Button
    Friend WithEvents rdp2 As RadioButton
    Friend WithEvents rdp1 As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label8 As Label
    Friend WithEvents SaveFileDialog As SaveFileDialog
    Friend WithEvents Button2 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents dtp2 As DateTimePicker
    Friend WithEvents dtp1 As DateTimePicker
    Friend WithEvents BtnCSV As Button
    Friend WithEvents dgvlist As DataGridView
    Friend WithEvents Button3 As Button
    Friend WithEvents ChkHarian As CheckBox
    Friend WithEvents ChkKaryawan As CheckBox
    Friend WithEvents ChkMandiri As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ChkBanklainNya As CheckBox
    Friend WithEvents ChkBni As CheckBox
    Friend WithEvents Button4 As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents BtnPrint As Button
    Friend WithEvents fg2 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents fg_DS As C1.Win.C1FlexGrid.C1FlexGrid
    'Friend WithEvents C1WordDocument1 As C1.C1Word.C1WordDocument
End Class
