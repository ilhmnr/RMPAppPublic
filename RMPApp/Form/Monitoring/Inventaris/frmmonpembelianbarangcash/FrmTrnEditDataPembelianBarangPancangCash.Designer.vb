<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTrnEditDataPembelianBarangPancangCash
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTrnEditDataPembelianBarangPancangCash))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.CmbKategori = New System.Windows.Forms.ComboBox()
        Me.CmbCatatan = New System.Windows.Forms.ComboBox()
        Me.tgl = New System.Windows.Forms.DateTimePicker()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.RdInv = New System.Windows.Forms.RadioButton()
        Me.RdOper = New System.Windows.Forms.RadioButton()
        Me.ChkNonActive = New System.Windows.Forms.CheckBox()
        Me.rdPulsa = New System.Windows.Forms.RadioButton()
        Me.rdPurchaser = New System.Windows.Forms.RadioButton()
        Me.rdPancang = New System.Windows.Forms.RadioButton()
        Me.TxtTotal = New System.Windows.Forms.TextBox()
        Me.TxtHarga = New System.Windows.Forms.TextBox()
        Me.TxtQty = New System.Windows.Forms.TextBox()
        Me.TxtDetailId = New System.Windows.Forms.TextBox()
        Me.TxtNamaItem = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Panel8)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(456, 40)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(48, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(362, 28)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Edit Pembelian Barang Pancang Cash"
        '
        'Panel8
        '
        Me.Panel8.BackgroundImage = CType(resources.GetObject("Panel8.BackgroundImage"), System.Drawing.Image)
        Me.Panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel8.Location = New System.Drawing.Point(12, 2)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(35, 35)
        Me.Panel8.TabIndex = 11
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel2.Controls.Add(Me.BtnCancel)
        Me.Panel2.Controls.Add(Me.BtnSave)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 319)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(456, 40)
        Me.Panel2.TabIndex = 0
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.BackColor = System.Drawing.Color.White
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCancel.Location = New System.Drawing.Point(369, 5)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.BtnCancel.Size = New System.Drawing.Size(75, 30)
        Me.BtnCancel.TabIndex = 1027
        Me.BtnCancel.Text = "Exit"
        Me.BtnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSave.BackColor = System.Drawing.Color.White
        Me.BtnSave.Image = CType(resources.GetObject("BtnSave.Image"), System.Drawing.Image)
        Me.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSave.Location = New System.Drawing.Point(293, 5)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.BtnSave.Size = New System.Drawing.Size(75, 30)
        Me.BtnSave.TabIndex = 1026
        Me.BtnSave.Text = "Save"
        Me.BtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.Panel10)
        Me.Panel3.Controls.Add(Me.CmbKategori)
        Me.Panel3.Controls.Add(Me.CmbCatatan)
        Me.Panel3.Controls.Add(Me.tgl)
        Me.Panel3.Controls.Add(Me.Label20)
        Me.Panel3.Controls.Add(Me.Label16)
        Me.Panel3.Controls.Add(Me.Panel6)
        Me.Panel3.Controls.Add(Me.ChkNonActive)
        Me.Panel3.Controls.Add(Me.rdPulsa)
        Me.Panel3.Controls.Add(Me.rdPurchaser)
        Me.Panel3.Controls.Add(Me.rdPancang)
        Me.Panel3.Controls.Add(Me.TxtTotal)
        Me.Panel3.Controls.Add(Me.TxtHarga)
        Me.Panel3.Controls.Add(Me.TxtQty)
        Me.Panel3.Controls.Add(Me.TxtDetailId)
        Me.Panel3.Controls.Add(Me.TxtNamaItem)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Label21)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 40)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(456, 279)
        Me.Panel3.TabIndex = 0
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.Black
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel10.Location = New System.Drawing.Point(0, 0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(456, 1)
        Me.Panel10.TabIndex = 905708
        '
        'CmbKategori
        '
        Me.CmbKategori.FormattingEnabled = True
        Me.CmbKategori.Location = New System.Drawing.Point(89, 124)
        Me.CmbKategori.Name = "CmbKategori"
        Me.CmbKategori.Size = New System.Drawing.Size(350, 21)
        Me.CmbKategori.TabIndex = 1079
        '
        'CmbCatatan
        '
        Me.CmbCatatan.FormattingEnabled = True
        Me.CmbCatatan.Location = New System.Drawing.Point(89, 100)
        Me.CmbCatatan.Name = "CmbCatatan"
        Me.CmbCatatan.Size = New System.Drawing.Size(350, 21)
        Me.CmbCatatan.TabIndex = 1079
        '
        'tgl
        '
        Me.tgl.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.tgl.Location = New System.Drawing.Point(89, 12)
        Me.tgl.Name = "tgl"
        Me.tgl.Size = New System.Drawing.Size(99, 22)
        Me.tgl.TabIndex = 1078
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.Label20.Location = New System.Drawing.Point(12, 104)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(44, 13)
        Me.Label20.TabIndex = 1077
        Me.Label20.Text = "Catatan"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.Label16.Location = New System.Drawing.Point(12, 128)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(71, 13)
        Me.Label16.TabIndex = 1076
        Me.Label16.Text = "Kategori Item"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.RdInv)
        Me.Panel6.Controls.Add(Me.RdOper)
        Me.Panel6.Location = New System.Drawing.Point(89, 223)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(173, 25)
        Me.Panel6.TabIndex = 1071
        '
        'RdInv
        '
        Me.RdInv.AutoSize = True
        Me.RdInv.Location = New System.Drawing.Point(3, 4)
        Me.RdInv.Name = "RdInv"
        Me.RdInv.Size = New System.Drawing.Size(75, 17)
        Me.RdInv.TabIndex = 2
        Me.RdInv.TabStop = True
        Me.RdInv.Text = "Inventaris"
        Me.RdInv.UseVisualStyleBackColor = True
        '
        'RdOper
        '
        Me.RdOper.AutoSize = True
        Me.RdOper.Location = New System.Drawing.Point(80, 4)
        Me.RdOper.Name = "RdOper"
        Me.RdOper.Size = New System.Drawing.Size(88, 17)
        Me.RdOper.TabIndex = 2
        Me.RdOper.TabStop = True
        Me.RdOper.Text = "Operasional"
        Me.RdOper.UseVisualStyleBackColor = True
        '
        'ChkNonActive
        '
        Me.ChkNonActive.AutoSize = True
        Me.ChkNonActive.Location = New System.Drawing.Point(89, 252)
        Me.ChkNonActive.Name = "ChkNonActive"
        Me.ChkNonActive.Size = New System.Drawing.Size(78, 17)
        Me.ChkNonActive.TabIndex = 1068
        Me.ChkNonActive.Text = "NonActive"
        Me.ChkNonActive.UseVisualStyleBackColor = True
        '
        'rdPulsa
        '
        Me.rdPulsa.AutoSize = True
        Me.rdPulsa.Location = New System.Drawing.Point(261, 79)
        Me.rdPulsa.Name = "rdPulsa"
        Me.rdPulsa.Size = New System.Drawing.Size(125, 17)
        Me.rdPulsa.TabIndex = 1067
        Me.rdPulsa.TabStop = True
        Me.rdPulsa.Text = "Pulsa / Token Listrik"
        Me.rdPulsa.UseVisualStyleBackColor = True
        '
        'rdPurchaser
        '
        Me.rdPurchaser.AutoSize = True
        Me.rdPurchaser.Location = New System.Drawing.Point(166, 79)
        Me.rdPurchaser.Name = "rdPurchaser"
        Me.rdPurchaser.Size = New System.Drawing.Size(75, 17)
        Me.rdPurchaser.TabIndex = 1066
        Me.rdPurchaser.TabStop = True
        Me.rdPurchaser.Text = "Purchaser"
        Me.rdPurchaser.UseVisualStyleBackColor = True
        '
        'rdPancang
        '
        Me.rdPancang.AutoSize = True
        Me.rdPancang.Location = New System.Drawing.Point(89, 79)
        Me.rdPancang.Name = "rdPancang"
        Me.rdPancang.Size = New System.Drawing.Size(69, 17)
        Me.rdPancang.TabIndex = 1065
        Me.rdPancang.TabStop = True
        Me.rdPancang.Text = "Pancang"
        Me.rdPancang.UseVisualStyleBackColor = True
        '
        'TxtTotal
        '
        Me.TxtTotal.Location = New System.Drawing.Point(89, 198)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.Size = New System.Drawing.Size(156, 22)
        Me.TxtTotal.TabIndex = 1063
        '
        'TxtHarga
        '
        Me.TxtHarga.Location = New System.Drawing.Point(89, 148)
        Me.TxtHarga.Name = "TxtHarga"
        Me.TxtHarga.Size = New System.Drawing.Size(156, 22)
        Me.TxtHarga.TabIndex = 1064
        '
        'TxtQty
        '
        Me.TxtQty.Location = New System.Drawing.Point(89, 173)
        Me.TxtQty.Name = "TxtQty"
        Me.TxtQty.Size = New System.Drawing.Size(156, 22)
        Me.TxtQty.TabIndex = 1062
        '
        'TxtDetailId
        '
        Me.TxtDetailId.Location = New System.Drawing.Point(12, 60)
        Me.TxtDetailId.Name = "TxtDetailId"
        Me.TxtDetailId.Size = New System.Drawing.Size(60, 22)
        Me.TxtDetailId.TabIndex = 1060
        Me.TxtDetailId.Visible = False
        '
        'TxtNamaItem
        '
        Me.TxtNamaItem.Location = New System.Drawing.Point(89, 35)
        Me.TxtNamaItem.Multiline = True
        Me.TxtNamaItem.Name = "TxtNamaItem"
        Me.TxtNamaItem.Size = New System.Drawing.Size(350, 40)
        Me.TxtNamaItem.TabIndex = 1061
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 254)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 13)
        Me.Label11.TabIndex = 1045
        Me.Label11.Text = "NonActive"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 81)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(60, 13)
        Me.Label13.TabIndex = 1046
        Me.Label13.Text = "Pembelian"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 229)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 13)
        Me.Label9.TabIndex = 1047
        Me.Label9.Text = "Kategori"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(12, 203)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(31, 13)
        Me.Label15.TabIndex = 1049
        Me.Label15.Text = "Total"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 153)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 1051
        Me.Label4.Text = "Harga"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 178)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 1053
        Me.Label3.Text = "Quantity"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(12, 16)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(47, 13)
        Me.Label21.TabIndex = 1059
        Me.Label21.Text = "Tanggal"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 1044
        Me.Label2.Text = "Nama Item"
        '
        'FrmTrnEditDataPembelianBarangPancangCash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(456, 359)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FrmTrnEditDataPembelianBarangPancangCash"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Pembelian Barang Pancang Cash"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents tgl As DateTimePicker
    Friend WithEvents Label20 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents RdInv As RadioButton
    Friend WithEvents RdOper As RadioButton
    Friend WithEvents ChkNonActive As CheckBox
    Friend WithEvents rdPulsa As RadioButton
    Friend WithEvents rdPurchaser As RadioButton
    Friend WithEvents rdPancang As RadioButton
    Friend WithEvents TxtTotal As TextBox
    Friend WithEvents TxtHarga As TextBox
    Friend WithEvents TxtQty As TextBox
    Friend WithEvents TxtDetailId As TextBox
    Friend WithEvents TxtNamaItem As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents BtnCancel As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents CmbKategori As ComboBox
    Friend WithEvents CmbCatatan As ComboBox
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel8 As Panel
End Class
