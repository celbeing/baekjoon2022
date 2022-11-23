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
    static int N, M;
    static int[,] board = new int[10, 10];
    static Queue<int[,]> bfs= new Queue<int[,]>();
    static Location hole = new Location(0, 0);
    static void Main()
    {
        string a = Console.ReadLine();
        N = int.Parse(a.Split()[0]);
        M = int.Parse(a.Split()[1]);
        Location red = new Location(0, 0);
        Location blue = new Location(0, 0);
        for(int i = 0; i < N; i++)
        {
            a = Console.ReadLine();
            for(int j = 0; j < M; j++)
            {
                if (a[j] == '#')        // wall
                    board[i, j] = 1;
                else if (a[j] == '.')   // blank
                    board[i, j] = 0;
                else if (a[j] == 'O')   // holl
                {
                    hole.X = i; hole.Y = j;
                    board[i, j] = 0;
                }
                else if (a[j] == 'R')   // red
                {
                    red.X = i; red.Y = j;
                    board[i, j] = 0;
                }
                else if (a[j] == 'B')   // blue
                {
                    blue.X = i; blue.Y = j;
                    board[i, j] = 0;
                }
            }
        }
    }
    static int[,] Push(int dir, Location red, Location blue, int depth)
    {
        // 0:up, 1:down, 2:left, 3:right
        if (dir == 0)
        {
            while (board[red.X - 1, red.Y] == 0 && red != hole)
            {
                if (red.X - 1 == blue.X && red.Y == blue.Y) break;
                red.X--;
            }
            while (board[blue.X - 1, blue.Y] == 0 && blue != hole)
            {
                if (red.X == blue.X - 1 && red.Y == blue.Y) break;
                blue.X--;
            }
            while (board[red.X - 1, red.Y] == 0 && red != hole)
            {
                if (red.X - 1 == blue.X && red.Y == blue.Y) break;
                red.X--;
            }
            return board;
        }
        else if (dir == 1)
        {
            while (board[red.X + 1, red.Y] == 0 && red != hole)
            {
                if (red.X + 1 == blue.X && red.Y == blue.Y) break;
                red.X++;
            }
            while (board[blue.X + 1, blue.Y] == 0 && blue != hole)
            {
                if (red.X == blue.X + 1 && red.Y == blue.Y) break;
                blue.X++;
            }
            while (board[red.X + 1, red.Y] == 0 && red != hole)
            {
                if (red.X + 1 == blue.X && red.Y == blue.Y) break;
                red.X++;
            }
            return board;
        }
        else if(dir == 2)
        {
            while (board[red.X, red.Y - 1] == 0 && red != hole)
            {
                if (red.X == blue.X && red.Y - 1 == blue.Y) break;
                red.Y--;
            }
            while (board[blue.X, blue.Y - 1] == 0 && blue != hole)
            {
                if (red.X == blue.X && red.Y == blue.Y - 1) break;
                blue.Y--;
            }
            while (board[red.X, red.Y - 1] == 0 && red != hole)
            {
                if (red.X == blue.X && red.Y - 1 == blue.Y) break;
                red.Y--;
            }
            return board;
        }
        else
        {
            while (board[red.X, red.Y + 1] == 0 && red != hole)
            {
                if (red.X == blue.X && red.Y + 1 == blue.Y) break;
                red.Y++;
            }
            while (board[blue.X, blue.Y + 1] == 0 && blue != hole)
            {
                if (red.X == blue.X && red.Y == blue.Y + 1) break;
                blue.Y++;
            }
            while (board[red.X, red.Y + 1] == 0 && red != hole)
            {
                if (red.X == blue.X && red.Y + 1 == blue.Y) break;
                red.Y++;
            }
            return board;
        }
    }
}