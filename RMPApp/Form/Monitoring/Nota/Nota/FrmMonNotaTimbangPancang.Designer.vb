Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMonNotaTimbangPancang
    Inherits DockContent

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMonNotaTimbangPancang))
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtTujuanManual = New System.Windows.Forms.TextBox()
        Me.rdPSG = New System.Windows.Forms.RadioButton()
        Me.rdManual = New System.Windows.Forms.RadioButton()
        Me.rdRSUP = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnSaveGroup = New System.Windows.Forms.Button()
        Me.btnEditGroup = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTotalDiblok = New System.Windows.Forms.TextBox()
        Me.btnMonKapal = New System.Windows.Forms.Button()
        Me.btnPrintAll = New System.Windows.Forms.Button()
        Me.btnInputTglMasukKapal = New System.Windows.Forms.Button()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbKapal = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtNoNota = New System.Windows.Forms.TextBox()
        Me.dtpTglNota2 = New System.Windows.Forms.DateTimePicker()
        Me.dtpTglNota1 = New System.Windows.Forms.DateTimePicker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnFindRelasi = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnFindPetani = New System.Windows.Forms.Button()
        Me.chkTujuan = New System.Windows.Forms.CheckBox()
        Me.txtNamaSupRelasi = New System.Windows.Forms.TextBox()
        Me.chkTglPenjualan = New System.Windows.Forms.CheckBox()
        Me.txtNamaSupPetani = New System.Windows.Forms.TextBox()
        Me.chkTglNota = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtKodeSupRelasi = New System.Windows.Forms.TextBox()
        Me.txtTrip = New System.Windows.Forms.TextBox()
        Me.txtKodeSupPetani = New System.Windows.Forms.TextBox()
        Me.cmbPancang = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbJenisKB = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpTglJual2 = New System.Windows.Forms.DateTimePicker()
        Me.dtpTglJual1 = New System.Windows.Forms.DateTimePicker()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.BackgroundImage = CType(resources.GetObject("Panel4.BackgroundImage"), System.Drawing.Image)
        Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel4.Location = New System.Drawing.Point(5, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(35, 35)
        Me.Panel4.TabIndex = 7
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.txtTujuanManual)
        Me.Panel3.Controls.Add(Me.rdPSG)
        Me.Panel3.Controls.Add(Me.rdManual)
        Me.Panel3.Controls.Add(Me.rdRSUP)
        Me.Panel3.Location = New System.Drawing.Point(143, 82)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(250, 25)
        Me.Panel3.TabIndex = 110
        '
        'txtTujuanManual
        '
        Me.txtTujuanManual.Location = New System.Drawing.Point(147, 1)
        Me.txtTujuanManual.Name = "txtTujuanManual"
        Me.txtTujuanManual.Size = New System.Drawing.Size(103, 22)
        Me.txtTujuanManual.TabIndex = 127
        '
        'rdPSG
        '
        Me.rdPSG.AutoSize = True
        Me.rdPSG.Checked = True
        Me.rdPSG.Location = New System.Drawing.Point(4, 4)
        Me.rdPSG.Name = "rdPSG"
        Me.rdPSG.Size = New System.Drawing.Size(45, 17)
        Me.rdPSG.TabIndex = 2
        Me.rdPSG.TabStop = True
        Me.rdPSG.Text = "PSG"
        Me.rdPSG.UseVisualStyleBackColor = True
        '
        'rdManual
        '
        Me.rdManual.AutoSize = True
        Me.rdManual.Location = New System.Drawing.Point(113, 4)
        Me.rdManual.Name = "rdManual"
        Me.rdManual.Size = New System.Drawing.Size(28, 17)
        Me.rdManual.TabIndex = 1
        Me.rdManual.Text = ":"
        Me.rdManual.UseVisualStyleBackColor = True
        '
        'rdRSUP
        '
        Me.rdRSUP.AutoSize = True
        Me.rdRSUP.Location = New System.Drawing.Point(55, 4)
        Me.rdRSUP.Name = "rdRSUP"
        Me.rdRSUP.Size = New System.Drawing.Size(52, 17)
        Me.rdRSUP.TabIndex = 0
        Me.rdRSUP.Text = "RSUP"
        Me.rdRSUP.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(43, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(347, 28)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Monitoring Nota Timbang Pancang"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnSaveGroup)
        Me.Panel2.Controls.Add(Me.btnEditGroup)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtTotalDiblok)
        Me.Panel2.Controls.Add(Me.btnMonKapal)
        Me.Panel2.Controls.Add(Me.btnPrintAll)
        Me.Panel2.Controls.Add(Me.btnInputTglMasukKapal)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 518)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(5, 0, 5, 5)
        Me.Panel2.Size = New System.Drawing.Size(1198, 40)
        Me.Panel2.TabIndex = 5
        '
        'btnSaveGroup
        '
        Me.btnSaveGroup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveGroup.BackColor = System.Drawing.Color.White
        Me.btnSaveGroup.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveGroup.Image = CType(resources.GetObject("btnSaveGroup.Image"), System.Drawing.Image)
        Me.btnSaveGroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveGroup.Location = New System.Drawing.Point(894, 5)
        Me.btnSaveGroup.Name = "btnSaveGroup"
        Me.btnSaveGroup.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btnSaveGroup.Size = New System.Drawing.Size(100, 30)
        Me.btnSaveGroup.TabIndex = 134
        Me.btnSaveGroup.Text = "Save Group"
        Me.btnSaveGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSaveGroup.UseVisualStyleBackColor = False
        '
        'btnEditGroup
        '
        Me.btnEditGroup.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditGroup.BackColor = System.Drawing.Color.White
        Me.btnEditGroup.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditGroup.Image = CType(resources.GetObject("btnEditGroup.Image"), System.Drawing.Image)
        Me.btnEditGroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEditGroup.Location = New System.Drawing.Point(793, 5)
        Me.btnEditGroup.Name = "btnEditGroup"
        Me.btnEditGroup.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btnEditGroup.Size = New System.Drawing.Size(100, 30)
        Me.btnEditGroup.TabIndex = 133
        Me.btnEditGroup.Text = "Edit Group"
        Me.btnEditGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEditGroup.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(999, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 129
        Me.Label2.Text = "Total Diblok"
        '
        'txtTotalDiblok
        '
        Me.txtTotalDiblok.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalDiblok.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDiblok.Location = New System.Drawing.Point(1074, 9)
        Me.txtTotalDiblok.Name = "txtTotalDiblok"
        Me.txtTotalDiblok.Size = New System.Drawing.Size(113, 22)
        Me.txtTotalDiblok.TabIndex = 132
        Me.txtTotalDiblok.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnMonKapal
        '
        Me.btnMonKapal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnMonKapal.BackColor = System.Drawing.Color.White
        Me.btnMonKapal.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMonKapal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMonKapal.Location = New System.Drawing.Point(188, 5)
        Me.btnMonKapal.Name = "btnMonKapal"
        Me.btnMonKapal.Size = New System.Drawing.Size(123, 30)
        Me.btnMonKapal.TabIndex = 131
        Me.btnMonKapal.Text = "Monitoring Kapal"
        Me.btnMonKapal.UseVisualStyleBackColor = False
        '
        'btnPrintAll
        '
        Me.btnPrintAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrintAll.BackColor = System.Drawing.Color.White
        Me.btnPrintAll.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintAll.Image = CType(resources.GetObject("btnPrintAll.Image"), System.Drawing.Image)
        Me.btnPrintAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrintAll.Location = New System.Drawing.Point(312, 5)
        Me.btnPrintAll.Name = "btnPrintAll"
        Me.btnPrintAll.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btnPrintAll.Size = New System.Drawing.Size(109, 30)
        Me.btnPrintAll.TabIndex = 130
        Me.btnPrintAll.Text = "Print All Nota"
        Me.btnPrintAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrintAll.UseVisualStyleBackColor = False
        '
        'btnInputTglMasukKapal
        '
        Me.btnInputTglMasukKapal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnInputTglMasukKapal.BackColor = System.Drawing.Color.White
        Me.btnInputTglMasukKapal.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInputTglMasukKapal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnInputTglMasukKapal.Location = New System.Drawing.Point(10, 5)
        Me.btnInputTglMasukKapal.Name = "btnInputTglMasukKapal"
        Me.btnInputTglMasukKapal.Size = New System.Drawing.Size(177, 30)
        Me.btnInputTglMasukKapal.TabIndex = 128
        Me.btnInputTglMasukKapal.Text = "Input Tanggal Masuk Kapal"
        Me.btnInputTglMasukKapal.UseVisualStyleBackColor = False
        '
        'btnExcel
        '
        Me.btnExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExcel.BackColor = System.Drawing.Color.White
        Me.btnExcel.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(1037, 75)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btnExcel.Size = New System.Drawing.Size(75, 30)
        Me.btnExcel.TabIndex = 108
        Me.btnExcel.Text = "Excel"
        Me.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcel.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.White
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(1112, 75)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnClose.Size = New System.Drawing.Size(75, 30)
        Me.btnClose.TabIndex = 106
        Me.btnClose.Text = "Close"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.White
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRefresh.Location = New System.Drawing.Point(962, 75)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btnRefresh.Size = New System.Drawing.Size(75, 30)
        Me.btnRefresh.TabIndex = 105
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(258, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 13)
        Me.Label4.TabIndex = 104
        Me.Label4.Text = "s/d"
        '
        'cmbKapal
        '
        Me.cmbKapal.FormattingEnabled = True
        Me.cmbKapal.Location = New System.Drawing.Point(490, 34)
        Me.cmbKapal.Name = "cmbKapal"
        Me.cmbKapal.Size = New System.Drawing.Size(246, 21)
        Me.cmbKapal.TabIndex = 101
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(421, 38)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(35, 13)
        Me.Label25.TabIndex = 77
        Me.Label25.Text = "Kapal"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(12, 14)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(50, 13)
        Me.Label17.TabIndex = 76
        Me.Label17.Text = "No Nota"
        '
        'txtNoNota
        '
        Me.txtNoNota.Location = New System.Drawing.Point(146, 9)
        Me.txtNoNota.Name = "txtNoNota"
        Me.txtNoNota.Size = New System.Drawing.Size(246, 22)
        Me.txtNoNota.TabIndex = 82
        '
        'dtpTglNota2
        '
        Me.dtpTglNota2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTglNota2.Location = New System.Drawing.Point(287, 33)
        Me.dtpTglNota2.Name = "dtpTglNota2"
        Me.dtpTglNota2.Size = New System.Drawing.Size(105, 22)
        Me.dtpTglNota2.TabIndex = 84
        '
        'dtpTglNota1
        '
        Me.dtpTglNota1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTglNota1.Location = New System.Drawing.Point(146, 33)
        Me.dtpTglNota1.Name = "dtpTglNota1"
        Me.dtpTglNota1.Size = New System.Drawing.Size(105, 22)
        Me.dtpTglNota1.TabIndex = 83
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnFindRelasi)
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Controls.Add(Me.btnFindPetani)
        Me.Panel1.Controls.Add(Me.chkTujuan)
        Me.Panel1.Controls.Add(Me.txtNamaSupRelasi)
        Me.Panel1.Controls.Add(Me.chkTglPenjualan)
        Me.Panel1.Controls.Add(Me.txtNamaSupPetani)
        Me.Panel1.Controls.Add(Me.chkTglNota)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.txtKodeSupRelasi)
        Me.Panel1.Controls.Add(Me.txtTrip)
        Me.Panel1.Controls.Add(Me.txtKodeSupPetani)
        Me.Panel1.Controls.Add(Me.cmbPancang)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.cmbJenisKB)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.dtpTglJual2)
        Me.Panel1.Controls.Add(Me.dtpTglJual1)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.btnExcel)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.btnRefresh)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.cmbKapal)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.txtNoNota)
        Me.Panel1.Controls.Add(Me.dtpTglNota2)
        Me.Panel1.Controls.Add(Me.dtpTglNota1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 40)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1198, 114)
        Me.Panel1.TabIndex = 6
        '
        'btnFindRelasi
        '
        Me.btnFindRelasi.BackColor = System.Drawing.Color.White
        Me.btnFindRelasi.Image = CType(resources.GetObject("btnFindRelasi.Image"), System.Drawing.Image)
        Me.btnFindRelasi.Location = New System.Drawing.Point(1148, 8)
        Me.btnFindRelasi.Name = "btnFindRelasi"
        Me.btnFindRelasi.Size = New System.Drawing.Size(25, 25)
        Me.btnFindRelasi.TabIndex = 21
        Me.btnFindRelasi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFindRelasi.UseVisualStyleBackColor = False
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Black
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1198, 1)
        Me.Panel6.TabIndex = 128
        '
        'btnFindPetani
        '
        Me.btnFindPetani.BackColor = System.Drawing.Color.White
        Me.btnFindPetani.Image = CType(resources.GetObject("btnFindPetani.Image"), System.Drawing.Image)
        Me.btnFindPetani.Location = New System.Drawing.Point(1148, 32)
        Me.btnFindPetani.Name = "btnFindPetani"
        Me.btnFindPetani.Size = New System.Drawing.Size(25, 25)
        Me.btnFindPetani.TabIndex = 20
        Me.btnFindPetani.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFindPetani.UseVisualStyleBackColor = False
        '
        'chkTujuan
        '
        Me.chkTujuan.AutoSize = True
        Me.chkTujuan.Location = New System.Drawing.Point(12, 86)
        Me.chkTujuan.Name = "chkTujuan"
        Me.chkTujuan.Size = New System.Drawing.Size(61, 17)
        Me.chkTujuan.TabIndex = 127
        Me.chkTujuan.Text = "Tujuan"
        Me.chkTujuan.UseVisualStyleBackColor = True
        '
        'txtNamaSupRelasi
        '
        Me.txtNamaSupRelasi.Location = New System.Drawing.Point(963, 9)
        Me.txtNamaSupRelasi.Name = "txtNamaSupRelasi"
        Me.txtNamaSupRelasi.Size = New System.Drawing.Size(184, 22)
        Me.txtNamaSupRelasi.TabIndex = 18
        '
        'chkTglPenjualan
        '
        Me.chkTglPenjualan.AutoSize = True
        Me.chkTglPenjualan.Location = New System.Drawing.Point(12, 62)
        Me.chkTglPenjualan.Name = "chkTglPenjualan"
        Me.chkTglPenjualan.Size = New System.Drawing.Size(120, 17)
        Me.chkTglPenjualan.TabIndex = 126
        Me.chkTglPenjualan.Text = "Tanggal Penjualan"
        Me.chkTglPenjualan.UseVisualStyleBackColor = True
        '
        'txtNamaSupPetani
        '
        Me.txtNamaSupPetani.Location = New System.Drawing.Point(963, 33)
        Me.txtNamaSupPetani.Name = "txtNamaSupPetani"
        Me.txtNamaSupPetani.Size = New System.Drawing.Size(184, 22)
        Me.txtNamaSupPetani.TabIndex = 19
        '
        'chkTglNota
        '
        Me.chkTglNota.AutoSize = True
        Me.chkTglNota.Checked = True
        Me.chkTglNota.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTglNota.Location = New System.Drawing.Point(12, 36)
        Me.chkTglNota.Name = "chkTglNota"
        Me.chkTglNota.Size = New System.Drawing.Size(94, 17)
        Me.chkTglNota.TabIndex = 125
        Me.chkTglNota.Text = "Tanggal Nota"
        Me.chkTglNota.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(765, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Sub Petani"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(765, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Relasi / Penerima Uang"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(421, 64)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(25, 13)
        Me.Label11.TabIndex = 123
        Me.Label11.Text = "Trip"
        '
        'txtKodeSupRelasi
        '
        Me.txtKodeSupRelasi.Location = New System.Drawing.Point(894, 9)
        Me.txtKodeSupRelasi.Name = "txtKodeSupRelasi"
        Me.txtKodeSupRelasi.Size = New System.Drawing.Size(67, 22)
        Me.txtKodeSupRelasi.TabIndex = 16
        '
        'txtTrip
        '
        Me.txtTrip.Location = New System.Drawing.Point(490, 59)
        Me.txtTrip.Name = "txtTrip"
        Me.txtTrip.Size = New System.Drawing.Size(123, 22)
        Me.txtTrip.TabIndex = 124
        '
        'txtKodeSupPetani
        '
        Me.txtKodeSupPetani.Location = New System.Drawing.Point(894, 33)
        Me.txtKodeSupPetani.Name = "txtKodeSupPetani"
        Me.txtKodeSupPetani.Size = New System.Drawing.Size(67, 22)
        Me.txtKodeSupPetani.TabIndex = 17
        '
        'cmbPancang
        '
        Me.cmbPancang.FormattingEnabled = True
        Me.cmbPancang.Location = New System.Drawing.Point(490, 10)
        Me.cmbPancang.Name = "cmbPancang"
        Me.cmbPancang.Size = New System.Drawing.Size(246, 21)
        Me.cmbPancang.TabIndex = 122
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(421, 14)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 13)
        Me.Label10.TabIndex = 121
        Me.Label10.Text = "Pancang"
        '
        'cmbJenisKB
        '
        Me.cmbJenisKB.FormattingEnabled = True
        Me.cmbJenisKB.Location = New System.Drawing.Point(490, 84)
        Me.cmbJenisKB.Name = "cmbJenisKB"
        Me.cmbJenisKB.Size = New System.Drawing.Size(246, 21)
        Me.cmbJenisKB.TabIndex = 120
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(421, 88)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 13)
        Me.Label9.TabIndex = 119
        Me.Label9.Text = "Jenis KB"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(258, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(23, 13)
        Me.Label6.TabIndex = 113
        Me.Label6.Text = "s/d"
        '
        'dtpTglJual2
        '
        Me.dtpTglJual2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTglJual2.Location = New System.Drawing.Point(287, 59)
        Me.dtpTglJual2.Name = "dtpTglJual2"
        Me.dtpTglJual2.Size = New System.Drawing.Size(105, 22)
        Me.dtpTglJual2.TabIndex = 112
        '
        'dtpTglJual1
        '
        Me.dtpTglJual1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTglJual1.Location = New System.Drawing.Point(146, 59)
        Me.dtpTglJual1.Name = "dtpTglJual1"
        Me.dtpTglJual1.Size = New System.Drawing.Size(105, 22)
        Me.dtpTglJual1.TabIndex = 111
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.fg)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 154)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(10, 0, 10, 10)
        Me.Panel5.Size = New System.Drawing.Size(1198, 364)
        Me.Panel5.TabIndex = 9
        '
        'fg
        '
        Me.fg.ColumnInfo = resources.GetString("fg.ColumnInfo")
        Me.fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fg.Location = New System.Drawing.Point(10, 0)
        Me.fg.Name = "fg"
        Me.fg.Rows.Count = 1
        Me.fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.CellRange
        Me.fg.Size = New System.Drawing.Size(1178, 354)
        Me.fg.TabIndex = 0
        '
        'FrmMonNotaTimbangPancang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1198, 558)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FrmMonNotaTimbangPancang"
        Me.Padding = New System.Windows.Forms.Padding(0, 40, 0, 0)
        Me.Text = "Monitoring Nota Timbang Pancang"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents rdPSG As RadioButton
    Friend WithEvents rdManual As RadioButton
    Friend WithEvents rdRSUP As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnExcel As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbKapal As ComboBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents txtNoNota As TextBox
    Friend WithEvents dtpTglNota2 As DateTimePicker
    Friend WithEvents dtpTglNota1 As DateTimePicker
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label6 As Label
    Friend WithEvents dtpTglJual2 As DateTimePicker
    Friend WithEvents dtpTglJual1 As DateTimePicker
    Friend WithEvents cmbJenisKB As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cmbPancang As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtTrip As TextBox
    Friend WithEvents chkTglPenjualan As CheckBox
    Friend WithEvents chkTglNota As CheckBox
    Friend WithEvents txtTujuanManual As TextBox
    Friend WithEvents chkTujuan As CheckBox
    Friend WithEvents btnPrintAll As Button
    Friend WithEvents btnInputTglMasukKapal As Button
    Friend WithEvents btnMonKapal As Button
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents txtTotalDiblok As TextBox
    Friend WithEvents btnFindRelasi As Button
    Friend WithEvents btnFindPetani As Button
    Friend WithEvents txtNamaSupRelasi As TextBox
    Friend WithEvents txtNamaSupPetani As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtKodeSupRelasi As TextBox
    Friend WithEvents txtKodeSupPetani As TextBox
    Friend WithEvents btnSaveGroup As Button
    Friend WithEvents btnEditGroup As Button
End Class
