using System;
using System.Collections.Generic;
using System.Text;

namespace Dijkstra
{
    internal class Class1
    {
        int[,] graph;
        int start;
        int n;

        public void ReadFile(string path)
        {
            string[] lines = File.ReadAllLines(path);
            int idx = 0;
            n = int.Parse(lines[idx++]);

            graph = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                string[] parts = lines[idx++].Split(' ');
                for (int j = 0; j < n; j++)
                {
                    graph[i,j] = int.Parse(parts[j]);
                }
            }
            start = int.Parse(lines[idx++]);
        }

        public void WriteFile(string path, int[] result)
        {
            using StreamWriter sw = new StreamWriter(path);
            sw.WriteLine("Кратчайшие пути");
            for (int i = 0; i < n; i++)
            {
                sw.WriteLine($"{start} -> {i + 1}: {result[i]}");

            }
        }

        public int[] FindShortPath()
        {
            n = graph.GetLength(0);
            int[] dist = new int[n];
            bool[] visited = new bool[n];

            for (int i = 0; i < n; i++)
            {
                dist[i] = int.MaxValue;
            }

            dist[start - 1] = 0;

            for (int step = 0; step < n - 1; step++)
            {
                int u = -1;
                for (int v = 0;v < n; v++)
                {
                    if (!visited[v] && (u == -1 || dist[v] < dist[u]))
                        u = v;
                }

                if (dist[u] == int.MaxValue) break;
                visited[u] = true;

                for (int v = 0; v < n; v++)
                {
                    if (graph[u, v] > 0 && !visited[v] && dist[u] + graph[u, v] < dist[v]) // ребро существует, вершина не обработана, новый путь короче текущего
                        dist[v] = dist[u] + graph[u, v]; // обновляем расстояние
                }
            }
            return dist;
        }
    }
}
