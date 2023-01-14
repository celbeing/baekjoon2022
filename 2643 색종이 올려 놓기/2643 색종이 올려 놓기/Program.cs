using System;
using System.Linq;

class Program
{
    static int N, count;
    static void Main()
    {
        N = int.Parse(Console.ReadLine());
        int[] sort = new int[N];
        int[,] paper = new int[N, 3];
        for (int i = 0; i < N; i++)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            sort[i] = Math.Min(input[0], input[1]) * 1000 + Math.Max(input[0], input[1]);
        }
        Array.Sort(sort);
        for (int i = N - 1; i >= 0; i--)
        {
            paper[i, 0] = sort[N - i - 1] / 1000;
            paper[i, 1] = sort[N - i - 1] % 1000;
        }
        paper[0, 2] = 1;
        count = 1;
        for (int i = 1; i < N; i++)
        {
            for (int j = i - 1; j >= 0; j--)
            {
                if (paper[i, 0] <= paper[j, 0] && paper[i, 1] <= paper[j, 1])
                {
                    paper[i, 2] = Math.Max(paper[j, 2] + 1, paper[i, 2]);
                }
            }
            if (paper[i, 2] == 0) paper[i, 2]++;
            count = Math.Max(paper[i, 2], count);
        }
        Console.WriteLine(count);
    }
}