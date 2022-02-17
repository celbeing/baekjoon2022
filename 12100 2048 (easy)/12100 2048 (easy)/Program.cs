using System;
using System.Collections.Generic;

class Program
{
	static int N, max;
	static int[,] Board;
	static Queue<int> blockpush = new Queue<int>();
	enum Direction { right, down, left, up };

	static void Main()
	{
		N = int.Parse(Console.ReadLine());
		max = 0;
		Board = new int[N, N];
		for (int i = 0; i < N; i++)
		{
			var row = Console.ReadLine().Split();
			for (int j = 0; j < N; j++)
			{
				Board[i, j] = int.Parse(row[j]);
				if (max < Board[i, j]) max = Board[i, j];
			}
		}
		Move(Board, 0);
		Console.WriteLine(max);
	}

	static void Move(int[,] board, int depth)
	{
		if (depth == 5)
		{
			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < N; j++)
				{
					if (board[i, j] > max) max = board[i, j];
					return;
				}
			}
		}
		Move(Push(board, Direction.right), depth + 1);
		Move(Push(board, Direction.down), depth + 1);
		Move(Push(board, Direction.left), depth + 1);
		Move(Push(board, Direction.up), depth + 1);
	}

	static int[,] Push(int[,] gravity, Direction dir)
	{
		switch(dir)
		{
			case Direction.right:
				for (int i = 0; i < N; i++)
				{
					for (int j = N - 1; j >= 0; j--)
					{
						if (gravity[i, j] > 0) blockpush.Enqueue(gravity[i, j]);
						gravity[i, j] = 0;
					}
					for (int j = N - 1; j >= 0 && blockpush.Count > 0; j--)
					{
						if (gravity[i, j] == 0) gravity[i, j] = blockpush.Dequeue();
						if (blockpush.Count == 0) break;
						if (gravity[i, j] == blockpush.Peek())
							gravity[i, j] += blockpush.Dequeue();
					}
				}
				break;
			case Direction.down:
				for (int j = 0; j < N; j++)
				{
					for (int i = N - 1; i >= 0; i--)
					{
						if (gravity[i, j] > 0) blockpush.Enqueue(gravity[i, j]);
						gravity[i, j] = 0;
					}
					for (int i = N - 1; i >= 0 && blockpush.Count > 0; i--)
					{
						if (gravity[i, j] == 0) gravity[i, j] = blockpush.Dequeue();
						if (blockpush.Count == 0) break;
						if (gravity[i, j] == blockpush.Peek())
							gravity[i, j] += blockpush.Dequeue();
					}
				}
				break;
			case Direction.left:
				for (int i = 0; i < N; i++)
				{
					for (int j = 0; j < N; j++)
					{
						if (gravity[i, j] > 0) blockpush.Enqueue(gravity[i, j]);
						gravity[i, j] = 0;
					}
					for (int j = 0; j < N && blockpush.Count > 0; j++)
					{
						if (gravity[i, j] == 0) gravity[i, j] = blockpush.Dequeue();
						if (blockpush.Count == 0) break;
						if (gravity[i, j] == blockpush.Peek())
							gravity[i, j] += blockpush.Dequeue();
					}
				}
				break;
			case Direction.up:
				for (int j = 0; j < N; j++)
				{
					for (int i = 0; i < N; i++)
					{
						if (gravity[i, j] > 0) blockpush.Enqueue(gravity[i, j]);
						gravity[i, j] = 0;
					}
					for (int i = 0; i < N && blockpush.Count > 0; i++)
					{
						if (gravity[i, j] == 0) gravity[i, j] = blockpush.Dequeue();
						if (blockpush.Count == 0) break;
						if (gravity[i, j] == blockpush.Peek())
							gravity[i, j] += blockpush.Dequeue();
					}
				}
				break;
		}
		for(int i = 0; i < N; i++)
        {
			for (int j = 0; j < N; j++)
				if (max < gravity[i, j]) max = gravity[i, j];
        }
		return gravity;
	}

	static void Draw(int[,] map)
    {
		Console.WriteLine("state");
		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < N; j++)
				Console.Write(map[i, j] + " ");
			Console.Write("\n");
        }
    }
}