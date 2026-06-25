using System;
using System.Collections.Generic;
using System.Text;

namespace CodePrufer
{
    internal class Class1
    {
        int n; // количество вершин
        List<int>[] adj; // список смежности

        public void ReadFile(string filename)
        {
            string[] lines = File.ReadAllLines(filename); // читаем весь файл в массив строк
            n = int.Parse(lines[0]); // количество вершин

            adj = new List<int>[n + 1]; // массив списков
            for (int i = 1; i <= n; i++)
            {
                adj[i] = new List<int>(); // инициализируем каждый список
            }

            for (int i = 1; i <= n - 1; i++)
            {
                string[] parts = lines[i].Split(' ');
                int u = int.Parse(parts[0]);
                int v = int.Parse(parts[1]);

                adj[u].Add(v);
                adj[v].Add(u);
            }

        }

        public void WriteFile(string path, int[] code)
        {
            File.WriteAllText(path, "Код Прюфера: " + string.Join(" ", code));
        }

        public int[] Encode()
        {
            int[] degree = new int[n + 1]; // считаем степень каждой вершины
            for (int i = 1; i <= n; i++)
            {
                degree[i] = adj[i].Count;
            }

            int[] code = new int[n - 2]; // код прюфера всгда длиной -2
            
            for ( int step = 0; step < n - 2; step++) // повторяем n-2 раза
            {
                for (int v = 1; v <= n; v++) // перебираем все вершины по порядку
                {
                    if (degree[v] == 1) // нашли вершину с одним соседом
                    {
                        int neighbor = adj[v][0]; // единственный сосед вершины
                        code[step] = neighbor; //  записываем соседа в код

                        degree[v] = 0; // помечаем вершину как удалённую
                        adj[neighbor].Remove(v); // убираем вершину из списка соседей
                        degree[neighbor]--; // уменьшаем степень соседа
                        break; // следующий шаг
                    }
                }
            }
            return code;
        }
    }
}
