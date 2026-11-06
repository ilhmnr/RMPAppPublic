<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTrnPoinLoyalty
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtp2 = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpInvoice = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnLoaddata = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtinvoice = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.txtTotHutang = New System.Windows.Forms.TextBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.grpDataTimbangCrane = New XanderUI.XUICustomGroupbox()
        Me.dgvList = New System.Windows.Forms.DataGridView()
        Me.No = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DetailID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TglCashBack = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDPetani = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Petani = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pancang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDPenerimaUang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AlamatID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NamaPenerimaUang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoRekening = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Jenis_Bank = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Keterangan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JumlahPoinYangDiKlaim = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CashBackYangDiterima = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Verifikasi = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.btnexit = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnAjukanAP = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.grpDataTimbangCrane.SuspendLayout()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1053, 31)
        Me.Panel1.TabIndex = 876
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(45, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(210, 17)
        Me.Label8.TabIndex = 828
        Me.Label8.Text = "Verifikasi Cashback Loyalty"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.RMPApp.My.Resources.Resources.Cashback2
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(39, 31)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(97, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 15)
        Me.Label3.TabIndex = 875
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1053, 603)
        Me.GroupBox2.TabIndex = 877
        Me.GroupBox2.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.SplitContainer2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1047, 584)
        Me.GroupBox1.TabIndex = 873
        Me.GroupBox1.TabStop = False
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
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer2.Panel1.Controls.Add(Me.dtp2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer2.Panel1.Controls.Add(Me.dtpInvoice)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.btnLoaddata)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtinvoice)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.dtp1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtTotHutang)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer1)
        Me.SplitContainer2.Size = New System.Drawing.Size(1041, 565)
        Me.SplitContainer2.SplitterDistance = 89
        Me.SplitContainer2.TabIndex = 75
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(286, 62)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(22, 17)
        Me.Label9.TabIndex = 275
        Me.Label9.Text = "to"
        '
        'dtp2
        '
        Me.dtp2.CustomFormat = "dd MMM yyyy"
        Me.dtp2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp2.Location = New System.Drawing.Point(311, 59)
        Me.dtp2.Name = "dtp2"
        Me.dtp2.Size = New System.Drawing.Size(153, 23)
        Me.dtp2.TabIndex = 274
        Me.dtp2.Value = New Date(2019, 4, 8, 0, 0, 0, 0)
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(111, 36)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(11, 17)
        Me.Label7.TabIndex = 273
        Me.Label7.Text = ":"
        '
        'dtpInvoice
        '
        Me.dtpInvoice.CustomFormat = "dd MMM yyyy"
        Me.dtpInvoice.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpInvoice.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInvoice.Location = New System.Drawing.Point(129, 33)
        Me.dtpInvoice.Name = "dtpInvoice"
        Me.dtpInvoice.Size = New System.Drawing.Size(152, 23)
        Me.dtpInvoice.TabIndex = 272
        Me.dtpInvoice.Value = New Date(2019, 4, 8, 0, 0, 0, 0)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(12, 59)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 17)
        Me.Label6.TabIndex = 271
        Me.Label6.Text = "Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 17)
        Me.Label1.TabIndex = 270
        Me.Label1.Text = "Date.Invoice"
        '
        'btnLoaddata
        '
        Me.btnLoaddata.BackColor = System.Drawing.Color.White
        Me.btnLoaddata.BackgroundImage = Global.RMPApp.My.Resources.Resources.find20
        Me.btnLoaddata.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLoaddata.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLoaddata.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.btnLoaddata.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.btnLoaddata.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.btnLoaddata.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoaddata.Location = New System.Drawing.Point(470, 59)
        Me.btnLoaddata.Name = "btnLoaddata"
        Me.btnLoaddata.Size = New System.Drawing.Size(23, 23)
        Me.btnLoaddata.TabIndex = 269
        Me.btnLoaddata.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(112, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 17)
        Me.Label5.TabIndex = 268
        Me.Label5.Text = ":"
        '
        'txtinvoice
        '
        Me.txtinvoice.BackColor = System.Drawing.Color.White
        Me.txtinvoice.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtinvoice.Location = New System.Drawing.Point(129, 11)
        Me.txtinvoice.Name = "txtinvoice"
        Me.txtinvoice.ReadOnly = True
        Me.txtinvoice.Size = New System.Drawing.Size(152, 13)
        Me.txtinvoice.TabIndex = 267
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(12, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 17)
        Me.Label4.TabIndex = 266
        Me.Label4.Text = "No.Invoice"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(111, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 17)
        Me.Label2.TabIndex = 263
        Me.Label2.Text = ":"
        '
        'dtp1
        '
        Me.dtp1.CustomFormat = "dd MMM yyyy"
        Me.dtp1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp1.Location = New System.Drawing.Point(128, 59)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(153, 23)
        Me.dtp1.TabIndex = 265
        Me.dtp1.Value = New Date(2019, 4, 8, 0, 0, 0, 0)
        '
        'txtTotHutang
        '
        Me.txtTotHutang.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotHutang.Location = New System.Drawing.Point(1068, 8)
        Me.txtTotHutang.Multiline = True
        Me.txtTotHutang.Name = "txtTotHutang"
        Me.txtTotHutang.Size = New System.Drawing.Size(145, 51)
        Me.txtTotHutang.TabIndex = 236
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnsave)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnexit)
        Me.SplitContainer1.Size = New System.Drawing.Size(1041, 472)
        Me.SplitContainer1.SplitterDistance = 421
        Me.SplitContainer1.TabIndex = 0
        '
        'grpDataTimbangCrane
        '
        Me.grpDataTimbangCrane.BorderColor = System.Drawing.Color.DodgerBlue
        Me.grpDataTimbangCrane.BorderWidth = 1
        Me.grpDataTimbangCrane.Controls.Add(Me.dgvList)
        Me.grpDataTimbangCrane.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDataTimbangCrane.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDataTimbangCrane.Location = New System.Drawing.Point(0, 0)
        Me.grpDataTimbangCrane.Name = "grpDataTimbangCrane"
        Me.grpDataTimbangCrane.ShowText = True
        Me.grpDataTimbangCrane.Size = New System.Drawing.Size(1041, 421)
        Me.grpDataTimbangCrane.TabIndex = 215
        Me.grpDataTimbangCrane.TabStop = False
        Me.grpDataTimbangCrane.Text = "Verifikai Poin"
        Me.grpDataTimbangCrane.TextColor = System.Drawing.Color.Navy
        '
        'dgvList
        '
        Me.dgvList.AllowUserToAddRows = False
        Me.dgvList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvList.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(244, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.No, Me.DetailID, Me.TglCashBack, Me.IDPetani, Me.Petani, Me.Pancang, Me.IDPenerimaUang, Me.AlamatID, Me.NamaPenerimaUang, Me.NoRekening, Me.Jenis_Bank, Me.Keterangan, Me.JumlahPoinYangDiKlaim, Me.CashBackYangDiterima, Me.Verifikasi})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvList.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvList.EnableHeadersVisualStyles = False
        Me.dgvList.Location = New System.Drawing.Point(6, 22)
        Me.dgvList.Name = "dgvList"
        Me.dgvList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Honeydew
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvList.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvList.RowHeadersVisible = False
        Me.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvList.Size = New System.Drawing.Size(1029, 393)
        Me.dgvList.TabIndex = 429
        '
        'No
        '
        Me.No.HeaderText = "No."
        Me.No.Name = "No"
        Me.No.ReadOnly = True
        Me.No.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.No.Width = 50
        '
        'DetailID
        '
        Me.DetailID.HeaderText = "DetailID"
        Me.DetailID.Name = "DetailID"
        Me.DetailID.ReadOnly = True
        Me.DetailID.Visible = False
        '
        'TglCashBack
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "d"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.TglCashBack.DefaultCellStyle = DataGridViewCellStyle2
        Me.TglCashBack.HeaderText = "Tgl.CashBack"
        Me.TglCashBack.Name = "TglCashBack"
        Me.TglCashBack.ReadOnly = True
        Me.TglCashBack.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'IDPetani
        '
        Me.IDPetani.HeaderText = "IDPetani"
        Me.IDPetani.Name = "IDPetani"
        Me.IDPetani.ReadOnly = True
        Me.IDPetani.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.IDPetani.Width = 80
        '
        'Petani
        '
        Me.Petani.HeaderText = "Petani"
        Me.Petani.Name = "Petani"
        Me.Petani.ReadOnly = True
        Me.Petani.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Pancang
        '
        Me.Pancang.HeaderText = "Pancang"
        Me.Pancang.Name = "Pancang"
        Me.Pancang.ReadOnly = True
        Me.Pancang.Width = 120
        '
        'IDPenerimaUang
        '
        Me.IDPenerimaUang.HeaderText = "IDPenerimaUang"
        Me.IDPenerimaUang.Name = "IDPenerimaUang"
        Me.IDPenerimaUang.ReadOnly = True
        Me.IDPenerimaUang.Width = 120
        '
        'AlamatID
        '
        Me.AlamatID.HeaderText = "AlamatID"
        Me.AlamatID.Name = "AlamatID"
        Me.AlamatID.ReadOnly = True
        '
        'NamaPenerimaUang
        '
        Me.NamaPenerimaUang.HeaderText = "NamaPenerimaUang"
        Me.NamaPenerimaUang.Name = "NamaPenerimaUang"
        Me.NamaPenerimaUang.ReadOnly = True
        Me.NamaPenerimaUang.Width = 150
        '
        'NoRekening
        '
        Me.NoRekening.HeaderText = "NoRekening"
        Me.NoRekening.Name = "NoRekening"
        Me.NoRekening.ReadOnly = True
        Me.NoRekening.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Jenis_Bank
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Jenis_Bank.DefaultCellStyle = DataGridViewCellStyle3
        Me.Jenis_Bank.HeaderText = "Jenis Bank"
        Me.Jenis_Bank.Name = "Jenis_Bank"
        Me.Jenis_Bank.ReadOnly = True
        Me.Jenis_Bank.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Keterangan
        '
        Me.Keterangan.HeaderText = "Keterangan"
        Me.Keterangan.Name = "Keterangan"
        Me.Keterangan.ReadOnly = True
        Me.Keterangan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'JumlahPoinYangDiKlaim
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.JumlahPoinYangDiKlaim.DefaultCellStyle = DataGridViewCellStyle4
        Me.JumlahPoinYangDiKlaim.HeaderText = "JumlahPoinYangDiKlaim"
        Me.JumlahPoinYangDiKlaim.Name = "JumlahPoinYangDiKlaim"
        Me.JumlahPoinYangDiKlaim.ReadOnly = True
        Me.JumlahPoinYangDiKlaim.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.JumlahPoinYangDiKlaim.Width = 170
        '
        'CashBackYangDiterima
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.CashBackYangDiterima.DefaultCellStyle = DataGridViewCellStyle5
        Me.CashBackYangDiterima.HeaderText = "CashBack yang Diterima"
        Me.CashBackYangDiterima.Name = "CashBackYangDiterima"
        Me.CashBackYangDiterima.ReadOnly = True
        Me.CashBackYangDiterima.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CashBackYangDiterima.Width = 150
        '
        'Verifikasi
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = False
        Me.Verifikasi.DefaultCellStyle = DataGridViewCellStyle6
        Me.Verifikasi.HeaderText = "Verifikasi"
        Me.Verifikasi.Name = "Verifikasi"
        Me.Verifikasi.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Verifikasi.Width = 80
        '
        'btnsave
        '
        Me.btnsave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnsave.BackColor = System.Drawing.Color.AliceBlue
        Me.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsave.Font = New System.Drawing.Font("Gabriola", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsave.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.btnsave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnsave.Location = New System.Drawing.Point(886, 6)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(75, 35)
        Me.btnsave.TabIndex = 250
        Me.btnsave.Text = "&Save"
        Me.btnsave.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnsave.UseVisualStyleBackColor = False
        '
        'btnexit
        '
        Me.btnexit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnexit.BackColor = System.Drawing.Color.AliceBlue
        Me.btnexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnexit.Font = New System.Drawing.Font("Gabriola", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexit.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.btnexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnexit.Location = New System.Drawing.Point(960, 6)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(75, 35)
        Me.btnexit.TabIndex = 249
        Me.btnexit.Text = "Exit"
        Me.btnexit.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnexit.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Gabriola", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRefresh.Location = New System.Drawing.Point(735, 528)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 34)
        Me.btnRefresh.TabIndex = 878
        Me.btnRefresh.Text = "&Refresh"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'btnAjukanAP
        '
        Me.btnAjukanAP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAjukanAP.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnAjukanAP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAjukanAP.Font = New System.Drawing.Font("Gabriola", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAjukanAP.ForeColor = System.Drawing.Color.White
        Me.btnAjukanAP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAjukanAP.Location = New System.Drawing.Point(817, 528)
        Me.btnAjukanAP.Name = "btnAjukanAP"
        Me.btnAjukanAP.Size = New System.Drawing.Size(89, 34)
        Me.btnAjukanAP.TabIndex = 879
        Me.btnAjukanAP.Text = "&AjukanAP"
        Me.btnAjukanAP.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnAjukanAP.UseVisualStyleBackColor = False
        '
        'FrmTrnPoinLoyalty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1053, 603)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.btnAjukanAP)
        Me.Name = "FrmTrnPoinLoyalty"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmTrnPoinLoyalty"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.grpDataTimbangCrane.ResumeLayout(False)
        Me.grpDataTimbangCrane.PerformLayout()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents SaveFileDialog As SaveFileDialog
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnAjukanAP As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents Label9 As Label
    Friend WithEvents dtp2 As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents dtpInvoice As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnLoaddata As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents txtinvoice As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtp1 As DateTimePicker
    Friend WithEvents txtTotHutang As TextBox
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents grpDataTimbangCrane As XanderUI.XUICustomGroupbox
    Friend WithEvents dgvList As DataGridView
    Friend WithEvents btnsave As Button
    Friend WithEvents btnexit As Button
    Friend WithEvents No As DataGridViewTextBoxColumn
    Friend WithEvents DetailID As DataGridViewTextBoxColumn
    Friend WithEvents TglCashBack As DataGridViewTextBoxColumn
    Friend WithEvents IDPetani As DataGridViewTextBoxColumn
    Friend WithEvents Petani As DataGridViewTextBoxColumn
    Friend WithEvents Pancang As DataGridViewTextBoxColumn
    Friend WithEvents IDPenerimaUang As DataGridViewTextBoxColumn
    Friend WithEvents AlamatID As DataGridViewTextBoxColumn
    Friend WithEvents NamaPenerimaUang As DataGridViewTextBoxColumn
    Friend WithEvents NoRekening As DataGridViewTextBoxColumn
    Friend WithEvents Jenis_Bank As DataGridViewTextBoxColumn
    Friend WithEvents Keterangan As DataGridViewTextBoxColumn
    Friend WithEvents JumlahPoinYangDiKlaim As DataGridViewTextBoxColumn
    Friend WithEvents CashBackYangDiterima As DataGridViewTextBoxColumn
    Friend WithEvents Verifikasi As DataGridViewCheckBoxColumn
End Class
