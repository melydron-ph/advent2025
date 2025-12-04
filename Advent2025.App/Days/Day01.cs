namespace Advent2025.App.Days;

public sealed class Day01 : IDay
{
    public int Number => 1;

    public string Part1(string input)
    {
        var lines = input.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        int num = 50;
        int result = 0;
        foreach (var line in lines)
        {
            char c = line[0];
            int num2 = int.Parse(line.Substring(1));
            num = c == 'R' ? num + num2 : num - num2;
            num = ((num % 100) + 100) % 100;
            if (num == 0)
                result++;
        }
        return result.ToString();
    }

    public string Part2(string input)
    {
        var lines = input.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        int num = 50;
        int result = 0;
        foreach (var line in lines)
        {
            char c = line[0];
            int num2 = int.Parse(line.Substring(1));
            for (int i = 0; i < num2; i++)
            {
                num = c == 'R' ? (num + 1) % 100 : (num + 99) % 100;
                if (num == 0) result++;
            }
        }
        return result.ToString();
    }
}