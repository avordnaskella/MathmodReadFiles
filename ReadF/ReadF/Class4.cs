using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Text;

// установить nuget пакет closedxml
namespace ReadF
{
    internal class Class4
    {
 public void ReadAndWriteXl(string path)
  {
      using (XLWorkbook wbIn = new XLWorkbook(path))
      using (XLWorkbook wbOut = new XLWorkbook())
      {
          IXLWorksheet wsIn = wbIn.Worksheet(1);
          IXLWorksheet wsOut = wbOut.Worksheets.Add("sheets1");

          int outRow = 1;

          foreach(IXLRow row in wsIn.RowsUsed())
          {
              int age = row.Cell(2).GetValue<int>();
              if (age > 15)
              {
                  foreach(IXLCell cell in row.CellsUsed())
                  {
                      wsOut.Cell(outRow, cell.Address.ColumnNumber).Value = cell.Value; 
                  }
                  outRow++;
              }
          }
          wbOut.SaveAs("filter.xlsx");
      }
  }

public void ReadAndWrite(string path)
 {
     using (XLWorkbook wbIn = new XLWorkbook(path)) 
     using(XLWorkbook wbOut= new XLWorkbook())
     {
         IXLWorksheet wsIn = wbIn.Worksheet(1);
         IXLWorksheet wsOut = wbOut.Worksheets.Add("sheet1");
         int outRow = 1;
         foreach (IXLRow row in wsIn.RowsUsed())
         {
             Console.WriteLine(row.Cell(1).GetValue<string>() + row.Cell(2).GetValue<string>());
             foreach (IXLCell cell in row.CellsUsed())
             {
                 wsOut.Cell(outRow, cell.Address.ColumnNumber).Value = cell.Value;
             }
         }

         wbOut.SaveAs("prim.xlsx");
     }
     
 }
        
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


        
public void Filter(string path)
{
    using XLWorkbook wbIn = new XLWorkbook(path);
    using XLWorkbook wbOut = new XLWorkbook();
    {
        IXLWorksheet wsI = wbIn.Worksheet(1);
        IXLWorksheet wsO = wbOut.Worksheets.Add("sheet1");

        int outRow = 1;

        foreach (IXLRow row in wsI.RowsUsed())
        {
            int age = row.Cell(2).GetValue<int>();
            if (age > 5)
            {
                wsO.Cell(outRow,1).Value = row.Cell(1).GetValue<string>();
                wsO.Cell(outRow,2).Value = row.Cell(2).GetValue<string>();
                outRow++;

            }
        }

        wbOut.SaveAs("itog.xlsx");
    }
}
    }
}
