<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFotoSlide
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
        Me.Pic = New System.Windows.Forms.PictureBox()
        Me.lblJudulFoto = New System.Windows.Forms.Label()
        Me.lblNoFoto = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTotalFoto = New System.Windows.Forms.Label()
        Me.pnlSlideKanan = New System.Windows.Forms.Panel()
        Me.pnlSlideKiri = New System.Windows.Forms.Panel()
        Me.pnlControlSlide = New System.Windows.Forms.Panel()
        Me.lblKg = New System.Windows.Forms.Label()
        CType(Me.Pic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlControlSlide.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pic
        '
        Me.Pic.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pic.Location = New System.Drawing.Point(12, 43)
        Me.Pic.Name = "Pic"
        Me.Pic.Size = New System.Drawing.Size(440, 417)
        Me.Pic.TabIndex = 0
        Me.Pic.TabStop = False
        '
        'lblJudulFoto
        '
        Me.lblJudulFoto.AutoSize = True
        Me.lblJudulFoto.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJudulFoto.Location = New System.Drawing.Point(6, 6)
        Me.lblJudulFoto.Name = "lblJudulFoto"
        Me.lblJudulFoto.Size = New System.Drawing.Size(151, 31)
        Me.lblJudulFoto.TabIndex = 2
        Me.lblJudulFoto.Text = "Judul Foto"
        '
        'lblNoFoto
        '
        Me.lblNoFoto.AutoSize = True
        Me.lblNoFoto.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoFoto.Location = New System.Drawing.Point(74, 7)
        Me.lblNoFoto.Name = "lblNoFoto"
        Me.lblNoFoto.Size = New System.Drawing.Size(44, 31)
        Me.lblNoFoto.TabIndex = 2
        Me.lblNoFoto.Text = "00"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(124, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 31)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = ":"
        '
        'lblTotalFoto
        '
        Me.lblTotalFoto.AutoSize = True
        Me.lblTotalFoto.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalFoto.Location = New System.Drawing.Point(152, 7)
        Me.lblTotalFoto.Name = "lblTotalFoto"
        Me.lblTotalFoto.Size = New System.Drawing.Size(44, 31)
        Me.lblTotalFoto.TabIndex = 2
        Me.lblTotalFoto.Text = "00"
        '
        'pnlSlideKanan
        '
        Me.pnlSlideKanan.BackgroundImage = Global.RMPApp.My.Resources.Resources.slide_right
        Me.pnlSlideKanan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlSlideKanan.Location = New System.Drawing.Point(202, 0)
        Me.pnlSlideKanan.Name = "pnlSlideKanan"
        Me.pnlSlideKanan.Size = New System.Drawing.Size(67, 44)
        Me.pnlSlideKanan.TabIndex = 3
        '
        'pnlSlideKiri
        '
        Me.pnlSlideKiri.BackgroundImage = Global.RMPApp.My.Resources.Resources.slide_left
        Me.pnlSlideKiri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlSlideKiri.Location = New System.Drawing.Point(1, 0)
        Me.pnlSlideKiri.Name = "pnlSlideKiri"
        Me.pnlSlideKiri.Size = New System.Drawing.Size(67, 44)
        Me.pnlSlideKiri.TabIndex = 3
        '
        'pnlControlSlide
        '
        Me.pnlControlSlide.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlControlSlide.Controls.Add(Me.pnlSlideKiri)
        Me.pnlControlSlide.Controls.Add(Me.lblNoFoto)
        Me.pnlControlSlide.Controls.Add(Me.pnlSlideKanan)
        Me.pnlControlSlide.Controls.Add(Me.Label3)
        Me.pnlControlSlide.Controls.Add(Me.lblTotalFoto)
        Me.pnlControlSlide.Location = New System.Drawing.Point(97, 466)
        Me.pnlControlSlide.Name = "pnlControlSlide"
        Me.pnlControlSlide.Size = New System.Drawing.Size(270, 46)
        Me.pnlControlSlide.TabIndex = 4
        '
        'lblKg
        '
        Me.lblKg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblKg.AutoSize = True
        Me.lblKg.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKg.Location = New System.Drawing.Point(364, 6)
        Me.lblKg.Name = "lblKg"
        Me.lblKg.Size = New System.Drawing.Size(81, 31)
        Me.lblKg.TabIndex = 2
        Me.lblKg.Text = "00Kg"
        '
        'FrmFotoSlide
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(464, 516)
        Me.Controls.Add(Me.pnlControlSlide)
        Me.Controls.Add(Me.lblKg)
        Me.Controls.Add(Me.lblJudulFoto)
        Me.Controls.Add(Me.Pic)
        Me.Name = "FrmFotoSlide"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Show Foto"
        CType(Me.Pic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlControlSlide.ResumeLayout(False)
        Me.pnlControlSlide.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Pic As PictureBox
    Friend WithEvents lblJudulFoto As Label
    Friend WithEvents lblNoFoto As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTotalFoto As Label
    Friend WithEvents pnlSlideKanan As Panel
    Friend WithEvents pnlSlideKiri As Panel
    Friend WithEvents pnlControlSlide As Panel
    Friend WithEvents lblKg As Label
End Class
