using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] h = new int[100010];

        string[] input = Console.ReadLine().Split(' ');
        for (int i = 1; i <= n; i++) h[i] = int.Parse(input[i - 1]);

        int[] dp = new int[100010];
        dp[1] = 0;
        dp[2] = Math.Abs(h[2] - h[1]);

        for (int i = 3; i <= n; i++)
        {
            dp[i] = Math.Min(dp[i - 1] + Math.Abs(h[i] - h[i - 1]), dp[i - 2] + Math.Abs(h[i] - h[i - 2]));
        }

        Console.WriteLine(dp[n]);

    }
}