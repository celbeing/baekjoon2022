using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
public class Path
{
    public StringBuilder sb = new StringBuilder();
    public Path(StringBuilder S, int n)
    {
        sb.Append(S + " " + n);
    }
    public Path(int n)
    {
        if (sb.Length == 0) sb.Append(n);
        else sb.Append(" " + n);
    }
    public Path()
    {
        this.sb.Clear();
    }
}
class Program
{
    static int N, K, S;
    static int[] time = Enumerable.Repeat(-1, 100002).ToArray<int>();
    static Queue<int> BFS = new Queue<int>();
    static List<Path> path = new List<Path>();
    static void Main()
    {
        var nk = Console.ReadLine().Split();
        N = int.Parse(nk[0]); K = int.Parse(nk[1]);
        for (int i = 0; i <= 100001; i++)
            path.Add(new Path());
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
            path[N].sb.Append(N);
            while (BFS.Count > 0)
            {
                S = BFS.Dequeue();
                if (S == K) break;
                int[] d = { -1, 1, S };                             // -1, +1, *2
                for (int i = 0; i < 3; i++)
                {
                    if (S + d[i] < 0 || S + d[i] > K + 1) continue;
                    if (time[S + d[i]] == -1)
                    {
                        BFS.Enqueue(S + d[i]);
                        time[S + d[i]] = time[S] + 1;
                        path[S + d[i]] = new Path(path[S].sb, S + d[i]);
                    }
                }
            }
            Console.WriteLine(time[K]);
            Console.WriteLine(path[K].sb);
        }
    }
}