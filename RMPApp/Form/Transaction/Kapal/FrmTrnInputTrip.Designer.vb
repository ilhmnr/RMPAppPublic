<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTrnInputTrip
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTrnInputTrip))
        Me.grpFilterData = New XanderUI.XUICustomGroupbox()
        Me.chkKapalTenggelam = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.rdP2 = New System.Windows.Forms.RadioButton()
        Me.PanelcmbTrip = New System.Windows.Forms.Panel()
        Me.PanelcmbTrip2 = New System.Windows.Forms.Panel()
        Me.PanelcmbTrip1 = New System.Windows.Forms.Panel()
        Me.cmbTrip = New System.Windows.Forms.ComboBox()
        Me.rdP1 = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DTPTglMasuk = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PanelcmbKapal = New System.Windows.Forms.Panel()
        Me.PanelcmbKapal2 = New System.Windows.Forms.Panel()
        Me.PanelcmbKapal1 = New System.Windows.Forms.Panel()
        Me.cmbKapal = New System.Windows.Forms.ComboBox()
        Me.chkKapal = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PanelPancang = New System.Windows.Forms.Panel()
        Me.PanelPancang2 = New System.Windows.Forms.Panel()
        Me.PanelPancang1 = New System.Windows.Forms.Panel()
        Me.cmbPancang = New System.Windows.Forms.ComboBox()
        Me.chkPancang = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DTPEnd = New System.Windows.Forms.DateTimePicker()
        Me.DTPStart = New System.Windows.Forms.DateTimePicker()
        Me.chkTransDate = New System.Windows.Forms.CheckBox()
        Me.grpDataTimbangCrane = New XanderUI.XUICustomGroupbox()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.schfg = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.grpButton = New XanderUI.XUICustomGroupbox()
        Me.PanelInfo = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TLP = New System.Windows.Forms.TableLayoutPanel()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.TimerInfo = New System.Windows.Forms.Timer(Me.components)
        Me.grpFilterData.SuspendLayout()
        Me.PanelcmbTrip.SuspendLayout()
        Me.PanelcmbKapal.SuspendLayout()
        Me.PanelPancang.SuspendLayout()
        Me.grpDataTimbangCrane.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpButton.SuspendLayout()
        Me.PanelInfo.SuspendLayout()
        Me.TLP.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpFilterData
        '
        Me.grpFilterData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFilterData.BorderColor = System.Drawing.Color.DodgerBlue
        Me.grpFilterData.BorderWidth = 1
        Me.grpFilterData.Controls.Add(Me.chkKapalTenggelam)
        Me.grpFilterData.Controls.Add(Me.Label7)
        Me.grpFilterData.Controls.Add(Me.rdP2)
        Me.grpFilterData.Controls.Add(Me.PanelcmbTrip)
        Me.grpFilterData.Controls.Add(Me.rdP1)
        Me.grpFilterData.Controls.Add(Me.Label4)
        Me.grpFilterData.Controls.Add(Me.DTPTglMasuk)
        Me.grpFilterData.Controls.Add(Me.Label8)
        Me.grpFilterData.Controls.Add(Me.Label5)
        Me.grpFilterData.Controls.Add(Me.btnRefresh)
        Me.grpFilterData.Controls.Add(Me.Label3)
        Me.grpFilterData.Controls.Add(Me.PanelcmbKapal)
        Me.grpFilterData.Controls.Add(Me.chkKapal)
        Me.grpFilterData.Controls.Add(Me.Label2)
        Me.grpFilterData.Controls.Add(Me.PanelPancang)
        Me.grpFilterData.Controls.Add(Me.chkPancang)
        Me.grpFilterData.Controls.Add(Me.Label1)
        Me.grpFilterData.Controls.Add(Me.DTPEnd)
        Me.grpFilterData.Controls.Add(Me.DTPStart)
        Me.grpFilterData.Controls.Add(Me.chkTransDate)
        Me.grpFilterData.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpFilterData.Location = New System.Drawing.Point(6, -1)
        Me.grpFilterData.Name = "grpFilterData"
        Me.grpFilterData.ShowText = True
        Me.grpFilterData.Size = New System.Drawing.Size(1664, 55)
        Me.grpFilterData.TabIndex = 3
        Me.grpFilterData.TabStop = False
        Me.grpFilterData.Text = "Filter Data"
        Me.grpFilterData.TextColor = System.Drawing.Color.Navy
        '
        'chkKapalTenggelam
        '
        Me.chkKapalTenggelam.AutoSize = True
        Me.chkKapalTenggelam.FlatAppearance.BorderSize = 0
        Me.chkKapalTenggelam.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkKapalTenggelam.ForeColor = System.Drawing.Color.Maroon
        Me.chkKapalTenggelam.Location = New System.Drawing.Point(1328, 22)
        Me.chkKapalTenggelam.Name = "chkKapalTenggelam"
        Me.chkKapalTenggelam.Size = New System.Drawing.Size(207, 20)
        Me.chkKapalTenggelam.TabIndex = 256
        Me.chkKapalTenggelam.Text = "Checklist Kapal Tenggelam"
        Me.chkKapalTenggelam.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label7.Location = New System.Drawing.Point(1080, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 16)
        Me.Label7.TabIndex = 208
        Me.Label7.Text = "TRIP"
        '
        'rdP2
        '
        Me.rdP2.AutoSize = True
        Me.rdP2.Checked = True
        Me.rdP2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdP2.Location = New System.Drawing.Point(1257, 22)
        Me.rdP2.Name = "rdP2"
        Me.rdP2.Size = New System.Drawing.Size(40, 20)
        Me.rdP2.TabIndex = 211
        Me.rdP2.TabStop = True
        Me.rdP2.Text = "P2"
        Me.rdP2.UseVisualStyleBackColor = True
        Me.rdP2.Visible = False
        '
        'PanelcmbTrip
        '
        Me.PanelcmbTrip.Controls.Add(Me.PanelcmbTrip2)
        Me.PanelcmbTrip.Controls.Add(Me.PanelcmbTrip1)
        Me.PanelcmbTrip.Controls.Add(Me.cmbTrip)
        Me.PanelcmbTrip.Location = New System.Drawing.Point(1137, 20)
        Me.PanelcmbTrip.Name = "PanelcmbTrip"
        Me.PanelcmbTrip.Size = New System.Drawing.Size(68, 26)
        Me.PanelcmbTrip.TabIndex = 200
        '
        'PanelcmbTrip2
        '
        Me.PanelcmbTrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PanelcmbTrip2.Location = New System.Drawing.Point(4, 25)
        Me.PanelcmbTrip2.MaximumSize = New System.Drawing.Size(61, 1)
        Me.PanelcmbTrip2.MinimumSize = New System.Drawing.Size(2, 1)
        Me.PanelcmbTrip2.Name = "PanelcmbTrip2"
        Me.PanelcmbTrip2.Size = New System.Drawing.Size(5, 1)
        Me.PanelcmbTrip2.TabIndex = 66
        Me.PanelcmbTrip2.Visible = False
        '
        'PanelcmbTrip1
        '
        Me.PanelcmbTrip1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelcmbTrip1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PanelcmbTrip1.Location = New System.Drawing.Point(4, 25)
        Me.PanelcmbTrip1.Name = "PanelcmbTrip1"
        Me.PanelcmbTrip1.Size = New System.Drawing.Size(61, 1)
        Me.PanelcmbTrip1.TabIndex = 65
        '
        'cmbTrip
        '
        Me.cmbTrip.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTrip.BackColor = System.Drawing.Color.LightPink
        Me.cmbTrip.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbTrip.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTrip.ForeColor = System.Drawing.Color.Black
        Me.cmbTrip.FormattingEnabled = True
        Me.cmbTrip.IntegralHeight = False
        Me.cmbTrip.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50"})
        Me.cmbTrip.Location = New System.Drawing.Point(3, 1)
        Me.cmbTrip.Name = "cmbTrip"
        Me.cmbTrip.Size = New System.Drawing.Size(64, 24)
        Me.cmbTrip.TabIndex = 64
        '
        'rdP1
        '
        Me.rdP1.AutoSize = True
        Me.rdP1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdP1.Location = New System.Drawing.Point(1211, 22)
        Me.rdP1.Name = "rdP1"
        Me.rdP1.Size = New System.Drawing.Size(40, 20)
        Me.rdP1.TabIndex = 210
        Me.rdP1.Text = "P1"
        Me.rdP1.UseVisualStyleBackColor = True
        Me.rdP1.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(1119, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 16)
        Me.Label4.TabIndex = 202
        Me.Label4.Text = ":"
        '
        'DTPTglMasuk
        '
        Me.DTPTglMasuk.CustomFormat = "dd MMM yyyy"
        Me.DTPTglMasuk.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPTglMasuk.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPTglMasuk.Location = New System.Drawing.Point(982, 21)
        Me.DTPTglMasuk.Name = "DTPTglMasuk"
        Me.DTPTglMasuk.Size = New System.Drawing.Size(92, 23)
        Me.DTPTglMasuk.TabIndex = 209
        Me.DTPTglMasuk.Value = New Date(2019, 4, 8, 0, 0, 0, 0)
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(859, 26)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(117, 16)
        Me.Label8.TabIndex = 208
        Me.Label8.Text = "Tgl Masuk Kapal"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(640, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 17)
        Me.Label5.TabIndex = 206
        Me.Label5.Text = ":"
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnRefresh.Location = New System.Drawing.Point(1568, 16)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(90, 30)
        Me.btnRefresh.TabIndex = 185
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(367, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 17)
        Me.Label3.TabIndex = 201
        Me.Label3.Text = ":"
        '
        'PanelcmbKapal
        '
        Me.PanelcmbKapal.Controls.Add(Me.PanelcmbKapal2)
        Me.PanelcmbKapal.Controls.Add(Me.PanelcmbKapal1)
        Me.PanelcmbKapal.Controls.Add(Me.cmbKapal)
        Me.PanelcmbKapal.Location = New System.Drawing.Point(657, 20)
        Me.PanelcmbKapal.Name = "PanelcmbKapal"
        Me.PanelcmbKapal.Size = New System.Drawing.Size(196, 26)
        Me.PanelcmbKapal.TabIndex = 205
        '
        'PanelcmbKapal2
        '
        Me.PanelcmbKapal2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PanelcmbKapal2.Location = New System.Drawing.Point(4, 25)
        Me.PanelcmbKapal2.MaximumSize = New System.Drawing.Size(412, 1)
        Me.PanelcmbKapal2.MinimumSize = New System.Drawing.Size(2, 1)
        Me.PanelcmbKapal2.Name = "PanelcmbKapal2"
        Me.PanelcmbKapal2.Size = New System.Drawing.Size(5, 1)
        Me.PanelcmbKapal2.TabIndex = 66
        Me.PanelcmbKapal2.Visible = False
        '
        'PanelcmbKapal1
        '
        Me.PanelcmbKapal1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelcmbKapal1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PanelcmbKapal1.Location = New System.Drawing.Point(4, 25)
        Me.PanelcmbKapal1.Name = "PanelcmbKapal1"
        Me.PanelcmbKapal1.Size = New System.Drawing.Size(189, 1)
        Me.PanelcmbKapal1.TabIndex = 65
        '
        'cmbKapal
        '
        Me.cmbKapal.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbKapal.BackColor = System.Drawing.Color.White
        Me.cmbKapal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbKapal.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbKapal.FormattingEnabled = True
        Me.cmbKapal.IntegralHeight = False
        Me.cmbKapal.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cmbKapal.Location = New System.Drawing.Point(3, 1)
        Me.cmbKapal.Name = "cmbKapal"
        Me.cmbKapal.Size = New System.Drawing.Size(192, 25)
        Me.cmbKapal.TabIndex = 64
        '
        'chkKapal
        '
        Me.chkKapal.AutoSize = True
        Me.chkKapal.FlatAppearance.BorderSize = 0
        Me.chkKapal.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkKapal.Location = New System.Drawing.Point(569, 22)
        Me.chkKapal.Name = "chkKapal"
        Me.chkKapal.Size = New System.Drawing.Size(65, 21)
        Me.chkKapal.TabIndex = 204
        Me.chkKapal.Text = "Kapal"
        Me.chkKapal.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(68, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = ":"
        '
        'PanelPancang
        '
        Me.PanelPancang.Controls.Add(Me.PanelPancang2)
        Me.PanelPancang.Controls.Add(Me.PanelPancang1)
        Me.PanelPancang.Controls.Add(Me.cmbPancang)
        Me.PanelPancang.Location = New System.Drawing.Point(380, 20)
        Me.PanelPancang.Name = "PanelPancang"
        Me.PanelPancang.Size = New System.Drawing.Size(186, 26)
        Me.PanelPancang.TabIndex = 199
        '
        'PanelPancang2
        '
        Me.PanelPancang2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PanelPancang2.Location = New System.Drawing.Point(4, 25)
        Me.PanelPancang2.MaximumSize = New System.Drawing.Size(412, 1)
        Me.PanelPancang2.MinimumSize = New System.Drawing.Size(2, 1)
        Me.PanelPancang2.Name = "PanelPancang2"
        Me.PanelPancang2.Size = New System.Drawing.Size(5, 1)
        Me.PanelPancang2.TabIndex = 66
        Me.PanelPancang2.Visible = False
        '
        'PanelPancang1
        '
        Me.PanelPancang1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelPancang1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PanelPancang1.Location = New System.Drawing.Point(4, 25)
        Me.PanelPancang1.Name = "PanelPancang1"
        Me.PanelPancang1.Size = New System.Drawing.Size(179, 1)
        Me.PanelPancang1.TabIndex = 65
        '
        'cmbPancang
        '
        Me.cmbPancang.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbPancang.BackColor = System.Drawing.Color.White
        Me.cmbPancang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbPancang.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPancang.FormattingEnabled = True
        Me.cmbPancang.IntegralHeight = False
        Me.cmbPancang.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cmbPancang.Location = New System.Drawing.Point(3, 1)
        Me.cmbPancang.Name = "cmbPancang"
        Me.cmbPancang.Size = New System.Drawing.Size(180, 25)
        Me.cmbPancang.TabIndex = 64
        '
        'chkPancang
        '
        Me.chkPancang.AutoSize = True
        Me.chkPancang.FlatAppearance.BorderSize = 0
        Me.chkPancang.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPancang.Location = New System.Drawing.Point(286, 22)
        Me.chkPancang.Name = "chkPancang"
        Me.chkPancang.Size = New System.Drawing.Size(86, 21)
        Me.chkPancang.TabIndex = 195
        Me.chkPancang.Text = "Pancang"
        Me.chkPancang.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(171, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 13)
        Me.Label1.TabIndex = 192
        Me.Label1.Text = "-"
        '
        'DTPEnd
        '
        Me.DTPEnd.CustomFormat = "dd MMM yyyy"
        Me.DTPEnd.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPEnd.Location = New System.Drawing.Point(183, 21)
        Me.DTPEnd.Name = "DTPEnd"
        Me.DTPEnd.Size = New System.Drawing.Size(92, 23)
        Me.DTPEnd.TabIndex = 194
        Me.DTPEnd.Value = New Date(2019, 4, 9, 0, 0, 0, 0)
        '
        'DTPStart
        '
        Me.DTPStart.CustomFormat = "dd MMM yyyy"
        Me.DTPStart.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPStart.Location = New System.Drawing.Point(79, 21)
        Me.DTPStart.Name = "DTPStart"
        Me.DTPStart.Size = New System.Drawing.Size(92, 23)
        Me.DTPStart.TabIndex = 193
        Me.DTPStart.Value = New Date(2019, 4, 8, 0, 0, 0, 0)
        '
        'chkTransDate
        '
        Me.chkTransDate.AutoSize = True
        Me.chkTransDate.Checked = True
        Me.chkTransDate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTransDate.FlatAppearance.BorderSize = 0
        Me.chkTransDate.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTransDate.Location = New System.Drawing.Point(6, 22)
        Me.chkTransDate.Name = "chkTransDate"
        Me.chkTransDate.Size = New System.Drawing.Size(59, 21)
        Me.chkTransDate.TabIndex = 191
        Me.chkTransDate.Tag = "1"
        Me.chkTransDate.Text = "Date"
        Me.chkTransDate.UseVisualStyleBackColor = True
        '
        'grpDataTimbangCrane
        '
        Me.grpDataTimbangCrane.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDataTimbangCrane.BorderColor = System.Drawing.Color.DodgerBlue
        Me.grpDataTimbangCrane.BorderWidth = 1
        Me.grpDataTimbangCrane.Controls.Add(Me.fg)
        Me.grpDataTimbangCrane.Controls.Add(Me.schfg)
        Me.grpDataTimbangCrane.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDataTimbangCrane.Location = New System.Drawing.Point(6, 96)
        Me.grpDataTimbangCrane.Name = "grpDataTimbangCrane"
        Me.grpDataTimbangCrane.ShowText = True
        Me.grpDataTimbangCrane.Size = New System.Drawing.Size(1664, 480)
        Me.grpDataTimbangCrane.TabIndex = 96
        Me.grpDataTimbangCrane.TabStop = False
        Me.grpDataTimbangCrane.Text = "Data Nota Pancang"
        Me.grpDataTimbangCrane.TextColor = System.Drawing.Color.Navy
        '
        'fg
        '
        Me.fg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fg.ColumnInfo = "30,1,0,0,0,110,Columns:1{Style:""TextAlign:GeneralCenter;ImageAlign:CenterCenter;""" &
    ";}" & Global.Microsoft.VisualBasic.ChrW(9) & "26{Style:""TextAlign:GeneralCenter;ImageAlign:CenterCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.fg.ForeColor = System.Drawing.Color.Black
        Me.fg.Location = New System.Drawing.Point(6, 22)
        Me.fg.Name = "fg"
        Me.fg.Rows.Count = 10
        Me.fg.Rows.DefaultSize = 22
        Me.fg.Size = New System.Drawing.Size(1650, 452)
        Me.fg.StyleInfo = resources.GetString("fg.StyleInfo")
        Me.fg.TabIndex = 195
        '
        'schfg
        '
        Me.schfg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.schfg.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.schfg.Location = New System.Drawing.Point(1343, -14)
        Me.schfg.Margin = New System.Windows.Forms.Padding(1)
        Me.schfg.Name = "schfg"
        Me.schfg.ShowClearButton = False
        Me.schfg.ShowSearchButton = False
        Me.schfg.Size = New System.Drawing.Size(349, 37)
        Me.schfg.TabIndex = 194
        '
        'grpButton
        '
        Me.grpButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpButton.BorderColor = System.Drawing.Color.DodgerBlue
        Me.grpButton.BorderWidth = 1
        Me.grpButton.Controls.Add(Me.PanelInfo)
        Me.grpButton.Controls.Add(Me.TLP)
        Me.grpButton.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpButton.Location = New System.Drawing.Point(6, 53)
        Me.grpButton.Name = "grpButton"
        Me.grpButton.ShowText = True
        Me.grpButton.Size = New System.Drawing.Size(1664, 44)
        Me.grpButton.TabIndex = 209
        Me.grpButton.TabStop = False
        Me.grpButton.TextColor = System.Drawing.Color.Navy
        '
        'PanelInfo
        '
        Me.PanelInfo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelInfo.BackColor = System.Drawing.Color.Black
        Me.PanelInfo.Controls.Add(Me.Label6)
        Me.PanelInfo.Location = New System.Drawing.Point(6, 10)
        Me.PanelInfo.Name = "PanelInfo"
        Me.PanelInfo.Size = New System.Drawing.Size(1235, 28)
        Me.PanelInfo.TabIndex = 94
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Lime
        Me.Label6.Location = New System.Drawing.Point(3, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(1151, 19)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = resources.GetString("Label6.Text")
        '
        'TLP
        '
        Me.TLP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TLP.ColumnCount = 3
        Me.TLP.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TLP.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TLP.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TLP.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TLP.Controls.Add(Me.btnSave, 0, 0)
        Me.TLP.Controls.Add(Me.btnFind, 0, 0)
        Me.TLP.Controls.Add(Me.btnCancel, 2, 0)
        Me.TLP.Location = New System.Drawing.Point(1365, 7)
        Me.TLP.Name = "TLP"
        Me.TLP.RowCount = 1
        Me.TLP.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TLP.Size = New System.Drawing.Size(294, 35)
        Me.TLP.TabIndex = 92
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(8, Byte), Integer))
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(101, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(92, 29)
        Me.btnSave.TabIndex = 195
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnFind
        '
        Me.btnFind.BackColor = System.Drawing.Color.MediumOrchid
        Me.btnFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnFind.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFind.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnFind.FlatAppearance.BorderSize = 0
        Me.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFind.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFind.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFind.Location = New System.Drawing.Point(3, 3)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(92, 29)
        Me.btnFind.TabIndex = 193
        Me.btnFind.Text = "Find"
        Me.btnFind.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(86, Byte), Integer))
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(199, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(92, 29)
        Me.btnCancel.TabIndex = 196
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'TimerInfo
        '
        '
        'FrmInputTripNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1677, 580)
        Me.Controls.Add(Me.grpButton)
        Me.Controls.Add(Me.grpDataTimbangCrane)
        Me.Controls.Add(Me.grpFilterData)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmInputTripNew"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Input Tanggal Masuk Kapal"
        Me.grpFilterData.ResumeLayout(False)
        Me.grpFilterData.PerformLayout()
        Me.PanelcmbTrip.ResumeLayout(False)
        Me.PanelcmbKapal.ResumeLayout(False)
        Me.PanelPancang.ResumeLayout(False)
        Me.grpDataTimbangCrane.ResumeLayout(False)
        Me.grpDataTimbangCrane.PerformLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpButton.ResumeLayout(False)
        Me.grpButton.PerformLayout()
        Me.PanelInfo.ResumeLayout(False)
        Me.PanelInfo.PerformLayout()
        Me.TLP.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grpFilterData As XanderUI.XUICustomGroupbox
    Friend WithEvents Label5 As Label
    Friend WithEvents PanelcmbKapal As Panel
    Friend WithEvents PanelcmbKapal2 As Panel
    Friend WithEvents PanelcmbKapal1 As Panel
    Friend WithEvents cmbKapal As ComboBox
    Friend WithEvents chkKapal As CheckBox
    Friend WithEvents btnRefresh As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PanelPancang As Panel
    Friend WithEvents PanelPancang2 As Panel
    Friend WithEvents PanelPancang1 As Panel
    Friend WithEvents cmbPancang As ComboBox
    Friend WithEvents chkPancang As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DTPEnd As DateTimePicker
    Friend WithEvents DTPStart As DateTimePicker
    Friend WithEvents chkTransDate As CheckBox
    Friend WithEvents grpDataTimbangCrane As XanderUI.XUICustomGroupbox
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents schfg As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents grpButton As XanderUI.XUICustomGroupbox
    Friend WithEvents Label7 As Label
    Friend WithEvents PanelInfo As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents TLP As TableLayoutPanel
    Friend WithEvents btnSave As Button
    Friend WithEvents btnFind As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents PanelcmbTrip As Panel
    Friend WithEvents PanelcmbTrip2 As Panel
    Friend WithEvents PanelcmbTrip1 As Panel
    Friend WithEvents cmbTrip As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TimerInfo As Timer
    Friend WithEvents DTPTglMasuk As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents rdP2 As RadioButton
    Friend WithEvents rdP1 As RadioButton
    Friend WithEvents chkKapalTenggelam As CheckBox
End Class
