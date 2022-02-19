using System;
using System.Linq;
// using System.Collections.Generic;
class Program
{
    static int N, count;
    static int[] row = Enumerable.Repeat(-1, 15).ToArray<int>();
    static bool safe;
    static void Main()
    {
        N = int.Parse(Console.ReadLine());
        Search(0);
        Console.WriteLine(count);
    }
    static void Search(int depth)
    {                                       // row[k]: k행에 퀸이 있는 칸의 번호
        if(depth == N)
        {
            count++;
            return;
        }
        for(int i = 0; i < N; i++)          // i: 현재 depth의 퀸을 두려고 하는 칸의 번호
        {
            safe = true;
            for (int j = 0; j < depth; j++)  // j: 퀸이 있는 행들
            {
                int dr = i + depth - j; int dl = i - depth + j;
                if (dr >= N) dr = i;    if (dl < 0) dl = i;
                if (row[j] == i || row[j] == dr || row[j] == dl)
                {
                    safe = false;
                    break;
                }
            }
            if (safe)
            {
                row[depth] = i;
                Search(depth + 1);
                row[depth] = -1;
            }
        }
    }
}