using System;
using System.Collections.Generic;
class Program
{
    static int N, M;
    static int[,] map = new int[100, 100];
    static int[,] weight = new int[100, 100];
    static bool[,] check = new bool[100, 100];
    static Queue<Location> BFS = new Queue<Location>();
    static void Main()
    {
        var nm = Console.ReadLine().Split();
        N = int.Parse(nm[1]); M = int.Parse(nm[0]);
        for(int i = 0; i < N; i++)
        {
            string row = Console.ReadLine();
            for (int j = 0; j < M; j++)
            {
                map[i, j] = row[j] == '0' ? 0 : 1;
                weight[i, j] = 10000;
            }
        }

        check[0, 0] = true;
        weight[0, 0] = 0;
        BFS.Enqueue(new Location(0, 0));
        while (BFS.Count > 0)
        {
            int a = BFS.Peek().x;
            int b = BFS.Peek().y;
            Search(a, b);
            BFS.Dequeue();
        }
        Console.WriteLine(weight[N - 1, M - 1]);
    }
    static void DFS(int a, int b)
    {
        Search(a, b);
    }
    static void Search(int a, int b)
    {
        int[] dx = { -1, 0, 1, 0 };
        int[] dy = { 0, -1, 0, 1 };
        int x, y;
        for(int i = 0; i < 4; i++)
        {
            x = a + dx[i]; y = b + dy[i];
            if (x < 0 || y < 0 || x >= N || y >= M) continue;

            if (!check[x, y])
            {
                if(map[x,y] == 0)
                {
                    check[x, y] = true;
                    weight[x, y] = Math.Min(weight[a, b], weight[x, y]);
                    DFS(x, y);
                }
                else
                {
                    check[x, y] = true;
                    weight[x, y] = Math.Min(weight[a, b] + 1, weight[x, y]);
                    BFS.Enqueue(new Location(x, y));
                }
            }
        }
    }
}
public class Location
{
    public int x, y;
    public Location(int a, int b)
    {
        x = a;
        y = b;
    }
}