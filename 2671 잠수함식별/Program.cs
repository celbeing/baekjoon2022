using System;
using System.Text.RegularExpressions;

class Program
{
    
    static void Main()
    {
        string pattern = "^(100+1+|01)+$";
        if (Regex.IsMatch(Console.ReadLine(), pattern)) Console.WriteLine("SUBMARINE");
        else Console.WriteLine("NOISE");
    }
}