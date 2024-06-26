using System;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int[] A = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        bool ans = false;

        for (int i = 0; i < N; i++)
        {
            for (int j = i + 1; j < N; j++)
            {
                for (int k = j + 1; k < N; k++)
                {
                    if(A[i]+A[j]+A[k]==1000) ans = true;
                }
            }
        }

        if (ans) Console.WriteLine("Yes");
        else Console.WriteLine("No");

    }
}
