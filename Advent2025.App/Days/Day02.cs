namespace Advent2025.App.Days;

public sealed class Day02 : IDay
{
    public int Number => 2;

    public string Part1(string input)
    {
        string[] separators = [",", "\r\n", "\n"];
        var tokens = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        long result = 0;
        foreach (var t in tokens)
        {
            var s = t.Trim();
            if (s.Length == 0) continue;
            var parts = s.Split('-', 2, StringSplitOptions.None);
            long num1 = long.Parse(parts[0]);
            long num2 = long.Parse(parts[1]);
            for (long i = num1; i <= num2; i++)
            {
                string numStr = i.ToString();
                if (numStr.Length % 2 == 1) continue;
                if (numStr[..(numStr.Length / 2)] == numStr[(numStr.Length / 2)..])
                    result += i;
            }
        }
        return result.ToString();
    }

    public string Part2(string input)
    {
        string[] separators = [",", "\r\n", "\n"];
        var tokens = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        long result = 0;
        foreach (var t in tokens)
        {
            var s = t.Trim();
            if (s.Length == 0) continue;
            var parts = s.Split('-', 2, StringSplitOptions.None);
            long num1 = long.Parse(parts[0]);
            long num2 = long.Parse(parts[1]);
            for (long i = num1; i <= num2; i++)
            {
                string numStr = i.ToString();
                for (int j = 1; j <= numStr.Length / 2; j++)
                {
                    if (numStr.Length % j != 0) continue;
                    string candidateSequence = numStr[..j];
                    bool isGood = true;
                    for (int k = j; k < numStr.Length; k += j)
                    {
                        string segment = numStr.Substring(k, Math.Min(j, numStr.Length - k));
                        if (segment != candidateSequence)
                        {
                            isGood = false;
                            break;
                        }
                    }
                    if (isGood)
                    {
                        DebugSink.WriteLine($"{i}");
                        result += i;
                        break;
                    }
                }
            }
        }
        return result.ToString();

    }
}
