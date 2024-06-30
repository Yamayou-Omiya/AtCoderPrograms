using System;
using System.Linq;

class Program
{
    static bool Check(long k, long mid, long[] a)
    {
        long sum = 0;
        for (long i = 1; i <= a.Length - 1; i++) sum += mid / a[i];
        return k > sum;
    }
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        long n = long.Parse(input[0]);
        long k = long.Parse(input[1]);
        long[] a = new long[n + 1];
        input = Console.ReadLine().Split(' ');
        for (long i = 1; i <= n; i++) a[i] = long.Parse(input[i - 1]);

        long l = 0, r = (long)Math.Pow(10, 9);
        while (r - l > 1)
        {
            long mid = (r + l) / 2;
            if (Check(k, mid, a)) l = mid;
            else r = mid;
        }
        Console.WriteLine(r);
    }
}