using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine().Trim());
        int[] a = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
        int[] b = new int[n];

        List<int> t = a.Distinct().ToList();
        t.Sort();

        for (int i = 0; i < n; i++)
        {
            b[i] = t.BinarySearch(a[i]) + 1;
        }

        Console.WriteLine(string.Join(" ", b));
    }
}