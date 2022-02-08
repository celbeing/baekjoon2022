using System;
using System.Collections.Generic;
class Program
{
    static int R, C, N, H, distance, x, y, mineral;     // distance : 클러스터와 바닥 사이 가장 짧은 거리
    static int[,] cave = new int[100, 100];
    static bool turn, hit;                              // false >>> , true <<<    // false : pass, hit : check
    static byte[,] check = new byte[100, 100];          // 탐색한 곳인지 확인
    static Queue<Location> bfs = new Queue<Location>(); // 미네랄 탐색 큐
    static Queue<Location> drop = new Queue<Location>();// 떨어트릴 클러스터 큐
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
            // 막대 던지기
            H = R - int.Parse(height[i]);                   // 높이는 위에서부터 재는 걸로
            if (turn)
            {
                for(int j = C - 1; j >= 0; j--)
                {
                    hit = cave[H, j] == 1 ? true : false;
                    if (hit)                                // 맞은 부분의 위, 뒤, 아래 칸 확인
                    {                                       // 확인할 때 바닥이 확인되면 바로 큐 비워버리기
                        cave[H, j] = 0;                     // 다음 탐색에 큐가 안비워져있으면 탐색할 필요 없음
                        if (H > 0 && cave[H - 1, j] == 1)   // 맞은 부분 위쪽칸부터 확인
                        {
                            check[H - 1, j] = 1;
                            bfs.Enqueue(new Location(H - 1, j));
                        }
                        else if ()
                    }
                }
            }

            // 미네랄 쪼개졌는지 확인하기
            // 미네랄 떨구기
            // 반복
        }
        // 동굴 모양 출력
    }
    static void Search()
    {
        while (bfs.Count > 0)
        {
            x = bfs.Peek().x; y = bfs.Peek().y;
            x = R - 1; bfs.Clear(); drop.Clear();
            if(x > 0 && cave[x - 1, y] == 1)
            {

            }
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