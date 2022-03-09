using System;
class Program
{
    static int N, M, count, index, length;
    static void Main()
    {
        var nm = Console.ReadLine().Split();
        N = int.Parse(nm[0]); M = int.Parse(nm[1]);
        var m = Console.ReadLine().Split();
        var num = new int[M];
        for (int i = 0; i < M; i++)
            num[i] = int.Parse(m[i]);
        count = 0;
        length = N;
        index = 1;
        int a, b;
        for(int i = 0; i < M; i++)
        {
            if (index < num[i])
            {
                a = num[i] - index;
                b = length - num[i] + index;
                count += Math.Min(a, b);
            }
            else if (index > num[i])
            {
                a = index - num[i];
                b = length - index + num[i];
                count += Math.Min(a, b);
            }
            length--;
            index = num[i];
            for (int j = i + 1; j < M; j++)
                if (index < num[j]) num[j]--;
            if (index > length) index = 1;
        }
        Console.WriteLine(count);
    }
}