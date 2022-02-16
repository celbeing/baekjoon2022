using System;
using System.Text;
class Program
{
    static int res = 0;
    static string input;
    static StringBuilder S = new StringBuilder();
    static void Main()
    {
        while (true)
        {
            input = Console.ReadLine();
            if (input == null) break;
            S.Append(input);
        }
        var num = S.ToString().Split(',');
        foreach (string s in num)
            res += int.Parse(s);
        Console.WriteLine(res);
    }
}