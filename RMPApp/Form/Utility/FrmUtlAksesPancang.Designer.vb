Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmUtlAksesPancang
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUtlAksesPancang))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.fgPancang = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.TxtCariPancang = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.fgGroup = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnCancelGroup = New System.Windows.Forms.Button()
        Me.btnSaveGroup = New System.Windows.Forms.Button()
        Me.btnDeleteGroup = New System.Windows.Forms.Button()
        Me.btnEditGroup = New System.Windows.Forms.Button()
        Me.btnAddGroup = New System.Windows.Forms.Button()
        Me.TxtNamaGroup = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtCariUser = New System.Windows.Forms.TextBox()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.fgUser = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel10.SuspendLayout()
        CType(Me.fgPancang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel9.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.fgGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.Panel11.SuspendLayout()
        CType(Me.fgUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Panel13)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1017, 40)
        Me.Panel1.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(50, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(152, 28)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Akses Pancang"
        '
        'Panel13
        '
        Me.Panel13.BackgroundImage = CType(resources.GetObject("Panel13.BackgroundImage"), System.Drawing.Image)
        Me.Panel13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel13.Location = New System.Drawing.Point(14, 3)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(35, 35)
        Me.Panel13.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 40)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1017, 589)
        Me.Panel2.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Panel12)
        Me.Panel4.Controls.Add(Me.Panel11)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(561, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel4.Size = New System.Drawing.Size(456, 589)
        Me.Panel4.TabIndex = 0
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.fgUser)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel12.Location = New System.Drawing.Point(10, 50)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(434, 527)
        Me.Panel12.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel6)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(561, 589)
        Me.Panel3.TabIndex = 0
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.White
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.Panel10)
        Me.Panel6.Controls.Add(Me.Panel9)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(0, 312)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel6.Size = New System.Drawing.Size(561, 277)
        Me.Panel6.TabIndex = 0
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.fgPancang)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel10.Location = New System.Drawing.Point(10, 50)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(539, 215)
        Me.Panel10.TabIndex = 0
        '
        'fgPancang
        '
        Me.fgPancang.ColumnInfo = "10,1,0,0,0,-1,Columns:"
        Me.fgPancang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgPancang.Location = New System.Drawing.Point(0, 0)
        Me.fgPancang.Name = "fgPancang"
        Me.fgPancang.Size = New System.Drawing.Size(539, 215)
        Me.fgPancang.TabIndex = 1
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.TxtCariPancang)
        Me.Panel9.Controls.Add(Me.Label1)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(10, 10)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(539, 40)
        Me.Panel9.TabIndex = 0
        '
        'TxtCariPancang
        '
        Me.TxtCariPancang.Location = New System.Drawing.Point(82, 10)
        Me.TxtCariPancang.Name = "TxtCariPancang"
        Me.TxtCariPancang.Size = New System.Drawing.Size(175, 22)
        Me.TxtCariPancang.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Cari Pancang"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.White
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Panel8)
        Me.Panel5.Controls.Add(Me.Panel7)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel5.Size = New System.Drawing.Size(561, 312)
        Me.Panel5.TabIndex = 0
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.fgGroup)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(10, 80)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(539, 220)
        Me.Panel8.TabIndex = 0
        '
        'fgGroup
        '
        Me.fgGroup.ColumnInfo = "10,1,0,0,0,-1,Columns:"
        Me.fgGroup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgGroup.Location = New System.Drawing.Point(0, 0)
        Me.fgGroup.Name = "fgGroup"
        Me.fgGroup.Size = New System.Drawing.Size(539, 220)
        Me.fgGroup.TabIndex = 2
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.btnExit)
        Me.Panel7.Controls.Add(Me.btnCancelGroup)
        Me.Panel7.Controls.Add(Me.btnSaveGroup)
        Me.Panel7.Controls.Add(Me.btnDeleteGroup)
        Me.Panel7.Controls.Add(Me.btnEditGroup)
        Me.Panel7.Controls.Add(Me.btnAddGroup)
        Me.Panel7.Controls.Add(Me.TxtNamaGroup)
        Me.Panel7.Controls.Add(Me.Label2)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(10, 10)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(539, 70)
        Me.Panel7.TabIndex = 0
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.White
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExit.Location = New System.Drawing.Point(387, 33)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnExit.Size = New System.Drawing.Size(75, 30)
        Me.btnExit.TabIndex = 11
        Me.btnExit.Text = "Exit"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnCancelGroup
        '
        Me.btnCancelGroup.BackColor = System.Drawing.Color.White
        Me.btnCancelGroup.Image = CType(resources.GetObject("btnCancelGroup.Image"), System.Drawing.Image)
        Me.btnCancelGroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelGroup.Location = New System.Drawing.Point(311, 33)
        Me.btnCancelGroup.Name = "btnCancelGroup"
        Me.btnCancelGroup.Padding = New System.Windows.Forms.Padding(5, 0, 3, 0)
        Me.btnCancelGroup.Size = New System.Drawing.Size(75, 30)
        Me.btnCancelGroup.TabIndex = 10
        Me.btnCancelGroup.Text = "Cancel"
        Me.btnCancelGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelGroup.UseVisualStyleBackColor = False
        '
        'btnSaveGroup
        '
        Me.btnSaveGroup.BackColor = System.Drawing.Color.White
        Me.btnSaveGroup.Image = CType(resources.GetObject("btnSaveGroup.Image"), System.Drawing.Image)
        Me.btnSaveGroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveGroup.Location = New System.Drawing.Point(235, 33)
        Me.btnSaveGroup.Name = "btnSaveGroup"
        Me.btnSaveGroup.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnSaveGroup.Size = New System.Drawing.Size(75, 30)
        Me.btnSaveGroup.TabIndex = 9
        Me.btnSaveGroup.Text = "Save"
        Me.btnSaveGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSaveGroup.UseVisualStyleBackColor = False
        '
        'btnDeleteGroup
        '
        Me.btnDeleteGroup.BackColor = System.Drawing.Color.White
        Me.btnDeleteGroup.Image = CType(resources.GetObject("btnDeleteGroup.Image"), System.Drawing.Image)
        Me.btnDeleteGroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDeleteGroup.Location = New System.Drawing.Point(159, 33)
        Me.btnDeleteGroup.Name = "btnDeleteGroup"
        Me.btnDeleteGroup.Padding = New System.Windows.Forms.Padding(5, 0, 3, 0)
        Me.btnDeleteGroup.Size = New System.Drawing.Size(75, 30)
        Me.btnDeleteGroup.TabIndex = 8
        Me.btnDeleteGroup.Text = "Delete"
        Me.btnDeleteGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDeleteGroup.UseVisualStyleBackColor = False
        '
        'btnEditGroup
        '
        Me.btnEditGroup.BackColor = System.Drawing.Color.White
        Me.btnEditGroup.Image = CType(resources.GetObject("btnEditGroup.Image"), System.Drawing.Image)
        Me.btnEditGroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEditGroup.Location = New System.Drawing.Point(83, 33)
        Me.btnEditGroup.Name = "btnEditGroup"
        Me.btnEditGroup.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnEditGroup.Size = New System.Drawing.Size(75, 30)
        Me.btnEditGroup.TabIndex = 7
        Me.btnEditGroup.Text = "Edit"
        Me.btnEditGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEditGroup.UseVisualStyleBackColor = False
        '
        'btnAddGroup
        '
        Me.btnAddGroup.BackColor = System.Drawing.Color.White
        Me.btnAddGroup.Image = CType(resources.GetObject("btnAddGroup.Image"), System.Drawing.Image)
        Me.btnAddGroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAddGroup.Location = New System.Drawing.Point(7, 33)
        Me.btnAddGroup.Name = "btnAddGroup"
        Me.btnAddGroup.Padding = New System.Windows.Forms.Padding(10, 0, 3, 0)
        Me.btnAddGroup.Size = New System.Drawing.Size(75, 30)
        Me.btnAddGroup.TabIndex = 6
        Me.btnAddGroup.Text = "Add"
        Me.btnAddGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAddGroup.UseVisualStyleBackColor = False
        '
        'TxtNamaGroup
        '
        Me.TxtNamaGroup.Location = New System.Drawing.Point(82, 8)
        Me.TxtNamaGroup.Name = "TxtNamaGroup"
        Me.TxtNamaGroup.Size = New System.Drawing.Size(175, 22)
        Me.TxtNamaGroup.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Group Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Cari Admin Nota"
        '
        'TxtCariUser
        '
        Me.TxtCariUser.Location = New System.Drawing.Point(99, 10)
        Me.TxtCariUser.Name = "TxtCariUser"
        Me.TxtCariUser.Size = New System.Drawing.Size(175, 22)
        Me.TxtCariUser.TabIndex = 15
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.TxtCariUser)
        Me.Panel11.Controls.Add(Me.Label3)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(10, 10)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(434, 40)
        Me.Panel11.TabIndex = 0
        '
        'fgUser
        '
        Me.fgUser.ColumnInfo = "10,1,0,0,0,-1,Columns:"
        Me.fgUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fgUser.Location = New System.Drawing.Point(0, 0)
        Me.fgUser.Name = "fgUser"
        Me.fgUser.Size = New System.Drawing.Size(434, 527)
        Me.fgUser.TabIndex = 2
        '
        'FrmUtlAksesPancang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1017, 629)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FrmUtlAksesPancang"
        Me.Text = "Akses Pancang"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        CType(Me.fgPancang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        CType(Me.fgGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        CType(Me.fgUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents fgGroup As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel7 As Panel
    Friend WithEvents TxtNamaGroup As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnExit As Button
    Friend WithEvents btnCancelGroup As Button
    Friend WithEvents btnSaveGroup As Button
    Friend WithEvents btnDeleteGroup As Button
    Friend WithEvents btnEditGroup As Button
    Friend WithEvents btnAddGroup As Button
    Friend WithEvents Panel10 As Panel
    Friend WithEvents fgPancang As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel9 As Panel
    Friend WithEvents TxtCariPancang As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel12 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel13 As Panel
    Friend WithEvents fgUser As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Panel11 As Panel
    Friend WithEvents TxtCariUser As TextBox
    Friend WithEvents Label3 As Label
End Class
