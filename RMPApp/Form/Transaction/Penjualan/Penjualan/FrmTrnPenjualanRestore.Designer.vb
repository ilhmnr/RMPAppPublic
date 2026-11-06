Imports System.Windows.Controls
Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTrnPenjualanRestore
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTrnPenjualanRestore))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.chkA6 = New System.Windows.Forms.CheckBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.rdJambul = New System.Windows.Forms.RadioButton()
        Me.rdGelondong = New System.Windows.Forms.RadioButton()
        Me.rdCungkil = New System.Windows.Forms.RadioButton()
        Me.rdLicin = New System.Windows.Forms.RadioButton()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.rdKBA = New System.Windows.Forms.RadioButton()
        Me.rdGD = New System.Windows.Forms.RadioButton()
        Me.rdKC = New System.Windows.Forms.RadioButton()
        Me.rdKBB = New System.Windows.Forms.RadioButton()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.rdPSG = New System.Windows.Forms.RadioButton()
        Me.rdCustomer = New System.Windows.Forms.RadioButton()
        Me.rdRSUP = New System.Windows.Forms.RadioButton()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtTrip = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cboKapal = New System.Windows.Forms.ComboBox()
        Me.cboPancang = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 40)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1091, 568)
        Me.Panel2.TabIndex = 5
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.fg)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 84)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(10, 0, 10, 10)
        Me.Panel4.Size = New System.Drawing.Size(1091, 484)
        Me.Panel4.TabIndex = 4
        '
        'fg
        '
        Me.fg.ColumnInfo = resources.GetString("fg.ColumnInfo")
        Me.fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fg.Location = New System.Drawing.Point(10, 0)
        Me.fg.Name = "fg"
        Me.fg.Rows.Count = 1
        Me.fg.Size = New System.Drawing.Size(1071, 474)
        Me.fg.TabIndex = 4
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnClose)
        Me.Panel3.Controls.Add(Me.Panel9)
        Me.Panel3.Controls.Add(Me.btnSearch)
        Me.Panel3.Controls.Add(Me.chkA6)
        Me.Panel3.Controls.Add(Me.Label18)
        Me.Panel3.Controls.Add(Me.Panel11)
        Me.Panel3.Controls.Add(Me.Panel10)
        Me.Panel3.Controls.Add(Me.Label25)
        Me.Panel3.Controls.Add(Me.Label27)
        Me.Panel3.Controls.Add(Me.Panel15)
        Me.Panel3.Controls.Add(Me.Label26)
        Me.Panel3.Controls.Add(Me.Label20)
        Me.Panel3.Controls.Add(Me.txtTrip)
        Me.Panel3.Controls.Add(Me.Label19)
        Me.Panel3.Controls.Add(Me.cboKapal)
        Me.Panel3.Controls.Add(Me.cboPancang)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1091, 84)
        Me.Panel3.TabIndex = 4
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.White
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(867, 46)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnClose.Size = New System.Drawing.Size(75, 30)
        Me.btnClose.TabIndex = 905739
        Me.btnClose.Text = "Exit"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.Black
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(1091, 1)
        Me.Panel9.TabIndex = 905738
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.White
        Me.btnSearch.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(791, 46)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnSearch.Size = New System.Drawing.Size(75, 30)
        Me.btnSearch.TabIndex = 905708
        Me.btnSearch.Text = "Refresh"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'chkA6
        '
        Me.chkA6.AutoSize = True
        Me.chkA6.Location = New System.Drawing.Point(736, 57)
        Me.chkA6.Name = "chkA6"
        Me.chkA6.Size = New System.Drawing.Size(39, 17)
        Me.chkA6.TabIndex = 905705
        Me.chkA6.Text = "A6"
        Me.chkA6.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(7, 12)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(25, 13)
        Me.Label18.TabIndex = 905696
        Me.Label18.Text = "Trip"
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.rdJambul)
        Me.Panel11.Controls.Add(Me.rdGelondong)
        Me.Panel11.Controls.Add(Me.rdCungkil)
        Me.Panel11.Controls.Add(Me.rdLicin)
        Me.Panel11.Location = New System.Drawing.Point(441, 31)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(266, 21)
        Me.Panel11.TabIndex = 905703
        '
        'rdJambul
        '
        Me.rdJambul.AutoSize = True
        Me.rdJambul.Checked = True
        Me.rdJambul.Location = New System.Drawing.Point(3, 2)
        Me.rdJambul.Name = "rdJambul"
        Me.rdJambul.Size = New System.Drawing.Size(58, 17)
        Me.rdJambul.TabIndex = 118
        Me.rdJambul.TabStop = True
        Me.rdJambul.Text = "Jambul"
        Me.rdJambul.UseVisualStyleBackColor = True
        '
        'rdGelondong
        '
        Me.rdGelondong.AutoSize = True
        Me.rdGelondong.Location = New System.Drawing.Point(186, 2)
        Me.rdGelondong.Name = "rdGelondong"
        Me.rdGelondong.Size = New System.Drawing.Size(77, 17)
        Me.rdGelondong.TabIndex = 118
        Me.rdGelondong.Text = "Gelondong"
        Me.rdGelondong.UseVisualStyleBackColor = True
        '
        'rdCungkil
        '
        Me.rdCungkil.AutoSize = True
        Me.rdCungkil.Location = New System.Drawing.Point(120, 2)
        Me.rdCungkil.Name = "rdCungkil"
        Me.rdCungkil.Size = New System.Drawing.Size(60, 17)
        Me.rdCungkil.TabIndex = 118
        Me.rdCungkil.Text = "Cungkil"
        Me.rdCungkil.UseVisualStyleBackColor = True
        '
        'rdLicin
        '
        Me.rdLicin.AutoSize = True
        Me.rdLicin.Location = New System.Drawing.Point(67, 2)
        Me.rdLicin.Name = "rdLicin"
        Me.rdLicin.Size = New System.Drawing.Size(47, 17)
        Me.rdLicin.TabIndex = 118
        Me.rdLicin.Text = "Licin"
        Me.rdLicin.UseVisualStyleBackColor = True
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.rdKBA)
        Me.Panel10.Controls.Add(Me.rdGD)
        Me.Panel10.Controls.Add(Me.rdKC)
        Me.Panel10.Controls.Add(Me.rdKBB)
        Me.Panel10.Location = New System.Drawing.Point(441, 55)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(266, 21)
        Me.Panel10.TabIndex = 905704
        '
        'rdKBA
        '
        Me.rdKBA.AutoSize = True
        Me.rdKBA.Checked = True
        Me.rdKBA.Location = New System.Drawing.Point(3, 2)
        Me.rdKBA.Name = "rdKBA"
        Me.rdKBA.Size = New System.Drawing.Size(49, 17)
        Me.rdKBA.TabIndex = 118
        Me.rdKBA.TabStop = True
        Me.rdKBA.Text = "KB-A"
        Me.rdKBA.UseVisualStyleBackColor = True
        '
        'rdGD
        '
        Me.rdGD.AutoSize = True
        Me.rdGD.Location = New System.Drawing.Point(158, 2)
        Me.rdGD.Name = "rdGD"
        Me.rdGD.Size = New System.Drawing.Size(41, 17)
        Me.rdGD.TabIndex = 118
        Me.rdGD.Text = "GD"
        Me.rdGD.UseVisualStyleBackColor = True
        '
        'rdKC
        '
        Me.rdKC.AutoSize = True
        Me.rdKC.Location = New System.Drawing.Point(113, 2)
        Me.rdKC.Name = "rdKC"
        Me.rdKC.Size = New System.Drawing.Size(39, 17)
        Me.rdKC.TabIndex = 118
        Me.rdKC.Text = "KC"
        Me.rdKC.UseVisualStyleBackColor = True
        '
        'rdKBB
        '
        Me.rdKBB.AutoSize = True
        Me.rdKBB.Location = New System.Drawing.Point(58, 2)
        Me.rdKBB.Name = "rdKBB"
        Me.rdKBB.Size = New System.Drawing.Size(49, 17)
        Me.rdKBB.TabIndex = 118
        Me.rdKBB.Text = "KB-B"
        Me.rdKBB.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(395, 12)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(40, 13)
        Me.Label25.TabIndex = 905693
        Me.Label25.Text = "Tujuan"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(395, 59)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(36, 13)
        Me.Label27.TabIndex = 905702
        Me.Label27.Text = "Grade"
        '
        'Panel15
        '
        Me.Panel15.Controls.Add(Me.rdPSG)
        Me.Panel15.Controls.Add(Me.rdCustomer)
        Me.Panel15.Controls.Add(Me.rdRSUP)
        Me.Panel15.Location = New System.Drawing.Point(441, 8)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(266, 21)
        Me.Panel15.TabIndex = 905694
        '
        'rdPSG
        '
        Me.rdPSG.AutoSize = True
        Me.rdPSG.Checked = True
        Me.rdPSG.Location = New System.Drawing.Point(4, 2)
        Me.rdPSG.Name = "rdPSG"
        Me.rdPSG.Size = New System.Drawing.Size(47, 17)
        Me.rdPSG.TabIndex = 118
        Me.rdPSG.TabStop = True
        Me.rdPSG.Text = "PSG"
        Me.rdPSG.UseVisualStyleBackColor = True
        '
        'rdCustomer
        '
        Me.rdCustomer.AutoSize = True
        Me.rdCustomer.Location = New System.Drawing.Point(118, 2)
        Me.rdCustomer.Name = "rdCustomer"
        Me.rdCustomer.Size = New System.Drawing.Size(69, 17)
        Me.rdCustomer.TabIndex = 118
        Me.rdCustomer.Text = "Customer"
        Me.rdCustomer.UseVisualStyleBackColor = True
        '
        'rdRSUP
        '
        Me.rdRSUP.AutoSize = True
        Me.rdRSUP.Location = New System.Drawing.Point(57, 2)
        Me.rdRSUP.Name = "rdRSUP"
        Me.rdRSUP.Size = New System.Drawing.Size(55, 17)
        Me.rdRSUP.TabIndex = 118
        Me.rdRSUP.Text = "RSUP"
        Me.rdRSUP.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(395, 35)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(34, 13)
        Me.Label26.TabIndex = 905701
        Me.Label26.Text = "Jenis "
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(7, 35)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(50, 13)
        Me.Label20.TabIndex = 905695
        Me.Label20.Text = "Pancang"
        '
        'txtTrip
        '
        Me.txtTrip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTrip.Location = New System.Drawing.Point(63, 8)
        Me.txtTrip.Name = "txtTrip"
        Me.txtTrip.Size = New System.Drawing.Size(75, 20)
        Me.txtTrip.TabIndex = 905698
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(7, 59)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(34, 13)
        Me.Label19.TabIndex = 905697
        Me.Label19.Text = "Kapal"
        '
        'cboKapal
        '
        Me.cboKapal.FormattingEnabled = True
        Me.cboKapal.Location = New System.Drawing.Point(63, 55)
        Me.cboKapal.Name = "cboKapal"
        Me.cboKapal.Size = New System.Drawing.Size(302, 21)
        Me.cboKapal.TabIndex = 905700
        '
        'cboPancang
        '
        Me.cboPancang.FormattingEnabled = True
        Me.cboPancang.Location = New System.Drawing.Point(63, 31)
        Me.cboPancang.Name = "cboPancang"
        Me.cboPancang.Size = New System.Drawing.Size(302, 21)
        Me.cboPancang.TabIndex = 905699
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Panel8)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1091, 40)
        Me.Panel1.TabIndex = 4
        '
        'Panel8
        '
        Me.Panel8.BackgroundImage = CType(resources.GetObject("Panel8.BackgroundImage"), System.Drawing.Image)
        Me.Panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel8.Location = New System.Drawing.Point(9, 2)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(35, 35)
        Me.Panel8.TabIndex = 13
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(47, 5)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(275, 28)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Transaksi Penjualan Restore"
        '
        'FrmTrnPenjualanRestore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1091, 608)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmTrnPenjualanRestore"
        Me.Text = "Transaksi Penjualan Restore"
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.Panel15.ResumeLayout(False)
        Me.Panel15.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents txtTrip As Windows.Forms.TextBox
    Friend WithEvents cboKapal As Windows.Forms.ComboBox
    Friend WithEvents cboPancang As Windows.Forms.ComboBox
    Friend WithEvents Label18 As Windows.Forms.Label
    Friend WithEvents Label19 As Windows.Forms.Label
    Friend WithEvents Label20 As Windows.Forms.Label
    Friend WithEvents Panel15 As Windows.Forms.Panel
    Friend WithEvents rdPSG As Windows.Forms.RadioButton
    Friend WithEvents rdRSUP As Windows.Forms.RadioButton
    Friend WithEvents Label25 As Windows.Forms.Label
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents Panel11 As Windows.Forms.Panel
    Friend WithEvents rdJambul As Windows.Forms.RadioButton
    Friend WithEvents rdCungkil As Windows.Forms.RadioButton
    Friend WithEvents rdLicin As Windows.Forms.RadioButton
    Friend WithEvents Panel10 As Windows.Forms.Panel
    Friend WithEvents rdKBA As Windows.Forms.RadioButton
    Friend WithEvents rdKC As Windows.Forms.RadioButton
    Friend WithEvents rdKBB As Windows.Forms.RadioButton
    Friend WithEvents Label27 As Windows.Forms.Label
    Friend WithEvents Label26 As Windows.Forms.Label
    Friend WithEvents chkA6 As Windows.Forms.CheckBox
    Friend WithEvents rdCustomer As Windows.Forms.RadioButton
    Friend WithEvents rdGelondong As Windows.Forms.RadioButton
    Friend WithEvents rdGD As Windows.Forms.RadioButton
    Friend WithEvents Panel4 As Windows.Forms.Panel
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel3 As Windows.Forms.Panel
    Friend WithEvents Panel8 As Windows.Forms.Panel
    Friend WithEvents Label13 As Windows.Forms.Label
    Friend WithEvents btnSearch As Windows.Forms.Button
    Friend WithEvents Panel9 As Windows.Forms.Panel
    Friend WithEvents btnClose As Windows.Forms.Button
End Class
