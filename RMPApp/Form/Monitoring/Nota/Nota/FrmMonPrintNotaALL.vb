Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

Public Class FrmMonPrintNotaALL
    Dim cls As New ClsDatabaseConnection
    Dim Conn As SqlConnection = New SqlConnection(StrConnRMPApp)

    Private Sub FrmMonPrintNotaALL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ReportViewer.RefreshReport()

        dtp1.Value = Format(Now, "yyyy-MM-dd")
        dtp2.Value = Format(Now, "yyyy-MM-dd")
        Modul_RMP.Combo.SetPancang(cboPCG)
        Modul_RMP.Combo.SetKapal(cboKPL)

        dgv.AllowUserToAddRows = False
        dtp1.Enabled = False
        dtp2.Enabled = False
        cboPCG.Enabled = False
        cboKPL.Enabled = False
        txtTrip.Enabled = False

        Me.ReportViewer.RefreshReport()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ReportViewer.Clear()
        ReportViewer.LocalReport.DataSources.Clear()
        chkTgl.Checked = False
        chkPancang.Checked = False
        chkKapal.Checked = False
        chkTrip.Checked = False
        dgv.Rows.Clear()
        dtp1.Value = Format(Now, "yyyy-MM-dd")
        dtp2.Value = Format(Now, "yyyy-MM-dd")
    End Sub

    Private Sub cboPCG_KeyUp(sender As Object, e As KeyEventArgs) Handles cboPCG.KeyUp
        UI.AutoCompleteCombo_KeyUp(cboPCG, e)
    End Sub

    Private Sub cboKPL_KeyUp(sender As Object, e As KeyEventArgs) Handles cboKPL.KeyUp
        UI.AutoCompleteCombo_KeyUp(cboKPL, e)
    End Sub

    Private Sub txtTrip_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTrip.KeyPress
        UI.validasi(e, 2)
    End Sub

    Private Sub chkTgl_CheckedChanged(sender As Object, e As EventArgs) Handles chkTgl.CheckedChanged
        If chkTgl.Checked = True Then
            dtp1.Enabled = True
            dtp2.Enabled = True
        Else
            dtp1.Enabled = False
            dtp2.Enabled = False
            dtp1.Value = Format(Now, "yyyy-MM-dd")
            dtp2.Value = Format(Now, "yyyy-MM-dd")
        End If
    End Sub

    Private Sub chkPancang_CheckedChanged(sender As Object, e As EventArgs) Handles chkPancang.CheckedChanged
        If chkPancang.Checked = True Then
            cboPCG.Enabled = True
        Else
            cboPCG.Enabled = False
            cboPCG.Text = ""
        End If
    End Sub

    Private Sub chkKapal_CheckedChanged(sender As Object, e As EventArgs) Handles chkKapal.CheckedChanged
        If chkKapal.Checked = True Then
            cboKPL.Enabled = True
        Else
            cboKPL.Enabled = False
            cboKPL.Text = ""
        End If
    End Sub

    Private Sub chkTrip_CheckedChanged(sender As Object, e As EventArgs) Handles chkTrip.CheckedChanged
        If chkTrip.Checked = True Then
            txtTrip.Enabled = True
        Else
            txtTrip.Enabled = False
            txtTrip.Text = ""
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If chkTgl.Checked = False Then
            MessageBox.Show("Silahkan pilih tanggal !", AT, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ReportViewer.Clear()
        ReportViewer.LocalReport.DataSources.Clear()
        LoadData()
    End Sub

    Sub LoadData()
        Cursor = Cursors.WaitCursor
        Application.DoEvents()

        Try
            Dim dt As DataTable = New DataTable()
            Dim i As Integer
            Dim sql As String = ""

            If chkTgl.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "CONVERT(DATETIME,CONVERT(VARCHAR, TransDate,103),103) BETWEEN CONVERT (DATETIME,'" & dtp1.Value & "',103) AND CONVERT(DATETIME,'" & dtp2.Value & "',103)")
            End If

            If chkPancang.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "IDPancang = '" & cboPCG.SelectedValue & "'")
            End If

            If chkKapal.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "IDKapal = '" & cboKPL.SelectedValue & "'")
            End If

            If chkTrip.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "Trip = '" & txtTrip.Text & "'")
            End If

            'If rdAllBank.Checked = True Then
            '    If chkUM.Checked = True Then
            '        dt = DB.ExecuteQuery(StrConnRMPApp,"SELECT NoNota,Pancang,Kapal,TotalHarga,TransID FROM vwTMBGKelapaHdr " &
            '                                                      "WHERE Deleted = 0 AND IndUM = 1 " & IIf(sql = "", "", " AND " & sql) & " ORDER BY NamaRelasi")
            '    ElseIf chkUM.Checked = False Then
            '        dt = DB.ExecuteQuery(StrConnRMPApp,"SELECT NoNota,Pancang,Kapal,TotalHarga,TransID FROM vwTMBGKelapaHdr " &
            '                                                      "WHERE Deleted = 0 AND IndUM = 0 " & IIf(sql = "", "", " AND " & sql) & " ORDER BY NamaRelasi")
            '    End If
            'ElseIf rdBNI.Checked = True Then
            '    If chkUM.Checked = True Then
            '        dt = DB.ExecuteQuery(StrConnRMPApp,"SELECT NoNota,Pancang,Kapal,TotalHarga,TransID FROM vwTMBGKelapaHdr " &
            '                                                      "WHERE Bank = 'BNI' AND Deleted = 0 AND IndUM = 1 " & IIf(sql = "", "", " AND " & sql) & " ORDER BY NamaRelasi")
            '    ElseIf chkUM.Checked = False Then
            '        dt = DB.ExecuteQuery(StrConnRMPApp,"SELECT NoNota,Pancang,Kapal,TotalHarga,TransID FROM vwTMBGKelapaHdr " &
            '                                                      "WHERE Bank = 'BNI' AND Deleted = 0 AND IndUM = 0 " & IIf(sql = "", "", " AND " & sql) & " ORDER BY NamaRelasi")
            '    End If
            'ElseIf rdSelainBNI.Checked = True Then
            '    If chkUM.Checked = True Then
            '        dt = DB.ExecuteQuery(StrConnRMPApp,"SELECT NoNota,Pancang,Kapal,TotalHarga,TransID FROM vwTMBGKelapaHdr " &
            '                                                      "WHERE Bank NOT IN ('BNI') AND Deleted = 0 AND IndUM = 1 " & IIf(sql = "", "", " AND " & sql) & " ORDER BY NamaRelasi")
            '    ElseIf chkUM.Checked = False Then
            '        dt = DB.ExecuteQuery(StrConnRMPApp,"SELECT NoNota,Pancang,Kapal,TotalHarga,TransID FROM vwTMBGKelapaHdr " &
            '                                                      "WHERE Bank NOT IN ('BNI') AND Deleted = 0 AND IndUM = 0 " & IIf(sql = "", "", " AND " & sql) & " ORDER BY NamaRelasi")
            '    End If
            'End If



            If rdAllBank.Checked = True Then
                If chkUM.Checked = True Then
                    dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT NoNota,Pancang,Kapal,TotalHarga,TransID FROM vwTMBGKelapaHdrAll " &
                                                                  "WHERE Deleted = 0 AND IndUM = 1 " & IIf(sql = "", "", " AND " & sql) & " ORDER BY NamaRelasi")
                ElseIf chkUM.Checked = False Then
                    dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT NoNota,Pancang,Kapal,TotalHarga,TransID FROM vwTMBGKelapaHdrAll  " &
                                                                  "WHERE Deleted = 0 AND IndUM = 0 " & IIf(sql = "", "", " AND " & sql) & " ORDER BY NamaRelasi")
                End If
            ElseIf rdBNI.Checked = True Then
                If chkUM.Checked = True Then
                    dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT NoNota,Pancang,Kapal,TotalHarga,TransID FROM vwTMBGKelapaHdrAll " &
                                                                  "WHERE Bank = 'BNI' AND Deleted = 0 AND IndUM = 1 " & IIf(sql = "", "", " AND " & sql) & " ORDER BY NamaRelasi")
                ElseIf chkUM.Checked = False Then
                    dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT NoNota,Pancang,Kapal,TotalHarga,TransID FROM vwTMBGKelapaHdrAll " &
                                                                  "WHERE Bank = 'BNI' AND Deleted = 0 AND IndUM = 0 " & IIf(sql = "", "", " AND " & sql) & " ORDER BY NamaRelasi")
                End If
            ElseIf rdSelainBNI.Checked = True Then
                If chkUM.Checked = True Then
                    dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT NoNota,Pancang,Kapal,TotalHarga,TransID FROM vwTMBGKelapaHdrAll " &
                                                                  "WHERE Bank NOT IN ('BNI') AND Deleted = 0 AND IndUM = 1 " & IIf(sql = "", "", " AND " & sql) & " ORDER BY NamaRelasi")
                ElseIf chkUM.Checked = False Then
                    dt = Modul_RMP.DB.ExecuteQuery(StrConnRMPApp, "SELECT NoNota,Pancang,Kapal,TotalHarga,TransID FROM vwTMBGKelapaHdrAll " &
                                                                  "WHERE Bank NOT IN ('BNI') AND Deleted = 0 AND IndUM = 0 " & IIf(sql = "", "", " AND " & sql) & " ORDER BY NamaRelasi")
                End If
            End If

            If dt.Rows.Count > 0 Then
                With dgv
                    dgv.Rows.Clear()
                    For Each row As DataRow In dt.Rows
                        .Rows.Add()
                        .Item("No", i).Value = i + 1
                        If Not IsDBNull(row.Item("NoNota")) Then .Item("NoNota", i).Value = row.Item("NoNota")
                        If Not IsDBNull(row.Item("Pancang")) Then .Item("Pancang", i).Value = row.Item("Pancang")
                        If Not IsDBNull(row.Item("Kapal")) Then .Item("Kapal", i).Value = row.Item("Kapal")
                        If Not IsDBNull(row.Item("TotalHarga")) Then .Item("Total", i).Value = row.Item("TotalHarga")
                        If Not IsDBNull(row.Item("TransID")) Then .Item("TransID", i).Value = row.Item("TransID")
                        i = i + 1
                    Next
                End With
            Else
                dgv.Rows.Clear()
                MsgBox("No Data", MsgBoxStyle.Exclamation, AT)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            ReportViewer.Clear()
            ReportViewer.LocalReport.DataSources.Clear()
            Dim sql As String = ""

            If chkTgl.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "CONVERT(DATETIME,CONVERT(VARCHAR, TransDate,103),103) BETWEEN CONVERT (DATETIME,'" & dtp1.Value & "',103) AND CONVERT(DATETIME,'" & dtp2.Value & "',103)")
            End If

            If chkPancang.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "IDPancang = '" & cboPCG.SelectedValue & "'")
            End If

            If chkKapal.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "IDKapal = '" & cboKPL.SelectedValue & "'")
            End If

            If chkTrip.Checked = True Then
                sql = Modul_RMP.Func.SetCondition(sql, "Trip = '" & txtTrip.Text & "'")
            End If

            If rdAllBank.Checked = True Then
                If chkUM.Checked = True Then
                    sql = "SELECT NoNota,Pancang,Kapal,TotalHarga,TransID FROM vwTMBGKelapaHdrALL WHERE Deleted = 0 AND IndUM = 1 " & IIf(sql = "", "", " AND " & sql) & " ORDER BY NamaRelasi"
                ElseIf chkUM.Checked = False Then
                    sql = "SELECT NoNota,Pancang,Kapal,TotalHarga,TransID FROM vwTMBGKelapaHdrall WHERE Deleted = 0 AND IndUM = 0 " & IIf(sql = "", "", " AND " & sql) & " ORDER BY NamaRelasi"
                End If
            ElseIf rdBNI.Checked = True Then
                If chkUM.Checked = True Then
                    sql = "SELECT NoNota,Pancang,Kapal,TotalHarga,TransID FROM vwTMBGKelapaHdrall WHERE Bank = 'BNI' AND Deleted = 0 AND IndUM = 1 " & IIf(sql = "", "", " AND " & sql) & " ORDER BY NamaRelasi"
                ElseIf chkUM.Checked = False Then
                    sql = "SELECT NoNota,Pancang,Kapal,TotalHarga,TransID FROM vwTMBGKelapaHdrall WHERE Bank = 'BNI' AND Deleted = 0 AND IndUM = 0 " & IIf(sql = "", "", " AND " & sql) & " ORDER BY NamaRelasi"
                End If
            ElseIf rdSelainBNI.Checked = True Then
                If chkUM.Checked = True Then
                    sql = "SELECT NoNota,Pancang,Kapal,TotalHarga,TransID FROM vwTMBGKelapaHdrall WHERE Bank NOT IN ('BNI') AND Deleted = 0 AND IndUM = 1 " & IIf(sql = "", "", " AND " & sql) & " ORDER BY NamaRelasi"
                ElseIf chkUM.Checked = False Then
                    sql = "SELECT NoNota,Pancang,Kapal,TotalHarga,TransID FROM vwTMBGKelapaHdrall WHERE Bank NOT IN ('BNI') AND Deleted = 0 AND IndUM = 0 " & IIf(sql = "", "", " AND " & sql) & " ORDER BY NamaRelasi"
                End If
            End If

            Dim Da = New SqlDataAdapter(sql, Conn)
            Dim Dt = New DataTable()
            Da.Fill(Dt)
            Dim Drs = New ReportDataSource("DataSet1", Dt)
            Me.ReportViewer.LocalReport.DataSources.Add(Drs)
            Dim newPageSetting As New System.Drawing.Printing.PageSettings
            newPageSetting.Margins = New Drawing.Printing.Margins(10, 10, 10, 10)
            newPageSetting.Landscape = True
            Me.ReportViewer.SetPageSettings(newPageSetting)
            Me.ReportViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            Me.ReportViewer.LocalReport.EnableExternalImages = True
            Me.ReportViewer.LocalReport.ReportEmbeddedResource = My.Application.Info.AssemblyName & ".RptPrintFoto.rdlc"
            Me.ReportViewer.RefreshReport()
            Me.ReportViewer.RefreshReport()
        Catch ex As Exception
            MsgBox("Tidak ada Nota yang akan diprint!", vbInformation, AT)
        End Try
        Me.Cursor = Cursors.Default
    End Sub
End Class