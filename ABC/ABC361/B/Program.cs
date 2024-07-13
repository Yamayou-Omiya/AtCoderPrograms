using System;

class Program
{
    static void Main()
    {
        
        int[,] point = new int[4, 3];
        string[] input = Console.ReadLine().Split(' ');
        (point[0, 0], point[0, 1], point[0, 2]) = (int.Parse(input[0]), int.Parse(input[1]), int.Parse(input[2]));
        (point[1, 0], point[1, 1], point[1, 2]) = (int.Parse(input[3]), int.Parse(input[4]), int.Parse(input[5]));
        input = Console.ReadLine().Split(' ');
        (point[2, 0], point[2, 1], point[2, 2]) = (int.Parse(input[0]), int.Parse(input[1]), int.Parse(input[2]));
        (point[3, 0], point[3, 1], point[3, 2]) = (int.Parse(input[3]), int.Parse(input[4]), int.Parse(input[5]));

        //point0とpoint1を対角線とする立方体とpoint2とpoint3を対角線とする立方体が重なっているかどうかを判定する
        if (point[0, 0] < point[3, 0] && point[1, 0] > point[2, 0] && point[0, 1] < point[3, 1] && point[1, 1] > point[2, 1] && point[0, 2] < point[3, 2] && point[1, 2] > point[2, 2]) Console.WriteLine("Yes");
        else Console.WriteLine("No");

    }
}
