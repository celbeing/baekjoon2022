using System;
using System.Text;
using System.Collections.Generic;
class Program
{
    static int n, building;
    static int[,] block = new int[25, 25];
    static bool[,] check = new bool[25, 25];
    static StringBuilder result = new StringBuilder();
    static List<int> complex = new List<int>();
    static void Main()
    {
        n = int.Parse(Console.ReadLine());
        for(int i = 0; i < n; i++)
        {
            string str = Console.ReadLine();
            for (int j = 0; j < n; j++)
            {
                block[i, j] = str[j] == '0' ? 0 : 1;
            }
        }
        for(int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (block[i, j] == 1 && !check[i, j])
                {
                    building = 0;
                    DFS(i, j);
                    complex.Add(building);
                }
            }
        }
        complex.Sort();
        result.AppendLine(complex.Count.ToString()) ;
        foreach(int a in complex)
        {
            result.AppendLine(a.ToString());
        }
        Console.WriteLine(result);
    }

    static void DFS(int x, int y)
    {
        check[x, y] = true;
        building++;
        if (x > 0)
        {
            if (block[x - 1, y] == 1 && !check[x - 1, y]) DFS(x - 1, y);
        }
        if (y > 0)
        {
            if (block[x, y - 1] == 1 && !check[x, y - 1]) DFS(x, y - 1);
        }
        if (x < n - 1)
        {
            if (block[x + 1, y] == 1 && !check[x + 1, y]) DFS(x + 1, y);
        }
        if (y < n - 1)
        {
            if (block[x, y + 1] == 1 && !check[x, y + 1]) DFS(x, y + 1);
        }
        return;
    }
}