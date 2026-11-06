Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMstSupplier
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMstSupplier))
        Me.PanelForm = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.chkPPHUMKM = New System.Windows.Forms.CheckBox()
        Me.TxtNoKTP = New System.Windows.Forms.MaskedTextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnFileChoose = New System.Windows.Forms.Button()
        Me.ocxAttachment = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.chkKomisiToke = New System.Windows.Forms.CheckBox()
        Me.TxtNoHp = New System.Windows.Forms.MaskedTextBox()
        Me.TxtNoNpwp = New System.Windows.Forms.MaskedTextBox()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.rdCash = New System.Windows.Forms.RadioButton()
        Me.rdPribadi = New System.Windows.Forms.RadioButton()
        Me.rdPTCV = New System.Windows.Forms.RadioButton()
        Me.txtketerangan = New System.Windows.Forms.TextBox()
        Me.chkRelasiPcgSub = New System.Windows.Forms.CheckBox()
        Me.ChkToke = New System.Windows.Forms.CheckBox()
        Me.ChkNpwp = New System.Windows.Forms.CheckBox()
        Me.cmbKategori = New System.Windows.Forms.ComboBox()
        Me.CboBahanBaku = New System.Windows.Forms.ComboBox()
        Me.TxtNamaSup = New System.Windows.Forms.TextBox()
        Me.txtkodesup = New System.Windows.Forms.TextBox()
        Me.TxtNamaNpwp = New System.Windows.Forms.TextBox()
        Me.TxtRmSupId = New System.Windows.Forms.TextBox()
        Me.cmbJenisSupplier = New System.Windows.Forms.ComboBox()
        Me.CboKodeDivKav = New System.Windows.Forms.ComboBox()
        Me.TxtAlamatSup = New System.Windows.Forms.TextBox()
        Me.TxtWilayah = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.ChkTdkAktif = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.PanelForm.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ocxAttachment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel10.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelForm
        '
        Me.PanelForm.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PanelForm.Controls.Add(Me.Panel1)
        Me.PanelForm.Controls.Add(Me.Panel2)
        Me.PanelForm.Location = New System.Drawing.Point(9, 11)
        Me.PanelForm.Name = "PanelForm"
        Me.PanelForm.Size = New System.Drawing.Size(873, 551)
        Me.PanelForm.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnFind)
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.btnDelete)
        Me.Panel1.Controls.Add(Me.btnEdit)
        Me.Panel1.Controls.Add(Me.btnAdd)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 511)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(873, 40)
        Me.Panel1.TabIndex = 4
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
        Me.btnExit.Location = New System.Drawing.Point(792, 5)
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
        Me.btnCancel.Location = New System.Drawing.Point(716, 5)
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
        Me.btnSave.Location = New System.Drawing.Point(640, 5)
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
        Me.btnDelete.Location = New System.Drawing.Point(564, 5)
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
        Me.btnEdit.Location = New System.Drawing.Point(488, 5)
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
        Me.btnAdd.Location = New System.Drawing.Point(412, 5)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnAdd.Size = New System.Drawing.Size(75, 30)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(0, 40, 0, 0)
        Me.Panel2.Size = New System.Drawing.Size(873, 551)
        Me.Panel2.TabIndex = 5
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.Panel6)
        Me.Panel3.Controls.Add(Me.chkPPHUMKM)
        Me.Panel3.Controls.Add(Me.TxtNoKTP)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.GroupBox1)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.chkKomisiToke)
        Me.Panel3.Controls.Add(Me.TxtNoHp)
        Me.Panel3.Controls.Add(Me.TxtNoNpwp)
        Me.Panel3.Controls.Add(Me.Panel10)
        Me.Panel3.Controls.Add(Me.txtketerangan)
        Me.Panel3.Controls.Add(Me.chkRelasiPcgSub)
        Me.Panel3.Controls.Add(Me.ChkToke)
        Me.Panel3.Controls.Add(Me.ChkNpwp)
        Me.Panel3.Controls.Add(Me.cmbKategori)
        Me.Panel3.Controls.Add(Me.CboBahanBaku)
        Me.Panel3.Controls.Add(Me.TxtNamaSup)
        Me.Panel3.Controls.Add(Me.txtkodesup)
        Me.Panel3.Controls.Add(Me.TxtNamaNpwp)
        Me.Panel3.Controls.Add(Me.TxtRmSupId)
        Me.Panel3.Controls.Add(Me.cmbJenisSupplier)
        Me.Panel3.Controls.Add(Me.CboKodeDivKav)
        Me.Panel3.Controls.Add(Me.TxtAlamatSup)
        Me.Panel3.Controls.Add(Me.TxtWilayah)
        Me.Panel3.Controls.Add(Me.Label27)
        Me.Panel3.Controls.Add(Me.Label24)
        Me.Panel3.Controls.Add(Me.ChkTdkAktif)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 40)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(873, 511)
        Me.Panel3.TabIndex = 4
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Black
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(873, 1)
        Me.Panel6.TabIndex = 905703
        '
        'chkPPHUMKM
        '
        Me.chkPPHUMKM.AutoSize = True
        Me.chkPPHUMKM.Location = New System.Drawing.Point(688, 136)
        Me.chkPPHUMKM.Name = "chkPPHUMKM"
        Me.chkPPHUMKM.Size = New System.Drawing.Size(83, 17)
        Me.chkPPHUMKM.TabIndex = 905702
        Me.chkPPHUMKM.Text = "PPH UMKM"
        Me.chkPPHUMKM.UseVisualStyleBackColor = True
        '
        'TxtNoKTP
        '
        Me.TxtNoKTP.Location = New System.Drawing.Point(89, 60)
        Me.TxtNoKTP.Mask = "0000 0000 0000 0000"
        Me.TxtNoKTP.Name = "TxtNoKTP"
        Me.TxtNoKTP.Size = New System.Drawing.Size(220, 22)
        Me.TxtNoKTP.TabIndex = 905701
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(7, 12)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(79, 13)
        Me.Label14.TabIndex = 905700
        Me.Label14.Text = "Kode Supplier"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.btnFileChoose)
        Me.GroupBox1.Controls.Add(Me.ocxAttachment)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 268)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(5, 35, 5, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(853, 197)
        Me.GroupBox1.TabIndex = 905699
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Attachment"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(2, 34)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(646, 13)
        Me.Label7.TabIndex = 905703
        Me.Label7.Text = "Catatan: Harap isi kolom remark sesuai jenis dokumen yang diunggah, misalnya: PET" &
    "ANI, KTP, KK, NPWP, UMKM, atau NIB."
        '
        'btnFileChoose
        '
        Me.btnFileChoose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFileChoose.BackColor = System.Drawing.Color.White
        Me.btnFileChoose.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFileChoose.Image = CType(resources.GetObject("btnFileChoose.Image"), System.Drawing.Image)
        Me.btnFileChoose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFileChoose.Location = New System.Drawing.Point(773, 14)
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
        Me.ocxAttachment.Location = New System.Drawing.Point(5, 50)
        Me.ocxAttachment.Name = "ocxAttachment"
        Me.ocxAttachment.ShowButtons = C1.Win.C1FlexGrid.ShowButtonsEnum.Always
        Me.ocxAttachment.Size = New System.Drawing.Size(843, 142)
        Me.ocxAttachment.TabIndex = 905699
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(7, 245)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(78, 13)
        Me.Label13.TabIndex = 905697
        Me.Label13.Text = "Jenis Supplier"
        '
        'chkKomisiToke
        '
        Me.chkKomisiToke.AutoSize = True
        Me.chkKomisiToke.Location = New System.Drawing.Point(688, 110)
        Me.chkKomisiToke.Name = "chkKomisiToke"
        Me.chkKomisiToke.Size = New System.Drawing.Size(85, 17)
        Me.chkKomisiToke.TabIndex = 905696
        Me.chkKomisiToke.Text = "Komisi Toke"
        Me.chkKomisiToke.UseVisualStyleBackColor = True
        '
        'TxtNoHp
        '
        Me.TxtNoHp.Location = New System.Drawing.Point(89, 135)
        Me.TxtNoHp.Mask = "0000 0000 0000 0"
        Me.TxtNoHp.Name = "TxtNoHp"
        Me.TxtNoHp.Size = New System.Drawing.Size(220, 22)
        Me.TxtNoHp.TabIndex = 905694
        '
        'TxtNoNpwp
        '
        Me.TxtNoNpwp.Location = New System.Drawing.Point(89, 110)
        Me.TxtNoNpwp.Mask = "0000 0000 0000 0000"
        Me.TxtNoNpwp.Name = "TxtNoNpwp"
        Me.TxtNoNpwp.Size = New System.Drawing.Size(220, 22)
        Me.TxtNoNpwp.TabIndex = 905693
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.rdCash)
        Me.Panel10.Controls.Add(Me.rdPribadi)
        Me.Panel10.Controls.Add(Me.rdPTCV)
        Me.Panel10.Location = New System.Drawing.Point(89, 240)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(220, 22)
        Me.Panel10.TabIndex = 905691
        '
        'rdCash
        '
        Me.rdCash.AutoSize = True
        Me.rdCash.Location = New System.Drawing.Point(137, 1)
        Me.rdCash.Name = "rdCash"
        Me.rdCash.Size = New System.Drawing.Size(50, 17)
        Me.rdCash.TabIndex = 21
        Me.rdCash.TabStop = True
        Me.rdCash.Text = "Cash"
        Me.rdCash.UseVisualStyleBackColor = True
        '
        'rdPribadi
        '
        Me.rdPribadi.AutoSize = True
        Me.rdPribadi.Checked = True
        Me.rdPribadi.Location = New System.Drawing.Point(4, 1)
        Me.rdPribadi.Name = "rdPribadi"
        Me.rdPribadi.Size = New System.Drawing.Size(61, 17)
        Me.rdPribadi.TabIndex = 21
        Me.rdPribadi.TabStop = True
        Me.rdPribadi.Text = "Pribadi"
        Me.rdPribadi.UseVisualStyleBackColor = True
        '
        'rdPTCV
        '
        Me.rdPTCV.AutoSize = True
        Me.rdPTCV.Location = New System.Drawing.Point(71, 1)
        Me.rdPTCV.Name = "rdPTCV"
        Me.rdPTCV.Size = New System.Drawing.Size(60, 17)
        Me.rdPTCV.TabIndex = 21
        Me.rdPTCV.TabStop = True
        Me.rdPTCV.Text = "PT / CV"
        Me.rdPTCV.UseVisualStyleBackColor = True
        '
        'txtketerangan
        '
        Me.txtketerangan.Location = New System.Drawing.Point(432, 135)
        Me.txtketerangan.Multiline = True
        Me.txtketerangan.Name = "txtketerangan"
        Me.txtketerangan.Size = New System.Drawing.Size(220, 79)
        Me.txtketerangan.TabIndex = 905690
        '
        'chkRelasiPcgSub
        '
        Me.chkRelasiPcgSub.AutoSize = True
        Me.chkRelasiPcgSub.Location = New System.Drawing.Point(688, 86)
        Me.chkRelasiPcgSub.Name = "chkRelasiPcgSub"
        Me.chkRelasiPcgSub.Size = New System.Drawing.Size(93, 17)
        Me.chkRelasiPcgSub.TabIndex = 905689
        Me.chkRelasiPcgSub.Text = "Pancang Sub"
        Me.chkRelasiPcgSub.UseVisualStyleBackColor = True
        '
        'ChkToke
        '
        Me.ChkToke.AutoSize = True
        Me.ChkToke.Location = New System.Drawing.Point(688, 61)
        Me.ChkToke.Name = "ChkToke"
        Me.ChkToke.Size = New System.Drawing.Size(49, 17)
        Me.ChkToke.TabIndex = 905681
        Me.ChkToke.Text = "Toke"
        Me.ChkToke.UseVisualStyleBackColor = True
        '
        'ChkNpwp
        '
        Me.ChkNpwp.AutoSize = True
        Me.ChkNpwp.Location = New System.Drawing.Point(688, 38)
        Me.ChkNpwp.Name = "ChkNpwp"
        Me.ChkNpwp.Size = New System.Drawing.Size(82, 17)
        Me.ChkNpwp.TabIndex = 905682
        Me.ChkNpwp.Text = "Non NPWP"
        Me.ChkNpwp.UseVisualStyleBackColor = True
        '
        'cmbKategori
        '
        Me.cmbKategori.FormattingEnabled = True
        Me.cmbKategori.Location = New System.Drawing.Point(432, 111)
        Me.cmbKategori.Name = "cmbKategori"
        Me.cmbKategori.Size = New System.Drawing.Size(220, 21)
        Me.cmbKategori.TabIndex = 905686
        '
        'CboBahanBaku
        '
        Me.CboBahanBaku.FormattingEnabled = True
        Me.CboBahanBaku.Location = New System.Drawing.Point(432, 63)
        Me.CboBahanBaku.Name = "CboBahanBaku"
        Me.CboBahanBaku.Size = New System.Drawing.Size(220, 21)
        Me.CboBahanBaku.TabIndex = 905687
        '
        'TxtNamaSup
        '
        Me.TxtNamaSup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNamaSup.Location = New System.Drawing.Point(89, 35)
        Me.TxtNamaSup.Name = "TxtNamaSup"
        Me.TxtNamaSup.Size = New System.Drawing.Size(220, 22)
        Me.TxtNamaSup.TabIndex = 905683
        '
        'txtkodesup
        '
        Me.txtkodesup.Enabled = False
        Me.txtkodesup.Location = New System.Drawing.Point(201, 10)
        Me.txtkodesup.Name = "txtkodesup"
        Me.txtkodesup.Size = New System.Drawing.Size(108, 22)
        Me.txtkodesup.TabIndex = 905692
        '
        'TxtNamaNpwp
        '
        Me.TxtNamaNpwp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNamaNpwp.Location = New System.Drawing.Point(89, 85)
        Me.TxtNamaNpwp.Name = "TxtNamaNpwp"
        Me.TxtNamaNpwp.Size = New System.Drawing.Size(219, 22)
        Me.TxtNamaNpwp.TabIndex = 905684
        '
        'TxtRmSupId
        '
        Me.TxtRmSupId.Enabled = False
        Me.TxtRmSupId.Location = New System.Drawing.Point(89, 10)
        Me.TxtRmSupId.Name = "TxtRmSupId"
        Me.TxtRmSupId.Size = New System.Drawing.Size(108, 22)
        Me.TxtRmSupId.TabIndex = 905680
        '
        'cmbJenisSupplier
        '
        Me.cmbJenisSupplier.FormattingEnabled = True
        Me.cmbJenisSupplier.Items.AddRange(New Object() {"Petani", "Kaki"})
        Me.cmbJenisSupplier.Location = New System.Drawing.Point(432, 87)
        Me.cmbJenisSupplier.Name = "cmbJenisSupplier"
        Me.cmbJenisSupplier.Size = New System.Drawing.Size(220, 21)
        Me.cmbJenisSupplier.TabIndex = 905678
        '
        'CboKodeDivKav
        '
        Me.CboKodeDivKav.FormattingEnabled = True
        Me.CboKodeDivKav.Location = New System.Drawing.Point(432, 9)
        Me.CboKodeDivKav.Name = "CboKodeDivKav"
        Me.CboKodeDivKav.Size = New System.Drawing.Size(220, 21)
        Me.CboKodeDivKav.TabIndex = 905677
        '
        'TxtAlamatSup
        '
        Me.TxtAlamatSup.Location = New System.Drawing.Point(89, 160)
        Me.TxtAlamatSup.Multiline = True
        Me.TxtAlamatSup.Name = "TxtAlamatSup"
        Me.TxtAlamatSup.Size = New System.Drawing.Size(220, 78)
        Me.TxtAlamatSup.TabIndex = 905675
        '
        'TxtWilayah
        '
        Me.TxtWilayah.Location = New System.Drawing.Point(432, 33)
        Me.TxtWilayah.Multiline = True
        Me.TxtWilayah.Name = "TxtWilayah"
        Me.TxtWilayah.Size = New System.Drawing.Size(220, 26)
        Me.TxtWilayah.TabIndex = 905676
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(350, 91)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(78, 13)
        Me.Label27.TabIndex = 905672
        Me.Label27.Text = "Jenis Supplier"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(350, 138)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(66, 13)
        Me.Label24.TabIndex = 905673
        Me.Label24.Text = "Keterangan"
        '
        'ChkTdkAktif
        '
        Me.ChkTdkAktif.AutoSize = True
        Me.ChkTdkAktif.Location = New System.Drawing.Point(688, 12)
        Me.ChkTdkAktif.Name = "ChkTdkAktif"
        Me.ChkTdkAktif.Size = New System.Drawing.Size(78, 17)
        Me.ChkTdkAktif.TabIndex = 905669
        Me.ChkTdkAktif.Text = "Not Active"
        Me.ChkTdkAktif.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 163)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 905667
        Me.Label3.Text = "Alamat"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(350, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 905668
        Me.Label2.Text = "Wilayah/SP"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(350, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 905666
        Me.Label4.Text = "Div/Blok/Kav"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 13)
        Me.Label5.TabIndex = 905658
        Me.Label5.Text = "Nama Suplier"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(350, 67)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 905659
        Me.Label6.Text = "Bahan Baku"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 115)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 13)
        Me.Label8.TabIndex = 905661
        Me.Label8.Text = "No NPWP"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 90)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 905662
        Me.Label9.Text = "Nama NPWP"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(7, 65)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 13)
        Me.Label10.TabIndex = 905663
        Me.Label10.Text = "No KTP"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(7, 140)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 13)
        Me.Label11.TabIndex = 905664
        Me.Label11.Text = "No HP"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(350, 115)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 13)
        Me.Label12.TabIndex = 905665
        Me.Label12.Text = "Kategori"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(41, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(162, 28)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Master Supplier"
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
        'FrmMstSupplierV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(890, 572)
        Me.Controls.Add(Me.PanelForm)
        Me.Name = "FrmMstSupplierV2"
        Me.Text = "Master Supplier"
        Me.PanelForm.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ocxAttachment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelForm As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnFind As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents chkPPHUMKM As CheckBox
    Friend WithEvents TxtNoKTP As MaskedTextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btnFileChoose As Button
    Friend WithEvents ocxAttachment As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label13 As Label
    Friend WithEvents chkKomisiToke As CheckBox
    Friend WithEvents TxtNoHp As MaskedTextBox
    Friend WithEvents TxtNoNpwp As MaskedTextBox
    Friend WithEvents Panel10 As Panel
    Friend WithEvents rdCash As RadioButton
    Friend WithEvents rdPribadi As RadioButton
    Friend WithEvents rdPTCV As RadioButton
    Friend WithEvents txtketerangan As TextBox
    Friend WithEvents chkRelasiPcgSub As CheckBox
    Friend WithEvents ChkToke As CheckBox
    Friend WithEvents ChkNpwp As CheckBox
    Friend WithEvents cmbKategori As ComboBox
    Friend WithEvents CboBahanBaku As ComboBox
    Friend WithEvents TxtNamaSup As TextBox
    Friend WithEvents txtkodesup As TextBox
    Friend WithEvents TxtNamaNpwp As TextBox
    Friend WithEvents TxtRmSupId As TextBox
    Friend WithEvents cmbJenisSupplier As ComboBox
    Friend WithEvents CboKodeDivKav As ComboBox
    Friend WithEvents TxtAlamatSup As TextBox
    Friend WithEvents TxtWilayah As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents ChkTdkAktif As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel4 As Panel
End Class
