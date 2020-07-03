using System;
using System.Web.Mvc;
using DevExpress.Spreadsheet;
using DevExpress.Web.Mvc;
using DXWebApplication23.Models;

namespace DXWebApplication23.Controllers {
    public class HomeController : Controller {
        [HttpGet]
        public ActionResult Index() {
            var model = new SpreadsheetData() {
                DocumentId = Guid.NewGuid().ToString(),
                DocumentFormat = DocumentFormat.Xlsx,
                Document = DataHelper.GetDocument()
            };
            return View(model);
        }

        public ActionResult SpreadsheetPartial() {
            return SpreadsheetExtension.GetCallbackResult(SpreadsheetSettingsHelper.GetSpreadsheetSettings());
        }
    }
    public static class SpreadsheetSettingsHelper {
        public static SpreadsheetSettings GetSpreadsheetSettings() {
            SpreadsheetSettings settings = new SpreadsheetSettings();
            settings.Name = "SpreadsheetName";
            settings.CallbackRouteValues = new { Controller = "Home", Action = "SpreadsheetPartial" };
            settings.Width = System.Web.UI.WebControls.Unit.Percentage(100);
            settings.Height = 500;
            settings.Saving = (s, e) =>
            {
                byte[] docBytes = SpreadsheetExtension.SaveCopy("SpreadsheetName", DocumentFormat.Xlsx);
                DataHelper.SaveDocument(docBytes);
                e.Handled = true;
            };
            return settings;
        }
    }
}