

Partial Class DSPembayaranKT
	Partial Public Class dtRelasiDataTable
		Private Sub dtRelasiDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
			If (e.Column.ColumnName = Me.idrelasiColumn.ColumnName) Then
				'Add user code here
			End If

		End Sub

	End Class

	Partial Public Class dtBayarBongkarAllDataTable
		Private Sub dtBayarBongkarAllDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
			If (e.Column.ColumnName = Me.NamaRekeningColumn.ColumnName) Then
				'Add user code here
			End If

		End Sub

	End Class

	Partial Public Class dtSuratJalanDataTable
		Private Sub dtSuratJalanDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
			If (e.Column.ColumnName = Me.JenisColumn.ColumnName) Then
				'Add user code here
			End If

		End Sub

	End Class

	Partial Public Class dtBayarKTDataTable
		Private Sub dtBayarKTDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
			If (e.Column.ColumnName = Me.TglTerimaColumn.ColumnName) Then
				'Add user code here
			End If

		End Sub

	End Class
End Class
