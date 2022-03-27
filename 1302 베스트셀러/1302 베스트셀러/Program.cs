using System;
using System.Collections.Generic;
class Program
{
    static int N, max, count, bestseller;
    static List<string> sales = new List<string>();
    static void Main()
    {
        N = int.Parse(Console.ReadLine());
        count = 1; bestseller = 0;
        for (int i = 0; i < N; i++)
            sales.Add(Console.ReadLine());
        sales.Sort();
        for (int i = 0; i < N - 1; i++)
        {
            if (sales[i] == sales[i + 1])
            {
                count++;
                if (count > max)
                {
                    bestseller = i;
                    max = count;
                }
            }
            else
            {
                count = 1;
            }
        }
        Console.WriteLine(sales[bestseller]);
    }
}