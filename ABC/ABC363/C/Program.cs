using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static int n, k;
    static string s;

    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        (n, k) = (int.Parse(input[0]), int.Parse(input[1]));
        s = Console.ReadLine();

        List<string> permutations = GetPermutations(s);

        int ans = 0;
        foreach (var perm in permutations)
        {
            bool isPalindrome = true;
            for (int i = 0; i <= n - k; i++)
            {
                bool isPld = true;
                for (int j = 0; j < k / 2; j++)
                {
                    if (perm[i + j] != perm[i + k - j - 1])
                    {
                        isPld = false;
                    }

                }

                if (isPld)
                {
                    isPalindrome = false;
                    break;
                }
            }
            if (isPalindrome) ans++;
        }

        Console.WriteLine(ans);

    }

    static List<string> GetPermutations(string str)
    {
        if (str.Length <= 1)
            return new List<string> { str };

        var permutations = new HashSet<string>();

        for (int i = 0; i < str.Length; i++)
        {
            char c = str[i];
            string remaining = str.Remove(i, 1);

            foreach (var perm in GetPermutations(remaining))
            {
                permutations.Add(c + perm);
            }
        }

        return permutations.ToList();
    }

}