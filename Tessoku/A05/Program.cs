using System;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        int N = int.Parse(input[0]);
        int K = int.Parse(input[1]);
        int ans = 0;

        for (int i = 1; i <= N; i++)
        {
            for (int j = 1; j <= N; j++)
            {
                int r = K - i - j;
                if (1 <= r && r <= N) ans++;

            }
        }

        Console.WriteLine(ans);

    }
}
