'*********************************************************
'* This library is to handle errors through-out the game *
'*********************************************************

Imports System
Imports System.IO
Imports System.Console
Imports System.Threading
Public Class ErrorHandler

Dim EMsg As String = Nothing
Dim EType As String = "Error"
Public Function Er(Optional ErDesc As String = Nothing, Optional ErNumber As Integer = -1, Optional Type As String = "console") As Boolean
	Try
	If ErNumber = 0 AndAlso ErDesc = Nothing Then
		Warn("The error event was raised but an error did not occur!")
		Return True
	ElseIf ErNumber = 1 Then
		EMsg = "This is a test."
	Else
		EMsg = ErDesc
	End If
	If Type = "console" Then
		Dim DefaultFColor As ConsoleColor = Console.ForeGroundColor
		Console.ForegroundColor = ConsoleColor.Red
		WriteLine("Error: " & EMsg)
		Console.ForegroundColor = DefaultFColor
	ElseIf Type = "msgbox" Then 'May cause an issue on some Unix based systems with Mono
		Dim Worker As New Thread(AddressOf MBox)
		Worker.Start()
	ElseIf Type = "log" Then
		File.AppendAllText("error.log", "Error: " & EMsg & VbNewLine)
	Else
		WriteLine("Error: " & Type & " is not a type of handling!")
		WriteLine("The current available types are 'console', 'log', and 'msgbox'")
	End If
	Return True
	Catch
	EMsg = EMsg & VbNewLine & "Error: " & Err.Description 'Appends the original error message
	Dim Worker As New Thread(AddressOf MBox)
        Worker.Start()
	Return False
	End Try
End Function

Public Function Warn(Optional WDesc As String = Nothing, Optional WNumber As Integer = -1, Optional Type As String = "console") As Boolean
	If WNumber = -1 AndAlso WDesc = Nothing Then
		EMsg = "A warning was raised but nothing occured to raise it!"
	ElseIf WNumber = 1 Then
		EMsg = "This is a test."
	Else
		EMsg = WDesc
	End If
	If Type = "console" Then
                Dim DefaultFColor As ConsoleColor = Console.ForeGroundColor
                Console.ForegroundColor = ConsoleColor.Yellow
                WriteLine("Warn: " & EMsg)
                Console.ForegroundColor = DefaultFColor
        ElseIf Type = "msgbox" Then 'May cause an issue on some Unix based systems with Mono
                EType = "Warn"
		Dim Worker As New Thread(AddressOf MBox)
                Worker.Start()
	Else
                WriteLine("Error: " & Type & " is not a type of handling!")
                WriteLine("The current available types are 'console' and 'msgbox'")
        End If
	Return True
End Function

Private Sub MBox()
	Dim i As UInt16 = 16
	If EType = "Error" Then
		i = 16
	Else
		i = 48
	End If
	MsgBox(EMsg, i, "King Of The Hill Online")
End Sub
End Class
