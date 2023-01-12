using System;
using System.Collections.Generic;

class Program
{
    static string[] input = new string[6];
    static int[,] board = new int[6, 6];
    static bool[,] check = new bool[6, 6];
    static int count, result, find;
    static int[] dr = { 0, 1, 0, -1 };
    static int[] dc = { 1, 0, -1, 0 };
    static int[] dir = new int[4];
    // 0:r, 1:d, 2:l, 3:u
    static void Main()
    {
        for (int i = 0; i < 6; i++)
        {
            input = Console.ReadLine().Split();
            for (int j = 0; j < 6; j++)
            {
                board[i, j] = int.Parse(input[j]);
                if (board[i, j] != 0) count++;
            }
        }
        if (count != 6)
        {
            Console.WriteLine(0);
            return;
        }
        for (int n = 1; n <= 6; n++)
        {
            for(int i = 0; i < 6; i++)
                for(int j = 0; j < 6; j++)
                    check[i, j] = false;
            for (int i = 0; i < 4; i++) dir[i] = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (board[i, j] == n)
                    {
                        check[i, j] = true;
                        if (n == 1) result = dfs(i, j);
                        if (dfs(i, j) == 0)
                        {
                            Console.WriteLine(0);
                            return;
                        }
                    }
                }
            }
        }
        Console.WriteLine(result);
    }
    static int dfs(int r, int c)
    {
        for (int i = 0; i < 4; i++)
        {
            if (dir[find] == 2) return board[r, c];
            if (r + dr[i] < 0 || r + dr[i] > 5 || c + dc[i] < 0 || c + dc[i] > 5) continue;
            if (check[r + dr[i], c + dc[i]]) continue;
            if (board[r + dr[i], c + dc[i]] != 0)
            {
                if (dir[0] + dir[1] + dir[2] + dir[3] == 0) find = 4;
                dir[i]++;
                if (find == 4) find = i;
                check[r + dr[i], c + dc[i]] = true;
                int res = dfs(r + dr[i], c + dc[i]);
                if (res != 0) return res;
                dir[i]--;
            }
        }
        return 0;
    }
}