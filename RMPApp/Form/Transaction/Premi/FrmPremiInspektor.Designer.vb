<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPremiInspektor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPremiInspektor))
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.rp = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.fghasilinspektur = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.fgrupiah = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbring = New System.Windows.Forms.ComboBox()
        Me.cmbGrade_KB = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnrefresh = New System.Windows.Forms.Button()
        Me.dttgl = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.dttglinvoice = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.fgpoint = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.fglavelbonus = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.fginspektur = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.fgpcg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.fgpancang = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlHead = New System.Windows.Forms.Panel()
        Me.lblHead = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.fglavelbonusdesc = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.btnexit = New System.Windows.Forms.Button()
        Me.Panel6.SuspendLayout()
        Me.rp.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.fghasilinspektur, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.fgrupiah, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.fgpoint, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.fglavelbonus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.fginspektur, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel6.SuspendLayout()
        CType(Me.fgpcg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fgpancang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.fglavelbonusdesc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.White
        Me.Panel6.Controls.Add(Me.rp)
        Me.Panel6.Controls.Add(Me.btnexit)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.ForeColor = System.Drawing.Color.Black
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1250, 872)
        Me.Panel6.TabIndex = 324
        '
        'rp
        '
        Me.rp.ColumnCount = 1
        Me.rp.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.rp.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.rp.Controls.Add(Me.SplitContainer1, 0, 0)
        Me.rp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rp.Location = New System.Drawing.Point(0, 0)
        Me.rp.Name = "rp"
        Me.rp.RowCount = 2
        Me.rp.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.rp.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.rp.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.rp.Size = New System.Drawing.Size(1250, 872)
        Me.rp.TabIndex = 905567
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.68489!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.31511!))
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel3, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel6, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 39)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1244, 830)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.BackColor = System.Drawing.SystemColors.Window
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.GroupBox5, 0, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.GroupBox4, 0, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel4, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.GroupBox3, 0, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.GroupBox2, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.GroupBox1, 0, 2)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 6
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 118.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(525, 824)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.fghasilinspektur)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox5.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.GroupBox5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.GroupBox5.Location = New System.Drawing.Point(3, 403)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(519, 135)
        Me.GroupBox5.TabIndex = 905568
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Hasil Inspektur"
        '
        'fghasilinspektur
        '
        Me.fghasilinspektur.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fghasilinspektur.ColumnInfo = resources.GetString("fghasilinspektur.ColumnInfo")
        Me.fghasilinspektur.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fghasilinspektur.ForeColor = System.Drawing.Color.Black
        Me.fghasilinspektur.Location = New System.Drawing.Point(3, 18)
        Me.fghasilinspektur.Name = "fghasilinspektur"
        Me.fghasilinspektur.Rows.Count = 5
        Me.fghasilinspektur.Rows.DefaultSize = 22
        Me.fghasilinspektur.Size = New System.Drawing.Size(513, 114)
        Me.fghasilinspektur.StyleInfo = resources.GetString("fghasilinspektur.StyleInfo")
        Me.fghasilinspektur.TabIndex = 11
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.fgrupiah)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox4.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.GroupBox4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.GroupBox4.Location = New System.Drawing.Point(3, 685)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(519, 136)
        Me.GroupBox4.TabIndex = 905566
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Perhitungan Rupiah"
        '
        'fgrupiah
        '
        Me.fgrupiah.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fgrupiah.ColumnInfo = resources.GetString("fgrupiah.ColumnInfo")
        Me.fgrupiah.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgrupiah.ForeColor = System.Drawing.Color.Black
        Me.fgrupiah.Location = New System.Drawing.Point(3, 18)
        Me.fgrupiah.Name = "fgrupiah"
        Me.fgrupiah.Rows.Count = 5
        Me.fgrupiah.Rows.DefaultSize = 22
        Me.fgrupiah.Size = New System.Drawing.Size(513, 115)
        Me.fgrupiah.StyleInfo = resources.GetString("fgrupiah.StyleInfo")
        Me.fgrupiah.TabIndex = 10
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.TableLayoutPanel4.ColumnCount = 4
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 368.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.Label7, 1, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.Label6, 0, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.Label3, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.cmbring, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.cmbGrade_KB, 2, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Label9, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Label1, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.TableLayoutPanel7, 2, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.Label5, 1, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.Label4, 0, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.TableLayoutPanel8, 2, 3)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel4.ForeColor = System.Drawing.Color.White
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 4
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(519, 112)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(118, 83)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(10, 29)
        Me.Label7.TabIndex = 905570
        Me.Label7.Text = ":"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(3, 89)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 17)
        Me.Label6.TabIndex = 905571
        Me.Label6.Text = "Tgl.Invoice"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(3, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 17)
        Me.Label3.TabIndex = 905567
        Me.Label3.Text = "Jenis KB"
        '
        'cmbring
        '
        Me.cmbring.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbring.FormattingEnabled = True
        Me.cmbring.Location = New System.Drawing.Point(134, 3)
        Me.cmbring.Name = "cmbring"
        Me.cmbring.Size = New System.Drawing.Size(362, 21)
        Me.cmbring.TabIndex = 905563
        '
        'cmbGrade_KB
        '
        Me.cmbGrade_KB.FormattingEnabled = True
        Me.cmbGrade_KB.Location = New System.Drawing.Point(134, 28)
        Me.cmbGrade_KB.Name = "cmbGrade_KB"
        Me.cmbGrade_KB.Size = New System.Drawing.Size(362, 21)
        Me.cmbGrade_KB.TabIndex = 905564
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(118, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(10, 25)
        Me.Label9.TabIndex = 905562
        Me.Label9.Text = ":"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(118, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 25)
        Me.Label1.TabIndex = 905565
        Me.Label1.Text = ":"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(3, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 17)
        Me.Label2.TabIndex = 905566
        Me.Label2.Text = "Ring"
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.ColumnCount = 3
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.14155!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.85845!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 196.0!))
        Me.TableLayoutPanel7.Controls.Add(Me.btnrefresh, 1, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.dttgl, 2, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.DateTimePicker1, 0, 0)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(134, 53)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 1
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(362, 27)
        Me.TableLayoutPanel7.TabIndex = 905570
        '
        'btnrefresh
        '
        Me.btnrefresh.BackColor = System.Drawing.Color.White
        Me.btnrefresh.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnrefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnrefresh.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.btnrefresh.Location = New System.Drawing.Point(87, 3)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(75, 21)
        Me.btnrefresh.TabIndex = 905571
        Me.btnrefresh.Text = "Refresh"
        Me.btnrefresh.UseVisualStyleBackColor = False
        '
        'dttgl
        '
        Me.dttgl.CalendarForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.dttgl.CalendarTitleBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dttgl.CalendarTitleForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dttgl.CustomFormat = ""
        Me.dttgl.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dttgl.Location = New System.Drawing.Point(168, 3)
        Me.dttgl.Name = "dttgl"
        Me.dttgl.Size = New System.Drawing.Size(127, 20)
        Me.dttgl.TabIndex = 905570
        Me.dttgl.Visible = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "MM/yyyy"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(3, 3)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(78, 20)
        Me.DateTimePicker1.TabIndex = 905572
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(118, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 33)
        Me.Label5.TabIndex = 905569
        Me.Label5.Text = ":"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(3, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 17)
        Me.Label4.TabIndex = 905568
        Me.Label4.Text = "Tanggal"
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.ColumnCount = 3
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel8.Controls.Add(Me.dttglinvoice, 0, 0)
        Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(134, 86)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 1
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(362, 23)
        Me.TableLayoutPanel8.TabIndex = 905572
        '
        'dttglinvoice
        '
        Me.dttglinvoice.CustomFormat = ""
        Me.dttglinvoice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dttglinvoice.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dttglinvoice.Location = New System.Drawing.Point(3, 3)
        Me.dttglinvoice.Name = "dttglinvoice"
        Me.dttglinvoice.Size = New System.Drawing.Size(165, 20)
        Me.dttglinvoice.TabIndex = 905573
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.fgpoint)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.GroupBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.GroupBox3.Location = New System.Drawing.Point(3, 544)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(519, 135)
        Me.GroupBox3.TabIndex = 905565
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Perhitungan Point"
        '
        'fgpoint
        '
        Me.fgpoint.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fgpoint.ColumnInfo = resources.GetString("fgpoint.ColumnInfo")
        Me.fgpoint.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgpoint.ForeColor = System.Drawing.Color.Black
        Me.fgpoint.Location = New System.Drawing.Point(3, 18)
        Me.fgpoint.Name = "fgpoint"
        Me.fgpoint.Rows.Count = 5
        Me.fgpoint.Rows.DefaultSize = 22
        Me.fgpoint.Size = New System.Drawing.Size(513, 114)
        Me.fgpoint.StyleInfo = resources.GetString("fgpoint.StyleInfo")
        Me.fgpoint.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData
        Me.fgpoint.TabIndex = 12
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.fglavelbonus)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(3, 121)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(519, 135)
        Me.GroupBox2.TabIndex = 905564
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Lavel Bonus"
        '
        'fglavelbonus
        '
        Me.fglavelbonus.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.fglavelbonus.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fglavelbonus.ColumnInfo = resources.GetString("fglavelbonus.ColumnInfo")
        Me.fglavelbonus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fglavelbonus.ForeColor = System.Drawing.Color.Black
        Me.fglavelbonus.Location = New System.Drawing.Point(3, 18)
        Me.fglavelbonus.Name = "fglavelbonus"
        Me.fglavelbonus.Rows.Count = 5
        Me.fglavelbonus.Rows.DefaultSize = 22
        Me.fglavelbonus.Size = New System.Drawing.Size(513, 114)
        Me.fglavelbonus.StyleInfo = resources.GetString("fglavelbonus.StyleInfo")
        Me.fglavelbonus.TabIndex = 9
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.fginspektur)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 9.0!)
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 262)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(519, 135)
        Me.GroupBox1.TabIndex = 905560
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Target Inspektur"
        '
        'fginspektur
        '
        Me.fginspektur.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fginspektur.ColumnInfo = resources.GetString("fginspektur.ColumnInfo")
        Me.fginspektur.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fginspektur.ForeColor = System.Drawing.Color.Black
        Me.fginspektur.Location = New System.Drawing.Point(3, 18)
        Me.fginspektur.Name = "fginspektur"
        Me.fginspektur.Rows.Count = 5
        Me.fginspektur.Rows.DefaultSize = 22
        Me.fginspektur.Size = New System.Drawing.Size(513, 114)
        Me.fginspektur.StyleInfo = resources.GetString("fginspektur.StyleInfo")
        Me.fginspektur.TabIndex = 12
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 1
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.fgpcg, 0, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.fgpancang, 0, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(534, 3)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 3
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.17458!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.82542!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(707, 824)
        Me.TableLayoutPanel6.TabIndex = 1
        '
        'fgpcg
        '
        Me.fgpcg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.fgpcg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fgpcg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fgpcg.ColumnInfo = resources.GetString("fgpcg.ColumnInfo")
        Me.fgpcg.ForeColor = System.Drawing.Color.Black
        Me.fgpcg.Location = New System.Drawing.Point(3, 129)
        Me.fgpcg.Name = "fgpcg"
        Me.fgpcg.Rows.Count = 5
        Me.fgpcg.Rows.DefaultSize = 22
        Me.fgpcg.Size = New System.Drawing.Size(701, 647)
        Me.fgpcg.StyleInfo = resources.GetString("fgpcg.StyleInfo")
        Me.fgpcg.TabIndex = 8
        '
        'fgpancang
        '
        Me.fgpancang.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.fgpancang.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fgpancang.ColumnInfo = "2,0,0,0,0,110,Columns:0{Width:80;Caption:""ID Pancang"";Style:""TextAlign:CenterCent" &
    "er;"";StyleFixed:""TextAlign:CenterCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "1{Width:327;Caption:""Pancang"";StyleF" &
    "ixed:""TextAlign:CenterCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.fgpancang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgpancang.ForeColor = System.Drawing.Color.Black
        Me.fgpancang.Location = New System.Drawing.Point(3, 3)
        Me.fgpancang.Name = "fgpancang"
        Me.fgpancang.Rows.Count = 5
        Me.fgpancang.Rows.DefaultSize = 22
        Me.fgpancang.Size = New System.Drawing.Size(701, 120)
        Me.fgpancang.StyleInfo = resources.GetString("fgpancang.StyleInfo")
        Me.fgpancang.TabIndex = 11
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TableLayoutPanel5)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1244, 30)
        Me.SplitContainer1.SplitterDistance = 519
        Me.SplitContainer1.TabIndex = 1
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 1
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 386.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.pnlHead, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.lblHead, 0, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 2
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(386, 30)
        Me.TableLayoutPanel5.TabIndex = 1
        '
        'pnlHead
        '
        Me.pnlHead.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.pnlHead.Location = New System.Drawing.Point(3, 23)
        Me.pnlHead.Name = "pnlHead"
        Me.pnlHead.Size = New System.Drawing.Size(380, 1)
        Me.pnlHead.TabIndex = 325
        '
        'lblHead
        '
        Me.lblHead.AutoSize = True
        Me.lblHead.BackColor = System.Drawing.Color.Transparent
        Me.lblHead.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblHead.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHead.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.lblHead.Location = New System.Drawing.Point(3, 0)
        Me.lblHead.Name = "lblHead"
        Me.lblHead.Size = New System.Drawing.Size(228, 19)
        Me.lblHead.TabIndex = 301
        Me.lblHead.Text = "Master Premi dan Pengawas"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 328.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.fglavelbonusdesc, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(305, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(416, 30)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'fglavelbonusdesc
        '
        Me.fglavelbonusdesc.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.fglavelbonusdesc.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fglavelbonusdesc.ColumnInfo = resources.GetString("fglavelbonusdesc.ColumnInfo")
        Me.fglavelbonusdesc.ForeColor = System.Drawing.Color.Black
        Me.fglavelbonusdesc.Location = New System.Drawing.Point(91, 3)
        Me.fglavelbonusdesc.Name = "fglavelbonusdesc"
        Me.fglavelbonusdesc.Rows.Count = 5
        Me.fglavelbonusdesc.Rows.DefaultSize = 22
        Me.fglavelbonusdesc.Size = New System.Drawing.Size(295, 24)
        Me.fglavelbonusdesc.StyleInfo = resources.GetString("fglavelbonusdesc.StyleInfo")
        Me.fglavelbonusdesc.TabIndex = 10
        Me.fglavelbonusdesc.Visible = False
        '
        'btnexit
        '
        Me.btnexit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnexit.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnexit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnexit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.btnexit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.btnexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnexit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexit.ForeColor = System.Drawing.Color.White
        Me.btnexit.Image = CType(resources.GetObject("btnexit.Image"), System.Drawing.Image)
        Me.btnexit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnexit.Location = New System.Drawing.Point(1136, 894)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(79, 39)
        Me.btnexit.TabIndex = 307
        Me.btnexit.Text = "Exit"
        Me.btnexit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnexit.UseVisualStyleBackColor = False
        '
        'FrmPremiInspektor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1250, 872)
        Me.Controls.Add(Me.Panel6)
        Me.Name = "FrmPremiInspektor"
        Me.Text = "FrmPremiInspektor"
        Me.Panel6.ResumeLayout(False)
        Me.rp.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.fghasilinspektur, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.fgrupiah, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.fgpoint, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.fglavelbonus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.fginspektur, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel6.ResumeLayout(False)
        CType(Me.fgpcg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fgpancang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.fglavelbonusdesc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel6 As Panel
    Friend WithEvents btnexit As Button
    Friend WithEvents rp As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents lblHead As Label
    Friend WithEvents pnlHead As Panel
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents fgrupiah As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents fghasilinspektur As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents fgpoint As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents fglavelbonus As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents fginspektur As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents cmbring As ComboBox
    Friend WithEvents cmbGrade_KB As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents dttgl As DateTimePicker
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents fgpcg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents TableLayoutPanel7 As TableLayoutPanel
    Friend WithEvents btnrefresh As Button
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TableLayoutPanel8 As TableLayoutPanel
    Friend WithEvents dttglinvoice As DateTimePicker
    Friend WithEvents fglavelbonusdesc As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents fgpancang As C1.Win.C1FlexGrid.C1FlexGrid
End Class
