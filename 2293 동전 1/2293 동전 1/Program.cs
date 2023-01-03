using System;
class Program
{
    static int n, k;
    static string[] input;
    static uint[] dp = new uint[100001];
    static void Main()
    {
        input = Console.ReadLine().Split();
        n = int.Parse(input[0]);
        k = int.Parse(input[1]);
        dp[0] = 1;
        for (int i = 0; i < n; i++)
        {
            int j = int.Parse(Console.ReadLine());
            for(int l = j; l <= k; l++)
            {
                dp[l] += dp[l - j];
            }

        }
        Console.WriteLine(dp[k]);
    }
}