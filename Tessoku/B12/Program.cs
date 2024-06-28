using System;
using System.Linq;

class Program
{
    static bool Check(int n, double mid)
    {
        double fx = mid * mid * mid + mid;
        return (fx <= n);
    }

    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        double l = 0.0, r = 100.0;
        while (r - l > 0.0001)
        {
            double mid = (r + l) / 2.0;
            if (Check(n, mid)) l = mid;
            else r = mid;
        }
        Console.WriteLine(l);

    }
}