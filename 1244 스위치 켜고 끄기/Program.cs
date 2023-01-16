using System;

class Program
{
    static int N, S, flag;
    static string[] switchin, input;
    static void Main()
    {
        N = int.Parse(Console.ReadLine());
        bool[] sw = new bool[N];
        switchin = Console.ReadLine().Split();
        for (int i = 0; i < N; i++)
            sw[i] = (switchin[i] == "0") ? false : true;
        S = int.Parse(Console.ReadLine());
        for (int i = 0; i < S; i++)
        {
            input = Console.ReadLine().Split();
            if (input[0] == "1")
            {
                flag = int.Parse(input[1]);
                for (int j = flag; j <= N; j += flag)
                    sw[j - 1] = (sw[j - 1]) ? false : true;
            }
            else
            {
                flag = int.Parse(input[1]) - 1;
                sw[flag] = (sw[flag]) ? false : true;
                for (int j = 1; flag - j >= 0 && flag + j < N; j++)
                    if (sw[flag - j] == sw[flag + j])
                    {
                        sw[flag - j] = sw[flag - j] ? false : true;
                        sw[flag + j] = sw[flag + j] ? false : true;
                    }
                    else break;
            }
        }
        for (int i = 0; i < N - 1; i++)
            if (i % 20 == 19)
                Console.Write($"{Convert.ToInt32(sw[i])}\n");
            else Console.Write($"{Convert.ToInt32(sw[i])} ");
        Console.Write(Convert.ToInt32(sw[N - 1]));
    }
}