using System;
using System.Linq;

class Program
{
    static bool Check(int mid, int k, int p, int[] q)
    {
        return (p + q[mid] <= k);
    }

    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);

        int[] a = new int[n + 10];
        int[] b = new int[n + 10];
        int[] c = new int[n + 10];
        int[] d = new int[n + 10];

        input = Console.ReadLine().Split(' ');
        for (int i = 1; i <= n; i++) a[i] = int.Parse(input[i - 1]);
        input = Console.ReadLine().Split(' ');
        for (int i = 1; i <= n; i++) b[i] = int.Parse(input[i - 1]);
        input = Console.ReadLine().Split(' ');
        for (int i = 1; i <= n; i++) c[i] = int.Parse(input[i - 1]);
        input = Console.ReadLine().Split(' ');
        for (int i = 1; i <= n; i++) d[i] = int.Parse(input[i - 1]);

        int[] p = new int[n * n + 1];
        int[] q = new int[n * n + 1];
        for (int x = 1; x <= n; x++)
        {
            for (int y = 1; y <= n; y++)
            {
                p[(x - 1) * n + y] = a[x] + b[y];
                q[(x - 1) * n + y] = c[x] + d[y];
            }
        }
        Array.Sort(p);
        Array.Sort(q);

        bool ans = false;

        for (int i = 1; i <= n * n; i++)
        {
            int l = 1, r = n * n + 1;
            while (r - l > 1)
            {
                int mid = (l + r) / 2;
                if (Check(mid, k, p[i], q)) l = mid;
                else r = mid;
            }
            if (p[i] + q[l] == k) ans = true;
        }

        if (ans) Console.WriteLine("Yes");
        else Console.WriteLine("No");
    }
}