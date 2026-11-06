Imports C1.Design

Public Class ClsSecurityHelper
	Public Function EncryptText(strText As String, ByVal strPwd As String)
		Dim i As Integer, c As Integer
		Dim strBuff As String

#If Not CASE_SENSITIVE_PASSWORD Then

		'Convert password to upper case
		'if not case-sensitive
		strPwd = UCase$(strPwd)

#End If
		strBuff = ""
		'Encrypt string
		If Len(strPwd) Then
			For i = 1 To Len(strText)
				c = Asc(Mid$(strText, i, 1))
				c = c + Asc(Mid$(strPwd, (i Mod Len(strPwd)) + 1, 1))
				strBuff = strBuff & Chr(c And &HFF)
			Next i
		Else
			strBuff = strText
		End If
		EncryptText = strBuff
	End Function

	Public Function EncryptText_(ByVal strText As String, ByVal strPwd As String)
		Dim i As Integer, c As Integer
		Dim strBuff As String = ""

#If Not CASE_SENSITIVE_PASSWORD Then

		'Convert password to upper case
		'if not case-sensitive
		strPwd = UCase$(strPwd)

#End If

		'Encrypt string
		If Len(strPwd) Then
			For i = 1 To Len(strText)
				c = Asc(Mid$(strText, i, 1))
				c = c + Asc(Mid$(strPwd, (i Mod Len(strPwd)) + 1, 1))
				strBuff = strBuff & Chr(c And &HFF)
			Next i
		Else
			strBuff = strText
		End If
		EncryptText_ = strBuff
	End Function
	Public Function DecryptText_(strText As String, ByVal strPwd As String)
		Dim i As Integer, c As Integer, strBuff As String

		strBuff = ""
#If Not CASE_SENSITIVE_PASSWORD Then
		strPwd = UCase$(strPwd)
#End If

		If Len(strPwd) Then
			For i = 1 To Len(strText)
				c = Asc(Mid$(strText, i, 1))
				c = c - Asc(Mid$(strPwd, (i Mod Len(strPwd)) + 1, 1))
				strBuff = strBuff & Chr(c And &HFF)
			Next i
		Else
			strBuff = strText
		End If
		DecryptText_ = strBuff
	End Function
	Public Function DecryptText(ByVal strText As String, ByVal strPwd As String)
		Dim i As Integer, c As Integer, strBuff As String = ""
#If Not CASE_SENSITIVE_PASSWORD Then
		strPwd = UCase$(strPwd)
#End If

		If Len(strPwd) Then
			For i = 1 To Len(strText)
				c = Asc(Mid$(strText, i, 1))
				c = c - Asc(Mid$(strPwd, (i Mod Len(strPwd)) + 1, 1))
				strBuff = strBuff & Chr(c And &HFF)
			Next i
		Else
			strBuff = strText
		End If
		DecryptText = strBuff
	End Function

	Public Sub GetAccess(ByVal RoleID As Integer, ByVal MenuTag As String, ByRef CanAdd As Boolean, ByRef CanEdit As Boolean, ByRef CanDelete As Boolean, ByRef CanSave As Boolean)
		Try
			Dim dt As DataTable = New DataTable
			dt = DB.ExecuteQuery(StrConnRMPApp, "select * from tblUtlRoleMenu as a inner join tblUtlMenu as b on a.MenuID=b.MenuID 
												where RoleID=" & RoleID & " and MenuTag='" & MenuTag & "'")
			CanAdd = dt.Rows(0)("CanAdd")
			CanEdit = dt.Rows(0)("CanEdit")
			CanDelete = dt.Rows(0)("CanDelete")
			CanSave = dt.Rows(0)("CanSave")
		Catch ex As Exception

		End Try
	End Sub
End Class
