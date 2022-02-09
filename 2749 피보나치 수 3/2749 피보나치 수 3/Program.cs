using System;
class Program
{
    static int n;
    static int[] fib = new int[1500001];
    static void Main()
    {
        fib[0] = 0;
        n = (int)(long.Parse(Console.ReadLine()) % 1500000);
        for(int i = 1; i <= 1500000; i++)
        {
            fib[i] = fibonacci(fib, i);
        }
        Console.Write(fib[n]);
    }
    static int fibonacci(int[] num, int i)
    {
        if (i > 1)
            return (num[i - 1] + num[i - 2])%1000000;
        else return 1;
    }
}
/* 일단 쉬운 풀이(꼼수?) 피사노 주기를 써서 풀긴 했는데
 * 분할정복을 통한 빠른 거듭제곱으로 풀 수도 있는 문제인 것 같다.
 * 피보나치 수를 거듭제곱으로 어떻게 구하는지 이론을 모르는데
 * 나중에 시간 많이 남을 때 이 풀이로도 풀어보면 좋을 듯
 */