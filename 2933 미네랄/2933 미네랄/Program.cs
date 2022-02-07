using System;
using System.Collections.Generic;
class Program
{
    static int R, C, N, H, distance, x, y, mineral;     // distance : 클러스터와 바닥 사이 가장 짧은 거리
    static bool turn;                                   // false >>> , true <<<
    static byte[,] check = new byte[100, 100];          // 탐색한 곳인지 확인
    static Queue<Location> bfs = new Queue<Location>(); // 미네랄 탐색 큐
    static void Main()
    {
        var rc = Console.ReadLine().Split();
        R = int.Parse(rc[0]); C = int.Parse(rc[1]);
        int[,] cave = new int[R, C];
        for(int i = 0; i < R; i++)
        {
            var row = Console.ReadLine();
            for(int j = 0; j < C; j++)
            {
                cave[i, j] = row[j] == '.' ? 0 : 1;
            }
        }
        N = int.Parse(Console.ReadLine()); H = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
        {
            // 막대 던지기
            // 미네랄 쪼개졌는지 확인하기
            // 미네랄 떨구기
            // 반복
        }
        // 동굴 모양 출력
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