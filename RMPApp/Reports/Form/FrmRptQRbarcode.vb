
Imports Microsoft.Reporting.WinForms
Imports System.Data.SqlClient
Imports System.IO

Public Class FrmRptQRbarcode

    Private FolderName As String = cls_Webdav.WebDavGENSupplierFolder

    Private ReadOnly IDPetaniDicetak As New List(Of String)

    Private isUpdatingPrint As Boolean = False
    Private isPrintUpdated As Boolean = False

    Public pathBarcode As String =
        UrlMasterTTPancnag & "QRBarcode2023\Barcode\"

    Public pathQRCode As String =
        UrlMasterTTPancnag & "QRBarcode2023\QRCode\"

    Private Sub FrmRptQRbarcode_Load(
        sender As Object, e As EventArgs
    ) Handles MyBase.Load

    End Sub

    Public Sub TampilkanReport(
        dtPetani As DataTable,
        nonRekening As Boolean
    )

        Try

            If dtPetani Is Nothing OrElse dtPetani.Rows.Count = 0 Then
                Throw New Exception("Tidak ada data petani untuk dicetak.")
            End If

            Cursor = Cursors.WaitCursor

            IDPetaniDicetak.Clear()
            isPrintUpdated = False

            Dim dtReport As DataTable = BuatDataReport(dtPetani)

            If dtReport.Rows.Count = 0 Then
                Throw New Exception("Data laporan tidak ditemukan.")
            End If

            For Each dr As DataRow In dtPetani.Rows

                Dim id As String = GetString(dr, "IDPetani")

                If id <> "" AndAlso Not IDPetaniDicetak.Contains(id) Then
                    IDPetaniDicetak.Add(id)
                End If

            Next

            If IDPetaniDicetak.Count = 0 Then
                Throw New Exception("ID petani untuk dicetak tidak ditemukan.")
            End If

            Dim reportName As String

            If nonRekening Then
                reportName = ".RptBarcodePCGNonRekening.rdlc"
            Else
                reportName = ".RptBarcodePCG_.rdlc"
            End If

            With ReportViewer.LocalReport

                .DataSources.Clear()
                .EnableExternalImages = True
                .EnableHyperlinks = True

                .ReportEmbeddedResource =
                    My.Application.Info.AssemblyName & reportName

                .DataSources.Add(
                    New ReportDataSource("dtrel", dtReport)
                )

            End With

            ReportViewer.SetDisplayMode(DisplayMode.PrintLayout)
            ReportViewer.RefreshReport()

        Catch ex As Exception

            MessageBox.Show(
                ex.Message,
                My.Application.Info.Title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            )

        Finally

            Cursor = Cursors.Default

        End Try

    End Sub

    Private Function BuatDataReport(
        dtPetani As DataTable
    ) As DataTable

        Dim dt As New DataTable

        dt.Columns.Add("namarelasi", GetType(String))
        dt.Columns.Add("idrelasi", GetType(String))
        dt.Columns.Add("Alamat", GetType(String))
        dt.Columns.Add("FileAttachment", GetType(String))
        dt.Columns.Add("qrimg", GetType(String))
        dt.Columns.Add("brimg", GetType(String))
        dt.Columns.Add("NoHP", GetType(String))
        dt.Columns.Add("relimg", GetType(Byte()))

        For Each dr As DataRow In dtPetani.Rows

            Dim idPetani As String = GetString(dr, "IDPetani")
            Dim qrName As String = GetString(dr, "QRCode")
            Dim barcodeName As String = GetString(dr, "Barcode")

            If idPetani = "" Then Continue For

            Dim row As DataRow = dt.NewRow()

            row("namarelasi") = GetString(dr, "NamaPetani")
            row("idrelasi") = idPetani
            row("Alamat") = GetString(dr, "Alamat")
            row("FileAttachment") = GetString(dr, "FileAttachment")
            row("NoHP") = GetString(dr, "NoHP")

            If qrName <> "" Then
                row("qrimg") = Path.Combine(
                    pathQRCode,
                    qrName & ".jpeg"
                )
            Else
                row("qrimg") = ""
            End If

            If barcodeName <> "" Then
                row("brimg") = Path.Combine(
                    pathBarcode,
                    barcodeName & ".jpeg"
                )
            Else
                row("brimg") = ""
            End If

            row("relimg") = DBNull.Value

            Dim foto As String = GetString(dr, "FileAttachment")

            If foto <> "" Then

                Try

                    Using downloadedImage As Image =
                        ClsWebDAV.DownloadFileWebDav(
                            cls_Webdav.WebDavGENSupplier,
                            FolderName,
                            idPetani,
                            foto
                        )

                        If downloadedImage IsNot Nothing Then

                            Using bmp As New Bitmap(downloadedImage)

                                Using ms As New MemoryStream()

                                    bmp.Save(ms, Imaging.ImageFormat.Jpeg)
                                    row("relimg") = ms.ToArray()

                                End Using

                            End Using

                        End If

                    End Using

                Catch

                    row("relimg") = DBNull.Value

                End Try

            End If

            dt.Rows.Add(row)

        Next

        Return dt

    End Function

    Private Function GetString(
        dr As DataRow,
        columnName As String
    ) As String

        If Not dr.Table.Columns.Contains(columnName) Then Return ""
        If IsDBNull(dr(columnName)) Then Return ""

        Return dr(columnName).ToString().Trim()

    End Function

    Private Sub ReportViewer_Print(
        sender As Object,
        e As ReportPrintEventArgs
    ) Handles ReportViewer.Print

        If isUpdatingPrint OrElse isPrintUpdated Then Exit Sub
        If IDPetaniDicetak.Count = 0 Then Exit Sub

        isUpdatingPrint = True

        Try

            Using cn As New SqlConnection(StrConnRMPApp)

                cn.Open()

                Using tran As SqlTransaction = cn.BeginTransaction()

                    Try

                        Using cmd As New SqlCommand(
                            "UPDATE RSUPAccounting.dbo.tblRMMstSupplier " &
                            "SET FlagSudahPrintFoto = 1 " &
                            "WHERE KodeSup = @IDPetani",
                            cn,
                            tran
                        )

                            cmd.Parameters.Add(
                                "@IDPetani",
                                SqlDbType.VarChar,
                                50
                            )

                            For Each id As String In IDPetaniDicetak

                                cmd.Parameters("@IDPetani").Value = id
                                cmd.ExecuteNonQuery()

                            Next

                        End Using

                        tran.Commit()
                        isPrintUpdated = True

                    Catch

                        tran.Rollback()
                        Throw

                    End Try

                End Using

            End Using

        Catch ex As Exception

            MessageBox.Show(
                "Proses cetak telah dipanggil, tetapi status print " &
                "gagal diperbarui." & vbCrLf & ex.Message,
                My.Application.Info.Title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            )

        Finally

            isUpdatingPrint = False

        End Try

    End Sub

End Class
