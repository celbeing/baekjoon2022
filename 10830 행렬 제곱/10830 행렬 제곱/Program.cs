using System;
class Program
{
    static int N;
    static long B;
    static void Main()
    {
        var nb = Console.ReadLine().Split();
        N = int.Parse(nb[0]); B = long.Parse(nb[1]);
        int[,] matr = new int[N, N];
        int[,] mato = new int[N, N];
        for(int i = 0; i < N; i++)
        {
            var row = Console.ReadLine().Split();
            for(int j= 0; j < N; j++)
            {
                mato[i, j] = int.Parse(row[j]);
            }
            matr[i, i] = 1;
        }
        while (B > 0)
        {
            if(B % 2 == 1)
            {
                matr = Multiply(matr, mato);
                B--;
            }
            mato = Multiply(mato, mato);
            B >>= 1;
        }
        for(int i = 0; i< N; i++)
        {
            for(int j = 0; j < N; j++)
            {
                Console.Write(matr[i, j] + " ");
            }
            Console.Write("\n");
        }
    }
    static int[,] Multiply(int[,] mat1, int[,] mat2)
    {
        int[,] res = new int[N, N];
        for(int i = 0; i < N; i++)
        {
            for(int j = 0; j < N; j++)
            {
                for(int k = 0; k < N; k++)
                {
                    res[i, j] += mat1[i, k] * mat2[k, j];
                }
                res[i, j] %= 1000;
            }
        }
        return res;
    }
}