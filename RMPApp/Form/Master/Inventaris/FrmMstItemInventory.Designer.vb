Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMstItemInventory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMstItemInventory))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.BtnUpdate = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.CmbUpdateSatuan = New System.Windows.Forms.ComboBox()
        Me.CmbUpdateKategori = New System.Windows.Forms.ComboBox()
        Me.CmbKategoriEdit = New System.Windows.Forms.ComboBox()
        Me.CmbSatuanEdit = New System.Windows.Forms.ComboBox()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Dtpend = New System.Windows.Forms.DateTimePicker()
        Me.DtpStart = New System.Windows.Forms.DateTimePicker()
        Me.TxtCariNamaBarang = New System.Windows.Forms.TextBox()
        Me.CmbKategoriCari = New System.Windows.Forms.ComboBox()
        Me.CmbSatuanCari = New System.Windows.Forms.ComboBox()
        Me.CmbKodeBarangCari = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.ChkTgl = New System.Windows.Forms.CheckBox()
        Me.RdBPB = New System.Windows.Forms.RadioButton()
        Me.RdPCG = New System.Windows.Forms.RadioButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ChkKdItem = New System.Windows.Forms.CheckBox()
        Me.ChkKategori = New System.Windows.Forms.CheckBox()
        Me.ChkSatuan = New System.Windows.Forms.CheckBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.btnFileChooseImage = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pictItem = New System.Windows.Forms.PictureBox()
        Me.txtFileAttachment = New System.Windows.Forms.TextBox()
        Me.CmbSatuan = New System.Windows.Forms.ComboBox()
        Me.CmbKategori = New System.Windows.Forms.ComboBox()
        Me.DtpTanggal = New System.Windows.Forms.DateTimePicker()
        Me.TxtHarga = New System.Windows.Forms.TextBox()
        Me.TxtNamaItem = New System.Windows.Forms.TextBox()
        Me.TxtKodeItem = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pictItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Panel8)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1112, 40)
        Me.Panel1.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(51, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(151, 28)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Master Barang"
        '
        'Panel8
        '
        Me.Panel8.BackgroundImage = CType(resources.GetObject("Panel8.BackgroundImage"), System.Drawing.Image)
        Me.Panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel8.Location = New System.Drawing.Point(15, 3)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(35, 35)
        Me.Panel8.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnRefresh)
        Me.Panel2.Controls.Add(Me.BtnExit)
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Controls.Add(Me.btnSave)
        Me.Panel2.Controls.Add(Me.BtnUpdate)
        Me.Panel2.Controls.Add(Me.btnAdd)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 567)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1112, 40)
        Me.Panel2.TabIndex = 0
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.White
        Me.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRefresh.Location = New System.Drawing.Point(647, 5)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnRefresh.Size = New System.Drawing.Size(75, 30)
        Me.btnRefresh.TabIndex = 987
        Me.btnRefresh.Text = "Cari"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'BtnExit
        '
        Me.BtnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExit.BackColor = System.Drawing.Color.White
        Me.BtnExit.Image = CType(resources.GetObject("BtnExit.Image"), System.Drawing.Image)
        Me.BtnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnExit.Location = New System.Drawing.Point(1027, 5)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.BtnExit.Size = New System.Drawing.Size(75, 30)
        Me.BtnExit.TabIndex = 986
        Me.BtnExit.Text = "Exit"
        Me.BtnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnExit.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.White
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(951, 5)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Padding = New System.Windows.Forms.Padding(5, 0, 3, 0)
        Me.btnCancel.Size = New System.Drawing.Size(75, 30)
        Me.btnCancel.TabIndex = 985
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
        Me.btnSave.Location = New System.Drawing.Point(875, 5)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnSave.Size = New System.Drawing.Size(75, 30)
        Me.btnSave.TabIndex = 984
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnUpdate.BackColor = System.Drawing.Color.White
        Me.BtnUpdate.Image = CType(resources.GetObject("BtnUpdate.Image"), System.Drawing.Image)
        Me.BtnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnUpdate.Location = New System.Drawing.Point(799, 5)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.BtnUpdate.Size = New System.Drawing.Size(75, 30)
        Me.BtnUpdate.TabIndex = 983
        Me.BtnUpdate.Text = "Edit"
        Me.BtnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnUpdate.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.BackColor = System.Drawing.Color.White
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(723, 5)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnAdd.Size = New System.Drawing.Size(75, 30)
        Me.btnAdd.TabIndex = 982
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 40)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1112, 527)
        Me.Panel3.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Panel7)
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 226)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1112, 301)
        Me.Panel5.TabIndex = 0
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.CmbUpdateSatuan)
        Me.Panel7.Controls.Add(Me.CmbUpdateKategori)
        Me.Panel7.Controls.Add(Me.CmbKategoriEdit)
        Me.Panel7.Controls.Add(Me.CmbSatuanEdit)
        Me.Panel7.Controls.Add(Me.fg)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(0, 65)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Padding = New System.Windows.Forms.Padding(10, 0, 10, 10)
        Me.Panel7.Size = New System.Drawing.Size(1112, 236)
        Me.Panel7.TabIndex = 0
        '
        'CmbUpdateSatuan
        '
        Me.CmbUpdateSatuan.FormattingEnabled = True
        Me.CmbUpdateSatuan.Location = New System.Drawing.Point(1067, 202)
        Me.CmbUpdateSatuan.Name = "CmbUpdateSatuan"
        Me.CmbUpdateSatuan.Size = New System.Drawing.Size(10, 21)
        Me.CmbUpdateSatuan.TabIndex = 989
        Me.CmbUpdateSatuan.Visible = False
        '
        'CmbUpdateKategori
        '
        Me.CmbUpdateKategori.FormattingEnabled = True
        Me.CmbUpdateKategori.Location = New System.Drawing.Point(1051, 202)
        Me.CmbUpdateKategori.Name = "CmbUpdateKategori"
        Me.CmbUpdateKategori.Size = New System.Drawing.Size(10, 21)
        Me.CmbUpdateKategori.TabIndex = 990
        Me.CmbUpdateKategori.Visible = False
        '
        'CmbKategoriEdit
        '
        Me.CmbKategoriEdit.FormattingEnabled = True
        Me.CmbKategoriEdit.Location = New System.Drawing.Point(956, 229)
        Me.CmbKategoriEdit.Name = "CmbKategoriEdit"
        Me.CmbKategoriEdit.Size = New System.Drawing.Size(121, 21)
        Me.CmbKategoriEdit.TabIndex = 987
        Me.CmbKategoriEdit.Visible = False
        '
        'CmbSatuanEdit
        '
        Me.CmbSatuanEdit.FormattingEnabled = True
        Me.CmbSatuanEdit.Location = New System.Drawing.Point(829, 230)
        Me.CmbSatuanEdit.Name = "CmbSatuanEdit"
        Me.CmbSatuanEdit.Size = New System.Drawing.Size(121, 21)
        Me.CmbSatuanEdit.TabIndex = 988
        Me.CmbSatuanEdit.Visible = False
        '
        'fg
        '
        Me.fg.ColumnInfo = resources.GetString("fg.ColumnInfo")
        Me.fg.Dock = System.Windows.Forms.DockStyle.Left
        Me.fg.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.fg.Location = New System.Drawing.Point(10, 0)
        Me.fg.Name = "fg"
        Me.fg.Size = New System.Drawing.Size(1092, 226)
        Me.fg.TabIndex = 986
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Panel10)
        Me.Panel6.Controls.Add(Me.Dtpend)
        Me.Panel6.Controls.Add(Me.DtpStart)
        Me.Panel6.Controls.Add(Me.TxtCariNamaBarang)
        Me.Panel6.Controls.Add(Me.CmbKategoriCari)
        Me.Panel6.Controls.Add(Me.CmbSatuanCari)
        Me.Panel6.Controls.Add(Me.CmbKodeBarangCari)
        Me.Panel6.Controls.Add(Me.Label22)
        Me.Panel6.Controls.Add(Me.Label23)
        Me.Panel6.Controls.Add(Me.ChkTgl)
        Me.Panel6.Controls.Add(Me.RdBPB)
        Me.Panel6.Controls.Add(Me.RdPCG)
        Me.Panel6.Controls.Add(Me.Label12)
        Me.Panel6.Controls.Add(Me.ChkKdItem)
        Me.Panel6.Controls.Add(Me.ChkKategori)
        Me.Panel6.Controls.Add(Me.ChkSatuan)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1112, 65)
        Me.Panel6.TabIndex = 0
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.Black
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel10.Location = New System.Drawing.Point(0, 0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(1112, 1)
        Me.Panel10.TabIndex = 905706
        '
        'Dtpend
        '
        Me.Dtpend.Location = New System.Drawing.Point(609, 8)
        Me.Dtpend.Name = "Dtpend"
        Me.Dtpend.Size = New System.Drawing.Size(102, 22)
        Me.Dtpend.TabIndex = 949
        '
        'DtpStart
        '
        Me.DtpStart.Location = New System.Drawing.Point(475, 8)
        Me.DtpStart.Name = "DtpStart"
        Me.DtpStart.Size = New System.Drawing.Size(102, 22)
        Me.DtpStart.TabIndex = 950
        '
        'TxtCariNamaBarang
        '
        Me.TxtCariNamaBarang.Location = New System.Drawing.Point(99, 32)
        Me.TxtCariNamaBarang.Name = "TxtCariNamaBarang"
        Me.TxtCariNamaBarang.Size = New System.Drawing.Size(249, 22)
        Me.TxtCariNamaBarang.TabIndex = 949
        '
        'CmbKategoriCari
        '
        Me.CmbKategoriCari.FormattingEnabled = True
        Me.CmbKategoriCari.Location = New System.Drawing.Point(805, 9)
        Me.CmbKategoriCari.Name = "CmbKategoriCari"
        Me.CmbKategoriCari.Size = New System.Drawing.Size(249, 21)
        Me.CmbKategoriCari.TabIndex = 992
        '
        'CmbSatuanCari
        '
        Me.CmbSatuanCari.FormattingEnabled = True
        Me.CmbSatuanCari.Location = New System.Drawing.Point(805, 33)
        Me.CmbSatuanCari.Name = "CmbSatuanCari"
        Me.CmbSatuanCari.Size = New System.Drawing.Size(249, 21)
        Me.CmbSatuanCari.TabIndex = 991
        '
        'CmbKodeBarangCari
        '
        Me.CmbKodeBarangCari.FormattingEnabled = True
        Me.CmbKodeBarangCari.Location = New System.Drawing.Point(475, 33)
        Me.CmbKodeBarangCari.Name = "CmbKodeBarangCari"
        Me.CmbKodeBarangCari.Size = New System.Drawing.Size(236, 21)
        Me.CmbKodeBarangCari.TabIndex = 990
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(12, 37)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(84, 13)
        Me.Label22.TabIndex = 986
        Me.Label22.Text = "Nama Barang"
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(12, 13)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(84, 13)
        Me.Label23.TabIndex = 987
        Me.Label23.Text = "Master Barang"
        '
        'ChkTgl
        '
        Me.ChkTgl.AutoSize = True
        Me.ChkTgl.BackColor = System.Drawing.Color.Transparent
        Me.ChkTgl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ChkTgl.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.ChkTgl.Location = New System.Drawing.Point(381, 11)
        Me.ChkTgl.Name = "ChkTgl"
        Me.ChkTgl.Size = New System.Drawing.Size(68, 17)
        Me.ChkTgl.TabIndex = 976
        Me.ChkTgl.Text = "Tanggal "
        Me.ChkTgl.UseVisualStyleBackColor = False
        '
        'RdBPB
        '
        Me.RdBPB.AutoSize = True
        Me.RdBPB.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.RdBPB.Location = New System.Drawing.Point(152, 11)
        Me.RdBPB.Name = "RdBPB"
        Me.RdBPB.Size = New System.Drawing.Size(46, 17)
        Me.RdBPB.TabIndex = 988
        Me.RdBPB.Text = "BPB"
        Me.RdBPB.UseVisualStyleBackColor = True
        '
        'RdPCG
        '
        Me.RdPCG.AutoSize = True
        Me.RdPCG.Checked = True
        Me.RdPCG.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.RdPCG.Location = New System.Drawing.Point(99, 11)
        Me.RdPCG.Name = "RdPCG"
        Me.RdPCG.Size = New System.Drawing.Size(47, 17)
        Me.RdPCG.TabIndex = 989
        Me.RdPCG.TabStop = True
        Me.RdPCG.Text = "PCG"
        Me.RdPCG.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.Label12.Location = New System.Drawing.Point(583, 13)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(20, 13)
        Me.Label12.TabIndex = 984
        Me.Label12.Text = "s/d"
        '
        'ChkKdItem
        '
        Me.ChkKdItem.AutoSize = True
        Me.ChkKdItem.BackColor = System.Drawing.Color.Transparent
        Me.ChkKdItem.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ChkKdItem.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.ChkKdItem.Location = New System.Drawing.Point(381, 35)
        Me.ChkKdItem.Name = "ChkKdItem"
        Me.ChkKdItem.Size = New System.Drawing.Size(88, 17)
        Me.ChkKdItem.TabIndex = 975
        Me.ChkKdItem.Text = "Kode Barang"
        Me.ChkKdItem.UseVisualStyleBackColor = False
        '
        'ChkKategori
        '
        Me.ChkKategori.AutoSize = True
        Me.ChkKategori.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ChkKategori.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.ChkKategori.Location = New System.Drawing.Point(733, 11)
        Me.ChkKategori.Name = "ChkKategori"
        Me.ChkKategori.Size = New System.Drawing.Size(66, 17)
        Me.ChkKategori.TabIndex = 977
        Me.ChkKategori.Text = "Kategori"
        Me.ChkKategori.UseVisualStyleBackColor = True
        '
        'ChkSatuan
        '
        Me.ChkSatuan.AutoSize = True
        Me.ChkSatuan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ChkSatuan.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.ChkSatuan.Location = New System.Drawing.Point(733, 35)
        Me.ChkSatuan.Name = "ChkSatuan"
        Me.ChkSatuan.Size = New System.Drawing.Size(60, 17)
        Me.ChkSatuan.TabIndex = 978
        Me.ChkSatuan.Text = "Satuan"
        Me.ChkSatuan.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Panel9)
        Me.Panel4.Controls.Add(Me.btnFileChooseImage)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.GroupBox1)
        Me.Panel4.Controls.Add(Me.txtFileAttachment)
        Me.Panel4.Controls.Add(Me.CmbSatuan)
        Me.Panel4.Controls.Add(Me.CmbKategori)
        Me.Panel4.Controls.Add(Me.DtpTanggal)
        Me.Panel4.Controls.Add(Me.TxtHarga)
        Me.Panel4.Controls.Add(Me.TxtNamaItem)
        Me.Panel4.Controls.Add(Me.TxtKodeItem)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.Label13)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1112, 226)
        Me.Panel4.TabIndex = 0
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.Black
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(1112, 1)
        Me.Panel9.TabIndex = 905706
        '
        'btnFileChooseImage
        '
        Me.btnFileChooseImage.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnFileChooseImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnFileChooseImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnFileChooseImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFileChooseImage.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnFileChooseImage.Location = New System.Drawing.Point(597, 193)
        Me.btnFileChooseImage.Name = "btnFileChooseImage"
        Me.btnFileChooseImage.Size = New System.Drawing.Size(72, 25)
        Me.btnFileChooseImage.TabIndex = 1065
        Me.btnFileChooseImage.Text = "Pilih"
        Me.btnFileChooseImage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFileChooseImage.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(371, 198)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 14)
        Me.Label5.TabIndex = 1067
        Me.Label5.Text = "Pilih Gambar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.pictItem)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(371, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(298, 189)
        Me.GroupBox1.TabIndex = 1066
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
        Me.txtFileAttachment.Location = New System.Drawing.Point(371, 194)
        Me.txtFileAttachment.Name = "txtFileAttachment"
        Me.txtFileAttachment.Size = New System.Drawing.Size(298, 22)
        Me.txtFileAttachment.TabIndex = 1068
        Me.txtFileAttachment.Visible = False
        '
        'CmbSatuan
        '
        Me.CmbSatuan.FormattingEnabled = True
        Me.CmbSatuan.Location = New System.Drawing.Point(93, 162)
        Me.CmbSatuan.Name = "CmbSatuan"
        Me.CmbSatuan.Size = New System.Drawing.Size(249, 21)
        Me.CmbSatuan.TabIndex = 944
        '
        'CmbKategori
        '
        Me.CmbKategori.FormattingEnabled = True
        Me.CmbKategori.Location = New System.Drawing.Point(93, 138)
        Me.CmbKategori.Name = "CmbKategori"
        Me.CmbKategori.Size = New System.Drawing.Size(249, 21)
        Me.CmbKategori.TabIndex = 943
        '
        'DtpTanggal
        '
        Me.DtpTanggal.Location = New System.Drawing.Point(93, 112)
        Me.DtpTanggal.Name = "DtpTanggal"
        Me.DtpTanggal.Size = New System.Drawing.Size(249, 22)
        Me.DtpTanggal.TabIndex = 942
        '
        'TxtHarga
        '
        Me.TxtHarga.Location = New System.Drawing.Point(93, 87)
        Me.TxtHarga.Name = "TxtHarga"
        Me.TxtHarga.Size = New System.Drawing.Size(249, 22)
        Me.TxtHarga.TabIndex = 941
        '
        'TxtNamaItem
        '
        Me.TxtNamaItem.Location = New System.Drawing.Point(93, 37)
        Me.TxtNamaItem.Multiline = True
        Me.TxtNamaItem.Name = "TxtNamaItem"
        Me.TxtNamaItem.Size = New System.Drawing.Size(249, 47)
        Me.TxtNamaItem.TabIndex = 941
        '
        'TxtKodeItem
        '
        Me.TxtKodeItem.Location = New System.Drawing.Point(93, 12)
        Me.TxtKodeItem.Name = "TxtKodeItem"
        Me.TxtKodeItem.Size = New System.Drawing.Size(249, 22)
        Me.TxtKodeItem.TabIndex = 941
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(12, 139)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 19)
        Me.Label6.TabIndex = 926
        Me.Label6.Text = "Kategori"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(12, 163)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 19)
        Me.Label13.TabIndex = 929
        Me.Label13.Text = "Satuan"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(12, 114)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 19)
        Me.Label10.TabIndex = 928
        Me.Label10.Text = "Tanggal"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(12, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 19)
        Me.Label2.TabIndex = 927
        Me.Label2.Text = "Harga Barang"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(12, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 19)
        Me.Label3.TabIndex = 930
        Me.Label3.Text = "KodeItem"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 19)
        Me.Label1.TabIndex = 931
        Me.Label1.Text = "Nama barang"
        '
        'FrmMstItemInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1112, 607)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FrmMstItemInventory"
        Me.Text = "Master Barang"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.pictItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents CmbSatuan As ComboBox
    Friend WithEvents CmbKategori As ComboBox
    Friend WithEvents DtpTanggal As DateTimePicker
    Friend WithEvents TxtHarga As TextBox
    Friend WithEvents TxtNamaItem As TextBox
    Friend WithEvents TxtKodeItem As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents ChkTgl As CheckBox
    Friend WithEvents RdBPB As RadioButton
    Friend WithEvents RdPCG As RadioButton
    Friend WithEvents Label12 As Label
    Friend WithEvents ChkKdItem As CheckBox
    Friend WithEvents ChkKategori As CheckBox
    Friend WithEvents ChkSatuan As CheckBox
    Friend WithEvents Dtpend As DateTimePicker
    Friend WithEvents DtpStart As DateTimePicker
    Friend WithEvents TxtCariNamaBarang As TextBox
    Friend WithEvents CmbKategoriCari As ComboBox
    Friend WithEvents CmbSatuanCari As ComboBox
    Friend WithEvents CmbKodeBarangCari As ComboBox
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BtnExit As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents BtnUpdate As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel8 As Panel
    Friend WithEvents CmbKategoriEdit As ComboBox
    Friend WithEvents CmbSatuanEdit As ComboBox
    Friend WithEvents CmbUpdateSatuan As ComboBox
    Friend WithEvents CmbUpdateKategori As ComboBox
    Friend WithEvents btnFileChooseImage As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents pictItem As PictureBox
    Friend WithEvents txtFileAttachment As TextBox
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Panel9 As Panel
End Class
