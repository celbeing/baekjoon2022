using System;
class Program
{
    static int N, K;
    static int div = 1000000007;
    static long[] fac = new long[4000001];
    static long[] inv = new long[4000001];
    static void Main()
    {
        fac[1] = 1;
        for(int i = 2; i <= 4000000; i++)
            fac[i] = fac[i - 1] * i % div;
        inv[4000000] = (int)Pow(fac[4000000], div - 2);
        for (int i = 3999999; i >= 0; i--)
            inv[i] = inv[i + 1] * (i + 1) % div;
        var nk = Console.ReadLine().Split();
        N = int.Parse(nk[0]); K = int.Parse(nk[1]);
        Console.WriteLine((fac[N] * inv[N - K] % div) * inv[K] % div);
    }
    static long Pow(long b, int e)
    {
        long res = 1;
        while (e > 0)
        {
            if (e % 2 == 1)
            {
                res *= b;
                res %= div;
                e--;
            }
            b *= b;
            b %= div;
            e >>= 1;
        }
        return res;
    }
}