using System;
using System.Linq;
using System.Collections.Generic;
class Program
{
    static int n;
    static List<int[]> hi = new List<int[]>();
    static List<int[]> ki = new List<int[]>();
    static List<int[]> h = new List<int[]>();
    static List<int[]> k = new List<int[]>();
    static int[,] board = new int[20, 20];
    static int[,] check = new int[20, 20];
    static void Main()
    {
        n = int.Parse(Console.ReadLine());
        for(int i = 0; i < n; i++)
            hi.Add(Console.ReadLine().Split().Select(int.Parse).ToArray());
        for (int i = 0; i < n; i++)
            ki.Add(Console.ReadLine().Split().Select(int.Parse).ToArray());
        for (int i = 0; i < n; i++)
        {
            int[] hcnt = new int[hi[i][0] * 2 + 1];
            hcnt[0] = 0;
            if(hcnt.Length > 1)
                for(int j = 1; j <= hi[i][0]; j++)
            {
                hcnt[j * 2 - 1] = hi[i][j];
                hcnt[j * 2] = 0;
            }
            h.Add(hcnt);
            int[] kcnt = new int[ki[i][0] * 2 + 1];
            kcnt[0] = 0;
            if(kcnt.Length > 1)
                for (int j = 1; j <= ki[i][0]; j++)
            {
                kcnt[j * 2 - 1] = ki[i][j];
                kcnt[j * 2] = 0;
            }
            k.Add(kcnt);
        }

        Console.WriteLine();
    }
}