using System;
using System.Text;
using System.Collections.Generic;
class Program
{
    static int V, E, K, u, v, w;
    static StringBuilder result = new StringBuilder();
    static Queue<int> bfs = new Queue<int>();
    static void Main()
    {
        var VE = Console.ReadLine().Split();
        V = int.Parse(VE[0]);
        E = int.Parse(VE[1]);
        K = int.Parse(Console.ReadLine()) - 1;
        int[] distance = new int[V];
        int[,] graph = new int[V, V];
        for (int i = 0; i < E; i++)
        {
            var uvw = Console.ReadLine().Split();
            u = int.Parse(uvw[0]) - 1;
            v = int.Parse(uvw[1]) - 1;
            w = int.Parse(uvw[2]);
            graph[u, v] = w;
        }
        bfs.Enqueue(K);
        while (bfs.Count > 0)
        {
            for (int i = 0; i < V; i++)
            {
                if (graph[bfs.Peek(), i] != 0)
                {
                    bfs.Enqueue(i);
                    if (distance[i] != 0)
                    {
                        if(distance[bfs.Peek()] + graph[bfs.Peek(), i] < distance[i])
                        {
                            distance[i] = distance[bfs.Peek()] + graph[bfs.Peek(), i];
                        }
                    }
                    else distance[i] = distance[bfs.Peek()] + graph[bfs.Peek(), i];
                }
            }
            bfs.Dequeue();
        }
        for (int i = 0; i < V; i++)
        {
            if (i == K) result.AppendLine(0.ToString());
            else result.AppendLine(distance[i] == 0 ? "INF" : distance[i].ToString());
        }
        Console.WriteLine(result);
    }
}