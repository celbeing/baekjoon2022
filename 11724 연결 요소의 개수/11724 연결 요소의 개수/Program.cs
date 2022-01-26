using System;
class Program
{
    static int n, m, u, v, cc;
    static bool[] check = new bool[1000];
    static int[,] graph = new int[1000, 1000];
    static void Main()
    {
        var nm = Console.ReadLine().Split();
        n = int.Parse(nm[0]);
        m = int.Parse(nm[1]);
        for (int i = 0; i < m; i++)
        {
            var uv = Console.ReadLine().Split();
            u = int.Parse(uv[0]) - 1;
            v = int.Parse(uv[1]) - 1;
            graph[u, v] = 1;
            graph[v, u] = 1;
        }
        for(int i = 0; i < n; i++)
        {
            if (!check[i])
            {
                cc++;
                DFS(i);
            }
        }
        Console.WriteLine(cc);
    }

    static void DFS(int d)
    {
        check[d] = true;
        for (int i = 0; i < n; i++)
        {
            if(graph[d,i] == 1 && !check[i])
            {
                DFS(i);
            }
        }
    }
}