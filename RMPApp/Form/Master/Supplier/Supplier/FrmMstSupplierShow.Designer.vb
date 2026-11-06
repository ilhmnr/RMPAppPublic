Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMstSupplierShow
    Inherits DockContent

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMstSupplierShow))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.TxtSupplier = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.ChkFilterFoto = New System.Windows.Forms.CheckBox()
        Me.ChkfilterKtp = New System.Windows.Forms.CheckBox()
        Me.ChkFilterKk = New System.Windows.Forms.CheckBox()
        Me.ChkFilterNpwp = New System.Windows.Forms.CheckBox()
        Me.ChkFilterCV = New System.Windows.Forms.CheckBox()
        Me.cmbPancang = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.rdAllStatus = New System.Windows.Forms.RadioButton()
        Me.rdTidakAktif = New System.Windows.Forms.RadioButton()
        Me.rdAktif = New System.Windows.Forms.RadioButton()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ocx = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chkTanggal = New System.Windows.Forms.CheckBox()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.ocx, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(43, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(219, 28)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Master Supplier Show"
        '
        'Panel4
        '
        Me.Panel4.BackgroundImage = CType(resources.GetObject("Panel4.BackgroundImage"), System.Drawing.Image)
        Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel4.Location = New System.Drawing.Point(5, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(35, 35)
        Me.Panel4.TabIndex = 3
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(119, 35)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(105, 22)
        Me.DateTimePicker1.TabIndex = 83
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(260, 35)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(105, 22)
        Me.DateTimePicker2.TabIndex = 84
        '
        'TxtSupplier
        '
        Me.TxtSupplier.Location = New System.Drawing.Point(119, 10)
        Me.TxtSupplier.Name = "TxtSupplier"
        Me.TxtSupplier.Size = New System.Drawing.Size(246, 22)
        Me.TxtSupplier.TabIndex = 82
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(7, 15)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(105, 13)
        Me.Label17.TabIndex = 76
        Me.Label17.Text = "Nama/Kode Suplier"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(7, 64)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(51, 13)
        Me.Label25.TabIndex = 77
        Me.Label25.Text = "Pancang"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.Red
        Me.Label18.Location = New System.Drawing.Point(740, 40)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(151, 13)
        Me.Label18.TabIndex = 78
        Me.Label18.Text = "Foto NPWP Belum diUpload"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.Color.Red
        Me.Label19.Location = New System.Drawing.Point(740, 15)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(195, 13)
        Me.Label19.TabIndex = 79
        Me.Label19.Text = "Foto NPWP Dan KTP Belum diUpload"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.Color.Red
        Me.Label20.Location = New System.Drawing.Point(740, 64)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(137, 13)
        Me.Label20.TabIndex = 80
        Me.Label20.Text = "Foto KTP Belum diUpload"
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Location = New System.Drawing.Point(715, 36)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(20, 20)
        Me.Panel7.TabIndex = 87
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Location = New System.Drawing.Point(715, 11)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(20, 20)
        Me.Panel8.TabIndex = 88
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel9.Location = New System.Drawing.Point(715, 60)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(20, 20)
        Me.Panel9.TabIndex = 89
        '
        'ChkFilterFoto
        '
        Me.ChkFilterFoto.AutoSize = True
        Me.ChkFilterFoto.Location = New System.Drawing.Point(486, 13)
        Me.ChkFilterFoto.Name = "ChkFilterFoto"
        Me.ChkFilterFoto.Size = New System.Drawing.Size(50, 17)
        Me.ChkFilterFoto.TabIndex = 90
        Me.ChkFilterFoto.Text = "Foto"
        Me.ChkFilterFoto.UseVisualStyleBackColor = True
        '
        'ChkfilterKtp
        '
        Me.ChkfilterKtp.AutoSize = True
        Me.ChkfilterKtp.Location = New System.Drawing.Point(542, 13)
        Me.ChkfilterKtp.Name = "ChkfilterKtp"
        Me.ChkfilterKtp.Size = New System.Drawing.Size(43, 17)
        Me.ChkfilterKtp.TabIndex = 91
        Me.ChkfilterKtp.Text = "Ktp"
        Me.ChkfilterKtp.UseVisualStyleBackColor = True
        '
        'ChkFilterKk
        '
        Me.ChkFilterKk.AutoSize = True
        Me.ChkFilterKk.Location = New System.Drawing.Point(591, 13)
        Me.ChkFilterKk.Name = "ChkFilterKk"
        Me.ChkFilterKk.Size = New System.Drawing.Size(38, 17)
        Me.ChkFilterKk.TabIndex = 92
        Me.ChkFilterKk.Text = "Kk"
        Me.ChkFilterKk.UseVisualStyleBackColor = True
        '
        'ChkFilterNpwp
        '
        Me.ChkFilterNpwp.AutoSize = True
        Me.ChkFilterNpwp.Location = New System.Drawing.Point(635, 13)
        Me.ChkFilterNpwp.Name = "ChkFilterNpwp"
        Me.ChkFilterNpwp.Size = New System.Drawing.Size(57, 17)
        Me.ChkFilterNpwp.TabIndex = 93
        Me.ChkFilterNpwp.Text = "Npwp"
        Me.ChkFilterNpwp.UseVisualStyleBackColor = True
        '
        'ChkFilterCV
        '
        Me.ChkFilterCV.AutoSize = True
        Me.ChkFilterCV.Location = New System.Drawing.Point(486, 62)
        Me.ChkFilterCV.Name = "ChkFilterCV"
        Me.ChkFilterCV.Size = New System.Drawing.Size(55, 17)
        Me.ChkFilterCV.TabIndex = 100
        Me.ChkFilterCV.Text = "PT/CV"
        Me.ChkFilterCV.UseVisualStyleBackColor = True
        '
        'cmbPancang
        '
        Me.cmbPancang.FormattingEnabled = True
        Me.cmbPancang.Location = New System.Drawing.Point(119, 60)
        Me.cmbPancang.Name = "cmbPancang"
        Me.cmbPancang.Size = New System.Drawing.Size(246, 21)
        Me.cmbPancang.TabIndex = 101
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(400, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 103
        Me.Label3.Text = "Belum Upload"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(231, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 13)
        Me.Label4.TabIndex = 104
        Me.Label4.Text = "s/d"
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.White
        Me.btnAdd.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(1012, 51)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btnAdd.Size = New System.Drawing.Size(75, 30)
        Me.btnAdd.TabIndex = 105
        Me.btnAdd.Text = "Refresh"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnExcel
        '
        Me.btnExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExcel.BackColor = System.Drawing.Color.White
        Me.btnExcel.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(1087, 51)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.btnExcel.Size = New System.Drawing.Size(75, 30)
        Me.btnExcel.TabIndex = 108
        Me.btnExcel.Text = "Excel"
        Me.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcel.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(400, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 109
        Me.Label5.Text = "Status"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.rdAllStatus)
        Me.Panel3.Controls.Add(Me.rdTidakAktif)
        Me.Panel3.Controls.Add(Me.rdAktif)
        Me.Panel3.Location = New System.Drawing.Point(486, 33)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(206, 25)
        Me.Panel3.TabIndex = 110
        '
        'rdAllStatus
        '
        Me.rdAllStatus.AutoSize = True
        Me.rdAllStatus.Checked = True
        Me.rdAllStatus.Location = New System.Drawing.Point(4, 4)
        Me.rdAllStatus.Name = "rdAllStatus"
        Me.rdAllStatus.Size = New System.Drawing.Size(38, 17)
        Me.rdAllStatus.TabIndex = 2
        Me.rdAllStatus.TabStop = True
        Me.rdAllStatus.Text = "All"
        Me.rdAllStatus.UseVisualStyleBackColor = True
        '
        'rdTidakAktif
        '
        Me.rdTidakAktif.AutoSize = True
        Me.rdTidakAktif.Location = New System.Drawing.Point(103, 4)
        Me.rdTidakAktif.Name = "rdTidakAktif"
        Me.rdTidakAktif.Size = New System.Drawing.Size(79, 17)
        Me.rdTidakAktif.TabIndex = 1
        Me.rdTidakAktif.Text = "Tidak Aktif"
        Me.rdTidakAktif.UseVisualStyleBackColor = True
        '
        'rdAktif
        '
        Me.rdAktif.AutoSize = True
        Me.rdAktif.Location = New System.Drawing.Point(48, 4)
        Me.rdAktif.Name = "rdAktif"
        Me.rdAktif.Size = New System.Drawing.Size(49, 17)
        Me.rdAktif.TabIndex = 0
        Me.rdAktif.Text = "Aktif"
        Me.rdAktif.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Black
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1247, 1)
        Me.Panel6.TabIndex = 905704
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.BackColor = System.Drawing.Color.White
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExit.Location = New System.Drawing.Point(1162, 51)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnExit.Size = New System.Drawing.Size(75, 30)
        Me.btnExit.TabIndex = 905705
        Me.btnExit.Text = "Exit"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.chkTanggal)
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.btnExcel)
        Me.Panel1.Controls.Add(Me.btnAdd)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.cmbPancang)
        Me.Panel1.Controls.Add(Me.ChkFilterCV)
        Me.Panel1.Controls.Add(Me.ChkFilterNpwp)
        Me.Panel1.Controls.Add(Me.ChkFilterKk)
        Me.Panel1.Controls.Add(Me.ChkfilterKtp)
        Me.Panel1.Controls.Add(Me.ChkFilterFoto)
        Me.Panel1.Controls.Add(Me.Panel9)
        Me.Panel1.Controls.Add(Me.Panel8)
        Me.Panel1.Controls.Add(Me.Panel7)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.TxtSupplier)
        Me.Panel1.Controls.Add(Me.DateTimePicker2)
        Me.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 40)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1247, 91)
        Me.Panel1.TabIndex = 0
        '
        'ocx
        '
        Me.ocx.ColumnInfo = resources.GetString("ocx.ColumnInfo")
        Me.ocx.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ocx.Location = New System.Drawing.Point(10, 0)
        Me.ocx.Name = "ocx"
        Me.ocx.Rows.Count = 1
        Me.ocx.Size = New System.Drawing.Size(1227, 389)
        Me.ocx.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ocx)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 131)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(10, 0, 10, 10)
        Me.Panel2.Size = New System.Drawing.Size(1247, 399)
        Me.Panel2.TabIndex = 0
        '
        'chkTanggal
        '
        Me.chkTanggal.AutoSize = True
        Me.chkTanggal.Checked = True
        Me.chkTanggal.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTanggal.Location = New System.Drawing.Point(10, 38)
        Me.chkTanggal.Name = "chkTanggal"
        Me.chkTanggal.Size = New System.Drawing.Size(66, 17)
        Me.chkTanggal.TabIndex = 905706
        Me.chkTanggal.Text = "Tanggal"
        Me.chkTanggal.UseVisualStyleBackColor = True
        '
        'FrmMstSupplierV2Show
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1247, 530)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FrmMstSupplierV2Show"
        Me.Padding = New System.Windows.Forms.Padding(0, 40, 0, 0)
        Me.Text = "Master Supplier Show"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.ocx, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents TxtSupplier As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents ChkFilterFoto As CheckBox
    Friend WithEvents ChkfilterKtp As CheckBox
    Friend WithEvents ChkFilterKk As CheckBox
    Friend WithEvents ChkFilterNpwp As CheckBox
    Friend WithEvents ChkFilterCV As CheckBox
    Friend WithEvents cmbPancang As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnExcel As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents rdAllStatus As RadioButton
    Friend WithEvents rdTidakAktif As RadioButton
    Friend WithEvents rdAktif As RadioButton
    Friend WithEvents Panel6 As Panel
    Friend WithEvents btnExit As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ocx As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel2 As Panel
    Friend WithEvents chkTanggal As CheckBox
End Class
