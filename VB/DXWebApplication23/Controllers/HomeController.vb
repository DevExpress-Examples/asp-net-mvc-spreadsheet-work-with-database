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
            Return SpreadsheetExtension.GetCallbackResult("SpreadsheetName", _
                                                          Sub(p)
                                                              p.Saving(Sub(e)
                                                                           Dim docBytes() As Byte = SpreadsheetExtension.SaveCopy("SpreadsheetName", DocumentFormat.Xlsx)
                                                                           DataHelper.SaveDocument(docBytes)
                                                                           e.Handled = True
                                                                       End Sub)
                                                          End Sub)
        End Function
    End Class
End Namespace