<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/DXWebApplication23/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/DXWebApplication23/Controllers/HomeController.vb))
* [DataHelper.cs](./CS/DXWebApplication23/Models/DataHelper.cs) (VB: [DataHelper.vb](./VB/DXWebApplication23/Models/DataHelper.vb))
* [Index.cshtml](./CS/DXWebApplication23/Views/Home/Index.cshtml)
* **[SpreadsheetPartial.cshtml](./CS/DXWebApplication23/Views/Home/SpreadsheetPartial.cshtml)**
<!-- default file list end -->
# Spreadsheet - How to save and load documents from a database


<strong>UPDATED:<br><br></strong>
<p>Starting with v16.1, Spreadsheet provides the capability to handle certain actions in the Controller. So, it is possible to save a document to a database using the Spreadsheet ribbon's 'Save' button.<br><br></p>
<strong>UPDATED:</strong><br><br>This code example demonstrates how to save and restore Spreadsheet documents from a database using a Binary column.<br>Starting with version <strong>15.1</strong>, it is possible to use the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebMvcSpreadsheetExtension_Opentopic">SpreadsheetExtension.Open</a>  method to load a document and call the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebMvcSpreadsheetExtension_SaveCopytopic">SpreadsheetExtension.SaveCopy</a>  method to save changes.<br><br><strong>For Older Versions:</strong><br>Use <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressSpreadsheetISpreadsheetComponent_LoadDocumenttopic">ISpreadsheetComponent.LoadDocument</a> to load a document and <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressSpreadsheetISpreadsheetComponent_SaveDocumenttopic">ISpreadsheetComponent.SaveDocument</a> - to save it.<br><br><strong>See Also:<br>WebForms Version:</strong><br><a href="https://www.devexpress.com/Support/Center/p/T190812">T190812: ASPxSpreadsheet - How to save and load documents from a database</a>

<br/>


