using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);

        int[] a = new int[n + 10];
        input = Console.ReadLine().Split(' ');
        for (int i = 1; i <= n; i++) a[i] = int.Parse(input[i - 1]);

        int[] r = new int[n + 10];
        long count = 0;
        for (int i = 1; i <= n - 1; i++)
        {
            if (i == 1) r[i] = 1;
            else r[i] = r[i - 1];

            while (r[i] < n && a[r[i] + 1] - a[i] <= k) r[i]++;
            count += r[i] - i;
        }
        Console.WriteLine(count);
    }
}