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

        <HttpGet> _
        Public Function Index() As ActionResult
            Return View()
        End Function

		<HttpPost> _
        Public Function Submit() As ActionResult
            Dim docBytes() As Byte = SpreadsheetExtension.SaveCopy("Spreadsheet", DocumentFormat.Xlsx)
            DataHelper.SaveDocument(docBytes)
            Return View("Index")
        End Function

        Public Function SpreadsheetPartial() As ActionResult
            Dim model = New SpreadsheetData() With {
                .DocumentId = Guid.NewGuid().ToString(),
                .DocumentFormat = DocumentFormat.Xlsx,
                .Document = DataHelper.GetDocument()
            }
            Return PartialView("_SpreadsheetPartial", model)
        End Function

	End Class
End Namespace