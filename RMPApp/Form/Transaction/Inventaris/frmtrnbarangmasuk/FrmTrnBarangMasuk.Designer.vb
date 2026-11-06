<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTrnBarangMasuk
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent
    'Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTrnBarangMasuk))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CmbPancang = New System.Windows.Forms.ComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.CmbPenanggungJawab = New System.Windows.Forms.ComboBox()
        Me.CmbKondisiBarang = New System.Windows.Forms.ComboBox()
        Me.fg2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.DtpAlokasi = New System.Windows.Forms.DateTimePicker()
        Me.CmbInventarisMasuk = New System.Windows.Forms.ComboBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.CmbSatuan = New System.Windows.Forms.ComboBox()
        Me.CmbKategori = New System.Windows.Forms.ComboBox()
        Me.CmbKodeBarang = New System.Windows.Forms.ComboBox()
        Me.TxtNamaBarang = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ChkKodeBarang = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ChkKategoriBarang = New System.Windows.Forms.CheckBox()
        Me.DtpStart = New System.Windows.Forms.DateTimePicker()
        Me.DtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.RdBPB = New System.Windows.Forms.RadioButton()
        Me.RdPCG = New System.Windows.Forms.RadioButton()
        Me.ChkSatuanBarang = New System.Windows.Forms.CheckBox()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Panel8)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(763, 40)
        Me.Panel1.TabIndex = 1020
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(46, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(240, 28)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Transaksi Barang Masuk"
        '
        'Panel8
        '
        Me.Panel8.BackgroundImage = CType(resources.GetObject("Panel8.BackgroundImage"), System.Drawing.Image)
        Me.Panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel8.Location = New System.Drawing.Point(10, 3)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(35, 35)
        Me.Panel8.TabIndex = 7
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel2.Controls.Add(Me.BtnExit)
        Me.Panel2.Controls.Add(Me.BtnSave)
        Me.Panel2.Controls.Add(Me.btnRefresh)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.CmbPancang)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 507)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(763, 56)
        Me.Panel2.TabIndex = 1021
        '
        'BtnExit
        '
        Me.BtnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExit.BackColor = System.Drawing.Color.White
        Me.BtnExit.Image = CType(resources.GetObject("BtnExit.Image"), System.Drawing.Image)
        Me.BtnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnExit.Location = New System.Drawing.Point(678, 18)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.BtnExit.Size = New System.Drawing.Size(75, 30)
        Me.BtnExit.TabIndex = 905712
        Me.BtnExit.Text = "Exit"
        Me.BtnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnExit.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.BackColor = System.Drawing.Color.White
        Me.BtnSave.Image = CType(resources.GetObject("BtnSave.Image"), System.Drawing.Image)
        Me.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSave.Location = New System.Drawing.Point(602, 18)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.BtnSave.Size = New System.Drawing.Size(75, 30)
        Me.BtnSave.TabIndex = 905711
        Me.BtnSave.Text = "Save"
        Me.BtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.White
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRefresh.Location = New System.Drawing.Point(526, 18)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btnRefresh.Size = New System.Drawing.Size(75, 30)
        Me.btnRefresh.TabIndex = 905710
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(7, 9)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(349, 13)
        Me.Label15.TabIndex = 1052
        Me.Label15.Text = "Kolom Penanggung Jawab,Inventaris Masuk,Dan Pancang Wajib Di Isi !"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 1044
        Me.Label4.Text = "Pancang"
        '
        'CmbPancang
        '
        Me.CmbPancang.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CmbPancang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.CmbPancang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbPancang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbPancang.FormattingEnabled = True
        Me.CmbPancang.Location = New System.Drawing.Point(63, 27)
        Me.CmbPancang.Name = "CmbPancang"
        Me.CmbPancang.Size = New System.Drawing.Size(245, 21)
        Me.CmbPancang.TabIndex = 1043
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 40)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(763, 467)
        Me.Panel3.TabIndex = 1022
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Panel7)
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 105)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(763, 362)
        Me.Panel5.TabIndex = 1
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.White
        Me.Panel7.Controls.Add(Me.CmbPenanggungJawab)
        Me.Panel7.Controls.Add(Me.CmbKondisiBarang)
        Me.Panel7.Controls.Add(Me.fg2)
        Me.Panel7.Controls.Add(Me.DtpAlokasi)
        Me.Panel7.Controls.Add(Me.CmbInventarisMasuk)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(0, 217)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Padding = New System.Windows.Forms.Padding(10, 0, 10, 10)
        Me.Panel7.Size = New System.Drawing.Size(763, 145)
        Me.Panel7.TabIndex = 1050
        '
        'CmbPenanggungJawab
        '
        Me.CmbPenanggungJawab.FormattingEnabled = True
        Me.CmbPenanggungJawab.Location = New System.Drawing.Point(592, 230)
        Me.CmbPenanggungJawab.Name = "CmbPenanggungJawab"
        Me.CmbPenanggungJawab.Size = New System.Drawing.Size(84, 21)
        Me.CmbPenanggungJawab.TabIndex = 1051
        Me.CmbPenanggungJawab.Visible = False
        '
        'CmbKondisiBarang
        '
        Me.CmbKondisiBarang.FormattingEnabled = True
        Me.CmbKondisiBarang.Location = New System.Drawing.Point(666, 226)
        Me.CmbKondisiBarang.Name = "CmbKondisiBarang"
        Me.CmbKondisiBarang.Size = New System.Drawing.Size(10, 21)
        Me.CmbKondisiBarang.TabIndex = 1052
        Me.CmbKondisiBarang.Visible = False
        '
        'fg2
        '
        Me.fg2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fg2.ColumnInfo = "17,1,0,0,0,110,Columns:5{Style:""TextAlign:GeneralCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "10{Editor:""DtpAlokasi" &
    """;Style:"""";}" & Global.Microsoft.VisualBasic.ChrW(9) & "11{Editor:""CmbInventarisMasuk"";Style:"""";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.fg2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fg2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fg2.ForeColor = System.Drawing.Color.Black
        Me.fg2.Location = New System.Drawing.Point(10, 0)
        Me.fg2.Name = "fg2"
        Me.fg2.Rows.Count = 4
        Me.fg2.Rows.DefaultSize = 22
        Me.fg2.Size = New System.Drawing.Size(743, 135)
        Me.fg2.StyleInfo = resources.GetString("fg2.StyleInfo")
        Me.fg2.TabIndex = 1050
        '
        'DtpAlokasi
        '
        Me.DtpAlokasi.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpAlokasi.Location = New System.Drawing.Point(700, 227)
        Me.DtpAlokasi.Name = "DtpAlokasi"
        Me.DtpAlokasi.Size = New System.Drawing.Size(10, 20)
        Me.DtpAlokasi.TabIndex = 1054
        Me.DtpAlokasi.Visible = False
        '
        'CmbInventarisMasuk
        '
        Me.CmbInventarisMasuk.FormattingEnabled = True
        Me.CmbInventarisMasuk.Location = New System.Drawing.Point(744, 230)
        Me.CmbInventarisMasuk.Name = "CmbInventarisMasuk"
        Me.CmbInventarisMasuk.Size = New System.Drawing.Size(10, 21)
        Me.CmbInventarisMasuk.TabIndex = 1053
        Me.CmbInventarisMasuk.Visible = False
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.White
        Me.Panel6.Controls.Add(Me.fg)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Padding = New System.Windows.Forms.Padding(10, 0, 10, 10)
        Me.Panel6.Size = New System.Drawing.Size(763, 217)
        Me.Panel6.TabIndex = 1050
        '
        'fg
        '
        Me.fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fg.ColumnInfo = "11,1,0,0,0,110,Columns:1{Style:""TextAlign:CenterCenter;"";StyleFixed:""TextAlign:Ce" &
    "nterCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fg.Font = New System.Drawing.Font("Arial", 5.0!, System.Drawing.FontStyle.Bold)
        Me.fg.ForeColor = System.Drawing.Color.Black
        Me.fg.Location = New System.Drawing.Point(10, 0)
        Me.fg.Name = "fg"
        Me.fg.Rows.Count = 4
        Me.fg.Rows.DefaultSize = 22
        Me.fg.Size = New System.Drawing.Size(743, 207)
        Me.fg.StyleInfo = resources.GetString("fg.StyleInfo")
        Me.fg.TabIndex = 1042
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.Panel9)
        Me.Panel4.Controls.Add(Me.CmbSatuan)
        Me.Panel4.Controls.Add(Me.CmbKategori)
        Me.Panel4.Controls.Add(Me.CmbKodeBarang)
        Me.Panel4.Controls.Add(Me.TxtNamaBarang)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.Label13)
        Me.Panel4.Controls.Add(Me.ChkKodeBarang)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Controls.Add(Me.ChkKategoriBarang)
        Me.Panel4.Controls.Add(Me.DtpStart)
        Me.Panel4.Controls.Add(Me.DtpEnd)
        Me.Panel4.Controls.Add(Me.RdBPB)
        Me.Panel4.Controls.Add(Me.RdPCG)
        Me.Panel4.Controls.Add(Me.ChkSatuanBarang)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(763, 105)
        Me.Panel4.TabIndex = 0
        '
        'CmbSatuan
        '
        Me.CmbSatuan.FormattingEnabled = True
        Me.CmbSatuan.Location = New System.Drawing.Point(466, 31)
        Me.CmbSatuan.Name = "CmbSatuan"
        Me.CmbSatuan.Size = New System.Drawing.Size(254, 21)
        Me.CmbSatuan.TabIndex = 1054
        '
        'CmbKategori
        '
        Me.CmbKategori.FormattingEnabled = True
        Me.CmbKategori.Location = New System.Drawing.Point(466, 7)
        Me.CmbKategori.Name = "CmbKategori"
        Me.CmbKategori.Size = New System.Drawing.Size(254, 21)
        Me.CmbKategori.TabIndex = 1054
        '
        'CmbKodeBarang
        '
        Me.CmbKodeBarang.FormattingEnabled = True
        Me.CmbKodeBarang.Location = New System.Drawing.Point(106, 53)
        Me.CmbKodeBarang.Name = "CmbKodeBarang"
        Me.CmbKodeBarang.Size = New System.Drawing.Size(254, 21)
        Me.CmbKodeBarang.TabIndex = 1054
        '
        'TxtNamaBarang
        '
        Me.TxtNamaBarang.Location = New System.Drawing.Point(106, 77)
        Me.TxtNamaBarang.Name = "TxtNamaBarang"
        Me.TxtNamaBarang.Size = New System.Drawing.Size(254, 20)
        Me.TxtNamaBarang.TabIndex = 1053
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.Label3.Location = New System.Drawing.Point(12, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 1034
        Me.Label3.Text = "Barang"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.Label13.Location = New System.Drawing.Point(223, 35)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(20, 13)
        Me.Label13.TabIndex = 1035
        Me.Label13.Text = "s/d"
        '
        'ChkKodeBarang
        '
        Me.ChkKodeBarang.AutoSize = True
        Me.ChkKodeBarang.BackColor = System.Drawing.Color.Transparent
        Me.ChkKodeBarang.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ChkKodeBarang.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.ChkKodeBarang.Location = New System.Drawing.Point(12, 55)
        Me.ChkKodeBarang.Name = "ChkKodeBarang"
        Me.ChkKodeBarang.Size = New System.Drawing.Size(88, 17)
        Me.ChkKodeBarang.TabIndex = 1020
        Me.ChkKodeBarang.Text = "Kode Barang"
        Me.ChkKodeBarang.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.Label6.Location = New System.Drawing.Point(12, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 13)
        Me.Label6.TabIndex = 1036
        Me.Label6.Text = "Cari "
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.Label12.Location = New System.Drawing.Point(12, 35)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 13)
        Me.Label12.TabIndex = 1033
        Me.Label12.Text = "Transaksi Date"
        '
        'ChkKategoriBarang
        '
        Me.ChkKategoriBarang.AutoSize = True
        Me.ChkKategoriBarang.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ChkKategoriBarang.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.ChkKategoriBarang.Location = New System.Drawing.Point(394, 9)
        Me.ChkKategoriBarang.Name = "ChkKategoriBarang"
        Me.ChkKategoriBarang.Size = New System.Drawing.Size(66, 17)
        Me.ChkKategoriBarang.TabIndex = 1021
        Me.ChkKategoriBarang.Text = "Kategori"
        Me.ChkKategoriBarang.UseVisualStyleBackColor = True
        '
        'DtpStart
        '
        Me.DtpStart.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.DtpStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpStart.Location = New System.Drawing.Point(106, 32)
        Me.DtpStart.Name = "DtpStart"
        Me.DtpStart.Size = New System.Drawing.Size(111, 18)
        Me.DtpStart.TabIndex = 1038
        '
        'DtpEnd
        '
        Me.DtpEnd.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.DtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpEnd.Location = New System.Drawing.Point(249, 32)
        Me.DtpEnd.Name = "DtpEnd"
        Me.DtpEnd.Size = New System.Drawing.Size(111, 18)
        Me.DtpEnd.TabIndex = 1037
        '
        'RdBPB
        '
        Me.RdBPB.AutoSize = True
        Me.RdBPB.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.RdBPB.Location = New System.Drawing.Point(159, 9)
        Me.RdBPB.Name = "RdBPB"
        Me.RdBPB.Size = New System.Drawing.Size(46, 17)
        Me.RdBPB.TabIndex = 1039
        Me.RdBPB.TabStop = True
        Me.RdBPB.Text = "BPB"
        Me.RdBPB.UseVisualStyleBackColor = True
        '
        'RdPCG
        '
        Me.RdPCG.AutoSize = True
        Me.RdPCG.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.RdPCG.Location = New System.Drawing.Point(106, 9)
        Me.RdPCG.Name = "RdPCG"
        Me.RdPCG.Size = New System.Drawing.Size(47, 17)
        Me.RdPCG.TabIndex = 1040
        Me.RdPCG.TabStop = True
        Me.RdPCG.Text = "PCG"
        Me.RdPCG.UseVisualStyleBackColor = True
        '
        'ChkSatuanBarang
        '
        Me.ChkSatuanBarang.AutoSize = True
        Me.ChkSatuanBarang.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ChkSatuanBarang.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.ChkSatuanBarang.Location = New System.Drawing.Point(394, 33)
        Me.ChkSatuanBarang.Name = "ChkSatuanBarang"
        Me.ChkSatuanBarang.Size = New System.Drawing.Size(60, 17)
        Me.ChkSatuanBarang.TabIndex = 1022
        Me.ChkSatuanBarang.Text = "Satuan"
        Me.ChkSatuanBarang.UseVisualStyleBackColor = True
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.Black
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(763, 1)
        Me.Panel9.TabIndex = 905704
        '
        'FrmTrnBarangMasuk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(763, 563)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmTrnBarangMasuk"
        Me.Text = "Transaksi Barang Masuk"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.fg2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label15 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents CmbPancang As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents CmbPenanggungJawab As ComboBox
    Friend WithEvents CmbKondisiBarang As ComboBox
    Friend WithEvents fg2 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents DtpAlokasi As DateTimePicker
    Friend WithEvents CmbInventarisMasuk As ComboBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel4 As Panel
    Friend WithEvents CmbSatuan As ComboBox
    Friend WithEvents CmbKategori As ComboBox
    Friend WithEvents CmbKodeBarang As ComboBox
    Friend WithEvents TxtNamaBarang As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents ChkKodeBarang As CheckBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents ChkKategoriBarang As CheckBox
    Friend WithEvents DtpStart As DateTimePicker
    Friend WithEvents DtpEnd As DateTimePicker
    Friend WithEvents RdBPB As RadioButton
    Friend WithEvents RdPCG As RadioButton
    Friend WithEvents ChkSatuanBarang As CheckBox
    Friend WithEvents btnRefresh As Button
    Friend WithEvents BtnExit As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents Panel9 As Panel
End Class
