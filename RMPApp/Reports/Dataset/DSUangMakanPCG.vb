Partial Class DSUangMakanPCG
    Partial Public Class DtUangMakanPCGDataTable
        Private Sub DtUangMakanPCGDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.NamaColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class
End Class
