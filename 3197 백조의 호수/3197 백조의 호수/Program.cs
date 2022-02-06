using System;
using System.Collections.Generic;
public class loc
{
    public int x;
    public int y;
    public loc(int a, int b)
    {
        x = a;
        y = b;
    }
}
class Program
{
    static int R, C, day, r, c;
    static int[,] lake = new int[1500, 1500];
    static bool[,] wcheck = new bool[1500, 1500];
    static bool[,] scheck = new bool[1500, 1500];
    static Queue<loc> water = new Queue<loc>();
    static Queue<loc> Nwater = new Queue<loc>();
    static Queue<loc> swan = new Queue<loc>();
    static Queue<loc> Nswan = new Queue<loc>();
    static void Main()
    {
        var rc = Console.ReadLine().Split();
        R = int.Parse(rc[0]); C = int.Parse(rc[1]);
        for (int i = 0; i < R; i++)
        {
            var row = Console.ReadLine();
            for (int j = 0; j < C; j++)
            {
                if (row[j] == '.') lake[i, j] = 0;      // 0 : water
                else if (row[j] == 'X') lake[i, j] = 1; // 1 : glacier
                else { lake[i, j] = -1; Console.WriteLine("Swan here"); }                   // -1: swan
            }
        }
        for (int i = 0; i < R; i++)
        {
            for (int j = 0; j < C; j++)
            {
                if (lake[i, j] < 1)
                {
                    water.Enqueue(new loc(i, j));
                    wcheck[i, j] = true;
                }
                if (lake[i, j] == -1)
                {
                    swan.Enqueue(new loc(i, j));
                    scheck[i, j] = true;
                }
            }
        }
        scheck[swan.Peek().x, swan.Peek().y] = false;
        swan.Dequeue();
        while (true)
        {
            Console.WriteLine($"days gone... today is {day}");
            while (Nwater.Count > 0)
            {
                r = Nwater.Peek().x; c = Nwater.Peek().y;
                if (lake[r, c] == 1) lake[r, c] = 0;
                water.Enqueue(new loc(r, c));
                Nwater.Dequeue();
            }                               // Nwater 빙하 녹이고
                                            // water  으로 큐 옮기기
            while (water.Count > 0)
            {
                r = water.Peek().x; c = water.Peek().y;
                Console.WriteLine($"check water {r},{c}");
                if (r > 0 && !wcheck[r - 1, c])
                {
                    if (lake[r - 1, c] == 1) Nwater.Enqueue(new loc(r - 1, c));
                    else water.Enqueue(new loc(r - 1, c));
                    wcheck[r - 1, c] = true;
                }
                if (c > 0 && !wcheck[r, c - 1])
                {
                    if (lake[r, c - 1] == 1) Nwater.Enqueue(new loc(r, c - 1));
                    else water.Enqueue(new loc(r, c - 1));
                    wcheck[r, c - 1] = true;
                }
                if (r < R - 1 && !wcheck[r + 1, c])
                {
                    if (lake[r + 1, c] == 1) Nwater.Enqueue(new loc(r + 1, c));
                    else water.Enqueue(new loc(r + 1, c));
                    wcheck[r + 1, c] = true;
                }
                if (c < C - 1 && !wcheck[r, c + 1])
                {
                    if (lake[r, c + 1] == 1) Nwater.Enqueue(new loc(r, c + 1));
                    else water.Enqueue(new loc(r, c + 1));
                    wcheck[r, c + 1] = true;
                }                               // water  좌표 상하좌우 확인하고
                                                // 빙하 있으면 Nwater에 Enqueue,
                                                // 빙하 없으면  water에 Enqueue
                water.Dequeue();
            }
            Console.WriteLine($"{day} Water check done");
            while (Nswan.Count > 0)
            {
                r = Nswan.Peek().x; c = Nswan.Peek().y;
                swan.Enqueue(new loc(r, c));
                Nswan.Dequeue();
            }                               // Nswan에서 swan으로 큐 옮기기
            while (swan.Count > 0)
            {
                r = swan.Peek().x; c = swan.Peek().y;
                Console.WriteLine($"check swan {r},{c}");
                if (r > 0 && !scheck[r - 1, c])
                {
                    if(lake[r - 1, c] == -1)
                    {
                        Console.WriteLine(day);
                        return;
                    }
                    else if (lake[r - 1, c] == 1) Nswan.Enqueue(new loc(r - 1, c));
                    else swan.Enqueue(new loc(r - 1, c));
                    scheck[r - 1, c] = true;
                }
                if (c > 0 && !scheck[r, c - 1])
                {
                    if (lake[r, c - 1] == -1)
                    {
                        Console.WriteLine(day);
                        return;
                    }
                    else if (lake[r, c - 1] == 1) Nswan.Enqueue(new loc(r, c - 1));
                    else swan.Enqueue(new loc(r, c - 1));
                    scheck[r, c - 1] = true;
                }
                if (r < R - 1 && !scheck[r + 1, c])
                {
                    if (lake[r + 1, c] == -1)
                    {
                        Console.WriteLine(day);
                        return;
                    }
                    else if (lake[r + 1, c] == 1) Nswan.Enqueue(new loc(r + 1, c));
                    else swan.Enqueue(new loc(r + 1, c));
                    scheck[r + 1, c] = true;
                }
                if (c < C - 1 && !scheck[r, c + 1])
                {
                    if (lake[r, c + 1] == -1)
                    {
                        Console.WriteLine(day);
                        return;
                    }
                    else if (lake[r, c + 1] == 1) Nswan.Enqueue(new loc(r, c + 1));
                    else swan.Enqueue(new loc(r, c + 1));
                    scheck[r, c + 1] = true;
                }
                swan.Dequeue();
            }
            Console.WriteLine($"{day} Swan check done");
            day++;
        }
    }
}