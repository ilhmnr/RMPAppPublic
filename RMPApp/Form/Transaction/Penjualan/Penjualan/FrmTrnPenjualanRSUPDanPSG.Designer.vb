Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTrnPenjualanRSUPDanPSG
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTrnPenjualanRSUPDanPSG))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.chkPPH22 = New System.Windows.Forms.CheckBox()
        Me.rdKapalTenggelam = New System.Windows.Forms.CheckBox()
        Me.rdHabis = New System.Windows.Forms.RadioButton()
        Me.rdBersambung = New System.Windows.Forms.RadioButton()
        Me.chkA6 = New System.Windows.Forms.CheckBox()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.rdCustomer = New System.Windows.Forms.RadioButton()
        Me.rdPSG = New System.Windows.Forms.RadioButton()
        Me.rdRSUP = New System.Windows.Forms.RadioButton()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.rdJambul = New System.Windows.Forms.RadioButton()
        Me.rdGelondong = New System.Windows.Forms.RadioButton()
        Me.rdCungkil = New System.Windows.Forms.RadioButton()
        Me.rdLicin = New System.Windows.Forms.RadioButton()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.rdKBA = New System.Windows.Forms.RadioButton()
        Me.rdGD = New System.Windows.Forms.RadioButton()
        Me.rdKC = New System.Windows.Forms.RadioButton()
        Me.rdKBB = New System.Windows.Forms.RadioButton()
        Me.dtpTanggalNota2 = New System.Windows.Forms.DateTimePicker()
        Me.dtpTanggalNota1 = New System.Windows.Forms.DateTimePicker()
        Me.dtpTanggalPenjualan = New System.Windows.Forms.DateTimePicker()
        Me.txtNoTrans = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtTrip = New System.Windows.Forms.TextBox()
        Me.cboKapal = New System.Windows.Forms.ComboBox()
        Me.cboPancang = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnProposional = New System.Windows.Forms.Button()
        Me.btnFindKapal = New System.Windows.Forms.Button()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtGDPersen = New System.Windows.Forms.Label()
        Me.txtKCPersen = New System.Windows.Forms.Label()
        Me.txtTotAllPbk = New System.Windows.Forms.Label()
        Me.txtTotPbk = New System.Windows.Forms.Label()
        Me.txtTotPcg = New System.Windows.Forms.Label()
        Me.txtGDAllPbk = New System.Windows.Forms.Label()
        Me.txtKCAllPbk = New System.Windows.Forms.Label()
        Me.txtGDPbk = New System.Windows.Forms.Label()
        Me.txtKCPbk = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtGDPcg = New System.Windows.Forms.Label()
        Me.txtKCPcg = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtKBBPersen = New System.Windows.Forms.Label()
        Me.txtKBBAllPbk = New System.Windows.Forms.Label()
        Me.txtKBBPbk = New System.Windows.Forms.Label()
        Me.txtKBBPcg = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtKBAPersen = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtKBAAllPbk = New System.Windows.Forms.Label()
        Me.txtKBAPbk = New System.Windows.Forms.Label()
        Me.txtKBAPcg = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtBertambah = New System.Windows.Forms.TextBox()
        Me.txtSusut = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.fgPenjualan = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.fgStok = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.fgPancang = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.PanelGroupPabrik = New System.Windows.Forms.Panel()
        Me.PanelAllPabrik = New System.Windows.Forms.Panel()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.fgAllPabrik = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.PanelPabrik = New System.Windows.Forms.Panel()
        Me.grpNotaPabrik = New System.Windows.Forms.GroupBox()
        Me.fgPabrik = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.grpFakturPembelian = New System.Windows.Forms.GroupBox()
        Me.fgFakturPabrik = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel16.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.fgPenjualan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.fgStok, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel12.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.fgPancang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.PanelGroupPabrik.SuspendLayout()
        Me.PanelAllPabrik.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.fgAllPabrik, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelPabrik.SuspendLayout()
        Me.grpNotaPabrik.SuspendLayout()
        CType(Me.fgPabrik, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFakturPembelian.SuspendLayout()
        CType(Me.fgFakturPabrik, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Panel8)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1412, 40)
        Me.Panel1.TabIndex = 0
        '
        'Panel8
        '
        Me.Panel8.BackgroundImage = CType(resources.GetObject("Panel8.BackgroundImage"), System.Drawing.Image)
        Me.Panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel8.Location = New System.Drawing.Point(10, 3)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(35, 35)
        Me.Panel8.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(48, 6)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(340, 28)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "Transaksi Penjualan RSUP Dan PSG"
        '
        'chkPPH22
        '
        Me.chkPPH22.AutoSize = True
        Me.chkPPH22.Checked = True
        Me.chkPPH22.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPPH22.Location = New System.Drawing.Point(1226, 36)
        Me.chkPPH22.Name = "chkPPH22"
        Me.chkPPH22.Size = New System.Drawing.Size(61, 17)
        Me.chkPPH22.TabIndex = 905660
        Me.chkPPH22.Text = "PPH 22"
        Me.chkPPH22.UseVisualStyleBackColor = True
        '
        'rdKapalTenggelam
        '
        Me.rdKapalTenggelam.AutoSize = True
        Me.rdKapalTenggelam.Location = New System.Drawing.Point(1123, 11)
        Me.rdKapalTenggelam.Name = "rdKapalTenggelam"
        Me.rdKapalTenggelam.Size = New System.Drawing.Size(112, 17)
        Me.rdKapalTenggelam.TabIndex = 905659
        Me.rdKapalTenggelam.Text = "Kapal Tenggelam"
        Me.rdKapalTenggelam.UseVisualStyleBackColor = True
        '
        'rdHabis
        '
        Me.rdHabis.AutoSize = True
        Me.rdHabis.Location = New System.Drawing.Point(1168, 36)
        Me.rdHabis.Name = "rdHabis"
        Me.rdHabis.Size = New System.Drawing.Size(54, 17)
        Me.rdHabis.TabIndex = 905658
        Me.rdHabis.TabStop = True
        Me.rdHabis.Text = "Habis"
        Me.rdHabis.UseVisualStyleBackColor = True
        '
        'rdBersambung
        '
        Me.rdBersambung.AutoSize = True
        Me.rdBersambung.Location = New System.Drawing.Point(1078, 36)
        Me.rdBersambung.Name = "rdBersambung"
        Me.rdBersambung.Size = New System.Drawing.Size(90, 17)
        Me.rdBersambung.TabIndex = 905658
        Me.rdBersambung.TabStop = True
        Me.rdBersambung.Text = "Bersambung"
        Me.rdBersambung.UseVisualStyleBackColor = True
        '
        'chkA6
        '
        Me.chkA6.AutoSize = True
        Me.chkA6.Enabled = False
        Me.chkA6.Location = New System.Drawing.Point(1078, 11)
        Me.chkA6.Name = "chkA6"
        Me.chkA6.Size = New System.Drawing.Size(39, 17)
        Me.chkA6.TabIndex = 120
        Me.chkA6.Text = "A6"
        Me.chkA6.UseVisualStyleBackColor = True
        '
        'Panel15
        '
        Me.Panel15.Controls.Add(Me.rdCustomer)
        Me.Panel15.Controls.Add(Me.rdPSG)
        Me.Panel15.Controls.Add(Me.rdRSUP)
        Me.Panel15.Location = New System.Drawing.Point(791, 9)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(189, 21)
        Me.Panel15.TabIndex = 119
        '
        'rdCustomer
        '
        Me.rdCustomer.AutoSize = True
        Me.rdCustomer.Enabled = False
        Me.rdCustomer.Location = New System.Drawing.Point(117, 2)
        Me.rdCustomer.Name = "rdCustomer"
        Me.rdCustomer.Size = New System.Drawing.Size(74, 17)
        Me.rdCustomer.TabIndex = 119
        Me.rdCustomer.Text = "Customer"
        Me.rdCustomer.UseVisualStyleBackColor = True
        '
        'rdPSG
        '
        Me.rdPSG.AutoSize = True
        Me.rdPSG.Checked = True
        Me.rdPSG.Enabled = False
        Me.rdPSG.Location = New System.Drawing.Point(3, 2)
        Me.rdPSG.Name = "rdPSG"
        Me.rdPSG.Size = New System.Drawing.Size(45, 17)
        Me.rdPSG.TabIndex = 118
        Me.rdPSG.TabStop = True
        Me.rdPSG.Text = "PSG"
        Me.rdPSG.UseVisualStyleBackColor = True
        '
        'rdRSUP
        '
        Me.rdRSUP.AutoSize = True
        Me.rdRSUP.Enabled = False
        Me.rdRSUP.Location = New System.Drawing.Point(56, 2)
        Me.rdRSUP.Name = "rdRSUP"
        Me.rdRSUP.Size = New System.Drawing.Size(52, 17)
        Me.rdRSUP.TabIndex = 118
        Me.rdRSUP.Text = "RSUP"
        Me.rdRSUP.UseVisualStyleBackColor = True
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.rdJambul)
        Me.Panel11.Controls.Add(Me.rdGelondong)
        Me.Panel11.Controls.Add(Me.rdCungkil)
        Me.Panel11.Controls.Add(Me.rdLicin)
        Me.Panel11.Location = New System.Drawing.Point(791, 34)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(269, 21)
        Me.Panel11.TabIndex = 119
        '
        'rdJambul
        '
        Me.rdJambul.AutoSize = True
        Me.rdJambul.Checked = True
        Me.rdJambul.Enabled = False
        Me.rdJambul.Location = New System.Drawing.Point(3, 2)
        Me.rdJambul.Name = "rdJambul"
        Me.rdJambul.Size = New System.Drawing.Size(61, 17)
        Me.rdJambul.TabIndex = 118
        Me.rdJambul.TabStop = True
        Me.rdJambul.Text = "Jambul"
        Me.rdJambul.UseVisualStyleBackColor = True
        '
        'rdGelondong
        '
        Me.rdGelondong.AutoSize = True
        Me.rdGelondong.Enabled = False
        Me.rdGelondong.Location = New System.Drawing.Point(186, 2)
        Me.rdGelondong.Name = "rdGelondong"
        Me.rdGelondong.Size = New System.Drawing.Size(84, 17)
        Me.rdGelondong.TabIndex = 118
        Me.rdGelondong.Text = "Gelondong"
        Me.rdGelondong.UseVisualStyleBackColor = True
        '
        'rdCungkil
        '
        Me.rdCungkil.AutoSize = True
        Me.rdCungkil.Enabled = False
        Me.rdCungkil.Location = New System.Drawing.Point(120, 2)
        Me.rdCungkil.Name = "rdCungkil"
        Me.rdCungkil.Size = New System.Drawing.Size(65, 17)
        Me.rdCungkil.TabIndex = 118
        Me.rdCungkil.Text = "Cungkil"
        Me.rdCungkil.UseVisualStyleBackColor = True
        '
        'rdLicin
        '
        Me.rdLicin.AutoSize = True
        Me.rdLicin.Enabled = False
        Me.rdLicin.Location = New System.Drawing.Point(67, 2)
        Me.rdLicin.Name = "rdLicin"
        Me.rdLicin.Size = New System.Drawing.Size(48, 17)
        Me.rdLicin.TabIndex = 118
        Me.rdLicin.Text = "Licin"
        Me.rdLicin.UseVisualStyleBackColor = True
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.rdKBA)
        Me.Panel10.Controls.Add(Me.rdGD)
        Me.Panel10.Controls.Add(Me.rdKC)
        Me.Panel10.Controls.Add(Me.rdKBB)
        Me.Panel10.Location = New System.Drawing.Point(791, 59)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(269, 21)
        Me.Panel10.TabIndex = 119
        '
        'rdKBA
        '
        Me.rdKBA.AutoSize = True
        Me.rdKBA.Checked = True
        Me.rdKBA.Enabled = False
        Me.rdKBA.Location = New System.Drawing.Point(3, 2)
        Me.rdKBA.Name = "rdKBA"
        Me.rdKBA.Size = New System.Drawing.Size(49, 17)
        Me.rdKBA.TabIndex = 118
        Me.rdKBA.TabStop = True
        Me.rdKBA.Text = "KB-A"
        Me.rdKBA.UseVisualStyleBackColor = True
        '
        'rdGD
        '
        Me.rdGD.AutoSize = True
        Me.rdGD.Enabled = False
        Me.rdGD.Location = New System.Drawing.Point(158, 2)
        Me.rdGD.Name = "rdGD"
        Me.rdGD.Size = New System.Drawing.Size(41, 17)
        Me.rdGD.TabIndex = 118
        Me.rdGD.Text = "GD"
        Me.rdGD.UseVisualStyleBackColor = True
        '
        'rdKC
        '
        Me.rdKC.AutoSize = True
        Me.rdKC.Enabled = False
        Me.rdKC.Location = New System.Drawing.Point(113, 2)
        Me.rdKC.Name = "rdKC"
        Me.rdKC.Size = New System.Drawing.Size(38, 17)
        Me.rdKC.TabIndex = 118
        Me.rdKC.Text = "KC"
        Me.rdKC.UseVisualStyleBackColor = True
        '
        'rdKBB
        '
        Me.rdKBB.AutoSize = True
        Me.rdKBB.Enabled = False
        Me.rdKBB.Location = New System.Drawing.Point(58, 2)
        Me.rdKBB.Name = "rdKBB"
        Me.rdKBB.Size = New System.Drawing.Size(49, 17)
        Me.rdKBB.TabIndex = 118
        Me.rdKBB.Text = "KB-B"
        Me.rdKBB.UseVisualStyleBackColor = True
        '
        'dtpTanggalNota2
        '
        Me.dtpTanggalNota2.Enabled = False
        Me.dtpTanggalNota2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTanggalNota2.Location = New System.Drawing.Point(242, 58)
        Me.dtpTanggalNota2.Name = "dtpTanggalNota2"
        Me.dtpTanggalNota2.Size = New System.Drawing.Size(98, 22)
        Me.dtpTanggalNota2.TabIndex = 115
        '
        'dtpTanggalNota1
        '
        Me.dtpTanggalNota1.Enabled = False
        Me.dtpTanggalNota1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTanggalNota1.Location = New System.Drawing.Point(113, 58)
        Me.dtpTanggalNota1.Name = "dtpTanggalNota1"
        Me.dtpTanggalNota1.Size = New System.Drawing.Size(98, 22)
        Me.dtpTanggalNota1.TabIndex = 116
        '
        'dtpTanggalPenjualan
        '
        Me.dtpTanggalPenjualan.Enabled = False
        Me.dtpTanggalPenjualan.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTanggalPenjualan.Location = New System.Drawing.Point(113, 33)
        Me.dtpTanggalPenjualan.Name = "dtpTanggalPenjualan"
        Me.dtpTanggalPenjualan.Size = New System.Drawing.Size(227, 22)
        Me.dtpTanggalPenjualan.TabIndex = 117
        '
        'txtNoTrans
        '
        Me.txtNoTrans.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNoTrans.Enabled = False
        Me.txtNoTrans.Location = New System.Drawing.Point(113, 8)
        Me.txtNoTrans.Name = "txtNoTrans"
        Me.txtNoTrans.Size = New System.Drawing.Size(227, 22)
        Me.txtNoTrans.TabIndex = 114
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(216, 63)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(23, 13)
        Me.Label21.TabIndex = 110
        Me.Label21.Text = "s/d"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(7, 63)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(75, 13)
        Me.Label22.TabIndex = 111
        Me.Label22.Text = "Tanggal Nota"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(7, 38)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(101, 13)
        Me.Label23.TabIndex = 112
        Me.Label23.Text = "Tanggal Penjualan"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(7, 13)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(51, 13)
        Me.Label24.TabIndex = 113
        Me.Label24.Text = "No Trans"
        '
        'txtTrip
        '
        Me.txtTrip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTrip.Enabled = False
        Me.txtTrip.Location = New System.Drawing.Point(418, 8)
        Me.txtTrip.Name = "txtTrip"
        Me.txtTrip.Size = New System.Drawing.Size(75, 22)
        Me.txtTrip.TabIndex = 107
        '
        'cboKapal
        '
        Me.cboKapal.Enabled = False
        Me.cboKapal.FormattingEnabled = True
        Me.cboKapal.Location = New System.Drawing.Point(418, 59)
        Me.cboKapal.Name = "cboKapal"
        Me.cboKapal.Size = New System.Drawing.Size(302, 21)
        Me.cboKapal.TabIndex = 109
        '
        'cboPancang
        '
        Me.cboPancang.Enabled = False
        Me.cboPancang.FormattingEnabled = True
        Me.cboPancang.Location = New System.Drawing.Point(418, 34)
        Me.cboPancang.Name = "cboPancang"
        Me.cboPancang.Size = New System.Drawing.Size(302, 21)
        Me.cboPancang.TabIndex = 108
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(362, 13)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(25, 13)
        Me.Label18.TabIndex = 104
        Me.Label18.Text = "Trip"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(748, 13)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(42, 13)
        Me.Label25.TabIndex = 105
        Me.Label25.Text = "Tujuan"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(748, 63)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(38, 13)
        Me.Label27.TabIndex = 105
        Me.Label27.Text = "Grade"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(362, 63)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(35, 13)
        Me.Label19.TabIndex = 105
        Me.Label19.Text = "Kapal"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(748, 38)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(35, 13)
        Me.Label26.TabIndex = 103
        Me.Label26.Text = "Jenis "
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(362, 38)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(51, 13)
        Me.Label20.TabIndex = 103
        Me.Label20.Text = "Pancang"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel6.Controls.Add(Me.btnClose)
        Me.Panel6.Controls.Add(Me.btnSave)
        Me.Panel6.Controls.Add(Me.txtTotal)
        Me.Panel6.Controls.Add(Me.Label11)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel6.Location = New System.Drawing.Point(0, 750)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1412, 40)
        Me.Panel6.TabIndex = 1
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.White
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(1327, 5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnClose.Size = New System.Drawing.Size(75, 30)
        Me.btnClose.TabIndex = 905665
        Me.btnClose.Text = "Exit"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.White
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(1251, 5)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnSave.Size = New System.Drawing.Size(75, 30)
        Me.btnSave.TabIndex = 905664
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'txtTotal
        '
        Me.txtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotal.BackColor = System.Drawing.Color.White
        Me.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(44, 10)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(129, 20)
        Me.txtTotal.TabIndex = 905653
        Me.txtTotal.Text = "0"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(7, 14)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(31, 13)
        Me.Label11.TabIndex = 905652
        Me.Label11.Text = "Total"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.Panel9)
        Me.Panel7.Controls.Add(Me.btnCancel)
        Me.Panel7.Controls.Add(Me.btnProposional)
        Me.Panel7.Controls.Add(Me.btnFindKapal)
        Me.Panel7.Controls.Add(Me.chkPPH22)
        Me.Panel7.Controls.Add(Me.txtNoTrans)
        Me.Panel7.Controls.Add(Me.rdKapalTenggelam)
        Me.Panel7.Controls.Add(Me.Label20)
        Me.Panel7.Controls.Add(Me.rdHabis)
        Me.Panel7.Controls.Add(Me.Label26)
        Me.Panel7.Controls.Add(Me.rdBersambung)
        Me.Panel7.Controls.Add(Me.Label19)
        Me.Panel7.Controls.Add(Me.chkA6)
        Me.Panel7.Controls.Add(Me.Label27)
        Me.Panel7.Controls.Add(Me.Panel15)
        Me.Panel7.Controls.Add(Me.Label25)
        Me.Panel7.Controls.Add(Me.Panel11)
        Me.Panel7.Controls.Add(Me.Label18)
        Me.Panel7.Controls.Add(Me.cboPancang)
        Me.Panel7.Controls.Add(Me.cboKapal)
        Me.Panel7.Controls.Add(Me.txtTrip)
        Me.Panel7.Controls.Add(Me.Panel10)
        Me.Panel7.Controls.Add(Me.Label24)
        Me.Panel7.Controls.Add(Me.dtpTanggalNota2)
        Me.Panel7.Controls.Add(Me.Label23)
        Me.Panel7.Controls.Add(Me.dtpTanggalNota1)
        Me.Panel7.Controls.Add(Me.Label22)
        Me.Panel7.Controls.Add(Me.dtpTanggalPenjualan)
        Me.Panel7.Controls.Add(Me.Label21)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 40)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(1412, 88)
        Me.Panel7.TabIndex = 2
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.White
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(1273, 54)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Padding = New System.Windows.Forms.Padding(5, 0, 3, 0)
        Me.btnCancel.Size = New System.Drawing.Size(75, 30)
        Me.btnCancel.TabIndex = 905733
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnProposional
        '
        Me.btnProposional.BackColor = System.Drawing.Color.White
        Me.btnProposional.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProposional.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProposional.Location = New System.Drawing.Point(1176, 54)
        Me.btnProposional.Name = "btnProposional"
        Me.btnProposional.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnProposional.Size = New System.Drawing.Size(96, 30)
        Me.btnProposional.TabIndex = 905732
        Me.btnProposional.Text = "Proposional"
        Me.btnProposional.UseVisualStyleBackColor = False
        '
        'btnFindKapal
        '
        Me.btnFindKapal.BackColor = System.Drawing.Color.White
        Me.btnFindKapal.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindKapal.Image = CType(resources.GetObject("btnFindKapal.Image"), System.Drawing.Image)
        Me.btnFindKapal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFindKapal.Location = New System.Drawing.Point(1078, 54)
        Me.btnFindKapal.Name = "btnFindKapal"
        Me.btnFindKapal.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnFindKapal.Size = New System.Drawing.Size(97, 30)
        Me.btnFindKapal.TabIndex = 905731
        Me.btnFindKapal.Text = "Find Kapal"
        Me.btnFindKapal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFindKapal.UseVisualStyleBackColor = False
        '
        'Panel16
        '
        Me.Panel16.Controls.Add(Me.Panel2)
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel16.Location = New System.Drawing.Point(0, 128)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Padding = New System.Windows.Forms.Padding(10, 0, 10, 10)
        Me.Panel16.Size = New System.Drawing.Size(1412, 622)
        Me.Panel16.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(10, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Panel2.Size = New System.Drawing.Size(1392, 612)
        Me.Panel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel13)
        Me.Panel3.Controls.Add(Me.Panel12)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 169)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Panel3.Size = New System.Drawing.Size(1392, 443)
        Me.Panel3.TabIndex = 6
        '
        'Panel13
        '
        Me.Panel13.Controls.Add(Me.Panel4)
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel13.Location = New System.Drawing.Point(637, 5)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(755, 438)
        Me.Panel13.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.AutoScroll = True
        Me.Panel4.Controls.Add(Me.GroupBox5)
        Me.Panel4.Controls.Add(Me.GroupBox4)
        Me.Panel4.Controls.Add(Me.GroupBox3)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Panel4.Size = New System.Drawing.Size(755, 438)
        Me.Panel4.TabIndex = 1
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.BackColor = System.Drawing.Color.White
        Me.GroupBox5.Controls.Add(Me.Panel14)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.txtGDPersen)
        Me.GroupBox5.Controls.Add(Me.txtKCPersen)
        Me.GroupBox5.Controls.Add(Me.txtTotAllPbk)
        Me.GroupBox5.Controls.Add(Me.txtTotPbk)
        Me.GroupBox5.Controls.Add(Me.txtTotPcg)
        Me.GroupBox5.Controls.Add(Me.txtGDAllPbk)
        Me.GroupBox5.Controls.Add(Me.txtKCAllPbk)
        Me.GroupBox5.Controls.Add(Me.txtGDPbk)
        Me.GroupBox5.Controls.Add(Me.txtKCPbk)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Controls.Add(Me.txtGDPcg)
        Me.GroupBox5.Controls.Add(Me.txtKCPcg)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Controls.Add(Me.txtKBBPersen)
        Me.GroupBox5.Controls.Add(Me.txtKBBAllPbk)
        Me.GroupBox5.Controls.Add(Me.txtKBBPbk)
        Me.GroupBox5.Controls.Add(Me.txtKBBPcg)
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.Label29)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Controls.Add(Me.txtKBAPersen)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.txtKBAAllPbk)
        Me.GroupBox5.Controls.Add(Me.txtKBAPbk)
        Me.GroupBox5.Controls.Add(Me.txtKBAPcg)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Controls.Add(Me.txtBertambah)
        Me.GroupBox5.Controls.Add(Me.txtSusut)
        Me.GroupBox5.Location = New System.Drawing.Point(3, 283)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(715, 176)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        '
        'Panel14
        '
        Me.Panel14.BackColor = System.Drawing.Color.Black
        Me.Panel14.Location = New System.Drawing.Point(16, 142)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(260, 1)
        Me.Panel14.TabIndex = 140
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 13)
        Me.Label3.TabIndex = 138
        '
        'txtGDPersen
        '
        Me.txtGDPersen.AutoSize = True
        Me.txtGDPersen.Location = New System.Drawing.Point(263, 122)
        Me.txtGDPersen.Name = "txtGDPersen"
        Me.txtGDPersen.Size = New System.Drawing.Size(13, 13)
        Me.txtGDPersen.TabIndex = 137
        Me.txtGDPersen.Text = "0"
        '
        'txtKCPersen
        '
        Me.txtKCPersen.AutoSize = True
        Me.txtKCPersen.Location = New System.Drawing.Point(263, 98)
        Me.txtKCPersen.Name = "txtKCPersen"
        Me.txtKCPersen.Size = New System.Drawing.Size(13, 13)
        Me.txtKCPersen.TabIndex = 137
        Me.txtKCPersen.Text = "0"
        '
        'txtTotAllPbk
        '
        Me.txtTotAllPbk.AutoSize = True
        Me.txtTotAllPbk.Location = New System.Drawing.Point(189, 148)
        Me.txtTotAllPbk.Name = "txtTotAllPbk"
        Me.txtTotAllPbk.Size = New System.Drawing.Size(13, 13)
        Me.txtTotAllPbk.TabIndex = 136
        Me.txtTotAllPbk.Text = "0"
        '
        'txtTotPbk
        '
        Me.txtTotPbk.AutoSize = True
        Me.txtTotPbk.Location = New System.Drawing.Point(133, 148)
        Me.txtTotPbk.Name = "txtTotPbk"
        Me.txtTotPbk.Size = New System.Drawing.Size(13, 13)
        Me.txtTotPbk.TabIndex = 135
        Me.txtTotPbk.Text = "0"
        '
        'txtTotPcg
        '
        Me.txtTotPcg.AutoSize = True
        Me.txtTotPcg.Location = New System.Drawing.Point(65, 148)
        Me.txtTotPcg.Name = "txtTotPcg"
        Me.txtTotPcg.Size = New System.Drawing.Size(13, 13)
        Me.txtTotPcg.TabIndex = 134
        Me.txtTotPcg.Text = "0"
        '
        'txtGDAllPbk
        '
        Me.txtGDAllPbk.AutoSize = True
        Me.txtGDAllPbk.Location = New System.Drawing.Point(189, 122)
        Me.txtGDAllPbk.Name = "txtGDAllPbk"
        Me.txtGDAllPbk.Size = New System.Drawing.Size(13, 13)
        Me.txtGDAllPbk.TabIndex = 133
        Me.txtGDAllPbk.Text = "0"
        '
        'txtKCAllPbk
        '
        Me.txtKCAllPbk.AutoSize = True
        Me.txtKCAllPbk.Location = New System.Drawing.Point(189, 98)
        Me.txtKCAllPbk.Name = "txtKCAllPbk"
        Me.txtKCAllPbk.Size = New System.Drawing.Size(13, 13)
        Me.txtKCAllPbk.TabIndex = 133
        Me.txtKCAllPbk.Text = "0"
        '
        'txtGDPbk
        '
        Me.txtGDPbk.AutoSize = True
        Me.txtGDPbk.Location = New System.Drawing.Point(133, 122)
        Me.txtGDPbk.Name = "txtGDPbk"
        Me.txtGDPbk.Size = New System.Drawing.Size(13, 13)
        Me.txtGDPbk.TabIndex = 132
        Me.txtGDPbk.Text = "0"
        '
        'txtKCPbk
        '
        Me.txtKCPbk.AutoSize = True
        Me.txtKCPbk.Location = New System.Drawing.Point(133, 98)
        Me.txtKCPbk.Name = "txtKCPbk"
        Me.txtKCPbk.Size = New System.Drawing.Size(13, 13)
        Me.txtKCPbk.TabIndex = 132
        Me.txtKCPbk.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(15, 148)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 13)
        Me.Label9.TabIndex = 131
        Me.Label9.Text = "Total"
        '
        'txtGDPcg
        '
        Me.txtGDPcg.AutoSize = True
        Me.txtGDPcg.Location = New System.Drawing.Point(65, 122)
        Me.txtGDPcg.Name = "txtGDPcg"
        Me.txtGDPcg.Size = New System.Drawing.Size(13, 13)
        Me.txtGDPcg.TabIndex = 130
        Me.txtGDPcg.Text = "0"
        '
        'txtKCPcg
        '
        Me.txtKCPcg.AutoSize = True
        Me.txtKCPcg.Location = New System.Drawing.Point(65, 98)
        Me.txtKCPcg.Name = "txtKCPcg"
        Me.txtKCPcg.Size = New System.Drawing.Size(13, 13)
        Me.txtKCPcg.TabIndex = 130
        Me.txtKCPcg.Text = "0"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(15, 122)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(23, 13)
        Me.Label12.TabIndex = 129
        Me.Label12.Text = "GD"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(20, 13)
        Me.Label4.TabIndex = 129
        Me.Label4.Text = "KC"
        '
        'txtKBBPersen
        '
        Me.txtKBBPersen.AutoSize = True
        Me.txtKBBPersen.Location = New System.Drawing.Point(263, 73)
        Me.txtKBBPersen.Name = "txtKBBPersen"
        Me.txtKBBPersen.Size = New System.Drawing.Size(13, 13)
        Me.txtKBBPersen.TabIndex = 128
        Me.txtKBBPersen.Text = "0"
        '
        'txtKBBAllPbk
        '
        Me.txtKBBAllPbk.AutoSize = True
        Me.txtKBBAllPbk.Location = New System.Drawing.Point(189, 73)
        Me.txtKBBAllPbk.Name = "txtKBBAllPbk"
        Me.txtKBBAllPbk.Size = New System.Drawing.Size(13, 13)
        Me.txtKBBAllPbk.TabIndex = 115
        Me.txtKBBAllPbk.Text = "0"
        '
        'txtKBBPbk
        '
        Me.txtKBBPbk.AutoSize = True
        Me.txtKBBPbk.Location = New System.Drawing.Point(133, 73)
        Me.txtKBBPbk.Name = "txtKBBPbk"
        Me.txtKBBPbk.Size = New System.Drawing.Size(13, 13)
        Me.txtKBBPbk.TabIndex = 126
        Me.txtKBBPbk.Text = "0"
        '
        'txtKBBPcg
        '
        Me.txtKBBPcg.AutoSize = True
        Me.txtKBBPcg.Location = New System.Drawing.Point(65, 73)
        Me.txtKBBPcg.Name = "txtKBBPcg"
        Me.txtKBBPcg.Size = New System.Drawing.Size(13, 13)
        Me.txtKBBPcg.TabIndex = 125
        Me.txtKBBPcg.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 124
        Me.Label2.Text = "KB-B"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(263, 22)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(16, 13)
        Me.Label29.TabIndex = 123
        Me.Label29.Text = "%"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(15, 22)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(41, 13)
        Me.Label16.TabIndex = 122
        Me.Label16.Text = "Grade"
        '
        'txtKBAPersen
        '
        Me.txtKBAPersen.AutoSize = True
        Me.txtKBAPersen.Location = New System.Drawing.Point(263, 45)
        Me.txtKBAPersen.Name = "txtKBAPersen"
        Me.txtKBAPersen.Size = New System.Drawing.Size(13, 13)
        Me.txtKBAPersen.TabIndex = 121
        Me.txtKBAPersen.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(65, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 120
        Me.Label7.Text = "Pancang"
        '
        'txtKBAAllPbk
        '
        Me.txtKBAAllPbk.AutoSize = True
        Me.txtKBAAllPbk.Location = New System.Drawing.Point(189, 45)
        Me.txtKBAAllPbk.Name = "txtKBAAllPbk"
        Me.txtKBAAllPbk.Size = New System.Drawing.Size(13, 13)
        Me.txtKBAAllPbk.TabIndex = 119
        Me.txtKBAAllPbk.Text = "0"
        '
        'txtKBAPbk
        '
        Me.txtKBAPbk.AutoSize = True
        Me.txtKBAPbk.Location = New System.Drawing.Point(133, 45)
        Me.txtKBAPbk.Name = "txtKBAPbk"
        Me.txtKBAPbk.Size = New System.Drawing.Size(13, 13)
        Me.txtKBAPbk.TabIndex = 118
        Me.txtKBAPbk.Text = "0"
        '
        'txtKBAPcg
        '
        Me.txtKBAPcg.AutoSize = True
        Me.txtKBAPcg.Location = New System.Drawing.Point(65, 45)
        Me.txtKBAPcg.Name = "txtKBAPcg"
        Me.txtKBAPcg.Size = New System.Drawing.Size(13, 13)
        Me.txtKBAPcg.TabIndex = 117
        Me.txtKBAPcg.Text = "0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(189, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 13)
        Me.Label10.TabIndex = 116
        Me.Label10.Text = "All Pabrik"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(133, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 139
        Me.Label5.Text = "Pabrik"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 127
        Me.Label1.Text = "KB-A"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(308, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 13)
        Me.Label8.TabIndex = 113
        Me.Label8.Text = "BERTAMBAH"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(308, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 113
        Me.Label6.Text = "SUSUT"
        '
        'txtBertambah
        '
        Me.txtBertambah.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBertambah.Location = New System.Drawing.Point(395, 44)
        Me.txtBertambah.Name = "txtBertambah"
        Me.txtBertambah.ReadOnly = True
        Me.txtBertambah.Size = New System.Drawing.Size(155, 22)
        Me.txtBertambah.TabIndex = 114
        '
        'txtSusut
        '
        Me.txtSusut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSusut.Location = New System.Drawing.Point(395, 18)
        Me.txtSusut.Name = "txtSusut"
        Me.txtSusut.ReadOnly = True
        Me.txtSusut.Size = New System.Drawing.Size(155, 22)
        Me.txtSusut.TabIndex = 114
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.BackColor = System.Drawing.Color.White
        Me.GroupBox4.Controls.Add(Me.fgPenjualan)
        Me.GroupBox4.Location = New System.Drawing.Point(3, 142)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(715, 135)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Penjualan"
        '
        'fgPenjualan
        '
        Me.fgPenjualan.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.fgPenjualan.ColumnInfo = resources.GetString("fgPenjualan.ColumnInfo")
        Me.fgPenjualan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgPenjualan.Location = New System.Drawing.Point(3, 18)
        Me.fgPenjualan.Name = "fgPenjualan"
        Me.fgPenjualan.Rows.Count = 1
        Me.fgPenjualan.Size = New System.Drawing.Size(709, 114)
        Me.fgPenjualan.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.BackColor = System.Drawing.Color.White
        Me.GroupBox3.Controls.Add(Me.fgStok)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 1)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(715, 135)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Stok"
        '
        'fgStok
        '
        Me.fgStok.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.fgStok.ColumnInfo = resources.GetString("fgStok.ColumnInfo")
        Me.fgStok.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgStok.Location = New System.Drawing.Point(3, 18)
        Me.fgStok.Name = "fgStok"
        Me.fgStok.Rows.Count = 1
        Me.fgStok.Size = New System.Drawing.Size(709, 114)
        Me.fgStok.TabIndex = 0
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.GroupBox2)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel12.Location = New System.Drawing.Point(0, 5)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(637, 438)
        Me.Panel12.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.fgPancang)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(637, 438)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Nota Pancang"
        '
        'fgPancang
        '
        Me.fgPancang.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.fgPancang.ColumnInfo = resources.GetString("fgPancang.ColumnInfo")
        Me.fgPancang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgPancang.Location = New System.Drawing.Point(3, 18)
        Me.fgPancang.Name = "fgPancang"
        Me.fgPancang.Rows.Count = 1
        Me.fgPancang.Size = New System.Drawing.Size(631, 417)
        Me.fgPancang.TabIndex = 2
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.PanelGroupPabrik)
        Me.Panel5.Controls.Add(Me.grpFakturPembelian)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 5)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1392, 164)
        Me.Panel5.TabIndex = 4
        '
        'PanelGroupPabrik
        '
        Me.PanelGroupPabrik.Controls.Add(Me.PanelAllPabrik)
        Me.PanelGroupPabrik.Controls.Add(Me.PanelPabrik)
        Me.PanelGroupPabrik.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelGroupPabrik.Location = New System.Drawing.Point(515, 0)
        Me.PanelGroupPabrik.Name = "PanelGroupPabrik"
        Me.PanelGroupPabrik.Size = New System.Drawing.Size(877, 164)
        Me.PanelGroupPabrik.TabIndex = 4
        '
        'PanelAllPabrik
        '
        Me.PanelAllPabrik.Controls.Add(Me.GroupBox6)
        Me.PanelAllPabrik.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelAllPabrik.Location = New System.Drawing.Point(520, 0)
        Me.PanelAllPabrik.Name = "PanelAllPabrik"
        Me.PanelAllPabrik.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.PanelAllPabrik.Size = New System.Drawing.Size(357, 164)
        Me.PanelAllPabrik.TabIndex = 2
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.White
        Me.GroupBox6.Controls.Add(Me.fgAllPabrik)
        Me.GroupBox6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox6.Location = New System.Drawing.Point(5, 0)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(352, 164)
        Me.GroupBox6.TabIndex = 0
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "All Nota Bongkar Pabrik"
        '
        'fgAllPabrik
        '
        Me.fgAllPabrik.ColumnInfo = resources.GetString("fgAllPabrik.ColumnInfo")
        Me.fgAllPabrik.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgAllPabrik.Location = New System.Drawing.Point(3, 18)
        Me.fgAllPabrik.Name = "fgAllPabrik"
        Me.fgAllPabrik.Rows.Count = 1
        Me.fgAllPabrik.Size = New System.Drawing.Size(346, 143)
        Me.fgAllPabrik.TabIndex = 0
        '
        'PanelPabrik
        '
        Me.PanelPabrik.Controls.Add(Me.grpNotaPabrik)
        Me.PanelPabrik.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelPabrik.Location = New System.Drawing.Point(0, 0)
        Me.PanelPabrik.Name = "PanelPabrik"
        Me.PanelPabrik.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.PanelPabrik.Size = New System.Drawing.Size(520, 164)
        Me.PanelPabrik.TabIndex = 1
        '
        'grpNotaPabrik
        '
        Me.grpNotaPabrik.BackColor = System.Drawing.Color.White
        Me.grpNotaPabrik.Controls.Add(Me.fgPabrik)
        Me.grpNotaPabrik.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpNotaPabrik.Location = New System.Drawing.Point(5, 0)
        Me.grpNotaPabrik.Name = "grpNotaPabrik"
        Me.grpNotaPabrik.Size = New System.Drawing.Size(515, 164)
        Me.grpNotaPabrik.TabIndex = 0
        Me.grpNotaPabrik.TabStop = False
        Me.grpNotaPabrik.Text = "Select Nota Bongkar Pabrik"
        '
        'fgPabrik
        '
        Me.fgPabrik.ColumnInfo = resources.GetString("fgPabrik.ColumnInfo")
        Me.fgPabrik.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgPabrik.Location = New System.Drawing.Point(3, 18)
        Me.fgPabrik.Name = "fgPabrik"
        Me.fgPabrik.Rows.Count = 1
        Me.fgPabrik.Size = New System.Drawing.Size(509, 143)
        Me.fgPabrik.TabIndex = 0
        '
        'grpFakturPembelian
        '
        Me.grpFakturPembelian.BackColor = System.Drawing.Color.White
        Me.grpFakturPembelian.Controls.Add(Me.fgFakturPabrik)
        Me.grpFakturPembelian.Dock = System.Windows.Forms.DockStyle.Left
        Me.grpFakturPembelian.Location = New System.Drawing.Point(0, 0)
        Me.grpFakturPembelian.Name = "grpFakturPembelian"
        Me.grpFakturPembelian.Size = New System.Drawing.Size(515, 164)
        Me.grpFakturPembelian.TabIndex = 3
        Me.grpFakturPembelian.TabStop = False
        Me.grpFakturPembelian.Text = "Faktur Pembelian Pabrik"
        '
        'fgFakturPabrik
        '
        Me.fgFakturPabrik.ColumnInfo = resources.GetString("fgFakturPabrik.ColumnInfo")
        Me.fgFakturPabrik.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgFakturPabrik.Location = New System.Drawing.Point(3, 18)
        Me.fgFakturPabrik.Name = "fgFakturPabrik"
        Me.fgFakturPabrik.Rows.Count = 1
        Me.fgFakturPabrik.Size = New System.Drawing.Size(509, 143)
        Me.fgFakturPabrik.TabIndex = 0
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.Black
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(1412, 1)
        Me.Panel9.TabIndex = 905734
        '
        'FrmTrnPembuatanPenjualan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1412, 790)
        Me.Controls.Add(Me.Panel16)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FrmTrnPembuatanPenjualan"
        Me.Text = "Transaksi Penjualan RSUP Dan PSG"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel15.ResumeLayout(False)
        Me.Panel15.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel16.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel13.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.fgPenjualan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.fgStok, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel12.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.fgPancang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.PanelGroupPabrik.ResumeLayout(False)
        Me.PanelAllPabrik.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.fgAllPabrik, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelPabrik.ResumeLayout(False)
        Me.grpNotaPabrik.ResumeLayout(False)
        CType(Me.fgPabrik, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFakturPembelian.ResumeLayout(False)
        CType(Me.fgFakturPabrik, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtTrip As TextBox
    Friend WithEvents cboKapal As ComboBox
    Friend WithEvents cboPancang As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents dtpTanggalNota2 As DateTimePicker
    Friend WithEvents dtpTanggalNota1 As DateTimePicker
    Friend WithEvents dtpTanggalPenjualan As DateTimePicker
    Friend WithEvents txtNoTrans As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents rdRSUP As RadioButton
    Friend WithEvents rdPSG As RadioButton
    Friend WithEvents Label25 As Label
    Friend WithEvents Panel10 As Panel
    Friend WithEvents rdKBA As RadioButton
    Friend WithEvents rdKC As RadioButton
    Friend WithEvents rdKBB As RadioButton
    Friend WithEvents Panel11 As Panel
    Friend WithEvents rdJambul As RadioButton
    Friend WithEvents rdLicin As RadioButton
    Friend WithEvents rdCungkil As RadioButton
    Friend WithEvents Label27 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents chkA6 As CheckBox
    Friend WithEvents rdHabis As RadioButton
    Friend WithEvents rdBersambung As RadioButton
    Friend WithEvents Panel15 As Panel
    Friend WithEvents rdGelondong As RadioButton
    Friend WithEvents rdGD As RadioButton
    Friend WithEvents rdKapalTenggelam As CheckBox
    Friend WithEvents rdCustomer As RadioButton
    Friend WithEvents chkPPH22 As CheckBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel16 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel13 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Panel14 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents txtGDPersen As Label
    Friend WithEvents txtKCPersen As Label
    Friend WithEvents txtTotAllPbk As Label
    Friend WithEvents txtTotPbk As Label
    Friend WithEvents txtTotPcg As Label
    Friend WithEvents txtGDAllPbk As Label
    Friend WithEvents txtKCAllPbk As Label
    Friend WithEvents txtGDPbk As Label
    Friend WithEvents txtKCPbk As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtGDPcg As Label
    Friend WithEvents txtKCPcg As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtKBBPersen As Label
    Friend WithEvents txtKBBAllPbk As Label
    Friend WithEvents txtKBBPbk As Label
    Friend WithEvents txtKBBPcg As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtKBAPersen As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtKBAAllPbk As Label
    Friend WithEvents txtKBAPbk As Label
    Friend WithEvents txtKBAPcg As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtBertambah As TextBox
    Friend WithEvents txtSusut As TextBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents fgPenjualan As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents fgStok As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel12 As Panel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents fgPancang As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel5 As Panel
    Friend WithEvents PanelGroupPabrik As Panel
    Friend WithEvents PanelAllPabrik As Panel
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents fgAllPabrik As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents PanelPabrik As Panel
    Friend WithEvents grpNotaPabrik As GroupBox
    Friend WithEvents fgPabrik As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents grpFakturPembelian As GroupBox
    Friend WithEvents fgFakturPabrik As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Label13 As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnProposional As Button
    Friend WithEvents btnFindKapal As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Panel9 As Panel
End Class
