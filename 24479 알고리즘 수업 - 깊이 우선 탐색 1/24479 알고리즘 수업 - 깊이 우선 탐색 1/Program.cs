using System;
class Program
{
    static int N, M, R;
    static bool[] check;
    static void Main()
    {
        var nmr = Console.ReadLine().Split();
        N = int.Parse(nmr[0]); M = int.Parse(nmr[1]); R = int.Parse(nmr[2]);
        check = new bool[N];
        for(int i = 0; i < M; i++)
        {
            var edge = Console.ReadLine().Split();
            // 그래프를 어떻게 저장하지?
            // 검색은? 행렬로 하면 320GB짜리
            // 작동하지 않는 모던워페어 1.5개
        }
    }
    static void DFS(int vertex)
    {
        check[vertex] = true;
    }
}