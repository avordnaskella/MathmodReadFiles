using System;
using System.Collections.Generic;
using System.Text;

namespace ReadF
{
    internal class Class1
    { //csv
        string[] lines;
        public void ReadFileCSV(string path)
        {
            lines = File.ReadAllLines(path);
            int countStr = lines.Length;

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
              
                Console.WriteLine( parts[0] + parts[1] +  parts[2] +  parts[3]  + parts[4]);
            }

           // File.WriteAllLines("output.csv", lines);
        }

        public void WriteFileCSV(string path)
        {
            // string[] text;
            // text = new string[] { "dkkdkd, 14", "dlld, 55", "dfkdk, 122" };
            // File.WriteAllLines(filename, text);

            File.WriteAllLines("output.csv", lines);
        }
    }
}
