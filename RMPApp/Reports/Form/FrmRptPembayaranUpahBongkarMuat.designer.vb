<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptPembayaranUpahBongkarMuat
	'Inherits System.Windows.Forms.Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRptPembayaranUpahBongkarMuat))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTrip2 = New System.Windows.Forms.TextBox()
        Me.txtTrip1 = New System.Windows.Forms.TextBox()
        Me.ChkTrip = New System.Windows.Forms.CheckBox()
        Me.chkpontianak = New System.Windows.Forms.CheckBox()
        Me.chkP2 = New System.Windows.Forms.CheckBox()
        Me.chkP1 = New System.Windows.Forms.CheckBox()
        Me.chkTgl = New System.Windows.Forms.CheckBox()
        Me.rdAll = New System.Windows.Forms.RadioButton()
        Me.rdBelumBayar = New System.Windows.Forms.RadioButton()
        Me.chkBank = New System.Windows.Forms.CheckBox()
        Me.chkPancang = New System.Windows.Forms.CheckBox()
        Me.cboJenisBank = New System.Windows.Forms.ComboBox()
        Me.cboPancang = New System.Windows.Forms.ComboBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.dtp2 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnLoaddata = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.txtMinggu = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtTrip2)
        Me.GroupBox1.Controls.Add(Me.txtTrip1)
        Me.GroupBox1.Controls.Add(Me.ChkTrip)
        Me.GroupBox1.Controls.Add(Me.chkpontianak)
        Me.GroupBox1.Controls.Add(Me.chkP2)
        Me.GroupBox1.Controls.Add(Me.chkP1)
        Me.GroupBox1.Controls.Add(Me.chkTgl)
        Me.GroupBox1.Controls.Add(Me.rdAll)
        Me.GroupBox1.Controls.Add(Me.rdBelumBayar)
        Me.GroupBox1.Controls.Add(Me.chkBank)
        Me.GroupBox1.Controls.Add(Me.chkPancang)
        Me.GroupBox1.Controls.Add(Me.cboJenisBank)
        Me.GroupBox1.Controls.Add(Me.cboPancang)
        Me.GroupBox1.Controls.Add(Me.Panel4)
        Me.GroupBox1.Controls.Add(Me.btnLoaddata)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(919, 136)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter Data"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(197, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 13)
        Me.Label2.TabIndex = 80
        Me.Label2.Text = "-"
        '
        'txtTrip2
        '
        Me.txtTrip2.Location = New System.Drawing.Point(207, 109)
        Me.txtTrip2.Name = "txtTrip2"
        Me.txtTrip2.Size = New System.Drawing.Size(120, 20)
        Me.txtTrip2.TabIndex = 79
        '
        'txtTrip1
        '
        Me.txtTrip1.Location = New System.Drawing.Point(77, 109)
        Me.txtTrip1.Name = "txtTrip1"
        Me.txtTrip1.Size = New System.Drawing.Size(120, 20)
        Me.txtTrip1.TabIndex = 79
        '
        'ChkTrip
        '
        Me.ChkTrip.AutoSize = True
        Me.ChkTrip.Location = New System.Drawing.Point(6, 111)
        Me.ChkTrip.Name = "ChkTrip"
        Me.ChkTrip.Size = New System.Drawing.Size(44, 17)
        Me.ChkTrip.TabIndex = 78
        Me.ChkTrip.Text = "Trip"
        Me.ChkTrip.UseVisualStyleBackColor = True
        '
        'chkpontianak
        '
        Me.chkpontianak.AutoSize = True
        Me.chkpontianak.Location = New System.Drawing.Point(819, 15)
        Me.chkpontianak.Name = "chkpontianak"
        Me.chkpontianak.Size = New System.Drawing.Size(94, 17)
        Me.chkpontianak.TabIndex = 77
        Me.chkpontianak.Text = "UM Pontianak"
        Me.chkpontianak.UseVisualStyleBackColor = True
        '
        'chkP2
        '
        Me.chkP2.AutoSize = True
        Me.chkP2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkP2.Location = New System.Drawing.Point(427, 25)
        Me.chkP2.Name = "chkP2"
        Me.chkP2.Size = New System.Drawing.Size(40, 20)
        Me.chkP2.TabIndex = 76
        Me.chkP2.Text = "P2"
        Me.chkP2.UseVisualStyleBackColor = True
        '
        'chkP1
        '
        Me.chkP1.AutoSize = True
        Me.chkP1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkP1.Location = New System.Drawing.Point(380, 25)
        Me.chkP1.Name = "chkP1"
        Me.chkP1.Size = New System.Drawing.Size(40, 20)
        Me.chkP1.TabIndex = 75
        Me.chkP1.Text = "P1"
        Me.chkP1.UseVisualStyleBackColor = True
        '
        'chkTgl
        '
        Me.chkTgl.AutoSize = True
        Me.chkTgl.Location = New System.Drawing.Point(6, 27)
        Me.chkTgl.Name = "chkTgl"
        Me.chkTgl.Size = New System.Drawing.Size(65, 17)
        Me.chkTgl.TabIndex = 73
        Me.chkTgl.Text = "Tanggal"
        Me.chkTgl.UseVisualStyleBackColor = True
        '
        'rdAll
        '
        Me.rdAll.AutoSize = True
        Me.rdAll.Location = New System.Drawing.Point(332, 85)
        Me.rdAll.Name = "rdAll"
        Me.rdAll.Size = New System.Drawing.Size(36, 17)
        Me.rdAll.TabIndex = 72
        Me.rdAll.Text = "All"
        Me.rdAll.UseVisualStyleBackColor = True
        '
        'rdBelumBayar
        '
        Me.rdBelumBayar.AutoSize = True
        Me.rdBelumBayar.Location = New System.Drawing.Point(332, 56)
        Me.rdBelumBayar.Name = "rdBelumBayar"
        Me.rdBelumBayar.Size = New System.Drawing.Size(84, 17)
        Me.rdBelumBayar.TabIndex = 71
        Me.rdBelumBayar.Text = "Belum Bayar"
        Me.rdBelumBayar.UseVisualStyleBackColor = True
        '
        'chkBank
        '
        Me.chkBank.AutoSize = True
        Me.chkBank.Location = New System.Drawing.Point(6, 85)
        Me.chkBank.Name = "chkBank"
        Me.chkBank.Size = New System.Drawing.Size(51, 17)
        Me.chkBank.TabIndex = 70
        Me.chkBank.Text = "Bank"
        Me.chkBank.UseVisualStyleBackColor = True
        '
        'chkPancang
        '
        Me.chkPancang.AutoSize = True
        Me.chkPancang.Location = New System.Drawing.Point(6, 56)
        Me.chkPancang.Name = "chkPancang"
        Me.chkPancang.Size = New System.Drawing.Size(69, 17)
        Me.chkPancang.TabIndex = 69
        Me.chkPancang.Text = "Pancang"
        Me.chkPancang.UseVisualStyleBackColor = True
        '
        'cboJenisBank
        '
        Me.cboJenisBank.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboJenisBank.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboJenisBank.FormattingEnabled = True
        Me.cboJenisBank.Location = New System.Drawing.Point(77, 83)
        Me.cboJenisBank.Name = "cboJenisBank"
        Me.cboJenisBank.Size = New System.Drawing.Size(249, 21)
        Me.cboJenisBank.TabIndex = 68
        '
        'cboPancang
        '
        Me.cboPancang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPancang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPancang.FormattingEnabled = True
        Me.cboPancang.Location = New System.Drawing.Point(77, 54)
        Me.cboPancang.Name = "cboPancang"
        Me.cboPancang.Size = New System.Drawing.Size(249, 21)
        Me.cboPancang.TabIndex = 54
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.dtp1)
        Me.Panel4.Controls.Add(Me.dtp2)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Location = New System.Drawing.Point(77, 21)
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
        Me.btnLoaddata.Location = New System.Drawing.Point(332, 21)
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
        Me.GroupBox2.Location = New System.Drawing.Point(12, 143)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(919, 383)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Data"
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReportViewer1.Location = New System.Drawing.Point(6, 14)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(907, 363)
        Me.ReportViewer1.TabIndex = 0
        '
        'txtMinggu
        '
        Me.txtMinggu.Location = New System.Drawing.Point(892, 99)
        Me.txtMinggu.Name = "txtMinggu"
        Me.txtMinggu.ReadOnly = True
        Me.txtMinggu.Size = New System.Drawing.Size(39, 20)
        Me.txtMinggu.TabIndex = 17
        Me.txtMinggu.Visible = False
        '
        'FrmRptPembayaranUpahBongkarMuat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SkyBlue
        Me.ClientSize = New System.Drawing.Size(943, 538)
        Me.Controls.Add(Me.txtMinggu)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmRptPembayaranUpahBongkarMuat"
        Me.Text = "Report Upah Bongkar Muat (Tambang)"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents dtp1 As DateTimePicker
    Friend WithEvents dtp2 As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents btnLoaddata As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents txtMinggu As TextBox
    Friend WithEvents cboPancang As ComboBox
    Friend WithEvents rdAll As RadioButton
    Friend WithEvents rdBelumBayar As RadioButton
    Friend WithEvents chkBank As CheckBox
    Friend WithEvents chkPancang As CheckBox
    Friend WithEvents cboJenisBank As ComboBox
    Friend WithEvents chkTgl As CheckBox
    Friend WithEvents chkP2 As CheckBox
    Friend WithEvents chkP1 As CheckBox
    Friend WithEvents chkpontianak As CheckBox
    Friend WithEvents ChkTrip As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtTrip2 As TextBox
    Friend WithEvents txtTrip1 As TextBox
End Class
