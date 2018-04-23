Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports DevExpress.Web.Mvc
Imports DXWebApplication23.Models
Imports DevExpress.Spreadsheet

Namespace DXWebApplication23.Controllers
	Public Class HomeController
		Inherits Controller
		'
		' GET: /Home/

		<HttpGet> _
		Public Function Index() As ActionResult
			Return View()
		End Function

		<HttpPost> _
		Public Function Submit() As ActionResult
			Dim book As IWorkbook = SpreadsheetExtension.GetCurrentDocument("Spreadsheet")
			Dim docBytes() As Byte = book.SaveDocument(DocumentFormat.Xlsx)
			DataHelper.SaveDocument(docBytes)

			Return View("Index")
		End Function

		Public Function SpreadsheetPartial() As ActionResult
			Return PartialView("_SpreadsheetPartial", DataHelper.GetDocument())
		End Function

		Public Function SpreadsheetPartialDownload() As FileStreamResult
			Return SpreadsheetExtension.DownloadFile("Spreadsheet")
		End Function
	End Class
End Namespace