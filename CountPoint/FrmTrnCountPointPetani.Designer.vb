<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTrnCountPointPetani
    Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.tmrpoin = New System.Windows.Forms.Timer(Me.components)
        Me.BeratNettoAkhir = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TARRAPERSEN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PANCANG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SUBPETANIID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PENERIMAID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.JENISKELAPA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NONOTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.TRANSDATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.dgvsupplier = New System.Windows.Forms.DataGridView()
        Me.nonota2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.transdate2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JENISKELAPA2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PENERIMAID2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SUBPETANIID2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PANCANG2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TARRAPERSEN2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NETTOAKHIR2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tmrquota = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvList = New System.Windows.Forms.DataGridView()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.tmrtgl = New System.Windows.Forms.Timer(Me.components)
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnHitungAwalBulan = New System.Windows.Forms.Button()
        CType(Me.dgvsupplier, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(313, 71)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(68, 19)
        Me.Button6.TabIndex = 896
        Me.Button6.Text = "Button6"
        Me.Button6.UseVisualStyleBackColor = True
        Me.Button6.Visible = False
        '
        'tmrpoin
        '
        Me.tmrpoin.Interval = 6000
        '
        'BeratNettoAkhir
        '
        Me.BeratNettoAkhir.HeaderText = "NETTO AKHIR"
        Me.BeratNettoAkhir.Name = "BeratNettoAkhir"
        Me.BeratNettoAkhir.Width = 200
        '
        'TARRAPERSEN
        '
        Me.TARRAPERSEN.HeaderText = "TARRAPERSEN"
        Me.TARRAPERSEN.Name = "TARRAPERSEN"
        '
        'PANCANG
        '
        Me.PANCANG.HeaderText = "PANCANG"
        Me.PANCANG.Name = "PANCANG"
        '
        'SUBPETANIID
        '
        Me.SUBPETANIID.HeaderText = "SUBPETANIID"
        Me.SUBPETANIID.Name = "SUBPETANIID"
        '
        'PENERIMAID
        '
        Me.PENERIMAID.HeaderText = "PENERIMAID"
        Me.PENERIMAID.Name = "PENERIMAID"
        '
        'Timer2
        '
        '
        'JENISKELAPA
        '
        Me.JENISKELAPA.HeaderText = "JENISKELAPA"
        Me.JENISKELAPA.Name = "JENISKELAPA"
        '
        'NONOTA
        '
        Me.NONOTA.HeaderText = "NONOTA"
        Me.NONOTA.Name = "NONOTA"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(535, 438)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(35, 23)
        Me.Button5.TabIndex = 895
        Me.Button5.Text = "Button5"
        Me.Button5.UseVisualStyleBackColor = True
        Me.Button5.Visible = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Pink
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button3.Location = New System.Drawing.Point(309, 115)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(51, 26)
        Me.Button3.TabIndex = 893
        Me.Button3.Text = "Selesai"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Pink
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button2.Location = New System.Drawing.Point(193, 115)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(115, 26)
        Me.Button2.TabIndex = 892
        Me.Button2.Text = "UpdateAllSupplier"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Bahnschrift", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Gold
        Me.Label3.Location = New System.Drawing.Point(15, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 16)
        Me.Label3.TabIndex = 891
        Me.Label3.Text = "Date"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(55, 120)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(133, 20)
        Me.DateTimePicker1.TabIndex = 890
        '
        'TRANSDATE
        '
        Me.TRANSDATE.HeaderText = "TRANSDATE"
        Me.TRANSDATE.Name = "TRANSDATE"
        '
        'Timer1
        '
        Me.Timer1.Interval = 2000
        '
        'dgvsupplier
        '
        Me.dgvsupplier.AllowUserToAddRows = False
        Me.dgvsupplier.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dgvsupplier.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(80, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvsupplier.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvsupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvsupplier.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nonota2, Me.transdate2, Me.JENISKELAPA2, Me.PENERIMAID2, Me.SUBPETANIID2, Me.PANCANG2, Me.TARRAPERSEN2, Me.NETTOAKHIR2})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvsupplier.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvsupplier.EnableHeadersVisualStyles = False
        Me.dgvsupplier.Location = New System.Drawing.Point(15, 154)
        Me.dgvsupplier.Name = "dgvsupplier"
        Me.dgvsupplier.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Honeydew
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvsupplier.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvsupplier.RowHeadersVisible = False
        Me.dgvsupplier.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvsupplier.Size = New System.Drawing.Size(813, 122)
        Me.dgvsupplier.TabIndex = 889
        '
        'nonota2
        '
        Me.nonota2.HeaderText = "NONOTA"
        Me.nonota2.Name = "nonota2"
        '
        'transdate2
        '
        Me.transdate2.HeaderText = "TRANSDATE"
        Me.transdate2.Name = "transdate2"
        '
        'JENISKELAPA2
        '
        Me.JENISKELAPA2.HeaderText = "JENISKELAPA"
        Me.JENISKELAPA2.Name = "JENISKELAPA2"
        '
        'PENERIMAID2
        '
        Me.PENERIMAID2.HeaderText = "PENERIMAID"
        Me.PENERIMAID2.Name = "PENERIMAID2"
        '
        'SUBPETANIID2
        '
        Me.SUBPETANIID2.HeaderText = "SUBPETANIID"
        Me.SUBPETANIID2.Name = "SUBPETANIID2"
        '
        'PANCANG2
        '
        Me.PANCANG2.HeaderText = "PANCANG"
        Me.PANCANG2.Name = "PANCANG2"
        '
        'TARRAPERSEN2
        '
        Me.TARRAPERSEN2.HeaderText = "TARRAPERSEN"
        Me.TARRAPERSEN2.Name = "TARRAPERSEN2"
        '
        'NETTOAKHIR2
        '
        Me.NETTOAKHIR2.HeaderText = "NETTO AKHIR"
        Me.NETTOAKHIR2.Name = "NETTOAKHIR2"
        Me.NETTOAKHIR2.Width = 200
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Bahnschrift", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Gold
        Me.Label8.Location = New System.Drawing.Point(60, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(154, 33)
        Me.Label8.TabIndex = 885
        Me.Label8.Text = "Hitung Poin"
        '
        'tmrquota
        '
        Me.tmrquota.Interval = 2000
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.MediumSpringGreen
        Me.Label1.Location = New System.Drawing.Point(109, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 15)
        Me.Label1.TabIndex = 887
        Me.Label1.Text = "Hitung Poin Aktif"
        '
        'dgvList
        '
        Me.dgvList.AllowUserToAddRows = False
        Me.dgvList.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.dgvList.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(80, Byte), Integer))
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NONOTA, Me.TRANSDATE, Me.JENISKELAPA, Me.PENERIMAID, Me.SUBPETANIID, Me.PANCANG, Me.TARRAPERSEN, Me.BeratNettoAkhir})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvList.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgvList.EnableHeadersVisualStyles = False
        Me.dgvList.Location = New System.Drawing.Point(15, 282)
        Me.dgvList.Name = "dgvList"
        Me.dgvList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Honeydew
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvList.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvList.RowHeadersVisible = False
        Me.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvList.Size = New System.Drawing.Size(813, 153)
        Me.dgvList.TabIndex = 882
        '
        'btnsave
        '
        Me.btnsave.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnsave.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsave.Font = New System.Drawing.Font("Gabriola", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsave.ForeColor = System.Drawing.Color.Gold
        Me.btnsave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnsave.Location = New System.Drawing.Point(388, 441)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(112, 35)
        Me.btnsave.TabIndex = 883
        Me.btnsave.Text = "&Hitung Poin"
        Me.btnsave.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnsave.UseVisualStyleBackColor = False
        '
        'tmrtgl
        '
        Me.tmrtgl.Interval = 10000
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Pink
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button4.Location = New System.Drawing.Point(361, 115)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(81, 26)
        Me.Button4.TabIndex = 894
        Me.Button4.Text = "loadsupplier"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.MediumSpringGreen
        Me.Label2.Location = New System.Drawing.Point(674, 447)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 15)
        Me.Label2.TabIndex = 888
        Me.Label2.Text = "Hitung Poin Aktif"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(6, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(54, 44)
        Me.PictureBox1.TabIndex = 886
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Gabriola", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Gold
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(307, 441)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 35)
        Me.Button1.TabIndex = 884
        Me.Button1.Text = "&Load"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnHitungAwalBulan
        '
        Me.btnHitungAwalBulan.Location = New System.Drawing.Point(15, 441)
        Me.btnHitungAwalBulan.Name = "btnHitungAwalBulan"
        Me.btnHitungAwalBulan.Size = New System.Drawing.Size(115, 23)
        Me.btnHitungAwalBulan.TabIndex = 897
        Me.btnHitungAwalBulan.Text = "Hitung Awal Bulan"
        Me.btnHitungAwalBulan.UseVisualStyleBackColor = True
        '
        'FrmTrnCountPointPetani
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(835, 481)
        Me.Controls.Add(Me.btnHitungAwalBulan)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.dgvsupplier)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvList)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "FrmTrnCountPointPetani"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transaksi Count Point Petani"
        CType(Me.dgvsupplier, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button6 As Button
    Friend WithEvents tmrpoin As Timer
    Friend WithEvents BeratNettoAkhir As DataGridViewTextBoxColumn
    Friend WithEvents TARRAPERSEN As DataGridViewTextBoxColumn
    Friend WithEvents PANCANG As DataGridViewTextBoxColumn
    Friend WithEvents SUBPETANIID As DataGridViewTextBoxColumn
    Friend WithEvents PENERIMAID As DataGridViewTextBoxColumn
    Friend WithEvents Timer2 As Timer
    Friend WithEvents JENISKELAPA As DataGridViewTextBoxColumn
    Friend WithEvents NONOTA As DataGridViewTextBoxColumn
    Friend WithEvents Button5 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents TRANSDATE As DataGridViewTextBoxColumn
    Friend WithEvents Timer1 As Timer
    Friend WithEvents dgvsupplier As DataGridView
    Friend WithEvents nonota2 As DataGridViewTextBoxColumn
    Friend WithEvents transdate2 As DataGridViewTextBoxColumn
    Friend WithEvents JENISKELAPA2 As DataGridViewTextBoxColumn
    Friend WithEvents PENERIMAID2 As DataGridViewTextBoxColumn
    Friend WithEvents SUBPETANIID2 As DataGridViewTextBoxColumn
    Friend WithEvents PANCANG2 As DataGridViewTextBoxColumn
    Friend WithEvents TARRAPERSEN2 As DataGridViewTextBoxColumn
    Friend WithEvents NETTOAKHIR2 As DataGridViewTextBoxColumn
    Friend WithEvents Label8 As Label
    Friend WithEvents tmrquota As Timer
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvList As DataGridView
    Friend WithEvents btnsave As Button
    Private WithEvents tmrtgl As Timer
    Friend WithEvents Button4 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents btnHitungAwalBulan As Button
End Class
