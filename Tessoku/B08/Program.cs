using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] x = new int[n+10];
        int[] y = new int[n+10];

        string[] input;

        for (int i = 1; i <= n; i++)
        {
            input = Console.ReadLine().Split();
            x[i] = int.Parse(input[0]);
            y[i] = int.Parse(input[1]);
        }

        int[,] p = new int[1510, 1510];
        for (int i = 1; i <= n; i++) p[x[i], y[i]]++;

        int q = int.Parse(Console.ReadLine());
        int[] a = new int[q + 10];
        int[] b = new int[q + 10];
        int[] c = new int[q + 10];
        int[] d = new int[q + 10];


        for (int i = 1; i <= q; i++)
        {
            input = Console.ReadLine().Split(' ');
            a[i] = int.Parse(input[0]);
            b[i] = int.Parse(input[1]);
            c[i] = int.Parse(input[2]);
            d[i] = int.Parse(input[3]);
        }

        int[,] z = new int[1510, 1510];

        for (int i = 1; i <= 1500; i++)
        {
            for (int j = 1; j <= 1500; j++)
            {
                z[i, j] = z[i, j - 1] + p[i, j];
            }
        }

        for (int i = 1; i <= 1500; i++)
        {
            for (int j = 1; j <= 1500; j++)
            {
                z[j, i] = z[j - 1, i] + z[j, i];
            }
        }

        for (int i = 1; i <= q; i++)
        {
            Console.WriteLine(z[c[i], d[i]] + z[a[i] - 1, b[i] - 1] - z[a[i] - 1, d[i]] - z[c[i], b[i] - 1]);
        }
    }
}