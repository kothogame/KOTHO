'*************************************************
'* This library is for random events in the game *
'*************************************************

Imports System
Imports System.Console
Public Class RandomEvent

Public Function RandomNumber(Optional Lowest As Integer = 1, Optional Highest As Integer = 100) As Integer
	If Lowest > Highest Then
		WriteLine("Error: Lowest number must be smaller than the Highest")
		WriteLine("Returning 0 due to error.")
		Return 0
	Else
		Dim Work As New Random
		Return Work.Next(Highest, Lowest)
	End If
End Function

Public Function SpawnEnemy(Optional Chance As Integer = 1) As Boolean
	If RandomNumber(1, 20) <= Chance Then
		Return True
	Else
		Return False
	End If 
End Function
End Class
