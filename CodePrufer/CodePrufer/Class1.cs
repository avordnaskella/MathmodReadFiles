using System;
using System.Collections.Generic;
using System.Text;

namespace CodePrufer
{
    internal class Class1
    {
       int n;
       List<int>[] adj;

       public void ReadFromFile(string path)
        {
            string[] lines = File.ReadAllLines(path);

            n = int.Parse(lines[0]);

            adj = new List<int>[n + 1];
            for (int i = 1; i <= n; i++)
                adj[i] = new List<int>();

            for (int i = 1; i <= n - 1; i++)
            {
                string[] parts = lines[i].Split(' ');
                int u = int.Parse(parts[0]);
                int v = int.Parse(parts[1]);
                adj[u].Add(v);
                adj[v].Add(u);
            }
        }

        public  int[] Encode()
        {
            int[] degree = new int[n + 1];
            for (int i = 1; i <= n; i++)
                degree[i] = adj[i].Count;

            List<int>[] copy = new List<int>[n + 1];
            for (int i = 1; i <= n; i++)
                copy[i] = new List<int>(adj[i]);

            int[] code = new int[n - 2];

            for (int step = 0; step < n - 2; step++)
            {
                for (int v = 1; v <= n; v++)
                {
                    if (degree[v] == 1)
                    {
                        int neighbor = copy[v][0];
                        code[step] = neighbor;

                        degree[v] = 0;
                        copy[neighbor].Remove(v);
                        degree[neighbor]--;
                        break;
                    }
                }
            }

            return code;
        }

        // Записываем результат в файл
       public void WriteFile(string path, int[] code)
        {
            File.WriteAllText(path, "Код Прюфера: " + string.Join(" ", code));
        }

    }
}
