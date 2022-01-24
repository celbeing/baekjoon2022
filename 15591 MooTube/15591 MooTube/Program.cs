using System;
using System.Text;
using System.Collections.Generic;

class Program
{
    static int N, Q, p, q, r, k, v, recommend;
    static StringBuilder result = new StringBuilder();
    static Queue<int> bfs = new Queue<int>();
    static int[,] tube = new int[5000, 5000];
    static bool[] done = new bool[5000];
    static void Main()
    {
        var nq = Console.ReadLine().Split();
        N = int.Parse(nq[0]);
        Q = int.Parse(nq[1]);
        for (int i = 1; i < N; i++)
        {
            var pqr = Console.ReadLine().Split();
            p = int.Parse(pqr[0]);
            q = int.Parse(pqr[1]);
            r = int.Parse(pqr[2]);
            tube[p - 1, q - 1] = r;
            tube[q - 1, p - 1] = r;
        }
        for (int i = 0; i < Q; i++)
        {
            for (int j = 0; j < N; j++) done[j] = false;
            recommend = 0;
            bfs.Clear();
            var kv = Console.ReadLine().Split();
            k = int.Parse(kv[0]);
            v = int.Parse(kv[1]);
            bfs.Enqueue(v - 1);
            while (bfs.Count > 0)
            {
                done[bfs.Peek()] = true;
                for (int j = 0; j < N; j++)
                {
                    if (tube[bfs.Peek(), j] >= k && !done[j])
                    {
                        bfs.Enqueue(j);
                        recommend++;
                    }
                }
                bfs.Dequeue();
            }
            result.AppendLine(recommend.ToString());
        }
        Console.WriteLine(result);
    }
}