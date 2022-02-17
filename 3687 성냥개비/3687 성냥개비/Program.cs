using System;
using System.Text;

class Program
{
    static int T, n;
    static long[] num = { 1, 7, 4, 2, 0, 8 };
    static long[] small = new long[101];
    static StringBuilder large;
    static void Main()
    {
        T = int.Parse(Console.ReadLine());
        large = new StringBuilder();
        for(int i = 0; i < T; i++)
        {
            n = int.Parse(Console.ReadLine());
            for (int j = 2; j <= n; j++) small[j] = long.MaxValue;
            small[2] = 1; small[3] = 7; small[4] = 4;
            small[5] = 2; small[6] = 6; small[7] = 8;
            for (int j = 8; j <= n; j++)
            {
                for (int k = 2; k <= 7; k++)
                {
                    if (j - k < 2) continue;
                    if (small[j] > small[j - k] * 10 + num[k - 2]) small[j] = small[j - k] * 10 + num[k - 2];
                }
            }
            large.Append(small[n]);
            large.Append(" ");
            if (n % 2 == 0) large.Append("1");
            else large.Append('7');
            large.Append('1', (n / 2) - 1);
            Console.WriteLine(large);
            large.Clear();
        }
    }
}