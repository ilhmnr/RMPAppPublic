Imports System.Data.SqlClient
Imports C1.Win
Imports C1.Win.C1FlexGrid
Public Class FrmMonUangMakanPCGDataPancangManual
    Public idpersonil As String
    Public tanggal As String
    Private Sub DataPancangManualShow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HeaderFG()
        ShowData(idpersonil, tanggal)
    End Sub

    Public Sub HeaderFG()
        Dim txt As CellRange
        With fg
            .AllowEditing = True
            .Font = New System.Drawing.Font("Century Gothic", 7.5!, System.Drawing.FontStyle.Regular)
            .Cols.Count = 15
            .AllowMergingFixed = AllowMergingEnum.FixedOnly
            .Styles.Fixed.BackColor = Color.FromArgb(240, 248, 254)
            .Styles.Alternate.BackColor = Color.White
            .Rows(0).StyleFixedNew.BackColor = Color.FromArgb(179, 229, 252)
            .Rows(0).StyleNew.BackColor = Color.FromArgb(179, 229, 252)

            .VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Custom
            .Styles.Normal.WordWrap = True
            .Rows.Fixed = 1
            .AllowMerging = AllowMergingEnum.FixedOnly
            .Rows(0).AllowMerging = True
            .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

            txt = .GetCellRange(0, 0, 0, 0) : txt.Data = "NO" : .Cols(0).Width = 50 : .Cols(0).AllowMerging = True
            txt = .GetCellRange(0, 1, 0, 1) : txt.Data = "ID" : .Cols(1).TextAlign = TextAlignEnum.CenterCenter : .Cols(1).AllowMerging = True : .Cols(1).AllowEditing = False : .Cols(1).Visible = False
            txt = .GetCellRange(0, 2, 0, 2) : txt.Data = "TANGGAL" : .Cols(2).TextAlign = TextAlignEnum.CenterCenter : .Cols(2).AllowMerging = True : .Cols(2).AllowEditing = False
            txt = .GetCellRange(0, 3, 0, 3) : txt.Data = "BAGIAN" : .Cols(3).TextAlign = TextAlignEnum.CenterCenter : .Cols(3).AllowMerging = True : .Cols(3).AllowEditing = False
            txt = .GetCellRange(0, 4, 0, 4) : txt.Data = "ID PERSONIL" : .Cols(4).TextAlign = TextAlignEnum.CenterCenter : .Cols(4).AllowMerging = True : .Cols(4).AllowEditing = False
            txt = .GetCellRange(0, 5, 0, 5) : txt.Data = "NAMA" : .Cols(5).TextAlign = TextAlignEnum.LeftCenter : .Cols(5).AllowMerging = True : .Cols(5).AllowEditing = False
            txt = .GetCellRange(0, 6, 0, 6) : txt.Data = "JABATAN" : .Cols(6).TextAlign = TextAlignEnum.CenterCenter : .Cols(6).AllowMerging = True : .Cols(6).AllowEditing = False
            txt = .GetCellRange(0, 7, 0, 7) : txt.Data = "ID PANCANG" : .Cols(7).TextAlign = TextAlignEnum.CenterCenter : .Cols(7).AllowMerging = True : .Cols(7).AllowEditing = False : .Cols(7).Visible = False
            txt = .GetCellRange(0, 8, 0, 8) : txt.Data = "PANCANG" : .Cols(8).TextAlign = TextAlignEnum.LeftCenter : .Cols(8).AllowMerging = True : .Cols(8).AllowEditing = False
            txt = .GetCellRange(0, 9, 0, 9) : txt.Data = "KEHADIRAN" : .Cols(9).TextAlign = TextAlignEnum.CenterCenter : .Cols(9).AllowMerging = True : .Cols(9).AllowEditing = False
            txt = .GetCellRange(0, 10, 0, 10) : txt.Data = "FOTO" : .Cols(10).TextAlign = TextAlignEnum.CenterCenter : .Cols(10).AllowMerging = True : .Cols(10).AllowEditing = False
            txt = .GetCellRange(0, 11, 0, 11) : txt.Data = "KETERANGAN" : .Cols(11).TextAlign = TextAlignEnum.LeftCenter : .Cols(11).AllowMerging = True : .Cols(11).AllowEditing = False
            txt = .GetCellRange(0, 12, 0, 12) : txt.Data = "CREATED BY" : .Cols(12).TextAlign = TextAlignEnum.CenterCenter : .Cols(12).AllowMerging = True : .Cols(12).AllowEditing = False
            txt = .GetCellRange(0, 13, 0, 13) : txt.Data = "CREATED DATE" : .Cols(13).TextAlign = TextAlignEnum.CenterCenter : .Cols(13).AllowMerging = True : .Cols(13).AllowEditing = False
            txt = .GetCellRange(0, 14, 0, 14) : txt.Data = "CREATED COMP" : .Cols(14).TextAlign = TextAlignEnum.CenterCenter : .Cols(14).AllowMerging = True : .Cols(14).AllowEditing = False

            .AutoSizeCols()
        End With
    End Sub


    Private Sub ShowData(idpersonil As String, tanggal As String)
        Cursor = Cursors.WaitCursor
        Dim i As Integer = 1
        Dim sql As String = ""
        Dim dt As DataTable = New DataTable()

        Try
            dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT * FROM TblAbsensiManualPersonilPCG WHERE Deleted = 0 AND cast(Tanggal as date) ='" & tanggal & "' AND idpersonil= '" & idpersonil & "'")

            If dt.Rows.Count > 0 Then
                With fg
                    .Rows.Count = 1
                    For Each row As DataRow In dt.Rows
                        .AddItem(i)
                        .Item(i, 1) = row.Item("ID")
                        .Item(i, 2) = row.Item("Tanggal")
                        .Item(i, 3) = row.Item("Bagian")
                        .Item(i, 4) = row.Item("IDPersonil")
                        .Item(i, 5) = row.Item("Nama")
                        .Item(i, 6) = row.Item("Jabatan")
                        .Item(i, 7) = row.Item("IDPancang")
                        .Item(i, 8) = row.Item("Pancang")
                        .Item(i, 9) = row.Item("Kehadiran")
                        .Item(i, 10) = row.Item("Foto")
                        .Item(i, 11) = row.Item("Keterangan")
                        .Item(i, 12) = row.Item("CreatedBy")
                        .Item(i, 13) = row.Item("CreatedDate")
                        .Item(i, 14) = row.Item("CreatedComp")
                        i = i + 1
                    Next
                    .AutoSizeCols()
                End With
            Else
                MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
                fg.Rows.Count = 1
            End If
        Catch EX As Exception
            MsgBox(EX.Message)
        End Try

        Cursor = Cursors.Default
    End Sub

End Class