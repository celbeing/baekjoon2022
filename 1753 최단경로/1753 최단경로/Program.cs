using System;
using System.Collections.Generic;
class Program
{
    static int V, E;
    static Queue<int> BFS = new Queue<int>();
    static void Main()
    {
        var ve = Console.ReadLine().Split();
        V = int.Parse(ve[0]); E = int.Parse(ve[1]);
        BFS.Enqueue(int.Parse(Console.ReadLine()));
        int[,] node = new int[V, V];
    }
}