@ModelType DXWebApplication23.Models.SpreadsheetData

@Html.DevExpress().Spreadsheet(
    Sub(settings)
            settings.Name = "Spreadsheet"
            settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "SpreadsheetPartial"}
            settings.Width = System.Web.UI.WebControls.Unit.Percentage(100)
            settings.RibbonMode = SpreadsheetRibbonMode.Ribbon
    End Sub).Open(
        Model.DocumentId, Model.DocumentFormat,
        Function()
                Return Model.Document
        End Function).GetHtml()