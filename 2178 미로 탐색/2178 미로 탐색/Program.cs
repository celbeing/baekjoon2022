using System;
class Program
{
    static int n, m;
    static int result = 10000;
    static int[,] maze = new int[100, 100];
    static bool finished = false;
    static bool[,] check = new bool[100, 100];
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
        DFS(0, 0, 0);
        Console.WriteLine(result);
    }

    static void DFS(int x, int y, int move)
    {
        Console.WriteLine(x + " " + y + " " + move);
        check[x, y] = true;
        if (x == n - 1 && y == m - 1)
        {
            result = Math.Min(move + 1, result);
            check[n - 1, m - 1] = false;
        }
        if (y < m) if (maze[x, y + 1] == 1 && !check[x, y + 1]) DFS(x, y + 1, move + 1);
        if (x < n) if (maze[x + 1, y] == 1 && !check[x + 1, y]) DFS(x + 1, y, move + 1);
        if (y > 0) if (maze[x, y - 1] == 1 && !check[x, y - 1]) DFS(x, y - 1, move + 1);
        if (x > 0) if (maze[x - 1, y] == 1 && !check[x - 1, y]) DFS(x - 1, y, move + 1);
        return;
    }
}