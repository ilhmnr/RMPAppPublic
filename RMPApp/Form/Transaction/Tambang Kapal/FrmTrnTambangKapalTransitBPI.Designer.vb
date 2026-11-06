Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTrnTambangKapalTransitBPI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTrnTambangKapalTransitBPI))
        Me.cboNoTransOlahGerak = New System.Windows.Forms.ComboBox()
        Me.cboNoTransBPJS = New System.Windows.Forms.ComboBox()
        Me.cboNoTransGPS = New System.Windows.Forms.ComboBox()
        Me.cboNoTransSusut = New System.Windows.Forms.ComboBox()
        Me.cboPenerimaUang = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lblJudulForm = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpTanggalPengajuan = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIDAsuransi = New System.Windows.Forms.TextBox()
        Me.txtNoTrans = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlFg = New System.Windows.Forms.Panel()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtTrip = New System.Windows.Forms.TextBox()
        Me.cboKapal = New System.Windows.Forms.ComboBox()
        Me.cboToPancang = New System.Windows.Forms.ComboBox()
        Me.cboFromPancang = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtKodeGroupNota = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel5.SuspendLayout()
        Me.pnlFg.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboNoTransOlahGerak
        '
        Me.cboNoTransOlahGerak.FormattingEnabled = True
        Me.cboNoTransOlahGerak.Location = New System.Drawing.Point(580, 140)
        Me.cboNoTransOlahGerak.Name = "cboNoTransOlahGerak"
        Me.cboNoTransOlahGerak.Size = New System.Drawing.Size(227, 21)
        Me.cboNoTransOlahGerak.TabIndex = 905658
        '
        'cboNoTransBPJS
        '
        Me.cboNoTransBPJS.FormattingEnabled = True
        Me.cboNoTransBPJS.Location = New System.Drawing.Point(580, 116)
        Me.cboNoTransBPJS.Name = "cboNoTransBPJS"
        Me.cboNoTransBPJS.Size = New System.Drawing.Size(227, 21)
        Me.cboNoTransBPJS.TabIndex = 905658
        '
        'cboNoTransGPS
        '
        Me.cboNoTransGPS.FormattingEnabled = True
        Me.cboNoTransGPS.Location = New System.Drawing.Point(580, 92)
        Me.cboNoTransGPS.Name = "cboNoTransGPS"
        Me.cboNoTransGPS.Size = New System.Drawing.Size(227, 21)
        Me.cboNoTransGPS.TabIndex = 905658
        '
        'cboNoTransSusut
        '
        Me.cboNoTransSusut.FormattingEnabled = True
        Me.cboNoTransSusut.Location = New System.Drawing.Point(580, 69)
        Me.cboNoTransSusut.Name = "cboNoTransSusut"
        Me.cboNoTransSusut.Size = New System.Drawing.Size(227, 21)
        Me.cboNoTransSusut.TabIndex = 905658
        '
        'cboPenerimaUang
        '
        Me.cboPenerimaUang.FormattingEnabled = True
        Me.cboPenerimaUang.Location = New System.Drawing.Point(580, 46)
        Me.cboPenerimaUang.Name = "cboPenerimaUang"
        Me.cboPenerimaUang.Size = New System.Drawing.Size(227, 21)
        Me.cboPenerimaUang.TabIndex = 905658
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(494, 167)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "ID Asuransi"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Silver
        Me.Panel5.Controls.Add(Me.lblJudulForm)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1132, 30)
        Me.Panel5.TabIndex = 905657
        '
        'lblJudulForm
        '
        Me.lblJudulForm.AutoSize = True
        Me.lblJudulForm.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJudulForm.ForeColor = System.Drawing.Color.Black
        Me.lblJudulForm.Location = New System.Drawing.Point(378, 2)
        Me.lblJudulForm.Name = "lblJudulForm"
        Me.lblJudulForm.Size = New System.Drawing.Size(425, 25)
        Me.lblJudulForm.TabIndex = 0
        Me.lblJudulForm.Text = "TRANSAKSI TAMBANG KAPAL TRANSIT"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(494, 144)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Pot Olah Gerak"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(494, 120)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Pot BPJS"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(494, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Pot GPS"
        '
        'dtpTanggalPengajuan
        '
        Me.dtpTanggalPengajuan.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTanggalPengajuan.Location = New System.Drawing.Point(123, 69)
        Me.dtpTanggalPengajuan.Name = "dtpTanggalPengajuan"
        Me.dtpTanggalPengajuan.Size = New System.Drawing.Size(106, 20)
        Me.dtpTanggalPengajuan.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(494, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Pot Susut"
        '
        'txtIDAsuransi
        '
        Me.txtIDAsuransi.Enabled = False
        Me.txtIDAsuransi.Location = New System.Drawing.Point(580, 163)
        Me.txtIDAsuransi.Name = "txtIDAsuransi"
        Me.txtIDAsuransi.Size = New System.Drawing.Size(227, 20)
        Me.txtIDAsuransi.TabIndex = 11
        '
        'txtNoTrans
        '
        Me.txtNoTrans.Enabled = False
        Me.txtNoTrans.Location = New System.Drawing.Point(123, 46)
        Me.txtNoTrans.Name = "txtNoTrans"
        Me.txtNoTrans.Size = New System.Drawing.Size(302, 20)
        Me.txtNoTrans.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(494, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Penerima Uang"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Tanggal Pengajuan"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "No Trans"
        '
        'pnlFg
        '
        Me.pnlFg.BackColor = System.Drawing.Color.White
        Me.pnlFg.Controls.Add(Me.fg)
        Me.pnlFg.Controls.Add(Me.Panel3)
        Me.pnlFg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlFg.Location = New System.Drawing.Point(0, 226)
        Me.pnlFg.Name = "pnlFg"
        Me.pnlFg.Size = New System.Drawing.Size(1134, 328)
        Me.pnlFg.TabIndex = 3
        '
        'fg
        '
        Me.fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.fg.ColumnInfo = resources.GetString("fg.ColumnInfo")
        Me.fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fg.Location = New System.Drawing.Point(0, 0)
        Me.fg.Name = "fg"
        Me.fg.Rows.Count = 1
        Me.fg.Size = New System.Drawing.Size(1134, 283)
        Me.fg.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 283)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Panel3.Size = New System.Drawing.Size(1134, 45)
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
        Me.Panel4.Size = New System.Drawing.Size(1134, 40)
        Me.Panel4.TabIndex = 0
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        Me.btnSave.Location = New System.Drawing.Point(972, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 30)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Location = New System.Drawing.Point(1053, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 30)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "Close"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtKodeGroupNota)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.txtTrip)
        Me.Panel1.Controls.Add(Me.cboKapal)
        Me.Panel1.Controls.Add(Me.cboToPancang)
        Me.Panel1.Controls.Add(Me.cboFromPancang)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.cboNoTransOlahGerak)
        Me.Panel1.Controls.Add(Me.cboNoTransBPJS)
        Me.Panel1.Controls.Add(Me.cboNoTransGPS)
        Me.Panel1.Controls.Add(Me.cboNoTransSusut)
        Me.Panel1.Controls.Add(Me.cboPenerimaUang)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
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
        Me.Panel1.Size = New System.Drawing.Size(1134, 226)
        Me.Panel1.TabIndex = 4
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnSearch.BackgroundImage = Global.RMPApp.My.Resources.Resources.search_button_31102025
        Me.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(431, 87)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(30, 30)
        Me.btnSearch.TabIndex = 905703
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'txtTrip
        '
        Me.txtTrip.Location = New System.Drawing.Point(123, 140)
        Me.txtTrip.Name = "txtTrip"
        Me.txtTrip.Size = New System.Drawing.Size(75, 20)
        Me.txtTrip.TabIndex = 905698
        '
        'cboKapal
        '
        Me.cboKapal.FormattingEnabled = True
        Me.cboKapal.Location = New System.Drawing.Point(123, 116)
        Me.cboKapal.Name = "cboKapal"
        Me.cboKapal.Size = New System.Drawing.Size(302, 21)
        Me.cboKapal.TabIndex = 905700
        '
        'cboToPancang
        '
        Me.cboToPancang.FormattingEnabled = True
        Me.cboToPancang.Location = New System.Drawing.Point(123, 186)
        Me.cboToPancang.Name = "cboToPancang"
        Me.cboToPancang.Size = New System.Drawing.Size(302, 21)
        Me.cboToPancang.TabIndex = 905699
        '
        'cboFromPancang
        '
        Me.cboFromPancang.FormattingEnabled = True
        Me.cboFromPancang.Location = New System.Drawing.Point(123, 92)
        Me.cboFromPancang.Name = "cboFromPancang"
        Me.cboFromPancang.Size = New System.Drawing.Size(302, 21)
        Me.cboFromPancang.TabIndex = 905699
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(17, 144)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 13)
        Me.Label9.TabIndex = 905696
        Me.Label9.Text = "From Trip"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(17, 190)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 13)
        Me.Label11.TabIndex = 905695
        Me.Label11.Text = "To Pancang"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(17, 120)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 13)
        Me.Label10.TabIndex = 905697
        Me.Label10.Text = "From Kapal"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(17, 96)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(76, 13)
        Me.Label13.TabIndex = 905695
        Me.Label13.Text = "From Pancang"
        '
        'txtKodeGroupNota
        '
        Me.txtKodeGroupNota.Location = New System.Drawing.Point(123, 163)
        Me.txtKodeGroupNota.Name = "txtKodeGroupNota"
        Me.txtKodeGroupNota.Size = New System.Drawing.Size(150, 20)
        Me.txtKodeGroupNota.TabIndex = 905705
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(17, 167)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(90, 13)
        Me.Label12.TabIndex = 905704
        Me.Label12.Text = "Kode Group Nota"
        '
        'FrmTrnTambangKapalTransitBPI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1134, 554)
        Me.Controls.Add(Me.pnlFg)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmTrnTambangKapalTransitBPI"
        Me.Text = "Transaksi Tambang Kapal Transit"
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.pnlFg.ResumeLayout(False)
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboNoTransOlahGerak As ComboBox
    Friend WithEvents cboNoTransBPJS As ComboBox
    Friend WithEvents cboNoTransGPS As ComboBox
    Friend WithEvents cboNoTransSusut As ComboBox
    Friend WithEvents cboPenerimaUang As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents lblJudulForm As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpTanggalPengajuan As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents txtIDAsuransi As TextBox
    Friend WithEvents txtNoTrans As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents pnlFg As Panel
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtTrip As TextBox
    Friend WithEvents cboKapal As ComboBox
    Friend WithEvents cboFromPancang As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents cboToPancang As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtKodeGroupNota As TextBox
    Friend WithEvents Label12 As Label
End Class
