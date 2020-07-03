@ModelType DXWebApplication23.Models.SpreadsheetData
@Imports DXWebApplication23.Controllers

@Html.DevExpress().Spreadsheet(SpreadsheetSettingsHelper.GetSpreadsheetSettings()).Open(Model.DocumentId, Model.DocumentFormat,
                              Function()
                                  Return Model.Document
                              End Function).GetHtml()