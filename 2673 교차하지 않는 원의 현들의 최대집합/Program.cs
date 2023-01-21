using System;
using System.Linq;
class Program
{
    static int N;
    static int[,] dp = new int[100, 100];
    static int[,] str = new int[100, 100];
    static void Main()
    {
        N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
        {
            int[] ab = Console.ReadLine().Split().Select(int.Parse).ToArray();
            str[ab[0] - 1, ab[1] - 1] = 1; str[ab[1] - 1, ab[0] - 1] = 1;
        }
        for (int i = 0; i < 100; i++)
            for (int j = i; j >= 0; j--)
                for (int k = j; k < i; k++)
                    dp[j, i] = Math.Max(dp[j, i], dp[j, k] + dp[k, i] + str[i, j]);
        Console.WriteLine(dp[0, 99]);
    }
}