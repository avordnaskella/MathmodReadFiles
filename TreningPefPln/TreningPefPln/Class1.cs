using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace TreningPefPln
{
    internal class Class1
    {
        int[] sypply; //поставщики
        int[] demand;// потребители
        double[,] cost;// тарифы
        double[,] plan; // опорное распределение
        double totalCost; // цеелвая функция

        public void ReadFile(string path)
        {
            string [] lines = File.ReadAllLines(path); // читаем все строки в файле
            int idx = 0; // номер текущей строки

            int m = int.Parse(lines[idx++]); //количество поставщиков первая строка
            int n = int.Parse(lines[idx++]); // количество потребителей вторая строка

            sypply = Array.ConvertAll(lines[idx++].Split(' '), int.Parse); // значение поставщиклв
            demand = Array.ConvertAll(lines[idx++].Split(' '), int.Parse); // значение потребителей

            cost = new double[m, n]; // размер матрицы

            for (int i = 0; i < m; i++)
            {
                string[] parts = lines[idx++].Split(' ');
                for (int j = 0; j < n; j++)
                {
                    cost[i,j] = double.Parse(parts[j]);
                }
            }
        }

        public void WriteFile(string path) 
        { 
            using StreamWriter sw = new StreamWriter(path);
            
            sw.WriteLine("Опорный план: ");
            for (int i = 0; i < plan.GetLength(0); i++)
            {
                for (int j = 0;j < plan.GetLength(1); j++)
                {
                 
                    sw.Write(plan[i,j] + " ");

                }
                sw.WriteLine();
            }
            sw.WriteLine("Значение целевой функции " + totalCost);
        }

        public void Northwest()
        {
            int m = sypply.Length;
            int n = demand.Length;
            plan = new double[m, n];

            int[] s = (int[])sypply.Clone();
            int[] d = (int[])demand.Clone();
            // копиии чтобы не портить входные данные
            totalCost = 0;

            int i = 0; 
            int j = 0;

            while (i< m && j < n)
            {
                int qty = Math.Min(s[i], d[j]);
                plan[i, j] = qty;

                totalCost += qty * cost[i,j];

                s[i] -= qty;
                d[j] -= qty;

                if (s[i] == 0 && d[j] == 0)
                {
                    i++;
                    j++;
                }
                else if (s[i] == 0)
                {
                    i++;
                }
                else 
                { 
                    j++; 
                }

            }

        }

        public void MinEl()
        {
            int m = sypply.Length;
            int n = demand.Length;
            plan = new double[m, n];

            int[] s = (int[])sypply.Clone();
            int[] d = (int[])demand.Clone();
            // копиии чтобы не портить входные данные
            totalCost = 0;

            while (true)
            {
                double minCost = double.MaxValue;
                int minI = -1;
                int minJ = -1;

                for (int i = 0; i < m; i++)
                {
                    if (s[i] == 0) continue;
                    for (int j = 0; j < n; j++)
                    {
                        if (d[j] == 0) continue;
                        if (cost[i, j] < minCost)
                        {
                            minCost = cost[i, j];
                            minI = i; minJ = j;
                        }
                    }
                }

                if (minI == -1) break;

                int qty = Math.Min(s[minI], d[minJ]);
                plan[minI, minJ] = qty;
                totalCost += qty * cost[minI, minJ];
                s[minI] -= qty;
                d[minJ] -= qty;
            }
        }

    }
}


