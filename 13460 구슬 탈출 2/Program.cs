using System;
using System.Collections.Generic;
class Program
{
    static int N, M, ox, oy, count;
    static List<char[,]> memory = new List<char[,]>();
    static void Main()
    {
        string[] rc = Console.ReadLine().Split();
        N = int.Parse(rc[0]);
        M = int.Parse(rc[1]);
        count = 0;
        char[,] board = new char[N, M];
        for (int i = 0; i < N; i++)
        {
            string input = Console.ReadLine();
            for (int j = 0; j < M; j++)
            {
                board[i, j] = input[j];
                if(input[j] == 'O')
                {
                    ox = i; oy = j;
                }
            }
        }
        Queue<char[,]> bfs = new Queue<char[,]>();
        Queue<char[,]> q = new Queue<char[,]>();
        bfs.Enqueue(board);
        memory.Add(board);
        while(bfs.Count > 0)
        {
            char[,] nboard = copy(bfs.Dequeue());
            char[,] cboard = copy(nboard);
            for(int i = 0; i < 4; i++)
            {
                
                cboard = push(cboard, i);
                for (int j = 0; j < memory.Count; j++)
                {
                    if (equals(memory[j], cboard, N, M)) continue;
                    else
                    {
                        q.Enqueue(cboard);
                        memory.Add(cboard);
                    }
                }
            }
            if(bfs.Count == 0)
            {
                count++;
                if(count == 11)
                {
                    Console.WriteLine(-1);
                    return;
                }
                while (q.Count > 0)
                {
                    if (check(q.Peek()))
                    {
                        Console.WriteLine(count);
                        return;
                    }
                    bfs.Enqueue(q.Dequeue());
                }
            }
        }
    }
    static bool equals(char[,] a, char[,] b, int x, int y)
    {
        for(int i = 0; i < x; i++)
        {
            for(int j = 0; j < y; j++)
            {
                if (a[i, j] != b[i, j]) return false;
            }
        }
        return true;
    }
    static bool check(char[,] board)
    {
        for(int i = 0; i < N; i++)
        {
            for(int j = 0; j < M; j++)
            {
                if (board[i, j] == 'R') return false;
            }
        }
        return true;
    }
    static char[,] copy(char[,] board)
    {
        char[,] nboard = new char[N, M];
        for(int i = 0; i < N; i++)
        {
            for(int j = 0; j < M; j++)
            {
                nboard[i, j] = board[i, j];
            }
        }
        return nboard;
    }
    static char[,] push(char[,] board, int dir)
    {
        int rx, ry, bx, by;
        rx = 0; ry = 0; bx = 0; by = 0;
        char[,] nboard = copy(board);
        for(int i = 0; i < N; i++)
        {
            for(int j = 0; j < M; j++)
            {
                if(board[i,j] == 'R')
                {
                    rx = i; ry = j;
                }
                else if(board[i,j] == 'B')
                {
                    bx = i; by = j;
                }
            }
        }
        if(dir == 0)
        {
            bool hit = false;
            for(int i = 1; rx - i >= 0 && !hit; i++)
            {
                switch (nboard[rx - i, ry])
                {
                    case '.':
                        break;
                    case 'O':
                        nboard[rx, ry] = '.';
                        hit = true;
                        break;
                    default:
                        nboard[rx, ry] = '.';
                        nboard[rx - i + 1, ry] = 'R';
                        hit = true;
                        rx -= i - 1;
                        break;
                }
            }
            hit = false;
            for(int i = 1; bx - i >= 0 && !hit; i++)
            {
                switch (nboard[bx - i, by])
                {
                    case '.':
                        break;
                    case 'O':
                        nboard[bx, by] = '.';
                        hit = true;
                        break;
                    default:
                        nboard[bx, by] = '.';
                        nboard[bx - i + 1, by] = 'B';
                        hit = true;
                        bx -= i - 1;
                        break;
                }
            }
            hit = false;
            for (int i = 1; rx - i >= 0 && !hit; i++)
            {
                switch (nboard[rx - i, ry])
                {
                    case '.':
                        break;
                    case 'O':
                        nboard[rx, ry] = '.';
                        hit = true;
                        break;
                    default:
                        nboard[rx, ry] = '.';
                        nboard[rx - i + 1, ry] = 'R';
                        hit = true;
                        rx -= i - 1;
                        break;
                }
            }
        }
        else if (dir == 1)
        {
            bool hit = false;
            for (int i = 1; ry - i >= 0 && !hit; i++)
            {
                switch (nboard[rx, ry - i])
                {
                    case '.':
                        break;
                    case 'O':
                        nboard[rx, ry] = '.';
                        hit = true;
                        break;
                    default:
                        nboard[rx, ry] = '.';
                        nboard[rx, ry - i + 1] = 'R';
                        hit = true;
                        ry -= i - 1;
                        break;
                }
            }
            hit = false;
            for (int i = 1; by - i >= 0 && !hit; i++)
            {
                switch (nboard[bx, by - i])
                {
                    case '.':
                        break;
                    case 'O':
                        nboard[bx, by] = '.';
                        hit = true;
                        break;
                    default:
                        nboard[bx, by] = '.';
                        nboard[bx, by - i + 1] = 'B';
                        hit = true;
                        by -= i - 1;
                        break;
                }
            }
            hit = false;
            for (int i = 1; ry - i >= 0 && !hit; i++)
            {
                switch (nboard[rx, ry - i])
                {
                    case '.':
                        break;
                    case 'O':
                        nboard[rx, ry] = '.';
                        hit = true;
                        break;
                    default:
                        nboard[rx, ry] = '.';
                        nboard[rx, ry - i + 1] = 'R';
                        hit = true;
                        ry -= i - 1;
                        break;
                }
            }
        }
        else if (dir == 2)
        {
            bool hit = false;
            for (int i = 1; rx + i < N && !hit; i++)
            {
                switch (nboard[rx + i, ry])
                {
                    case '.':
                        break;
                    case 'O':
                        nboard[rx, ry] = '.';
                        hit = true;
                        break;
                    default:
                        nboard[rx, ry] = '.';
                        nboard[rx + i - 1, ry] = 'R';
                        hit = true;
                        rx += i - 1;
                        break;
                }
            }
            hit = false;
            for (int i = 1; bx + i < N && !hit; i++)
            {
                switch (nboard[bx + i, by])
                {
                    case '.':
                        break;
                    case 'O':
                        nboard[bx, by] = '.';
                        hit = true;
                        break;
                    default:
                        nboard[bx, by] = '.';
                        nboard[bx + i - 1, by] = 'B';
                        hit = true;
                        bx += i - 1;
                        break;
                }
            }
            hit = false;
            for (int i = 1; rx + i < N && !hit; i++)
            {
                switch (nboard[rx + i, ry])
                {
                    case '.':
                        break;
                    case 'O':
                        nboard[rx, ry] = '.';
                        hit = true;
                        break;
                    default:
                        nboard[rx, ry] = '.';
                        nboard[rx + i - 1, ry] = 'R';
                        hit = true;
                        rx += i - 1;
                        break;
                }
            }
        }
        else if (dir == 3)
        {
            bool hit = false;
            for (int i = 1; ry + i < M && !hit; i++)
            {
                switch (nboard[rx, ry + i])
                {
                    case '.':
                        break;
                    case 'O':
                        nboard[rx, ry] = '.';
                        hit = true;
                        break;
                    default:
                        nboard[rx, ry] = '.';
                        nboard[rx, ry + i - 1] = 'R';
                        hit = true;
                        ry += i - 1;
                        break;
                }
            }
            hit = false;
            for (int i = 1; by + i < M && !hit; i++)
            {
                switch (nboard[bx, by + i])
                {
                    case '.':
                        break;
                    case 'O':
                        nboard[bx, by] = '.';
                        hit = true;
                        break;
                    default:
                        nboard[bx, by] = '.';
                        nboard[bx, by + i - 1] = 'B';
                        hit = true;
                        by += i - 1;
                        break;
                }
            }
            hit = false;
            for (int i = 1; ry + i < M && !hit; i++)
            {
                switch (nboard[rx, ry + i])
                {
                    case '.':
                        break;
                    case 'O':
                        nboard[rx, ry] = '.';
                        hit = true;
                        break;
                    default:
                        nboard[rx, ry] = '.';
                        nboard[rx, ry + i - 1] = 'R';
                        hit = true;
                        ry += i - 1;
                        break;
                }
            }
        }
        for(int i = 0; i < N; i++)
        {
            for(int j = 0; j < M; j++)
            {
                Console.Write(nboard[i, j]);
            }
            Console.Write('\n');
        }
        Console.WriteLine(count + "trial " + dir + "dir");
        Console.WriteLine(rx + " " + ry + " " + bx + " " + by);
        return nboard;
    } 
}

/*
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
*/