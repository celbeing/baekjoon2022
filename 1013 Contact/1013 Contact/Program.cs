using System;
using System.Text;
using System.Text.RegularExpressions;
class Program
{
    static int T;
    static Regex regex = new Regex("^(100+1+|01)+$");
    static void Main()
    {
        T = int.Parse(Console.ReadLine());
        for(int i = 0; i < T; i++)
        {
            Console.WriteLine(regex.IsMatch(Console.ReadLine()) ? "YES" : "NO");
        }
    }
}