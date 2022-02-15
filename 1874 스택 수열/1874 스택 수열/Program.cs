using System;
using System.Text;
using System.Collections.Generic;

class Program
{
    static int n, k, s;
    static bool p;
    static Stack<int> stack = new Stack<int>();
    static StringBuilder procedure = new StringBuilder();
    static void Main()
    {
        n = int.Parse(Console.ReadLine()); s = 1;
        for (int i = 0; i < n; i++)
        {
            k = int.Parse(Console.ReadLine());
            if (p) continue;
            StackControl(k);
        }
        Console.WriteLine(procedure);
    }
    static void StackControl(int t)
    {
        if (stack.Count == 0)
        {
            stack.Push(s++);
            procedure.AppendLine("+");
        }
        if(stack.Peek() < t)
        {
            while(s <= t)
            {
                stack.Push(s++);
                procedure.AppendLine("+");
            }
        }
        if(stack.Peek() == t)
        {
            stack.Pop();
            procedure.AppendLine("-");
            return;
        }
        else
        {
            procedure.Clear();
            procedure.AppendLine("NO");
            p = true;
            return;
        }
    }
}