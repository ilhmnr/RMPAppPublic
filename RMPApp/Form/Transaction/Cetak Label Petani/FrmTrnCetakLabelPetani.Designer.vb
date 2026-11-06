Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTrnCetakLabelPetani
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTrnCetakLabelPetani))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnCetakLabel = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.cbxSelectAll = New System.Windows.Forms.CheckBox()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.lblSudahPrint = New System.Windows.Forms.Label()
        Me.lblBelumPrint = New System.Windows.Forms.Label()
        Me.lblTotalData = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.dtpTglAkhir = New System.Windows.Forms.DateTimePicker()
        Me.dtpTglAwal = New System.Windows.Forms.DateTimePicker()
        Me.cmbStatusPrint = New System.Windows.Forms.ComboBox()
        Me.cmbFotoPetani = New System.Windows.Forms.ComboBox()
        Me.cmbJenisPetani = New System.Windows.Forms.ComboBox()
        Me.cmbPancang = New System.Windows.Forms.ComboBox()
        Me.chkPeriode = New System.Windows.Forms.CheckBox()
        Me.chkPancang = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Panel8)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(827, 40)
        Me.Panel1.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(46, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(279, 28)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Transaksi Cetak Label Petani"
        '
        'Panel8
        '
        Me.Panel8.BackgroundImage = CType(resources.GetObject("Panel8.BackgroundImage"), System.Drawing.Image)
        Me.Panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel8.Location = New System.Drawing.Point(10, 3)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(35, 35)
        Me.Panel8.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnClose)
        Me.Panel2.Controls.Add(Me.btnCetakLabel)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 453)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(827, 40)
        Me.Panel2.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.White
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(742, 5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnClose.Size = New System.Drawing.Size(75, 30)
        Me.btnClose.TabIndex = 13
        Me.btnClose.Text = "Exit"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnCetakLabel
        '
        Me.btnCetakLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCetakLabel.BackColor = System.Drawing.Color.White
        Me.btnCetakLabel.Image = CType(resources.GetObject("btnCetakLabel.Image"), System.Drawing.Image)
        Me.btnCetakLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCetakLabel.Location = New System.Drawing.Point(611, 5)
        Me.btnCetakLabel.Name = "btnCetakLabel"
        Me.btnCetakLabel.Padding = New System.Windows.Forms.Padding(5, 0, 3, 0)
        Me.btnCetakLabel.Size = New System.Drawing.Size(130, 30)
        Me.btnCetakLabel.TabIndex = 10
        Me.btnCetakLabel.Text = "Generate && Print"
        Me.btnCetakLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCetakLabel.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 40)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(827, 413)
        Me.Panel3.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.White
        Me.Panel5.Controls.Add(Me.Panel7)
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 91)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(827, 322)
        Me.Panel5.TabIndex = 0
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.fg)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(0, 42)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Padding = New System.Windows.Forms.Padding(10, 0, 10, 10)
        Me.Panel7.Size = New System.Drawing.Size(827, 280)
        Me.Panel7.TabIndex = 0
        '
        'fg
        '
        Me.fg.AutoClipboard = True
        Me.fg.ColumnInfo = resources.GetString("fg.ColumnInfo")
        Me.fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fg.Location = New System.Drawing.Point(10, 0)
        Me.fg.Name = "fg"
        Me.fg.Size = New System.Drawing.Size(807, 270)
        Me.fg.TabIndex = 0
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.cbxSelectAll)
        Me.Panel6.Controls.Add(Me.Panel10)
        Me.Panel6.Controls.Add(Me.btnSearch)
        Me.Panel6.Controls.Add(Me.txtSearch)
        Me.Panel6.Controls.Add(Me.lblSudahPrint)
        Me.Panel6.Controls.Add(Me.lblBelumPrint)
        Me.Panel6.Controls.Add(Me.lblTotalData)
        Me.Panel6.Controls.Add(Me.Label8)
        Me.Panel6.Controls.Add(Me.Label6)
        Me.Panel6.Controls.Add(Me.Label3)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(827, 42)
        Me.Panel6.TabIndex = 0
        '
        'cbxSelectAll
        '
        Me.cbxSelectAll.AutoSize = True
        Me.cbxSelectAll.Location = New System.Drawing.Point(10, 13)
        Me.cbxSelectAll.Name = "cbxSelectAll"
        Me.cbxSelectAll.Size = New System.Drawing.Size(72, 17)
        Me.cbxSelectAll.TabIndex = 905705
        Me.cbxSelectAll.Text = "Select All"
        Me.cbxSelectAll.UseVisualStyleBackColor = True
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.Black
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel10.Location = New System.Drawing.Point(0, 0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(827, 1)
        Me.Panel10.TabIndex = 905704
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.White
        Me.btnSearch.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(289, 6)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnSearch.Size = New System.Drawing.Size(75, 30)
        Me.btnSearch.TabIndex = 8
        Me.btnSearch.Text = "Search"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(88, 10)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(200, 22)
        Me.txtSearch.TabIndex = 4
        '
        'lblSudahPrint
        '
        Me.lblSudahPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSudahPrint.AutoSize = True
        Me.lblSudahPrint.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSudahPrint.Location = New System.Drawing.Point(767, 7)
        Me.lblSudahPrint.Name = "lblSudahPrint"
        Me.lblSudahPrint.Size = New System.Drawing.Size(48, 28)
        Me.lblSudahPrint.TabIndex = 0
        Me.lblSudahPrint.Text = "000"
        '
        'lblBelumPrint
        '
        Me.lblBelumPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBelumPrint.AutoSize = True
        Me.lblBelumPrint.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBelumPrint.Location = New System.Drawing.Point(638, 7)
        Me.lblBelumPrint.Name = "lblBelumPrint"
        Me.lblBelumPrint.Size = New System.Drawing.Size(48, 28)
        Me.lblBelumPrint.TabIndex = 0
        Me.lblBelumPrint.Text = "000"
        '
        'lblTotalData
        '
        Me.lblTotalData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalData.AutoSize = True
        Me.lblTotalData.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalData.Location = New System.Drawing.Point(509, 7)
        Me.lblTotalData.Name = "lblTotalData"
        Me.lblTotalData.Size = New System.Drawing.Size(48, 28)
        Me.lblTotalData.TabIndex = 0
        Me.lblTotalData.Text = "000"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(700, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Sudah Print"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(573, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Belum Print"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(451, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Total Data"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.Panel9)
        Me.Panel4.Controls.Add(Me.dtpTglAkhir)
        Me.Panel4.Controls.Add(Me.dtpTglAwal)
        Me.Panel4.Controls.Add(Me.cmbStatusPrint)
        Me.Panel4.Controls.Add(Me.cmbFotoPetani)
        Me.Panel4.Controls.Add(Me.cmbJenisPetani)
        Me.Panel4.Controls.Add(Me.cmbPancang)
        Me.Panel4.Controls.Add(Me.chkPeriode)
        Me.Panel4.Controls.Add(Me.chkPancang)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(827, 91)
        Me.Panel4.TabIndex = 0
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.Black
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(827, 1)
        Me.Panel9.TabIndex = 905704
        '
        'dtpTglAkhir
        '
        Me.dtpTglAkhir.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTglAkhir.Location = New System.Drawing.Point(635, 35)
        Me.dtpTglAkhir.Name = "dtpTglAkhir"
        Me.dtpTglAkhir.Size = New System.Drawing.Size(121, 22)
        Me.dtpTglAkhir.TabIndex = 3
        '
        'dtpTglAwal
        '
        Me.dtpTglAwal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTglAwal.Location = New System.Drawing.Point(479, 35)
        Me.dtpTglAwal.Name = "dtpTglAwal"
        Me.dtpTglAwal.Size = New System.Drawing.Size(121, 22)
        Me.dtpTglAwal.TabIndex = 3
        '
        'cmbStatusPrint
        '
        Me.cmbStatusPrint.FormattingEnabled = True
        Me.cmbStatusPrint.Location = New System.Drawing.Point(479, 11)
        Me.cmbStatusPrint.Name = "cmbStatusPrint"
        Me.cmbStatusPrint.Size = New System.Drawing.Size(277, 21)
        Me.cmbStatusPrint.TabIndex = 2
        '
        'cmbFotoPetani
        '
        Me.cmbFotoPetani.FormattingEnabled = True
        Me.cmbFotoPetani.Location = New System.Drawing.Point(79, 61)
        Me.cmbFotoPetani.Name = "cmbFotoPetani"
        Me.cmbFotoPetani.Size = New System.Drawing.Size(277, 21)
        Me.cmbFotoPetani.TabIndex = 2
        '
        'cmbJenisPetani
        '
        Me.cmbJenisPetani.FormattingEnabled = True
        Me.cmbJenisPetani.Location = New System.Drawing.Point(79, 36)
        Me.cmbJenisPetani.Name = "cmbJenisPetani"
        Me.cmbJenisPetani.Size = New System.Drawing.Size(277, 21)
        Me.cmbJenisPetani.TabIndex = 2
        '
        'cmbPancang
        '
        Me.cmbPancang.FormattingEnabled = True
        Me.cmbPancang.Location = New System.Drawing.Point(79, 11)
        Me.cmbPancang.Name = "cmbPancang"
        Me.cmbPancang.Size = New System.Drawing.Size(277, 21)
        Me.cmbPancang.TabIndex = 2
        '
        'chkPeriode
        '
        Me.chkPeriode.AutoSize = True
        Me.chkPeriode.Checked = True
        Me.chkPeriode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPeriode.Location = New System.Drawing.Point(385, 38)
        Me.chkPeriode.Name = "chkPeriode"
        Me.chkPeriode.Size = New System.Drawing.Size(66, 17)
        Me.chkPeriode.TabIndex = 1
        Me.chkPeriode.Text = "Tanggal"
        Me.chkPeriode.UseVisualStyleBackColor = True
        '
        'chkPancang
        '
        Me.chkPancang.AutoSize = True
        Me.chkPancang.Location = New System.Drawing.Point(10, 13)
        Me.chkPancang.Name = "chkPancang"
        Me.chkPancang.Size = New System.Drawing.Size(70, 17)
        Me.chkPancang.TabIndex = 1
        Me.chkPancang.Text = "Pancang"
        Me.chkPancang.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(606, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "s/d"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 65)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Foto Petani"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(385, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Status Print"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Jenis Petani"
        '
        'FrmTrnCetakLabelPetani
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(827, 493)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FrmTrnCetakLabelPetani"
        Me.Text = "Transaksi Cetak Label Petani"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpTglAkhir As DateTimePicker
    Friend WithEvents dtpTglAwal As DateTimePicker
    Friend WithEvents cmbStatusPrint As ComboBox
    Friend WithEvents cmbJenisPetani As ComboBox
    Friend WithEvents cmbPancang As ComboBox
    Friend WithEvents chkPancang As CheckBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents chkPeriode As CheckBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents lblSudahPrint As Label
    Friend WithEvents lblBelumPrint As Label
    Friend WithEvents lblTotalData As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents btnClose As Button
    Friend WithEvents btnCetakLabel As Button
    Friend WithEvents cbxSelectAll As CheckBox
    Friend WithEvents cmbFotoPetani As ComboBox
    Friend WithEvents Label7 As Label
End Class
