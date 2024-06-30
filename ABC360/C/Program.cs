using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] a = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int[] w = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        long sum = 0;

        for (int i = 0; i < n; i++) sum += w[i];

        int[] count1 = new int[n];
        int[] count2 = new int[n];
        for (int i = 0; i < n; i++)
        {
            count1[a[i] - 1] = Math.Max(count1[a[i] - 1], w[i]);
            count2[a[i] - 1]++;
        }

        for (int i = 0; i < n; i++) sum -= count1[i];
        Console.WriteLine(sum);
    }
}
