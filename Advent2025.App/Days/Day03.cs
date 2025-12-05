namespace Advent2025.App.Days;

public sealed class Day03 : IDay
{
    public int Number => 3;

    public string Part1(string input)
    {
        var lines = input.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        int result = 0;

        foreach (var line in lines)
        {
            int firstDigit = 0;
            int firstDigitLocation = 0;
            for (int i = 0; i < line.Length - 1; i++)
            {
                if (char.IsDigit(line[i]))
                {
                    int digit = int.Parse(line[i].ToString());
                    if (digit > firstDigit)
                    {
                        firstDigit = digit;
                        firstDigitLocation = i; 
                    }
                }
            }
            int secondDigit = 0;
            int secondDigitLocation = 0;
            for (int i = firstDigitLocation + 1; i < line.Length; i++)  
            {
                if (char.IsDigit(line[i]))
                {
                    int digit = int.Parse(line[i].ToString());
                    if (digit > secondDigit)
                    {
                        secondDigit = digit;
                        secondDigitLocation = i;    
                    }
                }
            }
            result += firstDigit * 10 + secondDigit;
            // DebugSink.WriteLine($"{firstDigit}{secondDigit}, result: {result}");
        }

        return result.ToString();
    }

    public string Part2(string input)
    {
        var lines = input.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        long result = 0;
        foreach (var line in lines)
        {
            var digits = new List<int>();
            for (int i = 0; i < line.Length; i++)
            {
                if (char.IsDigit(line[i]))
                {
                    digits.Add(line[i] - '0');
                }
            }
            int k = Math.Min(12, digits.Count);
            int toRemove = digits.Count - k;
            var stack = new List<int>(digits.Count);
            for (int i = 0; i < digits.Count; i++)
            {
                int d = digits[i];
                while (toRemove > 0 && stack.Count > 0 && stack[stack.Count - 1] < d)
                {
                    stack.RemoveAt(stack.Count - 1);
                    toRemove--;
                }
                stack.Add(d);
            }
            if (toRemove > 0)
            {
                stack.RemoveRange(stack.Count - toRemove, toRemove);
            }
            long value = 0;
            for (int i = 0; i < k && i < stack.Count; i++)
            {
                value = value * 10 + stack[i];
            }
            result += value;
        }
        return result.ToString();
    }
}