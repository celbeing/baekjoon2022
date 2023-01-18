using System;

class Program
{
    static int N;
    static double max;
    static double[] dp;
    static void Main()
    {
        N = int.Parse(Console.ReadLine());
        dp = new double[N];
        dp[0] = double.Parse(Console.ReadLine());
        max = dp[0];
        for(int i = 1; i < N; i++)
        {
            double z = double.Parse(Console.ReadLine());
            dp[i] = Math.Max(dp[i - 1] * z, z);
            max = Math.Max(max, dp[i]);
        }
        Console.WriteLine(max.ToString("0.000"));
    }
}