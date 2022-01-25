using System;
using System.Collections.Generic;
class Program
{
    static int n, m, x, y;
    static int[,] move = new int[100, 100];
    static int[,] maze = new int[100, 100];
    static bool[,] check = new bool[100, 100];
    static Queue<int> BFS = new Queue<int>();
    static void Main()
    {
        var nm = Console.ReadLine().Split();
        n = int.Parse(nm[0]);
        m = int.Parse(nm[1]);
        for (int i = 0; i < n; i++)
        {
            var row = Console.ReadLine();
            for (int j = 0; j < m; j++)
            {
                maze[i, j] = row[j] == '0' ? 0 : 1;
            }
        }
        BFS.Enqueue(0);
        while (BFS.Count > 0)
        {
            x = BFS.Peek() / 100; y = BFS.Peek() % 100;
            check[x, y] = true;
            if (y < m) if (maze[x, y + 1] == 1 && !check[x, y + 1])
                {
                    move[x, y + 1] = move[x, y] + 1;
                    BFS.Enqueue((x * 100) + y + 1);
                }
            if (x < n) if (maze[x + 1, y] == 1 && !check[x + 1, y])
                {
                    move[x + 1, y] = move[x, y] + 1;
                    BFS.Enqueue((x * 100) + y + 100);
                }
            if (y > 0) if (maze[x, y - 1] == 1 && !check[x, y - 1])
                {
                    move[x, y - 1] = move[x, y] + 1;
                    BFS.Enqueue((x * 100) + y - 1);
                }
            if (x > 0) if (maze[x - 1, y] == 1 && !check[x - 1, y])
                {
                    move[x - 1, y] = move[x, y] + 1;
                    BFS.Enqueue((x * 100) + y - 100);
                }
            if (BFS.Dequeue() == (n * 100) + m)
            {
                break;
            }
        }
        Console.WriteLine(move[n - 1, m - 1] + 1);
    }
}