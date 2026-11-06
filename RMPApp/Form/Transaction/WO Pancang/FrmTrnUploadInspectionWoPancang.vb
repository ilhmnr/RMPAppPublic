Imports System.IO

Public Class FrmTrnUploadInspectionWoPancang
    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        txtWoId.Clear()
        txtPancang.Clear()
        txtJudul.Clear()

        With FrmTrnApproval1DanInputBarangPengajuanWoPancangFind
            .TabControl.SelectedTab = .TabPage6
            .openFormBy = "Inspection"
            .rdAllinspection.Checked = True
            .loadData()
            .ShowDialog()
        End With
    End Sub

    Private Sub FrmTrnUploadInspectionWoPancang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblFile.Text = "No File"
        picFile.BackgroundImage = My.Resources.no_image
    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Try
            Dim topColor As Color = Color.FromArgb(0, 172, 251) ' Warna atas yang tebal
            Dim bottomColor As Color = Color.FromArgb(0, 0, 255, 255) ' Warna bawah yang pudar

            Dim gradientRect As New Rectangle(0, 0, Panel1.Width, Panel1.Height)

            Using brush As New Drawing2D.LinearGradientBrush(gradientRect, topColor, bottomColor, Drawing2D.LinearGradientMode.Vertical)
                e.Graphics.FillRectangle(brush, gradientRect)
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not File.Exists(lblFile.Text) Then
            MsgBox("File Inspection Belum Di Upload !", vbExclamation, AT)
            Exit Sub
        End If

        Dim query As String = ""
        query = " declare @namaFile varchar(100)
                  select @namaFile=(select 'Inspection_'+cast(id as varchar(50))+'_'+cast(format(getdate(),'yyyy-MM-dd HH-mm-ss') as varchar(20))+'.pdf' from tbl_wo_trn_hdr where id=" & txtWoId.Text & ")
                  update RMPApp..tbl_wo_trn_hdr set file_pemeriksaan=@namaFile where id=" & txtWoId.Text & "
                  UPDATE RMPApp..tbl_wo_trn_file_wo set deleted=1,deleted_by='" & ClsSession.UserID & "',deleted_date=getdate() where wo_id=" & txtWoId.Text & " and deleted=0 and flag=4
                  insert into RMPApp..tbl_wo_trn_file_wo (wo_id,file_name,flag,deskripsi,deleted,created_by,created_date)
                  values (" & txtWoId.Text & ",@namaFile,4,'Inspection',0,'" & ClsSession.UserID & "',getdate())
                  EXEC [dbo].[sp_wo_save_marker] " & txtWoId.Text & ", 'PROGRESS 3', '" & ClsSession.UserID.ToUpper & "','CLOSE WO', 'ADMIN'
                  select @namaFile as GetValueString "

        Dim namaFile As String = DB.ExecuteScalarValue(Of String)(StrConnRMPApp,query)

        Dim lokasiSimpanFile As String = UrlNotaPancang & "DocumentWorkOrder\" & namaFile
        File.Copy(lblFile.Text, lokasiSimpanFile, True)

        lblFile.Text = namaFile

        MsgBox("File Berhasil Di Simpan", vbInformation, AT)
    End Sub

    Private Sub btnUploadFile_Click(sender As Object, e As EventArgs) Handles btnUploadFile.Click
        Dim Openpdf As OpenFileDialog = New OpenFileDialog()
        Openpdf.Filter = "PDF files|*.pdf|All files|*.*;"

        If Openpdf.ShowDialog() = DialogResult.OK Then
            Dim pdfLog As String = Openpdf.FileName.ToString()
            lblFile.Text = pdfLog
            AxAcroPDF1.src = Openpdf.FileName
            AxAcroPDF1.LoadFile(lblFile.Text)
            picFile.BackgroundImage = My.Resources.file
        Else
            lblFile.Text = "No File"
            picFile.BackgroundImage = My.Resources.no_image
        End If

        If AxAcroPDF1.src Is Nothing Then
            MessageBox.Show("Try new file")
        Else
            MessageBox.Show("PDF Uploaded")
        End If
    End Sub

    Private Sub picFile_Click(sender As Object, e As EventArgs) Handles picFile.Click
        Try
            Process.Start(UrlNotaPancang & "DocumentWorkOrder\" & lblFile.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "File Tidak Ditemukan Pilih File terlebih dahulu", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
End Class