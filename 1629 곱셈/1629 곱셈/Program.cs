using System;
class Program
{
    static long A;
    static int B, C;
    static long res = 1;

    static void Main()
    {
        var ABC = Console.ReadLine().Split();
        A = long.Parse(ABC[0]);
        B = int.Parse(ABC[1]);
        C = int.Parse(ABC[2]);
        while (B > 0)
        {
            if (B % 2 == 1)
            {
                res *= A;
                res %= C;
                B--;
            }
            A *= A;
            A %= C;
            B >>= 1;
        }
        Console.WriteLine(res);
    }
}