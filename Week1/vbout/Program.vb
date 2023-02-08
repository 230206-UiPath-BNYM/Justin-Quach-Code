Imports System

Module Program
    Sub Main(args As String())
        dim greeting as String = "hey"
        dim greetStyle as String = "casual" 'casual, business casual, full business, etc'
        Console.WriteLine(greeter(greetStyle))
    End Sub
    Function greeter(greeting_type As String) As String
        Select Case greeting_type
            Case "casual"
                Return "sup"
            Case "business casual"
                Return "salutations!"
            Case "full business"
                Return "to whom it may concern"
            Case Else
                Return "hello"
        End Select
    End Function
End Module
