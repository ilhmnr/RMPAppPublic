
Imports System.Data
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmMstSatuanItem

    Private Enum FormMode
        Normal
        Add
        Edit
    End Enum

    Private mode As FormMode = FormMode.Normal
    Private Perintah As String = ""
    Private Satuan As String = ""
    Private Id As Integer
    Private txt As CellRange

    Private Sub FrmMstSatuanBarang_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        HeaderFG()
        ShowData()
        ClearData()

    End Sub

    Private Sub HeaderFG()

        With FG
            .Font = New Font("Century Gothic", 7.0!, FontStyle.Regular)
            .Rows.Count = 1
            .Cols.Count = 6
            .Rows.Fixed = 1
            .Cols.Fixed = 1

            .Styles.Fixed.BackColor = Color.PowderBlue
            .Styles.Alternate.BackColor = Color.FromArgb(224, 224, 224)
            .Rows(0).StyleFixedNew.BackColor = Color.PowderBlue
            .Rows(0).StyleNew.BackColor = Color.PowderBlue
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            .Styles.Normal.WordWrap = True

            .VisualStyle = VisualStyle.Custom
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True

            txt = .GetCellRange(0, 0)
            txt.Data = "No"
            .Cols(0).Width = 50
            .Cols(0).TextAlign = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 1)
            txt.Data = "Satuan Barang"
            .Cols(1).TextAlign = TextAlignEnum.LeftCenter
            .Cols(1).AllowEditing = False

            txt = .GetCellRange(0, 2)
            txt.Data = "Created By"
            .Cols(2).TextAlign = TextAlignEnum.CenterCenter
            .Cols(2).AllowEditing = False

            txt = .GetCellRange(0, 3)
            txt.Data = "Created Date"
            .Cols(3).TextAlign = TextAlignEnum.CenterCenter
            .Cols(3).AllowEditing = False

            txt = .GetCellRange(0, 4)
            txt.Data = "Not Actived"
            .Cols(4).TextAlign = TextAlignEnum.CenterCenter
            .Cols(4).AllowEditing = True
            .Cols(4).Visible = False

            txt = .GetCellRange(0, 5)
            txt.Data = "Id"
            .Cols(5).Visible = False

            .AutoSizeCols()

        End With

    End Sub

    Private Sub ShowData()

        Dim dt As DataTable = Nothing

        Try
            FG.Rows.Count = 1

            dt = DB.ExecuteQuery(
                StrConnRMPApp,
                "SELECT * FROM TblInv_MstSatuanBarang " &
                "WHERE NotActived = 0 ORDER BY Satuan ASC"
            )

            With FG
                For Each row As DataRow In dt.Rows

                    .AddItem(
                        (.Rows.Count).ToString() & vbTab &
                        Convert.ToString(row("Satuan")) & vbTab &
                        Convert.ToString(row("CreatedBy")) & vbTab &
                        Convert.ToString(row("CreatedDate")) & vbTab &
                        "False" & vbTab &
                        Convert.ToString(row("Id"))
                    )

                Next

                .AutoSizeCols()
            End With

        Catch ex As Exception
            MessageBox.Show(
                ex.Message,
                "Tampil Data",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )
        Finally
            If dt IsNot Nothing Then dt.Dispose()
        End Try

    End Sub

    Private Sub ClearData()

        mode = FormMode.Normal
        Perintah = ""

        TxtSatuan.Clear()
        TxtSatuan.Enabled = False

        FG.Enabled = False
        FG.Cols(4).Visible = False

        btnAdd.Enabled = True
        btnSave.Enabled = False
        BtnUpdate.Enabled = True
        btnCancel.Enabled = False

    End Sub

    Private Sub btnAdd_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnAdd.Click

        mode = FormMode.Add
        Perintah = "Add"

        TxtSatuan.Clear()
        TxtSatuan.Enabled = True

        FG.Enabled = False

        btnAdd.Enabled = False
        btnSave.Enabled = True
        BtnUpdate.Enabled = False
        btnCancel.Enabled = True

        TxtSatuan.Focus()

    End Sub

    Private Sub BtnUpdate_Click(
        sender As Object,
        e As EventArgs
    ) Handles BtnUpdate.Click

        If FG.Rows.Count <= 1 Then
            MessageBox.Show(
                "Tidak ada data yang dapat diubah.",
                AT,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )
            Return
        End If

        mode = FormMode.Edit
        Perintah = "Edit"

        TxtSatuan.Enabled = False
        FG.Enabled = True
        FG.Cols(4).Visible = True

        btnAdd.Enabled = False
        btnSave.Enabled = True
        BtnUpdate.Enabled = False
        btnCancel.Enabled = True

    End Sub

    Private Function SpInv_SaveMstSatuanBarang(
        ByVal Conn As SqlConnection,
        ByVal Trans As SqlTransaction
    ) As Boolean

        Using cmd As New SqlCommand(
            "RMPApp..SpInv_SaveMstSatuanBarang",
            Conn,
            Trans
        )

            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Add(
                "@Satuan",
                SqlDbType.VarChar,
                50
            ).Value = Satuan

            cmd.Parameters.Add(
                "@UserLogin",
                SqlDbType.VarChar,
                50
            ).Value = ClsSession.UserID

            cmd.Parameters.Add(
                "@Perintah",
                SqlDbType.VarChar,
                20
            ).Value = Perintah

            cmd.Parameters.Add(
                "@Id",
                SqlDbType.Int
            ).Value = Id

            Dim pFlag As SqlParameter =
                cmd.Parameters.Add("@Flag", SqlDbType.TinyInt)

            pFlag.Direction = ParameterDirection.InputOutput
            pFlag.Value = 0

            cmd.ExecuteNonQuery()

            If pFlag.Value Is Nothing OrElse
               pFlag.Value Is DBNull.Value Then
                Return False
            End If

            Return Convert.ToInt32(pFlag.Value) <> 0

        End Using

    End Function

    Private Sub btnSave_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnSave.Click

        If mode = FormMode.Normal Then Return

        If mode = FormMode.Add AndAlso
           String.IsNullOrWhiteSpace(TxtSatuan.Text) Then

            MessageBox.Show(
                "Satuan barang wajib diisi.",
                AT,
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            TxtSatuan.Focus()
            Return
        End If

        Dim koneksi As SqlConnection = Nothing
        Dim transaksi As SqlTransaction = Nothing

        Me.Cursor = Cursors.WaitCursor
        btnSave.Enabled = False

        Try
            koneksi = DB.OpenConnection(StrConnRMPApp)
            transaksi = koneksi.BeginTransaction()

            If mode = FormMode.Add Then

                Satuan = TxtSatuan.Text.Trim()
                Id = 1
                Perintah = "Add"

                If Not SpInv_SaveMstSatuanBarang(
                    koneksi, transaksi
                ) Then
                    Throw New Exception("Simpan data gagal.")
                End If

            ElseIf mode = FormMode.Edit Then

                Dim AdaData As Boolean = False

                For i As Integer = 1 To FG.Rows.Count - 1

                    Dim isNotActived As Boolean = False

                    If FG(i, 4) IsNot Nothing AndAlso
                       FG(i, 4) IsNot DBNull.Value Then

                        Boolean.TryParse(
                            Convert.ToString(FG(i, 4)),
                            isNotActived
                        )

                    End If

                    If isNotActived Then

                        AdaData = True

                        Satuan = Convert.ToString(FG(i, 1))
                        Id = Convert.ToInt32(FG(i, 5))
                        Perintah = "Edit"

                        If Not SpInv_SaveMstSatuanBarang(
                            koneksi, transaksi
                        ) Then
                            Throw New Exception(
                                "Gagal mengubah status satuan: " & Satuan
                            )
                        End If

                    End If

                Next

                If Not AdaData Then
                    transaksi.Rollback()
                    transaksi.Dispose()
                    transaksi = Nothing

                    MessageBox.Show(
                        "Tidak ada data yang dipilih. " &
                        "Centang kolom Not Actived untuk memilih data.",
                        AT,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    )

                    Return
                End If

            End If

            transaksi.Commit()
            transaksi.Dispose()
            transaksi = Nothing

            MessageBox.Show(
                "Data telah tersimpan.",
                AT,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            ShowData()
            ClearData()

        Catch ex As Exception

            If transaksi IsNot Nothing Then
                Try
                    transaksi.Rollback()
                Catch
                End Try
            End If

            MessageBox.Show(
                ex.Message,
                "Simpan Data",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        Finally

            If transaksi IsNot Nothing Then transaksi.Dispose()
            If koneksi IsNot Nothing Then koneksi.Dispose()

            Me.Cursor = Cursors.Default

            If mode <> FormMode.Normal Then
                btnSave.Enabled = True
            End If

        End Try

    End Sub

    Private Sub btnCancel_Click(
        sender As Object,
        e As EventArgs
    ) Handles btnCancel.Click

        ClearData()

    End Sub

    Private Sub BtnExit_Click(
        sender As Object,
        e As EventArgs
    ) Handles BtnExit.Click

        Me.Close()

    End Sub

    Private Sub FrmMstSatuanItem_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Func.ControlCentreForm(Me, PanelForm)
    End Sub
End Class
