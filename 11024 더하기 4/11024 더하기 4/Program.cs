using System;

class Program
{
    static int T, res;
    static void Main()
    {
        T = int.Parse(Console.ReadLine());
        for (int i = 0; i < T; i++)
        {
            res = 0;
            var N = Console.ReadLine().Split();
            foreach (string num in N)
                res += int.Parse(num);
            Console.WriteLine(res);
        }
    }
}