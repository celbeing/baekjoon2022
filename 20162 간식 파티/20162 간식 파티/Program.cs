using System;
class Program
{
    static int N, max;
    static int[] snack, dp;
    static void Main()
    {
        N = int.Parse(Console.ReadLine());
        snack = new int[N]; dp = new int[N]; max = 0;
        for (int i = 0; i < N; i++)
            snack[i] = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
        {
            dp[i] = snack[i];
            for(int j = 0; j < i; j++)
            {
                if (snack[i] > snack[j] && dp[i] < dp[j] + snack[i]) dp[i] = dp[j] + snack[i];
            }
            max = dp[i] > max ? dp[i] : max;
        }
        Console.WriteLine(max);
    }
}