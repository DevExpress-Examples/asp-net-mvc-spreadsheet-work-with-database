@ModelType DXWebApplication23.Models.SpreadsheetData

@Html.DevExpress().Spreadsheet( _
    Sub(settings)
            settings.Name = "SpreadsheetName"
            settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "SpreadsheetPartial"}
            settings.Width = System.Web.UI.WebControls.Unit.Percentage(100)
    End Sub).Open(Model.DocumentId, Model.DocumentFormat, _
                  Function()
                          Return Model.Document
                  End Function).GetHtml()