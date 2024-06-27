using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] a = new int[n + 10];
        int[] b = new int[n + 10];
        int[] c = new int[n + 10];
        int[] d = new int[n + 10];
        string[] input;

        for (int i = 1; i <= n; i++)
        {
            input = Console.ReadLine().Split(' ');
            a[i] = int.Parse(input[0]);
            b[i] = int.Parse(input[1]);
            c[i] = int.Parse(input[2]);
            d[i] = int.Parse(input[3]);
        }

        int[,] x = new int[1510, 1510];
        int[,] z = new int[1510, 1510];

        for (int i = 1; i <= n; i++)
        {
            x[a[i], b[i]]++;
            x[a[i], d[i]]--;
            x[c[i], b[i]]--;
            x[c[i], d[i]]++;
        }

        for (int i = 0; i <= 1500; i++) z[i, 0] = x[i, 0];

        for (int i = 0; i <= 1500; i++)
        {
            for (int j = 1; j <= 1500; j++)
            {
                z[i, j] = z[i, j - 1] + x[i, j];
            }
        }

        for (int i = 0; i <= 1500; i++)
        {
            for (int j = 1; j <= 1500; j++)
            {
                z[j, i] = z[j - 1, i] + z[j, i];
            }
        }

        int count = 0;

        for (int i = 0; i <= 1500; i++)
        {
            for (int j = 0; j <= 1500; j++)
            {
                if (z[i, j] > 0) count++;
            }
        }
        Console.WriteLine(count);
    }
}
