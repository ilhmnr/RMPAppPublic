<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTrnTambangKapalBPIFindKapal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTrnTambangKapalBPIFindKapal))
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtTrip = New System.Windows.Forms.TextBox()
        Me.cboKapal = New System.Windows.Forms.ComboBox()
        Me.cboPancang = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblJudulForm = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.dtpTanggalNota2 = New System.Windows.Forms.DateTimePicker()
        Me.dtpTanggalNota1 = New System.Windows.Forms.DateTimePicker()
        Me.Panel3.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.fg)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 96)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(0, 5, 0, 5)
        Me.Panel3.Size = New System.Drawing.Size(1140, 392)
        Me.Panel3.TabIndex = 23
        '
        'fg
        '
        Me.fg.ColumnInfo = resources.GetString("fg.ColumnInfo")
        Me.fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fg.Location = New System.Drawing.Point(0, 5)
        Me.fg.Name = "fg"
        Me.fg.Rows.Count = 1
        Me.fg.Size = New System.Drawing.Size(1140, 382)
        Me.fg.TabIndex = 3
        '
        'txtTrip
        '
        Me.txtTrip.Location = New System.Drawing.Point(484, 38)
        Me.txtTrip.Name = "txtTrip"
        Me.txtTrip.Size = New System.Drawing.Size(75, 20)
        Me.txtTrip.TabIndex = 905673
        '
        'cboKapal
        '
        Me.cboKapal.FormattingEnabled = True
        Me.cboKapal.Location = New System.Drawing.Point(484, 64)
        Me.cboKapal.Name = "cboKapal"
        Me.cboKapal.Size = New System.Drawing.Size(302, 21)
        Me.cboKapal.TabIndex = 905675
        '
        'cboPancang
        '
        Me.cboPancang.FormattingEnabled = True
        Me.cboPancang.Location = New System.Drawing.Point(114, 64)
        Me.cboPancang.Name = "cboPancang"
        Me.cboPancang.Size = New System.Drawing.Size(302, 21)
        Me.cboPancang.TabIndex = 905674
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(447, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 13)
        Me.Label3.TabIndex = 905666
        Me.Label3.Text = "Trip"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(447, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 905667
        Me.Label2.Text = "Kapal"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(260, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 13)
        Me.Label5.TabIndex = 905664
        Me.Label5.Text = "-"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 13)
        Me.Label4.TabIndex = 905664
        Me.Label4.Text = "Tanggal Kalkulasi"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 905664
        Me.Label1.Text = "Pancang"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Silver
        Me.Panel4.Controls.Add(Me.lblJudulForm)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1138, 30)
        Me.Panel4.TabIndex = 905656
        '
        'lblJudulForm
        '
        Me.lblJudulForm.AutoSize = True
        Me.lblJudulForm.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJudulForm.ForeColor = System.Drawing.Color.Black
        Me.lblJudulForm.Location = New System.Drawing.Point(378, 2)
        Me.lblJudulForm.Name = "lblJudulForm"
        Me.lblJudulForm.Size = New System.Drawing.Size(328, 25)
        Me.lblJudulForm.TabIndex = 0
        Me.lblJudulForm.Text = "FIND KAPAL TAMBANG KAPAL"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.dtpTanggalNota2)
        Me.Panel1.Controls.Add(Me.dtpTanggalNota1)
        Me.Panel1.Controls.Add(Me.txtTrip)
        Me.Panel1.Controls.Add(Me.cboKapal)
        Me.Panel1.Controls.Add(Me.cboPancang)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1140, 96)
        Me.Panel1.TabIndex = 22
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnSearch.BackgroundImage = Global.RMPApp.My.Resources.Resources.search_button_31102025
        Me.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(792, 55)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(30, 30)
        Me.btnSearch.TabIndex = 905692
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'dtpTanggalNota2
        '
        Me.dtpTanggalNota2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTanggalNota2.Location = New System.Drawing.Point(278, 38)
        Me.dtpTanggalNota2.Name = "dtpTanggalNota2"
        Me.dtpTanggalNota2.Size = New System.Drawing.Size(138, 20)
        Me.dtpTanggalNota2.TabIndex = 905690
        '
        'dtpTanggalNota1
        '
        Me.dtpTanggalNota1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTanggalNota1.Location = New System.Drawing.Point(114, 38)
        Me.dtpTanggalNota1.Name = "dtpTanggalNota1"
        Me.dtpTanggalNota1.Size = New System.Drawing.Size(138, 20)
        Me.dtpTanggalNota1.TabIndex = 905690
        '
        'FrmTrnTambangKapalBPIFindKapal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1140, 488)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmTrnTambangKapalBPIFindKapal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Find Kapal Tambang Kapal"
        Me.Panel3.ResumeLayout(False)
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel3 As Panel
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtTrip As TextBox
    Friend WithEvents cboKapal As ComboBox
    Friend WithEvents cboPancang As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents lblJudulForm As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents dtpTanggalNota2 As DateTimePicker
    Friend WithEvents dtpTanggalNota1 As DateTimePicker
    Friend WithEvents btnSearch As Button
End Class
