<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmApprovalUserPelangsirKapalAndroid
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtNama = New System.Windows.Forms.TextBox()
        Me.btnCari = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnApproval = New System.Windows.Forms.Button()
        Me.btnReject = New System.Windows.Forms.Button()
        Me.rdNoStatus = New System.Windows.Forms.RadioButton()
        Me.rdApproval = New System.Windows.Forms.RadioButton()
        Me.rdReject = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.rdReject)
        Me.Panel1.Controls.Add(Me.rdApproval)
        Me.Panel1.Controls.Add(Me.rdNoStatus)
        Me.Panel1.Controls.Add(Me.btnReject)
        Me.Panel1.Controls.Add(Me.btnApproval)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnCari)
        Me.Panel1.Controls.Add(Me.txtNama)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(10, 10)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(914, 87)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.fg)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(10, 97)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(914, 423)
        Me.Panel2.TabIndex = 1
        '
        'fg
        '
        Me.fg.ColumnInfo = "10,1,0,0,0,-1,Columns:1{Style:""DataType:System.Boolean;TextAlign:LeftCenter;Image" &
    "Align:CenterCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fg.Location = New System.Drawing.Point(0, 0)
        Me.fg.Name = "fg"
        Me.fg.Size = New System.Drawing.Size(912, 421)
        Me.fg.TabIndex = 0
        '
        'txtNama
        '
        Me.txtNama.Location = New System.Drawing.Point(8, 61)
        Me.txtNama.Name = "txtNama"
        Me.txtNama.Size = New System.Drawing.Size(206, 20)
        Me.txtNama.TabIndex = 0
        '
        'btnCari
        '
        Me.btnCari.Image = Global.RMPApp.My.Resources.Resources.find20
        Me.btnCari.Location = New System.Drawing.Point(220, 51)
        Me.btnCari.Name = "btnCari"
        Me.btnCari.Size = New System.Drawing.Size(30, 30)
        Me.btnCari.TabIndex = 1
        Me.btnCari.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Matura MT Script Capitals", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(413, 26)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Approval User Pelangsir Kapala Pancang"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Black
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Location = New System.Drawing.Point(8, 29)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(440, 3)
        Me.Panel3.TabIndex = 3
        '
        'btnApproval
        '
        Me.btnApproval.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnApproval.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnApproval.Location = New System.Drawing.Point(753, 58)
        Me.btnApproval.Name = "btnApproval"
        Me.btnApproval.Size = New System.Drawing.Size(75, 23)
        Me.btnApproval.TabIndex = 4
        Me.btnApproval.Text = "Approval"
        Me.btnApproval.UseVisualStyleBackColor = False
        '
        'btnReject
        '
        Me.btnReject.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReject.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnReject.Location = New System.Drawing.Point(834, 58)
        Me.btnReject.Name = "btnReject"
        Me.btnReject.Size = New System.Drawing.Size(75, 23)
        Me.btnReject.TabIndex = 4
        Me.btnReject.Text = "Reject"
        Me.btnReject.UseVisualStyleBackColor = False
        '
        'rdNoStatus
        '
        Me.rdNoStatus.AutoSize = True
        Me.rdNoStatus.Checked = True
        Me.rdNoStatus.Location = New System.Drawing.Point(8, 38)
        Me.rdNoStatus.Name = "rdNoStatus"
        Me.rdNoStatus.Size = New System.Drawing.Size(72, 17)
        Me.rdNoStatus.TabIndex = 5
        Me.rdNoStatus.TabStop = True
        Me.rdNoStatus.Text = "No Status"
        Me.rdNoStatus.UseVisualStyleBackColor = True
        '
        'rdApproval
        '
        Me.rdApproval.AutoSize = True
        Me.rdApproval.Location = New System.Drawing.Point(86, 38)
        Me.rdApproval.Name = "rdApproval"
        Me.rdApproval.Size = New System.Drawing.Size(67, 17)
        Me.rdApproval.TabIndex = 5
        Me.rdApproval.Text = "Approval"
        Me.rdApproval.UseVisualStyleBackColor = True
        '
        'rdReject
        '
        Me.rdReject.AutoSize = True
        Me.rdReject.Location = New System.Drawing.Point(159, 38)
        Me.rdReject.Name = "rdReject"
        Me.rdReject.Size = New System.Drawing.Size(56, 17)
        Me.rdReject.TabIndex = 5
        Me.rdReject.Text = "Reject"
        Me.rdReject.UseVisualStyleBackColor = True
        '
        'FrmApprovalUserPelangsirKapalAndroid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 530)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmApprovalUserPelangsirKapalAndroid"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmApprovalUserPelangsirKapalAndroid"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents btnCari As Button
    Friend WithEvents txtNama As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnReject As Button
    Friend WithEvents btnApproval As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents rdReject As RadioButton
    Friend WithEvents rdApproval As RadioButton
    Friend WithEvents rdNoStatus As RadioButton
End Class
