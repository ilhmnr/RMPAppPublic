Imports System.IO
Imports System.Net

Public Class FrmFotoNota
	Public images As String
	Public Foto As String
	Public NoRek As String

	'Input Master Rekening
	Public NoRekening As String
	Public SupID As String

	Private Sub FrmFotoNota_Load(sender As Object, e As EventArgs) Handles Me.Load
		If Foto = "Rekening" Then
			PictureBox1.BackgroundImage = Nothing

			Dim folder As String = "\\rsupind2\MasterTT$\Pancang\Rekening\"

			If (File.Exists(folder & NoRek & ".jpg")) Then
				PictureBox1.BackgroundImage = Image.FromFile(folder & NoRek & ".jpg")
				PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
			Else
				PictureBox1.BackgroundImage = My.Resources.no
			End If
			Me.Text = "Foto Rekening"
			btnPrint.Visible = True

		ElseIf Foto = "Nota" Then
			'\\rsupind2\ImageKaryawan$\
			PictureBox1.BackgroundImage = Nothing

			Dim apiUrl As String = UrlApiNotaPancang & "ImagesNotaPancang&filename=" & images & ".jpg&flag=notapancang"

			Modul_RMP.Func.getfoto(apiUrl, TokenApiNotaPancang, PictureBox1)

			'If PictureBox1.Image Is Nothing Then
			'	Dim imageUrl As String = "http://222.124.139.166:5006/ImageNota/Images/" & images & ".jpg"
			'	Dim client As New WebClient()
			'	Dim imgStream As IO.Stream = client.OpenRead(imageUrl)
			'	PictureBox1.Image = Image.FromStream(imgStream)
			'End If

			Me.Text = "Nota Pancang"
			btnPrint.Visible = True

		ElseIf Foto = "FotoCheckin" Then
			PictureBox1.BackgroundImage = Nothing

			Dim apiUrl As String = UrlApiNotaPancang & "ImagesKapalPelangsirCheckin&filename=" & images & "&flag=notapancang"

			Modul_RMP.Func.getfoto(apiUrl, TokenApiNotaPancang, PictureBox1)

			Me.Text = "Foto Checkin"
			btnPrint.Visible = True
		ElseIf Foto = "Input Master Rekening" Then
			On Error Resume Next
			Dim folder As String = NoRekening & "-" & SupID
			PictureBox1.Image = Nothing
			Dim apiUrl As String = UrlApiPancang & "Rekening&filename=" & folder & ".png&flag=mastertt2"

			Modul_RMP.Func.getfoto(apiUrl, TokenApiNotaPancang, PictureBox1)
			Me.Text = "Rekening"
			btnPrint.Visible = False

		ElseIf Foto = "Master Kapten Kapal" Then
			PictureBox1.BackgroundImage = Nothing
			' http://222.124.139.166:81/BaseAPI/public/uploads/
			PictureBox1.LoadAsync("http://222.124.139.166:81/BaseAPI/public/uploads/" & images)
			Me.Text = "Master Kapten Kapal"


			'ElseIf Foto = "Master Personil Pancang" Then

			'	PictureBox1.BackgroundImage = Nothing
			'	On Error Resume Next
			'	Dim id As String = FrmMstPersonilPancang.txtID.Text + "-" + FrmMstPersonilPancang.txtNIK.Text
			'	Dim folder As String = UrlMasterTTPancnag & "PersonilPancang\"
			'	Dim filename As String = System.IO.Path.Combine(folder, id & ".png")
			'	PictureBox1.Image = Image.FromFile(filename)
			'	Me.Text = "Personil Pancang"

			'	btnPrint.Visible = False
		ElseIf Foto = "FotoKelapaB" Then
			PictureBox1.BackgroundImage = Nothing

			Dim apiUrl As String = UrlApiNotaPancangNew & "ImagesKelapaB&filename=" & images & ".JPG&flag=notapancang"

			Modul_RMP.Func.getfoto(apiUrl, TokenApiNotaPancang, PictureBox1)

			Me.Text = "Foto Kelapa B"
			btnPrint.Visible = True
		End If
	End Sub

	Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
		FrmRptTest.FormName = Foto
		FrmRptTest.FileName = images
		FrmRptTest.Show()
	End Sub
End Class
