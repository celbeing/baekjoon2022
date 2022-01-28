using System;
class Program
{
    static int N, count, queen;
    static int[,] location = new int[15, 2];
    static int[] xpy = new int[15];
    static int[] xmy = new int[15];
    static int[] xx = new int[15];
    static int[] yy = new int[15];
    static bool[,] board = new bool[15, 15];
    static void Main()
    {
        for(int i = 0; i < 15;)
        {
            xpy[i] = 30;
            xmy[i] = 15;
            xx[i] = 15;
            yy[i] = 15;
        }
        N = int.Parse(Console.ReadLine());
        for(int i = 0; i < N; i++)
        {
            for(int j = 0; j < N; j++)
            {
                Tracking(i, j);
            }
        }
        Console.WriteLine(count);
    }
    static void Tracking(int x, int y)
    {
        if (Check(x, y))
        {
            board[x, y] = true;
            queen++;
            Record(x, y, queen - 1);
            if (queen == N)
            {
                count++;
                queen--;
                Remove(x, y, queen - 1);
                board[x, y] = false;
                return;
            }
        }
        else return;
        if(x < N - 1)
        {
            for(int i = x + 1; i < N; i++)
            {
                for(int j = 0; j < N; j++)
                {
                    Tracking(i, j);
                }
            }
        }
        queen--;
        board[x, y] = false;
    }
    static void Record(int x, int y, int q)
    {
        xpy[q] = x + y;
        xmy[q] = x - y;
        xx[q] = x;
        yy[q] = y;
    }
    static void Remove(int x, int y, int q)
    {
        xpy[q] = 30;
        xmy[q] = 15;
        xx[q] = 15;
        yy[q] = 15;
    }
    static bool Check(int x, int y)
    {
            if (xpy.) return false;
            if (location[i, 0] - location[i, 1] == x - y) return false;
            if (location[i, 0] == x) return false;
            if (location[i, 1] == y) return false;
        return true;
        /*
        for(int i = 0; i < N; i++)
        {
            if (board[x, i] && i != y) return false;
            if (board[i, y] && i != x) return false;
        }   // 가로, 세로 방향으로 true 칸 있으면 false
        for(int i = 0; i < 15; i++)
        {
            if (i < x - y || i > x - y + 14) { }
            else if (board[i, i - x + y] && i != x) return false;
            if (i > x + y || i < x + y - 14) { }
            else if (board[i, x + y - i] && i != x) return false;
        }   // 대각선 방향 true 칸 있으면 false
        return !board[x,y];
        */
    }
    static void Print()
    {
        Console.WriteLine(queen);
        for(int i = 0; i < N; i++)
        {
            for(int j = 0; j < N; j++)
            {
                Console.Write(board[i, j] ? "1" : "0");
            }
            Console.Write("\n");
        }
    }
}