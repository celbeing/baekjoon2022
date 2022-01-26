using System;
using System.Text;
using System.Collections.Generic;
class Program
{
    static int N, x, y;
    static StringBuilder result = new StringBuilder();
    static List<(int, int)> coordinate = new List<(int, int)>();
    static void Main()
    {
        N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
        {
            var xy = Console.ReadLine().Split();
            coordinate.Add((int.Parse(xy[0]), int.Parse(xy[1])));
        }
        coordinate.Sort();
        for(int i = 0; i < N; i++)
        {
            result.AppendLine(coordinate[i].ToString());
        }
        result.Replace("(", "");
        result.Replace(")", "");
        result.Replace(",", "");
        Console.WriteLine(result);
    }
}