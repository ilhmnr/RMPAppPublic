<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmRptPembayaranUpahBongkarAll
	'Inherits System.Windows.Forms.Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRptPembayaranUpahBongkarAll))
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbTrip2 = New System.Windows.Forms.ComboBox()
        Me.cmbTrip1 = New System.Windows.Forms.ComboBox()
        Me.chkP2 = New System.Windows.Forms.CheckBox()
        Me.chkP1 = New System.Windows.Forms.CheckBox()
        Me.chkPCG = New System.Windows.Forms.CheckBox()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.rdAll = New System.Windows.Forms.RadioButton()
        Me.rdBelumBayar = New System.Windows.Forms.RadioButton()
        Me.chkTrip = New System.Windows.Forms.CheckBox()
        Me.chkBank = New System.Windows.Forms.CheckBox()
        Me.chkPancang = New System.Windows.Forms.CheckBox()
        Me.chkTgl = New System.Windows.Forms.CheckBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.cboJenisBank = New System.Windows.Forms.ComboBox()
        Me.txtMinggu = New System.Windows.Forms.TextBox()
        Me.cboPancang = New System.Windows.Forms.ComboBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.dtp2 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnLoaddata = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.C1DataViewSet1 = New C1.C1DataExtender.C1DataViewSet()
        Me.GroupBox1.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.C1DataViewSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReportViewer1.Location = New System.Drawing.Point(6, 14)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(1198, 373)
        Me.ReportViewer1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbTrip2)
        Me.GroupBox1.Controls.Add(Me.cmbTrip1)
        Me.GroupBox1.Controls.Add(Me.chkP2)
        Me.GroupBox1.Controls.Add(Me.chkP1)
        Me.GroupBox1.Controls.Add(Me.chkPCG)
        Me.GroupBox1.Controls.Add(Me.fg)
        Me.GroupBox1.Controls.Add(Me.rdAll)
        Me.GroupBox1.Controls.Add(Me.rdBelumBayar)
        Me.GroupBox1.Controls.Add(Me.chkTrip)
        Me.GroupBox1.Controls.Add(Me.chkBank)
        Me.GroupBox1.Controls.Add(Me.chkPancang)
        Me.GroupBox1.Controls.Add(Me.chkTgl)
        Me.GroupBox1.Controls.Add(Me.btnPrint)
        Me.GroupBox1.Controls.Add(Me.cboJenisBank)
        Me.GroupBox1.Controls.Add(Me.txtMinggu)
        Me.GroupBox1.Controls.Add(Me.cboPancang)
        Me.GroupBox1.Controls.Add(Me.Panel4)
        Me.GroupBox1.Controls.Add(Me.btnLoaddata)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1210, 129)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter Data"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(196, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 13)
        Me.Label2.TabIndex = 80
        Me.Label2.Text = "-"
        '
        'cmbTrip2
        '
        Me.cmbTrip2.Enabled = False
        Me.cmbTrip2.FormattingEnabled = True
        Me.cmbTrip2.Location = New System.Drawing.Point(206, 103)
        Me.cmbTrip2.Name = "cmbTrip2"
        Me.cmbTrip2.Size = New System.Drawing.Size(120, 21)
        Me.cmbTrip2.TabIndex = 79
        '
        'cmbTrip1
        '
        Me.cmbTrip1.Enabled = False
        Me.cmbTrip1.FormattingEnabled = True
        Me.cmbTrip1.Location = New System.Drawing.Point(77, 103)
        Me.cmbTrip1.Name = "cmbTrip1"
        Me.cmbTrip1.Size = New System.Drawing.Size(120, 21)
        Me.cmbTrip1.TabIndex = 79
        '
        'chkP2
        '
        Me.chkP2.AutoSize = True
        Me.chkP2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkP2.Location = New System.Drawing.Point(469, 50)
        Me.chkP2.Name = "chkP2"
        Me.chkP2.Size = New System.Drawing.Size(40, 20)
        Me.chkP2.TabIndex = 78
        Me.chkP2.Text = "P2"
        Me.chkP2.UseVisualStyleBackColor = True
        '
        'chkP1
        '
        Me.chkP1.AutoSize = True
        Me.chkP1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkP1.Location = New System.Drawing.Point(422, 50)
        Me.chkP1.Name = "chkP1"
        Me.chkP1.Size = New System.Drawing.Size(40, 20)
        Me.chkP1.TabIndex = 77
        Me.chkP1.Text = "P1"
        Me.chkP1.UseVisualStyleBackColor = True
        '
        'chkPCG
        '
        Me.chkPCG.AutoSize = True
        Me.chkPCG.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPCG.ForeColor = System.Drawing.Color.Maroon
        Me.chkPCG.Location = New System.Drawing.Point(374, 81)
        Me.chkPCG.Name = "chkPCG"
        Me.chkPCG.Size = New System.Drawing.Size(123, 19)
        Me.chkPCG.TabIndex = 68
        Me.chkPCG.Text = "Print Per Pancang"
        Me.chkPCG.UseVisualStyleBackColor = True
        '
        'fg
        '
        Me.fg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fg.ColumnInfo = "2,1,0,0,0,-1,Columns:1{Width:200;Caption:""No Invoice"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.fg.Location = New System.Drawing.Point(674, 19)
        Me.fg.Name = "fg"
        Me.fg.Rows.Count = 4
        Me.fg.Size = New System.Drawing.Size(287, 93)
        Me.fg.TabIndex = 67
        Me.fg.Visible = False
        '
        'rdAll
        '
        Me.rdAll.AutoSize = True
        Me.rdAll.Location = New System.Drawing.Point(332, 80)
        Me.rdAll.Name = "rdAll"
        Me.rdAll.Size = New System.Drawing.Size(36, 17)
        Me.rdAll.TabIndex = 66
        Me.rdAll.Text = "All"
        Me.rdAll.UseVisualStyleBackColor = True
        '
        'rdBelumBayar
        '
        Me.rdBelumBayar.AutoSize = True
        Me.rdBelumBayar.Location = New System.Drawing.Point(332, 51)
        Me.rdBelumBayar.Name = "rdBelumBayar"
        Me.rdBelumBayar.Size = New System.Drawing.Size(84, 17)
        Me.rdBelumBayar.TabIndex = 65
        Me.rdBelumBayar.Text = "Belum Bayar"
        Me.rdBelumBayar.UseVisualStyleBackColor = True
        '
        'chkTrip
        '
        Me.chkTrip.AutoSize = True
        Me.chkTrip.Location = New System.Drawing.Point(6, 105)
        Me.chkTrip.Name = "chkTrip"
        Me.chkTrip.Size = New System.Drawing.Size(44, 17)
        Me.chkTrip.TabIndex = 64
        Me.chkTrip.Text = "Trip"
        Me.chkTrip.UseVisualStyleBackColor = True
        '
        'chkBank
        '
        Me.chkBank.AutoSize = True
        Me.chkBank.Location = New System.Drawing.Point(6, 80)
        Me.chkBank.Name = "chkBank"
        Me.chkBank.Size = New System.Drawing.Size(51, 17)
        Me.chkBank.TabIndex = 64
        Me.chkBank.Text = "Bank"
        Me.chkBank.UseVisualStyleBackColor = True
        '
        'chkPancang
        '
        Me.chkPancang.AutoSize = True
        Me.chkPancang.Location = New System.Drawing.Point(6, 51)
        Me.chkPancang.Name = "chkPancang"
        Me.chkPancang.Size = New System.Drawing.Size(69, 17)
        Me.chkPancang.TabIndex = 63
        Me.chkPancang.Text = "Pancang"
        Me.chkPancang.UseVisualStyleBackColor = True
        '
        'chkTgl
        '
        Me.chkTgl.AutoSize = True
        Me.chkTgl.Location = New System.Drawing.Point(6, 22)
        Me.chkTgl.Name = "chkTgl"
        Me.chkTgl.Size = New System.Drawing.Size(65, 17)
        Me.chkTgl.TabIndex = 62
        Me.chkTgl.Text = "Tanggal"
        Me.chkTgl.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.Color.DarkKhaki
        Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.btnPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Image = Global.RMPApp.My.Resources.Resources.icons8_print_32
        Me.btnPrint.Location = New System.Drawing.Point(380, 15)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(42, 28)
        Me.btnPrint.TabIndex = 61
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'cboJenisBank
        '
        Me.cboJenisBank.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboJenisBank.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboJenisBank.FormattingEnabled = True
        Me.cboJenisBank.Location = New System.Drawing.Point(77, 78)
        Me.cboJenisBank.Name = "cboJenisBank"
        Me.cboJenisBank.Size = New System.Drawing.Size(249, 21)
        Me.cboJenisBank.TabIndex = 58
        '
        'txtMinggu
        '
        Me.txtMinggu.Location = New System.Drawing.Point(1067, 73)
        Me.txtMinggu.Name = "txtMinggu"
        Me.txtMinggu.ReadOnly = True
        Me.txtMinggu.Size = New System.Drawing.Size(39, 20)
        Me.txtMinggu.TabIndex = 16
        Me.txtMinggu.Visible = False
        '
        'cboPancang
        '
        Me.cboPancang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPancang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPancang.FormattingEnabled = True
        Me.cboPancang.Location = New System.Drawing.Point(77, 49)
        Me.cboPancang.Name = "cboPancang"
        Me.cboPancang.Size = New System.Drawing.Size(249, 21)
        Me.cboPancang.TabIndex = 56
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.dtp1)
        Me.Panel4.Controls.Add(Me.dtp2)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Location = New System.Drawing.Point(77, 15)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(249, 28)
        Me.Panel4.TabIndex = 51
        '
        'dtp1
        '
        Me.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp1.Location = New System.Drawing.Point(3, 4)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(104, 20)
        Me.dtp1.TabIndex = 6
        '
        'dtp2
        '
        Me.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp2.Location = New System.Drawing.Point(142, 4)
        Me.dtp2.Name = "dtp2"
        Me.dtp2.Size = New System.Drawing.Size(104, 20)
        Me.dtp2.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(113, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "s/d"
        '
        'btnLoaddata
        '
        Me.btnLoaddata.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.btnLoaddata.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLoaddata.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.btnLoaddata.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.btnLoaddata.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.btnLoaddata.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoaddata.Image = CType(resources.GetObject("btnLoaddata.Image"), System.Drawing.Image)
        Me.btnLoaddata.Location = New System.Drawing.Point(332, 15)
        Me.btnLoaddata.Name = "btnLoaddata"
        Me.btnLoaddata.Size = New System.Drawing.Size(42, 28)
        Me.btnLoaddata.TabIndex = 52
        Me.btnLoaddata.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.ReportViewer1)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 144)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1210, 393)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Data"
        '
        'C1DataViewSet1
        '
        Me.C1DataViewSet1.DiagramXML = ""
        '
        'FrmRptPembayaranUpahBongkarAll
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SkyBlue
        Me.ClientSize = New System.Drawing.Size(1233, 546)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmRptPembayaranUpahBongkarAll"
        Me.Text = "Report Upah Bongkar"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.C1DataViewSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents dtp1 As DateTimePicker
    Friend WithEvents dtp2 As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents btnLoaddata As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtMinggu As TextBox
    Friend WithEvents cboPancang As ComboBox
    Friend WithEvents cboJenisBank As ComboBox
    Friend WithEvents btnPrint As Button
    Friend WithEvents chkBank As CheckBox
    Friend WithEvents chkPancang As CheckBox
    Friend WithEvents chkTgl As CheckBox
    Friend WithEvents C1DataViewSet1 As C1.C1DataExtender.C1DataViewSet
    Friend WithEvents rdAll As RadioButton
    Friend WithEvents rdBelumBayar As RadioButton
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents chkPCG As CheckBox
    Friend WithEvents chkP2 As CheckBox
    Friend WithEvents chkP1 As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbTrip2 As ComboBox
    Friend WithEvents cmbTrip1 As ComboBox
    Friend WithEvents chkTrip As CheckBox
End Class
