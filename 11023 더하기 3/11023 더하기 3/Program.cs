using System;

class Program
{
    static int res;
    static void Main()
    {
        var N = Console.ReadLine().Split();
        foreach (string num in N)
            res += int.Parse(num);
        Console.WriteLine(res);
    }
}