<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTrnBuktiTrfPengajuanPoin
    Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTrnBuktiTrfPengajuanPoin))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnadd = New System.Windows.Forms.Button()
        Me.btncancel = New System.Windows.Forms.Button()
        Me.chkBri = New System.Windows.Forms.CheckBox()
        Me.btnedit = New System.Windows.Forms.Button()
        Me.chkBni = New System.Windows.Forms.CheckBox()
        Me.chkMandiri = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbBank = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.btnexit = New System.Windows.Forms.Button()
        Me.btnpdf = New System.Windows.Forms.Button()
        Me.pdfuploadbox = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtptrf = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtp2 = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpInvoice = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnLoaddata = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtNoInvoice = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtinvoice = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.txtTotHutang = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvList = New System.Windows.Forms.DataGridView()
        Me.No = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DetailID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TransID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDToko = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TanggalPengajuan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NamaToko = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDSupplier = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Supplier = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JenisBank = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RekTujuan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NamaRek = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoInvoice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IndTF = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Gagal_Transfer = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.HapusBaris = New System.Windows.Forms.DataGridViewImageColumn()
        Me.grpDataTimbangCrane = New XanderUI.XUICustomGroupbox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnlHead = New System.Windows.Forms.Panel()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDataTimbangCrane.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox2.Controls.Add(Me.btnadd)
        Me.GroupBox2.Controls.Add(Me.btncancel)
        Me.GroupBox2.Controls.Add(Me.chkBri)
        Me.GroupBox2.Controls.Add(Me.btnedit)
        Me.GroupBox2.Controls.Add(Me.chkBni)
        Me.GroupBox2.Controls.Add(Me.chkMandiri)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.cmbBank)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.btnsave)
        Me.GroupBox2.Controls.Add(Me.btnexit)
        Me.GroupBox2.Controls.Add(Me.btnpdf)
        Me.GroupBox2.Controls.Add(Me.pdfuploadbox)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.dtptrf)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.dtp2)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.dtpInvoice)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.btnLoaddata)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.TxtNoInvoice)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtinvoice)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.dtp1)
        Me.GroupBox2.Controls.Add(Me.txtTotHutang)
        Me.GroupBox2.Controls.Add(Me.Panel1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(0, 57)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1062, 223)
        Me.GroupBox2.TabIndex = 905629
        Me.GroupBox2.TabStop = False
        '
        'btnadd
        '
        Me.btnadd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnadd.BackColor = System.Drawing.Color.AliceBlue
        Me.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnadd.Font = New System.Drawing.Font("Gabriola", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnadd.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.btnadd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnadd.Location = New System.Drawing.Point(569, 80)
        Me.btnadd.Name = "btnadd"
        Me.btnadd.Size = New System.Drawing.Size(75, 33)
        Me.btnadd.TabIndex = 905653
        Me.btnadd.Text = "&Add"
        Me.btnadd.UseVisualStyleBackColor = False
        Me.btnadd.Visible = False
        '
        'btncancel
        '
        Me.btncancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btncancel.BackColor = System.Drawing.Color.AliceBlue
        Me.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncancel.Font = New System.Drawing.Font("Gabriola", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncancel.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.btncancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btncancel.Location = New System.Drawing.Point(569, 158)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(75, 33)
        Me.btncancel.TabIndex = 905657
        Me.btncancel.Text = "Cancel"
        Me.btncancel.UseVisualStyleBackColor = False
        Me.btncancel.Visible = False
        '
        'chkBri
        '
        Me.chkBri.AutoSize = True
        Me.chkBri.Location = New System.Drawing.Point(287, 134)
        Me.chkBri.Name = "chkBri"
        Me.chkBri.Size = New System.Drawing.Size(44, 21)
        Me.chkBri.TabIndex = 905663
        Me.chkBri.Text = "BRI"
        Me.chkBri.UseVisualStyleBackColor = True
        '
        'btnedit
        '
        Me.btnedit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnedit.BackColor = System.Drawing.Color.AliceBlue
        Me.btnedit.Enabled = False
        Me.btnedit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnedit.Font = New System.Drawing.Font("Gabriola", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnedit.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.btnedit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnedit.Location = New System.Drawing.Point(569, 119)
        Me.btnedit.Name = "btnedit"
        Me.btnedit.Size = New System.Drawing.Size(75, 33)
        Me.btnedit.TabIndex = 905654
        Me.btnedit.Text = "&Edit"
        Me.btnedit.UseVisualStyleBackColor = False
        Me.btnedit.Visible = False
        '
        'chkBni
        '
        Me.chkBni.AutoSize = True
        Me.chkBni.Location = New System.Drawing.Point(235, 134)
        Me.chkBni.Name = "chkBni"
        Me.chkBni.Size = New System.Drawing.Size(46, 21)
        Me.chkBni.TabIndex = 905663
        Me.chkBni.Text = "BNI"
        Me.chkBni.UseVisualStyleBackColor = True
        '
        'chkMandiri
        '
        Me.chkMandiri.AutoSize = True
        Me.chkMandiri.Location = New System.Drawing.Point(151, 134)
        Me.chkMandiri.Name = "chkMandiri"
        Me.chkMandiri.Size = New System.Drawing.Size(78, 21)
        Me.chkMandiri.TabIndex = 905663
        Me.chkMandiri.Text = "MANDIRI"
        Me.chkMandiri.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(134, 135)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(11, 17)
        Me.Label13.TabIndex = 905662
        Me.Label13.Text = ":"
        '
        'cmbBank
        '
        Me.cmbBank.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cmbBank.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBank.FormattingEnabled = True
        Me.cmbBank.Items.AddRange(New Object() {"BNI", "BRI", "BRI-GTG", "BRI-TBH", "RIAU-GTG", "RIAUKEPRI-GTG", "RIAUKEPRI-PKU"})
        Me.cmbBank.Location = New System.Drawing.Point(151, 43)
        Me.cmbBank.Name = "cmbBank"
        Me.cmbBank.Size = New System.Drawing.Size(224, 25)
        Me.cmbBank.TabIndex = 905661
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(14, 136)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(101, 21)
        Me.Label12.TabIndex = 905660
        Me.Label12.Text = "Bank"
        '
        'btnsave
        '
        Me.btnsave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnsave.BackColor = System.Drawing.Color.AliceBlue
        Me.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsave.Font = New System.Drawing.Font("Gabriola", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsave.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.btnsave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnsave.Location = New System.Drawing.Point(913, 183)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(75, 35)
        Me.btnsave.TabIndex = 905656
        Me.btnsave.Text = "&Save"
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
        Me.btnexit.Location = New System.Drawing.Point(987, 183)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(72, 35)
        Me.btnexit.TabIndex = 905655
        Me.btnexit.Text = "Exit"
        Me.btnexit.UseVisualStyleBackColor = False
        '
        'btnpdf
        '
        Me.btnpdf.BackgroundImage = Global.RMPApp.My.Resources.Resources.file
        Me.btnpdf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnpdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnpdf.ForeColor = System.Drawing.Color.White
        Me.btnpdf.Location = New System.Drawing.Point(440, 12)
        Me.btnpdf.Name = "btnpdf"
        Me.btnpdf.Size = New System.Drawing.Size(28, 28)
        Me.btnpdf.TabIndex = 905651
        Me.btnpdf.UseVisualStyleBackColor = True
        '
        'pdfuploadbox
        '
        Me.pdfuploadbox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.pdfuploadbox.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.pdfuploadbox.Location = New System.Drawing.Point(474, 19)
        Me.pdfuploadbox.Name = "pdfuploadbox"
        Me.pdfuploadbox.Size = New System.Drawing.Size(321, 15)
        Me.pdfuploadbox.TabIndex = 905643
        Me.pdfuploadbox.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(134, 108)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(11, 17)
        Me.Label10.TabIndex = 905641
        Me.Label10.Text = ":"
        '
        'dtptrf
        '
        Me.dtptrf.CustomFormat = "dd MMM yyyy"
        Me.dtptrf.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtptrf.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtptrf.Location = New System.Drawing.Point(151, 103)
        Me.dtptrf.Name = "dtptrf"
        Me.dtptrf.Size = New System.Drawing.Size(224, 23)
        Me.dtptrf.TabIndex = 905640
        Me.dtptrf.Value = New Date(2019, 4, 8, 0, 0, 0, 0)
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(14, 108)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(76, 17)
        Me.Label11.TabIndex = 905637
        Me.Label11.Text = "Tgl Transfer"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.AliceBlue
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Centaur", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(381, 15)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(53, 22)
        Me.Button1.TabIndex = 905635
        Me.Button1.Text = "&File"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(252, 168)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(22, 17)
        Me.Label1.TabIndex = 905633
        Me.Label1.Text = "to"
        '
        'dtp2
        '
        Me.dtp2.CustomFormat = "dd MMM yyyy"
        Me.dtp2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp2.Location = New System.Drawing.Point(280, 163)
        Me.dtp2.Name = "dtp2"
        Me.dtp2.Size = New System.Drawing.Size(95, 23)
        Me.dtp2.TabIndex = 905631
        Me.dtp2.Value = New Date(2019, 4, 8, 0, 0, 0, 0)
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(134, 47)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(11, 17)
        Me.Label16.TabIndex = 905630
        Me.Label16.Text = ":"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(134, 79)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(11, 17)
        Me.Label7.TabIndex = 905630
        Me.Label7.Text = ":"
        '
        'dtpInvoice
        '
        Me.dtpInvoice.CustomFormat = "dd MMM yyyy"
        Me.dtpInvoice.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpInvoice.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInvoice.Location = New System.Drawing.Point(151, 74)
        Me.dtpInvoice.Name = "dtpInvoice"
        Me.dtpInvoice.Size = New System.Drawing.Size(224, 23)
        Me.dtpInvoice.TabIndex = 905627
        Me.dtpInvoice.Value = New Date(2019, 4, 8, 0, 0, 0, 0)
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(14, 47)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(74, 17)
        Me.Label15.TabIndex = 905624
        Me.Label15.Text = "Bank Kirim"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(14, 168)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 17)
        Me.Label6.TabIndex = 905625
        Me.Label6.Text = "Tgl Pengajuan"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(14, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 17)
        Me.Label2.TabIndex = 905624
        Me.Label2.Text = "Tgl Transaksi"
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
        Me.btnLoaddata.Location = New System.Drawing.Point(381, 192)
        Me.btnLoaddata.Name = "btnLoaddata"
        Me.btnLoaddata.Size = New System.Drawing.Size(23, 23)
        Me.btnLoaddata.TabIndex = 905621
        Me.btnLoaddata.UseVisualStyleBackColor = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(134, 195)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(11, 17)
        Me.Label14.TabIndex = 905620
        Me.Label14.Text = ":"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(134, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 17)
        Me.Label5.TabIndex = 905620
        Me.Label5.Text = ":"
        '
        'TxtNoInvoice
        '
        Me.TxtNoInvoice.Location = New System.Drawing.Point(151, 192)
        Me.TxtNoInvoice.Name = "TxtNoInvoice"
        Me.TxtNoInvoice.Size = New System.Drawing.Size(224, 22)
        Me.TxtNoInvoice.TabIndex = 905618
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(14, 195)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 17)
        Me.Label8.TabIndex = 905616
        Me.Label8.Text = "No Invoice"
        '
        'txtinvoice
        '
        Me.txtinvoice.Location = New System.Drawing.Point(151, 15)
        Me.txtinvoice.Name = "txtinvoice"
        Me.txtinvoice.Size = New System.Drawing.Size(224, 22)
        Me.txtinvoice.TabIndex = 905618
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(14, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 17)
        Me.Label4.TabIndex = 905616
        Me.Label4.Text = "Transaction ID"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(134, 168)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 17)
        Me.Label3.TabIndex = 905612
        Me.Label3.Text = ":"
        '
        'dtp1
        '
        Me.dtp1.CustomFormat = "dd MMM yyyy"
        Me.dtp1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp1.Location = New System.Drawing.Point(151, 163)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(95, 23)
        Me.dtp1.TabIndex = 905613
        Me.dtp1.Value = New Date(2019, 4, 8, 0, 0, 0, 0)
        '
        'txtTotHutang
        '
        Me.txtTotHutang.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotHutang.Location = New System.Drawing.Point(667, 25)
        Me.txtTotHutang.Multiline = True
        Me.txtTotHutang.Name = "txtTotHutang"
        Me.txtTotHutang.Size = New System.Drawing.Size(145, 51)
        Me.txtTotHutang.TabIndex = 905609
        Me.txtTotHutang.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(3, 219)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1056, 1)
        Me.Panel1.TabIndex = 905608
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
        Me.dgvList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.No, Me.DetailID, Me.TransID, Me.IDToko, Me.TanggalPengajuan, Me.NamaToko, Me.IDSupplier, Me.Supplier, Me.JenisBank, Me.RekTujuan, Me.NamaRek, Me.Amount, Me.NoInvoice, Me.IndTF, Me.Gagal_Transfer, Me.HapusBaris})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvList.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvList.EnableHeadersVisualStyles = False
        Me.dgvList.Location = New System.Drawing.Point(3, 19)
        Me.dgvList.Name = "dgvList"
        Me.dgvList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Honeydew
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvList.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvList.RowHeadersVisible = False
        Me.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvList.Size = New System.Drawing.Size(1056, 238)
        Me.dgvList.TabIndex = 429
        '
        'No
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.No.DefaultCellStyle = DataGridViewCellStyle2
        Me.No.HeaderText = "No"
        Me.No.Name = "No"
        Me.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.No.Width = 50
        '
        'DetailID
        '
        Me.DetailID.HeaderText = "Kode Pengajuan"
        Me.DetailID.Name = "DetailID"
        Me.DetailID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DetailID.Width = 80
        '
        'TransID
        '
        Me.TransID.HeaderText = "TransID"
        Me.TransID.Name = "TransID"
        Me.TransID.Visible = False
        '
        'IDToko
        '
        Me.IDToko.HeaderText = "IDToko"
        Me.IDToko.Name = "IDToko"
        Me.IDToko.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.IDToko.Visible = False
        Me.IDToko.Width = 80
        '
        'TanggalPengajuan
        '
        Me.TanggalPengajuan.HeaderText = "Tgl Pengajuan"
        Me.TanggalPengajuan.Name = "TanggalPengajuan"
        '
        'NamaToko
        '
        Me.NamaToko.HeaderText = "Nama Toko"
        Me.NamaToko.Name = "NamaToko"
        Me.NamaToko.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'IDSupplier
        '
        Me.IDSupplier.HeaderText = "ID Supplier"
        Me.IDSupplier.Name = "IDSupplier"
        '
        'Supplier
        '
        Me.Supplier.HeaderText = "Supplier"
        Me.Supplier.Name = "Supplier"
        '
        'JenisBank
        '
        Me.JenisBank.HeaderText = "Jenis Bank"
        Me.JenisBank.Name = "JenisBank"
        Me.JenisBank.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'RekTujuan
        '
        Me.RekTujuan.HeaderText = "Rek Tujuan"
        Me.RekTujuan.Name = "RekTujuan"
        '
        'NamaRek
        '
        Me.NamaRek.HeaderText = "Nama Rekening"
        Me.NamaRek.Name = "NamaRek"
        '
        'Amount
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Amount.DefaultCellStyle = DataGridViewCellStyle3
        Me.Amount.HeaderText = "Amount"
        Me.Amount.Name = "Amount"
        '
        'NoInvoice
        '
        Me.NoInvoice.HeaderText = "No Invoice"
        Me.NoInvoice.Name = "NoInvoice"
        Me.NoInvoice.Width = 120
        '
        'IndTF
        '
        Me.IndTF.HeaderText = "Sudah Transfer"
        Me.IndTF.Name = "IndTF"
        Me.IndTF.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IndTF.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Gagal_Transfer
        '
        Me.Gagal_Transfer.HeaderText = "Gagal Transfer"
        Me.Gagal_Transfer.Name = "Gagal_Transfer"
        Me.Gagal_Transfer.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Gagal_Transfer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'HapusBaris
        '
        Me.HapusBaris.HeaderText = "Delete"
        Me.HapusBaris.Name = "HapusBaris"
        Me.HapusBaris.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.HapusBaris.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'grpDataTimbangCrane
        '
        Me.grpDataTimbangCrane.BorderColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.grpDataTimbangCrane.BorderWidth = 1
        Me.grpDataTimbangCrane.Controls.Add(Me.dgvList)
        Me.grpDataTimbangCrane.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDataTimbangCrane.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDataTimbangCrane.Location = New System.Drawing.Point(0, 280)
        Me.grpDataTimbangCrane.Name = "grpDataTimbangCrane"
        Me.grpDataTimbangCrane.ShowText = True
        Me.grpDataTimbangCrane.Size = New System.Drawing.Size(1062, 260)
        Me.grpDataTimbangCrane.TabIndex = 905630
        Me.grpDataTimbangCrane.TabStop = False
        Me.grpDataTimbangCrane.TextColor = System.Drawing.Color.Navy
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Rounded MT Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(41, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(363, 28)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Bukti Transfer Pengajuan Poin"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.AliceBlue
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.pnlHead)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1062, 57)
        Me.GroupBox1.TabIndex = 905628
        Me.GroupBox1.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.RMPApp.My.Resources.Resources.icons8_flame_58__1_
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(6, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 36)
        Me.PictureBox1.TabIndex = 905611
        Me.PictureBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(6, 7)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1056, 1)
        Me.Panel2.TabIndex = 905610
        '
        'pnlHead
        '
        Me.pnlHead.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlHead.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.pnlHead.Location = New System.Drawing.Point(3, 53)
        Me.pnlHead.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlHead.Name = "pnlHead"
        Me.pnlHead.Size = New System.Drawing.Size(1056, 1)
        Me.pnlHead.TabIndex = 905608
        '
        'FrmTrnBuktiTrfPengajuanPoin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1062, 540)
        Me.Controls.Add(Me.grpDataTimbangCrane)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmTrnBuktiTrfPengajuanPoin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Upload Bukti Transfer Pengajuan Poin Toko"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDataTimbangCrane.ResumeLayout(False)
        Me.grpDataTimbangCrane.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnpdf As Button
    Friend WithEvents pdfuploadbox As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents dtptrf As DateTimePicker
    Friend WithEvents Label11 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents dtp2 As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents dtpInvoice As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents btnLoaddata As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents txtinvoice As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dtp1 As DateTimePicker
    Friend WithEvents txtTotHutang As TextBox
    Friend WithEvents btnadd As Button
    Friend WithEvents btncancel As Button
    Friend WithEvents btnedit As Button
    Friend WithEvents btnsave As Button
    Friend WithEvents btnexit As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents cmbBank As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents dgvList As DataGridView
    Friend WithEvents grpDataTimbangCrane As XanderUI.XUICustomGroupbox
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents pnlHead As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TxtNoInvoice As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents chkBri As CheckBox
    Friend WithEvents chkBni As CheckBox
    Friend WithEvents chkMandiri As CheckBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents No As DataGridViewTextBoxColumn
    Friend WithEvents DetailID As DataGridViewTextBoxColumn
    Friend WithEvents TransID As DataGridViewTextBoxColumn
    Friend WithEvents IDToko As DataGridViewTextBoxColumn
    Friend WithEvents TanggalPengajuan As DataGridViewTextBoxColumn
    Friend WithEvents NamaToko As DataGridViewTextBoxColumn
    Friend WithEvents IDSupplier As DataGridViewTextBoxColumn
    Friend WithEvents Supplier As DataGridViewTextBoxColumn
    Friend WithEvents JenisBank As DataGridViewTextBoxColumn
    Friend WithEvents RekTujuan As DataGridViewTextBoxColumn
    Friend WithEvents NamaRek As DataGridViewTextBoxColumn
    Friend WithEvents Amount As DataGridViewTextBoxColumn
    Friend WithEvents NoInvoice As DataGridViewTextBoxColumn
    Friend WithEvents IndTF As DataGridViewCheckBoxColumn
    Friend WithEvents Gagal_Transfer As DataGridViewCheckBoxColumn
    Friend WithEvents HapusBaris As DataGridViewImageColumn
End Class
