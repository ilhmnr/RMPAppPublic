Public Interface ILookupDialog
    Property SourceFg As Object
    Property ExcludeColumn As String
    Property AutoClose As Boolean
    Sub LoadItems()
    Event ItemSelected As ItemSelectedEventHandler
    Delegate Sub ItemSelectedEventHandler(data As Dictionary(Of String, String))
End Interface