using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] a = new int[100010];
        int[] b = new int[100010];

        string[] input = Console.ReadLine().Split(' ');
        for (int i = 2; i <= n; i++) a[i] = int.Parse(input[i - 2]);

        input = Console.ReadLine().Split(' ');
        for (int i = 3; i <= n; i++) b[i] = int.Parse(input[i - 3]);

    }
}