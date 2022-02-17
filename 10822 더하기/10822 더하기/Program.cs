using System;

class Program
{
    static int res = 0;
    static void Main()
    {
        var s = Console.ReadLine().Split(',');
        foreach(string n in s)
            res += int.Parse(n);
        Console.WriteLine(res);
    }
}