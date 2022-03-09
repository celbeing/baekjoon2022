using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static int N;
    static List<List<int>> time1 = new List<List<int>>();
    static List<List<int>> time2 = new List<List<int>>();
    static void Main()
    {
        N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
        {
            var se = Console.ReadLine().Split();
            time1.Add(new List<int> { int.Parse(se[0]), int.Parse(se[1]) });
        }
        var tmp = time1.OrderBy(x => x[1]).OrderBy(x=>x[0]);
        foreach (var time in tmp)
            time2.Add(time);

        for (int i = 0; i < N; i++)
            Console.WriteLine(time2[i][0] + " " + time2[i][1]);
    }
}