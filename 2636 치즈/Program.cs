using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static int row, column, time, last;
    static int[] dr = { 1, 0, -1, 0 };
    static int[] dc = { 0, 1, 0, -1 };
    static bool[,] cheese, check;
    static Queue<int> exposed = new Queue<int>();
    static Queue<int> air = new Queue<int>();
    static void Main()
    {
        int[] rc = Console.ReadLine().Split().Select(int.Parse).ToArray();
        row = rc[0]; column = rc[1];
        cheese = new bool[row, column];
        check = new bool[row, column];
        for (int i = 0; i < row; i++)
        {
            int[] r = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int j = 0; j < column; j++)
            {
                if (r[j] == 1)
                {
                    cheese[i, j] = true;
                    last++;
                }
                else cheese[i, j] = false;
            }
        }
        air.Enqueue(0);
        Melt();
    }
    static void Melt()
    {
        while (true)
        {
            while (air.Count > 0)
            {
                int r = air.Peek() / 100;
                int c = air.Dequeue() % 100;
                for (int i = 0; i < 4; i++)
                {
                    int rr = r + dr[i];
                    int cc = c + dc[i];
                    if (rr < 0 || rr >= row || cc < 0 || cc >= column || check[rr, cc]) continue;
                    if (cheese[rr, cc])
                    {
                        check[rr, cc] = true;
                        exposed.Enqueue(rr * 100 + cc);
                    }
                    else
                    {
                        check[rr, cc] = true;
                        air.Enqueue(rr * 100 + cc);
                    }
                }
            }
            if (exposed.Count == last)
            {
                if (last != 0) Console.WriteLine(time + 1);
                else Console.WriteLine(time);
                Console.WriteLine(last);
                return;
            }
            while (exposed.Count > 0)
            {
                int r = exposed.Peek() / 100;
                int c = exposed.Peek() % 100;
                cheese[r, c] = false; last--;
                air.Enqueue(exposed.Dequeue());
            }
            time++;
        }
    }
}