#入力した配列のからx以上の要素を取り出す
using System;

class Program{
    static void Main(){
        int[] a = {1, 2, 3, 4, 5, 6, 7, 8, 9};
        int x = 5;
        int[] b = new int[a.Length];
        int j = 0;
        for(int i = 0; i < a.Length; i++){
            if(a[i] >= x){
                b[j] = a[i];
                j++;
            }
        }
        Array.Resize(ref b, j);
        foreach(int i in b){
            Console.WriteLine(i);
        }
    }
}