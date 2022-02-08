using System;
using System.Text;
using System.Collections.Generic;
class Program
{
    static int R, C, N, H, dis, x, y;                   // dis  : 바닥까지 가장 짧은 거리
    static int[,] cave = new int[100, 100];
    static bool turn, hit, ground;                      // trun : false >>> , true <<<
    static bool[,] check = new bool[100, 100];          // hit  : false = pass, true = check
    static Queue<Location> bfs = new Queue<Location>(); // 미네랄 탐색 큐
    static Queue<Location> drop = new Queue<Location>();// 떨어트릴 클러스터 큐
    static StringBuilder map = new StringBuilder();
    static void Main()
    {
        var rc = Console.ReadLine().Split();
        R = int.Parse(rc[0]); C = int.Parse(rc[1]);
        for(int i = 0; i < R; i++)
        {
            var row = Console.ReadLine();
            for(int j = 0; j < C; j++)
            {
                cave[i, j] = row[j] == '.' ? 0 : 1;
            }
        }
        N = int.Parse(Console.ReadLine()); var height = Console.ReadLine().Split();
        for (int i = 0; i < N; i++)
        {
            // 탐색 정보 초기화
            dis = R;
            for (int j = 0; j < R; j++)
            {
                for (int k = 0; k < C; k++)
                {
                    check[j, k] = false;
                }
            }

            // 막대 던지기
            H = R - int.Parse(height[i]);   // 높이는 위에서부터
            int start = turn ? C - 1 : 0, end = turn ? -1 : C, dir = turn ? -1 : 1;
            for(int j = start; j != end; j += dir)
            {
                hit = cave[H, j] == 1 ? true : false;
                if (hit)
                {
                    cave[H, j] = 0;
                    x = H; y = j;
                    break;
                }
            }

            // 미네랄 쪼개졌는지 확인하기
            // 다음 탐색에 큐가 안비워져있으면 탐색할 필요 없음
            // 윗칸 확인
            if (x > 0 && cave[x - 1, y] == 1)
            {
                check[x - 1, y] = true;
                bfs.Enqueue(new Location(x - 1, y));
                Search();
            }
            // 뒤칸 확인
            if (drop.Count == 0 && y + dir > 0 && cave[x, y + dir] == 1 && !check[x, y + dir])
            {
                check[x, y + dir] = true;
                bfs.Enqueue(new Location(x, y + dir));
                Search();
            }
            // 아래칸 확인
            if (drop.Count == 0 && x < R - 1 && cave[x + 1, y] == 1 && !check[x + 1, y])
            {
                check[x + 1, y] = true;
                bfs.Enqueue(new Location(x + 1, y));
                Search();
            }

            // 미네랄 떨구기
            while (drop.Count > 0)
            {
                x = drop.Peek().x; y = drop.Peek().y;
                int measure = 0;
                for (int j = x; j < R - 1; j++)
                {
                    if (cave[j + 1, y] == 0 ^ check[j + 1, y]) measure++;
                    else break;
                }
                dis = dis > measure ? measure : dis;
                bfs.Enqueue(drop.Dequeue());
            }
            while(bfs.Count > 0)
            {
                x = bfs.Peek().x; y = bfs.Peek().y;
                cave[x + dis, y]++;
                cave[x, y]--;
                bfs.Dequeue();
            }
            // 반복
            turn = !turn;
            
        }
        // 동굴 모양 출력
        for (int i = 0; i < R - 1; i++)
        {
            for (int j = 0; j < C; j++)
            {
                map.Append(cave[i, j] == 0 ? '.' : 'x');
            }
            Console.WriteLine(map);
            map.Clear();
        }
        for (int i = 0; i < C; i++)
            map.Append(cave[R - 1, i] == 0 ? '.' : 'x');
        Console.Write(map);
    }
    static void Search()    // 탐색
    // 맞은 부분의 위, 뒤, 아래 칸 확인
    // 확인할 때 바닥이 확인되면 ground = true
    {
        int a, b;
        ground = false;
        while (bfs.Count > 0)
        {
            a = bfs.Peek().x; b = bfs.Peek().y;
            // 바닥에 닿은 경우
            if (a == R - 1) ground = true;

            // 상하좌우 확인
            if(a > 0 && cave[a - 1, b] == 1 && !check[a - 1, b])
            {bfs.Enqueue(new Location(a - 1, b)); check[a - 1, b] = true;}
            if (b > 0 && cave[a, b - 1] == 1 && !check[a, b - 1])
            { bfs.Enqueue(new Location(a, b - 1)); check[a, b - 1] = true; }

            if (a < R - 1 && cave[a + 1, b] == 1 && !check[a + 1, b])
            { bfs.Enqueue(new Location(a + 1, b)); check[a + 1, b] = true; }
            if (b < C - 1 && cave[a, b + 1] == 1 && !check[a, b + 1])
            { bfs.Enqueue(new Location(a, b + 1)); check[a, b + 1] = true; }

            drop.Enqueue(bfs.Dequeue());
        }
        if (ground)
        {
            bfs.Clear();
            drop.Clear();
        }
    }
}
public class Location
{
    public int x;
    public int y;
    public Location(int a, int b)
    {
        x = a;
        y = b;
    }
}