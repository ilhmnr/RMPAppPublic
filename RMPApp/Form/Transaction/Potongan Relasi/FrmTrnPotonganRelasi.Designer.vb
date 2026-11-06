Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTrnPotonganRelasi
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTrnPotonganRelasi))
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lblJudulForm = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.txtTotalDetail = New System.Windows.Forms.TextBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pnlFg = New System.Windows.Forms.Panel()
        Me.chkSelectAll = New System.Windows.Forms.CheckBox()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.cboKapal = New System.Windows.Forms.ComboBox()
        Me.cboPenerimaUang = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtNoTrans = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtTotalVoucher = New System.Windows.Forms.TextBox()
        Me.txtSudahTerpotong = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TxtSisaVoucher = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.CmbReffNo = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtRemark = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.rdTambangKapal = New System.Windows.Forms.RadioButton()
        Me.rdUpahBongkar = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rdSusut = New System.Windows.Forms.RadioButton()
        Me.rdOlahGerak = New System.Windows.Forms.RadioButton()
        Me.rdBPJS = New System.Windows.Forms.RadioButton()
        Me.rdGPS = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlFg.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Silver
        Me.Panel5.Controls.Add(Me.lblJudulForm)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1198, 30)
        Me.Panel5.TabIndex = 905657
        '
        'lblJudulForm
        '
        Me.lblJudulForm.AutoSize = True
        Me.lblJudulForm.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJudulForm.ForeColor = System.Drawing.Color.Black
        Me.lblJudulForm.Location = New System.Drawing.Point(378, 2)
        Me.lblJudulForm.Name = "lblJudulForm"
        Me.lblJudulForm.Size = New System.Drawing.Size(270, 25)
        Me.lblJudulForm.TabIndex = 0
        Me.lblJudulForm.Text = "Transaksi Potongan Relasi"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        Me.btnSave.Location = New System.Drawing.Point(969, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 30)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnExit.ForeColor = System.Drawing.Color.Black
        Me.btnExit.Location = New System.Drawing.Point(1119, 3)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 30)
        Me.btnExit.TabIndex = 13
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.txtTotalDetail)
        Me.Panel4.Controls.Add(Me.btnDelete)
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Controls.Add(Me.btnExit)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 5)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1200, 40)
        Me.Panel4.TabIndex = 0
        '
        'txtTotalDetail
        '
        Me.txtTotalDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalDetail.Enabled = False
        Me.txtTotalDetail.Location = New System.Drawing.Point(74, 9)
        Me.txtTotalDetail.Name = "txtTotalDetail"
        Me.txtTotalDetail.Size = New System.Drawing.Size(118, 20)
        Me.txtTotalDetail.TabIndex = 905683
        Me.txtTotalDetail.Text = "0"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnDelete.ForeColor = System.Drawing.Color.Black
        Me.btnDelete.Location = New System.Drawing.Point(1044, 3)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 30)
        Me.btnDelete.TabIndex = 13
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Total Detail"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 412)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Panel3.Size = New System.Drawing.Size(1200, 45)
        Me.Panel3.TabIndex = 0
        '
        'pnlFg
        '
        Me.pnlFg.BackColor = System.Drawing.Color.White
        Me.pnlFg.Controls.Add(Me.chkSelectAll)
        Me.pnlFg.Controls.Add(Me.fg)
        Me.pnlFg.Controls.Add(Me.Panel3)
        Me.pnlFg.Controls.Add(Me.cboKapal)
        Me.pnlFg.Controls.Add(Me.cboPenerimaUang)
        Me.pnlFg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlFg.Location = New System.Drawing.Point(5, 183)
        Me.pnlFg.Name = "pnlFg"
        Me.pnlFg.Padding = New System.Windows.Forms.Padding(0, 30, 0, 0)
        Me.pnlFg.Size = New System.Drawing.Size(1200, 457)
        Me.pnlFg.TabIndex = 5
        '
        'chkSelectAll
        '
        Me.chkSelectAll.AutoSize = True
        Me.chkSelectAll.Location = New System.Drawing.Point(11, 7)
        Me.chkSelectAll.Name = "chkSelectAll"
        Me.chkSelectAll.Size = New System.Drawing.Size(70, 17)
        Me.chkSelectAll.TabIndex = 2
        Me.chkSelectAll.Text = "Select All"
        Me.chkSelectAll.UseVisualStyleBackColor = True
        '
        'fg
        '
        Me.fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.fg.ColumnInfo = resources.GetString("fg.ColumnInfo")
        Me.fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fg.Location = New System.Drawing.Point(0, 30)
        Me.fg.Name = "fg"
        Me.fg.Rows.Count = 1
        Me.fg.Size = New System.Drawing.Size(1200, 382)
        Me.fg.TabIndex = 1
        '
        'cboKapal
        '
        Me.cboKapal.FormattingEnabled = True
        Me.cboKapal.IntegralHeight = False
        Me.cboKapal.ItemHeight = 13
        Me.cboKapal.Location = New System.Drawing.Point(1129, 4)
        Me.cboKapal.Name = "cboKapal"
        Me.cboKapal.Size = New System.Drawing.Size(30, 21)
        Me.cboKapal.TabIndex = 905677
        Me.cboKapal.Visible = False
        '
        'cboPenerimaUang
        '
        Me.cboPenerimaUang.FormattingEnabled = True
        Me.cboPenerimaUang.IntegralHeight = False
        Me.cboPenerimaUang.ItemHeight = 13
        Me.cboPenerimaUang.Location = New System.Drawing.Point(1165, 4)
        Me.cboPenerimaUang.Name = "cboPenerimaUang"
        Me.cboPenerimaUang.Size = New System.Drawing.Size(30, 21)
        Me.cboPenerimaUang.TabIndex = 905677
        Me.cboPenerimaUang.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Potongan"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtNoTrans)
        Me.Panel1.Controls.Add(Me.Label24)
        Me.Panel1.Controls.Add(Me.txtTotalVoucher)
        Me.Panel1.Controls.Add(Me.txtSudahTerpotong)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.TxtSisaVoucher)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.CmbReffNo)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.TxtRemark)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(5, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1200, 178)
        Me.Panel1.TabIndex = 6
        '
        'txtNoTrans
        '
        Me.txtNoTrans.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNoTrans.Enabled = False
        Me.txtNoTrans.Location = New System.Drawing.Point(136, 43)
        Me.txtNoTrans.Name = "txtNoTrans"
        Me.txtNoTrans.Size = New System.Drawing.Size(251, 20)
        Me.txtNoTrans.TabIndex = 905683
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(698, 146)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(118, 17)
        Me.Label24.TabIndex = 905682
        Me.Label24.Text = "Sudah Terpotong"
        '
        'txtTotalVoucher
        '
        Me.txtTotalVoucher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalVoucher.Enabled = False
        Me.txtTotalVoucher.Location = New System.Drawing.Point(577, 144)
        Me.txtTotalVoucher.Name = "txtTotalVoucher"
        Me.txtTotalVoucher.Size = New System.Drawing.Size(91, 20)
        Me.txtTotalVoucher.TabIndex = 905681
        '
        'txtSudahTerpotong
        '
        Me.txtSudahTerpotong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSudahTerpotong.Enabled = False
        Me.txtSudahTerpotong.Location = New System.Drawing.Point(822, 144)
        Me.txtSudahTerpotong.Name = "txtSudahTerpotong"
        Me.txtSudahTerpotong.Size = New System.Drawing.Size(91, 20)
        Me.txtSudahTerpotong.TabIndex = 905681
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(947, 146)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(89, 17)
        Me.Label22.TabIndex = 905679
        Me.Label22.Text = "Sisa Voucher"
        '
        'TxtSisaVoucher
        '
        Me.TxtSisaVoucher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSisaVoucher.Enabled = False
        Me.TxtSisaVoucher.Location = New System.Drawing.Point(1042, 144)
        Me.TxtSisaVoucher.Name = "TxtSisaVoucher"
        Me.TxtSisaVoucher.Size = New System.Drawing.Size(91, 20)
        Me.TxtSisaVoucher.TabIndex = 905678
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(412, 45)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 17)
        Me.Label15.TabIndex = 905673
        Me.Label15.Text = "Reff No"
        '
        'CmbReffNo
        '
        Me.CmbReffNo.FormattingEnabled = True
        Me.CmbReffNo.IntegralHeight = False
        Me.CmbReffNo.ItemHeight = 13
        Me.CmbReffNo.Location = New System.Drawing.Point(475, 43)
        Me.CmbReffNo.Name = "CmbReffNo"
        Me.CmbReffNo.Size = New System.Drawing.Size(658, 21)
        Me.CmbReffNo.TabIndex = 905677
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(474, 146)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 17)
        Me.Label6.TabIndex = 905672
        Me.Label6.Text = "Total Voucher"
        '
        'TxtRemark
        '
        Me.TxtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtRemark.Enabled = False
        Me.TxtRemark.Location = New System.Drawing.Point(475, 66)
        Me.TxtRemark.Multiline = True
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(658, 75)
        Me.TxtRemark.TabIndex = 905669
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(412, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 17)
        Me.Label1.TabIndex = 905671
        Me.Label1.Text = "Remark"
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.rdTambangKapal)
        Me.Panel6.Controls.Add(Me.rdUpahBongkar)
        Me.Panel6.Location = New System.Drawing.Point(136, 92)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(256, 25)
        Me.Panel6.TabIndex = 905668
        '
        'rdTambangKapal
        '
        Me.rdTambangKapal.AutoSize = True
        Me.rdTambangKapal.Location = New System.Drawing.Point(4, 4)
        Me.rdTambangKapal.Name = "rdTambangKapal"
        Me.rdTambangKapal.Size = New System.Drawing.Size(100, 17)
        Me.rdTambangKapal.TabIndex = 905667
        Me.rdTambangKapal.Text = "Tambang Kapal"
        Me.rdTambangKapal.UseVisualStyleBackColor = True
        '
        'rdUpahBongkar
        '
        Me.rdUpahBongkar.AutoSize = True
        Me.rdUpahBongkar.Location = New System.Drawing.Point(110, 4)
        Me.rdUpahBongkar.Name = "rdUpahBongkar"
        Me.rdUpahBongkar.Size = New System.Drawing.Size(94, 17)
        Me.rdUpahBongkar.TabIndex = 905667
        Me.rdUpahBongkar.Text = "Upah Bongkar"
        Me.rdUpahBongkar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Potongan Transaksi"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rdSusut)
        Me.Panel2.Controls.Add(Me.rdOlahGerak)
        Me.Panel2.Controls.Add(Me.rdBPJS)
        Me.Panel2.Controls.Add(Me.rdGPS)
        Me.Panel2.Location = New System.Drawing.Point(136, 65)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(256, 25)
        Me.Panel2.TabIndex = 905668
        '
        'rdSusut
        '
        Me.rdSusut.AutoSize = True
        Me.rdSusut.Location = New System.Drawing.Point(4, 4)
        Me.rdSusut.Name = "rdSusut"
        Me.rdSusut.Size = New System.Drawing.Size(52, 17)
        Me.rdSusut.TabIndex = 905667
        Me.rdSusut.Text = "Susut"
        Me.rdSusut.UseVisualStyleBackColor = True
        '
        'rdOlahGerak
        '
        Me.rdOlahGerak.AutoSize = True
        Me.rdOlahGerak.Location = New System.Drawing.Point(62, 4)
        Me.rdOlahGerak.Name = "rdOlahGerak"
        Me.rdOlahGerak.Size = New System.Drawing.Size(79, 17)
        Me.rdOlahGerak.TabIndex = 905667
        Me.rdOlahGerak.Text = "Olah Gerak"
        Me.rdOlahGerak.UseVisualStyleBackColor = True
        '
        'rdBPJS
        '
        Me.rdBPJS.AutoSize = True
        Me.rdBPJS.Location = New System.Drawing.Point(147, 4)
        Me.rdBPJS.Name = "rdBPJS"
        Me.rdBPJS.Size = New System.Drawing.Size(51, 17)
        Me.rdBPJS.TabIndex = 905667
        Me.rdBPJS.Text = "BPJS"
        Me.rdBPJS.UseVisualStyleBackColor = True
        '
        'rdGPS
        '
        Me.rdGPS.AutoSize = True
        Me.rdGPS.Location = New System.Drawing.Point(204, 4)
        Me.rdGPS.Name = "rdGPS"
        Me.rdGPS.Size = New System.Drawing.Size(47, 17)
        Me.rdGPS.TabIndex = 905667
        Me.rdGPS.Text = "GPS"
        Me.rdGPS.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "No Trans"
        '
        'FrmTrnPotonganRelasi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1210, 645)
        Me.Controls.Add(Me.pnlFg)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmTrnPotonganRelasi"
        Me.Padding = New System.Windows.Forms.Padding(5)
        Me.Text = "Transaksi Potongan Relasi"
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.pnlFg.ResumeLayout(False)
        Me.pnlFg.PerformLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel5 As Panel
    Friend WithEvents lblJudulForm As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents pnlFg As Panel
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents rdGPS As RadioButton
    Friend WithEvents rdBPJS As RadioButton
    Friend WithEvents Panel6 As Panel
    Friend WithEvents rdTambangKapal As RadioButton
    Friend WithEvents rdUpahBongkar As RadioButton
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label24 As Label
    Friend WithEvents txtSudahTerpotong As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents TxtSisaVoucher As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents CmbReffNo As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtRemark As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtTotalVoucher As TextBox
    Friend WithEvents btnDelete As Button
    Friend WithEvents chkSelectAll As CheckBox
    Friend WithEvents txtNoTrans As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents rdSusut As RadioButton
    Friend WithEvents rdOlahGerak As RadioButton
    Friend WithEvents cboPenerimaUang As ComboBox
    Friend WithEvents txtTotalDetail As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cboKapal As ComboBox
End Class
