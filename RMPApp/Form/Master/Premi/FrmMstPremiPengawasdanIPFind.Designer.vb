<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMstPremiPengawasdanIPFind
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.btnCari = New System.Windows.Forms.Button()
        Me.dtTanggal2 = New System.Windows.Forms.DateTimePicker()
        Me.dtTanggal1 = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.dgvfind = New System.Windows.Forms.DataGridView()
        Me.HeaderID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoTrans = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Periode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Batas_KB_B = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Batas_Susut_KB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Grade_KB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Grade_KB_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Maksimal_KBB_Pengawas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Max_Susut_Kg_Pengawas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Vol_KB_Pcg_Pengawas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Maksimal_KBB_Inspektor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Max_Susut_Kg_Inspektor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Vol_KB_Pcg_Inspektor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreatedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreatedDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LastUpdatedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LastUpdatedDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvfind, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnKeluar
        '
        Me.btnKeluar.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnKeluar.BackColor = System.Drawing.Color.SteelBlue
        Me.btnKeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnKeluar.ForeColor = System.Drawing.Color.White
        Me.btnKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKeluar.Location = New System.Drawing.Point(505, 16)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(81, 27)
        Me.btnKeluar.TabIndex = 588
        Me.btnKeluar.Text = "Keluar"
        Me.btnKeluar.UseVisualStyleBackColor = False
        '
        'btnCari
        '
        Me.btnCari.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnCari.BackColor = System.Drawing.Color.SteelBlue
        Me.btnCari.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCari.ForeColor = System.Drawing.Color.White
        Me.btnCari.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCari.Location = New System.Drawing.Point(418, 16)
        Me.btnCari.Name = "btnCari"
        Me.btnCari.Size = New System.Drawing.Size(81, 27)
        Me.btnCari.TabIndex = 587
        Me.btnCari.Text = "Cari Data"
        Me.btnCari.UseVisualStyleBackColor = False
        '
        'dtTanggal2
        '
        Me.dtTanggal2.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtTanggal2.Location = New System.Drawing.Point(258, 18)
        Me.dtTanggal2.Name = "dtTanggal2"
        Me.dtTanggal2.Size = New System.Drawing.Size(144, 23)
        Me.dtTanggal2.TabIndex = 583
        '
        'dtTanggal1
        '
        Me.dtTanggal1.CalendarFont = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtTanggal1.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtTanggal1.Location = New System.Drawing.Point(72, 18)
        Me.dtTanggal1.Name = "dtTanggal1"
        Me.dtTanggal1.Size = New System.Drawing.Size(146, 23)
        Me.dtTanggal1.TabIndex = 582
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(224, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 15)
        Me.Label3.TabIndex = 580
        Me.Label3.Text = "s/d"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 15)
        Me.Label2.TabIndex = 579
        Me.Label2.Text = "Tanggal"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnKeluar)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnCari)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dtTanggal2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dtTanggal1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvfind)
        Me.SplitContainer1.Size = New System.Drawing.Size(1549, 665)
        Me.SplitContainer1.SplitterDistance = 59
        Me.SplitContainer1.TabIndex = 5
        '
        'dgvfind
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Modern No. 20", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Magenta
        Me.dgvfind.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvfind.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.dgvfind.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Magenta
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvfind.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvfind.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvfind.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.HeaderID, Me.NoTrans, Me.Periode, Me.Batas_KB_B, Me.Batas_Susut_KB, Me.Grade_KB, Me.Grade_KB_ID, Me.Maksimal_KBB_Pengawas, Me.Max_Susut_Kg_Pengawas, Me.Vol_KB_Pcg_Pengawas, Me.Maksimal_KBB_Inspektor, Me.Max_Susut_Kg_Inspektor, Me.Vol_KB_Pcg_Inspektor, Me.CreatedBy, Me.CreatedDate, Me.LastUpdatedBy, Me.LastUpdatedDate})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Modern No. 20", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Magenta
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvfind.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvfind.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvfind.EnableHeadersVisualStyles = False
        Me.dgvfind.GridColor = System.Drawing.Color.Black
        Me.dgvfind.Location = New System.Drawing.Point(0, 0)
        Me.dgvfind.Name = "dgvfind"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Magenta
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvfind.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvfind.RowHeadersVisible = False
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Magenta
        Me.dgvfind.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvfind.Size = New System.Drawing.Size(1549, 602)
        Me.dgvfind.TabIndex = 41
        '
        'HeaderID
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Magenta
        Me.HeaderID.DefaultCellStyle = DataGridViewCellStyle3
        Me.HeaderID.HeaderText = "HeaderID"
        Me.HeaderID.Name = "HeaderID"
        Me.HeaderID.Width = 110
        '
        'NoTrans
        '
        Me.NoTrans.HeaderText = "NoTrans"
        Me.NoTrans.Name = "NoTrans"
        '
        'Periode
        '
        Me.Periode.HeaderText = "Periode"
        Me.Periode.Name = "Periode"
        '
        'Batas_KB_B
        '
        Me.Batas_KB_B.HeaderText = "Batas_KB_B"
        Me.Batas_KB_B.Name = "Batas_KB_B"
        '
        'Batas_Susut_KB
        '
        Me.Batas_Susut_KB.HeaderText = "Batas_Susut_KB"
        Me.Batas_Susut_KB.Name = "Batas_Susut_KB"
        '
        'Grade_KB
        '
        Me.Grade_KB.HeaderText = "Grade_KB"
        Me.Grade_KB.Name = "Grade_KB"
        '
        'Grade_KB_ID
        '
        Me.Grade_KB_ID.HeaderText = "Grade_KB_ID"
        Me.Grade_KB_ID.Name = "Grade_KB_ID"
        '
        'Maksimal_KBB_Pengawas
        '
        Me.Maksimal_KBB_Pengawas.HeaderText = "Maksimal_KBB_Pengawas"
        Me.Maksimal_KBB_Pengawas.Name = "Maksimal_KBB_Pengawas"
        '
        'Max_Susut_Kg_Pengawas
        '
        Me.Max_Susut_Kg_Pengawas.HeaderText = "Max_Susut_Kg_Pengawas"
        Me.Max_Susut_Kg_Pengawas.Name = "Max_Susut_Kg_Pengawas"
        '
        'Vol_KB_Pcg_Pengawas
        '
        Me.Vol_KB_Pcg_Pengawas.HeaderText = "Vol_KB_Pcg_Pengawas"
        Me.Vol_KB_Pcg_Pengawas.Name = "Vol_KB_Pcg_Pengawas"
        '
        'Maksimal_KBB_Inspektor
        '
        Me.Maksimal_KBB_Inspektor.HeaderText = "Maksimal_KBB_Inspektor"
        Me.Maksimal_KBB_Inspektor.Name = "Maksimal_KBB_Inspektor"
        '
        'Max_Susut_Kg_Inspektor
        '
        Me.Max_Susut_Kg_Inspektor.HeaderText = "Max_Susut_Kg_Inspektor"
        Me.Max_Susut_Kg_Inspektor.Name = "Max_Susut_Kg_Inspektor"
        '
        'Vol_KB_Pcg_Inspektor
        '
        Me.Vol_KB_Pcg_Inspektor.HeaderText = "Vol_KB_Pcg_Inspektor"
        Me.Vol_KB_Pcg_Inspektor.Name = "Vol_KB_Pcg_Inspektor"
        '
        'CreatedBy
        '
        Me.CreatedBy.HeaderText = "CreatedBy"
        Me.CreatedBy.Name = "CreatedBy"
        '
        'CreatedDate
        '
        Me.CreatedDate.HeaderText = "CreatedDate"
        Me.CreatedDate.Name = "CreatedDate"
        '
        'LastUpdatedBy
        '
        Me.LastUpdatedBy.HeaderText = "LastUpdatedBy"
        Me.LastUpdatedBy.Name = "LastUpdatedBy"
        '
        'LastUpdatedDate
        '
        Me.LastUpdatedDate.HeaderText = "LastUpdatedDate"
        Me.LastUpdatedDate.Name = "LastUpdatedDate"
        '
        'FrmMasterPremiPengawasdanIPFind
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1549, 665)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmMasterPremiPengawasdanIPFind"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmMasterPremiPengawasdanIPFind"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvfind, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnKeluar As Button
    Friend WithEvents btnCari As Button
    Friend WithEvents dtTanggal2 As DateTimePicker
    Friend WithEvents dtTanggal1 As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents dgvfind As DataGridView
    Friend WithEvents HeaderID As DataGridViewTextBoxColumn
    Friend WithEvents NoTrans As DataGridViewTextBoxColumn
    Friend WithEvents Periode As DataGridViewTextBoxColumn
    Friend WithEvents Batas_KB_B As DataGridViewTextBoxColumn
    Friend WithEvents Batas_Susut_KB As DataGridViewTextBoxColumn
    Friend WithEvents Grade_KB As DataGridViewTextBoxColumn
    Friend WithEvents Grade_KB_ID As DataGridViewTextBoxColumn
    Friend WithEvents Maksimal_KBB_Pengawas As DataGridViewTextBoxColumn
    Friend WithEvents Max_Susut_Kg_Pengawas As DataGridViewTextBoxColumn
    Friend WithEvents Vol_KB_Pcg_Pengawas As DataGridViewTextBoxColumn
    Friend WithEvents Maksimal_KBB_Inspektor As DataGridViewTextBoxColumn
    Friend WithEvents Max_Susut_Kg_Inspektor As DataGridViewTextBoxColumn
    Friend WithEvents Vol_KB_Pcg_Inspektor As DataGridViewTextBoxColumn
    Friend WithEvents CreatedBy As DataGridViewTextBoxColumn
    Friend WithEvents CreatedDate As DataGridViewTextBoxColumn
    Friend WithEvents LastUpdatedBy As DataGridViewTextBoxColumn
    Friend WithEvents LastUpdatedDate As DataGridViewTextBoxColumn
End Class
