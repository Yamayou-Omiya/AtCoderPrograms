using System;
using System.Linq;

class Program
{
    static int a, b;
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        (a, b) = (int.Parse(input[0]), int.Parse(input[1]));

        List<int> list = new List<int>();
        list.AddRange(new int[] { 1, 2, 3 });

        if (list.Contains(a)) list.Remove(a);
        if (list.Contains(b)) list.Remove(b);

        if(list.Count == 1) Console.WriteLine(list[0]);
        else Console.WriteLine("-1");
    }
}
