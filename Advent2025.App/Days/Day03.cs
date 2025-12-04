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
        int result = 0;
        return result.ToString();
    }
}
