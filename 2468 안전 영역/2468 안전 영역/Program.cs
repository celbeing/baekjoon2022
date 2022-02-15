using System;
using System.Collections.Generic;

public class Location
{
    private int x, y;
    public int X
    {
        get { return this.x; }
        set { this.x = value; }
    }
    public int Y
    {
        get { return this.y; }
        set { this.y = value; }
    }
    public Location(int x, int y)
    {
        X = x; Y = y;
    }
}
class Program
{
    static int N, count, max, low, high, x, y;
    static int[] dx = { 1, -1, 0, 0 };
    static int[] dy = { 0, 0, 1, -1 };
    static Queue<Location> BFS = new Queue<Location>();
    static void Main()
    {
        N = int.Parse(Console.ReadLine());
        int[,] map = new int[N, N];
        bool[,] check = new bool[N, N];
        max = 1;
        low = 100; high = 1;
        for(int i = 0; i < N; i++)
        {
            var row = Console.ReadLine().Split();
            for (int j = 0; j < N; j++)
            {
                map[i, j] = int.Parse(row[j]);
                high = map[i, j] > high ? map[i, j] : high;
                low = map[i, j] < low ? map[i, j] : low;
                // 탐색 횟수 줄이기
            }
        }
        for(int i = low; i < high; i++)
        {
            count = 0;
            for(int j = 0; j < N; j++)
            {
                for (int k = 0; k < N; k++)
                    check[j, k] = false;
            }
            for(int j = 0; j < N; j++)
            {
                for (int k = 0; k < N; k++)
                {
                    if(map[j,k] > i && !check[j, k])
                    {
                        BFS.Enqueue(new Location(j, k));
                        check[j, k] = true;
                        while(BFS.Count > 0)
                        {
                            for(int l = 0; l < 4; l++)
                            {
                                x = BFS.Peek().X + dx[l];
                                y = BFS.Peek().Y + dy[l];
                                if (x < 0 || y < 0 || x >= N || y >= N || check[x,y]) continue;
                                if (map[x, y] > i)
                                {
                                    BFS.Enqueue(new Location(x, y));
                                    check[x, y] = true;
                                }
                                else check[x, y] = true;
                            }
                            BFS.Dequeue();
                        }
                        count++;
                    }
                }
            }
            max = count > max ? count : max;
        }
        Console.WriteLine(max);
    }
}