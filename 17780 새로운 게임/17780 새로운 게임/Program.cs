using System;
class Program
{
    static int n, k;    // 4<=N<=12 // 4<=K<=10
    static void Main()
    {
        var nk = Console.ReadLine().Split();
        n = int.Parse(nk[0]);
        k = int.Parse(nk[1]);
        int[,] board = new int[n, n];
        int[,,]
        for(int i = 0; i < n; i++)
        {
            var row = Console.ReadLine().Split();
            for(int j = 0; j < n; j++)
            {
                board[i, j] = int.Parse(row[j]);
            }
        }
        for(int i = 0; i < k; i++)
        {

        }
    }
}