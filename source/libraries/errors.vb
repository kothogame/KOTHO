'**********************************************************
'* This library is to handles errors through-out the game *
'**********************************************************

Imports System
Imports System.Console
Imports System.Threading
Public Class ErrorHandler

Dim EMsg As String = Nothing
Public Function Er(Optional ErDescription As String = Nothing, Optional ErNumber As Integer = -1, Optional Type As String = "console") As Boolean
	If ErNumber = 0 AndAlso ErDescription = Nothing Then
		EMsg = "The error event was raised but an error did not occure!"
	ElseIf ErNumber = 1 Then
		EMsg = "This is a test."
	Else
		EMsg = ErDescription
	End If
	If Type = "console" Then
		Dim DefaultFColor As ConsoleColor = Console.ForeGroundColor
		Console.ForegroundColor = ConsoleColor.Red
		WriteLine("Error: " & EMsg)
		Console.ForegroundColor = DefaultFColor
	ElseIf Type = "msgbox" Then
		Dim Worker As New Thread(AddressOf MBox)
		Worker.Start()
	Else
		WriteLine("Error: " & Type & " is not a type of handling!")
		WriteLine("The current available types are 'console' and 'msgbox'")
	End If
	Return True
End Function

Private Sub MBox()
	MsgBox(EMsg, 16, "King Of The Hill Online")
End Sub
End Class
