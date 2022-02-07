using System;
class Program
{
    static int N, K;
    static int div = 10007;
    static void Main()
    {
        var nk = Console.ReadLine().Split();
        N = int.Parse(nk[0]); K = int.Parse(nk[1]);
        Console.WriteLine(Fac(N) * Pow(Fac(N - K) * Fac(K) % div, div - 2) % div);
    }
    static int Fac(int f)
    {
        if (f < 2) return 1;
        else return f * Fac(f - 1) % div;
    }
    static int Pow(int b, int e)
    {
        int res = 1;
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