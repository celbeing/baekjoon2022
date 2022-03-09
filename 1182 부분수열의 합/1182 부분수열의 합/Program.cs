using System;
class Program
{
    static int N, S, sum, count;
    static int[] arr = new int[20];
    static void Main()
    {
        var ns = Console.ReadLine().Split();
        N = int.Parse(ns[0]); S = int.Parse(ns[1]);
        var n = Console.ReadLine().Split();
        for (int i = 0; i < N; i++)
            arr[i] = int.Parse(n[i]);
        for(int i = 0; i < N; i++) Tracking(i);
        Console.WriteLine(count);
    }
    static void Tracking(int index)
    {
        sum += arr[index];
        if (S == sum) count++;
        for (int i = index + 1; i < N; i++)
            Tracking(i);
        sum -= arr[index];
    }
}