using System;
using System.Linq;

class Program
{
    static int n, t;
    static int[] a = new int[200010];
    static bool[,] bingo = new bool[2010, 2010];
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        (n, t) = (int.Parse(input[0]), int.Parse(input[1]));

        input = Console.ReadLine().Split(' ');
        for (int i = 1; i <= t; i++) a[i] = int.Parse(input[i - 1]);
        int ans = -1;

        for (int i = 1; i <= t; i++)
        {
            bingo[(a[i] - 1) / n, (a[i] - 1) % n] = true;
            bool flag = true;
            for (int j = 0; j < n; j++)
            {
                if (bingo[j, (a[i] - 1) % n] == false)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                ans = i;
                break;
            }

            for (int j = 0; j < n; j++)
            {
                flag = true;
                if (bingo[(a[i] - 1) / n, j] == false)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                ans = i;
                break;
            }

            //斜め
            if ((a[i] - 1) / n == (a[i] - 1) % n)
            {
                flag = true;
                for (int j = 0; j < n; j++)
                {
                    if (bingo[j, j] == false)
                    {
                        flag = false;
                        break;
                    }
                }
            }
            if (flag)
            {
                ans = i;
                break;
            }

            if ((a[i] - 1) / n + (a[i] - 1) % n == n - 1)
            {
                flag = true;
                for (int j = 0; j < n; j++)
                {
                    if (bingo[j, n - 1 - j] == false)
                    {
                        flag = false;
                        break;
                    }
                }
            }
            if (flag)
            {
                ans = i;
                break;
            }
        }
        Console.WriteLine(ans);

    }

}
