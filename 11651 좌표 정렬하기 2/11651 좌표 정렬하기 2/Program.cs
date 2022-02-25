using System;
using System.Text;
using System.Collections.Generic;
class Pragram
{
    static int N, x, y;
    static void Main()
    {
        N = int.Parse(Console.ReadLine());
        var X = new int[N]; var Y = new int[N];
        var xy = new string[2];
        for(int i = 0; i < N; i++)
        {
            xy = Console.ReadLine().Split();
            X[i] = int.Parse(xy[0]);
            Y[i] = int.Parse(xy[1]);
        }
        for(int i = 0; i < N; i++)
        {

        }
    }
    static void QuickSort(int p)
    // 퀵소트 공부부터 하고오자
    {
        int i = 0; int j = p - 1;
        while(i <= j)
        {

        }
    }
}