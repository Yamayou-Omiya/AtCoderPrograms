using System;

class Program
{
    static void Main()
    {

        string[] input = Console.ReadLine().Split(' ');
        string S = input[0];
        string T = input[1];

        string ans = "No";

        for (int w = 1; w < S.Length; w++)
        {
            for (int c = 1; c <= w; c++)
            {
                if (IsMatching(S, T, c, w))
                {
                    ans = "Yes";
                    break;
                }
            }
        }
        Console.WriteLine(ans);
    }

    static bool IsMatching(string S, string T, int c, int w)
    {
        string concatenated = "";
        for (int i = 0; i < S.Length; i += w)
        {
            if (i + c - 1 < S.Length)
            {
                concatenated += S[i + c - 1];
            }
        }
        return concatenated.Equals(T);
    }
}
