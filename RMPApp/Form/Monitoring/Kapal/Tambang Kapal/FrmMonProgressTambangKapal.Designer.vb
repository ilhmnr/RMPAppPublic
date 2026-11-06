Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMonProgressTambangKapal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMonProgressTambangKapal))
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dtpMuat2 = New System.Windows.Forms.DateTimePicker()
        Me.dtpMuat1 = New System.Windows.Forms.DateTimePicker()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.rdAllJenis = New System.Windows.Forms.RadioButton()
        Me.rdJambul = New System.Windows.Forms.RadioButton()
        Me.rdLicin = New System.Windows.Forms.RadioButton()
        Me.rdCungkil = New System.Windows.Forms.RadioButton()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.rdPSG = New System.Windows.Forms.RadioButton()
        Me.rdAllTujuan = New System.Windows.Forms.RadioButton()
        Me.rdRSUP = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rdBelumInput = New System.Windows.Forms.RadioButton()
        Me.rdSudahInput = New System.Windows.Forms.RadioButton()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblJudulForm = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboPancang = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTrip = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboKapal = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel3.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.fg)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 156)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(0, 5, 0, 5)
        Me.Panel3.Size = New System.Drawing.Size(1233, 532)
        Me.Panel3.TabIndex = 16
        '
        'fg
        '
        Me.fg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.fg.ColumnInfo = resources.GetString("fg.ColumnInfo")
        Me.fg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fg.Location = New System.Drawing.Point(0, 5)
        Me.fg.Name = "fg"
        Me.fg.Rows.Count = 1
        Me.fg.Size = New System.Drawing.Size(1233, 522)
        Me.fg.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.dtpMuat2)
        Me.Panel1.Controls.Add(Me.dtpMuat1)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.cboPancang)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtTrip)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cboKapal)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1233, 156)
        Me.Panel1.TabIndex = 15
        '
        'dtpMuat2
        '
        Me.dtpMuat2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpMuat2.Location = New System.Drawing.Point(233, 44)
        Me.dtpMuat2.Name = "dtpMuat2"
        Me.dtpMuat2.Size = New System.Drawing.Size(96, 20)
        Me.dtpMuat2.TabIndex = 905703
        '
        'dtpMuat1
        '
        Me.dtpMuat1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpMuat1.Location = New System.Drawing.Point(115, 44)
        Me.dtpMuat1.Name = "dtpMuat1"
        Me.dtpMuat1.Size = New System.Drawing.Size(96, 20)
        Me.dtpMuat1.TabIndex = 905703
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
        Me.btnSearch.Location = New System.Drawing.Point(765, 62)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(30, 30)
        Me.btnSearch.TabIndex = 905702
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.rdAllJenis)
        Me.Panel6.Controls.Add(Me.rdJambul)
        Me.Panel6.Controls.Add(Me.rdLicin)
        Me.Panel6.Controls.Add(Me.rdCungkil)
        Me.Panel6.Location = New System.Drawing.Point(115, 117)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(279, 25)
        Me.Panel6.TabIndex = 905701
        '
        'rdAllJenis
        '
        Me.rdAllJenis.AutoSize = True
        Me.rdAllJenis.Checked = True
        Me.rdAllJenis.Location = New System.Drawing.Point(4, 4)
        Me.rdAllJenis.Name = "rdAllJenis"
        Me.rdAllJenis.Size = New System.Drawing.Size(63, 17)
        Me.rdAllJenis.TabIndex = 905700
        Me.rdAllJenis.TabStop = True
        Me.rdAllJenis.Text = "All Jenis"
        Me.rdAllJenis.UseVisualStyleBackColor = True
        '
        'rdJambul
        '
        Me.rdJambul.AutoSize = True
        Me.rdJambul.Location = New System.Drawing.Point(73, 4)
        Me.rdJambul.Name = "rdJambul"
        Me.rdJambul.Size = New System.Drawing.Size(58, 17)
        Me.rdJambul.TabIndex = 905700
        Me.rdJambul.Text = "Jambul"
        Me.rdJambul.UseVisualStyleBackColor = True
        '
        'rdLicin
        '
        Me.rdLicin.AutoSize = True
        Me.rdLicin.Location = New System.Drawing.Point(137, 4)
        Me.rdLicin.Name = "rdLicin"
        Me.rdLicin.Size = New System.Drawing.Size(47, 17)
        Me.rdLicin.TabIndex = 905700
        Me.rdLicin.Text = "Licin"
        Me.rdLicin.UseVisualStyleBackColor = True
        '
        'rdCungkil
        '
        Me.rdCungkil.AutoSize = True
        Me.rdCungkil.Location = New System.Drawing.Point(190, 4)
        Me.rdCungkil.Name = "rdCungkil"
        Me.rdCungkil.Size = New System.Drawing.Size(60, 17)
        Me.rdCungkil.TabIndex = 905700
        Me.rdCungkil.Text = "Cungkil"
        Me.rdCungkil.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.rdPSG)
        Me.Panel5.Controls.Add(Me.rdAllTujuan)
        Me.Panel5.Controls.Add(Me.rdRSUP)
        Me.Panel5.Location = New System.Drawing.Point(115, 91)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(279, 25)
        Me.Panel5.TabIndex = 905701
        '
        'rdPSG
        '
        Me.rdPSG.AutoSize = True
        Me.rdPSG.Location = New System.Drawing.Point(143, 4)
        Me.rdPSG.Name = "rdPSG"
        Me.rdPSG.Size = New System.Drawing.Size(47, 17)
        Me.rdPSG.TabIndex = 905700
        Me.rdPSG.Text = "PSG"
        Me.rdPSG.UseVisualStyleBackColor = True
        '
        'rdAllTujuan
        '
        Me.rdAllTujuan.AutoSize = True
        Me.rdAllTujuan.Checked = True
        Me.rdAllTujuan.Location = New System.Drawing.Point(4, 4)
        Me.rdAllTujuan.Name = "rdAllTujuan"
        Me.rdAllTujuan.Size = New System.Drawing.Size(72, 17)
        Me.rdAllTujuan.TabIndex = 905700
        Me.rdAllTujuan.TabStop = True
        Me.rdAllTujuan.Text = "All Tujuan"
        Me.rdAllTujuan.UseVisualStyleBackColor = True
        '
        'rdRSUP
        '
        Me.rdRSUP.AutoSize = True
        Me.rdRSUP.Location = New System.Drawing.Point(82, 4)
        Me.rdRSUP.Name = "rdRSUP"
        Me.rdRSUP.Size = New System.Drawing.Size(55, 17)
        Me.rdRSUP.TabIndex = 905700
        Me.rdRSUP.Text = "RSUP"
        Me.rdRSUP.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rdBelumInput)
        Me.Panel2.Controls.Add(Me.rdSudahInput)
        Me.Panel2.Location = New System.Drawing.Point(115, 65)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(279, 25)
        Me.Panel2.TabIndex = 905701
        '
        'rdBelumInput
        '
        Me.rdBelumInput.AutoSize = True
        Me.rdBelumInput.Checked = True
        Me.rdBelumInput.Location = New System.Drawing.Point(4, 4)
        Me.rdBelumInput.Name = "rdBelumInput"
        Me.rdBelumInput.Size = New System.Drawing.Size(129, 17)
        Me.rdBelumInput.TabIndex = 905700
        Me.rdBelumInput.TabStop = True
        Me.rdBelumInput.Text = "Belum Input Tambang"
        Me.rdBelumInput.UseVisualStyleBackColor = True
        '
        'rdSudahInput
        '
        Me.rdSudahInput.AutoSize = True
        Me.rdSudahInput.Location = New System.Drawing.Point(139, 4)
        Me.rdSudahInput.Name = "rdSudahInput"
        Me.rdSudahInput.Size = New System.Drawing.Size(131, 17)
        Me.rdSudahInput.TabIndex = 905700
        Me.rdSudahInput.Text = "Sudah Input Tambang"
        Me.rdSudahInput.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Silver
        Me.Panel4.Controls.Add(Me.lblJudulForm)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1231, 30)
        Me.Panel4.TabIndex = 905656
        '
        'lblJudulForm
        '
        Me.lblJudulForm.AutoSize = True
        Me.lblJudulForm.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJudulForm.ForeColor = System.Drawing.Color.Black
        Me.lblJudulForm.Location = New System.Drawing.Point(378, 2)
        Me.lblJudulForm.Name = "lblJudulForm"
        Me.lblJudulForm.Size = New System.Drawing.Size(465, 25)
        Me.lblJudulForm.TabIndex = 0
        Me.lblJudulForm.Text = "MONITORING PROGRESS TAMBANG KAPAL"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(21, 123)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 905693
        Me.Label6.Text = "Jenis"
        '
        'cboPancang
        '
        Me.cboPancang.FormattingEnabled = True
        Me.cboPancang.Location = New System.Drawing.Point(457, 67)
        Me.cboPancang.Name = "cboPancang"
        Me.cboPancang.Size = New System.Drawing.Size(302, 21)
        Me.cboPancang.TabIndex = 905698
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 97)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 905693
        Me.Label5.Text = "Tujuan"
        '
        'txtTrip
        '
        Me.txtTrip.Location = New System.Drawing.Point(457, 119)
        Me.txtTrip.Name = "txtTrip"
        Me.txtTrip.Size = New System.Drawing.Size(75, 20)
        Me.txtTrip.TabIndex = 905697
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(217, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(10, 13)
        Me.Label8.TabIndex = 905693
        Me.Label8.Text = "-"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(21, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 13)
        Me.Label7.TabIndex = 905693
        Me.Label7.Text = "Tanggal Booking"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 905693
        Me.Label4.Text = "Status"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(401, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 905693
        Me.Label1.Text = "Pancang"
        '
        'cboKapal
        '
        Me.cboKapal.FormattingEnabled = True
        Me.cboKapal.Location = New System.Drawing.Point(457, 93)
        Me.cboKapal.Name = "cboKapal"
        Me.cboKapal.Size = New System.Drawing.Size(302, 21)
        Me.cboKapal.TabIndex = 905699
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(401, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 905695
        Me.Label2.Text = "Kapal"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(401, 123)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 13)
        Me.Label3.TabIndex = 905694
        Me.Label3.Text = "Trip"
        '
        'FrmMonProgressTambangKapal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1233, 688)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmMonProgressTambangKapal"
        Me.Text = "Monitoring Progres Tambang Kapal"
        Me.Panel3.ResumeLayout(False)
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel3 As Panel
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents lblJudulForm As Label
    Friend WithEvents cboPancang As ComboBox
    Friend WithEvents txtTrip As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cboKapal As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents rdPSG As RadioButton
    Friend WithEvents rdRSUP As RadioButton
    Friend WithEvents rdAllTujuan As RadioButton
    Friend WithEvents rdSudahInput As RadioButton
    Friend WithEvents rdBelumInput As RadioButton
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents rdCungkil As RadioButton
    Friend WithEvents rdLicin As RadioButton
    Friend WithEvents rdJambul As RadioButton
    Friend WithEvents rdAllJenis As RadioButton
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnSearch As Button
    Friend WithEvents dtpMuat2 As DateTimePicker
    Friend WithEvents dtpMuat1 As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
End Class
