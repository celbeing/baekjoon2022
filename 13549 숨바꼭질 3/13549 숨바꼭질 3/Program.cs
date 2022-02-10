using System;
using System.Linq;
using System.Collections.Generic;
class Program
{
    static int N, K, S;
    static int[] time = Enumerable.Repeat<int>(-1, 200001).ToArray<int>();
    static Queue<int> BFS = new Queue<int>();

    static void Main()
    {
        var nk = Console.ReadLine().Split();
        N = int.Parse(nk[0]); K = int.Parse(nk[1]);
        if(N >= K)  // 거꾸로 가는 케이스 제거
        {
            Console.WriteLine(N == K ? 0 : N - K);
            return;
        }
        BFS.Enqueue(N);
        time[N] = 0;
        while (BFS.Count > 0)
        {
            S = BFS.Dequeue();
            //Console.WriteLine(S);
            if (time[K] != -1 && time[K] < time[S]) break;
            int[] d = { 0, -1, 1 };
            for (int i = 0; i < 3; i++)
            {
                if (S + d[i] < 0 || S + d[i] > K + 2) continue; // 신경 안 써도 되는 케이스 건너뛰기
                if (i == 0 && S != 0) // 순간이동 하는 경우
                {
                    for(int j = 2; S * j < K + 2; j *= 2)
                    {
                        if(time[S * j] == -1 || time[S] < time[S * j])
                        {
                            time[S * j] = time[S];
                            BFS.Enqueue(S * j);
                        }
                    }
                }
                else        // 걸어가는 경우
                {
                    if (time[S + d[i]] == -1 || time[S + d[i]] > time[S] + 1)
                    {       // 처음 왔거나 최단거리인 경우
                        time[S + d[i]] = time[S] + 1;
                        BFS.Enqueue(S + d[i]);
                    }
                }
            }
        }
        Console.WriteLine(time[K]);
    }
}