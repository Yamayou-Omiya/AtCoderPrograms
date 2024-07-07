using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        (int n, int k) = (int.Parse(input[0]), int.Parse(input[1]));
        int[] a = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        Array.Sort(a);
        int ans  = 1000000000;
        for (int i = 0; i <= k; i++)
        {
            ans = Math.Min(ans, a[n - k + i - 1] - a[i]);
        }
        Console.WriteLine(ans);
    }
}
