using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
public class GraphNode<T>
{
    private List<GraphNode<T>> _linked;
    private List<int> _weight;
    public T data { get; set; }
    public GraphNode() { }
    public GraphNode(T value)
    {
        this.data = value;
    }
    public List<GraphNode<T>> Linked
    {
        get
        {
            _linked = _linked ?? new List<GraphNode<T>>();
            return _linked;
        }
    }
    public List<int> Weight
    {
        get
        {
            _weight = _weight ?? new List<int>();
            return _weight;
        }
    }
}
public class Graph<T>
{
    private List<GraphNode<T>> _nodeList;
    public Graph()
    {
        _nodeList = new List<GraphNode<T>>();
    }
    public GraphNode<T> AddNode(T data)
    {
        GraphNode<T> n = new GraphNode<T>(data);
        _nodeList.Add(n);
        return n;
    }
    public GraphNode<T> AddNode(GraphNode<T> node)
    {
        _nodeList.Add(node);
        return node;
    }
    public void AddEdge(GraphNode<T> from, GraphNode<T> to, int weight = 0, bool oneway = true)
    {
        from.Linked.Add(to);
        from.Weight.Add(weight);
        if (!oneway)
        {
            to.Linked.Add(from);
            to.Weight.Add(weight);
        }
    }
    internal void DebugPrintLinks()
    {
        foreach(GraphNode<T> graphNode in _nodeList)
        {
            foreach(var n in graphNode.Linked)
            {
                string s = graphNode.data + " - " + n.data;
                Console.WriteLine(s);
            }
        }
    }
}
class Program
{
    static void Main()
    {
        Graph<int> g = new Graph<int>();
        var n1 = g.AddNode(10);
        n1 = g.AddNode(60);
        var n2 = g.AddNode(20);
        var n3 = g.AddNode(30);
        var n4 = g.AddNode(40);
        var n5 = g.AddNode(50);

        g.AddEdge(n1, n3, 4);
        g.AddEdge(n2, n4, 1);
        g.AddEdge(n3, n4, 2);
        g.AddEdge(n3, n5, 5);

        g.DebugPrintLinks();
    }
}

/*
class Program
{
    static int V, E, ex,ey, S;
    static int[] dist = Enumerable.Repeat<int>(int.MaxValue, 20000).ToArray<int>();
    static int[,] edge = new int[20000, 20000];
    static bool[] check = new bool[20000];
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
            ex = int.Parse(e[0]) - 1; ey = int.Parse(e[1]) - 1;
            if (edge[ex, ey] == 0) edge[ex, ey] = int.Parse(e[2]);
            else edge[ex, ey] = Math.Min(edge[ex, ey], int.Parse(e[2]));
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
*/