using System;
using System.Linq;

class Program
{
    static int n;
    static int[] l = new int[200010], r = new int[200010];
    static void Main(string[] args)
    {
        n = int.Parse(Console.ReadLine());
        string[] input;
        for(int i = 1; i <= n; i++){
            input = Console.ReadLine().Split(' ');
            (l[i], r[i]) = (int.Parse(input[0]), int.Parse(input[1]));
        } 

        long sum = 0;
        long[] ans = new long[200010];
        for(int i = 1; i <= n; i++)
        {
            sum += l[i];
            ans[i] = l[i];
        }

        if (sum > 0)
        {
            Console.WriteLine("No");
            return;
        }

        for(int i = 1; i <= n; i++)
        {
            if(r[i]-l[i] < -sum){
                ans[i] = r[i];
                sum += r[i]-l[i];
            }else if(r[i]-l[i] >= -sum){
                ans[i] = l[i]-sum;
                sum = 0;
                Console.WriteLine("Yes");
                break;
            }
        }

        if(sum==0) Console.WriteLine(string.Join(" ", ans.Skip(1).Take(n)));
        else Console.WriteLine("No");
    }
}