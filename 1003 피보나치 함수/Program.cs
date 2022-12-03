using System;
using System.IO;
class Program
{
    static int T, cases;
    static int[] fib0 = new int[41];
    static int[] fib1 = new int[41];
    static BufferedStream fibonacci = new BufferedStream(Console.OpenStandardOutput());
    static StreamWriter results = new StreamWriter(fibonacci);
    static void Main()
    {
        fib0[0] = 1; fib0[1] = 0;
        fib1[0] = 0; fib1[1] = 1;
        for(int i = 2; i < 41; i++)
        {
            fib0[i] = fib0[i - 1] + fib0[i - 2];
            fib1[i] = fib1[i - 1] + fib1[i - 2];
        }
        T = int.Parse(Console.ReadLine());
        for(int i = 0; i < T; i++)
        {
            cases = int.Parse(Console.ReadLine());
            results.WriteLine($"{fib0[cases]} {fib1[cases]}");
        }
        results.Close();
    }
}