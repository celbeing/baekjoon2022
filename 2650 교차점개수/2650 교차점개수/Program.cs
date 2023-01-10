using System;

class Program
{
    static int dot, sum, max;
    static string[] strI = new string[4];
    static int[] intI = new int[4];
    static void Main()
    {
        dot = int.Parse(Console.ReadLine());
        int[,] dots = new int[dot / 2, 2];
        int[] meets = new int[dot / 2];
        for (int i = 0; i < dot / 2; i++)
        {
            // 1: top, 2: bottom, 3: left, 4: right
            strI = Console.ReadLine().Split();
            for (int j = 0; j < 4; j++) intI[j] = int.Parse(strI[j]);
            int k;
            switch (intI[0])
            {
                case 1:
                    k = 0;
                    break;
                case 2:
                    k = -150;
                    break;
                case 3:
                    k = -200;
                    break;
                default:
                    k = 50;
                    break;
            }
            dots[i, 0] = intI[1] + k;
            switch (intI[2])
            {
                case 1:
                    k = 0;
                    break;
                case 2:
                    k = -150;
                    break;
                case 3:
                    k = -200;
                    break;
                default:
                    k = 50;
                    break;
            }
            dots[i, 1] = intI[3] + k;
            if (dots[i, 0] < 0) dots[i, 0] *= -1;
            if (dots[i, 1] < 0) dots[i, 1] *= -1;
            if (dots[i, 0] > dots[i, 1])
            {
                k = dots[i, 0];
                dots[i, 0] = dots[i, 1];
                dots[i, 1] = k;
            }
        }
        for(int i = 0; i < dot/2; i++)
        {
            for(int j = 0; j < dot/2; j++)
            {
                if (i == j) continue;
                if ((dots[i, 0] < dots[j, 0] && dots[j, 0] < dots[i, 1]) ^ (dots[i, 0] < dots[j, 1] && dots[j, 1] < dots[i, 1])) meets[i]++;
            }
            sum += meets[i];
            if (max < meets[i]) max = meets[i];
        }
        Console.WriteLine(sum / 2);
        Console.WriteLine(max);
    }
}