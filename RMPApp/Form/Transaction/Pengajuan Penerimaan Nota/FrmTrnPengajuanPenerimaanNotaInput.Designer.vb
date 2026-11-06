Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTrnPengajuanPenerimaanNotaInput
    Inherits DockContent

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTrnPengajuanPenerimaanNotaInput))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnFindNota = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.chkA6 = New System.Windows.Forms.CheckBox()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.rdAllJenis = New System.Windows.Forms.RadioButton()
        Me.rdJambul = New System.Windows.Forms.RadioButton()
        Me.rdCungkil = New System.Windows.Forms.RadioButton()
        Me.rdLicin = New System.Windows.Forms.RadioButton()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.rdAllGrade = New System.Windows.Forms.RadioButton()
        Me.rdKBA = New System.Windows.Forms.RadioButton()
        Me.rdKC = New System.Windows.Forms.RadioButton()
        Me.rdKBB = New System.Windows.Forms.RadioButton()
        Me.rdRSUP = New System.Windows.Forms.RadioButton()
        Me.rdAllTujuan = New System.Windows.Forms.RadioButton()
        Me.rdPSG = New System.Windows.Forms.RadioButton()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtTrip = New System.Windows.Forms.TextBox()
        Me.dtpTanggalNota2 = New System.Windows.Forms.DateTimePicker()
        Me.dtpTanggalNota1 = New System.Windows.Forms.DateTimePicker()
        Me.dtpTanggalApproval = New System.Windows.Forms.DateTimePicker()
        Me.txtNoTrans = New System.Windows.Forms.TextBox()
        Me.cboKapal = New System.Windows.Forms.ComboBox()
        Me.cboPancang = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlFg = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.rdAllAjukan = New System.Windows.Forms.CheckBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.pnlFg.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.btnFindNota)
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Controls.Add(Me.chkA6)
        Me.Panel1.Controls.Add(Me.Panel11)
        Me.Panel1.Controls.Add(Me.Panel10)
        Me.Panel1.Controls.Add(Me.rdRSUP)
        Me.Panel1.Controls.Add(Me.rdAllTujuan)
        Me.Panel1.Controls.Add(Me.rdPSG)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.Label27)
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.txtTrip)
        Me.Panel1.Controls.Add(Me.dtpTanggalNota2)
        Me.Panel1.Controls.Add(Me.dtpTanggalNota1)
        Me.Panel1.Controls.Add(Me.dtpTanggalApproval)
        Me.Panel1.Controls.Add(Me.txtNoTrans)
        Me.Panel1.Controls.Add(Me.cboKapal)
        Me.Panel1.Controls.Add(Me.cboPancang)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 40)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1204, 94)
        Me.Panel1.TabIndex = 0
        '
        'btnFindNota
        '
        Me.btnFindNota.BackColor = System.Drawing.Color.White
        Me.btnFindNota.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFindNota.Image = CType(resources.GetObject("btnFindNota.Image"), System.Drawing.Image)
        Me.btnFindNota.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFindNota.Location = New System.Drawing.Point(1080, 53)
        Me.btnFindNota.Name = "btnFindNota"
        Me.btnFindNota.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnFindNota.Size = New System.Drawing.Size(91, 30)
        Me.btnFindNota.TabIndex = 905705
        Me.btnFindNota.Text = "Find Nota"
        Me.btnFindNota.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFindNota.UseVisualStyleBackColor = False
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Black
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1204, 1)
        Me.Panel6.TabIndex = 905704
        '
        'chkA6
        '
        Me.chkA6.AutoSize = True
        Me.chkA6.Enabled = False
        Me.chkA6.Location = New System.Drawing.Point(1080, 12)
        Me.chkA6.Name = "chkA6"
        Me.chkA6.Size = New System.Drawing.Size(39, 17)
        Me.chkA6.TabIndex = 905667
        Me.chkA6.Text = "A6"
        Me.chkA6.UseVisualStyleBackColor = True
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.rdAllJenis)
        Me.Panel11.Controls.Add(Me.rdJambul)
        Me.Panel11.Controls.Add(Me.rdCungkil)
        Me.Panel11.Controls.Add(Me.rdLicin)
        Me.Panel11.Location = New System.Drawing.Point(803, 36)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(253, 21)
        Me.Panel11.TabIndex = 905665
        '
        'rdAllJenis
        '
        Me.rdAllJenis.AutoSize = True
        Me.rdAllJenis.Checked = True
        Me.rdAllJenis.Enabled = False
        Me.rdAllJenis.Location = New System.Drawing.Point(3, 2)
        Me.rdAllJenis.Name = "rdAllJenis"
        Me.rdAllJenis.Size = New System.Drawing.Size(63, 17)
        Me.rdAllJenis.TabIndex = 118
        Me.rdAllJenis.TabStop = True
        Me.rdAllJenis.Text = "All Jenis"
        Me.rdAllJenis.UseVisualStyleBackColor = True
        '
        'rdJambul
        '
        Me.rdJambul.AutoSize = True
        Me.rdJambul.Enabled = False
        Me.rdJambul.Location = New System.Drawing.Point(72, 2)
        Me.rdJambul.Name = "rdJambul"
        Me.rdJambul.Size = New System.Drawing.Size(58, 17)
        Me.rdJambul.TabIndex = 118
        Me.rdJambul.Text = "Jambul"
        Me.rdJambul.UseVisualStyleBackColor = True
        '
        'rdCungkil
        '
        Me.rdCungkil.AutoSize = True
        Me.rdCungkil.Enabled = False
        Me.rdCungkil.Location = New System.Drawing.Point(189, 2)
        Me.rdCungkil.Name = "rdCungkil"
        Me.rdCungkil.Size = New System.Drawing.Size(60, 17)
        Me.rdCungkil.TabIndex = 118
        Me.rdCungkil.Text = "Cungkil"
        Me.rdCungkil.UseVisualStyleBackColor = True
        '
        'rdLicin
        '
        Me.rdLicin.AutoSize = True
        Me.rdLicin.Enabled = False
        Me.rdLicin.Location = New System.Drawing.Point(136, 2)
        Me.rdLicin.Name = "rdLicin"
        Me.rdLicin.Size = New System.Drawing.Size(47, 17)
        Me.rdLicin.TabIndex = 118
        Me.rdLicin.Text = "Licin"
        Me.rdLicin.UseVisualStyleBackColor = True
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.rdAllGrade)
        Me.Panel10.Controls.Add(Me.rdKBA)
        Me.Panel10.Controls.Add(Me.rdKC)
        Me.Panel10.Controls.Add(Me.rdKBB)
        Me.Panel10.Location = New System.Drawing.Point(803, 63)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(253, 21)
        Me.Panel10.TabIndex = 905666
        '
        'rdAllGrade
        '
        Me.rdAllGrade.AutoSize = True
        Me.rdAllGrade.Checked = True
        Me.rdAllGrade.Enabled = False
        Me.rdAllGrade.Location = New System.Drawing.Point(3, 2)
        Me.rdAllGrade.Name = "rdAllGrade"
        Me.rdAllGrade.Size = New System.Drawing.Size(68, 17)
        Me.rdAllGrade.TabIndex = 118
        Me.rdAllGrade.TabStop = True
        Me.rdAllGrade.Text = "All Grade"
        Me.rdAllGrade.UseVisualStyleBackColor = True
        '
        'rdKBA
        '
        Me.rdKBA.AutoSize = True
        Me.rdKBA.Enabled = False
        Me.rdKBA.Location = New System.Drawing.Point(77, 2)
        Me.rdKBA.Name = "rdKBA"
        Me.rdKBA.Size = New System.Drawing.Size(49, 17)
        Me.rdKBA.TabIndex = 118
        Me.rdKBA.Text = "KB-A"
        Me.rdKBA.UseVisualStyleBackColor = True
        '
        'rdKC
        '
        Me.rdKC.AutoSize = True
        Me.rdKC.Enabled = False
        Me.rdKC.Location = New System.Drawing.Point(187, 2)
        Me.rdKC.Name = "rdKC"
        Me.rdKC.Size = New System.Drawing.Size(39, 17)
        Me.rdKC.TabIndex = 118
        Me.rdKC.Text = "KC"
        Me.rdKC.UseVisualStyleBackColor = True
        '
        'rdKBB
        '
        Me.rdKBB.AutoSize = True
        Me.rdKBB.Enabled = False
        Me.rdKBB.Location = New System.Drawing.Point(132, 2)
        Me.rdKBB.Name = "rdKBB"
        Me.rdKBB.Size = New System.Drawing.Size(49, 17)
        Me.rdKBB.TabIndex = 118
        Me.rdKBB.Text = "KB-B"
        Me.rdKBB.UseVisualStyleBackColor = True
        '
        'rdRSUP
        '
        Me.rdRSUP.AutoSize = True
        Me.rdRSUP.Enabled = False
        Me.rdRSUP.Location = New System.Drawing.Point(937, 12)
        Me.rdRSUP.Name = "rdRSUP"
        Me.rdRSUP.Size = New System.Drawing.Size(55, 17)
        Me.rdRSUP.TabIndex = 905663
        Me.rdRSUP.Text = "RSUP"
        Me.rdRSUP.UseVisualStyleBackColor = True
        '
        'rdAllTujuan
        '
        Me.rdAllTujuan.AutoSize = True
        Me.rdAllTujuan.Checked = True
        Me.rdAllTujuan.Enabled = False
        Me.rdAllTujuan.Location = New System.Drawing.Point(806, 12)
        Me.rdAllTujuan.Name = "rdAllTujuan"
        Me.rdAllTujuan.Size = New System.Drawing.Size(72, 17)
        Me.rdAllTujuan.TabIndex = 905664
        Me.rdAllTujuan.TabStop = True
        Me.rdAllTujuan.Text = "All Tujuan"
        Me.rdAllTujuan.UseVisualStyleBackColor = True
        '
        'rdPSG
        '
        Me.rdPSG.AutoSize = True
        Me.rdPSG.Enabled = False
        Me.rdPSG.Location = New System.Drawing.Point(884, 12)
        Me.rdPSG.Name = "rdPSG"
        Me.rdPSG.Size = New System.Drawing.Size(47, 17)
        Me.rdPSG.TabIndex = 905664
        Me.rdPSG.Text = "PSG"
        Me.rdPSG.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(760, 14)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(40, 13)
        Me.Label25.TabIndex = 905661
        Me.Label25.Text = "Tujuan"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(760, 67)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(36, 13)
        Me.Label27.TabIndex = 905662
        Me.Label27.Text = "Grade"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(760, 40)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(34, 13)
        Me.Label26.TabIndex = 905660
        Me.Label26.Text = "Jenis "
        '
        'txtTrip
        '
        Me.txtTrip.Location = New System.Drawing.Point(422, 10)
        Me.txtTrip.Name = "txtTrip"
        Me.txtTrip.ReadOnly = True
        Me.txtTrip.Size = New System.Drawing.Size(75, 20)
        Me.txtTrip.TabIndex = 100
        '
        'dtpTanggalNota2
        '
        Me.dtpTanggalNota2.Enabled = False
        Me.dtpTanggalNota2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTanggalNota2.Location = New System.Drawing.Point(233, 63)
        Me.dtpTanggalNota2.Name = "dtpTanggalNota2"
        Me.dtpTanggalNota2.Size = New System.Drawing.Size(98, 20)
        Me.dtpTanggalNota2.TabIndex = 12
        '
        'dtpTanggalNota1
        '
        Me.dtpTanggalNota1.Enabled = False
        Me.dtpTanggalNota1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTanggalNota1.Location = New System.Drawing.Point(104, 63)
        Me.dtpTanggalNota1.Name = "dtpTanggalNota1"
        Me.dtpTanggalNota1.Size = New System.Drawing.Size(98, 20)
        Me.dtpTanggalNota1.TabIndex = 12
        '
        'dtpTanggalApproval
        '
        Me.dtpTanggalApproval.Enabled = False
        Me.dtpTanggalApproval.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTanggalApproval.Location = New System.Drawing.Point(104, 36)
        Me.dtpTanggalApproval.Name = "dtpTanggalApproval"
        Me.dtpTanggalApproval.Size = New System.Drawing.Size(227, 20)
        Me.dtpTanggalApproval.TabIndex = 12
        '
        'txtNoTrans
        '
        Me.txtNoTrans.Location = New System.Drawing.Point(104, 10)
        Me.txtNoTrans.Name = "txtNoTrans"
        Me.txtNoTrans.ReadOnly = True
        Me.txtNoTrans.Size = New System.Drawing.Size(227, 20)
        Me.txtNoTrans.TabIndex = 11
        '
        'cboKapal
        '
        Me.cboKapal.Enabled = False
        Me.cboKapal.FormattingEnabled = True
        Me.cboKapal.Location = New System.Drawing.Point(422, 63)
        Me.cboKapal.Name = "cboKapal"
        Me.cboKapal.Size = New System.Drawing.Size(302, 21)
        Me.cboKapal.TabIndex = 102
        '
        'cboPancang
        '
        Me.cboPancang.Enabled = False
        Me.cboPancang.FormattingEnabled = True
        Me.cboPancang.Location = New System.Drawing.Point(422, 36)
        Me.cboPancang.Name = "cboPancang"
        Me.cboPancang.Size = New System.Drawing.Size(302, 21)
        Me.cboPancang.TabIndex = 101
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(366, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Trip"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(213, 67)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(10, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "-"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 67)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Tanggal Nota"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Tanggal Approval"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "No Trans"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(366, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Kapal"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(366, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Pancang"
        '
        'pnlFg
        '
        Me.pnlFg.BackColor = System.Drawing.Color.White
        Me.pnlFg.Controls.Add(Me.Panel4)
        Me.pnlFg.Controls.Add(Me.rdAllAjukan)
        Me.pnlFg.Controls.Add(Me.Panel3)
        Me.pnlFg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlFg.Location = New System.Drawing.Point(0, 134)
        Me.pnlFg.Name = "pnlFg"
        Me.pnlFg.Padding = New System.Windows.Forms.Padding(0, 30, 0, 0)
        Me.pnlFg.Size = New System.Drawing.Size(1204, 288)
        Me.pnlFg.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.fg)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 30)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(10, 0, 10, 10)
        Me.Panel4.Size = New System.Drawing.Size(1204, 218)
        Me.Panel4.TabIndex = 3
        '
        'fg
        '
        Me.fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.fg.ColumnInfo = resources.GetString("fg.ColumnInfo")
        Me.fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fg.Location = New System.Drawing.Point(10, 0)
        Me.fg.Name = "fg"
        Me.fg.Rows.Count = 1
        Me.fg.Size = New System.Drawing.Size(1184, 208)
        Me.fg.TabIndex = 2
        '
        'rdAllAjukan
        '
        Me.rdAllAjukan.AutoSize = True
        Me.rdAllAjukan.Location = New System.Drawing.Point(10, 10)
        Me.rdAllAjukan.Name = "rdAllAjukan"
        Me.rdAllAjukan.Size = New System.Drawing.Size(59, 17)
        Me.rdAllAjukan.TabIndex = 2
        Me.rdAllAjukan.Text = "Ajukan"
        Me.rdAllAjukan.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel3.Controls.Add(Me.btnCancel)
        Me.Panel3.Controls.Add(Me.btnSave)
        Me.Panel3.Controls.Add(Me.btnDelete)
        Me.Panel3.Controls.Add(Me.txtTotal)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 248)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Panel3.Size = New System.Drawing.Size(1204, 40)
        Me.Panel3.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.White
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(1119, 5)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnCancel.Size = New System.Drawing.Size(75, 30)
        Me.btnCancel.TabIndex = 905663
        Me.btnCancel.Text = "Exit"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.White
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(968, 5)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnSave.Size = New System.Drawing.Size(75, 30)
        Me.btnSave.TabIndex = 905662
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.White
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(1044, 5)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Padding = New System.Windows.Forms.Padding(5, 0, 3, 0)
        Me.btnDelete.Size = New System.Drawing.Size(75, 30)
        Me.btnDelete.TabIndex = 905661
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelete.UseVisualStyleBackColor = False
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
        Me.txtTotal.TabIndex = 905660
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
        Me.Label11.TabIndex = 905659
        Me.Label11.Text = "Total"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(48, 6)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(429, 28)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Transaksi Input Pengajuan Penerimaan Nota"
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Location = New System.Drawing.Point(10, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(35, 35)
        Me.Panel2.TabIndex = 3
        '
        'FrmTrnPengajuanPenerimaanNotaInput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1204, 422)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlFg)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmTrnPengajuanPenerimaanNotaInput"
        Me.Padding = New System.Windows.Forms.Padding(0, 40, 0, 0)
        Me.Text = "Transaksi Input Pengajuan Penerimaan Nota"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.pnlFg.ResumeLayout(False)
        Me.pnlFg.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlFg As Panel
    Friend WithEvents txtNoTrans As TextBox
    Friend WithEvents cboKapal As ComboBox
    Friend WithEvents cboPancang As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpTanggalApproval As DateTimePicker
    Friend WithEvents dtpTanggalNota2 As DateTimePicker
    Friend WithEvents dtpTanggalNota1 As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtTrip As TextBox
    Friend WithEvents rdAllAjukan As CheckBox
    Friend WithEvents chkA6 As CheckBox
    Friend WithEvents Panel11 As Panel
    Friend WithEvents rdJambul As RadioButton
    Friend WithEvents rdCungkil As RadioButton
    Friend WithEvents rdLicin As RadioButton
    Friend WithEvents Panel10 As Panel
    Friend WithEvents rdKBA As RadioButton
    Friend WithEvents rdKC As RadioButton
    Friend WithEvents rdKBB As RadioButton
    Friend WithEvents rdRSUP As RadioButton
    Friend WithEvents rdPSG As RadioButton
    Friend WithEvents Label25 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents rdAllJenis As RadioButton
    Friend WithEvents rdAllGrade As RadioButton
    Friend WithEvents rdAllTujuan As RadioButton
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnFindNota As Button
End Class
