Imports System.Data.SqlClient

Public Class FrmMstWilayahDivisi

    Private Enum FormMode
        Normal
        Add
        Edit
    End Enum

    Private mode As FormMode = FormMode.Normal
    Private dtDivKav As New DataTable()

    Private ReadOnly ConnRMPApp As String = StrConnAccounting
    Private ReadOnly ConnTimbangan As String = StrConnTimbangan

#Region "Form Load"

    Private Sub FrmMstWilayahDivisi_Load(
        sender As Object, e As EventArgs
    ) Handles MyBase.Load
        ClsFlexGrid.ApplyStyle(fg)

        Try
            LoadComboBoxData()
            KondisiAwal()
            TampilkanData()
            ClsFlexGrid.ApplyStyle(fg)

        Catch ex As Exception
            MsgBoxCustom.Show(
                ex.Message,
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Error)
        End Try

    End Sub

    Private Sub FrmMstWilayahDivisi_Resize(
        sender As Object, e As EventArgs
    ) Handles MyBase.Resize

        Func.ControlCentreForm(Me, PanelForm)

    End Sub

#End Region

#Region "Load ComboBox"

    Private Sub LoadComboBoxData()

        Combo.GroupSupplier(CmbGroupSupplier)
        Combo.RmWilayah(CmbMainArea)
        Combo.RmAreaZone(CmbArea)

        Dim dt As DataTable

        dt = New DataTable()
        dt.Columns.Add("KodeGroupRM", GetType(Integer))
        dt.Columns.Add("NamaGroupRM", GetType(String))

        dt.Rows.Add(1, "Kelapa")
        dt.Rows.Add(2, "Nenas")
        dt.Rows.Add(3, "Kelapa & Nenas")

        With CmbGroupBahanBaku
            .DataSource = dt
            .DisplayMember = "NamaGroupRM"
            .ValueMember = "KodeGroupRM"
            .SelectedIndex = -1
        End With
    End Sub

#End Region

#Region "Kondisi Form"

    Private Sub KondisiAwal()

        mode = FormMode.Normal

        ControlEnabled(False)
        CmdEnabled(True)
        ClearData()

    End Sub

    Private Sub ControlEnabled(flag As Boolean)

        TxtKodeDivKav.Enabled = flag
        TxtNamaDivKav.Enabled = flag
        TxtWilayah.Enabled = flag
        TxtKeterangan.Enabled = flag

        CmbGroupSupplier.Enabled = flag
        CmbGroupBahanBaku.Enabled = flag
        CmbMainArea.Enabled = flag
        CmbArea.Enabled = flag

        TxtKodeDivKav.ReadOnly = (mode = FormMode.Edit)

    End Sub

    Private Sub CmdEnabled(flag As Boolean)

        btnTambah.Enabled = flag
        btnEdit.Enabled = flag
        btnHapus.Enabled = flag
        btnTutup.Enabled = flag

        btnSimpan.Enabled = Not flag
        btnBatal.Enabled = Not flag

    End Sub

    Private Sub ClearData()

        TxtKodeDivKav.Clear()
        TxtNamaDivKav.Clear()
        TxtWilayah.Clear()
        TxtKeterangan.Clear()

        CmbGroupSupplier.SelectedIndex = -1
        CmbGroupBahanBaku.SelectedIndex = -1
        CmbMainArea.SelectedIndex = -1
        CmbArea.SelectedIndex = -1

    End Sub

#End Region

