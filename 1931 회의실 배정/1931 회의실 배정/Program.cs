using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static int N, end, count;
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
        var tmp = time1.OrderBy(x => x[0]).OrderBy(x=>x[1]);
        foreach (var time in tmp)
            time2.Add(time);
        for(int i = 0; i < N; i++)
        {
            if(time2[i][0] >= end)
            {
                count++;
                end = time2[i][1];
            }
        }
        Console.WriteLine(count);
    }
}