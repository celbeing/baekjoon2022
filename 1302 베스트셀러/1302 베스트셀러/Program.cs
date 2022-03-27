using System;
using System.Collections.Generic;
class Program
{
    static int N, top;
    static List<Book> sales = new List<Book>();
    static List<string> bestseller = new List<string>();
    static void Main()
    {
        N = int.Parse(Console.ReadLine());
        for(int i = 0; i < N; i++)
        {
            var title = Console.ReadLine();
            var newbook = true;
            for(int j = 0; j < sales.Count; j++)
            {
                if(sales[j].title == title)
                {
                    sales[j].Sold();
                    newbook = false;
                    break;
                }
            }
            if (newbook)
                sales.Add(new Book(title));
        }
        foreach (var book in sales)
        {
            if (top < book.sold)
            {
                bestseller.RemoveRange(0, bestseller.Count);
                bestseller.Add(book.title);
            }
            else if(top == book.sold)
            {
                bestseller.Add(book.title);
            }
        }
        bestseller.Sort();
        Console.WriteLine(bestseller[0]);
    }
}
public struct Book
{
    public string title;
    public int sold;
    public Book(string t)
    {
        this.title = t;
        this.sold = 1;
    }
    public void Sold()
    {
        this.sold++;
    }
}