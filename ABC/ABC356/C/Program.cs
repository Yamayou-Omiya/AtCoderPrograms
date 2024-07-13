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

        int[] box = new int[n];
        for (int i = 0; i < n; i++) box[a[i] - 1] = Math.Max(box[a[i] - 1], w[i]);

        for (int i = 0; i < n; i++) sum -= box[i];
        Console.WriteLine(sum);
    }
}
