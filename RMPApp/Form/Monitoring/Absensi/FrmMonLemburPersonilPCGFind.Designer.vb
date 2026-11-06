<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMonLemburPersonilPCGFind
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rdPeriode2 = New System.Windows.Forms.RadioButton()
        Me.rdPeriode1 = New System.Windows.Forms.RadioButton()
        Me.rdAll = New System.Windows.Forms.RadioButton()
        Me.rdP2 = New System.Windows.Forms.RadioButton()
        Me.rdP1 = New System.Windows.Forms.RadioButton()
        Me.dtp = New System.Windows.Forms.DateTimePicker()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.btnrefreshh = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(323, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 268
        Me.Label2.Text = "Bagian :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 269
        Me.Label1.Text = "Periode :"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rdPeriode2)
        Me.Panel2.Controls.Add(Me.rdPeriode1)
        Me.Panel2.Location = New System.Drawing.Point(67, 10)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(155, 29)
        Me.Panel2.TabIndex = 267
        '
        'rdPeriode2
        '
        Me.rdPeriode2.AutoSize = True
        Me.rdPeriode2.Location = New System.Drawing.Point(82, 6)
        Me.rdPeriode2.Name = "rdPeriode2"
        Me.rdPeriode2.Size = New System.Drawing.Size(70, 17)
        Me.rdPeriode2.TabIndex = 0
        Me.rdPeriode2.Text = "Periode 2"
        Me.rdPeriode2.UseVisualStyleBackColor = True
        '
        'rdPeriode1
        '
        Me.rdPeriode1.AutoSize = True
        Me.rdPeriode1.Checked = True
        Me.rdPeriode1.Location = New System.Drawing.Point(4, 5)
        Me.rdPeriode1.Name = "rdPeriode1"
        Me.rdPeriode1.Size = New System.Drawing.Size(70, 17)
        Me.rdPeriode1.TabIndex = 0
        Me.rdPeriode1.TabStop = True
        Me.rdPeriode1.Text = "Periode 1"
        Me.rdPeriode1.UseVisualStyleBackColor = True
        '
        'rdAll
        '
        Me.rdAll.AutoSize = True
        Me.rdAll.Location = New System.Drawing.Point(463, 16)
        Me.rdAll.Name = "rdAll"
        Me.rdAll.Size = New System.Drawing.Size(36, 17)
        Me.rdAll.TabIndex = 264
        Me.rdAll.Text = "All"
        Me.rdAll.UseVisualStyleBackColor = True
        '
        'rdP2
        '
        Me.rdP2.AutoSize = True
        Me.rdP2.Location = New System.Drawing.Point(419, 16)
        Me.rdP2.Name = "rdP2"
        Me.rdP2.Size = New System.Drawing.Size(38, 17)
        Me.rdP2.TabIndex = 265
        Me.rdP2.Text = "P2"
        Me.rdP2.UseVisualStyleBackColor = True
        '
        'rdP1
        '
        Me.rdP1.AutoSize = True
        Me.rdP1.Checked = True
        Me.rdP1.Location = New System.Drawing.Point(375, 16)
        Me.rdP1.Name = "rdP1"
        Me.rdP1.Size = New System.Drawing.Size(38, 17)
        Me.rdP1.TabIndex = 266
        Me.rdP1.TabStop = True
        Me.rdP1.Text = "P1"
        Me.rdP1.UseVisualStyleBackColor = True
        '
        'dtp
        '
        Me.dtp.CustomFormat = "MM-yyyy"
        Me.dtp.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp.Location = New System.Drawing.Point(225, 13)
        Me.dtp.Name = "dtp"
        Me.dtp.Size = New System.Drawing.Size(68, 23)
        Me.dtp.TabIndex = 263
        Me.dtp.Value = New Date(2019, 4, 8, 0, 0, 0, 0)
        '
        'fg
        '
        Me.fg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fg.ColumnInfo = "10,1,0,0,0,-1,Columns:"
        Me.fg.Location = New System.Drawing.Point(15, 50)
        Me.fg.Name = "fg"
        Me.fg.Size = New System.Drawing.Size(888, 401)
        Me.fg.TabIndex = 270
        '
        'btnrefreshh
        '
        Me.btnrefreshh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnrefreshh.BackColor = System.Drawing.Color.AliceBlue
        Me.btnrefreshh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnrefreshh.Font = New System.Drawing.Font("Gabriola", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnrefreshh.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.btnrefreshh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnrefreshh.Location = New System.Drawing.Point(828, 6)
        Me.btnrefreshh.Name = "btnrefreshh"
        Me.btnrefreshh.Size = New System.Drawing.Size(75, 37)
        Me.btnrefreshh.TabIndex = 271
        Me.btnrefreshh.Text = "Refresh"
        Me.btnrefreshh.UseVisualStyleBackColor = False
        '
        'FrmMonLemburPersonilPCGFind
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(915, 463)
        Me.Controls.Add(Me.btnrefreshh)
        Me.Controls.Add(Me.fg)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.rdAll)
        Me.Controls.Add(Me.rdP2)
        Me.Controls.Add(Me.rdP1)
        Me.Controls.Add(Me.dtp)
        Me.Name = "FrmMonLemburPersonilPCGFind"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lembur Personil Pancang Find"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents rdPeriode2 As RadioButton
    Friend WithEvents rdPeriode1 As RadioButton
    Friend WithEvents rdAll As RadioButton
    Friend WithEvents rdP2 As RadioButton
    Friend WithEvents rdP1 As RadioButton
    Friend WithEvents dtp As DateTimePicker
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents btnrefreshh As Button
End Class
