using System;
class Program
{
    static int N, count;
    static int[,] board = new int[15, 15];
    static void Main()
    {
        N = int.Parse(Console.ReadLine());
        Do(0, 0);
        Tracking(0, 0, 1);
        Console.WriteLine(count);
    }
    static void Tracking(int x, int y, int d)
    {
        Console.WriteLine(d + "번째 퀸");
        if (d < N)
        {
            for (int i = y + 1; i < N; i++)
            {
                if (board[x, i] == 0)
                {
                    Do(x, i);
                    if (i == N - 1)
                    {
                        if (x == N - 1)
                        {
                            Undo(x, i);
                            return;
                        }
                        Tracking(x + 1, 0, d + 1);
                    }
                    else Tracking(x, i + 1, d + 1);
                    Undo(x, i);
                }
            }
            for (int i = x + 1; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (board[i, j] == 0)
                    {
                        Do(i, j);
                        if (j == N - 1)
                        {
                            if (i == N - 1)
                            {
                                Undo(i, j);
                                return;
                            }
                            else Tracking(i + 1, 0, d + 1);
                        }
                        else Tracking(i, j + 1, d + 1);
                        Undo(i, j);
                    }
                }
            }
        }
        else if (d == N && board[x,y] == 0) count++;
        return;
    }
    static void Do(int x, int y)
    {
        Console.WriteLine("(" + x + ", " + y + ")");
        for (int i = 0; i < N; i++)
        {
            board[i, y]++;
            board[x, i]++;
        }
        for (int i = 0; i < 15; i++)
        {
            if (i < x - y || i > x - y + 14) { }
            else board[i, i - x + y]++;
            if (i > x + y || i < x + y - 14) { }
            else board[i, x + y - i]++;
        }
        board[x, y] -= 3;
        for(int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write(board[i, j]);
            }
            Console.Write("\n");
        }
    }
    static void Undo(int x, int y)
    {
        for (int i = 0; i < N; i++)
        {
            board[i, y]--;
            board[x, i]--;
        }
        for (int i = 0; i < 15; i++)
        {
            if (i < x - y || i > x - y + 14) { }
            else board[i, i - x + y]--;
            if (i > x + y || i < x + y - 14) { }
            else board[i, x + y - i]--;
        }
        board[x, y] += 3;
    }
}