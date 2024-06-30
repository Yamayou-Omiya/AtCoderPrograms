using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string s = Console.ReadLine();
        string ans = "No";

        if (s[0] == 'R') ans = "Yes";
        if (s[1] == 'R') if (s[2] == 'M') ans = "Yes";
        Console.WriteLine(ans);

    }
}
