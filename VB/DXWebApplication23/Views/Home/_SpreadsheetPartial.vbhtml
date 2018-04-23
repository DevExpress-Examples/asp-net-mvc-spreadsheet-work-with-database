@Html.DevExpress().Spreadsheet(
    Sub(settings)
            settings.Name = "Spreadsheet"
            settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "SpreadsheetPartial"}
            settings.DownloadRouteValues = New With {.Controller = "Home", .Action = "SpreadsheetPartialDownload"}
            settings.Width = System.Web.UI.WebControls.Unit.Percentage(100)
            settings.Height = 500
            settings.RibbonMode = SpreadsheetRibbonMode.Ribbon
            If (Model IsNot Nothing) Then
                settings.PreRender = Sub(s, e)
                                             Dim spreadsheet As MVCxSpreadsheet = DirectCast(s, MVCxSpreadsheet)
                                             spreadsheet.Document.LoadDocument(DirectCast(Model, Byte()), DevExpress.Spreadsheet.DocumentFormat.Xlsx)
                                     End Sub
            End If
    End Sub).GetHtml()