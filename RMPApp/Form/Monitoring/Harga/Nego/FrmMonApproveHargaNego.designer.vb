<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMonApproveHargaNego
    'Inherits System.Windows.Forms.Form
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMonApproveHargaNego))
        Me.grpDataTimbangCrane = New XanderUI.XUICustomGroupbox()
        Me.fg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.schfg = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.DTPEnd = New System.Windows.Forms.DateTimePicker()
        Me.DTPStart = New System.Windows.Forms.DateTimePicker()
        Me.chkTransDate = New System.Windows.Forms.CheckBox()
        Me.chkTrip = New System.Windows.Forms.CheckBox()
        Me.cmbTrip = New System.Windows.Forms.ComboBox()
        Me.cmbKapal = New System.Windows.Forms.ComboBox()
        Me.chkKapal = New System.Windows.Forms.CheckBox()
        Me.cmbPancang = New System.Windows.Forms.ComboBox()
        Me.chkPancang = New System.Windows.Forms.CheckBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.pnlHead = New System.Windows.Forms.Panel()
        Me.lblHead = New System.Windows.Forms.Label()
        Me.chkS_Petani = New System.Windows.Forms.CheckBox()
        Me.cmbS_Petani = New System.Windows.Forms.ComboBox()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.rdSudahInputHargaNego = New System.Windows.Forms.RadioButton()
        Me.rdSudahApproval1 = New System.Windows.Forms.RadioButton()
        Me.rdSudahApproval2 = New System.Windows.Forms.RadioButton()
        Me.rdSudahApproval3 = New System.Windows.Forms.RadioButton()
        Me.grpDataTimbangCrane.SuspendLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpDataTimbangCrane
        '
        Me.grpDataTimbangCrane.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDataTimbangCrane.BorderColor = System.Drawing.Color.DodgerBlue
        Me.grpDataTimbangCrane.BorderWidth = 1
        Me.grpDataTimbangCrane.Controls.Add(Me.fg)
        Me.grpDataTimbangCrane.Controls.Add(Me.schfg)
        Me.grpDataTimbangCrane.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDataTimbangCrane.Location = New System.Drawing.Point(3, 172)
        Me.grpDataTimbangCrane.Name = "grpDataTimbangCrane"
        Me.grpDataTimbangCrane.ShowText = True
        Me.grpDataTimbangCrane.Size = New System.Drawing.Size(950, 467)
        Me.grpDataTimbangCrane.TabIndex = 97
        Me.grpDataTimbangCrane.TabStop = False
        Me.grpDataTimbangCrane.TextColor = System.Drawing.Color.Navy
        '
        'fg
        '
        Me.fg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fg.ColumnInfo = "27,1,0,0,0,110,Columns:1{Style:""TextAlign:GeneralCenter;ImageAlign:CenterCenter;""" &
    ";}" & Global.Microsoft.VisualBasic.ChrW(9) & "25{ShowButtons:Never;}" & Global.Microsoft.VisualBasic.ChrW(9) & "26{Name:""Button"";ShowButtons:Always;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.fg.ForeColor = System.Drawing.Color.Black
        Me.fg.Location = New System.Drawing.Point(10, 26)
        Me.fg.Name = "fg"
        Me.fg.Rows.Count = 10
        Me.fg.Rows.DefaultSize = 22
        Me.fg.Size = New System.Drawing.Size(935, 432)
        Me.fg.StyleInfo = resources.GetString("fg.StyleInfo")
        Me.fg.TabIndex = 195
        '
        'schfg
        '
        Me.schfg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.schfg.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.schfg.Location = New System.Drawing.Point(664, -10)
        Me.schfg.Margin = New System.Windows.Forms.Padding(1)
        Me.schfg.Name = "schfg"
        Me.schfg.ShowClearButton = False
        Me.schfg.ShowSearchButton = False
        Me.schfg.Size = New System.Drawing.Size(310, 40)
        Me.schfg.TabIndex = 194
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnRefresh.BackgroundImage = CType(resources.GetObject("btnRefresh.BackgroundImage"), System.Drawing.Image)
        Me.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnRefresh.Location = New System.Drawing.Point(650, 141)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(36, 24)
        Me.btnRefresh.TabIndex = 338
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'DTPEnd
        '
        Me.DTPEnd.CustomFormat = "dd/mm/yyyy"
        Me.DTPEnd.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPEnd.Location = New System.Drawing.Point(236, 84)
        Me.DTPEnd.Name = "DTPEnd"
        Me.DTPEnd.Size = New System.Drawing.Size(93, 23)
        Me.DTPEnd.TabIndex = 337
        Me.DTPEnd.Value = New Date(2020, 2, 1, 0, 0, 0, 0)
        '
        'DTPStart
        '
        Me.DTPStart.CustomFormat = "dd/mm/yyyy"
        Me.DTPStart.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPStart.Location = New System.Drawing.Point(121, 84)
        Me.DTPStart.Name = "DTPStart"
        Me.DTPStart.Size = New System.Drawing.Size(98, 23)
        Me.DTPStart.TabIndex = 336
        Me.DTPStart.Value = New Date(2020, 2, 1, 0, 0, 0, 0)
        '
        'chkTransDate
        '
        Me.chkTransDate.AutoSize = True
        Me.chkTransDate.Checked = True
        Me.chkTransDate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTransDate.FlatAppearance.BorderSize = 0
        Me.chkTransDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkTransDate.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTransDate.Location = New System.Drawing.Point(13, 85)
        Me.chkTransDate.Name = "chkTransDate"
        Me.chkTransDate.Size = New System.Drawing.Size(56, 21)
        Me.chkTransDate.TabIndex = 335
        Me.chkTransDate.Text = "Date"
        Me.chkTransDate.UseVisualStyleBackColor = True
        '
        'chkTrip
        '
        Me.chkTrip.AutoSize = True
        Me.chkTrip.FlatAppearance.BorderSize = 0
        Me.chkTrip.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkTrip.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTrip.Location = New System.Drawing.Point(359, 114)
        Me.chkTrip.Name = "chkTrip"
        Me.chkTrip.Size = New System.Drawing.Size(45, 21)
        Me.chkTrip.TabIndex = 334
        Me.chkTrip.Text = "Trip"
        Me.chkTrip.UseVisualStyleBackColor = True
        '
        'cmbTrip
        '
        Me.cmbTrip.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cmbTrip.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbTrip.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTrip.FormattingEnabled = True
        Me.cmbTrip.IntegralHeight = False
        Me.cmbTrip.ItemHeight = 17
        Me.cmbTrip.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50"})
        Me.cmbTrip.Location = New System.Drawing.Point(436, 112)
        Me.cmbTrip.Name = "cmbTrip"
        Me.cmbTrip.Size = New System.Drawing.Size(81, 25)
        Me.cmbTrip.TabIndex = 333
        '
        'cmbKapal
        '
        Me.cmbKapal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cmbKapal.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.cmbKapal.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbKapal.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbKapal.FormattingEnabled = True
        Me.cmbKapal.IntegralHeight = False
        Me.cmbKapal.Location = New System.Drawing.Point(436, 141)
        Me.cmbKapal.Name = "cmbKapal"
        Me.cmbKapal.Size = New System.Drawing.Size(208, 25)
        Me.cmbKapal.TabIndex = 331
        '
        'chkKapal
        '
        Me.chkKapal.AutoSize = True
        Me.chkKapal.FlatAppearance.BorderSize = 0
        Me.chkKapal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkKapal.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkKapal.Location = New System.Drawing.Point(358, 143)
        Me.chkKapal.Name = "chkKapal"
        Me.chkKapal.Size = New System.Drawing.Size(62, 21)
        Me.chkKapal.TabIndex = 332
        Me.chkKapal.Text = "Kapal"
        Me.chkKapal.UseVisualStyleBackColor = True
        '
        'cmbPancang
        '
        Me.cmbPancang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cmbPancang.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbPancang.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPancang.FormattingEnabled = True
        Me.cmbPancang.IntegralHeight = False
        Me.cmbPancang.Location = New System.Drawing.Point(121, 112)
        Me.cmbPancang.Name = "cmbPancang"
        Me.cmbPancang.Size = New System.Drawing.Size(209, 25)
        Me.cmbPancang.TabIndex = 330
        '
        'chkPancang
        '
        Me.chkPancang.AutoSize = True
        Me.chkPancang.FlatAppearance.BorderSize = 0
        Me.chkPancang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkPancang.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPancang.Location = New System.Drawing.Point(13, 114)
        Me.chkPancang.Name = "chkPancang"
        Me.chkPancang.Size = New System.Drawing.Size(83, 21)
        Me.chkPancang.TabIndex = 329
        Me.chkPancang.Text = "Pancang"
        Me.chkPancang.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.LightCoral
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnClose.Location = New System.Drawing.Point(858, 646)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(85, 30)
        Me.btnClose.TabIndex = 804
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'pnlHead
        '
        Me.pnlHead.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlHead.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.pnlHead.Location = New System.Drawing.Point(10, 49)
        Me.pnlHead.Name = "pnlHead"
        Me.pnlHead.Size = New System.Drawing.Size(936, 1)
        Me.pnlHead.TabIndex = 303
        '
        'lblHead
        '
        Me.lblHead.AutoSize = True
        Me.lblHead.BackColor = System.Drawing.Color.Transparent
        Me.lblHead.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblHead.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHead.ForeColor = System.Drawing.Color.Gray
        Me.lblHead.Location = New System.Drawing.Point(7, 12)
        Me.lblHead.Name = "lblHead"
        Me.lblHead.Size = New System.Drawing.Size(285, 28)
        Me.lblHead.TabIndex = 302
        Me.lblHead.Text = "Monitoring Harga Nego"
        '
        'chkS_Petani
        '
        Me.chkS_Petani.AutoSize = True
        Me.chkS_Petani.FlatAppearance.BorderSize = 0
        Me.chkS_Petani.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkS_Petani.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkS_Petani.Location = New System.Drawing.Point(13, 143)
        Me.chkS_Petani.Name = "chkS_Petani"
        Me.chkS_Petani.Size = New System.Drawing.Size(92, 21)
        Me.chkS_Petani.TabIndex = 811
        Me.chkS_Petani.Text = "Sub Petani"
        Me.chkS_Petani.UseVisualStyleBackColor = True
        '
        'cmbS_Petani
        '
        Me.cmbS_Petani.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cmbS_Petani.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbS_Petani.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbS_Petani.FormattingEnabled = True
        Me.cmbS_Petani.IntegralHeight = False
        Me.cmbS_Petani.Location = New System.Drawing.Point(121, 141)
        Me.cmbS_Petani.Name = "cmbS_Petani"
        Me.cmbS_Petani.Size = New System.Drawing.Size(209, 24)
        Me.cmbS_Petani.TabIndex = 810
        '
        'btnExcel
        '
        Me.btnExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExcel.BackColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExcel.FlatAppearance.BorderSize = 0
        Me.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcel.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnExcel.Image = Global.RMPApp.My.Resources.Resources.excel
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(757, 645)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(95, 30)
        Me.btnExcel.TabIndex = 812
        Me.btnExcel.Text = "Excel"
        Me.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcel.UseVisualStyleBackColor = False
        '
        'rdSudahInputHargaNego
        '
        Me.rdSudahInputHargaNego.AutoSize = True
        Me.rdSudahInputHargaNego.Checked = True
        Me.rdSudahInputHargaNego.Location = New System.Drawing.Point(12, 61)
        Me.rdSudahInputHargaNego.Name = "rdSudahInputHargaNego"
        Me.rdSudahInputHargaNego.Size = New System.Drawing.Size(144, 17)
        Me.rdSudahInputHargaNego.TabIndex = 813
        Me.rdSudahInputHargaNego.TabStop = True
        Me.rdSudahInputHargaNego.Text = "Sudah Input Harga Nego"
        Me.rdSudahInputHargaNego.UseVisualStyleBackColor = True
        '
        'rdSudahApproval1
        '
        Me.rdSudahApproval1.AutoSize = True
        Me.rdSudahApproval1.Location = New System.Drawing.Point(162, 61)
        Me.rdSudahApproval1.Name = "rdSudahApproval1"
        Me.rdSudahApproval1.Size = New System.Drawing.Size(110, 17)
        Me.rdSudahApproval1.TabIndex = 813
        Me.rdSudahApproval1.Text = "Sudah Approval 1"
        Me.rdSudahApproval1.UseVisualStyleBackColor = True
        '
        'rdSudahApproval2
        '
        Me.rdSudahApproval2.AutoSize = True
        Me.rdSudahApproval2.Location = New System.Drawing.Point(278, 61)
        Me.rdSudahApproval2.Name = "rdSudahApproval2"
        Me.rdSudahApproval2.Size = New System.Drawing.Size(110, 17)
        Me.rdSudahApproval2.TabIndex = 813
        Me.rdSudahApproval2.Text = "Sudah Approval 2"
        Me.rdSudahApproval2.UseVisualStyleBackColor = True
        '
        'rdSudahApproval3
        '
        Me.rdSudahApproval3.AutoSize = True
        Me.rdSudahApproval3.Location = New System.Drawing.Point(394, 61)
        Me.rdSudahApproval3.Name = "rdSudahApproval3"
        Me.rdSudahApproval3.Size = New System.Drawing.Size(110, 17)
        Me.rdSudahApproval3.TabIndex = 813
        Me.rdSudahApproval3.Text = "Sudah Approval 3"
        Me.rdSudahApproval3.UseVisualStyleBackColor = True
        '
        'FrmMonApproveHargaNego
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSkyBlue
        Me.ClientSize = New System.Drawing.Size(953, 682)
        Me.Controls.Add(Me.rdSudahApproval3)
        Me.Controls.Add(Me.rdSudahApproval2)
        Me.Controls.Add(Me.rdSudahApproval1)
        Me.Controls.Add(Me.rdSudahInputHargaNego)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.chkS_Petani)
        Me.Controls.Add(Me.cmbS_Petani)
        Me.Controls.Add(Me.pnlHead)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblHead)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.DTPEnd)
        Me.Controls.Add(Me.DTPStart)
        Me.Controls.Add(Me.chkTransDate)
        Me.Controls.Add(Me.chkTrip)
        Me.Controls.Add(Me.cmbTrip)
        Me.Controls.Add(Me.cmbKapal)
        Me.Controls.Add(Me.chkKapal)
        Me.Controls.Add(Me.cmbPancang)
        Me.Controls.Add(Me.chkPancang)
        Me.Controls.Add(Me.grpDataTimbangCrane)
        Me.Name = "FrmMonApproveHargaNego"
        Me.Text = "Monitoring Approve Harga Nego"
        Me.grpDataTimbangCrane.ResumeLayout(False)
        Me.grpDataTimbangCrane.PerformLayout()
        CType(Me.fg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grpDataTimbangCrane As XanderUI.XUICustomGroupbox
    Friend WithEvents fg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents schfg As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents btnRefresh As Button
    Friend WithEvents DTPEnd As DateTimePicker
    Friend WithEvents DTPStart As DateTimePicker
    Friend WithEvents chkTransDate As CheckBox
    Friend WithEvents chkTrip As CheckBox
    Friend WithEvents cmbTrip As ComboBox
    Friend WithEvents cmbKapal As ComboBox
    Friend WithEvents chkKapal As CheckBox
    Friend WithEvents cmbPancang As ComboBox
    Friend WithEvents chkPancang As CheckBox
    Friend WithEvents btnClose As Button
    Friend WithEvents pnlHead As Panel
    Friend WithEvents lblHead As Label
    Friend WithEvents chkS_Petani As CheckBox
    Friend WithEvents cmbS_Petani As ComboBox
    Friend WithEvents btnExcel As Button
    Friend WithEvents SaveFileDialog As SaveFileDialog
    Friend WithEvents rdSudahInputHargaNego As RadioButton
    Friend WithEvents rdSudahApproval1 As RadioButton
    Friend WithEvents rdSudahApproval2 As RadioButton
    Friend WithEvents rdSudahApproval3 As RadioButton
End Class
