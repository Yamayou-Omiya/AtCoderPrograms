using System;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int[] a = new int[n + 1];
        string[] input = Console.ReadLine().Split(' ');
        for (int i = 1; i <= n; i++) a[i] = int.Parse(input[i - 1]);

        int q = int.Parse(Console.ReadLine());

        int[] sum = new int[n + 1];
        sum[0] = 0;
        for (int i = 1; i <= n; i++) sum[i] = sum[i - 1] + a[i];

        for (int i = 0; i < q; i++)
        {
            input = Console.ReadLine().Split(' ');
            int l = int.Parse(input[0]);
            int r = int.Parse(input[1]);
            int win = sum[r] - sum[l - 1];
            int lose = r - l + 1 - win;

            if (win > lose) Console.WriteLine("win");
            else if (win < lose) Console.WriteLine("lose");
            else Console.WriteLine("draw");

        }
    }
}
