<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FORMUNTUKINPUTLOYALTYCONTOH
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvList = New System.Windows.Forms.DataGridView()
        Me.dtp2 = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.btnLoaddata = New System.Windows.Forms.Button()
        Me.NONOTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TRANSDATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JENISKELAPA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PENERIMAID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SUBPETANIID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PANCANG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TARRAPERSEN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BeratNettoAkhir = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvList
        '
        Me.dgvList.AllowUserToAddRows = False
        Me.dgvList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvList.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(244, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NONOTA, Me.TRANSDATE, Me.JENISKELAPA, Me.PENERIMAID, Me.SUBPETANIID, Me.PANCANG, Me.TARRAPERSEN, Me.BeratNettoAkhir})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvList.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvList.EnableHeadersVisualStyles = False
        Me.dgvList.Location = New System.Drawing.Point(27, 103)
        Me.dgvList.Name = "dgvList"
        Me.dgvList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Honeydew
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvList.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvList.RowHeadersVisible = False
        Me.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvList.Size = New System.Drawing.Size(1007, 433)
        Me.dgvList.TabIndex = 430
        '
        'dtp2
        '
        Me.dtp2.CustomFormat = "dd MMM yyyy"
        Me.dtp2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp2.Location = New System.Drawing.Point(375, 50)
        Me.dtp2.Name = "dtp2"
        Me.dtp2.Size = New System.Drawing.Size(153, 23)
        Me.dtp2.TabIndex = 433
        Me.dtp2.Value = New Date(2019, 4, 8, 0, 0, 0, 0)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(76, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 17)
        Me.Label6.TabIndex = 432
        Me.Label6.Text = "Date"
        '
        'dtp1
        '
        Me.dtp1.CustomFormat = "dd MMM yyyy"
        Me.dtp1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp1.Location = New System.Drawing.Point(192, 50)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(153, 23)
        Me.dtp1.TabIndex = 431
        Me.dtp1.Value = New Date(2019, 4, 8, 0, 0, 0, 0)
        '
        'btnsave
        '
        Me.btnsave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnsave.BackColor = System.Drawing.Color.AliceBlue
        Me.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsave.Font = New System.Drawing.Font("Gabriola", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsave.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.btnsave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnsave.Location = New System.Drawing.Point(932, 557)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(75, 35)
        Me.btnsave.TabIndex = 434
        Me.btnsave.Text = "&Save"
        Me.btnsave.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnsave.UseVisualStyleBackColor = False
        '
        'btnLoaddata
        '
        Me.btnLoaddata.BackColor = System.Drawing.Color.White
        Me.btnLoaddata.BackgroundImage = Global.RMPApp.My.Resources.Resources.find20
        Me.btnLoaddata.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLoaddata.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLoaddata.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.btnLoaddata.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.btnLoaddata.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.btnLoaddata.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoaddata.Location = New System.Drawing.Point(534, 50)
        Me.btnLoaddata.Name = "btnLoaddata"
        Me.btnLoaddata.Size = New System.Drawing.Size(23, 23)
        Me.btnLoaddata.TabIndex = 435
        Me.btnLoaddata.UseVisualStyleBackColor = False
        '
        'NONOTA
        '
        Me.NONOTA.HeaderText = "NONOTA"
        Me.NONOTA.Name = "NONOTA"
        '
        'TRANSDATE
        '
        Me.TRANSDATE.HeaderText = "TRANSDATE"
        Me.TRANSDATE.Name = "TRANSDATE"
        '
        'JENISKELAPA
        '
        Me.JENISKELAPA.HeaderText = "JENISKELAPA"
        Me.JENISKELAPA.Name = "JENISKELAPA"
        '
        'PENERIMAID
        '
        Me.PENERIMAID.HeaderText = "PENERIMAID"
        Me.PENERIMAID.Name = "PENERIMAID"
        '
        'SUBPETANIID
        '
        Me.SUBPETANIID.HeaderText = "SUBPETANIID"
        Me.SUBPETANIID.Name = "SUBPETANIID"
        '
        'PANCANG
        '
        Me.PANCANG.HeaderText = "PANCANG"
        Me.PANCANG.Name = "PANCANG"
        '
        'TARRAPERSEN
        '
        Me.TARRAPERSEN.HeaderText = "TARRAPERSEN"
        Me.TARRAPERSEN.Name = "TARRAPERSEN"
        '
        'BeratNettoAkhir
        '
        Me.BeratNettoAkhir.HeaderText = "BeratNettoAkhir"
        Me.BeratNettoAkhir.Name = "BeratNettoAkhir"
        '
        'Timer1
        '
        Me.Timer1.Interval = 3000
        '
        'FORMUNTUKINPUTLOYALTYCONTOH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1046, 642)
        Me.Controls.Add(Me.btnLoaddata)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.dtp2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dtp1)
        Me.Controls.Add(Me.dgvList)
        Me.Name = "FORMUNTUKINPUTLOYALTYCONTOH"
        Me.Text = "FORMUNTUKINPUTLOYALTYCONTOH"
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvList As DataGridView
    Friend WithEvents dtp2 As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents dtp1 As DateTimePicker
    Friend WithEvents btnsave As Button
    Friend WithEvents btnLoaddata As Button
    Friend WithEvents NONOTA As DataGridViewTextBoxColumn
    Friend WithEvents TRANSDATE As DataGridViewTextBoxColumn
    Friend WithEvents JENISKELAPA As DataGridViewTextBoxColumn
    Friend WithEvents PENERIMAID As DataGridViewTextBoxColumn
    Friend WithEvents SUBPETANIID As DataGridViewTextBoxColumn
    Friend WithEvents PANCANG As DataGridViewTextBoxColumn
    Friend WithEvents TARRAPERSEN As DataGridViewTextBoxColumn
    Friend WithEvents BeratNettoAkhir As DataGridViewTextBoxColumn
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer2 As Timer
End Class
