'This should be replaced with a real database reader for something like MySQL
Imports System
Imports System.IO
Public Class dbreader
Dim i As UInt64 = 0
Public Function ItemIDLookUp(ByVal Name As String) As Integer
	Dim Item() As String = File.ReadAllLines("../db/items.txt")
	Do Until i = Item.Length
		If Item(i).Contains(":" & Name & ":") = True Then
			Dim Temp() As String = Split(Item(i), ":")
			Return Temp(0)
		Else
			i += 1
		End If
	Loop
	Return -1 'If its not found
End Function
End Class
