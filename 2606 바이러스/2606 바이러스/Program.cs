using System;
using System.Collections.Generic;
class Program
{
    static int computer, node, infected, p, q;
    static int[,] graph = new int[100, 100];
    static bool[] infect = new bool[100];
    static Queue<int> virus = new Queue<int>();
    static void Main()
    {
        computer = int.Parse(Console.ReadLine());
        node = int.Parse(Console.ReadLine());
        for(int i = 0; i < node; i++)
        {
            var pq = Console.ReadLine().Split();
            p = int.Parse(pq[0]) - 1;
            q = int.Parse(pq[1]) - 1;
            graph[p, q] = 1;
            graph[q, p] = 1;
        }
        virus.Enqueue(0);
        infect[0] = true;
        while (virus.Count > 0)
        {
            for(int i = 0; i < computer; i++)
            {
                if(graph[virus.Peek(),i]==1 && !infect[i])
                {
                    virus.Enqueue(i);
                    infect[i] = true;
                }
            }
            virus.Dequeue();
            infected++;
        }
        Console.WriteLine(infected - 1);
    }
}