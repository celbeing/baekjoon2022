using System;
using System.Collections.Generic;
class Program
{
    static int N, E, R, L;
    static List<List<int>> node = new List<List<int>>();
    static Queue<int> bfs = new Queue<int>();
    static void Main()
    {
        N = int.Parse(Console.ReadLine());
        var tree = Console.ReadLine().Split();
        E = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
            node.Add(new List<int> { });
        for (int i = 0; i < N; i++)
        {
            if (i == E) continue;
            if (int.Parse(tree[i]) == -1) R = i;
            else node[int.Parse(tree[i])].Add(i);
        }
        bfs.Enqueue(R);
        while (bfs.Count > 0)
        {
            if(bfs.Peek() == E) { bfs.Dequeue(); continue; }
            if (node[bfs.Peek()].Count == 0) L++;
            foreach(int v in node[bfs.Dequeue()])
                bfs.Enqueue(v);
        }
        Console.WriteLine(L);
    }
}