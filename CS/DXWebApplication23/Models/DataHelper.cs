using System;
using System.Linq;
using DevExpress.Spreadsheet;

namespace DXWebApplication23.Models {
    public class DataHelper {
        public static byte[] GetDocument() {
            DataClassesDataContext context = new DataClassesDataContext();
            return context.Docs.FirstOrDefault().DocBytes.ToArray();
        }

        public static void SaveDocument(byte[] bytes) {
            DataClassesDataContext context = new DataClassesDataContext();
            context.Docs.FirstOrDefault().DocBytes = bytes;
            context.SubmitChanges();
        }
    }

    public class SpreadsheetData {
        public string DocumentId { get; set; }
        public DocumentFormat DocumentFormat { get; set; }
        public byte[] Document { get; set; }
    }
}