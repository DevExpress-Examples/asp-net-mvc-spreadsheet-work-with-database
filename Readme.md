<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128553954/20.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T190813)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# Spreadsheet for ASP.NET MVC - How to save and load documents from a database

This example demonstrates how to configure the [Spreadsheet extension](https://docs.devexpress.com/AspNetMvc/17113/components/spreadsheet) to save and load documents from a database.

![Connect Spreadsheet to Database](connect-spreadsheet-to-database.png)

## Overview

Follow the steps below to configure the Spreadsheet extension to work with a database:

1. Create a class that models a spreadsheet document. This class should be able to store a document's identifier, format, and contents:

    ```cs
    public class SpreadsheetData {
        public string DocumentId { get; set; }
        public DocumentFormat DocumentFormat { get; set; }
        public byte[] Document { get; set; }
    }
    ```

2. Register the database context:

    ```cs
    public partial class DocumentsEntities : DbContext {
        public DocumentsEntities(): base("name=DocumentsEntities") {}
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            throw new UnintentionalCodeFirstException();
        }
        public virtual DbSet<Doc> Docs { get; set; }
    }

    public partial class Doc {
        public int Id { get; set; }
        public byte[] DocBytes { get; set; }
        public string Comments { get; set; }
    }
    ```

3. Add connection strings:

    ```xml
    <connectionStrings>
        <add name="DocumentsConnectionString" connectionString="Data Source=(local);Initial Catalog = Documents;User Id=sa; Password=dx;Connect Timeout=30" providerName="System.Data.SqlClient" />
        <add name="DocumentsEntities" connectionString="metadata=res://*/Models.Model1.csdl|res://*/Models.Model1.ssdl|res://*/Models.Model1.msl;provider=System.Data.SqlClient;provider connection string=&quot;Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Documents.mdf;Integrated Security=True;connect timeout=30;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
    </connectionStrings>
    ```

4. Create a helper class that configures and returns the [SpreadsheetSettings](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.SpreadsheetSettings?p=netframework) object. In the class method, specify the object's [Name](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.SettingsBase.Name) and [CallbackRouteValues](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.SpreadsheetSettings.CallbackRouteValues) properties. Set the [Saving](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.SpreadsheetSettings.Saving?p=netframework) property to a function that converts an open document to a byte array and saves the array to the database:

    ```cs
    public static class SpreadsheetSettingsHelper {
            public static SpreadsheetSettings GetSpreadsheetSettings() {
                SpreadsheetSettings settings = new SpreadsheetSettings();
                settings.Name = "SpreadsheetName";
                settings.CallbackRouteValues = new { Controller = "Home", Action = "SpreadsheetPartial" };
                settings.Saving = (s, e) => {
                    byte[] docBytes = SpreadsheetExtension.SaveCopy("SpreadsheetName", DocumentFormat.Xlsx);
                    DataHelper.SaveDocument(docBytes);
                    e.Handled = true;
                };
                // ...
                return settings;
            }
        }
    ```

5. In a partial view, declare the Spreadsheet extension with the settings that the helper class configures. Call the Spreadsheet's [Open](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.RichEditExtension.Open(System.String-DevExpress.XtraRichEdit.DocumentFormat-System.Func-System.Byte---)?p=netframework) method overload to open a document the model contains:

    ```razor
    @Html.DevExpress().Spreadsheet(SpreadsheetSettingsHelper.GetSpreadsheetSettings()).Open(
        Model.DocumentId, 
        Model.DocumentFormat, 
        () => { return Model.Document; }
    ).GetHtml()
    ```

6. In the action method assigned to the `CallbackRouteValues` property, use the helper class to get the Spreadsheet extension setting. Pass the settings to the [GetCallbackResult](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.SpreadsheetExtension.GetCallbackResult(DevExpress.Web.Mvc.SpreadsheetSettings)?p=netframework) method overload to return the result of callback processing back to the client: 

    ```cs
    public ActionResult SpreadsheetPartial() { // Spreadsheet's CallbackRouteAction method
        return SpreadsheetExtension.GetCallbackResult(SpreadsheetSettingsHelper.GetSpreadsheetSettings());
    }
    ```

## Files to Review

* **[SpreadsheetPartial.cshtml](./CS/DXWebApplication23/Views/Home/SpreadsheetPartial.cshtml)**
* [HomeController.cs](./CS/DXWebApplication23/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/DXWebApplication23/Controllers/HomeController.vb))
* [DataHelper.cs](./CS/DXWebApplication23/Models/DataHelper.cs) (VB: [DataHelper.vb](./VB/DXWebApplication23/Models/DataHelper.vb))
* [Index.cshtml](./CS/DXWebApplication23/Views/Home/Index.cshtml)

## Documentation

* [Creating a Connection String and Working with SQL Server LocalDB](https://learn.microsoft.com/en-us/aspnet/mvc/overview/getting-started/introduction/creating-a-connection-string)
* [Office Document Management](https://docs.devexpress.com/AspNetMvc/402337/common-features/office-document-management)

## More Examples

* [Spreadsheet for ASP.NET Web Forms - How to save and load documents from a database](https://github.com/DevExpress-Examples/aspxspreadsheet-how-to-save-and-load-documents-from-a-database-t190812)
