using System;
using System.Collections.Generic;
public class Document
{
    private int num, priority;
    public int Number
    {
        get { return this.num; }
        set { this.num = value; }
    }
    public int Priority
    {
        get { return this.priority; }
        set { this.priority = value; }
    }
    public Document(int n, int p)
    {
        Number = n;
        Priority = p;
    }
}
class Program
{
    static int T, N, M, count;
    static int[] priority = new int[10];
    static Queue<Document> PrintQ = new Queue<Document>();
    static void Main()
    {
        T = int.Parse(Console.ReadLine());
        for (int i = 0; i < T; i++)
        {
            var nm = Console.ReadLine().Split();
            N = int.Parse(nm[0]); M = int.Parse(nm[1]);
            var documents = Console.ReadLine().Split();
            PrintQ.Clear(); count = 0;
            for (int j = 0; j < 10; j++) priority[j] = 0;
            for (int j = 0; j < N; j++)
            {
                PrintQ.Enqueue(new Document(j, int.Parse(documents[j])));
                priority[int.Parse(documents[j])]++;
            }
            while (PrintQ.Count > 0)
            {
                for (int j = PrintQ.Peek().Priority + 1; j < 10; j++)
                {
                    if (priority[j] > 0)
                    {
                        PrintQ.Enqueue(PrintQ.Dequeue());
                        j = PrintQ.Peek().Priority;
                    }
                }
                priority[PrintQ.Peek().Priority]--;
                count++;
                if (PrintQ.Dequeue().Number == M) break;
            }
            Console.WriteLine(count);
        }
    }
}