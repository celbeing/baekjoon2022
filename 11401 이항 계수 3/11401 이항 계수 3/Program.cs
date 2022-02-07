using System;
using System.Numerics;
class Program
{
    static int N, K;
    static BigInteger bc = new BigInteger();
    static void Main()
    {
        var nk = Console.ReadLine().Split();
        N = int.Parse(nk[0]);
        K = int.Parse(nk[1]);
        bc = 1;
        if (N < K * 2) K = N - K;
        for(int i = N - K; i <= N; i++)
        {
            bc *= i;
        }
        bc /= N - K;
        for(int i = 1; i <= K; i++)
        {
            bc /= i;
        }
        Console.WriteLine(bc);
    }
}