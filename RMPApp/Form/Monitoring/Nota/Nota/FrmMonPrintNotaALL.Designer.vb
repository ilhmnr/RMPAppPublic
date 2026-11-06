<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMonPrintNotaALL
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMonPrintNotaALL))
        Me.grpDataTimbangPancang = New XanderUI.XUICustomGroupbox()
        Me.rdSelainBNI = New System.Windows.Forms.RadioButton()
        Me.rdBNI = New System.Windows.Forms.RadioButton()
        Me.rdAllBank = New System.Windows.Forms.RadioButton()
        Me.chkUM = New System.Windows.Forms.CheckBox()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.No = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoNota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pancang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kapal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TransID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.dtp2 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkTrip = New System.Windows.Forms.CheckBox()
        Me.chkKapal = New System.Windows.Forms.CheckBox()
        Me.chkPancang = New System.Windows.Forms.CheckBox()
        Me.chkTgl = New System.Windows.Forms.CheckBox()
        Me.txtTrip = New System.Windows.Forms.TextBox()
        Me.cboKPL = New System.Windows.Forms.ComboBox()
        Me.cboPCG = New System.Windows.Forms.ComboBox()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.XuiCustomGroupbox1 = New XanderUI.XUICustomGroupbox()
        Me.ReportViewer = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.grpDataTimbangPancang.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XuiCustomGroupbox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpDataTimbangPancang
        '
        Me.grpDataTimbangPancang.BackColor = System.Drawing.Color.LightSkyBlue
        Me.grpDataTimbangPancang.BorderColor = System.Drawing.Color.Black
        Me.grpDataTimbangPancang.BorderWidth = 1
        Me.grpDataTimbangPancang.Controls.Add(Me.rdSelainBNI)
        Me.grpDataTimbangPancang.Controls.Add(Me.rdBNI)
        Me.grpDataTimbangPancang.Controls.Add(Me.rdAllBank)
        Me.grpDataTimbangPancang.Controls.Add(Me.chkUM)
        Me.grpDataTimbangPancang.Controls.Add(Me.dgv)
        Me.grpDataTimbangPancang.Controls.Add(Me.btnClose)
        Me.grpDataTimbangPancang.Controls.Add(Me.btnCancel)
        Me.grpDataTimbangPancang.Controls.Add(Me.btnPrint)
        Me.grpDataTimbangPancang.Controls.Add(Me.btnRefresh)
        Me.grpDataTimbangPancang.Controls.Add(Me.dtp2)
        Me.grpDataTimbangPancang.Controls.Add(Me.Label1)
        Me.grpDataTimbangPancang.Controls.Add(Me.chkTrip)
        Me.grpDataTimbangPancang.Controls.Add(Me.chkKapal)
        Me.grpDataTimbangPancang.Controls.Add(Me.chkPancang)
        Me.grpDataTimbangPancang.Controls.Add(Me.chkTgl)
        Me.grpDataTimbangPancang.Controls.Add(Me.txtTrip)
        Me.grpDataTimbangPancang.Controls.Add(Me.cboKPL)
        Me.grpDataTimbangPancang.Controls.Add(Me.cboPCG)
        Me.grpDataTimbangPancang.Controls.Add(Me.dtp1)
        Me.grpDataTimbangPancang.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpDataTimbangPancang.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDataTimbangPancang.Location = New System.Drawing.Point(0, 0)
        Me.grpDataTimbangPancang.Name = "grpDataTimbangPancang"
        Me.grpDataTimbangPancang.ShowText = True
        Me.grpDataTimbangPancang.Size = New System.Drawing.Size(1370, 207)
        Me.grpDataTimbangPancang.TabIndex = 98
        Me.grpDataTimbangPancang.TabStop = False
        Me.grpDataTimbangPancang.Text = "List Nota"
        Me.grpDataTimbangPancang.TextColor = System.Drawing.Color.Black
        '
        'rdSelainBNI
        '
        Me.rdSelainBNI.AutoSize = True
        Me.rdSelainBNI.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdSelainBNI.ForeColor = System.Drawing.Color.DarkBlue
        Me.rdSelainBNI.Location = New System.Drawing.Point(236, 138)
        Me.rdSelainBNI.Name = "rdSelainBNI"
        Me.rdSelainBNI.Size = New System.Drawing.Size(83, 20)
        Me.rdSelainBNI.TabIndex = 259
        Me.rdSelainBNI.Text = "Selain BNI"
        Me.rdSelainBNI.UseVisualStyleBackColor = True
        '
        'rdBNI
        '
        Me.rdBNI.AutoSize = True
        Me.rdBNI.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdBNI.ForeColor = System.Drawing.Color.DarkBlue
        Me.rdBNI.Location = New System.Drawing.Point(184, 138)
        Me.rdBNI.Name = "rdBNI"
        Me.rdBNI.Size = New System.Drawing.Size(45, 20)
        Me.rdBNI.TabIndex = 258
        Me.rdBNI.Text = "BNI"
        Me.rdBNI.UseVisualStyleBackColor = True
        '
        'rdAllBank
        '
        Me.rdAllBank.AutoSize = True
        Me.rdAllBank.Checked = True
        Me.rdAllBank.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdAllBank.ForeColor = System.Drawing.Color.DarkBlue
        Me.rdAllBank.Location = New System.Drawing.Point(105, 138)
        Me.rdAllBank.Name = "rdAllBank"
        Me.rdAllBank.Size = New System.Drawing.Size(72, 20)
        Me.rdAllBank.TabIndex = 257
        Me.rdAllBank.TabStop = True
        Me.rdAllBank.Text = "All Bank"
        Me.rdAllBank.UseVisualStyleBackColor = True
        '
        'chkUM
        '
        Me.chkUM.AutoSize = True
        Me.chkUM.BackColor = System.Drawing.Color.LightSkyBlue
        Me.chkUM.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkUM.ForeColor = System.Drawing.Color.Maroon
        Me.chkUM.Location = New System.Drawing.Point(214, 112)
        Me.chkUM.Name = "chkUM"
        Me.chkUM.Size = New System.Drawing.Size(84, 20)
        Me.chkUM.TabIndex = 188
        Me.chkUM.Text = "Sudah UM"
        Me.chkUM.UseVisualStyleBackColor = False
        '
        'dgv
        '
        Me.dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.OliveDrab
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv.ColumnHeadersHeight = 30
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.No, Me.NoNota, Me.Pancang, Me.Kapal, Me.Total, Me.TransID})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Moccasin
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgv.EnableHeadersVisualStyles = False
        Me.dgv.Location = New System.Drawing.Point(338, 20)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgv.RowHeadersVisible = False
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(1026, 181)
        Me.dgv.TabIndex = 186
        '
        'No
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.No.DefaultCellStyle = DataGridViewCellStyle3
        Me.No.HeaderText = "No"
        Me.No.Name = "No"
        Me.No.ReadOnly = True
        Me.No.Width = 51
        '
        'NoNota
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.NoNota.DefaultCellStyle = DataGridViewCellStyle4
        Me.NoNota.HeaderText = "No Nota"
        Me.NoNota.Name = "NoNota"
        Me.NoNota.ReadOnly = True
        Me.NoNota.Width = 88
        '
        'Pancang
        '
        Me.Pancang.HeaderText = "Pancang"
        Me.Pancang.Name = "Pancang"
        Me.Pancang.ReadOnly = True
        Me.Pancang.Width = 91
        '
        'Kapal
        '
        Me.Kapal.HeaderText = "Kapal"
        Me.Kapal.Name = "Kapal"
        Me.Kapal.ReadOnly = True
        Me.Kapal.Width = 70
        '
        'Total
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Total.DefaultCellStyle = DataGridViewCellStyle5
        Me.Total.HeaderText = "Total Rupiah"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        Me.Total.Width = 112
        '
        'TransID
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.TransID.DefaultCellStyle = DataGridViewCellStyle6
        Me.TransID.HeaderText = "Trans ID"
        Me.TransID.Name = "TransID"
        Me.TransID.ReadOnly = True
        Me.TransID.Width = 80
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.Tomato
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnClose.Image = Global.RMPApp.My.Resources.Resources.Cancel
        Me.btnClose.Location = New System.Drawing.Point(282, 174)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(50, 27)
        Me.btnClose.TabIndex = 185
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.OliveDrab
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnCancel.Location = New System.Drawing.Point(226, 174)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(50, 27)
        Me.btnCancel.TabIndex = 184
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.BackColor = System.Drawing.Color.OliveDrab
        Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrint.FlatAppearance.BorderSize = 0
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPrint.Image = Global.RMPApp.My.Resources.Resources.PRINTF1
        Me.btnPrint.Location = New System.Drawing.Point(170, 174)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(50, 27)
        Me.btnPrint.TabIndex = 183
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.OliveDrab
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnRefresh.Image = Global.RMPApp.My.Resources.Resources.Refresh
        Me.btnRefresh.Location = New System.Drawing.Point(114, 174)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(50, 27)
        Me.btnRefresh.TabIndex = 182
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'dtp2
        '
        Me.dtp2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp2.Location = New System.Drawing.Point(232, 20)
        Me.dtp2.Name = "dtp2"
        Me.dtp2.Size = New System.Drawing.Size(100, 22)
        Me.dtp2.TabIndex = 181
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Label1.Font = New System.Drawing.Font("Comic Sans MS", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(211, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 16)
        Me.Label1.TabIndex = 180
        Me.Label1.Text = "-"
        '
        'chkTrip
        '
        Me.chkTrip.AutoSize = True
        Me.chkTrip.BackColor = System.Drawing.Color.LightSkyBlue
        Me.chkTrip.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTrip.Location = New System.Drawing.Point(12, 112)
        Me.chkTrip.Name = "chkTrip"
        Me.chkTrip.Size = New System.Drawing.Size(47, 20)
        Me.chkTrip.TabIndex = 179
        Me.chkTrip.Text = "Trip"
        Me.chkTrip.UseVisualStyleBackColor = False
        '
        'chkKapal
        '
        Me.chkKapal.AutoSize = True
        Me.chkKapal.BackColor = System.Drawing.Color.LightSkyBlue
        Me.chkKapal.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkKapal.Location = New System.Drawing.Point(12, 81)
        Me.chkKapal.Name = "chkKapal"
        Me.chkKapal.Size = New System.Drawing.Size(60, 20)
        Me.chkKapal.TabIndex = 178
        Me.chkKapal.Text = "Kapal"
        Me.chkKapal.UseVisualStyleBackColor = False
        '
        'chkPancang
        '
        Me.chkPancang.AutoSize = True
        Me.chkPancang.BackColor = System.Drawing.Color.LightSkyBlue
        Me.chkPancang.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPancang.Location = New System.Drawing.Point(12, 50)
        Me.chkPancang.Name = "chkPancang"
        Me.chkPancang.Size = New System.Drawing.Size(79, 20)
        Me.chkPancang.TabIndex = 177
        Me.chkPancang.Text = "Pancang"
        Me.chkPancang.UseVisualStyleBackColor = False
        '
        'chkTgl
        '
        Me.chkTgl.AutoSize = True
        Me.chkTgl.BackColor = System.Drawing.Color.LightSkyBlue
        Me.chkTgl.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTgl.Location = New System.Drawing.Point(12, 22)
        Me.chkTgl.Name = "chkTgl"
        Me.chkTgl.Size = New System.Drawing.Size(86, 20)
        Me.chkTgl.TabIndex = 176
        Me.chkTgl.Text = "Trans Date"
        Me.chkTgl.UseVisualStyleBackColor = False
        '
        'txtTrip
        '
        Me.txtTrip.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTrip.Location = New System.Drawing.Point(105, 110)
        Me.txtTrip.Name = "txtTrip"
        Me.txtTrip.Size = New System.Drawing.Size(100, 22)
        Me.txtTrip.TabIndex = 175
        '
        'cboKPL
        '
        Me.cboKPL.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboKPL.FormattingEnabled = True
        Me.cboKPL.Location = New System.Drawing.Point(105, 79)
        Me.cboKPL.Name = "cboKPL"
        Me.cboKPL.Size = New System.Drawing.Size(227, 25)
        Me.cboKPL.TabIndex = 174
        '
        'cboPCG
        '
        Me.cboPCG.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPCG.FormattingEnabled = True
        Me.cboPCG.Location = New System.Drawing.Point(105, 48)
        Me.cboPCG.Name = "cboPCG"
        Me.cboPCG.Size = New System.Drawing.Size(227, 25)
        Me.cboPCG.TabIndex = 173
        '
        'dtp1
        '
        Me.dtp1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp1.Location = New System.Drawing.Point(105, 20)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(100, 22)
        Me.dtp1.TabIndex = 172
        '
        'XuiCustomGroupbox1
        '
        Me.XuiCustomGroupbox1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.XuiCustomGroupbox1.BorderColor = System.Drawing.Color.Black
        Me.XuiCustomGroupbox1.BorderWidth = 1
        Me.XuiCustomGroupbox1.Controls.Add(Me.ReportViewer)
        Me.XuiCustomGroupbox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XuiCustomGroupbox1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XuiCustomGroupbox1.Location = New System.Drawing.Point(0, 207)
        Me.XuiCustomGroupbox1.Name = "XuiCustomGroupbox1"
        Me.XuiCustomGroupbox1.ShowText = True
        Me.XuiCustomGroupbox1.Size = New System.Drawing.Size(1370, 498)
        Me.XuiCustomGroupbox1.TabIndex = 99
        Me.XuiCustomGroupbox1.TabStop = False
        Me.XuiCustomGroupbox1.Text = "Nota Pancang"
        Me.XuiCustomGroupbox1.TextColor = System.Drawing.Color.Black
        '
        'ReportViewer
        '
        Me.ReportViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer.Location = New System.Drawing.Point(3, 19)
        Me.ReportViewer.Name = "ReportViewer"
        Me.ReportViewer.ServerReport.BearerToken = Nothing
        Me.ReportViewer.Size = New System.Drawing.Size(1364, 476)
        Me.ReportViewer.TabIndex = 172
        '
        'FrmMonPrintNotaALL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1370, 705)
        Me.Controls.Add(Me.XuiCustomGroupbox1)
        Me.Controls.Add(Me.grpDataTimbangPancang)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmMonPrintNotaALL"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Print Nota"
        Me.grpDataTimbangPancang.ResumeLayout(False)
        Me.grpDataTimbangPancang.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XuiCustomGroupbox1.ResumeLayout(False)
        Me.XuiCustomGroupbox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grpDataTimbangPancang As XanderUI.XUICustomGroupbox
    Friend WithEvents XuiCustomGroupbox1 As XanderUI.XUICustomGroupbox
    Friend WithEvents ReportViewer As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dtp2 As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents chkTrip As CheckBox
    Friend WithEvents chkKapal As CheckBox
    Friend WithEvents chkPancang As CheckBox
    Friend WithEvents chkTgl As CheckBox
    Friend WithEvents txtTrip As TextBox
    Friend WithEvents cboKPL As ComboBox
    Friend WithEvents cboPCG As ComboBox
    Friend WithEvents dtp1 As DateTimePicker
    Friend WithEvents dgv As DataGridView
    Friend WithEvents btnClose As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents No As DataGridViewTextBoxColumn
    Friend WithEvents NoNota As DataGridViewTextBoxColumn
    Friend WithEvents Pancang As DataGridViewTextBoxColumn
    Friend WithEvents Kapal As DataGridViewTextBoxColumn
    Friend WithEvents Total As DataGridViewTextBoxColumn
    Friend WithEvents TransID As DataGridViewTextBoxColumn
    Friend WithEvents chkUM As CheckBox
    Friend WithEvents rdSelainBNI As RadioButton
    Friend WithEvents rdBNI As RadioButton
    Friend WithEvents rdAllBank As RadioButton
End Class
