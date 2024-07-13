using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        (int n, int k, int x) = (int.Parse(input[0]), int.Parse(input[1]), int.Parse(input[2]));
        int[] a = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        for (int i = 0; i < k; i++) Console.Write("{0} ", a[i]);
        Console.Write("{0} ", x);
        for (int i = k; i < n; i++) Console.Write("{0} ", a[i]);
    }
}
