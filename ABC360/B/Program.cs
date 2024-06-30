using System;

class Program
{
    static void Main()
    {
        // 入力を読み込む
        string input = Console.ReadLine();
        string[] inputs = input.Split(' ');
        string S = inputs[0];
        string T = inputs[1];

        // 条件を満たすcとwの組が存在するかを探す
        bool found = false;

        // wの可能な長さをループする (wはSの長さ未満)
        for (int w = 1; w < S.Length; w++)
        {
            // Sのw文字毎にc文字目を取ってTを形成できるか確認する
            for (int c = 1; c <= w; c++)
            {
                if (IsMatching(S, T, c, w))
                {
                    found = true;
                    break;
                }
            }
            if (found)
            {
                break;
            }
        }

        // 結果を出力する
        Console.WriteLine(found ? "Yes" : "No");
    }

    static bool IsMatching(string S, string T, int c, int w)
    {
        string concatenated = "";
        for (int i = 0; i < S.Length; i += w)
        {
            if (i + c - 1 < S.Length)
            {
                concatenated += S[i + c - 1];
            }
        }
        return concatenated.Equals(T);
    }
}
