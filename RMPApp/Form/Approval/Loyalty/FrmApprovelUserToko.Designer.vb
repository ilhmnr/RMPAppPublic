<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmApprovelUserToko
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmApprovelUserToko))
        Me.schfg = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.grpDataTimbangCrane = New XanderUI.XUICustomGroupbox()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnRejected = New System.Windows.Forms.Button()
        Me.cbxAll = New System.Windows.Forms.CheckBox()
        Me.btnApproved = New System.Windows.Forms.Button()
        Me.pnlAlasanDitolak = New System.Windows.Forms.Panel()
        Me.txtAlasan = New System.Windows.Forms.TextBox()
        Me.lblAlasanDitolak = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.pnlSearch = New System.Windows.Forms.Panel()
        Me.txtcari = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.grpDataTimbangCrane.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'schfg
        '
        Me.schfg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.schfg.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.schfg.Location = New System.Drawing.Point(791, -12)
        Me.schfg.Margin = New System.Windows.Forms.Padding(1)
        Me.schfg.Name = "schfg"
        Me.schfg.ShowClearButton = False
        Me.schfg.ShowSearchButton = False
        Me.schfg.Size = New System.Drawing.Size(208, 37)
        Me.schfg.TabIndex = 194
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.BackgroundImage = Global.RMPApp.My.Resources.Resources.transparent_refresh_icon_reload_icon_reset_icon_5dbe14a6840921_0842978615727382145408
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(314, 22)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(22, 22)
        Me.Button1.TabIndex = 879
        Me.Button1.UseVisualStyleBackColor = False
        '
        'grpDataTimbangCrane
        '
        Me.grpDataTimbangCrane.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDataTimbangCrane.BackColor = System.Drawing.Color.White
        Me.grpDataTimbangCrane.BorderColor = System.Drawing.Color.DodgerBlue
        Me.grpDataTimbangCrane.BorderWidth = 1
        Me.grpDataTimbangCrane.Controls.Add(Me.fg)
        Me.grpDataTimbangCrane.Controls.Add(Me.schfg)
        Me.grpDataTimbangCrane.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDataTimbangCrane.Location = New System.Drawing.Point(20, 50)
        Me.grpDataTimbangCrane.Name = "grpDataTimbangCrane"
        Me.grpDataTimbangCrane.ShowText = True
        Me.grpDataTimbangCrane.Size = New System.Drawing.Size(972, 411)
        Me.grpDataTimbangCrane.TabIndex = 878
        Me.grpDataTimbangCrane.TabStop = False
        Me.grpDataTimbangCrane.Text = "Toko"
        Me.grpDataTimbangCrane.TextColor = System.Drawing.Color.Navy
        '
        'fg
        '
        Me.fg.ColumnInfo = resources.GetString("fg.ColumnInfo")
        Me.fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fg.Location = New System.Drawing.Point(3, 19)
        Me.fg.Name = "fg"
        Me.fg.Size = New System.Drawing.Size(966, 389)
        Me.fg.TabIndex = 429
        '
        'Panel6
        '
        Me.Panel6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel6.BackColor = System.Drawing.Color.White
        Me.Panel6.Controls.Add(Me.Button1)
        Me.Panel6.Controls.Add(Me.grpDataTimbangCrane)
        Me.Panel6.Controls.Add(Me.btnRejected)
        Me.Panel6.Controls.Add(Me.cbxAll)
        Me.Panel6.Controls.Add(Me.btnApproved)
        Me.Panel6.Controls.Add(Me.pnlAlasanDitolak)
        Me.Panel6.Controls.Add(Me.txtAlasan)
        Me.Panel6.Controls.Add(Me.lblAlasanDitolak)
        Me.Panel6.Controls.Add(Me.Label19)
        Me.Panel6.Controls.Add(Me.pnlSearch)
        Me.Panel6.Controls.Add(Me.txtcari)
        Me.Panel6.Controls.Add(Me.Label6)
        Me.Panel6.ForeColor = System.Drawing.Color.Black
        Me.Panel6.Location = New System.Drawing.Point(12, 52)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1017, 523)
        Me.Panel6.TabIndex = 883
        '
        'btnRejected
        '
        Me.btnRejected.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRejected.BackgroundImage = Global.RMPApp.My.Resources.Resources.icons8_mail_64__1_
        Me.btnRejected.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRejected.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRejected.ForeColor = System.Drawing.Color.White
        Me.btnRejected.Location = New System.Drawing.Point(956, 467)
        Me.btnRejected.Name = "btnRejected"
        Me.btnRejected.Size = New System.Drawing.Size(58, 54)
        Me.btnRejected.TabIndex = 320
        Me.btnRejected.UseVisualStyleBackColor = True
        '
        'cbxAll
        '
        Me.cbxAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbxAll.AutoSize = True
        Me.cbxAll.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbxAll.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxAll.Location = New System.Drawing.Point(33, 484)
        Me.cbxAll.Name = "cbxAll"
        Me.cbxAll.Size = New System.Drawing.Size(84, 21)
        Me.cbxAll.TabIndex = 317
        Me.cbxAll.Text = "Select All"
        Me.cbxAll.UseVisualStyleBackColor = True
        '
        'btnApproved
        '
        Me.btnApproved.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApproved.BackColor = System.Drawing.Color.White
        Me.btnApproved.BackgroundImage = Global.RMPApp.My.Resources.Resources.icons8_mail_64
        Me.btnApproved.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnApproved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnApproved.ForeColor = System.Drawing.Color.White
        Me.btnApproved.Location = New System.Drawing.Point(893, 467)
        Me.btnApproved.Name = "btnApproved"
        Me.btnApproved.Size = New System.Drawing.Size(57, 55)
        Me.btnApproved.TabIndex = 319
        Me.btnApproved.Text = "'"
        Me.btnApproved.UseVisualStyleBackColor = False
        '
        'pnlAlasanDitolak
        '
        Me.pnlAlasanDitolak.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlAlasanDitolak.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.pnlAlasanDitolak.Location = New System.Drawing.Point(649, 505)
        Me.pnlAlasanDitolak.Name = "pnlAlasanDitolak"
        Me.pnlAlasanDitolak.Size = New System.Drawing.Size(220, 1)
        Me.pnlAlasanDitolak.TabIndex = 315
        '
        'txtAlasan
        '
        Me.txtAlasan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAlasan.BackColor = System.Drawing.Color.White
        Me.txtAlasan.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtAlasan.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlasan.Location = New System.Drawing.Point(657, 484)
        Me.txtAlasan.Name = "txtAlasan"
        Me.txtAlasan.Size = New System.Drawing.Size(212, 15)
        Me.txtAlasan.TabIndex = 314
        Me.txtAlasan.Text = "Remark"
        '
        'lblAlasanDitolak
        '
        Me.lblAlasanDitolak.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAlasanDitolak.AutoSize = True
        Me.lblAlasanDitolak.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.lblAlasanDitolak.Location = New System.Drawing.Point(584, 483)
        Me.lblAlasanDitolak.Name = "lblAlasanDitolak"
        Me.lblAlasanDitolak.Size = New System.Drawing.Size(64, 17)
        Me.lblAlasanDitolak.TabIndex = 313
        Me.lblAlasanDitolak.Text = "Remark   :"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label19.Location = New System.Drawing.Point(77, 19)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(11, 17)
        Me.Label19.TabIndex = 312
        Me.Label19.Text = ":"
        '
        'pnlSearch
        '
        Me.pnlSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.pnlSearch.Location = New System.Drawing.Point(90, 39)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Size = New System.Drawing.Size(220, 1)
        Me.pnlSearch.TabIndex = 311
        '
        'txtcari
        '
        Me.txtcari.BackColor = System.Drawing.Color.White
        Me.txtcari.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtcari.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcari.Location = New System.Drawing.Point(96, 20)
        Me.txtcari.Name = "txtcari"
        Me.txtcari.Size = New System.Drawing.Size(212, 15)
        Me.txtcari.TabIndex = 310
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(23, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 17)
        Me.Label6.TabIndex = 309
        Me.Label6.Text = "Search"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.RMPApp.My.Resources.Resources.Untitled_1
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(54, 46)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(60, 33)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(145, 1)
        Me.Panel2.TabIndex = 829
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.Panel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 3.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel3.Location = New System.Drawing.Point(60, 37)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(145, 1)
        Me.Panel3.TabIndex = 830
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.DimGray
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1041, 46)
        Me.Panel1.TabIndex = 884
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(57, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(101, 18)
        Me.Label8.TabIndex = 828
        Me.Label8.Text = "Approval User"
        '
        'ApprovelUserToko
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1041, 587)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ApprovelUserToko"
        Me.Text = "ApprovelUserToko"
        Me.grpDataTimbangCrane.ResumeLayout(False)
        Me.grpDataTimbangCrane.PerformLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents schfg As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents Button1 As Button
    Friend WithEvents grpDataTimbangCrane As XanderUI.XUICustomGroupbox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents btnRejected As Button
    Friend WithEvents cbxAll As CheckBox
    Friend WithEvents btnApproved As Button
    Friend WithEvents pnlAlasanDitolak As Panel
    Friend WithEvents txtAlasan As TextBox
    Friend WithEvents lblAlasanDitolak As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents pnlSearch As Panel
    Friend WithEvents txtcari As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
End Class
