using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {

        int d = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        int[] l = new int[n + 1];
        int[] r = new int[n + 1];

        int[] b = new int[d + 2];
        int[] sum = new int[d + 2];
        sum[0] = 0;

        for (int i = 1; i <= n; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            l[i] = int.Parse(input[0]);
            r[i] = int.Parse(input[1]);
        }

        for (int i = 1; i <= n; i++)
        {
            b[l[i]]++;
            b[r[i] + 1]--;
        }

        for (int i = 1; i <= d; i++)
        {
            sum[i] = sum[i - 1] + b[i];
            Console.WriteLine(sum[i]);
        }
    }
}