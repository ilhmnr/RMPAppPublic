Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMonPenerimaanPabrikKelapaBPI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMonPenerimaanPabrikKelapaBPI))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboPancang = New System.Windows.Forms.ComboBox()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.pnlKelapaBulat = New System.Windows.Forms.Panel()
        Me.pnlKelapaBulatDtl = New System.Windows.Forms.Panel()
        Me.pnlKelapaHdrDtl2 = New System.Windows.Forms.Panel()
        Me.fgKBRSUP = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.fgKBPSG = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.fgKBTot = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.pnlCungkilDtl = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.fgKCRSUP = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.fgKCPSG = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.fgKCTot = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.btnExcelKB = New System.Windows.Forms.Button()
        Me.btnExcelKc = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.pnlKelapaBulat.SuspendLayout()
        Me.pnlKelapaBulatDtl.SuspendLayout()
        Me.pnlKelapaHdrDtl2.SuspendLayout()
        CType(Me.fgKBRSUP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fgKBPSG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fgKBTot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.pnlCungkilDtl.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.fgKCRSUP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fgKCPSG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fgKCTot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1212, 40)
        Me.Panel1.TabIndex = 0
        '
        'Panel7
        '
        Me.Panel7.BackgroundImage = CType(resources.GetObject("Panel7.BackgroundImage"), System.Drawing.Image)
        Me.Panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel7.Location = New System.Drawing.Point(10, 3)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(35, 35)
        Me.Panel7.TabIndex = 18
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(46, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(413, 28)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Monitoring Bongkar Pabrik RSUP Dan PSG"
        '
        'cboPancang
        '
        Me.cboPancang.FormattingEnabled = True
        Me.cboPancang.Location = New System.Drawing.Point(62, 59)
        Me.cboPancang.Name = "cboPancang"
        Me.cboPancang.Size = New System.Drawing.Size(260, 21)
        Me.cboPancang.TabIndex = 905707
        '
        'cboStatus
        '
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"Muat", "Close", "Booking Pabrik", "Checkin Pabrik", "Bongkar Pabrik", "Release Pabrik", "Terima Pabrik"})
        Me.cboStatus.Location = New System.Drawing.Point(62, 35)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(260, 21)
        Me.cboStatus.TabIndex = 905707
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 905706
        Me.Label4.Tag = "Status"
        Me.Label4.Text = "Pancang"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(180, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 13)
        Me.Label3.TabIndex = 905706
        Me.Label3.Text = "s/d"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 905706
        Me.Label2.Tag = "Status"
        Me.Label2.Text = "Status"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 905706
        Me.Label1.Text = "Tanggal"
        '
        'txtTotal
        '
        Me.txtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(869, 56)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(147, 23)
        Me.txtTotal.TabIndex = 905705
        Me.txtTotal.Text = "0"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpEnd
        '
        Me.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEnd.Location = New System.Drawing.Point(209, 12)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(113, 20)
        Me.dtpEnd.TabIndex = 905660
        '
        'dtpStart
        '
        Me.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStart.Location = New System.Drawing.Point(62, 12)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(113, 20)
        Me.dtpStart.TabIndex = 905660
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 40)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1212, 608)
        Me.Panel3.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.TabControl1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 94)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(10, 0, 10, 10)
        Me.Panel4.Size = New System.Drawing.Size(1212, 514)
        Me.Panel4.TabIndex = 1
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(10, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1192, 504)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.pnlKelapaBulat)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1184, 478)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Kelapa Bulat"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'pnlKelapaBulat
        '
        Me.pnlKelapaBulat.Controls.Add(Me.pnlKelapaBulatDtl)
        Me.pnlKelapaBulat.Controls.Add(Me.fgKBTot)
        Me.pnlKelapaBulat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlKelapaBulat.Location = New System.Drawing.Point(3, 3)
        Me.pnlKelapaBulat.Name = "pnlKelapaBulat"
        Me.pnlKelapaBulat.Size = New System.Drawing.Size(1178, 472)
        Me.pnlKelapaBulat.TabIndex = 0
        '
        'pnlKelapaBulatDtl
        '
        Me.pnlKelapaBulatDtl.Controls.Add(Me.pnlKelapaHdrDtl2)
        Me.pnlKelapaBulatDtl.Controls.Add(Me.fgKBPSG)
        Me.pnlKelapaBulatDtl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlKelapaBulatDtl.Location = New System.Drawing.Point(0, 116)
        Me.pnlKelapaBulatDtl.Name = "pnlKelapaBulatDtl"
        Me.pnlKelapaBulatDtl.Padding = New System.Windows.Forms.Padding(0, 15, 0, 0)
        Me.pnlKelapaBulatDtl.Size = New System.Drawing.Size(1178, 356)
        Me.pnlKelapaBulatDtl.TabIndex = 3
        '
        'pnlKelapaHdrDtl2
        '
        Me.pnlKelapaHdrDtl2.Controls.Add(Me.fgKBRSUP)
        Me.pnlKelapaHdrDtl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlKelapaHdrDtl2.Location = New System.Drawing.Point(0, 197)
        Me.pnlKelapaHdrDtl2.Name = "pnlKelapaHdrDtl2"
        Me.pnlKelapaHdrDtl2.Padding = New System.Windows.Forms.Padding(0, 15, 0, 0)
        Me.pnlKelapaHdrDtl2.Size = New System.Drawing.Size(1178, 159)
        Me.pnlKelapaHdrDtl2.TabIndex = 1
        '
        'fgKBRSUP
        '
        Me.fgKBRSUP.ColumnInfo = resources.GetString("fgKBRSUP.ColumnInfo")
        Me.fgKBRSUP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgKBRSUP.Location = New System.Drawing.Point(0, 15)
        Me.fgKBRSUP.Name = "fgKBRSUP"
        Me.fgKBRSUP.Rows.Fixed = 2
        Me.fgKBRSUP.Size = New System.Drawing.Size(1178, 144)
        Me.fgKBRSUP.TabIndex = 2
        '
        'fgKBPSG
        '
        Me.fgKBPSG.ColumnInfo = resources.GetString("fgKBPSG.ColumnInfo")
        Me.fgKBPSG.Dock = System.Windows.Forms.DockStyle.Top
        Me.fgKBPSG.Location = New System.Drawing.Point(0, 15)
        Me.fgKBPSG.Name = "fgKBPSG"
        Me.fgKBPSG.Rows.Fixed = 2
        Me.fgKBPSG.Size = New System.Drawing.Size(1178, 182)
        Me.fgKBPSG.TabIndex = 0
        '
        'fgKBTot
        '
        Me.fgKBTot.ColumnInfo = resources.GetString("fgKBTot.ColumnInfo")
        Me.fgKBTot.Dock = System.Windows.Forms.DockStyle.Top
        Me.fgKBTot.Location = New System.Drawing.Point(0, 0)
        Me.fgKBTot.Name = "fgKBTot"
        Me.fgKBTot.Rows.Fixed = 3
        Me.fgKBTot.Size = New System.Drawing.Size(1178, 116)
        Me.fgKBTot.TabIndex = 2
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Panel5)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1184, 478)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Cungkil"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.pnlCungkilDtl)
        Me.Panel5.Controls.Add(Me.fgKCTot)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(3, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1178, 472)
        Me.Panel5.TabIndex = 1
        '
        'pnlCungkilDtl
        '
        Me.pnlCungkilDtl.Controls.Add(Me.Panel6)
        Me.pnlCungkilDtl.Controls.Add(Me.fgKCPSG)
        Me.pnlCungkilDtl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCungkilDtl.Location = New System.Drawing.Point(0, 116)
        Me.pnlCungkilDtl.Name = "pnlCungkilDtl"
        Me.pnlCungkilDtl.Padding = New System.Windows.Forms.Padding(0, 15, 0, 0)
        Me.pnlCungkilDtl.Size = New System.Drawing.Size(1178, 356)
        Me.pnlCungkilDtl.TabIndex = 3
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.fgKCRSUP)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(0, 197)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Padding = New System.Windows.Forms.Padding(0, 15, 0, 0)
        Me.Panel6.Size = New System.Drawing.Size(1178, 159)
        Me.Panel6.TabIndex = 1
        '
        'fgKCRSUP
        '
        Me.fgKCRSUP.ColumnInfo = resources.GetString("fgKCRSUP.ColumnInfo")
        Me.fgKCRSUP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgKCRSUP.Location = New System.Drawing.Point(0, 15)
        Me.fgKCRSUP.Name = "fgKCRSUP"
        Me.fgKCRSUP.Rows.Fixed = 2
        Me.fgKCRSUP.Size = New System.Drawing.Size(1178, 144)
        Me.fgKCRSUP.TabIndex = 1
        '
        'fgKCPSG
        '
        Me.fgKCPSG.ColumnInfo = resources.GetString("fgKCPSG.ColumnInfo")
        Me.fgKCPSG.Dock = System.Windows.Forms.DockStyle.Top
        Me.fgKCPSG.Location = New System.Drawing.Point(0, 15)
        Me.fgKCPSG.Name = "fgKCPSG"
        Me.fgKCPSG.Rows.Fixed = 2
        Me.fgKCPSG.Size = New System.Drawing.Size(1178, 182)
        Me.fgKCPSG.TabIndex = 0
        '
        'fgKCTot
        '
        Me.fgKCTot.ColumnInfo = resources.GetString("fgKCTot.ColumnInfo")
        Me.fgKCTot.Dock = System.Windows.Forms.DockStyle.Top
        Me.fgKCTot.Location = New System.Drawing.Point(0, 0)
        Me.fgKCTot.Name = "fgKCTot"
        Me.fgKCTot.Rows.Fixed = 3
        Me.fgKCTot.Size = New System.Drawing.Size(1178, 116)
        Me.fgKCTot.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel8)
        Me.Panel2.Controls.Add(Me.btnExcelKB)
        Me.Panel2.Controls.Add(Me.btnExcelKc)
        Me.Panel2.Controls.Add(Me.btnClose)
        Me.Panel2.Controls.Add(Me.btnSearch)
        Me.Panel2.Controls.Add(Me.cboPancang)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.cboStatus)
        Me.Panel2.Controls.Add(Me.dtpStart)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.dtpEnd)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtTotal)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1212, 94)
        Me.Panel2.TabIndex = 0
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Black
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(1212, 1)
        Me.Panel8.TabIndex = 905748
        '
        'btnExcelKB
        '
        Me.btnExcelKB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExcelKB.BackColor = System.Drawing.Color.White
        Me.btnExcelKB.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcelKB.Image = CType(resources.GetObject("btnExcelKB.Image"), System.Drawing.Image)
        Me.btnExcelKB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcelKB.Location = New System.Drawing.Point(1022, 20)
        Me.btnExcelKB.Name = "btnExcelKB"
        Me.btnExcelKB.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnExcelKB.Size = New System.Drawing.Size(180, 30)
        Me.btnExcelKB.TabIndex = 905747
        Me.btnExcelKB.Text = "Convert Excel Kelapa Bulat"
        Me.btnExcelKB.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcelKB.UseVisualStyleBackColor = False
        '
        'btnExcelKc
        '
        Me.btnExcelKc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExcelKc.BackColor = System.Drawing.Color.White
        Me.btnExcelKc.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcelKc.Image = CType(resources.GetObject("btnExcelKc.Image"), System.Drawing.Image)
        Me.btnExcelKc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcelKc.Location = New System.Drawing.Point(1022, 52)
        Me.btnExcelKc.Name = "btnExcelKc"
        Me.btnExcelKc.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnExcelKc.Size = New System.Drawing.Size(180, 30)
        Me.btnExcelKc.TabIndex = 905746
        Me.btnExcelKc.Text = "Convert Excel Cungkil"
        Me.btnExcelKc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcelKc.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.White
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(409, 52)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnClose.Size = New System.Drawing.Size(75, 30)
        Me.btnClose.TabIndex = 905745
        Me.btnClose.Text = "Exit"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.White
        Me.btnSearch.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(328, 52)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.btnSearch.Size = New System.Drawing.Size(75, 30)
        Me.btnSearch.TabIndex = 905744
        Me.btnSearch.Text = "Refresh"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'FrmMonPenerimaanPabrikKelapaBPI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1212, 648)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmMonPenerimaanPabrikKelapaBPI"
        Me.Text = "Monitoring Bongkar Pabrik RSUP Dan PSG"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.pnlKelapaBulat.ResumeLayout(False)
        Me.pnlKelapaBulatDtl.ResumeLayout(False)
        Me.pnlKelapaHdrDtl2.ResumeLayout(False)
        CType(Me.fgKBRSUP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fgKBPSG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fgKBTot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.pnlCungkilDtl.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        CType(Me.fgKCRSUP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fgKCPSG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fgKCTot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents dtpStart As DateTimePicker
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents dtpEnd As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cboPancang As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents pnlKelapaBulat As Panel
    Friend WithEvents pnlKelapaBulatDtl As Panel
    Friend WithEvents pnlKelapaHdrDtl2 As Panel
    Friend WithEvents fgKBRSUP As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents fgKBPSG As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents fgKBTot As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Panel5 As Panel
    Friend WithEvents pnlCungkilDtl As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents fgKCRSUP As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents fgKCPSG As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents fgKCTot As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents btnExcelKB As Button
    Friend WithEvents btnExcelKc As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel8 As Panel
End Class