#Region "Tampilkan Data"

    Private Sub TampilkanData()

        Dim sql As String =
            "SELECT * FROM vwRMMstSubArea " &
            "WHERE NotActive = 0 " &
            "ORDER BY KodeDivKav"

        dtDivKav = DB.ExecuteQuery(ConnRMPApp, sql)

        With fg
            .BeginUpdate()
            Try
                .Rows.Count = 1

                For Each dr As DataRow In dtDivKav.Rows

                    .AddItem("")

                    Dim r As Integer = .Rows.Count - 1

                    .Item(r, "No") = r
                    .Item(r, "KodeDivKav") = dr("KodeDivKav")
                    .Item(r, "NamaDivKav") = dr("NamaDivKav")
                    .Item(r, "Wilayah") = dr("Wilayah")
                    .Item(r, "NamaGroupSupplier") = dr("NamaGroup")

                    Select Case Convert.ToInt32(dr("GroupRM"))
                        Case 1
                            .Item(r, "NamaGroupBahanBaku") = "Kelapa"
                        Case 2
                            .Item(r, "NamaGroupBahanBaku") = "Nenas"
                        Case 3
                            .Item(r, "NamaGroupBahanBaku") = "Kelapa & Nenas"
                        Case Else
                            .Item(r, "NamaGroupBahanBaku") = ""
                    End Select

                    .Item(r, "Keterangan") = dr("Keterangan")
                    .Item(r, "NamaMainArea") = dr("NAMA_WILAYAH")
                    .Item(r, "NamaArea") = dr("AreaZoneName")
                    .Item(r, "KodeWilayah") = dr("Kode_Wilayah")
                    .Item(r, "AreaZoneID") = dr("AreaZoneID")

                Next

            Finally
                .EndUpdate()
            End Try
        End With

    End Sub

    Private Sub C1FlexGrid1_Click(
        sender As Object, e As EventArgs
    ) Handles fg.Click

        If mode <> FormMode.Normal Then Return
        If fg.Row < fg.Rows.Fixed Then Return

        TampilkanDataTerpilih(fg.Row)

    End Sub

    Private Sub TampilkanDataTerpilih(rowIndex As Integer)

        With fg
            TxtKodeDivKav.Text = Convert.ToString(.Item(rowIndex, "KodeDivKav"))
            TxtNamaDivKav.Text = Convert.ToString(.Item(rowIndex, "NamaDivKav"))
            TxtWilayah.Text = Convert.ToString(.Item(rowIndex, "Wilayah"))
            TxtKeterangan.Text = Convert.ToString(.Item(rowIndex, "Keterangan"))

            PilihCombo(CmbGroupSupplier, .Item(rowIndex, "NamaGroupSupplier"), False)
            PilihCombo(CmbGroupBahanBaku, .Item(rowIndex, "NamaGroupBahanBaku"), False)
            PilihCombo(CmbMainArea, .Item(rowIndex, "KodeWilayah"), True)
            PilihCombo(CmbArea, .Item(rowIndex, "AreaZoneID"), True)
        End With

    End Sub

    Private Sub PilihCombo(
        cbo As ComboBox,
        nilai As Object,
        berdasarkanValue As Boolean
    )

        If nilai Is Nothing OrElse IsDBNull(nilai) Then
            cbo.SelectedIndex = -1
            Return
        End If

        If berdasarkanValue Then
            cbo.SelectedValue = nilai
        Else
            cbo.SelectedIndex = -1

            For i As Integer = 0 To cbo.Items.Count - 1
                cbo.SelectedIndex = i

                If String.Equals(
                    cbo.Text,
                    Convert.ToString(nilai),
                    StringComparison.OrdinalIgnoreCase) Then
                    Return
                End If
            Next

            cbo.SelectedIndex = -1
        End If

    End Sub

#End Region

#Region "Validasi"

    Private Function ValidasiInput() As Boolean

        If TxtKodeDivKav.Text.Trim() = "" Then
            MsgBoxCustom.Show(
                "Kode Divisi/Kavling harus diisi.",
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Information)
            TxtKodeDivKav.Focus()
            Return False
        End If

        If TxtNamaDivKav.Text.Trim() = "" Then
            MsgBoxCustom.Show(
                "Nama Divisi/Kavling harus diisi.",
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Information)
            TxtNamaDivKav.Focus()
            Return False
        End If

        If TxtWilayah.Text.Trim() = "" Then
            MsgBoxCustom.Show(
                "Wilayah harus diisi.",
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Information)
            TxtWilayah.Focus()
            Return False
        End If

        If CmbGroupSupplier.SelectedIndex = -1 Then
            MsgBoxCustom.Show(
                "Group Supplier harus dipilih.",
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Information)
            CmbGroupSupplier.Focus()
            Return False
        End If

        Return True

    End Function

