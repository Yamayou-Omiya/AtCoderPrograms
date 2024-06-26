using System;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        for (int i = 9; i >= 0; i--)
        {
            if (((N >> i & 1)) == 1) Console.Write("1");
            else Console.Write("0");
        }

    }
}
