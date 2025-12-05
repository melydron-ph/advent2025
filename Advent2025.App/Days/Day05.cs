using System.Diagnostics;
using System.IO.Pipelines;

namespace Advent2025.App.Days;

public sealed class Day05 : IDay
{
    public int Number => 5;

    public string Part1(string input)
    {
        var blocks = input.Split("\r\n\r\n");
        string[] separators = [",", "\r\n", "\n"];
        var block1 = blocks[0].Split(separators, StringSplitOptions.RemoveEmptyEntries);
        var ranges = new List<(long, long)>();
        foreach (var range in block1)
        {
            var parts = range.Split("-");
            long start = long.Parse(parts[0]);
            long length = long.Parse(parts[1]) - long.Parse(parts[0]);
            ranges.Add((start, length));
        }
        int result = 0;
        var block2 = blocks[1].Split(separators, StringSplitOptions.RemoveEmptyEntries);
        foreach (var candidate in block2)
        {
            long candidateLong = long.Parse(candidate);
            bool isInRange = false;
            foreach (var range in ranges)
            {
                if (candidateLong >= range.Item1 && candidateLong <= range.Item1 + range.Item2)
                {
                    isInRange = true;
                    break;
                }
            }
            if (isInRange)
            {
                result++;
            }
        }

        return result.ToString();
    }

    public string Part2(string input)
    {
        var blocks = input.Split("\r\n\r\n");
        string[] separators = [",", "\r\n", "\n"];
        var block1 = blocks[0].Split(separators, StringSplitOptions.RemoveEmptyEntries);
        var ranges = new List<(long, long)>();
        foreach (var range in block1)
        {
            var parts = range.Split("-");
            long start = long.Parse(parts[0]);
            long end = long.Parse(parts[1]);
            ranges.Add((start, end));
        }
        ranges = ranges.OrderBy(x => x.Item1).ThenBy(x => x.Item2).ToList();
        var finalRanges = new List<(long, long)>();
        long curStart = ranges[0].Item1;
        long curEnd = ranges[0].Item2;
        for (int i = 1; i < ranges.Count; i++)
        {
            long s = ranges[i].Item1;
            long e = ranges[i].Item2;
            if (s <= curEnd + 1)
            {
                if (e > curEnd)
                    curEnd = e;
            }
            else
            {
                finalRanges.Add((curStart, curEnd));
                curStart = s;
                curEnd = e;
            }
        }
        finalRanges.Add((curStart, curEnd));

        long result = 0;
        foreach (var (a, b) in finalRanges)
        {
            result += (b - a + 1);
        }
        return result.ToString();
    }
}
