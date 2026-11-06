Imports System.Data.SqlClient
Imports System.Globalization
Imports C1.C1Rdl
Imports C1.Win.C1Themes

Public Class FrmMstHargaBeliBahanBaku
    Dim cmds As SqlCommand
    Dim kodehargastring As String
    Public perintah As String


    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ClearData()
        EnableDisableControls(True)
        EnableComandButtons(False)

        perintah = "Add"

        dtpTgl.Focus()
    End Sub

    Public Sub ListLavel()
        Dim i As Integer = 1

        Using cmd As New SqlCommand("SELECT IDPancang, Pancang FROM Android_tblMstPancang", DB.OpenConnection(StrConnRMPApp))
            Using qrd2 As SqlDataReader = cmd.ExecuteReader()

                fg.Rows.Count = 1
                fg.Cols.Count = 3

                fg.Item(0, 0) = "No"
                fg.Item(0, 1) = "ID Pancang"
                fg.Cols(1).Name = "IDPancang"
                fg.Item(0, 2) = "Pancang"
                fg.Cols(2).Name = "Pancang"

                While qrd2.Read()
                    fg.AddItem(
                        i & vbTab &
                        qrd2("IDPancang").ToString() & vbTab &
                        qrd2("Pancang").ToString()
                    )
                    i += 1
                End While

            End Using
        End Using
    End Sub

    Private Sub HEADERADD()

        Try
            If cmbBahanBaku.Text <> "" Then
                Using conny As New SqlConnection(StrConnRMPApp)
                    conny.Open()

                    Dim sqlx As String = "SELECT KodeGrade, (Grade + ' ' + JenisSupplier) AS Grade FROM tblMstHeaderHargaBahanBaku WHERE KD_Jenis = @KD_Jenis"

                    Using cmdselect As New SqlCommand(sqlx, conny)
                        cmdselect.Parameters.AddWithValue("@KD_Jenis", cmbBahanBaku.SelectedValue.ToString())

                        Using RD As SqlDataReader = cmdselect.ExecuteReader()

                            Dim x As Integer = 3

                            If fg.Cols.Count < 2 Then
                                fg.Cols.Count = 3
                            End If

                            While RD.Read()
                                fg.Cols.Count += 1

                                fg.Cols(x).Name = RD("KodeGrade").ToString()
                                fg.Cols(x).Caption = RD("Grade").ToString()
                                fg.Cols(x).Format = "n0"
                                fg.Cols(x).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter
                                fg.Cols(x).Width = 100
                                fg.Cols(x).DataType = GetType(Double)

                                x += 1
                            End While

                        End Using
                    End Using
                End Using
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub changedataadd()
        If perintah = "Add" Then
            HEADERADD()
        End If
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click

        Dim KodeHarga As String = ""
        Dim Koneksi As SqlConnection = Nothing
        Dim Transaksi As SqlTransaction = Nothing

        Try
            Me.Cursor = Cursors.WaitCursor

            If cmbJenisWilayah.Text = "" Then
                MsgBoxCustom.Show("Isi Jenis Wilayah!", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
                Exit Sub
            End If

            ' Guard tambahan: cegah NullReferenceException jika belum ada Grade/Bahan Baku dipilih.
            If cmbBahanBaku.Text = "" Then
                MsgBoxCustom.Show("Isi Bahan Baku!", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
                Exit Sub
            End If

            If (cmbGradeSub.Text = "") AndAlso (cmbBahanBaku.SelectedValue.ToString() = "JB" OrElse cmbBahanBaku.SelectedValue.ToString() = "LC") Then
                MsgBoxCustom.Show("Isi Grade Sub!", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
                Exit Sub
            End If

            Koneksi = DB.OpenConnection(StrConnRMPApp)
            Transaksi = Koneksi.BeginTransaction()

            If Not SimpanDataHdr(Koneksi, Transaksi, KodeHarga) Then
                Transaksi.Rollback()
                MsgBoxCustom.Show("Simpan Master Harga Bahan Baku (Kg) Hdr Gagal", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
                Exit Sub
            End If

            For col As Integer = 3 To fg.Cols.Count - 1
                For row As Integer = 1 To fg.Rows.Count - 1
                    If Not SimpanDataDtl(Koneksi, Transaksi, KodeHarga, col, row) Then
                        Transaksi.Rollback()
                        MsgBoxCustom.Show("Simpan Master Harga Bahan Baku (Kg) Dtl Gagal", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
                        Exit Sub
                    End If
                Next
            Next

            Transaksi.Commit()

            MsgBoxCustom.Show("Simpan data berhasil", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)

            ClearData()
            EnableDisableControls(False)
            EnableComandButtons(True)

            LoadData(KodeHarga)
        Catch ex As Exception
            If Transaksi IsNot Nothing Then
                Try
                    Transaksi.Rollback()
                Catch
                End Try
            End If
            MsgBoxCustom.Show(ex.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)

        Finally
            If Koneksi IsNot Nothing Then
                Koneksi.Close()
                Koneksi.Dispose()
            End If
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    ' Menyimpan header transaksi. Menggunakan Using agar SqlCommand pasti di-dispose.
    Private Function SimpanDataHdr(ByVal Conn2 As SqlConnection, ByVal Trans As SqlTransaction, ByRef KodeHarga As String) As Boolean
        SimpanDataHdr = False

        Dim asal As String = If(rdDarat.Checked, "Darat", "Laut")

        Try
            Using cqd As New SqlCommand()
                cqd.Connection = Conn2
                cqd.CommandType = CommandType.StoredProcedure
                cqd.CommandText = "spMstHargaBeliBahanBakuHdr"
                cqd.Transaction = Trans

                cqd.Parameters.Add("@Perintah", SqlDbType.VarChar, 20).Value = perintah
                Dim parKode As SqlParameter = cqd.Parameters.Add("@KodeHargaString", SqlDbType.VarChar, 30)
                parKode.Direction = ParameterDirection.InputOutput
                parKode.Value = If(perintah = "Add", "", txtnotrans.Text)
                cqd.Parameters.Add("@kodeBahanBaku", SqlDbType.VarChar).Value = cmbBahanBaku.SelectedValue.ToString()
                cqd.Parameters.Add("@BahanBaku", SqlDbType.VarChar).Value = cmbBahanBaku.Text
                cqd.Parameters.Add("@Asal", SqlDbType.VarChar).Value = asal
                cqd.Parameters.Add("@Periode", SqlDbType.Date).Value = dtpTgl.Value.Date
                cqd.Parameters.Add("@SubGrade", SqlDbType.VarChar).Value = cmbGradeSub.SelectedValue.ToString()
                cqd.Parameters.Add("@NotActive", SqlDbType.Bit).Value = chkNotActive.Checked
                cqd.Parameters.Add("@JenisWilayah", SqlDbType.VarChar, 50).Value = cmbJenisWilayah.Text
                cqd.Parameters.Add("@CreatedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
                cqd.Parameters.Add("@LastUpdatedBy", SqlDbType.VarChar, 50).Value = ClsSession.UserID
                Dim parFlag As SqlParameter = cqd.Parameters.Add("@Flag", SqlDbType.SmallInt)
                parFlag.Direction = ParameterDirection.InputOutput
                parFlag.Value = 0

                cqd.ExecuteNonQuery()

                If parFlag.Value = 0 Then
                    MsgBoxCustom.Show("Simpan data gagal!", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
                    Return False
                End If

                KodeHarga = parKode.Value.ToString()
                Return True
            End Using
        Catch ex As Exception
            MsgBoxCustom.Show(ex.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
        End Try
    End Function

    ' Menyimpan detail harga per baris/kolom. Exception message asli sekarang tidak lagi
    ' "tertutupi" oleh error kedua (dulu mereferensikan parameter @Error yang tidak pernah dibuat).
    Private Function SimpanDataDtl(ByVal Conn As SqlConnection, ByVal Trans As SqlTransaction, ByVal kodeharga As String, ByVal col As Integer, ByVal row As Integer) As Boolean
        Try
            Using myCmd As New SqlCommand()
                myCmd.Connection = Conn
                myCmd.CommandType = CommandType.StoredProcedure
                myCmd.CommandText = "spMstHargaBeliBahanBakuDtl"
                myCmd.Transaction = Trans

                myCmd.Parameters.Add("@KodeHargaString", SqlDbType.VarChar).Value = kodeharga
                myCmd.Parameters.Add("@IDPancang", SqlDbType.Int).Value = fg.Item(row, "IDPancang")
                myCmd.Parameters.Add("@KodeGrade", SqlDbType.VarChar).Value = fg.Cols(col).Name
                myCmd.Parameters.Add("@Harga", SqlDbType.Decimal, 18, 2).Value = ParseHarga(fg.Item(row, col))
                myCmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = ClsSession.UserID
                myCmd.Parameters.Add("@LastUpdatedBy", SqlDbType.VarChar).Value = ClsSession.UserID
                Dim parFlag As SqlParameter = myCmd.Parameters.Add("@Flag", SqlDbType.SmallInt)
                parFlag.Direction = ParameterDirection.InputOutput
                parFlag.Value = 0

                myCmd.ExecuteNonQuery()

                If parFlag.Value = 0 Then
                    MsgBoxCustom.Show("Simpan data gagal!", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Warning)
                    Return False
                End If

                Return True
            End Using
        Catch ex As Exception
            MsgBoxCustom.Show(ex.Message, MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Error)
            Return False
        End Try

        Return True
    End Function

    ' Parsing angka yang lebih aman daripada Val() (Val selalu pakai titik sebagai desimal,
    ' tidak cocok untuk input locale Indonesia yang biasa pakai koma).
    Private Function ParseHarga(ByVal cellValue As Object) As Double
        If cellValue Is Nothing OrElse IsDBNull(cellValue) Then Return 0

        Dim text As String = cellValue.ToString()
        If String.IsNullOrWhiteSpace(text) Then Return 0

        Dim result As Double
        If Double.TryParse(text, NumberStyles.Any, CultureInfo.CurrentCulture, result) Then
            Return result
        End If
        If Double.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, result) Then
            Return result
        End If

        Return 0
    End Function

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ClearData()
        EnableDisableControls(False)
        EnableComandButtons(True)
    End Sub

    Private Sub btnfind_Click(sender As Object, e As EventArgs) Handles BTNFIND.Click
        FrmMstHargaBeliBahanBakuShow.Show()
    End Sub

    Public Sub LoadData(ByVal KodeHarga As String)
        EnableDisableControls(False)
        EnableComandButtons(True)
        ClearData()

        Dim dt As DataTable = New DataTable
        Dim sql As String = "SELECT KodeHargaString, kodebahanbaku, BahanBaku, Asal, Periode, 
                                CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, SubGrade, isnull(JenisWilayah, '') as JenisWilayah
                                FROM tblRMMstHargaBahanBakuHdr 
                                WHERE kodehargastring ='" & KodeHarga & "'"

        dt = DB.ExecuteQuery(StrConnRMPApp, sql)

        txtnotrans.Text = dt.Rows(0)("KodeHargaString").ToString()
        dtpTgl.Value = CDate(dt.Rows(0)("Periode"))
        cmbBahanBaku.SelectedValue = dt.Rows(0)("kodebahanbaku")
        Select Case If(dt.Rows(0)("Asal") Is Nothing, "", dt.Rows(0)("Asal").ToString())
            Case "Darat"
                rdDarat.Checked = True
            Case "Laut"
                rdklaut.Checked = True
        End Select
        cmbJenisWilayah.Text = dt.Rows(0)("JenisWilayah").ToString()
        cmbGradeSub.Text = dt.Rows(0)("SubGrade").ToString()

        SelectedIndexChanged()
        ShowdataDTL(KodeHarga)
    End Sub

    ' Diperbaiki: dulu query harga dijalankan per SEL grid (N x M query, dan rawan SQL Injection
    ' karena string SQL digabung langsung). Sekarang: 1 query untuk ambil semua detail harga,
    ' lalu diisi ke grid dari Dictionary di memori — jauh lebih cepat dan aman.
    Public Sub ShowdataDTL(NOTRANS As String)

        Dim i As Integer = 1
        Dim sqlMaster As String = "SELECT IDPancang, Pancang FROM RMPApp..Android_tblMstPancang"
        Dim sqlDetail As String = "SELECT IDPancang, KodeGrade, Harga FROM RMPApp..tblRMMstHargaBahanBakuDtl WHERE KodeHargaString = @KodeHargaString"

        Dim hargaMap As New Dictionary(Of String, String)

        Using cn As SqlConnection = DB.OpenConnection(StrConnRMPApp)

            Using cmdDetail As New SqlCommand(sqlDetail, cn)
                cmdDetail.Parameters.Add("@KodeHargaString", SqlDbType.VarChar, 35).Value = NOTRANS

                Using drDetail As SqlDataReader = cmdDetail.ExecuteReader()
                    While drDetail.Read()
                        Dim key As String = drDetail("IDPancang").ToString() & "|" & drDetail("KodeGrade").ToString()
                        hargaMap(key) = drDetail("Harga").ToString()
                    End While
                End Using
            End Using

            Using cmdMaster As New SqlCommand(sqlMaster, cn)
                Using dr As SqlDataReader = cmdMaster.ExecuteReader()

                    fg.Rows.Count = 1

                    If dr.HasRows Then
                        While dr.Read()

                            Dim row As Integer = fg.Rows.Count
                            Dim idPancang As String = dr("IDPancang").ToString()

                            fg.AddItem(i & vbTab & idPancang & vbTab & dr("Pancang").ToString())

                            For x As Integer = 3 To fg.Cols.Count - 1
                                Dim key As String = idPancang & "|" & fg.Cols(x).Name
                                fg(row, x) = If(hargaMap.ContainsKey(key), hargaMap(key), "")
                            Next

                            i += 1
                        End While

                        fg.AutoSizeCols()
                    Else
                        MsgBox("Data tidak ditemukan!")
                    End If

                End Using
            End Using

        End Using

        fg.Rows.Count = Math.Max(fg.Rows.Count, 1)

    End Sub

    Public Sub HEADERfind(KodeHarga As String)

        Using conny As New SqlConnection(StrConnPSGRMP)
            conny.Open()

            Dim sqlx As String =
                "SELECT KodeGrade, Nama_Grade " &
                "FROM vwRMMstHargaBahanBakuGradeHdr " &
                "WHERE KodeHarga = @KodeHarga"

            Using cmdselect As New SqlCommand(sqlx, conny)
                cmdselect.Parameters.Add("@KodeHarga", SqlDbType.VarChar, 20).Value = KodeHarga

                Using RD As SqlDataReader = cmdselect.ExecuteReader()
                    fg.Cols.Count = 2

                    While RD.Read()
                        Dim x As Integer = fg.Cols.Count
                        fg.Cols.Count += 1

                        With fg.Cols(x)
                            .Name = RD("KodeGrade").ToString()
                            .Caption = RD("Nama_Grade").ToString()
                            .Format = "n0"
                            .Width = 220
                            .DataType = GetType(Double)
                        End With
                    End While
                End Using
            End Using
        End Using

    End Sub

    Private Sub cmbGrade_KB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBahanBaku.SelectedIndexChanged
        SelectedIndexChanged()
    End Sub

    Private Sub SelectedIndexChanged()
        ListLavel()
        HEADERADD()
        fg.AutoSizeCols()
    End Sub


    Private Sub FrmMasterHargaBahanBakuPancang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Combo.SetJenisByKDJenis(cmbBahanBaku)
        Combo.SUBGRADE(cmbGradeSub)
        Combo.JenisWilayah(cmbJenisWilayah)

        Clsfg.ApplyStyle(fg)

        EnableDisableControls(False)
        EnableComandButtons(True)
        ClearData()
    End Sub

    Private Sub EnableDisableControls(enable As Boolean)
        dtpTgl.Enabled = enable
        cmbBahanBaku.Enabled = enable
        cmbGradeSub.Enabled = enable
        rdDarat.Enabled = enable
        rdklaut.Enabled = enable
        cmbJenisWilayah.Enabled = enable
        chkNotActive.Enabled = enable
    End Sub

    Private Sub EnableComandButtons(enable As Boolean)
        btnAdd.Enabled = enable
        btnEdit.Enabled = enable
        btnsave.Enabled = Not enable
        btnCancel.Enabled = Not enable
    End Sub

    Private Sub ClearData()
        perintah = ""

        txtnotrans.Text = ""
        dtpTgl.Value = Now
        cmbBahanBaku.SelectedIndex = -1
        cmbGradeSub.SelectedIndex = -1
        rdDarat.Checked = True
        cmbJenisWilayah.SelectedIndex = -1
        chkNotActive.Checked = False

        fg.Rows.Count = 1
        fg.Cols.Count = 3
    End Sub

    Private Sub PasteCells()

        Dim s As String = Clipboard.GetText()
        If String.IsNullOrWhiteSpace(s) Then Exit Sub

        Dim ri As Integer = fg.Row
        Dim ci As Integer = fg.Col

        For Each r As String In s.Split({ControlChars.CrLf}, StringSplitOptions.RemoveEmptyEntries)
            If ri >= fg.Rows.Count Then Exit For

            Dim Cell As Integer = ci
            For Each c As String In r.Split(ControlChars.Tab)
                If Cell >= fg.Cols.Count Then Exit For
                fg(ri, Cell) = c
                Cell += 1
            Next

            ri += 1
        Next

    End Sub

    ' Digabung dengan fg_KeyDown di bawah. Sebelumnya method ini terpisah, memanggil
    ' CopyCells() yang tidak pernah didefinisikan (gagal compile) dan tidak punya
    ' klausa "Handles" sehingga tidak pernah ter-trigger sama sekali.
    Private Sub fg_KeyDown(sender As Object, e As KeyEventArgs) Handles fg.KeyDown
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.C
                    fg.Copy()
                    e.SuppressKeyPress = True
                Case Keys.V
                    PasteCells()
                    e.SuppressKeyPress = True
            End Select
        End If
    End Sub

    ' Ditambahkan "Handles btnEdit.Click" — sebelumnya tidak ada, jadi tombol Edit
    ' kemungkinan besar tidak pernah berfungsi.
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        perintah = "Edit"

        If txtnotrans.Text = "" Then
            MsgBoxCustom.Show("Tidak ada data yang di Edit, Klik data terlebih dahulu", MsgBoxCustom.ButtonType.OK, MsgBoxCustom.IconType.Information)
            Exit Sub
        End If

        EnableComandButtons(False)
        EnableDisableControls(True)
    End Sub

    Private Sub fg_BeforeEdit(sender As Object, e As C1.Win.C1FlexGrid.RowColEventArgs) Handles fg.BeforeEdit
        If fg.Rows.Count <= 1 Or fg.Cols.Count <= 3 Then
            e.Cancel = True
        Else
            Select Case perintah
                Case "Add", "Edit"
                Case Else
                    e.Cancel = True
            End Select
        End If
    End Sub
End Class