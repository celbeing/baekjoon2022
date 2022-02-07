using System;
class Program
{
    static int N, K;
    static int div = 1000000007;
    static long[] fac = new long[4000001];
    static long[] inv = new long[4000001];
    static void Main()
    {
        fac[1] = 1;
        for(int i = 2; i <= 4000000; i++)
            fac[i] = fac[i - 1] * i % div;
        inv[4000000] = (int)Pow(fac[4000000], div - 2);
        for (int i = 3999999; i >= 0; i--)
            inv[i] = inv[i + 1] * (i + 1) % div;
        var nk = Console.ReadLine().Split();
        N = int.Parse(nk[0]); K = int.Parse(nk[1]);
        Console.WriteLine((fac[N] * inv[N - K] % div) * inv[K] % div);
    }
    static long Pow(long b, int e)
    {
        long res = 1;
        while (e > 0)
        {
            if (e % 2 == 1)
            {
                res *= b;
                res %= div;
                e--;
            }
            b *= b;
            b %= div;
            e >>= 1;
        }
        return res;
    }
}
/* 참고 san9640 33924026
 * 입력 받는 방법이 신기함
 * 접근이 아예 다름
 * 유클리드 호제법 쓰신 것 같은데 무슨 원리인지는 아예 감이 안온다
using System;
using System.Collections.Generic;
using System.Text;

int GetInt() {
	return int.Parse(Console.ReadLine());
}

(int, int) GetConst() {
	var constants = GetValues();
	return (constants[0], constants[1]);
}

int[] GetValues() {
	return Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
}

(int N, int K) = GetConst();

// K가 너무 크다 싶으면 그냥 빼버림 (결과값은 같음)
if (K * 2 > N) {
	K = N - K;
}

long Divider = 1000000007;

long GetB2A(int a, int b) {
	long result = 1;
	for (long i = b; i <= a; i++) {
		result = (result * i) % Divider;
	}

	return result;
}

long lower = GetB2A(K, 1);
long upper = GetB2A(N, N - K + 1);

// a가 더 작음
long ExtendedGCD(long a, long b) {
	long q, r, s, sa = 1, sb = 0;

	while (b > 0) {
		q = a / b;
		r = a % b;

		a = b;
		b = r;

		s = sa - q * sb;
		sa = sb;
		sb = s;
	}

	if (sa < 0) {
		sa += Divider;
	}

	return sa;
}

var answer = (upper * ExtendedGCD(lower, Divider)) % Divider;

Console.WriteLine(answer);
*/