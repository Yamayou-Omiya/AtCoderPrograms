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

        int[] sum = new int[n + 10];
        sum[0] = 0;
        for (int i = 1; i <= n; i++) sum[i] = sum[i - 1] + a[i];

        int[] r = new int[n + 10];
        long count = 0;
        for (int i = 1; i <= n; i++)
        {
            if (i == 1) r[i] = 0;
            else r[i] = r[i - 1];

            while (r[i] < n && sum[r[i] + 1] - sum[i - 1] <= k) r[i]++;
            count += r[i] - i + 1;
        }
        Console.WriteLine(count);
    }
}