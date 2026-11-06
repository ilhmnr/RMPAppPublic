<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTrnTukarPoinNew
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.chkS_Petani = New System.Windows.Forms.CheckBox()
        Me.cmbS_Petani = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpInvoice = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnLoaddata = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtinvoice = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.txtTotHutang = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.grpDataTimbangCrane = New XanderUI.XUICustomGroupbox()
        Me.dgvList = New System.Windows.Forms.DataGridView()
        Me.No = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DetailID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDPetani = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Petani = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AlamatID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JumlahPoint = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RpPoint = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sering_antar_IDPancang = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.IDNoRek = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Keterangan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoHP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JumlahPoinCashBack = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HargaPoint = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RpCashBack = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoReffHarga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.btnexit = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnAjukanAP = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkS_Petani
        '
        Me.chkS_Petani.AutoSize = True
        Me.chkS_Petani.FlatAppearance.BorderSize = 0
        Me.chkS_Petani.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkS_Petani.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkS_Petani.Location = New System.Drawing.Point(15, 59)
        Me.chkS_Petani.Name = "chkS_Petani"
        Me.chkS_Petani.Size = New System.Drawing.Size(92, 21)
        Me.chkS_Petani.TabIndex = 275
        Me.chkS_Petani.Text = "Sub Petani"
        Me.chkS_Petani.UseVisualStyleBackColor = True
        '
        'cmbS_Petani
        '
        Me.cmbS_Petani.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cmbS_Petani.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbS_Petani.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbS_Petani.FormattingEnabled = True
        Me.cmbS_Petani.IntegralHeight = False
        Me.cmbS_Petani.Location = New System.Drawing.Point(130, 58)
        Me.cmbS_Petani.Name = "cmbS_Petani"
        Me.cmbS_Petani.Size = New System.Drawing.Size(205, 24)
        Me.cmbS_Petani.TabIndex = 274
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
        Me.dtpInvoice.Location = New System.Drawing.Point(129, 32)
        Me.dtpInvoice.Name = "dtpInvoice"
        Me.dtpInvoice.Size = New System.Drawing.Size(152, 23)
        Me.dtpInvoice.TabIndex = 272
        Me.dtpInvoice.Value = New Date(2019, 4, 8, 0, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 35)
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
        Me.btnLoaddata.Location = New System.Drawing.Point(341, 59)
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
        Me.Label4.Location = New System.Drawing.Point(12, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 17)
        Me.Label4.TabIndex = 266
        Me.Label4.Text = "No.Invoice"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(45, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(262, 17)
        Me.Label8.TabIndex = 828
        Me.Label8.Text = "Tukar Poin Cashback (Manual)New"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(113, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 17)
        Me.Label2.TabIndex = 276
        Me.Label2.Text = ":"
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
        Me.Label3.Location = New System.Drawing.Point(90, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 15)
        Me.Label3.TabIndex = 885
        '
        'txtTotHutang
        '
        Me.txtTotHutang.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotHutang.Location = New System.Drawing.Point(913, 11)
        Me.txtTotHutang.Multiline = True
        Me.txtTotHutang.Name = "txtTotHutang"
        Me.txtTotHutang.Size = New System.Drawing.Size(145, 51)
        Me.txtTotHutang.TabIndex = 236
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.SplitContainer2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1118, 563)
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
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.chkS_Petani)
        Me.SplitContainer2.Panel1.Controls.Add(Me.cmbS_Petani)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer2.Panel1.Controls.Add(Me.dtpInvoice)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.btnLoaddata)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtinvoice)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer2.Panel1.Controls.Add(Me.txtTotHutang)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer1)
        Me.SplitContainer2.Size = New System.Drawing.Size(1112, 544)
        Me.SplitContainer2.SplitterDistance = 89
        Me.SplitContainer2.TabIndex = 75
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
        Me.SplitContainer1.Size = New System.Drawing.Size(1112, 451)
        Me.SplitContainer1.SplitterDistance = 404
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
        Me.grpDataTimbangCrane.Size = New System.Drawing.Size(1112, 404)
        Me.grpDataTimbangCrane.TabIndex = 215
        Me.grpDataTimbangCrane.TabStop = False
        Me.grpDataTimbangCrane.Text = "Tukar Point"
        Me.grpDataTimbangCrane.TextColor = System.Drawing.Color.Navy
        '
        'dgvList
        '
        Me.dgvList.AllowUserToAddRows = False
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
        Me.dgvList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.No, Me.DetailID, Me.IDPetani, Me.Petani, Me.AlamatID, Me.JumlahPoint, Me.RpPoint, Me.Sering_antar_IDPancang, Me.IDNoRek, Me.Keterangan, Me.NoHP, Me.JumlahPoinCashBack, Me.HargaPoint, Me.RpCashBack, Me.NoReffHarga})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvList.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvList.EnableHeadersVisualStyles = False
        Me.dgvList.Location = New System.Drawing.Point(3, 19)
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
        Me.dgvList.Size = New System.Drawing.Size(1106, 382)
        Me.dgvList.TabIndex = 431
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
        Me.DetailID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DetailID.Visible = False
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
        'AlamatID
        '
        Me.AlamatID.HeaderText = "AlamatID"
        Me.AlamatID.Name = "AlamatID"
        Me.AlamatID.ReadOnly = True
        Me.AlamatID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'JumlahPoint
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.JumlahPoint.DefaultCellStyle = DataGridViewCellStyle2
        Me.JumlahPoint.HeaderText = "JumlahPoint"
        Me.JumlahPoint.Name = "JumlahPoint"
        Me.JumlahPoint.ReadOnly = True
        Me.JumlahPoint.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'RpPoint
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.RpPoint.DefaultCellStyle = DataGridViewCellStyle3
        Me.RpPoint.HeaderText = "RpPoint"
        Me.RpPoint.Name = "RpPoint"
        Me.RpPoint.ReadOnly = True
        Me.RpPoint.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Sering_antar_IDPancang
        '
        Me.Sering_antar_IDPancang.HeaderText = "Sering Antar Ke Pancang"
        Me.Sering_antar_IDPancang.Name = "Sering_antar_IDPancang"
        Me.Sering_antar_IDPancang.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Sering_antar_IDPancang.Width = 250
        '
        'IDNoRek
        '
        Me.IDNoRek.HeaderText = "Penerima Uang, Rekening, Bank"
        Me.IDNoRek.Name = "IDNoRek"
        Me.IDNoRek.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IDNoRek.Width = 500
        '
        'Keterangan
        '
        Me.Keterangan.HeaderText = "Keterangan"
        Me.Keterangan.Name = "Keterangan"
        Me.Keterangan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'NoHP
        '
        Me.NoHP.HeaderText = "NoHP"
        Me.NoHP.Name = "NoHP"
        Me.NoHP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'JumlahPoinCashBack
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.JumlahPoinCashBack.DefaultCellStyle = DataGridViewCellStyle4
        Me.JumlahPoinCashBack.HeaderText = "JumlahPoin(CashBack)"
        Me.JumlahPoinCashBack.Name = "JumlahPoinCashBack"
        Me.JumlahPoinCashBack.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.JumlahPoinCashBack.Width = 170
        '
        'HargaPoint
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.HargaPoint.DefaultCellStyle = DataGridViewCellStyle5
        Me.HargaPoint.HeaderText = "HargaPoint"
        Me.HargaPoint.Name = "HargaPoint"
        Me.HargaPoint.ReadOnly = True
        Me.HargaPoint.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.HargaPoint.Width = 80
        '
        'RpCashBack
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.RpCashBack.DefaultCellStyle = DataGridViewCellStyle6
        Me.RpCashBack.HeaderText = "Rp. CashBack"
        Me.RpCashBack.Name = "RpCashBack"
        Me.RpCashBack.ReadOnly = True
        Me.RpCashBack.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.RpCashBack.Width = 150
        '
        'NoReffHarga
        '
        Me.NoReffHarga.HeaderText = "NoReffHarga"
        Me.NoReffHarga.Name = "NoReffHarga"
        Me.NoReffHarga.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.NoReffHarga.Visible = False
        '
        'btnsave
        '
        Me.btnsave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnsave.BackColor = System.Drawing.Color.AliceBlue
        Me.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsave.Font = New System.Drawing.Font("Gabriola", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsave.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.btnsave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnsave.Location = New System.Drawing.Point(957, 2)
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
        Me.btnexit.Location = New System.Drawing.Point(1031, 2)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(75, 35)
        Me.btnexit.TabIndex = 249
        Me.btnexit.Text = "Exit"
        Me.btnexit.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnexit.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 31)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1124, 582)
        Me.GroupBox2.TabIndex = 887
        Me.GroupBox2.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1124, 31)
        Me.Panel1.TabIndex = 886
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Gabriola", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRefresh.Location = New System.Drawing.Point(960, 580)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 34)
        Me.btnRefresh.TabIndex = 888
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
        Me.btnAjukanAP.Location = New System.Drawing.Point(1042, 580)
        Me.btnAjukanAP.Name = "btnAjukanAP"
        Me.btnAjukanAP.Size = New System.Drawing.Size(89, 34)
        Me.btnAjukanAP.TabIndex = 889
        Me.btnAjukanAP.Text = "&AjukanAP"
        Me.btnAjukanAP.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnAjukanAP.UseVisualStyleBackColor = False
        '
        'FrmTrnTukarPoinNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1124, 613)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.btnAjukanAP)
        Me.Name = "FrmTrnTukarPoinNew"
        Me.Text = "FrmTrnTukarPoinNew"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
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
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chkS_Petani As CheckBox
    Friend WithEvents cmbS_Petani As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents dtpInvoice As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents btnLoaddata As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents txtinvoice As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents SaveFileDialog As SaveFileDialog
    Friend WithEvents txtTotHutang As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents grpDataTimbangCrane As XanderUI.XUICustomGroupbox
    Friend WithEvents dgvList As DataGridView
    Friend WithEvents No As DataGridViewTextBoxColumn
    Friend WithEvents DetailID As DataGridViewTextBoxColumn
    Friend WithEvents IDPetani As DataGridViewTextBoxColumn
    Friend WithEvents Petani As DataGridViewTextBoxColumn
    Friend WithEvents AlamatID As DataGridViewTextBoxColumn
    Friend WithEvents JumlahPoint As DataGridViewTextBoxColumn
    Friend WithEvents RpPoint As DataGridViewTextBoxColumn
    Friend WithEvents Sering_antar_IDPancang As DataGridViewComboBoxColumn
    Friend WithEvents IDNoRek As DataGridViewComboBoxColumn
    Friend WithEvents Keterangan As DataGridViewTextBoxColumn
    Friend WithEvents NoHP As DataGridViewTextBoxColumn
    Friend WithEvents JumlahPoinCashBack As DataGridViewTextBoxColumn
    Friend WithEvents HargaPoint As DataGridViewTextBoxColumn
    Friend WithEvents RpCashBack As DataGridViewTextBoxColumn
    Friend WithEvents NoReffHarga As DataGridViewTextBoxColumn
    Friend WithEvents btnsave As Button
    Friend WithEvents btnexit As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnAjukanAP As Button
End Class
