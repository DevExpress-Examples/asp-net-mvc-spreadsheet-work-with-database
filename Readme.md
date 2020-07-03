<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/DXWebApplication23/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/DXWebApplication23/Controllers/HomeController.vb))
* [DataHelper.cs](./CS/DXWebApplication23/Models/DataHelper.cs) (VB: [DataHelper.vb](./VB/DXWebApplication23/Models/DataHelper.vb))
* [Index.cshtml](./CS/DXWebApplication23/Views/Home/Index.cshtml)
* **[SpreadsheetPartial.cshtml](./CS/DXWebApplication23/Views/Home/SpreadsheetPartial.cshtml)**
<!-- default file list end -->
# Spreadsheet - How to save and load documents from a database

## Steps to implement:
1) Create a helper class that returns the Spreadsheet settings. Make sure that you specify the **Name** and the **CallbackRouteValues** properties:
```cs
 public static class SpreadsheetSettingsHelper {
        public static SpreadsheetSettings GetSpreadsheetSettings() {
            SpreadsheetSettings settings = new SpreadsheetSettings();
            settings.Name = "SpreadsheetName";
            settings.CallbackRouteValues = new { Controller = "Home", Action = "SpreadsheetPartial" };
            ...
            return settings;
        }
    }
```
2) Handle the Saving event in these settings and save the Spreadsheet document to byte[] with the [SaveCopy](https://docs.devexpress.com/AspNet/devexpress.web.mvc.spreadsheetextension.savecopy.overloads) method. Then, save the result to your database:
```cs
 settings.Saving = (s, e) =>
            {
                byte[] docBytes = SpreadsheetExtension.SaveCopy("SpreadsheetName", DocumentFormat.Xlsx);
                DataHelper.SaveDocument(docBytes);
                e.Handled = true;
            };
```
3) Use the helper in Partial View with Spreadsheet and in Controller:
```cs
@Html.DevExpress().Spreadsheet(SpreadsheetSettingsHelper.GetSpreadsheetSettings()).Open(Model.DocumentId, Model.DocumentFormat, () => { return Model.Document; }).GetHtml()
```
```cs
 public ActionResult SpreadsheetPartial() { // Spreadsheet's CallbackRouteAction method
            return SpreadsheetExtension.GetCallbackResult(SpreadsheetSettingsHelper.GetSpreadsheetSettings());
        }
```
<br><br><strong>See Also:<br>WebForms Version:</strong><br><a href="https://www.devexpress.com/Support/Center/p/T190812">T190812: ASPxSpreadsheet - How to save and load documents from a database</a>
### Change Log:


<strong>16.1:</strong>
<p>Spreadsheet allows handling certain actions in the Controller now. So, it is possible to save a document to a database using the Spreadsheet ribbon's 'Save' button.</p>
<strong>15.1:</strong>

Now you can use the <a href="https://docs.devexpress.com/AspNet/devexpress.web.mvc.spreadsheetextension.open.overloads">SpreadsheetExtension.Open</a>  method to load a document and call the <a href="https://docs.devexpress.com/AspNet/devexpress.web.mvc.spreadsheetextension.savecopy.overloads">SpreadsheetExtension.SaveCopy</a>  method to save changes.<br><br><strong>For Older Versions:</strong><br>Use <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressSpreadsheetISpreadsheetComponent_LoadDocumenttopic">ISpreadsheetComponent.LoadDocument</a> to load a document and <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressSpreadsheetISpreadsheetComponent_SaveDocumenttopic">ISpreadsheetComponent.SaveDocument</a> - to save it.

<br/>


