using System;
using System.Text;
using System.Collections.Generic;
class Program
{
    static int n, m, v, p, q;
    static int[,] graph = new int[1000, 1000];
    static bool[] check = new bool[1000];
    static StringBuilder result = new StringBuilder();
    static Queue<int> BFS = new Queue<int>();
    static void Main()
    {
        var nmv = Console.ReadLine().Split();
        n = int.Parse(nmv[0]);
        m = int.Parse(nmv[1]);
        v = int.Parse(nmv[2]);
        for (int i = 0; i < m; i++)
        {
            var pq = Console.ReadLine().Split();
            p = int.Parse(pq[0]);
            q = int.Parse(pq[1]);
            graph[p - 1, q - 1] = 1;
            graph[q - 1, p - 1] = 1;
        }
        DFS(v - 1);
        for (int i = 0; i < n; i++)
        {
            check[i] = false;
        }
        Console.WriteLine(result);
        result.Clear();
        BFS.Enqueue(v - 1);
        check[v - 1] = true;
        while (BFS.Count > 0)
        {
            for (int i = 0; i < n; i++)
            {
                if (!check[i] && graph[BFS.Peek(), i] == 1)
                {
                    BFS.Enqueue(i);
                    check[i] = true;
                }
            }
            result.Append((BFS.Dequeue() + 1).ToString());
            result.Append(' ');
        }
        Console.WriteLine(result);
    }

    static void DFS(int d)
    {
        check[d] = true;
        result.Append((d + 1).ToString());
        result.Append(' ');
        for (int i = 0; i < n; i++)
        {
            if (!check[i] && graph[d, i] == 1)
            {
                DFS(i);
            }
        }
        return;
    }
}