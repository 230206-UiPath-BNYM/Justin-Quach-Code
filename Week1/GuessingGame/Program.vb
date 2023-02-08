Imports System

Module Program
    Sub Main(args As String())
        Console.Write("Target Word:  ")
        dim targetWord as string = Console.ReadLine()
        'Need to check for integers in word(Not Done)
        targetWord = targetWord.toLower() ' Convert the target word into all lower case letters
        dim wordLen as integer = Len(targetWord) 'Get length of the target word
        dim targetArray(wordLen) as string 'array for target word
        dim blankArray(wordLen) as string 'array for blank word
        dim count = 0
        For each i as string in targetWord 'populate both arrays
            targetArray(count) = i 'with letters from the target word
            blankArray(count) = "_" 'and blanks
            count = count + 1
        Next
        For index As integer = 0 To 20 'Create blank spaces so that the input word cannot be seen
            Console.WriteLine(vbCrLf)
        Next
        PrintMan(0) 'print the hangman ascii
        Console.Write("Guess the word:  ")
        dim guessLetter as string 'user input letter
        dim wrongCounter as integer 'how many wrong letters have been input
        dim checkLetter as boolean 'if the user input letter is a letter in the target word
        dim winLoss as boolean = True 'Win or Lose
        While EqualArray(targetArray, blankArray)
            guessLetter = Console.ReadLine() 'Get user input letter
            'check for single letter & no integers(Not Done)
            count = 0 'initialize counter
            checkLetter = True 'initialize bool
            For index As integer = 0 To wordLen 'checks through each index of the array containing the target word
                If guessLetter = targetArray(index) Then 'if the the target array at this index is the same as the input letter:
                    blankArray(index) = guessLetter 'edit the array of blanks and add in the guessed letter
                    checkLetter = False 'change the value of the bool to note that the user input letter has been found in the target word
                End If
            Next
            If checkLetter Then 'if checkLetter is true, the letter was not found in the target word. if false the letter was found
                wrongCounter = wrongCounter + 1 'add 1 to counter to indicate a wrong answer was given
            End If
            If wrongCounter = 6 Then 'if wrongCounter reaches 6, game is over
                winLoss = False 'indicate game has been lost
                Exit While 'Skip the rest of the while loop and exit the loop
            End If
            PrintMan(wrongCounter) 'Print the hangman ascii
            Console.Write("Word:  ") 'Print the word with blanks
            For index As integer = 0 To wordLen
                Console.Write(blankArray(index))
            Next
            Console.WriteLine(vbCrLf)
        End While
        If winLoss Then 
            Console.WriteLine("You Win")  'If the number of wrong answers has not reached 6, the value of winLoss would allow this to print
        Else Console.WriteLine("You Lose")'If the number of wrong answers is 6, the value of winLoss would allow this to print
        End If
    End Sub
    Sub PrintMan(tries as integer)
        Select Case tries 'Switch to print each stage of the hangman
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
    Sub Testing() 'Sub just for testing out the hangman ascii
        For index As integer = 0 To 6
            PrintMan(index)
        Next
    End Sub
    Function EqualArray(array1 as string(), array2 as string()) As Boolean 'Function to check through each index of 2 arrays; returns true if all values are the same false if a value differs
        For index As integer = 0 To array1.length-1
            If array1(index) <> array2(index) Then
                Return True
            End If
        Next
        Return False
    End Function
End Module