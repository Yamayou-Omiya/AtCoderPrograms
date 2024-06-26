using System;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        int A = int.Parse(input[0]);
        int B = int.Parse(input[1]);
        bool ans = false;

        for (int i = A; i <= B; i++)
        {
            if (100 % i == 0)
            {
                ans = true;
                break;
            }
        }

        if (ans) Console.WriteLine("Yes");
        else Console.WriteLine("No");

    }
}
