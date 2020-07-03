using System;
using System.Linq;
using DevExpress.Spreadsheet;

namespace DXWebApplication23.Models {
    public class DataHelper {
        public static byte[] GetDocument() {
            DocumentsEntities context = new DocumentsEntities();
            return context.Docs.FirstOrDefault().DocBytes.ToArray();
        }

        public static void SaveDocument(byte[] bytes) {
            DocumentsEntities context = new DocumentsEntities();
            context.Docs.FirstOrDefault().DocBytes = bytes;
            context.SaveChanges();
        }
    }

    public class SpreadsheetData {
        public string DocumentId { get; set; }
        public DocumentFormat DocumentFormat { get; set; }
        public byte[] Document { get; set; }
    }
}