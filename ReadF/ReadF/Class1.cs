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
            

            File.WriteAllLines("output.csv", lines);
        }
    }
}
