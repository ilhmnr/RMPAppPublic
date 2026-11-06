<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMstKapal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMstKapal))
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.PanelForm = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnFileChoose = New System.Windows.Forms.Button()
        Me.ocxAttachment = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.CmbKaptenKapala = New System.Windows.Forms.ComboBox()
        Me.CmbBodyKapal = New System.Windows.Forms.ComboBox()
        Me.CmbPancang = New System.Windows.Forms.ComboBox()
        Me.chkPontianak = New System.Windows.Forms.CheckBox()
        Me.chkCrane = New System.Windows.Forms.CheckBox()
        Me.TxtIDKapal = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtTahunKapal = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtRemarkInActive = New System.Windows.Forms.TextBox()
        Me.chkNonActive = New System.Windows.Forms.CheckBox()
        Me.TxtNoHpKapten = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtPemilikKapal = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtDayaMesinKapal = New System.Windows.Forms.TextBox()
        Me.TxtNamaKapal = New System.Windows.Forms.TextBox()
        Me.TxtKapasitasKapal = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.isNonAsuransi = New System.Windows.Forms.CheckBox()
        Me.PanelForm.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ocxAttachment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'PanelForm
        '
        Me.PanelForm.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PanelForm.Controls.Add(Me.Panel4)
        Me.PanelForm.Controls.Add(Me.Panel3)
        Me.PanelForm.Controls.Add(Me.Panel2)
        Me.PanelForm.Location = New System.Drawing.Point(8, 47)
        Me.PanelForm.Name = "PanelForm"
        Me.PanelForm.Size = New System.Drawing.Size(886, 496)
        Me.PanelForm.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.isNonAsuransi)
        Me.Panel4.Controls.Add(Me.Label15)
        Me.Panel4.Controls.Add(Me.GroupBox1)
        Me.Panel4.Controls.Add(Me.Label13)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.Panel7)
        Me.Panel4.Controls.Add(Me.CmbKaptenKapala)
        Me.Panel4.Controls.Add(Me.CmbBodyKapal)
        Me.Panel4.Controls.Add(Me.CmbPancang)
        Me.Panel4.Controls.Add(Me.chkPontianak)
        Me.Panel4.Controls.Add(Me.chkCrane)
        Me.Panel4.Controls.Add(Me.TxtIDKapal)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.TxtTahunKapal)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.TxtRemarkInActive)
        Me.Panel4.Controls.Add(Me.chkNonActive)
        Me.Panel4.Controls.Add(Me.TxtNoHpKapten)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.TxtPemilikKapal)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.TxtDayaMesinKapal)
        Me.Panel4.Controls.Add(Me.TxtNamaKapal)
        Me.Panel4.Controls.Add(Me.TxtKapasitasKapal)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 40)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(886, 416)
        Me.Panel4.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label15.Location = New System.Drawing.Point(16, 17)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 21)
        Me.Label15.TabIndex = 905710
        Me.Label15.Text = "ID Kapal"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.btnFileChoose)
        Me.GroupBox1.Controls.Add(Me.ocxAttachment)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 218)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(5, 35, 5, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(845, 192)
        Me.GroupBox1.TabIndex = 905709
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Attachment"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(2, 34)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(529, 13)
        Me.Label14.TabIndex = 905703
        Me.Label14.Text = "Catatan: Harap isi kolom remark sesuai jenis dokumen yang diunggah, misalnya: KAP" &
    "AL atau SURAT." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnFileChoose
        '
        Me.btnFileChoose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFileChoose.BackColor = System.Drawing.Color.White
        Me.btnFileChoose.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFileChoose.Image = CType(resources.GetObject("btnFileChoose.Image"), System.Drawing.Image)
        Me.btnFileChoose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFileChoose.Location = New System.Drawing.Point(765, 14)
        Me.btnFileChoose.Name = "btnFileChoose"
        Me.btnFileChoose.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnFileChoose.Size = New System.Drawing.Size(75, 30)
        Me.btnFileChoose.TabIndex = 7
        Me.btnFileChoose.Text = "Browse"
        Me.btnFileChoose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFileChoose.UseVisualStyleBackColor = False
        '
        'ocxAttachment
        '
        Me.ocxAttachment.ColumnInfo = resources.GetString("ocxAttachment.ColumnInfo")
        Me.ocxAttachment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ocxAttachment.Location = New System.Drawing.Point(5, 48)
        Me.ocxAttachment.Name = "ocxAttachment"
        Me.ocxAttachment.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.ocxAttachment.Size = New System.Drawing.Size(835, 139)
        Me.ocxAttachment.TabIndex = 905699
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label13.Location = New System.Drawing.Point(397, 117)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(28, 21)
        Me.Label13.TabIndex = 905708
        Me.Label13.Text = "KG"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label5.Location = New System.Drawing.Point(397, 143)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 21)
        Me.Label5.TabIndex = 905707
        Me.Label5.Text = "PK"
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Black
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(886, 1)
        Me.Panel7.TabIndex = 905706
        '
        'CmbKaptenKapala
        '
        Me.CmbKaptenKapala.FormattingEnabled = True
        Me.CmbKaptenKapala.Location = New System.Drawing.Point(587, 64)
        Me.CmbKaptenKapala.Name = "CmbKaptenKapala"
        Me.CmbKaptenKapala.Size = New System.Drawing.Size(275, 21)
        Me.CmbKaptenKapala.TabIndex = 908
        '
        'CmbBodyKapal
        '
        Me.CmbBodyKapal.FormattingEnabled = True
        Me.CmbBodyKapal.Location = New System.Drawing.Point(587, 17)
        Me.CmbBodyKapal.Name = "CmbBodyKapal"
        Me.CmbBodyKapal.Size = New System.Drawing.Size(275, 21)
        Me.CmbBodyKapal.TabIndex = 906
        '
        'CmbPancang
        '
        Me.CmbPancang.FormattingEnabled = True
        Me.CmbPancang.Location = New System.Drawing.Point(148, 92)
        Me.CmbPancang.Name = "CmbPancang"
        Me.CmbPancang.Size = New System.Drawing.Size(275, 21)
        Me.CmbPancang.TabIndex = 903
        '
        'chkPontianak
        '
        Me.chkPontianak.AutoSize = True
        Me.chkPontianak.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPontianak.ForeColor = System.Drawing.Color.Maroon
        Me.chkPontianak.Location = New System.Drawing.Point(785, 166)
        Me.chkPontianak.Name = "chkPontianak"
        Me.chkPontianak.Size = New System.Drawing.Size(84, 20)
        Me.chkPontianak.TabIndex = 205
        Me.chkPontianak.Text = "Pontianak"
        Me.chkPontianak.UseVisualStyleBackColor = True
        '
        'chkCrane
        '
        Me.chkCrane.AutoSize = True
        Me.chkCrane.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCrane.ForeColor = System.Drawing.Color.Maroon
        Me.chkCrane.Location = New System.Drawing.Point(680, 166)
        Me.chkCrane.Name = "chkCrane"
        Me.chkCrane.Size = New System.Drawing.Size(99, 20)
        Me.chkCrane.TabIndex = 204
        Me.chkCrane.Text = "Kapal Crane"
        Me.chkCrane.UseVisualStyleBackColor = True
        '
        'TxtIDKapal
        '
        Me.TxtIDKapal.Location = New System.Drawing.Point(148, 17)
        Me.TxtIDKapal.Name = "TxtIDKapal"
        Me.TxtIDKapal.ReadOnly = True
        Me.TxtIDKapal.Size = New System.Drawing.Size(138, 20)
        Me.TxtIDKapal.TabIndex = 202
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label10.Location = New System.Drawing.Point(462, 42)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 18)
        Me.Label10.TabIndex = 198
        Me.Label10.Text = "Tahun Kapal"
        '
        'TxtTahunKapal
        '
        Me.TxtTahunKapal.Location = New System.Drawing.Point(587, 41)
        Me.TxtTahunKapal.Name = "TxtTahunKapal"
        Me.TxtTahunKapal.Size = New System.Drawing.Size(277, 20)
        Me.TxtTahunKapal.TabIndex = 907
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label9.Location = New System.Drawing.Point(462, 118)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(119, 46)
        Me.Label9.TabIndex = 196
        Me.Label9.Text = "Remark InActive"
        '
        'TxtRemarkInActive
        '
        Me.TxtRemarkInActive.Location = New System.Drawing.Point(587, 114)
        Me.TxtRemarkInActive.Multiline = True
        Me.TxtRemarkInActive.Name = "TxtRemarkInActive"
        Me.TxtRemarkInActive.Size = New System.Drawing.Size(277, 46)
        Me.TxtRemarkInActive.TabIndex = 910
        '
        'chkNonActive
        '
        Me.chkNonActive.AutoSize = True
        Me.chkNonActive.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNonActive.ForeColor = System.Drawing.Color.Maroon
        Me.chkNonActive.Location = New System.Drawing.Point(587, 166)
        Me.chkNonActive.Name = "chkNonActive"
        Me.chkNonActive.Size = New System.Drawing.Size(87, 20)
        Me.chkNonActive.TabIndex = 194
        Me.chkNonActive.Text = "Not Active"
        Me.chkNonActive.UseVisualStyleBackColor = True
        '
        'TxtNoHpKapten
        '
        Me.TxtNoHpKapten.BackColor = System.Drawing.SystemColors.Window
        Me.TxtNoHpKapten.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNoHpKapten.Location = New System.Drawing.Point(587, 88)
        Me.TxtNoHpKapten.Name = "TxtNoHpKapten"
        Me.TxtNoHpKapten.Size = New System.Drawing.Size(277, 23)
        Me.TxtNoHpKapten.TabIndex = 909
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label7.Location = New System.Drawing.Point(462, 89)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 21)
        Me.Label7.TabIndex = 192
        Me.Label7.Text = "No.HP Kapten"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label6.Location = New System.Drawing.Point(462, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 21)
        Me.Label6.TabIndex = 191
        Me.Label6.Text = "Kapten Kapal"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label8.Location = New System.Drawing.Point(16, 92)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 21)
        Me.Label8.TabIndex = 190
        Me.Label8.Text = "Pancang"
        '
        'TxtPemilikKapal
        '
        Me.TxtPemilikKapal.BackColor = System.Drawing.SystemColors.Window
        Me.TxtPemilikKapal.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPemilikKapal.Location = New System.Drawing.Point(148, 66)
        Me.TxtPemilikKapal.Name = "TxtPemilikKapal"
        Me.TxtPemilikKapal.Size = New System.Drawing.Size(277, 23)
        Me.TxtPemilikKapal.TabIndex = 902
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(16, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 19)
        Me.Label1.TabIndex = 181
        Me.Label1.Text = "Pemilik Kapal"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(16, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 21)
        Me.Label3.TabIndex = 182
        Me.Label3.Text = "Nama Kapal"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label12.Location = New System.Drawing.Point(462, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(110, 21)
        Me.Label12.TabIndex = 185
        Me.Label12.Text = "Body Kapal"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label11.Location = New System.Drawing.Point(16, 143)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(126, 21)
        Me.Label11.TabIndex = 184
        Me.Label11.Text = "Daya Mesin Kapal"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(16, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 21)
        Me.Label4.TabIndex = 183
        Me.Label4.Text = "Kapasitas Kapal"
        '
        'TxtDayaMesinKapal
        '
        Me.TxtDayaMesinKapal.BackColor = System.Drawing.SystemColors.Window
        Me.TxtDayaMesinKapal.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDayaMesinKapal.Location = New System.Drawing.Point(148, 142)
        Me.TxtDayaMesinKapal.Name = "TxtDayaMesinKapal"
        Me.TxtDayaMesinKapal.Size = New System.Drawing.Size(243, 23)
        Me.TxtDayaMesinKapal.TabIndex = 905
        '
        'TxtNamaKapal
        '
        Me.TxtNamaKapal.BackColor = System.Drawing.SystemColors.Window
        Me.TxtNamaKapal.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNamaKapal.Location = New System.Drawing.Point(148, 40)
        Me.TxtNamaKapal.Name = "TxtNamaKapal"
        Me.TxtNamaKapal.Size = New System.Drawing.Size(277, 23)
        Me.TxtNamaKapal.TabIndex = 901
        '
        'TxtKapasitasKapal
        '
        Me.TxtKapasitasKapal.BackColor = System.Drawing.SystemColors.Window
        Me.TxtKapasitasKapal.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKapasitasKapal.Location = New System.Drawing.Point(148, 116)
        Me.TxtKapasitasKapal.Name = "TxtKapasitasKapal"
        Me.TxtKapasitasKapal.Size = New System.Drawing.Size(243, 23)
        Me.TxtKapasitasKapal.TabIndex = 904
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Panel6)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(886, 40)
        Me.Panel3.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(49, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(137, 28)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Master Kapal"
        '
        'Panel6
        '
        Me.Panel6.BackgroundImage = CType(resources.GetObject("Panel6.BackgroundImage"), System.Drawing.Image)
        Me.Panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel6.Location = New System.Drawing.Point(13, 3)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(35, 35)
        Me.Panel6.TabIndex = 7
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnFind)
        Me.Panel2.Controls.Add(Me.btnExit)
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Controls.Add(Me.btnSave)
        Me.Panel2.Controls.Add(Me.btnEdit)
        Me.Panel2.Controls.Add(Me.btnAdd)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 456)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(886, 40)
        Me.Panel2.TabIndex = 0
        '
        'btnFind
        '
        Me.btnFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnFind.BackColor = System.Drawing.Color.White
        Me.btnFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnFind.Image = CType(resources.GetObject("btnFind.Image"), System.Drawing.Image)
        Me.btnFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFind.Location = New System.Drawing.Point(7, 5)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnFind.Size = New System.Drawing.Size(75, 30)
        Me.btnFind.TabIndex = 195
        Me.btnFind.Text = "Find"
        Me.btnFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFind.UseVisualStyleBackColor = False
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.BackColor = System.Drawing.Color.White
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExit.Location = New System.Drawing.Point(804, 5)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnExit.Size = New System.Drawing.Size(75, 30)
        Me.btnExit.TabIndex = 194
        Me.btnExit.Text = "Exit"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.White
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(728, 5)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Padding = New System.Windows.Forms.Padding(5, 0, 3, 0)
        Me.btnCancel.Size = New System.Drawing.Size(75, 30)
        Me.btnCancel.TabIndex = 193
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.White
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(652, 5)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnSave.Size = New System.Drawing.Size(75, 30)
        Me.btnSave.TabIndex = 192
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BackColor = System.Drawing.Color.White
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEdit.Location = New System.Drawing.Point(576, 5)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnEdit.Size = New System.Drawing.Size(75, 30)
        Me.btnEdit.TabIndex = 191
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.White
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(500, 5)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnAdd.Size = New System.Drawing.Size(75, 30)
        Me.btnAdd.TabIndex = 190
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'isNonAsuransi
        '
        Me.isNonAsuransi.AutoSize = True
        Me.isNonAsuransi.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.isNonAsuransi.ForeColor = System.Drawing.Color.Maroon
        Me.isNonAsuransi.Location = New System.Drawing.Point(587, 192)
        Me.isNonAsuransi.Name = "isNonAsuransi"
        Me.isNonAsuransi.Size = New System.Drawing.Size(148, 20)
        Me.isNonAsuransi.TabIndex = 905711
        Me.isNonAsuransi.Text = "Tidak Hitung Asuransi"
        Me.isNonAsuransi.UseVisualStyleBackColor = True
        '
        'FrmMstKapal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(904, 587)
        Me.Controls.Add(Me.PanelForm)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmMstKapal"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Master Kapal"
        Me.PanelForm.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ocxAttachment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents PanelForm As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents CmbKaptenKapala As ComboBox
    Friend WithEvents CmbBodyKapal As ComboBox
    Friend WithEvents CmbPancang As ComboBox
    Friend WithEvents chkPontianak As CheckBox
    Friend WithEvents chkCrane As CheckBox
    Friend WithEvents TxtIDKapal As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TxtTahunKapal As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TxtRemarkInActive As TextBox
    Friend WithEvents chkNonActive As CheckBox
    Friend WithEvents TxtNoHpKapten As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TxtPemilikKapal As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtDayaMesinKapal As TextBox
    Friend WithEvents TxtNamaKapal As TextBox
    Friend WithEvents TxtKapasitasKapal As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label13 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label14 As Label
    Friend WithEvents btnFileChoose As Button
    Friend WithEvents ocxAttachment As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents btnExit As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnFind As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents isNonAsuransi As CheckBox
End Class
