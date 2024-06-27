using System;
using System.Linq;

class Program
{
    static bool Check(int x, int mid, int[] a)
    {
        return (x > a[mid]);
    }
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] a = new int[n + 1];
        string[] input = Console.ReadLine().Split(' ');
        for (int i = 1; i <= n; i++) a[i] = int.Parse(input[i - 1]);

        int q = int.Parse(Console.ReadLine());
        int[] x = new int[q + 10];
        for (int i = 1; i <= q; i++) x[i] = int.Parse(Console.ReadLine());
        Array.Sort(a);
        for (int i = 1; i <= q; i++)
        {
            int l = 0, r = n + 1;
            while (r - l > 1)
            {
                int mid = (r + l) / 2;
                if (Check(x[i], mid, a)) l = mid;
                else r = mid;
            }
            Console.WriteLine(l);
        }
    }
}