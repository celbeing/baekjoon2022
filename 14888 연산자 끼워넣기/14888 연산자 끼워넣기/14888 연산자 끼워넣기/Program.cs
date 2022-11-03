using System;
class Program
{
    static int N, max, min;
    static string str;
    static int[] A = new int[11];
    static int[] operators = new int[4];
    static void Main()
    {
        min = int.MaxValue;
        max = int.MinValue;
        N = int.Parse(Console.ReadLine());
        str = Console.ReadLine();
        for (int i = 0; i < N; i++)
        {
            A[i] = int.Parse(str.Split()[i]);
        }
        str = Console.ReadLine();
        for(int i = 0; i < 4; i++)
        {
            operators[i] = int.Parse(str.Split()[i]);
        }
        DFS(A[0], 1);
        Console.WriteLine(max);
        Console.WriteLine(min);
    }
    static void DFS(int cal, int depth)
    {
        if (depth == N)
        {
            if (cal > max) max = cal;
            if (cal < min) min = cal;
            return;
        }
        for(int i = 0; i < 4; i++)
        {
            if(operators[i] > 0)
            {
                operators[i]--;
                if (i == 0)
                    DFS(cal + A[depth], depth + 1);
                if (i == 1)
                    DFS(cal - A[depth], depth + 1);
                if (i == 2)
                    DFS(cal * A[depth], depth + 1);
                if (i == 3)
                    DFS(cal / A[depth], depth + 1);
                operators[i]++;
            }
        }
    }
}