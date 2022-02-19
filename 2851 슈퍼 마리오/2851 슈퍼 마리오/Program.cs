using System;
class Program
{
    static int near = 0;
    static int[] mushroom = new int[10];
    static void Main()
    {
        for (int i = 0; i < 10; i++)
        {
            mushroom[i] = int.Parse(Console.ReadLine());
            if (i > 0) mushroom[i] += mushroom[i - 1];
            if (Math.Pow(100 - mushroom[i], 2) <= Math.Pow(100 - near, 2))
                near = Math.Max(near, mushroom[i]);
        }
        Console.WriteLine(near);
    }
}