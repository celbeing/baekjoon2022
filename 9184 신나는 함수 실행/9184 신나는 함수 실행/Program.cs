using System;
class Program
{
    static int a, b, c;
    static int[,,] w = new int[21, 21, 21];
    static void Main()
    {
        for(int i = 0; i < 21; i++)
        {
            for(int j = 0; j < 21; j++)
            {
                for (int k = 0; k < 21; k++)
                    w[i, j, k] = int.MaxValue;
            }
        }
        while (true)
        {
            var abc = Console.ReadLine().Split();
            a = int.Parse(abc[0]); b = int.Parse(abc[1]); c = int.Parse(abc[2]);
            if (a == -1 && a == b && b == c) break;
            Output(W(a, b, c));
        }
    }
    static int W(int a, int b, int c)
    {
        if (a <= 0 || b <= 0 || c <= 0) return 1;
        else if (a > 20 || b > 20 || c > 20) return W(20, 20, 20);
        else if (a < b && b < c)
        {
            if (w[a, b, c] == int.MaxValue)
            {
                w[a, b, c] = W(a, b, c - 1) + W(a, b - 1, c - 1) - W(a, b - 1, c);
                return W(a, b, c - 1) + W(a, b - 1, c - 1) - W(a, b - 1, c);
            }
            else return w[a, b, c];
        }
        else
        {
            if (w[a, b, c] == int.MaxValue)
            {
                w[a, b, c] = W(a - 1, b, c) + W(a - 1, b - 1, c) + W(a - 1, b, c - 1) - W(a - 1, b - 1, c - 1);
                return W(a - 1, b, c) + W(a - 1, b - 1, c) + W(a - 1, b, c - 1) - W(a - 1, b - 1, c - 1);
            }
            else return w[a, b, c];
        }
    }
    static void Output(int res)
    {
        Console.WriteLine($"w({a}, {b}, {c}) = {res}");
    }
}