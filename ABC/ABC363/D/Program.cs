using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        BigInteger N = BigInteger.Parse(Console.ReadLine());
        BigInteger result = FindNthPalindrome(N);
        Console.WriteLine(result);
    }

    static BigInteger FindNthPalindrome(BigInteger N)
    {
        BigInteger count = 0;
        BigInteger num = 0;

        while (count < N)
        {
            if (IsPalindrome(num))
            {
                count++;
            }
            if (count < N)
            {
                num++;
            }
        }

        return num;
    }

    static bool IsPalindrome(BigInteger num)
    {
        string str = num.ToString();
        int left = 0;
        int right = str.Length - 1;

        while (left < right)
        {
            if (str[left] != str[right])
            {
                return false;
            }
            left++;
            right--;
        }

        return true;
    }
}