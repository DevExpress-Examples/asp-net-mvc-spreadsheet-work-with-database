using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

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
}