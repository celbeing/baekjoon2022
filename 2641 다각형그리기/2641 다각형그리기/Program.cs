using System;
using System.Text;
class Program
{
    static int L, T, count;
    static StringBuilder result = new StringBuilder();
    static void Main()
    {
        L = int.Parse(Console.ReadLine());
        int[] sample = new int[L];
        string[] input = new string[L];
        input = Console.ReadLine().Split();
        for (int i = 0; i < L; i++) sample[i] = int.Parse(input[i]);
        T = int.Parse(Console.ReadLine());
        int[,] cases = new int[T, L];
        for (int i = 0; i < T; i++)
        {
            input = Console.ReadLine().Split();
            for (int j = 0; j < L; j++) cases[i, j] = int.Parse(input[j]);
            for (int j = 0; j < L; j++)
            {
                int k = cases[i, 0];
                for (int l = 0; l < L - 1; l++)
                    cases[i, l] = cases[i, l + 1];
                cases[i, L - 1] = k;
                if (check(sample, cases, i))
                {
                    count++;
                    for (int l = 0; l < L - 1; l++)
                        result.Append($"{input[l]} ");
                    result.Append($"{input[L - 1]}\n");
                }
            }
        }
        if(count == 0)
        {
            Console.WriteLine(0);
            return;
        }
        result.Remove(result.Length - 1, 1);
        Console.WriteLine(count);
        Console.WriteLine(result.ToString());
    }
    static bool check(int[] sample, int[,] cases, int t)
    {
        for (int i = 0; i < L; i++)
            if (sample[i] != cases[t, i]) goto reverse;
        return true;
    reverse:
        int[] reverse = new int[L];
        for(int i = 0; i < L; i++)
        {
            switch(cases[t, L - i - 1])
            {
                case 1:
                    reverse[i] = 3;
                    break;
                case 2:
                    reverse[i] = 4;
                    break;
                case 3:
                    reverse[i] = 1;
                    break;
                default:
                    reverse[i] = 2;
                    break;
            }
        }
        for (int i = 0; i < L; i++)
            if (sample[i] != reverse[i]) return false;
        return true;
    }
}