Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTrnUpahBongkarInput
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTrnUpahBongkarInput))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnKalkulasi = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.txtHeaderID = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboPancang = New System.Windows.Forms.ComboBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNoTrans = New System.Windows.Forms.TextBox()
        Me.cboNoTransBPJS = New System.Windows.Forms.ComboBox()
        Me.rdTglCheckin = New System.Windows.Forms.RadioButton()
        Me.dtpCheckin2 = New System.Windows.Forms.DateTimePicker()
        Me.cboPenerimaUang = New System.Windows.Forms.ComboBox()
        Me.rdTglNota = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpTanggalPengajuan = New System.Windows.Forms.DateTimePicker()
        Me.rdTglBoking = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtpNota1 = New System.Windows.Forms.DateTimePicker()
        Me.dtpboking2 = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTrip2 = New System.Windows.Forms.TextBox()
        Me.dtpboking1 = New System.Windows.Forms.DateTimePicker()
        Me.dtpCheckin1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTrip = New System.Windows.Forms.TextBox()
        Me.dtpNota2 = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboKapal = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Panel7)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1222, 40)
        Me.Panel1.TabIndex = 0
        '
        'Panel7
        '
        Me.Panel7.BackgroundImage = CType(resources.GetObject("Panel7.BackgroundImage"), System.Drawing.Image)
        Me.Panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel7.Location = New System.Drawing.Point(10, 3)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(35, 35)
        Me.Panel7.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(48, 6)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(295, 28)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Transaksi Upah Bongkar Input"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Controls.Add(Me.btnSave)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 456)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1222, 40)
        Me.Panel2.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.White
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(1137, 5)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnCancel.Size = New System.Drawing.Size(75, 30)
        Me.btnCancel.TabIndex = 905696
        Me.btnCancel.Text = "Exit"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.White
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(1062, 5)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnSave.Size = New System.Drawing.Size(75, 30)
        Me.btnSave.TabIndex = 905695
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 40)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1222, 416)
        Me.Panel3.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.White
        Me.Panel5.Controls.Add(Me.fg)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 134)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(10, 0, 10, 10)
        Me.Panel5.Size = New System.Drawing.Size(1222, 282)
        Me.Panel5.TabIndex = 0
        '
        'fg
        '
        Me.fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.fg.ColumnInfo = resources.GetString("fg.ColumnInfo")
        Me.fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fg.Location = New System.Drawing.Point(10, 0)
        Me.fg.Name = "fg"
        Me.fg.Rows.Count = 1
        Me.fg.Size = New System.Drawing.Size(1202, 272)
        Me.fg.TabIndex = 905682
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Controls.Add(Me.cboKapal)
        Me.Panel4.Controls.Add(Me.btnKalkulasi)
        Me.Panel4.Controls.Add(Me.Panel6)
        Me.Panel4.Controls.Add(Me.txtHeaderID)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.cboPancang)
        Me.Panel4.Controls.Add(Me.btnSearch)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.txtNoTrans)
        Me.Panel4.Controls.Add(Me.cboNoTransBPJS)
        Me.Panel4.Controls.Add(Me.rdTglCheckin)
        Me.Panel4.Controls.Add(Me.dtpCheckin2)
        Me.Panel4.Controls.Add(Me.cboPenerimaUang)
        Me.Panel4.Controls.Add(Me.rdTglNota)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.dtpTanggalPengajuan)
        Me.Panel4.Controls.Add(Me.rdTglBoking)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.dtpNota1)
        Me.Panel4.Controls.Add(Me.dtpboking2)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.txtTrip2)
        Me.Panel4.Controls.Add(Me.dtpboking1)
        Me.Panel4.Controls.Add(Me.dtpCheckin1)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.txtTrip)
        Me.Panel4.Controls.Add(Me.dtpNota2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1222, 134)
        Me.Panel4.TabIndex = 0
        '
        'btnKalkulasi
        '
        Me.btnKalkulasi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnKalkulasi.BackColor = System.Drawing.Color.White
        Me.btnKalkulasi.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKalkulasi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKalkulasi.Location = New System.Drawing.Point(1136, 93)
        Me.btnKalkulasi.Name = "btnKalkulasi"
        Me.btnKalkulasi.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnKalkulasi.Size = New System.Drawing.Size(75, 30)
        Me.btnKalkulasi.TabIndex = 905715
        Me.btnKalkulasi.Text = "Kalkulasi"
        Me.btnKalkulasi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKalkulasi.UseVisualStyleBackColor = False
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Black
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1222, 1)
        Me.Panel6.TabIndex = 905714
        '
        'txtHeaderID
        '
        Me.txtHeaderID.Enabled = False
        Me.txtHeaderID.Location = New System.Drawing.Point(95, 11)
        Me.txtHeaderID.Name = "txtHeaderID"
        Me.txtHeaderID.Size = New System.Drawing.Size(18, 20)
        Me.txtHeaderID.TabIndex = 905713
        Me.txtHeaderID.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 905684
        Me.Label4.Text = "No Trans"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(412, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 905698
        Me.Label2.Text = "Pancang"
        '
        'cboPancang
        '
        Me.cboPancang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPancang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPancang.FormattingEnabled = True
        Me.cboPancang.Location = New System.Drawing.Point(468, 43)
        Me.cboPancang.Name = "cboPancang"
        Me.cboPancang.Size = New System.Drawing.Size(271, 21)
        Me.cboPancang.TabIndex = 905697
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
        Me.btnSearch.Location = New System.Drawing.Point(745, 38)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(30, 30)
        Me.btnSearch.TabIndex = 905711
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(243, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 13)
        Me.Label3.TabIndex = 905707
        Me.Label3.Text = "s/d"
        '
        'txtNoTrans
        '
        Me.txtNoTrans.Enabled = False
        Me.txtNoTrans.Location = New System.Drawing.Point(119, 11)
        Me.txtNoTrans.Name = "txtNoTrans"
        Me.txtNoTrans.Size = New System.Drawing.Size(270, 20)
        Me.txtNoTrans.TabIndex = 905689
        '
        'cboNoTransBPJS
        '
        Me.cboNoTransBPJS.FormattingEnabled = True
        Me.cboNoTransBPJS.Location = New System.Drawing.Point(892, 64)
        Me.cboNoTransBPJS.Name = "cboNoTransBPJS"
        Me.cboNoTransBPJS.Size = New System.Drawing.Size(311, 21)
        Me.cboNoTransBPJS.TabIndex = 905695
        '
        'rdTglCheckin
        '
        Me.rdTglCheckin.AutoSize = True
        Me.rdTglCheckin.Checked = True
        Me.rdTglCheckin.Location = New System.Drawing.Point(7, 105)
        Me.rdTglCheckin.Name = "rdTglCheckin"
        Me.rdTglCheckin.Size = New System.Drawing.Size(106, 17)
        Me.rdTglCheckin.TabIndex = 905708
        Me.rdTglCheckin.TabStop = True
        Me.rdTglCheckin.Text = "Tanggal Checkin"
        Me.rdTglCheckin.UseVisualStyleBackColor = True
        '
        'dtpCheckin2
        '
        Me.dtpCheckin2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCheckin2.Location = New System.Drawing.Point(269, 103)
        Me.dtpCheckin2.Name = "dtpCheckin2"
        Me.dtpCheckin2.Size = New System.Drawing.Size(120, 20)
        Me.dtpCheckin2.TabIndex = 905704
        '
        'cboPenerimaUang
        '
        Me.cboPenerimaUang.FormattingEnabled = True
        Me.cboPenerimaUang.Location = New System.Drawing.Point(892, 37)
        Me.cboPenerimaUang.Name = "cboPenerimaUang"
        Me.cboPenerimaUang.Size = New System.Drawing.Size(311, 21)
        Me.cboPenerimaUang.TabIndex = 905696
        '
        'rdTglNota
        '
        Me.rdTglNota.AutoSize = True
        Me.rdTglNota.Location = New System.Drawing.Point(7, 59)
        Me.rdTglNota.Name = "rdTglNota"
        Me.rdTglNota.Size = New System.Drawing.Size(90, 17)
        Me.rdTglNota.TabIndex = 905709
        Me.rdTglNota.Text = "Tanggal Nota"
        Me.rdTglNota.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(243, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(23, 13)
        Me.Label6.TabIndex = 905706
        Me.Label6.Text = "s/d"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 13)
        Me.Label5.TabIndex = 905685
        Me.Label5.Text = "Tanggal Pengajuan"
        '
        'dtpTanggalPengajuan
        '
        Me.dtpTanggalPengajuan.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTanggalPengajuan.Location = New System.Drawing.Point(119, 34)
        Me.dtpTanggalPengajuan.Name = "dtpTanggalPengajuan"
        Me.dtpTanggalPengajuan.Size = New System.Drawing.Size(270, 20)
        Me.dtpTanggalPengajuan.TabIndex = 905692
        '
        'rdTglBoking
        '
        Me.rdTglBoking.AutoSize = True
        Me.rdTglBoking.Location = New System.Drawing.Point(7, 82)
        Me.rdTglBoking.Name = "rdTglBoking"
        Me.rdTglBoking.Size = New System.Drawing.Size(100, 17)
        Me.rdTglBoking.TabIndex = 905710
        Me.rdTglBoking.Text = "Tanggal Boking"
        Me.rdTglBoking.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(243, 61)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(23, 13)
        Me.Label9.TabIndex = 905705
        Me.Label9.Text = "s/d"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(412, 95)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(25, 13)
        Me.Label7.TabIndex = 905686
        Me.Label7.Text = "Trip"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(806, 68)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 13)
        Me.Label10.TabIndex = 905683
        Me.Label10.Text = "No Trans BPJS"
        '
        'dtpNota1
        '
        Me.dtpNota1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNota1.Location = New System.Drawing.Point(119, 57)
        Me.dtpNota1.Name = "dtpNota1"
        Me.dtpNota1.Size = New System.Drawing.Size(120, 20)
        Me.dtpNota1.TabIndex = 905699
        '
        'dtpboking2
        '
        Me.dtpboking2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpboking2.Location = New System.Drawing.Point(269, 80)
        Me.dtpboking2.Name = "dtpboking2"
        Me.dtpboking2.Size = New System.Drawing.Size(120, 20)
        Me.dtpboking2.TabIndex = 905703
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(538, 95)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(18, 13)
        Me.Label8.TabIndex = 905688
        Me.Label8.Text = "sd"
        '
        'txtTrip2
        '
        Me.txtTrip2.Location = New System.Drawing.Point(562, 92)
        Me.txtTrip2.Name = "txtTrip2"
        Me.txtTrip2.Size = New System.Drawing.Size(64, 20)
        Me.txtTrip2.TabIndex = 905690
        '
        'dtpboking1
        '
        Me.dtpboking1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpboking1.Location = New System.Drawing.Point(119, 80)
        Me.dtpboking1.Name = "dtpboking1"
        Me.dtpboking1.Size = New System.Drawing.Size(120, 20)
        Me.dtpboking1.TabIndex = 905700
        '
        'dtpCheckin1
        '
        Me.dtpCheckin1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCheckin1.Location = New System.Drawing.Point(119, 103)
        Me.dtpCheckin1.Name = "dtpCheckin1"
        Me.dtpCheckin1.Size = New System.Drawing.Size(120, 20)
        Me.dtpCheckin1.TabIndex = 905701
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(806, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 905687
        Me.Label1.Text = "Penerima Uang"
        '
        'txtTrip
        '
        Me.txtTrip.Location = New System.Drawing.Point(468, 91)
        Me.txtTrip.Name = "txtTrip"
        Me.txtTrip.Size = New System.Drawing.Size(64, 20)
        Me.txtTrip.TabIndex = 905691
        '
        'dtpNota2
        '
        Me.dtpNota2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNota2.Location = New System.Drawing.Point(269, 57)
        Me.dtpNota2.Name = "dtpNota2"
        Me.dtpNota2.Size = New System.Drawing.Size(120, 20)
        Me.dtpNota2.TabIndex = 905702
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(412, 71)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(34, 13)
        Me.Label12.TabIndex = 905717
        Me.Label12.Text = "Kapal"
        '
        'cboKapal
        '
        Me.cboKapal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboKapal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboKapal.FormattingEnabled = True
        Me.cboKapal.Location = New System.Drawing.Point(468, 67)
        Me.cboKapal.Name = "cboKapal"
        Me.cboKapal.Size = New System.Drawing.Size(271, 21)
        Me.cboKapal.TabIndex = 905716
        '
        'FrmTrnUpahBongkarInput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1222, 496)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmTrnUpahBongkarInput"
        Me.Text = "Transaksi Upah Bongkar Input"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel4 As Panel
    Friend WithEvents txtHeaderID As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cboPancang As ComboBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNoTrans As TextBox
    Friend WithEvents cboNoTransBPJS As ComboBox
    Friend WithEvents rdTglCheckin As RadioButton
    Friend WithEvents dtpCheckin2 As DateTimePicker
    Friend WithEvents cboPenerimaUang As ComboBox
    Friend WithEvents rdTglNota As RadioButton
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents dtpTanggalPengajuan As DateTimePicker
    Friend WithEvents rdTglBoking As RadioButton
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents dtpNota1 As DateTimePicker
    Friend WithEvents dtpboking2 As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents txtTrip2 As TextBox
    Friend WithEvents dtpboking1 As DateTimePicker
    Friend WithEvents dtpCheckin1 As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents txtTrip As TextBox
    Friend WithEvents dtpNota2 As DateTimePicker
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnKalkulasi As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents cboKapal As ComboBox
End Class
