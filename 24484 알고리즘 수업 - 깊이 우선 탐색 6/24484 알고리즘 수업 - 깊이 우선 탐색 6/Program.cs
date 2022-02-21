using System;
using System.Text;
using System.Collections.Generic;

public class GraphNode<T>
{
    private List<int> _connected;
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
    public void AddEdge(int from, int to)
    {
        _node[from].Connected.Add(to);
        _node[to].Connected.Add(from);
    }
    public List<GraphNode<T>> Node
    {
        get { return _node; }
    }
}
class Program
{
    static int N, M, R, count, depth, res;
    static int[] dt;
    static bool[] check;
    static Graph<int> graph = new Graph<int>();
    static void Main()
    {
        var nmr = Console.ReadLine().Split();
        N = int.Parse(nmr[0]); M = int.Parse(nmr[1]); R = int.Parse(nmr[2]);
        dt = new int[N]; check = new bool[N];
        for (int i = 0; i < N; i++)
            graph.AddNode(i);
        for (int i = 0; i < M; i++)
        {
            var edge = Console.ReadLine().Split();
            graph.AddEdge(int.Parse(edge[0]) - 1, int.Parse(edge[1]) - 1);
        }
        for (int i = 0; i < N; i++)
            graph.Node[i].Connected.Sort();

        DFS(R - 1);
        for (int i = 0; i < N; i++)
            res += dt[i];
        Console.WriteLine(res);
    }
    static void DFS(int node)
    {
        count++;
        dt[node] = count * depth; depth++;
        check[node] = true;
        for (int i = graph.Node[node].Connected.Count - 1; i >= 0 ; i--)
        {
            if (check[graph.Node[node].Connected[i]]) continue;
            DFS(graph.Node[node].Connected[i]);
        }
        depth--;
    }
}