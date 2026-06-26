using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Text;

// установить nuget пакет closedxml
namespace ReadF
{
    internal class Class4
    {
       public void ReadXlsx(string path)
        {
            using (XLWorkbook wb = new XLWorkbook(path))
            {
                
                IXLWorksheet ws = wb.Worksheet(1);
                foreach (IXLRow row in ws.RowsUsed())
                {
                   Console.WriteLine(row.Cell(1).GetValue<string>() + " " + row.Cell(2).GetValue<int>() + " ");
                }
            }
        }

        public void WriteXlsx(string path)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {

                IXLWorksheet ws = wb.Worksheets.Add("Sheet1");
                ws.Cell(1, 1).Value = "Ira";
                ws.Cell(1, 2).Value = "Ira";
                ws.Cell(2, 1).Value = "Ira";

                wb.SaveAs(path);
            }
        }
    }
}
