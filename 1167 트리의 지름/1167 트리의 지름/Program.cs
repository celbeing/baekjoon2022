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
        Tracking(0,-1);
        Console.WriteLine(Max);
    }
    static void Tracking(int node, int par)
    {
        if (tree[node].Count == 0)
        {
            weight[node] = 0;
            return;
        }
        foreach (var edge in tree[node])
        {
            if (edge[0] == par) continue;
            Tracking(edge[0], node);
        }
        int max = 0;
        foreach (var edge in tree[node])
        {
            if (edge[0] == par) continue;
            max = max > weight[edge[0]] + edge[1] ? max : weight[edge[0]] + edge[1];
        }
        weight[node] = max;
        if(tree[node].Count == 1) Max = Max > max ? Max : max;
        else
        {
            int[] w = new int[tree[node].Count];
            for(int i = 0; i < w.Length; i++)
            {
                w[i] = weight[tree[node][i][0]] + tree[node][i][1];
            }
            Array.Sort(w);
            Max = Max > w[0] + w[1] ? Max : w[0] + w[1];
        }
    }
}