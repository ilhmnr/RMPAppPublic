Partial Class DSMonRekening
    Partial Public Class dtRekeningRelasiPancangDataTable
        Private Sub dtRekeningRelasiPancangDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.IDPetaniColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class
End Class
