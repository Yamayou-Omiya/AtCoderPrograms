using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        int n = int.Parse(input[0]);
        int t = int.Parse(input[1]);
        string s = Console.ReadLine();
        int[] x = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        long count = 0;

        List<int> rightArrowAnts = new List<int>();
        List<int> leftArrowAnts = new List<int>();

        for (int i = 0; i < n; i++)
        {
            if (s[i] == '1') rightArrowAnts.Add(x[i]);
            else leftArrowAnts.Add(x[i]);
        }

        rightArrowAnts.Sort();
        leftArrowAnts.Sort();

        t *= 2;
        int a = 0;
        int b = 0;

        for (int i = 0; i < rightArrowAnts.Count; i++)
        {
            while (a < leftArrowAnts.Count && leftArrowAnts[a] < rightArrowAnts[i]) a++;
            while (b < leftArrowAnts.Count && (long)leftArrowAnts[b] - (long)t <= (long)rightArrowAnts[i]) b++;
            count += b - a;
        }
        Console.WriteLine(count);
    }
}
