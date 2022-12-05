using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static int tc;
    static int[] sieve = new int[1000001];
    static List<int> prime = new List<int>();
    static BufferedStream bs = new BufferedStream(Console.OpenStandardOutput());
    static StreamWriter results = new StreamWriter(bs);
    static void Main()
    {
        for(int i = 2; i <= 1000000; i++)
        {
            if(sieve[i] == 0)
            {
                prime.Add(i);
                for (int j = i; j <= 1000000; j += i)
                    sieve[j] = 1;
            }
        }
        /*
        prime.Add(2);
        for(int i = 3; i <= 1000000; i++)
        {
            for(int j = 0; j < prime.Count; j++)
            {
                if (prime[j] * prime[j] > i)
                {
                    prime.Add(i);
                    break;
                }
                else if (i % prime[j] == 0) break;
            }
        }
        */
        while (true)
        {
            tc = int.Parse(Console.ReadLine());
            if (tc == 0)
            {
                results.Close();
                return;
            }
            for(int i = 0; i < prime.Count; i++)
            {
                if (prime.Contains(tc - prime[i]))
                {
                    results.WriteLine($"{tc} = {prime[i]} + {tc - prime[i]}");
                    break;
                }
                if (prime[i] >= tc)
                {
                    results.WriteLine("Goldbach's conjecture is wrong.");
                    break;
                }
            }
        }
    }
}