using System;
using System.Linq;

class Program
{
    static bool Check(int x, int mid, int[] a)
    {
        return (x >= a[mid]);
    }
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        int n = int.Parse(input[0]);
        int x = int.Parse(input[1]);
        int[] a = new int[n + 10];
        input = Console.ReadLine().Split(' ');
        for (int i = 1; i <= n; i++) a[i] = int.Parse(input[i - 1]);

        int l = 0, r = n + 1;
        while (r - l > 1)
        {
            int mid = (r + l) / 2;
            if (Check(x, mid, a)) l = mid;
            else r = mid;
        }

        Console.WriteLine(l);
    }
}