using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int n, k;
        string s;

        string[] input = Console.ReadLine().Split();
        n = int.Parse(input[0]);
        k = int.Parse(input[1]);

        s = Console.ReadLine();

        List<int> a = new List<int>();
        for (int i = 0; i < n; i++)
        {
            a.Add(s[i] - 'a');
        }

        a.Sort();

        int ans = 0;
        bool ok, flag;

        do
        {
            ok = true;
            for (int i = 0; i <= n - k; i++)
            {
                flag = true;
                for (int j = 0; j < k / 2; j++)
                {
                    if (a[i + j] != a[i + k - 1 - j])
                    {
                        flag = false;
                    }
                }
                if (flag) ok = false;

            }
            if (ok) ans++;

        } while (NextPermutation(a));
        Console.WriteLine(ans);
    }

    // C#には next_permutation がないので、自前で実装
    static bool NextPermutation(List<int> a)
    {
        int i = a.Count - 2;
        while (i >= 0 && a[i] >= a[i + 1]) i--;

        if (i < 0) return false;

        int j = a.Count - 1;
        while (a[j] <= a[i]) j--;

        int temp = a[i];
        a[i] = a[j];
        a[j] = temp;

        a.Reverse(i + 1, a.Count - i - 1);
        return true;
    }
}