Public Class ClsGeneral
	Function ValidNota(NoNota As String) As Boolean
		If Right(RTrim(NoNota), 6) = Format(Periode, "MMyyyy") Then
			ValidNota = True
		Else
			MsgBox("Nomor Nota Tidak Sesuai Dengan Periode Yang Berjalan!", vbCritical, "Periode : " & Format(Periode, "MMyyyy"))
			ValidNota = False
		End If
	End Function
End Class
