using System;
using System.Collections.Generic;
class Program
{
    static string[] input;
    static int[] clock = new int[5];
    static bool[] check = new bool[10000];
    static List<int> clockNumbers = new List<int>();
    static void Main()
    {
        input = Console.ReadLine().Split();
        for(int i = 0; i < 4; i++)
        {
            clock[1] *= 10;
            clock[1] += int.Parse(input[i]);
        }
        for(int i = 0; i < 3; i++)
            clock[2 + i] = (clock[1 + i] % 1000) * 10 + clock[1 + i] / 1000;
        clock[0] = Math.Min(Math.Min(clock[1], clock[2]), Math.Min(clock[3], clock[4]));
        for(int i = 1111; i < 10000; i++)
        {
            if (check[i]) continue;
            if ($"{i}".Contains('0')) continue;
            clockNumbers.Add(i);
            int cnt = i;
            for(int j = 0; j < 3; j++)
            {
                cnt = (cnt % 1000) * 10 + cnt / 1000;
                check[cnt] = true;
            }
        }
        Console.WriteLine(clockNumbers.IndexOf(clock[0]) + 1);
    }
}