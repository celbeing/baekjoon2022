using System;
using System.Text.RegularExpressions;
class Program
{
    static int T;
    static Regex regex = new Regex("^(100+1+|01)+$");
    // ^: 문자열 시작부분
    // $: 문자열 끝부분
    static void Main()
    {
        T = int.Parse(Console.ReadLine());
        for(int i = 0; i < T; i++)
        {
            Console.WriteLine(regex.IsMatch(Console.ReadLine()) ? "YES" : "NO");
        }
    }
}