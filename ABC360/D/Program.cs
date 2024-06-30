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
        for (int i = 0; i < leftArrowAnts.Count; i++)
        {
            int l = -1, r = rightArrowAnts.Count-1;
            while (r - l > 1)
            {
                int mid = (r + l) / 2;
                int d = leftArrowAnts[i] - rightArrowAnts[mid];
                if (d <= t) r = mid;
                else l = mid;
            }
            int index = rightArrowAnts.FindIndex(x => x > leftArrowAnts[i]);
            if (index != -1) count += index - r;
            else count += leftArrowAnts.Count - r;
        }

        Console.WriteLine(count);

    }
}
