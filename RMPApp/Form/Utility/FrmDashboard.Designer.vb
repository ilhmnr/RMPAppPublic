Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmDashboard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDashboard))
        Me.flpDashboard = New System.Windows.Forms.FlowLayoutPanel()
        Me.PanelNota = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.PnlMenungguAccDtl = New System.Windows.Forms.Panel()
        Me.txtMenungguAccLv3 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtMenungguAccLv2 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtMenungguAccLv1 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.PnlProsesPengajuanPergroup = New System.Windows.Forms.Panel()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.pcPengajuan = New LiveChartsCore.SkiaSharpView.WinForms.PieChart()
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PnlProsesNotaPergroup = New System.Windows.Forms.Panel()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.pcNota = New LiveChartsCore.SkiaSharpView.WinForms.PieChart()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.PnlTotalNota = New System.Windows.Forms.Panel()
        Me.txtTotalNota = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PnlTotalNotaIco = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.PnlApproved = New System.Windows.Forms.Panel()
        Me.txtApproved = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.PnlApprovedIco = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PnlMenungguAcc = New System.Windows.Forms.Panel()
        Me.txtMenungguAcc = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PnlMenungguAccIco = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.PnlTotalPengajuan = New System.Windows.Forms.Panel()
        Me.txtTotalPengajuan = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PnlTotalPengajuanIco = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.dtpTglNota = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PnlNotaPembelianIco = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.PnlRankingPancang = New System.Windows.Forms.Panel()
        Me.Panel20 = New System.Windows.Forms.Panel()
        Me.CartesianChart1 = New LiveChartsCore.SkiaSharpView.WinForms.CartesianChart()
        Me.Panel19 = New System.Windows.Forms.Panel()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.rd1HariNP = New System.Windows.Forms.RadioButton()
        Me.rd7HariNP = New System.Windows.Forms.RadioButton()
        Me.rd30HariNP = New System.Windows.Forms.RadioButton()
        Me.flpDashboard.SuspendLayout()
        Me.PanelNota.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.PnlMenungguAccDtl.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.PnlProsesPengajuanPergroup.SuspendLayout()
        Me.Panel17.SuspendLayout()
        Me.Panel18.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.PnlProsesNotaPergroup.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.PnlTotalNota.SuspendLayout()
        Me.PnlTotalNotaIco.SuspendLayout()
        Me.PnlApproved.SuspendLayout()
        Me.PnlApprovedIco.SuspendLayout()
        Me.PnlMenungguAcc.SuspendLayout()
        Me.PnlMenungguAccIco.SuspendLayout()
        Me.PnlTotalPengajuan.SuspendLayout()
        Me.PnlTotalPengajuanIco.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.PnlNotaPembelianIco.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.PnlRankingPancang.SuspendLayout()
        Me.Panel20.SuspendLayout()
        Me.Panel19.SuspendLayout()
        Me.SuspendLayout()
        '
        'flpDashboard
        '
        Me.flpDashboard.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flpDashboard.AutoScroll = True
        Me.flpDashboard.Controls.Add(Me.PanelNota)
        Me.flpDashboard.Controls.Add(Me.Panel7)
        Me.flpDashboard.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpDashboard.Location = New System.Drawing.Point(13, 13)
        Me.flpDashboard.Name = "flpDashboard"
        Me.flpDashboard.Size = New System.Drawing.Size(1087, 641)
        Me.flpDashboard.TabIndex = 1
        Me.flpDashboard.WrapContents = False
        '
        'PanelNota
        '
        Me.PanelNota.Controls.Add(Me.Panel6)
        Me.PanelNota.Controls.Add(Me.Panel5)
        Me.PanelNota.Location = New System.Drawing.Point(3, 3)
        Me.PanelNota.Name = "PanelNota"
        Me.PanelNota.Size = New System.Drawing.Size(1013, 450)
        Me.PanelNota.TabIndex = 2
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Panel8)
        Me.Panel6.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(0, 59)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1013, 391)
        Me.Panel6.TabIndex = 3
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.Panel10)
        Me.Panel8.Controls.Add(Me.Panel2)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(0, 108)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(1013, 283)
        Me.Panel8.TabIndex = 4
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.Panel13)
        Me.Panel10.Controls.Add(Me.Panel11)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel10.Location = New System.Drawing.Point(300, 0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(713, 283)
        Me.Panel10.TabIndex = 0
        '
        'Panel13
        '
        Me.Panel13.Controls.Add(Me.PnlMenungguAccDtl)
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel13.Location = New System.Drawing.Point(300, 0)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Padding = New System.Windows.Forms.Padding(5, 10, 0, 10)
        Me.Panel13.Size = New System.Drawing.Size(413, 283)
        Me.Panel13.TabIndex = 0
        '
        'PnlMenungguAccDtl
        '
        Me.PnlMenungguAccDtl.BackColor = System.Drawing.Color.White
        Me.PnlMenungguAccDtl.Controls.Add(Me.txtMenungguAccLv3)
        Me.PnlMenungguAccDtl.Controls.Add(Me.Label16)
        Me.PnlMenungguAccDtl.Controls.Add(Me.txtMenungguAccLv2)
        Me.PnlMenungguAccDtl.Controls.Add(Me.Label12)
        Me.PnlMenungguAccDtl.Controls.Add(Me.txtMenungguAccLv1)
        Me.PnlMenungguAccDtl.Controls.Add(Me.Label15)
        Me.PnlMenungguAccDtl.Controls.Add(Me.Label11)
        Me.PnlMenungguAccDtl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlMenungguAccDtl.Location = New System.Drawing.Point(5, 10)
        Me.PnlMenungguAccDtl.Name = "PnlMenungguAccDtl"
        Me.PnlMenungguAccDtl.Size = New System.Drawing.Size(408, 263)
        Me.PnlMenungguAccDtl.TabIndex = 0
        '
        'txtMenungguAccLv3
        '
        Me.txtMenungguAccLv3.AutoSize = True
        Me.txtMenungguAccLv3.BackColor = System.Drawing.Color.White
        Me.txtMenungguAccLv3.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMenungguAccLv3.Location = New System.Drawing.Point(227, 134)
        Me.txtMenungguAccLv3.Name = "txtMenungguAccLv3"
        Me.txtMenungguAccLv3.Size = New System.Drawing.Size(33, 19)
        Me.txtMenungguAccLv3.TabIndex = 11
        Me.txtMenungguAccLv3.Text = "000"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.White
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(7, 134)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(193, 19)
        Me.Label16.TabIndex = 12
        Me.Label16.Text = "Approve Level 3 (Manager)"
        '
        'txtMenungguAccLv2
        '
        Me.txtMenungguAccLv2.AutoSize = True
        Me.txtMenungguAccLv2.BackColor = System.Drawing.Color.White
        Me.txtMenungguAccLv2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMenungguAccLv2.Location = New System.Drawing.Point(227, 95)
        Me.txtMenungguAccLv2.Name = "txtMenungguAccLv2"
        Me.txtMenungguAccLv2.Size = New System.Drawing.Size(33, 19)
        Me.txtMenungguAccLv2.TabIndex = 13
        Me.txtMenungguAccLv2.Text = "000"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.White
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(7, 95)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(214, 19)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "Approve Level 2 (KADEP RMD)"
        '
        'txtMenungguAccLv1
        '
        Me.txtMenungguAccLv1.AutoSize = True
        Me.txtMenungguAccLv1.BackColor = System.Drawing.Color.White
        Me.txtMenungguAccLv1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMenungguAccLv1.Location = New System.Drawing.Point(227, 56)
        Me.txtMenungguAccLv1.Name = "txtMenungguAccLv1"
        Me.txtMenungguAccLv1.Size = New System.Drawing.Size(33, 19)
        Me.txtMenungguAccLv1.TabIndex = 15
        Me.txtMenungguAccLv1.Text = "000"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.White
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(7, 56)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(214, 19)
        Me.Label15.TabIndex = 16
        Me.Label15.Text = "Approve Level 1 (Main Admin)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.White
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 6)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(154, 28)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Menunggu Acc"
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.PnlProsesPengajuanPergroup)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel11.Location = New System.Drawing.Point(0, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Padding = New System.Windows.Forms.Padding(5, 10, 5, 10)
        Me.Panel11.Size = New System.Drawing.Size(300, 283)
        Me.Panel11.TabIndex = 0
        '
        'PnlProsesPengajuanPergroup
        '
        Me.PnlProsesPengajuanPergroup.BackColor = System.Drawing.Color.White
        Me.PnlProsesPengajuanPergroup.Controls.Add(Me.Panel17)
        Me.PnlProsesPengajuanPergroup.Controls.Add(Me.Panel18)
        Me.PnlProsesPengajuanPergroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlProsesPengajuanPergroup.Location = New System.Drawing.Point(5, 10)
        Me.PnlProsesPengajuanPergroup.Name = "PnlProsesPengajuanPergroup"
        Me.PnlProsesPengajuanPergroup.Size = New System.Drawing.Size(290, 263)
        Me.PnlProsesPengajuanPergroup.TabIndex = 1
        '
        'Panel17
        '
        Me.Panel17.Controls.Add(Me.pcPengajuan)
        Me.Panel17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel17.Location = New System.Drawing.Point(0, 40)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Size = New System.Drawing.Size(290, 223)
        Me.Panel17.TabIndex = 1
        '
        'pcPengajuan
        '
        Me.pcPengajuan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pcPengajuan.InitialRotation = 0R
        Me.pcPengajuan.IsClockwise = True
        Me.pcPengajuan.Location = New System.Drawing.Point(0, 0)
        Me.pcPengajuan.MaxAngle = 360.0R
        Me.pcPengajuan.MaxValue = Double.NaN
        Me.pcPengajuan.MinValue = 0R
        Me.pcPengajuan.Name = "pcPengajuan"
        Me.pcPengajuan.Size = New System.Drawing.Size(290, 223)
        Me.pcPengajuan.TabIndex = 0
        '
        'Panel18
        '
        Me.Panel18.Controls.Add(Me.Label6)
        Me.Panel18.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel18.Location = New System.Drawing.Point(0, 0)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Size = New System.Drawing.Size(290, 40)
        Me.Panel18.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(269, 28)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Proses Pengajuan Pergroup"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.PnlProsesNotaPergroup)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(0, 10, 5, 10)
        Me.Panel2.Size = New System.Drawing.Size(300, 283)
        Me.Panel2.TabIndex = 0
        '
        'PnlProsesNotaPergroup
        '
        Me.PnlProsesNotaPergroup.BackColor = System.Drawing.Color.White
        Me.PnlProsesNotaPergroup.Controls.Add(Me.Panel15)
        Me.PnlProsesNotaPergroup.Controls.Add(Me.Panel14)
        Me.PnlProsesNotaPergroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlProsesNotaPergroup.Location = New System.Drawing.Point(0, 10)
        Me.PnlProsesNotaPergroup.Name = "PnlProsesNotaPergroup"
        Me.PnlProsesNotaPergroup.Size = New System.Drawing.Size(295, 263)
        Me.PnlProsesNotaPergroup.TabIndex = 0
        '
        'Panel15
        '
        Me.Panel15.Controls.Add(Me.pcNota)
        Me.Panel15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel15.Location = New System.Drawing.Point(0, 40)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(295, 223)
        Me.Panel15.TabIndex = 1
        '
        'pcNota
        '
        Me.pcNota.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pcNota.InitialRotation = 0R
        Me.pcNota.IsClockwise = True
        Me.pcNota.Location = New System.Drawing.Point(0, 0)
        Me.pcNota.MaxAngle = 360.0R
        Me.pcNota.MaxValue = Double.NaN
        Me.pcNota.MinValue = 0R
        Me.pcNota.Name = "pcNota"
        Me.pcNota.Size = New System.Drawing.Size(295, 223)
        Me.pcNota.TabIndex = 0
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.Label5)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel14.Location = New System.Drawing.Point(0, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(295, 40)
        Me.Panel14.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(218, 28)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Proses Nota Pergroup"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 7
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.PnlTotalNota, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PnlApproved, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PnlMenungguAcc, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PnlTotalPengajuan, 2, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1013, 108)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'PnlTotalNota
        '
        Me.PnlTotalNota.BackColor = System.Drawing.Color.White
        Me.PnlTotalNota.Controls.Add(Me.txtTotalNota)
        Me.PnlTotalNota.Controls.Add(Me.Label8)
        Me.PnlTotalNota.Controls.Add(Me.PnlTotalNotaIco)
        Me.PnlTotalNota.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlTotalNota.Location = New System.Drawing.Point(3, 3)
        Me.PnlTotalNota.Name = "PnlTotalNota"
        Me.PnlTotalNota.Size = New System.Drawing.Size(239, 102)
        Me.PnlTotalNota.TabIndex = 7
        '
        'txtTotalNota
        '
        Me.txtTotalNota.AutoSize = True
        Me.txtTotalNota.Font = New System.Drawing.Font("Segoe UI", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNota.Location = New System.Drawing.Point(61, 43)
        Me.txtTotalNota.Name = "txtTotalNota"
        Me.txtTotalNota.Size = New System.Drawing.Size(92, 54)
        Me.txtTotalNota.TabIndex = 2
        Me.txtTotalNota.Text = "000"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(66, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 19)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Total Nota"
        '
        'PnlTotalNotaIco
        '
        Me.PnlTotalNotaIco.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.PnlTotalNotaIco.Controls.Add(Me.Panel12)
        Me.PnlTotalNotaIco.Location = New System.Drawing.Point(20, 20)
        Me.PnlTotalNotaIco.Name = "PnlTotalNotaIco"
        Me.PnlTotalNotaIco.Padding = New System.Windows.Forms.Padding(5)
        Me.PnlTotalNotaIco.Size = New System.Drawing.Size(40, 40)
        Me.PnlTotalNotaIco.TabIndex = 0
        '
        'Panel12
        '
        Me.Panel12.BackgroundImage = CType(resources.GetObject("Panel12.BackgroundImage"), System.Drawing.Image)
        Me.Panel12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel12.Location = New System.Drawing.Point(5, 5)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(30, 30)
        Me.Panel12.TabIndex = 4
        '
        'PnlApproved
        '
        Me.PnlApproved.BackColor = System.Drawing.Color.White
        Me.PnlApproved.Controls.Add(Me.txtApproved)
        Me.PnlApproved.Controls.Add(Me.Label14)
        Me.PnlApproved.Controls.Add(Me.PnlApprovedIco)
        Me.PnlApproved.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlApproved.Location = New System.Drawing.Point(768, 3)
        Me.PnlApproved.Name = "PnlApproved"
        Me.PnlApproved.Size = New System.Drawing.Size(242, 102)
        Me.PnlApproved.TabIndex = 6
        '
        'txtApproved
        '
        Me.txtApproved.AutoSize = True
        Me.txtApproved.Font = New System.Drawing.Font("Segoe UI", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApproved.Location = New System.Drawing.Point(61, 43)
        Me.txtApproved.Name = "txtApproved"
        Me.txtApproved.Size = New System.Drawing.Size(92, 54)
        Me.txtApproved.TabIndex = 2
        Me.txtApproved.Text = "000"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(66, 24)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(77, 19)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Approved"
        '
        'PnlApprovedIco
        '
        Me.PnlApprovedIco.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.PnlApprovedIco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PnlApprovedIco.Controls.Add(Me.Panel3)
        Me.PnlApprovedIco.Location = New System.Drawing.Point(20, 20)
        Me.PnlApprovedIco.Name = "PnlApprovedIco"
        Me.PnlApprovedIco.Padding = New System.Windows.Forms.Padding(5)
        Me.PnlApprovedIco.Size = New System.Drawing.Size(40, 40)
        Me.PnlApprovedIco.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BackgroundImage = CType(resources.GetObject("Panel3.BackgroundImage"), System.Drawing.Image)
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(5, 5)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(30, 30)
        Me.Panel3.TabIndex = 3
        '
        'PnlMenungguAcc
        '
        Me.PnlMenungguAcc.BackColor = System.Drawing.Color.White
        Me.PnlMenungguAcc.Controls.Add(Me.txtMenungguAcc)
        Me.PnlMenungguAcc.Controls.Add(Me.Label10)
        Me.PnlMenungguAcc.Controls.Add(Me.PnlMenungguAccIco)
        Me.PnlMenungguAcc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlMenungguAcc.Location = New System.Drawing.Point(513, 3)
        Me.PnlMenungguAcc.Name = "PnlMenungguAcc"
        Me.PnlMenungguAcc.Size = New System.Drawing.Size(239, 102)
        Me.PnlMenungguAcc.TabIndex = 4
        '
        'txtMenungguAcc
        '
        Me.txtMenungguAcc.AutoSize = True
        Me.txtMenungguAcc.Font = New System.Drawing.Font("Segoe UI", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMenungguAcc.Location = New System.Drawing.Point(61, 43)
        Me.txtMenungguAcc.Name = "txtMenungguAcc"
        Me.txtMenungguAcc.Size = New System.Drawing.Size(92, 54)
        Me.txtMenungguAcc.TabIndex = 2
        Me.txtMenungguAcc.Text = "000"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(66, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(108, 19)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Menunggu Acc"
        '
        'PnlMenungguAccIco
        '
        Me.PnlMenungguAccIco.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.PnlMenungguAccIco.Controls.Add(Me.Panel4)
        Me.PnlMenungguAccIco.Location = New System.Drawing.Point(20, 20)
        Me.PnlMenungguAccIco.Name = "PnlMenungguAccIco"
        Me.PnlMenungguAccIco.Padding = New System.Windows.Forms.Padding(5)
        Me.PnlMenungguAccIco.Size = New System.Drawing.Size(40, 40)
        Me.PnlMenungguAccIco.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.BackgroundImage = CType(resources.GetObject("Panel4.BackgroundImage"), System.Drawing.Image)
        Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(5, 5)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(30, 30)
        Me.Panel4.TabIndex = 5
        '
        'PnlTotalPengajuan
        '
        Me.PnlTotalPengajuan.BackColor = System.Drawing.Color.White
        Me.PnlTotalPengajuan.Controls.Add(Me.txtTotalPengajuan)
        Me.PnlTotalPengajuan.Controls.Add(Me.Label1)
        Me.PnlTotalPengajuan.Controls.Add(Me.PnlTotalPengajuanIco)
        Me.PnlTotalPengajuan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlTotalPengajuan.Location = New System.Drawing.Point(258, 3)
        Me.PnlTotalPengajuan.Name = "PnlTotalPengajuan"
        Me.PnlTotalPengajuan.Size = New System.Drawing.Size(239, 102)
        Me.PnlTotalPengajuan.TabIndex = 0
        '
        'txtTotalPengajuan
        '
        Me.txtTotalPengajuan.AutoSize = True
        Me.txtTotalPengajuan.Font = New System.Drawing.Font("Segoe UI", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPengajuan.Location = New System.Drawing.Point(61, 43)
        Me.txtTotalPengajuan.Name = "txtTotalPengajuan"
        Me.txtTotalPengajuan.Size = New System.Drawing.Size(92, 54)
        Me.txtTotalPengajuan.TabIndex = 2
        Me.txtTotalPengajuan.Text = "000"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(66, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Total Pengajuan"
        '
        'PnlTotalPengajuanIco
        '
        Me.PnlTotalPengajuanIco.BackColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.PnlTotalPengajuanIco.Controls.Add(Me.Panel1)
        Me.PnlTotalPengajuanIco.Location = New System.Drawing.Point(20, 20)
        Me.PnlTotalPengajuanIco.Name = "PnlTotalPengajuanIco"
        Me.PnlTotalPengajuanIco.Padding = New System.Windows.Forms.Padding(5)
        Me.PnlTotalPengajuanIco.Size = New System.Drawing.Size(40, 40)
        Me.PnlTotalPengajuanIco.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(5, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(30, 30)
        Me.Panel1.TabIndex = 4
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.btnRefresh)
        Me.Panel5.Controls.Add(Me.dtpTglNota)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.PnlNotaPembelianIco)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1013, 59)
        Me.Panel5.TabIndex = 3
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRefresh.Location = New System.Drawing.Point(916, 19)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.btnRefresh.Size = New System.Drawing.Size(95, 30)
        Me.btnRefresh.TabIndex = 8
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'dtpTglNota
        '
        Me.dtpTglNota.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpTglNota.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTglNota.Location = New System.Drawing.Point(793, 26)
        Me.dtpTglNota.Name = "dtpTglNota"
        Me.dtpTglNota.Size = New System.Drawing.Size(120, 22)
        Me.dtpTglNota.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(50, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(467, 19)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Rekapitulasi dan status proses nota pembelian kelapa berdasarkan tanggal." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(49, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(163, 28)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Nota Pembelian"
        '
        'PnlNotaPembelianIco
        '
        Me.PnlNotaPembelianIco.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.PnlNotaPembelianIco.Controls.Add(Me.Panel9)
        Me.PnlNotaPembelianIco.Location = New System.Drawing.Point(3, 9)
        Me.PnlNotaPembelianIco.Name = "PnlNotaPembelianIco"
        Me.PnlNotaPembelianIco.Padding = New System.Windows.Forms.Padding(5)
        Me.PnlNotaPembelianIco.Size = New System.Drawing.Size(40, 40)
        Me.PnlNotaPembelianIco.TabIndex = 5
        '
        'Panel9
        '
        Me.Panel9.BackgroundImage = CType(resources.GetObject("Panel9.BackgroundImage"), System.Drawing.Image)
        Me.Panel9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(5, 5)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(30, 30)
        Me.Panel9.TabIndex = 4
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.PnlRankingPancang)
        Me.Panel7.Location = New System.Drawing.Point(3, 459)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.Panel7.Size = New System.Drawing.Size(1013, 399)
        Me.Panel7.TabIndex = 5
        '
        'PnlRankingPancang
        '
        Me.PnlRankingPancang.Controls.Add(Me.Panel20)
        Me.PnlRankingPancang.Controls.Add(Me.Panel19)
        Me.PnlRankingPancang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlRankingPancang.Location = New System.Drawing.Point(0, 0)
        Me.PnlRankingPancang.Name = "PnlRankingPancang"
        Me.PnlRankingPancang.Size = New System.Drawing.Size(1013, 389)
        Me.PnlRankingPancang.TabIndex = 0
        '
        'Panel20
        '
        Me.Panel20.AutoScroll = True
        Me.Panel20.BackColor = System.Drawing.Color.White
        Me.Panel20.Controls.Add(Me.CartesianChart1)
        Me.Panel20.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel20.Location = New System.Drawing.Point(0, 40)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Size = New System.Drawing.Size(1013, 349)
        Me.Panel20.TabIndex = 0
        '
        'CartesianChart1
        '
        Me.CartesianChart1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CartesianChart1.BackColor = System.Drawing.Color.White
        Me.CartesianChart1.Location = New System.Drawing.Point(3, 3)
        Me.CartesianChart1.MatchAxesScreenDataRatio = False
        Me.CartesianChart1.Name = "CartesianChart1"
        Me.CartesianChart1.Size = New System.Drawing.Size(968, 221)
        Me.CartesianChart1.TabIndex = 0
        '
        'Panel19
        '
        Me.Panel19.BackColor = System.Drawing.Color.White
        Me.Panel19.Controls.Add(Me.rd30HariNP)
        Me.Panel19.Controls.Add(Me.rd7HariNP)
        Me.Panel19.Controls.Add(Me.rd1HariNP)
        Me.Panel19.Controls.Add(Me.Label20)
        Me.Panel19.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel19.Location = New System.Drawing.Point(0, 0)
        Me.Panel19.Name = "Panel19"
        Me.Panel19.Size = New System.Drawing.Size(1013, 40)
        Me.Panel19.TabIndex = 0
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(6, 6)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(258, 28)
        Me.Label20.TabIndex = 10
        Me.Label20.Text = "Ranking Nota Perpancang"
        '
        'rd1HariNP
        '
        Me.rd1HariNP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rd1HariNP.AutoSize = True
        Me.rd1HariNP.Checked = True
        Me.rd1HariNP.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rd1HariNP.Location = New System.Drawing.Point(742, 16)
        Me.rd1HariNP.Name = "rd1HariNP"
        Me.rd1HariNP.Size = New System.Drawing.Size(55, 17)
        Me.rd1HariNP.TabIndex = 11
        Me.rd1HariNP.TabStop = True
        Me.rd1HariNP.Text = "1 Hari"
        Me.rd1HariNP.UseVisualStyleBackColor = True
        '
        'rd7HariNP
        '
        Me.rd7HariNP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rd7HariNP.AutoSize = True
        Me.rd7HariNP.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rd7HariNP.Location = New System.Drawing.Point(802, 16)
        Me.rd7HariNP.Name = "rd7HariNP"
        Me.rd7HariNP.Size = New System.Drawing.Size(99, 17)
        Me.rd7HariNP.TabIndex = 11
        Me.rd7HariNP.Text = "7 Hari Terakhir"
        Me.rd7HariNP.UseVisualStyleBackColor = True
        '
        'rd30HariNP
        '
        Me.rd30HariNP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rd30HariNP.AutoSize = True
        Me.rd30HariNP.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rd30HariNP.Location = New System.Drawing.Point(906, 16)
        Me.rd30HariNP.Name = "rd30HariNP"
        Me.rd30HariNP.Size = New System.Drawing.Size(105, 17)
        Me.rd30HariNP.TabIndex = 11
        Me.rd30HariNP.Text = "30 Hari Terakhir"
        Me.rd30HariNP.UseVisualStyleBackColor = True
        '
        'FrmDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1113, 667)
        Me.Controls.Add(Me.flpDashboard)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmDashboard"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.Text = "Dashboard"
        Me.flpDashboard.ResumeLayout(False)
        Me.PanelNota.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.Panel13.ResumeLayout(False)
        Me.PnlMenungguAccDtl.ResumeLayout(False)
        Me.PnlMenungguAccDtl.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.PnlProsesPengajuanPergroup.ResumeLayout(False)
        Me.Panel17.ResumeLayout(False)
        Me.Panel18.ResumeLayout(False)
        Me.Panel18.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.PnlProsesNotaPergroup.ResumeLayout(False)
        Me.Panel15.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.PnlTotalNota.ResumeLayout(False)
        Me.PnlTotalNota.PerformLayout()
        Me.PnlTotalNotaIco.ResumeLayout(False)
        Me.PnlApproved.ResumeLayout(False)
        Me.PnlApproved.PerformLayout()
        Me.PnlApprovedIco.ResumeLayout(False)
        Me.PnlMenungguAcc.ResumeLayout(False)
        Me.PnlMenungguAcc.PerformLayout()
        Me.PnlMenungguAccIco.ResumeLayout(False)
        Me.PnlTotalPengajuan.ResumeLayout(False)
        Me.PnlTotalPengajuan.PerformLayout()
        Me.PnlTotalPengajuanIco.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.PnlNotaPembelianIco.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.PnlRankingPancang.ResumeLayout(False)
        Me.Panel20.ResumeLayout(False)
        Me.Panel19.ResumeLayout(False)
        Me.Panel19.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents flpDashboard As FlowLayoutPanel
    Friend WithEvents PanelNota As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents PnlApproved As Panel
    Friend WithEvents txtApproved As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents PnlApprovedIco As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PnlMenungguAcc As Panel
    Friend WithEvents txtMenungguAcc As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents PnlMenungguAccIco As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents PnlTotalPengajuan As Panel
    Friend WithEvents txtTotalPengajuan As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PnlTotalPengajuanIco As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents PnlNotaPembelianIco As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents dtpTglNota As DateTimePicker
    Friend WithEvents btnRefresh As Button
    Friend WithEvents PnlTotalNota As Panel
    Friend WithEvents txtTotalNota As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents PnlTotalNotaIco As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PnlProsesNotaPergroup As Panel
    Friend WithEvents pcNota As LiveChartsCore.SkiaSharpView.WinForms.PieChart
    Friend WithEvents Panel15 As Panel
    Friend WithEvents Panel14 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel13 As Panel
    Friend WithEvents Panel11 As Panel
    Friend WithEvents PnlProsesPengajuanPergroup As Panel
    Friend WithEvents Panel17 As Panel
    Friend WithEvents pcPengajuan As LiveChartsCore.SkiaSharpView.WinForms.PieChart
    Friend WithEvents Panel18 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents PnlMenungguAccDtl As Panel
    Friend WithEvents txtMenungguAccLv3 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtMenungguAccLv2 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtMenungguAccLv1 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents PnlRankingPancang As Panel
    Friend WithEvents Panel20 As Panel
    Friend WithEvents CartesianChart1 As LiveChartsCore.SkiaSharpView.WinForms.CartesianChart
    Friend WithEvents Panel19 As Panel
    Friend WithEvents Label20 As Label
    Friend WithEvents rd30HariNP As RadioButton
    Friend WithEvents rd7HariNP As RadioButton
    Friend WithEvents rd1HariNP As RadioButton
End Class
