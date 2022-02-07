using System;
class Program
{
    static int T, N;
    static ulong div = 1000000007;
    static void Main()
    {
        T = int.Parse(Console.ReadLine());
        for(int i = 0; i < T; i++)
        {
            N = int.Parse(Console.ReadLine());
            Console.WriteLine(Power(2, N - 2) % div);
        }
    }
    static ulong Power(ulong a, int n)
    {
        ulong res = 1;
        while(n > 0)
        {
            if(n % 2 == 1)
            {
                res *= a;
                res %= div;
                n--;
            }
            a *= a;
            a %= div;
            n >>= 1;
        }
        return res;
    }
}