using System;
using System.Text;
class Program
{
    static int L, C, v;
    static char[] e;
    static string vowel = "aeiou";
    static StringBuilder crypto = new StringBuilder();
    static StringBuilder set = new StringBuilder();
    static void Main()
    {
        var lc = Console.ReadLine().Split();
        L = int.Parse(lc[0]); C = int.Parse(lc[1]);
        var letter = Console.ReadLine();
        e = new char[C];
        for (int i = 0; i < C; i++)
            e[i] = letter[i * 2];
        Array.Sort(e);
        Search(0, 0);
        Console.WriteLine(crypto);
    }
    static void Search(int index, int depth)
    {
        if (C - index + 1 < L - depth)
            return;
        if (depth == L)
        {
            v = 0;
            string search = set.ToString();
            for(int i = 0; i < 5; i++)
                if (search.Contains(vowel[i])) v++;
            if (v > 0 && L - v > 1) crypto.AppendLine(search);
            return;
        }
        for(int i = index; i < C; i++)
        {
            set.Append(e[i]);
            Search(i + 1, depth + 1);
            set.Remove(depth, 1);
        }
    }
}