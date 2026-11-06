
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports C1.Win.C1FlexGrid
Imports Excel = Microsoft.Office.Interop.Excel
Public Class FrmMonKapalSelesaiPancang
    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub FrmMonKapalSelesaiPancang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtp1.Value = Format(Now, "yyyy-MM-dd")
        dtp2.Value = Format(Now, "yyyy-MM-dd")

        Modul_RMP.Combo.SetPancang(cmbPancang)
        Modul_RMP.Combo.SetKapal(cmbKapal)
        rdP2.Checked = True
    End Sub

    Private Sub chkPancang_CheckedChanged(sender As Object, e As EventArgs) Handles chkPancang.CheckedChanged
        If chkPancang.Checked = True Then
            cmbPancang.Enabled = True
        Else
            cmbPancang.Enabled = False
            cmbPancang.Text = ""
        End If
    End Sub

    Private Sub ChkKapal_CheckedChanged(sender As Object, e As EventArgs) Handles ChkKapal.CheckedChanged
        If ChkKapal.Checked = True Then
            cmbKapal.Enabled = True
        Else
            cmbKapal.Enabled = False
            cmbKapal.Text = ""
        End If
    End Sub

    Private Sub chkTgl_CheckedChanged(sender As Object, e As EventArgs) Handles chkTgl.CheckedChanged
        If chkTgl.Checked = True Then
            dtp1.Enabled = True
            dtp2.Enabled = True
        Else
            dtp1.Enabled = False
            dtp2.Enabled = False
        End If
    End Sub

    Private Sub btncaridata_Click(sender As Object, e As EventArgs) Handles btncaridata.Click
        loaddata()
    End Sub
    Private Sub loaddata()
        Try
            Dim SQL, SQL2, SQL3 As String, i As Integer

            If chkPancang.Checked = True Then

                SQL2 = Modul_RMP.Func.SetCondition(SQL2, "a.IDPancang = '" & cmbPancang.SelectedValue & "'")

            End If

            If chkTgl.Checked = True Then

                ' SQL2 = " And ((convert(date,convert(varchar,TglInvoice,103),103) between convert (date,'" & dtp1.Value & "',103) and convert(date,'" & dtp2.Value & "',103)))"
                SQL2 = Modul_RMP.Func.SetCondition(SQL2, " CONVERT(DATE,CONVERT(VARCHAR,MT.CloseDate,103),103) BETWEEN CONVERT (DATETIME,'" & dtp1.Value & "',103) AND CONVERT(DATETIME,'" & dtp2.Value & "',103)")

            End If

            If rdP1.Checked = True Then
                SQL2 = Modul_RMP.Func.SetCondition(SQL2, "a.bONGKAR = 'PSG'")

            ElseIf rdP2.Checked = True Then
                SQL2 = Modul_RMP.Func.SetCondition(SQL2, "a.bONGKAR = 'RSUP'")

            End If


            SQL = "  select c.IDPancang , c.Pancang,CASE WHEN A.JENIS= 'Licin' THEN sum(A.NettoAkhir) END as licin, " &
                     " Case When A.JENIS= 'Jambul' THEN sum(A.NettoAkhir) END as jambul,a.IDKapal,mt.NamaKapal , " &
                    " b.Kap As kapasitas,MT.CloseDate As  EndTimbangDate, " &
                    " sum(a.TotalRupiahAkhir) as TotalRp from [TblTrnKelapaHdr]  as a  left join tblMstKapal as B on A.IDKapal=B.KapalID  " &
                    " Left Join tblMstAwalTripPancang as C on C.IDKapal=A.IDKapal   And a.AwalTripID=c.id  " &
                     " left join Android_tblBookingKapalMuat as mt on c.IDBooking =mt.DetailID  " &
                    " where  mt.BookingID is null and  " &
                    "  a.IDPancang<>8 and StatusBooking='Close' and BookingID is null and (a.Deleted is null or a.Deleted =0)  " & IIf(SQL2 = "", "", " AND " & SQL2) & " group by a.IDKapal,mt.NamaKapal, MT.CloseDate,c.Pancang,c.IDPancang,a.jenis,c.id,a.AwalTripID,a.deleted,b.kap"


            Using koneksi As New SqlCommand(SQL, DB.OpenConnection(StrConnRMPApp))
                Using DR = koneksi.ExecuteReader()
                    If DR.HasRows Then
                        dgvList.RowCount = 0
                        While DR.Read
                            With dgvList
                                .Rows.Add()
                                .Item("no", i).Value = i + 1
                                .Item("TanggalSelesaiTimbang", i).Value = DR!EndTimbangDate
                                .Item("Pancang", i).Value = DR!IDPancang & "." & DR!Pancang
                                .Item("Licin", i).Value = DR!Licin & ""
                                .Item("Jambul", i).Value = DR!Jambul & ""
                                .Item("Kapal", i).Value = DR!IDKapal & "." & DR!NamaKapal
                                .Item("Kapasitas", i).Value = DR!Kapasitas
                                .Item("TotalRp", i).Value = DR!TotalRp

                                With Me.dgvList

                                    .Rows(i).Cells("No").Style.BackColor = Color.FromArgb(240, 240, 240)
                                End With
                            End With
                            i += 1
                        End While


                    Else
                        dgvList.Rows.Clear()
                        MsgBox("Data Tidak ditemukan ! ", MsgBoxStyle.Information)
                        Exit Sub
                    End If

                    DR.Close()
                End Using
            End Using
            DB.CloseConnection()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        ExportExcel(dgvList)
    End Sub

    Sub ExportExcel(ByVal obj As Object)
        Dim xlapp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim i As Integer
        Dim j As Integer

        xlapp = New Excel.Application
        xlWorkBook = xlapp.Workbooks.Add(misValue)
        xlWorkSheet = CType(xlWorkBook.Sheets("Sheet1"), Excel.Worksheet)

        For k = 0 To dgvList.ColumnCount - 1
            xlWorkSheet.Cells(1, k + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            xlWorkSheet.Cells(1, k + 1) = dgvList.Columns(k).Name
        Next
        For i = 0 To dgvList.RowCount - 1
            For j = 0 To dgvList.ColumnCount - 1
                xlWorkSheet.Cells(i + 2, j + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                xlWorkSheet.Cells(i + 2, j + 1) =
                     dgvList(j, i).Value.ToString()
            Next
        Next

        Dim SaveFileDialog1 As New SaveFileDialog()
        SaveFileDialog1.Filter = "Execl files (*.xlsx)|*.xlsx"
        SaveFileDialog1.FilterIndex = 2
        SaveFileDialog1.RestoreDirectory = True
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            xlWorkSheet.SaveAs(SaveFileDialog1.FileName)
            MsgBox("Save file success")
        Else
            Return
        End If
        xlWorkBook.Close()
        xlapp.Quit()
    End Sub
End Class