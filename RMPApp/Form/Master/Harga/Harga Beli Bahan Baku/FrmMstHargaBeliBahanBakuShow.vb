Imports System.Data.SqlClient

Public Class FrmMstHargaBeliBahanBakuShow

    Private Sub ListData()

        Dim i As Integer = 1
        Dim sql As String =
            "SELECT KodeHargaString, kodebahanbaku, BahanBaku, Asal, Periode, " &
            "CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, SubGrade " &
            "FROM RMPApp..tblRMMstHargaBahanBakuHdr " &
            "WHERE ISNULL(NotActive, 0) = 0 " &
            "AND Periode BETWEEN @Tanggal1 AND @Tanggal2 " &
            "ORDER BY Periode DESC"

        Using conn As SqlConnection = DB.OpenConnection(StrConnAccounting)
            Using cmd As New SqlCommand(sql, conn)

                cmd.Parameters.Add("@Tanggal1", SqlDbType.DateTime).Value = dtTanggal1.Value.Date
                cmd.Parameters.Add("@Tanggal2", SqlDbType.DateTime).Value = dtTanggal2.Value.Date.AddDays(1).AddTicks(-1)

                Using DR As SqlDataReader = cmd.ExecuteReader()

                    fg.Rows.Count = 1

                    If Not DR.HasRows Then
                        MsgBox("Data Tidak ditemukan !", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    While DR.Read()

                        fg.AddItem(
                            i & vbTab &
                            DR("KodeHargaString").ToString() & vbTab &
                            If(IsDBNull(DR("kodebahanbaku")), "", DR("kodebahanbaku").ToString()) & vbTab &
                            If(IsDBNull(DR("BahanBaku")), "", DR("BahanBaku").ToString()) & vbTab &
                            If(IsDBNull(DR("Asal")), "", DR("Asal").ToString()) & vbTab &
                            If(IsDBNull(DR("Periode")), "", DR("Periode").ToString()) & vbTab &
                            If(IsDBNull(DR("CreatedBy")), "", DR("CreatedBy").ToString()) & vbTab &
                            If(IsDBNull(DR("CreatedDate")), "", DR("CreatedDate").ToString()) & vbTab &
                            If(IsDBNull(DR("LastUpdatedBy")), "", DR("LastUpdatedBy").ToString()) & vbTab &
                            If(IsDBNull(DR("LastUpdatedDate")), "", DR("LastUpdatedDate").ToString()) & vbTab &
                            If(IsDBNull(DR("SubGrade")), "", DR("SubGrade").ToString())
                        )

                    End While

                    fg.AutoSizeCols()
                End Using

            End Using
        End Using

    End Sub


    Private Sub FrmMasterHargaBahanBakuPancangFind_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        BringToFront()

        dtTanggal1.Value = New Date(Now.Year, Now.Month, 1)
        dtTanggal2.Value = dtTanggal1.Value.AddMonths(1).AddDays(-1)

        fg.Rows.Count = 1

        Clsfg.ApplyStyle(fg)
    End Sub


    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        ListData()
    End Sub


    Private Sub fg_DoubleClick(sender As Object, e As EventArgs) Handles fg.DoubleClick
        If fg.Row < 1 Then Exit Sub

        With FrmMstHargaBeliBahanBaku
            .LoadData(fg.Item(fg.Row, "KodeHargaString"))
        End With

        Me.Dispose()
    End Sub

End Class