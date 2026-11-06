Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTrnTambangKapalBPI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTrnTambangKapalBPI))
        Me.lblJudulForm = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.pnlFg = New System.Windows.Forms.Panel()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtHeaderID = New System.Windows.Forms.TextBox()
        Me.cboNoTransOlahGerak = New System.Windows.Forms.ComboBox()
        Me.cboNoTransBPJS = New System.Windows.Forms.ComboBox()
        Me.cboNoTransGPS = New System.Windows.Forms.ComboBox()
        Me.cboNoTransSusut = New System.Windows.Forms.ComboBox()
        Me.cboPenerimaUang = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnFindKapal = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpTanggalPengajuan = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIDAsuransi = New System.Windows.Forms.TextBox()
        Me.txtNoTrans = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlFg.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblJudulForm
        '
        Me.lblJudulForm.AutoSize = True
        Me.lblJudulForm.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJudulForm.ForeColor = System.Drawing.Color.Black
        Me.lblJudulForm.Location = New System.Drawing.Point(378, 2)
        Me.lblJudulForm.Name = "lblJudulForm"
        Me.lblJudulForm.Size = New System.Drawing.Size(326, 25)
        Me.lblJudulForm.TabIndex = 0
        Me.lblJudulForm.Text = "TRANSAKSI TAMBANG KAPAL"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        Me.btnSave.Location = New System.Drawing.Point(1075, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 30)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Silver
        Me.Panel5.Controls.Add(Me.lblJudulForm)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1235, 30)
        Me.Panel5.TabIndex = 905657
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 436)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Panel3.Size = New System.Drawing.Size(1237, 45)
        Me.Panel3.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Controls.Add(Me.btnCancel)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 5)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1237, 40)
        Me.Panel4.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Location = New System.Drawing.Point(1156, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 30)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "Close"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'pnlFg
        '
        Me.pnlFg.BackColor = System.Drawing.Color.White
        Me.pnlFg.Controls.Add(Me.fg)
        Me.pnlFg.Controls.Add(Me.Panel3)
        Me.pnlFg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlFg.Location = New System.Drawing.Point(0, 122)
        Me.pnlFg.Name = "pnlFg"
        Me.pnlFg.Size = New System.Drawing.Size(1237, 481)
        Me.pnlFg.TabIndex = 1
        '
        'fg
        '
        Me.fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.fg.ColumnInfo = resources.GetString("fg.ColumnInfo")
        Me.fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fg.Location = New System.Drawing.Point(0, 0)
        Me.fg.Name = "fg"
        Me.fg.Rows.Count = 1
        Me.fg.Size = New System.Drawing.Size(1237, 436)
        Me.fg.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtHeaderID)
        Me.Panel1.Controls.Add(Me.cboNoTransOlahGerak)
        Me.Panel1.Controls.Add(Me.cboNoTransBPJS)
        Me.Panel1.Controls.Add(Me.cboNoTransGPS)
        Me.Panel1.Controls.Add(Me.cboNoTransSusut)
        Me.Panel1.Controls.Add(Me.cboPenerimaUang)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.btnFindKapal)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.dtpTanggalPengajuan)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtIDAsuransi)
        Me.Panel1.Controls.Add(Me.txtNoTrans)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1237, 122)
        Me.Panel1.TabIndex = 2
        '
        'txtHeaderID
        '
        Me.txtHeaderID.Enabled = False
        Me.txtHeaderID.Location = New System.Drawing.Point(89, 51)
        Me.txtHeaderID.Name = "txtHeaderID"
        Me.txtHeaderID.Size = New System.Drawing.Size(19, 20)
        Me.txtHeaderID.TabIndex = 905659
        Me.txtHeaderID.Visible = False
        '
        'cboNoTransOlahGerak
        '
        Me.cboNoTransOlahGerak.FormattingEnabled = True
        Me.cboNoTransOlahGerak.Location = New System.Drawing.Point(881, 66)
        Me.cboNoTransOlahGerak.Name = "cboNoTransOlahGerak"
        Me.cboNoTransOlahGerak.Size = New System.Drawing.Size(227, 21)
        Me.cboNoTransOlahGerak.TabIndex = 905658
        '
        'cboNoTransBPJS
        '
        Me.cboNoTransBPJS.FormattingEnabled = True
        Me.cboNoTransBPJS.Location = New System.Drawing.Point(881, 39)
        Me.cboNoTransBPJS.Name = "cboNoTransBPJS"
        Me.cboNoTransBPJS.Size = New System.Drawing.Size(227, 21)
        Me.cboNoTransBPJS.TabIndex = 905658
        '
        'cboNoTransGPS
        '
        Me.cboNoTransGPS.FormattingEnabled = True
        Me.cboNoTransGPS.Location = New System.Drawing.Point(537, 93)
        Me.cboNoTransGPS.Name = "cboNoTransGPS"
        Me.cboNoTransGPS.Size = New System.Drawing.Size(227, 21)
        Me.cboNoTransGPS.TabIndex = 905658
        '
        'cboNoTransSusut
        '
        Me.cboNoTransSusut.FormattingEnabled = True
        Me.cboNoTransSusut.Location = New System.Drawing.Point(537, 66)
        Me.cboNoTransSusut.Name = "cboNoTransSusut"
        Me.cboNoTransSusut.Size = New System.Drawing.Size(227, 21)
        Me.cboNoTransSusut.TabIndex = 905658
        '
        'cboPenerimaUang
        '
        Me.cboPenerimaUang.FormattingEnabled = True
        Me.cboPenerimaUang.Location = New System.Drawing.Point(537, 37)
        Me.cboPenerimaUang.Name = "cboPenerimaUang"
        Me.cboPenerimaUang.Size = New System.Drawing.Size(227, 21)
        Me.cboPenerimaUang.TabIndex = 905658
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(797, 98)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "ID Asuransi"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(797, 71)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Pot Olah Gerak"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(797, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Pot BPJS"
        '
        'btnFindKapal
        '
        Me.btnFindKapal.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnFindKapal.ForeColor = System.Drawing.Color.Black
        Me.btnFindKapal.Location = New System.Drawing.Point(347, 67)
        Me.btnFindKapal.Name = "btnFindKapal"
        Me.btnFindKapal.Size = New System.Drawing.Size(75, 30)
        Me.btnFindKapal.TabIndex = 13
        Me.btnFindKapal.Text = "Find Kapal"
        Me.btnFindKapal.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(450, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Pot GPS"
        '
        'dtpTanggalPengajuan
        '
        Me.dtpTanggalPengajuan.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTanggalPengajuan.Location = New System.Drawing.Point(114, 77)
        Me.dtpTanggalPengajuan.Name = "dtpTanggalPengajuan"
        Me.dtpTanggalPengajuan.Size = New System.Drawing.Size(227, 20)
        Me.dtpTanggalPengajuan.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(450, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Pot Susut"
        '
        'txtIDAsuransi
        '
        Me.txtIDAsuransi.Enabled = False
        Me.txtIDAsuransi.Location = New System.Drawing.Point(881, 93)
        Me.txtIDAsuransi.Name = "txtIDAsuransi"
        Me.txtIDAsuransi.Size = New System.Drawing.Size(227, 20)
        Me.txtIDAsuransi.TabIndex = 11
        '
        'txtNoTrans
        '
        Me.txtNoTrans.Enabled = False
        Me.txtNoTrans.Location = New System.Drawing.Point(114, 51)
        Me.txtNoTrans.Name = "txtNoTrans"
        Me.txtNoTrans.Size = New System.Drawing.Size(227, 20)
        Me.txtNoTrans.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(450, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Penerima Uang"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Tanggal Pengajuan"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "No Trans"
        '
        'FrmTrnTambangKapalBPI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1237, 603)
        Me.Controls.Add(Me.pnlFg)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmTrnTambangKapalBPI"
        Me.Text = "Transaksi Tambang Kapal"
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.pnlFg.ResumeLayout(False)
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblJudulForm As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnCancel As Button
    Friend WithEvents pnlFg As Panel
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnFindKapal As Button
    Friend WithEvents dtpTanggalPengajuan As DateTimePicker
    Friend WithEvents txtNoTrans As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cboPenerimaUang As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cboNoTransGPS As ComboBox
    Friend WithEvents cboNoTransSusut As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cboNoTransOlahGerak As ComboBox
    Friend WithEvents cboNoTransBPJS As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtIDAsuransi As TextBox
    Friend WithEvents txtHeaderID As TextBox
End Class
