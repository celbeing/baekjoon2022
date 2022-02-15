using System;
using System.Collections.Generic;
public class Location
{
    private int x, y, z;
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
    public int Z
    {
        get { return this.z; }
        set { this.z = value; }
    }
    public Location(int n, int m, int h)
    {
        X = n; Y = m; Z = h;
    }
}
class Program
{
    static int N, M, H, x, y, z, x2, y2, z2, day;
    static int[] dx = { 1, -1, 0, 0, 0, 0 };
    static int[] dy = { 0, 0, 1, -1, 0, 0 };
    static int[] dz = { 0, 0, 0, 0, 1, -1 };
    static Queue<Location> BFS = new Queue<Location>();
    static void Main()
    {
        var size = Console.ReadLine().Split();
        M = int.Parse(size[0]); N = int.Parse(size[1]); H = int.Parse(size[2]);
        int[,,] tomato = new int[N, M, H];
        // 확인 안한 토마토 없는 = -1, 안익은 = 0, 익은 = 1
        // 확인 한   토마토 없는 = -1, 익은 = 이전칸 + 1
        for(int i = 0; i < H; i++)
        {
            for(int j = 0; j < N; j++)
            {
                var row = Console.ReadLine().Split();
                for (int k = 0; k < M; k++)
                {
                    switch (int.Parse(row[k])) {
                        case 0:
                            tomato[j, k, i] = 0;
                            break;
                        case 1:
                            tomato[j, k, i] = 1;
                            BFS.Enqueue(new Location(j, k, i));
                            break;
                        case -1:
                            tomato[j, k, i] = -1;
                            break;
                        }
                }
            }
        }
        while (BFS.Count > 0)
        {
            x = BFS.Peek().X; y = BFS.Peek().Y; z = BFS.Dequeue().Z;
            day += tomato[x, y, z] > day ? 1 : 0;
            for(int i = 0; i < 6; i++)
            {
                x2 = x + dx[i]; y2 = y + dy[i]; z2 = z + dz[i];
                if (x2 < 0 || y2 < 0 || z2 < 0 || x2 > N - 1 || y2 > M - 1 || z2 > H - 1) continue;
                if (tomato[x2, y2, z2] == 0)
                { tomato[x2, y2, z2] = tomato[x, y, z] + 1; BFS.Enqueue(new Location(x2, y2, z2)); }
            }
        }
        for (int i = 0; i < H; i++)
        {
            for (int j = 0; j < N; j++)
            {
                for (int k = 0; k < M; k++)
                {
                    if (tomato[j, k, i] == 0)
                    {
                        Console.WriteLine(-1);
                        return;
                    }
                    else day = day < tomato[j, k, i] ? tomato[j, k, i] : day;
                }
            }
        }
        Console.WriteLine(day - 1);
    }
}