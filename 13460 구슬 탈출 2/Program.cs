using System;
using System.Collections.Generic;
public class Location
{
    int x, y;
    public Location(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public int X
    {
        get { return this.x; }
        set { x = value; }
    }
    public int Y
    {
        get { return this.y; }
        set { x = value; }
    }
}
class Program
{
    static bool red, blue;
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
        Location goal;
        Location red = new Location(0, 0);
        Location blue = new Location(0, 0);
        for(int i = 0; i < N; i++)
        {
            for(int j = 0; j < M; j++)
            {
                if (board[i, j] == 2)
                    goal = new Location(i, j);
                else if (board[i, j] == 3)
                    red = new Location(i, j);
                else if (board[i, j] == 4)
                    blue = new Location(i, j);
            }
        }

        // 1:up, 2:down, 3:left, 4:right
        if (dir == 0)
        {
            if(red.X > blue.X)
            {
                board[blue.X, blue.Y] = 0;
                for(int i = 0; blue.X - i >= 0; i++)
                {
                    if (board[blue.X - i, blue.Y] == 0) continue;
                    else if (board[blue.X - i, blue.Y] == 2) board[blue.X, blue.Y] = 0;
                    else
                    {
                        board[blue.X, blue.Y] = 0;
                        board[blue.X - i + 1, blue.Y] = 4;
                    }
                }
                board[red.X, red.Y] = 0;
                for (int i = 0; red.X - i >= 0; i++)
                {
                    if (board[red.X - i, red.Y] == 0) continue;
                    else if (board[red.X - i, red.Y] == 2) board[red.X, red.Y] = 0;
                    else
                    {
                        board[red.X, red.Y] = 0;
                        board[red.X - i + 1, red.Y] = 3;
                    }
                }
            }
            else
            {
                board[red.X, red.Y] = 0;
                for (int i = 0; red.X - i >= 0; i++)
                {
                    if (board[red.X - i, red.Y] == 0) continue;
                    else if (board[red.X - i, red.Y] == 2) board[red.X, red.Y] = 0;
                    else
                    {
                        board[red.X, red.Y] = 0;
                        board[red.X - i + 1, red.Y] = 3;
                    }
                }
                board[blue.X, blue.Y] = 0;
                for (int i = 0; blue.X - i >= 0; i++)
                {
                    if (board[blue.X - i, blue.Y] == 0) continue;
                    else if (board[blue.X - i, blue.Y] == 2) board[blue.X, blue.Y] = 0;
                    else
                    {
                        board[blue.X, blue.Y] = 0;
                        board[blue.X - i + 1, blue.Y] = 4;
                    }
                }
            }
            return board;
        }
        else if(dir == 1)
        {
            if (red.X < blue.X)
            {
                board[blue.X, blue.Y] = 0;
                for (int i = 0; blue.X + i < N; i++)
                {
                    if (board[blue.X + i, blue.Y] == 0) continue;
                    else if (board[blue.X + i, blue.Y] == 2) board[blue.X, blue.Y] = 0;
                    else
                    {
                        board[blue.X, blue.Y] = 0;
                        board[blue.X + i - 1, blue.Y] = 4;
                    }
                }
                board[red.X, red.Y] = 0;
                for (int i = 0; red.X + i < N; i++)
                {
                    if (board[red.X + i, red.Y] == 0) continue;
                    else if (board[red.X + i, red.Y] == 2) board[red.X, red.Y] = 0;
                    else
                    {
                        board[red.X, red.Y] = 0;
                        board[red.X + i - 1, red.Y] = 3;
                    }
                }
            }
            else
            {
                board[red.X, red.Y] = 0;
                for (int i = 0; red.X + i < N; i++)
                {
                    if (board[red.X + i, red.Y] == 0) continue;
                    else if (board[red.X + i, red.Y] == 2) board[red.X, red.Y] = 0;
                    else
                    {
                        board[red.X, red.Y] = 0;
                        board[red.X + i - 1, red.Y] = 3;
                    }
                }
                board[blue.X, blue.Y] = 0;
                for (int i = 0; blue.X + i < N; i++)
                {
                    if (board[blue.X + i, blue.Y] == 0) continue;
                    else if (board[blue.X + i, blue.Y] == 2) board[blue.X, blue.Y] = 0;
                    else
                    {
                        board[blue.X, blue.Y] = 0;
                        board[blue.X + i - 1, blue.Y] = 4;
                    }
                }
            }
            return board;
        }
        else if(dir == 2)
        {
            if (red.Y > blue.Y)
            {
                board[blue.X, blue.Y] = 0;
                for (int i = 0; blue.Y - i >= 0; i++)
                {
                    if (board[blue.X, blue.Y - i] == 0) continue;
                    else if (board[blue.X, blue.Y - i] == 2) board[blue.X, blue.Y] = 0;
                    else
                    {
                        board[blue.X, blue.Y] = 0;
                        board[blue.X - i + 1, blue.Y] = 4;
                    }
                }
                board[red.X, red.Y] = 0;
                for (int i = 0; red.X - i >= 0; i++)
                {
                    if (board[red.X - i, red.Y] == 0) continue;
                    else if (board[red.X - i, red.Y] == 2) board[red.X, red.Y] = 0;
                    else
                    {
                        board[red.X, red.Y] = 0;
                        board[red.X - i + 1, red.Y] = 3;
                    }
                }
            }
            else
            {
                board[red.X, red.Y] = 0;
                for (int i = 0; red.X - i >= 0; i++)
                {
                    if (board[red.X - i, red.Y] == 0) continue;
                    else if (board[red.X - i, red.Y] == 2) board[red.X, red.Y] = 0;
                    else
                    {
                        board[red.X, red.Y] = 0;
                        board[red.X - i + 1, red.Y] = 3;
                    }
                }
                board[blue.X, blue.Y] = 0;
                for (int i = 0; blue.X - i >= 0; i++)
                {
                    if (board[blue.X - i, blue.Y] == 0) continue;
                    else if (board[blue.X - i, blue.Y] == 2) board[blue.X, blue.Y] = 0;
                    else
                    {
                        board[blue.X, blue.Y] = 0;
                        board[blue.X - i + 1, blue.Y] = 4;
                    }
                }
            }
            return board;
        }
        else
        {
            return board;
        }
    }
}