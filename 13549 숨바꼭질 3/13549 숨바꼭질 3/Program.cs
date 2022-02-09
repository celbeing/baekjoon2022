using System;
using System.Linq;
using System.Collections.Generic;
class Program
{
    static int N, K, s;
    static int[] time = Enumerable.Repeat<int>(100000, 200001).ToArray<int>();
    static bool[] check = new bool[200001];
    static Queue<int> BFS = new Queue<int>();
    static void Main()
    {
        var nk = Console.ReadLine().Split();
        N = int.Parse(nk[0]); K = int.Parse(nk[1]);
        BFS.Enqueue(N);
        time[N] = 0;
        check[N] = true;
        while (BFS.Count > 0)
        {
            s = BFS.Peek();
            if (s == K) break;
            Search(s);
            BFS.Dequeue();
        }
        Console.WriteLine(time[K]);
    }
    static void Search(int s)
    {
        int[] ds = {s, 1, -1};
        for(int i = 0; i < 3; i++)
        {
            if (s + ds[i] < 0 || s + ds[i] > K * 2) continue;
            if (!check[s + ds[i]])
            {
                check[s + ds[i]] = true;
                if (i == 0)
                {
                    time[s + ds[i]] = time[s];
                    Search(s + ds[i]);
                }
                else
                {
                    time[s + ds[i]] = time[s] + 1;
                    BFS.Enqueue(s + ds[i]);
                }
            }
        }
    }
}