<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTrnTerimaNotaDiPabrik
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTrnTerimaNotaDiPabrik))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.BtnCari = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.CmbPancang = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.rdPulsaListrik = New System.Windows.Forms.RadioButton()
        Me.rdPurchaser = New System.Windows.Forms.RadioButton()
        Me.rdPancang = New System.Windows.Forms.RadioButton()
        Me.rdAllPenggunaan = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.rdAll = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.rdSdhTerima = New System.Windows.Forms.RadioButton()
        Me.rdBlmTerima = New System.Windows.Forms.RadioButton()
        Me.dtp2 = New System.Windows.Forms.DateTimePicker()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Panel8)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(618, 40)
        Me.Panel1.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(47, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(304, 28)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Transaksi Trima Nota Di Pabrik"
        '
        'Panel8
        '
        Me.Panel8.BackgroundImage = CType(resources.GetObject("Panel8.BackgroundImage"), System.Drawing.Image)
        Me.Panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel8.Location = New System.Drawing.Point(11, 3)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(35, 35)
        Me.Panel8.TabIndex = 11
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel2.Controls.Add(Me.BtnExit)
        Me.Panel2.Controls.Add(Me.btnSave)
        Me.Panel2.Controls.Add(Me.BtnCari)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 332)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(618, 40)
        Me.Panel2.TabIndex = 0
        '
        'BtnExit
        '
        Me.BtnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExit.BackColor = System.Drawing.Color.White
        Me.BtnExit.Image = CType(resources.GetObject("BtnExit.Image"), System.Drawing.Image)
        Me.BtnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnExit.Location = New System.Drawing.Point(533, 4)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.BtnExit.Size = New System.Drawing.Size(75, 30)
        Me.BtnExit.TabIndex = 905718
        Me.BtnExit.Text = "Exit"
        Me.BtnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnExit.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.White
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(457, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnSave.Size = New System.Drawing.Size(75, 30)
        Me.btnSave.TabIndex = 905717
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'BtnCari
        '
        Me.BtnCari.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCari.BackColor = System.Drawing.Color.White
        Me.BtnCari.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCari.Image = CType(resources.GetObject("BtnCari.Image"), System.Drawing.Image)
        Me.BtnCari.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCari.Location = New System.Drawing.Point(381, 4)
        Me.BtnCari.Name = "BtnCari"
        Me.BtnCari.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.BtnCari.Size = New System.Drawing.Size(75, 30)
        Me.BtnCari.TabIndex = 905716
        Me.BtnCari.Text = "Refresh"
        Me.BtnCari.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCari.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 40)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(618, 292)
        Me.Panel3.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.White
        Me.Panel5.Controls.Add(Me.fg)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 109)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(10, 0, 10, 10)
        Me.Panel5.Size = New System.Drawing.Size(618, 183)
        Me.Panel5.TabIndex = 0
        '
        'fg
        '
        Me.fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fg.ColumnInfo = resources.GetString("fg.ColumnInfo")
        Me.fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fg.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fg.ForeColor = System.Drawing.Color.Black
        Me.fg.Location = New System.Drawing.Point(10, 0)
        Me.fg.Name = "fg"
        Me.fg.Rows.Count = 4
        Me.fg.Rows.DefaultSize = 22
        Me.fg.Size = New System.Drawing.Size(598, 173)
        Me.fg.StyleInfo = resources.GetString("fg.StyleInfo")
        Me.fg.TabIndex = 1019
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.Panel9)
        Me.Panel4.Controls.Add(Me.CmbPancang)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.Panel6)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.rdAll)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.dtp1)
        Me.Panel4.Controls.Add(Me.rdSdhTerima)
        Me.Panel4.Controls.Add(Me.rdBlmTerima)
        Me.Panel4.Controls.Add(Me.dtp2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(618, 109)
        Me.Panel4.TabIndex = 0
        '
        'CmbPancang
        '
        Me.CmbPancang.FormattingEnabled = True
        Me.CmbPancang.Location = New System.Drawing.Point(82, 50)
        Me.CmbPancang.Name = "CmbPancang"
        Me.CmbPancang.Size = New System.Drawing.Size(225, 21)
        Me.CmbPancang.TabIndex = 1020
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 1006
        Me.Label1.Text = "Status "
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.rdPulsaListrik)
        Me.Panel6.Controls.Add(Me.rdPurchaser)
        Me.Panel6.Controls.Add(Me.rdPancang)
        Me.Panel6.Controls.Add(Me.rdAllPenggunaan)
        Me.Panel6.Location = New System.Drawing.Point(82, 74)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(274, 27)
        Me.Panel6.TabIndex = 1018
        '
        'rdPulsaListrik
        '
        Me.rdPulsaListrik.AutoSize = True
        Me.rdPulsaListrik.Location = New System.Drawing.Point(195, 5)
        Me.rdPulsaListrik.Name = "rdPulsaListrik"
        Me.rdPulsaListrik.Size = New System.Drawing.Size(78, 17)
        Me.rdPulsaListrik.TabIndex = 977
        Me.rdPulsaListrik.Text = "PulsaListrik"
        Me.rdPulsaListrik.UseVisualStyleBackColor = True
        '
        'rdPurchaser
        '
        Me.rdPurchaser.AutoSize = True
        Me.rdPurchaser.Location = New System.Drawing.Point(116, 5)
        Me.rdPurchaser.Name = "rdPurchaser"
        Me.rdPurchaser.Size = New System.Drawing.Size(73, 17)
        Me.rdPurchaser.TabIndex = 977
        Me.rdPurchaser.Text = "Purchaser"
        Me.rdPurchaser.UseVisualStyleBackColor = True
        '
        'rdPancang
        '
        Me.rdPancang.AutoSize = True
        Me.rdPancang.Location = New System.Drawing.Point(42, 5)
        Me.rdPancang.Name = "rdPancang"
        Me.rdPancang.Size = New System.Drawing.Size(68, 17)
        Me.rdPancang.TabIndex = 978
        Me.rdPancang.Text = "Pancang"
        Me.rdPancang.UseVisualStyleBackColor = True
        '
        'rdAllPenggunaan
        '
        Me.rdAllPenggunaan.AutoSize = True
        Me.rdAllPenggunaan.Checked = True
        Me.rdAllPenggunaan.Location = New System.Drawing.Point(1, 5)
        Me.rdAllPenggunaan.Name = "rdAllPenggunaan"
        Me.rdAllPenggunaan.Size = New System.Drawing.Size(36, 17)
        Me.rdAllPenggunaan.TabIndex = 979
        Me.rdAllPenggunaan.TabStop = True
        Me.rdAllPenggunaan.Text = "All"
        Me.rdAllPenggunaan.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 1009
        Me.Label2.Text = "Tanggal "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(183, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 13)
        Me.Label3.TabIndex = 1008
        Me.Label3.Text = "s/d"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.Label9.Location = New System.Drawing.Point(8, 81)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 13)
        Me.Label9.TabIndex = 1017
        Me.Label9.Text = "Penggunaan"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rdAll
        '
        Me.rdAll.AutoSize = True
        Me.rdAll.Location = New System.Drawing.Point(274, 8)
        Me.rdAll.Name = "rdAll"
        Me.rdAll.Size = New System.Drawing.Size(36, 17)
        Me.rdAll.TabIndex = 1003
        Me.rdAll.Text = "All"
        Me.rdAll.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.Label6.Location = New System.Drawing.Point(8, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 1016
        Me.Label6.Text = "Pancang"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtp1
        '
        Me.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp1.Location = New System.Drawing.Point(82, 27)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(95, 20)
        Me.dtp1.TabIndex = 1012
        '
        'rdSdhTerima
        '
        Me.rdSdhTerima.AutoSize = True
        Me.rdSdhTerima.Location = New System.Drawing.Point(177, 8)
        Me.rdSdhTerima.Name = "rdSdhTerima"
        Me.rdSdhTerima.Size = New System.Drawing.Size(91, 17)
        Me.rdSdhTerima.TabIndex = 1004
        Me.rdSdhTerima.Text = "Sudah Terima"
        Me.rdSdhTerima.UseVisualStyleBackColor = True
        '
        'rdBlmTerima
        '
        Me.rdBlmTerima.AutoSize = True
        Me.rdBlmTerima.Checked = True
        Me.rdBlmTerima.Location = New System.Drawing.Point(82, 8)
        Me.rdBlmTerima.Name = "rdBlmTerima"
        Me.rdBlmTerima.Size = New System.Drawing.Size(89, 17)
        Me.rdBlmTerima.TabIndex = 1005
        Me.rdBlmTerima.TabStop = True
        Me.rdBlmTerima.Text = "Belum Terima"
        Me.rdBlmTerima.UseVisualStyleBackColor = True
        '
        'dtp2
        '
        Me.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp2.Location = New System.Drawing.Point(212, 27)
        Me.dtp2.Name = "dtp2"
        Me.dtp2.Size = New System.Drawing.Size(95, 20)
        Me.dtp2.TabIndex = 1011
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.Black
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(618, 1)
        Me.Panel9.TabIndex = 905707
        '
        'FrmTrnTerimaNotaDiPabrik
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(618, 372)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmTrnTerimaNotaDiPabrik"
        Me.Text = "Transaksi Trima Nota Di Pabrik"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents rdPulsaListrik As RadioButton
    Friend WithEvents rdPurchaser As RadioButton
    Friend WithEvents rdPancang As RadioButton
    Friend WithEvents rdAllPenggunaan As RadioButton
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label9 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents rdBlmTerima As RadioButton
    Friend WithEvents dtp2 As DateTimePicker
    Friend WithEvents rdSdhTerima As RadioButton
    Friend WithEvents dtp1 As DateTimePicker
    Friend WithEvents rdAll As RadioButton
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents CmbPancang As ComboBox
    Friend WithEvents BtnExit As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents BtnCari As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel9 As Panel
End Class
