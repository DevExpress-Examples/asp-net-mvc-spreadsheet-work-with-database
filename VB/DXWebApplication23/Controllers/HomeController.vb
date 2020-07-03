Imports System
Imports System.Web.Mvc
Imports DevExpress.Spreadsheet
Imports DevExpress.Web.Mvc
Imports DXWebApplication23.Models

Namespace DXWebApplication23.Controllers
	Public Class HomeController
		Inherits Controller

		<HttpGet>
		Public Function Index() As ActionResult
			Dim model = New SpreadsheetData() With {.DocumentId = Guid.NewGuid().ToString(), .DocumentFormat = DocumentFormat.Xlsx, .Document = DataHelper.GetDocument()}
			Return View(model)
		End Function

		Public Function SpreadsheetPartial() As ActionResult
			Return SpreadsheetExtension.GetCallbackResult(SpreadsheetSettingsHelper.GetSpreadsheetSettings())
		End Function
	End Class
	Public NotInheritable Class SpreadsheetSettingsHelper

		Private Sub New()
		End Sub

		Public Shared Function GetSpreadsheetSettings() As SpreadsheetSettings
			Dim settings As New SpreadsheetSettings()
			settings.Name = "SpreadsheetName"
			settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "SpreadsheetPartial"}
			settings.Width = System.Web.UI.WebControls.Unit.Percentage(100)
			settings.Height = 500
			settings.Saving = Sub(s, e)
				Dim docBytes() As Byte = SpreadsheetExtension.SaveCopy("SpreadsheetName", DocumentFormat.Xlsx)
				DataHelper.SaveDocument(docBytes)
				e.Handled = True
			End Sub
			Return settings
		End Function
	End Class
End Namespace