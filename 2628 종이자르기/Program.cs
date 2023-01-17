using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static int width, height, n;
    static int[] w, h;
    static Stack<int> ws = new Stack<int>();
    static Stack<int> hs = new Stack<int>();
    static void Main()
    {
        int[] wh = Console.ReadLine().Split().Select(int.Parse).ToArray();
        width = wh[0]; height = wh[1];
        n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            wh = Console.ReadLine().Split().Select(int.Parse).ToArray();
            if (wh[0] == 0) hs.Push(wh[1]);
            else ws.Push(wh[1]);
        }
        w = new int[ws.Count + 2];
        h = new int[hs.Count + 2];
        for (int i = 1; ws.Count > 0; i++) w[i] = ws.Pop();
        for (int i = 1; hs.Count > 0; i++) h[i] = hs.Pop();
        w[0] = 0; h[0] = 0;
        w[w.Length - 1] = width;
        h[h.Length - 1] = height;
        Array.Sort(w);
        Array.Sort(h);
        width = 0; height = 0;
        for (int i = 1; i < w.Length; i++) width = Math.Max(width, w[i] - w[i - 1]);
        for (int i = 1; i < h.Length; i++) height = Math.Max(height, h[i] - h[i - 1]);
        Console.WriteLine(width * height);
    }
}