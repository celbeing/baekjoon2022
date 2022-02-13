using System;
using System.Linq;
using System.Collections.Generic;
class Program
{
    static int n, target, m, x, y;
    static int[] check = Enumerable.Repeat(100, 100).ToArray<int>();
    static int[,] genogram = new int[100, 100];
    static Queue<int> BFS = new Queue<int>();
    static void Main()
    {
        n = int.Parse(Console.ReadLine());
        var who = Console.ReadLine().Split();
        BFS.Enqueue(int.Parse(who[0]) - 1); target = int.Parse(who[1]) - 1;
        check[BFS.Peek()] = 0;
        m = int.Parse(Console.ReadLine());
        for(int i = 0; i < m; i++)
        {
            var rel = Console.ReadLine().Split();
            x = int.Parse(rel[0]) - 1; y = int.Parse(rel[1]) - 1;
            genogram[x, y] = 1; genogram[y, x] = 1;
        }
        while (BFS.Count > 0)
        {
            x = BFS.Dequeue();
            if (x == target) break;
            for(int i = 0; i < n; i++)
            {
                if(genogram[x,i] == 1 && check[i] == 100)
                {
                    BFS.Enqueue(i);
                    check[i] = check[x] + 1;
                }
            }
        }
        Console.WriteLine(check[target] == 100 ? -1 : check[target]);
    }
}