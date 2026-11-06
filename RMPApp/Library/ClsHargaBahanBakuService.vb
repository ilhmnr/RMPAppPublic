Public Class ClsHargaBahanBakuService
    Public Function GetHargakGB(ByVal pancang As String, rd1 As RadioButton, rd2 As RadioButton, date1 As DateTimePicker) As Double

        Dim dt As DataTable = New DataTable()
        If rd1.Checked = True Then
            Dim KODEHARGA As String
            KODEHARGA = DB.ExecuteScalarValue(Of String)(StrConnRMPApp, "Select Top 1 KodeHargaString As GetValuep2 From vwRMMstHargaBahanBakuKgDtl Where KodeGrade='Licin-B' and Harga>0  and idpancang='" & pancang & "' and  convert(smalldatetime,Periode,103) <= convert(smalldatetime,'" & date1.Value & "',103)  Order BY Periode Desc")

            dt = DB.ExecuteQuery(StrConnRMPApp, "Select  Harga from RSUPAccounting..vwRMMstHargaBahanBakuDtl Where KodeGrade='Licin-B' and Harga>0   and KodeHargaString='" & KODEHARGA & "' ")

        Else
            If rd2.Checked = True Then

                Dim KODEHARGA2 As String
                KODEHARGA2 = DB.ExecuteScalarValue(Of String)(StrConnRMPApp, "Select Top 1 KodeHargaString As GetValuep2 From vwRMMstHargaBahanBakuKgDtl Where KodeGrade='Jambul-B' and Harga>0  and idpancang='" & pancang & "' and  convert(smalldatetime,Periode,103) <= convert(smalldatetime,'" & date1.Value & "',103)   Order BY Periode Desc")

                dt = DB.ExecuteQuery(StrConnRMPApp, "Select Harga from RSUPAccounting..vwRMMstHargaBahanBakuDtl Where KodeGrade='Jambul-B' and Harga>0  and idpancang='" & pancang & "' and KodeHargaString='" & KODEHARGA2 & "' ")
            Else
                MessageBox.Show("Tidak Ada Harga")
            End If
        End If

        If dt.Rows.Count = 0 Then
            MsgBox("Harga bahan baku belum ada !", vbExclamation, AT)
        End If

        GetHargakGB = dt.Rows(0).Item("Harga")

        Return GetHargakGB
    End Function

    Public Function GetHargakGB_btr(ByVal pancang As String, date1 As DateTimePicker) As Double
        Dim dt As DataTable = New DataTable()
        Dim KODEHARGA As String
        KODEHARGA = DB.ExecuteScalarValue(Of String)(StrConnRMPApp, "Select Top 1 KodeHargaString As GetValuep2 From vwRMMstHargaBahanBakukgHdr Where Jenis= 'Licin'  and convert(smalldatetime,Periode,103) <= convert(smalldatetime,'" & date1.Text & "',103) Order BY Periode Desc")

        dt = DB.ExecuteQuery(StrConnRMPApp, "Select  Harga from RSUPAccounting..vwRMMstHargaBahanBakuDtl Where KodeGrade='Licin-B' and Harga>0  and idpancang='" & pancang & "' and KodeHargaString='" & KODEHARGA & "' ")

        GetHargakGB_btr = dt.Rows(0).Item("Harga")
        Return GetHargakGB_btr
    End Function
End Class
