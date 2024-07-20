using System;
using System.Linq;

class Program
{
    static int r;
    static void Main(string[] args)
    {
        r = int.Parse(Console.ReadLine());
        Console.WriteLine(100-(r%100));
    }
}
