Imports System.Data.SqlClient
Imports System.DirectoryServices.ActiveDirectory
Imports C1.Util.DX.WIC
Imports C1.Win.C1FlexGrid
Imports Microsoft.VisualBasic.Devices

Public Class FrmMstUangMakan
    Dim dt As DataTable = New DataTable
    Dim dt2 As DataTable = New DataTable
    Dim txt As CellRange
    Dim pancang As String
    Dim perintah As String
    Dim idPancang As Integer
    Dim uangMakan As Integer
    Dim tgl As Date
    Private Sub FrmMstUangMakan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel3.Left = (Me.ClientSize.Width - Me.Panel3.Width) / 2
        HeaderFG()
        Search()
        tampilanAwal()
        cekJikaAdaPancangBaruYangBelumDiSimpanDiMasterUangMakan()
        cekPancangYangBelumAdaUangMakan()
    End Sub
    Private Sub Search()
        With scp
            .SearchMode = C1.Win.C1FlexGrid.SearchMode.Always
            .SearchDelay = 2
            .Watermark = "Cari Di sini..."
            .SetC1FlexGridSearchPanel(fg, scp)
        End With
    End Sub
    Public Sub HeaderFG()
        With fg
            .Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Regular)
            .Rows.Count = 1
            .Cols.Count = 10
            .Cols.Fixed = 1
            .Styles.Fixed.BackColor = Color.White 'FromArgb(227, 242, 253)
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleFixedNew.BackColor = Color.SkyBlue
            .Rows(0).StyleNew.BackColor = Color.SkyBlue
            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 1
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "N0" : .Cols(0).Width = 50
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "Pancang" : .Cols(1).TextAlign = TextAlignEnum.LeftCenter : .Cols(1).AllowEditing = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Uang Makan" : .Cols(2).TextAlign = TextAlignEnum.RightCenter : .Cols(2).AllowEditing = False : .Cols(2).Format = "#,###0"
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Tanggal Awal Perioder" : .Cols(3).TextAlign = TextAlignEnum.CenterCenter : .Cols(3).AllowEditing = False
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "Created By" : .Cols(4).TextAlign = TextAlignEnum.LeftCenter : .Cols(4).AllowEditing = False
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "Created Date" : .Cols(5).TextAlign = TextAlignEnum.CenterCenter : .Cols(5).AllowEditing = False
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "Updated By" : .Cols(6).TextAlign = TextAlignEnum.LeftCenter : .Cols(6).AllowEditing = False
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "Updated Date" : .Cols(7).TextAlign = TextAlignEnum.CenterCenter : .Cols(7).AllowEditing = False
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "Computer" : .Cols(8).TextAlign = TextAlignEnum.LeftCenter : .Cols(8).AllowEditing = False
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "idPancang" : .Cols(9).TextAlign = TextAlignEnum.LeftCenter : .Cols(9).AllowEditing = False : .Cols(9).Visible = False

            .AutoSizeCols()
        End With
    End Sub
    Sub tampilanAwal()
        fg.Enabled = True

        txtpancang.Clear()
        txtuangmakan.Clear()
        dtptgl.Value = Now
        dtpAdd.Value = Now

        txtpancang.Enabled = False
        txtuangmakan.Enabled = False
        dtptgl.Enabled = False

        btnEdit.Enabled = False
        btnsave.Enabled = False
        btnCancel.Enabled = False
        btnclose.Enabled = True

        perintah = ""

        With fg
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Uang Makan" : .Cols(2).TextAlign = TextAlignEnum.RightCenter : .Cols(2).AllowEditing = False
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Tanggal Awal Perioder" : .Cols(3).TextAlign = TextAlignEnum.CenterCenter : .Cols(3).AllowEditing = False
        End With
    End Sub
    Sub cekJikaAdaPancangBaruYangBelumDiSimpanDiMasterUangMakan()
        dt.Clear()
        dt2.Clear()
        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select IDPancang,Pancang from Android_tblMstPancang where IDPancang not in (8)")
        For Each row As DataRow In dt.Rows
            dt2 = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select id_pancang from tblMstUangMakan where id_pancang='" & row("IDPancang") & "'")

            If dt2.Rows.Count = 0 Then
                db.ExecuteQuery(StrConnRMPApp,"insert into tblMstUangMakan (id_pancang,pancang,tgl_awal_periode,created_by,created_date,computer)
                                                          values ('" & row("IDPancang") & "','" & row("Pancang") & "',getdate(),'" & ClsSession.UserID & "',getdate(),HOST_NAME())")
            End If

            dt2.Clear()
        Next
    End Sub
    Sub cekPancangYangBelumAdaUangMakan()
        Dim i As Integer = 1
        dt.Clear()
        dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select * from Vw_MstUangMakan WHERE UANG_MAKAN IS NULL")

        If dt.Rows.Count <> 0 Then

            MsgBox("Ada Uang Makan Yang Belum Di Isi Nilai Nya,Isi Uang Makan Dan Tanggal Awal Periode Nya Pada Tabel Ini.", vbInformation, AT)

            With fg
                For Each row As DataRow In dt.Rows
                    .AddItem(i)
                    .Item(i, 1) = row.Item("Pancang")
                    .Item(i, 2) = row.Item("uang_makan")
                    .Item(i, 3) = row.Item("tgl_awal_periode")
                    .Item(i, 4) = row.Item("created_by")
                    .Item(i, 5) = row.Item("created_date")
                    .Item(i, 6) = row.Item("updated_by")
                    .Item(i, 7) = row.Item("updated_date")
                    .Item(i, 8) = row.Item("Computer")
                    .Item(i, 9) = row.Item("id_pancang")

                    i = i + 1
                Next
                .AutoSizeCols()
            End With
            addData()
        Else
            tampilData()
        End If
    End Sub
    Sub addData()
        With fg
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "Uang Makan" : .Cols(2).TextAlign = TextAlignEnum.RightCenter : .Cols(2).AllowEditing = True
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "Tanggal Awal Perioder" : .Cols(3).TextAlign = TextAlignEnum.CenterCenter : .Cols(3).AllowEditing = True
        End With

        btnEdit.Enabled = False
        btnsave.Enabled = True
        btnCancel.Enabled = False
        btnclose.Enabled = True

        perintah = "Add"
    End Sub
    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Me.Cursor = Cursors.WaitCursor
        Dim koneksi As SqlConnection = Modul_RMP.DB.OpenConnection(StrConnRMPApp)
        Dim Transaksi As SqlTransaction
        Transaksi = koneksi.BeginTransaction

        If perintah <> "Add" Then
            If txtuangmakan.Text = "" Then
                MsgBox("Uang Makan Belum Di Isi.", vbInformation, AT)
                Exit Sub
            End If

            'dt.Clear()
            'dt = DB.ExecuteQuery(StrConnRMPApp,"select * from tblMstUangMakan where id_pancang='' and cast(tgl_awal_periode as date)=cast('' as date)")
            'If dt.Rows.Count <> 0 Then
            '    MsgBox("Data Uang Makan Pancang '" & txtpancang.Text & "' Dan Tanggal Awal Periode '" & Format(dtptgl.Value, "yyyy-MM-dd") & "' Sudah Ada.", vbInformation, AT)
            '    Exit Sub
            'End If
        End If

        If perintah = "Add" Then
            For i = 1 To fg.Rows.Count - 1
                If IsDBNull(fg.Item(i, 2)) Then
                    MsgBox("Uang Makan Belum Di Isi Semua.", vbInformation, AT)
                    Exit Sub
                End If
            Next
        End If

        Try
            If perintah = "Add" Then
                For i = 1 To fg.Rows.Count - 1
                    uangMakan = fg.Item(i, 2)
                    tgl = fg.Item(i, 3)
                    idPancang = fg.Item(i, 9)
                    If SpSaveMstUangMakan(koneksi, Transaksi) = False Then
                        Transaksi.Rollback()
                        MsgBox("Simpan Data Gagal", vbCritical, "Save Master Uang Makan")
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                Next
            Else
                uangMakan = txtuangmakan.Text
                tgl = dtptgl.Value
                If SpSaveMstUangMakan(koneksi, Transaksi) = False Then
                    Transaksi.Rollback()
                    MsgBox("Simpan Data Gagal", vbCritical, "Save Master Uang Makan")
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            End If
            Transaksi.Commit()
            MsgBox("Data Telah Tersimpan", MsgBoxStyle.Information)
            tampilanAwal()
            tampilData()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            koneksi.Close()
            Me.Cursor = Cursors.Default
        End Try
        cekPancangYangBelumAdaUangMakan()
    End Sub
    Private Function SpSaveMstUangMakan(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction) As Boolean
        SpSaveMstUangMakan = False
        Dim MyCon As SqlConnection = Conn
        Dim MyConTrans As SqlTransaction = Trans
        Dim cmd As New SqlCommand
        With cmd
            'buat parameter sp
            .Connection = Conn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "RMPApp..SpSaveMstUangMakan"
            .Transaction = MyConTrans
            .Parameters.Add("@idPancang", SqlDbType.Int).Value = idPancang
            .Parameters.Add("@uangMakan", SqlDbType.Int).Value = uangMakan
            .Parameters.Add("@tgl", SqlDbType.Date).Value = Format(tgl, "yyyy-MM-dd")
            .Parameters.Add("@user", SqlDbType.VarChar, 50).Value = ClsSession.UserID
            .Parameters.Add("@perintah", SqlDbType.VarChar, 50).Value = perintah
            .Parameters.Add(New SqlParameter("@Flag", SqlDbType.TinyInt, 1, ParameterDirection.InputOutput, False, 0, 0, 0, DataRowVersion.Proposed, 0))
            .ExecuteNonQuery()
        End With
        Try
            If CInt(cmd.Parameters("@Flag").Value) = "0" Then
                cmd.Dispose()
                Exit Function
            End If
            cmd.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return True
    End Function

    Private Sub txtuangmakn_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtuangmakan.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Sub tampilData()
        Dim i As Integer = 1
        fg.Rows.Count = 1
        Try
            If chkLiatSemua.Checked = True Then
                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select * from tblMstUangMakan  order by id_pancang,tgl_awal_periode desc")
            Else
                dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "select * from Vw_MstUangMakan")
            End If
            If dt.Rows.Count > 0 Then
                With fg
                    For Each row As DataRow In dt.Rows
                        .AddItem(i)
                        .Item(i, 1) = row.Item("Pancang")
                        .Item(i, 2) = row.Item("uang_makan")
                        .Item(i, 3) = row.Item("tgl_awal_periode")
                        .Item(i, 4) = row.Item("created_by")
                        .Item(i, 5) = row.Item("created_date")
                        .Item(i, 6) = row.Item("updated_by")
                        .Item(i, 7) = row.Item("updated_date")
                        .Item(i, 8) = row.Item("Computer")
                        .Item(i, 9) = row.Item("id_pancang")

                        i = i + 1
                    Next
                    .AutoSizeCols()
                End With
            Else
                Call MsgBox("Data Tidak Di Temulkan !", vbExclamation, AT)
            End If
        Catch EX As Exception
            MsgBox(EX.Message)
        End Try
    End Sub

    Private Sub fg_Click(sender As Object, e As EventArgs) Handles fg.Click
        If fg.Rows.Count > 1 And perintah <> "Add" Then
            txtpancang.Text = fg.Item(fg.RowSel, 1)
            txtuangmakan.Text = fg.Item(fg.RowSel, 2)
            dtptgl.Value = fg.Item(fg.RowSel, 3)
            idPancang = fg.Item(fg.RowSel, 9)

            btnEdit.Enabled = True
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        fg.Enabled = False

        txtuangmakan.Enabled = True
        dtptgl.Enabled = False
        If chkLiatSemua.Checked = False Then
            dtptgl.Value = Now
            dtptgl.Enabled = True
        End If


        btnEdit.Enabled = False
        btnsave.Enabled = True
        btnCancel.Enabled = True

        perintah = "Edit"
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        tampilanAwal()
        tampilData()
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub chkLiatSemua_CheckedChanged(sender As Object, e As EventArgs) Handles chkLiatSemua.CheckedChanged
        tampilData()
    End Sub

    Private Sub FrmMstUangMakan_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Func.ControlCentreForm(Me, PanelForm)
    End Sub
End Class