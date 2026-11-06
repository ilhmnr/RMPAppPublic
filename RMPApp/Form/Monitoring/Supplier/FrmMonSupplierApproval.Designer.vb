<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMonSupplierApproval
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMonSupplierApproval))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rdAll = New System.Windows.Forms.RadioButton()
        Me.rdApproval2 = New System.Windows.Forms.RadioButton()
        Me.rdApproval1 = New System.Windows.Forms.RadioButton()
        Me.rdBelumApproval = New System.Windows.Forms.RadioButton()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnCari = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtp2 = New System.Windows.Forms.DateTimePicker()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.chkTgl = New System.Windows.Forms.CheckBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.rdAll)
        Me.Panel1.Controls.Add(Me.rdApproval2)
        Me.Panel1.Controls.Add(Me.rdApproval1)
        Me.Panel1.Controls.Add(Me.rdBelumApproval)
        Me.Panel1.Controls.Add(Me.btnExcel)
        Me.Panel1.Controls.Add(Me.btnCari)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.dtp2)
        Me.Panel1.Controls.Add(Me.dtp1)
        Me.Panel1.Controls.Add(Me.chkTgl)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(975, 83)
        Me.Panel1.TabIndex = 0
        '
        'rdAll
        '
        Me.rdAll.AutoSize = True
        Me.rdAll.Checked = True
        Me.rdAll.Location = New System.Drawing.Point(10, 36)
        Me.rdAll.Name = "rdAll"
        Me.rdAll.Size = New System.Drawing.Size(36, 17)
        Me.rdAll.TabIndex = 5
        Me.rdAll.TabStop = True
        Me.rdAll.Text = "All"
        Me.rdAll.UseVisualStyleBackColor = True
        '
        'rdApproval2
        '
        Me.rdApproval2.AutoSize = True
        Me.rdApproval2.Location = New System.Drawing.Point(273, 36)
        Me.rdApproval2.Name = "rdApproval2"
        Me.rdApproval2.Size = New System.Drawing.Size(110, 17)
        Me.rdApproval2.TabIndex = 5
        Me.rdApproval2.Text = "Sudah Approval 2"
        Me.rdApproval2.UseVisualStyleBackColor = True
        '
        'rdApproval1
        '
        Me.rdApproval1.AutoSize = True
        Me.rdApproval1.Location = New System.Drawing.Point(157, 36)
        Me.rdApproval1.Name = "rdApproval1"
        Me.rdApproval1.Size = New System.Drawing.Size(110, 17)
        Me.rdApproval1.TabIndex = 5
        Me.rdApproval1.Text = "Sudah Approval 1"
        Me.rdApproval1.UseVisualStyleBackColor = True
        '
        'rdBelumApproval
        '
        Me.rdBelumApproval.AutoSize = True
        Me.rdBelumApproval.Location = New System.Drawing.Point(52, 36)
        Me.rdBelumApproval.Name = "rdBelumApproval"
        Me.rdBelumApproval.Size = New System.Drawing.Size(99, 17)
        Me.rdBelumApproval.TabIndex = 5
        Me.rdBelumApproval.Text = "Belum Approval"
        Me.rdBelumApproval.UseVisualStyleBackColor = True
        '
        'btnExcel
        '
        Me.btnExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExcel.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.ForeColor = System.Drawing.Color.White
        Me.btnExcel.Location = New System.Drawing.Point(860, 54)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(105, 23)
        Me.btnExcel.TabIndex = 4
        Me.btnExcel.Text = "Convert Excel"
        Me.btnExcel.UseVisualStyleBackColor = False
        '
        'btnCari
        '
        Me.btnCari.BackgroundImage = Global.RMPApp.My.Resources.Resources.find20
        Me.btnCari.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCari.Location = New System.Drawing.Point(316, 57)
        Me.btnCari.Name = "btnCari"
        Me.btnCari.Size = New System.Drawing.Size(23, 23)
        Me.btnCari.TabIndex = 4
        Me.btnCari.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(190, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "sd"
        '
        'dtp2
        '
        Me.dtp2.Location = New System.Drawing.Point(214, 58)
        Me.dtp2.Name = "dtp2"
        Me.dtp2.Size = New System.Drawing.Size(96, 20)
        Me.dtp2.TabIndex = 2
        '
        'dtp1
        '
        Me.dtp1.Location = New System.Drawing.Point(87, 58)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(96, 20)
        Me.dtp1.TabIndex = 2
        '
        'chkTgl
        '
        Me.chkTgl.AutoSize = True
        Me.chkTgl.Location = New System.Drawing.Point(10, 60)
        Me.chkTgl.Name = "chkTgl"
        Me.chkTgl.Size = New System.Drawing.Size(71, 17)
        Me.chkTgl.TabIndex = 1
        Me.chkTgl.Text = "Tanggal :"
        Me.chkTgl.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(975, 33)
        Me.Panel3.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Monotype Corsiva", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(234, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Monitoring Approval Relasi"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.fg)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 83)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(10, 0, 10, 10)
        Me.Panel2.Size = New System.Drawing.Size(975, 564)
        Me.Panel2.TabIndex = 0
        '
        'fg
        '
        Me.fg.ColumnInfo = resources.GetString("fg.ColumnInfo")
        Me.fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fg.Location = New System.Drawing.Point(10, 0)
        Me.fg.Name = "fg"
        Me.fg.Size = New System.Drawing.Size(955, 554)
        Me.fg.TabIndex = 0
        '
        'FrmMonApprovalRelasi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(975, 647)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmMonApprovalRelasi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Monitoring Approval Relasi"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents dtp2 As DateTimePicker
    Friend WithEvents dtp1 As DateTimePicker
    Friend WithEvents chkTgl As CheckBox
    Friend WithEvents btnCari As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents rdAll As RadioButton
    Friend WithEvents rdApproval2 As RadioButton
    Friend WithEvents rdApproval1 As RadioButton
    Friend WithEvents rdBelumApproval As RadioButton
    Friend WithEvents btnExcel As Button
End Class
