<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMonKapalSelesaiPancang
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvList = New System.Windows.Forms.DataGridView()
        Me.No = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TanggalSelesaiTimbang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pancang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Licin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Jambul = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kapal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kapasitas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalRp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbPancang = New System.Windows.Forms.ComboBox()
        Me.chkPancang = New System.Windows.Forms.CheckBox()
        Me.ChkKapal = New System.Windows.Forms.CheckBox()
        Me.cmbKapal = New System.Windows.Forms.ComboBox()
        Me.RdAll = New System.Windows.Forms.RadioButton()
        Me.dtp2 = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btncaridata = New System.Windows.Forms.Button()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.chkTgl = New System.Windows.Forms.CheckBox()
        Me.rdP2 = New System.Windows.Forms.RadioButton()
        Me.rdP1 = New System.Windows.Forms.RadioButton()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvList
        '
        Me.dgvList.AllowUserToAddRows = False
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        Me.dgvList.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvList.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Tai Le", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.No, Me.TanggalSelesaiTimbang, Me.Pancang, Me.Licin, Me.Jambul, Me.Kapal, Me.Kapasitas, Me.TotalRp})
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Tai Le", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvList.DefaultCellStyle = DataGridViewCellStyle19
        Me.dgvList.EnableHeadersVisualStyles = False
        Me.dgvList.Location = New System.Drawing.Point(6, 183)
        Me.dgvList.Name = "dgvList"
        Me.dgvList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Tai Le", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.Honeydew
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvList.RowHeadersDefaultCellStyle = DataGridViewCellStyle20
        Me.dgvList.RowHeadersVisible = False
        Me.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvList.Size = New System.Drawing.Size(1162, 446)
        Me.dgvList.TabIndex = 805
        '
        'No
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.No.DefaultCellStyle = DataGridViewCellStyle13
        Me.No.HeaderText = "No."
        Me.No.Name = "No"
        Me.No.ReadOnly = True
        Me.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.No.Width = 50
        '
        'TanggalSelesaiTimbang
        '
        Me.TanggalSelesaiTimbang.HeaderText = "Tanggal"
        Me.TanggalSelesaiTimbang.Name = "TanggalSelesaiTimbang"
        Me.TanggalSelesaiTimbang.Width = 150
        '
        'Pancang
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.Format = "N0"
        DataGridViewCellStyle14.NullValue = Nothing
        Me.Pancang.DefaultCellStyle = DataGridViewCellStyle14
        Me.Pancang.HeaderText = "Pancang"
        Me.Pancang.Name = "Pancang"
        Me.Pancang.Width = 210
        '
        'Licin
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.Format = "N0"
        Me.Licin.DefaultCellStyle = DataGridViewCellStyle15
        Me.Licin.HeaderText = "Licin"
        Me.Licin.Name = "Licin"
        '
        'Jambul
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.Format = "N0"
        Me.Jambul.DefaultCellStyle = DataGridViewCellStyle16
        Me.Jambul.HeaderText = "Jambul"
        Me.Jambul.Name = "Jambul"
        '
        'Kapal
        '
        Me.Kapal.HeaderText = "Kapal"
        Me.Kapal.Name = "Kapal"
        Me.Kapal.Width = 220
        '
        'Kapasitas
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle17.Format = "N0"
        DataGridViewCellStyle17.NullValue = Nothing
        Me.Kapasitas.DefaultCellStyle = DataGridViewCellStyle17
        Me.Kapasitas.HeaderText = "Kapasitas"
        Me.Kapasitas.Name = "Kapasitas"
        '
        'TotalRp
        '
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle18.Format = "N0"
        Me.TotalRp.DefaultCellStyle = DataGridViewCellStyle18
        Me.TotalRp.HeaderText = "Total Rp"
        Me.TotalRp.Name = "TotalRp"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label8.Location = New System.Drawing.Point(190, 37)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(23, 13)
        Me.Label8.TabIndex = 811
        Me.Label8.Text = "s/d"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GroupBox1.Controls.Add(Me.btnExcel)
        Me.GroupBox1.Controls.Add(Me.cmbPancang)
        Me.GroupBox1.Controls.Add(Me.chkPancang)
        Me.GroupBox1.Controls.Add(Me.ChkKapal)
        Me.GroupBox1.Controls.Add(Me.cmbKapal)
        Me.GroupBox1.Controls.Add(Me.RdAll)
        Me.GroupBox1.Controls.Add(Me.dtp2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btncaridata)
        Me.GroupBox1.Controls.Add(Me.dtp1)
        Me.GroupBox1.Controls.Add(Me.chkTgl)
        Me.GroupBox1.Controls.Add(Me.rdP2)
        Me.GroupBox1.Controls.Add(Me.rdP1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1162, 158)
        Me.GroupBox1.TabIndex = 812
        Me.GroupBox1.TabStop = False
        '
        'cmbPancang
        '
        Me.cmbPancang.BackColor = System.Drawing.Color.White
        Me.cmbPancang.Enabled = False
        Me.cmbPancang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbPancang.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPancang.FormattingEnabled = True
        Me.cmbPancang.IntegralHeight = False
        Me.cmbPancang.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cmbPancang.Location = New System.Drawing.Point(449, 41)
        Me.cmbPancang.Name = "cmbPancang"
        Me.cmbPancang.Size = New System.Drawing.Size(300, 25)
        Me.cmbPancang.TabIndex = 803
        Me.cmbPancang.Text = "13.PANCANG PSG PARIT DAMAI (PENJURU)"
        '
        'chkPancang
        '
        Me.chkPancang.AutoSize = True
        Me.chkPancang.FlatAppearance.BorderSize = 0
        Me.chkPancang.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPancang.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.chkPancang.Location = New System.Drawing.Point(358, 43)
        Me.chkPancang.Name = "chkPancang"
        Me.chkPancang.Size = New System.Drawing.Size(84, 20)
        Me.chkPancang.TabIndex = 804
        Me.chkPancang.Text = "Pancang"
        Me.chkPancang.UseVisualStyleBackColor = True
        '
        'ChkKapal
        '
        Me.ChkKapal.AutoSize = True
        Me.ChkKapal.FlatAppearance.BorderSize = 0
        Me.ChkKapal.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkKapal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ChkKapal.Location = New System.Drawing.Point(10, 85)
        Me.ChkKapal.Name = "ChkKapal"
        Me.ChkKapal.Size = New System.Drawing.Size(65, 20)
        Me.ChkKapal.TabIndex = 802
        Me.ChkKapal.Tag = "1"
        Me.ChkKapal.Text = "Kapal"
        Me.ChkKapal.UseVisualStyleBackColor = True
        '
        'cmbKapal
        '
        Me.cmbKapal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cmbKapal.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbKapal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbKapal.FormattingEnabled = True
        Me.cmbKapal.IntegralHeight = False
        Me.cmbKapal.Location = New System.Drawing.Point(99, 81)
        Me.cmbKapal.Name = "cmbKapal"
        Me.cmbKapal.Size = New System.Drawing.Size(225, 24)
        Me.cmbKapal.TabIndex = 801
        '
        'RdAll
        '
        Me.RdAll.AutoSize = True
        Me.RdAll.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdAll.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.RdAll.Location = New System.Drawing.Point(201, 114)
        Me.RdAll.Name = "RdAll"
        Me.RdAll.Size = New System.Drawing.Size(47, 20)
        Me.RdAll.TabIndex = 800
        Me.RdAll.Text = "ALL"
        Me.RdAll.UseVisualStyleBackColor = True
        '
        'dtp2
        '
        Me.dtp2.CustomFormat = "dd MMM yyyy"
        Me.dtp2.Enabled = False
        Me.dtp2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp2.Location = New System.Drawing.Point(231, 41)
        Me.dtp2.Name = "dtp2"
        Me.dtp2.Size = New System.Drawing.Size(92, 23)
        Me.dtp2.TabIndex = 235
        Me.dtp2.Value = New Date(2019, 4, 9, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(198, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 13)
        Me.Label3.TabIndex = 799
        Me.Label3.Text = "s/d"
        '
        'btncaridata
        '
        Me.btncaridata.BackColor = System.Drawing.SystemColors.Control
        'Me.btncaridata.BackgroundImage = Global.RMPApp.My.Resources.Resources.searchh3
        Me.btncaridata.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncaridata.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btncaridata.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btncaridata.Location = New System.Drawing.Point(763, 42)
        Me.btncaridata.Name = "btncaridata"
        Me.btncaridata.Size = New System.Drawing.Size(74, 24)
        Me.btncaridata.TabIndex = 796
        Me.btncaridata.Text = "Cari Data"
        Me.btncaridata.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btncaridata.UseVisualStyleBackColor = False
        '
        'dtp1
        '
        Me.dtp1.CustomFormat = "dd MMM yyyy"
        Me.dtp1.Enabled = False
        Me.dtp1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp1.Location = New System.Drawing.Point(98, 41)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(92, 23)
        Me.dtp1.TabIndex = 234
        Me.dtp1.Value = New Date(2019, 4, 8, 0, 0, 0, 0)
        '
        'chkTgl
        '
        Me.chkTgl.AutoSize = True
        Me.chkTgl.FlatAppearance.BorderSize = 0
        Me.chkTgl.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTgl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.chkTgl.Location = New System.Drawing.Point(10, 43)
        Me.chkTgl.Name = "chkTgl"
        Me.chkTgl.Size = New System.Drawing.Size(56, 20)
        Me.chkTgl.TabIndex = 233
        Me.chkTgl.Tag = "1"
        Me.chkTgl.Text = "Date"
        Me.chkTgl.UseVisualStyleBackColor = True
        '
        'rdP2
        '
        Me.rdP2.AutoSize = True
        Me.rdP2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdP2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.rdP2.Location = New System.Drawing.Point(150, 114)
        Me.rdP2.Name = "rdP2"
        Me.rdP2.Size = New System.Drawing.Size(39, 20)
        Me.rdP2.TabIndex = 231
        Me.rdP2.Text = "P2"
        Me.rdP2.UseVisualStyleBackColor = True
        '
        'rdP1
        '
        Me.rdP1.AutoSize = True
        Me.rdP1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdP1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.rdP1.Location = New System.Drawing.Point(98, 114)
        Me.rdP1.Name = "rdP1"
        Me.rdP1.Size = New System.Drawing.Size(39, 20)
        Me.rdP1.TabIndex = 230
        Me.rdP1.Text = "P1"
        Me.rdP1.UseVisualStyleBackColor = True
        '
        'btnExcel
        '
        Me.btnExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExcel.BackColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExcel.FlatAppearance.BorderSize = 0
        Me.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcel.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnExcel.Image = Global.RMPApp.My.Resources.Resources.excel
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(1061, 122)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(95, 30)
        Me.btnExcel.TabIndex = 805
        Me.btnExcel.Text = "Excel"
        Me.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcel.UseVisualStyleBackColor = False
        '
        'FrmMonKapalSelesaiPancang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(1177, 641)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dgvList)
        Me.Name = "FrmMonKapalSelesaiPancang"
        Me.Text = "Monitoring Kapal Selesai Pancang"
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvList As DataGridView
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RdAll As RadioButton
    Friend WithEvents dtp2 As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents btncaridata As Button
    Friend WithEvents dtp1 As DateTimePicker
    Friend WithEvents chkTgl As CheckBox
    Friend WithEvents rdP2 As RadioButton
    Friend WithEvents rdP1 As RadioButton
    Friend WithEvents ChkKapal As CheckBox
    Friend WithEvents cmbKapal As ComboBox
    Friend WithEvents cmbPancang As ComboBox
    Friend WithEvents chkPancang As CheckBox
    Friend WithEvents No As DataGridViewTextBoxColumn
    Friend WithEvents TanggalSelesaiTimbang As DataGridViewTextBoxColumn
    Friend WithEvents Pancang As DataGridViewTextBoxColumn
    Friend WithEvents Licin As DataGridViewTextBoxColumn
    Friend WithEvents Jambul As DataGridViewTextBoxColumn
    Friend WithEvents Kapal As DataGridViewTextBoxColumn
    Friend WithEvents Kapasitas As DataGridViewTextBoxColumn
    Friend WithEvents TotalRp As DataGridViewTextBoxColumn
    Friend WithEvents btnExcel As Button
    Friend WithEvents SaveFileDialog As SaveFileDialog
End Class
