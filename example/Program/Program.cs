using System;
using System.Collections.Generic;

class Program
{
    static int N;
    static int L;
    static int K;
    static int[] A;
    
    static bool ok(int x)
    {
        int cnt = 0;
        int pre = 0;
        for (int i = 0; i < N; i++)
        {
            if (A[i] - pre >= x && L - A[i] >= x)
            {
                cnt++;
                pre = A[i];
            }
        }
        if (cnt >= K) return true;
        else return false;
    }
    static void Main()
    {

        string[] input = Console.ReadLine().Split(' ');
        N = int.Parse(input[0]);
        L = int.Parse(input[1]);
        K = int.Parse(Console.ReadLine());
        A = new int[N];
        A = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int ans = 0;

        //Aの配列をソートして,Kより大きい最初の要素のインデックスを取り出す
        int left = 0;
        int right = L;
        while (left < right)
        {
            int mid = (left + right) / 2;
            if (ok(mid)) right = mid;
            else left = mid + 1;
        }
        ans = left;
        Console.WriteLine(ans);
        
    }
     
}

