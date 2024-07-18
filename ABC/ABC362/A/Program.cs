using System;
using System.Linq;

class Program
{
    static int r,g,b;
    static string c;
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        (r,g,b) = (int.Parse(input[0]), int.Parse(input[1]), int.Parse(input[2]));
        c = Console.ReadLine();
        List<int> rgb = new List<int> { r, g, b };
        if(c == "Red") Console.WriteLine(Math.Min(rgb[1], rgb[2]));
        else if(c == "Green") Console.WriteLine(Math.Min(rgb[0], rgb[2]));
        else if(c == "Blue") Console.WriteLine(Math.Min(rgb[0], rgb[1]));

    }
}
