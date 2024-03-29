﻿using System;
using System.Linq;
using System.Collections.Generic;
class Program
{
    static int F, S, G, U, D, now;
    static Queue<int> BFS = new Queue<int>();
    static void Main()
    {
        var fsgud = Console.ReadLine().Split();
        F = int.Parse(fsgud[0]); S = int.Parse(fsgud[1]); G = int.Parse(fsgud[2]);
        U = int.Parse(fsgud[3]); D = int.Parse(fsgud[4]);
        int[] count = Enumerable.Repeat(-1, F).ToArray<int>();
        S--; G--;
        BFS.Enqueue(S);
        count[S] = 0;
        while(BFS.Count > 0)
        {
            now = BFS.Dequeue();
            if(now + U < F && count[now + U] == -1)
            {
                count[now + U] = count[now] + 1;
                BFS.Enqueue(now + U);
            }
            if (now - D > -1 && count[now - D] == -1)
            {
                count[now - D] = count[now] + 1;
                BFS.Enqueue(now - D);
            }
        }
        Console.WriteLine(count[G] == -1 ? "use the stairs" : count[G]);
    }
}