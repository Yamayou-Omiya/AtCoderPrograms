using System;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        int n = int.Parse(input[0]);
        int q = int.Parse(input[1]);
        
        int[] a = new int[n+1];
        input = Console.ReadLine().Split(' ');
        for (int i = 1; i <= n; i++) a[i] = int.Parse(input[i-1]);

        int[] sum = new int[n+1];
        sum[0] = 0;
        for (int i = 1; i <= n; i++) sum[i] = sum[i - 1] + a[i];

        for (int i = 0; i < q; i++)
        {
            input = Console.ReadLine().Split(' ');
            int l = int.Parse(input[0]);
            int r = int.Parse(input[1]);

            Console.WriteLine(sum[r] - sum[l-1]);
        }
    }
}
