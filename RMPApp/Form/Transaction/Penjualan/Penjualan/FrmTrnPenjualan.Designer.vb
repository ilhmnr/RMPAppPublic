Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTrnPenjualan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTrnPenjualan))
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnAddParigi = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.txtTrip = New System.Windows.Forms.TextBox()
        Me.txtNoTrans = New System.Windows.Forms.TextBox()
        Me.cboKapal = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboPancang = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.dtpTanggalPenjualan1 = New System.Windows.Forms.DateTimePicker()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.dtpTanggalPenjualan2 = New System.Windows.Forms.DateTimePicker()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.rdAllTujuan = New System.Windows.Forms.RadioButton()
        Me.rdPSG = New System.Windows.Forms.RadioButton()
        Me.rdCustomer = New System.Windows.Forms.RadioButton()
        Me.rdRSUP = New System.Windows.Forms.RadioButton()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel3.Controls.Add(Me.btnAdd)
        Me.Panel3.Controls.Add(Me.btnAddParigi)
        Me.Panel3.Controls.Add(Me.btnClose)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 523)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Panel3.Size = New System.Drawing.Size(1157, 40)
        Me.Panel3.TabIndex = 2
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.White
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(898, 5)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnAdd.Size = New System.Drawing.Size(75, 30)
        Me.btnAdd.TabIndex = 905667
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnAddParigi
        '
        Me.btnAddParigi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddParigi.BackColor = System.Drawing.Color.White
        Me.btnAddParigi.Image = CType(resources.GetObject("btnAddParigi.Image"), System.Drawing.Image)
        Me.btnAddParigi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAddParigi.Location = New System.Drawing.Point(973, 5)
        Me.btnAddParigi.Name = "btnAddParigi"
        Me.btnAddParigi.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnAddParigi.Size = New System.Drawing.Size(99, 30)
        Me.btnAddParigi.TabIndex = 905666
        Me.btnAddParigi.Text = "Add Parigi"
        Me.btnAddParigi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAddParigi.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.White
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(1072, 5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnClose.Size = New System.Drawing.Size(75, 30)
        Me.btnClose.TabIndex = 905665
        Me.btnClose.Text = "Exit"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 40)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1157, 563)
        Me.Panel2.TabIndex = 3
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.fg)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 94)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(10, 0, 10, 10)
        Me.Panel5.Size = New System.Drawing.Size(1157, 429)
        Me.Panel5.TabIndex = 5
        '
        'fg
        '
        Me.fg.ColumnInfo = resources.GetString("fg.ColumnInfo")
        Me.fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fg.Location = New System.Drawing.Point(10, 0)
        Me.fg.Name = "fg"
        Me.fg.Rows.Count = 1
        Me.fg.Size = New System.Drawing.Size(1137, 419)
        Me.fg.TabIndex = 4
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Panel9)
        Me.Panel4.Controls.Add(Me.btnRefresh)
        Me.Panel4.Controls.Add(Me.txtTrip)
        Me.Panel4.Controls.Add(Me.txtNoTrans)
        Me.Panel4.Controls.Add(Me.cboKapal)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.cboPancang)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.Label18)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.Label19)
        Me.Panel4.Controls.Add(Me.dtpTanggalPenjualan1)
        Me.Panel4.Controls.Add(Me.Label20)
        Me.Panel4.Controls.Add(Me.dtpTanggalPenjualan2)
        Me.Panel4.Controls.Add(Me.Panel15)
        Me.Panel4.Controls.Add(Me.Label25)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1157, 94)
        Me.Panel4.TabIndex = 4
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.Black
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(1157, 1)
        Me.Panel9.TabIndex = 905738
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.White
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRefresh.Location = New System.Drawing.Point(754, 55)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnRefresh.Size = New System.Drawing.Size(75, 30)
        Me.btnRefresh.TabIndex = 905707
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'txtTrip
        '
        Me.txtTrip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTrip.Location = New System.Drawing.Point(446, 10)
        Me.txtTrip.Name = "txtTrip"
        Me.txtTrip.Size = New System.Drawing.Size(75, 20)
        Me.txtTrip.TabIndex = 905698
        '
        'txtNoTrans
        '
        Me.txtNoTrans.Location = New System.Drawing.Point(104, 10)
        Me.txtNoTrans.Name = "txtNoTrans"
        Me.txtNoTrans.Size = New System.Drawing.Size(227, 20)
        Me.txtNoTrans.TabIndex = 24
        '
        'cboKapal
        '
        Me.cboKapal.FormattingEnabled = True
        Me.cboKapal.Location = New System.Drawing.Point(446, 64)
        Me.cboKapal.Name = "cboKapal"
        Me.cboKapal.Size = New System.Drawing.Size(302, 21)
        Me.cboKapal.TabIndex = 905700
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "No Trans"
        '
        'cboPancang
        '
        Me.cboPancang.FormattingEnabled = True
        Me.cboPancang.Location = New System.Drawing.Point(446, 37)
        Me.cboPancang.Name = "cboPancang"
        Me.cboPancang.Size = New System.Drawing.Size(302, 21)
        Me.cboPancang.TabIndex = 905699
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Tanggal Penjualan"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(390, 14)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(25, 13)
        Me.Label18.TabIndex = 905696
        Me.Label18.Text = "Trip"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(213, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(10, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "-"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(390, 68)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(34, 13)
        Me.Label19.TabIndex = 905697
        Me.Label19.Text = "Kapal"
        '
        'dtpTanggalPenjualan1
        '
        Me.dtpTanggalPenjualan1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTanggalPenjualan1.Location = New System.Drawing.Point(104, 36)
        Me.dtpTanggalPenjualan1.Name = "dtpTanggalPenjualan1"
        Me.dtpTanggalPenjualan1.Size = New System.Drawing.Size(98, 20)
        Me.dtpTanggalPenjualan1.TabIndex = 26
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(390, 41)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(50, 13)
        Me.Label20.TabIndex = 905695
        Me.Label20.Text = "Pancang"
        '
        'dtpTanggalPenjualan2
        '
        Me.dtpTanggalPenjualan2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTanggalPenjualan2.Location = New System.Drawing.Point(233, 36)
        Me.dtpTanggalPenjualan2.Name = "dtpTanggalPenjualan2"
        Me.dtpTanggalPenjualan2.Size = New System.Drawing.Size(98, 20)
        Me.dtpTanggalPenjualan2.TabIndex = 25
        '
        'Panel15
        '
        Me.Panel15.Controls.Add(Me.rdAllTujuan)
        Me.Panel15.Controls.Add(Me.rdPSG)
        Me.Panel15.Controls.Add(Me.rdCustomer)
        Me.Panel15.Controls.Add(Me.rdRSUP)
        Me.Panel15.Location = New System.Drawing.Point(104, 62)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(269, 21)
        Me.Panel15.TabIndex = 905694
        '
        'rdAllTujuan
        '
        Me.rdAllTujuan.AutoSize = True
        Me.rdAllTujuan.Checked = True
        Me.rdAllTujuan.Location = New System.Drawing.Point(2, 2)
        Me.rdAllTujuan.Name = "rdAllTujuan"
        Me.rdAllTujuan.Size = New System.Drawing.Size(72, 17)
        Me.rdAllTujuan.TabIndex = 118
        Me.rdAllTujuan.TabStop = True
        Me.rdAllTujuan.Text = "All Tujuan"
        Me.rdAllTujuan.UseVisualStyleBackColor = True
        '
        'rdPSG
        '
        Me.rdPSG.AutoSize = True
        Me.rdPSG.Location = New System.Drawing.Point(80, 2)
        Me.rdPSG.Name = "rdPSG"
        Me.rdPSG.Size = New System.Drawing.Size(47, 17)
        Me.rdPSG.TabIndex = 118
        Me.rdPSG.Text = "PSG"
        Me.rdPSG.UseVisualStyleBackColor = True
        '
        'rdCustomer
        '
        Me.rdCustomer.AutoSize = True
        Me.rdCustomer.Location = New System.Drawing.Point(194, 2)
        Me.rdCustomer.Name = "rdCustomer"
        Me.rdCustomer.Size = New System.Drawing.Size(69, 17)
        Me.rdCustomer.TabIndex = 118
        Me.rdCustomer.Text = "Customer"
        Me.rdCustomer.UseVisualStyleBackColor = True
        '
        'rdRSUP
        '
        Me.rdRSUP.AutoSize = True
        Me.rdRSUP.Location = New System.Drawing.Point(133, 2)
        Me.rdRSUP.Name = "rdRSUP"
        Me.rdRSUP.Size = New System.Drawing.Size(55, 17)
        Me.rdRSUP.TabIndex = 118
        Me.rdRSUP.Text = "RSUP"
        Me.rdRSUP.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(7, 66)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(40, 13)
        Me.Label25.TabIndex = 905693
        Me.Label25.Text = "Tujuan"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Panel8)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1157, 40)
        Me.Panel1.TabIndex = 1
        '
        'Panel8
        '
        Me.Panel8.BackgroundImage = CType(resources.GetObject("Panel8.BackgroundImage"), System.Drawing.Image)
        Me.Panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel8.Location = New System.Drawing.Point(10, 3)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(35, 35)
        Me.Panel8.TabIndex = 11
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(48, 6)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(197, 28)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "Transaksi Penjualan"
        '
        'FrmTrnPenjualan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1157, 603)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmTrnPenjualan"
        Me.Text = "Transaksi Penjualan"
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel15.ResumeLayout(False)
        Me.Panel15.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel4 As Panel
    Friend WithEvents txtTrip As TextBox
    Friend WithEvents txtNoTrans As TextBox
    Friend WithEvents cboKapal As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cboPancang As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents dtpTanggalPenjualan1 As DateTimePicker
    Friend WithEvents Label20 As Label
    Friend WithEvents dtpTanggalPenjualan2 As DateTimePicker
    Friend WithEvents Panel15 As Panel
    Friend WithEvents rdAllTujuan As RadioButton
    Friend WithEvents rdPSG As RadioButton
    Friend WithEvents rdCustomer As RadioButton
    Friend WithEvents rdRSUP As RadioButton
    Friend WithEvents Label25 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnAddParigi As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Label13 As Label
    Friend WithEvents Panel9 As Panel
End Class
