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
    static bool seperate, border;
    // static bool startpoint;
    static int[] dx = { 1, -1, 0, 0 };
    static int[] dy = { 0, 0, 1, -1 };
    static int[,] map;
    static bool[,] check;
    static Queue<Location> sea_now = new Queue<Location>();
    static Queue<Location> sea_next = new Queue<Location>();
    static Queue<Location> ice = new Queue<Location>();

    static void Main()
    {
        // 지도 만들기
        var nm = Console.ReadLine().Split();
        N = int.Parse(nm[0]); M = int.Parse(nm[1]);
        map = new int[N, M];
        check = new bool[N, M];
        for (int i = 0; i < N; i++)
        {
            var row = Console.ReadLine().Split();
            for (int j = 0; j < M; j++)
            {
                map[i, j] = int.Parse(row[j]);
                if (map[i, j] > 0)
                    area++;
                else sea_now.Enqueue(new Location(i, j));
            }
        }

        while (ice.Count > 0)
        {
            // 빙산과 인접한 좌표만 바다 큐에 다시 삽입
            for (int i = 0; i < 4; i++)
            {
                x = sea_now.Peek().X + dx[i]; y = sea_now.Peek().Y + dy[i];
                if (x < 0 || y < 0 || x >= N || y >= M) continue;
                if (map[x, y] > 0) sea_next.Enqueue(new Location(sea_now.Peek().X, sea_now.Peek().Y));

            }
            check[sea_now.Peek().X, sea_now.Peek().Y] = true;
            sea_now.Dequeue();
        }
        // 빙산을 녹인다.
        // 바다가 새로 생겼는지 확인하고
        // 생겼다면 바다 큐를 수정한다.
        // 반복
        // 빙산 탐색은 바다 큐에서 하나만 상하좌우 확인하고 시작하면 됨

        while (!seperate)
        {
            
            while (sea_next.Count > 0) sea_now.Enqueue(sea_next.Dequeue());
            while (sea_now.Count > 0)
            {
                // 빙산 녹이기
                for (int i = 0; i < 4; i++)
                {
                    x = sea_now.Peek().X + dx[i]; y = sea_now.Peek().Y + dy[i];
                    if (x < 0 || y < 0 || x >= N || y >= M || check[x, y]) continue;
                    if (map[x, y] > 0)
                        if (--map[x, y] == 0) area--;
                }
                
            }
            // 다음 빙산 확인하기

        }
    }

        /*
        static void IceMelt()   // 빙산 녹이기
        {
            while(sea.Count > 0)
            {
                for(int i = 0; i < 4; i++)
                {
                    x = sea.Peek().X + dx[i]; y = sea.Peek().Y + dy[i];
                    if (x < 0 || y < 0 || x >= N || y >= M) continue;
                    if(map[x,y] > 0)
                        if (--map[x, y] == 0) area--;
                    // sea에 인접한 ice 있으면 일단 1깎고
                    // 0이 되었으면 area 줄이기
                }
                sea.Dequeue();
            }
        }
        static int IceBFS(Location start) // ice 칸수를 return
        {
            if(start.X + start.Y < 0)   // 진입점이 없다면 찾기
            {
                for(int i = 0; i < N; i++)
                {
                    if (start.X + start.Y > 0) break;
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
            if (start.X + start.Y < 0) return 0;
            int areacount = 0;
            for(int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                    check[i, j] = false;
            }
            ice.Enqueue(start);
            areacount++;
            check[start.X, start.Y] = true;
            while (ice.Count > 0)
            {
                for (int k = 0; k < 4; k++)
                {
                    x = start.X + dx[k]; y = start.Y + dy[k];
                    if (x < 0 || y < 0 || x >= N || y >= M || check[x, y]) continue;
                    if (map[x, y] > 0)
                    {
                        ice.Enqueue(new Location(x, y));
                        check[x, y] = true;
                        areacount++;
                    }
                    else
                    {
                        sea.Enqueue(new Location(x, y));
                        check[x, y] = true;
                    }
                }
                ice.Dequeue();
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
            area = IceBFS(start);
            while (true)
            {
                IceMelt();
                year++;
                if (area > IceBFS(new Location(-1,-1)) || area == 0) break;
            }
            Console.WriteLine(area == 0 ? 0 : year);

            // 바다에서 탐색 시작
            // 빙하에 닿는 부분만 sea큐에 저장
            // 빙하 녹이기 한번 실행하고 glacier큐 탐색
            // 빙하가 사라졌다면 sea 탐색 다시하고 큐 수정, area 수정
            // 만약 탐색 끝났는데 area 수보다 탐색구역 수가 적다면 year 출력
            // 만약 area가 0이 되었다면 area 출력
        }
        */
    }