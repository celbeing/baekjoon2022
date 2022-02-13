using System;
using System.Collections.Generic;
class Program
{
    static int W, H;
    static void Main()
    {
        var wh = Console.ReadLine().Split();
        W = int.Parse(wh[0]); H = int.Parse(wh[1]);
        char[,] map = new char[H, W];
        for(int i = 0; i < H; i++)
        {
            var row = Console.ReadLine();
            for (int j = 0; j < W; j++) map[i, j] = row[j];
        }
    }
}