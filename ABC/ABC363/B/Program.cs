using System;
using System.Linq;

class Program
{
    static int n, t, p;
    static int[] l;
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        (n, t, p) = (int.Parse(input[0]), int.Parse(input[1]), int.Parse(input[2]));
        l = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        Array.Sort(l);
        Array.Reverse(l);
        if (t - l[p-1]> 0) Console.WriteLine(t - l[p-1]);
        else Console.WriteLine(0);
        
    }
}
