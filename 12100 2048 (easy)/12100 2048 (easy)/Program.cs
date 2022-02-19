using System;
using System.Collections.Generic;
public class Board
{
	public int[,] board;
	// 필드는 은닉성을 유지해야하지만
	// 2차원의 필드는 get, set 키워드를 어떻게 써야
	// 속성으로 값을 주고 받을 수 있을지 고민하다가
	// 결국 public으로 간단히 포기했다.
	public Board(int N)
    {
		board = new int[N, N];
    }
}
class Program
{
	static int N, max;
	static Queue<int> blockpush = new Queue<int>();
	// 블록을 밀어낼 때 사용할 큐다.

	static Stack<Board> tracking = new Stack<Board>();
	// 탐색 과정을 기억할 스택
	enum Direction { right, down, left, up };

	static void Main()
	{
		N = int.Parse(Console.ReadLine());
		max = 0;
		Board first = new Board(N);
		for (int i = 0; i < N; i++)
		{
			var row = Console.ReadLine().Split();
			for (int j = 0; j < N; j++)
			{
				first.board[i, j] = int.Parse(row[j]);
				if (max < first.board[i, j])
					max = first.board[i, j];
			}
		}
		tracking.Push(first);
		// 게임의 최초상태를 스택에 삽입한다.

		Move(first.board, 0);
		Console.WriteLine(max);
	}

	static void Move(int[,] board, int depth)
	{
		if (depth == 5)
		{
			tracking.Pop();
			return;
		}	// 탐색 깊이가 5가 되었다면 스택을 하나 삭제하고 탈출

		Move(Push(Direction.right), depth + 1);
		Move(Push(Direction.down), depth + 1);
		Move(Push(Direction.left), depth + 1);
		Move(Push(Direction.up), depth + 1);
		// 상하좌우로 각각 한번씩 재귀호출한다.

		tracking.Pop();
		// 모든 방향 탐색이 끝났다면 스택을 하나 삭제하고 탈출
	}

	static int[,] Push(Direction dir)
	{
		Board push = new Board(N);
		// 새로운 배열을 만든다.
		switch(dir)
		{
			case Direction.right:
				for (int i = 0; i < N; i++)
				{
					for (int j = N - 1; j >= 0; j--)
						if (tracking.Peek().board[i, j] > 0)
							blockpush.Enqueue(tracking.Peek().board[i, j]);
					// 블록의 숫자들을 큐에 삽입한다.
					// 어차피 모든 블록을 공백없이 한 방향으로 쭉 밀어야하기 때문에
					// 0이 아닌 값만 FIFO 으로 불러오면 된다.

					for (int j = N - 1; j >= 0 && blockpush.Count > 0; j--)
					{
						if (push.board[i, j] == 0) push.board[i, j] = blockpush.Dequeue();
						// 큐가 비어있지 않은데 지금 보는 칸이 비었다면
						// 큐의 값을 불러온다.

						if (blockpush.Count == 0) break;
						// 큐가 비었다면 반복을 멈춘다.

						if (push.board[i, j] == blockpush.Peek())
							push.board[i, j] += blockpush.Dequeue();
						// 지금 보는 칸의 숫자와 큐의 맨 윗 값이 같다면
						// 큐에서 하나 더 꺼내오고 지금 보는 칸에 더해준다.

						// 이 방법으로 한 번 밀어줄 때 최대 2개의 블록만
						// 합쳐지도록 구현했다.
					}
				}
				break;
			case Direction.down:
				for (int j = 0; j < N; j++)
				{
					for (int i = N - 1; i >= 0; i--)
						if (tracking.Peek().board[i, j] > 0)
							blockpush.Enqueue(tracking.Peek().board[i, j]);
					for (int i = N - 1; i >= 0 && blockpush.Count > 0; i--)
					{
						if (push.board[i, j] == 0) push.board[i, j] = blockpush.Dequeue();
						if (blockpush.Count == 0) break;
						if (push.board[i, j] == blockpush.Peek())
							push.board[i, j] += blockpush.Dequeue();
					}
				}
				break;
			case Direction.left:
				for (int i = 0; i < N; i++)
				{
					for (int j = 0; j < N; j++)
						if (tracking.Peek().board[i, j] > 0)
							blockpush.Enqueue(tracking.Peek().board[i, j]);
					for (int j = 0; j < N && blockpush.Count > 0; j++)
					{
						if (push.board[i, j] == 0) push.board[i, j] = blockpush.Dequeue();
						if (blockpush.Count == 0) break;
						if (push.board[i, j] == blockpush.Peek())
							push.board[i, j] += blockpush.Dequeue();
					}
				}
				break;
			case Direction.up:
				for (int j = 0; j < N; j++)
				{
					for (int i = 0; i < N; i++)
						if (tracking.Peek().board[i, j] > 0)
							blockpush.Enqueue(tracking.Peek().board[i, j]);
					for (int i = 0; i < N && blockpush.Count > 0; i++)
					{
						if (push.board[i, j] == 0) push.board[i, j] = blockpush.Dequeue();
						if (blockpush.Count == 0) break;
						if (push.board[i, j] == blockpush.Peek())
							push.board[i, j] += blockpush.Dequeue();
					}
				}
				break;
		}
		for(int i = 0; i < N; i++)
        {
			for (int j = 0; j < N; j++)
				if (max < push.board[i, j]) max = push.board[i, j];
        }
		tracking.Push(push);
		// 새로 만들어진 배열을 스택에 삽입한다.

		return push.board;
	}
}