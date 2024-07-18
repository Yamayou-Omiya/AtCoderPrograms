using System;

class Program
{
    static int n, m;
    static int[] a = new int[110], b = new int[110];
    static string[] backet = new string[210];
    static List<string> c = new List<string>();

    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        (n, m) = (int.Parse(input[0]), int.Parse(input[1]));

        input = Console.ReadLine().Split(' ');
        for (int i = 1; i <= n; i++)
        {
            a[i] = int.Parse(input[i - 1]);
            backet[a[i]] = "A";
        }

        input = Console.ReadLine().Split(' ');
        for (int i = 1; i <= m; i++)
        {
            b[i] = int.Parse(input[i - 1]);
            backet[b[i]] = "B";
        }

        for (int i = 1; i <= 200; i++)
        {
            if (backet[i] != null) c.Add(backet[i]);
        }

        string answer = "No";

        for (int i = 1; i <= n + m - 1; i++)
        {
            if (c[i] == c[i - 1] && c[i] == "A") answer = "Yes";
        }

        Console.WriteLine(answer);

    }
}
