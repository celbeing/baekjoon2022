using System;
using System.Collections.Generic;
public class State
{
    private int depth;
    private int[,] board = new int[10, 10];
    private Location red, blue;
    public State(Location red, Location blue, int[,] board, int d)
    {
        this.red = red;
        this.blue = blue;
        this.board = board;
        this.depth = d;
    }
    public Location Red
    {
        get { return this.red; }
        set { red = value; }
    }
    public Location Blue
    {
        get { return this.blue; }
        set { blue = value; }
    }
    public int D
    {
        get { return this.depth; }
        set { depth = value; }
    }
    public int[,] B
    {
        get { return this.board; }
        set { board = value; }
    }
}
public class Location
{
    private int x, y;
    public Location(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public int X
    {
        get { return this.x; }
        set { this.x = value; }
    }
    public int Y
    {
        get { return this.y; }
        set { this.y = value; }
    }
}
class Program
{
    static int N, M;
    static int[,] board = new int[10, 10];
    static Queue<State> bfs= new Queue<State>();
    static Location hole = new Location(0, 0);
    static bool goal = false;
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
        State initial = new State(red, blue, board, 0);
        bfs.Enqueue(initial);
        while(bfs.Count > 0)
        {
            State now = bfs.Dequeue();
            for(int i = 0; i < 4; i++)
            {
                bfs.Enqueue(Push(i, now));
                for(int j = 0; j < N; j++)
                {
                    for(int k = 0; k < M; k++)
                    {
                        if (now.Red.X == j && now.Red.Y == k) Console.Write("R");
                        else if (now.Blue.X == j && now.Blue.Y == k) Console.Write("B");
                        else Console.Write(now.B[j, k]);
                    }
                    Console.Write('\n');
                }
            }
            if (goal)
            {
                Console.WriteLine("done in " + now.D + " moves.");
                break;
            }
        }
        if (!goal) Console.WriteLine("fail");
    }
    static State Push(int dir, State last)
    {
        Location red = last.Red;
        Location blue = last.Blue;
        int[,] board = last.B;
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
        }
        last.Red = red;
        last.Blue = blue;
        last.B = board;
        if (red == hole && blue == hole) goal = true;
        return last;
    }
}