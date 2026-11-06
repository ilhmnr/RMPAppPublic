<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMonRelasiLoyal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMonRelasiLoyal))
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.grpFilterData = New XanderUI.XUICustomGroupbox()
        Me.btnkalkulasi = New System.Windows.Forms.Button()
        Me.DOYear = New System.Windows.Forms.DateTimePicker()
        Me.chkYear = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.XuiCustomGroupbox1 = New XanderUI.XUICustomGroupbox()
        Me.schfgKg = New C1.Win.C1FlexGrid.C1FlexGridSearchPanel()
        Me.fgKg = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.grpFilterData.SuspendLayout()
        Me.XuiCustomGroupbox1.SuspendLayout()
        CType(Me.fgKg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpFilterData
        '
        Me.grpFilterData.BorderColor = System.Drawing.Color.DodgerBlue
        Me.grpFilterData.BorderWidth = 1
        Me.grpFilterData.Controls.Add(Me.btnkalkulasi)
        Me.grpFilterData.Controls.Add(Me.DOYear)
        Me.grpFilterData.Controls.Add(Me.chkYear)
        Me.grpFilterData.Controls.Add(Me.Label9)
        Me.grpFilterData.Controls.Add(Me.btnExcel)
        Me.grpFilterData.Controls.Add(Me.btnRefresh)
        Me.grpFilterData.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpFilterData.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpFilterData.Location = New System.Drawing.Point(0, 0)
        Me.grpFilterData.Name = "grpFilterData"
        Me.grpFilterData.ShowText = True
        Me.grpFilterData.Size = New System.Drawing.Size(930, 54)
        Me.grpFilterData.TabIndex = 11
        Me.grpFilterData.TabStop = False
        Me.grpFilterData.Text = "Filter Data"
        Me.grpFilterData.TextColor = System.Drawing.Color.Navy
        '
        'btnkalkulasi
        '
        Me.btnkalkulasi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnkalkulasi.BackColor = System.Drawing.Color.DimGray
        Me.btnkalkulasi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnkalkulasi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnkalkulasi.ForeColor = System.Drawing.Color.White
        Me.btnkalkulasi.Location = New System.Drawing.Point(650, 18)
        Me.btnkalkulasi.Name = "btnkalkulasi"
        Me.btnkalkulasi.Size = New System.Drawing.Size(84, 30)
        Me.btnkalkulasi.TabIndex = 247
        Me.btnkalkulasi.Text = "Kalkulasi"
        Me.btnkalkulasi.UseVisualStyleBackColor = False
        '
        'DOYear
        '
        Me.DOYear.CustomFormat = "yyyy"
        Me.DOYear.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DOYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DOYear.Location = New System.Drawing.Point(92, 20)
        Me.DOYear.Name = "DOYear"
        Me.DOYear.Size = New System.Drawing.Size(55, 23)
        Me.DOYear.TabIndex = 241
        Me.DOYear.Value = New Date(2022, 1, 1, 0, 0, 0, 0)
        '
        'chkYear
        '
        Me.chkYear.AutoSize = True
        Me.chkYear.FlatAppearance.BorderSize = 0
        Me.chkYear.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkYear.Location = New System.Drawing.Point(14, 22)
        Me.chkYear.Name = "chkYear"
        Me.chkYear.Size = New System.Drawing.Size(55, 21)
        Me.chkYear.TabIndex = 239
        Me.chkYear.Tag = "1"
        Me.chkYear.Text = "Year"
        Me.chkYear.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(69, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(11, 17)
        Me.Label9.TabIndex = 238
        Me.Label9.Text = ":"
        '
        'btnExcel
        '
        Me.btnExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExcel.BackColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExcel.FlatAppearance.BorderSize = 0
        Me.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnExcel.Location = New System.Drawing.Point(827, 19)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(95, 28)
        Me.btnExcel.TabIndex = 223
        Me.btnExcel.Text = "Excel"
        Me.btnExcel.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnRefresh.Location = New System.Drawing.Point(735, 19)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(90, 28)
        Me.btnRefresh.TabIndex = 222
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'XuiCustomGroupbox1
        '
        Me.XuiCustomGroupbox1.BackColor = System.Drawing.Color.White
        Me.XuiCustomGroupbox1.BorderColor = System.Drawing.Color.DodgerBlue
        Me.XuiCustomGroupbox1.BorderWidth = 1
        Me.XuiCustomGroupbox1.Controls.Add(Me.schfgKg)
        Me.XuiCustomGroupbox1.Controls.Add(Me.fgKg)
        Me.XuiCustomGroupbox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XuiCustomGroupbox1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XuiCustomGroupbox1.Location = New System.Drawing.Point(0, 54)
        Me.XuiCustomGroupbox1.Name = "XuiCustomGroupbox1"
        Me.XuiCustomGroupbox1.ShowText = True
        Me.XuiCustomGroupbox1.Size = New System.Drawing.Size(930, 408)
        Me.XuiCustomGroupbox1.TabIndex = 177
        Me.XuiCustomGroupbox1.TabStop = False
        Me.XuiCustomGroupbox1.Text = "PCG"
        Me.XuiCustomGroupbox1.TextColor = System.Drawing.Color.Navy
        '
        'schfgKg
        '
        Me.schfgKg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.schfgKg.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.schfgKg.Location = New System.Drawing.Point(492, -15)
        Me.schfgKg.Margin = New System.Windows.Forms.Padding(1)
        Me.schfgKg.Name = "schfgKg"
        Me.schfgKg.ShowClearButton = False
        Me.schfgKg.ShowSearchButton = False
        Me.schfgKg.Size = New System.Drawing.Size(456, 32)
        Me.schfgKg.TabIndex = 223
        '
        'fgKg
        '
        Me.fgKg.AllowEditing = False
        Me.fgKg.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.fgKg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fgKg.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.fgKg.ColumnInfo = resources.GetString("fgKg.ColumnInfo")
        Me.fgKg.ForeColor = System.Drawing.Color.Black
        Me.fgKg.Location = New System.Drawing.Point(6, 22)
        Me.fgKg.Name = "fgKg"
        Me.fgKg.Rows.Count = 5
        Me.fgKg.Rows.DefaultSize = 22
        Me.fgKg.Size = New System.Drawing.Size(918, 380)
        Me.fgKg.StyleInfo = resources.GetString("fgKg.StyleInfo")
        Me.fgKg.TabIndex = 7
        '
        'FrmMonRelasiLoyal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(930, 462)
        Me.Controls.Add(Me.XuiCustomGroupbox1)
        Me.Controls.Add(Me.grpFilterData)
        Me.Name = "FrmMonRelasiLoyal"
        Me.Text = "FrmRelasiLoyal"
        Me.grpFilterData.ResumeLayout(False)
        Me.grpFilterData.PerformLayout()
        Me.XuiCustomGroupbox1.ResumeLayout(False)
        Me.XuiCustomGroupbox1.PerformLayout()
        CType(Me.fgKg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SaveFileDialog As SaveFileDialog
    Friend WithEvents grpFilterData As XanderUI.XUICustomGroupbox
    Friend WithEvents DOYear As DateTimePicker
    Friend WithEvents chkYear As CheckBox
    Friend WithEvents Label9 As Label
    Friend WithEvents btnExcel As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents XuiCustomGroupbox1 As XanderUI.XUICustomGroupbox
    Friend WithEvents schfgKg As C1.Win.C1FlexGrid.C1FlexGridSearchPanel
    Friend WithEvents fgKg As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents btnkalkulasi As Button
End Class
