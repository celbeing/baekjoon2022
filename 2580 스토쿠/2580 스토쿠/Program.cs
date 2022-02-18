using System;
using System.Collections.Generic;
public class Location
{
    private int x, y;
    public int X
    {
        get { return this.x; }
        set { this.x = value; }
    }
    public int Y
    {
        get { return this.y; }
        set { this.y = value; }
    }
    public Location(int a, int b)
    {
        X = a; Y = b;
    }
}
class Program
{
    static int[,] sudoku = new int[9, 9];
    static bool[,] row = new bool[9, 9];
    static bool[,] col = new bool[9, 9];
    static bool[,] box = new bool[9, 9];
    static Stack<Location> checklist = new Stack<Location>();
    static Stack<Location> checkedlist = new Stack<Location>();
    static void Main()
    {
        for(int i = 0; i < 9; i++)
        {
            var r = Console.ReadLine().Split();
            for(int j = 0; j < 9; j++)
            {
                sudoku[i, j] = int.Parse(r[j]);
                if (sudoku[i, j] == 0) checklist.Push(new Location(i, j));
                else Marker(i, j);
            }
        }

        Tracking();

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
                Console.Write(sudoku[i, j] + " ");
            if(i != 8) Console.Write("\n");
        }
    }
    static void Tracking()
    {
        if (checklist.Count == 0) return;
        int a = checklist.Peek().X; int b = checklist.Peek().Y;
        for (int i = 1; i < 10; i++)
        {
            if (Check(checklist.Peek(), i))
            {
                checkedlist.Push(checklist.Pop());
                sudoku[a, b] = i;
                Marker(a, b);
                Tracking();
            }
            else continue;
            Marker(a, b);
            if (checklist.Count == 0) return;
        }
        checklist.Push(checkedlist.Pop());
    }

    /*
    static bool Check(Location s)
    {
        int a = s.X; int b = s.Y;
        for(int i = 0; i < 9; i++)
        {
            if (i != a && sudoku[i, b] == sudoku[a, b]) return false;
            if (i != b && sudoku[a, i] == sudoku[a, b]) return false;
        }
        a /= 3; b /= 3;
        a *= 3; b *= 3;
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                if (s.X == a + i && s.Y == b + j) continue;
                if (sudoku[s.X, s.Y] == sudoku[a + i, b + j]) return false;
            }
        }
        return true;
    }
    */
}