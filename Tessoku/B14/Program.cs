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


        input = Console.ReadLine().Split(' ');
        for (int i = 1; i <= n; i++) a[i] = int.Parse(input[i - 1]);
        int pL = n / 2;
        int qL = n - pL;

        int[] p = new int[1 << pL];
        int[] q = new int[1 << qL];
        for (int x = 0; x < (1 << (pL)); x++)
        {
            int sum = 0;
            for (int y = 0; y < pL; y++)
            {
                if (((x >> y) & 1) == 1) sum += a[y + 1];
            }
            p[x] = sum;
        }

        for (int x = 0; x < (1 << (qL)); x++)
        {
            int sum = 0;
            for (int y = 0; y < qL; y++)
            {
                if (((x >> y) & 1) == 1) sum += a[pL + y + 1];
            }
            q[x] = sum;
        }

        Array.Sort(p);
        Array.Sort(q);

        bool ans = false;

        for (int i = 0; i < (1 << pL); i++)
        {
            int l = 0, r = (1 << qL);
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
