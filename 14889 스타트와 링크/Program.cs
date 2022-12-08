using System;
using System.Collections.Generic;
class Program
{
    static int N, min;
    static int[] teamS, teamL;
    static int[,] stat;
    static Stack<int> team = new Stack<int>();
    static void Main()
    {
        N = int.Parse(Console.ReadLine());
        stat = new int[N, N];
        teamS = new int[N / 2];
        teamL = new int[N / 2];
        min = int.MaxValue;
        string[] input = new string[N];
        for (int i = 0; i < N; i++)
        {
            input = Console.ReadLine().Split();
            for(int j = 0; j < N; j++)
                stat[i, j] = int.Parse(input[j]);
        }
        for(int i = 0; i < N; i++)
        {
            for(int j = i + 1; j< N; j++)
                stat[i, j] += stat[j, i];
        }
        dfs();
        Console.WriteLine(min);
    }
    static void dfs()
    {
        /*
        if (team.Count == N / 2)
        {
            for (int i = 0; i < N / 2; i++)
            {
                teamS[i] = team.Pop();
            }
            Array.Sort(teamS);
            int s = 0; int l = 0;
            for (int i = 1; i <= N; i++)
            {
                if(s >= N / 2)
                {
                    teamL[l] = i;
                    l++;
                }
                else if (teamS[s] == i) s++;
                else
                {
                    teamL[l] = i;
                    l++;
                }
            }
            int S = 0; int L = 0;
            for (int i = 1; i < (N / 2) - 1; i++)
            {
                for (int j = i + 1; j < N / 2; j++)
                {
                    S += stat[teamS[i] - 1, teamS[j] - 1];
                    L += stat[teamL[i] - 1, teamL[j] - 1];
                }
            }
            int d = S > L ? S - L : L - S;
            min = min > d ? d : min;
            return;
        }
        */
        if (team.Count == 0)
        {
            for (int i = 1; i <= N / 2; i++)
            {
                team.Push(i);
                dfs();
            }
        }
        else
        {
            for (int i = team.Peek() + 1; i < N; i++)
            {
                team.Push(i);
                dfs();
            }
        }
    }
}