using System;
using System.Collections.Generic;

class Program
{
    static int N,L,K;
    static int[] A;
    static bool Check(int x){
        int count = 0;
        int pre = 0;

        for(int i = 0; i<N;i++){
            if(A[i]-pre>=x){
                count++;
                pre = A[i];
            }
        }
        if(L-pre >=x) count++;
        return (count>=K+1);
    }
    static void Main()
    {

        string[] input = Console.ReadLine().Split(' ');
        N = int.Parse(input[0]);
        L = int.Parse(input[1]);
        K = int.Parse(Console.ReadLine());
        A = new int[N];
        A = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int left=-1,right=L+1;
        while(right-left>1){
            int mid = (left+right)/2;
            if(Check(mid)) left = mid;
            else right = mid;
        }



    }
     
}
