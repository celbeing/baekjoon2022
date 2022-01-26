using System;
using System.Collections.Generic;
class Program
{
    static int V, E, K, u, v, w;
    static Queue<int> bfs = new Queue<int>();
    static void Main()
    {
        var VE = Console.ReadLine().Split();
        V = int.Parse(VE[0]);
        E = int.Parse(VE[1]);
        K = int.Parse(Console.ReadLine());
        int[,] graph = new int[V, V];
        for(int i = 0; i < E; i++)
        {
            var uvw = Console.ReadLine().Split();
            u = int.Parse(uvw[0]);
            v = int.Parse(uvw[1]);
            w = int.Parse(uvw[2]);
            graph[u, v] = w;
        }
    }
}