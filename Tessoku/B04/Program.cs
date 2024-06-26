using System;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int ans = 0;

        for (int i = 0; i < 8; i++)
        {
            ans += (N % 10) * (1 << i);
            N /= 10;
        }

        Console.WriteLine(ans);

    }
}
