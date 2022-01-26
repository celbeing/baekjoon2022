using System;
using System.Collections.Generic;
class Program
{
    static int n, k;
    static int[] time = new int[100001];
    static bool[] check = new bool[100001];
    static Queue<int> BFS = new Queue<int>();
    static void Main()
    {
        var nk = Console.ReadLine().Split();
        n = int.Parse(nk[0]);
        k = int.Parse(nk[1]);
        BFS.Enqueue(n);
        time[n] = 0;
        check[n] = true;
        while (BFS.Count > 0)
        {
            if (BFS.Peek() == k)
            {
                Console.WriteLine(time[k]);
                break;
            }
            if (BFS.Peek() > 0)
            {
                if (!check[BFS.Peek() - 1])
                {
                    time[BFS.Peek() - 1] = time[BFS.Peek()] + 1;
                    BFS.Enqueue(BFS.Peek() - 1);
                    check[BFS.Peek() - 1] = true;
                }
            }
            if (BFS.Peek() < 100000)
            {
                if (!check[BFS.Peek() + 1])
                {
                    time[BFS.Peek() + 1] = time[BFS.Peek()] + 1;
                    BFS.Enqueue(BFS.Peek() + 1);
                    check[BFS.Peek() + 1] = true;
                }
            }
            if (BFS.Peek() * 2 <= 100000)
            {
                if (!check[BFS.Peek() * 2])
                {
                    time[BFS.Peek() * 2] = time[BFS.Peek()] + 1;
                    BFS.Enqueue(BFS.Peek() * 2);
                    check[BFS.Peek() * 2] = true;
                }
            }
            BFS.Dequeue();
        }
    }
}