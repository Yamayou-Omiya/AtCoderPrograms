using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {

        int t = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        int[] l = new int[n + 10];
        int[] r = new int[n + 10];

        int[] b = new int[t + 10];
        int[] sum = new int[t + 10];

        for (int i = 1; i <= n; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            l[i] = int.Parse(input[0]);
            r[i] = int.Parse(input[1]);
        }

        for (int i = 1; i <= n; i++)
        {
            b[l[i]]++;
            b[r[i]]--;
        }

        sum[0] = b[0];
        Console.WriteLine(sum[0]);

        for (int i = 1; i <= t - 1; i++)
        {
            sum[i] = Math.Max(0, sum[i - 1] + b[i]);
            Console.WriteLine(sum[i]);
        }
    }
}