Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMstKapalPelangsir
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMstKapalPelangsir))
        Me.PanelForm = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.txtnohpkapten = New System.Windows.Forms.MaskedTextBox()
        Me.txtnohppemilik = New System.Windows.Forms.MaskedTextBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnFileChooseImage = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pictItem = New System.Windows.Forms.PictureBox()
        Me.txtFileAttachment = New System.Windows.Forms.TextBox()
        Me.cmbPancang = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtidpompong2 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkNotActive = New System.Windows.Forms.CheckBox()
        Me.txtidkapal = New System.Windows.Forms.TextBox()
        Me.txtalamat = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtnamakapten = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtnamapemilik = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtkapasitas = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtnamapompong = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.PanelForm.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pictItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelForm
        '
        Me.PanelForm.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PanelForm.Controls.Add(Me.Panel4)
        Me.PanelForm.Controls.Add(Me.Panel3)
        Me.PanelForm.Controls.Add(Me.Panel2)
        Me.PanelForm.Location = New System.Drawing.Point(11, 12)
        Me.PanelForm.Name = "PanelForm"
        Me.PanelForm.Size = New System.Drawing.Size(769, 389)
        Me.PanelForm.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.txtnohpkapten)
        Me.Panel4.Controls.Add(Me.txtnohppemilik)
        Me.Panel4.Controls.Add(Me.Panel6)
        Me.Panel4.Controls.Add(Me.btnFileChooseImage)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.GroupBox1)
        Me.Panel4.Controls.Add(Me.txtFileAttachment)
        Me.Panel4.Controls.Add(Me.cmbPancang)
        Me.Panel4.Controls.Add(Me.Label14)
        Me.Panel4.Controls.Add(Me.txtidpompong2)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.TextBox6)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.chkNotActive)
        Me.Panel4.Controls.Add(Me.txtidkapal)
        Me.Panel4.Controls.Add(Me.txtalamat)
        Me.Panel4.Controls.Add(Me.Label27)
        Me.Panel4.Controls.Add(Me.Label26)
        Me.Panel4.Controls.Add(Me.txtnamakapten)
        Me.Panel4.Controls.Add(Me.Label24)
        Me.Panel4.Controls.Add(Me.txtnamapemilik)
        Me.Panel4.Controls.Add(Me.Label22)
        Me.Panel4.Controls.Add(Me.txtkapasitas)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.txtnamapompong)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.Label13)
        Me.Panel4.Controls.Add(Me.TextBox3)
        Me.Panel4.Controls.Add(Me.Label19)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 40)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(769, 309)
        Me.Panel4.TabIndex = 952
        '
        'txtnohpkapten
        '
        Me.txtnohpkapten.Location = New System.Drawing.Point(138, 148)
        Me.txtnohpkapten.Mask = "0000 0000 0000 0"
        Me.txtnohpkapten.Name = "txtnohpkapten"
        Me.txtnohpkapten.Size = New System.Drawing.Size(293, 20)
        Me.txtnohpkapten.TabIndex = 907
        '
        'txtnohppemilik
        '
        Me.txtnohppemilik.Location = New System.Drawing.Point(138, 102)
        Me.txtnohppemilik.Mask = "0000 0000 0000 0"
        Me.txtnohppemilik.Name = "txtnohppemilik"
        Me.txtnohppemilik.Size = New System.Drawing.Size(293, 20)
        Me.txtnohppemilik.TabIndex = 905
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Black
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(769, 1)
        Me.Panel6.TabIndex = 905705
        '
        'btnFileChooseImage
        '
        Me.btnFileChooseImage.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnFileChooseImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnFileChooseImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnFileChooseImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFileChooseImage.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnFileChooseImage.Location = New System.Drawing.Point(678, 190)
        Me.btnFileChooseImage.Name = "btnFileChooseImage"
        Me.btnFileChooseImage.Size = New System.Drawing.Size(72, 25)
        Me.btnFileChooseImage.TabIndex = 1061
        Me.btnFileChooseImage.Text = "Pilih"
        Me.btnFileChooseImage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFileChooseImage.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(452, 195)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 14)
        Me.Label3.TabIndex = 1063
        Me.Label3.Text = "Pilih Gambar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.pictItem)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(452, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(298, 189)
        Me.GroupBox1.TabIndex = 1062
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Foto Kapal Pelangsir"
        '
        'pictItem
        '
        Me.pictItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pictItem.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.pictItem.Location = New System.Drawing.Point(3, 18)
        Me.pictItem.Name = "pictItem"
        Me.pictItem.Size = New System.Drawing.Size(292, 168)
        Me.pictItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictItem.TabIndex = 227
        Me.pictItem.TabStop = False
        '
        'txtFileAttachment
        '
        Me.txtFileAttachment.AccessibleDescription = "ReadOnly"
        Me.txtFileAttachment.AccessibleName = ""
        Me.txtFileAttachment.BackColor = System.Drawing.Color.White
        Me.txtFileAttachment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFileAttachment.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtFileAttachment.ForeColor = System.Drawing.Color.Black
        Me.txtFileAttachment.Location = New System.Drawing.Point(452, 191)
        Me.txtFileAttachment.Name = "txtFileAttachment"
        Me.txtFileAttachment.Size = New System.Drawing.Size(298, 22)
        Me.txtFileAttachment.TabIndex = 1064
        Me.txtFileAttachment.Visible = False
        '
        'cmbPancang
        '
        Me.cmbPancang.FormattingEnabled = True
        Me.cmbPancang.Location = New System.Drawing.Point(138, 171)
        Me.cmbPancang.Name = "cmbPancang"
        Me.cmbPancang.Size = New System.Drawing.Size(292, 21)
        Me.cmbPancang.TabIndex = 908
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(16, 173)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(67, 17)
        Me.Label14.TabIndex = 1057
        Me.Label14.Text = "Pancang"
        '
        'txtidpompong2
        '
        Me.txtidpompong2.Location = New System.Drawing.Point(138, 10)
        Me.txtidpompong2.Name = "txtidpompong2"
        Me.txtidpompong2.ReadOnly = True
        Me.txtidpompong2.Size = New System.Drawing.Size(291, 20)
        Me.txtidpompong2.TabIndex = 1053
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(16, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 17)
        Me.Label7.TabIndex = 1052
        Me.Label7.Text = "IDPompong"
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(138, 10)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(291, 20)
        Me.TextBox6.TabIndex = 1054
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(16, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 17)
        Me.Label2.TabIndex = 1049
        Me.Label2.Text = "No Hp Pemilik"
        '
        'chkNotActive
        '
        Me.chkNotActive.AutoSize = True
        Me.chkNotActive.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.chkNotActive.Location = New System.Drawing.Point(140, 280)
        Me.chkNotActive.Name = "chkNotActive"
        Me.chkNotActive.Size = New System.Drawing.Size(96, 21)
        Me.chkNotActive.TabIndex = 1048
        Me.chkNotActive.Text = "Not Active"
        Me.chkNotActive.UseVisualStyleBackColor = True
        '
        'txtidkapal
        '
        Me.txtidkapal.BackColor = System.Drawing.Color.White
        Me.txtidkapal.Location = New System.Drawing.Point(401, 11)
        Me.txtidkapal.Name = "txtidkapal"
        Me.txtidkapal.Size = New System.Drawing.Size(30, 20)
        Me.txtidkapal.TabIndex = 1047
        Me.txtidkapal.Visible = False
        '
        'txtalamat
        '
        Me.txtalamat.Location = New System.Drawing.Point(138, 195)
        Me.txtalamat.Multiline = True
        Me.txtalamat.Name = "txtalamat"
        Me.txtalamat.Size = New System.Drawing.Size(294, 73)
        Me.txtalamat.TabIndex = 909
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(16, 197)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(60, 17)
        Me.Label27.TabIndex = 1044
        Me.Label27.Text = "Alamat "
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(16, 150)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(104, 17)
        Me.Label26.TabIndex = 1041
        Me.Label26.Text = "No. Hp Kapten"
        '
        'txtnamakapten
        '
        Me.txtnamakapten.Location = New System.Drawing.Point(138, 125)
        Me.txtnamakapten.Name = "txtnamakapten"
        Me.txtnamakapten.Size = New System.Drawing.Size(294, 20)
        Me.txtnamakapten.TabIndex = 906
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(16, 127)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(100, 17)
        Me.Label24.TabIndex = 1038
        Me.Label24.Text = "Nama Kapten"
        '
        'txtnamapemilik
        '
        Me.txtnamapemilik.Location = New System.Drawing.Point(138, 79)
        Me.txtnamapemilik.Name = "txtnamapemilik"
        Me.txtnamapemilik.Size = New System.Drawing.Size(294, 20)
        Me.txtnamapemilik.TabIndex = 903
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(16, 81)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(98, 17)
        Me.Label22.TabIndex = 1035
        Me.Label22.Text = "Nama Pemilik"
        '
        'txtkapasitas
        '
        Me.txtkapasitas.Location = New System.Drawing.Point(138, 56)
        Me.txtkapasitas.Name = "txtkapasitas"
        Me.txtkapasitas.Size = New System.Drawing.Size(293, 20)
        Me.txtkapasitas.TabIndex = 902
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(16, 58)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(102, 17)
        Me.Label11.TabIndex = 1031
        Me.Label11.Text = "Kapasitas (KG)"
        '
        'txtnamapompong
        '
        Me.txtnamapompong.Location = New System.Drawing.Point(138, 33)
        Me.txtnamapompong.Name = "txtnamapompong"
        Me.txtnamapompong.Size = New System.Drawing.Size(294, 20)
        Me.txtnamapompong.TabIndex = 901
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(16, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(118, 17)
        Me.Label4.TabIndex = 1024
        Me.Label4.Text = "Nama Pompong"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(16, 58)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 17)
        Me.Label13.TabIndex = 1030
        Me.Label13.Text = "Kapasitas"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(138, 33)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(291, 20)
        Me.TextBox3.TabIndex = 1027
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(16, 35)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(118, 17)
        Me.Label19.TabIndex = 1025
        Me.Label19.Text = "Nama Pompong"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel3.Controls.Add(Me.btnFind)
        Me.Panel3.Controls.Add(Me.btnExit)
        Me.Panel3.Controls.Add(Me.btnCancel)
        Me.Panel3.Controls.Add(Me.btnSave)
        Me.Panel3.Controls.Add(Me.btnEdit)
        Me.Panel3.Controls.Add(Me.btnAdd)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 349)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(769, 40)
        Me.Panel3.TabIndex = 952
        '
        'btnFind
        '
        Me.btnFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnFind.BackColor = System.Drawing.Color.White
        Me.btnFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnFind.Image = CType(resources.GetObject("btnFind.Image"), System.Drawing.Image)
        Me.btnFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFind.Location = New System.Drawing.Point(11, 5)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnFind.Size = New System.Drawing.Size(75, 30)
        Me.btnFind.TabIndex = 920
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
        Me.btnExit.Location = New System.Drawing.Point(683, 5)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnExit.Size = New System.Drawing.Size(75, 30)
        Me.btnExit.TabIndex = 919
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
        Me.btnCancel.Location = New System.Drawing.Point(607, 5)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Padding = New System.Windows.Forms.Padding(5, 0, 3, 0)
        Me.btnCancel.Size = New System.Drawing.Size(75, 30)
        Me.btnCancel.TabIndex = 918
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
        Me.btnSave.Location = New System.Drawing.Point(531, 5)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnSave.Size = New System.Drawing.Size(75, 30)
        Me.btnSave.TabIndex = 917
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
        Me.btnEdit.Location = New System.Drawing.Point(455, 5)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnEdit.Size = New System.Drawing.Size(75, 30)
        Me.btnEdit.TabIndex = 916
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
        Me.btnAdd.Location = New System.Drawing.Point(379, 5)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnAdd.Size = New System.Drawing.Size(75, 30)
        Me.btnAdd.TabIndex = 915
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(769, 40)
        Me.Panel2.TabIndex = 952
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(46, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(229, 28)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Master Kapal Pelangsir"
        '
        'Panel5
        '
        Me.Panel5.BackgroundImage = CType(resources.GetObject("Panel5.BackgroundImage"), System.Drawing.Image)
        Me.Panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel5.Location = New System.Drawing.Point(10, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(35, 35)
        Me.Panel5.TabIndex = 3
        '
        'FrmMstKapalPelangsir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 413)
        Me.Controls.Add(Me.PanelForm)
        Me.Name = "FrmMstKapalPelangsir"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Master Kapal Pelangsir"
        Me.PanelForm.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.pictItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelForm As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label14 As Label
    Friend WithEvents txtidpompong2 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents chkNotActive As CheckBox
    Friend WithEvents txtidkapal As TextBox
    Friend WithEvents txtalamat As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents txtnamakapten As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents txtnamapemilik As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txtkapasitas As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtnamapompong As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents cmbPancang As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents btnExit As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnFind As Button
    Friend WithEvents btnFileChooseImage As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents pictItem As PictureBox
    Friend WithEvents txtFileAttachment As TextBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents txtnohpkapten As MaskedTextBox
    Friend WithEvents txtnohppemilik As MaskedTextBox
End Class
