using System;
using System.Text;
using System.Collections.Generic;
class Pragram
{
    static int N, x, y;
    static List<(int, int)> coordinate = new List<(int, int)>();
    static void Main()
    {
        N = int.Parse(Console.ReadLine());
        var sb = new StringBuilder();
        var res = new StringBuilder();
        for (int i = 0; i < N; i++)
        {
            var xy = Console.ReadLine().Split();
            x = int.Parse(xy[0]); y = int.Parse(xy[1]);
            coordinate.Add((y,x));
            coordinate.Sort();
        }
        for(int i = 0; i < N; i++)
        {
            sb.Append(coordinate[i]);
            sb.Replace("(",""); sb.Replace(")", ""); sb.Replace(",", "");
            var xy = sb.ToString().Split();
            res.AppendLine(xy[1] + " " + xy[0]);
            sb.Clear();
        }
        Console.WriteLine(res);
    }
}