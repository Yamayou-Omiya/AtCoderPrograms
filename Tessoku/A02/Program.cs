using System;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        int N = int.Parse(input[0]);
        int X = int.Parse(input[1]);
        int[] A = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        bool ans = false;

        for (int i = 0; i < N; i++)
        {
            if (A[i] == X)
            {
                ans = true;
                break;
            }
        }

        if (ans) Console.WriteLine("Yes");
        else Console.WriteLine("No");

    }
}
