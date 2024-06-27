using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] a = new int[n + 10];
        string[] input = Console.ReadLine().Split(' ');
        for (int i = 1; i <= n; i++) a[i] = int.Parse(input[i - 1]);

        int d = int.Parse(Console.ReadLine());
        int[] l = new int[d + 10];
        int[] r = new int[d + 10];

        for (int i = 1; i <= d; i++)
        {
            input = Console.ReadLine().Split(' ');
            l[i] = int.Parse(input[0]);
            r[i] = int.Parse(input[1]);
        }

        int[] p = new int[n + 10];
        int[] q = new int[n + 10];

        p[1] = a[1];
        q[n] = a[n];

        for (int i = 2; i <= n; i++) p[i] = Math.Max(p[i - 1], a[i]);
        for (int i = n - 1; i >= 1; i--) q[i] = Math.Max(q[i + 1], a[i]);

        for (int i = 1; i <= d; i++)
        {
            Console.WriteLine(Math.Max(p[l[i] - 1], q[r[i] + 1]));
        }
    }
}