﻿using System;
using System.IO;
using System.Linq;
class Program
{
    static int N, index_max, index_min, tmp;
    static int[] Max = Enumerable.Repeat(int.MinValue, 100001).ToArray<int>();
    static int[] Min = Enumerable.Repeat(int.MaxValue, 100001).ToArray<int>();
    static BufferedStream bs = new BufferedStream(Console.OpenStandardOutput());
    static StreamWriter Speak = new StreamWriter(bs);
    static void Main()
    {
        index_max = 1; index_min = 1;
        N = int.Parse(Console.ReadLine());
        for(int i = 0; i < N; i++)
        {
            if (i % 2 == 0) MaxInsert(int.Parse(Console.ReadLine()));
            else MinInsert(int.Parse(Console.ReadLine()));
            Speak.WriteLine(Max[1]);
        }
        Speak.Close();
    }

    static void MaxInsert(int k)
    {
        if(Min[1] < k)
        {
            Max[index_max] = Min[1];
            MaxSortUp();
            Min[1] = k;
            MinSortDown();
        }
        else
        {
            Max[index_max] = k;
            MaxSortUp();
        }
        index_max++;
    }
    static void MaxSortUp()
    {
        for(int i = index_max; i > 1; i /= 2)
        {
            if (Max[i] > Max[i / 2])
            {
                tmp = Max[i];
                Max[i] = Max[i / 2];
                Max[i / 2] = tmp;
            }
            else break;
        }
    }
    static void MaxSortDown()
    {
        for(int i = 1; i <= index_max;)
        {
            if (Max[i] < Math.Max(Max[i * 2], Max[i * 2 + 1]))
            {
                i = Max[i * 2] > Max[i * 2 + 1] ? i * 2 : i * 2 + 1;
                tmp = Max[i / 2];
                Max[i / 2] = Max[i];
                Max[i] = tmp;
            }
            else break;
        }
    }
    static void MinInsert(int k)
    {
        if (Max[1] > k)
        {
            Min[index_min] = Max[1];
            MinSortUp();
            Max[1] = k;
            MaxSortDown();
        }
        else
        {
            Min[index_min] = k;
            MinSortUp();
        }
        index_min++;
    }
    static void MinSortUp()
    {
        for (int i = index_min; i > 1; i /= 2)
        {
            if (Min[i] < Min[i / 2])
            {
                tmp = Min[i];
                Min[i] = Min[i / 2];
                Min[i / 2] = tmp;
            }
            else break;
        }
    }
    static void MinSortDown()
    {
        for(int i = 1; i <= index_min;)
        {
            if (Min[i] > Math.Min(Min[i * 2], Min[i * 2 + 1]))
            {
                i = Min[i * 2] < Min[i * 2 + 1] ? i * 2 : i * 2 + 1;
                tmp = Min[i / 2];
                Min[i / 2] = Min[i];
                Min[i] = tmp;
            }
            else break;
        }
    }
}