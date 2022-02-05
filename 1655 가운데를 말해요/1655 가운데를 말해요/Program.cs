﻿using System;
class Program
{
    static int N, Index_max, Index_min, change, tmp;
    static int[] Max = new int[50001];  // 가장 큰 값이 1번으로 오는 최대 힙
    static int[] Min = new int[50001];  // 가장 작은 값이 1번으로 오는 최소 힙
    static void Main()
    {
        Index_max = 2; Index_min = 2;
        N = int.Parse(Console.ReadLine());
        Max[1] = int.Parse(Console.ReadLine());
        Console.WriteLine(Max[1]);
        if (N > 1)
        {
            Min[1] = int.Parse(Console.ReadLine());
            if(Max[1] > Min[1])
            {
                change = Max[1];
                Max[1] = Min[1];
                Min[1] = change;
            }
            Console.WriteLine(Max[1]);
        }
        for (int i = 2; i < N; i++)
        {
            if (i % 2 == 0)
            {
                Max_Heap(int.Parse(Console.ReadLine()));
            }
            else
            {
                Min_Heap(int.Parse(Console.ReadLine()));
            }
            Console.WriteLine($"{Index_max} {Max[5]} {Max[4]} {Max[3]} {Max[2]} {Max[1]} {Min[1]} {Min[2]} {Min[3]} {Min[4]} {Min[5]} {Index_min}");
        }
    }
    static void Top_Change()            // 힙 1번 값을 비교하고 최대힙>최소힙 이면 서로 바꿔서 정렬 다시하기
    {
        if (Index_min == 1 || Index_max == 1) return;
        if (Max[1] > Min[1])
        {
            tmp = Max[1];
            Index_max--;        // 여기 정렬 안함
            Max_Heap(Min[1]);
            Index_min--;
            Min_Heap(tmp);
        }
    }
    static void Max_Heap(int k)         // 최대 힙에 k를 추가하고 정렬
    {
        if (k > Min[1])
        {
            Max[Index_max] = Min[1];
            Index_min--;
            Push(Min, Index_min);
            Min_Heap(k);
        }
        else
        {
            Max[Index_max] = k;
        }
        for (int i = Index_max; i > 1; i /= 2)
        {
            if (Max[i / 2] < Max[i])
            {
                change = Max[i];
                Max[i] = Max[i / 2];
                Max[i / 2] = change;
            }
            else break;
        }
        Index_max++;
    }
    static void Min_Heap(int k)         // 최소 힙에 k를 추가하고 정렬
    {
        if(k < Max[1])
        {
            Min[Index_min] = Max[1];
            Index_max--;
            Push(Max, Index_max);
            Max_Heap(k);
        }
        else
        {
            Min[Index_min] = k;
        }
        for (int i = Index_min; i > 1; i /= 2)
        {
            if (Min[i / 2] > Min[i])
            {
                change = Min[i];
                Min[i] = Min[i / 2];
                Min[i / 2] = change;
            }
            else break;
        }
        Index_min++;
    }
    static void Push(int[] Heap, int Index)
    {
        for(int i = 1; i < Index; i++)
        {
            Heap[i] = Heap[i + 1];
        }
    }
}