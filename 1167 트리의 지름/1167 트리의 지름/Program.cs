using System;
using System.Collections.Generic;
class Program
{
    static int N, Max;
    static int[] weight;
    static List<List<List<int>>> tree = new List<List<List<int>>>();
    // tree<vertex<node,distance>>>
    static void Main()
    {
        N = int.Parse(Console.ReadLine());
        weight = new int[N];
        Max = 0;
        for(int i = 0; i < N; i++)
        {
            var node = Console.ReadLine().Split();
            for(int j = 1; node[j] != "-1"; j += 2)
            {
                tree.Add(new List<List<int>> { });
                tree[i].Add(new List<int> { int.Parse(node[j]) - 1, int.Parse(node[j + 1])});
            }
        }
        Tracking(0);
        Console.WriteLine(Max);
    }
    static void Tracking(int node)
    {
        foreach(var edge in tree[node])
        {
            
        }
    }
}