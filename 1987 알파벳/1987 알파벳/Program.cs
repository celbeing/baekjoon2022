using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
class Program
{
    static int R, C, x, y, max, index;
    static int[] dx = { 1, -1, 0, 0 };
    static int[] dy = { 0, 0, 1, -1 };
    static char[,] map;
    static char[] path;
    static bool[] check = new bool[26];
    static void Main()
    {
        var rc = Console.ReadLine().Split().Select(int.Parse).ToArray();
        R = rc[0]; C = rc[1]; index = 0;
        map = new char[R, C];
        path = new char[R * C + 1];
        for(int i = 0; i < R; i++)
        {
            var row = Console.ReadLine();
            for(int j = 0; j < C; j++)
                map[i, j] = row[j];
        }
        dfs(0, 0);
        Console.WriteLine(max);
    }
    static void dfs(int a, int b)
    {
        path[index] = (map[a, b]); index++;
        check[map[a, b] - 65] = true;
        max = max > index ? max : index;
        if (max == 26) return;
        for (int i = 0; i < 4; i++)
        {
            x = a + dx[i]; y = b + dy[i];
            if (x < 0 || y < 0 || x >= R || y >= C) continue;
            if (check[map[x,y] - 65]) continue;
            else dfs(x, y);
        }
        check[map[a, b] - 65] = false;
        index--;
    }
}