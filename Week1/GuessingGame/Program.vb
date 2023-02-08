Imports System

Module Program
    Sub Main(args As String())
        Console.Write("Target Word:  ")
        dim targetWord as string = Console.ReadLine()
        'Check for integers in word
        targetWord = targetWord.toLower()
        dim wordLen as integer = Len(targetWord)
        dim targetArray(wordLen) as string
        dim blankArray(wordLen) as string
        dim count = 0
        For each i as string in targetWord
            targetArray(count) = i
            blankArray(count) = "_"
            count = count + 1
        Next
        For index As integer = 0 To 10
            Console.WriteLine(vbCrLf)
        Next
        PrintMan(0)
        Console.Write("Guess the word:  ")
        dim guessLetter as string
        dim wrongCounter as integer
        dim checkLetter as boolean
        dim winLoss as boolean = True
        While EqualArray(targetArray, blankArray)
            guessLetter = Console.ReadLine()'check for single letter & no integers
            count = 0
            checkLetter = True
            For index As integer = 0 To wordLen
                If guessLetter = targetArray(index) Then
                    blankArray(index) = guessLetter
                    checkLetter = False
                End If
            Next
            If checkLetter Then
                wrongCounter = wrongCounter + 1
            End If
            If wrongCounter = 6 Then
                winLoss = False
                Exit While
            End If
            PrintMan(wrongCounter)
            Console.Write("Word:  ")
            For index As integer = 0 To wordLen
                Console.Write(blankArray(index))
            Next
            Console.WriteLine(vbCrLf)
        End While
        If winLoss Then
            Console.WriteLine("You Win")
        Else Console.WriteLine("You Lose")
        End If
        
    End Sub
    Sub PrintMan(tries as integer)
        Select Case tries
            Case 0
                Console.WriteLine("  +---+" & vbCrLf & "  |   |" & vbCrLf & "      |" & vbCrLf & "      |" & vbCrLf & "      |" & vbCrLf & "      |" & vbCrLf & "=========")
            Case 1
                Console.WriteLine("  +---+" & vbCrLf & "  |   |" & vbCrLf & "  O   |" & vbCrLf & "      |" & vbCrLf & "      |" & vbCrLf & "      |" & vbCrLf & "=========")
            Case 2
                Console.WriteLine("  +---+" & vbCrLf & "  |   |" & vbCrLf & "  O   |" & vbCrLf & "  |   |" & vbCrLf & "      |" & vbCrLf & "      |" & vbCrLf & "=========")
            Case 3
                Console.WriteLine("  +---+" & vbCrLf & "  |   |" & vbCrLf & "  O   |" & vbCrLf & " /|   |" & vbCrLf & "      |" & vbCrLf & "      |" & vbCrLf & "=========")
            Case 4
                Console.WriteLine("  +---+" & vbCrLf & "  |   |" & vbCrLf & "  O   |" & vbCrLf & " /|\  |" & vbCrLf & "      |" & vbCrLf & "      |" & vbCrLf & "=========")
            Case 5
                Console.WriteLine("  +---+" & vbCrLf & "  |   |" & vbCrLf & "  O   |" & vbCrLf & " /|\  |" & vbCrLf & " /    |" & vbCrLf & "      |" & vbCrLf & "=========")
            Case 6
                Console.WriteLine("  +---+" & vbCrLf & "  |   |" & vbCrLf & "  O   |" & vbCrLf & " /|\  |" & vbCrLf & " / \  |" & vbCrLf & "      |" & vbCrLf & "=========" & vbCrLf & "Game Over")
        End Select
    End Sub
    Sub Testing()
        For index As integer = 0 To 6
            PrintMan(index)
        Next
    End Sub
    Function EqualArray(array1 as string(), array2 as string()) As Boolean 
        For index As integer = 0 To array1.length-1
            If array1(index) <> array2(index) Then
                Return True
            End If
        Next
        Return False
    End Function
End Module