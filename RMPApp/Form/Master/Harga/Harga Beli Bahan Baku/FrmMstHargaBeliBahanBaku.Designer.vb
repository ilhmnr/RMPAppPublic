<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMstHargaBeliBahanBaku
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMstHargaBeliBahanBaku))
        Me.IDPancang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pancang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BTNFIND = New System.Windows.Forms.Button()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtnotrans = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkNotActive = New System.Windows.Forms.CheckBox()
        Me.dtpTgl = New System.Windows.Forms.DateTimePicker()
        Me.cmbGradeSub = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.rdDarat = New System.Windows.Forms.RadioButton()
        Me.cmbBahanBaku = New System.Windows.Forms.ComboBox()
        Me.rdklaut = New System.Windows.Forms.RadioButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbJenisWilayah = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'IDPancang
        '
        Me.IDPancang.HeaderText = "IDPancang"
        Me.IDPancang.Name = "IDPancang"
        '
        'Pancang
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Pancang.DefaultCellStyle = DataGridViewCellStyle1
        Me.Pancang.HeaderText = "Pancang"
        Me.Pancang.Name = "Pancang"
        Me.Pancang.Width = 300
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Panel7)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(869, 40)
        Me.Panel1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(46, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(301, 28)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Master Harga Beli Bahan Baku"
        '
        'Panel7
        '
        Me.Panel7.BackgroundImage = CType(resources.GetObject("Panel7.BackgroundImage"), System.Drawing.Image)
        Me.Panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel7.Location = New System.Drawing.Point(10, 3)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(35, 35)
        Me.Panel7.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel2.Controls.Add(Me.BTNFIND)
        Me.Panel2.Controls.Add(Me.btnclose)
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Controls.Add(Me.btnsave)
        Me.Panel2.Controls.Add(Me.btnEdit)
        Me.Panel2.Controls.Add(Me.btnAdd)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 413)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(869, 40)
        Me.Panel2.TabIndex = 0
        '
        'BTNFIND
        '
        Me.BTNFIND.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BTNFIND.BackColor = System.Drawing.Color.White
        Me.BTNFIND.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BTNFIND.Image = CType(resources.GetObject("BTNFIND.Image"), System.Drawing.Image)
        Me.BTNFIND.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTNFIND.Location = New System.Drawing.Point(10, 5)
        Me.BTNFIND.Name = "BTNFIND"
        Me.BTNFIND.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.BTNFIND.Size = New System.Drawing.Size(75, 30)
        Me.BTNFIND.TabIndex = 12
        Me.BTNFIND.Text = "Find"
        Me.BTNFIND.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTNFIND.UseVisualStyleBackColor = False
        '
        'btnclose
        '
        Me.btnclose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnclose.BackColor = System.Drawing.Color.White
        Me.btnclose.Image = CType(resources.GetObject("btnclose.Image"), System.Drawing.Image)
        Me.btnclose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnclose.Location = New System.Drawing.Point(784, 5)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnclose.Size = New System.Drawing.Size(75, 30)
        Me.btnclose.TabIndex = 11
        Me.btnclose.Text = "Exit"
        Me.btnclose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnclose.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.White
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(708, 5)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Padding = New System.Windows.Forms.Padding(5, 0, 3, 0)
        Me.btnCancel.Size = New System.Drawing.Size(75, 30)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnsave
        '
        Me.btnsave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnsave.BackColor = System.Drawing.Color.White
        Me.btnsave.Image = CType(resources.GetObject("btnsave.Image"), System.Drawing.Image)
        Me.btnsave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnsave.Location = New System.Drawing.Point(632, 5)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnsave.Size = New System.Drawing.Size(75, 30)
        Me.btnsave.TabIndex = 9
        Me.btnsave.Text = "Save"
        Me.btnsave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnsave.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BackColor = System.Drawing.Color.White
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEdit.Location = New System.Drawing.Point(556, 5)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnEdit.Size = New System.Drawing.Size(75, 30)
        Me.btnEdit.TabIndex = 7
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.White
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(480, 5)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnAdd.Size = New System.Drawing.Size(75, 30)
        Me.btnAdd.TabIndex = 6
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel6)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 40)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(869, 373)
        Me.Panel3.TabIndex = 0
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.fg)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(0, 111)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Padding = New System.Windows.Forms.Padding(10, 0, 10, 10)
        Me.Panel6.Size = New System.Drawing.Size(869, 262)
        Me.Panel6.TabIndex = 905596
        '
        'fg
        '
        Me.fg.ColumnInfo = "1,1,0,0,0,-1,Columns:0{Name:""No"";Caption:""No"";Style:""TextAlign:LeftCenter;"";Style" &
    "Fixed:""TextAlign:CenterCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fg.Location = New System.Drawing.Point(10, 0)
        Me.fg.Name = "fg"
        Me.fg.Rows.Count = 1
        Me.fg.Size = New System.Drawing.Size(849, 252)
        Me.fg.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.cmbJenisWilayah)
        Me.Panel5.Controls.Add(Me.Panel8)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.txtnotrans)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Controls.Add(Me.chkNotActive)
        Me.Panel5.Controls.Add(Me.dtpTgl)
        Me.Panel5.Controls.Add(Me.cmbGradeSub)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.rdDarat)
        Me.Panel5.Controls.Add(Me.cmbBahanBaku)
        Me.Panel5.Controls.Add(Me.rdklaut)
        Me.Panel5.Controls.Add(Me.Label10)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(869, 111)
        Me.Panel5.TabIndex = 905596
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Black
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(869, 1)
        Me.Panel8.TabIndex = 905704
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label8.Location = New System.Drawing.Point(12, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(93, 17)
        Me.Label8.TabIndex = 905603
        Me.Label8.Text = "No Trans Level"
        '
        'txtnotrans
        '
        Me.txtnotrans.Location = New System.Drawing.Point(111, 10)
        Me.txtnotrans.Name = "txtnotrans"
        Me.txtnotrans.ReadOnly = True
        Me.txtnotrans.Size = New System.Drawing.Size(197, 20)
        Me.txtnotrans.TabIndex = 905618
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(12, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 17)
        Me.Label1.TabIndex = 905604
        Me.Label1.Text = "Tanggal"
        '
        'chkNotActive
        '
        Me.chkNotActive.AutoSize = True
        Me.chkNotActive.Location = New System.Drawing.Point(436, 59)
        Me.chkNotActive.Name = "chkNotActive"
        Me.chkNotActive.Size = New System.Drawing.Size(76, 17)
        Me.chkNotActive.TabIndex = 905617
        Me.chkNotActive.Text = "Not Active"
        Me.chkNotActive.UseVisualStyleBackColor = True
        '
        'dtpTgl
        '
        Me.dtpTgl.CalendarForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.dtpTgl.CalendarTitleBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dtpTgl.CalendarTitleForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dtpTgl.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTgl.Location = New System.Drawing.Point(111, 33)
        Me.dtpTgl.Name = "dtpTgl"
        Me.dtpTgl.Size = New System.Drawing.Size(197, 20)
        Me.dtpTgl.TabIndex = 905605
        '
        'cmbGradeSub
        '
        Me.cmbGradeSub.FormattingEnabled = True
        Me.cmbGradeSub.Location = New System.Drawing.Point(111, 80)
        Me.cmbGradeSub.Name = "cmbGradeSub"
        Me.cmbGradeSub.Size = New System.Drawing.Size(197, 21)
        Me.cmbGradeSub.TabIndex = 905616
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(12, 82)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 17)
        Me.Label5.TabIndex = 905614
        Me.Label5.Text = "GradeSub"
        '
        'rdDarat
        '
        Me.rdDarat.AutoSize = True
        Me.rdDarat.Checked = True
        Me.rdDarat.Location = New System.Drawing.Point(436, 35)
        Me.rdDarat.Name = "rdDarat"
        Me.rdDarat.Size = New System.Drawing.Size(51, 17)
        Me.rdDarat.TabIndex = 905609
        Me.rdDarat.TabStop = True
        Me.rdDarat.Text = "Darat"
        Me.rdDarat.UseVisualStyleBackColor = True
        '
        'cmbBahanBaku
        '
        Me.cmbBahanBaku.FormattingEnabled = True
        Me.cmbBahanBaku.Location = New System.Drawing.Point(111, 56)
        Me.cmbBahanBaku.Name = "cmbBahanBaku"
        Me.cmbBahanBaku.Size = New System.Drawing.Size(197, 21)
        Me.cmbBahanBaku.TabIndex = 905613
        '
        'rdklaut
        '
        Me.rdklaut.AutoSize = True
        Me.rdklaut.Location = New System.Drawing.Point(493, 35)
        Me.rdklaut.Name = "rdklaut"
        Me.rdklaut.Size = New System.Drawing.Size(46, 17)
        Me.rdklaut.TabIndex = 905610
        Me.rdklaut.Text = "Laut"
        Me.rdklaut.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label10.Location = New System.Drawing.Point(12, 58)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(76, 17)
        Me.Label10.TabIndex = 905611
        Me.Label10.Text = "Bahan Baku"
        '
        'cmbJenisWilayah
        '
        Me.cmbJenisWilayah.FormattingEnabled = True
        Me.cmbJenisWilayah.Location = New System.Drawing.Point(436, 10)
        Me.cmbJenisWilayah.Name = "cmbJenisWilayah"
        Me.cmbJenisWilayah.Size = New System.Drawing.Size(197, 21)
        Me.cmbJenisWilayah.TabIndex = 905705
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(342, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 17)
        Me.Label3.TabIndex = 905706
        Me.Label3.Text = "Jenis Wilayah"
        '
        'FrmMstHargaBeliBahanBaku
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(869, 453)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmMstHargaBeliBahanBaku"
        Me.Text = "Master Harga Beli Bahan Baku"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents IDPancang As DataGridViewTextBoxColumn
    Friend WithEvents Pancang As DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents txtnotrans As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents chkNotActive As CheckBox
    Friend WithEvents dtpTgl As DateTimePicker
    Friend WithEvents cmbGradeSub As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents rdDarat As RadioButton
    Friend WithEvents cmbBahanBaku As ComboBox
    Friend WithEvents rdklaut As RadioButton
    Friend WithEvents Label10 As Label
    Friend WithEvents btnclose As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnsave As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents BTNFIND As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbJenisWilayah As ComboBox
End Class
