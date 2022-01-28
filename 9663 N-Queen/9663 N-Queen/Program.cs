using System;
using System.Collections.Generic;
class Program
{
    static int N, count;
    static Stack<int> location = new Stack<int>();
    static int[,] board = new int[15, 15];
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
        if (Promising() < N - location.Count) return;
        if (board[x, y] == 0)
        {
            location.Push((x * N) + y);
            Do(location.Peek());
        }
        else return;
        if (location.Count == N)
        {
            count++;
            Undo(location.Pop());
            return;
        }
        if (y < N - 1)
        {
            for (int i = y + 1; i < N; i++)
            {
                Tracking(x, i);
            }
        }
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
        Undo(location.Pop());
    }
    static int Promising()
    {
        if (location.Count == 0) return N * N;
        int x = location.Peek() / N;
        int y = location.Peek() % N;
        int cnt = 0;
        if(y < N - 1)
        {
            for(int i = y + 1; i < N; i++)
            {
                if (board[x, y] == 0) cnt++;
            }
        }
        if(x < N - 1)
        {
            for(int i = x + 1; i < N; i++)
            {
                for(int j = 0; j < N; j++)
                {
                    if (board[i, j] == 0) cnt++;
                }
            }
        }
        return cnt;
    }
    static void Do(int a)
    {
        int x = a / N;
        int y = a % N;
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
    }
    static void Undo(int a)
    {
        int x = a / N;
        int y = a % N;
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