<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMstFee
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMstFee))
        Me.cboPancang = New System.Windows.Forms.ComboBox()
        Me.txtNamaPemilik = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ChkNotActive = New System.Windows.Forms.CheckBox()
        Me.TxtID = New System.Windows.Forms.TextBox()
        Me.cboNamaPemilikLahan = New System.Windows.Forms.ComboBox()
        Me.cbobahanbaku = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dttgl = New System.Windows.Forms.DateTimePicker()
        Me.txtNoTlpPemilikLahan = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtFeeToke = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cboNamaToke = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtNoRekToke = New System.Windows.Forms.TextBox()
        Me.txtNamaRekToke = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtNoTlpToke = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFeePemilikLahan = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNoRekPemilikLahan = New System.Windows.Forms.TextBox()
        Me.txtNamaRekPemilikLahan = New System.Windows.Forms.TextBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.lblJudulForm = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.scp = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.ChkGetAllData = New System.Windows.Forms.CheckBox()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.txtBankToke = New System.Windows.Forms.TextBox()
        Me.txtBankPemilikLahan = New System.Windows.Forms.TextBox()
        Me.Panel3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboPancang
        '
        Me.cboPancang.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPancang.FormattingEnabled = True
        Me.cboPancang.Location = New System.Drawing.Point(76, 75)
        Me.cboPancang.Name = "cboPancang"
        Me.cboPancang.Size = New System.Drawing.Size(336, 25)
        Me.cboPancang.TabIndex = 249
        '
        'txtNamaPemilik
        '
        Me.txtNamaPemilik.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNamaPemilik.Location = New System.Drawing.Point(418, 76)
        Me.txtNamaPemilik.Name = "txtNamaPemilik"
        Me.txtNamaPemilik.Size = New System.Drawing.Size(51, 23)
        Me.txtNamaPemilik.TabIndex = 247
        Me.txtNamaPemilik.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 240
        Me.Label5.Text = "No Telp"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 238
        Me.Label3.Text = "Pancang"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 236
        Me.Label1.Text = "Nama"
        '
        'ChkNotActive
        '
        Me.ChkNotActive.AutoSize = True
        Me.ChkNotActive.ForeColor = System.Drawing.Color.Red
        Me.ChkNotActive.Location = New System.Drawing.Point(323, 51)
        Me.ChkNotActive.Name = "ChkNotActive"
        Me.ChkNotActive.Size = New System.Drawing.Size(73, 17)
        Me.ChkNotActive.TabIndex = 920
        Me.ChkNotActive.Text = "NotActive"
        Me.ChkNotActive.UseVisualStyleBackColor = True
        '
        'TxtID
        '
        Me.TxtID.Location = New System.Drawing.Point(418, 49)
        Me.TxtID.Name = "TxtID"
        Me.TxtID.Size = New System.Drawing.Size(51, 20)
        Me.TxtID.TabIndex = 919
        Me.TxtID.Visible = False
        '
        'cboNamaPemilikLahan
        '
        Me.cboNamaPemilikLahan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboNamaPemilikLahan.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboNamaPemilikLahan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboNamaPemilikLahan.FormattingEnabled = True
        Me.cboNamaPemilikLahan.IntegralHeight = False
        Me.cboNamaPemilikLahan.Location = New System.Drawing.Point(102, 21)
        Me.cboNamaPemilikLahan.Name = "cboNamaPemilikLahan"
        Me.cboNamaPemilikLahan.Size = New System.Drawing.Size(336, 24)
        Me.cboNamaPemilikLahan.TabIndex = 910
        '
        'cbobahanbaku
        '
        Me.cbobahanbaku.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbobahanbaku.FormattingEnabled = True
        Me.cbobahanbaku.Location = New System.Drawing.Point(76, 106)
        Me.cbobahanbaku.Name = "cbobahanbaku"
        Me.cbobahanbaku.Size = New System.Drawing.Size(179, 21)
        Me.cbobahanbaku.TabIndex = 908
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(20, 110)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(31, 13)
        Me.Label11.TabIndex = 907
        Me.Label11.Text = "Jenis"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(20, 53)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 13)
        Me.Label10.TabIndex = 906
        Me.Label10.Text = "Periode"
        '
        'dttgl
        '
        Me.dttgl.CalendarForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.dttgl.CalendarTitleBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dttgl.CalendarTitleForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.dttgl.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dttgl.Location = New System.Drawing.Point(76, 49)
        Me.dttgl.Name = "dttgl"
        Me.dttgl.Size = New System.Drawing.Size(241, 20)
        Me.dttgl.TabIndex = 905
        '
        'txtNoTlpPemilikLahan
        '
        Me.txtNoTlpPemilikLahan.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoTlpPemilikLahan.Location = New System.Drawing.Point(102, 51)
        Me.txtNoTlpPemilikLahan.Name = "txtNoTlpPemilikLahan"
        Me.txtNoTlpPemilikLahan.Size = New System.Drawing.Size(336, 23)
        Me.txtNoTlpPemilikLahan.TabIndex = 271
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.GroupBox2)
        Me.Panel3.Controls.Add(Me.GroupBox1)
        Me.Panel3.Controls.Add(Me.Panel7)
        Me.Panel3.Controls.Add(Me.ChkNotActive)
        Me.Panel3.Controls.Add(Me.TxtID)
        Me.Panel3.Controls.Add(Me.cbobahanbaku)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.dttgl)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.txtNamaPemilik)
        Me.Panel3.Controls.Add(Me.cboPancang)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1298, 357)
        Me.Panel3.TabIndex = 11
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Panel2)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.cboNamaToke)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.txtNoRekToke)
        Me.GroupBox2.Controls.Add(Me.txtBankToke)
        Me.GroupBox2.Controls.Add(Me.txtNamaRekToke)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.txtNoTlpToke)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Location = New System.Drawing.Point(515, 133)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(459, 207)
        Me.GroupBox2.TabIndex = 905660
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Toke"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 174)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(25, 13)
        Me.Label12.TabIndex = 918
        Me.Label12.Text = "Fee"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.txtFeeToke)
        Me.Panel2.Location = New System.Drawing.Point(102, 168)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(178, 25)
        Me.Panel2.TabIndex = 919
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(4, 5)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(24, 13)
        Me.Label13.TabIndex = 277
        Me.Label13.Text = "Rp."
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(138, 5)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(28, 13)
        Me.Label14.TabIndex = 276
        Me.Label14.Text = "/ Kg"
        '
        'txtFeeToke
        '
        Me.txtFeeToke.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtFeeToke.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFeeToke.Location = New System.Drawing.Point(30, 1)
        Me.txtFeeToke.Name = "txtFeeToke"
        Me.txtFeeToke.Size = New System.Drawing.Size(110, 23)
        Me.txtFeeToke.TabIndex = 275
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(11, 85)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(70, 13)
        Me.Label15.TabIndex = 920
        Me.Label15.Text = "No Rekening"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(11, 114)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(84, 13)
        Me.Label16.TabIndex = 921
        Me.Label16.Text = "Nama Rekening"
        '
        'cboNamaToke
        '
        Me.cboNamaToke.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboNamaToke.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboNamaToke.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboNamaToke.FormattingEnabled = True
        Me.cboNamaToke.IntegralHeight = False
        Me.cboNamaToke.Location = New System.Drawing.Point(102, 21)
        Me.cboNamaToke.Name = "cboNamaToke"
        Me.cboNamaToke.Size = New System.Drawing.Size(336, 24)
        Me.cboNamaToke.TabIndex = 910
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(11, 144)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(32, 13)
        Me.Label17.TabIndex = 924
        Me.Label17.Text = "Bank"
        '
        'txtNoRekToke
        '
        Me.txtNoRekToke.Enabled = False
        Me.txtNoRekToke.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoRekToke.Location = New System.Drawing.Point(101, 80)
        Me.txtNoRekToke.Name = "txtNoRekToke"
        Me.txtNoRekToke.Size = New System.Drawing.Size(227, 23)
        Me.txtNoRekToke.TabIndex = 922
        '
        'txtNamaRekToke
        '
        Me.txtNamaRekToke.Enabled = False
        Me.txtNamaRekToke.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNamaRekToke.Location = New System.Drawing.Point(101, 109)
        Me.txtNamaRekToke.Name = "txtNamaRekToke"
        Me.txtNamaRekToke.Size = New System.Drawing.Size(227, 23)
        Me.txtNamaRekToke.TabIndex = 923
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(12, 54)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(45, 13)
        Me.Label18.TabIndex = 240
        Me.Label18.Text = "No Telp"
        '
        'txtNoTlpToke
        '
        Me.txtNoTlpToke.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoTlpToke.Location = New System.Drawing.Point(102, 51)
        Me.txtNoTlpToke.Name = "txtNoTlpToke"
        Me.txtNoTlpToke.Size = New System.Drawing.Size(336, 23)
        Me.txtNoTlpToke.TabIndex = 271
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(12, 27)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(35, 13)
        Me.Label19.TabIndex = 236
        Me.Label19.Text = "Nama"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cboNamaPemilikLahan)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtNoRekPemilikLahan)
        Me.GroupBox1.Controls.Add(Me.txtBankPemilikLahan)
        Me.GroupBox1.Controls.Add(Me.txtNamaRekPemilikLahan)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtNoTlpPemilikLahan)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(23, 133)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(459, 207)
        Me.GroupBox1.TabIndex = 905659
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pemilik Lahan"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 174)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(25, 13)
        Me.Label6.TabIndex = 918
        Me.Label6.Text = "Fee"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtFeePemilikLahan)
        Me.Panel1.Location = New System.Drawing.Point(102, 168)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(178, 25)
        Me.Panel1.TabIndex = 919
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(4, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(24, 13)
        Me.Label8.TabIndex = 277
        Me.Label8.Text = "Rp."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(138, 5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 13)
        Me.Label7.TabIndex = 276
        Me.Label7.Text = "/ Kg"
        '
        'txtFeePemilikLahan
        '
        Me.txtFeePemilikLahan.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtFeePemilikLahan.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFeePemilikLahan.Location = New System.Drawing.Point(30, 1)
        Me.txtFeePemilikLahan.Name = "txtFeePemilikLahan"
        Me.txtFeePemilikLahan.Size = New System.Drawing.Size(110, 23)
        Me.txtFeePemilikLahan.TabIndex = 275
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 920
        Me.Label2.Text = "No Rekening"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 114)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 13)
        Me.Label4.TabIndex = 921
        Me.Label4.Text = "Nama Rekening"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 144)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 13)
        Me.Label9.TabIndex = 924
        Me.Label9.Text = "Bank"
        '
        'txtNoRekPemilikLahan
        '
        Me.txtNoRekPemilikLahan.Enabled = False
        Me.txtNoRekPemilikLahan.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoRekPemilikLahan.Location = New System.Drawing.Point(101, 80)
        Me.txtNoRekPemilikLahan.Name = "txtNoRekPemilikLahan"
        Me.txtNoRekPemilikLahan.Size = New System.Drawing.Size(227, 23)
        Me.txtNoRekPemilikLahan.TabIndex = 922
        '
        'txtNamaRekPemilikLahan
        '
        Me.txtNamaRekPemilikLahan.Enabled = False
        Me.txtNamaRekPemilikLahan.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNamaRekPemilikLahan.Location = New System.Drawing.Point(101, 109)
        Me.txtNamaRekPemilikLahan.Name = "txtNamaRekPemilikLahan"
        Me.txtNamaRekPemilikLahan.Size = New System.Drawing.Size(227, 23)
        Me.txtNamaRekPemilikLahan.TabIndex = 923
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Silver
        Me.Panel7.Controls.Add(Me.lblJudulForm)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(1296, 30)
        Me.Panel7.TabIndex = 905658
        '
        'lblJudulForm
        '
        Me.lblJudulForm.AutoSize = True
        Me.lblJudulForm.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJudulForm.ForeColor = System.Drawing.Color.Black
        Me.lblJudulForm.Location = New System.Drawing.Point(496, 2)
        Me.lblJudulForm.Name = "lblJudulForm"
        Me.lblJudulForm.Size = New System.Drawing.Size(185, 25)
        Me.lblJudulForm.TabIndex = 0
        Me.lblJudulForm.Text = "MASTER KOMISI"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.scp)
        Me.Panel4.Controls.Add(Me.fg)
        Me.Panel4.Controls.Add(Me.ChkGetAllData)
        Me.Panel4.Controls.Add(Me.btnFind)
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 357)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(0, 40, 0, 0)
        Me.Panel4.Size = New System.Drawing.Size(1298, 330)
        Me.Panel4.TabIndex = 12
        '
        'scp
        '
        Me.scp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.scp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.scp.Location = New System.Drawing.Point(1016, -2)
        Me.scp.Margin = New System.Windows.Forms.Padding(0)
        Me.scp.Name = "scp"
        Me.scp.ShowClearButton = False
        Me.scp.ShowSearchButton = False
        Me.scp.Size = New System.Drawing.Size(302, 37)
        Me.scp.TabIndex = 925
        '
        'fg
        '
        Me.fg.ColumnInfo = resources.GetString("fg.ColumnInfo")
        Me.fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fg.Location = New System.Drawing.Point(0, 40)
        Me.fg.Name = "fg"
        Me.fg.Rows.Count = 10
        Me.fg.Size = New System.Drawing.Size(1296, 246)
        Me.fg.TabIndex = 923
        '
        'ChkGetAllData
        '
        Me.ChkGetAllData.AutoSize = True
        Me.ChkGetAllData.ForeColor = System.Drawing.Color.Black
        Me.ChkGetAllData.Location = New System.Drawing.Point(91, 18)
        Me.ChkGetAllData.Name = "ChkGetAllData"
        Me.ChkGetAllData.Size = New System.Drawing.Size(77, 17)
        Me.ChkGetAllData.TabIndex = 926
        Me.ChkGetAllData.Text = "GetAllData"
        Me.ChkGetAllData.UseVisualStyleBackColor = True
        '
        'btnFind
        '
        Me.btnFind.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnFind.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFind.FlatAppearance.BorderSize = 0
        Me.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnFind.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFind.ForeColor = System.Drawing.Color.Black
        Me.btnFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFind.Location = New System.Drawing.Point(12, 6)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(73, 29)
        Me.btnFind.TabIndex = 224
        Me.btnFind.Text = "Refresh"
        Me.btnFind.UseVisualStyleBackColor = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.White
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.btnExit)
        Me.Panel5.Controls.Add(Me.btnCancel)
        Me.Panel5.Controls.Add(Me.btnSave)
        Me.Panel5.Controls.Add(Me.btnAdd)
        Me.Panel5.Controls.Add(Me.btnEdit)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 286)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1296, 42)
        Me.Panel5.TabIndex = 0
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExit.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.Color.Black
        Me.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExit.Location = New System.Drawing.Point(1213, 6)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 29)
        Me.btnExit.TabIndex = 196
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancel.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(1132, 6)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 29)
        Me.btnCancel.TabIndex = 196
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSave.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(974, 6)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(73, 29)
        Me.btnSave.TabIndex = 197
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAdd.FlatAppearance.BorderSize = 0
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAdd.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.Black
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(895, 6)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(73, 29)
        Me.btnAdd.TabIndex = 195
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEdit.FlatAppearance.BorderSize = 0
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEdit.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.Color.Black
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEdit.Location = New System.Drawing.Point(1053, 6)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(73, 29)
        Me.btnEdit.TabIndex = 194
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'txtBankToke
        '
        Me.txtBankToke.Enabled = False
        Me.txtBankToke.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBankToke.Location = New System.Drawing.Point(101, 138)
        Me.txtBankToke.Name = "txtBankToke"
        Me.txtBankToke.Size = New System.Drawing.Size(227, 23)
        Me.txtBankToke.TabIndex = 923
        '
        'txtBankPemilikLahan
        '
        Me.txtBankPemilikLahan.Enabled = False
        Me.txtBankPemilikLahan.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBankPemilikLahan.Location = New System.Drawing.Point(101, 138)
        Me.txtBankPemilikLahan.Name = "txtBankPemilikLahan"
        Me.txtBankPemilikLahan.Size = New System.Drawing.Size(227, 23)
        Me.txtBankPemilikLahan.TabIndex = 923
        '
        'FrmMstFee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1298, 687)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmMstFee"
        Me.Text = "Master Komisi"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboPancang As ComboBox
    Friend WithEvents txtNamaPemilik As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtNoTlpPemilikLahan As TextBox
    Friend WithEvents dttgl As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents cbobahanbaku As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cboNamaPemilikLahan As ComboBox
    Friend WithEvents TxtID As TextBox
    Friend WithEvents ChkNotActive As CheckBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents ChkGetAllData As CheckBox
    Friend WithEvents scp As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents btnFind As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel5 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtFeePemilikLahan As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtNoRekPemilikLahan As TextBox
    Friend WithEvents txtNamaRekPemilikLahan As TextBox
    Friend WithEvents Panel7 As Panel
    Friend WithEvents lblJudulForm As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtFeeToke As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents cboNamaToke As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtNoRekToke As TextBox
    Friend WithEvents txtNamaRekToke As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtNoTlpToke As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents btnExit As Button
    Friend WithEvents txtBankToke As TextBox
    Friend WithEvents txtBankPemilikLahan As TextBox
End Class
