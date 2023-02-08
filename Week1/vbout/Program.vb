Imports System

Module Program
    Sub Main(args As String())
        dim greeting as String = "hey"
        dim greetStyle as String = "casual" 'casual, business casual, full business, etc
        'Console.WriteLine(greeter(greetStyle))
        'GuessingGame(1)
        'Counter1(5)
        'Counter2(5)
        GuessingGamev2()
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
    Sub GuessingGame(guess as Integer)
        dim rnd as Random = new Random()
        dim mysteryNumber as integer = rnd.next(1,2)
        If guess <> mysteryNumber Then '<> is for not equal
            Console.WriteLine("Wrong guess :<")
        Else Console.WriteLine("Good guess :>")
        End If
    End Sub
    Sub Counter1(stopping_point as Integer)
        dim count as integer = 0
        While count < stopping_point
            Console.WriteLine(count)
            count = count + 1
        End While
    End Sub
    Sub Counter2(stoppingPoint as integer)
        For index As integer = 0 To stoppingPoint
            Console.WriteLine(index)
        Next
    End Sub
    Sub GuessingGamev2()
        dim rnd as random = new Random()
        dim mysteryNum as integer = rnd.Next(1,100)
        Console.WriteLine("Input Guess")
        dim guess as string = Console.ReadLine()
        dim guessNum as integer = 0
        Try
            guessNum = integer.Parse(guess)
        Catch ex as Exception
            Console.WriteLine("Invalid Guess")
        End Try
        While guessNum <> mysteryNum
            Console.Write("Wrong Number! ")
            If guessNum < mysteryNum Then
                Console.WriteLine("Try Higher than " & guessNum)
            Else Console.WriteLine("Try Lower " & guessNum)
            End If
            'Console. WriteLine(vbCrLf) 'vbCrLf is newline for vb
            guess = Console.ReadLine()
            Try
                guessNum = integer.Parse(guess)
            Catch ex as Exception
                Console.WriteLine("Invalid Guess")
            End Try
        End While 
        Console.WriteLine("Correct! You Win.")
    End Sub
End Module
