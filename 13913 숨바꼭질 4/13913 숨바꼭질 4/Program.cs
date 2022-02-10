using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
class Program
{
    static int N, K, S;
    static int[] time = Enumerable.Repeat(-1, 100002).ToArray<int>();
    static int[] from = new int[1000001];
    static Queue<int> BFS = new Queue<int>();
    static Stack<int> path = new Stack<int>();
    static StringBuilder Path = new StringBuilder();
    static void Main()
    {
        var nk = Console.ReadLine().Split();
        N = int.Parse(nk[0]); K = int.Parse(nk[1]);
        if (N >= K)  // 거꾸로 가는 케이스 제거
        {
            Console.WriteLine(N == K ? 0 : N - K);
            if (N == K) Console.WriteLine(N);
            else
            {
                for (int i = N; i > K; i--)
                {
                    Console.Write(i + " ");
                }
                Console.Write(K + "\n");
            }
            return;
        }
        else
        {
            BFS.Enqueue(N);
            time[N] = 0;
            while (BFS.Count > 0)
            {
                S = BFS.Dequeue();
                if (S == K) break;
                int[] d = { -1, 1, S };
                for (int i = 0; i < 3; i++)
                {
                    if (S + d[i] < 0 || S + d[i] > K + 1) continue;
                    if (time[S + d[i]] == -1)
                    {
                        BFS.Enqueue(S + d[i]);
                        time[S + d[i]] = time[S] + 1;
                        from[S + d[i]] = S;
                    }
                }
            }
            Console.WriteLine(time[K]);
            S = from[K];
            for (int i = 0; i < time[K]; i++)
            {
                path.Push(S);
                S = from[S];
            }
            while(path.Count > 0)
            {
                Path.Append(path.Pop() + " ");
            }
            Path.Append(K);
            Console.WriteLine(Path);
        }
    }
}