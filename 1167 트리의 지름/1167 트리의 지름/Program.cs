using System;
using System.Collections.Generic;
class Program
{
    static int N;
    static List<List<List<int>>> tree = new List<List<List<int>>>();
    // tree<vertex<node,distance>>>
    static void Main()
    {
        N = int.Parse(Console.ReadLine());
        for(int i = 0; i < N; i++)
        {
            var node = Console.ReadLine().Split();
            for(int j = 1; node[j] != "-1"; j += 2)
            {
                tree.Add(new List<List<int>> { });
                tree[i].Add(new List<int> { int.Parse(node[j]), int.Parse(node[j + 1])});
            }
        }
    }
}