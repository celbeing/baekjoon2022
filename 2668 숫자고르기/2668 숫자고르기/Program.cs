using System;
using System.Collections.Generic;

class Program
{
    static int N;
    static int[] arr = new int[101];
    static bool[] check = new bool[101];
    static Queue<int> loop = new Queue<int>();
    static Queue<int> result = new Queue<int>();
    static void Main()
    {
        N = int.Parse(Console.ReadLine());
        for(int i = 1; i <= N; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        for(int i = 1; i <= N; i++)
        {
            if (check[i]) continue;
            int cnt = arr[i];
            do
            {
                if (loop.Contains(cnt))
                {
                    loop.Clear();
                    break;
                }
                loop.Enqueue(cnt);
                cnt = arr[cnt];
            } while (cnt != i);
            if (loop.Count == 0) continue;
            loop.Enqueue(i);
            while (loop.Count > 0)
                check[loop.Dequeue()] = true;
        }
        for (int i = 1; i <= N; i++)
            if (check[i]) result.Enqueue(i);
        Console.WriteLine(result.Count);
        while (result.Count > 0) Console.WriteLine(result.Dequeue());
    }
}