#End Region

#Region "Simpan Data"

    Private Function SimpanDatabase(
        connString As String,
        ByRef pesanError As String
    ) As Boolean

        Using conn As SqlConnection = DB.OpenConnection(connString)

            Using trans As SqlTransaction = conn.BeginTransaction()

                Try
                    Using cmd As New SqlCommand(
                        "spRMMstDivisiKavling2", conn, trans)

                        cmd.CommandType = CommandType.StoredProcedure

                        cmd.Parameters.Add(
                            "@KodeDivKav", SqlDbType.VarChar, 100
                        ).Value = TxtKodeDivKav.Text.Trim().ToUpper()

                        cmd.Parameters.Add(
                            "@NamaDivKav", SqlDbType.VarChar, 200
                        ).Value = TxtNamaDivKav.Text.Trim().ToUpper()

                        cmd.Parameters.Add(
                            "@Wilayah", SqlDbType.VarChar, 50
                        ).Value = TxtWilayah.Text.Trim().ToUpper()

                        cmd.Parameters.Add(
                            "@GroupDivisi", SqlDbType.Int
                        ).Value = Convert.ToInt32(CmbGroupSupplier.SelectedValue)

                        cmd.Parameters.Add(
                            "@GroupRM", SqlDbType.Int
                        ).Value = If(
                            CmbGroupBahanBaku.SelectedValue Is Nothing,
                            0,
                            Convert.ToInt32(CmbGroupBahanBaku.SelectedValue))

                        cmd.Parameters.Add(
                            "@Keterangan", SqlDbType.VarChar, 200
                        ).Value = If(
                            TxtKeterangan.Text.Trim() = "",
                            CType(DBNull.Value, Object),
                            TxtKeterangan.Text.Trim())

                        cmd.Parameters.Add(
                            "@Kode_Wilayah", SqlDbType.VarChar, 15
                        ).Value = If(
                            CmbMainArea.SelectedValue Is Nothing,
                            CType(DBNull.Value, Object),
                            CmbMainArea.SelectedValue)

                        cmd.Parameters.Add(
                            "@AreaZoneID", SqlDbType.VarChar, 10
                        ).Value = If(
                            CmbArea.SelectedValue Is Nothing,
                            CType(DBNull.Value, Object),
                            CmbArea.SelectedValue)

                        cmd.Parameters.Add(
                            "@CreatedBy", SqlDbType.VarChar, 50
                        ).Value = ClsSession.UserID

                        cmd.Parameters.Add(
                            "@LastUpdatedBy", SqlDbType.VarChar, 50
                        ).Value = ClsSession.UserID

                        Dim pFlag As SqlParameter =
                            cmd.Parameters.Add("@Flag", SqlDbType.Int)

                        pFlag.Direction = ParameterDirection.Output

                        cmd.ExecuteNonQuery()

                        If pFlag.Value Is DBNull.Value OrElse
                           Convert.ToInt32(pFlag.Value) = 0 Then

                            trans.Rollback()
                            pesanError = "Stored procedure gagal menyimpan data."
                            Return False
                        End If

                    End Using

                    trans.Commit()
                    Return True

                Catch ex As Exception
                    Try
                        trans.Rollback()
                    Catch
                    End Try

                    pesanError = ex.Message
                    Return False
                End Try

            End Using
        End Using

    End Function

#End Region

