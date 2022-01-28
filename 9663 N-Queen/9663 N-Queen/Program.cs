using System;
class Program
{
    static int N, count, queen;
    static bool[,] board = new bool[15, 15];
    static void Main()
    {
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
            if (queen == N)
            {
                count++;
                queen--;
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
    static bool Check(int x, int y)
    {
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