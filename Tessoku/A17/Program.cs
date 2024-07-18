using System;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] a = new int[100010];
        int[] b = new int[100010];

        string[] input = Console.ReadLine().Split(' ');
        for (int i = 2; i <= n; i++) a[i] = int.Parse(input[i - 2]);

        input = Console.ReadLine().Split(' ');
        for (int i = 3; i <= n; i++) b[i] = int.Parse(input[i - 3]);

        int[] dp = new int[100010];
        dp[1] = 0;
        dp[2] = a[2];
        for (int i = 3; i <= n; i++) dp[i] = Math.Min(dp[i - 1] + a[i], dp[i - 2] + b[i]);


        List<int> answer = new List<int>();
        int place = n;
        while (place > 0)
        {
            answer.Add(place);
            if (dp[place] == dp[place - 1] + a[place]) place--;
            else place -= 2;
        }

        answer.Reverse();
        Console.WriteLine(answer.Count);
        foreach (int i in answer) Console.Write(i + " ");

    }
}
