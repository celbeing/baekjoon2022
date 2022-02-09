using System;
class Program
{
    static int T, h, w;
    static void Main()
    {
        T = int.Parse(Console.ReadLine());
        for(int i = 0; i < T; i++)
        {
            Case();
        }
    }
    static void Case()
    {
        var hw = Console.ReadLine().Split();
        h = int.Parse(hw[0]); w = int.Parse(hw[1]);
        char[,] jail = new char[h, w];
        bool[,] check = new bool[h, w];
        for(int i = 0; i < h; i++)
        {
            string row = Console.ReadLine();
            for (int j = 0; j < w; j++)
                jail[i, j] = row[j];
        }
    }
}