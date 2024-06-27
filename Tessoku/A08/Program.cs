using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        int h = int.Parse(input[0]);
        int w = int.Parse(input[1]);
        int[,] x = new int[h + 10, w + 10];

        for (int i = 1; i <= h; i++)
        {
            input = Console.ReadLine().Split(' ');
            for (int j = 1; j <= w; j++)
            {
                x[i, j] = int.Parse(input[j-1]);
            }
        }

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

        int[,] z = new int[h + 10, w + 10];

        for (int i = 1; i <= h; i++)
        {
            for (int j = 1; j <= w; j++)
            {
                z[i, j] = z[i, j - 1] + x[i, j];
            }
        }

        for (int i = 1; i <= w; i++)
        {
            for (int j = 1; j <= h; j++)
            {
                z[j, i] = z[j - 1, i] + z[j, i];
            }
        }

        for (int i = 1; i <= q; i++)
        {
            Console.WriteLine(z[c[i],d[i]]+z[a[i]-1,b[i]-1]-z[a[i]-1,d[i]]-z[c[i],b[i]-1]);
        }
    }
}