#Region "Tombol Add, Edit, Save, Cancel"

    Private Sub btnAdd_Click(
        sender As Object, e As EventArgs
    ) Handles btnTambah.Click

        ClearData()
        mode = FormMode.Add
        ControlEnabled(True)
        CmdEnabled(False)

        TxtKodeDivKav.ReadOnly = False
        TxtKodeDivKav.Focus()

    End Sub

    Private Sub btnEdit_Click(
        sender As Object, e As EventArgs
    ) Handles btnEdit.Click

        If TxtKodeDivKav.Text.Trim() = "" Then
            MsgBoxCustom.Show(
                "Pilih data yang akan diedit terlebih dahulu.",
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Information)
            Return
        End If

        mode = FormMode.Edit
        ControlEnabled(True)
        CmdEnabled(False)

        TxtKodeDivKav.ReadOnly = True
        TxtNamaDivKav.Focus()

    End Sub

    Private Sub btnSave_Click(
        sender As Object, e As EventArgs
    ) Handles btnSimpan.Click

        If Not ValidasiInput() Then Return

        If CmbGroupBahanBaku.SelectedIndex = -1 Then
            MsgBoxCustom.Show(
                "Group Bahan Baku harus dipilih.",
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Information)
            CmbGroupBahanBaku.Focus()
            Return
        End If

        Me.Cursor = Cursors.WaitCursor

        Try
            Dim pesanError As String = ""

            If Not SimpanDatabase(ConnTimbangan, pesanError) Then
                MsgBoxCustom.Show(
                    "Simpan data ke database Timbangan gagal." &
                    vbCrLf & pesanError,
                    MsgBoxCustom.ButtonType.OK,
                    MsgBoxCustom.IconType.Error)
                Return
            End If

            If Not SimpanDatabase(ConnRMPApp, pesanError) Then
                MsgBoxCustom.Show(
                    "Simpan data ke database RMPApp gagal." &
                    vbCrLf & pesanError,
                    MsgBoxCustom.ButtonType.OK,
                    MsgBoxCustom.IconType.Error)
                Return
            End If

            MsgBoxCustom.Show(
                "Data berhasil disimpan.",
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Information)

            KondisiAwal()
            TampilkanData()

        Catch ex As Exception
            MsgBoxCustom.Show(
                ex.Message,
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub btnCancel_Click(
        sender As Object, e As EventArgs
    ) Handles btnBatal.Click

        KondisiAwal()

    End Sub

#End Region

#Region "Delete"

    Private Sub btnDelete_Click(
    sender As Object, e As EventArgs
) Handles btnHapus.Click

        If TxtKodeDivKav.Text.Trim() = "" Then
            MsgBoxCustom.Show(
            "Pilih data yang akan dihapus terlebih dahulu.",
            MsgBoxCustom.ButtonType.OK,
            MsgBoxCustom.IconType.Information)
            Return
        End If

        If MsgBoxCustom.Show(
        "Anda yakin ingin menghapus data ini?",
        MsgBoxCustom.ButtonType.YesNo,
        MsgBoxCustom.IconType.Question) <> DialogResult.Yes Then
            Return
        End If

        Me.Cursor = Cursors.WaitCursor

        Try
            Dim sql As String =
            "UPDATE tblRMMstDivisiKavling " &
            "SET NotActive = 1 " &
            "WHERE KodeDivKav = @KodeDivKav AND NotActive = 0"

            Dim hasil As Integer = DB.ExecuteNonQuery(
            ConnRMPApp,
            sql,
            New SqlParameter() {
                New SqlParameter("@KodeDivKav", TxtKodeDivKav.Text.Trim())
            })

            If hasil > 0 Then
                MsgBoxCustom.Show(
                "Data berhasil dinonaktifkan.",
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Information)

                KondisiAwal()
                TampilkanData()

            ElseIf hasil = 0 Then
                MsgBoxCustom.Show(
                "Data tidak ditemukan atau sudah dinonaktifkan.",
                MsgBoxCustom.ButtonType.OK,
                MsgBoxCustom.IconType.Information)

            End If

        Catch ex As Exception
            MsgBoxCustom.Show(
            "Hapus data gagal." & vbCrLf & ex.Message,
            MsgBoxCustom.ButtonType.OK,
            MsgBoxCustom.IconType.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

#End Region

#Region "Exit"

    Private Sub btnExit_Click(
        sender As Object, e As EventArgs
    ) Handles btnTutup.Click

        Me.Close()

    End Sub

#End Region

End Class