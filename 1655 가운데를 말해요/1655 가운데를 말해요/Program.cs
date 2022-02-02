using System;
class Program
{
    static int N, Index_max, Index_min, change, tmp;
    static int[] Max = new int[50001];  // 가장 큰 값이 1번으로 오는 최대 힙
    static int[] Min = new int[50001];  // 가장 작은 값이 1번으로 오는 최소 힙
    static void Main()
    {
        Index_max = 1; Index_min = 1;
        N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
        {
            if (i % 2 == 0)
            {
                Max_Heap(int.Parse(Console.ReadLine()));
                Top_Change();
            }
            else
            {
                Min_Heap(int.Parse(Console.ReadLine()));
                Top_Change();
            }
            Console.WriteLine(Max[1]);
        }
    }
    static void Top_Change()            // 힙 1번 값을 비교하고 최대힙>최소힙 이면 서로 바꿔서 정렬 다시하기
    {
        if (Index_min == 1 || Index_max == 1) return;
        if (Max[1] > Min[1])
        {
            tmp = Max[1];
            Index_max--;
            Max_Heap(Min[1]);
            Index_min--;
            Min_Heap(tmp);
        }
    }
    static void Max_Heap(int k)         // 최대 힙에 k를 추가하고 정렬
    {
        Max[Index_max] = k;
        for(int i = Index_max; i >1; i /= 2)
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
        Max[Index_min] = k;
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
}