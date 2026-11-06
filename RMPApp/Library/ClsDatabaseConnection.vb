Imports System.Data.SqlClient

Public Class ClsDatabaseConnection
	Public CONN As SqlConnection
	Public DA As SqlDataAdapter
	Public DS As DataSet
	Public CMD As SqlCommand
	Public DR As SqlDataReader

	Public Function OpenConnection(strConn As String) As SqlConnection
		Try
			CONN = New SqlConnection(strConn)

			If CONN.State = ConnectionState.Closed Then
				CONN.Open()
			End If

			Return CONN

		Catch ex As Exception
			Dim Msg As String

			Select Case strConn
				Case StrConnRMPApp
					Msg = "Koneksi ke database RMPApp gagal !"
				Case StrConnAccounting
                    Msg = "Koneksi ke database Accounting gagal !"
				Case StrConnPSGRMP
					Msg = "Koneksi ke database PSGRMP gagal !"
                Case StrConnDBPancang
                    Msg = "Koneksi ke database DBPancang gagal !"
                Case StrConnOneLogin
					Msg = "Koneksi ke database OneLogin gagal !"
                Case StrConnP1RMP
					Msg = "Koneksi ke database P1RMP gagal !"
                Case StrConnTimbangan
					Msg = "Koneksi ke database Timbangan gagal !"
				Case Else
					Msg = "Koneksi ke database gagal !"
			End Select

			MsgBox(Msg, vbExclamation, AT)
			Return Nothing
		End Try
	End Function

	Public Sub CloseConnection()
		Try
			If CONN IsNot Nothing AndAlso CONN.State = ConnectionState.Open Then
				CONN.Close()
			End If

		Catch ex As Exception
			MsgBox("Gagal menutup koneksi database !", vbCritical, AT)
		End Try
	End Sub

	Public Function ExecuteQuery(strConn As String,
									   ByVal sql As String,
									   Optional params As SqlParameter() = Nothing) As DataTable

		Dim dt As New DataTable()

		Try
			Using cn As New SqlConnection(strConn)
				Using cmd As New SqlCommand(sql, cn)

					cmd.CommandTimeout = 600

					If params IsNot Nothing Then
						cmd.Parameters.AddRange(params)
					End If

					cn.Open()

					Using dr As SqlDataReader = cmd.ExecuteReader()
						dt.Load(dr)
					End Using

				End Using
			End Using

		Catch ex As Exception
			MsgBox(ex.Message, vbExclamation, AT)
		End Try

		Return dt

	End Function

	Public Function ExecuteNonQuery(strConn As String,
								ByVal sql As String,
								Optional params As SqlParameter() = Nothing) As Integer

		Try
			Using cn As New SqlConnection(strConn)
				Using cmd As New SqlCommand(sql, cn)

					cmd.CommandTimeout = 600

					If params IsNot Nothing Then
						cmd.Parameters.AddRange(params)
					End If

					cn.Open()

					Return cmd.ExecuteNonQuery()

				End Using
			End Using

		Catch ex As Exception
			MsgBox(ex.Message, vbExclamation, AT)
			Return -1
		End Try

	End Function

	Public Function ExecuteScalarValue(Of T)(strConn As String,
										  ByVal sql As String,
										  Optional params As SqlParameter() = Nothing) As T

		Try
			Using cn As New SqlConnection(strConn)
				Using cmd As New SqlCommand(sql, cn)

					cmd.CommandTimeout = 600

					If params IsNot Nothing Then
						cmd.Parameters.AddRange(params)
					End If

					cn.Open()

					Dim result As Object = cmd.ExecuteScalar()

					If result Is Nothing OrElse IsDBNull(result) Then
						Return Nothing
					End If

					Return CType(Convert.ChangeType(result, GetType(T)), T)

				End Using
			End Using

		Catch ex As Exception
			MsgBox(ex.Message, vbExclamation, AT)
			Return Nothing
		End Try

	End Function

	Public Function GetCategories(tableName As String) As String

		Dim categories As String = ""

		Dim commandText As String = $"SELECT * FROM {tableName}"
		Dim command As SqlCommand = New SqlCommand(commandText, DB.OpenConnection(StrConnRMPApp))

		'conn.Open()

		Dim dr As SqlDataReader = command.ExecuteReader()

		While dr.Read()

			If categories = "" Then
				categories = "|" + dr.Item("Ket").ToString()
			Else
				categories = categories + "|" + dr.Item("Ket").ToString()
			End If

		End While

		Return categories

	End Function

    Public Function ClosingDate(Tgl As Date)
		DB.OpenConnection(StrConnPSGRMP)
		Dim cmd As New SqlCommand
		Dim sql As String
		Dim i As Integer
		sql = "Select ClosingDate from tblRMUtlClosingDate "
		cmd.CommandText = sql
		cmd.Connection = DB.OpenConnection(StrConnPSGRMP)
		Dim ODR As SqlDataReader = cmd.ExecuteReader()

		i = 0
		If ODR.HasRows Then
			Do While ODR.Read
				If Tgl <= ODR("ClosingDate") Then
					ClosingDate = 1
				End If
			Loop
		End If
	End Function

	Public Function ClosingDateP2(Tgl As Date)
		DB.OpenConnection(StrConnAccounting)
		Dim cmd As New SqlCommand
		Dim sql As String
		Dim i As Integer
		sql = " Select Closing_Date from RSUPGeneralLedger2018..TblRGLUtilClosingDate "
		cmd.CommandText = sql
		cmd.Connection = DB.OpenConnection(StrConnAccounting)
		Dim ODR As SqlDataReader = cmd.ExecuteReader()

		i = 0
		If ODR.HasRows Then
			Do While ODR.Read
				If Tgl <= ODR("Closing_Date") Then
					ClosingDateP2 = 1
				End If
			Loop
		End If
	End Function

	Public Function GetDate() As String
		Dim hasil As String = ""
		Dim cn As New SqlConnection(StrConnRMPApp)

		Dim sql As String = "SELECT CONVERT(varchar, GETDATE(), 103) + ' ' + CONVERT(varchar, GETDATE(), 108) AS Now"
		Dim cmd As New SqlCommand(sql, cn)
		Dim rs As SqlDataReader = Nothing

		Try
			cn.Open()
			rs = cmd.ExecuteReader

			While rs.Read
				hasil = rs!Now
			End While
		Catch ex As Exception
			MessageBox.Show(ex.Message)
		Finally
			rs.Dispose()
			cn.Close()
		End Try
		Return hasil
	End Function

End Class
