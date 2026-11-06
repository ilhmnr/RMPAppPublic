<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTrnPenjualanRSUPDanPSGFindKapal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTrnPenjualanRSUPDanPSGFindKapal))
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.rdGD = New System.Windows.Forms.RadioButton()
        Me.rdAllGrade = New System.Windows.Forms.RadioButton()
        Me.rdKBA = New System.Windows.Forms.RadioButton()
        Me.rdKC = New System.Windows.Forms.RadioButton()
        Me.rdKBB = New System.Windows.Forms.RadioButton()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtTrip = New System.Windows.Forms.TextBox()
        Me.cboKapal = New System.Windows.Forms.ComboBox()
        Me.cboPancang = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.chkA6 = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rdAllTujuan = New System.Windows.Forms.RadioButton()
        Me.rdPSG = New System.Windows.Forms.RadioButton()
        Me.rdCustomer = New System.Windows.Forms.RadioButton()
        Me.rdRSUP = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.rdGelondong = New System.Windows.Forms.RadioButton()
        Me.rdAllJenis = New System.Windows.Forms.RadioButton()
        Me.rdJambul = New System.Windows.Forms.RadioButton()
        Me.rdCungkil = New System.Windows.Forms.RadioButton()
        Me.rdLicin = New System.Windows.Forms.RadioButton()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Panel10.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.rdGD)
        Me.Panel10.Controls.Add(Me.rdAllGrade)
        Me.Panel10.Controls.Add(Me.rdKBA)
        Me.Panel10.Controls.Add(Me.rdKC)
        Me.Panel10.Controls.Add(Me.rdKBB)
        Me.Panel10.Location = New System.Drawing.Point(440, 59)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(332, 21)
        Me.Panel10.TabIndex = 905688
        '
        'rdGD
        '
        Me.rdGD.AutoSize = True
        Me.rdGD.Location = New System.Drawing.Point(232, 2)
        Me.rdGD.Name = "rdGD"
        Me.rdGD.Size = New System.Drawing.Size(41, 17)
        Me.rdGD.TabIndex = 119
        Me.rdGD.Text = "GD"
        Me.rdGD.UseVisualStyleBackColor = True
        '
        'rdAllGrade
        '
        Me.rdAllGrade.AutoSize = True
        Me.rdAllGrade.Checked = True
        Me.rdAllGrade.Location = New System.Drawing.Point(3, 2)
        Me.rdAllGrade.Name = "rdAllGrade"
        Me.rdAllGrade.Size = New System.Drawing.Size(68, 17)
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
        Me.rdKC.Size = New System.Drawing.Size(39, 17)
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
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(394, 14)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(40, 13)
        Me.Label25.TabIndex = 905682
        Me.Label25.Text = "Tujuan"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(394, 63)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(36, 13)
        Me.Label27.TabIndex = 905683
        Me.Label27.Text = "Grade"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(394, 38)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(34, 13)
        Me.Label26.TabIndex = 905681
        Me.Label26.Text = "Jenis "
        '
        'txtTrip
        '
        Me.txtTrip.Location = New System.Drawing.Point(63, 59)
        Me.txtTrip.Name = "txtTrip"
        Me.txtTrip.Size = New System.Drawing.Size(75, 20)
        Me.txtTrip.TabIndex = 905673
        '
        'cboKapal
        '
        Me.cboKapal.FormattingEnabled = True
        Me.cboKapal.Location = New System.Drawing.Point(63, 34)
        Me.cboKapal.Name = "cboKapal"
        Me.cboKapal.Size = New System.Drawing.Size(302, 21)
        Me.cboKapal.TabIndex = 905675
        '
        'cboPancang
        '
        Me.cboPancang.FormattingEnabled = True
        Me.cboPancang.Location = New System.Drawing.Point(63, 10)
        Me.cboPancang.Name = "cboPancang"
        Me.cboPancang.Size = New System.Drawing.Size(302, 21)
        Me.cboPancang.TabIndex = 905674
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 13)
        Me.Label3.TabIndex = 905666
        Me.Label3.Text = "Trip"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 905667
        Me.Label2.Text = "Kapal"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
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
        Me.Panel3.Size = New System.Drawing.Size(1203, 528)
        Me.Panel3.TabIndex = 18
        '
        'chkA6
        '
        Me.chkA6.AutoSize = True
        Me.chkA6.Location = New System.Drawing.Point(793, 61)
        Me.chkA6.Name = "chkA6"
        Me.chkA6.Size = New System.Drawing.Size(39, 17)
        Me.chkA6.TabIndex = 905689
        Me.chkA6.Text = "A6"
        Me.chkA6.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rdAllTujuan)
        Me.Panel2.Controls.Add(Me.rdPSG)
        Me.Panel2.Controls.Add(Me.rdCustomer)
        Me.Panel2.Controls.Add(Me.rdRSUP)
        Me.Panel2.Location = New System.Drawing.Point(440, 10)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(332, 21)
        Me.Panel2.TabIndex = 905687
        '
        'rdAllTujuan
        '
        Me.rdAllTujuan.AutoSize = True
        Me.rdAllTujuan.Checked = True
        Me.rdAllTujuan.Location = New System.Drawing.Point(3, 2)
        Me.rdAllTujuan.Name = "rdAllTujuan"
        Me.rdAllTujuan.Size = New System.Drawing.Size(72, 17)
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
        Me.rdPSG.Size = New System.Drawing.Size(47, 17)
        Me.rdPSG.TabIndex = 905686
        Me.rdPSG.Text = "PSG"
        Me.rdPSG.UseVisualStyleBackColor = True
        '
        'rdCustomer
        '
        Me.rdCustomer.AutoSize = True
        Me.rdCustomer.Location = New System.Drawing.Point(195, 2)
        Me.rdCustomer.Name = "rdCustomer"
        Me.rdCustomer.Size = New System.Drawing.Size(69, 17)
        Me.rdCustomer.TabIndex = 905684
        Me.rdCustomer.Text = "Customer"
        Me.rdCustomer.UseVisualStyleBackColor = True
        '
        'rdRSUP
        '
        Me.rdRSUP.AutoSize = True
        Me.rdRSUP.Location = New System.Drawing.Point(134, 2)
        Me.rdRSUP.Name = "rdRSUP"
        Me.rdRSUP.Size = New System.Drawing.Size(55, 17)
        Me.rdRSUP.TabIndex = 905684
        Me.rdRSUP.Text = "RSUP"
        Me.rdRSUP.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Panel8)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1203, 40)
        Me.Panel1.TabIndex = 17
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.rdGelondong)
        Me.Panel11.Controls.Add(Me.rdAllJenis)
        Me.Panel11.Controls.Add(Me.rdJambul)
        Me.Panel11.Controls.Add(Me.rdCungkil)
        Me.Panel11.Controls.Add(Me.rdLicin)
        Me.Panel11.Location = New System.Drawing.Point(440, 34)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(332, 21)
        Me.Panel11.TabIndex = 905687
        '
        'rdGelondong
        '
        Me.rdGelondong.AutoSize = True
        Me.rdGelondong.Location = New System.Drawing.Point(255, 2)
        Me.rdGelondong.Name = "rdGelondong"
        Me.rdGelondong.Size = New System.Drawing.Size(77, 17)
        Me.rdGelondong.TabIndex = 119
        Me.rdGelondong.Text = "Gelondong"
        Me.rdGelondong.UseVisualStyleBackColor = True
        '
        'rdAllJenis
        '
        Me.rdAllJenis.AutoSize = True
        Me.rdAllJenis.Checked = True
        Me.rdAllJenis.Location = New System.Drawing.Point(3, 2)
        Me.rdAllJenis.Name = "rdAllJenis"
        Me.rdAllJenis.Size = New System.Drawing.Size(63, 17)
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
        Me.rdJambul.Size = New System.Drawing.Size(58, 17)
        Me.rdJambul.TabIndex = 118
        Me.rdJambul.Text = "Jambul"
        Me.rdJambul.UseVisualStyleBackColor = True
        '
        'rdCungkil
        '
        Me.rdCungkil.AutoSize = True
        Me.rdCungkil.Location = New System.Drawing.Point(189, 2)
        Me.rdCungkil.Name = "rdCungkil"
        Me.rdCungkil.Size = New System.Drawing.Size(60, 17)
        Me.rdCungkil.TabIndex = 118
        Me.rdCungkil.Text = "Cungkil"
        Me.rdCungkil.UseVisualStyleBackColor = True
        '
        'rdLicin
        '
        Me.rdLicin.AutoSize = True
        Me.rdLicin.Location = New System.Drawing.Point(136, 2)
        Me.rdLicin.Name = "rdLicin"
        Me.rdLicin.Size = New System.Drawing.Size(47, 17)
        Me.rdLicin.TabIndex = 118
        Me.rdLicin.Text = "Licin"
        Me.rdLicin.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnClose)
        Me.Panel4.Controls.Add(Me.btnSearch)
        Me.Panel4.Controls.Add(Me.Panel9)
        Me.Panel4.Controls.Add(Me.Label1)
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
        Me.Panel4.Size = New System.Drawing.Size(1203, 88)
        Me.Panel4.TabIndex = 3
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.fg)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 88)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(10, 0, 10, 10)
        Me.Panel5.Size = New System.Drawing.Size(1203, 440)
        Me.Panel5.TabIndex = 3
        '
        'fg
        '
        Me.fg.ColumnInfo = resources.GetString("fg.ColumnInfo")
        Me.fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fg.Location = New System.Drawing.Point(10, 0)
        Me.fg.Name = "fg"
        Me.fg.Rows.Count = 1
        Me.fg.Size = New System.Drawing.Size(1183, 430)
        Me.fg.TabIndex = 3
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.Black
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(1203, 1)
        Me.Panel9.TabIndex = 905739
        '
        'Panel8
        '
        Me.Panel8.BackgroundImage = CType(resources.GetObject("Panel8.BackgroundImage"), System.Drawing.Image)
        Me.Panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel8.Location = New System.Drawing.Point(10, 3)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(35, 35)
        Me.Panel8.TabIndex = 13
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(48, 6)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(445, 28)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Transaksi Penjualan RSUP Dan PSG Find Kapal"
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.White
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(914, 50)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnClose.Size = New System.Drawing.Size(75, 30)
        Me.btnClose.TabIndex = 905741
        Me.btnClose.Text = "Exit"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.White
        Me.btnSearch.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(838, 50)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnSearch.Size = New System.Drawing.Size(75, 30)
        Me.btnSearch.TabIndex = 905740
        Me.btnSearch.Text = "Refresh"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'FrmTrnPenjualanRSUPDanPSGFindKapal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1203, 568)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmTrnPenjualanRSUPDanPSGFindKapal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Find Kapal Pembuatan Penjualan"
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel10 As Panel
    Friend WithEvents rdAllGrade As RadioButton
    Friend WithEvents rdKBA As RadioButton
    Friend WithEvents rdKC As RadioButton
    Friend WithEvents rdKBB As RadioButton
    Friend WithEvents Label25 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents txtTrip As TextBox
    Friend WithEvents cboKapal As ComboBox
    Friend WithEvents cboPancang As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents chkA6 As CheckBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents rdAllTujuan As RadioButton
    Friend WithEvents rdPSG As RadioButton
    Friend WithEvents rdRSUP As RadioButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel11 As Panel
    Friend WithEvents rdAllJenis As RadioButton
    Friend WithEvents rdJambul As RadioButton
    Friend WithEvents rdCungkil As RadioButton
    Friend WithEvents rdLicin As RadioButton
    Friend WithEvents rdGD As RadioButton
    Friend WithEvents rdGelondong As RadioButton
    Friend WithEvents rdCustomer As RadioButton
    Friend WithEvents Panel5 As Panel
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Label13 As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents btnSearch As Button
End Class
