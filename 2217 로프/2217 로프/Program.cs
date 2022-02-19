using System;
class Program
{
    static int N, max;
    static int[] rope;
    static void Main()
    {
        N = int.Parse(Console.ReadLine());
        rope = new int[N]; max = 0;
        for (int i = 0; i < N; i++)
            rope[i] = int.Parse(Console.ReadLine());
        Array.Sort(rope);
        for(int i = 0; i < N; i++)
        {
            rope[i] *= N - i;
            max = rope[i] > max ? rope[i] : max;
        }
        Console.WriteLine(max);
    }
}