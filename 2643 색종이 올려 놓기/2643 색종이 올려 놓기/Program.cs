using System;

class Program
{
    static int N;
    static string[] input = new string[2];
    static void Main()
    {
        N = int.Parse(Console.ReadLine());
        int[,] paper = new int[N, 2];
        for(int i = 0; i < N; i++)
        {
            input = Console.ReadLine().Split();
            paper[i, 0] = int.Parse(input[0]);
            paper[i, 1] = int.Parse(input[1]);
        }
    }
}