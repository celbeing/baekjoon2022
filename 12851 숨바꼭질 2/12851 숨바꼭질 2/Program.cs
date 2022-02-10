using System;
using System.Linq;
using System.Collections.Generic;
class Program
{
    static int N, K, S;
    static int[] count = new int[100002];
    static int[] time = Enumerable.Repeat(-1, 100002).ToArray<int>();
    static Queue<int> BFS = new Queue<int>();
    static void Main()
    {
        var nk = Console.ReadLine().Split();
        N = int.Parse(nk[0]);K = int.Parse(nk[1]);
        if (N == K) Console.WriteLine("0\n1");
        else if (N > K) Console.WriteLine($"{N - K}\n1");
        else
        {
            BFS.Enqueue(N);
            time[N] = 0;
            count[N] = 1;
            while (BFS.Count > 0)
            {
                S = BFS.Dequeue();
                int[] d = { -1, 1, S };                             // -1, +1, *2
                for (int i = 0; i < 3; i++)
                {
                    if (S + d[i] < 0 || S + d[i] > K + 1) continue; // 생각 안해도 되는 경우들 0 미만의 index,
                                                                    // K를 넘어가버리면 무조건 시간 손해
                    if (time[S + d[i]] != -1)                       // 왔던 곳이면
                        if (time[S] + 1 == time[S + d[i]]) count[S + d[i]] += count[S]; else { }
                                                                    // 시간 같으면 가짓수 더해주기
                    else
                    {                                               // 처음 왔으면
                        time[S + d[i]] = time[S] + 1;               // 시간 더해주기
                        count[S + d[i]] = count[S];                 // 가짓수 가져오기
                        BFS.Enqueue(S + d[i]);                      // 큐에 추가
                    }                                               // 왔던 곳은 큐에 추가 안하기 때문에
                }                                                   // K에 처음 도착할 때만 K 이후를 탐색하고
            }                                                       // 탐색 끝남
            Console.WriteLine(time[K]);
            Console.WriteLine(count[K]);
        }
    }
}