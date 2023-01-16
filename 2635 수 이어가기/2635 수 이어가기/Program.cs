using System;

class Program
{
    static int N, max, index, a1, a2, a3;
    static void Main()
    {
        N = int.Parse(Console.ReadLine());
        int[] count = new int[N];
        max = 0;
        for (int i = 0; i < N; i++)
        {
            a1 = N; a2 = i + 1; a3 = 0; count[i] = 2;
            while (true)
            {
                a3 = a1 - a2;
                if (a3 < 0) break;
                a1 = a2; a2 = a3; count[i]++;
            }
            if (count[i] > max)
            {
                max = count[i];
                index = i;
            }
        }
        Console.WriteLine(max);
        Console.Write($"{N} {index + 1}");
        a1 = N; a2 = index + 1;
        while (true)
        {
            a3 = a1 - a2;
            if (a3 < 0) break;
            Console.Write($" {a3}");
            a1 = a2; a2 = a3;
        }
    }
}