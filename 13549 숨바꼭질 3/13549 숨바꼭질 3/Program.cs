using System;
using System.Linq;
using System.Collections.Generic;
class Program
{
    static int N, K, S;
    static bool find = false;
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
            S = BFS.Peek();
            if (find) break;
            Search(S);
            BFS.Dequeue();
        }
        Console.WriteLine(time[K]);
    }
    static void Search(int s)
    {
        find = s == K ? true : find;
        if (find) return;
        Teleport(s);
        Walk(s);
    }
    static void Teleport(int s)
    {
        find = s == K ? true : find;
        check[s] = true;
        if (s * 2 < K * 2 && !check[s * 2])
        {
            time[s * 2] = time[s];
            Search(s * 2);
        }
    }
    static void Walk(int s)
    {
        find = s == K ? true : find;
        check[s] = true;
        int[] ds = { -1, 1 };
        for(int i = 0; i < 2; i++)
        {
            if (s + ds[i] < 0 || s + ds[i] > 100000) continue;
            if(!check[s + ds[i]])
            {
                time[s + ds[i]] = Math.Min(time[s] + 1, time[s + ds[i]]);
                Teleport(s + ds[i]);
                BFS.Enqueue(s + ds[i]);
            }
        }
    }
}