using System;
using System.Collections.Generic;
public class Location
{
    public int x, y;
    public Location(int a, int b)
    {
        x = a; y = b;
    }
}
class Program
{
    static int w, h, island, x, y;
    static int[,] map = new int[50, 50];
    static bool[,] check = new bool[50, 50];
    static Queue<Location> BFS = new Queue<Location>();
    static void Main()
    {
        int[] dx = { 1, 0, -1, 0, 1, 1, -1, -1 };
        int[] dy = { 0, 1, 0, -1, 1, -1, 1, -1 };
        while (true)
        {
            var wh = Console.ReadLine().Split();
            w = int.Parse(wh[0]); h = int.Parse(wh[1]);
            if (w + h == 0) break;
            island = 0;
            for (int i = 0; i < h; i++)
            {
                var row = Console.ReadLine().Split();
                for (int j = 0; j < w; j++)
                {
                    map[i, j] = int.Parse(row[j]);
                    check[i, j] = false;
                }
            }
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (map[i, j] == 1 && !check[i, j]) // 땅 발견 탐색 시작
                    {
                        BFS.Enqueue(new Location(i, j));
                        check[i, j] = true;
                        while (BFS.Count > 0)
                        {
                            x = BFS.Peek().x; y = BFS.Peek().y;
                            for (int k = 0; k < 8; k++)
                            {
                                if (x + dx[k] < 0 || y + dy[k] < 0 || x + dx[k] > h - 1 || y + dy[k] > w - 1) continue;
                                if (!check[x + dx[k], y + dy[k]] && map[x + dx[k], y + dy[k]] == 1)
                                {
                                    BFS.Enqueue(new Location(x + dx[k], y + dy[k]));
                                    check[x + dx[k], y + dy[k]] = true;
                                }
                            }
                            BFS.Dequeue();
                        }
                        island++;
                    }
                }
            }
            Console.WriteLine(island);
        }
    }
}