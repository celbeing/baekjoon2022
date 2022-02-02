using System;

class Program
{
    static int N, K, V;
    static void Main()
    {
        var nk = Console.ReadLine().Split();
        N = int.Parse(nk[0]);   // 물품의 수
        K = int.Parse(nk[1]);   // 준서가 버틸 수 있는 최대 무게
        int[,] Backpack = new int[N, K + 1];    // 0 ~ (N - 1)번 배낭 무게를 늘려갈 때 최대 값들을 저장할 배열
        int[] Weight = new int[N];              // 물건 번호 별 무게를 저장할 배열
        var wv = Console.ReadLine().Split();
        Weight[0] = int.Parse(wv[0]);
        V = int.Parse(wv[1]);
        for(int i = 0; i <= K; i++)             // 첫번째(0번) 물건을 배낭에 담아봄
        {
            if (i < Weight[0]) Backpack[0, i] = 0;
            else Backpack[0, i] = V;
        }
        for(int i = 1; i < N; i++)              // 두번째(1번) 물건부터 확인
        {
            wv = Console.ReadLine().Split();
            Weight[i] = int.Parse(wv[0]); V = int.Parse(wv[1]);
            for(int j = 0; j <= K; j++)         // i : 물건 번호, j : 배낭 무게
            {
                if (Weight[i] > j) Backpack[i, j] = Backpack[i - 1, j]; // 배낭에 물건 못담으면 이전 배낭 정보 그대로 가져오기
                else Backpack[i, j] = (int)Math.Max(Backpack[i - 1, j - Weight[i]] + V, Backpack[i - 1, j]);
            }           // 같은 무게의 이전 배낭의 가치와 이번 물건을 담을 여유가 있는 이전 배낭의 가치 + 이번 물건의 가치 둘 중 큰 값 저장
        }
        Console.Write(Backpack[N - 1, K]);
    }
}