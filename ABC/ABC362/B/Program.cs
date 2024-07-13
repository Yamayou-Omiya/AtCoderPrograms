using System;
using System.Linq;

class Program
{
    static int[,] point = new int[3,2];
    static void Main(string[] args)
    {
        string[] input;
        for(int i = 0; i < 3; i++){
            input = Console.ReadLine().Split(' ');
            (point[i,0], point[i,1]) = (int.Parse(input[0]), int.Parse(input[1]));
        }

        double a,b,c;
        a = Math.Pow(point[0,0] - point[1,0], 2) + Math.Pow(point[0,1] - point[1,1], 2);
        b = Math.Pow(point[1,0] - point[2,0], 2) + Math.Pow(point[1,1] - point[2,1], 2);
        c = Math.Pow(point[2,0] - point[0,0], 2) + Math.Pow(point[2,1] - point[0,1], 2);

        if(a+b==c || b+c==a || c+a==b) Console.WriteLine("Yes");
        else Console.WriteLine("No");
    }
}
