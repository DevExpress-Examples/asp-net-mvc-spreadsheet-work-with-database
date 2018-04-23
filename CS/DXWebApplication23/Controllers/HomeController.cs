using System;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using DXWebApplication23.Models;
using DevExpress.Spreadsheet;

namespace DXWebApplication23.Controllers {
    public class HomeController : Controller {

        [HttpGet]
        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult Submit() {
            byte[] docBytes = SpreadsheetExtension.SaveCopy("Spreadsheet", DocumentFormat.Xlsx);
            DataHelper.SaveDocument(docBytes);
            return View("Index");
        }

        public ActionResult SpreadsheetPartial() {
            var model = new SpreadsheetData() {
                DocumentId = Guid.NewGuid().ToString(),
                DocumentFormat = DocumentFormat.Xlsx,
                Document = DataHelper.GetDocument()
            };
            return PartialView("_SpreadsheetPartial", model);
        }
    }
}