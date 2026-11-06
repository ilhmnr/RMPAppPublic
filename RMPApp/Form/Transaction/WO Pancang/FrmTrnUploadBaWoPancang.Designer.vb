<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTrnUploadBaWoPancang
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTrnUploadBaWoPancang))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.AxAcroPDF1 = New AxAcroPDFLib.AxAcroPDF()
        Me.lblFile = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnUploadFile = New System.Windows.Forms.Button()
        Me.picFile = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.txtWoId = New System.Windows.Forms.TextBox()
        Me.txtJudul = New System.Windows.Forms.TextBox()
        Me.txtPancang = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rdMandiri = New System.Windows.Forms.RadioButton()
        Me.rdKontraktor = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picFile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Panel11)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(671, 33)
        Me.Panel1.TabIndex = 3
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.Black
        Me.Panel11.Location = New System.Drawing.Point(12, 29)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(479, 3)
        Me.Panel11.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Cooper Black", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, -3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(358, 31)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Upload BA WO Pancang"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 33)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(5, 0, 5, 5)
        Me.Panel2.Size = New System.Drawing.Size(671, 218)
        Me.Panel2.TabIndex = 4
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.AxAcroPDF1)
        Me.GroupBox2.Controls.Add(Me.lblFile)
        Me.GroupBox2.Controls.Add(Me.btnSave)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.btnUploadFile)
        Me.GroupBox2.Controls.Add(Me.picFile)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(5, 89)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(661, 124)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Upload BA"
        '
        'AxAcroPDF1
        '
        Me.AxAcroPDF1.Enabled = True
        Me.AxAcroPDF1.Location = New System.Drawing.Point(421, 55)
        Me.AxAcroPDF1.Name = "AxAcroPDF1"
        Me.AxAcroPDF1.OcxState = CType(resources.GetObject("AxAcroPDF1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxAcroPDF1.Size = New System.Drawing.Size(192, 192)
        Me.AxAcroPDF1.TabIndex = 905688
        Me.AxAcroPDF1.Visible = False
        '
        'lblFile
        '
        Me.lblFile.Location = New System.Drawing.Point(84, 60)
        Me.lblFile.Name = "lblFile"
        Me.lblFile.ReadOnly = True
        Me.lblFile.Size = New System.Drawing.Size(308, 20)
        Me.lblFile.TabIndex = 905687
        Me.lblFile.Text = "No File"
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(84, 86)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(94, 32)
        Me.btnSave.TabIndex = 905684
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(7, 17)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(46, 13)
        Me.Label19.TabIndex = 905683
        Me.Label19.Text = "File BA :"
        '
        'btnUploadFile
        '
        Me.btnUploadFile.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnUploadFile.ForeColor = System.Drawing.Color.White
        Me.btnUploadFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUploadFile.Location = New System.Drawing.Point(84, 33)
        Me.btnUploadFile.Name = "btnUploadFile"
        Me.btnUploadFile.Size = New System.Drawing.Size(68, 21)
        Me.btnUploadFile.TabIndex = 905686
        Me.btnUploadFile.Text = "Upload File"
        Me.btnUploadFile.UseVisualStyleBackColor = False
        '
        'picFile
        '
        Me.picFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picFile.Location = New System.Drawing.Point(10, 33)
        Me.picFile.Name = "picFile"
        Me.picFile.Size = New System.Drawing.Size(68, 85)
        Me.picFile.TabIndex = 905685
        Me.picFile.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdKontraktor)
        Me.GroupBox1.Controls.Add(Me.rdMandiri)
        Me.GroupBox1.Controls.Add(Me.btnExit)
        Me.GroupBox1.Controls.Add(Me.btnFind)
        Me.GroupBox1.Controls.Add(Me.txtWoId)
        Me.GroupBox1.Controls.Add(Me.txtJudul)
        Me.GroupBox1.Controls.Add(Me.txtPancang)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(5, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(661, 89)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detail WO"
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnExit.ForeColor = System.Drawing.Color.White
        Me.btnExit.Image = Global.RMPApp.My.Resources.Resources.ExitPSN
        Me.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExit.Location = New System.Drawing.Point(427, 29)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(72, 32)
        Me.btnExit.TabIndex = 126
        Me.btnExit.Text = "Exit"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnFind
        '
        Me.btnFind.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnFind.ForeColor = System.Drawing.Color.White
        Me.btnFind.Image = Global.RMPApp.My.Resources.Resources.find20
        Me.btnFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFind.Location = New System.Drawing.Point(356, 29)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(72, 32)
        Me.btnFind.TabIndex = 127
        Me.btnFind.Text = "Find"
        Me.btnFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFind.UseVisualStyleBackColor = False
        '
        'txtWoId
        '
        Me.txtWoId.Location = New System.Drawing.Point(350, 6)
        Me.txtWoId.Name = "txtWoId"
        Me.txtWoId.Size = New System.Drawing.Size(27, 20)
        Me.txtWoId.TabIndex = 139
        Me.txtWoId.Visible = False
        '
        'txtJudul
        '
        Me.txtJudul.Location = New System.Drawing.Point(75, 41)
        Me.txtJudul.Name = "txtJudul"
        Me.txtJudul.ReadOnly = True
        Me.txtJudul.Size = New System.Drawing.Size(275, 20)
        Me.txtJudul.TabIndex = 142
        '
        'txtPancang
        '
        Me.txtPancang.Location = New System.Drawing.Point(75, 15)
        Me.txtPancang.Name = "txtPancang"
        Me.txtPancang.ReadOnly = True
        Me.txtPancang.Size = New System.Drawing.Size(275, 20)
        Me.txtPancang.TabIndex = 143
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(62, 19)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(10, 13)
        Me.Label18.TabIndex = 129
        Me.Label18.Text = ":"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(62, 45)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(10, 13)
        Me.Label17.TabIndex = 131
        Me.Label17.Text = ":"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 135
        Me.Label6.Text = "Judul"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 13)
        Me.Label5.TabIndex = 136
        Me.Label5.Text = "Pancang"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 135
        Me.Label1.Text = "Pelaksana"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(62, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 13)
        Me.Label2.TabIndex = 131
        Me.Label2.Text = ":"
        '
        'rdMandiri
        '
        Me.rdMandiri.AutoSize = True
        Me.rdMandiri.Checked = True
        Me.rdMandiri.Enabled = False
        Me.rdMandiri.Location = New System.Drawing.Point(75, 67)
        Me.rdMandiri.Name = "rdMandiri"
        Me.rdMandiri.Size = New System.Drawing.Size(59, 17)
        Me.rdMandiri.TabIndex = 144
        Me.rdMandiri.TabStop = True
        Me.rdMandiri.Text = "Mandiri"
        Me.rdMandiri.UseVisualStyleBackColor = True
        '
        'rdKontraktor
        '
        Me.rdKontraktor.AutoSize = True
        Me.rdKontraktor.Enabled = False
        Me.rdKontraktor.Location = New System.Drawing.Point(140, 67)
        Me.rdKontraktor.Name = "rdKontraktor"
        Me.rdKontraktor.Size = New System.Drawing.Size(74, 17)
        Me.rdKontraktor.TabIndex = 144
        Me.rdKontraktor.Text = "Kontraktor"
        Me.rdKontraktor.UseVisualStyleBackColor = True
        '
        'FrmTrnUploadBaWoPancang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(671, 251)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmTrnUploadBaWoPancang"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmTrnUploadBaWoPancang"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picFile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnExit As Button
    Friend WithEvents btnFind As Button
    Friend WithEvents txtWoId As TextBox
    Friend WithEvents txtJudul As TextBox
    Friend WithEvents txtPancang As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblFile As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents Label19 As Label
    Friend WithEvents btnUploadFile As Button
    Friend WithEvents picFile As PictureBox
    Friend WithEvents AxAcroPDF1 As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents Panel11 As Panel
    Friend WithEvents rdKontraktor As RadioButton
    Friend WithEvents rdMandiri As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
