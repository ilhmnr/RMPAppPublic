<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMstUpahBongkarMuat
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMstUpahBongkarMuat))
        Me.grpFilterData = New XanderUI.XUICustomGroupbox()
        Me.cbobahanbaku = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.rdLaut = New System.Windows.Forms.RadioButton()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.txtCari = New System.Windows.Forms.TextBox()
        Me.rdDarat = New System.Windows.Forms.RadioButton()
        Me.XuiCustomGroupbox1 = New XanderUI.XUICustomGroupbox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtKet = New System.Windows.Forms.TextBox()
        Me.dtpPeriode = New System.Windows.Forms.DateTimePicker()
        Me.TxtUpahKapalCrane = New System.Windows.Forms.TextBox()
        Me.PanelPancang = New System.Windows.Forms.Panel()
        Me.PanelPancang2 = New System.Windows.Forms.Panel()
        Me.PanelPancang1 = New System.Windows.Forms.Panel()
        Me.cmbPancang = New System.Windows.Forms.ComboBox()
        Me.txtUpah = New System.Windows.Forms.TextBox()
        Me.txtIDUpah = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.XuiCustomGroupbox2 = New XanderUI.XUICustomGroupbox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dtp2 = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.cmbPancang2 = New System.Windows.Forms.ComboBox()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.dgvlist = New System.Windows.Forms.DataGridView()
        Me.No = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDTambang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDPancang2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pancang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Periode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UpahTambang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UpahTambangKapalCrane = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KodeBB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JenisBahanBaku = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Keterangan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreatedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreatedDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UpdatedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UpdatedDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.grpFilterData.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.XuiCustomGroupbox1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.PanelPancang.SuspendLayout()
        Me.XuiCustomGroupbox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel15.SuspendLayout()
        CType(Me.dgvlist, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpFilterData
        '
        Me.grpFilterData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFilterData.BackColor = System.Drawing.Color.White
        Me.grpFilterData.BorderColor = System.Drawing.Color.DodgerBlue
        Me.grpFilterData.BorderWidth = 1
        Me.grpFilterData.Controls.Add(Me.Label9)
        Me.grpFilterData.Controls.Add(Me.cbobahanbaku)
        Me.grpFilterData.Controls.Add(Me.Label7)
        Me.grpFilterData.Controls.Add(Me.rdLaut)
        Me.grpFilterData.Controls.Add(Me.Panel12)
        Me.grpFilterData.Controls.Add(Me.rdDarat)
        Me.grpFilterData.Controls.Add(Me.XuiCustomGroupbox1)
        Me.grpFilterData.Controls.Add(Me.Label5)
        Me.grpFilterData.Controls.Add(Me.Label8)
        Me.grpFilterData.Controls.Add(Me.Label4)
        Me.grpFilterData.Controls.Add(Me.Label3)
        Me.grpFilterData.Controls.Add(Me.txtKet)
        Me.grpFilterData.Controls.Add(Me.dtpPeriode)
        Me.grpFilterData.Controls.Add(Me.TxtUpahKapalCrane)
        Me.grpFilterData.Controls.Add(Me.PanelPancang)
        Me.grpFilterData.Controls.Add(Me.txtUpah)
        Me.grpFilterData.Controls.Add(Me.txtIDUpah)
        Me.grpFilterData.Controls.Add(Me.Label2)
        Me.grpFilterData.Controls.Add(Me.Label1)
        Me.grpFilterData.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpFilterData.Location = New System.Drawing.Point(12, 12)
        Me.grpFilterData.Name = "grpFilterData"
        Me.grpFilterData.ShowText = True
        Me.grpFilterData.Size = New System.Drawing.Size(1015, 336)
        Me.grpFilterData.TabIndex = 8
        Me.grpFilterData.TabStop = False
        Me.grpFilterData.Text = "Filter Data"
        Me.grpFilterData.TextColor = System.Drawing.Color.Navy
        '
        'cbobahanbaku
        '
        Me.cbobahanbaku.FormattingEnabled = True
        Me.cbobahanbaku.Location = New System.Drawing.Point(228, 128)
        Me.cbobahanbaku.Name = "cbobahanbaku"
        Me.cbobahanbaku.Size = New System.Drawing.Size(175, 25)
        Me.cbobahanbaku.TabIndex = 395
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 132)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 17)
        Me.Label7.TabIndex = 394
        Me.Label7.Text = "Jenis"
        '
        'rdLaut
        '
        Me.rdLaut.AutoSize = True
        Me.rdLaut.Checked = True
        Me.rdLaut.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdLaut.Location = New System.Drawing.Point(414, 130)
        Me.rdLaut.Name = "rdLaut"
        Me.rdLaut.Size = New System.Drawing.Size(52, 20)
        Me.rdLaut.TabIndex = 234
        Me.rdLaut.TabStop = True
        Me.rdLaut.Text = "Laut"
        Me.rdLaut.UseVisualStyleBackColor = True
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.White
        Me.Panel12.Controls.Add(Me.txtCari)
        Me.Panel12.Location = New System.Drawing.Point(539, 235)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(378, 34)
        Me.Panel12.TabIndex = 388
        Me.Panel12.Visible = False
        '
        'txtCari
        '
        Me.txtCari.BackColor = System.Drawing.Color.White
        Me.txtCari.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCari.Location = New System.Drawing.Point(7, 9)
        Me.txtCari.Name = "txtCari"
        Me.txtCari.Size = New System.Drawing.Size(366, 16)
        Me.txtCari.TabIndex = 67
        Me.txtCari.Text = "Search"
        '
        'rdDarat
        '
        Me.rdDarat.AutoSize = True
        Me.rdDarat.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdDarat.Location = New System.Drawing.Point(472, 130)
        Me.rdDarat.Name = "rdDarat"
        Me.rdDarat.Size = New System.Drawing.Size(61, 20)
        Me.rdDarat.TabIndex = 233
        Me.rdDarat.Text = "Darat"
        Me.rdDarat.UseVisualStyleBackColor = True
        '
        'XuiCustomGroupbox1
        '
        Me.XuiCustomGroupbox1.BorderColor = System.Drawing.Color.DodgerBlue
        Me.XuiCustomGroupbox1.BorderWidth = 1
        Me.XuiCustomGroupbox1.Controls.Add(Me.TableLayoutPanel1)
        Me.XuiCustomGroupbox1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XuiCustomGroupbox1.Location = New System.Drawing.Point(539, 270)
        Me.XuiCustomGroupbox1.Name = "XuiCustomGroupbox1"
        Me.XuiCustomGroupbox1.ShowText = True
        Me.XuiCustomGroupbox1.Size = New System.Drawing.Size(378, 50)
        Me.XuiCustomGroupbox1.TabIndex = 9
        Me.XuiCustomGroupbox1.TabStop = False
        Me.XuiCustomGroupbox1.TextColor = System.Drawing.Color.Navy
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnFind, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCancel, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnSave, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnEdit, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAdd, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(6, 9)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(367, 35)
        Me.TableLayoutPanel1.TabIndex = 231
        '
        'btnFind
        '
        Me.btnFind.BackColor = System.Drawing.Color.OliveDrab
        Me.btnFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnFind.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFind.FlatAppearance.BorderSize = 0
        Me.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFind.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFind.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFind.Location = New System.Drawing.Point(3, 3)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(67, 29)
        Me.btnFind.TabIndex = 224
        Me.btnFind.Text = "Find"
        Me.btnFind.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.PaleVioletRed
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(295, 3)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 29)
        Me.btnCancel.TabIndex = 196
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.DarkGoldenrod
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(149, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(67, 29)
        Me.btnSave.TabIndex = 197
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.Color.DarkGoldenrod
        Me.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEdit.FlatAppearance.BorderSize = 0
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEdit.Location = New System.Drawing.Point(222, 3)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(67, 29)
        Me.btnEdit.TabIndex = 194
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.OliveDrab
        Me.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAdd.FlatAppearance.BorderSize = 0
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(76, 3)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(67, 29)
        Me.btnAdd.TabIndex = 195
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 252)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 17)
        Me.Label5.TabIndex = 229
        Me.Label5.Text = "Keterangan"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 220)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(203, 17)
        Me.Label8.TabIndex = 228
        Me.Label8.Text = "Upah Tambang (Kapal Crane)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 191)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 17)
        Me.Label4.TabIndex = 228
        Me.Label4.Text = "Upah Tambang"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 162)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 17)
        Me.Label3.TabIndex = 227
        Me.Label3.Text = "Periode"
        '
        'txtKet
        '
        Me.txtKet.Location = New System.Drawing.Point(228, 249)
        Me.txtKet.Multiline = True
        Me.txtKet.Name = "txtKet"
        Me.txtKet.Size = New System.Drawing.Size(305, 71)
        Me.txtKet.TabIndex = 226
        '
        'dtpPeriode
        '
        Me.dtpPeriode.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPeriode.Location = New System.Drawing.Point(228, 159)
        Me.dtpPeriode.Name = "dtpPeriode"
        Me.dtpPeriode.Size = New System.Drawing.Size(175, 23)
        Me.dtpPeriode.TabIndex = 225
        '
        'TxtUpahKapalCrane
        '
        Me.TxtUpahKapalCrane.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUpahKapalCrane.Location = New System.Drawing.Point(228, 217)
        Me.TxtUpahKapalCrane.Name = "TxtUpahKapalCrane"
        Me.TxtUpahKapalCrane.Size = New System.Drawing.Size(96, 23)
        Me.TxtUpahKapalCrane.TabIndex = 223
        Me.TxtUpahKapalCrane.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PanelPancang
        '
        Me.PanelPancang.Controls.Add(Me.PanelPancang2)
        Me.PanelPancang.Controls.Add(Me.PanelPancang1)
        Me.PanelPancang.Controls.Add(Me.cmbPancang)
        Me.PanelPancang.Location = New System.Drawing.Point(228, 96)
        Me.PanelPancang.Name = "PanelPancang"
        Me.PanelPancang.Size = New System.Drawing.Size(305, 26)
        Me.PanelPancang.TabIndex = 224
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
        Me.PanelPancang1.Size = New System.Drawing.Size(298, 1)
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
        Me.cmbPancang.Size = New System.Drawing.Size(301, 25)
        Me.cmbPancang.TabIndex = 64
        '
        'txtUpah
        '
        Me.txtUpah.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpah.Location = New System.Drawing.Point(228, 188)
        Me.txtUpah.Name = "txtUpah"
        Me.txtUpah.Size = New System.Drawing.Size(96, 23)
        Me.txtUpah.TabIndex = 223
        Me.txtUpah.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIDUpah
        '
        Me.txtIDUpah.BackColor = System.Drawing.SystemColors.Info
        Me.txtIDUpah.Location = New System.Drawing.Point(228, 67)
        Me.txtIDUpah.Name = "txtIDUpah"
        Me.txtIDUpah.ReadOnly = True
        Me.txtIDUpah.Size = New System.Drawing.Size(96, 23)
        Me.txtIDUpah.TabIndex = 222
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 17)
        Me.Label2.TabIndex = 221
        Me.Label2.Text = "Pancang"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 17)
        Me.Label1.TabIndex = 220
        Me.Label1.Text = "ID Upah"
        '
        'XuiCustomGroupbox2
        '
        Me.XuiCustomGroupbox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XuiCustomGroupbox2.BorderColor = System.Drawing.Color.DodgerBlue
        Me.XuiCustomGroupbox2.BorderWidth = 1
        Me.XuiCustomGroupbox2.Controls.Add(Me.GroupBox3)
        Me.XuiCustomGroupbox2.Controls.Add(Me.Panel15)
        Me.XuiCustomGroupbox2.Controls.Add(Me.btnLoad)
        Me.XuiCustomGroupbox2.Controls.Add(Me.dgvlist)
        Me.XuiCustomGroupbox2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XuiCustomGroupbox2.Location = New System.Drawing.Point(12, 354)
        Me.XuiCustomGroupbox2.Name = "XuiCustomGroupbox2"
        Me.XuiCustomGroupbox2.ShowText = True
        Me.XuiCustomGroupbox2.Size = New System.Drawing.Size(1015, 239)
        Me.XuiCustomGroupbox2.TabIndex = 235
        Me.XuiCustomGroupbox2.TabStop = False
        Me.XuiCustomGroupbox2.Text = "Monitoring"
        Me.XuiCustomGroupbox2.TextColor = System.Drawing.Color.Navy
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dtp2)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.dtp1)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 22)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(368, 44)
        Me.GroupBox3.TabIndex = 391
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Periode"
        '
        'dtp2
        '
        Me.dtp2.Enabled = False
        Me.dtp2.Location = New System.Drawing.Point(203, 16)
        Me.dtp2.Name = "dtp2"
        Me.dtp2.Size = New System.Drawing.Size(158, 23)
        Me.dtp2.TabIndex = 381
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(168, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 17)
        Me.Label6.TabIndex = 380
        Me.Label6.Text = "s/d"
        '
        'dtp1
        '
        Me.dtp1.CalendarTrailingForeColor = System.Drawing.Color.White
        Me.dtp1.Checked = False
        Me.dtp1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtp1.CustomFormat = "MMMM"
        Me.dtp1.Location = New System.Drawing.Point(5, 16)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.ShowCheckBox = True
        Me.dtp1.Size = New System.Drawing.Size(158, 23)
        Me.dtp1.TabIndex = 379
        '
        'Panel15
        '
        Me.Panel15.BackColor = System.Drawing.Color.White
        Me.Panel15.Controls.Add(Me.cmbPancang2)
        Me.Panel15.Location = New System.Drawing.Point(380, 31)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(334, 33)
        Me.Panel15.TabIndex = 389
        '
        'cmbPancang2
        '
        Me.cmbPancang2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbPancang2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPancang2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbPancang2.FormattingEnabled = True
        Me.cmbPancang2.Location = New System.Drawing.Point(5, 4)
        Me.cmbPancang2.Name = "cmbPancang2"
        Me.cmbPancang2.Size = New System.Drawing.Size(326, 25)
        Me.cmbPancang2.TabIndex = 344
        Me.cmbPancang2.Text = "Pancang"
        '
        'btnLoad
        '
        Me.btnLoad.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.btnLoad.BackgroundImage = Global.RMPApp.My.Resources.Resources._3407006
        Me.btnLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLoad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.btnLoad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.btnLoad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Location = New System.Drawing.Point(717, 35)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(30, 25)
        Me.btnLoad.TabIndex = 387
        Me.btnLoad.UseVisualStyleBackColor = False
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
        Me.dgvlist.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvlist.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvlist.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvlist.ColumnHeadersHeight = 45
        Me.dgvlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvlist.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.No, Me.IDTambang, Me.IDPancang2, Me.Pancang, Me.Periode, Me.UpahTambang, Me.UpahTambangKapalCrane, Me.KodeBB, Me.JenisBahanBaku, Me.Keterangan, Me.CreatedBy, Me.CreatedDate, Me.UpdatedBy, Me.UpdatedDate})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvlist.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvlist.GridColor = System.Drawing.SystemColors.ButtonFace
        Me.dgvlist.Location = New System.Drawing.Point(6, 72)
        Me.dgvlist.Name = "dgvlist"
        Me.dgvlist.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvlist.RowHeadersVisible = False
        Me.dgvlist.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        Me.dgvlist.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvlist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvlist.Size = New System.Drawing.Size(1003, 161)
        Me.dgvlist.TabIndex = 386
        '
        'No
        '
        Me.No.Frozen = True
        Me.No.HeaderText = "No"
        Me.No.Name = "No"
        Me.No.Width = 60
        '
        'IDTambang
        '
        Me.IDTambang.HeaderText = "IDBongkar"
        Me.IDTambang.Name = "IDTambang"
        Me.IDTambang.Visible = False
        '
        'IDPancang2
        '
        Me.IDPancang2.Frozen = True
        Me.IDPancang2.HeaderText = "IDPancang"
        Me.IDPancang2.Name = "IDPancang2"
        '
        'Pancang
        '
        Me.Pancang.HeaderText = "Pancang"
        Me.Pancang.Name = "Pancang"
        Me.Pancang.Width = 250
        '
        'Periode
        '
        DataGridViewCellStyle2.Format = "d"
        Me.Periode.DefaultCellStyle = DataGridViewCellStyle2
        Me.Periode.HeaderText = "Periode"
        Me.Periode.Name = "Periode"
        Me.Periode.Width = 150
        '
        'UpahTambang
        '
        Me.UpahTambang.HeaderText = "Upah Tambang"
        Me.UpahTambang.Name = "UpahTambang"
        '
        'UpahTambangKapalCrane
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.UpahTambangKapalCrane.DefaultCellStyle = DataGridViewCellStyle3
        Me.UpahTambangKapalCrane.HeaderText = "Updah Tambang (Kapal Crane)"
        Me.UpahTambangKapalCrane.Name = "UpahTambangKapalCrane"
        Me.UpahTambangKapalCrane.ReadOnly = True
        Me.UpahTambangKapalCrane.Width = 150
        '
        'KodeBB
        '
        Me.KodeBB.HeaderText = "KodeBB"
        Me.KodeBB.Name = "KodeBB"
        Me.KodeBB.Visible = False
        '
        'JenisBahanBaku
        '
        Me.JenisBahanBaku.HeaderText = "Jenis Bahan Baku"
        Me.JenisBahanBaku.Name = "JenisBahanBaku"
        Me.JenisBahanBaku.Width = 120
        '
        'Keterangan
        '
        Me.Keterangan.HeaderText = "Keterangan"
        Me.Keterangan.Name = "Keterangan"
        Me.Keterangan.Width = 350
        '
        'CreatedBy
        '
        Me.CreatedBy.HeaderText = "Created By"
        Me.CreatedBy.Name = "CreatedBy"
        Me.CreatedBy.Width = 180
        '
        'CreatedDate
        '
        DataGridViewCellStyle4.Format = "d"
        Me.CreatedDate.DefaultCellStyle = DataGridViewCellStyle4
        Me.CreatedDate.HeaderText = "Created Date"
        Me.CreatedDate.Name = "CreatedDate"
        Me.CreatedDate.Width = 120
        '
        'UpdatedBy
        '
        Me.UpdatedBy.HeaderText = "Updated By"
        Me.UpdatedBy.Name = "UpdatedBy"
        '
        'UpdatedDate
        '
        DataGridViewCellStyle5.Format = "d"
        Me.UpdatedDate.DefaultCellStyle = DataGridViewCellStyle5
        Me.UpdatedDate.HeaderText = "Updated Date"
        Me.UpdatedDate.Name = "UpdatedDate"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Cambria", 20.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(280, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(460, 32)
        Me.Label9.TabIndex = 397
        Me.Label9.Text = "Master Upah Bongkar (Tambang P2)"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmMstUpahBongkarMuat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1039, 605)
        Me.Controls.Add(Me.XuiCustomGroupbox2)
        Me.Controls.Add(Me.grpFilterData)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmMstUpahBongkarMuat"
        Me.Text = "Master Upah Bongkar Muat (Tambang) "
        Me.grpFilterData.ResumeLayout(False)
        Me.grpFilterData.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        Me.Panel12.PerformLayout()
        Me.XuiCustomGroupbox1.ResumeLayout(False)
        Me.XuiCustomGroupbox1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.PanelPancang.ResumeLayout(False)
        Me.XuiCustomGroupbox2.ResumeLayout(False)
        Me.XuiCustomGroupbox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel15.ResumeLayout(False)
        CType(Me.dgvlist, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grpFilterData As XanderUI.XUICustomGroupbox
	Friend WithEvents Label5 As Label
	Friend WithEvents Label4 As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents txtKet As TextBox
	Friend WithEvents dtpPeriode As DateTimePicker
	Friend WithEvents PanelPancang As Panel
	Friend WithEvents PanelPancang2 As Panel
	Friend WithEvents PanelPancang1 As Panel
	Friend WithEvents cmbPancang As ComboBox
	Friend WithEvents txtUpah As TextBox
	Friend WithEvents txtIDUpah As TextBox
	Friend WithEvents Label2 As Label
	Friend WithEvents Label1 As Label
	Friend WithEvents XuiCustomGroupbox1 As XanderUI.XUICustomGroupbox
	Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
	Friend WithEvents btnFind As Button
	Friend WithEvents btnCancel As Button
	Friend WithEvents btnSave As Button
	Friend WithEvents btnEdit As Button
	Friend WithEvents btnAdd As Button
    Friend WithEvents rdLaut As RadioButton
    Friend WithEvents rdDarat As RadioButton
    Friend WithEvents XuiCustomGroupbox2 As XanderUI.XUICustomGroupbox
    Friend WithEvents Panel15 As Panel
    Friend WithEvents cmbPancang2 As ComboBox
    Friend WithEvents Panel12 As Panel
    Friend WithEvents txtCari As TextBox
    Friend WithEvents btnLoad As Button
    Friend WithEvents dgvlist As DataGridView
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents dtp2 As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents dtp1 As DateTimePicker
    Friend WithEvents cbobahanbaku As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TxtUpahKapalCrane As TextBox
    Friend WithEvents No As DataGridViewTextBoxColumn
    Friend WithEvents IDTambang As DataGridViewTextBoxColumn
    Friend WithEvents IDPancang2 As DataGridViewTextBoxColumn
    Friend WithEvents Pancang As DataGridViewTextBoxColumn
    Friend WithEvents Periode As DataGridViewTextBoxColumn
    Friend WithEvents UpahTambang As DataGridViewTextBoxColumn
    Friend WithEvents UpahTambangKapalCrane As DataGridViewTextBoxColumn
    Friend WithEvents KodeBB As DataGridViewTextBoxColumn
    Friend WithEvents JenisBahanBaku As DataGridViewTextBoxColumn
    Friend WithEvents Keterangan As DataGridViewTextBoxColumn
    Friend WithEvents CreatedBy As DataGridViewTextBoxColumn
    Friend WithEvents CreatedDate As DataGridViewTextBoxColumn
    Friend WithEvents UpdatedBy As DataGridViewTextBoxColumn
    Friend WithEvents UpdatedDate As DataGridViewTextBoxColumn
    Friend WithEvents Label9 As Label
End Class
