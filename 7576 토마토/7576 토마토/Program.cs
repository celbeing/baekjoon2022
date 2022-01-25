using System;
using System.Collections.Generic;
class Program
{
    static int m, n, X, Y, result;
    static Queue<int> x = new Queue<int>();
    static Queue<int> y = new Queue<int>();
    static void Main()
    {
        var mn = Console.ReadLine().Split();
        m = int.Parse(mn[0]);
        n = int.Parse(mn[1]);
        int[,] cage = new int[n, m];
        int[,] days = new int[n, m];
        bool[,] check = new bool[n, m];
        for (int i = 0; i < n; i++)
        {
            var row = Console.ReadLine().Split();
            for (int j = 0; j < m; j++)
            {
                cage[i, j] = int.Parse(row[j]);
                days[i, j] = n * m;
            }
        }
        for(int i = 0; i < n; i++)
        {
            for(int j = 0; j < m; j++)
            {
                if(cage[i,j] == 1 && !check[i, j])
                {
                    check[i, j] = true;
                    days[i, j] = 0;
                    x.Enqueue(i); y.Enqueue(j);
                }
            }
        }
        while (x.Count > 0)
        {
            X = x.Peek();
            Y = y.Peek();
            check[X, Y] = true;
            if(X > 0)
            {
                if(cage[X - 1, Y] == 0)
                {
                    if(days[X, Y] + 1 < days[X - 1, Y])
                    {
                        days[X - 1, Y] = days[X, Y] + 1;
                        x.Enqueue(X - 1); y.Enqueue(Y);
                    }
                }
            }
            if (Y > 0)
            {
                if (cage[X, Y - 1] == 0)
                {
                    if (days[X, Y] + 1 < days[X, Y - 1])
                    {
                        days[X, Y - 1] = days[X, Y] + 1;
                        x.Enqueue(X); y.Enqueue(Y - 1);
                    }
                }
            }
            if (X < n - 1)
            {
                if (cage[X + 1, Y] == 0)
                {
                    if (days[X, Y] + 1 < days[X + 1, Y])
                    {
                        days[X + 1, Y] = days[X, Y] + 1;
                        x.Enqueue(X + 1); y.Enqueue(Y);
                    }
                }
            }
            if (Y < m - 1)
            {
                if (cage[X, Y + 1] == 0)
                {
                    if (days[X, Y] + 1 < days[X, Y + 1])
                    {
                        days[X, Y + 1] = days[X, Y] + 1;
                        x.Enqueue(X); y.Enqueue(Y + 1);
                    }
                }
            }
            x.Dequeue(); y.Dequeue();
        }
        for(int i = 0; i < n; i++)
        {
            for(int j = 0; j < m; j++)
            {
                if (cage[i, j] == -1) continue;
                if(cage[i,j] == 0 && !check[i,j])
                {
                    Console.WriteLine(-1);
                    return;
                }
                result = result < days[i, j] ? days[i, j] : result;
            }
        }
        Console.WriteLine(result);
    }
}