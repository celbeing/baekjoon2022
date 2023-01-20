using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static int N, xlast, xcnt;
    static double area;
    static int[] vertical = new int[20000];
    static List<int[]> map = new List<int[]>();
    static void Main()
    {
        N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
        {
            double[] rect = Console.ReadLine().Split().Select(double.Parse).ToArray();
            int[] left = { (int)(rect[0] * 10), (int)(rect[1] * 10), (int)((rect[1] + rect[3]) * 10), 1 };
            int[] right = { (int)((rect[0] + rect[2]) * 10), (int)(rect[1] * 10), (int)((rect[1] + rect[3]) * 10), -1 };
            map.Add(left); map.Add(right);
        }
        List<int[]> sweep = (from rect in map
                             orderby rect[0]
                             select rect).ToList();
        int vcount = 0;
        for(int i = 0; i < sweep.Count;)
        {
            xcnt = sweep[i][0];
            area += vcount * (xcnt - xlast);
            xlast = xcnt;
            do
            {
                for (int j = sweep[i][1]; j < sweep[i][2]; j++)
                    vertical[j] += sweep[i][3];
                i++;
            } while (i < sweep.Count && sweep[i][0] == sweep[i - 1][0]);
            vcount = 0;
            for (int j = 0; j < 20000; j++)
                if (vertical[j] > 0) vcount++;
        }
        xcnt = sweep[sweep.Count - 1][0];
        area += vcount * (xcnt - xlast);
        area *= 0.01;
        if (area % 1 == 0) Console.WriteLine(area);
        else Console.WriteLine(area.ToString("0.00"));
    }
}