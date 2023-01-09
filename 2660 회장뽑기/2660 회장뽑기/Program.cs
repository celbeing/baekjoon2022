using System;
using System.Collections.Generic;

class Program
{
    static int N, candidate;
    static string[] input = new string[2];
    static Queue<int> bfs = new Queue<int>();
    static Queue<int> bfs2 = new Queue<int>();
    static void Main()
    {
        N = int.Parse(Console.ReadLine());
        int[] score = new int[N];
        bool[] check = new bool[N];
        bool[,] graph = new bool[N, N];
        while (true)
        {
            input = Console.ReadLine().Split();
            if (int.Parse(input[0]) == -1) break;
            graph[int.Parse(input[0]) - 1, int.Parse(input[1]) - 1] = true;
            graph[int.Parse(input[1]) - 1, int.Parse(input[0]) - 1] = true;
        }
        for(int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++) check[j] = false;
            check[i] = true;
            bfs.Enqueue(i);
            while(bfs.Count > 0)
            {
                int t = bfs.Dequeue();
                for(int j = 0; j < N; j++)
                {
                    if(graph[t,j] && !check[j])
                    {
                        check[j] = true;
                        bfs2.Enqueue(j);
                    }
                }
                if(bfs.Count == 0)
                {
                    while (bfs2.Count > 0) bfs.Enqueue(bfs2.Dequeue());
                    score[i]++;
                }
            }
            score[i]--;
        }
        int min = N;
        for(int i = 0; i < N; i++)
            min = Math.Min(score[i], min);
        for(int i = 0; i < N; i++)
        {
            if (score[i] == min)
            {
                candidate++;
                bfs.Enqueue(i + 1);
            }
        }
        Console.WriteLine($"{min} {candidate}");
        while (bfs.Count > 1) Console.Write($"{bfs.Dequeue()} ");
        Console.Write(bfs.Dequeue());
    }
}