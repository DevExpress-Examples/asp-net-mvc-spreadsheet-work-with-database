Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Linq
Imports System.Web

Namespace DXWebApplication23.Models
	Public Class DataHelper
		Public Shared Function GetDocument() As Byte()
			Dim context As New DataClassesDataContext()
			Return context.Docs.FirstOrDefault().DocBytes.ToArray()
		End Function

		Public Shared Sub SaveDocument(ByVal bytes() As Byte)
			Dim context As New DataClassesDataContext()
			context.Docs.FirstOrDefault().DocBytes = bytes
			context.SubmitChanges()
		End Sub
	End Class
End Namespace