Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing
Imports C1.Win.C1FlexGrid
Imports QRCoder
Imports WeifenLuo.WinFormsUI.Docking
Imports ZXing

Public Class FrmTrnCetakLabelPetani

    Private dtData As New DataTable
    Private isLoading As Boolean = False

    Private Sub FrmTrnCetakLabelPetani_Load(
        sender As Object, e As EventArgs
    ) Handles MyBase.Load

        ClsFlexGrid.ApplyStyle(fg)

        LoadCombo()
        Combo.SetPancang(cmbPancang)

        ShowData()

    End Sub

    Private Sub LoadCombo()

        cmbJenisPetani.Items.Clear()
        cmbJenisPetani.Items.Add("Semua")
        cmbJenisPetani.Items.Add("Rekening")
        cmbJenisPetani.Items.Add("Non Rekening")
        cmbJenisPetani.SelectedIndex = 0

        cmbStatusPrint.Items.Clear()
        cmbStatusPrint.Items.Add("Semua")
        cmbStatusPrint.Items.Add("Belum Print")
        cmbStatusPrint.Items.Add("Sudah Print")
        cmbStatusPrint.SelectedIndex = 0

        cmbFotoPetani.Items.Clear()
        cmbFotoPetani.Items.Add("Semua")
        cmbFotoPetani.Items.Add("Ada")
        cmbFotoPetani.Items.Add("Tidak Ada")
        cmbFotoPetani.SelectedIndex = 0

    End Sub

    Private Function BuildQuery() As String

        Dim sql As String =
            "SELECT * " &
            "FROM dbo.vwTrnCetakLabelPetani D " &
            "WHERE 1 = 1 "

        If cmbJenisPetani.Text = "Rekening" Then
            sql &= "AND D.NonRekening = 0 "
        ElseIf cmbJenisPetani.Text = "Non Rekening" Then
            sql &= "AND D.NonRekening = 1 "
        End If

        If cmbStatusPrint.Text = "Belum Print" Then
            sql &= "AND ISNULL(D.FlagSudahPrintFoto, 0) = 0 "
        ElseIf cmbStatusPrint.Text = "Sudah Print" Then
            sql &= "AND ISNULL(D.FlagSudahPrintFoto, 0) = 1 "
        End If

        If cmbFotoPetani.Text = "Ada" Then
            sql &= "AND ISNULL(D.StatusVerifFoto, 0) = 1 "
        ElseIf cmbFotoPetani.Text = "Tidak Ada" Then
            sql &= "AND ISNULL(D.StatusVerifFoto, 0) = 0 "
        End If

        If chkPancang.Checked Then
            sql &= "AND D.IDPancang = @IDPancang "
        End If

        If chkPeriode.Checked Then
            sql &= "AND D.CreatedDate >= @TglAwal " &
                   "AND D.CreatedDate < DATEADD(DAY, 1, @TglAkhir) "
        End If

        If txtSearch.Text.Trim <> "" Then
            sql &= "AND (" &
                   "D.IDPetani LIKE @Cari OR " &
                   "D.NamaPetani LIKE @Cari OR " &
                   "D.DivBlokKav LIKE @Cari) "
        End If

        sql &= "ORDER BY D.NamaPetani"

        Return sql

    End Function

    Private Sub ShowData()

        If isLoading Then Exit Sub

        isLoading = True
        Cursor = Cursors.WaitCursor
        fg.Redraw = False

        Try

            Using cn As New SqlConnection(StrConnRMPApp)

                Using cmd As New SqlCommand(BuildQuery(), cn)

                    If chkPancang.Checked Then

                        If cmbPancang.SelectedValue Is Nothing OrElse
                           cmbPancang.SelectedValue Is DBNull.Value Then

                            cmd.Parameters.AddWithValue(
                                "@IDPancang", DBNull.Value
                            )

                        Else

                            cmd.Parameters.AddWithValue(
                                "@IDPancang", cmbPancang.SelectedValue
                            )

                        End If

                    End If

                    If chkPeriode.Checked Then

                        cmd.Parameters.AddWithValue(
                            "@TglAwal", dtpTglAwal.Value.Date
                        )

                        cmd.Parameters.AddWithValue(
                            "@TglAkhir", dtpTglAkhir.Value.Date
                        )

                    End If

                    If txtSearch.Text.Trim <> "" Then

                        cmd.Parameters.AddWithValue(
                            "@Cari", "%" & txtSearch.Text.Trim & "%"
                        )

                    End If

                    Using da As New SqlDataAdapter(cmd)

                        dtData = New DataTable
                        da.Fill(dtData)

                    End Using

                End Using

            End Using

            fg.Rows.Count = 1

            Dim no As Integer = 1

            For Each dr As DataRow In dtData.Rows

                fg.Rows.Add()

                Dim r As Integer = fg.Rows.Count - 1

                fg.Item(r, "No") = no
                fg.Item(r, "Select") = False
                fg.Item(r, "IDPetani") = GetString(dr, "IDPetani")
                fg.Item(r, "NamaPetani") = GetString(dr, "NamaPetani")
                fg.Item(r, "NoRekening") = GetString(dr, "Rekening")
                fg.Item(r, "NoKTP") = GetString(dr, "NoKTP")
                fg.Item(r, "DivBlokKav") = GetString(dr, "DivBlokKav")
                fg.Item(r, "Alamat") = GetString(dr, "Alamat")
                fg.Item(r, "QRCode") = GetString(dr, "QRCode")
                fg.Item(r, "BarCode") = GetString(dr, "Barcode")
                fg.Item(r, "NoHP") = GetString(dr, "NoHP")
                fg.Item(r, "FileAttachment") = GetString(dr, "FileAttachment")

                fg.Item(r, "StatusPrint") =
                    If(GetInteger(dr, "FlagSudahPrintFoto") = 1,
                       "Sudah Print", "Belum Print")

                If Not IsDBNull(dr("CreatedDate")) Then
                    fg.Item(r, "CreatedDate") = CDate(dr("CreatedDate"))
                End If

                fg.Item(r, "FotoPetani") = If(GetInteger(dr, "StatusVerifFoto") = 1, "Ada", "Tidak Ada")

                no += 1

            Next

            fg.AutoSizeCols()

            UpdateSummary()

            cbxSelectAll.Checked = False

        Catch ex As Exception

            MessageBox.Show(
                ex.Message, AT,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        Finally

            fg.Redraw = True
            Cursor = Cursors.Default
            isLoading = False

        End Try

    End Sub

    Private Function GetString(
        dr As DataRow,
        columnName As String
    ) As String

        If IsDBNull(dr(columnName)) Then Return ""

        Return dr(columnName).ToString()

    End Function

    Private Function GetInteger(
        dr As DataRow,
        columnName As String
    ) As Integer

        If IsDBNull(dr(columnName)) Then Return 0

        Return Convert.ToInt32(dr(columnName))

    End Function

    Private Function IsRowSelected(rowIndex As Integer) As Boolean

        If fg.Item(rowIndex, "Select") Is Nothing OrElse
           fg.Item(rowIndex, "Select") Is DBNull.Value Then

            Return False

        End If

        Return Convert.ToBoolean(fg.Item(rowIndex, "Select"))

    End Function

    Private Sub UpdateSummary()

        Dim belum As Integer = 0
        Dim sudah As Integer = 0

        For i As Integer = 1 To fg.Rows.Count - 1

            If fg.Item(i, "StatusPrint").ToString() = "Sudah Print" Then
                sudah += 1
            Else
                belum += 1
            End If

        Next

        lblTotalData.Text = (fg.Rows.Count - 1).ToString()
        lblBelumPrint.Text = belum.ToString()
        lblSudahPrint.Text = sudah.ToString()

    End Sub

    Private Sub btnSearch_Click(
        sender As Object, e As EventArgs
    ) Handles btnSearch.Click

        ShowData()

    End Sub

    Private Sub txtSearch_KeyDown(
        sender As Object, e As KeyEventArgs
    ) Handles txtSearch.KeyDown

        If e.KeyCode = Keys.Enter Then

            ShowData()
            e.SuppressKeyPress = True

        End If

    End Sub

    Private Sub cbxSelectAll_CheckedChanged(
        sender As Object, e As EventArgs
    ) Handles cbxSelectAll.CheckedChanged

        If isLoading Then Exit Sub

        For i As Integer = 1 To fg.Rows.Count - 1
            fg.Item(i, "Select") = cbxSelectAll.Checked
        Next

    End Sub

    Private Sub btnClose_Click(
        sender As Object, e As EventArgs
    ) Handles btnClose.Click

        Close()

    End Sub

    Private Function GetJumlahTerpilih() As Integer

        Dim jumlah As Integer = 0

        For i As Integer = 1 To fg.Rows.Count - 1

            If IsRowSelected(i) Then
                jumlah += 1
            End If

        Next

        Return jumlah

    End Function

    Private Function ValidasiDataCetak() As Boolean

        Dim belumVerifikasi As New List(Of String)

        For i As Integer = 1 To fg.Rows.Count - 1

            If IsRowSelected(i) Then

                If fg.Item(i, "FotoPetani").ToString() <> "Ada" Then

                    belumVerifikasi.Add(
                        fg.Item(i, "IDPetani").ToString() & " - " &
                        fg.Item(i, "NamaPetani").ToString()
                    )

                End If

            End If

        Next

        If belumVerifikasi.Count > 0 Then

            MessageBox.Show(
                "Petani berikut belum diverifikasi fotonya:" &
                vbCrLf & vbCrLf &
                String.Join(vbCrLf, belumVerifikasi),
                AT,
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

            Return False

        End If

        Return True

    End Function

    Private Function GetDataTerpilih() As DataTable

        Dim dt As DataTable = dtData.Clone()

        For i As Integer = 1 To fg.Rows.Count - 1

            If Not IsRowSelected(i) Then Continue For

            Dim idPetani As String =
                fg.Item(i, "IDPetani").ToString()

            Dim rows() As DataRow = dtData.Select(
                "IDPetani = '" & idPetani.Replace("'", "''") & "'"
            )

            If rows.Length > 0 Then
                dt.ImportRow(rows(0))
            End If

        Next

        Return dt

    End Function


    Private Sub btnCetakLabel_Click(
    sender As Object, e As EventArgs
) Handles btnCetakLabel.Click

        Dim jumlah As Integer = GetJumlahTerpilih()

        If jumlah = 0 Then

            MessageBox.Show(
            "Pilih data petani terlebih dahulu.",
            AT,
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning
        )

            Exit Sub

        End If

        If Not ValidasiDataCetak() Then Exit Sub

        If MessageBox.Show(
        "Generate QR Code dan Barcode untuk " &
        jumlah & " petani, kemudian cetak label?",
        AT,
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    ) <> DialogResult.Yes Then Exit Sub

        Cursor = Cursors.WaitCursor

        Try

            Dim dt As DataTable = GetDataTerpilih()

            If dt.Rows.Count = 0 Then
                Throw New Exception("Data petani terpilih tidak ditemukan.")
            End If

            For Each dr As DataRow In dt.Rows
                GenerateQRBarcode(dr)
            Next

            Dim dtRekening As DataTable = dt.Clone()
            Dim dtNonRekening As DataTable = dt.Clone()

            For Each dr As DataRow In dt.Rows

                If Convert.ToBoolean(dr("NonRekening")) Then
                    dtNonRekening.ImportRow(dr)
                Else
                    dtRekening.ImportRow(dr)
                End If

            Next

            If dtRekening.Rows.Count = 0 AndAlso
           dtNonRekening.Rows.Count = 0 Then

                Throw New Exception("Tidak ada data untuk dicetak.")

            End If

            If dtRekening.Rows.Count > 0 Then

                Dim frm As New FrmRptQRbarcode

                frm.TampilkanReport(dtRekening, False)

                FrmMain.BukaMenu(frm, FrmMain.mnuTrnCetakLabelPetani)

            End If

            If dtNonRekening.Rows.Count > 0 Then

                Dim frm As New FrmRptQRbarcode

                frm.TampilkanReport(dtNonRekening, True)

                FrmMain.BukaMenu(frm, FrmMain.mnuTrnCetakLabelPetani)

            End If

            ShowData()

        Catch ex As Exception

            MessageBox.Show(
            ex.Message,
            AT,
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
        )

        Finally

            Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub GenerateQRBarcode(dr As DataRow)

        Dim idPetani As String = GetString(dr, "IDPetani")

        If idPetani = "" Then
            Throw New Exception("IDPetani tidak boleh kosong.")
        End If

        Dim qrName As String = ""
        Dim barcodeName As String = ""

        Dim namaPetani As String = GetString(dr, "NamaPetani")
        Dim noKTP As String = GetString(dr, "NoKTP")
        Dim alamat As String = GetString(dr, "Alamat")
        Dim rekening As String = GetString(dr, "Rekening")
        Dim nonRekening As Boolean =
            Convert.ToBoolean(dr("NonRekening"))

        Dim qrImage As Image = Nothing
        Dim barcodeImage As Image = Nothing

        Try

            ' Periksa apakah record QR/Barcode sudah tersedia.
            Using cn As New SqlConnection(StrConnRMPApp)

                cn.Open()

                Using cmd As New SqlCommand(
                    "SELECT QRCode, Barcode " &
                    "FROM dbo.TblMstQRBarcodePetaniPCG " &
                    "WHERE IDPetani = @IDPetani", cn
                )

                    cmd.Parameters.Add(
                        "@IDPetani", SqlDbType.VarChar, 50
                    ).Value = idPetani

                    Using rd As SqlDataReader = cmd.ExecuteReader()

                        If rd.Read() Then

                            qrName = If(IsDBNull(rd("QRCode")),
                                        "", rd("QRCode").ToString())

                            barcodeName = If(IsDBNull(rd("Barcode")),
                                             "", rd("Barcode").ToString())

                        End If

                    End Using

                End Using

            End Using

            Dim isRecordBaru As Boolean = (qrName = "" OrElse barcodeName = "")

            If isRecordBaru Then

                qrName = "QR" & idPetani
                barcodeName = "BR" & idPetani

                SimpanDataQRBarcode(
                    idPetani,
                    namaPetani,
                    noKTP,
                    alamat,
                    rekening,
                    nonRekening,
                    qrName,
                    barcodeName
                )

            End If

            ' Generate QR Code.
            Dim generator As New QRCodeGenerator

            Using qrData = generator.CreateQrCode(
                idPetani,
                QRCodeGenerator.ECCLevel.Q
            )

                Using qr As New QRCode(qrData)

                    qrImage = qr.GetGraphic(6)

                End Using

            End Using

            ' Generate Barcode CODE 93.
            Dim writer As New BarcodeWriter With {
                .Format = BarcodeFormat.CODE_93
            }

            barcodeImage = writer.Write(idPetani)

            ' Pastikan folder tersedia.
            If Not Directory.Exists(Modul_Config.pathQRCode) Then
                Directory.CreateDirectory(Modul_Config.pathQRCode)
            End If

            If Not Directory.Exists(Modul_Config.pathBarcode) Then
                Directory.CreateDirectory(Modul_Config.pathBarcode)
            End If

            ' Simpan gambar.
            qrImage.Save(
                Path.Combine(
                    Modul_Config.pathQRCode,
                    qrName & ".jpeg"
                ),
                Imaging.ImageFormat.Jpeg
            )

            barcodeImage.Save(
                Path.Combine(
                    Modul_Config.pathBarcode,
                    barcodeName & ".jpeg"
                ),
                Imaging.ImageFormat.Jpeg
            )

            dr("QRCode") = qrName
            dr("Barcode") = barcodeName

        Catch ex As Exception

            Throw New Exception(
                "Gagal generate QR/Barcode petani " &
                idPetani & ": " & ex.Message
            )

        Finally

            If qrImage IsNot Nothing Then qrImage.Dispose()
            If barcodeImage IsNot Nothing Then barcodeImage.Dispose()

        End Try

    End Sub

    Private Sub SimpanDataQRBarcode(
        idPetani As String,
        namaPetani As String,
        noKTP As String,
        alamat As String,
        rekening As String,
        nonRekening As Boolean,
        qrName As String,
        barcodeName As String
    )

        Using cn As New SqlConnection(StrConnRMPApp)

            cn.Open()

            Using cmd As New SqlCommand(
                "spSaveQRBarcode2023", cn
            )

                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@IDPetani", idPetani)
                cmd.Parameters.AddWithValue("@NamaPetani", namaPetani)
                cmd.Parameters.AddWithValue("@NoKTP", noKTP)
                cmd.Parameters.AddWithValue("@Alamat", alamat)
                cmd.Parameters.AddWithValue("@QRCode", qrName)
                cmd.Parameters.AddWithValue("@Barcode", barcodeName)
                cmd.Parameters.AddWithValue("@RekBank", rekening)
                cmd.Parameters.AddWithValue("@CreatedBy", ClsSession.UserID)
                cmd.Parameters.AddWithValue("@NonRekening", nonRekening)

                Dim pFlag As New SqlParameter("@Flag", SqlDbType.Int)
                pFlag.Direction = ParameterDirection.Output
                cmd.Parameters.Add(pFlag)

                cmd.ExecuteNonQuery()

                If IsDBNull(pFlag.Value) OrElse
                   Convert.ToInt32(pFlag.Value) <= 0 Then

                    Throw New Exception(
                        "Data QR/Barcode tidak berhasil disimpan."
                    )

                End If

            End Using

        End Using

    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles fg.BeforeEdit
        If fg.Cols(e.Col).Name = "Select" Then
        Else
            e.Cancel = True
        End If
    End Sub
End Class