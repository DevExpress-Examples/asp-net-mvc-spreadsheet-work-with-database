using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using DXWebApplication23.Models;
using DevExpress.Spreadsheet;

namespace DXWebApplication23.Controllers {
    public class HomeController : Controller {
        //
        // GET: /Home/

        [HttpGet]
        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult Submit() {
            IWorkbook book = SpreadsheetExtension.GetCurrentDocument("Spreadsheet");
            byte[] docBytes = book.SaveDocument(DocumentFormat.Xlsx);
            DataHelper.SaveDocument(docBytes);

            return View("Index");
        }

        public ActionResult SpreadsheetPartial() {
            return PartialView("_SpreadsheetPartial", DataHelper.GetDocument());
        }

        public FileStreamResult SpreadsheetPartialDownload() {
            return SpreadsheetExtension.DownloadFile("Spreadsheet");
        }
    }
}