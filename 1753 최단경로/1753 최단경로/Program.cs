using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public class GraphNode<T>
{
    private List<int> _connected;
    private List<int> _weigth;
    public T Data { get; set; }
    public GraphNode(T value)
    {
        this.Data = value;
    }
    public List<int> Connected
    {
        get
        {
            if (_connected == null)
                _connected = new List<int>();
            return _connected;
        }
    }
    public List<int> Weight
    {
        get
        {
            if (_weigth == null)
                _weigth = new List<int>();
            return _weigth;
        }
    }
}
public class Graph<T>
{
    private List<GraphNode<T>> _node;
    public Graph()
    {
        _node = new List<GraphNode<T>>();
    }
    public GraphNode<T> AddNode(T data)
    {
        GraphNode<T> n = new GraphNode<T>(data);
        _node.Add(n);
        return n;
    }
    public void AddEdge(int from, int to, int weight = 0)
    {
        _node[from].Connected.Add(to);
        _node[from].Weight.Add(weight);
    }
    public List<GraphNode<T>> Node
    {
        get { return _node; }
    }
}
class Program
{
    static int V, E, K, from, to, weight;
    static int[] cost;
    static Queue<int> dist = new Queue<int>();
    static Graph<int> graph = new Graph<int>();
    static StringBuilder res = new StringBuilder();
    static StreamReader sr = new StreamReader(Console.OpenStandardInput());
    static void Main()
    {
        var ve = sr.ReadLine().Split().Select(int.Parse).ToArray();
        V = ve[0]; E = ve[1];
        K = int.Parse(sr.ReadLine()) - 1;
        cost = Enumerable.Repeat(int.MaxValue, V).ToArray<int>();
        for (int i = 0; i < V; i++)
            // graph.AddNode(i);
        for (int i = 0; i < E; i++)
        {
            var inf = sr.ReadLine().Split().Select(int.Parse).ToArray();
            from = inf[0] - 1; to = inf[1] - 1; weight = inf[2];
            // graph.AddEdge(from, to, weight);
        }
        cost[K] = 0;
        // Dijkstra(K);
        foreach(int path in cost)
        {
            if (path == int.MaxValue) res.Append("INF\n");
            else res.Append(path.ToString() + "\n");
        }
        Console.WriteLine(res);
    }
    /*
    static void Dijkstra(int node)
    {
        dist.Enqueue(node);
        while (dist.Count > 0)
        {
            node = dist.Dequeue();
            for (int i = 0; i < graph.Node[node].Connected.Count; i++)
            {
                if (cost[graph.Node[node].Connected[i]] > cost[node] + graph.Node[node].Weight[i])
                {
                    cost[graph.Node[node].Connected[i]] = cost[node] + graph.Node[node].Weight[i];
                    dist.Enqueue(graph.Node[node].Connected[i]);
                }
            }
        }
    }
    */
}