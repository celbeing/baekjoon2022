using System;
class Program
{
    static int a = 0;
    static int b = 0;
    static int c = 0;
    static int[] row = new int[10];
    static int[] column = new int[10];
    static string input;
    static bool[,] board = new bool[10, 10];
    static void Main()
    {
        for (int i = 0; i < 10; i++)
        {
            input = Console.ReadLine();
            for (int j = 0; j < 10; j++)
            {
                if (input[j] == '0') board[i, j] = false;
                else board[i, j] = true;
            }
        }
        for(int i = 0; i < 10; i++)
        {
            for(int j = 0; j < 10; j++)
            {
                if (board[i, j]) row[i]++;
                if (board[j, i]) column[i]++;
            }
        }
        for (int i = 0; i < 10; i++)
        {
            if (row[i] == 0) continue;
            if (row[i] == 1)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (board[i, j])
                    {
                        a = 100 * (i + 1) + j + 1;
                        i = 10;
                        break;
                    }
                }
            }
            else
            {
                for (int j = 0; j < 10; j++)
                {
                    if (board[i, j])
                    {
                        a = 100 * (i + 1) + j + 1;
                        break;
                    }
                }
                for (int j = 9; j >= 0; j--)
                {
                    if (board[i, j])
                    {
                        b = 100 * (i + 1) + j + 1;
                        i = 10;
                        break;
                    }
                }
            }
        }
        for (int i = 9; i >= 0; i--)
        {
            if (row[i] == 0) continue;
            if (row[i] == 1)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (board[i, j])
                    {
                        c = 100 * (i + 1) + j + 1;
                        i = -1;
                        break;
                    }
                }
            }
            else
            {
                if (b != 0)
                {
                    Console.WriteLine(0);
                    return;
                }
                for (int j = 0; j < 10; j++)
                {
                    if (board[i, j])
                    {
                        b = 100 * (i + 1) + j + 1;
                        break;
                    }
                }
                for (int j = 9; j >= 0; j--)
                {
                    if (board[i, j])
                    {
                        c = 100 * (i + 1) + j + 1;
                        i = -1;
                        break;
                    }
                }
            }
        }
        if(b == 0)
        {
            for(int i = 0; i < 10; i++)
            {
                if (column[i] == 1)
                {
                    for(int j = 0; j < 10; j++)
                    {
                        if (board[j, i])
                        {
                            b = 100 * (j + 1) + i + 1;
                        }
                    }
                }
            }
        }
        if (a * b * c == 0)
        {
            Console.WriteLine(0);
            return;
        }
        else if (a / 100 == b / 100 && a % 100 == c % 100)
        {
            for (int i = a / 100 - 1; i < c / 100 - 1; i++)
            {
                if (row[i] - row[i + 1] == 1) continue;
                else
                {
                    Console.WriteLine(0);
                    return;
                }
            }
            for (int i = a % 100 - 1; i < b % 100 - 1; i++)
            {
                if (column[i] - column[i + 1] == 1) continue;
                else
                {
                    Console.WriteLine(0);
                    return;
                }
            }
        }
        else if (a % 100 == b % 100 && b / 100 == c / 100)
        {
            for (int i = a / 100 - 1; i < c / 100 - 1; i++)
            {
                if (row[i + 1] - row[i] == 1) continue;
                else
                {
                    Console.WriteLine(0);
                    return;
                }
            }
            for (int i = a % 100 - 1; i < c % 100 - 1; i++)
            {
                if (column[i] - column[i + 1] == 1) continue;
                else
                {
                    Console.WriteLine(0);
                    return;
                }
            }
        }
        else if (a % 100 == c % 100 && b / 100 == c / 100)
        {
            for (int i = a / 100 - 1; i < c / 100 - 1; i++)
            {
                if (row[i + 1] - row[i] == 1) continue;
                else
                {
                    Console.WriteLine(0);
                    return;
                }
            }
            for (int i = b % 100 - 1; i < c % 100 - 1; i++)
            {
                if (column[i + 1] - column[i] == 1) continue;
                else
                {
                    Console.WriteLine(0);
                    return;
                }
            }
        }
        else if (a / 100 == b / 100 && b % 100 == c % 100)
        {
            for (int i = a / 100 - 1; i < c / 100 - 1; i++)
            {
                if (row[i] - row[i + 1] == 1) continue;
                else
                {
                    Console.WriteLine(0);
                    return;
                }
            }
            for (int i = a % 100 - 1; i < b % 100 - 1; i++)
            {
                if (column[i + 1] - column[i] == 1) continue;
                else
                {
                    Console.WriteLine(0);
                    return;
                }
            }
        }

        else if (a / 100 == b / 100 && c == (a / 100 + row[a / 100 - 1] / 2) * 100 + (a % 100 + b % 100) / 2)
        {
            for(int i = a / 100 - 1; i < c / 100 - 1; i++)
            {
                if (row[i] - row[i + 1] == 2) continue;
                else
                {
                    Console.WriteLine(0);
                    return;
                }
            }
            for(int i = 1; i < column[c % 100 - 1]; i++)
            {
                if (column[c % 100 - 1 - i] == column[c % 100 - 1 + i] && column[c % 100 - 1] - i == column[c % 100 - 1 + i]) continue;
                else
                {
                    Console.WriteLine(0);
                    return;
                }
            }
        }
        else if (a % 100 == c % 100 && b == (a / 100 + c / 100) / 2 * 100 + a % 100 + column[a % 100 - 1] / 2)
        {
            for (int i = a % 100 - 1; i < b % 100 - 1; i++)
            {
                if (column[i] - column[i + 1] == 2) continue;
                else
                {
                    Console.WriteLine(0);
                    return;
                }
            }
            for (int i = 1; i < row[b / 100 - 1]; i++)
            {
                if (row[b / 100 - 1 - i] == row[b / 100 - 1 + i] && row[b / 100 - 1] - i == row[b / 100 - 1 + i]) continue;
                else
                {
                    Console.WriteLine(0);
                    return;
                }
            }
        }
        else if (a % 100 == c % 100 && b == (a / 100 + c / 100) / 2 * 100 + a % 100 - column[a % 100 - 1] / 2)
        {
            for (int i = b % 100 - 1; i < a % 100 - 1; i++)
            {
                if (column[i + 1] - column[i] == 2) continue;
                else
                {
                    Console.WriteLine(0);
                    return;
                }
            }
            for (int i = 1; i < row[b / 100 - 1]; i++)
            {
                if (row[b / 100 - 1 - i] == row[b / 100 - 1 + i] && row[b / 100 - 1] - i == row[b / 100 - 1 + i]) continue;
                else
                {
                    Console.WriteLine(0);
                    return;
                }
            }
        }
        else if (b / 100 == c / 100 && a == (b / 100 - row[b / 100 - 1] / 2) * 100 + (b % 100 + c % 100) / 2)
        {
            for (int i = a / 100 - 1; i < c / 100 - 1; i++)
            {
                if (row[i + 1] - row[i] == 2) continue;
                else
                {
                    Console.WriteLine(0);
                    return;
                }
            }
            for (int i = 1; i < column[a % 100 - 1]; i++)
            {
                if (column[a % 100 - 1 - i] == column[a % 100 - 1 + i] && column[a % 100 - 1] - i == column[a % 100 - 1 + i]) continue;
                else
                {
                    Console.WriteLine(0);
                    return;
                }
            }
        }
        else
        {
            Console.WriteLine(0);
            return;
        }
        Console.WriteLine($"{a / 100} {a % 100}");
        Console.WriteLine($"{b / 100} {b % 100}");
        Console.WriteLine($"{c / 100} {c % 100}");
    }
}