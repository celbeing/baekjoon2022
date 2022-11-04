using System;
using System.Collections.Generic;
class Program
{
    static int N, M;
    static int[,] board = new int[10, 10];
    static Queue<int[,]> bfs= new Queue<int[,]>();
    static void Main()
    {
        string a = Console.ReadLine();
        N = int.Parse(a.Split()[0]);
        M = int.Parse(a.Split()[1]);
        for(int i = 0; i < N; i++)
        {
            a = Console.ReadLine();
            for(int j = 0; j < M; j++)
            {
                if (a[j] == '#')
                    board[i, j] = 1;
                else if (a[j] == '.')
                    board[i, j] = 0;
                else if (a[j] == 'O')
                    board[i, j] = 2;
                else if (a[j] == 'R')
                    board[i, j] = 3;
                else if (a[j] == 'B')
                    board[i, j] = 4;
            }
        }
    }
    static int[,] Push(int[,] board, int dir, int depth)
    {
        if (dir == 0)
        {

        }
        return board;
    }
}