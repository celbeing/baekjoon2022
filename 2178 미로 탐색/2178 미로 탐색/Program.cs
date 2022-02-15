using System;
using System.Collections.Generic;

public class Location
{
    private int x, y;
    public Location(int a, int b)
    {
        X = a;
        Y = b;
    }
    public int X
    {
        get { return this.x; }
        set { x = value; }
    }
    public int Y
    {
        get { return this.y; }
        set { y = value; }
    }
}
class Program
{
    static int N, M, x, y;
    static int[] dx = { 0, 1, 0, -1 };
    static int[] dy = { 1, 0, -1, 0 };
    static int[,] map = new int[100, 100];
    static bool[,] check = new bool[100, 100];
    static Queue<Location> BFS = new Queue<Location>();
    static void Main()
    {
        var nm = Console.ReadLine().Split();
        N = int.Parse(nm[0]); M = int.Parse(nm[1]);
        for(int i = 0; i < N; i++)
        {
            var row = Console.ReadLine();
            for (int j = 0; j < M; j++)
                map[i, j] = row[j] == '0' ? 0 : 1;
        }

        BFS.Enqueue(new Location(0, 0));
        check[0, 0] = true;
        while(BFS.Count > 0)
        {
            x = BFS.Peek().X; y = BFS.Peek().Y;
            BFS.Dequeue();
            if (x == N - 1 && y == M - 1) break;
            for (int i = 0; i < 4; i++)
            {
                if (x + dx[i] < 0 || y + dy[i] < 0 || x + dx[i] > N - 1 || y + dy[i] > M - 1) continue;
                if (map[x + dx[i], y + dy[i]] > 0 && !check[x + dx[i], y + dy[i]])
                {
                    BFS.Enqueue(new Location(x + dx[i], y + dy[i]));
                    check[x + dx[i], y + dy[i]] = true;
                    map[x + dx[i], y + dy[i]] += map[x, y];
                }
            }
        }
        Console.WriteLine(map[N - 1, M - 1]);
    }
}