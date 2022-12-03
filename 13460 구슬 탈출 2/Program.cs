using System;
using System.Collections.Generic;
class Program
{
    static int N, M, ox, oy, count;
    static int[,] board = new int[10, 10];
    static bool[,,,] check = new bool[10, 10, 10, 10];
    static void Main()
    {
        string[] rc = Console.ReadLine().Split();
        N = int.Parse(rc[0]);
        M = int.Parse(rc[1]);
        count = 1;
        int[] loc = { 0, 0, 0, 0 };
        for (int i = 0; i < N; i++)
        {
            string input = Console.ReadLine();
            for (int j = 0; j < M; j++)
            {
                switch (input[j])
                {
                    case '#':
                        board[i, j] = 1;
                        break;
                    case '.':
                        board[i, j] = 0;
                        break;
                    case 'O':
                        board[i, j] = 0;
                        ox = i; oy = j;
                        break;
                    case 'R':
                        board[i, j] = 0;
                        loc[0] = i; loc[1] = j;
                        break;
                    case 'B':
                        board[i, j] = 0;
                        loc[2] = i; loc[3] = j;
                        break;
                }
            }
        }
        Queue<int[]> bfs = new Queue<int[]>();
        Queue<int[]> q = new Queue<int[]>();
        bfs.Enqueue(loc);
        check[loc[0], loc[1], loc[2], loc[3]] = true;
        while(bfs.Count > 0)
        {
            int[] last = bfs.Dequeue();
            
            for(int i = 0; i < 4; i++)
            {
                int[] cnt = new int[4];
                cnt = push(last, i);
                if (cnt[0] == 0) return;
                else if (cnt[0] == 10) continue;
                if (!check[cnt[0], cnt[1], cnt[2], cnt[3]])
                {
                    q.Enqueue(cnt);
                    check[cnt[0], cnt[1], cnt[2], cnt[3]] = true;
                }
            }
            if (bfs.Count == 0)
            {
                count++;
                if (count == 11) break;
                while (q.Count > 0) bfs.Enqueue(q.Dequeue());
            }
        }
        Console.WriteLine(-1);
    }
    static int[] push(int[] last, int dir)
    {
        int rx, ry, bx, by;
        int[] New = new int[4];
        for (int i = 0; i < 4; i++) New[i] = last[i];
        rx = New[0]; ry = New[1]; bx = New[2]; by = New[3];
        // rx = last[0]; ry = last[1]; bx = last[2]; by = last[3];
        if(dir == 0)
        {
            while(rx >= 0)
            {
                if ((rx == bx && ry == by) || board[rx, ry] == 1)
                {
                    rx++;
                    break;
                }
                else if (rx == ox && ry == oy)
                {
                    break;
                }
                rx--;
            }
            while (bx >= 0)
            {
                if (bx == ox && by == oy)
                {
                    int[] flag = { 10, 10, 10, 10 };
                    return flag;
                }
                else if ((rx == bx && ry == by) || board[bx, by] == 1)
                {
                    bx++;
                    break;
                }
                bx--;
            }
            while (rx >= 0)
            {
                if ((rx == bx && ry == by) || board[rx, ry] == 1)
                {
                    rx++;
                    break;
                }
                else if (rx == ox && ry == oy)
                {
                    Console.WriteLine(count);
                    int[] flag = { 0, 0, 0, 0 };
                    return flag;
                }
                rx--;
            }
        }
        else if (dir == 1)
        {
            while (ry >= 0)
            {
                if ((rx == bx && ry == by) || board[rx, ry] == 1)
                {
                    ry++;
                    break;
                }
                else if (rx == ox && ry == oy)
                {
                    break;
                }
                ry--;
            }
            while (by >= 0)
            {
                if (bx == ox && by == oy)
                {
                    int[] flag = { 10, 10, 10, 10 };
                    return flag;
                }
                else if ((rx == bx && ry == by) || board[bx, by] == 1)
                {
                    by++;
                    break;
                }
                by--;
            }
            while (ry >= 0)
            {
                if ((rx == bx && ry == by) || board[rx, ry] == 1)
                {
                    ry++;
                    break;
                }
                else if (rx == ox && ry == oy)
                {
                    Console.WriteLine(count);
                    int[] flag = { 0, 0, 0, 0 };
                    return flag;
                }
                ry--;
            }
        }
        else if (dir == 2)
        {
            while (rx < N)
            {
                if ((rx == bx && ry == by) || board[rx, ry] == 1)
                {
                    rx--;
                    break;
                }
                else if (rx == ox && ry == oy)
                {
                    break;
                }
                rx++;
            }
            while (bx < N)
            {
                if (bx == ox && by == oy)
                {;
                    int[] flag = { 10, 10, 10, 10 };
                    return flag;
                }
                else if ((rx == bx && ry == by) || board[bx, by] == 1)
                {
                    bx--;
                    break;
                }
                bx++;
            }
            while (rx < N)
            {
                if ((rx == bx && ry == by) || board[rx, ry] == 1)
                {
                    rx--;
                    break;
                }
                else if (rx == ox && ry == oy)
                {
                    Console.WriteLine(count);
                    int[] flag = { 0, 0, 0, 0 };
                    return flag;
                }
                rx++;
            }
        }
        else if (dir == 3)
        {
            while (ry < M)
            {
                if ((rx == bx && ry == by) || board[rx, ry] == 1)
                {
                    ry--;
                    break;
                }
                else if (rx == ox && ry == oy)
                {
                    break;
                }
                ry++;
            }
            while (by < M)
            {
                if (bx == ox && by == oy)
                {
                    int[] flag = { 10, 10, 10, 10 };
                    return flag;
                }
                else if  ((rx == bx && ry == by) || board[bx, by] == 1)
                {
                    by--;
                    break;
                }
                by++;
            }
            while (ry < M)
            {
                if ((rx == bx && ry == by) || board[rx, ry] == 1)
                {
                    ry--;
                    break;
                }
                else if (rx == ox && ry == oy)
                {
                    Console.WriteLine(count);
                    int[] flag = { 0, 0, 0, 0 };
                    return flag;
                }
                ry++;
            }
        }
        New[0] = rx; New[1] = ry; New[2] = bx; New[3] = by;
        return New;
    } 
}