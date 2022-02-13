using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public class Graph
{
    private int from, to;
    public Graph(int n1, int n2)
    {
        from = n1;
        to = n2;
    }
}
class Program
{
    static int V, E, W, S;
    static int[] dist = Enumerable.Repeat<int>(int.MaxValue, 20000).ToArray<int>();
    static int[,] edge = new int[20000, 20000];
    static bool[] check = new bool[20000];
    static List<Graph> Node = new List<Graph>();
    static List<int> Weight = new List<int>();
    static Queue<int> BFS = new Queue<int>();
    static StringBuilder res = new StringBuilder();
    static void Main()
    {
        var ve = Console.ReadLine().Split();
        V = int.Parse(ve[0]); E = int.Parse(ve[1]);
        BFS.Enqueue(int.Parse(Console.ReadLine()) - 1);
        dist[BFS.Peek()] = 0;
        for (int i = 0; i < E; i++)
        {
            var e = Console.ReadLine().Split();
            Graph edge = new Graph(int.Parse(e[0]) - 1, int.Parse(e[1]) - 1);
            W = int.Parse(e[2]);
            if (Node.Contains(edge))
            {
                List[Node.FindIndex(edge)] = Math.Min(List[Node.FindIndex(edge)], W);
            }
        }
        while(BFS.Count > 0)
        {
            S = BFS.Dequeue();
            for(int i = 0; i < V; i++)
            {
                if (i == S || check[i]) continue;
                if(edge[S, i] != 0)
                {
                    if(dist[i] > dist[S] + edge[S, i])
                    {
                        dist[i] = dist[S] + edge[S, i];
                        BFS.Enqueue(i);
                    }
                }
            }
            check[S] = true;
        }
        for(int i = 0; i < V; i++)
        {
            if (dist[i] == int.MaxValue) Console.WriteLine("INF");
            else Console.WriteLine(dist[i]);
            //res.AppendLine(dist[i] == int.MaxValue ? "INF" : dist[i].ToString());
        }
        //Console.Write(res);
    }
}