using System;
using System.Collections.Generic;
public class Location
{
    private int x, y;
    public int X
    {
        get { return this.x; }
        set { x = value; }
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
    static int N, M, area, year, x, y;
    static bool startpoint;
    static int[] dx = { 1, -1, 0, 0 };
    static int[] dy = { 0, 0, 1, -1 };
    static int[,] map;
    static bool[,] check;
    static Location start = null;
    static Queue<Location> sea = new Queue<Location>();
    static Queue<Location> glacier = new Queue<Location>();

    static void GlacierMelt()
    {
        while(sea.Count > 0)
        {
            for(int i = 0; i < 4; i++)
            {
                x = sea.Peek().X + dx[i]; y = sea.Peek().Y + dy[i];
                if (x < 0 || y < 0 || x >= N || y >= M) continue;
                if(map[x,y] > 0)
                    if (--map[x, y] == 0) area--;
            }
            sea.Dequeue();
        }
    }
    static int GlacierBFS(Location start = null)
    {
        if(start == null)
        {
            for(int i = 0; i < N; i++)
            {
                if (start != null) break;
                for(int j = 0; j < M; j++)
                {
                    if(map[i,j] > 0)
                    {
                        start.X = i; start.Y = j;
                        break;
                    }
                }
            }
        }
        int areacount = 0;
        for(int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
                check[i, j] = false;
        }
        glacier.Enqueue(start);
        areacount++;
        check[start.X, start.Y] = true;
        while (glacier.Count > 0)
        {
            for (int k = 0; k < 4; k++)
            {
                x = start.X + dx[k]; y = start.Y + dy[k];
                if (x < 0 || y < 0 || x >= N || y >= M || check[x, y]) continue;
                if (map[x, y] > 0)
                {
                    glacier.Enqueue(new Location(x, y));
                    check[x, y] = true;
                    areacount++;
                }
                else
                {
                    sea.Enqueue(new Location(x, y));
                }
            }
        }
        return areacount;
    }
    static void Main()
    {
        // 지도 만들기
        var nm = Console.ReadLine().Split();
        N = int.Parse(nm[0]); M = int.Parse(nm[1]);
        map = new int[N, M];
        check = new bool[N, M];
        for(int i = 0; i < N; i++)
        {
            var row = Console.ReadLine().Split();
            for (int j = 0; j < M; j++)
            {
                map[i, j] = int.Parse(row[j]);
                if (map[i, j] > 0)
                {
                    area++;
                    if (!startpoint)
                    {
                        start = new Location(i, j);
                        startpoint = true;
                        // bfs 시작점 설정
                    }
                }
            }
        }
        //해안선 찾기
        area = GlacierBFS(start);
        while (true)
        {
            GlacierMelt();
            year++;
            if (area > GlacierBFS() || area == 0) break;
        }
        Console.WriteLine(area == 0 ? 0 : year);

        // 바다에서 탐색 시작
        // 빙하에 닿는 부분만 sea큐에 저장
        // 빙하 녹이기 한번 실행하고 glacier큐 탐색
        // 빙하가 사라졌다면 sea 탐색 다시하고 큐 수정, area 수정
        // 만약 탐색 끝났는데 area 수보다 탐색구역 수가 적다면 year 출력
        // 만약 area가 0이 되었다면 area 출력
    }
}