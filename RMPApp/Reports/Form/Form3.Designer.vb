<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvList = New System.Windows.Forms.DataGridView()
        Me.No = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDPancangReal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDPancang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pancang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TglMasukKapal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Trip = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NamaKapal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KapalID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NotaVia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalMuatan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.N1Pabrik = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalUpahBongkar1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalSusut = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoTransSusut = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.PotongSusut = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoTransOlahGerak = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.PotongLainLain = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoTransGPS = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.PotonganGps = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalUpahBongkar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BayarVia = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.NotaViaID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rekening = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.AccountNo1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AccountName1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DetailID1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.norekid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NoInvoice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Print = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.StatusBongkar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Investigasi = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.HargaLama = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.BahanBaku = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.No, Me.IDPancangReal, Me.IDPancang, Me.Pancang, Me.TglMasukKapal, Me.Trip, Me.NamaKapal, Me.KapalID, Me.NotaVia, Me.TotalMuatan, Me.N1Pabrik, Me.Rp, Me.TotalUpahBongkar1, Me.TotalSusut, Me.NoTransSusut, Me.PotongSusut, Me.NoTransOlahGerak, Me.PotongLainLain, Me.NoTransGPS, Me.PotonganGps, Me.TotalUpahBongkar, Me.BayarVia, Me.NotaViaID, Me.Rekening, Me.AccountNo1, Me.AccountName1, Me.DetailID1, Me.norekid, Me.NoInvoice, Me.Print, Me.StatusBongkar, Me.Investigasi, Me.HargaLama, Me.BahanBaku})
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvList.DefaultCellStyle = DataGridViewCellStyle14
        Me.dgvList.EnableHeadersVisualStyles = False
        Me.dgvList.Location = New System.Drawing.Point(-187, 8)
        Me.dgvList.Name = "dgvList"
        Me.dgvList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Honeydew
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvList.RowHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.dgvList.RowHeadersVisible = False
        Me.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvList.Size = New System.Drawing.Size(1175, 435)
        Me.dgvList.TabIndex = 75
        '
        'No
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.No.DefaultCellStyle = DataGridViewCellStyle2
        Me.No.HeaderText = "No."
        Me.No.Name = "No"
        Me.No.ReadOnly = True
        Me.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.No.Width = 50
        '
        'IDPancangReal
        '
        Me.IDPancangReal.HeaderText = "IDPancangReal"
        Me.IDPancangReal.Name = "IDPancangReal"
        Me.IDPancangReal.Visible = False
        '
        'IDPancang
        '
        Me.IDPancang.HeaderText = "IDPancang"
        Me.IDPancang.Name = "IDPancang"
        '
        'Pancang
        '
        Me.Pancang.HeaderText = "Pancang"
        Me.Pancang.Name = "Pancang"
        '
        'TglMasukKapal
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.TglMasukKapal.DefaultCellStyle = DataGridViewCellStyle3
        Me.TglMasukKapal.HeaderText = "Tgl Masuk Kapal"
        Me.TglMasukKapal.Name = "TglMasukKapal"
        Me.TglMasukKapal.ReadOnly = True
        Me.TglMasukKapal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Trip
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Trip.DefaultCellStyle = DataGridViewCellStyle4
        Me.Trip.HeaderText = "Trip"
        Me.Trip.Name = "Trip"
        Me.Trip.ReadOnly = True
        Me.Trip.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'NamaKapal
        '
        Me.NamaKapal.HeaderText = "Nama Kapal"
        Me.NamaKapal.Name = "NamaKapal"
        Me.NamaKapal.ReadOnly = True
        Me.NamaKapal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.NamaKapal.Width = 230
        '
        'KapalID
        '
        Me.KapalID.HeaderText = "KapalID"
        Me.KapalID.Name = "KapalID"
        Me.KapalID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'NotaVia
        '
        Me.NotaVia.HeaderText = "NotaVia"
        Me.NotaVia.Name = "NotaVia"
        Me.NotaVia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.NotaVia.Visible = False
        '
        'TotalMuatan
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.TotalMuatan.DefaultCellStyle = DataGridViewCellStyle5
        Me.TotalMuatan.HeaderText = "Total Muatan (KG)"
        Me.TotalMuatan.Name = "TotalMuatan"
        Me.TotalMuatan.ReadOnly = True
        Me.TotalMuatan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.TotalMuatan.Width = 110
        '
        'N1Pabrik
        '
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.N1Pabrik.DefaultCellStyle = DataGridViewCellStyle6
        Me.N1Pabrik.HeaderText = "N1Pabrik (Kg)"
        Me.N1Pabrik.Name = "N1Pabrik"
        '
        'Rp
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.Rp.DefaultCellStyle = DataGridViewCellStyle7
        Me.Rp.HeaderText = "Rp @"
        Me.Rp.Name = "Rp"
        Me.Rp.ReadOnly = True
        Me.Rp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Rp.Width = 80
        '
        'TotalUpahBongkar1
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N0"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.TotalUpahBongkar1.DefaultCellStyle = DataGridViewCellStyle8
        Me.TotalUpahBongkar1.HeaderText = "TotalUpahBongkar1"
        Me.TotalUpahBongkar1.Name = "TotalUpahBongkar1"
        '
        'TotalSusut
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N0"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.TotalSusut.DefaultCellStyle = DataGridViewCellStyle9
        Me.TotalSusut.HeaderText = "Potongan Asuransi"
        Me.TotalSusut.Name = "TotalSusut"
        '
        'NoTransSusut
        '
        Me.NoTransSusut.HeaderText = "NoTransSusut"
        Me.NoTransSusut.Name = "NoTransSusut"
        Me.NoTransSusut.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NoTransSusut.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'PotongSusut
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.PotongSusut.DefaultCellStyle = DataGridViewCellStyle10
        Me.PotongSusut.HeaderText = "PotongSusut"
        Me.PotongSusut.Name = "PotongSusut"
        '
        'NoTransOlahGerak
        '
        Me.NoTransOlahGerak.HeaderText = "NoTransOlahGerak"
        Me.NoTransOlahGerak.Name = "NoTransOlahGerak"
        Me.NoTransOlahGerak.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NoTransOlahGerak.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'PotongLainLain
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.PotongLainLain.DefaultCellStyle = DataGridViewCellStyle11
        Me.PotongLainLain.HeaderText = "Potongan Olah Gerak"
        Me.PotongLainLain.Name = "PotongLainLain"
        '
        'NoTransGPS
        '
        Me.NoTransGPS.HeaderText = "NoTransGPS"
        Me.NoTransGPS.Name = "NoTransGPS"
        Me.NoTransGPS.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NoTransGPS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'PotonganGps
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.PotonganGps.DefaultCellStyle = DataGridViewCellStyle12
        Me.PotonganGps.HeaderText = "Potongan Gps"
        Me.PotonganGps.Name = "PotonganGps"
        '
        'TotalUpahBongkar
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.Format = "N0"
        DataGridViewCellStyle13.NullValue = Nothing
        Me.TotalUpahBongkar.DefaultCellStyle = DataGridViewCellStyle13
        Me.TotalUpahBongkar.HeaderText = "Total Upah Bongkar (Rp)"
        Me.TotalUpahBongkar.Name = "TotalUpahBongkar"
        Me.TotalUpahBongkar.ReadOnly = True
        Me.TotalUpahBongkar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TotalUpahBongkar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.TotalUpahBongkar.Width = 200
        '
        'BayarVia
        '
        Me.BayarVia.HeaderText = "Pembayaran Via Trf/Ktn"
        Me.BayarVia.Items.AddRange(New Object() {"Transfer", "Kontan"})
        Me.BayarVia.Name = "BayarVia"
        Me.BayarVia.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'NotaViaID
        '
        Me.NotaViaID.HeaderText = "Nota Via ID"
        Me.NotaViaID.Name = "NotaViaID"
        Me.NotaViaID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.NotaViaID.Visible = False
        '
        'Rekening
        '
        Me.Rekening.HeaderText = "Nama, NoRekening, Bank"
        Me.Rekening.Name = "Rekening"
        Me.Rekening.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Rekening.Width = 230
        '
        'AccountNo1
        '
        Me.AccountNo1.HeaderText = "AccountNo"
        Me.AccountNo1.Name = "AccountNo1"
        Me.AccountNo1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.AccountNo1.Visible = False
        '
        'AccountName1
        '
        Me.AccountName1.HeaderText = "AccountName"
        Me.AccountName1.Name = "AccountName1"
        Me.AccountName1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.AccountName1.Visible = False
        Me.AccountName1.Width = 200
        '
        'DetailID1
        '
        Me.DetailID1.HeaderText = "DetailID1"
        Me.DetailID1.Name = "DetailID1"
        Me.DetailID1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DetailID1.Visible = False
        '
        'norekid
        '
        Me.norekid.HeaderText = "norekid"
        Me.norekid.Name = "norekid"
        Me.norekid.Visible = False
        '
        'NoInvoice
        '
        Me.NoInvoice.HeaderText = "NoInvoice"
        Me.NoInvoice.Name = "NoInvoice"
        Me.NoInvoice.Visible = False
        '
        'Print
        '
        Me.Print.HeaderText = "Print"
        Me.Print.Name = "Print"
        Me.Print.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Print.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Print.Visible = False
        '
        'StatusBongkar
        '
        Me.StatusBongkar.HeaderText = "StatusBongkar"
        Me.StatusBongkar.Name = "StatusBongkar"
        '
        'Investigasi
        '
        Me.Investigasi.HeaderText = "Investigasi"
        Me.Investigasi.Name = "Investigasi"
        '
        'HargaLama
        '
        Me.HargaLama.HeaderText = "HargaLama"
        Me.HargaLama.Name = "HargaLama"
        Me.HargaLama.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.HargaLama.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'BahanBaku
        '
        Me.BahanBaku.HeaderText = "BahanBaku"
        Me.BahanBaku.Name = "BahanBaku"
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.dgvList)
        Me.Name = "Form3"
        Me.Text = "Form3"
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvList As DataGridView
    Friend WithEvents No As DataGridViewTextBoxColumn
    Friend WithEvents IDPancangReal As DataGridViewTextBoxColumn
    Friend WithEvents IDPancang As DataGridViewTextBoxColumn
    Friend WithEvents Pancang As DataGridViewTextBoxColumn
    Friend WithEvents TglMasukKapal As DataGridViewTextBoxColumn
    Friend WithEvents Trip As DataGridViewTextBoxColumn
    Friend WithEvents NamaKapal As DataGridViewTextBoxColumn
    Friend WithEvents KapalID As DataGridViewTextBoxColumn
    Friend WithEvents NotaVia As DataGridViewTextBoxColumn
    Friend WithEvents TotalMuatan As DataGridViewTextBoxColumn
    Friend WithEvents N1Pabrik As DataGridViewTextBoxColumn
    Friend WithEvents Rp As DataGridViewTextBoxColumn
    Friend WithEvents TotalUpahBongkar1 As DataGridViewTextBoxColumn
    Friend WithEvents TotalSusut As DataGridViewTextBoxColumn
    Friend WithEvents NoTransSusut As DataGridViewComboBoxColumn
    Friend WithEvents PotongSusut As DataGridViewTextBoxColumn
    Friend WithEvents NoTransOlahGerak As DataGridViewComboBoxColumn
    Friend WithEvents PotongLainLain As DataGridViewTextBoxColumn
    Friend WithEvents NoTransGPS As DataGridViewComboBoxColumn
    Friend WithEvents PotonganGps As DataGridViewTextBoxColumn
    Friend WithEvents TotalUpahBongkar As DataGridViewTextBoxColumn
    Friend WithEvents BayarVia As DataGridViewComboBoxColumn
    Friend WithEvents NotaViaID As DataGridViewTextBoxColumn
    Friend WithEvents Rekening As DataGridViewComboBoxColumn
    Friend WithEvents AccountNo1 As DataGridViewTextBoxColumn
    Friend WithEvents AccountName1 As DataGridViewTextBoxColumn
    Friend WithEvents DetailID1 As DataGridViewTextBoxColumn
    Friend WithEvents norekid As DataGridViewTextBoxColumn
    Friend WithEvents NoInvoice As DataGridViewTextBoxColumn
    Friend WithEvents Print As DataGridViewButtonColumn
    Friend WithEvents StatusBongkar As DataGridViewTextBoxColumn
    Friend WithEvents Investigasi As DataGridViewCheckBoxColumn
    Friend WithEvents HargaLama As DataGridViewCheckBoxColumn
    Friend WithEvents BahanBaku As DataGridViewTextBoxColumn
End Class
