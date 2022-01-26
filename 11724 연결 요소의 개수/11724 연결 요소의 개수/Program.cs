using System;
using System.Collections.Generic;
class Program
{
    static int n, m, u, v, cc;
    static Queue<int> bfs = new Queue<int>();
    static void Main()
    {
        var nm = Console.ReadLine().Split();
        n = int.Parse(nm[0]);
        m = int.Parse(nm[1]);
        bool[] check = new bool[n];
        int[,] graph = new int[n, n];
        for (int i = 0; i < m; i++)
        {
            var uv = Console.ReadLine().Split();
            u = int.Parse(uv[0]) - 1;
            v = int.Parse(uv[1]) - 1;
            graph[u, v] = 1;
            graph[v, u] = 1;
        }
        for (int i = 0; i < n; i++)
        {
            if (!check[i])
            {
                bfs.Enqueue(i);
                check[i] = true;
                cc++;
            }
            while (bfs.Count > 0)
            {
                for (int j = 0; j < n; j++)
                {
                    if (graph[bfs.Peek(), j] == 1 && !check[j])
                    {
                        bfs.Enqueue(j);
                        check[j] = true;
                    }
                }
                bfs.Dequeue();
            }
        }
        Console.WriteLine(cc);
    }
}