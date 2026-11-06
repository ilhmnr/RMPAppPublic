Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMstSupplierMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMstSupplierMain))
        Me.PanelForm = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.chkKomisiHanyaToke = New System.Windows.Forms.CheckBox()
        Me.chkKomisiToke = New System.Windows.Forms.CheckBox()
        Me.chkPetaniKakiView = New System.Windows.Forms.CheckBox()
        Me.chkPetaniKaki = New System.Windows.Forms.CheckBox()
        Me.chkCungkil = New System.Windows.Forms.CheckBox()
        Me.chkArang = New System.Windows.Forms.CheckBox()
        Me.chkLicin = New System.Windows.Forms.CheckBox()
        Me.chkJambul = New System.Windows.Forms.CheckBox()
        Me.chkPcgLaut = New System.Windows.Forms.CheckBox()
        Me.chkDarat = New System.Windows.Forms.CheckBox()
        Me.chkPcgKontainer = New System.Windows.Forms.CheckBox()
        Me.chkPcgSubMain = New System.Windows.Forms.CheckBox()
        Me.chkPcgSub = New System.Windows.Forms.CheckBox()
        Me.chkPancang = New System.Windows.Forms.CheckBox()
        Me.chkNotActive = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.txtSingkatanNota = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtSingkatan = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboMainFactory = New System.Windows.Forms.ComboBox()
        Me.txtAlamatSup = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtNamaNPWP = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtNoNPWP = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtKodeNota = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboKodeDivKav = New System.Windows.Forms.ComboBox()
        Me.txtWilayah = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboBahanBaku = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboGroupSup = New System.Windows.Forms.ComboBox()
        Me.txtNamaSup = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtKodeSup = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRMSupID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.PanelForm.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelForm
        '
        Me.PanelForm.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PanelForm.Controls.Add(Me.Panel2)
        Me.PanelForm.Controls.Add(Me.Panel3)
        Me.PanelForm.Location = New System.Drawing.Point(2, 6)
        Me.PanelForm.Name = "PanelForm"
        Me.PanelForm.Size = New System.Drawing.Size(805, 472)
        Me.PanelForm.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnFind)
        Me.Panel2.Controls.Add(Me.btnExit)
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Controls.Add(Me.btnSave)
        Me.Panel2.Controls.Add(Me.btnDelete)
        Me.Panel2.Controls.Add(Me.btnEdit)
        Me.Panel2.Controls.Add(Me.btnAdd)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(0, 432)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(805, 40)
        Me.Panel2.TabIndex = 6
        '
        'btnFind
        '
        Me.btnFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnFind.BackColor = System.Drawing.Color.White
        Me.btnFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnFind.Image = CType(resources.GetObject("btnFind.Image"), System.Drawing.Image)
        Me.btnFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFind.Location = New System.Drawing.Point(6, 5)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnFind.Size = New System.Drawing.Size(75, 30)
        Me.btnFind.TabIndex = 6
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
        Me.btnExit.Location = New System.Drawing.Point(724, 5)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnExit.Size = New System.Drawing.Size(75, 30)
        Me.btnExit.TabIndex = 5
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
        Me.btnCancel.Location = New System.Drawing.Point(648, 5)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Padding = New System.Windows.Forms.Padding(5, 0, 3, 0)
        Me.btnCancel.Size = New System.Drawing.Size(75, 30)
        Me.btnCancel.TabIndex = 4
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
        Me.btnSave.Location = New System.Drawing.Point(572, 5)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnSave.Size = New System.Drawing.Size(75, 30)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.BackColor = System.Drawing.Color.White
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(496, 5)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Padding = New System.Windows.Forms.Padding(5, 0, 3, 0)
        Me.btnDelete.Size = New System.Drawing.Size(75, 30)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BackColor = System.Drawing.Color.White
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEdit.Location = New System.Drawing.Point(420, 5)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnEdit.Size = New System.Drawing.Size(75, 30)
        Me.btnEdit.TabIndex = 1
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
        Me.btnAdd.Location = New System.Drawing.Point(344, 5)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnAdd.Size = New System.Drawing.Size(75, 30)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(0, 40, 0, 0)
        Me.Panel3.Size = New System.Drawing.Size(805, 472)
        Me.Panel3.TabIndex = 7
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.White
        Me.Panel5.Controls.Add(Me.chkKomisiHanyaToke)
        Me.Panel5.Controls.Add(Me.chkKomisiToke)
        Me.Panel5.Controls.Add(Me.chkPetaniKakiView)
        Me.Panel5.Controls.Add(Me.chkPetaniKaki)
        Me.Panel5.Controls.Add(Me.chkCungkil)
        Me.Panel5.Controls.Add(Me.chkArang)
        Me.Panel5.Controls.Add(Me.chkLicin)
        Me.Panel5.Controls.Add(Me.chkJambul)
        Me.Panel5.Controls.Add(Me.chkPcgLaut)
        Me.Panel5.Controls.Add(Me.chkDarat)
        Me.Panel5.Controls.Add(Me.chkPcgKontainer)
        Me.Panel5.Controls.Add(Me.chkPcgSubMain)
        Me.Panel5.Controls.Add(Me.chkPcgSub)
        Me.Panel5.Controls.Add(Me.chkPancang)
        Me.Panel5.Controls.Add(Me.chkNotActive)
        Me.Panel5.Controls.Add(Me.CheckBox2)
        Me.Panel5.Controls.Add(Me.CheckBox1)
        Me.Panel5.Controls.Add(Me.txtSingkatanNota)
        Me.Panel5.Controls.Add(Me.Label13)
        Me.Panel5.Controls.Add(Me.txtSingkatan)
        Me.Panel5.Controls.Add(Me.Label14)
        Me.Panel5.Controls.Add(Me.Label15)
        Me.Panel5.Controls.Add(Me.cboMainFactory)
        Me.Panel5.Controls.Add(Me.txtAlamatSup)
        Me.Panel5.Controls.Add(Me.Label12)
        Me.Panel5.Controls.Add(Me.txtNamaNPWP)
        Me.Panel5.Controls.Add(Me.Label11)
        Me.Panel5.Controls.Add(Me.txtNoNPWP)
        Me.Panel5.Controls.Add(Me.Label10)
        Me.Panel5.Controls.Add(Me.txtKodeNota)
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.cboKodeDivKav)
        Me.Panel5.Controls.Add(Me.txtWilayah)
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Controls.Add(Me.cboBahanBaku)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.cboGroupSup)
        Me.Panel5.Controls.Add(Me.txtNamaSup)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.txtKodeSup)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.txtRMSupID)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 40)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(805, 432)
        Me.Panel5.TabIndex = 5
        '
        'chkKomisiHanyaToke
        '
        Me.chkKomisiHanyaToke.AutoSize = True
        Me.chkKomisiHanyaToke.Location = New System.Drawing.Point(465, 164)
        Me.chkKomisiHanyaToke.Name = "chkKomisiHanyaToke"
        Me.chkKomisiHanyaToke.Size = New System.Drawing.Size(127, 17)
        Me.chkKomisiHanyaToke.TabIndex = 905732
        Me.chkKomisiHanyaToke.Text = "Komisi Hanya Tokeh"
        Me.chkKomisiHanyaToke.UseVisualStyleBackColor = True
        '
        'chkKomisiToke
        '
        Me.chkKomisiToke.AutoSize = True
        Me.chkKomisiToke.Location = New System.Drawing.Point(367, 164)
        Me.chkKomisiToke.Name = "chkKomisiToke"
        Me.chkKomisiToke.Size = New System.Drawing.Size(92, 17)
        Me.chkKomisiToke.TabIndex = 905732
        Me.chkKomisiToke.Text = "Komisi Tokeh"
        Me.chkKomisiToke.UseVisualStyleBackColor = True
        '
        'chkPetaniKakiView
        '
        Me.chkPetaniKakiView.AutoSize = True
        Me.chkPetaniKakiView.Location = New System.Drawing.Point(489, 140)
        Me.chkPetaniKakiView.Name = "chkPetaniKakiView"
        Me.chkPetaniKakiView.Size = New System.Drawing.Size(170, 17)
        Me.chkPetaniKakiView.TabIndex = 905732
        Me.chkPetaniKakiView.Text = "Tampilkan Harga Petani Kaki"
        Me.chkPetaniKakiView.UseVisualStyleBackColor = True
        '
        'chkPetaniKaki
        '
        Me.chkPetaniKaki.AutoSize = True
        Me.chkPetaniKaki.Location = New System.Drawing.Point(367, 140)
        Me.chkPetaniKaki.Name = "chkPetaniKaki"
        Me.chkPetaniKaki.Size = New System.Drawing.Size(116, 17)
        Me.chkPetaniKaki.TabIndex = 905732
        Me.chkPetaniKaki.Text = "Harga Petani Kaki"
        Me.chkPetaniKaki.UseVisualStyleBackColor = True
        '
        'chkCungkil
        '
        Me.chkCungkil.AutoSize = True
        Me.chkCungkil.Location = New System.Drawing.Point(553, 115)
        Me.chkCungkil.Name = "chkCungkil"
        Me.chkCungkil.Size = New System.Drawing.Size(66, 17)
        Me.chkCungkil.TabIndex = 905732
        Me.chkCungkil.Text = "Cungkil"
        Me.chkCungkil.UseVisualStyleBackColor = True
        '
        'chkArang
        '
        Me.chkArang.AutoSize = True
        Me.chkArang.Location = New System.Drawing.Point(490, 115)
        Me.chkArang.Name = "chkArang"
        Me.chkArang.Size = New System.Drawing.Size(57, 17)
        Me.chkArang.TabIndex = 905732
        Me.chkArang.Text = "Arang"
        Me.chkArang.UseVisualStyleBackColor = True
        '
        'chkLicin
        '
        Me.chkLicin.AutoSize = True
        Me.chkLicin.Location = New System.Drawing.Point(435, 115)
        Me.chkLicin.Name = "chkLicin"
        Me.chkLicin.Size = New System.Drawing.Size(49, 17)
        Me.chkLicin.TabIndex = 905732
        Me.chkLicin.Text = "Licin"
        Me.chkLicin.UseVisualStyleBackColor = True
        '
        'chkJambul
        '
        Me.chkJambul.AutoSize = True
        Me.chkJambul.Location = New System.Drawing.Point(367, 115)
        Me.chkJambul.Name = "chkJambul"
        Me.chkJambul.Size = New System.Drawing.Size(62, 17)
        Me.chkJambul.TabIndex = 905732
        Me.chkJambul.Text = "Jambul"
        Me.chkJambul.UseVisualStyleBackColor = True
        '
        'chkPcgLaut
        '
        Me.chkPcgLaut.AutoSize = True
        Me.chkPcgLaut.Location = New System.Drawing.Point(474, 92)
        Me.chkPcgLaut.Name = "chkPcgLaut"
        Me.chkPcgLaut.Size = New System.Drawing.Size(95, 17)
        Me.chkPcgLaut.TabIndex = 905732
        Me.chkPcgLaut.Text = "Pancang Laut"
        Me.chkPcgLaut.UseVisualStyleBackColor = True
        '
        'chkDarat
        '
        Me.chkDarat.AutoSize = True
        Me.chkDarat.Location = New System.Drawing.Point(367, 92)
        Me.chkDarat.Name = "chkDarat"
        Me.chkDarat.Size = New System.Drawing.Size(101, 17)
        Me.chkDarat.TabIndex = 905732
        Me.chkDarat.Text = "Pancang Darat"
        Me.chkDarat.UseVisualStyleBackColor = True
        '
        'chkPcgKontainer
        '
        Me.chkPcgKontainer.AutoSize = True
        Me.chkPcgKontainer.Location = New System.Drawing.Point(670, 68)
        Me.chkPcgKontainer.Name = "chkPcgKontainer"
        Me.chkPcgKontainer.Size = New System.Drawing.Size(123, 17)
        Me.chkPcgKontainer.TabIndex = 905732
        Me.chkPcgKontainer.Text = "Pancang Kontainer"
        Me.chkPcgKontainer.UseVisualStyleBackColor = True
        '
        'chkPcgSubMain
        '
        Me.chkPcgSubMain.AutoSize = True
        Me.chkPcgSubMain.Location = New System.Drawing.Point(542, 68)
        Me.chkPcgSubMain.Name = "chkPcgSubMain"
        Me.chkPcgSubMain.Size = New System.Drawing.Size(122, 17)
        Me.chkPcgSubMain.TabIndex = 905732
        Me.chkPcgSubMain.Text = "Pancang Sub Main"
        Me.chkPcgSubMain.UseVisualStyleBackColor = True
        '
        'chkPcgSub
        '
        Me.chkPcgSub.AutoSize = True
        Me.chkPcgSub.Location = New System.Drawing.Point(443, 68)
        Me.chkPcgSub.Name = "chkPcgSub"
        Me.chkPcgSub.Size = New System.Drawing.Size(93, 17)
        Me.chkPcgSub.TabIndex = 905732
        Me.chkPcgSub.Text = "Pancang Sub"
        Me.chkPcgSub.UseVisualStyleBackColor = True
        '
        'chkPancang
        '
        Me.chkPancang.AutoSize = True
        Me.chkPancang.Location = New System.Drawing.Point(367, 68)
        Me.chkPancang.Name = "chkPancang"
        Me.chkPancang.Size = New System.Drawing.Size(70, 17)
        Me.chkPancang.TabIndex = 905732
        Me.chkPancang.Text = "Pancang"
        Me.chkPancang.UseVisualStyleBackColor = True
        '
        'chkNotActive
        '
        Me.chkNotActive.AutoSize = True
        Me.chkNotActive.Location = New System.Drawing.Point(367, 18)
        Me.chkNotActive.Name = "chkNotActive"
        Me.chkNotActive.Size = New System.Drawing.Size(80, 17)
        Me.chkNotActive.TabIndex = 905732
        Me.chkNotActive.Text = "Tidak Aktif"
        Me.chkNotActive.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(427, 43)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(48, 17)
        Me.CheckBox2.TabIndex = 905732
        Me.CheckBox2.Text = "Laut"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(367, 43)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(54, 17)
        Me.CheckBox1.TabIndex = 905732
        Me.CheckBox1.Text = "Kanal"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'txtSingkatanNota
        '
        Me.txtSingkatanNota.Location = New System.Drawing.Point(126, 359)
        Me.txtSingkatanNota.Name = "txtSingkatanNota"
        Me.txtSingkatanNota.Size = New System.Drawing.Size(200, 22)
        Me.txtSingkatanNota.TabIndex = 905731
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(17, 364)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(87, 13)
        Me.Label13.TabIndex = 905730
        Me.Label13.Text = "Singkatan Nota"
        '
        'txtSingkatan
        '
        Me.txtSingkatan.Location = New System.Drawing.Point(126, 334)
        Me.txtSingkatan.Name = "txtSingkatan"
        Me.txtSingkatan.Size = New System.Drawing.Size(200, 22)
        Me.txtSingkatan.TabIndex = 905729
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(17, 339)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(59, 13)
        Me.Label14.TabIndex = 905728
        Me.Label14.Text = "Singkatan"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(17, 314)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(73, 13)
        Me.Label15.TabIndex = 905727
        Me.Label15.Text = "Main Factory"
        '
        'cboMainFactory
        '
        Me.cboMainFactory.FormattingEnabled = True
        Me.cboMainFactory.Location = New System.Drawing.Point(126, 310)
        Me.cboMainFactory.Name = "cboMainFactory"
        Me.cboMainFactory.Size = New System.Drawing.Size(200, 21)
        Me.cboMainFactory.TabIndex = 905726
        '
        'txtAlamatSup
        '
        Me.txtAlamatSup.Location = New System.Drawing.Point(126, 261)
        Me.txtAlamatSup.Multiline = True
        Me.txtAlamatSup.Name = "txtAlamatSup"
        Me.txtAlamatSup.Size = New System.Drawing.Size(200, 46)
        Me.txtAlamatSup.TabIndex = 905725
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(17, 266)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 13)
        Me.Label12.TabIndex = 905724
        Me.Label12.Text = "Alamat"
        '
        'txtNamaNPWP
        '
        Me.txtNamaNPWP.Location = New System.Drawing.Point(126, 236)
        Me.txtNamaNPWP.Name = "txtNamaNPWP"
        Me.txtNamaNPWP.Size = New System.Drawing.Size(200, 22)
        Me.txtNamaNPWP.TabIndex = 905723
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(17, 241)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 13)
        Me.Label11.TabIndex = 905722
        Me.Label11.Text = "Nama NPWP"
        '
        'txtNoNPWP
        '
        Me.txtNoNPWP.Location = New System.Drawing.Point(126, 211)
        Me.txtNoNPWP.Name = "txtNoNPWP"
        Me.txtNoNPWP.Size = New System.Drawing.Size(200, 22)
        Me.txtNoNPWP.TabIndex = 905721
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(17, 216)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 13)
        Me.Label10.TabIndex = 905720
        Me.Label10.Text = "No. NPWP"
        '
        'txtKodeNota
        '
        Me.txtKodeNota.Location = New System.Drawing.Point(126, 186)
        Me.txtKodeNota.Name = "txtKodeNota"
        Me.txtKodeNota.Size = New System.Drawing.Size(200, 22)
        Me.txtKodeNota.TabIndex = 905719
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(17, 191)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 13)
        Me.Label9.TabIndex = 905718
        Me.Label9.Text = "Kode Nota"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 166)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 13)
        Me.Label8.TabIndex = 905717
        Me.Label8.Text = "Divisi/Blok/Kav"
        '
        'cboKodeDivKav
        '
        Me.cboKodeDivKav.FormattingEnabled = True
        Me.cboKodeDivKav.Location = New System.Drawing.Point(126, 162)
        Me.cboKodeDivKav.Name = "cboKodeDivKav"
        Me.cboKodeDivKav.Size = New System.Drawing.Size(200, 21)
        Me.cboKodeDivKav.TabIndex = 905716
        '
        'txtWilayah
        '
        Me.txtWilayah.Location = New System.Drawing.Point(126, 137)
        Me.txtWilayah.Name = "txtWilayah"
        Me.txtWilayah.Size = New System.Drawing.Size(200, 22)
        Me.txtWilayah.TabIndex = 905715
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 142)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 13)
        Me.Label7.TabIndex = 905714
        Me.Label7.Text = "Wilayah"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 117)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 13)
        Me.Label6.TabIndex = 905713
        Me.Label6.Text = "Jenis Bahan Baku"
        '
        'cboBahanBaku
        '
        Me.cboBahanBaku.FormattingEnabled = True
        Me.cboBahanBaku.Location = New System.Drawing.Point(126, 113)
        Me.cboBahanBaku.Name = "cboBahanBaku"
        Me.cboBahanBaku.Size = New System.Drawing.Size(200, 21)
        Me.cboBahanBaku.TabIndex = 905712
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 13)
        Me.Label5.TabIndex = 905711
        Me.Label5.Text = "Group Supplier"
        '
        'cboGroupSup
        '
        Me.cboGroupSup.FormattingEnabled = True
        Me.cboGroupSup.Location = New System.Drawing.Point(126, 90)
        Me.cboGroupSup.Name = "cboGroupSup"
        Me.cboGroupSup.Size = New System.Drawing.Size(200, 21)
        Me.cboGroupSup.TabIndex = 905710
        '
        'txtNamaSup
        '
        Me.txtNamaSup.Location = New System.Drawing.Point(126, 65)
        Me.txtNamaSup.Name = "txtNamaSup"
        Me.txtNamaSup.Size = New System.Drawing.Size(200, 22)
        Me.txtNamaSup.TabIndex = 905709
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 905708
        Me.Label4.Text = "Nama Supplier"
        '
        'txtKodeSup
        '
        Me.txtKodeSup.Location = New System.Drawing.Point(126, 40)
        Me.txtKodeSup.Name = "txtKodeSup"
        Me.txtKodeSup.Size = New System.Drawing.Size(200, 22)
        Me.txtKodeSup.TabIndex = 905707
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 905706
        Me.Label3.Text = "Kode Supplier"
        '
        'txtRMSupID
        '
        Me.txtRMSupID.Location = New System.Drawing.Point(126, 15)
        Me.txtRMSupID.Name = "txtRMSupID"
        Me.txtRMSupID.Size = New System.Drawing.Size(200, 22)
        Me.txtRMSupID.TabIndex = 905705
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 905704
        Me.Label2.Text = "ID Supplier"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Black
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(805, 1)
        Me.Panel6.TabIndex = 905703
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(41, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(216, 28)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Master Supplier Main"
        '
        'Panel4
        '
        Me.Panel4.BackgroundImage = CType(resources.GetObject("Panel4.BackgroundImage"), System.Drawing.Image)
        Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel4.Location = New System.Drawing.Point(5, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(35, 35)
        Me.Panel4.TabIndex = 1
        '
        'FrmMstSupplierMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(811, 482)
        Me.Controls.Add(Me.PanelForm)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FrmMstSupplierMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Master Supplier Main"
        Me.PanelForm.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelForm As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnFind As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents chkKomisiHanyaToke As CheckBox
    Friend WithEvents chkKomisiToke As CheckBox
    Friend WithEvents chkPetaniKakiView As CheckBox
    Friend WithEvents chkPetaniKaki As CheckBox
    Friend WithEvents chkCungkil As CheckBox
    Friend WithEvents chkArang As CheckBox
    Friend WithEvents chkLicin As CheckBox
    Friend WithEvents chkJambul As CheckBox
    Friend WithEvents chkPcgLaut As CheckBox
    Friend WithEvents chkDarat As CheckBox
    Friend WithEvents chkPcgKontainer As CheckBox
    Friend WithEvents chkPcgSubMain As CheckBox
    Friend WithEvents chkPcgSub As CheckBox
    Friend WithEvents chkPancang As CheckBox
    Friend WithEvents chkNotActive As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents txtSingkatanNota As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtSingkatan As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents cboMainFactory As ComboBox
    Friend WithEvents txtAlamatSup As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtNamaNPWP As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtNoNPWP As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtKodeNota As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cboKodeDivKav As ComboBox
    Friend WithEvents txtWilayah As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cboBahanBaku As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cboGroupSup As ComboBox
    Friend WithEvents txtNamaSup As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtKodeSup As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtRMSupID As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel4 As Panel
End Class
