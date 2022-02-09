using System;
using System.Numerics;
class Program
{
    static int n;
    static BigInteger[] f = new BigInteger[10001];
    static void Main()
    {
        n = int.Parse(Console.ReadLine());
        f[0] = 0;
        for(int i = 1; i <= n; i++)
            f[i] = fib(i);
        Console.WriteLine(f[n]);
    }
    static BigInteger fib(int i)
    {
        if (i > 1) return f[i - 1] + f[i - 2];
        else return 1;
    }
}
/* 이 문제도 BigInteger 구조체 쓰면서 손쉽게 풀어버렸다.
 * https://www.acmicpc.net/blog/view/28
 * 여기를 참고하면 피보나치 수를 구하는 다양한 방법이 소개되어있다.
 * 재귀, 메모이제이션(이건 이름만 알고 뭔지 몰?루), 행렬 제곱
 * 그리고 피보나치 수 관련 문제도 링크가 걸려있다.
 * 시 간 날 때 꼭 해 볼 것 !
 */