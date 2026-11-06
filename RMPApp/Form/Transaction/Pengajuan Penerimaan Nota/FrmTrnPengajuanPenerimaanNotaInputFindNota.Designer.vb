<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTrnPengajuanPenerimaanNotaInputFindNota
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTrnPengajuanPenerimaanNotaInputFindNota))
        Me.rdAllTujuan = New System.Windows.Forms.RadioButton()
        Me.rdPSG = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rdRSUP = New System.Windows.Forms.RadioButton()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.dtpTanggalNota2 = New System.Windows.Forms.DateTimePicker()
        Me.dtpTanggalNota1 = New System.Windows.Forms.DateTimePicker()
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
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtTrip = New System.Windows.Forms.TextBox()
        Me.cboKapal = New System.Windows.Forms.ComboBox()
        Me.cboPancang = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'rdAllTujuan
        '
        Me.rdAllTujuan.AutoSize = True
        Me.rdAllTujuan.Checked = True
        Me.rdAllTujuan.Location = New System.Drawing.Point(3, 2)
        Me.rdAllTujuan.Name = "rdAllTujuan"
        Me.rdAllTujuan.Size = New System.Drawing.Size(76, 17)
        Me.rdAllTujuan.TabIndex = 905685
        Me.rdAllTujuan.TabStop = True
        Me.rdAllTujuan.Text = "All Tujuan"
        Me.rdAllTujuan.UseVisualStyleBackColor = True
        '
        'rdPSG
        '
        Me.rdPSG.AutoSize = True
        Me.rdPSG.Location = New System.Drawing.Point(81, 2)
        Me.rdPSG.Name = "rdPSG"
        Me.rdPSG.Size = New System.Drawing.Size(45, 17)
        Me.rdPSG.TabIndex = 905686
        Me.rdPSG.Text = "PSG"
        Me.rdPSG.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rdAllTujuan)
        Me.Panel2.Controls.Add(Me.rdPSG)
        Me.Panel2.Controls.Add(Me.rdRSUP)
        Me.Panel2.Location = New System.Drawing.Point(486, 36)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(253, 21)
        Me.Panel2.TabIndex = 905687
        '
        'rdRSUP
        '
        Me.rdRSUP.AutoSize = True
        Me.rdRSUP.Location = New System.Drawing.Point(134, 2)
        Me.rdRSUP.Name = "rdRSUP"
        Me.rdRSUP.Size = New System.Drawing.Size(52, 17)
        Me.rdRSUP.TabIndex = 905684
        Me.rdRSUP.Text = "RSUP"
        Me.rdRSUP.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(418, 40)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(42, 13)
        Me.Label25.TabIndex = 905682
        Me.Label25.Text = "Tujuan"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1103, 40)
        Me.Panel1.TabIndex = 19
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(47, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(478, 28)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Transaksi Pengajuan Penerimaan Nota Find Kapal"
        '
        'Panel6
        '
        Me.Panel6.BackgroundImage = CType(resources.GetObject("Panel6.BackgroundImage"), System.Drawing.Image)
        Me.Panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel6.Location = New System.Drawing.Point(9, 2)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(35, 35)
        Me.Panel6.TabIndex = 7
        '
        'dtpTanggalNota2
        '
        Me.dtpTanggalNota2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTanggalNota2.Location = New System.Drawing.Point(261, 11)
        Me.dtpTanggalNota2.Name = "dtpTanggalNota2"
        Me.dtpTanggalNota2.Size = New System.Drawing.Size(130, 22)
        Me.dtpTanggalNota2.TabIndex = 905690
        '
        'dtpTanggalNota1
        '
        Me.dtpTanggalNota1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTanggalNota1.Location = New System.Drawing.Point(89, 11)
        Me.dtpTanggalNota1.Name = "dtpTanggalNota1"
        Me.dtpTanggalNota1.Size = New System.Drawing.Size(130, 22)
        Me.dtpTanggalNota1.TabIndex = 905690
        '
        'chkA6
        '
        Me.chkA6.AutoSize = True
        Me.chkA6.Location = New System.Drawing.Point(489, 14)
        Me.chkA6.Name = "chkA6"
        Me.chkA6.Size = New System.Drawing.Size(39, 17)
        Me.chkA6.TabIndex = 905689
        Me.chkA6.Text = "A6"
        Me.chkA6.UseVisualStyleBackColor = True
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.rdAllJenis)
        Me.Panel11.Controls.Add(Me.rdJambul)
        Me.Panel11.Controls.Add(Me.rdCungkil)
        Me.Panel11.Controls.Add(Me.rdLicin)
        Me.Panel11.Location = New System.Drawing.Point(486, 60)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(253, 21)
        Me.Panel11.TabIndex = 905687
        '
        'rdAllJenis
        '
        Me.rdAllJenis.AutoSize = True
        Me.rdAllJenis.Checked = True
        Me.rdAllJenis.Location = New System.Drawing.Point(3, 2)
        Me.rdAllJenis.Name = "rdAllJenis"
        Me.rdAllJenis.Size = New System.Drawing.Size(66, 17)
        Me.rdAllJenis.TabIndex = 118
        Me.rdAllJenis.TabStop = True
        Me.rdAllJenis.Text = "All Jenis"
        Me.rdAllJenis.UseVisualStyleBackColor = True
        '
        'rdJambul
        '
        Me.rdJambul.AutoSize = True
        Me.rdJambul.Location = New System.Drawing.Point(72, 2)
        Me.rdJambul.Name = "rdJambul"
        Me.rdJambul.Size = New System.Drawing.Size(61, 17)
        Me.rdJambul.TabIndex = 118
        Me.rdJambul.Text = "Jambul"
        Me.rdJambul.UseVisualStyleBackColor = True
        '
        'rdCungkil
        '
        Me.rdCungkil.AutoSize = True
        Me.rdCungkil.Location = New System.Drawing.Point(189, 2)
        Me.rdCungkil.Name = "rdCungkil"
        Me.rdCungkil.Size = New System.Drawing.Size(65, 17)
        Me.rdCungkil.TabIndex = 118
        Me.rdCungkil.Text = "Cungkil"
        Me.rdCungkil.UseVisualStyleBackColor = True
        '
        'rdLicin
        '
        Me.rdLicin.AutoSize = True
        Me.rdLicin.Location = New System.Drawing.Point(136, 2)
        Me.rdLicin.Name = "rdLicin"
        Me.rdLicin.Size = New System.Drawing.Size(48, 17)
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
        Me.Panel10.Location = New System.Drawing.Point(486, 85)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(253, 21)
        Me.Panel10.TabIndex = 905688
        '
        'rdAllGrade
        '
        Me.rdAllGrade.AutoSize = True
        Me.rdAllGrade.Checked = True
        Me.rdAllGrade.Location = New System.Drawing.Point(3, 2)
        Me.rdAllGrade.Name = "rdAllGrade"
        Me.rdAllGrade.Size = New System.Drawing.Size(72, 17)
        Me.rdAllGrade.TabIndex = 118
        Me.rdAllGrade.TabStop = True
        Me.rdAllGrade.Text = "All Grade"
        Me.rdAllGrade.UseVisualStyleBackColor = True
        '
        'rdKBA
        '
        Me.rdKBA.AutoSize = True
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
        Me.rdKC.Location = New System.Drawing.Point(187, 2)
        Me.rdKC.Name = "rdKC"
        Me.rdKC.Size = New System.Drawing.Size(38, 17)
        Me.rdKC.TabIndex = 118
        Me.rdKC.Text = "KC"
        Me.rdKC.UseVisualStyleBackColor = True
        '
        'rdKBB
        '
        Me.rdKBB.AutoSize = True
        Me.rdKBB.Location = New System.Drawing.Point(132, 2)
        Me.rdKBB.Name = "rdKBB"
        Me.rdKBB.Size = New System.Drawing.Size(49, 17)
        Me.rdKBB.TabIndex = 118
        Me.rdKBB.Text = "KB-B"
        Me.rdKBB.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(418, 89)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(38, 13)
        Me.Label27.TabIndex = 905683
        Me.Label27.Text = "Grade"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(418, 64)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(35, 13)
        Me.Label26.TabIndex = 905681
        Me.Label26.Text = "Jenis "
        '
        'txtTrip
        '
        Me.txtTrip.Location = New System.Drawing.Point(89, 84)
        Me.txtTrip.Name = "txtTrip"
        Me.txtTrip.Size = New System.Drawing.Size(75, 22)
        Me.txtTrip.TabIndex = 905673
        '
        'cboKapal
        '
        Me.cboKapal.FormattingEnabled = True
        Me.cboKapal.Location = New System.Drawing.Point(89, 60)
        Me.cboKapal.Name = "cboKapal"
        Me.cboKapal.Size = New System.Drawing.Size(302, 21)
        Me.cboKapal.TabIndex = 905675
        '
        'cboPancang
        '
        Me.cboPancang.FormattingEnabled = True
        Me.cboPancang.Location = New System.Drawing.Point(89, 36)
        Me.cboPancang.Name = "cboPancang"
        Me.cboPancang.Size = New System.Drawing.Size(302, 21)
        Me.cboPancang.TabIndex = 905674
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 13)
        Me.Label3.TabIndex = 905666
        Me.Label3.Text = "Trip"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 905667
        Me.Label2.Text = "Kapal"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(230, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 13)
        Me.Label5.TabIndex = 905664
        Me.Label5.Text = "s/d"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 905664
        Me.Label4.Text = "Tanggal Nota"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 905664
        Me.Label1.Text = "Pancang"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 40)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1103, 498)
        Me.Panel3.TabIndex = 21
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.fg)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 118)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(10, 0, 10, 10)
        Me.Panel5.Size = New System.Drawing.Size(1103, 380)
        Me.Panel5.TabIndex = 4
        '
        'fg
        '
        Me.fg.ColumnInfo = resources.GetString("fg.ColumnInfo")
        Me.fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fg.Location = New System.Drawing.Point(10, 0)
        Me.fg.Name = "fg"
        Me.fg.Rows.Count = 1
        Me.fg.Size = New System.Drawing.Size(1083, 370)
        Me.fg.TabIndex = 4
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnCancel)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.Panel7)
        Me.Panel4.Controls.Add(Me.btnRefresh)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.dtpTanggalNota2)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.dtpTanggalNota1)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.chkA6)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.Panel2)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.Panel11)
        Me.Panel4.Controls.Add(Me.cboPancang)
        Me.Panel4.Controls.Add(Me.Panel10)
        Me.Panel4.Controls.Add(Me.cboKapal)
        Me.Panel4.Controls.Add(Me.Label25)
        Me.Panel4.Controls.Add(Me.txtTrip)
        Me.Panel4.Controls.Add(Me.Label27)
        Me.Panel4.Controls.Add(Me.Label26)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1103, 118)
        Me.Panel4.TabIndex = 4
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Black
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(1103, 1)
        Me.Panel7.TabIndex = 905732
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.White
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRefresh.Location = New System.Drawing.Point(942, 76)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnRefresh.Size = New System.Drawing.Size(75, 30)
        Me.btnRefresh.TabIndex = 905730
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(419, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 13)
        Me.Label6.TabIndex = 905733
        Me.Label6.Text = "Grade Sub"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.White
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(1018, 76)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnCancel.Size = New System.Drawing.Size(75, 30)
        Me.btnCancel.TabIndex = 905734
        Me.btnCancel.Text = "Exit"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'FrmTrnPengajuanPenerimaanNotaShowKapal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1103, 538)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FrmTrnPengajuanPenerimaanNotaShowKapal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transaksi Pengajuan Penerimaan Nota Find Kapal"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rdAllTujuan As RadioButton
    Friend WithEvents rdPSG As RadioButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents rdRSUP As RadioButton
    Friend WithEvents Label25 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtTrip As TextBox
    Friend WithEvents cboKapal As ComboBox
    Friend WithEvents cboPancang As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents dtpTanggalNota2 As DateTimePicker
    Friend WithEvents dtpTanggalNota1 As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents chkA6 As CheckBox
    Friend WithEvents Panel11 As Panel
    Friend WithEvents rdAllJenis As RadioButton
    Friend WithEvents rdJambul As RadioButton
    Friend WithEvents rdCungkil As RadioButton
    Friend WithEvents rdLicin As RadioButton
    Friend WithEvents Panel10 As Panel
    Friend WithEvents rdAllGrade As RadioButton
    Friend WithEvents rdKBA As RadioButton
    Friend WithEvents rdKC As RadioButton
    Friend WithEvents rdKBB As RadioButton
    Friend WithEvents Label27 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents btnRefresh As Button
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents btnCancel As Button
End Class
