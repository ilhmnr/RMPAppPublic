<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTrnInvoicePembayaranKelapa
    'Inherits System.Windows.Forms.Form
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTrnInvoicePembayaranKelapa))
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.cboPCG = New System.Windows.Forms.ComboBox()
        Me.cboKPL = New System.Windows.Forms.ComboBox()
        Me.txtTrip = New System.Windows.Forms.TextBox()
        Me.chkTgl = New System.Windows.Forms.CheckBox()
        Me.chkPancang = New System.Windows.Forms.CheckBox()
        Me.chkKapal = New System.Windows.Forms.CheckBox()
        Me.chkTrip = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtp2 = New System.Windows.Forms.DateTimePicker()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtInput = New System.Windows.Forms.DateTimePicker()
        Me.grpDataTimbangPancang = New XanderUI.XUICustomGroupbox()
        Me.txtNoInvoice = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCari = New System.Windows.Forms.Button()
        Me.XuiCustomGroupbox1 = New XanderUI.XUICustomGroupbox()
        Me.dgvlist = New System.Windows.Forms.DataGridView()
        Me.No = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NamaKapal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kapasitas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Trip = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pancang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Muatan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Harga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Jumlah = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Jenis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDKapal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoNota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Check = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.grpDataTimbangPancang.SuspendLayout()
        Me.XuiCustomGroupbox1.SuspendLayout()
        CType(Me.dgvlist, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtp1
        '
        Me.dtp1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp1.Location = New System.Drawing.Point(105, 20)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(84, 22)
        Me.dtp1.TabIndex = 172
        '
        'cboPCG
        '
        Me.cboPCG.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPCG.FormattingEnabled = True
        Me.cboPCG.Location = New System.Drawing.Point(105, 48)
        Me.cboPCG.Name = "cboPCG"
        Me.cboPCG.Size = New System.Drawing.Size(196, 25)
        Me.cboPCG.TabIndex = 173
        '
        'cboKPL
        '
        Me.cboKPL.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboKPL.FormattingEnabled = True
        Me.cboKPL.Location = New System.Drawing.Point(105, 79)
        Me.cboKPL.Name = "cboKPL"
        Me.cboKPL.Size = New System.Drawing.Size(196, 25)
        Me.cboKPL.TabIndex = 174
        '
        'txtTrip
        '
        Me.txtTrip.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTrip.Location = New System.Drawing.Point(105, 110)
        Me.txtTrip.Name = "txtTrip"
        Me.txtTrip.Size = New System.Drawing.Size(106, 22)
        Me.txtTrip.TabIndex = 175
        '
        'chkTgl
        '
        Me.chkTgl.AutoSize = True
        Me.chkTgl.BackColor = System.Drawing.Color.LightSkyBlue
        Me.chkTgl.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTgl.Location = New System.Drawing.Point(12, 22)
        Me.chkTgl.Name = "chkTgl"
        Me.chkTgl.Size = New System.Drawing.Size(86, 20)
        Me.chkTgl.TabIndex = 176
        Me.chkTgl.Text = "Trans Date"
        Me.chkTgl.UseVisualStyleBackColor = False
        '
        'chkPancang
        '
        Me.chkPancang.AutoSize = True
        Me.chkPancang.BackColor = System.Drawing.Color.LightSkyBlue
        Me.chkPancang.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPancang.Location = New System.Drawing.Point(12, 50)
        Me.chkPancang.Name = "chkPancang"
        Me.chkPancang.Size = New System.Drawing.Size(79, 20)
        Me.chkPancang.TabIndex = 177
        Me.chkPancang.Text = "Pancang"
        Me.chkPancang.UseVisualStyleBackColor = False
        '
        'chkKapal
        '
        Me.chkKapal.AutoSize = True
        Me.chkKapal.BackColor = System.Drawing.Color.LightSkyBlue
        Me.chkKapal.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkKapal.Location = New System.Drawing.Point(12, 81)
        Me.chkKapal.Name = "chkKapal"
        Me.chkKapal.Size = New System.Drawing.Size(60, 20)
        Me.chkKapal.TabIndex = 178
        Me.chkKapal.Text = "Kapal"
        Me.chkKapal.UseVisualStyleBackColor = False
        '
        'chkTrip
        '
        Me.chkTrip.AutoSize = True
        Me.chkTrip.BackColor = System.Drawing.Color.LightSkyBlue
        Me.chkTrip.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTrip.Location = New System.Drawing.Point(12, 112)
        Me.chkTrip.Name = "chkTrip"
        Me.chkTrip.Size = New System.Drawing.Size(47, 20)
        Me.chkTrip.TabIndex = 179
        Me.chkTrip.Text = "Trip"
        Me.chkTrip.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Label1.Font = New System.Drawing.Font("Comic Sans MS", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(196, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 16)
        Me.Label1.TabIndex = 180
        Me.Label1.Text = "-"
        '
        'dtp2
        '
        Me.dtp2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp2.Location = New System.Drawing.Point(217, 20)
        Me.dtp2.Name = "dtp2"
        Me.dtp2.Size = New System.Drawing.Size(84, 22)
        Me.dtp2.TabIndex = 181
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.Color.OliveDrab
        Me.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrint.FlatAppearance.BorderSize = 0
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPrint.Location = New System.Drawing.Point(161, 138)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(50, 27)
        Me.btnPrint.TabIndex = 183
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.OliveDrab
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnCancel.Location = New System.Drawing.Point(217, 138)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(59, 27)
        Me.btnCancel.TabIndex = 184
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.OliveDrab
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnClose.Location = New System.Drawing.Point(282, 138)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(63, 27)
        Me.btnClose.TabIndex = 185
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(307, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 16)
        Me.Label2.TabIndex = 188
        Me.Label2.Text = "Input Tanggal"
        '
        'dtInput
        '
        Me.dtInput.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtInput.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtInput.Location = New System.Drawing.Point(412, 20)
        Me.dtInput.Name = "dtInput"
        Me.dtInput.Size = New System.Drawing.Size(84, 22)
        Me.dtInput.TabIndex = 189
        '
        'grpDataTimbangPancang
        '
        Me.grpDataTimbangPancang.BackColor = System.Drawing.Color.LightSkyBlue
        Me.grpDataTimbangPancang.BorderColor = System.Drawing.Color.Black
        Me.grpDataTimbangPancang.BorderWidth = 1
        Me.grpDataTimbangPancang.Controls.Add(Me.txtNoInvoice)
        Me.grpDataTimbangPancang.Controls.Add(Me.Label3)
        Me.grpDataTimbangPancang.Controls.Add(Me.btnCari)
        Me.grpDataTimbangPancang.Controls.Add(Me.dtInput)
        Me.grpDataTimbangPancang.Controls.Add(Me.Label2)
        Me.grpDataTimbangPancang.Controls.Add(Me.btnClose)
        Me.grpDataTimbangPancang.Controls.Add(Me.btnCancel)
        Me.grpDataTimbangPancang.Controls.Add(Me.btnPrint)
        Me.grpDataTimbangPancang.Controls.Add(Me.dtp2)
        Me.grpDataTimbangPancang.Controls.Add(Me.Label1)
        Me.grpDataTimbangPancang.Controls.Add(Me.chkTrip)
        Me.grpDataTimbangPancang.Controls.Add(Me.chkKapal)
        Me.grpDataTimbangPancang.Controls.Add(Me.chkPancang)
        Me.grpDataTimbangPancang.Controls.Add(Me.chkTgl)
        Me.grpDataTimbangPancang.Controls.Add(Me.txtTrip)
        Me.grpDataTimbangPancang.Controls.Add(Me.cboKPL)
        Me.grpDataTimbangPancang.Controls.Add(Me.cboPCG)
        Me.grpDataTimbangPancang.Controls.Add(Me.dtp1)
        Me.grpDataTimbangPancang.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpDataTimbangPancang.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDataTimbangPancang.Location = New System.Drawing.Point(0, 0)
        Me.grpDataTimbangPancang.Name = "grpDataTimbangPancang"
        Me.grpDataTimbangPancang.ShowText = True
        Me.grpDataTimbangPancang.Size = New System.Drawing.Size(1370, 174)
        Me.grpDataTimbangPancang.TabIndex = 100
        Me.grpDataTimbangPancang.TabStop = False
        Me.grpDataTimbangPancang.Text = "List Nota"
        Me.grpDataTimbangPancang.TextColor = System.Drawing.Color.Black
        '
        'txtNoInvoice
        '
        Me.txtNoInvoice.Location = New System.Drawing.Point(412, 51)
        Me.txtNoInvoice.Name = "txtNoInvoice"
        Me.txtNoInvoice.Size = New System.Drawing.Size(175, 23)
        Me.txtNoInvoice.TabIndex = 194
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(307, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 16)
        Me.Label3.TabIndex = 193
        Me.Label3.Text = "No Invoice"
        '
        'btnCari
        '
        Me.btnCari.BackColor = System.Drawing.Color.OliveDrab
        Me.btnCari.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCari.FlatAppearance.BorderSize = 0
        Me.btnCari.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCari.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCari.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnCari.Image = CType(resources.GetObject("btnCari.Image"), System.Drawing.Image)
        Me.btnCari.Location = New System.Drawing.Point(105, 138)
        Me.btnCari.Name = "btnCari"
        Me.btnCari.Size = New System.Drawing.Size(50, 27)
        Me.btnCari.TabIndex = 191
        Me.btnCari.UseVisualStyleBackColor = False
        '
        'XuiCustomGroupbox1
        '
        Me.XuiCustomGroupbox1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.XuiCustomGroupbox1.BorderColor = System.Drawing.Color.Black
        Me.XuiCustomGroupbox1.BorderWidth = 1
        Me.XuiCustomGroupbox1.Controls.Add(Me.dgvlist)
        Me.XuiCustomGroupbox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XuiCustomGroupbox1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XuiCustomGroupbox1.Location = New System.Drawing.Point(0, 174)
        Me.XuiCustomGroupbox1.Name = "XuiCustomGroupbox1"
        Me.XuiCustomGroupbox1.ShowText = True
        Me.XuiCustomGroupbox1.Size = New System.Drawing.Size(1370, 439)
        Me.XuiCustomGroupbox1.TabIndex = 101
        Me.XuiCustomGroupbox1.TabStop = False
        Me.XuiCustomGroupbox1.Text = "Nota Pancang"
        Me.XuiCustomGroupbox1.TextColor = System.Drawing.Color.Black
        '
        'dgvlist
        '
        Me.dgvlist.AllowUserToAddRows = False
        Me.dgvlist.AllowUserToResizeColumns = False
        Me.dgvlist.AllowUserToResizeRows = False
        Me.dgvlist.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvlist.BackgroundColor = System.Drawing.Color.White
        Me.dgvlist.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvlist.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvlist.ColumnHeadersHeight = 36
        Me.dgvlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvlist.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.No, Me.NamaKapal, Me.Kapasitas, Me.Trip, Me.Pancang, Me.Muatan, Me.Harga, Me.Jumlah, Me.Jenis, Me.IDKapal, Me.NoNota, Me.Check})
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvlist.DefaultCellStyle = DataGridViewCellStyle22
        Me.dgvlist.GridColor = System.Drawing.SystemColors.ButtonFace
        Me.dgvlist.Location = New System.Drawing.Point(12, 22)
        Me.dgvlist.Name = "dgvlist"
        Me.dgvlist.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvlist.RowHeadersDefaultCellStyle = DataGridViewCellStyle23
        Me.dgvlist.RowHeadersVisible = False
        Me.dgvlist.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle24.BackColor = System.Drawing.Color.White
        Me.dgvlist.RowsDefaultCellStyle = DataGridViewCellStyle24
        Me.dgvlist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvlist.Size = New System.Drawing.Size(1346, 405)
        Me.dgvlist.TabIndex = 319
        '
        'No
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.No.DefaultCellStyle = DataGridViewCellStyle14
        Me.No.HeaderText = "No"
        Me.No.Name = "No"
        Me.No.Width = 40
        '
        'NamaKapal
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.NamaKapal.DefaultCellStyle = DataGridViewCellStyle15
        Me.NamaKapal.HeaderText = "Nama Kapal"
        Me.NamaKapal.Name = "NamaKapal"
        Me.NamaKapal.Width = 250
        '
        'Kapasitas
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.Format = "N0"
        DataGridViewCellStyle16.NullValue = Nothing
        Me.Kapasitas.DefaultCellStyle = DataGridViewCellStyle16
        Me.Kapasitas.HeaderText = "Kapasitas"
        Me.Kapasitas.Name = "Kapasitas"
        '
        'Trip
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Trip.DefaultCellStyle = DataGridViewCellStyle17
        Me.Trip.HeaderText = "Trip"
        Me.Trip.Name = "Trip"
        '
        'Pancang
        '
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Pancang.DefaultCellStyle = DataGridViewCellStyle18
        Me.Pancang.HeaderText = "Pancang"
        Me.Pancang.Name = "Pancang"
        Me.Pancang.Width = 250
        '
        'Muatan
        '
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle19.Format = "N0"
        DataGridViewCellStyle19.NullValue = Nothing
        Me.Muatan.DefaultCellStyle = DataGridViewCellStyle19
        Me.Muatan.HeaderText = "Muatan"
        Me.Muatan.Name = "Muatan"
        '
        'Harga
        '
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle20.Format = "N0"
        DataGridViewCellStyle20.NullValue = Nothing
        Me.Harga.DefaultCellStyle = DataGridViewCellStyle20
        Me.Harga.HeaderText = "Harga"
        Me.Harga.Name = "Harga"
        '
        'Jumlah
        '
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle21.Format = "N0"
        Me.Jumlah.DefaultCellStyle = DataGridViewCellStyle21
        Me.Jumlah.HeaderText = "Jumlah"
        Me.Jumlah.Name = "Jumlah"
        '
        'Jenis
        '
        Me.Jenis.HeaderText = "Jenis"
        Me.Jenis.Name = "Jenis"
        Me.Jenis.Visible = False
        '
        'IDKapal
        '
        Me.IDKapal.HeaderText = "IDKapal"
        Me.IDKapal.Name = "IDKapal"
        Me.IDKapal.Visible = False
        '
        'NoNota
        '
        Me.NoNota.HeaderText = "NoNota"
        Me.NoNota.Name = "NoNota"
        Me.NoNota.Visible = False
        '
        'Check
        '
        Me.Check.HeaderText = "Check"
        Me.Check.Name = "Check"
        Me.Check.Visible = False
        Me.Check.Width = 50
        '
        'FrmTrnInvoicePembayaranKelapa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1370, 613)
        Me.Controls.Add(Me.XuiCustomGroupbox1)
        Me.Controls.Add(Me.grpDataTimbangPancang)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmTrnInvoicePembayaranKelapa"
        Me.Text = "Invoice Pembayaran Kelapa"
        Me.grpDataTimbangPancang.ResumeLayout(False)
        Me.grpDataTimbangPancang.PerformLayout()
        Me.XuiCustomGroupbox1.ResumeLayout(False)
        Me.XuiCustomGroupbox1.PerformLayout()
        CType(Me.dgvlist, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dtp1 As DateTimePicker
    Friend WithEvents cboPCG As ComboBox
    Friend WithEvents cboKPL As ComboBox
    Friend WithEvents txtTrip As TextBox
    Friend WithEvents chkTgl As CheckBox
    Friend WithEvents chkPancang As CheckBox
    Friend WithEvents chkKapal As CheckBox
    Friend WithEvents chkTrip As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dtp2 As DateTimePicker
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents dtInput As DateTimePicker
    Friend WithEvents grpDataTimbangPancang As XanderUI.XUICustomGroupbox
    Friend WithEvents btnCari As Button
    Friend WithEvents XuiCustomGroupbox1 As XanderUI.XUICustomGroupbox
    Friend WithEvents dgvlist As DataGridView
    Friend WithEvents No As DataGridViewTextBoxColumn
    Friend WithEvents NamaKapal As DataGridViewTextBoxColumn
    Friend WithEvents Kapasitas As DataGridViewTextBoxColumn
    Friend WithEvents Trip As DataGridViewTextBoxColumn
    Friend WithEvents Pancang As DataGridViewTextBoxColumn
    Friend WithEvents Muatan As DataGridViewTextBoxColumn
    Friend WithEvents Harga As DataGridViewTextBoxColumn
    Friend WithEvents Jumlah As DataGridViewTextBoxColumn
    Friend WithEvents Jenis As DataGridViewTextBoxColumn
    Friend WithEvents IDKapal As DataGridViewTextBoxColumn
    Friend WithEvents NoNota As DataGridViewTextBoxColumn
    Friend WithEvents Check As DataGridViewCheckBoxColumn
    Friend WithEvents txtNoInvoice As TextBox
    Friend WithEvents Label3 As Label
End Class
