Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMonPenerimaanKBKg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMonPenerimaanKBKg))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnConvertButir = New System.Windows.Forms.Button()
        Me.btnConvertKg = New System.Windows.Forms.Button()
        Me.btnRefreshP1 = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.fgpricekg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.fg2 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.fg1 = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.OptNonOrganik = New System.Windows.Forms.RadioButton()
        Me.OptOrganik = New System.Windows.Forms.RadioButton()
        Me.OptAllData = New System.Windows.Forms.RadioButton()
        Me.TxtNota = New System.Windows.Forms.TextBox()
        Me.TxtKodeSupplier = New System.Windows.Forms.TextBox()
        Me.CmbKapal = New System.Windows.Forms.ComboBox()
        Me.CmbSubSupplier = New System.Windows.Forms.ComboBox()
        Me.CmbAsalKB = New System.Windows.Forms.ComboBox()
        Me.CmbSupplier = New System.Windows.Forms.ComboBox()
        Me.DtpTanggalAkhir = New System.Windows.Forms.DateTimePicker()
        Me.DtpTanggalAwal = New System.Windows.Forms.DateTimePicker()
        Me.ChkBelumDibuatAP = New System.Windows.Forms.CheckBox()
        Me.ChkBelumComplete = New System.Windows.Forms.CheckBox()
        Me.ChkApprovalUangMuka = New System.Windows.Forms.CheckBox()
        Me.ChkCekKapalByID = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel11.SuspendLayout()
        CType(Me.fgpricekg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel10.SuspendLayout()
        Me.Panel14.SuspendLayout()
        CType(Me.fg2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel13.SuspendLayout()
        CType(Me.fg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel12.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Panel7)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1156, 40)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(46, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(395, 28)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Monitoring Penerimaan Kelapa Timbang"
        '
        'Panel7
        '
        Me.Panel7.BackgroundImage = CType(resources.GetObject("Panel7.BackgroundImage"), System.Drawing.Image)
        Me.Panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel7.Location = New System.Drawing.Point(10, 3)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(35, 35)
        Me.Panel7.TabIndex = 7
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnClose)
        Me.Panel2.Controls.Add(Me.btnConvertButir)
        Me.Panel2.Controls.Add(Me.btnConvertKg)
        Me.Panel2.Controls.Add(Me.btnRefreshP1)
        Me.Panel2.Controls.Add(Me.btnRefresh)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 552)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1156, 40)
        Me.Panel2.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.White
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(1071, 5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnClose.Size = New System.Drawing.Size(75, 30)
        Me.btnClose.TabIndex = 22
        Me.btnClose.Text = "Exit"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnConvertButir
        '
        Me.btnConvertButir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConvertButir.BackColor = System.Drawing.Color.White
        Me.btnConvertButir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConvertButir.Location = New System.Drawing.Point(974, 5)
        Me.btnConvertButir.Name = "btnConvertButir"
        Me.btnConvertButir.Size = New System.Drawing.Size(96, 30)
        Me.btnConvertButir.TabIndex = 21
        Me.btnConvertButir.Text = "Convert Butir"
        Me.btnConvertButir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConvertButir.UseVisualStyleBackColor = False
        '
        'btnConvertKg
        '
        Me.btnConvertKg.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConvertKg.BackColor = System.Drawing.Color.White
        Me.btnConvertKg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConvertKg.Location = New System.Drawing.Point(889, 5)
        Me.btnConvertKg.Name = "btnConvertKg"
        Me.btnConvertKg.Size = New System.Drawing.Size(84, 30)
        Me.btnConvertKg.TabIndex = 20
        Me.btnConvertKg.Text = "Convert Kg"
        Me.btnConvertKg.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConvertKg.UseVisualStyleBackColor = False
        '
        'btnRefreshP1
        '
        Me.btnRefreshP1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefreshP1.BackColor = System.Drawing.Color.White
        Me.btnRefreshP1.Image = CType(resources.GetObject("btnRefreshP1.Image"), System.Drawing.Image)
        Me.btnRefreshP1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRefreshP1.Location = New System.Drawing.Point(798, 5)
        Me.btnRefreshP1.Name = "btnRefreshP1"
        Me.btnRefreshP1.Size = New System.Drawing.Size(90, 30)
        Me.btnRefreshP1.TabIndex = 19
        Me.btnRefreshP1.Text = "Refresh P1"
        Me.btnRefreshP1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRefreshP1.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.White
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRefresh.Location = New System.Drawing.Point(722, 5)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 30)
        Me.btnRefresh.TabIndex = 18
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 40)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1156, 512)
        Me.Panel3.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.White
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 118)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(10, 0, 10, 10)
        Me.Panel5.Size = New System.Drawing.Size(1156, 394)
        Me.Panel5.TabIndex = 0
        '
        'Panel6
        '
        Me.Panel6.AutoScroll = True
        Me.Panel6.Controls.Add(Me.Panel9)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(10, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1136, 384)
        Me.Panel6.TabIndex = 0
        '
        'Panel9
        '
        Me.Panel9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel9.Controls.Add(Me.Panel11)
        Me.Panel9.Controls.Add(Me.Panel10)
        Me.Panel9.Controls.Add(Me.Panel12)
        Me.Panel9.Location = New System.Drawing.Point(2, 2)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(1114, 600)
        Me.Panel9.TabIndex = 0
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.fgpricekg)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel11.Location = New System.Drawing.Point(0, 200)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.Panel11.Size = New System.Drawing.Size(1114, 200)
        Me.Panel11.TabIndex = 5
        '
        'fgpricekg
        '
        Me.fgpricekg.AllowEditing = False
        Me.fgpricekg.AutoClipboard = True
        Me.fgpricekg.ColumnInfo = "10,1,0,0,0,-1,Columns:0{Caption:""No"";StyleFixed:""TextAlign:CenterCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.fgpricekg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgpricekg.Location = New System.Drawing.Point(0, 0)
        Me.fgpricekg.Name = "fgpricekg"
        Me.fgpricekg.Size = New System.Drawing.Size(1114, 190)
        Me.fgpricekg.TabIndex = 1
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.Panel14)
        Me.Panel10.Controls.Add(Me.Panel13)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel10.Location = New System.Drawing.Point(0, 400)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(1114, 200)
        Me.Panel10.TabIndex = 2
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.fg2)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel14.Location = New System.Drawing.Point(568, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Panel14.Size = New System.Drawing.Size(546, 200)
        Me.Panel14.TabIndex = 0
        '
        'fg2
        '
        Me.fg2.AllowEditing = False
        Me.fg2.AutoClipboard = True
        Me.fg2.ColumnInfo = "10,1,0,0,0,-1,Columns:0{Caption:""No"";StyleFixed:""TextAlign:CenterCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.fg2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fg2.Location = New System.Drawing.Point(5, 0)
        Me.fg2.Name = "fg2"
        Me.fg2.Size = New System.Drawing.Size(541, 200)
        Me.fg2.TabIndex = 2
        '
        'Panel13
        '
        Me.Panel13.Controls.Add(Me.fg1)
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel13.Location = New System.Drawing.Point(0, 0)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.Panel13.Size = New System.Drawing.Size(568, 200)
        Me.Panel13.TabIndex = 0
        '
        'fg1
        '
        Me.fg1.AllowEditing = False
        Me.fg1.AutoClipboard = True
        Me.fg1.ColumnInfo = "10,1,0,0,0,-1,Columns:0{Caption:""No"";StyleFixed:""TextAlign:CenterCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.fg1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fg1.Location = New System.Drawing.Point(0, 0)
        Me.fg1.Name = "fg1"
        Me.fg1.Size = New System.Drawing.Size(563, 200)
        Me.fg1.TabIndex = 2
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.fg)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel12.Location = New System.Drawing.Point(0, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.Panel12.Size = New System.Drawing.Size(1114, 200)
        Me.Panel12.TabIndex = 4
        '
        'fg
        '
        Me.fg.AllowEditing = False
        Me.fg.AutoClipboard = True
        Me.fg.ColumnInfo = "10,1,0,0,0,-1,Columns:0{Caption:""No"";StyleFixed:""TextAlign:CenterCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fg.Location = New System.Drawing.Point(0, 0)
        Me.fg.Name = "fg"
        Me.fg.Size = New System.Drawing.Size(1114, 190)
        Me.fg.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.OptNonOrganik)
        Me.Panel4.Controls.Add(Me.OptOrganik)
        Me.Panel4.Controls.Add(Me.OptAllData)
        Me.Panel4.Controls.Add(Me.TxtNota)
        Me.Panel4.Controls.Add(Me.TxtKodeSupplier)
        Me.Panel4.Controls.Add(Me.CmbKapal)
        Me.Panel4.Controls.Add(Me.CmbSubSupplier)
        Me.Panel4.Controls.Add(Me.CmbAsalKB)
        Me.Panel4.Controls.Add(Me.CmbSupplier)
        Me.Panel4.Controls.Add(Me.DtpTanggalAkhir)
        Me.Panel4.Controls.Add(Me.DtpTanggalAwal)
        Me.Panel4.Controls.Add(Me.ChkBelumDibuatAP)
        Me.Panel4.Controls.Add(Me.ChkBelumComplete)
        Me.Panel4.Controls.Add(Me.ChkApprovalUangMuka)
        Me.Panel4.Controls.Add(Me.ChkCekKapalByID)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.Panel8)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1156, 118)
        Me.Panel4.TabIndex = 0
        '
        'OptNonOrganik
        '
        Me.OptNonOrganik.AutoSize = True
        Me.OptNonOrganik.Location = New System.Drawing.Point(697, 88)
        Me.OptNonOrganik.Name = "OptNonOrganik"
        Me.OptNonOrganik.Size = New System.Drawing.Size(126, 17)
        Me.OptNonOrganik.TabIndex = 905716
        Me.OptNonOrganik.Text = "Produk nonorganik"
        Me.OptNonOrganik.UseVisualStyleBackColor = True
        '
        'OptOrganik
        '
        Me.OptOrganik.AutoSize = True
        Me.OptOrganik.Location = New System.Drawing.Point(586, 88)
        Me.OptOrganik.Name = "OptOrganik"
        Me.OptOrganik.Size = New System.Drawing.Size(105, 17)
        Me.OptOrganik.TabIndex = 905716
        Me.OptOrganik.Text = "Produk organik"
        Me.OptOrganik.UseVisualStyleBackColor = True
        '
        'OptAllData
        '
        Me.OptAllData.AutoSize = True
        Me.OptAllData.Checked = True
        Me.OptAllData.Location = New System.Drawing.Point(453, 88)
        Me.OptAllData.Name = "OptAllData"
        Me.OptAllData.Size = New System.Drawing.Size(127, 17)
        Me.OptAllData.TabIndex = 905716
        Me.OptAllData.TabStop = True
        Me.OptAllData.Text = "Semua jenis produk"
        Me.OptAllData.UseVisualStyleBackColor = True
        '
        'TxtNota
        '
        Me.TxtNota.Location = New System.Drawing.Point(453, 62)
        Me.TxtNota.Name = "TxtNota"
        Me.TxtNota.Size = New System.Drawing.Size(236, 22)
        Me.TxtNota.TabIndex = 905715
        '
        'TxtKodeSupplier
        '
        Me.TxtKodeSupplier.Location = New System.Drawing.Point(453, 13)
        Me.TxtKodeSupplier.Name = "TxtKodeSupplier"
        Me.TxtKodeSupplier.Size = New System.Drawing.Size(236, 22)
        Me.TxtKodeSupplier.TabIndex = 905715
        '
        'CmbKapal
        '
        Me.CmbKapal.FormattingEnabled = True
        Me.CmbKapal.Location = New System.Drawing.Point(453, 38)
        Me.CmbKapal.Name = "CmbKapal"
        Me.CmbKapal.Size = New System.Drawing.Size(236, 21)
        Me.CmbKapal.TabIndex = 905714
        '
        'CmbSubSupplier
        '
        Me.CmbSubSupplier.FormattingEnabled = True
        Me.CmbSubSupplier.Location = New System.Drawing.Point(96, 86)
        Me.CmbSubSupplier.Name = "CmbSubSupplier"
        Me.CmbSubSupplier.Size = New System.Drawing.Size(236, 21)
        Me.CmbSubSupplier.TabIndex = 905714
        '
        'CmbAsalKB
        '
        Me.CmbAsalKB.FormattingEnabled = True
        Me.CmbAsalKB.Location = New System.Drawing.Point(96, 62)
        Me.CmbAsalKB.Name = "CmbAsalKB"
        Me.CmbAsalKB.Size = New System.Drawing.Size(236, 21)
        Me.CmbAsalKB.TabIndex = 905714
        '
        'CmbSupplier
        '
        Me.CmbSupplier.FormattingEnabled = True
        Me.CmbSupplier.Location = New System.Drawing.Point(96, 38)
        Me.CmbSupplier.Name = "CmbSupplier"
        Me.CmbSupplier.Size = New System.Drawing.Size(236, 21)
        Me.CmbSupplier.TabIndex = 905714
        '
        'DtpTanggalAkhir
        '
        Me.DtpTanggalAkhir.Location = New System.Drawing.Point(231, 13)
        Me.DtpTanggalAkhir.Name = "DtpTanggalAkhir"
        Me.DtpTanggalAkhir.Size = New System.Drawing.Size(101, 22)
        Me.DtpTanggalAkhir.TabIndex = 905713
        '
        'DtpTanggalAwal
        '
        Me.DtpTanggalAwal.Location = New System.Drawing.Point(96, 13)
        Me.DtpTanggalAwal.Name = "DtpTanggalAwal"
        Me.DtpTanggalAwal.Size = New System.Drawing.Size(101, 22)
        Me.DtpTanggalAwal.TabIndex = 905713
        '
        'ChkBelumDibuatAP
        '
        Me.ChkBelumDibuatAP.AutoSize = True
        Me.ChkBelumDibuatAP.Location = New System.Drawing.Point(837, 41)
        Me.ChkBelumDibuatAP.Name = "ChkBelumDibuatAP"
        Me.ChkBelumDibuatAP.Size = New System.Drawing.Size(112, 17)
        Me.ChkBelumDibuatAP.TabIndex = 905712
        Me.ChkBelumDibuatAP.Text = "Belum Dibuat AP"
        Me.ChkBelumDibuatAP.UseVisualStyleBackColor = True
        '
        'ChkBelumComplete
        '
        Me.ChkBelumComplete.AutoSize = True
        Me.ChkBelumComplete.Location = New System.Drawing.Point(723, 41)
        Me.ChkBelumComplete.Name = "ChkBelumComplete"
        Me.ChkBelumComplete.Size = New System.Drawing.Size(107, 17)
        Me.ChkBelumComplete.TabIndex = 905712
        Me.ChkBelumComplete.Text = "Belum Complite"
        Me.ChkBelumComplete.UseVisualStyleBackColor = True
        '
        'ChkApprovalUangMuka
        '
        Me.ChkApprovalUangMuka.AutoSize = True
        Me.ChkApprovalUangMuka.Location = New System.Drawing.Point(836, 17)
        Me.ChkApprovalUangMuka.Name = "ChkApprovalUangMuka"
        Me.ChkApprovalUangMuka.Size = New System.Drawing.Size(147, 17)
        Me.ChkApprovalUangMuka.TabIndex = 905712
        Me.ChkApprovalUangMuka.Text = "Approval && Uang Muka"
        Me.ChkApprovalUangMuka.UseVisualStyleBackColor = True
        '
        'ChkCekKapalByID
        '
        Me.ChkCekKapalByID.AutoSize = True
        Me.ChkCekKapalByID.Location = New System.Drawing.Point(723, 17)
        Me.ChkCekKapalByID.Name = "ChkCekKapalByID"
        Me.ChkCekKapalByID.Size = New System.Drawing.Size(106, 17)
        Me.ChkCekKapalByID.TabIndex = 905712
        Me.ChkCekKapalByID.Text = "Chk Kapal By ID"
        Me.ChkCekKapalByID.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(364, 90)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 13)
        Me.Label9.TabIndex = 905711
        Me.Label9.Text = "Jenis Produk"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 90)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 13)
        Me.Label8.TabIndex = 905711
        Me.Label8.Text = "Sub Supplier"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 905711
        Me.Label6.Text = "Asal KB"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(364, 67)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 905710
        Me.Label7.Text = "No. Nota"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(364, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 905710
        Me.Label5.Text = "Kapal"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 905709
        Me.Label4.Text = "Supplier"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(364, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 905708
        Me.Label3.Text = "Kode Supplier"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(202, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(23, 13)
        Me.Label10.TabIndex = 905707
        Me.Label10.Text = "s/d"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 905707
        Me.Label2.Text = "Tanggal"
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Black
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(1156, 1)
        Me.Panel8.TabIndex = 905706
        '
        'FrmMonPenerimaanKBKg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1156, 592)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FrmMonPenerimaanKBKg"
        Me.Text = "Monitoring Penerimaan Kelapa Timbang"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        CType(Me.fgpricekg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel10.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        CType(Me.fg2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel13.ResumeLayout(False)
        CType(Me.fg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel12.ResumeLayout(False)
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents OptNonOrganik As RadioButton
    Friend WithEvents OptOrganik As RadioButton
    Friend WithEvents OptAllData As RadioButton
    Friend WithEvents TxtNota As TextBox
    Friend WithEvents TxtKodeSupplier As TextBox
    Friend WithEvents CmbKapal As ComboBox
    Friend WithEvents CmbSubSupplier As ComboBox
    Friend WithEvents CmbAsalKB As ComboBox
    Friend WithEvents CmbSupplier As ComboBox
    Friend WithEvents DtpTanggalAkhir As DateTimePicker
    Friend WithEvents DtpTanggalAwal As DateTimePicker
    Friend WithEvents ChkBelumDibuatAP As CheckBox
    Friend WithEvents ChkBelumComplete As CheckBox
    Friend WithEvents ChkApprovalUangMuka As CheckBox
    Friend WithEvents ChkCekKapalByID As CheckBox
    Friend WithEvents Label10 As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents btnConvertButir As Button
    Friend WithEvents btnConvertKg As Button
    Friend WithEvents btnRefreshP1 As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel11 As Panel
    Friend WithEvents fgpricekg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Panel14 As Panel
    Friend WithEvents fg2 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel13 As Panel
    Friend WithEvents fg1 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel12 As Panel
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
End Class
