Imports System
Imports System.IO
Public Class Shops
Public Items() As String = File.ReadAllLines("../db/items.txt")	'Example database containing item IDs
Public Shop As String = File.ReadAllText("../db/shops.txt")	'Contains shop info
Public Inv As String = File.ReadAllText("../db/inventory.txt")	'Contains players inventory
Public Function Buy(ByVal ShopName As String, ByVal ItemID As UInt32, ByVal PlayersMoney As Integer) As String
	If Inv.Contains(ItemID) = True Then
		Return "Player has it"
	ElseIf Shop.Contains(ShopName) = True AndAlso Shop.Contains(ItemID) = True Then
		Dim Cost As Integer
		Dim Temp() As String = Split
		Return "Foo"
	Else
		Return "Not Found"
	End If
End Function
End Class
'********NOT FINISHED*******
